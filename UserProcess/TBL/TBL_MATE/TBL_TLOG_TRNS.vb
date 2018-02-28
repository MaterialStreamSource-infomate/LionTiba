'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' �y���́zMaterialStreamð��ٸ׽
' �y�@�\�z��ݻ޸���۸�ð��ٸ׽
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
''' TLOG_TRNSð��ٸ׽
''' </summary>
Public Class TBL_TLOG_TRNS
    Inherits clsTemplateTable

    '**********************************************************************************************
    '����������������
#Region "  �׽�ϐ���`                  "
    '�����è
    Private mobjAryMe As TBL_TLOG_TRNS()                                         '��ݻ޸���۸�
    Private mstrUSER_SQL As String                                               'հ�ްSQL
    Private mORDER_BY As String                                                  'OrderBy��
    Private mWHERE As String                                                     'Where��
    Private mFLOG_NO_CYCLIC As Nullable(Of Integer)                              '���د�۸އ�
    Private mFHASSEI_DT As Nullable(Of Date)                                     '��������
    Private mFUSER_ID As String                                                  'հ�ްID
    Private mFTERM_ID As String                                                  '�[��ID
    Private mFSYORI_ID As String                                                 '����ID
    Private mFMSG_PRM1 As String                                                 '���Ұ�1
    Private mFMSG_PRM2 As String                                                 '���Ұ�2
    Private mFMSG_PRM3 As String                                                 '���Ұ�3
    Private mFMSG_PRM4 As String                                                 '���Ұ�4
    Private mFMSG_PRM5 As String                                                 '���Ұ�5
    Private mFLOG_DATA_TRN As String                                             '��ݻ޸���۸��ް�
#End Region
#Region "  �����è��`                  "
    ''' <summary>
    ''' ���ѕϐ� (���׽�^�z��)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_TLOG_TRNS()
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
    ''' ���د�۸އ�
    ''' </summary>
    Public Property FLOG_NO_CYCLIC() As Nullable(Of Integer)
        Get
            Return mFLOG_NO_CYCLIC
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFLOG_NO_CYCLIC = Value
        End Set
    End Property
    ''' <summary>
    ''' ��������
    ''' </summary>
    Public Property FHASSEI_DT() As Nullable(Of Date)
        Get
            Return mFHASSEI_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mFHASSEI_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' հ�ްID
    ''' </summary>
    Public Property FUSER_ID() As String
        Get
            Return mFUSER_ID
        End Get
        Set(ByVal Value As String)
            mFUSER_ID = Value
        End Set
    End Property
    ''' <summary>
    ''' �[��ID
    ''' </summary>
    Public Property FTERM_ID() As String
        Get
            Return mFTERM_ID
        End Get
        Set(ByVal Value As String)
            mFTERM_ID = Value
        End Set
    End Property
    ''' <summary>
    ''' ����ID
    ''' </summary>
    Public Property FSYORI_ID() As String
        Get
            Return mFSYORI_ID
        End Get
        Set(ByVal Value As String)
            mFSYORI_ID = Value
        End Set
    End Property
    ''' <summary>
    ''' ���Ұ�1
    ''' </summary>
    Public Property FMSG_PRM1() As String
        Get
            Return mFMSG_PRM1
        End Get
        Set(ByVal Value As String)
            mFMSG_PRM1 = Value
        End Set
    End Property
    ''' <summary>
    ''' ���Ұ�2
    ''' </summary>
    Public Property FMSG_PRM2() As String
        Get
            Return mFMSG_PRM2
        End Get
        Set(ByVal Value As String)
            mFMSG_PRM2 = Value
        End Set
    End Property
    ''' <summary>
    ''' ���Ұ�3
    ''' </summary>
    Public Property FMSG_PRM3() As String
        Get
            Return mFMSG_PRM3
        End Get
        Set(ByVal Value As String)
            mFMSG_PRM3 = Value
        End Set
    End Property
    ''' <summary>
    ''' ���Ұ�4
    ''' </summary>
    Public Property FMSG_PRM4() As String
        Get
            Return mFMSG_PRM4
        End Get
        Set(ByVal Value As String)
            mFMSG_PRM4 = Value
        End Set
    End Property
    ''' <summary>
    ''' ���Ұ�5
    ''' </summary>
    Public Property FMSG_PRM5() As String
        Get
            Return mFMSG_PRM5
        End Get
        Set(ByVal Value As String)
            mFMSG_PRM5 = Value
        End Set
    End Property
    ''' <summary>
    ''' ��ݻ޸���۸��ް�
    ''' </summary>
    Public Property FLOG_DATA_TRN() As String
        Get
            Return mFLOG_DATA_TRN
        End Get
        Set(ByVal Value As String)
            mFLOG_DATA_TRN = Value
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
    Public Function GET_TLOG_TRNS(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    TLOG_TRNS")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FLOG_NO_CYCLIC) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO_CYCLIC
            strSQL.Append(vbCrLf & "    AND FLOG_NO_CYCLIC = :" & UBound(strBindField) - 1 & " --���د�۸އ�")
        End If
        If IsNull(FHASSEI_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHASSEI_DT
            strSQL.Append(vbCrLf & "    AND FHASSEI_DT = :" & UBound(strBindField) - 1 & " --��������")
        End If
        If IsNull(FUSER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID
            strSQL.Append(vbCrLf & "    AND FUSER_ID = :" & UBound(strBindField) - 1 & " --հ�ްID")
        End If
        If IsNull(FTERM_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTERM_ID
            strSQL.Append(vbCrLf & "    AND FTERM_ID = :" & UBound(strBindField) - 1 & " --�[��ID")
        End If
        If IsNull(FSYORI_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYORI_ID
            strSQL.Append(vbCrLf & "    AND FSYORI_ID = :" & UBound(strBindField) - 1 & " --����ID")
        End If
        If IsNull(FMSG_PRM1) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM1
            strSQL.Append(vbCrLf & "    AND FMSG_PRM1 = :" & UBound(strBindField) - 1 & " --���Ұ�1")
        End If
        If IsNull(FMSG_PRM2) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM2
            strSQL.Append(vbCrLf & "    AND FMSG_PRM2 = :" & UBound(strBindField) - 1 & " --���Ұ�2")
        End If
        If IsNull(FMSG_PRM3) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM3
            strSQL.Append(vbCrLf & "    AND FMSG_PRM3 = :" & UBound(strBindField) - 1 & " --���Ұ�3")
        End If
        If IsNull(FMSG_PRM4) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM4
            strSQL.Append(vbCrLf & "    AND FMSG_PRM4 = :" & UBound(strBindField) - 1 & " --���Ұ�4")
        End If
        If IsNull(FMSG_PRM5) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM5
            strSQL.Append(vbCrLf & "    AND FMSG_PRM5 = :" & UBound(strBindField) - 1 & " --���Ұ�5")
        End If
        If IsNull(FLOG_DATA_TRN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_DATA_TRN
            strSQL.Append(vbCrLf & "    AND FLOG_DATA_TRN = :" & UBound(strBindField) - 1 & " --��ݻ޸���۸��ް�")
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
        strDataSetName = "TLOG_TRNS"
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
    Public Function GET_TLOG_TRNS_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    TLOG_TRNS")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FLOG_NO_CYCLIC) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO_CYCLIC
            strSQL.Append(vbCrLf & "    AND FLOG_NO_CYCLIC = :" & UBound(strBindField) - 1 & " --���د�۸އ�")
        End If
        If IsNull(FHASSEI_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHASSEI_DT
            strSQL.Append(vbCrLf & "    AND FHASSEI_DT = :" & UBound(strBindField) - 1 & " --��������")
        End If
        If IsNull(FUSER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID
            strSQL.Append(vbCrLf & "    AND FUSER_ID = :" & UBound(strBindField) - 1 & " --հ�ްID")
        End If
        If IsNull(FTERM_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTERM_ID
            strSQL.Append(vbCrLf & "    AND FTERM_ID = :" & UBound(strBindField) - 1 & " --�[��ID")
        End If
        If IsNull(FSYORI_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYORI_ID
            strSQL.Append(vbCrLf & "    AND FSYORI_ID = :" & UBound(strBindField) - 1 & " --����ID")
        End If
        If IsNull(FMSG_PRM1) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM1
            strSQL.Append(vbCrLf & "    AND FMSG_PRM1 = :" & UBound(strBindField) - 1 & " --���Ұ�1")
        End If
        If IsNull(FMSG_PRM2) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM2
            strSQL.Append(vbCrLf & "    AND FMSG_PRM2 = :" & UBound(strBindField) - 1 & " --���Ұ�2")
        End If
        If IsNull(FMSG_PRM3) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM3
            strSQL.Append(vbCrLf & "    AND FMSG_PRM3 = :" & UBound(strBindField) - 1 & " --���Ұ�3")
        End If
        If IsNull(FMSG_PRM4) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM4
            strSQL.Append(vbCrLf & "    AND FMSG_PRM4 = :" & UBound(strBindField) - 1 & " --���Ұ�4")
        End If
        If IsNull(FMSG_PRM5) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM5
            strSQL.Append(vbCrLf & "    AND FMSG_PRM5 = :" & UBound(strBindField) - 1 & " --���Ұ�5")
        End If
        If IsNull(FLOG_DATA_TRN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_DATA_TRN
            strSQL.Append(vbCrLf & "    AND FLOG_DATA_TRN = :" & UBound(strBindField) - 1 & " --��ݻ޸���۸��ް�")
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
        strDataSetName = "TLOG_TRNS"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TLOG_TRNS(Owner, objDb, objDbLog)
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
    Public Function GET_TLOG_TRNS_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "TLOG_TRNS"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TLOG_TRNS(Owner, objDb, objDbLog)
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
    Public Function GET_TLOG_TRNS_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    TLOG_TRNS")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FLOG_NO_CYCLIC) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO_CYCLIC
            strSQL.Append(vbCrLf & "    AND FLOG_NO_CYCLIC = :" & UBound(strBindField) - 1 & " --���د�۸އ�")
        End If
        If IsNull(FHASSEI_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHASSEI_DT
            strSQL.Append(vbCrLf & "    AND FHASSEI_DT = :" & UBound(strBindField) - 1 & " --��������")
        End If
        If IsNull(FUSER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID
            strSQL.Append(vbCrLf & "    AND FUSER_ID = :" & UBound(strBindField) - 1 & " --հ�ްID")
        End If
        If IsNull(FTERM_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTERM_ID
            strSQL.Append(vbCrLf & "    AND FTERM_ID = :" & UBound(strBindField) - 1 & " --�[��ID")
        End If
        If IsNull(FSYORI_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYORI_ID
            strSQL.Append(vbCrLf & "    AND FSYORI_ID = :" & UBound(strBindField) - 1 & " --����ID")
        End If
        If IsNull(FMSG_PRM1) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM1
            strSQL.Append(vbCrLf & "    AND FMSG_PRM1 = :" & UBound(strBindField) - 1 & " --���Ұ�1")
        End If
        If IsNull(FMSG_PRM2) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM2
            strSQL.Append(vbCrLf & "    AND FMSG_PRM2 = :" & UBound(strBindField) - 1 & " --���Ұ�2")
        End If
        If IsNull(FMSG_PRM3) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM3
            strSQL.Append(vbCrLf & "    AND FMSG_PRM3 = :" & UBound(strBindField) - 1 & " --���Ұ�3")
        End If
        If IsNull(FMSG_PRM4) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM4
            strSQL.Append(vbCrLf & "    AND FMSG_PRM4 = :" & UBound(strBindField) - 1 & " --���Ұ�4")
        End If
        If IsNull(FMSG_PRM5) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM5
            strSQL.Append(vbCrLf & "    AND FMSG_PRM5 = :" & UBound(strBindField) - 1 & " --���Ұ�5")
        End If
        If IsNull(FLOG_DATA_TRN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_DATA_TRN
            strSQL.Append(vbCrLf & "    AND FLOG_DATA_TRN = :" & UBound(strBindField) - 1 & " --��ݻ޸���۸��ް�")
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
        strDataSetName = "TLOG_TRNS"
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
    Public Sub UPDATE_TLOG_TRNS()
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
        ElseIf IsNull(mFLOG_NO_CYCLIC) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[���د�۸އ�]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFHASSEI_DT) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[��������]"
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
        strSQL.Append(vbCrLf & "    TLOG_TRNS")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
        If IsNull(mFLOG_NO_CYCLIC) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_NO_CYCLIC = NULL --���د�۸އ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_NO_CYCLIC = NULL --���د�۸އ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO_CYCLIC
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_NO_CYCLIC = :" & Ubound(strBindField) - 1 & " --���د�۸އ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_NO_CYCLIC = :" & Ubound(strBindField) - 1 & " --���د�۸އ�")
        End If
        intCount = intCount + 1
        If IsNull(mFHASSEI_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHASSEI_DT = NULL --��������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHASSEI_DT = NULL --��������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHASSEI_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHASSEI_DT = :" & Ubound(strBindField) - 1 & " --��������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHASSEI_DT = :" & Ubound(strBindField) - 1 & " --��������")
        End If
        intCount = intCount + 1
        If IsNull(mFUSER_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUSER_ID = NULL --հ�ްID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUSER_ID = NULL --հ�ްID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUSER_ID = :" & Ubound(strBindField) - 1 & " --հ�ްID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUSER_ID = :" & Ubound(strBindField) - 1 & " --հ�ްID")
        End If
        intCount = intCount + 1
        If IsNull(mFTERM_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTERM_ID = NULL --�[��ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTERM_ID = NULL --�[��ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTERM_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTERM_ID = :" & Ubound(strBindField) - 1 & " --�[��ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTERM_ID = :" & Ubound(strBindField) - 1 & " --�[��ID")
        End If
        intCount = intCount + 1
        If IsNull(mFSYORI_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSYORI_ID = NULL --����ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSYORI_ID = NULL --����ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYORI_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSYORI_ID = :" & Ubound(strBindField) - 1 & " --����ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSYORI_ID = :" & Ubound(strBindField) - 1 & " --����ID")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_PRM1) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_PRM1 = NULL --���Ұ�1")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_PRM1 = NULL --���Ұ�1")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM1
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_PRM1 = :" & Ubound(strBindField) - 1 & " --���Ұ�1")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_PRM1 = :" & Ubound(strBindField) - 1 & " --���Ұ�1")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_PRM2) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_PRM2 = NULL --���Ұ�2")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_PRM2 = NULL --���Ұ�2")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM2
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_PRM2 = :" & Ubound(strBindField) - 1 & " --���Ұ�2")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_PRM2 = :" & Ubound(strBindField) - 1 & " --���Ұ�2")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_PRM3) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_PRM3 = NULL --���Ұ�3")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_PRM3 = NULL --���Ұ�3")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM3
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_PRM3 = :" & Ubound(strBindField) - 1 & " --���Ұ�3")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_PRM3 = :" & Ubound(strBindField) - 1 & " --���Ұ�3")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_PRM4) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_PRM4 = NULL --���Ұ�4")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_PRM4 = NULL --���Ұ�4")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM4
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_PRM4 = :" & Ubound(strBindField) - 1 & " --���Ұ�4")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_PRM4 = :" & Ubound(strBindField) - 1 & " --���Ұ�4")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_PRM5) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_PRM5 = NULL --���Ұ�5")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_PRM5 = NULL --���Ұ�5")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM5
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_PRM5 = :" & Ubound(strBindField) - 1 & " --���Ұ�5")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_PRM5 = :" & Ubound(strBindField) - 1 & " --���Ұ�5")
        End If
        intCount = intCount + 1
        If IsNull(mFLOG_DATA_TRN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_DATA_TRN = NULL --��ݻ޸���۸��ް�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_DATA_TRN = NULL --��ݻ޸���۸��ް�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_DATA_TRN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_DATA_TRN = :" & Ubound(strBindField) - 1 & " --��ݻ޸���۸��ް�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_DATA_TRN = :" & Ubound(strBindField) - 1 & " --��ݻ޸���۸��ް�")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FLOG_NO_CYCLIC) = True Then
            strSQL.Append(vbCrLf & "    AND FLOG_NO_CYCLIC IS NULL --���د�۸އ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO_CYCLIC
            strSQL.Append(vbCrLf & "    AND FLOG_NO_CYCLIC = :" & UBound(strBindField) - 1 & " --���د�۸އ�")
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
    Public Sub ADD_TLOG_TRNS()
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
        ElseIf IsNull(mFLOG_NO_CYCLIC) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[���د�۸އ�]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFHASSEI_DT) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[��������]"
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
        strSQL.Append(vbCrLf & "    TLOG_TRNS")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
        If IsNull(mFLOG_NO_CYCLIC) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���د�۸އ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���د�۸އ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO_CYCLIC
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���د�۸އ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���د�۸އ�")
        End If
        intCount = intCount + 1
        If IsNull(mFHASSEI_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --��������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --��������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHASSEI_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --��������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --��������")
        End If
        intCount = intCount + 1
        If IsNull(mFUSER_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --հ�ްID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --հ�ްID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --հ�ްID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --հ�ްID")
        End If
        intCount = intCount + 1
        If IsNull(mFTERM_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�[��ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�[��ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTERM_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�[��ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�[��ID")
        End If
        intCount = intCount + 1
        If IsNull(mFSYORI_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYORI_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����ID")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_PRM1) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���Ұ�1")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���Ұ�1")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM1
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���Ұ�1")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���Ұ�1")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_PRM2) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���Ұ�2")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���Ұ�2")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM2
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���Ұ�2")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���Ұ�2")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_PRM3) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���Ұ�3")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���Ұ�3")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM3
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���Ұ�3")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���Ұ�3")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_PRM4) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���Ұ�4")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���Ұ�4")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM4
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���Ұ�4")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���Ұ�4")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_PRM5) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���Ұ�5")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���Ұ�5")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM5
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���Ұ�5")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���Ұ�5")
        End If
        intCount = intCount + 1
        If IsNull(mFLOG_DATA_TRN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --��ݻ޸���۸��ް�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --��ݻ޸���۸��ް�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_DATA_TRN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --��ݻ޸���۸��ް�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --��ݻ޸���۸��ް�")
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
    Public Sub DELETE_TLOG_TRNS()
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
        ElseIf IsNull(mFLOG_NO_CYCLIC) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[���د�۸އ�]"
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
        strSQL.Append(vbCrLf & "    TLOG_TRNS")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FLOG_NO_CYCLIC) = True Then
            strSQL.Append(vbCrLf & "    AND FLOG_NO_CYCLIC IS NULL --���د�۸އ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO_CYCLIC
            strSQL.Append(vbCrLf & "    AND FLOG_NO_CYCLIC = :" & UBound(strBindField) - 1 & " --���د�۸އ�")
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
    Public Sub DELETE_TLOG_TRNS_ANY()
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
        strSQL.Append(vbCrLf & "    TLOG_TRNS")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(FLOG_NO_CYCLIC) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO_CYCLIC
            strSQL.Append(vbCrLf & "    AND FLOG_NO_CYCLIC = :" & UBound(strBindField) - 1 & " --���د�۸އ�")
        End If
        If IsNotNull(FHASSEI_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHASSEI_DT
            strSQL.Append(vbCrLf & "    AND FHASSEI_DT = :" & UBound(strBindField) - 1 & " --��������")
        End If
        If IsNotNull(FUSER_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID
            strSQL.Append(vbCrLf & "    AND FUSER_ID = :" & UBound(strBindField) - 1 & " --հ�ްID")
        End If
        If IsNotNull(FTERM_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTERM_ID
            strSQL.Append(vbCrLf & "    AND FTERM_ID = :" & UBound(strBindField) - 1 & " --�[��ID")
        End If
        If IsNotNull(FSYORI_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYORI_ID
            strSQL.Append(vbCrLf & "    AND FSYORI_ID = :" & UBound(strBindField) - 1 & " --����ID")
        End If
        If IsNotNull(FMSG_PRM1) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM1
            strSQL.Append(vbCrLf & "    AND FMSG_PRM1 = :" & UBound(strBindField) - 1 & " --���Ұ�1")
        End If
        If IsNotNull(FMSG_PRM2) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM2
            strSQL.Append(vbCrLf & "    AND FMSG_PRM2 = :" & UBound(strBindField) - 1 & " --���Ұ�2")
        End If
        If IsNotNull(FMSG_PRM3) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM3
            strSQL.Append(vbCrLf & "    AND FMSG_PRM3 = :" & UBound(strBindField) - 1 & " --���Ұ�3")
        End If
        If IsNotNull(FMSG_PRM4) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM4
            strSQL.Append(vbCrLf & "    AND FMSG_PRM4 = :" & UBound(strBindField) - 1 & " --���Ұ�4")
        End If
        If IsNotNull(FMSG_PRM5) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM5
            strSQL.Append(vbCrLf & "    AND FMSG_PRM5 = :" & UBound(strBindField) - 1 & " --���Ұ�5")
        End If
        If IsNotNull(FLOG_DATA_TRN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_DATA_TRN
            strSQL.Append(vbCrLf & "    AND FLOG_DATA_TRN = :" & UBound(strBindField) - 1 & " --��ݻ޸���۸��ް�")
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
        If IsNothing(objType.GetProperty("FLOG_NO_CYCLIC")) = False Then mFLOG_NO_CYCLIC = objObject.FLOG_NO_CYCLIC '���د�۸އ�
        If IsNothing(objType.GetProperty("FHASSEI_DT")) = False Then mFHASSEI_DT = objObject.FHASSEI_DT '��������
        If IsNothing(objType.GetProperty("FUSER_ID")) = False Then mFUSER_ID = objObject.FUSER_ID 'հ�ްID
        If IsNothing(objType.GetProperty("FTERM_ID")) = False Then mFTERM_ID = objObject.FTERM_ID '�[��ID
        If IsNothing(objType.GetProperty("FSYORI_ID")) = False Then mFSYORI_ID = objObject.FSYORI_ID '����ID
        If IsNothing(objType.GetProperty("FMSG_PRM1")) = False Then mFMSG_PRM1 = objObject.FMSG_PRM1 '���Ұ�1
        If IsNothing(objType.GetProperty("FMSG_PRM2")) = False Then mFMSG_PRM2 = objObject.FMSG_PRM2 '���Ұ�2
        If IsNothing(objType.GetProperty("FMSG_PRM3")) = False Then mFMSG_PRM3 = objObject.FMSG_PRM3 '���Ұ�3
        If IsNothing(objType.GetProperty("FMSG_PRM4")) = False Then mFMSG_PRM4 = objObject.FMSG_PRM4 '���Ұ�4
        If IsNothing(objType.GetProperty("FMSG_PRM5")) = False Then mFMSG_PRM5 = objObject.FMSG_PRM5 '���Ұ�5
        If IsNothing(objType.GetProperty("FLOG_DATA_TRN")) = False Then mFLOG_DATA_TRN = objObject.FLOG_DATA_TRN '��ݻ޸���۸��ް�

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
        mFLOG_NO_CYCLIC = Nothing
        mFHASSEI_DT = Nothing
        mFUSER_ID = Nothing
        mFTERM_ID = Nothing
        mFSYORI_ID = Nothing
        mFMSG_PRM1 = Nothing
        mFMSG_PRM2 = Nothing
        mFMSG_PRM3 = Nothing
        mFMSG_PRM4 = Nothing
        mFMSG_PRM5 = Nothing
        mFLOG_DATA_TRN = Nothing


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
        mFLOG_NO_CYCLIC = TO_INTEGER_NULLABLE(objRow("FLOG_NO_CYCLIC"))
        mFHASSEI_DT = TO_DATE_NULLABLE(objRow("FHASSEI_DT"))
        mFUSER_ID = TO_STRING_NULLABLE(objRow("FUSER_ID"))
        mFTERM_ID = TO_STRING_NULLABLE(objRow("FTERM_ID"))
        mFSYORI_ID = TO_STRING_NULLABLE(objRow("FSYORI_ID"))
        mFMSG_PRM1 = TO_STRING_NULLABLE(objRow("FMSG_PRM1"))
        mFMSG_PRM2 = TO_STRING_NULLABLE(objRow("FMSG_PRM2"))
        mFMSG_PRM3 = TO_STRING_NULLABLE(objRow("FMSG_PRM3"))
        mFMSG_PRM4 = TO_STRING_NULLABLE(objRow("FMSG_PRM4"))
        mFMSG_PRM5 = TO_STRING_NULLABLE(objRow("FMSG_PRM5"))
        mFLOG_DATA_TRN = TO_STRING_NULLABLE(objRow("FLOG_DATA_TRN"))


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
        strMsg &= "[ð��ٖ�:��ݻ޸���۸�]"
        If IsNotNull(FLOG_NO_CYCLIC) Then
            strMsg &= "[���د�۸އ�:" & FLOG_NO_CYCLIC & "]"
        End If
        If IsNotNull(FHASSEI_DT) Then
            strMsg &= "[��������:" & FHASSEI_DT & "]"
        End If
        If IsNotNull(FUSER_ID) Then
            strMsg &= "[հ�ްID:" & FUSER_ID & "]"
        End If
        If IsNotNull(FTERM_ID) Then
            strMsg &= "[�[��ID:" & FTERM_ID & "]"
        End If
        If IsNotNull(FSYORI_ID) Then
            strMsg &= "[����ID:" & FSYORI_ID & "]"
        End If
        If IsNotNull(FMSG_PRM1) Then
            strMsg &= "[���Ұ�1:" & FMSG_PRM1 & "]"
        End If
        If IsNotNull(FMSG_PRM2) Then
            strMsg &= "[���Ұ�2:" & FMSG_PRM2 & "]"
        End If
        If IsNotNull(FMSG_PRM3) Then
            strMsg &= "[���Ұ�3:" & FMSG_PRM3 & "]"
        End If
        If IsNotNull(FMSG_PRM4) Then
            strMsg &= "[���Ұ�4:" & FMSG_PRM4 & "]"
        End If
        If IsNotNull(FMSG_PRM5) Then
            strMsg &= "[���Ұ�5:" & FMSG_PRM5 & "]"
        End If
        If IsNotNull(FLOG_DATA_TRN) Then
            strMsg &= "[��ݻ޸���۸��ް�:" & FLOG_DATA_TRN & "]"
        End If


    End Sub
#End Region
    '����������������
    '**********************************************************************************************

    '**********************************************************************************************
    '���������ы���
#Region "  ��ݻ޸���۸ޒǉ�  [SEQ����]              (Public  ADD_TLOG_TRNS_SEQ)(�X�V�^)"
    Public Sub ADD_TLOG_TRNS_SEQ()
        Try
            Dim strSQL As String
            Dim objDataSet As New DataSet       '�ް����
            Dim strDataSetName As String        '�ް���Ė�
            Dim objRow As DataRow               '1ں��ޕ��̃f�[�^


            '***********************
            '���ݽ���o
            '***********************
            strSQL = "SELECT SEQ_TLOG_TRNS.NEXTVAL AS SQLNO FROM DUAL"
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "SEQ_TLOG_TRNS"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                objRow = objDataSet.Tables(strDataSetName).Rows(0)
                mFLOG_NO_CYCLIC = TO_INTEGER_NULLABLE(objRow("SQLNO"))
            Else
                Throw New UserException("���ݽ���Ԏ��s")
            End If


            '***********************
            '�ǉ�
            '***********************
            Me.UPDATE_TLOG_TRNS()



        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
#Region "  ��ݻ޸���۸ޒǉ�  [SEQ����]              (Public  ADD_TLOG_TRNS_SEQ)(�ǉ��^)"
    '' ''Public Sub ADD_TLOG_TRNS_SEQ()
    '' ''    Try


    '' ''        '***********************
    '' ''        '۸އ��̓���
    '' ''        '***********************
    '' ''        Dim objTPRG_SEQNO As New TBL_TPRG_SEQNO(Owner, ObjDb, ObjDbLog) '���ݽ���׽
    '' ''        objTPRG_SEQNO.FSEQ_ID = FSEQ_ID_SSVRLOG_NO_TRNS                  '���ݽID
    '' ''        mFLOG_NO = objTPRG_SEQNO.GET_ENTRY_NO()                         'SEQ���̓���


    '' ''        '***********************
    '' ''        '�ǉ�
    '' ''        '***********************
    '' ''        Me.ADD_TLOG_TRNS()


    '' ''    Catch ex As UserException
    '' ''        Throw ex
    '' ''    Catch ex As Exception
    '' ''        Throw ex
    '' ''    End Try
    '' ''End Sub
#End Region
    '���������ы���
    '**********************************************************************************************


    '**********************************************************************************************
    '���������ьŗL

    '���������ьŗL
    '**********************************************************************************************

End Class
