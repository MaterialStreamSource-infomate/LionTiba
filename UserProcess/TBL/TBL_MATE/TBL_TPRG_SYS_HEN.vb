'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' �y���́zMaterialStreamð��ٸ׽
' �y�@�\�z���ѕϐ�ð��ٸ׽
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
''' ���ѕϐ�ð��ٸ׽
''' </summary>
Public Class TBL_TPRG_SYS_HEN
    Inherits clsTemplateTable

    '**********************************************************************************************
    '����������������
#Region "  �׽�ϐ���`                  "
    '�����è
    Private mobjAryMe As TBL_TPRG_SYS_HEN()                                      '���ѕϐ�
    Private mstrUSER_SQL As String                                               'հ�ްSQL
    Private mORDER_BY As String                                                  'OrderBy��
    Private mWHERE As String                                                     'Where��
    Private mFHENSU_ID As String                                                 '�ϐ�ID
    Private mFHENSU_NAME As String                                               '�ϐ�����
    Private mFHENSU_FLAG As Nullable(Of Integer)                                 '��É\�׸�
    Private mFHENSU_KIND As Nullable(Of Integer)                                 '�ް����
    Private mFHENSU_INT As Nullable(Of Integer)                                  '�����ް�
    Private mFHENSU_REAL As Nullable(Of Decimal)                                 '�����ް�
    Private mFHENSU_CHAR As String                                               '�����ް�
    Private mFHENSU_DATE As Nullable(Of Date)                                    '���t�ް�
#End Region
#Region "  �����è��`                  "
    ''' <summary>
    ''' ���ѕϐ� (���׽�^�z��)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_TPRG_SYS_HEN()
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
    ''' �ϐ�ID
    ''' </summary>
    Public Property FHENSU_ID() As String
        Get
            Return mFHENSU_ID
        End Get
        Set(ByVal Value As String)
            mFHENSU_ID = Value
        End Set
    End Property
    ''' <summary>
    ''' �ϐ�����
    ''' </summary>
    Public Property FHENSU_NAME() As String
        Get
            Return mFHENSU_NAME
        End Get
        Set(ByVal Value As String)
            mFHENSU_NAME = Value
        End Set
    End Property
    ''' <summary>
    ''' ��É\�׸�
    ''' </summary>
    Public Property FHENSU_FLAG() As Nullable(Of Integer)
        Get
            Return mFHENSU_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFHENSU_FLAG = Value
        End Set
    End Property
    ''' <summary>
    ''' �ް����
    ''' </summary>
    Public Property FHENSU_KIND() As Nullable(Of Integer)
        Get
            Return mFHENSU_KIND
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFHENSU_KIND = Value
        End Set
    End Property
    ''' <summary>
    ''' �����ް�
    ''' </summary>
    Public Property FHENSU_INT() As Nullable(Of Integer)
        Get
            Return mFHENSU_INT
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFHENSU_INT = Value
        End Set
    End Property
    ''' <summary>
    ''' �����ް�
    ''' </summary>
    Public Property FHENSU_REAL() As Nullable(Of Decimal)
        Get
            Return mFHENSU_REAL
        End Get
        Set(ByVal Value As Nullable(Of Decimal))
            mFHENSU_REAL = Value
        End Set
    End Property
    ''' <summary>
    ''' �����ް�
    ''' </summary>
    Public Property FHENSU_CHAR() As String
        Get
            Return mFHENSU_CHAR
        End Get
        Set(ByVal Value As String)
            mFHENSU_CHAR = Value
        End Set
    End Property
    ''' <summary>
    ''' ���t�ް�
    ''' </summary>
    Public Property FHENSU_DATE() As Nullable(Of Date)
        Get
            Return mFHENSU_DATE
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mFHENSU_DATE = Value
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
    Public Function GET_TPRG_SYS_HEN(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    TPRG_SYS_HEN")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FHENSU_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_ID
            strSQL.Append(vbCrLf & "    AND FHENSU_ID = :" & UBound(strBindField) - 1 & " --�ϐ�ID")
        End If
        If IsNull(FHENSU_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_NAME
            strSQL.Append(vbCrLf & "    AND FHENSU_NAME = :" & UBound(strBindField) - 1 & " --�ϐ�����")
        End If
        If IsNull(FHENSU_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_FLAG
            strSQL.Append(vbCrLf & "    AND FHENSU_FLAG = :" & UBound(strBindField) - 1 & " --��É\�׸�")
        End If
        If IsNull(FHENSU_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_KIND
            strSQL.Append(vbCrLf & "    AND FHENSU_KIND = :" & UBound(strBindField) - 1 & " --�ް����")
        End If
        If IsNull(FHENSU_INT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_INT
            strSQL.Append(vbCrLf & "    AND FHENSU_INT = :" & UBound(strBindField) - 1 & " --�����ް�")
        End If
        If IsNull(FHENSU_REAL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_REAL
            strSQL.Append(vbCrLf & "    AND FHENSU_REAL = :" & UBound(strBindField) - 1 & " --�����ް�")
        End If
        If IsNull(FHENSU_CHAR) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_CHAR
            strSQL.Append(vbCrLf & "    AND FHENSU_CHAR = :" & UBound(strBindField) - 1 & " --�����ް�")
        End If
        If IsNull(FHENSU_DATE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_DATE
            strSQL.Append(vbCrLf & "    AND FHENSU_DATE = :" & UBound(strBindField) - 1 & " --���t�ް�")
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
        strDataSetName = "TPRG_SYS_HEN"
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
    Public Function GET_TPRG_SYS_HEN_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    TPRG_SYS_HEN")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FHENSU_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_ID
            strSQL.Append(vbCrLf & "    AND FHENSU_ID = :" & UBound(strBindField) - 1 & " --�ϐ�ID")
        End If
        If IsNull(FHENSU_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_NAME
            strSQL.Append(vbCrLf & "    AND FHENSU_NAME = :" & UBound(strBindField) - 1 & " --�ϐ�����")
        End If
        If IsNull(FHENSU_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_FLAG
            strSQL.Append(vbCrLf & "    AND FHENSU_FLAG = :" & UBound(strBindField) - 1 & " --��É\�׸�")
        End If
        If IsNull(FHENSU_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_KIND
            strSQL.Append(vbCrLf & "    AND FHENSU_KIND = :" & UBound(strBindField) - 1 & " --�ް����")
        End If
        If IsNull(FHENSU_INT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_INT
            strSQL.Append(vbCrLf & "    AND FHENSU_INT = :" & UBound(strBindField) - 1 & " --�����ް�")
        End If
        If IsNull(FHENSU_REAL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_REAL
            strSQL.Append(vbCrLf & "    AND FHENSU_REAL = :" & UBound(strBindField) - 1 & " --�����ް�")
        End If
        If IsNull(FHENSU_CHAR) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_CHAR
            strSQL.Append(vbCrLf & "    AND FHENSU_CHAR = :" & UBound(strBindField) - 1 & " --�����ް�")
        End If
        If IsNull(FHENSU_DATE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_DATE
            strSQL.Append(vbCrLf & "    AND FHENSU_DATE = :" & UBound(strBindField) - 1 & " --���t�ް�")
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
        strDataSetName = "TPRG_SYS_HEN"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TPRG_SYS_HEN(Owner, objDb, objDbLog)
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
    Public Function GET_TPRG_SYS_HEN_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "TPRG_SYS_HEN"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TPRG_SYS_HEN(Owner, objDb, objDbLog)
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
    Public Function GET_TPRG_SYS_HEN_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    TPRG_SYS_HEN")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FHENSU_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_ID
            strSQL.Append(vbCrLf & "    AND FHENSU_ID = :" & UBound(strBindField) - 1 & " --�ϐ�ID")
        End If
        If IsNull(FHENSU_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_NAME
            strSQL.Append(vbCrLf & "    AND FHENSU_NAME = :" & UBound(strBindField) - 1 & " --�ϐ�����")
        End If
        If IsNull(FHENSU_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_FLAG
            strSQL.Append(vbCrLf & "    AND FHENSU_FLAG = :" & UBound(strBindField) - 1 & " --��É\�׸�")
        End If
        If IsNull(FHENSU_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_KIND
            strSQL.Append(vbCrLf & "    AND FHENSU_KIND = :" & UBound(strBindField) - 1 & " --�ް����")
        End If
        If IsNull(FHENSU_INT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_INT
            strSQL.Append(vbCrLf & "    AND FHENSU_INT = :" & UBound(strBindField) - 1 & " --�����ް�")
        End If
        If IsNull(FHENSU_REAL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_REAL
            strSQL.Append(vbCrLf & "    AND FHENSU_REAL = :" & UBound(strBindField) - 1 & " --�����ް�")
        End If
        If IsNull(FHENSU_CHAR) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_CHAR
            strSQL.Append(vbCrLf & "    AND FHENSU_CHAR = :" & UBound(strBindField) - 1 & " --�����ް�")
        End If
        If IsNull(FHENSU_DATE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_DATE
            strSQL.Append(vbCrLf & "    AND FHENSU_DATE = :" & UBound(strBindField) - 1 & " --���t�ް�")
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
        strDataSetName = "TPRG_SYS_HEN"
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
    Public Sub UPDATE_TPRG_SYS_HEN()
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
        ElseIf IsNull(mFHENSU_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�ϐ�ID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFHENSU_FLAG) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[��É\�׸�]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFHENSU_KIND) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�ް����]"
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
        strSQL.Append(vbCrLf & "    TPRG_SYS_HEN")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
        If IsNull(mFHENSU_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHENSU_ID = NULL --�ϐ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHENSU_ID = NULL --�ϐ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHENSU_ID = :" & Ubound(strBindField) - 1 & " --�ϐ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHENSU_ID = :" & Ubound(strBindField) - 1 & " --�ϐ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mFHENSU_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHENSU_NAME = NULL --�ϐ�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHENSU_NAME = NULL --�ϐ�����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHENSU_NAME = :" & Ubound(strBindField) - 1 & " --�ϐ�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHENSU_NAME = :" & Ubound(strBindField) - 1 & " --�ϐ�����")
        End If
        intCount = intCount + 1
        If IsNull(mFHENSU_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHENSU_FLAG = NULL --��É\�׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHENSU_FLAG = NULL --��É\�׸�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHENSU_FLAG = :" & Ubound(strBindField) - 1 & " --��É\�׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHENSU_FLAG = :" & Ubound(strBindField) - 1 & " --��É\�׸�")
        End If
        intCount = intCount + 1
        If IsNull(mFHENSU_KIND) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHENSU_KIND = NULL --�ް����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHENSU_KIND = NULL --�ް����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_KIND
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHENSU_KIND = :" & Ubound(strBindField) - 1 & " --�ް����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHENSU_KIND = :" & Ubound(strBindField) - 1 & " --�ް����")
        End If
        intCount = intCount + 1
        If IsNull(mFHENSU_INT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHENSU_INT = NULL --�����ް�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHENSU_INT = NULL --�����ް�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_INT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHENSU_INT = :" & Ubound(strBindField) - 1 & " --�����ް�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHENSU_INT = :" & Ubound(strBindField) - 1 & " --�����ް�")
        End If
        intCount = intCount + 1
        If IsNull(mFHENSU_REAL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHENSU_REAL = NULL --�����ް�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHENSU_REAL = NULL --�����ް�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_REAL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHENSU_REAL = :" & Ubound(strBindField) - 1 & " --�����ް�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHENSU_REAL = :" & Ubound(strBindField) - 1 & " --�����ް�")
        End If
        intCount = intCount + 1
        If IsNull(mFHENSU_CHAR) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHENSU_CHAR = NULL --�����ް�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHENSU_CHAR = NULL --�����ް�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_CHAR
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHENSU_CHAR = :" & Ubound(strBindField) - 1 & " --�����ް�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHENSU_CHAR = :" & Ubound(strBindField) - 1 & " --�����ް�")
        End If
        intCount = intCount + 1
        If IsNull(mFHENSU_DATE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHENSU_DATE = NULL --���t�ް�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHENSU_DATE = NULL --���t�ް�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_DATE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHENSU_DATE = :" & Ubound(strBindField) - 1 & " --���t�ް�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHENSU_DATE = :" & Ubound(strBindField) - 1 & " --���t�ް�")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FHENSU_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FHENSU_ID IS NULL --�ϐ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_ID
            strSQL.Append(vbCrLf & "    AND FHENSU_ID = :" & UBound(strBindField) - 1 & " --�ϐ�ID")
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
    Public Sub ADD_TPRG_SYS_HEN()
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
        ElseIf IsNull(mFHENSU_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�ϐ�ID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFHENSU_FLAG) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[��É\�׸�]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFHENSU_KIND) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�ް����]"
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
        strSQL.Append(vbCrLf & "    TPRG_SYS_HEN")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
        If IsNull(mFHENSU_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ϐ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ϐ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ϐ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ϐ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mFHENSU_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ϐ�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ϐ�����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ϐ�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ϐ�����")
        End If
        intCount = intCount + 1
        If IsNull(mFHENSU_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --��É\�׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --��É\�׸�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --��É\�׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --��É\�׸�")
        End If
        intCount = intCount + 1
        If IsNull(mFHENSU_KIND) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ް����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ް����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_KIND
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ް����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ް����")
        End If
        intCount = intCount + 1
        If IsNull(mFHENSU_INT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�����ް�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�����ް�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_INT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�����ް�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�����ް�")
        End If
        intCount = intCount + 1
        If IsNull(mFHENSU_REAL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�����ް�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�����ް�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_REAL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�����ް�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�����ް�")
        End If
        intCount = intCount + 1
        If IsNull(mFHENSU_CHAR) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�����ް�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�����ް�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_CHAR
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�����ް�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�����ް�")
        End If
        intCount = intCount + 1
        If IsNull(mFHENSU_DATE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���t�ް�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���t�ް�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_DATE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���t�ް�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���t�ް�")
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
    Public Sub DELETE_TPRG_SYS_HEN()
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
        ElseIf IsNull(mFHENSU_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�ϐ�ID]"
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
        strSQL.Append(vbCrLf & "    TPRG_SYS_HEN")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FHENSU_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FHENSU_ID IS NULL --�ϐ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_ID
            strSQL.Append(vbCrLf & "    AND FHENSU_ID = :" & UBound(strBindField) - 1 & " --�ϐ�ID")
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
    Public Sub DELETE_TPRG_SYS_HEN_ANY()
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
        strSQL.Append(vbCrLf & "    TPRG_SYS_HEN")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(FHENSU_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_ID
            strSQL.Append(vbCrLf & "    AND FHENSU_ID = :" & UBound(strBindField) - 1 & " --�ϐ�ID")
        End If
        If IsNotNull(FHENSU_NAME) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_NAME
            strSQL.Append(vbCrLf & "    AND FHENSU_NAME = :" & UBound(strBindField) - 1 & " --�ϐ�����")
        End If
        If IsNotNull(FHENSU_FLAG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_FLAG
            strSQL.Append(vbCrLf & "    AND FHENSU_FLAG = :" & UBound(strBindField) - 1 & " --��É\�׸�")
        End If
        If IsNotNull(FHENSU_KIND) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_KIND
            strSQL.Append(vbCrLf & "    AND FHENSU_KIND = :" & UBound(strBindField) - 1 & " --�ް����")
        End If
        If IsNotNull(FHENSU_INT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_INT
            strSQL.Append(vbCrLf & "    AND FHENSU_INT = :" & UBound(strBindField) - 1 & " --�����ް�")
        End If
        If IsNotNull(FHENSU_REAL) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_REAL
            strSQL.Append(vbCrLf & "    AND FHENSU_REAL = :" & UBound(strBindField) - 1 & " --�����ް�")
        End If
        If IsNotNull(FHENSU_CHAR) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_CHAR
            strSQL.Append(vbCrLf & "    AND FHENSU_CHAR = :" & UBound(strBindField) - 1 & " --�����ް�")
        End If
        If IsNotNull(FHENSU_DATE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_DATE
            strSQL.Append(vbCrLf & "    AND FHENSU_DATE = :" & UBound(strBindField) - 1 & " --���t�ް�")
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
        If IsNothing(objType.GetProperty("FHENSU_ID")) = False Then mFHENSU_ID = objObject.FHENSU_ID '�ϐ�ID
        If IsNothing(objType.GetProperty("FHENSU_NAME")) = False Then mFHENSU_NAME = objObject.FHENSU_NAME '�ϐ�����
        If IsNothing(objType.GetProperty("FHENSU_FLAG")) = False Then mFHENSU_FLAG = objObject.FHENSU_FLAG '��É\�׸�
        If IsNothing(objType.GetProperty("FHENSU_KIND")) = False Then mFHENSU_KIND = objObject.FHENSU_KIND '�ް����
        If IsNothing(objType.GetProperty("FHENSU_INT")) = False Then mFHENSU_INT = objObject.FHENSU_INT '�����ް�
        If IsNothing(objType.GetProperty("FHENSU_REAL")) = False Then mFHENSU_REAL = objObject.FHENSU_REAL '�����ް�
        If IsNothing(objType.GetProperty("FHENSU_CHAR")) = False Then mFHENSU_CHAR = objObject.FHENSU_CHAR '�����ް�
        If IsNothing(objType.GetProperty("FHENSU_DATE")) = False Then mFHENSU_DATE = objObject.FHENSU_DATE '���t�ް�

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
        mFHENSU_ID = Nothing
        mFHENSU_NAME = Nothing
        mFHENSU_FLAG = Nothing
        mFHENSU_KIND = Nothing
        mFHENSU_INT = Nothing
        mFHENSU_REAL = Nothing
        mFHENSU_CHAR = Nothing
        mFHENSU_DATE = Nothing


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
        mFHENSU_ID = TO_STRING_NULLABLE(objRow("FHENSU_ID"))
        mFHENSU_NAME = TO_STRING_NULLABLE(objRow("FHENSU_NAME"))
        mFHENSU_FLAG = TO_INTEGER_NULLABLE(objRow("FHENSU_FLAG"))
        mFHENSU_KIND = TO_INTEGER_NULLABLE(objRow("FHENSU_KIND"))
        mFHENSU_INT = TO_INTEGER_NULLABLE(objRow("FHENSU_INT"))
        mFHENSU_REAL = TO_DECIMAL_NULLABLE(objRow("FHENSU_REAL"))
        mFHENSU_CHAR = TO_STRING_NULLABLE(objRow("FHENSU_CHAR"))
        mFHENSU_DATE = TO_DATE_NULLABLE(objRow("FHENSU_DATE"))


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
        strMsg &= "[ð��ٖ�:���ѕϐ�]"
        If IsNotNull(FHENSU_ID) Then
            strMsg &= "[�ϐ�ID:" & FHENSU_ID & "]"
        End If
        If IsNotNull(FHENSU_NAME) Then
            strMsg &= "[�ϐ�����:" & FHENSU_NAME & "]"
        End If
        If IsNotNull(FHENSU_FLAG) Then
            strMsg &= "[��É\�׸�:" & FHENSU_FLAG & "]"
        End If
        If IsNotNull(FHENSU_KIND) Then
            strMsg &= "[�ް����:" & FHENSU_KIND & "]"
        End If
        If IsNotNull(FHENSU_INT) Then
            strMsg &= "[�����ް�:" & FHENSU_INT & "]"
        End If
        If IsNotNull(FHENSU_REAL) Then
            strMsg &= "[�����ް�:" & FHENSU_REAL & "]"
        End If
        If IsNotNull(FHENSU_CHAR) Then
            strMsg &= "[�����ް�:" & FHENSU_CHAR & "]"
        End If
        If IsNotNull(FHENSU_DATE) Then
            strMsg &= "[���t�ް�:" & FHENSU_DATE & "]"
        End If


    End Sub
#End Region
    '����������������
    '**********************************************************************************************

    '**********************************************************************************************
    '���������ы���
#Region "  �׽�ϐ���`"
    '�����è(ð��ٗ�)
    Private mobjCHANGE_DATA As Object               '�ύX�ް�
    Private mobjGET_DATA As Object                  '�擾�ް�
#End Region
#Region "  �����è��`"

#Region "  �ύX�ް�"
    Public Property OBJCHANGE_DATA() As Object
        Get
            Return mobjCHANGE_DATA
        End Get
        Set(ByVal Value As Object)
            mobjCHANGE_DATA = Value
        End Set
    End Property
#End Region
#Region "  �擾�ް�"
    Public Property OBJGET_DATA() As Object
        Get
            Return mobjGET_DATA
        End Get
        Set(ByVal Value As Object)
            mobjGET_DATA = Value
        End Set
    End Property
#End Region

#End Region
#Region "  ���ѕϐ��擾 [��޼ު�Ė߂�]      (Public  GET_TPRG_SYS_HEN_OBJ)"
    Public Function GET_TPRG_SYS_HEN_OBJ() As RetCode
        Try
            Dim strSQL As String            'SQL��
            Dim strMsg As String            'ү����
            Dim objDataSet As New DataSet   '�ް����
            Dim strDataSetName As String    '�ް���Ė�
            Dim objRow As DataRow           '1ں��ޕ����ް�

            '***********************
            '�����è����
            '***********************
            If mFHENSU_ID = DEFAULT_STRING Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�ϐ�ID]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '���oSQL�쐬
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    *"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TPRG_SYS_HEN"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FHENSU_ID = '" & TO_STRING(mFHENSU_ID) & "'"
            strSQL &= vbCrLf


            '***********************
            '���o
            '***********************
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TPRG_SYS_HEN"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                objRow = objDataSet.Tables(strDataSetName).Rows(0)
                Call SET_DATA(objRow)
                Select Case TO_INTEGER(mFHENSU_KIND)                            '�ϐ����
                    Case FHENSU_KIND_SINT
                        mobjGET_DATA = mFHENSU_INT
                    Case FHENSU_KIND_SREAL
                        mobjGET_DATA = mFHENSU_REAL
                    Case FHENSU_KIND_SCHAR
                        mobjGET_DATA = mFHENSU_CHAR
                    Case FHENSU_KIND_SDATE
                        mobjGET_DATA = mFHENSU_DATE
                End Select
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
#Region "  ���ѕϐ��X�V [��޼ު�ēn��]      (Public  UPDATE_TPRG_SYS_HEN_OBJ)"
    Public Sub UPDATE_TPRG_SYS_HEN_OBJ()
        Try
            Dim strSQL As String        'SQL��
            Dim strMsg As String        'ү����
            Dim intRetSQL As Integer    'SQL���s�߂�l

            '***********************
            '�����è����
            '***********************
            If mFHENSU_ID = DEFAULT_STRING Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�ϐ�ID]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '�X�VSQL�쐬
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "UPDATE"
            strSQL &= vbCrLf & "    TPRG_SYS_HEN"
            strSQL &= vbCrLf & " SET"
            strSQL &= vbCrLf & "    FHENSU_ID = '" & TO_STRING(mFHENSU_ID) & "'"
            strSQL &= vbCrLf & "   ,FHENSU_NAME = '" & TO_STRING(mFHENSU_NAME) & "'"
            Select Case TO_INTEGER(mFHENSU_KIND)                                                              '�ϐ����
                Case FHENSU_KIND_SINT
                    strSQL &= vbCrLf & "   ,FHENSU_INT = " & TO_STRING(mobjCHANGE_DATA)
                Case FHENSU_KIND_SREAL
                    strSQL &= vbCrLf & "   ,FHENSU_REAL = " & TO_STRING(mobjCHANGE_DATA)
                Case FHENSU_KIND_SCHAR
                    strSQL &= vbCrLf & "   ,FHENSU_CHAR = '" & TO_STRING(mobjCHANGE_DATA) & "'"
                Case FHENSU_KIND_SDATE
                    strSQL &= vbCrLf & "   ,FHENSU_DATE = TO_DATE('" & TO_STRING(mobjCHANGE_DATA) & "','YYYY/MM/DD HH24:MI:SS')"
            End Select
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FHENSU_ID = '" & TO_STRING(mFHENSU_ID) & "'"
            strSQL &= vbCrLf


            '***********************
            '�X�V
            '***********************
            intRetSQL = ObjDb.Execute(strSQL)
            If intRetSQL = -1 Then
                '(SQL�װ)
                strSQL = Replace(strSQL, vbCrLf, "")
                strMsg = ERRMSG_ERR_UPDATE & ObjDb.ErrMsg & "�y" & strSQL & "�z"
                Throw New UserException(strMsg)
            End If
            If intRetSQL < 1 Then
                '(�Ώۍs����)
                strSQL = Replace(strSQL, vbCrLf, "")
                strMsg = ERRMSG_ERR_UPDATE & "(�Ώۍs����)[ð���:TPRG_SYS_HEN]"
                Throw New UserException(strMsg)
            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region


#Region "  SS000000_001:�ׯ�ݸ޷�ݾٌv�搔��������ݽ"
    Public Property SS000000_001() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = "SS000000_001"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = "SS000000_001"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property
#End Region
#Region "  SS000000_002:�ڰݗD�揇"
    ''' <summary>
    ''' �ڰݗD�揇
    ''' </summary>
    Public Property SS000000_002() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = "SS000000_002"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = "SS000000_002"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property
#End Region
#Region "  SS000000_007:Ӱ�ސ؂�ւ���ѱ��(sec)"
    Public Property SS000000_007() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = "SS000000_007"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = "SS000000_007"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property
#End Region
#Region "  SS000000_008:���ޯ��۸ޓo�^�׸�"
    Public Property SS000000_008() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = "SS000000_008"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = "SS000000_008"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property
#End Region
#Region "  SS000000_009:�ׯ�ݸ޷�ݾَg�p�׸�"
    Public Property SS000000_009() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = "SS000000_009"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = "SS000000_009"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property
#End Region
#Region "  SS000000_010:��ʗp���o�Ɏ��т̏o�ֽ͐ؑð��"
    Public Property SS000000_010() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = "SS000000_010"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = "SS000000_010"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property
#End Region
#Region "  SS000000_011:��ײݐݒ莞�đ��M�׸�"
    Public Property SS000000_011() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = "SS000000_011"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = "SS000000_011"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property
#End Region
#Region "  SS000000_012:�߽ܰ�ޕs��v������"
    Public Property SS000000_012() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = "SS000000_012"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = "SS000000_012"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property
#End Region
#Region "  SS000000_013:�߽ܰ�ޗL���������ߓ���"
    Public Property SS000000_013() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = "SS000000_013"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = "SS000000_013"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property
#End Region
#Region "  SS000000_014:�߽ܰ�ނ�հ��ID�̈�v�����׸�"
    Public Property SS000000_014() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = "SS000000_014"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = "SS000000_014"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property
#End Region
#Region "  SS000000_015:�߽ܰ�ޗL�������؂�\������"
    Public Property SS000000_015() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = "SS000000_015"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = "SS000000_015"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property
#End Region
#Region "  SS000000_016:�ʐM�ُ펞��ײݐؑ��׸�"
    Public Property SS000000_016() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = "SS000000_016"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = "SS000000_016"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property
#End Region
#Region "  SS000000_017:�ʐM�ُ펞ں��ލ폜�׸�"
    Public Property SS000000_017() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = "SS000000_017"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = "SS000000_017"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property
#End Region
#Region "  SS000000_018:��ײݔ�������ð��ٓo�^�׸�"
    Public Property SS000000_018() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = "SS000000_018"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = "SS000000_018"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property
#End Region
#Region "  SS000000_019:��ײݔ�������ð��ٓo�^�׸�"
    Public Property SS000000_019() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = "SS000000_019"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = "SS000000_019"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property
#End Region
#Region "  SS000000_020:�������ޕs������ײݐؑ��׸�"
    Public Property SS000000_020() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = "SS000000_020"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = "SS000000_020"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property
#End Region
#Region "  SS000000_021:�o�Ɏw������ٰ����ѱ��(�ذ�ތ��ۗ\�h)"
    ''' <summary>
    ''' �o�Ɏw������ٰ����ѱ��(�ذ�ތ��ۗ\�h)
    ''' </summary>
    Public Property SS000000_021() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = "SS000000_021"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = "SS000000_021"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property
#End Region
#Region "  SS000000_022:�o�Ɏw������(�ڰݖ�)�̸ڰݗD�揇"
    ''' <summary>
    ''' �o�Ɏw������(�ڰݖ�)�̸ڰݗD�揇
    ''' </summary>
    Public Property SS000000_022() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = "SS000000_022"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = "SS000000_022"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property
#End Region

#Region "  SS040101_001:DB�ޯ�������۸��ыN���߽"
    '''**********************************************************************************************
    ''' <summary>
    ''' DB�ޯ�������۸��ыN���߽
    ''' </summary>
    ''' <value>�ް��l</value>
    ''' <returns>�ް��l</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Property SS040101_001() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = "SS040101_001"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = "SS040101_001"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property
#End Region
#Region "  SS040102_001:DB�ޯ�������۸��ыN���߽2"
    '''**********************************************************************************************
    ''' <summary>
    ''' DB�ޯ�������۸��ыN���߽2
    ''' </summary>
    ''' <value>�ް��l</value>
    ''' <returns>�ް��l</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Property SS040102_001() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = "SS040102_001"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = "SS040102_001"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property
#End Region
#Region "  SS040102_002:DB�ޯ�������۸��ыN���߽3"
    '''**********************************************************************************************
    ''' <summary>
    ''' DB�ޯ�������۸��ыN���߽3
    ''' </summary>
    ''' <value>�ް��l</value>
    ''' <returns>�ް��l</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Property SS040102_002() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = "SS040102_002"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = "SS040102_002"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property
#End Region

    '���������ы���
    '**********************************************************************************************

    '**********************************************************************************************
    '���������ьŗL
#Region "  GJ307000_001:PLC����ݽ��ʍX�V�ذ�ߎ���(msec)"
    Public Property GJ307000_001() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = "GJ307000_001"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = "GJ307000_001"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property
#End Region
#Region "  SJ000000_001:�o��CV������̓����o�Ɏw����"
    ''' <summary>
    ''' �o��CV������̓����o�Ɏw����
    ''' </summary>
    Public Property SJ000000_001() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = "SJ000000_001"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = "SJ000000_001"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property
#End Region
#Region "  SJ000000_003:۰���ް��D�揇"
    ''' <summary>
    ''' ۰���ް��D�揇
    ''' </summary>
    Public Property SJ000000_003() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = "SJ000000_003"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mFHENSU_CHAR                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = "SJ000000_003"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property
#End Region
#Region "  SJ000000_004:�ŏI�g�p����ް�"
    ''' <summary>
    ''' �ŏI�g�p����ް�
    ''' </summary>
    Public Property SJ000000_004() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = "SJ000000_004"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mFHENSU_CHAR                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = "SJ000000_004"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property
#End Region
#Region "  SJ000000_005:۰�ލ��@�D�揇"
    ''' <summary>
    ''' ۰�ލ��@�D�揇
    ''' </summary>
    Public Property SJ000000_005() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = "SJ000000_005"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mFHENSU_CHAR                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = "SJ000000_005"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property
#End Region
#Region "  SJ000000_006:۰���ް��D�揇(1���@)"
    ''' <summary>
    ''' ۰���ް��D�揇(1���@)
    ''' </summary>
    Public Property SJ000000_006() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = "SJ000000_006"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mFHENSU_CHAR                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = "SJ000000_006"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property
#End Region
#Region "  SJ000000_007:۰���ް��D�揇(2���@)"
    ''' <summary>
    ''' ۰���ް��D�揇(2���@)
    ''' </summary>
    Public Property SJ000000_007() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = "SJ000000_007"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mFHENSU_CHAR                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = "SJ000000_007"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property
#End Region

#Region "  SJ000000_011:���ߎ���"
    ''' <summary>
    ''' ���ߎ���
    ''' </summary>
    Public Property SJ000000_011() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = "SJ000000_011"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = "SJ000000_011"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property
#End Region
#Region "  SJ000000_012:�ŏI���s���ߎ���"
    ''' <summary>
    ''' �ŏI���s���ߎ���
    ''' </summary>
    Public Property SJ000000_012() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = "SJ000000_012"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = "SJ000000_012"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property
#End Region
#Region "  SJ000000_013:���ƊJ�n����"
    ''' <summary>
    ''' ���ƊJ�n����
    ''' </summary>
    Public Property SJ000000_013() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = "SJ000000_013"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = "SJ000000_013"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property
#End Region
#Region "  SJ000000_014:�ŏI���s���ߎ���"
    ''' <summary>
    ''' �ŏI���s���ߎ���
    ''' </summary>
    Public Property SJ000000_014() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = "SJ000000_014"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = "SJ000000_014"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property
#End Region

#Region "  SJ000000_021:������۾��ċN���ޯ�̧���߽"
    ''' <summary>
    ''' ������۾��ċN���ޯ�̧���߽
    ''' </summary>
    Public Property SJ000000_021() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = "SJ000000_021"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = "SJ000000_021"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property
#End Region
#Region "  SJ000000_022:Exceļ�ٕۑ��߽"
    ''' <summary>
    ''' Exceļ�ٕۑ��߽
    ''' </summary>
    Public Property SJ000000_022() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = "SJ000000_022"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = "SJ000000_022"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property
#End Region
#Region "  SJ000000_023:Csv̧�ٕۑ��߽"
    ''' <summary>
    ''' Csv̧�ٕۑ��߽
    ''' </summary>
    Public Property SJ000000_023() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = "SJ000000_023"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = "SJ000000_023"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property
#End Region
#Region "  SJ000000_024:Exe�N����۸����߽"
    ''' <summary>
    ''' Exe�N����۸����߽
    ''' </summary>
    Public Property SJ000000_024() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = "SJ000000_024"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = "SJ000000_024"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property
#End Region

#Region "  SJ000000_031:���q���۰וԐM�d��01"
    ''' <summary>
    ''' ���q���۰וԐM�d��01
    ''' </summary>
    Public Property SJ000000_031() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = "SJ000000_031"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = "SJ000000_031"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property
#End Region
#Region "  SJ000000_032:���q���۰וԐM�d��02"
    ''' <summary>
    ''' ���q���۰וԐM�d��02
    ''' </summary>
    Public Property SJ000000_032() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = "SJ000000_032"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = "SJ000000_032"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property
#End Region

#Region "  SJ000000_041:�����ُ�����"
    ''' <summary>
    ''' �����ُ�����
    ''' </summary>
    Public Property SJ000000_041() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = "SJ000000_041"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = "SJ000000_041"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property
#End Region
#Region "  SJ000000_042:��M�ُ�����"
    ''' <summary>
    ''' ��M�ُ�����
    ''' </summary>
    Public Property SJ000000_042() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = "SJ000000_042"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = "SJ000000_042"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property
#End Region
#Region "  SJ000000_043:���ُ�����"
    ''' <summary>
    ''' ���ُ�����
    ''' </summary>
    Public Property SJ000000_043() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = "SJ000000_043"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = "SJ000000_043"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property
#End Region

    '������������************************************************************************************************************
    'JobMate:Dou 2014/08/04 ���ɐݒ���񏈗����s���ׂ̉���
#Region "  SJ390002_001:1�����ŏ�������ں��ތ���"
    ''' <summary>
    ''' 1�����ŏ�������ں��ތ���
    ''' </summary>
    Public Property SJ390002_001() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = "SJ390002_001"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = "SJ390002_001"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property
#End Region
    '������������************************************************************************************************************

    '������������************************************************************************************************************
    'JobMate:S.Ouchi 2016/08/04 ������۾���؊Ď����s���ׂ̉��� ������������
#Region "  SJ390003_001:������۾��Ď�(��؎g�p�ʔ���l)(KByte)"
    ''' <summary>
    ''' ������۾��Ď�(��؎g�p�ʔ���l)(KByte)
    ''' </summary>
    Public Property SJ390003_001() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = "SJ390003_001"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = "SJ390003_001"    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property
#End Region
    'JobMate:S.Ouchi 2016/08/04 ������۾���؊Ď����s���ׂ̉��� ������������
    '������������************************************************************************************************************

#Region "  GJ304070_001:��د�ނ̔w�i�F"
    ''' <summary>
    ''' ��د�ނ̔w�i�F
    ''' </summary>
    Public Property GJ304070_001() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = FHENSU_ID_JGJ304070_001    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = FHENSU_ID_JGJ304070_001    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property
#End Region
#Region "  GJ304070_002:��د�ނ̘g��"
    ''' <summary>
    ''' ��د�ނ̘g��
    ''' </summary>
    Public Property GJ304070_002() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = FHENSU_ID_JGJ304070_002    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = FHENSU_ID_JGJ304070_002    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property
#End Region
#Region "  GJ304070_011:���ق̔w�i�F"
    ''' <summary>
    ''' ���ق̔w�i�F
    ''' </summary>
    Public Property GJ304070_011() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = FHENSU_ID_JGJ304070_011    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = FHENSU_ID_JGJ304070_011    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property

#End Region
#Region "  GJ304070_012:���ق̕����F"
    ''' <summary>
    ''' ���ق̕����F
    ''' </summary>
    Public Property GJ304070_012() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = FHENSU_ID_JGJ304070_012    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = FHENSU_ID_JGJ304070_012    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property

#End Region
#Region "  GJ304070_101:���̐F"
    ''' <summary>
    ''' ���̐F
    ''' </summary>
    Public Property GJ304070_101() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = FHENSU_ID_JGJ304070_101    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = FHENSU_ID_JGJ304070_101    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property

#End Region
#Region "  GJ304070_102:���̐F"
    ''' <summary>
    ''' ���̐F
    ''' </summary>
    Public Property GJ304070_102() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = FHENSU_ID_JGJ304070_102    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = FHENSU_ID_JGJ304070_102    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property

#End Region
#Region "  GJ304070_103:���̐F"
    ''' <summary>
    ''' ���̐F
    ''' </summary>
    Public Property GJ304070_103() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = FHENSU_ID_JGJ304070_103    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = FHENSU_ID_JGJ304070_103    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property

#End Region
#Region "  GJ304070_104:���̐F"
    ''' <summary>
    ''' ���̐F
    ''' </summary>
    Public Property GJ304070_104() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = FHENSU_ID_JGJ304070_104    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = FHENSU_ID_JGJ304070_104    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property

#End Region
#Region "  GJ304070_105:���̐F"
    ''' <summary>
    ''' ���̐F
    ''' </summary>
    Public Property GJ304070_105() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = FHENSU_ID_JGJ304070_105    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = FHENSU_ID_JGJ304070_105    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property

#End Region
#Region "  GJ304070_106:���̐F"
    ''' <summary>
    ''' ���̐F
    ''' </summary>
    Public Property GJ304070_106() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = FHENSU_ID_JGJ304070_106    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = FHENSU_ID_JGJ304070_106    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property

#End Region
#Region "  GJ304070_107:�~�̐F"
    ''' <summary>
    ''' �~�̐F
    ''' </summary>
    Public Property GJ304070_107() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = FHENSU_ID_JGJ304070_107    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = FHENSU_ID_JGJ304070_107    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property

#End Region
#Region "  GJ304070_108:-�̐F"
    ''' <summary>
    ''' -�̐F
    ''' </summary>
    Public Property GJ304070_108() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = FHENSU_ID_JGJ304070_108    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = FHENSU_ID_JGJ304070_108    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property

#End Region
#Region "  GJ304070_109:���̐F"
    ''' <summary>
    ''' ���̐F
    ''' </summary>
    Public Property GJ304070_109() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = FHENSU_ID_JGJ304070_109    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = FHENSU_ID_JGJ304070_109    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property

#End Region
#Region "  GJ304070_110:���̐F"
    ''' <summary>
    ''' ���̐F
    ''' </summary>
    Public Property GJ304070_110() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = FHENSU_ID_JGJ304070_110    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = FHENSU_ID_JGJ304070_110    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property

#End Region
#Region "  GJ304070_111:���̐F"
    ''' <summary>
    ''' ���̐F
    ''' </summary>
    Public Property GJ304070_111() As Object
        Get
            '(�����è   �擾����)

            Dim objReturn As Object
            mFHENSU_ID = FHENSU_ID_JGJ304070_111    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��擾       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                '�ް�       ���


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(�����è   �X�V����)

            mFHENSU_ID = FHENSU_ID_JGJ304070_111    '�ϐ�ID     ���


            '***************************************************
            '���ѕϐ��X�V       (�����^)
            '***************************************************
            Dim intRet As RetCode                   '�߂�l
            Dim strMsg As String                    'ү����
            intRet = GET_TPRG_SYS_HEN_OBJ()         '���       �擾
            If intRet = RetCode.NotFound Then
                '(������Ȃ��ꍇ)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[�ϐ�ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 '�ް�       ���
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '���       �X�V


        End Set
    End Property

#End Region





    '���������ьŗL
    '**********************************************************************************************


End Class
