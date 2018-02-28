'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' �y���́zMaterialStreamð��ٸ׽
' �y�@�\�z�ݔ���ð��ٸ׽
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
''' �ݔ���ð��ٸ׽
''' </summary>
Public Class TBL_TSTS_EQ_CTRL
    Inherits clsTemplateTable

    '**********************************************************************************************
    '����������������
#Region "  �׽�ϐ���`                  "
    '�����è
    Private mobjAryMe As TBL_TSTS_EQ_CTRL()                                      '�ݔ���
    Private mstrUSER_SQL As String                                               'հ�ްSQL
    Private mORDER_BY As String                                                  'OrderBy��
    Private mWHERE As String                                                     'Where��
    Private mFEQ_ID As String                                                    '�ݔ�ID
    Private mFEQ_KUBUN As Nullable(Of Integer)                                   '�ݔ��敪
    Private mFEQ_ID_LOCAL As String                                              '۰�ِݔ�ID
    Private mFTRK_BUF_NO As Nullable(Of Integer)                                 '�ׯ�ݸ��ޯ̧��
    Private mFEQ_NAME As String                                                  '�ݔ�����
    Private mFEQ_STS As String                                                   '�ݔ����
    Private mFEQ_STOP_CD As String                                               '��~�v������
    Private mFEQ_REQ_STS As Nullable(Of Integer)                                 '�v�����
    Private mFEQ_CUT_STS As Nullable(Of Integer)                                 '�ؗ����
    Private mFEQ_CUT_KUBUN As Nullable(Of Integer)                               '�ؗ���
    Private mFEQ_PASS_FLAG As Nullable(Of Integer)                               '�����w�������ǉz�׸�
    Private mFUPDATE_DT As Nullable(Of Date)                                     '�X�V����
    Private mFENTRY_DT As Nullable(Of Date)                                      '�o�^����
    Private mFUSER_ID As String                                                  'հ�ްID
    Private mFCOMMENT As String                                                  '����
    Private mFEQ_DSP_KUBUN As Nullable(Of Integer)                               '��ʐݔ���ԕ\���敪
    Private mFEQ_STOP_KUBUN As Nullable(Of Integer)                              '�ݔ���~�v���敪
    Private mXEVENT_FLAG As Nullable(Of Integer)                                 '����Ēʒm�׸�
    Private mXEVENT_LOG_KUBUN As Nullable(Of Integer)                            '����Ēʒm۸ޏo�͋敪
    Private mXEQ_DSP_GROUP_KUBUN As Nullable(Of Integer)                         '��ٰ�ߐݔ���ԕ\���敪
    Private mXEQ_RPT_KUBUN01 As Nullable(Of Integer)                             '���[�敪01
    Private mXEQ_ERR_KUBUN As Nullable(Of Integer)                               '�ݔ��ُ�۸ޏo�͋敪
#End Region
#Region "  �����è��`                  "
    ''' <summary>
    ''' ���ѕϐ� (���׽�^�z��)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_TSTS_EQ_CTRL()
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
    ''' �ݔ��敪
    ''' </summary>
    Public Property FEQ_KUBUN() As Nullable(Of Integer)
        Get
            Return mFEQ_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFEQ_KUBUN = Value
        End Set
    End Property
    ''' <summary>
    ''' ۰�ِݔ�ID
    ''' </summary>
    Public Property FEQ_ID_LOCAL() As String
        Get
            Return mFEQ_ID_LOCAL
        End Get
        Set(ByVal Value As String)
            mFEQ_ID_LOCAL = Value
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
    ''' �ݔ�����
    ''' </summary>
    Public Property FEQ_NAME() As String
        Get
            Return mFEQ_NAME
        End Get
        Set(ByVal Value As String)
            mFEQ_NAME = Value
        End Set
    End Property
    ''' <summary>
    ''' �ݔ����
    ''' </summary>
    Public Property FEQ_STS() As String
        Get
            Return mFEQ_STS
        End Get
        Set(ByVal Value As String)
            mFEQ_STS = Value
        End Set
    End Property
    ''' <summary>
    ''' ��~�v������
    ''' </summary>
    Public Property FEQ_STOP_CD() As String
        Get
            Return mFEQ_STOP_CD
        End Get
        Set(ByVal Value As String)
            mFEQ_STOP_CD = Value
        End Set
    End Property
    ''' <summary>
    ''' �v�����
    ''' </summary>
    Public Property FEQ_REQ_STS() As Nullable(Of Integer)
        Get
            Return mFEQ_REQ_STS
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFEQ_REQ_STS = Value
        End Set
    End Property
    ''' <summary>
    ''' �ؗ����
    ''' </summary>
    Public Property FEQ_CUT_STS() As Nullable(Of Integer)
        Get
            Return mFEQ_CUT_STS
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFEQ_CUT_STS = Value
        End Set
    End Property
    ''' <summary>
    ''' �ؗ���
    ''' </summary>
    Public Property FEQ_CUT_KUBUN() As Nullable(Of Integer)
        Get
            Return mFEQ_CUT_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFEQ_CUT_KUBUN = Value
        End Set
    End Property
    ''' <summary>
    ''' �����w�������ǉz�׸�
    ''' </summary>
    Public Property FEQ_PASS_FLAG() As Nullable(Of Integer)
        Get
            Return mFEQ_PASS_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFEQ_PASS_FLAG = Value
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
    ''' ��ʐݔ���ԕ\���敪
    ''' </summary>
    Public Property FEQ_DSP_KUBUN() As Nullable(Of Integer)
        Get
            Return mFEQ_DSP_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFEQ_DSP_KUBUN = Value
        End Set
    End Property
    ''' <summary>
    ''' �ݔ���~�v���敪
    ''' </summary>
    Public Property FEQ_STOP_KUBUN() As Nullable(Of Integer)
        Get
            Return mFEQ_STOP_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFEQ_STOP_KUBUN = Value
        End Set
    End Property
    ''' <summary>
    ''' ����Ēʒm�׸�
    ''' </summary>
    Public Property XEVENT_FLAG() As Nullable(Of Integer)
        Get
            Return mXEVENT_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXEVENT_FLAG = Value
        End Set
    End Property
    ''' <summary>
    ''' ����Ēʒm۸ޏo�͋敪
    ''' </summary>
    Public Property XEVENT_LOG_KUBUN() As Nullable(Of Integer)
        Get
            Return mXEVENT_LOG_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXEVENT_LOG_KUBUN = Value
        End Set
    End Property
    ''' <summary>
    ''' ��ٰ�ߐݔ���ԕ\���敪
    ''' </summary>
    Public Property XEQ_DSP_GROUP_KUBUN() As Nullable(Of Integer)
        Get
            Return mXEQ_DSP_GROUP_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXEQ_DSP_GROUP_KUBUN = Value
        End Set
    End Property
    ''' <summary>
    ''' ���[�敪01
    ''' </summary>
    Public Property XEQ_RPT_KUBUN01() As Nullable(Of Integer)
        Get
            Return mXEQ_RPT_KUBUN01
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXEQ_RPT_KUBUN01 = Value
        End Set
    End Property
    ''' <summary>
    ''' �ݔ��ُ�۸ޏo�͋敪
    ''' </summary>
    Public Property XEQ_ERR_KUBUN() As Nullable(Of Integer)
        Get
            Return mXEQ_ERR_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXEQ_ERR_KUBUN = Value
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
    Public Function GET_TSTS_EQ_CTRL(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    TSTS_EQ_CTRL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FEQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --�ݔ�ID")
        End If
        If IsNull(FEQ_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_KUBUN
            strSQL.Append(vbCrLf & "    AND FEQ_KUBUN = :" & UBound(strBindField) - 1 & " --�ݔ��敪")
        End If
        If IsNull(FEQ_ID_LOCAL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID_LOCAL
            strSQL.Append(vbCrLf & "    AND FEQ_ID_LOCAL = :" & UBound(strBindField) - 1 & " --۰�ِݔ�ID")
        End If
        If IsNull(FTRK_BUF_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FEQ_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_NAME
            strSQL.Append(vbCrLf & "    AND FEQ_NAME = :" & UBound(strBindField) - 1 & " --�ݔ�����")
        End If
        If IsNull(FEQ_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STS
            strSQL.Append(vbCrLf & "    AND FEQ_STS = :" & UBound(strBindField) - 1 & " --�ݔ����")
        End If
        If IsNull(FEQ_STOP_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STOP_CD
            strSQL.Append(vbCrLf & "    AND FEQ_STOP_CD = :" & UBound(strBindField) - 1 & " --��~�v������")
        End If
        If IsNull(FEQ_REQ_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_REQ_STS
            strSQL.Append(vbCrLf & "    AND FEQ_REQ_STS = :" & UBound(strBindField) - 1 & " --�v�����")
        End If
        If IsNull(FEQ_CUT_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_CUT_STS
            strSQL.Append(vbCrLf & "    AND FEQ_CUT_STS = :" & UBound(strBindField) - 1 & " --�ؗ����")
        End If
        If IsNull(FEQ_CUT_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_CUT_KUBUN
            strSQL.Append(vbCrLf & "    AND FEQ_CUT_KUBUN = :" & UBound(strBindField) - 1 & " --�ؗ���")
        End If
        If IsNull(FEQ_PASS_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_PASS_FLAG
            strSQL.Append(vbCrLf & "    AND FEQ_PASS_FLAG = :" & UBound(strBindField) - 1 & " --�����w�������ǉz�׸�")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --�X�V����")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --�o�^����")
        End If
        If IsNull(FUSER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID
            strSQL.Append(vbCrLf & "    AND FUSER_ID = :" & UBound(strBindField) - 1 & " --հ�ްID")
        End If
        If IsNull(FCOMMENT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOMMENT
            strSQL.Append(vbCrLf & "    AND FCOMMENT = :" & UBound(strBindField) - 1 & " --����")
        End If
        If IsNull(FEQ_DSP_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_DSP_KUBUN
            strSQL.Append(vbCrLf & "    AND FEQ_DSP_KUBUN = :" & UBound(strBindField) - 1 & " --��ʐݔ���ԕ\���敪")
        End If
        If IsNull(FEQ_STOP_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STOP_KUBUN
            strSQL.Append(vbCrLf & "    AND FEQ_STOP_KUBUN = :" & UBound(strBindField) - 1 & " --�ݔ���~�v���敪")
        End If
        If IsNull(XEVENT_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEVENT_FLAG
            strSQL.Append(vbCrLf & "    AND XEVENT_FLAG = :" & UBound(strBindField) - 1 & " --����Ēʒm�׸�")
        End If
        If IsNull(XEVENT_LOG_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEVENT_LOG_KUBUN
            strSQL.Append(vbCrLf & "    AND XEVENT_LOG_KUBUN = :" & UBound(strBindField) - 1 & " --����Ēʒm۸ޏo�͋敪")
        End If
        If IsNull(XEQ_DSP_GROUP_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_DSP_GROUP_KUBUN
            strSQL.Append(vbCrLf & "    AND XEQ_DSP_GROUP_KUBUN = :" & UBound(strBindField) - 1 & " --��ٰ�ߐݔ���ԕ\���敪")
        End If
        If IsNull(XEQ_RPT_KUBUN01) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_RPT_KUBUN01
            strSQL.Append(vbCrLf & "    AND XEQ_RPT_KUBUN01 = :" & UBound(strBindField) - 1 & " --���[�敪01")
        End If
        If IsNull(XEQ_ERR_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ERR_KUBUN
            strSQL.Append(vbCrLf & "    AND XEQ_ERR_KUBUN = :" & UBound(strBindField) - 1 & " --�ݔ��ُ�۸ޏo�͋敪")
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
        strDataSetName = "TSTS_EQ_CTRL"
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
    Public Function GET_TSTS_EQ_CTRL_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    TSTS_EQ_CTRL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FEQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --�ݔ�ID")
        End If
        If IsNull(FEQ_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_KUBUN
            strSQL.Append(vbCrLf & "    AND FEQ_KUBUN = :" & UBound(strBindField) - 1 & " --�ݔ��敪")
        End If
        If IsNull(FEQ_ID_LOCAL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID_LOCAL
            strSQL.Append(vbCrLf & "    AND FEQ_ID_LOCAL = :" & UBound(strBindField) - 1 & " --۰�ِݔ�ID")
        End If
        If IsNull(FTRK_BUF_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FEQ_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_NAME
            strSQL.Append(vbCrLf & "    AND FEQ_NAME = :" & UBound(strBindField) - 1 & " --�ݔ�����")
        End If
        If IsNull(FEQ_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STS
            strSQL.Append(vbCrLf & "    AND FEQ_STS = :" & UBound(strBindField) - 1 & " --�ݔ����")
        End If
        If IsNull(FEQ_STOP_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STOP_CD
            strSQL.Append(vbCrLf & "    AND FEQ_STOP_CD = :" & UBound(strBindField) - 1 & " --��~�v������")
        End If
        If IsNull(FEQ_REQ_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_REQ_STS
            strSQL.Append(vbCrLf & "    AND FEQ_REQ_STS = :" & UBound(strBindField) - 1 & " --�v�����")
        End If
        If IsNull(FEQ_CUT_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_CUT_STS
            strSQL.Append(vbCrLf & "    AND FEQ_CUT_STS = :" & UBound(strBindField) - 1 & " --�ؗ����")
        End If
        If IsNull(FEQ_CUT_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_CUT_KUBUN
            strSQL.Append(vbCrLf & "    AND FEQ_CUT_KUBUN = :" & UBound(strBindField) - 1 & " --�ؗ���")
        End If
        If IsNull(FEQ_PASS_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_PASS_FLAG
            strSQL.Append(vbCrLf & "    AND FEQ_PASS_FLAG = :" & UBound(strBindField) - 1 & " --�����w�������ǉz�׸�")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --�X�V����")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --�o�^����")
        End If
        If IsNull(FUSER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID
            strSQL.Append(vbCrLf & "    AND FUSER_ID = :" & UBound(strBindField) - 1 & " --հ�ްID")
        End If
        If IsNull(FCOMMENT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOMMENT
            strSQL.Append(vbCrLf & "    AND FCOMMENT = :" & UBound(strBindField) - 1 & " --����")
        End If
        If IsNull(FEQ_DSP_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_DSP_KUBUN
            strSQL.Append(vbCrLf & "    AND FEQ_DSP_KUBUN = :" & UBound(strBindField) - 1 & " --��ʐݔ���ԕ\���敪")
        End If
        If IsNull(FEQ_STOP_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STOP_KUBUN
            strSQL.Append(vbCrLf & "    AND FEQ_STOP_KUBUN = :" & UBound(strBindField) - 1 & " --�ݔ���~�v���敪")
        End If
        If IsNull(XEVENT_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEVENT_FLAG
            strSQL.Append(vbCrLf & "    AND XEVENT_FLAG = :" & UBound(strBindField) - 1 & " --����Ēʒm�׸�")
        End If
        If IsNull(XEVENT_LOG_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEVENT_LOG_KUBUN
            strSQL.Append(vbCrLf & "    AND XEVENT_LOG_KUBUN = :" & UBound(strBindField) - 1 & " --����Ēʒm۸ޏo�͋敪")
        End If
        If IsNull(XEQ_DSP_GROUP_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_DSP_GROUP_KUBUN
            strSQL.Append(vbCrLf & "    AND XEQ_DSP_GROUP_KUBUN = :" & UBound(strBindField) - 1 & " --��ٰ�ߐݔ���ԕ\���敪")
        End If
        If IsNull(XEQ_RPT_KUBUN01) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_RPT_KUBUN01
            strSQL.Append(vbCrLf & "    AND XEQ_RPT_KUBUN01 = :" & UBound(strBindField) - 1 & " --���[�敪01")
        End If
        If IsNull(XEQ_ERR_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ERR_KUBUN
            strSQL.Append(vbCrLf & "    AND XEQ_ERR_KUBUN = :" & UBound(strBindField) - 1 & " --�ݔ��ُ�۸ޏo�͋敪")
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
        strDataSetName = "TSTS_EQ_CTRL"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TSTS_EQ_CTRL(Owner, objDb, objDbLog)
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
    Public Function GET_TSTS_EQ_CTRL_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "TSTS_EQ_CTRL"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TSTS_EQ_CTRL(Owner, objDb, objDbLog)
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
    Public Function GET_TSTS_EQ_CTRL_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    TSTS_EQ_CTRL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FEQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --�ݔ�ID")
        End If
        If IsNull(FEQ_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_KUBUN
            strSQL.Append(vbCrLf & "    AND FEQ_KUBUN = :" & UBound(strBindField) - 1 & " --�ݔ��敪")
        End If
        If IsNull(FEQ_ID_LOCAL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID_LOCAL
            strSQL.Append(vbCrLf & "    AND FEQ_ID_LOCAL = :" & UBound(strBindField) - 1 & " --۰�ِݔ�ID")
        End If
        If IsNull(FTRK_BUF_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧��")
        End If
        If IsNull(FEQ_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_NAME
            strSQL.Append(vbCrLf & "    AND FEQ_NAME = :" & UBound(strBindField) - 1 & " --�ݔ�����")
        End If
        If IsNull(FEQ_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STS
            strSQL.Append(vbCrLf & "    AND FEQ_STS = :" & UBound(strBindField) - 1 & " --�ݔ����")
        End If
        If IsNull(FEQ_STOP_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STOP_CD
            strSQL.Append(vbCrLf & "    AND FEQ_STOP_CD = :" & UBound(strBindField) - 1 & " --��~�v������")
        End If
        If IsNull(FEQ_REQ_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_REQ_STS
            strSQL.Append(vbCrLf & "    AND FEQ_REQ_STS = :" & UBound(strBindField) - 1 & " --�v�����")
        End If
        If IsNull(FEQ_CUT_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_CUT_STS
            strSQL.Append(vbCrLf & "    AND FEQ_CUT_STS = :" & UBound(strBindField) - 1 & " --�ؗ����")
        End If
        If IsNull(FEQ_CUT_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_CUT_KUBUN
            strSQL.Append(vbCrLf & "    AND FEQ_CUT_KUBUN = :" & UBound(strBindField) - 1 & " --�ؗ���")
        End If
        If IsNull(FEQ_PASS_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_PASS_FLAG
            strSQL.Append(vbCrLf & "    AND FEQ_PASS_FLAG = :" & UBound(strBindField) - 1 & " --�����w�������ǉz�׸�")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --�X�V����")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --�o�^����")
        End If
        If IsNull(FUSER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID
            strSQL.Append(vbCrLf & "    AND FUSER_ID = :" & UBound(strBindField) - 1 & " --հ�ްID")
        End If
        If IsNull(FCOMMENT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOMMENT
            strSQL.Append(vbCrLf & "    AND FCOMMENT = :" & UBound(strBindField) - 1 & " --����")
        End If
        If IsNull(FEQ_DSP_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_DSP_KUBUN
            strSQL.Append(vbCrLf & "    AND FEQ_DSP_KUBUN = :" & UBound(strBindField) - 1 & " --��ʐݔ���ԕ\���敪")
        End If
        If IsNull(FEQ_STOP_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STOP_KUBUN
            strSQL.Append(vbCrLf & "    AND FEQ_STOP_KUBUN = :" & UBound(strBindField) - 1 & " --�ݔ���~�v���敪")
        End If
        If IsNull(XEVENT_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEVENT_FLAG
            strSQL.Append(vbCrLf & "    AND XEVENT_FLAG = :" & UBound(strBindField) - 1 & " --����Ēʒm�׸�")
        End If
        If IsNull(XEVENT_LOG_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEVENT_LOG_KUBUN
            strSQL.Append(vbCrLf & "    AND XEVENT_LOG_KUBUN = :" & UBound(strBindField) - 1 & " --����Ēʒm۸ޏo�͋敪")
        End If
        If IsNull(XEQ_DSP_GROUP_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_DSP_GROUP_KUBUN
            strSQL.Append(vbCrLf & "    AND XEQ_DSP_GROUP_KUBUN = :" & UBound(strBindField) - 1 & " --��ٰ�ߐݔ���ԕ\���敪")
        End If
        If IsNull(XEQ_RPT_KUBUN01) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_RPT_KUBUN01
            strSQL.Append(vbCrLf & "    AND XEQ_RPT_KUBUN01 = :" & UBound(strBindField) - 1 & " --���[�敪01")
        End If
        If IsNull(XEQ_ERR_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ERR_KUBUN
            strSQL.Append(vbCrLf & "    AND XEQ_ERR_KUBUN = :" & UBound(strBindField) - 1 & " --�ݔ��ُ�۸ޏo�͋敪")
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
        strDataSetName = "TSTS_EQ_CTRL"
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
    Public Sub UPDATE_TSTS_EQ_CTRL()
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
        ElseIf IsNull(mFEQ_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�ݔ�ID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFEQ_KUBUN) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�ݔ��敪]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFEQ_NAME) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�ݔ�����]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFEQ_STS) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�ݔ����]"
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
        strSQL.Append(vbCrLf & "    TSTS_EQ_CTRL")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
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
        If IsNull(mFEQ_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_KUBUN = NULL --�ݔ��敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_KUBUN = NULL --�ݔ��敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_KUBUN = :" & Ubound(strBindField) - 1 & " --�ݔ��敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_KUBUN = :" & Ubound(strBindField) - 1 & " --�ݔ��敪")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_ID_LOCAL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_ID_LOCAL = NULL --۰�ِݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_ID_LOCAL = NULL --۰�ِݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID_LOCAL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_ID_LOCAL = :" & Ubound(strBindField) - 1 & " --۰�ِݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_ID_LOCAL = :" & Ubound(strBindField) - 1 & " --۰�ِݔ�ID")
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
        If IsNull(mFEQ_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_NAME = NULL --�ݔ�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_NAME = NULL --�ݔ�����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_NAME = :" & Ubound(strBindField) - 1 & " --�ݔ�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_NAME = :" & Ubound(strBindField) - 1 & " --�ݔ�����")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_STS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_STS = NULL --�ݔ����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_STS = NULL --�ݔ����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_STS = :" & Ubound(strBindField) - 1 & " --�ݔ����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_STS = :" & Ubound(strBindField) - 1 & " --�ݔ����")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_STOP_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_STOP_CD = NULL --��~�v������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_STOP_CD = NULL --��~�v������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STOP_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_STOP_CD = :" & Ubound(strBindField) - 1 & " --��~�v������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_STOP_CD = :" & Ubound(strBindField) - 1 & " --��~�v������")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_REQ_STS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_REQ_STS = NULL --�v�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_REQ_STS = NULL --�v�����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_REQ_STS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_REQ_STS = :" & Ubound(strBindField) - 1 & " --�v�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_REQ_STS = :" & Ubound(strBindField) - 1 & " --�v�����")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_CUT_STS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_CUT_STS = NULL --�ؗ����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_CUT_STS = NULL --�ؗ����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_CUT_STS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_CUT_STS = :" & Ubound(strBindField) - 1 & " --�ؗ����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_CUT_STS = :" & Ubound(strBindField) - 1 & " --�ؗ����")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_CUT_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_CUT_KUBUN = NULL --�ؗ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_CUT_KUBUN = NULL --�ؗ���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_CUT_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_CUT_KUBUN = :" & Ubound(strBindField) - 1 & " --�ؗ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_CUT_KUBUN = :" & Ubound(strBindField) - 1 & " --�ؗ���")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_PASS_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_PASS_FLAG = NULL --�����w�������ǉz�׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_PASS_FLAG = NULL --�����w�������ǉz�׸�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_PASS_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_PASS_FLAG = :" & Ubound(strBindField) - 1 & " --�����w�������ǉz�׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_PASS_FLAG = :" & Ubound(strBindField) - 1 & " --�����w�������ǉz�׸�")
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
        If IsNull(mFEQ_DSP_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_DSP_KUBUN = NULL --��ʐݔ���ԕ\���敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_DSP_KUBUN = NULL --��ʐݔ���ԕ\���敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_DSP_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_DSP_KUBUN = :" & Ubound(strBindField) - 1 & " --��ʐݔ���ԕ\���敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_DSP_KUBUN = :" & Ubound(strBindField) - 1 & " --��ʐݔ���ԕ\���敪")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_STOP_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_STOP_KUBUN = NULL --�ݔ���~�v���敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_STOP_KUBUN = NULL --�ݔ���~�v���敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STOP_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_STOP_KUBUN = :" & Ubound(strBindField) - 1 & " --�ݔ���~�v���敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_STOP_KUBUN = :" & Ubound(strBindField) - 1 & " --�ݔ���~�v���敪")
        End If
        intCount = intCount + 1
        If IsNull(mXEVENT_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEVENT_FLAG = NULL --����Ēʒm�׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEVENT_FLAG = NULL --����Ēʒm�׸�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEVENT_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEVENT_FLAG = :" & Ubound(strBindField) - 1 & " --����Ēʒm�׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEVENT_FLAG = :" & Ubound(strBindField) - 1 & " --����Ēʒm�׸�")
        End If
        intCount = intCount + 1
        If IsNull(mXEVENT_LOG_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEVENT_LOG_KUBUN = NULL --����Ēʒm۸ޏo�͋敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEVENT_LOG_KUBUN = NULL --����Ēʒm۸ޏo�͋敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEVENT_LOG_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEVENT_LOG_KUBUN = :" & Ubound(strBindField) - 1 & " --����Ēʒm۸ޏo�͋敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEVENT_LOG_KUBUN = :" & Ubound(strBindField) - 1 & " --����Ēʒm۸ޏo�͋敪")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_DSP_GROUP_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_DSP_GROUP_KUBUN = NULL --��ٰ�ߐݔ���ԕ\���敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_DSP_GROUP_KUBUN = NULL --��ٰ�ߐݔ���ԕ\���敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_DSP_GROUP_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_DSP_GROUP_KUBUN = :" & Ubound(strBindField) - 1 & " --��ٰ�ߐݔ���ԕ\���敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_DSP_GROUP_KUBUN = :" & Ubound(strBindField) - 1 & " --��ٰ�ߐݔ���ԕ\���敪")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_RPT_KUBUN01) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_RPT_KUBUN01 = NULL --���[�敪01")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_RPT_KUBUN01 = NULL --���[�敪01")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_RPT_KUBUN01
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_RPT_KUBUN01 = :" & Ubound(strBindField) - 1 & " --���[�敪01")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_RPT_KUBUN01 = :" & Ubound(strBindField) - 1 & " --���[�敪01")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ERR_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ERR_KUBUN = NULL --�ݔ��ُ�۸ޏo�͋敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ERR_KUBUN = NULL --�ݔ��ُ�۸ޏo�͋敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ERR_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ERR_KUBUN = :" & Ubound(strBindField) - 1 & " --�ݔ��ُ�۸ޏo�͋敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ERR_KUBUN = :" & Ubound(strBindField) - 1 & " --�ݔ��ُ�۸ޏo�͋敪")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
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
    Public Sub ADD_TSTS_EQ_CTRL()
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
        ElseIf IsNull(mFEQ_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�ݔ�ID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFEQ_KUBUN) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�ݔ��敪]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFEQ_NAME) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�ݔ�����]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFEQ_STS) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�ݔ����]"
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
        strSQL.Append(vbCrLf & "    TSTS_EQ_CTRL")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
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
        If IsNull(mFEQ_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ݔ��敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ݔ��敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ݔ��敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ݔ��敪")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_ID_LOCAL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --۰�ِݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --۰�ِݔ�ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID_LOCAL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --۰�ِݔ�ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --۰�ِݔ�ID")
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
        If IsNull(mFEQ_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ݔ�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ݔ�����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ݔ�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ݔ�����")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_STS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ݔ����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ݔ����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ݔ����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ݔ����")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_STOP_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --��~�v������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --��~�v������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STOP_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --��~�v������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --��~�v������")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_REQ_STS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�v�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�v�����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_REQ_STS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�v�����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�v�����")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_CUT_STS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ؗ����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ؗ����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_CUT_STS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ؗ����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ؗ����")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_CUT_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ؗ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ؗ���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_CUT_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ؗ���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ؗ���")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_PASS_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�����w�������ǉz�׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�����w�������ǉz�׸�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_PASS_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�����w�������ǉz�׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�����w�������ǉz�׸�")
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
        If IsNull(mFEQ_DSP_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --��ʐݔ���ԕ\���敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --��ʐݔ���ԕ\���敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_DSP_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --��ʐݔ���ԕ\���敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --��ʐݔ���ԕ\���敪")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_STOP_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ݔ���~�v���敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ݔ���~�v���敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STOP_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ݔ���~�v���敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ݔ���~�v���敪")
        End If
        intCount = intCount + 1
        If IsNull(mXEVENT_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����Ēʒm�׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����Ēʒm�׸�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEVENT_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����Ēʒm�׸�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����Ēʒm�׸�")
        End If
        intCount = intCount + 1
        If IsNull(mXEVENT_LOG_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����Ēʒm۸ޏo�͋敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����Ēʒm۸ޏo�͋敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEVENT_LOG_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����Ēʒm۸ޏo�͋敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����Ēʒm۸ޏo�͋敪")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_DSP_GROUP_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --��ٰ�ߐݔ���ԕ\���敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --��ٰ�ߐݔ���ԕ\���敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_DSP_GROUP_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --��ٰ�ߐݔ���ԕ\���敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --��ٰ�ߐݔ���ԕ\���敪")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_RPT_KUBUN01) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���[�敪01")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���[�敪01")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_RPT_KUBUN01
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���[�敪01")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���[�敪01")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ERR_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ݔ��ُ�۸ޏo�͋敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ݔ��ُ�۸ޏo�͋敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ERR_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ݔ��ُ�۸ޏo�͋敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ݔ��ُ�۸ޏo�͋敪")
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
    Public Sub DELETE_TSTS_EQ_CTRL()
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
        strSQL.Append(vbCrLf & "    TSTS_EQ_CTRL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
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
    Public Sub DELETE_TSTS_EQ_CTRL_ANY()
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
        strSQL.Append(vbCrLf & "    TSTS_EQ_CTRL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(FEQ_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --�ݔ�ID")
        End If
        If IsNotNull(FEQ_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_KUBUN
            strSQL.Append(vbCrLf & "    AND FEQ_KUBUN = :" & UBound(strBindField) - 1 & " --�ݔ��敪")
        End If
        If IsNotNull(FEQ_ID_LOCAL) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID_LOCAL
            strSQL.Append(vbCrLf & "    AND FEQ_ID_LOCAL = :" & UBound(strBindField) - 1 & " --۰�ِݔ�ID")
        End If
        If IsNotNull(FTRK_BUF_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --�ׯ�ݸ��ޯ̧��")
        End If
        If IsNotNull(FEQ_NAME) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_NAME
            strSQL.Append(vbCrLf & "    AND FEQ_NAME = :" & UBound(strBindField) - 1 & " --�ݔ�����")
        End If
        If IsNotNull(FEQ_STS) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STS
            strSQL.Append(vbCrLf & "    AND FEQ_STS = :" & UBound(strBindField) - 1 & " --�ݔ����")
        End If
        If IsNotNull(FEQ_STOP_CD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STOP_CD
            strSQL.Append(vbCrLf & "    AND FEQ_STOP_CD = :" & UBound(strBindField) - 1 & " --��~�v������")
        End If
        If IsNotNull(FEQ_REQ_STS) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_REQ_STS
            strSQL.Append(vbCrLf & "    AND FEQ_REQ_STS = :" & UBound(strBindField) - 1 & " --�v�����")
        End If
        If IsNotNull(FEQ_CUT_STS) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_CUT_STS
            strSQL.Append(vbCrLf & "    AND FEQ_CUT_STS = :" & UBound(strBindField) - 1 & " --�ؗ����")
        End If
        If IsNotNull(FEQ_CUT_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_CUT_KUBUN
            strSQL.Append(vbCrLf & "    AND FEQ_CUT_KUBUN = :" & UBound(strBindField) - 1 & " --�ؗ���")
        End If
        If IsNotNull(FEQ_PASS_FLAG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_PASS_FLAG
            strSQL.Append(vbCrLf & "    AND FEQ_PASS_FLAG = :" & UBound(strBindField) - 1 & " --�����w�������ǉz�׸�")
        End If
        If IsNotNull(FUPDATE_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --�X�V����")
        End If
        If IsNotNull(FENTRY_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --�o�^����")
        End If
        If IsNotNull(FUSER_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID
            strSQL.Append(vbCrLf & "    AND FUSER_ID = :" & UBound(strBindField) - 1 & " --հ�ްID")
        End If
        If IsNotNull(FCOMMENT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOMMENT
            strSQL.Append(vbCrLf & "    AND FCOMMENT = :" & UBound(strBindField) - 1 & " --����")
        End If
        If IsNotNull(FEQ_DSP_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_DSP_KUBUN
            strSQL.Append(vbCrLf & "    AND FEQ_DSP_KUBUN = :" & UBound(strBindField) - 1 & " --��ʐݔ���ԕ\���敪")
        End If
        If IsNotNull(FEQ_STOP_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STOP_KUBUN
            strSQL.Append(vbCrLf & "    AND FEQ_STOP_KUBUN = :" & UBound(strBindField) - 1 & " --�ݔ���~�v���敪")
        End If
        If IsNotNull(XEVENT_FLAG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEVENT_FLAG
            strSQL.Append(vbCrLf & "    AND XEVENT_FLAG = :" & UBound(strBindField) - 1 & " --����Ēʒm�׸�")
        End If
        If IsNotNull(XEVENT_LOG_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEVENT_LOG_KUBUN
            strSQL.Append(vbCrLf & "    AND XEVENT_LOG_KUBUN = :" & UBound(strBindField) - 1 & " --����Ēʒm۸ޏo�͋敪")
        End If
        If IsNotNull(XEQ_DSP_GROUP_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_DSP_GROUP_KUBUN
            strSQL.Append(vbCrLf & "    AND XEQ_DSP_GROUP_KUBUN = :" & UBound(strBindField) - 1 & " --��ٰ�ߐݔ���ԕ\���敪")
        End If
        If IsNotNull(XEQ_RPT_KUBUN01) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_RPT_KUBUN01
            strSQL.Append(vbCrLf & "    AND XEQ_RPT_KUBUN01 = :" & UBound(strBindField) - 1 & " --���[�敪01")
        End If
        If IsNotNull(XEQ_ERR_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ERR_KUBUN
            strSQL.Append(vbCrLf & "    AND XEQ_ERR_KUBUN = :" & UBound(strBindField) - 1 & " --�ݔ��ُ�۸ޏo�͋敪")
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
        If IsNothing(objType.GetProperty("FEQ_ID")) = False Then mFEQ_ID = objObject.FEQ_ID '�ݔ�ID
        If IsNothing(objType.GetProperty("FEQ_KUBUN")) = False Then mFEQ_KUBUN = objObject.FEQ_KUBUN '�ݔ��敪
        If IsNothing(objType.GetProperty("FEQ_ID_LOCAL")) = False Then mFEQ_ID_LOCAL = objObject.FEQ_ID_LOCAL '۰�ِݔ�ID
        If IsNothing(objType.GetProperty("FTRK_BUF_NO")) = False Then mFTRK_BUF_NO = objObject.FTRK_BUF_NO '�ׯ�ݸ��ޯ̧��
        If IsNothing(objType.GetProperty("FEQ_NAME")) = False Then mFEQ_NAME = objObject.FEQ_NAME '�ݔ�����
        If IsNothing(objType.GetProperty("FEQ_STS")) = False Then mFEQ_STS = objObject.FEQ_STS '�ݔ����
        If IsNothing(objType.GetProperty("FEQ_STOP_CD")) = False Then mFEQ_STOP_CD = objObject.FEQ_STOP_CD '��~�v������
        If IsNothing(objType.GetProperty("FEQ_REQ_STS")) = False Then mFEQ_REQ_STS = objObject.FEQ_REQ_STS '�v�����
        If IsNothing(objType.GetProperty("FEQ_CUT_STS")) = False Then mFEQ_CUT_STS = objObject.FEQ_CUT_STS '�ؗ����
        If IsNothing(objType.GetProperty("FEQ_CUT_KUBUN")) = False Then mFEQ_CUT_KUBUN = objObject.FEQ_CUT_KUBUN '�ؗ���
        If IsNothing(objType.GetProperty("FEQ_PASS_FLAG")) = False Then mFEQ_PASS_FLAG = objObject.FEQ_PASS_FLAG '�����w�������ǉz�׸�
        If IsNothing(objType.GetProperty("FUPDATE_DT")) = False Then mFUPDATE_DT = objObject.FUPDATE_DT '�X�V����
        If IsNothing(objType.GetProperty("FENTRY_DT")) = False Then mFENTRY_DT = objObject.FENTRY_DT '�o�^����
        If IsNothing(objType.GetProperty("FUSER_ID")) = False Then mFUSER_ID = objObject.FUSER_ID 'հ�ްID
        If IsNothing(objType.GetProperty("FCOMMENT")) = False Then mFCOMMENT = objObject.FCOMMENT '����
        If IsNothing(objType.GetProperty("FEQ_DSP_KUBUN")) = False Then mFEQ_DSP_KUBUN = objObject.FEQ_DSP_KUBUN '��ʐݔ���ԕ\���敪
        If IsNothing(objType.GetProperty("FEQ_STOP_KUBUN")) = False Then mFEQ_STOP_KUBUN = objObject.FEQ_STOP_KUBUN '�ݔ���~�v���敪
        If IsNothing(objType.GetProperty("XEVENT_FLAG")) = False Then mXEVENT_FLAG = objObject.XEVENT_FLAG '����Ēʒm�׸�
        If IsNothing(objType.GetProperty("XEVENT_LOG_KUBUN")) = False Then mXEVENT_LOG_KUBUN = objObject.XEVENT_LOG_KUBUN '����Ēʒm۸ޏo�͋敪
        If IsNothing(objType.GetProperty("XEQ_DSP_GROUP_KUBUN")) = False Then mXEQ_DSP_GROUP_KUBUN = objObject.XEQ_DSP_GROUP_KUBUN '��ٰ�ߐݔ���ԕ\���敪
        If IsNothing(objType.GetProperty("XEQ_RPT_KUBUN01")) = False Then mXEQ_RPT_KUBUN01 = objObject.XEQ_RPT_KUBUN01 '���[�敪01
        If IsNothing(objType.GetProperty("XEQ_ERR_KUBUN")) = False Then mXEQ_ERR_KUBUN = objObject.XEQ_ERR_KUBUN '�ݔ��ُ�۸ޏo�͋敪

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
        mFEQ_ID = Nothing
        mFEQ_KUBUN = Nothing
        mFEQ_ID_LOCAL = Nothing
        mFTRK_BUF_NO = Nothing
        mFEQ_NAME = Nothing
        mFEQ_STS = Nothing
        mFEQ_STOP_CD = Nothing
        mFEQ_REQ_STS = Nothing
        mFEQ_CUT_STS = Nothing
        mFEQ_CUT_KUBUN = Nothing
        mFEQ_PASS_FLAG = Nothing
        mFUPDATE_DT = Nothing
        mFENTRY_DT = Nothing
        mFUSER_ID = Nothing
        mFCOMMENT = Nothing
        mFEQ_DSP_KUBUN = Nothing
        mFEQ_STOP_KUBUN = Nothing
        mXEVENT_FLAG = Nothing
        mXEVENT_LOG_KUBUN = Nothing
        mXEQ_DSP_GROUP_KUBUN = Nothing
        mXEQ_RPT_KUBUN01 = Nothing
        mXEQ_ERR_KUBUN = Nothing


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
        mFEQ_ID = TO_STRING_NULLABLE(objRow("FEQ_ID"))
        mFEQ_KUBUN = TO_INTEGER_NULLABLE(objRow("FEQ_KUBUN"))
        mFEQ_ID_LOCAL = TO_STRING_NULLABLE(objRow("FEQ_ID_LOCAL"))
        mFTRK_BUF_NO = TO_INTEGER_NULLABLE(objRow("FTRK_BUF_NO"))
        mFEQ_NAME = TO_STRING_NULLABLE(objRow("FEQ_NAME"))
        mFEQ_STS = TO_STRING_NULLABLE(objRow("FEQ_STS"))
        mFEQ_STOP_CD = TO_STRING_NULLABLE(objRow("FEQ_STOP_CD"))
        mFEQ_REQ_STS = TO_INTEGER_NULLABLE(objRow("FEQ_REQ_STS"))
        mFEQ_CUT_STS = TO_INTEGER_NULLABLE(objRow("FEQ_CUT_STS"))
        mFEQ_CUT_KUBUN = TO_INTEGER_NULLABLE(objRow("FEQ_CUT_KUBUN"))
        mFEQ_PASS_FLAG = TO_INTEGER_NULLABLE(objRow("FEQ_PASS_FLAG"))
        mFUPDATE_DT = TO_DATE_NULLABLE(objRow("FUPDATE_DT"))
        mFENTRY_DT = TO_DATE_NULLABLE(objRow("FENTRY_DT"))
        mFUSER_ID = TO_STRING_NULLABLE(objRow("FUSER_ID"))
        mFCOMMENT = TO_STRING_NULLABLE(objRow("FCOMMENT"))
        mFEQ_DSP_KUBUN = TO_INTEGER_NULLABLE(objRow("FEQ_DSP_KUBUN"))
        mFEQ_STOP_KUBUN = TO_INTEGER_NULLABLE(objRow("FEQ_STOP_KUBUN"))
        mXEVENT_FLAG = TO_INTEGER_NULLABLE(objRow("XEVENT_FLAG"))
        mXEVENT_LOG_KUBUN = TO_INTEGER_NULLABLE(objRow("XEVENT_LOG_KUBUN"))
        mXEQ_DSP_GROUP_KUBUN = TO_INTEGER_NULLABLE(objRow("XEQ_DSP_GROUP_KUBUN"))
        mXEQ_RPT_KUBUN01 = TO_INTEGER_NULLABLE(objRow("XEQ_RPT_KUBUN01"))
        mXEQ_ERR_KUBUN = TO_INTEGER_NULLABLE(objRow("XEQ_ERR_KUBUN"))


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
        strMsg &= "[ð��ٖ�:�ݔ���]"
        If IsNotNull(FEQ_ID) Then
            strMsg &= "[�ݔ�ID:" & FEQ_ID & "]"
        End If
        If IsNotNull(FEQ_KUBUN) Then
            strMsg &= "[�ݔ��敪:" & FEQ_KUBUN & "]"
        End If
        If IsNotNull(FEQ_ID_LOCAL) Then
            strMsg &= "[۰�ِݔ�ID:" & FEQ_ID_LOCAL & "]"
        End If
        If IsNotNull(FTRK_BUF_NO) Then
            strMsg &= "[�ׯ�ݸ��ޯ̧��:" & FTRK_BUF_NO & "]"
        End If
        If IsNotNull(FEQ_NAME) Then
            strMsg &= "[�ݔ�����:" & FEQ_NAME & "]"
        End If
        If IsNotNull(FEQ_STS) Then
            strMsg &= "[�ݔ����:" & FEQ_STS & "]"
        End If
        If IsNotNull(FEQ_STOP_CD) Then
            strMsg &= "[��~�v������:" & FEQ_STOP_CD & "]"
        End If
        If IsNotNull(FEQ_REQ_STS) Then
            strMsg &= "[�v�����:" & FEQ_REQ_STS & "]"
        End If
        If IsNotNull(FEQ_CUT_STS) Then
            strMsg &= "[�ؗ����:" & FEQ_CUT_STS & "]"
        End If
        If IsNotNull(FEQ_CUT_KUBUN) Then
            strMsg &= "[�ؗ���:" & FEQ_CUT_KUBUN & "]"
        End If
        If IsNotNull(FEQ_PASS_FLAG) Then
            strMsg &= "[�����w�������ǉz�׸�:" & FEQ_PASS_FLAG & "]"
        End If
        If IsNotNull(FUPDATE_DT) Then
            strMsg &= "[�X�V����:" & FUPDATE_DT & "]"
        End If
        If IsNotNull(FENTRY_DT) Then
            strMsg &= "[�o�^����:" & FENTRY_DT & "]"
        End If
        If IsNotNull(FUSER_ID) Then
            strMsg &= "[հ�ްID:" & FUSER_ID & "]"
        End If
        If IsNotNull(FCOMMENT) Then
            strMsg &= "[����:" & FCOMMENT & "]"
        End If
        If IsNotNull(FEQ_DSP_KUBUN) Then
            strMsg &= "[��ʐݔ���ԕ\���敪:" & FEQ_DSP_KUBUN & "]"
        End If
        If IsNotNull(FEQ_STOP_KUBUN) Then
            strMsg &= "[�ݔ���~�v���敪:" & FEQ_STOP_KUBUN & "]"
        End If
        If IsNotNull(XEVENT_FLAG) Then
            strMsg &= "[����Ēʒm�׸�:" & XEVENT_FLAG & "]"
        End If
        If IsNotNull(XEVENT_LOG_KUBUN) Then
            strMsg &= "[����Ēʒm۸ޏo�͋敪:" & XEVENT_LOG_KUBUN & "]"
        End If
        If IsNotNull(XEQ_DSP_GROUP_KUBUN) Then
            strMsg &= "[��ٰ�ߐݔ���ԕ\���敪:" & XEQ_DSP_GROUP_KUBUN & "]"
        End If
        If IsNotNull(XEQ_RPT_KUBUN01) Then
            strMsg &= "[���[�敪01:" & XEQ_RPT_KUBUN01 & "]"
        End If
        If IsNotNull(XEQ_ERR_KUBUN) Then
            strMsg &= "[�ݔ��ُ�۸ޏo�͋敪:" & XEQ_ERR_KUBUN & "]"
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
