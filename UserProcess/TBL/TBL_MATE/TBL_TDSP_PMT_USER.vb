'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' 【名称】MaterialStreamﾃｰﾌﾞﾙｸﾗｽ
' 【機能】ﾕｰｻﾞｰ別許可ﾏｽﾀﾃｰﾌﾞﾙｸﾗｽ
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
''' ﾕｰｻﾞ別許可ﾏｽﾀﾃｰﾌﾞﾙｸﾗｽ
''' </summary>
Public Class TBL_TDSP_PMT_USER
    Inherits clsTemplateTable

    '**********************************************************************************************
    '↓↓↓自動生成部
#Region "  ｸﾗｽ変数定義                  "
    'ﾌﾟﾛﾊﾟﾃｨ
    Private mobjAryMe As TBL_TDSP_PMT_USER()                                     'ﾕｰｻﾞｰ別許可ﾏｽﾀ
    Private mstrUSER_SQL As String                                               'ﾕｰｻﾞｰSQL
    Private mORDER_BY As String                                                  'OrderBy句
    Private mWHERE As String                                                     'Where句
    Private mFUSER_DSP_LEVEL As Nullable(Of Integer)                             'ﾕｰｻﾞｰ操作ﾚﾍﾞﾙ
    Private mFDISP_ID As String                                                  '画面ID
    Private mFCTRL_ID As String                                                  'ｺﾝﾄﾛｰﾙID
    Private mFOPE_FLAG As Nullable(Of Integer)                                   '操作ﾌﾗｸﾞ
    Private mFENTRY_DT As Nullable(Of Date)                                      '登録日時
    Private mFENTRY_USER_ID As String                                            '登録ﾕｰｻﾞｰID
    Private mFENTRY_TERM_ID As String                                            '登録端末ID
    Private mFUPDATE_DT As Nullable(Of Date)                                     '更新日時
    Private mFUPDATE_USER_ID As String                                           '更新ﾕｰｻﾞｰID
    Private mFUPDATE_TERM_ID As String                                           '更新端末ID
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                  "
    ''' <summary>
    ''' ｼｽﾃﾑ変数 (自ｸﾗｽ型配列)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_TDSP_PMT_USER()
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
    ''' ﾕｰｻﾞｰ操作ﾚﾍﾞﾙ
    ''' </summary>
    Public Property FUSER_DSP_LEVEL() As Nullable(Of Integer)
        Get
            Return mFUSER_DSP_LEVEL
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFUSER_DSP_LEVEL = Value
        End Set
    End Property
    ''' <summary>
    ''' 画面ID
    ''' </summary>
    Public Property FDISP_ID() As String
        Get
            Return mFDISP_ID
        End Get
        Set(ByVal Value As String)
            mFDISP_ID = Value
        End Set
    End Property
    ''' <summary>
    ''' ｺﾝﾄﾛｰﾙID
    ''' </summary>
    Public Property FCTRL_ID() As String
        Get
            Return mFCTRL_ID
        End Get
        Set(ByVal Value As String)
            mFCTRL_ID = Value
        End Set
    End Property
    ''' <summary>
    ''' 操作ﾌﾗｸﾞ
    ''' </summary>
    Public Property FOPE_FLAG() As Nullable(Of Integer)
        Get
            Return mFOPE_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFOPE_FLAG = Value
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
    Public Function GET_TDSP_PMT_USER(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    TDSP_PMT_USER")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FUSER_DSP_LEVEL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_DSP_LEVEL
            strSQL.Append(vbCrLf & "    AND FUSER_DSP_LEVEL = :" & UBound(strBindField) - 1 & " --ﾕｰｻﾞｰ操作ﾚﾍﾞﾙ")
        End If
        If IsNull(FDISP_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ID
            strSQL.Append(vbCrLf & "    AND FDISP_ID = :" & UBound(strBindField) - 1 & " --画面ID")
        End If
        If IsNull(FCTRL_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCTRL_ID
            strSQL.Append(vbCrLf & "    AND FCTRL_ID = :" & UBound(strBindField) - 1 & " --ｺﾝﾄﾛｰﾙID")
        End If
        If IsNull(FOPE_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFOPE_FLAG
            strSQL.Append(vbCrLf & "    AND FOPE_FLAG = :" & UBound(strBindField) - 1 & " --操作ﾌﾗｸﾞ")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --登録日時")
        End If
        If IsNull(FENTRY_USER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_USER_ID
            strSQL.Append(vbCrLf & "    AND FENTRY_USER_ID = :" & UBound(strBindField) - 1 & " --登録ﾕｰｻﾞｰID")
        End If
        If IsNull(FENTRY_TERM_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_TERM_ID
            strSQL.Append(vbCrLf & "    AND FENTRY_TERM_ID = :" & UBound(strBindField) - 1 & " --登録端末ID")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --更新日時")
        End If
        If IsNull(FUPDATE_USER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_USER_ID
            strSQL.Append(vbCrLf & "    AND FUPDATE_USER_ID = :" & UBound(strBindField) - 1 & " --更新ﾕｰｻﾞｰID")
        End If
        If IsNull(FUPDATE_TERM_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_TERM_ID
            strSQL.Append(vbCrLf & "    AND FUPDATE_TERM_ID = :" & UBound(strBindField) - 1 & " --更新端末ID")
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
        strDataSetName = "TDSP_PMT_USER"
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
    Public Function GET_TDSP_PMT_USER_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    TDSP_PMT_USER")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FUSER_DSP_LEVEL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_DSP_LEVEL
            strSQL.Append(vbCrLf & "    AND FUSER_DSP_LEVEL = :" & UBound(strBindField) - 1 & " --ﾕｰｻﾞｰ操作ﾚﾍﾞﾙ")
        End If
        If IsNull(FDISP_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ID
            strSQL.Append(vbCrLf & "    AND FDISP_ID = :" & UBound(strBindField) - 1 & " --画面ID")
        End If
        If IsNull(FCTRL_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCTRL_ID
            strSQL.Append(vbCrLf & "    AND FCTRL_ID = :" & UBound(strBindField) - 1 & " --ｺﾝﾄﾛｰﾙID")
        End If
        If IsNull(FOPE_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFOPE_FLAG
            strSQL.Append(vbCrLf & "    AND FOPE_FLAG = :" & UBound(strBindField) - 1 & " --操作ﾌﾗｸﾞ")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --登録日時")
        End If
        If IsNull(FENTRY_USER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_USER_ID
            strSQL.Append(vbCrLf & "    AND FENTRY_USER_ID = :" & UBound(strBindField) - 1 & " --登録ﾕｰｻﾞｰID")
        End If
        If IsNull(FENTRY_TERM_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_TERM_ID
            strSQL.Append(vbCrLf & "    AND FENTRY_TERM_ID = :" & UBound(strBindField) - 1 & " --登録端末ID")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --更新日時")
        End If
        If IsNull(FUPDATE_USER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_USER_ID
            strSQL.Append(vbCrLf & "    AND FUPDATE_USER_ID = :" & UBound(strBindField) - 1 & " --更新ﾕｰｻﾞｰID")
        End If
        If IsNull(FUPDATE_TERM_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_TERM_ID
            strSQL.Append(vbCrLf & "    AND FUPDATE_TERM_ID = :" & UBound(strBindField) - 1 & " --更新端末ID")
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
        strDataSetName = "TDSP_PMT_USER"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TDSP_PMT_USER(Owner, objDb, objDbLog)
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
    Public Function GET_TDSP_PMT_USER_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "TDSP_PMT_USER"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TDSP_PMT_USER(Owner, objDb, objDbLog)
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
    Public Function GET_TDSP_PMT_USER_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    TDSP_PMT_USER")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FUSER_DSP_LEVEL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_DSP_LEVEL
            strSQL.Append(vbCrLf & "    AND FUSER_DSP_LEVEL = :" & UBound(strBindField) - 1 & " --ﾕｰｻﾞｰ操作ﾚﾍﾞﾙ")
        End If
        If IsNull(FDISP_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ID
            strSQL.Append(vbCrLf & "    AND FDISP_ID = :" & UBound(strBindField) - 1 & " --画面ID")
        End If
        If IsNull(FCTRL_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCTRL_ID
            strSQL.Append(vbCrLf & "    AND FCTRL_ID = :" & UBound(strBindField) - 1 & " --ｺﾝﾄﾛｰﾙID")
        End If
        If IsNull(FOPE_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFOPE_FLAG
            strSQL.Append(vbCrLf & "    AND FOPE_FLAG = :" & UBound(strBindField) - 1 & " --操作ﾌﾗｸﾞ")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --登録日時")
        End If
        If IsNull(FENTRY_USER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_USER_ID
            strSQL.Append(vbCrLf & "    AND FENTRY_USER_ID = :" & UBound(strBindField) - 1 & " --登録ﾕｰｻﾞｰID")
        End If
        If IsNull(FENTRY_TERM_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_TERM_ID
            strSQL.Append(vbCrLf & "    AND FENTRY_TERM_ID = :" & UBound(strBindField) - 1 & " --登録端末ID")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --更新日時")
        End If
        If IsNull(FUPDATE_USER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_USER_ID
            strSQL.Append(vbCrLf & "    AND FUPDATE_USER_ID = :" & UBound(strBindField) - 1 & " --更新ﾕｰｻﾞｰID")
        End If
        If IsNull(FUPDATE_TERM_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_TERM_ID
            strSQL.Append(vbCrLf & "    AND FUPDATE_TERM_ID = :" & UBound(strBindField) - 1 & " --更新端末ID")
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
        strDataSetName = "TDSP_PMT_USER"
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
    Public Sub UPDATE_TDSP_PMT_USER()
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
        ElseIf IsNull(mFUSER_DSP_LEVEL) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾕｰｻﾞｰ操作ﾚﾍﾞﾙ]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFDISP_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[画面ID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFCTRL_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ｺﾝﾄﾛｰﾙID]"
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
        strSQL.Append(vbCrLf & "    TDSP_PMT_USER")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
        If IsNull(mFUSER_DSP_LEVEL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUSER_DSP_LEVEL = NULL --ﾕｰｻﾞｰ操作ﾚﾍﾞﾙ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUSER_DSP_LEVEL = NULL --ﾕｰｻﾞｰ操作ﾚﾍﾞﾙ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_DSP_LEVEL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUSER_DSP_LEVEL = :" & Ubound(strBindField) - 1 & " --ﾕｰｻﾞｰ操作ﾚﾍﾞﾙ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUSER_DSP_LEVEL = :" & Ubound(strBindField) - 1 & " --ﾕｰｻﾞｰ操作ﾚﾍﾞﾙ")
        End If
        intCount = intCount + 1
        If IsNull(mFDISP_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDISP_ID = NULL --画面ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDISP_ID = NULL --画面ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDISP_ID = :" & Ubound(strBindField) - 1 & " --画面ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDISP_ID = :" & Ubound(strBindField) - 1 & " --画面ID")
        End If
        intCount = intCount + 1
        If IsNull(mFCTRL_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCTRL_ID = NULL --ｺﾝﾄﾛｰﾙID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCTRL_ID = NULL --ｺﾝﾄﾛｰﾙID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCTRL_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCTRL_ID = :" & Ubound(strBindField) - 1 & " --ｺﾝﾄﾛｰﾙID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCTRL_ID = :" & Ubound(strBindField) - 1 & " --ｺﾝﾄﾛｰﾙID")
        End If
        intCount = intCount + 1
        If IsNull(mFOPE_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FOPE_FLAG = NULL --操作ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FOPE_FLAG = NULL --操作ﾌﾗｸﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFOPE_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FOPE_FLAG = :" & Ubound(strBindField) - 1 & " --操作ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FOPE_FLAG = :" & Ubound(strBindField) - 1 & " --操作ﾌﾗｸﾞ")
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
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FUSER_DSP_LEVEL) = True Then
            strSQL.Append(vbCrLf & "    AND FUSER_DSP_LEVEL IS NULL --ﾕｰｻﾞｰ操作ﾚﾍﾞﾙ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_DSP_LEVEL
            strSQL.Append(vbCrLf & "    AND FUSER_DSP_LEVEL = :" & UBound(strBindField) - 1 & " --ﾕｰｻﾞｰ操作ﾚﾍﾞﾙ")
        End If
        If IsNull(FDISP_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FDISP_ID IS NULL --画面ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ID
            strSQL.Append(vbCrLf & "    AND FDISP_ID = :" & UBound(strBindField) - 1 & " --画面ID")
        End If
        If IsNull(FCTRL_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FCTRL_ID IS NULL --ｺﾝﾄﾛｰﾙID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCTRL_ID
            strSQL.Append(vbCrLf & "    AND FCTRL_ID = :" & UBound(strBindField) - 1 & " --ｺﾝﾄﾛｰﾙID")
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
    Public Sub ADD_TDSP_PMT_USER()
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
        ElseIf IsNull(mFUSER_DSP_LEVEL) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾕｰｻﾞｰ操作ﾚﾍﾞﾙ]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFDISP_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[画面ID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFCTRL_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ｺﾝﾄﾛｰﾙID]"
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
        strSQL.Append(vbCrLf & "    TDSP_PMT_USER")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
        If IsNull(mFUSER_DSP_LEVEL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾕｰｻﾞｰ操作ﾚﾍﾞﾙ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾕｰｻﾞｰ操作ﾚﾍﾞﾙ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_DSP_LEVEL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾕｰｻﾞｰ操作ﾚﾍﾞﾙ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾕｰｻﾞｰ操作ﾚﾍﾞﾙ")
        End If
        intCount = intCount + 1
        If IsNull(mFDISP_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --画面ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --画面ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --画面ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --画面ID")
        End If
        intCount = intCount + 1
        If IsNull(mFCTRL_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｺﾝﾄﾛｰﾙID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｺﾝﾄﾛｰﾙID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCTRL_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｺﾝﾄﾛｰﾙID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｺﾝﾄﾛｰﾙID")
        End If
        intCount = intCount + 1
        If IsNull(mFOPE_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --操作ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --操作ﾌﾗｸﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFOPE_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --操作ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --操作ﾌﾗｸﾞ")
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
    Public Sub DELETE_TDSP_PMT_USER()
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
        ElseIf IsNull(mFUSER_DSP_LEVEL) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾕｰｻﾞｰ操作ﾚﾍﾞﾙ]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFDISP_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[画面ID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFCTRL_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ｺﾝﾄﾛｰﾙID]"
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
        strSQL.Append(vbCrLf & "    TDSP_PMT_USER")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FUSER_DSP_LEVEL) = True Then
            strSQL.Append(vbCrLf & "    AND FUSER_DSP_LEVEL IS NULL --ﾕｰｻﾞｰ操作ﾚﾍﾞﾙ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_DSP_LEVEL
            strSQL.Append(vbCrLf & "    AND FUSER_DSP_LEVEL = :" & UBound(strBindField) - 1 & " --ﾕｰｻﾞｰ操作ﾚﾍﾞﾙ")
        End If
        If IsNull(FDISP_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FDISP_ID IS NULL --画面ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ID
            strSQL.Append(vbCrLf & "    AND FDISP_ID = :" & UBound(strBindField) - 1 & " --画面ID")
        End If
        If IsNull(FCTRL_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FCTRL_ID IS NULL --ｺﾝﾄﾛｰﾙID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCTRL_ID
            strSQL.Append(vbCrLf & "    AND FCTRL_ID = :" & UBound(strBindField) - 1 & " --ｺﾝﾄﾛｰﾙID")
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
    Public Sub DELETE_TDSP_PMT_USER_ANY()
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
        strSQL.Append(vbCrLf & "    TDSP_PMT_USER")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(FUSER_DSP_LEVEL) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_DSP_LEVEL
            strSQL.Append(vbCrLf & "    AND FUSER_DSP_LEVEL = :" & UBound(strBindField) - 1 & " --ﾕｰｻﾞｰ操作ﾚﾍﾞﾙ")
        End If
        If IsNotNull(FDISP_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ID
            strSQL.Append(vbCrLf & "    AND FDISP_ID = :" & UBound(strBindField) - 1 & " --画面ID")
        End If
        If IsNotNull(FCTRL_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCTRL_ID
            strSQL.Append(vbCrLf & "    AND FCTRL_ID = :" & UBound(strBindField) - 1 & " --ｺﾝﾄﾛｰﾙID")
        End If
        If IsNotNull(FOPE_FLAG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFOPE_FLAG
            strSQL.Append(vbCrLf & "    AND FOPE_FLAG = :" & UBound(strBindField) - 1 & " --操作ﾌﾗｸﾞ")
        End If
        If IsNotNull(FENTRY_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --登録日時")
        End If
        If IsNotNull(FENTRY_USER_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_USER_ID
            strSQL.Append(vbCrLf & "    AND FENTRY_USER_ID = :" & UBound(strBindField) - 1 & " --登録ﾕｰｻﾞｰID")
        End If
        If IsNotNull(FENTRY_TERM_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_TERM_ID
            strSQL.Append(vbCrLf & "    AND FENTRY_TERM_ID = :" & UBound(strBindField) - 1 & " --登録端末ID")
        End If
        If IsNotNull(FUPDATE_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --更新日時")
        End If
        If IsNotNull(FUPDATE_USER_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_USER_ID
            strSQL.Append(vbCrLf & "    AND FUPDATE_USER_ID = :" & UBound(strBindField) - 1 & " --更新ﾕｰｻﾞｰID")
        End If
        If IsNotNull(FUPDATE_TERM_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_TERM_ID
            strSQL.Append(vbCrLf & "    AND FUPDATE_TERM_ID = :" & UBound(strBindField) - 1 & " --更新端末ID")
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
        If IsNothing(objType.GetProperty("FUSER_DSP_LEVEL")) = False Then mFUSER_DSP_LEVEL = objObject.FUSER_DSP_LEVEL 'ﾕｰｻﾞｰ操作ﾚﾍﾞﾙ
        If IsNothing(objType.GetProperty("FDISP_ID")) = False Then mFDISP_ID = objObject.FDISP_ID '画面ID
        If IsNothing(objType.GetProperty("FCTRL_ID")) = False Then mFCTRL_ID = objObject.FCTRL_ID 'ｺﾝﾄﾛｰﾙID
        If IsNothing(objType.GetProperty("FOPE_FLAG")) = False Then mFOPE_FLAG = objObject.FOPE_FLAG '操作ﾌﾗｸﾞ
        If IsNothing(objType.GetProperty("FENTRY_DT")) = False Then mFENTRY_DT = objObject.FENTRY_DT '登録日時
        If IsNothing(objType.GetProperty("FENTRY_USER_ID")) = False Then mFENTRY_USER_ID = objObject.FENTRY_USER_ID '登録ﾕｰｻﾞｰID
        If IsNothing(objType.GetProperty("FENTRY_TERM_ID")) = False Then mFENTRY_TERM_ID = objObject.FENTRY_TERM_ID '登録端末ID
        If IsNothing(objType.GetProperty("FUPDATE_DT")) = False Then mFUPDATE_DT = objObject.FUPDATE_DT '更新日時
        If IsNothing(objType.GetProperty("FUPDATE_USER_ID")) = False Then mFUPDATE_USER_ID = objObject.FUPDATE_USER_ID '更新ﾕｰｻﾞｰID
        If IsNothing(objType.GetProperty("FUPDATE_TERM_ID")) = False Then mFUPDATE_TERM_ID = objObject.FUPDATE_TERM_ID '更新端末ID

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
        mFUSER_DSP_LEVEL = Nothing
        mFDISP_ID = Nothing
        mFCTRL_ID = Nothing
        mFOPE_FLAG = Nothing
        mFENTRY_DT = Nothing
        mFENTRY_USER_ID = Nothing
        mFENTRY_TERM_ID = Nothing
        mFUPDATE_DT = Nothing
        mFUPDATE_USER_ID = Nothing
        mFUPDATE_TERM_ID = Nothing


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
        mFUSER_DSP_LEVEL = TO_INTEGER_NULLABLE(objRow("FUSER_DSP_LEVEL"))
        mFDISP_ID = TO_STRING_NULLABLE(objRow("FDISP_ID"))
        mFCTRL_ID = TO_STRING_NULLABLE(objRow("FCTRL_ID"))
        mFOPE_FLAG = TO_INTEGER_NULLABLE(objRow("FOPE_FLAG"))
        mFENTRY_DT = TO_DATE_NULLABLE(objRow("FENTRY_DT"))
        mFENTRY_USER_ID = TO_STRING_NULLABLE(objRow("FENTRY_USER_ID"))
        mFENTRY_TERM_ID = TO_STRING_NULLABLE(objRow("FENTRY_TERM_ID"))
        mFUPDATE_DT = TO_DATE_NULLABLE(objRow("FUPDATE_DT"))
        mFUPDATE_USER_ID = TO_STRING_NULLABLE(objRow("FUPDATE_USER_ID"))
        mFUPDATE_TERM_ID = TO_STRING_NULLABLE(objRow("FUPDATE_TERM_ID"))


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
        strMsg &= "[ﾃｰﾌﾞﾙ名:ﾕｰｻﾞｰ別許可ﾏｽﾀ]"
        If IsNotNull(FUSER_DSP_LEVEL) Then
            strMsg &= "[ﾕｰｻﾞｰ操作ﾚﾍﾞﾙ:" & FUSER_DSP_LEVEL & "]"
        End If
        If IsNotNull(FDISP_ID) Then
            strMsg &= "[画面ID:" & FDISP_ID & "]"
        End If
        If IsNotNull(FCTRL_ID) Then
            strMsg &= "[ｺﾝﾄﾛｰﾙID:" & FCTRL_ID & "]"
        End If
        If IsNotNull(FOPE_FLAG) Then
            strMsg &= "[操作ﾌﾗｸﾞ:" & FOPE_FLAG & "]"
        End If
        If IsNotNull(FENTRY_DT) Then
            strMsg &= "[登録日時:" & FENTRY_DT & "]"
        End If
        If IsNotNull(FENTRY_USER_ID) Then
            strMsg &= "[登録ﾕｰｻﾞｰID:" & FENTRY_USER_ID & "]"
        End If
        If IsNotNull(FENTRY_TERM_ID) Then
            strMsg &= "[登録端末ID:" & FENTRY_TERM_ID & "]"
        End If
        If IsNotNull(FUPDATE_DT) Then
            strMsg &= "[更新日時:" & FUPDATE_DT & "]"
        End If
        If IsNotNull(FUPDATE_USER_ID) Then
            strMsg &= "[更新ﾕｰｻﾞｰID:" & FUPDATE_USER_ID & "]"
        End If
        If IsNotNull(FUPDATE_TERM_ID) Then
            strMsg &= "[更新端末ID:" & FUPDATE_TERM_ID & "]"
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
#Region "  ﾚｺｰﾄﾞ全取得(条件:画面ID,ｺﾝﾄﾛｰﾙID)           "
    Public Function GET_TDSP_PMT_USER_FDISP_ID() As RetCode
        Try
            Dim intRet As RetCode                 '戻り値
            '' ''Dim strMsg As String                  'ﾒｯｾｰｼﾞ

            Dim strSQL As String
            strSQL = ""
            strSQL &= vbCrLf & "SELECT "
            strSQL &= vbCrLf & "   * "
            strSQL &= vbCrLf & "FROM "
            strSQL &= vbCrLf & "   TDSP_PMT_USER "
            strSQL &= vbCrLf & "WHERE "
            strSQL &= vbCrLf & "      (FDISP_ID = 'HDT_301000'"
            strSQL &= vbCrLf & "   OR  FDISP_ID = 'HDT_303000')"
            strSQL &= vbCrLf & "   AND FCTRL_ID <> '" & FCTRL_ID_SKOTEI & "'"
            If IsNull(mFUSER_DSP_LEVEL) = False Then
                strSQL &= vbCrLf & "            AND FUSER_DSP_LEVEL = " & TO_STRING(mFUSER_DSP_LEVEL)      'ﾕｰｻﾞ操作ﾚﾍﾞﾙ
            End If
            strSQL &= vbCrLf & "ORDER BY "
            strSQL &= vbCrLf & "   FDISP_ID, FCTRL_ID "
            strSQL &= vbCrLf
            mstrUSER_SQL = strSQL
            intRet = GET_TDSP_PMT_USER_USER()       '特定


            Return intRet
        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
    End Function
#End Region
    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
