'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' �y���́zMaterialStreamð��ٸ׽
' �y�@�\�z����ڥ������ޏ�ð��ٸ׽
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
''' ����ڥ������ޏ�ð��ٸ׽
''' </summary>
Public Class TBL_XSTS_DPL_PL
    Inherits clsTemplateTable

    '**********************************************************************************************
    '����������������
#Region "  �׽�ϐ���`                  "
    '�����è
    Private mobjAryMe As TBL_XSTS_DPL_PL()                                       '����ڥ������ޏ�
    Private mstrUSER_SQL As String                                               'հ�ްSQL
    Private mORDER_BY As String                                                  'OrderBy��
    Private mWHERE As String                                                     'Where��
    Private mXDPL_PL_NO As Nullable(Of Integer)                                  '����ڥ������ޔԍ�
    Private mFHINMEI_CD As String                                                '�i�ں���
    Private mXDPL_PL_PTN As Nullable(Of Integer)                                 '����ڥ������������
    Private mXDPL_PL_ONLINE As Nullable(Of Integer)                              '����ڥ������޵�ײݏ��
    Private mXDPL_PL_STS As Nullable(Of Integer)                                 '����ڥ������މ^�]���
    Private mXSTART_DT As Nullable(Of Date)                                      '�J�n����
    Private mXEND_DT As Nullable(Of Date)                                        '�I������
#End Region
#Region "  �����è��`                  "
    ''' <summary>
    ''' ���ѕϐ� (���׽�^�z��)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_XSTS_DPL_PL()
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
    ''' ����ڥ������������
    ''' </summary>
    Public Property XDPL_PL_PTN() As Nullable(Of Integer)
        Get
            Return mXDPL_PL_PTN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXDPL_PL_PTN = Value
        End Set
    End Property
    ''' <summary>
    ''' ����ڥ������޵�ײݏ��
    ''' </summary>
    Public Property XDPL_PL_ONLINE() As Nullable(Of Integer)
        Get
            Return mXDPL_PL_ONLINE
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXDPL_PL_ONLINE = Value
        End Set
    End Property
    ''' <summary>
    ''' ����ڥ������މ^�]���
    ''' </summary>
    Public Property XDPL_PL_STS() As Nullable(Of Integer)
        Get
            Return mXDPL_PL_STS
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXDPL_PL_STS = Value
        End Set
    End Property
    ''' <summary>
    ''' �J�n����
    ''' </summary>
    Public Property XSTART_DT() As Nullable(Of Date)
        Get
            Return mXSTART_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mXSTART_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' �I������
    ''' </summary>
    Public Property XEND_DT() As Nullable(Of Date)
        Get
            Return mXEND_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mXEND_DT = Value
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
    Public Function GET_XSTS_DPL_PL(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    XSTS_DPL_PL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XDPL_PL_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_NO
            strSQL.Append(vbCrLf & "    AND XDPL_PL_NO = :" & UBound(strBindField) - 1 & " --����ڥ������ޔԍ�")
        End If
        If IsNull(FHINMEI_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --�i�ں���")
        End If
        If IsNull(XDPL_PL_PTN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_PTN
            strSQL.Append(vbCrLf & "    AND XDPL_PL_PTN = :" & UBound(strBindField) - 1 & " --����ڥ������������")
        End If
        If IsNull(XDPL_PL_ONLINE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_ONLINE
            strSQL.Append(vbCrLf & "    AND XDPL_PL_ONLINE = :" & UBound(strBindField) - 1 & " --����ڥ������޵�ײݏ��")
        End If
        If IsNull(XDPL_PL_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_STS
            strSQL.Append(vbCrLf & "    AND XDPL_PL_STS = :" & UBound(strBindField) - 1 & " --����ڥ������މ^�]���")
        End If
        If IsNull(XSTART_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSTART_DT
            strSQL.Append(vbCrLf & "    AND XSTART_DT = :" & UBound(strBindField) - 1 & " --�J�n����")
        End If
        If IsNull(XEND_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEND_DT
            strSQL.Append(vbCrLf & "    AND XEND_DT = :" & UBound(strBindField) - 1 & " --�I������")
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
        strDataSetName = "XSTS_DPL_PL"
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
    Public Function GET_XSTS_DPL_PL_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    XSTS_DPL_PL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XDPL_PL_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_NO
            strSQL.Append(vbCrLf & "    AND XDPL_PL_NO = :" & UBound(strBindField) - 1 & " --����ڥ������ޔԍ�")
        End If
        If IsNull(FHINMEI_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --�i�ں���")
        End If
        If IsNull(XDPL_PL_PTN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_PTN
            strSQL.Append(vbCrLf & "    AND XDPL_PL_PTN = :" & UBound(strBindField) - 1 & " --����ڥ������������")
        End If
        If IsNull(XDPL_PL_ONLINE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_ONLINE
            strSQL.Append(vbCrLf & "    AND XDPL_PL_ONLINE = :" & UBound(strBindField) - 1 & " --����ڥ������޵�ײݏ��")
        End If
        If IsNull(XDPL_PL_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_STS
            strSQL.Append(vbCrLf & "    AND XDPL_PL_STS = :" & UBound(strBindField) - 1 & " --����ڥ������މ^�]���")
        End If
        If IsNull(XSTART_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSTART_DT
            strSQL.Append(vbCrLf & "    AND XSTART_DT = :" & UBound(strBindField) - 1 & " --�J�n����")
        End If
        If IsNull(XEND_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEND_DT
            strSQL.Append(vbCrLf & "    AND XEND_DT = :" & UBound(strBindField) - 1 & " --�I������")
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
        strDataSetName = "XSTS_DPL_PL"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XSTS_DPL_PL(Owner, objDb, objDbLog)
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
    Public Function GET_XSTS_DPL_PL_USER(Optional ByRef objUSER_PARAM AS Object(,) = nothing) As RetCode
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
        strDataSetName = "XSTS_DPL_PL"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XSTS_DPL_PL(Owner, objDb, objDbLog)
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
    Public Function GET_XSTS_DPL_PL_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    XSTS_DPL_PL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XDPL_PL_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_NO
            strSQL.Append(vbCrLf & "    AND XDPL_PL_NO = :" & UBound(strBindField) - 1 & " --����ڥ������ޔԍ�")
        End If
        If IsNull(FHINMEI_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --�i�ں���")
        End If
        If IsNull(XDPL_PL_PTN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_PTN
            strSQL.Append(vbCrLf & "    AND XDPL_PL_PTN = :" & UBound(strBindField) - 1 & " --����ڥ������������")
        End If
        If IsNull(XDPL_PL_ONLINE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_ONLINE
            strSQL.Append(vbCrLf & "    AND XDPL_PL_ONLINE = :" & UBound(strBindField) - 1 & " --����ڥ������޵�ײݏ��")
        End If
        If IsNull(XDPL_PL_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_STS
            strSQL.Append(vbCrLf & "    AND XDPL_PL_STS = :" & UBound(strBindField) - 1 & " --����ڥ������މ^�]���")
        End If
        If IsNull(XSTART_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSTART_DT
            strSQL.Append(vbCrLf & "    AND XSTART_DT = :" & UBound(strBindField) - 1 & " --�J�n����")
        End If
        If IsNull(XEND_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEND_DT
            strSQL.Append(vbCrLf & "    AND XEND_DT = :" & UBound(strBindField) - 1 & " --�I������")
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
        strDataSetName = "XSTS_DPL_PL"
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
    Public Sub UPDATE_XSTS_DPL_PL()
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
        strSQL.Append(vbCrLf & "    XSTS_DPL_PL")
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
        If IsNull(mXDPL_PL_PTN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_PTN = NULL --����ڥ������������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_PTN = NULL --����ڥ������������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_PTN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_PTN = :" & Ubound(strBindField) - 1 & " --����ڥ������������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_PTN = :" & Ubound(strBindField) - 1 & " --����ڥ������������")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_ONLINE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_ONLINE = NULL --����ڥ������޵�ײݏ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_ONLINE = NULL --����ڥ������޵�ײݏ��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_ONLINE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_ONLINE = :" & Ubound(strBindField) - 1 & " --����ڥ������޵�ײݏ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_ONLINE = :" & Ubound(strBindField) - 1 & " --����ڥ������޵�ײݏ��")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_STS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_STS = NULL --����ڥ������މ^�]���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_STS = NULL --����ڥ������މ^�]���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_STS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_STS = :" & Ubound(strBindField) - 1 & " --����ڥ������މ^�]���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_STS = :" & Ubound(strBindField) - 1 & " --����ڥ������މ^�]���")
        End If
        intCount = intCount + 1
        If IsNull(mXSTART_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSTART_DT = NULL --�J�n����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSTART_DT = NULL --�J�n����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSTART_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSTART_DT = :" & Ubound(strBindField) - 1 & " --�J�n����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSTART_DT = :" & Ubound(strBindField) - 1 & " --�J�n����")
        End If
        intCount = intCount + 1
        If IsNull(mXEND_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEND_DT = NULL --�I������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEND_DT = NULL --�I������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEND_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEND_DT = :" & Ubound(strBindField) - 1 & " --�I������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEND_DT = :" & Ubound(strBindField) - 1 & " --�I������")
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
    Public Sub ADD_XSTS_DPL_PL()
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
        strSQL.Append(vbCrLf & "    XSTS_DPL_PL")
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
        If IsNull(mXDPL_PL_PTN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����ڥ������������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����ڥ������������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_PTN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����ڥ������������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����ڥ������������")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_ONLINE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����ڥ������޵�ײݏ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����ڥ������޵�ײݏ��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_ONLINE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����ڥ������޵�ײݏ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����ڥ������޵�ײݏ��")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_STS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����ڥ������މ^�]���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����ڥ������މ^�]���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_STS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����ڥ������މ^�]���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����ڥ������މ^�]���")
        End If
        intCount = intCount + 1
        If IsNull(mXSTART_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�J�n����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�J�n����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSTART_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�J�n����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�J�n����")
        End If
        intCount = intCount + 1
        If IsNull(mXEND_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�I������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�I������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEND_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�I������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�I������")
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
    Public Sub DELETE_XSTS_DPL_PL()
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
        strSQL.Append(vbCrLf & "    XSTS_DPL_PL")
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
    Public Sub DELETE_XSTS_DPL_PL_ANY()
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
        strSQL.Append(vbCrLf & "    XSTS_DPL_PL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(XDPL_PL_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_NO
            strSQL.Append(vbCrLf & "    AND XDPL_PL_NO = :" & UBound(strBindField) - 1 & " --����ڥ������ޔԍ�")
        End If
        If IsNotNull(FHINMEI_CD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --�i�ں���")
        End If
        If IsNotNull(XDPL_PL_PTN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_PTN
            strSQL.Append(vbCrLf & "    AND XDPL_PL_PTN = :" & UBound(strBindField) - 1 & " --����ڥ������������")
        End If
        If IsNotNull(XDPL_PL_ONLINE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_ONLINE
            strSQL.Append(vbCrLf & "    AND XDPL_PL_ONLINE = :" & UBound(strBindField) - 1 & " --����ڥ������޵�ײݏ��")
        End If
        If IsNotNull(XDPL_PL_STS) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_STS
            strSQL.Append(vbCrLf & "    AND XDPL_PL_STS = :" & UBound(strBindField) - 1 & " --����ڥ������މ^�]���")
        End If
        If IsNotNull(XSTART_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSTART_DT
            strSQL.Append(vbCrLf & "    AND XSTART_DT = :" & UBound(strBindField) - 1 & " --�J�n����")
        End If
        If IsNotNull(XEND_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEND_DT
            strSQL.Append(vbCrLf & "    AND XEND_DT = :" & UBound(strBindField) - 1 & " --�I������")
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
        If IsNothing(objType.GetProperty("XDPL_PL_NO")) = False Then mXDPL_PL_NO = objObject.XDPL_PL_NO                                                '����ڥ������ޔԍ�
        If IsNothing(objType.GetProperty("FHINMEI_CD")) = False Then mFHINMEI_CD = objObject.FHINMEI_CD                                                '�i�ں���
        If IsNothing(objType.GetProperty("XDPL_PL_PTN")) = False Then mXDPL_PL_PTN = objObject.XDPL_PL_PTN                                             '����ڥ������������
        If IsNothing(objType.GetProperty("XDPL_PL_ONLINE")) = False Then mXDPL_PL_ONLINE = objObject.XDPL_PL_ONLINE                                    '����ڥ������޵�ײݏ��
        If IsNothing(objType.GetProperty("XDPL_PL_STS")) = False Then mXDPL_PL_STS = objObject.XDPL_PL_STS                                             '����ڥ������މ^�]���
        If IsNothing(objType.GetProperty("XSTART_DT")) = False Then mXSTART_DT = objObject.XSTART_DT                                                   '�J�n����
        If IsNothing(objType.GetProperty("XEND_DT")) = False Then mXEND_DT = objObject.XEND_DT                                                         '�I������

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
        mFHINMEI_CD = Nothing
        mXDPL_PL_PTN = Nothing
        mXDPL_PL_ONLINE = Nothing
        mXDPL_PL_STS = Nothing
        mXSTART_DT = Nothing
        mXEND_DT = Nothing


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
        mFHINMEI_CD = TO_STRING_NULLABLE(objRow("FHINMEI_CD"))
        mXDPL_PL_PTN = TO_INTEGER_NULLABLE(objRow("XDPL_PL_PTN"))
        mXDPL_PL_ONLINE = TO_INTEGER_NULLABLE(objRow("XDPL_PL_ONLINE"))
        mXDPL_PL_STS = TO_INTEGER_NULLABLE(objRow("XDPL_PL_STS"))
        mXSTART_DT = TO_DATE_NULLABLE(objRow("XSTART_DT"))
        mXEND_DT = TO_DATE_NULLABLE(objRow("XEND_DT"))


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
        strMsg &= "[ð��ٖ�:����ڥ������ޏ�]"
        If IsNotNull(XDPL_PL_NO) Then
            strMsg &= "[����ڥ������ޔԍ�:" & XDPL_PL_NO & "]"
        End If
        If IsNotNull(FHINMEI_CD) Then
            strMsg &= "[�i�ں���:" & FHINMEI_CD & "]"
        End If
        If IsNotNull(XDPL_PL_PTN) Then
            strMsg &= "[����ڥ������������:" & XDPL_PL_PTN & "]"
        End If
        If IsNotNull(XDPL_PL_ONLINE) Then
            strMsg &= "[����ڥ������޵�ײݏ��:" & XDPL_PL_ONLINE & "]"
        End If
        If IsNotNull(XDPL_PL_STS) Then
            strMsg &= "[����ڥ������މ^�]���:" & XDPL_PL_STS & "]"
        End If
        If IsNotNull(XSTART_DT) Then
            strMsg &= "[�J�n����:" & XSTART_DT & "]"
        End If
        If IsNotNull(XEND_DT) Then
            strMsg &= "[�I������:" & XEND_DT & "]"
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
