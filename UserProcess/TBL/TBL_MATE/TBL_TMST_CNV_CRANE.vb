'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' �y���́zMaterialStreamð��ٸ׽
' �y�@�\�z���ޱ�ڰ�Ͻ�ð��ٸ׽
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
''' ���ޱ�ڰ�Ͻ�ð��ٸ׽
''' </summary>
Public Class TBL_TMST_CNV_CRANE
    Inherits clsTemplateTable

    '**********************************************************************************************
    '����������������
#Region "  �׽�ϐ���`                  "
    '�����è
    Private mobjAryMe As TBL_TMST_CNV_CRANE()                                    '���ޱ�ڰ�Ͻ�
    Private mstrUSER_SQL As String                                               'հ�ްSQL
    Private mORDER_BY As String                                                  'OrderBy��
    Private mWHERE As String                                                     'Where��
    Private mFEQ_ID_CRANE As String                                              '�ڰݐݔ�ID
    Private mFINOUT_KUBUN As Nullable(Of Integer)                                '���o�ɋ敪
    Private mFEQ_ID_CNV As String                                                '���ޱ�ݔ�ID
    Private mFEQ_CUT_STS As Nullable(Of Integer)                                 '�ؗ����
#End Region
#Region "  �����è��`                  "
    ''' <summary>
    ''' ���ѕϐ� (���׽�^�z��)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_TMST_CNV_CRANE()
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
    ''' �ڰݐݔ�ID
    ''' </summary>
    Public Property FEQ_ID_CRANE() As String
        Get
            Return mFEQ_ID_CRANE
        End Get
        Set(ByVal Value As String)
            mFEQ_ID_CRANE = Value
        End Set
    End Property
    ''' <summary>
    ''' ���o�ɋ敪
    ''' </summary>
    Public Property FINOUT_KUBUN() As Nullable(Of Integer)
        Get
            Return mFINOUT_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFINOUT_KUBUN = Value
        End Set
    End Property
    ''' <summary>
    ''' ���ޱ�ݔ�ID
    ''' </summary>
    Public Property FEQ_ID_CNV() As String
        Get
            Return mFEQ_ID_CNV
        End Get
        Set(ByVal Value As String)
            mFEQ_ID_CNV = Value
        End Set
    End Property
    ''' <summary>
    ''' �ؗ����
    ''' </summary>
    Public Property FEQ_CUT_STS() As Nullable(Of Integer)
        Get
            Return mFEQ_CUT_STS
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFEQ_CUT_STS = Value
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
    Public Function GET_TMST_CNV_CRANE(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    TMST_CNV_CRANE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FEQ_ID_CRANE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID_CRANE
            strSQL.Append(vbCrLf & "    AND FEQ_ID_CRANE = :" & UBound(strBindField) - 1 & " --�ڰݐݔ�ID")
        End If
        If IsNull(FINOUT_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINOUT_KUBUN
            strSQL.Append(vbCrLf & "    AND FINOUT_KUBUN = :" & UBound(strBindField) - 1 & " --���o�ɋ敪")
        End If
        If IsNull(FEQ_ID_CNV) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID_CNV
            strSQL.Append(vbCrLf & "    AND FEQ_ID_CNV = :" & UBound(strBindField) - 1 & " --���ޱ�ݔ�ID")
        End If
        If IsNull(FEQ_CUT_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_CUT_STS
            strSQL.Append(vbCrLf & "    AND FEQ_CUT_STS = :" & UBound(strBindField) - 1 & " --�ؗ����")
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
        strDataSetName = "TMST_CNV_CRANE"
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
    Public Function GET_TMST_CNV_CRANE_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    TMST_CNV_CRANE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FEQ_ID_CRANE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID_CRANE
            strSQL.Append(vbCrLf & "    AND FEQ_ID_CRANE = :" & UBound(strBindField) - 1 & " --�ڰݐݔ�ID")
        End If
        If IsNull(FINOUT_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINOUT_KUBUN
            strSQL.Append(vbCrLf & "    AND FINOUT_KUBUN = :" & UBound(strBindField) - 1 & " --���o�ɋ敪")
        End If
        If IsNull(FEQ_ID_CNV) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID_CNV
            strSQL.Append(vbCrLf & "    AND FEQ_ID_CNV = :" & UBound(strBindField) - 1 & " --���ޱ�ݔ�ID")
        End If
        If IsNull(FEQ_CUT_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_CUT_STS
            strSQL.Append(vbCrLf & "    AND FEQ_CUT_STS = :" & UBound(strBindField) - 1 & " --�ؗ����")
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
        strDataSetName = "TMST_CNV_CRANE"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TMST_CNV_CRANE(Owner, objDb, objDbLog)
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
    Public Function GET_TMST_CNV_CRANE_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "TMST_CNV_CRANE"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TMST_CNV_CRANE(Owner, objDb, objDbLog)
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
    Public Function GET_TMST_CNV_CRANE_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    TMST_CNV_CRANE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FEQ_ID_CRANE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID_CRANE
            strSQL.Append(vbCrLf & "    AND FEQ_ID_CRANE = :" & UBound(strBindField) - 1 & " --�ڰݐݔ�ID")
        End If
        If IsNull(FINOUT_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINOUT_KUBUN
            strSQL.Append(vbCrLf & "    AND FINOUT_KUBUN = :" & UBound(strBindField) - 1 & " --���o�ɋ敪")
        End If
        If IsNull(FEQ_ID_CNV) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID_CNV
            strSQL.Append(vbCrLf & "    AND FEQ_ID_CNV = :" & UBound(strBindField) - 1 & " --���ޱ�ݔ�ID")
        End If
        If IsNull(FEQ_CUT_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_CUT_STS
            strSQL.Append(vbCrLf & "    AND FEQ_CUT_STS = :" & UBound(strBindField) - 1 & " --�ؗ����")
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
        strDataSetName = "TMST_CNV_CRANE"
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
    Public Sub UPDATE_TMST_CNV_CRANE()
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
        End If


        '***********************
        '�X�VSQL�쐬
        '***********************
        strBindField = Nothing
        objBindValue = Nothing
        ReDim Preserve strBindField(0)
        ReDim Preserve objBindValue(0)
        strSQL.Append(vbCrLf & "UPDATE")
        strSQL.Append(vbCrLf & "    TMST_CNV_CRANE")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
        If IsNull(mFEQ_ID_CRANE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_ID_CRANE = NULL --�ڰݐݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_ID_CRANE = NULL --�ڰݐݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID_CRANE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_ID_CRANE = :" & Ubound(strBindField) - 1 & " --�ڰݐݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_ID_CRANE = :" & Ubound(strBindField) - 1 & " --�ڰݐݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mFINOUT_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FINOUT_KUBUN = NULL --���o�ɋ敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FINOUT_KUBUN = NULL --���o�ɋ敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINOUT_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FINOUT_KUBUN = :" & Ubound(strBindField) - 1 & " --���o�ɋ敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FINOUT_KUBUN = :" & Ubound(strBindField) - 1 & " --���o�ɋ敪")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_ID_CNV) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_ID_CNV = NULL --���ޱ�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_ID_CNV = NULL --���ޱ�ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID_CNV
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_ID_CNV = :" & Ubound(strBindField) - 1 & " --���ޱ�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_ID_CNV = :" & Ubound(strBindField) - 1 & " --���ޱ�ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_CUT_STS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_CUT_STS = NULL --�ؗ����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_CUT_STS = NULL --�ؗ����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_CUT_STS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_CUT_STS = :" & Ubound(strBindField) - 1 & " --�ؗ����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_CUT_STS = :" & Ubound(strBindField) - 1 & " --�ؗ����")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FEQ_ID_CRANE) = True Then
            strSQL.Append(vbCrLf & "    AND FEQ_ID_CRANE IS NULL --�ڰݐݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID_CRANE
            strSQL.Append(vbCrLf & "    AND FEQ_ID_CRANE = :" & UBound(strBindField) - 1 & " --�ڰݐݔ�ID")
        End If
        If IsNull(FINOUT_KUBUN) = True Then
            strSQL.Append(vbCrLf & "    AND FINOUT_KUBUN IS NULL --���o�ɋ敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINOUT_KUBUN
            strSQL.Append(vbCrLf & "    AND FINOUT_KUBUN = :" & UBound(strBindField) - 1 & " --���o�ɋ敪")
        End If
        If IsNull(FEQ_ID_CNV) = True Then
            strSQL.Append(vbCrLf & "    AND FEQ_ID_CNV IS NULL --���ޱ�ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID_CNV
            strSQL.Append(vbCrLf & "    AND FEQ_ID_CNV = :" & UBound(strBindField) - 1 & " --���ޱ�ݔ�ID")
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
    Public Sub ADD_TMST_CNV_CRANE()
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
        End If


        '***********************
        '�ǉ�SQL�쐬
        '***********************
        strBindField = Nothing
        objBindValue = Nothing
        ReDim Preserve strBindField(0)
        ReDim Preserve objBindValue(0)
        strSQL.Append(vbCrLf & "INSERT INTO")
        strSQL.Append(vbCrLf & "    TMST_CNV_CRANE")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
        If IsNull(mFEQ_ID_CRANE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ڰݐݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ڰݐݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID_CRANE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ڰݐݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ڰݐݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mFINOUT_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���o�ɋ敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���o�ɋ敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINOUT_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���o�ɋ敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���o�ɋ敪")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_ID_CNV) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���ޱ�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���ޱ�ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID_CNV
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���ޱ�ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���ޱ�ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_CUT_STS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ؗ����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ؗ����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_CUT_STS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ؗ����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ؗ����")
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
    Public Sub DELETE_TMST_CNV_CRANE()
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
        ElseIf IsNull(mFEQ_ID_CRANE) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�ڰݐݔ�ID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFINOUT_KUBUN) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[���o�ɋ敪]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFEQ_ID_CNV) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[���ޱ�ݔ�ID]"
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
        strSQL.Append(vbCrLf & "    TMST_CNV_CRANE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FEQ_ID_CRANE) = True Then
            strSQL.Append(vbCrLf & "    AND FEQ_ID_CRANE IS NULL --�ڰݐݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID_CRANE
            strSQL.Append(vbCrLf & "    AND FEQ_ID_CRANE = :" & UBound(strBindField) - 1 & " --�ڰݐݔ�ID")
        End If
        If IsNull(FINOUT_KUBUN) = True Then
            strSQL.Append(vbCrLf & "    AND FINOUT_KUBUN IS NULL --���o�ɋ敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINOUT_KUBUN
            strSQL.Append(vbCrLf & "    AND FINOUT_KUBUN = :" & UBound(strBindField) - 1 & " --���o�ɋ敪")
        End If
        If IsNull(FEQ_ID_CNV) = True Then
            strSQL.Append(vbCrLf & "    AND FEQ_ID_CNV IS NULL --���ޱ�ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID_CNV
            strSQL.Append(vbCrLf & "    AND FEQ_ID_CNV = :" & UBound(strBindField) - 1 & " --���ޱ�ݔ�ID")
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
    Public Sub DELETE_TMST_CNV_CRANE_ANY()
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
        strSQL.Append(vbCrLf & "    TMST_CNV_CRANE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(FEQ_ID_CRANE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID_CRANE
            strSQL.Append(vbCrLf & "    AND FEQ_ID_CRANE = :" & UBound(strBindField) - 1 & " --�ڰݐݔ�ID")
        End If
        If IsNotNull(FINOUT_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINOUT_KUBUN
            strSQL.Append(vbCrLf & "    AND FINOUT_KUBUN = :" & UBound(strBindField) - 1 & " --���o�ɋ敪")
        End If
        If IsNotNull(FEQ_ID_CNV) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID_CNV
            strSQL.Append(vbCrLf & "    AND FEQ_ID_CNV = :" & UBound(strBindField) - 1 & " --���ޱ�ݔ�ID")
        End If
        If IsNotNull(FEQ_CUT_STS) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_CUT_STS
            strSQL.Append(vbCrLf & "    AND FEQ_CUT_STS = :" & UBound(strBindField) - 1 & " --�ؗ����")
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
        If IsNothing(objType.GetProperty("FEQ_ID_CRANE")) = False Then mFEQ_ID_CRANE = objObject.FEQ_ID_CRANE '�ڰݐݔ�ID
        If IsNothing(objType.GetProperty("FINOUT_KUBUN")) = False Then mFINOUT_KUBUN = objObject.FINOUT_KUBUN '���o�ɋ敪
        If IsNothing(objType.GetProperty("FEQ_ID_CNV")) = False Then mFEQ_ID_CNV = objObject.FEQ_ID_CNV '���ޱ�ݔ�ID
        If IsNothing(objType.GetProperty("FEQ_CUT_STS")) = False Then mFEQ_CUT_STS = objObject.FEQ_CUT_STS '�ؗ����

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
        mFEQ_ID_CRANE = Nothing
        mFINOUT_KUBUN = Nothing
        mFEQ_ID_CNV = Nothing
        mFEQ_CUT_STS = Nothing


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
        mFEQ_ID_CRANE = TO_STRING_NULLABLE(objRow("FEQ_ID_CRANE"))
        mFINOUT_KUBUN = TO_INTEGER_NULLABLE(objRow("FINOUT_KUBUN"))
        mFEQ_ID_CNV = TO_STRING_NULLABLE(objRow("FEQ_ID_CNV"))
        mFEQ_CUT_STS = TO_INTEGER_NULLABLE(objRow("FEQ_CUT_STS"))


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
        strMsg &= "[ð��ٖ�:���ޱ�ڰ�Ͻ�]"
        If IsNotNull(FEQ_ID_CRANE) Then
            strMsg &= "[�ڰݐݔ�ID:" & FEQ_ID_CRANE & "]"
        End If
        If IsNotNull(FINOUT_KUBUN) Then
            strMsg &= "[���o�ɋ敪:" & FINOUT_KUBUN & "]"
        End If
        If IsNotNull(FEQ_ID_CNV) Then
            strMsg &= "[���ޱ�ݔ�ID:" & FEQ_ID_CNV & "]"
        End If
        If IsNotNull(FEQ_CUT_STS) Then
            strMsg &= "[�ؗ����:" & FEQ_CUT_STS & "]"
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
