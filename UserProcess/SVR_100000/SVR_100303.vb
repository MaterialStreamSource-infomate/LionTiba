'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z�ׯ�ݸ޷�ݾٸ׽
' �y�쐬�zSIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon�g�p�̈�
Imports MateCommon.clsConst                 'Confiģ�ٓǍ��ݓ��W��Ӽޭ�َg�p�̈�
#End Region

Public Class SVR_100303
    Inherits clsTemplateServer

#Region "  �׽���������p�ϐ���`                                                                "
#End Region
#Region "  �����è�ϐ���`                                                                      "
    Private mFTRK_BUF_NO As Nullable(Of Integer)    '�ׯ�ݸ��ޯ̧��
    Private mFPALLET_ID As String                   '��گ�ID
    Private mFINOUT_STS As Nullable(Of Integer)     'INOUT
    Private mKARA_OUT_FLAG As Integer = FLAG_OFF    '��o���׸�
#End Region
#Region "  �����è��`                                                                          "
    ''' =======================================
    ''' <summary>�ׯ�ݸ��ޯ̧��</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FTRK_BUF_NO() As Integer
        Get
            Return mFTRK_BUF_NO
        End Get
        Set(ByVal Value As Integer)
            mFTRK_BUF_NO = Value
        End Set
    End Property
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
    ''' <summary>INOUT</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FINOUT_STS() As Integer
        Get
            Return mFINOUT_STS
        End Get
        Set(ByVal Value As Integer)
            mFINOUT_STS = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>��o���׸�</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property KARA_OUT_FLAG() As Integer
        Get
            Return mKARA_OUT_FLAG
        End Get
        Set(ByVal Value As Integer)
            mKARA_OUT_FLAG = Value
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
#Region "  �ׯ�ݸ޷�ݾ�                                                                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ׯ�ݸ޷�ݾ�
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub MENTE_CANCEL()
        Try
            Dim strMsg As String                    'ү����
            Dim intRet As RetCode                   '�߂�l


            '************************
            '�����è����
            '************************
            If IsNull(mFTRK_BUF_NO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�ׯ�ݸ��ޯ̧��]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFPALLET_ID) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[��گ�ID]"
                Throw New UserException(strMsg)
            End If

           
            '************************
            '�ׯ�ݸ�Ͻ��̓���
            '************************
            Dim objTMST_TRK As New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog) '�ׯ�ݸ��ޯ̧Ͻ��׽
            objTMST_TRK.FTRK_BUF_NO = mFTRK_BUF_NO                      '�ׯ�ݸ��ޯ̧No
            intRet = objTMST_TRK.GET_TMST_TRK(True)                     '����

           
            '************************
            '�ׯ�ݸ޷�ݾ�
            '************************
            Select Case TO_INTEGER(objTMST_TRK.FBUF_KIND)
                Case FBUF_KIND_SIN : Call Mente_Cancel_IN(mFPALLET_ID, mFTRK_BUF_NO)         '���ɒ�������ݾ�
                Case FBUF_KIND_SASRS : Call Mente_Cancel_OUT_RSV(mFPALLET_ID, mFTRK_BUF_NO)  '�o�ɗ\�񋭐���ݾ�
                Case FBUF_KIND_SHIRA : Call Mente_Cancel_OUT_RSV_NOTORSV(mFPALLET_ID, mFTRK_BUF_NO)        '�o�ɗ\�񋭐���ݾفi��������������������j
                Case FBUF_KIND_SOUT : Call Mente_Cancel_OUT(mFPALLET_ID, mFTRK_BUF_NO)       '�o�ɒ�������ݾ�
                Case FBUF_KIND_STRNS
                    'If mFTRK_BUF_NO = FTRK_BUF_NO_2004 Then
                    '    '(�ڰݔ������̏ꍇ)
                    '    Call Mente_Cancel_TRNS_CRANE(mFPALLET_ID, mFTRK_BUF_NO)             '������������ݾ�(�ڰݔ�����)
                    'Else
                    '(���̑��������̏ꍇ)
                    Call Mente_Cancel_TRNS(mFPALLET_ID, mFTRK_BUF_NO)                   '������������ݾ�
                    'End If
                Case FBUF_KIND_SSOUKO : Call Mente_Cancel_SOUKO(mFPALLET_ID, mFTRK_BUF_NO)   '�q�ɊԈړ�����ݾ�
                Case Else
                    '(������Ȃ��ꍇ)
                    strMsg = ERRMSG_DISP_MENTE_CANCEL_BUF_KIND & "[�z��O�ޯ̧]" & "[�ޯ̧No:" & TO_STRING(objTMST_TRK.FTRK_BUF_NO) & "]"
                    Throw New UserException(strMsg)
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

#Region "  ���ɒ�������ݾ�                                                                      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���ɒ�������ݾ�
    ''' </summary>
    ''' <param name="strPALLET_ID">��گ�ID</param>
    ''' <param name="intTRK_BUF_NO">�ޯ̧��</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Mente_Cancel_IN(ByVal strPALLET_ID As String, ByVal intTRK_BUF_NO As Integer)
        Try
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����


            '************************
            '���ɒ��ޯ̧�̓���
            '************************
            Dim objTPRG_TRK_BUF_RELAY As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)       '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF_RELAY.FTRK_BUF_NO = intTRK_BUF_NO                               '�ޯ̧��
            objTPRG_TRK_BUF_RELAY.FPALLET_ID = strPALLET_ID                                 '��گ�ID
            intRet = objTPRG_TRK_BUF_RELAY.GET_TPRG_TRK_BUF(True)                           '����
            If IsNull(objTPRG_TRK_BUF_RELAY.FRSV_BUF_FM) = True Then
                '(������������ς̏ꍇ)
                strMsg = ERRMSG_DISP_MENTE_CANCEL_BUF_KIND & "[�������J����]" & "[�ޯ̧��:" & TO_STRING(objTPRG_TRK_BUF_RELAY.FTRK_BUF_NO) & "  ,��گ�ID:" & objTPRG_TRK_BUF_RELAY.FPALLET_ID & "]"
                Throw New UserException(strMsg)
            End If


            '************************
            '�ð����ޯ̧�̓���
            '************************
            Dim objTPRG_TRK_BUF_ST As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)  '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF_ST.FTRK_BUF_NO = objTPRG_TRK_BUF_RELAY.FRSV_BUF_FM      '�ޯ̧��
            objTPRG_TRK_BUF_ST.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_FM '�z��
            intRet = objTPRG_TRK_BUF_ST.GET_TPRG_TRK_BUF(True)                      '����


            '************************
            '�������J��
            '************************
            If objTPRG_TRK_BUF_ST.FRSV_PALLET <> objTPRG_TRK_BUF_RELAY.FPALLET_ID Or _
               objTPRG_TRK_BUF_ST.FRES_KIND <> FRES_KIND_SRSV_TRNS_IN Then
                '(������������ς̏ꍇ)
                strMsg = ERRMSG_DISP_MENTE_CANCEL_BUF_KIND & "[�������J����]" & "[�ޯ̧��:" & TO_STRING(objTPRG_TRK_BUF_RELAY.FTRK_BUF_NO) & "  ,��گ�ID:" & objTPRG_TRK_BUF_RELAY.FPALLET_ID & "]"
                Throw New UserException(strMsg)
            End If


            '************************
            '�q���ޯ̧�̓���
            '************************
            Dim objTPRG_TRK_BUF_ASRS As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)  '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO = objTPRG_TRK_BUF_RELAY.FRSV_BUF_TO      '�ޯ̧��
            objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_TO '�z��
            intRet = objTPRG_TRK_BUF_ASRS.GET_TPRG_TRK_BUF(True)                      '����


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


            '************************
            '�݌Ɉ������̓���
            '************************
            Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)     '�݌Ɉ������
            objTSTS_HIKIATE.FPALLET_ID = strPALLET_ID                               '��گ�ID
            intRet = objTSTS_HIKIATE.GET_TSTS_HIKIATE_PALLET                        '����
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TSTS_HIKIATE & "[��گ�ID:" & objTSTS_HIKIATE.FPALLET_ID & "]"
                Throw New UserException(strMsg)
            End If


            '************************
            '�����w��QUE�̓���
            '************************
            Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog) '�����w��QUE
            objTPLN_CARRY_QUE.FPALLET_ID = strPALLET_ID                             '��گ�ID
            intRet = objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE(True)                     '����


            '************************
            '�݌Ɉړ�
            '************************
            Dim objSVR_100103 As New SVR_100103(Owner, ObjDb, ObjDbLog) '�݌Ɉړ��׽
            objSVR_100103.OBJTPRG_TRK_BUF_FM = objTPRG_TRK_BUF_RELAY    '�ׯ�ݸ��ޯ̧(���ɒ��ޯ̧)
            objSVR_100103.OBJTPRG_TRK_BUF_TO = objTPRG_TRK_BUF_ST       '�ׯ�ݸ��ޯ̧(�ð����ޯ̧)
            objSVR_100103.FPALLET_ID = strPALLET_ID                     '��گ�ID
            objSVR_100103.FINOUT_STS = FINOUT_STS_SMENTE_CANCEL          'INOUT
            objSVR_100103.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND   '��Ǝ��
            objSVR_100103.INTCLEAR_FM_FLAG = FLAG_ON                    '�������ر�׸�
            objSVR_100103.STOCK_TRNS()                                  '�ړ�


            '************************
            '�����w��QUE�̍X�V
            '************************
            objTPLN_CARRY_QUE.FCARRYQUE_DIR_STS = FCARRYQUE_DIR_STS_SNON             '�����w����(�����{)
            objTPLN_CARRY_QUE.FUPDATE_DT = Now                                      '���ݓ���
            objTPLN_CARRY_QUE.UPDATE_TPLN_CARRY_QUE()                               '�X�V


            '************************
            '�������䑗�MIF�̍폜
            '************************
            Dim objTLIF_TRNS_SEND As New TBL_TLIF_TRNS_SEND(Owner, ObjDb, ObjDbLog) '�������䑗�MIF�׽
            objTLIF_TRNS_SEND.FPALLET_ID = strPALLET_ID                             '��گ�ID
            objTLIF_TRNS_SEND.DELETE_TLIF_TRNS_SEND_PALLET()                        '�폜


            '************************
            '���������MIF�̍폜
            '************************
            Dim objTLIF_TRNS_RECV As New TBL_TLIF_TRNS_RECV(Owner, ObjDb, ObjDbLog) '���������MIF�׽
            objTLIF_TRNS_RECV.FPALLET_ID = strPALLET_ID                             '��گ�ID
            objTLIF_TRNS_RECV.DELETE_TLIF_TRNS_RECV_PALLET()                        '�폜


            '************************
            '�ري֘A�t���폜
            '************************
            Dim objTPRG_SERIAL As New TBL_TPRG_SERIAL(Owner, ObjDb, ObjDbLog)       '�ري֘A�t���׽
            objTPRG_SERIAL.FPALLET_ID = strPALLET_ID                                '��گ�ID
            objTPRG_SERIAL.DELETE_TPRG_SERIAL()                                     '�폜

            '************************
            '�������N��
            '************************
            Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)         '������Ǘ��׽
            objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                                '�N��(������������)


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#Region "  �o�ɗ\�񋭐���ݾ�(�������������������)                                                                    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �o�ɗ\�񋭐���ݾ�(�������������������)
    ''' </summary>
    ''' <param name="strPALLET_ID">��گ�ID</param>
    ''' <param name="intTRK_BUF_NO">�ޯ̧��</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Mente_Cancel_OUT_RSV_NOTORSV(ByVal strPALLET_ID As String, ByVal intTRK_BUF_NO As Integer)
        Try
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����


            '������������************************************************************************************************************
            'JobMate:N.Dounoshita 2013/09/03 �\�萔ϲŽ1


            ''*********************************************
            ''�\�萔ϲŽ1
            ''*********************************************
            'Call UpdateYoteiNumMinus1(mFTRK_BUF_NO, mFPALLET_ID)


            '******************************************************************************************
            '�ׯ�ݸ޷�ݾقŁA�o�׎w��.�o�׈������������ɖ߂�
            '******************************************************************************************
            Call Update_XSYUKKA_KON_RESERVE_Minus(mFPALLET_ID)


            '������������************************************************************************************************************


            '************************
            '�q���ޯ̧�̓���
            '************************
            Dim objTPRG_TRK_BUF_ASRS As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)    '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO = intTRK_BUF_NO                            '�ޯ̧��
            objTPRG_TRK_BUF_ASRS.FPALLET_ID = strPALLET_ID                              '��گ�ID
            intRet = objTPRG_TRK_BUF_ASRS.GET_TPRG_TRK_BUF(True)                        '����

            '************************
            '�݌Ɉ������̓���
            '************************
            Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)             '�݌Ɉ������
            objTSTS_HIKIATE.FPALLET_ID = strPALLET_ID                                       '��گ�ID
            intRet = objTSTS_HIKIATE.GET_TSTS_HIKIATE_PALLET                                '����
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TSTS_HIKIATE & "[��گ�ID:" & objTSTS_HIKIATE.FPALLET_ID & "]"
                Throw New UserException(strMsg)
            End If


            '������������************************************************************************************************************
            'SystemMate:N.Dounoshita 2012/08/25  ���ꏈ���p�ɍ�Ǝ�ʂ��L��
            Dim intFSAGYOU_KIND As Nullable(Of Integer) = objTSTS_HIKIATE.FSAGYOU_KIND      '��Ǝ��
            ' ''������������************************************************************************************************************


            '************************
            '�q���ޯ̧�̍X�V
            '************************
            objTPRG_TRK_BUF_ASRS.FRSV_PALLET = DEFAULT_STRING                   '��������گ�ID
            objTPRG_TRK_BUF_ASRS.FRES_KIND = FRES_KIND_SZAIKO                    '�������
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


            '************************
            '�\���ޯ̧�̊J��
            '************************
            Dim objTPRG_TRK_BUF_RSV As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)     '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF_RSV.FRSV_PALLET = objTPRG_TRK_BUF_ASRS.FPALLET_ID           '��������گ�ID
            objTPRG_TRK_BUF_RSV.CLEAR_TPRG_TRK_BUF_RSV_PC()                             '�J��


            '************************
            '�݌ɏ��̍X�V
            '************************
            Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)             '�݌ɏ��ð��ٸ׽
            objTRST_STOCK.FPALLET_ID = strPALLET_ID                                     '��گ�ID
            objTRST_STOCK.GET_TRST_STOCK_KONSAI(False)
            For ii As Integer = LBound(objTRST_STOCK.ARYME) To UBound(objTRST_STOCK.ARYME)
                objTRST_STOCK.ARYME(ii).FTR_RES_VOL = 0         '����������
                objTRST_STOCK.ARYME(ii).FUPDATE_DT = Now        '�X�V����
                objTRST_STOCK.ARYME(ii).UPDATE_TRST_STOCK()     '�X�V
            Next
            objTRST_STOCK.ARYME_CLEAR()


            '************************
            '�����w��QUE�̍폜
            '************************
            Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)     '�����w��QUE�׽
            objTPLN_CARRY_QUE.FPALLET_ID = strPALLET_ID                               '��گ�ID
            objTPLN_CARRY_QUE.DELETE_TPLN_CARRY_QUE_PALLET()                            '�폜


            '************************
            '�݌Ɉ������̍폜
            '************************
            objTSTS_HIKIATE = New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)  '�݌Ɉ������׽
            objTSTS_HIKIATE.FPALLET_ID = strPALLET_ID
            objTSTS_HIKIATE.DELETE_TSTS_HIKIATE_PALLET()       '�폜


            '************************
            '�������N��
            '************************
            Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)         '������Ǘ��׽
            objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                                '�N��(������������)


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#Region "  �o�ɗ\�񋭐���ݾ�                                                                    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �o�ɗ\�񋭐���ݾ�
    ''' </summary>
    ''' <param name="strPALLET_ID">��گ�ID</param>
    ''' <param name="intTRK_BUF_NO">�ޯ̧��</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Mente_Cancel_OUT_RSV(ByVal strPALLET_ID As String, ByVal intTRK_BUF_NO As Integer)
        Try
            ''Dim intRet As RetCode                   '�߂�l
            ''Dim strMsg As String                    'ү����

            '������������************************************************************************************************************
            'JobMate:A.Noto 2012/10/25 �q���ޯ̧�����������ı��
            '                          (�����������݌ɂ��ׯ�ݸނ͔��o�\��ɂ��邪�A���̎��_�ł͔����悪���܂��Ă��Ȃ�����)
            ' ''************************
            ' ''�q���ޯ̧�̓���
            ' ''************************
            ''Dim objTPRG_TRK_BUF_ASRS As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)    '�ׯ�ݸ��ޯ̧�׽
            ''objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO = intTRK_BUF_NO                            '�ޯ̧��
            ''objTPRG_TRK_BUF_ASRS.FPALLET_ID = strPALLET_ID                              '��گ�ID
            ''intRet = objTPRG_TRK_BUF_ASRS.GET_TPRG_TRK_BUF(True)                        '����
            ''If IsNull(objTPRG_TRK_BUF_ASRS.FTR_TO) = True Then
            ''    '(�����斢�����̏ꍇ)
            ''    strMsg = ERRMSG_DISP_MENTE_CANCEL_BUF_KIND & "[�����斢����]" & "[�ׯ�ݸ�:" & objTPRG_TRK_BUF_ASRS.FDISP_ADDRESS & "]"
            ''    Throw New UserException(strMsg)
            ''End If
            '������������************************************************************************************************************

            '************************
            '�o�ɗ\��ݾ�
            '************************
            Mente_Cancel_OUT_RSV_NOTORSV(strPALLET_ID, intTRK_BUF_NO)


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#Region "  �o�ɒ�������ݾ�                                                                      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �o�ɒ�������ݾ�
    ''' </summary>
    ''' <param name="strPALLET_ID">��گ�ID</param>
    ''' <param name="intTRK_BUF_NO">�ޯ̧��</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Mente_Cancel_OUT(ByVal strPALLET_ID As String, ByVal intTRK_BUF_NO As Integer)
        Try
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����


            '************************
            '�o�ɒ��ޯ̧�̓���
            '************************
            Dim objTPRG_TRK_BUF_RELAY As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)   '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF_RELAY.FTRK_BUF_NO = intTRK_BUF_NO                           '�ޯ̧��
            objTPRG_TRK_BUF_RELAY.FPALLET_ID = strPALLET_ID                             '��گ�ID
            intRet = objTPRG_TRK_BUF_RELAY.GET_TPRG_TRK_BUF(True)                       '����


            '************************
            '�ð����ޯ̧�̓���
            '************************
            Dim objTPRG_TRK_BUF_ST As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)  '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF_ST.FTRK_BUF_NO = objTPRG_TRK_BUF_RELAY.FRSV_BUF_TO      '�ޯ̧��
            objTPRG_TRK_BUF_ST.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_TO '�z��
            intRet = objTPRG_TRK_BUF_ST.GET_TPRG_TRK_BUF(True)                      '����


            '************************
            '�q���ޯ̧�̓���
            '************************
            Dim objTPRG_TRK_BUF_ASRS As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)  '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO = objTPRG_TRK_BUF_RELAY.FRSV_BUF_FM      '�ޯ̧��
            objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_FM '�z��
            intRet = objTPRG_TRK_BUF_ASRS.GET_TPRG_TRK_BUF(True)                      '����


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


            '************************
            '�݌Ɉ������̓���
            '************************
            Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)     '�݌Ɉ������
            objTSTS_HIKIATE.FPALLET_ID = objTPRG_TRK_BUF_RELAY.FPALLET_ID           '��گ�ID
            intRet = objTSTS_HIKIATE.GET_TSTS_HIKIATE_PALLET                        '����
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TSTS_HIKIATE & "[��گ�ID:" & objTSTS_HIKIATE.FPALLET_ID & "]"
                Throw New UserException(strMsg)
            End If


            '************************
            '�����w��QUE�̓���
            '************************
            Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog) '�����w��QUE
            objTPLN_CARRY_QUE.FPALLET_ID = objTPRG_TRK_BUF_RELAY.FPALLET_ID         '��گ�ID
            intRet = objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE(True)                     '����


            '************************
            '�������J������
            '************************
            If objTPRG_TRK_BUF_ASRS.FRSV_PALLET <> objTPRG_TRK_BUF_RELAY.FPALLET_ID Or _
               objTPRG_TRK_BUF_ASRS.FRES_KIND <> FRES_KIND_SRSV_TRNS_OUT Then
                '(������������ς̏ꍇ)
                strMsg = ERRMSG_DISP_MENTE_CANCEL_BUF_KIND & "[�������J����]" & "[�ޯ̧��:" & TO_STRING(objTPRG_TRK_BUF_RELAY.FTRK_BUF_NO) & "  ,��گ�ID:" & objTPRG_TRK_BUF_RELAY.FPALLET_ID & "]"
                Throw New UserException(strMsg)
            End If


            '************************
            '�݌Ɉړ�
            '************************
            Dim objSVR_100103 As New SVR_100103(Owner, ObjDb, ObjDbLog) '�݌Ɉړ��׽
            objSVR_100103.OBJTPRG_TRK_BUF_FM = objTPRG_TRK_BUF_RELAY    '�ׯ�ݸ��ޯ̧(���ɒ��ޯ̧)
            objSVR_100103.OBJTPRG_TRK_BUF_TO = objTPRG_TRK_BUF_ASRS     '�ׯ�ݸ��ޯ̧(�q���ޯ̧)
            objSVR_100103.FPALLET_ID = objTPRG_TRK_BUF_RELAY.FPALLET_ID '��گ�ID
            objSVR_100103.FINOUT_STS = FINOUT_STS_SMENTE_CANCEL          'INOUT
            objSVR_100103.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND   '��Ǝ��
            objSVR_100103.INTCLEAR_FM_FLAG = FLAG_ON                    '�������ر�׸�
            objSVR_100103.STOCK_TRNS()                                  '�ړ�


            '************************
            '�q���ޯ̧�̍X�V
            '************************
            objTPRG_TRK_BUF_ASRS.FRES_KIND = FRES_KIND_SRSV_TRNS_OUT     '���o�\��
            objTPRG_TRK_BUF_ASRS.FTRNS_FM = DEFAULT_STRING              '�����w�ߗpFM
            objTPRG_TRK_BUF_ASRS.FTRNS_TO = DEFAULT_STRING              '�����w�ߗpTO
            objTPRG_TRK_BUF_ASRS.FRSV_BUF_TO = DEFAULT_INTEGER          'TO�����ޯ̧��
            objTPRG_TRK_BUF_ASRS.FRSV_ARRAY_TO = DEFAULT_INTEGER        'TO�����z��
            objTPRG_TRK_BUF_ASRS.FDISP_ADDRESS_TO = DEFAULT_STRING      'TO�\�L�p
            objTPRG_TRK_BUF_ASRS.FBUF_IN_DT = Now                       '�X�V����
            objTPRG_TRK_BUF_ASRS.UPDATE_TPRG_TRK_BUF()                  '�X�V


            '************************
            '�\���ޯ̧�̉��
            '************************
            Dim objTPRG_TRK_BUF_RSV As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog) '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF_RSV.FRSV_PALLET = objTPRG_TRK_BUF_ASRS.FPALLET_ID       '��گ�ID
            objTPRG_TRK_BUF_RSV.CLEAR_TPRG_TRK_BUF_RSV_PC()                         '���


            '************************
            '�����w��QUE�̍X�V
            '************************
            objTPLN_CARRY_QUE.FCARRYQUE_DIR_STS = FCARRYQUE_DIR_STS_SNON             '�����w����(�����{)
            objTPLN_CARRY_QUE.FUPDATE_DT = Now                                      '���ݓ���
            objTPLN_CARRY_QUE.UPDATE_TPLN_CARRY_QUE()                               '�X�V


            '************************
            '�ري֘A�t���폜
            '************************
            Dim objTPRG_SERIAL As New TBL_TPRG_SERIAL(Owner, ObjDb, ObjDbLog)       '�ري֘A�t���׽
            objTPRG_SERIAL.FPALLET_ID = strPALLET_ID                                '��گ�ID
            objTPRG_SERIAL.DELETE_TPRG_SERIAL()                                     '�폜


            '************************
            '�������䑗�MIF�̍폜
            '************************
            Dim objTLIF_TRNS_SEND As New TBL_TLIF_TRNS_SEND(Owner, ObjDb, ObjDbLog) '�������䑗�MIF�׽
            objTLIF_TRNS_SEND.FPALLET_ID = strPALLET_ID                             '��گ�ID
            objTLIF_TRNS_SEND.DELETE_TLIF_TRNS_SEND_PALLET()                        '�폜


            '************************
            '���������MIF�̍폜
            '************************
            Dim objTLIF_TRNS_RECV As New TBL_TLIF_TRNS_RECV(Owner, ObjDb, ObjDbLog) '���������MIF�׽
            objTLIF_TRNS_RECV.FPALLET_ID = strPALLET_ID                             '��گ�ID
            objTLIF_TRNS_RECV.DELETE_TLIF_TRNS_RECV_PALLET()                        '�폜


            '******************************************************************************************************
            '�o�ɗ\�񋭐���ݾ�(�o�ɒI�\��܂Ŗ߂����̂ŁA����ɂ�����i�K�߂�)
            '******************************************************************************************************
            Call Mente_Cancel_OUT_RSV(strPALLET_ID, objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO)


            '************************
            '�������N��
            '************************
            Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)         '������Ǘ��׽
            objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                                '�N��(������������)


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#Region "  ������������ݾ�                                                                      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ������������ݾ�
    ''' </summary>
    ''' <param name="strPALLET_ID">��گ�ID</param>
    ''' <param name="intTRK_BUF_NO">�ޯ̧��</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Mente_Cancel_TRNS(ByVal strPALLET_ID As String, ByVal intTRK_BUF_NO As Integer)
        Try
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����


            '************************
            '�������ޯ̧�̓���
            '************************
            Dim objTPRG_TRK_BUF_RELAY As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)       '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF_RELAY.FTRK_BUF_NO = intTRK_BUF_NO                               '�ޯ̧��
            objTPRG_TRK_BUF_RELAY.FPALLET_ID = strPALLET_ID                                 '��گ�ID
            intRet = objTPRG_TRK_BUF_RELAY.GET_TPRG_TRK_BUF(True)                           '����
            If IsNull(objTPRG_TRK_BUF_RELAY.FRSV_BUF_FM) = True Then
                '(������������ς̏ꍇ)
                strMsg = ERRMSG_DISP_MENTE_CANCEL_BUF_KIND & "[�������J����]" & "[�ޯ̧��:" & TO_STRING(objTPRG_TRK_BUF_RELAY.FTRK_BUF_NO) & "  ,��گ�ID:" & objTPRG_TRK_BUF_RELAY.FPALLET_ID & "]"
                Throw New UserException(strMsg)
            End If


            '************************
            '�������ޯ̧�̓���
            '************************
            Dim objTPRG_TRK_BUF_FM As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)  '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF_FM.FTRK_BUF_NO = objTPRG_TRK_BUF_RELAY.FRSV_BUF_FM      '�ޯ̧��
            objTPRG_TRK_BUF_FM.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_FM '�z��
            intRet = objTPRG_TRK_BUF_FM.GET_TPRG_TRK_BUF(True)                      '����


            If objTPRG_TRK_BUF_FM.FRSV_PALLET <> objTPRG_TRK_BUF_RELAY.FPALLET_ID Or _
               objTPRG_TRK_BUF_FM.FRES_KIND <> FRES_KIND_SRSV_TRNS_IN Then
                '(������������ς̏ꍇ)
                strMsg = ERRMSG_DISP_MENTE_CANCEL_BUF_KIND & "[�������J����]" & "[�ޯ̧��:" & TO_STRING(objTPRG_TRK_BUF_RELAY.FTRK_BUF_NO) & "  ,��گ�ID:" & objTPRG_TRK_BUF_RELAY.FPALLET_ID & "]"
                Throw New UserException(strMsg)
            End If


            '************************
            '�������ޯ̧�̓���
            '************************
            Dim objTPRG_TRK_BUF_TO As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)  '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF_TO.FTRK_BUF_NO = objTPRG_TRK_BUF_RELAY.FRSV_BUF_TO      '�ޯ̧��
            objTPRG_TRK_BUF_TO.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_TO '�z��
            intRet = objTPRG_TRK_BUF_TO.GET_TPRG_TRK_BUF(True)                      '����


            '************************
            '�݌Ɉ������̓���
            '************************
            Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)     '�݌Ɉ������
            objTSTS_HIKIATE.FPALLET_ID = strPALLET_ID                               '��گ�ID
            intRet = objTSTS_HIKIATE.GET_TSTS_HIKIATE_PALLET                        '����
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TSTS_HIKIATE & "[��گ�ID:" & objTSTS_HIKIATE.FPALLET_ID & "]"
                Throw New UserException(strMsg)
            End If


            '************************
            '�����w��QUE�̓���
            '************************
            Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog) '�����w��QUE
            objTPLN_CARRY_QUE.FPALLET_ID = strPALLET_ID                             '��گ�ID
            intRet = objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE(True)                     '����


            '************************
            '�݌Ɉړ�
            '************************
            Dim intFTRK_BUF_NO_FM As Integer = objTPRG_TRK_BUF_FM.FTRK_BUF_NO
            Dim intFTR_FM_RELAY As Integer = objTPRG_TRK_BUF_RELAY.FTR_FM

            Dim objSVR_100103 As New SVR_100103(Owner, ObjDb, ObjDbLog) '�݌Ɉړ��׽
            objSVR_100103.OBJTPRG_TRK_BUF_FM = objTPRG_TRK_BUF_RELAY    '�ׯ�ݸ��ޯ̧(���ɒ��ޯ̧)
            objSVR_100103.OBJTPRG_TRK_BUF_TO = objTPRG_TRK_BUF_FM       '�ׯ�ݸ��ޯ̧(�q���ޯ̧)
            objSVR_100103.FPALLET_ID = strPALLET_ID                     '��گ�ID
            objSVR_100103.FINOUT_STS = FINOUT_STS_SMENTE_CANCEL          'INOUT
            objSVR_100103.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND   '��Ǝ��
            objSVR_100103.INTCLEAR_FM_FLAG = FLAG_ON                    '�������ر�׸�
            objSVR_100103.STOCK_TRNS()                                  '�ړ�


            '************************
            '�ŏI���B�ޯ̧�̓���
            '************************
            Dim intRSV_BUF_TO As Nullable(Of Integer) = DEFAULT_INTEGER                 'TO�����ׯ�ݸއ�
            Dim intRSV_ARRAY_TO As Nullable(Of Integer) = DEFAULT_INTEGER               'TO�����z��
            Dim strDISP_ADDRESS_TO As String = DEFAULT_STRING                           'TO�\�L�p���ڽ
            Dim objTPRG_TRK_BUF_END As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)     '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF_END.FTRK_BUF_NO = objTPRG_TRK_BUF_FM.FTR_TO                 '�ŏI�ޯ̧��
            objTPRG_TRK_BUF_END.FRSV_PALLET = mFPALLET_ID                               '��������گ�ID
            intRet = objTPRG_TRK_BUF_END.GET_TPRG_TRK_BUF_RSV_PALLET()
            If intRet = RetCode.OK Then
                '������������************************************************************************************************************
                'Checked SystemMate:N.Dounoshita 2012/01/26 �u����TO�ׯ�ݸ��ޯ̧���v���g�p���Ă���̂͊ԈႢ�Ǝv����B
                '    intRSV_BUF_TO = objTPRG_TRK_BUF_END.FTRK_BUF_NO                         'TO�����ׯ�ݸއ�
                '    intRSV_ARRAY_TO = objTPRG_TRK_BUF_END.FTRK_BUF_ARRAY                    'TO�����z��
                '������������************************************************************************************************************
                strDISP_ADDRESS_TO = objTPRG_TRK_BUF_END.FDISP_ADDRESS                  'TO�\�L�p���ڽ
            End If


            '************************
            '�\���ޯ̧�̉��
            '************************
            Dim objTPRG_TRK_BUF_RSV As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog) '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF_RSV.FRSV_PALLET = strPALLET_ID                          '��گ�ID
            objTPRG_TRK_BUF_RSV.CLEAR_TPRG_TRK_BUF_RSV_PC()                         '���

            '************************
            '�ŏI���B�ޯ̧�̍ė\��
            '************************
            If IsNull(objTPRG_TRK_BUF_END.FTRK_BUF_ARRAY) = False Then
                '(�ŏI�ޯ̧�������Ă���Ă���ꍇ)
                objTPRG_TRK_BUF_END.UPDATE_TPRG_TRK_BUF()
            End If

            '************************
            '�������ޯ̧�̍X�V
            '************************
            '������������************************************************************************************************************
            'Checked SystemMate:N.Dounoshita 2012/01/26 �u����TO�ׯ�ݸ��ޯ̧���v���g�p���Ă���̂͊ԈႢ�Ǝv����B
            'objTPRG_TRK_BUF_FM.FTRNS_FM = objTPRG_TRK_BUF_FM.FTRK_BUF_NO
            'objTPRG_TRK_BUF_FM.FTRNS_TO = TO_STRING(intRSV_BUF_TO)
            '������������************************************************************************************************************
            objTPRG_TRK_BUF_FM.FRSV_BUF_FM = objTPRG_TRK_BUF_FM.FTRK_BUF_NO
            objTPRG_TRK_BUF_FM.FRSV_ARRAY_FM = objTPRG_TRK_BUF_FM.FTRK_BUF_ARRAY
            objTPRG_TRK_BUF_FM.FRSV_BUF_TO = intRSV_BUF_TO
            objTPRG_TRK_BUF_FM.FRSV_ARRAY_TO = intRSV_ARRAY_TO
            objTPRG_TRK_BUF_FM.FDISP_ADDRESS_TO = strDISP_ADDRESS_TO
            objTPRG_TRK_BUF_FM.FBUF_IN_DT = Now
            objTPRG_TRK_BUF_FM.UPDATE_TPRG_TRK_BUF()


            '************************
            '�����w��QUE�̍X�V
            '************************
            objTPLN_CARRY_QUE.FCARRYQUE_DIR_STS = FCARRYQUE_DIR_STS_SNON             '�����w����(�����{)
            objTPLN_CARRY_QUE.FUPDATE_DT = Now                                      '���ݓ���
            objTPLN_CARRY_QUE.UPDATE_TPLN_CARRY_QUE()                               '�X�V

            '************************
            '�ري֘A�t���폜
            '************************
            Dim objTPRG_SERIAL As New TBL_TPRG_SERIAL(Owner, ObjDb, ObjDbLog)       '�ري֘A�t���׽
            objTPRG_SERIAL.FPALLET_ID = strPALLET_ID                                '��گ�ID
            objTPRG_SERIAL.DELETE_TPRG_SERIAL()                                     '�폜


            '************************
            '�������䑗�MIF�̍폜
            '************************
            Dim objTLIF_TRNS_SEND As New TBL_TLIF_TRNS_SEND(Owner, ObjDb, ObjDbLog) '�������䑗�MIF�׽
            objTLIF_TRNS_SEND.FPALLET_ID = strPALLET_ID                             '��گ�ID
            objTLIF_TRNS_SEND.DELETE_TLIF_TRNS_SEND_PALLET()                        '�폜


            '************************
            '���������MIF�̍폜
            '************************
            Dim objTLIF_TRNS_RECV As New TBL_TLIF_TRNS_RECV(Owner, ObjDb, ObjDbLog) '���������MIF�׽
            objTLIF_TRNS_RECV.FPALLET_ID = strPALLET_ID                             '��گ�ID
            objTLIF_TRNS_RECV.DELETE_TLIF_TRNS_RECV_PALLET()                        '�폜

            '************************
            '�������N��
            '************************
            Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)         '������Ǘ��׽
            objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                                '�N��(������������)


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#Region "  ������������ݾ�(�ڰݔ�����)                                                          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ������������ݾ�(�ڰݔ�����)
    ''' </summary>
    ''' <param name="strPALLET_ID">��گ�ID</param>
    ''' <param name="intTRK_BUF_NO">�ޯ̧��</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Mente_Cancel_TRNS_CRANE(ByVal strPALLET_ID As String, ByVal intTRK_BUF_NO As Integer)
        Try
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����


            '************************
            '���������ޯ̧�̓���
            '************************
            Dim objTPRG_TRK_BUF_RELAY As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)       '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF_RELAY.FTRK_BUF_NO = intTRK_BUF_NO                               '�ޯ̧��
            objTPRG_TRK_BUF_RELAY.FPALLET_ID = strPALLET_ID                                 '��گ�ID
            intRet = objTPRG_TRK_BUF_RELAY.GET_TPRG_TRK_BUF(True)                           '����
            If IsNull(objTPRG_TRK_BUF_RELAY.FRSV_BUF_FM) = True Then
                '(������������ς̏ꍇ)
                strMsg = ERRMSG_DISP_MENTE_CANCEL_BUF_KIND & "[�������J����]" & "[�ޯ̧��:" & TO_STRING(objTPRG_TRK_BUF_RELAY.FTRK_BUF_NO) & "  ,��گ�ID:" & objTPRG_TRK_BUF_RELAY.FPALLET_ID & "]"
                Throw New UserException(strMsg)
            End If


            '************************
            '���ޯ̧�̓���
            '************************
            Dim objTPRG_TRK_BUF_FM As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)  '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF_FM.FTRK_BUF_NO = objTPRG_TRK_BUF_RELAY.FRSV_BUF_FM      '�ޯ̧��
            objTPRG_TRK_BUF_FM.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_FM '�z��
            intRet = objTPRG_TRK_BUF_FM.GET_TPRG_TRK_BUF(True)                      '����


            '************************
            '�������J��
            '************************
            If objTPRG_TRK_BUF_FM.FRSV_PALLET <> objTPRG_TRK_BUF_RELAY.FPALLET_ID Or _
               objTPRG_TRK_BUF_FM.FRES_KIND <> FRES_KIND_SRSV_TRNS_IN Then
                '(������������ς̏ꍇ)
                strMsg = ERRMSG_DISP_MENTE_CANCEL_BUF_KIND & "[�������J����]" & "[�ޯ̧��:" & TO_STRING(objTPRG_TRK_BUF_RELAY.FTRK_BUF_NO) & "  ,��گ�ID:" & objTPRG_TRK_BUF_RELAY.FPALLET_ID & "]"
                Throw New UserException(strMsg)
            End If


            '************************
            '���ޯ̧�̓���
            '************************
            Dim objTPRG_TRK_BUF_TO As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)  '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF_TO.FTRK_BUF_NO = objTPRG_TRK_BUF_RELAY.FRSV_BUF_TO      '�ޯ̧��
            objTPRG_TRK_BUF_TO.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_TO '�z��
            intRet = objTPRG_TRK_BUF_TO.GET_TPRG_TRK_BUF(True)                      '����


            '************************
            '�݌Ɉ������̓���
            '************************
            Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)     '�݌Ɉ������
            objTSTS_HIKIATE.FPALLET_ID = strPALLET_ID                               '��گ�ID
            intRet = objTSTS_HIKIATE.GET_TSTS_HIKIATE_PALLET                        '����
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TSTS_HIKIATE & "[��گ�ID:" & objTSTS_HIKIATE.FPALLET_ID & "]"
                Throw New UserException(strMsg)
            End If


            '************************
            '�����w��QUE�̓���
            '************************
            Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog) '�����w��QUE
            objTPLN_CARRY_QUE.FPALLET_ID = strPALLET_ID                             '��گ�ID
            intRet = objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE(True)                     '����


            '************************
            '�݌Ɉړ�
            '************************
            Dim objSVR_100103 As New SVR_100103(Owner, ObjDb, ObjDbLog) '�݌Ɉړ��׽
            objSVR_100103.OBJTPRG_TRK_BUF_FM = objTPRG_TRK_BUF_RELAY    '�ׯ�ݸ��ޯ̧(���ɒ��ޯ̧)
            objSVR_100103.OBJTPRG_TRK_BUF_TO = objTPRG_TRK_BUF_FM       '�ׯ�ݸ��ޯ̧(�ð����ޯ̧)
            objSVR_100103.FPALLET_ID = strPALLET_ID                     '��گ�ID
            objSVR_100103.FINOUT_STS = FINOUT_STS_SMENTE_CANCEL          'INOUT
            objSVR_100103.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND   '��Ǝ��
            objSVR_100103.INTCLEAR_FM_FLAG = FLAG_ON                    '�������ر�׸�
            objSVR_100103.STOCK_TRNS()                                  '�ړ�


            '************************
            '�ð����ޯ̧�̍X�V
            '************************
            objTPRG_TRK_BUF_FM.FTRNS_FM = objTPRG_TRK_BUF_RELAY.FTRNS_FM
            objTPRG_TRK_BUF_FM.FTRNS_TO = objTPRG_TRK_BUF_RELAY.FTRNS_TO
            objTPRG_TRK_BUF_FM.FRSV_BUF_TO = DEFAULT_INTEGER
            objTPRG_TRK_BUF_FM.FRSV_ARRAY_TO = DEFAULT_INTEGER
            objTPRG_TRK_BUF_FM.FDISP_ADDRESS_TO = objTPRG_TRK_BUF_RELAY.FDISP_ADDRESS_TO
            objTPRG_TRK_BUF_FM.FBUF_IN_DT = Now
            objTPRG_TRK_BUF_FM.UPDATE_TPRG_TRK_BUF()


            '************************
            '�q���ޯ̧�̍X�V
            '************************
            objTPRG_TRK_BUF_TO.CLEAR_TPRG_TRK_BUF()


            '************************
            '�����w��QUE�̍X�V
            '************************
            objTPLN_CARRY_QUE.FCARRYQUE_DIR_STS = FCARRYQUE_DIR_STS_SNON             '�����w����(�����{)
            objTPLN_CARRY_QUE.FUPDATE_DT = Now                                      '���ݓ���
            objTPLN_CARRY_QUE.UPDATE_TPLN_CARRY_QUE()                               '�X�V


            '************************
            '�������䑗�MIF�̍폜
            '************************
            Dim objTLIF_TRNS_SEND As New TBL_TLIF_TRNS_SEND(Owner, ObjDb, ObjDbLog) '�������䑗�MIF�׽
            objTLIF_TRNS_SEND.FPALLET_ID = strPALLET_ID                             '��گ�ID
            objTLIF_TRNS_SEND.DELETE_TLIF_TRNS_SEND_PALLET()                        '�폜


            '************************
            '���������MIF�̍폜
            '************************
            Dim objTLIF_TRNS_RECV As New TBL_TLIF_TRNS_RECV(Owner, ObjDb, ObjDbLog) '���������MIF�׽
            objTLIF_TRNS_RECV.FPALLET_ID = strPALLET_ID                             '��گ�ID
            objTLIF_TRNS_RECV.DELETE_TLIF_TRNS_RECV_PALLET()                        '�폜

            '************************
            '�ري֘A�t���폜
            '************************
            Dim objTPRG_SERIAL As New TBL_TPRG_SERIAL(Owner, ObjDb, ObjDbLog)       '�ري֘A�t���׽
            objTPRG_SERIAL.FPALLET_ID = strPALLET_ID                                '��گ�ID
            objTPRG_SERIAL.DELETE_TPRG_SERIAL()                                     '�폜

            '************************
            '�������N��
            '************************
            Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)         '������Ǘ��׽
            objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                                '�N��(������������)

        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#Region "  �q�ɊԈړ���������ݾ�                                                                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �q�ɊԈړ���������ݾ�
    ''' </summary>
    ''' <param name="strPALLET_ID">��گ�ID</param>
    ''' <param name="intTRK_BUF_NO">�ޯ̧��</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub Mente_Cancel_SOUKO(ByVal strPALLET_ID As String, ByVal intTRK_BUF_NO As Integer)
        Try
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����


            '************************
            '�o�ɒ��ޯ̧�̓���
            '************************
            Dim objTPRG_TRK_BUF_RELAY As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)   '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF_RELAY.FTRK_BUF_NO = intTRK_BUF_NO                           '�ޯ̧��
            objTPRG_TRK_BUF_RELAY.FPALLET_ID = strPALLET_ID                             '��گ�ID
            intRet = objTPRG_TRK_BUF_RELAY.GET_TPRG_TRK_BUF(True)                       '����


            '************************
            '�ð����ޯ̧�̓���
            '************************
            Dim objTPRG_TRK_BUF_ST As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)  '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF_ST.FTRK_BUF_NO = objTPRG_TRK_BUF_RELAY.FRSV_BUF_TO      '�ޯ̧��
            objTPRG_TRK_BUF_ST.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_TO '�z��
            intRet = objTPRG_TRK_BUF_ST.GET_TPRG_TRK_BUF(True)                      '����


            '************************
            '�q���ޯ̧�̓���
            '************************
            Dim objTPRG_TRK_BUF_ASRS As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)  '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO = objTPRG_TRK_BUF_RELAY.FRSV_BUF_FM      '�ޯ̧��
            objTPRG_TRK_BUF_ASRS.FTRK_BUF_ARRAY = objTPRG_TRK_BUF_RELAY.FRSV_ARRAY_FM '�z��
            intRet = objTPRG_TRK_BUF_ASRS.GET_TPRG_TRK_BUF(True)                      '����


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


            '************************
            '�݌Ɉ������̓���
            '************************
            Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)     '�݌Ɉ������
            objTSTS_HIKIATE.FPALLET_ID = objTPRG_TRK_BUF_RELAY.FPALLET_ID           '��گ�ID
            intRet = objTSTS_HIKIATE.GET_TSTS_HIKIATE_PALLET                        '����
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TSTS_HIKIATE & "[��گ�ID:" & objTSTS_HIKIATE.FPALLET_ID & "]"
                Throw New UserException(strMsg)
            End If


            '************************
            '�����w��QUE�̓���
            '************************
            Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog) '�����w��QUE
            objTPLN_CARRY_QUE.FPALLET_ID = objTPRG_TRK_BUF_RELAY.FPALLET_ID         '��گ�ID
            intRet = objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE(True)                     '����


            '************************
            '�݌Ɉړ�
            '************************
            Dim objSVR_100103 As New SVR_100103(Owner, ObjDb, ObjDbLog) '�݌Ɉړ��׽
            objSVR_100103.OBJTPRG_TRK_BUF_FM = objTPRG_TRK_BUF_RELAY    '�ׯ�ݸ��ޯ̧(���ɒ��ޯ̧)
            objSVR_100103.OBJTPRG_TRK_BUF_TO = objTPRG_TRK_BUF_ASRS     '�ׯ�ݸ��ޯ̧(�q���ޯ̧)
            objSVR_100103.FPALLET_ID = objTPRG_TRK_BUF_RELAY.FPALLET_ID '��گ�ID
            objSVR_100103.FINOUT_STS = FINOUT_STS_SMENTE_CANCEL          'INOUT
            objSVR_100103.FSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND   '��Ǝ��
            objSVR_100103.INTCLEAR_FM_FLAG = FLAG_ON                    '�������ر�׸�
            objSVR_100103.STOCK_TRNS()                                  '�ړ�


            '************************
            '�q���ޯ̧�̍X�V
            '************************
            objTPRG_TRK_BUF_ASRS.FRES_KIND = FRES_KIND_SRSV_TRNS_OUT     '���o�\��
            objTPRG_TRK_BUF_ASRS.FTRNS_FM = DEFAULT_STRING              '�����w�ߗpFM
            objTPRG_TRK_BUF_ASRS.FTRNS_TO = DEFAULT_STRING              '�����w�ߗpTO
            objTPRG_TRK_BUF_ASRS.FRSV_BUF_TO = DEFAULT_INTEGER          'TO�����ޯ̧��
            objTPRG_TRK_BUF_ASRS.FRSV_ARRAY_TO = DEFAULT_INTEGER        'TO�����z��
            objTPRG_TRK_BUF_ASRS.FDISP_ADDRESS_TO = DEFAULT_STRING      'TO�\�L�p
            objTPRG_TRK_BUF_ASRS.FBUF_IN_DT = Now                       '�X�V����
            objTPRG_TRK_BUF_ASRS.UPDATE_TPRG_TRK_BUF()                  '�X�V


            '************************
            '�\���ޯ̧�̉��
            '************************
            Dim objTPRG_TRK_BUF_RSV As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog) '�ׯ�ݸ��ޯ̧�׽
            '������������************************************************************************************************************
            'Checked SystemMate:N.Dounoshita 2011/12/20 �޸ޏC��
            objTPRG_TRK_BUF_RSV.FRSV_PALLET = strPALLET_ID                          '��گ�ID
            'objTPRG_TRK_BUF_RSV.FRSV_PALLET = objTPRG_TRK_BUF_RELAY.FPALLET_ID      '��گ�ID
            '������������************************************************************************************************************
            objTPRG_TRK_BUF_RSV.CLEAR_TPRG_TRK_BUF_RSV_PC()                         '���


            '************************
            '�����w��QUE�̍X�V
            '************************
            objTPLN_CARRY_QUE.FCARRYQUE_DIR_STS = FCARRYQUE_DIR_STS_SNON             '�����w����(�����{)
            objTPLN_CARRY_QUE.FUPDATE_DT = Now                                      '���ݓ���
            objTPLN_CARRY_QUE.UPDATE_TPLN_CARRY_QUE()                               '�X�V


            '************************
            '�ري֘A�t���폜
            '************************
            Dim objTPRG_SERIAL As New TBL_TPRG_SERIAL(Owner, ObjDb, ObjDbLog)       '�ري֘A�t���׽
            objTPRG_SERIAL.FPALLET_ID = strPALLET_ID                                '��گ�ID
            objTPRG_SERIAL.DELETE_TPRG_SERIAL()                                     '�폜


            '************************
            '�������䑗�MIF�̍폜
            '************************
            Dim objTLIF_TRNS_SEND As New TBL_TLIF_TRNS_SEND(Owner, ObjDb, ObjDbLog) '�������䑗�MIF�׽
            objTLIF_TRNS_SEND.FPALLET_ID = strPALLET_ID                             '��گ�ID
            objTLIF_TRNS_SEND.DELETE_TLIF_TRNS_SEND_PALLET()                        '�폜


            '************************
            '���������MIF�̍폜
            '************************
            Dim objTLIF_TRNS_RECV As New TBL_TLIF_TRNS_RECV(Owner, ObjDb, ObjDbLog) '���������MIF�׽
            objTLIF_TRNS_RECV.FPALLET_ID = strPALLET_ID                             '��گ�ID
            objTLIF_TRNS_RECV.DELETE_TLIF_TRNS_RECV_PALLET()                        '�폜


            '********************************
            '�q�ɊԈړ���������ݾٓ��ꏈ��
            '********************************
            '' ''Call Mente_Cancel_OUT_Special(strPALLET_ID, objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO)


            '******************************************************************************************************
            '�q�ɊԈړ��I�\�񋭐���ݾ�(�o�ɒI�\��܂Ŗ߂����̂ŁA����ɂ�����i�K�߂�)
            '******************************************************************************************************
            Call Mente_Cancel_SOUKO_RSV(strPALLET_ID, objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO)


            '************************
            '�������N��
            '************************
            Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)         '������Ǘ��׽
            objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                                '�N��(������������)


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#Region "  �q�ɊԈړ��I�\�񋭐���ݾ�                                                            "
    '**********************************************************************************************
    '�y�@�\�z����
    '�y�����z[IN ] strPALLET_ID         :
    '        [IN ] intTRK_BUF_NO        :
    '�y�ߒl�z����
    '**********************************************************************************************
    ''' <summary>
    ''' �q�ɊԈړ��I�\�񋭐���ݾ� 
    ''' </summary>
    ''' <param name="strPALLET_ID">��گ�ID</param>
    ''' <param name="intTRK_BUF_NO">�ޯ̧��</param>
    ''' <remarks></remarks>
    Private Sub Mente_Cancel_SOUKO_RSV(ByVal strPALLET_ID As String, ByVal intTRK_BUF_NO As Integer)
        Try
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����


            '************************
            '�q���ޯ̧�̓���
            '************************
            Dim objTPRG_TRK_BUF_ASRS As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)    '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF_ASRS.FTRK_BUF_NO = intTRK_BUF_NO                            '�ޯ̧��
            objTPRG_TRK_BUF_ASRS.FPALLET_ID = strPALLET_ID                              '��گ�ID
            intRet = objTPRG_TRK_BUF_ASRS.GET_TPRG_TRK_BUF(True)                        '����
            If IsNull(objTPRG_TRK_BUF_ASRS.FTR_TO) = True Then
                '(�����斢�����̏ꍇ)
                strMsg = ERRMSG_DISP_MENTE_CANCEL_BUF_KIND & "[�����斢����]" & "[�ׯ�ݸ�:" & objTPRG_TRK_BUF_ASRS.FDISP_ADDRESS & "]"
                Throw New UserException(strMsg)
            End If


            '************************
            '�݌Ɉ������̓���
            '************************
            Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)     '�݌Ɉ������
            objTSTS_HIKIATE.FPALLET_ID = strPALLET_ID                               '��گ�ID
            intRet = objTSTS_HIKIATE.GET_TSTS_HIKIATE_PALLET                        '����
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TSTS_HIKIATE & "[��گ�ID:" & objTSTS_HIKIATE.FPALLET_ID & "]"
                Throw New UserException(strMsg)
            End If


            '************************
            '�q���ޯ̧�̍X�V
            '************************
            objTPRG_TRK_BUF_ASRS.FRSV_PALLET = DEFAULT_STRING                   '��������گ�ID
            objTPRG_TRK_BUF_ASRS.FRES_KIND = FRES_KIND_SZAIKO                    '�������
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


            '************************
            '�\���ޯ̧�̊J��
            '************************
            Dim objTPRG_TRK_BUF_RSV As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)     '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF_RSV.FRSV_PALLET = objTPRG_TRK_BUF_ASRS.FPALLET_ID           '��������گ�ID
            objTPRG_TRK_BUF_RSV.CLEAR_TPRG_TRK_BUF_RSV_PC()                             '�J��


            '************************
            '�݌ɏ��̍X�V
            '************************
            Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)             '�݌ɏ��ð��ٸ׽
            objTRST_STOCK.FPALLET_ID = strPALLET_ID                                     '��گ�ID
            objTRST_STOCK.GET_TRST_STOCK_KONSAI(False)
            For ii As Integer = LBound(objTRST_STOCK.ARYME) To UBound(objTRST_STOCK.ARYME)
                objTRST_STOCK.ARYME(ii).FTR_RES_VOL = 0         '����������
                objTRST_STOCK.ARYME(ii).FUPDATE_DT = Now        '�X�V����
                objTRST_STOCK.ARYME(ii).UPDATE_TRST_STOCK()     '�X�V
            Next
            objTRST_STOCK.ARYME_CLEAR()


            '************************
            '�����w��QUE�̍폜
            '************************
            Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog)     '�����w��QUE�׽
            objTPLN_CARRY_QUE.FPALLET_ID = strPALLET_ID                               '��گ�ID
            objTPLN_CARRY_QUE.DELETE_TPLN_CARRY_QUE_PALLET()                            '�폜


            '************************
            '�݌Ɉ������̍폜
            '************************
            objTSTS_HIKIATE = New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)  '�݌Ɉ������׽
            objTSTS_HIKIATE.FPALLET_ID = strPALLET_ID
            objTSTS_HIKIATE.DELETE_TSTS_HIKIATE_PALLET()       '�폜


            '************************
            '�������N��
            '************************
            Dim objTPRG_TIMER As New TBL_TPRG_TIMER(Owner, ObjDb, ObjDbLog)         '������Ǘ��׽
            objTPRG_TIMER.KIDOU_ON(FSYORI_ID_S010001)                                '�N��(������������)


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
