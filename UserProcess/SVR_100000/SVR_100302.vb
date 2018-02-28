'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.  
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z�ׯ�ݸލ폜�׽
' �y�쐬�zSIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon�g�p�̈�
Imports MateCommon.clsConst                 'Confiģ�ٓǍ��ݓ��W��Ӽޭ�َg�p�̈�
#End Region

Public Class SVR_100302
    Inherits clsTemplateServer

#Region "  �׽���������p�ϐ���`                                                                "
#End Region
#Region "  �����è�ϐ���`                                                                      "
    Private mFTRK_BUF_NO As Nullable(Of Integer)    '�ׯ�ݸ��ޯ̧��
    Private mFPALLET_ID As String                   '��گ�ID
    Private mFTERM_ID As String                     '�[��ID
    Private mFUSER_ID As String                     'հ�ްID
    Private mFINOUT_STS As Integer = FINOUT_STS_SMENTE_DELETE    'IN/OUT
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
    ''' <summary>�[��ID</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FTERM_ID() As String
        Get
            Return mFTERM_ID
        End Get
        Set(ByVal Value As String)
            mFTERM_ID = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>հ�ްID</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FUSER_ID() As String
        Get
            Return mFUSER_ID
        End Get
        Set(ByVal Value As String)
            mFUSER_ID = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>IN/OUT</summary>
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
#Region "  �ׯ�ݸލ폜                                                                          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ׯ�ݸލ폜
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub MENTE_DELETE()
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


            '������������************************************************************************************************************
            'JobMate:N.Dounoshita 2013/09/03 �\�萔ϲŽ1


            ''*********************************************
            ''�\�萔ϲŽ1
            ''*********************************************
            'Call UpdateYoteiNumMinus1(mFTRK_BUF_NO, mFPALLET_ID)


            'Call Special31()
            '������������************************************************************************************************************


            '************************
            '�ׯ�ݸލ폜
            '************************
            Call DeleteTrkBuf(mFPALLET_ID, mFTRK_BUF_NO)


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw ex
        End Try
    End Sub
#End Region
#Region "  �ׯ�ݸ�,�݌ɏ��,���̑���گĂɊ֌W������S�č폜                                   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ׯ�ݸ�,�݌ɏ��,���̑���گĂɊ֌W������S�č폜
    ''' </summary>
    ''' <param name="strPALLET_ID">��گ�ID</param>
    ''' <param name="intTRK_BUF_NO">�ޯ̧��</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub DeleteTrkBuf(ByVal strPALLET_ID As String, ByVal intTRK_BUF_NO As Integer)

        Try
            Dim intRet As RetCode                   '�߂�l
            'Dim strMsg As String                    'ү����

            '************************
            '�݌��ޯ̧�̓���
            '************************
            Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)     '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF.FTRK_BUF_NO = intTRK_BUF_NO                             '�ޯ̧��
            objTPRG_TRK_BUF.FPALLET_ID = strPALLET_ID                               '��گ�ID
            intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF(True)                         '����


            '************************
            '�݌Ɉ������̓���
            '************************
            Dim intSAGYOU_KIND As Integer       '��Ǝ��
            Dim objTSTS_HIKIATE As New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)     '�݌Ɉ������
            objTSTS_HIKIATE.FPALLET_ID = strPALLET_ID                               '��گ�ID
            intRet = objTSTS_HIKIATE.GET_TSTS_HIKIATE_PALLET                        '����
            If intRet = RetCode.OK Then
                intSAGYOU_KIND = objTSTS_HIKIATE.FSAGYOU_KIND                       '��Ǝ��

                '������������************************************************************************************************************
                'SystemMate:N.Dounoshita 2012/04/25  ���ڂ̍폜�ɑΉ�

                ''************************
                ''�݌Ɉ������̍폜
                ''************************
                'objTSTS_HIKIATE = New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)  '�݌Ɉ������׽
                'objTSTS_HIKIATE.FPALLET_ID = strPALLET_ID
                'objTSTS_HIKIATE.DELETE_TSTS_HIKIATE_PALLET()       '�폜

                '������������************************************************************************************************************

            Else
                '(������Ȃ��ꍇ)

                intSAGYOU_KIND = FSAGYOU_KIND_SSYSTEM_MENTE_NON                 '��Ǝ��

            End If


            '************************
            '�݌ɏ��̎擾
            '************************
            Dim objTRST_STOCK_BASE As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)        '�݌ɏ��׽
            objTRST_STOCK_BASE.FPALLET_ID = mFPALLET_ID                                 '��گ�ID
            objTRST_STOCK_BASE.GET_TRST_STOCK_KONSAI(False)


            '**************************************
            '�ۊǏo�[�L�^�ǉ�
            '**************************************
            Call Add_TBL_TEVD_SUITOU(objTPRG_TRK_BUF.FTRK_BUF_NO _
                                   , DEFAULT_INTEGER _
                                   , intSAGYOU_KIND _
                                   , mFTERM_ID _
                                   , mFUSER_ID _
                                   , DEFAULT_STRING _
                                   , DEFAULT_STRING _
                                   , objTRST_STOCK_BASE _
                                    )


            '************************
            '�݌ɍ폜
            '************************
            '������������************************************************************************************************************
            'SystemMate:N.Dounoshita 2012/04/25  ���ڂ̍폜�ɑΉ�

            For Each objTRST_STOCK As TBL_TRST_STOCK In objTRST_STOCK_BASE.ARYME
                Dim objSVR_100102 As New SVR_100102(Owner, ObjDb, ObjDbLog) '�݌ɍ폜�׽
                objSVR_100102.OBJTPRG_TRK_BUF = objTPRG_TRK_BUF             '�ׯ�ݸ��ޯ̧
                objSVR_100102.FPALLET_ID = strPALLET_ID                     '��گ�ID
                objSVR_100102.FLOT_NO_STOCK = objTRST_STOCK.FLOT_NO_STOCK   '�݌�ۯć�
                objSVR_100102.FINOUT_STS = mFINOUT_STS                      'INOUT(����ݽ�o�^)
                objSVR_100102.FSAGYOU_KIND = intSAGYOU_KIND                 '��Ǝ��
                objSVR_100102.STOCK_DELETE()                                '�폜
            Next


            '************************
            '�݌Ɉ������̍폜
            '************************
            objTSTS_HIKIATE = New TBL_TSTS_HIKIATE(Owner, ObjDb, ObjDbLog)  '�݌Ɉ������׽
            objTSTS_HIKIATE.FPALLET_ID = strPALLET_ID
            objTSTS_HIKIATE.DELETE_TSTS_HIKIATE_PALLET()       '�폜


            'Dim objSVR_100102 As New SVR_100102(Owner, ObjDb, ObjDbLog) '�݌ɍ폜�׽
            'objSVR_100102.OBJTPRG_TRK_BUF = objTPRG_TRK_BUF             '�ׯ�ݸ��ޯ̧
            'objSVR_100102.FPALLET_ID = strPALLET_ID                     '��گ�ID
            'objSVR_100102.FINOUT_STS = mFINOUT_STS                      'INOUT(����ݽ�o�^)
            'objSVR_100102.FSAGYOU_KIND = intSAGYOU_KIND                 '��Ǝ��
            'objSVR_100102.STOCK_DELETE()                                '�폜

            '������������************************************************************************************************************


            '**************************************
            '�z����
            '**************************************
            objTRST_STOCK_BASE.ARYME_CLEAR()


            '************************
            '�\���ޯ̧�̉��
            '************************
            Dim objTPRG_TRK_BUF_RSV As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog) '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF_RSV.FRSV_PALLET = strPALLET_ID                          '��گ�ID
            objTPRG_TRK_BUF_RSV.CLEAR_TPRG_TRK_BUF_RSV_PC()                         '���


            '************************
            '�����w��QUE�̍폜
            '************************
            Dim objTPLN_CARRY_QUE As New TBL_TPLN_CARRY_QUE(Owner, ObjDb, ObjDbLog) '�����w��QUE
            objTPLN_CARRY_QUE.FPALLET_ID = strPALLET_ID                             '��گ�ID
            intRet = objTPLN_CARRY_QUE.GET_TPLN_CARRY_QUE(False)                    '����
            If intRet = RetCode.OK Then
                '(���������ꍇ)
                objTPLN_CARRY_QUE.DELETE_TPLN_CARRY_QUE()   '�폜
            End If


            '************************
            '�������䑗�MIF�̍폜
            '************************
            Dim objTLIF_TRNS_SEND As New TBL_TLIF_TRNS_SEND(Owner, ObjDb, ObjDbLog) '�������䑗�MIF�׽
            objTLIF_TRNS_SEND.FPALLET_ID = strPALLET_ID                             '��گ�ID
            objTLIF_TRNS_SEND.DELETE_TLIF_TRNS_SEND_PALLET()                        '�폜


            '************************
            '�ري֘A�t���폜
            '************************
            Dim objTPRG_SERIAL As New TBL_TPRG_SERIAL(Owner, ObjDb, ObjDbLog)       '�ري֘A�t���׽
            objTPRG_SERIAL.FPALLET_ID = strPALLET_ID                                '��گ�ID
            objTPRG_SERIAL.DELETE_TPRG_SERIAL()                                     '�폜



            '************************
            '���������MIF�̍폜
            '************************
            Dim objTLIF_TRNS_RECV As New TBL_TLIF_TRNS_RECV(Owner, ObjDb, ObjDbLog) '���������MIF�׽
            objTLIF_TRNS_RECV.FPALLET_ID = strPALLET_ID                             '��گ�ID
            objTLIF_TRNS_RECV.DELETE_TLIF_TRNS_RECV_PALLET()                        '�폜


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
