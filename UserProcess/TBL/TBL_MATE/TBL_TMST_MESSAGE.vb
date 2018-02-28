'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' �y���́zMaterialStreamð��ٸ׽
' �y�@�\�zү����Ͻ�ð��ٸ׽
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
''' ү����Ͻ�ð��ٸ׽
''' </summary>
Public Class TBL_TMST_MESSAGE
    Inherits clsTemplateTable

    '**********************************************************************************************
    '����������������
#Region "  �׽�ϐ���`                  "
    '�����è
    Private mobjAryMe As TBL_TMST_MESSAGE()                                      'ү����Ͻ�
    Private mstrUSER_SQL As String                                               'հ�ްSQL
    Private mORDER_BY As String                                                  'OrderBy��
    Private mWHERE As String                                                     'Where��
    Private mFMSG_ID As String                                                   'ү����ID
    Private mFMSG_NAIYOU As String                                               'ү���ޓ��e
    Private mFMSG_KUBUN As Nullable(Of Integer)                                  'ү���ދ敪
    Private mFMSG_LEVEL As Nullable(Of Integer)                                  'ү��������
    Private mFMSG_TYPE As Nullable(Of Integer)                                   'ү�����ޯ������
    Private mFMSG_BTN As Nullable(Of Integer)                                    'ү�����ޯ������
    Private mFMSG_TITLE As Nullable(Of Integer)                                  'ү�����ޯ������
    Private mFMSG_DSP As Nullable(Of Integer)                                    'ү�����ޯ���\��
    Private mFLOG_FLAG As Nullable(Of Integer)                                   '۸ޏ����׸�
#End Region
#Region "  �����è��`                  "
    ''' <summary>
    ''' ���ѕϐ� (���׽�^�z��)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_TMST_MESSAGE()
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
    ''' ү����ID
    ''' </summary>
    Public Property FMSG_ID() As String
        Get
            Return mFMSG_ID
        End Get
        Set(ByVal Value As String)
            mFMSG_ID = Value
        End Set
    End Property
    ''' <summary>
    ''' ү���ޓ��e
    ''' </summary>
    Public Property FMSG_NAIYOU() As String
        Get
            Return mFMSG_NAIYOU
        End Get
        Set(ByVal Value As String)
            mFMSG_NAIYOU = Value
        End Set
    End Property
    ''' <summary>
    ''' ү���ދ敪
    ''' </summary>
    Public Property FMSG_KUBUN() As Nullable(Of Integer)
        Get
            Return mFMSG_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFMSG_KUBUN = Value
        End Set
    End Property
    ''' <summary>
    ''' ү��������
    ''' </summary>
    Public Property FMSG_LEVEL() As Nullable(Of Integer)
        Get
            Return mFMSG_LEVEL
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFMSG_LEVEL = Value
        End Set
    End Property
    ''' <summary>
    ''' ү�����ޯ������
    ''' </summary>
    Public Property FMSG_TYPE() As Nullable(Of Integer)
        Get
            Return mFMSG_TYPE
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFMSG_TYPE = Value
        End Set
    End Property
    ''' <summary>
    ''' ү�����ޯ������
    ''' </summary>
    Public Property FMSG_BTN() As Nullable(Of Integer)
        Get
            Return mFMSG_BTN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFMSG_BTN = Value
        End Set
    End Property
    ''' <summary>
    ''' ү�����ޯ������
    ''' </summary>
    Public Property FMSG_TITLE() As Nullable(Of Integer)
        Get
            Return mFMSG_TITLE
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFMSG_TITLE = Value
        End Set
    End Property
    ''' <summary>
    ''' ү�����ޯ���\��
    ''' </summary>
    Public Property FMSG_DSP() As Nullable(Of Integer)
        Get
            Return mFMSG_DSP
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFMSG_DSP = Value
        End Set
    End Property
    ''' <summary>
    ''' ۸ޏ����׸�
    ''' </summary>
    Public Property FLOG_FLAG() As Nullable(Of Integer)
        Get
            Return mFLOG_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFLOG_FLAG = Value
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
    Public Function GET_TMST_MESSAGE(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    TMST_MESSAGE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FMSG_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_ID
            strSQL.Append(vbCrLf & "    AND FMSG_ID = :" & UBound(strBindField) - 1 & " --ү����ID")
        End If
        If IsNull(FMSG_NAIYOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_NAIYOU
            strSQL.Append(vbCrLf & "    AND FMSG_NAIYOU = :" & UBound(strBindField) - 1 & " --ү���ޓ��e")
        End If
        If IsNull(FMSG_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_KUBUN
            strSQL.Append(vbCrLf & "    AND FMSG_KUBUN = :" & UBound(strBindField) - 1 & " --ү���ދ敪")
        End If
        If IsNull(FMSG_LEVEL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_LEVEL
            strSQL.Append(vbCrLf & "    AND FMSG_LEVEL = :" & UBound(strBindField) - 1 & " --ү��������")
        End If
        If IsNull(FMSG_TYPE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_TYPE
            strSQL.Append(vbCrLf & "    AND FMSG_TYPE = :" & UBound(strBindField) - 1 & " --ү�����ޯ������")
        End If
        If IsNull(FMSG_BTN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_BTN
            strSQL.Append(vbCrLf & "    AND FMSG_BTN = :" & UBound(strBindField) - 1 & " --ү�����ޯ������")
        End If
        If IsNull(FMSG_TITLE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_TITLE
            strSQL.Append(vbCrLf & "    AND FMSG_TITLE = :" & UBound(strBindField) - 1 & " --ү�����ޯ������")
        End If
        If IsNull(FMSG_DSP) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_DSP
            strSQL.Append(vbCrLf & "    AND FMSG_DSP = :" & UBound(strBindField) - 1 & " --ү�����ޯ���\��")
        End If
        If IsNull(FLOG_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_FLAG
            strSQL.Append(vbCrLf & "    AND FLOG_FLAG = :" & UBound(strBindField) - 1 & " --۸ޏ����׸�")
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
        strDataSetName = "TMST_MESSAGE"
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
    Public Function GET_TMST_MESSAGE_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    TMST_MESSAGE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FMSG_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_ID
            strSQL.Append(vbCrLf & "    AND FMSG_ID = :" & UBound(strBindField) - 1 & " --ү����ID")
        End If
        If IsNull(FMSG_NAIYOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_NAIYOU
            strSQL.Append(vbCrLf & "    AND FMSG_NAIYOU = :" & UBound(strBindField) - 1 & " --ү���ޓ��e")
        End If
        If IsNull(FMSG_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_KUBUN
            strSQL.Append(vbCrLf & "    AND FMSG_KUBUN = :" & UBound(strBindField) - 1 & " --ү���ދ敪")
        End If
        If IsNull(FMSG_LEVEL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_LEVEL
            strSQL.Append(vbCrLf & "    AND FMSG_LEVEL = :" & UBound(strBindField) - 1 & " --ү��������")
        End If
        If IsNull(FMSG_TYPE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_TYPE
            strSQL.Append(vbCrLf & "    AND FMSG_TYPE = :" & UBound(strBindField) - 1 & " --ү�����ޯ������")
        End If
        If IsNull(FMSG_BTN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_BTN
            strSQL.Append(vbCrLf & "    AND FMSG_BTN = :" & UBound(strBindField) - 1 & " --ү�����ޯ������")
        End If
        If IsNull(FMSG_TITLE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_TITLE
            strSQL.Append(vbCrLf & "    AND FMSG_TITLE = :" & UBound(strBindField) - 1 & " --ү�����ޯ������")
        End If
        If IsNull(FMSG_DSP) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_DSP
            strSQL.Append(vbCrLf & "    AND FMSG_DSP = :" & UBound(strBindField) - 1 & " --ү�����ޯ���\��")
        End If
        If IsNull(FLOG_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_FLAG
            strSQL.Append(vbCrLf & "    AND FLOG_FLAG = :" & UBound(strBindField) - 1 & " --۸ޏ����׸�")
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
        strDataSetName = "TMST_MESSAGE"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TMST_MESSAGE(Owner, objDb, objDbLog)
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
    Public Function GET_TMST_MESSAGE_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "TMST_MESSAGE"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TMST_MESSAGE(Owner, objDb, objDbLog)
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
    Public Function GET_TMST_MESSAGE_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    TMST_MESSAGE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FMSG_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_ID
            strSQL.Append(vbCrLf & "    AND FMSG_ID = :" & UBound(strBindField) - 1 & " --ү����ID")
        End If
        If IsNull(FMSG_NAIYOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_NAIYOU
            strSQL.Append(vbCrLf & "    AND FMSG_NAIYOU = :" & UBound(strBindField) - 1 & " --ү���ޓ��e")
        End If
        If IsNull(FMSG_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_KUBUN
            strSQL.Append(vbCrLf & "    AND FMSG_KUBUN = :" & UBound(strBindField) - 1 & " --ү���ދ敪")
        End If
        If IsNull(FMSG_LEVEL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_LEVEL
            strSQL.Append(vbCrLf & "    AND FMSG_LEVEL = :" & UBound(strBindField) - 1 & " --ү��������")
        End If
        If IsNull(FMSG_TYPE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_TYPE
            strSQL.Append(vbCrLf & "    AND FMSG_TYPE = :" & UBound(strBindField) - 1 & " --ү�����ޯ������")
        End If
        If IsNull(FMSG_BTN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_BTN
            strSQL.Append(vbCrLf & "    AND FMSG_BTN = :" & UBound(strBindField) - 1 & " --ү�����ޯ������")
        End If
        If IsNull(FMSG_TITLE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_TITLE
            strSQL.Append(vbCrLf & "    AND FMSG_TITLE = :" & UBound(strBindField) - 1 & " --ү�����ޯ������")
        End If
        If IsNull(FMSG_DSP) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_DSP
            strSQL.Append(vbCrLf & "    AND FMSG_DSP = :" & UBound(strBindField) - 1 & " --ү�����ޯ���\��")
        End If
        If IsNull(FLOG_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_FLAG
            strSQL.Append(vbCrLf & "    AND FLOG_FLAG = :" & UBound(strBindField) - 1 & " --۸ޏ����׸�")
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
        strDataSetName = "TMST_MESSAGE"
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
    Public Sub UPDATE_TMST_MESSAGE()
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
        ElseIf IsNull(mFMSG_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ү����ID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFMSG_NAIYOU) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ү���ޓ��e]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFMSG_KUBUN) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ү���ދ敪]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFMSG_LEVEL) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ү��������]"
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
        strSQL.Append(vbCrLf & "    TMST_MESSAGE")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
        If IsNull(mFMSG_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_ID = NULL --ү����ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_ID = NULL --ү����ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_ID = :" & Ubound(strBindField) - 1 & " --ү����ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_ID = :" & Ubound(strBindField) - 1 & " --ү����ID")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_NAIYOU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_NAIYOU = NULL --ү���ޓ��e")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_NAIYOU = NULL --ү���ޓ��e")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_NAIYOU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_NAIYOU = :" & Ubound(strBindField) - 1 & " --ү���ޓ��e")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_NAIYOU = :" & Ubound(strBindField) - 1 & " --ү���ޓ��e")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_KUBUN = NULL --ү���ދ敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_KUBUN = NULL --ү���ދ敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_KUBUN = :" & Ubound(strBindField) - 1 & " --ү���ދ敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_KUBUN = :" & Ubound(strBindField) - 1 & " --ү���ދ敪")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_LEVEL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_LEVEL = NULL --ү��������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_LEVEL = NULL --ү��������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_LEVEL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_LEVEL = :" & Ubound(strBindField) - 1 & " --ү��������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_LEVEL = :" & Ubound(strBindField) - 1 & " --ү��������")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_TYPE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_TYPE = NULL --ү�����ޯ������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_TYPE = NULL --ү�����ޯ������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_TYPE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_TYPE = :" & Ubound(strBindField) - 1 & " --ү�����ޯ������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_TYPE = :" & Ubound(strBindField) - 1 & " --ү�����ޯ������")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_BTN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_BTN = NULL --ү�����ޯ������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_BTN = NULL --ү�����ޯ������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_BTN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_BTN = :" & Ubound(strBindField) - 1 & " --ү�����ޯ������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_BTN = :" & Ubound(strBindField) - 1 & " --ү�����ޯ������")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_TITLE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_TITLE = NULL --ү�����ޯ������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_TITLE = NULL --ү�����ޯ������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_TITLE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_TITLE = :" & Ubound(strBindField) - 1 & " --ү�����ޯ������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_TITLE = :" & Ubound(strBindField) - 1 & " --ү�����ޯ������")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_DSP) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_DSP = NULL --ү�����ޯ���\��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_DSP = NULL --ү�����ޯ���\��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_DSP
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_DSP = :" & Ubound(strBindField) - 1 & " --ү�����ޯ���\��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_DSP = :" & Ubound(strBindField) - 1 & " --ү�����ޯ���\��")
        End If
        intCount = intCount + 1
        If IsNull(mFLOG_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_FLAG = NULL --۸ޏ����׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_FLAG = NULL --۸ޏ����׸�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_FLAG = :" & Ubound(strBindField) - 1 & " --۸ޏ����׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_FLAG = :" & Ubound(strBindField) - 1 & " --۸ޏ����׸�")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FMSG_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FMSG_ID IS NULL --ү����ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_ID
            strSQL.Append(vbCrLf & "    AND FMSG_ID = :" & UBound(strBindField) - 1 & " --ү����ID")
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
    Public Sub ADD_TMST_MESSAGE()
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
        ElseIf IsNull(mFMSG_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ү����ID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFMSG_NAIYOU) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ү���ޓ��e]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFMSG_KUBUN) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ү���ދ敪]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFMSG_LEVEL) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ү��������]"
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
        strSQL.Append(vbCrLf & "    TMST_MESSAGE")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
        If IsNull(mFMSG_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ү����ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ү����ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ү����ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ү����ID")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_NAIYOU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ү���ޓ��e")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ү���ޓ��e")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_NAIYOU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ү���ޓ��e")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ү���ޓ��e")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ү���ދ敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ү���ދ敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ү���ދ敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ү���ދ敪")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_LEVEL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ү��������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ү��������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_LEVEL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ү��������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ү��������")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_TYPE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ү�����ޯ������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ү�����ޯ������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_TYPE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ү�����ޯ������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ү�����ޯ������")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_BTN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ү�����ޯ������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ү�����ޯ������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_BTN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ү�����ޯ������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ү�����ޯ������")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_TITLE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ү�����ޯ������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ү�����ޯ������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_TITLE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ү�����ޯ������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ү�����ޯ������")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_DSP) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ү�����ޯ���\��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ү�����ޯ���\��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_DSP
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ү�����ޯ���\��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ү�����ޯ���\��")
        End If
        intCount = intCount + 1
        If IsNull(mFLOG_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --۸ޏ����׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --۸ޏ����׸�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --۸ޏ����׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --۸ޏ����׸�")
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
    Public Sub DELETE_TMST_MESSAGE()
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
        ElseIf IsNull(mFMSG_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ү����ID]"
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
        strSQL.Append(vbCrLf & "    TMST_MESSAGE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FMSG_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FMSG_ID IS NULL --ү����ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_ID
            strSQL.Append(vbCrLf & "    AND FMSG_ID = :" & UBound(strBindField) - 1 & " --ү����ID")
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
    Public Sub DELETE_TMST_MESSAGE_ANY()
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
        strSQL.Append(vbCrLf & "    TMST_MESSAGE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(FMSG_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_ID
            strSQL.Append(vbCrLf & "    AND FMSG_ID = :" & UBound(strBindField) - 1 & " --ү����ID")
        End If
        If IsNotNull(FMSG_NAIYOU) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_NAIYOU
            strSQL.Append(vbCrLf & "    AND FMSG_NAIYOU = :" & UBound(strBindField) - 1 & " --ү���ޓ��e")
        End If
        If IsNotNull(FMSG_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_KUBUN
            strSQL.Append(vbCrLf & "    AND FMSG_KUBUN = :" & UBound(strBindField) - 1 & " --ү���ދ敪")
        End If
        If IsNotNull(FMSG_LEVEL) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_LEVEL
            strSQL.Append(vbCrLf & "    AND FMSG_LEVEL = :" & UBound(strBindField) - 1 & " --ү��������")
        End If
        If IsNotNull(FMSG_TYPE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_TYPE
            strSQL.Append(vbCrLf & "    AND FMSG_TYPE = :" & UBound(strBindField) - 1 & " --ү�����ޯ������")
        End If
        If IsNotNull(FMSG_BTN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_BTN
            strSQL.Append(vbCrLf & "    AND FMSG_BTN = :" & UBound(strBindField) - 1 & " --ү�����ޯ������")
        End If
        If IsNotNull(FMSG_TITLE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_TITLE
            strSQL.Append(vbCrLf & "    AND FMSG_TITLE = :" & UBound(strBindField) - 1 & " --ү�����ޯ������")
        End If
        If IsNotNull(FMSG_DSP) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_DSP
            strSQL.Append(vbCrLf & "    AND FMSG_DSP = :" & UBound(strBindField) - 1 & " --ү�����ޯ���\��")
        End If
        If IsNotNull(FLOG_FLAG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_FLAG
            strSQL.Append(vbCrLf & "    AND FLOG_FLAG = :" & UBound(strBindField) - 1 & " --۸ޏ����׸�")
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
        If IsNothing(objType.GetProperty("FMSG_ID")) = False Then mFMSG_ID = objObject.FMSG_ID 'ү����ID
        If IsNothing(objType.GetProperty("FMSG_NAIYOU")) = False Then mFMSG_NAIYOU = objObject.FMSG_NAIYOU 'ү���ޓ��e
        If IsNothing(objType.GetProperty("FMSG_KUBUN")) = False Then mFMSG_KUBUN = objObject.FMSG_KUBUN 'ү���ދ敪
        If IsNothing(objType.GetProperty("FMSG_LEVEL")) = False Then mFMSG_LEVEL = objObject.FMSG_LEVEL 'ү��������
        If IsNothing(objType.GetProperty("FMSG_TYPE")) = False Then mFMSG_TYPE = objObject.FMSG_TYPE 'ү�����ޯ������
        If IsNothing(objType.GetProperty("FMSG_BTN")) = False Then mFMSG_BTN = objObject.FMSG_BTN 'ү�����ޯ������
        If IsNothing(objType.GetProperty("FMSG_TITLE")) = False Then mFMSG_TITLE = objObject.FMSG_TITLE 'ү�����ޯ������
        If IsNothing(objType.GetProperty("FMSG_DSP")) = False Then mFMSG_DSP = objObject.FMSG_DSP 'ү�����ޯ���\��
        If IsNothing(objType.GetProperty("FLOG_FLAG")) = False Then mFLOG_FLAG = objObject.FLOG_FLAG '۸ޏ����׸�

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
        mFMSG_ID = Nothing
        mFMSG_NAIYOU = Nothing
        mFMSG_KUBUN = Nothing
        mFMSG_LEVEL = Nothing
        mFMSG_TYPE = Nothing
        mFMSG_BTN = Nothing
        mFMSG_TITLE = Nothing
        mFMSG_DSP = Nothing
        mFLOG_FLAG = Nothing


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
        mFMSG_ID = TO_STRING_NULLABLE(objRow("FMSG_ID"))
        mFMSG_NAIYOU = TO_STRING_NULLABLE(objRow("FMSG_NAIYOU"))
        mFMSG_KUBUN = TO_INTEGER_NULLABLE(objRow("FMSG_KUBUN"))
        mFMSG_LEVEL = TO_INTEGER_NULLABLE(objRow("FMSG_LEVEL"))
        mFMSG_TYPE = TO_INTEGER_NULLABLE(objRow("FMSG_TYPE"))
        mFMSG_BTN = TO_INTEGER_NULLABLE(objRow("FMSG_BTN"))
        mFMSG_TITLE = TO_INTEGER_NULLABLE(objRow("FMSG_TITLE"))
        mFMSG_DSP = TO_INTEGER_NULLABLE(objRow("FMSG_DSP"))
        mFLOG_FLAG = TO_INTEGER_NULLABLE(objRow("FLOG_FLAG"))


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
        strMsg &= "[ð��ٖ�:ү����Ͻ�]"
        If IsNotNull(FMSG_ID) Then
            strMsg &= "[ү����ID:" & FMSG_ID & "]"
        End If
        If IsNotNull(FMSG_NAIYOU) Then
            strMsg &= "[ү���ޓ��e:" & FMSG_NAIYOU & "]"
        End If
        If IsNotNull(FMSG_KUBUN) Then
            strMsg &= "[ү���ދ敪:" & FMSG_KUBUN & "]"
        End If
        If IsNotNull(FMSG_LEVEL) Then
            strMsg &= "[ү��������:" & FMSG_LEVEL & "]"
        End If
        If IsNotNull(FMSG_TYPE) Then
            strMsg &= "[ү�����ޯ������:" & FMSG_TYPE & "]"
        End If
        If IsNotNull(FMSG_BTN) Then
            strMsg &= "[ү�����ޯ������:" & FMSG_BTN & "]"
        End If
        If IsNotNull(FMSG_TITLE) Then
            strMsg &= "[ү�����ޯ������:" & FMSG_TITLE & "]"
        End If
        If IsNotNull(FMSG_DSP) Then
            strMsg &= "[ү�����ޯ���\��:" & FMSG_DSP & "]"
        End If
        If IsNotNull(FLOG_FLAG) Then
            strMsg &= "[۸ޏ����׸�:" & FLOG_FLAG & "]"
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
