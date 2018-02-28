'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' �y���́zMaterialStreamð��ٸ׽
' �y�@�\�z���ݽ���ް����ð��ٸ׽
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
''' ���ݽ���ް����ð��ٸ׽
''' </summary>
Public Class TBL_TPRG_SEQNO
    Inherits clsTemplateTable

    '**********************************************************************************************
    '����������������
#Region "  �׽�ϐ���`                  "
    '�����è
    Private mobjAryMe As TBL_TPRG_SEQNO()                                        '���ݽ���ް����
    Private mstrUSER_SQL As String                                               'հ�ްSQL
    Private mORDER_BY As String                                                  'OrderBy��
    Private mWHERE As String                                                     'Where��
    Private mFSEQ_ID As String                                                   '���ݽ���ްID
    Private mFSEQ_NAME As String                                                 '���ݽ���ް����
    Private mFSEQ_NO As Nullable(Of Decimal)                                     '���ݽ���ް
    Private mFSEQ_NO_MAX As Nullable(Of Decimal)                                 '���ݽ���ް�ő�l
    Private mFSEQ_NO_MIN As Nullable(Of Decimal)                                 '���ݽ���ް�ŏ��l
    Private mFUPDATE_DT As Nullable(Of Date)                                     '�X�V����
    Private mFRESET_DT As Nullable(Of Date)                                      'ؾ�ē���
#End Region
#Region "  �����è��`                  "
    ''' <summary>
    ''' ���ѕϐ� (���׽�^�z��)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_TPRG_SEQNO()
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
    ''' ���ݽ���ްID
    ''' </summary>
    Public Property FSEQ_ID() As String
        Get
            Return mFSEQ_ID
        End Get
        Set(ByVal Value As String)
            mFSEQ_ID = Value
        End Set
    End Property
    ''' <summary>
    ''' ���ݽ���ް����
    ''' </summary>
    Public Property FSEQ_NAME() As String
        Get
            Return mFSEQ_NAME
        End Get
        Set(ByVal Value As String)
            mFSEQ_NAME = Value
        End Set
    End Property
    ''' <summary>
    ''' ���ݽ���ް
    ''' </summary>
    Public Property FSEQ_NO() As Nullable(Of Decimal)
        Get
            Return mFSEQ_NO
        End Get
        Set(ByVal Value As Nullable(Of Decimal))
            mFSEQ_NO = Value
        End Set
    End Property
    ''' <summary>
    ''' ���ݽ���ް�ő�l
    ''' </summary>
    Public Property FSEQ_NO_MAX() As Nullable(Of Decimal)
        Get
            Return mFSEQ_NO_MAX
        End Get
        Set(ByVal Value As Nullable(Of Decimal))
            mFSEQ_NO_MAX = Value
        End Set
    End Property
    ''' <summary>
    ''' ���ݽ���ް�ŏ��l
    ''' </summary>
    Public Property FSEQ_NO_MIN() As Nullable(Of Decimal)
        Get
            Return mFSEQ_NO_MIN
        End Get
        Set(ByVal Value As Nullable(Of Decimal))
            mFSEQ_NO_MIN = Value
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
    ''' ؾ�ē���
    ''' </summary>
    Public Property FRESET_DT() As Nullable(Of Date)
        Get
            Return mFRESET_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mFRESET_DT = Value
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
    Public Function GET_TPRG_SEQNO(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    TPRG_SEQNO")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FSEQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_ID
            strSQL.Append(vbCrLf & "    AND FSEQ_ID = :" & UBound(strBindField) - 1 & " --���ݽ���ްID")
        End If
        If IsNull(FSEQ_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NAME
            strSQL.Append(vbCrLf & "    AND FSEQ_NAME = :" & UBound(strBindField) - 1 & " --���ݽ���ް����")
        End If
        If IsNull(FSEQ_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NO
            strSQL.Append(vbCrLf & "    AND FSEQ_NO = :" & UBound(strBindField) - 1 & " --���ݽ���ް")
        End If
        If IsNull(FSEQ_NO_MAX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NO_MAX
            strSQL.Append(vbCrLf & "    AND FSEQ_NO_MAX = :" & UBound(strBindField) - 1 & " --���ݽ���ް�ő�l")
        End If
        If IsNull(FSEQ_NO_MIN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NO_MIN
            strSQL.Append(vbCrLf & "    AND FSEQ_NO_MIN = :" & UBound(strBindField) - 1 & " --���ݽ���ް�ŏ��l")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --�X�V����")
        End If
        If IsNull(FRESET_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRESET_DT
            strSQL.Append(vbCrLf & "    AND FRESET_DT = :" & UBound(strBindField) - 1 & " --ؾ�ē���")
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
        strDataSetName = "TPRG_SEQNO"
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
    Public Function GET_TPRG_SEQNO_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    TPRG_SEQNO")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FSEQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_ID
            strSQL.Append(vbCrLf & "    AND FSEQ_ID = :" & UBound(strBindField) - 1 & " --���ݽ���ްID")
        End If
        If IsNull(FSEQ_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NAME
            strSQL.Append(vbCrLf & "    AND FSEQ_NAME = :" & UBound(strBindField) - 1 & " --���ݽ���ް����")
        End If
        If IsNull(FSEQ_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NO
            strSQL.Append(vbCrLf & "    AND FSEQ_NO = :" & UBound(strBindField) - 1 & " --���ݽ���ް")
        End If
        If IsNull(FSEQ_NO_MAX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NO_MAX
            strSQL.Append(vbCrLf & "    AND FSEQ_NO_MAX = :" & UBound(strBindField) - 1 & " --���ݽ���ް�ő�l")
        End If
        If IsNull(FSEQ_NO_MIN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NO_MIN
            strSQL.Append(vbCrLf & "    AND FSEQ_NO_MIN = :" & UBound(strBindField) - 1 & " --���ݽ���ް�ŏ��l")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --�X�V����")
        End If
        If IsNull(FRESET_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRESET_DT
            strSQL.Append(vbCrLf & "    AND FRESET_DT = :" & UBound(strBindField) - 1 & " --ؾ�ē���")
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
        strDataSetName = "TPRG_SEQNO"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TPRG_SEQNO(Owner, objDb, objDbLog)
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
    Public Function GET_TPRG_SEQNO_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "TPRG_SEQNO"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TPRG_SEQNO(Owner, objDb, objDbLog)
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
    Public Function GET_TPRG_SEQNO_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    TPRG_SEQNO")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FSEQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_ID
            strSQL.Append(vbCrLf & "    AND FSEQ_ID = :" & UBound(strBindField) - 1 & " --���ݽ���ްID")
        End If
        If IsNull(FSEQ_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NAME
            strSQL.Append(vbCrLf & "    AND FSEQ_NAME = :" & UBound(strBindField) - 1 & " --���ݽ���ް����")
        End If
        If IsNull(FSEQ_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NO
            strSQL.Append(vbCrLf & "    AND FSEQ_NO = :" & UBound(strBindField) - 1 & " --���ݽ���ް")
        End If
        If IsNull(FSEQ_NO_MAX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NO_MAX
            strSQL.Append(vbCrLf & "    AND FSEQ_NO_MAX = :" & UBound(strBindField) - 1 & " --���ݽ���ް�ő�l")
        End If
        If IsNull(FSEQ_NO_MIN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NO_MIN
            strSQL.Append(vbCrLf & "    AND FSEQ_NO_MIN = :" & UBound(strBindField) - 1 & " --���ݽ���ް�ŏ��l")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --�X�V����")
        End If
        If IsNull(FRESET_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRESET_DT
            strSQL.Append(vbCrLf & "    AND FRESET_DT = :" & UBound(strBindField) - 1 & " --ؾ�ē���")
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
        strDataSetName = "TPRG_SEQNO"
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
    Public Sub UPDATE_TPRG_SEQNO()
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
        ElseIf IsNull(mFSEQ_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[���ݽ���ްID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFSEQ_NAME) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[���ݽ���ް����]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFSEQ_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[���ݽ���ް]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFSEQ_NO_MAX) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[���ݽ���ް�ő�l]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFSEQ_NO_MIN) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[���ݽ���ް�ŏ��l]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFUPDATE_DT) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�X�V����]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFRESET_DT) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ؾ�ē���]"
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
        strSQL.Append(vbCrLf & "    TPRG_SEQNO")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
        If IsNull(mFSEQ_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSEQ_ID = NULL --���ݽ���ްID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSEQ_ID = NULL --���ݽ���ްID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSEQ_ID = :" & Ubound(strBindField) - 1 & " --���ݽ���ްID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSEQ_ID = :" & Ubound(strBindField) - 1 & " --���ݽ���ްID")
        End If
        intCount = intCount + 1
        If IsNull(mFSEQ_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSEQ_NAME = NULL --���ݽ���ް����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSEQ_NAME = NULL --���ݽ���ް����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSEQ_NAME = :" & Ubound(strBindField) - 1 & " --���ݽ���ް����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSEQ_NAME = :" & Ubound(strBindField) - 1 & " --���ݽ���ް����")
        End If
        intCount = intCount + 1
        If IsNull(mFSEQ_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSEQ_NO = NULL --���ݽ���ް")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSEQ_NO = NULL --���ݽ���ް")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSEQ_NO = :" & Ubound(strBindField) - 1 & " --���ݽ���ް")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSEQ_NO = :" & Ubound(strBindField) - 1 & " --���ݽ���ް")
        End If
        intCount = intCount + 1
        If IsNull(mFSEQ_NO_MAX) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSEQ_NO_MAX = NULL --���ݽ���ް�ő�l")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSEQ_NO_MAX = NULL --���ݽ���ް�ő�l")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NO_MAX
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSEQ_NO_MAX = :" & Ubound(strBindField) - 1 & " --���ݽ���ް�ő�l")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSEQ_NO_MAX = :" & Ubound(strBindField) - 1 & " --���ݽ���ް�ő�l")
        End If
        intCount = intCount + 1
        If IsNull(mFSEQ_NO_MIN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSEQ_NO_MIN = NULL --���ݽ���ް�ŏ��l")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSEQ_NO_MIN = NULL --���ݽ���ް�ŏ��l")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NO_MIN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSEQ_NO_MIN = :" & Ubound(strBindField) - 1 & " --���ݽ���ް�ŏ��l")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSEQ_NO_MIN = :" & Ubound(strBindField) - 1 & " --���ݽ���ް�ŏ��l")
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
        If IsNull(mFRESET_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRESET_DT = NULL --ؾ�ē���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRESET_DT = NULL --ؾ�ē���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRESET_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRESET_DT = :" & Ubound(strBindField) - 1 & " --ؾ�ē���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRESET_DT = :" & Ubound(strBindField) - 1 & " --ؾ�ē���")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FSEQ_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FSEQ_ID IS NULL --���ݽ���ްID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_ID
            strSQL.Append(vbCrLf & "    AND FSEQ_ID = :" & UBound(strBindField) - 1 & " --���ݽ���ްID")
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
    Public Sub ADD_TPRG_SEQNO()
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
        ElseIf IsNull(mFSEQ_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[���ݽ���ްID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFSEQ_NAME) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[���ݽ���ް����]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFSEQ_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[���ݽ���ް]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFSEQ_NO_MAX) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[���ݽ���ް�ő�l]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFSEQ_NO_MIN) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[���ݽ���ް�ŏ��l]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFUPDATE_DT) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�X�V����]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFRESET_DT) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ؾ�ē���]"
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
        strSQL.Append(vbCrLf & "    TPRG_SEQNO")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
        If IsNull(mFSEQ_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���ݽ���ްID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���ݽ���ްID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���ݽ���ްID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���ݽ���ްID")
        End If
        intCount = intCount + 1
        If IsNull(mFSEQ_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���ݽ���ް����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���ݽ���ް����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���ݽ���ް����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���ݽ���ް����")
        End If
        intCount = intCount + 1
        If IsNull(mFSEQ_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���ݽ���ް")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���ݽ���ް")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���ݽ���ް")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���ݽ���ް")
        End If
        intCount = intCount + 1
        If IsNull(mFSEQ_NO_MAX) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���ݽ���ް�ő�l")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���ݽ���ް�ő�l")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NO_MAX
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���ݽ���ް�ő�l")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���ݽ���ް�ő�l")
        End If
        intCount = intCount + 1
        If IsNull(mFSEQ_NO_MIN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���ݽ���ް�ŏ��l")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���ݽ���ް�ŏ��l")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NO_MIN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���ݽ���ް�ŏ��l")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���ݽ���ް�ŏ��l")
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
        If IsNull(mFRESET_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ؾ�ē���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ؾ�ē���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRESET_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ؾ�ē���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ؾ�ē���")
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
    Public Sub DELETE_TPRG_SEQNO()
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
        ElseIf IsNull(mFSEQ_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[���ݽ���ްID]"
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
        strSQL.Append(vbCrLf & "    TPRG_SEQNO")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FSEQ_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FSEQ_ID IS NULL --���ݽ���ްID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_ID
            strSQL.Append(vbCrLf & "    AND FSEQ_ID = :" & UBound(strBindField) - 1 & " --���ݽ���ްID")
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
    Public Sub DELETE_TPRG_SEQNO_ANY()
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
        strSQL.Append(vbCrLf & "    TPRG_SEQNO")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(FSEQ_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_ID
            strSQL.Append(vbCrLf & "    AND FSEQ_ID = :" & UBound(strBindField) - 1 & " --���ݽ���ްID")
        End If
        If IsNotNull(FSEQ_NAME) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NAME
            strSQL.Append(vbCrLf & "    AND FSEQ_NAME = :" & UBound(strBindField) - 1 & " --���ݽ���ް����")
        End If
        If IsNotNull(FSEQ_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NO
            strSQL.Append(vbCrLf & "    AND FSEQ_NO = :" & UBound(strBindField) - 1 & " --���ݽ���ް")
        End If
        If IsNotNull(FSEQ_NO_MAX) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NO_MAX
            strSQL.Append(vbCrLf & "    AND FSEQ_NO_MAX = :" & UBound(strBindField) - 1 & " --���ݽ���ް�ő�l")
        End If
        If IsNotNull(FSEQ_NO_MIN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NO_MIN
            strSQL.Append(vbCrLf & "    AND FSEQ_NO_MIN = :" & UBound(strBindField) - 1 & " --���ݽ���ް�ŏ��l")
        End If
        If IsNotNull(FUPDATE_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --�X�V����")
        End If
        If IsNotNull(FRESET_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRESET_DT
            strSQL.Append(vbCrLf & "    AND FRESET_DT = :" & UBound(strBindField) - 1 & " --ؾ�ē���")
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
        If IsNothing(objType.GetProperty("FSEQ_ID")) = False Then mFSEQ_ID = objObject.FSEQ_ID '���ݽ���ްID
        If IsNothing(objType.GetProperty("FSEQ_NAME")) = False Then mFSEQ_NAME = objObject.FSEQ_NAME '���ݽ���ް����
        If IsNothing(objType.GetProperty("FSEQ_NO")) = False Then mFSEQ_NO = objObject.FSEQ_NO '���ݽ���ް
        If IsNothing(objType.GetProperty("FSEQ_NO_MAX")) = False Then mFSEQ_NO_MAX = objObject.FSEQ_NO_MAX '���ݽ���ް�ő�l
        If IsNothing(objType.GetProperty("FSEQ_NO_MIN")) = False Then mFSEQ_NO_MIN = objObject.FSEQ_NO_MIN '���ݽ���ް�ŏ��l
        If IsNothing(objType.GetProperty("FUPDATE_DT")) = False Then mFUPDATE_DT = objObject.FUPDATE_DT '�X�V����
        If IsNothing(objType.GetProperty("FRESET_DT")) = False Then mFRESET_DT = objObject.FRESET_DT 'ؾ�ē���

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
        mFSEQ_ID = Nothing
        mFSEQ_NAME = Nothing
        mFSEQ_NO = Nothing
        mFSEQ_NO_MAX = Nothing
        mFSEQ_NO_MIN = Nothing
        mFUPDATE_DT = Nothing
        mFRESET_DT = Nothing


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
        mFSEQ_ID = TO_STRING_NULLABLE(objRow("FSEQ_ID"))
        mFSEQ_NAME = TO_STRING_NULLABLE(objRow("FSEQ_NAME"))
        mFSEQ_NO = TO_DECIMAL_NULLABLE(objRow("FSEQ_NO"))
        mFSEQ_NO_MAX = TO_DECIMAL_NULLABLE(objRow("FSEQ_NO_MAX"))
        mFSEQ_NO_MIN = TO_DECIMAL_NULLABLE(objRow("FSEQ_NO_MIN"))
        mFUPDATE_DT = TO_DATE_NULLABLE(objRow("FUPDATE_DT"))
        mFRESET_DT = TO_DATE_NULLABLE(objRow("FRESET_DT"))


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
        strMsg &= "[ð��ٖ�:���ݽ���ް����]"
        If IsNotNull(FSEQ_ID) Then
            strMsg &= "[���ݽ���ްID:" & FSEQ_ID & "]"
        End If
        If IsNotNull(FSEQ_NAME) Then
            strMsg &= "[���ݽ���ް����:" & FSEQ_NAME & "]"
        End If
        If IsNotNull(FSEQ_NO) Then
            strMsg &= "[���ݽ���ް:" & FSEQ_NO & "]"
        End If
        If IsNotNull(FSEQ_NO_MAX) Then
            strMsg &= "[���ݽ���ް�ő�l:" & FSEQ_NO_MAX & "]"
        End If
        If IsNotNull(FSEQ_NO_MIN) Then
            strMsg &= "[���ݽ���ް�ŏ��l:" & FSEQ_NO_MIN & "]"
        End If
        If IsNotNull(FUPDATE_DT) Then
            strMsg &= "[�X�V����:" & FUPDATE_DT & "]"
        End If
        If IsNotNull(FRESET_DT) Then
            strMsg &= "[ؾ�ē���:" & FRESET_DT & "]"
        End If


    End Sub
#End Region
    '����������������
    '**********************************************************************************************

    '**********************************************************************************************
    '���������ы���
#Region "  �o�^���擾�X�V(ComError�Ȃ�)                         (Public  GET_ENTRY_NO)"
    '*******************************************************************************************************************
    '�y�@�\�z����
    '�y�����z�Ȃ�
    '�y�ߒl�z�o�^��
    '*******************************************************************************************************************
    Public Function GET_ENTRY_NO() As String
        Try
            Dim strReturn As String     '�ߒl


            '******************************************************
            '���ݽ���ް�擾
            '******************************************************
            strReturn = GET_ENTRY_NO_KETA(8)


            Return (strReturn)
        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "  �o�^���擾�X�V(ComError�Ȃ����t�����ȊO�̌����w��)   (Public  GET_ENTRY_NO_KETA)"
    '*******************************************************************************************************************
    '�y�@�\�z����
    '�y�����z�Ȃ�
    '�y�ߒl�z�o�^��
    '*******************************************************************************************************************
    Public Function GET_ENTRY_NO_KETA(ByVal intKeta As Integer) As String
        Try
            Dim strReturn As String     '�ߒl


            '******************************************************
            '���ݽ���ް�擾
            '******************************************************
            Dim objTPRG_SEQNO As New clsSeqNo(ObjDbLog)
            Dim intSeqNo As Integer                         '���ݽ��
            objTPRG_SEQNO.userFSEQ_ID = FSEQ_ID             '���ݽ���ްID
            '' ''objTPRG_SEQNO.userstrDBName = "Genshi"          'DB��
            objTPRG_SEQNO.userstrTableName = "TPRG_SEQNO"   'ð��ٖ�
            intSeqNo = objTPRG_SEQNO.userGetUpdateSeqNo()   '���ݽ���擾


            '******************************************************
            '���擾
            '******************************************************
            Call GET_TPRG_SEQNO_COMERRNOTHING()


            '������������************************************************************************************************************
            'SystemMate:N.Dounoshita 2012/12/25  SEQ�����Ԏ���ؾ�Ă���Ȃ��޸ޏC��
            '                                    ���t���؂�ւ�����u�ԂɁA���exe��������SEQ���𔭔Ԃ����ꍇ�A���ݸނɂ���Ă͕Е���SEQ��ؾ�Ă���Ȃ��ꍇ������B


            ''******************************************************
            ''���ݽ���ްؾ��
            ''******************************************************
            'Dim strResetDate As String = Format(mFRESET_DT, "yyyy/MM/dd")       'ؾ�ē��t
            'Dim strUpdateDate As String = Format(mFUPDATE_DT, "yyyy/MM/dd")     '�X�V����
            'Dim dtmResetDate As Date = CDate(strResetDate)                      'ؾ�ē��t
            'Dim dtmUpdateDate As Date = CDate(strUpdateDate)                    '�X�V����
            'If DateAdd(DateInterval.Day, 1, dtmResetDate) <= dtmUpdateDate Then
            '    '(�ŏIؾ�ē����������ȏ�o�߂��Ă����ꍇ)

            '    Call objTPRG_SEQNO.userResetSeqNo()             '���ݽ��ؾ��
            '    intSeqNo = objTPRG_SEQNO.userGetUpdateSeqNo()   '���ݽ���擾
            '    Call GET_TPRG_SEQNO_COMERRNOTHING()             '���擾

            'End If


            '������������************************************************************************************************************


            '******************************************************
            '۸����ް�쐬
            '******************************************************
            Dim strLogDate As String = Format(mFRESET_DT, "yyyyMMdd")       '�X�V����
            strReturn = strLogDate & ZERO_PAD(intSeqNo, intKeta)            '۸����ް�쐬


            Return (strReturn)
        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "  �o�^���擾�X�V(���د��p)(ComError�Ȃ�)               (Public  GET_ENTRY_NO_CYCLIC)"
    '*******************************************************************************************************************
    '�y�@�\�z����
    '�y�����z�Ȃ�
    '�y�ߒl�z�o�^��
    '*******************************************************************************************************************
    Public Function GET_ENTRY_NO_CYCLIC() As String
        Try
            Dim strReturn As String     '�ߒl


            '******************************************************
            '���ݽ���ް�擾
            '******************************************************
            Dim objTPRG_SEQNO As New clsSeqNo(ObjDbLog)
            Dim intSeqNo As Integer                         '���ݽ��
            objTPRG_SEQNO.userFSEQ_ID = FSEQ_ID             '���ݽ���ްID
            '' ''objTPRG_SEQNO.userstrDBName = "Genshi"          'DB��
            objTPRG_SEQNO.userstrTableName = "TPRG_SEQNO"   'ð��ٖ�
            intSeqNo = objTPRG_SEQNO.userGetUpdateSeqNo()   '���ݽ���擾


            '******************************************************
            '���擾
            '******************************************************
            Call GET_TPRG_SEQNO_COMERRNOTHING()


            '******************************************************
            '۸����ް�쐬
            '******************************************************
            Dim strLogDate As String = Format(mFUPDATE_DT, "yyyyMMdd")      '�X�V����
            strReturn = ZERO_PAD(intSeqNo, 16)                              '۸����ް�쐬


            Return (strReturn)
        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "  ���ݽ���ް���Ԏ擾(ComError�Ȃ�)                     (Private GET_TPRG_SEQNO_COMERRNOTHING)"
    Private Function GET_TPRG_SEQNO_COMERRNOTHING() As RetCode
        Try
            Dim strSQL As String            'SQL��
            Dim strMsg As String            'ү����
            Dim objDataSet As New DataSet   '�ް����
            Dim strDataSetName As String    '�ް���Ė�
            Dim objRow As DataRow           '1ں��ޕ����ް�

            '***********************
            '�����è����
            '***********************
            If mFSEQ_ID = DEFAULT_STRING Then
                strMsg = ERRMSG_ERR_PROPERTY & "[���ݽ���ްID]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '���oSQL�쐬
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    *"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TPRG_SEQNO"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FSEQ_ID = '" & TO_STRING(mFSEQ_ID) & "'"
            strSQL &= vbCrLf


            '***********************
            '���o
            '***********************
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TPRG_SEQNO"
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

#Region "  �o�^���擾�X�V(ComError�Ȃ����t�Ȃ������w��)   (Public  GET_ENTRY_NO_KETA_NODATE)"
    '*******************************************************************************************************************
    '�y�@�\�z����
    '�y�����z�Ȃ�
    '�y�ߒl�z�o�^��
    '*******************************************************************************************************************
    Public Function GET_ENTRY_NO_KETA_NODATE(ByVal intKeta As Integer) As String
        Try
            Dim strReturn As String     '�ߒl


            '******************************************************
            '���ݽ���ް�擾
            '******************************************************
            Dim objTPRG_SEQNO As New clsSeqNo(ObjDbLog)
            Dim intSeqNo As Integer                         '���ݽ��
            objTPRG_SEQNO.userFSEQ_ID = FSEQ_ID             '���ݽ���ްID
            '' ''objTPRG_SEQNO.userstrDBName = "Genshi"          'DB��
            objTPRG_SEQNO.userstrTableName = "TPRG_SEQNO"   'ð��ٖ�
            intSeqNo = objTPRG_SEQNO.userGetUpdateSeqNo()   '���ݽ���擾


            '******************************************************
            '���擾
            '******************************************************
            Call GET_TPRG_SEQNO_COMERRNOTHING()


            '������������************************************************************************************************************
            'SystemMate:N.Dounoshita 2012/12/25  SEQ�����Ԏ���ؾ�Ă���Ȃ��޸ޏC��
            '                                    ���t���؂�ւ�����u�ԂɁA���exe��������SEQ���𔭔Ԃ����ꍇ�A���ݸނɂ���Ă͕Е���SEQ��ؾ�Ă���Ȃ��ꍇ������B


            ''******************************************************
            ''���ݽ���ްؾ��
            ''******************************************************
            'Dim strResetDate As String = Format(mFRESET_DT, "yyyy/MM/dd")       'ؾ�ē��t
            'Dim strUpdateDate As String = Format(mFUPDATE_DT, "yyyy/MM/dd")     '�X�V����
            'Dim dtmResetDate As Date = CDate(strResetDate)                      'ؾ�ē��t
            'Dim dtmUpdateDate As Date = CDate(strUpdateDate)                    '�X�V����
            'If DateAdd(DateInterval.Day, 1, dtmResetDate) <= dtmUpdateDate Then
            '    '(�ŏIؾ�ē����������ȏ�o�߂��Ă����ꍇ)

            '    Call objTPRG_SEQNO.userResetSeqNo()             '���ݽ��ؾ��
            '    intSeqNo = objTPRG_SEQNO.userGetUpdateSeqNo()   '���ݽ���擾
            '    Call GET_TPRG_SEQNO_COMERRNOTHING()             '���擾

            'End If


            '������������************************************************************************************************************


            '******************************************************
            '۸����ް�쐬
            '******************************************************

            Dim strLogDate As String = Format(mFRESET_DT, "yyMMdd")       '�X�V����
            strReturn = Right(strLogDate & ZERO_PAD(intSeqNo, intKeta - 6), intKeta)            '۸����ް�쐬


            Return (strReturn)
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

    '���������ьŗL
    '**********************************************************************************************

End Class
