'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z�ڰݗD�揇�X�V�׽
' �y�쐬�zSIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon�g�p�̈�
Imports MateCommon.clsConst                 'Confiģ�ٓǍ��ݓ��W��Ӽޭ�َg�p�̈�
#End Region

Public Class SVR_100205
    Inherits clsTemplateServer

#Region "  �׽���������p�ϐ���`                                                                "
#End Region
#Region "  �����è�ϐ���`                                                                      "
    Private mFTRK_BUF_NO As Nullable(Of Integer)    '�ׯ�ݸ��ޯ̧No
    Private mFEQ_ID As String                       '�ݔ�ID
    '������������************************************************************************************************************
    'SystemMate:N.Dounoshita 2013/05/24  �X�V����ڰݗD�揇��I���\�ɂ���
    Private mFHENSU_ID As String                    '�ϐ�ID
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
    ''' <summary>�ݔ�ID</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FEQ_ID() As String
        Get
            Return mFEQ_ID
        End Get
        Set(ByVal Value As String)
            mFEQ_ID = Value
        End Set
    End Property
    '������������************************************************************************************************************
    'SystemMate:N.Dounoshita 2013/05/24  �X�V����ڰݗD�揇��I���\�ɂ���
    ''' =======================================
    ''' <summary>�ϐ�ID</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FHENSU_ID() As String
        Get
            Return mFHENSU_ID
        End Get
        Set(ByVal Value As String)
            mFHENSU_ID = Value
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
    End Sub
#End Region
#Region "  �ڰݗD�揇�X�V                                                                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ڰݗD�揇�X�V
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub CRANE_ORDER_UPDATE()
        Try
            Dim strMsg As String        'ү����
            Dim intRet As RetCode       '�߂�l


            '************************
            '�����è����
            '************************
            If IsNull(mFTRK_BUF_NO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�ׯ�ݸ��ޯ̧No]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFEQ_ID) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�ݔ�ID]"
                Throw New UserException(strMsg)
            End If


            '******************************************
            '�ڰݗD�揇�̍č\�z
            '******************************************
            '================================
            '���ѕϐ��擾
            '================================
            Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)         '���ѕϐ��׽
            '������������************************************************************************************************************
            'SystemMate:N.Dounoshita 2013/05/24  �X�V����ڰݗD�揇��I���\�ɂ���
            If IsNotNull(mFHENSU_ID) Then
                objTPRG_SYS_HEN.FHENSU_ID = mFHENSU_ID                  '�ϐ�ID
            Else
                objTPRG_SYS_HEN.FHENSU_ID = FHENSU_ID_SSS000000_002     '�ϐ�ID
            End If
            'objTPRG_SYS_HEN.FHENSU_ID = FHENSU_ID_SSS000000_002                         '�ϐ�ID
            '������������************************************************************************************************************
            intRet = objTPRG_SYS_HEN.GET_TPRG_SYS_HEN(True)                             '�擾

            '================================
            '�ݔ�ID����
            '================================
            Dim strTemp() As String             '�ݔ�ID�z��ꎞ�ۊ�
            Dim blnFound As Boolean = False     '�ݔ�ID�����׸�
            Dim ii As Integer                   '����
            strTemp = Split(objTPRG_SYS_HEN.FHENSU_CHAR, KUGIRI01)
            For ii = LBound(strTemp) To UBound(strTemp)
                '(ٰ��:�ڰݐ�)
                If mFEQ_ID = strTemp(ii) Then
                    '(���������ꍇ)
                    blnFound = True
                    Exit For
                End If
            Next
            If blnFound = False Then
                strMsg = ERRMSG_NOTFOUND_FEQ_ID & "[�ݔ�ID:" & TO_STRING(mFEQ_ID) & "][�ڰݗD�揇:" & objTPRG_SYS_HEN.FHENSU_CHAR & "]"
                Throw New UserException(strMsg)
            End If

            '================================
            '�č\�z
            '================================
            Dim strSCRN_PRI As String = ""      '�ڰݗD�揇�č\�z
            If ii <> UBound(strTemp) Then
                '(�I�����ꂽ�ڰ݂��Ō������Ȃ��ꍇ)

                For jj As Integer = ii + 1 To UBound(strTemp)
                    '(ٰ��:�ݒ肳�ꂽ���̸ڰ݂���A�Ō���̸ڰ݂܂�)
                    strSCRN_PRI &= KUGIRI01 & strTemp(jj)
                Next
                For jj As Integer = LBound(strTemp) To ii
                    '(ٰ��:�ŏ��̸ڰ݂���A�ݒ肳�ꂽ�ڰ݂܂�)
                    strSCRN_PRI &= KUGIRI01 & strTemp(jj)
                Next

                '�ŏ������Ȱ����폜
                strSCRN_PRI = Replace(strSCRN_PRI, KUGIRI01, "", 1, 1)

                '�X�V
                objTPRG_SYS_HEN.FHENSU_CHAR = strSCRN_PRI   '�ڰݗD�揇
                objTPRG_SYS_HEN.UPDATE_TPRG_SYS_HEN()       '�X�V

            End If






            ' '' ''************************
            ' '' ''�ڰݗD�揇�̍č\�z
            ' '' ''************************
            '' ''Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(Owner, ObjDb, ObjDbLog)     '���ѕϐ��׽
            '' ''Dim strSCRANE As String = objTPRG_SYS_HEN.SCRANE                        '�ڰݗD�揇
            '' ''Dim strTemp As String = DEFAULT_STRING                                  'TEMP
            '' ''intLen = Len(strSCRANE)                                                 '�������̎擾
            '' ''intPos = InStr(TO_STRING(strSCRANE), mFCRANE_ID)                        '�����ʒu�̓���
            '' ''strTemp = strTemp & Mid(TO_STRING(strSCRANE), intPos + 1)
            '' ''strTemp = strTemp & Mid(TO_STRING(strSCRANE), 1, intPos)


            ' '' ''************************
            ' '' ''���ѕϐ��̍X�V
            ' '' ''************************
            '' ''objTPRG_SYS_HEN.SCRANE = strTemp


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
