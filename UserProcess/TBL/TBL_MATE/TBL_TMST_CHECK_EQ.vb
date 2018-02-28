'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' �y���́zMaterialStreamð��ٸ׽
' �y�@�\�z�����N������Ͻ�ð��ٸ׽
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
''' �����N������Ͻ�ð��ٸ׽
''' </summary>
Public Class TBL_TMST_CHECK_EQ
    Inherits clsTemplateTable

    '**********************************************************************************************
    '����������������
#Region "  �׽�ϐ���`                  "
    '�����è
    Private mobjAryMe As TBL_TMST_CHECK_EQ()                                     '�����N������Ͻ�
    Private mstrUSER_SQL As String                                               'հ�ްSQL
    Private mORDER_BY As String                                                  'OrderBy��
    Private mWHERE As String                                                     'Where��
    Private mFBUF_FM As Nullable(Of Integer)                                     '�������ׯ�ݸ��ޯ̧��
    Private mFEQ_ID_CRANE_FM As String                                           '���ڰݐݔ�ID
    Private mFBUF_TO As Nullable(Of Integer)                                     '�������ׯ�ݸ��ޯ̧��
    Private mFEQ_ID_CRANE_TO As String                                           '��ڰݐݔ�ID
    Private mFCHECK_EQ_ID As String                                              '����ݔ�ID
    Private mFCHECK_EQ_INDEX As Nullable(Of Integer)                             '����ݔ����ޯ��
    Private mFEQ_STS As String                                                   '�ݔ����
    Private mFEQ_REQ_STS As Nullable(Of Integer)                                 '�v�����
    Private mFEQ_CUT_STS As Nullable(Of Integer)                                 '�ؗ����
#End Region
#Region "  �����è��`                  "
    ''' <summary>
    ''' ���ѕϐ� (���׽�^�z��)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_TMST_CHECK_EQ()
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
    ''' �������ׯ�ݸ��ޯ̧��
    ''' </summary>
    Public Property FBUF_FM() As Nullable(Of Integer)
        Get
            Return mFBUF_FM
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFBUF_FM = Value
        End Set
    End Property
    ''' <summary>
    ''' ���ڰݐݔ�ID
    ''' </summary>
    Public Property FEQ_ID_CRANE_FM() As String
        Get
            Return mFEQ_ID_CRANE_FM
        End Get
        Set(ByVal Value As String)
            mFEQ_ID_CRANE_FM = Value
        End Set
    End Property
    ''' <summary>
    ''' �������ׯ�ݸ��ޯ̧��
    ''' </summary>
    Public Property FBUF_TO() As Nullable(Of Integer)
        Get
            Return mFBUF_TO
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFBUF_TO = Value
        End Set
    End Property
    ''' <summary>
    ''' ��ڰݐݔ�ID
    ''' </summary>
    Public Property FEQ_ID_CRANE_TO() As String
        Get
            Return mFEQ_ID_CRANE_TO
        End Get
        Set(ByVal Value As String)
            mFEQ_ID_CRANE_TO = Value
        End Set
    End Property
    ''' <summary>
    ''' ����ݔ�ID
    ''' </summary>
    Public Property FCHECK_EQ_ID() As String
        Get
            Return mFCHECK_EQ_ID
        End Get
        Set(ByVal Value As String)
            mFCHECK_EQ_ID = Value
        End Set
    End Property
    ''' <summary>
    ''' ����ݔ����ޯ��
    ''' </summary>
    Public Property FCHECK_EQ_INDEX() As Nullable(Of Integer)
        Get
            Return mFCHECK_EQ_INDEX
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFCHECK_EQ_INDEX = Value
        End Set
    End Property
    ''' <summary>
    ''' �ݔ����
    ''' </summary>
    Public Property FEQ_STS() As String
        Get
            Return mFEQ_STS
        End Get
        Set(ByVal Value As String)
            mFEQ_STS = Value
        End Set
    End Property
    ''' <summary>
    ''' �v�����
    ''' </summary>
    Public Property FEQ_REQ_STS() As Nullable(Of Integer)
        Get
            Return mFEQ_REQ_STS
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFEQ_REQ_STS = Value
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
    Public Function GET_TMST_CHECK_EQ(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    TMST_CHECK_EQ")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FBUF_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_FM
            strSQL.Append(vbCrLf & "    AND FBUF_FM = :" & UBound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FEQ_ID_CRANE_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID_CRANE_FM
            strSQL.Append(vbCrLf & "    AND FEQ_ID_CRANE_FM = :" & UBound(strBindField) - 1 & " --���ڰݐݔ�ID")
        End If
        If IsNull(FBUF_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_TO
            strSQL.Append(vbCrLf & "    AND FBUF_TO = :" & UBound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FEQ_ID_CRANE_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID_CRANE_TO
            strSQL.Append(vbCrLf & "    AND FEQ_ID_CRANE_TO = :" & UBound(strBindField) - 1 & " --��ڰݐݔ�ID")
        End If
        If IsNull(FCHECK_EQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCHECK_EQ_ID
            strSQL.Append(vbCrLf & "    AND FCHECK_EQ_ID = :" & UBound(strBindField) - 1 & " --����ݔ�ID")
        End If
        If IsNull(FCHECK_EQ_INDEX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCHECK_EQ_INDEX
            strSQL.Append(vbCrLf & "    AND FCHECK_EQ_INDEX = :" & UBound(strBindField) - 1 & " --����ݔ����ޯ��")
        End If
        If IsNull(FEQ_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STS
            strSQL.Append(vbCrLf & "    AND FEQ_STS = :" & UBound(strBindField) - 1 & " --�ݔ����")
        End If
        If IsNull(FEQ_REQ_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_REQ_STS
            strSQL.Append(vbCrLf & "    AND FEQ_REQ_STS = :" & UBound(strBindField) - 1 & " --�v�����")
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
        strDataSetName = "TMST_CHECK_EQ"
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
    Public Function GET_TMST_CHECK_EQ_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    TMST_CHECK_EQ")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FBUF_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_FM
            strSQL.Append(vbCrLf & "    AND FBUF_FM = :" & UBound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FEQ_ID_CRANE_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID_CRANE_FM
            strSQL.Append(vbCrLf & "    AND FEQ_ID_CRANE_FM = :" & UBound(strBindField) - 1 & " --���ڰݐݔ�ID")
        End If
        If IsNull(FBUF_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_TO
            strSQL.Append(vbCrLf & "    AND FBUF_TO = :" & UBound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FEQ_ID_CRANE_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID_CRANE_TO
            strSQL.Append(vbCrLf & "    AND FEQ_ID_CRANE_TO = :" & UBound(strBindField) - 1 & " --��ڰݐݔ�ID")
        End If
        If IsNull(FCHECK_EQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCHECK_EQ_ID
            strSQL.Append(vbCrLf & "    AND FCHECK_EQ_ID = :" & UBound(strBindField) - 1 & " --����ݔ�ID")
        End If
        If IsNull(FCHECK_EQ_INDEX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCHECK_EQ_INDEX
            strSQL.Append(vbCrLf & "    AND FCHECK_EQ_INDEX = :" & UBound(strBindField) - 1 & " --����ݔ����ޯ��")
        End If
        If IsNull(FEQ_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STS
            strSQL.Append(vbCrLf & "    AND FEQ_STS = :" & UBound(strBindField) - 1 & " --�ݔ����")
        End If
        If IsNull(FEQ_REQ_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_REQ_STS
            strSQL.Append(vbCrLf & "    AND FEQ_REQ_STS = :" & UBound(strBindField) - 1 & " --�v�����")
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
        strDataSetName = "TMST_CHECK_EQ"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TMST_CHECK_EQ(Owner, objDb, objDbLog)
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
    Public Function GET_TMST_CHECK_EQ_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "TMST_CHECK_EQ"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TMST_CHECK_EQ(Owner, objDb, objDbLog)
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
    Public Function GET_TMST_CHECK_EQ_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    TMST_CHECK_EQ")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FBUF_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_FM
            strSQL.Append(vbCrLf & "    AND FBUF_FM = :" & UBound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FEQ_ID_CRANE_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID_CRANE_FM
            strSQL.Append(vbCrLf & "    AND FEQ_ID_CRANE_FM = :" & UBound(strBindField) - 1 & " --���ڰݐݔ�ID")
        End If
        If IsNull(FBUF_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_TO
            strSQL.Append(vbCrLf & "    AND FBUF_TO = :" & UBound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FEQ_ID_CRANE_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID_CRANE_TO
            strSQL.Append(vbCrLf & "    AND FEQ_ID_CRANE_TO = :" & UBound(strBindField) - 1 & " --��ڰݐݔ�ID")
        End If
        If IsNull(FCHECK_EQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCHECK_EQ_ID
            strSQL.Append(vbCrLf & "    AND FCHECK_EQ_ID = :" & UBound(strBindField) - 1 & " --����ݔ�ID")
        End If
        If IsNull(FCHECK_EQ_INDEX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCHECK_EQ_INDEX
            strSQL.Append(vbCrLf & "    AND FCHECK_EQ_INDEX = :" & UBound(strBindField) - 1 & " --����ݔ����ޯ��")
        End If
        If IsNull(FEQ_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STS
            strSQL.Append(vbCrLf & "    AND FEQ_STS = :" & UBound(strBindField) - 1 & " --�ݔ����")
        End If
        If IsNull(FEQ_REQ_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_REQ_STS
            strSQL.Append(vbCrLf & "    AND FEQ_REQ_STS = :" & UBound(strBindField) - 1 & " --�v�����")
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
        strDataSetName = "TMST_CHECK_EQ"
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
    Public Sub UPDATE_TMST_CHECK_EQ()
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
        ElseIf IsNull(mFBUF_FM) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�������ׯ�ݸ��ޯ̧��]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFEQ_ID_CRANE_FM) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[���ڰݐݔ�ID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFBUF_TO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�������ׯ�ݸ��ޯ̧��]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFEQ_ID_CRANE_TO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[��ڰݐݔ�ID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFCHECK_EQ_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[����ݔ�ID]"
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
        strSQL.Append(vbCrLf & "    TMST_CHECK_EQ")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
        If IsNull(mFBUF_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FBUF_FM = NULL --�������ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FBUF_FM = NULL --�������ׯ�ݸ��ޯ̧��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FBUF_FM = :" & Ubound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FBUF_FM = :" & Ubound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧��")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_ID_CRANE_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_ID_CRANE_FM = NULL --���ڰݐݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_ID_CRANE_FM = NULL --���ڰݐݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID_CRANE_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_ID_CRANE_FM = :" & Ubound(strBindField) - 1 & " --���ڰݐݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_ID_CRANE_FM = :" & Ubound(strBindField) - 1 & " --���ڰݐݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mFBUF_TO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FBUF_TO = NULL --�������ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FBUF_TO = NULL --�������ׯ�ݸ��ޯ̧��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_TO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FBUF_TO = :" & Ubound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FBUF_TO = :" & Ubound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧��")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_ID_CRANE_TO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_ID_CRANE_TO = NULL --��ڰݐݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_ID_CRANE_TO = NULL --��ڰݐݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID_CRANE_TO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_ID_CRANE_TO = :" & Ubound(strBindField) - 1 & " --��ڰݐݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_ID_CRANE_TO = :" & Ubound(strBindField) - 1 & " --��ڰݐݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mFCHECK_EQ_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCHECK_EQ_ID = NULL --����ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCHECK_EQ_ID = NULL --����ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCHECK_EQ_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCHECK_EQ_ID = :" & Ubound(strBindField) - 1 & " --����ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCHECK_EQ_ID = :" & Ubound(strBindField) - 1 & " --����ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mFCHECK_EQ_INDEX) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCHECK_EQ_INDEX = NULL --����ݔ����ޯ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCHECK_EQ_INDEX = NULL --����ݔ����ޯ��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCHECK_EQ_INDEX
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCHECK_EQ_INDEX = :" & Ubound(strBindField) - 1 & " --����ݔ����ޯ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCHECK_EQ_INDEX = :" & Ubound(strBindField) - 1 & " --����ݔ����ޯ��")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_STS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_STS = NULL --�ݔ����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_STS = NULL --�ݔ����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_STS = :" & Ubound(strBindField) - 1 & " --�ݔ����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_STS = :" & Ubound(strBindField) - 1 & " --�ݔ����")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_REQ_STS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_REQ_STS = NULL --�v�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_REQ_STS = NULL --�v�����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_REQ_STS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_REQ_STS = :" & Ubound(strBindField) - 1 & " --�v�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_REQ_STS = :" & Ubound(strBindField) - 1 & " --�v�����")
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
        If IsNull(FBUF_FM) = True Then
            strSQL.Append(vbCrLf & "    AND FBUF_FM IS NULL --�������ׯ�ݸ��ޯ̧��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_FM
            strSQL.Append(vbCrLf & "    AND FBUF_FM = :" & UBound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FEQ_ID_CRANE_FM) = True Then
            strSQL.Append(vbCrLf & "    AND FEQ_ID_CRANE_FM IS NULL --���ڰݐݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID_CRANE_FM
            strSQL.Append(vbCrLf & "    AND FEQ_ID_CRANE_FM = :" & UBound(strBindField) - 1 & " --���ڰݐݔ�ID")
        End If
        If IsNull(FBUF_TO) = True Then
            strSQL.Append(vbCrLf & "    AND FBUF_TO IS NULL --�������ׯ�ݸ��ޯ̧��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_TO
            strSQL.Append(vbCrLf & "    AND FBUF_TO = :" & UBound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FEQ_ID_CRANE_TO) = True Then
            strSQL.Append(vbCrLf & "    AND FEQ_ID_CRANE_TO IS NULL --��ڰݐݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID_CRANE_TO
            strSQL.Append(vbCrLf & "    AND FEQ_ID_CRANE_TO = :" & UBound(strBindField) - 1 & " --��ڰݐݔ�ID")
        End If
        If IsNull(FCHECK_EQ_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FCHECK_EQ_ID IS NULL --����ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCHECK_EQ_ID
            strSQL.Append(vbCrLf & "    AND FCHECK_EQ_ID = :" & UBound(strBindField) - 1 & " --����ݔ�ID")
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
    Public Sub ADD_TMST_CHECK_EQ()
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
        ElseIf IsNull(mFBUF_FM) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�������ׯ�ݸ��ޯ̧��]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFEQ_ID_CRANE_FM) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[���ڰݐݔ�ID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFBUF_TO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�������ׯ�ݸ��ޯ̧��]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFEQ_ID_CRANE_TO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[��ڰݐݔ�ID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFCHECK_EQ_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[����ݔ�ID]"
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
        strSQL.Append(vbCrLf & "    TMST_CHECK_EQ")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
        If IsNull(mFBUF_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�������ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�������ׯ�ݸ��ޯ̧��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧��")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_ID_CRANE_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���ڰݐݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���ڰݐݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID_CRANE_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���ڰݐݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���ڰݐݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mFBUF_TO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�������ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�������ׯ�ݸ��ޯ̧��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_TO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧��")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_ID_CRANE_TO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --��ڰݐݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --��ڰݐݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID_CRANE_TO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --��ڰݐݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --��ڰݐݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mFCHECK_EQ_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCHECK_EQ_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����ݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����ݔ�ID")
        End If
        intCount = intCount + 1
        If IsNull(mFCHECK_EQ_INDEX) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����ݔ����ޯ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����ݔ����ޯ��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCHECK_EQ_INDEX
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����ݔ����ޯ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����ݔ����ޯ��")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_STS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ݔ����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ݔ����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ݔ����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ݔ����")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_REQ_STS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�v�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�v�����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_REQ_STS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�v�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�v�����")
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
    Public Sub DELETE_TMST_CHECK_EQ()
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
        ElseIf IsNull(mFBUF_FM) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�������ׯ�ݸ��ޯ̧��]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFEQ_ID_CRANE_FM) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[���ڰݐݔ�ID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFBUF_TO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�������ׯ�ݸ��ޯ̧��]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFEQ_ID_CRANE_TO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[��ڰݐݔ�ID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFCHECK_EQ_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[����ݔ�ID]"
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
        strSQL.Append(vbCrLf & "    TMST_CHECK_EQ")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FBUF_FM) = True Then
            strSQL.Append(vbCrLf & "    AND FBUF_FM IS NULL --�������ׯ�ݸ��ޯ̧��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_FM
            strSQL.Append(vbCrLf & "    AND FBUF_FM = :" & UBound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FEQ_ID_CRANE_FM) = True Then
            strSQL.Append(vbCrLf & "    AND FEQ_ID_CRANE_FM IS NULL --���ڰݐݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID_CRANE_FM
            strSQL.Append(vbCrLf & "    AND FEQ_ID_CRANE_FM = :" & UBound(strBindField) - 1 & " --���ڰݐݔ�ID")
        End If
        If IsNull(FBUF_TO) = True Then
            strSQL.Append(vbCrLf & "    AND FBUF_TO IS NULL --�������ׯ�ݸ��ޯ̧��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_TO
            strSQL.Append(vbCrLf & "    AND FBUF_TO = :" & UBound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FEQ_ID_CRANE_TO) = True Then
            strSQL.Append(vbCrLf & "    AND FEQ_ID_CRANE_TO IS NULL --��ڰݐݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID_CRANE_TO
            strSQL.Append(vbCrLf & "    AND FEQ_ID_CRANE_TO = :" & UBound(strBindField) - 1 & " --��ڰݐݔ�ID")
        End If
        If IsNull(FCHECK_EQ_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FCHECK_EQ_ID IS NULL --����ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCHECK_EQ_ID
            strSQL.Append(vbCrLf & "    AND FCHECK_EQ_ID = :" & UBound(strBindField) - 1 & " --����ݔ�ID")
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
    Public Sub DELETE_TMST_CHECK_EQ_ANY()
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
        strSQL.Append(vbCrLf & "    TMST_CHECK_EQ")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(FBUF_FM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_FM
            strSQL.Append(vbCrLf & "    AND FBUF_FM = :" & UBound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧��")
        End If
        If IsNotNull(FEQ_ID_CRANE_FM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID_CRANE_FM
            strSQL.Append(vbCrLf & "    AND FEQ_ID_CRANE_FM = :" & UBound(strBindField) - 1 & " --���ڰݐݔ�ID")
        End If
        If IsNotNull(FBUF_TO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_TO
            strSQL.Append(vbCrLf & "    AND FBUF_TO = :" & UBound(strBindField) - 1 & " --�������ׯ�ݸ��ޯ̧��")
        End If
        If IsNotNull(FEQ_ID_CRANE_TO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID_CRANE_TO
            strSQL.Append(vbCrLf & "    AND FEQ_ID_CRANE_TO = :" & UBound(strBindField) - 1 & " --��ڰݐݔ�ID")
        End If
        If IsNotNull(FCHECK_EQ_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCHECK_EQ_ID
            strSQL.Append(vbCrLf & "    AND FCHECK_EQ_ID = :" & UBound(strBindField) - 1 & " --����ݔ�ID")
        End If
        If IsNotNull(FCHECK_EQ_INDEX) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCHECK_EQ_INDEX
            strSQL.Append(vbCrLf & "    AND FCHECK_EQ_INDEX = :" & UBound(strBindField) - 1 & " --����ݔ����ޯ��")
        End If
        If IsNotNull(FEQ_STS) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STS
            strSQL.Append(vbCrLf & "    AND FEQ_STS = :" & UBound(strBindField) - 1 & " --�ݔ����")
        End If
        If IsNotNull(FEQ_REQ_STS) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_REQ_STS
            strSQL.Append(vbCrLf & "    AND FEQ_REQ_STS = :" & UBound(strBindField) - 1 & " --�v�����")
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
        If IsNothing(objType.GetProperty("FBUF_FM")) = False Then mFBUF_FM = objObject.FBUF_FM '�������ׯ�ݸ��ޯ̧��
        If IsNothing(objType.GetProperty("FEQ_ID_CRANE_FM")) = False Then mFEQ_ID_CRANE_FM = objObject.FEQ_ID_CRANE_FM '���ڰݐݔ�ID
        If IsNothing(objType.GetProperty("FBUF_TO")) = False Then mFBUF_TO = objObject.FBUF_TO '�������ׯ�ݸ��ޯ̧��
        If IsNothing(objType.GetProperty("FEQ_ID_CRANE_TO")) = False Then mFEQ_ID_CRANE_TO = objObject.FEQ_ID_CRANE_TO '��ڰݐݔ�ID
        If IsNothing(objType.GetProperty("FCHECK_EQ_ID")) = False Then mFCHECK_EQ_ID = objObject.FCHECK_EQ_ID '����ݔ�ID
        If IsNothing(objType.GetProperty("FCHECK_EQ_INDEX")) = False Then mFCHECK_EQ_INDEX = objObject.FCHECK_EQ_INDEX '����ݔ����ޯ��
        If IsNothing(objType.GetProperty("FEQ_STS")) = False Then mFEQ_STS = objObject.FEQ_STS '�ݔ����
        If IsNothing(objType.GetProperty("FEQ_REQ_STS")) = False Then mFEQ_REQ_STS = objObject.FEQ_REQ_STS '�v�����
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
        mFBUF_FM = Nothing
        mFEQ_ID_CRANE_FM = Nothing
        mFBUF_TO = Nothing
        mFEQ_ID_CRANE_TO = Nothing
        mFCHECK_EQ_ID = Nothing
        mFCHECK_EQ_INDEX = Nothing
        mFEQ_STS = Nothing
        mFEQ_REQ_STS = Nothing
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
        mFBUF_FM = TO_INTEGER_NULLABLE(objRow("FBUF_FM"))
        mFEQ_ID_CRANE_FM = TO_STRING_NULLABLE(objRow("FEQ_ID_CRANE_FM"))
        mFBUF_TO = TO_INTEGER_NULLABLE(objRow("FBUF_TO"))
        mFEQ_ID_CRANE_TO = TO_STRING_NULLABLE(objRow("FEQ_ID_CRANE_TO"))
        mFCHECK_EQ_ID = TO_STRING_NULLABLE(objRow("FCHECK_EQ_ID"))
        mFCHECK_EQ_INDEX = TO_INTEGER_NULLABLE(objRow("FCHECK_EQ_INDEX"))
        mFEQ_STS = TO_STRING_NULLABLE(objRow("FEQ_STS"))
        mFEQ_REQ_STS = TO_INTEGER_NULLABLE(objRow("FEQ_REQ_STS"))
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
        strMsg &= "[ð��ٖ�:�����N������Ͻ�]"
        If IsNotNull(FBUF_FM) Then
            strMsg &= "[�������ׯ�ݸ��ޯ̧��:" & FBUF_FM & "]"
        End If
        If IsNotNull(FEQ_ID_CRANE_FM) Then
            strMsg &= "[���ڰݐݔ�ID:" & FEQ_ID_CRANE_FM & "]"
        End If
        If IsNotNull(FBUF_TO) Then
            strMsg &= "[�������ׯ�ݸ��ޯ̧��:" & FBUF_TO & "]"
        End If
        If IsNotNull(FEQ_ID_CRANE_TO) Then
            strMsg &= "[��ڰݐݔ�ID:" & FEQ_ID_CRANE_TO & "]"
        End If
        If IsNotNull(FCHECK_EQ_ID) Then
            strMsg &= "[����ݔ�ID:" & FCHECK_EQ_ID & "]"
        End If
        If IsNotNull(FCHECK_EQ_INDEX) Then
            strMsg &= "[����ݔ����ޯ��:" & FCHECK_EQ_INDEX & "]"
        End If
        If IsNotNull(FEQ_STS) Then
            strMsg &= "[�ݔ����:" & FEQ_STS & "]"
        End If
        If IsNotNull(FEQ_REQ_STS) Then
            strMsg &= "[�v�����:" & FEQ_REQ_STS & "]"
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
