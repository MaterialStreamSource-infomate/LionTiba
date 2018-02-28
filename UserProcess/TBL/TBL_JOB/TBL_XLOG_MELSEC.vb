'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' �y���́zMaterialStreamð��ٸ׽
' �y�@�\�zMELSEC�ʐM۸�ð��ٸ׽
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
''' MELSEC�ʐM۸�ð��ٸ׽
''' </summary>
Public Class TBL_XLOG_MELSEC
    Inherits clsTemplateTable

    '**********************************************************************************************
    '����������������
#Region "  �׽�ϐ���`                  "
    '�����è
    Private mobjAryMe As TBL_XLOG_MELSEC()                                       'MELSEC�ʐM۸�
    Private mstrUSER_SQL As String                                               'հ�ްSQL
    Private mORDER_BY As String                                                  'OrderBy��
    Private mWHERE As String                                                     'Where��
    Private mFLOG_CHECK_DT1 As Nullable(Of Date)                                 '�m�F����_1
    Private mFEQ_ID As String                                                    '�ݔ�ID
    Private mXCOMMENT01 As String                                                '����01
    Private mXCOMMENT01_01 As String                                             '����01_01
    Private mXCOMMENT02 As String                                                '����02
    Private mXCOMMENT03 As String                                                '����03
    Private mXCOMMENT04 As String                                                '����04
    Private mXCOMMENT05 As String                                                '����05
    Private mXCOMMENT06 As String                                                '����06
    Private mXCOMMENT07 As String                                                '����07
    Private mXCOMMENT08 As String                                                '����08
    Private mXCOMMENT09 As String                                                '����09
    Private mFTEXT_ID As String                                                  '÷��ID
    Private mFTRNS_SERIAL As String                                              '�����ره�(MC��)
    Private mFLOG_CHECK_DT2 As Nullable(Of Date)                                 '�m�F����_2
    Private mFDENBUN As String                                                   '�ʐM�d��
    Private mFDENBUN02 As String                                                 '�ʐM�d��02
    Private mFLOG_NO As String                                                   '۸އ�
#End Region
#Region "  �����è��`                  "
    ''' <summary>
    ''' ���ѕϐ� (���׽�^�z��)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_XLOG_MELSEC()
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
    ''' �m�F����_1
    ''' </summary>
    Public Property FLOG_CHECK_DT1() As Nullable(Of Date)
        Get
            Return mFLOG_CHECK_DT1
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mFLOG_CHECK_DT1 = Value
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
    ''' ����01
    ''' </summary>
    Public Property XCOMMENT01() As String
        Get
            Return mXCOMMENT01
        End Get
        Set(ByVal Value As String)
            mXCOMMENT01 = Value
        End Set
    End Property
    ''' <summary>
    ''' ����01_01
    ''' </summary>
    Public Property XCOMMENT01_01() As String
        Get
            Return mXCOMMENT01_01
        End Get
        Set(ByVal Value As String)
            mXCOMMENT01_01 = Value
        End Set
    End Property
    ''' <summary>
    ''' ����02
    ''' </summary>
    Public Property XCOMMENT02() As String
        Get
            Return mXCOMMENT02
        End Get
        Set(ByVal Value As String)
            mXCOMMENT02 = Value
        End Set
    End Property
    ''' <summary>
    ''' ����03
    ''' </summary>
    Public Property XCOMMENT03() As String
        Get
            Return mXCOMMENT03
        End Get
        Set(ByVal Value As String)
            mXCOMMENT03 = Value
        End Set
    End Property
    ''' <summary>
    ''' ����04
    ''' </summary>
    Public Property XCOMMENT04() As String
        Get
            Return mXCOMMENT04
        End Get
        Set(ByVal Value As String)
            mXCOMMENT04 = Value
        End Set
    End Property
    ''' <summary>
    ''' ����05
    ''' </summary>
    Public Property XCOMMENT05() As String
        Get
            Return mXCOMMENT05
        End Get
        Set(ByVal Value As String)
            mXCOMMENT05 = Value
        End Set
    End Property
    ''' <summary>
    ''' ����06
    ''' </summary>
    Public Property XCOMMENT06() As String
        Get
            Return mXCOMMENT06
        End Get
        Set(ByVal Value As String)
            mXCOMMENT06 = Value
        End Set
    End Property
    ''' <summary>
    ''' ����07
    ''' </summary>
    Public Property XCOMMENT07() As String
        Get
            Return mXCOMMENT07
        End Get
        Set(ByVal Value As String)
            mXCOMMENT07 = Value
        End Set
    End Property
    ''' <summary>
    ''' ����08
    ''' </summary>
    Public Property XCOMMENT08() As String
        Get
            Return mXCOMMENT08
        End Get
        Set(ByVal Value As String)
            mXCOMMENT08 = Value
        End Set
    End Property
    ''' <summary>
    ''' ����09
    ''' </summary>
    Public Property XCOMMENT09() As String
        Get
            Return mXCOMMENT09
        End Get
        Set(ByVal Value As String)
            mXCOMMENT09 = Value
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
    ''' �m�F����_2
    ''' </summary>
    Public Property FLOG_CHECK_DT2() As Nullable(Of Date)
        Get
            Return mFLOG_CHECK_DT2
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mFLOG_CHECK_DT2 = Value
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
    Public Function GET_XLOG_MELSEC(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    XLOG_MELSEC")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FLOG_CHECK_DT1) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT1
            strSQL.Append(vbCrLf & "    AND FLOG_CHECK_DT1 = :" & UBound(strBindField) - 1 & " --�m�F����_1")
        End If
        If IsNull(FEQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --�ݔ�ID")
        End If
        If IsNull(XCOMMENT01) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT01
            strSQL.Append(vbCrLf & "    AND XCOMMENT01 = :" & UBound(strBindField) - 1 & " --����01")
        End If
        If IsNull(XCOMMENT01_01) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT01_01
            strSQL.Append(vbCrLf & "    AND XCOMMENT01_01 = :" & UBound(strBindField) - 1 & " --����01_01")
        End If
        If IsNull(XCOMMENT02) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT02
            strSQL.Append(vbCrLf & "    AND XCOMMENT02 = :" & UBound(strBindField) - 1 & " --����02")
        End If
        If IsNull(XCOMMENT03) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT03
            strSQL.Append(vbCrLf & "    AND XCOMMENT03 = :" & UBound(strBindField) - 1 & " --����03")
        End If
        If IsNull(XCOMMENT04) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT04
            strSQL.Append(vbCrLf & "    AND XCOMMENT04 = :" & UBound(strBindField) - 1 & " --����04")
        End If
        If IsNull(XCOMMENT05) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT05
            strSQL.Append(vbCrLf & "    AND XCOMMENT05 = :" & UBound(strBindField) - 1 & " --����05")
        End If
        If IsNull(XCOMMENT06) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT06
            strSQL.Append(vbCrLf & "    AND XCOMMENT06 = :" & UBound(strBindField) - 1 & " --����06")
        End If
        If IsNull(XCOMMENT07) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT07
            strSQL.Append(vbCrLf & "    AND XCOMMENT07 = :" & UBound(strBindField) - 1 & " --����07")
        End If
        If IsNull(XCOMMENT08) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT08
            strSQL.Append(vbCrLf & "    AND XCOMMENT08 = :" & UBound(strBindField) - 1 & " --����08")
        End If
        If IsNull(XCOMMENT09) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT09
            strSQL.Append(vbCrLf & "    AND XCOMMENT09 = :" & UBound(strBindField) - 1 & " --����09")
        End If
        If IsNull(FTEXT_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTEXT_ID
            strSQL.Append(vbCrLf & "    AND FTEXT_ID = :" & UBound(strBindField) - 1 & " --÷��ID")
        End If
        If IsNull(FTRNS_SERIAL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_SERIAL
            strSQL.Append(vbCrLf & "    AND FTRNS_SERIAL = :" & UBound(strBindField) - 1 & " --�����ره�(MC��)")
        End If
        If IsNull(FLOG_CHECK_DT2) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT2
            strSQL.Append(vbCrLf & "    AND FLOG_CHECK_DT2 = :" & UBound(strBindField) - 1 & " --�m�F����_2")
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
        If IsNull(FLOG_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            strSQL.Append(vbCrLf & "    AND FLOG_NO = :" & UBound(strBindField) - 1 & " --۸އ�")
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
        strDataSetName = "XLOG_MELSEC"
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
    Public Function GET_XLOG_MELSEC_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    XLOG_MELSEC")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FLOG_CHECK_DT1) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT1
            strSQL.Append(vbCrLf & "    AND FLOG_CHECK_DT1 = :" & UBound(strBindField) - 1 & " --�m�F����_1")
        End If
        If IsNull(FEQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --�ݔ�ID")
        End If
        If IsNull(XCOMMENT01) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT01
            strSQL.Append(vbCrLf & "    AND XCOMMENT01 = :" & UBound(strBindField) - 1 & " --����01")
        End If
        If IsNull(XCOMMENT01_01) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT01_01
            strSQL.Append(vbCrLf & "    AND XCOMMENT01_01 = :" & UBound(strBindField) - 1 & " --����01_01")
        End If
        If IsNull(XCOMMENT02) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT02
            strSQL.Append(vbCrLf & "    AND XCOMMENT02 = :" & UBound(strBindField) - 1 & " --����02")
        End If
        If IsNull(XCOMMENT03) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT03
            strSQL.Append(vbCrLf & "    AND XCOMMENT03 = :" & UBound(strBindField) - 1 & " --����03")
        End If
        If IsNull(XCOMMENT04) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT04
            strSQL.Append(vbCrLf & "    AND XCOMMENT04 = :" & UBound(strBindField) - 1 & " --����04")
        End If
        If IsNull(XCOMMENT05) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT05
            strSQL.Append(vbCrLf & "    AND XCOMMENT05 = :" & UBound(strBindField) - 1 & " --����05")
        End If
        If IsNull(XCOMMENT06) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT06
            strSQL.Append(vbCrLf & "    AND XCOMMENT06 = :" & UBound(strBindField) - 1 & " --����06")
        End If
        If IsNull(XCOMMENT07) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT07
            strSQL.Append(vbCrLf & "    AND XCOMMENT07 = :" & UBound(strBindField) - 1 & " --����07")
        End If
        If IsNull(XCOMMENT08) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT08
            strSQL.Append(vbCrLf & "    AND XCOMMENT08 = :" & UBound(strBindField) - 1 & " --����08")
        End If
        If IsNull(XCOMMENT09) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT09
            strSQL.Append(vbCrLf & "    AND XCOMMENT09 = :" & UBound(strBindField) - 1 & " --����09")
        End If
        If IsNull(FTEXT_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTEXT_ID
            strSQL.Append(vbCrLf & "    AND FTEXT_ID = :" & UBound(strBindField) - 1 & " --÷��ID")
        End If
        If IsNull(FTRNS_SERIAL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_SERIAL
            strSQL.Append(vbCrLf & "    AND FTRNS_SERIAL = :" & UBound(strBindField) - 1 & " --�����ره�(MC��)")
        End If
        If IsNull(FLOG_CHECK_DT2) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT2
            strSQL.Append(vbCrLf & "    AND FLOG_CHECK_DT2 = :" & UBound(strBindField) - 1 & " --�m�F����_2")
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
        If IsNull(FLOG_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            strSQL.Append(vbCrLf & "    AND FLOG_NO = :" & UBound(strBindField) - 1 & " --۸އ�")
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
        strDataSetName = "XLOG_MELSEC"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XLOG_MELSEC(Owner, objDb, objDbLog)
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
    Public Function GET_XLOG_MELSEC_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "XLOG_MELSEC"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XLOG_MELSEC(Owner, objDb, objDbLog)
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
    Public Function GET_XLOG_MELSEC_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    XLOG_MELSEC")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FLOG_CHECK_DT1) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT1
            strSQL.Append(vbCrLf & "    AND FLOG_CHECK_DT1 = :" & UBound(strBindField) - 1 & " --�m�F����_1")
        End If
        If IsNull(FEQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --�ݔ�ID")
        End If
        If IsNull(XCOMMENT01) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT01
            strSQL.Append(vbCrLf & "    AND XCOMMENT01 = :" & UBound(strBindField) - 1 & " --����01")
        End If
        If IsNull(XCOMMENT01_01) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT01_01
            strSQL.Append(vbCrLf & "    AND XCOMMENT01_01 = :" & UBound(strBindField) - 1 & " --����01_01")
        End If
        If IsNull(XCOMMENT02) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT02
            strSQL.Append(vbCrLf & "    AND XCOMMENT02 = :" & UBound(strBindField) - 1 & " --����02")
        End If
        If IsNull(XCOMMENT03) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT03
            strSQL.Append(vbCrLf & "    AND XCOMMENT03 = :" & UBound(strBindField) - 1 & " --����03")
        End If
        If IsNull(XCOMMENT04) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT04
            strSQL.Append(vbCrLf & "    AND XCOMMENT04 = :" & UBound(strBindField) - 1 & " --����04")
        End If
        If IsNull(XCOMMENT05) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT05
            strSQL.Append(vbCrLf & "    AND XCOMMENT05 = :" & UBound(strBindField) - 1 & " --����05")
        End If
        If IsNull(XCOMMENT06) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT06
            strSQL.Append(vbCrLf & "    AND XCOMMENT06 = :" & UBound(strBindField) - 1 & " --����06")
        End If
        If IsNull(XCOMMENT07) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT07
            strSQL.Append(vbCrLf & "    AND XCOMMENT07 = :" & UBound(strBindField) - 1 & " --����07")
        End If
        If IsNull(XCOMMENT08) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT08
            strSQL.Append(vbCrLf & "    AND XCOMMENT08 = :" & UBound(strBindField) - 1 & " --����08")
        End If
        If IsNull(XCOMMENT09) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT09
            strSQL.Append(vbCrLf & "    AND XCOMMENT09 = :" & UBound(strBindField) - 1 & " --����09")
        End If
        If IsNull(FTEXT_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTEXT_ID
            strSQL.Append(vbCrLf & "    AND FTEXT_ID = :" & UBound(strBindField) - 1 & " --÷��ID")
        End If
        If IsNull(FTRNS_SERIAL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_SERIAL
            strSQL.Append(vbCrLf & "    AND FTRNS_SERIAL = :" & UBound(strBindField) - 1 & " --�����ره�(MC��)")
        End If
        If IsNull(FLOG_CHECK_DT2) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT2
            strSQL.Append(vbCrLf & "    AND FLOG_CHECK_DT2 = :" & UBound(strBindField) - 1 & " --�m�F����_2")
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
        If IsNull(FLOG_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            strSQL.Append(vbCrLf & "    AND FLOG_NO = :" & UBound(strBindField) - 1 & " --۸އ�")
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
        strDataSetName = "XLOG_MELSEC"
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
    Public Sub UPDATE_XLOG_MELSEC()
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
        strSQL.Append(vbCrLf & "    XLOG_MELSEC")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
        If IsNull(mFLOG_CHECK_DT1) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_CHECK_DT1 = NULL --�m�F����_1")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_CHECK_DT1 = NULL --�m�F����_1")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT1
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_CHECK_DT1 = :" & Ubound(strBindField) - 1 & " --�m�F����_1")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_CHECK_DT1 = :" & Ubound(strBindField) - 1 & " --�m�F����_1")
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
        If IsNull(mXCOMMENT01) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCOMMENT01 = NULL --����01")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCOMMENT01 = NULL --����01")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT01
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCOMMENT01 = :" & Ubound(strBindField) - 1 & " --����01")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCOMMENT01 = :" & Ubound(strBindField) - 1 & " --����01")
        End If
        intCount = intCount + 1
        If IsNull(mXCOMMENT01_01) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCOMMENT01_01 = NULL --����01_01")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCOMMENT01_01 = NULL --����01_01")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT01_01
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCOMMENT01_01 = :" & Ubound(strBindField) - 1 & " --����01_01")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCOMMENT01_01 = :" & Ubound(strBindField) - 1 & " --����01_01")
        End If
        intCount = intCount + 1
        If IsNull(mXCOMMENT02) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCOMMENT02 = NULL --����02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCOMMENT02 = NULL --����02")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT02
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCOMMENT02 = :" & Ubound(strBindField) - 1 & " --����02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCOMMENT02 = :" & Ubound(strBindField) - 1 & " --����02")
        End If
        intCount = intCount + 1
        If IsNull(mXCOMMENT03) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCOMMENT03 = NULL --����03")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCOMMENT03 = NULL --����03")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT03
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCOMMENT03 = :" & Ubound(strBindField) - 1 & " --����03")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCOMMENT03 = :" & Ubound(strBindField) - 1 & " --����03")
        End If
        intCount = intCount + 1
        If IsNull(mXCOMMENT04) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCOMMENT04 = NULL --����04")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCOMMENT04 = NULL --����04")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT04
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCOMMENT04 = :" & Ubound(strBindField) - 1 & " --����04")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCOMMENT04 = :" & Ubound(strBindField) - 1 & " --����04")
        End If
        intCount = intCount + 1
        If IsNull(mXCOMMENT05) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCOMMENT05 = NULL --����05")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCOMMENT05 = NULL --����05")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT05
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCOMMENT05 = :" & Ubound(strBindField) - 1 & " --����05")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCOMMENT05 = :" & Ubound(strBindField) - 1 & " --����05")
        End If
        intCount = intCount + 1
        If IsNull(mXCOMMENT06) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCOMMENT06 = NULL --����06")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCOMMENT06 = NULL --����06")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT06
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCOMMENT06 = :" & Ubound(strBindField) - 1 & " --����06")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCOMMENT06 = :" & Ubound(strBindField) - 1 & " --����06")
        End If
        intCount = intCount + 1
        If IsNull(mXCOMMENT07) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCOMMENT07 = NULL --����07")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCOMMENT07 = NULL --����07")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT07
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCOMMENT07 = :" & Ubound(strBindField) - 1 & " --����07")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCOMMENT07 = :" & Ubound(strBindField) - 1 & " --����07")
        End If
        intCount = intCount + 1
        If IsNull(mXCOMMENT08) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCOMMENT08 = NULL --����08")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCOMMENT08 = NULL --����08")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT08
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCOMMENT08 = :" & Ubound(strBindField) - 1 & " --����08")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCOMMENT08 = :" & Ubound(strBindField) - 1 & " --����08")
        End If
        intCount = intCount + 1
        If IsNull(mXCOMMENT09) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCOMMENT09 = NULL --����09")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCOMMENT09 = NULL --����09")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT09
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCOMMENT09 = :" & Ubound(strBindField) - 1 & " --����09")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCOMMENT09 = :" & Ubound(strBindField) - 1 & " --����09")
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
        If IsNull(mFLOG_CHECK_DT2) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_CHECK_DT2 = NULL --�m�F����_2")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_CHECK_DT2 = NULL --�m�F����_2")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT2
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_CHECK_DT2 = :" & Ubound(strBindField) - 1 & " --�m�F����_2")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_CHECK_DT2 = :" & Ubound(strBindField) - 1 & " --�m�F����_2")
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
    Public Sub ADD_XLOG_MELSEC()
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
        strSQL.Append(vbCrLf & "    XLOG_MELSEC")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
        If IsNull(mFLOG_CHECK_DT1) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�m�F����_1")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�m�F����_1")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT1
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�m�F����_1")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�m�F����_1")
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
        If IsNull(mXCOMMENT01) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����01")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����01")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT01
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����01")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����01")
        End If
        intCount = intCount + 1
        If IsNull(mXCOMMENT01_01) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����01_01")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����01_01")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT01_01
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����01_01")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����01_01")
        End If
        intCount = intCount + 1
        If IsNull(mXCOMMENT02) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����02")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT02
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����02")
        End If
        intCount = intCount + 1
        If IsNull(mXCOMMENT03) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����03")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����03")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT03
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����03")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����03")
        End If
        intCount = intCount + 1
        If IsNull(mXCOMMENT04) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����04")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����04")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT04
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����04")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����04")
        End If
        intCount = intCount + 1
        If IsNull(mXCOMMENT05) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����05")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����05")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT05
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����05")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����05")
        End If
        intCount = intCount + 1
        If IsNull(mXCOMMENT06) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����06")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����06")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT06
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����06")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����06")
        End If
        intCount = intCount + 1
        If IsNull(mXCOMMENT07) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����07")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����07")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT07
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����07")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����07")
        End If
        intCount = intCount + 1
        If IsNull(mXCOMMENT08) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����08")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����08")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT08
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����08")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����08")
        End If
        intCount = intCount + 1
        If IsNull(mXCOMMENT09) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --����09")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --����09")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT09
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --����09")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --����09")
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
        If IsNull(mFLOG_CHECK_DT2) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --�m�F����_2")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --�m�F����_2")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT2
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --�m�F����_2")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --�m�F����_2")
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
    Public Sub DELETE_XLOG_MELSEC()
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
        strSQL.Append(vbCrLf & "    XLOG_MELSEC")
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
    Public Sub DELETE_XLOG_MELSEC_ANY()
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
        strSQL.Append(vbCrLf & "    XLOG_MELSEC")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(FLOG_CHECK_DT1) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT1
            strSQL.Append(vbCrLf & "    AND FLOG_CHECK_DT1 = :" & UBound(strBindField) - 1 & " --�m�F����_1")
        End If
        If IsNotNull(FEQ_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --�ݔ�ID")
        End If
        If IsNotNull(XCOMMENT01) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT01
            strSQL.Append(vbCrLf & "    AND XCOMMENT01 = :" & UBound(strBindField) - 1 & " --����01")
        End If
        If IsNotNull(XCOMMENT01_01) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT01_01
            strSQL.Append(vbCrLf & "    AND XCOMMENT01_01 = :" & UBound(strBindField) - 1 & " --����01_01")
        End If
        If IsNotNull(XCOMMENT02) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT02
            strSQL.Append(vbCrLf & "    AND XCOMMENT02 = :" & UBound(strBindField) - 1 & " --����02")
        End If
        If IsNotNull(XCOMMENT03) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT03
            strSQL.Append(vbCrLf & "    AND XCOMMENT03 = :" & UBound(strBindField) - 1 & " --����03")
        End If
        If IsNotNull(XCOMMENT04) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT04
            strSQL.Append(vbCrLf & "    AND XCOMMENT04 = :" & UBound(strBindField) - 1 & " --����04")
        End If
        If IsNotNull(XCOMMENT05) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT05
            strSQL.Append(vbCrLf & "    AND XCOMMENT05 = :" & UBound(strBindField) - 1 & " --����05")
        End If
        If IsNotNull(XCOMMENT06) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT06
            strSQL.Append(vbCrLf & "    AND XCOMMENT06 = :" & UBound(strBindField) - 1 & " --����06")
        End If
        If IsNotNull(XCOMMENT07) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT07
            strSQL.Append(vbCrLf & "    AND XCOMMENT07 = :" & UBound(strBindField) - 1 & " --����07")
        End If
        If IsNotNull(XCOMMENT08) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT08
            strSQL.Append(vbCrLf & "    AND XCOMMENT08 = :" & UBound(strBindField) - 1 & " --����08")
        End If
        If IsNotNull(XCOMMENT09) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCOMMENT09
            strSQL.Append(vbCrLf & "    AND XCOMMENT09 = :" & UBound(strBindField) - 1 & " --����09")
        End If
        If IsNotNull(FTEXT_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTEXT_ID
            strSQL.Append(vbCrLf & "    AND FTEXT_ID = :" & UBound(strBindField) - 1 & " --÷��ID")
        End If
        If IsNotNull(FTRNS_SERIAL) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_SERIAL
            strSQL.Append(vbCrLf & "    AND FTRNS_SERIAL = :" & UBound(strBindField) - 1 & " --�����ره�(MC��)")
        End If
        If IsNotNull(FLOG_CHECK_DT2) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT2
            strSQL.Append(vbCrLf & "    AND FLOG_CHECK_DT2 = :" & UBound(strBindField) - 1 & " --�m�F����_2")
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
        If IsNotNull(FLOG_NO) = True Then
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
#Region "  �����è��߰                  "
    Public Sub COPY_PROPERTY(ByVal objObject As Object)


        '***********************
        '�����è�ϐ��־��
        '***********************
        Dim objType As Type = objObject.GetType
        If IsNothing(objType.GetProperty("FLOG_CHECK_DT1")) = False Then mFLOG_CHECK_DT1 = objObject.FLOG_CHECK_DT1 '�m�F����_1
        If IsNothing(objType.GetProperty("FEQ_ID")) = False Then mFEQ_ID = objObject.FEQ_ID '�ݔ�ID
        If IsNothing(objType.GetProperty("XCOMMENT01")) = False Then mXCOMMENT01 = objObject.XCOMMENT01 '����01
        If IsNothing(objType.GetProperty("XCOMMENT01_01")) = False Then mXCOMMENT01_01 = objObject.XCOMMENT01_01 '����01_01
        If IsNothing(objType.GetProperty("XCOMMENT02")) = False Then mXCOMMENT02 = objObject.XCOMMENT02 '����02
        If IsNothing(objType.GetProperty("XCOMMENT03")) = False Then mXCOMMENT03 = objObject.XCOMMENT03 '����03
        If IsNothing(objType.GetProperty("XCOMMENT04")) = False Then mXCOMMENT04 = objObject.XCOMMENT04 '����04
        If IsNothing(objType.GetProperty("XCOMMENT05")) = False Then mXCOMMENT05 = objObject.XCOMMENT05 '����05
        If IsNothing(objType.GetProperty("XCOMMENT06")) = False Then mXCOMMENT06 = objObject.XCOMMENT06 '����06
        If IsNothing(objType.GetProperty("XCOMMENT07")) = False Then mXCOMMENT07 = objObject.XCOMMENT07 '����07
        If IsNothing(objType.GetProperty("XCOMMENT08")) = False Then mXCOMMENT08 = objObject.XCOMMENT08 '����08
        If IsNothing(objType.GetProperty("XCOMMENT09")) = False Then mXCOMMENT09 = objObject.XCOMMENT09 '����09
        If IsNothing(objType.GetProperty("FTEXT_ID")) = False Then mFTEXT_ID = objObject.FTEXT_ID '÷��ID
        If IsNothing(objType.GetProperty("FTRNS_SERIAL")) = False Then mFTRNS_SERIAL = objObject.FTRNS_SERIAL '�����ره�(MC��)
        If IsNothing(objType.GetProperty("FLOG_CHECK_DT2")) = False Then mFLOG_CHECK_DT2 = objObject.FLOG_CHECK_DT2 '�m�F����_2
        If IsNothing(objType.GetProperty("FDENBUN")) = False Then mFDENBUN = objObject.FDENBUN '�ʐM�d��
        If IsNothing(objType.GetProperty("FDENBUN02")) = False Then mFDENBUN02 = objObject.FDENBUN02 '�ʐM�d��02
        If IsNothing(objType.GetProperty("FLOG_NO")) = False Then mFLOG_NO = objObject.FLOG_NO '۸އ�

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
        mFLOG_CHECK_DT1 = Nothing
        mFEQ_ID = Nothing
        mXCOMMENT01 = Nothing
        mXCOMMENT01_01 = Nothing
        mXCOMMENT02 = Nothing
        mXCOMMENT03 = Nothing
        mXCOMMENT04 = Nothing
        mXCOMMENT05 = Nothing
        mXCOMMENT06 = Nothing
        mXCOMMENT07 = Nothing
        mXCOMMENT08 = Nothing
        mXCOMMENT09 = Nothing
        mFTEXT_ID = Nothing
        mFTRNS_SERIAL = Nothing
        mFLOG_CHECK_DT2 = Nothing
        mFDENBUN = Nothing
        mFDENBUN02 = Nothing
        mFLOG_NO = Nothing


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
        mFLOG_CHECK_DT1 = TO_DATE_NULLABLE(objRow("FLOG_CHECK_DT1"))
        mFEQ_ID = TO_STRING_NULLABLE(objRow("FEQ_ID"))
        mXCOMMENT01 = TO_STRING_NULLABLE(objRow("XCOMMENT01"))
        mXCOMMENT01_01 = TO_STRING_NULLABLE(objRow("XCOMMENT01_01"))
        mXCOMMENT02 = TO_STRING_NULLABLE(objRow("XCOMMENT02"))
        mXCOMMENT03 = TO_STRING_NULLABLE(objRow("XCOMMENT03"))
        mXCOMMENT04 = TO_STRING_NULLABLE(objRow("XCOMMENT04"))
        mXCOMMENT05 = TO_STRING_NULLABLE(objRow("XCOMMENT05"))
        mXCOMMENT06 = TO_STRING_NULLABLE(objRow("XCOMMENT06"))
        mXCOMMENT07 = TO_STRING_NULLABLE(objRow("XCOMMENT07"))
        mXCOMMENT08 = TO_STRING_NULLABLE(objRow("XCOMMENT08"))
        mXCOMMENT09 = TO_STRING_NULLABLE(objRow("XCOMMENT09"))
        mFTEXT_ID = TO_STRING_NULLABLE(objRow("FTEXT_ID"))
        mFTRNS_SERIAL = TO_STRING_NULLABLE(objRow("FTRNS_SERIAL"))
        mFLOG_CHECK_DT2 = TO_DATE_NULLABLE(objRow("FLOG_CHECK_DT2"))
        mFDENBUN = TO_STRING_NULLABLE(objRow("FDENBUN"))
        mFDENBUN02 = TO_STRING_NULLABLE(objRow("FDENBUN02"))
        mFLOG_NO = TO_STRING_NULLABLE(objRow("FLOG_NO"))


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
        strMsg &= "[ð��ٖ�:MELSEC�ʐM۸�]"
        If IsNotNull(FLOG_CHECK_DT1) Then
            strMsg &= "[�m�F����_1:" & FLOG_CHECK_DT1 & "]"
        End If
        If IsNotNull(FEQ_ID) Then
            strMsg &= "[�ݔ�ID:" & FEQ_ID & "]"
        End If
        If IsNotNull(XCOMMENT01) Then
            strMsg &= "[����01:" & XCOMMENT01 & "]"
        End If
        If IsNotNull(XCOMMENT01_01) Then
            strMsg &= "[����01_01:" & XCOMMENT01_01 & "]"
        End If
        If IsNotNull(XCOMMENT02) Then
            strMsg &= "[����02:" & XCOMMENT02 & "]"
        End If
        If IsNotNull(XCOMMENT03) Then
            strMsg &= "[����03:" & XCOMMENT03 & "]"
        End If
        If IsNotNull(XCOMMENT04) Then
            strMsg &= "[����04:" & XCOMMENT04 & "]"
        End If
        If IsNotNull(XCOMMENT05) Then
            strMsg &= "[����05:" & XCOMMENT05 & "]"
        End If
        If IsNotNull(XCOMMENT06) Then
            strMsg &= "[����06:" & XCOMMENT06 & "]"
        End If
        If IsNotNull(XCOMMENT07) Then
            strMsg &= "[����07:" & XCOMMENT07 & "]"
        End If
        If IsNotNull(XCOMMENT08) Then
            strMsg &= "[����08:" & XCOMMENT08 & "]"
        End If
        If IsNotNull(XCOMMENT09) Then
            strMsg &= "[����09:" & XCOMMENT09 & "]"
        End If
        If IsNotNull(FTEXT_ID) Then
            strMsg &= "[÷��ID:" & FTEXT_ID & "]"
        End If
        If IsNotNull(FTRNS_SERIAL) Then
            strMsg &= "[�����ره�(MC��):" & FTRNS_SERIAL & "]"
        End If
        If IsNotNull(FLOG_CHECK_DT2) Then
            strMsg &= "[�m�F����_2:" & FLOG_CHECK_DT2 & "]"
        End If
        If IsNotNull(FDENBUN) Then
            strMsg &= "[�ʐM�d��:" & FDENBUN & "]"
        End If
        If IsNotNull(FDENBUN02) Then
            strMsg &= "[�ʐM�d��02:" & FDENBUN02 & "]"
        End If
        If IsNotNull(FLOG_NO) Then
            strMsg &= "[۸އ�:" & FLOG_NO & "]"
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
#Region "  �پ���ʐM۸ޒǉ�  [SEQ����]                  "
    Public Sub ADD_XLOG_MELSEC_SEQ()
        Try


            '***********************
            '۸އ��̓���
            '***********************
            Dim objTPRG_SEQNO As New TBL_TPRG_SEQNO(Owner, ObjDb, ObjDbLog) '���ݽ���׽
            objTPRG_SEQNO.FSEQ_ID = FSEQ_ID_SSVRLOG_NO_EQ                    '���ݽID
            mFLOG_NO = objTPRG_SEQNO.GET_ENTRY_NO()                         'SEQ���̓���


            '***********************
            '�ǉ�
            '***********************
            Me.ADD_XLOG_MELSEC()


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
