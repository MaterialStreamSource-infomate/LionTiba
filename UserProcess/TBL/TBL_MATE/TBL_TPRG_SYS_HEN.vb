'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' 【名称】MaterialStreamﾃｰﾌﾞﾙｸﾗｽ
' 【機能】ｼｽﾃﾑ変数ﾃｰﾌﾞﾙｸﾗｽ
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
''' ｼｽﾃﾑ変数ﾃｰﾌﾞﾙｸﾗｽ
''' </summary>
Public Class TBL_TPRG_SYS_HEN
    Inherits clsTemplateTable

    '**********************************************************************************************
    '↓↓↓自動生成部
#Region "  ｸﾗｽ変数定義                  "
    'ﾌﾟﾛﾊﾟﾃｨ
    Private mobjAryMe As TBL_TPRG_SYS_HEN()                                      'ｼｽﾃﾑ変数
    Private mstrUSER_SQL As String                                               'ﾕｰｻﾞｰSQL
    Private mORDER_BY As String                                                  'OrderBy句
    Private mWHERE As String                                                     'Where句
    Private mFHENSU_ID As String                                                 '変数ID
    Private mFHENSU_NAME As String                                               '変数名称
    Private mFHENSU_FLAG As Nullable(Of Integer)                                 'ﾒﾝﾃ可能ﾌﾗｸﾞ
    Private mFHENSU_KIND As Nullable(Of Integer)                                 'ﾃﾞｰﾀ種別
    Private mFHENSU_INT As Nullable(Of Integer)                                  '整数ﾃﾞｰﾀ
    Private mFHENSU_REAL As Nullable(Of Decimal)                                 '実数ﾃﾞｰﾀ
    Private mFHENSU_CHAR As String                                               '文字ﾃﾞｰﾀ
    Private mFHENSU_DATE As Nullable(Of Date)                                    '日付ﾃﾞｰﾀ
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                  "
    ''' <summary>
    ''' ｼｽﾃﾑ変数 (自ｸﾗｽ型配列)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_TPRG_SYS_HEN()
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
    ''' 変数ID
    ''' </summary>
    Public Property FHENSU_ID() As String
        Get
            Return mFHENSU_ID
        End Get
        Set(ByVal Value As String)
            mFHENSU_ID = Value
        End Set
    End Property
    ''' <summary>
    ''' 変数名称
    ''' </summary>
    Public Property FHENSU_NAME() As String
        Get
            Return mFHENSU_NAME
        End Get
        Set(ByVal Value As String)
            mFHENSU_NAME = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾒﾝﾃ可能ﾌﾗｸﾞ
    ''' </summary>
    Public Property FHENSU_FLAG() As Nullable(Of Integer)
        Get
            Return mFHENSU_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFHENSU_FLAG = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾃﾞｰﾀ種別
    ''' </summary>
    Public Property FHENSU_KIND() As Nullable(Of Integer)
        Get
            Return mFHENSU_KIND
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFHENSU_KIND = Value
        End Set
    End Property
    ''' <summary>
    ''' 整数ﾃﾞｰﾀ
    ''' </summary>
    Public Property FHENSU_INT() As Nullable(Of Integer)
        Get
            Return mFHENSU_INT
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFHENSU_INT = Value
        End Set
    End Property
    ''' <summary>
    ''' 実数ﾃﾞｰﾀ
    ''' </summary>
    Public Property FHENSU_REAL() As Nullable(Of Decimal)
        Get
            Return mFHENSU_REAL
        End Get
        Set(ByVal Value As Nullable(Of Decimal))
            mFHENSU_REAL = Value
        End Set
    End Property
    ''' <summary>
    ''' 文字ﾃﾞｰﾀ
    ''' </summary>
    Public Property FHENSU_CHAR() As String
        Get
            Return mFHENSU_CHAR
        End Get
        Set(ByVal Value As String)
            mFHENSU_CHAR = Value
        End Set
    End Property
    ''' <summary>
    ''' 日付ﾃﾞｰﾀ
    ''' </summary>
    Public Property FHENSU_DATE() As Nullable(Of Date)
        Get
            Return mFHENSU_DATE
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mFHENSU_DATE = Value
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
    Public Function GET_TPRG_SYS_HEN(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    TPRG_SYS_HEN")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FHENSU_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_ID
            strSQL.Append(vbCrLf & "    AND FHENSU_ID = :" & UBound(strBindField) - 1 & " --変数ID")
        End If
        If IsNull(FHENSU_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_NAME
            strSQL.Append(vbCrLf & "    AND FHENSU_NAME = :" & UBound(strBindField) - 1 & " --変数名称")
        End If
        If IsNull(FHENSU_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_FLAG
            strSQL.Append(vbCrLf & "    AND FHENSU_FLAG = :" & UBound(strBindField) - 1 & " --ﾒﾝﾃ可能ﾌﾗｸﾞ")
        End If
        If IsNull(FHENSU_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_KIND
            strSQL.Append(vbCrLf & "    AND FHENSU_KIND = :" & UBound(strBindField) - 1 & " --ﾃﾞｰﾀ種別")
        End If
        If IsNull(FHENSU_INT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_INT
            strSQL.Append(vbCrLf & "    AND FHENSU_INT = :" & UBound(strBindField) - 1 & " --整数ﾃﾞｰﾀ")
        End If
        If IsNull(FHENSU_REAL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_REAL
            strSQL.Append(vbCrLf & "    AND FHENSU_REAL = :" & UBound(strBindField) - 1 & " --実数ﾃﾞｰﾀ")
        End If
        If IsNull(FHENSU_CHAR) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_CHAR
            strSQL.Append(vbCrLf & "    AND FHENSU_CHAR = :" & UBound(strBindField) - 1 & " --文字ﾃﾞｰﾀ")
        End If
        If IsNull(FHENSU_DATE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_DATE
            strSQL.Append(vbCrLf & "    AND FHENSU_DATE = :" & UBound(strBindField) - 1 & " --日付ﾃﾞｰﾀ")
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
        strDataSetName = "TPRG_SYS_HEN"
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
    Public Function GET_TPRG_SYS_HEN_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    TPRG_SYS_HEN")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FHENSU_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_ID
            strSQL.Append(vbCrLf & "    AND FHENSU_ID = :" & UBound(strBindField) - 1 & " --変数ID")
        End If
        If IsNull(FHENSU_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_NAME
            strSQL.Append(vbCrLf & "    AND FHENSU_NAME = :" & UBound(strBindField) - 1 & " --変数名称")
        End If
        If IsNull(FHENSU_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_FLAG
            strSQL.Append(vbCrLf & "    AND FHENSU_FLAG = :" & UBound(strBindField) - 1 & " --ﾒﾝﾃ可能ﾌﾗｸﾞ")
        End If
        If IsNull(FHENSU_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_KIND
            strSQL.Append(vbCrLf & "    AND FHENSU_KIND = :" & UBound(strBindField) - 1 & " --ﾃﾞｰﾀ種別")
        End If
        If IsNull(FHENSU_INT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_INT
            strSQL.Append(vbCrLf & "    AND FHENSU_INT = :" & UBound(strBindField) - 1 & " --整数ﾃﾞｰﾀ")
        End If
        If IsNull(FHENSU_REAL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_REAL
            strSQL.Append(vbCrLf & "    AND FHENSU_REAL = :" & UBound(strBindField) - 1 & " --実数ﾃﾞｰﾀ")
        End If
        If IsNull(FHENSU_CHAR) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_CHAR
            strSQL.Append(vbCrLf & "    AND FHENSU_CHAR = :" & UBound(strBindField) - 1 & " --文字ﾃﾞｰﾀ")
        End If
        If IsNull(FHENSU_DATE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_DATE
            strSQL.Append(vbCrLf & "    AND FHENSU_DATE = :" & UBound(strBindField) - 1 & " --日付ﾃﾞｰﾀ")
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
        strDataSetName = "TPRG_SYS_HEN"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TPRG_SYS_HEN(Owner, objDb, objDbLog)
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
    Public Function GET_TPRG_SYS_HEN_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "TPRG_SYS_HEN"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TPRG_SYS_HEN(Owner, objDb, objDbLog)
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
    Public Function GET_TPRG_SYS_HEN_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    TPRG_SYS_HEN")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FHENSU_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_ID
            strSQL.Append(vbCrLf & "    AND FHENSU_ID = :" & UBound(strBindField) - 1 & " --変数ID")
        End If
        If IsNull(FHENSU_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_NAME
            strSQL.Append(vbCrLf & "    AND FHENSU_NAME = :" & UBound(strBindField) - 1 & " --変数名称")
        End If
        If IsNull(FHENSU_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_FLAG
            strSQL.Append(vbCrLf & "    AND FHENSU_FLAG = :" & UBound(strBindField) - 1 & " --ﾒﾝﾃ可能ﾌﾗｸﾞ")
        End If
        If IsNull(FHENSU_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_KIND
            strSQL.Append(vbCrLf & "    AND FHENSU_KIND = :" & UBound(strBindField) - 1 & " --ﾃﾞｰﾀ種別")
        End If
        If IsNull(FHENSU_INT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_INT
            strSQL.Append(vbCrLf & "    AND FHENSU_INT = :" & UBound(strBindField) - 1 & " --整数ﾃﾞｰﾀ")
        End If
        If IsNull(FHENSU_REAL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_REAL
            strSQL.Append(vbCrLf & "    AND FHENSU_REAL = :" & UBound(strBindField) - 1 & " --実数ﾃﾞｰﾀ")
        End If
        If IsNull(FHENSU_CHAR) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_CHAR
            strSQL.Append(vbCrLf & "    AND FHENSU_CHAR = :" & UBound(strBindField) - 1 & " --文字ﾃﾞｰﾀ")
        End If
        If IsNull(FHENSU_DATE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_DATE
            strSQL.Append(vbCrLf & "    AND FHENSU_DATE = :" & UBound(strBindField) - 1 & " --日付ﾃﾞｰﾀ")
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
        strDataSetName = "TPRG_SYS_HEN"
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
    Public Sub UPDATE_TPRG_SYS_HEN()
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
        ElseIf IsNull(mFHENSU_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[変数ID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFHENSU_FLAG) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾒﾝﾃ可能ﾌﾗｸﾞ]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFHENSU_KIND) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾃﾞｰﾀ種別]"
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
        strSQL.Append(vbCrLf & "    TPRG_SYS_HEN")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
        If IsNull(mFHENSU_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHENSU_ID = NULL --変数ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHENSU_ID = NULL --変数ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHENSU_ID = :" & Ubound(strBindField) - 1 & " --変数ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHENSU_ID = :" & Ubound(strBindField) - 1 & " --変数ID")
        End If
        intCount = intCount + 1
        If IsNull(mFHENSU_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHENSU_NAME = NULL --変数名称")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHENSU_NAME = NULL --変数名称")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHENSU_NAME = :" & Ubound(strBindField) - 1 & " --変数名称")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHENSU_NAME = :" & Ubound(strBindField) - 1 & " --変数名称")
        End If
        intCount = intCount + 1
        If IsNull(mFHENSU_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHENSU_FLAG = NULL --ﾒﾝﾃ可能ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHENSU_FLAG = NULL --ﾒﾝﾃ可能ﾌﾗｸﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHENSU_FLAG = :" & Ubound(strBindField) - 1 & " --ﾒﾝﾃ可能ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHENSU_FLAG = :" & Ubound(strBindField) - 1 & " --ﾒﾝﾃ可能ﾌﾗｸﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFHENSU_KIND) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHENSU_KIND = NULL --ﾃﾞｰﾀ種別")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHENSU_KIND = NULL --ﾃﾞｰﾀ種別")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_KIND
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHENSU_KIND = :" & Ubound(strBindField) - 1 & " --ﾃﾞｰﾀ種別")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHENSU_KIND = :" & Ubound(strBindField) - 1 & " --ﾃﾞｰﾀ種別")
        End If
        intCount = intCount + 1
        If IsNull(mFHENSU_INT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHENSU_INT = NULL --整数ﾃﾞｰﾀ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHENSU_INT = NULL --整数ﾃﾞｰﾀ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_INT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHENSU_INT = :" & Ubound(strBindField) - 1 & " --整数ﾃﾞｰﾀ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHENSU_INT = :" & Ubound(strBindField) - 1 & " --整数ﾃﾞｰﾀ")
        End If
        intCount = intCount + 1
        If IsNull(mFHENSU_REAL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHENSU_REAL = NULL --実数ﾃﾞｰﾀ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHENSU_REAL = NULL --実数ﾃﾞｰﾀ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_REAL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHENSU_REAL = :" & Ubound(strBindField) - 1 & " --実数ﾃﾞｰﾀ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHENSU_REAL = :" & Ubound(strBindField) - 1 & " --実数ﾃﾞｰﾀ")
        End If
        intCount = intCount + 1
        If IsNull(mFHENSU_CHAR) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHENSU_CHAR = NULL --文字ﾃﾞｰﾀ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHENSU_CHAR = NULL --文字ﾃﾞｰﾀ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_CHAR
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHENSU_CHAR = :" & Ubound(strBindField) - 1 & " --文字ﾃﾞｰﾀ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHENSU_CHAR = :" & Ubound(strBindField) - 1 & " --文字ﾃﾞｰﾀ")
        End If
        intCount = intCount + 1
        If IsNull(mFHENSU_DATE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHENSU_DATE = NULL --日付ﾃﾞｰﾀ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHENSU_DATE = NULL --日付ﾃﾞｰﾀ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_DATE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHENSU_DATE = :" & Ubound(strBindField) - 1 & " --日付ﾃﾞｰﾀ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHENSU_DATE = :" & Ubound(strBindField) - 1 & " --日付ﾃﾞｰﾀ")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FHENSU_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FHENSU_ID IS NULL --変数ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_ID
            strSQL.Append(vbCrLf & "    AND FHENSU_ID = :" & UBound(strBindField) - 1 & " --変数ID")
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
    Public Sub ADD_TPRG_SYS_HEN()
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
        ElseIf IsNull(mFHENSU_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[変数ID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFHENSU_FLAG) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾒﾝﾃ可能ﾌﾗｸﾞ]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFHENSU_KIND) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾃﾞｰﾀ種別]"
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
        strSQL.Append(vbCrLf & "    TPRG_SYS_HEN")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
        If IsNull(mFHENSU_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --変数ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --変数ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --変数ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --変数ID")
        End If
        intCount = intCount + 1
        If IsNull(mFHENSU_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --変数名称")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --変数名称")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --変数名称")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --変数名称")
        End If
        intCount = intCount + 1
        If IsNull(mFHENSU_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾒﾝﾃ可能ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾒﾝﾃ可能ﾌﾗｸﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾒﾝﾃ可能ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾒﾝﾃ可能ﾌﾗｸﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFHENSU_KIND) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾃﾞｰﾀ種別")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾃﾞｰﾀ種別")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_KIND
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾃﾞｰﾀ種別")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾃﾞｰﾀ種別")
        End If
        intCount = intCount + 1
        If IsNull(mFHENSU_INT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --整数ﾃﾞｰﾀ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --整数ﾃﾞｰﾀ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_INT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --整数ﾃﾞｰﾀ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --整数ﾃﾞｰﾀ")
        End If
        intCount = intCount + 1
        If IsNull(mFHENSU_REAL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --実数ﾃﾞｰﾀ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --実数ﾃﾞｰﾀ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_REAL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --実数ﾃﾞｰﾀ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --実数ﾃﾞｰﾀ")
        End If
        intCount = intCount + 1
        If IsNull(mFHENSU_CHAR) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --文字ﾃﾞｰﾀ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --文字ﾃﾞｰﾀ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_CHAR
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --文字ﾃﾞｰﾀ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --文字ﾃﾞｰﾀ")
        End If
        intCount = intCount + 1
        If IsNull(mFHENSU_DATE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --日付ﾃﾞｰﾀ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --日付ﾃﾞｰﾀ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_DATE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --日付ﾃﾞｰﾀ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --日付ﾃﾞｰﾀ")
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
    Public Sub DELETE_TPRG_SYS_HEN()
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
        ElseIf IsNull(mFHENSU_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[変数ID]"
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
        strSQL.Append(vbCrLf & "    TPRG_SYS_HEN")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FHENSU_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FHENSU_ID IS NULL --変数ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_ID
            strSQL.Append(vbCrLf & "    AND FHENSU_ID = :" & UBound(strBindField) - 1 & " --変数ID")
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
    Public Sub DELETE_TPRG_SYS_HEN_ANY()
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
        strSQL.Append(vbCrLf & "    TPRG_SYS_HEN")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(FHENSU_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_ID
            strSQL.Append(vbCrLf & "    AND FHENSU_ID = :" & UBound(strBindField) - 1 & " --変数ID")
        End If
        If IsNotNull(FHENSU_NAME) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_NAME
            strSQL.Append(vbCrLf & "    AND FHENSU_NAME = :" & UBound(strBindField) - 1 & " --変数名称")
        End If
        If IsNotNull(FHENSU_FLAG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_FLAG
            strSQL.Append(vbCrLf & "    AND FHENSU_FLAG = :" & UBound(strBindField) - 1 & " --ﾒﾝﾃ可能ﾌﾗｸﾞ")
        End If
        If IsNotNull(FHENSU_KIND) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_KIND
            strSQL.Append(vbCrLf & "    AND FHENSU_KIND = :" & UBound(strBindField) - 1 & " --ﾃﾞｰﾀ種別")
        End If
        If IsNotNull(FHENSU_INT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_INT
            strSQL.Append(vbCrLf & "    AND FHENSU_INT = :" & UBound(strBindField) - 1 & " --整数ﾃﾞｰﾀ")
        End If
        If IsNotNull(FHENSU_REAL) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_REAL
            strSQL.Append(vbCrLf & "    AND FHENSU_REAL = :" & UBound(strBindField) - 1 & " --実数ﾃﾞｰﾀ")
        End If
        If IsNotNull(FHENSU_CHAR) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_CHAR
            strSQL.Append(vbCrLf & "    AND FHENSU_CHAR = :" & UBound(strBindField) - 1 & " --文字ﾃﾞｰﾀ")
        End If
        If IsNotNull(FHENSU_DATE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHENSU_DATE
            strSQL.Append(vbCrLf & "    AND FHENSU_DATE = :" & UBound(strBindField) - 1 & " --日付ﾃﾞｰﾀ")
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
        If IsNothing(objType.GetProperty("FHENSU_ID")) = False Then mFHENSU_ID = objObject.FHENSU_ID '変数ID
        If IsNothing(objType.GetProperty("FHENSU_NAME")) = False Then mFHENSU_NAME = objObject.FHENSU_NAME '変数名称
        If IsNothing(objType.GetProperty("FHENSU_FLAG")) = False Then mFHENSU_FLAG = objObject.FHENSU_FLAG 'ﾒﾝﾃ可能ﾌﾗｸﾞ
        If IsNothing(objType.GetProperty("FHENSU_KIND")) = False Then mFHENSU_KIND = objObject.FHENSU_KIND 'ﾃﾞｰﾀ種別
        If IsNothing(objType.GetProperty("FHENSU_INT")) = False Then mFHENSU_INT = objObject.FHENSU_INT '整数ﾃﾞｰﾀ
        If IsNothing(objType.GetProperty("FHENSU_REAL")) = False Then mFHENSU_REAL = objObject.FHENSU_REAL '実数ﾃﾞｰﾀ
        If IsNothing(objType.GetProperty("FHENSU_CHAR")) = False Then mFHENSU_CHAR = objObject.FHENSU_CHAR '文字ﾃﾞｰﾀ
        If IsNothing(objType.GetProperty("FHENSU_DATE")) = False Then mFHENSU_DATE = objObject.FHENSU_DATE '日付ﾃﾞｰﾀ

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
        mFHENSU_ID = Nothing
        mFHENSU_NAME = Nothing
        mFHENSU_FLAG = Nothing
        mFHENSU_KIND = Nothing
        mFHENSU_INT = Nothing
        mFHENSU_REAL = Nothing
        mFHENSU_CHAR = Nothing
        mFHENSU_DATE = Nothing


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
        mFHENSU_ID = TO_STRING_NULLABLE(objRow("FHENSU_ID"))
        mFHENSU_NAME = TO_STRING_NULLABLE(objRow("FHENSU_NAME"))
        mFHENSU_FLAG = TO_INTEGER_NULLABLE(objRow("FHENSU_FLAG"))
        mFHENSU_KIND = TO_INTEGER_NULLABLE(objRow("FHENSU_KIND"))
        mFHENSU_INT = TO_INTEGER_NULLABLE(objRow("FHENSU_INT"))
        mFHENSU_REAL = TO_DECIMAL_NULLABLE(objRow("FHENSU_REAL"))
        mFHENSU_CHAR = TO_STRING_NULLABLE(objRow("FHENSU_CHAR"))
        mFHENSU_DATE = TO_DATE_NULLABLE(objRow("FHENSU_DATE"))


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
        strMsg &= "[ﾃｰﾌﾞﾙ名:ｼｽﾃﾑ変数]"
        If IsNotNull(FHENSU_ID) Then
            strMsg &= "[変数ID:" & FHENSU_ID & "]"
        End If
        If IsNotNull(FHENSU_NAME) Then
            strMsg &= "[変数名称:" & FHENSU_NAME & "]"
        End If
        If IsNotNull(FHENSU_FLAG) Then
            strMsg &= "[ﾒﾝﾃ可能ﾌﾗｸﾞ:" & FHENSU_FLAG & "]"
        End If
        If IsNotNull(FHENSU_KIND) Then
            strMsg &= "[ﾃﾞｰﾀ種別:" & FHENSU_KIND & "]"
        End If
        If IsNotNull(FHENSU_INT) Then
            strMsg &= "[整数ﾃﾞｰﾀ:" & FHENSU_INT & "]"
        End If
        If IsNotNull(FHENSU_REAL) Then
            strMsg &= "[実数ﾃﾞｰﾀ:" & FHENSU_REAL & "]"
        End If
        If IsNotNull(FHENSU_CHAR) Then
            strMsg &= "[文字ﾃﾞｰﾀ:" & FHENSU_CHAR & "]"
        End If
        If IsNotNull(FHENSU_DATE) Then
            strMsg &= "[日付ﾃﾞｰﾀ:" & FHENSU_DATE & "]"
        End If


    End Sub
#End Region
    '↑↑↑自動生成部
    '**********************************************************************************************

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ共通
#Region "  ｸﾗｽ変数定義"
    'ﾌﾟﾛﾊﾟﾃｨ(ﾃｰﾌﾞﾙ列)
    Private mobjCHANGE_DATA As Object               '変更ﾃﾞｰﾀ
    Private mobjGET_DATA As Object                  '取得ﾃﾞｰﾀ
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義"

#Region "  変更ﾃﾞｰﾀ"
    Public Property OBJCHANGE_DATA() As Object
        Get
            Return mobjCHANGE_DATA
        End Get
        Set(ByVal Value As Object)
            mobjCHANGE_DATA = Value
        End Set
    End Property
#End Region
#Region "  取得ﾃﾞｰﾀ"
    Public Property OBJGET_DATA() As Object
        Get
            Return mobjGET_DATA
        End Get
        Set(ByVal Value As Object)
            mobjGET_DATA = Value
        End Set
    End Property
#End Region

#End Region
#Region "  ｼｽﾃﾑ変数取得 [ｵﾌﾞｼﾞｪｸﾄ戻し]      (Public  GET_TPRG_SYS_HEN_OBJ)"
    Public Function GET_TPRG_SYS_HEN_OBJ() As RetCode
        Try
            Dim strSQL As String            'SQL文
            Dim strMsg As String            'ﾒｯｾｰｼﾞ
            Dim objDataSet As New DataSet   'ﾃﾞｰﾀｾｯﾄ
            Dim strDataSetName As String    'ﾃﾞｰﾀｾｯﾄ名
            Dim objRow As DataRow           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ

            '***********************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '***********************
            If mFHENSU_ID = DEFAULT_STRING Then
                strMsg = ERRMSG_ERR_PROPERTY & "[変数ID]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '抽出SQL作成
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    *"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TPRG_SYS_HEN"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FHENSU_ID = '" & TO_STRING(mFHENSU_ID) & "'"
            strSQL &= vbCrLf


            '***********************
            '抽出
            '***********************
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TPRG_SYS_HEN"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                objRow = objDataSet.Tables(strDataSetName).Rows(0)
                Call SET_DATA(objRow)
                Select Case TO_INTEGER(mFHENSU_KIND)                            '変数種別
                    Case FHENSU_KIND_SINT
                        mobjGET_DATA = mFHENSU_INT
                    Case FHENSU_KIND_SREAL
                        mobjGET_DATA = mFHENSU_REAL
                    Case FHENSU_KIND_SCHAR
                        mobjGET_DATA = mFHENSU_CHAR
                    Case FHENSU_KIND_SDATE
                        mobjGET_DATA = mFHENSU_DATE
                End Select
                Return (RetCode.OK)
            Else
                Return (RetCode.NotFound)
            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "  ｼｽﾃﾑ変数更新 [ｵﾌﾞｼﾞｪｸﾄ渡し]      (Public  UPDATE_TPRG_SYS_HEN_OBJ)"
    Public Sub UPDATE_TPRG_SYS_HEN_OBJ()
        Try
            Dim strSQL As String        'SQL文
            Dim strMsg As String        'ﾒｯｾｰｼﾞ
            Dim intRetSQL As Integer    'SQL実行戻り値

            '***********************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '***********************
            If mFHENSU_ID = DEFAULT_STRING Then
                strMsg = ERRMSG_ERR_PROPERTY & "[変数ID]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '更新SQL作成
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "UPDATE"
            strSQL &= vbCrLf & "    TPRG_SYS_HEN"
            strSQL &= vbCrLf & " SET"
            strSQL &= vbCrLf & "    FHENSU_ID = '" & TO_STRING(mFHENSU_ID) & "'"
            strSQL &= vbCrLf & "   ,FHENSU_NAME = '" & TO_STRING(mFHENSU_NAME) & "'"
            Select Case TO_INTEGER(mFHENSU_KIND)                                                              '変数種別
                Case FHENSU_KIND_SINT
                    strSQL &= vbCrLf & "   ,FHENSU_INT = " & TO_STRING(mobjCHANGE_DATA)
                Case FHENSU_KIND_SREAL
                    strSQL &= vbCrLf & "   ,FHENSU_REAL = " & TO_STRING(mobjCHANGE_DATA)
                Case FHENSU_KIND_SCHAR
                    strSQL &= vbCrLf & "   ,FHENSU_CHAR = '" & TO_STRING(mobjCHANGE_DATA) & "'"
                Case FHENSU_KIND_SDATE
                    strSQL &= vbCrLf & "   ,FHENSU_DATE = TO_DATE('" & TO_STRING(mobjCHANGE_DATA) & "','YYYY/MM/DD HH24:MI:SS')"
            End Select
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FHENSU_ID = '" & TO_STRING(mFHENSU_ID) & "'"
            strSQL &= vbCrLf


            '***********************
            '更新
            '***********************
            intRetSQL = ObjDb.Execute(strSQL)
            If intRetSQL = -1 Then
                '(SQLｴﾗｰ)
                strSQL = Replace(strSQL, vbCrLf, "")
                strMsg = ERRMSG_ERR_UPDATE & ObjDb.ErrMsg & "【" & strSQL & "】"
                Throw New UserException(strMsg)
            End If
            If intRetSQL < 1 Then
                '(対象行無し)
                strSQL = Replace(strSQL, vbCrLf, "")
                strMsg = ERRMSG_ERR_UPDATE & "(対象行無し)[ﾃｰﾌﾞﾙ:TPRG_SYS_HEN]"
                Throw New UserException(strMsg)
            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region


#Region "  SS000000_001:ﾄﾗｯｷﾝｸﾞｷｬﾝｾﾙ計画数自動ﾒﾝﾃﾅﾝｽ"
    Public Property SS000000_001() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = "SS000000_001"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = "SS000000_001"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property
#End Region
#Region "  SS000000_002:ｸﾚｰﾝ優先順"
    ''' <summary>
    ''' ｸﾚｰﾝ優先順
    ''' </summary>
    Public Property SS000000_002() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = "SS000000_002"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = "SS000000_002"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property
#End Region
#Region "  SS000000_007:ﾓｰﾄﾞ切り替えﾀｲﾑｱｳﾄ(sec)"
    Public Property SS000000_007() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = "SS000000_007"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = "SS000000_007"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property
#End Region
#Region "  SS000000_008:ﾃﾞﾊﾞｯｸﾞﾛｸﾞ登録ﾌﾗｸﾞ"
    Public Property SS000000_008() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = "SS000000_008"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = "SS000000_008"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property
#End Region
#Region "  SS000000_009:ﾄﾗｯｷﾝｸﾞｷｬﾝｾﾙ使用ﾌﾗｸﾞ"
    Public Property SS000000_009() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = "SS000000_009"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = "SS000000_009"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property
#End Region
#Region "  SS000000_010:画面用入出庫実績の出力切替ｽﾃｰﾀｽ"
    Public Property SS000000_010() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = "SS000000_010"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = "SS000000_010"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property
#End Region
#Region "  SS000000_011:ｵﾝﾗｲﾝ設定時再送信ﾌﾗｸﾞ"
    Public Property SS000000_011() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = "SS000000_011"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = "SS000000_011"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property
#End Region
#Region "  SS000000_012:ﾊﾟｽﾜｰﾄﾞ不一致制限回数"
    Public Property SS000000_012() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = "SS000000_012"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = "SS000000_012"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property
#End Region
#Region "  SS000000_013:ﾊﾟｽﾜｰﾄﾞ有効期限超過日数"
    Public Property SS000000_013() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = "SS000000_013"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = "SS000000_013"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property
#End Region
#Region "  SS000000_014:ﾊﾟｽﾜｰﾄﾞとﾕｰｻﾞIDの一致ﾁｪｯｸﾌﾗｸﾞ"
    Public Property SS000000_014() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = "SS000000_014"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = "SS000000_014"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property
#End Region
#Region "  SS000000_015:ﾊﾟｽﾜｰﾄﾞ有効期限切れ表示日数"
    Public Property SS000000_015() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = "SS000000_015"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = "SS000000_015"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property
#End Region
#Region "  SS000000_016:通信異常時ｵﾌﾗｲﾝ切替ﾌﾗｸﾞ"
    Public Property SS000000_016() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = "SS000000_016"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = "SS000000_016"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property
#End Region
#Region "  SS000000_017:通信異常時ﾚｺｰﾄﾞ削除ﾌﾗｸﾞ"
    Public Property SS000000_017() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = "SS000000_017"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = "SS000000_017"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property
#End Region
#Region "  SS000000_018:ｵﾝﾗｲﾝ搬送制御ﾃｰﾌﾞﾙ登録ﾌﾗｸﾞ"
    Public Property SS000000_018() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = "SS000000_018"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = "SS000000_018"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property
#End Region
#Region "  SS000000_019:ｵﾌﾗｲﾝ搬送制御ﾃｰﾌﾞﾙ登録ﾌﾗｸﾞ"
    Public Property SS000000_019() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = "SS000000_019"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = "SS000000_019"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property
#End Region
#Region "  SS000000_020:応答ｺｰﾄﾞ不明時ｵﾌﾗｲﾝ切替ﾌﾗｸﾞ"
    Public Property SS000000_020() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = "SS000000_020"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = "SS000000_020"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property
#End Region
#Region "  SS000000_021:出庫指示処理ﾙｰﾌﾟﾀｲﾑｱｳﾄ(ﾌﾘｰｽﾞ現象予防)"
    ''' <summary>
    ''' 出庫指示処理ﾙｰﾌﾟﾀｲﾑｱｳﾄ(ﾌﾘｰｽﾞ現象予防)
    ''' </summary>
    Public Property SS000000_021() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = "SS000000_021"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = "SS000000_021"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property
#End Region
#Region "  SS000000_022:出庫指示引当(ｸﾚｰﾝ毎)のｸﾚｰﾝ優先順"
    ''' <summary>
    ''' 出庫指示引当(ｸﾚｰﾝ毎)のｸﾚｰﾝ優先順
    ''' </summary>
    Public Property SS000000_022() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = "SS000000_022"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = "SS000000_022"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property
#End Region

#Region "  SS040101_001:DBﾊﾞｯｸｱｯﾌﾟﾌﾟﾛｸﾞﾗﾑ起動ﾊﾟｽ"
    '''**********************************************************************************************
    ''' <summary>
    ''' DBﾊﾞｯｸｱｯﾌﾟﾌﾟﾛｸﾞﾗﾑ起動ﾊﾟｽ
    ''' </summary>
    ''' <value>ﾃﾞｰﾀ値</value>
    ''' <returns>ﾃﾞｰﾀ値</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Property SS040101_001() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = "SS040101_001"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = "SS040101_001"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property
#End Region
#Region "  SS040102_001:DBﾊﾞｯｸｱｯﾌﾟﾌﾟﾛｸﾞﾗﾑ起動ﾊﾟｽ2"
    '''**********************************************************************************************
    ''' <summary>
    ''' DBﾊﾞｯｸｱｯﾌﾟﾌﾟﾛｸﾞﾗﾑ起動ﾊﾟｽ2
    ''' </summary>
    ''' <value>ﾃﾞｰﾀ値</value>
    ''' <returns>ﾃﾞｰﾀ値</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Property SS040102_001() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = "SS040102_001"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = "SS040102_001"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property
#End Region
#Region "  SS040102_002:DBﾊﾞｯｸｱｯﾌﾟﾌﾟﾛｸﾞﾗﾑ起動ﾊﾟｽ3"
    '''**********************************************************************************************
    ''' <summary>
    ''' DBﾊﾞｯｸｱｯﾌﾟﾌﾟﾛｸﾞﾗﾑ起動ﾊﾟｽ3
    ''' </summary>
    ''' <value>ﾃﾞｰﾀ値</value>
    ''' <returns>ﾃﾞｰﾀ値</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Property SS040102_002() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = "SS040102_002"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = "SS040102_002"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property
#End Region

    '↑↑↑ｼｽﾃﾑ共通
    '**********************************************************************************************

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有
#Region "  GJ307000_001:PLCﾒﾝﾃﾅﾝｽ画面更新ｽﾘｰﾌﾟ時間(msec)"
    Public Property GJ307000_001() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = "GJ307000_001"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = "GJ307000_001"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property
#End Region
#Region "  SJ000000_001:出庫CV当たりの同時出庫指示数"
    ''' <summary>
    ''' 出庫CV当たりの同時出庫指示数
    ''' </summary>
    Public Property SJ000000_001() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = "SJ000000_001"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = "SJ000000_001"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property
#End Region
#Region "  SJ000000_003:ﾛｰﾀﾞﾊﾞｰｽ優先順"
    ''' <summary>
    ''' ﾛｰﾀﾞﾊﾞｰｽ優先順
    ''' </summary>
    Public Property SJ000000_003() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = "SJ000000_003"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mFHENSU_CHAR                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = "SJ000000_003"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property
#End Region
#Region "  SJ000000_004:最終使用ﾊﾞﾗﾊﾞｰｽ"
    ''' <summary>
    ''' 最終使用ﾊﾞﾗﾊﾞｰｽ
    ''' </summary>
    Public Property SJ000000_004() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = "SJ000000_004"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mFHENSU_CHAR                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = "SJ000000_004"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property
#End Region
#Region "  SJ000000_005:ﾛｰﾀﾞ号機優先順"
    ''' <summary>
    ''' ﾛｰﾀﾞ号機優先順
    ''' </summary>
    Public Property SJ000000_005() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = "SJ000000_005"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mFHENSU_CHAR                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = "SJ000000_005"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property
#End Region
#Region "  SJ000000_006:ﾛｰﾀﾞﾊﾞｰｽ優先順(1号機)"
    ''' <summary>
    ''' ﾛｰﾀﾞﾊﾞｰｽ優先順(1号機)
    ''' </summary>
    Public Property SJ000000_006() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = "SJ000000_006"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mFHENSU_CHAR                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = "SJ000000_006"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property
#End Region
#Region "  SJ000000_007:ﾛｰﾀﾞﾊﾞｰｽ優先順(2号機)"
    ''' <summary>
    ''' ﾛｰﾀﾞﾊﾞｰｽ優先順(2号機)
    ''' </summary>
    Public Property SJ000000_007() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = "SJ000000_007"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mFHENSU_CHAR                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = "SJ000000_007"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property
#End Region

#Region "  SJ000000_011:締め時刻"
    ''' <summary>
    ''' 締め時刻
    ''' </summary>
    Public Property SJ000000_011() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = "SJ000000_011"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = "SJ000000_011"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property
#End Region
#Region "  SJ000000_012:最終実行締め時刻"
    ''' <summary>
    ''' 最終実行締め時刻
    ''' </summary>
    Public Property SJ000000_012() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = "SJ000000_012"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = "SJ000000_012"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property
#End Region
#Region "  SJ000000_013:操業開始時刻"
    ''' <summary>
    ''' 操業開始時刻
    ''' </summary>
    Public Property SJ000000_013() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = "SJ000000_013"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = "SJ000000_013"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property
#End Region
#Region "  SJ000000_014:最終実行締め時刻"
    ''' <summary>
    ''' 最終実行締め時刻
    ''' </summary>
    Public Property SJ000000_014() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = "SJ000000_014"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = "SJ000000_014"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property
#End Region

#Region "  SJ000000_021:ｻｰﾊﾞﾌﾟﾛｾｽ再起動ﾊﾞｯﾁﾌｧｲﾙﾊﾟｽ"
    ''' <summary>
    ''' ｻｰﾊﾞﾌﾟﾛｾｽ再起動ﾊﾞｯﾁﾌｧｲﾙﾊﾟｽ
    ''' </summary>
    Public Property SJ000000_021() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = "SJ000000_021"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = "SJ000000_021"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property
#End Region
#Region "  SJ000000_022:Excelﾌｧｲﾙ保存ﾊﾟｽ"
    ''' <summary>
    ''' Excelﾌｧｲﾙ保存ﾊﾟｽ
    ''' </summary>
    Public Property SJ000000_022() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = "SJ000000_022"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = "SJ000000_022"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property
#End Region
#Region "  SJ000000_023:Csvﾌｧｲﾙ保存ﾊﾟｽ"
    ''' <summary>
    ''' Csvﾌｧｲﾙ保存ﾊﾟｽ
    ''' </summary>
    Public Property SJ000000_023() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = "SJ000000_023"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = "SJ000000_023"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property
#End Region
#Region "  SJ000000_024:Exe起動ﾌﾟﾛｸﾞﾗﾑﾊﾟｽ"
    ''' <summary>
    ''' Exe起動ﾌﾟﾛｸﾞﾗﾑﾊﾟｽ
    ''' </summary>
    Public Property SJ000000_024() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = "SJ000000_024"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = "SJ000000_024"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property
#End Region

#Region "  SJ000000_031:車輌ｺﾝﾄﾛｰﾗ返信電文01"
    ''' <summary>
    ''' 車輌ｺﾝﾄﾛｰﾗ返信電文01
    ''' </summary>
    Public Property SJ000000_031() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = "SJ000000_031"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = "SJ000000_031"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property
#End Region
#Region "  SJ000000_032:車輌ｺﾝﾄﾛｰﾗ返信電文02"
    ''' <summary>
    ''' 車輌ｺﾝﾄﾛｰﾗ返信電文02
    ''' </summary>
    Public Property SJ000000_032() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = "SJ000000_032"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = "SJ000000_032"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property
#End Region

#Region "  SJ000000_041:引当異常ﾗﾝﾌﾟ"
    ''' <summary>
    ''' 引当異常ﾗﾝﾌﾟ
    ''' </summary>
    Public Property SJ000000_041() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = "SJ000000_041"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = "SJ000000_041"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property
#End Region
#Region "  SJ000000_042:交信異常ﾗﾝﾌﾟ"
    ''' <summary>
    ''' 交信異常ﾗﾝﾌﾟ
    ''' </summary>
    Public Property SJ000000_042() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = "SJ000000_042"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = "SJ000000_042"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property
#End Region
#Region "  SJ000000_043:情報異常ﾗﾝﾌﾟ"
    ''' <summary>
    ''' 情報異常ﾗﾝﾌﾟ
    ''' </summary>
    Public Property SJ000000_043() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = "SJ000000_043"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = "SJ000000_043"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property
#End Region

    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:Dou 2014/08/04 入庫設定並列処理を行う為の改造
#Region "  SJ390002_001:1周期で処理するﾚｺｰﾄﾞ件数"
    ''' <summary>
    ''' 1周期で処理するﾚｺｰﾄﾞ件数
    ''' </summary>
    Public Property SJ390002_001() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = "SJ390002_001"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = "SJ390002_001"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property
#End Region
    '↑↑↑↑↑↑************************************************************************************************************

    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:S.Ouchi 2016/08/04 ｻｰﾊﾞﾌﾟﾛｾｽﾒﾓﾘ監視を行う為の改造 ↓↓↓↓↓↓
#Region "  SJ390003_001:ｻｰﾊﾞﾌﾟﾛｾｽ監視(ﾒﾓﾘ使用量判定値)(KByte)"
    ''' <summary>
    ''' ｻｰﾊﾞﾌﾟﾛｾｽ監視(ﾒﾓﾘ使用量判定値)(KByte)
    ''' </summary>
    Public Property SJ390003_001() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = "SJ390003_001"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = "SJ390003_001"    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (整数型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property
#End Region
    'JobMate:S.Ouchi 2016/08/04 ｻｰﾊﾞﾌﾟﾛｾｽﾒﾓﾘ監視を行う為の改造 ↑↑↑↑↑↑
    '↑↑↑↑↑↑************************************************************************************************************

#Region "  GJ304070_001:ｸﾞﾘｯﾄﾞの背景色"
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞの背景色
    ''' </summary>
    Public Property GJ304070_001() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = FHENSU_ID_JGJ304070_001    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (文字型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = FHENSU_ID_JGJ304070_001    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (文字型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property
#End Region
#Region "  GJ304070_002:ｸﾞﾘｯﾄﾞの枠線"
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞの枠線
    ''' </summary>
    Public Property GJ304070_002() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = FHENSU_ID_JGJ304070_002    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (文字型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = FHENSU_ID_JGJ304070_002    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (文字型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property
#End Region
#Region "  GJ304070_011:ﾗﾍﾞﾙの背景色"
    ''' <summary>
    ''' ﾗﾍﾞﾙの背景色
    ''' </summary>
    Public Property GJ304070_011() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = FHENSU_ID_JGJ304070_011    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (文字型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = FHENSU_ID_JGJ304070_011    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (文字型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property

#End Region
#Region "  GJ304070_012:ﾗﾍﾞﾙの文字色"
    ''' <summary>
    ''' ﾗﾍﾞﾙの文字色
    ''' </summary>
    Public Property GJ304070_012() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = FHENSU_ID_JGJ304070_012    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (文字型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = FHENSU_ID_JGJ304070_012    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (文字型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property

#End Region
#Region "  GJ304070_101:●の色"
    ''' <summary>
    ''' ●の色
    ''' </summary>
    Public Property GJ304070_101() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = FHENSU_ID_JGJ304070_101    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (文字型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = FHENSU_ID_JGJ304070_101    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (文字型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property

#End Region
#Region "  GJ304070_102:○の色"
    ''' <summary>
    ''' ○の色
    ''' </summary>
    Public Property GJ304070_102() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = FHENSU_ID_JGJ304070_102    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (文字型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = FHENSU_ID_JGJ304070_102    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (文字型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property

#End Region
#Region "  GJ304070_103:▲の色"
    ''' <summary>
    ''' ▲の色
    ''' </summary>
    Public Property GJ304070_103() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = FHENSU_ID_JGJ304070_103    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (文字型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = FHENSU_ID_JGJ304070_103    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (文字型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property

#End Region
#Region "  GJ304070_104:△の色"
    ''' <summary>
    ''' △の色
    ''' </summary>
    Public Property GJ304070_104() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = FHENSU_ID_JGJ304070_104    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (文字型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = FHENSU_ID_JGJ304070_104    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (文字型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property

#End Region
#Region "  GJ304070_105:■の色"
    ''' <summary>
    ''' ■の色
    ''' </summary>
    Public Property GJ304070_105() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = FHENSU_ID_JGJ304070_105    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (文字型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = FHENSU_ID_JGJ304070_105    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (文字型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property

#End Region
#Region "  GJ304070_106:□の色"
    ''' <summary>
    ''' □の色
    ''' </summary>
    Public Property GJ304070_106() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = FHENSU_ID_JGJ304070_106    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (文字型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = FHENSU_ID_JGJ304070_106    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (文字型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property

#End Region
#Region "  GJ304070_107:×の色"
    ''' <summary>
    ''' ×の色
    ''' </summary>
    Public Property GJ304070_107() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = FHENSU_ID_JGJ304070_107    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (文字型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = FHENSU_ID_JGJ304070_107    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (文字型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property

#End Region
#Region "  GJ304070_108:-の色"
    ''' <summary>
    ''' -の色
    ''' </summary>
    Public Property GJ304070_108() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = FHENSU_ID_JGJ304070_108    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (文字型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = FHENSU_ID_JGJ304070_108    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (文字型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property

#End Region
#Region "  GJ304070_109:★の色"
    ''' <summary>
    ''' ★の色
    ''' </summary>
    Public Property GJ304070_109() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = FHENSU_ID_JGJ304070_109    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (文字型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = FHENSU_ID_JGJ304070_109    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (文字型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property

#End Region
#Region "  GJ304070_110:▼の色"
    ''' <summary>
    ''' ▼の色
    ''' </summary>
    Public Property GJ304070_110() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = FHENSU_ID_JGJ304070_110    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (文字型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = FHENSU_ID_JGJ304070_110    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (文字型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property

#End Region
#Region "  GJ304070_111:▽の色"
    ''' <summary>
    ''' ▽の色
    ''' </summary>
    Public Property GJ304070_111() As Object
        Get
            '(ﾌﾟﾛﾊﾟﾃｨ   取得処理)

            Dim objReturn As Object
            mFHENSU_ID = FHENSU_ID_JGJ304070_111    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数取得       (文字型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            objReturn = mobjGET_DATA                'ﾃﾞｰﾀ       ｾｯﾄ


            Return objReturn
        End Get
        Set(ByVal Value As Object)
            '(ﾌﾟﾛﾊﾟﾃｨ   更新処理)

            mFHENSU_ID = FHENSU_ID_JGJ304070_111    '変数ID     ｾｯﾄ


            '***************************************************
            'ｼｽﾃﾑ変数更新       (文字型)
            '***************************************************
            Dim intRet As RetCode                   '戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ
            intRet = GET_TPRG_SYS_HEN_OBJ()         '情報       取得
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strMsg = ERRMSG_NOTFOUND_TPRG_SYS_HEN & "[変数ID:" & mFHENSU_ID & "]"
                Throw New UserException(ERRMSG_NOTFOUND_TPRG_SYS_HEN)
            End If
            mobjCHANGE_DATA = Value                 'ﾃﾞｰﾀ       ｾｯﾄ
            Call UPDATE_TPRG_SYS_HEN_OBJ()          '情報       更新


        End Set
    End Property

#End Region





    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************


End Class
