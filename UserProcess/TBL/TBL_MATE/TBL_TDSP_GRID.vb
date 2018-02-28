'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' �y���́zMaterialStreamð��ٸ׽
' �y�@�\�z��د��Ͻ�ð��ٸ׽
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
''' ��د��Ͻ�ð��ٸ׽
''' </summary>
Public Class TBL_TDSP_GRID
    Inherits clsTemplateTable

    '**********************************************************************************************
    '����������������
#Region "  �׽�ϐ���`                  "
    '�����è
    Private mobjAryMe As TBL_TDSP_GRID()                                         '��د��Ͻ�
    Private mstrUSER_SQL As String                                               'հ�ްSQL
    Private mORDER_BY As String                                                  'OrderBy��
    Private mWHERE As String                                                     'Where��
    Private mFDISP_ID As String                                                  '���ID
    Private mFCTRL_ID As String                                                  '���۰�ID
    Private mFCOL_INDEX As Nullable(Of Integer)                                  '����ޯ��
    Private mFGRID_DISPLAYINDEX As Nullable(Of Integer)                          '��د�ޗ�\������
    Private mFGRID_ORDER_BY As Nullable(Of Integer)                              '��د�޵��ް�D�揇
    Private mFGRID_ORDER_ASCDESC As String                                       '��د�޵��ް�����~��
    Private mFGRID_H_TEXT As String                                              '��د��ͯ�ް÷��
    Private mFGRID_H_ALIGNMENT As String                                         '��د��ͯ�ް�z�u
    Private mFGRID_D_ALIGNMENT As String                                         '��د���ް��z�u
    Private mFGRID_D_FORMAT As String                                            '��د���ް�̫�ϯ�
    Private mFGRID_D_WIDTH As String                                             '��د���ް���
    Private mFGRID_COL_DISP_FLAG As Nullable(Of Integer)                         '��د�ޗ�\���׸�
#End Region
#Region "  �����è��`                  "
    ''' <summary>
    ''' ���ѕϐ� (���׽�^�z��)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_TDSP_GRID()
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
    ''' ���ID
    ''' </summary>
    Public Property FDISP_ID() As String
        Get
            Return mFDISP_ID
        End Get
        Set(ByVal Value As String)
            mFDISP_ID = Value
        End Set
    End Property
    ''' <summary>
    ''' ���۰�ID
    ''' </summary>
    Public Property FCTRL_ID() As String
        Get
            Return mFCTRL_ID
        End Get
        Set(ByVal Value As String)
            mFCTRL_ID = Value
        End Set
    End Property
    ''' <summary>
    ''' ����ޯ��
    ''' </summary>
    Public Property FCOL_INDEX() As Nullable(Of Integer)
        Get
            Return mFCOL_INDEX
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFCOL_INDEX = Value
        End Set
    End Property
    ''' <summary>
    ''' ��د�ޗ�\������
    ''' </summary>
    Public Property FGRID_DISPLAYINDEX() As Nullable(Of Integer)
        Get
            Return mFGRID_DISPLAYINDEX
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFGRID_DISPLAYINDEX = Value
        End Set
    End Property
    ''' <summary>
    ''' ��د�޵��ް�D�揇
    ''' </summary>
    Public Property FGRID_ORDER_BY() As Nullable(Of Integer)
        Get
            Return mFGRID_ORDER_BY
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFGRID_ORDER_BY = Value
        End Set
    End Property
    ''' <summary>
    ''' ��د�޵��ް�����~��
    ''' </summary>
    Public Property FGRID_ORDER_ASCDESC() As String
        Get
            Return mFGRID_ORDER_ASCDESC
        End Get
        Set(ByVal Value As String)
            mFGRID_ORDER_ASCDESC = Value
        End Set
    End Property
    ''' <summary>
    ''' ��د��ͯ�ް÷��
    ''' </summary>
    Public Property FGRID_H_TEXT() As String
        Get
            Return mFGRID_H_TEXT
        End Get
        Set(ByVal Value As String)
            mFGRID_H_TEXT = Value
        End Set
    End Property
    ''' <summary>
    ''' ��د��ͯ�ް�z�u
    ''' </summary>
    Public Property FGRID_H_ALIGNMENT() As String
        Get
            Return mFGRID_H_ALIGNMENT
        End Get
        Set(ByVal Value As String)
            mFGRID_H_ALIGNMENT = Value
        End Set
    End Property
    ''' <summary>
    ''' ��د���ް��z�u
    ''' </summary>
    Public Property FGRID_D_ALIGNMENT() As String
        Get
            Return mFGRID_D_ALIGNMENT
        End Get
        Set(ByVal Value As String)
            mFGRID_D_ALIGNMENT = Value
        End Set
    End Property
    ''' <summary>
    ''' ��د���ް�̫�ϯ�
    ''' </summary>
    Public Property FGRID_D_FORMAT() As String
        Get
            Return mFGRID_D_FORMAT
        End Get
        Set(ByVal Value As String)
            mFGRID_D_FORMAT = Value
        End Set
    End Property
    ''' <summary>
    ''' ��د���ް���
    ''' </summary>
    Public Property FGRID_D_WIDTH() As String
        Get
            Return mFGRID_D_WIDTH
        End Get
        Set(ByVal Value As String)
            mFGRID_D_WIDTH = Value
        End Set
    End Property
    ''' <summary>
    ''' ��د�ޗ�\���׸�
    ''' </summary>
    Public Property FGRID_COL_DISP_FLAG() As Nullable(Of Integer)
        Get
            Return mFGRID_COL_DISP_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFGRID_COL_DISP_FLAG = Value
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
    Public Function GET_TDSP_GRID(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    TDSP_GRID")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FDISP_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ID
            strSQL.Append(vbCrLf & "    AND FDISP_ID = :" & UBound(strBindField) - 1 & " --���ID")
        End If
        If IsNull(FCTRL_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCTRL_ID
            strSQL.Append(vbCrLf & "    AND FCTRL_ID = :" & UBound(strBindField) - 1 & " --���۰�ID")
        End If
        If IsNull(FCOL_INDEX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOL_INDEX
            strSQL.Append(vbCrLf & "    AND FCOL_INDEX = :" & UBound(strBindField) - 1 & " --����ޯ��")
        End If
        If IsNull(FGRID_DISPLAYINDEX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_DISPLAYINDEX
            strSQL.Append(vbCrLf & "    AND FGRID_DISPLAYINDEX = :" & UBound(strBindField) - 1 & " --��د�ޗ�\������")
        End If
        If IsNull(FGRID_ORDER_BY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_ORDER_BY
            strSQL.Append(vbCrLf & "    AND FGRID_ORDER_BY = :" & UBound(strBindField) - 1 & " --��د�޵��ް�D�揇")
        End If
        If IsNull(FGRID_ORDER_ASCDESC) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_ORDER_ASCDESC
            strSQL.Append(vbCrLf & "    AND FGRID_ORDER_ASCDESC = :" & UBound(strBindField) - 1 & " --��د�޵��ް�����~��")
        End If
        If IsNull(FGRID_H_TEXT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_H_TEXT
            strSQL.Append(vbCrLf & "    AND FGRID_H_TEXT = :" & UBound(strBindField) - 1 & " --��د��ͯ�ް÷��")
        End If
        If IsNull(FGRID_H_ALIGNMENT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_H_ALIGNMENT
            strSQL.Append(vbCrLf & "    AND FGRID_H_ALIGNMENT = :" & UBound(strBindField) - 1 & " --��د��ͯ�ް�z�u")
        End If
        If IsNull(FGRID_D_ALIGNMENT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_D_ALIGNMENT
            strSQL.Append(vbCrLf & "    AND FGRID_D_ALIGNMENT = :" & UBound(strBindField) - 1 & " --��د���ް��z�u")
        End If
        If IsNull(FGRID_D_FORMAT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_D_FORMAT
            strSQL.Append(vbCrLf & "    AND FGRID_D_FORMAT = :" & UBound(strBindField) - 1 & " --��د���ް�̫�ϯ�")
        End If
        If IsNull(FGRID_D_WIDTH) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_D_WIDTH
            strSQL.Append(vbCrLf & "    AND FGRID_D_WIDTH = :" & UBound(strBindField) - 1 & " --��د���ް���")
        End If
        If IsNull(FGRID_COL_DISP_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_COL_DISP_FLAG
            strSQL.Append(vbCrLf & "    AND FGRID_COL_DISP_FLAG = :" & UBound(strBindField) - 1 & " --��د�ޗ�\���׸�")
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
        strDataSetName = "TDSP_GRID"
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
    Public Function GET_TDSP_GRID_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    TDSP_GRID")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FDISP_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ID
            strSQL.Append(vbCrLf & "    AND FDISP_ID = :" & UBound(strBindField) - 1 & " --���ID")
        End If
        If IsNull(FCTRL_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCTRL_ID
            strSQL.Append(vbCrLf & "    AND FCTRL_ID = :" & UBound(strBindField) - 1 & " --���۰�ID")
        End If
        If IsNull(FCOL_INDEX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOL_INDEX
            strSQL.Append(vbCrLf & "    AND FCOL_INDEX = :" & UBound(strBindField) - 1 & " --����ޯ��")
        End If
        If IsNull(FGRID_DISPLAYINDEX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_DISPLAYINDEX
            strSQL.Append(vbCrLf & "    AND FGRID_DISPLAYINDEX = :" & UBound(strBindField) - 1 & " --��د�ޗ�\������")
        End If
        If IsNull(FGRID_ORDER_BY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_ORDER_BY
            strSQL.Append(vbCrLf & "    AND FGRID_ORDER_BY = :" & UBound(strBindField) - 1 & " --��د�޵��ް�D�揇")
        End If
        If IsNull(FGRID_ORDER_ASCDESC) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_ORDER_ASCDESC
            strSQL.Append(vbCrLf & "    AND FGRID_ORDER_ASCDESC = :" & UBound(strBindField) - 1 & " --��د�޵��ް�����~��")
        End If
        If IsNull(FGRID_H_TEXT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_H_TEXT
            strSQL.Append(vbCrLf & "    AND FGRID_H_TEXT = :" & UBound(strBindField) - 1 & " --��د��ͯ�ް÷��")
        End If
        If IsNull(FGRID_H_ALIGNMENT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_H_ALIGNMENT
            strSQL.Append(vbCrLf & "    AND FGRID_H_ALIGNMENT = :" & UBound(strBindField) - 1 & " --��د��ͯ�ް�z�u")
        End If
        If IsNull(FGRID_D_ALIGNMENT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_D_ALIGNMENT
            strSQL.Append(vbCrLf & "    AND FGRID_D_ALIGNMENT = :" & UBound(strBindField) - 1 & " --��د���ް��z�u")
        End If
        If IsNull(FGRID_D_FORMAT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_D_FORMAT
            strSQL.Append(vbCrLf & "    AND FGRID_D_FORMAT = :" & UBound(strBindField) - 1 & " --��د���ް�̫�ϯ�")
        End If
        If IsNull(FGRID_D_WIDTH) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_D_WIDTH
            strSQL.Append(vbCrLf & "    AND FGRID_D_WIDTH = :" & UBound(strBindField) - 1 & " --��د���ް���")
        End If
        If IsNull(FGRID_COL_DISP_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_COL_DISP_FLAG
            strSQL.Append(vbCrLf & "    AND FGRID_COL_DISP_FLAG = :" & UBound(strBindField) - 1 & " --��د�ޗ�\���׸�")
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
        strDataSetName = "TDSP_GRID"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TDSP_GRID(Owner, objDb, objDbLog)
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
    Public Function GET_TDSP_GRID_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "TDSP_GRID"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TDSP_GRID(Owner, objDb, objDbLog)
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
    Public Function GET_TDSP_GRID_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    TDSP_GRID")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FDISP_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ID
            strSQL.Append(vbCrLf & "    AND FDISP_ID = :" & UBound(strBindField) - 1 & " --���ID")
        End If
        If IsNull(FCTRL_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCTRL_ID
            strSQL.Append(vbCrLf & "    AND FCTRL_ID = :" & UBound(strBindField) - 1 & " --���۰�ID")
        End If
        If IsNull(FCOL_INDEX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOL_INDEX
            strSQL.Append(vbCrLf & "    AND FCOL_INDEX = :" & UBound(strBindField) - 1 & " --����ޯ��")
        End If
        If IsNull(FGRID_DISPLAYINDEX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_DISPLAYINDEX
            strSQL.Append(vbCrLf & "    AND FGRID_DISPLAYINDEX = :" & UBound(strBindField) - 1 & " --��د�ޗ�\������")
        End If
        If IsNull(FGRID_ORDER_BY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_ORDER_BY
            strSQL.Append(vbCrLf & "    AND FGRID_ORDER_BY = :" & UBound(strBindField) - 1 & " --��د�޵��ް�D�揇")
        End If
        If IsNull(FGRID_ORDER_ASCDESC) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_ORDER_ASCDESC
            strSQL.Append(vbCrLf & "    AND FGRID_ORDER_ASCDESC = :" & UBound(strBindField) - 1 & " --��د�޵��ް�����~��")
        End If
        If IsNull(FGRID_H_TEXT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_H_TEXT
            strSQL.Append(vbCrLf & "    AND FGRID_H_TEXT = :" & UBound(strBindField) - 1 & " --��د��ͯ�ް÷��")
        End If
        If IsNull(FGRID_H_ALIGNMENT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_H_ALIGNMENT
            strSQL.Append(vbCrLf & "    AND FGRID_H_ALIGNMENT = :" & UBound(strBindField) - 1 & " --��د��ͯ�ް�z�u")
        End If
        If IsNull(FGRID_D_ALIGNMENT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_D_ALIGNMENT
            strSQL.Append(vbCrLf & "    AND FGRID_D_ALIGNMENT = :" & UBound(strBindField) - 1 & " --��د���ް��z�u")
        End If
        If IsNull(FGRID_D_FORMAT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_D_FORMAT
            strSQL.Append(vbCrLf & "    AND FGRID_D_FORMAT = :" & UBound(strBindField) - 1 & " --��د���ް�̫�ϯ�")
        End If
        If IsNull(FGRID_D_WIDTH) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_D_WIDTH
            strSQL.Append(vbCrLf & "    AND FGRID_D_WIDTH = :" & UBound(strBindField) - 1 & " --��د���ް���")
        End If
        If IsNull(FGRID_COL_DISP_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_COL_DISP_FLAG
            strSQL.Append(vbCrLf & "    AND FGRID_COL_DISP_FLAG = :" & UBound(strBindField) - 1 & " --��د�ޗ�\���׸�")
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
        strDataSetName = "TDSP_GRID"
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
    Public Sub UPDATE_TDSP_GRID()
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
        strSQL.Append(vbCrLf & "    TDSP_GRID")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
        If IsNull(mFDISP_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDISP_ID = NULL --���ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDISP_ID = NULL --���ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDISP_ID = :" & Ubound(strBindField) - 1 & " --���ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDISP_ID = :" & Ubound(strBindField) - 1 & " --���ID")
        End If
        intCount = intCount + 1
        If IsNull(mFCTRL_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCTRL_ID = NULL --���۰�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCTRL_ID = NULL --���۰�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCTRL_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCTRL_ID = :" & Ubound(strBindField) - 1 & " --���۰�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCTRL_ID = :" & Ubound(strBindField) - 1 & " --���۰�ID")
        End If
        intCount = intCount + 1
        If IsNull(mFCOL_INDEX) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCOL_INDEX = NULL --����ޯ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCOL_INDEX = NULL --����ޯ��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOL_INDEX
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCOL_INDEX = :" & Ubound(strBindField) - 1 & " --����ޯ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCOL_INDEX = :" & Ubound(strBindField) - 1 & " --����ޯ��")
        End If
        intCount = intCount + 1
        If IsNull(mFGRID_DISPLAYINDEX) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FGRID_DISPLAYINDEX = NULL --��د�ޗ�\������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FGRID_DISPLAYINDEX = NULL --��د�ޗ�\������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_DISPLAYINDEX
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FGRID_DISPLAYINDEX = :" & Ubound(strBindField) - 1 & " --��د�ޗ�\������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FGRID_DISPLAYINDEX = :" & Ubound(strBindField) - 1 & " --��د�ޗ�\������")
        End If
        intCount = intCount + 1
        If IsNull(mFGRID_ORDER_BY) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FGRID_ORDER_BY = NULL --��د�޵��ް�D�揇")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FGRID_ORDER_BY = NULL --��د�޵��ް�D�揇")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_ORDER_BY
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FGRID_ORDER_BY = :" & Ubound(strBindField) - 1 & " --��د�޵��ް�D�揇")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FGRID_ORDER_BY = :" & Ubound(strBindField) - 1 & " --��د�޵��ް�D�揇")
        End If
        intCount = intCount + 1
        If IsNull(mFGRID_ORDER_ASCDESC) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FGRID_ORDER_ASCDESC = NULL --��د�޵��ް�����~��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FGRID_ORDER_ASCDESC = NULL --��د�޵��ް�����~��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_ORDER_ASCDESC
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FGRID_ORDER_ASCDESC = :" & Ubound(strBindField) - 1 & " --��د�޵��ް�����~��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FGRID_ORDER_ASCDESC = :" & Ubound(strBindField) - 1 & " --��د�޵��ް�����~��")
        End If
        intCount = intCount + 1
        If IsNull(mFGRID_H_TEXT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FGRID_H_TEXT = NULL --��د��ͯ�ް÷��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FGRID_H_TEXT = NULL --��د��ͯ�ް÷��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_H_TEXT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FGRID_H_TEXT = :" & Ubound(strBindField) - 1 & " --��د��ͯ�ް÷��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FGRID_H_TEXT = :" & Ubound(strBindField) - 1 & " --��د��ͯ�ް÷��")
        End If
        intCount = intCount + 1
        If IsNull(mFGRID_H_ALIGNMENT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FGRID_H_ALIGNMENT = NULL --��د��ͯ�ް�z�u")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FGRID_H_ALIGNMENT = NULL --��د��ͯ�ް�z�u")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_H_ALIGNMENT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FGRID_H_ALIGNMENT = :" & Ubound(strBindField) - 1 & " --��د��ͯ�ް�z�u")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FGRID_H_ALIGNMENT = :" & Ubound(strBindField) - 1 & " --��د��ͯ�ް�z�u")
        End If
        intCount = intCount + 1
        If IsNull(mFGRID_D_ALIGNMENT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FGRID_D_ALIGNMENT = NULL --��د���ް��z�u")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FGRID_D_ALIGNMENT = NULL --��د���ް��z�u")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_D_ALIGNMENT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FGRID_D_ALIGNMENT = :" & Ubound(strBindField) - 1 & " --��د���ް��z�u")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FGRID_D_ALIGNMENT = :" & Ubound(strBindField) - 1 & " --��د���ް��z�u")
        End If
        intCount = intCount + 1
        If IsNull(mFGRID_D_FORMAT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FGRID_D_FORMAT = NULL --��د���ް�̫�ϯ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FGRID_D_FORMAT = NULL --��د���ް�̫�ϯ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_D_FORMAT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FGRID_D_FORMAT = :" & Ubound(strBindField) - 1 & " --��د���ް�̫�ϯ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FGRID_D_FORMAT = :" & Ubound(strBindField) - 1 & " --��د���ް�̫�ϯ�")
        End If
        intCount = intCount + 1
        If IsNull(mFGRID_D_WIDTH) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FGRID_D_WIDTH = NULL --��د���ް���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FGRID_D_WIDTH = NULL --��د���ް���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_D_WIDTH
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FGRID_D_WIDTH = :" & Ubound(strBindField) - 1 & " --��د���ް���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FGRID_D_WIDTH = :" & Ubound(strBindField) - 1 & " --��د���ް���")
        End If
        intCount = intCount + 1
        If IsNull(mFGRID_COL_DISP_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FGRID_COL_DISP_FLAG = NULL --��د�ޗ�\���׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FGRID_COL_DISP_FLAG = NULL --��د�ޗ�\���׸�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_COL_DISP_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FGRID_COL_DISP_FLAG = :" & Ubound(strBindField) - 1 & " --��د�ޗ�\���׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FGRID_COL_DISP_FLAG = :" & Ubound(strBindField) - 1 & " --��د�ޗ�\���׸�")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FDISP_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FDISP_ID IS NULL --���ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ID
            strSQL.Append(vbCrLf & "    AND FDISP_ID = :" & UBound(strBindField) - 1 & " --���ID")
        End If
        If IsNull(FCTRL_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FCTRL_ID IS NULL --���۰�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCTRL_ID
            strSQL.Append(vbCrLf & "    AND FCTRL_ID = :" & UBound(strBindField) - 1 & " --���۰�ID")
        End If
        If IsNull(FCOL_INDEX) = True Then
            strSQL.Append(vbCrLf & "    AND FCOL_INDEX IS NULL --����ޯ��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOL_INDEX
            strSQL.Append(vbCrLf & "    AND FCOL_INDEX = :" & UBound(strBindField) - 1 & " --����ޯ��")
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
    Public Sub ADD_TDSP_GRID()
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
        strSQL.Append(vbCrLf & "    TDSP_GRID")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
        If IsNull(mFDISP_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���ID")
        End If
        intCount = intCount + 1
        If IsNull(mFCTRL_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���۰�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���۰�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCTRL_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���۰�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���۰�ID")
        End If
        intCount = intCount + 1
        If IsNull(mFCOL_INDEX) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����ޯ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����ޯ��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOL_INDEX
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����ޯ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����ޯ��")
        End If
        intCount = intCount + 1
        If IsNull(mFGRID_DISPLAYINDEX) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --��د�ޗ�\������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --��د�ޗ�\������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_DISPLAYINDEX
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --��د�ޗ�\������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --��د�ޗ�\������")
        End If
        intCount = intCount + 1
        If IsNull(mFGRID_ORDER_BY) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --��د�޵��ް�D�揇")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --��د�޵��ް�D�揇")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_ORDER_BY
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --��د�޵��ް�D�揇")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --��د�޵��ް�D�揇")
        End If
        intCount = intCount + 1
        If IsNull(mFGRID_ORDER_ASCDESC) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --��د�޵��ް�����~��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --��د�޵��ް�����~��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_ORDER_ASCDESC
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --��د�޵��ް�����~��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --��د�޵��ް�����~��")
        End If
        intCount = intCount + 1
        If IsNull(mFGRID_H_TEXT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --��د��ͯ�ް÷��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --��د��ͯ�ް÷��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_H_TEXT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --��د��ͯ�ް÷��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --��د��ͯ�ް÷��")
        End If
        intCount = intCount + 1
        If IsNull(mFGRID_H_ALIGNMENT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --��د��ͯ�ް�z�u")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --��د��ͯ�ް�z�u")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_H_ALIGNMENT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --��د��ͯ�ް�z�u")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --��د��ͯ�ް�z�u")
        End If
        intCount = intCount + 1
        If IsNull(mFGRID_D_ALIGNMENT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --��د���ް��z�u")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --��د���ް��z�u")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_D_ALIGNMENT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --��د���ް��z�u")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --��د���ް��z�u")
        End If
        intCount = intCount + 1
        If IsNull(mFGRID_D_FORMAT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --��د���ް�̫�ϯ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --��د���ް�̫�ϯ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_D_FORMAT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --��د���ް�̫�ϯ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --��د���ް�̫�ϯ�")
        End If
        intCount = intCount + 1
        If IsNull(mFGRID_D_WIDTH) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --��د���ް���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --��د���ް���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_D_WIDTH
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --��د���ް���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --��د���ް���")
        End If
        intCount = intCount + 1
        If IsNull(mFGRID_COL_DISP_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --��د�ޗ�\���׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --��د�ޗ�\���׸�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_COL_DISP_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --��د�ޗ�\���׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --��د�ޗ�\���׸�")
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
    Public Sub DELETE_TDSP_GRID()
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
        ElseIf IsNull(mFDISP_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[���ID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFCTRL_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[���۰�ID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFCOL_INDEX) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[����ޯ��]"
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
        strSQL.Append(vbCrLf & "    TDSP_GRID")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FDISP_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FDISP_ID IS NULL --���ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ID
            strSQL.Append(vbCrLf & "    AND FDISP_ID = :" & UBound(strBindField) - 1 & " --���ID")
        End If
        If IsNull(FCTRL_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FCTRL_ID IS NULL --���۰�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCTRL_ID
            strSQL.Append(vbCrLf & "    AND FCTRL_ID = :" & UBound(strBindField) - 1 & " --���۰�ID")
        End If
        If IsNull(FCOL_INDEX) = True Then
            strSQL.Append(vbCrLf & "    AND FCOL_INDEX IS NULL --����ޯ��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOL_INDEX
            strSQL.Append(vbCrLf & "    AND FCOL_INDEX = :" & UBound(strBindField) - 1 & " --����ޯ��")
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
    Public Sub DELETE_TDSP_GRID_ANY()
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
        strSQL.Append(vbCrLf & "    TDSP_GRID")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(FDISP_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ID
            strSQL.Append(vbCrLf & "    AND FDISP_ID = :" & UBound(strBindField) - 1 & " --���ID")
        End If
        If IsNotNull(FCTRL_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCTRL_ID
            strSQL.Append(vbCrLf & "    AND FCTRL_ID = :" & UBound(strBindField) - 1 & " --���۰�ID")
        End If
        If IsNotNull(FCOL_INDEX) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOL_INDEX
            strSQL.Append(vbCrLf & "    AND FCOL_INDEX = :" & UBound(strBindField) - 1 & " --����ޯ��")
        End If
        If IsNotNull(FGRID_DISPLAYINDEX) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_DISPLAYINDEX
            strSQL.Append(vbCrLf & "    AND FGRID_DISPLAYINDEX = :" & UBound(strBindField) - 1 & " --��د�ޗ�\������")
        End If
        If IsNotNull(FGRID_ORDER_BY) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_ORDER_BY
            strSQL.Append(vbCrLf & "    AND FGRID_ORDER_BY = :" & UBound(strBindField) - 1 & " --��د�޵��ް�D�揇")
        End If
        If IsNotNull(FGRID_ORDER_ASCDESC) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_ORDER_ASCDESC
            strSQL.Append(vbCrLf & "    AND FGRID_ORDER_ASCDESC = :" & UBound(strBindField) - 1 & " --��د�޵��ް�����~��")
        End If
        If IsNotNull(FGRID_H_TEXT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_H_TEXT
            strSQL.Append(vbCrLf & "    AND FGRID_H_TEXT = :" & UBound(strBindField) - 1 & " --��د��ͯ�ް÷��")
        End If
        If IsNotNull(FGRID_H_ALIGNMENT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_H_ALIGNMENT
            strSQL.Append(vbCrLf & "    AND FGRID_H_ALIGNMENT = :" & UBound(strBindField) - 1 & " --��د��ͯ�ް�z�u")
        End If
        If IsNotNull(FGRID_D_ALIGNMENT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_D_ALIGNMENT
            strSQL.Append(vbCrLf & "    AND FGRID_D_ALIGNMENT = :" & UBound(strBindField) - 1 & " --��د���ް��z�u")
        End If
        If IsNotNull(FGRID_D_FORMAT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_D_FORMAT
            strSQL.Append(vbCrLf & "    AND FGRID_D_FORMAT = :" & UBound(strBindField) - 1 & " --��د���ް�̫�ϯ�")
        End If
        If IsNotNull(FGRID_D_WIDTH) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_D_WIDTH
            strSQL.Append(vbCrLf & "    AND FGRID_D_WIDTH = :" & UBound(strBindField) - 1 & " --��د���ް���")
        End If
        If IsNotNull(FGRID_COL_DISP_FLAG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_COL_DISP_FLAG
            strSQL.Append(vbCrLf & "    AND FGRID_COL_DISP_FLAG = :" & UBound(strBindField) - 1 & " --��د�ޗ�\���׸�")
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
        If IsNothing(objType.GetProperty("FDISP_ID")) = False Then mFDISP_ID = objObject.FDISP_ID '���ID
        If IsNothing(objType.GetProperty("FCTRL_ID")) = False Then mFCTRL_ID = objObject.FCTRL_ID '���۰�ID
        If IsNothing(objType.GetProperty("FCOL_INDEX")) = False Then mFCOL_INDEX = objObject.FCOL_INDEX '����ޯ��
        If IsNothing(objType.GetProperty("FGRID_DISPLAYINDEX")) = False Then mFGRID_DISPLAYINDEX = objObject.FGRID_DISPLAYINDEX '��د�ޗ�\������
        If IsNothing(objType.GetProperty("FGRID_ORDER_BY")) = False Then mFGRID_ORDER_BY = objObject.FGRID_ORDER_BY '��د�޵��ް�D�揇
        If IsNothing(objType.GetProperty("FGRID_ORDER_ASCDESC")) = False Then mFGRID_ORDER_ASCDESC = objObject.FGRID_ORDER_ASCDESC '��د�޵��ް�����~��
        If IsNothing(objType.GetProperty("FGRID_H_TEXT")) = False Then mFGRID_H_TEXT = objObject.FGRID_H_TEXT '��د��ͯ�ް÷��
        If IsNothing(objType.GetProperty("FGRID_H_ALIGNMENT")) = False Then mFGRID_H_ALIGNMENT = objObject.FGRID_H_ALIGNMENT '��د��ͯ�ް�z�u
        If IsNothing(objType.GetProperty("FGRID_D_ALIGNMENT")) = False Then mFGRID_D_ALIGNMENT = objObject.FGRID_D_ALIGNMENT '��د���ް��z�u
        If IsNothing(objType.GetProperty("FGRID_D_FORMAT")) = False Then mFGRID_D_FORMAT = objObject.FGRID_D_FORMAT '��د���ް�̫�ϯ�
        If IsNothing(objType.GetProperty("FGRID_D_WIDTH")) = False Then mFGRID_D_WIDTH = objObject.FGRID_D_WIDTH '��د���ް���
        If IsNothing(objType.GetProperty("FGRID_COL_DISP_FLAG")) = False Then mFGRID_COL_DISP_FLAG = objObject.FGRID_COL_DISP_FLAG '��د�ޗ�\���׸�

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
        mFDISP_ID = Nothing
        mFCTRL_ID = Nothing
        mFCOL_INDEX = Nothing
        mFGRID_DISPLAYINDEX = Nothing
        mFGRID_ORDER_BY = Nothing
        mFGRID_ORDER_ASCDESC = Nothing
        mFGRID_H_TEXT = Nothing
        mFGRID_H_ALIGNMENT = Nothing
        mFGRID_D_ALIGNMENT = Nothing
        mFGRID_D_FORMAT = Nothing
        mFGRID_D_WIDTH = Nothing
        mFGRID_COL_DISP_FLAG = Nothing


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
        mFDISP_ID = TO_STRING_NULLABLE(objRow("FDISP_ID"))
        mFCTRL_ID = TO_STRING_NULLABLE(objRow("FCTRL_ID"))
        mFCOL_INDEX = TO_INTEGER_NULLABLE(objRow("FCOL_INDEX"))
        mFGRID_DISPLAYINDEX = TO_INTEGER_NULLABLE(objRow("FGRID_DISPLAYINDEX"))
        mFGRID_ORDER_BY = TO_INTEGER_NULLABLE(objRow("FGRID_ORDER_BY"))
        mFGRID_ORDER_ASCDESC = TO_STRING_NULLABLE(objRow("FGRID_ORDER_ASCDESC"))
        mFGRID_H_TEXT = TO_STRING_NULLABLE(objRow("FGRID_H_TEXT"))
        mFGRID_H_ALIGNMENT = TO_STRING_NULLABLE(objRow("FGRID_H_ALIGNMENT"))
        mFGRID_D_ALIGNMENT = TO_STRING_NULLABLE(objRow("FGRID_D_ALIGNMENT"))
        mFGRID_D_FORMAT = TO_STRING_NULLABLE(objRow("FGRID_D_FORMAT"))
        mFGRID_D_WIDTH = TO_STRING_NULLABLE(objRow("FGRID_D_WIDTH"))
        mFGRID_COL_DISP_FLAG = TO_INTEGER_NULLABLE(objRow("FGRID_COL_DISP_FLAG"))


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
        strMsg &= "[ð��ٖ�:��د��Ͻ�]"
        If IsNotNull(FDISP_ID) Then
            strMsg &= "[���ID:" & FDISP_ID & "]"
        End If
        If IsNotNull(FCTRL_ID) Then
            strMsg &= "[���۰�ID:" & FCTRL_ID & "]"
        End If
        If IsNotNull(FCOL_INDEX) Then
            strMsg &= "[����ޯ��:" & FCOL_INDEX & "]"
        End If
        If IsNotNull(FGRID_DISPLAYINDEX) Then
            strMsg &= "[��د�ޗ�\������:" & FGRID_DISPLAYINDEX & "]"
        End If
        If IsNotNull(FGRID_ORDER_BY) Then
            strMsg &= "[��د�޵��ް�D�揇:" & FGRID_ORDER_BY & "]"
        End If
        If IsNotNull(FGRID_ORDER_ASCDESC) Then
            strMsg &= "[��د�޵��ް�����~��:" & FGRID_ORDER_ASCDESC & "]"
        End If
        If IsNotNull(FGRID_H_TEXT) Then
            strMsg &= "[��د��ͯ�ް÷��:" & FGRID_H_TEXT & "]"
        End If
        If IsNotNull(FGRID_H_ALIGNMENT) Then
            strMsg &= "[��د��ͯ�ް�z�u:" & FGRID_H_ALIGNMENT & "]"
        End If
        If IsNotNull(FGRID_D_ALIGNMENT) Then
            strMsg &= "[��د���ް��z�u:" & FGRID_D_ALIGNMENT & "]"
        End If
        If IsNotNull(FGRID_D_FORMAT) Then
            strMsg &= "[��د���ް�̫�ϯ�:" & FGRID_D_FORMAT & "]"
        End If
        If IsNotNull(FGRID_D_WIDTH) Then
            strMsg &= "[��د���ް���:" & FGRID_D_WIDTH & "]"
        End If
        If IsNotNull(FGRID_COL_DISP_FLAG) Then
            strMsg &= "[��د�ޗ�\���׸�:" & FGRID_COL_DISP_FLAG & "]"
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
