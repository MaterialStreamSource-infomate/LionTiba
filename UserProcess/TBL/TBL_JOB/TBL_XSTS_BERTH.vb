'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' �y���́zMaterialStreamð��ٸ׽
' �y�@�\�z�o���ް���ð��ٸ׽
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
''' �o���ް���ð��ٸ׽
''' </summary>
Public Class TBL_XSTS_BERTH
    Inherits clsTemplateTable

    '**********************************************************************************************
    '����������������
#Region "  �׽�ϐ���`                  "
    '�����è
    Private mobjAryMe As TBL_XSTS_BERTH()                                        '�o���ް���
    Private mstrUSER_SQL As String                                               'հ�ްSQL
    Private mORDER_BY As String                                                  'OrderBy��
    Private mWHERE As String                                                     'Where��
    Private mXBERTH_NO As String                                                 '�ް�No.
    Private mXSYUKKA_D As Nullable(Of Date)                                      '�o�ד�
    Private mXHENSEI_NO As String                                                '�Ґ�No.
    Private mXSYUKKA_D_RIN1 As Nullable(Of Date)                                 '�א�1�o�ד�
    Private mXHENSEI_NO_OYA_RIN1 As String                                       '�א�1�e�Ґ�No.
    Private mXSYUKKA_D_RIN2 As Nullable(Of Date)                                 '�א�2�o�ד�
    Private mXHENSEI_NO_OYA_RIN2 As String                                       '�א�2�e�Ґ�No.
    Private mFEQ_LOCATION As Nullable(Of Integer)                                '�ݔ�۹����
    Private mXBERTH_YOUTO As Nullable(Of Integer)                                '�ް��p�r
    Private mXBRTH_PRI_BARA As Nullable(Of Integer)                              '�ް�������_���
    Private mXBRTH_PRI_PALE As Nullable(Of Integer)                              '�ް�������_��گ�
    Private mFEQ_ID As String                                                    '�ݔ�ID
    Private mXBERTH_STS As Nullable(Of Integer)                                  '�ް��g�p��
    Private mXSTNO_HIKI As Nullable(Of Integer)                                  '����STNo.
    Private mFUPDATE_DT As Nullable(Of Date)                                     '�X�V����
    Private mXBERTH_GROUP As Nullable(Of Integer)                                '�ް���ٰ��
    Private mXTUMI_HOUKOU As Nullable(Of Integer)                                '�ύ�����
    Private mXEQ_ID_B_SYABAN As String                                           '�Ԕԕ\��
#End Region
#Region "  �����è��`                  "
    ''' <summary>
    ''' ���ѕϐ� (���׽�^�z��)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_XSTS_BERTH()
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
    ''' �ް�No.
    ''' </summary>
    Public Property XBERTH_NO() As String
        Get
            Return mXBERTH_NO
        End Get
        Set(ByVal Value As String)
            mXBERTH_NO = Value
        End Set
    End Property
    ''' <summary>
    ''' �o�ד�
    ''' </summary>
    Public Property XSYUKKA_D() As Nullable(Of Date)
        Get
            Return mXSYUKKA_D
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mXSYUKKA_D = Value
        End Set
    End Property
    ''' <summary>
    ''' �Ґ�No.
    ''' </summary>
    Public Property XHENSEI_NO() As String
        Get
            Return mXHENSEI_NO
        End Get
        Set(ByVal Value As String)
            mXHENSEI_NO = Value
        End Set
    End Property
    ''' <summary>
    ''' �א�1�o�ד�
    ''' </summary>
    Public Property XSYUKKA_D_RIN1() As Nullable(Of Date)
        Get
            Return mXSYUKKA_D_RIN1
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mXSYUKKA_D_RIN1 = Value
        End Set
    End Property
    ''' <summary>
    ''' �א�1�e�Ґ�No.
    ''' </summary>
    Public Property XHENSEI_NO_OYA_RIN1() As String
        Get
            Return mXHENSEI_NO_OYA_RIN1
        End Get
        Set(ByVal Value As String)
            mXHENSEI_NO_OYA_RIN1 = Value
        End Set
    End Property
    ''' <summary>
    ''' �א�2�o�ד�
    ''' </summary>
    Public Property XSYUKKA_D_RIN2() As Nullable(Of Date)
        Get
            Return mXSYUKKA_D_RIN2
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mXSYUKKA_D_RIN2 = Value
        End Set
    End Property
    ''' <summary>
    ''' �א�2�e�Ґ�No.
    ''' </summary>
    Public Property XHENSEI_NO_OYA_RIN2() As String
        Get
            Return mXHENSEI_NO_OYA_RIN2
        End Get
        Set(ByVal Value As String)
            mXHENSEI_NO_OYA_RIN2 = Value
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
    ''' �ް��p�r
    ''' </summary>
    Public Property XBERTH_YOUTO() As Nullable(Of Integer)
        Get
            Return mXBERTH_YOUTO
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXBERTH_YOUTO = Value
        End Set
    End Property
    ''' <summary>
    ''' �ް�������_���
    ''' </summary>
    Public Property XBRTH_PRI_BARA() As Nullable(Of Integer)
        Get
            Return mXBRTH_PRI_BARA
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXBRTH_PRI_BARA = Value
        End Set
    End Property
    ''' <summary>
    ''' �ް�������_��گ�
    ''' </summary>
    Public Property XBRTH_PRI_PALE() As Nullable(Of Integer)
        Get
            Return mXBRTH_PRI_PALE
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXBRTH_PRI_PALE = Value
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
    ''' �ް��g�p��
    ''' </summary>
    Public Property XBERTH_STS() As Nullable(Of Integer)
        Get
            Return mXBERTH_STS
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXBERTH_STS = Value
        End Set
    End Property
    ''' <summary>
    ''' ����STNo.
    ''' </summary>
    Public Property XSTNO_HIKI() As Nullable(Of Integer)
        Get
            Return mXSTNO_HIKI
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXSTNO_HIKI = Value
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
    ''' <summary>
    ''' �ύ�����
    ''' </summary>
    Public Property XTUMI_HOUKOU() As Nullable(Of Integer)
        Get
            Return mXTUMI_HOUKOU
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXTUMI_HOUKOU = Value
        End Set
    End Property
    ''' <summary>
    ''' �Ԕԕ\��
    ''' </summary>
    Public Property XEQ_ID_B_SYABAN() As String
        Get
            Return mXEQ_ID_B_SYABAN
        End Get
        Set(ByVal Value As String)
            mXEQ_ID_B_SYABAN = Value
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
    Public Function GET_XSTS_BERTH(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    XSTS_BERTH")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XBERTH_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_NO
            strSQL.Append(vbCrLf & "    AND XBERTH_NO = :" & UBound(strBindField) - 1 & " --�ް�No.")
        End If
        If IsNull(XSYUKKA_D) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D = :" & UBound(strBindField) - 1 & " --�o�ד�")
        End If
        If IsNull(XHENSEI_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO = :" & UBound(strBindField) - 1 & " --�Ґ�No.")
        End If
        If IsNull(XSYUKKA_D_RIN1) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D_RIN1
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D_RIN1 = :" & UBound(strBindField) - 1 & " --�א�1�o�ד�")
        End If
        If IsNull(XHENSEI_NO_OYA_RIN1) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA_RIN1
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO_OYA_RIN1 = :" & UBound(strBindField) - 1 & " --�א�1�e�Ґ�No.")
        End If
        If IsNull(XSYUKKA_D_RIN2) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D_RIN2
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D_RIN2 = :" & UBound(strBindField) - 1 & " --�א�2�o�ד�")
        End If
        If IsNull(XHENSEI_NO_OYA_RIN2) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA_RIN2
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO_OYA_RIN2 = :" & UBound(strBindField) - 1 & " --�א�2�e�Ґ�No.")
        End If
        If IsNull(FEQ_LOCATION) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_LOCATION
            strSQL.Append(vbCrLf & "    AND FEQ_LOCATION = :" & UBound(strBindField) - 1 & " --�ݔ�۹����")
        End If
        If IsNull(XBERTH_YOUTO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_YOUTO
            strSQL.Append(vbCrLf & "    AND XBERTH_YOUTO = :" & UBound(strBindField) - 1 & " --�ް��p�r")
        End If
        If IsNull(XBRTH_PRI_BARA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBRTH_PRI_BARA
            strSQL.Append(vbCrLf & "    AND XBRTH_PRI_BARA = :" & UBound(strBindField) - 1 & " --�ް�������_���")
        End If
        If IsNull(XBRTH_PRI_PALE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBRTH_PRI_PALE
            strSQL.Append(vbCrLf & "    AND XBRTH_PRI_PALE = :" & UBound(strBindField) - 1 & " --�ް�������_��گ�")
        End If
        If IsNull(FEQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --�ݔ�ID")
        End If
        If IsNull(XBERTH_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_STS
            strSQL.Append(vbCrLf & "    AND XBERTH_STS = :" & UBound(strBindField) - 1 & " --�ް��g�p��")
        End If
        If IsNull(XSTNO_HIKI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSTNO_HIKI
            strSQL.Append(vbCrLf & "    AND XSTNO_HIKI = :" & UBound(strBindField) - 1 & " --����STNo.")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --�X�V����")
        End If
        If IsNull(XBERTH_GROUP) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_GROUP
            strSQL.Append(vbCrLf & "    AND XBERTH_GROUP = :" & UBound(strBindField) - 1 & " --�ް���ٰ��")
        End If
        If IsNull(XTUMI_HOUKOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_HOUKOU
            strSQL.Append(vbCrLf & "    AND XTUMI_HOUKOU = :" & UBound(strBindField) - 1 & " --�ύ�����")
        End If
        If IsNull(XEQ_ID_B_SYABAN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_SYABAN
            strSQL.Append(vbCrLf & "    AND XEQ_ID_B_SYABAN = :" & UBound(strBindField) - 1 & " --�Ԕԕ\��")
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
        strDataSetName = "XSTS_BERTH"
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
    Public Function GET_XSTS_BERTH_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    XSTS_BERTH")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XBERTH_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_NO
            strSQL.Append(vbCrLf & "    AND XBERTH_NO = :" & UBound(strBindField) - 1 & " --�ް�No.")
        End If
        If IsNull(XSYUKKA_D) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D = :" & UBound(strBindField) - 1 & " --�o�ד�")
        End If
        If IsNull(XHENSEI_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO = :" & UBound(strBindField) - 1 & " --�Ґ�No.")
        End If
        If IsNull(XSYUKKA_D_RIN1) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D_RIN1
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D_RIN1 = :" & UBound(strBindField) - 1 & " --�א�1�o�ד�")
        End If
        If IsNull(XHENSEI_NO_OYA_RIN1) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA_RIN1
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO_OYA_RIN1 = :" & UBound(strBindField) - 1 & " --�א�1�e�Ґ�No.")
        End If
        If IsNull(XSYUKKA_D_RIN2) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D_RIN2
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D_RIN2 = :" & UBound(strBindField) - 1 & " --�א�2�o�ד�")
        End If
        If IsNull(XHENSEI_NO_OYA_RIN2) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA_RIN2
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO_OYA_RIN2 = :" & UBound(strBindField) - 1 & " --�א�2�e�Ґ�No.")
        End If
        If IsNull(FEQ_LOCATION) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_LOCATION
            strSQL.Append(vbCrLf & "    AND FEQ_LOCATION = :" & UBound(strBindField) - 1 & " --�ݔ�۹����")
        End If
        If IsNull(XBERTH_YOUTO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_YOUTO
            strSQL.Append(vbCrLf & "    AND XBERTH_YOUTO = :" & UBound(strBindField) - 1 & " --�ް��p�r")
        End If
        If IsNull(XBRTH_PRI_BARA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBRTH_PRI_BARA
            strSQL.Append(vbCrLf & "    AND XBRTH_PRI_BARA = :" & UBound(strBindField) - 1 & " --�ް�������_���")
        End If
        If IsNull(XBRTH_PRI_PALE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBRTH_PRI_PALE
            strSQL.Append(vbCrLf & "    AND XBRTH_PRI_PALE = :" & UBound(strBindField) - 1 & " --�ް�������_��گ�")
        End If
        If IsNull(FEQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --�ݔ�ID")
        End If
        If IsNull(XBERTH_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_STS
            strSQL.Append(vbCrLf & "    AND XBERTH_STS = :" & UBound(strBindField) - 1 & " --�ް��g�p��")
        End If
        If IsNull(XSTNO_HIKI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSTNO_HIKI
            strSQL.Append(vbCrLf & "    AND XSTNO_HIKI = :" & UBound(strBindField) - 1 & " --����STNo.")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --�X�V����")
        End If
        If IsNull(XBERTH_GROUP) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_GROUP
            strSQL.Append(vbCrLf & "    AND XBERTH_GROUP = :" & UBound(strBindField) - 1 & " --�ް���ٰ��")
        End If
        If IsNull(XTUMI_HOUKOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_HOUKOU
            strSQL.Append(vbCrLf & "    AND XTUMI_HOUKOU = :" & UBound(strBindField) - 1 & " --�ύ�����")
        End If
        If IsNull(XEQ_ID_B_SYABAN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_SYABAN
            strSQL.Append(vbCrLf & "    AND XEQ_ID_B_SYABAN = :" & UBound(strBindField) - 1 & " --�Ԕԕ\��")
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
        strDataSetName = "XSTS_BERTH"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XSTS_BERTH(Owner, objDb, objDbLog)
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
    Public Function GET_XSTS_BERTH_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "XSTS_BERTH"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XSTS_BERTH(Owner, objDb, objDbLog)
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
    Public Function GET_XSTS_BERTH_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    XSTS_BERTH")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XBERTH_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_NO
            strSQL.Append(vbCrLf & "    AND XBERTH_NO = :" & UBound(strBindField) - 1 & " --�ް�No.")
        End If
        If IsNull(XSYUKKA_D) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D = :" & UBound(strBindField) - 1 & " --�o�ד�")
        End If
        If IsNull(XHENSEI_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO = :" & UBound(strBindField) - 1 & " --�Ґ�No.")
        End If
        If IsNull(XSYUKKA_D_RIN1) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D_RIN1
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D_RIN1 = :" & UBound(strBindField) - 1 & " --�א�1�o�ד�")
        End If
        If IsNull(XHENSEI_NO_OYA_RIN1) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA_RIN1
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO_OYA_RIN1 = :" & UBound(strBindField) - 1 & " --�א�1�e�Ґ�No.")
        End If
        If IsNull(XSYUKKA_D_RIN2) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D_RIN2
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D_RIN2 = :" & UBound(strBindField) - 1 & " --�א�2�o�ד�")
        End If
        If IsNull(XHENSEI_NO_OYA_RIN2) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA_RIN2
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO_OYA_RIN2 = :" & UBound(strBindField) - 1 & " --�א�2�e�Ґ�No.")
        End If
        If IsNull(FEQ_LOCATION) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_LOCATION
            strSQL.Append(vbCrLf & "    AND FEQ_LOCATION = :" & UBound(strBindField) - 1 & " --�ݔ�۹����")
        End If
        If IsNull(XBERTH_YOUTO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_YOUTO
            strSQL.Append(vbCrLf & "    AND XBERTH_YOUTO = :" & UBound(strBindField) - 1 & " --�ް��p�r")
        End If
        If IsNull(XBRTH_PRI_BARA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBRTH_PRI_BARA
            strSQL.Append(vbCrLf & "    AND XBRTH_PRI_BARA = :" & UBound(strBindField) - 1 & " --�ް�������_���")
        End If
        If IsNull(XBRTH_PRI_PALE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBRTH_PRI_PALE
            strSQL.Append(vbCrLf & "    AND XBRTH_PRI_PALE = :" & UBound(strBindField) - 1 & " --�ް�������_��گ�")
        End If
        If IsNull(FEQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --�ݔ�ID")
        End If
        If IsNull(XBERTH_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_STS
            strSQL.Append(vbCrLf & "    AND XBERTH_STS = :" & UBound(strBindField) - 1 & " --�ް��g�p��")
        End If
        If IsNull(XSTNO_HIKI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSTNO_HIKI
            strSQL.Append(vbCrLf & "    AND XSTNO_HIKI = :" & UBound(strBindField) - 1 & " --����STNo.")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --�X�V����")
        End If
        If IsNull(XBERTH_GROUP) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_GROUP
            strSQL.Append(vbCrLf & "    AND XBERTH_GROUP = :" & UBound(strBindField) - 1 & " --�ް���ٰ��")
        End If
        If IsNull(XTUMI_HOUKOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_HOUKOU
            strSQL.Append(vbCrLf & "    AND XTUMI_HOUKOU = :" & UBound(strBindField) - 1 & " --�ύ�����")
        End If
        If IsNull(XEQ_ID_B_SYABAN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_SYABAN
            strSQL.Append(vbCrLf & "    AND XEQ_ID_B_SYABAN = :" & UBound(strBindField) - 1 & " --�Ԕԕ\��")
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
        strDataSetName = "XSTS_BERTH"
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
    Public Sub UPDATE_XSTS_BERTH()
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
        ElseIf IsNull(mXBERTH_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�ް�No.]"
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
        strSQL.Append(vbCrLf & "    XSTS_BERTH")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
        If IsNull(mXBERTH_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XBERTH_NO = NULL --�ް�No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XBERTH_NO = NULL --�ް�No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XBERTH_NO = :" & Ubound(strBindField) - 1 & " --�ް�No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XBERTH_NO = :" & Ubound(strBindField) - 1 & " --�ް�No.")
        End If
        intCount = intCount + 1
        If IsNull(mXSYUKKA_D) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_D = NULL --�o�ד�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_D = NULL --�o�ד�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_D = :" & Ubound(strBindField) - 1 & " --�o�ד�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_D = :" & Ubound(strBindField) - 1 & " --�o�ד�")
        End If
        intCount = intCount + 1
        If IsNull(mXHENSEI_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XHENSEI_NO = NULL --�Ґ�No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XHENSEI_NO = NULL --�Ґ�No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XHENSEI_NO = :" & Ubound(strBindField) - 1 & " --�Ґ�No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XHENSEI_NO = :" & Ubound(strBindField) - 1 & " --�Ґ�No.")
        End If
        intCount = intCount + 1
        If IsNull(mXSYUKKA_D_RIN1) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_D_RIN1 = NULL --�א�1�o�ד�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_D_RIN1 = NULL --�א�1�o�ד�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D_RIN1
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_D_RIN1 = :" & Ubound(strBindField) - 1 & " --�א�1�o�ד�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_D_RIN1 = :" & Ubound(strBindField) - 1 & " --�א�1�o�ד�")
        End If
        intCount = intCount + 1
        If IsNull(mXHENSEI_NO_OYA_RIN1) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XHENSEI_NO_OYA_RIN1 = NULL --�א�1�e�Ґ�No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XHENSEI_NO_OYA_RIN1 = NULL --�א�1�e�Ґ�No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA_RIN1
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XHENSEI_NO_OYA_RIN1 = :" & Ubound(strBindField) - 1 & " --�א�1�e�Ґ�No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XHENSEI_NO_OYA_RIN1 = :" & Ubound(strBindField) - 1 & " --�א�1�e�Ґ�No.")
        End If
        intCount = intCount + 1
        If IsNull(mXSYUKKA_D_RIN2) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_D_RIN2 = NULL --�א�2�o�ד�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_D_RIN2 = NULL --�א�2�o�ד�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D_RIN2
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_D_RIN2 = :" & Ubound(strBindField) - 1 & " --�א�2�o�ד�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_D_RIN2 = :" & Ubound(strBindField) - 1 & " --�א�2�o�ד�")
        End If
        intCount = intCount + 1
        If IsNull(mXHENSEI_NO_OYA_RIN2) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XHENSEI_NO_OYA_RIN2 = NULL --�א�2�e�Ґ�No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XHENSEI_NO_OYA_RIN2 = NULL --�א�2�e�Ґ�No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA_RIN2
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XHENSEI_NO_OYA_RIN2 = :" & Ubound(strBindField) - 1 & " --�א�2�e�Ґ�No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XHENSEI_NO_OYA_RIN2 = :" & Ubound(strBindField) - 1 & " --�א�2�e�Ґ�No.")
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
        If IsNull(mXBERTH_YOUTO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XBERTH_YOUTO = NULL --�ް��p�r")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XBERTH_YOUTO = NULL --�ް��p�r")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_YOUTO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XBERTH_YOUTO = :" & Ubound(strBindField) - 1 & " --�ް��p�r")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XBERTH_YOUTO = :" & Ubound(strBindField) - 1 & " --�ް��p�r")
        End If
        intCount = intCount + 1
        If IsNull(mXBRTH_PRI_BARA) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XBRTH_PRI_BARA = NULL --�ް�������_���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XBRTH_PRI_BARA = NULL --�ް�������_���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBRTH_PRI_BARA
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XBRTH_PRI_BARA = :" & Ubound(strBindField) - 1 & " --�ް�������_���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XBRTH_PRI_BARA = :" & Ubound(strBindField) - 1 & " --�ް�������_���")
        End If
        intCount = intCount + 1
        If IsNull(mXBRTH_PRI_PALE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XBRTH_PRI_PALE = NULL --�ް�������_��گ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XBRTH_PRI_PALE = NULL --�ް�������_��گ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBRTH_PRI_PALE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XBRTH_PRI_PALE = :" & Ubound(strBindField) - 1 & " --�ް�������_��گ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XBRTH_PRI_PALE = :" & Ubound(strBindField) - 1 & " --�ް�������_��گ�")
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
        If IsNull(mXBERTH_STS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XBERTH_STS = NULL --�ް��g�p��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XBERTH_STS = NULL --�ް��g�p��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_STS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XBERTH_STS = :" & Ubound(strBindField) - 1 & " --�ް��g�p��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XBERTH_STS = :" & Ubound(strBindField) - 1 & " --�ް��g�p��")
        End If
        intCount = intCount + 1
        If IsNull(mXSTNO_HIKI) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSTNO_HIKI = NULL --����STNo.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSTNO_HIKI = NULL --����STNo.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSTNO_HIKI
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSTNO_HIKI = :" & Ubound(strBindField) - 1 & " --����STNo.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSTNO_HIKI = :" & Ubound(strBindField) - 1 & " --����STNo.")
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
        If IsNull(mXTUMI_HOUKOU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTUMI_HOUKOU = NULL --�ύ�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTUMI_HOUKOU = NULL --�ύ�����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_HOUKOU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTUMI_HOUKOU = :" & Ubound(strBindField) - 1 & " --�ύ�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTUMI_HOUKOU = :" & Ubound(strBindField) - 1 & " --�ύ�����")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_B_SYABAN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_B_SYABAN = NULL --�Ԕԕ\��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_B_SYABAN = NULL --�Ԕԕ\��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_SYABAN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_B_SYABAN = :" & Ubound(strBindField) - 1 & " --�Ԕԕ\��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_B_SYABAN = :" & Ubound(strBindField) - 1 & " --�Ԕԕ\��")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(XBERTH_NO) = True Then
            strSQL.Append(vbCrLf & "    AND XBERTH_NO IS NULL --�ް�No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_NO
            strSQL.Append(vbCrLf & "    AND XBERTH_NO = :" & UBound(strBindField) - 1 & " --�ް�No.")
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
    Public Sub ADD_XSTS_BERTH()
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
        ElseIf IsNull(mXBERTH_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�ް�No.]"
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
        strSQL.Append(vbCrLf & "    XSTS_BERTH")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
        If IsNull(mXBERTH_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ް�No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ް�No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ް�No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ް�No.")
        End If
        intCount = intCount + 1
        If IsNull(mXSYUKKA_D) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�o�ד�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�o�ד�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�o�ד�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�o�ד�")
        End If
        intCount = intCount + 1
        If IsNull(mXHENSEI_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�Ґ�No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�Ґ�No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�Ґ�No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�Ґ�No.")
        End If
        intCount = intCount + 1
        If IsNull(mXSYUKKA_D_RIN1) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�א�1�o�ד�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�א�1�o�ד�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D_RIN1
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�א�1�o�ד�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�א�1�o�ד�")
        End If
        intCount = intCount + 1
        If IsNull(mXHENSEI_NO_OYA_RIN1) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�א�1�e�Ґ�No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�א�1�e�Ґ�No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA_RIN1
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�א�1�e�Ґ�No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�א�1�e�Ґ�No.")
        End If
        intCount = intCount + 1
        If IsNull(mXSYUKKA_D_RIN2) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�א�2�o�ד�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�א�2�o�ד�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D_RIN2
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�א�2�o�ד�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�א�2�o�ד�")
        End If
        intCount = intCount + 1
        If IsNull(mXHENSEI_NO_OYA_RIN2) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�א�2�e�Ґ�No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�א�2�e�Ґ�No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA_RIN2
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�א�2�e�Ґ�No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�א�2�e�Ґ�No.")
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
        If IsNull(mXBERTH_YOUTO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ް��p�r")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ް��p�r")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_YOUTO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ް��p�r")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ް��p�r")
        End If
        intCount = intCount + 1
        If IsNull(mXBRTH_PRI_BARA) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ް�������_���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ް�������_���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBRTH_PRI_BARA
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ް�������_���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ް�������_���")
        End If
        intCount = intCount + 1
        If IsNull(mXBRTH_PRI_PALE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ް�������_��گ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ް�������_��گ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBRTH_PRI_PALE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ް�������_��گ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ް�������_��گ�")
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
        If IsNull(mXBERTH_STS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ް��g�p��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ް��g�p��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_STS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ް��g�p��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ް��g�p��")
        End If
        intCount = intCount + 1
        If IsNull(mXSTNO_HIKI) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����STNo.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����STNo.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSTNO_HIKI
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����STNo.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����STNo.")
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
        If IsNull(mXTUMI_HOUKOU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ύ�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ύ�����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_HOUKOU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ύ�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ύ�����")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_B_SYABAN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�Ԕԕ\��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�Ԕԕ\��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_SYABAN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�Ԕԕ\��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�Ԕԕ\��")
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
    Public Sub DELETE_XSTS_BERTH()
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
        ElseIf IsNull(mXBERTH_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�ް�No.]"
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
        strSQL.Append(vbCrLf & "    XSTS_BERTH")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(XBERTH_NO) = True Then
            strSQL.Append(vbCrLf & "    AND XBERTH_NO IS NULL --�ް�No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_NO
            strSQL.Append(vbCrLf & "    AND XBERTH_NO = :" & UBound(strBindField) - 1 & " --�ް�No.")
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
    Public Sub DELETE_XSTS_BERTH_ANY()
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
        strSQL.Append(vbCrLf & "    XSTS_BERTH")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(XBERTH_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_NO
            strSQL.Append(vbCrLf & "    AND XBERTH_NO = :" & UBound(strBindField) - 1 & " --�ް�No.")
        End If
        If IsNotNull(XSYUKKA_D) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D = :" & UBound(strBindField) - 1 & " --�o�ד�")
        End If
        If IsNotNull(XHENSEI_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO = :" & UBound(strBindField) - 1 & " --�Ґ�No.")
        End If
        If IsNotNull(XSYUKKA_D_RIN1) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D_RIN1
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D_RIN1 = :" & UBound(strBindField) - 1 & " --�א�1�o�ד�")
        End If
        If IsNotNull(XHENSEI_NO_OYA_RIN1) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA_RIN1
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO_OYA_RIN1 = :" & UBound(strBindField) - 1 & " --�א�1�e�Ґ�No.")
        End If
        If IsNotNull(XSYUKKA_D_RIN2) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D_RIN2
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D_RIN2 = :" & UBound(strBindField) - 1 & " --�א�2�o�ד�")
        End If
        If IsNotNull(XHENSEI_NO_OYA_RIN2) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA_RIN2
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO_OYA_RIN2 = :" & UBound(strBindField) - 1 & " --�א�2�e�Ґ�No.")
        End If
        If IsNotNull(FEQ_LOCATION) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_LOCATION
            strSQL.Append(vbCrLf & "    AND FEQ_LOCATION = :" & UBound(strBindField) - 1 & " --�ݔ�۹����")
        End If
        If IsNotNull(XBERTH_YOUTO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_YOUTO
            strSQL.Append(vbCrLf & "    AND XBERTH_YOUTO = :" & UBound(strBindField) - 1 & " --�ް��p�r")
        End If
        If IsNotNull(XBRTH_PRI_BARA) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBRTH_PRI_BARA
            strSQL.Append(vbCrLf & "    AND XBRTH_PRI_BARA = :" & UBound(strBindField) - 1 & " --�ް�������_���")
        End If
        If IsNotNull(XBRTH_PRI_PALE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBRTH_PRI_PALE
            strSQL.Append(vbCrLf & "    AND XBRTH_PRI_PALE = :" & UBound(strBindField) - 1 & " --�ް�������_��گ�")
        End If
        If IsNotNull(FEQ_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --�ݔ�ID")
        End If
        If IsNotNull(XBERTH_STS) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_STS
            strSQL.Append(vbCrLf & "    AND XBERTH_STS = :" & UBound(strBindField) - 1 & " --�ް��g�p��")
        End If
        If IsNotNull(XSTNO_HIKI) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSTNO_HIKI
            strSQL.Append(vbCrLf & "    AND XSTNO_HIKI = :" & UBound(strBindField) - 1 & " --����STNo.")
        End If
        If IsNotNull(FUPDATE_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --�X�V����")
        End If
        If IsNotNull(XBERTH_GROUP) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_GROUP
            strSQL.Append(vbCrLf & "    AND XBERTH_GROUP = :" & UBound(strBindField) - 1 & " --�ް���ٰ��")
        End If
        If IsNotNull(XTUMI_HOUKOU) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_HOUKOU
            strSQL.Append(vbCrLf & "    AND XTUMI_HOUKOU = :" & UBound(strBindField) - 1 & " --�ύ�����")
        End If
        If IsNotNull(XEQ_ID_B_SYABAN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_SYABAN
            strSQL.Append(vbCrLf & "    AND XEQ_ID_B_SYABAN = :" & UBound(strBindField) - 1 & " --�Ԕԕ\��")
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
        If IsNothing(objType.GetProperty("XBERTH_NO")) = False Then mXBERTH_NO = objObject.XBERTH_NO '�ް�No.
        If IsNothing(objType.GetProperty("XSYUKKA_D")) = False Then mXSYUKKA_D = objObject.XSYUKKA_D '�o�ד�
        If IsNothing(objType.GetProperty("XHENSEI_NO")) = False Then mXHENSEI_NO = objObject.XHENSEI_NO '�Ґ�No.
        If IsNothing(objType.GetProperty("XSYUKKA_D_RIN1")) = False Then mXSYUKKA_D_RIN1 = objObject.XSYUKKA_D_RIN1 '�א�1�o�ד�
        If IsNothing(objType.GetProperty("XHENSEI_NO_OYA_RIN1")) = False Then mXHENSEI_NO_OYA_RIN1 = objObject.XHENSEI_NO_OYA_RIN1 '�א�1�e�Ґ�No.
        If IsNothing(objType.GetProperty("XSYUKKA_D_RIN2")) = False Then mXSYUKKA_D_RIN2 = objObject.XSYUKKA_D_RIN2 '�א�2�o�ד�
        If IsNothing(objType.GetProperty("XHENSEI_NO_OYA_RIN2")) = False Then mXHENSEI_NO_OYA_RIN2 = objObject.XHENSEI_NO_OYA_RIN2 '�א�2�e�Ґ�No.
        If IsNothing(objType.GetProperty("FEQ_LOCATION")) = False Then mFEQ_LOCATION = objObject.FEQ_LOCATION '�ݔ�۹����
        If IsNothing(objType.GetProperty("XBERTH_YOUTO")) = False Then mXBERTH_YOUTO = objObject.XBERTH_YOUTO '�ް��p�r
        If IsNothing(objType.GetProperty("XBRTH_PRI_BARA")) = False Then mXBRTH_PRI_BARA = objObject.XBRTH_PRI_BARA '�ް�������_���
        If IsNothing(objType.GetProperty("XBRTH_PRI_PALE")) = False Then mXBRTH_PRI_PALE = objObject.XBRTH_PRI_PALE '�ް�������_��گ�
        If IsNothing(objType.GetProperty("FEQ_ID")) = False Then mFEQ_ID = objObject.FEQ_ID '�ݔ�ID
        If IsNothing(objType.GetProperty("XBERTH_STS")) = False Then mXBERTH_STS = objObject.XBERTH_STS '�ް��g�p��
        If IsNothing(objType.GetProperty("XSTNO_HIKI")) = False Then mXSTNO_HIKI = objObject.XSTNO_HIKI '����STNo.
        If IsNothing(objType.GetProperty("FUPDATE_DT")) = False Then mFUPDATE_DT = objObject.FUPDATE_DT '�X�V����
        If IsNothing(objType.GetProperty("XBERTH_GROUP")) = False Then mXBERTH_GROUP = objObject.XBERTH_GROUP '�ް���ٰ��
        If IsNothing(objType.GetProperty("XTUMI_HOUKOU")) = False Then mXTUMI_HOUKOU = objObject.XTUMI_HOUKOU '�ύ�����
        If IsNothing(objType.GetProperty("XEQ_ID_B_SYABAN")) = False Then mXEQ_ID_B_SYABAN = objObject.XEQ_ID_B_SYABAN '�Ԕԕ\��

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
        mXBERTH_NO = Nothing
        mXSYUKKA_D = Nothing
        mXHENSEI_NO = Nothing
        mXSYUKKA_D_RIN1 = Nothing
        mXHENSEI_NO_OYA_RIN1 = Nothing
        mXSYUKKA_D_RIN2 = Nothing
        mXHENSEI_NO_OYA_RIN2 = Nothing
        mFEQ_LOCATION = Nothing
        mXBERTH_YOUTO = Nothing
        mXBRTH_PRI_BARA = Nothing
        mXBRTH_PRI_PALE = Nothing
        mFEQ_ID = Nothing
        mXBERTH_STS = Nothing
        mXSTNO_HIKI = Nothing
        mFUPDATE_DT = Nothing
        mXBERTH_GROUP = Nothing
        mXTUMI_HOUKOU = Nothing
        mXEQ_ID_B_SYABAN = Nothing


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
        mXBERTH_NO = TO_STRING_NULLABLE(objRow("XBERTH_NO"))
        mXSYUKKA_D = TO_DATE_NULLABLE(objRow("XSYUKKA_D"))
        mXHENSEI_NO = TO_STRING_NULLABLE(objRow("XHENSEI_NO"))
        mXSYUKKA_D_RIN1 = TO_DATE_NULLABLE(objRow("XSYUKKA_D_RIN1"))
        mXHENSEI_NO_OYA_RIN1 = TO_STRING_NULLABLE(objRow("XHENSEI_NO_OYA_RIN1"))
        mXSYUKKA_D_RIN2 = TO_DATE_NULLABLE(objRow("XSYUKKA_D_RIN2"))
        mXHENSEI_NO_OYA_RIN2 = TO_STRING_NULLABLE(objRow("XHENSEI_NO_OYA_RIN2"))
        mFEQ_LOCATION = TO_INTEGER_NULLABLE(objRow("FEQ_LOCATION"))
        mXBERTH_YOUTO = TO_INTEGER_NULLABLE(objRow("XBERTH_YOUTO"))
        mXBRTH_PRI_BARA = TO_INTEGER_NULLABLE(objRow("XBRTH_PRI_BARA"))
        mXBRTH_PRI_PALE = TO_INTEGER_NULLABLE(objRow("XBRTH_PRI_PALE"))
        mFEQ_ID = TO_STRING_NULLABLE(objRow("FEQ_ID"))
        mXBERTH_STS = TO_INTEGER_NULLABLE(objRow("XBERTH_STS"))
        mXSTNO_HIKI = TO_INTEGER_NULLABLE(objRow("XSTNO_HIKI"))
        mFUPDATE_DT = TO_DATE_NULLABLE(objRow("FUPDATE_DT"))
        mXBERTH_GROUP = TO_INTEGER_NULLABLE(objRow("XBERTH_GROUP"))
        mXTUMI_HOUKOU = TO_INTEGER_NULLABLE(objRow("XTUMI_HOUKOU"))
        mXEQ_ID_B_SYABAN = TO_STRING_NULLABLE(objRow("XEQ_ID_B_SYABAN"))


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
        strMsg &= "[ð��ٖ�:�o���ް���]"
        If IsNotNull(XBERTH_NO) Then
            strMsg &= "[�ް�No.:" & XBERTH_NO & "]"
        End If
        If IsNotNull(XSYUKKA_D) Then
            strMsg &= "[�o�ד�:" & XSYUKKA_D & "]"
        End If
        If IsNotNull(XHENSEI_NO) Then
            strMsg &= "[�Ґ�No.:" & XHENSEI_NO & "]"
        End If
        If IsNotNull(XSYUKKA_D_RIN1) Then
            strMsg &= "[�א�1�o�ד�:" & XSYUKKA_D_RIN1 & "]"
        End If
        If IsNotNull(XHENSEI_NO_OYA_RIN1) Then
            strMsg &= "[�א�1�e�Ґ�No.:" & XHENSEI_NO_OYA_RIN1 & "]"
        End If
        If IsNotNull(XSYUKKA_D_RIN2) Then
            strMsg &= "[�א�2�o�ד�:" & XSYUKKA_D_RIN2 & "]"
        End If
        If IsNotNull(XHENSEI_NO_OYA_RIN2) Then
            strMsg &= "[�א�2�e�Ґ�No.:" & XHENSEI_NO_OYA_RIN2 & "]"
        End If
        If IsNotNull(FEQ_LOCATION) Then
            strMsg &= "[�ݔ�۹����:" & FEQ_LOCATION & "]"
        End If
        If IsNotNull(XBERTH_YOUTO) Then
            strMsg &= "[�ް��p�r:" & XBERTH_YOUTO & "]"
        End If
        If IsNotNull(XBRTH_PRI_BARA) Then
            strMsg &= "[�ް�������_���:" & XBRTH_PRI_BARA & "]"
        End If
        If IsNotNull(XBRTH_PRI_PALE) Then
            strMsg &= "[�ް�������_��گ�:" & XBRTH_PRI_PALE & "]"
        End If
        If IsNotNull(FEQ_ID) Then
            strMsg &= "[�ݔ�ID:" & FEQ_ID & "]"
        End If
        If IsNotNull(XBERTH_STS) Then
            strMsg &= "[�ް��g�p��:" & XBERTH_STS & "]"
        End If
        If IsNotNull(XSTNO_HIKI) Then
            strMsg &= "[����STNo.:" & XSTNO_HIKI & "]"
        End If
        If IsNotNull(FUPDATE_DT) Then
            strMsg &= "[�X�V����:" & FUPDATE_DT & "]"
        End If
        If IsNotNull(XBERTH_GROUP) Then
            strMsg &= "[�ް���ٰ��:" & XBERTH_GROUP & "]"
        End If
        If IsNotNull(XTUMI_HOUKOU) Then
            strMsg &= "[�ύ�����:" & XTUMI_HOUKOU & "]"
        End If
        If IsNotNull(XEQ_ID_B_SYABAN) Then
            strMsg &= "[�Ԕԕ\��:" & XEQ_ID_B_SYABAN & "]"
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
