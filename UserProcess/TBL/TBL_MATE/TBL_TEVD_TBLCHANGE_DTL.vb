'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' 【名称】MaterialStreamﾃｰﾌﾞﾙｸﾗｽ
' 【機能】変更履歴詳細ﾃｰﾌﾞﾙｸﾗｽ
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
''' ﾃｰﾌﾞﾙ変更履歴詳細ﾃｰﾌﾞﾙｸﾗｽ
''' </summary>
Public Class TBL_TEVD_TBLCHANGE_DTL
    Inherits clsTemplateTable

    '**********************************************************************************************
    '↓↓↓自動生成部
#Region "  ｸﾗｽ変数定義                  "
    'ﾌﾟﾛﾊﾟﾃｨ
    Private mobjAryMe As TBL_TEVD_TBLCHANGE_DTL()                                '変更履歴詳細
    Private mstrUSER_SQL As String                                               'ﾕｰｻﾞｰSQL
    Private mORDER_BY As String                                                  'OrderBy句
    Private mWHERE As String                                                     'Where句
    Private mFLOG_NO As String                                                   'ﾛｸﾞ№
    Private mFSYORI_ID As String                                                 '処理ID
    Private mFTABLE_NAME As String                                               'ﾃｰﾌﾞﾙ名
    Private mFFIELD_NAME As String                                               'ﾌｨｰﾙﾄﾞ名
    Private mFVALUE_BEFORE As String                                             '更新前情報
    Private mFVALUE_AFTER As String                                              '更新後情報
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                  "
    ''' <summary>
    ''' ｼｽﾃﾑ変数 (自ｸﾗｽ型配列)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_TEVD_TBLCHANGE_DTL()
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
    ''' ﾛｸﾞ№
    ''' </summary>
    Public Property FLOG_NO() As String
        Get
            Return mFLOG_NO
        End Get
        Set(ByVal Value As String)
            mFLOG_NO = Value
        End Set
    End Property
    ''' <summary>
    ''' 処理ID
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
    ''' ﾃｰﾌﾞﾙ名
    ''' </summary>
    Public Property FTABLE_NAME() As String
        Get
            Return mFTABLE_NAME
        End Get
        Set(ByVal Value As String)
            mFTABLE_NAME = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾌｨｰﾙﾄﾞ名
    ''' </summary>
    Public Property FFIELD_NAME() As String
        Get
            Return mFFIELD_NAME
        End Get
        Set(ByVal Value As String)
            mFFIELD_NAME = Value
        End Set
    End Property
    ''' <summary>
    ''' 更新前情報
    ''' </summary>
    Public Property FVALUE_BEFORE() As String
        Get
            Return mFVALUE_BEFORE
        End Get
        Set(ByVal Value As String)
            mFVALUE_BEFORE = Value
        End Set
    End Property
    ''' <summary>
    ''' 更新後情報
    ''' </summary>
    Public Property FVALUE_AFTER() As String
        Get
            Return mFVALUE_AFTER
        End Get
        Set(ByVal Value As String)
            mFVALUE_AFTER = Value
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
    Public Function GET_TEVD_TBLCHANGE_DTL(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    TEVD_TBLCHANGE_DTL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FLOG_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            strSQL.Append(vbCrLf & "    AND FLOG_NO = :" & UBound(strBindField) - 1 & " --ﾛｸﾞ№")
        End If
        If IsNull(FSYORI_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYORI_ID
            strSQL.Append(vbCrLf & "    AND FSYORI_ID = :" & UBound(strBindField) - 1 & " --処理ID")
        End If
        If IsNull(FTABLE_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTABLE_NAME
            strSQL.Append(vbCrLf & "    AND FTABLE_NAME = :" & UBound(strBindField) - 1 & " --ﾃｰﾌﾞﾙ名")
        End If
        If IsNull(FFIELD_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFFIELD_NAME
            strSQL.Append(vbCrLf & "    AND FFIELD_NAME = :" & UBound(strBindField) - 1 & " --ﾌｨｰﾙﾄﾞ名")
        End If
        If IsNull(FVALUE_BEFORE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFVALUE_BEFORE
            strSQL.Append(vbCrLf & "    AND FVALUE_BEFORE = :" & UBound(strBindField) - 1 & " --更新前情報")
        End If
        If IsNull(FVALUE_AFTER) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFVALUE_AFTER
            strSQL.Append(vbCrLf & "    AND FVALUE_AFTER = :" & UBound(strBindField) - 1 & " --更新後情報")
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
        strDataSetName = "TEVD_TBLCHANGE_DTL"
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
    Public Function GET_TEVD_TBLCHANGE_DTL_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    TEVD_TBLCHANGE_DTL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FLOG_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            strSQL.Append(vbCrLf & "    AND FLOG_NO = :" & UBound(strBindField) - 1 & " --ﾛｸﾞ№")
        End If
        If IsNull(FSYORI_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYORI_ID
            strSQL.Append(vbCrLf & "    AND FSYORI_ID = :" & UBound(strBindField) - 1 & " --処理ID")
        End If
        If IsNull(FTABLE_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTABLE_NAME
            strSQL.Append(vbCrLf & "    AND FTABLE_NAME = :" & UBound(strBindField) - 1 & " --ﾃｰﾌﾞﾙ名")
        End If
        If IsNull(FFIELD_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFFIELD_NAME
            strSQL.Append(vbCrLf & "    AND FFIELD_NAME = :" & UBound(strBindField) - 1 & " --ﾌｨｰﾙﾄﾞ名")
        End If
        If IsNull(FVALUE_BEFORE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFVALUE_BEFORE
            strSQL.Append(vbCrLf & "    AND FVALUE_BEFORE = :" & UBound(strBindField) - 1 & " --更新前情報")
        End If
        If IsNull(FVALUE_AFTER) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFVALUE_AFTER
            strSQL.Append(vbCrLf & "    AND FVALUE_AFTER = :" & UBound(strBindField) - 1 & " --更新後情報")
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
        strDataSetName = "TEVD_TBLCHANGE_DTL"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TEVD_TBLCHANGE_DTL(Owner, objDb, objDbLog)
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
    Public Function GET_TEVD_TBLCHANGE_DTL_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "TEVD_TBLCHANGE_DTL"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TEVD_TBLCHANGE_DTL(Owner, objDb, objDbLog)
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
    Public Function GET_TEVD_TBLCHANGE_DTL_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    TEVD_TBLCHANGE_DTL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FLOG_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            strSQL.Append(vbCrLf & "    AND FLOG_NO = :" & UBound(strBindField) - 1 & " --ﾛｸﾞ№")
        End If
        If IsNull(FSYORI_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYORI_ID
            strSQL.Append(vbCrLf & "    AND FSYORI_ID = :" & UBound(strBindField) - 1 & " --処理ID")
        End If
        If IsNull(FTABLE_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTABLE_NAME
            strSQL.Append(vbCrLf & "    AND FTABLE_NAME = :" & UBound(strBindField) - 1 & " --ﾃｰﾌﾞﾙ名")
        End If
        If IsNull(FFIELD_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFFIELD_NAME
            strSQL.Append(vbCrLf & "    AND FFIELD_NAME = :" & UBound(strBindField) - 1 & " --ﾌｨｰﾙﾄﾞ名")
        End If
        If IsNull(FVALUE_BEFORE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFVALUE_BEFORE
            strSQL.Append(vbCrLf & "    AND FVALUE_BEFORE = :" & UBound(strBindField) - 1 & " --更新前情報")
        End If
        If IsNull(FVALUE_AFTER) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFVALUE_AFTER
            strSQL.Append(vbCrLf & "    AND FVALUE_AFTER = :" & UBound(strBindField) - 1 & " --更新後情報")
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
        strDataSetName = "TEVD_TBLCHANGE_DTL"
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
    Public Sub UPDATE_TEVD_TBLCHANGE_DTL()
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
        ElseIf IsNull(mFLOG_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾛｸﾞ№]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFSYORI_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[処理ID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFTABLE_NAME) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾃｰﾌﾞﾙ名]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFFIELD_NAME) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾌｨｰﾙﾄﾞ名]"
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
        strSQL.Append(vbCrLf & "    TEVD_TBLCHANGE_DTL")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
        If IsNull(mFLOG_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_NO = NULL --ﾛｸﾞ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_NO = NULL --ﾛｸﾞ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_NO = :" & Ubound(strBindField) - 1 & " --ﾛｸﾞ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_NO = :" & Ubound(strBindField) - 1 & " --ﾛｸﾞ№")
        End If
        intCount = intCount + 1
        If IsNull(mFSYORI_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSYORI_ID = NULL --処理ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSYORI_ID = NULL --処理ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYORI_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSYORI_ID = :" & Ubound(strBindField) - 1 & " --処理ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSYORI_ID = :" & Ubound(strBindField) - 1 & " --処理ID")
        End If
        intCount = intCount + 1
        If IsNull(mFTABLE_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTABLE_NAME = NULL --ﾃｰﾌﾞﾙ名")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTABLE_NAME = NULL --ﾃｰﾌﾞﾙ名")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTABLE_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTABLE_NAME = :" & Ubound(strBindField) - 1 & " --ﾃｰﾌﾞﾙ名")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTABLE_NAME = :" & Ubound(strBindField) - 1 & " --ﾃｰﾌﾞﾙ名")
        End If
        intCount = intCount + 1
        If IsNull(mFFIELD_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FFIELD_NAME = NULL --ﾌｨｰﾙﾄﾞ名")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FFIELD_NAME = NULL --ﾌｨｰﾙﾄﾞ名")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFFIELD_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FFIELD_NAME = :" & Ubound(strBindField) - 1 & " --ﾌｨｰﾙﾄﾞ名")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FFIELD_NAME = :" & Ubound(strBindField) - 1 & " --ﾌｨｰﾙﾄﾞ名")
        End If
        intCount = intCount + 1
        If IsNull(mFVALUE_BEFORE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FVALUE_BEFORE = NULL --更新前情報")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FVALUE_BEFORE = NULL --更新前情報")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFVALUE_BEFORE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FVALUE_BEFORE = :" & Ubound(strBindField) - 1 & " --更新前情報")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FVALUE_BEFORE = :" & Ubound(strBindField) - 1 & " --更新前情報")
        End If
        intCount = intCount + 1
        If IsNull(mFVALUE_AFTER) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FVALUE_AFTER = NULL --更新後情報")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FVALUE_AFTER = NULL --更新後情報")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFVALUE_AFTER
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FVALUE_AFTER = :" & Ubound(strBindField) - 1 & " --更新後情報")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FVALUE_AFTER = :" & Ubound(strBindField) - 1 & " --更新後情報")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FLOG_NO) = True Then
            strSQL.Append(vbCrLf & "    AND FLOG_NO IS NULL --ﾛｸﾞ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            strSQL.Append(vbCrLf & "    AND FLOG_NO = :" & UBound(strBindField) - 1 & " --ﾛｸﾞ№")
        End If
        If IsNull(FSYORI_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FSYORI_ID IS NULL --処理ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYORI_ID
            strSQL.Append(vbCrLf & "    AND FSYORI_ID = :" & UBound(strBindField) - 1 & " --処理ID")
        End If
        If IsNull(FTABLE_NAME) = True Then
            strSQL.Append(vbCrLf & "    AND FTABLE_NAME IS NULL --ﾃｰﾌﾞﾙ名")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTABLE_NAME
            strSQL.Append(vbCrLf & "    AND FTABLE_NAME = :" & UBound(strBindField) - 1 & " --ﾃｰﾌﾞﾙ名")
        End If
        If IsNull(FFIELD_NAME) = True Then
            strSQL.Append(vbCrLf & "    AND FFIELD_NAME IS NULL --ﾌｨｰﾙﾄﾞ名")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFFIELD_NAME
            strSQL.Append(vbCrLf & "    AND FFIELD_NAME = :" & UBound(strBindField) - 1 & " --ﾌｨｰﾙﾄﾞ名")
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
    Public Sub ADD_TEVD_TBLCHANGE_DTL()
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
        ElseIf IsNull(mFLOG_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾛｸﾞ№]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFSYORI_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[処理ID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFTABLE_NAME) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾃｰﾌﾞﾙ名]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFFIELD_NAME) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾌｨｰﾙﾄﾞ名]"
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
        strSQL.Append(vbCrLf & "    TEVD_TBLCHANGE_DTL")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
        If IsNull(mFLOG_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾛｸﾞ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾛｸﾞ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾛｸﾞ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾛｸﾞ№")
        End If
        intCount = intCount + 1
        If IsNull(mFSYORI_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --処理ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --処理ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYORI_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --処理ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --処理ID")
        End If
        intCount = intCount + 1
        If IsNull(mFTABLE_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾃｰﾌﾞﾙ名")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾃｰﾌﾞﾙ名")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTABLE_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾃｰﾌﾞﾙ名")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾃｰﾌﾞﾙ名")
        End If
        intCount = intCount + 1
        If IsNull(mFFIELD_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾌｨｰﾙﾄﾞ名")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾌｨｰﾙﾄﾞ名")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFFIELD_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾌｨｰﾙﾄﾞ名")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾌｨｰﾙﾄﾞ名")
        End If
        intCount = intCount + 1
        If IsNull(mFVALUE_BEFORE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --更新前情報")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --更新前情報")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFVALUE_BEFORE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --更新前情報")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --更新前情報")
        End If
        intCount = intCount + 1
        If IsNull(mFVALUE_AFTER) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --更新後情報")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --更新後情報")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFVALUE_AFTER
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --更新後情報")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --更新後情報")
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
    Public Sub DELETE_TEVD_TBLCHANGE_DTL()
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
        ElseIf IsNull(mFLOG_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾛｸﾞ№]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFSYORI_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[処理ID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFTABLE_NAME) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾃｰﾌﾞﾙ名]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFFIELD_NAME) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾌｨｰﾙﾄﾞ名]"
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
        strSQL.Append(vbCrLf & "    TEVD_TBLCHANGE_DTL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FLOG_NO) = True Then
            strSQL.Append(vbCrLf & "    AND FLOG_NO IS NULL --ﾛｸﾞ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            strSQL.Append(vbCrLf & "    AND FLOG_NO = :" & UBound(strBindField) - 1 & " --ﾛｸﾞ№")
        End If
        If IsNull(FSYORI_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FSYORI_ID IS NULL --処理ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYORI_ID
            strSQL.Append(vbCrLf & "    AND FSYORI_ID = :" & UBound(strBindField) - 1 & " --処理ID")
        End If
        If IsNull(FTABLE_NAME) = True Then
            strSQL.Append(vbCrLf & "    AND FTABLE_NAME IS NULL --ﾃｰﾌﾞﾙ名")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTABLE_NAME
            strSQL.Append(vbCrLf & "    AND FTABLE_NAME = :" & UBound(strBindField) - 1 & " --ﾃｰﾌﾞﾙ名")
        End If
        If IsNull(FFIELD_NAME) = True Then
            strSQL.Append(vbCrLf & "    AND FFIELD_NAME IS NULL --ﾌｨｰﾙﾄﾞ名")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFFIELD_NAME
            strSQL.Append(vbCrLf & "    AND FFIELD_NAME = :" & UBound(strBindField) - 1 & " --ﾌｨｰﾙﾄﾞ名")
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
    Public Sub DELETE_TEVD_TBLCHANGE_DTL_ANY()
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
        strSQL.Append(vbCrLf & "    TEVD_TBLCHANGE_DTL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(FLOG_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            strSQL.Append(vbCrLf & "    AND FLOG_NO = :" & UBound(strBindField) - 1 & " --ﾛｸﾞ№")
        End If
        If IsNotNull(FSYORI_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYORI_ID
            strSQL.Append(vbCrLf & "    AND FSYORI_ID = :" & UBound(strBindField) - 1 & " --処理ID")
        End If
        If IsNotNull(FTABLE_NAME) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTABLE_NAME
            strSQL.Append(vbCrLf & "    AND FTABLE_NAME = :" & UBound(strBindField) - 1 & " --ﾃｰﾌﾞﾙ名")
        End If
        If IsNotNull(FFIELD_NAME) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFFIELD_NAME
            strSQL.Append(vbCrLf & "    AND FFIELD_NAME = :" & UBound(strBindField) - 1 & " --ﾌｨｰﾙﾄﾞ名")
        End If
        If IsNotNull(FVALUE_BEFORE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFVALUE_BEFORE
            strSQL.Append(vbCrLf & "    AND FVALUE_BEFORE = :" & UBound(strBindField) - 1 & " --更新前情報")
        End If
        If IsNotNull(FVALUE_AFTER) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFVALUE_AFTER
            strSQL.Append(vbCrLf & "    AND FVALUE_AFTER = :" & UBound(strBindField) - 1 & " --更新後情報")
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
        If IsNothing(objType.GetProperty("FLOG_NO")) = False Then mFLOG_NO = objObject.FLOG_NO 'ﾛｸﾞ№
        If IsNothing(objType.GetProperty("FSYORI_ID")) = False Then mFSYORI_ID = objObject.FSYORI_ID '処理ID
        If IsNothing(objType.GetProperty("FTABLE_NAME")) = False Then mFTABLE_NAME = objObject.FTABLE_NAME 'ﾃｰﾌﾞﾙ名
        If IsNothing(objType.GetProperty("FFIELD_NAME")) = False Then mFFIELD_NAME = objObject.FFIELD_NAME 'ﾌｨｰﾙﾄﾞ名
        If IsNothing(objType.GetProperty("FVALUE_BEFORE")) = False Then mFVALUE_BEFORE = objObject.FVALUE_BEFORE '更新前情報
        If IsNothing(objType.GetProperty("FVALUE_AFTER")) = False Then mFVALUE_AFTER = objObject.FVALUE_AFTER '更新後情報

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
        mFLOG_NO = Nothing
        mFSYORI_ID = Nothing
        mFTABLE_NAME = Nothing
        mFFIELD_NAME = Nothing
        mFVALUE_BEFORE = Nothing
        mFVALUE_AFTER = Nothing


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
        mFLOG_NO = TO_STRING_NULLABLE(objRow("FLOG_NO"))
        mFSYORI_ID = TO_STRING_NULLABLE(objRow("FSYORI_ID"))
        mFTABLE_NAME = TO_STRING_NULLABLE(objRow("FTABLE_NAME"))
        mFFIELD_NAME = TO_STRING_NULLABLE(objRow("FFIELD_NAME"))
        mFVALUE_BEFORE = TO_STRING_NULLABLE(objRow("FVALUE_BEFORE"))
        mFVALUE_AFTER = TO_STRING_NULLABLE(objRow("FVALUE_AFTER"))


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
        strMsg &= "[ﾃｰﾌﾞﾙ名:変更履歴詳細]"
        If IsNotNull(FLOG_NO) Then
            strMsg &= "[ﾛｸﾞ№:" & FLOG_NO & "]"
        End If
        If IsNotNull(FSYORI_ID) Then
            strMsg &= "[処理ID:" & FSYORI_ID & "]"
        End If
        If IsNotNull(FTABLE_NAME) Then
            strMsg &= "[ﾃｰﾌﾞﾙ名:" & FTABLE_NAME & "]"
        End If
        If IsNotNull(FFIELD_NAME) Then
            strMsg &= "[ﾌｨｰﾙﾄﾞ名:" & FFIELD_NAME & "]"
        End If
        If IsNotNull(FVALUE_BEFORE) Then
            strMsg &= "[更新前情報:" & FVALUE_BEFORE & "]"
        End If
        If IsNotNull(FVALUE_AFTER) Then
            strMsg &= "[更新後情報:" & FVALUE_AFTER & "]"
        End If


    End Sub
#End Region
    '↑↑↑自動生成部
    '**********************************************************************************************

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ共通
#Region "  ﾃﾞｰﾀ削除(ｺﾞﾐ)                (Public  DELETE_TEVD_TBLCHANGE_DTL_SCRAP)"
    Public Sub DELETE_TEVD_TBLCHANGE_DTL_SCRAP()
        Try
            Dim strSQL As String        'SQL文
            Dim strMsg As String        'ﾒｯｾｰｼﾞ
            Dim intRetSQL As Integer    'SQL実行戻り値


            '***********************
            '削除SQL作成
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "DELETE"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TEVD_TBLCHANGE_DTL"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "    NOT EXISTS"
            strSQL &= vbCrLf & "        ("
            strSQL &= vbCrLf & "        SELECT"
            strSQL &= vbCrLf & "            *"
            strSQL &= vbCrLf & "        FROM"
            strSQL &= vbCrLf & "            TEVD_TBLCHANGE"
            strSQL &= vbCrLf & "        WHERE"
            strSQL &= vbCrLf & "                TEVD_TBLCHANGE.FLOG_NO = TEVD_TBLCHANGE_DTL.FLOG_NO"
            strSQL &= vbCrLf & "            )"
            strSQL &= vbCrLf


            '***********************
            '削除
            '***********************
            intRetSQL = ObjDb.Execute(strSQL)
            If intRetSQL = -1 Then
                '(SQLｴﾗｰ)
                strSQL = Replace(strSQL, vbCrLf, "")
                strMsg = ERRMSG_ERR_DELETE & ObjDb.ErrMsg & "【" & strSQL & "】"
                Throw New UserException(strMsg)
            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
    '↑↑↑ｼｽﾃﾑ共通
    '**********************************************************************************************


    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
