'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' �y���́zMaterialStreamð��ٸ׽
' �y�@�\�z�o�׺���ԏ�ð��ٸ׽
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
''' �o�׺���ԏ�ð��ٸ׽
''' </summary>
Public Class TBL_XSTS_CONVEYOR
    Inherits clsTemplateTable

    '**********************************************************************************************
    '����������������
#Region "  �׽�ϐ���`                  "
    '�����è
    Private mobjAryMe As TBL_XSTS_CONVEYOR()                                     '�o�׺���ԏ�
    Private mstrUSER_SQL As String                                               'հ�ްSQL
    Private mORDER_BY As String                                                  'OrderBy��
    Private mWHERE As String                                                     'Where��
    Private mXSTNO As Nullable(Of Integer)                                       'STNo.
    Private mFEQ_LOCATION As Nullable(Of Integer)                                '�ݔ�۹����
    Private mXCONVEYOR_YOUTO As Nullable(Of Integer)                             '����ԗp�r
    Private mFUPDATE_DT As Nullable(Of Date)                                     '�X�V����
    Private mXCONVEYOR_GROUP As Nullable(Of Integer)                             '����Ը�ٰ��
    Private mXCONVEYOR_ORDER As Nullable(Of Integer)                             '����ԏ�
    Private mXBERTH_GROUP As Nullable(Of Integer)                                '�ް���ٰ��
#End Region
#Region "  �����è��`                  "
    ''' <summary>
    ''' ���ѕϐ� (���׽�^�z��)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_XSTS_CONVEYOR()
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
    ''' STNo.
    ''' </summary>
    Public Property XSTNO() As Nullable(Of Integer)
        Get
            Return mXSTNO
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXSTNO = Value
        End Set
    End Property
    ''' <summary>
    ''' �ݔ�۹����
    ''' </summary>
    Public Property FEQ_LOCATION() As Nullable(Of Integer)
        Get
            Return mFEQ_LOCATION
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFEQ_LOCATION = Value
        End Set
    End Property
    ''' <summary>
    ''' ����ԗp�r
    ''' </summary>
    Public Property XCONVEYOR_YOUTO() As Nullable(Of Integer)
        Get
            Return mXCONVEYOR_YOUTO
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXCONVEYOR_YOUTO = Value
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
    ''' ����Ը�ٰ��
    ''' </summary>
    Public Property XCONVEYOR_GROUP() As Nullable(Of Integer)
        Get
            Return mXCONVEYOR_GROUP
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXCONVEYOR_GROUP = Value
        End Set
    End Property
    ''' <summary>
    ''' ����ԏ�
    ''' </summary>
    Public Property XCONVEYOR_ORDER() As Nullable(Of Integer)
        Get
            Return mXCONVEYOR_ORDER
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXCONVEYOR_ORDER = Value
        End Set
    End Property
    ''' <summary>
    ''' �ް���ٰ��
    ''' </summary>
    Public Property XBERTH_GROUP() As Nullable(Of Integer)
        Get
            Return mXBERTH_GROUP
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXBERTH_GROUP = Value
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
    Public Function GET_XSTS_CONVEYOR(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    XSTS_CONVEYOR")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XSTNO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSTNO
            strSQL.Append(vbCrLf & "    AND XSTNO = :" & UBound(strBindField) - 1 & " --STNo.")
        End If
        If IsNull(FEQ_LOCATION) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_LOCATION
            strSQL.Append(vbCrLf & "    AND FEQ_LOCATION = :" & UBound(strBindField) - 1 & " --�ݔ�۹����")
        End If
        If IsNull(XCONVEYOR_YOUTO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCONVEYOR_YOUTO
            strSQL.Append(vbCrLf & "    AND XCONVEYOR_YOUTO = :" & UBound(strBindField) - 1 & " --����ԗp�r")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --�X�V����")
        End If
        If IsNull(XCONVEYOR_GROUP) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCONVEYOR_GROUP
            strSQL.Append(vbCrLf & "    AND XCONVEYOR_GROUP = :" & UBound(strBindField) - 1 & " --����Ը�ٰ��")
        End If
        If IsNull(XCONVEYOR_ORDER) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCONVEYOR_ORDER
            strSQL.Append(vbCrLf & "    AND XCONVEYOR_ORDER = :" & UBound(strBindField) - 1 & " --����ԏ�")
        End If
        If IsNull(XBERTH_GROUP) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_GROUP
            strSQL.Append(vbCrLf & "    AND XBERTH_GROUP = :" & UBound(strBindField) - 1 & " --�ް���ٰ��")
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
        strDataSetName = "XSTS_CONVEYOR"
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
    Public Function GET_XSTS_CONVEYOR_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    XSTS_CONVEYOR")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XSTNO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSTNO
            strSQL.Append(vbCrLf & "    AND XSTNO = :" & UBound(strBindField) - 1 & " --STNo.")
        End If
        If IsNull(FEQ_LOCATION) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_LOCATION
            strSQL.Append(vbCrLf & "    AND FEQ_LOCATION = :" & UBound(strBindField) - 1 & " --�ݔ�۹����")
        End If
        If IsNull(XCONVEYOR_YOUTO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCONVEYOR_YOUTO
            strSQL.Append(vbCrLf & "    AND XCONVEYOR_YOUTO = :" & UBound(strBindField) - 1 & " --����ԗp�r")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --�X�V����")
        End If
        If IsNull(XCONVEYOR_GROUP) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCONVEYOR_GROUP
            strSQL.Append(vbCrLf & "    AND XCONVEYOR_GROUP = :" & UBound(strBindField) - 1 & " --����Ը�ٰ��")
        End If
        If IsNull(XCONVEYOR_ORDER) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCONVEYOR_ORDER
            strSQL.Append(vbCrLf & "    AND XCONVEYOR_ORDER = :" & UBound(strBindField) - 1 & " --����ԏ�")
        End If
        If IsNull(XBERTH_GROUP) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_GROUP
            strSQL.Append(vbCrLf & "    AND XBERTH_GROUP = :" & UBound(strBindField) - 1 & " --�ް���ٰ��")
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
        strDataSetName = "XSTS_CONVEYOR"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XSTS_CONVEYOR(Owner, objDb, objDbLog)
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
    Public Function GET_XSTS_CONVEYOR_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "XSTS_CONVEYOR"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XSTS_CONVEYOR(Owner, objDb, objDbLog)
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
    Public Function GET_XSTS_CONVEYOR_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    XSTS_CONVEYOR")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XSTNO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSTNO
            strSQL.Append(vbCrLf & "    AND XSTNO = :" & UBound(strBindField) - 1 & " --STNo.")
        End If
        If IsNull(FEQ_LOCATION) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_LOCATION
            strSQL.Append(vbCrLf & "    AND FEQ_LOCATION = :" & UBound(strBindField) - 1 & " --�ݔ�۹����")
        End If
        If IsNull(XCONVEYOR_YOUTO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCONVEYOR_YOUTO
            strSQL.Append(vbCrLf & "    AND XCONVEYOR_YOUTO = :" & UBound(strBindField) - 1 & " --����ԗp�r")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --�X�V����")
        End If
        If IsNull(XCONVEYOR_GROUP) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCONVEYOR_GROUP
            strSQL.Append(vbCrLf & "    AND XCONVEYOR_GROUP = :" & UBound(strBindField) - 1 & " --����Ը�ٰ��")
        End If
        If IsNull(XCONVEYOR_ORDER) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCONVEYOR_ORDER
            strSQL.Append(vbCrLf & "    AND XCONVEYOR_ORDER = :" & UBound(strBindField) - 1 & " --����ԏ�")
        End If
        If IsNull(XBERTH_GROUP) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_GROUP
            strSQL.Append(vbCrLf & "    AND XBERTH_GROUP = :" & UBound(strBindField) - 1 & " --�ް���ٰ��")
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
        strDataSetName = "XSTS_CONVEYOR"
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
    Public Sub UPDATE_XSTS_CONVEYOR()
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
        ElseIf IsNull(mXSTNO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[STNo.]"
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
        strSQL.Append(vbCrLf & "    XSTS_CONVEYOR")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
        If IsNull(mXSTNO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSTNO = NULL --STNo.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSTNO = NULL --STNo.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSTNO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSTNO = :" & Ubound(strBindField) - 1 & " --STNo.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSTNO = :" & Ubound(strBindField) - 1 & " --STNo.")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_LOCATION) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_LOCATION = NULL --�ݔ�۹����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_LOCATION = NULL --�ݔ�۹����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_LOCATION
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_LOCATION = :" & Ubound(strBindField) - 1 & " --�ݔ�۹����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_LOCATION = :" & Ubound(strBindField) - 1 & " --�ݔ�۹����")
        End If
        intCount = intCount + 1
        If IsNull(mXCONVEYOR_YOUTO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCONVEYOR_YOUTO = NULL --����ԗp�r")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCONVEYOR_YOUTO = NULL --����ԗp�r")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCONVEYOR_YOUTO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCONVEYOR_YOUTO = :" & Ubound(strBindField) - 1 & " --����ԗp�r")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCONVEYOR_YOUTO = :" & Ubound(strBindField) - 1 & " --����ԗp�r")
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
        If IsNull(mXCONVEYOR_GROUP) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCONVEYOR_GROUP = NULL --����Ը�ٰ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCONVEYOR_GROUP = NULL --����Ը�ٰ��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCONVEYOR_GROUP
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCONVEYOR_GROUP = :" & Ubound(strBindField) - 1 & " --����Ը�ٰ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCONVEYOR_GROUP = :" & Ubound(strBindField) - 1 & " --����Ը�ٰ��")
        End If
        intCount = intCount + 1
        If IsNull(mXCONVEYOR_ORDER) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCONVEYOR_ORDER = NULL --����ԏ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCONVEYOR_ORDER = NULL --����ԏ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCONVEYOR_ORDER
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCONVEYOR_ORDER = :" & Ubound(strBindField) - 1 & " --����ԏ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCONVEYOR_ORDER = :" & Ubound(strBindField) - 1 & " --����ԏ�")
        End If
        intCount = intCount + 1
        If IsNull(mXBERTH_GROUP) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XBERTH_GROUP = NULL --�ް���ٰ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XBERTH_GROUP = NULL --�ް���ٰ��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_GROUP
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XBERTH_GROUP = :" & Ubound(strBindField) - 1 & " --�ް���ٰ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XBERTH_GROUP = :" & Ubound(strBindField) - 1 & " --�ް���ٰ��")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(XSTNO) = True Then
            strSQL.Append(vbCrLf & "    AND XSTNO IS NULL --STNo.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSTNO
            strSQL.Append(vbCrLf & "    AND XSTNO = :" & UBound(strBindField) - 1 & " --STNo.")
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
    Public Sub ADD_XSTS_CONVEYOR()
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
        ElseIf IsNull(mXSTNO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[STNo.]"
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
        strSQL.Append(vbCrLf & "    XSTS_CONVEYOR")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
        If IsNull(mXSTNO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --STNo.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --STNo.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSTNO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --STNo.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --STNo.")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_LOCATION) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ݔ�۹����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ݔ�۹����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_LOCATION
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ݔ�۹����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ݔ�۹����")
        End If
        intCount = intCount + 1
        If IsNull(mXCONVEYOR_YOUTO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����ԗp�r")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����ԗp�r")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCONVEYOR_YOUTO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����ԗp�r")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����ԗp�r")
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
        If IsNull(mXCONVEYOR_GROUP) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����Ը�ٰ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����Ը�ٰ��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCONVEYOR_GROUP
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����Ը�ٰ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����Ը�ٰ��")
        End If
        intCount = intCount + 1
        If IsNull(mXCONVEYOR_ORDER) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����ԏ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����ԏ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCONVEYOR_ORDER
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����ԏ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����ԏ�")
        End If
        intCount = intCount + 1
        If IsNull(mXBERTH_GROUP) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ް���ٰ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ް���ٰ��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_GROUP
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ް���ٰ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ް���ٰ��")
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
    Public Sub DELETE_XSTS_CONVEYOR()
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
        ElseIf IsNull(mXSTNO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[STNo.]"
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
        strSQL.Append(vbCrLf & "    XSTS_CONVEYOR")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(XSTNO) = True Then
            strSQL.Append(vbCrLf & "    AND XSTNO IS NULL --STNo.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSTNO
            strSQL.Append(vbCrLf & "    AND XSTNO = :" & UBound(strBindField) - 1 & " --STNo.")
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
    Public Sub DELETE_XSTS_CONVEYOR_ANY()
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
        strSQL.Append(vbCrLf & "    XSTS_CONVEYOR")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(XSTNO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSTNO
            strSQL.Append(vbCrLf & "    AND XSTNO = :" & UBound(strBindField) - 1 & " --STNo.")
        End If
        If IsNotNull(FEQ_LOCATION) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_LOCATION
            strSQL.Append(vbCrLf & "    AND FEQ_LOCATION = :" & UBound(strBindField) - 1 & " --�ݔ�۹����")
        End If
        If IsNotNull(XCONVEYOR_YOUTO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCONVEYOR_YOUTO
            strSQL.Append(vbCrLf & "    AND XCONVEYOR_YOUTO = :" & UBound(strBindField) - 1 & " --����ԗp�r")
        End If
        If IsNotNull(FUPDATE_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --�X�V����")
        End If
        If IsNotNull(XCONVEYOR_GROUP) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCONVEYOR_GROUP
            strSQL.Append(vbCrLf & "    AND XCONVEYOR_GROUP = :" & UBound(strBindField) - 1 & " --����Ը�ٰ��")
        End If
        If IsNotNull(XCONVEYOR_ORDER) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCONVEYOR_ORDER
            strSQL.Append(vbCrLf & "    AND XCONVEYOR_ORDER = :" & UBound(strBindField) - 1 & " --����ԏ�")
        End If
        If IsNotNull(XBERTH_GROUP) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_GROUP
            strSQL.Append(vbCrLf & "    AND XBERTH_GROUP = :" & UBound(strBindField) - 1 & " --�ް���ٰ��")
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
        If IsNothing(objType.GetProperty("XSTNO")) = False Then mXSTNO = objObject.XSTNO 'STNo.
        If IsNothing(objType.GetProperty("FEQ_LOCATION")) = False Then mFEQ_LOCATION = objObject.FEQ_LOCATION '�ݔ�۹����
        If IsNothing(objType.GetProperty("XCONVEYOR_YOUTO")) = False Then mXCONVEYOR_YOUTO = objObject.XCONVEYOR_YOUTO '����ԗp�r
        If IsNothing(objType.GetProperty("FUPDATE_DT")) = False Then mFUPDATE_DT = objObject.FUPDATE_DT '�X�V����
        If IsNothing(objType.GetProperty("XCONVEYOR_GROUP")) = False Then mXCONVEYOR_GROUP = objObject.XCONVEYOR_GROUP '����Ը�ٰ��
        If IsNothing(objType.GetProperty("XCONVEYOR_ORDER")) = False Then mXCONVEYOR_ORDER = objObject.XCONVEYOR_ORDER '����ԏ�
        If IsNothing(objType.GetProperty("XBERTH_GROUP")) = False Then mXBERTH_GROUP = objObject.XBERTH_GROUP '�ް���ٰ��

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
        mXSTNO = Nothing
        mFEQ_LOCATION = Nothing
        mXCONVEYOR_YOUTO = Nothing
        mFUPDATE_DT = Nothing
        mXCONVEYOR_GROUP = Nothing
        mXCONVEYOR_ORDER = Nothing
        mXBERTH_GROUP = Nothing


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
        mXSTNO = TO_INTEGER_NULLABLE(objRow("XSTNO"))
        mFEQ_LOCATION = TO_INTEGER_NULLABLE(objRow("FEQ_LOCATION"))
        mXCONVEYOR_YOUTO = TO_INTEGER_NULLABLE(objRow("XCONVEYOR_YOUTO"))
        mFUPDATE_DT = TO_DATE_NULLABLE(objRow("FUPDATE_DT"))
        mXCONVEYOR_GROUP = TO_INTEGER_NULLABLE(objRow("XCONVEYOR_GROUP"))
        mXCONVEYOR_ORDER = TO_INTEGER_NULLABLE(objRow("XCONVEYOR_ORDER"))
        mXBERTH_GROUP = TO_INTEGER_NULLABLE(objRow("XBERTH_GROUP"))


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
        strMsg &= "[ð��ٖ�:�o�׺���ԏ�]"
        If IsNotNull(XSTNO) Then
            strMsg &= "[STNo.:" & XSTNO & "]"
        End If
        If IsNotNull(FEQ_LOCATION) Then
            strMsg &= "[�ݔ�۹����:" & FEQ_LOCATION & "]"
        End If
        If IsNotNull(XCONVEYOR_YOUTO) Then
            strMsg &= "[����ԗp�r:" & XCONVEYOR_YOUTO & "]"
        End If
        If IsNotNull(FUPDATE_DT) Then
            strMsg &= "[�X�V����:" & FUPDATE_DT & "]"
        End If
        If IsNotNull(XCONVEYOR_GROUP) Then
            strMsg &= "[����Ը�ٰ��:" & XCONVEYOR_GROUP & "]"
        End If
        If IsNotNull(XCONVEYOR_ORDER) Then
            strMsg &= "[����ԏ�:" & XCONVEYOR_ORDER & "]"
        End If
        If IsNotNull(XBERTH_GROUP) Then
            strMsg &= "[�ް���ٰ��:" & XBERTH_GROUP & "]"
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
