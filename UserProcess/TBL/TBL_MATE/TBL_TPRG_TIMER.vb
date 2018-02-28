'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' �y���́zMaterialStreamð��ٸ׽
' �y�@�\�z������Ǘ�ð��ٸ׽
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
''' ������Ǘ�ð��ٸ׽
''' </summary>
Public Class TBL_TPRG_TIMER
    Inherits clsTemplateTable

    '**********************************************************************************************
    '����������������
#Region "  �׽�ϐ���`                  "
    '�����è
    Private mobjAryMe As TBL_TPRG_TIMER()                                        '������Ǘ�
    Private mstrUSER_SQL As String                                               'հ�ްSQL
    Private mORDER_BY As String                                                  'OrderBy��
    Private mWHERE As String                                                     'Where��
    Private mFSYORI_ID As String                                                 '����ID
    Private mFYUKOU_FLAG As Nullable(Of Integer)                                 '�L���׸�
    Private mFKIDOU_FLAG As Nullable(Of Integer)                                 '�N���׸�
    Private mFEXEC_DT As Nullable(Of Date)                                       '���s����
    Private mFRANK As Nullable(Of Integer)                                       '�����D�揇��
    Private mFRANK_DTL As Nullable(Of Integer)                                   '�����D�揇�ʏڍ�
    Private mFSOCKET_MSG As String                                               '����
    Private mFLAST_DT As Nullable(Of Date)                                       '�ŏI��������
    Private mFTIME_OUT_SEC As Nullable(Of Integer)                               '��ϰ����
    Private mFCOMMENT As String                                                  '����
    Private mFLOG_OPE_FLAG As Nullable(Of Integer)                               '���ڰ���۸ޓo�^�׸�
    Private mFLOG_TRN_FLAG As Nullable(Of Integer)                               '��ݻ޸���۸ޓo�^�׸�
    Private mFEVD_OPE_FLAG As Nullable(Of Integer)                               '��Ɨ���o�^�׸�
#End Region
#Region "  �����è��`                  "
    ''' <summary>
    ''' ���ѕϐ� (���׽�^�z��)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_TPRG_TIMER()
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
    ''' �L���׸�
    ''' </summary>
    Public Property FYUKOU_FLAG() As Nullable(Of Integer)
        Get
            Return mFYUKOU_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFYUKOU_FLAG = Value
        End Set
    End Property
    ''' <summary>
    ''' �N���׸�
    ''' </summary>
    Public Property FKIDOU_FLAG() As Nullable(Of Integer)
        Get
            Return mFKIDOU_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFKIDOU_FLAG = Value
        End Set
    End Property
    ''' <summary>
    ''' ���s����
    ''' </summary>
    Public Property FEXEC_DT() As Nullable(Of Date)
        Get
            Return mFEXEC_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mFEXEC_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' �����D�揇��
    ''' </summary>
    Public Property FRANK() As Nullable(Of Integer)
        Get
            Return mFRANK
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRANK = Value
        End Set
    End Property
    ''' <summary>
    ''' �����D�揇�ʏڍ�
    ''' </summary>
    Public Property FRANK_DTL() As Nullable(Of Integer)
        Get
            Return mFRANK_DTL
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRANK_DTL = Value
        End Set
    End Property
    ''' <summary>
    ''' ����
    ''' </summary>
    Public Property FSOCKET_MSG() As String
        Get
            Return mFSOCKET_MSG
        End Get
        Set(ByVal Value As String)
            mFSOCKET_MSG = Value
        End Set
    End Property
    ''' <summary>
    ''' �ŏI��������
    ''' </summary>
    Public Property FLAST_DT() As Nullable(Of Date)
        Get
            Return mFLAST_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mFLAST_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' ��ϰ����
    ''' </summary>
    Public Property FTIME_OUT_SEC() As Nullable(Of Integer)
        Get
            Return mFTIME_OUT_SEC
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFTIME_OUT_SEC = Value
        End Set
    End Property
    ''' <summary>
    ''' ����
    ''' </summary>
    Public Property FCOMMENT() As String
        Get
            Return mFCOMMENT
        End Get
        Set(ByVal Value As String)
            mFCOMMENT = Value
        End Set
    End Property
    ''' <summary>
    ''' ���ڰ���۸ޓo�^�׸�
    ''' </summary>
    Public Property FLOG_OPE_FLAG() As Nullable(Of Integer)
        Get
            Return mFLOG_OPE_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFLOG_OPE_FLAG = Value
        End Set
    End Property
    ''' <summary>
    ''' ��ݻ޸���۸ޓo�^�׸�
    ''' </summary>
    Public Property FLOG_TRN_FLAG() As Nullable(Of Integer)
        Get
            Return mFLOG_TRN_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFLOG_TRN_FLAG = Value
        End Set
    End Property
    ''' <summary>
    ''' ��Ɨ���o�^�׸�
    ''' </summary>
    Public Property FEVD_OPE_FLAG() As Nullable(Of Integer)
        Get
            Return mFEVD_OPE_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFEVD_OPE_FLAG = Value
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
    Public Function GET_TPRG_TIMER(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    TPRG_TIMER")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FSYORI_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYORI_ID
            strSQL.Append(vbCrLf & "    AND FSYORI_ID = :" & UBound(strBindField) - 1 & " --����ID")
        End If
        If IsNull(FYUKOU_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFYUKOU_FLAG
            strSQL.Append(vbCrLf & "    AND FYUKOU_FLAG = :" & UBound(strBindField) - 1 & " --�L���׸�")
        End If
        If IsNull(FKIDOU_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFKIDOU_FLAG
            strSQL.Append(vbCrLf & "    AND FKIDOU_FLAG = :" & UBound(strBindField) - 1 & " --�N���׸�")
        End If
        If IsNull(FEXEC_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEXEC_DT
            strSQL.Append(vbCrLf & "    AND FEXEC_DT = :" & UBound(strBindField) - 1 & " --���s����")
        End If
        If IsNull(FRANK) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRANK
            strSQL.Append(vbCrLf & "    AND FRANK = :" & UBound(strBindField) - 1 & " --�����D�揇��")
        End If
        If IsNull(FRANK_DTL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRANK_DTL
            strSQL.Append(vbCrLf & "    AND FRANK_DTL = :" & UBound(strBindField) - 1 & " --�����D�揇�ʏڍ�")
        End If
        If IsNull(FSOCKET_MSG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSOCKET_MSG
            strSQL.Append(vbCrLf & "    AND FSOCKET_MSG = :" & UBound(strBindField) - 1 & " --����")
        End If
        If IsNull(FLAST_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLAST_DT
            strSQL.Append(vbCrLf & "    AND FLAST_DT = :" & UBound(strBindField) - 1 & " --�ŏI��������")
        End If
        If IsNull(FTIME_OUT_SEC) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTIME_OUT_SEC
            strSQL.Append(vbCrLf & "    AND FTIME_OUT_SEC = :" & UBound(strBindField) - 1 & " --��ϰ����")
        End If
        If IsNull(FCOMMENT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOMMENT
            strSQL.Append(vbCrLf & "    AND FCOMMENT = :" & UBound(strBindField) - 1 & " --����")
        End If
        If IsNull(FLOG_OPE_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_OPE_FLAG
            strSQL.Append(vbCrLf & "    AND FLOG_OPE_FLAG = :" & UBound(strBindField) - 1 & " --���ڰ���۸ޓo�^�׸�")
        End If
        If IsNull(FLOG_TRN_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_TRN_FLAG
            strSQL.Append(vbCrLf & "    AND FLOG_TRN_FLAG = :" & UBound(strBindField) - 1 & " --��ݻ޸���۸ޓo�^�׸�")
        End If
        If IsNull(FEVD_OPE_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEVD_OPE_FLAG
            strSQL.Append(vbCrLf & "    AND FEVD_OPE_FLAG = :" & UBound(strBindField) - 1 & " --��Ɨ���o�^�׸�")
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
        strDataSetName = "TPRG_TIMER"
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
    Public Function GET_TPRG_TIMER_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    TPRG_TIMER")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FSYORI_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYORI_ID
            strSQL.Append(vbCrLf & "    AND FSYORI_ID = :" & UBound(strBindField) - 1 & " --����ID")
        End If
        If IsNull(FYUKOU_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFYUKOU_FLAG
            strSQL.Append(vbCrLf & "    AND FYUKOU_FLAG = :" & UBound(strBindField) - 1 & " --�L���׸�")
        End If
        If IsNull(FKIDOU_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFKIDOU_FLAG
            strSQL.Append(vbCrLf & "    AND FKIDOU_FLAG = :" & UBound(strBindField) - 1 & " --�N���׸�")
        End If
        If IsNull(FEXEC_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEXEC_DT
            strSQL.Append(vbCrLf & "    AND FEXEC_DT = :" & UBound(strBindField) - 1 & " --���s����")
        End If
        If IsNull(FRANK) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRANK
            strSQL.Append(vbCrLf & "    AND FRANK = :" & UBound(strBindField) - 1 & " --�����D�揇��")
        End If
        If IsNull(FRANK_DTL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRANK_DTL
            strSQL.Append(vbCrLf & "    AND FRANK_DTL = :" & UBound(strBindField) - 1 & " --�����D�揇�ʏڍ�")
        End If
        If IsNull(FSOCKET_MSG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSOCKET_MSG
            strSQL.Append(vbCrLf & "    AND FSOCKET_MSG = :" & UBound(strBindField) - 1 & " --����")
        End If
        If IsNull(FLAST_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLAST_DT
            strSQL.Append(vbCrLf & "    AND FLAST_DT = :" & UBound(strBindField) - 1 & " --�ŏI��������")
        End If
        If IsNull(FTIME_OUT_SEC) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTIME_OUT_SEC
            strSQL.Append(vbCrLf & "    AND FTIME_OUT_SEC = :" & UBound(strBindField) - 1 & " --��ϰ����")
        End If
        If IsNull(FCOMMENT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOMMENT
            strSQL.Append(vbCrLf & "    AND FCOMMENT = :" & UBound(strBindField) - 1 & " --����")
        End If
        If IsNull(FLOG_OPE_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_OPE_FLAG
            strSQL.Append(vbCrLf & "    AND FLOG_OPE_FLAG = :" & UBound(strBindField) - 1 & " --���ڰ���۸ޓo�^�׸�")
        End If
        If IsNull(FLOG_TRN_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_TRN_FLAG
            strSQL.Append(vbCrLf & "    AND FLOG_TRN_FLAG = :" & UBound(strBindField) - 1 & " --��ݻ޸���۸ޓo�^�׸�")
        End If
        If IsNull(FEVD_OPE_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEVD_OPE_FLAG
            strSQL.Append(vbCrLf & "    AND FEVD_OPE_FLAG = :" & UBound(strBindField) - 1 & " --��Ɨ���o�^�׸�")
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
        strDataSetName = "TPRG_TIMER"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TPRG_TIMER(Owner, objDb, objDbLog)
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
    Public Function GET_TPRG_TIMER_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "TPRG_TIMER"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TPRG_TIMER(Owner, objDb, objDbLog)
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
    Public Function GET_TPRG_TIMER_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    TPRG_TIMER")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FSYORI_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYORI_ID
            strSQL.Append(vbCrLf & "    AND FSYORI_ID = :" & UBound(strBindField) - 1 & " --����ID")
        End If
        If IsNull(FYUKOU_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFYUKOU_FLAG
            strSQL.Append(vbCrLf & "    AND FYUKOU_FLAG = :" & UBound(strBindField) - 1 & " --�L���׸�")
        End If
        If IsNull(FKIDOU_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFKIDOU_FLAG
            strSQL.Append(vbCrLf & "    AND FKIDOU_FLAG = :" & UBound(strBindField) - 1 & " --�N���׸�")
        End If
        If IsNull(FEXEC_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEXEC_DT
            strSQL.Append(vbCrLf & "    AND FEXEC_DT = :" & UBound(strBindField) - 1 & " --���s����")
        End If
        If IsNull(FRANK) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRANK
            strSQL.Append(vbCrLf & "    AND FRANK = :" & UBound(strBindField) - 1 & " --�����D�揇��")
        End If
        If IsNull(FRANK_DTL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRANK_DTL
            strSQL.Append(vbCrLf & "    AND FRANK_DTL = :" & UBound(strBindField) - 1 & " --�����D�揇�ʏڍ�")
        End If
        If IsNull(FSOCKET_MSG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSOCKET_MSG
            strSQL.Append(vbCrLf & "    AND FSOCKET_MSG = :" & UBound(strBindField) - 1 & " --����")
        End If
        If IsNull(FLAST_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLAST_DT
            strSQL.Append(vbCrLf & "    AND FLAST_DT = :" & UBound(strBindField) - 1 & " --�ŏI��������")
        End If
        If IsNull(FTIME_OUT_SEC) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTIME_OUT_SEC
            strSQL.Append(vbCrLf & "    AND FTIME_OUT_SEC = :" & UBound(strBindField) - 1 & " --��ϰ����")
        End If
        If IsNull(FCOMMENT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOMMENT
            strSQL.Append(vbCrLf & "    AND FCOMMENT = :" & UBound(strBindField) - 1 & " --����")
        End If
        If IsNull(FLOG_OPE_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_OPE_FLAG
            strSQL.Append(vbCrLf & "    AND FLOG_OPE_FLAG = :" & UBound(strBindField) - 1 & " --���ڰ���۸ޓo�^�׸�")
        End If
        If IsNull(FLOG_TRN_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_TRN_FLAG
            strSQL.Append(vbCrLf & "    AND FLOG_TRN_FLAG = :" & UBound(strBindField) - 1 & " --��ݻ޸���۸ޓo�^�׸�")
        End If
        If IsNull(FEVD_OPE_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEVD_OPE_FLAG
            strSQL.Append(vbCrLf & "    AND FEVD_OPE_FLAG = :" & UBound(strBindField) - 1 & " --��Ɨ���o�^�׸�")
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
        strDataSetName = "TPRG_TIMER"
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
    Public Sub UPDATE_TPRG_TIMER()
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
        End If


        '***********************
        '�X�VSQL�쐬
        '***********************
        strBindField = Nothing
        objBindValue = Nothing
        ReDim Preserve strBindField(0)
        ReDim Preserve objBindValue(0)
        strSQL.Append(vbCrLf & "UPDATE")
        strSQL.Append(vbCrLf & "    TPRG_TIMER")
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
        If IsNull(mFYUKOU_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FYUKOU_FLAG = NULL --�L���׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FYUKOU_FLAG = NULL --�L���׸�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFYUKOU_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FYUKOU_FLAG = :" & Ubound(strBindField) - 1 & " --�L���׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FYUKOU_FLAG = :" & Ubound(strBindField) - 1 & " --�L���׸�")
        End If
        intCount = intCount + 1
        If IsNull(mFKIDOU_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FKIDOU_FLAG = NULL --�N���׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FKIDOU_FLAG = NULL --�N���׸�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFKIDOU_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FKIDOU_FLAG = :" & Ubound(strBindField) - 1 & " --�N���׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FKIDOU_FLAG = :" & Ubound(strBindField) - 1 & " --�N���׸�")
        End If
        intCount = intCount + 1
        If IsNull(mFEXEC_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEXEC_DT = NULL --���s����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEXEC_DT = NULL --���s����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEXEC_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEXEC_DT = :" & Ubound(strBindField) - 1 & " --���s����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEXEC_DT = :" & Ubound(strBindField) - 1 & " --���s����")
        End If
        intCount = intCount + 1
        If IsNull(mFRANK) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRANK = NULL --�����D�揇��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRANK = NULL --�����D�揇��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRANK
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRANK = :" & Ubound(strBindField) - 1 & " --�����D�揇��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRANK = :" & Ubound(strBindField) - 1 & " --�����D�揇��")
        End If
        intCount = intCount + 1
        If IsNull(mFRANK_DTL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRANK_DTL = NULL --�����D�揇�ʏڍ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRANK_DTL = NULL --�����D�揇�ʏڍ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRANK_DTL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRANK_DTL = :" & Ubound(strBindField) - 1 & " --�����D�揇�ʏڍ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRANK_DTL = :" & Ubound(strBindField) - 1 & " --�����D�揇�ʏڍ�")
        End If
        intCount = intCount + 1
        If IsNull(mFSOCKET_MSG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSOCKET_MSG = NULL --����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSOCKET_MSG = NULL --����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSOCKET_MSG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSOCKET_MSG = :" & Ubound(strBindField) - 1 & " --����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSOCKET_MSG = :" & Ubound(strBindField) - 1 & " --����")
        End If
        intCount = intCount + 1
        If IsNull(mFLAST_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLAST_DT = NULL --�ŏI��������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLAST_DT = NULL --�ŏI��������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLAST_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLAST_DT = :" & Ubound(strBindField) - 1 & " --�ŏI��������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLAST_DT = :" & Ubound(strBindField) - 1 & " --�ŏI��������")
        End If
        intCount = intCount + 1
        If IsNull(mFTIME_OUT_SEC) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTIME_OUT_SEC = NULL --��ϰ����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTIME_OUT_SEC = NULL --��ϰ����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTIME_OUT_SEC
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTIME_OUT_SEC = :" & Ubound(strBindField) - 1 & " --��ϰ����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTIME_OUT_SEC = :" & Ubound(strBindField) - 1 & " --��ϰ����")
        End If
        intCount = intCount + 1
        If IsNull(mFCOMMENT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCOMMENT = NULL --����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCOMMENT = NULL --����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOMMENT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCOMMENT = :" & Ubound(strBindField) - 1 & " --����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCOMMENT = :" & Ubound(strBindField) - 1 & " --����")
        End If
        intCount = intCount + 1
        If IsNull(mFLOG_OPE_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_OPE_FLAG = NULL --���ڰ���۸ޓo�^�׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_OPE_FLAG = NULL --���ڰ���۸ޓo�^�׸�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_OPE_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_OPE_FLAG = :" & Ubound(strBindField) - 1 & " --���ڰ���۸ޓo�^�׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_OPE_FLAG = :" & Ubound(strBindField) - 1 & " --���ڰ���۸ޓo�^�׸�")
        End If
        intCount = intCount + 1
        If IsNull(mFLOG_TRN_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_TRN_FLAG = NULL --��ݻ޸���۸ޓo�^�׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_TRN_FLAG = NULL --��ݻ޸���۸ޓo�^�׸�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_TRN_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_TRN_FLAG = :" & Ubound(strBindField) - 1 & " --��ݻ޸���۸ޓo�^�׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_TRN_FLAG = :" & Ubound(strBindField) - 1 & " --��ݻ޸���۸ޓo�^�׸�")
        End If
        intCount = intCount + 1
        If IsNull(mFEVD_OPE_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEVD_OPE_FLAG = NULL --��Ɨ���o�^�׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEVD_OPE_FLAG = NULL --��Ɨ���o�^�׸�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEVD_OPE_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEVD_OPE_FLAG = :" & Ubound(strBindField) - 1 & " --��Ɨ���o�^�׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEVD_OPE_FLAG = :" & Ubound(strBindField) - 1 & " --��Ɨ���o�^�׸�")
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
    Public Sub ADD_TPRG_TIMER()
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
        End If


        '***********************
        '�ǉ�SQL�쐬
        '***********************
        strBindField = Nothing
        objBindValue = Nothing
        ReDim Preserve strBindField(0)
        ReDim Preserve objBindValue(0)
        strSQL.Append(vbCrLf & "INSERT INTO")
        strSQL.Append(vbCrLf & "    TPRG_TIMER")
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
        If IsNull(mFYUKOU_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�L���׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�L���׸�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFYUKOU_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�L���׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�L���׸�")
        End If
        intCount = intCount + 1
        If IsNull(mFKIDOU_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�N���׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�N���׸�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFKIDOU_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�N���׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�N���׸�")
        End If
        intCount = intCount + 1
        If IsNull(mFEXEC_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���s����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���s����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEXEC_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���s����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���s����")
        End If
        intCount = intCount + 1
        If IsNull(mFRANK) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�����D�揇��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�����D�揇��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRANK
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�����D�揇��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�����D�揇��")
        End If
        intCount = intCount + 1
        If IsNull(mFRANK_DTL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�����D�揇�ʏڍ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�����D�揇�ʏڍ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRANK_DTL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�����D�揇�ʏڍ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�����D�揇�ʏڍ�")
        End If
        intCount = intCount + 1
        If IsNull(mFSOCKET_MSG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSOCKET_MSG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����")
        End If
        intCount = intCount + 1
        If IsNull(mFLAST_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ŏI��������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ŏI��������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLAST_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ŏI��������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ŏI��������")
        End If
        intCount = intCount + 1
        If IsNull(mFTIME_OUT_SEC) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --��ϰ����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --��ϰ����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTIME_OUT_SEC
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --��ϰ����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --��ϰ����")
        End If
        intCount = intCount + 1
        If IsNull(mFCOMMENT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOMMENT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����")
        End If
        intCount = intCount + 1
        If IsNull(mFLOG_OPE_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���ڰ���۸ޓo�^�׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���ڰ���۸ޓo�^�׸�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_OPE_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���ڰ���۸ޓo�^�׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���ڰ���۸ޓo�^�׸�")
        End If
        intCount = intCount + 1
        If IsNull(mFLOG_TRN_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --��ݻ޸���۸ޓo�^�׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --��ݻ޸���۸ޓo�^�׸�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_TRN_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --��ݻ޸���۸ޓo�^�׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --��ݻ޸���۸ޓo�^�׸�")
        End If
        intCount = intCount + 1
        If IsNull(mFEVD_OPE_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --��Ɨ���o�^�׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --��Ɨ���o�^�׸�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEVD_OPE_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --��Ɨ���o�^�׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --��Ɨ���o�^�׸�")
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
    Public Sub DELETE_TPRG_TIMER()
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
        strSQL.Append(vbCrLf & "    TPRG_TIMER")
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
    Public Sub DELETE_TPRG_TIMER_ANY()
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
        strSQL.Append(vbCrLf & "    TPRG_TIMER")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(FSYORI_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYORI_ID
            strSQL.Append(vbCrLf & "    AND FSYORI_ID = :" & UBound(strBindField) - 1 & " --����ID")
        End If
        If IsNotNull(FYUKOU_FLAG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFYUKOU_FLAG
            strSQL.Append(vbCrLf & "    AND FYUKOU_FLAG = :" & UBound(strBindField) - 1 & " --�L���׸�")
        End If
        If IsNotNull(FKIDOU_FLAG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFKIDOU_FLAG
            strSQL.Append(vbCrLf & "    AND FKIDOU_FLAG = :" & UBound(strBindField) - 1 & " --�N���׸�")
        End If
        If IsNotNull(FEXEC_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEXEC_DT
            strSQL.Append(vbCrLf & "    AND FEXEC_DT = :" & UBound(strBindField) - 1 & " --���s����")
        End If
        If IsNotNull(FRANK) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRANK
            strSQL.Append(vbCrLf & "    AND FRANK = :" & UBound(strBindField) - 1 & " --�����D�揇��")
        End If
        If IsNotNull(FRANK_DTL) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRANK_DTL
            strSQL.Append(vbCrLf & "    AND FRANK_DTL = :" & UBound(strBindField) - 1 & " --�����D�揇�ʏڍ�")
        End If
        If IsNotNull(FSOCKET_MSG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSOCKET_MSG
            strSQL.Append(vbCrLf & "    AND FSOCKET_MSG = :" & UBound(strBindField) - 1 & " --����")
        End If
        If IsNotNull(FLAST_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLAST_DT
            strSQL.Append(vbCrLf & "    AND FLAST_DT = :" & UBound(strBindField) - 1 & " --�ŏI��������")
        End If
        If IsNotNull(FTIME_OUT_SEC) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTIME_OUT_SEC
            strSQL.Append(vbCrLf & "    AND FTIME_OUT_SEC = :" & UBound(strBindField) - 1 & " --��ϰ����")
        End If
        If IsNotNull(FCOMMENT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOMMENT
            strSQL.Append(vbCrLf & "    AND FCOMMENT = :" & UBound(strBindField) - 1 & " --����")
        End If
        If IsNotNull(FLOG_OPE_FLAG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_OPE_FLAG
            strSQL.Append(vbCrLf & "    AND FLOG_OPE_FLAG = :" & UBound(strBindField) - 1 & " --���ڰ���۸ޓo�^�׸�")
        End If
        If IsNotNull(FLOG_TRN_FLAG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_TRN_FLAG
            strSQL.Append(vbCrLf & "    AND FLOG_TRN_FLAG = :" & UBound(strBindField) - 1 & " --��ݻ޸���۸ޓo�^�׸�")
        End If
        If IsNotNull(FEVD_OPE_FLAG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEVD_OPE_FLAG
            strSQL.Append(vbCrLf & "    AND FEVD_OPE_FLAG = :" & UBound(strBindField) - 1 & " --��Ɨ���o�^�׸�")
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
        If IsNothing(objType.GetProperty("FYUKOU_FLAG")) = False Then mFYUKOU_FLAG = objObject.FYUKOU_FLAG '�L���׸�
        If IsNothing(objType.GetProperty("FKIDOU_FLAG")) = False Then mFKIDOU_FLAG = objObject.FKIDOU_FLAG '�N���׸�
        If IsNothing(objType.GetProperty("FEXEC_DT")) = False Then mFEXEC_DT = objObject.FEXEC_DT '���s����
        If IsNothing(objType.GetProperty("FRANK")) = False Then mFRANK = objObject.FRANK '�����D�揇��
        If IsNothing(objType.GetProperty("FRANK_DTL")) = False Then mFRANK_DTL = objObject.FRANK_DTL '�����D�揇�ʏڍ�
        If IsNothing(objType.GetProperty("FSOCKET_MSG")) = False Then mFSOCKET_MSG = objObject.FSOCKET_MSG '����
        If IsNothing(objType.GetProperty("FLAST_DT")) = False Then mFLAST_DT = objObject.FLAST_DT '�ŏI��������
        If IsNothing(objType.GetProperty("FTIME_OUT_SEC")) = False Then mFTIME_OUT_SEC = objObject.FTIME_OUT_SEC '��ϰ����
        If IsNothing(objType.GetProperty("FCOMMENT")) = False Then mFCOMMENT = objObject.FCOMMENT '����
        If IsNothing(objType.GetProperty("FLOG_OPE_FLAG")) = False Then mFLOG_OPE_FLAG = objObject.FLOG_OPE_FLAG '���ڰ���۸ޓo�^�׸�
        If IsNothing(objType.GetProperty("FLOG_TRN_FLAG")) = False Then mFLOG_TRN_FLAG = objObject.FLOG_TRN_FLAG '��ݻ޸���۸ޓo�^�׸�
        If IsNothing(objType.GetProperty("FEVD_OPE_FLAG")) = False Then mFEVD_OPE_FLAG = objObject.FEVD_OPE_FLAG '��Ɨ���o�^�׸�

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
        mFYUKOU_FLAG = Nothing
        mFKIDOU_FLAG = Nothing
        mFEXEC_DT = Nothing
        mFRANK = Nothing
        mFRANK_DTL = Nothing
        mFSOCKET_MSG = Nothing
        mFLAST_DT = Nothing
        mFTIME_OUT_SEC = Nothing
        mFCOMMENT = Nothing
        mFLOG_OPE_FLAG = Nothing
        mFLOG_TRN_FLAG = Nothing
        mFEVD_OPE_FLAG = Nothing


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
        mFYUKOU_FLAG = TO_INTEGER_NULLABLE(objRow("FYUKOU_FLAG"))
        mFKIDOU_FLAG = TO_INTEGER_NULLABLE(objRow("FKIDOU_FLAG"))
        mFEXEC_DT = TO_DATE_NULLABLE(objRow("FEXEC_DT"))
        mFRANK = TO_INTEGER_NULLABLE(objRow("FRANK"))
        mFRANK_DTL = TO_INTEGER_NULLABLE(objRow("FRANK_DTL"))
        mFSOCKET_MSG = TO_STRING_NULLABLE(objRow("FSOCKET_MSG"))
        mFLAST_DT = TO_DATE_NULLABLE(objRow("FLAST_DT"))
        mFTIME_OUT_SEC = TO_INTEGER_NULLABLE(objRow("FTIME_OUT_SEC"))
        mFCOMMENT = TO_STRING_NULLABLE(objRow("FCOMMENT"))
        mFLOG_OPE_FLAG = TO_INTEGER_NULLABLE(objRow("FLOG_OPE_FLAG"))
        mFLOG_TRN_FLAG = TO_INTEGER_NULLABLE(objRow("FLOG_TRN_FLAG"))
        mFEVD_OPE_FLAG = TO_INTEGER_NULLABLE(objRow("FEVD_OPE_FLAG"))


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
        strMsg &= "[ð��ٖ�:������Ǘ�]"
        If IsNotNull(FSYORI_ID) Then
            strMsg &= "[����ID:" & FSYORI_ID & "]"
        End If
        If IsNotNull(FYUKOU_FLAG) Then
            strMsg &= "[�L���׸�:" & FYUKOU_FLAG & "]"
        End If
        If IsNotNull(FKIDOU_FLAG) Then
            strMsg &= "[�N���׸�:" & FKIDOU_FLAG & "]"
        End If
        If IsNotNull(FEXEC_DT) Then
            strMsg &= "[���s����:" & FEXEC_DT & "]"
        End If
        If IsNotNull(FRANK) Then
            strMsg &= "[�����D�揇��:" & FRANK & "]"
        End If
        If IsNotNull(FRANK_DTL) Then
            strMsg &= "[�����D�揇�ʏڍ�:" & FRANK_DTL & "]"
        End If
        If IsNotNull(FSOCKET_MSG) Then
            strMsg &= "[����:" & FSOCKET_MSG & "]"
        End If
        If IsNotNull(FLAST_DT) Then
            strMsg &= "[�ŏI��������:" & FLAST_DT & "]"
        End If
        If IsNotNull(FTIME_OUT_SEC) Then
            strMsg &= "[��ϰ����:" & FTIME_OUT_SEC & "]"
        End If
        If IsNotNull(FCOMMENT) Then
            strMsg &= "[����:" & FCOMMENT & "]"
        End If
        If IsNotNull(FLOG_OPE_FLAG) Then
            strMsg &= "[���ڰ���۸ޓo�^�׸�:" & FLOG_OPE_FLAG & "]"
        End If
        If IsNotNull(FLOG_TRN_FLAG) Then
            strMsg &= "[��ݻ޸���۸ޓo�^�׸�:" & FLOG_TRN_FLAG & "]"
        End If
        If IsNotNull(FEVD_OPE_FLAG) Then
            strMsg &= "[��Ɨ���o�^�׸�:" & FEVD_OPE_FLAG & "]"
        End If


    End Sub
#End Region
    '����������������
    '**********************************************************************************************

    '**********************************************************************************************
    '���������ы���
#Region "  �L���׸�ON               (Public  YUKOU_ON)"
    Public Sub YUKOU_ON(ByVal strSYORI_ID As String)
        Try
            Dim intRet As Integer               '�߂�l


            '***********************
            '������Ǘ����擾
            '***********************
            '������������************************************************************************************************************
            'Checked SystemMate:N.Dounoshita 2011/10/20 ҿ��ނ�A��Call�o���Ȃ��ׁA�C��
            Call CLEAR_PROPERTY()
            '������������************************************************************************************************************
            mFSYORI_ID = strSYORI_ID
            intRet = Me.GET_TPRG_TIMER(True)


            '***********************
            '������Ǘ����X�V
            '***********************
            mFLAST_DT = Now
            mFYUKOU_FLAG = FLAG_ON
            Me.UPDATE_TPRG_TIMER()


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
#Region "  �L���׸�OFF              (Public  YUUOU_OFF)"
    Public Sub YUKOU_OFF(ByVal strSYORI_ID As String)
        Try
            Dim intRet As Integer               '�߂�l

            '***********************
            '������Ǘ����擾
            '***********************
            '������������************************************************************************************************************
            'Checked SystemMate:N.Dounoshita 2011/10/20 ҿ��ނ�A��Call�o���Ȃ��ׁA�C��
            Call CLEAR_PROPERTY()
            '������������************************************************************************************************************
            mFSYORI_ID = strSYORI_ID
            intRet = Me.GET_TPRG_TIMER(True)


            '***********************
            '������Ǘ����X�V
            '***********************
            mFLAST_DT = Now
            mFYUKOU_FLAG = FLAG_OFF
            Me.UPDATE_TPRG_TIMER()


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
#Region "  �N���׸�ON               (Public  KIDOU_ON)"
    Public Sub KIDOU_ON(ByVal strSYORI_ID As String)
        Try
            Dim intRet As Integer               '�߂�l

            '***********************
            '������Ǘ����擾
            '***********************
            '������������************************************************************************************************************
            'Checked SystemMate:N.Dounoshita 2011/10/20 ҿ��ނ�A��Call�o���Ȃ��ׁA�C��
            Call CLEAR_PROPERTY()
            '������������************************************************************************************************************
            mFSYORI_ID = FORMAT_DSP_DELCMD & strSYORI_ID
            intRet = Me.GET_TPRG_TIMER(True)


            '***********************
            '������Ǘ����X�V
            '***********************
            mFLAST_DT = Now
            mFKIDOU_FLAG = FLAG_ON
            Me.UPDATE_TPRG_TIMER()


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
#Region "  �N���׸�OFF              (Public  KIDOU_OFF)"
    Public Sub KIDOU_OFF(ByVal strSYORI_ID As String)
        Try
            Dim intRet As Integer               '�߂�l

            '***********************
            '������Ǘ����擾
            '***********************
            '������������************************************************************************************************************
            'Checked SystemMate:N.Dounoshita 2011/10/20 ҿ��ނ�A��Call�o���Ȃ��ׁA�C��
            Call CLEAR_PROPERTY()
            '������������************************************************************************************************************
            mFSYORI_ID = strSYORI_ID
            intRet = Me.GET_TPRG_TIMER(True)


            '***********************
            '������Ǘ����X�V
            '***********************
            mFLAST_DT = Now
            mFKIDOU_FLAG = FLAG_OFF
            Me.UPDATE_TPRG_TIMER()


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
