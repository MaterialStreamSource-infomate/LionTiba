'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' �y���́zMaterialStreamð��ٸ׽
' �y�@�\�z���������MIFð��ٸ׽
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
''' ���������MIFð��ٸ׽
''' </summary>
Public Class TBL_TLIF_TRNS_RECV
    Inherits clsTemplateTable

    '**********************************************************************************************
    '����������������
#Region "  �׽�ϐ���`                  "
    '�����è
    Private mobjAryMe As TBL_TLIF_TRNS_RECV()                                    '���������MIF
    Private mstrUSER_SQL As String                                               'հ�ްSQL
    Private mORDER_BY As String                                                  'OrderBy��
    Private mWHERE As String                                                     'Where��
    Private mFENTRY_NO As String                                                 '�o�^��
    Private mFEQ_ID As String                                                    '�ݔ�ID
    Private mFCOMMAND_ID As String                                               '�����ID
    Private mFPALLET_ID As String                                                '��گ�ID
    Private mFTEXT_ID As String                                                  '÷��ID
    Private mFDENBUN_PRM1 As String                                              '�d�����Ұ�1
    Private mFDENBUN_PRM2 As String                                              '�d�����Ұ�2
    Private mFDENBUN_PRM3 As String                                              '�d�����Ұ�3
    Private mFDENBUN_PRM4 As String                                              '�d�����Ұ�4
    Private mFDENBUN_PRM5 As String                                              '�d�����Ұ�5
    Private mFDENBUN_PRM6 As String                                              '�d�����Ұ�6
    Private mFTRNS_SERIAL As String                                              '�����ره�(MC��)
    Private mFPRIORITY As Nullable(Of Integer)                                   '�D������
    Private mFDENBUN As String                                                   '�ʐM�d��
    Private mFDENBUN02 As String                                                 '�ʐM�d��02
    Private mFPROGRESS As Nullable(Of Integer)                                   '�i�����
    Private mFRES_CD_EQ As String                                                '�ݔ���������
    Private mFENTRY_DT As Nullable(Of Date)                                      '�o�^����
    Private mFUPDATE_DT As Nullable(Of Date)                                     '�X�V����
#End Region
#Region "  �����è��`                  "
    ''' <summary>
    ''' ���ѕϐ� (���׽�^�z��)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_TLIF_TRNS_RECV()
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
    ''' �o�^��
    ''' </summary>
    Public Property FENTRY_NO() As String
        Get
            Return mFENTRY_NO
        End Get
        Set(ByVal Value As String)
            mFENTRY_NO = Value
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
    ''' �����ID
    ''' </summary>
    Public Property FCOMMAND_ID() As String
        Get
            Return mFCOMMAND_ID
        End Get
        Set(ByVal Value As String)
            mFCOMMAND_ID = Value
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
    ''' ÷��ID
    ''' </summary>
    Public Property FTEXT_ID() As String
        Get
            Return mFTEXT_ID
        End Get
        Set(ByVal Value As String)
            mFTEXT_ID = Value
        End Set
    End Property
    ''' <summary>
    ''' �d�����Ұ�1
    ''' </summary>
    Public Property FDENBUN_PRM1() As String
        Get
            Return mFDENBUN_PRM1
        End Get
        Set(ByVal Value As String)
            mFDENBUN_PRM1 = Value
        End Set
    End Property
    ''' <summary>
    ''' �d�����Ұ�2
    ''' </summary>
    Public Property FDENBUN_PRM2() As String
        Get
            Return mFDENBUN_PRM2
        End Get
        Set(ByVal Value As String)
            mFDENBUN_PRM2 = Value
        End Set
    End Property
    ''' <summary>
    ''' �d�����Ұ�3
    ''' </summary>
    Public Property FDENBUN_PRM3() As String
        Get
            Return mFDENBUN_PRM3
        End Get
        Set(ByVal Value As String)
            mFDENBUN_PRM3 = Value
        End Set
    End Property
    ''' <summary>
    ''' �d�����Ұ�4
    ''' </summary>
    Public Property FDENBUN_PRM4() As String
        Get
            Return mFDENBUN_PRM4
        End Get
        Set(ByVal Value As String)
            mFDENBUN_PRM4 = Value
        End Set
    End Property
    ''' <summary>
    ''' �d�����Ұ�5
    ''' </summary>
    Public Property FDENBUN_PRM5() As String
        Get
            Return mFDENBUN_PRM5
        End Get
        Set(ByVal Value As String)
            mFDENBUN_PRM5 = Value
        End Set
    End Property
    ''' <summary>
    ''' �d�����Ұ�6
    ''' </summary>
    Public Property FDENBUN_PRM6() As String
        Get
            Return mFDENBUN_PRM6
        End Get
        Set(ByVal Value As String)
            mFDENBUN_PRM6 = Value
        End Set
    End Property
    ''' <summary>
    ''' �����ره�(MC��)
    ''' </summary>
    Public Property FTRNS_SERIAL() As String
        Get
            Return mFTRNS_SERIAL
        End Get
        Set(ByVal Value As String)
            mFTRNS_SERIAL = Value
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
    ''' �ʐM�d��
    ''' </summary>
    Public Property FDENBUN() As String
        Get
            Return mFDENBUN
        End Get
        Set(ByVal Value As String)
            mFDENBUN = Value
        End Set
    End Property
    ''' <summary>
    ''' �ʐM�d��02
    ''' </summary>
    Public Property FDENBUN02() As String
        Get
            Return mFDENBUN02
        End Get
        Set(ByVal Value As String)
            mFDENBUN02 = Value
        End Set
    End Property
    ''' <summary>
    ''' �i�����
    ''' </summary>
    Public Property FPROGRESS() As Nullable(Of Integer)
        Get
            Return mFPROGRESS
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFPROGRESS = Value
        End Set
    End Property
    ''' <summary>
    ''' �ݔ���������
    ''' </summary>
    Public Property FRES_CD_EQ() As String
        Get
            Return mFRES_CD_EQ
        End Get
        Set(ByVal Value As String)
            mFRES_CD_EQ = Value
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
    Public Function GET_TLIF_TRNS_RECV(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    TLIF_TRNS_RECV")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FENTRY_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_NO
            strSQL.Append(vbCrLf & "    AND FENTRY_NO = :" & UBound(strBindField) - 1 & " --�o�^��")
        End If
        If IsNull(FEQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --�ݔ�ID")
        End If
        If IsNull(FCOMMAND_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOMMAND_ID
            strSQL.Append(vbCrLf & "    AND FCOMMAND_ID = :" & UBound(strBindField) - 1 & " --�����ID")
        End If
        If IsNull(FPALLET_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --��گ�ID")
        End If
        If IsNull(FTEXT_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTEXT_ID
            strSQL.Append(vbCrLf & "    AND FTEXT_ID = :" & UBound(strBindField) - 1 & " --÷��ID")
        End If
        If IsNull(FDENBUN_PRM1) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM1
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM1 = :" & UBound(strBindField) - 1 & " --�d�����Ұ�1")
        End If
        If IsNull(FDENBUN_PRM2) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM2
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM2 = :" & UBound(strBindField) - 1 & " --�d�����Ұ�2")
        End If
        If IsNull(FDENBUN_PRM3) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM3
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM3 = :" & UBound(strBindField) - 1 & " --�d�����Ұ�3")
        End If
        If IsNull(FDENBUN_PRM4) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM4
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM4 = :" & UBound(strBindField) - 1 & " --�d�����Ұ�4")
        End If
        If IsNull(FDENBUN_PRM5) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM5
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM5 = :" & UBound(strBindField) - 1 & " --�d�����Ұ�5")
        End If
        If IsNull(FDENBUN_PRM6) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM6
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM6 = :" & UBound(strBindField) - 1 & " --�d�����Ұ�6")
        End If
        If IsNull(FTRNS_SERIAL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_SERIAL
            strSQL.Append(vbCrLf & "    AND FTRNS_SERIAL = :" & UBound(strBindField) - 1 & " --�����ره�(MC��)")
        End If
        If IsNull(FPRIORITY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPRIORITY
            strSQL.Append(vbCrLf & "    AND FPRIORITY = :" & UBound(strBindField) - 1 & " --�D������")
        End If
        If IsNull(FDENBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN
            strSQL.Append(vbCrLf & "    AND FDENBUN = :" & UBound(strBindField) - 1 & " --�ʐM�d��")
        End If
        If IsNull(FDENBUN02) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN02
            strSQL.Append(vbCrLf & "    AND FDENBUN02 = :" & UBound(strBindField) - 1 & " --�ʐM�d��02")
        End If
        If IsNull(FPROGRESS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPROGRESS
            strSQL.Append(vbCrLf & "    AND FPROGRESS = :" & UBound(strBindField) - 1 & " --�i�����")
        End If
        If IsNull(FRES_CD_EQ) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRES_CD_EQ
            strSQL.Append(vbCrLf & "    AND FRES_CD_EQ = :" & UBound(strBindField) - 1 & " --�ݔ���������")
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
        strDataSetName = "TLIF_TRNS_RECV"
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
    Public Function GET_TLIF_TRNS_RECV_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    TLIF_TRNS_RECV")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FENTRY_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_NO
            strSQL.Append(vbCrLf & "    AND FENTRY_NO = :" & UBound(strBindField) - 1 & " --�o�^��")
        End If
        If IsNull(FEQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --�ݔ�ID")
        End If
        If IsNull(FCOMMAND_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOMMAND_ID
            strSQL.Append(vbCrLf & "    AND FCOMMAND_ID = :" & UBound(strBindField) - 1 & " --�����ID")
        End If
        If IsNull(FPALLET_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --��گ�ID")
        End If
        If IsNull(FTEXT_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTEXT_ID
            strSQL.Append(vbCrLf & "    AND FTEXT_ID = :" & UBound(strBindField) - 1 & " --÷��ID")
        End If
        If IsNull(FDENBUN_PRM1) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM1
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM1 = :" & UBound(strBindField) - 1 & " --�d�����Ұ�1")
        End If
        If IsNull(FDENBUN_PRM2) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM2
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM2 = :" & UBound(strBindField) - 1 & " --�d�����Ұ�2")
        End If
        If IsNull(FDENBUN_PRM3) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM3
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM3 = :" & UBound(strBindField) - 1 & " --�d�����Ұ�3")
        End If
        If IsNull(FDENBUN_PRM4) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM4
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM4 = :" & UBound(strBindField) - 1 & " --�d�����Ұ�4")
        End If
        If IsNull(FDENBUN_PRM5) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM5
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM5 = :" & UBound(strBindField) - 1 & " --�d�����Ұ�5")
        End If
        If IsNull(FDENBUN_PRM6) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM6
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM6 = :" & UBound(strBindField) - 1 & " --�d�����Ұ�6")
        End If
        If IsNull(FTRNS_SERIAL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_SERIAL
            strSQL.Append(vbCrLf & "    AND FTRNS_SERIAL = :" & UBound(strBindField) - 1 & " --�����ره�(MC��)")
        End If
        If IsNull(FPRIORITY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPRIORITY
            strSQL.Append(vbCrLf & "    AND FPRIORITY = :" & UBound(strBindField) - 1 & " --�D������")
        End If
        If IsNull(FDENBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN
            strSQL.Append(vbCrLf & "    AND FDENBUN = :" & UBound(strBindField) - 1 & " --�ʐM�d��")
        End If
        If IsNull(FDENBUN02) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN02
            strSQL.Append(vbCrLf & "    AND FDENBUN02 = :" & UBound(strBindField) - 1 & " --�ʐM�d��02")
        End If
        If IsNull(FPROGRESS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPROGRESS
            strSQL.Append(vbCrLf & "    AND FPROGRESS = :" & UBound(strBindField) - 1 & " --�i�����")
        End If
        If IsNull(FRES_CD_EQ) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRES_CD_EQ
            strSQL.Append(vbCrLf & "    AND FRES_CD_EQ = :" & UBound(strBindField) - 1 & " --�ݔ���������")
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
        strDataSetName = "TLIF_TRNS_RECV"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TLIF_TRNS_RECV(Owner, objDb, objDbLog)
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
    Public Function GET_TLIF_TRNS_RECV_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "TLIF_TRNS_RECV"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TLIF_TRNS_RECV(Owner, objDb, objDbLog)
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
    Public Function GET_TLIF_TRNS_RECV_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    TLIF_TRNS_RECV")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FENTRY_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_NO
            strSQL.Append(vbCrLf & "    AND FENTRY_NO = :" & UBound(strBindField) - 1 & " --�o�^��")
        End If
        If IsNull(FEQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --�ݔ�ID")
        End If
        If IsNull(FCOMMAND_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOMMAND_ID
            strSQL.Append(vbCrLf & "    AND FCOMMAND_ID = :" & UBound(strBindField) - 1 & " --�����ID")
        End If
        If IsNull(FPALLET_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --��گ�ID")
        End If
        If IsNull(FTEXT_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTEXT_ID
            strSQL.Append(vbCrLf & "    AND FTEXT_ID = :" & UBound(strBindField) - 1 & " --÷��ID")
        End If
        If IsNull(FDENBUN_PRM1) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM1
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM1 = :" & UBound(strBindField) - 1 & " --�d�����Ұ�1")
        End If
        If IsNull(FDENBUN_PRM2) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM2
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM2 = :" & UBound(strBindField) - 1 & " --�d�����Ұ�2")
        End If
        If IsNull(FDENBUN_PRM3) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM3
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM3 = :" & UBound(strBindField) - 1 & " --�d�����Ұ�3")
        End If
        If IsNull(FDENBUN_PRM4) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM4
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM4 = :" & UBound(strBindField) - 1 & " --�d�����Ұ�4")
        End If
        If IsNull(FDENBUN_PRM5) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM5
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM5 = :" & UBound(strBindField) - 1 & " --�d�����Ұ�5")
        End If
        If IsNull(FDENBUN_PRM6) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM6
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM6 = :" & UBound(strBindField) - 1 & " --�d�����Ұ�6")
        End If
        If IsNull(FTRNS_SERIAL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_SERIAL
            strSQL.Append(vbCrLf & "    AND FTRNS_SERIAL = :" & UBound(strBindField) - 1 & " --�����ره�(MC��)")
        End If
        If IsNull(FPRIORITY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPRIORITY
            strSQL.Append(vbCrLf & "    AND FPRIORITY = :" & UBound(strBindField) - 1 & " --�D������")
        End If
        If IsNull(FDENBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN
            strSQL.Append(vbCrLf & "    AND FDENBUN = :" & UBound(strBindField) - 1 & " --�ʐM�d��")
        End If
        If IsNull(FDENBUN02) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN02
            strSQL.Append(vbCrLf & "    AND FDENBUN02 = :" & UBound(strBindField) - 1 & " --�ʐM�d��02")
        End If
        If IsNull(FPROGRESS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPROGRESS
            strSQL.Append(vbCrLf & "    AND FPROGRESS = :" & UBound(strBindField) - 1 & " --�i�����")
        End If
        If IsNull(FRES_CD_EQ) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRES_CD_EQ
            strSQL.Append(vbCrLf & "    AND FRES_CD_EQ = :" & UBound(strBindField) - 1 & " --�ݔ���������")
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
        strDataSetName = "TLIF_TRNS_RECV"
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
    Public Sub UPDATE_TLIF_TRNS_RECV()
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
        ElseIf IsNull(mFENTRY_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�o�^��]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFEQ_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�ݔ�ID]"
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
        strSQL.Append(vbCrLf & "    TLIF_TRNS_RECV")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
        If IsNull(mFENTRY_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FENTRY_NO = NULL --�o�^��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FENTRY_NO = NULL --�o�^��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FENTRY_NO = :" & Ubound(strBindField) - 1 & " --�o�^��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FENTRY_NO = :" & Ubound(strBindField) - 1 & " --�o�^��")
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
        If IsNull(mFCOMMAND_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCOMMAND_ID = NULL --�����ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCOMMAND_ID = NULL --�����ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOMMAND_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCOMMAND_ID = :" & Ubound(strBindField) - 1 & " --�����ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCOMMAND_ID = :" & Ubound(strBindField) - 1 & " --�����ID")
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
        If IsNull(mFTEXT_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTEXT_ID = NULL --÷��ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTEXT_ID = NULL --÷��ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTEXT_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTEXT_ID = :" & Ubound(strBindField) - 1 & " --÷��ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTEXT_ID = :" & Ubound(strBindField) - 1 & " --÷��ID")
        End If
        intCount = intCount + 1
        If IsNull(mFDENBUN_PRM1) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDENBUN_PRM1 = NULL --�d�����Ұ�1")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDENBUN_PRM1 = NULL --�d�����Ұ�1")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM1
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDENBUN_PRM1 = :" & Ubound(strBindField) - 1 & " --�d�����Ұ�1")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDENBUN_PRM1 = :" & Ubound(strBindField) - 1 & " --�d�����Ұ�1")
        End If
        intCount = intCount + 1
        If IsNull(mFDENBUN_PRM2) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDENBUN_PRM2 = NULL --�d�����Ұ�2")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDENBUN_PRM2 = NULL --�d�����Ұ�2")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM2
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDENBUN_PRM2 = :" & Ubound(strBindField) - 1 & " --�d�����Ұ�2")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDENBUN_PRM2 = :" & Ubound(strBindField) - 1 & " --�d�����Ұ�2")
        End If
        intCount = intCount + 1
        If IsNull(mFDENBUN_PRM3) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDENBUN_PRM3 = NULL --�d�����Ұ�3")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDENBUN_PRM3 = NULL --�d�����Ұ�3")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM3
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDENBUN_PRM3 = :" & Ubound(strBindField) - 1 & " --�d�����Ұ�3")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDENBUN_PRM3 = :" & Ubound(strBindField) - 1 & " --�d�����Ұ�3")
        End If
        intCount = intCount + 1
        If IsNull(mFDENBUN_PRM4) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDENBUN_PRM4 = NULL --�d�����Ұ�4")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDENBUN_PRM4 = NULL --�d�����Ұ�4")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM4
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDENBUN_PRM4 = :" & Ubound(strBindField) - 1 & " --�d�����Ұ�4")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDENBUN_PRM4 = :" & Ubound(strBindField) - 1 & " --�d�����Ұ�4")
        End If
        intCount = intCount + 1
        If IsNull(mFDENBUN_PRM5) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDENBUN_PRM5 = NULL --�d�����Ұ�5")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDENBUN_PRM5 = NULL --�d�����Ұ�5")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM5
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDENBUN_PRM5 = :" & Ubound(strBindField) - 1 & " --�d�����Ұ�5")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDENBUN_PRM5 = :" & Ubound(strBindField) - 1 & " --�d�����Ұ�5")
        End If
        intCount = intCount + 1
        If IsNull(mFDENBUN_PRM6) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDENBUN_PRM6 = NULL --�d�����Ұ�6")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDENBUN_PRM6 = NULL --�d�����Ұ�6")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM6
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDENBUN_PRM6 = :" & Ubound(strBindField) - 1 & " --�d�����Ұ�6")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDENBUN_PRM6 = :" & Ubound(strBindField) - 1 & " --�d�����Ұ�6")
        End If
        intCount = intCount + 1
        If IsNull(mFTRNS_SERIAL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTRNS_SERIAL = NULL --�����ره�(MC��)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTRNS_SERIAL = NULL --�����ره�(MC��)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_SERIAL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTRNS_SERIAL = :" & Ubound(strBindField) - 1 & " --�����ره�(MC��)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTRNS_SERIAL = :" & Ubound(strBindField) - 1 & " --�����ره�(MC��)")
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
        If IsNull(mFDENBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDENBUN = NULL --�ʐM�d��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDENBUN = NULL --�ʐM�d��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDENBUN = :" & Ubound(strBindField) - 1 & " --�ʐM�d��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDENBUN = :" & Ubound(strBindField) - 1 & " --�ʐM�d��")
        End If
        intCount = intCount + 1
        If IsNull(mFDENBUN02) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDENBUN02 = NULL --�ʐM�d��02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDENBUN02 = NULL --�ʐM�d��02")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN02
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDENBUN02 = :" & Ubound(strBindField) - 1 & " --�ʐM�d��02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDENBUN02 = :" & Ubound(strBindField) - 1 & " --�ʐM�d��02")
        End If
        intCount = intCount + 1
        If IsNull(mFPROGRESS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FPROGRESS = NULL --�i�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FPROGRESS = NULL --�i�����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPROGRESS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FPROGRESS = :" & Ubound(strBindField) - 1 & " --�i�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FPROGRESS = :" & Ubound(strBindField) - 1 & " --�i�����")
        End If
        intCount = intCount + 1
        If IsNull(mFRES_CD_EQ) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRES_CD_EQ = NULL --�ݔ���������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRES_CD_EQ = NULL --�ݔ���������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRES_CD_EQ
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRES_CD_EQ = :" & Ubound(strBindField) - 1 & " --�ݔ���������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRES_CD_EQ = :" & Ubound(strBindField) - 1 & " --�ݔ���������")
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
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FENTRY_NO) = True Then
            strSQL.Append(vbCrLf & "    AND FENTRY_NO IS NULL --�o�^��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_NO
            strSQL.Append(vbCrLf & "    AND FENTRY_NO = :" & UBound(strBindField) - 1 & " --�o�^��")
        End If
        If IsNull(FEQ_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FEQ_ID IS NULL --�ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --�ݔ�ID")
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
    Public Sub ADD_TLIF_TRNS_RECV()
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
        ElseIf IsNull(mFENTRY_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�o�^��]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFEQ_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�ݔ�ID]"
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
        strSQL.Append(vbCrLf & "    TLIF_TRNS_RECV")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
        If IsNull(mFENTRY_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�o�^��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�o�^��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�o�^��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�o�^��")
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
        If IsNull(mFCOMMAND_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�����ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�����ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOMMAND_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�����ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�����ID")
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
        If IsNull(mFTEXT_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --÷��ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --÷��ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTEXT_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --÷��ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --÷��ID")
        End If
        intCount = intCount + 1
        If IsNull(mFDENBUN_PRM1) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�d�����Ұ�1")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�d�����Ұ�1")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM1
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�d�����Ұ�1")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�d�����Ұ�1")
        End If
        intCount = intCount + 1
        If IsNull(mFDENBUN_PRM2) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�d�����Ұ�2")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�d�����Ұ�2")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM2
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�d�����Ұ�2")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�d�����Ұ�2")
        End If
        intCount = intCount + 1
        If IsNull(mFDENBUN_PRM3) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�d�����Ұ�3")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�d�����Ұ�3")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM3
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�d�����Ұ�3")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�d�����Ұ�3")
        End If
        intCount = intCount + 1
        If IsNull(mFDENBUN_PRM4) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�d�����Ұ�4")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�d�����Ұ�4")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM4
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�d�����Ұ�4")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�d�����Ұ�4")
        End If
        intCount = intCount + 1
        If IsNull(mFDENBUN_PRM5) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�d�����Ұ�5")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�d�����Ұ�5")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM5
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�d�����Ұ�5")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�d�����Ұ�5")
        End If
        intCount = intCount + 1
        If IsNull(mFDENBUN_PRM6) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�d�����Ұ�6")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�d�����Ұ�6")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM6
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�d�����Ұ�6")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�d�����Ұ�6")
        End If
        intCount = intCount + 1
        If IsNull(mFTRNS_SERIAL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�����ره�(MC��)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�����ره�(MC��)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_SERIAL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�����ره�(MC��)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�����ره�(MC��)")
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
        If IsNull(mFDENBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ʐM�d��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ʐM�d��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ʐM�d��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ʐM�d��")
        End If
        intCount = intCount + 1
        If IsNull(mFDENBUN02) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ʐM�d��02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ʐM�d��02")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN02
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ʐM�d��02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ʐM�d��02")
        End If
        intCount = intCount + 1
        If IsNull(mFPROGRESS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�i�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�i�����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPROGRESS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�i�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�i�����")
        End If
        intCount = intCount + 1
        If IsNull(mFRES_CD_EQ) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ݔ���������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ݔ���������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRES_CD_EQ
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ݔ���������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ݔ���������")
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
    Public Sub DELETE_TLIF_TRNS_RECV()
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
        ElseIf IsNull(mFENTRY_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�o�^��]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFEQ_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�ݔ�ID]"
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
        strSQL.Append(vbCrLf & "    TLIF_TRNS_RECV")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FENTRY_NO) = True Then
            strSQL.Append(vbCrLf & "    AND FENTRY_NO IS NULL --�o�^��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_NO
            strSQL.Append(vbCrLf & "    AND FENTRY_NO = :" & UBound(strBindField) - 1 & " --�o�^��")
        End If
        If IsNull(FEQ_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FEQ_ID IS NULL --�ݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --�ݔ�ID")
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
    Public Sub DELETE_TLIF_TRNS_RECV_ANY()
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
        strSQL.Append(vbCrLf & "    TLIF_TRNS_RECV")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(FENTRY_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_NO
            strSQL.Append(vbCrLf & "    AND FENTRY_NO = :" & UBound(strBindField) - 1 & " --�o�^��")
        End If
        If IsNotNull(FEQ_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --�ݔ�ID")
        End If
        If IsNotNull(FCOMMAND_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOMMAND_ID
            strSQL.Append(vbCrLf & "    AND FCOMMAND_ID = :" & UBound(strBindField) - 1 & " --�����ID")
        End If
        If IsNotNull(FPALLET_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --��گ�ID")
        End If
        If IsNotNull(FTEXT_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTEXT_ID
            strSQL.Append(vbCrLf & "    AND FTEXT_ID = :" & UBound(strBindField) - 1 & " --÷��ID")
        End If
        If IsNotNull(FDENBUN_PRM1) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM1
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM1 = :" & UBound(strBindField) - 1 & " --�d�����Ұ�1")
        End If
        If IsNotNull(FDENBUN_PRM2) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM2
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM2 = :" & UBound(strBindField) - 1 & " --�d�����Ұ�2")
        End If
        If IsNotNull(FDENBUN_PRM3) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM3
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM3 = :" & UBound(strBindField) - 1 & " --�d�����Ұ�3")
        End If
        If IsNotNull(FDENBUN_PRM4) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM4
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM4 = :" & UBound(strBindField) - 1 & " --�d�����Ұ�4")
        End If
        If IsNotNull(FDENBUN_PRM5) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM5
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM5 = :" & UBound(strBindField) - 1 & " --�d�����Ұ�5")
        End If
        If IsNotNull(FDENBUN_PRM6) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN_PRM6
            strSQL.Append(vbCrLf & "    AND FDENBUN_PRM6 = :" & UBound(strBindField) - 1 & " --�d�����Ұ�6")
        End If
        If IsNotNull(FTRNS_SERIAL) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_SERIAL
            strSQL.Append(vbCrLf & "    AND FTRNS_SERIAL = :" & UBound(strBindField) - 1 & " --�����ره�(MC��)")
        End If
        If IsNotNull(FPRIORITY) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPRIORITY
            strSQL.Append(vbCrLf & "    AND FPRIORITY = :" & UBound(strBindField) - 1 & " --�D������")
        End If
        If IsNotNull(FDENBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN
            strSQL.Append(vbCrLf & "    AND FDENBUN = :" & UBound(strBindField) - 1 & " --�ʐM�d��")
        End If
        If IsNotNull(FDENBUN02) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDENBUN02
            strSQL.Append(vbCrLf & "    AND FDENBUN02 = :" & UBound(strBindField) - 1 & " --�ʐM�d��02")
        End If
        If IsNotNull(FPROGRESS) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPROGRESS
            strSQL.Append(vbCrLf & "    AND FPROGRESS = :" & UBound(strBindField) - 1 & " --�i�����")
        End If
        If IsNotNull(FRES_CD_EQ) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRES_CD_EQ
            strSQL.Append(vbCrLf & "    AND FRES_CD_EQ = :" & UBound(strBindField) - 1 & " --�ݔ���������")
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
        If IsNothing(objType.GetProperty("FENTRY_NO")) = False Then mFENTRY_NO = objObject.FENTRY_NO '�o�^��
        If IsNothing(objType.GetProperty("FEQ_ID")) = False Then mFEQ_ID = objObject.FEQ_ID '�ݔ�ID
        If IsNothing(objType.GetProperty("FCOMMAND_ID")) = False Then mFCOMMAND_ID = objObject.FCOMMAND_ID '�����ID
        If IsNothing(objType.GetProperty("FPALLET_ID")) = False Then mFPALLET_ID = objObject.FPALLET_ID '��گ�ID
        If IsNothing(objType.GetProperty("FTEXT_ID")) = False Then mFTEXT_ID = objObject.FTEXT_ID '÷��ID
        If IsNothing(objType.GetProperty("FDENBUN_PRM1")) = False Then mFDENBUN_PRM1 = objObject.FDENBUN_PRM1 '�d�����Ұ�1
        If IsNothing(objType.GetProperty("FDENBUN_PRM2")) = False Then mFDENBUN_PRM2 = objObject.FDENBUN_PRM2 '�d�����Ұ�2
        If IsNothing(objType.GetProperty("FDENBUN_PRM3")) = False Then mFDENBUN_PRM3 = objObject.FDENBUN_PRM3 '�d�����Ұ�3
        If IsNothing(objType.GetProperty("FDENBUN_PRM4")) = False Then mFDENBUN_PRM4 = objObject.FDENBUN_PRM4 '�d�����Ұ�4
        If IsNothing(objType.GetProperty("FDENBUN_PRM5")) = False Then mFDENBUN_PRM5 = objObject.FDENBUN_PRM5 '�d�����Ұ�5
        If IsNothing(objType.GetProperty("FDENBUN_PRM6")) = False Then mFDENBUN_PRM6 = objObject.FDENBUN_PRM6 '�d�����Ұ�6
        If IsNothing(objType.GetProperty("FTRNS_SERIAL")) = False Then mFTRNS_SERIAL = objObject.FTRNS_SERIAL '�����ره�(MC��)
        If IsNothing(objType.GetProperty("FPRIORITY")) = False Then mFPRIORITY = objObject.FPRIORITY '�D������
        If IsNothing(objType.GetProperty("FDENBUN")) = False Then mFDENBUN = objObject.FDENBUN '�ʐM�d��
        If IsNothing(objType.GetProperty("FDENBUN02")) = False Then mFDENBUN02 = objObject.FDENBUN02 '�ʐM�d��02
        If IsNothing(objType.GetProperty("FPROGRESS")) = False Then mFPROGRESS = objObject.FPROGRESS '�i�����
        If IsNothing(objType.GetProperty("FRES_CD_EQ")) = False Then mFRES_CD_EQ = objObject.FRES_CD_EQ '�ݔ���������
        If IsNothing(objType.GetProperty("FENTRY_DT")) = False Then mFENTRY_DT = objObject.FENTRY_DT '�o�^����
        If IsNothing(objType.GetProperty("FUPDATE_DT")) = False Then mFUPDATE_DT = objObject.FUPDATE_DT '�X�V����

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
        mFENTRY_NO = Nothing
        mFEQ_ID = Nothing
        mFCOMMAND_ID = Nothing
        mFPALLET_ID = Nothing
        mFTEXT_ID = Nothing
        mFDENBUN_PRM1 = Nothing
        mFDENBUN_PRM2 = Nothing
        mFDENBUN_PRM3 = Nothing
        mFDENBUN_PRM4 = Nothing
        mFDENBUN_PRM5 = Nothing
        mFDENBUN_PRM6 = Nothing
        mFTRNS_SERIAL = Nothing
        mFPRIORITY = Nothing
        mFDENBUN = Nothing
        mFDENBUN02 = Nothing
        mFPROGRESS = Nothing
        mFRES_CD_EQ = Nothing
        mFENTRY_DT = Nothing
        mFUPDATE_DT = Nothing


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
        mFENTRY_NO = TO_STRING_NULLABLE(objRow("FENTRY_NO"))
        mFEQ_ID = TO_STRING_NULLABLE(objRow("FEQ_ID"))
        mFCOMMAND_ID = TO_STRING_NULLABLE(objRow("FCOMMAND_ID"))
        mFPALLET_ID = TO_STRING_NULLABLE(objRow("FPALLET_ID"))
        mFTEXT_ID = TO_STRING_NULLABLE(objRow("FTEXT_ID"))
        mFDENBUN_PRM1 = TO_STRING_NULLABLE(objRow("FDENBUN_PRM1"))
        mFDENBUN_PRM2 = TO_STRING_NULLABLE(objRow("FDENBUN_PRM2"))
        mFDENBUN_PRM3 = TO_STRING_NULLABLE(objRow("FDENBUN_PRM3"))
        mFDENBUN_PRM4 = TO_STRING_NULLABLE(objRow("FDENBUN_PRM4"))
        mFDENBUN_PRM5 = TO_STRING_NULLABLE(objRow("FDENBUN_PRM5"))
        mFDENBUN_PRM6 = TO_STRING_NULLABLE(objRow("FDENBUN_PRM6"))
        mFTRNS_SERIAL = TO_STRING_NULLABLE(objRow("FTRNS_SERIAL"))
        mFPRIORITY = TO_INTEGER_NULLABLE(objRow("FPRIORITY"))
        mFDENBUN = TO_STRING_NULLABLE(objRow("FDENBUN"))
        mFDENBUN02 = TO_STRING_NULLABLE(objRow("FDENBUN02"))
        mFPROGRESS = TO_INTEGER_NULLABLE(objRow("FPROGRESS"))
        mFRES_CD_EQ = TO_STRING_NULLABLE(objRow("FRES_CD_EQ"))
        mFENTRY_DT = TO_DATE_NULLABLE(objRow("FENTRY_DT"))
        mFUPDATE_DT = TO_DATE_NULLABLE(objRow("FUPDATE_DT"))


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
        strMsg &= "[ð��ٖ�:���������MIF]"
        If IsNotNull(FENTRY_NO) Then
            strMsg &= "[�o�^��:" & FENTRY_NO & "]"
        End If
        If IsNotNull(FEQ_ID) Then
            strMsg &= "[�ݔ�ID:" & FEQ_ID & "]"
        End If
        If IsNotNull(FCOMMAND_ID) Then
            strMsg &= "[�����ID:" & FCOMMAND_ID & "]"
        End If
        If IsNotNull(FPALLET_ID) Then
            strMsg &= "[��گ�ID:" & FPALLET_ID & "]"
        End If
        If IsNotNull(FTEXT_ID) Then
            strMsg &= "[÷��ID:" & FTEXT_ID & "]"
        End If
        If IsNotNull(FDENBUN_PRM1) Then
            strMsg &= "[�d�����Ұ�1:" & FDENBUN_PRM1 & "]"
        End If
        If IsNotNull(FDENBUN_PRM2) Then
            strMsg &= "[�d�����Ұ�2:" & FDENBUN_PRM2 & "]"
        End If
        If IsNotNull(FDENBUN_PRM3) Then
            strMsg &= "[�d�����Ұ�3:" & FDENBUN_PRM3 & "]"
        End If
        If IsNotNull(FDENBUN_PRM4) Then
            strMsg &= "[�d�����Ұ�4:" & FDENBUN_PRM4 & "]"
        End If
        If IsNotNull(FDENBUN_PRM5) Then
            strMsg &= "[�d�����Ұ�5:" & FDENBUN_PRM5 & "]"
        End If
        If IsNotNull(FDENBUN_PRM6) Then
            strMsg &= "[�d�����Ұ�6:" & FDENBUN_PRM6 & "]"
        End If
        If IsNotNull(FTRNS_SERIAL) Then
            strMsg &= "[�����ره�(MC��):" & FTRNS_SERIAL & "]"
        End If
        If IsNotNull(FPRIORITY) Then
            strMsg &= "[�D������:" & FPRIORITY & "]"
        End If
        If IsNotNull(FDENBUN) Then
            strMsg &= "[�ʐM�d��:" & FDENBUN & "]"
        End If
        If IsNotNull(FDENBUN02) Then
            strMsg &= "[�ʐM�d��02:" & FDENBUN02 & "]"
        End If
        If IsNotNull(FPROGRESS) Then
            strMsg &= "[�i�����:" & FPROGRESS & "]"
        End If
        If IsNotNull(FRES_CD_EQ) Then
            strMsg &= "[�ݔ���������:" & FRES_CD_EQ & "]"
        End If
        If IsNotNull(FENTRY_DT) Then
            strMsg &= "[�o�^����:" & FENTRY_DT & "]"
        End If
        If IsNotNull(FUPDATE_DT) Then
            strMsg &= "[�X�V����:" & FUPDATE_DT & "]"
        End If


    End Sub
#End Region
    '����������������
    '**********************************************************************************************

    '**********************************************************************************************
    '���������ы���
#Region "  ���������MIF�ǉ�   [SEQ������]                     (Public  ADD_TLIF_TRNS_SEND_SEQ)"
    Public Sub ADD_TLIF_TRNS_RECV_SEQ()
        Try
            'Dim strSQL As String        'SQL��
            Dim strMsg As String        'ү����
            'Dim intRetSQL As Integer    'SQL���s�߂�l

            '***********************
            '�����è����
            '***********************
            If mFEQ_ID = DEFAULT_STRING Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�ݔ�ID]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '�o�^���̓���
            '***********************
            Dim objTPRG_SEQNO As New TBL_TPRG_SEQNO(Owner, ObjDb, ObjDbLog) '���ݽ���׽
            objTPRG_SEQNO.FSEQ_ID = FSEQ_ID_SSVRENTRY_NO_TRNS_R              '���ݽID
            mFENTRY_NO = objTPRG_SEQNO.GET_ENTRY_NO()                       '�o�^���̓���


            '***********************
            '�ǉ�SQL�쐬
            '***********************
            Me.ADD_TLIF_TRNS_RECV()


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
#Region "  ���������MIF�폜   [��گ�ID]                       (Public  DELETE_TLIF_TRNS_RECV_PALLET)"
    Public Sub DELETE_TLIF_TRNS_RECV_PALLET()
        Try
            Dim strSQL As String        'SQL��
            Dim strMsg As String        'ү����
            Dim intRetSQL As Integer    'SQL���s�߂�l

            '***********************
            '�����è����
            '***********************
            If IsNull(mFPALLET_ID) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[��گ�ID]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '�폜SQL�쐬
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "DELETE"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TLIF_TRNS_RECV"
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
#Region "  �ʐM�ُ�ں��ގ擾                                    (Public  GET_TLIF_TRNS_RECV_ERROR_RECORD)"
    Public Function GET_TLIF_TRNS_RECV_ERROR_RECORD() As RetCode
        Try
            Dim strSQL As String            'SQL��
            Dim strMsg As String            'ү����
            Dim objDataSet As New DataSet   '�ް����
            Dim strDataSetName As String    '�ް���Ė�


            '***********************
            '�����è����
            '***********************
            If mFEQ_ID = DEFAULT_STRING Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�ݔ�ID]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '�ʐM�ُ�ں�������
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    *"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TLIF_TRNS_RECV"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FEQ_ID = '" & TO_STRING(mFEQ_ID) & "'"                      '�ݔ�ID
            strSQL &= vbCrLf & "    AND FCOMMAND_ID = '" & TO_STRING(FCOMMAND_ID_SCUT_EQ) & "'"      '�����ID
            strSQL &= vbCrLf
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TLIF_TRNS_RECV"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                '(���������ꍇ)
                Return (RetCode.OK)
            Else
                '(������Ȃ������ꍇ)
                Return (RetCode.NotFound)
            End If


        Catch ex As Exception
            Throw ex

        End Try
    End Function
#End Region
    '���������ы���
    '**********************************************************************************************


    '**********************************************************************************************
    '���������ьŗL

    '���������ьŗL
    '**********************************************************************************************

End Class
