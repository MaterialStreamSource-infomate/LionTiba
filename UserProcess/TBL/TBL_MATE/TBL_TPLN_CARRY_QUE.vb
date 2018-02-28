'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' �y���́zMaterialStreamð��ٸ׽
' �y�@�\�z�����w��QUEð��ٸ׽
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
''' �����w��QUEð��ٸ׽
''' </summary>
Public Class TBL_TPLN_CARRY_QUE
    Inherits clsTemplateTable

    '**********************************************************************************************
    '����������������
#Region "  �׽�ϐ���`                  "
    '�����è
    Private mobjAryMe As TBL_TPLN_CARRY_QUE()                                    '�����w��QUE
    Private mstrUSER_SQL As String                                               'հ�ްSQL
    Private mORDER_BY As String                                                  'OrderBy��
    Private mWHERE As String                                                     'Where��
    Private mFCARRYQUE_D As Nullable(Of Date)                                    '�����w����
    Private mFCARRYQUE_ORDER As Nullable(Of Integer)                             '��������
    Private mFEQ_ID As String                                                    '�ݔ�ID
    Private mFPRIORITY As Nullable(Of Integer)                                   '�D������
    Private mFPALLET_ID As String                                                '��گ�ID
    Private mFCARRYQUE_KUBUN As Nullable(Of Integer)                             '�w���敪
    Private mFCARRYQUE_DIR_STS As Nullable(Of Integer)                           '�����w����
    Private mFENTRY_DT As Nullable(Of Date)                                      '�o�^����
    Private mFUPDATE_DT As Nullable(Of Date)                                     '�X�V����
    Private mXOYAKO_KUBUN As Nullable(Of Integer)                                '�e�q�敪
    Private mXPALLET_ID_AITE As String                                           '������گ�ID
#End Region
#Region "  �����è��`                  "
    ''' <summary>
    ''' ���ѕϐ� (���׽�^�z��)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_TPLN_CARRY_QUE()
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
    ''' �����w����
    ''' </summary>
    Public Property FCARRYQUE_D() As Nullable(Of Date)
        Get
            Return mFCARRYQUE_D
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mFCARRYQUE_D = Value
        End Set
    End Property
    ''' <summary>
    ''' ��������
    ''' </summary>
    Public Property FCARRYQUE_ORDER() As Nullable(Of Integer)
        Get
            Return mFCARRYQUE_ORDER
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFCARRYQUE_ORDER = Value
        End Set
    End Property
    ''' <summary>
    ''' �ݔ�ID
    ''' </summary>
    Public Property FEQ_ID() As String
        Get
            Return mFEQ_ID
        End Get
        Set(ByVal Value As String)
            mFEQ_ID = Value
        End Set
    End Property
    ''' <summary>
    ''' �D������
    ''' </summary>
    Public Property FPRIORITY() As Nullable(Of Integer)
        Get
            Return mFPRIORITY
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFPRIORITY = Value
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
    ''' �w���敪
    ''' </summary>
    Public Property FCARRYQUE_KUBUN() As Nullable(Of Integer)
        Get
            Return mFCARRYQUE_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFCARRYQUE_KUBUN = Value
        End Set
    End Property
    ''' <summary>
    ''' �����w����
    ''' </summary>
    Public Property FCARRYQUE_DIR_STS() As Nullable(Of Integer)
        Get
            Return mFCARRYQUE_DIR_STS
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFCARRYQUE_DIR_STS = Value
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
    ''' �e�q�敪
    ''' </summary>
    Public Property XOYAKO_KUBUN() As Nullable(Of Integer)
        Get
            Return mXOYAKO_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXOYAKO_KUBUN = Value
        End Set
    End Property
    ''' <summary>
    ''' ������گ�ID
    ''' </summary>
    Public Property XPALLET_ID_AITE() As String
        Get
            Return mXPALLET_ID_AITE
        End Get
        Set(ByVal Value As String)
            mXPALLET_ID_AITE = Value
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
    Public Function GET_TPLN_CARRY_QUE(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    TPLN_CARRY_QUE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FCARRYQUE_D) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_D
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_D = :" & UBound(strBindField) - 1 & " --�����w����")
        End If
        If IsNull(FCARRYQUE_ORDER) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_ORDER
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_ORDER = :" & UBound(strBindField) - 1 & " --��������")
        End If
        If IsNull(FEQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --�ݔ�ID")
        End If
        If IsNull(FPRIORITY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPRIORITY
            strSQL.Append(vbCrLf & "    AND FPRIORITY = :" & UBound(strBindField) - 1 & " --�D������")
        End If
        If IsNull(FPALLET_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --��گ�ID")
        End If
        If IsNull(FCARRYQUE_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_KUBUN
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_KUBUN = :" & UBound(strBindField) - 1 & " --�w���敪")
        End If
        If IsNull(FCARRYQUE_DIR_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_DIR_STS
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_DIR_STS = :" & UBound(strBindField) - 1 & " --�����w����")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --�o�^����")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --�X�V����")
        End If
        If IsNull(XOYAKO_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOYAKO_KUBUN
            strSQL.Append(vbCrLf & "    AND XOYAKO_KUBUN = :" & UBound(strBindField) - 1 & " --�e�q�敪")
        End If
        If IsNull(XPALLET_ID_AITE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPALLET_ID_AITE
            strSQL.Append(vbCrLf & "    AND XPALLET_ID_AITE = :" & UBound(strBindField) - 1 & " --������گ�ID")
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
        strDataSetName = "TPLN_CARRY_QUE"
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
    Public Function GET_TPLN_CARRY_QUE_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    TPLN_CARRY_QUE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FCARRYQUE_D) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_D
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_D = :" & UBound(strBindField) - 1 & " --�����w����")
        End If
        If IsNull(FCARRYQUE_ORDER) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_ORDER
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_ORDER = :" & UBound(strBindField) - 1 & " --��������")
        End If
        If IsNull(FEQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --�ݔ�ID")
        End If
        If IsNull(FPRIORITY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPRIORITY
            strSQL.Append(vbCrLf & "    AND FPRIORITY = :" & UBound(strBindField) - 1 & " --�D������")
        End If
        If IsNull(FPALLET_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --��گ�ID")
        End If
        If IsNull(FCARRYQUE_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_KUBUN
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_KUBUN = :" & UBound(strBindField) - 1 & " --�w���敪")
        End If
        If IsNull(FCARRYQUE_DIR_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_DIR_STS
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_DIR_STS = :" & UBound(strBindField) - 1 & " --�����w����")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --�o�^����")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --�X�V����")
        End If
        If IsNull(XOYAKO_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOYAKO_KUBUN
            strSQL.Append(vbCrLf & "    AND XOYAKO_KUBUN = :" & UBound(strBindField) - 1 & " --�e�q�敪")
        End If
        If IsNull(XPALLET_ID_AITE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPALLET_ID_AITE
            strSQL.Append(vbCrLf & "    AND XPALLET_ID_AITE = :" & UBound(strBindField) - 1 & " --������گ�ID")
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
        strDataSetName = "TPLN_CARRY_QUE"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TPLN_CARRY_QUE(Owner, objDb, objDbLog)
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
    Public Function GET_TPLN_CARRY_QUE_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "TPLN_CARRY_QUE"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TPLN_CARRY_QUE(Owner, objDb, objDbLog)
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
    Public Function GET_TPLN_CARRY_QUE_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    TPLN_CARRY_QUE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FCARRYQUE_D) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_D
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_D = :" & UBound(strBindField) - 1 & " --�����w����")
        End If
        If IsNull(FCARRYQUE_ORDER) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_ORDER
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_ORDER = :" & UBound(strBindField) - 1 & " --��������")
        End If
        If IsNull(FEQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --�ݔ�ID")
        End If
        If IsNull(FPRIORITY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPRIORITY
            strSQL.Append(vbCrLf & "    AND FPRIORITY = :" & UBound(strBindField) - 1 & " --�D������")
        End If
        If IsNull(FPALLET_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --��گ�ID")
        End If
        If IsNull(FCARRYQUE_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_KUBUN
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_KUBUN = :" & UBound(strBindField) - 1 & " --�w���敪")
        End If
        If IsNull(FCARRYQUE_DIR_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_DIR_STS
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_DIR_STS = :" & UBound(strBindField) - 1 & " --�����w����")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --�o�^����")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --�X�V����")
        End If
        If IsNull(XOYAKO_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOYAKO_KUBUN
            strSQL.Append(vbCrLf & "    AND XOYAKO_KUBUN = :" & UBound(strBindField) - 1 & " --�e�q�敪")
        End If
        If IsNull(XPALLET_ID_AITE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPALLET_ID_AITE
            strSQL.Append(vbCrLf & "    AND XPALLET_ID_AITE = :" & UBound(strBindField) - 1 & " --������گ�ID")
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
        strDataSetName = "TPLN_CARRY_QUE"
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
    Public Sub UPDATE_TPLN_CARRY_QUE()
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
        ElseIf IsNull(mFCARRYQUE_D) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�����w����]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFCARRYQUE_ORDER) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[��������]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFEQ_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�ݔ�ID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFPRIORITY) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�D������]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFPALLET_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[��گ�ID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFCARRYQUE_KUBUN) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�w���敪]"
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
        strSQL.Append(vbCrLf & "    TPLN_CARRY_QUE")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
        If IsNull(mFCARRYQUE_D) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCARRYQUE_D = NULL --�����w����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCARRYQUE_D = NULL --�����w����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_D
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCARRYQUE_D = :" & Ubound(strBindField) - 1 & " --�����w����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCARRYQUE_D = :" & Ubound(strBindField) - 1 & " --�����w����")
        End If
        intCount = intCount + 1
        If IsNull(mFCARRYQUE_ORDER) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCARRYQUE_ORDER = NULL --��������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCARRYQUE_ORDER = NULL --��������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_ORDER
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCARRYQUE_ORDER = :" & Ubound(strBindField) - 1 & " --��������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCARRYQUE_ORDER = :" & Ubound(strBindField) - 1 & " --��������")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_ID = NULL --�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_ID = NULL --�ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_ID = :" & Ubound(strBindField) - 1 & " --�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_ID = :" & Ubound(strBindField) - 1 & " --�ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mFPRIORITY) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FPRIORITY = NULL --�D������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FPRIORITY = NULL --�D������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPRIORITY
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FPRIORITY = :" & Ubound(strBindField) - 1 & " --�D������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FPRIORITY = :" & Ubound(strBindField) - 1 & " --�D������")
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
        If IsNull(mFCARRYQUE_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCARRYQUE_KUBUN = NULL --�w���敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCARRYQUE_KUBUN = NULL --�w���敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCARRYQUE_KUBUN = :" & Ubound(strBindField) - 1 & " --�w���敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCARRYQUE_KUBUN = :" & Ubound(strBindField) - 1 & " --�w���敪")
        End If
        intCount = intCount + 1
        If IsNull(mFCARRYQUE_DIR_STS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCARRYQUE_DIR_STS = NULL --�����w����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCARRYQUE_DIR_STS = NULL --�����w����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_DIR_STS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCARRYQUE_DIR_STS = :" & Ubound(strBindField) - 1 & " --�����w����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCARRYQUE_DIR_STS = :" & Ubound(strBindField) - 1 & " --�����w����")
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
        If IsNull(mXOYAKO_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XOYAKO_KUBUN = NULL --�e�q�敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XOYAKO_KUBUN = NULL --�e�q�敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOYAKO_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XOYAKO_KUBUN = :" & Ubound(strBindField) - 1 & " --�e�q�敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XOYAKO_KUBUN = :" & Ubound(strBindField) - 1 & " --�e�q�敪")
        End If
        intCount = intCount + 1
        If IsNull(mXPALLET_ID_AITE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XPALLET_ID_AITE = NULL --������گ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XPALLET_ID_AITE = NULL --������گ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPALLET_ID_AITE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XPALLET_ID_AITE = :" & Ubound(strBindField) - 1 & " --������گ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XPALLET_ID_AITE = :" & Ubound(strBindField) - 1 & " --������گ�ID")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FCARRYQUE_D) = True Then
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_D IS NULL --�����w����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_D
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_D = :" & UBound(strBindField) - 1 & " --�����w����")
        End If
        If IsNull(FCARRYQUE_ORDER) = True Then
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_ORDER IS NULL --��������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_ORDER
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_ORDER = :" & UBound(strBindField) - 1 & " --��������")
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
    Public Sub ADD_TPLN_CARRY_QUE()
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
        ElseIf IsNull(mFCARRYQUE_D) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�����w����]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFCARRYQUE_ORDER) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[��������]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFEQ_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�ݔ�ID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFPRIORITY) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�D������]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFPALLET_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[��گ�ID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFCARRYQUE_KUBUN) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�w���敪]"
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
        strSQL.Append(vbCrLf & "    TPLN_CARRY_QUE")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
        If IsNull(mFCARRYQUE_D) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�����w����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�����w����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_D
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�����w����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�����w����")
        End If
        intCount = intCount + 1
        If IsNull(mFCARRYQUE_ORDER) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --��������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --��������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_ORDER
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --��������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --��������")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mFPRIORITY) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�D������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�D������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPRIORITY
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�D������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�D������")
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
        If IsNull(mFCARRYQUE_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�w���敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�w���敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�w���敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�w���敪")
        End If
        intCount = intCount + 1
        If IsNull(mFCARRYQUE_DIR_STS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�����w����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�����w����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_DIR_STS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�����w����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�����w����")
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
        If IsNull(mXOYAKO_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�e�q�敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�e�q�敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOYAKO_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�e�q�敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�e�q�敪")
        End If
        intCount = intCount + 1
        If IsNull(mXPALLET_ID_AITE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --������گ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --������گ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPALLET_ID_AITE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --������گ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --������گ�ID")
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
    Public Sub DELETE_TPLN_CARRY_QUE()
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
        ElseIf IsNull(mFCARRYQUE_D) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�����w����]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFCARRYQUE_ORDER) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[��������]"
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
        strSQL.Append(vbCrLf & "    TPLN_CARRY_QUE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FCARRYQUE_D) = True Then
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_D IS NULL --�����w����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_D
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_D = :" & UBound(strBindField) - 1 & " --�����w����")
        End If
        If IsNull(FCARRYQUE_ORDER) = True Then
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_ORDER IS NULL --��������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_ORDER
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_ORDER = :" & UBound(strBindField) - 1 & " --��������")
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
    Public Sub DELETE_TPLN_CARRY_QUE_ANY()
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
        strSQL.Append(vbCrLf & "    TPLN_CARRY_QUE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(FCARRYQUE_D) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_D
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_D = :" & UBound(strBindField) - 1 & " --�����w����")
        End If
        If IsNotNull(FCARRYQUE_ORDER) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_ORDER
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_ORDER = :" & UBound(strBindField) - 1 & " --��������")
        End If
        If IsNotNull(FEQ_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --�ݔ�ID")
        End If
        If IsNotNull(FPRIORITY) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPRIORITY
            strSQL.Append(vbCrLf & "    AND FPRIORITY = :" & UBound(strBindField) - 1 & " --�D������")
        End If
        If IsNotNull(FPALLET_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --��گ�ID")
        End If
        If IsNotNull(FCARRYQUE_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_KUBUN
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_KUBUN = :" & UBound(strBindField) - 1 & " --�w���敪")
        End If
        If IsNotNull(FCARRYQUE_DIR_STS) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_DIR_STS
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_DIR_STS = :" & UBound(strBindField) - 1 & " --�����w����")
        End If
        If IsNotNull(FENTRY_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --�o�^����")
        End If
        If IsNotNull(FUPDATE_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --�X�V����")
        End If
        If IsNotNull(XOYAKO_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOYAKO_KUBUN
            strSQL.Append(vbCrLf & "    AND XOYAKO_KUBUN = :" & UBound(strBindField) - 1 & " --�e�q�敪")
        End If
        If IsNotNull(XPALLET_ID_AITE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPALLET_ID_AITE
            strSQL.Append(vbCrLf & "    AND XPALLET_ID_AITE = :" & UBound(strBindField) - 1 & " --������گ�ID")
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
        If IsNothing(objType.GetProperty("FCARRYQUE_D")) = False Then mFCARRYQUE_D = objObject.FCARRYQUE_D '�����w����
        If IsNothing(objType.GetProperty("FCARRYQUE_ORDER")) = False Then mFCARRYQUE_ORDER = objObject.FCARRYQUE_ORDER '��������
        If IsNothing(objType.GetProperty("FEQ_ID")) = False Then mFEQ_ID = objObject.FEQ_ID '�ݔ�ID
        If IsNothing(objType.GetProperty("FPRIORITY")) = False Then mFPRIORITY = objObject.FPRIORITY '�D������
        If IsNothing(objType.GetProperty("FPALLET_ID")) = False Then mFPALLET_ID = objObject.FPALLET_ID '��گ�ID
        If IsNothing(objType.GetProperty("FCARRYQUE_KUBUN")) = False Then mFCARRYQUE_KUBUN = objObject.FCARRYQUE_KUBUN '�w���敪
        If IsNothing(objType.GetProperty("FCARRYQUE_DIR_STS")) = False Then mFCARRYQUE_DIR_STS = objObject.FCARRYQUE_DIR_STS '�����w����
        If IsNothing(objType.GetProperty("FENTRY_DT")) = False Then mFENTRY_DT = objObject.FENTRY_DT '�o�^����
        If IsNothing(objType.GetProperty("FUPDATE_DT")) = False Then mFUPDATE_DT = objObject.FUPDATE_DT '�X�V����
        If IsNothing(objType.GetProperty("XOYAKO_KUBUN")) = False Then mXOYAKO_KUBUN = objObject.XOYAKO_KUBUN '�e�q�敪
        If IsNothing(objType.GetProperty("XPALLET_ID_AITE")) = False Then mXPALLET_ID_AITE = objObject.XPALLET_ID_AITE '������گ�ID

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
        mFCARRYQUE_D = Nothing
        mFCARRYQUE_ORDER = Nothing
        mFEQ_ID = Nothing
        mFPRIORITY = Nothing
        mFPALLET_ID = Nothing
        mFCARRYQUE_KUBUN = Nothing
        mFCARRYQUE_DIR_STS = Nothing
        mFENTRY_DT = Nothing
        mFUPDATE_DT = Nothing
        mXOYAKO_KUBUN = Nothing
        mXPALLET_ID_AITE = Nothing


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
        mFCARRYQUE_D = TO_DATE_NULLABLE(objRow("FCARRYQUE_D"))
        mFCARRYQUE_ORDER = TO_INTEGER_NULLABLE(objRow("FCARRYQUE_ORDER"))
        mFEQ_ID = TO_STRING_NULLABLE(objRow("FEQ_ID"))
        mFPRIORITY = TO_INTEGER_NULLABLE(objRow("FPRIORITY"))
        mFPALLET_ID = TO_STRING_NULLABLE(objRow("FPALLET_ID"))
        mFCARRYQUE_KUBUN = TO_INTEGER_NULLABLE(objRow("FCARRYQUE_KUBUN"))
        mFCARRYQUE_DIR_STS = TO_INTEGER_NULLABLE(objRow("FCARRYQUE_DIR_STS"))
        mFENTRY_DT = TO_DATE_NULLABLE(objRow("FENTRY_DT"))
        mFUPDATE_DT = TO_DATE_NULLABLE(objRow("FUPDATE_DT"))
        mXOYAKO_KUBUN = TO_INTEGER_NULLABLE(objRow("XOYAKO_KUBUN"))
        mXPALLET_ID_AITE = TO_STRING_NULLABLE(objRow("XPALLET_ID_AITE"))


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
        strMsg &= "[ð��ٖ�:�����w��QUE]"
        If IsNotNull(FCARRYQUE_D) Then
            strMsg &= "[�����w����:" & FCARRYQUE_D & "]"
        End If
        If IsNotNull(FCARRYQUE_ORDER) Then
            strMsg &= "[��������:" & FCARRYQUE_ORDER & "]"
        End If
        If IsNotNull(FEQ_ID) Then
            strMsg &= "[�ݔ�ID:" & FEQ_ID & "]"
        End If
        If IsNotNull(FPRIORITY) Then
            strMsg &= "[�D������:" & FPRIORITY & "]"
        End If
        If IsNotNull(FPALLET_ID) Then
            strMsg &= "[��گ�ID:" & FPALLET_ID & "]"
        End If
        If IsNotNull(FCARRYQUE_KUBUN) Then
            strMsg &= "[�w���敪:" & FCARRYQUE_KUBUN & "]"
        End If
        If IsNotNull(FCARRYQUE_DIR_STS) Then
            strMsg &= "[�����w����:" & FCARRYQUE_DIR_STS & "]"
        End If
        If IsNotNull(FENTRY_DT) Then
            strMsg &= "[�o�^����:" & FENTRY_DT & "]"
        End If
        If IsNotNull(FUPDATE_DT) Then
            strMsg &= "[�X�V����:" & FUPDATE_DT & "]"
        End If
        If IsNotNull(XOYAKO_KUBUN) Then
            strMsg &= "[�e�q�敪:" & XOYAKO_KUBUN & "]"
        End If
        If IsNotNull(XPALLET_ID_AITE) Then
            strMsg &= "[������گ�ID:" & XPALLET_ID_AITE & "]"
        End If


    End Sub
#End Region
    '����������������
    '**********************************************************************************************

    '**********************************************************************************************
    '���������ы���
#Region "  �����w��QUE�ǉ�  [����������]        (Public  ADD_TPLN_CARRY_QUE_ORDER)"
    Public Sub ADD_TPLN_CARRY_QUE_ORDER()
        Try
            Dim strSQL As String            'SQL��
            Dim strMsg As String            'ү����
            Dim intRetSQL As Integer        'SQL���s�߂�l
            Dim objDataSet As New DataSet   '�ް����
            Dim strDataSetName As String    '�ް���Ė�
            Dim objRow As DataRow           '1ں��ޕ����ް�

            '***********************
            '�����è����
            '***********************
            If IsNull(mFCARRYQUE_D) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�����w����]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '���oSQL�쐬
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    MAX(FCARRYQUE_ORDER) AS MAX_ORDER"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TPLN_CARRY_QUE"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FCARRYQUE_D = TO_DATE('" & Format(mFCARRYQUE_D, "yyyy/MM/dd HH:mm:ss") & "','YYYY/MM/DD HH24:MI:SS')"
            strSQL &= vbCrLf


            '***********************
            '���o
            '***********************
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TPLN_CARRY_QUE"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                objRow = objDataSet.Tables(strDataSetName).Rows(0)
                If IsDBNull(objRow("MAX_ORDER")) = False Then
                    mFCARRYQUE_ORDER = TO_NUMBER(objRow("MAX_ORDER")) + 1
                Else
                    mFCARRYQUE_ORDER = 1
                End If
            Else
                mFCARRYQUE_ORDER = 1
            End If


            '***********************
            '�ǉ�SQL�쐬
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "INSERT INTO"
            strSQL &= vbCrLf & "    TPLN_CARRY_QUE"
            strSQL &= vbCrLf & " VALUES("
            strSQL &= vbCrLf & "    TO_DATE('" & Format(mFCARRYQUE_D, "yyyy/MM/dd HH:mm:ss") & "','YYYY/MM/DD HH24:MI:SS')"
            strSQL &= vbCrLf & "   ," & TO_STRING(mFCARRYQUE_ORDER)
            strSQL &= vbCrLf & "   ,'" & TO_STRING(mFEQ_ID) & "'"
            strSQL &= vbCrLf & "   ," & TO_STRING(mFPRIORITY)
            strSQL &= vbCrLf & "   ,'" & TO_STRING(mFPALLET_ID) & "'"
            strSQL &= vbCrLf & "   ," & TO_STRING(mFCARRYQUE_KUBUN)
            strSQL &= vbCrLf & "   ," & TO_STRING(mFCARRYQUE_DIR_STS)
            strSQL &= vbCrLf & "   ,TO_DATE('" & Format(mFENTRY_DT, "yyyy/MM/dd HH:mm:ss") & "','YYYY/MM/DD HH24:MI:SS')"
            strSQL &= vbCrLf & "   ,TO_DATE('" & Format(mFUPDATE_DT, "yyyy/MM/dd HH:mm:ss") & "','YYYY/MM/DD HH24:MI:SS')"
            '������������************************************************************************************************************
            'JobMate:N.Dounoshita 2013/04/03  �߱�����Ή�
            If IsNotNull(mXOYAKO_KUBUN) Then
                strSQL &= vbCrLf & "   ," & TO_STRING(mXOYAKO_KUBUN)
            Else
                strSQL &= vbCrLf & "   ,NULL "
            End If
            strSQL &= vbCrLf & "   ,'" & TO_STRING(mXPALLET_ID_AITE) & "'"
            '������������************************************************************************************************************
            strSQL &= vbCrLf & " )"
            strSQL &= vbCrLf


            '***********************
            '�ǉ�
            '***********************
            intRetSQL = ObjDb.Execute(strSQL)
            If intRetSQL = -1 Then
                '(SQL�װ)
                strSQL = Replace(strSQL, vbCrLf, "")
                strMsg = ERRMSG_ERR_ADD & ObjDb.ErrMsg & "�y" & strSQL & "�z"
                Throw New UserException(strMsg)
            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
#Region "  �����w��QUE�폜  [��گ�]             (Public  DELETE_TPLN_CARRY_QUE_PALLET)"
    Public Sub DELETE_TPLN_CARRY_QUE_PALLET()
        Try
            Dim strSQL As String        'SQL��
            Dim strMsg As String        'ү����
            Dim intRetSQL As Integer    'SQL���s�߂�l

            '***********************
            '�����è����
            '***********************
            If mFPALLET_ID = DEFAULT_STRING Then
                strMsg = ERRMSG_ERR_PROPERTY & "[��گ�ID]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '�폜SQL�쐬
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "DELETE"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TPLN_CARRY_QUE"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FPALLET_ID = '" & TO_STRING(mFPALLET_ID) & "'"
            strSQL &= vbCrLf


            '***********************
            '�폜
            '***********************
            intRetSQL = ObjDb.Execute(strSQL)
            If intRetSQL = -1 Then
                '(SQL�װ)
                strSQL = Replace(strSQL, vbCrLf, "")
                strMsg = ERRMSG_ERR_DELETE & ObjDb.ErrMsg & "�y" & strSQL & "�z"
                Throw New UserException(strMsg)
            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
#Region "  �����w��QUE�w�������擾  [�ݔ�ID]    (Public  GET_TPLN_CARRY_QUE_SEND_COUNT_BY_EQ_ID)"
    Public Function GET_TPLN_CARRY_QUE_SEND_COUNT_BY_EQ_ID() As RetCode
        Try
            Dim strSQL As String            'SQL��
            Dim strMsg As String            'ү����
            Dim objDataSet As New DataSet   '�ް����
            Dim strDataSetName As String    '�ް���Ė�
            Dim objRow As DataRow           '1ں��ޕ����ް�

            '***********************
            '�����è����
            '***********************
            If mFEQ_ID = DEFAULT_STRING Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�ݔ�ID]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '���oSQL�쐬
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    COUNT(*) AS CNT"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TPLN_CARRY_QUE"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FEQ_ID = '" & TO_STRING(mFEQ_ID) & "'"                          '�ݔ�ID
            strSQL &= vbCrLf & "    AND FCARRYQUE_DIR_STS = '" & TO_STRING(FCARRYQUE_DIR_STS_SEND) & "'" '�����w���� = �w����
            strSQL &= vbCrLf


            '***********************
            '���o
            '***********************
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TPLN_CARRY_QUE"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                objRow = objDataSet.Tables(strDataSetName).Rows(0)
                Return (TO_INTEGER(objRow("CNT")))
            Else
                Return (0)
            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "  �����w��QUE���Ɏw�������擾 [�ݔ�ID] (Public  GET_TPLN_CARRY_QUE_SEND_COUNT_IN)"
    Public Function GET_TPLN_CARRY_QUE_SEND_COUNT_IN() As RetCode
        Try
            Dim strSQL As String            'SQL��
            Dim strMsg As String            'ү����
            Dim objDataSet As New DataSet   '�ް����
            Dim strDataSetName As String    '�ް���Ė�
            Dim objRow As DataRow           '1ں��ޕ����ް�

            '***********************
            '�����è����
            '***********************
            If mFEQ_ID = DEFAULT_STRING Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�ݔ�ID]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '���oSQL�쐬
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    COUNT(*) AS CNT"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TPLN_CARRY_QUE"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FEQ_ID = '" & TO_STRING(mFEQ_ID) & "'"                          '�ݔ�ID
            strSQL &= vbCrLf & "    AND FCARRYQUE_DIR_STS = " & TO_STRING(FCARRYQUE_DIR_STS_SEND)        '�����w���� = �w����
            strSQL &= vbCrLf & "    AND FCARRYQUE_KUBUN = " & TO_STRING(FCARRYQUE_KUBUN_SIN)             '�w���敪 = ����
            strSQL &= vbCrLf


            '***********************
            '���o
            '***********************
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TPLN_CARRY_QUE"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                objRow = objDataSet.Tables(strDataSetName).Rows(0)
                Return (TO_INTEGER(objRow("CNT")))
            Else
                Return (0)
            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "  �����w��QUE�o�Ɏw�������擾 [�ݔ�ID] (Public  GET_TPLN_CARRY_QUE_SEND_COUNT_OUT)"
    Public Function GET_TPLN_CARRY_QUE_SEND_COUNT_OUT() As RetCode
        Try
            Dim strSQL As String            'SQL��
            Dim strMsg As String            'ү����
            Dim objDataSet As New DataSet   '�ް����
            Dim strDataSetName As String    '�ް���Ė�
            Dim objRow As DataRow           '1ں��ޕ����ް�

            '***********************
            '�����è����
            '***********************
            If mFEQ_ID = DEFAULT_STRING Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�ݔ�ID]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '���oSQL�쐬
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    COUNT(*) AS CNT"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TPLN_CARRY_QUE"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FEQ_ID = '" & TO_STRING(mFEQ_ID) & "'"                          '�ݔ�ID
            strSQL &= vbCrLf & "    AND FCARRYQUE_DIR_STS = " & TO_STRING(FCARRYQUE_DIR_STS_SEND)        '�����w���� = �w����
            strSQL &= vbCrLf & "    AND FCARRYQUE_KUBUN = " & TO_STRING(FCARRYQUE_KUBUN_SOUT)            '�w���敪 = �o��
            strSQL &= vbCrLf


            '***********************
            '���o
            '***********************
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TPLN_CARRY_QUE"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                objRow = objDataSet.Tables(strDataSetName).Rows(0)
                Return (TO_INTEGER(objRow("CNT")))
            Else
                Return (0)
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

#Region "  �׽�ϐ���`                  "
    Private mFTR_TO As String                       '����TO�ׯ�ݸ��ޯ̧��
#End Region
#Region "  �����è��`                  "
    ''' <summary>
    ''' ����TO�ׯ�ݸ��ޯ̧��
    ''' </summary>
    Public Property FTR_TO() As String
        Get
            Return mFTR_TO
        End Get
        Set(ByVal Value As String)
            mFTR_TO = Value
        End Set
    End Property
#End Region
#Region "  �����w��QUE�o�Ɏw���擾 [�ݔ�ID][����TO�ׯ�ݸ��ޯ̧��]                       "
    '''**********************************************************************************************
    ''' <summary>
    ''' �����w��QUE�o�Ɏw���擾 [�ݔ�ID][����TO�ׯ�ݸ��ޯ̧��]
    ''' </summary>
    ''' <param name="intWhereMode">WHERE��ŁA�uIN�v�uNOT IN�v�̂ǂ��炩�ɂ��锻��</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function GET_TPLN_CARRY_QUE_SEND_OUT_FTR_TO(ByVal intWhereMode As WhereMode) As RetCode
        Try
            Dim strSQL As String            'SQL��
            Dim strMsg As String            'ү����
            'Dim objDataSet As New DataSet   '�ް����
            'Dim strDataSetName As String    '�ް���Ė�
            'Dim objRow As DataRow           '1ں��ޕ����ް�
            Dim intRet As RetCode           '�߂�l


            '***********************
            '�����è����
            '***********************
            If mFEQ_ID = DEFAULT_STRING Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�ݔ�ID]"
                Throw New UserException(strMsg)
            ElseIf mFTR_TO = DEFAULT_STRING Then
                strMsg = ERRMSG_ERR_PROPERTY & "[����TO�ׯ�ݸ��ޯ̧��]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '���oSQL�쐬
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    TPLN_CARRY_QUE.FCARRYQUE_D "
            strSQL &= vbCrLf & "   ,TPLN_CARRY_QUE.FCARRYQUE_ORDER "
            strSQL &= vbCrLf & "   ,TPLN_CARRY_QUE.FEQ_ID "
            strSQL &= vbCrLf & "   ,TPLN_CARRY_QUE.FPRIORITY "
            strSQL &= vbCrLf & "   ,TPLN_CARRY_QUE.FPALLET_ID "
            strSQL &= vbCrLf & "   ,TPLN_CARRY_QUE.FCARRYQUE_KUBUN "
            strSQL &= vbCrLf & "   ,TPLN_CARRY_QUE.FCARRYQUE_DIR_STS "
            strSQL &= vbCrLf & "   ,TPLN_CARRY_QUE.FENTRY_DT "
            strSQL &= vbCrLf & "   ,TPLN_CARRY_QUE.FUPDATE_DT "
            '������������************************************************************************************************************
            'JobMate:N.Dounoshita 2013/04/03  �߱�����Ή�
            strSQL &= vbCrLf & "   ,TPLN_CARRY_QUE.XOYAKO_KUBUN "
            strSQL &= vbCrLf & "   ,TPLN_CARRY_QUE.XPALLET_ID_AITE "
            '������������************************************************************************************************************
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TPLN_CARRY_QUE"
            strSQL &= vbCrLf & "   ,TPRG_TRK_BUF"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "    1 = 1"
            strSQL &= vbCrLf & "    AND TPLN_CARRY_QUE.FPALLET_ID = TPRG_TRK_BUF.FPALLET_ID"                    '�ׯ�ݸ��ޯ̧�ƌ���
            strSQL &= vbCrLf & "    AND TPLN_CARRY_QUE.FCARRYQUE_DIR_STS = " & FCARRYQUE_DIR_STS_SNON & ""      '�����w��QUE    .�����w����
            strSQL &= vbCrLf & "    AND TPLN_CARRY_QUE.FCARRYQUE_KUBUN IN (" & FCARRYQUE_KUBUN_SOUT & ")"       '�����w��QUE    .�w���敪
            strSQL &= vbCrLf & "    AND TPLN_CARRY_QUE.FEQ_ID = '" & mFEQ_ID & "'"                              '�����w��QUE    .�ݔ�ID
            If intWhereMode = WhereMode.IN_Mode Then
                strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FTR_TO IN(" & mFTR_TO & ")"                                  '�����w��QUE    .�ݔ�ID
            Else
                strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FTR_TO NOT IN(" & mFTR_TO & ")"                                  '�����w��QUE    .�ݔ�ID
            End If
            strSQL &= vbCrLf & " ORDER BY"
            strSQL &= vbCrLf & "    TPLN_CARRY_QUE.FPRIORITY DESC"                  '�����w��QUE  .��ײ��è�敪
            strSQL &= vbCrLf & "   ,TPLN_CARRY_QUE.FCARRYQUE_D "                    '�����w��QUE  .�����w����
            strSQL &= vbCrLf & "   ,TPLN_CARRY_QUE.FCARRYQUE_ORDER "                '�����w��QUE  .��������
            strSQL &= vbCrLf


            '***********************
            '���o
            '***********************
            mstrUSER_SQL = strSQL
            intRet = GET_TPLN_CARRY_QUE_USER()


            Return (intRet)
        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
    '���������ьŗL
    '**********************************************************************************************

End Class
