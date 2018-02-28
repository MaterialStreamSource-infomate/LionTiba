'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' �y���́zMaterialStreamð��ٸ׽
' �y�@�\�z�ׯ�ݸ��ޯ̧Ͻ�ð��ٸ׽
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
''' �ׯ�ݸ��ޯ̧Ͻ�ð��ٸ׽
''' </summary>
Public Class TBL_TMST_TRK
    Inherits clsTemplateTable

    '**********************************************************************************************
    '����������������
#Region "  �׽�ϐ���`                  "
    '�����è
    Private mobjAryMe As TBL_TMST_TRK()                                          '�ׯ�ݸ��ޯ̧Ͻ�
    Private mstrUSER_SQL As String                                               'հ�ްSQL
    Private mORDER_BY As String                                                  'OrderBy��
    Private mWHERE As String                                                     'Where��
    Private mFTRK_BUF_NO As Nullable(Of Integer)                                 '�ׯ�ݸ��ޯ̧��
    Private mFBUF_NAME As String                                                 '�ׯ�ݸ��ޯ̧����
    Private mFBUF_KIND As Nullable(Of Integer)                                   '�ޯ̧���
    Private mFNEW_IN_KUBUN As Nullable(Of Integer)                               '�V�K�����ޯ̧�敪
    Private mFBUF_MAX As Nullable(Of Integer)                                    '�ő��ޯ̧����
    Private mFBUF_LOG_FLAG As Nullable(Of Integer)                               '۸ޗL���׸�
    Private mFRAC_RETU_MAX As Nullable(Of Integer)                               '�ő��
    Private mFRAC_REN_MAX As Nullable(Of Integer)                                '�ő�A��
    Private mFRAC_DAN_MAX As Nullable(Of Integer)                                '�ő�i��
    Private mFRAC_EDA_MAX As Nullable(Of Integer)                                '�ő�}��
    Private mFPLACE_CD As Nullable(Of Integer)                                   '�ۊǏꏊ����
    Private mFAREA_CD As Nullable(Of Integer)                                    '�ر����
    Private mXEQ_ID_MOD As String                                                'Ӱ�ސݔ�ID
    Private mXEQ_ID_STN As String                                                'ST�ډאݔ�ID
    Private mXTRK_BUF_NO_IN_HIRA As Nullable(Of Integer)                         '���ɐݒ莞���u
    Private mXTRK_BUF_NO_OUT_HIRA As Nullable(Of Integer)                        '�o�ɐݒ莞���u
    Private mXADRS_IN As String                                                  '���Ɏw�����ڽ
    Private mXADRS_OUT As String                                                 '�o�Ɏw�����ڽ
    Private mXADRS_HANSOU As String                                              '�����w�����ڽ
    Private mXADRS_PLCTRK05 As String                                            'PLC�ׯ�ݸޱ��ڽ05
    Private mXADRS_PLCTRK04 As String                                            'PLC�ׯ�ݸޱ��ڽ04
    Private mXADRS_PALLET01 As String                                            '��گĐ����ڽ01
    Private mXADRS_PALLET02 As String                                            '��گĐ����ڽ02
    Private mXADRS_YOTEI01 As String                                             '�\�萔���ڽ01
    Private mXADRS_YOTEI02 As String                                             '�\�萔���ڽ02
    Private mXLS_NO As Nullable(Of Integer)                                      'L/S�ԍ�
    Private mXEQ_ID_IN_FR As String                                              '���ɗv���O�ݔ�ID
    Private mXEQ_ID_IN_BK As String                                              '���ɗv����ݔ�ID
    Private mXEQ_ID_HASU_FR As String                                            '�[���O�ݔ�ID
    Private mXEQ_ID_HASU_BK As String                                            '�[����ݔ�ID
    Private mXTRK_BUF_NO_CONV As Nullable(Of Integer)                            '����Ԋ֘A�t��
    Private mXEQ_ID_IRI_YOUKYU As String                                         '���I���ɗv���ݔ�ID
    Private mXEQ_ID_OUT_YOUKYU As String                                         '�o�ɗv���ݔ�ID
    Private mXEQ_ID_OUT_BUF As String                                            '�o�I�ޯ̧��ݔ�ID
    Private mXEQ_ID_OUT_END As String                                            '�o�Ɋ����ݔ�ID
    Private mXEQ_ID_B_HENSEI As String                                           '�Ґ����\��
    Private mXEQ_ID_B_OUTEND As String                                           '�o�Ɋ�������
    Private mXEQ_ID_B_TUMIEND As String                                          '�ύ���������
    Private mXMAINTE_KUBUN As Nullable(Of Integer)                               '����ݽ�敪
    Private mXMAINTE_ORDER As Nullable(Of Integer)                               '����ݽ�敪��
    Private mXMAINTE_NAME As String                                              '����ݽ�\����
    Private mXBUF_NAME_DTL As String                                             '�ׯ�ݸ��ޯ̧����(��������)
#End Region
#Region "  �����è��`                  "
    ''' <summary>
    ''' ���ѕϐ� (���׽�^�z��)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_TMST_TRK()
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
    ''' �ׯ�ݸ��ޯ̧����
    ''' </summary>
    Public Property FBUF_NAME() As String
        Get
            Return mFBUF_NAME
        End Get
        Set(ByVal Value As String)
            mFBUF_NAME = Value
        End Set
    End Property
    ''' <summary>
    ''' �ޯ̧���
    ''' </summary>
    Public Property FBUF_KIND() As Nullable(Of Integer)
        Get
            Return mFBUF_KIND
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFBUF_KIND = Value
        End Set
    End Property
    ''' <summary>
    ''' �V�K�����ޯ̧�敪
    ''' </summary>
    Public Property FNEW_IN_KUBUN() As Nullable(Of Integer)
        Get
            Return mFNEW_IN_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFNEW_IN_KUBUN = Value
        End Set
    End Property
    ''' <summary>
    ''' �ő��ޯ̧����
    ''' </summary>
    Public Property FBUF_MAX() As Nullable(Of Integer)
        Get
            Return mFBUF_MAX
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFBUF_MAX = Value
        End Set
    End Property
    ''' <summary>
    ''' ۸ޗL���׸�
    ''' </summary>
    Public Property FBUF_LOG_FLAG() As Nullable(Of Integer)
        Get
            Return mFBUF_LOG_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFBUF_LOG_FLAG = Value
        End Set
    End Property
    ''' <summary>
    ''' �ő��
    ''' </summary>
    Public Property FRAC_RETU_MAX() As Nullable(Of Integer)
        Get
            Return mFRAC_RETU_MAX
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRAC_RETU_MAX = Value
        End Set
    End Property
    ''' <summary>
    ''' �ő�A��
    ''' </summary>
    Public Property FRAC_REN_MAX() As Nullable(Of Integer)
        Get
            Return mFRAC_REN_MAX
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRAC_REN_MAX = Value
        End Set
    End Property
    ''' <summary>
    ''' �ő�i��
    ''' </summary>
    Public Property FRAC_DAN_MAX() As Nullable(Of Integer)
        Get
            Return mFRAC_DAN_MAX
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRAC_DAN_MAX = Value
        End Set
    End Property
    ''' <summary>
    ''' �ő�}��
    ''' </summary>
    Public Property FRAC_EDA_MAX() As Nullable(Of Integer)
        Get
            Return mFRAC_EDA_MAX
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRAC_EDA_MAX = Value
        End Set
    End Property
    ''' <summary>
    ''' �ۊǏꏊ����
    ''' </summary>
    Public Property FPLACE_CD() As Nullable(Of Integer)
        Get
            Return mFPLACE_CD
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFPLACE_CD = Value
        End Set
    End Property
    ''' <summary>
    ''' �ر����
    ''' </summary>
    Public Property FAREA_CD() As Nullable(Of Integer)
        Get
            Return mFAREA_CD
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFAREA_CD = Value
        End Set
    End Property
    ''' <summary>
    ''' Ӱ�ސݔ�ID
    ''' </summary>
    Public Property XEQ_ID_MOD() As String
        Get
            Return mXEQ_ID_MOD
        End Get
        Set(ByVal Value As String)
            mXEQ_ID_MOD = Value
        End Set
    End Property
    ''' <summary>
    ''' ST�ډאݔ�ID
    ''' </summary>
    Public Property XEQ_ID_STN() As String
        Get
            Return mXEQ_ID_STN
        End Get
        Set(ByVal Value As String)
            mXEQ_ID_STN = Value
        End Set
    End Property
    ''' <summary>
    ''' ���ɐݒ莞���u
    ''' </summary>
    Public Property XTRK_BUF_NO_IN_HIRA() As Nullable(Of Integer)
        Get
            Return mXTRK_BUF_NO_IN_HIRA
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXTRK_BUF_NO_IN_HIRA = Value
        End Set
    End Property
    ''' <summary>
    ''' �o�ɐݒ莞���u
    ''' </summary>
    Public Property XTRK_BUF_NO_OUT_HIRA() As Nullable(Of Integer)
        Get
            Return mXTRK_BUF_NO_OUT_HIRA
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXTRK_BUF_NO_OUT_HIRA = Value
        End Set
    End Property
    ''' <summary>
    ''' ���Ɏw�����ڽ
    ''' </summary>
    Public Property XADRS_IN() As String
        Get
            Return mXADRS_IN
        End Get
        Set(ByVal Value As String)
            mXADRS_IN = Value
        End Set
    End Property
    ''' <summary>
    ''' �o�Ɏw�����ڽ
    ''' </summary>
    Public Property XADRS_OUT() As String
        Get
            Return mXADRS_OUT
        End Get
        Set(ByVal Value As String)
            mXADRS_OUT = Value
        End Set
    End Property
    ''' <summary>
    ''' �����w�����ڽ
    ''' </summary>
    Public Property XADRS_HANSOU() As String
        Get
            Return mXADRS_HANSOU
        End Get
        Set(ByVal Value As String)
            mXADRS_HANSOU = Value
        End Set
    End Property
    ''' <summary>
    ''' PLC�ׯ�ݸޱ��ڽ05
    ''' </summary>
    Public Property XADRS_PLCTRK05() As String
        Get
            Return mXADRS_PLCTRK05
        End Get
        Set(ByVal Value As String)
            mXADRS_PLCTRK05 = Value
        End Set
    End Property
    ''' <summary>
    ''' PLC�ׯ�ݸޱ��ڽ04
    ''' </summary>
    Public Property XADRS_PLCTRK04() As String
        Get
            Return mXADRS_PLCTRK04
        End Get
        Set(ByVal Value As String)
            mXADRS_PLCTRK04 = Value
        End Set
    End Property
    ''' <summary>
    ''' ��گĐ����ڽ01
    ''' </summary>
    Public Property XADRS_PALLET01() As String
        Get
            Return mXADRS_PALLET01
        End Get
        Set(ByVal Value As String)
            mXADRS_PALLET01 = Value
        End Set
    End Property
    ''' <summary>
    ''' ��گĐ����ڽ02
    ''' </summary>
    Public Property XADRS_PALLET02() As String
        Get
            Return mXADRS_PALLET02
        End Get
        Set(ByVal Value As String)
            mXADRS_PALLET02 = Value
        End Set
    End Property
    ''' <summary>
    ''' �\�萔���ڽ01
    ''' </summary>
    Public Property XADRS_YOTEI01() As String
        Get
            Return mXADRS_YOTEI01
        End Get
        Set(ByVal Value As String)
            mXADRS_YOTEI01 = Value
        End Set
    End Property
    ''' <summary>
    ''' �\�萔���ڽ02
    ''' </summary>
    Public Property XADRS_YOTEI02() As String
        Get
            Return mXADRS_YOTEI02
        End Get
        Set(ByVal Value As String)
            mXADRS_YOTEI02 = Value
        End Set
    End Property
    ''' <summary>
    ''' L/S�ԍ�
    ''' </summary>
    Public Property XLS_NO() As Nullable(Of Integer)
        Get
            Return mXLS_NO
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXLS_NO = Value
        End Set
    End Property
    ''' <summary>
    ''' ���ɗv���O�ݔ�ID
    ''' </summary>
    Public Property XEQ_ID_IN_FR() As String
        Get
            Return mXEQ_ID_IN_FR
        End Get
        Set(ByVal Value As String)
            mXEQ_ID_IN_FR = Value
        End Set
    End Property
    ''' <summary>
    ''' ���ɗv����ݔ�ID
    ''' </summary>
    Public Property XEQ_ID_IN_BK() As String
        Get
            Return mXEQ_ID_IN_BK
        End Get
        Set(ByVal Value As String)
            mXEQ_ID_IN_BK = Value
        End Set
    End Property
    ''' <summary>
    ''' �[���O�ݔ�ID
    ''' </summary>
    Public Property XEQ_ID_HASU_FR() As String
        Get
            Return mXEQ_ID_HASU_FR
        End Get
        Set(ByVal Value As String)
            mXEQ_ID_HASU_FR = Value
        End Set
    End Property
    ''' <summary>
    ''' �[����ݔ�ID
    ''' </summary>
    Public Property XEQ_ID_HASU_BK() As String
        Get
            Return mXEQ_ID_HASU_BK
        End Get
        Set(ByVal Value As String)
            mXEQ_ID_HASU_BK = Value
        End Set
    End Property
    ''' <summary>
    ''' ����Ԋ֘A�t��
    ''' </summary>
    Public Property XTRK_BUF_NO_CONV() As Nullable(Of Integer)
        Get
            Return mXTRK_BUF_NO_CONV
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXTRK_BUF_NO_CONV = Value
        End Set
    End Property
    ''' <summary>
    ''' ���I���ɗv���ݔ�ID
    ''' </summary>
    Public Property XEQ_ID_IRI_YOUKYU() As String
        Get
            Return mXEQ_ID_IRI_YOUKYU
        End Get
        Set(ByVal Value As String)
            mXEQ_ID_IRI_YOUKYU = Value
        End Set
    End Property
    ''' <summary>
    ''' �o�ɗv���ݔ�ID
    ''' </summary>
    Public Property XEQ_ID_OUT_YOUKYU() As String
        Get
            Return mXEQ_ID_OUT_YOUKYU
        End Get
        Set(ByVal Value As String)
            mXEQ_ID_OUT_YOUKYU = Value
        End Set
    End Property
    ''' <summary>
    ''' �o�I�ޯ̧��ݔ�ID
    ''' </summary>
    Public Property XEQ_ID_OUT_BUF() As String
        Get
            Return mXEQ_ID_OUT_BUF
        End Get
        Set(ByVal Value As String)
            mXEQ_ID_OUT_BUF = Value
        End Set
    End Property
    ''' <summary>
    ''' �o�Ɋ����ݔ�ID
    ''' </summary>
    Public Property XEQ_ID_OUT_END() As String
        Get
            Return mXEQ_ID_OUT_END
        End Get
        Set(ByVal Value As String)
            mXEQ_ID_OUT_END = Value
        End Set
    End Property
    ''' <summary>
    ''' �Ґ����\��
    ''' </summary>
    Public Property XEQ_ID_B_HENSEI() As String
        Get
            Return mXEQ_ID_B_HENSEI
        End Get
        Set(ByVal Value As String)
            mXEQ_ID_B_HENSEI = Value
        End Set
    End Property
    ''' <summary>
    ''' �o�Ɋ�������
    ''' </summary>
    Public Property XEQ_ID_B_OUTEND() As String
        Get
            Return mXEQ_ID_B_OUTEND
        End Get
        Set(ByVal Value As String)
            mXEQ_ID_B_OUTEND = Value
        End Set
    End Property
    ''' <summary>
    ''' �ύ���������
    ''' </summary>
    Public Property XEQ_ID_B_TUMIEND() As String
        Get
            Return mXEQ_ID_B_TUMIEND
        End Get
        Set(ByVal Value As String)
            mXEQ_ID_B_TUMIEND = Value
        End Set
    End Property
    ''' <summary>
    ''' ����ݽ�敪
    ''' </summary>
    Public Property XMAINTE_KUBUN() As Nullable(Of Integer)
        Get
            Return mXMAINTE_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXMAINTE_KUBUN = Value
        End Set
    End Property
    ''' <summary>
    ''' ����ݽ�敪��
    ''' </summary>
    Public Property XMAINTE_ORDER() As Nullable(Of Integer)
        Get
            Return mXMAINTE_ORDER
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXMAINTE_ORDER = Value
        End Set
    End Property
    ''' <summary>
    ''' ����ݽ�\����
    ''' </summary>
    Public Property XMAINTE_NAME() As String
        Get
            Return mXMAINTE_NAME
        End Get
        Set(ByVal Value As String)
            mXMAINTE_NAME = Value
        End Set
    End Property
    ''' <summary>
    ''' �ׯ�ݸ��ޯ̧����(��������)
    ''' </summary>
    Public Property XBUF_NAME_DTL() As String
        Get
            Return mXBUF_NAME_DTL
        End Get
        Set(ByVal Value As String)
            mXBUF_NAME_DTL = Value
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
    Public Function GET_TMST_TRK(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    TMST_TRK")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FTRK_BUF_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FBUF_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_NAME
            strSQL.Append(vbCrLf & "    AND FBUF_NAME = :" & UBound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧����")
        End If
        If IsNull(FBUF_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_KIND
            strSQL.Append(vbCrLf & "    AND FBUF_KIND = :" & UBound(strBindField) - 1 & " --�ޯ̧���")
        End If
        If IsNull(FNEW_IN_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFNEW_IN_KUBUN
            strSQL.Append(vbCrLf & "    AND FNEW_IN_KUBUN = :" & UBound(strBindField) - 1 & " --�V�K�����ޯ̧�敪")
        End If
        If IsNull(FBUF_MAX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_MAX
            strSQL.Append(vbCrLf & "    AND FBUF_MAX = :" & UBound(strBindField) - 1 & " --�ő��ޯ̧����")
        End If
        If IsNull(FBUF_LOG_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_LOG_FLAG
            strSQL.Append(vbCrLf & "    AND FBUF_LOG_FLAG = :" & UBound(strBindField) - 1 & " --۸ޗL���׸�")
        End If
        If IsNull(FRAC_RETU_MAX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_RETU_MAX
            strSQL.Append(vbCrLf & "    AND FRAC_RETU_MAX = :" & UBound(strBindField) - 1 & " --�ő��")
        End If
        If IsNull(FRAC_REN_MAX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_REN_MAX
            strSQL.Append(vbCrLf & "    AND FRAC_REN_MAX = :" & UBound(strBindField) - 1 & " --�ő�A��")
        End If
        If IsNull(FRAC_DAN_MAX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_DAN_MAX
            strSQL.Append(vbCrLf & "    AND FRAC_DAN_MAX = :" & UBound(strBindField) - 1 & " --�ő�i��")
        End If
        If IsNull(FRAC_EDA_MAX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_EDA_MAX
            strSQL.Append(vbCrLf & "    AND FRAC_EDA_MAX = :" & UBound(strBindField) - 1 & " --�ő�}��")
        End If
        If IsNull(FPLACE_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLACE_CD
            strSQL.Append(vbCrLf & "    AND FPLACE_CD = :" & UBound(strBindField) - 1 & " --�ۊǏꏊ����")
        End If
        If IsNull(FAREA_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFAREA_CD
            strSQL.Append(vbCrLf & "    AND FAREA_CD = :" & UBound(strBindField) - 1 & " --�ر����")
        End If
        If IsNull(XEQ_ID_MOD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_MOD
            strSQL.Append(vbCrLf & "    AND XEQ_ID_MOD = :" & UBound(strBindField) - 1 & " --Ӱ�ސݔ�ID")
        End If
        If IsNull(XEQ_ID_STN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_STN
            strSQL.Append(vbCrLf & "    AND XEQ_ID_STN = :" & UBound(strBindField) - 1 & " --ST�ډאݔ�ID")
        End If
        If IsNull(XTRK_BUF_NO_IN_HIRA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_IN_HIRA
            strSQL.Append(vbCrLf & "    AND XTRK_BUF_NO_IN_HIRA = :" & UBound(strBindField) - 1 & " --���ɐݒ莞���u")
        End If
        If IsNull(XTRK_BUF_NO_OUT_HIRA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_OUT_HIRA
            strSQL.Append(vbCrLf & "    AND XTRK_BUF_NO_OUT_HIRA = :" & UBound(strBindField) - 1 & " --�o�ɐݒ莞���u")
        End If
        If IsNull(XADRS_IN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_IN
            strSQL.Append(vbCrLf & "    AND XADRS_IN = :" & UBound(strBindField) - 1 & " --���Ɏw�����ڽ")
        End If
        If IsNull(XADRS_OUT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_OUT
            strSQL.Append(vbCrLf & "    AND XADRS_OUT = :" & UBound(strBindField) - 1 & " --�o�Ɏw�����ڽ")
        End If
        If IsNull(XADRS_HANSOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_HANSOU
            strSQL.Append(vbCrLf & "    AND XADRS_HANSOU = :" & UBound(strBindField) - 1 & " --�����w�����ڽ")
        End If
        If IsNull(XADRS_PLCTRK05) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PLCTRK05
            strSQL.Append(vbCrLf & "    AND XADRS_PLCTRK05 = :" & UBound(strBindField) - 1 & " --PLC�ׯ�ݸޱ��ڽ05")
        End If
        If IsNull(XADRS_PLCTRK04) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PLCTRK04
            strSQL.Append(vbCrLf & "    AND XADRS_PLCTRK04 = :" & UBound(strBindField) - 1 & " --PLC�ׯ�ݸޱ��ڽ04")
        End If
        If IsNull(XADRS_PALLET01) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PALLET01
            strSQL.Append(vbCrLf & "    AND XADRS_PALLET01 = :" & UBound(strBindField) - 1 & " --��گĐ����ڽ01")
        End If
        If IsNull(XADRS_PALLET02) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PALLET02
            strSQL.Append(vbCrLf & "    AND XADRS_PALLET02 = :" & UBound(strBindField) - 1 & " --��گĐ����ڽ02")
        End If
        If IsNull(XADRS_YOTEI01) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_YOTEI01
            strSQL.Append(vbCrLf & "    AND XADRS_YOTEI01 = :" & UBound(strBindField) - 1 & " --�\�萔���ڽ01")
        End If
        If IsNull(XADRS_YOTEI02) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_YOTEI02
            strSQL.Append(vbCrLf & "    AND XADRS_YOTEI02 = :" & UBound(strBindField) - 1 & " --�\�萔���ڽ02")
        End If
        If IsNull(XLS_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXLS_NO
            strSQL.Append(vbCrLf & "    AND XLS_NO = :" & UBound(strBindField) - 1 & " --L/S�ԍ�")
        End If
        If IsNull(XEQ_ID_IN_FR) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_IN_FR
            strSQL.Append(vbCrLf & "    AND XEQ_ID_IN_FR = :" & UBound(strBindField) - 1 & " --���ɗv���O�ݔ�ID")
        End If
        If IsNull(XEQ_ID_IN_BK) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_IN_BK
            strSQL.Append(vbCrLf & "    AND XEQ_ID_IN_BK = :" & UBound(strBindField) - 1 & " --���ɗv����ݔ�ID")
        End If
        If IsNull(XEQ_ID_HASU_FR) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_HASU_FR
            strSQL.Append(vbCrLf & "    AND XEQ_ID_HASU_FR = :" & UBound(strBindField) - 1 & " --�[���O�ݔ�ID")
        End If
        If IsNull(XEQ_ID_HASU_BK) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_HASU_BK
            strSQL.Append(vbCrLf & "    AND XEQ_ID_HASU_BK = :" & UBound(strBindField) - 1 & " --�[����ݔ�ID")
        End If
        If IsNull(XTRK_BUF_NO_CONV) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_CONV
            strSQL.Append(vbCrLf & "    AND XTRK_BUF_NO_CONV = :" & UBound(strBindField) - 1 & " --����Ԋ֘A�t��")
        End If
        If IsNull(XEQ_ID_IRI_YOUKYU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_IRI_YOUKYU
            strSQL.Append(vbCrLf & "    AND XEQ_ID_IRI_YOUKYU = :" & UBound(strBindField) - 1 & " --���I���ɗv���ݔ�ID")
        End If
        If IsNull(XEQ_ID_OUT_YOUKYU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_OUT_YOUKYU
            strSQL.Append(vbCrLf & "    AND XEQ_ID_OUT_YOUKYU = :" & UBound(strBindField) - 1 & " --�o�ɗv���ݔ�ID")
        End If
        If IsNull(XEQ_ID_OUT_BUF) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_OUT_BUF
            strSQL.Append(vbCrLf & "    AND XEQ_ID_OUT_BUF = :" & UBound(strBindField) - 1 & " --�o�I�ޯ̧��ݔ�ID")
        End If
        If IsNull(XEQ_ID_OUT_END) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_OUT_END
            strSQL.Append(vbCrLf & "    AND XEQ_ID_OUT_END = :" & UBound(strBindField) - 1 & " --�o�Ɋ����ݔ�ID")
        End If
        If IsNull(XEQ_ID_B_HENSEI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_HENSEI
            strSQL.Append(vbCrLf & "    AND XEQ_ID_B_HENSEI = :" & UBound(strBindField) - 1 & " --�Ґ����\��")
        End If
        If IsNull(XEQ_ID_B_OUTEND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_OUTEND
            strSQL.Append(vbCrLf & "    AND XEQ_ID_B_OUTEND = :" & UBound(strBindField) - 1 & " --�o�Ɋ�������")
        End If
        If IsNull(XEQ_ID_B_TUMIEND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_TUMIEND
            strSQL.Append(vbCrLf & "    AND XEQ_ID_B_TUMIEND = :" & UBound(strBindField) - 1 & " --�ύ���������")
        End If
        If IsNull(XMAINTE_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAINTE_KUBUN
            strSQL.Append(vbCrLf & "    AND XMAINTE_KUBUN = :" & UBound(strBindField) - 1 & " --����ݽ�敪")
        End If
        If IsNull(XMAINTE_ORDER) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAINTE_ORDER
            strSQL.Append(vbCrLf & "    AND XMAINTE_ORDER = :" & UBound(strBindField) - 1 & " --����ݽ�敪��")
        End If
        If IsNull(XMAINTE_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAINTE_NAME
            strSQL.Append(vbCrLf & "    AND XMAINTE_NAME = :" & UBound(strBindField) - 1 & " --����ݽ�\����")
        End If
        If IsNull(XBUF_NAME_DTL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBUF_NAME_DTL
            strSQL.Append(vbCrLf & "    AND XBUF_NAME_DTL = :" & UBound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧����(��������)")
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
        strDataSetName = "TMST_TRK"
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
    Public Function GET_TMST_TRK_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    TMST_TRK")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FTRK_BUF_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FBUF_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_NAME
            strSQL.Append(vbCrLf & "    AND FBUF_NAME = :" & UBound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧����")
        End If
        If IsNull(FBUF_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_KIND
            strSQL.Append(vbCrLf & "    AND FBUF_KIND = :" & UBound(strBindField) - 1 & " --�ޯ̧���")
        End If
        If IsNull(FNEW_IN_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFNEW_IN_KUBUN
            strSQL.Append(vbCrLf & "    AND FNEW_IN_KUBUN = :" & UBound(strBindField) - 1 & " --�V�K�����ޯ̧�敪")
        End If
        If IsNull(FBUF_MAX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_MAX
            strSQL.Append(vbCrLf & "    AND FBUF_MAX = :" & UBound(strBindField) - 1 & " --�ő��ޯ̧����")
        End If
        If IsNull(FBUF_LOG_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_LOG_FLAG
            strSQL.Append(vbCrLf & "    AND FBUF_LOG_FLAG = :" & UBound(strBindField) - 1 & " --۸ޗL���׸�")
        End If
        If IsNull(FRAC_RETU_MAX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_RETU_MAX
            strSQL.Append(vbCrLf & "    AND FRAC_RETU_MAX = :" & UBound(strBindField) - 1 & " --�ő��")
        End If
        If IsNull(FRAC_REN_MAX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_REN_MAX
            strSQL.Append(vbCrLf & "    AND FRAC_REN_MAX = :" & UBound(strBindField) - 1 & " --�ő�A��")
        End If
        If IsNull(FRAC_DAN_MAX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_DAN_MAX
            strSQL.Append(vbCrLf & "    AND FRAC_DAN_MAX = :" & UBound(strBindField) - 1 & " --�ő�i��")
        End If
        If IsNull(FRAC_EDA_MAX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_EDA_MAX
            strSQL.Append(vbCrLf & "    AND FRAC_EDA_MAX = :" & UBound(strBindField) - 1 & " --�ő�}��")
        End If
        If IsNull(FPLACE_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLACE_CD
            strSQL.Append(vbCrLf & "    AND FPLACE_CD = :" & UBound(strBindField) - 1 & " --�ۊǏꏊ����")
        End If
        If IsNull(FAREA_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFAREA_CD
            strSQL.Append(vbCrLf & "    AND FAREA_CD = :" & UBound(strBindField) - 1 & " --�ر����")
        End If
        If IsNull(XEQ_ID_MOD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_MOD
            strSQL.Append(vbCrLf & "    AND XEQ_ID_MOD = :" & UBound(strBindField) - 1 & " --Ӱ�ސݔ�ID")
        End If
        If IsNull(XEQ_ID_STN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_STN
            strSQL.Append(vbCrLf & "    AND XEQ_ID_STN = :" & UBound(strBindField) - 1 & " --ST�ډאݔ�ID")
        End If
        If IsNull(XTRK_BUF_NO_IN_HIRA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_IN_HIRA
            strSQL.Append(vbCrLf & "    AND XTRK_BUF_NO_IN_HIRA = :" & UBound(strBindField) - 1 & " --���ɐݒ莞���u")
        End If
        If IsNull(XTRK_BUF_NO_OUT_HIRA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_OUT_HIRA
            strSQL.Append(vbCrLf & "    AND XTRK_BUF_NO_OUT_HIRA = :" & UBound(strBindField) - 1 & " --�o�ɐݒ莞���u")
        End If
        If IsNull(XADRS_IN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_IN
            strSQL.Append(vbCrLf & "    AND XADRS_IN = :" & UBound(strBindField) - 1 & " --���Ɏw�����ڽ")
        End If
        If IsNull(XADRS_OUT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_OUT
            strSQL.Append(vbCrLf & "    AND XADRS_OUT = :" & UBound(strBindField) - 1 & " --�o�Ɏw�����ڽ")
        End If
        If IsNull(XADRS_HANSOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_HANSOU
            strSQL.Append(vbCrLf & "    AND XADRS_HANSOU = :" & UBound(strBindField) - 1 & " --�����w�����ڽ")
        End If
        If IsNull(XADRS_PLCTRK05) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PLCTRK05
            strSQL.Append(vbCrLf & "    AND XADRS_PLCTRK05 = :" & UBound(strBindField) - 1 & " --PLC�ׯ�ݸޱ��ڽ05")
        End If
        If IsNull(XADRS_PLCTRK04) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PLCTRK04
            strSQL.Append(vbCrLf & "    AND XADRS_PLCTRK04 = :" & UBound(strBindField) - 1 & " --PLC�ׯ�ݸޱ��ڽ04")
        End If
        If IsNull(XADRS_PALLET01) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PALLET01
            strSQL.Append(vbCrLf & "    AND XADRS_PALLET01 = :" & UBound(strBindField) - 1 & " --��گĐ����ڽ01")
        End If
        If IsNull(XADRS_PALLET02) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PALLET02
            strSQL.Append(vbCrLf & "    AND XADRS_PALLET02 = :" & UBound(strBindField) - 1 & " --��گĐ����ڽ02")
        End If
        If IsNull(XADRS_YOTEI01) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_YOTEI01
            strSQL.Append(vbCrLf & "    AND XADRS_YOTEI01 = :" & UBound(strBindField) - 1 & " --�\�萔���ڽ01")
        End If
        If IsNull(XADRS_YOTEI02) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_YOTEI02
            strSQL.Append(vbCrLf & "    AND XADRS_YOTEI02 = :" & UBound(strBindField) - 1 & " --�\�萔���ڽ02")
        End If
        If IsNull(XLS_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXLS_NO
            strSQL.Append(vbCrLf & "    AND XLS_NO = :" & UBound(strBindField) - 1 & " --L/S�ԍ�")
        End If
        If IsNull(XEQ_ID_IN_FR) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_IN_FR
            strSQL.Append(vbCrLf & "    AND XEQ_ID_IN_FR = :" & UBound(strBindField) - 1 & " --���ɗv���O�ݔ�ID")
        End If
        If IsNull(XEQ_ID_IN_BK) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_IN_BK
            strSQL.Append(vbCrLf & "    AND XEQ_ID_IN_BK = :" & UBound(strBindField) - 1 & " --���ɗv����ݔ�ID")
        End If
        If IsNull(XEQ_ID_HASU_FR) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_HASU_FR
            strSQL.Append(vbCrLf & "    AND XEQ_ID_HASU_FR = :" & UBound(strBindField) - 1 & " --�[���O�ݔ�ID")
        End If
        If IsNull(XEQ_ID_HASU_BK) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_HASU_BK
            strSQL.Append(vbCrLf & "    AND XEQ_ID_HASU_BK = :" & UBound(strBindField) - 1 & " --�[����ݔ�ID")
        End If
        If IsNull(XTRK_BUF_NO_CONV) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_CONV
            strSQL.Append(vbCrLf & "    AND XTRK_BUF_NO_CONV = :" & UBound(strBindField) - 1 & " --����Ԋ֘A�t��")
        End If
        If IsNull(XEQ_ID_IRI_YOUKYU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_IRI_YOUKYU
            strSQL.Append(vbCrLf & "    AND XEQ_ID_IRI_YOUKYU = :" & UBound(strBindField) - 1 & " --���I���ɗv���ݔ�ID")
        End If
        If IsNull(XEQ_ID_OUT_YOUKYU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_OUT_YOUKYU
            strSQL.Append(vbCrLf & "    AND XEQ_ID_OUT_YOUKYU = :" & UBound(strBindField) - 1 & " --�o�ɗv���ݔ�ID")
        End If
        If IsNull(XEQ_ID_OUT_BUF) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_OUT_BUF
            strSQL.Append(vbCrLf & "    AND XEQ_ID_OUT_BUF = :" & UBound(strBindField) - 1 & " --�o�I�ޯ̧��ݔ�ID")
        End If
        If IsNull(XEQ_ID_OUT_END) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_OUT_END
            strSQL.Append(vbCrLf & "    AND XEQ_ID_OUT_END = :" & UBound(strBindField) - 1 & " --�o�Ɋ����ݔ�ID")
        End If
        If IsNull(XEQ_ID_B_HENSEI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_HENSEI
            strSQL.Append(vbCrLf & "    AND XEQ_ID_B_HENSEI = :" & UBound(strBindField) - 1 & " --�Ґ����\��")
        End If
        If IsNull(XEQ_ID_B_OUTEND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_OUTEND
            strSQL.Append(vbCrLf & "    AND XEQ_ID_B_OUTEND = :" & UBound(strBindField) - 1 & " --�o�Ɋ�������")
        End If
        If IsNull(XEQ_ID_B_TUMIEND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_TUMIEND
            strSQL.Append(vbCrLf & "    AND XEQ_ID_B_TUMIEND = :" & UBound(strBindField) - 1 & " --�ύ���������")
        End If
        If IsNull(XMAINTE_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAINTE_KUBUN
            strSQL.Append(vbCrLf & "    AND XMAINTE_KUBUN = :" & UBound(strBindField) - 1 & " --����ݽ�敪")
        End If
        If IsNull(XMAINTE_ORDER) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAINTE_ORDER
            strSQL.Append(vbCrLf & "    AND XMAINTE_ORDER = :" & UBound(strBindField) - 1 & " --����ݽ�敪��")
        End If
        If IsNull(XMAINTE_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAINTE_NAME
            strSQL.Append(vbCrLf & "    AND XMAINTE_NAME = :" & UBound(strBindField) - 1 & " --����ݽ�\����")
        End If
        If IsNull(XBUF_NAME_DTL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBUF_NAME_DTL
            strSQL.Append(vbCrLf & "    AND XBUF_NAME_DTL = :" & UBound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧����(��������)")
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
        strDataSetName = "TMST_TRK"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TMST_TRK(Owner, objDb, objDbLog)
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
    Public Function GET_TMST_TRK_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "TMST_TRK"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TMST_TRK(Owner, objDb, objDbLog)
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
    Public Function GET_TMST_TRK_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    TMST_TRK")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FTRK_BUF_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FBUF_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_NAME
            strSQL.Append(vbCrLf & "    AND FBUF_NAME = :" & UBound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧����")
        End If
        If IsNull(FBUF_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_KIND
            strSQL.Append(vbCrLf & "    AND FBUF_KIND = :" & UBound(strBindField) - 1 & " --�ޯ̧���")
        End If
        If IsNull(FNEW_IN_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFNEW_IN_KUBUN
            strSQL.Append(vbCrLf & "    AND FNEW_IN_KUBUN = :" & UBound(strBindField) - 1 & " --�V�K�����ޯ̧�敪")
        End If
        If IsNull(FBUF_MAX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_MAX
            strSQL.Append(vbCrLf & "    AND FBUF_MAX = :" & UBound(strBindField) - 1 & " --�ő��ޯ̧����")
        End If
        If IsNull(FBUF_LOG_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_LOG_FLAG
            strSQL.Append(vbCrLf & "    AND FBUF_LOG_FLAG = :" & UBound(strBindField) - 1 & " --۸ޗL���׸�")
        End If
        If IsNull(FRAC_RETU_MAX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_RETU_MAX
            strSQL.Append(vbCrLf & "    AND FRAC_RETU_MAX = :" & UBound(strBindField) - 1 & " --�ő��")
        End If
        If IsNull(FRAC_REN_MAX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_REN_MAX
            strSQL.Append(vbCrLf & "    AND FRAC_REN_MAX = :" & UBound(strBindField) - 1 & " --�ő�A��")
        End If
        If IsNull(FRAC_DAN_MAX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_DAN_MAX
            strSQL.Append(vbCrLf & "    AND FRAC_DAN_MAX = :" & UBound(strBindField) - 1 & " --�ő�i��")
        End If
        If IsNull(FRAC_EDA_MAX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_EDA_MAX
            strSQL.Append(vbCrLf & "    AND FRAC_EDA_MAX = :" & UBound(strBindField) - 1 & " --�ő�}��")
        End If
        If IsNull(FPLACE_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLACE_CD
            strSQL.Append(vbCrLf & "    AND FPLACE_CD = :" & UBound(strBindField) - 1 & " --�ۊǏꏊ����")
        End If
        If IsNull(FAREA_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFAREA_CD
            strSQL.Append(vbCrLf & "    AND FAREA_CD = :" & UBound(strBindField) - 1 & " --�ر����")
        End If
        If IsNull(XEQ_ID_MOD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_MOD
            strSQL.Append(vbCrLf & "    AND XEQ_ID_MOD = :" & UBound(strBindField) - 1 & " --Ӱ�ސݔ�ID")
        End If
        If IsNull(XEQ_ID_STN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_STN
            strSQL.Append(vbCrLf & "    AND XEQ_ID_STN = :" & UBound(strBindField) - 1 & " --ST�ډאݔ�ID")
        End If
        If IsNull(XTRK_BUF_NO_IN_HIRA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_IN_HIRA
            strSQL.Append(vbCrLf & "    AND XTRK_BUF_NO_IN_HIRA = :" & UBound(strBindField) - 1 & " --���ɐݒ莞���u")
        End If
        If IsNull(XTRK_BUF_NO_OUT_HIRA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_OUT_HIRA
            strSQL.Append(vbCrLf & "    AND XTRK_BUF_NO_OUT_HIRA = :" & UBound(strBindField) - 1 & " --�o�ɐݒ莞���u")
        End If
        If IsNull(XADRS_IN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_IN
            strSQL.Append(vbCrLf & "    AND XADRS_IN = :" & UBound(strBindField) - 1 & " --���Ɏw�����ڽ")
        End If
        If IsNull(XADRS_OUT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_OUT
            strSQL.Append(vbCrLf & "    AND XADRS_OUT = :" & UBound(strBindField) - 1 & " --�o�Ɏw�����ڽ")
        End If
        If IsNull(XADRS_HANSOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_HANSOU
            strSQL.Append(vbCrLf & "    AND XADRS_HANSOU = :" & UBound(strBindField) - 1 & " --�����w�����ڽ")
        End If
        If IsNull(XADRS_PLCTRK05) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PLCTRK05
            strSQL.Append(vbCrLf & "    AND XADRS_PLCTRK05 = :" & UBound(strBindField) - 1 & " --PLC�ׯ�ݸޱ��ڽ05")
        End If
        If IsNull(XADRS_PLCTRK04) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PLCTRK04
            strSQL.Append(vbCrLf & "    AND XADRS_PLCTRK04 = :" & UBound(strBindField) - 1 & " --PLC�ׯ�ݸޱ��ڽ04")
        End If
        If IsNull(XADRS_PALLET01) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PALLET01
            strSQL.Append(vbCrLf & "    AND XADRS_PALLET01 = :" & UBound(strBindField) - 1 & " --��گĐ����ڽ01")
        End If
        If IsNull(XADRS_PALLET02) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PALLET02
            strSQL.Append(vbCrLf & "    AND XADRS_PALLET02 = :" & UBound(strBindField) - 1 & " --��گĐ����ڽ02")
        End If
        If IsNull(XADRS_YOTEI01) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_YOTEI01
            strSQL.Append(vbCrLf & "    AND XADRS_YOTEI01 = :" & UBound(strBindField) - 1 & " --�\�萔���ڽ01")
        End If
        If IsNull(XADRS_YOTEI02) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_YOTEI02
            strSQL.Append(vbCrLf & "    AND XADRS_YOTEI02 = :" & UBound(strBindField) - 1 & " --�\�萔���ڽ02")
        End If
        If IsNull(XLS_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXLS_NO
            strSQL.Append(vbCrLf & "    AND XLS_NO = :" & UBound(strBindField) - 1 & " --L/S�ԍ�")
        End If
        If IsNull(XEQ_ID_IN_FR) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_IN_FR
            strSQL.Append(vbCrLf & "    AND XEQ_ID_IN_FR = :" & UBound(strBindField) - 1 & " --���ɗv���O�ݔ�ID")
        End If
        If IsNull(XEQ_ID_IN_BK) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_IN_BK
            strSQL.Append(vbCrLf & "    AND XEQ_ID_IN_BK = :" & UBound(strBindField) - 1 & " --���ɗv����ݔ�ID")
        End If
        If IsNull(XEQ_ID_HASU_FR) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_HASU_FR
            strSQL.Append(vbCrLf & "    AND XEQ_ID_HASU_FR = :" & UBound(strBindField) - 1 & " --�[���O�ݔ�ID")
        End If
        If IsNull(XEQ_ID_HASU_BK) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_HASU_BK
            strSQL.Append(vbCrLf & "    AND XEQ_ID_HASU_BK = :" & UBound(strBindField) - 1 & " --�[����ݔ�ID")
        End If
        If IsNull(XTRK_BUF_NO_CONV) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_CONV
            strSQL.Append(vbCrLf & "    AND XTRK_BUF_NO_CONV = :" & UBound(strBindField) - 1 & " --����Ԋ֘A�t��")
        End If
        If IsNull(XEQ_ID_IRI_YOUKYU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_IRI_YOUKYU
            strSQL.Append(vbCrLf & "    AND XEQ_ID_IRI_YOUKYU = :" & UBound(strBindField) - 1 & " --���I���ɗv���ݔ�ID")
        End If
        If IsNull(XEQ_ID_OUT_YOUKYU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_OUT_YOUKYU
            strSQL.Append(vbCrLf & "    AND XEQ_ID_OUT_YOUKYU = :" & UBound(strBindField) - 1 & " --�o�ɗv���ݔ�ID")
        End If
        If IsNull(XEQ_ID_OUT_BUF) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_OUT_BUF
            strSQL.Append(vbCrLf & "    AND XEQ_ID_OUT_BUF = :" & UBound(strBindField) - 1 & " --�o�I�ޯ̧��ݔ�ID")
        End If
        If IsNull(XEQ_ID_OUT_END) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_OUT_END
            strSQL.Append(vbCrLf & "    AND XEQ_ID_OUT_END = :" & UBound(strBindField) - 1 & " --�o�Ɋ����ݔ�ID")
        End If
        If IsNull(XEQ_ID_B_HENSEI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_HENSEI
            strSQL.Append(vbCrLf & "    AND XEQ_ID_B_HENSEI = :" & UBound(strBindField) - 1 & " --�Ґ����\��")
        End If
        If IsNull(XEQ_ID_B_OUTEND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_OUTEND
            strSQL.Append(vbCrLf & "    AND XEQ_ID_B_OUTEND = :" & UBound(strBindField) - 1 & " --�o�Ɋ�������")
        End If
        If IsNull(XEQ_ID_B_TUMIEND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_TUMIEND
            strSQL.Append(vbCrLf & "    AND XEQ_ID_B_TUMIEND = :" & UBound(strBindField) - 1 & " --�ύ���������")
        End If
        If IsNull(XMAINTE_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAINTE_KUBUN
            strSQL.Append(vbCrLf & "    AND XMAINTE_KUBUN = :" & UBound(strBindField) - 1 & " --����ݽ�敪")
        End If
        If IsNull(XMAINTE_ORDER) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAINTE_ORDER
            strSQL.Append(vbCrLf & "    AND XMAINTE_ORDER = :" & UBound(strBindField) - 1 & " --����ݽ�敪��")
        End If
        If IsNull(XMAINTE_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAINTE_NAME
            strSQL.Append(vbCrLf & "    AND XMAINTE_NAME = :" & UBound(strBindField) - 1 & " --����ݽ�\����")
        End If
        If IsNull(XBUF_NAME_DTL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBUF_NAME_DTL
            strSQL.Append(vbCrLf & "    AND XBUF_NAME_DTL = :" & UBound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧����(��������)")
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
        strDataSetName = "TMST_TRK"
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
    Public Sub UPDATE_TMST_TRK()
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
        ElseIf IsNull(mFBUF_NAME) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�ׯ�ݸ��ޯ̧����]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFBUF_KIND) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�ޯ̧���]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFNEW_IN_KUBUN) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�V�K�����ޯ̧�敪]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFBUF_MAX) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�ő��ޯ̧����]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFBUF_LOG_FLAG) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[۸ޗL���׸�]"
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
        strSQL.Append(vbCrLf & "    TMST_TRK")
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
        If IsNull(mFBUF_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FBUF_NAME = NULL --�ׯ�ݸ��ޯ̧����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FBUF_NAME = NULL --�ׯ�ݸ��ޯ̧����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FBUF_NAME = :" & Ubound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FBUF_NAME = :" & Ubound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧����")
        End If
        intCount = intCount + 1
        If IsNull(mFBUF_KIND) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FBUF_KIND = NULL --�ޯ̧���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FBUF_KIND = NULL --�ޯ̧���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_KIND
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FBUF_KIND = :" & Ubound(strBindField) - 1 & " --�ޯ̧���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FBUF_KIND = :" & Ubound(strBindField) - 1 & " --�ޯ̧���")
        End If
        intCount = intCount + 1
        If IsNull(mFNEW_IN_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FNEW_IN_KUBUN = NULL --�V�K�����ޯ̧�敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FNEW_IN_KUBUN = NULL --�V�K�����ޯ̧�敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFNEW_IN_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FNEW_IN_KUBUN = :" & Ubound(strBindField) - 1 & " --�V�K�����ޯ̧�敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FNEW_IN_KUBUN = :" & Ubound(strBindField) - 1 & " --�V�K�����ޯ̧�敪")
        End If
        intCount = intCount + 1
        If IsNull(mFBUF_MAX) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FBUF_MAX = NULL --�ő��ޯ̧����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FBUF_MAX = NULL --�ő��ޯ̧����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_MAX
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FBUF_MAX = :" & Ubound(strBindField) - 1 & " --�ő��ޯ̧����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FBUF_MAX = :" & Ubound(strBindField) - 1 & " --�ő��ޯ̧����")
        End If
        intCount = intCount + 1
        If IsNull(mFBUF_LOG_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FBUF_LOG_FLAG = NULL --۸ޗL���׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FBUF_LOG_FLAG = NULL --۸ޗL���׸�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_LOG_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FBUF_LOG_FLAG = :" & Ubound(strBindField) - 1 & " --۸ޗL���׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FBUF_LOG_FLAG = :" & Ubound(strBindField) - 1 & " --۸ޗL���׸�")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_RETU_MAX) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_RETU_MAX = NULL --�ő��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_RETU_MAX = NULL --�ő��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_RETU_MAX
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_RETU_MAX = :" & Ubound(strBindField) - 1 & " --�ő��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_RETU_MAX = :" & Ubound(strBindField) - 1 & " --�ő��")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_REN_MAX) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_REN_MAX = NULL --�ő�A��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_REN_MAX = NULL --�ő�A��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_REN_MAX
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_REN_MAX = :" & Ubound(strBindField) - 1 & " --�ő�A��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_REN_MAX = :" & Ubound(strBindField) - 1 & " --�ő�A��")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_DAN_MAX) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_DAN_MAX = NULL --�ő�i��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_DAN_MAX = NULL --�ő�i��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_DAN_MAX
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_DAN_MAX = :" & Ubound(strBindField) - 1 & " --�ő�i��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_DAN_MAX = :" & Ubound(strBindField) - 1 & " --�ő�i��")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_EDA_MAX) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_EDA_MAX = NULL --�ő�}��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_EDA_MAX = NULL --�ő�}��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_EDA_MAX
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_EDA_MAX = :" & Ubound(strBindField) - 1 & " --�ő�}��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_EDA_MAX = :" & Ubound(strBindField) - 1 & " --�ő�}��")
        End If
        intCount = intCount + 1
        If IsNull(mFPLACE_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FPLACE_CD = NULL --�ۊǏꏊ����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FPLACE_CD = NULL --�ۊǏꏊ����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLACE_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FPLACE_CD = :" & Ubound(strBindField) - 1 & " --�ۊǏꏊ����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FPLACE_CD = :" & Ubound(strBindField) - 1 & " --�ۊǏꏊ����")
        End If
        intCount = intCount + 1
        If IsNull(mFAREA_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FAREA_CD = NULL --�ر����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FAREA_CD = NULL --�ر����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFAREA_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FAREA_CD = :" & Ubound(strBindField) - 1 & " --�ر����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FAREA_CD = :" & Ubound(strBindField) - 1 & " --�ر����")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_MOD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_MOD = NULL --Ӱ�ސݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_MOD = NULL --Ӱ�ސݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_MOD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_MOD = :" & Ubound(strBindField) - 1 & " --Ӱ�ސݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_MOD = :" & Ubound(strBindField) - 1 & " --Ӱ�ސݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_STN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_STN = NULL --ST�ډאݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_STN = NULL --ST�ډאݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_STN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_STN = :" & Ubound(strBindField) - 1 & " --ST�ډאݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_STN = :" & Ubound(strBindField) - 1 & " --ST�ډאݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXTRK_BUF_NO_IN_HIRA) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTRK_BUF_NO_IN_HIRA = NULL --���ɐݒ莞���u")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTRK_BUF_NO_IN_HIRA = NULL --���ɐݒ莞���u")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_IN_HIRA
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTRK_BUF_NO_IN_HIRA = :" & Ubound(strBindField) - 1 & " --���ɐݒ莞���u")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTRK_BUF_NO_IN_HIRA = :" & Ubound(strBindField) - 1 & " --���ɐݒ莞���u")
        End If
        intCount = intCount + 1
        If IsNull(mXTRK_BUF_NO_OUT_HIRA) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTRK_BUF_NO_OUT_HIRA = NULL --�o�ɐݒ莞���u")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTRK_BUF_NO_OUT_HIRA = NULL --�o�ɐݒ莞���u")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_OUT_HIRA
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTRK_BUF_NO_OUT_HIRA = :" & Ubound(strBindField) - 1 & " --�o�ɐݒ莞���u")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTRK_BUF_NO_OUT_HIRA = :" & Ubound(strBindField) - 1 & " --�o�ɐݒ莞���u")
        End If
        intCount = intCount + 1
        If IsNull(mXADRS_IN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XADRS_IN = NULL --���Ɏw�����ڽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XADRS_IN = NULL --���Ɏw�����ڽ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_IN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XADRS_IN = :" & Ubound(strBindField) - 1 & " --���Ɏw�����ڽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XADRS_IN = :" & Ubound(strBindField) - 1 & " --���Ɏw�����ڽ")
        End If
        intCount = intCount + 1
        If IsNull(mXADRS_OUT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XADRS_OUT = NULL --�o�Ɏw�����ڽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XADRS_OUT = NULL --�o�Ɏw�����ڽ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_OUT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XADRS_OUT = :" & Ubound(strBindField) - 1 & " --�o�Ɏw�����ڽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XADRS_OUT = :" & Ubound(strBindField) - 1 & " --�o�Ɏw�����ڽ")
        End If
        intCount = intCount + 1
        If IsNull(mXADRS_HANSOU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XADRS_HANSOU = NULL --�����w�����ڽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XADRS_HANSOU = NULL --�����w�����ڽ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_HANSOU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XADRS_HANSOU = :" & Ubound(strBindField) - 1 & " --�����w�����ڽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XADRS_HANSOU = :" & Ubound(strBindField) - 1 & " --�����w�����ڽ")
        End If
        intCount = intCount + 1
        If IsNull(mXADRS_PLCTRK05) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XADRS_PLCTRK05 = NULL --PLC�ׯ�ݸޱ��ڽ05")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XADRS_PLCTRK05 = NULL --PLC�ׯ�ݸޱ��ڽ05")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PLCTRK05
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XADRS_PLCTRK05 = :" & Ubound(strBindField) - 1 & " --PLC�ׯ�ݸޱ��ڽ05")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XADRS_PLCTRK05 = :" & Ubound(strBindField) - 1 & " --PLC�ׯ�ݸޱ��ڽ05")
        End If
        intCount = intCount + 1
        If IsNull(mXADRS_PLCTRK04) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XADRS_PLCTRK04 = NULL --PLC�ׯ�ݸޱ��ڽ04")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XADRS_PLCTRK04 = NULL --PLC�ׯ�ݸޱ��ڽ04")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PLCTRK04
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XADRS_PLCTRK04 = :" & Ubound(strBindField) - 1 & " --PLC�ׯ�ݸޱ��ڽ04")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XADRS_PLCTRK04 = :" & Ubound(strBindField) - 1 & " --PLC�ׯ�ݸޱ��ڽ04")
        End If
        intCount = intCount + 1
        If IsNull(mXADRS_PALLET01) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XADRS_PALLET01 = NULL --��گĐ����ڽ01")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XADRS_PALLET01 = NULL --��گĐ����ڽ01")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PALLET01
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XADRS_PALLET01 = :" & Ubound(strBindField) - 1 & " --��گĐ����ڽ01")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XADRS_PALLET01 = :" & Ubound(strBindField) - 1 & " --��گĐ����ڽ01")
        End If
        intCount = intCount + 1
        If IsNull(mXADRS_PALLET02) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XADRS_PALLET02 = NULL --��گĐ����ڽ02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XADRS_PALLET02 = NULL --��گĐ����ڽ02")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PALLET02
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XADRS_PALLET02 = :" & Ubound(strBindField) - 1 & " --��گĐ����ڽ02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XADRS_PALLET02 = :" & Ubound(strBindField) - 1 & " --��گĐ����ڽ02")
        End If
        intCount = intCount + 1
        If IsNull(mXADRS_YOTEI01) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XADRS_YOTEI01 = NULL --�\�萔���ڽ01")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XADRS_YOTEI01 = NULL --�\�萔���ڽ01")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_YOTEI01
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XADRS_YOTEI01 = :" & Ubound(strBindField) - 1 & " --�\�萔���ڽ01")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XADRS_YOTEI01 = :" & Ubound(strBindField) - 1 & " --�\�萔���ڽ01")
        End If
        intCount = intCount + 1
        If IsNull(mXADRS_YOTEI02) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XADRS_YOTEI02 = NULL --�\�萔���ڽ02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XADRS_YOTEI02 = NULL --�\�萔���ڽ02")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_YOTEI02
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XADRS_YOTEI02 = :" & Ubound(strBindField) - 1 & " --�\�萔���ڽ02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XADRS_YOTEI02 = :" & Ubound(strBindField) - 1 & " --�\�萔���ڽ02")
        End If
        intCount = intCount + 1
        If IsNull(mXLS_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XLS_NO = NULL --L/S�ԍ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XLS_NO = NULL --L/S�ԍ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXLS_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XLS_NO = :" & Ubound(strBindField) - 1 & " --L/S�ԍ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XLS_NO = :" & Ubound(strBindField) - 1 & " --L/S�ԍ�")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_IN_FR) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_IN_FR = NULL --���ɗv���O�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_IN_FR = NULL --���ɗv���O�ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_IN_FR
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_IN_FR = :" & Ubound(strBindField) - 1 & " --���ɗv���O�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_IN_FR = :" & Ubound(strBindField) - 1 & " --���ɗv���O�ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_IN_BK) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_IN_BK = NULL --���ɗv����ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_IN_BK = NULL --���ɗv����ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_IN_BK
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_IN_BK = :" & Ubound(strBindField) - 1 & " --���ɗv����ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_IN_BK = :" & Ubound(strBindField) - 1 & " --���ɗv����ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_HASU_FR) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_HASU_FR = NULL --�[���O�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_HASU_FR = NULL --�[���O�ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_HASU_FR
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_HASU_FR = :" & Ubound(strBindField) - 1 & " --�[���O�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_HASU_FR = :" & Ubound(strBindField) - 1 & " --�[���O�ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_HASU_BK) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_HASU_BK = NULL --�[����ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_HASU_BK = NULL --�[����ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_HASU_BK
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_HASU_BK = :" & Ubound(strBindField) - 1 & " --�[����ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_HASU_BK = :" & Ubound(strBindField) - 1 & " --�[����ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXTRK_BUF_NO_CONV) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTRK_BUF_NO_CONV = NULL --����Ԋ֘A�t��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTRK_BUF_NO_CONV = NULL --����Ԋ֘A�t��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_CONV
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTRK_BUF_NO_CONV = :" & Ubound(strBindField) - 1 & " --����Ԋ֘A�t��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTRK_BUF_NO_CONV = :" & Ubound(strBindField) - 1 & " --����Ԋ֘A�t��")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_IRI_YOUKYU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_IRI_YOUKYU = NULL --���I���ɗv���ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_IRI_YOUKYU = NULL --���I���ɗv���ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_IRI_YOUKYU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_IRI_YOUKYU = :" & Ubound(strBindField) - 1 & " --���I���ɗv���ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_IRI_YOUKYU = :" & Ubound(strBindField) - 1 & " --���I���ɗv���ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_OUT_YOUKYU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_OUT_YOUKYU = NULL --�o�ɗv���ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_OUT_YOUKYU = NULL --�o�ɗv���ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_OUT_YOUKYU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_OUT_YOUKYU = :" & Ubound(strBindField) - 1 & " --�o�ɗv���ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_OUT_YOUKYU = :" & Ubound(strBindField) - 1 & " --�o�ɗv���ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_OUT_BUF) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_OUT_BUF = NULL --�o�I�ޯ̧��ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_OUT_BUF = NULL --�o�I�ޯ̧��ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_OUT_BUF
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_OUT_BUF = :" & Ubound(strBindField) - 1 & " --�o�I�ޯ̧��ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_OUT_BUF = :" & Ubound(strBindField) - 1 & " --�o�I�ޯ̧��ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_OUT_END) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_OUT_END = NULL --�o�Ɋ����ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_OUT_END = NULL --�o�Ɋ����ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_OUT_END
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_OUT_END = :" & Ubound(strBindField) - 1 & " --�o�Ɋ����ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_OUT_END = :" & Ubound(strBindField) - 1 & " --�o�Ɋ����ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_B_HENSEI) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_B_HENSEI = NULL --�Ґ����\��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_B_HENSEI = NULL --�Ґ����\��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_HENSEI
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_B_HENSEI = :" & Ubound(strBindField) - 1 & " --�Ґ����\��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_B_HENSEI = :" & Ubound(strBindField) - 1 & " --�Ґ����\��")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_B_OUTEND) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_B_OUTEND = NULL --�o�Ɋ�������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_B_OUTEND = NULL --�o�Ɋ�������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_OUTEND
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_B_OUTEND = :" & Ubound(strBindField) - 1 & " --�o�Ɋ�������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_B_OUTEND = :" & Ubound(strBindField) - 1 & " --�o�Ɋ�������")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_B_TUMIEND) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_B_TUMIEND = NULL --�ύ���������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_B_TUMIEND = NULL --�ύ���������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_TUMIEND
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_B_TUMIEND = :" & Ubound(strBindField) - 1 & " --�ύ���������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_B_TUMIEND = :" & Ubound(strBindField) - 1 & " --�ύ���������")
        End If
        intCount = intCount + 1
        If IsNull(mXMAINTE_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XMAINTE_KUBUN = NULL --����ݽ�敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XMAINTE_KUBUN = NULL --����ݽ�敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAINTE_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XMAINTE_KUBUN = :" & Ubound(strBindField) - 1 & " --����ݽ�敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XMAINTE_KUBUN = :" & Ubound(strBindField) - 1 & " --����ݽ�敪")
        End If
        intCount = intCount + 1
        If IsNull(mXMAINTE_ORDER) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XMAINTE_ORDER = NULL --����ݽ�敪��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XMAINTE_ORDER = NULL --����ݽ�敪��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAINTE_ORDER
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XMAINTE_ORDER = :" & Ubound(strBindField) - 1 & " --����ݽ�敪��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XMAINTE_ORDER = :" & Ubound(strBindField) - 1 & " --����ݽ�敪��")
        End If
        intCount = intCount + 1
        If IsNull(mXMAINTE_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XMAINTE_NAME = NULL --����ݽ�\����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XMAINTE_NAME = NULL --����ݽ�\����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAINTE_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XMAINTE_NAME = :" & Ubound(strBindField) - 1 & " --����ݽ�\����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XMAINTE_NAME = :" & Ubound(strBindField) - 1 & " --����ݽ�\����")
        End If
        intCount = intCount + 1
        If IsNull(mXBUF_NAME_DTL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XBUF_NAME_DTL = NULL --�ׯ�ݸ��ޯ̧����(��������)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XBUF_NAME_DTL = NULL --�ׯ�ݸ��ޯ̧����(��������)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBUF_NAME_DTL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XBUF_NAME_DTL = :" & Ubound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧����(��������)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XBUF_NAME_DTL = :" & Ubound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧����(��������)")
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
    Public Sub ADD_TMST_TRK()
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
        ElseIf IsNull(mFBUF_NAME) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�ׯ�ݸ��ޯ̧����]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFBUF_KIND) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�ޯ̧���]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFNEW_IN_KUBUN) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�V�K�����ޯ̧�敪]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFBUF_MAX) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�ő��ޯ̧����]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFBUF_LOG_FLAG) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[۸ޗL���׸�]"
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
        strSQL.Append(vbCrLf & "    TMST_TRK")
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
        If IsNull(mFBUF_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ׯ�ݸ��ޯ̧����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ׯ�ݸ��ޯ̧����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧����")
        End If
        intCount = intCount + 1
        If IsNull(mFBUF_KIND) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ޯ̧���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ޯ̧���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_KIND
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ޯ̧���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ޯ̧���")
        End If
        intCount = intCount + 1
        If IsNull(mFNEW_IN_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�V�K�����ޯ̧�敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�V�K�����ޯ̧�敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFNEW_IN_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�V�K�����ޯ̧�敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�V�K�����ޯ̧�敪")
        End If
        intCount = intCount + 1
        If IsNull(mFBUF_MAX) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ő��ޯ̧����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ő��ޯ̧����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_MAX
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ő��ޯ̧����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ő��ޯ̧����")
        End If
        intCount = intCount + 1
        If IsNull(mFBUF_LOG_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --۸ޗL���׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --۸ޗL���׸�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_LOG_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --۸ޗL���׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --۸ޗL���׸�")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_RETU_MAX) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ő��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ő��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_RETU_MAX
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ő��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ő��")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_REN_MAX) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ő�A��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ő�A��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_REN_MAX
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ő�A��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ő�A��")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_DAN_MAX) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ő�i��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ő�i��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_DAN_MAX
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ő�i��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ő�i��")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_EDA_MAX) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ő�}��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ő�}��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_EDA_MAX
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ő�}��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ő�}��")
        End If
        intCount = intCount + 1
        If IsNull(mFPLACE_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ۊǏꏊ����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ۊǏꏊ����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLACE_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ۊǏꏊ����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ۊǏꏊ����")
        End If
        intCount = intCount + 1
        If IsNull(mFAREA_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ر����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ر����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFAREA_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ر����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ر����")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_MOD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --Ӱ�ސݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --Ӱ�ސݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_MOD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --Ӱ�ސݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --Ӱ�ސݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_STN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ST�ډאݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ST�ډאݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_STN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ST�ډאݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ST�ډאݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXTRK_BUF_NO_IN_HIRA) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���ɐݒ莞���u")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���ɐݒ莞���u")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_IN_HIRA
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���ɐݒ莞���u")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���ɐݒ莞���u")
        End If
        intCount = intCount + 1
        If IsNull(mXTRK_BUF_NO_OUT_HIRA) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�o�ɐݒ莞���u")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�o�ɐݒ莞���u")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_OUT_HIRA
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�o�ɐݒ莞���u")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�o�ɐݒ莞���u")
        End If
        intCount = intCount + 1
        If IsNull(mXADRS_IN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���Ɏw�����ڽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���Ɏw�����ڽ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_IN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���Ɏw�����ڽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���Ɏw�����ڽ")
        End If
        intCount = intCount + 1
        If IsNull(mXADRS_OUT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�o�Ɏw�����ڽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�o�Ɏw�����ڽ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_OUT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�o�Ɏw�����ڽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�o�Ɏw�����ڽ")
        End If
        intCount = intCount + 1
        If IsNull(mXADRS_HANSOU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�����w�����ڽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�����w�����ڽ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_HANSOU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�����w�����ڽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�����w�����ڽ")
        End If
        intCount = intCount + 1
        If IsNull(mXADRS_PLCTRK05) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --PLC�ׯ�ݸޱ��ڽ05")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --PLC�ׯ�ݸޱ��ڽ05")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PLCTRK05
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --PLC�ׯ�ݸޱ��ڽ05")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --PLC�ׯ�ݸޱ��ڽ05")
        End If
        intCount = intCount + 1
        If IsNull(mXADRS_PLCTRK04) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --PLC�ׯ�ݸޱ��ڽ04")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --PLC�ׯ�ݸޱ��ڽ04")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PLCTRK04
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --PLC�ׯ�ݸޱ��ڽ04")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --PLC�ׯ�ݸޱ��ڽ04")
        End If
        intCount = intCount + 1
        If IsNull(mXADRS_PALLET01) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --��گĐ����ڽ01")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --��گĐ����ڽ01")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PALLET01
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --��گĐ����ڽ01")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --��گĐ����ڽ01")
        End If
        intCount = intCount + 1
        If IsNull(mXADRS_PALLET02) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --��گĐ����ڽ02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --��گĐ����ڽ02")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PALLET02
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --��گĐ����ڽ02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --��گĐ����ڽ02")
        End If
        intCount = intCount + 1
        If IsNull(mXADRS_YOTEI01) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�\�萔���ڽ01")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�\�萔���ڽ01")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_YOTEI01
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�\�萔���ڽ01")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�\�萔���ڽ01")
        End If
        intCount = intCount + 1
        If IsNull(mXADRS_YOTEI02) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�\�萔���ڽ02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�\�萔���ڽ02")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_YOTEI02
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�\�萔���ڽ02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�\�萔���ڽ02")
        End If
        intCount = intCount + 1
        If IsNull(mXLS_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --L/S�ԍ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --L/S�ԍ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXLS_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --L/S�ԍ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --L/S�ԍ�")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_IN_FR) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���ɗv���O�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���ɗv���O�ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_IN_FR
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���ɗv���O�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���ɗv���O�ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_IN_BK) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���ɗv����ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���ɗv����ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_IN_BK
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���ɗv����ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���ɗv����ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_HASU_FR) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�[���O�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�[���O�ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_HASU_FR
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�[���O�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�[���O�ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_HASU_BK) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�[����ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�[����ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_HASU_BK
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�[����ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�[����ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXTRK_BUF_NO_CONV) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����Ԋ֘A�t��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����Ԋ֘A�t��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_CONV
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����Ԋ֘A�t��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����Ԋ֘A�t��")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_IRI_YOUKYU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���I���ɗv���ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���I���ɗv���ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_IRI_YOUKYU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���I���ɗv���ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���I���ɗv���ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_OUT_YOUKYU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�o�ɗv���ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�o�ɗv���ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_OUT_YOUKYU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�o�ɗv���ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�o�ɗv���ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_OUT_BUF) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�o�I�ޯ̧��ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�o�I�ޯ̧��ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_OUT_BUF
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�o�I�ޯ̧��ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�o�I�ޯ̧��ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_OUT_END) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�o�Ɋ����ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�o�Ɋ����ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_OUT_END
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�o�Ɋ����ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�o�Ɋ����ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_B_HENSEI) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�Ґ����\��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�Ґ����\��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_HENSEI
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�Ґ����\��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�Ґ����\��")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_B_OUTEND) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�o�Ɋ�������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�o�Ɋ�������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_OUTEND
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�o�Ɋ�������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�o�Ɋ�������")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_B_TUMIEND) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ύ���������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ύ���������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_TUMIEND
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ύ���������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ύ���������")
        End If
        intCount = intCount + 1
        If IsNull(mXMAINTE_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����ݽ�敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����ݽ�敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAINTE_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����ݽ�敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����ݽ�敪")
        End If
        intCount = intCount + 1
        If IsNull(mXMAINTE_ORDER) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����ݽ�敪��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����ݽ�敪��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAINTE_ORDER
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����ݽ�敪��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����ݽ�敪��")
        End If
        intCount = intCount + 1
        If IsNull(mXMAINTE_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����ݽ�\����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����ݽ�\����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAINTE_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����ݽ�\����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����ݽ�\����")
        End If
        intCount = intCount + 1
        If IsNull(mXBUF_NAME_DTL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ׯ�ݸ��ޯ̧����(��������)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ׯ�ݸ��ޯ̧����(��������)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBUF_NAME_DTL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧����(��������)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧����(��������)")
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
    Public Sub DELETE_TMST_TRK()
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
        strSQL.Append(vbCrLf & "    TMST_TRK")
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
    Public Sub DELETE_TMST_TRK_ANY()
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
        strSQL.Append(vbCrLf & "    TMST_TRK")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(FTRK_BUF_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧��")
        End If
        If IsNotNull(FBUF_NAME) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_NAME
            strSQL.Append(vbCrLf & "    AND FBUF_NAME = :" & UBound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧����")
        End If
        If IsNotNull(FBUF_KIND) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_KIND
            strSQL.Append(vbCrLf & "    AND FBUF_KIND = :" & UBound(strBindField) - 1 & " --�ޯ̧���")
        End If
        If IsNotNull(FNEW_IN_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFNEW_IN_KUBUN
            strSQL.Append(vbCrLf & "    AND FNEW_IN_KUBUN = :" & UBound(strBindField) - 1 & " --�V�K�����ޯ̧�敪")
        End If
        If IsNotNull(FBUF_MAX) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_MAX
            strSQL.Append(vbCrLf & "    AND FBUF_MAX = :" & UBound(strBindField) - 1 & " --�ő��ޯ̧����")
        End If
        If IsNotNull(FBUF_LOG_FLAG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_LOG_FLAG
            strSQL.Append(vbCrLf & "    AND FBUF_LOG_FLAG = :" & UBound(strBindField) - 1 & " --۸ޗL���׸�")
        End If
        If IsNotNull(FRAC_RETU_MAX) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_RETU_MAX
            strSQL.Append(vbCrLf & "    AND FRAC_RETU_MAX = :" & UBound(strBindField) - 1 & " --�ő��")
        End If
        If IsNotNull(FRAC_REN_MAX) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_REN_MAX
            strSQL.Append(vbCrLf & "    AND FRAC_REN_MAX = :" & UBound(strBindField) - 1 & " --�ő�A��")
        End If
        If IsNotNull(FRAC_DAN_MAX) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_DAN_MAX
            strSQL.Append(vbCrLf & "    AND FRAC_DAN_MAX = :" & UBound(strBindField) - 1 & " --�ő�i��")
        End If
        If IsNotNull(FRAC_EDA_MAX) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_EDA_MAX
            strSQL.Append(vbCrLf & "    AND FRAC_EDA_MAX = :" & UBound(strBindField) - 1 & " --�ő�}��")
        End If
        If IsNotNull(FPLACE_CD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLACE_CD
            strSQL.Append(vbCrLf & "    AND FPLACE_CD = :" & UBound(strBindField) - 1 & " --�ۊǏꏊ����")
        End If
        If IsNotNull(FAREA_CD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFAREA_CD
            strSQL.Append(vbCrLf & "    AND FAREA_CD = :" & UBound(strBindField) - 1 & " --�ر����")
        End If
        If IsNotNull(XEQ_ID_MOD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_MOD
            strSQL.Append(vbCrLf & "    AND XEQ_ID_MOD = :" & UBound(strBindField) - 1 & " --Ӱ�ސݔ�ID")
        End If
        If IsNotNull(XEQ_ID_STN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_STN
            strSQL.Append(vbCrLf & "    AND XEQ_ID_STN = :" & UBound(strBindField) - 1 & " --ST�ډאݔ�ID")
        End If
        If IsNotNull(XTRK_BUF_NO_IN_HIRA) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_IN_HIRA
            strSQL.Append(vbCrLf & "    AND XTRK_BUF_NO_IN_HIRA = :" & UBound(strBindField) - 1 & " --���ɐݒ莞���u")
        End If
        If IsNotNull(XTRK_BUF_NO_OUT_HIRA) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_OUT_HIRA
            strSQL.Append(vbCrLf & "    AND XTRK_BUF_NO_OUT_HIRA = :" & UBound(strBindField) - 1 & " --�o�ɐݒ莞���u")
        End If
        If IsNotNull(XADRS_IN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_IN
            strSQL.Append(vbCrLf & "    AND XADRS_IN = :" & UBound(strBindField) - 1 & " --���Ɏw�����ڽ")
        End If
        If IsNotNull(XADRS_OUT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_OUT
            strSQL.Append(vbCrLf & "    AND XADRS_OUT = :" & UBound(strBindField) - 1 & " --�o�Ɏw�����ڽ")
        End If
        If IsNotNull(XADRS_HANSOU) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_HANSOU
            strSQL.Append(vbCrLf & "    AND XADRS_HANSOU = :" & UBound(strBindField) - 1 & " --�����w�����ڽ")
        End If
        If IsNotNull(XADRS_PLCTRK05) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PLCTRK05
            strSQL.Append(vbCrLf & "    AND XADRS_PLCTRK05 = :" & UBound(strBindField) - 1 & " --PLC�ׯ�ݸޱ��ڽ05")
        End If
        If IsNotNull(XADRS_PLCTRK04) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PLCTRK04
            strSQL.Append(vbCrLf & "    AND XADRS_PLCTRK04 = :" & UBound(strBindField) - 1 & " --PLC�ׯ�ݸޱ��ڽ04")
        End If
        If IsNotNull(XADRS_PALLET01) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PALLET01
            strSQL.Append(vbCrLf & "    AND XADRS_PALLET01 = :" & UBound(strBindField) - 1 & " --��گĐ����ڽ01")
        End If
        If IsNotNull(XADRS_PALLET02) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PALLET02
            strSQL.Append(vbCrLf & "    AND XADRS_PALLET02 = :" & UBound(strBindField) - 1 & " --��گĐ����ڽ02")
        End If
        If IsNotNull(XADRS_YOTEI01) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_YOTEI01
            strSQL.Append(vbCrLf & "    AND XADRS_YOTEI01 = :" & UBound(strBindField) - 1 & " --�\�萔���ڽ01")
        End If
        If IsNotNull(XADRS_YOTEI02) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_YOTEI02
            strSQL.Append(vbCrLf & "    AND XADRS_YOTEI02 = :" & UBound(strBindField) - 1 & " --�\�萔���ڽ02")
        End If
        If IsNotNull(XLS_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXLS_NO
            strSQL.Append(vbCrLf & "    AND XLS_NO = :" & UBound(strBindField) - 1 & " --L/S�ԍ�")
        End If
        If IsNotNull(XEQ_ID_IN_FR) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_IN_FR
            strSQL.Append(vbCrLf & "    AND XEQ_ID_IN_FR = :" & UBound(strBindField) - 1 & " --���ɗv���O�ݔ�ID")
        End If
        If IsNotNull(XEQ_ID_IN_BK) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_IN_BK
            strSQL.Append(vbCrLf & "    AND XEQ_ID_IN_BK = :" & UBound(strBindField) - 1 & " --���ɗv����ݔ�ID")
        End If
        If IsNotNull(XEQ_ID_HASU_FR) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_HASU_FR
            strSQL.Append(vbCrLf & "    AND XEQ_ID_HASU_FR = :" & UBound(strBindField) - 1 & " --�[���O�ݔ�ID")
        End If
        If IsNotNull(XEQ_ID_HASU_BK) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_HASU_BK
            strSQL.Append(vbCrLf & "    AND XEQ_ID_HASU_BK = :" & UBound(strBindField) - 1 & " --�[����ݔ�ID")
        End If
        If IsNotNull(XTRK_BUF_NO_CONV) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_CONV
            strSQL.Append(vbCrLf & "    AND XTRK_BUF_NO_CONV = :" & UBound(strBindField) - 1 & " --����Ԋ֘A�t��")
        End If
        If IsNotNull(XEQ_ID_IRI_YOUKYU) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_IRI_YOUKYU
            strSQL.Append(vbCrLf & "    AND XEQ_ID_IRI_YOUKYU = :" & UBound(strBindField) - 1 & " --���I���ɗv���ݔ�ID")
        End If
        If IsNotNull(XEQ_ID_OUT_YOUKYU) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_OUT_YOUKYU
            strSQL.Append(vbCrLf & "    AND XEQ_ID_OUT_YOUKYU = :" & UBound(strBindField) - 1 & " --�o�ɗv���ݔ�ID")
        End If
        If IsNotNull(XEQ_ID_OUT_BUF) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_OUT_BUF
            strSQL.Append(vbCrLf & "    AND XEQ_ID_OUT_BUF = :" & UBound(strBindField) - 1 & " --�o�I�ޯ̧��ݔ�ID")
        End If
        If IsNotNull(XEQ_ID_OUT_END) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_OUT_END
            strSQL.Append(vbCrLf & "    AND XEQ_ID_OUT_END = :" & UBound(strBindField) - 1 & " --�o�Ɋ����ݔ�ID")
        End If
        If IsNotNull(XEQ_ID_B_HENSEI) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_HENSEI
            strSQL.Append(vbCrLf & "    AND XEQ_ID_B_HENSEI = :" & UBound(strBindField) - 1 & " --�Ґ����\��")
        End If
        If IsNotNull(XEQ_ID_B_OUTEND) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_OUTEND
            strSQL.Append(vbCrLf & "    AND XEQ_ID_B_OUTEND = :" & UBound(strBindField) - 1 & " --�o�Ɋ�������")
        End If
        If IsNotNull(XEQ_ID_B_TUMIEND) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_TUMIEND
            strSQL.Append(vbCrLf & "    AND XEQ_ID_B_TUMIEND = :" & UBound(strBindField) - 1 & " --�ύ���������")
        End If
        If IsNotNull(XMAINTE_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAINTE_KUBUN
            strSQL.Append(vbCrLf & "    AND XMAINTE_KUBUN = :" & UBound(strBindField) - 1 & " --����ݽ�敪")
        End If
        If IsNotNull(XMAINTE_ORDER) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAINTE_ORDER
            strSQL.Append(vbCrLf & "    AND XMAINTE_ORDER = :" & UBound(strBindField) - 1 & " --����ݽ�敪��")
        End If
        If IsNotNull(XMAINTE_NAME) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAINTE_NAME
            strSQL.Append(vbCrLf & "    AND XMAINTE_NAME = :" & UBound(strBindField) - 1 & " --����ݽ�\����")
        End If
        If IsNotNull(XBUF_NAME_DTL) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBUF_NAME_DTL
            strSQL.Append(vbCrLf & "    AND XBUF_NAME_DTL = :" & UBound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧����(��������)")
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
        If IsNothing(objType.GetProperty("FBUF_NAME")) = False Then mFBUF_NAME = objObject.FBUF_NAME '�ׯ�ݸ��ޯ̧����
        If IsNothing(objType.GetProperty("FBUF_KIND")) = False Then mFBUF_KIND = objObject.FBUF_KIND '�ޯ̧���
        If IsNothing(objType.GetProperty("FNEW_IN_KUBUN")) = False Then mFNEW_IN_KUBUN = objObject.FNEW_IN_KUBUN '�V�K�����ޯ̧�敪
        If IsNothing(objType.GetProperty("FBUF_MAX")) = False Then mFBUF_MAX = objObject.FBUF_MAX '�ő��ޯ̧����
        If IsNothing(objType.GetProperty("FBUF_LOG_FLAG")) = False Then mFBUF_LOG_FLAG = objObject.FBUF_LOG_FLAG '۸ޗL���׸�
        If IsNothing(objType.GetProperty("FRAC_RETU_MAX")) = False Then mFRAC_RETU_MAX = objObject.FRAC_RETU_MAX '�ő��
        If IsNothing(objType.GetProperty("FRAC_REN_MAX")) = False Then mFRAC_REN_MAX = objObject.FRAC_REN_MAX '�ő�A��
        If IsNothing(objType.GetProperty("FRAC_DAN_MAX")) = False Then mFRAC_DAN_MAX = objObject.FRAC_DAN_MAX '�ő�i��
        If IsNothing(objType.GetProperty("FRAC_EDA_MAX")) = False Then mFRAC_EDA_MAX = objObject.FRAC_EDA_MAX '�ő�}��
        If IsNothing(objType.GetProperty("FPLACE_CD")) = False Then mFPLACE_CD = objObject.FPLACE_CD '�ۊǏꏊ����
        If IsNothing(objType.GetProperty("FAREA_CD")) = False Then mFAREA_CD = objObject.FAREA_CD '�ر����
        If IsNothing(objType.GetProperty("XEQ_ID_MOD")) = False Then mXEQ_ID_MOD = objObject.XEQ_ID_MOD 'Ӱ�ސݔ�ID
        If IsNothing(objType.GetProperty("XEQ_ID_STN")) = False Then mXEQ_ID_STN = objObject.XEQ_ID_STN 'ST�ډאݔ�ID
        If IsNothing(objType.GetProperty("XTRK_BUF_NO_IN_HIRA")) = False Then mXTRK_BUF_NO_IN_HIRA = objObject.XTRK_BUF_NO_IN_HIRA '���ɐݒ莞���u
        If IsNothing(objType.GetProperty("XTRK_BUF_NO_OUT_HIRA")) = False Then mXTRK_BUF_NO_OUT_HIRA = objObject.XTRK_BUF_NO_OUT_HIRA '�o�ɐݒ莞���u
        If IsNothing(objType.GetProperty("XADRS_IN")) = False Then mXADRS_IN = objObject.XADRS_IN '���Ɏw�����ڽ
        If IsNothing(objType.GetProperty("XADRS_OUT")) = False Then mXADRS_OUT = objObject.XADRS_OUT '�o�Ɏw�����ڽ
        If IsNothing(objType.GetProperty("XADRS_HANSOU")) = False Then mXADRS_HANSOU = objObject.XADRS_HANSOU '�����w�����ڽ
        If IsNothing(objType.GetProperty("XADRS_PLCTRK05")) = False Then mXADRS_PLCTRK05 = objObject.XADRS_PLCTRK05 'PLC�ׯ�ݸޱ��ڽ05
        If IsNothing(objType.GetProperty("XADRS_PLCTRK04")) = False Then mXADRS_PLCTRK04 = objObject.XADRS_PLCTRK04 'PLC�ׯ�ݸޱ��ڽ04
        If IsNothing(objType.GetProperty("XADRS_PALLET01")) = False Then mXADRS_PALLET01 = objObject.XADRS_PALLET01 '��گĐ����ڽ01
        If IsNothing(objType.GetProperty("XADRS_PALLET02")) = False Then mXADRS_PALLET02 = objObject.XADRS_PALLET02 '��گĐ����ڽ02
        If IsNothing(objType.GetProperty("XADRS_YOTEI01")) = False Then mXADRS_YOTEI01 = objObject.XADRS_YOTEI01 '�\�萔���ڽ01
        If IsNothing(objType.GetProperty("XADRS_YOTEI02")) = False Then mXADRS_YOTEI02 = objObject.XADRS_YOTEI02 '�\�萔���ڽ02
        If IsNothing(objType.GetProperty("XLS_NO")) = False Then mXLS_NO = objObject.XLS_NO 'L/S�ԍ�
        If IsNothing(objType.GetProperty("XEQ_ID_IN_FR")) = False Then mXEQ_ID_IN_FR = objObject.XEQ_ID_IN_FR '���ɗv���O�ݔ�ID
        If IsNothing(objType.GetProperty("XEQ_ID_IN_BK")) = False Then mXEQ_ID_IN_BK = objObject.XEQ_ID_IN_BK '���ɗv����ݔ�ID
        If IsNothing(objType.GetProperty("XEQ_ID_HASU_FR")) = False Then mXEQ_ID_HASU_FR = objObject.XEQ_ID_HASU_FR '�[���O�ݔ�ID
        If IsNothing(objType.GetProperty("XEQ_ID_HASU_BK")) = False Then mXEQ_ID_HASU_BK = objObject.XEQ_ID_HASU_BK '�[����ݔ�ID
        If IsNothing(objType.GetProperty("XTRK_BUF_NO_CONV")) = False Then mXTRK_BUF_NO_CONV = objObject.XTRK_BUF_NO_CONV '����Ԋ֘A�t��
        If IsNothing(objType.GetProperty("XEQ_ID_IRI_YOUKYU")) = False Then mXEQ_ID_IRI_YOUKYU = objObject.XEQ_ID_IRI_YOUKYU '���I���ɗv���ݔ�ID
        If IsNothing(objType.GetProperty("XEQ_ID_OUT_YOUKYU")) = False Then mXEQ_ID_OUT_YOUKYU = objObject.XEQ_ID_OUT_YOUKYU '�o�ɗv���ݔ�ID
        If IsNothing(objType.GetProperty("XEQ_ID_OUT_BUF")) = False Then mXEQ_ID_OUT_BUF = objObject.XEQ_ID_OUT_BUF '�o�I�ޯ̧��ݔ�ID
        If IsNothing(objType.GetProperty("XEQ_ID_OUT_END")) = False Then mXEQ_ID_OUT_END = objObject.XEQ_ID_OUT_END '�o�Ɋ����ݔ�ID
        If IsNothing(objType.GetProperty("XEQ_ID_B_HENSEI")) = False Then mXEQ_ID_B_HENSEI = objObject.XEQ_ID_B_HENSEI '�Ґ����\��
        If IsNothing(objType.GetProperty("XEQ_ID_B_OUTEND")) = False Then mXEQ_ID_B_OUTEND = objObject.XEQ_ID_B_OUTEND '�o�Ɋ�������
        If IsNothing(objType.GetProperty("XEQ_ID_B_TUMIEND")) = False Then mXEQ_ID_B_TUMIEND = objObject.XEQ_ID_B_TUMIEND '�ύ���������
        If IsNothing(objType.GetProperty("XMAINTE_KUBUN")) = False Then mXMAINTE_KUBUN = objObject.XMAINTE_KUBUN '����ݽ�敪
        If IsNothing(objType.GetProperty("XMAINTE_ORDER")) = False Then mXMAINTE_ORDER = objObject.XMAINTE_ORDER '����ݽ�敪��
        If IsNothing(objType.GetProperty("XMAINTE_NAME")) = False Then mXMAINTE_NAME = objObject.XMAINTE_NAME '����ݽ�\����
        If IsNothing(objType.GetProperty("XBUF_NAME_DTL")) = False Then mXBUF_NAME_DTL = objObject.XBUF_NAME_DTL '�ׯ�ݸ��ޯ̧����(��������)

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
        mFBUF_NAME = Nothing
        mFBUF_KIND = Nothing
        mFNEW_IN_KUBUN = Nothing
        mFBUF_MAX = Nothing
        mFBUF_LOG_FLAG = Nothing
        mFRAC_RETU_MAX = Nothing
        mFRAC_REN_MAX = Nothing
        mFRAC_DAN_MAX = Nothing
        mFRAC_EDA_MAX = Nothing
        mFPLACE_CD = Nothing
        mFAREA_CD = Nothing
        mXEQ_ID_MOD = Nothing
        mXEQ_ID_STN = Nothing
        mXTRK_BUF_NO_IN_HIRA = Nothing
        mXTRK_BUF_NO_OUT_HIRA = Nothing
        mXADRS_IN = Nothing
        mXADRS_OUT = Nothing
        mXADRS_HANSOU = Nothing
        mXADRS_PLCTRK05 = Nothing
        mXADRS_PLCTRK04 = Nothing
        mXADRS_PALLET01 = Nothing
        mXADRS_PALLET02 = Nothing
        mXADRS_YOTEI01 = Nothing
        mXADRS_YOTEI02 = Nothing
        mXLS_NO = Nothing
        mXEQ_ID_IN_FR = Nothing
        mXEQ_ID_IN_BK = Nothing
        mXEQ_ID_HASU_FR = Nothing
        mXEQ_ID_HASU_BK = Nothing
        mXTRK_BUF_NO_CONV = Nothing
        mXEQ_ID_IRI_YOUKYU = Nothing
        mXEQ_ID_OUT_YOUKYU = Nothing
        mXEQ_ID_OUT_BUF = Nothing
        mXEQ_ID_OUT_END = Nothing
        mXEQ_ID_B_HENSEI = Nothing
        mXEQ_ID_B_OUTEND = Nothing
        mXEQ_ID_B_TUMIEND = Nothing
        mXMAINTE_KUBUN = Nothing
        mXMAINTE_ORDER = Nothing
        mXMAINTE_NAME = Nothing
        mXBUF_NAME_DTL = Nothing


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
        mFBUF_NAME = TO_STRING_NULLABLE(objRow("FBUF_NAME"))
        mFBUF_KIND = TO_INTEGER_NULLABLE(objRow("FBUF_KIND"))
        mFNEW_IN_KUBUN = TO_INTEGER_NULLABLE(objRow("FNEW_IN_KUBUN"))
        mFBUF_MAX = TO_INTEGER_NULLABLE(objRow("FBUF_MAX"))
        mFBUF_LOG_FLAG = TO_INTEGER_NULLABLE(objRow("FBUF_LOG_FLAG"))
        mFRAC_RETU_MAX = TO_INTEGER_NULLABLE(objRow("FRAC_RETU_MAX"))
        mFRAC_REN_MAX = TO_INTEGER_NULLABLE(objRow("FRAC_REN_MAX"))
        mFRAC_DAN_MAX = TO_INTEGER_NULLABLE(objRow("FRAC_DAN_MAX"))
        mFRAC_EDA_MAX = TO_INTEGER_NULLABLE(objRow("FRAC_EDA_MAX"))
        mFPLACE_CD = TO_INTEGER_NULLABLE(objRow("FPLACE_CD"))
        mFAREA_CD = TO_INTEGER_NULLABLE(objRow("FAREA_CD"))
        mXEQ_ID_MOD = TO_STRING_NULLABLE(objRow("XEQ_ID_MOD"))
        mXEQ_ID_STN = TO_STRING_NULLABLE(objRow("XEQ_ID_STN"))
        mXTRK_BUF_NO_IN_HIRA = TO_INTEGER_NULLABLE(objRow("XTRK_BUF_NO_IN_HIRA"))
        mXTRK_BUF_NO_OUT_HIRA = TO_INTEGER_NULLABLE(objRow("XTRK_BUF_NO_OUT_HIRA"))
        mXADRS_IN = TO_STRING_NULLABLE(objRow("XADRS_IN"))
        mXADRS_OUT = TO_STRING_NULLABLE(objRow("XADRS_OUT"))
        mXADRS_HANSOU = TO_STRING_NULLABLE(objRow("XADRS_HANSOU"))
        mXADRS_PLCTRK05 = TO_STRING_NULLABLE(objRow("XADRS_PLCTRK05"))
        mXADRS_PLCTRK04 = TO_STRING_NULLABLE(objRow("XADRS_PLCTRK04"))
        mXADRS_PALLET01 = TO_STRING_NULLABLE(objRow("XADRS_PALLET01"))
        mXADRS_PALLET02 = TO_STRING_NULLABLE(objRow("XADRS_PALLET02"))
        mXADRS_YOTEI01 = TO_STRING_NULLABLE(objRow("XADRS_YOTEI01"))
        mXADRS_YOTEI02 = TO_STRING_NULLABLE(objRow("XADRS_YOTEI02"))
        mXLS_NO = TO_INTEGER_NULLABLE(objRow("XLS_NO"))
        mXEQ_ID_IN_FR = TO_STRING_NULLABLE(objRow("XEQ_ID_IN_FR"))
        mXEQ_ID_IN_BK = TO_STRING_NULLABLE(objRow("XEQ_ID_IN_BK"))
        mXEQ_ID_HASU_FR = TO_STRING_NULLABLE(objRow("XEQ_ID_HASU_FR"))
        mXEQ_ID_HASU_BK = TO_STRING_NULLABLE(objRow("XEQ_ID_HASU_BK"))
        mXTRK_BUF_NO_CONV = TO_INTEGER_NULLABLE(objRow("XTRK_BUF_NO_CONV"))
        mXEQ_ID_IRI_YOUKYU = TO_STRING_NULLABLE(objRow("XEQ_ID_IRI_YOUKYU"))
        mXEQ_ID_OUT_YOUKYU = TO_STRING_NULLABLE(objRow("XEQ_ID_OUT_YOUKYU"))
        mXEQ_ID_OUT_BUF = TO_STRING_NULLABLE(objRow("XEQ_ID_OUT_BUF"))
        mXEQ_ID_OUT_END = TO_STRING_NULLABLE(objRow("XEQ_ID_OUT_END"))
        mXEQ_ID_B_HENSEI = TO_STRING_NULLABLE(objRow("XEQ_ID_B_HENSEI"))
        mXEQ_ID_B_OUTEND = TO_STRING_NULLABLE(objRow("XEQ_ID_B_OUTEND"))
        mXEQ_ID_B_TUMIEND = TO_STRING_NULLABLE(objRow("XEQ_ID_B_TUMIEND"))
        mXMAINTE_KUBUN = TO_INTEGER_NULLABLE(objRow("XMAINTE_KUBUN"))
        mXMAINTE_ORDER = TO_INTEGER_NULLABLE(objRow("XMAINTE_ORDER"))
        mXMAINTE_NAME = TO_STRING_NULLABLE(objRow("XMAINTE_NAME"))
        mXBUF_NAME_DTL = TO_STRING_NULLABLE(objRow("XBUF_NAME_DTL"))


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
        strMsg &= "[ð��ٖ�:�ׯ�ݸ��ޯ̧Ͻ�]"
        If IsNotNull(FTRK_BUF_NO) Then
            strMsg &= "[�ׯ�ݸ��ޯ̧��:" & FTRK_BUF_NO & "]"
        End If
        If IsNotNull(FBUF_NAME) Then
            strMsg &= "[�ׯ�ݸ��ޯ̧����:" & FBUF_NAME & "]"
        End If
        If IsNotNull(FBUF_KIND) Then
            strMsg &= "[�ޯ̧���:" & FBUF_KIND & "]"
        End If
        If IsNotNull(FNEW_IN_KUBUN) Then
            strMsg &= "[�V�K�����ޯ̧�敪:" & FNEW_IN_KUBUN & "]"
        End If
        If IsNotNull(FBUF_MAX) Then
            strMsg &= "[�ő��ޯ̧����:" & FBUF_MAX & "]"
        End If
        If IsNotNull(FBUF_LOG_FLAG) Then
            strMsg &= "[۸ޗL���׸�:" & FBUF_LOG_FLAG & "]"
        End If
        If IsNotNull(FRAC_RETU_MAX) Then
            strMsg &= "[�ő��:" & FRAC_RETU_MAX & "]"
        End If
        If IsNotNull(FRAC_REN_MAX) Then
            strMsg &= "[�ő�A��:" & FRAC_REN_MAX & "]"
        End If
        If IsNotNull(FRAC_DAN_MAX) Then
            strMsg &= "[�ő�i��:" & FRAC_DAN_MAX & "]"
        End If
        If IsNotNull(FRAC_EDA_MAX) Then
            strMsg &= "[�ő�}��:" & FRAC_EDA_MAX & "]"
        End If
        If IsNotNull(FPLACE_CD) Then
            strMsg &= "[�ۊǏꏊ����:" & FPLACE_CD & "]"
        End If
        If IsNotNull(FAREA_CD) Then
            strMsg &= "[�ر����:" & FAREA_CD & "]"
        End If
        If IsNotNull(XEQ_ID_MOD) Then
            strMsg &= "[Ӱ�ސݔ�ID:" & XEQ_ID_MOD & "]"
        End If
        If IsNotNull(XEQ_ID_STN) Then
            strMsg &= "[ST�ډאݔ�ID:" & XEQ_ID_STN & "]"
        End If
        If IsNotNull(XTRK_BUF_NO_IN_HIRA) Then
            strMsg &= "[���ɐݒ莞���u:" & XTRK_BUF_NO_IN_HIRA & "]"
        End If
        If IsNotNull(XTRK_BUF_NO_OUT_HIRA) Then
            strMsg &= "[�o�ɐݒ莞���u:" & XTRK_BUF_NO_OUT_HIRA & "]"
        End If
        If IsNotNull(XADRS_IN) Then
            strMsg &= "[���Ɏw�����ڽ:" & XADRS_IN & "]"
        End If
        If IsNotNull(XADRS_OUT) Then
            strMsg &= "[�o�Ɏw�����ڽ:" & XADRS_OUT & "]"
        End If
        If IsNotNull(XADRS_HANSOU) Then
            strMsg &= "[�����w�����ڽ:" & XADRS_HANSOU & "]"
        End If
        If IsNotNull(XADRS_PLCTRK05) Then
            strMsg &= "[PLC�ׯ�ݸޱ��ڽ05:" & XADRS_PLCTRK05 & "]"
        End If
        If IsNotNull(XADRS_PLCTRK04) Then
            strMsg &= "[PLC�ׯ�ݸޱ��ڽ04:" & XADRS_PLCTRK04 & "]"
        End If
        If IsNotNull(XADRS_PALLET01) Then
            strMsg &= "[��گĐ����ڽ01:" & XADRS_PALLET01 & "]"
        End If
        If IsNotNull(XADRS_PALLET02) Then
            strMsg &= "[��گĐ����ڽ02:" & XADRS_PALLET02 & "]"
        End If
        If IsNotNull(XADRS_YOTEI01) Then
            strMsg &= "[�\�萔���ڽ01:" & XADRS_YOTEI01 & "]"
        End If
        If IsNotNull(XADRS_YOTEI02) Then
            strMsg &= "[�\�萔���ڽ02:" & XADRS_YOTEI02 & "]"
        End If
        If IsNotNull(XLS_NO) Then
            strMsg &= "[L/S�ԍ�:" & XLS_NO & "]"
        End If
        If IsNotNull(XEQ_ID_IN_FR) Then
            strMsg &= "[���ɗv���O�ݔ�ID:" & XEQ_ID_IN_FR & "]"
        End If
        If IsNotNull(XEQ_ID_IN_BK) Then
            strMsg &= "[���ɗv����ݔ�ID:" & XEQ_ID_IN_BK & "]"
        End If
        If IsNotNull(XEQ_ID_HASU_FR) Then
            strMsg &= "[�[���O�ݔ�ID:" & XEQ_ID_HASU_FR & "]"
        End If
        If IsNotNull(XEQ_ID_HASU_BK) Then
            strMsg &= "[�[����ݔ�ID:" & XEQ_ID_HASU_BK & "]"
        End If
        If IsNotNull(XTRK_BUF_NO_CONV) Then
            strMsg &= "[����Ԋ֘A�t��:" & XTRK_BUF_NO_CONV & "]"
        End If
        If IsNotNull(XEQ_ID_IRI_YOUKYU) Then
            strMsg &= "[���I���ɗv���ݔ�ID:" & XEQ_ID_IRI_YOUKYU & "]"
        End If
        If IsNotNull(XEQ_ID_OUT_YOUKYU) Then
            strMsg &= "[�o�ɗv���ݔ�ID:" & XEQ_ID_OUT_YOUKYU & "]"
        End If
        If IsNotNull(XEQ_ID_OUT_BUF) Then
            strMsg &= "[�o�I�ޯ̧��ݔ�ID:" & XEQ_ID_OUT_BUF & "]"
        End If
        If IsNotNull(XEQ_ID_OUT_END) Then
            strMsg &= "[�o�Ɋ����ݔ�ID:" & XEQ_ID_OUT_END & "]"
        End If
        If IsNotNull(XEQ_ID_B_HENSEI) Then
            strMsg &= "[�Ґ����\��:" & XEQ_ID_B_HENSEI & "]"
        End If
        If IsNotNull(XEQ_ID_B_OUTEND) Then
            strMsg &= "[�o�Ɋ�������:" & XEQ_ID_B_OUTEND & "]"
        End If
        If IsNotNull(XEQ_ID_B_TUMIEND) Then
            strMsg &= "[�ύ���������:" & XEQ_ID_B_TUMIEND & "]"
        End If
        If IsNotNull(XMAINTE_KUBUN) Then
            strMsg &= "[����ݽ�敪:" & XMAINTE_KUBUN & "]"
        End If
        If IsNotNull(XMAINTE_ORDER) Then
            strMsg &= "[����ݽ�敪��:" & XMAINTE_ORDER & "]"
        End If
        If IsNotNull(XMAINTE_NAME) Then
            strMsg &= "[����ݽ�\����:" & XMAINTE_NAME & "]"
        End If
        If IsNotNull(XBUF_NAME_DTL) Then
            strMsg &= "[�ׯ�ݸ��ޯ̧����(��������):" & XBUF_NAME_DTL & "]"
        End If


    End Sub
#End Region
    '����������������
    '**********************************************************************************************

    '**********************************************************************************************
    '���������ы���
#Region "  �ް��擾(�ۊǏꏊ����&�ر)   (Public  GET_TMST_TRK_FPLACE_AREA)"
    Public Function GET_TMST_TRK_FPLACE_AREA() As RetCode
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
            ElseIf IsNull(mFPLACE_CD) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�ۊǏꏊ����]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFAREA_CD) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�ر]"
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
            strSQL.Append(vbCrLf & "    TMST_TRK")
            strSQL.Append(vbCrLf & " WHERE")
            strSQL.Append(vbCrLf & "        1 = 1")
            If IsNull(FPLACE_CD) = True Then
                strSQL.Append(vbCrLf & "    AND FPLACE_CD IS NULL --�ۊǏꏊ����")
            Else
                ReDim Preserve strBindField(UBound(strBindField) + 1)
                ReDim Preserve objBindValue(UBound(objBindValue) + 1)
                strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
                objBindValue(UBound(objBindValue)) = mFPLACE_CD
                strSQL.Append(vbCrLf & "    AND FPLACE_CD = :" & UBound(strBindField) - 1 & " --�ۊǏꏊ����")
            End If
            If IsNull(FAREA_CD) = True Then
                strSQL.Append(vbCrLf & "    AND FAREA_CD IS NULL --�ر")
            Else
                ReDim Preserve strBindField(UBound(strBindField) + 1)
                ReDim Preserve objBindValue(UBound(objBindValue) + 1)
                strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
                objBindValue(UBound(objBindValue)) = mFAREA_CD
                strSQL.Append(vbCrLf & "    AND FAREA_CD = :" & UBound(strBindField) - 1 & " --�ر")
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
            '���o
            '***********************
            ObjDb.SQL = strSQL.ToString
            ObjDb.Parameter = objParameter
            objDataSet.Clear()
            strDataSetName = "TMST_TRK"
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
    '���������ы���
    '**********************************************************************************************


    '**********************************************************************************************
    '���������ьŗL
#Region "  �ް��擾(�ۊǏꏊ����)       (Public  GET_TMST_TRK_FPLACE)"
    Public Function GET_TMST_TRK_FPLACE() As RetCode
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
            ElseIf IsNull(mFPLACE_CD) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�ۊǏꏊ����]"
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
            strSQL.Append(vbCrLf & "    TMST_TRK")
            strSQL.Append(vbCrLf & " WHERE")
            strSQL.Append(vbCrLf & "        1 = 1")
            If IsNull(FPLACE_CD) = True Then
                strSQL.Append(vbCrLf & "    AND FPLACE_CD IS NULL --�ۊǏꏊ����")
            Else
                ReDim Preserve strBindField(UBound(strBindField) + 1)
                ReDim Preserve objBindValue(UBound(objBindValue) + 1)
                strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
                objBindValue(UBound(objBindValue)) = mFPLACE_CD
                strSQL.Append(vbCrLf & "    AND FPLACE_CD = :" & UBound(strBindField) - 1 & " --�ۊǏꏊ����")
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
            '���o
            '***********************
            ObjDb.SQL = strSQL.ToString
            ObjDb.Parameter = objParameter
            objDataSet.Clear()
            strDataSetName = "TMST_TRK"
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
#Region "  �ް��擾(�ۊǏꏊ����(�I�̂�))       (Public  GET_TMST_TRK_FPLACE_RAC)"
    Public Function GET_TMST_TRK_FPLACE_RAC() As RetCode
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
            ElseIf IsNull(mFPLACE_CD) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�ۊǏꏊ����]"
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
            strSQL.Append(vbCrLf & "    TMST_TRK")
            strSQL.Append(vbCrLf & " WHERE")
            strSQL.Append(vbCrLf & "        1 = 1")
            strSQL.Append(vbCrLf & "        AND FBUF_KIND = " & TO_STRING(FBUF_KIND_SASRS))
            If IsNull(FPLACE_CD) = True Then
                strSQL.Append(vbCrLf & "    AND FPLACE_CD IS NULL --�ۊǏꏊ����")
            Else
                ReDim Preserve strBindField(UBound(strBindField) + 1)
                ReDim Preserve objBindValue(UBound(objBindValue) + 1)
                strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
                objBindValue(UBound(objBindValue)) = mFPLACE_CD
                strSQL.Append(vbCrLf & "    AND FPLACE_CD = :" & UBound(strBindField) - 1 & " --�ۊǏꏊ����")
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
            '���o
            '***********************
            ObjDb.SQL = strSQL.ToString
            ObjDb.Parameter = objParameter
            objDataSet.Clear()
            strDataSetName = "TMST_TRK"
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

#Region "  �ް����ϐ�                   "
    '''**********************************************************************************************
    ''' <summary>
    ''' �ް����ϐ�
    ''' </summary>
    ''' <param name="objRow">�ް�ں��޵�޼ު��</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub SET_DATA_PLC(ByVal objRow As DataRow)


        '***********************
        '�ް����
        '***********************
        mFTRK_BUF_NO = TO_INTEGER_NULLABLE(objRow("FTRK_BUF_NO"))
        mXADRS_IN = TO_STRING_NULLABLE(objRow("XADRS_IN"))
        mXADRS_OUT = TO_STRING_NULLABLE(objRow("XADRS_OUT"))
        mXMAINTE_KUBUN = TO_INTEGER_NULLABLE(objRow("XMAINTE_KUBUN"))
        mXMAINTE_ORDER = TO_INTEGER_NULLABLE(objRow("XMAINTE_ORDER"))
        mXMAINTE_NAME = TO_STRING_NULLABLE(objRow("XMAINTE_NAME"))


    End Sub
#End Region
#Region "  �ް��擾(���ђ��o)(PLC)           "
    '''**********************************************************************************************
    ''' <summary>
    ''' �ް��擾(���ђ��o)(PLC)
    ''' </summary>
    ''' <param name="objUSER_PARAM">հ�ްPARAM (�޲��ޕϐ��p��޼ު�Č^�z��)</param>
    ''' <returns>���ʖ߂�l</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function GET_TMST_TRK_USER_PLC(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "TMST_TRK"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
                mobjAryMe(ii).SET_DATA_PLC(objRow)
            Next ii
            Return (RetCode.OK)
        Else
            Return (RetCode.NotFound)
        End If


    End Function
#End Region

    '���������ьŗL
    '**********************************************************************************************

End Class
