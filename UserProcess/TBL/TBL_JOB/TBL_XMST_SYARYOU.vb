'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' 【名称】MaterialStreamﾃｰﾌﾞﾙｸﾗｽ
' 【機能】車輌ﾏｽﾀﾃｰﾌﾞﾙｸﾗｽ
' 【作成】2010/03/02  SIT                                   Rev 0.00
'**********************************************************************************************

#Region "  Imports"
Imports System
Imports System.Text
Imports MateCommon
Imports MateCommon.clsConst
Imports JobCommon
#End Region

''' <summary>
''' 車輌ﾏｽﾀﾃｰﾌﾞﾙｸﾗｽ
''' </summary>
Public Class TBL_XMST_SYARYOU
    Inherits clsTemplateTable

    '**********************************************************************************************
    '↓↓↓自動生成部
#Region "  ｸﾗｽ変数定義                  "
    'ﾌﾟﾛﾊﾟﾃｨ
    Private mobjAryMe As TBL_XMST_SYARYOU()                                      '車輌ﾏｽﾀ
    Private mstrUSER_SQL As String                                               'ﾕｰｻﾞｰSQL
    Private mORDER_BY As String                                                  'OrderBy句
    Private mWHERE As String                                                     'Where句
    Private mXSYARYOU_NO As Nullable(Of Integer)                                 '車輌番号
    Private mXTUMI_HOUKOU As Nullable(Of Integer)                                '積込方向
    Private mXTUMI_HOUHOU As Nullable(Of Integer)                                '積込方法
    Private mXNOT_USER As Nullable(Of Integer)                                   '未使用区分
    Private mFENTRY_DT As Nullable(Of Date)                                      '登録日時
    Private mXCARD_NO As String                                                  'ｶｰﾄﾞ№
    Private mXSYASYU_KBN As String                                               '車種区分
    Private mXSYASYU_COMMENT As String                                           '車種ｺﾒﾝﾄ
    Private mXGYOUSYA_CD As String                                               '物流業者ｺｰﾄﾞ
    Private mXLOADER_POSSIBLE As Nullable(Of Integer)                            'ﾛｰﾀﾞ対応可否
    Private mXSYARYOU_MODE As Nullable(Of Integer)                               'ﾛｰﾀﾞﾓｰﾄﾞ(ﾌﾟｯｼｬｰ比)
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                  "
    ''' <summary>
    ''' ｼｽﾃﾑ変数 (自ｸﾗｽ型配列)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_XMST_SYARYOU()
        Get
            Return mobjAryMe
        End Get
    End Property
    ''' <summary>
    ''' ﾕｰｻﾞｰSQL (文字型)
    ''' </summary>
    Public WriteOnly Property USER_SQL() As String
        Set(ByVal Value As String)
            mstrUSER_SQL = Value
        End Set
    End Property
    ''' <summary>
    ''' OrderBy句
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
    ''' Where句
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
    ''' 車輌番号
    ''' </summary>
    Public Property XSYARYOU_NO() As Nullable(Of Integer)
        Get
            Return mXSYARYOU_NO
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXSYARYOU_NO = Value
        End Set
    End Property
    ''' <summary>
    ''' 積込方向
    ''' </summary>
    Public Property XTUMI_HOUKOU() As Nullable(Of Integer)
        Get
            Return mXTUMI_HOUKOU
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXTUMI_HOUKOU = Value
        End Set
    End Property
    ''' <summary>
    ''' 積込方法
    ''' </summary>
    Public Property XTUMI_HOUHOU() As Nullable(Of Integer)
        Get
            Return mXTUMI_HOUHOU
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXTUMI_HOUHOU = Value
        End Set
    End Property
    ''' <summary>
    ''' 未使用区分
    ''' </summary>
    Public Property XNOT_USER() As Nullable(Of Integer)
        Get
            Return mXNOT_USER
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXNOT_USER = Value
        End Set
    End Property
    ''' <summary>
    ''' 登録日時
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
    ''' ｶｰﾄﾞ№
    ''' </summary>
    Public Property XCARD_NO() As String
        Get
            Return mXCARD_NO
        End Get
        Set(ByVal Value As String)
            mXCARD_NO = Value
        End Set
    End Property
    ''' <summary>
    ''' 車種区分
    ''' </summary>
    Public Property XSYASYU_KBN() As String
        Get
            Return mXSYASYU_KBN
        End Get
        Set(ByVal Value As String)
            mXSYASYU_KBN = Value
        End Set
    End Property
    ''' <summary>
    ''' 車種ｺﾒﾝﾄ
    ''' </summary>
    Public Property XSYASYU_COMMENT() As String
        Get
            Return mXSYASYU_COMMENT
        End Get
        Set(ByVal Value As String)
            mXSYASYU_COMMENT = Value
        End Set
    End Property
    ''' <summary>
    ''' 物流業者ｺｰﾄﾞ
    ''' </summary>
    Public Property XGYOUSYA_CD() As String
        Get
            Return mXGYOUSYA_CD
        End Get
        Set(ByVal Value As String)
            mXGYOUSYA_CD = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾛｰﾀﾞ対応可否
    ''' </summary>
    Public Property XLOADER_POSSIBLE() As Nullable(Of Integer)
        Get
            Return mXLOADER_POSSIBLE
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXLOADER_POSSIBLE = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾛｰﾀﾞﾓｰﾄﾞ(ﾌﾟｯｼｬｰ比)
    ''' </summary>
    Public Property XSYARYOU_MODE() As Nullable(Of Integer)
        Get
            Return mXSYARYOU_MODE
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXSYARYOU_MODE = Value
        End Set
    End Property
#End Region
#Region "  ｺﾝｽﾄﾗｸﾀ                      "
    '''**********************************************************************************************
    ''' <summary>
    ''' ｺﾝｽﾄﾗｸﾀ
    ''' </summary>
    ''' <param name="objOwner">ｵｰﾅｰｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="objDb">DBｱｸｾｽｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <param name="objDbLog">DBｱｸｾｽｵﾌﾞｼﾞｪｸﾄ(ﾛｸﾞ書き込み用)</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub New(ByVal objOwner As Object, ByVal objDb As clsConn, ByVal objDbLog As clsConn)
        MyBase.new(objOwner, objDb, objDbLog)   '親ｸﾗｽのｺﾝｽﾄﾗｸﾀを実装
    End Sub
#End Region
#Region "  ﾃﾞｰﾀ取得                     "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀ取得
    ''' </summary>
    ''' <param name="blnNotFoundError">ﾚｺｰﾄﾞが一件も取得出来なかった場合、Throwするか否かのﾌﾗｸﾞ</param>
    ''' <returns>共通戻り値</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function GET_XMST_SYARYOU(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
        Dim strSQL As New StringBuilder 'SQL文
        Dim objDataSet As New DataSet   'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String    'ﾃﾞｰﾀｾｯﾄ名
        Dim objRow As DataRow           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim objParameter(1, 0) As Object
        Dim strBindField(0) As String
        Dim objBindValue(0) As Object
        Dim strBindType(0) As String


        '***********************
        '抽出SQL作成
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
        strSQL.Append(vbCrLf & "    XMST_SYARYOU")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XSYARYOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYARYOU_NO
            strSQL.Append(vbCrLf & "    AND XSYARYOU_NO = :" & UBound(strBindField) - 1 & " --車輌番号")
        End If
        If IsNull(XTUMI_HOUKOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_HOUKOU
            strSQL.Append(vbCrLf & "    AND XTUMI_HOUKOU = :" & UBound(strBindField) - 1 & " --積込方向")
        End If
        If IsNull(XTUMI_HOUHOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_HOUHOU
            strSQL.Append(vbCrLf & "    AND XTUMI_HOUHOU = :" & UBound(strBindField) - 1 & " --積込方法")
        End If
        If IsNull(XNOT_USER) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXNOT_USER
            strSQL.Append(vbCrLf & "    AND XNOT_USER = :" & UBound(strBindField) - 1 & " --未使用区分")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --登録日時")
        End If
        If IsNull(XCARD_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCARD_NO
            strSQL.Append(vbCrLf & "    AND XCARD_NO = :" & UBound(strBindField) - 1 & " --ｶｰﾄﾞ№")
        End If
        If IsNull(XSYASYU_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYASYU_KBN
            strSQL.Append(vbCrLf & "    AND XSYASYU_KBN = :" & UBound(strBindField) - 1 & " --車種区分")
        End If
        If IsNull(XSYASYU_COMMENT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYASYU_COMMENT
            strSQL.Append(vbCrLf & "    AND XSYASYU_COMMENT = :" & UBound(strBindField) - 1 & " --車種ｺﾒﾝﾄ")
        End If
        If IsNull(XGYOUSYA_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_CD
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_CD = :" & UBound(strBindField) - 1 & " --物流業者ｺｰﾄﾞ")
        End If
        If IsNull(XLOADER_POSSIBLE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXLOADER_POSSIBLE
            strSQL.Append(vbCrLf & "    AND XLOADER_POSSIBLE = :" & UBound(strBindField) - 1 & " --ﾛｰﾀﾞ対応可否")
        End If
        If IsNull(XSYARYOU_MODE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYARYOU_MODE
            strSQL.Append(vbCrLf & "    AND XSYARYOU_MODE = :" & UBound(strBindField) - 1 & " --ﾛｰﾀﾞﾓｰﾄﾞ(ﾌﾟｯｼｬｰ比)")
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
        'ﾊﾞｲﾝﾄﾞ変数定義
        '***********************
        objParameter = Nothing
        ReDim Preserve objParameter(2, UBound(strBindField) - 1)
        Dim ii As Integer
        For ii = LBound(strBindField) + 1 To UBound(strBindField)
            objParameter(0, ii - 1) = strBindField(ii)
            objParameter(1, ii - 1) = objBindValue(ii)
        Next ii


        '***********************
        '抽出
        '***********************
        ObjDb.SQL = strSQL.ToString
        ObjDb.Parameter = objParameter
        objDataSet.Clear()
        strDataSetName = "XMST_SYARYOU"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count = 1 Then
            objRow = objDataSet.Tables(strDataSetName).Rows(0)
            Call SET_DATA(objRow)
            Return (RetCode.OK)
        ElseIf objDataSet.Tables(strDataSetName).Rows.Count <= 0 Then

            If blnNotFoundError = True Then
                '(ｴﾗｰとする場合)
                Dim strMsg As String = ""
                Call MAKE_ERRMSG01(strMsg)
                Throw New UserException(strMsg)
            Else
                '(ｴﾗｰしない場合)
                Return (RetCode.NotFound)
            End If

        Else
            Throw New UserException("複数ﾚｺｰﾄﾞ抽出した為、ｴﾗｰとします。")
        End If


    End Function
#End Region
#Region "  ﾃﾞｰﾀ取得(複数ﾚｺｰﾄﾞ)          "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀ取得(複数ﾚｺｰﾄﾞ)
    ''' </summary>
    ''' <returns>共通戻り値</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function GET_XMST_SYARYOU_ANY() As RetCode
        Dim strSQL As New StringBuilder 'SQL文
        Dim objDataSet As New DataSet   'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String    'ﾃﾞｰﾀｾｯﾄ名
        Dim objRow As DataRow           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim objParameter(1, 0) As Object
        Dim strBindField(0) As String
        Dim objBindValue(0) As Object
        Dim strBindType(0) As String


        '***********************
        '抽出SQL作成
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
        strSQL.Append(vbCrLf & "    XMST_SYARYOU")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XSYARYOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYARYOU_NO
            strSQL.Append(vbCrLf & "    AND XSYARYOU_NO = :" & UBound(strBindField) - 1 & " --車輌番号")
        End If
        If IsNull(XTUMI_HOUKOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_HOUKOU
            strSQL.Append(vbCrLf & "    AND XTUMI_HOUKOU = :" & UBound(strBindField) - 1 & " --積込方向")
        End If
        If IsNull(XTUMI_HOUHOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_HOUHOU
            strSQL.Append(vbCrLf & "    AND XTUMI_HOUHOU = :" & UBound(strBindField) - 1 & " --積込方法")
        End If
        If IsNull(XNOT_USER) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXNOT_USER
            strSQL.Append(vbCrLf & "    AND XNOT_USER = :" & UBound(strBindField) - 1 & " --未使用区分")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --登録日時")
        End If
        If IsNull(XCARD_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCARD_NO
            strSQL.Append(vbCrLf & "    AND XCARD_NO = :" & UBound(strBindField) - 1 & " --ｶｰﾄﾞ№")
        End If
        If IsNull(XSYASYU_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYASYU_KBN
            strSQL.Append(vbCrLf & "    AND XSYASYU_KBN = :" & UBound(strBindField) - 1 & " --車種区分")
        End If
        If IsNull(XSYASYU_COMMENT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYASYU_COMMENT
            strSQL.Append(vbCrLf & "    AND XSYASYU_COMMENT = :" & UBound(strBindField) - 1 & " --車種ｺﾒﾝﾄ")
        End If
        If IsNull(XGYOUSYA_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_CD
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_CD = :" & UBound(strBindField) - 1 & " --物流業者ｺｰﾄﾞ")
        End If
        If IsNull(XLOADER_POSSIBLE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXLOADER_POSSIBLE
            strSQL.Append(vbCrLf & "    AND XLOADER_POSSIBLE = :" & UBound(strBindField) - 1 & " --ﾛｰﾀﾞ対応可否")
        End If
        If IsNull(XSYARYOU_MODE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYARYOU_MODE
            strSQL.Append(vbCrLf & "    AND XSYARYOU_MODE = :" & UBound(strBindField) - 1 & " --ﾛｰﾀﾞﾓｰﾄﾞ(ﾌﾟｯｼｬｰ比)")
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
        'ﾊﾞｲﾝﾄﾞ変数定義
        '***********************
        objParameter = Nothing
        ReDim Preserve objParameter(2, Ubound(strBindField) - 1)
        Dim ii As Integer
        For ii = Lbound(strBindField) + 1 To Ubound(strBindField)
            objParameter(0, ii - 1) = strBindField(ii)
            objParameter(1, ii - 1) = objBindValue(ii)
        Next ii


        '***********************
        '抽出
        '***********************
        mobjAryMe = Nothing
        ObjDb.SQL = strSQL.ToString
        ObjDb.Parameter = objParameter
        objDataSet.Clear()
        strDataSetName = "XMST_SYARYOU"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XMST_SYARYOU(Owner, objDb, objDbLog)
                mobjAryMe(ii).SET_DATA(objRow)
            Next ii
            Return (RetCode.OK)
        Else
            Return (RetCode.NotFound)
        End If


    End Function
#End Region
#Region "  ﾃﾞｰﾀ取得(ｶｽﾀﾑ抽出)           "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀ取得(ｶｽﾀﾑ抽出)
    ''' </summary>
    ''' <param name="objUSER_PARAM">ﾕｰｻﾞｰPARAM (ﾊﾞｲﾝﾄﾞ変数用ｵﾌﾞｼﾞｪｸﾄ型配列)</param>
    ''' <returns>共通戻り値</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function GET_XMST_SYARYOU_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
        Dim strMsg As String            'ﾒｯｾｰｼﾞ
        Dim objDataSet As New DataSet   'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String    'ﾃﾞｰﾀｾｯﾄ名
        Dim objRow As DataRow           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim ii As Integer               'ｶｳﾝﾀ


        '***********************
        'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
        '***********************
        If 1 <> 1 Then
        ElseIf IsNull(mstrUSER_SQL) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾕｰｻﾞｰSQL]"
            Throw New UserException(strMsg)
        End If


        '***********************
        '抽出
        '***********************
        mobjAryMe = Nothing
        If IsNothing(objUSER_PARAM) = False Then
            ObjDb.Parameter = objUSER_PARAM
        End If
        ObjDb.SQL = mstrUSER_SQL
        objDataSet.Clear()
        strDataSetName = "XMST_SYARYOU"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XMST_SYARYOU(Owner, objDb, objDbLog)
                mobjAryMe(ii).SET_DATA(objRow)
            Next ii
            Return (RetCode.OK)
        Else
            Return (RetCode.NotFound)
        End If


    End Function
#End Region
#Region "  ﾃﾞｰﾀ取得(ｶｳﾝﾄ)               "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀ取得(ｶｳﾝﾄ)
    ''' </summary>
    ''' <returns>共通戻り値</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function GET_XMST_SYARYOU_COUNT() As Integer
        Dim strSQL As New StringBuilder 'SQL文
        Dim objDataSet As New DataSet   'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String    'ﾃﾞｰﾀｾｯﾄ名
        Dim objRow As DataRow           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim objParameter(1, 0) As Object
        Dim strBindField(0) As String
        Dim objBindValue(0) As Object
        Dim strBindType(0) As String


        '***********************
        '抽出SQL作成
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
        strSQL.Append(vbCrLf & "    XMST_SYARYOU")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XSYARYOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYARYOU_NO
            strSQL.Append(vbCrLf & "    AND XSYARYOU_NO = :" & UBound(strBindField) - 1 & " --車輌番号")
        End If
        If IsNull(XTUMI_HOUKOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_HOUKOU
            strSQL.Append(vbCrLf & "    AND XTUMI_HOUKOU = :" & UBound(strBindField) - 1 & " --積込方向")
        End If
        If IsNull(XTUMI_HOUHOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_HOUHOU
            strSQL.Append(vbCrLf & "    AND XTUMI_HOUHOU = :" & UBound(strBindField) - 1 & " --積込方法")
        End If
        If IsNull(XNOT_USER) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXNOT_USER
            strSQL.Append(vbCrLf & "    AND XNOT_USER = :" & UBound(strBindField) - 1 & " --未使用区分")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --登録日時")
        End If
        If IsNull(XCARD_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCARD_NO
            strSQL.Append(vbCrLf & "    AND XCARD_NO = :" & UBound(strBindField) - 1 & " --ｶｰﾄﾞ№")
        End If
        If IsNull(XSYASYU_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYASYU_KBN
            strSQL.Append(vbCrLf & "    AND XSYASYU_KBN = :" & UBound(strBindField) - 1 & " --車種区分")
        End If
        If IsNull(XSYASYU_COMMENT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYASYU_COMMENT
            strSQL.Append(vbCrLf & "    AND XSYASYU_COMMENT = :" & UBound(strBindField) - 1 & " --車種ｺﾒﾝﾄ")
        End If
        If IsNull(XGYOUSYA_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_CD
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_CD = :" & UBound(strBindField) - 1 & " --物流業者ｺｰﾄﾞ")
        End If
        If IsNull(XLOADER_POSSIBLE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXLOADER_POSSIBLE
            strSQL.Append(vbCrLf & "    AND XLOADER_POSSIBLE = :" & UBound(strBindField) - 1 & " --ﾛｰﾀﾞ対応可否")
        End If
        If IsNull(XSYARYOU_MODE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYARYOU_MODE
            strSQL.Append(vbCrLf & "    AND XSYARYOU_MODE = :" & UBound(strBindField) - 1 & " --ﾛｰﾀﾞﾓｰﾄﾞ(ﾌﾟｯｼｬｰ比)")
        End If
        If IsNotNull(mWHERE) Then
            strSQL.Append(vbCrLf & mWHERE)
        End If
        strSQL.Append(vbCrLf)


        '***********************
        'ﾊﾞｲﾝﾄﾞ変数定義
        '***********************
        objParameter = Nothing
        ReDim Preserve objParameter(2, Ubound(strBindField) - 1)
        Dim ii As Integer
        For ii = Lbound(strBindField) + 1 To Ubound(strBindField)
            objParameter(0, ii - 1) = strBindField(ii)
            objParameter(1, ii - 1) = objBindValue(ii)
        Next ii


        '***********************
        '抽出
        '***********************
        ObjDb.SQL = strSQL.ToString
        ObjDb.Parameter = objParameter
        objDataSet.Clear()
        strDataSetName = "XMST_SYARYOU"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        objRow = objDataSet.Tables(strDataSetName).Rows(0)
        Return (objRow(0))


    End Function
#End Region
#Region "  ﾃﾞｰﾀ更新                     "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀ更新
    ''' </summary>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub UPDATE_XMST_SYARYOU()
        Dim strSQL As New StringBuilder     'SQL文
        Dim strMsg As String                'ﾒｯｾｰｼﾞ
        Dim intRetSQL As Integer            'SQL実行戻り値
        Dim objParameter(1, 0) As Object
        Dim strBindField(0) As String
        Dim objBindValue(0) As Object


        '***********************
        'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
        '***********************
        If 1 <> 1 Then
        ElseIf IsNull(mXSYARYOU_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[車輌番号]"
            Throw New UserException(strMsg)
        End If


        '***********************
        '更新SQL作成
        '***********************
        strBindField = Nothing
        objBindValue = Nothing
        ReDim Preserve strBindField(0)
        ReDim Preserve objBindValue(0)
        strSQL.Append(vbCrLf & "UPDATE")
        strSQL.Append(vbCrLf & "    XMST_SYARYOU")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
        If IsNull(mXSYARYOU_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYARYOU_NO = NULL --車輌番号")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYARYOU_NO = NULL --車輌番号")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYARYOU_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYARYOU_NO = :" & Ubound(strBindField) - 1 & " --車輌番号")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYARYOU_NO = :" & Ubound(strBindField) - 1 & " --車輌番号")
        End If
        intCount = intCount + 1
        If IsNull(mXTUMI_HOUKOU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTUMI_HOUKOU = NULL --積込方向")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTUMI_HOUKOU = NULL --積込方向")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_HOUKOU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTUMI_HOUKOU = :" & Ubound(strBindField) - 1 & " --積込方向")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTUMI_HOUKOU = :" & Ubound(strBindField) - 1 & " --積込方向")
        End If
        intCount = intCount + 1
        If IsNull(mXTUMI_HOUHOU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTUMI_HOUHOU = NULL --積込方法")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTUMI_HOUHOU = NULL --積込方法")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_HOUHOU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTUMI_HOUHOU = :" & Ubound(strBindField) - 1 & " --積込方法")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTUMI_HOUHOU = :" & Ubound(strBindField) - 1 & " --積込方法")
        End If
        intCount = intCount + 1
        If IsNull(mXNOT_USER) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XNOT_USER = NULL --未使用区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XNOT_USER = NULL --未使用区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXNOT_USER
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XNOT_USER = :" & Ubound(strBindField) - 1 & " --未使用区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XNOT_USER = :" & Ubound(strBindField) - 1 & " --未使用区分")
        End If
        intCount = intCount + 1
        If IsNull(mFENTRY_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FENTRY_DT = NULL --登録日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FENTRY_DT = NULL --登録日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FENTRY_DT = :" & Ubound(strBindField) - 1 & " --登録日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FENTRY_DT = :" & Ubound(strBindField) - 1 & " --登録日時")
        End If
        intCount = intCount + 1
        If IsNull(mXCARD_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCARD_NO = NULL --ｶｰﾄﾞ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCARD_NO = NULL --ｶｰﾄﾞ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCARD_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCARD_NO = :" & Ubound(strBindField) - 1 & " --ｶｰﾄﾞ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCARD_NO = :" & Ubound(strBindField) - 1 & " --ｶｰﾄﾞ№")
        End If
        intCount = intCount + 1
        If IsNull(mXSYASYU_KBN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYASYU_KBN = NULL --車種区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYASYU_KBN = NULL --車種区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYASYU_KBN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYASYU_KBN = :" & Ubound(strBindField) - 1 & " --車種区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYASYU_KBN = :" & Ubound(strBindField) - 1 & " --車種区分")
        End If
        intCount = intCount + 1
        If IsNull(mXSYASYU_COMMENT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYASYU_COMMENT = NULL --車種ｺﾒﾝﾄ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYASYU_COMMENT = NULL --車種ｺﾒﾝﾄ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYASYU_COMMENT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYASYU_COMMENT = :" & Ubound(strBindField) - 1 & " --車種ｺﾒﾝﾄ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYASYU_COMMENT = :" & Ubound(strBindField) - 1 & " --車種ｺﾒﾝﾄ")
        End If
        intCount = intCount + 1
        If IsNull(mXGYOUSYA_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XGYOUSYA_CD = NULL --物流業者ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XGYOUSYA_CD = NULL --物流業者ｺｰﾄﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XGYOUSYA_CD = :" & Ubound(strBindField) - 1 & " --物流業者ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XGYOUSYA_CD = :" & Ubound(strBindField) - 1 & " --物流業者ｺｰﾄﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mXLOADER_POSSIBLE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XLOADER_POSSIBLE = NULL --ﾛｰﾀﾞ対応可否")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XLOADER_POSSIBLE = NULL --ﾛｰﾀﾞ対応可否")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXLOADER_POSSIBLE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XLOADER_POSSIBLE = :" & Ubound(strBindField) - 1 & " --ﾛｰﾀﾞ対応可否")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XLOADER_POSSIBLE = :" & Ubound(strBindField) - 1 & " --ﾛｰﾀﾞ対応可否")
        End If
        intCount = intCount + 1
        If IsNull(mXSYARYOU_MODE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYARYOU_MODE = NULL --ﾛｰﾀﾞﾓｰﾄﾞ(ﾌﾟｯｼｬｰ比)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYARYOU_MODE = NULL --ﾛｰﾀﾞﾓｰﾄﾞ(ﾌﾟｯｼｬｰ比)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYARYOU_MODE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYARYOU_MODE = :" & Ubound(strBindField) - 1 & " --ﾛｰﾀﾞﾓｰﾄﾞ(ﾌﾟｯｼｬｰ比)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYARYOU_MODE = :" & Ubound(strBindField) - 1 & " --ﾛｰﾀﾞﾓｰﾄﾞ(ﾌﾟｯｼｬｰ比)")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(XSYARYOU_NO) = True Then
            strSQL.Append(vbCrLf & "    AND XSYARYOU_NO IS NULL --車輌番号")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYARYOU_NO
            strSQL.Append(vbCrLf & "    AND XSYARYOU_NO = :" & UBound(strBindField) - 1 & " --車輌番号")
        End If


        '***********************
        'ﾊﾞｲﾝﾄﾞ変数定義
        '***********************
        objParameter = Nothing
        ReDim Preserve objParameter(2, UBound(strBindField) - 1)
        Dim ii As Integer
        For ii = LBound(strBindField) + 1 To UBound(strBindField)
            objParameter(0, ii - 1) = strBindField(ii)
            objParameter(1, ii - 1) = objBindValue(ii)
        Next ii


        '***********************
        '更新
        '***********************
        ObjDb.Parameter = objParameter
        intRetSQL = ObjDb.Execute(strSQL.ToString)
        If intRetSQL = -1 Then
            '(SQLｴﾗｰ)
            strMsg = ERRMSG_ERR_UPDATE & " " & ObjDb.ErrMsg & "[" & Replace(strSQL.ToString, vbCrLf, "") & "]"
            Throw New UserException(strMsg)
        End If
        If intRetSQL < 1 Then
            '(対象行無し)
            strMsg = ERRMSG_ERR_UPDATE & "[対象行無し]"
            Throw New UserException(strMsg)
        End If


    End Sub
#End Region
#Region "  ﾃﾞｰﾀ追加                     "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀ追加
    ''' </summary>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub ADD_XMST_SYARYOU()
        Dim strSQL As New StringBuilder     'SQL文
        Dim strMsg As String                'ﾒｯｾｰｼﾞ
        Dim intRetSQL As Integer            'SQL実行戻り値
        Dim objParameter(1, 0) As Object
        Dim strBindField(0) As String
        Dim objBindValue(0) As Object


        '***********************
        'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
        '***********************
        If 1 <> 1 Then
        ElseIf IsNull(mXSYARYOU_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[車輌番号]"
            Throw New UserException(strMsg)
        End If


        '***********************
        '追加SQL作成
        '***********************
        strBindField = Nothing
        objBindValue = Nothing
        ReDim Preserve strBindField(0)
        ReDim Preserve objBindValue(0)
        strSQL.Append(vbCrLf & "INSERT INTO")
        strSQL.Append(vbCrLf & "    XMST_SYARYOU")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
        If IsNull(mXSYARYOU_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --車輌番号")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --車輌番号")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYARYOU_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --車輌番号")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --車輌番号")
        End If
        intCount = intCount + 1
        If IsNull(mXTUMI_HOUKOU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --積込方向")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --積込方向")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_HOUKOU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --積込方向")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --積込方向")
        End If
        intCount = intCount + 1
        If IsNull(mXTUMI_HOUHOU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --積込方法")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --積込方法")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_HOUHOU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --積込方法")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --積込方法")
        End If
        intCount = intCount + 1
        If IsNull(mXNOT_USER) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --未使用区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --未使用区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXNOT_USER
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --未使用区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --未使用区分")
        End If
        intCount = intCount + 1
        If IsNull(mFENTRY_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --登録日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --登録日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --登録日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --登録日時")
        End If
        intCount = intCount + 1
        If IsNull(mXCARD_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｶｰﾄﾞ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｶｰﾄﾞ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCARD_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｶｰﾄﾞ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｶｰﾄﾞ№")
        End If
        intCount = intCount + 1
        If IsNull(mXSYASYU_KBN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --車種区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --車種区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYASYU_KBN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --車種区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --車種区分")
        End If
        intCount = intCount + 1
        If IsNull(mXSYASYU_COMMENT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --車種ｺﾒﾝﾄ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --車種ｺﾒﾝﾄ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYASYU_COMMENT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --車種ｺﾒﾝﾄ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --車種ｺﾒﾝﾄ")
        End If
        intCount = intCount + 1
        If IsNull(mXGYOUSYA_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --物流業者ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --物流業者ｺｰﾄﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --物流業者ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --物流業者ｺｰﾄﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mXLOADER_POSSIBLE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾛｰﾀﾞ対応可否")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾛｰﾀﾞ対応可否")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXLOADER_POSSIBLE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾛｰﾀﾞ対応可否")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾛｰﾀﾞ対応可否")
        End If
        intCount = intCount + 1
        If IsNull(mXSYARYOU_MODE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾛｰﾀﾞﾓｰﾄﾞ(ﾌﾟｯｼｬｰ比)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾛｰﾀﾞﾓｰﾄﾞ(ﾌﾟｯｼｬｰ比)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYARYOU_MODE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾛｰﾀﾞﾓｰﾄﾞ(ﾌﾟｯｼｬｰ比)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾛｰﾀﾞﾓｰﾄﾞ(ﾌﾟｯｼｬｰ比)")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " )")


        '***********************
        'ﾊﾞｲﾝﾄﾞ変数定義
        '***********************
        objParameter = Nothing
        ReDim Preserve objParameter(2, UBound(strBindField) - 1)
        Dim ii As Integer
        For ii = LBound(strBindField) + 1 To UBound(strBindField)
            objParameter(0, ii - 1) = strBindField(ii)
            objParameter(1, ii - 1) = objBindValue(ii)
        Next ii


        '***********************
        '追加
        '***********************
        ObjDb.Parameter = objParameter
        intRetSQL = ObjDb.Execute(strSQL.ToString)
        If intRetSQL = -1 Then
            '(SQLｴﾗｰ)
            strMsg = ERRMSG_ERR_ADD & " " & ObjDb.ErrMsg & "[" & Replace(strSQL.ToString, vbCrLf, "") & "]"
            Throw New UserException(strMsg)
        End If


    End Sub
#End Region
#Region "  ﾃﾞｰﾀ削除                     "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀ削除
    ''' </summary>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub DELETE_XMST_SYARYOU()
        Dim strSQL As New StringBuilder     'SQL文
        Dim strMsg As String                'ﾒｯｾｰｼﾞ
        Dim intRetSQL As Integer            'SQL実行戻り値
        Dim objParameter(1, 0) As Object
        Dim strBindField(0) As String
        Dim objBindValue(0) As Object


        '***********************
        'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
        '***********************
        If 1 <> 1 Then
        ElseIf IsNull(mXSYARYOU_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[車輌番号]"
            Throw New UserException(strMsg)
        End If


        '***********************
        '削除SQL作成
        '***********************
        strBindField = Nothing
        objBindValue = Nothing
        ReDim Preserve strBindField(0)
        ReDim Preserve objBindValue(0)
        strSQL.Append(vbCrLf & "DELETE")
        strSQL.Append(vbCrLf & " FROM")
        strSQL.Append(vbCrLf & "    XMST_SYARYOU")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(XSYARYOU_NO) = True Then
            strSQL.Append(vbCrLf & "    AND XSYARYOU_NO IS NULL --車輌番号")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYARYOU_NO
            strSQL.Append(vbCrLf & "    AND XSYARYOU_NO = :" & UBound(strBindField) - 1 & " --車輌番号")
        End If


        '***********************
        'ﾊﾞｲﾝﾄﾞ変数定義
        '***********************
        objParameter = Nothing
        ReDim Preserve objParameter(2, UBound(strBindField) - 1)
        Dim ii As Integer
        For ii = LBound(strBindField) + 1 To UBound(strBindField)
            objParameter(0, ii - 1) = strBindField(ii)
            objParameter(1, ii - 1) = objBindValue(ii)
        Next ii


        '***********************
        '削除
        '***********************
        ObjDb.Parameter = objParameter
        intRetSQL = ObjDb.Execute(strSQL.ToString)
        If intRetSQL = -1 Then
            '(SQLｴﾗｰ)
            strMsg = ERRMSG_ERR_DELETE & " " & ObjDb.ErrMsg & "[" & Replace(strSQL.ToString, vbCrLf, "") & "]"
            Throw New UserException(strMsg)
        End If


    End Sub
#End Region
#Region "  ﾃﾞｰﾀ削除(複数ﾚｺｰﾄﾞ)          "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀ削除
    ''' </summary>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub DELETE_XMST_SYARYOU_ANY()
        Dim strSQL As New StringBuilder     'SQL文
        Dim strMsg As String                'ﾒｯｾｰｼﾞ
        Dim intRetSQL As Integer            'SQL実行戻り値
        Dim objParameter(1, 0) As Object
        Dim strBindField(0) As String
        Dim objBindValue(0) As Object


        '***********************
        '削除SQL作成
        '***********************
        strBindField = Nothing
        objBindValue = Nothing
        ReDim Preserve strBindField(0)
        ReDim Preserve objBindValue(0)
        strSQL.Append(vbCrLf & "DELETE")
        strSQL.Append(vbCrLf & " FROM")
        strSQL.Append(vbCrLf & "    XMST_SYARYOU")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(XSYARYOU_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYARYOU_NO
            strSQL.Append(vbCrLf & "    AND XSYARYOU_NO = :" & UBound(strBindField) - 1 & " --車輌番号")
        End If
        If IsNotNull(XTUMI_HOUKOU) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_HOUKOU
            strSQL.Append(vbCrLf & "    AND XTUMI_HOUKOU = :" & UBound(strBindField) - 1 & " --積込方向")
        End If
        If IsNotNull(XTUMI_HOUHOU) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_HOUHOU
            strSQL.Append(vbCrLf & "    AND XTUMI_HOUHOU = :" & UBound(strBindField) - 1 & " --積込方法")
        End If
        If IsNotNull(XNOT_USER) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXNOT_USER
            strSQL.Append(vbCrLf & "    AND XNOT_USER = :" & UBound(strBindField) - 1 & " --未使用区分")
        End If
        If IsNotNull(FENTRY_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --登録日時")
        End If
        If IsNotNull(XCARD_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCARD_NO
            strSQL.Append(vbCrLf & "    AND XCARD_NO = :" & UBound(strBindField) - 1 & " --ｶｰﾄﾞ№")
        End If
        If IsNotNull(XSYASYU_KBN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYASYU_KBN
            strSQL.Append(vbCrLf & "    AND XSYASYU_KBN = :" & UBound(strBindField) - 1 & " --車種区分")
        End If
        If IsNotNull(XSYASYU_COMMENT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYASYU_COMMENT
            strSQL.Append(vbCrLf & "    AND XSYASYU_COMMENT = :" & UBound(strBindField) - 1 & " --車種ｺﾒﾝﾄ")
        End If
        If IsNotNull(XGYOUSYA_CD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_CD
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_CD = :" & UBound(strBindField) - 1 & " --物流業者ｺｰﾄﾞ")
        End If
        If IsNotNull(XLOADER_POSSIBLE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXLOADER_POSSIBLE
            strSQL.Append(vbCrLf & "    AND XLOADER_POSSIBLE = :" & UBound(strBindField) - 1 & " --ﾛｰﾀﾞ対応可否")
        End If
        If IsNotNull(XSYARYOU_MODE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYARYOU_MODE
            strSQL.Append(vbCrLf & "    AND XSYARYOU_MODE = :" & UBound(strBindField) - 1 & " --ﾛｰﾀﾞﾓｰﾄﾞ(ﾌﾟｯｼｬｰ比)")
        End If


        '***********************
        'ﾊﾞｲﾝﾄﾞ変数定義
        '***********************
        objParameter = Nothing
        ReDim Preserve objParameter(2, UBound(strBindField) - 1)
        Dim ii As Integer
        For ii = LBound(strBindField) + 1 To UBound(strBindField)
            objParameter(0, ii - 1) = strBindField(ii)
            objParameter(1, ii - 1) = objBindValue(ii)
        Next ii


        '***********************
        '削除
        '***********************
        ObjDb.Parameter = objParameter
        intRetSQL = ObjDb.Execute(strSQL.ToString)
        If intRetSQL = -1 Then
            '(SQLｴﾗｰ)
            strMsg = ERRMSG_ERR_DELETE & " " & ObjDb.ErrMsg & "[" & Replace(strSQL.ToString, vbCrLf, "") & "]"
            Throw New UserException(strMsg)
        End If


    End Sub
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨｺﾋﾟｰ                  "
    Public Sub COPY_PROPERTY(ByVal objObject As Object)


        '***********************
        'ﾌﾟﾛﾊﾟﾃｨ変数へｾｯﾄ
        '***********************
        Dim objType As Type = objObject.GetType
        If IsNothing(objType.GetProperty("XSYARYOU_NO")) = False Then mXSYARYOU_NO = objObject.XSYARYOU_NO '車輌番号
        If IsNothing(objType.GetProperty("XTUMI_HOUKOU")) = False Then mXTUMI_HOUKOU = objObject.XTUMI_HOUKOU '積込方向
        If IsNothing(objType.GetProperty("XTUMI_HOUHOU")) = False Then mXTUMI_HOUHOU = objObject.XTUMI_HOUHOU '積込方法
        If IsNothing(objType.GetProperty("XNOT_USER")) = False Then mXNOT_USER = objObject.XNOT_USER '未使用区分
        If IsNothing(objType.GetProperty("FENTRY_DT")) = False Then mFENTRY_DT = objObject.FENTRY_DT '登録日時
        If IsNothing(objType.GetProperty("XCARD_NO")) = False Then mXCARD_NO = objObject.XCARD_NO 'ｶｰﾄﾞ№
        If IsNothing(objType.GetProperty("XSYASYU_KBN")) = False Then mXSYASYU_KBN = objObject.XSYASYU_KBN '車種区分
        If IsNothing(objType.GetProperty("XSYASYU_COMMENT")) = False Then mXSYASYU_COMMENT = objObject.XSYASYU_COMMENT '車種ｺﾒﾝﾄ
        If IsNothing(objType.GetProperty("XGYOUSYA_CD")) = False Then mXGYOUSYA_CD = objObject.XGYOUSYA_CD '物流業者ｺｰﾄﾞ
        If IsNothing(objType.GetProperty("XLOADER_POSSIBLE")) = False Then mXLOADER_POSSIBLE = objObject.XLOADER_POSSIBLE 'ﾛｰﾀﾞ対応可否
        If IsNothing(objType.GetProperty("XSYARYOU_MODE")) = False Then mXSYARYOU_MODE = objObject.XSYARYOU_MODE 'ﾛｰﾀﾞﾓｰﾄﾞ(ﾌﾟｯｼｬｰ比)

    End Sub
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨｸﾘｱ                   "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾌﾟﾛﾊﾟﾃｨｸﾘｱ
    ''' </summary>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub CLEAR_PROPERTY()


        '***********************
        'ﾌﾟﾛﾊﾟﾃｨ変数ｸﾘｱ
        '***********************
        Call ARYME_CLEAR()
        mstrUSER_SQL = Nothing
        mXSYARYOU_NO = Nothing
        mXTUMI_HOUKOU = Nothing
        mXTUMI_HOUHOU = Nothing
        mXNOT_USER = Nothing
        mFENTRY_DT = Nothing
        mXCARD_NO = Nothing
        mXSYASYU_KBN = Nothing
        mXSYASYU_COMMENT = Nothing
        mXGYOUSYA_CD = Nothing
        mXLOADER_POSSIBLE = Nothing
        mXSYARYOU_MODE = Nothing


    End Sub
#End Region
#Region "  AryMeｸﾘｱ                     "
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

#Region "  ﾃﾞｰﾀ→変数                   "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀ→変数
    ''' </summary>
    ''' <param name="objRow">ﾃﾞｰﾀﾚｺｰﾄﾞｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub SET_DATA(ByVal objRow As DataRow)


        '***********************
        'ﾃﾞｰﾀｾｯﾄ
        '***********************
        mXSYARYOU_NO = TO_INTEGER_NULLABLE(objRow("XSYARYOU_NO"))
        mXTUMI_HOUKOU = TO_INTEGER_NULLABLE(objRow("XTUMI_HOUKOU"))
        mXTUMI_HOUHOU = TO_INTEGER_NULLABLE(objRow("XTUMI_HOUHOU"))
        mXNOT_USER = TO_INTEGER_NULLABLE(objRow("XNOT_USER"))
        mFENTRY_DT = TO_DATE_NULLABLE(objRow("FENTRY_DT"))
        mXCARD_NO = TO_STRING_NULLABLE(objRow("XCARD_NO"))
        mXSYASYU_KBN = TO_STRING_NULLABLE(objRow("XSYASYU_KBN"))
        mXSYASYU_COMMENT = TO_STRING_NULLABLE(objRow("XSYASYU_COMMENT"))
        mXGYOUSYA_CD = TO_STRING_NULLABLE(objRow("XGYOUSYA_CD"))
        mXLOADER_POSSIBLE = TO_INTEGER_NULLABLE(objRow("XLOADER_POSSIBLE"))
        mXSYARYOU_MODE = TO_INTEGER_NULLABLE(objRow("XSYARYOU_MODE"))


    End Sub
#End Region
#Region "  ｴﾗｰﾒｯｾｰｼﾞ文字列作成01        "
    '''**********************************************************************************************
    ''' <summary>
    ''' ｴﾗｰﾒｯｾｰｼﾞ文字列作成01
    ''' </summary>
    ''' <param name="strMsg">ｴﾗｰﾒｯｾｰｼﾞ文字列</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub MAKE_ERRMSG01(ByRef strMsg As String)


        '***********************
        'ﾃﾞｰﾀｾｯﾄ
        '***********************
        strMsg = "ﾚｺｰﾄﾞが見つかりませんでした。"
        strMsg &= "[ﾃｰﾌﾞﾙ名:車輌ﾏｽﾀ]"
        If IsNotNull(XSYARYOU_NO) Then
            strMsg &= "[車輌番号:" & XSYARYOU_NO & "]"
        End If
        If IsNotNull(XTUMI_HOUKOU) Then
            strMsg &= "[積込方向:" & XTUMI_HOUKOU & "]"
        End If
        If IsNotNull(XTUMI_HOUHOU) Then
            strMsg &= "[積込方法:" & XTUMI_HOUHOU & "]"
        End If
        If IsNotNull(XNOT_USER) Then
            strMsg &= "[未使用区分:" & XNOT_USER & "]"
        End If
        If IsNotNull(FENTRY_DT) Then
            strMsg &= "[登録日時:" & FENTRY_DT & "]"
        End If
        If IsNotNull(XCARD_NO) Then
            strMsg &= "[ｶｰﾄﾞ№:" & XCARD_NO & "]"
        End If
        If IsNotNull(XSYASYU_KBN) Then
            strMsg &= "[車種区分:" & XSYASYU_KBN & "]"
        End If
        If IsNotNull(XSYASYU_COMMENT) Then
            strMsg &= "[車種ｺﾒﾝﾄ:" & XSYASYU_COMMENT & "]"
        End If
        If IsNotNull(XGYOUSYA_CD) Then
            strMsg &= "[物流業者ｺｰﾄﾞ:" & XGYOUSYA_CD & "]"
        End If
        If IsNotNull(XLOADER_POSSIBLE) Then
            strMsg &= "[ﾛｰﾀﾞ対応可否:" & XLOADER_POSSIBLE & "]"
        End If
        If IsNotNull(XSYARYOU_MODE) Then
            strMsg &= "[ﾛｰﾀﾞﾓｰﾄﾞ(ﾌﾟｯｼｬｰ比):" & XSYARYOU_MODE & "]"
        End If


    End Sub
#End Region
    '↑↑↑自動生成部
    '**********************************************************************************************

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ共通

    '↑↑↑ｼｽﾃﾑ共通
    '**********************************************************************************************


    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
