'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z�݌ɍ폜�׽
' �y�쐬�zSIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon�g�p�̈�
Imports MateCommon.clsConst                 'Confiģ�ٓǍ��ݓ��W��Ӽޭ�َg�p�̈�
#End Region

Public Class SVR_100102
    Inherits clsTemplateServer

#Region "  �׽���������p�ϐ���`                                                                "
#End Region
#Region "  �����è�ϐ���`                                                                      "
    Private mobjTPRG_TRK_BUF As TBL_TPRG_TRK_BUF    '�ׯ�ݸ��ޯ̧
    Private mFPALLET_ID As String                   '��گ�ID
    Private mFLOT_NO_STOCK As String                '�݌�ۯć�
    Private mFINOUT_STS As Nullable(Of Integer)     'IN/OUT     (���o�Ɏ��їp)
    Private mFSAGYOU_KIND As Nullable(Of Integer)   '��Ǝ��   (���o�Ɏ��їp)
#End Region
#Region "  �����è��`                                                                          "
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
#Region "  �݌ɍ폜                                                                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �݌ɍ폜
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub STOCK_DELETE()
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
                '' ''ElseIf mobjTPRG_TRK_BUF.FRES_KIND <> FRES_KIND_SZAIKO Then
                '' ''    strMsg = ERRMSG_ERR_PROPERTY & "[�ׯ�ݸ��ޯ̧<>�݌�]"
                '' ''    Throw New UserException(strMsg)
            End If


            '*******************************
            '�݌ɏ��̓���(��گ�ID�̂�)
            '*******************************
            Dim objTRST_STOCK_ALL As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog) '�݌ɏ��׽
            objTRST_STOCK_ALL.FPALLET_ID = mFPALLET_ID                          '��گ�ID
            intRet = objTRST_STOCK_ALL.GET_TRST_STOCK_KONSAI(True)              '����


            '************************
            '�\���ޯ̧�̉��
            '************************
            Dim objTPRG_TRK_BUF_RSV As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog) '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF_RSV.FRSV_PALLET = mFPALLET_ID                           '��گ�ID
            objTPRG_TRK_BUF_RSV.CLEAR_TPRG_TRK_BUF_RSV_PC()                         '���


            '************************
            '�ޯ̧�̸ر
            '************************
            If UBound(objTRST_STOCK_ALL.ARYME) = 0 Or IsNull(mFLOT_NO_STOCK) = True Then
                '(�݌ɑS�č폜�̏ꍇ)
                mobjTPRG_TRK_BUF.CLEAR_TPRG_TRK_BUF()
            End If
            objTRST_STOCK_ALL.ARYME_CLEAR()


            '**************************************
            '�݌ɏ��̓���(��گ�ID,�݌�ۯć�)
            '**************************************
            Dim objTRST_STOCK_ONE As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog) '�݌ɏ��׽
            objTRST_STOCK_ONE.FPALLET_ID = mFPALLET_ID                          '��گ�ID
            If IsNull(mFLOT_NO_STOCK) = False Then
                objTRST_STOCK_ONE.FLOT_NO_STOCK = mFLOT_NO_STOCK                '�݌�ۯć�
            End If
            intRet = objTRST_STOCK_ONE.GET_TRST_STOCK_KONSAI(True)              '����


            '************************
            'INOUT���ђǉ�
            '************************
            Dim objTLOG_INOUT As New TBL_TLOG_INOUT(Owner, ObjDb, ObjDbLog)         'INOUT���Ѹ׽
            objTLOG_INOUT.FRESULT_DT = Now                                          '���ѓ���
            objTLOG_INOUT.FBUF_FM = mobjTPRG_TRK_BUF.FTRK_BUF_NO                    '�������ޯ̧��
            objTLOG_INOUT.FARRAY_FM = mobjTPRG_TRK_BUF.FTRK_BUF_ARRAY               '�������z��
            objTLOG_INOUT.FBUF_TO = DEFAULT_INTEGER                                 '�������ޯ̧��
            objTLOG_INOUT.FARRAY_TO = DEFAULT_INTEGER                               '������z��
            objTLOG_INOUT.FINOUT_STS = mFINOUT_STS                                  'IN/OUT
            objTLOG_INOUT.FSAGYOU_KIND = mFSAGYOU_KIND                              '��Ǝ��
            objTLOG_INOUT.FDISP_ADDRESS_FM = mobjTPRG_TRK_BUF.FDISP_ADDRESS         'FM�\�L�p���ڽ
            objTLOG_INOUT.FDISP_ADDRESS_TO = DEFAULT_STRING                         'TO�\�L�p���ڽ
            objTLOG_INOUT.FDISPLOG_ADDRESS_FM = mobjTPRG_TRK_BUF.FDISP_ADDRESS      'FM�\�L�p���ڽ_۸ޗp
            objTLOG_INOUT.FDISPLOG_ADDRESS_TO = DEFAULT_STRING                      'TO�\�L�p���ڽ_۸ޗp
            objTLOG_INOUT.FUSER_ID = FUSER_ID_SKOTEI                                'հ�ްID
            objTLOG_INOUT.OBJTRST_STOCK = objTRST_STOCK_ONE                         '�݌ɏ��
            objTLOG_INOUT.ADD_TLOG_INOUT_ALL()                                      '�ǉ�


            '************************
            '�݌ɂ̍폜
            '************************
            objTRST_STOCK_ONE.FPALLET_ID = objTRST_STOCK_ONE.ARYME(0).FPALLET_ID
            If IsNull(mFLOT_NO_STOCK) = False Then
                objTRST_STOCK_ONE.FLOT_NO_STOCK = objTRST_STOCK_ONE.ARYME(0).FLOT_NO_STOCK
            End If
            objTRST_STOCK_ONE.DELETE_TRST_STOCK_ALL()
            objTRST_STOCK_ONE.ARYME_CLEAR()


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New System.Exception(ex.Message)
        End Try
    End Sub
#End Region
#Region "  �݌ɍ폜   (Public STOCK_DELETE) �Â��ް�ޮ݈ꉞ�ޯ�����"
    ' '' '' ''**********************************************************************************************
    ' '' '' ''�y�@�\�z�݌ɍ폜
    ' '' '' ''�y�����z����
    ' '' '' ''�y�ߒl�z����
    ' '' '' ''**********************************************************************************************
    '' '' ''Public Sub STOCK_DELETE()
    '' '' ''    Try
    '' '' ''        Dim strMsg As String        'ү����
    '' '' ''        Dim intRet As Integer       '�߂�l


    '' '' ''        '************************
    '' '' ''        '�����è����
    '' '' ''        '************************
    '' '' ''        If IsNull(mobjTPRG_TRK_BUF) = True Then
    '' '' ''            strMsg = ERRMSG_ERR_PROPERTY & "[�ׯ�ݸ��ޯ̧]"
    '' '' ''            Throw New UserException(strMsg)
    '' '' ''        ElseIf IsNull(mFPALLET_ID) = True Then
    '' '' ''            strMsg = ERRMSG_ERR_PROPERTY & "[��گ�ID]"
    '' '' ''            Throw New UserException(strMsg)
    '' '' ''        ElseIf IsNull(mFINOUT_STS) = True Then
    '' '' ''            strMsg = ERRMSG_ERR_PROPERTY & "[IN/OUT]"
    '' '' ''            Throw New UserException(strMsg)
    '' '' ''        ElseIf IsNull(mFSAGYOU_KIND) = True Then
    '' '' ''            strMsg = ERRMSG_ERR_PROPERTY & "[��Ǝ��]"
    '' '' ''            Throw New UserException(strMsg)
    '' '' ''            '' ''ElseIf mobjTPRG_TRK_BUF.FRES_KIND <> FRES_KIND_ZAIKO Then
    '' '' ''            '' ''    strMsg = ERRMSG_ERR_PROPERTY & "[�ׯ�ݸ��ޯ̧<>�݌�]"
    '' '' ''            '' ''    Throw New UserException(strMsg)
    '' '' ''        End If


    '' '' ''        '************************
    '' '' ''        '�݌ɏ��̓���
    '' '' ''        '************************
    '' '' ''        Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog) '�݌ɏ��׽
    '' '' ''        objTRST_STOCK.FPALLET_ID = mFPALLET_ID                          '��گ�ID
    '' '' ''        intRet = objTRST_STOCK.GET_TRST_STOCK_KONSAI()                  '����
    '' '' ''        If intRet = RetCode.NotFound Then
    '' '' ''            '(������Ȃ��ꍇ)
    '' '' ''            strMsg = ERRMSG_NOTFOUND_TRST_STOCK & "[��گ�ID:" & objTRST_STOCK.FPALLET_ID & "]"
    '' '' ''            Throw New UserException(strMsg)
    '' '' ''        End If


    '' '' ''        '************************
    '' '' ''        '�ޯ̧�̸ر
    '' '' ''        '************************
    '' '' ''        mobjTPRG_TRK_BUF.CLEAR_TPRG_TRK_BUF()


    '' '' ''        '************************
    '' '' ''        'INOUT���ђǉ�
    '' '' ''        '************************
    '' '' ''        Dim objTLOG_INOUT As New TBL_TLOG_INOUT(Owner, ObjDb, ObjDbLog)         'INOUT���Ѹ׽
    '' '' ''        objTLOG_INOUT.FRESULT_DT = Now                                          '���ѓ���
    '' '' ''        objTLOG_INOUT.FBUF_FM = mobjTPRG_TRK_BUF.FTRK_BUF_NO                    '�������ޯ̧��
    '' '' ''        objTLOG_INOUT.FARRAY_FM = mobjTPRG_TRK_BUF.FTRK_BUF_ARRAY               '�������z��
    '' '' ''        objTLOG_INOUT.FBUF_TO = DEFAULT_INTEGER                                 '�������ޯ̧��
    '' '' ''        objTLOG_INOUT.FARRAY_TO = DEFAULT_INTEGER                               '������z��
    '' '' ''        objTLOG_INOUT.FINOUT_STS = mFINOUT_STS                                  'IN/OUT
    '' '' ''        objTLOG_INOUT.FSAGYOU_KIND = mFSAGYOU_KIND                              '��Ǝ��
    '' '' ''        objTLOG_INOUT.FDISP_ADDRESS_FM = mobjTPRG_TRK_BUF.FDISP_ADDRESS         'FM�\�L�p���ڽ
    '' '' ''        objTLOG_INOUT.FDISP_ADDRESS_TO = DEFAULT_STRING                         'TO�\�L�p���ڽ
    '' '' ''        objTLOG_INOUT.FDISPLOG_ADDRESS_FM = mobjTPRG_TRK_BUF.FDISP_ADDRESS      'FM�\�L�p���ڽ_۸ޗp
    '' '' ''        objTLOG_INOUT.FDISPLOG_ADDRESS_TO = DEFAULT_STRING                      'TO�\�L�p���ڽ_۸ޗp
    '' '' ''        objTLOG_INOUT.FUSER_ID = FUSER_ID_SKOTEI                                    'հ�ްID
    '' '' ''        objTLOG_INOUT.OBJTRST_STOCK = objTRST_STOCK                             '�݌ɏ��
    '' '' ''        objTLOG_INOUT.ADD_TLOG_INOUT_ALL()                                      '�ǉ�


    '' '' ''        Dim ii As Integer
    '' '' ''        For ii = LBound(objTRST_STOCK.ARYME) To UBound(objTRST_STOCK.ARYME)
    '' '' ''            '(ٰ��:���ڍ݌ɐ�)

    '' '' ''            '************************
    '' '' ''            '�݌ɂ̍폜
    '' '' ''            '************************
    '' '' ''            objTRST_STOCK.FPALLET_ID = objTRST_STOCK.ARYME(ii).FPALLET_ID
    '' '' ''            objTRST_STOCK.FLOT_NO_STOCK = objTRST_STOCK.ARYME(ii).FLOT_NO_STOCK
    '' '' ''            objTRST_STOCK.DELETE_TRST_STOCK_ALL()

    '' '' ''        Next


    '' '' ''    Catch ex As UserException
    '' '' ''        Call ComUser(ex, MeSyoriID)
    '' '' ''        Throw ex
    '' '' ''    Catch ex As Exception
    '' '' ''        Call ComError(ex, MeSyoriID)
    '' '' ''        Throw New System.Exception(ex.Message)
    '' '' ''    End Try

    '' '' ''End Sub
#End Region


    '**********************************************************************************************
    '���������ьŗL

    '���������ьŗL
    '**********************************************************************************************

End Class
