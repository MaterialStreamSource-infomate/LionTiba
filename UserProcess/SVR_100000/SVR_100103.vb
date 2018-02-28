'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z�݌Ɉړ��׽
' �y�쐬�zSIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon�g�p�̈�
Imports MateCommon.clsConst                 'Confiģ�ٓǍ��ݓ��W��Ӽޭ�َg�p�̈�
#End Region

Public Class SVR_100103
    Inherits clsTemplateServer

#Region "  �׽���������p�ϐ���`                                                                "
#End Region
#Region "  �����è�ϐ���`                                                                      "
    Private mobjTPRG_TRK_BUF_FM As TBL_TPRG_TRK_BUF     '���ׯ�ݸ��ޯ̧
    Private mobjTPRG_TRK_BUF_TO As TBL_TPRG_TRK_BUF     '���ׯ�ݸ��ޯ̧
    Private mFPALLET_ID As String                       '��گ�ID
    Private mFINOUT_STS As Nullable(Of Integer)         'IN/OUT     (���o�Ɏ��їp)
    Private mFSAGYOU_KIND As Nullable(Of Integer)       '��Ǝ��   (���o�Ɏ��їp)
    Private mINTCLEAR_FM_FLAG As Nullable(Of Integer)   '�ړ����ر�׸�
#End Region
#Region "  �����è��`                                                                          "
    ''' =======================================
    ''' <summary>���ׯ�ݸ��ޯ̧</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property OBJTPRG_TRK_BUF_FM() As TBL_TPRG_TRK_BUF
        Get
            Return mobjTPRG_TRK_BUF_FM
        End Get
        Set(ByVal Value As TBL_TPRG_TRK_BUF)
            mobjTPRG_TRK_BUF_FM = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>���ׯ�ݸ��ޯ̧</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property OBJTPRG_TRK_BUF_TO() As TBL_TPRG_TRK_BUF
        Get
            Return mobjTPRG_TRK_BUF_TO
        End Get
        Set(ByVal Value As TBL_TPRG_TRK_BUF)
            mobjTPRG_TRK_BUF_TO = Value
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
    ''' <summary>IN/OUT     (���o�Ɏ��їp)</summary>
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
    ''' =======================================
    ''' <summary>��Ǝ��   (���o�Ɏ��їp)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FSAGYOU_KIND() As Nullable(Of Integer)
        Get
            Return mFSAGYOU_KIND
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFSAGYOU_KIND = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>�ړ����ر�׸�</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property INTCLEAR_FM_FLAG() As Nullable(Of Integer)
        Get
            Return mINTCLEAR_FM_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mINTCLEAR_FM_FLAG = Value
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
#Region "  �݌Ɉړ�                                                                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �݌Ɉړ�
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub STOCK_TRNS()
        Try
            Dim strMsg As String        'ү����
            Dim intRet As Integer       '�߂�l


            '************************
            '�����è����
            '************************
            If IsNull(mobjTPRG_TRK_BUF_FM) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[���ׯ�ݸ��ޯ̧]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mobjTPRG_TRK_BUF_TO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[���ׯ�ݸ��ޯ̧]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFPALLET_ID) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[��گ�ID]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFINOUT_STS) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[IN/OUT]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFSAGYOU_KIND) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[��Ǝ��]"
                Throw New UserException(strMsg)
            ElseIf (TO_INTEGER(mobjTPRG_TRK_BUF_FM.FRES_KIND) <> FRES_KIND_SZAIKO) And _
                   (TO_INTEGER(mobjTPRG_TRK_BUF_FM.FRES_KIND) <> FRES_KIND_SRSV_TRNS_OUT) Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�ׯ�ݸ��ޯ̧<>�݌�/�����\��]"
                Throw New UserException(strMsg)
            End If


            '************************
            '�݌ɏ��̓���
            '************************
            Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog) '�݌ɏ��׽
            objTRST_STOCK.FPALLET_ID = mFPALLET_ID                          '��گ�ID
            intRet = objTRST_STOCK.GET_TRST_STOCK_KONSAI(True)              '����


            '************************
            '���ׯ�ݸ��ޯ̧�̍X�V
            '************************
            mobjTPRG_TRK_BUF_TO.FRES_KIND = FRES_KIND_SZAIKO                '�݌Ɉ������(�݌�)
            mobjTPRG_TRK_BUF_TO.FPALLET_ID = mFPALLET_ID                    '��گ�ID
            mobjTPRG_TRK_BUF_TO.FBUF_IN_DT = Now                            '�ޯ̧������
            mobjTPRG_TRK_BUF_TO.UPDATE_TPRG_TRK_BUF()                       '�X�V


            '************************
            'INOUT���ђǉ�
            '************************
            Dim objTLOG_INOUT As New TBL_TLOG_INOUT(Owner, ObjDb, ObjDbLog)         'INOUT���Ѹ׽
            objTLOG_INOUT.FRESULT_DT = Now                                          '���ѓ���
            objTLOG_INOUT.FBUF_FM = mobjTPRG_TRK_BUF_FM.FTRK_BUF_NO                 '�������ޯ̧��
            objTLOG_INOUT.FARRAY_FM = mobjTPRG_TRK_BUF_FM.FTRK_BUF_ARRAY            '�������z��
            objTLOG_INOUT.FBUF_TO = mobjTPRG_TRK_BUF_TO.FTRK_BUF_NO                 '�������ޯ̧��
            objTLOG_INOUT.FARRAY_TO = mobjTPRG_TRK_BUF_TO.FTRK_BUF_ARRAY            '������z��
            objTLOG_INOUT.FINOUT_STS = mFINOUT_STS                                  'IN/OUT
            objTLOG_INOUT.FSAGYOU_KIND = mFSAGYOU_KIND                              '��Ǝ��
            objTLOG_INOUT.FDISP_ADDRESS_FM = mobjTPRG_TRK_BUF_FM.FDISP_ADDRESS      'FM�\�L�p���ڽ
            objTLOG_INOUT.FDISP_ADDRESS_TO = mobjTPRG_TRK_BUF_TO.FDISP_ADDRESS      'TO�\�L�p���ڽ
            If IsNull(mobjTPRG_TRK_BUF_FM.FDISPLOG_ADDRESS_FM) = True Then
                '(FM�\�L�p���ڽ_۸ޗp����Ă���Ă��Ȃ��ꍇ)
                objTLOG_INOUT.FDISPLOG_ADDRESS_FM = objTLOG_INOUT.FDISP_ADDRESS_FM              'FM�\�L�p���ڽ_۸ޗp
            Else
                '(FM�\�L�p���ڽ_۸ޗp����Ă���Ă���ꍇ)
                objTLOG_INOUT.FDISPLOG_ADDRESS_FM = mobjTPRG_TRK_BUF_FM.FDISPLOG_ADDRESS_FM     'FM�\�L�p���ڽ_۸ޗp
            End If
            objTLOG_INOUT.FDISPLOG_ADDRESS_TO = mobjTPRG_TRK_BUF_TO.FDISP_ADDRESS   'TO�\�L�p���ڽ_۸ޗp
            objTLOG_INOUT.FUSER_ID = FUSER_ID_SKOTEI                                'հ�ްID
            objTLOG_INOUT.OBJTRST_STOCK = objTRST_STOCK                             '�݌ɏ��
            objTLOG_INOUT.ADD_TLOG_INOUT_ALL()                                      '�ǉ�


            '**************************************
            '��ʗp���o�Ɏ��т̏o�ֽ͐ؑð���擾
            '**************************************
            Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog) '���ѕϐ�
            Dim strSINOUTTemp As String                                         '��ʗp���o�Ɏ��т̏o�ֽ͐ؑð��������
            Dim strSINOUT() As String                                           '��ʗp���o�Ɏ��т̏o�ֽ͐ؑð���z��
            strSINOUTTemp = objTPRG_SYS_HEN.SS000000_010
            strSINOUT = Split(strSINOUTTemp, KUGIRI01)


            '**********************************
            '��ʗp���o�Ɏ��т̏o�͔��f
            '**********************************
            Dim blnExist As Boolean = False     '��ʗp���o�Ɏ��т̏o���׸�
            For ii As Integer = LBound(strSINOUT) To UBound(strSINOUT)
                '(�ݒ肳�ꂽ�ð����)
                If strSINOUT(ii) = mFINOUT_STS Then
                    blnExist = True
                    Exit For
                End If
            Next


            '************************
            '�\�L�p���ڽ_۸ޗp�̍X�V
            '************************
            mobjTPRG_TRK_BUF_TO.FDISPLOG_ADDRESS_TO = mobjTPRG_TRK_BUF_TO.FDISP_ADDRESS             'TO�\�L�p���ڽ_۸ޗp
            If blnExist = True Then
                '(��ʗp���o�Ɏ��т̏o�͂��s���ꍇ)
                mobjTPRG_TRK_BUF_TO.FDISPLOG_ADDRESS_FM = mobjTPRG_TRK_BUF_TO.FDISP_ADDRESS         'FM�\�L�p���ڽ_۸ޗp
            Else
                '(��ʗp���o�Ɏ��т̏o�͂��s��Ȃ��ꍇ)
                If IsNull(mobjTPRG_TRK_BUF_TO.FDISPLOG_ADDRESS_FM) = True Then
                    '(�ݒ肳��Ă��Ȃ��ꍇ)
                    mobjTPRG_TRK_BUF_TO.FDISPLOG_ADDRESS_FM = mobjTPRG_TRK_BUF_FM.FDISP_ADDRESS     'TO�\�L�p���ڽ_۸ޗp
                End If
            End If


            '************************
            '���ׯ�ݸ��ޯ̧�̸ر
            '************************
            If TO_INTEGER(mINTCLEAR_FM_FLAG) = FLAG_ON Then
                '(�������ر�׸ނ�ON�̏ꍇ)
                mobjTPRG_TRK_BUF_FM.CLEAR_TPRG_TRK_BUF()
            Else
                '(�������ر�׸ނ�OFF�̏ꍇ)
                mobjTPRG_TRK_BUF_FM.FRES_KIND = FRES_KIND_SAKI
                mobjTPRG_TRK_BUF_FM.FPALLET_ID = DEFAULT_STRING
                mobjTPRG_TRK_BUF_FM.FBUF_IN_DT = Now
                mobjTPRG_TRK_BUF_FM.UPDATE_TPRG_TRK_BUF()
            End If


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New System.Exception(ex.Message)
        End Try
    End Sub
#End Region

    '**********************************************************************************************
    '���������ьŗL

    '���������ьŗL
    '**********************************************************************************************

End Class
