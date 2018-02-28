'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. 
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z�݌Ɉ����׽
' �y�쐬�zSIT
'**********************************************************************************************

#Region "  Imports                                                                              "
Imports JobCommon
Imports MateCommon                          'MateCommon�g�p�̈�
Imports MateCommon.clsConst                 'Confiģ�ٓǍ��ݓ��W��Ӽޭ�َg�p�̈�
#End Region

Public Class SVR_100202
    Inherits clsTemplateServer

#Region "  �׽���������p�萔��`                                                                "
    Public Enum UpdateMode
        CHANGE_ALL = 0                                              '�݌ɏ���ׯ�ݸ��ޯ̧�X�V
        STOCK_ONLY = 1                                              '�݌ɏ��̂ݍX�V
        NON_UPDATE = 2                                              '�X�V�Ȃ�
    End Enum

    Public Const CHK_PROC As Integer = 1                            '�L���݌ɐ�����
    Public Const RSV_PROC As Integer = 2                            '�݌Ɋm�ۏ���
#End Region
#Region "  �����è�ϐ���`                                                                      "
    Private mFTRK_BUF_NO As Nullable(Of Integer)                        '�ׯ�ݸ��ޯ̧��
    Private mFPALLET_ID As String                                       '��گ�ID
    '������������************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/04/25  ���������ɍ݌�ۯć���ǉ�
    Private mFLOT_NO_STOCK As String                                    '�݌�ۯć�
    '������������************************************************************************************************************
    Private mFHINMEI_CD As String                                       '�i������
    Private mFLOT_NO As String                                          'ۯć�
    Private mFEQ_CHK_KUBUN As Boolean = True                            '�ݔ�����敪
    Private mFSYUKKA_TO_CD As String = ""                               '�o�א溰��
    Private mFEQ_ID_CRN As String                                       '�ݔ�ID(�ڰ�)
    Private mBLNFullVol_Check As Boolean = False                        '��گē��S�������׸�
    Private mINTUpdateMode As UpdateMode = UpdateMode.CHANGE_ALL        '�X�VӰ��
    Private mFSEIHIN_KUBUN As Nullable(Of Integer)                      '���i�敪
    Private mFZAIKO_KUBUN As Nullable(Of Integer)                       '�݌ɋ敪
    Private mFHORYU_KUBUN As Nullable(Of Integer)                       '�ۗ��敪
    Private mINTMaxPlt As Nullable(Of Integer)                          '������گĐ�����
    Private mstrArrayPALLET_ID() As String                              '�����ς���گ�(��گ�ID)
    Private mFTR_RES_VOL() As Nullable(Of Decimal)                      '�����ς���گ�(����������)
    '������������************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/04/27  �I�`���ʂ�ǉ�
    Private mFRAC_FORM As Nullable(Of Integer)                          '�I�`����
    '������������************************************************************************************************************
    '������������************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/04/25  ���������ɍ݌�ۯć���ǉ�
    Private mstrArrayFLOT_NO_STOCK() As String                          '�����ς���گ�(�݌�ۯć�)
    '������������************************************************************************************************************
    '������������************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/04/27  OrderBy�𐧌�
    Private mstrOrderBy As String                                       'OrderBy
    '������������************************************************************************************************************
    '������������************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/10/20  �݌Ɉ����ɁA���ޱ�̐ؗ����������ɒǉ��B�ؗ�������Ă�����A�݌Ɉ����̑ΏۂƂ��Ȃ��B
    Private mFBUF_TO As Nullable(Of Integer)           '�������ׯ�ݸ��ޯ̧��
    '������������************************************************************************************************************
    '������������************************************************************************************************************
    'SystemMate:N.Dounoshita 2013/06/05  �[������
    Public Enum HasuMode
        All             '��PL�A�[��PL����
        HasuPL          '�[��PL �̂�
        FullPL          '��PL   �̂�
    End Enum
    Private mintHasu As HasuMode = HasuMode.All         '�[���׸�
    '������������************************************************************************************************************
    '������������************************************************************************************************************
    'SystemMate:N.Dounoshita 2013/06/07  ���ɋ敪
    Private mFIN_KUBUN As String                        '���ɋ敪
    '������������************************************************************************************************************
    '������������************************************************************************************************************
    'JobMate:N.Dounoshita 2013/06/20 �I��ۯ��ǉ�
    Private mintAryXTANA_BLOCK() As Nullable(Of Integer)    '�I��ۯ�
    '������������************************************************************************************************************
    '������������************************************************************************************************************
    'JobMate:N.Dounoshita 2013/06/20 �����敪�A���i�敪��ǉ�
    Private mXKENSA_KUBUN As Nullable(Of Integer)    '�����敪
    Private mXKENPIN_KUBUN As Nullable(Of Integer)   '���i�敪
    Private mXMAKER_CD As String                     'Ұ�-����
    '������������************************************************************************************************************
#End Region
#Region "  �����è��`                                                                          "
    ''' =======================================
    ''' <summary>�ׯ�ݸ��ޯ̧��</summary>
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
    ''' <summary>��گ�ID</summary>
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
    ''' <summary>�݌�ۯć�</summary>
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
    ''' <summary>�i������</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FHINMEI_CD() As String
        Get
            Return mFHINMEI_CD
        End Get
        Set(ByVal Value As String)
            mFHINMEI_CD = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>ۯć�</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FLOT_NO() As String
        Get
            Return mFLOT_NO
        End Get
        Set(ByVal Value As String)
            mFLOT_NO = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>�ݔ�����敪</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FEQ_CHK_KUBUN() As Boolean
        Get
            Return mFEQ_CHK_KUBUN
        End Get
        Set(ByVal Value As Boolean)
            mFEQ_CHK_KUBUN = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>�o�א溰��</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FSYUKKA_TO_CD() As String
        Get
            Return mFSYUKKA_TO_CD
        End Get
        Set(ByVal Value As String)
            mFSYUKKA_TO_CD = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>�ݔ�ID(�ڰ�)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FEQ_ID_CRN() As String
        Get
            Return mFEQ_ID_CRN
        End Get
        Set(ByVal Value As String)
            mFEQ_ID_CRN = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>��گē��S�������׸�</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property BLNFullVol_Check() As Boolean
        Get
            Return mBLNFullVol_Check
        End Get
        Set(ByVal Value As Boolean)
            mBLNFullVol_Check = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>�X�VӰ��</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property INTUpdateMode() As UpdateMode
        Get
            Return mINTUpdateMode
        End Get
        Set(ByVal Value As UpdateMode)
            mINTUpdateMode = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>���i�敪</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FSEIHIN_KUBUN() As Nullable(Of Integer)
        Get
            Return mFSEIHIN_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFSEIHIN_KUBUN = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>�݌ɋ敪</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FZAIKO_KUBUN() As Nullable(Of Integer)
        Get
            Return mFZAIKO_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFZAIKO_KUBUN = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>�ۗ��敪</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FHORYU_KUBUN() As Nullable(Of Integer)
        Get
            Return mFHORYU_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFHORYU_KUBUN = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>������گĐ�����</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property INTMaxPlt() As Nullable(Of Integer)
        Get
            Return mINTMaxPlt
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mINTMaxPlt = Value
        End Set
    End Property
    ''' =======================================
    ''' <summary>�����ς���گ�(��گ�ID)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property strArrayPALLET_ID() As String()
        Get
            Return mstrArrayPALLET_ID
        End Get
    End Property
    ''' =======================================
    ''' <summary>�����ς���گ�(����������)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property FTR_RES_VOL(ByVal decIndex As Decimal) As Nullable(Of Decimal)
        Get
            Return mFTR_RES_VOL(decIndex)
        End Get
    End Property

    '������������************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/04/27  �I�`���ʂ�ǉ�
    ''' =======================================
    ''' <summary>�I�`����</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FRAC_FORM() As String
        Get
            Return mFRAC_FORM
        End Get
        Set(ByVal Value As String)
            mFRAC_FORM = Value
        End Set
    End Property
    '������������************************************************************************************************************

    '������������************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/04/25  ���������ɍ݌�ۯć���ǉ�
    ''' =======================================
    ''' <summary>�����ς���گ�(�݌�ۯć�)</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public ReadOnly Property strArrayFLOT_NO_STOCK() As String()
        Get
            Return mstrArrayFLOT_NO_STOCK
        End Get
    End Property
    '������������************************************************************************************************************

    '������������************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/04/27  OrderBy�𐧌�
    ''' =======================================
    ''' <summary>OrderBy�𐧌�</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property strOrderBy() As String
        Get
            Return mstrOrderBy
        End Get
        Set(ByVal Value As String)
            mstrOrderBy = Value
        End Set
    End Property
    '������������************************************************************************************************************

    '������������************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/10/20  �݌Ɉ����ɁA���ޱ�̐ؗ����������ɒǉ��B�ؗ�������Ă�����A�݌Ɉ����̑ΏۂƂ��Ȃ��B
    ''' =======================================
    ''' <summary>�������ׯ�ݸ��ޯ̧��</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FBUF_TO() As Nullable(Of Integer)
        Get
            Return mFBUF_TO
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFBUF_TO = Value
        End Set
    End Property
    '������������************************************************************************************************************

    '������������************************************************************************************************************
    'SystemMate:N.Dounoshita 2013/06/05  �[������
    ''' =======================================
    ''' <summary>�[��Ӱ��</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property intHasu() As HasuMode
        Get
            Return mintHasu
        End Get
        Set(ByVal Value As HasuMode)
            mintHasu = Value
        End Set
    End Property
    '������������************************************************************************************************************

    '������������************************************************************************************************************
    'SystemMate:N.Dounoshita 2013/06/07  ���ɋ敪
    ''' =======================================
    ''' <summary>���ɋ敪</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property FIN_KUBUN() As String
        Get
            Return mFIN_KUBUN
        End Get
        Set(ByVal Value As String)
            mFIN_KUBUN = Value
        End Set
    End Property
    '������������************************************************************************************************************

    '������������************************************************************************************************************
    'JobMate:N.Dounoshita 2013/06/20 �I��ۯ��ǉ�
    ''' =======================================
    ''' <summary>�I��ۯ�</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property intAryXTANA_BLOCK() As Nullable(Of Integer)()
        Get
            Return mintAryXTANA_BLOCK
        End Get
        Set(ByVal Value As Nullable(Of Integer)())
            mintAryXTANA_BLOCK = Value
        End Set
    End Property
    '������������************************************************************************************************************

    '������������************************************************************************************************************
    'JobMate:N.Dounoshita 2013/06/20 �ۗ��敪�A�����敪�A���i�敪��ǉ�

    ''' =======================================
    ''' <summary>�����敪</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property XKENSA_KUBUN() As Nullable(Of Integer)
        Get
            Return mXKENSA_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXKENSA_KUBUN = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>���i�敪</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property XKENPIN_KUBUN() As Nullable(Of Integer)
        Get
            Return mXKENPIN_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXKENPIN_KUBUN = Value
        End Set
    End Property

    ''' =======================================
    ''' <summary>Ұ�-����</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property XMAKER_CD() As String
        Get
            Return mXMAKER_CD
        End Get
        Set(ByVal Value As String)
            mXMAKER_CD = Value
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
#Region "�@�۰�ޏ���                                                                            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �۰�ޏ���
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub Close()
        Try
            '�e�׽�̺ݽ�׸������s
            MyBase.Close()

        Catch ex As Exception
            ComError(ex)
            Throw New System.Exception(ex.Message)
        End Try
    End Sub
#End Region
#Region "�@�݌Ɉ�������                                                                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �݌Ɉ�������
    ''' </summary>
    ''' <param name="decReqNum">�����v����</param>
    ''' <returns>0:OK 1:NG 2:NotFound</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function FIND_STOCK(ByVal decReqNum As Decimal) As RetCode
        Try
            Dim strMsg As String                    'ү����
            Dim intRet As RetCode                   '�߂�l


            '************************
            '�����è����
            '************************
            If decReqNum < 0 Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�����v����]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFTRK_BUF_NO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�ׯ�ݸ��ޯ̧No]"
                Throw New UserException(strMsg)
            End If


            '************************
            '�L���݌ɐ�����
            '************************
            intRet = CheckStock()
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                Return RetCode.NotFound
            ElseIf intRet = RetCode.NG Then
                '(���̑�NG�̏ꍇ)
                Return RetCode.NG
            End If


            '************************
            '�݌Ɋm��
            '************************
            intRet = ReserveStock(decReqNum)
            If intRet = RetCode.NotEnough Then
                '(�s�����Ă���ꍇ)
                Return RetCode.NotEnough
            ElseIf intRet = RetCode.NG Then
                '(���̑�NG�̏ꍇ)
                Return RetCode.NG
            End If


            Return RetCode.OK
        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New System.Exception(ex.Message)
        End Try
    End Function
#End Region
#Region "  �L���݌ɐ�����                                                                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �L���݌ɐ�����
    ''' </summary>
    ''' <returns>0:OK 1:NG 2:NotFound</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function CheckStock() As RetCode
        Try
            Dim objDataSet As New DataSet               '�ް����
            Try
                Dim strSQL As String                    'SQL��


                '************************
                'SQL������
                '************************
                strSQL = MakeSQL(CHK_PROC)


                '************************
                '���o
                '************************
                objDataSet.Clear()
                ObjDb.SQL = strSQL
                ObjDb.GetDataSet("TRST_STOCK", objDataSet)


                '************************
                '�L���݌ɐ�����
                '************************
                If TO_DECIMAL_NULLABLE(objDataSet.Tables("TRST_STOCK").Rows(0).Item("FTR_VOL")) - _
                   TO_DECIMAL_NULLABLE(objDataSet.Tables("TRST_STOCK").Rows(0).Item("FTR_RES_VOL")) > 0 Then

                    '(�����Ǘ���-����������>0�̏ꍇ)
                    Return RetCode.OK
                Else
                    Return RetCode.NotFound
                End If


            Catch ex As UserException
                Throw ex
            Catch ex As Exception
                Throw New System.Exception(ex.Message)
            Finally
                objDataSet.Dispose()
                objDataSet = Nothing
            End Try
        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New System.Exception(ex.Message)
        End Try
    End Function
#End Region
#Region "  �݌Ɋm�ۏ���                                                                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �݌Ɋm�ۏ���
    ''' </summary>
    ''' <param name="decReqNum">�����v����</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function ReserveStock(ByVal decReqNum As Decimal) As Integer
        Try
            Dim objDataSet As New DataSet               '�ް����
            Try
                Dim strMsg As String                    'ү����
                Dim intRet As RetCode                   '�߂�l
                Dim strSQL As String                    'SQL��
                Dim oRow As DataRow                     '1ں��ޕ����ް�
                Dim decRsv As Decimal = 0               '�����ςݐ�
                Dim intPlt As Integer = 0               '�����ς���گĐ�


                '************************
                'SQL������
                '************************
                strSQL = MakeSQL(RSV_PROC)


                '************************
                '���o
                '************************
                objDataSet.Clear()
                ObjDb.SQL = strSQL
                ObjDb.GetDataSet("TRST_STOCK", objDataSet)


                '************************
                '��گ�ID�z���������
                '************************
                mstrArrayPALLET_ID = Nothing


                '������������************************************************************************************************************
                'SystemMate:N.Dounoshita 2012/10/20  �݌Ɉ����ɁA���ޱ�̐ؗ����������ɒǉ��B�ؗ�������Ă�����A�݌Ɉ����̑ΏۂƂ��Ȃ��B

                Dim blnGetPallet As Boolean = False      '�݌Ɏ擾�׸�

                '������������************************************************************************************************************


                If objDataSet.Tables("TRST_STOCK").Rows.Count > 0 Then
                    For Each oRow In objDataSet.Tables("TRST_STOCK").Rows


                        '������������************************************************************************************************************
                        'SystemMate:N.Dounoshita 2012/10/20  �݌Ɉ����ɁA���ޱ�̐ؗ����������ɒǉ��B�ؗ�������Ă�����A�݌Ɉ����̑ΏۂƂ��Ȃ��B


                        '************************************************
                        '���ޱ�ؗ�����
                        '************************************************
                        Dim blnEQCut As Boolean     '�ؗ��׸�
                        blnEQCut = SVR_100202_CheckTMST_CNV_CRANE(TO_STRING(oRow.Item("FPALLET_ID")), mFTRK_BUF_NO, mFBUF_TO)
                        If blnEQCut = True Then
                            '(�ؗ����̏ꍇ)
                            Continue For
                        End If
                        blnGetPallet = True


                        '������������************************************************************************************************************


                        If mINTUpdateMode = UpdateMode.CHANGE_ALL Then
                            Dim intRetSQL As Integer    'SQL���s�߂�l

                            strSQL = ""
                            strSQL &= vbCrLf & "UPDATE"
                            strSQL &= vbCrLf & "    TPRG_TRK_BUF"
                            strSQL &= vbCrLf & " SET"
                            strSQL &= vbCrLf & "    FRES_KIND = '" & TO_STRING(FRES_KIND_SRSV_TRNS_OUT) & "'"
                            strSQL &= vbCrLf & " WHERE"
                            strSQL &= vbCrLf & "        FPALLET_ID = '" & TO_STRING(oRow.Item("FPALLET_ID")) & "'"
                            strSQL &= vbCrLf & "    AND FTRK_BUF_NO = " & TO_STRING(mFTRK_BUF_NO)
                            strSQL &= vbCrLf
                            intRetSQL = ObjDb.Execute(strSQL)
                            If intRetSQL = -1 Then
                                '(SQL�װ)
                                strSQL = Replace(strSQL, vbCrLf, "")
                                strMsg = ERRMSG_ERR_UPDATE & ObjDb.ErrMsg & "�y" & strSQL & "�z"
                                Throw New UserException(strMsg)
                            End If
                            If intRetSQL < 1 Then
                                strMsg = ERRMSG_NOTFOUND_TPRG_TRK & "[�ޯ̧��:" & TO_STRING(mFTRK_BUF_NO) & "  ,��گ�ID:" & TO_STRING(oRow.Item("FPALLET_ID")) & "]"
                                Throw New UserException(strMsg)
                            End If

                        End If


                        '************************
                        '�݌ɏ��̓���
                        '************************
                        Dim decNowRsv As Decimal                                            '����������ė�
                        Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)     '�݌ɏ��׽
                        objTRST_STOCK.FPALLET_ID = TO_STRING(oRow.Item("FPALLET_ID"))       '��گ�ID
                        objTRST_STOCK.FLOT_NO_STOCK = TO_STRING(oRow.Item("FLOT_NO_STOCK")) '�݌�ۯ�No
                        intRet = objTRST_STOCK.GET_TRST_STOCK(True)                         '����


                        '************************
                        '�݌ɏ��̍X�V
                        '************************
                        If decReqNum = 0 Then
                            '(��������ʂ��w�薳���̏ꍇ)
                            '�����Ă��������Ǘ��ʂ��s���ŁA����1��گĂ̑S�Ă̔����Ǘ��ʂ������Ă������ꍇ�Ɏg�p
                            decNowRsv = TO_NUMBER(objTRST_STOCK.FTR_VOL) - TO_NUMBER(objTRST_STOCK.FTR_RES_VOL)         '����������ė�
                            decRsv += decNowRsv                                                                         '�����ςݐ�����
                            objTRST_STOCK.FTR_RES_VOL = objTRST_STOCK.FTR_VOL                                           '���������ʂ�ݒ�
                        Else
                            '(��������ʂ��w�肠��̏ꍇ)
                            '�����Ă��������Ǘ��ʂ����m�ȏꍇ�Ɏg�p
                            If (TO_NUMBER(objTRST_STOCK.FTR_VOL) - TO_NUMBER(objTRST_STOCK.FTR_RES_VOL)) > (decReqNum - decRsv) And mBLNFullVol_Check = False Then
                                '(�����Ǘ��� > ���������� �ɂȂ�ꍇ�A�������� �����Ǘ��� > ���������� �ɂ������ꍇ)
                                objTRST_STOCK.FTR_RES_VOL = TO_NUMBER(objTRST_STOCK.FTR_RES_VOL) + (decReqNum - decRsv)               '���������ʂ�ݒ�
                                decNowRsv = decReqNum - decRsv                                  '����������ė�
                                decRsv += decNowRsv                                             '�����ςݐ�����
                            Else
                                '(�����Ǘ��� = ���������� �ɂȂ�ꍇ�A�������� �����Ǘ��� = ���������� �ɂ������ꍇ)
                                decNowRsv = TO_NUMBER(objTRST_STOCK.FTR_VOL) - TO_NUMBER(objTRST_STOCK.FTR_RES_VOL)     '����������ė�
                                decRsv += TO_NUMBER(objTRST_STOCK.FTR_VOL) - TO_NUMBER(objTRST_STOCK.FTR_RES_VOL)       '�����ςݐ�����
                                objTRST_STOCK.FTR_RES_VOL = objTRST_STOCK.FTR_VOL               '���������ʂ�ݒ�
                            End If
                        End If
                        If mINTUpdateMode = UpdateMode.CHANGE_ALL Or mINTUpdateMode = UpdateMode.STOCK_ONLY Then
                            '(�X�VӰ�ނ��S�X�V/�݌ɍX�V�̏ꍇ)
                            objTRST_STOCK.UPDATE_TRST_STOCK()
                        End If


                        '************************
                        '�����ς���گĐ�����
                        '************************
                        intPlt += 1


                        '************************
                        '�������ꂽ��گ�ID�ێ�
                        '************************
                        intRet = ArrayFindData(mstrArrayPALLET_ID, TO_STRING(oRow.Item("FPALLET_ID")))
                        If intRet = -1 Then
                            '(��گ�ID��������Ȃ������ꍇ)
                            If IsNull(mstrArrayPALLET_ID) Then
                                ReDim mstrArrayPALLET_ID(0)
                            Else
                                ReDim Preserve mstrArrayPALLET_ID(UBound(mstrArrayPALLET_ID) + 1)
                            End If
                            mstrArrayPALLET_ID(UBound(mstrArrayPALLET_ID)) = TO_STRING(oRow.Item("FPALLET_ID"))
                        End If


                        '************************
                        '�������ꂽ�����Ǘ��ʕێ�
                        '************************
                        Dim intIndex As Integer = UBound(mstrArrayPALLET_ID)
                        ReDim Preserve mFTR_RES_VOL(intIndex)
                        mFTR_RES_VOL(intIndex) = decNowRsv


                        '������������************************************************************************************************************
                        'SystemMate:N.Dounoshita 2012/04/25  ���������ɍ݌�ۯć���ǉ�

                        '************************
                        '�������ꂽ�݌�ۯć��ێ�
                        '************************
                        ReDim Preserve mstrArrayFLOT_NO_STOCK(intIndex)
                        mstrArrayFLOT_NO_STOCK(intIndex) = TO_STRING(oRow.Item("FLOT_NO_STOCK"))

                        '������������************************************************************************************************************


                        '������������************************************************************************************************************
                        'JobMate:N.Dounoshita 2013/06/20 �I��ۯ��ǉ�

                        '************************
                        '�������ꂽ�I��ۯ��ێ�
                        '************************
                        ReDim Preserve mintAryXTANA_BLOCK(intIndex)
                        mintAryXTANA_BLOCK(intIndex) = TO_STRING(oRow.Item("XTANA_BLOCK"))

                        '������������************************************************************************************************************


                        '************************
                        '������گĐ���������
                        '************************
                        If decReqNum > 0 Then
                            If TO_INTEGER(mINTMaxPlt) > 0 Then
                                If TO_INTEGER(mINTMaxPlt) <= intPlt Then
                                    Exit For
                                End If
                            End If
                        End If


                        '************************
                        '�v��������
                        '************************
                        If decReqNum > 0 Then
                            If decReqNum <= decRsv Then
                                Exit For
                            End If
                        End If
                    Next

                    '************************
                    '�v��������
                    '************************
                    '������������************************************************************************************************************
                    'SystemMate:N.Dounoshita 2012/10/20  �݌Ɉ����ɁA���ޱ�̐ؗ����������ɒǉ��B�ؗ�������Ă�����A�݌Ɉ����̑ΏۂƂ��Ȃ��B
                    If blnGetPallet = True Then
                        '(�݌Ɏ擾���Ă����ꍇ)
                        '������������************************************************************************************************************

                        If decReqNum = 0 Then
                            Return RetCode.OK
                        Else
                            If TO_INTEGER(mINTMaxPlt) > 0 And TO_INTEGER(mINTMaxPlt) <= intPlt Then
                                Return RetCode.OK
                            Else
                                If decReqNum <= decRsv Then
                                    Return RetCode.OK
                                Else
                                    Return RetCode.NotEnough
                                End If
                            End If
                        End If

                        '������������************************************************************************************************************
                        'SystemMate:N.Dounoshita 2012/10/20  �݌Ɉ����ɁA���ޱ�̐ؗ����������ɒǉ��B�ؗ�������Ă�����A�݌Ɉ����̑ΏۂƂ��Ȃ��B
                    Else
                        '(�݌Ɏ擾���Ă��Ȃ��ꍇ)
                        Return RetCode.NotEnough
                    End If
                    '������������************************************************************************************************************

                Else
                    Throw New System.Exception(ERRMSG_NOTFOUND_TRST_STOCK & "�y" & strSQL & "�z")
                End If


                Return RetCode.NotFound
            Catch ex As UserException
                Call ComUser(ex, MeSyoriID)
                Throw ex
            Catch ex As Exception
                Call ComError(ex, MeSyoriID)
                Throw New System.Exception(ex.Message)
            Finally
                objDataSet.Dispose()
                objDataSet = Nothing
            End Try
        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            ComError(ex, MeSyoriID)
            Throw New System.Exception(ex.Message)
        End Try
    End Function
#End Region
#Region "�@�݌Ɉ���SQL������                                                                    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �݌Ɉ���SQL������
    ''' </summary>
    ''' <param name="intProcKubun">1:�L���݌ɐ����� 2:�݌Ɋm�ۏ���</param>
    ''' <returns>SQL��</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function MakeSQL(ByVal intProcKubun As Integer) As String
        Try
            Dim intRet As Integer = 0
            Dim objDataSet As New DataSet               '�ް����
            Try
                Dim strSQL As String = ""               'SQL��


                '************************
                'SQL������
                '************************
                strSQL = ""
                strSQL &= vbCrLf & "SELECT "
                If intProcKubun = CHK_PROC Then
                    '(�L���݌ɐ������̏ꍇ)
                    strSQL &= vbCrLf & "   SUM(FTR_VOL) AS FTR_VOL "                           '�����Ǘ���(���݌ɐ�)
                    strSQL &= vbCrLf & "  ,SUM(FTR_RES_VOL) AS FTR_RES_VOL "                   '����������(�������ςݐ�)
                ElseIf intProcKubun = RSV_PROC Then
                    '(�݌Ɋm�ۏ����̏ꍇ)
                    strSQL &= vbCrLf & "   FTR_VOL "                                           '�����Ǘ���
                    strSQL &= vbCrLf & "  ,FPALLET_ID "                                        '��گ�ID
                    strSQL &= vbCrLf & "  ,FLOT_NO_STOCK "                                     '�݌�ۯć�
                    strSQL &= vbCrLf & "  ,FARRIVE_DT AS FARRIVE_DT"                           '�݌ɔ�������
                    '������������************************************************************************************************************
                    'SystemMate:N.Dounoshita 2012/04/27  OrderBy�𐧌�
                    strSQL &= vbCrLf & "  ,FSERCH_NO "                                          '�󌟍�����
                    strSQL &= vbCrLf & "  ,FRAC_FORM "                                          '�I�`����
                    '������������************************************************************************************************************
                    '������������************************************************************************************************************
                    'JobMate:N.Dounoshita 2013/06/20 �I��ۯ��ǉ�
                    strSQL &= vbCrLf & "  ,XTANA_BLOCK "                                        '�I��ۯ�
                    '������������************************************************************************************************************
                End If
                strSQL &= vbCrLf & "FROM "
                strSQL &= vbCrLf & "( "
                strSQL &= vbCrLf & "    SELECT B.FTRK_BUF_ARRAY AS FTRK_BUF_ARRAY "             '�ׯ�ݸ��ޯ̧�z��No
                strSQL &= vbCrLf & "          ,B.FPALLET_ID AS FPALLET_ID "                     '��گ�ID
                strSQL &= vbCrLf & "          ,A.FLOT_NO_STOCK AS FLOT_NO_STOCK "               '�݌�ۯć�
                strSQL &= vbCrLf & "          ,A.FHINMEI_CD AS FHINMEI_CD "                     '�i������
                strSQL &= vbCrLf & "          ,A.FLOT_NO AS FLOT_NO "                           'ۯć�
                strSQL &= vbCrLf & "          ,A.FTR_VOL AS FTR_VOL "                           '�����Ǘ���
                strSQL &= vbCrLf & "          ,A.FTR_RES_VOL AS FTR_RES_VOL "                   '����������
                strSQL &= vbCrLf & "          ,A.FARRIVE_DT AS FARRIVE_DT "                     '�݌ɔ�������
                '������������************************************************************************************************************
                'SystemMate:N.Dounoshita 2012/04/27  OrderBy�𐧌�
                strSQL &= vbCrLf & "          ,B.FSERCH_NO AS FSERCH_NO "                       '�󌟍�����
                strSQL &= vbCrLf & "          ,B.FRAC_FORM AS FRAC_FORM "                       '�I�`����
                '������������************************************************************************************************************
                '������������************************************************************************************************************
                'JobMate:N.Dounoshita 2013/06/20 �I��ۯ��ǉ�
                strSQL &= vbCrLf & "          ,B.XTANA_BLOCK AS XTANA_BLOCK "                   '�I��ۯ�
                '������������************************************************************************************************************
                strSQL &= vbCrLf & "    FROM TRST_STOCK A "
                strSQL &= vbCrLf & "        ,TPRG_TRK_BUF B"
                strSQL &= vbCrLf & "        ,TMST_CRANE E "
                strSQL &= vbCrLf & "        ,TSTS_EQ_CTRL F "
                '������������************************************************************************************************************
                'SystemMate:N.Dounoshita 2013/06/05  �[������
                If mintHasu = HasuMode.FullPL Or mintHasu = HasuMode.HasuPL Then
                    strSQL &= vbCrLf & "        ,TMST_ITEM G "
                End If
                '������������************************************************************************************************************

                strSQL &= vbCrLf & "	WHERE "
                strSQL &= vbCrLf & "	      A.FPALLET_ID = B.FPALLET_ID"                      '��������

                strSQL &= vbCrLf & "	  AND E.FEQ_ID     = F.FEQ_ID"                          '��������

                strSQL &= vbCrLf & "	  AND E.FCRANE_ROW1 <= B.FRAC_RETU "                    '��������
                strSQL &= vbCrLf & "	  AND B.FRAC_RETU   <= E.FCRANE_ROW2 "                  '��������


                strSQL &= vbCrLf & "	  AND B.FTRK_BUF_NO = " & Trim(Str(mFTRK_BUF_NO))       '�ׯ�ݸ��ޯ̧��
                strSQL &= vbCrLf & "	  AND B.FREMOVE_KIND = " & Trim(Str(FLAG_OFF))          '�֎~�L��
                strSQL &= vbCrLf & "	  AND B.FRES_KIND = " & Trim(Str(FRES_KIND_SZAIKO))     '�݌Ɉ������
                strSQL &= vbCrLf & "	  AND A.FTR_VOL > A.FTR_RES_VOL"                    '�L���݌ɐ�����
                strSQL &= vbCrLf & "	  AND E.FTRK_BUF_NO = " & Trim(Str(mFTRK_BUF_NO))
                strSQL &= vbCrLf & "	  AND F.FEQ_CUT_STS = " & Trim(Str(FLAG_OFF))
                '������������************************************************************************************************************
                'SystemMate:N.Dounoshita 2013/06/05  �[������
                If mintHasu = HasuMode.FullPL Or mintHasu = HasuMode.HasuPL Then
                    strSQL &= vbCrLf & "	  AND A.FHINMEI_CD = G.FHINMEI_CD "                 '�i������
                    If mintHasu = HasuMode.FullPL Then
                        strSQL &= vbCrLf & "	  AND A.FTR_VOL = G.FNUM_IN_PALLET "            'PL���ύڐ�
                    Else
                        strSQL &= vbCrLf & "	  AND A.FTR_VOL <> G.FNUM_IN_PALLET "           'PL���ύڐ�
                    End If
                End If
                '������������************************************************************************************************************
                If mFEQ_ID_CRN <> "" Then
                    '(�ڰݎw�肪����ꍇ)
                    strSQL &= vbCrLf & "	  AND E.FEQ_ID = '" & mFEQ_ID_CRN & "'"
                End If

                '========================
                '��߼�ݏ����w��
                '========================
                If mFPALLET_ID <> DEFAULT_STRING Then
                    '(��گ�ID�w��L��̏ꍇ)
                    strSQL &= vbCrLf & "      AND A.FPALLET_ID = '" & mFPALLET_ID & "'"                 '��گ�ID
                End If

                '������������************************************************************************************************************
                'SystemMate:N.Dounoshita 2012/04/27  �I�`���ʂ�ǉ�
                If IsNotNull(mFRAC_FORM) Then
                    '(�I�`���ʎw��L��̏ꍇ)
                    strSQL &= vbCrLf & "      AND B.FRAC_FORM = " & mFRAC_FORM                      '�I�`����
                End If
                '������������************************************************************************************************************

                '������������************************************************************************************************************
                'SystemMate:N.Dounoshita 2013/06/07  ���ɋ敪
                If IsNotNull(mFIN_KUBUN) Then
                    '(���ɋ敪�w��L��̏ꍇ)
                    strSQL &= vbCrLf & "      AND A.FIN_KUBUN IN (" & mFIN_KUBUN & ")"              '���ɋ敪
                End If
                '������������************************************************************************************************************

                '������������************************************************************************************************************
                'SystemMate:N.Dounoshita 2012/04/25  ���������ɍ݌�ۯć���ǉ�
                If mFLOT_NO_STOCK <> DEFAULT_STRING Then
                    '(�݌�ۯć��w��L��̏ꍇ)
                    strSQL &= vbCrLf & "      AND A.FLOT_NO_STOCK = '" & mFLOT_NO_STOCK & "'"           '�݌�ۯć�
                End If
                '������������************************************************************************************************************
                If mFHINMEI_CD <> DEFAULT_STRING Then
                    '(�i�����ގw��L��̏ꍇ)
                    strSQL &= vbCrLf & "      AND A.FHINMEI_CD = '" & mFHINMEI_CD & "'"                 '�i������
                End If
                If mFLOT_NO <> DEFAULT_STRING Then
                    '(ۯć��w��L��̏ꍇ)
                    strSQL &= vbCrLf & "      AND A.FLOT_NO = '" & mFLOT_NO & "'"                       'ۯć�
                End If
                If IsNull(mFSEIHIN_KUBUN) = False Then
                    '(���i�敪�w��L��̏ꍇ)
                    strSQL &= vbCrLf & "      AND A.FSEIHIN_KUBUN = " & Trim(Str(mFSEIHIN_KUBUN))       '���i�敪
                End If
                If IsNull(mFZAIKO_KUBUN) = False Then
                    '(�݌ɋ敪�w��L��̏ꍇ)
                    strSQL &= vbCrLf & "      AND A.FZAIKO_KUBUN = " & Trim(Str(mFZAIKO_KUBUN))         '�݌ɋ敪
                End If

                If IsNull(mFHORYU_KUBUN) = False Then
                    '(�ۗ��敪�w��L��̏ꍇ)
                    strSQL &= vbCrLf & "      AND A.FHORYU_KUBUN = " & Trim(Str(mFHORYU_KUBUN))         '�ۗ��敪
                End If

                '������������************************************************************************************************************
                'JobMate:N.Dounoshita 2013/06/20 �����敪�A���i�敪��ǉ�

                If IsNull(mXKENSA_KUBUN) = False Then
                    '(�����敪�w��L��̏ꍇ)
                    strSQL &= vbCrLf & "      AND A.XKENSA_KUBUN = " & Trim(Str(mXKENSA_KUBUN))         '�����敪
                End If

                If IsNull(mXKENPIN_KUBUN) = False Then
                    '(���i�敪�w��L��̏ꍇ)
                    strSQL &= vbCrLf & "      AND A.XKENPIN_KUBUN = " & Trim(Str(mXKENPIN_KUBUN))       '���i�敪
                End If

                If IsNull(mXMAKER_CD) = False Then
                    '(���i�敪�w��L��̏ꍇ)
                    strSQL &= vbCrLf & "      AND A.XMAKER_CD = '" & (mXMAKER_CD) & "'"                 'Ұ�-����
                End If

                '������������************************************************************************************************************


                strSQL &= vbCrLf & ") HIKI"
                '========================
                '�D�揇�w��
                '========================
                '������������************************************************************************************************************
                'SystemMate:N.Dounoshita 2012/04/27  OrderBy�𐧌�
                If IsNull(mstrOrderBy) Then
                    '(�����è����Ă���Ă��Ȃ��ꍇ)
                    '������������************************************************************************************************************

                    If intProcKubun = RSV_PROC Then
                        '(�݌Ɋm�ۏ����̏ꍇ)

                        '������������************************************************************************************************************
                        'JobMate:N.Dounoshita 2013/06/12 ���ёւ�

                        strSQL &= vbCrLf & "    ORDER BY FLOT_NO "                  'ۯć�
                        strSQL &= vbCrLf & "           , FARRIVE_DT "               '�݌ɔ�������
                        strSQL &= vbCrLf & "           , FTR_VOL"                   '�����Ǘ���

                        'strSQL &= vbCrLf & "    ORDER BY FARRIVE_DT "                                   '�݌ɔ�������
                        'strSQL &= vbCrLf & "           , FTR_VOL"                                       '�����Ǘ���

                        '������������************************************************************************************************************

                    End If

                    '������������************************************************************************************************************
                    'SystemMate:N.Dounoshita 2012/04/27  OrderBy�𐧌�
                Else
                    '(�����è����Ă���Ă���ꍇ)

                    If intProcKubun = RSV_PROC Then
                        '(�݌Ɋm�ۏ����̏ꍇ)

                        strSQL &= vbCrLf & "    ORDER BY "
                        strSQL &= vbCrLf & "    " & mstrOrderBy

                    End If

                End If
                strSQL &= vbCrLf
                '������������************************************************************************************************************



                Return strSQL


            Catch ex As UserException
                Call ComUser(ex, MeSyoriID)
                Throw ex
            Catch ex As Exception
                ComError(ex, MeSyoriID)
                Throw New System.Exception(ex.Message)
            Finally
                objDataSet.Dispose()
                objDataSet = Nothing
            End Try
        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            ComError(ex, MeSyoriID)
            Throw New System.Exception(ex.Message)
        End Try
    End Function
#End Region

    '�֗��@�\
#Region "  �L���݌ɐ������i�݌ɐ��擾�j                                                                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �L���݌ɐ������i�݌ɐ��擾�j
    ''' </summary>
    ''' <returns>�݌ɐ�</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function CheckStockVol() As Decimal
        Try
            Dim objDataSet As New DataSet               '�ް����
            Try
                Dim strSQL As String                    'SQL��


                '************************
                'SQL������
                '************************
                strSQL = MakeSQL(CHK_PROC)


                '************************
                '���o
                '************************
                objDataSet.Clear()
                ObjDb.SQL = strSQL
                ObjDb.GetDataSet("TRST_STOCK", objDataSet)


                '************************
                '�L���݌ɐ�����
                '************************
                Dim intVol As Decimal = 0

                intVol = TO_DECIMAL(objDataSet.Tables("TRST_STOCK").Rows(0).Item("FTR_VOL")) - _
                   TO_DECIMAL(objDataSet.Tables("TRST_STOCK").Rows(0).Item("FTR_RES_VOL"))

                Return intVol

            Catch ex As UserException
                Throw ex
            Catch ex As Exception
                Throw New System.Exception(ex.Message)
            Finally
                objDataSet.Dispose()
                objDataSet = Nothing
            End Try
        Catch ex As UserException
            Call ComUser(ex, MeSyoriID)
            Throw ex
        Catch ex As Exception
            Call ComError(ex, MeSyoriID)
            Throw New System.Exception(ex.Message)
        End Try
    End Function
#End Region


    '**********************************************************************************************
    '���������ьŗL

    '���������ьŗL
    '**********************************************************************************************

End Class
