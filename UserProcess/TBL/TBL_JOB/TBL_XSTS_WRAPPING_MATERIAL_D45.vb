'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' �y���́zMaterialStreamð��ٸ׽
' �y�@�\�z��ޏo�ɐݒ���(D45)ð��ٸ׽
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
''' ��ޏo�ɐݒ���(D45)ð��ٸ׽
''' </summary>
Public Class TBL_XSTS_WRAPPING_MATERIAL_D45
    Inherits clsTemplateTable

    '**********************************************************************************************
    '����������������
#Region "  �׽�ϐ���`                  "
    '�����è
    Private mobjAryMe As TBL_XSTS_WRAPPING_MATERIAL_D45()                        '��ޏo�ɐݒ���(D45)
    Private mstrUSER_SQL As String                                               'հ�ްSQL
    Private mORDER_BY As String                                                  'OrderBy��
    Private mWHERE As String                                                     'Where��
    Private mXPROD_LINE As String                                                '���Yײ݇�
    Private mFTRK_BUF_NO As Nullable(Of Integer)                                 '�ׯ�ݸ��ޯ̧��
    Private mFEQ_ID As String                                                    '�ݔ�ID
    Private mFHINMEI_CD As String                                                '�i�ں���
    Private mXMAKER_CD As String                                                 'Ұ�-����
    Private mXSTART_DT As Nullable(Of Date)                                      '�J�n����
    Private mXEND_DT As Nullable(Of Date)                                        '�I������
    Private mXPLAN_NUM As Nullable(Of Decimal)                                   '�v�搔��
    Private mXRESULT_NUM As Nullable(Of Decimal)                                 '���ѐ���
    Private mXRESULT_NUM_SUM As Nullable(Of Decimal)                             '���ѐ���(���v)
    Private mXPROGRESS As Nullable(Of Integer)                                   '�i�����
    Private mFGRID_DISPLAYINDEX As Nullable(Of Integer)                          '��د�ޗ�\������
    Private mFPLAN_KEY As String                                                 '�v�淰
#End Region
#Region "  �����è��`                  "
    ''' <summary>
    ''' ���ѕϐ� (���׽�^�z��)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_XSTS_WRAPPING_MATERIAL_D45()
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
    ''' ���Yײ݇�
    ''' </summary>
    Public Property XPROD_LINE() As String
        Get
            Return mXPROD_LINE
        End Get
        Set(ByVal Value As String)
            mXPROD_LINE = Value
        End Set
    End Property
    ''' <summary>
    ''' �ׯ�ݸ��ޯ̧��
    ''' </summary>
    Public Property FTRK_BUF_NO() As Nullable(Of Integer)
        Get
            Return mFTRK_BUF_NO
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFTRK_BUF_NO = Value
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
    ''' Ұ�-����
    ''' </summary>
    Public Property XMAKER_CD() As String
        Get
            Return mXMAKER_CD
        End Get
        Set(ByVal Value As String)
            mXMAKER_CD = Value
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
    ''' <summary>
    ''' �v�搔��
    ''' </summary>
    Public Property XPLAN_NUM() As Nullable(Of Decimal)
        Get
            Return mXPLAN_NUM
        End Get
        Set(ByVal Value As Nullable(Of Decimal))
            mXPLAN_NUM = Value
        End Set
    End Property
    ''' <summary>
    ''' ���ѐ���
    ''' </summary>
    Public Property XRESULT_NUM() As Nullable(Of Decimal)
        Get
            Return mXRESULT_NUM
        End Get
        Set(ByVal Value As Nullable(Of Decimal))
            mXRESULT_NUM = Value
        End Set
    End Property
    ''' <summary>
    ''' ���ѐ���(���v)
    ''' </summary>
    Public Property XRESULT_NUM_SUM() As Nullable(Of Decimal)
        Get
            Return mXRESULT_NUM_SUM
        End Get
        Set(ByVal Value As Nullable(Of Decimal))
            mXRESULT_NUM_SUM = Value
        End Set
    End Property
    ''' <summary>
    ''' �i�����
    ''' </summary>
    Public Property XPROGRESS() As Nullable(Of Integer)
        Get
            Return mXPROGRESS
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXPROGRESS = Value
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
    ''' �v�淰
    ''' </summary>
    Public Property FPLAN_KEY() As String
        Get
            Return mFPLAN_KEY
        End Get
        Set(ByVal Value As String)
            mFPLAN_KEY = Value
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
    Public Function GET_XSTS_WRAPPING_MATERIAL_D45(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    XSTS_WRAPPING_MATERIAL_D45")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XPROD_LINE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPROD_LINE
            strSQL.Append(vbCrLf & "    AND XPROD_LINE = :" & UBound(strBindField) - 1 & " --���Yײ݇�")
        End If
        If IsNull(FTRK_BUF_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FEQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --�ݔ�ID")
        End If
        If IsNull(FHINMEI_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --�i�ں���")
        End If
        If IsNull(XMAKER_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAKER_CD
            strSQL.Append(vbCrLf & "    AND XMAKER_CD = :" & UBound(strBindField) - 1 & " --Ұ�-����")
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
        If IsNull(XPLAN_NUM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPLAN_NUM
            strSQL.Append(vbCrLf & "    AND XPLAN_NUM = :" & UBound(strBindField) - 1 & " --�v�搔��")
        End If
        If IsNull(XRESULT_NUM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXRESULT_NUM
            strSQL.Append(vbCrLf & "    AND XRESULT_NUM = :" & UBound(strBindField) - 1 & " --���ѐ���")
        End If
        If IsNull(XRESULT_NUM_SUM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXRESULT_NUM_SUM
            strSQL.Append(vbCrLf & "    AND XRESULT_NUM_SUM = :" & UBound(strBindField) - 1 & " --���ѐ���(���v)")
        End If
        If IsNull(XPROGRESS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPROGRESS
            strSQL.Append(vbCrLf & "    AND XPROGRESS = :" & UBound(strBindField) - 1 & " --�i�����")
        End If
        If IsNull(FGRID_DISPLAYINDEX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_DISPLAYINDEX
            strSQL.Append(vbCrLf & "    AND FGRID_DISPLAYINDEX = :" & UBound(strBindField) - 1 & " --��د�ޗ�\������")
        End If
        If IsNull(FPLAN_KEY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLAN_KEY
            strSQL.Append(vbCrLf & "    AND FPLAN_KEY = :" & UBound(strBindField) - 1 & " --�v�淰")
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
        strDataSetName = "XSTS_WRAPPING_MATERIAL_D45"
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
    Public Function GET_XSTS_WRAPPING_MATERIAL_D45_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    XSTS_WRAPPING_MATERIAL_D45")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XPROD_LINE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPROD_LINE
            strSQL.Append(vbCrLf & "    AND XPROD_LINE = :" & UBound(strBindField) - 1 & " --���Yײ݇�")
        End If
        If IsNull(FTRK_BUF_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FEQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --�ݔ�ID")
        End If
        If IsNull(FHINMEI_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --�i�ں���")
        End If
        If IsNull(XMAKER_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAKER_CD
            strSQL.Append(vbCrLf & "    AND XMAKER_CD = :" & UBound(strBindField) - 1 & " --Ұ�-����")
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
        If IsNull(XPLAN_NUM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPLAN_NUM
            strSQL.Append(vbCrLf & "    AND XPLAN_NUM = :" & UBound(strBindField) - 1 & " --�v�搔��")
        End If
        If IsNull(XRESULT_NUM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXRESULT_NUM
            strSQL.Append(vbCrLf & "    AND XRESULT_NUM = :" & UBound(strBindField) - 1 & " --���ѐ���")
        End If
        If IsNull(XRESULT_NUM_SUM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXRESULT_NUM_SUM
            strSQL.Append(vbCrLf & "    AND XRESULT_NUM_SUM = :" & UBound(strBindField) - 1 & " --���ѐ���(���v)")
        End If
        If IsNull(XPROGRESS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPROGRESS
            strSQL.Append(vbCrLf & "    AND XPROGRESS = :" & UBound(strBindField) - 1 & " --�i�����")
        End If
        If IsNull(FGRID_DISPLAYINDEX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_DISPLAYINDEX
            strSQL.Append(vbCrLf & "    AND FGRID_DISPLAYINDEX = :" & UBound(strBindField) - 1 & " --��د�ޗ�\������")
        End If
        If IsNull(FPLAN_KEY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLAN_KEY
            strSQL.Append(vbCrLf & "    AND FPLAN_KEY = :" & UBound(strBindField) - 1 & " --�v�淰")
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
        strDataSetName = "XSTS_WRAPPING_MATERIAL_D45"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XSTS_WRAPPING_MATERIAL_D45(Owner, objDb, objDbLog)
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
    Public Function GET_XSTS_WRAPPING_MATERIAL_D45_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "XSTS_WRAPPING_MATERIAL_D45"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XSTS_WRAPPING_MATERIAL_D45(Owner, objDb, objDbLog)
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
    Public Function GET_XSTS_WRAPPING_MATERIAL_D45_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    XSTS_WRAPPING_MATERIAL_D45")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XPROD_LINE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPROD_LINE
            strSQL.Append(vbCrLf & "    AND XPROD_LINE = :" & UBound(strBindField) - 1 & " --���Yײ݇�")
        End If
        If IsNull(FTRK_BUF_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FEQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --�ݔ�ID")
        End If
        If IsNull(FHINMEI_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --�i�ں���")
        End If
        If IsNull(XMAKER_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAKER_CD
            strSQL.Append(vbCrLf & "    AND XMAKER_CD = :" & UBound(strBindField) - 1 & " --Ұ�-����")
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
        If IsNull(XPLAN_NUM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPLAN_NUM
            strSQL.Append(vbCrLf & "    AND XPLAN_NUM = :" & UBound(strBindField) - 1 & " --�v�搔��")
        End If
        If IsNull(XRESULT_NUM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXRESULT_NUM
            strSQL.Append(vbCrLf & "    AND XRESULT_NUM = :" & UBound(strBindField) - 1 & " --���ѐ���")
        End If
        If IsNull(XRESULT_NUM_SUM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXRESULT_NUM_SUM
            strSQL.Append(vbCrLf & "    AND XRESULT_NUM_SUM = :" & UBound(strBindField) - 1 & " --���ѐ���(���v)")
        End If
        If IsNull(XPROGRESS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPROGRESS
            strSQL.Append(vbCrLf & "    AND XPROGRESS = :" & UBound(strBindField) - 1 & " --�i�����")
        End If
        If IsNull(FGRID_DISPLAYINDEX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_DISPLAYINDEX
            strSQL.Append(vbCrLf & "    AND FGRID_DISPLAYINDEX = :" & UBound(strBindField) - 1 & " --��د�ޗ�\������")
        End If
        If IsNull(FPLAN_KEY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLAN_KEY
            strSQL.Append(vbCrLf & "    AND FPLAN_KEY = :" & UBound(strBindField) - 1 & " --�v�淰")
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
        strDataSetName = "XSTS_WRAPPING_MATERIAL_D45"
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
    Public Sub UPDATE_XSTS_WRAPPING_MATERIAL_D45()
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
        ElseIf IsNull(mXPROD_LINE) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[���Yײ݇�]"
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
        strSQL.Append(vbCrLf & "    XSTS_WRAPPING_MATERIAL_D45")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
        If IsNull(mXPROD_LINE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XPROD_LINE = NULL --���Yײ݇�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XPROD_LINE = NULL --���Yײ݇�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPROD_LINE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XPROD_LINE = :" & Ubound(strBindField) - 1 & " --���Yײ݇�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XPROD_LINE = :" & Ubound(strBindField) - 1 & " --���Yײ݇�")
        End If
        intCount = intCount + 1
        If IsNull(mFTRK_BUF_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTRK_BUF_NO = NULL --�ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTRK_BUF_NO = NULL --�ׯ�ݸ��ޯ̧��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTRK_BUF_NO = :" & Ubound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTRK_BUF_NO = :" & Ubound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧��")
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
        If IsNull(mXMAKER_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XMAKER_CD = NULL --Ұ�-����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XMAKER_CD = NULL --Ұ�-����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAKER_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XMAKER_CD = :" & Ubound(strBindField) - 1 & " --Ұ�-����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XMAKER_CD = :" & Ubound(strBindField) - 1 & " --Ұ�-����")
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
        If IsNull(mXPLAN_NUM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XPLAN_NUM = NULL --�v�搔��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XPLAN_NUM = NULL --�v�搔��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPLAN_NUM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XPLAN_NUM = :" & Ubound(strBindField) - 1 & " --�v�搔��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XPLAN_NUM = :" & Ubound(strBindField) - 1 & " --�v�搔��")
        End If
        intCount = intCount + 1
        If IsNull(mXRESULT_NUM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XRESULT_NUM = NULL --���ѐ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XRESULT_NUM = NULL --���ѐ���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXRESULT_NUM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XRESULT_NUM = :" & Ubound(strBindField) - 1 & " --���ѐ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XRESULT_NUM = :" & Ubound(strBindField) - 1 & " --���ѐ���")
        End If
        intCount = intCount + 1
        If IsNull(mXRESULT_NUM_SUM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XRESULT_NUM_SUM = NULL --���ѐ���(���v)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XRESULT_NUM_SUM = NULL --���ѐ���(���v)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXRESULT_NUM_SUM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XRESULT_NUM_SUM = :" & Ubound(strBindField) - 1 & " --���ѐ���(���v)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XRESULT_NUM_SUM = :" & Ubound(strBindField) - 1 & " --���ѐ���(���v)")
        End If
        intCount = intCount + 1
        If IsNull(mXPROGRESS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XPROGRESS = NULL --�i�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XPROGRESS = NULL --�i�����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPROGRESS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XPROGRESS = :" & Ubound(strBindField) - 1 & " --�i�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XPROGRESS = :" & Ubound(strBindField) - 1 & " --�i�����")
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
        If IsNull(mFPLAN_KEY) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FPLAN_KEY = NULL --�v�淰")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FPLAN_KEY = NULL --�v�淰")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLAN_KEY
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FPLAN_KEY = :" & Ubound(strBindField) - 1 & " --�v�淰")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FPLAN_KEY = :" & Ubound(strBindField) - 1 & " --�v�淰")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(XPROD_LINE) = True Then
            strSQL.Append(vbCrLf & "    AND XPROD_LINE IS NULL --���Yײ݇�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPROD_LINE
            strSQL.Append(vbCrLf & "    AND XPROD_LINE = :" & UBound(strBindField) - 1 & " --���Yײ݇�")
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
    Public Sub ADD_XSTS_WRAPPING_MATERIAL_D45()
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
        ElseIf IsNull(mXPROD_LINE) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[���Yײ݇�]"
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
        strSQL.Append(vbCrLf & "    XSTS_WRAPPING_MATERIAL_D45")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
        If IsNull(mXPROD_LINE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���Yײ݇�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���Yײ݇�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPROD_LINE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���Yײ݇�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���Yײ݇�")
        End If
        intCount = intCount + 1
        If IsNull(mFTRK_BUF_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ׯ�ݸ��ޯ̧��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧��")
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
        If IsNull(mXMAKER_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --Ұ�-����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --Ұ�-����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAKER_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --Ұ�-����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --Ұ�-����")
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
        If IsNull(mXPLAN_NUM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�v�搔��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�v�搔��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPLAN_NUM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�v�搔��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�v�搔��")
        End If
        intCount = intCount + 1
        If IsNull(mXRESULT_NUM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���ѐ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���ѐ���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXRESULT_NUM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���ѐ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���ѐ���")
        End If
        intCount = intCount + 1
        If IsNull(mXRESULT_NUM_SUM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���ѐ���(���v)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���ѐ���(���v)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXRESULT_NUM_SUM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���ѐ���(���v)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���ѐ���(���v)")
        End If
        intCount = intCount + 1
        If IsNull(mXPROGRESS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�i�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�i�����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPROGRESS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�i�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�i�����")
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
        If IsNull(mFPLAN_KEY) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�v�淰")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�v�淰")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLAN_KEY
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�v�淰")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�v�淰")
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
    Public Sub DELETE_XSTS_WRAPPING_MATERIAL_D45()
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
        ElseIf IsNull(mXPROD_LINE) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[���Yײ݇�]"
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
        strSQL.Append(vbCrLf & "    XSTS_WRAPPING_MATERIAL_D45")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(XPROD_LINE) = True Then
            strSQL.Append(vbCrLf & "    AND XPROD_LINE IS NULL --���Yײ݇�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPROD_LINE
            strSQL.Append(vbCrLf & "    AND XPROD_LINE = :" & UBound(strBindField) - 1 & " --���Yײ݇�")
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
    Public Sub DELETE_XSTS_WRAPPING_MATERIAL_D45_ANY()
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
        strSQL.Append(vbCrLf & "    XSTS_WRAPPING_MATERIAL_D45")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(XPROD_LINE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPROD_LINE
            strSQL.Append(vbCrLf & "    AND XPROD_LINE = :" & UBound(strBindField) - 1 & " --���Yײ݇�")
        End If
        If IsNotNull(FTRK_BUF_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧��")
        End If
        If IsNotNull(FEQ_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --�ݔ�ID")
        End If
        If IsNotNull(FHINMEI_CD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --�i�ں���")
        End If
        If IsNotNull(XMAKER_CD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAKER_CD
            strSQL.Append(vbCrLf & "    AND XMAKER_CD = :" & UBound(strBindField) - 1 & " --Ұ�-����")
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
        If IsNotNull(XPLAN_NUM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPLAN_NUM
            strSQL.Append(vbCrLf & "    AND XPLAN_NUM = :" & UBound(strBindField) - 1 & " --�v�搔��")
        End If
        If IsNotNull(XRESULT_NUM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXRESULT_NUM
            strSQL.Append(vbCrLf & "    AND XRESULT_NUM = :" & UBound(strBindField) - 1 & " --���ѐ���")
        End If
        If IsNotNull(XRESULT_NUM_SUM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXRESULT_NUM_SUM
            strSQL.Append(vbCrLf & "    AND XRESULT_NUM_SUM = :" & UBound(strBindField) - 1 & " --���ѐ���(���v)")
        End If
        If IsNotNull(XPROGRESS) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPROGRESS
            strSQL.Append(vbCrLf & "    AND XPROGRESS = :" & UBound(strBindField) - 1 & " --�i�����")
        End If
        If IsNotNull(FGRID_DISPLAYINDEX) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_DISPLAYINDEX
            strSQL.Append(vbCrLf & "    AND FGRID_DISPLAYINDEX = :" & UBound(strBindField) - 1 & " --��د�ޗ�\������")
        End If
        If IsNotNull(FPLAN_KEY) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLAN_KEY
            strSQL.Append(vbCrLf & "    AND FPLAN_KEY = :" & UBound(strBindField) - 1 & " --�v�淰")
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
        If IsNothing(objType.GetProperty("XPROD_LINE")) = False Then mXPROD_LINE = objObject.XPROD_LINE '���Yײ݇�
        If IsNothing(objType.GetProperty("FTRK_BUF_NO")) = False Then mFTRK_BUF_NO = objObject.FTRK_BUF_NO '�ׯ�ݸ��ޯ̧��
        If IsNothing(objType.GetProperty("FEQ_ID")) = False Then mFEQ_ID = objObject.FEQ_ID '�ݔ�ID
        If IsNothing(objType.GetProperty("FHINMEI_CD")) = False Then mFHINMEI_CD = objObject.FHINMEI_CD '�i�ں���
        If IsNothing(objType.GetProperty("XMAKER_CD")) = False Then mXMAKER_CD = objObject.XMAKER_CD 'Ұ�-����
        If IsNothing(objType.GetProperty("XSTART_DT")) = False Then mXSTART_DT = objObject.XSTART_DT '�J�n����
        If IsNothing(objType.GetProperty("XEND_DT")) = False Then mXEND_DT = objObject.XEND_DT '�I������
        If IsNothing(objType.GetProperty("XPLAN_NUM")) = False Then mXPLAN_NUM = objObject.XPLAN_NUM '�v�搔��
        If IsNothing(objType.GetProperty("XRESULT_NUM")) = False Then mXRESULT_NUM = objObject.XRESULT_NUM '���ѐ���
        If IsNothing(objType.GetProperty("XRESULT_NUM_SUM")) = False Then mXRESULT_NUM_SUM = objObject.XRESULT_NUM_SUM '���ѐ���(���v)
        If IsNothing(objType.GetProperty("XPROGRESS")) = False Then mXPROGRESS = objObject.XPROGRESS '�i�����
        If IsNothing(objType.GetProperty("FGRID_DISPLAYINDEX")) = False Then mFGRID_DISPLAYINDEX = objObject.FGRID_DISPLAYINDEX '��د�ޗ�\������
        If IsNothing(objType.GetProperty("FPLAN_KEY")) = False Then mFPLAN_KEY = objObject.FPLAN_KEY '�v�淰

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
        mXPROD_LINE = Nothing
        mFTRK_BUF_NO = Nothing
        mFEQ_ID = Nothing
        mFHINMEI_CD = Nothing
        mXMAKER_CD = Nothing
        mXSTART_DT = Nothing
        mXEND_DT = Nothing
        mXPLAN_NUM = Nothing
        mXRESULT_NUM = Nothing
        mXRESULT_NUM_SUM = Nothing
        mXPROGRESS = Nothing
        mFGRID_DISPLAYINDEX = Nothing
        mFPLAN_KEY = Nothing


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
        mXPROD_LINE = TO_STRING_NULLABLE(objRow("XPROD_LINE"))
        mFTRK_BUF_NO = TO_INTEGER_NULLABLE(objRow("FTRK_BUF_NO"))
        mFEQ_ID = TO_STRING_NULLABLE(objRow("FEQ_ID"))
        mFHINMEI_CD = TO_STRING_NULLABLE(objRow("FHINMEI_CD"))
        mXMAKER_CD = TO_STRING_NULLABLE(objRow("XMAKER_CD"))
        mXSTART_DT = TO_DATE_NULLABLE(objRow("XSTART_DT"))
        mXEND_DT = TO_DATE_NULLABLE(objRow("XEND_DT"))
        mXPLAN_NUM = TO_DECIMAL_NULLABLE(objRow("XPLAN_NUM"))
        mXRESULT_NUM = TO_DECIMAL_NULLABLE(objRow("XRESULT_NUM"))
        mXRESULT_NUM_SUM = TO_DECIMAL_NULLABLE(objRow("XRESULT_NUM_SUM"))
        mXPROGRESS = TO_INTEGER_NULLABLE(objRow("XPROGRESS"))
        mFGRID_DISPLAYINDEX = TO_INTEGER_NULLABLE(objRow("FGRID_DISPLAYINDEX"))
        mFPLAN_KEY = TO_STRING_NULLABLE(objRow("FPLAN_KEY"))


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
        strMsg &= "[ð��ٖ�:��ޏo�ɐݒ���(D45)]"
        If IsNotNull(XPROD_LINE) Then
            strMsg &= "[���Yײ݇�:" & XPROD_LINE & "]"
        End If
        If IsNotNull(FTRK_BUF_NO) Then
            strMsg &= "[�ׯ�ݸ��ޯ̧��:" & FTRK_BUF_NO & "]"
        End If
        If IsNotNull(FEQ_ID) Then
            strMsg &= "[�ݔ�ID:" & FEQ_ID & "]"
        End If
        If IsNotNull(FHINMEI_CD) Then
            strMsg &= "[�i�ں���:" & FHINMEI_CD & "]"
        End If
        If IsNotNull(XMAKER_CD) Then
            strMsg &= "[Ұ�-����:" & XMAKER_CD & "]"
        End If
        If IsNotNull(XSTART_DT) Then
            strMsg &= "[�J�n����:" & XSTART_DT & "]"
        End If
        If IsNotNull(XEND_DT) Then
            strMsg &= "[�I������:" & XEND_DT & "]"
        End If
        If IsNotNull(XPLAN_NUM) Then
            strMsg &= "[�v�搔��:" & XPLAN_NUM & "]"
        End If
        If IsNotNull(XRESULT_NUM) Then
            strMsg &= "[���ѐ���:" & XRESULT_NUM & "]"
        End If
        If IsNotNull(XRESULT_NUM_SUM) Then
            strMsg &= "[���ѐ���(���v):" & XRESULT_NUM_SUM & "]"
        End If
        If IsNotNull(XPROGRESS) Then
            strMsg &= "[�i�����:" & XPROGRESS & "]"
        End If
        If IsNotNull(FGRID_DISPLAYINDEX) Then
            strMsg &= "[��د�ޗ�\������:" & FGRID_DISPLAYINDEX & "]"
        End If
        If IsNotNull(FPLAN_KEY) Then
            strMsg &= "[�v�淰:" & FPLAN_KEY & "]"
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
