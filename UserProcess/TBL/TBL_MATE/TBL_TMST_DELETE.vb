'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' �y���́zMaterialStreamð��ٸ׽
' �y�@�\�z�ް��폜Ͻ�ð��ٸ׽
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
''' �ް��폜Ͻ�ð��ٸ׽
''' </summary>
Public Class TBL_TMST_DELETE
    Inherits clsTemplateTable

    '**********************************************************************************************
    '����������������
#Region "  �׽�ϐ���`                  "
    '�����è
    Private mobjAryMe As TBL_TMST_DELETE()                                       '�ް��폜Ͻ�
    Private mstrUSER_SQL As String                                               'հ�ްSQL
    Private mORDER_BY As String                                                  'OrderBy��
    Private mWHERE As String                                                     'Where��
    Private mFTABLE_NAME As String                                               'ð��ٖ�
    Private mFTABLE_AREA As Nullable(Of Integer)                                 '�\�̈�
    Private mFCONDITION_SERIAL As Nullable(Of Integer)                           '�����A��
    Private mFDELETE_KUBUN As Nullable(Of Integer)                               '�폜�敪
    Private mFDELETE_UNIT As String                                              '����폜�P��
    Private mFDELETE_FIELD As String                                             '�폜����̨����
    Private mFDELETE_VALUE As Nullable(Of Integer)                               '�폜�����l
    Private mFDELETE_KUBUN02 As Nullable(Of Integer)                             '�폜�敪02
    Private mFDELETE_FIELD02 As String                                           '�폜����̨����02
    Private mFDELETE_VALUE02 As Nullable(Of Integer)                             '�폜�����l02
#End Region
#Region "  �����è��`                  "
    ''' <summary>
    ''' ���ѕϐ� (���׽�^�z��)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_TMST_DELETE()
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
    ''' ð��ٖ�
    ''' </summary>
    Public Property FTABLE_NAME() As String
        Get
            Return mFTABLE_NAME
        End Get
        Set(ByVal Value As String)
            mFTABLE_NAME = Value
        End Set
    End Property
    ''' <summary>
    ''' �\�̈�
    ''' </summary>
    Public Property FTABLE_AREA() As Nullable(Of Integer)
        Get
            Return mFTABLE_AREA
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFTABLE_AREA = Value
        End Set
    End Property
    ''' <summary>
    ''' �����A��
    ''' </summary>
    Public Property FCONDITION_SERIAL() As Nullable(Of Integer)
        Get
            Return mFCONDITION_SERIAL
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFCONDITION_SERIAL = Value
        End Set
    End Property
    ''' <summary>
    ''' �폜�敪
    ''' </summary>
    Public Property FDELETE_KUBUN() As Nullable(Of Integer)
        Get
            Return mFDELETE_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFDELETE_KUBUN = Value
        End Set
    End Property
    ''' <summary>
    ''' ����폜�P��
    ''' </summary>
    Public Property FDELETE_UNIT() As String
        Get
            Return mFDELETE_UNIT
        End Get
        Set(ByVal Value As String)
            mFDELETE_UNIT = Value
        End Set
    End Property
    ''' <summary>
    ''' �폜����̨����
    ''' </summary>
    Public Property FDELETE_FIELD() As String
        Get
            Return mFDELETE_FIELD
        End Get
        Set(ByVal Value As String)
            mFDELETE_FIELD = Value
        End Set
    End Property
    ''' <summary>
    ''' �폜�����l
    ''' </summary>
    Public Property FDELETE_VALUE() As Nullable(Of Integer)
        Get
            Return mFDELETE_VALUE
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFDELETE_VALUE = Value
        End Set
    End Property
    ''' <summary>
    ''' �폜�敪02
    ''' </summary>
    Public Property FDELETE_KUBUN02() As Nullable(Of Integer)
        Get
            Return mFDELETE_KUBUN02
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFDELETE_KUBUN02 = Value
        End Set
    End Property
    ''' <summary>
    ''' �폜����̨����02
    ''' </summary>
    Public Property FDELETE_FIELD02() As String
        Get
            Return mFDELETE_FIELD02
        End Get
        Set(ByVal Value As String)
            mFDELETE_FIELD02 = Value
        End Set
    End Property
    ''' <summary>
    ''' �폜�����l02
    ''' </summary>
    Public Property FDELETE_VALUE02() As Nullable(Of Integer)
        Get
            Return mFDELETE_VALUE02
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFDELETE_VALUE02 = Value
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
    Public Function GET_TMST_DELETE(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    TMST_DELETE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FTABLE_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTABLE_NAME
            strSQL.Append(vbCrLf & "    AND FTABLE_NAME = :" & UBound(strBindField) - 1 & " --ð��ٖ�")
        End If
        If IsNull(FTABLE_AREA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTABLE_AREA
            strSQL.Append(vbCrLf & "    AND FTABLE_AREA = :" & UBound(strBindField) - 1 & " --�\�̈�")
        End If
        If IsNull(FCONDITION_SERIAL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCONDITION_SERIAL
            strSQL.Append(vbCrLf & "    AND FCONDITION_SERIAL = :" & UBound(strBindField) - 1 & " --�����A��")
        End If
        If IsNull(FDELETE_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_KUBUN
            strSQL.Append(vbCrLf & "    AND FDELETE_KUBUN = :" & UBound(strBindField) - 1 & " --�폜�敪")
        End If
        If IsNull(FDELETE_UNIT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_UNIT
            strSQL.Append(vbCrLf & "    AND FDELETE_UNIT = :" & UBound(strBindField) - 1 & " --����폜�P��")
        End If
        If IsNull(FDELETE_FIELD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_FIELD
            strSQL.Append(vbCrLf & "    AND FDELETE_FIELD = :" & UBound(strBindField) - 1 & " --�폜����̨����")
        End If
        If IsNull(FDELETE_VALUE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_VALUE
            strSQL.Append(vbCrLf & "    AND FDELETE_VALUE = :" & UBound(strBindField) - 1 & " --�폜�����l")
        End If
        If IsNull(FDELETE_KUBUN02) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_KUBUN02
            strSQL.Append(vbCrLf & "    AND FDELETE_KUBUN02 = :" & UBound(strBindField) - 1 & " --�폜�敪02")
        End If
        If IsNull(FDELETE_FIELD02) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_FIELD02
            strSQL.Append(vbCrLf & "    AND FDELETE_FIELD02 = :" & UBound(strBindField) - 1 & " --�폜����̨����02")
        End If
        If IsNull(FDELETE_VALUE02) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_VALUE02
            strSQL.Append(vbCrLf & "    AND FDELETE_VALUE02 = :" & UBound(strBindField) - 1 & " --�폜�����l02")
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
        strDataSetName = "TMST_DELETE"
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
    Public Function GET_TMST_DELETE_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    TMST_DELETE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FTABLE_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTABLE_NAME
            strSQL.Append(vbCrLf & "    AND FTABLE_NAME = :" & UBound(strBindField) - 1 & " --ð��ٖ�")
        End If
        If IsNull(FTABLE_AREA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTABLE_AREA
            strSQL.Append(vbCrLf & "    AND FTABLE_AREA = :" & UBound(strBindField) - 1 & " --�\�̈�")
        End If
        If IsNull(FCONDITION_SERIAL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCONDITION_SERIAL
            strSQL.Append(vbCrLf & "    AND FCONDITION_SERIAL = :" & UBound(strBindField) - 1 & " --�����A��")
        End If
        If IsNull(FDELETE_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_KUBUN
            strSQL.Append(vbCrLf & "    AND FDELETE_KUBUN = :" & UBound(strBindField) - 1 & " --�폜�敪")
        End If
        If IsNull(FDELETE_UNIT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_UNIT
            strSQL.Append(vbCrLf & "    AND FDELETE_UNIT = :" & UBound(strBindField) - 1 & " --����폜�P��")
        End If
        If IsNull(FDELETE_FIELD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_FIELD
            strSQL.Append(vbCrLf & "    AND FDELETE_FIELD = :" & UBound(strBindField) - 1 & " --�폜����̨����")
        End If
        If IsNull(FDELETE_VALUE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_VALUE
            strSQL.Append(vbCrLf & "    AND FDELETE_VALUE = :" & UBound(strBindField) - 1 & " --�폜�����l")
        End If
        If IsNull(FDELETE_KUBUN02) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_KUBUN02
            strSQL.Append(vbCrLf & "    AND FDELETE_KUBUN02 = :" & UBound(strBindField) - 1 & " --�폜�敪02")
        End If
        If IsNull(FDELETE_FIELD02) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_FIELD02
            strSQL.Append(vbCrLf & "    AND FDELETE_FIELD02 = :" & UBound(strBindField) - 1 & " --�폜����̨����02")
        End If
        If IsNull(FDELETE_VALUE02) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_VALUE02
            strSQL.Append(vbCrLf & "    AND FDELETE_VALUE02 = :" & UBound(strBindField) - 1 & " --�폜�����l02")
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
        strDataSetName = "TMST_DELETE"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TMST_DELETE(Owner, objDb, objDbLog)
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
    Public Function GET_TMST_DELETE_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "TMST_DELETE"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TMST_DELETE(Owner, objDb, objDbLog)
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
    Public Function GET_TMST_DELETE_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    TMST_DELETE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FTABLE_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTABLE_NAME
            strSQL.Append(vbCrLf & "    AND FTABLE_NAME = :" & UBound(strBindField) - 1 & " --ð��ٖ�")
        End If
        If IsNull(FTABLE_AREA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTABLE_AREA
            strSQL.Append(vbCrLf & "    AND FTABLE_AREA = :" & UBound(strBindField) - 1 & " --�\�̈�")
        End If
        If IsNull(FCONDITION_SERIAL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCONDITION_SERIAL
            strSQL.Append(vbCrLf & "    AND FCONDITION_SERIAL = :" & UBound(strBindField) - 1 & " --�����A��")
        End If
        If IsNull(FDELETE_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_KUBUN
            strSQL.Append(vbCrLf & "    AND FDELETE_KUBUN = :" & UBound(strBindField) - 1 & " --�폜�敪")
        End If
        If IsNull(FDELETE_UNIT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_UNIT
            strSQL.Append(vbCrLf & "    AND FDELETE_UNIT = :" & UBound(strBindField) - 1 & " --����폜�P��")
        End If
        If IsNull(FDELETE_FIELD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_FIELD
            strSQL.Append(vbCrLf & "    AND FDELETE_FIELD = :" & UBound(strBindField) - 1 & " --�폜����̨����")
        End If
        If IsNull(FDELETE_VALUE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_VALUE
            strSQL.Append(vbCrLf & "    AND FDELETE_VALUE = :" & UBound(strBindField) - 1 & " --�폜�����l")
        End If
        If IsNull(FDELETE_KUBUN02) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_KUBUN02
            strSQL.Append(vbCrLf & "    AND FDELETE_KUBUN02 = :" & UBound(strBindField) - 1 & " --�폜�敪02")
        End If
        If IsNull(FDELETE_FIELD02) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_FIELD02
            strSQL.Append(vbCrLf & "    AND FDELETE_FIELD02 = :" & UBound(strBindField) - 1 & " --�폜����̨����02")
        End If
        If IsNull(FDELETE_VALUE02) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_VALUE02
            strSQL.Append(vbCrLf & "    AND FDELETE_VALUE02 = :" & UBound(strBindField) - 1 & " --�폜�����l02")
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
        strDataSetName = "TMST_DELETE"
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
    Public Sub UPDATE_TMST_DELETE()
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
        ElseIf IsNull(mFTABLE_NAME) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ð��ٖ�]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFTABLE_AREA) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�\�̈�]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFCONDITION_SERIAL) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�����A��]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFDELETE_KUBUN) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�폜�敪]"
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
        strSQL.Append(vbCrLf & "    TMST_DELETE")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
        If IsNull(mFTABLE_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTABLE_NAME = NULL --ð��ٖ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTABLE_NAME = NULL --ð��ٖ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTABLE_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTABLE_NAME = :" & Ubound(strBindField) - 1 & " --ð��ٖ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTABLE_NAME = :" & Ubound(strBindField) - 1 & " --ð��ٖ�")
        End If
        intCount = intCount + 1
        If IsNull(mFTABLE_AREA) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTABLE_AREA = NULL --�\�̈�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTABLE_AREA = NULL --�\�̈�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTABLE_AREA
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTABLE_AREA = :" & Ubound(strBindField) - 1 & " --�\�̈�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTABLE_AREA = :" & Ubound(strBindField) - 1 & " --�\�̈�")
        End If
        intCount = intCount + 1
        If IsNull(mFCONDITION_SERIAL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCONDITION_SERIAL = NULL --�����A��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCONDITION_SERIAL = NULL --�����A��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCONDITION_SERIAL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCONDITION_SERIAL = :" & Ubound(strBindField) - 1 & " --�����A��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCONDITION_SERIAL = :" & Ubound(strBindField) - 1 & " --�����A��")
        End If
        intCount = intCount + 1
        If IsNull(mFDELETE_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDELETE_KUBUN = NULL --�폜�敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDELETE_KUBUN = NULL --�폜�敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDELETE_KUBUN = :" & Ubound(strBindField) - 1 & " --�폜�敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDELETE_KUBUN = :" & Ubound(strBindField) - 1 & " --�폜�敪")
        End If
        intCount = intCount + 1
        If IsNull(mFDELETE_UNIT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDELETE_UNIT = NULL --����폜�P��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDELETE_UNIT = NULL --����폜�P��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_UNIT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDELETE_UNIT = :" & Ubound(strBindField) - 1 & " --����폜�P��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDELETE_UNIT = :" & Ubound(strBindField) - 1 & " --����폜�P��")
        End If
        intCount = intCount + 1
        If IsNull(mFDELETE_FIELD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDELETE_FIELD = NULL --�폜����̨����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDELETE_FIELD = NULL --�폜����̨����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_FIELD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDELETE_FIELD = :" & Ubound(strBindField) - 1 & " --�폜����̨����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDELETE_FIELD = :" & Ubound(strBindField) - 1 & " --�폜����̨����")
        End If
        intCount = intCount + 1
        If IsNull(mFDELETE_VALUE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDELETE_VALUE = NULL --�폜�����l")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDELETE_VALUE = NULL --�폜�����l")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_VALUE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDELETE_VALUE = :" & Ubound(strBindField) - 1 & " --�폜�����l")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDELETE_VALUE = :" & Ubound(strBindField) - 1 & " --�폜�����l")
        End If
        intCount = intCount + 1
        If IsNull(mFDELETE_KUBUN02) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDELETE_KUBUN02 = NULL --�폜�敪02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDELETE_KUBUN02 = NULL --�폜�敪02")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_KUBUN02
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDELETE_KUBUN02 = :" & Ubound(strBindField) - 1 & " --�폜�敪02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDELETE_KUBUN02 = :" & Ubound(strBindField) - 1 & " --�폜�敪02")
        End If
        intCount = intCount + 1
        If IsNull(mFDELETE_FIELD02) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDELETE_FIELD02 = NULL --�폜����̨����02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDELETE_FIELD02 = NULL --�폜����̨����02")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_FIELD02
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDELETE_FIELD02 = :" & Ubound(strBindField) - 1 & " --�폜����̨����02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDELETE_FIELD02 = :" & Ubound(strBindField) - 1 & " --�폜����̨����02")
        End If
        intCount = intCount + 1
        If IsNull(mFDELETE_VALUE02) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDELETE_VALUE02 = NULL --�폜�����l02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDELETE_VALUE02 = NULL --�폜�����l02")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_VALUE02
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDELETE_VALUE02 = :" & Ubound(strBindField) - 1 & " --�폜�����l02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDELETE_VALUE02 = :" & Ubound(strBindField) - 1 & " --�폜�����l02")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FTABLE_NAME) = True Then
            strSQL.Append(vbCrLf & "    AND FTABLE_NAME IS NULL --ð��ٖ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTABLE_NAME
            strSQL.Append(vbCrLf & "    AND FTABLE_NAME = :" & UBound(strBindField) - 1 & " --ð��ٖ�")
        End If
        If IsNull(FTABLE_AREA) = True Then
            strSQL.Append(vbCrLf & "    AND FTABLE_AREA IS NULL --�\�̈�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTABLE_AREA
            strSQL.Append(vbCrLf & "    AND FTABLE_AREA = :" & UBound(strBindField) - 1 & " --�\�̈�")
        End If
        If IsNull(FCONDITION_SERIAL) = True Then
            strSQL.Append(vbCrLf & "    AND FCONDITION_SERIAL IS NULL --�����A��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCONDITION_SERIAL
            strSQL.Append(vbCrLf & "    AND FCONDITION_SERIAL = :" & UBound(strBindField) - 1 & " --�����A��")
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
    Public Sub ADD_TMST_DELETE()
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
        ElseIf IsNull(mFTABLE_NAME) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ð��ٖ�]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFTABLE_AREA) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�\�̈�]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFCONDITION_SERIAL) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�����A��]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFDELETE_KUBUN) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�폜�敪]"
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
        strSQL.Append(vbCrLf & "    TMST_DELETE")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
        If IsNull(mFTABLE_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ð��ٖ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ð��ٖ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTABLE_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ð��ٖ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ð��ٖ�")
        End If
        intCount = intCount + 1
        If IsNull(mFTABLE_AREA) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�\�̈�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�\�̈�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTABLE_AREA
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�\�̈�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�\�̈�")
        End If
        intCount = intCount + 1
        If IsNull(mFCONDITION_SERIAL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�����A��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�����A��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCONDITION_SERIAL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�����A��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�����A��")
        End If
        intCount = intCount + 1
        If IsNull(mFDELETE_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�폜�敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�폜�敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�폜�敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�폜�敪")
        End If
        intCount = intCount + 1
        If IsNull(mFDELETE_UNIT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����폜�P��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����폜�P��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_UNIT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����폜�P��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����폜�P��")
        End If
        intCount = intCount + 1
        If IsNull(mFDELETE_FIELD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�폜����̨����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�폜����̨����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_FIELD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�폜����̨����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�폜����̨����")
        End If
        intCount = intCount + 1
        If IsNull(mFDELETE_VALUE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�폜�����l")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�폜�����l")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_VALUE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�폜�����l")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�폜�����l")
        End If
        intCount = intCount + 1
        If IsNull(mFDELETE_KUBUN02) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�폜�敪02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�폜�敪02")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_KUBUN02
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�폜�敪02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�폜�敪02")
        End If
        intCount = intCount + 1
        If IsNull(mFDELETE_FIELD02) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�폜����̨����02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�폜����̨����02")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_FIELD02
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�폜����̨����02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�폜����̨����02")
        End If
        intCount = intCount + 1
        If IsNull(mFDELETE_VALUE02) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�폜�����l02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�폜�����l02")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_VALUE02
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�폜�����l02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�폜�����l02")
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
    Public Sub DELETE_TMST_DELETE()
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
        ElseIf IsNull(mFTABLE_NAME) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ð��ٖ�]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFTABLE_AREA) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�\�̈�]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFCONDITION_SERIAL) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�����A��]"
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
        strSQL.Append(vbCrLf & "    TMST_DELETE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FTABLE_NAME) = True Then
            strSQL.Append(vbCrLf & "    AND FTABLE_NAME IS NULL --ð��ٖ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTABLE_NAME
            strSQL.Append(vbCrLf & "    AND FTABLE_NAME = :" & UBound(strBindField) - 1 & " --ð��ٖ�")
        End If
        If IsNull(FTABLE_AREA) = True Then
            strSQL.Append(vbCrLf & "    AND FTABLE_AREA IS NULL --�\�̈�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTABLE_AREA
            strSQL.Append(vbCrLf & "    AND FTABLE_AREA = :" & UBound(strBindField) - 1 & " --�\�̈�")
        End If
        If IsNull(FCONDITION_SERIAL) = True Then
            strSQL.Append(vbCrLf & "    AND FCONDITION_SERIAL IS NULL --�����A��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCONDITION_SERIAL
            strSQL.Append(vbCrLf & "    AND FCONDITION_SERIAL = :" & UBound(strBindField) - 1 & " --�����A��")
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
    Public Sub DELETE_TMST_DELETE_ANY()
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
        strSQL.Append(vbCrLf & "    TMST_DELETE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(FTABLE_NAME) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTABLE_NAME
            strSQL.Append(vbCrLf & "    AND FTABLE_NAME = :" & UBound(strBindField) - 1 & " --ð��ٖ�")
        End If
        If IsNotNull(FTABLE_AREA) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTABLE_AREA
            strSQL.Append(vbCrLf & "    AND FTABLE_AREA = :" & UBound(strBindField) - 1 & " --�\�̈�")
        End If
        If IsNotNull(FCONDITION_SERIAL) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCONDITION_SERIAL
            strSQL.Append(vbCrLf & "    AND FCONDITION_SERIAL = :" & UBound(strBindField) - 1 & " --�����A��")
        End If
        If IsNotNull(FDELETE_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_KUBUN
            strSQL.Append(vbCrLf & "    AND FDELETE_KUBUN = :" & UBound(strBindField) - 1 & " --�폜�敪")
        End If
        If IsNotNull(FDELETE_UNIT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_UNIT
            strSQL.Append(vbCrLf & "    AND FDELETE_UNIT = :" & UBound(strBindField) - 1 & " --����폜�P��")
        End If
        If IsNotNull(FDELETE_FIELD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_FIELD
            strSQL.Append(vbCrLf & "    AND FDELETE_FIELD = :" & UBound(strBindField) - 1 & " --�폜����̨����")
        End If
        If IsNotNull(FDELETE_VALUE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_VALUE
            strSQL.Append(vbCrLf & "    AND FDELETE_VALUE = :" & UBound(strBindField) - 1 & " --�폜�����l")
        End If
        If IsNotNull(FDELETE_KUBUN02) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_KUBUN02
            strSQL.Append(vbCrLf & "    AND FDELETE_KUBUN02 = :" & UBound(strBindField) - 1 & " --�폜�敪02")
        End If
        If IsNotNull(FDELETE_FIELD02) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_FIELD02
            strSQL.Append(vbCrLf & "    AND FDELETE_FIELD02 = :" & UBound(strBindField) - 1 & " --�폜����̨����02")
        End If
        If IsNotNull(FDELETE_VALUE02) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_VALUE02
            strSQL.Append(vbCrLf & "    AND FDELETE_VALUE02 = :" & UBound(strBindField) - 1 & " --�폜�����l02")
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
        If IsNothing(objType.GetProperty("FTABLE_NAME")) = False Then mFTABLE_NAME = objObject.FTABLE_NAME 'ð��ٖ�
        If IsNothing(objType.GetProperty("FTABLE_AREA")) = False Then mFTABLE_AREA = objObject.FTABLE_AREA '�\�̈�
        If IsNothing(objType.GetProperty("FCONDITION_SERIAL")) = False Then mFCONDITION_SERIAL = objObject.FCONDITION_SERIAL '�����A��
        If IsNothing(objType.GetProperty("FDELETE_KUBUN")) = False Then mFDELETE_KUBUN = objObject.FDELETE_KUBUN '�폜�敪
        If IsNothing(objType.GetProperty("FDELETE_UNIT")) = False Then mFDELETE_UNIT = objObject.FDELETE_UNIT '����폜�P��
        If IsNothing(objType.GetProperty("FDELETE_FIELD")) = False Then mFDELETE_FIELD = objObject.FDELETE_FIELD '�폜����̨����
        If IsNothing(objType.GetProperty("FDELETE_VALUE")) = False Then mFDELETE_VALUE = objObject.FDELETE_VALUE '�폜�����l
        If IsNothing(objType.GetProperty("FDELETE_KUBUN02")) = False Then mFDELETE_KUBUN02 = objObject.FDELETE_KUBUN02 '�폜�敪02
        If IsNothing(objType.GetProperty("FDELETE_FIELD02")) = False Then mFDELETE_FIELD02 = objObject.FDELETE_FIELD02 '�폜����̨����02
        If IsNothing(objType.GetProperty("FDELETE_VALUE02")) = False Then mFDELETE_VALUE02 = objObject.FDELETE_VALUE02 '�폜�����l02

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
        mFTABLE_NAME = Nothing
        mFTABLE_AREA = Nothing
        mFCONDITION_SERIAL = Nothing
        mFDELETE_KUBUN = Nothing
        mFDELETE_UNIT = Nothing
        mFDELETE_FIELD = Nothing
        mFDELETE_VALUE = Nothing
        mFDELETE_KUBUN02 = Nothing
        mFDELETE_FIELD02 = Nothing
        mFDELETE_VALUE02 = Nothing


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
        mFTABLE_NAME = TO_STRING_NULLABLE(objRow("FTABLE_NAME"))
        mFTABLE_AREA = TO_INTEGER_NULLABLE(objRow("FTABLE_AREA"))
        mFCONDITION_SERIAL = TO_INTEGER_NULLABLE(objRow("FCONDITION_SERIAL"))
        mFDELETE_KUBUN = TO_INTEGER_NULLABLE(objRow("FDELETE_KUBUN"))
        mFDELETE_UNIT = TO_STRING_NULLABLE(objRow("FDELETE_UNIT"))
        mFDELETE_FIELD = TO_STRING_NULLABLE(objRow("FDELETE_FIELD"))
        mFDELETE_VALUE = TO_INTEGER_NULLABLE(objRow("FDELETE_VALUE"))
        mFDELETE_KUBUN02 = TO_INTEGER_NULLABLE(objRow("FDELETE_KUBUN02"))
        mFDELETE_FIELD02 = TO_STRING_NULLABLE(objRow("FDELETE_FIELD02"))
        mFDELETE_VALUE02 = TO_INTEGER_NULLABLE(objRow("FDELETE_VALUE02"))


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
        strMsg &= "[ð��ٖ�:�ް��폜Ͻ�]"
        If IsNotNull(FTABLE_NAME) Then
            strMsg &= "[ð��ٖ�:" & FTABLE_NAME & "]"
        End If
        If IsNotNull(FTABLE_AREA) Then
            strMsg &= "[�\�̈�:" & FTABLE_AREA & "]"
        End If
        If IsNotNull(FCONDITION_SERIAL) Then
            strMsg &= "[�����A��:" & FCONDITION_SERIAL & "]"
        End If
        If IsNotNull(FDELETE_KUBUN) Then
            strMsg &= "[�폜�敪:" & FDELETE_KUBUN & "]"
        End If
        If IsNotNull(FDELETE_UNIT) Then
            strMsg &= "[����폜�P��:" & FDELETE_UNIT & "]"
        End If
        If IsNotNull(FDELETE_FIELD) Then
            strMsg &= "[�폜����̨����:" & FDELETE_FIELD & "]"
        End If
        If IsNotNull(FDELETE_VALUE) Then
            strMsg &= "[�폜�����l:" & FDELETE_VALUE & "]"
        End If
        If IsNotNull(FDELETE_KUBUN02) Then
            strMsg &= "[�폜�敪02:" & FDELETE_KUBUN02 & "]"
        End If
        If IsNotNull(FDELETE_FIELD02) Then
            strMsg &= "[�폜����̨����02:" & FDELETE_FIELD02 & "]"
        End If
        If IsNotNull(FDELETE_VALUE02) Then
            strMsg &= "[�폜�����l02:" & FDELETE_VALUE02 & "]"
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
