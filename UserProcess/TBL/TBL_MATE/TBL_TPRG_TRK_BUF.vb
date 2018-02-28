'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' �y���́zMaterialStreamð��ٸ׽
' �y�@�\�z�ׯ�ݸ��ޯ̧ð��ٸ׽
' �y�쐬�z2010/03/02  SIT                                   Rev 0.00
'**********************************************************************************************

#Region "  Imports"
Imports System
Imports System.Text
Imports MateCommon
Imports MateCommon.clsConst
Imports JobCommon
#End Region

''' <summary>
''' �ׯ�ݸ��ޯ̧ð��ٸ׽
''' </summary>
Public Class TBL_TPRG_TRK_BUF
    Inherits clsTemplateTable

    '**********************************************************************************************
    '����������������
#Region "  �׽�ϐ���`                  "
    '�����è
    Private mobjAryMe As TBL_TPRG_TRK_BUF()                                      '�ׯ�ݸ��ޯ̧
    Private mstrUSER_SQL As String                                               'հ�ްSQL
    Private mORDER_BY As String                                                  'OrderBy��
    Private mWHERE As String                                                     'Where��
    Private mFTRK_BUF_NO As Nullable(Of Integer)                                 '�ׯ�ݸ��ޯ̧��
    Private mFTRK_BUF_ARRAY As Nullable(Of Integer)                              '�ׯ�ݸ��ޯ̧�z��
    Private mFSERCH_NO As Nullable(Of Integer)                                   '�󌟍�����
    Private mFTRNS_ADDRESS As String                                             '�����w���p���ڽ
    Private mFDISP_ADDRESS As String                                             '�\�L�p���ڽ
    Private mFRAC_RETU As Nullable(Of Integer)                                   '��
    Private mFRAC_REN As Nullable(Of Integer)                                    '�A
    Private mFRAC_DAN As Nullable(Of Integer)                                    '�i
    Private mFRAC_EDA As Nullable(Of Integer)                                    '�}
    Private mFREMOVE_KIND As Nullable(Of Integer)                                '�֎~�L��
    Private mFRAC_FORM As Nullable(Of Integer)                                   '�I�`����
    Private mFRES_KIND As Nullable(Of Integer)                                   '�������
    Private mFRSV_PALLET As String                                               '��������گ�ID
    Private mFTR_FM As Nullable(Of Integer)                                      '����FM�ׯ�ݸ��ޯ̧��
    Private mFTR_TO As Nullable(Of Integer)                                      '����TO�ׯ�ݸ��ޯ̧��
    Private mFTR_IDOU As Nullable(Of Integer)                                    '����TO�ړ��ׯ�ݸ��ޯ̧��
    Private mFTRNS_FM As String                                                  '�����w�ߗpFM
    Private mFTRNS_TO As String                                                  '�����w�ߗpTO
    Private mFRSV_BUF_FM As Nullable(Of Integer)                                 'FM�����ׯ�ݸ��ޯ̧��
    Private mFRSV_ARRAY_FM As Nullable(Of Integer)                               'FM�����ׯ�ݸ��ޯ̧�z��
    Private mFRSV_BUF_TO As Nullable(Of Integer)                                 'TO�����ׯ�ݸ��ޯ̧��
    Private mFRSV_ARRAY_TO As Nullable(Of Integer)                               'TO�����ׯ�ݸ��ޯ̧�z��
    Private mFDISP_ADDRESS_FM As String                                          'FM�\�L�p���ڽ
    Private mFDISP_ADDRESS_TO As String                                          'TO�\�L�p���ڽ
    Private mFDISPLOG_ADDRESS_FM As String                                       'FM�\�L�p���ڽ_۸ޗp
    Private mFDISPLOG_ADDRESS_TO As String                                       'TO�\�L�p���ڽ_۸ޗp
    Private mFPALLET_ID As String                                                '��گ�ID
    Private mFBUF_IN_DT As Nullable(Of Date)                                     '�ޯ̧������
    Private mFRAC_BUNRUI As String                                               '�I����
    Private mXTANA_BLOCK As Nullable(Of Integer)                                 '�I��ۯ�
    Private mXTANA_BLOCK_DTL As Nullable(Of Integer)                             '�I��ۯ��ڍ�
    Private mXTANA_BLOCK_STS As Nullable(Of Integer)                             '�I��ۯ����
#End Region
#Region "  �����è��`                  "
    ''' <summary>
    ''' ���ѕϐ� (���׽�^�z��)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_TPRG_TRK_BUF()
        Get
            Return mobjAryMe
        End Get
    End Property
    ''' <summary>
    ''' հ�ްSQL (�����^)
    ''' </summary>
    Public WriteOnly Property USER_SQL() As String
        Set(ByVal Value As String)
            mstrUSER_SQL = Value
        End Set
    End Property
    ''' <summary>
    ''' OrderBy��
    ''' </summary>
    Public Property ORDER_BY() As String
        Get
            Return mORDER_BY
        End Get
        Set(ByVal Value As String)
            mORDER_BY = Value
        End Set
    End Property
    ''' <summary>
    ''' Where��
    ''' </summary>
    Public Property WHERE() As String
        Get
            Return mWHERE
        End Get
        Set(ByVal Value As String)
            mWHERE = Value
        End Set
    End Property
    ''' <summary>
    ''' �ׯ�ݸ��ޯ̧��
    ''' </summary>
    Public Property FTRK_BUF_NO() As Nullable(Of Integer)
        Get
            Return mFTRK_BUF_NO
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFTRK_BUF_NO = Value
        End Set
    End Property
    ''' <summary>
    ''' �ׯ�ݸ��ޯ̧�z��
    ''' </summary>
    Public Property FTRK_BUF_ARRAY() As Nullable(Of Integer)
        Get
            Return mFTRK_BUF_ARRAY
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFTRK_BUF_ARRAY = Value
        End Set
    End Property
    ''' <summary>
    ''' �󌟍�����
    ''' </summary>
    Public Property FSERCH_NO() As Nullable(Of Integer)
        Get
            Return mFSERCH_NO
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFSERCH_NO = Value
        End Set
    End Property
    ''' <summary>
    ''' �����w���p���ڽ
    ''' </summary>
    Public Property FTRNS_ADDRESS() As String
        Get
            Return mFTRNS_ADDRESS
        End Get
        Set(ByVal Value As String)
            mFTRNS_ADDRESS = Value
        End Set
    End Property
    ''' <summary>
    ''' �\�L�p���ڽ
    ''' </summary>
    Public Property FDISP_ADDRESS() As String
        Get
            Return mFDISP_ADDRESS
        End Get
        Set(ByVal Value As String)
            mFDISP_ADDRESS = Value
        End Set
    End Property
    ''' <summary>
    ''' ��
    ''' </summary>
    Public Property FRAC_RETU() As Nullable(Of Integer)
        Get
            Return mFRAC_RETU
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRAC_RETU = Value
        End Set
    End Property
    ''' <summary>
    ''' �A
    ''' </summary>
    Public Property FRAC_REN() As Nullable(Of Integer)
        Get
            Return mFRAC_REN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRAC_REN = Value
        End Set
    End Property
    ''' <summary>
    ''' �i
    ''' </summary>
    Public Property FRAC_DAN() As Nullable(Of Integer)
        Get
            Return mFRAC_DAN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRAC_DAN = Value
        End Set
    End Property
    ''' <summary>
    ''' �}
    ''' </summary>
    Public Property FRAC_EDA() As Nullable(Of Integer)
        Get
            Return mFRAC_EDA
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRAC_EDA = Value
        End Set
    End Property
    ''' <summary>
    ''' �֎~�L��
    ''' </summary>
    Public Property FREMOVE_KIND() As Nullable(Of Integer)
        Get
            Return mFREMOVE_KIND
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFREMOVE_KIND = Value
        End Set
    End Property
    ''' <summary>
    ''' �I�`����
    ''' </summary>
    Public Property FRAC_FORM() As Nullable(Of Integer)
        Get
            Return mFRAC_FORM
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRAC_FORM = Value
        End Set
    End Property
    ''' <summary>
    ''' �������
    ''' </summary>
    Public Property FRES_KIND() As Nullable(Of Integer)
        Get
            Return mFRES_KIND
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRES_KIND = Value
        End Set
    End Property
    ''' <summary>
    ''' ��������گ�ID
    ''' </summary>
    Public Property FRSV_PALLET() As String
        Get
            Return mFRSV_PALLET
        End Get
        Set(ByVal Value As String)
            mFRSV_PALLET = Value
        End Set
    End Property
    ''' <summary>
    ''' ����FM�ׯ�ݸ��ޯ̧��
    ''' </summary>
    Public Property FTR_FM() As Nullable(Of Integer)
        Get
            Return mFTR_FM
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFTR_FM = Value
        End Set
    End Property
    ''' <summary>
    ''' ����TO�ׯ�ݸ��ޯ̧��
    ''' </summary>
    Public Property FTR_TO() As Nullable(Of Integer)
        Get
            Return mFTR_TO
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFTR_TO = Value
        End Set
    End Property
    ''' <summary>
    ''' ����TO�ړ��ׯ�ݸ��ޯ̧��
    ''' </summary>
    Public Property FTR_IDOU() As Nullable(Of Integer)
        Get
            Return mFTR_IDOU
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFTR_IDOU = Value
        End Set
    End Property
    ''' <summary>
    ''' �����w�ߗpFM
    ''' </summary>
    Public Property FTRNS_FM() As String
        Get
            Return mFTRNS_FM
        End Get
        Set(ByVal Value As String)
            mFTRNS_FM = Value
        End Set
    End Property
    ''' <summary>
    ''' �����w�ߗpTO
    ''' </summary>
    Public Property FTRNS_TO() As String
        Get
            Return mFTRNS_TO
        End Get
        Set(ByVal Value As String)
            mFTRNS_TO = Value
        End Set
    End Property
    ''' <summary>
    ''' FM�����ׯ�ݸ��ޯ̧��
    ''' </summary>
    Public Property FRSV_BUF_FM() As Nullable(Of Integer)
        Get
            Return mFRSV_BUF_FM
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRSV_BUF_FM = Value
        End Set
    End Property
    ''' <summary>
    ''' FM�����ׯ�ݸ��ޯ̧�z��
    ''' </summary>
    Public Property FRSV_ARRAY_FM() As Nullable(Of Integer)
        Get
            Return mFRSV_ARRAY_FM
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRSV_ARRAY_FM = Value
        End Set
    End Property
    ''' <summary>
    ''' TO�����ׯ�ݸ��ޯ̧��
    ''' </summary>
    Public Property FRSV_BUF_TO() As Nullable(Of Integer)
        Get
            Return mFRSV_BUF_TO
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRSV_BUF_TO = Value
        End Set
    End Property
    ''' <summary>
    ''' TO�����ׯ�ݸ��ޯ̧�z��
    ''' </summary>
    Public Property FRSV_ARRAY_TO() As Nullable(Of Integer)
        Get
            Return mFRSV_ARRAY_TO
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRSV_ARRAY_TO = Value
        End Set
    End Property
    ''' <summary>
    ''' FM�\�L�p���ڽ
    ''' </summary>
    Public Property FDISP_ADDRESS_FM() As String
        Get
            Return mFDISP_ADDRESS_FM
        End Get
        Set(ByVal Value As String)
            mFDISP_ADDRESS_FM = Value
        End Set
    End Property
    ''' <summary>
    ''' TO�\�L�p���ڽ
    ''' </summary>
    Public Property FDISP_ADDRESS_TO() As String
        Get
            Return mFDISP_ADDRESS_TO
        End Get
        Set(ByVal Value As String)
            mFDISP_ADDRESS_TO = Value
        End Set
    End Property
    ''' <summary>
    ''' FM�\�L�p���ڽ_۸ޗp
    ''' </summary>
    Public Property FDISPLOG_ADDRESS_FM() As String
        Get
            Return mFDISPLOG_ADDRESS_FM
        End Get
        Set(ByVal Value As String)
            mFDISPLOG_ADDRESS_FM = Value
        End Set
    End Property
    ''' <summary>
    ''' TO�\�L�p���ڽ_۸ޗp
    ''' </summary>
    Public Property FDISPLOG_ADDRESS_TO() As String
        Get
            Return mFDISPLOG_ADDRESS_TO
        End Get
        Set(ByVal Value As String)
            mFDISPLOG_ADDRESS_TO = Value
        End Set
    End Property
    ''' <summary>
    ''' ��گ�ID
    ''' </summary>
    Public Property FPALLET_ID() As String
        Get
            Return mFPALLET_ID
        End Get
        Set(ByVal Value As String)
            mFPALLET_ID = Value
        End Set
    End Property
    ''' <summary>
    ''' �ޯ̧������
    ''' </summary>
    Public Property FBUF_IN_DT() As Nullable(Of Date)
        Get
            Return mFBUF_IN_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mFBUF_IN_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' �I����
    ''' </summary>
    Public Property FRAC_BUNRUI() As String
        Get
            Return mFRAC_BUNRUI
        End Get
        Set(ByVal Value As String)
            mFRAC_BUNRUI = Value
        End Set
    End Property
    ''' <summary>
    ''' �I��ۯ�
    ''' </summary>
    Public Property XTANA_BLOCK() As Nullable(Of Integer)
        Get
            Return mXTANA_BLOCK
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXTANA_BLOCK = Value
        End Set
    End Property
    ''' <summary>
    ''' �I��ۯ��ڍ�
    ''' </summary>
    Public Property XTANA_BLOCK_DTL() As Nullable(Of Integer)
        Get
            Return mXTANA_BLOCK_DTL
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXTANA_BLOCK_DTL = Value
        End Set
    End Property
    ''' <summary>
    ''' �I��ۯ����
    ''' </summary>
    Public Property XTANA_BLOCK_STS() As Nullable(Of Integer)
        Get
            Return mXTANA_BLOCK_STS
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXTANA_BLOCK_STS = Value
        End Set
    End Property
#End Region
#Region "  �ݽ�׸�                      "
    '''**********************************************************************************************
    ''' <summary>
    ''' �ݽ�׸�
    ''' </summary>
    ''' <param name="objOwner">��Ű��޼ު��</param>
    ''' <param name="objDb">DB������޼ު��</param>
    ''' <param name="objDbLog">DB������޼ު��(۸ޏ������ݗp)</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub New(ByVal objOwner As Object, ByVal objDb As clsConn, ByVal objDbLog As clsConn)
        MyBase.new(objOwner, objDb, objDbLog)   '�e�׽�̺ݽ�׸�������
    End Sub
#End Region
#Region "  �ް��擾                     "
    '''**********************************************************************************************
    ''' <summary>
    ''' �ް��擾
    ''' </summary>
    ''' <param name="blnNotFoundError">ں��ނ��ꌏ���擾�o���Ȃ������ꍇ�AThrow���邩�ۂ����׸�</param>
    ''' <returns>���ʖ߂�l</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function GET_TPRG_TRK_BUF(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
        Dim strSQL As New StringBuilder 'SQL��
        Dim objDataSet As New DataSet   '�ް����
        Dim strDataSetName As String    '�ް���Ė�
        Dim objRow As DataRow           '1ں��ޕ����ް�
        Dim objParameter(1, 0) As Object
        Dim strBindField(0) As String
        Dim objBindValue(0) As Object
        Dim strBindType(0) As String


        '***********************
        '���oSQL�쐬
        '***********************
        strBindField = Nothing
        objBindValue = Nothing
        strBindType = Nothing
        ReDim Preserve strBindField(0)
        ReDim Preserve objBindValue(0)
        ReDim Preserve strBindType(0)
        strSQL.Append(vbCrLf & "SELECT")
        strSQL.Append(vbCrLf & "    *")
        strSQL.Append(vbCrLf & " FROM")
        strSQL.Append(vbCrLf & "    TPRG_TRK_BUF")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FTRK_BUF_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FTRK_BUF_ARRAY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_ARRAY
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_ARRAY = :" & UBound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧�z��")
        End If
        If IsNull(FSERCH_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSERCH_NO
            strSQL.Append(vbCrLf & "    AND FSERCH_NO = :" & UBound(strBindField) - 1 & " --�󌟍�����")
        End If
        If IsNull(FTRNS_ADDRESS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_ADDRESS
            strSQL.Append(vbCrLf & "    AND FTRNS_ADDRESS = :" & UBound(strBindField) - 1 & " --�����w���p���ڽ")
        End If
        If IsNull(FDISP_ADDRESS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS
            strSQL.Append(vbCrLf & "    AND FDISP_ADDRESS = :" & UBound(strBindField) - 1 & " --�\�L�p���ڽ")
        End If
        If IsNull(FRAC_RETU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_RETU
            strSQL.Append(vbCrLf & "    AND FRAC_RETU = :" & UBound(strBindField) - 1 & " --��")
        End If
        If IsNull(FRAC_REN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_REN
            strSQL.Append(vbCrLf & "    AND FRAC_REN = :" & UBound(strBindField) - 1 & " --�A")
        End If
        If IsNull(FRAC_DAN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_DAN
            strSQL.Append(vbCrLf & "    AND FRAC_DAN = :" & UBound(strBindField) - 1 & " --�i")
        End If
        If IsNull(FRAC_EDA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_EDA
            strSQL.Append(vbCrLf & "    AND FRAC_EDA = :" & UBound(strBindField) - 1 & " --�}")
        End If
        If IsNull(FREMOVE_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFREMOVE_KIND
            strSQL.Append(vbCrLf & "    AND FREMOVE_KIND = :" & UBound(strBindField) - 1 & " --�֎~�L��")
        End If
        If IsNull(FRAC_FORM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_FORM
            strSQL.Append(vbCrLf & "    AND FRAC_FORM = :" & UBound(strBindField) - 1 & " --�I�`����")
        End If
        If IsNull(FRES_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRES_KIND
            strSQL.Append(vbCrLf & "    AND FRES_KIND = :" & UBound(strBindField) - 1 & " --�������")
        End If
        If IsNull(FRSV_PALLET) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_PALLET
            strSQL.Append(vbCrLf & "    AND FRSV_PALLET = :" & UBound(strBindField) - 1 & " --��������گ�ID")
        End If
        If IsNull(FTR_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_FM
            strSQL.Append(vbCrLf & "    AND FTR_FM = :" & UBound(strBindField) - 1 & " --����FM�ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FTR_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_TO
            strSQL.Append(vbCrLf & "    AND FTR_TO = :" & UBound(strBindField) - 1 & " --����TO�ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FTR_IDOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_IDOU
            strSQL.Append(vbCrLf & "    AND FTR_IDOU = :" & UBound(strBindField) - 1 & " --����TO�ړ��ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FTRNS_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_FM
            strSQL.Append(vbCrLf & "    AND FTRNS_FM = :" & UBound(strBindField) - 1 & " --�����w�ߗpFM")
        End If
        If IsNull(FTRNS_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_TO
            strSQL.Append(vbCrLf & "    AND FTRNS_TO = :" & UBound(strBindField) - 1 & " --�����w�ߗpTO")
        End If
        If IsNull(FRSV_BUF_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_BUF_FM
            strSQL.Append(vbCrLf & "    AND FRSV_BUF_FM = :" & UBound(strBindField) - 1 & " --FM�����ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FRSV_ARRAY_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_ARRAY_FM
            strSQL.Append(vbCrLf & "    AND FRSV_ARRAY_FM = :" & UBound(strBindField) - 1 & " --FM�����ׯ�ݸ��ޯ̧�z��")
        End If
        If IsNull(FRSV_BUF_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_BUF_TO
            strSQL.Append(vbCrLf & "    AND FRSV_BUF_TO = :" & UBound(strBindField) - 1 & " --TO�����ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FRSV_ARRAY_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_ARRAY_TO
            strSQL.Append(vbCrLf & "    AND FRSV_ARRAY_TO = :" & UBound(strBindField) - 1 & " --TO�����ׯ�ݸ��ޯ̧�z��")
        End If
        If IsNull(FDISP_ADDRESS_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS_FM
            strSQL.Append(vbCrLf & "    AND FDISP_ADDRESS_FM = :" & UBound(strBindField) - 1 & " --FM�\�L�p���ڽ")
        End If
        If IsNull(FDISP_ADDRESS_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS_TO
            strSQL.Append(vbCrLf & "    AND FDISP_ADDRESS_TO = :" & UBound(strBindField) - 1 & " --TO�\�L�p���ڽ")
        End If
        If IsNull(FDISPLOG_ADDRESS_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISPLOG_ADDRESS_FM
            strSQL.Append(vbCrLf & "    AND FDISPLOG_ADDRESS_FM = :" & UBound(strBindField) - 1 & " --FM�\�L�p���ڽ_۸ޗp")
        End If
        If IsNull(FDISPLOG_ADDRESS_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISPLOG_ADDRESS_TO
            strSQL.Append(vbCrLf & "    AND FDISPLOG_ADDRESS_TO = :" & UBound(strBindField) - 1 & " --TO�\�L�p���ڽ_۸ޗp")
        End If
        If IsNull(FPALLET_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --��گ�ID")
        End If
        If IsNull(FBUF_IN_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_IN_DT
            strSQL.Append(vbCrLf & "    AND FBUF_IN_DT = :" & UBound(strBindField) - 1 & " --�ޯ̧������")
        End If
        If IsNull(FRAC_BUNRUI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_BUNRUI
            strSQL.Append(vbCrLf & "    AND FRAC_BUNRUI = :" & UBound(strBindField) - 1 & " --�I����")
        End If
        If IsNull(XTANA_BLOCK) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTANA_BLOCK
            strSQL.Append(vbCrLf & "    AND XTANA_BLOCK = :" & UBound(strBindField) - 1 & " --�I��ۯ�")
        End If
        If IsNull(XTANA_BLOCK_DTL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTANA_BLOCK_DTL
            strSQL.Append(vbCrLf & "    AND XTANA_BLOCK_DTL = :" & UBound(strBindField) - 1 & " --�I��ۯ��ڍ�")
        End If
        If IsNull(XTANA_BLOCK_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTANA_BLOCK_STS
            strSQL.Append(vbCrLf & "    AND XTANA_BLOCK_STS = :" & UBound(strBindField) - 1 & " --�I��ۯ����")
        End If
        If IsNotNull(mWHERE) Then
            strSQL.Append(vbCrLf & mWHERE)
        End If
        If IsNotNull(mORDER_BY) Then
            strSQL.Append(vbCrLf & " ORDER BY ")
            strSQL.Append(vbCrLf & mORDER_BY)
        End If
        strSQL.Append(vbCrLf)


        '***********************
        '�޲��ޕϐ���`
        '***********************
        objParameter = Nothing
        ReDim Preserve objParameter(2, UBound(strBindField) - 1)
        Dim ii As Integer
        For ii = LBound(strBindField) + 1 To UBound(strBindField)
            objParameter(0, ii - 1) = strBindField(ii)
            objParameter(1, ii - 1) = objBindValue(ii)
        Next ii


        '***********************
        '���o
        '***********************
        ObjDb.SQL = strSQL.ToString
        ObjDb.Parameter = objParameter
        objDataSet.Clear()
        strDataSetName = "TPRG_TRK_BUF"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count = 1 Then
            objRow = objDataSet.Tables(strDataSetName).Rows(0)
            Call SET_DATA(objRow)
            Return (RetCode.OK)
        ElseIf objDataSet.Tables(strDataSetName).Rows.Count <= 0 Then

            If blnNotFoundError = True Then
                '(�װ�Ƃ���ꍇ)
                Dim strMsg As String = ""
                Call MAKE_ERRMSG01(strMsg)
                Throw New UserException(strMsg)
            Else
                '(�װ���Ȃ��ꍇ)
                Return (RetCode.NotFound)
            End If

        Else
            Throw New UserException("����ں��ޒ��o�����ׁA�װ�Ƃ��܂��B")
        End If


    End Function
#End Region
#Region "  �ް��擾(����ں���)          "
    '''**********************************************************************************************
    ''' <summary>
    ''' �ް��擾(����ں���)
    ''' </summary>
    ''' <returns>���ʖ߂�l</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function GET_TPRG_TRK_BUF_ANY() As RetCode
        Dim strSQL As New StringBuilder 'SQL��
        Dim objDataSet As New DataSet   '�ް����
        Dim strDataSetName As String    '�ް���Ė�
        Dim objRow As DataRow           '1ں��ޕ����ް�
        Dim objParameter(1, 0) As Object
        Dim strBindField(0) As String
        Dim objBindValue(0) As Object
        Dim strBindType(0) As String


        '***********************
        '���oSQL�쐬
        '***********************
        strBindField = Nothing
        objBindValue = Nothing
        strBindType = Nothing
        ReDim Preserve strBindField(0)
        ReDim Preserve objBindValue(0)
        ReDim Preserve strBindType(0)
        strSQL.Append(vbCrLf & "SELECT")
        strSQL.Append(vbCrLf & "    *")
        strSQL.Append(vbCrLf & " FROM")
        strSQL.Append(vbCrLf & "    TPRG_TRK_BUF")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FTRK_BUF_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FTRK_BUF_ARRAY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_ARRAY
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_ARRAY = :" & UBound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧�z��")
        End If
        If IsNull(FSERCH_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSERCH_NO
            strSQL.Append(vbCrLf & "    AND FSERCH_NO = :" & UBound(strBindField) - 1 & " --�󌟍�����")
        End If
        If IsNull(FTRNS_ADDRESS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_ADDRESS
            strSQL.Append(vbCrLf & "    AND FTRNS_ADDRESS = :" & UBound(strBindField) - 1 & " --�����w���p���ڽ")
        End If
        If IsNull(FDISP_ADDRESS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS
            strSQL.Append(vbCrLf & "    AND FDISP_ADDRESS = :" & UBound(strBindField) - 1 & " --�\�L�p���ڽ")
        End If
        If IsNull(FRAC_RETU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_RETU
            strSQL.Append(vbCrLf & "    AND FRAC_RETU = :" & UBound(strBindField) - 1 & " --��")
        End If
        If IsNull(FRAC_REN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_REN
            strSQL.Append(vbCrLf & "    AND FRAC_REN = :" & UBound(strBindField) - 1 & " --�A")
        End If
        If IsNull(FRAC_DAN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_DAN
            strSQL.Append(vbCrLf & "    AND FRAC_DAN = :" & UBound(strBindField) - 1 & " --�i")
        End If
        If IsNull(FRAC_EDA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_EDA
            strSQL.Append(vbCrLf & "    AND FRAC_EDA = :" & UBound(strBindField) - 1 & " --�}")
        End If
        If IsNull(FREMOVE_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFREMOVE_KIND
            strSQL.Append(vbCrLf & "    AND FREMOVE_KIND = :" & UBound(strBindField) - 1 & " --�֎~�L��")
        End If
        If IsNull(FRAC_FORM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_FORM
            strSQL.Append(vbCrLf & "    AND FRAC_FORM = :" & UBound(strBindField) - 1 & " --�I�`����")
        End If
        If IsNull(FRES_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRES_KIND
            strSQL.Append(vbCrLf & "    AND FRES_KIND = :" & UBound(strBindField) - 1 & " --�������")
        End If
        If IsNull(FRSV_PALLET) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_PALLET
            strSQL.Append(vbCrLf & "    AND FRSV_PALLET = :" & UBound(strBindField) - 1 & " --��������گ�ID")
        End If
        If IsNull(FTR_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_FM
            strSQL.Append(vbCrLf & "    AND FTR_FM = :" & UBound(strBindField) - 1 & " --����FM�ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FTR_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_TO
            strSQL.Append(vbCrLf & "    AND FTR_TO = :" & UBound(strBindField) - 1 & " --����TO�ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FTR_IDOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_IDOU
            strSQL.Append(vbCrLf & "    AND FTR_IDOU = :" & UBound(strBindField) - 1 & " --����TO�ړ��ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FTRNS_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_FM
            strSQL.Append(vbCrLf & "    AND FTRNS_FM = :" & UBound(strBindField) - 1 & " --�����w�ߗpFM")
        End If
        If IsNull(FTRNS_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_TO
            strSQL.Append(vbCrLf & "    AND FTRNS_TO = :" & UBound(strBindField) - 1 & " --�����w�ߗpTO")
        End If
        If IsNull(FRSV_BUF_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_BUF_FM
            strSQL.Append(vbCrLf & "    AND FRSV_BUF_FM = :" & UBound(strBindField) - 1 & " --FM�����ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FRSV_ARRAY_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_ARRAY_FM
            strSQL.Append(vbCrLf & "    AND FRSV_ARRAY_FM = :" & UBound(strBindField) - 1 & " --FM�����ׯ�ݸ��ޯ̧�z��")
        End If
        If IsNull(FRSV_BUF_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_BUF_TO
            strSQL.Append(vbCrLf & "    AND FRSV_BUF_TO = :" & UBound(strBindField) - 1 & " --TO�����ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FRSV_ARRAY_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_ARRAY_TO
            strSQL.Append(vbCrLf & "    AND FRSV_ARRAY_TO = :" & UBound(strBindField) - 1 & " --TO�����ׯ�ݸ��ޯ̧�z��")
        End If
        If IsNull(FDISP_ADDRESS_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS_FM
            strSQL.Append(vbCrLf & "    AND FDISP_ADDRESS_FM = :" & UBound(strBindField) - 1 & " --FM�\�L�p���ڽ")
        End If
        If IsNull(FDISP_ADDRESS_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS_TO
            strSQL.Append(vbCrLf & "    AND FDISP_ADDRESS_TO = :" & UBound(strBindField) - 1 & " --TO�\�L�p���ڽ")
        End If
        If IsNull(FDISPLOG_ADDRESS_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISPLOG_ADDRESS_FM
            strSQL.Append(vbCrLf & "    AND FDISPLOG_ADDRESS_FM = :" & UBound(strBindField) - 1 & " --FM�\�L�p���ڽ_۸ޗp")
        End If
        If IsNull(FDISPLOG_ADDRESS_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISPLOG_ADDRESS_TO
            strSQL.Append(vbCrLf & "    AND FDISPLOG_ADDRESS_TO = :" & UBound(strBindField) - 1 & " --TO�\�L�p���ڽ_۸ޗp")
        End If
        If IsNull(FPALLET_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --��گ�ID")
        End If
        If IsNull(FBUF_IN_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_IN_DT
            strSQL.Append(vbCrLf & "    AND FBUF_IN_DT = :" & UBound(strBindField) - 1 & " --�ޯ̧������")
        End If
        If IsNull(FRAC_BUNRUI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_BUNRUI
            strSQL.Append(vbCrLf & "    AND FRAC_BUNRUI = :" & UBound(strBindField) - 1 & " --�I����")
        End If
        If IsNull(XTANA_BLOCK) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTANA_BLOCK
            strSQL.Append(vbCrLf & "    AND XTANA_BLOCK = :" & UBound(strBindField) - 1 & " --�I��ۯ�")
        End If
        If IsNull(XTANA_BLOCK_DTL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTANA_BLOCK_DTL
            strSQL.Append(vbCrLf & "    AND XTANA_BLOCK_DTL = :" & UBound(strBindField) - 1 & " --�I��ۯ��ڍ�")
        End If
        If IsNull(XTANA_BLOCK_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTANA_BLOCK_STS
            strSQL.Append(vbCrLf & "    AND XTANA_BLOCK_STS = :" & UBound(strBindField) - 1 & " --�I��ۯ����")
        End If
        If IsNotNull(mWHERE) Then
            strSQL.Append(vbCrLf & mWHERE)
        End If
        If IsNotNull(mORDER_BY) Then
            strSQL.Append(vbCrLf & " ORDER BY ")
            strSQL.Append(vbCrLf & mORDER_BY)
        End If
        strSQL.Append(vbCrLf)


        '***********************
        '�޲��ޕϐ���`
        '***********************
        objParameter = Nothing
        ReDim Preserve objParameter(2, Ubound(strBindField) - 1)
        Dim ii As Integer
        For ii = Lbound(strBindField) + 1 To Ubound(strBindField)
            objParameter(0, ii - 1) = strBindField(ii)
            objParameter(1, ii - 1) = objBindValue(ii)
        Next ii


        '***********************
        '���o
        '***********************
        mobjAryMe = Nothing
        ObjDb.SQL = strSQL.ToString
        ObjDb.Parameter = objParameter
        objDataSet.Clear()
        strDataSetName = "TPRG_TRK_BUF"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TPRG_TRK_BUF(Owner, objDb, objDbLog)
                mobjAryMe(ii).SET_DATA(objRow)
            Next ii
            Return (RetCode.OK)
        Else
            Return (RetCode.NotFound)
        End If


    End Function
#End Region
#Region "  �ް��擾(���ђ��o)           "
    '''**********************************************************************************************
    ''' <summary>
    ''' �ް��擾(���ђ��o)
    ''' </summary>
    ''' <param name="objUSER_PARAM">հ�ްPARAM (�޲��ޕϐ��p��޼ު�Č^�z��)</param>
    ''' <returns>���ʖ߂�l</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function GET_TPRG_TRK_BUF_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
        Dim strMsg As String            'ү����
        Dim objDataSet As New DataSet   '�ް����
        Dim strDataSetName As String    '�ް���Ė�
        Dim objRow As DataRow           '1ں��ޕ����ް�
        Dim ii As Integer               '����


        '***********************
        '�����è����
        '***********************
        If 1 <> 1 Then
        ElseIf IsNull(mstrUSER_SQL) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[հ�ްSQL]"
            Throw New UserException(strMsg)
        End If


        '***********************
        '���o
        '***********************
        mobjAryMe = Nothing
        If IsNothing(objUSER_PARAM) = False Then
            ObjDb.Parameter = objUSER_PARAM
        End If
        ObjDb.SQL = mstrUSER_SQL
        objDataSet.Clear()
        strDataSetName = "TPRG_TRK_BUF"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TPRG_TRK_BUF(Owner, objDb, objDbLog)
                mobjAryMe(ii).SET_DATA(objRow)
            Next ii
            Return (RetCode.OK)
        Else
            Return (RetCode.NotFound)
        End If


    End Function
#End Region
#Region "  �ް��擾(����)               "
    '''**********************************************************************************************
    ''' <summary>
    ''' �ް��擾(����)
    ''' </summary>
    ''' <returns>���ʖ߂�l</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function GET_TPRG_TRK_BUF_COUNT() As Integer
        Dim strSQL As New StringBuilder 'SQL��
        Dim objDataSet As New DataSet   '�ް����
        Dim strDataSetName As String    '�ް���Ė�
        Dim objRow As DataRow           '1ں��ޕ����ް�
        Dim objParameter(1, 0) As Object
        Dim strBindField(0) As String
        Dim objBindValue(0) As Object
        Dim strBindType(0) As String


        '***********************
        '���oSQL�쐬
        '***********************
        strBindField = Nothing
        objBindValue = Nothing
        strBindType = Nothing
        ReDim Preserve strBindField(0)
        ReDim Preserve objBindValue(0)
        ReDim Preserve strBindType(0)
        strSQL.Append(vbCrLf & "SELECT")
        strSQL.Append(vbCrLf & "    COUNT(*)")
        strSQL.Append(vbCrLf & " FROM")
        strSQL.Append(vbCrLf & "    TPRG_TRK_BUF")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FTRK_BUF_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FTRK_BUF_ARRAY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_ARRAY
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_ARRAY = :" & UBound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧�z��")
        End If
        If IsNull(FSERCH_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSERCH_NO
            strSQL.Append(vbCrLf & "    AND FSERCH_NO = :" & UBound(strBindField) - 1 & " --�󌟍�����")
        End If
        If IsNull(FTRNS_ADDRESS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_ADDRESS
            strSQL.Append(vbCrLf & "    AND FTRNS_ADDRESS = :" & UBound(strBindField) - 1 & " --�����w���p���ڽ")
        End If
        If IsNull(FDISP_ADDRESS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS
            strSQL.Append(vbCrLf & "    AND FDISP_ADDRESS = :" & UBound(strBindField) - 1 & " --�\�L�p���ڽ")
        End If
        If IsNull(FRAC_RETU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_RETU
            strSQL.Append(vbCrLf & "    AND FRAC_RETU = :" & UBound(strBindField) - 1 & " --��")
        End If
        If IsNull(FRAC_REN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_REN
            strSQL.Append(vbCrLf & "    AND FRAC_REN = :" & UBound(strBindField) - 1 & " --�A")
        End If
        If IsNull(FRAC_DAN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_DAN
            strSQL.Append(vbCrLf & "    AND FRAC_DAN = :" & UBound(strBindField) - 1 & " --�i")
        End If
        If IsNull(FRAC_EDA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_EDA
            strSQL.Append(vbCrLf & "    AND FRAC_EDA = :" & UBound(strBindField) - 1 & " --�}")
        End If
        If IsNull(FREMOVE_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFREMOVE_KIND
            strSQL.Append(vbCrLf & "    AND FREMOVE_KIND = :" & UBound(strBindField) - 1 & " --�֎~�L��")
        End If
        If IsNull(FRAC_FORM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_FORM
            strSQL.Append(vbCrLf & "    AND FRAC_FORM = :" & UBound(strBindField) - 1 & " --�I�`����")
        End If
        If IsNull(FRES_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRES_KIND
            strSQL.Append(vbCrLf & "    AND FRES_KIND = :" & UBound(strBindField) - 1 & " --�������")
        End If
        If IsNull(FRSV_PALLET) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_PALLET
            strSQL.Append(vbCrLf & "    AND FRSV_PALLET = :" & UBound(strBindField) - 1 & " --��������گ�ID")
        End If
        If IsNull(FTR_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_FM
            strSQL.Append(vbCrLf & "    AND FTR_FM = :" & UBound(strBindField) - 1 & " --����FM�ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FTR_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_TO
            strSQL.Append(vbCrLf & "    AND FTR_TO = :" & UBound(strBindField) - 1 & " --����TO�ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FTR_IDOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_IDOU
            strSQL.Append(vbCrLf & "    AND FTR_IDOU = :" & UBound(strBindField) - 1 & " --����TO�ړ��ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FTRNS_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_FM
            strSQL.Append(vbCrLf & "    AND FTRNS_FM = :" & UBound(strBindField) - 1 & " --�����w�ߗpFM")
        End If
        If IsNull(FTRNS_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_TO
            strSQL.Append(vbCrLf & "    AND FTRNS_TO = :" & UBound(strBindField) - 1 & " --�����w�ߗpTO")
        End If
        If IsNull(FRSV_BUF_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_BUF_FM
            strSQL.Append(vbCrLf & "    AND FRSV_BUF_FM = :" & UBound(strBindField) - 1 & " --FM�����ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FRSV_ARRAY_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_ARRAY_FM
            strSQL.Append(vbCrLf & "    AND FRSV_ARRAY_FM = :" & UBound(strBindField) - 1 & " --FM�����ׯ�ݸ��ޯ̧�z��")
        End If
        If IsNull(FRSV_BUF_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_BUF_TO
            strSQL.Append(vbCrLf & "    AND FRSV_BUF_TO = :" & UBound(strBindField) - 1 & " --TO�����ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FRSV_ARRAY_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_ARRAY_TO
            strSQL.Append(vbCrLf & "    AND FRSV_ARRAY_TO = :" & UBound(strBindField) - 1 & " --TO�����ׯ�ݸ��ޯ̧�z��")
        End If
        If IsNull(FDISP_ADDRESS_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS_FM
            strSQL.Append(vbCrLf & "    AND FDISP_ADDRESS_FM = :" & UBound(strBindField) - 1 & " --FM�\�L�p���ڽ")
        End If
        If IsNull(FDISP_ADDRESS_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS_TO
            strSQL.Append(vbCrLf & "    AND FDISP_ADDRESS_TO = :" & UBound(strBindField) - 1 & " --TO�\�L�p���ڽ")
        End If
        If IsNull(FDISPLOG_ADDRESS_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISPLOG_ADDRESS_FM
            strSQL.Append(vbCrLf & "    AND FDISPLOG_ADDRESS_FM = :" & UBound(strBindField) - 1 & " --FM�\�L�p���ڽ_۸ޗp")
        End If
        If IsNull(FDISPLOG_ADDRESS_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISPLOG_ADDRESS_TO
            strSQL.Append(vbCrLf & "    AND FDISPLOG_ADDRESS_TO = :" & UBound(strBindField) - 1 & " --TO�\�L�p���ڽ_۸ޗp")
        End If
        If IsNull(FPALLET_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --��گ�ID")
        End If
        If IsNull(FBUF_IN_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_IN_DT
            strSQL.Append(vbCrLf & "    AND FBUF_IN_DT = :" & UBound(strBindField) - 1 & " --�ޯ̧������")
        End If
        If IsNull(FRAC_BUNRUI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_BUNRUI
            strSQL.Append(vbCrLf & "    AND FRAC_BUNRUI = :" & UBound(strBindField) - 1 & " --�I����")
        End If
        If IsNull(XTANA_BLOCK) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTANA_BLOCK
            strSQL.Append(vbCrLf & "    AND XTANA_BLOCK = :" & UBound(strBindField) - 1 & " --�I��ۯ�")
        End If
        If IsNull(XTANA_BLOCK_DTL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTANA_BLOCK_DTL
            strSQL.Append(vbCrLf & "    AND XTANA_BLOCK_DTL = :" & UBound(strBindField) - 1 & " --�I��ۯ��ڍ�")
        End If
        If IsNull(XTANA_BLOCK_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTANA_BLOCK_STS
            strSQL.Append(vbCrLf & "    AND XTANA_BLOCK_STS = :" & UBound(strBindField) - 1 & " --�I��ۯ����")
        End If
        If IsNotNull(mWHERE) Then
            strSQL.Append(vbCrLf & mWHERE)
        End If
        strSQL.Append(vbCrLf)


        '***********************
        '�޲��ޕϐ���`
        '***********************
        objParameter = Nothing
        ReDim Preserve objParameter(2, Ubound(strBindField) - 1)
        Dim ii As Integer
        For ii = Lbound(strBindField) + 1 To Ubound(strBindField)
            objParameter(0, ii - 1) = strBindField(ii)
            objParameter(1, ii - 1) = objBindValue(ii)
        Next ii


        '***********************
        '���o
        '***********************
        ObjDb.SQL = strSQL.ToString
        ObjDb.Parameter = objParameter
        objDataSet.Clear()
        strDataSetName = "TPRG_TRK_BUF"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        objRow = objDataSet.Tables(strDataSetName).Rows(0)
        Return (objRow(0))


    End Function
#End Region
#Region "  �ް��X�V                     "
    '''**********************************************************************************************
    ''' <summary>
    ''' �ް��X�V
    ''' </summary>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub UPDATE_TPRG_TRK_BUF()
        Dim strSQL As New StringBuilder     'SQL��
        Dim strMsg As String                'ү����
        Dim intRetSQL As Integer            'SQL���s�߂�l
        Dim objParameter(1, 0) As Object
        Dim strBindField(0) As String
        Dim objBindValue(0) As Object


        '***********************
        '�����è����
        '***********************
        If 1 <> 1 Then
        ElseIf IsNull(mFTRK_BUF_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�ׯ�ݸ��ޯ̧��]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFTRK_BUF_ARRAY) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�ׯ�ݸ��ޯ̧�z��]"
            Throw New UserException(strMsg)
        End If


        '***********************
        '�X�VSQL�쐬
        '***********************
        strBindField = Nothing
        objBindValue = Nothing
        ReDim Preserve strBindField(0)
        ReDim Preserve objBindValue(0)
        strSQL.Append(vbCrLf & "UPDATE")
        strSQL.Append(vbCrLf & "    TPRG_TRK_BUF")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
        If IsNull(mFTRK_BUF_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTRK_BUF_NO = NULL --�ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTRK_BUF_NO = NULL --�ׯ�ݸ��ޯ̧��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTRK_BUF_NO = :" & Ubound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTRK_BUF_NO = :" & Ubound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧��")
        End If
        intCount = intCount + 1
        If IsNull(mFTRK_BUF_ARRAY) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTRK_BUF_ARRAY = NULL --�ׯ�ݸ��ޯ̧�z��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTRK_BUF_ARRAY = NULL --�ׯ�ݸ��ޯ̧�z��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_ARRAY
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTRK_BUF_ARRAY = :" & Ubound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧�z��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTRK_BUF_ARRAY = :" & Ubound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧�z��")
        End If
        intCount = intCount + 1
        If IsNull(mFSERCH_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSERCH_NO = NULL --�󌟍�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSERCH_NO = NULL --�󌟍�����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSERCH_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSERCH_NO = :" & Ubound(strBindField) - 1 & " --�󌟍�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSERCH_NO = :" & Ubound(strBindField) - 1 & " --�󌟍�����")
        End If
        intCount = intCount + 1
        If IsNull(mFTRNS_ADDRESS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTRNS_ADDRESS = NULL --�����w���p���ڽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTRNS_ADDRESS = NULL --�����w���p���ڽ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_ADDRESS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTRNS_ADDRESS = :" & Ubound(strBindField) - 1 & " --�����w���p���ڽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTRNS_ADDRESS = :" & Ubound(strBindField) - 1 & " --�����w���p���ڽ")
        End If
        intCount = intCount + 1
        If IsNull(mFDISP_ADDRESS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDISP_ADDRESS = NULL --�\�L�p���ڽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDISP_ADDRESS = NULL --�\�L�p���ڽ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDISP_ADDRESS = :" & Ubound(strBindField) - 1 & " --�\�L�p���ڽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDISP_ADDRESS = :" & Ubound(strBindField) - 1 & " --�\�L�p���ڽ")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_RETU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_RETU = NULL --��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_RETU = NULL --��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_RETU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_RETU = :" & Ubound(strBindField) - 1 & " --��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_RETU = :" & Ubound(strBindField) - 1 & " --��")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_REN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_REN = NULL --�A")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_REN = NULL --�A")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_REN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_REN = :" & Ubound(strBindField) - 1 & " --�A")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_REN = :" & Ubound(strBindField) - 1 & " --�A")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_DAN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_DAN = NULL --�i")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_DAN = NULL --�i")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_DAN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_DAN = :" & Ubound(strBindField) - 1 & " --�i")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_DAN = :" & Ubound(strBindField) - 1 & " --�i")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_EDA) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_EDA = NULL --�}")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_EDA = NULL --�}")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_EDA
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_EDA = :" & Ubound(strBindField) - 1 & " --�}")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_EDA = :" & Ubound(strBindField) - 1 & " --�}")
        End If
        intCount = intCount + 1
        If IsNull(mFREMOVE_KIND) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FREMOVE_KIND = NULL --�֎~�L��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FREMOVE_KIND = NULL --�֎~�L��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFREMOVE_KIND
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FREMOVE_KIND = :" & Ubound(strBindField) - 1 & " --�֎~�L��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FREMOVE_KIND = :" & Ubound(strBindField) - 1 & " --�֎~�L��")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_FORM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_FORM = NULL --�I�`����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_FORM = NULL --�I�`����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_FORM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_FORM = :" & Ubound(strBindField) - 1 & " --�I�`����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_FORM = :" & Ubound(strBindField) - 1 & " --�I�`����")
        End If
        intCount = intCount + 1
        If IsNull(mFRES_KIND) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRES_KIND = NULL --�������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRES_KIND = NULL --�������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRES_KIND
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRES_KIND = :" & Ubound(strBindField) - 1 & " --�������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRES_KIND = :" & Ubound(strBindField) - 1 & " --�������")
        End If
        intCount = intCount + 1
        If IsNull(mFRSV_PALLET) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRSV_PALLET = NULL --��������گ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRSV_PALLET = NULL --��������گ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_PALLET
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRSV_PALLET = :" & Ubound(strBindField) - 1 & " --��������گ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRSV_PALLET = :" & Ubound(strBindField) - 1 & " --��������گ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mFTR_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTR_FM = NULL --����FM�ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTR_FM = NULL --����FM�ׯ�ݸ��ޯ̧��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTR_FM = :" & Ubound(strBindField) - 1 & " --����FM�ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTR_FM = :" & Ubound(strBindField) - 1 & " --����FM�ׯ�ݸ��ޯ̧��")
        End If
        intCount = intCount + 1
        If IsNull(mFTR_TO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTR_TO = NULL --����TO�ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTR_TO = NULL --����TO�ׯ�ݸ��ޯ̧��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_TO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTR_TO = :" & Ubound(strBindField) - 1 & " --����TO�ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTR_TO = :" & Ubound(strBindField) - 1 & " --����TO�ׯ�ݸ��ޯ̧��")
        End If
        intCount = intCount + 1
        If IsNull(mFTR_IDOU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTR_IDOU = NULL --����TO�ړ��ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTR_IDOU = NULL --����TO�ړ��ׯ�ݸ��ޯ̧��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_IDOU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTR_IDOU = :" & Ubound(strBindField) - 1 & " --����TO�ړ��ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTR_IDOU = :" & Ubound(strBindField) - 1 & " --����TO�ړ��ׯ�ݸ��ޯ̧��")
        End If
        intCount = intCount + 1
        If IsNull(mFTRNS_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTRNS_FM = NULL --�����w�ߗpFM")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTRNS_FM = NULL --�����w�ߗpFM")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTRNS_FM = :" & Ubound(strBindField) - 1 & " --�����w�ߗpFM")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTRNS_FM = :" & Ubound(strBindField) - 1 & " --�����w�ߗpFM")
        End If
        intCount = intCount + 1
        If IsNull(mFTRNS_TO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTRNS_TO = NULL --�����w�ߗpTO")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTRNS_TO = NULL --�����w�ߗpTO")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_TO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTRNS_TO = :" & Ubound(strBindField) - 1 & " --�����w�ߗpTO")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTRNS_TO = :" & Ubound(strBindField) - 1 & " --�����w�ߗpTO")
        End If
        intCount = intCount + 1
        If IsNull(mFRSV_BUF_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRSV_BUF_FM = NULL --FM�����ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRSV_BUF_FM = NULL --FM�����ׯ�ݸ��ޯ̧��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_BUF_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRSV_BUF_FM = :" & Ubound(strBindField) - 1 & " --FM�����ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRSV_BUF_FM = :" & Ubound(strBindField) - 1 & " --FM�����ׯ�ݸ��ޯ̧��")
        End If
        intCount = intCount + 1
        If IsNull(mFRSV_ARRAY_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRSV_ARRAY_FM = NULL --FM�����ׯ�ݸ��ޯ̧�z��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRSV_ARRAY_FM = NULL --FM�����ׯ�ݸ��ޯ̧�z��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_ARRAY_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRSV_ARRAY_FM = :" & Ubound(strBindField) - 1 & " --FM�����ׯ�ݸ��ޯ̧�z��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRSV_ARRAY_FM = :" & Ubound(strBindField) - 1 & " --FM�����ׯ�ݸ��ޯ̧�z��")
        End If
        intCount = intCount + 1
        If IsNull(mFRSV_BUF_TO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRSV_BUF_TO = NULL --TO�����ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRSV_BUF_TO = NULL --TO�����ׯ�ݸ��ޯ̧��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_BUF_TO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRSV_BUF_TO = :" & Ubound(strBindField) - 1 & " --TO�����ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRSV_BUF_TO = :" & Ubound(strBindField) - 1 & " --TO�����ׯ�ݸ��ޯ̧��")
        End If
        intCount = intCount + 1
        If IsNull(mFRSV_ARRAY_TO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRSV_ARRAY_TO = NULL --TO�����ׯ�ݸ��ޯ̧�z��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRSV_ARRAY_TO = NULL --TO�����ׯ�ݸ��ޯ̧�z��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_ARRAY_TO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRSV_ARRAY_TO = :" & Ubound(strBindField) - 1 & " --TO�����ׯ�ݸ��ޯ̧�z��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRSV_ARRAY_TO = :" & Ubound(strBindField) - 1 & " --TO�����ׯ�ݸ��ޯ̧�z��")
        End If
        intCount = intCount + 1
        If IsNull(mFDISP_ADDRESS_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDISP_ADDRESS_FM = NULL --FM�\�L�p���ڽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDISP_ADDRESS_FM = NULL --FM�\�L�p���ڽ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDISP_ADDRESS_FM = :" & Ubound(strBindField) - 1 & " --FM�\�L�p���ڽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDISP_ADDRESS_FM = :" & Ubound(strBindField) - 1 & " --FM�\�L�p���ڽ")
        End If
        intCount = intCount + 1
        If IsNull(mFDISP_ADDRESS_TO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDISP_ADDRESS_TO = NULL --TO�\�L�p���ڽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDISP_ADDRESS_TO = NULL --TO�\�L�p���ڽ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS_TO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDISP_ADDRESS_TO = :" & Ubound(strBindField) - 1 & " --TO�\�L�p���ڽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDISP_ADDRESS_TO = :" & Ubound(strBindField) - 1 & " --TO�\�L�p���ڽ")
        End If
        intCount = intCount + 1
        If IsNull(mFDISPLOG_ADDRESS_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDISPLOG_ADDRESS_FM = NULL --FM�\�L�p���ڽ_۸ޗp")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDISPLOG_ADDRESS_FM = NULL --FM�\�L�p���ڽ_۸ޗp")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISPLOG_ADDRESS_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDISPLOG_ADDRESS_FM = :" & Ubound(strBindField) - 1 & " --FM�\�L�p���ڽ_۸ޗp")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDISPLOG_ADDRESS_FM = :" & Ubound(strBindField) - 1 & " --FM�\�L�p���ڽ_۸ޗp")
        End If
        intCount = intCount + 1
        If IsNull(mFDISPLOG_ADDRESS_TO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDISPLOG_ADDRESS_TO = NULL --TO�\�L�p���ڽ_۸ޗp")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDISPLOG_ADDRESS_TO = NULL --TO�\�L�p���ڽ_۸ޗp")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISPLOG_ADDRESS_TO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDISPLOG_ADDRESS_TO = :" & Ubound(strBindField) - 1 & " --TO�\�L�p���ڽ_۸ޗp")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDISPLOG_ADDRESS_TO = :" & Ubound(strBindField) - 1 & " --TO�\�L�p���ڽ_۸ޗp")
        End If
        intCount = intCount + 1
        If IsNull(mFPALLET_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FPALLET_ID = NULL --��گ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FPALLET_ID = NULL --��گ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FPALLET_ID = :" & Ubound(strBindField) - 1 & " --��گ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FPALLET_ID = :" & Ubound(strBindField) - 1 & " --��گ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mFBUF_IN_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FBUF_IN_DT = NULL --�ޯ̧������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FBUF_IN_DT = NULL --�ޯ̧������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_IN_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FBUF_IN_DT = :" & Ubound(strBindField) - 1 & " --�ޯ̧������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FBUF_IN_DT = :" & Ubound(strBindField) - 1 & " --�ޯ̧������")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_BUNRUI) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_BUNRUI = NULL --�I����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_BUNRUI = NULL --�I����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_BUNRUI
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_BUNRUI = :" & Ubound(strBindField) - 1 & " --�I����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_BUNRUI = :" & Ubound(strBindField) - 1 & " --�I����")
        End If
        intCount = intCount + 1
        If IsNull(mXTANA_BLOCK) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTANA_BLOCK = NULL --�I��ۯ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTANA_BLOCK = NULL --�I��ۯ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTANA_BLOCK
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTANA_BLOCK = :" & Ubound(strBindField) - 1 & " --�I��ۯ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTANA_BLOCK = :" & Ubound(strBindField) - 1 & " --�I��ۯ�")
        End If
        intCount = intCount + 1
        If IsNull(mXTANA_BLOCK_DTL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTANA_BLOCK_DTL = NULL --�I��ۯ��ڍ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTANA_BLOCK_DTL = NULL --�I��ۯ��ڍ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTANA_BLOCK_DTL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTANA_BLOCK_DTL = :" & Ubound(strBindField) - 1 & " --�I��ۯ��ڍ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTANA_BLOCK_DTL = :" & Ubound(strBindField) - 1 & " --�I��ۯ��ڍ�")
        End If
        intCount = intCount + 1
        If IsNull(mXTANA_BLOCK_STS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTANA_BLOCK_STS = NULL --�I��ۯ����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTANA_BLOCK_STS = NULL --�I��ۯ����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTANA_BLOCK_STS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTANA_BLOCK_STS = :" & Ubound(strBindField) - 1 & " --�I��ۯ����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTANA_BLOCK_STS = :" & Ubound(strBindField) - 1 & " --�I��ۯ����")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FTRK_BUF_NO) = True Then
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO IS NULL --�ׯ�ݸ��ޯ̧��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FTRK_BUF_ARRAY) = True Then
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_ARRAY IS NULL --�ׯ�ݸ��ޯ̧�z��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_ARRAY
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_ARRAY = :" & UBound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧�z��")
        End If


        '***********************
        '�޲��ޕϐ���`
        '***********************
        objParameter = Nothing
        ReDim Preserve objParameter(2, UBound(strBindField) - 1)
        Dim ii As Integer
        For ii = LBound(strBindField) + 1 To UBound(strBindField)
            objParameter(0, ii - 1) = strBindField(ii)
            objParameter(1, ii - 1) = objBindValue(ii)
        Next ii


        '***********************
        '�X�V
        '***********************
        ObjDb.Parameter = objParameter
        intRetSQL = ObjDb.Execute(strSQL.ToString)
        If intRetSQL = -1 Then
            '(SQL�װ)
            strMsg = ERRMSG_ERR_UPDATE & " " & ObjDb.ErrMsg & "[" & Replace(strSQL.ToString, vbCrLf, "") & "]"
            Throw New UserException(strMsg)
        End If
        If intRetSQL < 1 Then
            '(�Ώۍs����)
            strMsg = ERRMSG_ERR_UPDATE & "[�Ώۍs����]"
            Throw New UserException(strMsg)
        End If


    End Sub
#End Region
#Region "  �ް��ǉ�                     "
    '''**********************************************************************************************
    ''' <summary>
    ''' �ް��ǉ�
    ''' </summary>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub ADD_TPRG_TRK_BUF()
        Dim strSQL As New StringBuilder     'SQL��
        Dim strMsg As String                'ү����
        Dim intRetSQL As Integer            'SQL���s�߂�l
        Dim objParameter(1, 0) As Object
        Dim strBindField(0) As String
        Dim objBindValue(0) As Object


        '***********************
        '�����è����
        '***********************
        If 1 <> 1 Then
        ElseIf IsNull(mFTRK_BUF_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�ׯ�ݸ��ޯ̧��]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFTRK_BUF_ARRAY) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�ׯ�ݸ��ޯ̧�z��]"
            Throw New UserException(strMsg)
        End If


        '***********************
        '�ǉ�SQL�쐬
        '***********************
        strBindField = Nothing
        objBindValue = Nothing
        ReDim Preserve strBindField(0)
        ReDim Preserve objBindValue(0)
        strSQL.Append(vbCrLf & "INSERT INTO")
        strSQL.Append(vbCrLf & "    TPRG_TRK_BUF")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
        If IsNull(mFTRK_BUF_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ׯ�ݸ��ޯ̧��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧��")
        End If
        intCount = intCount + 1
        If IsNull(mFTRK_BUF_ARRAY) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ׯ�ݸ��ޯ̧�z��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ׯ�ݸ��ޯ̧�z��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_ARRAY
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧�z��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧�z��")
        End If
        intCount = intCount + 1
        If IsNull(mFSERCH_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�󌟍�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�󌟍�����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSERCH_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�󌟍�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�󌟍�����")
        End If
        intCount = intCount + 1
        If IsNull(mFTRNS_ADDRESS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�����w���p���ڽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�����w���p���ڽ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_ADDRESS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�����w���p���ڽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�����w���p���ڽ")
        End If
        intCount = intCount + 1
        If IsNull(mFDISP_ADDRESS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�\�L�p���ڽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�\�L�p���ڽ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�\�L�p���ڽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�\�L�p���ڽ")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_RETU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_RETU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --��")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_REN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�A")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�A")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_REN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�A")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�A")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_DAN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�i")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�i")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_DAN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�i")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�i")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_EDA) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�}")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�}")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_EDA
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�}")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�}")
        End If
        intCount = intCount + 1
        If IsNull(mFREMOVE_KIND) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�֎~�L��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�֎~�L��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFREMOVE_KIND
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�֎~�L��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�֎~�L��")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_FORM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�I�`����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�I�`����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_FORM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�I�`����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�I�`����")
        End If
        intCount = intCount + 1
        If IsNull(mFRES_KIND) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRES_KIND
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�������")
        End If
        intCount = intCount + 1
        If IsNull(mFRSV_PALLET) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --��������گ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --��������گ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_PALLET
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --��������گ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --��������گ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mFTR_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����FM�ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����FM�ׯ�ݸ��ޯ̧��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����FM�ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����FM�ׯ�ݸ��ޯ̧��")
        End If
        intCount = intCount + 1
        If IsNull(mFTR_TO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����TO�ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����TO�ׯ�ݸ��ޯ̧��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_TO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����TO�ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����TO�ׯ�ݸ��ޯ̧��")
        End If
        intCount = intCount + 1
        If IsNull(mFTR_IDOU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����TO�ړ��ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����TO�ړ��ׯ�ݸ��ޯ̧��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_IDOU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����TO�ړ��ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����TO�ړ��ׯ�ݸ��ޯ̧��")
        End If
        intCount = intCount + 1
        If IsNull(mFTRNS_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�����w�ߗpFM")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�����w�ߗpFM")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�����w�ߗpFM")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�����w�ߗpFM")
        End If
        intCount = intCount + 1
        If IsNull(mFTRNS_TO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�����w�ߗpTO")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�����w�ߗpTO")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_TO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�����w�ߗpTO")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�����w�ߗpTO")
        End If
        intCount = intCount + 1
        If IsNull(mFRSV_BUF_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --FM�����ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --FM�����ׯ�ݸ��ޯ̧��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_BUF_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --FM�����ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --FM�����ׯ�ݸ��ޯ̧��")
        End If
        intCount = intCount + 1
        If IsNull(mFRSV_ARRAY_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --FM�����ׯ�ݸ��ޯ̧�z��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --FM�����ׯ�ݸ��ޯ̧�z��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_ARRAY_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --FM�����ׯ�ݸ��ޯ̧�z��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --FM�����ׯ�ݸ��ޯ̧�z��")
        End If
        intCount = intCount + 1
        If IsNull(mFRSV_BUF_TO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --TO�����ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --TO�����ׯ�ݸ��ޯ̧��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_BUF_TO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --TO�����ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --TO�����ׯ�ݸ��ޯ̧��")
        End If
        intCount = intCount + 1
        If IsNull(mFRSV_ARRAY_TO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --TO�����ׯ�ݸ��ޯ̧�z��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --TO�����ׯ�ݸ��ޯ̧�z��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_ARRAY_TO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --TO�����ׯ�ݸ��ޯ̧�z��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --TO�����ׯ�ݸ��ޯ̧�z��")
        End If
        intCount = intCount + 1
        If IsNull(mFDISP_ADDRESS_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --FM�\�L�p���ڽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --FM�\�L�p���ڽ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --FM�\�L�p���ڽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --FM�\�L�p���ڽ")
        End If
        intCount = intCount + 1
        If IsNull(mFDISP_ADDRESS_TO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --TO�\�L�p���ڽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --TO�\�L�p���ڽ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS_TO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --TO�\�L�p���ڽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --TO�\�L�p���ڽ")
        End If
        intCount = intCount + 1
        If IsNull(mFDISPLOG_ADDRESS_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --FM�\�L�p���ڽ_۸ޗp")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --FM�\�L�p���ڽ_۸ޗp")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISPLOG_ADDRESS_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --FM�\�L�p���ڽ_۸ޗp")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --FM�\�L�p���ڽ_۸ޗp")
        End If
        intCount = intCount + 1
        If IsNull(mFDISPLOG_ADDRESS_TO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --TO�\�L�p���ڽ_۸ޗp")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --TO�\�L�p���ڽ_۸ޗp")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISPLOG_ADDRESS_TO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --TO�\�L�p���ڽ_۸ޗp")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --TO�\�L�p���ڽ_۸ޗp")
        End If
        intCount = intCount + 1
        If IsNull(mFPALLET_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --��گ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --��گ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --��گ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --��گ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mFBUF_IN_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ޯ̧������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ޯ̧������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_IN_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ޯ̧������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ޯ̧������")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_BUNRUI) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�I����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�I����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_BUNRUI
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�I����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�I����")
        End If
        intCount = intCount + 1
        If IsNull(mXTANA_BLOCK) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�I��ۯ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�I��ۯ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTANA_BLOCK
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�I��ۯ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�I��ۯ�")
        End If
        intCount = intCount + 1
        If IsNull(mXTANA_BLOCK_DTL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�I��ۯ��ڍ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�I��ۯ��ڍ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTANA_BLOCK_DTL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�I��ۯ��ڍ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�I��ۯ��ڍ�")
        End If
        intCount = intCount + 1
        If IsNull(mXTANA_BLOCK_STS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�I��ۯ����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�I��ۯ����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTANA_BLOCK_STS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�I��ۯ����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�I��ۯ����")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " )")


        '***********************
        '�޲��ޕϐ���`
        '***********************
        objParameter = Nothing
        ReDim Preserve objParameter(2, UBound(strBindField) - 1)
        Dim ii As Integer
        For ii = LBound(strBindField) + 1 To UBound(strBindField)
            objParameter(0, ii - 1) = strBindField(ii)
            objParameter(1, ii - 1) = objBindValue(ii)
        Next ii


        '***********************
        '�ǉ�
        '***********************
        ObjDb.Parameter = objParameter
        intRetSQL = ObjDb.Execute(strSQL.ToString)
        If intRetSQL = -1 Then
            '(SQL�װ)
            strMsg = ERRMSG_ERR_ADD & " " & ObjDb.ErrMsg & "[" & Replace(strSQL.ToString, vbCrLf, "") & "]"
            Throw New UserException(strMsg)
        End If


    End Sub
#End Region
#Region "  �ް��폜                     "
    '''**********************************************************************************************
    ''' <summary>
    ''' �ް��폜
    ''' </summary>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub DELETE_TPRG_TRK_BUF()
        Dim strSQL As New StringBuilder     'SQL��
        Dim strMsg As String                'ү����
        Dim intRetSQL As Integer            'SQL���s�߂�l
        Dim objParameter(1, 0) As Object
        Dim strBindField(0) As String
        Dim objBindValue(0) As Object


        '***********************
        '�����è����
        '***********************
        If 1 <> 1 Then
        ElseIf IsNull(mFTRK_BUF_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�ׯ�ݸ��ޯ̧��]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFTRK_BUF_ARRAY) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�ׯ�ݸ��ޯ̧�z��]"
            Throw New UserException(strMsg)
        End If


        '***********************
        '�폜SQL�쐬
        '***********************
        strBindField = Nothing
        objBindValue = Nothing
        ReDim Preserve strBindField(0)
        ReDim Preserve objBindValue(0)
        strSQL.Append(vbCrLf & "DELETE")
        strSQL.Append(vbCrLf & " FROM")
        strSQL.Append(vbCrLf & "    TPRG_TRK_BUF")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FTRK_BUF_NO) = True Then
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO IS NULL --�ׯ�ݸ��ޯ̧��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FTRK_BUF_ARRAY) = True Then
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_ARRAY IS NULL --�ׯ�ݸ��ޯ̧�z��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_ARRAY
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_ARRAY = :" & UBound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧�z��")
        End If


        '***********************
        '�޲��ޕϐ���`
        '***********************
        objParameter = Nothing
        ReDim Preserve objParameter(2, UBound(strBindField) - 1)
        Dim ii As Integer
        For ii = LBound(strBindField) + 1 To UBound(strBindField)
            objParameter(0, ii - 1) = strBindField(ii)
            objParameter(1, ii - 1) = objBindValue(ii)
        Next ii


        '***********************
        '�폜
        '***********************
        ObjDb.Parameter = objParameter
        intRetSQL = ObjDb.Execute(strSQL.ToString)
        If intRetSQL = -1 Then
            '(SQL�װ)
            strMsg = ERRMSG_ERR_DELETE & " " & ObjDb.ErrMsg & "[" & Replace(strSQL.ToString, vbCrLf, "") & "]"
            Throw New UserException(strMsg)
        End If


    End Sub
#End Region
#Region "  �ް��폜(����ں���)          "
    '''**********************************************************************************************
    ''' <summary>
    ''' �ް��폜
    ''' </summary>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub DELETE_TPRG_TRK_BUF_ANY()
        Dim strSQL As New StringBuilder     'SQL��
        Dim strMsg As String                'ү����
        Dim intRetSQL As Integer            'SQL���s�߂�l
        Dim objParameter(1, 0) As Object
        Dim strBindField(0) As String
        Dim objBindValue(0) As Object


        '***********************
        '�폜SQL�쐬
        '***********************
        strBindField = Nothing
        objBindValue = Nothing
        ReDim Preserve strBindField(0)
        ReDim Preserve objBindValue(0)
        strSQL.Append(vbCrLf & "DELETE")
        strSQL.Append(vbCrLf & " FROM")
        strSQL.Append(vbCrLf & "    TPRG_TRK_BUF")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(FTRK_BUF_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧��")
        End If
        If IsNotNull(FTRK_BUF_ARRAY) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_ARRAY
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_ARRAY = :" & UBound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧�z��")
        End If
        If IsNotNull(FSERCH_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSERCH_NO
            strSQL.Append(vbCrLf & "    AND FSERCH_NO = :" & UBound(strBindField) - 1 & " --�󌟍�����")
        End If
        If IsNotNull(FTRNS_ADDRESS) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_ADDRESS
            strSQL.Append(vbCrLf & "    AND FTRNS_ADDRESS = :" & UBound(strBindField) - 1 & " --�����w���p���ڽ")
        End If
        If IsNotNull(FDISP_ADDRESS) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS
            strSQL.Append(vbCrLf & "    AND FDISP_ADDRESS = :" & UBound(strBindField) - 1 & " --�\�L�p���ڽ")
        End If
        If IsNotNull(FRAC_RETU) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_RETU
            strSQL.Append(vbCrLf & "    AND FRAC_RETU = :" & UBound(strBindField) - 1 & " --��")
        End If
        If IsNotNull(FRAC_REN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_REN
            strSQL.Append(vbCrLf & "    AND FRAC_REN = :" & UBound(strBindField) - 1 & " --�A")
        End If
        If IsNotNull(FRAC_DAN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_DAN
            strSQL.Append(vbCrLf & "    AND FRAC_DAN = :" & UBound(strBindField) - 1 & " --�i")
        End If
        If IsNotNull(FRAC_EDA) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_EDA
            strSQL.Append(vbCrLf & "    AND FRAC_EDA = :" & UBound(strBindField) - 1 & " --�}")
        End If
        If IsNotNull(FREMOVE_KIND) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFREMOVE_KIND
            strSQL.Append(vbCrLf & "    AND FREMOVE_KIND = :" & UBound(strBindField) - 1 & " --�֎~�L��")
        End If
        If IsNotNull(FRAC_FORM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_FORM
            strSQL.Append(vbCrLf & "    AND FRAC_FORM = :" & UBound(strBindField) - 1 & " --�I�`����")
        End If
        If IsNotNull(FRES_KIND) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRES_KIND
            strSQL.Append(vbCrLf & "    AND FRES_KIND = :" & UBound(strBindField) - 1 & " --�������")
        End If
        If IsNotNull(FRSV_PALLET) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_PALLET
            strSQL.Append(vbCrLf & "    AND FRSV_PALLET = :" & UBound(strBindField) - 1 & " --��������گ�ID")
        End If
        If IsNotNull(FTR_FM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_FM
            strSQL.Append(vbCrLf & "    AND FTR_FM = :" & UBound(strBindField) - 1 & " --����FM�ׯ�ݸ��ޯ̧��")
        End If
        If IsNotNull(FTR_TO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_TO
            strSQL.Append(vbCrLf & "    AND FTR_TO = :" & UBound(strBindField) - 1 & " --����TO�ׯ�ݸ��ޯ̧��")
        End If
        If IsNotNull(FTR_IDOU) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_IDOU
            strSQL.Append(vbCrLf & "    AND FTR_IDOU = :" & UBound(strBindField) - 1 & " --����TO�ړ��ׯ�ݸ��ޯ̧��")
        End If
        If IsNotNull(FTRNS_FM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_FM
            strSQL.Append(vbCrLf & "    AND FTRNS_FM = :" & UBound(strBindField) - 1 & " --�����w�ߗpFM")
        End If
        If IsNotNull(FTRNS_TO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_TO
            strSQL.Append(vbCrLf & "    AND FTRNS_TO = :" & UBound(strBindField) - 1 & " --�����w�ߗpTO")
        End If
        If IsNotNull(FRSV_BUF_FM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_BUF_FM
            strSQL.Append(vbCrLf & "    AND FRSV_BUF_FM = :" & UBound(strBindField) - 1 & " --FM�����ׯ�ݸ��ޯ̧��")
        End If
        If IsNotNull(FRSV_ARRAY_FM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_ARRAY_FM
            strSQL.Append(vbCrLf & "    AND FRSV_ARRAY_FM = :" & UBound(strBindField) - 1 & " --FM�����ׯ�ݸ��ޯ̧�z��")
        End If
        If IsNotNull(FRSV_BUF_TO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_BUF_TO
            strSQL.Append(vbCrLf & "    AND FRSV_BUF_TO = :" & UBound(strBindField) - 1 & " --TO�����ׯ�ݸ��ޯ̧��")
        End If
        If IsNotNull(FRSV_ARRAY_TO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_ARRAY_TO
            strSQL.Append(vbCrLf & "    AND FRSV_ARRAY_TO = :" & UBound(strBindField) - 1 & " --TO�����ׯ�ݸ��ޯ̧�z��")
        End If
        If IsNotNull(FDISP_ADDRESS_FM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS_FM
            strSQL.Append(vbCrLf & "    AND FDISP_ADDRESS_FM = :" & UBound(strBindField) - 1 & " --FM�\�L�p���ڽ")
        End If
        If IsNotNull(FDISP_ADDRESS_TO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS_TO
            strSQL.Append(vbCrLf & "    AND FDISP_ADDRESS_TO = :" & UBound(strBindField) - 1 & " --TO�\�L�p���ڽ")
        End If
        If IsNotNull(FDISPLOG_ADDRESS_FM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISPLOG_ADDRESS_FM
            strSQL.Append(vbCrLf & "    AND FDISPLOG_ADDRESS_FM = :" & UBound(strBindField) - 1 & " --FM�\�L�p���ڽ_۸ޗp")
        End If
        If IsNotNull(FDISPLOG_ADDRESS_TO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISPLOG_ADDRESS_TO
            strSQL.Append(vbCrLf & "    AND FDISPLOG_ADDRESS_TO = :" & UBound(strBindField) - 1 & " --TO�\�L�p���ڽ_۸ޗp")
        End If
        If IsNotNull(FPALLET_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --��گ�ID")
        End If
        If IsNotNull(FBUF_IN_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_IN_DT
            strSQL.Append(vbCrLf & "    AND FBUF_IN_DT = :" & UBound(strBindField) - 1 & " --�ޯ̧������")
        End If
        If IsNotNull(FRAC_BUNRUI) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_BUNRUI
            strSQL.Append(vbCrLf & "    AND FRAC_BUNRUI = :" & UBound(strBindField) - 1 & " --�I����")
        End If
        If IsNotNull(XTANA_BLOCK) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTANA_BLOCK
            strSQL.Append(vbCrLf & "    AND XTANA_BLOCK = :" & UBound(strBindField) - 1 & " --�I��ۯ�")
        End If
        If IsNotNull(XTANA_BLOCK_DTL) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTANA_BLOCK_DTL
            strSQL.Append(vbCrLf & "    AND XTANA_BLOCK_DTL = :" & UBound(strBindField) - 1 & " --�I��ۯ��ڍ�")
        End If
        If IsNotNull(XTANA_BLOCK_STS) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTANA_BLOCK_STS
            strSQL.Append(vbCrLf & "    AND XTANA_BLOCK_STS = :" & UBound(strBindField) - 1 & " --�I��ۯ����")
        End If


        '***********************
        '�޲��ޕϐ���`
        '***********************
        objParameter = Nothing
        ReDim Preserve objParameter(2, UBound(strBindField) - 1)
        Dim ii As Integer
        For ii = LBound(strBindField) + 1 To UBound(strBindField)
            objParameter(0, ii - 1) = strBindField(ii)
            objParameter(1, ii - 1) = objBindValue(ii)
        Next ii


        '***********************
        '�폜
        '***********************
        ObjDb.Parameter = objParameter
        intRetSQL = ObjDb.Execute(strSQL.ToString)
        If intRetSQL = -1 Then
            '(SQL�װ)
            strMsg = ERRMSG_ERR_DELETE & " " & ObjDb.ErrMsg & "[" & Replace(strSQL.ToString, vbCrLf, "") & "]"
            Throw New UserException(strMsg)
        End If


    End Sub
#End Region
#Region "  �����è��߰                  "
    Public Sub COPY_PROPERTY(ByVal objObject As Object)


        '***********************
        '�����è�ϐ��־��
        '***********************
        Dim objType As Type = objObject.GetType
        If IsNothing(objType.GetProperty("FTRK_BUF_NO")) = False Then mFTRK_BUF_NO = objObject.FTRK_BUF_NO '�ׯ�ݸ��ޯ̧��
        If IsNothing(objType.GetProperty("FTRK_BUF_ARRAY")) = False Then mFTRK_BUF_ARRAY = objObject.FTRK_BUF_ARRAY '�ׯ�ݸ��ޯ̧�z��
        If IsNothing(objType.GetProperty("FSERCH_NO")) = False Then mFSERCH_NO = objObject.FSERCH_NO '�󌟍�����
        If IsNothing(objType.GetProperty("FTRNS_ADDRESS")) = False Then mFTRNS_ADDRESS = objObject.FTRNS_ADDRESS '�����w���p���ڽ
        If IsNothing(objType.GetProperty("FDISP_ADDRESS")) = False Then mFDISP_ADDRESS = objObject.FDISP_ADDRESS '�\�L�p���ڽ
        If IsNothing(objType.GetProperty("FRAC_RETU")) = False Then mFRAC_RETU = objObject.FRAC_RETU '��
        If IsNothing(objType.GetProperty("FRAC_REN")) = False Then mFRAC_REN = objObject.FRAC_REN '�A
        If IsNothing(objType.GetProperty("FRAC_DAN")) = False Then mFRAC_DAN = objObject.FRAC_DAN '�i
        If IsNothing(objType.GetProperty("FRAC_EDA")) = False Then mFRAC_EDA = objObject.FRAC_EDA '�}
        If IsNothing(objType.GetProperty("FREMOVE_KIND")) = False Then mFREMOVE_KIND = objObject.FREMOVE_KIND '�֎~�L��
        If IsNothing(objType.GetProperty("FRAC_FORM")) = False Then mFRAC_FORM = objObject.FRAC_FORM '�I�`����
        If IsNothing(objType.GetProperty("FRES_KIND")) = False Then mFRES_KIND = objObject.FRES_KIND '�������
        If IsNothing(objType.GetProperty("FRSV_PALLET")) = False Then mFRSV_PALLET = objObject.FRSV_PALLET '��������گ�ID
        If IsNothing(objType.GetProperty("FTR_FM")) = False Then mFTR_FM = objObject.FTR_FM '����FM�ׯ�ݸ��ޯ̧��
        If IsNothing(objType.GetProperty("FTR_TO")) = False Then mFTR_TO = objObject.FTR_TO '����TO�ׯ�ݸ��ޯ̧��
        If IsNothing(objType.GetProperty("FTR_IDOU")) = False Then mFTR_IDOU = objObject.FTR_IDOU '����TO�ړ��ׯ�ݸ��ޯ̧��
        If IsNothing(objType.GetProperty("FTRNS_FM")) = False Then mFTRNS_FM = objObject.FTRNS_FM '�����w�ߗpFM
        If IsNothing(objType.GetProperty("FTRNS_TO")) = False Then mFTRNS_TO = objObject.FTRNS_TO '�����w�ߗpTO
        If IsNothing(objType.GetProperty("FRSV_BUF_FM")) = False Then mFRSV_BUF_FM = objObject.FRSV_BUF_FM 'FM�����ׯ�ݸ��ޯ̧��
        If IsNothing(objType.GetProperty("FRSV_ARRAY_FM")) = False Then mFRSV_ARRAY_FM = objObject.FRSV_ARRAY_FM 'FM�����ׯ�ݸ��ޯ̧�z��
        If IsNothing(objType.GetProperty("FRSV_BUF_TO")) = False Then mFRSV_BUF_TO = objObject.FRSV_BUF_TO 'TO�����ׯ�ݸ��ޯ̧��
        If IsNothing(objType.GetProperty("FRSV_ARRAY_TO")) = False Then mFRSV_ARRAY_TO = objObject.FRSV_ARRAY_TO 'TO�����ׯ�ݸ��ޯ̧�z��
        If IsNothing(objType.GetProperty("FDISP_ADDRESS_FM")) = False Then mFDISP_ADDRESS_FM = objObject.FDISP_ADDRESS_FM 'FM�\�L�p���ڽ
        If IsNothing(objType.GetProperty("FDISP_ADDRESS_TO")) = False Then mFDISP_ADDRESS_TO = objObject.FDISP_ADDRESS_TO 'TO�\�L�p���ڽ
        If IsNothing(objType.GetProperty("FDISPLOG_ADDRESS_FM")) = False Then mFDISPLOG_ADDRESS_FM = objObject.FDISPLOG_ADDRESS_FM 'FM�\�L�p���ڽ_۸ޗp
        If IsNothing(objType.GetProperty("FDISPLOG_ADDRESS_TO")) = False Then mFDISPLOG_ADDRESS_TO = objObject.FDISPLOG_ADDRESS_TO 'TO�\�L�p���ڽ_۸ޗp
        If IsNothing(objType.GetProperty("FPALLET_ID")) = False Then mFPALLET_ID = objObject.FPALLET_ID '��گ�ID
        If IsNothing(objType.GetProperty("FBUF_IN_DT")) = False Then mFBUF_IN_DT = objObject.FBUF_IN_DT '�ޯ̧������
        If IsNothing(objType.GetProperty("FRAC_BUNRUI")) = False Then mFRAC_BUNRUI = objObject.FRAC_BUNRUI '�I����
        If IsNothing(objType.GetProperty("XTANA_BLOCK")) = False Then mXTANA_BLOCK = objObject.XTANA_BLOCK '�I��ۯ�
        If IsNothing(objType.GetProperty("XTANA_BLOCK_DTL")) = False Then mXTANA_BLOCK_DTL = objObject.XTANA_BLOCK_DTL '�I��ۯ��ڍ�
        If IsNothing(objType.GetProperty("XTANA_BLOCK_STS")) = False Then mXTANA_BLOCK_STS = objObject.XTANA_BLOCK_STS '�I��ۯ����

    End Sub
#End Region
#Region "  �����è�ر                   "
    '''**********************************************************************************************
    ''' <summary>
    ''' �����è�ر
    ''' </summary>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub CLEAR_PROPERTY()


        '***********************
        '�����è�ϐ��ر
        '***********************
        Call ARYME_CLEAR()
        mstrUSER_SQL = Nothing
        mFTRK_BUF_NO = Nothing
        mFTRK_BUF_ARRAY = Nothing
        mFSERCH_NO = Nothing
        mFTRNS_ADDRESS = Nothing
        mFDISP_ADDRESS = Nothing
        mFRAC_RETU = Nothing
        mFRAC_REN = Nothing
        mFRAC_DAN = Nothing
        mFRAC_EDA = Nothing
        mFREMOVE_KIND = Nothing
        mFRAC_FORM = Nothing
        mFRES_KIND = Nothing
        mFRSV_PALLET = Nothing
        mFTR_FM = Nothing
        mFTR_TO = Nothing
        mFTR_IDOU = Nothing
        mFTRNS_FM = Nothing
        mFTRNS_TO = Nothing
        mFRSV_BUF_FM = Nothing
        mFRSV_ARRAY_FM = Nothing
        mFRSV_BUF_TO = Nothing
        mFRSV_ARRAY_TO = Nothing
        mFDISP_ADDRESS_FM = Nothing
        mFDISP_ADDRESS_TO = Nothing
        mFDISPLOG_ADDRESS_FM = Nothing
        mFDISPLOG_ADDRESS_TO = Nothing
        mFPALLET_ID = Nothing
        mFBUF_IN_DT = Nothing
        mFRAC_BUNRUI = Nothing
        mXTANA_BLOCK = Nothing
        mXTANA_BLOCK_DTL = Nothing
        mXTANA_BLOCK_STS = Nothing


    End Sub
#End Region
#Region "  AryMe�ر                     "
    Public Sub ARYME_CLEAR()


        If IsNull(mobjAryMe) = False Then
            For ii As Integer = LBound(mobjAryMe) To UBound(mobjAryMe)
                mobjAryMe(ii).CLEAR_PROPERTY()
                mobjAryMe(ii) = Nothing
            Next
            mobjAryMe = Nothing
        End If


    End Sub
#End Region

#Region "  �ް����ϐ�                   "
    '''**********************************************************************************************
    ''' <summary>
    ''' �ް����ϐ�
    ''' </summary>
    ''' <param name="objRow">�ް�ں��޵�޼ު��</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub SET_DATA(ByVal objRow As DataRow)


        '***********************
        '�ް����
        '***********************
        mFTRK_BUF_NO = TO_INTEGER_NULLABLE(objRow("FTRK_BUF_NO"))
        mFTRK_BUF_ARRAY = TO_INTEGER_NULLABLE(objRow("FTRK_BUF_ARRAY"))
        mFSERCH_NO = TO_INTEGER_NULLABLE(objRow("FSERCH_NO"))
        mFTRNS_ADDRESS = TO_STRING_NULLABLE(objRow("FTRNS_ADDRESS"))
        mFDISP_ADDRESS = TO_STRING_NULLABLE(objRow("FDISP_ADDRESS"))
        mFRAC_RETU = TO_INTEGER_NULLABLE(objRow("FRAC_RETU"))
        mFRAC_REN = TO_INTEGER_NULLABLE(objRow("FRAC_REN"))
        mFRAC_DAN = TO_INTEGER_NULLABLE(objRow("FRAC_DAN"))
        mFRAC_EDA = TO_INTEGER_NULLABLE(objRow("FRAC_EDA"))
        mFREMOVE_KIND = TO_INTEGER_NULLABLE(objRow("FREMOVE_KIND"))
        mFRAC_FORM = TO_INTEGER_NULLABLE(objRow("FRAC_FORM"))
        mFRES_KIND = TO_INTEGER_NULLABLE(objRow("FRES_KIND"))
        mFRSV_PALLET = TO_STRING_NULLABLE(objRow("FRSV_PALLET"))
        mFTR_FM = TO_INTEGER_NULLABLE(objRow("FTR_FM"))
        mFTR_TO = TO_INTEGER_NULLABLE(objRow("FTR_TO"))
        mFTR_IDOU = TO_INTEGER_NULLABLE(objRow("FTR_IDOU"))
        mFTRNS_FM = TO_STRING_NULLABLE(objRow("FTRNS_FM"))
        mFTRNS_TO = TO_STRING_NULLABLE(objRow("FTRNS_TO"))
        mFRSV_BUF_FM = TO_INTEGER_NULLABLE(objRow("FRSV_BUF_FM"))
        mFRSV_ARRAY_FM = TO_INTEGER_NULLABLE(objRow("FRSV_ARRAY_FM"))
        mFRSV_BUF_TO = TO_INTEGER_NULLABLE(objRow("FRSV_BUF_TO"))
        mFRSV_ARRAY_TO = TO_INTEGER_NULLABLE(objRow("FRSV_ARRAY_TO"))
        mFDISP_ADDRESS_FM = TO_STRING_NULLABLE(objRow("FDISP_ADDRESS_FM"))
        mFDISP_ADDRESS_TO = TO_STRING_NULLABLE(objRow("FDISP_ADDRESS_TO"))
        mFDISPLOG_ADDRESS_FM = TO_STRING_NULLABLE(objRow("FDISPLOG_ADDRESS_FM"))
        mFDISPLOG_ADDRESS_TO = TO_STRING_NULLABLE(objRow("FDISPLOG_ADDRESS_TO"))
        mFPALLET_ID = TO_STRING_NULLABLE(objRow("FPALLET_ID"))
        mFBUF_IN_DT = TO_DATE_NULLABLE(objRow("FBUF_IN_DT"))
        mFRAC_BUNRUI = TO_STRING_NULLABLE(objRow("FRAC_BUNRUI"))
        mXTANA_BLOCK = TO_INTEGER_NULLABLE(objRow("XTANA_BLOCK"))
        mXTANA_BLOCK_DTL = TO_INTEGER_NULLABLE(objRow("XTANA_BLOCK_DTL"))
        mXTANA_BLOCK_STS = TO_INTEGER_NULLABLE(objRow("XTANA_BLOCK_STS"))


    End Sub
#End Region
#Region "  �װү���ޕ�����쐬01        "
    '''**********************************************************************************************
    ''' <summary>
    ''' �װү���ޕ�����쐬01
    ''' </summary>
    ''' <param name="strMsg">�װү���ޕ�����</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub MAKE_ERRMSG01(ByRef strMsg As String)


        '***********************
        '�ް����
        '***********************
        strMsg = "ں��ނ�������܂���ł����B"
        strMsg &= "[ð��ٖ�:�ׯ�ݸ��ޯ̧]"
        If IsNotNull(FTRK_BUF_NO) Then
            strMsg &= "[�ׯ�ݸ��ޯ̧��:" & FTRK_BUF_NO & "]"
        End If
        If IsNotNull(FTRK_BUF_ARRAY) Then
            strMsg &= "[�ׯ�ݸ��ޯ̧�z��:" & FTRK_BUF_ARRAY & "]"
        End If
        If IsNotNull(FSERCH_NO) Then
            strMsg &= "[�󌟍�����:" & FSERCH_NO & "]"
        End If
        If IsNotNull(FTRNS_ADDRESS) Then
            strMsg &= "[�����w���p���ڽ:" & FTRNS_ADDRESS & "]"
        End If
        If IsNotNull(FDISP_ADDRESS) Then
            strMsg &= "[�\�L�p���ڽ:" & FDISP_ADDRESS & "]"
        End If
        If IsNotNull(FRAC_RETU) Then
            strMsg &= "[��:" & FRAC_RETU & "]"
        End If
        If IsNotNull(FRAC_REN) Then
            strMsg &= "[�A:" & FRAC_REN & "]"
        End If
        If IsNotNull(FRAC_DAN) Then
            strMsg &= "[�i:" & FRAC_DAN & "]"
        End If
        If IsNotNull(FRAC_EDA) Then
            strMsg &= "[�}:" & FRAC_EDA & "]"
        End If
        If IsNotNull(FREMOVE_KIND) Then
            strMsg &= "[�֎~�L��:" & FREMOVE_KIND & "]"
        End If
        If IsNotNull(FRAC_FORM) Then
            strMsg &= "[�I�`����:" & FRAC_FORM & "]"
        End If
        If IsNotNull(FRES_KIND) Then
            strMsg &= "[�������:" & FRES_KIND & "]"
        End If
        If IsNotNull(FRSV_PALLET) Then
            strMsg &= "[��������گ�ID:" & FRSV_PALLET & "]"
        End If
        If IsNotNull(FTR_FM) Then
            strMsg &= "[����FM�ׯ�ݸ��ޯ̧��:" & FTR_FM & "]"
        End If
        If IsNotNull(FTR_TO) Then
            strMsg &= "[����TO�ׯ�ݸ��ޯ̧��:" & FTR_TO & "]"
        End If
        If IsNotNull(FTR_IDOU) Then
            strMsg &= "[����TO�ړ��ׯ�ݸ��ޯ̧��:" & FTR_IDOU & "]"
        End If
        If IsNotNull(FTRNS_FM) Then
            strMsg &= "[�����w�ߗpFM:" & FTRNS_FM & "]"
        End If
        If IsNotNull(FTRNS_TO) Then
            strMsg &= "[�����w�ߗpTO:" & FTRNS_TO & "]"
        End If
        If IsNotNull(FRSV_BUF_FM) Then
            strMsg &= "[FM�����ׯ�ݸ��ޯ̧��:" & FRSV_BUF_FM & "]"
        End If
        If IsNotNull(FRSV_ARRAY_FM) Then
            strMsg &= "[FM�����ׯ�ݸ��ޯ̧�z��:" & FRSV_ARRAY_FM & "]"
        End If
        If IsNotNull(FRSV_BUF_TO) Then
            strMsg &= "[TO�����ׯ�ݸ��ޯ̧��:" & FRSV_BUF_TO & "]"
        End If
        If IsNotNull(FRSV_ARRAY_TO) Then
            strMsg &= "[TO�����ׯ�ݸ��ޯ̧�z��:" & FRSV_ARRAY_TO & "]"
        End If
        If IsNotNull(FDISP_ADDRESS_FM) Then
            strMsg &= "[FM�\�L�p���ڽ:" & FDISP_ADDRESS_FM & "]"
        End If
        If IsNotNull(FDISP_ADDRESS_TO) Then
            strMsg &= "[TO�\�L�p���ڽ:" & FDISP_ADDRESS_TO & "]"
        End If
        If IsNotNull(FDISPLOG_ADDRESS_FM) Then
            strMsg &= "[FM�\�L�p���ڽ_۸ޗp:" & FDISPLOG_ADDRESS_FM & "]"
        End If
        If IsNotNull(FDISPLOG_ADDRESS_TO) Then
            strMsg &= "[TO�\�L�p���ڽ_۸ޗp:" & FDISPLOG_ADDRESS_TO & "]"
        End If
        If IsNotNull(FPALLET_ID) Then
            strMsg &= "[��گ�ID:" & FPALLET_ID & "]"
        End If
        If IsNotNull(FBUF_IN_DT) Then
            strMsg &= "[�ޯ̧������:" & FBUF_IN_DT & "]"
        End If
        If IsNotNull(FRAC_BUNRUI) Then
            strMsg &= "[�I����:" & FRAC_BUNRUI & "]"
        End If
        If IsNotNull(XTANA_BLOCK) Then
            strMsg &= "[�I��ۯ�:" & XTANA_BLOCK & "]"
        End If
        If IsNotNull(XTANA_BLOCK_DTL) Then
            strMsg &= "[�I��ۯ��ڍ�:" & XTANA_BLOCK_DTL & "]"
        End If
        If IsNotNull(XTANA_BLOCK_STS) Then
            strMsg &= "[�I��ۯ����:" & XTANA_BLOCK_STS & "]"
        End If


    End Sub
#End Region
    '����������������
    '**********************************************************************************************

    '**********************************************************************************************
    '���������ы���
#Region "  �׽�ϐ���`"
    '�����è(ð��ٗ�)
    Private mintRETU_MIN As Nullable(Of Integer)            '�����čŏ���
    Private mintRETU_MAX As Nullable(Of Integer)            '�����čő��
    Private mintDAN_MIN As Nullable(Of Integer)             '�����čŏ��i
    Private mintDAN_MAX As Nullable(Of Integer)             '�����čő�i
    Private mintFIFO_STS_FLAG As Nullable(Of Integer)       'FIFO��������׸�(OFF:������ ON:������)
    '������������************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/04/26  ���o�ɗ\��I���擾�@�\�ǉ�
    Private mobjTMST_CRANE As TBL_TMST_CRANE            '�ڰ�Ͻ�
    '������������************************************************************************************************************
#End Region
#Region "  �����è��`"
    Public Property INTRETU_MIN() As Nullable(Of Integer)
        Get
            Return mintRETU_MIN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mintRETU_MIN = Value
        End Set
    End Property
    Public Property INTRETU_MAX() As Nullable(Of Integer)
        Get
            Return mintRETU_MAX
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mintRETU_MAX = Value
        End Set
    End Property
    Public Property INTDAN_MIN() As Nullable(Of Integer)
        Get
            Return mintDAN_MIN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mintDAN_MIN = Value
        End Set
    End Property
    Public Property INTDAN_MAX() As Nullable(Of Integer)
        Get
            Return mintDAN_MAX
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mintDAN_MAX = Value
        End Set
    End Property
    Public Property INTFIFO_STS_FLAG() As Nullable(Of Integer)
        Get
            Return mintFIFO_STS_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mintFIFO_STS_FLAG = Value
        End Set
    End Property
    '������������************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/04/26  ���o�ɗ\��I���擾�@�\�ǉ�
    Public Property objTMST_CRANE() As TBL_TMST_CRANE
        Get
            Return mobjTMST_CRANE
        End Get
        Set(ByVal Value As TBL_TMST_CRANE)
            mobjTMST_CRANE = Value
        End Set
    End Property
    '������������************************************************************************************************************
#End Region
#Region "  �ׯ�ݸ��ޯ̧����  [��������گ�ID]    (Public GET_TPRG_TRK_BUF_RSV_PALLET)"
    Public Function GET_TPRG_TRK_BUF_RSV_PALLET() As RetCode
        Try
            Dim strSQL As String                'SQL��
            Dim strMsg As String                'ү����
            Dim objDataSet As New DataSet       '�ް����
            Dim strDataSetName As String        '�ް���Ė�
            Dim objRow As DataRow               '1ں��ޕ��̃f�[�^


            '***********************
            '�����è����
            '***********************
            If IsNull(mFRSV_PALLET) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[��������گ�ID]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFTRK_BUF_NO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�ׯ�ݸ��ޯ̧��]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '���oSQL�쐬
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    *"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TPRG_TRK_BUF"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FRSV_PALLET = '" & TO_STRING(mFRSV_PALLET) & "'"    '��������گ�ID
            strSQL &= vbCrLf & "    AND FTRK_BUF_NO = " & TO_STRING(mFTRK_BUF_NO)           '�ޯ̧��
            strSQL &= vbCrLf


            '***********************
            '���o
            '***********************
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TPRG_TRK_BUF"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            '������������************************************************************************************************************
            'Checked SystemMate:N.Dounoshita 2011/10/19 ����ں��ގ擾�װ�ɑΉ�

            If objDataSet.Tables(strDataSetName).Rows.Count <= 0 Then
                Return (RetCode.NotFound)
            ElseIf objDataSet.Tables(strDataSetName).Rows.Count = 1 Then
                objRow = objDataSet.Tables(strDataSetName).Rows(0)
                Call SET_DATA(objRow)
                Return (RetCode.OK)
            Else
                Throw New Exception("����ں��ޒ��o�����ׁA�װ�Ƃ��܂��B")
            End If

            'If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            '    objRow = objDataSet.Tables(strDataSetName).Rows(0)
            '    Call SET_DATA(objRow)
            '    Return (RetCode.OK)
            'Else
            '    Return (RetCode.NotFound)
            'End If

            '������������************************************************************************************************************


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region
#Region "  �ׯ�ݸ��ޯ̧����  [�󕽒u��] (Public GET_TPRG_TRK_BUF_AKI_HIRA)"
    Public Function GET_TPRG_TRK_BUF_AKI_HIRA() As RetCode
        Try
            Dim strSQL As String                'SQL��
            Dim strMsg As String                'ү����
            Dim objDataSet As New DataSet       '�ް����
            Dim strDataSetName As String        '�ް���Ė�
            Dim objRow As DataRow               '1ں��ޕ��̃f�[�^


            '***********************
            '�����è����
            '***********************
            If IsNull(mFTRK_BUF_NO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�ޯ̧No]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '���oSQL�쐬
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    *"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TPRG_TRK_BUF"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FTRK_BUF_NO = " & TO_STRING(mFTRK_BUF_NO)               '�ޯ̧No
            strSQL &= vbCrLf & "    AND FTRK_BUF_ARRAY = ("                                     '�z��No
            strSQL &= vbCrLf & "        SELECT"
            strSQL &= vbCrLf & "            MIN(FTRK_BUF_ARRAY)"
            strSQL &= vbCrLf & "         FROM"
            strSQL &= vbCrLf & "            TPRG_TRK_BUF"
            strSQL &= vbCrLf & "         WHERE"
            strSQL &= vbCrLf & "                FTRK_BUF_NO = " & TO_STRING(mFTRK_BUF_NO)       '�ޯ̧No
            strSQL &= vbCrLf & "            AND FPALLET_ID IS NULL"                             '��گ�ID
            strSQL &= vbCrLf & "            AND FRES_KIND = " & TO_STRING(FRES_KIND_SAKI)        '�݌Ɉ������
            strSQL &= vbCrLf & "            AND FREMOVE_KIND = " & TO_STRING(FLAG_OFF)          '�֎~�L��
            strSQL &= vbCrLf & "    )"
            strSQL &= vbCrLf


            '***********************
            '���o
            '***********************
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TPRG_TRK_BUF"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                objRow = objDataSet.Tables(strDataSetName).Rows(0)
                Call SET_DATA(objRow)
                Return (RetCode.OK)
            Else
                Return (RetCode.NotFound)
            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "  �ׯ�ݸ��ޯ̧����  [FIFO�݌�] (Public GET_TPRG_TRK_BUF_FIFO)"
    '������������************************************************************************************************************
    'SystemMate:N.Dounoshita 2013/03/25  �����ׯ�ݸގ擾�\�Ȃ悤�ɂ���
    Public Function GET_TPRG_TRK_BUF_FIFO(Optional ByVal blnAll As Boolean = False) As RetCode
        'Public Function GET_TPRG_TRK_BUF_FIFO() As RetCode
        '������������************************************************************************************************************
        Try
            Dim strSQL As String                'SQL��
            Dim strMsg As String                'ү����
            Dim objDataSet As New DataSet       '�ް����
            Dim strDataSetName As String        '�ް���Ė�
            Dim objRow As DataRow               '1ں��ޕ��̃f�[�^


            '***********************
            '�����è����
            '***********************
            If IsNull(mFTRK_BUF_NO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�ޯ̧��]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '���oSQL�쐬
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    *"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TPRG_TRK_BUF"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FTRK_BUF_NO = " & TO_STRING(mFTRK_BUF_NO)   '�ޯ̧No
            strSQL &= vbCrLf & "    AND FPALLET_ID IS NOT NULL"                     '��گ�ID
            If IsNotNull(mFTR_TO) Then
                strSQL &= vbCrLf & "    AND FTR_TO = " & TO_STRING(mFTR_TO)             '����TO�ׯ�ݸ��ޯ̧��
            End If
            If IsNotNull(mFTR_FM) Then
                strSQL &= vbCrLf & "    AND FTR_FM = " & TO_STRING(mFTR_FM)             '����FM�ׯ�ݸ��ޯ̧��
            End If
            If IsNotNull(mFRSV_BUF_TO) Then
                strSQL &= vbCrLf & "    AND FRSV_BUF_TO = " & TO_STRING(mFRSV_BUF_TO)   'TO�����ׯ�ݸ��ޯ̧��
            End If
            strSQL &= vbCrLf & " ORDER BY"
            strSQL &= vbCrLf & "    FBUF_IN_DT"                                     '�ޯ̧������
            strSQL &= vbCrLf & "   ,FTRK_BUF_ARRAY"                                 '�z��No
            strSQL &= vbCrLf


            '-----------------------
            '���o
            '-----------------------
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TPRG_TRK_BUF"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then

                If blnAll = True Then
                    '(�S�擾�̏ꍇ)
                    ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
                    For ii As Integer = LBound(mobjAryMe) To UBound(mobjAryMe)
                        objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                        mobjAryMe(ii) = New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                        mobjAryMe(ii).SET_DATA(objRow)
                    Next ii
                Else
                    '(�ꌏ�擾�̏ꍇ)
                    objRow = objDataSet.Tables(strDataSetName).Rows(0)
                    Call SET_DATA(objRow)
                End If

                Return (RetCode.OK)
            Else
                Return (RetCode.NotFound)
            End If


        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
    End Function
#End Region
#Region "  �ׯ�ݸ��ޯ̧����  [����ST�݌�] (Public GET_TPRG_TRK_BUF_ST_IN)"
    Public Function GET_TPRG_TRK_BUF_ST_IN() As RetCode
        Try
            Dim strSQL As String                'SQL��
            'Dim strMsg As String                'ү����
            Dim objDataSet As New DataSet       '�ް����
            'Dim strDataSetName As String        '�ް���Ė�
            'Dim objRow As DataRow               '1ں��ޕ��̃f�[�^


            '***********************
            '���oSQL�쐬
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    *"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TPRG_TRK_BUF"
            strSQL &= vbCrLf & "  , TMST_ST"
            strSQL &= vbCrLf & "  , TMST_TRK"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "      (    TMST_ST.FINOUT_KUBUN = " & TO_STRING(FINOUT_KUBUN_SIN)            '���o�ɋ敪(����)
            strSQL &= vbCrLf & "        OR TMST_ST.FINOUT_KUBUN = " & TO_STRING(FINOUT_KUBUN_SINOUT)         '���o�ɋ敪(���o��)
            strSQL &= vbCrLf & "      )"
            strSQL &= vbCrLf & "    AND TMST_ST.FTRK_BUF_NO = TPRG_TRK_BUF.FTRK_BUF_NO"                     '�ޯ̧No
            strSQL &= vbCrLf & "    AND TMST_TRK.FTRK_BUF_NO = TPRG_TRK_BUF.FTRK_BUF_NO"                     '�ޯ̧No
            strSQL &= vbCrLf & "    AND TMST_TRK.FBUF_KIND = " & FBUF_KIND_SONE                              '�ޯ̧��ʁi���o��ST�j
            strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FPALLET_ID IS NOT NULL"                                '��گ�ID
            strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FRES_KIND = " & TO_STRING(FRES_KIND_SRSV_TRNS_OUT)      '�݌Ɉ������(�����\��)
            strSQL &= vbCrLf & " ORDER BY"
            strSQL &= vbCrLf & "    TPRG_TRK_BUF.FBUF_IN_DT"                                    '�ޯ̧������
            strSQL &= vbCrLf & "   ,TPRG_TRK_BUF.FTRK_BUF_ARRAY"                                '�z��No
            strSQL &= vbCrLf

            mstrUSER_SQL = strSQL
            Dim intRet As RetCode
            intRet = GET_TPRG_TRK_BUF_USER()
            Return intRet


        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
    End Function
#End Region
#Region "  �ׯ�ݸ��ޯ̧����  [��I]     (Public GET_TPRG_TRK_BUF_AKI_RAC)"
    '''************************************************************************************************************
    ''' <summary>
    ''' �ׯ�ݸ��ޯ̧����  [��I]
    ''' </summary>
    ''' <param name="blnAll">�S�Ă̋�I���擾���邩�ۂ�</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''************************************************************************************************************
    Public Function GET_TPRG_TRK_BUF_AKI_RAC(Optional ByVal blnAll As Boolean = False) As RetCode
        Try
            Dim strSQL As String                'SQL��
            Dim strMsg As String                'ү����
            Dim objDataSet As New DataSet       '�ް����
            Dim strDataSetName As String        '�ް���Ė�
            Dim objRow As DataRow               '1ں��ޕ��̃f�[�^


            '***********************
            '�����è����
            '***********************
            If IsNull(mFTRK_BUF_NO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�ޯ̧No]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '���oSQL�쐬
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "         SELECT "
            strSQL &= vbCrLf & "            * "
            strSQL &= vbCrLf & "         FROM"
            strSQL &= vbCrLf & "            TPRG_TRK_BUF,TMST_CRANE,TSTS_EQ_CTRL"
            strSQL &= vbCrLf & "         WHERE"
            strSQL &= vbCrLf & "                TPRG_TRK_BUF.FTRK_BUF_NO = " & TO_STRING(mFTRK_BUF_NO)      '�ׯ�ݸ��ޯ̧No
            strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.FPALLET_ID IS NULL"                            '��گ�ID
            strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.FRES_KIND = " & TO_STRING(FRES_KIND_SAKI)       '�݌Ɉ������
            strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.FREMOVE_KIND = " & TO_STRING(FLAG_OFF)         '�֎~�L��
            If IsNull(mFRAC_FORM) = False Then
                strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.FRAC_FORM = " & TO_STRING(mFRAC_FORM)      '�I�`����
            End If
            If IsNull(mFRAC_BUNRUI) = False Then
                strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.FRAC_BUNRUI = " & TO_STRING(mFRAC_BUNRUI)  '�I����
            End If
            If IsNull(mintRETU_MIN) = False And IsNull(mintRETU_MAX) = False Then
                '(��w��L��̏ꍇ)
                strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.FRAC_RETU >= " & TO_STRING(INTRETU_MIN)    '�ŏ���
                strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.FRAC_RETU <= " & TO_STRING(INTRETU_MAX)    '�ő��
            End If
            If IsNull(mintDAN_MIN) = False And IsNull(mintDAN_MAX) = False Then
                '(�i�w��L��̏ꍇ)
                strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.FRAC_DAN >= " & TO_STRING(INTDAN_MIN)      '�ŏ��i
                strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.FRAC_DAN <= " & TO_STRING(INTDAN_MAX)      '�ő�i
            End If
            strSQL &= vbCrLf & "            AND TMST_CRANE.FTRK_BUF_NO = TPRG_TRK_BUF.FTRK_BUF_NO"          '�ׯ�ݸ��ޯ̧No

            strSQL &= vbCrLf & "            AND TMST_CRANE.FCRANE_ROW1 <= TPRG_TRK_BUF.FRAC_RETU"            '��1
            strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.FRAC_RETU <= TMST_CRANE.FCRANE_ROW2"            '��2

            strSQL &= vbCrLf & "            AND TSTS_EQ_CTRL.FEQ_ID = TMST_CRANE.FEQ_ID"                    '�ݔ�ID
            strSQL &= vbCrLf & "            AND TSTS_EQ_CTRL.FEQ_CUT_STS = " & FEQ_CUT_STS_SOFF              '�ؗ��L��


            '������������************************************************************************************************************
            'JobMate:N.Dounoshita 2013/04/03 ��O�I�A���I����ʂ�����ׂɕK�v
            If IsNull(mFRAC_EDA) = False Then
                strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.FRAC_EDA = " & TO_STRING(mFRAC_EDA)                '�}
            End If
            If IsNull(mXTANA_BLOCK) = False Then
                strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.XTANA_BLOCK = " & TO_STRING(mXTANA_BLOCK)          '�I��ۯ�
            End If
            If IsNull(mXTANA_BLOCK_DTL) = False Then
                strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.XTANA_BLOCK_DTL = " & TO_STRING(mXTANA_BLOCK_DTL)  '�I��ۯ��ڍ�
            End If
            If IsNull(mXTANA_BLOCK_STS) = False Then
                strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.XTANA_BLOCK_STS = " & TO_STRING(mXTANA_BLOCK_STS)  '�I��ۯ����
            End If
            '������������************************************************************************************************************


            strSQL &= vbCrLf & "         ORDER BY "
            strSQL &= vbCrLf & "            TPRG_TRK_BUF.FSERCH_NO "        '�󌟍���No

            strSQL &= vbCrLf


            '***********************
            '���o
            '***********************
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TPRG_TRK_BUF"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then

                If blnAll = True Then
                    '(�S�擾�̏ꍇ)
                    ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
                    For ii As Integer = LBound(mobjAryMe) To UBound(mobjAryMe)
                        objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                        mobjAryMe(ii) = New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                        mobjAryMe(ii).SET_DATA(objRow)
                    Next ii
                Else
                    '(�ꌏ�擾�̏ꍇ)
                    objRow = objDataSet.Tables(strDataSetName).Rows(0)
                    Call SET_DATA(objRow)
                End If

                Return (RetCode.OK)
            Else
                Return (RetCode.NotFound)
            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "  �ׯ�ݸ��ޯ̧����  [�I�Ԃ���] (Public GET_TPRG_TRK_BUF_TANA)"
    Public Function GET_TPRG_TRK_BUF_TANA() As RetCode
        Try
            Dim strSQL As String                'SQL��
            Dim strMsg As String                'ү����
            Dim objDataSet As New DataSet       '�ް����
            Dim strDataSetName As String        '�ް���Ė�
            Dim objRow As DataRow               '1ں��ޕ��̃f�[�^


            '***********************
            '�����è����
            '***********************
            If 1 <> 1 Then
            ElseIf IsNull(mFTRK_BUF_NO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�ׯ�ݸ��ޯ̧��]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFRAC_RETU) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[��]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFRAC_REN) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�A]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFRAC_DAN) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�i]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '���oSQL�쐬
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    *"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TPRG_TRK_BUF"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        1 = 1"
            strSQL &= vbCrLf & "    AND FTRK_BUF_NO = " & mFTRK_BUF_NO      '�ׯ�ݸ��ޯ̧��
            strSQL &= vbCrLf & "    AND FRAC_RETU = " & mFRAC_RETU          '��
            strSQL &= vbCrLf & "    AND FRAC_REN = " & mFRAC_REN            '�A
            strSQL &= vbCrLf & "    AND FRAC_DAN = " & mFRAC_DAN            '�i
            strSQL &= vbCrLf


            '***********************
            '���o
            '***********************
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TPRG_TRK_BUF"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                objRow = objDataSet.Tables(strDataSetName).Rows(0)
                Call SET_DATA(objRow)
                Return (RetCode.OK)
            Else
                Return (RetCode.NotFound)
            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region
#Region "  �ޯ̧����@                  (Public CLEAR_TPRG_TRK_BUF)"
    Public Sub CLEAR_TPRG_TRK_BUF()
        Try
            Dim strSQL As String                    'SQL��
            Dim intRetSQL As Integer                'SQL���s�߂�l
            Dim strMsg As String                    'ү����


            '***********************
            '�����è����
            '***********************
            If IsNull(mFTRK_BUF_NO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�ޯ̧No]"
                Throw New System.Exception(strMsg)
            ElseIf IsNull(mFTRK_BUF_ARRAY) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�z��No]"
                Throw New System.Exception(strMsg)
            End If


            '***********************
            '�X�VSQL�쐬
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "UPDATE"
            strSQL &= vbCrLf & "    TPRG_TRK_BUF"                                   '�ׯ�ݸ��ޯ̧
            strSQL &= vbCrLf & " SET"
            strSQL &= vbCrLf & "    FRES_KIND = " & TO_STRING(FRES_KIND_SAKI)        '�݌Ɉ������
            strSQL &= vbCrLf & "   ,FRSV_PALLET = NULL"                             '��������گ�ID
            strSQL &= vbCrLf & "   ,FTR_FM = NULL"                                  '����FM�ޯ̧��
            strSQL &= vbCrLf & "   ,FTR_TO = NULL"                                  '����TO�ޯ̧��
            strSQL &= vbCrLf & "   ,FTR_IDOU = NULL"                                '����TO�ړ��ޯ̧��
            strSQL &= vbCrLf & "   ,FTRNS_FM = NULL"                                '�����w�ߗpFM
            strSQL &= vbCrLf & "   ,FTRNS_TO = NULL"                                '�����w�ߗpTO
            strSQL &= vbCrLf & "   ,FRSV_BUF_FM = NULL"                             'FM�����ׯ�ݸއ�
            strSQL &= vbCrLf & "   ,FRSV_ARRAY_FM = NULL"                           'FM�����z��
            strSQL &= vbCrLf & "   ,FRSV_BUF_TO = NULL"                             'TO�����ׯ�ݸއ�
            strSQL &= vbCrLf & "   ,FRSV_ARRAY_TO = NULL"                           'TO�����z��
            strSQL &= vbCrLf & "   ,FDISP_ADDRESS_FM = NULL"                        'FM�\�L�p���ڽ
            strSQL &= vbCrLf & "   ,FDISP_ADDRESS_TO = NULL"                        'TO�\�L�p���ڽ
            strSQL &= vbCrLf & "   ,FDISPLOG_ADDRESS_FM = NULL"                     'FM�\�L�p���ڽ_۸ޗp
            strSQL &= vbCrLf & "   ,FDISPLOG_ADDRESS_TO = NULL"                     'TO�\�L�p���ڽ_۸ޗp
            strSQL &= vbCrLf & "   ,FPALLET_ID = NULL"                              '��گ�ID
            strSQL &= vbCrLf & "   ,FBUF_IN_DT = NULL"                              '�ޯ̧������
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "       FTRK_BUF_NO = " & TO_STRING(mFTRK_BUF_NO)          '�ޯ̧No
            strSQL &= vbCrLf & "   AND FTRK_BUF_ARRAY = " & TO_STRING(mFTRK_BUF_ARRAY)    '�z��No
            strSQL &= vbCrLf


            '***********************
            '�֌W���������è�ر
            '***********************
            mFRES_KIND = FRES_KIND_SAKI              '�݌Ɉ������
            mFRSV_PALLET = Nothing                  '��������گ�ID
            mFTR_FM = Nothing                       '����FM�ޯ̧��
            mFTR_TO = Nothing                       '����TO�ޯ̧��
            mFTR_IDOU = Nothing                     '����TO�ړ��ޯ̧��
            mFTRNS_FM = Nothing                     '�����w�ߗpFM
            mFTRNS_TO = Nothing                     '�����w�ߗpTO
            mFRSV_BUF_FM = Nothing                  'FM�����ׯ�ݸއ�
            mFRSV_ARRAY_FM = Nothing                'FM�����z��
            mFRSV_BUF_TO = Nothing                  'TO�����ׯ�ݸއ�
            mFRSV_ARRAY_TO = Nothing                'TO�����z��
            mFDISP_ADDRESS_FM = Nothing             'FM�\�L�p���ڽ
            mFDISP_ADDRESS_TO = Nothing             'TO�\�L�p���ڽ
            mFDISPLOG_ADDRESS_FM = Nothing          'FM�\�L�p���ڽ_۸ޗp
            mFDISPLOG_ADDRESS_TO = Nothing          'TO�\�L�p���ڽ_۸ޗp
            mFPALLET_ID = Nothing                   '��گ�ID
            mFBUF_IN_DT = Nothing                   '�ޯ̧������


            '***********************
            '�X�V
            '***********************
            intRetSQL = ObjDb.Execute(strSQL)
            If intRetSQL = -1 Then
                '(SQL�װ)
                strSQL = Replace(strSQL, vbCrLf, "")
                strMsg = ObjDb.ErrMsg & "�y" & strSQL & "�z"
                strMsg = ERRMSG_ERR_UPDATE & strMsg
                Throw New UserException(strMsg)
            End If
            If intRetSQL <> 1 Then
                '(�X�V�s�s��)
                strSQL = Replace(strSQL, vbCrLf, "")
                strMsg = ERRMSG_ERR_UPDATE & "[ð���:TPRG_TRK_BUF  ,�ޯ̧No:" & TO_STRING(mFTRK_BUF_NO) & "  ,�z��No:" & TO_STRING(mFTRK_BUF_ARRAY) & "]"
                Throw New UserException(strMsg)
            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region
#Region "  �ޯ̧���    [��������گ�ID] (Public CLEAR_TPRG_TRK_BUF_RSV_PC)"
    Public Sub CLEAR_TPRG_TRK_BUF_RSV_PC()
        Try
            Dim strSQL As String                    'SQL��
            Dim intRetSQL As Integer                'SQL���s�߂�l
            Dim strMsg As String                    'ү����


            '***********************
            '�����è����
            '***********************
            If IsNull(mFRSV_PALLET) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[��������گ�ID]"
                Throw New System.Exception(strMsg)
            End If


            '***********************
            '�X�VSQL�쐬
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "UPDATE"
            strSQL &= vbCrLf & "    TPRG_TRK_BUF"                        '�ׯ�ݸ��ޯ̧
            strSQL &= vbCrLf & " SET"
            strSQL &= vbCrLf & "    FRES_KIND = " & TO_STRING(FRES_KIND_SAKI)        '�݌Ɉ������
            strSQL &= vbCrLf & "   ,FRSV_PALLET = NULL"                             '��������گ�ID
            strSQL &= vbCrLf & "   ,FTR_FM = NULL"                                  '����FM�ޯ̧��
            strSQL &= vbCrLf & "   ,FTR_TO = NULL"                                  '����TO�ޯ̧��
            strSQL &= vbCrLf & "   ,FTR_IDOU = NULL"                                '����TO�ړ��ޯ̧��
            strSQL &= vbCrLf & "   ,FTRNS_FM = NULL"                                '�����w�ߗpFM
            strSQL &= vbCrLf & "   ,FTRNS_TO = NULL"                                '�����w�ߗpTO
            strSQL &= vbCrLf & "   ,FRSV_BUF_FM = NULL"                             'FM�����ׯ�ݸއ�
            strSQL &= vbCrLf & "   ,FRSV_ARRAY_FM = NULL"                           'FM�����z��
            strSQL &= vbCrLf & "   ,FRSV_BUF_TO = NULL"                             'TO�����ׯ�ݸއ�
            strSQL &= vbCrLf & "   ,FRSV_ARRAY_TO = NULL"                           'TO�����z��
            strSQL &= vbCrLf & "   ,FDISP_ADDRESS_FM = NULL"                        'FM�\�L�p���ڽ
            strSQL &= vbCrLf & "   ,FDISP_ADDRESS_TO = NULL"                        'TO�\�L�p���ڽ
            strSQL &= vbCrLf & "   ,FPALLET_ID = NULL"                              '��گ�ID
            strSQL &= vbCrLf & "   ,FBUF_IN_DT = NULL"                              '�ޯ̧������
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "       FRSV_PALLET = '" & TO_STRING(mFRSV_PALLET) & "'"     '��������گ�ID
            strSQL &= vbCrLf & "   AND (FPALLET_ID <> '" & TO_STRING(mFRSV_PALLET) & "'"    '��������گ�ID
            strSQL &= vbCrLf & "        OR FPALLET_ID IS NULL)"
            strSQL &= vbCrLf


            '***********************
            '�X�V
            '***********************
            intRetSQL = ObjDb.Execute(strSQL)
            If intRetSQL = -1 Then
                '(SQL�װ)
                strSQL = Replace(strSQL, vbCrLf, "")
                strMsg = ObjDb.ErrMsg & "�y" & strSQL & "�z"
                strMsg = ERRMSG_ERR_UPDATE & strMsg
                Throw New UserException(strMsg)
            End If
            'If intRetSQL <> 1 Then
            '    '(�X�V�s�s��)
            '    strSQL = Replace(strSQL, vbCrLf, "")
            '    strMsg = ERRMSG_ERR_UPDATE & "[ð���:TPRG_TRK_BUF  ,��������گ�ID:" & mFRSV_PALLET & "]"
            '    Throw New UserException(strMsg)
            'End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region
#Region "  TO�\�L�p���ڽ����            (Public GET_FDISP_ADDRESS)"
    Public Function GET_ADDRESS_TO() As String
        Try
            'Dim strMsg As String                'ү����
            Dim objDataSet As New DataSet       '�ް����
            Dim intRet As RetCode               '�߂�l
            Dim strReturn As String             '���g�֐��߂�l


            '***********************
            '�����è����
            '***********************
            If IsNull(mFRSV_BUF_TO) = True Then
                strReturn = DEFAULT_STRING
                Return (strReturn)
            ElseIf IsNull(mFRSV_ARRAY_TO) = True Then
                strReturn = DEFAULT_STRING
                Return (strReturn)
            End If


            '************************
            '�ׯ�ݸ��ޯ̧�̓���
            '************************
            Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)     '�ׯ�ݸ��ޯ̧�׽
            objTPRG_TRK_BUF.FTRK_BUF_NO = mFRSV_BUF_TO          '�ޯ̧��
            objTPRG_TRK_BUF.FTRK_BUF_ARRAY = mFRSV_ARRAY_TO     '�z��
            intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF(False)    '����
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strReturn = DEFAULT_STRING
                '' ''strMsg = ERRMSG_NOTFOUND_BUF & "[�ޯ̧��:" & objTPRG_TRK_BUF.FTRK_BUF_NO & "  ,�ޯ̧�z��:" & objTPRG_TRK_BUF.FTRK_BUF_ARRAY & "]"
                '' ''Throw New UserException(strMsg)
            End If
            strReturn = objTPRG_TRK_BUF.FDISP_ADDRESS


            Return (strReturn)
        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region
#Region "  �ׯ�ݸ��ޯ̧����  [��گĐ�]  (Public GET_TPRG_TRK_PALLET_COUNT)"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' �w�肳�ꂽ�ׯ�ݸ��ޯ̧����گĐ����擾
    ''' </summary>
    ''' <returns>�w�肳�ꂽ�ׯ�ݸ��ޯ̧����گĐ����</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Function GET_TPRG_TRK_PALLET_COUNT() As Integer
        Try
            Dim strSQL As String                'SQL��
            Dim strMsg As String                'ү����
            Dim objDataSet As New DataSet       '�ް����
            Dim strDataSetName As String        '�ް���Ė�
            Dim objRow As DataRow               '1ں��ޕ��̃f�[�^


            '***********************
            '�����è����
            '***********************
            If IsNull(mFTRK_BUF_NO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�ޯ̧��]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '���oSQL�쐬
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    COUNT(*)"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TPRG_TRK_BUF"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FTRK_BUF_NO = " & TO_STRING(mFTRK_BUF_NO)   '�ޯ̧No
            strSQL &= vbCrLf & "    AND FPALLET_ID IS NOT NULL"                     '��گ�ID
            strSQL &= vbCrLf


            '-----------------------
            '���o
            '-----------------------
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TPRG_TRK_BUF"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            objRow = objDataSet.Tables(strDataSetName).Rows(0)
            Return (objRow(0))


        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
    End Function
#End Region
#Region "  �ް��擾 [�������ׯ�ݸގ擾(TO)] "
    ''' <summary>
    ''' �ް��擾 [�������ׯ�ݸގ擾(TO)]
    ''' </summary>
    ''' <returns>���ʖ߂�l</returns>
    ''' <remarks></remarks>
    Public Function GET_TPRG_TRK_BUF_TR_TO() As RetCode
        Try
            Dim strSQL As New StringBuilder     'SQL��
            Dim strMsg As String                'ү����
            Dim objDataSet As New DataSet       '�ް����
            Dim strDataSetName As String        '�ް���Ė�
            Dim objRow As DataRow               '1ں��ޕ����ް�
            Dim objParameter(1, 0) As Object
            Dim strBindField(0) As String
            Dim objBindValue(0) As Object

            '***********************
            '�����è����
            '***********************
            If 1 <> 1 Then
            ElseIf IsNull(mFTR_TO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[����TO�ׯ�ݸ��ޯ̧��]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '���oSQL�쐬
            '***********************
            strBindField = Nothing
            objBindValue = Nothing
            ReDim Preserve strBindField(0)
            ReDim Preserve objBindValue(0)
            strSQL.Append(vbCrLf & "SELECT")
            strSQL.Append(vbCrLf & "    *")
            strSQL.Append(vbCrLf & " FROM")
            strSQL.Append(vbCrLf & "    TPRG_TRK_BUF")
            strSQL.Append(vbCrLf & " WHERE")
            strSQL.Append(vbCrLf & "        1 = 1")
            If IsNull(FTRK_BUF_NO) = True Then
                'NOP
            Else
                ReDim Preserve strBindField(UBound(strBindField) + 1)
                ReDim Preserve objBindValue(UBound(objBindValue) + 1)
                strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
                objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
                strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧��")
            End If

            strSQL.Append(vbCrLf & "    AND FPALLET_ID IS NOT NULL --��گ�ID")

            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_TO
            strSQL.Append(vbCrLf & "    AND FTR_TO = :" & UBound(strBindField) - 1 & " --����TO�ׯ�ݸ��ޯ̧��")

            '***********************
            '�޲��ޕϐ���`
            '***********************
            objParameter = Nothing
            ReDim Preserve objParameter(2, UBound(strBindField) - 1)
            Dim ii As Integer
            For ii = LBound(strBindField) + 1 To UBound(strBindField)
                objParameter(0, ii - 1) = strBindField(ii)
                objParameter(1, ii - 1) = objBindValue(ii)
            Next ii


            '***********************
            '���o
            '***********************
            ObjDb.SQL = strSQL.ToString
            ObjDb.Parameter = objParameter
            objDataSet.Clear()
            strDataSetName = "TPRG_TRK_BUF"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                '������������************************************************************************************************************
                'Checked SystemMate:N.Dounoshita 2011/11/10 ����ں��ގ擾����̂őΉ�
                ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
                For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                    objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                    mobjAryMe(ii) = New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                    mobjAryMe(ii).SET_DATA(objRow)
                Next ii
                'objRow = objDataSet.Tables(strDataSetName).Rows(0)
                'Call SET_DATA(objRow)
                '������������************************************************************************************************************
                Return (RetCode.OK)
            Else
                Return (RetCode.NotFound)
            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "  �ް��擾 [�������ׯ�ݸގ擾(FM)] "
    ''' <summary>
    ''' �ް��擾 [�������ׯ�ݸގ擾(FM)]
    ''' </summary>
    ''' <returns>���ʖ߂�l</returns>
    ''' <remarks></remarks>
    Public Function GET_TPRG_TRK_BUF_TR_FM() As RetCode
        Try
            Dim strSQL As New StringBuilder     'SQL��
            Dim strMsg As String                'ү����
            Dim objDataSet As New DataSet       '�ް����
            Dim strDataSetName As String        '�ް���Ė�
            Dim objRow As DataRow               '1ں��ޕ����ް�
            Dim objParameter(1, 0) As Object
            Dim strBindField(0) As String
            Dim objBindValue(0) As Object

            '***********************
            '�����è����
            '***********************
            If 1 <> 1 Then
            ElseIf IsNull(mFTR_FM) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[����FM�ׯ�ݸ��ޯ̧��]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '���oSQL�쐬
            '***********************
            strBindField = Nothing
            objBindValue = Nothing
            ReDim Preserve strBindField(0)
            ReDim Preserve objBindValue(0)
            strSQL.Append(vbCrLf & "SELECT")
            strSQL.Append(vbCrLf & "    *")
            strSQL.Append(vbCrLf & " FROM")
            strSQL.Append(vbCrLf & "    TPRG_TRK_BUF")
            strSQL.Append(vbCrLf & " WHERE")
            strSQL.Append(vbCrLf & "        1 = 1")
            If IsNull(FTRK_BUF_NO) = True Then
                'NOP
            Else
                ReDim Preserve strBindField(UBound(strBindField) + 1)
                ReDim Preserve objBindValue(UBound(objBindValue) + 1)
                strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
                objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
                strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧��")
            End If

            strSQL.Append(vbCrLf & "    AND FPALLET_ID IS NOT NULL --��گ�ID")

            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_FM
            strSQL.Append(vbCrLf & "    AND FTR_FM = :" & UBound(strBindField) - 1 & " --����FM�ׯ�ݸ��ޯ̧��")

            '***********************
            '�޲��ޕϐ���`
            '***********************
            objParameter = Nothing
            ReDim Preserve objParameter(2, UBound(strBindField) - 1)
            Dim ii As Integer
            For ii = LBound(strBindField) + 1 To UBound(strBindField)
                objParameter(0, ii - 1) = strBindField(ii)
                objParameter(1, ii - 1) = objBindValue(ii)
            Next ii


            '***********************
            '���o
            '***********************
            ObjDb.SQL = strSQL.ToString
            ObjDb.Parameter = objParameter
            objDataSet.Clear()
            strDataSetName = "TPRG_TRK_BUF"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                '������������************************************************************************************************************
                'Checked SystemMate:N.Dounoshita 2011/11/10 ����ں��ގ擾����̂őΉ�
                ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
                For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                    objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                    mobjAryMe(ii) = New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                    mobjAryMe(ii).SET_DATA(objRow)
                Next ii
                'objRow = objDataSet.Tables(strDataSetName).Rows(0)
                'Call SET_DATA(objRow)
                '������������************************************************************************************************************
                Return (RetCode.OK)
            Else
                Return (RetCode.NotFound)
            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "  �������ׯ�ݸޗL������            "
    '''*********************************************************************************************************************
    ''' <summary>
    ''' �������ׯ�ݸޗL������
    ''' </summary>
    ''' <param name="strFTRK_BUF_NO"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''*********************************************************************************************************************
    Public Function CHECK_TPRG_TRK_BUF_RELAY(ByVal strFTRK_BUF_NO As String) As RetCode
        Try
            Dim intRet As RetCode = RetCode.NG


            '****************************************************
            'TO�ƂȂ��Ă����ׯ�ݸ�      ����
            '****************************************************
            Call CLEAR_PROPERTY()
            mFTR_TO = strFTRK_BUF_NO
            intRet = Me.GET_TPRG_TRK_BUF_TR_TO()
            If intRet <> RetCode.OK Then
                '(TO�ƂȂ��Ă����ׯ�ݸނ��Ȃ������ꍇ)


                '****************************************************
                'FM�ƂȂ��Ă����ׯ�ݸ�      ����
                '****************************************************
                Call CLEAR_PROPERTY()
                mFTR_FM = strFTRK_BUF_NO
                intRet = Me.GET_TPRG_TRK_BUF_TR_FM()

            End If


            Return intRet
        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

    '������������************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/04/26  ���o�ɗ\��I���擾�@�\�ǉ�
#Region "  �ׯ�ݸ��ޯ̧����  [���o�ɗ\��I]             "
    '''************************************************************************************************************
    ''' <summary>
    ''' �ׯ�ݸ��ޯ̧����  [���o�ɗ\��I]
    ''' </summary>
    ''' <param name="blnAll">�S�Ă̒I���擾���邩�ۂ�</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''************************************************************************************************************
    Public Function GET_TPRG_TRK_BUF_RESERVE_RAC(Optional ByVal blnAll As Boolean = False) As RetCode
        Try
            Dim strSQL As String                'SQL��
            Dim strMsg As String                'ү����
            Dim objDataSet As New DataSet       '�ް����
            Dim strDataSetName As String        '�ް���Ė�
            Dim objRow As DataRow               '1ں��ޕ��̃f�[�^


            '***********************
            '�����è����
            '***********************
            If IsNull(mFTRK_BUF_NO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�ޯ̧No]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '���oSQL�쐬
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "         SELECT "
            strSQL &= vbCrLf & "            TPRG_TRK_BUF.FTRK_BUF_NO		AS	    FTRK_BUF_NO	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FTRK_BUF_ARRAY	AS      FTRK_BUF_ARRAY	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FSERCH_NO			AS      FSERCH_NO	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FTRNS_ADDRESS		AS      FTRNS_ADDRESS	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FDISP_ADDRESS		AS      FDISP_ADDRESS	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRAC_RETU			AS      FRAC_RETU	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRAC_REN			AS      FRAC_REN	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRAC_DAN			AS      FRAC_DAN	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRAC_EDA			AS      FRAC_EDA	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FREMOVE_KIND		AS      FREMOVE_KIND	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRAC_FORM			AS      FRAC_FORM	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRES_KIND			AS      FRES_KIND	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRSV_PALLET		AS      FRSV_PALLET	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FTR_FM			AS      FTR_FM		 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FTR_TO			AS      FTR_TO		 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FTR_IDOU			AS      FTR_IDOU	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FTRNS_FM			AS      FTRNS_FM	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FTRNS_TO			AS      FTRNS_TO	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRSV_BUF_FM		AS      FRSV_BUF_FM	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRSV_ARRAY_FM		AS      FRSV_ARRAY_FM	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRSV_BUF_TO		AS      FRSV_BUF_TO	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRSV_ARRAY_TO		AS      FRSV_ARRAY_TO	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FDISP_ADDRESS_FM		AS      FDISP_ADDRESS_FM "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FDISP_ADDRESS_TO		AS      FDISP_ADDRESS_TO "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FDISPLOG_ADDRESS_FM	AS      FDISPLOG_ADDRESS_FM "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FDISPLOG_ADDRESS_TO	AS      FDISPLOG_ADDRESS_TO "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FPALLET_ID		AS      FPALLET_ID	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FBUF_IN_DT		AS      FBUF_IN_DT	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRAC_BUNRUI		AS      FRAC_BUNRUI	 "

            '������������************************************************************************************************************
            'JobMate:N.Dounoshita 2013/04/03  �߱�����Ή�

            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.XTANA_BLOCK		AS      XTANA_BLOCK	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.XTANA_BLOCK_DTL	AS      XTANA_BLOCK_DTL	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.XTANA_BLOCK_STS	AS      XTANA_BLOCK_STS	 "

            '������������************************************************************************************************************

            strSQL &= vbCrLf & "         FROM"
            strSQL &= vbCrLf & "            TPRG_TRK_BUF"
            strSQL &= vbCrLf & "           ,TMST_CRANE"
            strSQL &= vbCrLf & "           ,TSTS_EQ_CTRL"
            strSQL &= vbCrLf & "         WHERE"
            strSQL &= vbCrLf & "                TPRG_TRK_BUF.FTRK_BUF_NO = " & TO_STRING(mFTRK_BUF_NO)      '�ׯ�ݸ��ޯ̧No
            strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.FPALLET_ID IS NULL"                            '��گ�ID
            strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.FRES_KIND IN (" & TO_STRING(FRES_KIND_SRSV_TRNS_IN) & _
                                                                        ", " & TO_STRING(FRES_KIND_SRSV_TRNS_OUT) & _
                                                                        ")"                                 '�݌Ɉ������
            strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.FREMOVE_KIND = " & TO_STRING(FLAG_OFF)         '�֎~�L��
            strSQL &= vbCrLf & "            AND TMST_CRANE.FTRK_BUF_NO = TPRG_TRK_BUF.FTRK_BUF_NO"          '�ׯ�ݸ��ޯ̧No
            strSQL &= vbCrLf & "            AND TMST_CRANE.FCRANE_ROW1 <= TPRG_TRK_BUF.FRAC_RETU"           '��1
            strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.FRAC_RETU <= TMST_CRANE.FCRANE_ROW2"           '��2
            strSQL &= vbCrLf & "            AND TSTS_EQ_CTRL.FEQ_ID = TMST_CRANE.FEQ_ID"                    '�ݔ�ID
            strSQL &= vbCrLf & "            AND TSTS_EQ_CTRL.FEQ_CUT_STS = " & FEQ_CUT_STS_SOFF             '�ؗ��L��
            strSQL &= vbCrLf & "            AND TSTS_EQ_CTRL.FEQ_ID = '" & mobjTMST_CRANE.FEQ_ID & "'"      '�ݔ�ID
            strSQL &= vbCrLf & "         ORDER BY "
            strSQL &= vbCrLf & "            TPRG_TRK_BUF.FSERCH_NO "        '�󌟍���No

            strSQL &= vbCrLf


            '***********************
            '���o
            '***********************
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TPRG_TRK_BUF"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then

                If blnAll = True Then
                    '(�S�擾�̏ꍇ)
                    ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
                    For ii As Integer = LBound(mobjAryMe) To UBound(mobjAryMe)
                        objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                        mobjAryMe(ii) = New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                        mobjAryMe(ii).SET_DATA(objRow)
                    Next ii
                Else
                    '(�ꌏ�擾�̏ꍇ)
                    objRow = objDataSet.Tables(strDataSetName).Rows(0)
                    Call SET_DATA(objRow)
                End If

                Return (RetCode.OK)
            Else
                Return (RetCode.NotFound)
            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
    '������������************************************************************************************************************

    '������������************************************************************************************************************
    'SystemMate:A.Noto 2012/05/07  �ׯ�ݸ��ޯ̧����  [���ɒ��A�o�ɒ��A�I�Ԕ��������ׯ�ݸނ��擾][����:�ݔ�ID]
#Region "  �׽�ϐ���`"
    Private mFEQ_ID As String                '�ݔ�ID
#End Region
#Region "  �����è��`"
    Public Property FEQ_ID() As String
        Get
            Return mFEQ_ID
        End Get
        Set(ByVal Value As String)
            mFEQ_ID = Value
        End Set
    End Property
#End Region
#Region "  �ׯ�ݸ��ޯ̧����  [���ɒ��A�o�ɒ��A�I�Ԕ��������ׯ�ݸނ��擾]    [����:�ݔ�ID]                   "
    '''************************************************************************************************************
    ''' <summary>
    ''' �ׯ�ݸ��ޯ̧����  [���ɒ��A�o�ɒ��A�I�Ԕ��������ׯ�ݸނ��擾][����:�ݔ�ID]
    ''' </summary>
    ''' <param name="blnAll">�S�Ă̒I���擾���邩�ۂ�</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''************************************************************************************************************
    Public Function GET_TPRG_TRK_BUF_RELAY(Optional ByVal blnAll As Boolean = False) As RetCode
        Try
            Dim intRet As RetCode


            Dim strFBUF_KIND As String = ""
            strFBUF_KIND = TO_STRING(FBUF_KIND_SIN)
            strFBUF_KIND &= ", " & TO_STRING(FBUF_KIND_SOUT)
            strFBUF_KIND &= ", " & TO_STRING(FBUF_KIND_SSOUKO)
            intRet = GET_TPRG_TRK_BUF_OUT_HANSOU_BASE(blnAll, strFBUF_KIND)


            Return intRet
        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''''************************************************************************************************************
    '''' <summary>
    '''' �ׯ�ݸ��ޯ̧����  [���ɒ��A�o�ɒ��A�I�Ԕ��������ׯ�ݸނ��擾][����:�ݔ�ID]
    '''' </summary>
    '''' <param name="blnAll">�S�Ă̒I���擾���邩�ۂ�</param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    ''''************************************************************************************************************
    'Public Function GET_TPRG_TRK_BUF_RELAY(Optional ByVal blnAll As Boolean = False) As RetCode
    '    Try
    '        Dim strSQL As String                'SQL��
    '        'Dim strMsg As String                'ү����
    '        Dim objDataSet As New DataSet       '�ް����
    '        Dim strDataSetName As String        '�ް���Ė�
    '        Dim objRow As DataRow               '1ں��ޕ��̃f�[�^


    '        '***********************
    '        '�����è����
    '        '***********************
    '        'If IsNull(mFTRK_BUF_NO) = True Then
    '        '    strMsg = ERRMSG_ERR_PROPERTY & "[�ޯ̧No]"
    '        '    Throw New UserException(strMsg)
    '        'ElseIf IsNull(mFEQ_ID) = True Then
    '        '    strMsg = ERRMSG_ERR_PROPERTY & "[�ݔ�ID]"
    '        '    Throw New UserException(strMsg)
    '        'End If


    '        '***********************
    '        '���oSQL�쐬
    '        '***********************
    '        strSQL = ""
    '        strSQL &= vbCrLf & "         SELECT "
    '        strSQL &= vbCrLf & "             TPRG_TRK_BUF.FTRK_BUF_NO       AS      FTRK_BUF_NO	 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FTRK_BUF_ARRAY    AS      FTRK_BUF_ARRAY	 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FSERCH_NO         AS      FSERCH_NO	 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FTRNS_ADDRESS     AS      FTRNS_ADDRESS	 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FDISP_ADDRESS     AS      FDISP_ADDRESS	 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRAC_RETU         AS      FRAC_RETU	 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRAC_REN          AS      FRAC_REN	 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRAC_DAN          AS      FRAC_DAN	 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRAC_EDA          AS      FRAC_EDA	 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FREMOVE_KIND      AS      FREMOVE_KIND	 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRAC_FORM         AS      FRAC_FORM	 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRES_KIND			AS      FRES_KIND	 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRSV_PALLET		AS      FRSV_PALLET	 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FTR_FM			AS      FTR_FM		 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FTR_TO			AS      FTR_TO		 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FTR_IDOU			AS      FTR_IDOU	 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FTRNS_FM			AS      FTRNS_FM	 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FTRNS_TO			AS      FTRNS_TO	 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRSV_BUF_FM		AS      FRSV_BUF_FM	 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRSV_ARRAY_FM		AS      FRSV_ARRAY_FM	 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRSV_BUF_TO		AS      FRSV_BUF_TO	 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRSV_ARRAY_TO		AS      FRSV_ARRAY_TO	 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FDISP_ADDRESS_FM		AS      FDISP_ADDRESS_FM "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FDISP_ADDRESS_TO		AS      FDISP_ADDRESS_TO "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FDISPLOG_ADDRESS_FM	AS      FDISPLOG_ADDRESS_FM "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FDISPLOG_ADDRESS_TO	AS      FDISPLOG_ADDRESS_TO "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FPALLET_ID		AS      FPALLET_ID	 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FBUF_IN_DT		AS      FBUF_IN_DT	 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRAC_BUNRUI		AS      FRAC_BUNRUI	 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.XRAC_PRIORITY		AS      XRAC_PRIORITY	 "
    '        strSQL &= vbCrLf & "         FROM"
    '        strSQL &= vbCrLf & "            TPRG_TRK_BUF"
    '        strSQL &= vbCrLf & "           ,TMST_TRK"
    '        strSQL &= vbCrLf & "           ,TPLN_CARRY_QUE"
    '        strSQL &= vbCrLf & "         WHERE"
    '        strSQL &= vbCrLf & "                    1 = 1"
    '        If IsNotNull(mFEQ_ID) Then
    '            strSQL &= vbCrLf & "            AND TPLN_CARRY_QUE.FEQ_ID = '" & TO_STRING(mFEQ_ID) & "'"           '�ݔ�ID
    '        End If
    '        strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.FPALLET_ID IS NOT NULL"                                '��گ�ID
    '        strSQL &= vbCrLf & "            AND TMST_TRK.FBUF_KIND IN (" & TO_STRING(FBUF_KIND_SIN) & _
    '                                                                ", " & TO_STRING(FBUF_KIND_SOUT) & _
    '                                                                ", " & TO_STRING(FBUF_KIND_SSOUKO) & _
    '                                                                ")"                                         '�ޯ̧���
    '        strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.FTRK_BUF_NO = TMST_TRK.FTRK_BUF_NO"                '�ׯ�ݸ��ޯ̧No
    '        strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.FPALLET_ID = TPLN_CARRY_QUE.FPALLET_ID"            '��گ�ID
    '        strSQL &= vbCrLf & "         ORDER BY "
    '        strSQL &= vbCrLf & "            TPRG_TRK_BUF.FSERCH_NO "                                            '�󌟍���No
    '        strSQL &= vbCrLf


    '        '***********************
    '        '���o
    '        '***********************
    '        ObjDb.SQL = strSQL
    '        objDataSet.Clear()
    '        strDataSetName = "TPRG_TRK_BUF"
    '        ObjDb.GetDataSet(strDataSetName, objDataSet)
    '        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then

    '            If blnAll = True Then
    '                '(�S�擾�̏ꍇ)
    '                ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
    '                For ii As Integer = LBound(mobjAryMe) To UBound(mobjAryMe)
    '                    objRow = objDataSet.Tables(strDataSetName).Rows(ii)
    '                    mobjAryMe(ii) = New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
    '                    mobjAryMe(ii).SET_DATA(objRow)
    '                Next ii
    '            Else
    '                '(�ꌏ�擾�̏ꍇ)
    '                If objDataSet.Tables(strDataSetName).Rows.Count > 1 Then
    '                    '(�������擾�����ꍇ)
    '                    Throw New UserException("���������R�[�h���擾���܂����B")
    '                End If

    '                objRow = objDataSet.Tables(strDataSetName).Rows(0)
    '                Call SET_DATA(objRow)

    '            End If

    '            Return (RetCode.OK)
    '        Else
    '            Return (RetCode.NotFound)
    '        End If

    '    Catch ex As UserException
    '        Throw ex
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function
#End Region
#Region "  �ׯ�ݸ��ޯ̧����  [���o�\��A�����\����ׯ�ݸނ��擾]            [����:�ݔ�ID�A�������]         "
    '''************************************************************************************************************
    ''' <summary>
    ''' �ׯ�ݸ��ޯ̧����  [���o�\��A�����\����ׯ�ݸނ��擾]            [����:�ݔ�ID�A�������]
    ''' </summary>
    ''' <param name="blnAll">�S�Ă̒I���擾���邩�ۂ�</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''************************************************************************************************************
    Public Function GET_TPRG_TRK_BUF_ASRS(Optional ByVal blnAll As Boolean = False) As RetCode
        Try

            Dim intRet As RetCode
            intRet = GET_TPRG_TRK_BUF_OUT_HANSOU_BASE(blnAll, FBUF_KIND_SASRS)

            Return intRet
        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "  �ׯ�ݸ��ޯ̧����  [�������ׯ�ݸނ��ް�]                          [����:�ݔ�ID�A�������]         "
    '''************************************************************************************************************
    ''' <summary>
    ''' �ׯ�ݸ��ޯ̧����  [�������ׯ�ݸނ��ް�]                          [����:�ݔ�ID]
    ''' </summary>
    ''' <param name="blnAll">�S�Ă̒I���擾���邩�ۂ�</param>
    ''' <param name="strFBUF_KIND">�ޯ̧���</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''************************************************************************************************************
    Private Function GET_TPRG_TRK_BUF_OUT_HANSOU_BASE(ByVal blnAll As Boolean _
                                                    , ByVal strFBUF_KIND As String _
                                                      ) As RetCode
        Try
            Dim strSQL As String                'SQL��
            'Dim strMsg As String                'ү����
            Dim objDataSet As New DataSet       '�ް����
            Dim strDataSetName As String        '�ް���Ė�
            Dim objRow As DataRow               '1ں��ޕ��̃f�[�^


            '***********************
            '�����è����
            '***********************
            'If IsNull(mFTRK_BUF_NO) = True Then
            '    strMsg = ERRMSG_ERR_PROPERTY & "[�ޯ̧No]"
            '    Throw New UserException(strMsg)
            'ElseIf IsNull(mFEQ_ID) = True Then
            '    strMsg = ERRMSG_ERR_PROPERTY & "[�ݔ�ID]"
            '    Throw New UserException(strMsg)
            'End If


            '***********************
            '���oSQL�쐬
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "         SELECT "
            strSQL &= vbCrLf & "             TPRG_TRK_BUF.FTRK_BUF_NO       AS      FTRK_BUF_NO	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FTRK_BUF_ARRAY    AS      FTRK_BUF_ARRAY	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FSERCH_NO         AS      FSERCH_NO	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FTRNS_ADDRESS     AS      FTRNS_ADDRESS	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FDISP_ADDRESS     AS      FDISP_ADDRESS	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRAC_RETU         AS      FRAC_RETU	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRAC_REN          AS      FRAC_REN	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRAC_DAN          AS      FRAC_DAN	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRAC_EDA          AS      FRAC_EDA	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FREMOVE_KIND      AS      FREMOVE_KIND	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRAC_FORM         AS      FRAC_FORM	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRES_KIND			AS      FRES_KIND	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRSV_PALLET		AS      FRSV_PALLET	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FTR_FM			AS      FTR_FM		 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FTR_TO			AS      FTR_TO		 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FTR_IDOU			AS      FTR_IDOU	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FTRNS_FM			AS      FTRNS_FM	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FTRNS_TO			AS      FTRNS_TO	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRSV_BUF_FM		AS      FRSV_BUF_FM	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRSV_ARRAY_FM		AS      FRSV_ARRAY_FM	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRSV_BUF_TO		AS      FRSV_BUF_TO	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRSV_ARRAY_TO		AS      FRSV_ARRAY_TO	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FDISP_ADDRESS_FM		AS      FDISP_ADDRESS_FM "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FDISP_ADDRESS_TO		AS      FDISP_ADDRESS_TO "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FDISPLOG_ADDRESS_FM	AS      FDISPLOG_ADDRESS_FM "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FDISPLOG_ADDRESS_TO	AS      FDISPLOG_ADDRESS_TO "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FPALLET_ID		AS      FPALLET_ID	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FBUF_IN_DT		AS      FBUF_IN_DT	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRAC_BUNRUI		AS      FRAC_BUNRUI	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.XRAC_PRIORITY		AS      XRAC_PRIORITY	 "
            strSQL &= vbCrLf & "         FROM"
            strSQL &= vbCrLf & "            TPRG_TRK_BUF"
            strSQL &= vbCrLf & "           ,TMST_TRK"
            strSQL &= vbCrLf & "           ,TPLN_CARRY_QUE"
            strSQL &= vbCrLf & "         WHERE"
            strSQL &= vbCrLf & "                    1 = 1"
            If IsNotNull(mFEQ_ID) Then
                strSQL &= vbCrLf & "            AND TPLN_CARRY_QUE.FEQ_ID = '" & TO_STRING(mFEQ_ID) & "'"           '�ݔ�ID
            End If
            If IsNotNull(mFRES_KIND) Then
                strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.FRES_KIND = '" & TO_STRING(mFRES_KIND) & "'"       '�������
            End If
            strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.FPALLET_ID IS NOT NULL"                                '��گ�ID
            strSQL &= vbCrLf & "            AND TMST_TRK.FBUF_KIND IN (" & strFBUF_KIND & ")"                   '�ޯ̧���
            strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.FTRK_BUF_NO = TMST_TRK.FTRK_BUF_NO"                '�ׯ�ݸ��ޯ̧No
            strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.FPALLET_ID = TPLN_CARRY_QUE.FPALLET_ID"            '��گ�ID
            strSQL &= vbCrLf & "         ORDER BY "
            strSQL &= vbCrLf & "            TPRG_TRK_BUF.FSERCH_NO "                                            '�󌟍���No
            strSQL &= vbCrLf


            '***********************
            '���o
            '***********************
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TPRG_TRK_BUF"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then

                If blnAll = True Then
                    '(�S�擾�̏ꍇ)
                    ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
                    For ii As Integer = LBound(mobjAryMe) To UBound(mobjAryMe)
                        objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                        mobjAryMe(ii) = New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                        mobjAryMe(ii).SET_DATA(objRow)
                    Next ii
                Else
                    '(�ꌏ�擾�̏ꍇ)
                    If objDataSet.Tables(strDataSetName).Rows.Count > 1 Then
                        '(�������擾�����ꍇ)
                        Throw New UserException("���������R�[�h���擾���܂����B")
                    End If

                    objRow = objDataSet.Tables(strDataSetName).Rows(0)
                    Call SET_DATA(objRow)

                End If

                Return (RetCode.OK)
            Else
                Return (RetCode.NotFound)
            End If

        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
    '������������************************************************************************************************************

    '������������************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/08/21  ���o�\��ST�̎擾
#Region "  �ׯ�ݸ��ޯ̧����  [���o�\��ST]             "
    '''************************************************************************************************************
    ''' <summary>
    ''' �ׯ�ݸ��ޯ̧����  [���o�\��ST]
    ''' </summary>
    ''' <param name="blnAll">�S�Ă̒I���擾���邩�ۂ�</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''************************************************************************************************************
    Public Function GET_TPRG_TRK_BUF_RESERVE_IN_ST(Optional ByVal blnAll As Boolean = False) As RetCode
        Try
            Dim strSQL As String                'SQL��
            Dim strMsg As String                'ү����
            Dim objDataSet As New DataSet       '�ް����
            Dim strDataSetName As String        '�ް���Ė�
            Dim objRow As DataRow               '1ں��ޕ��̃f�[�^


            '***********************
            '�����è����
            '***********************
            If IsNull(mFTRK_BUF_NO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�ޯ̧No]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '���oSQL�쐬
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "         SELECT "
            strSQL &= vbCrLf & "            * "
            strSQL &= vbCrLf & "         FROM "
            strSQL &= vbCrLf & "            TPRG_TRK_BUF"
            strSQL &= vbCrLf & "         WHERE"
            strSQL &= vbCrLf & "                FTRK_BUF_NO = " & TO_STRING(mFTRK_BUF_NO)      '�ׯ�ݸ��ޯ̧No
            strSQL &= vbCrLf & "            AND FPALLET_ID IS NULL"                            '��گ�ID
            strSQL &= vbCrLf & "            AND FRES_KIND IN (" & TO_STRING(FRES_KIND_SRSV_TRNS_IN) & ")"          '�݌Ɉ������
            strSQL &= vbCrLf & "         ORDER BY "
            strSQL &= vbCrLf & "            FBUF_IN_DT ASC "        '�ޯ̧������
            strSQL &= vbCrLf


            '***********************
            '���o
            '***********************
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TPRG_TRK_BUF"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then

                If blnAll = True Then
                    '(�S�擾�̏ꍇ)
                    ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
                    For ii As Integer = LBound(mobjAryMe) To UBound(mobjAryMe)
                        objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                        mobjAryMe(ii) = New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                        mobjAryMe(ii).SET_DATA(objRow)
                    Next ii
                Else
                    '(�ꌏ�擾�̏ꍇ)
                    objRow = objDataSet.Tables(strDataSetName).Rows(0)
                    Call SET_DATA(objRow)
                End If

                Return (RetCode.OK)
            Else
                Return (RetCode.NotFound)
            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
    '������������************************************************************************************************************

    '���������ы���
    '**********************************************************************************************


    '**********************************************************************************************
    '���������ьŗL

    '������������************************************************************************************************************
    'JobMate:A.Noto 2012/07/03  �֎~�I�ꊇ�ݒ�֐��ǉ�
#Region "  �׽�ϐ���`"
    Private mFRAC_RETU_FROM As Integer          '��(FROM)
    Private mFRAC_RETU_TO As Integer            '��(TO)
    Private mFRAC_REN_FROM As Integer           '�A(FROM)
    Private mFRAC_REN_TO As Integer             '�A(TO)
    Private mFRAC_DAN_FROM As Integer           '�i(FROM)
    Private mFRAC_DAN_TO As Integer             '�i(TO)
#End Region
#Region "  �����è��`"
    Public Property FRAC_RETU_FROM() As Integer
        Get
            Return mFRAC_RETU_FROM
        End Get
        Set(ByVal Value As Integer)
            mFRAC_RETU_FROM = Value
        End Set
    End Property
    Public Property FRAC_RETU_TO() As Integer
        Get
            Return mFRAC_RETU_TO
        End Get
        Set(ByVal Value As Integer)
            mFRAC_RETU_TO = Value
        End Set
    End Property
    Public Property FRAC_REN_FROM() As Integer
        Get
            Return mFRAC_REN_FROM
        End Get
        Set(ByVal Value As Integer)
            mFRAC_REN_FROM = Value
        End Set
    End Property
    Public Property FRAC_REN_TO() As Integer
        Get
            Return mFRAC_REN_TO
        End Get
        Set(ByVal Value As Integer)
            mFRAC_REN_TO = Value
        End Set
    End Property
    Public Property FRAC_DAN_FROM() As Integer
        Get
            Return mFRAC_DAN_FROM
        End Get
        Set(ByVal Value As Integer)
            mFRAC_DAN_FROM = Value
        End Set
    End Property
    Public Property FRAC_DAN_TO() As Integer
        Get
            Return mFRAC_DAN_TO
        End Get
        Set(ByVal Value As Integer)
            mFRAC_DAN_TO = Value
        End Set
    End Property
#End Region
#Region "  �֎~�I�ꊇ�X�V (Public UPDATE_TPRG_TRK_BUF_FREMOVE_KIND)"
    Public Sub UPDATE_TPRG_TRK_BUF_FREMOVE_KIND()
        Try
            Dim strSQL As String                    'SQL��
            Dim intRetSQL As Integer                'SQL���s�߂�l
            Dim strMsg As String                    'ү����

            '***********************
            '�����è����
            '***********************
            If IsNull(mFREMOVE_KIND) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�֎~�L��]"
                Throw New UserException(strMsg)
            End If

            '***********************
            '�X�VSQL�쐬
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "UPDATE"
            strSQL &= vbCrLf & "    TPRG_TRK_BUF"                                   '�ׯ�ݸ��ޯ̧
            strSQL &= vbCrLf & " SET"
            strSQL &= vbCrLf & "    FREMOVE_KIND = " & TO_INTEGER(mFREMOVE_KIND)    '�֎~�L��
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "    1 = 1 "
            If mFRAC_RETU_FROM <> 0 Then
                strSQL &= vbCrLf & "   AND FRAC_RETU >= " & TO_INTEGER(mFRAC_RETU_FROM)         '��(FROM)
            End If
            If mFRAC_RETU_TO <> 0 Then
                strSQL &= vbCrLf & "   AND FRAC_RETU <= " & TO_INTEGER(mFRAC_RETU_TO)           '��(TO)
            End If
            If mFRAC_REN_FROM <> 0 Then
                strSQL &= vbCrLf & "   AND FRAC_REN >= " & TO_INTEGER(mFRAC_REN_FROM)           '�A(FROM)
            End If
            If mFRAC_REN_TO <> 0 Then
                strSQL &= vbCrLf & "   AND FRAC_REN <= " & TO_INTEGER(mFRAC_REN_TO)             '�A(TO)
            End If
            If mFRAC_DAN_FROM <> 0 Then
                strSQL &= vbCrLf & "   AND FRAC_DAN >= " & TO_INTEGER(mFRAC_DAN_FROM)           '�i(FROM)
            End If
            If mFRAC_DAN_TO <> 0 Then
                strSQL &= vbCrLf & "   AND FRAC_DAN <= " & TO_INTEGER(mFRAC_DAN_TO)             '�i(TO)
            End If

            strSQL &= vbCrLf & "   AND FREMOVE_KIND <> " & TO_INTEGER(FREMOVE_KIND_SNON)        '�֎~�L��(�����I�ȊO)
            strSQL &= vbCrLf


            '***********************
            '�X�V
            '***********************
            intRetSQL = ObjDb.Execute(strSQL)
            If intRetSQL = -1 Then
                '(SQL�װ)
                strSQL = Replace(strSQL, vbCrLf, "")
                strMsg = ObjDb.ErrMsg & "�y" & strSQL & "�z"
                strMsg = ERRMSG_ERR_UPDATE & strMsg
                Throw New UserException(strMsg)
            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region


    '������������************************************************************************************************************

#Region "  �ׯ�ݸ�����      [�o�ɒ����ׯ�ݸނ����邩�ۂ�]                           [����:�ׯ�ݸ��ޯ̧��]       "
    Public Function GET_TPRG_TRK_BUF_COUNT_OUT_TRK() As RetCode
        Try
            Dim strSQL As String                'SQL��
            Dim strMsg As String                'ү����
            Dim objDataSet As New DataSet       '�ް����
            Dim strDataSetName As String        '�ް���Ė�
            Dim objRow As DataRow               '1ں��ޕ��̃f�[�^


            '***********************
            '�����è����
            '***********************
            If IsNull(mFTRK_BUF_NO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�ޯ̧No]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '���oSQL�쐬
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    COUNT(*)"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TPRG_TRK_BUF"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FTRK_BUF_NO = " & TO_STRING(mFTRK_BUF_NO)       '�ޯ̧No
            strSQL &= vbCrLf & "    AND FRES_KIND <> " & FRES_KIND_SAKI                 '�݌Ɉ������
            strSQL &= vbCrLf


            '***********************
            '���o
            '***********************
            ObjDb.SQL = strSQL.ToString
            objDataSet.Clear()
            strDataSetName = "TPRG_TRK_BUF"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            objRow = objDataSet.Tables(strDataSetName).Rows(0)
            Return (objRow(0))


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "  �ׯ�ݸ�����      [����������ׯ�ݸނ����݂��邩�ۂ�]                     "
    Public Function GET_TPRG_TRK_BUF_COUNT_ZAIKO() As RetCode
        Try
            Dim strSQL As String                'SQL��
            Dim strMsg As String                'ү����
            Dim objDataSet As New DataSet       '�ް����
            Dim strDataSetName As String        '�ް���Ė�
            Dim objRow As DataRow               '1ں��ޕ��̃f�[�^


            '***********************
            '�����è����
            '***********************
            If IsNull(mFTRK_BUF_NO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�ޯ̧No]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '���oSQL�쐬
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    COUNT(*)"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TPRG_TRK_BUF"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FTRK_BUF_NO = " & TO_STRING(mFTRK_BUF_NO)       '�ޯ̧No
            strSQL &= vbCrLf & "    AND FRES_KIND <> " & FRES_KIND_SAKI                 '�݌Ɉ������
            strSQL &= vbCrLf


            '***********************
            '���o
            '***********************
            ObjDb.SQL = strSQL.ToString
            objDataSet.Clear()
            strDataSetName = "TPRG_TRK_BUF"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            objRow = objDataSet.Tables(strDataSetName).Rows(0)
            Return (objRow(0))


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

    '    '�I��ۯ��ڍ�(Where��Ŏg�p�������)
    '#Region "  �׽�ϐ���`"
    '    Private mstrXTANA_BLOCK_DTL_WhereIn As String       '�I��ۯ��ڍ�(Where��Ŏg�p�������)
    '#End Region
    '#Region "  �����è��`"
    '    Public Property strXTANA_BLOCK_DTL_WhereIn() As String
    '        Get
    '            Return mstrXTANA_BLOCK_DTL_WhereIn
    '        End Get
    '        Set(ByVal Value As String)
    '            mstrXTANA_BLOCK_DTL_WhereIn = Value
    '        End Set
    '    End Property
    '#End Region


    '������������************************************************************************************************************
    'JobMate:S.Ouchi 2013/11/08 ��I�����ύX
#Region "  ���ɒ��ׯ�ݸގ擾            (Public GET_TPRG_TRK_BUF_NI_NUM)"
    ''' <summary>
    ''' ���ɒ��ׯ�ݸގ擾
    ''' </summary>
    ''' <param name="strFEQ_ID">�ڰݐݔ�ID</param>
    ''' <param name="strFHENSU_ID">�ڰݗD�揇 �ϐ�ID</param>
    ''' <returns>���ɒ�����</returns>
    ''' <remarks></remarks>
    Public Function GET_TPRG_TRK_BUF_NI_NUM(ByVal strFEQ_ID As String, ByVal strFHENSU_ID As String) As Integer
        Try
            Dim strSQL As String                'SQL��
            Dim objDataSet As New DataSet       '�ް����
            Dim strDataSetName As String        '�ް���Ė�

            '***********************
            '���oSQL�쐬
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "         SELECT "
            strSQL &= vbCrLf & "            BB.FTRK_BUF_NO "
            strSQL &= vbCrLf & "           ,BB.FTRK_BUF_ARRAY "
            strSQL &= vbCrLf & "           ,BB.FPALLET_ID "
            strSQL &= vbCrLf & "         FROM"
            strSQL &= vbCrLf & "            TPRG_TRK_BUF AA"
            strSQL &= vbCrLf & "           ,TPRG_TRK_BUF BB"
            strSQL &= vbCrLf & "           ,TMST_CRANE"
            strSQL &= vbCrLf & "         WHERE"
            strSQL &= vbCrLf & "                TMST_CRANE.FEQ_ID = '" & strFEQ_ID & "'"                        '�ڰݐݔ�ID
            strSQL &= vbCrLf & "            AND TMST_CRANE.FTRK_BUF_NO = AA.FTRK_BUF_NO"                        '�ׯ�ݸ��ޯ̧No
            strSQL &= vbCrLf & "            AND TMST_CRANE.FCRANE_ROW1 <= AA.FRAC_RETU"                         '��1
            strSQL &= vbCrLf & "            AND AA.FRAC_RETU <= TMST_CRANE.FCRANE_ROW2"                         '��2
            strSQL &= vbCrLf & "            AND AA.FTRK_BUF_NO = " & TO_STRING(FTRK_BUF_NO_J9000)               '�ׯ�ݸ��ޯ̧No(�����q��)
            strSQL &= vbCrLf & "            AND AA.FRSV_PALLET IS NOT NULL"                                     '��������گ�ID
            strSQL &= vbCrLf & "            AND AA.FRSV_PALLET = BB.FPALLET_ID"                                 '��گ�ID

            If strFHENSU_ID = FHENSU_ID_SSJ000000_051 Then
                strSQL &= vbCrLf & "            AND ((1000 <= BB.FTRK_BUF_NO AND BB.FTRK_BUF_NO <= 1999)"       '�ׯ�ݸ��ޯ̧No(1F����CV)
                strSQL &= vbCrLf & "              OR (4000 <= BB.FTRK_BUF_NO AND BB.FTRK_BUF_NO <= 4999)"       '�ׯ�ݸ��ޯ̧No(1F����CV�҂�)
                strSQL &= vbCrLf & "              OR BB.FTRK_BUF_NO = " & TO_STRING(FTRK_BUF_NO_J3301)          '�ׯ�ݸ��ޯ̧No(1F���ɔ�����)
                strSQL &= vbCrLf & "              OR BB.FTRK_BUF_NO = " & TO_STRING(FTRK_BUF_NO_J3101) & ")"    '�ׯ�ݸ��ޯ̧No(1F���ɒ�)
            Else
                strSQL &= vbCrLf & "            AND ((2000 <= BB.FTRK_BUF_NO AND BB.FTRK_BUF_NO <= 2999)"       '�ׯ�ݸ��ޯ̧No(2F����CV)
                strSQL &= vbCrLf & "              OR (5000 <= BB.FTRK_BUF_NO AND BB.FTRK_BUF_NO <= 5999)"       '�ׯ�ݸ��ޯ̧No(2F����CV�҂�)
                strSQL &= vbCrLf & "              OR BB.FTRK_BUF_NO = " & TO_STRING(FTRK_BUF_NO_J3302)          '�ׯ�ݸ��ޯ̧No(2F���ɔ�����)
                strSQL &= vbCrLf & "              OR BB.FTRK_BUF_NO = " & TO_STRING(FTRK_BUF_NO_J3102) & ")"    '�ׯ�ݸ��ޯ̧No(2F���ɒ�)
            End If

            strSQL &= vbCrLf & "         ORDER BY "
            strSQL &= vbCrLf & "            BB.FTRK_BUF_NO "
            strSQL &= vbCrLf & "           ,BB.FTRK_BUF_ARRAY "

            strSQL &= vbCrLf


            '***********************
            '���o
            '***********************
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TPRG_TRK_BUF"
            ObjDb.GetDataSet(strDataSetName, objDataSet)

            Return objDataSet.Tables(strDataSetName).Rows.Count

        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
    'JobMate:S.Ouchi 2013/11/08 ��I�����ύX
    '������������************************************************************************************************************


    '���������ьŗL
    '**********************************************************************************************

End Class
