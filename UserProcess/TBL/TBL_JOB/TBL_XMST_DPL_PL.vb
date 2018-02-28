'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' �y���́zMaterialStreamð��ٸ׽
' �y�@�\�z����ڥ�������Ͻ�ð��ٸ׽
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
''' ����ڥ�������Ͻ�ð��ٸ׽
''' </summary>
Public Class TBL_XMST_DPL_PL
    Inherits clsTemplateTable

    '**********************************************************************************************
    '����������������
#Region "  �׽�ϐ���`                  "
    '�����è
    Private mobjAryMe As TBL_XMST_DPL_PL()                                       '����ڥ�������Ͻ�
    Private mstrUSER_SQL As String                                               'հ�ްSQL
    Private mORDER_BY As String                                                  'OrderBy��
    Private mWHERE As String                                                     'Where��
    Private mXDPL_PL_NO As Nullable(Of Integer)                                  '����ڥ������ޔԍ�
    Private mXDPL_PL_NAME As String                                              '����ڥ������ޖ���
    Private mXPROD_LINE As String                                                '���Yײ݇�
    Private mFTRK_BUF_NO As Nullable(Of Integer)                                 '�ׯ�ݸ��ޯ̧��
    Private mXDPL_PL_EQ_ID_HINM As String                                        '����ڥ������ޕi���ސݔ�ID
    Private mXDPL_PL_EQ_ID_PL As String                                          '����ڥ������ސ��Y��گĐ��ݔ�ID
    Private mXDPL_PL_EQ_ID_HASU As String                                        '����ڥ������ޒ[���ް��ݔ�ID
    Private mXDPL_PL_EQ_ID_TRBL_HH As String                                     '����ڥ�����������َ��Ԑݔ�ID(��)
    Private mXDPL_PL_EQ_ID_TRBL_MM As String                                     '����ڥ�����������َ��Ԑݔ�ID(��)
    Private mXDPL_PL_EQ_ID_TRBL_SS As String                                     '����ڥ�����������َ��Ԑݔ�ID(�b)
    Private mXDPL_PL_EQ_ID_TRBL As String                                        '����ڥ�����������ٌ����ݔ�ID
    Private mXDPL_PL_EQ_ID_COUNT As String                                       '����ڥ������ސϕt���ݔ�ID
    Private mXDPL_PL_EQ_ID_KADOU_HH As String                                    '����ڥ������މ^�]���Ԑݔ�ID(��)
    Private mXDPL_PL_EQ_ID_KADOU_MM As String                                    '����ڥ������މ^�]���Ԑݔ�ID(��)
    Private mXDPL_PL_EQ_ID_KADOU_SS As String                                    '����ڥ������މ^�]���Ԑݔ�ID(�b)
    Private mXDPL_PL_EQ_ID_STKD As String                                        '����ڥ������ދN��(�w��)�ݔ�ID
    Private mXDPL_PL_EQ_ID_STED As String                                        '����ڥ������މ^�]�I��(�w��)�ݔ�ID
    Private mXDPL_PL_EQ_ID_STPT As String                                        '����ڥ������ސϕt����ݐݒ�(�w��)�ݔ�ID
    Private mXDPL_PL_EQ_ID_STCL As String                                        '����ڥ��������ް��ر(�w��)�ݔ�ID
    Private mXDPL_PL_EQ_ID_STKN As String                                        '����ڥ��������ް��ر����(�w��)�ݔ�ID
    Private mXDPL_PL_EQ_ID_STST As String                                        '����ڥ������މ^�]��~(�w��)�ݔ�ID
    Private mXDPL_PL_EQ_ID_STHR As String                                        '����ڥ������ޕ��o��~(�w��)�ݔ�ID
    Private mXDPL_PL_EQ_ID_KIDO As String                                        '����ڥ������ދN��ANS�ݔ�ID
    Private mXDPL_PL_EQ_ID_ONLN As String                                        '����ڥ������޵�ײ�ANS�ݔ�ID
    Private mXDPL_PL_EQ_ID_OFLN As String                                        '����ڥ������޵�ײ�ANS�ݔ�ID
    Private mXDPL_PL_EQ_ID_IJOU As String                                        '����ڥ������ވꊇ�ُ�ݔ�ID
    Private mXDPL_PL_EQ_ID_KEHO As String                                        '����ڥ������ތx��ݔ�ID
    Private mXDPL_PL_EQ_ID_PLPT As String                                        '����ڥ������ސϕt����ݐݒ��v�ݔ�ID
    Private mXDPL_PL_EQ_ID_REDY As String                                        '����ڥ������ދN���\�ݔ�ID
    Private mXDPL_PL_EQ_ID_SYRY As String                                        '����ڥ������ޏI���v���ݔ�ID
    Private mFENTRY_DT As Nullable(Of Date)                                      '�o�^����
#End Region
#Region "  �����è��`                  "
    ''' <summary>
    ''' ���ѕϐ� (���׽�^�z��)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_XMST_DPL_PL()
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
    ''' ����ڥ������ޔԍ�
    ''' </summary>
    Public Property XDPL_PL_NO() As Nullable(Of Integer)
        Get
            Return mXDPL_PL_NO
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXDPL_PL_NO = Value
        End Set
    End Property
    ''' <summary>
    ''' ����ڥ������ޖ���
    ''' </summary>
    Public Property XDPL_PL_NAME() As String
        Get
            Return mXDPL_PL_NAME
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_NAME = Value
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
    ''' ����ڥ������ޕi���ސݔ�ID
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_HINM() As String
        Get
            Return mXDPL_PL_EQ_ID_HINM
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_HINM = Value
        End Set
    End Property
    ''' <summary>
    ''' ����ڥ������ސ��Y��گĐ��ݔ�ID
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_PL() As String
        Get
            Return mXDPL_PL_EQ_ID_PL
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_PL = Value
        End Set
    End Property
    ''' <summary>
    ''' ����ڥ������ޒ[���ް��ݔ�ID
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_HASU() As String
        Get
            Return mXDPL_PL_EQ_ID_HASU
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_HASU = Value
        End Set
    End Property
    ''' <summary>
    ''' ����ڥ�����������َ��Ԑݔ�ID(��)
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_TRBL_HH() As String
        Get
            Return mXDPL_PL_EQ_ID_TRBL_HH
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_TRBL_HH = Value
        End Set
    End Property
    ''' <summary>
    ''' ����ڥ�����������َ��Ԑݔ�ID(��)
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_TRBL_MM() As String
        Get
            Return mXDPL_PL_EQ_ID_TRBL_MM
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_TRBL_MM = Value
        End Set
    End Property
    ''' <summary>
    ''' ����ڥ�����������َ��Ԑݔ�ID(�b)
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_TRBL_SS() As String
        Get
            Return mXDPL_PL_EQ_ID_TRBL_SS
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_TRBL_SS = Value
        End Set
    End Property
    ''' <summary>
    ''' ����ڥ�����������ٌ����ݔ�ID
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_TRBL() As String
        Get
            Return mXDPL_PL_EQ_ID_TRBL
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_TRBL = Value
        End Set
    End Property
    ''' <summary>
    ''' ����ڥ������ސϕt���ݔ�ID
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_COUNT() As String
        Get
            Return mXDPL_PL_EQ_ID_COUNT
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_COUNT = Value
        End Set
    End Property
    ''' <summary>
    ''' ����ڥ������މ^�]���Ԑݔ�ID(��)
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_KADOU_HH() As String
        Get
            Return mXDPL_PL_EQ_ID_KADOU_HH
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_KADOU_HH = Value
        End Set
    End Property
    ''' <summary>
    ''' ����ڥ������މ^�]���Ԑݔ�ID(��)
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_KADOU_MM() As String
        Get
            Return mXDPL_PL_EQ_ID_KADOU_MM
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_KADOU_MM = Value
        End Set
    End Property
    ''' <summary>
    ''' ����ڥ������މ^�]���Ԑݔ�ID(�b)
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_KADOU_SS() As String
        Get
            Return mXDPL_PL_EQ_ID_KADOU_SS
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_KADOU_SS = Value
        End Set
    End Property
    ''' <summary>
    ''' ����ڥ������ދN��(�w��)�ݔ�ID
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_STKD() As String
        Get
            Return mXDPL_PL_EQ_ID_STKD
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_STKD = Value
        End Set
    End Property
    ''' <summary>
    ''' ����ڥ������މ^�]�I��(�w��)�ݔ�ID
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_STED() As String
        Get
            Return mXDPL_PL_EQ_ID_STED
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_STED = Value
        End Set
    End Property
    ''' <summary>
    ''' ����ڥ������ސϕt����ݐݒ�(�w��)�ݔ�ID
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_STPT() As String
        Get
            Return mXDPL_PL_EQ_ID_STPT
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_STPT = Value
        End Set
    End Property
    ''' <summary>
    ''' ����ڥ��������ް��ر(�w��)�ݔ�ID
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_STCL() As String
        Get
            Return mXDPL_PL_EQ_ID_STCL
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_STCL = Value
        End Set
    End Property
    ''' <summary>
    ''' ����ڥ��������ް��ر����(�w��)�ݔ�ID
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_STKN() As String
        Get
            Return mXDPL_PL_EQ_ID_STKN
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_STKN = Value
        End Set
    End Property
    ''' <summary>
    ''' ����ڥ������މ^�]��~(�w��)�ݔ�ID
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_STST() As String
        Get
            Return mXDPL_PL_EQ_ID_STST
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_STST = Value
        End Set
    End Property
    ''' <summary>
    ''' ����ڥ������ޕ��o��~(�w��)�ݔ�ID
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_STHR() As String
        Get
            Return mXDPL_PL_EQ_ID_STHR
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_STHR = Value
        End Set
    End Property
    ''' <summary>
    ''' ����ڥ������ދN��ANS�ݔ�ID
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_KIDO() As String
        Get
            Return mXDPL_PL_EQ_ID_KIDO
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_KIDO = Value
        End Set
    End Property
    ''' <summary>
    ''' ����ڥ������޵�ײ�ANS�ݔ�ID
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_ONLN() As String
        Get
            Return mXDPL_PL_EQ_ID_ONLN
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_ONLN = Value
        End Set
    End Property
    ''' <summary>
    ''' ����ڥ������޵�ײ�ANS�ݔ�ID
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_OFLN() As String
        Get
            Return mXDPL_PL_EQ_ID_OFLN
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_OFLN = Value
        End Set
    End Property
    ''' <summary>
    ''' ����ڥ������ވꊇ�ُ�ݔ�ID
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_IJOU() As String
        Get
            Return mXDPL_PL_EQ_ID_IJOU
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_IJOU = Value
        End Set
    End Property
    ''' <summary>
    ''' ����ڥ������ތx��ݔ�ID
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_KEHO() As String
        Get
            Return mXDPL_PL_EQ_ID_KEHO
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_KEHO = Value
        End Set
    End Property
    ''' <summary>
    ''' ����ڥ������ސϕt����ݐݒ��v�ݔ�ID
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_PLPT() As String
        Get
            Return mXDPL_PL_EQ_ID_PLPT
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_PLPT = Value
        End Set
    End Property
    ''' <summary>
    ''' ����ڥ������ދN���\�ݔ�ID
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_REDY() As String
        Get
            Return mXDPL_PL_EQ_ID_REDY
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_REDY = Value
        End Set
    End Property
    ''' <summary>
    ''' ����ڥ������ޏI���v���ݔ�ID
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_SYRY() As String
        Get
            Return mXDPL_PL_EQ_ID_SYRY
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_SYRY = Value
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
    Public Function GET_XMST_DPL_PL(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    XMST_DPL_PL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XDPL_PL_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_NO
            strSQL.Append(vbCrLf & "    AND XDPL_PL_NO = :" & UBound(strBindField) - 1 & " --����ڥ������ޔԍ�")
        End If
        If IsNull(XDPL_PL_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_NAME
            strSQL.Append(vbCrLf & "    AND XDPL_PL_NAME = :" & UBound(strBindField) - 1 & " --����ڥ������ޖ���")
        End If
        If IsNull(XPROD_LINE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPROD_LINE
            strSQL.Append(vbCrLf & "    AND XPROD_LINE = :" & UBound(strBindField) - 1 & " --���Yײ݇�")
        End If
        If IsNull(FTRK_BUF_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(XDPL_PL_EQ_ID_HINM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_HINM
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_HINM = :" & UBound(strBindField) - 1 & " --����ڥ������ޕi���ސݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_PL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_PL
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_PL = :" & UBound(strBindField) - 1 & " --����ڥ������ސ��Y��گĐ��ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_HASU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_HASU
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_HASU = :" & UBound(strBindField) - 1 & " --����ڥ������ޒ[���ް��ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_TRBL_HH) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL_HH
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_TRBL_HH = :" & UBound(strBindField) - 1 & " --����ڥ�����������َ��Ԑݔ�ID(��)")
        End If
        If IsNull(XDPL_PL_EQ_ID_TRBL_MM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL_MM
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_TRBL_MM = :" & UBound(strBindField) - 1 & " --����ڥ�����������َ��Ԑݔ�ID(��)")
        End If
        If IsNull(XDPL_PL_EQ_ID_TRBL_SS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL_SS
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_TRBL_SS = :" & UBound(strBindField) - 1 & " --����ڥ�����������َ��Ԑݔ�ID(�b)")
        End If
        If IsNull(XDPL_PL_EQ_ID_TRBL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_TRBL = :" & UBound(strBindField) - 1 & " --����ڥ�����������ٌ����ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_COUNT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_COUNT
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_COUNT = :" & UBound(strBindField) - 1 & " --����ڥ������ސϕt���ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_KADOU_HH) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KADOU_HH
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_KADOU_HH = :" & UBound(strBindField) - 1 & " --����ڥ������މ^�]���Ԑݔ�ID(��)")
        End If
        If IsNull(XDPL_PL_EQ_ID_KADOU_MM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KADOU_MM
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_KADOU_MM = :" & UBound(strBindField) - 1 & " --����ڥ������މ^�]���Ԑݔ�ID(��)")
        End If
        If IsNull(XDPL_PL_EQ_ID_KADOU_SS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KADOU_SS
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_KADOU_SS = :" & UBound(strBindField) - 1 & " --����ڥ������މ^�]���Ԑݔ�ID(�b)")
        End If
        If IsNull(XDPL_PL_EQ_ID_STKD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STKD
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STKD = :" & UBound(strBindField) - 1 & " --����ڥ������ދN��(�w��)�ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_STED) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STED
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STED = :" & UBound(strBindField) - 1 & " --����ڥ������މ^�]�I��(�w��)�ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_STPT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STPT
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STPT = :" & UBound(strBindField) - 1 & " --����ڥ������ސϕt����ݐݒ�(�w��)�ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_STCL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STCL
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STCL = :" & UBound(strBindField) - 1 & " --����ڥ��������ް��ر(�w��)�ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_STKN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STKN
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STKN = :" & UBound(strBindField) - 1 & " --����ڥ��������ް��ر����(�w��)�ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_STST) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STST
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STST = :" & UBound(strBindField) - 1 & " --����ڥ������މ^�]��~(�w��)�ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_STHR) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STHR
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STHR = :" & UBound(strBindField) - 1 & " --����ڥ������ޕ��o��~(�w��)�ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_KIDO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KIDO
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_KIDO = :" & UBound(strBindField) - 1 & " --����ڥ������ދN��ANS�ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_ONLN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_ONLN
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_ONLN = :" & UBound(strBindField) - 1 & " --����ڥ������޵�ײ�ANS�ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_OFLN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_OFLN
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_OFLN = :" & UBound(strBindField) - 1 & " --����ڥ������޵�ײ�ANS�ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_IJOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_IJOU
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_IJOU = :" & UBound(strBindField) - 1 & " --����ڥ������ވꊇ�ُ�ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_KEHO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KEHO
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_KEHO = :" & UBound(strBindField) - 1 & " --����ڥ������ތx��ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_PLPT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_PLPT
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_PLPT = :" & UBound(strBindField) - 1 & " --����ڥ������ސϕt����ݐݒ��v�ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_REDY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_REDY
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_REDY = :" & UBound(strBindField) - 1 & " --����ڥ������ދN���\�ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_SYRY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_SYRY
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_SYRY = :" & UBound(strBindField) - 1 & " --����ڥ������ޏI���v���ݔ�ID")
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
        strDataSetName = "XMST_DPL_PL"
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
    Public Function GET_XMST_DPL_PL_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    XMST_DPL_PL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XDPL_PL_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_NO
            strSQL.Append(vbCrLf & "    AND XDPL_PL_NO = :" & UBound(strBindField) - 1 & " --����ڥ������ޔԍ�")
        End If
        If IsNull(XDPL_PL_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_NAME
            strSQL.Append(vbCrLf & "    AND XDPL_PL_NAME = :" & UBound(strBindField) - 1 & " --����ڥ������ޖ���")
        End If
        If IsNull(XPROD_LINE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPROD_LINE
            strSQL.Append(vbCrLf & "    AND XPROD_LINE = :" & UBound(strBindField) - 1 & " --���Yײ݇�")
        End If
        If IsNull(FTRK_BUF_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(XDPL_PL_EQ_ID_HINM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_HINM
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_HINM = :" & UBound(strBindField) - 1 & " --����ڥ������ޕi���ސݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_PL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_PL
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_PL = :" & UBound(strBindField) - 1 & " --����ڥ������ސ��Y��گĐ��ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_HASU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_HASU
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_HASU = :" & UBound(strBindField) - 1 & " --����ڥ������ޒ[���ް��ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_TRBL_HH) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL_HH
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_TRBL_HH = :" & UBound(strBindField) - 1 & " --����ڥ�����������َ��Ԑݔ�ID(��)")
        End If
        If IsNull(XDPL_PL_EQ_ID_TRBL_MM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL_MM
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_TRBL_MM = :" & UBound(strBindField) - 1 & " --����ڥ�����������َ��Ԑݔ�ID(��)")
        End If
        If IsNull(XDPL_PL_EQ_ID_TRBL_SS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL_SS
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_TRBL_SS = :" & UBound(strBindField) - 1 & " --����ڥ�����������َ��Ԑݔ�ID(�b)")
        End If
        If IsNull(XDPL_PL_EQ_ID_TRBL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_TRBL = :" & UBound(strBindField) - 1 & " --����ڥ�����������ٌ����ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_COUNT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_COUNT
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_COUNT = :" & UBound(strBindField) - 1 & " --����ڥ������ސϕt���ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_KADOU_HH) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KADOU_HH
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_KADOU_HH = :" & UBound(strBindField) - 1 & " --����ڥ������މ^�]���Ԑݔ�ID(��)")
        End If
        If IsNull(XDPL_PL_EQ_ID_KADOU_MM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KADOU_MM
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_KADOU_MM = :" & UBound(strBindField) - 1 & " --����ڥ������މ^�]���Ԑݔ�ID(��)")
        End If
        If IsNull(XDPL_PL_EQ_ID_KADOU_SS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KADOU_SS
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_KADOU_SS = :" & UBound(strBindField) - 1 & " --����ڥ������މ^�]���Ԑݔ�ID(�b)")
        End If
        If IsNull(XDPL_PL_EQ_ID_STKD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STKD
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STKD = :" & UBound(strBindField) - 1 & " --����ڥ������ދN��(�w��)�ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_STED) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STED
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STED = :" & UBound(strBindField) - 1 & " --����ڥ������މ^�]�I��(�w��)�ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_STPT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STPT
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STPT = :" & UBound(strBindField) - 1 & " --����ڥ������ސϕt����ݐݒ�(�w��)�ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_STCL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STCL
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STCL = :" & UBound(strBindField) - 1 & " --����ڥ��������ް��ر(�w��)�ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_STKN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STKN
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STKN = :" & UBound(strBindField) - 1 & " --����ڥ��������ް��ر����(�w��)�ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_STST) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STST
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STST = :" & UBound(strBindField) - 1 & " --����ڥ������މ^�]��~(�w��)�ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_STHR) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STHR
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STHR = :" & UBound(strBindField) - 1 & " --����ڥ������ޕ��o��~(�w��)�ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_KIDO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KIDO
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_KIDO = :" & UBound(strBindField) - 1 & " --����ڥ������ދN��ANS�ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_ONLN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_ONLN
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_ONLN = :" & UBound(strBindField) - 1 & " --����ڥ������޵�ײ�ANS�ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_OFLN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_OFLN
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_OFLN = :" & UBound(strBindField) - 1 & " --����ڥ������޵�ײ�ANS�ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_IJOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_IJOU
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_IJOU = :" & UBound(strBindField) - 1 & " --����ڥ������ވꊇ�ُ�ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_KEHO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KEHO
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_KEHO = :" & UBound(strBindField) - 1 & " --����ڥ������ތx��ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_PLPT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_PLPT
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_PLPT = :" & UBound(strBindField) - 1 & " --����ڥ������ސϕt����ݐݒ��v�ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_REDY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_REDY
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_REDY = :" & UBound(strBindField) - 1 & " --����ڥ������ދN���\�ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_SYRY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_SYRY
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_SYRY = :" & UBound(strBindField) - 1 & " --����ڥ������ޏI���v���ݔ�ID")
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
        strDataSetName = "XMST_DPL_PL"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XMST_DPL_PL(Owner, objDb, objDbLog)
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
    Public Function GET_XMST_DPL_PL_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "XMST_DPL_PL"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XMST_DPL_PL(Owner, objDb, objDbLog)
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
    Public Function GET_XMST_DPL_PL_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    XMST_DPL_PL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XDPL_PL_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_NO
            strSQL.Append(vbCrLf & "    AND XDPL_PL_NO = :" & UBound(strBindField) - 1 & " --����ڥ������ޔԍ�")
        End If
        If IsNull(XDPL_PL_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_NAME
            strSQL.Append(vbCrLf & "    AND XDPL_PL_NAME = :" & UBound(strBindField) - 1 & " --����ڥ������ޖ���")
        End If
        If IsNull(XPROD_LINE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPROD_LINE
            strSQL.Append(vbCrLf & "    AND XPROD_LINE = :" & UBound(strBindField) - 1 & " --���Yײ݇�")
        End If
        If IsNull(FTRK_BUF_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(XDPL_PL_EQ_ID_HINM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_HINM
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_HINM = :" & UBound(strBindField) - 1 & " --����ڥ������ޕi���ސݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_PL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_PL
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_PL = :" & UBound(strBindField) - 1 & " --����ڥ������ސ��Y��گĐ��ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_HASU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_HASU
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_HASU = :" & UBound(strBindField) - 1 & " --����ڥ������ޒ[���ް��ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_TRBL_HH) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL_HH
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_TRBL_HH = :" & UBound(strBindField) - 1 & " --����ڥ�����������َ��Ԑݔ�ID(��)")
        End If
        If IsNull(XDPL_PL_EQ_ID_TRBL_MM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL_MM
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_TRBL_MM = :" & UBound(strBindField) - 1 & " --����ڥ�����������َ��Ԑݔ�ID(��)")
        End If
        If IsNull(XDPL_PL_EQ_ID_TRBL_SS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL_SS
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_TRBL_SS = :" & UBound(strBindField) - 1 & " --����ڥ�����������َ��Ԑݔ�ID(�b)")
        End If
        If IsNull(XDPL_PL_EQ_ID_TRBL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_TRBL = :" & UBound(strBindField) - 1 & " --����ڥ�����������ٌ����ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_COUNT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_COUNT
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_COUNT = :" & UBound(strBindField) - 1 & " --����ڥ������ސϕt���ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_KADOU_HH) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KADOU_HH
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_KADOU_HH = :" & UBound(strBindField) - 1 & " --����ڥ������މ^�]���Ԑݔ�ID(��)")
        End If
        If IsNull(XDPL_PL_EQ_ID_KADOU_MM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KADOU_MM
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_KADOU_MM = :" & UBound(strBindField) - 1 & " --����ڥ������މ^�]���Ԑݔ�ID(��)")
        End If
        If IsNull(XDPL_PL_EQ_ID_KADOU_SS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KADOU_SS
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_KADOU_SS = :" & UBound(strBindField) - 1 & " --����ڥ������މ^�]���Ԑݔ�ID(�b)")
        End If
        If IsNull(XDPL_PL_EQ_ID_STKD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STKD
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STKD = :" & UBound(strBindField) - 1 & " --����ڥ������ދN��(�w��)�ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_STED) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STED
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STED = :" & UBound(strBindField) - 1 & " --����ڥ������މ^�]�I��(�w��)�ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_STPT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STPT
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STPT = :" & UBound(strBindField) - 1 & " --����ڥ������ސϕt����ݐݒ�(�w��)�ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_STCL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STCL
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STCL = :" & UBound(strBindField) - 1 & " --����ڥ��������ް��ر(�w��)�ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_STKN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STKN
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STKN = :" & UBound(strBindField) - 1 & " --����ڥ��������ް��ر����(�w��)�ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_STST) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STST
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STST = :" & UBound(strBindField) - 1 & " --����ڥ������މ^�]��~(�w��)�ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_STHR) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STHR
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STHR = :" & UBound(strBindField) - 1 & " --����ڥ������ޕ��o��~(�w��)�ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_KIDO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KIDO
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_KIDO = :" & UBound(strBindField) - 1 & " --����ڥ������ދN��ANS�ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_ONLN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_ONLN
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_ONLN = :" & UBound(strBindField) - 1 & " --����ڥ������޵�ײ�ANS�ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_OFLN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_OFLN
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_OFLN = :" & UBound(strBindField) - 1 & " --����ڥ������޵�ײ�ANS�ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_IJOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_IJOU
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_IJOU = :" & UBound(strBindField) - 1 & " --����ڥ������ވꊇ�ُ�ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_KEHO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KEHO
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_KEHO = :" & UBound(strBindField) - 1 & " --����ڥ������ތx��ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_PLPT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_PLPT
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_PLPT = :" & UBound(strBindField) - 1 & " --����ڥ������ސϕt����ݐݒ��v�ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_REDY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_REDY
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_REDY = :" & UBound(strBindField) - 1 & " --����ڥ������ދN���\�ݔ�ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_SYRY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_SYRY
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_SYRY = :" & UBound(strBindField) - 1 & " --����ڥ������ޏI���v���ݔ�ID")
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
        strDataSetName = "XMST_DPL_PL"
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
    Public Sub UPDATE_XMST_DPL_PL()
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
        ElseIf IsNull(mXDPL_PL_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[����ڥ������ޔԍ�]"
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
        strSQL.Append(vbCrLf & "    XMST_DPL_PL")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
        If IsNull(mXDPL_PL_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_NO = NULL --����ڥ������ޔԍ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_NO = NULL --����ڥ������ޔԍ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_NO = :" & Ubound(strBindField) - 1 & " --����ڥ������ޔԍ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_NO = :" & Ubound(strBindField) - 1 & " --����ڥ������ޔԍ�")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_NAME = NULL --����ڥ������ޖ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_NAME = NULL --����ڥ������ޖ���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_NAME = :" & Ubound(strBindField) - 1 & " --����ڥ������ޖ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_NAME = :" & Ubound(strBindField) - 1 & " --����ڥ������ޖ���")
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
        If IsNull(mXDPL_PL_EQ_ID_HINM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_HINM = NULL --����ڥ������ޕi���ސݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_HINM = NULL --����ڥ������ޕi���ސݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_HINM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_HINM = :" & Ubound(strBindField) - 1 & " --����ڥ������ޕi���ސݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_HINM = :" & Ubound(strBindField) - 1 & " --����ڥ������ޕi���ސݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_PL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_PL = NULL --����ڥ������ސ��Y��گĐ��ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_PL = NULL --����ڥ������ސ��Y��گĐ��ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_PL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_PL = :" & Ubound(strBindField) - 1 & " --����ڥ������ސ��Y��گĐ��ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_PL = :" & Ubound(strBindField) - 1 & " --����ڥ������ސ��Y��گĐ��ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_HASU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_HASU = NULL --����ڥ������ޒ[���ް��ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_HASU = NULL --����ڥ������ޒ[���ް��ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_HASU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_HASU = :" & Ubound(strBindField) - 1 & " --����ڥ������ޒ[���ް��ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_HASU = :" & Ubound(strBindField) - 1 & " --����ڥ������ޒ[���ް��ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_TRBL_HH) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_TRBL_HH = NULL --����ڥ�����������َ��Ԑݔ�ID(��)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_TRBL_HH = NULL --����ڥ�����������َ��Ԑݔ�ID(��)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL_HH
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_TRBL_HH = :" & Ubound(strBindField) - 1 & " --����ڥ�����������َ��Ԑݔ�ID(��)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_TRBL_HH = :" & Ubound(strBindField) - 1 & " --����ڥ�����������َ��Ԑݔ�ID(��)")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_TRBL_MM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_TRBL_MM = NULL --����ڥ�����������َ��Ԑݔ�ID(��)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_TRBL_MM = NULL --����ڥ�����������َ��Ԑݔ�ID(��)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL_MM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_TRBL_MM = :" & Ubound(strBindField) - 1 & " --����ڥ�����������َ��Ԑݔ�ID(��)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_TRBL_MM = :" & Ubound(strBindField) - 1 & " --����ڥ�����������َ��Ԑݔ�ID(��)")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_TRBL_SS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_TRBL_SS = NULL --����ڥ�����������َ��Ԑݔ�ID(�b)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_TRBL_SS = NULL --����ڥ�����������َ��Ԑݔ�ID(�b)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL_SS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_TRBL_SS = :" & Ubound(strBindField) - 1 & " --����ڥ�����������َ��Ԑݔ�ID(�b)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_TRBL_SS = :" & Ubound(strBindField) - 1 & " --����ڥ�����������َ��Ԑݔ�ID(�b)")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_TRBL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_TRBL = NULL --����ڥ�����������ٌ����ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_TRBL = NULL --����ڥ�����������ٌ����ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_TRBL = :" & Ubound(strBindField) - 1 & " --����ڥ�����������ٌ����ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_TRBL = :" & Ubound(strBindField) - 1 & " --����ڥ�����������ٌ����ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_COUNT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_COUNT = NULL --����ڥ������ސϕt���ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_COUNT = NULL --����ڥ������ސϕt���ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_COUNT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_COUNT = :" & Ubound(strBindField) - 1 & " --����ڥ������ސϕt���ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_COUNT = :" & Ubound(strBindField) - 1 & " --����ڥ������ސϕt���ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_KADOU_HH) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_KADOU_HH = NULL --����ڥ������މ^�]���Ԑݔ�ID(��)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_KADOU_HH = NULL --����ڥ������މ^�]���Ԑݔ�ID(��)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KADOU_HH
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_KADOU_HH = :" & Ubound(strBindField) - 1 & " --����ڥ������މ^�]���Ԑݔ�ID(��)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_KADOU_HH = :" & Ubound(strBindField) - 1 & " --����ڥ������މ^�]���Ԑݔ�ID(��)")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_KADOU_MM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_KADOU_MM = NULL --����ڥ������މ^�]���Ԑݔ�ID(��)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_KADOU_MM = NULL --����ڥ������މ^�]���Ԑݔ�ID(��)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KADOU_MM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_KADOU_MM = :" & Ubound(strBindField) - 1 & " --����ڥ������މ^�]���Ԑݔ�ID(��)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_KADOU_MM = :" & Ubound(strBindField) - 1 & " --����ڥ������މ^�]���Ԑݔ�ID(��)")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_KADOU_SS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_KADOU_SS = NULL --����ڥ������މ^�]���Ԑݔ�ID(�b)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_KADOU_SS = NULL --����ڥ������މ^�]���Ԑݔ�ID(�b)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KADOU_SS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_KADOU_SS = :" & Ubound(strBindField) - 1 & " --����ڥ������މ^�]���Ԑݔ�ID(�b)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_KADOU_SS = :" & Ubound(strBindField) - 1 & " --����ڥ������މ^�]���Ԑݔ�ID(�b)")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_STKD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_STKD = NULL --����ڥ������ދN��(�w��)�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_STKD = NULL --����ڥ������ދN��(�w��)�ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STKD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_STKD = :" & Ubound(strBindField) - 1 & " --����ڥ������ދN��(�w��)�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_STKD = :" & Ubound(strBindField) - 1 & " --����ڥ������ދN��(�w��)�ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_STED) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_STED = NULL --����ڥ������މ^�]�I��(�w��)�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_STED = NULL --����ڥ������މ^�]�I��(�w��)�ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STED
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_STED = :" & Ubound(strBindField) - 1 & " --����ڥ������މ^�]�I��(�w��)�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_STED = :" & Ubound(strBindField) - 1 & " --����ڥ������މ^�]�I��(�w��)�ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_STPT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_STPT = NULL --����ڥ������ސϕt����ݐݒ�(�w��)�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_STPT = NULL --����ڥ������ސϕt����ݐݒ�(�w��)�ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STPT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_STPT = :" & Ubound(strBindField) - 1 & " --����ڥ������ސϕt����ݐݒ�(�w��)�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_STPT = :" & Ubound(strBindField) - 1 & " --����ڥ������ސϕt����ݐݒ�(�w��)�ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_STCL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_STCL = NULL --����ڥ��������ް��ر(�w��)�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_STCL = NULL --����ڥ��������ް��ر(�w��)�ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STCL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_STCL = :" & Ubound(strBindField) - 1 & " --����ڥ��������ް��ر(�w��)�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_STCL = :" & Ubound(strBindField) - 1 & " --����ڥ��������ް��ر(�w��)�ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_STKN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_STKN = NULL --����ڥ��������ް��ر����(�w��)�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_STKN = NULL --����ڥ��������ް��ر����(�w��)�ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STKN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_STKN = :" & Ubound(strBindField) - 1 & " --����ڥ��������ް��ر����(�w��)�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_STKN = :" & Ubound(strBindField) - 1 & " --����ڥ��������ް��ر����(�w��)�ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_STST) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_STST = NULL --����ڥ������މ^�]��~(�w��)�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_STST = NULL --����ڥ������މ^�]��~(�w��)�ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STST
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_STST = :" & Ubound(strBindField) - 1 & " --����ڥ������މ^�]��~(�w��)�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_STST = :" & Ubound(strBindField) - 1 & " --����ڥ������މ^�]��~(�w��)�ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_STHR) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_STHR = NULL --����ڥ������ޕ��o��~(�w��)�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_STHR = NULL --����ڥ������ޕ��o��~(�w��)�ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STHR
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_STHR = :" & Ubound(strBindField) - 1 & " --����ڥ������ޕ��o��~(�w��)�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_STHR = :" & Ubound(strBindField) - 1 & " --����ڥ������ޕ��o��~(�w��)�ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_KIDO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_KIDO = NULL --����ڥ������ދN��ANS�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_KIDO = NULL --����ڥ������ދN��ANS�ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KIDO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_KIDO = :" & Ubound(strBindField) - 1 & " --����ڥ������ދN��ANS�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_KIDO = :" & Ubound(strBindField) - 1 & " --����ڥ������ދN��ANS�ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_ONLN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_ONLN = NULL --����ڥ������޵�ײ�ANS�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_ONLN = NULL --����ڥ������޵�ײ�ANS�ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_ONLN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_ONLN = :" & Ubound(strBindField) - 1 & " --����ڥ������޵�ײ�ANS�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_ONLN = :" & Ubound(strBindField) - 1 & " --����ڥ������޵�ײ�ANS�ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_OFLN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_OFLN = NULL --����ڥ������޵�ײ�ANS�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_OFLN = NULL --����ڥ������޵�ײ�ANS�ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_OFLN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_OFLN = :" & Ubound(strBindField) - 1 & " --����ڥ������޵�ײ�ANS�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_OFLN = :" & Ubound(strBindField) - 1 & " --����ڥ������޵�ײ�ANS�ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_IJOU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_IJOU = NULL --����ڥ������ވꊇ�ُ�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_IJOU = NULL --����ڥ������ވꊇ�ُ�ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_IJOU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_IJOU = :" & Ubound(strBindField) - 1 & " --����ڥ������ވꊇ�ُ�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_IJOU = :" & Ubound(strBindField) - 1 & " --����ڥ������ވꊇ�ُ�ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_KEHO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_KEHO = NULL --����ڥ������ތx��ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_KEHO = NULL --����ڥ������ތx��ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KEHO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_KEHO = :" & Ubound(strBindField) - 1 & " --����ڥ������ތx��ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_KEHO = :" & Ubound(strBindField) - 1 & " --����ڥ������ތx��ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_PLPT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_PLPT = NULL --����ڥ������ސϕt����ݐݒ��v�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_PLPT = NULL --����ڥ������ސϕt����ݐݒ��v�ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_PLPT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_PLPT = :" & Ubound(strBindField) - 1 & " --����ڥ������ސϕt����ݐݒ��v�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_PLPT = :" & Ubound(strBindField) - 1 & " --����ڥ������ސϕt����ݐݒ��v�ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_REDY) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_REDY = NULL --����ڥ������ދN���\�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_REDY = NULL --����ڥ������ދN���\�ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_REDY
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_REDY = :" & Ubound(strBindField) - 1 & " --����ڥ������ދN���\�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_REDY = :" & Ubound(strBindField) - 1 & " --����ڥ������ދN���\�ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_SYRY) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_SYRY = NULL --����ڥ������ޏI���v���ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_SYRY = NULL --����ڥ������ޏI���v���ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_SYRY
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_SYRY = :" & Ubound(strBindField) - 1 & " --����ڥ������ޏI���v���ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_SYRY = :" & Ubound(strBindField) - 1 & " --����ڥ������ޏI���v���ݔ�ID")
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
        If IsNull(XDPL_PL_NO) = True Then
            strSQL.Append(vbCrLf & "    AND XDPL_PL_NO IS NULL --����ڥ������ޔԍ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_NO
            strSQL.Append(vbCrLf & "    AND XDPL_PL_NO = :" & UBound(strBindField) - 1 & " --����ڥ������ޔԍ�")
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
    Public Sub ADD_XMST_DPL_PL()
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
        ElseIf IsNull(mXDPL_PL_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[����ڥ������ޔԍ�]"
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
        strSQL.Append(vbCrLf & "    XMST_DPL_PL")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
        If IsNull(mXDPL_PL_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����ڥ������ޔԍ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����ڥ������ޔԍ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����ڥ������ޔԍ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����ڥ������ޔԍ�")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����ڥ������ޖ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����ڥ������ޖ���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����ڥ������ޖ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����ڥ������ޖ���")
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
        If IsNull(mXDPL_PL_EQ_ID_HINM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����ڥ������ޕi���ސݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����ڥ������ޕi���ސݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_HINM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����ڥ������ޕi���ސݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����ڥ������ޕi���ސݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_PL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����ڥ������ސ��Y��گĐ��ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����ڥ������ސ��Y��گĐ��ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_PL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����ڥ������ސ��Y��گĐ��ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����ڥ������ސ��Y��گĐ��ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_HASU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����ڥ������ޒ[���ް��ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����ڥ������ޒ[���ް��ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_HASU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����ڥ������ޒ[���ް��ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����ڥ������ޒ[���ް��ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_TRBL_HH) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����ڥ�����������َ��Ԑݔ�ID(��)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����ڥ�����������َ��Ԑݔ�ID(��)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL_HH
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����ڥ�����������َ��Ԑݔ�ID(��)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����ڥ�����������َ��Ԑݔ�ID(��)")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_TRBL_MM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����ڥ�����������َ��Ԑݔ�ID(��)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����ڥ�����������َ��Ԑݔ�ID(��)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL_MM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����ڥ�����������َ��Ԑݔ�ID(��)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����ڥ�����������َ��Ԑݔ�ID(��)")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_TRBL_SS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����ڥ�����������َ��Ԑݔ�ID(�b)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����ڥ�����������َ��Ԑݔ�ID(�b)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL_SS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����ڥ�����������َ��Ԑݔ�ID(�b)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����ڥ�����������َ��Ԑݔ�ID(�b)")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_TRBL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����ڥ�����������ٌ����ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����ڥ�����������ٌ����ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����ڥ�����������ٌ����ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����ڥ�����������ٌ����ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_COUNT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����ڥ������ސϕt���ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����ڥ������ސϕt���ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_COUNT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����ڥ������ސϕt���ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����ڥ������ސϕt���ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_KADOU_HH) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����ڥ������މ^�]���Ԑݔ�ID(��)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����ڥ������މ^�]���Ԑݔ�ID(��)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KADOU_HH
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����ڥ������މ^�]���Ԑݔ�ID(��)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����ڥ������މ^�]���Ԑݔ�ID(��)")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_KADOU_MM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����ڥ������މ^�]���Ԑݔ�ID(��)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����ڥ������މ^�]���Ԑݔ�ID(��)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KADOU_MM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����ڥ������މ^�]���Ԑݔ�ID(��)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����ڥ������މ^�]���Ԑݔ�ID(��)")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_KADOU_SS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����ڥ������މ^�]���Ԑݔ�ID(�b)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����ڥ������މ^�]���Ԑݔ�ID(�b)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KADOU_SS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����ڥ������މ^�]���Ԑݔ�ID(�b)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����ڥ������މ^�]���Ԑݔ�ID(�b)")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_STKD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����ڥ������ދN��(�w��)�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����ڥ������ދN��(�w��)�ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STKD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����ڥ������ދN��(�w��)�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����ڥ������ދN��(�w��)�ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_STED) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����ڥ������މ^�]�I��(�w��)�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����ڥ������މ^�]�I��(�w��)�ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STED
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����ڥ������މ^�]�I��(�w��)�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����ڥ������މ^�]�I��(�w��)�ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_STPT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����ڥ������ސϕt����ݐݒ�(�w��)�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����ڥ������ސϕt����ݐݒ�(�w��)�ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STPT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����ڥ������ސϕt����ݐݒ�(�w��)�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����ڥ������ސϕt����ݐݒ�(�w��)�ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_STCL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����ڥ��������ް��ر(�w��)�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����ڥ��������ް��ر(�w��)�ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STCL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����ڥ��������ް��ر(�w��)�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����ڥ��������ް��ر(�w��)�ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_STKN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����ڥ��������ް��ر����(�w��)�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����ڥ��������ް��ر����(�w��)�ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STKN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����ڥ��������ް��ر����(�w��)�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����ڥ��������ް��ر����(�w��)�ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_STST) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����ڥ������މ^�]��~(�w��)�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����ڥ������މ^�]��~(�w��)�ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STST
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����ڥ������މ^�]��~(�w��)�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����ڥ������މ^�]��~(�w��)�ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_STHR) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����ڥ������ޕ��o��~(�w��)�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����ڥ������ޕ��o��~(�w��)�ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STHR
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����ڥ������ޕ��o��~(�w��)�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����ڥ������ޕ��o��~(�w��)�ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_KIDO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����ڥ������ދN��ANS�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����ڥ������ދN��ANS�ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KIDO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����ڥ������ދN��ANS�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����ڥ������ދN��ANS�ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_ONLN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����ڥ������޵�ײ�ANS�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����ڥ������޵�ײ�ANS�ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_ONLN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����ڥ������޵�ײ�ANS�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����ڥ������޵�ײ�ANS�ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_OFLN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����ڥ������޵�ײ�ANS�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����ڥ������޵�ײ�ANS�ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_OFLN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����ڥ������޵�ײ�ANS�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����ڥ������޵�ײ�ANS�ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_IJOU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����ڥ������ވꊇ�ُ�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����ڥ������ވꊇ�ُ�ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_IJOU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����ڥ������ވꊇ�ُ�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����ڥ������ވꊇ�ُ�ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_KEHO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����ڥ������ތx��ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����ڥ������ތx��ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KEHO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����ڥ������ތx��ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����ڥ������ތx��ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_PLPT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����ڥ������ސϕt����ݐݒ��v�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����ڥ������ސϕt����ݐݒ��v�ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_PLPT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����ڥ������ސϕt����ݐݒ��v�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����ڥ������ސϕt����ݐݒ��v�ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_REDY) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����ڥ������ދN���\�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����ڥ������ދN���\�ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_REDY
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����ڥ������ދN���\�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����ڥ������ދN���\�ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_SYRY) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����ڥ������ޏI���v���ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����ڥ������ޏI���v���ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_SYRY
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����ڥ������ޏI���v���ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����ڥ������ޏI���v���ݔ�ID")
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
    Public Sub DELETE_XMST_DPL_PL()
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
        ElseIf IsNull(mXDPL_PL_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[����ڥ������ޔԍ�]"
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
        strSQL.Append(vbCrLf & "    XMST_DPL_PL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(XDPL_PL_NO) = True Then
            strSQL.Append(vbCrLf & "    AND XDPL_PL_NO IS NULL --����ڥ������ޔԍ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_NO
            strSQL.Append(vbCrLf & "    AND XDPL_PL_NO = :" & UBound(strBindField) - 1 & " --����ڥ������ޔԍ�")
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
    Public Sub DELETE_XMST_DPL_PL_ANY()
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
        strSQL.Append(vbCrLf & "    XMST_DPL_PL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(XDPL_PL_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_NO
            strSQL.Append(vbCrLf & "    AND XDPL_PL_NO = :" & UBound(strBindField) - 1 & " --����ڥ������ޔԍ�")
        End If
        If IsNotNull(XDPL_PL_NAME) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_NAME
            strSQL.Append(vbCrLf & "    AND XDPL_PL_NAME = :" & UBound(strBindField) - 1 & " --����ڥ������ޖ���")
        End If
        If IsNotNull(XPROD_LINE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPROD_LINE
            strSQL.Append(vbCrLf & "    AND XPROD_LINE = :" & UBound(strBindField) - 1 & " --���Yײ݇�")
        End If
        If IsNotNull(FTRK_BUF_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧��")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_HINM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_HINM
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_HINM = :" & UBound(strBindField) - 1 & " --����ڥ������ޕi���ސݔ�ID")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_PL) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_PL
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_PL = :" & UBound(strBindField) - 1 & " --����ڥ������ސ��Y��گĐ��ݔ�ID")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_HASU) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_HASU
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_HASU = :" & UBound(strBindField) - 1 & " --����ڥ������ޒ[���ް��ݔ�ID")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_TRBL_HH) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL_HH
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_TRBL_HH = :" & UBound(strBindField) - 1 & " --����ڥ�����������َ��Ԑݔ�ID(��)")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_TRBL_MM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL_MM
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_TRBL_MM = :" & UBound(strBindField) - 1 & " --����ڥ�����������َ��Ԑݔ�ID(��)")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_TRBL_SS) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL_SS
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_TRBL_SS = :" & UBound(strBindField) - 1 & " --����ڥ�����������َ��Ԑݔ�ID(�b)")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_TRBL) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_TRBL = :" & UBound(strBindField) - 1 & " --����ڥ�����������ٌ����ݔ�ID")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_COUNT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_COUNT
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_COUNT = :" & UBound(strBindField) - 1 & " --����ڥ������ސϕt���ݔ�ID")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_KADOU_HH) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KADOU_HH
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_KADOU_HH = :" & UBound(strBindField) - 1 & " --����ڥ������މ^�]���Ԑݔ�ID(��)")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_KADOU_MM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KADOU_MM
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_KADOU_MM = :" & UBound(strBindField) - 1 & " --����ڥ������މ^�]���Ԑݔ�ID(��)")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_KADOU_SS) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KADOU_SS
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_KADOU_SS = :" & UBound(strBindField) - 1 & " --����ڥ������މ^�]���Ԑݔ�ID(�b)")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_STKD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STKD
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STKD = :" & UBound(strBindField) - 1 & " --����ڥ������ދN��(�w��)�ݔ�ID")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_STED) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STED
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STED = :" & UBound(strBindField) - 1 & " --����ڥ������މ^�]�I��(�w��)�ݔ�ID")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_STPT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STPT
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STPT = :" & UBound(strBindField) - 1 & " --����ڥ������ސϕt����ݐݒ�(�w��)�ݔ�ID")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_STCL) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STCL
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STCL = :" & UBound(strBindField) - 1 & " --����ڥ��������ް��ر(�w��)�ݔ�ID")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_STKN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STKN
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STKN = :" & UBound(strBindField) - 1 & " --����ڥ��������ް��ر����(�w��)�ݔ�ID")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_STST) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STST
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STST = :" & UBound(strBindField) - 1 & " --����ڥ������މ^�]��~(�w��)�ݔ�ID")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_STHR) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STHR
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STHR = :" & UBound(strBindField) - 1 & " --����ڥ������ޕ��o��~(�w��)�ݔ�ID")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_KIDO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KIDO
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_KIDO = :" & UBound(strBindField) - 1 & " --����ڥ������ދN��ANS�ݔ�ID")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_ONLN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_ONLN
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_ONLN = :" & UBound(strBindField) - 1 & " --����ڥ������޵�ײ�ANS�ݔ�ID")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_OFLN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_OFLN
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_OFLN = :" & UBound(strBindField) - 1 & " --����ڥ������޵�ײ�ANS�ݔ�ID")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_IJOU) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_IJOU
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_IJOU = :" & UBound(strBindField) - 1 & " --����ڥ������ވꊇ�ُ�ݔ�ID")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_KEHO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KEHO
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_KEHO = :" & UBound(strBindField) - 1 & " --����ڥ������ތx��ݔ�ID")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_PLPT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_PLPT
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_PLPT = :" & UBound(strBindField) - 1 & " --����ڥ������ސϕt����ݐݒ��v�ݔ�ID")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_REDY) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_REDY
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_REDY = :" & UBound(strBindField) - 1 & " --����ڥ������ދN���\�ݔ�ID")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_SYRY) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_SYRY
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_SYRY = :" & UBound(strBindField) - 1 & " --����ڥ������ޏI���v���ݔ�ID")
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
        If IsNothing(objType.GetProperty("XDPL_PL_NO")) = False Then mXDPL_PL_NO = objObject.XDPL_PL_NO '����ڥ������ޔԍ�
        If IsNothing(objType.GetProperty("XDPL_PL_NAME")) = False Then mXDPL_PL_NAME = objObject.XDPL_PL_NAME '����ڥ������ޖ���
        If IsNothing(objType.GetProperty("XPROD_LINE")) = False Then mXPROD_LINE = objObject.XPROD_LINE '���Yײ݇�
        If IsNothing(objType.GetProperty("FTRK_BUF_NO")) = False Then mFTRK_BUF_NO = objObject.FTRK_BUF_NO '�ׯ�ݸ��ޯ̧��
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_HINM")) = False Then mXDPL_PL_EQ_ID_HINM = objObject.XDPL_PL_EQ_ID_HINM '����ڥ������ޕi���ސݔ�ID
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_PL")) = False Then mXDPL_PL_EQ_ID_PL = objObject.XDPL_PL_EQ_ID_PL '����ڥ������ސ��Y��گĐ��ݔ�ID
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_HASU")) = False Then mXDPL_PL_EQ_ID_HASU = objObject.XDPL_PL_EQ_ID_HASU '����ڥ������ޒ[���ް��ݔ�ID
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_TRBL_HH")) = False Then mXDPL_PL_EQ_ID_TRBL_HH = objObject.XDPL_PL_EQ_ID_TRBL_HH '����ڥ�����������َ��Ԑݔ�ID(��)
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_TRBL_MM")) = False Then mXDPL_PL_EQ_ID_TRBL_MM = objObject.XDPL_PL_EQ_ID_TRBL_MM '����ڥ�����������َ��Ԑݔ�ID(��)
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_TRBL_SS")) = False Then mXDPL_PL_EQ_ID_TRBL_SS = objObject.XDPL_PL_EQ_ID_TRBL_SS '����ڥ�����������َ��Ԑݔ�ID(�b)
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_TRBL")) = False Then mXDPL_PL_EQ_ID_TRBL = objObject.XDPL_PL_EQ_ID_TRBL '����ڥ�����������ٌ����ݔ�ID
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_COUNT")) = False Then mXDPL_PL_EQ_ID_COUNT = objObject.XDPL_PL_EQ_ID_COUNT '����ڥ������ސϕt���ݔ�ID
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_KADOU_HH")) = False Then mXDPL_PL_EQ_ID_KADOU_HH = objObject.XDPL_PL_EQ_ID_KADOU_HH '����ڥ������މ^�]���Ԑݔ�ID(��)
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_KADOU_MM")) = False Then mXDPL_PL_EQ_ID_KADOU_MM = objObject.XDPL_PL_EQ_ID_KADOU_MM '����ڥ������މ^�]���Ԑݔ�ID(��)
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_KADOU_SS")) = False Then mXDPL_PL_EQ_ID_KADOU_SS = objObject.XDPL_PL_EQ_ID_KADOU_SS '����ڥ������މ^�]���Ԑݔ�ID(�b)
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_STKD")) = False Then mXDPL_PL_EQ_ID_STKD = objObject.XDPL_PL_EQ_ID_STKD '����ڥ������ދN��(�w��)�ݔ�ID
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_STED")) = False Then mXDPL_PL_EQ_ID_STED = objObject.XDPL_PL_EQ_ID_STED '����ڥ������މ^�]�I��(�w��)�ݔ�ID
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_STPT")) = False Then mXDPL_PL_EQ_ID_STPT = objObject.XDPL_PL_EQ_ID_STPT '����ڥ������ސϕt����ݐݒ�(�w��)�ݔ�ID
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_STCL")) = False Then mXDPL_PL_EQ_ID_STCL = objObject.XDPL_PL_EQ_ID_STCL '����ڥ��������ް��ر(�w��)�ݔ�ID
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_STKN")) = False Then mXDPL_PL_EQ_ID_STKN = objObject.XDPL_PL_EQ_ID_STKN '����ڥ��������ް��ر����(�w��)�ݔ�ID
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_STST")) = False Then mXDPL_PL_EQ_ID_STST = objObject.XDPL_PL_EQ_ID_STST '����ڥ������މ^�]��~(�w��)�ݔ�ID
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_STHR")) = False Then mXDPL_PL_EQ_ID_STHR = objObject.XDPL_PL_EQ_ID_STHR '����ڥ������ޕ��o��~(�w��)�ݔ�ID
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_KIDO")) = False Then mXDPL_PL_EQ_ID_KIDO = objObject.XDPL_PL_EQ_ID_KIDO '����ڥ������ދN��ANS�ݔ�ID
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_ONLN")) = False Then mXDPL_PL_EQ_ID_ONLN = objObject.XDPL_PL_EQ_ID_ONLN '����ڥ������޵�ײ�ANS�ݔ�ID
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_OFLN")) = False Then mXDPL_PL_EQ_ID_OFLN = objObject.XDPL_PL_EQ_ID_OFLN '����ڥ������޵�ײ�ANS�ݔ�ID
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_IJOU")) = False Then mXDPL_PL_EQ_ID_IJOU = objObject.XDPL_PL_EQ_ID_IJOU '����ڥ������ވꊇ�ُ�ݔ�ID
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_KEHO")) = False Then mXDPL_PL_EQ_ID_KEHO = objObject.XDPL_PL_EQ_ID_KEHO '����ڥ������ތx��ݔ�ID
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_PLPT")) = False Then mXDPL_PL_EQ_ID_PLPT = objObject.XDPL_PL_EQ_ID_PLPT '����ڥ������ސϕt����ݐݒ��v�ݔ�ID
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_REDY")) = False Then mXDPL_PL_EQ_ID_REDY = objObject.XDPL_PL_EQ_ID_REDY '����ڥ������ދN���\�ݔ�ID
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_SYRY")) = False Then mXDPL_PL_EQ_ID_SYRY = objObject.XDPL_PL_EQ_ID_SYRY '����ڥ������ޏI���v���ݔ�ID
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
        mXDPL_PL_NO = Nothing
        mXDPL_PL_NAME = Nothing
        mXPROD_LINE = Nothing
        mFTRK_BUF_NO = Nothing
        mXDPL_PL_EQ_ID_HINM = Nothing
        mXDPL_PL_EQ_ID_PL = Nothing
        mXDPL_PL_EQ_ID_HASU = Nothing
        mXDPL_PL_EQ_ID_TRBL_HH = Nothing
        mXDPL_PL_EQ_ID_TRBL_MM = Nothing
        mXDPL_PL_EQ_ID_TRBL_SS = Nothing
        mXDPL_PL_EQ_ID_TRBL = Nothing
        mXDPL_PL_EQ_ID_COUNT = Nothing
        mXDPL_PL_EQ_ID_KADOU_HH = Nothing
        mXDPL_PL_EQ_ID_KADOU_MM = Nothing
        mXDPL_PL_EQ_ID_KADOU_SS = Nothing
        mXDPL_PL_EQ_ID_STKD = Nothing
        mXDPL_PL_EQ_ID_STED = Nothing
        mXDPL_PL_EQ_ID_STPT = Nothing
        mXDPL_PL_EQ_ID_STCL = Nothing
        mXDPL_PL_EQ_ID_STKN = Nothing
        mXDPL_PL_EQ_ID_STST = Nothing
        mXDPL_PL_EQ_ID_STHR = Nothing
        mXDPL_PL_EQ_ID_KIDO = Nothing
        mXDPL_PL_EQ_ID_ONLN = Nothing
        mXDPL_PL_EQ_ID_OFLN = Nothing
        mXDPL_PL_EQ_ID_IJOU = Nothing
        mXDPL_PL_EQ_ID_KEHO = Nothing
        mXDPL_PL_EQ_ID_PLPT = Nothing
        mXDPL_PL_EQ_ID_REDY = Nothing
        mXDPL_PL_EQ_ID_SYRY = Nothing
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
        mXDPL_PL_NO = TO_INTEGER_NULLABLE(objRow("XDPL_PL_NO"))
        mXDPL_PL_NAME = TO_STRING_NULLABLE(objRow("XDPL_PL_NAME"))
        mXPROD_LINE = TO_STRING_NULLABLE(objRow("XPROD_LINE"))
        mFTRK_BUF_NO = TO_INTEGER_NULLABLE(objRow("FTRK_BUF_NO"))
        mXDPL_PL_EQ_ID_HINM = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_HINM"))
        mXDPL_PL_EQ_ID_PL = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_PL"))
        mXDPL_PL_EQ_ID_HASU = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_HASU"))
        mXDPL_PL_EQ_ID_TRBL_HH = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_TRBL_HH"))
        mXDPL_PL_EQ_ID_TRBL_MM = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_TRBL_MM"))
        mXDPL_PL_EQ_ID_TRBL_SS = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_TRBL_SS"))
        mXDPL_PL_EQ_ID_TRBL = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_TRBL"))
        mXDPL_PL_EQ_ID_COUNT = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_COUNT"))
        mXDPL_PL_EQ_ID_KADOU_HH = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_KADOU_HH"))
        mXDPL_PL_EQ_ID_KADOU_MM = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_KADOU_MM"))
        mXDPL_PL_EQ_ID_KADOU_SS = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_KADOU_SS"))
        mXDPL_PL_EQ_ID_STKD = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_STKD"))
        mXDPL_PL_EQ_ID_STED = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_STED"))
        mXDPL_PL_EQ_ID_STPT = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_STPT"))
        mXDPL_PL_EQ_ID_STCL = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_STCL"))
        mXDPL_PL_EQ_ID_STKN = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_STKN"))
        mXDPL_PL_EQ_ID_STST = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_STST"))
        mXDPL_PL_EQ_ID_STHR = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_STHR"))
        mXDPL_PL_EQ_ID_KIDO = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_KIDO"))
        mXDPL_PL_EQ_ID_ONLN = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_ONLN"))
        mXDPL_PL_EQ_ID_OFLN = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_OFLN"))
        mXDPL_PL_EQ_ID_IJOU = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_IJOU"))
        mXDPL_PL_EQ_ID_KEHO = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_KEHO"))
        mXDPL_PL_EQ_ID_PLPT = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_PLPT"))
        mXDPL_PL_EQ_ID_REDY = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_REDY"))
        mXDPL_PL_EQ_ID_SYRY = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_SYRY"))
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
        strMsg &= "[ð��ٖ�:����ڥ�������Ͻ�]"
        If IsNotNull(XDPL_PL_NO) Then
            strMsg &= "[����ڥ������ޔԍ�:" & XDPL_PL_NO & "]"
        End If
        If IsNotNull(XDPL_PL_NAME) Then
            strMsg &= "[����ڥ������ޖ���:" & XDPL_PL_NAME & "]"
        End If
        If IsNotNull(XPROD_LINE) Then
            strMsg &= "[���Yײ݇�:" & XPROD_LINE & "]"
        End If
        If IsNotNull(FTRK_BUF_NO) Then
            strMsg &= "[�ׯ�ݸ��ޯ̧��:" & FTRK_BUF_NO & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_HINM) Then
            strMsg &= "[����ڥ������ޕi���ސݔ�ID:" & XDPL_PL_EQ_ID_HINM & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_PL) Then
            strMsg &= "[����ڥ������ސ��Y��گĐ��ݔ�ID:" & XDPL_PL_EQ_ID_PL & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_HASU) Then
            strMsg &= "[����ڥ������ޒ[���ް��ݔ�ID:" & XDPL_PL_EQ_ID_HASU & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_TRBL_HH) Then
            strMsg &= "[����ڥ�����������َ��Ԑݔ�ID(��):" & XDPL_PL_EQ_ID_TRBL_HH & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_TRBL_MM) Then
            strMsg &= "[����ڥ�����������َ��Ԑݔ�ID(��):" & XDPL_PL_EQ_ID_TRBL_MM & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_TRBL_SS) Then
            strMsg &= "[����ڥ�����������َ��Ԑݔ�ID(�b):" & XDPL_PL_EQ_ID_TRBL_SS & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_TRBL) Then
            strMsg &= "[����ڥ�����������ٌ����ݔ�ID:" & XDPL_PL_EQ_ID_TRBL & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_COUNT) Then
            strMsg &= "[����ڥ������ސϕt���ݔ�ID:" & XDPL_PL_EQ_ID_COUNT & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_KADOU_HH) Then
            strMsg &= "[����ڥ������މ^�]���Ԑݔ�ID(��):" & XDPL_PL_EQ_ID_KADOU_HH & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_KADOU_MM) Then
            strMsg &= "[����ڥ������މ^�]���Ԑݔ�ID(��):" & XDPL_PL_EQ_ID_KADOU_MM & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_KADOU_SS) Then
            strMsg &= "[����ڥ������މ^�]���Ԑݔ�ID(�b):" & XDPL_PL_EQ_ID_KADOU_SS & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_STKD) Then
            strMsg &= "[����ڥ������ދN��(�w��)�ݔ�ID:" & XDPL_PL_EQ_ID_STKD & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_STED) Then
            strMsg &= "[����ڥ������މ^�]�I��(�w��)�ݔ�ID:" & XDPL_PL_EQ_ID_STED & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_STPT) Then
            strMsg &= "[����ڥ������ސϕt����ݐݒ�(�w��)�ݔ�ID:" & XDPL_PL_EQ_ID_STPT & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_STCL) Then
            strMsg &= "[����ڥ��������ް��ر(�w��)�ݔ�ID:" & XDPL_PL_EQ_ID_STCL & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_STKN) Then
            strMsg &= "[����ڥ��������ް��ر����(�w��)�ݔ�ID:" & XDPL_PL_EQ_ID_STKN & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_STST) Then
            strMsg &= "[����ڥ������މ^�]��~(�w��)�ݔ�ID:" & XDPL_PL_EQ_ID_STST & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_STHR) Then
            strMsg &= "[����ڥ������ޕ��o��~(�w��)�ݔ�ID:" & XDPL_PL_EQ_ID_STHR & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_KIDO) Then
            strMsg &= "[����ڥ������ދN��ANS�ݔ�ID:" & XDPL_PL_EQ_ID_KIDO & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_ONLN) Then
            strMsg &= "[����ڥ������޵�ײ�ANS�ݔ�ID:" & XDPL_PL_EQ_ID_ONLN & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_OFLN) Then
            strMsg &= "[����ڥ������޵�ײ�ANS�ݔ�ID:" & XDPL_PL_EQ_ID_OFLN & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_IJOU) Then
            strMsg &= "[����ڥ������ވꊇ�ُ�ݔ�ID:" & XDPL_PL_EQ_ID_IJOU & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_KEHO) Then
            strMsg &= "[����ڥ������ތx��ݔ�ID:" & XDPL_PL_EQ_ID_KEHO & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_PLPT) Then
            strMsg &= "[����ڥ������ސϕt����ݐݒ��v�ݔ�ID:" & XDPL_PL_EQ_ID_PLPT & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_REDY) Then
            strMsg &= "[����ڥ������ދN���\�ݔ�ID:" & XDPL_PL_EQ_ID_REDY & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_SYRY) Then
            strMsg &= "[����ڥ������ޏI���v���ݔ�ID:" & XDPL_PL_EQ_ID_SYRY & "]"
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

    '���������ьŗL
    '**********************************************************************************************

End Class
