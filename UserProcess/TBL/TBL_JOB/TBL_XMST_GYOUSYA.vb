'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' �y���́zMaterialStreamð��ٸ׽
' �y�@�\�z�Ǝ�Ͻ�ð��ٸ׽
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
''' �Ǝ�Ͻ�ð��ٸ׽
''' </summary>
Public Class TBL_XMST_GYOUSYA
    Inherits clsTemplateTable

    '**********************************************************************************************
    '����������������
#Region "  �׽�ϐ���`                  "
    '�����è
    Private mobjAryMe As TBL_XMST_GYOUSYA()                                      '�Ǝ�Ͻ�
    Private mstrUSER_SQL As String                                               'հ�ްSQL
    Private mORDER_BY As String                                                  'OrderBy��
    Private mWHERE As String                                                     'Where��
    Private mXGYOUSYA_CD As String                                               '�����ƎҺ���
    Private mXGYOUSYA_NAME As String                                             '�����ƎҖ���
    Private mXGYOUSYA_RYAKU As String                                            '����
    Private mXADDRESS As String                                                  '�Z��
    Private mXTELEPHONE As String                                                '�d�b�ԍ�
    Private mXPOSTAL_CODE As String                                              '�X�֔ԍ�
    Private mFENTRY_DT As Nullable(Of Date)                                      '�o�^����
#End Region
#Region "  �����è��`                  "
    ''' <summary>
    ''' ���ѕϐ� (���׽�^�z��)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_XMST_GYOUSYA()
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
    ''' �����ƎҖ���
    ''' </summary>
    Public Property XGYOUSYA_NAME() As String
        Get
            Return mXGYOUSYA_NAME
        End Get
        Set(ByVal Value As String)
            mXGYOUSYA_NAME = Value
        End Set
    End Property
    ''' <summary>
    ''' ����
    ''' </summary>
    Public Property XGYOUSYA_RYAKU() As String
        Get
            Return mXGYOUSYA_RYAKU
        End Get
        Set(ByVal Value As String)
            mXGYOUSYA_RYAKU = Value
        End Set
    End Property
    ''' <summary>
    ''' �Z��
    ''' </summary>
    Public Property XADDRESS() As String
        Get
            Return mXADDRESS
        End Get
        Set(ByVal Value As String)
            mXADDRESS = Value
        End Set
    End Property
    ''' <summary>
    ''' �d�b�ԍ�
    ''' </summary>
    Public Property XTELEPHONE() As String
        Get
            Return mXTELEPHONE
        End Get
        Set(ByVal Value As String)
            mXTELEPHONE = Value
        End Set
    End Property
    ''' <summary>
    ''' �X�֔ԍ�
    ''' </summary>
    Public Property XPOSTAL_CODE() As String
        Get
            Return mXPOSTAL_CODE
        End Get
        Set(ByVal Value As String)
            mXPOSTAL_CODE = Value
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
    Public Function GET_XMST_GYOUSYA(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    XMST_GYOUSYA")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XGYOUSYA_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_CD
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_CD = :" & UBound(strBindField) - 1 & " --�����ƎҺ���")
        End If
        If IsNull(XGYOUSYA_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_NAME
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_NAME = :" & UBound(strBindField) - 1 & " --�����ƎҖ���")
        End If
        If IsNull(XGYOUSYA_RYAKU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_RYAKU
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_RYAKU = :" & UBound(strBindField) - 1 & " --����")
        End If
        If IsNull(XADDRESS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADDRESS
            strSQL.Append(vbCrLf & "    AND XADDRESS = :" & UBound(strBindField) - 1 & " --�Z��")
        End If
        If IsNull(XTELEPHONE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTELEPHONE
            strSQL.Append(vbCrLf & "    AND XTELEPHONE = :" & UBound(strBindField) - 1 & " --�d�b�ԍ�")
        End If
        If IsNull(XPOSTAL_CODE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPOSTAL_CODE
            strSQL.Append(vbCrLf & "    AND XPOSTAL_CODE = :" & UBound(strBindField) - 1 & " --�X�֔ԍ�")
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
        strDataSetName = "XMST_GYOUSYA"
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
    Public Function GET_XMST_GYOUSYA_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    XMST_GYOUSYA")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XGYOUSYA_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_CD
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_CD = :" & UBound(strBindField) - 1 & " --�����ƎҺ���")
        End If
        If IsNull(XGYOUSYA_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_NAME
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_NAME = :" & UBound(strBindField) - 1 & " --�����ƎҖ���")
        End If
        If IsNull(XGYOUSYA_RYAKU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_RYAKU
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_RYAKU = :" & UBound(strBindField) - 1 & " --����")
        End If
        If IsNull(XADDRESS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADDRESS
            strSQL.Append(vbCrLf & "    AND XADDRESS = :" & UBound(strBindField) - 1 & " --�Z��")
        End If
        If IsNull(XTELEPHONE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTELEPHONE
            strSQL.Append(vbCrLf & "    AND XTELEPHONE = :" & UBound(strBindField) - 1 & " --�d�b�ԍ�")
        End If
        If IsNull(XPOSTAL_CODE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPOSTAL_CODE
            strSQL.Append(vbCrLf & "    AND XPOSTAL_CODE = :" & UBound(strBindField) - 1 & " --�X�֔ԍ�")
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
        strDataSetName = "XMST_GYOUSYA"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XMST_GYOUSYA(Owner, objDb, objDbLog)
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
    Public Function GET_XMST_GYOUSYA_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "XMST_GYOUSYA"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XMST_GYOUSYA(Owner, objDb, objDbLog)
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
    Public Function GET_XMST_GYOUSYA_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    XMST_GYOUSYA")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XGYOUSYA_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_CD
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_CD = :" & UBound(strBindField) - 1 & " --�����ƎҺ���")
        End If
        If IsNull(XGYOUSYA_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_NAME
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_NAME = :" & UBound(strBindField) - 1 & " --�����ƎҖ���")
        End If
        If IsNull(XGYOUSYA_RYAKU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_RYAKU
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_RYAKU = :" & UBound(strBindField) - 1 & " --����")
        End If
        If IsNull(XADDRESS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADDRESS
            strSQL.Append(vbCrLf & "    AND XADDRESS = :" & UBound(strBindField) - 1 & " --�Z��")
        End If
        If IsNull(XTELEPHONE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTELEPHONE
            strSQL.Append(vbCrLf & "    AND XTELEPHONE = :" & UBound(strBindField) - 1 & " --�d�b�ԍ�")
        End If
        If IsNull(XPOSTAL_CODE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPOSTAL_CODE
            strSQL.Append(vbCrLf & "    AND XPOSTAL_CODE = :" & UBound(strBindField) - 1 & " --�X�֔ԍ�")
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
        strDataSetName = "XMST_GYOUSYA"
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
    Public Sub UPDATE_XMST_GYOUSYA()
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
        ElseIf IsNull(mXGYOUSYA_CD) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�����ƎҺ���]"
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
        strSQL.Append(vbCrLf & "    XMST_GYOUSYA")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
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
        If IsNull(mXGYOUSYA_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XGYOUSYA_NAME = NULL --�����ƎҖ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XGYOUSYA_NAME = NULL --�����ƎҖ���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XGYOUSYA_NAME = :" & Ubound(strBindField) - 1 & " --�����ƎҖ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XGYOUSYA_NAME = :" & Ubound(strBindField) - 1 & " --�����ƎҖ���")
        End If
        intCount = intCount + 1
        If IsNull(mXGYOUSYA_RYAKU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XGYOUSYA_RYAKU = NULL --����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XGYOUSYA_RYAKU = NULL --����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_RYAKU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XGYOUSYA_RYAKU = :" & Ubound(strBindField) - 1 & " --����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XGYOUSYA_RYAKU = :" & Ubound(strBindField) - 1 & " --����")
        End If
        intCount = intCount + 1
        If IsNull(mXADDRESS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XADDRESS = NULL --�Z��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XADDRESS = NULL --�Z��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADDRESS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XADDRESS = :" & Ubound(strBindField) - 1 & " --�Z��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XADDRESS = :" & Ubound(strBindField) - 1 & " --�Z��")
        End If
        intCount = intCount + 1
        If IsNull(mXTELEPHONE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTELEPHONE = NULL --�d�b�ԍ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTELEPHONE = NULL --�d�b�ԍ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTELEPHONE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTELEPHONE = :" & Ubound(strBindField) - 1 & " --�d�b�ԍ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTELEPHONE = :" & Ubound(strBindField) - 1 & " --�d�b�ԍ�")
        End If
        intCount = intCount + 1
        If IsNull(mXPOSTAL_CODE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XPOSTAL_CODE = NULL --�X�֔ԍ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XPOSTAL_CODE = NULL --�X�֔ԍ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPOSTAL_CODE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XPOSTAL_CODE = :" & Ubound(strBindField) - 1 & " --�X�֔ԍ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XPOSTAL_CODE = :" & Ubound(strBindField) - 1 & " --�X�֔ԍ�")
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
        If IsNull(XGYOUSYA_CD) = True Then
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_CD IS NULL --�����ƎҺ���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_CD
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_CD = :" & UBound(strBindField) - 1 & " --�����ƎҺ���")
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
    Public Sub ADD_XMST_GYOUSYA()
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
        ElseIf IsNull(mXGYOUSYA_CD) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�����ƎҺ���]"
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
        strSQL.Append(vbCrLf & "    XMST_GYOUSYA")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
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
        If IsNull(mXGYOUSYA_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�����ƎҖ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�����ƎҖ���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�����ƎҖ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�����ƎҖ���")
        End If
        intCount = intCount + 1
        If IsNull(mXGYOUSYA_RYAKU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_RYAKU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����")
        End If
        intCount = intCount + 1
        If IsNull(mXADDRESS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�Z��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�Z��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADDRESS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�Z��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�Z��")
        End If
        intCount = intCount + 1
        If IsNull(mXTELEPHONE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�d�b�ԍ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�d�b�ԍ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTELEPHONE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�d�b�ԍ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�d�b�ԍ�")
        End If
        intCount = intCount + 1
        If IsNull(mXPOSTAL_CODE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�X�֔ԍ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�X�֔ԍ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPOSTAL_CODE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�X�֔ԍ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�X�֔ԍ�")
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
    Public Sub DELETE_XMST_GYOUSYA()
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
        ElseIf IsNull(mXGYOUSYA_CD) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�����ƎҺ���]"
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
        strSQL.Append(vbCrLf & "    XMST_GYOUSYA")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(XGYOUSYA_CD) = True Then
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_CD IS NULL --�����ƎҺ���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_CD
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_CD = :" & UBound(strBindField) - 1 & " --�����ƎҺ���")
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
    Public Sub DELETE_XMST_GYOUSYA_ANY()
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
        strSQL.Append(vbCrLf & "    XMST_GYOUSYA")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(XGYOUSYA_CD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_CD
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_CD = :" & UBound(strBindField) - 1 & " --�����ƎҺ���")
        End If
        If IsNotNull(XGYOUSYA_NAME) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_NAME
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_NAME = :" & UBound(strBindField) - 1 & " --�����ƎҖ���")
        End If
        If IsNotNull(XGYOUSYA_RYAKU) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_RYAKU
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_RYAKU = :" & UBound(strBindField) - 1 & " --����")
        End If
        If IsNotNull(XADDRESS) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADDRESS
            strSQL.Append(vbCrLf & "    AND XADDRESS = :" & UBound(strBindField) - 1 & " --�Z��")
        End If
        If IsNotNull(XTELEPHONE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTELEPHONE
            strSQL.Append(vbCrLf & "    AND XTELEPHONE = :" & UBound(strBindField) - 1 & " --�d�b�ԍ�")
        End If
        If IsNotNull(XPOSTAL_CODE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPOSTAL_CODE
            strSQL.Append(vbCrLf & "    AND XPOSTAL_CODE = :" & UBound(strBindField) - 1 & " --�X�֔ԍ�")
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
        If IsNothing(objType.GetProperty("XGYOUSYA_CD")) = False Then mXGYOUSYA_CD = objObject.XGYOUSYA_CD '�����ƎҺ���
        If IsNothing(objType.GetProperty("XGYOUSYA_NAME")) = False Then mXGYOUSYA_NAME = objObject.XGYOUSYA_NAME '�����ƎҖ���
        If IsNothing(objType.GetProperty("XGYOUSYA_RYAKU")) = False Then mXGYOUSYA_RYAKU = objObject.XGYOUSYA_RYAKU '����
        If IsNothing(objType.GetProperty("XADDRESS")) = False Then mXADDRESS = objObject.XADDRESS '�Z��
        If IsNothing(objType.GetProperty("XTELEPHONE")) = False Then mXTELEPHONE = objObject.XTELEPHONE '�d�b�ԍ�
        If IsNothing(objType.GetProperty("XPOSTAL_CODE")) = False Then mXPOSTAL_CODE = objObject.XPOSTAL_CODE '�X�֔ԍ�
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
        mXGYOUSYA_CD = Nothing
        mXGYOUSYA_NAME = Nothing
        mXGYOUSYA_RYAKU = Nothing
        mXADDRESS = Nothing
        mXTELEPHONE = Nothing
        mXPOSTAL_CODE = Nothing
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
        mXGYOUSYA_CD = TO_STRING_NULLABLE(objRow("XGYOUSYA_CD"))
        mXGYOUSYA_NAME = TO_STRING_NULLABLE(objRow("XGYOUSYA_NAME"))
        mXGYOUSYA_RYAKU = TO_STRING_NULLABLE(objRow("XGYOUSYA_RYAKU"))
        mXADDRESS = TO_STRING_NULLABLE(objRow("XADDRESS"))
        mXTELEPHONE = TO_STRING_NULLABLE(objRow("XTELEPHONE"))
        mXPOSTAL_CODE = TO_STRING_NULLABLE(objRow("XPOSTAL_CODE"))
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
        strMsg &= "[ð��ٖ�:�Ǝ�Ͻ�]"
        If IsNotNull(XGYOUSYA_CD) Then
            strMsg &= "[�����ƎҺ���:" & XGYOUSYA_CD & "]"
        End If
        If IsNotNull(XGYOUSYA_NAME) Then
            strMsg &= "[�����ƎҖ���:" & XGYOUSYA_NAME & "]"
        End If
        If IsNotNull(XGYOUSYA_RYAKU) Then
            strMsg &= "[����:" & XGYOUSYA_RYAKU & "]"
        End If
        If IsNotNull(XADDRESS) Then
            strMsg &= "[�Z��:" & XADDRESS & "]"
        End If
        If IsNotNull(XTELEPHONE) Then
            strMsg &= "[�d�b�ԍ�:" & XTELEPHONE & "]"
        End If
        If IsNotNull(XPOSTAL_CODE) Then
            strMsg &= "[�X�֔ԍ�:" & XPOSTAL_CODE & "]"
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
