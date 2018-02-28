'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' �y���́zMaterialStreamð��ٸ׽
' �y�@�\�z�i��Ͻ�ð��ٸ׽
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
''' �i��Ͻ�ð��ٸ׽
''' </summary>
Public Class TBL_TMST_ITEM
    Inherits clsTemplateTable

    '**********************************************************************************************
    '����������������
#Region "  �׽�ϐ���`                  "
    '�����è
    Private mobjAryMe As TBL_TMST_ITEM()                                         '�i��Ͻ�
    Private mstrUSER_SQL As String                                               'հ�ްSQL
    Private mORDER_BY As String                                                  'OrderBy��
    Private mWHERE As String                                                     'Where��
    Private mFHINMEI_CD As String                                                '�i�ں���
    Private mFHINMEI As String                                                   '�i��_������
    Private mFTANI As String                                                     '�P�ʺ���
    Private mFDECIMAL_POINT As Nullable(Of Integer)                              '�����_�ȉ��L������
    Private mFNUM_IN_CASE As Nullable(Of Decimal)                                '���ܐ���
    Private mFZAIKO_KUBUN As Nullable(Of Integer)                                '�݌ɋ敪
    Private mFSHIKEN_YOUHI As Nullable(Of Integer)                               '��������L��
    Private mFSHIKEN_TIMELIMIT As Nullable(Of Integer)                           '�����L������
    Private mFSHIKEN_READTIME As Nullable(Of Integer)                            '����ذ�����
    Private mFRITEST_TIMELIMIT As Nullable(Of Integer)                           '�ýĊ���
    Private mFRITEST_FLAG As Nullable(Of Integer)                                '�ýđΏەi�׸�
    Private mFNUM_IN_PALLET As Nullable(Of Decimal)                              'PL���ύڐ�
    Private mFINVENTORY_FLAG As Nullable(Of Integer)                             '�I�����Ώ��׸�
    Private mFSYSTEM_FLAG As Nullable(Of Integer)                                '���ёΏ��׸�
    Private mFHASU_MATOME As Nullable(Of Integer)                                '�[���܂Ƃ��׸�
    Private mFDISP_ADDRESS As String                                             '�\�L�p���ڽ
    Private mFHINMEI_KIKAKU As String                                            '�i��_�K�i�e��
    Private mFRAC_FORM As Nullable(Of Integer)                                   '�I�`����
    Private mFENTRY_TERM_ID As String                                            '�o�^�[��ID
    Private mFENTRY_DT As Nullable(Of Date)                                      '�o�^����
    Private mFENTRY_USER_ID As String                                            '�o�^հ�ްID
    Private mFENTRY_USER_NAME As String                                          '�o�^հ�ް��
    Private mFUPDATE_TERM_ID As String                                           '�X�V�[��ID
    Private mFUPDATE_USER_ID As String                                           '�X�Vհ�ްID
    Private mFUPDATE_USER_NAME As String                                         '�X�Vհ�ް��
    Private mFUPDATE_DT As Nullable(Of Date)                                     '�X�V����
    Private mXABC_KANRI As Nullable(Of Integer)                                  'ABC�Ǘ�
    Private mXPLANE_PACK_NUMBER As Nullable(Of Integer)                          '���ʍ���
    Private mXWEIGHT_IN_CASE As Nullable(Of Decimal)                             '���d��
    Private mXWEIGHT_IN_PALLET As Nullable(Of Decimal)                           '��گĂ�����̏d��
    Private mXHEIGHT_IN_CASE As Nullable(Of Integer)                             '������
    Private mXHEIGHT_IN_PALLET As Nullable(Of Integer)                           '��گč���
    Private mXARTICLE_TYPE_CODE As Nullable(Of Integer)                          '�i�ڎ��(���i�敪)
    Private mX24H_KENSA_AUTO_FLG As Nullable(Of Integer)                         '24H�������ʎ����w��
    Private mXHINMEI_CD As String                                                '�i�ں���(�����i�ں���)
    Private mXSUB_CD As Nullable(Of Integer)                                     '��޺���
    Private mXITF_CD As String                                                   'ITF����
    Private mXJAN_CD As String                                                   'JAN����
    Private mXMAKER_CD As String                                                 'Ұ�-����
    Private mFRAC_BUNRUI As String                                               '�I����
    Private mXDAN_IN_PALLET As Nullable(Of Integer)                              '1��گĂ̒i��
    Private mXIN_RES_TYPE As Nullable(Of Integer)                                '�i�ڕʋ�I��������
#End Region
#Region "  �����è��`                  "
    ''' <summary>
    ''' ���ѕϐ� (���׽�^�z��)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_TMST_ITEM()
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
    ''' ���ܐ���
    ''' </summary>
    Public Property FNUM_IN_CASE() As Nullable(Of Decimal)
        Get
            Return mFNUM_IN_CASE
        End Get
        Set(ByVal Value As Nullable(Of Decimal))
            mFNUM_IN_CASE = Value
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
    ''' ��������L��
    ''' </summary>
    Public Property FSHIKEN_YOUHI() As Nullable(Of Integer)
        Get
            Return mFSHIKEN_YOUHI
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFSHIKEN_YOUHI = Value
        End Set
    End Property
    ''' <summary>
    ''' �����L������
    ''' </summary>
    Public Property FSHIKEN_TIMELIMIT() As Nullable(Of Integer)
        Get
            Return mFSHIKEN_TIMELIMIT
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFSHIKEN_TIMELIMIT = Value
        End Set
    End Property
    ''' <summary>
    ''' ����ذ�����
    ''' </summary>
    Public Property FSHIKEN_READTIME() As Nullable(Of Integer)
        Get
            Return mFSHIKEN_READTIME
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFSHIKEN_READTIME = Value
        End Set
    End Property
    ''' <summary>
    ''' �ýĊ���
    ''' </summary>
    Public Property FRITEST_TIMELIMIT() As Nullable(Of Integer)
        Get
            Return mFRITEST_TIMELIMIT
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRITEST_TIMELIMIT = Value
        End Set
    End Property
    ''' <summary>
    ''' �ýđΏەi�׸�
    ''' </summary>
    Public Property FRITEST_FLAG() As Nullable(Of Integer)
        Get
            Return mFRITEST_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRITEST_FLAG = Value
        End Set
    End Property
    ''' <summary>
    ''' PL���ύڐ�
    ''' </summary>
    Public Property FNUM_IN_PALLET() As Nullable(Of Decimal)
        Get
            Return mFNUM_IN_PALLET
        End Get
        Set(ByVal Value As Nullable(Of Decimal))
            mFNUM_IN_PALLET = Value
        End Set
    End Property
    ''' <summary>
    ''' �I�����Ώ��׸�
    ''' </summary>
    Public Property FINVENTORY_FLAG() As Nullable(Of Integer)
        Get
            Return mFINVENTORY_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFINVENTORY_FLAG = Value
        End Set
    End Property
    ''' <summary>
    ''' ���ёΏ��׸�
    ''' </summary>
    Public Property FSYSTEM_FLAG() As Nullable(Of Integer)
        Get
            Return mFSYSTEM_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFSYSTEM_FLAG = Value
        End Set
    End Property
    ''' <summary>
    ''' �[���܂Ƃ��׸�
    ''' </summary>
    Public Property FHASU_MATOME() As Nullable(Of Integer)
        Get
            Return mFHASU_MATOME
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFHASU_MATOME = Value
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
    ''' �i��_�K�i�e��
    ''' </summary>
    Public Property FHINMEI_KIKAKU() As String
        Get
            Return mFHINMEI_KIKAKU
        End Get
        Set(ByVal Value As String)
            mFHINMEI_KIKAKU = Value
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
    ''' �o�^�[��ID
    ''' </summary>
    Public Property FENTRY_TERM_ID() As String
        Get
            Return mFENTRY_TERM_ID
        End Get
        Set(ByVal Value As String)
            mFENTRY_TERM_ID = Value
        End Set
    End Property
    ''' <summary>
    ''' �o�^����
    ''' </summary>
    Public Property FENTRY_DT() As Nullable(Of Date)
        Get
            Return mFENTRY_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mFENTRY_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' �o�^հ�ްID
    ''' </summary>
    Public Property FENTRY_USER_ID() As String
        Get
            Return mFENTRY_USER_ID
        End Get
        Set(ByVal Value As String)
            mFENTRY_USER_ID = Value
        End Set
    End Property
    ''' <summary>
    ''' �o�^հ�ް��
    ''' </summary>
    Public Property FENTRY_USER_NAME() As String
        Get
            Return mFENTRY_USER_NAME
        End Get
        Set(ByVal Value As String)
            mFENTRY_USER_NAME = Value
        End Set
    End Property
    ''' <summary>
    ''' �X�V�[��ID
    ''' </summary>
    Public Property FUPDATE_TERM_ID() As String
        Get
            Return mFUPDATE_TERM_ID
        End Get
        Set(ByVal Value As String)
            mFUPDATE_TERM_ID = Value
        End Set
    End Property
    ''' <summary>
    ''' �X�Vհ�ްID
    ''' </summary>
    Public Property FUPDATE_USER_ID() As String
        Get
            Return mFUPDATE_USER_ID
        End Get
        Set(ByVal Value As String)
            mFUPDATE_USER_ID = Value
        End Set
    End Property
    ''' <summary>
    ''' �X�Vհ�ް��
    ''' </summary>
    Public Property FUPDATE_USER_NAME() As String
        Get
            Return mFUPDATE_USER_NAME
        End Get
        Set(ByVal Value As String)
            mFUPDATE_USER_NAME = Value
        End Set
    End Property
    ''' <summary>
    ''' �X�V����
    ''' </summary>
    Public Property FUPDATE_DT() As Nullable(Of Date)
        Get
            Return mFUPDATE_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mFUPDATE_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' ABC�Ǘ�
    ''' </summary>
    Public Property XABC_KANRI() As Nullable(Of Integer)
        Get
            Return mXABC_KANRI
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXABC_KANRI = Value
        End Set
    End Property
    ''' <summary>
    ''' ���ʍ���
    ''' </summary>
    Public Property XPLANE_PACK_NUMBER() As Nullable(Of Integer)
        Get
            Return mXPLANE_PACK_NUMBER
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXPLANE_PACK_NUMBER = Value
        End Set
    End Property
    ''' <summary>
    ''' ���d��
    ''' </summary>
    Public Property XWEIGHT_IN_CASE() As Nullable(Of Decimal)
        Get
            Return mXWEIGHT_IN_CASE
        End Get
        Set(ByVal Value As Nullable(Of Decimal))
            mXWEIGHT_IN_CASE = Value
        End Set
    End Property
    ''' <summary>
    ''' ��گĂ�����̏d��
    ''' </summary>
    Public Property XWEIGHT_IN_PALLET() As Nullable(Of Decimal)
        Get
            Return mXWEIGHT_IN_PALLET
        End Get
        Set(ByVal Value As Nullable(Of Decimal))
            mXWEIGHT_IN_PALLET = Value
        End Set
    End Property
    ''' <summary>
    ''' ������
    ''' </summary>
    Public Property XHEIGHT_IN_CASE() As Nullable(Of Integer)
        Get
            Return mXHEIGHT_IN_CASE
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXHEIGHT_IN_CASE = Value
        End Set
    End Property
    ''' <summary>
    ''' ��گč���
    ''' </summary>
    Public Property XHEIGHT_IN_PALLET() As Nullable(Of Integer)
        Get
            Return mXHEIGHT_IN_PALLET
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXHEIGHT_IN_PALLET = Value
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
    ''' 24H�������ʎ����w��
    ''' </summary>
    Public Property X24H_KENSA_AUTO_FLG() As Nullable(Of Integer)
        Get
            Return mX24H_KENSA_AUTO_FLG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mX24H_KENSA_AUTO_FLG = Value
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
    ''' ��޺���
    ''' </summary>
    Public Property XSUB_CD() As Nullable(Of Integer)
        Get
            Return mXSUB_CD
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXSUB_CD = Value
        End Set
    End Property
    ''' <summary>
    ''' ITF����
    ''' </summary>
    Public Property XITF_CD() As String
        Get
            Return mXITF_CD
        End Get
        Set(ByVal Value As String)
            mXITF_CD = Value
        End Set
    End Property
    ''' <summary>
    ''' JAN����
    ''' </summary>
    Public Property XJAN_CD() As String
        Get
            Return mXJAN_CD
        End Get
        Set(ByVal Value As String)
            mXJAN_CD = Value
        End Set
    End Property
    ''' <summary>
    ''' Ұ�-����
    ''' </summary>
    Public Property XMAKER_CD() As String
        Get
            Return mXMAKER_CD
        End Get
        Set(ByVal Value As String)
            mXMAKER_CD = Value
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
    ''' 1��گĂ̒i��
    ''' </summary>
    Public Property XDAN_IN_PALLET() As Nullable(Of Integer)
        Get
            Return mXDAN_IN_PALLET
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXDAN_IN_PALLET = Value
        End Set
    End Property
    ''' <summary>
    ''' �i�ڕʋ�I��������
    ''' </summary>
    Public Property XIN_RES_TYPE() As Nullable(Of Integer)
        Get
            Return mXIN_RES_TYPE
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXIN_RES_TYPE = Value
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
    Public Function GET_TMST_ITEM(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    TMST_ITEM")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
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
        If IsNull(FTANI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTANI
            strSQL.Append(vbCrLf & "    AND FTANI = :" & UBound(strBindField) - 1 & " --�P�ʺ���")
        End If
        If IsNull(FDECIMAL_POINT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDECIMAL_POINT
            strSQL.Append(vbCrLf & "    AND FDECIMAL_POINT = :" & UBound(strBindField) - 1 & " --�����_�ȉ��L������")
        End If
        If IsNull(FNUM_IN_CASE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFNUM_IN_CASE
            strSQL.Append(vbCrLf & "    AND FNUM_IN_CASE = :" & UBound(strBindField) - 1 & " --���ܐ���")
        End If
        If IsNull(FZAIKO_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_KUBUN
            strSQL.Append(vbCrLf & "    AND FZAIKO_KUBUN = :" & UBound(strBindField) - 1 & " --�݌ɋ敪")
        End If
        If IsNull(FSHIKEN_YOUHI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSHIKEN_YOUHI
            strSQL.Append(vbCrLf & "    AND FSHIKEN_YOUHI = :" & UBound(strBindField) - 1 & " --��������L��")
        End If
        If IsNull(FSHIKEN_TIMELIMIT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSHIKEN_TIMELIMIT
            strSQL.Append(vbCrLf & "    AND FSHIKEN_TIMELIMIT = :" & UBound(strBindField) - 1 & " --�����L������")
        End If
        If IsNull(FSHIKEN_READTIME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSHIKEN_READTIME
            strSQL.Append(vbCrLf & "    AND FSHIKEN_READTIME = :" & UBound(strBindField) - 1 & " --����ذ�����")
        End If
        If IsNull(FRITEST_TIMELIMIT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRITEST_TIMELIMIT
            strSQL.Append(vbCrLf & "    AND FRITEST_TIMELIMIT = :" & UBound(strBindField) - 1 & " --�ýĊ���")
        End If
        If IsNull(FRITEST_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRITEST_FLAG
            strSQL.Append(vbCrLf & "    AND FRITEST_FLAG = :" & UBound(strBindField) - 1 & " --�ýđΏەi�׸�")
        End If
        If IsNull(FNUM_IN_PALLET) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFNUM_IN_PALLET
            strSQL.Append(vbCrLf & "    AND FNUM_IN_PALLET = :" & UBound(strBindField) - 1 & " --PL���ύڐ�")
        End If
        If IsNull(FINVENTORY_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINVENTORY_FLAG
            strSQL.Append(vbCrLf & "    AND FINVENTORY_FLAG = :" & UBound(strBindField) - 1 & " --�I�����Ώ��׸�")
        End If
        If IsNull(FSYSTEM_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYSTEM_FLAG
            strSQL.Append(vbCrLf & "    AND FSYSTEM_FLAG = :" & UBound(strBindField) - 1 & " --���ёΏ��׸�")
        End If
        If IsNull(FHASU_MATOME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHASU_MATOME
            strSQL.Append(vbCrLf & "    AND FHASU_MATOME = :" & UBound(strBindField) - 1 & " --�[���܂Ƃ��׸�")
        End If
        If IsNull(FDISP_ADDRESS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS
            strSQL.Append(vbCrLf & "    AND FDISP_ADDRESS = :" & UBound(strBindField) - 1 & " --�\�L�p���ڽ")
        End If
        If IsNull(FHINMEI_KIKAKU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_KIKAKU
            strSQL.Append(vbCrLf & "    AND FHINMEI_KIKAKU = :" & UBound(strBindField) - 1 & " --�i��_�K�i�e��")
        End If
        If IsNull(FRAC_FORM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_FORM
            strSQL.Append(vbCrLf & "    AND FRAC_FORM = :" & UBound(strBindField) - 1 & " --�I�`����")
        End If
        If IsNull(FENTRY_TERM_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_TERM_ID
            strSQL.Append(vbCrLf & "    AND FENTRY_TERM_ID = :" & UBound(strBindField) - 1 & " --�o�^�[��ID")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --�o�^����")
        End If
        If IsNull(FENTRY_USER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_USER_ID
            strSQL.Append(vbCrLf & "    AND FENTRY_USER_ID = :" & UBound(strBindField) - 1 & " --�o�^հ�ްID")
        End If
        If IsNull(FENTRY_USER_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_USER_NAME
            strSQL.Append(vbCrLf & "    AND FENTRY_USER_NAME = :" & UBound(strBindField) - 1 & " --�o�^հ�ް��")
        End If
        If IsNull(FUPDATE_TERM_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_TERM_ID
            strSQL.Append(vbCrLf & "    AND FUPDATE_TERM_ID = :" & UBound(strBindField) - 1 & " --�X�V�[��ID")
        End If
        If IsNull(FUPDATE_USER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_USER_ID
            strSQL.Append(vbCrLf & "    AND FUPDATE_USER_ID = :" & UBound(strBindField) - 1 & " --�X�Vհ�ްID")
        End If
        If IsNull(FUPDATE_USER_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_USER_NAME
            strSQL.Append(vbCrLf & "    AND FUPDATE_USER_NAME = :" & UBound(strBindField) - 1 & " --�X�Vհ�ް��")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --�X�V����")
        End If
        If IsNull(XABC_KANRI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXABC_KANRI
            strSQL.Append(vbCrLf & "    AND XABC_KANRI = :" & UBound(strBindField) - 1 & " --ABC�Ǘ�")
        End If
        If IsNull(XPLANE_PACK_NUMBER) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPLANE_PACK_NUMBER
            strSQL.Append(vbCrLf & "    AND XPLANE_PACK_NUMBER = :" & UBound(strBindField) - 1 & " --���ʍ���")
        End If
        If IsNull(XWEIGHT_IN_CASE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXWEIGHT_IN_CASE
            strSQL.Append(vbCrLf & "    AND XWEIGHT_IN_CASE = :" & UBound(strBindField) - 1 & " --���d��")
        End If
        If IsNull(XWEIGHT_IN_PALLET) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXWEIGHT_IN_PALLET
            strSQL.Append(vbCrLf & "    AND XWEIGHT_IN_PALLET = :" & UBound(strBindField) - 1 & " --��گĂ�����̏d��")
        End If
        If IsNull(XHEIGHT_IN_CASE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHEIGHT_IN_CASE
            strSQL.Append(vbCrLf & "    AND XHEIGHT_IN_CASE = :" & UBound(strBindField) - 1 & " --������")
        End If
        If IsNull(XHEIGHT_IN_PALLET) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHEIGHT_IN_PALLET
            strSQL.Append(vbCrLf & "    AND XHEIGHT_IN_PALLET = :" & UBound(strBindField) - 1 & " --��گč���")
        End If
        If IsNull(XARTICLE_TYPE_CODE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXARTICLE_TYPE_CODE
            strSQL.Append(vbCrLf & "    AND XARTICLE_TYPE_CODE = :" & UBound(strBindField) - 1 & " --�i�ڎ��(���i�敪)")
        End If
        If IsNull(X24H_KENSA_AUTO_FLG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mX24H_KENSA_AUTO_FLG
            strSQL.Append(vbCrLf & "    AND X24H_KENSA_AUTO_FLG = :" & UBound(strBindField) - 1 & " --24H�������ʎ����w��")
        End If
        If IsNull(XHINMEI_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHINMEI_CD
            strSQL.Append(vbCrLf & "    AND XHINMEI_CD = :" & UBound(strBindField) - 1 & " --�i�ں���(�����i�ں���)")
        End If
        If IsNull(XSUB_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSUB_CD
            strSQL.Append(vbCrLf & "    AND XSUB_CD = :" & UBound(strBindField) - 1 & " --��޺���")
        End If
        If IsNull(XITF_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXITF_CD
            strSQL.Append(vbCrLf & "    AND XITF_CD = :" & UBound(strBindField) - 1 & " --ITF����")
        End If
        If IsNull(XJAN_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXJAN_CD
            strSQL.Append(vbCrLf & "    AND XJAN_CD = :" & UBound(strBindField) - 1 & " --JAN����")
        End If
        If IsNull(XMAKER_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAKER_CD
            strSQL.Append(vbCrLf & "    AND XMAKER_CD = :" & UBound(strBindField) - 1 & " --Ұ�-����")
        End If
        If IsNull(FRAC_BUNRUI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_BUNRUI
            strSQL.Append(vbCrLf & "    AND FRAC_BUNRUI = :" & UBound(strBindField) - 1 & " --�I����")
        End If
        If IsNull(XDAN_IN_PALLET) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDAN_IN_PALLET
            strSQL.Append(vbCrLf & "    AND XDAN_IN_PALLET = :" & UBound(strBindField) - 1 & " --1��گĂ̒i��")
        End If
        If IsNull(XIN_RES_TYPE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIN_RES_TYPE
            strSQL.Append(vbCrLf & "    AND XIN_RES_TYPE = :" & UBound(strBindField) - 1 & " --�i�ڕʋ�I��������")
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
        strDataSetName = "TMST_ITEM"
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
    Public Function GET_TMST_ITEM_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    TMST_ITEM")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
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
        If IsNull(FTANI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTANI
            strSQL.Append(vbCrLf & "    AND FTANI = :" & UBound(strBindField) - 1 & " --�P�ʺ���")
        End If
        If IsNull(FDECIMAL_POINT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDECIMAL_POINT
            strSQL.Append(vbCrLf & "    AND FDECIMAL_POINT = :" & UBound(strBindField) - 1 & " --�����_�ȉ��L������")
        End If
        If IsNull(FNUM_IN_CASE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFNUM_IN_CASE
            strSQL.Append(vbCrLf & "    AND FNUM_IN_CASE = :" & UBound(strBindField) - 1 & " --���ܐ���")
        End If
        If IsNull(FZAIKO_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_KUBUN
            strSQL.Append(vbCrLf & "    AND FZAIKO_KUBUN = :" & UBound(strBindField) - 1 & " --�݌ɋ敪")
        End If
        If IsNull(FSHIKEN_YOUHI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSHIKEN_YOUHI
            strSQL.Append(vbCrLf & "    AND FSHIKEN_YOUHI = :" & UBound(strBindField) - 1 & " --��������L��")
        End If
        If IsNull(FSHIKEN_TIMELIMIT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSHIKEN_TIMELIMIT
            strSQL.Append(vbCrLf & "    AND FSHIKEN_TIMELIMIT = :" & UBound(strBindField) - 1 & " --�����L������")
        End If
        If IsNull(FSHIKEN_READTIME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSHIKEN_READTIME
            strSQL.Append(vbCrLf & "    AND FSHIKEN_READTIME = :" & UBound(strBindField) - 1 & " --����ذ�����")
        End If
        If IsNull(FRITEST_TIMELIMIT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRITEST_TIMELIMIT
            strSQL.Append(vbCrLf & "    AND FRITEST_TIMELIMIT = :" & UBound(strBindField) - 1 & " --�ýĊ���")
        End If
        If IsNull(FRITEST_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRITEST_FLAG
            strSQL.Append(vbCrLf & "    AND FRITEST_FLAG = :" & UBound(strBindField) - 1 & " --�ýđΏەi�׸�")
        End If
        If IsNull(FNUM_IN_PALLET) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFNUM_IN_PALLET
            strSQL.Append(vbCrLf & "    AND FNUM_IN_PALLET = :" & UBound(strBindField) - 1 & " --PL���ύڐ�")
        End If
        If IsNull(FINVENTORY_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINVENTORY_FLAG
            strSQL.Append(vbCrLf & "    AND FINVENTORY_FLAG = :" & UBound(strBindField) - 1 & " --�I�����Ώ��׸�")
        End If
        If IsNull(FSYSTEM_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYSTEM_FLAG
            strSQL.Append(vbCrLf & "    AND FSYSTEM_FLAG = :" & UBound(strBindField) - 1 & " --���ёΏ��׸�")
        End If
        If IsNull(FHASU_MATOME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHASU_MATOME
            strSQL.Append(vbCrLf & "    AND FHASU_MATOME = :" & UBound(strBindField) - 1 & " --�[���܂Ƃ��׸�")
        End If
        If IsNull(FDISP_ADDRESS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS
            strSQL.Append(vbCrLf & "    AND FDISP_ADDRESS = :" & UBound(strBindField) - 1 & " --�\�L�p���ڽ")
        End If
        If IsNull(FHINMEI_KIKAKU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_KIKAKU
            strSQL.Append(vbCrLf & "    AND FHINMEI_KIKAKU = :" & UBound(strBindField) - 1 & " --�i��_�K�i�e��")
        End If
        If IsNull(FRAC_FORM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_FORM
            strSQL.Append(vbCrLf & "    AND FRAC_FORM = :" & UBound(strBindField) - 1 & " --�I�`����")
        End If
        If IsNull(FENTRY_TERM_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_TERM_ID
            strSQL.Append(vbCrLf & "    AND FENTRY_TERM_ID = :" & UBound(strBindField) - 1 & " --�o�^�[��ID")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --�o�^����")
        End If
        If IsNull(FENTRY_USER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_USER_ID
            strSQL.Append(vbCrLf & "    AND FENTRY_USER_ID = :" & UBound(strBindField) - 1 & " --�o�^հ�ްID")
        End If
        If IsNull(FENTRY_USER_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_USER_NAME
            strSQL.Append(vbCrLf & "    AND FENTRY_USER_NAME = :" & UBound(strBindField) - 1 & " --�o�^հ�ް��")
        End If
        If IsNull(FUPDATE_TERM_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_TERM_ID
            strSQL.Append(vbCrLf & "    AND FUPDATE_TERM_ID = :" & UBound(strBindField) - 1 & " --�X�V�[��ID")
        End If
        If IsNull(FUPDATE_USER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_USER_ID
            strSQL.Append(vbCrLf & "    AND FUPDATE_USER_ID = :" & UBound(strBindField) - 1 & " --�X�Vհ�ްID")
        End If
        If IsNull(FUPDATE_USER_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_USER_NAME
            strSQL.Append(vbCrLf & "    AND FUPDATE_USER_NAME = :" & UBound(strBindField) - 1 & " --�X�Vհ�ް��")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --�X�V����")
        End If
        If IsNull(XABC_KANRI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXABC_KANRI
            strSQL.Append(vbCrLf & "    AND XABC_KANRI = :" & UBound(strBindField) - 1 & " --ABC�Ǘ�")
        End If
        If IsNull(XPLANE_PACK_NUMBER) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPLANE_PACK_NUMBER
            strSQL.Append(vbCrLf & "    AND XPLANE_PACK_NUMBER = :" & UBound(strBindField) - 1 & " --���ʍ���")
        End If
        If IsNull(XWEIGHT_IN_CASE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXWEIGHT_IN_CASE
            strSQL.Append(vbCrLf & "    AND XWEIGHT_IN_CASE = :" & UBound(strBindField) - 1 & " --���d��")
        End If
        If IsNull(XWEIGHT_IN_PALLET) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXWEIGHT_IN_PALLET
            strSQL.Append(vbCrLf & "    AND XWEIGHT_IN_PALLET = :" & UBound(strBindField) - 1 & " --��گĂ�����̏d��")
        End If
        If IsNull(XHEIGHT_IN_CASE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHEIGHT_IN_CASE
            strSQL.Append(vbCrLf & "    AND XHEIGHT_IN_CASE = :" & UBound(strBindField) - 1 & " --������")
        End If
        If IsNull(XHEIGHT_IN_PALLET) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHEIGHT_IN_PALLET
            strSQL.Append(vbCrLf & "    AND XHEIGHT_IN_PALLET = :" & UBound(strBindField) - 1 & " --��گč���")
        End If
        If IsNull(XARTICLE_TYPE_CODE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXARTICLE_TYPE_CODE
            strSQL.Append(vbCrLf & "    AND XARTICLE_TYPE_CODE = :" & UBound(strBindField) - 1 & " --�i�ڎ��(���i�敪)")
        End If
        If IsNull(X24H_KENSA_AUTO_FLG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mX24H_KENSA_AUTO_FLG
            strSQL.Append(vbCrLf & "    AND X24H_KENSA_AUTO_FLG = :" & UBound(strBindField) - 1 & " --24H�������ʎ����w��")
        End If
        If IsNull(XHINMEI_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHINMEI_CD
            strSQL.Append(vbCrLf & "    AND XHINMEI_CD = :" & UBound(strBindField) - 1 & " --�i�ں���(�����i�ں���)")
        End If
        If IsNull(XSUB_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSUB_CD
            strSQL.Append(vbCrLf & "    AND XSUB_CD = :" & UBound(strBindField) - 1 & " --��޺���")
        End If
        If IsNull(XITF_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXITF_CD
            strSQL.Append(vbCrLf & "    AND XITF_CD = :" & UBound(strBindField) - 1 & " --ITF����")
        End If
        If IsNull(XJAN_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXJAN_CD
            strSQL.Append(vbCrLf & "    AND XJAN_CD = :" & UBound(strBindField) - 1 & " --JAN����")
        End If
        If IsNull(XMAKER_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAKER_CD
            strSQL.Append(vbCrLf & "    AND XMAKER_CD = :" & UBound(strBindField) - 1 & " --Ұ�-����")
        End If
        If IsNull(FRAC_BUNRUI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_BUNRUI
            strSQL.Append(vbCrLf & "    AND FRAC_BUNRUI = :" & UBound(strBindField) - 1 & " --�I����")
        End If
        If IsNull(XDAN_IN_PALLET) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDAN_IN_PALLET
            strSQL.Append(vbCrLf & "    AND XDAN_IN_PALLET = :" & UBound(strBindField) - 1 & " --1��گĂ̒i��")
        End If
        If IsNull(XIN_RES_TYPE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIN_RES_TYPE
            strSQL.Append(vbCrLf & "    AND XIN_RES_TYPE = :" & UBound(strBindField) - 1 & " --�i�ڕʋ�I��������")
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
        strDataSetName = "TMST_ITEM"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TMST_ITEM(Owner, objDb, objDbLog)
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
    Public Function GET_TMST_ITEM_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "TMST_ITEM"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TMST_ITEM(Owner, objDb, objDbLog)
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
    Public Function GET_TMST_ITEM_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    TMST_ITEM")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
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
        If IsNull(FTANI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTANI
            strSQL.Append(vbCrLf & "    AND FTANI = :" & UBound(strBindField) - 1 & " --�P�ʺ���")
        End If
        If IsNull(FDECIMAL_POINT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDECIMAL_POINT
            strSQL.Append(vbCrLf & "    AND FDECIMAL_POINT = :" & UBound(strBindField) - 1 & " --�����_�ȉ��L������")
        End If
        If IsNull(FNUM_IN_CASE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFNUM_IN_CASE
            strSQL.Append(vbCrLf & "    AND FNUM_IN_CASE = :" & UBound(strBindField) - 1 & " --���ܐ���")
        End If
        If IsNull(FZAIKO_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_KUBUN
            strSQL.Append(vbCrLf & "    AND FZAIKO_KUBUN = :" & UBound(strBindField) - 1 & " --�݌ɋ敪")
        End If
        If IsNull(FSHIKEN_YOUHI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSHIKEN_YOUHI
            strSQL.Append(vbCrLf & "    AND FSHIKEN_YOUHI = :" & UBound(strBindField) - 1 & " --��������L��")
        End If
        If IsNull(FSHIKEN_TIMELIMIT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSHIKEN_TIMELIMIT
            strSQL.Append(vbCrLf & "    AND FSHIKEN_TIMELIMIT = :" & UBound(strBindField) - 1 & " --�����L������")
        End If
        If IsNull(FSHIKEN_READTIME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSHIKEN_READTIME
            strSQL.Append(vbCrLf & "    AND FSHIKEN_READTIME = :" & UBound(strBindField) - 1 & " --����ذ�����")
        End If
        If IsNull(FRITEST_TIMELIMIT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRITEST_TIMELIMIT
            strSQL.Append(vbCrLf & "    AND FRITEST_TIMELIMIT = :" & UBound(strBindField) - 1 & " --�ýĊ���")
        End If
        If IsNull(FRITEST_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRITEST_FLAG
            strSQL.Append(vbCrLf & "    AND FRITEST_FLAG = :" & UBound(strBindField) - 1 & " --�ýđΏەi�׸�")
        End If
        If IsNull(FNUM_IN_PALLET) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFNUM_IN_PALLET
            strSQL.Append(vbCrLf & "    AND FNUM_IN_PALLET = :" & UBound(strBindField) - 1 & " --PL���ύڐ�")
        End If
        If IsNull(FINVENTORY_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINVENTORY_FLAG
            strSQL.Append(vbCrLf & "    AND FINVENTORY_FLAG = :" & UBound(strBindField) - 1 & " --�I�����Ώ��׸�")
        End If
        If IsNull(FSYSTEM_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYSTEM_FLAG
            strSQL.Append(vbCrLf & "    AND FSYSTEM_FLAG = :" & UBound(strBindField) - 1 & " --���ёΏ��׸�")
        End If
        If IsNull(FHASU_MATOME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHASU_MATOME
            strSQL.Append(vbCrLf & "    AND FHASU_MATOME = :" & UBound(strBindField) - 1 & " --�[���܂Ƃ��׸�")
        End If
        If IsNull(FDISP_ADDRESS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS
            strSQL.Append(vbCrLf & "    AND FDISP_ADDRESS = :" & UBound(strBindField) - 1 & " --�\�L�p���ڽ")
        End If
        If IsNull(FHINMEI_KIKAKU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_KIKAKU
            strSQL.Append(vbCrLf & "    AND FHINMEI_KIKAKU = :" & UBound(strBindField) - 1 & " --�i��_�K�i�e��")
        End If
        If IsNull(FRAC_FORM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_FORM
            strSQL.Append(vbCrLf & "    AND FRAC_FORM = :" & UBound(strBindField) - 1 & " --�I�`����")
        End If
        If IsNull(FENTRY_TERM_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_TERM_ID
            strSQL.Append(vbCrLf & "    AND FENTRY_TERM_ID = :" & UBound(strBindField) - 1 & " --�o�^�[��ID")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --�o�^����")
        End If
        If IsNull(FENTRY_USER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_USER_ID
            strSQL.Append(vbCrLf & "    AND FENTRY_USER_ID = :" & UBound(strBindField) - 1 & " --�o�^հ�ްID")
        End If
        If IsNull(FENTRY_USER_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_USER_NAME
            strSQL.Append(vbCrLf & "    AND FENTRY_USER_NAME = :" & UBound(strBindField) - 1 & " --�o�^հ�ް��")
        End If
        If IsNull(FUPDATE_TERM_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_TERM_ID
            strSQL.Append(vbCrLf & "    AND FUPDATE_TERM_ID = :" & UBound(strBindField) - 1 & " --�X�V�[��ID")
        End If
        If IsNull(FUPDATE_USER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_USER_ID
            strSQL.Append(vbCrLf & "    AND FUPDATE_USER_ID = :" & UBound(strBindField) - 1 & " --�X�Vհ�ްID")
        End If
        If IsNull(FUPDATE_USER_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_USER_NAME
            strSQL.Append(vbCrLf & "    AND FUPDATE_USER_NAME = :" & UBound(strBindField) - 1 & " --�X�Vհ�ް��")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --�X�V����")
        End If
        If IsNull(XABC_KANRI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXABC_KANRI
            strSQL.Append(vbCrLf & "    AND XABC_KANRI = :" & UBound(strBindField) - 1 & " --ABC�Ǘ�")
        End If
        If IsNull(XPLANE_PACK_NUMBER) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPLANE_PACK_NUMBER
            strSQL.Append(vbCrLf & "    AND XPLANE_PACK_NUMBER = :" & UBound(strBindField) - 1 & " --���ʍ���")
        End If
        If IsNull(XWEIGHT_IN_CASE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXWEIGHT_IN_CASE
            strSQL.Append(vbCrLf & "    AND XWEIGHT_IN_CASE = :" & UBound(strBindField) - 1 & " --���d��")
        End If
        If IsNull(XWEIGHT_IN_PALLET) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXWEIGHT_IN_PALLET
            strSQL.Append(vbCrLf & "    AND XWEIGHT_IN_PALLET = :" & UBound(strBindField) - 1 & " --��گĂ�����̏d��")
        End If
        If IsNull(XHEIGHT_IN_CASE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHEIGHT_IN_CASE
            strSQL.Append(vbCrLf & "    AND XHEIGHT_IN_CASE = :" & UBound(strBindField) - 1 & " --������")
        End If
        If IsNull(XHEIGHT_IN_PALLET) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHEIGHT_IN_PALLET
            strSQL.Append(vbCrLf & "    AND XHEIGHT_IN_PALLET = :" & UBound(strBindField) - 1 & " --��گč���")
        End If
        If IsNull(XARTICLE_TYPE_CODE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXARTICLE_TYPE_CODE
            strSQL.Append(vbCrLf & "    AND XARTICLE_TYPE_CODE = :" & UBound(strBindField) - 1 & " --�i�ڎ��(���i�敪)")
        End If
        If IsNull(X24H_KENSA_AUTO_FLG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mX24H_KENSA_AUTO_FLG
            strSQL.Append(vbCrLf & "    AND X24H_KENSA_AUTO_FLG = :" & UBound(strBindField) - 1 & " --24H�������ʎ����w��")
        End If
        If IsNull(XHINMEI_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHINMEI_CD
            strSQL.Append(vbCrLf & "    AND XHINMEI_CD = :" & UBound(strBindField) - 1 & " --�i�ں���(�����i�ں���)")
        End If
        If IsNull(XSUB_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSUB_CD
            strSQL.Append(vbCrLf & "    AND XSUB_CD = :" & UBound(strBindField) - 1 & " --��޺���")
        End If
        If IsNull(XITF_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXITF_CD
            strSQL.Append(vbCrLf & "    AND XITF_CD = :" & UBound(strBindField) - 1 & " --ITF����")
        End If
        If IsNull(XJAN_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXJAN_CD
            strSQL.Append(vbCrLf & "    AND XJAN_CD = :" & UBound(strBindField) - 1 & " --JAN����")
        End If
        If IsNull(XMAKER_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAKER_CD
            strSQL.Append(vbCrLf & "    AND XMAKER_CD = :" & UBound(strBindField) - 1 & " --Ұ�-����")
        End If
        If IsNull(FRAC_BUNRUI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_BUNRUI
            strSQL.Append(vbCrLf & "    AND FRAC_BUNRUI = :" & UBound(strBindField) - 1 & " --�I����")
        End If
        If IsNull(XDAN_IN_PALLET) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDAN_IN_PALLET
            strSQL.Append(vbCrLf & "    AND XDAN_IN_PALLET = :" & UBound(strBindField) - 1 & " --1��گĂ̒i��")
        End If
        If IsNull(XIN_RES_TYPE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIN_RES_TYPE
            strSQL.Append(vbCrLf & "    AND XIN_RES_TYPE = :" & UBound(strBindField) - 1 & " --�i�ڕʋ�I��������")
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
        strDataSetName = "TMST_ITEM"
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
    Public Sub UPDATE_TMST_ITEM()
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
        ElseIf IsNull(mFHINMEI_CD) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�i�ں���]"
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
        strSQL.Append(vbCrLf & "    TMST_ITEM")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
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
        If IsNull(mFNUM_IN_CASE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FNUM_IN_CASE = NULL --���ܐ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FNUM_IN_CASE = NULL --���ܐ���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFNUM_IN_CASE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FNUM_IN_CASE = :" & Ubound(strBindField) - 1 & " --���ܐ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FNUM_IN_CASE = :" & Ubound(strBindField) - 1 & " --���ܐ���")
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
        If IsNull(mFSHIKEN_YOUHI) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSHIKEN_YOUHI = NULL --��������L��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSHIKEN_YOUHI = NULL --��������L��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSHIKEN_YOUHI
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSHIKEN_YOUHI = :" & Ubound(strBindField) - 1 & " --��������L��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSHIKEN_YOUHI = :" & Ubound(strBindField) - 1 & " --��������L��")
        End If
        intCount = intCount + 1
        If IsNull(mFSHIKEN_TIMELIMIT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSHIKEN_TIMELIMIT = NULL --�����L������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSHIKEN_TIMELIMIT = NULL --�����L������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSHIKEN_TIMELIMIT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSHIKEN_TIMELIMIT = :" & Ubound(strBindField) - 1 & " --�����L������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSHIKEN_TIMELIMIT = :" & Ubound(strBindField) - 1 & " --�����L������")
        End If
        intCount = intCount + 1
        If IsNull(mFSHIKEN_READTIME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSHIKEN_READTIME = NULL --����ذ�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSHIKEN_READTIME = NULL --����ذ�����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSHIKEN_READTIME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSHIKEN_READTIME = :" & Ubound(strBindField) - 1 & " --����ذ�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSHIKEN_READTIME = :" & Ubound(strBindField) - 1 & " --����ذ�����")
        End If
        intCount = intCount + 1
        If IsNull(mFRITEST_TIMELIMIT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRITEST_TIMELIMIT = NULL --�ýĊ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRITEST_TIMELIMIT = NULL --�ýĊ���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRITEST_TIMELIMIT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRITEST_TIMELIMIT = :" & Ubound(strBindField) - 1 & " --�ýĊ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRITEST_TIMELIMIT = :" & Ubound(strBindField) - 1 & " --�ýĊ���")
        End If
        intCount = intCount + 1
        If IsNull(mFRITEST_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRITEST_FLAG = NULL --�ýđΏەi�׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRITEST_FLAG = NULL --�ýđΏەi�׸�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRITEST_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRITEST_FLAG = :" & Ubound(strBindField) - 1 & " --�ýđΏەi�׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRITEST_FLAG = :" & Ubound(strBindField) - 1 & " --�ýđΏەi�׸�")
        End If
        intCount = intCount + 1
        If IsNull(mFNUM_IN_PALLET) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FNUM_IN_PALLET = NULL --PL���ύڐ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FNUM_IN_PALLET = NULL --PL���ύڐ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFNUM_IN_PALLET
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FNUM_IN_PALLET = :" & Ubound(strBindField) - 1 & " --PL���ύڐ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FNUM_IN_PALLET = :" & Ubound(strBindField) - 1 & " --PL���ύڐ�")
        End If
        intCount = intCount + 1
        If IsNull(mFINVENTORY_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FINVENTORY_FLAG = NULL --�I�����Ώ��׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FINVENTORY_FLAG = NULL --�I�����Ώ��׸�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINVENTORY_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FINVENTORY_FLAG = :" & Ubound(strBindField) - 1 & " --�I�����Ώ��׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FINVENTORY_FLAG = :" & Ubound(strBindField) - 1 & " --�I�����Ώ��׸�")
        End If
        intCount = intCount + 1
        If IsNull(mFSYSTEM_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSYSTEM_FLAG = NULL --���ёΏ��׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSYSTEM_FLAG = NULL --���ёΏ��׸�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYSTEM_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSYSTEM_FLAG = :" & Ubound(strBindField) - 1 & " --���ёΏ��׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSYSTEM_FLAG = :" & Ubound(strBindField) - 1 & " --���ёΏ��׸�")
        End If
        intCount = intCount + 1
        If IsNull(mFHASU_MATOME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHASU_MATOME = NULL --�[���܂Ƃ��׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHASU_MATOME = NULL --�[���܂Ƃ��׸�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHASU_MATOME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHASU_MATOME = :" & Ubound(strBindField) - 1 & " --�[���܂Ƃ��׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHASU_MATOME = :" & Ubound(strBindField) - 1 & " --�[���܂Ƃ��׸�")
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
        If IsNull(mFHINMEI_KIKAKU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHINMEI_KIKAKU = NULL --�i��_�K�i�e��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHINMEI_KIKAKU = NULL --�i��_�K�i�e��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_KIKAKU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHINMEI_KIKAKU = :" & Ubound(strBindField) - 1 & " --�i��_�K�i�e��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHINMEI_KIKAKU = :" & Ubound(strBindField) - 1 & " --�i��_�K�i�e��")
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
        If IsNull(mFENTRY_TERM_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FENTRY_TERM_ID = NULL --�o�^�[��ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FENTRY_TERM_ID = NULL --�o�^�[��ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_TERM_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FENTRY_TERM_ID = :" & Ubound(strBindField) - 1 & " --�o�^�[��ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FENTRY_TERM_ID = :" & Ubound(strBindField) - 1 & " --�o�^�[��ID")
        End If
        intCount = intCount + 1
        If IsNull(mFENTRY_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FENTRY_DT = NULL --�o�^����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FENTRY_DT = NULL --�o�^����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FENTRY_DT = :" & Ubound(strBindField) - 1 & " --�o�^����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FENTRY_DT = :" & Ubound(strBindField) - 1 & " --�o�^����")
        End If
        intCount = intCount + 1
        If IsNull(mFENTRY_USER_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FENTRY_USER_ID = NULL --�o�^հ�ްID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FENTRY_USER_ID = NULL --�o�^հ�ްID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_USER_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FENTRY_USER_ID = :" & Ubound(strBindField) - 1 & " --�o�^հ�ްID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FENTRY_USER_ID = :" & Ubound(strBindField) - 1 & " --�o�^հ�ްID")
        End If
        intCount = intCount + 1
        If IsNull(mFENTRY_USER_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FENTRY_USER_NAME = NULL --�o�^հ�ް��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FENTRY_USER_NAME = NULL --�o�^հ�ް��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_USER_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FENTRY_USER_NAME = :" & Ubound(strBindField) - 1 & " --�o�^հ�ް��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FENTRY_USER_NAME = :" & Ubound(strBindField) - 1 & " --�o�^հ�ް��")
        End If
        intCount = intCount + 1
        If IsNull(mFUPDATE_TERM_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUPDATE_TERM_ID = NULL --�X�V�[��ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUPDATE_TERM_ID = NULL --�X�V�[��ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_TERM_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUPDATE_TERM_ID = :" & Ubound(strBindField) - 1 & " --�X�V�[��ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUPDATE_TERM_ID = :" & Ubound(strBindField) - 1 & " --�X�V�[��ID")
        End If
        intCount = intCount + 1
        If IsNull(mFUPDATE_USER_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUPDATE_USER_ID = NULL --�X�Vհ�ްID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUPDATE_USER_ID = NULL --�X�Vհ�ްID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_USER_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUPDATE_USER_ID = :" & Ubound(strBindField) - 1 & " --�X�Vհ�ްID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUPDATE_USER_ID = :" & Ubound(strBindField) - 1 & " --�X�Vհ�ްID")
        End If
        intCount = intCount + 1
        If IsNull(mFUPDATE_USER_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUPDATE_USER_NAME = NULL --�X�Vհ�ް��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUPDATE_USER_NAME = NULL --�X�Vհ�ް��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_USER_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUPDATE_USER_NAME = :" & Ubound(strBindField) - 1 & " --�X�Vհ�ް��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUPDATE_USER_NAME = :" & Ubound(strBindField) - 1 & " --�X�Vհ�ް��")
        End If
        intCount = intCount + 1
        If IsNull(mFUPDATE_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUPDATE_DT = NULL --�X�V����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUPDATE_DT = NULL --�X�V����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUPDATE_DT = :" & Ubound(strBindField) - 1 & " --�X�V����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUPDATE_DT = :" & Ubound(strBindField) - 1 & " --�X�V����")
        End If
        intCount = intCount + 1
        If IsNull(mXABC_KANRI) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XABC_KANRI = NULL --ABC�Ǘ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XABC_KANRI = NULL --ABC�Ǘ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXABC_KANRI
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XABC_KANRI = :" & Ubound(strBindField) - 1 & " --ABC�Ǘ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XABC_KANRI = :" & Ubound(strBindField) - 1 & " --ABC�Ǘ�")
        End If
        intCount = intCount + 1
        If IsNull(mXPLANE_PACK_NUMBER) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XPLANE_PACK_NUMBER = NULL --���ʍ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XPLANE_PACK_NUMBER = NULL --���ʍ���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPLANE_PACK_NUMBER
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XPLANE_PACK_NUMBER = :" & Ubound(strBindField) - 1 & " --���ʍ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XPLANE_PACK_NUMBER = :" & Ubound(strBindField) - 1 & " --���ʍ���")
        End If
        intCount = intCount + 1
        If IsNull(mXWEIGHT_IN_CASE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XWEIGHT_IN_CASE = NULL --���d��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XWEIGHT_IN_CASE = NULL --���d��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXWEIGHT_IN_CASE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XWEIGHT_IN_CASE = :" & Ubound(strBindField) - 1 & " --���d��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XWEIGHT_IN_CASE = :" & Ubound(strBindField) - 1 & " --���d��")
        End If
        intCount = intCount + 1
        If IsNull(mXWEIGHT_IN_PALLET) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XWEIGHT_IN_PALLET = NULL --��گĂ�����̏d��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XWEIGHT_IN_PALLET = NULL --��گĂ�����̏d��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXWEIGHT_IN_PALLET
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XWEIGHT_IN_PALLET = :" & Ubound(strBindField) - 1 & " --��گĂ�����̏d��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XWEIGHT_IN_PALLET = :" & Ubound(strBindField) - 1 & " --��گĂ�����̏d��")
        End If
        intCount = intCount + 1
        If IsNull(mXHEIGHT_IN_CASE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XHEIGHT_IN_CASE = NULL --������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XHEIGHT_IN_CASE = NULL --������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHEIGHT_IN_CASE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XHEIGHT_IN_CASE = :" & Ubound(strBindField) - 1 & " --������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XHEIGHT_IN_CASE = :" & Ubound(strBindField) - 1 & " --������")
        End If
        intCount = intCount + 1
        If IsNull(mXHEIGHT_IN_PALLET) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XHEIGHT_IN_PALLET = NULL --��گč���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XHEIGHT_IN_PALLET = NULL --��گč���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHEIGHT_IN_PALLET
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XHEIGHT_IN_PALLET = :" & Ubound(strBindField) - 1 & " --��گč���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XHEIGHT_IN_PALLET = :" & Ubound(strBindField) - 1 & " --��گč���")
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
        If IsNull(mX24H_KENSA_AUTO_FLG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    X24H_KENSA_AUTO_FLG = NULL --24H�������ʎ����w��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,X24H_KENSA_AUTO_FLG = NULL --24H�������ʎ����w��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mX24H_KENSA_AUTO_FLG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    X24H_KENSA_AUTO_FLG = :" & Ubound(strBindField) - 1 & " --24H�������ʎ����w��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,X24H_KENSA_AUTO_FLG = :" & Ubound(strBindField) - 1 & " --24H�������ʎ����w��")
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
        If IsNull(mXSUB_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSUB_CD = NULL --��޺���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSUB_CD = NULL --��޺���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSUB_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSUB_CD = :" & Ubound(strBindField) - 1 & " --��޺���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSUB_CD = :" & Ubound(strBindField) - 1 & " --��޺���")
        End If
        intCount = intCount + 1
        If IsNull(mXITF_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XITF_CD = NULL --ITF����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XITF_CD = NULL --ITF����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXITF_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XITF_CD = :" & Ubound(strBindField) - 1 & " --ITF����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XITF_CD = :" & Ubound(strBindField) - 1 & " --ITF����")
        End If
        intCount = intCount + 1
        If IsNull(mXJAN_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XJAN_CD = NULL --JAN����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XJAN_CD = NULL --JAN����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXJAN_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XJAN_CD = :" & Ubound(strBindField) - 1 & " --JAN����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XJAN_CD = :" & Ubound(strBindField) - 1 & " --JAN����")
        End If
        intCount = intCount + 1
        If IsNull(mXMAKER_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XMAKER_CD = NULL --Ұ�-����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XMAKER_CD = NULL --Ұ�-����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAKER_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XMAKER_CD = :" & Ubound(strBindField) - 1 & " --Ұ�-����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XMAKER_CD = :" & Ubound(strBindField) - 1 & " --Ұ�-����")
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
        If IsNull(mXDAN_IN_PALLET) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDAN_IN_PALLET = NULL --1��گĂ̒i��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDAN_IN_PALLET = NULL --1��گĂ̒i��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDAN_IN_PALLET
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDAN_IN_PALLET = :" & Ubound(strBindField) - 1 & " --1��گĂ̒i��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDAN_IN_PALLET = :" & Ubound(strBindField) - 1 & " --1��گĂ̒i��")
        End If
        intCount = intCount + 1
        If IsNull(mXIN_RES_TYPE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XIN_RES_TYPE = NULL --�i�ڕʋ�I��������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XIN_RES_TYPE = NULL --�i�ڕʋ�I��������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIN_RES_TYPE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XIN_RES_TYPE = :" & Ubound(strBindField) - 1 & " --�i�ڕʋ�I��������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XIN_RES_TYPE = :" & Ubound(strBindField) - 1 & " --�i�ڕʋ�I��������")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FHINMEI_CD) = True Then
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD IS NULL --�i�ں���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --�i�ں���")
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
    Public Sub ADD_TMST_ITEM()
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
        ElseIf IsNull(mFHINMEI_CD) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�i�ں���]"
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
        strSQL.Append(vbCrLf & "    TMST_ITEM")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
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
        If IsNull(mFNUM_IN_CASE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���ܐ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���ܐ���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFNUM_IN_CASE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���ܐ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���ܐ���")
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
        If IsNull(mFSHIKEN_YOUHI) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --��������L��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --��������L��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSHIKEN_YOUHI
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --��������L��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --��������L��")
        End If
        intCount = intCount + 1
        If IsNull(mFSHIKEN_TIMELIMIT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�����L������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�����L������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSHIKEN_TIMELIMIT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�����L������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�����L������")
        End If
        intCount = intCount + 1
        If IsNull(mFSHIKEN_READTIME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����ذ�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����ذ�����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSHIKEN_READTIME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����ذ�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����ذ�����")
        End If
        intCount = intCount + 1
        If IsNull(mFRITEST_TIMELIMIT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ýĊ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ýĊ���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRITEST_TIMELIMIT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ýĊ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ýĊ���")
        End If
        intCount = intCount + 1
        If IsNull(mFRITEST_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ýđΏەi�׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ýđΏەi�׸�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRITEST_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ýđΏەi�׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ýđΏەi�׸�")
        End If
        intCount = intCount + 1
        If IsNull(mFNUM_IN_PALLET) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --PL���ύڐ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --PL���ύڐ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFNUM_IN_PALLET
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --PL���ύڐ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --PL���ύڐ�")
        End If
        intCount = intCount + 1
        If IsNull(mFINVENTORY_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�I�����Ώ��׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�I�����Ώ��׸�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINVENTORY_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�I�����Ώ��׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�I�����Ώ��׸�")
        End If
        intCount = intCount + 1
        If IsNull(mFSYSTEM_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���ёΏ��׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���ёΏ��׸�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYSTEM_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���ёΏ��׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���ёΏ��׸�")
        End If
        intCount = intCount + 1
        If IsNull(mFHASU_MATOME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�[���܂Ƃ��׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�[���܂Ƃ��׸�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHASU_MATOME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�[���܂Ƃ��׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�[���܂Ƃ��׸�")
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
        If IsNull(mFHINMEI_KIKAKU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�i��_�K�i�e��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�i��_�K�i�e��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_KIKAKU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�i��_�K�i�e��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�i��_�K�i�e��")
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
        If IsNull(mFENTRY_TERM_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�o�^�[��ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�o�^�[��ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_TERM_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�o�^�[��ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�o�^�[��ID")
        End If
        intCount = intCount + 1
        If IsNull(mFENTRY_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�o�^����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�o�^����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�o�^����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�o�^����")
        End If
        intCount = intCount + 1
        If IsNull(mFENTRY_USER_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�o�^հ�ްID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�o�^հ�ްID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_USER_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�o�^հ�ްID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�o�^հ�ްID")
        End If
        intCount = intCount + 1
        If IsNull(mFENTRY_USER_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�o�^հ�ް��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�o�^հ�ް��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_USER_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�o�^հ�ް��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�o�^հ�ް��")
        End If
        intCount = intCount + 1
        If IsNull(mFUPDATE_TERM_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�X�V�[��ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�X�V�[��ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_TERM_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�X�V�[��ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�X�V�[��ID")
        End If
        intCount = intCount + 1
        If IsNull(mFUPDATE_USER_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�X�Vհ�ްID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�X�Vհ�ްID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_USER_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�X�Vհ�ްID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�X�Vհ�ްID")
        End If
        intCount = intCount + 1
        If IsNull(mFUPDATE_USER_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�X�Vհ�ް��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�X�Vհ�ް��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_USER_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�X�Vհ�ް��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�X�Vհ�ް��")
        End If
        intCount = intCount + 1
        If IsNull(mFUPDATE_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�X�V����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�X�V����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�X�V����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�X�V����")
        End If
        intCount = intCount + 1
        If IsNull(mXABC_KANRI) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ABC�Ǘ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ABC�Ǘ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXABC_KANRI
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ABC�Ǘ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ABC�Ǘ�")
        End If
        intCount = intCount + 1
        If IsNull(mXPLANE_PACK_NUMBER) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���ʍ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���ʍ���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPLANE_PACK_NUMBER
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���ʍ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���ʍ���")
        End If
        intCount = intCount + 1
        If IsNull(mXWEIGHT_IN_CASE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���d��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���d��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXWEIGHT_IN_CASE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���d��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���d��")
        End If
        intCount = intCount + 1
        If IsNull(mXWEIGHT_IN_PALLET) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --��گĂ�����̏d��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --��گĂ�����̏d��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXWEIGHT_IN_PALLET
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --��گĂ�����̏d��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --��گĂ�����̏d��")
        End If
        intCount = intCount + 1
        If IsNull(mXHEIGHT_IN_CASE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHEIGHT_IN_CASE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --������")
        End If
        intCount = intCount + 1
        If IsNull(mXHEIGHT_IN_PALLET) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --��گč���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --��گč���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHEIGHT_IN_PALLET
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --��گč���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --��گč���")
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
        If IsNull(mX24H_KENSA_AUTO_FLG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --24H�������ʎ����w��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --24H�������ʎ����w��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mX24H_KENSA_AUTO_FLG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --24H�������ʎ����w��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --24H�������ʎ����w��")
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
        If IsNull(mXSUB_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --��޺���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --��޺���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSUB_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --��޺���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --��޺���")
        End If
        intCount = intCount + 1
        If IsNull(mXITF_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ITF����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ITF����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXITF_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ITF����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ITF����")
        End If
        intCount = intCount + 1
        If IsNull(mXJAN_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --JAN����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --JAN����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXJAN_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --JAN����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --JAN����")
        End If
        intCount = intCount + 1
        If IsNull(mXMAKER_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --Ұ�-����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --Ұ�-����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAKER_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --Ұ�-����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --Ұ�-����")
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
        If IsNull(mXDAN_IN_PALLET) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --1��گĂ̒i��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --1��گĂ̒i��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDAN_IN_PALLET
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --1��گĂ̒i��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --1��گĂ̒i��")
        End If
        intCount = intCount + 1
        If IsNull(mXIN_RES_TYPE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�i�ڕʋ�I��������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�i�ڕʋ�I��������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIN_RES_TYPE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�i�ڕʋ�I��������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�i�ڕʋ�I��������")
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
    Public Sub DELETE_TMST_ITEM()
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
        ElseIf IsNull(mFHINMEI_CD) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�i�ں���]"
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
        strSQL.Append(vbCrLf & "    TMST_ITEM")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FHINMEI_CD) = True Then
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD IS NULL --�i�ں���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --�i�ں���")
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
    Public Sub DELETE_TMST_ITEM_ANY()
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
        strSQL.Append(vbCrLf & "    TMST_ITEM")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
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
        If IsNotNull(FTANI) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTANI
            strSQL.Append(vbCrLf & "    AND FTANI = :" & UBound(strBindField) - 1 & " --�P�ʺ���")
        End If
        If IsNotNull(FDECIMAL_POINT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDECIMAL_POINT
            strSQL.Append(vbCrLf & "    AND FDECIMAL_POINT = :" & UBound(strBindField) - 1 & " --�����_�ȉ��L������")
        End If
        If IsNotNull(FNUM_IN_CASE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFNUM_IN_CASE
            strSQL.Append(vbCrLf & "    AND FNUM_IN_CASE = :" & UBound(strBindField) - 1 & " --���ܐ���")
        End If
        If IsNotNull(FZAIKO_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_KUBUN
            strSQL.Append(vbCrLf & "    AND FZAIKO_KUBUN = :" & UBound(strBindField) - 1 & " --�݌ɋ敪")
        End If
        If IsNotNull(FSHIKEN_YOUHI) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSHIKEN_YOUHI
            strSQL.Append(vbCrLf & "    AND FSHIKEN_YOUHI = :" & UBound(strBindField) - 1 & " --��������L��")
        End If
        If IsNotNull(FSHIKEN_TIMELIMIT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSHIKEN_TIMELIMIT
            strSQL.Append(vbCrLf & "    AND FSHIKEN_TIMELIMIT = :" & UBound(strBindField) - 1 & " --�����L������")
        End If
        If IsNotNull(FSHIKEN_READTIME) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSHIKEN_READTIME
            strSQL.Append(vbCrLf & "    AND FSHIKEN_READTIME = :" & UBound(strBindField) - 1 & " --����ذ�����")
        End If
        If IsNotNull(FRITEST_TIMELIMIT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRITEST_TIMELIMIT
            strSQL.Append(vbCrLf & "    AND FRITEST_TIMELIMIT = :" & UBound(strBindField) - 1 & " --�ýĊ���")
        End If
        If IsNotNull(FRITEST_FLAG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRITEST_FLAG
            strSQL.Append(vbCrLf & "    AND FRITEST_FLAG = :" & UBound(strBindField) - 1 & " --�ýđΏەi�׸�")
        End If
        If IsNotNull(FNUM_IN_PALLET) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFNUM_IN_PALLET
            strSQL.Append(vbCrLf & "    AND FNUM_IN_PALLET = :" & UBound(strBindField) - 1 & " --PL���ύڐ�")
        End If
        If IsNotNull(FINVENTORY_FLAG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINVENTORY_FLAG
            strSQL.Append(vbCrLf & "    AND FINVENTORY_FLAG = :" & UBound(strBindField) - 1 & " --�I�����Ώ��׸�")
        End If
        If IsNotNull(FSYSTEM_FLAG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYSTEM_FLAG
            strSQL.Append(vbCrLf & "    AND FSYSTEM_FLAG = :" & UBound(strBindField) - 1 & " --���ёΏ��׸�")
        End If
        If IsNotNull(FHASU_MATOME) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHASU_MATOME
            strSQL.Append(vbCrLf & "    AND FHASU_MATOME = :" & UBound(strBindField) - 1 & " --�[���܂Ƃ��׸�")
        End If
        If IsNotNull(FDISP_ADDRESS) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS
            strSQL.Append(vbCrLf & "    AND FDISP_ADDRESS = :" & UBound(strBindField) - 1 & " --�\�L�p���ڽ")
        End If
        If IsNotNull(FHINMEI_KIKAKU) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_KIKAKU
            strSQL.Append(vbCrLf & "    AND FHINMEI_KIKAKU = :" & UBound(strBindField) - 1 & " --�i��_�K�i�e��")
        End If
        If IsNotNull(FRAC_FORM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_FORM
            strSQL.Append(vbCrLf & "    AND FRAC_FORM = :" & UBound(strBindField) - 1 & " --�I�`����")
        End If
        If IsNotNull(FENTRY_TERM_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_TERM_ID
            strSQL.Append(vbCrLf & "    AND FENTRY_TERM_ID = :" & UBound(strBindField) - 1 & " --�o�^�[��ID")
        End If
        If IsNotNull(FENTRY_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --�o�^����")
        End If
        If IsNotNull(FENTRY_USER_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_USER_ID
            strSQL.Append(vbCrLf & "    AND FENTRY_USER_ID = :" & UBound(strBindField) - 1 & " --�o�^հ�ްID")
        End If
        If IsNotNull(FENTRY_USER_NAME) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_USER_NAME
            strSQL.Append(vbCrLf & "    AND FENTRY_USER_NAME = :" & UBound(strBindField) - 1 & " --�o�^հ�ް��")
        End If
        If IsNotNull(FUPDATE_TERM_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_TERM_ID
            strSQL.Append(vbCrLf & "    AND FUPDATE_TERM_ID = :" & UBound(strBindField) - 1 & " --�X�V�[��ID")
        End If
        If IsNotNull(FUPDATE_USER_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_USER_ID
            strSQL.Append(vbCrLf & "    AND FUPDATE_USER_ID = :" & UBound(strBindField) - 1 & " --�X�Vհ�ްID")
        End If
        If IsNotNull(FUPDATE_USER_NAME) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_USER_NAME
            strSQL.Append(vbCrLf & "    AND FUPDATE_USER_NAME = :" & UBound(strBindField) - 1 & " --�X�Vհ�ް��")
        End If
        If IsNotNull(FUPDATE_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --�X�V����")
        End If
        If IsNotNull(XABC_KANRI) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXABC_KANRI
            strSQL.Append(vbCrLf & "    AND XABC_KANRI = :" & UBound(strBindField) - 1 & " --ABC�Ǘ�")
        End If
        If IsNotNull(XPLANE_PACK_NUMBER) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPLANE_PACK_NUMBER
            strSQL.Append(vbCrLf & "    AND XPLANE_PACK_NUMBER = :" & UBound(strBindField) - 1 & " --���ʍ���")
        End If
        If IsNotNull(XWEIGHT_IN_CASE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXWEIGHT_IN_CASE
            strSQL.Append(vbCrLf & "    AND XWEIGHT_IN_CASE = :" & UBound(strBindField) - 1 & " --���d��")
        End If
        If IsNotNull(XWEIGHT_IN_PALLET) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXWEIGHT_IN_PALLET
            strSQL.Append(vbCrLf & "    AND XWEIGHT_IN_PALLET = :" & UBound(strBindField) - 1 & " --��گĂ�����̏d��")
        End If
        If IsNotNull(XHEIGHT_IN_CASE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHEIGHT_IN_CASE
            strSQL.Append(vbCrLf & "    AND XHEIGHT_IN_CASE = :" & UBound(strBindField) - 1 & " --������")
        End If
        If IsNotNull(XHEIGHT_IN_PALLET) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHEIGHT_IN_PALLET
            strSQL.Append(vbCrLf & "    AND XHEIGHT_IN_PALLET = :" & UBound(strBindField) - 1 & " --��گč���")
        End If
        If IsNotNull(XARTICLE_TYPE_CODE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXARTICLE_TYPE_CODE
            strSQL.Append(vbCrLf & "    AND XARTICLE_TYPE_CODE = :" & UBound(strBindField) - 1 & " --�i�ڎ��(���i�敪)")
        End If
        If IsNotNull(X24H_KENSA_AUTO_FLG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mX24H_KENSA_AUTO_FLG
            strSQL.Append(vbCrLf & "    AND X24H_KENSA_AUTO_FLG = :" & UBound(strBindField) - 1 & " --24H�������ʎ����w��")
        End If
        If IsNotNull(XHINMEI_CD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHINMEI_CD
            strSQL.Append(vbCrLf & "    AND XHINMEI_CD = :" & UBound(strBindField) - 1 & " --�i�ں���(�����i�ں���)")
        End If
        If IsNotNull(XSUB_CD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSUB_CD
            strSQL.Append(vbCrLf & "    AND XSUB_CD = :" & UBound(strBindField) - 1 & " --��޺���")
        End If
        If IsNotNull(XITF_CD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXITF_CD
            strSQL.Append(vbCrLf & "    AND XITF_CD = :" & UBound(strBindField) - 1 & " --ITF����")
        End If
        If IsNotNull(XJAN_CD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXJAN_CD
            strSQL.Append(vbCrLf & "    AND XJAN_CD = :" & UBound(strBindField) - 1 & " --JAN����")
        End If
        If IsNotNull(XMAKER_CD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAKER_CD
            strSQL.Append(vbCrLf & "    AND XMAKER_CD = :" & UBound(strBindField) - 1 & " --Ұ�-����")
        End If
        If IsNotNull(FRAC_BUNRUI) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_BUNRUI
            strSQL.Append(vbCrLf & "    AND FRAC_BUNRUI = :" & UBound(strBindField) - 1 & " --�I����")
        End If
        If IsNotNull(XDAN_IN_PALLET) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDAN_IN_PALLET
            strSQL.Append(vbCrLf & "    AND XDAN_IN_PALLET = :" & UBound(strBindField) - 1 & " --1��گĂ̒i��")
        End If
        If IsNotNull(XIN_RES_TYPE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIN_RES_TYPE
            strSQL.Append(vbCrLf & "    AND XIN_RES_TYPE = :" & UBound(strBindField) - 1 & " --�i�ڕʋ�I��������")
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
        If IsNothing(objType.GetProperty("FHINMEI_CD")) = False Then mFHINMEI_CD = objObject.FHINMEI_CD '�i�ں���
        If IsNothing(objType.GetProperty("FHINMEI")) = False Then mFHINMEI = objObject.FHINMEI '�i��_������
        If IsNothing(objType.GetProperty("FTANI")) = False Then mFTANI = objObject.FTANI '�P�ʺ���
        If IsNothing(objType.GetProperty("FDECIMAL_POINT")) = False Then mFDECIMAL_POINT = objObject.FDECIMAL_POINT '�����_�ȉ��L������
        If IsNothing(objType.GetProperty("FNUM_IN_CASE")) = False Then mFNUM_IN_CASE = objObject.FNUM_IN_CASE '���ܐ���
        If IsNothing(objType.GetProperty("FZAIKO_KUBUN")) = False Then mFZAIKO_KUBUN = objObject.FZAIKO_KUBUN '�݌ɋ敪
        If IsNothing(objType.GetProperty("FSHIKEN_YOUHI")) = False Then mFSHIKEN_YOUHI = objObject.FSHIKEN_YOUHI '��������L��
        If IsNothing(objType.GetProperty("FSHIKEN_TIMELIMIT")) = False Then mFSHIKEN_TIMELIMIT = objObject.FSHIKEN_TIMELIMIT '�����L������
        If IsNothing(objType.GetProperty("FSHIKEN_READTIME")) = False Then mFSHIKEN_READTIME = objObject.FSHIKEN_READTIME '����ذ�����
        If IsNothing(objType.GetProperty("FRITEST_TIMELIMIT")) = False Then mFRITEST_TIMELIMIT = objObject.FRITEST_TIMELIMIT '�ýĊ���
        If IsNothing(objType.GetProperty("FRITEST_FLAG")) = False Then mFRITEST_FLAG = objObject.FRITEST_FLAG '�ýđΏەi�׸�
        If IsNothing(objType.GetProperty("FNUM_IN_PALLET")) = False Then mFNUM_IN_PALLET = objObject.FNUM_IN_PALLET 'PL���ύڐ�
        If IsNothing(objType.GetProperty("FINVENTORY_FLAG")) = False Then mFINVENTORY_FLAG = objObject.FINVENTORY_FLAG '�I�����Ώ��׸�
        If IsNothing(objType.GetProperty("FSYSTEM_FLAG")) = False Then mFSYSTEM_FLAG = objObject.FSYSTEM_FLAG '���ёΏ��׸�
        If IsNothing(objType.GetProperty("FHASU_MATOME")) = False Then mFHASU_MATOME = objObject.FHASU_MATOME '�[���܂Ƃ��׸�
        If IsNothing(objType.GetProperty("FDISP_ADDRESS")) = False Then mFDISP_ADDRESS = objObject.FDISP_ADDRESS '�\�L�p���ڽ
        If IsNothing(objType.GetProperty("FHINMEI_KIKAKU")) = False Then mFHINMEI_KIKAKU = objObject.FHINMEI_KIKAKU '�i��_�K�i�e��
        If IsNothing(objType.GetProperty("FRAC_FORM")) = False Then mFRAC_FORM = objObject.FRAC_FORM '�I�`����
        If IsNothing(objType.GetProperty("FENTRY_TERM_ID")) = False Then mFENTRY_TERM_ID = objObject.FENTRY_TERM_ID '�o�^�[��ID
        If IsNothing(objType.GetProperty("FENTRY_DT")) = False Then mFENTRY_DT = objObject.FENTRY_DT '�o�^����
        If IsNothing(objType.GetProperty("FENTRY_USER_ID")) = False Then mFENTRY_USER_ID = objObject.FENTRY_USER_ID '�o�^հ�ްID
        If IsNothing(objType.GetProperty("FENTRY_USER_NAME")) = False Then mFENTRY_USER_NAME = objObject.FENTRY_USER_NAME '�o�^հ�ް��
        If IsNothing(objType.GetProperty("FUPDATE_TERM_ID")) = False Then mFUPDATE_TERM_ID = objObject.FUPDATE_TERM_ID '�X�V�[��ID
        If IsNothing(objType.GetProperty("FUPDATE_USER_ID")) = False Then mFUPDATE_USER_ID = objObject.FUPDATE_USER_ID '�X�Vհ�ްID
        If IsNothing(objType.GetProperty("FUPDATE_USER_NAME")) = False Then mFUPDATE_USER_NAME = objObject.FUPDATE_USER_NAME '�X�Vհ�ް��
        If IsNothing(objType.GetProperty("FUPDATE_DT")) = False Then mFUPDATE_DT = objObject.FUPDATE_DT '�X�V����
        If IsNothing(objType.GetProperty("XABC_KANRI")) = False Then mXABC_KANRI = objObject.XABC_KANRI 'ABC�Ǘ�
        If IsNothing(objType.GetProperty("XPLANE_PACK_NUMBER")) = False Then mXPLANE_PACK_NUMBER = objObject.XPLANE_PACK_NUMBER '���ʍ���
        If IsNothing(objType.GetProperty("XWEIGHT_IN_CASE")) = False Then mXWEIGHT_IN_CASE = objObject.XWEIGHT_IN_CASE '���d��
        If IsNothing(objType.GetProperty("XWEIGHT_IN_PALLET")) = False Then mXWEIGHT_IN_PALLET = objObject.XWEIGHT_IN_PALLET '��گĂ�����̏d��
        If IsNothing(objType.GetProperty("XHEIGHT_IN_CASE")) = False Then mXHEIGHT_IN_CASE = objObject.XHEIGHT_IN_CASE '������
        If IsNothing(objType.GetProperty("XHEIGHT_IN_PALLET")) = False Then mXHEIGHT_IN_PALLET = objObject.XHEIGHT_IN_PALLET '��گč���
        If IsNothing(objType.GetProperty("XARTICLE_TYPE_CODE")) = False Then mXARTICLE_TYPE_CODE = objObject.XARTICLE_TYPE_CODE '�i�ڎ��(���i�敪)
        If IsNothing(objType.GetProperty("X24H_KENSA_AUTO_FLG")) = False Then mX24H_KENSA_AUTO_FLG = objObject.X24H_KENSA_AUTO_FLG '24H�������ʎ����w��
        If IsNothing(objType.GetProperty("XHINMEI_CD")) = False Then mXHINMEI_CD = objObject.XHINMEI_CD '�i�ں���(�����i�ں���)
        If IsNothing(objType.GetProperty("XSUB_CD")) = False Then mXSUB_CD = objObject.XSUB_CD '��޺���
        If IsNothing(objType.GetProperty("XITF_CD")) = False Then mXITF_CD = objObject.XITF_CD 'ITF����
        If IsNothing(objType.GetProperty("XJAN_CD")) = False Then mXJAN_CD = objObject.XJAN_CD 'JAN����
        If IsNothing(objType.GetProperty("XMAKER_CD")) = False Then mXMAKER_CD = objObject.XMAKER_CD 'Ұ�-����
        If IsNothing(objType.GetProperty("FRAC_BUNRUI")) = False Then mFRAC_BUNRUI = objObject.FRAC_BUNRUI '�I����
        If IsNothing(objType.GetProperty("XDAN_IN_PALLET")) = False Then mXDAN_IN_PALLET = objObject.XDAN_IN_PALLET '1��گĂ̒i��
        If IsNothing(objType.GetProperty("XIN_RES_TYPE")) = False Then mXIN_RES_TYPE = objObject.XIN_RES_TYPE '�i�ڕʋ�I��������

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
        mFHINMEI_CD = Nothing
        mFHINMEI = Nothing
        mFTANI = Nothing
        mFDECIMAL_POINT = Nothing
        mFNUM_IN_CASE = Nothing
        mFZAIKO_KUBUN = Nothing
        mFSHIKEN_YOUHI = Nothing
        mFSHIKEN_TIMELIMIT = Nothing
        mFSHIKEN_READTIME = Nothing
        mFRITEST_TIMELIMIT = Nothing
        mFRITEST_FLAG = Nothing
        mFNUM_IN_PALLET = Nothing
        mFINVENTORY_FLAG = Nothing
        mFSYSTEM_FLAG = Nothing
        mFHASU_MATOME = Nothing
        mFDISP_ADDRESS = Nothing
        mFHINMEI_KIKAKU = Nothing
        mFRAC_FORM = Nothing
        mFENTRY_TERM_ID = Nothing
        mFENTRY_DT = Nothing
        mFENTRY_USER_ID = Nothing
        mFENTRY_USER_NAME = Nothing
        mFUPDATE_TERM_ID = Nothing
        mFUPDATE_USER_ID = Nothing
        mFUPDATE_USER_NAME = Nothing
        mFUPDATE_DT = Nothing
        mXABC_KANRI = Nothing
        mXPLANE_PACK_NUMBER = Nothing
        mXWEIGHT_IN_CASE = Nothing
        mXWEIGHT_IN_PALLET = Nothing
        mXHEIGHT_IN_CASE = Nothing
        mXHEIGHT_IN_PALLET = Nothing
        mXARTICLE_TYPE_CODE = Nothing
        mX24H_KENSA_AUTO_FLG = Nothing
        mXHINMEI_CD = Nothing
        mXSUB_CD = Nothing
        mXITF_CD = Nothing
        mXJAN_CD = Nothing
        mXMAKER_CD = Nothing
        mFRAC_BUNRUI = Nothing
        mXDAN_IN_PALLET = Nothing
        mXIN_RES_TYPE = Nothing


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
        mFHINMEI_CD = TO_STRING_NULLABLE(objRow("FHINMEI_CD"))
        mFHINMEI = TO_STRING_NULLABLE(objRow("FHINMEI"))
        mFTANI = TO_STRING_NULLABLE(objRow("FTANI"))
        mFDECIMAL_POINT = TO_INTEGER_NULLABLE(objRow("FDECIMAL_POINT"))
        mFNUM_IN_CASE = TO_DECIMAL_NULLABLE(objRow("FNUM_IN_CASE"))
        mFZAIKO_KUBUN = TO_INTEGER_NULLABLE(objRow("FZAIKO_KUBUN"))
        mFSHIKEN_YOUHI = TO_INTEGER_NULLABLE(objRow("FSHIKEN_YOUHI"))
        mFSHIKEN_TIMELIMIT = TO_INTEGER_NULLABLE(objRow("FSHIKEN_TIMELIMIT"))
        mFSHIKEN_READTIME = TO_INTEGER_NULLABLE(objRow("FSHIKEN_READTIME"))
        mFRITEST_TIMELIMIT = TO_INTEGER_NULLABLE(objRow("FRITEST_TIMELIMIT"))
        mFRITEST_FLAG = TO_INTEGER_NULLABLE(objRow("FRITEST_FLAG"))
        mFNUM_IN_PALLET = TO_DECIMAL_NULLABLE(objRow("FNUM_IN_PALLET"))
        mFINVENTORY_FLAG = TO_INTEGER_NULLABLE(objRow("FINVENTORY_FLAG"))
        mFSYSTEM_FLAG = TO_INTEGER_NULLABLE(objRow("FSYSTEM_FLAG"))
        mFHASU_MATOME = TO_INTEGER_NULLABLE(objRow("FHASU_MATOME"))
        mFDISP_ADDRESS = TO_STRING_NULLABLE(objRow("FDISP_ADDRESS"))
        mFHINMEI_KIKAKU = TO_STRING_NULLABLE(objRow("FHINMEI_KIKAKU"))
        mFRAC_FORM = TO_INTEGER_NULLABLE(objRow("FRAC_FORM"))
        mFENTRY_TERM_ID = TO_STRING_NULLABLE(objRow("FENTRY_TERM_ID"))
        mFENTRY_DT = TO_DATE_NULLABLE(objRow("FENTRY_DT"))
        mFENTRY_USER_ID = TO_STRING_NULLABLE(objRow("FENTRY_USER_ID"))
        mFENTRY_USER_NAME = TO_STRING_NULLABLE(objRow("FENTRY_USER_NAME"))
        mFUPDATE_TERM_ID = TO_STRING_NULLABLE(objRow("FUPDATE_TERM_ID"))
        mFUPDATE_USER_ID = TO_STRING_NULLABLE(objRow("FUPDATE_USER_ID"))
        mFUPDATE_USER_NAME = TO_STRING_NULLABLE(objRow("FUPDATE_USER_NAME"))
        mFUPDATE_DT = TO_DATE_NULLABLE(objRow("FUPDATE_DT"))
        mXABC_KANRI = TO_INTEGER_NULLABLE(objRow("XABC_KANRI"))
        mXPLANE_PACK_NUMBER = TO_INTEGER_NULLABLE(objRow("XPLANE_PACK_NUMBER"))
        mXWEIGHT_IN_CASE = TO_DECIMAL_NULLABLE(objRow("XWEIGHT_IN_CASE"))
        mXWEIGHT_IN_PALLET = TO_DECIMAL_NULLABLE(objRow("XWEIGHT_IN_PALLET"))
        mXHEIGHT_IN_CASE = TO_INTEGER_NULLABLE(objRow("XHEIGHT_IN_CASE"))
        mXHEIGHT_IN_PALLET = TO_INTEGER_NULLABLE(objRow("XHEIGHT_IN_PALLET"))
        mXARTICLE_TYPE_CODE = TO_INTEGER_NULLABLE(objRow("XARTICLE_TYPE_CODE"))
        mX24H_KENSA_AUTO_FLG = TO_INTEGER_NULLABLE(objRow("X24H_KENSA_AUTO_FLG"))
        mXHINMEI_CD = TO_STRING_NULLABLE(objRow("XHINMEI_CD"))
        mXSUB_CD = TO_INTEGER_NULLABLE(objRow("XSUB_CD"))
        mXITF_CD = TO_STRING_NULLABLE(objRow("XITF_CD"))
        mXJAN_CD = TO_STRING_NULLABLE(objRow("XJAN_CD"))
        mXMAKER_CD = TO_STRING_NULLABLE(objRow("XMAKER_CD"))
        mFRAC_BUNRUI = TO_STRING_NULLABLE(objRow("FRAC_BUNRUI"))
        mXDAN_IN_PALLET = TO_INTEGER_NULLABLE(objRow("XDAN_IN_PALLET"))
        mXIN_RES_TYPE = TO_INTEGER_NULLABLE(objRow("XIN_RES_TYPE"))


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
        strMsg &= "[ð��ٖ�:�i��Ͻ�]"
        If IsNotNull(FHINMEI_CD) Then
            strMsg &= "[�i�ں���:" & FHINMEI_CD & "]"
        End If
        If IsNotNull(FHINMEI) Then
            strMsg &= "[�i��_������:" & FHINMEI & "]"
        End If
        If IsNotNull(FTANI) Then
            strMsg &= "[�P�ʺ���:" & FTANI & "]"
        End If
        If IsNotNull(FDECIMAL_POINT) Then
            strMsg &= "[�����_�ȉ��L������:" & FDECIMAL_POINT & "]"
        End If
        If IsNotNull(FNUM_IN_CASE) Then
            strMsg &= "[���ܐ���:" & FNUM_IN_CASE & "]"
        End If
        If IsNotNull(FZAIKO_KUBUN) Then
            strMsg &= "[�݌ɋ敪:" & FZAIKO_KUBUN & "]"
        End If
        If IsNotNull(FSHIKEN_YOUHI) Then
            strMsg &= "[��������L��:" & FSHIKEN_YOUHI & "]"
        End If
        If IsNotNull(FSHIKEN_TIMELIMIT) Then
            strMsg &= "[�����L������:" & FSHIKEN_TIMELIMIT & "]"
        End If
        If IsNotNull(FSHIKEN_READTIME) Then
            strMsg &= "[����ذ�����:" & FSHIKEN_READTIME & "]"
        End If
        If IsNotNull(FRITEST_TIMELIMIT) Then
            strMsg &= "[�ýĊ���:" & FRITEST_TIMELIMIT & "]"
        End If
        If IsNotNull(FRITEST_FLAG) Then
            strMsg &= "[�ýđΏەi�׸�:" & FRITEST_FLAG & "]"
        End If
        If IsNotNull(FNUM_IN_PALLET) Then
            strMsg &= "[PL���ύڐ�:" & FNUM_IN_PALLET & "]"
        End If
        If IsNotNull(FINVENTORY_FLAG) Then
            strMsg &= "[�I�����Ώ��׸�:" & FINVENTORY_FLAG & "]"
        End If
        If IsNotNull(FSYSTEM_FLAG) Then
            strMsg &= "[���ёΏ��׸�:" & FSYSTEM_FLAG & "]"
        End If
        If IsNotNull(FHASU_MATOME) Then
            strMsg &= "[�[���܂Ƃ��׸�:" & FHASU_MATOME & "]"
        End If
        If IsNotNull(FDISP_ADDRESS) Then
            strMsg &= "[�\�L�p���ڽ:" & FDISP_ADDRESS & "]"
        End If
        If IsNotNull(FHINMEI_KIKAKU) Then
            strMsg &= "[�i��_�K�i�e��:" & FHINMEI_KIKAKU & "]"
        End If
        If IsNotNull(FRAC_FORM) Then
            strMsg &= "[�I�`����:" & FRAC_FORM & "]"
        End If
        If IsNotNull(FENTRY_TERM_ID) Then
            strMsg &= "[�o�^�[��ID:" & FENTRY_TERM_ID & "]"
        End If
        If IsNotNull(FENTRY_DT) Then
            strMsg &= "[�o�^����:" & FENTRY_DT & "]"
        End If
        If IsNotNull(FENTRY_USER_ID) Then
            strMsg &= "[�o�^հ�ްID:" & FENTRY_USER_ID & "]"
        End If
        If IsNotNull(FENTRY_USER_NAME) Then
            strMsg &= "[�o�^հ�ް��:" & FENTRY_USER_NAME & "]"
        End If
        If IsNotNull(FUPDATE_TERM_ID) Then
            strMsg &= "[�X�V�[��ID:" & FUPDATE_TERM_ID & "]"
        End If
        If IsNotNull(FUPDATE_USER_ID) Then
            strMsg &= "[�X�Vհ�ްID:" & FUPDATE_USER_ID & "]"
        End If
        If IsNotNull(FUPDATE_USER_NAME) Then
            strMsg &= "[�X�Vհ�ް��:" & FUPDATE_USER_NAME & "]"
        End If
        If IsNotNull(FUPDATE_DT) Then
            strMsg &= "[�X�V����:" & FUPDATE_DT & "]"
        End If
        If IsNotNull(XABC_KANRI) Then
            strMsg &= "[ABC�Ǘ�:" & XABC_KANRI & "]"
        End If
        If IsNotNull(XPLANE_PACK_NUMBER) Then
            strMsg &= "[���ʍ���:" & XPLANE_PACK_NUMBER & "]"
        End If
        If IsNotNull(XWEIGHT_IN_CASE) Then
            strMsg &= "[���d��:" & XWEIGHT_IN_CASE & "]"
        End If
        If IsNotNull(XWEIGHT_IN_PALLET) Then
            strMsg &= "[��گĂ�����̏d��:" & XWEIGHT_IN_PALLET & "]"
        End If
        If IsNotNull(XHEIGHT_IN_CASE) Then
            strMsg &= "[������:" & XHEIGHT_IN_CASE & "]"
        End If
        If IsNotNull(XHEIGHT_IN_PALLET) Then
            strMsg &= "[��گč���:" & XHEIGHT_IN_PALLET & "]"
        End If
        If IsNotNull(XARTICLE_TYPE_CODE) Then
            strMsg &= "[�i�ڎ��(���i�敪):" & XARTICLE_TYPE_CODE & "]"
        End If
        If IsNotNull(X24H_KENSA_AUTO_FLG) Then
            strMsg &= "[24H�������ʎ����w��:" & X24H_KENSA_AUTO_FLG & "]"
        End If
        If IsNotNull(XHINMEI_CD) Then
            strMsg &= "[�i�ں���(�����i�ں���):" & XHINMEI_CD & "]"
        End If
        If IsNotNull(XSUB_CD) Then
            strMsg &= "[��޺���:" & XSUB_CD & "]"
        End If
        If IsNotNull(XITF_CD) Then
            strMsg &= "[ITF����:" & XITF_CD & "]"
        End If
        If IsNotNull(XJAN_CD) Then
            strMsg &= "[JAN����:" & XJAN_CD & "]"
        End If
        If IsNotNull(XMAKER_CD) Then
            strMsg &= "[Ұ�-����:" & XMAKER_CD & "]"
        End If
        If IsNotNull(FRAC_BUNRUI) Then
            strMsg &= "[�I����:" & FRAC_BUNRUI & "]"
        End If
        If IsNotNull(XDAN_IN_PALLET) Then
            strMsg &= "[1��گĂ̒i��:" & XDAN_IN_PALLET & "]"
        End If
        If IsNotNull(XIN_RES_TYPE) Then
            strMsg &= "[�i�ڕʋ�I��������:" & XIN_RES_TYPE & "]"
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
