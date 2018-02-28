'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' 【名称】MaterialStreamﾃｰﾌﾞﾙｸﾗｽ
' 【機能】ｼｰｹﾝｽﾅﾝﾊﾞｰ発番ﾃｰﾌﾞﾙｸﾗｽ
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
''' ｼｰｹﾝｽﾅﾝﾊﾞｰ発番ﾃｰﾌﾞﾙｸﾗｽ
''' </summary>
Public Class TBL_TPRG_SEQNO
    Inherits clsTemplateTable

    '**********************************************************************************************
    '↓↓↓自動生成部
#Region "  ｸﾗｽ変数定義                  "
    'ﾌﾟﾛﾊﾟﾃｨ
    Private mobjAryMe As TBL_TPRG_SEQNO()                                        'ｼｰｹﾝｽﾅﾝﾊﾞｰ発番
    Private mstrUSER_SQL As String                                               'ﾕｰｻﾞｰSQL
    Private mORDER_BY As String                                                  'OrderBy句
    Private mWHERE As String                                                     'Where句
    Private mFSEQ_ID As String                                                   'ｼｰｹﾝｽﾅﾝﾊﾞｰID
    Private mFSEQ_NAME As String                                                 'ｼｰｹﾝｽﾅﾝﾊﾞｰ名称
    Private mFSEQ_NO As Nullable(Of Decimal)                                     'ｼｰｹﾝｽﾅﾝﾊﾞｰ
    Private mFSEQ_NO_MAX As Nullable(Of Decimal)                                 'ｼｰｹﾝｽﾅﾝﾊﾞｰ最大値
    Private mFSEQ_NO_MIN As Nullable(Of Decimal)                                 'ｼｰｹﾝｽﾅﾝﾊﾞｰ最小値
    Private mFUPDATE_DT As Nullable(Of Date)                                     '更新日時
    Private mFRESET_DT As Nullable(Of Date)                                      'ﾘｾｯﾄ日時
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                  "
    ''' <summary>
    ''' ｼｽﾃﾑ変数 (自ｸﾗｽ型配列)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_TPRG_SEQNO()
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
    ''' ｼｰｹﾝｽﾅﾝﾊﾞｰID
    ''' </summary>
    Public Property FSEQ_ID() As String
        Get
            Return mFSEQ_ID
        End Get
        Set(ByVal Value As String)
            mFSEQ_ID = Value
        End Set
    End Property
    ''' <summary>
    ''' ｼｰｹﾝｽﾅﾝﾊﾞｰ名称
    ''' </summary>
    Public Property FSEQ_NAME() As String
        Get
            Return mFSEQ_NAME
        End Get
        Set(ByVal Value As String)
            mFSEQ_NAME = Value
        End Set
    End Property
    ''' <summary>
    ''' ｼｰｹﾝｽﾅﾝﾊﾞｰ
    ''' </summary>
    Public Property FSEQ_NO() As Nullable(Of Decimal)
        Get
            Return mFSEQ_NO
        End Get
        Set(ByVal Value As Nullable(Of Decimal))
            mFSEQ_NO = Value
        End Set
    End Property
    ''' <summary>
    ''' ｼｰｹﾝｽﾅﾝﾊﾞｰ最大値
    ''' </summary>
    Public Property FSEQ_NO_MAX() As Nullable(Of Decimal)
        Get
            Return mFSEQ_NO_MAX
        End Get
        Set(ByVal Value As Nullable(Of Decimal))
            mFSEQ_NO_MAX = Value
        End Set
    End Property
    ''' <summary>
    ''' ｼｰｹﾝｽﾅﾝﾊﾞｰ最小値
    ''' </summary>
    Public Property FSEQ_NO_MIN() As Nullable(Of Decimal)
        Get
            Return mFSEQ_NO_MIN
        End Get
        Set(ByVal Value As Nullable(Of Decimal))
            mFSEQ_NO_MIN = Value
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
    ''' ﾘｾｯﾄ日時
    ''' </summary>
    Public Property FRESET_DT() As Nullable(Of Date)
        Get
            Return mFRESET_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mFRESET_DT = Value
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
    Public Function GET_TPRG_SEQNO(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    TPRG_SEQNO")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FSEQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_ID
            strSQL.Append(vbCrLf & "    AND FSEQ_ID = :" & UBound(strBindField) - 1 & " --ｼｰｹﾝｽﾅﾝﾊﾞｰID")
        End If
        If IsNull(FSEQ_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NAME
            strSQL.Append(vbCrLf & "    AND FSEQ_NAME = :" & UBound(strBindField) - 1 & " --ｼｰｹﾝｽﾅﾝﾊﾞｰ名称")
        End If
        If IsNull(FSEQ_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NO
            strSQL.Append(vbCrLf & "    AND FSEQ_NO = :" & UBound(strBindField) - 1 & " --ｼｰｹﾝｽﾅﾝﾊﾞｰ")
        End If
        If IsNull(FSEQ_NO_MAX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NO_MAX
            strSQL.Append(vbCrLf & "    AND FSEQ_NO_MAX = :" & UBound(strBindField) - 1 & " --ｼｰｹﾝｽﾅﾝﾊﾞｰ最大値")
        End If
        If IsNull(FSEQ_NO_MIN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NO_MIN
            strSQL.Append(vbCrLf & "    AND FSEQ_NO_MIN = :" & UBound(strBindField) - 1 & " --ｼｰｹﾝｽﾅﾝﾊﾞｰ最小値")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --更新日時")
        End If
        If IsNull(FRESET_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRESET_DT
            strSQL.Append(vbCrLf & "    AND FRESET_DT = :" & UBound(strBindField) - 1 & " --ﾘｾｯﾄ日時")
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
        strDataSetName = "TPRG_SEQNO"
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
    Public Function GET_TPRG_SEQNO_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    TPRG_SEQNO")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FSEQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_ID
            strSQL.Append(vbCrLf & "    AND FSEQ_ID = :" & UBound(strBindField) - 1 & " --ｼｰｹﾝｽﾅﾝﾊﾞｰID")
        End If
        If IsNull(FSEQ_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NAME
            strSQL.Append(vbCrLf & "    AND FSEQ_NAME = :" & UBound(strBindField) - 1 & " --ｼｰｹﾝｽﾅﾝﾊﾞｰ名称")
        End If
        If IsNull(FSEQ_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NO
            strSQL.Append(vbCrLf & "    AND FSEQ_NO = :" & UBound(strBindField) - 1 & " --ｼｰｹﾝｽﾅﾝﾊﾞｰ")
        End If
        If IsNull(FSEQ_NO_MAX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NO_MAX
            strSQL.Append(vbCrLf & "    AND FSEQ_NO_MAX = :" & UBound(strBindField) - 1 & " --ｼｰｹﾝｽﾅﾝﾊﾞｰ最大値")
        End If
        If IsNull(FSEQ_NO_MIN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NO_MIN
            strSQL.Append(vbCrLf & "    AND FSEQ_NO_MIN = :" & UBound(strBindField) - 1 & " --ｼｰｹﾝｽﾅﾝﾊﾞｰ最小値")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --更新日時")
        End If
        If IsNull(FRESET_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRESET_DT
            strSQL.Append(vbCrLf & "    AND FRESET_DT = :" & UBound(strBindField) - 1 & " --ﾘｾｯﾄ日時")
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
        strDataSetName = "TPRG_SEQNO"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TPRG_SEQNO(Owner, objDb, objDbLog)
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
    Public Function GET_TPRG_SEQNO_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "TPRG_SEQNO"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TPRG_SEQNO(Owner, objDb, objDbLog)
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
    Public Function GET_TPRG_SEQNO_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    TPRG_SEQNO")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FSEQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_ID
            strSQL.Append(vbCrLf & "    AND FSEQ_ID = :" & UBound(strBindField) - 1 & " --ｼｰｹﾝｽﾅﾝﾊﾞｰID")
        End If
        If IsNull(FSEQ_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NAME
            strSQL.Append(vbCrLf & "    AND FSEQ_NAME = :" & UBound(strBindField) - 1 & " --ｼｰｹﾝｽﾅﾝﾊﾞｰ名称")
        End If
        If IsNull(FSEQ_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NO
            strSQL.Append(vbCrLf & "    AND FSEQ_NO = :" & UBound(strBindField) - 1 & " --ｼｰｹﾝｽﾅﾝﾊﾞｰ")
        End If
        If IsNull(FSEQ_NO_MAX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NO_MAX
            strSQL.Append(vbCrLf & "    AND FSEQ_NO_MAX = :" & UBound(strBindField) - 1 & " --ｼｰｹﾝｽﾅﾝﾊﾞｰ最大値")
        End If
        If IsNull(FSEQ_NO_MIN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NO_MIN
            strSQL.Append(vbCrLf & "    AND FSEQ_NO_MIN = :" & UBound(strBindField) - 1 & " --ｼｰｹﾝｽﾅﾝﾊﾞｰ最小値")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --更新日時")
        End If
        If IsNull(FRESET_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRESET_DT
            strSQL.Append(vbCrLf & "    AND FRESET_DT = :" & UBound(strBindField) - 1 & " --ﾘｾｯﾄ日時")
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
        strDataSetName = "TPRG_SEQNO"
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
    Public Sub UPDATE_TPRG_SEQNO()
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
        ElseIf IsNull(mFSEQ_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ｼｰｹﾝｽﾅﾝﾊﾞｰID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFSEQ_NAME) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ｼｰｹﾝｽﾅﾝﾊﾞｰ名称]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFSEQ_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ｼｰｹﾝｽﾅﾝﾊﾞｰ]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFSEQ_NO_MAX) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ｼｰｹﾝｽﾅﾝﾊﾞｰ最大値]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFSEQ_NO_MIN) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ｼｰｹﾝｽﾅﾝﾊﾞｰ最小値]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFUPDATE_DT) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[更新日時]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFRESET_DT) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾘｾｯﾄ日時]"
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
        strSQL.Append(vbCrLf & "    TPRG_SEQNO")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
        If IsNull(mFSEQ_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSEQ_ID = NULL --ｼｰｹﾝｽﾅﾝﾊﾞｰID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSEQ_ID = NULL --ｼｰｹﾝｽﾅﾝﾊﾞｰID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSEQ_ID = :" & Ubound(strBindField) - 1 & " --ｼｰｹﾝｽﾅﾝﾊﾞｰID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSEQ_ID = :" & Ubound(strBindField) - 1 & " --ｼｰｹﾝｽﾅﾝﾊﾞｰID")
        End If
        intCount = intCount + 1
        If IsNull(mFSEQ_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSEQ_NAME = NULL --ｼｰｹﾝｽﾅﾝﾊﾞｰ名称")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSEQ_NAME = NULL --ｼｰｹﾝｽﾅﾝﾊﾞｰ名称")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSEQ_NAME = :" & Ubound(strBindField) - 1 & " --ｼｰｹﾝｽﾅﾝﾊﾞｰ名称")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSEQ_NAME = :" & Ubound(strBindField) - 1 & " --ｼｰｹﾝｽﾅﾝﾊﾞｰ名称")
        End If
        intCount = intCount + 1
        If IsNull(mFSEQ_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSEQ_NO = NULL --ｼｰｹﾝｽﾅﾝﾊﾞｰ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSEQ_NO = NULL --ｼｰｹﾝｽﾅﾝﾊﾞｰ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSEQ_NO = :" & Ubound(strBindField) - 1 & " --ｼｰｹﾝｽﾅﾝﾊﾞｰ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSEQ_NO = :" & Ubound(strBindField) - 1 & " --ｼｰｹﾝｽﾅﾝﾊﾞｰ")
        End If
        intCount = intCount + 1
        If IsNull(mFSEQ_NO_MAX) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSEQ_NO_MAX = NULL --ｼｰｹﾝｽﾅﾝﾊﾞｰ最大値")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSEQ_NO_MAX = NULL --ｼｰｹﾝｽﾅﾝﾊﾞｰ最大値")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NO_MAX
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSEQ_NO_MAX = :" & Ubound(strBindField) - 1 & " --ｼｰｹﾝｽﾅﾝﾊﾞｰ最大値")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSEQ_NO_MAX = :" & Ubound(strBindField) - 1 & " --ｼｰｹﾝｽﾅﾝﾊﾞｰ最大値")
        End If
        intCount = intCount + 1
        If IsNull(mFSEQ_NO_MIN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSEQ_NO_MIN = NULL --ｼｰｹﾝｽﾅﾝﾊﾞｰ最小値")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSEQ_NO_MIN = NULL --ｼｰｹﾝｽﾅﾝﾊﾞｰ最小値")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NO_MIN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSEQ_NO_MIN = :" & Ubound(strBindField) - 1 & " --ｼｰｹﾝｽﾅﾝﾊﾞｰ最小値")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSEQ_NO_MIN = :" & Ubound(strBindField) - 1 & " --ｼｰｹﾝｽﾅﾝﾊﾞｰ最小値")
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
        If IsNull(mFRESET_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRESET_DT = NULL --ﾘｾｯﾄ日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRESET_DT = NULL --ﾘｾｯﾄ日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRESET_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRESET_DT = :" & Ubound(strBindField) - 1 & " --ﾘｾｯﾄ日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRESET_DT = :" & Ubound(strBindField) - 1 & " --ﾘｾｯﾄ日時")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FSEQ_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FSEQ_ID IS NULL --ｼｰｹﾝｽﾅﾝﾊﾞｰID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_ID
            strSQL.Append(vbCrLf & "    AND FSEQ_ID = :" & UBound(strBindField) - 1 & " --ｼｰｹﾝｽﾅﾝﾊﾞｰID")
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
    Public Sub ADD_TPRG_SEQNO()
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
        ElseIf IsNull(mFSEQ_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ｼｰｹﾝｽﾅﾝﾊﾞｰID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFSEQ_NAME) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ｼｰｹﾝｽﾅﾝﾊﾞｰ名称]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFSEQ_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ｼｰｹﾝｽﾅﾝﾊﾞｰ]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFSEQ_NO_MAX) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ｼｰｹﾝｽﾅﾝﾊﾞｰ最大値]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFSEQ_NO_MIN) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ｼｰｹﾝｽﾅﾝﾊﾞｰ最小値]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFUPDATE_DT) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[更新日時]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFRESET_DT) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾘｾｯﾄ日時]"
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
        strSQL.Append(vbCrLf & "    TPRG_SEQNO")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
        If IsNull(mFSEQ_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｼｰｹﾝｽﾅﾝﾊﾞｰID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｼｰｹﾝｽﾅﾝﾊﾞｰID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｼｰｹﾝｽﾅﾝﾊﾞｰID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｼｰｹﾝｽﾅﾝﾊﾞｰID")
        End If
        intCount = intCount + 1
        If IsNull(mFSEQ_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｼｰｹﾝｽﾅﾝﾊﾞｰ名称")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｼｰｹﾝｽﾅﾝﾊﾞｰ名称")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｼｰｹﾝｽﾅﾝﾊﾞｰ名称")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｼｰｹﾝｽﾅﾝﾊﾞｰ名称")
        End If
        intCount = intCount + 1
        If IsNull(mFSEQ_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｼｰｹﾝｽﾅﾝﾊﾞｰ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｼｰｹﾝｽﾅﾝﾊﾞｰ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｼｰｹﾝｽﾅﾝﾊﾞｰ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｼｰｹﾝｽﾅﾝﾊﾞｰ")
        End If
        intCount = intCount + 1
        If IsNull(mFSEQ_NO_MAX) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｼｰｹﾝｽﾅﾝﾊﾞｰ最大値")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｼｰｹﾝｽﾅﾝﾊﾞｰ最大値")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NO_MAX
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｼｰｹﾝｽﾅﾝﾊﾞｰ最大値")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｼｰｹﾝｽﾅﾝﾊﾞｰ最大値")
        End If
        intCount = intCount + 1
        If IsNull(mFSEQ_NO_MIN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｼｰｹﾝｽﾅﾝﾊﾞｰ最小値")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｼｰｹﾝｽﾅﾝﾊﾞｰ最小値")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NO_MIN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｼｰｹﾝｽﾅﾝﾊﾞｰ最小値")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｼｰｹﾝｽﾅﾝﾊﾞｰ最小値")
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
        If IsNull(mFRESET_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾘｾｯﾄ日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾘｾｯﾄ日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRESET_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾘｾｯﾄ日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾘｾｯﾄ日時")
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
    Public Sub DELETE_TPRG_SEQNO()
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
        ElseIf IsNull(mFSEQ_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ｼｰｹﾝｽﾅﾝﾊﾞｰID]"
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
        strSQL.Append(vbCrLf & "    TPRG_SEQNO")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FSEQ_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FSEQ_ID IS NULL --ｼｰｹﾝｽﾅﾝﾊﾞｰID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_ID
            strSQL.Append(vbCrLf & "    AND FSEQ_ID = :" & UBound(strBindField) - 1 & " --ｼｰｹﾝｽﾅﾝﾊﾞｰID")
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
    Public Sub DELETE_TPRG_SEQNO_ANY()
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
        strSQL.Append(vbCrLf & "    TPRG_SEQNO")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(FSEQ_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_ID
            strSQL.Append(vbCrLf & "    AND FSEQ_ID = :" & UBound(strBindField) - 1 & " --ｼｰｹﾝｽﾅﾝﾊﾞｰID")
        End If
        If IsNotNull(FSEQ_NAME) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NAME
            strSQL.Append(vbCrLf & "    AND FSEQ_NAME = :" & UBound(strBindField) - 1 & " --ｼｰｹﾝｽﾅﾝﾊﾞｰ名称")
        End If
        If IsNotNull(FSEQ_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NO
            strSQL.Append(vbCrLf & "    AND FSEQ_NO = :" & UBound(strBindField) - 1 & " --ｼｰｹﾝｽﾅﾝﾊﾞｰ")
        End If
        If IsNotNull(FSEQ_NO_MAX) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NO_MAX
            strSQL.Append(vbCrLf & "    AND FSEQ_NO_MAX = :" & UBound(strBindField) - 1 & " --ｼｰｹﾝｽﾅﾝﾊﾞｰ最大値")
        End If
        If IsNotNull(FSEQ_NO_MIN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEQ_NO_MIN
            strSQL.Append(vbCrLf & "    AND FSEQ_NO_MIN = :" & UBound(strBindField) - 1 & " --ｼｰｹﾝｽﾅﾝﾊﾞｰ最小値")
        End If
        If IsNotNull(FUPDATE_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --更新日時")
        End If
        If IsNotNull(FRESET_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRESET_DT
            strSQL.Append(vbCrLf & "    AND FRESET_DT = :" & UBound(strBindField) - 1 & " --ﾘｾｯﾄ日時")
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
        If IsNothing(objType.GetProperty("FSEQ_ID")) = False Then mFSEQ_ID = objObject.FSEQ_ID 'ｼｰｹﾝｽﾅﾝﾊﾞｰID
        If IsNothing(objType.GetProperty("FSEQ_NAME")) = False Then mFSEQ_NAME = objObject.FSEQ_NAME 'ｼｰｹﾝｽﾅﾝﾊﾞｰ名称
        If IsNothing(objType.GetProperty("FSEQ_NO")) = False Then mFSEQ_NO = objObject.FSEQ_NO 'ｼｰｹﾝｽﾅﾝﾊﾞｰ
        If IsNothing(objType.GetProperty("FSEQ_NO_MAX")) = False Then mFSEQ_NO_MAX = objObject.FSEQ_NO_MAX 'ｼｰｹﾝｽﾅﾝﾊﾞｰ最大値
        If IsNothing(objType.GetProperty("FSEQ_NO_MIN")) = False Then mFSEQ_NO_MIN = objObject.FSEQ_NO_MIN 'ｼｰｹﾝｽﾅﾝﾊﾞｰ最小値
        If IsNothing(objType.GetProperty("FUPDATE_DT")) = False Then mFUPDATE_DT = objObject.FUPDATE_DT '更新日時
        If IsNothing(objType.GetProperty("FRESET_DT")) = False Then mFRESET_DT = objObject.FRESET_DT 'ﾘｾｯﾄ日時

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
        mFSEQ_ID = Nothing
        mFSEQ_NAME = Nothing
        mFSEQ_NO = Nothing
        mFSEQ_NO_MAX = Nothing
        mFSEQ_NO_MIN = Nothing
        mFUPDATE_DT = Nothing
        mFRESET_DT = Nothing


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
        mFSEQ_ID = TO_STRING_NULLABLE(objRow("FSEQ_ID"))
        mFSEQ_NAME = TO_STRING_NULLABLE(objRow("FSEQ_NAME"))
        mFSEQ_NO = TO_DECIMAL_NULLABLE(objRow("FSEQ_NO"))
        mFSEQ_NO_MAX = TO_DECIMAL_NULLABLE(objRow("FSEQ_NO_MAX"))
        mFSEQ_NO_MIN = TO_DECIMAL_NULLABLE(objRow("FSEQ_NO_MIN"))
        mFUPDATE_DT = TO_DATE_NULLABLE(objRow("FUPDATE_DT"))
        mFRESET_DT = TO_DATE_NULLABLE(objRow("FRESET_DT"))


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
        strMsg &= "[ﾃｰﾌﾞﾙ名:ｼｰｹﾝｽﾅﾝﾊﾞｰ発番]"
        If IsNotNull(FSEQ_ID) Then
            strMsg &= "[ｼｰｹﾝｽﾅﾝﾊﾞｰID:" & FSEQ_ID & "]"
        End If
        If IsNotNull(FSEQ_NAME) Then
            strMsg &= "[ｼｰｹﾝｽﾅﾝﾊﾞｰ名称:" & FSEQ_NAME & "]"
        End If
        If IsNotNull(FSEQ_NO) Then
            strMsg &= "[ｼｰｹﾝｽﾅﾝﾊﾞｰ:" & FSEQ_NO & "]"
        End If
        If IsNotNull(FSEQ_NO_MAX) Then
            strMsg &= "[ｼｰｹﾝｽﾅﾝﾊﾞｰ最大値:" & FSEQ_NO_MAX & "]"
        End If
        If IsNotNull(FSEQ_NO_MIN) Then
            strMsg &= "[ｼｰｹﾝｽﾅﾝﾊﾞｰ最小値:" & FSEQ_NO_MIN & "]"
        End If
        If IsNotNull(FUPDATE_DT) Then
            strMsg &= "[更新日時:" & FUPDATE_DT & "]"
        End If
        If IsNotNull(FRESET_DT) Then
            strMsg &= "[ﾘｾｯﾄ日時:" & FRESET_DT & "]"
        End If


    End Sub
#End Region
    '↑↑↑自動生成部
    '**********************************************************************************************

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ共通
#Region "  登録№取得更新(ComErrorなし)                         (Public  GET_ENTRY_NO)"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】なし
    '【戻値】登録№
    '*******************************************************************************************************************
    Public Function GET_ENTRY_NO() As String
        Try
            Dim strReturn As String     '戻値


            '******************************************************
            'ｼｰｹﾝｽﾅﾝﾊﾞｰ取得
            '******************************************************
            strReturn = GET_ENTRY_NO_KETA(8)


            Return (strReturn)
        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "  登録№取得更新(ComErrorなし日付部分以外の桁数指定)   (Public  GET_ENTRY_NO_KETA)"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】なし
    '【戻値】登録№
    '*******************************************************************************************************************
    Public Function GET_ENTRY_NO_KETA(ByVal intKeta As Integer) As String
        Try
            Dim strReturn As String     '戻値


            '******************************************************
            'ｼｰｹﾝｽﾅﾝﾊﾞｰ取得
            '******************************************************
            Dim objTPRG_SEQNO As New clsSeqNo(ObjDbLog)
            Dim intSeqNo As Integer                         'ｼｰｹﾝｽ№
            objTPRG_SEQNO.userFSEQ_ID = FSEQ_ID             'ｼｰｹﾝｽﾅﾝﾊﾞｰID
            '' ''objTPRG_SEQNO.userstrDBName = "Genshi"          'DB名
            objTPRG_SEQNO.userstrTableName = "TPRG_SEQNO"   'ﾃｰﾌﾞﾙ名
            intSeqNo = objTPRG_SEQNO.userGetUpdateSeqNo()   'ｼｰｹﾝｽ№取得


            '******************************************************
            '情報取得
            '******************************************************
            Call GET_TPRG_SEQNO_COMERRNOTHING()


            '↓↓↓↓↓↓************************************************************************************************************
            'SystemMate:N.Dounoshita 2012/12/25  SEQ№発番時にﾘｾｯﾄされないﾊﾞｸﾞ修正
            '                                    日付が切り替わった瞬間に、二つのexeが同時にSEQ№を発番した場合、ﾀｲﾐﾝｸﾞによっては片方がSEQ№ﾘｾｯﾄされない場合がある。


            ''******************************************************
            ''ｼｰｹﾝｽﾅﾝﾊﾞｰﾘｾｯﾄ
            ''******************************************************
            'Dim strResetDate As String = Format(mFRESET_DT, "yyyy/MM/dd")       'ﾘｾｯﾄ日付
            'Dim strUpdateDate As String = Format(mFUPDATE_DT, "yyyy/MM/dd")     '更新日時
            'Dim dtmResetDate As Date = CDate(strResetDate)                      'ﾘｾｯﾄ日付
            'Dim dtmUpdateDate As Date = CDate(strUpdateDate)                    '更新日時
            'If DateAdd(DateInterval.Day, 1, dtmResetDate) <= dtmUpdateDate Then
            '    '(最終ﾘｾｯﾄ日時から一日以上経過していた場合)

            '    Call objTPRG_SEQNO.userResetSeqNo()             'ｼｰｹﾝｽ№ﾘｾｯﾄ
            '    intSeqNo = objTPRG_SEQNO.userGetUpdateSeqNo()   'ｼｰｹﾝｽ№取得
            '    Call GET_TPRG_SEQNO_COMERRNOTHING()             '情報取得

            'End If


            '↑↑↑↑↑↑************************************************************************************************************


            '******************************************************
            'ﾛｸﾞﾅﾝﾊﾞｰ作成
            '******************************************************
            Dim strLogDate As String = Format(mFRESET_DT, "yyyyMMdd")       '更新日時
            strReturn = strLogDate & ZERO_PAD(intSeqNo, intKeta)            'ﾛｸﾞﾅﾝﾊﾞｰ作成


            Return (strReturn)
        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "  登録№取得更新(ｻｲｸﾘｯｸ用)(ComErrorなし)               (Public  GET_ENTRY_NO_CYCLIC)"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】なし
    '【戻値】登録№
    '*******************************************************************************************************************
    Public Function GET_ENTRY_NO_CYCLIC() As String
        Try
            Dim strReturn As String     '戻値


            '******************************************************
            'ｼｰｹﾝｽﾅﾝﾊﾞｰ取得
            '******************************************************
            Dim objTPRG_SEQNO As New clsSeqNo(ObjDbLog)
            Dim intSeqNo As Integer                         'ｼｰｹﾝｽ№
            objTPRG_SEQNO.userFSEQ_ID = FSEQ_ID             'ｼｰｹﾝｽﾅﾝﾊﾞｰID
            '' ''objTPRG_SEQNO.userstrDBName = "Genshi"          'DB名
            objTPRG_SEQNO.userstrTableName = "TPRG_SEQNO"   'ﾃｰﾌﾞﾙ名
            intSeqNo = objTPRG_SEQNO.userGetUpdateSeqNo()   'ｼｰｹﾝｽ№取得


            '******************************************************
            '情報取得
            '******************************************************
            Call GET_TPRG_SEQNO_COMERRNOTHING()


            '******************************************************
            'ﾛｸﾞﾅﾝﾊﾞｰ作成
            '******************************************************
            Dim strLogDate As String = Format(mFUPDATE_DT, "yyyyMMdd")      '更新日時
            strReturn = ZERO_PAD(intSeqNo, 16)                              'ﾛｸﾞﾅﾝﾊﾞｰ作成


            Return (strReturn)
        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "  ｼｰｹﾝｽﾅﾝﾊﾞｰ発番取得(ComErrorなし)                     (Private GET_TPRG_SEQNO_COMERRNOTHING)"
    Private Function GET_TPRG_SEQNO_COMERRNOTHING() As RetCode
        Try
            Dim strSQL As String            'SQL文
            Dim strMsg As String            'ﾒｯｾｰｼﾞ
            Dim objDataSet As New DataSet   'ﾃﾞｰﾀｾｯﾄ
            Dim strDataSetName As String    'ﾃﾞｰﾀｾｯﾄ名
            Dim objRow As DataRow           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ

            '***********************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '***********************
            If mFSEQ_ID = DEFAULT_STRING Then
                strMsg = ERRMSG_ERR_PROPERTY & "[ｼｰｹﾝｽﾅﾝﾊﾞｰID]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '抽出SQL作成
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    *"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TPRG_SEQNO"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FSEQ_ID = '" & TO_STRING(mFSEQ_ID) & "'"
            strSQL &= vbCrLf


            '***********************
            '抽出
            '***********************
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TPRG_SEQNO"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                objRow = objDataSet.Tables(strDataSetName).Rows(0)
                Call SET_DATA(objRow)
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

#Region "  登録№取得更新(ComErrorなし日付なし桁数指定)   (Public  GET_ENTRY_NO_KETA_NODATE)"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】なし
    '【戻値】登録№
    '*******************************************************************************************************************
    Public Function GET_ENTRY_NO_KETA_NODATE(ByVal intKeta As Integer) As String
        Try
            Dim strReturn As String     '戻値


            '******************************************************
            'ｼｰｹﾝｽﾅﾝﾊﾞｰ取得
            '******************************************************
            Dim objTPRG_SEQNO As New clsSeqNo(ObjDbLog)
            Dim intSeqNo As Integer                         'ｼｰｹﾝｽ№
            objTPRG_SEQNO.userFSEQ_ID = FSEQ_ID             'ｼｰｹﾝｽﾅﾝﾊﾞｰID
            '' ''objTPRG_SEQNO.userstrDBName = "Genshi"          'DB名
            objTPRG_SEQNO.userstrTableName = "TPRG_SEQNO"   'ﾃｰﾌﾞﾙ名
            intSeqNo = objTPRG_SEQNO.userGetUpdateSeqNo()   'ｼｰｹﾝｽ№取得


            '******************************************************
            '情報取得
            '******************************************************
            Call GET_TPRG_SEQNO_COMERRNOTHING()


            '↓↓↓↓↓↓************************************************************************************************************
            'SystemMate:N.Dounoshita 2012/12/25  SEQ№発番時にﾘｾｯﾄされないﾊﾞｸﾞ修正
            '                                    日付が切り替わった瞬間に、二つのexeが同時にSEQ№を発番した場合、ﾀｲﾐﾝｸﾞによっては片方がSEQ№ﾘｾｯﾄされない場合がある。


            ''******************************************************
            ''ｼｰｹﾝｽﾅﾝﾊﾞｰﾘｾｯﾄ
            ''******************************************************
            'Dim strResetDate As String = Format(mFRESET_DT, "yyyy/MM/dd")       'ﾘｾｯﾄ日付
            'Dim strUpdateDate As String = Format(mFUPDATE_DT, "yyyy/MM/dd")     '更新日時
            'Dim dtmResetDate As Date = CDate(strResetDate)                      'ﾘｾｯﾄ日付
            'Dim dtmUpdateDate As Date = CDate(strUpdateDate)                    '更新日時
            'If DateAdd(DateInterval.Day, 1, dtmResetDate) <= dtmUpdateDate Then
            '    '(最終ﾘｾｯﾄ日時から一日以上経過していた場合)

            '    Call objTPRG_SEQNO.userResetSeqNo()             'ｼｰｹﾝｽ№ﾘｾｯﾄ
            '    intSeqNo = objTPRG_SEQNO.userGetUpdateSeqNo()   'ｼｰｹﾝｽ№取得
            '    Call GET_TPRG_SEQNO_COMERRNOTHING()             '情報取得

            'End If


            '↑↑↑↑↑↑************************************************************************************************************


            '******************************************************
            'ﾛｸﾞﾅﾝﾊﾞｰ作成
            '******************************************************

            Dim strLogDate As String = Format(mFRESET_DT, "yyMMdd")       '更新日時
            strReturn = Right(strLogDate & ZERO_PAD(intSeqNo, intKeta - 6), intKeta)            'ﾛｸﾞﾅﾝﾊﾞｰ作成


            Return (strReturn)
        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

    '↑↑↑ｼｽﾃﾑ共通
    '**********************************************************************************************


    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
