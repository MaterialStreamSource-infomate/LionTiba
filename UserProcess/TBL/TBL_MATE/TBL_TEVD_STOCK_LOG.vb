'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' �y���́zMaterialStreamð��ٸ׽
' �y�@�\�z�݌ɍX�V����ð��ٸ׽
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
''' �݌ɍX�V����ð��ٸ׽
''' </summary>
Public Class TBL_TEVD_STOCK_LOG
    Inherits clsTemplateTable

    '**********************************************************************************************
    '����������������
#Region "  �׽�ϐ���`                  "
    '�����è
    Private mobjAryMe As TBL_TEVD_STOCK_LOG()                                    '�݌ɍX�V����
    Private mstrUSER_SQL As String                                               'հ�ްSQL
    Private mORDER_BY As String                                                  'OrderBy��
    Private mWHERE As String                                                     'Where��
    Private mFLOG_NO As String                                                   '۸އ�
    Private mFENTRY_DT As Nullable(Of Date)                                      '�o�^����
    Private mFPALLET_ID As String                                                '��گ�ID
    Private mFTERM_ID As String                                                  '�[��ID
    Private mFTERM_NAME As String                                                '�[����
    Private mFUSER_ID As String                                                  'հ�ްID
    Private mFUSER_NAME As String                                                '���O
    Private mFPLACE_CD As Nullable(Of Integer)                                   '�ۊǏꏊ����
    Private mFAREA_CD As Nullable(Of Integer)                                    '�ر����
    Private mFHINMEI_CD As String                                                '�i�ں���
    Private mFHINMEI As String                                                   '�i��_������
    Private mFLOT_NO As String                                                   'ۯć�
    Private mFSAGYOU_KIND As Nullable(Of Integer)                                '��Ǝ��
    Private mFNUM_IN_CASE As Nullable(Of Decimal)                                '���ܐ���
    Private mFTANI As String                                                     '�P�ʺ���
    Private mFDECIMAL_POINT As Nullable(Of Integer)                              '�����_�ȉ��L������
    Private mFSEIHIN_KUBUN As Nullable(Of Integer)                               '���i�敪
    Private mFZAIKO_KUBUN As Nullable(Of Integer)                                '�݌ɋ敪
    Private mFHORYU_KUBUN As Nullable(Of Integer)                                '�ۗ��敪
    Private mFRECEIVEPAY_NUM As Nullable(Of Decimal)                             '�󕥐���
    Private mFZAIKO_NUM As Nullable(Of Decimal)                                  '�݌ɐ���
    Private mFSAGYOU_CONTENT As String                                           '��Ɠ��e
#End Region
#Region "  �����è��`                  "
    ''' <summary>
    ''' ���ѕϐ� (���׽�^�z��)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_TEVD_STOCK_LOG()
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
    ''' ۸އ�
    ''' </summary>
    Public Property FLOG_NO() As String
        Get
            Return mFLOG_NO
        End Get
        Set(ByVal Value As String)
            mFLOG_NO = Value
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
    ''' �[����
    ''' </summary>
    Public Property FTERM_NAME() As String
        Get
            Return mFTERM_NAME
        End Get
        Set(ByVal Value As String)
            mFTERM_NAME = Value
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
    ''' ���O
    ''' </summary>
    Public Property FUSER_NAME() As String
        Get
            Return mFUSER_NAME
        End Get
        Set(ByVal Value As String)
            mFUSER_NAME = Value
        End Set
    End Property
    ''' <summary>
    ''' �ۊǏꏊ����
    ''' </summary>
    Public Property FPLACE_CD() As Nullable(Of Integer)
        Get
            Return mFPLACE_CD
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFPLACE_CD = Value
        End Set
    End Property
    ''' <summary>
    ''' �ر����
    ''' </summary>
    Public Property FAREA_CD() As Nullable(Of Integer)
        Get
            Return mFAREA_CD
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFAREA_CD = Value
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
    ''' �i��_������
    ''' </summary>
    Public Property FHINMEI() As String
        Get
            Return mFHINMEI
        End Get
        Set(ByVal Value As String)
            mFHINMEI = Value
        End Set
    End Property
    ''' <summary>
    ''' ۯć�
    ''' </summary>
    Public Property FLOT_NO() As String
        Get
            Return mFLOT_NO
        End Get
        Set(ByVal Value As String)
            mFLOT_NO = Value
        End Set
    End Property
    ''' <summary>
    ''' ��Ǝ��
    ''' </summary>
    Public Property FSAGYOU_KIND() As Nullable(Of Integer)
        Get
            Return mFSAGYOU_KIND
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFSAGYOU_KIND = Value
        End Set
    End Property
    ''' <summary>
    ''' ���ܐ���
    ''' </summary>
    Public Property FNUM_IN_CASE() As Nullable(Of Decimal)
        Get
            Return mFNUM_IN_CASE
        End Get
        Set(ByVal Value As Nullable(Of Decimal))
            mFNUM_IN_CASE = Value
        End Set
    End Property
    ''' <summary>
    ''' �P�ʺ���
    ''' </summary>
    Public Property FTANI() As String
        Get
            Return mFTANI
        End Get
        Set(ByVal Value As String)
            mFTANI = Value
        End Set
    End Property
    ''' <summary>
    ''' �����_�ȉ��L������
    ''' </summary>
    Public Property FDECIMAL_POINT() As Nullable(Of Integer)
        Get
            Return mFDECIMAL_POINT
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFDECIMAL_POINT = Value
        End Set
    End Property
    ''' <summary>
    ''' ���i�敪
    ''' </summary>
    Public Property FSEIHIN_KUBUN() As Nullable(Of Integer)
        Get
            Return mFSEIHIN_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFSEIHIN_KUBUN = Value
        End Set
    End Property
    ''' <summary>
    ''' �݌ɋ敪
    ''' </summary>
    Public Property FZAIKO_KUBUN() As Nullable(Of Integer)
        Get
            Return mFZAIKO_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFZAIKO_KUBUN = Value
        End Set
    End Property
    ''' <summary>
    ''' �ۗ��敪
    ''' </summary>
    Public Property FHORYU_KUBUN() As Nullable(Of Integer)
        Get
            Return mFHORYU_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFHORYU_KUBUN = Value
        End Set
    End Property
    ''' <summary>
    ''' �󕥐���
    ''' </summary>
    Public Property FRECEIVEPAY_NUM() As Nullable(Of Decimal)
        Get
            Return mFRECEIVEPAY_NUM
        End Get
        Set(ByVal Value As Nullable(Of Decimal))
            mFRECEIVEPAY_NUM = Value
        End Set
    End Property
    ''' <summary>
    ''' �݌ɐ���
    ''' </summary>
    Public Property FZAIKO_NUM() As Nullable(Of Decimal)
        Get
            Return mFZAIKO_NUM
        End Get
        Set(ByVal Value As Nullable(Of Decimal))
            mFZAIKO_NUM = Value
        End Set
    End Property
    ''' <summary>
    ''' ��Ɠ��e
    ''' </summary>
    Public Property FSAGYOU_CONTENT() As String
        Get
            Return mFSAGYOU_CONTENT
        End Get
        Set(ByVal Value As String)
            mFSAGYOU_CONTENT = Value
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
    Public Function GET_TEVD_STOCK_LOG(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    TEVD_STOCK_LOG")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FLOG_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            strSQL.Append(vbCrLf & "    AND FLOG_NO = :" & UBound(strBindField) - 1 & " --۸އ�")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --�o�^����")
        End If
        If IsNull(FPALLET_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --��گ�ID")
        End If
        If IsNull(FTERM_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTERM_ID
            strSQL.Append(vbCrLf & "    AND FTERM_ID = :" & UBound(strBindField) - 1 & " --�[��ID")
        End If
        If IsNull(FTERM_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTERM_NAME
            strSQL.Append(vbCrLf & "    AND FTERM_NAME = :" & UBound(strBindField) - 1 & " --�[����")
        End If
        If IsNull(FUSER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID
            strSQL.Append(vbCrLf & "    AND FUSER_ID = :" & UBound(strBindField) - 1 & " --հ�ްID")
        End If
        If IsNull(FUSER_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME
            strSQL.Append(vbCrLf & "    AND FUSER_NAME = :" & UBound(strBindField) - 1 & " --���O")
        End If
        If IsNull(FPLACE_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLACE_CD
            strSQL.Append(vbCrLf & "    AND FPLACE_CD = :" & UBound(strBindField) - 1 & " --�ۊǏꏊ����")
        End If
        If IsNull(FAREA_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFAREA_CD
            strSQL.Append(vbCrLf & "    AND FAREA_CD = :" & UBound(strBindField) - 1 & " --�ر����")
        End If
        If IsNull(FHINMEI_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --�i�ں���")
        End If
        If IsNull(FHINMEI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI
            strSQL.Append(vbCrLf & "    AND FHINMEI = :" & UBound(strBindField) - 1 & " --�i��_������")
        End If
        If IsNull(FLOT_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO
            strSQL.Append(vbCrLf & "    AND FLOT_NO = :" & UBound(strBindField) - 1 & " --ۯć�")
        End If
        If IsNull(FSAGYOU_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_KIND
            strSQL.Append(vbCrLf & "    AND FSAGYOU_KIND = :" & UBound(strBindField) - 1 & " --��Ǝ��")
        End If
        If IsNull(FNUM_IN_CASE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFNUM_IN_CASE
            strSQL.Append(vbCrLf & "    AND FNUM_IN_CASE = :" & UBound(strBindField) - 1 & " --���ܐ���")
        End If
        If IsNull(FTANI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTANI
            strSQL.Append(vbCrLf & "    AND FTANI = :" & UBound(strBindField) - 1 & " --�P�ʺ���")
        End If
        If IsNull(FDECIMAL_POINT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDECIMAL_POINT
            strSQL.Append(vbCrLf & "    AND FDECIMAL_POINT = :" & UBound(strBindField) - 1 & " --�����_�ȉ��L������")
        End If
        If IsNull(FSEIHIN_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEIHIN_KUBUN
            strSQL.Append(vbCrLf & "    AND FSEIHIN_KUBUN = :" & UBound(strBindField) - 1 & " --���i�敪")
        End If
        If IsNull(FZAIKO_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_KUBUN
            strSQL.Append(vbCrLf & "    AND FZAIKO_KUBUN = :" & UBound(strBindField) - 1 & " --�݌ɋ敪")
        End If
        If IsNull(FHORYU_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHORYU_KUBUN
            strSQL.Append(vbCrLf & "    AND FHORYU_KUBUN = :" & UBound(strBindField) - 1 & " --�ۗ��敪")
        End If
        If IsNull(FRECEIVEPAY_NUM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRECEIVEPAY_NUM
            strSQL.Append(vbCrLf & "    AND FRECEIVEPAY_NUM = :" & UBound(strBindField) - 1 & " --�󕥐���")
        End If
        If IsNull(FZAIKO_NUM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_NUM
            strSQL.Append(vbCrLf & "    AND FZAIKO_NUM = :" & UBound(strBindField) - 1 & " --�݌ɐ���")
        End If
        If IsNull(FSAGYOU_CONTENT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_CONTENT
            strSQL.Append(vbCrLf & "    AND FSAGYOU_CONTENT = :" & UBound(strBindField) - 1 & " --��Ɠ��e")
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
        strDataSetName = "TEVD_STOCK_LOG"
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
    Public Function GET_TEVD_STOCK_LOG_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    TEVD_STOCK_LOG")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FLOG_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            strSQL.Append(vbCrLf & "    AND FLOG_NO = :" & UBound(strBindField) - 1 & " --۸އ�")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --�o�^����")
        End If
        If IsNull(FPALLET_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --��گ�ID")
        End If
        If IsNull(FTERM_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTERM_ID
            strSQL.Append(vbCrLf & "    AND FTERM_ID = :" & UBound(strBindField) - 1 & " --�[��ID")
        End If
        If IsNull(FTERM_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTERM_NAME
            strSQL.Append(vbCrLf & "    AND FTERM_NAME = :" & UBound(strBindField) - 1 & " --�[����")
        End If
        If IsNull(FUSER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID
            strSQL.Append(vbCrLf & "    AND FUSER_ID = :" & UBound(strBindField) - 1 & " --հ�ްID")
        End If
        If IsNull(FUSER_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME
            strSQL.Append(vbCrLf & "    AND FUSER_NAME = :" & UBound(strBindField) - 1 & " --���O")
        End If
        If IsNull(FPLACE_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLACE_CD
            strSQL.Append(vbCrLf & "    AND FPLACE_CD = :" & UBound(strBindField) - 1 & " --�ۊǏꏊ����")
        End If
        If IsNull(FAREA_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFAREA_CD
            strSQL.Append(vbCrLf & "    AND FAREA_CD = :" & UBound(strBindField) - 1 & " --�ر����")
        End If
        If IsNull(FHINMEI_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --�i�ں���")
        End If
        If IsNull(FHINMEI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI
            strSQL.Append(vbCrLf & "    AND FHINMEI = :" & UBound(strBindField) - 1 & " --�i��_������")
        End If
        If IsNull(FLOT_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO
            strSQL.Append(vbCrLf & "    AND FLOT_NO = :" & UBound(strBindField) - 1 & " --ۯć�")
        End If
        If IsNull(FSAGYOU_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_KIND
            strSQL.Append(vbCrLf & "    AND FSAGYOU_KIND = :" & UBound(strBindField) - 1 & " --��Ǝ��")
        End If
        If IsNull(FNUM_IN_CASE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFNUM_IN_CASE
            strSQL.Append(vbCrLf & "    AND FNUM_IN_CASE = :" & UBound(strBindField) - 1 & " --���ܐ���")
        End If
        If IsNull(FTANI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTANI
            strSQL.Append(vbCrLf & "    AND FTANI = :" & UBound(strBindField) - 1 & " --�P�ʺ���")
        End If
        If IsNull(FDECIMAL_POINT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDECIMAL_POINT
            strSQL.Append(vbCrLf & "    AND FDECIMAL_POINT = :" & UBound(strBindField) - 1 & " --�����_�ȉ��L������")
        End If
        If IsNull(FSEIHIN_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEIHIN_KUBUN
            strSQL.Append(vbCrLf & "    AND FSEIHIN_KUBUN = :" & UBound(strBindField) - 1 & " --���i�敪")
        End If
        If IsNull(FZAIKO_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_KUBUN
            strSQL.Append(vbCrLf & "    AND FZAIKO_KUBUN = :" & UBound(strBindField) - 1 & " --�݌ɋ敪")
        End If
        If IsNull(FHORYU_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHORYU_KUBUN
            strSQL.Append(vbCrLf & "    AND FHORYU_KUBUN = :" & UBound(strBindField) - 1 & " --�ۗ��敪")
        End If
        If IsNull(FRECEIVEPAY_NUM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRECEIVEPAY_NUM
            strSQL.Append(vbCrLf & "    AND FRECEIVEPAY_NUM = :" & UBound(strBindField) - 1 & " --�󕥐���")
        End If
        If IsNull(FZAIKO_NUM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_NUM
            strSQL.Append(vbCrLf & "    AND FZAIKO_NUM = :" & UBound(strBindField) - 1 & " --�݌ɐ���")
        End If
        If IsNull(FSAGYOU_CONTENT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_CONTENT
            strSQL.Append(vbCrLf & "    AND FSAGYOU_CONTENT = :" & UBound(strBindField) - 1 & " --��Ɠ��e")
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
        strDataSetName = "TEVD_STOCK_LOG"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TEVD_STOCK_LOG(Owner, objDb, objDbLog)
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
    Public Function GET_TEVD_STOCK_LOG_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "TEVD_STOCK_LOG"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TEVD_STOCK_LOG(Owner, objDb, objDbLog)
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
    Public Function GET_TEVD_STOCK_LOG_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    TEVD_STOCK_LOG")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FLOG_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            strSQL.Append(vbCrLf & "    AND FLOG_NO = :" & UBound(strBindField) - 1 & " --۸އ�")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --�o�^����")
        End If
        If IsNull(FPALLET_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --��گ�ID")
        End If
        If IsNull(FTERM_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTERM_ID
            strSQL.Append(vbCrLf & "    AND FTERM_ID = :" & UBound(strBindField) - 1 & " --�[��ID")
        End If
        If IsNull(FTERM_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTERM_NAME
            strSQL.Append(vbCrLf & "    AND FTERM_NAME = :" & UBound(strBindField) - 1 & " --�[����")
        End If
        If IsNull(FUSER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID
            strSQL.Append(vbCrLf & "    AND FUSER_ID = :" & UBound(strBindField) - 1 & " --հ�ްID")
        End If
        If IsNull(FUSER_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME
            strSQL.Append(vbCrLf & "    AND FUSER_NAME = :" & UBound(strBindField) - 1 & " --���O")
        End If
        If IsNull(FPLACE_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLACE_CD
            strSQL.Append(vbCrLf & "    AND FPLACE_CD = :" & UBound(strBindField) - 1 & " --�ۊǏꏊ����")
        End If
        If IsNull(FAREA_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFAREA_CD
            strSQL.Append(vbCrLf & "    AND FAREA_CD = :" & UBound(strBindField) - 1 & " --�ر����")
        End If
        If IsNull(FHINMEI_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --�i�ں���")
        End If
        If IsNull(FHINMEI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI
            strSQL.Append(vbCrLf & "    AND FHINMEI = :" & UBound(strBindField) - 1 & " --�i��_������")
        End If
        If IsNull(FLOT_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO
            strSQL.Append(vbCrLf & "    AND FLOT_NO = :" & UBound(strBindField) - 1 & " --ۯć�")
        End If
        If IsNull(FSAGYOU_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_KIND
            strSQL.Append(vbCrLf & "    AND FSAGYOU_KIND = :" & UBound(strBindField) - 1 & " --��Ǝ��")
        End If
        If IsNull(FNUM_IN_CASE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFNUM_IN_CASE
            strSQL.Append(vbCrLf & "    AND FNUM_IN_CASE = :" & UBound(strBindField) - 1 & " --���ܐ���")
        End If
        If IsNull(FTANI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTANI
            strSQL.Append(vbCrLf & "    AND FTANI = :" & UBound(strBindField) - 1 & " --�P�ʺ���")
        End If
        If IsNull(FDECIMAL_POINT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDECIMAL_POINT
            strSQL.Append(vbCrLf & "    AND FDECIMAL_POINT = :" & UBound(strBindField) - 1 & " --�����_�ȉ��L������")
        End If
        If IsNull(FSEIHIN_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEIHIN_KUBUN
            strSQL.Append(vbCrLf & "    AND FSEIHIN_KUBUN = :" & UBound(strBindField) - 1 & " --���i�敪")
        End If
        If IsNull(FZAIKO_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_KUBUN
            strSQL.Append(vbCrLf & "    AND FZAIKO_KUBUN = :" & UBound(strBindField) - 1 & " --�݌ɋ敪")
        End If
        If IsNull(FHORYU_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHORYU_KUBUN
            strSQL.Append(vbCrLf & "    AND FHORYU_KUBUN = :" & UBound(strBindField) - 1 & " --�ۗ��敪")
        End If
        If IsNull(FRECEIVEPAY_NUM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRECEIVEPAY_NUM
            strSQL.Append(vbCrLf & "    AND FRECEIVEPAY_NUM = :" & UBound(strBindField) - 1 & " --�󕥐���")
        End If
        If IsNull(FZAIKO_NUM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_NUM
            strSQL.Append(vbCrLf & "    AND FZAIKO_NUM = :" & UBound(strBindField) - 1 & " --�݌ɐ���")
        End If
        If IsNull(FSAGYOU_CONTENT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_CONTENT
            strSQL.Append(vbCrLf & "    AND FSAGYOU_CONTENT = :" & UBound(strBindField) - 1 & " --��Ɠ��e")
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
        strDataSetName = "TEVD_STOCK_LOG"
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
    Public Sub UPDATE_TEVD_STOCK_LOG()
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
        ElseIf IsNull(mFLOG_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[۸އ�]"
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
        strSQL.Append(vbCrLf & "    TEVD_STOCK_LOG")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
        If IsNull(mFLOG_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_NO = NULL --۸އ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_NO = NULL --۸އ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_NO = :" & Ubound(strBindField) - 1 & " --۸އ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_NO = :" & Ubound(strBindField) - 1 & " --۸އ�")
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
        If IsNull(mFTERM_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTERM_NAME = NULL --�[����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTERM_NAME = NULL --�[����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTERM_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTERM_NAME = :" & Ubound(strBindField) - 1 & " --�[����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTERM_NAME = :" & Ubound(strBindField) - 1 & " --�[����")
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
        If IsNull(mFUSER_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUSER_NAME = NULL --���O")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUSER_NAME = NULL --���O")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUSER_NAME = :" & Ubound(strBindField) - 1 & " --���O")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUSER_NAME = :" & Ubound(strBindField) - 1 & " --���O")
        End If
        intCount = intCount + 1
        If IsNull(mFPLACE_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FPLACE_CD = NULL --�ۊǏꏊ����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FPLACE_CD = NULL --�ۊǏꏊ����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLACE_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FPLACE_CD = :" & Ubound(strBindField) - 1 & " --�ۊǏꏊ����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FPLACE_CD = :" & Ubound(strBindField) - 1 & " --�ۊǏꏊ����")
        End If
        intCount = intCount + 1
        If IsNull(mFAREA_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FAREA_CD = NULL --�ر����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FAREA_CD = NULL --�ر����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFAREA_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FAREA_CD = :" & Ubound(strBindField) - 1 & " --�ر����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FAREA_CD = :" & Ubound(strBindField) - 1 & " --�ر����")
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
        If IsNull(mFHINMEI) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHINMEI = NULL --�i��_������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHINMEI = NULL --�i��_������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHINMEI = :" & Ubound(strBindField) - 1 & " --�i��_������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHINMEI = :" & Ubound(strBindField) - 1 & " --�i��_������")
        End If
        intCount = intCount + 1
        If IsNull(mFLOT_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOT_NO = NULL --ۯć�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOT_NO = NULL --ۯć�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOT_NO = :" & Ubound(strBindField) - 1 & " --ۯć�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOT_NO = :" & Ubound(strBindField) - 1 & " --ۯć�")
        End If
        intCount = intCount + 1
        If IsNull(mFSAGYOU_KIND) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSAGYOU_KIND = NULL --��Ǝ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSAGYOU_KIND = NULL --��Ǝ��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_KIND
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSAGYOU_KIND = :" & Ubound(strBindField) - 1 & " --��Ǝ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSAGYOU_KIND = :" & Ubound(strBindField) - 1 & " --��Ǝ��")
        End If
        intCount = intCount + 1
        If IsNull(mFNUM_IN_CASE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FNUM_IN_CASE = NULL --���ܐ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FNUM_IN_CASE = NULL --���ܐ���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFNUM_IN_CASE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FNUM_IN_CASE = :" & Ubound(strBindField) - 1 & " --���ܐ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FNUM_IN_CASE = :" & Ubound(strBindField) - 1 & " --���ܐ���")
        End If
        intCount = intCount + 1
        If IsNull(mFTANI) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTANI = NULL --�P�ʺ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTANI = NULL --�P�ʺ���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTANI
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTANI = :" & Ubound(strBindField) - 1 & " --�P�ʺ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTANI = :" & Ubound(strBindField) - 1 & " --�P�ʺ���")
        End If
        intCount = intCount + 1
        If IsNull(mFDECIMAL_POINT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDECIMAL_POINT = NULL --�����_�ȉ��L������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDECIMAL_POINT = NULL --�����_�ȉ��L������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDECIMAL_POINT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDECIMAL_POINT = :" & Ubound(strBindField) - 1 & " --�����_�ȉ��L������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDECIMAL_POINT = :" & Ubound(strBindField) - 1 & " --�����_�ȉ��L������")
        End If
        intCount = intCount + 1
        If IsNull(mFSEIHIN_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSEIHIN_KUBUN = NULL --���i�敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSEIHIN_KUBUN = NULL --���i�敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEIHIN_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSEIHIN_KUBUN = :" & Ubound(strBindField) - 1 & " --���i�敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSEIHIN_KUBUN = :" & Ubound(strBindField) - 1 & " --���i�敪")
        End If
        intCount = intCount + 1
        If IsNull(mFZAIKO_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FZAIKO_KUBUN = NULL --�݌ɋ敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FZAIKO_KUBUN = NULL --�݌ɋ敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FZAIKO_KUBUN = :" & Ubound(strBindField) - 1 & " --�݌ɋ敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FZAIKO_KUBUN = :" & Ubound(strBindField) - 1 & " --�݌ɋ敪")
        End If
        intCount = intCount + 1
        If IsNull(mFHORYU_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHORYU_KUBUN = NULL --�ۗ��敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHORYU_KUBUN = NULL --�ۗ��敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHORYU_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHORYU_KUBUN = :" & Ubound(strBindField) - 1 & " --�ۗ��敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHORYU_KUBUN = :" & Ubound(strBindField) - 1 & " --�ۗ��敪")
        End If
        intCount = intCount + 1
        If IsNull(mFRECEIVEPAY_NUM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRECEIVEPAY_NUM = NULL --�󕥐���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRECEIVEPAY_NUM = NULL --�󕥐���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRECEIVEPAY_NUM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRECEIVEPAY_NUM = :" & Ubound(strBindField) - 1 & " --�󕥐���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRECEIVEPAY_NUM = :" & Ubound(strBindField) - 1 & " --�󕥐���")
        End If
        intCount = intCount + 1
        If IsNull(mFZAIKO_NUM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FZAIKO_NUM = NULL --�݌ɐ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FZAIKO_NUM = NULL --�݌ɐ���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_NUM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FZAIKO_NUM = :" & Ubound(strBindField) - 1 & " --�݌ɐ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FZAIKO_NUM = :" & Ubound(strBindField) - 1 & " --�݌ɐ���")
        End If
        intCount = intCount + 1
        If IsNull(mFSAGYOU_CONTENT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSAGYOU_CONTENT = NULL --��Ɠ��e")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSAGYOU_CONTENT = NULL --��Ɠ��e")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_CONTENT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSAGYOU_CONTENT = :" & Ubound(strBindField) - 1 & " --��Ɠ��e")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSAGYOU_CONTENT = :" & Ubound(strBindField) - 1 & " --��Ɠ��e")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FLOG_NO) = True Then
            strSQL.Append(vbCrLf & "    AND FLOG_NO IS NULL --۸އ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            strSQL.Append(vbCrLf & "    AND FLOG_NO = :" & UBound(strBindField) - 1 & " --۸އ�")
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
    Public Sub ADD_TEVD_STOCK_LOG()
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
        ElseIf IsNull(mFLOG_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[۸އ�]"
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
        strSQL.Append(vbCrLf & "    TEVD_STOCK_LOG")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
        If IsNull(mFLOG_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --۸އ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --۸އ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --۸އ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --۸އ�")
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
        If IsNull(mFTERM_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�[����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�[����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTERM_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�[����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�[����")
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
        If IsNull(mFUSER_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���O")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���O")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���O")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���O")
        End If
        intCount = intCount + 1
        If IsNull(mFPLACE_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ۊǏꏊ����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ۊǏꏊ����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLACE_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ۊǏꏊ����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ۊǏꏊ����")
        End If
        intCount = intCount + 1
        If IsNull(mFAREA_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ر����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ر����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFAREA_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ر����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ر����")
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
        If IsNull(mFHINMEI) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�i��_������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�i��_������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�i��_������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�i��_������")
        End If
        intCount = intCount + 1
        If IsNull(mFLOT_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ۯć�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ۯć�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ۯć�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ۯć�")
        End If
        intCount = intCount + 1
        If IsNull(mFSAGYOU_KIND) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --��Ǝ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --��Ǝ��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_KIND
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --��Ǝ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --��Ǝ��")
        End If
        intCount = intCount + 1
        If IsNull(mFNUM_IN_CASE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���ܐ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���ܐ���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFNUM_IN_CASE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���ܐ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���ܐ���")
        End If
        intCount = intCount + 1
        If IsNull(mFTANI) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�P�ʺ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�P�ʺ���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTANI
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�P�ʺ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�P�ʺ���")
        End If
        intCount = intCount + 1
        If IsNull(mFDECIMAL_POINT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�����_�ȉ��L������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�����_�ȉ��L������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDECIMAL_POINT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�����_�ȉ��L������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�����_�ȉ��L������")
        End If
        intCount = intCount + 1
        If IsNull(mFSEIHIN_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���i�敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���i�敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEIHIN_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���i�敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���i�敪")
        End If
        intCount = intCount + 1
        If IsNull(mFZAIKO_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�݌ɋ敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�݌ɋ敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�݌ɋ敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�݌ɋ敪")
        End If
        intCount = intCount + 1
        If IsNull(mFHORYU_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ۗ��敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ۗ��敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHORYU_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ۗ��敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ۗ��敪")
        End If
        intCount = intCount + 1
        If IsNull(mFRECEIVEPAY_NUM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�󕥐���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�󕥐���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRECEIVEPAY_NUM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�󕥐���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�󕥐���")
        End If
        intCount = intCount + 1
        If IsNull(mFZAIKO_NUM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�݌ɐ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�݌ɐ���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_NUM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�݌ɐ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�݌ɐ���")
        End If
        intCount = intCount + 1
        If IsNull(mFSAGYOU_CONTENT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --��Ɠ��e")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --��Ɠ��e")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_CONTENT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --��Ɠ��e")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --��Ɠ��e")
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
    Public Sub DELETE_TEVD_STOCK_LOG()
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
        ElseIf IsNull(mFLOG_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[۸އ�]"
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
        strSQL.Append(vbCrLf & "    TEVD_STOCK_LOG")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FLOG_NO) = True Then
            strSQL.Append(vbCrLf & "    AND FLOG_NO IS NULL --۸އ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            strSQL.Append(vbCrLf & "    AND FLOG_NO = :" & UBound(strBindField) - 1 & " --۸އ�")
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
    Public Sub DELETE_TEVD_STOCK_LOG_ANY()
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
        strSQL.Append(vbCrLf & "    TEVD_STOCK_LOG")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(FLOG_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            strSQL.Append(vbCrLf & "    AND FLOG_NO = :" & UBound(strBindField) - 1 & " --۸އ�")
        End If
        If IsNotNull(FENTRY_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --�o�^����")
        End If
        If IsNotNull(FPALLET_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --��گ�ID")
        End If
        If IsNotNull(FTERM_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTERM_ID
            strSQL.Append(vbCrLf & "    AND FTERM_ID = :" & UBound(strBindField) - 1 & " --�[��ID")
        End If
        If IsNotNull(FTERM_NAME) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTERM_NAME
            strSQL.Append(vbCrLf & "    AND FTERM_NAME = :" & UBound(strBindField) - 1 & " --�[����")
        End If
        If IsNotNull(FUSER_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID
            strSQL.Append(vbCrLf & "    AND FUSER_ID = :" & UBound(strBindField) - 1 & " --հ�ްID")
        End If
        If IsNotNull(FUSER_NAME) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME
            strSQL.Append(vbCrLf & "    AND FUSER_NAME = :" & UBound(strBindField) - 1 & " --���O")
        End If
        If IsNotNull(FPLACE_CD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLACE_CD
            strSQL.Append(vbCrLf & "    AND FPLACE_CD = :" & UBound(strBindField) - 1 & " --�ۊǏꏊ����")
        End If
        If IsNotNull(FAREA_CD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFAREA_CD
            strSQL.Append(vbCrLf & "    AND FAREA_CD = :" & UBound(strBindField) - 1 & " --�ر����")
        End If
        If IsNotNull(FHINMEI_CD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --�i�ں���")
        End If
        If IsNotNull(FHINMEI) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI
            strSQL.Append(vbCrLf & "    AND FHINMEI = :" & UBound(strBindField) - 1 & " --�i��_������")
        End If
        If IsNotNull(FLOT_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO
            strSQL.Append(vbCrLf & "    AND FLOT_NO = :" & UBound(strBindField) - 1 & " --ۯć�")
        End If
        If IsNotNull(FSAGYOU_KIND) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_KIND
            strSQL.Append(vbCrLf & "    AND FSAGYOU_KIND = :" & UBound(strBindField) - 1 & " --��Ǝ��")
        End If
        If IsNotNull(FNUM_IN_CASE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFNUM_IN_CASE
            strSQL.Append(vbCrLf & "    AND FNUM_IN_CASE = :" & UBound(strBindField) - 1 & " --���ܐ���")
        End If
        If IsNotNull(FTANI) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTANI
            strSQL.Append(vbCrLf & "    AND FTANI = :" & UBound(strBindField) - 1 & " --�P�ʺ���")
        End If
        If IsNotNull(FDECIMAL_POINT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDECIMAL_POINT
            strSQL.Append(vbCrLf & "    AND FDECIMAL_POINT = :" & UBound(strBindField) - 1 & " --�����_�ȉ��L������")
        End If
        If IsNotNull(FSEIHIN_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEIHIN_KUBUN
            strSQL.Append(vbCrLf & "    AND FSEIHIN_KUBUN = :" & UBound(strBindField) - 1 & " --���i�敪")
        End If
        If IsNotNull(FZAIKO_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_KUBUN
            strSQL.Append(vbCrLf & "    AND FZAIKO_KUBUN = :" & UBound(strBindField) - 1 & " --�݌ɋ敪")
        End If
        If IsNotNull(FHORYU_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHORYU_KUBUN
            strSQL.Append(vbCrLf & "    AND FHORYU_KUBUN = :" & UBound(strBindField) - 1 & " --�ۗ��敪")
        End If
        If IsNotNull(FRECEIVEPAY_NUM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRECEIVEPAY_NUM
            strSQL.Append(vbCrLf & "    AND FRECEIVEPAY_NUM = :" & UBound(strBindField) - 1 & " --�󕥐���")
        End If
        If IsNotNull(FZAIKO_NUM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_NUM
            strSQL.Append(vbCrLf & "    AND FZAIKO_NUM = :" & UBound(strBindField) - 1 & " --�݌ɐ���")
        End If
        If IsNotNull(FSAGYOU_CONTENT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_CONTENT
            strSQL.Append(vbCrLf & "    AND FSAGYOU_CONTENT = :" & UBound(strBindField) - 1 & " --��Ɠ��e")
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
        If IsNothing(objType.GetProperty("FLOG_NO")) = False Then mFLOG_NO = objObject.FLOG_NO '۸އ�
        If IsNothing(objType.GetProperty("FENTRY_DT")) = False Then mFENTRY_DT = objObject.FENTRY_DT '�o�^����
        If IsNothing(objType.GetProperty("FPALLET_ID")) = False Then mFPALLET_ID = objObject.FPALLET_ID '��گ�ID
        If IsNothing(objType.GetProperty("FTERM_ID")) = False Then mFTERM_ID = objObject.FTERM_ID '�[��ID
        If IsNothing(objType.GetProperty("FTERM_NAME")) = False Then mFTERM_NAME = objObject.FTERM_NAME '�[����
        If IsNothing(objType.GetProperty("FUSER_ID")) = False Then mFUSER_ID = objObject.FUSER_ID 'հ�ްID
        If IsNothing(objType.GetProperty("FUSER_NAME")) = False Then mFUSER_NAME = objObject.FUSER_NAME '���O
        If IsNothing(objType.GetProperty("FPLACE_CD")) = False Then mFPLACE_CD = objObject.FPLACE_CD '�ۊǏꏊ����
        If IsNothing(objType.GetProperty("FAREA_CD")) = False Then mFAREA_CD = objObject.FAREA_CD '�ر����
        If IsNothing(objType.GetProperty("FHINMEI_CD")) = False Then mFHINMEI_CD = objObject.FHINMEI_CD '�i�ں���
        If IsNothing(objType.GetProperty("FHINMEI")) = False Then mFHINMEI = objObject.FHINMEI '�i��_������
        If IsNothing(objType.GetProperty("FLOT_NO")) = False Then mFLOT_NO = objObject.FLOT_NO 'ۯć�
        If IsNothing(objType.GetProperty("FSAGYOU_KIND")) = False Then mFSAGYOU_KIND = objObject.FSAGYOU_KIND '��Ǝ��
        If IsNothing(objType.GetProperty("FNUM_IN_CASE")) = False Then mFNUM_IN_CASE = objObject.FNUM_IN_CASE '���ܐ���
        If IsNothing(objType.GetProperty("FTANI")) = False Then mFTANI = objObject.FTANI '�P�ʺ���
        If IsNothing(objType.GetProperty("FDECIMAL_POINT")) = False Then mFDECIMAL_POINT = objObject.FDECIMAL_POINT '�����_�ȉ��L������
        If IsNothing(objType.GetProperty("FSEIHIN_KUBUN")) = False Then mFSEIHIN_KUBUN = objObject.FSEIHIN_KUBUN '���i�敪
        If IsNothing(objType.GetProperty("FZAIKO_KUBUN")) = False Then mFZAIKO_KUBUN = objObject.FZAIKO_KUBUN '�݌ɋ敪
        If IsNothing(objType.GetProperty("FHORYU_KUBUN")) = False Then mFHORYU_KUBUN = objObject.FHORYU_KUBUN '�ۗ��敪
        If IsNothing(objType.GetProperty("FRECEIVEPAY_NUM")) = False Then mFRECEIVEPAY_NUM = objObject.FRECEIVEPAY_NUM '�󕥐���
        If IsNothing(objType.GetProperty("FZAIKO_NUM")) = False Then mFZAIKO_NUM = objObject.FZAIKO_NUM '�݌ɐ���
        If IsNothing(objType.GetProperty("FSAGYOU_CONTENT")) = False Then mFSAGYOU_CONTENT = objObject.FSAGYOU_CONTENT '��Ɠ��e

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
        mFLOG_NO = Nothing
        mFENTRY_DT = Nothing
        mFPALLET_ID = Nothing
        mFTERM_ID = Nothing
        mFTERM_NAME = Nothing
        mFUSER_ID = Nothing
        mFUSER_NAME = Nothing
        mFPLACE_CD = Nothing
        mFAREA_CD = Nothing
        mFHINMEI_CD = Nothing
        mFHINMEI = Nothing
        mFLOT_NO = Nothing
        mFSAGYOU_KIND = Nothing
        mFNUM_IN_CASE = Nothing
        mFTANI = Nothing
        mFDECIMAL_POINT = Nothing
        mFSEIHIN_KUBUN = Nothing
        mFZAIKO_KUBUN = Nothing
        mFHORYU_KUBUN = Nothing
        mFRECEIVEPAY_NUM = Nothing
        mFZAIKO_NUM = Nothing
        mFSAGYOU_CONTENT = Nothing


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
        mFLOG_NO = TO_STRING_NULLABLE(objRow("FLOG_NO"))
        mFENTRY_DT = TO_DATE_NULLABLE(objRow("FENTRY_DT"))
        mFPALLET_ID = TO_STRING_NULLABLE(objRow("FPALLET_ID"))
        mFTERM_ID = TO_STRING_NULLABLE(objRow("FTERM_ID"))
        mFTERM_NAME = TO_STRING_NULLABLE(objRow("FTERM_NAME"))
        mFUSER_ID = TO_STRING_NULLABLE(objRow("FUSER_ID"))
        mFUSER_NAME = TO_STRING_NULLABLE(objRow("FUSER_NAME"))
        mFPLACE_CD = TO_INTEGER_NULLABLE(objRow("FPLACE_CD"))
        mFAREA_CD = TO_INTEGER_NULLABLE(objRow("FAREA_CD"))
        mFHINMEI_CD = TO_STRING_NULLABLE(objRow("FHINMEI_CD"))
        mFHINMEI = TO_STRING_NULLABLE(objRow("FHINMEI"))
        mFLOT_NO = TO_STRING_NULLABLE(objRow("FLOT_NO"))
        mFSAGYOU_KIND = TO_INTEGER_NULLABLE(objRow("FSAGYOU_KIND"))
        mFNUM_IN_CASE = TO_DECIMAL_NULLABLE(objRow("FNUM_IN_CASE"))
        mFTANI = TO_STRING_NULLABLE(objRow("FTANI"))
        mFDECIMAL_POINT = TO_INTEGER_NULLABLE(objRow("FDECIMAL_POINT"))
        mFSEIHIN_KUBUN = TO_INTEGER_NULLABLE(objRow("FSEIHIN_KUBUN"))
        mFZAIKO_KUBUN = TO_INTEGER_NULLABLE(objRow("FZAIKO_KUBUN"))
        mFHORYU_KUBUN = TO_INTEGER_NULLABLE(objRow("FHORYU_KUBUN"))
        mFRECEIVEPAY_NUM = TO_DECIMAL_NULLABLE(objRow("FRECEIVEPAY_NUM"))
        mFZAIKO_NUM = TO_DECIMAL_NULLABLE(objRow("FZAIKO_NUM"))
        mFSAGYOU_CONTENT = TO_STRING_NULLABLE(objRow("FSAGYOU_CONTENT"))


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
        strMsg &= "[ð��ٖ�:�݌ɍX�V����]"
        If IsNotNull(FLOG_NO) Then
            strMsg &= "[۸އ�:" & FLOG_NO & "]"
        End If
        If IsNotNull(FENTRY_DT) Then
            strMsg &= "[�o�^����:" & FENTRY_DT & "]"
        End If
        If IsNotNull(FPALLET_ID) Then
            strMsg &= "[��گ�ID:" & FPALLET_ID & "]"
        End If
        If IsNotNull(FTERM_ID) Then
            strMsg &= "[�[��ID:" & FTERM_ID & "]"
        End If
        If IsNotNull(FTERM_NAME) Then
            strMsg &= "[�[����:" & FTERM_NAME & "]"
        End If
        If IsNotNull(FUSER_ID) Then
            strMsg &= "[հ�ްID:" & FUSER_ID & "]"
        End If
        If IsNotNull(FUSER_NAME) Then
            strMsg &= "[���O:" & FUSER_NAME & "]"
        End If
        If IsNotNull(FPLACE_CD) Then
            strMsg &= "[�ۊǏꏊ����:" & FPLACE_CD & "]"
        End If
        If IsNotNull(FAREA_CD) Then
            strMsg &= "[�ر����:" & FAREA_CD & "]"
        End If
        If IsNotNull(FHINMEI_CD) Then
            strMsg &= "[�i�ں���:" & FHINMEI_CD & "]"
        End If
        If IsNotNull(FHINMEI) Then
            strMsg &= "[�i��_������:" & FHINMEI & "]"
        End If
        If IsNotNull(FLOT_NO) Then
            strMsg &= "[ۯć�:" & FLOT_NO & "]"
        End If
        If IsNotNull(FSAGYOU_KIND) Then
            strMsg &= "[��Ǝ��:" & FSAGYOU_KIND & "]"
        End If
        If IsNotNull(FNUM_IN_CASE) Then
            strMsg &= "[���ܐ���:" & FNUM_IN_CASE & "]"
        End If
        If IsNotNull(FTANI) Then
            strMsg &= "[�P�ʺ���:" & FTANI & "]"
        End If
        If IsNotNull(FDECIMAL_POINT) Then
            strMsg &= "[�����_�ȉ��L������:" & FDECIMAL_POINT & "]"
        End If
        If IsNotNull(FSEIHIN_KUBUN) Then
            strMsg &= "[���i�敪:" & FSEIHIN_KUBUN & "]"
        End If
        If IsNotNull(FZAIKO_KUBUN) Then
            strMsg &= "[�݌ɋ敪:" & FZAIKO_KUBUN & "]"
        End If
        If IsNotNull(FHORYU_KUBUN) Then
            strMsg &= "[�ۗ��敪:" & FHORYU_KUBUN & "]"
        End If
        If IsNotNull(FRECEIVEPAY_NUM) Then
            strMsg &= "[�󕥐���:" & FRECEIVEPAY_NUM & "]"
        End If
        If IsNotNull(FZAIKO_NUM) Then
            strMsg &= "[�݌ɐ���:" & FZAIKO_NUM & "]"
        End If
        If IsNotNull(FSAGYOU_CONTENT) Then
            strMsg &= "[��Ɠ��e:" & FSAGYOU_CONTENT & "]"
        End If


    End Sub
#End Region
    '����������������
    '**********************************************************************************************

    '**********************************************************************************************
    '���������ы���
#Region "  �݌ɍX�V����ǉ�   [SEQ����]             (Public  ADD_TEVD_STOCK_LOG_SEQ)"
    Public Sub ADD_TEVD_STOCK_LOG_SEQ()
        Try


            '***********************
            '۸އ��̓���
            '***********************
            Dim objTPRG_SEQNO As New TBL_TPRG_SEQNO(Owner, ObjDb, ObjDbLog) '���ݽ���׽
            objTPRG_SEQNO.FSEQ_ID = FSEQ_ID_SSVRLOG_NO_STOCK_LOG             '���ݽID
            mFLOG_NO = objTPRG_SEQNO.GET_ENTRY_NO()                         'SEQ���̓���


            '***********************
            '�ǉ�
            '***********************
            Me.ADD_TEVD_STOCK_LOG()


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
    '���������ы���
    '**********************************************************************************************


    '**********************************************************************************************
    '���������ьŗL

    '���������ьŗL
    '**********************************************************************************************

End Class
