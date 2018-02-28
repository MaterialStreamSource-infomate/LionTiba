'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z��I�����ĸ׽
' �y�쐬�zSIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon�g�p�̈�
Imports MateCommon.clsConst                 'Confiģ�ٓǍ��ݓ��W��Ӽޭ�َg�p�̈�
#End Region

Public Class SVR_100201
    Inherits clsTemplateServer

#Region "  �׽���������p�ϐ���`                                                                "
#End Region
#Region "  �����è�ϐ���`                                                                      "
    Private mFTRK_BUF_NO As Nullable(Of Integer)      '�ׯ�ݸ��ޯ̧No
    Private mFTRK_BUF_ARRAY As Nullable(Of Integer)   '�ׯ�ݸ��ޯ̧�z��No
    Private mFRAC_FORM As Nullable(Of Integer)        '�I�`����
    Private mFEQ_ID_CRANE As String()                 '���ڰݐݔ�ID
    Private mFPALLET_ID As String                     '��گ�ID
    Private mblnUpdate As Boolean                     '�X�V�׸�
    '������������************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/04/18  ��I��������
    Private mFRES_TYPE As String                      '��������
    '������������************************************************************************************************************

    '������������************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/10/19  ��I�����ɁA���ޱ�̐ؗ����������ɒǉ��B�ؗ�������Ă�����A��I�����̑ΏۂƂ��Ȃ��B
    Private mFBUF_FM As Nullable(Of Integer)           '�������ׯ�ݸ��ޯ̧��
    '������������************************************************************************************************************

    '������������************************************************************************************************************
    'JobMate:N.Dounoshita 2013/04/03 ������ި��� and �߱�����̋�I�����ɑΉ�
    Private mblnPair As Boolean                             '�߱�����׸�
    Private mXTANA_BLOCK As Nullable(Of Integer)            '�I��ۯ�
    Private mFTRK_BUF_ARRAY_Pair As Nullable(Of Integer)    '�ׯ�ݸ��ޯ̧�z��No(�߱����)
    '������������************************************************************************************************************

#End Region
#Region "  �����è��`                                                                          "
    ''' =======================================
    ''' <summary>�ׯ�ݸ��ޯ̧No</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FTRK_BUF_NO() As Nullable(Of Integer)
        Get
            Return mFTRK_BUF_NO
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFTRK_BUF_NO = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>�ׯ�ݸ��ޯ̧�z��No</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FTRK_BUF_ARRAY() As Nullable(Of Integer)
        Get
            Return mFTRK_BUF_ARRAY
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFTRK_BUF_ARRAY = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>�I�`����</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FRAC_FORM() As Nullable(Of Integer)
        Get
            Return mFRAC_FORM
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRAC_FORM = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>���ڰݐݔ�ID</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FEQ_ID_CRANE() As String()
        Get
            Return mFEQ_ID_CRANE
        End Get
        Set(ByVal Value As String())
            mFEQ_ID_CRANE = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>�X�V�׸�</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property blnUpdate() As Boolean
        Get
            Return mblnUpdate
        End Get
        Set(ByVal Value As Boolean)
            mblnUpdate = Value
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

    '������������************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/04/18  ��I��������
    ''' =======================================
    ''' <summary>��گ�ID</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FRES_TYPE() As String
        Get
            Return mFRES_TYPE
        End Get
        Set(ByVal Value As String)
            mFRES_TYPE = Value
        End Set
    End Property
    '������������************************************************************************************************************

    '������������************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/10/19  ��I�����ɁA���ޱ�̐ؗ����������ɒǉ��B�ؗ�������Ă�����A��I�����̑ΏۂƂ��Ȃ��B
    ''' =======================================
    ''' <summary>�������ׯ�ݸ��ޯ̧��</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FBUF_FM() As Nullable(Of Integer)
        Get
            Return mFBUF_FM
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFBUF_FM = Value
        End Set
    End Property
    '������������************************************************************************************************************

    '������������************************************************************************************************************
    'JobMate:N.Dounoshita 2013/04/03 ������ި��� and �߱�����̋�I�����ɑΉ�
    ''' =======================================
    ''' <summary>�߱�����׸�</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property blnPair() As Boolean
        Get
            Return mblnPair
        End Get
        Set(ByVal Value As Boolean)
            mblnPair = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>�ׯ�ݸ��ޯ̧�z��No(�߱����)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FTRK_BUF_ARRAY_Pair() As Nullable(Of Integer)
        Get
            Return mFTRK_BUF_ARRAY_Pair
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFTRK_BUF_ARRAY_Pair = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>�I��ۯ�</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property XTANA_BLOCK() As Nullable(Of Integer)
        Get
            Return mXTANA_BLOCK
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXTANA_BLOCK = Value
        End Set
    End Property
    '������������************************************************************************************************************

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
        mblnUpdate = True
    End Sub
#End Region
#Region "  ��I������                                                                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��I������
    ''' </summary>
    ''' <returns>RetCode</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function FIND_TANA_AKI() As RetCode
        Try
            Dim strMsg As String                    'ү����
            Dim intRet As RetCode                   '�߂�l
            Dim blnFIND As Boolean = False          '��������


            '************************
            '�����è����
            '************************
            If IsNull(mFTRK_BUF_NO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�ׯ�ݸ��ޯ̧No]"
                Throw New UserException(strMsg)
            End If

            '************************
            '�ڰݗD�揇�g�p�L���̊m�F
            '************************
            Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)             '���ѕϐ��׽
            objTPRG_SYS_HEN.FHENSU_ID = FHENSU_ID_SSS000000_003                             '�ϐ�ID
            intRet = objTPRG_SYS_HEN.GET_TPRG_SYS_HEN(True)                                 '�擾


            If TO_INTEGER(objTPRG_SYS_HEN.FHENSU_INT) = FLAG_ON Then
                '(�ڰݗD�揇�ϐ��g�p�̏ꍇ)

                '************************
                '�I�`���ʗD�揇Ͻ��̎擾
                '************************
                Dim objTMST_RAC_BUNRUI_PR As New TBL_TMST_RAC_BUNRUI_PR(Owner, ObjDb, ObjDbLog)         '�I���ޗD�揇Ͻ�
                objTMST_RAC_BUNRUI_PR.FRES_TYPE = mFRES_TYPE                '��������
                objTMST_RAC_BUNRUI_PR.ORDER_BY = "FRAC_PRIORITY"            '����
                intRet = objTMST_RAC_BUNRUI_PR.GET_TMST_RAC_BUNRUI_PR_ANY() '�擾
                If intRet = RetCode.NotFound Then
                    '(������Ȃ��ꍇ)
                    strMsg = ERRMSG_NOTFOUND_TMST_RACBUNRUI_PRIORITY & "[��������:" & mFRES_TYPE & "]"
                    Throw New UserException(strMsg)
                End If

                For kk As Integer = 0 To objTMST_RAC_BUNRUI_PR.ARYME.Length - 1
                    '(ٰ��:�D�揇��)

                    '************************
                    '�ڰݗD�揇�̎擾
                    '************************
                    Dim objSVR_100204 As New SVR_100204(Owner, ObjDb, ObjDbLog)    '�ڰݗD�揇�擾�׽
                    objSVR_100204.FTRK_BUF_NO = mFTRK_BUF_NO                       '�ׯ�ݸ��ޯ̧No
                    objSVR_100204.CRANE_ORDER_GET()                                '�擾


                    For ii As Integer = LBound(objSVR_100204.FEQ_ID) To UBound(objSVR_100204.FEQ_ID)
                        '(ٰ��:�ڰݐ�)

                        '************************
                        '�ڰݎw�蔻��
                        '************************
                        Dim blnCr As Boolean = False
                        If mFEQ_ID_CRANE Is Nothing Then
                            '************************
                            '�ڰݖ��w��
                            '************************
                            blnCr = True
                        Else
                            '************************
                            '�ڰݎw�莞
                            '************************
                            For jj As Integer = LBound(mFEQ_ID_CRANE) To UBound(mFEQ_ID_CRANE)
                                If mFEQ_ID_CRANE(jj) = objSVR_100204.FEQ_ID(ii) Then
                                    blnCr = True
                                    Exit For
                                End If
                            Next
                            If blnCr = False Then
                                Continue For
                            End If
                        End If


                        '************************
                        '�ڰ�Ͻ��̓���
                        '************************
                        Dim objTMST_CRANE As New TBL_TMST_CRANE(Owner, ObjDb, ObjDbLog) '�ڰ�Ͻ��׽
                        objTMST_CRANE.FEQ_ID = objSVR_100204.FEQ_ID(ii)                 '�ݔ�ID
                        intRet = objTMST_CRANE.GET_TMST_CRANE(False)                    '����
                        If intRet = RetCode.NotFound Then
                            '(������Ȃ��ꍇ)
                            strMsg = ERRMSG_NOTFOUND_TMST_CRANE & "[�ݔ�ID:" & TO_STRING(objTMST_CRANE.FEQ_ID) & "]"
                            Throw New UserException(strMsg)
                        End If


                        '************************
                        '�ݔ��󋵂̓���
                        '************************
                        Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog) '�ݔ��󋵸׽
                        objTSTS_EQ_CTRL.FEQ_ID = objTMST_CRANE.FEQ_ID                       '�ݔ�ID
                        intRet = objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL(True)                     '����
                        If (TO_INTEGER(objTSTS_EQ_CTRL.FEQ_CUT_STS) = FLAG_ON) Then
                            '(�ؗ����̏ꍇ)
                            Continue For
                        End If


                        '������������************************************************************************************************************
                        'SystemMate:N.Dounoshita 2012/10/19  ��I�����ɁA���ޱ�̐ؗ����������ɒǉ��B�ؗ�������Ă�����A��I�����̑ΏۂƂ��Ȃ��B


                        '************************************************
                        '���ޱ�ؗ�����
                        '************************************************
                        Dim blnEQCut As Boolean     '�ؗ��׸�
                        blnEQCut = SVR_100201_CheckTMST_CNV_CRANE(objTMST_CRANE.FEQ_ID, mFBUF_FM, mFTRK_BUF_NO)
                        If blnEQCut = True Then
                            '(�ؗ����̏ꍇ)
                            Continue For
                        End If


                        '������������************************************************************************************************************


                        '************************
                        '��I�̓���
                        '************************
                        Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)             '�ׯ�ݸ��ޯ̧�׽
                        objTPRG_TRK_BUF.FTRK_BUF_NO = mFTRK_BUF_NO                                      '�ׯ�ݸ��ޯ̧No
                        objTPRG_TRK_BUF.FRAC_FORM = mFRAC_FORM                                          '�I�`����
                        objTPRG_TRK_BUF.FRAC_BUNRUI = objTMST_RAC_BUNRUI_PR.ARYME(kk).FRAC_BUNRUI       '�I����
                        objTPRG_TRK_BUF.INTRETU_MIN = objTMST_CRANE.FCRANE_ROW1                         '�ŏ���
                        objTPRG_TRK_BUF.INTRETU_MAX = objTMST_CRANE.FCRANE_ROW2                         '�ő��

                        intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF_AKI_RAC                   '����
                        If intRet = RetCode.OK Then
                            '(���������ꍇ)


                            '************************
                            '�ڰݗD�揇�̍X�V
                            '************************
                            If mblnUpdate = True Then
                                '(�X�V�׸ނ�ON�̏ꍇ)
                                Dim objSVR_100205 As New SVR_100205(Owner, ObjDb, ObjDbLog)     '�ڰݗD�揇�X�V�׽
                                objSVR_100205.FTRK_BUF_NO = mFTRK_BUF_NO                        '�ׯ�ݸ��ޯ̧No
                                objSVR_100205.FEQ_ID = objSVR_100204.FEQ_ID(ii)                 '�g�p�ݔ�ID
                                objSVR_100205.CRANE_ORDER_UPDATE()                              '�X�V
                            End If


                            '************************
                            '�߂�l�̾��
                            '************************
                            mFTRK_BUF_ARRAY = objTPRG_TRK_BUF.FTRK_BUF_ARRAY    '�ׯ�ݸޔz��No
                            Return (RetCode.OK)                                 '����I��


                        End If
                    Next


                Next


            Else
                '(�ڰݖ��g�p�̏ꍇ)


                '************************
                '��I�̓���
                '************************
                Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog) '�ׯ�ݸ��ޯ̧�׽
                objTPRG_TRK_BUF.FTRK_BUF_NO = mFTRK_BUF_NO                          '�ׯ�ݸ��ޯ̧No
                objTPRG_TRK_BUF.FRAC_FORM = mFRAC_FORM                              '�I�`����
                intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF_AKI_RAC                   '����
                If intRet = RetCode.OK Then
                    '(���������ꍇ)

                    '************************
                    '�߂�l�̾��
                    '************************
                    mFTRK_BUF_ARRAY = objTPRG_TRK_BUF.FTRK_BUF_ARRAY    '�ׯ�ݸޔz��No
                    Return (RetCode.OK)                                 '����I��
                End If


            End If


            Return (RetCode.NotFound)


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New System.Exception(ex.Message)
        End Try
    End Function
#End Region

    '������������************************************************************************************************************
    'JobMate:N.Dounoshita 2013/04/03 ������ި��� and �߱�����̋�I�����ɑΉ�
#Region "  �����è�ϐ���`                                                                      "

#End Region
#Region "  �����è��`                                                                          "

#End Region
#Region "  �񋓑�(���������)                                                                    "
    Public Enum SearchKind
        Kind11      '����1-1(�߱����1���)(�I��ۯ���Ԃ����ɒ��ł���A����i�ڂ����I�ɍ݌ɂ��Ă����O�I�������Ă�B)
        Kind12      '����1-2(�߱����2���)(���I�������Ă�B)
    End Enum
#End Region
#Region "  ��I������(������ި��� and �߱�����p)                                                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��I������(������ި��� and �߱�����p)
    ''' </summary>
    ''' <returns>RetCode</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function FIND_PAIR_TANA_AKI() As RetCode
        Try
            Dim strMsg As String                    'ү����
            Dim intRet As RetCode                   '�߂�l
            Dim blnFIND As Boolean = False          '��������


            '************************
            '�����è����
            '************************
            If IsNull(mFTRK_BUF_NO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�ׯ�ݸ��ޯ̧No]"
                Throw New UserException(strMsg)
            End If

            '************************
            '�ڰݗD�揇�g�p�L���̊m�F
            '************************
            Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)             '���ѕϐ��׽
            objTPRG_SYS_HEN.FHENSU_ID = FHENSU_ID_SSS000000_003                             '�ϐ�ID
            intRet = objTPRG_SYS_HEN.GET_TPRG_SYS_HEN()                                     '�擾


            If TO_INTEGER(objTPRG_SYS_HEN.FHENSU_INT) = FLAG_ON Then
                '(�ڰݗD�揇�ϐ��g�p�̏ꍇ)


                '������������************************************************************************************************************
                'JobMate:S.Ouchi 2013/11/08 ��I�����ύX
                ' '' '' '' ''************************
                ' '' '' '' ''�I�`���ʗD�揇Ͻ��̎擾
                ' '' '' '' ''************************
                '' '' '' ''Dim objTMST_RAC_BUNRUI_PR As New TBL_TMST_RAC_BUNRUI_PR(Owner, ObjDb, ObjDbLog)         '�I���ޗD�揇Ͻ�
                '' '' '' ''objTMST_RAC_BUNRUI_PR.FRES_TYPE = mFRES_TYPE                '��������
                '' '' '' ''objTMST_RAC_BUNRUI_PR.ORDER_BY = "FRAC_PRIORITY"            '����
                '' '' '' ''intRet = objTMST_RAC_BUNRUI_PR.GET_TMST_RAC_BUNRUI_PR_ANY() '�擾
                '' '' '' ''If intRet = RetCode.NotFound Then
                '' '' '' ''    '(������Ȃ��ꍇ)
                '' '' '' ''    strMsg = ERRMSG_NOTFOUND_TMST_RACBUNRUI_PRIORITY & "[��������:" & mFRES_TYPE & "]"
                '' '' '' ''    Throw New UserException(strMsg)
                '' '' '' ''End If

                '' '' '' ''For kk As Integer = 0 To objTMST_RAC_BUNRUI_PR.ARYME.Length - 1
                '' '' '' ''    '(ٰ��:�D�揇��)

                '' '' '' ''    '************************
                '' '' '' ''    '�ڰݗD�揇�̎擾
                '' '' '' ''    '************************
                '' '' '' ''    Dim objSVR_100204 As New SVR_100204(Owner, ObjDb, ObjDbLog)    '�ڰݗD�揇�擾�׽
                '' '' '' ''    objSVR_100204.FTRK_BUF_NO = mFTRK_BUF_NO                       '�ׯ�ݸ��ޯ̧No
                '' '' '' ''    objSVR_100204.CRANE_ORDER_GET()                                '�擾


                '' '' '' ''    For ii As Integer = LBound(objSVR_100204.FEQ_ID) To UBound(objSVR_100204.FEQ_ID)
                '' '' '' ''        '(ٰ��:�ڰݐ�)

                '' '' '' ''        '************************
                '' '' '' ''        '�ڰݎw�蔻��
                '' '' '' ''        '************************
                '' '' '' ''        Dim blnCr As Boolean = False
                '' '' '' ''        If mFEQ_ID_CRANE Is Nothing Then
                '' '' '' ''            '************************
                '' '' '' ''            '�ڰݖ��w��
                '' '' '' ''            '************************
                '' '' '' ''            blnCr = True
                '' '' '' ''        Else
                '' '' '' ''            '************************
                '' '' '' ''            '�ڰݎw�莞
                '' '' '' ''            '************************
                '' '' '' ''            For jj As Integer = LBound(mFEQ_ID_CRANE) To UBound(mFEQ_ID_CRANE)
                '' '' '' ''                If mFEQ_ID_CRANE(jj) = objSVR_100204.FEQ_ID(ii) Then
                '' '' '' ''                    blnCr = True
                '' '' '' ''                    Exit For
                '' '' '' ''                End If
                '' '' '' ''            Next
                '' '' '' ''            If blnCr = False Then
                '' '' '' ''                Continue For
                '' '' '' ''            End If
                '' '' '' ''        End If

                '' '' '' ''        '************************
                '' '' '' ''        '�ڰ�Ͻ��̓���
                '' '' '' ''        '************************
                '' '' '' ''        Dim objTMST_CRANE As New TBL_TMST_CRANE(Owner, ObjDb, ObjDbLog) '�ڰ�Ͻ��׽
                '' '' '' ''        objTMST_CRANE.FEQ_ID = objSVR_100204.FEQ_ID(ii)                 '�ݔ�ID
                '' '' '' ''        intRet = objTMST_CRANE.GET_TMST_CRANE()                         '����
                '' '' '' ''        If intRet = RetCode.NotFound Then
                '' '' '' ''            '(������Ȃ��ꍇ)
                '' '' '' ''            strMsg = ERRMSG_NOTFOUND_TMST_CRANE & "[�ݔ�ID:" & TO_STRING(objTMST_CRANE.FEQ_ID) & "]"
                '' '' '' ''            Throw New UserException(strMsg)
                '' '' '' ''        End If


                '' '' '' ''        '************************
                '' '' '' ''        '�ݔ��󋵂̓���
                '' '' '' ''        '************************
                '' '' '' ''        Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog) '�ݔ��󋵸׽
                '' '' '' ''        objTSTS_EQ_CTRL.FEQ_ID = objTMST_CRANE.FEQ_ID                       '�ݔ�ID
                '' '' '' ''        intRet = objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()                         '����
                '' '' '' ''        If intRet = RetCode.NotFound Then
                '' '' '' ''            '(������Ȃ��ꍇ)
                '' '' '' ''            strMsg = ERRMSG_NOTFOUND_TSTS_EQ_CTRL & "[�ݔ�ID:" & objTSTS_EQ_CTRL.FEQ_ID & "]"
                '' '' '' ''            Throw New UserException(strMsg)
                '' '' '' ''        ElseIf (TO_INTEGER(objTSTS_EQ_CTRL.FEQ_CUT_STS) = FLAG_ON) Then
                '' '' '' ''            '(�ؗ����̏ꍇ)
                '' '' '' ''            Continue For
                '' '' '' ''        End If


                '' '' '' ''        '************************************************
                '' '' '' ''        '��I�̓���
                '' '' '' ''        '************************************************
                '' '' '' ''        ' ''If mblnPair = True Then
                '' '' '' ''        ' ''    '(�߱�����̏ꍇ)

                '' '' '' ''        '==============================
                '' '' '' ''        '����1-1(�߱����1���)
                '' '' '' ''        '==============================
                '' '' '' ''        intRet = SelectAkiTPRG_TRK_BUF(objTMST_CRANE _
                '' '' '' ''                                     , Nothing _
                '' '' '' ''                                     , objSVR_100204.FEQ_ID(ii) _
                '' '' '' ''                                     , objTMST_RAC_BUNRUI_PR.ARYME(kk) _
                '' '' '' ''                                     , SearchKind.Kind11 _
                '' '' '' ''                                     )
                '' '' '' ''        If intRet = RetCode.OK Then Return (RetCode.OK) '����I��

                '' '' '' ''        '==============================
                '' '' '' ''        '����1-2(�߱����2���)
                '' '' '' ''        '==============================
                '' '' '' ''        intRet = SelectAkiTPRG_TRK_BUF(objTMST_CRANE _
                '' '' '' ''                                     , Nothing _
                '' '' '' ''                                     , objSVR_100204.FEQ_ID(ii) _
                '' '' '' ''                                     , objTMST_RAC_BUNRUI_PR.ARYME(kk) _
                '' '' '' ''                                     , SearchKind.Kind12 _
                '' '' '' ''                                     )
                '' '' '' ''        If intRet = RetCode.OK Then Return (RetCode.OK) '����I��


                '' '' '' ''    Next


                '' '' '' ''Next
                'JobMate:S.Ouchi 2013/11/08 ��I�����ύX
                '������������************************************************************************************************************




                '������������************************************************************************************************************
                'JobMate:S.Ouchi 2013/11/08 ��I�����ύX

                '************************
                '��O�I������
                '************************
                intRet = FIND_TEMAE_TANA_AKI()
                If intRet = RetCode.OK Then Return (RetCode.OK) '����I��

                '************************
                '�ڰݗD�揇�̎擾
                '************************
                Dim objSVR_100204 As New SVR_100204(Owner, ObjDb, ObjDbLog)    '�ڰݗD�揇�擾�׽
                objSVR_100204.FTRK_BUF_NO = mFTRK_BUF_NO                       '�ׯ�ݸ��ޯ̧No
                objSVR_100204.CRANE_ORDER_GET()                                '�擾

                For ii As Integer = LBound(objSVR_100204.FEQ_ID) To UBound(objSVR_100204.FEQ_ID)
                    '(ٰ��:�ڰݐ�)

                    '************************
                    '�ڰݎw�蔻��
                    '************************
                    Dim blnCr As Boolean = False
                    If mFEQ_ID_CRANE Is Nothing Then
                        '************************
                        '�ڰݖ��w��
                        '************************
                        blnCr = True
                    Else
                        '************************
                        '�ڰݎw�莞
                        '************************
                        For jj As Integer = LBound(mFEQ_ID_CRANE) To UBound(mFEQ_ID_CRANE)
                            If mFEQ_ID_CRANE(jj) = objSVR_100204.FEQ_ID(ii) Then
                                blnCr = True
                                Exit For
                            End If
                        Next
                        If blnCr = False Then
                            Continue For
                        End If
                    End If

                    '************************
                    '�ڰ�Ͻ��̓���
                    '************************
                    Dim objTMST_CRANE As New TBL_TMST_CRANE(Owner, ObjDb, ObjDbLog) '�ڰ�Ͻ��׽
                    objTMST_CRANE.FEQ_ID = objSVR_100204.FEQ_ID(ii)                 '�ݔ�ID
                    intRet = objTMST_CRANE.GET_TMST_CRANE()                         '����
                    If intRet = RetCode.NotFound Then
                        '(������Ȃ��ꍇ)
                        strMsg = ERRMSG_NOTFOUND_TMST_CRANE & "[�ݔ�ID:" & TO_STRING(objTMST_CRANE.FEQ_ID) & "]"
                        Throw New UserException(strMsg)
                    End If


                    '************************
                    '�ݔ��󋵂̓���
                    '************************
                    Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog) '�ݔ��󋵸׽
                    objTSTS_EQ_CTRL.FEQ_ID = objTMST_CRANE.FEQ_ID                       '�ݔ�ID
                    intRet = objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()                         '����
                    If intRet = RetCode.NotFound Then
                        '(������Ȃ��ꍇ)
                        strMsg = ERRMSG_NOTFOUND_TSTS_EQ_CTRL & "[�ݔ�ID:" & objTSTS_EQ_CTRL.FEQ_ID & "]"
                        Throw New UserException(strMsg)
                    ElseIf (TO_INTEGER(objTSTS_EQ_CTRL.FEQ_CUT_STS) = FLAG_ON) Then
                        '(�ؗ����̏ꍇ)
                        Continue For
                    End If


                    '************************
                    '���ɒ�4PL����
                    '************************
                    Dim strFHENSU_ID As String

                    Select Case TO_INTEGER(mFBUF_FM)
                        Case 1000 To 1999
                            strFHENSU_ID = FHENSU_ID_SSJ000000_051      '1F
                        Case 2000 To 2999
                            strFHENSU_ID = FHENSU_ID_SSJ000000_052      '2F
                        Case 4000 To 4999
                            strFHENSU_ID = FHENSU_ID_SSJ000000_051      '1F
                        Case 5000 To 5999
                            strFHENSU_ID = FHENSU_ID_SSJ000000_052      '2F
                        Case Else
                            strFHENSU_ID = FHENSU_ID_SSJ000000_052      '2F
                    End Select

                    Dim intCount As Integer
                    Dim objTRK_BUF_IN As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)                       '�ׯ�ݸ��ޯ̧�׽
                    intCount = objTRK_BUF_IN.GET_TPRG_TRK_BUF_NI_NUM(objTMST_CRANE.FEQ_ID, strFHENSU_ID)    '����
                    If intCount >= 4 Then
                        '(4PL�ȏ�̏ꍇ)
                        Continue For
                    End If


                    '************************
                    '�I�`���ʗD�揇Ͻ��̎擾
                    '************************
                    Dim objTMST_RAC_BUNRUI_PR As New TBL_TMST_RAC_BUNRUI_PR(Owner, ObjDb, ObjDbLog)         '�I���ޗD�揇Ͻ�
                    objTMST_RAC_BUNRUI_PR.FRES_TYPE = mFRES_TYPE                '��������
                    objTMST_RAC_BUNRUI_PR.ORDER_BY = "FRAC_PRIORITY"            '����
                    intRet = objTMST_RAC_BUNRUI_PR.GET_TMST_RAC_BUNRUI_PR_ANY() '�擾
                    If intRet = RetCode.NotFound Then
                        '(������Ȃ��ꍇ)
                        strMsg = ERRMSG_NOTFOUND_TMST_RACBUNRUI_PRIORITY & "[��������:" & mFRES_TYPE & "]"
                        Throw New UserException(strMsg)
                    End If

                    For kk As Integer = 0 To objTMST_RAC_BUNRUI_PR.ARYME.Length - 1
                        '(ٰ��:�D�揇��)

                        '************************************************
                        '��I�̓���
                        '************************************************
                        ' ''If mblnPair = True Then
                        ' ''    '(�߱�����̏ꍇ)

                        ' '' ''==============================
                        ' '' ''����1-1(�߱����1���)
                        ' '' ''==============================
                        '' ''intRet = SelectAkiTPRG_TRK_BUF(objTMST_CRANE _
                        '' ''                             , Nothing _
                        '' ''                             , objSVR_100204.FEQ_ID(ii) _
                        '' ''                             , objTMST_RAC_BUNRUI_PR.ARYME(kk) _
                        '' ''                             , SearchKind.Kind11 _
                        '' ''                             )
                        '' ''If intRet = RetCode.OK Then Return (RetCode.OK) '����I��

                        '==============================
                        '����1-2(�߱����2���)
                        '==============================
                        intRet = SelectAkiTPRG_TRK_BUF(objTMST_CRANE _
                                                     , Nothing _
                                                     , objSVR_100204.FEQ_ID(ii) _
                                                     , objTMST_RAC_BUNRUI_PR.ARYME(kk) _
                                                     , SearchKind.Kind12 _
                                                     )
                        If intRet = RetCode.OK Then Return (RetCode.OK) '����I��


                    Next


                Next
                'JobMate:S.Ouchi 2013/11/08 ��I�����ύX
                '������������************************************************************************************************************


            Else
                '(�ڰݖ��g�p�̏ꍇ)


                '************************
                '��I�̓���
                '************************
                Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog) '�ׯ�ݸ��ޯ̧�׽
                objTPRG_TRK_BUF.FTRK_BUF_NO = mFTRK_BUF_NO                          '�ׯ�ݸ��ޯ̧No
                objTPRG_TRK_BUF.FRAC_FORM = mFRAC_FORM                              '�I�`����
                intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF_AKI_RAC                   '����
                If intRet = RetCode.OK Then
                    '(���������ꍇ)

                    '************************
                    '�߂�l�̾��
                    '************************
                    mFTRK_BUF_ARRAY = objTPRG_TRK_BUF.FTRK_BUF_ARRAY    '�ׯ�ݸޔz��No
                    Return (RetCode.OK)                                 '����I��
                End If


            End If


            Return (RetCode.NotFound)


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New System.Exception(ex.Message)
        End Try
    End Function
#End Region
#Region "  �ׯ�ݸ��ޯ̧ð��ً�I��������                                                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ׯ�ݸ��ޯ̧ð��ً�I��������
    ''' </summary>
    ''' <param name="objTMST_CRANE">�ڰ�Ͻ�ð��ٸ׽</param>
    ''' <param name="intFRAC_FORM">�I�`����</param>
    ''' <param name="strFEQ_ID">�ݔ�ID(�ڰ�ID)</param>
    ''' <param name="objTMST_RAC_BUNRUI_PR">�I���ޗD�揇Ͻ�</param>
    ''' <param name="intSearchKind">���������</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function SelectAkiTPRG_TRK_BUF(ByVal objTMST_CRANE As TBL_TMST_CRANE _
                                         , ByVal intFRAC_FORM As Integer _
                                         , ByVal strFEQ_ID As String _
                                         , ByVal objTMST_RAC_BUNRUI_PR As TBL_TMST_RAC_BUNRUI_PR _
                                         , ByVal intSearchKind As SearchKind _
                                           ) As RetCode
        Try
            'Dim strMsg As String                    'ү����
            Dim intRet As RetCode                   '�߂�l
            Dim blnFIND As Boolean = False          '��������


            '***************************************************************************************************************************************************************
            '***************************************************************************************************************************************************************
            '���������̐ݒ�
            '***************************************************************************************************************************************************************
            '***************************************************************************************************************************************************************
            Dim intXTANA_BLOCK_STS As Nullable(Of Integer)      '�I��ۯ����
            Dim intXTANA_BLOCK_DTL As Nullable(Of Integer)      '�I��ۯ��ڍ�
            Dim intFRAC_EDA As Nullable(Of Integer)             '�}
            Select Case intSearchKind
                '************************
                '�߱����
                '************************
                Case SearchKind.Kind11
                    '����1-1(�߱����1���)
                    '(�I��ۯ���Ԃ����ɒ��ł���A����i�ڂ����I�ɍ݌ɂ��Ă����O�I�������Ă�B)
                    intXTANA_BLOCK_STS = XTANA_BLOCK_STS_IN                         '�I��ۯ����
                    intXTANA_BLOCK_DTL = XTANA_BLOCK_DTL_MAE_EVN                    '�I��ۯ��ڍ�
                    intFRAC_EDA = FRAC_EDA_MAE                                      '�}
                Case SearchKind.Kind12
                    '����1-1(�߱����2���)
                    '(���I�������Ă�B)
                    intXTANA_BLOCK_STS = Nothing                                    '�I��ۯ����
                    intXTANA_BLOCK_DTL = XTANA_BLOCK_DTL_OKU_EVN                    '�I��ۯ��ڍ�
                    intFRAC_EDA = FRAC_EDA_OKU                                      '�}
            End Select


            '************************
            '��I�̓���
            '************************
            Dim objTrkBase As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog) '�ׯ�ݸ��ޯ̧�׽
            objTrkBase.FTRK_BUF_NO = mFTRK_BUF_NO                          '�ׯ�ݸ��ޯ̧No
            objTrkBase.FRAC_FORM = intFRAC_FORM                            '�I�`����

            '    ������������************************************************************************************************************
            '    JobMate:S.Ouchi 2013/11/08 ��I�����ύX
            If Not (objTMST_RAC_BUNRUI_PR Is Nothing) Then
                'JobMate:S.Ouchi 2013/11/08 ��I�����ύX
                '������������************************************************************************************************************

                objTrkBase.FRAC_BUNRUI = objTMST_RAC_BUNRUI_PR.FRAC_BUNRUI     '�I����

                '������������************************************************************************************************************
                'JobMate:S.Ouchi 2013/11/08 ��I�����ύX
            End If
            '    JobMate:S.Ouchi 2013/11/08 ��I�����ύX
            '    ������������************************************************************************************************************

            objTrkBase.INTRETU_MIN = objTMST_CRANE.FCRANE_ROW1             '�ŏ���
            objTrkBase.INTRETU_MAX = objTMST_CRANE.FCRANE_ROW2             '�ő��
            objTrkBase.FRAC_FORM = mFRAC_FORM                              '�I�`����
            objTrkBase.FRAC_EDA = intFRAC_EDA                              '�}
            objTrkBase.XTANA_BLOCK = mXTANA_BLOCK                          '�I��ۯ�
            objTrkBase.XTANA_BLOCK_DTL = intXTANA_BLOCK_DTL                '�I��ۯ��ڍ�
            objTrkBase.XTANA_BLOCK_STS = intXTANA_BLOCK_STS                '�I��ۯ����
            intRet = objTrkBase.GET_TPRG_TRK_BUF_AKI_RAC(True)             '����
            If intRet = RetCode.OK Then
                '(���������ꍇ)
                For ii As Integer = 0 To objTrkBase.ARYME.Length - 1
                    '(ٰ��:��I��)


                    '************************************************
                    '�O�シ��I�����擾
                    '************************************************
                    Dim objTrkFind As TBL_TPRG_TRK_BUF = objTrkBase.ARYME(ii)               '�ׯ�ݸ��ޯ̧�׽
                    Dim objTrkRelation() As TBL_TPRG_TRK_BUF = Nothing                      '�ׯ�ݸ��ޯ̧�׽
                    Dim objStockFind As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)          '�݌ɏ��
                    Dim objStockRelation() As TBL_TRST_STOCK = Nothing                      '�݌ɏ��
                    Call GetTPRG_TRK_BUF_Relation(objTrkFind, objTrkRelation, objStockFind, objStockRelation)

                    '========================
                    '���ɂ���݌ɏ����擾
                    '========================
                    objStockFind.CLEAR_PROPERTY()                   '�����è�ر
                    objStockFind.FPALLET_ID = mFPALLET_ID           '��گ�ID
                    intRet = objStockFind.GET_TRST_STOCK_KONSAI(True)   '�擾


                    '***************************************************************************************************************************************************************
                    '***************************************************************************************************************************************************************
                    '��I���������Ă邩�ۂ��̔��f
                    '***************************************************************************************************************************************************************
                    '***************************************************************************************************************************************************************
                    Dim intFTRK_BUF_ARRAY_Pair As Nullable(Of Integer) = Nothing
                    Select Case intSearchKind
                        Case SearchKind.Kind11
                            '����1-1(�߱����1���)


                            '************************************************************************************************
                            '��O�I�������Ƃ���I����Ȃ��ƈ������ĂȂ�
                            '************************************************************************************************
                            If Not (objTrkRelation(RelationArray.MAE_EVN).FRES_KIND = FRES_KIND_SAKI) Then Continue For
                            If Not (objTrkRelation(RelationArray.MAE_ODD).FRES_KIND = FRES_KIND_SAKI) Then Continue For


                            '************************************************************************************************
                            '���I�� �݌ɒI or �����\�� �ȊO�̏ꍇ�͈������ĂȂ�
                            '************************************************************************************************
                            If Not (objTrkRelation(RelationArray.OKU_EVN).FRES_KIND = FRES_KIND_SZAIKO Or objTrkRelation(RelationArray.OKU_EVN).FRES_KIND = FRES_KIND_SRSV_TRNS_IN) Then Continue For
                            If Not (objTrkRelation(RelationArray.OKU_ODD).FRES_KIND = FRES_KIND_SZAIKO Or objTrkRelation(RelationArray.OKU_ODD).FRES_KIND = FRES_KIND_SRSV_TRNS_IN) Then Continue For


                            '************************************************************************************************
                            '����i��                       �̍݌ɂ���Ȃ��ƈ����ĂȂ�
                            '������ɋ敪                   �̍݌ɂ���Ȃ��ƈ����ĂȂ�
                            '���ꐶ�Yײ݇�                  �̍݌ɂ���Ȃ��ƈ����ĂȂ�
                            '����ۯć�                      �̍݌ɂ���Ȃ��ƈ����ĂȂ�
                            '����Ұ������                   �̍݌ɂ���Ȃ��ƈ����ĂȂ�
                            '************************************************************************************************
                            If Not (objStockFind.ARYME(0).FHINMEI_CD = objStockRelation(RelationArray.OKU_EVN).ARYME(0).FHINMEI_CD) Then Continue For
                            If Not (objStockFind.ARYME(0).FHINMEI_CD = objStockRelation(RelationArray.OKU_ODD).ARYME(0).FHINMEI_CD) Then Continue For
                            If Not (objStockFind.ARYME(0).FIN_KUBUN = objStockRelation(RelationArray.OKU_EVN).ARYME(0).FIN_KUBUN) Then Continue For
                            If Not (objStockFind.ARYME(0).FIN_KUBUN = objStockRelation(RelationArray.OKU_ODD).ARYME(0).FIN_KUBUN) Then Continue For
                            If Not (objStockFind.ARYME(0).XPROD_LINE = objStockRelation(RelationArray.OKU_EVN).ARYME(0).XPROD_LINE) Then Continue For
                            If Not (objStockFind.ARYME(0).XPROD_LINE = objStockRelation(RelationArray.OKU_ODD).ARYME(0).XPROD_LINE) Then Continue For
                            If Not (objStockFind.ARYME(0).FLOT_NO = objStockRelation(RelationArray.OKU_EVN).ARYME(0).FLOT_NO) Then Continue For
                            If Not (objStockFind.ARYME(0).FLOT_NO = objStockRelation(RelationArray.OKU_ODD).ARYME(0).FLOT_NO) Then Continue For
                            If Not (objStockFind.ARYME(0).XMAKER_CD = objStockRelation(RelationArray.OKU_EVN).ARYME(0).XMAKER_CD) Then Continue For
                            If Not (objStockFind.ARYME(0).XMAKER_CD = objStockRelation(RelationArray.OKU_ODD).ARYME(0).XMAKER_CD) Then Continue For


                            '************************************************************************************************
                            '�߱�̖߂�l�ݒ�
                            '************************************************************************************************
                            If mblnPair = True Then
                                '(�߱���ɂ̏ꍇ)
                                If objTrkFind.XTANA_BLOCK_DTL = objTrkRelation(RelationArray.MAE_EVN).XTANA_BLOCK_DTL Then
                                    intFTRK_BUF_ARRAY_Pair = objTrkRelation(RelationArray.MAE_ODD).FTRK_BUF_ARRAY
                                Else
                                    intFTRK_BUF_ARRAY_Pair = objTrkRelation(RelationArray.MAE_EVN).FTRK_BUF_ARRAY
                                End If
                            End If


                        Case SearchKind.Kind12
                            'Case SearchKind.Kind12, SearchKind.Kind24
                            '����1-2(�߱����2���)


                            '************************************************************************************************
                            '���I�������Ƃ���I����Ȃ��ƈ������ĂȂ�
                            '************************************************************************************************
                            If Not (objTrkRelation(RelationArray.OKU_EVN).FRES_KIND = FRES_KIND_SAKI) Then Continue For
                            If Not (objTrkRelation(RelationArray.OKU_ODD).FRES_KIND = FRES_KIND_SAKI) Then Continue For


                            '************************************************************************************************
                            '��O�I�� ��I �ȊO�̏ꍇ�͈������ĂȂ�
                            '************************************************************************************************
                            If Not (objTrkRelation(RelationArray.MAE_EVN).FRES_KIND = FRES_KIND_SAKI) Then Continue For
                            If Not (objTrkRelation(RelationArray.MAE_ODD).FRES_KIND = FRES_KIND_SAKI) Then Continue For


                            '************************************************************************************************
                            '�߱�̖߂�l�ݒ�
                            '************************************************************************************************
                            If mblnPair = True Then
                                '(�߱���ɂ̏ꍇ)
                                If objTrkFind.XTANA_BLOCK_DTL = objTrkRelation(RelationArray.OKU_EVN).XTANA_BLOCK_DTL Then
                                    intFTRK_BUF_ARRAY_Pair = objTrkRelation(RelationArray.OKU_ODD).FTRK_BUF_ARRAY
                                Else
                                    intFTRK_BUF_ARRAY_Pair = objTrkRelation(RelationArray.OKU_EVN).FTRK_BUF_ARRAY
                                End If
                            End If


                    End Select


                    '************************
                    '�ڰݗD�揇�̍X�V
                    '************************
                    If mblnUpdate = True Then
                        '(�X�V�׸ނ�ON�̏ꍇ)
                        If intSearchKind = SearchKind.Kind11 Or mblnPair = False Then
                            '(�ڰ݂��X�V����ꍇ)
                            Dim objSVR_100205 As New SVR_100205(Owner, ObjDb, ObjDbLog)     '�ڰݗD�揇�X�V�׽
                            objSVR_100205.FTRK_BUF_NO = mFTRK_BUF_NO                        '�ׯ�ݸ��ޯ̧No
                            objSVR_100205.FEQ_ID = strFEQ_ID                                '�g�p�ݔ�ID
                            objSVR_100205.CRANE_ORDER_UPDATE()                              '�X�V
                        End If
                    End If


                    '************************
                    '�߂�l�̾��
                    '************************
                    mFTRK_BUF_ARRAY = objTrkFind.FTRK_BUF_ARRAY         '�ׯ�ݸޔz��No
                    mFTRK_BUF_ARRAY_Pair = intFTRK_BUF_ARRAY_Pair       '�ׯ�ݸޔz��No(�߱����)
                    Return (RetCode.OK)                                 '����I��


                Next
            End If


            Return (RetCode.NotFound)


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New System.Exception(ex.Message)
        End Try
    End Function
#End Region


    '������������************************************************************************************************************
    'JobMate:S.Ouchi 2013/11/08 ��I�����ύX
#Region "  ��O�I������(������ި��� and �߱�����p)                                              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��O�I������(������ި��� and �߱�����p)
    ''' </summary>
    ''' <returns>RetCode</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function FIND_TEMAE_TANA_AKI() As RetCode
        Try
            Dim strMsg As String                    'ү����
            Dim intRet As RetCode                   '�߂�l
            Dim blnFIND As Boolean = False          '��������


            '************************
            '�����è����
            '************************
            If IsNull(mFTRK_BUF_NO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�ׯ�ݸ��ޯ̧No]"
                Throw New UserException(strMsg)
            End If


            '************************
            '�ڰݗD�揇�̎擾
            '************************
            Dim objSVR_100204 As New SVR_100204(Owner, ObjDb, ObjDbLog)    '�ڰݗD�揇�擾�׽
            objSVR_100204.FTRK_BUF_NO = mFTRK_BUF_NO                       '�ׯ�ݸ��ޯ̧No
            objSVR_100204.CRANE_ORDER_GET()                                '�擾

            For ii As Integer = LBound(objSVR_100204.FEQ_ID) To UBound(objSVR_100204.FEQ_ID)
                '(ٰ��:�ڰݐ�)

                '************************
                '�ڰݎw�蔻��
                '************************
                Dim blnCr As Boolean = False
                If mFEQ_ID_CRANE Is Nothing Then
                    '************************
                    '�ڰݖ��w��
                    '************************
                    blnCr = True
                Else
                    '************************
                    '�ڰݎw�莞
                    '************************
                    For jj As Integer = LBound(mFEQ_ID_CRANE) To UBound(mFEQ_ID_CRANE)
                        If mFEQ_ID_CRANE(jj) = objSVR_100204.FEQ_ID(ii) Then
                            blnCr = True
                            Exit For
                        End If
                    Next
                    If blnCr = False Then
                        Continue For
                    End If
                End If

                '************************
                '�ڰ�Ͻ��̓���
                '************************
                Dim objTMST_CRANE As New TBL_TMST_CRANE(Owner, ObjDb, ObjDbLog) '�ڰ�Ͻ��׽
                objTMST_CRANE.FEQ_ID = objSVR_100204.FEQ_ID(ii)                 '�ݔ�ID
                intRet = objTMST_CRANE.GET_TMST_CRANE()                         '����
                If intRet = RetCode.NotFound Then
                    '(������Ȃ��ꍇ)
                    strMsg = ERRMSG_NOTFOUND_TMST_CRANE & "[�ݔ�ID:" & TO_STRING(objTMST_CRANE.FEQ_ID) & "]"
                    Throw New UserException(strMsg)
                End If


                '************************
                '�ݔ��󋵂̓���
                '************************
                Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(Owner, ObjDb, ObjDbLog) '�ݔ��󋵸׽
                objTSTS_EQ_CTRL.FEQ_ID = objTMST_CRANE.FEQ_ID                       '�ݔ�ID
                intRet = objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()                         '����
                If intRet = RetCode.NotFound Then
                    '(������Ȃ��ꍇ)
                    strMsg = ERRMSG_NOTFOUND_TSTS_EQ_CTRL & "[�ݔ�ID:" & objTSTS_EQ_CTRL.FEQ_ID & "]"
                    Throw New UserException(strMsg)
                ElseIf (TO_INTEGER(objTSTS_EQ_CTRL.FEQ_CUT_STS) = FLAG_ON) Then
                    '(�ؗ����̏ꍇ)
                    Continue For
                End If


                '************************
                '���ɒ�4PL����
                '************************
                Dim strFHENSU_ID As String

                Select Case TO_INTEGER(mFBUF_FM)
                    Case 1000 To 1999
                        strFHENSU_ID = FHENSU_ID_SSJ000000_051      '1F
                    Case 2000 To 2999
                        strFHENSU_ID = FHENSU_ID_SSJ000000_052      '2F
                    Case 4000 To 4999
                        strFHENSU_ID = FHENSU_ID_SSJ000000_051      '1F
                    Case 5000 To 5999
                        strFHENSU_ID = FHENSU_ID_SSJ000000_052      '2F
                    Case Else
                        strFHENSU_ID = FHENSU_ID_SSJ000000_052      '2F
                End Select

                Dim intCount As Integer
                Dim objTRK_BUF_IN As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)                       '�ׯ�ݸ��ޯ̧�׽
                intCount = objTRK_BUF_IN.GET_TPRG_TRK_BUF_NI_NUM(objTMST_CRANE.FEQ_ID, strFHENSU_ID)    '����
                If intCount >= 4 Then
                    '(4PL�ȏ�̏ꍇ)
                    Continue For
                End If

                '==============================
                '����1-1(�߱����1���)
                '==============================
                intRet = SelectAkiTPRG_TRK_BUF(objTMST_CRANE _
                                             , Nothing _
                                             , objSVR_100204.FEQ_ID(ii) _
                                             , Nothing _
                                             , SearchKind.Kind11 _
                                             )
                If intRet = RetCode.OK Then Return (RetCode.OK) '����I��

            Next


            Return (RetCode.NotFound)


        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw New UserException(ex.Message)
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New System.Exception(ex.Message)
        End Try
    End Function
#End Region
    'JobMate:S.Ouchi 2013/11/08 ��I�����ύX
    '������������************************************************************************************************************

    '������������************************************************************************************************************

End Class
