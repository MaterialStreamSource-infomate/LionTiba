'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' �y���́zMaterialStreamð��ٸ׽
' �y�@�\�z�o�׎��яڍ�ð��ٸ׽
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
''' �o�׎��яڍ�ð��ٸ׽
''' </summary>
Public Class TBL_XRST_OUT_DTL
    Inherits clsTemplateTable

    '**********************************************************************************************
    '����������������
#Region "  �׽�ϐ���`                  "
    '�����è
    Private mobjAryMe As TBL_XRST_OUT_DTL()                                      '�o�׎��яڍ�
    Private mstrUSER_SQL As String                                               'հ�ްSQL
    Private mORDER_BY As String                                                  'OrderBy��
    Private mWHERE As String                                                     'Where��
    Private mXSYUKKA_D As Nullable(Of Date)                                      '�o�ד�
    Private mXHENSEI_NO As String                                                '�Ґ�No.
    Private mXDENPYOU_NO As String                                               '�`�[No.
    Private mXSYUKKA_RESULT_DT As Nullable(Of Date)                              '�o�׎��ѓ���
    Private mFPALLET_ID As String                                                '��گ�ID
    Private mFHINMEI_CD As String                                                '�i�ں���
    Private mFLOT_NO As String                                                   'ۯć�
    Private mXNUM As Nullable(Of Decimal)                                        '����
    Private mXTUMI_HOUKOU As Nullable(Of Integer)                                '�ύ�����
    Private mXTUMI_HOUHOU As Nullable(Of Integer)                                '�ύ����@
    Private mFIN_KUBUN As Nullable(Of Integer)                                   '���ɋ敪
    Private mFARRIVE_DT As Nullable(Of Date)                                     '�݌ɔ�������
    Private mXPROD_LINE As String                                                '���Yײ݇�
    Private mXFM_ST As Nullable(Of Integer)                                      '�������ð���No.
    Private mFBUF_FM As Nullable(Of Integer)                                     '�������ׯ�ݸ��ޯ̧��
    Private mFARRAY_FM As Nullable(Of Integer)                                   '�������ׯ�ݸ��ޯ̧�z��
    Private mFBUF_TO As Nullable(Of Integer)                                     '�������ׯ�ݸ��ޯ̧��
    Private mFARRAY_TO As Nullable(Of Integer)                                   '�������ׯ�ݸ��ޯ̧�z��
    Private mXBERTH_NO As String                                                 '�ް�No.
    Private mXSEND_NAME As String                                                '�͂��於��
    Private mXGYOUSYA_CD As String                                               '�����ƎҺ���
    Private mXHINMEI_CD As String                                                '�i�ں���(�����i�ں���)
    Private mXRAC_IN_DT As Nullable(Of Date)                                     '���ɓ���
    Private mXSYARYOU_NO As Nullable(Of Integer)                                 '���q�ԍ�
    Private mXKENPIN_KUBUN As String                                             '���i�敪
    Private mXSAIMOKU As String                                                  '����敪�ז�
    Private mXIDOU_KBN As String                                                 '�ړ��敪
    Private mXSYASYU_KBN As String                                               '�Ԏ�敪
    Private mXARTICLE_TYPE_CODE As Nullable(Of Integer)                          '�i�ڎ��(���i�敪)
    Private mXUNKOU_NO As String                                                 '�q�ɕʉ^�sNo.
    Private mXHENSEI_NO_OYA As String                                            '�e�Ґ�No.
#End Region
#Region "  �����è��`                  "
    ''' <summary>
    ''' ���ѕϐ� (���׽�^�z��)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_XRST_OUT_DTL()
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
    ''' �o�ד�
    ''' </summary>
    Public Property XSYUKKA_D() As Nullable(Of Date)
        Get
            Return mXSYUKKA_D
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mXSYUKKA_D = Value
        End Set
    End Property
    ''' <summary>
    ''' �Ґ�No.
    ''' </summary>
    Public Property XHENSEI_NO() As String
        Get
            Return mXHENSEI_NO
        End Get
        Set(ByVal Value As String)
            mXHENSEI_NO = Value
        End Set
    End Property
    ''' <summary>
    ''' �`�[No.
    ''' </summary>
    Public Property XDENPYOU_NO() As String
        Get
            Return mXDENPYOU_NO
        End Get
        Set(ByVal Value As String)
            mXDENPYOU_NO = Value
        End Set
    End Property
    ''' <summary>
    ''' �o�׎��ѓ���
    ''' </summary>
    Public Property XSYUKKA_RESULT_DT() As Nullable(Of Date)
        Get
            Return mXSYUKKA_RESULT_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mXSYUKKA_RESULT_DT = Value
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
    ''' ����
    ''' </summary>
    Public Property XNUM() As Nullable(Of Decimal)
        Get
            Return mXNUM
        End Get
        Set(ByVal Value As Nullable(Of Decimal))
            mXNUM = Value
        End Set
    End Property
    ''' <summary>
    ''' �ύ�����
    ''' </summary>
    Public Property XTUMI_HOUKOU() As Nullable(Of Integer)
        Get
            Return mXTUMI_HOUKOU
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXTUMI_HOUKOU = Value
        End Set
    End Property
    ''' <summary>
    ''' �ύ����@
    ''' </summary>
    Public Property XTUMI_HOUHOU() As Nullable(Of Integer)
        Get
            Return mXTUMI_HOUHOU
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXTUMI_HOUHOU = Value
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
    ''' �������ð���No.
    ''' </summary>
    Public Property XFM_ST() As Nullable(Of Integer)
        Get
            Return mXFM_ST
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXFM_ST = Value
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
    ''' �ް�No.
    ''' </summary>
    Public Property XBERTH_NO() As String
        Get
            Return mXBERTH_NO
        End Get
        Set(ByVal Value As String)
            mXBERTH_NO = Value
        End Set
    End Property
    ''' <summary>
    ''' �͂��於��
    ''' </summary>
    Public Property XSEND_NAME() As String
        Get
            Return mXSEND_NAME
        End Get
        Set(ByVal Value As String)
            mXSEND_NAME = Value
        End Set
    End Property
    ''' <summary>
    ''' �����ƎҺ���
    ''' </summary>
    Public Property XGYOUSYA_CD() As String
        Get
            Return mXGYOUSYA_CD
        End Get
        Set(ByVal Value As String)
            mXGYOUSYA_CD = Value
        End Set
    End Property
    ''' <summary>
    ''' �i�ں���(�����i�ں���)
    ''' </summary>
    Public Property XHINMEI_CD() As String
        Get
            Return mXHINMEI_CD
        End Get
        Set(ByVal Value As String)
            mXHINMEI_CD = Value
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
    ''' ���q�ԍ�
    ''' </summary>
    Public Property XSYARYOU_NO() As Nullable(Of Integer)
        Get
            Return mXSYARYOU_NO
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXSYARYOU_NO = Value
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
    ''' ����敪�ז�
    ''' </summary>
    Public Property XSAIMOKU() As String
        Get
            Return mXSAIMOKU
        End Get
        Set(ByVal Value As String)
            mXSAIMOKU = Value
        End Set
    End Property
    ''' <summary>
    ''' �ړ��敪
    ''' </summary>
    Public Property XIDOU_KBN() As String
        Get
            Return mXIDOU_KBN
        End Get
        Set(ByVal Value As String)
            mXIDOU_KBN = Value
        End Set
    End Property
    ''' <summary>
    ''' �Ԏ�敪
    ''' </summary>
    Public Property XSYASYU_KBN() As String
        Get
            Return mXSYASYU_KBN
        End Get
        Set(ByVal Value As String)
            mXSYASYU_KBN = Value
        End Set
    End Property
    ''' <summary>
    ''' �i�ڎ��(���i�敪)
    ''' </summary>
    Public Property XARTICLE_TYPE_CODE() As Nullable(Of Integer)
        Get
            Return mXARTICLE_TYPE_CODE
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXARTICLE_TYPE_CODE = Value
        End Set
    End Property
    ''' <summary>
    ''' �q�ɕʉ^�sNo.
    ''' </summary>
    Public Property XUNKOU_NO() As String
        Get
            Return mXUNKOU_NO
        End Get
        Set(ByVal Value As String)
            mXUNKOU_NO = Value
        End Set
    End Property
    ''' <summary>
    ''' �e�Ґ�No.
    ''' </summary>
    Public Property XHENSEI_NO_OYA() As String
        Get
            Return mXHENSEI_NO_OYA
        End Get
        Set(ByVal Value As String)
            mXHENSEI_NO_OYA = Value
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
    Public Function GET_XRST_OUT_DTL(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    XRST_OUT_DTL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XSYUKKA_D) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D = :" & UBound(strBindField) - 1 & " --�o�ד�")
        End If
        If IsNull(XHENSEI_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO = :" & UBound(strBindField) - 1 & " --�Ґ�No.")
        End If
        If IsNull(XDENPYOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDENPYOU_NO
            strSQL.Append(vbCrLf & "    AND XDENPYOU_NO = :" & UBound(strBindField) - 1 & " --�`�[No.")
        End If
        If IsNull(XSYUKKA_RESULT_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_RESULT_DT
            strSQL.Append(vbCrLf & "    AND XSYUKKA_RESULT_DT = :" & UBound(strBindField) - 1 & " --�o�׎��ѓ���")
        End If
        If IsNull(FPALLET_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --��گ�ID")
        End If
        If IsNull(FHINMEI_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --�i�ں���")
        End If
        If IsNull(FLOT_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO
            strSQL.Append(vbCrLf & "    AND FLOT_NO = :" & UBound(strBindField) - 1 & " --ۯć�")
        End If
        If IsNull(XNUM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXNUM
            strSQL.Append(vbCrLf & "    AND XNUM = :" & UBound(strBindField) - 1 & " --����")
        End If
        If IsNull(XTUMI_HOUKOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_HOUKOU
            strSQL.Append(vbCrLf & "    AND XTUMI_HOUKOU = :" & UBound(strBindField) - 1 & " --�ύ�����")
        End If
        If IsNull(XTUMI_HOUHOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_HOUHOU
            strSQL.Append(vbCrLf & "    AND XTUMI_HOUHOU = :" & UBound(strBindField) - 1 & " --�ύ����@")
        End If
        If IsNull(FIN_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFIN_KUBUN
            strSQL.Append(vbCrLf & "    AND FIN_KUBUN = :" & UBound(strBindField) - 1 & " --���ɋ敪")
        End If
        If IsNull(FARRIVE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFARRIVE_DT
            strSQL.Append(vbCrLf & "    AND FARRIVE_DT = :" & UBound(strBindField) - 1 & " --�݌ɔ�������")
        End If
        If IsNull(XPROD_LINE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPROD_LINE
            strSQL.Append(vbCrLf & "    AND XPROD_LINE = :" & UBound(strBindField) - 1 & " --���Yײ݇�")
        End If
        If IsNull(XFM_ST) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXFM_ST
            strSQL.Append(vbCrLf & "    AND XFM_ST = :" & UBound(strBindField) - 1 & " --�������ð���No.")
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
        If IsNull(XBERTH_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_NO
            strSQL.Append(vbCrLf & "    AND XBERTH_NO = :" & UBound(strBindField) - 1 & " --�ް�No.")
        End If
        If IsNull(XSEND_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSEND_NAME
            strSQL.Append(vbCrLf & "    AND XSEND_NAME = :" & UBound(strBindField) - 1 & " --�͂��於��")
        End If
        If IsNull(XGYOUSYA_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_CD
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_CD = :" & UBound(strBindField) - 1 & " --�����ƎҺ���")
        End If
        If IsNull(XHINMEI_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHINMEI_CD
            strSQL.Append(vbCrLf & "    AND XHINMEI_CD = :" & UBound(strBindField) - 1 & " --�i�ں���(�����i�ں���)")
        End If
        If IsNull(XRAC_IN_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXRAC_IN_DT
            strSQL.Append(vbCrLf & "    AND XRAC_IN_DT = :" & UBound(strBindField) - 1 & " --���ɓ���")
        End If
        If IsNull(XSYARYOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYARYOU_NO
            strSQL.Append(vbCrLf & "    AND XSYARYOU_NO = :" & UBound(strBindField) - 1 & " --���q�ԍ�")
        End If
        If IsNull(XKENPIN_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKENPIN_KUBUN
            strSQL.Append(vbCrLf & "    AND XKENPIN_KUBUN = :" & UBound(strBindField) - 1 & " --���i�敪")
        End If
        If IsNull(XSAIMOKU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSAIMOKU
            strSQL.Append(vbCrLf & "    AND XSAIMOKU = :" & UBound(strBindField) - 1 & " --����敪�ז�")
        End If
        If IsNull(XIDOU_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIDOU_KBN
            strSQL.Append(vbCrLf & "    AND XIDOU_KBN = :" & UBound(strBindField) - 1 & " --�ړ��敪")
        End If
        If IsNull(XSYASYU_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYASYU_KBN
            strSQL.Append(vbCrLf & "    AND XSYASYU_KBN = :" & UBound(strBindField) - 1 & " --�Ԏ�敪")
        End If
        If IsNull(XARTICLE_TYPE_CODE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXARTICLE_TYPE_CODE
            strSQL.Append(vbCrLf & "    AND XARTICLE_TYPE_CODE = :" & UBound(strBindField) - 1 & " --�i�ڎ��(���i�敪)")
        End If
        If IsNull(XUNKOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXUNKOU_NO
            strSQL.Append(vbCrLf & "    AND XUNKOU_NO = :" & UBound(strBindField) - 1 & " --�q�ɕʉ^�sNo.")
        End If
        If IsNull(XHENSEI_NO_OYA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO_OYA = :" & UBound(strBindField) - 1 & " --�e�Ґ�No.")
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
        strDataSetName = "XRST_OUT_DTL"
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
    Public Function GET_XRST_OUT_DTL_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    XRST_OUT_DTL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XSYUKKA_D) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D = :" & UBound(strBindField) - 1 & " --�o�ד�")
        End If
        If IsNull(XHENSEI_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO = :" & UBound(strBindField) - 1 & " --�Ґ�No.")
        End If
        If IsNull(XDENPYOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDENPYOU_NO
            strSQL.Append(vbCrLf & "    AND XDENPYOU_NO = :" & UBound(strBindField) - 1 & " --�`�[No.")
        End If
        If IsNull(XSYUKKA_RESULT_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_RESULT_DT
            strSQL.Append(vbCrLf & "    AND XSYUKKA_RESULT_DT = :" & UBound(strBindField) - 1 & " --�o�׎��ѓ���")
        End If
        If IsNull(FPALLET_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --��گ�ID")
        End If
        If IsNull(FHINMEI_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --�i�ں���")
        End If
        If IsNull(FLOT_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO
            strSQL.Append(vbCrLf & "    AND FLOT_NO = :" & UBound(strBindField) - 1 & " --ۯć�")
        End If
        If IsNull(XNUM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXNUM
            strSQL.Append(vbCrLf & "    AND XNUM = :" & UBound(strBindField) - 1 & " --����")
        End If
        If IsNull(XTUMI_HOUKOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_HOUKOU
            strSQL.Append(vbCrLf & "    AND XTUMI_HOUKOU = :" & UBound(strBindField) - 1 & " --�ύ�����")
        End If
        If IsNull(XTUMI_HOUHOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_HOUHOU
            strSQL.Append(vbCrLf & "    AND XTUMI_HOUHOU = :" & UBound(strBindField) - 1 & " --�ύ����@")
        End If
        If IsNull(FIN_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFIN_KUBUN
            strSQL.Append(vbCrLf & "    AND FIN_KUBUN = :" & UBound(strBindField) - 1 & " --���ɋ敪")
        End If
        If IsNull(FARRIVE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFARRIVE_DT
            strSQL.Append(vbCrLf & "    AND FARRIVE_DT = :" & UBound(strBindField) - 1 & " --�݌ɔ�������")
        End If
        If IsNull(XPROD_LINE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPROD_LINE
            strSQL.Append(vbCrLf & "    AND XPROD_LINE = :" & UBound(strBindField) - 1 & " --���Yײ݇�")
        End If
        If IsNull(XFM_ST) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXFM_ST
            strSQL.Append(vbCrLf & "    AND XFM_ST = :" & UBound(strBindField) - 1 & " --�������ð���No.")
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
        If IsNull(XBERTH_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_NO
            strSQL.Append(vbCrLf & "    AND XBERTH_NO = :" & UBound(strBindField) - 1 & " --�ް�No.")
        End If
        If IsNull(XSEND_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSEND_NAME
            strSQL.Append(vbCrLf & "    AND XSEND_NAME = :" & UBound(strBindField) - 1 & " --�͂��於��")
        End If
        If IsNull(XGYOUSYA_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_CD
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_CD = :" & UBound(strBindField) - 1 & " --�����ƎҺ���")
        End If
        If IsNull(XHINMEI_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHINMEI_CD
            strSQL.Append(vbCrLf & "    AND XHINMEI_CD = :" & UBound(strBindField) - 1 & " --�i�ں���(�����i�ں���)")
        End If
        If IsNull(XRAC_IN_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXRAC_IN_DT
            strSQL.Append(vbCrLf & "    AND XRAC_IN_DT = :" & UBound(strBindField) - 1 & " --���ɓ���")
        End If
        If IsNull(XSYARYOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYARYOU_NO
            strSQL.Append(vbCrLf & "    AND XSYARYOU_NO = :" & UBound(strBindField) - 1 & " --���q�ԍ�")
        End If
        If IsNull(XKENPIN_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKENPIN_KUBUN
            strSQL.Append(vbCrLf & "    AND XKENPIN_KUBUN = :" & UBound(strBindField) - 1 & " --���i�敪")
        End If
        If IsNull(XSAIMOKU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSAIMOKU
            strSQL.Append(vbCrLf & "    AND XSAIMOKU = :" & UBound(strBindField) - 1 & " --����敪�ז�")
        End If
        If IsNull(XIDOU_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIDOU_KBN
            strSQL.Append(vbCrLf & "    AND XIDOU_KBN = :" & UBound(strBindField) - 1 & " --�ړ��敪")
        End If
        If IsNull(XSYASYU_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYASYU_KBN
            strSQL.Append(vbCrLf & "    AND XSYASYU_KBN = :" & UBound(strBindField) - 1 & " --�Ԏ�敪")
        End If
        If IsNull(XARTICLE_TYPE_CODE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXARTICLE_TYPE_CODE
            strSQL.Append(vbCrLf & "    AND XARTICLE_TYPE_CODE = :" & UBound(strBindField) - 1 & " --�i�ڎ��(���i�敪)")
        End If
        If IsNull(XUNKOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXUNKOU_NO
            strSQL.Append(vbCrLf & "    AND XUNKOU_NO = :" & UBound(strBindField) - 1 & " --�q�ɕʉ^�sNo.")
        End If
        If IsNull(XHENSEI_NO_OYA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO_OYA = :" & UBound(strBindField) - 1 & " --�e�Ґ�No.")
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
        strDataSetName = "XRST_OUT_DTL"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XRST_OUT_DTL(Owner, objDb, objDbLog)
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
    Public Function GET_XRST_OUT_DTL_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "XRST_OUT_DTL"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XRST_OUT_DTL(Owner, objDb, objDbLog)
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
    Public Function GET_XRST_OUT_DTL_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    XRST_OUT_DTL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XSYUKKA_D) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D = :" & UBound(strBindField) - 1 & " --�o�ד�")
        End If
        If IsNull(XHENSEI_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO = :" & UBound(strBindField) - 1 & " --�Ґ�No.")
        End If
        If IsNull(XDENPYOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDENPYOU_NO
            strSQL.Append(vbCrLf & "    AND XDENPYOU_NO = :" & UBound(strBindField) - 1 & " --�`�[No.")
        End If
        If IsNull(XSYUKKA_RESULT_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_RESULT_DT
            strSQL.Append(vbCrLf & "    AND XSYUKKA_RESULT_DT = :" & UBound(strBindField) - 1 & " --�o�׎��ѓ���")
        End If
        If IsNull(FPALLET_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --��گ�ID")
        End If
        If IsNull(FHINMEI_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --�i�ں���")
        End If
        If IsNull(FLOT_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO
            strSQL.Append(vbCrLf & "    AND FLOT_NO = :" & UBound(strBindField) - 1 & " --ۯć�")
        End If
        If IsNull(XNUM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXNUM
            strSQL.Append(vbCrLf & "    AND XNUM = :" & UBound(strBindField) - 1 & " --����")
        End If
        If IsNull(XTUMI_HOUKOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_HOUKOU
            strSQL.Append(vbCrLf & "    AND XTUMI_HOUKOU = :" & UBound(strBindField) - 1 & " --�ύ�����")
        End If
        If IsNull(XTUMI_HOUHOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_HOUHOU
            strSQL.Append(vbCrLf & "    AND XTUMI_HOUHOU = :" & UBound(strBindField) - 1 & " --�ύ����@")
        End If
        If IsNull(FIN_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFIN_KUBUN
            strSQL.Append(vbCrLf & "    AND FIN_KUBUN = :" & UBound(strBindField) - 1 & " --���ɋ敪")
        End If
        If IsNull(FARRIVE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFARRIVE_DT
            strSQL.Append(vbCrLf & "    AND FARRIVE_DT = :" & UBound(strBindField) - 1 & " --�݌ɔ�������")
        End If
        If IsNull(XPROD_LINE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPROD_LINE
            strSQL.Append(vbCrLf & "    AND XPROD_LINE = :" & UBound(strBindField) - 1 & " --���Yײ݇�")
        End If
        If IsNull(XFM_ST) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXFM_ST
            strSQL.Append(vbCrLf & "    AND XFM_ST = :" & UBound(strBindField) - 1 & " --�������ð���No.")
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
        If IsNull(XBERTH_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_NO
            strSQL.Append(vbCrLf & "    AND XBERTH_NO = :" & UBound(strBindField) - 1 & " --�ް�No.")
        End If
        If IsNull(XSEND_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSEND_NAME
            strSQL.Append(vbCrLf & "    AND XSEND_NAME = :" & UBound(strBindField) - 1 & " --�͂��於��")
        End If
        If IsNull(XGYOUSYA_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_CD
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_CD = :" & UBound(strBindField) - 1 & " --�����ƎҺ���")
        End If
        If IsNull(XHINMEI_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHINMEI_CD
            strSQL.Append(vbCrLf & "    AND XHINMEI_CD = :" & UBound(strBindField) - 1 & " --�i�ں���(�����i�ں���)")
        End If
        If IsNull(XRAC_IN_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXRAC_IN_DT
            strSQL.Append(vbCrLf & "    AND XRAC_IN_DT = :" & UBound(strBindField) - 1 & " --���ɓ���")
        End If
        If IsNull(XSYARYOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYARYOU_NO
            strSQL.Append(vbCrLf & "    AND XSYARYOU_NO = :" & UBound(strBindField) - 1 & " --���q�ԍ�")
        End If
        If IsNull(XKENPIN_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKENPIN_KUBUN
            strSQL.Append(vbCrLf & "    AND XKENPIN_KUBUN = :" & UBound(strBindField) - 1 & " --���i�敪")
        End If
        If IsNull(XSAIMOKU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSAIMOKU
            strSQL.Append(vbCrLf & "    AND XSAIMOKU = :" & UBound(strBindField) - 1 & " --����敪�ז�")
        End If
        If IsNull(XIDOU_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIDOU_KBN
            strSQL.Append(vbCrLf & "    AND XIDOU_KBN = :" & UBound(strBindField) - 1 & " --�ړ��敪")
        End If
        If IsNull(XSYASYU_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYASYU_KBN
            strSQL.Append(vbCrLf & "    AND XSYASYU_KBN = :" & UBound(strBindField) - 1 & " --�Ԏ�敪")
        End If
        If IsNull(XARTICLE_TYPE_CODE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXARTICLE_TYPE_CODE
            strSQL.Append(vbCrLf & "    AND XARTICLE_TYPE_CODE = :" & UBound(strBindField) - 1 & " --�i�ڎ��(���i�敪)")
        End If
        If IsNull(XUNKOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXUNKOU_NO
            strSQL.Append(vbCrLf & "    AND XUNKOU_NO = :" & UBound(strBindField) - 1 & " --�q�ɕʉ^�sNo.")
        End If
        If IsNull(XHENSEI_NO_OYA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO_OYA = :" & UBound(strBindField) - 1 & " --�e�Ґ�No.")
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
        strDataSetName = "XRST_OUT_DTL"
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
    Public Sub UPDATE_XRST_OUT_DTL()
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
        ElseIf IsNull(mXSYUKKA_D) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�o�ד�]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mXHENSEI_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�Ґ�No.]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mXDENPYOU_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�`�[No.]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mXSYUKKA_RESULT_DT) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�o�׎��ѓ���]"
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
        strSQL.Append(vbCrLf & "    XRST_OUT_DTL")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
        If IsNull(mXSYUKKA_D) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_D = NULL --�o�ד�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_D = NULL --�o�ד�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_D = :" & Ubound(strBindField) - 1 & " --�o�ד�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_D = :" & Ubound(strBindField) - 1 & " --�o�ד�")
        End If
        intCount = intCount + 1
        If IsNull(mXHENSEI_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XHENSEI_NO = NULL --�Ґ�No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XHENSEI_NO = NULL --�Ґ�No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XHENSEI_NO = :" & Ubound(strBindField) - 1 & " --�Ґ�No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XHENSEI_NO = :" & Ubound(strBindField) - 1 & " --�Ґ�No.")
        End If
        intCount = intCount + 1
        If IsNull(mXDENPYOU_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDENPYOU_NO = NULL --�`�[No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDENPYOU_NO = NULL --�`�[No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDENPYOU_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDENPYOU_NO = :" & Ubound(strBindField) - 1 & " --�`�[No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDENPYOU_NO = :" & Ubound(strBindField) - 1 & " --�`�[No.")
        End If
        intCount = intCount + 1
        If IsNull(mXSYUKKA_RESULT_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_RESULT_DT = NULL --�o�׎��ѓ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_RESULT_DT = NULL --�o�׎��ѓ���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_RESULT_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_RESULT_DT = :" & Ubound(strBindField) - 1 & " --�o�׎��ѓ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_RESULT_DT = :" & Ubound(strBindField) - 1 & " --�o�׎��ѓ���")
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
        If IsNull(mXNUM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XNUM = NULL --����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XNUM = NULL --����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXNUM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XNUM = :" & Ubound(strBindField) - 1 & " --����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XNUM = :" & Ubound(strBindField) - 1 & " --����")
        End If
        intCount = intCount + 1
        If IsNull(mXTUMI_HOUKOU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTUMI_HOUKOU = NULL --�ύ�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTUMI_HOUKOU = NULL --�ύ�����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_HOUKOU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTUMI_HOUKOU = :" & Ubound(strBindField) - 1 & " --�ύ�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTUMI_HOUKOU = :" & Ubound(strBindField) - 1 & " --�ύ�����")
        End If
        intCount = intCount + 1
        If IsNull(mXTUMI_HOUHOU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTUMI_HOUHOU = NULL --�ύ����@")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTUMI_HOUHOU = NULL --�ύ����@")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_HOUHOU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTUMI_HOUHOU = :" & Ubound(strBindField) - 1 & " --�ύ����@")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTUMI_HOUHOU = :" & Ubound(strBindField) - 1 & " --�ύ����@")
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
        If IsNull(mXFM_ST) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XFM_ST = NULL --�������ð���No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XFM_ST = NULL --�������ð���No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXFM_ST
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XFM_ST = :" & Ubound(strBindField) - 1 & " --�������ð���No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XFM_ST = :" & Ubound(strBindField) - 1 & " --�������ð���No.")
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
        If IsNull(mXBERTH_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XBERTH_NO = NULL --�ް�No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XBERTH_NO = NULL --�ް�No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XBERTH_NO = :" & Ubound(strBindField) - 1 & " --�ް�No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XBERTH_NO = :" & Ubound(strBindField) - 1 & " --�ް�No.")
        End If
        intCount = intCount + 1
        If IsNull(mXSEND_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSEND_NAME = NULL --�͂��於��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSEND_NAME = NULL --�͂��於��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSEND_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSEND_NAME = :" & Ubound(strBindField) - 1 & " --�͂��於��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSEND_NAME = :" & Ubound(strBindField) - 1 & " --�͂��於��")
        End If
        intCount = intCount + 1
        If IsNull(mXGYOUSYA_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XGYOUSYA_CD = NULL --�����ƎҺ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XGYOUSYA_CD = NULL --�����ƎҺ���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XGYOUSYA_CD = :" & Ubound(strBindField) - 1 & " --�����ƎҺ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XGYOUSYA_CD = :" & Ubound(strBindField) - 1 & " --�����ƎҺ���")
        End If
        intCount = intCount + 1
        If IsNull(mXHINMEI_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XHINMEI_CD = NULL --�i�ں���(�����i�ں���)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XHINMEI_CD = NULL --�i�ں���(�����i�ں���)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHINMEI_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XHINMEI_CD = :" & Ubound(strBindField) - 1 & " --�i�ں���(�����i�ں���)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XHINMEI_CD = :" & Ubound(strBindField) - 1 & " --�i�ں���(�����i�ں���)")
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
        If IsNull(mXSYARYOU_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYARYOU_NO = NULL --���q�ԍ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYARYOU_NO = NULL --���q�ԍ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYARYOU_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYARYOU_NO = :" & Ubound(strBindField) - 1 & " --���q�ԍ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYARYOU_NO = :" & Ubound(strBindField) - 1 & " --���q�ԍ�")
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
        If IsNull(mXSAIMOKU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSAIMOKU = NULL --����敪�ז�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSAIMOKU = NULL --����敪�ז�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSAIMOKU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSAIMOKU = :" & Ubound(strBindField) - 1 & " --����敪�ז�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSAIMOKU = :" & Ubound(strBindField) - 1 & " --����敪�ז�")
        End If
        intCount = intCount + 1
        If IsNull(mXIDOU_KBN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XIDOU_KBN = NULL --�ړ��敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XIDOU_KBN = NULL --�ړ��敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIDOU_KBN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XIDOU_KBN = :" & Ubound(strBindField) - 1 & " --�ړ��敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XIDOU_KBN = :" & Ubound(strBindField) - 1 & " --�ړ��敪")
        End If
        intCount = intCount + 1
        If IsNull(mXSYASYU_KBN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYASYU_KBN = NULL --�Ԏ�敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYASYU_KBN = NULL --�Ԏ�敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYASYU_KBN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYASYU_KBN = :" & Ubound(strBindField) - 1 & " --�Ԏ�敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYASYU_KBN = :" & Ubound(strBindField) - 1 & " --�Ԏ�敪")
        End If
        intCount = intCount + 1
        If IsNull(mXARTICLE_TYPE_CODE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XARTICLE_TYPE_CODE = NULL --�i�ڎ��(���i�敪)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XARTICLE_TYPE_CODE = NULL --�i�ڎ��(���i�敪)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXARTICLE_TYPE_CODE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XARTICLE_TYPE_CODE = :" & Ubound(strBindField) - 1 & " --�i�ڎ��(���i�敪)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XARTICLE_TYPE_CODE = :" & Ubound(strBindField) - 1 & " --�i�ڎ��(���i�敪)")
        End If
        intCount = intCount + 1
        If IsNull(mXUNKOU_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XUNKOU_NO = NULL --�q�ɕʉ^�sNo.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XUNKOU_NO = NULL --�q�ɕʉ^�sNo.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXUNKOU_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XUNKOU_NO = :" & Ubound(strBindField) - 1 & " --�q�ɕʉ^�sNo.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XUNKOU_NO = :" & Ubound(strBindField) - 1 & " --�q�ɕʉ^�sNo.")
        End If
        intCount = intCount + 1
        If IsNull(mXHENSEI_NO_OYA) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XHENSEI_NO_OYA = NULL --�e�Ґ�No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XHENSEI_NO_OYA = NULL --�e�Ґ�No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XHENSEI_NO_OYA = :" & Ubound(strBindField) - 1 & " --�e�Ґ�No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XHENSEI_NO_OYA = :" & Ubound(strBindField) - 1 & " --�e�Ґ�No.")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(XSYUKKA_D) = True Then
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D IS NULL --�o�ד�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D = :" & UBound(strBindField) - 1 & " --�o�ד�")
        End If
        If IsNull(XHENSEI_NO) = True Then
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO IS NULL --�Ґ�No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO = :" & UBound(strBindField) - 1 & " --�Ґ�No.")
        End If
        If IsNull(XDENPYOU_NO) = True Then
            strSQL.Append(vbCrLf & "    AND XDENPYOU_NO IS NULL --�`�[No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDENPYOU_NO
            strSQL.Append(vbCrLf & "    AND XDENPYOU_NO = :" & UBound(strBindField) - 1 & " --�`�[No.")
        End If
        If IsNull(XSYUKKA_RESULT_DT) = True Then
            strSQL.Append(vbCrLf & "    AND XSYUKKA_RESULT_DT IS NULL --�o�׎��ѓ���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_RESULT_DT
            strSQL.Append(vbCrLf & "    AND XSYUKKA_RESULT_DT = :" & UBound(strBindField) - 1 & " --�o�׎��ѓ���")
        End If
        If IsNull(FPALLET_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FPALLET_ID IS NULL --��گ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --��گ�ID")
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
    Public Sub ADD_XRST_OUT_DTL()
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
        ElseIf IsNull(mXSYUKKA_D) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�o�ד�]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mXHENSEI_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�Ґ�No.]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mXDENPYOU_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�`�[No.]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mXSYUKKA_RESULT_DT) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�o�׎��ѓ���]"
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
        strSQL.Append(vbCrLf & "    XRST_OUT_DTL")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
        If IsNull(mXSYUKKA_D) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�o�ד�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�o�ד�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�o�ד�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�o�ד�")
        End If
        intCount = intCount + 1
        If IsNull(mXHENSEI_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�Ґ�No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�Ґ�No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�Ґ�No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�Ґ�No.")
        End If
        intCount = intCount + 1
        If IsNull(mXDENPYOU_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�`�[No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�`�[No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDENPYOU_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�`�[No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�`�[No.")
        End If
        intCount = intCount + 1
        If IsNull(mXSYUKKA_RESULT_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�o�׎��ѓ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�o�׎��ѓ���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_RESULT_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�o�׎��ѓ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�o�׎��ѓ���")
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
        If IsNull(mXNUM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXNUM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����")
        End If
        intCount = intCount + 1
        If IsNull(mXTUMI_HOUKOU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ύ�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ύ�����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_HOUKOU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ύ�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ύ�����")
        End If
        intCount = intCount + 1
        If IsNull(mXTUMI_HOUHOU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ύ����@")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ύ����@")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_HOUHOU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ύ����@")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ύ����@")
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
        If IsNull(mXFM_ST) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�������ð���No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�������ð���No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXFM_ST
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�������ð���No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�������ð���No.")
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
        If IsNull(mXBERTH_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ް�No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ް�No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ް�No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ް�No.")
        End If
        intCount = intCount + 1
        If IsNull(mXSEND_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�͂��於��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�͂��於��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSEND_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�͂��於��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�͂��於��")
        End If
        intCount = intCount + 1
        If IsNull(mXGYOUSYA_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�����ƎҺ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�����ƎҺ���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�����ƎҺ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�����ƎҺ���")
        End If
        intCount = intCount + 1
        If IsNull(mXHINMEI_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�i�ں���(�����i�ں���)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�i�ں���(�����i�ں���)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHINMEI_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�i�ں���(�����i�ں���)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�i�ں���(�����i�ں���)")
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
        If IsNull(mXSYARYOU_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���q�ԍ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���q�ԍ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYARYOU_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���q�ԍ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���q�ԍ�")
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
        If IsNull(mXSAIMOKU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����敪�ז�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����敪�ז�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSAIMOKU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����敪�ז�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����敪�ז�")
        End If
        intCount = intCount + 1
        If IsNull(mXIDOU_KBN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ړ��敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ړ��敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIDOU_KBN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ړ��敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ړ��敪")
        End If
        intCount = intCount + 1
        If IsNull(mXSYASYU_KBN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�Ԏ�敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�Ԏ�敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYASYU_KBN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�Ԏ�敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�Ԏ�敪")
        End If
        intCount = intCount + 1
        If IsNull(mXARTICLE_TYPE_CODE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�i�ڎ��(���i�敪)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�i�ڎ��(���i�敪)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXARTICLE_TYPE_CODE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�i�ڎ��(���i�敪)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�i�ڎ��(���i�敪)")
        End If
        intCount = intCount + 1
        If IsNull(mXUNKOU_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�q�ɕʉ^�sNo.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�q�ɕʉ^�sNo.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXUNKOU_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�q�ɕʉ^�sNo.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�q�ɕʉ^�sNo.")
        End If
        intCount = intCount + 1
        If IsNull(mXHENSEI_NO_OYA) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�e�Ґ�No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�e�Ґ�No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�e�Ґ�No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�e�Ґ�No.")
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
    Public Sub DELETE_XRST_OUT_DTL()
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
        ElseIf IsNull(mXSYUKKA_D) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�o�ד�]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mXHENSEI_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�Ґ�No.]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mXDENPYOU_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�`�[No.]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mXSYUKKA_RESULT_DT) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�o�׎��ѓ���]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFPALLET_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[��گ�ID]"
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
        strSQL.Append(vbCrLf & "    XRST_OUT_DTL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(XSYUKKA_D) = True Then
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D IS NULL --�o�ד�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D = :" & UBound(strBindField) - 1 & " --�o�ד�")
        End If
        If IsNull(XHENSEI_NO) = True Then
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO IS NULL --�Ґ�No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO = :" & UBound(strBindField) - 1 & " --�Ґ�No.")
        End If
        If IsNull(XDENPYOU_NO) = True Then
            strSQL.Append(vbCrLf & "    AND XDENPYOU_NO IS NULL --�`�[No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDENPYOU_NO
            strSQL.Append(vbCrLf & "    AND XDENPYOU_NO = :" & UBound(strBindField) - 1 & " --�`�[No.")
        End If
        If IsNull(XSYUKKA_RESULT_DT) = True Then
            strSQL.Append(vbCrLf & "    AND XSYUKKA_RESULT_DT IS NULL --�o�׎��ѓ���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_RESULT_DT
            strSQL.Append(vbCrLf & "    AND XSYUKKA_RESULT_DT = :" & UBound(strBindField) - 1 & " --�o�׎��ѓ���")
        End If
        If IsNull(FPALLET_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FPALLET_ID IS NULL --��گ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --��گ�ID")
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
    Public Sub DELETE_XRST_OUT_DTL_ANY()
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
        strSQL.Append(vbCrLf & "    XRST_OUT_DTL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(XSYUKKA_D) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D = :" & UBound(strBindField) - 1 & " --�o�ד�")
        End If
        If IsNotNull(XHENSEI_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO = :" & UBound(strBindField) - 1 & " --�Ґ�No.")
        End If
        If IsNotNull(XDENPYOU_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDENPYOU_NO
            strSQL.Append(vbCrLf & "    AND XDENPYOU_NO = :" & UBound(strBindField) - 1 & " --�`�[No.")
        End If
        If IsNotNull(XSYUKKA_RESULT_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_RESULT_DT
            strSQL.Append(vbCrLf & "    AND XSYUKKA_RESULT_DT = :" & UBound(strBindField) - 1 & " --�o�׎��ѓ���")
        End If
        If IsNotNull(FPALLET_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --��گ�ID")
        End If
        If IsNotNull(FHINMEI_CD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --�i�ں���")
        End If
        If IsNotNull(FLOT_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO
            strSQL.Append(vbCrLf & "    AND FLOT_NO = :" & UBound(strBindField) - 1 & " --ۯć�")
        End If
        If IsNotNull(XNUM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXNUM
            strSQL.Append(vbCrLf & "    AND XNUM = :" & UBound(strBindField) - 1 & " --����")
        End If
        If IsNotNull(XTUMI_HOUKOU) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_HOUKOU
            strSQL.Append(vbCrLf & "    AND XTUMI_HOUKOU = :" & UBound(strBindField) - 1 & " --�ύ�����")
        End If
        If IsNotNull(XTUMI_HOUHOU) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_HOUHOU
            strSQL.Append(vbCrLf & "    AND XTUMI_HOUHOU = :" & UBound(strBindField) - 1 & " --�ύ����@")
        End If
        If IsNotNull(FIN_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFIN_KUBUN
            strSQL.Append(vbCrLf & "    AND FIN_KUBUN = :" & UBound(strBindField) - 1 & " --���ɋ敪")
        End If
        If IsNotNull(FARRIVE_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFARRIVE_DT
            strSQL.Append(vbCrLf & "    AND FARRIVE_DT = :" & UBound(strBindField) - 1 & " --�݌ɔ�������")
        End If
        If IsNotNull(XPROD_LINE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPROD_LINE
            strSQL.Append(vbCrLf & "    AND XPROD_LINE = :" & UBound(strBindField) - 1 & " --���Yײ݇�")
        End If
        If IsNotNull(XFM_ST) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXFM_ST
            strSQL.Append(vbCrLf & "    AND XFM_ST = :" & UBound(strBindField) - 1 & " --�������ð���No.")
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
        If IsNotNull(XBERTH_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_NO
            strSQL.Append(vbCrLf & "    AND XBERTH_NO = :" & UBound(strBindField) - 1 & " --�ް�No.")
        End If
        If IsNotNull(XSEND_NAME) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSEND_NAME
            strSQL.Append(vbCrLf & "    AND XSEND_NAME = :" & UBound(strBindField) - 1 & " --�͂��於��")
        End If
        If IsNotNull(XGYOUSYA_CD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_CD
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_CD = :" & UBound(strBindField) - 1 & " --�����ƎҺ���")
        End If
        If IsNotNull(XHINMEI_CD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHINMEI_CD
            strSQL.Append(vbCrLf & "    AND XHINMEI_CD = :" & UBound(strBindField) - 1 & " --�i�ں���(�����i�ں���)")
        End If
        If IsNotNull(XRAC_IN_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXRAC_IN_DT
            strSQL.Append(vbCrLf & "    AND XRAC_IN_DT = :" & UBound(strBindField) - 1 & " --���ɓ���")
        End If
        If IsNotNull(XSYARYOU_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYARYOU_NO
            strSQL.Append(vbCrLf & "    AND XSYARYOU_NO = :" & UBound(strBindField) - 1 & " --���q�ԍ�")
        End If
        If IsNotNull(XKENPIN_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKENPIN_KUBUN
            strSQL.Append(vbCrLf & "    AND XKENPIN_KUBUN = :" & UBound(strBindField) - 1 & " --���i�敪")
        End If
        If IsNotNull(XSAIMOKU) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSAIMOKU
            strSQL.Append(vbCrLf & "    AND XSAIMOKU = :" & UBound(strBindField) - 1 & " --����敪�ז�")
        End If
        If IsNotNull(XIDOU_KBN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIDOU_KBN
            strSQL.Append(vbCrLf & "    AND XIDOU_KBN = :" & UBound(strBindField) - 1 & " --�ړ��敪")
        End If
        If IsNotNull(XSYASYU_KBN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYASYU_KBN
            strSQL.Append(vbCrLf & "    AND XSYASYU_KBN = :" & UBound(strBindField) - 1 & " --�Ԏ�敪")
        End If
        If IsNotNull(XARTICLE_TYPE_CODE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXARTICLE_TYPE_CODE
            strSQL.Append(vbCrLf & "    AND XARTICLE_TYPE_CODE = :" & UBound(strBindField) - 1 & " --�i�ڎ��(���i�敪)")
        End If
        If IsNotNull(XUNKOU_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXUNKOU_NO
            strSQL.Append(vbCrLf & "    AND XUNKOU_NO = :" & UBound(strBindField) - 1 & " --�q�ɕʉ^�sNo.")
        End If
        If IsNotNull(XHENSEI_NO_OYA) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO_OYA = :" & UBound(strBindField) - 1 & " --�e�Ґ�No.")
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
        If IsNothing(objType.GetProperty("XSYUKKA_D")) = False Then mXSYUKKA_D = objObject.XSYUKKA_D '�o�ד�
        If IsNothing(objType.GetProperty("XHENSEI_NO")) = False Then mXHENSEI_NO = objObject.XHENSEI_NO '�Ґ�No.
        If IsNothing(objType.GetProperty("XDENPYOU_NO")) = False Then mXDENPYOU_NO = objObject.XDENPYOU_NO '�`�[No.
        If IsNothing(objType.GetProperty("XSYUKKA_RESULT_DT")) = False Then mXSYUKKA_RESULT_DT = objObject.XSYUKKA_RESULT_DT '�o�׎��ѓ���
        If IsNothing(objType.GetProperty("FPALLET_ID")) = False Then mFPALLET_ID = objObject.FPALLET_ID '��گ�ID
        If IsNothing(objType.GetProperty("FHINMEI_CD")) = False Then mFHINMEI_CD = objObject.FHINMEI_CD '�i�ں���
        If IsNothing(objType.GetProperty("FLOT_NO")) = False Then mFLOT_NO = objObject.FLOT_NO 'ۯć�
        If IsNothing(objType.GetProperty("XNUM")) = False Then mXNUM = objObject.XNUM '����
        If IsNothing(objType.GetProperty("XTUMI_HOUKOU")) = False Then mXTUMI_HOUKOU = objObject.XTUMI_HOUKOU '�ύ�����
        If IsNothing(objType.GetProperty("XTUMI_HOUHOU")) = False Then mXTUMI_HOUHOU = objObject.XTUMI_HOUHOU '�ύ����@
        If IsNothing(objType.GetProperty("FIN_KUBUN")) = False Then mFIN_KUBUN = objObject.FIN_KUBUN '���ɋ敪
        If IsNothing(objType.GetProperty("FARRIVE_DT")) = False Then mFARRIVE_DT = objObject.FARRIVE_DT '�݌ɔ�������
        If IsNothing(objType.GetProperty("XPROD_LINE")) = False Then mXPROD_LINE = objObject.XPROD_LINE '���Yײ݇�
        If IsNothing(objType.GetProperty("XFM_ST")) = False Then mXFM_ST = objObject.XFM_ST '�������ð���No.
        If IsNothing(objType.GetProperty("FBUF_FM")) = False Then mFBUF_FM = objObject.FBUF_FM '�������ׯ�ݸ��ޯ̧��
        If IsNothing(objType.GetProperty("FARRAY_FM")) = False Then mFARRAY_FM = objObject.FARRAY_FM '�������ׯ�ݸ��ޯ̧�z��
        If IsNothing(objType.GetProperty("FBUF_TO")) = False Then mFBUF_TO = objObject.FBUF_TO '�������ׯ�ݸ��ޯ̧��
        If IsNothing(objType.GetProperty("FARRAY_TO")) = False Then mFARRAY_TO = objObject.FARRAY_TO '�������ׯ�ݸ��ޯ̧�z��
        If IsNothing(objType.GetProperty("XBERTH_NO")) = False Then mXBERTH_NO = objObject.XBERTH_NO '�ް�No.
        If IsNothing(objType.GetProperty("XSEND_NAME")) = False Then mXSEND_NAME = objObject.XSEND_NAME '�͂��於��
        If IsNothing(objType.GetProperty("XGYOUSYA_CD")) = False Then mXGYOUSYA_CD = objObject.XGYOUSYA_CD '�����ƎҺ���
        If IsNothing(objType.GetProperty("XHINMEI_CD")) = False Then mXHINMEI_CD = objObject.XHINMEI_CD '�i�ں���(�����i�ں���)
        If IsNothing(objType.GetProperty("XRAC_IN_DT")) = False Then mXRAC_IN_DT = objObject.XRAC_IN_DT '���ɓ���
        If IsNothing(objType.GetProperty("XSYARYOU_NO")) = False Then mXSYARYOU_NO = objObject.XSYARYOU_NO '���q�ԍ�
        If IsNothing(objType.GetProperty("XKENPIN_KUBUN")) = False Then mXKENPIN_KUBUN = objObject.XKENPIN_KUBUN '���i�敪
        If IsNothing(objType.GetProperty("XSAIMOKU")) = False Then mXSAIMOKU = objObject.XSAIMOKU '����敪�ז�
        If IsNothing(objType.GetProperty("XIDOU_KBN")) = False Then mXIDOU_KBN = objObject.XIDOU_KBN '�ړ��敪
        If IsNothing(objType.GetProperty("XSYASYU_KBN")) = False Then mXSYASYU_KBN = objObject.XSYASYU_KBN '�Ԏ�敪
        If IsNothing(objType.GetProperty("XARTICLE_TYPE_CODE")) = False Then mXARTICLE_TYPE_CODE = objObject.XARTICLE_TYPE_CODE '�i�ڎ��(���i�敪)
        If IsNothing(objType.GetProperty("XUNKOU_NO")) = False Then mXUNKOU_NO = objObject.XUNKOU_NO '�q�ɕʉ^�sNo.
        If IsNothing(objType.GetProperty("XHENSEI_NO_OYA")) = False Then mXHENSEI_NO_OYA = objObject.XHENSEI_NO_OYA '�e�Ґ�No.

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
        mXSYUKKA_D = Nothing
        mXHENSEI_NO = Nothing
        mXDENPYOU_NO = Nothing
        mXSYUKKA_RESULT_DT = Nothing
        mFPALLET_ID = Nothing
        mFHINMEI_CD = Nothing
        mFLOT_NO = Nothing
        mXNUM = Nothing
        mXTUMI_HOUKOU = Nothing
        mXTUMI_HOUHOU = Nothing
        mFIN_KUBUN = Nothing
        mFARRIVE_DT = Nothing
        mXPROD_LINE = Nothing
        mXFM_ST = Nothing
        mFBUF_FM = Nothing
        mFARRAY_FM = Nothing
        mFBUF_TO = Nothing
        mFARRAY_TO = Nothing
        mXBERTH_NO = Nothing
        mXSEND_NAME = Nothing
        mXGYOUSYA_CD = Nothing
        mXHINMEI_CD = Nothing
        mXRAC_IN_DT = Nothing
        mXSYARYOU_NO = Nothing
        mXKENPIN_KUBUN = Nothing
        mXSAIMOKU = Nothing
        mXIDOU_KBN = Nothing
        mXSYASYU_KBN = Nothing
        mXARTICLE_TYPE_CODE = Nothing
        mXUNKOU_NO = Nothing
        mXHENSEI_NO_OYA = Nothing


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
        mXSYUKKA_D = TO_DATE_NULLABLE(objRow("XSYUKKA_D"))
        mXHENSEI_NO = TO_STRING_NULLABLE(objRow("XHENSEI_NO"))
        mXDENPYOU_NO = TO_STRING_NULLABLE(objRow("XDENPYOU_NO"))
        mXSYUKKA_RESULT_DT = TO_DATE_NULLABLE(objRow("XSYUKKA_RESULT_DT"))
        mFPALLET_ID = TO_STRING_NULLABLE(objRow("FPALLET_ID"))
        mFHINMEI_CD = TO_STRING_NULLABLE(objRow("FHINMEI_CD"))
        mFLOT_NO = TO_STRING_NULLABLE(objRow("FLOT_NO"))
        mXNUM = TO_DECIMAL_NULLABLE(objRow("XNUM"))
        mXTUMI_HOUKOU = TO_INTEGER_NULLABLE(objRow("XTUMI_HOUKOU"))
        mXTUMI_HOUHOU = TO_INTEGER_NULLABLE(objRow("XTUMI_HOUHOU"))
        mFIN_KUBUN = TO_INTEGER_NULLABLE(objRow("FIN_KUBUN"))
        mFARRIVE_DT = TO_DATE_NULLABLE(objRow("FARRIVE_DT"))
        mXPROD_LINE = TO_STRING_NULLABLE(objRow("XPROD_LINE"))
        mXFM_ST = TO_INTEGER_NULLABLE(objRow("XFM_ST"))
        mFBUF_FM = TO_INTEGER_NULLABLE(objRow("FBUF_FM"))
        mFARRAY_FM = TO_INTEGER_NULLABLE(objRow("FARRAY_FM"))
        mFBUF_TO = TO_INTEGER_NULLABLE(objRow("FBUF_TO"))
        mFARRAY_TO = TO_INTEGER_NULLABLE(objRow("FARRAY_TO"))
        mXBERTH_NO = TO_STRING_NULLABLE(objRow("XBERTH_NO"))
        mXSEND_NAME = TO_STRING_NULLABLE(objRow("XSEND_NAME"))
        mXGYOUSYA_CD = TO_STRING_NULLABLE(objRow("XGYOUSYA_CD"))
        mXHINMEI_CD = TO_STRING_NULLABLE(objRow("XHINMEI_CD"))
        mXRAC_IN_DT = TO_DATE_NULLABLE(objRow("XRAC_IN_DT"))
        mXSYARYOU_NO = TO_INTEGER_NULLABLE(objRow("XSYARYOU_NO"))
        mXKENPIN_KUBUN = TO_STRING_NULLABLE(objRow("XKENPIN_KUBUN"))
        mXSAIMOKU = TO_STRING_NULLABLE(objRow("XSAIMOKU"))
        mXIDOU_KBN = TO_STRING_NULLABLE(objRow("XIDOU_KBN"))
        mXSYASYU_KBN = TO_STRING_NULLABLE(objRow("XSYASYU_KBN"))
        mXARTICLE_TYPE_CODE = TO_INTEGER_NULLABLE(objRow("XARTICLE_TYPE_CODE"))
        mXUNKOU_NO = TO_STRING_NULLABLE(objRow("XUNKOU_NO"))
        mXHENSEI_NO_OYA = TO_STRING_NULLABLE(objRow("XHENSEI_NO_OYA"))


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
        strMsg &= "[ð��ٖ�:�o�׎��яڍ�]"
        If IsNotNull(XSYUKKA_D) Then
            strMsg &= "[�o�ד�:" & XSYUKKA_D & "]"
        End If
        If IsNotNull(XHENSEI_NO) Then
            strMsg &= "[�Ґ�No.:" & XHENSEI_NO & "]"
        End If
        If IsNotNull(XDENPYOU_NO) Then
            strMsg &= "[�`�[No.:" & XDENPYOU_NO & "]"
        End If
        If IsNotNull(XSYUKKA_RESULT_DT) Then
            strMsg &= "[�o�׎��ѓ���:" & XSYUKKA_RESULT_DT & "]"
        End If
        If IsNotNull(FPALLET_ID) Then
            strMsg &= "[��گ�ID:" & FPALLET_ID & "]"
        End If
        If IsNotNull(FHINMEI_CD) Then
            strMsg &= "[�i�ں���:" & FHINMEI_CD & "]"
        End If
        If IsNotNull(FLOT_NO) Then
            strMsg &= "[ۯć�:" & FLOT_NO & "]"
        End If
        If IsNotNull(XNUM) Then
            strMsg &= "[����:" & XNUM & "]"
        End If
        If IsNotNull(XTUMI_HOUKOU) Then
            strMsg &= "[�ύ�����:" & XTUMI_HOUKOU & "]"
        End If
        If IsNotNull(XTUMI_HOUHOU) Then
            strMsg &= "[�ύ����@:" & XTUMI_HOUHOU & "]"
        End If
        If IsNotNull(FIN_KUBUN) Then
            strMsg &= "[���ɋ敪:" & FIN_KUBUN & "]"
        End If
        If IsNotNull(FARRIVE_DT) Then
            strMsg &= "[�݌ɔ�������:" & FARRIVE_DT & "]"
        End If
        If IsNotNull(XPROD_LINE) Then
            strMsg &= "[���Yײ݇�:" & XPROD_LINE & "]"
        End If
        If IsNotNull(XFM_ST) Then
            strMsg &= "[�������ð���No.:" & XFM_ST & "]"
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
        If IsNotNull(XBERTH_NO) Then
            strMsg &= "[�ް�No.:" & XBERTH_NO & "]"
        End If
        If IsNotNull(XSEND_NAME) Then
            strMsg &= "[�͂��於��:" & XSEND_NAME & "]"
        End If
        If IsNotNull(XGYOUSYA_CD) Then
            strMsg &= "[�����ƎҺ���:" & XGYOUSYA_CD & "]"
        End If
        If IsNotNull(XHINMEI_CD) Then
            strMsg &= "[�i�ں���(�����i�ں���):" & XHINMEI_CD & "]"
        End If
        If IsNotNull(XRAC_IN_DT) Then
            strMsg &= "[���ɓ���:" & XRAC_IN_DT & "]"
        End If
        If IsNotNull(XSYARYOU_NO) Then
            strMsg &= "[���q�ԍ�:" & XSYARYOU_NO & "]"
        End If
        If IsNotNull(XKENPIN_KUBUN) Then
            strMsg &= "[���i�敪:" & XKENPIN_KUBUN & "]"
        End If
        If IsNotNull(XSAIMOKU) Then
            strMsg &= "[����敪�ז�:" & XSAIMOKU & "]"
        End If
        If IsNotNull(XIDOU_KBN) Then
            strMsg &= "[�ړ��敪:" & XIDOU_KBN & "]"
        End If
        If IsNotNull(XSYASYU_KBN) Then
            strMsg &= "[�Ԏ�敪:" & XSYASYU_KBN & "]"
        End If
        If IsNotNull(XARTICLE_TYPE_CODE) Then
            strMsg &= "[�i�ڎ��(���i�敪):" & XARTICLE_TYPE_CODE & "]"
        End If
        If IsNotNull(XUNKOU_NO) Then
            strMsg &= "[�q�ɕʉ^�sNo.:" & XUNKOU_NO & "]"
        End If
        If IsNotNull(XHENSEI_NO_OYA) Then
            strMsg &= "[�e�Ґ�No.:" & XHENSEI_NO_OYA & "]"
        End If


    End Sub
#End Region
    '����������������
    '**********************************************************************************************

    '**********************************************************************************************
    '���������ы���

    '���������ы���
    '**********************************************************************************************


    '**********************************************************************************************
    '���������ьŗL

    '���������ьŗL
    '**********************************************************************************************

End Class
