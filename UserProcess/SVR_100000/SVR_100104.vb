'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z�݌ɍX�V�׽
' �y�쐬�zSIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon�g�p�̈�
Imports MateCommon.clsConst                 'Confiģ�ٓǍ��ݓ��W��Ӽޭ�َg�p�̈�
#End Region

Public Class SVR_100104
    Inherits clsTemplateServer

#Region "  �׽���������p�ϐ���`                                                                "
#End Region
#Region "  �����è�ϐ���`                                                                      "
    Private mobjTPRG_TRK_BUF As TBL_TPRG_TRK_BUF    '�ׯ�ݸ��ޯ̧ð��ٸ׽
    Private mobjTRST_STOCK As TBL_TRST_STOCK        '�݌ɏ��ð��ٸ׽
    Private mFINOUT_STS As Nullable(Of Integer)     'IN/OUT     (���o�Ɏ��їp)
    Private mFSAGYOU_KIND As Nullable(Of Integer)   '��Ǝ��   (���o�Ɏ��їp)
#End Region
#Region "  �����è��`                                                                          "
    ''' =======================================
    ''' <summary>�ׯ�ݸ��ޯ̧ð��ٸ׽</summary>
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
    ''' <summary>�݌ɏ��ð��ٸ׽</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property OBJTRST_STOCK() As TBL_TRST_STOCK
        Get
            Return mobjTRST_STOCK
        End Get
        Set(ByVal Value As TBL_TRST_STOCK)
            mobjTRST_STOCK = Value
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
#Region "  �݌ɍX�V                                                                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �݌ɍX�V
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub STOCK_UPDATE()
        Try
            Dim strMsg As String        'ү����


            '************************
            '�����è����
            '************************
            If IsNull(mobjTPRG_TRK_BUF) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�ׯ�ݸ��ޯ̧]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mobjTRST_STOCK) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�݌ɏ��]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFINOUT_STS) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[IN/OUT]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFSAGYOU_KIND) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[��Ǝ��]"
                Throw New UserException(strMsg)
            End If


            '************************
            'INOUT���ђǉ�
            '************************
            Dim objTLOG_INOUT As New TBL_TLOG_INOUT(Owner, ObjDb, ObjDbLog)         'INOUT���Ѹ׽
            objTLOG_INOUT.FRESULT_DT = Now                                          '���ѓ���
            objTLOG_INOUT.FBUF_FM = mobjTPRG_TRK_BUF.FTRK_BUF_NO                    '�������ޯ̧��
            objTLOG_INOUT.FARRAY_FM = mobjTPRG_TRK_BUF.FTRK_BUF_ARRAY               '�������z��
            objTLOG_INOUT.FBUF_TO = mobjTPRG_TRK_BUF.FTRK_BUF_NO                    '�������ޯ̧��
            objTLOG_INOUT.FARRAY_TO = mobjTPRG_TRK_BUF.FTRK_BUF_ARRAY               '������z��
            objTLOG_INOUT.FINOUT_STS = mFINOUT_STS                                  'IN/OUT
            objTLOG_INOUT.FSAGYOU_KIND = mFSAGYOU_KIND                              '��Ǝ��
            objTLOG_INOUT.FDISP_ADDRESS_FM = mobjTPRG_TRK_BUF.FDISP_ADDRESS         'FM�\�L�p���ڽ
            objTLOG_INOUT.FDISP_ADDRESS_TO = mobjTPRG_TRK_BUF.FDISP_ADDRESS         'TO�\�L�p���ڽ
            objTLOG_INOUT.FUSER_ID = FUSER_ID_SKOTEI                                'հ�ްID
            objTLOG_INOUT.OBJTRST_STOCK = mobjTRST_STOCK                            '�݌ɏ��
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
