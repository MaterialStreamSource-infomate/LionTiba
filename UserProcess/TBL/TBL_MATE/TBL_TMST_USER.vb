'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' 【名称】MaterialStreamﾃｰﾌﾞﾙｸﾗｽ
' 【機能】ﾕｰｻﾞｰﾏｽﾀﾃｰﾌﾞﾙｸﾗｽ
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
''' ﾕｰｻﾞｰﾏｽﾀﾃｰﾌﾞﾙｸﾗｽ
''' </summary>
Public Class TBL_TMST_USER
    Inherits clsTemplateTable

    '**********************************************************************************************
    '↓↓↓自動生成部
#Region "  ｸﾗｽ変数定義                  "
    'ﾌﾟﾛﾊﾟﾃｨ
    Private mobjAryMe As TBL_TMST_USER()                                         'ﾕｰｻﾞｰﾏｽﾀ
    Private mstrUSER_SQL As String                                               'ﾕｰｻﾞｰSQL
    Private mORDER_BY As String                                                  'OrderBy句
    Private mWHERE As String                                                     'Where句
    Private mFUSER_ID As String                                                  'ﾕｰｻﾞｰID
    Private mFUSER_NAME As String                                                '名前
    Private mFPASS_WORD As String                                                'ﾊﾟｽﾜｰﾄﾞ
    Private mFPASS_WORDUP_DT As Nullable(Of Date)                                'ﾊﾟｽﾜｰﾄﾞ更新日時
    Private mFLOGIN_ID As String                                                 'ﾛｸﾞｲﾝID
    Private mFUSER_ATEST As Nullable(Of Integer)                                 'ﾕｰｻﾞｰ認証状況
    Private mFWARNING_COUNT As Nullable(Of Integer)                              '不正ｱｸｾｽ回数
    Private mFLOCK_DT As Nullable(Of Date)                                       'ﾛｯｸ日時
    Private mFENTRY_TERM_ID As String                                            '登録端末ID
    Private mFENTRY_USER_ID As String                                            '登録ﾕｰｻﾞｰID
    Private mFENTRY_USER_NAME As String                                          '登録ﾕｰｻﾞｰ名
    Private mFENTRY_DT As Nullable(Of Date)                                      '登録日時
    Private mFUPDATE_TERM_ID As String                                           '更新端末ID
    Private mFUPDATE_USER_ID As String                                           '更新ﾕｰｻﾞｰID
    Private mFUPDATE_USER_NAME As String                                         '更新ﾕｰｻﾞｰ名
    Private mFUPDATE_DT As Nullable(Of Date)                                     '更新日時
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                  "
    ''' <summary>
    ''' ｼｽﾃﾑ変数 (自ｸﾗｽ型配列)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_TMST_USER()
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
    ''' ﾕｰｻﾞｰID
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
    ''' 名前
    ''' </summary>
    Public Property FUSER_NAME() As String
        Get
            Return mFUSER_NAME
        End Get
        Set(ByVal Value As String)
            mFUSER_NAME = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾊﾟｽﾜｰﾄﾞ
    ''' </summary>
    Public Property FPASS_WORD() As String
        Get
            Return mFPASS_WORD
        End Get
        Set(ByVal Value As String)
            mFPASS_WORD = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾊﾟｽﾜｰﾄﾞ更新日時
    ''' </summary>
    Public Property FPASS_WORDUP_DT() As Nullable(Of Date)
        Get
            Return mFPASS_WORDUP_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mFPASS_WORDUP_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾛｸﾞｲﾝID
    ''' </summary>
    Public Property FLOGIN_ID() As String
        Get
            Return mFLOGIN_ID
        End Get
        Set(ByVal Value As String)
            mFLOGIN_ID = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾕｰｻﾞｰ認証状況
    ''' </summary>
    Public Property FUSER_ATEST() As Nullable(Of Integer)
        Get
            Return mFUSER_ATEST
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFUSER_ATEST = Value
        End Set
    End Property
    ''' <summary>
    ''' 不正ｱｸｾｽ回数
    ''' </summary>
    Public Property FWARNING_COUNT() As Nullable(Of Integer)
        Get
            Return mFWARNING_COUNT
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFWARNING_COUNT = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾛｯｸ日時
    ''' </summary>
    Public Property FLOCK_DT() As Nullable(Of Date)
        Get
            Return mFLOCK_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mFLOCK_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' 登録端末ID
    ''' </summary>
    Public Property FENTRY_TERM_ID() As String
        Get
            Return mFENTRY_TERM_ID
        End Get
        Set(ByVal Value As String)
            mFENTRY_TERM_ID = Value
        End Set
    End Property
    ''' <summary>
    ''' 登録ﾕｰｻﾞｰID
    ''' </summary>
    Public Property FENTRY_USER_ID() As String
        Get
            Return mFENTRY_USER_ID
        End Get
        Set(ByVal Value As String)
            mFENTRY_USER_ID = Value
        End Set
    End Property
    ''' <summary>
    ''' 登録ﾕｰｻﾞｰ名
    ''' </summary>
    Public Property FENTRY_USER_NAME() As String
        Get
            Return mFENTRY_USER_NAME
        End Get
        Set(ByVal Value As String)
            mFENTRY_USER_NAME = Value
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
    ''' 更新端末ID
    ''' </summary>
    Public Property FUPDATE_TERM_ID() As String
        Get
            Return mFUPDATE_TERM_ID
        End Get
        Set(ByVal Value As String)
            mFUPDATE_TERM_ID = Value
        End Set
    End Property
    ''' <summary>
    ''' 更新ﾕｰｻﾞｰID
    ''' </summary>
    Public Property FUPDATE_USER_ID() As String
        Get
            Return mFUPDATE_USER_ID
        End Get
        Set(ByVal Value As String)
            mFUPDATE_USER_ID = Value
        End Set
    End Property
    ''' <summary>
    ''' 更新ﾕｰｻﾞｰ名
    ''' </summary>
    Public Property FUPDATE_USER_NAME() As String
        Get
            Return mFUPDATE_USER_NAME
        End Get
        Set(ByVal Value As String)
            mFUPDATE_USER_NAME = Value
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
    Public Function GET_TMST_USER(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    TMST_USER")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FUSER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID
            strSQL.Append(vbCrLf & "    AND FUSER_ID = :" & UBound(strBindField) - 1 & " --ﾕｰｻﾞｰID")
        End If
        If IsNull(FUSER_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME
            strSQL.Append(vbCrLf & "    AND FUSER_NAME = :" & UBound(strBindField) - 1 & " --名前")
        End If
        If IsNull(FPASS_WORD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPASS_WORD
            strSQL.Append(vbCrLf & "    AND FPASS_WORD = :" & UBound(strBindField) - 1 & " --ﾊﾟｽﾜｰﾄﾞ")
        End If
        If IsNull(FPASS_WORDUP_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPASS_WORDUP_DT
            strSQL.Append(vbCrLf & "    AND FPASS_WORDUP_DT = :" & UBound(strBindField) - 1 & " --ﾊﾟｽﾜｰﾄﾞ更新日時")
        End If
        If IsNull(FLOGIN_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOGIN_ID
            strSQL.Append(vbCrLf & "    AND FLOGIN_ID = :" & UBound(strBindField) - 1 & " --ﾛｸﾞｲﾝID")
        End If
        If IsNull(FUSER_ATEST) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ATEST
            strSQL.Append(vbCrLf & "    AND FUSER_ATEST = :" & UBound(strBindField) - 1 & " --ﾕｰｻﾞｰ認証状況")
        End If
        If IsNull(FWARNING_COUNT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFWARNING_COUNT
            strSQL.Append(vbCrLf & "    AND FWARNING_COUNT = :" & UBound(strBindField) - 1 & " --不正ｱｸｾｽ回数")
        End If
        If IsNull(FLOCK_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOCK_DT
            strSQL.Append(vbCrLf & "    AND FLOCK_DT = :" & UBound(strBindField) - 1 & " --ﾛｯｸ日時")
        End If
        If IsNull(FENTRY_TERM_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_TERM_ID
            strSQL.Append(vbCrLf & "    AND FENTRY_TERM_ID = :" & UBound(strBindField) - 1 & " --登録端末ID")
        End If
        If IsNull(FENTRY_USER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_USER_ID
            strSQL.Append(vbCrLf & "    AND FENTRY_USER_ID = :" & UBound(strBindField) - 1 & " --登録ﾕｰｻﾞｰID")
        End If
        If IsNull(FENTRY_USER_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_USER_NAME
            strSQL.Append(vbCrLf & "    AND FENTRY_USER_NAME = :" & UBound(strBindField) - 1 & " --登録ﾕｰｻﾞｰ名")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --登録日時")
        End If
        If IsNull(FUPDATE_TERM_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_TERM_ID
            strSQL.Append(vbCrLf & "    AND FUPDATE_TERM_ID = :" & UBound(strBindField) - 1 & " --更新端末ID")
        End If
        If IsNull(FUPDATE_USER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_USER_ID
            strSQL.Append(vbCrLf & "    AND FUPDATE_USER_ID = :" & UBound(strBindField) - 1 & " --更新ﾕｰｻﾞｰID")
        End If
        If IsNull(FUPDATE_USER_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_USER_NAME
            strSQL.Append(vbCrLf & "    AND FUPDATE_USER_NAME = :" & UBound(strBindField) - 1 & " --更新ﾕｰｻﾞｰ名")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --更新日時")
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
        strDataSetName = "TMST_USER"
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
    Public Function GET_TMST_USER_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    TMST_USER")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FUSER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID
            strSQL.Append(vbCrLf & "    AND FUSER_ID = :" & UBound(strBindField) - 1 & " --ﾕｰｻﾞｰID")
        End If
        If IsNull(FUSER_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME
            strSQL.Append(vbCrLf & "    AND FUSER_NAME = :" & UBound(strBindField) - 1 & " --名前")
        End If
        If IsNull(FPASS_WORD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPASS_WORD
            strSQL.Append(vbCrLf & "    AND FPASS_WORD = :" & UBound(strBindField) - 1 & " --ﾊﾟｽﾜｰﾄﾞ")
        End If
        If IsNull(FPASS_WORDUP_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPASS_WORDUP_DT
            strSQL.Append(vbCrLf & "    AND FPASS_WORDUP_DT = :" & UBound(strBindField) - 1 & " --ﾊﾟｽﾜｰﾄﾞ更新日時")
        End If
        If IsNull(FLOGIN_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOGIN_ID
            strSQL.Append(vbCrLf & "    AND FLOGIN_ID = :" & UBound(strBindField) - 1 & " --ﾛｸﾞｲﾝID")
        End If
        If IsNull(FUSER_ATEST) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ATEST
            strSQL.Append(vbCrLf & "    AND FUSER_ATEST = :" & UBound(strBindField) - 1 & " --ﾕｰｻﾞｰ認証状況")
        End If
        If IsNull(FWARNING_COUNT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFWARNING_COUNT
            strSQL.Append(vbCrLf & "    AND FWARNING_COUNT = :" & UBound(strBindField) - 1 & " --不正ｱｸｾｽ回数")
        End If
        If IsNull(FLOCK_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOCK_DT
            strSQL.Append(vbCrLf & "    AND FLOCK_DT = :" & UBound(strBindField) - 1 & " --ﾛｯｸ日時")
        End If
        If IsNull(FENTRY_TERM_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_TERM_ID
            strSQL.Append(vbCrLf & "    AND FENTRY_TERM_ID = :" & UBound(strBindField) - 1 & " --登録端末ID")
        End If
        If IsNull(FENTRY_USER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_USER_ID
            strSQL.Append(vbCrLf & "    AND FENTRY_USER_ID = :" & UBound(strBindField) - 1 & " --登録ﾕｰｻﾞｰID")
        End If
        If IsNull(FENTRY_USER_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_USER_NAME
            strSQL.Append(vbCrLf & "    AND FENTRY_USER_NAME = :" & UBound(strBindField) - 1 & " --登録ﾕｰｻﾞｰ名")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --登録日時")
        End If
        If IsNull(FUPDATE_TERM_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_TERM_ID
            strSQL.Append(vbCrLf & "    AND FUPDATE_TERM_ID = :" & UBound(strBindField) - 1 & " --更新端末ID")
        End If
        If IsNull(FUPDATE_USER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_USER_ID
            strSQL.Append(vbCrLf & "    AND FUPDATE_USER_ID = :" & UBound(strBindField) - 1 & " --更新ﾕｰｻﾞｰID")
        End If
        If IsNull(FUPDATE_USER_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_USER_NAME
            strSQL.Append(vbCrLf & "    AND FUPDATE_USER_NAME = :" & UBound(strBindField) - 1 & " --更新ﾕｰｻﾞｰ名")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --更新日時")
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
        strDataSetName = "TMST_USER"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TMST_USER(Owner, objDb, objDbLog)
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
    Public Function GET_TMST_USER_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "TMST_USER"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TMST_USER(Owner, objDb, objDbLog)
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
    Public Function GET_TMST_USER_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    TMST_USER")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FUSER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID
            strSQL.Append(vbCrLf & "    AND FUSER_ID = :" & UBound(strBindField) - 1 & " --ﾕｰｻﾞｰID")
        End If
        If IsNull(FUSER_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME
            strSQL.Append(vbCrLf & "    AND FUSER_NAME = :" & UBound(strBindField) - 1 & " --名前")
        End If
        If IsNull(FPASS_WORD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPASS_WORD
            strSQL.Append(vbCrLf & "    AND FPASS_WORD = :" & UBound(strBindField) - 1 & " --ﾊﾟｽﾜｰﾄﾞ")
        End If
        If IsNull(FPASS_WORDUP_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPASS_WORDUP_DT
            strSQL.Append(vbCrLf & "    AND FPASS_WORDUP_DT = :" & UBound(strBindField) - 1 & " --ﾊﾟｽﾜｰﾄﾞ更新日時")
        End If
        If IsNull(FLOGIN_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOGIN_ID
            strSQL.Append(vbCrLf & "    AND FLOGIN_ID = :" & UBound(strBindField) - 1 & " --ﾛｸﾞｲﾝID")
        End If
        If IsNull(FUSER_ATEST) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ATEST
            strSQL.Append(vbCrLf & "    AND FUSER_ATEST = :" & UBound(strBindField) - 1 & " --ﾕｰｻﾞｰ認証状況")
        End If
        If IsNull(FWARNING_COUNT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFWARNING_COUNT
            strSQL.Append(vbCrLf & "    AND FWARNING_COUNT = :" & UBound(strBindField) - 1 & " --不正ｱｸｾｽ回数")
        End If
        If IsNull(FLOCK_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOCK_DT
            strSQL.Append(vbCrLf & "    AND FLOCK_DT = :" & UBound(strBindField) - 1 & " --ﾛｯｸ日時")
        End If
        If IsNull(FENTRY_TERM_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_TERM_ID
            strSQL.Append(vbCrLf & "    AND FENTRY_TERM_ID = :" & UBound(strBindField) - 1 & " --登録端末ID")
        End If
        If IsNull(FENTRY_USER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_USER_ID
            strSQL.Append(vbCrLf & "    AND FENTRY_USER_ID = :" & UBound(strBindField) - 1 & " --登録ﾕｰｻﾞｰID")
        End If
        If IsNull(FENTRY_USER_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_USER_NAME
            strSQL.Append(vbCrLf & "    AND FENTRY_USER_NAME = :" & UBound(strBindField) - 1 & " --登録ﾕｰｻﾞｰ名")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --登録日時")
        End If
        If IsNull(FUPDATE_TERM_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_TERM_ID
            strSQL.Append(vbCrLf & "    AND FUPDATE_TERM_ID = :" & UBound(strBindField) - 1 & " --更新端末ID")
        End If
        If IsNull(FUPDATE_USER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_USER_ID
            strSQL.Append(vbCrLf & "    AND FUPDATE_USER_ID = :" & UBound(strBindField) - 1 & " --更新ﾕｰｻﾞｰID")
        End If
        If IsNull(FUPDATE_USER_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_USER_NAME
            strSQL.Append(vbCrLf & "    AND FUPDATE_USER_NAME = :" & UBound(strBindField) - 1 & " --更新ﾕｰｻﾞｰ名")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --更新日時")
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
        strDataSetName = "TMST_USER"
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
    Public Sub UPDATE_TMST_USER()
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
        ElseIf IsNull(mFUSER_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾕｰｻﾞｰID]"
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
        strSQL.Append(vbCrLf & "    TMST_USER")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
        If IsNull(mFUSER_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUSER_ID = NULL --ﾕｰｻﾞｰID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUSER_ID = NULL --ﾕｰｻﾞｰID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUSER_ID = :" & Ubound(strBindField) - 1 & " --ﾕｰｻﾞｰID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUSER_ID = :" & Ubound(strBindField) - 1 & " --ﾕｰｻﾞｰID")
        End If
        intCount = intCount + 1
        If IsNull(mFUSER_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUSER_NAME = NULL --名前")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUSER_NAME = NULL --名前")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUSER_NAME = :" & Ubound(strBindField) - 1 & " --名前")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUSER_NAME = :" & Ubound(strBindField) - 1 & " --名前")
        End If
        intCount = intCount + 1
        If IsNull(mFPASS_WORD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FPASS_WORD = NULL --ﾊﾟｽﾜｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FPASS_WORD = NULL --ﾊﾟｽﾜｰﾄﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPASS_WORD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FPASS_WORD = :" & Ubound(strBindField) - 1 & " --ﾊﾟｽﾜｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FPASS_WORD = :" & Ubound(strBindField) - 1 & " --ﾊﾟｽﾜｰﾄﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFPASS_WORDUP_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FPASS_WORDUP_DT = NULL --ﾊﾟｽﾜｰﾄﾞ更新日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FPASS_WORDUP_DT = NULL --ﾊﾟｽﾜｰﾄﾞ更新日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPASS_WORDUP_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FPASS_WORDUP_DT = :" & Ubound(strBindField) - 1 & " --ﾊﾟｽﾜｰﾄﾞ更新日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FPASS_WORDUP_DT = :" & Ubound(strBindField) - 1 & " --ﾊﾟｽﾜｰﾄﾞ更新日時")
        End If
        intCount = intCount + 1
        If IsNull(mFLOGIN_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOGIN_ID = NULL --ﾛｸﾞｲﾝID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOGIN_ID = NULL --ﾛｸﾞｲﾝID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOGIN_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOGIN_ID = :" & Ubound(strBindField) - 1 & " --ﾛｸﾞｲﾝID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOGIN_ID = :" & Ubound(strBindField) - 1 & " --ﾛｸﾞｲﾝID")
        End If
        intCount = intCount + 1
        If IsNull(mFUSER_ATEST) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUSER_ATEST = NULL --ﾕｰｻﾞｰ認証状況")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUSER_ATEST = NULL --ﾕｰｻﾞｰ認証状況")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ATEST
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUSER_ATEST = :" & Ubound(strBindField) - 1 & " --ﾕｰｻﾞｰ認証状況")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUSER_ATEST = :" & Ubound(strBindField) - 1 & " --ﾕｰｻﾞｰ認証状況")
        End If
        intCount = intCount + 1
        If IsNull(mFWARNING_COUNT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FWARNING_COUNT = NULL --不正ｱｸｾｽ回数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FWARNING_COUNT = NULL --不正ｱｸｾｽ回数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFWARNING_COUNT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FWARNING_COUNT = :" & Ubound(strBindField) - 1 & " --不正ｱｸｾｽ回数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FWARNING_COUNT = :" & Ubound(strBindField) - 1 & " --不正ｱｸｾｽ回数")
        End If
        intCount = intCount + 1
        If IsNull(mFLOCK_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOCK_DT = NULL --ﾛｯｸ日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOCK_DT = NULL --ﾛｯｸ日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOCK_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOCK_DT = :" & Ubound(strBindField) - 1 & " --ﾛｯｸ日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOCK_DT = :" & Ubound(strBindField) - 1 & " --ﾛｯｸ日時")
        End If
        intCount = intCount + 1
        If IsNull(mFENTRY_TERM_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FENTRY_TERM_ID = NULL --登録端末ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FENTRY_TERM_ID = NULL --登録端末ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_TERM_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FENTRY_TERM_ID = :" & Ubound(strBindField) - 1 & " --登録端末ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FENTRY_TERM_ID = :" & Ubound(strBindField) - 1 & " --登録端末ID")
        End If
        intCount = intCount + 1
        If IsNull(mFENTRY_USER_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FENTRY_USER_ID = NULL --登録ﾕｰｻﾞｰID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FENTRY_USER_ID = NULL --登録ﾕｰｻﾞｰID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_USER_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FENTRY_USER_ID = :" & Ubound(strBindField) - 1 & " --登録ﾕｰｻﾞｰID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FENTRY_USER_ID = :" & Ubound(strBindField) - 1 & " --登録ﾕｰｻﾞｰID")
        End If
        intCount = intCount + 1
        If IsNull(mFENTRY_USER_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FENTRY_USER_NAME = NULL --登録ﾕｰｻﾞｰ名")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FENTRY_USER_NAME = NULL --登録ﾕｰｻﾞｰ名")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_USER_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FENTRY_USER_NAME = :" & Ubound(strBindField) - 1 & " --登録ﾕｰｻﾞｰ名")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FENTRY_USER_NAME = :" & Ubound(strBindField) - 1 & " --登録ﾕｰｻﾞｰ名")
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
        If IsNull(mFUPDATE_TERM_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUPDATE_TERM_ID = NULL --更新端末ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUPDATE_TERM_ID = NULL --更新端末ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_TERM_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUPDATE_TERM_ID = :" & Ubound(strBindField) - 1 & " --更新端末ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUPDATE_TERM_ID = :" & Ubound(strBindField) - 1 & " --更新端末ID")
        End If
        intCount = intCount + 1
        If IsNull(mFUPDATE_USER_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUPDATE_USER_ID = NULL --更新ﾕｰｻﾞｰID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUPDATE_USER_ID = NULL --更新ﾕｰｻﾞｰID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_USER_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUPDATE_USER_ID = :" & Ubound(strBindField) - 1 & " --更新ﾕｰｻﾞｰID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUPDATE_USER_ID = :" & Ubound(strBindField) - 1 & " --更新ﾕｰｻﾞｰID")
        End If
        intCount = intCount + 1
        If IsNull(mFUPDATE_USER_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUPDATE_USER_NAME = NULL --更新ﾕｰｻﾞｰ名")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUPDATE_USER_NAME = NULL --更新ﾕｰｻﾞｰ名")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_USER_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUPDATE_USER_NAME = :" & Ubound(strBindField) - 1 & " --更新ﾕｰｻﾞｰ名")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUPDATE_USER_NAME = :" & Ubound(strBindField) - 1 & " --更新ﾕｰｻﾞｰ名")
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
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FUSER_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FUSER_ID IS NULL --ﾕｰｻﾞｰID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID
            strSQL.Append(vbCrLf & "    AND FUSER_ID = :" & UBound(strBindField) - 1 & " --ﾕｰｻﾞｰID")
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
    Public Sub ADD_TMST_USER()
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
        ElseIf IsNull(mFUSER_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾕｰｻﾞｰID]"
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
        strSQL.Append(vbCrLf & "    TMST_USER")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
        If IsNull(mFUSER_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾕｰｻﾞｰID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾕｰｻﾞｰID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾕｰｻﾞｰID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾕｰｻﾞｰID")
        End If
        intCount = intCount + 1
        If IsNull(mFUSER_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --名前")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --名前")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --名前")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --名前")
        End If
        intCount = intCount + 1
        If IsNull(mFPASS_WORD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾊﾟｽﾜｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾊﾟｽﾜｰﾄﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPASS_WORD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾊﾟｽﾜｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾊﾟｽﾜｰﾄﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFPASS_WORDUP_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾊﾟｽﾜｰﾄﾞ更新日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾊﾟｽﾜｰﾄﾞ更新日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPASS_WORDUP_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾊﾟｽﾜｰﾄﾞ更新日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾊﾟｽﾜｰﾄﾞ更新日時")
        End If
        intCount = intCount + 1
        If IsNull(mFLOGIN_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾛｸﾞｲﾝID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾛｸﾞｲﾝID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOGIN_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾛｸﾞｲﾝID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾛｸﾞｲﾝID")
        End If
        intCount = intCount + 1
        If IsNull(mFUSER_ATEST) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾕｰｻﾞｰ認証状況")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾕｰｻﾞｰ認証状況")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ATEST
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾕｰｻﾞｰ認証状況")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾕｰｻﾞｰ認証状況")
        End If
        intCount = intCount + 1
        If IsNull(mFWARNING_COUNT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --不正ｱｸｾｽ回数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --不正ｱｸｾｽ回数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFWARNING_COUNT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --不正ｱｸｾｽ回数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --不正ｱｸｾｽ回数")
        End If
        intCount = intCount + 1
        If IsNull(mFLOCK_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾛｯｸ日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾛｯｸ日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOCK_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾛｯｸ日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾛｯｸ日時")
        End If
        intCount = intCount + 1
        If IsNull(mFENTRY_TERM_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --登録端末ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --登録端末ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_TERM_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --登録端末ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --登録端末ID")
        End If
        intCount = intCount + 1
        If IsNull(mFENTRY_USER_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --登録ﾕｰｻﾞｰID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --登録ﾕｰｻﾞｰID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_USER_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --登録ﾕｰｻﾞｰID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --登録ﾕｰｻﾞｰID")
        End If
        intCount = intCount + 1
        If IsNull(mFENTRY_USER_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --登録ﾕｰｻﾞｰ名")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --登録ﾕｰｻﾞｰ名")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_USER_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --登録ﾕｰｻﾞｰ名")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --登録ﾕｰｻﾞｰ名")
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
        If IsNull(mFUPDATE_TERM_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --更新端末ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --更新端末ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_TERM_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --更新端末ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --更新端末ID")
        End If
        intCount = intCount + 1
        If IsNull(mFUPDATE_USER_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --更新ﾕｰｻﾞｰID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --更新ﾕｰｻﾞｰID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_USER_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --更新ﾕｰｻﾞｰID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --更新ﾕｰｻﾞｰID")
        End If
        intCount = intCount + 1
        If IsNull(mFUPDATE_USER_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --更新ﾕｰｻﾞｰ名")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --更新ﾕｰｻﾞｰ名")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_USER_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --更新ﾕｰｻﾞｰ名")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --更新ﾕｰｻﾞｰ名")
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
    Public Sub DELETE_TMST_USER()
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
        ElseIf IsNull(mFUSER_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾕｰｻﾞｰID]"
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
        strSQL.Append(vbCrLf & "    TMST_USER")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FUSER_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FUSER_ID IS NULL --ﾕｰｻﾞｰID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID
            strSQL.Append(vbCrLf & "    AND FUSER_ID = :" & UBound(strBindField) - 1 & " --ﾕｰｻﾞｰID")
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
    Public Sub DELETE_TMST_USER_ANY()
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
        strSQL.Append(vbCrLf & "    TMST_USER")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(FUSER_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID
            strSQL.Append(vbCrLf & "    AND FUSER_ID = :" & UBound(strBindField) - 1 & " --ﾕｰｻﾞｰID")
        End If
        If IsNotNull(FUSER_NAME) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME
            strSQL.Append(vbCrLf & "    AND FUSER_NAME = :" & UBound(strBindField) - 1 & " --名前")
        End If
        If IsNotNull(FPASS_WORD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPASS_WORD
            strSQL.Append(vbCrLf & "    AND FPASS_WORD = :" & UBound(strBindField) - 1 & " --ﾊﾟｽﾜｰﾄﾞ")
        End If
        If IsNotNull(FPASS_WORDUP_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPASS_WORDUP_DT
            strSQL.Append(vbCrLf & "    AND FPASS_WORDUP_DT = :" & UBound(strBindField) - 1 & " --ﾊﾟｽﾜｰﾄﾞ更新日時")
        End If
        If IsNotNull(FLOGIN_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOGIN_ID
            strSQL.Append(vbCrLf & "    AND FLOGIN_ID = :" & UBound(strBindField) - 1 & " --ﾛｸﾞｲﾝID")
        End If
        If IsNotNull(FUSER_ATEST) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ATEST
            strSQL.Append(vbCrLf & "    AND FUSER_ATEST = :" & UBound(strBindField) - 1 & " --ﾕｰｻﾞｰ認証状況")
        End If
        If IsNotNull(FWARNING_COUNT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFWARNING_COUNT
            strSQL.Append(vbCrLf & "    AND FWARNING_COUNT = :" & UBound(strBindField) - 1 & " --不正ｱｸｾｽ回数")
        End If
        If IsNotNull(FLOCK_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOCK_DT
            strSQL.Append(vbCrLf & "    AND FLOCK_DT = :" & UBound(strBindField) - 1 & " --ﾛｯｸ日時")
        End If
        If IsNotNull(FENTRY_TERM_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_TERM_ID
            strSQL.Append(vbCrLf & "    AND FENTRY_TERM_ID = :" & UBound(strBindField) - 1 & " --登録端末ID")
        End If
        If IsNotNull(FENTRY_USER_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_USER_ID
            strSQL.Append(vbCrLf & "    AND FENTRY_USER_ID = :" & UBound(strBindField) - 1 & " --登録ﾕｰｻﾞｰID")
        End If
        If IsNotNull(FENTRY_USER_NAME) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_USER_NAME
            strSQL.Append(vbCrLf & "    AND FENTRY_USER_NAME = :" & UBound(strBindField) - 1 & " --登録ﾕｰｻﾞｰ名")
        End If
        If IsNotNull(FENTRY_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --登録日時")
        End If
        If IsNotNull(FUPDATE_TERM_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_TERM_ID
            strSQL.Append(vbCrLf & "    AND FUPDATE_TERM_ID = :" & UBound(strBindField) - 1 & " --更新端末ID")
        End If
        If IsNotNull(FUPDATE_USER_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_USER_ID
            strSQL.Append(vbCrLf & "    AND FUPDATE_USER_ID = :" & UBound(strBindField) - 1 & " --更新ﾕｰｻﾞｰID")
        End If
        If IsNotNull(FUPDATE_USER_NAME) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_USER_NAME
            strSQL.Append(vbCrLf & "    AND FUPDATE_USER_NAME = :" & UBound(strBindField) - 1 & " --更新ﾕｰｻﾞｰ名")
        End If
        If IsNotNull(FUPDATE_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --更新日時")
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
        If IsNothing(objType.GetProperty("FUSER_ID")) = False Then mFUSER_ID = objObject.FUSER_ID 'ﾕｰｻﾞｰID
        If IsNothing(objType.GetProperty("FUSER_NAME")) = False Then mFUSER_NAME = objObject.FUSER_NAME '名前
        If IsNothing(objType.GetProperty("FPASS_WORD")) = False Then mFPASS_WORD = objObject.FPASS_WORD 'ﾊﾟｽﾜｰﾄﾞ
        If IsNothing(objType.GetProperty("FPASS_WORDUP_DT")) = False Then mFPASS_WORDUP_DT = objObject.FPASS_WORDUP_DT 'ﾊﾟｽﾜｰﾄﾞ更新日時
        If IsNothing(objType.GetProperty("FLOGIN_ID")) = False Then mFLOGIN_ID = objObject.FLOGIN_ID 'ﾛｸﾞｲﾝID
        If IsNothing(objType.GetProperty("FUSER_ATEST")) = False Then mFUSER_ATEST = objObject.FUSER_ATEST 'ﾕｰｻﾞｰ認証状況
        If IsNothing(objType.GetProperty("FWARNING_COUNT")) = False Then mFWARNING_COUNT = objObject.FWARNING_COUNT '不正ｱｸｾｽ回数
        If IsNothing(objType.GetProperty("FLOCK_DT")) = False Then mFLOCK_DT = objObject.FLOCK_DT 'ﾛｯｸ日時
        If IsNothing(objType.GetProperty("FENTRY_TERM_ID")) = False Then mFENTRY_TERM_ID = objObject.FENTRY_TERM_ID '登録端末ID
        If IsNothing(objType.GetProperty("FENTRY_USER_ID")) = False Then mFENTRY_USER_ID = objObject.FENTRY_USER_ID '登録ﾕｰｻﾞｰID
        If IsNothing(objType.GetProperty("FENTRY_USER_NAME")) = False Then mFENTRY_USER_NAME = objObject.FENTRY_USER_NAME '登録ﾕｰｻﾞｰ名
        If IsNothing(objType.GetProperty("FENTRY_DT")) = False Then mFENTRY_DT = objObject.FENTRY_DT '登録日時
        If IsNothing(objType.GetProperty("FUPDATE_TERM_ID")) = False Then mFUPDATE_TERM_ID = objObject.FUPDATE_TERM_ID '更新端末ID
        If IsNothing(objType.GetProperty("FUPDATE_USER_ID")) = False Then mFUPDATE_USER_ID = objObject.FUPDATE_USER_ID '更新ﾕｰｻﾞｰID
        If IsNothing(objType.GetProperty("FUPDATE_USER_NAME")) = False Then mFUPDATE_USER_NAME = objObject.FUPDATE_USER_NAME '更新ﾕｰｻﾞｰ名
        If IsNothing(objType.GetProperty("FUPDATE_DT")) = False Then mFUPDATE_DT = objObject.FUPDATE_DT '更新日時

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
        mFUSER_ID = Nothing
        mFUSER_NAME = Nothing
        mFPASS_WORD = Nothing
        mFPASS_WORDUP_DT = Nothing
        mFLOGIN_ID = Nothing
        mFUSER_ATEST = Nothing
        mFWARNING_COUNT = Nothing
        mFLOCK_DT = Nothing
        mFENTRY_TERM_ID = Nothing
        mFENTRY_USER_ID = Nothing
        mFENTRY_USER_NAME = Nothing
        mFENTRY_DT = Nothing
        mFUPDATE_TERM_ID = Nothing
        mFUPDATE_USER_ID = Nothing
        mFUPDATE_USER_NAME = Nothing
        mFUPDATE_DT = Nothing


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
        mFUSER_ID = TO_STRING_NULLABLE(objRow("FUSER_ID"))
        mFUSER_NAME = TO_STRING_NULLABLE(objRow("FUSER_NAME"))
        mFPASS_WORD = TO_STRING_NULLABLE(objRow("FPASS_WORD"))
        mFPASS_WORDUP_DT = TO_DATE_NULLABLE(objRow("FPASS_WORDUP_DT"))
        mFLOGIN_ID = TO_STRING_NULLABLE(objRow("FLOGIN_ID"))
        mFUSER_ATEST = TO_INTEGER_NULLABLE(objRow("FUSER_ATEST"))
        mFWARNING_COUNT = TO_INTEGER_NULLABLE(objRow("FWARNING_COUNT"))
        mFLOCK_DT = TO_DATE_NULLABLE(objRow("FLOCK_DT"))
        mFENTRY_TERM_ID = TO_STRING_NULLABLE(objRow("FENTRY_TERM_ID"))
        mFENTRY_USER_ID = TO_STRING_NULLABLE(objRow("FENTRY_USER_ID"))
        mFENTRY_USER_NAME = TO_STRING_NULLABLE(objRow("FENTRY_USER_NAME"))
        mFENTRY_DT = TO_DATE_NULLABLE(objRow("FENTRY_DT"))
        mFUPDATE_TERM_ID = TO_STRING_NULLABLE(objRow("FUPDATE_TERM_ID"))
        mFUPDATE_USER_ID = TO_STRING_NULLABLE(objRow("FUPDATE_USER_ID"))
        mFUPDATE_USER_NAME = TO_STRING_NULLABLE(objRow("FUPDATE_USER_NAME"))
        mFUPDATE_DT = TO_DATE_NULLABLE(objRow("FUPDATE_DT"))


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
        strMsg &= "[ﾃｰﾌﾞﾙ名:ﾕｰｻﾞｰﾏｽﾀ]"
        If IsNotNull(FUSER_ID) Then
            strMsg &= "[ﾕｰｻﾞｰID:" & FUSER_ID & "]"
        End If
        If IsNotNull(FUSER_NAME) Then
            strMsg &= "[名前:" & FUSER_NAME & "]"
        End If
        If IsNotNull(FPASS_WORD) Then
            strMsg &= "[ﾊﾟｽﾜｰﾄﾞ:" & FPASS_WORD & "]"
        End If
        If IsNotNull(FPASS_WORDUP_DT) Then
            strMsg &= "[ﾊﾟｽﾜｰﾄﾞ更新日時:" & FPASS_WORDUP_DT & "]"
        End If
        If IsNotNull(FLOGIN_ID) Then
            strMsg &= "[ﾛｸﾞｲﾝID:" & FLOGIN_ID & "]"
        End If
        If IsNotNull(FUSER_ATEST) Then
            strMsg &= "[ﾕｰｻﾞｰ認証状況:" & FUSER_ATEST & "]"
        End If
        If IsNotNull(FWARNING_COUNT) Then
            strMsg &= "[不正ｱｸｾｽ回数:" & FWARNING_COUNT & "]"
        End If
        If IsNotNull(FLOCK_DT) Then
            strMsg &= "[ﾛｯｸ日時:" & FLOCK_DT & "]"
        End If
        If IsNotNull(FENTRY_TERM_ID) Then
            strMsg &= "[登録端末ID:" & FENTRY_TERM_ID & "]"
        End If
        If IsNotNull(FENTRY_USER_ID) Then
            strMsg &= "[登録ﾕｰｻﾞｰID:" & FENTRY_USER_ID & "]"
        End If
        If IsNotNull(FENTRY_USER_NAME) Then
            strMsg &= "[登録ﾕｰｻﾞｰ名:" & FENTRY_USER_NAME & "]"
        End If
        If IsNotNull(FENTRY_DT) Then
            strMsg &= "[登録日時:" & FENTRY_DT & "]"
        End If
        If IsNotNull(FUPDATE_TERM_ID) Then
            strMsg &= "[更新端末ID:" & FUPDATE_TERM_ID & "]"
        End If
        If IsNotNull(FUPDATE_USER_ID) Then
            strMsg &= "[更新ﾕｰｻﾞｰID:" & FUPDATE_USER_ID & "]"
        End If
        If IsNotNull(FUPDATE_USER_NAME) Then
            strMsg &= "[更新ﾕｰｻﾞｰ名:" & FUPDATE_USER_NAME & "]"
        End If
        If IsNotNull(FUPDATE_DT) Then
            strMsg &= "[更新日時:" & FUPDATE_DT & "]"
        End If


    End Sub
#End Region
    '↑↑↑自動生成部
    '**********************************************************************************************



    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ共通
#Region "  ﾃﾞｰﾀ取得(ｷｰ:ﾛｸﾞｲﾝID)                         "
    Public Function GET_TMST_USER_FLOGIN_ID() As RetCode
        Try
            Dim strSQL As New StringBuilder     'SQL文
            Dim strMsg As String                'ﾒｯｾｰｼﾞ
            Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
            Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
            Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
            Dim objParameter(1, 0) As Object
            Dim strBindField(0) As String
            Dim objBindValue(0) As Object

            '***********************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '***********************
            If 1 <> 1 Then
            ElseIf IsNull(mFLOGIN_ID) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[ﾛｸﾞｲﾝID]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '抽出SQL作成
            '***********************
            strBindField = Nothing
            objBindValue = Nothing
            ReDim Preserve strBindField(0)
            ReDim Preserve objBindValue(0)
            strSQL.Append(vbCrLf & "SELECT")
            strSQL.Append(vbCrLf & "    *")
            strSQL.Append(vbCrLf & " FROM")
            strSQL.Append(vbCrLf & "    TMST_USER")
            strSQL.Append(vbCrLf & " WHERE")
            strSQL.Append(vbCrLf & "        1 = 1")
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOGIN_ID
            strSQL.Append(vbCrLf & "    AND FLOGIN_ID = :" & UBound(strBindField) - 1 & " --ﾛｸﾞｲﾝID")


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
            strDataSetName = "TMST_USER"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count = 1 Then
                objRow = objDataSet.Tables(strDataSetName).Rows(0)
                Call SET_DATA(objRow)
                Return (RetCode.OK)
            ElseIf objDataSet.Tables(strDataSetName).Rows.Count = 0 Then
                Return (RetCode.NotFound)
            ElseIf objDataSet.Tables(strDataSetName).Rows.Count > 1 Then
                Throw New Exception("ﾛｸﾞｲﾝIDが重複しています。")
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
#Region "  ﾃﾞｰﾀ取得(ｷｰ:ﾕｰｻﾞｰID、ﾛｸﾞｲﾝID)(ﾁｪｯｸ用)        "
    Public Function GET_TMST_USER_FLOGIN_ID_CHECK() As RetCode
        Try
            Dim strSQL As New StringBuilder     'SQL文
            Dim strMsg As String                'ﾒｯｾｰｼﾞ
            Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
            Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
            Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
            Dim objParameter(1, 0) As Object
            Dim strBindField(0) As String
            Dim objBindValue(0) As Object

            '***********************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '***********************
            If 1 <> 1 Then
            ElseIf IsNull(mFUSER_ID) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[ﾕｰｻﾞｰID]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFLOGIN_ID) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[ﾛｸﾞｲﾝID]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '抽出SQL作成
            '***********************
            strBindField = Nothing
            objBindValue = Nothing
            ReDim Preserve strBindField(0)
            ReDim Preserve objBindValue(0)
            strSQL.Append(vbCrLf & "SELECT")
            strSQL.Append(vbCrLf & "    *")
            strSQL.Append(vbCrLf & " FROM")
            strSQL.Append(vbCrLf & "    TMST_USER")
            strSQL.Append(vbCrLf & " WHERE")
            strSQL.Append(vbCrLf & "        1 = 1")
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID
            strSQL.Append(vbCrLf & "    AND FUSER_ID <> :" & UBound(strBindField) - 1 & " --ﾕｰｻﾞｰID")
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOGIN_ID
            strSQL.Append(vbCrLf & "    AND FLOGIN_ID = :" & UBound(strBindField) - 1 & " --ﾛｸﾞｲﾝID")


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
            strDataSetName = "TMST_USER"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count = 1 Then
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
    '↑↑↑ｼｽﾃﾑ共通
    '**********************************************************************************************


    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
