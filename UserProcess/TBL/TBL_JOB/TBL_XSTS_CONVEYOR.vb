'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' 【名称】MaterialStreamﾃｰﾌﾞﾙｸﾗｽ
' 【機能】出荷ｺﾝﾍﾞﾔ状況ﾃｰﾌﾞﾙｸﾗｽ
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
''' 出荷ｺﾝﾍﾞﾔ状況ﾃｰﾌﾞﾙｸﾗｽ
''' </summary>
Public Class TBL_XSTS_CONVEYOR
    Inherits clsTemplateTable

    '**********************************************************************************************
    '↓↓↓自動生成部
#Region "  ｸﾗｽ変数定義                  "
    'ﾌﾟﾛﾊﾟﾃｨ
    Private mobjAryMe As TBL_XSTS_CONVEYOR()                                     '出荷ｺﾝﾍﾞﾔ状況
    Private mstrUSER_SQL As String                                               'ﾕｰｻﾞｰSQL
    Private mORDER_BY As String                                                  'OrderBy句
    Private mWHERE As String                                                     'Where句
    Private mXSTNO As Nullable(Of Integer)                                       'STNo.
    Private mFEQ_LOCATION As Nullable(Of Integer)                                '設備ﾛｹｰｼｮﾝ
    Private mXCONVEYOR_YOUTO As Nullable(Of Integer)                             'ｺﾝﾍﾞﾔ用途
    Private mFUPDATE_DT As Nullable(Of Date)                                     '更新日時
    Private mXCONVEYOR_GROUP As Nullable(Of Integer)                             'ｺﾝﾍﾞﾔｸﾞﾙｰﾌﾟ
    Private mXCONVEYOR_ORDER As Nullable(Of Integer)                             'ｺﾝﾍﾞﾔ順
    Private mXBERTH_GROUP As Nullable(Of Integer)                                'ﾊﾞｰｽｸﾞﾙｰﾌﾟ
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                  "
    ''' <summary>
    ''' ｼｽﾃﾑ変数 (自ｸﾗｽ型配列)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_XSTS_CONVEYOR()
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
    ''' STNo.
    ''' </summary>
    Public Property XSTNO() As Nullable(Of Integer)
        Get
            Return mXSTNO
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXSTNO = Value
        End Set
    End Property
    ''' <summary>
    ''' 設備ﾛｹｰｼｮﾝ
    ''' </summary>
    Public Property FEQ_LOCATION() As Nullable(Of Integer)
        Get
            Return mFEQ_LOCATION
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFEQ_LOCATION = Value
        End Set
    End Property
    ''' <summary>
    ''' ｺﾝﾍﾞﾔ用途
    ''' </summary>
    Public Property XCONVEYOR_YOUTO() As Nullable(Of Integer)
        Get
            Return mXCONVEYOR_YOUTO
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXCONVEYOR_YOUTO = Value
        End Set
    End Property
    ''' <summary>
    ''' 更新日時
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
    ''' ｺﾝﾍﾞﾔｸﾞﾙｰﾌﾟ
    ''' </summary>
    Public Property XCONVEYOR_GROUP() As Nullable(Of Integer)
        Get
            Return mXCONVEYOR_GROUP
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXCONVEYOR_GROUP = Value
        End Set
    End Property
    ''' <summary>
    ''' ｺﾝﾍﾞﾔ順
    ''' </summary>
    Public Property XCONVEYOR_ORDER() As Nullable(Of Integer)
        Get
            Return mXCONVEYOR_ORDER
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXCONVEYOR_ORDER = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾊﾞｰｽｸﾞﾙｰﾌﾟ
    ''' </summary>
    Public Property XBERTH_GROUP() As Nullable(Of Integer)
        Get
            Return mXBERTH_GROUP
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXBERTH_GROUP = Value
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
    Public Function GET_XSTS_CONVEYOR(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    XSTS_CONVEYOR")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XSTNO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSTNO
            strSQL.Append(vbCrLf & "    AND XSTNO = :" & UBound(strBindField) - 1 & " --STNo.")
        End If
        If IsNull(FEQ_LOCATION) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_LOCATION
            strSQL.Append(vbCrLf & "    AND FEQ_LOCATION = :" & UBound(strBindField) - 1 & " --設備ﾛｹｰｼｮﾝ")
        End If
        If IsNull(XCONVEYOR_YOUTO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCONVEYOR_YOUTO
            strSQL.Append(vbCrLf & "    AND XCONVEYOR_YOUTO = :" & UBound(strBindField) - 1 & " --ｺﾝﾍﾞﾔ用途")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --更新日時")
        End If
        If IsNull(XCONVEYOR_GROUP) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCONVEYOR_GROUP
            strSQL.Append(vbCrLf & "    AND XCONVEYOR_GROUP = :" & UBound(strBindField) - 1 & " --ｺﾝﾍﾞﾔｸﾞﾙｰﾌﾟ")
        End If
        If IsNull(XCONVEYOR_ORDER) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCONVEYOR_ORDER
            strSQL.Append(vbCrLf & "    AND XCONVEYOR_ORDER = :" & UBound(strBindField) - 1 & " --ｺﾝﾍﾞﾔ順")
        End If
        If IsNull(XBERTH_GROUP) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_GROUP
            strSQL.Append(vbCrLf & "    AND XBERTH_GROUP = :" & UBound(strBindField) - 1 & " --ﾊﾞｰｽｸﾞﾙｰﾌﾟ")
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
        strDataSetName = "XSTS_CONVEYOR"
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
    Public Function GET_XSTS_CONVEYOR_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    XSTS_CONVEYOR")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XSTNO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSTNO
            strSQL.Append(vbCrLf & "    AND XSTNO = :" & UBound(strBindField) - 1 & " --STNo.")
        End If
        If IsNull(FEQ_LOCATION) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_LOCATION
            strSQL.Append(vbCrLf & "    AND FEQ_LOCATION = :" & UBound(strBindField) - 1 & " --設備ﾛｹｰｼｮﾝ")
        End If
        If IsNull(XCONVEYOR_YOUTO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCONVEYOR_YOUTO
            strSQL.Append(vbCrLf & "    AND XCONVEYOR_YOUTO = :" & UBound(strBindField) - 1 & " --ｺﾝﾍﾞﾔ用途")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --更新日時")
        End If
        If IsNull(XCONVEYOR_GROUP) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCONVEYOR_GROUP
            strSQL.Append(vbCrLf & "    AND XCONVEYOR_GROUP = :" & UBound(strBindField) - 1 & " --ｺﾝﾍﾞﾔｸﾞﾙｰﾌﾟ")
        End If
        If IsNull(XCONVEYOR_ORDER) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCONVEYOR_ORDER
            strSQL.Append(vbCrLf & "    AND XCONVEYOR_ORDER = :" & UBound(strBindField) - 1 & " --ｺﾝﾍﾞﾔ順")
        End If
        If IsNull(XBERTH_GROUP) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_GROUP
            strSQL.Append(vbCrLf & "    AND XBERTH_GROUP = :" & UBound(strBindField) - 1 & " --ﾊﾞｰｽｸﾞﾙｰﾌﾟ")
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
        strDataSetName = "XSTS_CONVEYOR"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XSTS_CONVEYOR(Owner, objDb, objDbLog)
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
    Public Function GET_XSTS_CONVEYOR_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "XSTS_CONVEYOR"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XSTS_CONVEYOR(Owner, objDb, objDbLog)
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
    Public Function GET_XSTS_CONVEYOR_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    XSTS_CONVEYOR")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XSTNO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSTNO
            strSQL.Append(vbCrLf & "    AND XSTNO = :" & UBound(strBindField) - 1 & " --STNo.")
        End If
        If IsNull(FEQ_LOCATION) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_LOCATION
            strSQL.Append(vbCrLf & "    AND FEQ_LOCATION = :" & UBound(strBindField) - 1 & " --設備ﾛｹｰｼｮﾝ")
        End If
        If IsNull(XCONVEYOR_YOUTO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCONVEYOR_YOUTO
            strSQL.Append(vbCrLf & "    AND XCONVEYOR_YOUTO = :" & UBound(strBindField) - 1 & " --ｺﾝﾍﾞﾔ用途")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --更新日時")
        End If
        If IsNull(XCONVEYOR_GROUP) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCONVEYOR_GROUP
            strSQL.Append(vbCrLf & "    AND XCONVEYOR_GROUP = :" & UBound(strBindField) - 1 & " --ｺﾝﾍﾞﾔｸﾞﾙｰﾌﾟ")
        End If
        If IsNull(XCONVEYOR_ORDER) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCONVEYOR_ORDER
            strSQL.Append(vbCrLf & "    AND XCONVEYOR_ORDER = :" & UBound(strBindField) - 1 & " --ｺﾝﾍﾞﾔ順")
        End If
        If IsNull(XBERTH_GROUP) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_GROUP
            strSQL.Append(vbCrLf & "    AND XBERTH_GROUP = :" & UBound(strBindField) - 1 & " --ﾊﾞｰｽｸﾞﾙｰﾌﾟ")
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
        strDataSetName = "XSTS_CONVEYOR"
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
    Public Sub UPDATE_XSTS_CONVEYOR()
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
        ElseIf IsNull(mXSTNO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[STNo.]"
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
        strSQL.Append(vbCrLf & "    XSTS_CONVEYOR")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
        If IsNull(mXSTNO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSTNO = NULL --STNo.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSTNO = NULL --STNo.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSTNO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSTNO = :" & Ubound(strBindField) - 1 & " --STNo.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSTNO = :" & Ubound(strBindField) - 1 & " --STNo.")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_LOCATION) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_LOCATION = NULL --設備ﾛｹｰｼｮﾝ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_LOCATION = NULL --設備ﾛｹｰｼｮﾝ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_LOCATION
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_LOCATION = :" & Ubound(strBindField) - 1 & " --設備ﾛｹｰｼｮﾝ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_LOCATION = :" & Ubound(strBindField) - 1 & " --設備ﾛｹｰｼｮﾝ")
        End If
        intCount = intCount + 1
        If IsNull(mXCONVEYOR_YOUTO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCONVEYOR_YOUTO = NULL --ｺﾝﾍﾞﾔ用途")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCONVEYOR_YOUTO = NULL --ｺﾝﾍﾞﾔ用途")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCONVEYOR_YOUTO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCONVEYOR_YOUTO = :" & Ubound(strBindField) - 1 & " --ｺﾝﾍﾞﾔ用途")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCONVEYOR_YOUTO = :" & Ubound(strBindField) - 1 & " --ｺﾝﾍﾞﾔ用途")
        End If
        intCount = intCount + 1
        If IsNull(mFUPDATE_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUPDATE_DT = NULL --更新日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUPDATE_DT = NULL --更新日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUPDATE_DT = :" & Ubound(strBindField) - 1 & " --更新日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUPDATE_DT = :" & Ubound(strBindField) - 1 & " --更新日時")
        End If
        intCount = intCount + 1
        If IsNull(mXCONVEYOR_GROUP) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCONVEYOR_GROUP = NULL --ｺﾝﾍﾞﾔｸﾞﾙｰﾌﾟ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCONVEYOR_GROUP = NULL --ｺﾝﾍﾞﾔｸﾞﾙｰﾌﾟ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCONVEYOR_GROUP
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCONVEYOR_GROUP = :" & Ubound(strBindField) - 1 & " --ｺﾝﾍﾞﾔｸﾞﾙｰﾌﾟ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCONVEYOR_GROUP = :" & Ubound(strBindField) - 1 & " --ｺﾝﾍﾞﾔｸﾞﾙｰﾌﾟ")
        End If
        intCount = intCount + 1
        If IsNull(mXCONVEYOR_ORDER) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCONVEYOR_ORDER = NULL --ｺﾝﾍﾞﾔ順")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCONVEYOR_ORDER = NULL --ｺﾝﾍﾞﾔ順")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCONVEYOR_ORDER
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XCONVEYOR_ORDER = :" & Ubound(strBindField) - 1 & " --ｺﾝﾍﾞﾔ順")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XCONVEYOR_ORDER = :" & Ubound(strBindField) - 1 & " --ｺﾝﾍﾞﾔ順")
        End If
        intCount = intCount + 1
        If IsNull(mXBERTH_GROUP) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XBERTH_GROUP = NULL --ﾊﾞｰｽｸﾞﾙｰﾌﾟ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XBERTH_GROUP = NULL --ﾊﾞｰｽｸﾞﾙｰﾌﾟ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_GROUP
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XBERTH_GROUP = :" & Ubound(strBindField) - 1 & " --ﾊﾞｰｽｸﾞﾙｰﾌﾟ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XBERTH_GROUP = :" & Ubound(strBindField) - 1 & " --ﾊﾞｰｽｸﾞﾙｰﾌﾟ")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(XSTNO) = True Then
            strSQL.Append(vbCrLf & "    AND XSTNO IS NULL --STNo.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSTNO
            strSQL.Append(vbCrLf & "    AND XSTNO = :" & UBound(strBindField) - 1 & " --STNo.")
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
    Public Sub ADD_XSTS_CONVEYOR()
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
        ElseIf IsNull(mXSTNO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[STNo.]"
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
        strSQL.Append(vbCrLf & "    XSTS_CONVEYOR")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
        If IsNull(mXSTNO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --STNo.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --STNo.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSTNO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --STNo.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --STNo.")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_LOCATION) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --設備ﾛｹｰｼｮﾝ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --設備ﾛｹｰｼｮﾝ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_LOCATION
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --設備ﾛｹｰｼｮﾝ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --設備ﾛｹｰｼｮﾝ")
        End If
        intCount = intCount + 1
        If IsNull(mXCONVEYOR_YOUTO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｺﾝﾍﾞﾔ用途")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｺﾝﾍﾞﾔ用途")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCONVEYOR_YOUTO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｺﾝﾍﾞﾔ用途")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｺﾝﾍﾞﾔ用途")
        End If
        intCount = intCount + 1
        If IsNull(mFUPDATE_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --更新日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --更新日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --更新日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --更新日時")
        End If
        intCount = intCount + 1
        If IsNull(mXCONVEYOR_GROUP) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｺﾝﾍﾞﾔｸﾞﾙｰﾌﾟ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｺﾝﾍﾞﾔｸﾞﾙｰﾌﾟ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCONVEYOR_GROUP
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｺﾝﾍﾞﾔｸﾞﾙｰﾌﾟ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｺﾝﾍﾞﾔｸﾞﾙｰﾌﾟ")
        End If
        intCount = intCount + 1
        If IsNull(mXCONVEYOR_ORDER) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｺﾝﾍﾞﾔ順")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｺﾝﾍﾞﾔ順")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCONVEYOR_ORDER
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｺﾝﾍﾞﾔ順")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｺﾝﾍﾞﾔ順")
        End If
        intCount = intCount + 1
        If IsNull(mXBERTH_GROUP) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾊﾞｰｽｸﾞﾙｰﾌﾟ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾊﾞｰｽｸﾞﾙｰﾌﾟ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_GROUP
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾊﾞｰｽｸﾞﾙｰﾌﾟ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾊﾞｰｽｸﾞﾙｰﾌﾟ")
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
    Public Sub DELETE_XSTS_CONVEYOR()
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
        ElseIf IsNull(mXSTNO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[STNo.]"
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
        strSQL.Append(vbCrLf & "    XSTS_CONVEYOR")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(XSTNO) = True Then
            strSQL.Append(vbCrLf & "    AND XSTNO IS NULL --STNo.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSTNO
            strSQL.Append(vbCrLf & "    AND XSTNO = :" & UBound(strBindField) - 1 & " --STNo.")
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
    Public Sub DELETE_XSTS_CONVEYOR_ANY()
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
        strSQL.Append(vbCrLf & "    XSTS_CONVEYOR")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(XSTNO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSTNO
            strSQL.Append(vbCrLf & "    AND XSTNO = :" & UBound(strBindField) - 1 & " --STNo.")
        End If
        If IsNotNull(FEQ_LOCATION) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_LOCATION
            strSQL.Append(vbCrLf & "    AND FEQ_LOCATION = :" & UBound(strBindField) - 1 & " --設備ﾛｹｰｼｮﾝ")
        End If
        If IsNotNull(XCONVEYOR_YOUTO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCONVEYOR_YOUTO
            strSQL.Append(vbCrLf & "    AND XCONVEYOR_YOUTO = :" & UBound(strBindField) - 1 & " --ｺﾝﾍﾞﾔ用途")
        End If
        If IsNotNull(FUPDATE_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --更新日時")
        End If
        If IsNotNull(XCONVEYOR_GROUP) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCONVEYOR_GROUP
            strSQL.Append(vbCrLf & "    AND XCONVEYOR_GROUP = :" & UBound(strBindField) - 1 & " --ｺﾝﾍﾞﾔｸﾞﾙｰﾌﾟ")
        End If
        If IsNotNull(XCONVEYOR_ORDER) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXCONVEYOR_ORDER
            strSQL.Append(vbCrLf & "    AND XCONVEYOR_ORDER = :" & UBound(strBindField) - 1 & " --ｺﾝﾍﾞﾔ順")
        End If
        If IsNotNull(XBERTH_GROUP) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_GROUP
            strSQL.Append(vbCrLf & "    AND XBERTH_GROUP = :" & UBound(strBindField) - 1 & " --ﾊﾞｰｽｸﾞﾙｰﾌﾟ")
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
        If IsNothing(objType.GetProperty("XSTNO")) = False Then mXSTNO = objObject.XSTNO 'STNo.
        If IsNothing(objType.GetProperty("FEQ_LOCATION")) = False Then mFEQ_LOCATION = objObject.FEQ_LOCATION '設備ﾛｹｰｼｮﾝ
        If IsNothing(objType.GetProperty("XCONVEYOR_YOUTO")) = False Then mXCONVEYOR_YOUTO = objObject.XCONVEYOR_YOUTO 'ｺﾝﾍﾞﾔ用途
        If IsNothing(objType.GetProperty("FUPDATE_DT")) = False Then mFUPDATE_DT = objObject.FUPDATE_DT '更新日時
        If IsNothing(objType.GetProperty("XCONVEYOR_GROUP")) = False Then mXCONVEYOR_GROUP = objObject.XCONVEYOR_GROUP 'ｺﾝﾍﾞﾔｸﾞﾙｰﾌﾟ
        If IsNothing(objType.GetProperty("XCONVEYOR_ORDER")) = False Then mXCONVEYOR_ORDER = objObject.XCONVEYOR_ORDER 'ｺﾝﾍﾞﾔ順
        If IsNothing(objType.GetProperty("XBERTH_GROUP")) = False Then mXBERTH_GROUP = objObject.XBERTH_GROUP 'ﾊﾞｰｽｸﾞﾙｰﾌﾟ

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
        mXSTNO = Nothing
        mFEQ_LOCATION = Nothing
        mXCONVEYOR_YOUTO = Nothing
        mFUPDATE_DT = Nothing
        mXCONVEYOR_GROUP = Nothing
        mXCONVEYOR_ORDER = Nothing
        mXBERTH_GROUP = Nothing


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
        mXSTNO = TO_INTEGER_NULLABLE(objRow("XSTNO"))
        mFEQ_LOCATION = TO_INTEGER_NULLABLE(objRow("FEQ_LOCATION"))
        mXCONVEYOR_YOUTO = TO_INTEGER_NULLABLE(objRow("XCONVEYOR_YOUTO"))
        mFUPDATE_DT = TO_DATE_NULLABLE(objRow("FUPDATE_DT"))
        mXCONVEYOR_GROUP = TO_INTEGER_NULLABLE(objRow("XCONVEYOR_GROUP"))
        mXCONVEYOR_ORDER = TO_INTEGER_NULLABLE(objRow("XCONVEYOR_ORDER"))
        mXBERTH_GROUP = TO_INTEGER_NULLABLE(objRow("XBERTH_GROUP"))


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
        strMsg &= "[ﾃｰﾌﾞﾙ名:出荷ｺﾝﾍﾞﾔ状況]"
        If IsNotNull(XSTNO) Then
            strMsg &= "[STNo.:" & XSTNO & "]"
        End If
        If IsNotNull(FEQ_LOCATION) Then
            strMsg &= "[設備ﾛｹｰｼｮﾝ:" & FEQ_LOCATION & "]"
        End If
        If IsNotNull(XCONVEYOR_YOUTO) Then
            strMsg &= "[ｺﾝﾍﾞﾔ用途:" & XCONVEYOR_YOUTO & "]"
        End If
        If IsNotNull(FUPDATE_DT) Then
            strMsg &= "[更新日時:" & FUPDATE_DT & "]"
        End If
        If IsNotNull(XCONVEYOR_GROUP) Then
            strMsg &= "[ｺﾝﾍﾞﾔｸﾞﾙｰﾌﾟ:" & XCONVEYOR_GROUP & "]"
        End If
        If IsNotNull(XCONVEYOR_ORDER) Then
            strMsg &= "[ｺﾝﾍﾞﾔ順:" & XCONVEYOR_ORDER & "]"
        End If
        If IsNotNull(XBERTH_GROUP) Then
            strMsg &= "[ﾊﾞｰｽｸﾞﾙｰﾌﾟ:" & XBERTH_GROUP & "]"
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
