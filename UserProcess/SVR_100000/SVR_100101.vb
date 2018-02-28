'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z�݌ɍ쐬�׽
' �y�쐬�zKSH
'**********************************************************************************************

#Region "  Imports"
Imports JobCommon
Imports MateCommon                          'MateCommon�g�p�̈�
Imports MateCommon.clsConst                 'Confiģ�ٓǍ��ݓ��W��Ӽޭ�َg�p�̈�
#End Region

Public Class SVR_100101
    Inherits clsTemplateServer

#Region "  �׽���������p�ϐ���`"
#End Region
#Region "  �����è�ϐ���`"
    Private mobjTPRG_TRK_BUF As TBL_TPRG_TRK_BUF    '�ׯ�ݸ��ޯ̧
    Private mFPALLET_ID As String                   '��گ�ID
    Private mFLOT_NO_STOCK As String                '�݌�ۯć�
    Private mFINOUT_STS As Nullable(Of Integer)     'IN/OUT     (���o�Ɏ��їp)
    Private mFSAGYOU_KIND As Nullable(Of Integer)   '��Ǝ��   (���o�Ɏ��їp)
#End Region
#Region "  �����è��`"
    ''' =======================================
    ''' <summary>�ׯ�ݸ��ޯ̧</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property OBJTPRG_TRK_BUF() As TBL_TPRG_TRK_BUF
        Get
            Return mobjTPRG_TRK_BUF
        End Get
        Set(ByVal Value As TBL_TPRG_TRK_BUF)
            mobjTPRG_TRK_BUF = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>�݌�ۯć�</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FLOT_NO_STOCK() As String
        Get
            Return mFLOT_NO_STOCK
        End Get
        Set(ByVal Value As String)
            mFLOT_NO_STOCK = Value
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
#End Region
#Region "  �ݽ�׸�"
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
#Region "  �݌ɍ쐬"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �݌ɍ쐬
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub STOCK_ADD()
        Try
            Dim strMsg As String        'ү����
            Dim intRet As Integer       '�߂�l


            '************************
            '�����è����
            '************************
            If IsNull(mobjTPRG_TRK_BUF) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�ׯ�ݸ��ޯ̧]"
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
            ElseIf TO_INTEGER(mobjTPRG_TRK_BUF.FRES_KIND) <> FRES_KIND_SAKI And TO_INTEGER(mobjTPRG_TRK_BUF.FRES_KIND) <> FRES_KIND_SZAIKO Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�ׯ�ݸ��ޯ̧<>��I AND �ׯ�ݸ��ޯ̧<>�݌ɒI]"
                Throw New UserException(strMsg)
            End If


            '************************
            '�݌ɏ��̓���
            '************************
            Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog) '�݌ɏ��׽
            objTRST_STOCK.FPALLET_ID = mFPALLET_ID                          '��گ�ID
            objTRST_STOCK.FLOT_NO_STOCK = mFLOT_NO_STOCK                    '�݌�ۯć�
            intRet = objTRST_STOCK.GET_TRST_STOCK_KONSAI(True)              '����
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TRST_STOCK & "[��گ�ID:" & objTRST_STOCK.FPALLET_ID & "]"
                Throw New UserException(strMsg)
            End If

            '************************
            '�ׯ�ݸ��ޯ̧�X�V
            '************************
            If TO_INTEGER(mobjTPRG_TRK_BUF.FRES_KIND) = FRES_KIND_SAKI Then
                '(��I�̏ꍇ)
                mobjTPRG_TRK_BUF.FRES_KIND = FRES_KIND_SZAIKO                '�݌Ɉ������  
                mobjTPRG_TRK_BUF.FPALLET_ID = mFPALLET_ID                   '��گ�ID
                mobjTPRG_TRK_BUF.FBUF_IN_DT = Now                           '�ޯ̧������
                mobjTPRG_TRK_BUF.UPDATE_TPRG_TRK_BUF()                      '�X�V
            End If



            '************************
            'INOUT���ђǉ�
            '************************
            Dim objTLOG_INOUT As New TBL_TLOG_INOUT(Owner, ObjDb, ObjDbLog)         'INOUT���Ѹ׽
            objTLOG_INOUT.FRESULT_DT = Now                                          '���ѓ���
            objTLOG_INOUT.FBUF_FM = DEFAULT_INTEGER                                 '�������ޯ̧��
            objTLOG_INOUT.FARRAY_FM = DEFAULT_INTEGER                               '�������z��
            objTLOG_INOUT.FBUF_TO = mobjTPRG_TRK_BUF.FTRK_BUF_NO                    '�������ޯ̧��
            objTLOG_INOUT.FARRAY_TO = mobjTPRG_TRK_BUF.FTRK_BUF_ARRAY               '������z��
            objTLOG_INOUT.FINOUT_STS = mFINOUT_STS                                  'IN/OUT
            objTLOG_INOUT.FSAGYOU_KIND = mFSAGYOU_KIND                              '��Ǝ��
            objTLOG_INOUT.FDISP_ADDRESS_FM = DEFAULT_STRING                         'FM�\�L�p���ڽ
            objTLOG_INOUT.FDISP_ADDRESS_TO = mobjTPRG_TRK_BUF.FDISP_ADDRESS         'TO�\�L�p���ڽ
            objTLOG_INOUT.FDISPLOG_ADDRESS_FM = DEFAULT_STRING                      'FM�\�L�p���ڽ_۸ޗp
            objTLOG_INOUT.FDISPLOG_ADDRESS_TO = mobjTPRG_TRK_BUF.FDISP_ADDRESS      'TO�\�L�p���ڽ_۸ޗp
            objTLOG_INOUT.FUSER_ID = FUSER_ID_SKOTEI                                'հ�ްID
            objTLOG_INOUT.OBJTRST_STOCK = objTRST_STOCK                             '�݌ɏ��
            objTLOG_INOUT.ADD_TLOG_INOUT_ALL()                                      '�ǉ�


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
