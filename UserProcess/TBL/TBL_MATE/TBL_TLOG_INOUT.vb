'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' �y���́zMaterialStreamð��ٸ׽
' �y�@�\�zINOUT����ð��ٸ׽
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
''' INOUT����ð��ٸ׽
''' </summary>
Public Class TBL_TLOG_INOUT
    Inherits clsTemplateTable

    '**********************************************************************************************
    '����������������
#Region "  �׽�ϐ���`                  "
    '�����è
    Private mobjAryMe As TBL_TLOG_INOUT()                                        'INOUT����
    Private mstrUSER_SQL As String                                               'հ�ްSQL
    Private mORDER_BY As String                                                  'OrderBy��
    Private mWHERE As String                                                     'Where��
    Private mFLOG_NO As String                                                   '۸އ�
    Private mFLOT_NO_STOCK As String                                             '�݌�ۯć�
    Private mFRESULT_DT As Nullable(Of Date)                                     '���ѓ���
    Private mFPALLET_ID As String                                                '��گ�ID
    Private mFBUF_FM As Nullable(Of Integer)                                     '�������ׯ�ݸ��ޯ̧��
    Private mFARRAY_FM As Nullable(Of Integer)                                   '�������ׯ�ݸ��ޯ̧�z��
    Private mFBUF_TO As Nullable(Of Integer)                                     '�������ׯ�ݸ��ޯ̧��
    Private mFARRAY_TO As Nullable(Of Integer)                                   '�������ׯ�ݸ��ޯ̧�z��
    Private mFINOUT_STS As Nullable(Of Integer)                                  'IN/OUT
    Private mFSAGYOU_KIND As Nullable(Of Integer)                                '��Ǝ��
    Private mFDISP_ADDRESS_FM As String                                          'FM�\�L�p���ڽ
    Private mFDISP_ADDRESS_TO As String                                          'TO�\�L�p���ڽ
    Private mFDISPLOG_ADDRESS_FM As String                                       'FM�\�L�p���ڽ_۸ޗp
    Private mFDISPLOG_ADDRESS_TO As String                                       'TO�\�L�p���ڽ_۸ޗp
    Private mFHINMEI_CD As String                                                '�i�ں���
    Private mFHINMEI As String                                                   '�i��_������
    Private mFLOT_NO As String                                                   'ۯć�
    Private mFTANI As String                                                     '�P�ʺ���
    Private mFARRIVE_DT As Nullable(Of Date)                                     '�݌ɔ�������
    Private mFIN_KUBUN As Nullable(Of Integer)                                   '���ɋ敪
    Private mFSEIHIN_KUBUN As Nullable(Of Integer)                               '���i�敪
    Private mFZAIKO_KUBUN As Nullable(Of Integer)                                '�݌ɋ敪
    Private mFHORYU_KUBUN As Nullable(Of Integer)                                '�ۗ��敪
    Private mFST_FM As Nullable(Of Integer)                                      '������ST�ׯ�ݸ��ޯ̧��
    Private mFOUT_NAME As String                                                 '������
    Private mFTR_VOL As Nullable(Of Decimal)                                     '�����Ǘ���
    Private mFTR_RES_VOL As Nullable(Of Decimal)                                 '����������
    Private mFDECIMAL_POINT As Nullable(Of Integer)                              '�����_�ȉ��L������
    Private mFHASU_FLAG As Nullable(Of Integer)                                  '�[���׸�
    Private mFLABEL_ID As String                                                 '����ID
    Private mFTRNS_SERIAL As String                                              '�����ره�(MC��)
    Private mFUSER_ID As String                                                  'հ�ްID
    Private mXPROD_LINE As String                                                '���Yײ݇�
    Private mXKENSA_KUBUN As String                                              '�����敪
    Private mXKENPIN_KUBUN As String                                             '���i�敪
    Private mXRAC_IN_DT As Nullable(Of Date)                                     '���ɓ���
    Private mXTRK_BUF_NO_IN As Nullable(Of Integer)                              '�����ׯ�ݸ��ޯ̧��
    Private mXTRK_BUF_ARRAY_IN As Nullable(Of Integer)                           '�����ׯ�ݸ��ޯ̧�z��
#End Region
#Region "  �����è��`                  "
    ''' <summary>
    ''' ���ѕϐ� (���׽�^�z��)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_TLOG_INOUT()
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
    ''' ۸އ�
    ''' </summary>
    Public Property FLOG_NO() As String
        Get
            Return mFLOG_NO
        End Get
        Set(ByVal Value As String)
            mFLOG_NO = Value
        End Set
    End Property
    ''' <summary>
    ''' �݌�ۯć�
    ''' </summary>
    Public Property FLOT_NO_STOCK() As String
        Get
            Return mFLOT_NO_STOCK
        End Get
        Set(ByVal Value As String)
            mFLOT_NO_STOCK = Value
        End Set
    End Property
    ''' <summary>
    ''' ���ѓ���
    ''' </summary>
    Public Property FRESULT_DT() As Nullable(Of Date)
        Get
            Return mFRESULT_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mFRESULT_DT = Value
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
    ''' �������ׯ�ݸ��ޯ̧��
    ''' </summary>
    Public Property FBUF_FM() As Nullable(Of Integer)
        Get
            Return mFBUF_FM
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFBUF_FM = Value
        End Set
    End Property
    ''' <summary>
    ''' �������ׯ�ݸ��ޯ̧�z��
    ''' </summary>
    Public Property FARRAY_FM() As Nullable(Of Integer)
        Get
            Return mFARRAY_FM
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFARRAY_FM = Value
        End Set
    End Property
    ''' <summary>
    ''' �������ׯ�ݸ��ޯ̧��
    ''' </summary>
    Public Property FBUF_TO() As Nullable(Of Integer)
        Get
            Return mFBUF_TO
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFBUF_TO = Value
        End Set
    End Property
    ''' <summary>
    ''' �������ׯ�ݸ��ޯ̧�z��
    ''' </summary>
    Public Property FARRAY_TO() As Nullable(Of Integer)
        Get
            Return mFARRAY_TO
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFARRAY_TO = Value
        End Set
    End Property
    ''' <summary>
    ''' IN/OUT
    ''' </summary>
    Public Property FINOUT_STS() As Nullable(Of Integer)
        Get
            Return mFINOUT_STS
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFINOUT_STS = Value
        End Set
    End Property
    ''' <summary>
    ''' ��Ǝ��
    ''' </summary>
    Public Property FSAGYOU_KIND() As Nullable(Of Integer)
        Get
            Return mFSAGYOU_KIND
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFSAGYOU_KIND = Value
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
    ''' �i�ں���
    ''' </summary>
    Public Property FHINMEI_CD() As String
        Get
            Return mFHINMEI_CD
        End Get
        Set(ByVal Value As String)
            mFHINMEI_CD = Value
        End Set
    End Property
    ''' <summary>
    ''' �i��_������
    ''' </summary>
    Public Property FHINMEI() As String
        Get
            Return mFHINMEI
        End Get
        Set(ByVal Value As String)
            mFHINMEI = Value
        End Set
    End Property
    ''' <summary>
    ''' ۯć�
    ''' </summary>
    Public Property FLOT_NO() As String
        Get
            Return mFLOT_NO
        End Get
        Set(ByVal Value As String)
            mFLOT_NO = Value
        End Set
    End Property
    ''' <summary>
    ''' �P�ʺ���
    ''' </summary>
    Public Property FTANI() As String
        Get
            Return mFTANI
        End Get
        Set(ByVal Value As String)
            mFTANI = Value
        End Set
    End Property
    ''' <summary>
    ''' �݌ɔ�������
    ''' </summary>
    Public Property FARRIVE_DT() As Nullable(Of Date)
        Get
            Return mFARRIVE_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mFARRIVE_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' ���ɋ敪
    ''' </summary>
    Public Property FIN_KUBUN() As Nullable(Of Integer)
        Get
            Return mFIN_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFIN_KUBUN = Value
        End Set
    End Property
    ''' <summary>
    ''' ���i�敪
    ''' </summary>
    Public Property FSEIHIN_KUBUN() As Nullable(Of Integer)
        Get
            Return mFSEIHIN_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFSEIHIN_KUBUN = Value
        End Set
    End Property
    ''' <summary>
    ''' �݌ɋ敪
    ''' </summary>
    Public Property FZAIKO_KUBUN() As Nullable(Of Integer)
        Get
            Return mFZAIKO_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFZAIKO_KUBUN = Value
        End Set
    End Property
    ''' <summary>
    ''' �ۗ��敪
    ''' </summary>
    Public Property FHORYU_KUBUN() As Nullable(Of Integer)
        Get
            Return mFHORYU_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFHORYU_KUBUN = Value
        End Set
    End Property
    ''' <summary>
    ''' ������ST�ׯ�ݸ��ޯ̧��
    ''' </summary>
    Public Property FST_FM() As Nullable(Of Integer)
        Get
            Return mFST_FM
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFST_FM = Value
        End Set
    End Property
    ''' <summary>
    ''' ������
    ''' </summary>
    Public Property FOUT_NAME() As String
        Get
            Return mFOUT_NAME
        End Get
        Set(ByVal Value As String)
            mFOUT_NAME = Value
        End Set
    End Property
    ''' <summary>
    ''' �����Ǘ���
    ''' </summary>
    Public Property FTR_VOL() As Nullable(Of Decimal)
        Get
            Return mFTR_VOL
        End Get
        Set(ByVal Value As Nullable(Of Decimal))
            mFTR_VOL = Value
        End Set
    End Property
    ''' <summary>
    ''' ����������
    ''' </summary>
    Public Property FTR_RES_VOL() As Nullable(Of Decimal)
        Get
            Return mFTR_RES_VOL
        End Get
        Set(ByVal Value As Nullable(Of Decimal))
            mFTR_RES_VOL = Value
        End Set
    End Property
    ''' <summary>
    ''' �����_�ȉ��L������
    ''' </summary>
    Public Property FDECIMAL_POINT() As Nullable(Of Integer)
        Get
            Return mFDECIMAL_POINT
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFDECIMAL_POINT = Value
        End Set
    End Property
    ''' <summary>
    ''' �[���׸�
    ''' </summary>
    Public Property FHASU_FLAG() As Nullable(Of Integer)
        Get
            Return mFHASU_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFHASU_FLAG = Value
        End Set
    End Property
    ''' <summary>
    ''' ����ID
    ''' </summary>
    Public Property FLABEL_ID() As String
        Get
            Return mFLABEL_ID
        End Get
        Set(ByVal Value As String)
            mFLABEL_ID = Value
        End Set
    End Property
    ''' <summary>
    ''' �����ره�(MC��)
    ''' </summary>
    Public Property FTRNS_SERIAL() As String
        Get
            Return mFTRNS_SERIAL
        End Get
        Set(ByVal Value As String)
            mFTRNS_SERIAL = Value
        End Set
    End Property
    ''' <summary>
    ''' հ�ްID
    ''' </summary>
    Public Property FUSER_ID() As String
        Get
            Return mFUSER_ID
        End Get
        Set(ByVal Value As String)
            mFUSER_ID = Value
        End Set
    End Property
    ''' <summary>
    ''' ���Yײ݇�
    ''' </summary>
    Public Property XPROD_LINE() As String
        Get
            Return mXPROD_LINE
        End Get
        Set(ByVal Value As String)
            mXPROD_LINE = Value
        End Set
    End Property
    ''' <summary>
    ''' �����敪
    ''' </summary>
    Public Property XKENSA_KUBUN() As String
        Get
            Return mXKENSA_KUBUN
        End Get
        Set(ByVal Value As String)
            mXKENSA_KUBUN = Value
        End Set
    End Property
    ''' <summary>
    ''' ���i�敪
    ''' </summary>
    Public Property XKENPIN_KUBUN() As String
        Get
            Return mXKENPIN_KUBUN
        End Get
        Set(ByVal Value As String)
            mXKENPIN_KUBUN = Value
        End Set
    End Property
    ''' <summary>
    ''' ���ɓ���
    ''' </summary>
    Public Property XRAC_IN_DT() As Nullable(Of Date)
        Get
            Return mXRAC_IN_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mXRAC_IN_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' �����ׯ�ݸ��ޯ̧��
    ''' </summary>
    Public Property XTRK_BUF_NO_IN() As Nullable(Of Integer)
        Get
            Return mXTRK_BUF_NO_IN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXTRK_BUF_NO_IN = Value
        End Set
    End Property
    ''' <summary>
    ''' �����ׯ�ݸ��ޯ̧�z��
    ''' </summary>
    Public Property XTRK_BUF_ARRAY_IN() As Nullable(Of Integer)
        Get
            Return mXTRK_BUF_ARRAY_IN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXTRK_BUF_ARRAY_IN = Value
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
    Public Function GET_TLOG_INOUT(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    TLOG_INOUT")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FLOG_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            strSQL.Append(vbCrLf & "    AND FLOG_NO = :" & UBound(strBindField) - 1 & " --۸އ�")
        End If
        If IsNull(FLOT_NO_STOCK) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO_STOCK
            strSQL.Append(vbCrLf & "    AND FLOT_NO_STOCK = :" & UBound(strBindField) - 1 & " --�݌�ۯć�")
        End If
        If IsNull(FRESULT_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRESULT_DT
            strSQL.Append(vbCrLf & "    AND FRESULT_DT = :" & UBound(strBindField) - 1 & " --���ѓ���")
        End If
        If IsNull(FPALLET_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --��گ�ID")
        End If
        If IsNull(FBUF_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_FM
            strSQL.Append(vbCrLf & "    AND FBUF_FM = :" & UBound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FARRAY_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFARRAY_FM
            strSQL.Append(vbCrLf & "    AND FARRAY_FM = :" & UBound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧�z��")
        End If
        If IsNull(FBUF_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_TO
            strSQL.Append(vbCrLf & "    AND FBUF_TO = :" & UBound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FARRAY_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFARRAY_TO
            strSQL.Append(vbCrLf & "    AND FARRAY_TO = :" & UBound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧�z��")
        End If
        If IsNull(FINOUT_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINOUT_STS
            strSQL.Append(vbCrLf & "    AND FINOUT_STS = :" & UBound(strBindField) - 1 & " --IN/OUT")
        End If
        If IsNull(FSAGYOU_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_KIND
            strSQL.Append(vbCrLf & "    AND FSAGYOU_KIND = :" & UBound(strBindField) - 1 & " --��Ǝ��")
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
        If IsNull(FHINMEI_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --�i�ں���")
        End If
        If IsNull(FHINMEI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI
            strSQL.Append(vbCrLf & "    AND FHINMEI = :" & UBound(strBindField) - 1 & " --�i��_������")
        End If
        If IsNull(FLOT_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO
            strSQL.Append(vbCrLf & "    AND FLOT_NO = :" & UBound(strBindField) - 1 & " --ۯć�")
        End If
        If IsNull(FTANI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTANI
            strSQL.Append(vbCrLf & "    AND FTANI = :" & UBound(strBindField) - 1 & " --�P�ʺ���")
        End If
        If IsNull(FARRIVE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFARRIVE_DT
            strSQL.Append(vbCrLf & "    AND FARRIVE_DT = :" & UBound(strBindField) - 1 & " --�݌ɔ�������")
        End If
        If IsNull(FIN_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFIN_KUBUN
            strSQL.Append(vbCrLf & "    AND FIN_KUBUN = :" & UBound(strBindField) - 1 & " --���ɋ敪")
        End If
        If IsNull(FSEIHIN_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEIHIN_KUBUN
            strSQL.Append(vbCrLf & "    AND FSEIHIN_KUBUN = :" & UBound(strBindField) - 1 & " --���i�敪")
        End If
        If IsNull(FZAIKO_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_KUBUN
            strSQL.Append(vbCrLf & "    AND FZAIKO_KUBUN = :" & UBound(strBindField) - 1 & " --�݌ɋ敪")
        End If
        If IsNull(FHORYU_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHORYU_KUBUN
            strSQL.Append(vbCrLf & "    AND FHORYU_KUBUN = :" & UBound(strBindField) - 1 & " --�ۗ��敪")
        End If
        If IsNull(FST_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFST_FM
            strSQL.Append(vbCrLf & "    AND FST_FM = :" & UBound(strBindField) - 1 & " --������ST�ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FOUT_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFOUT_NAME
            strSQL.Append(vbCrLf & "    AND FOUT_NAME = :" & UBound(strBindField) - 1 & " --������")
        End If
        If IsNull(FTR_VOL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_VOL
            strSQL.Append(vbCrLf & "    AND FTR_VOL = :" & UBound(strBindField) - 1 & " --�����Ǘ���")
        End If
        If IsNull(FTR_RES_VOL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_RES_VOL
            strSQL.Append(vbCrLf & "    AND FTR_RES_VOL = :" & UBound(strBindField) - 1 & " --����������")
        End If
        If IsNull(FDECIMAL_POINT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDECIMAL_POINT
            strSQL.Append(vbCrLf & "    AND FDECIMAL_POINT = :" & UBound(strBindField) - 1 & " --�����_�ȉ��L������")
        End If
        If IsNull(FHASU_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHASU_FLAG
            strSQL.Append(vbCrLf & "    AND FHASU_FLAG = :" & UBound(strBindField) - 1 & " --�[���׸�")
        End If
        If IsNull(FLABEL_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLABEL_ID
            strSQL.Append(vbCrLf & "    AND FLABEL_ID = :" & UBound(strBindField) - 1 & " --����ID")
        End If
        If IsNull(FTRNS_SERIAL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_SERIAL
            strSQL.Append(vbCrLf & "    AND FTRNS_SERIAL = :" & UBound(strBindField) - 1 & " --�����ره�(MC��)")
        End If
        If IsNull(FUSER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID
            strSQL.Append(vbCrLf & "    AND FUSER_ID = :" & UBound(strBindField) - 1 & " --հ�ްID")
        End If
        If IsNull(XPROD_LINE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPROD_LINE
            strSQL.Append(vbCrLf & "    AND XPROD_LINE = :" & UBound(strBindField) - 1 & " --���Yײ݇�")
        End If
        If IsNull(XKENSA_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKENSA_KUBUN
            strSQL.Append(vbCrLf & "    AND XKENSA_KUBUN = :" & UBound(strBindField) - 1 & " --�����敪")
        End If
        If IsNull(XKENPIN_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKENPIN_KUBUN
            strSQL.Append(vbCrLf & "    AND XKENPIN_KUBUN = :" & UBound(strBindField) - 1 & " --���i�敪")
        End If
        If IsNull(XRAC_IN_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXRAC_IN_DT
            strSQL.Append(vbCrLf & "    AND XRAC_IN_DT = :" & UBound(strBindField) - 1 & " --���ɓ���")
        End If
        If IsNull(XTRK_BUF_NO_IN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_IN
            strSQL.Append(vbCrLf & "    AND XTRK_BUF_NO_IN = :" & UBound(strBindField) - 1 & " --�����ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(XTRK_BUF_ARRAY_IN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_ARRAY_IN
            strSQL.Append(vbCrLf & "    AND XTRK_BUF_ARRAY_IN = :" & UBound(strBindField) - 1 & " --�����ׯ�ݸ��ޯ̧�z��")
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
        strDataSetName = "TLOG_INOUT"
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
    Public Function GET_TLOG_INOUT_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    TLOG_INOUT")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FLOG_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            strSQL.Append(vbCrLf & "    AND FLOG_NO = :" & UBound(strBindField) - 1 & " --۸އ�")
        End If
        If IsNull(FLOT_NO_STOCK) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO_STOCK
            strSQL.Append(vbCrLf & "    AND FLOT_NO_STOCK = :" & UBound(strBindField) - 1 & " --�݌�ۯć�")
        End If
        If IsNull(FRESULT_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRESULT_DT
            strSQL.Append(vbCrLf & "    AND FRESULT_DT = :" & UBound(strBindField) - 1 & " --���ѓ���")
        End If
        If IsNull(FPALLET_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --��گ�ID")
        End If
        If IsNull(FBUF_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_FM
            strSQL.Append(vbCrLf & "    AND FBUF_FM = :" & UBound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FARRAY_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFARRAY_FM
            strSQL.Append(vbCrLf & "    AND FARRAY_FM = :" & UBound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧�z��")
        End If
        If IsNull(FBUF_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_TO
            strSQL.Append(vbCrLf & "    AND FBUF_TO = :" & UBound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FARRAY_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFARRAY_TO
            strSQL.Append(vbCrLf & "    AND FARRAY_TO = :" & UBound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧�z��")
        End If
        If IsNull(FINOUT_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINOUT_STS
            strSQL.Append(vbCrLf & "    AND FINOUT_STS = :" & UBound(strBindField) - 1 & " --IN/OUT")
        End If
        If IsNull(FSAGYOU_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_KIND
            strSQL.Append(vbCrLf & "    AND FSAGYOU_KIND = :" & UBound(strBindField) - 1 & " --��Ǝ��")
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
        If IsNull(FHINMEI_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --�i�ں���")
        End If
        If IsNull(FHINMEI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI
            strSQL.Append(vbCrLf & "    AND FHINMEI = :" & UBound(strBindField) - 1 & " --�i��_������")
        End If
        If IsNull(FLOT_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO
            strSQL.Append(vbCrLf & "    AND FLOT_NO = :" & UBound(strBindField) - 1 & " --ۯć�")
        End If
        If IsNull(FTANI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTANI
            strSQL.Append(vbCrLf & "    AND FTANI = :" & UBound(strBindField) - 1 & " --�P�ʺ���")
        End If
        If IsNull(FARRIVE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFARRIVE_DT
            strSQL.Append(vbCrLf & "    AND FARRIVE_DT = :" & UBound(strBindField) - 1 & " --�݌ɔ�������")
        End If
        If IsNull(FIN_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFIN_KUBUN
            strSQL.Append(vbCrLf & "    AND FIN_KUBUN = :" & UBound(strBindField) - 1 & " --���ɋ敪")
        End If
        If IsNull(FSEIHIN_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEIHIN_KUBUN
            strSQL.Append(vbCrLf & "    AND FSEIHIN_KUBUN = :" & UBound(strBindField) - 1 & " --���i�敪")
        End If
        If IsNull(FZAIKO_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_KUBUN
            strSQL.Append(vbCrLf & "    AND FZAIKO_KUBUN = :" & UBound(strBindField) - 1 & " --�݌ɋ敪")
        End If
        If IsNull(FHORYU_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHORYU_KUBUN
            strSQL.Append(vbCrLf & "    AND FHORYU_KUBUN = :" & UBound(strBindField) - 1 & " --�ۗ��敪")
        End If
        If IsNull(FST_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFST_FM
            strSQL.Append(vbCrLf & "    AND FST_FM = :" & UBound(strBindField) - 1 & " --������ST�ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FOUT_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFOUT_NAME
            strSQL.Append(vbCrLf & "    AND FOUT_NAME = :" & UBound(strBindField) - 1 & " --������")
        End If
        If IsNull(FTR_VOL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_VOL
            strSQL.Append(vbCrLf & "    AND FTR_VOL = :" & UBound(strBindField) - 1 & " --�����Ǘ���")
        End If
        If IsNull(FTR_RES_VOL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_RES_VOL
            strSQL.Append(vbCrLf & "    AND FTR_RES_VOL = :" & UBound(strBindField) - 1 & " --����������")
        End If
        If IsNull(FDECIMAL_POINT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDECIMAL_POINT
            strSQL.Append(vbCrLf & "    AND FDECIMAL_POINT = :" & UBound(strBindField) - 1 & " --�����_�ȉ��L������")
        End If
        If IsNull(FHASU_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHASU_FLAG
            strSQL.Append(vbCrLf & "    AND FHASU_FLAG = :" & UBound(strBindField) - 1 & " --�[���׸�")
        End If
        If IsNull(FLABEL_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLABEL_ID
            strSQL.Append(vbCrLf & "    AND FLABEL_ID = :" & UBound(strBindField) - 1 & " --����ID")
        End If
        If IsNull(FTRNS_SERIAL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_SERIAL
            strSQL.Append(vbCrLf & "    AND FTRNS_SERIAL = :" & UBound(strBindField) - 1 & " --�����ره�(MC��)")
        End If
        If IsNull(FUSER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID
            strSQL.Append(vbCrLf & "    AND FUSER_ID = :" & UBound(strBindField) - 1 & " --հ�ްID")
        End If
        If IsNull(XPROD_LINE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPROD_LINE
            strSQL.Append(vbCrLf & "    AND XPROD_LINE = :" & UBound(strBindField) - 1 & " --���Yײ݇�")
        End If
        If IsNull(XKENSA_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKENSA_KUBUN
            strSQL.Append(vbCrLf & "    AND XKENSA_KUBUN = :" & UBound(strBindField) - 1 & " --�����敪")
        End If
        If IsNull(XKENPIN_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKENPIN_KUBUN
            strSQL.Append(vbCrLf & "    AND XKENPIN_KUBUN = :" & UBound(strBindField) - 1 & " --���i�敪")
        End If
        If IsNull(XRAC_IN_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXRAC_IN_DT
            strSQL.Append(vbCrLf & "    AND XRAC_IN_DT = :" & UBound(strBindField) - 1 & " --���ɓ���")
        End If
        If IsNull(XTRK_BUF_NO_IN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_IN
            strSQL.Append(vbCrLf & "    AND XTRK_BUF_NO_IN = :" & UBound(strBindField) - 1 & " --�����ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(XTRK_BUF_ARRAY_IN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_ARRAY_IN
            strSQL.Append(vbCrLf & "    AND XTRK_BUF_ARRAY_IN = :" & UBound(strBindField) - 1 & " --�����ׯ�ݸ��ޯ̧�z��")
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
        strDataSetName = "TLOG_INOUT"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TLOG_INOUT(Owner, objDb, objDbLog)
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
    Public Function GET_TLOG_INOUT_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "TLOG_INOUT"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TLOG_INOUT(Owner, objDb, objDbLog)
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
    Public Function GET_TLOG_INOUT_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    TLOG_INOUT")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FLOG_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            strSQL.Append(vbCrLf & "    AND FLOG_NO = :" & UBound(strBindField) - 1 & " --۸އ�")
        End If
        If IsNull(FLOT_NO_STOCK) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO_STOCK
            strSQL.Append(vbCrLf & "    AND FLOT_NO_STOCK = :" & UBound(strBindField) - 1 & " --�݌�ۯć�")
        End If
        If IsNull(FRESULT_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRESULT_DT
            strSQL.Append(vbCrLf & "    AND FRESULT_DT = :" & UBound(strBindField) - 1 & " --���ѓ���")
        End If
        If IsNull(FPALLET_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --��گ�ID")
        End If
        If IsNull(FBUF_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_FM
            strSQL.Append(vbCrLf & "    AND FBUF_FM = :" & UBound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FARRAY_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFARRAY_FM
            strSQL.Append(vbCrLf & "    AND FARRAY_FM = :" & UBound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧�z��")
        End If
        If IsNull(FBUF_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_TO
            strSQL.Append(vbCrLf & "    AND FBUF_TO = :" & UBound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FARRAY_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFARRAY_TO
            strSQL.Append(vbCrLf & "    AND FARRAY_TO = :" & UBound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧�z��")
        End If
        If IsNull(FINOUT_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINOUT_STS
            strSQL.Append(vbCrLf & "    AND FINOUT_STS = :" & UBound(strBindField) - 1 & " --IN/OUT")
        End If
        If IsNull(FSAGYOU_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_KIND
            strSQL.Append(vbCrLf & "    AND FSAGYOU_KIND = :" & UBound(strBindField) - 1 & " --��Ǝ��")
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
        If IsNull(FHINMEI_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --�i�ں���")
        End If
        If IsNull(FHINMEI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI
            strSQL.Append(vbCrLf & "    AND FHINMEI = :" & UBound(strBindField) - 1 & " --�i��_������")
        End If
        If IsNull(FLOT_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO
            strSQL.Append(vbCrLf & "    AND FLOT_NO = :" & UBound(strBindField) - 1 & " --ۯć�")
        End If
        If IsNull(FTANI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTANI
            strSQL.Append(vbCrLf & "    AND FTANI = :" & UBound(strBindField) - 1 & " --�P�ʺ���")
        End If
        If IsNull(FARRIVE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFARRIVE_DT
            strSQL.Append(vbCrLf & "    AND FARRIVE_DT = :" & UBound(strBindField) - 1 & " --�݌ɔ�������")
        End If
        If IsNull(FIN_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFIN_KUBUN
            strSQL.Append(vbCrLf & "    AND FIN_KUBUN = :" & UBound(strBindField) - 1 & " --���ɋ敪")
        End If
        If IsNull(FSEIHIN_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEIHIN_KUBUN
            strSQL.Append(vbCrLf & "    AND FSEIHIN_KUBUN = :" & UBound(strBindField) - 1 & " --���i�敪")
        End If
        If IsNull(FZAIKO_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_KUBUN
            strSQL.Append(vbCrLf & "    AND FZAIKO_KUBUN = :" & UBound(strBindField) - 1 & " --�݌ɋ敪")
        End If
        If IsNull(FHORYU_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHORYU_KUBUN
            strSQL.Append(vbCrLf & "    AND FHORYU_KUBUN = :" & UBound(strBindField) - 1 & " --�ۗ��敪")
        End If
        If IsNull(FST_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFST_FM
            strSQL.Append(vbCrLf & "    AND FST_FM = :" & UBound(strBindField) - 1 & " --������ST�ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FOUT_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFOUT_NAME
            strSQL.Append(vbCrLf & "    AND FOUT_NAME = :" & UBound(strBindField) - 1 & " --������")
        End If
        If IsNull(FTR_VOL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_VOL
            strSQL.Append(vbCrLf & "    AND FTR_VOL = :" & UBound(strBindField) - 1 & " --�����Ǘ���")
        End If
        If IsNull(FTR_RES_VOL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_RES_VOL
            strSQL.Append(vbCrLf & "    AND FTR_RES_VOL = :" & UBound(strBindField) - 1 & " --����������")
        End If
        If IsNull(FDECIMAL_POINT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDECIMAL_POINT
            strSQL.Append(vbCrLf & "    AND FDECIMAL_POINT = :" & UBound(strBindField) - 1 & " --�����_�ȉ��L������")
        End If
        If IsNull(FHASU_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHASU_FLAG
            strSQL.Append(vbCrLf & "    AND FHASU_FLAG = :" & UBound(strBindField) - 1 & " --�[���׸�")
        End If
        If IsNull(FLABEL_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLABEL_ID
            strSQL.Append(vbCrLf & "    AND FLABEL_ID = :" & UBound(strBindField) - 1 & " --����ID")
        End If
        If IsNull(FTRNS_SERIAL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_SERIAL
            strSQL.Append(vbCrLf & "    AND FTRNS_SERIAL = :" & UBound(strBindField) - 1 & " --�����ره�(MC��)")
        End If
        If IsNull(FUSER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID
            strSQL.Append(vbCrLf & "    AND FUSER_ID = :" & UBound(strBindField) - 1 & " --հ�ްID")
        End If
        If IsNull(XPROD_LINE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPROD_LINE
            strSQL.Append(vbCrLf & "    AND XPROD_LINE = :" & UBound(strBindField) - 1 & " --���Yײ݇�")
        End If
        If IsNull(XKENSA_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKENSA_KUBUN
            strSQL.Append(vbCrLf & "    AND XKENSA_KUBUN = :" & UBound(strBindField) - 1 & " --�����敪")
        End If
        If IsNull(XKENPIN_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKENPIN_KUBUN
            strSQL.Append(vbCrLf & "    AND XKENPIN_KUBUN = :" & UBound(strBindField) - 1 & " --���i�敪")
        End If
        If IsNull(XRAC_IN_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXRAC_IN_DT
            strSQL.Append(vbCrLf & "    AND XRAC_IN_DT = :" & UBound(strBindField) - 1 & " --���ɓ���")
        End If
        If IsNull(XTRK_BUF_NO_IN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_IN
            strSQL.Append(vbCrLf & "    AND XTRK_BUF_NO_IN = :" & UBound(strBindField) - 1 & " --�����ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(XTRK_BUF_ARRAY_IN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_ARRAY_IN
            strSQL.Append(vbCrLf & "    AND XTRK_BUF_ARRAY_IN = :" & UBound(strBindField) - 1 & " --�����ׯ�ݸ��ޯ̧�z��")
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
        strDataSetName = "TLOG_INOUT"
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
    Public Sub UPDATE_TLOG_INOUT()
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
        ElseIf IsNull(mFLOG_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[۸އ�]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFLOT_NO_STOCK) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�݌�ۯć�]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFRESULT_DT) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[���ѓ���]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFPALLET_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[��گ�ID]"
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
        strSQL.Append(vbCrLf & "    TLOG_INOUT")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
        If IsNull(mFLOG_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_NO = NULL --۸އ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_NO = NULL --۸އ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_NO = :" & Ubound(strBindField) - 1 & " --۸އ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_NO = :" & Ubound(strBindField) - 1 & " --۸އ�")
        End If
        intCount = intCount + 1
        If IsNull(mFLOT_NO_STOCK) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOT_NO_STOCK = NULL --�݌�ۯć�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOT_NO_STOCK = NULL --�݌�ۯć�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO_STOCK
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOT_NO_STOCK = :" & Ubound(strBindField) - 1 & " --�݌�ۯć�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOT_NO_STOCK = :" & Ubound(strBindField) - 1 & " --�݌�ۯć�")
        End If
        intCount = intCount + 1
        If IsNull(mFRESULT_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRESULT_DT = NULL --���ѓ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRESULT_DT = NULL --���ѓ���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRESULT_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRESULT_DT = :" & Ubound(strBindField) - 1 & " --���ѓ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRESULT_DT = :" & Ubound(strBindField) - 1 & " --���ѓ���")
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
        If IsNull(mFBUF_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FBUF_FM = NULL --�������ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FBUF_FM = NULL --�������ׯ�ݸ��ޯ̧��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FBUF_FM = :" & Ubound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FBUF_FM = :" & Ubound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧��")
        End If
        intCount = intCount + 1
        If IsNull(mFARRAY_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FARRAY_FM = NULL --�������ׯ�ݸ��ޯ̧�z��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FARRAY_FM = NULL --�������ׯ�ݸ��ޯ̧�z��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFARRAY_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FARRAY_FM = :" & Ubound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧�z��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FARRAY_FM = :" & Ubound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧�z��")
        End If
        intCount = intCount + 1
        If IsNull(mFBUF_TO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FBUF_TO = NULL --�������ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FBUF_TO = NULL --�������ׯ�ݸ��ޯ̧��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_TO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FBUF_TO = :" & Ubound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FBUF_TO = :" & Ubound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧��")
        End If
        intCount = intCount + 1
        If IsNull(mFARRAY_TO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FARRAY_TO = NULL --�������ׯ�ݸ��ޯ̧�z��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FARRAY_TO = NULL --�������ׯ�ݸ��ޯ̧�z��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFARRAY_TO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FARRAY_TO = :" & Ubound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧�z��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FARRAY_TO = :" & Ubound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧�z��")
        End If
        intCount = intCount + 1
        If IsNull(mFINOUT_STS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FINOUT_STS = NULL --IN/OUT")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FINOUT_STS = NULL --IN/OUT")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINOUT_STS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FINOUT_STS = :" & Ubound(strBindField) - 1 & " --IN/OUT")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FINOUT_STS = :" & Ubound(strBindField) - 1 & " --IN/OUT")
        End If
        intCount = intCount + 1
        If IsNull(mFSAGYOU_KIND) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSAGYOU_KIND = NULL --��Ǝ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSAGYOU_KIND = NULL --��Ǝ��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_KIND
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSAGYOU_KIND = :" & Ubound(strBindField) - 1 & " --��Ǝ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSAGYOU_KIND = :" & Ubound(strBindField) - 1 & " --��Ǝ��")
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
        If IsNull(mFHINMEI_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHINMEI_CD = NULL --�i�ں���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHINMEI_CD = NULL --�i�ں���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHINMEI_CD = :" & Ubound(strBindField) - 1 & " --�i�ں���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHINMEI_CD = :" & Ubound(strBindField) - 1 & " --�i�ں���")
        End If
        intCount = intCount + 1
        If IsNull(mFHINMEI) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHINMEI = NULL --�i��_������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHINMEI = NULL --�i��_������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHINMEI = :" & Ubound(strBindField) - 1 & " --�i��_������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHINMEI = :" & Ubound(strBindField) - 1 & " --�i��_������")
        End If
        intCount = intCount + 1
        If IsNull(mFLOT_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOT_NO = NULL --ۯć�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOT_NO = NULL --ۯć�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOT_NO = :" & Ubound(strBindField) - 1 & " --ۯć�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOT_NO = :" & Ubound(strBindField) - 1 & " --ۯć�")
        End If
        intCount = intCount + 1
        If IsNull(mFTANI) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTANI = NULL --�P�ʺ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTANI = NULL --�P�ʺ���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTANI
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTANI = :" & Ubound(strBindField) - 1 & " --�P�ʺ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTANI = :" & Ubound(strBindField) - 1 & " --�P�ʺ���")
        End If
        intCount = intCount + 1
        If IsNull(mFARRIVE_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FARRIVE_DT = NULL --�݌ɔ�������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FARRIVE_DT = NULL --�݌ɔ�������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFARRIVE_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FARRIVE_DT = :" & Ubound(strBindField) - 1 & " --�݌ɔ�������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FARRIVE_DT = :" & Ubound(strBindField) - 1 & " --�݌ɔ�������")
        End If
        intCount = intCount + 1
        If IsNull(mFIN_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FIN_KUBUN = NULL --���ɋ敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FIN_KUBUN = NULL --���ɋ敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFIN_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FIN_KUBUN = :" & Ubound(strBindField) - 1 & " --���ɋ敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FIN_KUBUN = :" & Ubound(strBindField) - 1 & " --���ɋ敪")
        End If
        intCount = intCount + 1
        If IsNull(mFSEIHIN_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSEIHIN_KUBUN = NULL --���i�敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSEIHIN_KUBUN = NULL --���i�敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEIHIN_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSEIHIN_KUBUN = :" & Ubound(strBindField) - 1 & " --���i�敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSEIHIN_KUBUN = :" & Ubound(strBindField) - 1 & " --���i�敪")
        End If
        intCount = intCount + 1
        If IsNull(mFZAIKO_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FZAIKO_KUBUN = NULL --�݌ɋ敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FZAIKO_KUBUN = NULL --�݌ɋ敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FZAIKO_KUBUN = :" & Ubound(strBindField) - 1 & " --�݌ɋ敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FZAIKO_KUBUN = :" & Ubound(strBindField) - 1 & " --�݌ɋ敪")
        End If
        intCount = intCount + 1
        If IsNull(mFHORYU_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHORYU_KUBUN = NULL --�ۗ��敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHORYU_KUBUN = NULL --�ۗ��敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHORYU_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHORYU_KUBUN = :" & Ubound(strBindField) - 1 & " --�ۗ��敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHORYU_KUBUN = :" & Ubound(strBindField) - 1 & " --�ۗ��敪")
        End If
        intCount = intCount + 1
        If IsNull(mFST_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FST_FM = NULL --������ST�ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FST_FM = NULL --������ST�ׯ�ݸ��ޯ̧��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFST_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FST_FM = :" & Ubound(strBindField) - 1 & " --������ST�ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FST_FM = :" & Ubound(strBindField) - 1 & " --������ST�ׯ�ݸ��ޯ̧��")
        End If
        intCount = intCount + 1
        If IsNull(mFOUT_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FOUT_NAME = NULL --������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FOUT_NAME = NULL --������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFOUT_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FOUT_NAME = :" & Ubound(strBindField) - 1 & " --������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FOUT_NAME = :" & Ubound(strBindField) - 1 & " --������")
        End If
        intCount = intCount + 1
        If IsNull(mFTR_VOL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTR_VOL = NULL --�����Ǘ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTR_VOL = NULL --�����Ǘ���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_VOL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTR_VOL = :" & Ubound(strBindField) - 1 & " --�����Ǘ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTR_VOL = :" & Ubound(strBindField) - 1 & " --�����Ǘ���")
        End If
        intCount = intCount + 1
        If IsNull(mFTR_RES_VOL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTR_RES_VOL = NULL --����������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTR_RES_VOL = NULL --����������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_RES_VOL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTR_RES_VOL = :" & Ubound(strBindField) - 1 & " --����������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTR_RES_VOL = :" & Ubound(strBindField) - 1 & " --����������")
        End If
        intCount = intCount + 1
        If IsNull(mFDECIMAL_POINT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDECIMAL_POINT = NULL --�����_�ȉ��L������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDECIMAL_POINT = NULL --�����_�ȉ��L������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDECIMAL_POINT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDECIMAL_POINT = :" & Ubound(strBindField) - 1 & " --�����_�ȉ��L������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDECIMAL_POINT = :" & Ubound(strBindField) - 1 & " --�����_�ȉ��L������")
        End If
        intCount = intCount + 1
        If IsNull(mFHASU_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHASU_FLAG = NULL --�[���׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHASU_FLAG = NULL --�[���׸�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHASU_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHASU_FLAG = :" & Ubound(strBindField) - 1 & " --�[���׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHASU_FLAG = :" & Ubound(strBindField) - 1 & " --�[���׸�")
        End If
        intCount = intCount + 1
        If IsNull(mFLABEL_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLABEL_ID = NULL --����ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLABEL_ID = NULL --����ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLABEL_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLABEL_ID = :" & Ubound(strBindField) - 1 & " --����ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLABEL_ID = :" & Ubound(strBindField) - 1 & " --����ID")
        End If
        intCount = intCount + 1
        If IsNull(mFTRNS_SERIAL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTRNS_SERIAL = NULL --�����ره�(MC��)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTRNS_SERIAL = NULL --�����ره�(MC��)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_SERIAL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTRNS_SERIAL = :" & Ubound(strBindField) - 1 & " --�����ره�(MC��)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTRNS_SERIAL = :" & Ubound(strBindField) - 1 & " --�����ره�(MC��)")
        End If
        intCount = intCount + 1
        If IsNull(mFUSER_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUSER_ID = NULL --հ�ްID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUSER_ID = NULL --հ�ްID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUSER_ID = :" & Ubound(strBindField) - 1 & " --հ�ްID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUSER_ID = :" & Ubound(strBindField) - 1 & " --հ�ްID")
        End If
        intCount = intCount + 1
        If IsNull(mXPROD_LINE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XPROD_LINE = NULL --���Yײ݇�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XPROD_LINE = NULL --���Yײ݇�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPROD_LINE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XPROD_LINE = :" & Ubound(strBindField) - 1 & " --���Yײ݇�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XPROD_LINE = :" & Ubound(strBindField) - 1 & " --���Yײ݇�")
        End If
        intCount = intCount + 1
        If IsNull(mXKENSA_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XKENSA_KUBUN = NULL --�����敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XKENSA_KUBUN = NULL --�����敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKENSA_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XKENSA_KUBUN = :" & Ubound(strBindField) - 1 & " --�����敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XKENSA_KUBUN = :" & Ubound(strBindField) - 1 & " --�����敪")
        End If
        intCount = intCount + 1
        If IsNull(mXKENPIN_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XKENPIN_KUBUN = NULL --���i�敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XKENPIN_KUBUN = NULL --���i�敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKENPIN_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XKENPIN_KUBUN = :" & Ubound(strBindField) - 1 & " --���i�敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XKENPIN_KUBUN = :" & Ubound(strBindField) - 1 & " --���i�敪")
        End If
        intCount = intCount + 1
        If IsNull(mXRAC_IN_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XRAC_IN_DT = NULL --���ɓ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XRAC_IN_DT = NULL --���ɓ���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXRAC_IN_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XRAC_IN_DT = :" & Ubound(strBindField) - 1 & " --���ɓ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XRAC_IN_DT = :" & Ubound(strBindField) - 1 & " --���ɓ���")
        End If
        intCount = intCount + 1
        If IsNull(mXTRK_BUF_NO_IN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTRK_BUF_NO_IN = NULL --�����ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTRK_BUF_NO_IN = NULL --�����ׯ�ݸ��ޯ̧��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_IN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTRK_BUF_NO_IN = :" & Ubound(strBindField) - 1 & " --�����ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTRK_BUF_NO_IN = :" & Ubound(strBindField) - 1 & " --�����ׯ�ݸ��ޯ̧��")
        End If
        intCount = intCount + 1
        If IsNull(mXTRK_BUF_ARRAY_IN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTRK_BUF_ARRAY_IN = NULL --�����ׯ�ݸ��ޯ̧�z��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTRK_BUF_ARRAY_IN = NULL --�����ׯ�ݸ��ޯ̧�z��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_ARRAY_IN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTRK_BUF_ARRAY_IN = :" & Ubound(strBindField) - 1 & " --�����ׯ�ݸ��ޯ̧�z��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTRK_BUF_ARRAY_IN = :" & Ubound(strBindField) - 1 & " --�����ׯ�ݸ��ޯ̧�z��")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FLOG_NO) = True Then
            strSQL.Append(vbCrLf & "    AND FLOG_NO IS NULL --۸އ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            strSQL.Append(vbCrLf & "    AND FLOG_NO = :" & UBound(strBindField) - 1 & " --۸އ�")
        End If
        If IsNull(FLOT_NO_STOCK) = True Then
            strSQL.Append(vbCrLf & "    AND FLOT_NO_STOCK IS NULL --�݌�ۯć�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO_STOCK
            strSQL.Append(vbCrLf & "    AND FLOT_NO_STOCK = :" & UBound(strBindField) - 1 & " --�݌�ۯć�")
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
    Public Sub ADD_TLOG_INOUT()
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
        ElseIf IsNull(mFLOG_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[۸އ�]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFLOT_NO_STOCK) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�݌�ۯć�]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFRESULT_DT) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[���ѓ���]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFPALLET_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[��گ�ID]"
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
        strSQL.Append(vbCrLf & "    TLOG_INOUT")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
        If IsNull(mFLOG_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --۸އ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --۸އ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --۸އ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --۸އ�")
        End If
        intCount = intCount + 1
        If IsNull(mFLOT_NO_STOCK) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�݌�ۯć�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�݌�ۯć�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO_STOCK
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�݌�ۯć�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�݌�ۯć�")
        End If
        intCount = intCount + 1
        If IsNull(mFRESULT_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���ѓ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���ѓ���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRESULT_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���ѓ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���ѓ���")
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
        If IsNull(mFBUF_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�������ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�������ׯ�ݸ��ޯ̧��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧��")
        End If
        intCount = intCount + 1
        If IsNull(mFARRAY_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�������ׯ�ݸ��ޯ̧�z��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�������ׯ�ݸ��ޯ̧�z��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFARRAY_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧�z��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧�z��")
        End If
        intCount = intCount + 1
        If IsNull(mFBUF_TO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�������ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�������ׯ�ݸ��ޯ̧��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_TO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧��")
        End If
        intCount = intCount + 1
        If IsNull(mFARRAY_TO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�������ׯ�ݸ��ޯ̧�z��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�������ׯ�ݸ��ޯ̧�z��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFARRAY_TO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧�z��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧�z��")
        End If
        intCount = intCount + 1
        If IsNull(mFINOUT_STS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --IN/OUT")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --IN/OUT")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINOUT_STS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --IN/OUT")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --IN/OUT")
        End If
        intCount = intCount + 1
        If IsNull(mFSAGYOU_KIND) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --��Ǝ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --��Ǝ��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_KIND
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --��Ǝ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --��Ǝ��")
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
        If IsNull(mFHINMEI_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�i�ں���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�i�ں���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�i�ں���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�i�ں���")
        End If
        intCount = intCount + 1
        If IsNull(mFHINMEI) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�i��_������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�i��_������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�i��_������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�i��_������")
        End If
        intCount = intCount + 1
        If IsNull(mFLOT_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ۯć�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ۯć�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ۯć�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ۯć�")
        End If
        intCount = intCount + 1
        If IsNull(mFTANI) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�P�ʺ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�P�ʺ���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTANI
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�P�ʺ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�P�ʺ���")
        End If
        intCount = intCount + 1
        If IsNull(mFARRIVE_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�݌ɔ�������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�݌ɔ�������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFARRIVE_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�݌ɔ�������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�݌ɔ�������")
        End If
        intCount = intCount + 1
        If IsNull(mFIN_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���ɋ敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���ɋ敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFIN_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���ɋ敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���ɋ敪")
        End If
        intCount = intCount + 1
        If IsNull(mFSEIHIN_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���i�敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���i�敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEIHIN_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���i�敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���i�敪")
        End If
        intCount = intCount + 1
        If IsNull(mFZAIKO_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�݌ɋ敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�݌ɋ敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�݌ɋ敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�݌ɋ敪")
        End If
        intCount = intCount + 1
        If IsNull(mFHORYU_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ۗ��敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ۗ��敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHORYU_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ۗ��敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ۗ��敪")
        End If
        intCount = intCount + 1
        If IsNull(mFST_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --������ST�ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --������ST�ׯ�ݸ��ޯ̧��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFST_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --������ST�ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --������ST�ׯ�ݸ��ޯ̧��")
        End If
        intCount = intCount + 1
        If IsNull(mFOUT_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFOUT_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --������")
        End If
        intCount = intCount + 1
        If IsNull(mFTR_VOL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�����Ǘ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�����Ǘ���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_VOL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�����Ǘ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�����Ǘ���")
        End If
        intCount = intCount + 1
        If IsNull(mFTR_RES_VOL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_RES_VOL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����������")
        End If
        intCount = intCount + 1
        If IsNull(mFDECIMAL_POINT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�����_�ȉ��L������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�����_�ȉ��L������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDECIMAL_POINT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�����_�ȉ��L������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�����_�ȉ��L������")
        End If
        intCount = intCount + 1
        If IsNull(mFHASU_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�[���׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�[���׸�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHASU_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�[���׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�[���׸�")
        End If
        intCount = intCount + 1
        If IsNull(mFLABEL_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLABEL_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����ID")
        End If
        intCount = intCount + 1
        If IsNull(mFTRNS_SERIAL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�����ره�(MC��)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�����ره�(MC��)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_SERIAL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�����ره�(MC��)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�����ره�(MC��)")
        End If
        intCount = intCount + 1
        If IsNull(mFUSER_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --հ�ްID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --հ�ްID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --հ�ްID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --հ�ްID")
        End If
        intCount = intCount + 1
        If IsNull(mXPROD_LINE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���Yײ݇�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���Yײ݇�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPROD_LINE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���Yײ݇�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���Yײ݇�")
        End If
        intCount = intCount + 1
        If IsNull(mXKENSA_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�����敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�����敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKENSA_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�����敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�����敪")
        End If
        intCount = intCount + 1
        If IsNull(mXKENPIN_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���i�敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���i�敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKENPIN_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���i�敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���i�敪")
        End If
        intCount = intCount + 1
        If IsNull(mXRAC_IN_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���ɓ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���ɓ���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXRAC_IN_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���ɓ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���ɓ���")
        End If
        intCount = intCount + 1
        If IsNull(mXTRK_BUF_NO_IN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�����ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�����ׯ�ݸ��ޯ̧��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_IN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�����ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�����ׯ�ݸ��ޯ̧��")
        End If
        intCount = intCount + 1
        If IsNull(mXTRK_BUF_ARRAY_IN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�����ׯ�ݸ��ޯ̧�z��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�����ׯ�ݸ��ޯ̧�z��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_ARRAY_IN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�����ׯ�ݸ��ޯ̧�z��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�����ׯ�ݸ��ޯ̧�z��")
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
    Public Sub DELETE_TLOG_INOUT()
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
        ElseIf IsNull(mFLOG_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[۸އ�]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFLOT_NO_STOCK) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�݌�ۯć�]"
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
        strSQL.Append(vbCrLf & "    TLOG_INOUT")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FLOG_NO) = True Then
            strSQL.Append(vbCrLf & "    AND FLOG_NO IS NULL --۸އ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            strSQL.Append(vbCrLf & "    AND FLOG_NO = :" & UBound(strBindField) - 1 & " --۸އ�")
        End If
        If IsNull(FLOT_NO_STOCK) = True Then
            strSQL.Append(vbCrLf & "    AND FLOT_NO_STOCK IS NULL --�݌�ۯć�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO_STOCK
            strSQL.Append(vbCrLf & "    AND FLOT_NO_STOCK = :" & UBound(strBindField) - 1 & " --�݌�ۯć�")
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
    Public Sub DELETE_TLOG_INOUT_ANY()
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
        strSQL.Append(vbCrLf & "    TLOG_INOUT")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(FLOG_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            strSQL.Append(vbCrLf & "    AND FLOG_NO = :" & UBound(strBindField) - 1 & " --۸އ�")
        End If
        If IsNotNull(FLOT_NO_STOCK) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO_STOCK
            strSQL.Append(vbCrLf & "    AND FLOT_NO_STOCK = :" & UBound(strBindField) - 1 & " --�݌�ۯć�")
        End If
        If IsNotNull(FRESULT_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRESULT_DT
            strSQL.Append(vbCrLf & "    AND FRESULT_DT = :" & UBound(strBindField) - 1 & " --���ѓ���")
        End If
        If IsNotNull(FPALLET_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --��گ�ID")
        End If
        If IsNotNull(FBUF_FM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_FM
            strSQL.Append(vbCrLf & "    AND FBUF_FM = :" & UBound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧��")
        End If
        If IsNotNull(FARRAY_FM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFARRAY_FM
            strSQL.Append(vbCrLf & "    AND FARRAY_FM = :" & UBound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧�z��")
        End If
        If IsNotNull(FBUF_TO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_TO
            strSQL.Append(vbCrLf & "    AND FBUF_TO = :" & UBound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧��")
        End If
        If IsNotNull(FARRAY_TO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFARRAY_TO
            strSQL.Append(vbCrLf & "    AND FARRAY_TO = :" & UBound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧�z��")
        End If
        If IsNotNull(FINOUT_STS) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINOUT_STS
            strSQL.Append(vbCrLf & "    AND FINOUT_STS = :" & UBound(strBindField) - 1 & " --IN/OUT")
        End If
        If IsNotNull(FSAGYOU_KIND) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_KIND
            strSQL.Append(vbCrLf & "    AND FSAGYOU_KIND = :" & UBound(strBindField) - 1 & " --��Ǝ��")
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
        If IsNotNull(FHINMEI_CD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --�i�ں���")
        End If
        If IsNotNull(FHINMEI) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI
            strSQL.Append(vbCrLf & "    AND FHINMEI = :" & UBound(strBindField) - 1 & " --�i��_������")
        End If
        If IsNotNull(FLOT_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO
            strSQL.Append(vbCrLf & "    AND FLOT_NO = :" & UBound(strBindField) - 1 & " --ۯć�")
        End If
        If IsNotNull(FTANI) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTANI
            strSQL.Append(vbCrLf & "    AND FTANI = :" & UBound(strBindField) - 1 & " --�P�ʺ���")
        End If
        If IsNotNull(FARRIVE_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFARRIVE_DT
            strSQL.Append(vbCrLf & "    AND FARRIVE_DT = :" & UBound(strBindField) - 1 & " --�݌ɔ�������")
        End If
        If IsNotNull(FIN_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFIN_KUBUN
            strSQL.Append(vbCrLf & "    AND FIN_KUBUN = :" & UBound(strBindField) - 1 & " --���ɋ敪")
        End If
        If IsNotNull(FSEIHIN_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEIHIN_KUBUN
            strSQL.Append(vbCrLf & "    AND FSEIHIN_KUBUN = :" & UBound(strBindField) - 1 & " --���i�敪")
        End If
        If IsNotNull(FZAIKO_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_KUBUN
            strSQL.Append(vbCrLf & "    AND FZAIKO_KUBUN = :" & UBound(strBindField) - 1 & " --�݌ɋ敪")
        End If
        If IsNotNull(FHORYU_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHORYU_KUBUN
            strSQL.Append(vbCrLf & "    AND FHORYU_KUBUN = :" & UBound(strBindField) - 1 & " --�ۗ��敪")
        End If
        If IsNotNull(FST_FM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFST_FM
            strSQL.Append(vbCrLf & "    AND FST_FM = :" & UBound(strBindField) - 1 & " --������ST�ׯ�ݸ��ޯ̧��")
        End If
        If IsNotNull(FOUT_NAME) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFOUT_NAME
            strSQL.Append(vbCrLf & "    AND FOUT_NAME = :" & UBound(strBindField) - 1 & " --������")
        End If
        If IsNotNull(FTR_VOL) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_VOL
            strSQL.Append(vbCrLf & "    AND FTR_VOL = :" & UBound(strBindField) - 1 & " --�����Ǘ���")
        End If
        If IsNotNull(FTR_RES_VOL) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_RES_VOL
            strSQL.Append(vbCrLf & "    AND FTR_RES_VOL = :" & UBound(strBindField) - 1 & " --����������")
        End If
        If IsNotNull(FDECIMAL_POINT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDECIMAL_POINT
            strSQL.Append(vbCrLf & "    AND FDECIMAL_POINT = :" & UBound(strBindField) - 1 & " --�����_�ȉ��L������")
        End If
        If IsNotNull(FHASU_FLAG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHASU_FLAG
            strSQL.Append(vbCrLf & "    AND FHASU_FLAG = :" & UBound(strBindField) - 1 & " --�[���׸�")
        End If
        If IsNotNull(FLABEL_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLABEL_ID
            strSQL.Append(vbCrLf & "    AND FLABEL_ID = :" & UBound(strBindField) - 1 & " --����ID")
        End If
        If IsNotNull(FTRNS_SERIAL) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_SERIAL
            strSQL.Append(vbCrLf & "    AND FTRNS_SERIAL = :" & UBound(strBindField) - 1 & " --�����ره�(MC��)")
        End If
        If IsNotNull(FUSER_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID
            strSQL.Append(vbCrLf & "    AND FUSER_ID = :" & UBound(strBindField) - 1 & " --հ�ްID")
        End If
        If IsNotNull(XPROD_LINE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPROD_LINE
            strSQL.Append(vbCrLf & "    AND XPROD_LINE = :" & UBound(strBindField) - 1 & " --���Yײ݇�")
        End If
        If IsNotNull(XKENSA_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKENSA_KUBUN
            strSQL.Append(vbCrLf & "    AND XKENSA_KUBUN = :" & UBound(strBindField) - 1 & " --�����敪")
        End If
        If IsNotNull(XKENPIN_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKENPIN_KUBUN
            strSQL.Append(vbCrLf & "    AND XKENPIN_KUBUN = :" & UBound(strBindField) - 1 & " --���i�敪")
        End If
        If IsNotNull(XRAC_IN_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXRAC_IN_DT
            strSQL.Append(vbCrLf & "    AND XRAC_IN_DT = :" & UBound(strBindField) - 1 & " --���ɓ���")
        End If
        If IsNotNull(XTRK_BUF_NO_IN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_IN
            strSQL.Append(vbCrLf & "    AND XTRK_BUF_NO_IN = :" & UBound(strBindField) - 1 & " --�����ׯ�ݸ��ޯ̧��")
        End If
        If IsNotNull(XTRK_BUF_ARRAY_IN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_ARRAY_IN
            strSQL.Append(vbCrLf & "    AND XTRK_BUF_ARRAY_IN = :" & UBound(strBindField) - 1 & " --�����ׯ�ݸ��ޯ̧�z��")
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
        If IsNothing(objType.GetProperty("FLOG_NO")) = False Then mFLOG_NO = objObject.FLOG_NO '۸އ�
        If IsNothing(objType.GetProperty("FLOT_NO_STOCK")) = False Then mFLOT_NO_STOCK = objObject.FLOT_NO_STOCK '�݌�ۯć�
        If IsNothing(objType.GetProperty("FRESULT_DT")) = False Then mFRESULT_DT = objObject.FRESULT_DT '���ѓ���
        If IsNothing(objType.GetProperty("FPALLET_ID")) = False Then mFPALLET_ID = objObject.FPALLET_ID '��گ�ID
        If IsNothing(objType.GetProperty("FBUF_FM")) = False Then mFBUF_FM = objObject.FBUF_FM '�������ׯ�ݸ��ޯ̧��
        If IsNothing(objType.GetProperty("FARRAY_FM")) = False Then mFARRAY_FM = objObject.FARRAY_FM '�������ׯ�ݸ��ޯ̧�z��
        If IsNothing(objType.GetProperty("FBUF_TO")) = False Then mFBUF_TO = objObject.FBUF_TO '�������ׯ�ݸ��ޯ̧��
        If IsNothing(objType.GetProperty("FARRAY_TO")) = False Then mFARRAY_TO = objObject.FARRAY_TO '�������ׯ�ݸ��ޯ̧�z��
        If IsNothing(objType.GetProperty("FINOUT_STS")) = False Then mFINOUT_STS = objObject.FINOUT_STS 'IN/OUT
        If IsNothing(objType.GetProperty("FSAGYOU_KIND")) = False Then mFSAGYOU_KIND = objObject.FSAGYOU_KIND '��Ǝ��
        If IsNothing(objType.GetProperty("FDISP_ADDRESS_FM")) = False Then mFDISP_ADDRESS_FM = objObject.FDISP_ADDRESS_FM 'FM�\�L�p���ڽ
        If IsNothing(objType.GetProperty("FDISP_ADDRESS_TO")) = False Then mFDISP_ADDRESS_TO = objObject.FDISP_ADDRESS_TO 'TO�\�L�p���ڽ
        If IsNothing(objType.GetProperty("FDISPLOG_ADDRESS_FM")) = False Then mFDISPLOG_ADDRESS_FM = objObject.FDISPLOG_ADDRESS_FM 'FM�\�L�p���ڽ_۸ޗp
        If IsNothing(objType.GetProperty("FDISPLOG_ADDRESS_TO")) = False Then mFDISPLOG_ADDRESS_TO = objObject.FDISPLOG_ADDRESS_TO 'TO�\�L�p���ڽ_۸ޗp
        If IsNothing(objType.GetProperty("FHINMEI_CD")) = False Then mFHINMEI_CD = objObject.FHINMEI_CD '�i�ں���
        If IsNothing(objType.GetProperty("FHINMEI")) = False Then mFHINMEI = objObject.FHINMEI '�i��_������
        If IsNothing(objType.GetProperty("FLOT_NO")) = False Then mFLOT_NO = objObject.FLOT_NO 'ۯć�
        If IsNothing(objType.GetProperty("FTANI")) = False Then mFTANI = objObject.FTANI '�P�ʺ���
        If IsNothing(objType.GetProperty("FARRIVE_DT")) = False Then mFARRIVE_DT = objObject.FARRIVE_DT '�݌ɔ�������
        If IsNothing(objType.GetProperty("FIN_KUBUN")) = False Then mFIN_KUBUN = objObject.FIN_KUBUN '���ɋ敪
        If IsNothing(objType.GetProperty("FSEIHIN_KUBUN")) = False Then mFSEIHIN_KUBUN = objObject.FSEIHIN_KUBUN '���i�敪
        If IsNothing(objType.GetProperty("FZAIKO_KUBUN")) = False Then mFZAIKO_KUBUN = objObject.FZAIKO_KUBUN '�݌ɋ敪
        If IsNothing(objType.GetProperty("FHORYU_KUBUN")) = False Then mFHORYU_KUBUN = objObject.FHORYU_KUBUN '�ۗ��敪
        If IsNothing(objType.GetProperty("FST_FM")) = False Then mFST_FM = objObject.FST_FM '������ST�ׯ�ݸ��ޯ̧��
        If IsNothing(objType.GetProperty("FOUT_NAME")) = False Then mFOUT_NAME = objObject.FOUT_NAME '������
        If IsNothing(objType.GetProperty("FTR_VOL")) = False Then mFTR_VOL = objObject.FTR_VOL '�����Ǘ���
        If IsNothing(objType.GetProperty("FTR_RES_VOL")) = False Then mFTR_RES_VOL = objObject.FTR_RES_VOL '����������
        If IsNothing(objType.GetProperty("FDECIMAL_POINT")) = False Then mFDECIMAL_POINT = objObject.FDECIMAL_POINT '�����_�ȉ��L������
        If IsNothing(objType.GetProperty("FHASU_FLAG")) = False Then mFHASU_FLAG = objObject.FHASU_FLAG '�[���׸�
        If IsNothing(objType.GetProperty("FLABEL_ID")) = False Then mFLABEL_ID = objObject.FLABEL_ID '����ID
        If IsNothing(objType.GetProperty("FTRNS_SERIAL")) = False Then mFTRNS_SERIAL = objObject.FTRNS_SERIAL '�����ره�(MC��)
        If IsNothing(objType.GetProperty("FUSER_ID")) = False Then mFUSER_ID = objObject.FUSER_ID 'հ�ްID
        If IsNothing(objType.GetProperty("XPROD_LINE")) = False Then mXPROD_LINE = objObject.XPROD_LINE '���Yײ݇�
        If IsNothing(objType.GetProperty("XKENSA_KUBUN")) = False Then mXKENSA_KUBUN = objObject.XKENSA_KUBUN '�����敪
        If IsNothing(objType.GetProperty("XKENPIN_KUBUN")) = False Then mXKENPIN_KUBUN = objObject.XKENPIN_KUBUN '���i�敪
        If IsNothing(objType.GetProperty("XRAC_IN_DT")) = False Then mXRAC_IN_DT = objObject.XRAC_IN_DT '���ɓ���
        If IsNothing(objType.GetProperty("XTRK_BUF_NO_IN")) = False Then mXTRK_BUF_NO_IN = objObject.XTRK_BUF_NO_IN '�����ׯ�ݸ��ޯ̧��
        If IsNothing(objType.GetProperty("XTRK_BUF_ARRAY_IN")) = False Then mXTRK_BUF_ARRAY_IN = objObject.XTRK_BUF_ARRAY_IN '�����ׯ�ݸ��ޯ̧�z��

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
        mFLOG_NO = Nothing
        mFLOT_NO_STOCK = Nothing
        mFRESULT_DT = Nothing
        mFPALLET_ID = Nothing
        mFBUF_FM = Nothing
        mFARRAY_FM = Nothing
        mFBUF_TO = Nothing
        mFARRAY_TO = Nothing
        mFINOUT_STS = Nothing
        mFSAGYOU_KIND = Nothing
        mFDISP_ADDRESS_FM = Nothing
        mFDISP_ADDRESS_TO = Nothing
        mFDISPLOG_ADDRESS_FM = Nothing
        mFDISPLOG_ADDRESS_TO = Nothing
        mFHINMEI_CD = Nothing
        mFHINMEI = Nothing
        mFLOT_NO = Nothing
        mFTANI = Nothing
        mFARRIVE_DT = Nothing
        mFIN_KUBUN = Nothing
        mFSEIHIN_KUBUN = Nothing
        mFZAIKO_KUBUN = Nothing
        mFHORYU_KUBUN = Nothing
        mFST_FM = Nothing
        mFOUT_NAME = Nothing
        mFTR_VOL = Nothing
        mFTR_RES_VOL = Nothing
        mFDECIMAL_POINT = Nothing
        mFHASU_FLAG = Nothing
        mFLABEL_ID = Nothing
        mFTRNS_SERIAL = Nothing
        mFUSER_ID = Nothing
        mXPROD_LINE = Nothing
        mXKENSA_KUBUN = Nothing
        mXKENPIN_KUBUN = Nothing
        mXRAC_IN_DT = Nothing
        mXTRK_BUF_NO_IN = Nothing
        mXTRK_BUF_ARRAY_IN = Nothing


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
        mFLOG_NO = TO_STRING_NULLABLE(objRow("FLOG_NO"))
        mFLOT_NO_STOCK = TO_STRING_NULLABLE(objRow("FLOT_NO_STOCK"))
        mFRESULT_DT = TO_DATE_NULLABLE(objRow("FRESULT_DT"))
        mFPALLET_ID = TO_STRING_NULLABLE(objRow("FPALLET_ID"))
        mFBUF_FM = TO_INTEGER_NULLABLE(objRow("FBUF_FM"))
        mFARRAY_FM = TO_INTEGER_NULLABLE(objRow("FARRAY_FM"))
        mFBUF_TO = TO_INTEGER_NULLABLE(objRow("FBUF_TO"))
        mFARRAY_TO = TO_INTEGER_NULLABLE(objRow("FARRAY_TO"))
        mFINOUT_STS = TO_INTEGER_NULLABLE(objRow("FINOUT_STS"))
        mFSAGYOU_KIND = TO_INTEGER_NULLABLE(objRow("FSAGYOU_KIND"))
        mFDISP_ADDRESS_FM = TO_STRING_NULLABLE(objRow("FDISP_ADDRESS_FM"))
        mFDISP_ADDRESS_TO = TO_STRING_NULLABLE(objRow("FDISP_ADDRESS_TO"))
        mFDISPLOG_ADDRESS_FM = TO_STRING_NULLABLE(objRow("FDISPLOG_ADDRESS_FM"))
        mFDISPLOG_ADDRESS_TO = TO_STRING_NULLABLE(objRow("FDISPLOG_ADDRESS_TO"))
        mFHINMEI_CD = TO_STRING_NULLABLE(objRow("FHINMEI_CD"))
        mFHINMEI = TO_STRING_NULLABLE(objRow("FHINMEI"))
        mFLOT_NO = TO_STRING_NULLABLE(objRow("FLOT_NO"))
        mFTANI = TO_STRING_NULLABLE(objRow("FTANI"))
        mFARRIVE_DT = TO_DATE_NULLABLE(objRow("FARRIVE_DT"))
        mFIN_KUBUN = TO_INTEGER_NULLABLE(objRow("FIN_KUBUN"))
        mFSEIHIN_KUBUN = TO_INTEGER_NULLABLE(objRow("FSEIHIN_KUBUN"))
        mFZAIKO_KUBUN = TO_INTEGER_NULLABLE(objRow("FZAIKO_KUBUN"))
        mFHORYU_KUBUN = TO_INTEGER_NULLABLE(objRow("FHORYU_KUBUN"))
        mFST_FM = TO_INTEGER_NULLABLE(objRow("FST_FM"))
        mFOUT_NAME = TO_STRING_NULLABLE(objRow("FOUT_NAME"))
        mFTR_VOL = TO_DECIMAL_NULLABLE(objRow("FTR_VOL"))
        mFTR_RES_VOL = TO_DECIMAL_NULLABLE(objRow("FTR_RES_VOL"))
        mFDECIMAL_POINT = TO_INTEGER_NULLABLE(objRow("FDECIMAL_POINT"))
        mFHASU_FLAG = TO_INTEGER_NULLABLE(objRow("FHASU_FLAG"))
        mFLABEL_ID = TO_STRING_NULLABLE(objRow("FLABEL_ID"))
        mFTRNS_SERIAL = TO_STRING_NULLABLE(objRow("FTRNS_SERIAL"))
        mFUSER_ID = TO_STRING_NULLABLE(objRow("FUSER_ID"))
        mXPROD_LINE = TO_STRING_NULLABLE(objRow("XPROD_LINE"))
        mXKENSA_KUBUN = TO_STRING_NULLABLE(objRow("XKENSA_KUBUN"))
        mXKENPIN_KUBUN = TO_STRING_NULLABLE(objRow("XKENPIN_KUBUN"))
        mXRAC_IN_DT = TO_DATE_NULLABLE(objRow("XRAC_IN_DT"))
        mXTRK_BUF_NO_IN = TO_INTEGER_NULLABLE(objRow("XTRK_BUF_NO_IN"))
        mXTRK_BUF_ARRAY_IN = TO_INTEGER_NULLABLE(objRow("XTRK_BUF_ARRAY_IN"))


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
        strMsg &= "[ð��ٖ�:INOUT����]"
        If IsNotNull(FLOG_NO) Then
            strMsg &= "[۸އ�:" & FLOG_NO & "]"
        End If
        If IsNotNull(FLOT_NO_STOCK) Then
            strMsg &= "[�݌�ۯć�:" & FLOT_NO_STOCK & "]"
        End If
        If IsNotNull(FRESULT_DT) Then
            strMsg &= "[���ѓ���:" & FRESULT_DT & "]"
        End If
        If IsNotNull(FPALLET_ID) Then
            strMsg &= "[��گ�ID:" & FPALLET_ID & "]"
        End If
        If IsNotNull(FBUF_FM) Then
            strMsg &= "[�������ׯ�ݸ��ޯ̧��:" & FBUF_FM & "]"
        End If
        If IsNotNull(FARRAY_FM) Then
            strMsg &= "[�������ׯ�ݸ��ޯ̧�z��:" & FARRAY_FM & "]"
        End If
        If IsNotNull(FBUF_TO) Then
            strMsg &= "[�������ׯ�ݸ��ޯ̧��:" & FBUF_TO & "]"
        End If
        If IsNotNull(FARRAY_TO) Then
            strMsg &= "[�������ׯ�ݸ��ޯ̧�z��:" & FARRAY_TO & "]"
        End If
        If IsNotNull(FINOUT_STS) Then
            strMsg &= "[IN/OUT:" & FINOUT_STS & "]"
        End If
        If IsNotNull(FSAGYOU_KIND) Then
            strMsg &= "[��Ǝ��:" & FSAGYOU_KIND & "]"
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
        If IsNotNull(FHINMEI_CD) Then
            strMsg &= "[�i�ں���:" & FHINMEI_CD & "]"
        End If
        If IsNotNull(FHINMEI) Then
            strMsg &= "[�i��_������:" & FHINMEI & "]"
        End If
        If IsNotNull(FLOT_NO) Then
            strMsg &= "[ۯć�:" & FLOT_NO & "]"
        End If
        If IsNotNull(FTANI) Then
            strMsg &= "[�P�ʺ���:" & FTANI & "]"
        End If
        If IsNotNull(FARRIVE_DT) Then
            strMsg &= "[�݌ɔ�������:" & FARRIVE_DT & "]"
        End If
        If IsNotNull(FIN_KUBUN) Then
            strMsg &= "[���ɋ敪:" & FIN_KUBUN & "]"
        End If
        If IsNotNull(FSEIHIN_KUBUN) Then
            strMsg &= "[���i�敪:" & FSEIHIN_KUBUN & "]"
        End If
        If IsNotNull(FZAIKO_KUBUN) Then
            strMsg &= "[�݌ɋ敪:" & FZAIKO_KUBUN & "]"
        End If
        If IsNotNull(FHORYU_KUBUN) Then
            strMsg &= "[�ۗ��敪:" & FHORYU_KUBUN & "]"
        End If
        If IsNotNull(FST_FM) Then
            strMsg &= "[������ST�ׯ�ݸ��ޯ̧��:" & FST_FM & "]"
        End If
        If IsNotNull(FOUT_NAME) Then
            strMsg &= "[������:" & FOUT_NAME & "]"
        End If
        If IsNotNull(FTR_VOL) Then
            strMsg &= "[�����Ǘ���:" & FTR_VOL & "]"
        End If
        If IsNotNull(FTR_RES_VOL) Then
            strMsg &= "[����������:" & FTR_RES_VOL & "]"
        End If
        If IsNotNull(FDECIMAL_POINT) Then
            strMsg &= "[�����_�ȉ��L������:" & FDECIMAL_POINT & "]"
        End If
        If IsNotNull(FHASU_FLAG) Then
            strMsg &= "[�[���׸�:" & FHASU_FLAG & "]"
        End If
        If IsNotNull(FLABEL_ID) Then
            strMsg &= "[����ID:" & FLABEL_ID & "]"
        End If
        If IsNotNull(FTRNS_SERIAL) Then
            strMsg &= "[�����ره�(MC��):" & FTRNS_SERIAL & "]"
        End If
        If IsNotNull(FUSER_ID) Then
            strMsg &= "[հ�ްID:" & FUSER_ID & "]"
        End If
        If IsNotNull(XPROD_LINE) Then
            strMsg &= "[���Yײ݇�:" & XPROD_LINE & "]"
        End If
        If IsNotNull(XKENSA_KUBUN) Then
            strMsg &= "[�����敪:" & XKENSA_KUBUN & "]"
        End If
        If IsNotNull(XKENPIN_KUBUN) Then
            strMsg &= "[���i�敪:" & XKENPIN_KUBUN & "]"
        End If
        If IsNotNull(XRAC_IN_DT) Then
            strMsg &= "[���ɓ���:" & XRAC_IN_DT & "]"
        End If
        If IsNotNull(XTRK_BUF_NO_IN) Then
            strMsg &= "[�����ׯ�ݸ��ޯ̧��:" & XTRK_BUF_NO_IN & "]"
        End If
        If IsNotNull(XTRK_BUF_ARRAY_IN) Then
            strMsg &= "[�����ׯ�ݸ��ޯ̧�z��:" & XTRK_BUF_ARRAY_IN & "]"
        End If


    End Sub
#End Region
    '����������������
    '**********************************************************************************************

    '**********************************************************************************************
    '���������ы���
#Region "  �׽�ϐ���`"
    '�����è(ð��ٗ�)
    Private mobjTRST_STOCK As TBL_TRST_STOCK            '�݌ɏ��
#End Region
#Region "  �����è��`"
    Public Property OBJTRST_STOCK() As TBL_TRST_STOCK
        Get
            Return mobjTRST_STOCK
        End Get
        Set(ByVal Value As TBL_TRST_STOCK)
            mobjTRST_STOCK = Value
        End Set
    End Property
#End Region
#Region "  INOUT���ђǉ�    [�t����񍞂�]      (Public  ADD_TLOG_INOUT_ALL)"
    Public Sub ADD_TLOG_INOUT_ALL()
        Try
            Dim strMsg As String        'ү����
            Dim dtmNow As Date = Now

            '***********************
            '�����è����
            '***********************
            If IsNull(mFRESULT_DT) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[���ѓ���]"
                Throw New UserException(strMsg)
                '' ''ElseIf mFPALLET_ID = DEFAULT_STRING Then
                '' ''    strMsg = ERRMSG_ERR_PROPERTY & "[��گ�ID]"
                '' ''    Throw New UserException(strMsg)
                '' ''ElseIf IsNull(mFBUF_FM) = True Then
                '' ''    strMsg = ERRMSG_ERR_PROPERTY & "[���ޯ̧��]"
                '' ''    Throw New UserException(strMsg)
                '' ''ElseIf IsNull(mFARRAY_FM) = True Then
                '' ''    strMsg = ERRMSG_ERR_PROPERTY & "[���z��]"
                '' ''    Throw New UserException(strMsg)
                '' ''ElseIf IsNull(mFBUF_TO) = True Then
                '' ''    strMsg = ERRMSG_ERR_PROPERTY & "[���ޯ̧��]"
                '' ''    Throw New UserException(strMsg)
                '' ''ElseIf IsNull(mFARRAY_TO) = True Then
                '' ''    strMsg = ERRMSG_ERR_PROPERTY & "[��z��]"
                '' ''    Throw New UserException(strMsg)
            ElseIf IsNull(mobjTRST_STOCK) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�݌ɏ���޼ު��]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '۸އ��̓���
            '***********************
            Dim objTPRG_SEQNO As New TBL_TPRG_SEQNO(Owner, ObjDb, ObjDbLog) '���ݽ���׽
            objTPRG_SEQNO.FSEQ_ID = FSEQ_ID_SSVRLOG_NO_INOUT                 '���ݽID(INOUT����)
            mFLOG_NO = objTPRG_SEQNO.GET_ENTRY_NO()                         'SEQ�̓���


            For ii As Integer = LBound(mobjTRST_STOCK.ARYME) To UBound(mobjTRST_STOCK.ARYME)
                '(���ڍ݌ɏ��̐�����)

                '***********************
                '�����ره��擾
                '***********************
                Dim objTPRG_SERIAL As New TBL_TPRG_SERIAL(Owner, ObjDb, ObjDbLog)   '�ري֘A�t���׽
                objTPRG_SERIAL.FPALLET_ID = mobjTRST_STOCK.ARYME(ii).FPALLET_ID     '��گ�ID
                objTPRG_SERIAL.GET_TPRG_SERIAL(False)                               '����


                '***********************
                '�i��Ͻ��擾
                '***********************
                Dim objTMST_ITEM As New TBL_TMST_ITEM(Owner, ObjDb, ObjDbLog)
                objTMST_ITEM.FHINMEI_CD = mobjTRST_STOCK.ARYME(ii).FHINMEI_CD
                objTMST_ITEM.GET_TMST_ITEM(False)


                '***********************
                'INOUT���т̓o�^
                '***********************
                Call COPY_PROPERTY(mobjTRST_STOCK.ARYME(ii))
                mFRESULT_DT = dtmNow                                            '���ѓ���
                mFHINMEI_CD = objTMST_ITEM.FHINMEI_CD                           '�i������
                mFHINMEI = objTMST_ITEM.FHINMEI                                 '�i��
                'mXArticleShortName = objTMST_ITEM.XArticleShortName              '�i�ڗ���
                mFTANI = objTMST_ITEM.FTANI                                     '�P��
                mFTRNS_SERIAL = objTPRG_SERIAL.FTRNS_SERIAL                     '�����ره�
                mFDECIMAL_POINT = objTMST_ITEM.FDECIMAL_POINT                   '�����_����
                Me.ADD_TLOG_INOUT()                                             '�ǉ�


            Next


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
    '���������ы���
    '**********************************************************************************************


    '**********************************************************************************************
    '���������ьŗL

    '���������ьŗL
    '**********************************************************************************************

End Class
