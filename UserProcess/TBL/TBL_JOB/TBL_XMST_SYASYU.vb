'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' 【名称】MaterialStreamﾃｰﾌﾞﾙｸﾗｽ
' 【機能】輸送手段ﾏｽﾀﾃｰﾌﾞﾙｸﾗｽ
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
''' 輸送手段ﾏｽﾀﾃｰﾌﾞﾙｸﾗｽ
''' </summary>
Public Class TBL_XMST_SYASYU
    Inherits clsTemplateTable

    '**********************************************************************************************
    '↓↓↓自動生成部
#Region "  ｸﾗｽ変数定義                  "
    'ﾌﾟﾛﾊﾟﾃｨ
    Private mobjAryMe As TBL_XMST_SYASYU()                                       '輸送手段ﾏｽﾀ
    Private mstrUSER_SQL As String                                               'ﾕｰｻﾞｰSQL
    Private mORDER_BY As String                                                  'OrderBy句
    Private mWHERE As String                                                     'Where句
    Private mXSYASYU_KBN As String                                               '車種区分
    Private mXSYASYU_NAME As String                                              '車種名称
    Private mFENTRY_DT As Nullable(Of Date)                                      '登録日時
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                  "
    ''' <summary>
    ''' ｼｽﾃﾑ変数 (自ｸﾗｽ型配列)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_XMST_SYASYU()
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
    ''' 車種名称
    ''' </summary>
    Public Property XSYASYU_NAME() As String
        Get
            Return mXSYASYU_NAME
        End Get
        Set(ByVal Value As String)
            mXSYASYU_NAME = Value
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
    Public Function GET_XMST_SYASYU(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    XMST_SYASYU")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XSYASYU_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYASYU_KBN
            strSQL.Append(vbCrLf & "    AND XSYASYU_KBN = :" & UBound(strBindField) - 1 & " --車種区分")
        End If
        If IsNull(XSYASYU_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYASYU_NAME
            strSQL.Append(vbCrLf & "    AND XSYASYU_NAME = :" & UBound(strBindField) - 1 & " --車種名称")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --登録日時")
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
        strDataSetName = "XMST_SYASYU"
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
    Public Function GET_XMST_SYASYU_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    XMST_SYASYU")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XSYASYU_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYASYU_KBN
            strSQL.Append(vbCrLf & "    AND XSYASYU_KBN = :" & UBound(strBindField) - 1 & " --車種区分")
        End If
        If IsNull(XSYASYU_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYASYU_NAME
            strSQL.Append(vbCrLf & "    AND XSYASYU_NAME = :" & UBound(strBindField) - 1 & " --車種名称")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --登録日時")
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
        strDataSetName = "XMST_SYASYU"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XMST_SYASYU(Owner, objDb, objDbLog)
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
    Public Function GET_XMST_SYASYU_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "XMST_SYASYU"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XMST_SYASYU(Owner, objDb, objDbLog)
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
    Public Function GET_XMST_SYASYU_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    XMST_SYASYU")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XSYASYU_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYASYU_KBN
            strSQL.Append(vbCrLf & "    AND XSYASYU_KBN = :" & UBound(strBindField) - 1 & " --車種区分")
        End If
        If IsNull(XSYASYU_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYASYU_NAME
            strSQL.Append(vbCrLf & "    AND XSYASYU_NAME = :" & UBound(strBindField) - 1 & " --車種名称")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --登録日時")
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
        strDataSetName = "XMST_SYASYU"
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
    Public Sub UPDATE_XMST_SYASYU()
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
        ElseIf IsNull(mXSYASYU_KBN) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[車種区分]"
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
        strSQL.Append(vbCrLf & "    XMST_SYASYU")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
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
        If IsNull(mXSYASYU_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYASYU_NAME = NULL --車種名称")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYASYU_NAME = NULL --車種名称")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYASYU_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYASYU_NAME = :" & Ubound(strBindField) - 1 & " --車種名称")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYASYU_NAME = :" & Ubound(strBindField) - 1 & " --車種名称")
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
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(XSYASYU_KBN) = True Then
            strSQL.Append(vbCrLf & "    AND XSYASYU_KBN IS NULL --車種区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYASYU_KBN
            strSQL.Append(vbCrLf & "    AND XSYASYU_KBN = :" & UBound(strBindField) - 1 & " --車種区分")
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
    Public Sub ADD_XMST_SYASYU()
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
        ElseIf IsNull(mXSYASYU_KBN) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[車種区分]"
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
        strSQL.Append(vbCrLf & "    XMST_SYASYU")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
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
        If IsNull(mXSYASYU_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --車種名称")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --車種名称")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYASYU_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --車種名称")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --車種名称")
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
    Public Sub DELETE_XMST_SYASYU()
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
        ElseIf IsNull(mXSYASYU_KBN) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[車種区分]"
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
        strSQL.Append(vbCrLf & "    XMST_SYASYU")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(XSYASYU_KBN) = True Then
            strSQL.Append(vbCrLf & "    AND XSYASYU_KBN IS NULL --車種区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYASYU_KBN
            strSQL.Append(vbCrLf & "    AND XSYASYU_KBN = :" & UBound(strBindField) - 1 & " --車種区分")
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
    Public Sub DELETE_XMST_SYASYU_ANY()
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
        strSQL.Append(vbCrLf & "    XMST_SYASYU")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(XSYASYU_KBN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYASYU_KBN
            strSQL.Append(vbCrLf & "    AND XSYASYU_KBN = :" & UBound(strBindField) - 1 & " --車種区分")
        End If
        If IsNotNull(XSYASYU_NAME) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYASYU_NAME
            strSQL.Append(vbCrLf & "    AND XSYASYU_NAME = :" & UBound(strBindField) - 1 & " --車種名称")
        End If
        If IsNotNull(FENTRY_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --登録日時")
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
        If IsNothing(objType.GetProperty("XSYASYU_KBN")) = False Then mXSYASYU_KBN = objObject.XSYASYU_KBN '車種区分
        If IsNothing(objType.GetProperty("XSYASYU_NAME")) = False Then mXSYASYU_NAME = objObject.XSYASYU_NAME '車種名称
        If IsNothing(objType.GetProperty("FENTRY_DT")) = False Then mFENTRY_DT = objObject.FENTRY_DT '登録日時

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
        mXSYASYU_KBN = Nothing
        mXSYASYU_NAME = Nothing
        mFENTRY_DT = Nothing


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
        mXSYASYU_KBN = TO_STRING_NULLABLE(objRow("XSYASYU_KBN"))
        mXSYASYU_NAME = TO_STRING_NULLABLE(objRow("XSYASYU_NAME"))
        mFENTRY_DT = TO_DATE_NULLABLE(objRow("FENTRY_DT"))


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
        strMsg &= "[ﾃｰﾌﾞﾙ名:輸送手段ﾏｽﾀ]"
        If IsNotNull(XSYASYU_KBN) Then
            strMsg &= "[車種区分:" & XSYASYU_KBN & "]"
        End If
        If IsNotNull(XSYASYU_NAME) Then
            strMsg &= "[車種名称:" & XSYASYU_NAME & "]"
        End If
        If IsNotNull(FENTRY_DT) Then
            strMsg &= "[登録日時:" & FENTRY_DT & "]"
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
