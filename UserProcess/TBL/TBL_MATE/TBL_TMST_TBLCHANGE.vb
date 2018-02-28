'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation All Rights Reserved
'
' �y���́zMaterialStreamð��ٸ׽
' �y�@�\�z�ύX����\��Ͻ�ð��ٸ׽
' �y�쐬�z2008/08/31  KSH                                   Rev 0.00
'**********************************************************************************************

#Region "  Imports"
Imports System
Imports System.Text
Imports MateCommon
Imports MateCommon.clsConst
Imports JobCommon
#End Region

''' <summary>
''' �ύX����\��Ͻ�ð��ٸ׽
''' </summary>
Public Class TBL_TMST_TBLCHANGE
    Inherits clsTemplateTable

    '**********************************************************************************************
    '����������������
#Region "  �׽�ϐ���`                  "
    '�����è
    Private mobjAryMe As TBL_TMST_TBLCHANGE()                                    '�ύX����\��Ͻ�
    Private mstrUSER_SQL As String                                               'հ�ްSQL
    Private mORDER_BY As String                                                  'OrderBy��
    Private mWHERE As String                                                     'Where��
    Private mFSYORI_ID As String                                                 '����ID
    Private mFTABLE_NAME As String                                               'ð��ٖ�
    Private mFFIELD_NAME As String                                               '̨���ޖ�
    Private mFGAMEN_DISP As String                                               '�\���p����
    Private mFWIDTH_CELL As Nullable(Of Integer)                                 '�ٕ�
    Private mFORDER As Nullable(Of Integer)                                      '�\����
    Private mFTEXT_ALIGN As Nullable(Of Integer)                                 '÷�Ĕz�u�ʒu
    Private mFDISP_FORMAT As String                                              '�\��̫�ϯ�
    Private mFLISTDSP_FLAG As Nullable(Of Integer)                               '�ꗗ�\���׸�
    Private mFDTLDSP_FLAG As Nullable(Of Integer)                                '�ڍ׈ꗗ�\���׸�
    Private mFDATA_TYPE As Nullable(Of Integer)                                  '�ް�����
#End Region
#Region "  �����è��`                  "
    ''' <summary>
    ''' ���ѕϐ� (���׽�^�z��)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_TMST_TBLCHANGE()
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
    ''' ̨���ޖ�
    ''' </summary>
    Public Property FFIELD_NAME() As String
        Get
            Return mFFIELD_NAME
        End Get
        Set(ByVal Value As String)
            mFFIELD_NAME = Value
        End Set
    End Property
    ''' <summary>
    ''' �\���p����
    ''' </summary>
    Public Property FGAMEN_DISP() As String
        Get
            Return mFGAMEN_DISP
        End Get
        Set(ByVal Value As String)
            mFGAMEN_DISP = Value
        End Set
    End Property
    ''' <summary>
    ''' �ٕ�
    ''' </summary>
    Public Property FWIDTH_CELL() As Nullable(Of Integer)
        Get
            Return mFWIDTH_CELL
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFWIDTH_CELL = Value
        End Set
    End Property
    ''' <summary>
    ''' �\����
    ''' </summary>
    Public Property FORDER() As Nullable(Of Integer)
        Get
            Return mFORDER
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFORDER = Value
        End Set
    End Property
    ''' <summary>
    ''' ÷�Ĕz�u�ʒu
    ''' </summary>
    Public Property FTEXT_ALIGN() As Nullable(Of Integer)
        Get
            Return mFTEXT_ALIGN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFTEXT_ALIGN = Value
        End Set
    End Property
    ''' <summary>
    ''' �\��̫�ϯ�
    ''' </summary>
    Public Property FDISP_FORMAT() As String
        Get
            Return mFDISP_FORMAT
        End Get
        Set(ByVal Value As String)
            mFDISP_FORMAT = Value
        End Set
    End Property
    ''' <summary>
    ''' �ꗗ�\���׸�
    ''' </summary>
    Public Property FLISTDSP_FLAG() As Nullable(Of Integer)
        Get
            Return mFLISTDSP_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFLISTDSP_FLAG = Value
        End Set
    End Property
    ''' <summary>
    ''' �ڍ׈ꗗ�\���׸�
    ''' </summary>
    Public Property FDTLDSP_FLAG() As Nullable(Of Integer)
        Get
            Return mFDTLDSP_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFDTLDSP_FLAG = Value
        End Set
    End Property
    ''' <summary>
    ''' �ް�����
    ''' </summary>
    Public Property FDATA_TYPE() As Nullable(Of Integer)
        Get
            Return mFDATA_TYPE
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFDATA_TYPE = Value
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
    Public Function GET_TMST_TBLCHANGE(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    TMST_TBLCHANGE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FSYORI_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYORI_ID
            strSQL.Append(vbCrLf & "    AND FSYORI_ID = :" & UBound(strBindField) - 1 & " --����ID")
        End If
        If IsNull(FTABLE_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTABLE_NAME
            strSQL.Append(vbCrLf & "    AND FTABLE_NAME = :" & UBound(strBindField) - 1 & " --ð��ٖ�")
        End If
        If IsNull(FFIELD_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFFIELD_NAME
            strSQL.Append(vbCrLf & "    AND FFIELD_NAME = :" & UBound(strBindField) - 1 & " --̨���ޖ�")
        End If
        If IsNull(FGAMEN_DISP) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGAMEN_DISP
            strSQL.Append(vbCrLf & "    AND FGAMEN_DISP = :" & UBound(strBindField) - 1 & " --�\���p����")
        End If
        If IsNull(FWIDTH_CELL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFWIDTH_CELL
            strSQL.Append(vbCrLf & "    AND FWIDTH_CELL = :" & UBound(strBindField) - 1 & " --�ٕ�")
        End If
        If IsNull(FORDER) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFORDER
            strSQL.Append(vbCrLf & "    AND FORDER = :" & UBound(strBindField) - 1 & " --�\����")
        End If
        If IsNull(FTEXT_ALIGN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTEXT_ALIGN
            strSQL.Append(vbCrLf & "    AND FTEXT_ALIGN = :" & UBound(strBindField) - 1 & " --÷�Ĕz�u�ʒu")
        End If
        If IsNull(FDISP_FORMAT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_FORMAT
            strSQL.Append(vbCrLf & "    AND FDISP_FORMAT = :" & UBound(strBindField) - 1 & " --�\��̫�ϯ�")
        End If
        If IsNull(FLISTDSP_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLISTDSP_FLAG
            strSQL.Append(vbCrLf & "    AND FLISTDSP_FLAG = :" & UBound(strBindField) - 1 & " --�ꗗ�\���׸�")
        End If
        If IsNull(FDTLDSP_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDTLDSP_FLAG
            strSQL.Append(vbCrLf & "    AND FDTLDSP_FLAG = :" & UBound(strBindField) - 1 & " --�ڍ׈ꗗ�\���׸�")
        End If
        If IsNull(FDATA_TYPE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDATA_TYPE
            strSQL.Append(vbCrLf & "    AND FDATA_TYPE = :" & UBound(strBindField) - 1 & " --�ް�����")
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
        strDataSetName = "TMST_TBLCHANGE"
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
    Public Function GET_TMST_TBLCHANGE_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    TMST_TBLCHANGE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FSYORI_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYORI_ID
            strSQL.Append(vbCrLf & "    AND FSYORI_ID = :" & UBound(strBindField) - 1 & " --����ID")
        End If
        If IsNull(FTABLE_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTABLE_NAME
            strSQL.Append(vbCrLf & "    AND FTABLE_NAME = :" & UBound(strBindField) - 1 & " --ð��ٖ�")
        End If
        If IsNull(FFIELD_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFFIELD_NAME
            strSQL.Append(vbCrLf & "    AND FFIELD_NAME = :" & UBound(strBindField) - 1 & " --̨���ޖ�")
        End If
        If IsNull(FGAMEN_DISP) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGAMEN_DISP
            strSQL.Append(vbCrLf & "    AND FGAMEN_DISP = :" & UBound(strBindField) - 1 & " --�\���p����")
        End If
        If IsNull(FWIDTH_CELL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFWIDTH_CELL
            strSQL.Append(vbCrLf & "    AND FWIDTH_CELL = :" & UBound(strBindField) - 1 & " --�ٕ�")
        End If
        If IsNull(FORDER) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFORDER
            strSQL.Append(vbCrLf & "    AND FORDER = :" & UBound(strBindField) - 1 & " --�\����")
        End If
        If IsNull(FTEXT_ALIGN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTEXT_ALIGN
            strSQL.Append(vbCrLf & "    AND FTEXT_ALIGN = :" & UBound(strBindField) - 1 & " --÷�Ĕz�u�ʒu")
        End If
        If IsNull(FDISP_FORMAT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_FORMAT
            strSQL.Append(vbCrLf & "    AND FDISP_FORMAT = :" & UBound(strBindField) - 1 & " --�\��̫�ϯ�")
        End If
        If IsNull(FLISTDSP_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLISTDSP_FLAG
            strSQL.Append(vbCrLf & "    AND FLISTDSP_FLAG = :" & UBound(strBindField) - 1 & " --�ꗗ�\���׸�")
        End If
        If IsNull(FDTLDSP_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDTLDSP_FLAG
            strSQL.Append(vbCrLf & "    AND FDTLDSP_FLAG = :" & UBound(strBindField) - 1 & " --�ڍ׈ꗗ�\���׸�")
        End If
        If IsNull(FDATA_TYPE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDATA_TYPE
            strSQL.Append(vbCrLf & "    AND FDATA_TYPE = :" & UBound(strBindField) - 1 & " --�ް�����")
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
        strDataSetName = "TMST_TBLCHANGE"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TMST_TBLCHANGE(Owner, objDb, objDbLog)
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
    Public Function GET_TMST_TBLCHANGE_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "TMST_TBLCHANGE"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TMST_TBLCHANGE(Owner, objDb, objDbLog)
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
    Public Function GET_TMST_TBLCHANGE_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    TMST_TBLCHANGE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FSYORI_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYORI_ID
            strSQL.Append(vbCrLf & "    AND FSYORI_ID = :" & UBound(strBindField) - 1 & " --����ID")
        End If
        If IsNull(FTABLE_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTABLE_NAME
            strSQL.Append(vbCrLf & "    AND FTABLE_NAME = :" & UBound(strBindField) - 1 & " --ð��ٖ�")
        End If
        If IsNull(FFIELD_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFFIELD_NAME
            strSQL.Append(vbCrLf & "    AND FFIELD_NAME = :" & UBound(strBindField) - 1 & " --̨���ޖ�")
        End If
        If IsNull(FGAMEN_DISP) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGAMEN_DISP
            strSQL.Append(vbCrLf & "    AND FGAMEN_DISP = :" & UBound(strBindField) - 1 & " --�\���p����")
        End If
        If IsNull(FWIDTH_CELL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFWIDTH_CELL
            strSQL.Append(vbCrLf & "    AND FWIDTH_CELL = :" & UBound(strBindField) - 1 & " --�ٕ�")
        End If
        If IsNull(FORDER) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFORDER
            strSQL.Append(vbCrLf & "    AND FORDER = :" & UBound(strBindField) - 1 & " --�\����")
        End If
        If IsNull(FTEXT_ALIGN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTEXT_ALIGN
            strSQL.Append(vbCrLf & "    AND FTEXT_ALIGN = :" & UBound(strBindField) - 1 & " --÷�Ĕz�u�ʒu")
        End If
        If IsNull(FDISP_FORMAT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_FORMAT
            strSQL.Append(vbCrLf & "    AND FDISP_FORMAT = :" & UBound(strBindField) - 1 & " --�\��̫�ϯ�")
        End If
        If IsNull(FLISTDSP_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLISTDSP_FLAG
            strSQL.Append(vbCrLf & "    AND FLISTDSP_FLAG = :" & UBound(strBindField) - 1 & " --�ꗗ�\���׸�")
        End If
        If IsNull(FDTLDSP_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDTLDSP_FLAG
            strSQL.Append(vbCrLf & "    AND FDTLDSP_FLAG = :" & UBound(strBindField) - 1 & " --�ڍ׈ꗗ�\���׸�")
        End If
        If IsNull(FDATA_TYPE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDATA_TYPE
            strSQL.Append(vbCrLf & "    AND FDATA_TYPE = :" & UBound(strBindField) - 1 & " --�ް�����")
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
        strDataSetName = "TMST_TBLCHANGE"
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
    Public Sub UPDATE_TMST_TBLCHANGE()
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
        ElseIf IsNull(mFSYORI_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[����ID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFTABLE_NAME) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ð��ٖ�]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFFIELD_NAME) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[̨���ޖ�]"
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
        strSQL.Append(vbCrLf & "    TMST_TBLCHANGE")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
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
        If IsNull(mFFIELD_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FFIELD_NAME = NULL --̨���ޖ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FFIELD_NAME = NULL --̨���ޖ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFFIELD_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FFIELD_NAME = :" & Ubound(strBindField) - 1 & " --̨���ޖ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FFIELD_NAME = :" & Ubound(strBindField) - 1 & " --̨���ޖ�")
        End If
        intCount = intCount + 1
        If IsNull(mFGAMEN_DISP) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FGAMEN_DISP = NULL --�\���p����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FGAMEN_DISP = NULL --�\���p����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGAMEN_DISP
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FGAMEN_DISP = :" & Ubound(strBindField) - 1 & " --�\���p����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FGAMEN_DISP = :" & Ubound(strBindField) - 1 & " --�\���p����")
        End If
        intCount = intCount + 1
        If IsNull(mFWIDTH_CELL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FWIDTH_CELL = NULL --�ٕ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FWIDTH_CELL = NULL --�ٕ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFWIDTH_CELL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FWIDTH_CELL = :" & Ubound(strBindField) - 1 & " --�ٕ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FWIDTH_CELL = :" & Ubound(strBindField) - 1 & " --�ٕ�")
        End If
        intCount = intCount + 1
        If IsNull(mFORDER) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FORDER = NULL --�\����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FORDER = NULL --�\����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFORDER
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FORDER = :" & Ubound(strBindField) - 1 & " --�\����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FORDER = :" & Ubound(strBindField) - 1 & " --�\����")
        End If
        intCount = intCount + 1
        If IsNull(mFTEXT_ALIGN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTEXT_ALIGN = NULL --÷�Ĕz�u�ʒu")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTEXT_ALIGN = NULL --÷�Ĕz�u�ʒu")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTEXT_ALIGN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTEXT_ALIGN = :" & Ubound(strBindField) - 1 & " --÷�Ĕz�u�ʒu")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTEXT_ALIGN = :" & Ubound(strBindField) - 1 & " --÷�Ĕz�u�ʒu")
        End If
        intCount = intCount + 1
        If IsNull(mFDISP_FORMAT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDISP_FORMAT = NULL --�\��̫�ϯ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDISP_FORMAT = NULL --�\��̫�ϯ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_FORMAT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDISP_FORMAT = :" & Ubound(strBindField) - 1 & " --�\��̫�ϯ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDISP_FORMAT = :" & Ubound(strBindField) - 1 & " --�\��̫�ϯ�")
        End If
        intCount = intCount + 1
        If IsNull(mFLISTDSP_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLISTDSP_FLAG = NULL --�ꗗ�\���׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLISTDSP_FLAG = NULL --�ꗗ�\���׸�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLISTDSP_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLISTDSP_FLAG = :" & Ubound(strBindField) - 1 & " --�ꗗ�\���׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLISTDSP_FLAG = :" & Ubound(strBindField) - 1 & " --�ꗗ�\���׸�")
        End If
        intCount = intCount + 1
        If IsNull(mFDTLDSP_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDTLDSP_FLAG = NULL --�ڍ׈ꗗ�\���׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDTLDSP_FLAG = NULL --�ڍ׈ꗗ�\���׸�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDTLDSP_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDTLDSP_FLAG = :" & Ubound(strBindField) - 1 & " --�ڍ׈ꗗ�\���׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDTLDSP_FLAG = :" & Ubound(strBindField) - 1 & " --�ڍ׈ꗗ�\���׸�")
        End If
        intCount = intCount + 1
        If IsNull(mFDATA_TYPE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDATA_TYPE = NULL --�ް�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDATA_TYPE = NULL --�ް�����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDATA_TYPE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDATA_TYPE = :" & Ubound(strBindField) - 1 & " --�ް�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDATA_TYPE = :" & Ubound(strBindField) - 1 & " --�ް�����")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FSYORI_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FSYORI_ID IS NULL --����ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYORI_ID
            strSQL.Append(vbCrLf & "    AND FSYORI_ID = :" & UBound(strBindField) - 1 & " --����ID")
        End If
        If IsNull(FTABLE_NAME) = True Then
            strSQL.Append(vbCrLf & "    AND FTABLE_NAME IS NULL --ð��ٖ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTABLE_NAME
            strSQL.Append(vbCrLf & "    AND FTABLE_NAME = :" & UBound(strBindField) - 1 & " --ð��ٖ�")
        End If
        If IsNull(FFIELD_NAME) = True Then
            strSQL.Append(vbCrLf & "    AND FFIELD_NAME IS NULL --̨���ޖ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFFIELD_NAME
            strSQL.Append(vbCrLf & "    AND FFIELD_NAME = :" & UBound(strBindField) - 1 & " --̨���ޖ�")
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
    Public Sub ADD_TMST_TBLCHANGE()
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
        ElseIf IsNull(mFSYORI_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[����ID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFTABLE_NAME) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ð��ٖ�]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFFIELD_NAME) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[̨���ޖ�]"
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
        strSQL.Append(vbCrLf & "    TMST_TBLCHANGE")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
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
        If IsNull(mFFIELD_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --̨���ޖ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --̨���ޖ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFFIELD_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --̨���ޖ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --̨���ޖ�")
        End If
        intCount = intCount + 1
        If IsNull(mFGAMEN_DISP) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�\���p����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�\���p����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGAMEN_DISP
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�\���p����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�\���p����")
        End If
        intCount = intCount + 1
        If IsNull(mFWIDTH_CELL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ٕ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ٕ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFWIDTH_CELL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ٕ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ٕ�")
        End If
        intCount = intCount + 1
        If IsNull(mFORDER) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�\����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�\����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFORDER
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�\����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�\����")
        End If
        intCount = intCount + 1
        If IsNull(mFTEXT_ALIGN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --÷�Ĕz�u�ʒu")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --÷�Ĕz�u�ʒu")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTEXT_ALIGN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --÷�Ĕz�u�ʒu")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --÷�Ĕz�u�ʒu")
        End If
        intCount = intCount + 1
        If IsNull(mFDISP_FORMAT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�\��̫�ϯ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�\��̫�ϯ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_FORMAT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�\��̫�ϯ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�\��̫�ϯ�")
        End If
        intCount = intCount + 1
        If IsNull(mFLISTDSP_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ꗗ�\���׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ꗗ�\���׸�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLISTDSP_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ꗗ�\���׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ꗗ�\���׸�")
        End If
        intCount = intCount + 1
        If IsNull(mFDTLDSP_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ڍ׈ꗗ�\���׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ڍ׈ꗗ�\���׸�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDTLDSP_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ڍ׈ꗗ�\���׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ڍ׈ꗗ�\���׸�")
        End If
        intCount = intCount + 1
        If IsNull(mFDATA_TYPE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ް�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ް�����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDATA_TYPE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ް�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ް�����")
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
    Public Sub DELETE_TMST_TBLCHANGE()
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
        ElseIf IsNull(mFSYORI_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[����ID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFTABLE_NAME) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ð��ٖ�]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFFIELD_NAME) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[̨���ޖ�]"
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
        strSQL.Append(vbCrLf & "    TMST_TBLCHANGE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FSYORI_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FSYORI_ID IS NULL --����ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYORI_ID
            strSQL.Append(vbCrLf & "    AND FSYORI_ID = :" & UBound(strBindField) - 1 & " --����ID")
        End If
        If IsNull(FTABLE_NAME) = True Then
            strSQL.Append(vbCrLf & "    AND FTABLE_NAME IS NULL --ð��ٖ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTABLE_NAME
            strSQL.Append(vbCrLf & "    AND FTABLE_NAME = :" & UBound(strBindField) - 1 & " --ð��ٖ�")
        End If
        If IsNull(FFIELD_NAME) = True Then
            strSQL.Append(vbCrLf & "    AND FFIELD_NAME IS NULL --̨���ޖ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFFIELD_NAME
            strSQL.Append(vbCrLf & "    AND FFIELD_NAME = :" & UBound(strBindField) - 1 & " --̨���ޖ�")
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
    Public Sub DELETE_TMST_TBLCHANGE_ANY()
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
        strSQL.Append(vbCrLf & "    TMST_TBLCHANGE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(FSYORI_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYORI_ID
            strSQL.Append(vbCrLf & "    AND FSYORI_ID = :" & UBound(strBindField) - 1 & " --����ID")
        End If
        If IsNotNull(FTABLE_NAME) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTABLE_NAME
            strSQL.Append(vbCrLf & "    AND FTABLE_NAME = :" & UBound(strBindField) - 1 & " --ð��ٖ�")
        End If
        If IsNotNull(FFIELD_NAME) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFFIELD_NAME
            strSQL.Append(vbCrLf & "    AND FFIELD_NAME = :" & UBound(strBindField) - 1 & " --̨���ޖ�")
        End If
        If IsNotNull(FGAMEN_DISP) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGAMEN_DISP
            strSQL.Append(vbCrLf & "    AND FGAMEN_DISP = :" & UBound(strBindField) - 1 & " --�\���p����")
        End If
        If IsNotNull(FWIDTH_CELL) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFWIDTH_CELL
            strSQL.Append(vbCrLf & "    AND FWIDTH_CELL = :" & UBound(strBindField) - 1 & " --�ٕ�")
        End If
        If IsNotNull(FORDER) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFORDER
            strSQL.Append(vbCrLf & "    AND FORDER = :" & UBound(strBindField) - 1 & " --�\����")
        End If
        If IsNotNull(FTEXT_ALIGN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTEXT_ALIGN
            strSQL.Append(vbCrLf & "    AND FTEXT_ALIGN = :" & UBound(strBindField) - 1 & " --÷�Ĕz�u�ʒu")
        End If
        If IsNotNull(FDISP_FORMAT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_FORMAT
            strSQL.Append(vbCrLf & "    AND FDISP_FORMAT = :" & UBound(strBindField) - 1 & " --�\��̫�ϯ�")
        End If
        If IsNotNull(FLISTDSP_FLAG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLISTDSP_FLAG
            strSQL.Append(vbCrLf & "    AND FLISTDSP_FLAG = :" & UBound(strBindField) - 1 & " --�ꗗ�\���׸�")
        End If
        If IsNotNull(FDTLDSP_FLAG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDTLDSP_FLAG
            strSQL.Append(vbCrLf & "    AND FDTLDSP_FLAG = :" & UBound(strBindField) - 1 & " --�ڍ׈ꗗ�\���׸�")
        End If
        If IsNotNull(FDATA_TYPE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDATA_TYPE
            strSQL.Append(vbCrLf & "    AND FDATA_TYPE = :" & UBound(strBindField) - 1 & " --�ް�����")
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
        If IsNothing(objType.GetProperty("FSYORI_ID")) = False Then mFSYORI_ID = objObject.FSYORI_ID '����ID
        If IsNothing(objType.GetProperty("FTABLE_NAME")) = False Then mFTABLE_NAME = objObject.FTABLE_NAME 'ð��ٖ�
        If IsNothing(objType.GetProperty("FFIELD_NAME")) = False Then mFFIELD_NAME = objObject.FFIELD_NAME '̨���ޖ�
        If IsNothing(objType.GetProperty("FGAMEN_DISP")) = False Then mFGAMEN_DISP = objObject.FGAMEN_DISP '�\���p����
        If IsNothing(objType.GetProperty("FWIDTH_CELL")) = False Then mFWIDTH_CELL = objObject.FWIDTH_CELL '�ٕ�
        If IsNothing(objType.GetProperty("FORDER")) = False Then mFORDER = objObject.FORDER '�\����
        If IsNothing(objType.GetProperty("FTEXT_ALIGN")) = False Then mFTEXT_ALIGN = objObject.FTEXT_ALIGN '÷�Ĕz�u�ʒu
        If IsNothing(objType.GetProperty("FDISP_FORMAT")) = False Then mFDISP_FORMAT = objObject.FDISP_FORMAT '�\��̫�ϯ�
        If IsNothing(objType.GetProperty("FLISTDSP_FLAG")) = False Then mFLISTDSP_FLAG = objObject.FLISTDSP_FLAG '�ꗗ�\���׸�
        If IsNothing(objType.GetProperty("FDTLDSP_FLAG")) = False Then mFDTLDSP_FLAG = objObject.FDTLDSP_FLAG '�ڍ׈ꗗ�\���׸�
        If IsNothing(objType.GetProperty("FDATA_TYPE")) = False Then mFDATA_TYPE = objObject.FDATA_TYPE '�ް�����

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
        mFSYORI_ID = Nothing
        mFTABLE_NAME = Nothing
        mFFIELD_NAME = Nothing
        mFGAMEN_DISP = Nothing
        mFWIDTH_CELL = Nothing
        mFORDER = Nothing
        mFTEXT_ALIGN = Nothing
        mFDISP_FORMAT = Nothing
        mFLISTDSP_FLAG = Nothing
        mFDTLDSP_FLAG = Nothing
        mFDATA_TYPE = Nothing


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
        mFSYORI_ID = TO_STRING_NULLABLE(objRow("FSYORI_ID"))
        mFTABLE_NAME = TO_STRING_NULLABLE(objRow("FTABLE_NAME"))
        mFFIELD_NAME = TO_STRING_NULLABLE(objRow("FFIELD_NAME"))
        mFGAMEN_DISP = TO_STRING_NULLABLE(objRow("FGAMEN_DISP"))
        mFWIDTH_CELL = TO_INTEGER_NULLABLE(objRow("FWIDTH_CELL"))
        mFORDER = TO_INTEGER_NULLABLE(objRow("FORDER"))
        mFTEXT_ALIGN = TO_INTEGER_NULLABLE(objRow("FTEXT_ALIGN"))
        mFDISP_FORMAT = TO_STRING_NULLABLE(objRow("FDISP_FORMAT"))
        mFLISTDSP_FLAG = TO_INTEGER_NULLABLE(objRow("FLISTDSP_FLAG"))
        mFDTLDSP_FLAG = TO_INTEGER_NULLABLE(objRow("FDTLDSP_FLAG"))
        mFDATA_TYPE = TO_INTEGER_NULLABLE(objRow("FDATA_TYPE"))


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
        strMsg &= "[ð��ٖ�:�ύX����\��Ͻ�]"
        If IsNotNull(FSYORI_ID) Then
            strMsg &= "[����ID:" & FSYORI_ID & "]"
        End If
        If IsNotNull(FTABLE_NAME) Then
            strMsg &= "[ð��ٖ�:" & FTABLE_NAME & "]"
        End If
        If IsNotNull(FFIELD_NAME) Then
            strMsg &= "[̨���ޖ�:" & FFIELD_NAME & "]"
        End If
        If IsNotNull(FGAMEN_DISP) Then
            strMsg &= "[�\���p����:" & FGAMEN_DISP & "]"
        End If
        If IsNotNull(FWIDTH_CELL) Then
            strMsg &= "[�ٕ�:" & FWIDTH_CELL & "]"
        End If
        If IsNotNull(FORDER) Then
            strMsg &= "[�\����:" & FORDER & "]"
        End If
        If IsNotNull(FTEXT_ALIGN) Then
            strMsg &= "[÷�Ĕz�u�ʒu:" & FTEXT_ALIGN & "]"
        End If
        If IsNotNull(FDISP_FORMAT) Then
            strMsg &= "[�\��̫�ϯ�:" & FDISP_FORMAT & "]"
        End If
        If IsNotNull(FLISTDSP_FLAG) Then
            strMsg &= "[�ꗗ�\���׸�:" & FLISTDSP_FLAG & "]"
        End If
        If IsNotNull(FDTLDSP_FLAG) Then
            strMsg &= "[�ڍ׈ꗗ�\���׸�:" & FDTLDSP_FLAG & "]"
        End If
        If IsNotNull(FDATA_TYPE) Then
            strMsg &= "[�ް�����:" & FDATA_TYPE & "]"
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
