'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' �y���́zMaterialStreamð��ٸ׽
' �y�@�\�z�o�׎w��ð��ٸ׽
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
''' �o�׎w��ð��ٸ׽
''' </summary>
Public Class TBL_XPLN_OUT
    Inherits clsTemplateTable

    '**********************************************************************************************
    '����������������
#Region "  �׽�ϐ���`                  "
    '�����è
    Private mobjAryMe As TBL_XPLN_OUT()                                          '�o�׎w��
    Private mstrUSER_SQL As String                                               'հ�ްSQL
    Private mORDER_BY As String                                                  'OrderBy��
    Private mWHERE As String                                                     'Where��
    Private mXSYUKKA_D As Nullable(Of Date)                                      '�o�ד�
    Private mXHENSEI_NO As String                                                '�Ґ�No.
    Private mXDATA_KIND As String                                                '�ް����
    Private mXEDIT_KBN As String                                                 '�ҏW�敪
    Private mXINPUT_PLACE As String                                              '���߯ďꏊ
    Private mXINPUT_DT As Nullable(Of Date)                                      '���߯ē��t
    Private mXINPUT_NO As String                                                 '���߯�No.
    Private mXDENPYOU_NO As String                                               '�`�[No.
    Private mXBUNRUI_NO As String                                                '����No.
    Private mXDATA_DT As Nullable(Of Date)                                       '�ް����t
    Private mXSOUKO_CD As String                                                 '�q�ɺ���
    Private mXTOU_NO As String                                                   '������
    Private mXTORIHIKI_KBN As String                                             '����敪
    Private mXDATA_SYORI As String                                               '�ް�����
    Private mXGYOUSYA_CD As String                                               '�����ƎҺ���
    Private mXGYOUSYA_KBN As String                                              '�Ǝҋ敪
    Private mXSYARYOU_NO As Nullable(Of Integer)                                 '���q�ԍ�
    Private mXUNKOU_NO As String                                                 '�q�ɕʉ^�sNo.
    Private mXTUMI_HOUKOU As Nullable(Of Integer)                                '�ύ�����
    Private mXTUMI_HOUHOU As Nullable(Of Integer)                                '�ύ����@
    Private mXSYASYU_KBN As String                                               '�Ԏ�敪
    Private mXHENSEI_NO_OYA As String                                            '�e�Ґ�No.
    Private mXSEND_NAME As String                                                '�͂��於��
    Private mXSEND_ADDRESS As String                                             '�͂���Z��
    Private mXBERTH_NO As String                                                 '�ް�No.
    Private mXKINKYU_KBN As Nullable(Of Integer)                                 '�ً}�o�׋敪
    Private mXKINKYU_LEVEL As Nullable(Of Integer)                               '�ً}�x
    Private mXSYARYOU_ENTRY_DT As Nullable(Of Date)                              '���q��t����
    Private mXSYUKKA_DIR_DT As Nullable(Of Date)                                 '�o�׎w������
    Private mXOUT_START_DT As Nullable(Of Date)                                  '�o�ɊJ�n����
    Private mXOUT_END_DT As Nullable(Of Date)                                    '�o�Ɋ�������
    Private mXTUMI_END_DT As Nullable(Of Date)                                   '�ύ���������
    Private mXSYUKKA_STS As Nullable(Of Integer)                                 '�o�׏�
    Private mXIKKATU_SYUKKO As Nullable(Of Integer)                              '�ꊇ�o�Ɏw��
    Private mFENTRY_DT As Nullable(Of Date)                                      '�o�^����
#End Region
#Region "  �����è��`                  "
    ''' <summary>
    ''' ���ѕϐ� (���׽�^�z��)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_XPLN_OUT()
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
    ''' �ް����
    ''' </summary>
    Public Property XDATA_KIND() As String
        Get
            Return mXDATA_KIND
        End Get
        Set(ByVal Value As String)
            mXDATA_KIND = Value
        End Set
    End Property
    ''' <summary>
    ''' �ҏW�敪
    ''' </summary>
    Public Property XEDIT_KBN() As String
        Get
            Return mXEDIT_KBN
        End Get
        Set(ByVal Value As String)
            mXEDIT_KBN = Value
        End Set
    End Property
    ''' <summary>
    ''' ���߯ďꏊ
    ''' </summary>
    Public Property XINPUT_PLACE() As String
        Get
            Return mXINPUT_PLACE
        End Get
        Set(ByVal Value As String)
            mXINPUT_PLACE = Value
        End Set
    End Property
    ''' <summary>
    ''' ���߯ē��t
    ''' </summary>
    Public Property XINPUT_DT() As Nullable(Of Date)
        Get
            Return mXINPUT_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mXINPUT_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' ���߯�No.
    ''' </summary>
    Public Property XINPUT_NO() As String
        Get
            Return mXINPUT_NO
        End Get
        Set(ByVal Value As String)
            mXINPUT_NO = Value
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
    ''' ����No.
    ''' </summary>
    Public Property XBUNRUI_NO() As String
        Get
            Return mXBUNRUI_NO
        End Get
        Set(ByVal Value As String)
            mXBUNRUI_NO = Value
        End Set
    End Property
    ''' <summary>
    ''' �ް����t
    ''' </summary>
    Public Property XDATA_DT() As Nullable(Of Date)
        Get
            Return mXDATA_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mXDATA_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' �q�ɺ���
    ''' </summary>
    Public Property XSOUKO_CD() As String
        Get
            Return mXSOUKO_CD
        End Get
        Set(ByVal Value As String)
            mXSOUKO_CD = Value
        End Set
    End Property
    ''' <summary>
    ''' ������
    ''' </summary>
    Public Property XTOU_NO() As String
        Get
            Return mXTOU_NO
        End Get
        Set(ByVal Value As String)
            mXTOU_NO = Value
        End Set
    End Property
    ''' <summary>
    ''' ����敪
    ''' </summary>
    Public Property XTORIHIKI_KBN() As String
        Get
            Return mXTORIHIKI_KBN
        End Get
        Set(ByVal Value As String)
            mXTORIHIKI_KBN = Value
        End Set
    End Property
    ''' <summary>
    ''' �ް�����
    ''' </summary>
    Public Property XDATA_SYORI() As String
        Get
            Return mXDATA_SYORI
        End Get
        Set(ByVal Value As String)
            mXDATA_SYORI = Value
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
    ''' �Ǝҋ敪
    ''' </summary>
    Public Property XGYOUSYA_KBN() As String
        Get
            Return mXGYOUSYA_KBN
        End Get
        Set(ByVal Value As String)
            mXGYOUSYA_KBN = Value
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
    ''' �͂���Z��
    ''' </summary>
    Public Property XSEND_ADDRESS() As String
        Get
            Return mXSEND_ADDRESS
        End Get
        Set(ByVal Value As String)
            mXSEND_ADDRESS = Value
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
    ''' �ً}�o�׋敪
    ''' </summary>
    Public Property XKINKYU_KBN() As Nullable(Of Integer)
        Get
            Return mXKINKYU_KBN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXKINKYU_KBN = Value
        End Set
    End Property
    ''' <summary>
    ''' �ً}�x
    ''' </summary>
    Public Property XKINKYU_LEVEL() As Nullable(Of Integer)
        Get
            Return mXKINKYU_LEVEL
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXKINKYU_LEVEL = Value
        End Set
    End Property
    ''' <summary>
    ''' ���q��t����
    ''' </summary>
    Public Property XSYARYOU_ENTRY_DT() As Nullable(Of Date)
        Get
            Return mXSYARYOU_ENTRY_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mXSYARYOU_ENTRY_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' �o�׎w������
    ''' </summary>
    Public Property XSYUKKA_DIR_DT() As Nullable(Of Date)
        Get
            Return mXSYUKKA_DIR_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mXSYUKKA_DIR_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' �o�ɊJ�n����
    ''' </summary>
    Public Property XOUT_START_DT() As Nullable(Of Date)
        Get
            Return mXOUT_START_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mXOUT_START_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' �o�Ɋ�������
    ''' </summary>
    Public Property XOUT_END_DT() As Nullable(Of Date)
        Get
            Return mXOUT_END_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mXOUT_END_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' �ύ���������
    ''' </summary>
    Public Property XTUMI_END_DT() As Nullable(Of Date)
        Get
            Return mXTUMI_END_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mXTUMI_END_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' �o�׏�
    ''' </summary>
    Public Property XSYUKKA_STS() As Nullable(Of Integer)
        Get
            Return mXSYUKKA_STS
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXSYUKKA_STS = Value
        End Set
    End Property
    ''' <summary>
    ''' �ꊇ�o�Ɏw��
    ''' </summary>
    Public Property XIKKATU_SYUKKO() As Nullable(Of Integer)
        Get
            Return mXIKKATU_SYUKKO
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXIKKATU_SYUKKO = Value
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
    Public Function GET_XPLN_OUT(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    XPLN_OUT")
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
        If IsNull(XDATA_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDATA_KIND
            strSQL.Append(vbCrLf & "    AND XDATA_KIND = :" & UBound(strBindField) - 1 & " --�ް����")
        End If
        If IsNull(XEDIT_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEDIT_KBN
            strSQL.Append(vbCrLf & "    AND XEDIT_KBN = :" & UBound(strBindField) - 1 & " --�ҏW�敪")
        End If
        If IsNull(XINPUT_PLACE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXINPUT_PLACE
            strSQL.Append(vbCrLf & "    AND XINPUT_PLACE = :" & UBound(strBindField) - 1 & " --���߯ďꏊ")
        End If
        If IsNull(XINPUT_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXINPUT_DT
            strSQL.Append(vbCrLf & "    AND XINPUT_DT = :" & UBound(strBindField) - 1 & " --���߯ē��t")
        End If
        If IsNull(XINPUT_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXINPUT_NO
            strSQL.Append(vbCrLf & "    AND XINPUT_NO = :" & UBound(strBindField) - 1 & " --���߯�No.")
        End If
        If IsNull(XDENPYOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDENPYOU_NO
            strSQL.Append(vbCrLf & "    AND XDENPYOU_NO = :" & UBound(strBindField) - 1 & " --�`�[No.")
        End If
        If IsNull(XBUNRUI_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBUNRUI_NO
            strSQL.Append(vbCrLf & "    AND XBUNRUI_NO = :" & UBound(strBindField) - 1 & " --����No.")
        End If
        If IsNull(XDATA_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDATA_DT
            strSQL.Append(vbCrLf & "    AND XDATA_DT = :" & UBound(strBindField) - 1 & " --�ް����t")
        End If
        If IsNull(XSOUKO_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSOUKO_CD
            strSQL.Append(vbCrLf & "    AND XSOUKO_CD = :" & UBound(strBindField) - 1 & " --�q�ɺ���")
        End If
        If IsNull(XTOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTOU_NO
            strSQL.Append(vbCrLf & "    AND XTOU_NO = :" & UBound(strBindField) - 1 & " --������")
        End If
        If IsNull(XTORIHIKI_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTORIHIKI_KBN
            strSQL.Append(vbCrLf & "    AND XTORIHIKI_KBN = :" & UBound(strBindField) - 1 & " --����敪")
        End If
        If IsNull(XDATA_SYORI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDATA_SYORI
            strSQL.Append(vbCrLf & "    AND XDATA_SYORI = :" & UBound(strBindField) - 1 & " --�ް�����")
        End If
        If IsNull(XGYOUSYA_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_CD
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_CD = :" & UBound(strBindField) - 1 & " --�����ƎҺ���")
        End If
        If IsNull(XGYOUSYA_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_KBN
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_KBN = :" & UBound(strBindField) - 1 & " --�Ǝҋ敪")
        End If
        If IsNull(XSYARYOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYARYOU_NO
            strSQL.Append(vbCrLf & "    AND XSYARYOU_NO = :" & UBound(strBindField) - 1 & " --���q�ԍ�")
        End If
        If IsNull(XUNKOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXUNKOU_NO
            strSQL.Append(vbCrLf & "    AND XUNKOU_NO = :" & UBound(strBindField) - 1 & " --�q�ɕʉ^�sNo.")
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
        If IsNull(XSYASYU_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYASYU_KBN
            strSQL.Append(vbCrLf & "    AND XSYASYU_KBN = :" & UBound(strBindField) - 1 & " --�Ԏ�敪")
        End If
        If IsNull(XHENSEI_NO_OYA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO_OYA = :" & UBound(strBindField) - 1 & " --�e�Ґ�No.")
        End If
        If IsNull(XSEND_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSEND_NAME
            strSQL.Append(vbCrLf & "    AND XSEND_NAME = :" & UBound(strBindField) - 1 & " --�͂��於��")
        End If
        If IsNull(XSEND_ADDRESS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSEND_ADDRESS
            strSQL.Append(vbCrLf & "    AND XSEND_ADDRESS = :" & UBound(strBindField) - 1 & " --�͂���Z��")
        End If
        If IsNull(XBERTH_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_NO
            strSQL.Append(vbCrLf & "    AND XBERTH_NO = :" & UBound(strBindField) - 1 & " --�ް�No.")
        End If
        If IsNull(XKINKYU_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKINKYU_KBN
            strSQL.Append(vbCrLf & "    AND XKINKYU_KBN = :" & UBound(strBindField) - 1 & " --�ً}�o�׋敪")
        End If
        If IsNull(XKINKYU_LEVEL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKINKYU_LEVEL
            strSQL.Append(vbCrLf & "    AND XKINKYU_LEVEL = :" & UBound(strBindField) - 1 & " --�ً}�x")
        End If
        If IsNull(XSYARYOU_ENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYARYOU_ENTRY_DT
            strSQL.Append(vbCrLf & "    AND XSYARYOU_ENTRY_DT = :" & UBound(strBindField) - 1 & " --���q��t����")
        End If
        If IsNull(XSYUKKA_DIR_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_DIR_DT
            strSQL.Append(vbCrLf & "    AND XSYUKKA_DIR_DT = :" & UBound(strBindField) - 1 & " --�o�׎w������")
        End If
        If IsNull(XOUT_START_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_START_DT
            strSQL.Append(vbCrLf & "    AND XOUT_START_DT = :" & UBound(strBindField) - 1 & " --�o�ɊJ�n����")
        End If
        If IsNull(XOUT_END_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_END_DT
            strSQL.Append(vbCrLf & "    AND XOUT_END_DT = :" & UBound(strBindField) - 1 & " --�o�Ɋ�������")
        End If
        If IsNull(XTUMI_END_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_END_DT
            strSQL.Append(vbCrLf & "    AND XTUMI_END_DT = :" & UBound(strBindField) - 1 & " --�ύ���������")
        End If
        If IsNull(XSYUKKA_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_STS
            strSQL.Append(vbCrLf & "    AND XSYUKKA_STS = :" & UBound(strBindField) - 1 & " --�o�׏�")
        End If
        If IsNull(XIKKATU_SYUKKO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIKKATU_SYUKKO
            strSQL.Append(vbCrLf & "    AND XIKKATU_SYUKKO = :" & UBound(strBindField) - 1 & " --�ꊇ�o�Ɏw��")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --�o�^����")
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
        strDataSetName = "XPLN_OUT"
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
    Public Function GET_XPLN_OUT_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    XPLN_OUT")
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
        If IsNull(XDATA_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDATA_KIND
            strSQL.Append(vbCrLf & "    AND XDATA_KIND = :" & UBound(strBindField) - 1 & " --�ް����")
        End If
        If IsNull(XEDIT_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEDIT_KBN
            strSQL.Append(vbCrLf & "    AND XEDIT_KBN = :" & UBound(strBindField) - 1 & " --�ҏW�敪")
        End If
        If IsNull(XINPUT_PLACE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXINPUT_PLACE
            strSQL.Append(vbCrLf & "    AND XINPUT_PLACE = :" & UBound(strBindField) - 1 & " --���߯ďꏊ")
        End If
        If IsNull(XINPUT_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXINPUT_DT
            strSQL.Append(vbCrLf & "    AND XINPUT_DT = :" & UBound(strBindField) - 1 & " --���߯ē��t")
        End If
        If IsNull(XINPUT_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXINPUT_NO
            strSQL.Append(vbCrLf & "    AND XINPUT_NO = :" & UBound(strBindField) - 1 & " --���߯�No.")
        End If
        If IsNull(XDENPYOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDENPYOU_NO
            strSQL.Append(vbCrLf & "    AND XDENPYOU_NO = :" & UBound(strBindField) - 1 & " --�`�[No.")
        End If
        If IsNull(XBUNRUI_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBUNRUI_NO
            strSQL.Append(vbCrLf & "    AND XBUNRUI_NO = :" & UBound(strBindField) - 1 & " --����No.")
        End If
        If IsNull(XDATA_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDATA_DT
            strSQL.Append(vbCrLf & "    AND XDATA_DT = :" & UBound(strBindField) - 1 & " --�ް����t")
        End If
        If IsNull(XSOUKO_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSOUKO_CD
            strSQL.Append(vbCrLf & "    AND XSOUKO_CD = :" & UBound(strBindField) - 1 & " --�q�ɺ���")
        End If
        If IsNull(XTOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTOU_NO
            strSQL.Append(vbCrLf & "    AND XTOU_NO = :" & UBound(strBindField) - 1 & " --������")
        End If
        If IsNull(XTORIHIKI_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTORIHIKI_KBN
            strSQL.Append(vbCrLf & "    AND XTORIHIKI_KBN = :" & UBound(strBindField) - 1 & " --����敪")
        End If
        If IsNull(XDATA_SYORI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDATA_SYORI
            strSQL.Append(vbCrLf & "    AND XDATA_SYORI = :" & UBound(strBindField) - 1 & " --�ް�����")
        End If
        If IsNull(XGYOUSYA_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_CD
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_CD = :" & UBound(strBindField) - 1 & " --�����ƎҺ���")
        End If
        If IsNull(XGYOUSYA_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_KBN
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_KBN = :" & UBound(strBindField) - 1 & " --�Ǝҋ敪")
        End If
        If IsNull(XSYARYOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYARYOU_NO
            strSQL.Append(vbCrLf & "    AND XSYARYOU_NO = :" & UBound(strBindField) - 1 & " --���q�ԍ�")
        End If
        If IsNull(XUNKOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXUNKOU_NO
            strSQL.Append(vbCrLf & "    AND XUNKOU_NO = :" & UBound(strBindField) - 1 & " --�q�ɕʉ^�sNo.")
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
        If IsNull(XSYASYU_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYASYU_KBN
            strSQL.Append(vbCrLf & "    AND XSYASYU_KBN = :" & UBound(strBindField) - 1 & " --�Ԏ�敪")
        End If
        If IsNull(XHENSEI_NO_OYA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO_OYA = :" & UBound(strBindField) - 1 & " --�e�Ґ�No.")
        End If
        If IsNull(XSEND_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSEND_NAME
            strSQL.Append(vbCrLf & "    AND XSEND_NAME = :" & UBound(strBindField) - 1 & " --�͂��於��")
        End If
        If IsNull(XSEND_ADDRESS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSEND_ADDRESS
            strSQL.Append(vbCrLf & "    AND XSEND_ADDRESS = :" & UBound(strBindField) - 1 & " --�͂���Z��")
        End If
        If IsNull(XBERTH_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_NO
            strSQL.Append(vbCrLf & "    AND XBERTH_NO = :" & UBound(strBindField) - 1 & " --�ް�No.")
        End If
        If IsNull(XKINKYU_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKINKYU_KBN
            strSQL.Append(vbCrLf & "    AND XKINKYU_KBN = :" & UBound(strBindField) - 1 & " --�ً}�o�׋敪")
        End If
        If IsNull(XKINKYU_LEVEL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKINKYU_LEVEL
            strSQL.Append(vbCrLf & "    AND XKINKYU_LEVEL = :" & UBound(strBindField) - 1 & " --�ً}�x")
        End If
        If IsNull(XSYARYOU_ENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYARYOU_ENTRY_DT
            strSQL.Append(vbCrLf & "    AND XSYARYOU_ENTRY_DT = :" & UBound(strBindField) - 1 & " --���q��t����")
        End If
        If IsNull(XSYUKKA_DIR_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_DIR_DT
            strSQL.Append(vbCrLf & "    AND XSYUKKA_DIR_DT = :" & UBound(strBindField) - 1 & " --�o�׎w������")
        End If
        If IsNull(XOUT_START_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_START_DT
            strSQL.Append(vbCrLf & "    AND XOUT_START_DT = :" & UBound(strBindField) - 1 & " --�o�ɊJ�n����")
        End If
        If IsNull(XOUT_END_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_END_DT
            strSQL.Append(vbCrLf & "    AND XOUT_END_DT = :" & UBound(strBindField) - 1 & " --�o�Ɋ�������")
        End If
        If IsNull(XTUMI_END_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_END_DT
            strSQL.Append(vbCrLf & "    AND XTUMI_END_DT = :" & UBound(strBindField) - 1 & " --�ύ���������")
        End If
        If IsNull(XSYUKKA_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_STS
            strSQL.Append(vbCrLf & "    AND XSYUKKA_STS = :" & UBound(strBindField) - 1 & " --�o�׏�")
        End If
        If IsNull(XIKKATU_SYUKKO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIKKATU_SYUKKO
            strSQL.Append(vbCrLf & "    AND XIKKATU_SYUKKO = :" & UBound(strBindField) - 1 & " --�ꊇ�o�Ɏw��")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --�o�^����")
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
        strDataSetName = "XPLN_OUT"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XPLN_OUT(Owner, objDb, objDbLog)
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
    Public Function GET_XPLN_OUT_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "XPLN_OUT"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XPLN_OUT(Owner, objDb, objDbLog)
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
    Public Function GET_XPLN_OUT_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    XPLN_OUT")
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
        If IsNull(XDATA_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDATA_KIND
            strSQL.Append(vbCrLf & "    AND XDATA_KIND = :" & UBound(strBindField) - 1 & " --�ް����")
        End If
        If IsNull(XEDIT_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEDIT_KBN
            strSQL.Append(vbCrLf & "    AND XEDIT_KBN = :" & UBound(strBindField) - 1 & " --�ҏW�敪")
        End If
        If IsNull(XINPUT_PLACE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXINPUT_PLACE
            strSQL.Append(vbCrLf & "    AND XINPUT_PLACE = :" & UBound(strBindField) - 1 & " --���߯ďꏊ")
        End If
        If IsNull(XINPUT_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXINPUT_DT
            strSQL.Append(vbCrLf & "    AND XINPUT_DT = :" & UBound(strBindField) - 1 & " --���߯ē��t")
        End If
        If IsNull(XINPUT_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXINPUT_NO
            strSQL.Append(vbCrLf & "    AND XINPUT_NO = :" & UBound(strBindField) - 1 & " --���߯�No.")
        End If
        If IsNull(XDENPYOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDENPYOU_NO
            strSQL.Append(vbCrLf & "    AND XDENPYOU_NO = :" & UBound(strBindField) - 1 & " --�`�[No.")
        End If
        If IsNull(XBUNRUI_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBUNRUI_NO
            strSQL.Append(vbCrLf & "    AND XBUNRUI_NO = :" & UBound(strBindField) - 1 & " --����No.")
        End If
        If IsNull(XDATA_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDATA_DT
            strSQL.Append(vbCrLf & "    AND XDATA_DT = :" & UBound(strBindField) - 1 & " --�ް����t")
        End If
        If IsNull(XSOUKO_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSOUKO_CD
            strSQL.Append(vbCrLf & "    AND XSOUKO_CD = :" & UBound(strBindField) - 1 & " --�q�ɺ���")
        End If
        If IsNull(XTOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTOU_NO
            strSQL.Append(vbCrLf & "    AND XTOU_NO = :" & UBound(strBindField) - 1 & " --������")
        End If
        If IsNull(XTORIHIKI_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTORIHIKI_KBN
            strSQL.Append(vbCrLf & "    AND XTORIHIKI_KBN = :" & UBound(strBindField) - 1 & " --����敪")
        End If
        If IsNull(XDATA_SYORI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDATA_SYORI
            strSQL.Append(vbCrLf & "    AND XDATA_SYORI = :" & UBound(strBindField) - 1 & " --�ް�����")
        End If
        If IsNull(XGYOUSYA_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_CD
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_CD = :" & UBound(strBindField) - 1 & " --�����ƎҺ���")
        End If
        If IsNull(XGYOUSYA_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_KBN
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_KBN = :" & UBound(strBindField) - 1 & " --�Ǝҋ敪")
        End If
        If IsNull(XSYARYOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYARYOU_NO
            strSQL.Append(vbCrLf & "    AND XSYARYOU_NO = :" & UBound(strBindField) - 1 & " --���q�ԍ�")
        End If
        If IsNull(XUNKOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXUNKOU_NO
            strSQL.Append(vbCrLf & "    AND XUNKOU_NO = :" & UBound(strBindField) - 1 & " --�q�ɕʉ^�sNo.")
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
        If IsNull(XSYASYU_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYASYU_KBN
            strSQL.Append(vbCrLf & "    AND XSYASYU_KBN = :" & UBound(strBindField) - 1 & " --�Ԏ�敪")
        End If
        If IsNull(XHENSEI_NO_OYA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO_OYA = :" & UBound(strBindField) - 1 & " --�e�Ґ�No.")
        End If
        If IsNull(XSEND_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSEND_NAME
            strSQL.Append(vbCrLf & "    AND XSEND_NAME = :" & UBound(strBindField) - 1 & " --�͂��於��")
        End If
        If IsNull(XSEND_ADDRESS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSEND_ADDRESS
            strSQL.Append(vbCrLf & "    AND XSEND_ADDRESS = :" & UBound(strBindField) - 1 & " --�͂���Z��")
        End If
        If IsNull(XBERTH_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_NO
            strSQL.Append(vbCrLf & "    AND XBERTH_NO = :" & UBound(strBindField) - 1 & " --�ް�No.")
        End If
        If IsNull(XKINKYU_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKINKYU_KBN
            strSQL.Append(vbCrLf & "    AND XKINKYU_KBN = :" & UBound(strBindField) - 1 & " --�ً}�o�׋敪")
        End If
        If IsNull(XKINKYU_LEVEL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKINKYU_LEVEL
            strSQL.Append(vbCrLf & "    AND XKINKYU_LEVEL = :" & UBound(strBindField) - 1 & " --�ً}�x")
        End If
        If IsNull(XSYARYOU_ENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYARYOU_ENTRY_DT
            strSQL.Append(vbCrLf & "    AND XSYARYOU_ENTRY_DT = :" & UBound(strBindField) - 1 & " --���q��t����")
        End If
        If IsNull(XSYUKKA_DIR_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_DIR_DT
            strSQL.Append(vbCrLf & "    AND XSYUKKA_DIR_DT = :" & UBound(strBindField) - 1 & " --�o�׎w������")
        End If
        If IsNull(XOUT_START_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_START_DT
            strSQL.Append(vbCrLf & "    AND XOUT_START_DT = :" & UBound(strBindField) - 1 & " --�o�ɊJ�n����")
        End If
        If IsNull(XOUT_END_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_END_DT
            strSQL.Append(vbCrLf & "    AND XOUT_END_DT = :" & UBound(strBindField) - 1 & " --�o�Ɋ�������")
        End If
        If IsNull(XTUMI_END_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_END_DT
            strSQL.Append(vbCrLf & "    AND XTUMI_END_DT = :" & UBound(strBindField) - 1 & " --�ύ���������")
        End If
        If IsNull(XSYUKKA_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_STS
            strSQL.Append(vbCrLf & "    AND XSYUKKA_STS = :" & UBound(strBindField) - 1 & " --�o�׏�")
        End If
        If IsNull(XIKKATU_SYUKKO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIKKATU_SYUKKO
            strSQL.Append(vbCrLf & "    AND XIKKATU_SYUKKO = :" & UBound(strBindField) - 1 & " --�ꊇ�o�Ɏw��")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --�o�^����")
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
        strDataSetName = "XPLN_OUT"
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
    Public Sub UPDATE_XPLN_OUT()
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
        End If


        '***********************
        '�X�VSQL�쐬
        '***********************
        strBindField = Nothing
        objBindValue = Nothing
        ReDim Preserve strBindField(0)
        ReDim Preserve objBindValue(0)
        strSQL.Append(vbCrLf & "UPDATE")
        strSQL.Append(vbCrLf & "    XPLN_OUT")
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
        If IsNull(mXDATA_KIND) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDATA_KIND = NULL --�ް����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDATA_KIND = NULL --�ް����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDATA_KIND
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDATA_KIND = :" & Ubound(strBindField) - 1 & " --�ް����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDATA_KIND = :" & Ubound(strBindField) - 1 & " --�ް����")
        End If
        intCount = intCount + 1
        If IsNull(mXEDIT_KBN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEDIT_KBN = NULL --�ҏW�敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEDIT_KBN = NULL --�ҏW�敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEDIT_KBN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEDIT_KBN = :" & Ubound(strBindField) - 1 & " --�ҏW�敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEDIT_KBN = :" & Ubound(strBindField) - 1 & " --�ҏW�敪")
        End If
        intCount = intCount + 1
        If IsNull(mXINPUT_PLACE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XINPUT_PLACE = NULL --���߯ďꏊ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XINPUT_PLACE = NULL --���߯ďꏊ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXINPUT_PLACE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XINPUT_PLACE = :" & Ubound(strBindField) - 1 & " --���߯ďꏊ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XINPUT_PLACE = :" & Ubound(strBindField) - 1 & " --���߯ďꏊ")
        End If
        intCount = intCount + 1
        If IsNull(mXINPUT_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XINPUT_DT = NULL --���߯ē��t")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XINPUT_DT = NULL --���߯ē��t")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXINPUT_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XINPUT_DT = :" & Ubound(strBindField) - 1 & " --���߯ē��t")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XINPUT_DT = :" & Ubound(strBindField) - 1 & " --���߯ē��t")
        End If
        intCount = intCount + 1
        If IsNull(mXINPUT_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XINPUT_NO = NULL --���߯�No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XINPUT_NO = NULL --���߯�No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXINPUT_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XINPUT_NO = :" & Ubound(strBindField) - 1 & " --���߯�No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XINPUT_NO = :" & Ubound(strBindField) - 1 & " --���߯�No.")
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
        If IsNull(mXBUNRUI_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XBUNRUI_NO = NULL --����No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XBUNRUI_NO = NULL --����No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBUNRUI_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XBUNRUI_NO = :" & Ubound(strBindField) - 1 & " --����No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XBUNRUI_NO = :" & Ubound(strBindField) - 1 & " --����No.")
        End If
        intCount = intCount + 1
        If IsNull(mXDATA_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDATA_DT = NULL --�ް����t")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDATA_DT = NULL --�ް����t")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDATA_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDATA_DT = :" & Ubound(strBindField) - 1 & " --�ް����t")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDATA_DT = :" & Ubound(strBindField) - 1 & " --�ް����t")
        End If
        intCount = intCount + 1
        If IsNull(mXSOUKO_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSOUKO_CD = NULL --�q�ɺ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSOUKO_CD = NULL --�q�ɺ���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSOUKO_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSOUKO_CD = :" & Ubound(strBindField) - 1 & " --�q�ɺ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSOUKO_CD = :" & Ubound(strBindField) - 1 & " --�q�ɺ���")
        End If
        intCount = intCount + 1
        If IsNull(mXTOU_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTOU_NO = NULL --������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTOU_NO = NULL --������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTOU_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTOU_NO = :" & Ubound(strBindField) - 1 & " --������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTOU_NO = :" & Ubound(strBindField) - 1 & " --������")
        End If
        intCount = intCount + 1
        If IsNull(mXTORIHIKI_KBN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTORIHIKI_KBN = NULL --����敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTORIHIKI_KBN = NULL --����敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTORIHIKI_KBN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTORIHIKI_KBN = :" & Ubound(strBindField) - 1 & " --����敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTORIHIKI_KBN = :" & Ubound(strBindField) - 1 & " --����敪")
        End If
        intCount = intCount + 1
        If IsNull(mXDATA_SYORI) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDATA_SYORI = NULL --�ް�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDATA_SYORI = NULL --�ް�����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDATA_SYORI
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDATA_SYORI = :" & Ubound(strBindField) - 1 & " --�ް�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDATA_SYORI = :" & Ubound(strBindField) - 1 & " --�ް�����")
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
        If IsNull(mXGYOUSYA_KBN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XGYOUSYA_KBN = NULL --�Ǝҋ敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XGYOUSYA_KBN = NULL --�Ǝҋ敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_KBN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XGYOUSYA_KBN = :" & Ubound(strBindField) - 1 & " --�Ǝҋ敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XGYOUSYA_KBN = :" & Ubound(strBindField) - 1 & " --�Ǝҋ敪")
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
        If IsNull(mXSEND_ADDRESS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSEND_ADDRESS = NULL --�͂���Z��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSEND_ADDRESS = NULL --�͂���Z��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSEND_ADDRESS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSEND_ADDRESS = :" & Ubound(strBindField) - 1 & " --�͂���Z��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSEND_ADDRESS = :" & Ubound(strBindField) - 1 & " --�͂���Z��")
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
        If IsNull(mXKINKYU_KBN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XKINKYU_KBN = NULL --�ً}�o�׋敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XKINKYU_KBN = NULL --�ً}�o�׋敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKINKYU_KBN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XKINKYU_KBN = :" & Ubound(strBindField) - 1 & " --�ً}�o�׋敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XKINKYU_KBN = :" & Ubound(strBindField) - 1 & " --�ً}�o�׋敪")
        End If
        intCount = intCount + 1
        If IsNull(mXKINKYU_LEVEL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XKINKYU_LEVEL = NULL --�ً}�x")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XKINKYU_LEVEL = NULL --�ً}�x")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKINKYU_LEVEL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XKINKYU_LEVEL = :" & Ubound(strBindField) - 1 & " --�ً}�x")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XKINKYU_LEVEL = :" & Ubound(strBindField) - 1 & " --�ً}�x")
        End If
        intCount = intCount + 1
        If IsNull(mXSYARYOU_ENTRY_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYARYOU_ENTRY_DT = NULL --���q��t����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYARYOU_ENTRY_DT = NULL --���q��t����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYARYOU_ENTRY_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYARYOU_ENTRY_DT = :" & Ubound(strBindField) - 1 & " --���q��t����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYARYOU_ENTRY_DT = :" & Ubound(strBindField) - 1 & " --���q��t����")
        End If
        intCount = intCount + 1
        If IsNull(mXSYUKKA_DIR_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_DIR_DT = NULL --�o�׎w������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_DIR_DT = NULL --�o�׎w������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_DIR_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_DIR_DT = :" & Ubound(strBindField) - 1 & " --�o�׎w������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_DIR_DT = :" & Ubound(strBindField) - 1 & " --�o�׎w������")
        End If
        intCount = intCount + 1
        If IsNull(mXOUT_START_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XOUT_START_DT = NULL --�o�ɊJ�n����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XOUT_START_DT = NULL --�o�ɊJ�n����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_START_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XOUT_START_DT = :" & Ubound(strBindField) - 1 & " --�o�ɊJ�n����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XOUT_START_DT = :" & Ubound(strBindField) - 1 & " --�o�ɊJ�n����")
        End If
        intCount = intCount + 1
        If IsNull(mXOUT_END_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XOUT_END_DT = NULL --�o�Ɋ�������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XOUT_END_DT = NULL --�o�Ɋ�������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_END_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XOUT_END_DT = :" & Ubound(strBindField) - 1 & " --�o�Ɋ�������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XOUT_END_DT = :" & Ubound(strBindField) - 1 & " --�o�Ɋ�������")
        End If
        intCount = intCount + 1
        If IsNull(mXTUMI_END_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTUMI_END_DT = NULL --�ύ���������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTUMI_END_DT = NULL --�ύ���������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_END_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTUMI_END_DT = :" & Ubound(strBindField) - 1 & " --�ύ���������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTUMI_END_DT = :" & Ubound(strBindField) - 1 & " --�ύ���������")
        End If
        intCount = intCount + 1
        If IsNull(mXSYUKKA_STS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_STS = NULL --�o�׏�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_STS = NULL --�o�׏�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_STS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_STS = :" & Ubound(strBindField) - 1 & " --�o�׏�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_STS = :" & Ubound(strBindField) - 1 & " --�o�׏�")
        End If
        intCount = intCount + 1
        If IsNull(mXIKKATU_SYUKKO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XIKKATU_SYUKKO = NULL --�ꊇ�o�Ɏw��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XIKKATU_SYUKKO = NULL --�ꊇ�o�Ɏw��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIKKATU_SYUKKO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XIKKATU_SYUKKO = :" & Ubound(strBindField) - 1 & " --�ꊇ�o�Ɏw��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XIKKATU_SYUKKO = :" & Ubound(strBindField) - 1 & " --�ꊇ�o�Ɏw��")
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
    Public Sub ADD_XPLN_OUT()
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
        End If


        '***********************
        '�ǉ�SQL�쐬
        '***********************
        strBindField = Nothing
        objBindValue = Nothing
        ReDim Preserve strBindField(0)
        ReDim Preserve objBindValue(0)
        strSQL.Append(vbCrLf & "INSERT INTO")
        strSQL.Append(vbCrLf & "    XPLN_OUT")
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
        If IsNull(mXDATA_KIND) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ް����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ް����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDATA_KIND
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ް����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ް����")
        End If
        intCount = intCount + 1
        If IsNull(mXEDIT_KBN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ҏW�敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ҏW�敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEDIT_KBN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ҏW�敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ҏW�敪")
        End If
        intCount = intCount + 1
        If IsNull(mXINPUT_PLACE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���߯ďꏊ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���߯ďꏊ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXINPUT_PLACE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���߯ďꏊ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���߯ďꏊ")
        End If
        intCount = intCount + 1
        If IsNull(mXINPUT_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���߯ē��t")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���߯ē��t")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXINPUT_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���߯ē��t")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���߯ē��t")
        End If
        intCount = intCount + 1
        If IsNull(mXINPUT_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���߯�No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���߯�No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXINPUT_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���߯�No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���߯�No.")
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
        If IsNull(mXBUNRUI_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBUNRUI_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����No.")
        End If
        intCount = intCount + 1
        If IsNull(mXDATA_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ް����t")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ް����t")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDATA_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ް����t")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ް����t")
        End If
        intCount = intCount + 1
        If IsNull(mXSOUKO_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�q�ɺ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�q�ɺ���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSOUKO_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�q�ɺ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�q�ɺ���")
        End If
        intCount = intCount + 1
        If IsNull(mXTOU_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTOU_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --������")
        End If
        intCount = intCount + 1
        If IsNull(mXTORIHIKI_KBN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTORIHIKI_KBN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����敪")
        End If
        intCount = intCount + 1
        If IsNull(mXDATA_SYORI) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ް�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ް�����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDATA_SYORI
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ް�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ް�����")
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
        If IsNull(mXGYOUSYA_KBN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�Ǝҋ敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�Ǝҋ敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_KBN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�Ǝҋ敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�Ǝҋ敪")
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
        If IsNull(mXSEND_ADDRESS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�͂���Z��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�͂���Z��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSEND_ADDRESS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�͂���Z��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�͂���Z��")
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
        If IsNull(mXKINKYU_KBN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ً}�o�׋敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ً}�o�׋敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKINKYU_KBN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ً}�o�׋敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ً}�o�׋敪")
        End If
        intCount = intCount + 1
        If IsNull(mXKINKYU_LEVEL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ً}�x")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ً}�x")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKINKYU_LEVEL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ً}�x")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ً}�x")
        End If
        intCount = intCount + 1
        If IsNull(mXSYARYOU_ENTRY_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���q��t����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���q��t����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYARYOU_ENTRY_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���q��t����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���q��t����")
        End If
        intCount = intCount + 1
        If IsNull(mXSYUKKA_DIR_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�o�׎w������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�o�׎w������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_DIR_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�o�׎w������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�o�׎w������")
        End If
        intCount = intCount + 1
        If IsNull(mXOUT_START_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�o�ɊJ�n����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�o�ɊJ�n����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_START_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�o�ɊJ�n����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�o�ɊJ�n����")
        End If
        intCount = intCount + 1
        If IsNull(mXOUT_END_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�o�Ɋ�������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�o�Ɋ�������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_END_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�o�Ɋ�������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�o�Ɋ�������")
        End If
        intCount = intCount + 1
        If IsNull(mXTUMI_END_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ύ���������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ύ���������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_END_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ύ���������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ύ���������")
        End If
        intCount = intCount + 1
        If IsNull(mXSYUKKA_STS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�o�׏�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�o�׏�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_STS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�o�׏�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�o�׏�")
        End If
        intCount = intCount + 1
        If IsNull(mXIKKATU_SYUKKO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ꊇ�o�Ɏw��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ꊇ�o�Ɏw��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIKKATU_SYUKKO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ꊇ�o�Ɏw��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ꊇ�o�Ɏw��")
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
    Public Sub DELETE_XPLN_OUT()
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
        strSQL.Append(vbCrLf & "    XPLN_OUT")
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
    Public Sub DELETE_XPLN_OUT_ANY()
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
        strSQL.Append(vbCrLf & "    XPLN_OUT")
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
        If IsNotNull(XDATA_KIND) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDATA_KIND
            strSQL.Append(vbCrLf & "    AND XDATA_KIND = :" & UBound(strBindField) - 1 & " --�ް����")
        End If
        If IsNotNull(XEDIT_KBN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEDIT_KBN
            strSQL.Append(vbCrLf & "    AND XEDIT_KBN = :" & UBound(strBindField) - 1 & " --�ҏW�敪")
        End If
        If IsNotNull(XINPUT_PLACE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXINPUT_PLACE
            strSQL.Append(vbCrLf & "    AND XINPUT_PLACE = :" & UBound(strBindField) - 1 & " --���߯ďꏊ")
        End If
        If IsNotNull(XINPUT_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXINPUT_DT
            strSQL.Append(vbCrLf & "    AND XINPUT_DT = :" & UBound(strBindField) - 1 & " --���߯ē��t")
        End If
        If IsNotNull(XINPUT_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXINPUT_NO
            strSQL.Append(vbCrLf & "    AND XINPUT_NO = :" & UBound(strBindField) - 1 & " --���߯�No.")
        End If
        If IsNotNull(XDENPYOU_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDENPYOU_NO
            strSQL.Append(vbCrLf & "    AND XDENPYOU_NO = :" & UBound(strBindField) - 1 & " --�`�[No.")
        End If
        If IsNotNull(XBUNRUI_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBUNRUI_NO
            strSQL.Append(vbCrLf & "    AND XBUNRUI_NO = :" & UBound(strBindField) - 1 & " --����No.")
        End If
        If IsNotNull(XDATA_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDATA_DT
            strSQL.Append(vbCrLf & "    AND XDATA_DT = :" & UBound(strBindField) - 1 & " --�ް����t")
        End If
        If IsNotNull(XSOUKO_CD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSOUKO_CD
            strSQL.Append(vbCrLf & "    AND XSOUKO_CD = :" & UBound(strBindField) - 1 & " --�q�ɺ���")
        End If
        If IsNotNull(XTOU_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTOU_NO
            strSQL.Append(vbCrLf & "    AND XTOU_NO = :" & UBound(strBindField) - 1 & " --������")
        End If
        If IsNotNull(XTORIHIKI_KBN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTORIHIKI_KBN
            strSQL.Append(vbCrLf & "    AND XTORIHIKI_KBN = :" & UBound(strBindField) - 1 & " --����敪")
        End If
        If IsNotNull(XDATA_SYORI) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDATA_SYORI
            strSQL.Append(vbCrLf & "    AND XDATA_SYORI = :" & UBound(strBindField) - 1 & " --�ް�����")
        End If
        If IsNotNull(XGYOUSYA_CD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_CD
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_CD = :" & UBound(strBindField) - 1 & " --�����ƎҺ���")
        End If
        If IsNotNull(XGYOUSYA_KBN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_KBN
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_KBN = :" & UBound(strBindField) - 1 & " --�Ǝҋ敪")
        End If
        If IsNotNull(XSYARYOU_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYARYOU_NO
            strSQL.Append(vbCrLf & "    AND XSYARYOU_NO = :" & UBound(strBindField) - 1 & " --���q�ԍ�")
        End If
        If IsNotNull(XUNKOU_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXUNKOU_NO
            strSQL.Append(vbCrLf & "    AND XUNKOU_NO = :" & UBound(strBindField) - 1 & " --�q�ɕʉ^�sNo.")
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
        If IsNotNull(XSYASYU_KBN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYASYU_KBN
            strSQL.Append(vbCrLf & "    AND XSYASYU_KBN = :" & UBound(strBindField) - 1 & " --�Ԏ�敪")
        End If
        If IsNotNull(XHENSEI_NO_OYA) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO_OYA = :" & UBound(strBindField) - 1 & " --�e�Ґ�No.")
        End If
        If IsNotNull(XSEND_NAME) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSEND_NAME
            strSQL.Append(vbCrLf & "    AND XSEND_NAME = :" & UBound(strBindField) - 1 & " --�͂��於��")
        End If
        If IsNotNull(XSEND_ADDRESS) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSEND_ADDRESS
            strSQL.Append(vbCrLf & "    AND XSEND_ADDRESS = :" & UBound(strBindField) - 1 & " --�͂���Z��")
        End If
        If IsNotNull(XBERTH_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_NO
            strSQL.Append(vbCrLf & "    AND XBERTH_NO = :" & UBound(strBindField) - 1 & " --�ް�No.")
        End If
        If IsNotNull(XKINKYU_KBN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKINKYU_KBN
            strSQL.Append(vbCrLf & "    AND XKINKYU_KBN = :" & UBound(strBindField) - 1 & " --�ً}�o�׋敪")
        End If
        If IsNotNull(XKINKYU_LEVEL) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKINKYU_LEVEL
            strSQL.Append(vbCrLf & "    AND XKINKYU_LEVEL = :" & UBound(strBindField) - 1 & " --�ً}�x")
        End If
        If IsNotNull(XSYARYOU_ENTRY_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYARYOU_ENTRY_DT
            strSQL.Append(vbCrLf & "    AND XSYARYOU_ENTRY_DT = :" & UBound(strBindField) - 1 & " --���q��t����")
        End If
        If IsNotNull(XSYUKKA_DIR_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_DIR_DT
            strSQL.Append(vbCrLf & "    AND XSYUKKA_DIR_DT = :" & UBound(strBindField) - 1 & " --�o�׎w������")
        End If
        If IsNotNull(XOUT_START_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_START_DT
            strSQL.Append(vbCrLf & "    AND XOUT_START_DT = :" & UBound(strBindField) - 1 & " --�o�ɊJ�n����")
        End If
        If IsNotNull(XOUT_END_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_END_DT
            strSQL.Append(vbCrLf & "    AND XOUT_END_DT = :" & UBound(strBindField) - 1 & " --�o�Ɋ�������")
        End If
        If IsNotNull(XTUMI_END_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_END_DT
            strSQL.Append(vbCrLf & "    AND XTUMI_END_DT = :" & UBound(strBindField) - 1 & " --�ύ���������")
        End If
        If IsNotNull(XSYUKKA_STS) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_STS
            strSQL.Append(vbCrLf & "    AND XSYUKKA_STS = :" & UBound(strBindField) - 1 & " --�o�׏�")
        End If
        If IsNotNull(XIKKATU_SYUKKO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIKKATU_SYUKKO
            strSQL.Append(vbCrLf & "    AND XIKKATU_SYUKKO = :" & UBound(strBindField) - 1 & " --�ꊇ�o�Ɏw��")
        End If
        If IsNotNull(FENTRY_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --�o�^����")
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
        If IsNothing(objType.GetProperty("XDATA_KIND")) = False Then mXDATA_KIND = objObject.XDATA_KIND '�ް����
        If IsNothing(objType.GetProperty("XEDIT_KBN")) = False Then mXEDIT_KBN = objObject.XEDIT_KBN '�ҏW�敪
        If IsNothing(objType.GetProperty("XINPUT_PLACE")) = False Then mXINPUT_PLACE = objObject.XINPUT_PLACE '���߯ďꏊ
        If IsNothing(objType.GetProperty("XINPUT_DT")) = False Then mXINPUT_DT = objObject.XINPUT_DT '���߯ē��t
        If IsNothing(objType.GetProperty("XINPUT_NO")) = False Then mXINPUT_NO = objObject.XINPUT_NO '���߯�No.
        If IsNothing(objType.GetProperty("XDENPYOU_NO")) = False Then mXDENPYOU_NO = objObject.XDENPYOU_NO '�`�[No.
        If IsNothing(objType.GetProperty("XBUNRUI_NO")) = False Then mXBUNRUI_NO = objObject.XBUNRUI_NO '����No.
        If IsNothing(objType.GetProperty("XDATA_DT")) = False Then mXDATA_DT = objObject.XDATA_DT '�ް����t
        If IsNothing(objType.GetProperty("XSOUKO_CD")) = False Then mXSOUKO_CD = objObject.XSOUKO_CD '�q�ɺ���
        If IsNothing(objType.GetProperty("XTOU_NO")) = False Then mXTOU_NO = objObject.XTOU_NO '������
        If IsNothing(objType.GetProperty("XTORIHIKI_KBN")) = False Then mXTORIHIKI_KBN = objObject.XTORIHIKI_KBN '����敪
        If IsNothing(objType.GetProperty("XDATA_SYORI")) = False Then mXDATA_SYORI = objObject.XDATA_SYORI '�ް�����
        If IsNothing(objType.GetProperty("XGYOUSYA_CD")) = False Then mXGYOUSYA_CD = objObject.XGYOUSYA_CD '�����ƎҺ���
        If IsNothing(objType.GetProperty("XGYOUSYA_KBN")) = False Then mXGYOUSYA_KBN = objObject.XGYOUSYA_KBN '�Ǝҋ敪
        If IsNothing(objType.GetProperty("XSYARYOU_NO")) = False Then mXSYARYOU_NO = objObject.XSYARYOU_NO '���q�ԍ�
        If IsNothing(objType.GetProperty("XUNKOU_NO")) = False Then mXUNKOU_NO = objObject.XUNKOU_NO '�q�ɕʉ^�sNo.
        If IsNothing(objType.GetProperty("XTUMI_HOUKOU")) = False Then mXTUMI_HOUKOU = objObject.XTUMI_HOUKOU '�ύ�����
        If IsNothing(objType.GetProperty("XTUMI_HOUHOU")) = False Then mXTUMI_HOUHOU = objObject.XTUMI_HOUHOU '�ύ����@
        If IsNothing(objType.GetProperty("XSYASYU_KBN")) = False Then mXSYASYU_KBN = objObject.XSYASYU_KBN '�Ԏ�敪
        If IsNothing(objType.GetProperty("XHENSEI_NO_OYA")) = False Then mXHENSEI_NO_OYA = objObject.XHENSEI_NO_OYA '�e�Ґ�No.
        If IsNothing(objType.GetProperty("XSEND_NAME")) = False Then mXSEND_NAME = objObject.XSEND_NAME '�͂��於��
        If IsNothing(objType.GetProperty("XSEND_ADDRESS")) = False Then mXSEND_ADDRESS = objObject.XSEND_ADDRESS '�͂���Z��
        If IsNothing(objType.GetProperty("XBERTH_NO")) = False Then mXBERTH_NO = objObject.XBERTH_NO '�ް�No.
        If IsNothing(objType.GetProperty("XKINKYU_KBN")) = False Then mXKINKYU_KBN = objObject.XKINKYU_KBN '�ً}�o�׋敪
        If IsNothing(objType.GetProperty("XKINKYU_LEVEL")) = False Then mXKINKYU_LEVEL = objObject.XKINKYU_LEVEL '�ً}�x
        If IsNothing(objType.GetProperty("XSYARYOU_ENTRY_DT")) = False Then mXSYARYOU_ENTRY_DT = objObject.XSYARYOU_ENTRY_DT '���q��t����
        If IsNothing(objType.GetProperty("XSYUKKA_DIR_DT")) = False Then mXSYUKKA_DIR_DT = objObject.XSYUKKA_DIR_DT '�o�׎w������
        If IsNothing(objType.GetProperty("XOUT_START_DT")) = False Then mXOUT_START_DT = objObject.XOUT_START_DT '�o�ɊJ�n����
        If IsNothing(objType.GetProperty("XOUT_END_DT")) = False Then mXOUT_END_DT = objObject.XOUT_END_DT '�o�Ɋ�������
        If IsNothing(objType.GetProperty("XTUMI_END_DT")) = False Then mXTUMI_END_DT = objObject.XTUMI_END_DT '�ύ���������
        If IsNothing(objType.GetProperty("XSYUKKA_STS")) = False Then mXSYUKKA_STS = objObject.XSYUKKA_STS '�o�׏�
        If IsNothing(objType.GetProperty("XIKKATU_SYUKKO")) = False Then mXIKKATU_SYUKKO = objObject.XIKKATU_SYUKKO '�ꊇ�o�Ɏw��
        If IsNothing(objType.GetProperty("FENTRY_DT")) = False Then mFENTRY_DT = objObject.FENTRY_DT '�o�^����

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
        mXDATA_KIND = Nothing
        mXEDIT_KBN = Nothing
        mXINPUT_PLACE = Nothing
        mXINPUT_DT = Nothing
        mXINPUT_NO = Nothing
        mXDENPYOU_NO = Nothing
        mXBUNRUI_NO = Nothing
        mXDATA_DT = Nothing
        mXSOUKO_CD = Nothing
        mXTOU_NO = Nothing
        mXTORIHIKI_KBN = Nothing
        mXDATA_SYORI = Nothing
        mXGYOUSYA_CD = Nothing
        mXGYOUSYA_KBN = Nothing
        mXSYARYOU_NO = Nothing
        mXUNKOU_NO = Nothing
        mXTUMI_HOUKOU = Nothing
        mXTUMI_HOUHOU = Nothing
        mXSYASYU_KBN = Nothing
        mXHENSEI_NO_OYA = Nothing
        mXSEND_NAME = Nothing
        mXSEND_ADDRESS = Nothing
        mXBERTH_NO = Nothing
        mXKINKYU_KBN = Nothing
        mXKINKYU_LEVEL = Nothing
        mXSYARYOU_ENTRY_DT = Nothing
        mXSYUKKA_DIR_DT = Nothing
        mXOUT_START_DT = Nothing
        mXOUT_END_DT = Nothing
        mXTUMI_END_DT = Nothing
        mXSYUKKA_STS = Nothing
        mXIKKATU_SYUKKO = Nothing
        mFENTRY_DT = Nothing


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
        mXDATA_KIND = TO_STRING_NULLABLE(objRow("XDATA_KIND"))
        mXEDIT_KBN = TO_STRING_NULLABLE(objRow("XEDIT_KBN"))
        mXINPUT_PLACE = TO_STRING_NULLABLE(objRow("XINPUT_PLACE"))
        mXINPUT_DT = TO_DATE_NULLABLE(objRow("XINPUT_DT"))
        mXINPUT_NO = TO_STRING_NULLABLE(objRow("XINPUT_NO"))
        mXDENPYOU_NO = TO_STRING_NULLABLE(objRow("XDENPYOU_NO"))
        mXBUNRUI_NO = TO_STRING_NULLABLE(objRow("XBUNRUI_NO"))
        mXDATA_DT = TO_DATE_NULLABLE(objRow("XDATA_DT"))
        mXSOUKO_CD = TO_STRING_NULLABLE(objRow("XSOUKO_CD"))
        mXTOU_NO = TO_STRING_NULLABLE(objRow("XTOU_NO"))
        mXTORIHIKI_KBN = TO_STRING_NULLABLE(objRow("XTORIHIKI_KBN"))
        mXDATA_SYORI = TO_STRING_NULLABLE(objRow("XDATA_SYORI"))
        mXGYOUSYA_CD = TO_STRING_NULLABLE(objRow("XGYOUSYA_CD"))
        mXGYOUSYA_KBN = TO_STRING_NULLABLE(objRow("XGYOUSYA_KBN"))
        mXSYARYOU_NO = TO_INTEGER_NULLABLE(objRow("XSYARYOU_NO"))
        mXUNKOU_NO = TO_STRING_NULLABLE(objRow("XUNKOU_NO"))
        mXTUMI_HOUKOU = TO_INTEGER_NULLABLE(objRow("XTUMI_HOUKOU"))
        mXTUMI_HOUHOU = TO_INTEGER_NULLABLE(objRow("XTUMI_HOUHOU"))
        mXSYASYU_KBN = TO_STRING_NULLABLE(objRow("XSYASYU_KBN"))
        mXHENSEI_NO_OYA = TO_STRING_NULLABLE(objRow("XHENSEI_NO_OYA"))
        mXSEND_NAME = TO_STRING_NULLABLE(objRow("XSEND_NAME"))
        mXSEND_ADDRESS = TO_STRING_NULLABLE(objRow("XSEND_ADDRESS"))
        mXBERTH_NO = TO_STRING_NULLABLE(objRow("XBERTH_NO"))
        mXKINKYU_KBN = TO_INTEGER_NULLABLE(objRow("XKINKYU_KBN"))
        mXKINKYU_LEVEL = TO_INTEGER_NULLABLE(objRow("XKINKYU_LEVEL"))
        mXSYARYOU_ENTRY_DT = TO_DATE_NULLABLE(objRow("XSYARYOU_ENTRY_DT"))
        mXSYUKKA_DIR_DT = TO_DATE_NULLABLE(objRow("XSYUKKA_DIR_DT"))
        mXOUT_START_DT = TO_DATE_NULLABLE(objRow("XOUT_START_DT"))
        mXOUT_END_DT = TO_DATE_NULLABLE(objRow("XOUT_END_DT"))
        mXTUMI_END_DT = TO_DATE_NULLABLE(objRow("XTUMI_END_DT"))
        mXSYUKKA_STS = TO_INTEGER_NULLABLE(objRow("XSYUKKA_STS"))
        mXIKKATU_SYUKKO = TO_INTEGER_NULLABLE(objRow("XIKKATU_SYUKKO"))
        mFENTRY_DT = TO_DATE_NULLABLE(objRow("FENTRY_DT"))


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
        strMsg &= "[ð��ٖ�:�o�׎w��]"
        If IsNotNull(XSYUKKA_D) Then
            strMsg &= "[�o�ד�:" & XSYUKKA_D & "]"
        End If
        If IsNotNull(XHENSEI_NO) Then
            strMsg &= "[�Ґ�No.:" & XHENSEI_NO & "]"
        End If
        If IsNotNull(XDATA_KIND) Then
            strMsg &= "[�ް����:" & XDATA_KIND & "]"
        End If
        If IsNotNull(XEDIT_KBN) Then
            strMsg &= "[�ҏW�敪:" & XEDIT_KBN & "]"
        End If
        If IsNotNull(XINPUT_PLACE) Then
            strMsg &= "[���߯ďꏊ:" & XINPUT_PLACE & "]"
        End If
        If IsNotNull(XINPUT_DT) Then
            strMsg &= "[���߯ē��t:" & XINPUT_DT & "]"
        End If
        If IsNotNull(XINPUT_NO) Then
            strMsg &= "[���߯�No.:" & XINPUT_NO & "]"
        End If
        If IsNotNull(XDENPYOU_NO) Then
            strMsg &= "[�`�[No.:" & XDENPYOU_NO & "]"
        End If
        If IsNotNull(XBUNRUI_NO) Then
            strMsg &= "[����No.:" & XBUNRUI_NO & "]"
        End If
        If IsNotNull(XDATA_DT) Then
            strMsg &= "[�ް����t:" & XDATA_DT & "]"
        End If
        If IsNotNull(XSOUKO_CD) Then
            strMsg &= "[�q�ɺ���:" & XSOUKO_CD & "]"
        End If
        If IsNotNull(XTOU_NO) Then
            strMsg &= "[������:" & XTOU_NO & "]"
        End If
        If IsNotNull(XTORIHIKI_KBN) Then
            strMsg &= "[����敪:" & XTORIHIKI_KBN & "]"
        End If
        If IsNotNull(XDATA_SYORI) Then
            strMsg &= "[�ް�����:" & XDATA_SYORI & "]"
        End If
        If IsNotNull(XGYOUSYA_CD) Then
            strMsg &= "[�����ƎҺ���:" & XGYOUSYA_CD & "]"
        End If
        If IsNotNull(XGYOUSYA_KBN) Then
            strMsg &= "[�Ǝҋ敪:" & XGYOUSYA_KBN & "]"
        End If
        If IsNotNull(XSYARYOU_NO) Then
            strMsg &= "[���q�ԍ�:" & XSYARYOU_NO & "]"
        End If
        If IsNotNull(XUNKOU_NO) Then
            strMsg &= "[�q�ɕʉ^�sNo.:" & XUNKOU_NO & "]"
        End If
        If IsNotNull(XTUMI_HOUKOU) Then
            strMsg &= "[�ύ�����:" & XTUMI_HOUKOU & "]"
        End If
        If IsNotNull(XTUMI_HOUHOU) Then
            strMsg &= "[�ύ����@:" & XTUMI_HOUHOU & "]"
        End If
        If IsNotNull(XSYASYU_KBN) Then
            strMsg &= "[�Ԏ�敪:" & XSYASYU_KBN & "]"
        End If
        If IsNotNull(XHENSEI_NO_OYA) Then
            strMsg &= "[�e�Ґ�No.:" & XHENSEI_NO_OYA & "]"
        End If
        If IsNotNull(XSEND_NAME) Then
            strMsg &= "[�͂��於��:" & XSEND_NAME & "]"
        End If
        If IsNotNull(XSEND_ADDRESS) Then
            strMsg &= "[�͂���Z��:" & XSEND_ADDRESS & "]"
        End If
        If IsNotNull(XBERTH_NO) Then
            strMsg &= "[�ް�No.:" & XBERTH_NO & "]"
        End If
        If IsNotNull(XKINKYU_KBN) Then
            strMsg &= "[�ً}�o�׋敪:" & XKINKYU_KBN & "]"
        End If
        If IsNotNull(XKINKYU_LEVEL) Then
            strMsg &= "[�ً}�x:" & XKINKYU_LEVEL & "]"
        End If
        If IsNotNull(XSYARYOU_ENTRY_DT) Then
            strMsg &= "[���q��t����:" & XSYARYOU_ENTRY_DT & "]"
        End If
        If IsNotNull(XSYUKKA_DIR_DT) Then
            strMsg &= "[�o�׎w������:" & XSYUKKA_DIR_DT & "]"
        End If
        If IsNotNull(XOUT_START_DT) Then
            strMsg &= "[�o�ɊJ�n����:" & XOUT_START_DT & "]"
        End If
        If IsNotNull(XOUT_END_DT) Then
            strMsg &= "[�o�Ɋ�������:" & XOUT_END_DT & "]"
        End If
        If IsNotNull(XTUMI_END_DT) Then
            strMsg &= "[�ύ���������:" & XTUMI_END_DT & "]"
        End If
        If IsNotNull(XSYUKKA_STS) Then
            strMsg &= "[�o�׏�:" & XSYUKKA_STS & "]"
        End If
        If IsNotNull(XIKKATU_SYUKKO) Then
            strMsg &= "[�ꊇ�o�Ɏw��:" & XIKKATU_SYUKKO & "]"
        End If
        If IsNotNull(FENTRY_DT) Then
            strMsg &= "[�o�^����:" & FENTRY_DT & "]"
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

#Region "  �o�׎w���擾         (Public  GET_PLN_OUT_HENSEI_MINYUKOU)"
    Public Function GET_PLN_OUT_HENSEI_MINYUKOU() As RetCode
        Dim strSQL As New StringBuilder 'SQL��
        Dim objDataSet As New DataSet   '�ް����
        Dim strDataSetName As String    '�ް���Ė�
        Dim objRow As DataRow           '1ں��ޕ����ް�
        Dim objParameter(1, 0) As Object
        Dim strBindField(0) As String
        Dim objBindValue(0) As Object
        Dim strBindType(0) As String
        Dim strMsg As String            'ү����


        '----------------
        '�����è����
        '----------------
        If mXHENSEI_NO = DEFAULT_STRING Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�Ґ�No]"
            Throw New System.Exception(strMsg)
        End If


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
        strSQL.Append(vbCrLf & "    XPLN_OUT")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")

        ReDim Preserve strBindField(UBound(strBindField) + 1)
        ReDim Preserve objBindValue(UBound(objBindValue) + 1)
        strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
        objBindValue(UBound(objBindValue)) = mXHENSEI_NO
        strSQL.Append(vbCrLf & "    AND XHENSEI_NO = :" & UBound(strBindField) - 1 & " --�Ґ�No.")

        ReDim Preserve strBindField(UBound(strBindField) + 1)
        ReDim Preserve objBindValue(UBound(objBindValue) + 1)
        strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
        objBindValue(UBound(objBindValue)) = XSYUKKA_STS_JNON
        strSQL.Append(vbCrLf & "    AND XSYUKKA_STS = :" & UBound(strBindField) - 1 & " --�o�׏�")

        strSQL.Append(vbCrLf & " ORDER BY ")
        strSQL.Append(vbCrLf & "    XSYUKKA_D ")
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
        mobjAryMe = Nothing
        ObjDb.SQL = strSQL.ToString
        ObjDb.Parameter = objParameter
        objDataSet.Clear()
        strDataSetName = "XPLN_OUT"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XPLN_OUT(Owner, ObjDb, ObjDbLog)
                mobjAryMe(ii).SET_DATA(objRow)
            Next ii
            Return (RetCode.OK)
        Else
            Return (RetCode.NotFound)
        End If

    End Function
#End Region

#Region "  �o�׎w���擾         (Public  GET_PLN_OUT_HENSEI_MINCOMPLETE)"
    Public Function GET_PLN_OUT_HENSEI_MINCOMPLETE() As RetCode
        Dim strSQL As New StringBuilder 'SQL��
        Dim objDataSet As New DataSet   '�ް����
        Dim strDataSetName As String    '�ް���Ė�
        Dim objRow As DataRow           '1ں��ޕ����ް�
        Dim objParameter(1, 0) As Object
        Dim strBindField(0) As String
        Dim objBindValue(0) As Object
        Dim strBindType(0) As String
        Dim strMsg As String            'ү����


        '----------------
        '�����è����
        '----------------
        If mXHENSEI_NO = DEFAULT_STRING Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�Ґ�No]"
            Throw New System.Exception(strMsg)
        End If


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
        strSQL.Append(vbCrLf & "    XPLN_OUT")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")

        ReDim Preserve strBindField(UBound(strBindField) + 1)
        ReDim Preserve objBindValue(UBound(objBindValue) + 1)
        strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
        objBindValue(UBound(objBindValue)) = mXHENSEI_NO
        strSQL.Append(vbCrLf & "    AND XHENSEI_NO = :" & UBound(strBindField) - 1 & " --�Ґ�No.")

        strSQL.Append(vbCrLf & " ORDER BY ")
        strSQL.Append(vbCrLf & "    XSYUKKA_D ")
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
        mobjAryMe = Nothing
        ObjDb.SQL = strSQL.ToString
        ObjDb.Parameter = objParameter
        objDataSet.Clear()
        strDataSetName = "XPLN_OUT"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            objRow = objDataSet.Tables(strDataSetName).Rows(0)
            Call SET_DATA(objRow)
            Return (RetCode.OK)
        Else
            Return (RetCode.NotFound)
        End If

    End Function
#End Region

    '���������ьŗL
    '**********************************************************************************************

End Class
