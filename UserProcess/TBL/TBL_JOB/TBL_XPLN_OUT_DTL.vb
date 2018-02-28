'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' �y���́zMaterialStreamð��ٸ׽
' �y�@�\�z�o�׎w���ڍ�ð��ٸ׽
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
''' �o�׎w���ڍ�ð��ٸ׽
''' </summary>
Public Class TBL_XPLN_OUT_DTL
    Inherits clsTemplateTable

    '**********************************************************************************************
    '����������������
#Region "  �׽�ϐ���`                  "
    '�����è
    Private mobjAryMe As TBL_XPLN_OUT_DTL()                                      '�o�׎w���ڍ�
    Private mstrUSER_SQL As String                                               'հ�ްSQL
    Private mORDER_BY As String                                                  'OrderBy��
    Private mWHERE As String                                                     'Where��
    Private mXSYUKKA_D As Nullable(Of Date)                                      '�o�ד�
    Private mXHENSEI_NO As String                                                '�Ґ�No.
    Private mFHINMEI_CD As String                                                '�i�ں���
    Private mFSAGYOU_KIND As Nullable(Of Integer)                                '��Ǝ��
    Private mFPLAN_KEY As String                                                 '�v�淰
    Private mXOUT_ORDER As Nullable(Of Integer)                                  '���q���o�וi�ڏ�
    Private mXSYUKKA_KON_PLAN As Nullable(Of Integer)                            '�o�ח\�荫��
    Private mXSYUKKA_KON_RESERVE As Nullable(Of Integer)                         '�o�׈�������
    Private mXSYUKKA_KON_RESULT As Nullable(Of Integer)                          '�o�׎��э���
    Private mXSYUKKA_KON_H_RESULT As Nullable(Of Integer)                        '�o�׎��э���(���u)
    Private mXSAIMOKU As String                                                  '����敪�ז�
    Private mFZAIKO_KUBUN As Nullable(Of Integer)                                '�݌ɋ敪
    Private mXIDOU_KBN As String                                                 '�ړ��敪
    Private mXHENSEI_NO_OYA As String                                            '�e�Ґ�No.
    Private mXTORIKIRI As Nullable(Of Integer)                                   '���؂�w��
    Private mXOUT_START_DT As Nullable(Of Date)                                  '�o�ɊJ�n����
    Private mXOUT_END_DT As Nullable(Of Date)                                    '�o�Ɋ�������
    Private mXSYUKKA_STS_DTL As Nullable(Of Integer)                             '�o�׏󋵏ڍ�
    Private mXDENPYOU_NO As String                                               '�`�[No.
#End Region
#Region "  �����è��`                  "
    ''' <summary>
    ''' ���ѕϐ� (���׽�^�z��)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_XPLN_OUT_DTL()
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
    ''' <summary>
    ''' ���q���o�וi�ڏ�
    ''' </summary>
    Public Property XOUT_ORDER() As Nullable(Of Integer)
        Get
            Return mXOUT_ORDER
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXOUT_ORDER = Value
        End Set
    End Property
    ''' <summary>
    ''' �o�ח\�荫��
    ''' </summary>
    Public Property XSYUKKA_KON_PLAN() As Nullable(Of Integer)
        Get
            Return mXSYUKKA_KON_PLAN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXSYUKKA_KON_PLAN = Value
        End Set
    End Property
    ''' <summary>
    ''' �o�׈�������
    ''' </summary>
    Public Property XSYUKKA_KON_RESERVE() As Nullable(Of Integer)
        Get
            Return mXSYUKKA_KON_RESERVE
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXSYUKKA_KON_RESERVE = Value
        End Set
    End Property
    ''' <summary>
    ''' �o�׎��э���
    ''' </summary>
    Public Property XSYUKKA_KON_RESULT() As Nullable(Of Integer)
        Get
            Return mXSYUKKA_KON_RESULT
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXSYUKKA_KON_RESULT = Value
        End Set
    End Property
    ''' <summary>
    ''' �o�׎��э���(���u)
    ''' </summary>
    Public Property XSYUKKA_KON_H_RESULT() As Nullable(Of Integer)
        Get
            Return mXSYUKKA_KON_H_RESULT
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXSYUKKA_KON_H_RESULT = Value
        End Set
    End Property
    ''' <summary>
    ''' ����敪�ז�
    ''' </summary>
    Public Property XSAIMOKU() As String
        Get
            Return mXSAIMOKU
        End Get
        Set(ByVal Value As String)
            mXSAIMOKU = Value
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
    ''' �ړ��敪
    ''' </summary>
    Public Property XIDOU_KBN() As String
        Get
            Return mXIDOU_KBN
        End Get
        Set(ByVal Value As String)
            mXIDOU_KBN = Value
        End Set
    End Property
    ''' <summary>
    ''' �e�Ґ�No.
    ''' </summary>
    Public Property XHENSEI_NO_OYA() As String
        Get
            Return mXHENSEI_NO_OYA
        End Get
        Set(ByVal Value As String)
            mXHENSEI_NO_OYA = Value
        End Set
    End Property
    ''' <summary>
    ''' ���؂�w��
    ''' </summary>
    Public Property XTORIKIRI() As Nullable(Of Integer)
        Get
            Return mXTORIKIRI
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXTORIKIRI = Value
        End Set
    End Property
    ''' <summary>
    ''' �o�ɊJ�n����
    ''' </summary>
    Public Property XOUT_START_DT() As Nullable(Of Date)
        Get
            Return mXOUT_START_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mXOUT_START_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' �o�Ɋ�������
    ''' </summary>
    Public Property XOUT_END_DT() As Nullable(Of Date)
        Get
            Return mXOUT_END_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mXOUT_END_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' �o�׏󋵏ڍ�
    ''' </summary>
    Public Property XSYUKKA_STS_DTL() As Nullable(Of Integer)
        Get
            Return mXSYUKKA_STS_DTL
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXSYUKKA_STS_DTL = Value
        End Set
    End Property
    ''' <summary>
    ''' �`�[No.
    ''' </summary>
    Public Property XDENPYOU_NO() As String
        Get
            Return mXDENPYOU_NO
        End Get
        Set(ByVal Value As String)
            mXDENPYOU_NO = Value
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
    Public Function GET_XPLN_OUT_DTL(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    XPLN_OUT_DTL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
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
        If IsNull(FHINMEI_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --�i�ں���")
        End If
        If IsNull(FSAGYOU_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_KIND
            strSQL.Append(vbCrLf & "    AND FSAGYOU_KIND = :" & UBound(strBindField) - 1 & " --��Ǝ��")
        End If
        If IsNull(FPLAN_KEY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLAN_KEY
            strSQL.Append(vbCrLf & "    AND FPLAN_KEY = :" & UBound(strBindField) - 1 & " --�v�淰")
        End If
        If IsNull(XOUT_ORDER) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_ORDER
            strSQL.Append(vbCrLf & "    AND XOUT_ORDER = :" & UBound(strBindField) - 1 & " --���q���o�וi�ڏ�")
        End If
        If IsNull(XSYUKKA_KON_PLAN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_PLAN
            strSQL.Append(vbCrLf & "    AND XSYUKKA_KON_PLAN = :" & UBound(strBindField) - 1 & " --�o�ח\�荫��")
        End If
        If IsNull(XSYUKKA_KON_RESERVE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_RESERVE
            strSQL.Append(vbCrLf & "    AND XSYUKKA_KON_RESERVE = :" & UBound(strBindField) - 1 & " --�o�׈�������")
        End If
        If IsNull(XSYUKKA_KON_RESULT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_RESULT
            strSQL.Append(vbCrLf & "    AND XSYUKKA_KON_RESULT = :" & UBound(strBindField) - 1 & " --�o�׎��э���")
        End If
        If IsNull(XSYUKKA_KON_H_RESULT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_H_RESULT
            strSQL.Append(vbCrLf & "    AND XSYUKKA_KON_H_RESULT = :" & UBound(strBindField) - 1 & " --�o�׎��э���(���u)")
        End If
        If IsNull(XSAIMOKU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSAIMOKU
            strSQL.Append(vbCrLf & "    AND XSAIMOKU = :" & UBound(strBindField) - 1 & " --����敪�ז�")
        End If
        If IsNull(FZAIKO_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_KUBUN
            strSQL.Append(vbCrLf & "    AND FZAIKO_KUBUN = :" & UBound(strBindField) - 1 & " --�݌ɋ敪")
        End If
        If IsNull(XIDOU_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIDOU_KBN
            strSQL.Append(vbCrLf & "    AND XIDOU_KBN = :" & UBound(strBindField) - 1 & " --�ړ��敪")
        End If
        If IsNull(XHENSEI_NO_OYA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO_OYA = :" & UBound(strBindField) - 1 & " --�e�Ґ�No.")
        End If
        If IsNull(XTORIKIRI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTORIKIRI
            strSQL.Append(vbCrLf & "    AND XTORIKIRI = :" & UBound(strBindField) - 1 & " --���؂�w��")
        End If
        If IsNull(XOUT_START_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_START_DT
            strSQL.Append(vbCrLf & "    AND XOUT_START_DT = :" & UBound(strBindField) - 1 & " --�o�ɊJ�n����")
        End If
        If IsNull(XOUT_END_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_END_DT
            strSQL.Append(vbCrLf & "    AND XOUT_END_DT = :" & UBound(strBindField) - 1 & " --�o�Ɋ�������")
        End If
        If IsNull(XSYUKKA_STS_DTL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_STS_DTL
            strSQL.Append(vbCrLf & "    AND XSYUKKA_STS_DTL = :" & UBound(strBindField) - 1 & " --�o�׏󋵏ڍ�")
        End If
        If IsNull(XDENPYOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDENPYOU_NO
            strSQL.Append(vbCrLf & "    AND XDENPYOU_NO = :" & UBound(strBindField) - 1 & " --�`�[No.")
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
        strDataSetName = "XPLN_OUT_DTL"
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
    Public Function GET_XPLN_OUT_DTL_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    XPLN_OUT_DTL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
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
        If IsNull(FHINMEI_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --�i�ں���")
        End If
        If IsNull(FSAGYOU_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_KIND
            strSQL.Append(vbCrLf & "    AND FSAGYOU_KIND = :" & UBound(strBindField) - 1 & " --��Ǝ��")
        End If
        If IsNull(FPLAN_KEY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLAN_KEY
            strSQL.Append(vbCrLf & "    AND FPLAN_KEY = :" & UBound(strBindField) - 1 & " --�v�淰")
        End If
        If IsNull(XOUT_ORDER) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_ORDER
            strSQL.Append(vbCrLf & "    AND XOUT_ORDER = :" & UBound(strBindField) - 1 & " --���q���o�וi�ڏ�")
        End If
        If IsNull(XSYUKKA_KON_PLAN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_PLAN
            strSQL.Append(vbCrLf & "    AND XSYUKKA_KON_PLAN = :" & UBound(strBindField) - 1 & " --�o�ח\�荫��")
        End If
        If IsNull(XSYUKKA_KON_RESERVE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_RESERVE
            strSQL.Append(vbCrLf & "    AND XSYUKKA_KON_RESERVE = :" & UBound(strBindField) - 1 & " --�o�׈�������")
        End If
        If IsNull(XSYUKKA_KON_RESULT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_RESULT
            strSQL.Append(vbCrLf & "    AND XSYUKKA_KON_RESULT = :" & UBound(strBindField) - 1 & " --�o�׎��э���")
        End If
        If IsNull(XSYUKKA_KON_H_RESULT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_H_RESULT
            strSQL.Append(vbCrLf & "    AND XSYUKKA_KON_H_RESULT = :" & UBound(strBindField) - 1 & " --�o�׎��э���(���u)")
        End If
        If IsNull(XSAIMOKU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSAIMOKU
            strSQL.Append(vbCrLf & "    AND XSAIMOKU = :" & UBound(strBindField) - 1 & " --����敪�ז�")
        End If
        If IsNull(FZAIKO_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_KUBUN
            strSQL.Append(vbCrLf & "    AND FZAIKO_KUBUN = :" & UBound(strBindField) - 1 & " --�݌ɋ敪")
        End If
        If IsNull(XIDOU_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIDOU_KBN
            strSQL.Append(vbCrLf & "    AND XIDOU_KBN = :" & UBound(strBindField) - 1 & " --�ړ��敪")
        End If
        If IsNull(XHENSEI_NO_OYA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO_OYA = :" & UBound(strBindField) - 1 & " --�e�Ґ�No.")
        End If
        If IsNull(XTORIKIRI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTORIKIRI
            strSQL.Append(vbCrLf & "    AND XTORIKIRI = :" & UBound(strBindField) - 1 & " --���؂�w��")
        End If
        If IsNull(XOUT_START_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_START_DT
            strSQL.Append(vbCrLf & "    AND XOUT_START_DT = :" & UBound(strBindField) - 1 & " --�o�ɊJ�n����")
        End If
        If IsNull(XOUT_END_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_END_DT
            strSQL.Append(vbCrLf & "    AND XOUT_END_DT = :" & UBound(strBindField) - 1 & " --�o�Ɋ�������")
        End If
        If IsNull(XSYUKKA_STS_DTL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_STS_DTL
            strSQL.Append(vbCrLf & "    AND XSYUKKA_STS_DTL = :" & UBound(strBindField) - 1 & " --�o�׏󋵏ڍ�")
        End If
        If IsNull(XDENPYOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDENPYOU_NO
            strSQL.Append(vbCrLf & "    AND XDENPYOU_NO = :" & UBound(strBindField) - 1 & " --�`�[No.")
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
        strDataSetName = "XPLN_OUT_DTL"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XPLN_OUT_DTL(Owner, objDb, objDbLog)
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
    Public Function GET_XPLN_OUT_DTL_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "XPLN_OUT_DTL"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XPLN_OUT_DTL(Owner, objDb, objDbLog)
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
    Public Function GET_XPLN_OUT_DTL_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    XPLN_OUT_DTL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
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
        If IsNull(FHINMEI_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --�i�ں���")
        End If
        If IsNull(FSAGYOU_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_KIND
            strSQL.Append(vbCrLf & "    AND FSAGYOU_KIND = :" & UBound(strBindField) - 1 & " --��Ǝ��")
        End If
        If IsNull(FPLAN_KEY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLAN_KEY
            strSQL.Append(vbCrLf & "    AND FPLAN_KEY = :" & UBound(strBindField) - 1 & " --�v�淰")
        End If
        If IsNull(XOUT_ORDER) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_ORDER
            strSQL.Append(vbCrLf & "    AND XOUT_ORDER = :" & UBound(strBindField) - 1 & " --���q���o�וi�ڏ�")
        End If
        If IsNull(XSYUKKA_KON_PLAN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_PLAN
            strSQL.Append(vbCrLf & "    AND XSYUKKA_KON_PLAN = :" & UBound(strBindField) - 1 & " --�o�ח\�荫��")
        End If
        If IsNull(XSYUKKA_KON_RESERVE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_RESERVE
            strSQL.Append(vbCrLf & "    AND XSYUKKA_KON_RESERVE = :" & UBound(strBindField) - 1 & " --�o�׈�������")
        End If
        If IsNull(XSYUKKA_KON_RESULT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_RESULT
            strSQL.Append(vbCrLf & "    AND XSYUKKA_KON_RESULT = :" & UBound(strBindField) - 1 & " --�o�׎��э���")
        End If
        If IsNull(XSYUKKA_KON_H_RESULT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_H_RESULT
            strSQL.Append(vbCrLf & "    AND XSYUKKA_KON_H_RESULT = :" & UBound(strBindField) - 1 & " --�o�׎��э���(���u)")
        End If
        If IsNull(XSAIMOKU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSAIMOKU
            strSQL.Append(vbCrLf & "    AND XSAIMOKU = :" & UBound(strBindField) - 1 & " --����敪�ז�")
        End If
        If IsNull(FZAIKO_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_KUBUN
            strSQL.Append(vbCrLf & "    AND FZAIKO_KUBUN = :" & UBound(strBindField) - 1 & " --�݌ɋ敪")
        End If
        If IsNull(XIDOU_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIDOU_KBN
            strSQL.Append(vbCrLf & "    AND XIDOU_KBN = :" & UBound(strBindField) - 1 & " --�ړ��敪")
        End If
        If IsNull(XHENSEI_NO_OYA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO_OYA = :" & UBound(strBindField) - 1 & " --�e�Ґ�No.")
        End If
        If IsNull(XTORIKIRI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTORIKIRI
            strSQL.Append(vbCrLf & "    AND XTORIKIRI = :" & UBound(strBindField) - 1 & " --���؂�w��")
        End If
        If IsNull(XOUT_START_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_START_DT
            strSQL.Append(vbCrLf & "    AND XOUT_START_DT = :" & UBound(strBindField) - 1 & " --�o�ɊJ�n����")
        End If
        If IsNull(XOUT_END_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_END_DT
            strSQL.Append(vbCrLf & "    AND XOUT_END_DT = :" & UBound(strBindField) - 1 & " --�o�Ɋ�������")
        End If
        If IsNull(XSYUKKA_STS_DTL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_STS_DTL
            strSQL.Append(vbCrLf & "    AND XSYUKKA_STS_DTL = :" & UBound(strBindField) - 1 & " --�o�׏󋵏ڍ�")
        End If
        If IsNull(XDENPYOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDENPYOU_NO
            strSQL.Append(vbCrLf & "    AND XDENPYOU_NO = :" & UBound(strBindField) - 1 & " --�`�[No.")
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
        strDataSetName = "XPLN_OUT_DTL"
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
    Public Sub UPDATE_XPLN_OUT_DTL()
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
        ElseIf IsNull(mXSYUKKA_D) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�o�ד�]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mXHENSEI_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�Ґ�No.]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFHINMEI_CD) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�i�ں���]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mXDENPYOU_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�`�[No.]"
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
        strSQL.Append(vbCrLf & "    XPLN_OUT_DTL")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
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
        If IsNull(mXOUT_ORDER) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XOUT_ORDER = NULL --���q���o�וi�ڏ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XOUT_ORDER = NULL --���q���o�וi�ڏ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_ORDER
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XOUT_ORDER = :" & Ubound(strBindField) - 1 & " --���q���o�וi�ڏ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XOUT_ORDER = :" & Ubound(strBindField) - 1 & " --���q���o�וi�ڏ�")
        End If
        intCount = intCount + 1
        If IsNull(mXSYUKKA_KON_PLAN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_KON_PLAN = NULL --�o�ח\�荫��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_KON_PLAN = NULL --�o�ח\�荫��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_PLAN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_KON_PLAN = :" & Ubound(strBindField) - 1 & " --�o�ח\�荫��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_KON_PLAN = :" & Ubound(strBindField) - 1 & " --�o�ח\�荫��")
        End If
        intCount = intCount + 1
        If IsNull(mXSYUKKA_KON_RESERVE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_KON_RESERVE = NULL --�o�׈�������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_KON_RESERVE = NULL --�o�׈�������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_RESERVE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_KON_RESERVE = :" & Ubound(strBindField) - 1 & " --�o�׈�������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_KON_RESERVE = :" & Ubound(strBindField) - 1 & " --�o�׈�������")
        End If
        intCount = intCount + 1
        If IsNull(mXSYUKKA_KON_RESULT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_KON_RESULT = NULL --�o�׎��э���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_KON_RESULT = NULL --�o�׎��э���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_RESULT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_KON_RESULT = :" & Ubound(strBindField) - 1 & " --�o�׎��э���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_KON_RESULT = :" & Ubound(strBindField) - 1 & " --�o�׎��э���")
        End If
        intCount = intCount + 1
        If IsNull(mXSYUKKA_KON_H_RESULT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_KON_H_RESULT = NULL --�o�׎��э���(���u)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_KON_H_RESULT = NULL --�o�׎��э���(���u)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_H_RESULT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_KON_H_RESULT = :" & Ubound(strBindField) - 1 & " --�o�׎��э���(���u)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_KON_H_RESULT = :" & Ubound(strBindField) - 1 & " --�o�׎��э���(���u)")
        End If
        intCount = intCount + 1
        If IsNull(mXSAIMOKU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSAIMOKU = NULL --����敪�ז�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSAIMOKU = NULL --����敪�ז�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSAIMOKU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSAIMOKU = :" & Ubound(strBindField) - 1 & " --����敪�ז�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSAIMOKU = :" & Ubound(strBindField) - 1 & " --����敪�ז�")
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
        If IsNull(mXIDOU_KBN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XIDOU_KBN = NULL --�ړ��敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XIDOU_KBN = NULL --�ړ��敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIDOU_KBN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XIDOU_KBN = :" & Ubound(strBindField) - 1 & " --�ړ��敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XIDOU_KBN = :" & Ubound(strBindField) - 1 & " --�ړ��敪")
        End If
        intCount = intCount + 1
        If IsNull(mXHENSEI_NO_OYA) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XHENSEI_NO_OYA = NULL --�e�Ґ�No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XHENSEI_NO_OYA = NULL --�e�Ґ�No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XHENSEI_NO_OYA = :" & Ubound(strBindField) - 1 & " --�e�Ґ�No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XHENSEI_NO_OYA = :" & Ubound(strBindField) - 1 & " --�e�Ґ�No.")
        End If
        intCount = intCount + 1
        If IsNull(mXTORIKIRI) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTORIKIRI = NULL --���؂�w��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTORIKIRI = NULL --���؂�w��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTORIKIRI
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTORIKIRI = :" & Ubound(strBindField) - 1 & " --���؂�w��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTORIKIRI = :" & Ubound(strBindField) - 1 & " --���؂�w��")
        End If
        intCount = intCount + 1
        If IsNull(mXOUT_START_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XOUT_START_DT = NULL --�o�ɊJ�n����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XOUT_START_DT = NULL --�o�ɊJ�n����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_START_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XOUT_START_DT = :" & Ubound(strBindField) - 1 & " --�o�ɊJ�n����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XOUT_START_DT = :" & Ubound(strBindField) - 1 & " --�o�ɊJ�n����")
        End If
        intCount = intCount + 1
        If IsNull(mXOUT_END_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XOUT_END_DT = NULL --�o�Ɋ�������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XOUT_END_DT = NULL --�o�Ɋ�������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_END_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XOUT_END_DT = :" & Ubound(strBindField) - 1 & " --�o�Ɋ�������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XOUT_END_DT = :" & Ubound(strBindField) - 1 & " --�o�Ɋ�������")
        End If
        intCount = intCount + 1
        If IsNull(mXSYUKKA_STS_DTL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_STS_DTL = NULL --�o�׏󋵏ڍ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_STS_DTL = NULL --�o�׏󋵏ڍ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_STS_DTL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_STS_DTL = :" & Ubound(strBindField) - 1 & " --�o�׏󋵏ڍ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_STS_DTL = :" & Ubound(strBindField) - 1 & " --�o�׏󋵏ڍ�")
        End If
        intCount = intCount + 1
        If IsNull(mXDENPYOU_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDENPYOU_NO = NULL --�`�[No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDENPYOU_NO = NULL --�`�[No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDENPYOU_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDENPYOU_NO = :" & Ubound(strBindField) - 1 & " --�`�[No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDENPYOU_NO = :" & Ubound(strBindField) - 1 & " --�`�[No.")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(XSYUKKA_D) = True Then
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D IS NULL --�o�ד�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D = :" & UBound(strBindField) - 1 & " --�o�ד�")
        End If
        If IsNull(XHENSEI_NO) = True Then
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO IS NULL --�Ґ�No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO = :" & UBound(strBindField) - 1 & " --�Ґ�No.")
        End If
        If IsNull(FHINMEI_CD) = True Then
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD IS NULL --�i�ں���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --�i�ں���")
        End If
        If IsNull(XDENPYOU_NO) = True Then
            strSQL.Append(vbCrLf & "    AND XDENPYOU_NO IS NULL --�`�[No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDENPYOU_NO
            strSQL.Append(vbCrLf & "    AND XDENPYOU_NO = :" & UBound(strBindField) - 1 & " --�`�[No.")
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
    Public Sub ADD_XPLN_OUT_DTL()
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
        ElseIf IsNull(mXSYUKKA_D) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�o�ד�]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mXHENSEI_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�Ґ�No.]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFHINMEI_CD) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�i�ں���]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mXDENPYOU_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�`�[No.]"
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
        strSQL.Append(vbCrLf & "    XPLN_OUT_DTL")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
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
        If IsNull(mXOUT_ORDER) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���q���o�וi�ڏ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���q���o�וi�ڏ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_ORDER
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���q���o�וi�ڏ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���q���o�וi�ڏ�")
        End If
        intCount = intCount + 1
        If IsNull(mXSYUKKA_KON_PLAN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�o�ח\�荫��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�o�ח\�荫��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_PLAN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�o�ח\�荫��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�o�ח\�荫��")
        End If
        intCount = intCount + 1
        If IsNull(mXSYUKKA_KON_RESERVE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�o�׈�������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�o�׈�������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_RESERVE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�o�׈�������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�o�׈�������")
        End If
        intCount = intCount + 1
        If IsNull(mXSYUKKA_KON_RESULT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�o�׎��э���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�o�׎��э���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_RESULT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�o�׎��э���")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�o�׎��э���")
        End If
        intCount = intCount + 1
        If IsNull(mXSYUKKA_KON_H_RESULT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�o�׎��э���(���u)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�o�׎��э���(���u)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_H_RESULT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�o�׎��э���(���u)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�o�׎��э���(���u)")
        End If
        intCount = intCount + 1
        If IsNull(mXSAIMOKU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����敪�ז�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����敪�ז�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSAIMOKU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����敪�ז�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����敪�ז�")
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
        If IsNull(mXIDOU_KBN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�ړ��敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�ړ��敪")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIDOU_KBN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�ړ��敪")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�ړ��敪")
        End If
        intCount = intCount + 1
        If IsNull(mXHENSEI_NO_OYA) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�e�Ґ�No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�e�Ґ�No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�e�Ґ�No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�e�Ґ�No.")
        End If
        intCount = intCount + 1
        If IsNull(mXTORIKIRI) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --���؂�w��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --���؂�w��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTORIKIRI
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --���؂�w��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --���؂�w��")
        End If
        intCount = intCount + 1
        If IsNull(mXOUT_START_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�o�ɊJ�n����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�o�ɊJ�n����")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_START_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�o�ɊJ�n����")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�o�ɊJ�n����")
        End If
        intCount = intCount + 1
        If IsNull(mXOUT_END_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�o�Ɋ�������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�o�Ɋ�������")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_END_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�o�Ɋ�������")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�o�Ɋ�������")
        End If
        intCount = intCount + 1
        If IsNull(mXSYUKKA_STS_DTL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�o�׏󋵏ڍ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�o�׏󋵏ڍ�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_STS_DTL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�o�׏󋵏ڍ�")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�o�׏󋵏ڍ�")
        End If
        intCount = intCount + 1
        If IsNull(mXDENPYOU_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�`�[No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�`�[No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDENPYOU_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�`�[No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�`�[No.")
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
    Public Sub DELETE_XPLN_OUT_DTL()
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
        ElseIf IsNull(mXSYUKKA_D) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�o�ד�]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mXHENSEI_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�Ґ�No.]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFHINMEI_CD) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�i�ں���]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mXDENPYOU_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[�`�[No.]"
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
        strSQL.Append(vbCrLf & "    XPLN_OUT_DTL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(XSYUKKA_D) = True Then
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D IS NULL --�o�ד�")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D = :" & UBound(strBindField) - 1 & " --�o�ד�")
        End If
        If IsNull(XHENSEI_NO) = True Then
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO IS NULL --�Ґ�No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO = :" & UBound(strBindField) - 1 & " --�Ґ�No.")
        End If
        If IsNull(FHINMEI_CD) = True Then
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD IS NULL --�i�ں���")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --�i�ں���")
        End If
        If IsNull(XDENPYOU_NO) = True Then
            strSQL.Append(vbCrLf & "    AND XDENPYOU_NO IS NULL --�`�[No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDENPYOU_NO
            strSQL.Append(vbCrLf & "    AND XDENPYOU_NO = :" & UBound(strBindField) - 1 & " --�`�[No.")
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
    Public Sub DELETE_XPLN_OUT_DTL_ANY()
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
        strSQL.Append(vbCrLf & "    XPLN_OUT_DTL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
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
        If IsNotNull(FHINMEI_CD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --�i�ں���")
        End If
        If IsNotNull(FSAGYOU_KIND) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_KIND
            strSQL.Append(vbCrLf & "    AND FSAGYOU_KIND = :" & UBound(strBindField) - 1 & " --��Ǝ��")
        End If
        If IsNotNull(FPLAN_KEY) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLAN_KEY
            strSQL.Append(vbCrLf & "    AND FPLAN_KEY = :" & UBound(strBindField) - 1 & " --�v�淰")
        End If
        If IsNotNull(XOUT_ORDER) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_ORDER
            strSQL.Append(vbCrLf & "    AND XOUT_ORDER = :" & UBound(strBindField) - 1 & " --���q���o�וi�ڏ�")
        End If
        If IsNotNull(XSYUKKA_KON_PLAN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_PLAN
            strSQL.Append(vbCrLf & "    AND XSYUKKA_KON_PLAN = :" & UBound(strBindField) - 1 & " --�o�ח\�荫��")
        End If
        If IsNotNull(XSYUKKA_KON_RESERVE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_RESERVE
            strSQL.Append(vbCrLf & "    AND XSYUKKA_KON_RESERVE = :" & UBound(strBindField) - 1 & " --�o�׈�������")
        End If
        If IsNotNull(XSYUKKA_KON_RESULT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_RESULT
            strSQL.Append(vbCrLf & "    AND XSYUKKA_KON_RESULT = :" & UBound(strBindField) - 1 & " --�o�׎��э���")
        End If
        If IsNotNull(XSYUKKA_KON_H_RESULT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_KON_H_RESULT
            strSQL.Append(vbCrLf & "    AND XSYUKKA_KON_H_RESULT = :" & UBound(strBindField) - 1 & " --�o�׎��э���(���u)")
        End If
        If IsNotNull(XSAIMOKU) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSAIMOKU
            strSQL.Append(vbCrLf & "    AND XSAIMOKU = :" & UBound(strBindField) - 1 & " --����敪�ז�")
        End If
        If IsNotNull(FZAIKO_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_KUBUN
            strSQL.Append(vbCrLf & "    AND FZAIKO_KUBUN = :" & UBound(strBindField) - 1 & " --�݌ɋ敪")
        End If
        If IsNotNull(XIDOU_KBN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIDOU_KBN
            strSQL.Append(vbCrLf & "    AND XIDOU_KBN = :" & UBound(strBindField) - 1 & " --�ړ��敪")
        End If
        If IsNotNull(XHENSEI_NO_OYA) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO_OYA = :" & UBound(strBindField) - 1 & " --�e�Ґ�No.")
        End If
        If IsNotNull(XTORIKIRI) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTORIKIRI
            strSQL.Append(vbCrLf & "    AND XTORIKIRI = :" & UBound(strBindField) - 1 & " --���؂�w��")
        End If
        If IsNotNull(XOUT_START_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_START_DT
            strSQL.Append(vbCrLf & "    AND XOUT_START_DT = :" & UBound(strBindField) - 1 & " --�o�ɊJ�n����")
        End If
        If IsNotNull(XOUT_END_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_END_DT
            strSQL.Append(vbCrLf & "    AND XOUT_END_DT = :" & UBound(strBindField) - 1 & " --�o�Ɋ�������")
        End If
        If IsNotNull(XSYUKKA_STS_DTL) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_STS_DTL
            strSQL.Append(vbCrLf & "    AND XSYUKKA_STS_DTL = :" & UBound(strBindField) - 1 & " --�o�׏󋵏ڍ�")
        End If
        If IsNotNull(XDENPYOU_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDENPYOU_NO
            strSQL.Append(vbCrLf & "    AND XDENPYOU_NO = :" & UBound(strBindField) - 1 & " --�`�[No.")
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
        If IsNothing(objType.GetProperty("XSYUKKA_D")) = False Then mXSYUKKA_D = objObject.XSYUKKA_D '�o�ד�
        If IsNothing(objType.GetProperty("XHENSEI_NO")) = False Then mXHENSEI_NO = objObject.XHENSEI_NO '�Ґ�No.
        If IsNothing(objType.GetProperty("FHINMEI_CD")) = False Then mFHINMEI_CD = objObject.FHINMEI_CD '�i�ں���
        If IsNothing(objType.GetProperty("FSAGYOU_KIND")) = False Then mFSAGYOU_KIND = objObject.FSAGYOU_KIND '��Ǝ��
        If IsNothing(objType.GetProperty("FPLAN_KEY")) = False Then mFPLAN_KEY = objObject.FPLAN_KEY '�v�淰
        If IsNothing(objType.GetProperty("XOUT_ORDER")) = False Then mXOUT_ORDER = objObject.XOUT_ORDER '���q���o�וi�ڏ�
        If IsNothing(objType.GetProperty("XSYUKKA_KON_PLAN")) = False Then mXSYUKKA_KON_PLAN = objObject.XSYUKKA_KON_PLAN '�o�ח\�荫��
        If IsNothing(objType.GetProperty("XSYUKKA_KON_RESERVE")) = False Then mXSYUKKA_KON_RESERVE = objObject.XSYUKKA_KON_RESERVE '�o�׈�������
        If IsNothing(objType.GetProperty("XSYUKKA_KON_RESULT")) = False Then mXSYUKKA_KON_RESULT = objObject.XSYUKKA_KON_RESULT '�o�׎��э���
        If IsNothing(objType.GetProperty("XSYUKKA_KON_H_RESULT")) = False Then mXSYUKKA_KON_H_RESULT = objObject.XSYUKKA_KON_H_RESULT '�o�׎��э���(���u)
        If IsNothing(objType.GetProperty("XSAIMOKU")) = False Then mXSAIMOKU = objObject.XSAIMOKU '����敪�ז�
        If IsNothing(objType.GetProperty("FZAIKO_KUBUN")) = False Then mFZAIKO_KUBUN = objObject.FZAIKO_KUBUN '�݌ɋ敪
        If IsNothing(objType.GetProperty("XIDOU_KBN")) = False Then mXIDOU_KBN = objObject.XIDOU_KBN '�ړ��敪
        If IsNothing(objType.GetProperty("XHENSEI_NO_OYA")) = False Then mXHENSEI_NO_OYA = objObject.XHENSEI_NO_OYA '�e�Ґ�No.
        If IsNothing(objType.GetProperty("XTORIKIRI")) = False Then mXTORIKIRI = objObject.XTORIKIRI '���؂�w��
        If IsNothing(objType.GetProperty("XOUT_START_DT")) = False Then mXOUT_START_DT = objObject.XOUT_START_DT '�o�ɊJ�n����
        If IsNothing(objType.GetProperty("XOUT_END_DT")) = False Then mXOUT_END_DT = objObject.XOUT_END_DT '�o�Ɋ�������
        If IsNothing(objType.GetProperty("XSYUKKA_STS_DTL")) = False Then mXSYUKKA_STS_DTL = objObject.XSYUKKA_STS_DTL '�o�׏󋵏ڍ�
        If IsNothing(objType.GetProperty("XDENPYOU_NO")) = False Then mXDENPYOU_NO = objObject.XDENPYOU_NO '�`�[No.

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
        mXSYUKKA_D = Nothing
        mXHENSEI_NO = Nothing
        mFHINMEI_CD = Nothing
        mFSAGYOU_KIND = Nothing
        mFPLAN_KEY = Nothing
        mXOUT_ORDER = Nothing
        mXSYUKKA_KON_PLAN = Nothing
        mXSYUKKA_KON_RESERVE = Nothing
        mXSYUKKA_KON_RESULT = Nothing
        mXSYUKKA_KON_H_RESULT = Nothing
        mXSAIMOKU = Nothing
        mFZAIKO_KUBUN = Nothing
        mXIDOU_KBN = Nothing
        mXHENSEI_NO_OYA = Nothing
        mXTORIKIRI = Nothing
        mXOUT_START_DT = Nothing
        mXOUT_END_DT = Nothing
        mXSYUKKA_STS_DTL = Nothing
        mXDENPYOU_NO = Nothing


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
        mXSYUKKA_D = TO_DATE_NULLABLE(objRow("XSYUKKA_D"))
        mXHENSEI_NO = TO_STRING_NULLABLE(objRow("XHENSEI_NO"))
        mFHINMEI_CD = TO_STRING_NULLABLE(objRow("FHINMEI_CD"))
        mFSAGYOU_KIND = TO_INTEGER_NULLABLE(objRow("FSAGYOU_KIND"))
        mFPLAN_KEY = TO_STRING_NULLABLE(objRow("FPLAN_KEY"))
        mXOUT_ORDER = TO_INTEGER_NULLABLE(objRow("XOUT_ORDER"))
        mXSYUKKA_KON_PLAN = TO_INTEGER_NULLABLE(objRow("XSYUKKA_KON_PLAN"))
        mXSYUKKA_KON_RESERVE = TO_INTEGER_NULLABLE(objRow("XSYUKKA_KON_RESERVE"))
        mXSYUKKA_KON_RESULT = TO_INTEGER_NULLABLE(objRow("XSYUKKA_KON_RESULT"))
        mXSYUKKA_KON_H_RESULT = TO_INTEGER_NULLABLE(objRow("XSYUKKA_KON_H_RESULT"))
        mXSAIMOKU = TO_STRING_NULLABLE(objRow("XSAIMOKU"))
        mFZAIKO_KUBUN = TO_INTEGER_NULLABLE(objRow("FZAIKO_KUBUN"))
        mXIDOU_KBN = TO_STRING_NULLABLE(objRow("XIDOU_KBN"))
        mXHENSEI_NO_OYA = TO_STRING_NULLABLE(objRow("XHENSEI_NO_OYA"))
        mXTORIKIRI = TO_INTEGER_NULLABLE(objRow("XTORIKIRI"))
        mXOUT_START_DT = TO_DATE_NULLABLE(objRow("XOUT_START_DT"))
        mXOUT_END_DT = TO_DATE_NULLABLE(objRow("XOUT_END_DT"))
        mXSYUKKA_STS_DTL = TO_INTEGER_NULLABLE(objRow("XSYUKKA_STS_DTL"))
        mXDENPYOU_NO = TO_STRING_NULLABLE(objRow("XDENPYOU_NO"))


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
        strMsg &= "[ð��ٖ�:�o�׎w���ڍ�]"
        If IsNotNull(XSYUKKA_D) Then
            strMsg &= "[�o�ד�:" & XSYUKKA_D & "]"
        End If
        If IsNotNull(XHENSEI_NO) Then
            strMsg &= "[�Ґ�No.:" & XHENSEI_NO & "]"
        End If
        If IsNotNull(FHINMEI_CD) Then
            strMsg &= "[�i�ں���:" & FHINMEI_CD & "]"
        End If
        If IsNotNull(FSAGYOU_KIND) Then
            strMsg &= "[��Ǝ��:" & FSAGYOU_KIND & "]"
        End If
        If IsNotNull(FPLAN_KEY) Then
            strMsg &= "[�v�淰:" & FPLAN_KEY & "]"
        End If
        If IsNotNull(XOUT_ORDER) Then
            strMsg &= "[���q���o�וi�ڏ�:" & XOUT_ORDER & "]"
        End If
        If IsNotNull(XSYUKKA_KON_PLAN) Then
            strMsg &= "[�o�ח\�荫��:" & XSYUKKA_KON_PLAN & "]"
        End If
        If IsNotNull(XSYUKKA_KON_RESERVE) Then
            strMsg &= "[�o�׈�������:" & XSYUKKA_KON_RESERVE & "]"
        End If
        If IsNotNull(XSYUKKA_KON_RESULT) Then
            strMsg &= "[�o�׎��э���:" & XSYUKKA_KON_RESULT & "]"
        End If
        If IsNotNull(XSYUKKA_KON_H_RESULT) Then
            strMsg &= "[�o�׎��э���(���u):" & XSYUKKA_KON_H_RESULT & "]"
        End If
        If IsNotNull(XSAIMOKU) Then
            strMsg &= "[����敪�ז�:" & XSAIMOKU & "]"
        End If
        If IsNotNull(FZAIKO_KUBUN) Then
            strMsg &= "[�݌ɋ敪:" & FZAIKO_KUBUN & "]"
        End If
        If IsNotNull(XIDOU_KBN) Then
            strMsg &= "[�ړ��敪:" & XIDOU_KBN & "]"
        End If
        If IsNotNull(XHENSEI_NO_OYA) Then
            strMsg &= "[�e�Ґ�No.:" & XHENSEI_NO_OYA & "]"
        End If
        If IsNotNull(XTORIKIRI) Then
            strMsg &= "[���؂�w��:" & XTORIKIRI & "]"
        End If
        If IsNotNull(XOUT_START_DT) Then
            strMsg &= "[�o�ɊJ�n����:" & XOUT_START_DT & "]"
        End If
        If IsNotNull(XOUT_END_DT) Then
            strMsg &= "[�o�Ɋ�������:" & XOUT_END_DT & "]"
        End If
        If IsNotNull(XSYUKKA_STS_DTL) Then
            strMsg &= "[�o�׏󋵏ڍ�:" & XSYUKKA_STS_DTL & "]"
        End If
        If IsNotNull(XDENPYOU_NO) Then
            strMsg &= "[�`�[No.:" & XDENPYOU_NO & "]"
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
#Region "  �o�׎w���ڍ׍폜[�Ґ���/�`�[���P��] (Public  DELETE_XPLN_OUT_DTL_HENSEI)"
    Public Sub DELETE_XPLN_OUT_DTL_HENSEI()
        Try
            Dim strSQL As String        'SQL��
            Dim strMsg As String        'ү����
            Dim intRetSQL As Integer    'SQL���s�߂�l


            '----------------
            '�����è����
            '----------------
            If mXSYUKKA_D = DEFAULT_DATE Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�o�ד�]"
                Throw New System.Exception(strMsg)
            ElseIf mXHENSEI_NO = DEFAULT_STRING Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�Ґ���]"
                Throw New System.Exception(strMsg)
            ElseIf mXDENPYOU_NO = DEFAULT_STRING Then
                strMsg = ERRMSG_ERR_PROPERTY & "[�`�[��]"
                Throw New System.Exception(strMsg)
            End If


            '-----------------------
            '�폜SQL�쐬
            '-----------------------
            strSQL = ""
            strSQL &= vbCrLf & "DELETE"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    XPLN_OUT_DTL"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "    XSYUKKA_D = TO_DATE('" & Format(mXSYUKKA_D, "yyyy/MM/dd") & "','YYYY/MM/DD')"                       '�o�ד�
            strSQL &= vbCrLf & " AND"
            strSQL &= vbCrLf & "    XHENSEI_NO = '" & TO_STRING(mXHENSEI_NO) & "'"          '�Ґ���
            strSQL &= vbCrLf & " AND"
            strSQL &= vbCrLf & "    XDENPYOU_NO = '" & TO_STRING(mXDENPYOU_NO) & "'"        '�`�[��
            strSQL &= vbCrLf


            '-----------------
            '�폜
            '-----------------
            intRetSQL = ObjDb.Execute(strSQL)
            If intRetSQL = -1 Then
                '(SQL�װ)
                strSQL = Replace(strSQL, vbCrLf, "")
                strMsg = ObjDb.ErrMsg & "�y" & strSQL & "�z"
                strMsg = ERRMSG_ERR_DELETE & strMsg
                Throw New System.Exception(strMsg)
            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
#End Region
    '���������ьŗL
    '**********************************************************************************************

End Class
