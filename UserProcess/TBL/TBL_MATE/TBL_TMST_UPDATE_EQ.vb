'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' 【名称】MaterialStreamﾃｰﾌﾞﾙｸﾗｽ
' 【機能】状態報告更新ﾏｽﾀﾃｰﾌﾞﾙｸﾗｽ
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
''' 状態報告更新ﾏｽﾀﾃｰﾌﾞﾙｸﾗｽ
''' </summary>
Public Class TBL_TMST_UPDATE_EQ
    Inherits clsTemplateTable

    '**********************************************************************************************
    '↓↓↓自動生成部
#Region "  ｸﾗｽ変数定義                  "
    'ﾌﾟﾛﾊﾟﾃｨ
    Private mobjAryMe As TBL_TMST_UPDATE_EQ()                                    '状態報告更新ﾏｽﾀ
    Private mstrUSER_SQL As String                                               'ﾕｰｻﾞｰSQL
    Private mORDER_BY As String                                                  'OrderBy句
    Private mWHERE As String                                                     'Where句
    Private mFEQ_ID As String                                                    '設備ID
    Private mFTEXT_ID As String                                                  'ﾃｷｽﾄID
    Private mFBYTE_POS As Nullable(Of Integer)                                   'ﾊﾞｲﾄ位置
    Private mFBYTE_NUM As Nullable(Of Integer)                                   'ﾊﾞｲﾄ数
    Private mFUPDATE_EQ_ID As String                                             '更新設備ID
    Private mFUPDATE_FIELD As String                                             '更新ﾌｨｰﾙﾄﾞ
    Private mFCOMMENT As String                                                  'ｺﾒﾝﾄ
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                  "
    ''' <summary>
    ''' ｼｽﾃﾑ変数 (自ｸﾗｽ型配列)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_TMST_UPDATE_EQ()
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
    ''' 設備ID
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
    ''' ﾃｷｽﾄID
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
    ''' ﾊﾞｲﾄ位置
    ''' </summary>
    Public Property FBYTE_POS() As Nullable(Of Integer)
        Get
            Return mFBYTE_POS
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFBYTE_POS = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾊﾞｲﾄ数
    ''' </summary>
    Public Property FBYTE_NUM() As Nullable(Of Integer)
        Get
            Return mFBYTE_NUM
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFBYTE_NUM = Value
        End Set
    End Property
    ''' <summary>
    ''' 更新設備ID
    ''' </summary>
    Public Property FUPDATE_EQ_ID() As String
        Get
            Return mFUPDATE_EQ_ID
        End Get
        Set(ByVal Value As String)
            mFUPDATE_EQ_ID = Value
        End Set
    End Property
    ''' <summary>
    ''' 更新ﾌｨｰﾙﾄﾞ
    ''' </summary>
    Public Property FUPDATE_FIELD() As String
        Get
            Return mFUPDATE_FIELD
        End Get
        Set(ByVal Value As String)
            mFUPDATE_FIELD = Value
        End Set
    End Property
    ''' <summary>
    ''' ｺﾒﾝﾄ
    ''' </summary>
    Public Property FCOMMENT() As String
        Get
            Return mFCOMMENT
        End Get
        Set(ByVal Value As String)
            mFCOMMENT = Value
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
    Public Function GET_TMST_UPDATE_EQ(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    TMST_UPDATE_EQ")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FEQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --設備ID")
        End If
        If IsNull(FTEXT_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTEXT_ID
            strSQL.Append(vbCrLf & "    AND FTEXT_ID = :" & UBound(strBindField) - 1 & " --ﾃｷｽﾄID")
        End If
        If IsNull(FBYTE_POS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBYTE_POS
            strSQL.Append(vbCrLf & "    AND FBYTE_POS = :" & UBound(strBindField) - 1 & " --ﾊﾞｲﾄ位置")
        End If
        If IsNull(FBYTE_NUM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBYTE_NUM
            strSQL.Append(vbCrLf & "    AND FBYTE_NUM = :" & UBound(strBindField) - 1 & " --ﾊﾞｲﾄ数")
        End If
        If IsNull(FUPDATE_EQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_EQ_ID
            strSQL.Append(vbCrLf & "    AND FUPDATE_EQ_ID = :" & UBound(strBindField) - 1 & " --更新設備ID")
        End If
        If IsNull(FUPDATE_FIELD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_FIELD
            strSQL.Append(vbCrLf & "    AND FUPDATE_FIELD = :" & UBound(strBindField) - 1 & " --更新ﾌｨｰﾙﾄﾞ")
        End If
        If IsNull(FCOMMENT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOMMENT
            strSQL.Append(vbCrLf & "    AND FCOMMENT = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ")
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
        strDataSetName = "TMST_UPDATE_EQ"
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
    Public Function GET_TMST_UPDATE_EQ_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    TMST_UPDATE_EQ")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FEQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --設備ID")
        End If
        If IsNull(FTEXT_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTEXT_ID
            strSQL.Append(vbCrLf & "    AND FTEXT_ID = :" & UBound(strBindField) - 1 & " --ﾃｷｽﾄID")
        End If
        If IsNull(FBYTE_POS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBYTE_POS
            strSQL.Append(vbCrLf & "    AND FBYTE_POS = :" & UBound(strBindField) - 1 & " --ﾊﾞｲﾄ位置")
        End If
        If IsNull(FBYTE_NUM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBYTE_NUM
            strSQL.Append(vbCrLf & "    AND FBYTE_NUM = :" & UBound(strBindField) - 1 & " --ﾊﾞｲﾄ数")
        End If
        If IsNull(FUPDATE_EQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_EQ_ID
            strSQL.Append(vbCrLf & "    AND FUPDATE_EQ_ID = :" & UBound(strBindField) - 1 & " --更新設備ID")
        End If
        If IsNull(FUPDATE_FIELD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_FIELD
            strSQL.Append(vbCrLf & "    AND FUPDATE_FIELD = :" & UBound(strBindField) - 1 & " --更新ﾌｨｰﾙﾄﾞ")
        End If
        If IsNull(FCOMMENT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOMMENT
            strSQL.Append(vbCrLf & "    AND FCOMMENT = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ")
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
        strDataSetName = "TMST_UPDATE_EQ"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TMST_UPDATE_EQ(Owner, objDb, objDbLog)
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
    Public Function GET_TMST_UPDATE_EQ_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "TMST_UPDATE_EQ"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TMST_UPDATE_EQ(Owner, objDb, objDbLog)
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
    Public Function GET_TMST_UPDATE_EQ_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    TMST_UPDATE_EQ")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FEQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --設備ID")
        End If
        If IsNull(FTEXT_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTEXT_ID
            strSQL.Append(vbCrLf & "    AND FTEXT_ID = :" & UBound(strBindField) - 1 & " --ﾃｷｽﾄID")
        End If
        If IsNull(FBYTE_POS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBYTE_POS
            strSQL.Append(vbCrLf & "    AND FBYTE_POS = :" & UBound(strBindField) - 1 & " --ﾊﾞｲﾄ位置")
        End If
        If IsNull(FBYTE_NUM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBYTE_NUM
            strSQL.Append(vbCrLf & "    AND FBYTE_NUM = :" & UBound(strBindField) - 1 & " --ﾊﾞｲﾄ数")
        End If
        If IsNull(FUPDATE_EQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_EQ_ID
            strSQL.Append(vbCrLf & "    AND FUPDATE_EQ_ID = :" & UBound(strBindField) - 1 & " --更新設備ID")
        End If
        If IsNull(FUPDATE_FIELD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_FIELD
            strSQL.Append(vbCrLf & "    AND FUPDATE_FIELD = :" & UBound(strBindField) - 1 & " --更新ﾌｨｰﾙﾄﾞ")
        End If
        If IsNull(FCOMMENT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOMMENT
            strSQL.Append(vbCrLf & "    AND FCOMMENT = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ")
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
        strDataSetName = "TMST_UPDATE_EQ"
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
    Public Sub UPDATE_TMST_UPDATE_EQ()
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
        End If


        '***********************
        '更新SQL作成
        '***********************
        strBindField = Nothing
        objBindValue = Nothing
        ReDim Preserve strBindField(0)
        ReDim Preserve objBindValue(0)
        strSQL.Append(vbCrLf & "UPDATE")
        strSQL.Append(vbCrLf & "    TMST_UPDATE_EQ")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
        If IsNull(mFEQ_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_ID = NULL --設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_ID = NULL --設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_ID = :" & Ubound(strBindField) - 1 & " --設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_ID = :" & Ubound(strBindField) - 1 & " --設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mFTEXT_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTEXT_ID = NULL --ﾃｷｽﾄID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTEXT_ID = NULL --ﾃｷｽﾄID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTEXT_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTEXT_ID = :" & Ubound(strBindField) - 1 & " --ﾃｷｽﾄID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTEXT_ID = :" & Ubound(strBindField) - 1 & " --ﾃｷｽﾄID")
        End If
        intCount = intCount + 1
        If IsNull(mFBYTE_POS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FBYTE_POS = NULL --ﾊﾞｲﾄ位置")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FBYTE_POS = NULL --ﾊﾞｲﾄ位置")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBYTE_POS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FBYTE_POS = :" & Ubound(strBindField) - 1 & " --ﾊﾞｲﾄ位置")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FBYTE_POS = :" & Ubound(strBindField) - 1 & " --ﾊﾞｲﾄ位置")
        End If
        intCount = intCount + 1
        If IsNull(mFBYTE_NUM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FBYTE_NUM = NULL --ﾊﾞｲﾄ数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FBYTE_NUM = NULL --ﾊﾞｲﾄ数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBYTE_NUM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FBYTE_NUM = :" & Ubound(strBindField) - 1 & " --ﾊﾞｲﾄ数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FBYTE_NUM = :" & Ubound(strBindField) - 1 & " --ﾊﾞｲﾄ数")
        End If
        intCount = intCount + 1
        If IsNull(mFUPDATE_EQ_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUPDATE_EQ_ID = NULL --更新設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUPDATE_EQ_ID = NULL --更新設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_EQ_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUPDATE_EQ_ID = :" & Ubound(strBindField) - 1 & " --更新設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUPDATE_EQ_ID = :" & Ubound(strBindField) - 1 & " --更新設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mFUPDATE_FIELD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUPDATE_FIELD = NULL --更新ﾌｨｰﾙﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUPDATE_FIELD = NULL --更新ﾌｨｰﾙﾄﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_FIELD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUPDATE_FIELD = :" & Ubound(strBindField) - 1 & " --更新ﾌｨｰﾙﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUPDATE_FIELD = :" & Ubound(strBindField) - 1 & " --更新ﾌｨｰﾙﾄﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFCOMMENT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCOMMENT = NULL --ｺﾒﾝﾄ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCOMMENT = NULL --ｺﾒﾝﾄ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOMMENT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCOMMENT = :" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCOMMENT = :" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FEQ_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FEQ_ID IS NULL --設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --設備ID")
        End If
        If IsNull(FTEXT_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FTEXT_ID IS NULL --ﾃｷｽﾄID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTEXT_ID
            strSQL.Append(vbCrLf & "    AND FTEXT_ID = :" & UBound(strBindField) - 1 & " --ﾃｷｽﾄID")
        End If
        If IsNull(FBYTE_POS) = True Then
            strSQL.Append(vbCrLf & "    AND FBYTE_POS IS NULL --ﾊﾞｲﾄ位置")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBYTE_POS
            strSQL.Append(vbCrLf & "    AND FBYTE_POS = :" & UBound(strBindField) - 1 & " --ﾊﾞｲﾄ位置")
        End If
        If IsNull(FBYTE_NUM) = True Then
            strSQL.Append(vbCrLf & "    AND FBYTE_NUM IS NULL --ﾊﾞｲﾄ数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBYTE_NUM
            strSQL.Append(vbCrLf & "    AND FBYTE_NUM = :" & UBound(strBindField) - 1 & " --ﾊﾞｲﾄ数")
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
    Public Sub ADD_TMST_UPDATE_EQ()
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
        End If


        '***********************
        '追加SQL作成
        '***********************
        strBindField = Nothing
        objBindValue = Nothing
        ReDim Preserve strBindField(0)
        ReDim Preserve objBindValue(0)
        strSQL.Append(vbCrLf & "INSERT INTO")
        strSQL.Append(vbCrLf & "    TMST_UPDATE_EQ")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
        If IsNull(mFEQ_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mFTEXT_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾃｷｽﾄID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾃｷｽﾄID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTEXT_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾃｷｽﾄID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾃｷｽﾄID")
        End If
        intCount = intCount + 1
        If IsNull(mFBYTE_POS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾊﾞｲﾄ位置")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾊﾞｲﾄ位置")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBYTE_POS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾊﾞｲﾄ位置")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾊﾞｲﾄ位置")
        End If
        intCount = intCount + 1
        If IsNull(mFBYTE_NUM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾊﾞｲﾄ数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾊﾞｲﾄ数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBYTE_NUM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾊﾞｲﾄ数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾊﾞｲﾄ数")
        End If
        intCount = intCount + 1
        If IsNull(mFUPDATE_EQ_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --更新設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --更新設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_EQ_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --更新設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --更新設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mFUPDATE_FIELD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --更新ﾌｨｰﾙﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --更新ﾌｨｰﾙﾄﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_FIELD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --更新ﾌｨｰﾙﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --更新ﾌｨｰﾙﾄﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFCOMMENT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｺﾒﾝﾄ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｺﾒﾝﾄ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOMMENT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ")
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
    Public Sub DELETE_TMST_UPDATE_EQ()
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
        ElseIf IsNull(mFEQ_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[設備ID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFTEXT_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾃｷｽﾄID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFBYTE_POS) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾊﾞｲﾄ位置]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFBYTE_NUM) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾊﾞｲﾄ数]"
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
        strSQL.Append(vbCrLf & "    TMST_UPDATE_EQ")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FEQ_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FEQ_ID IS NULL --設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --設備ID")
        End If
        If IsNull(FTEXT_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FTEXT_ID IS NULL --ﾃｷｽﾄID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTEXT_ID
            strSQL.Append(vbCrLf & "    AND FTEXT_ID = :" & UBound(strBindField) - 1 & " --ﾃｷｽﾄID")
        End If
        If IsNull(FBYTE_POS) = True Then
            strSQL.Append(vbCrLf & "    AND FBYTE_POS IS NULL --ﾊﾞｲﾄ位置")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBYTE_POS
            strSQL.Append(vbCrLf & "    AND FBYTE_POS = :" & UBound(strBindField) - 1 & " --ﾊﾞｲﾄ位置")
        End If
        If IsNull(FBYTE_NUM) = True Then
            strSQL.Append(vbCrLf & "    AND FBYTE_NUM IS NULL --ﾊﾞｲﾄ数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBYTE_NUM
            strSQL.Append(vbCrLf & "    AND FBYTE_NUM = :" & UBound(strBindField) - 1 & " --ﾊﾞｲﾄ数")
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
    Public Sub DELETE_TMST_UPDATE_EQ_ANY()
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
        strSQL.Append(vbCrLf & "    TMST_UPDATE_EQ")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(FEQ_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --設備ID")
        End If
        If IsNotNull(FTEXT_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTEXT_ID
            strSQL.Append(vbCrLf & "    AND FTEXT_ID = :" & UBound(strBindField) - 1 & " --ﾃｷｽﾄID")
        End If
        If IsNotNull(FBYTE_POS) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBYTE_POS
            strSQL.Append(vbCrLf & "    AND FBYTE_POS = :" & UBound(strBindField) - 1 & " --ﾊﾞｲﾄ位置")
        End If
        If IsNotNull(FBYTE_NUM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBYTE_NUM
            strSQL.Append(vbCrLf & "    AND FBYTE_NUM = :" & UBound(strBindField) - 1 & " --ﾊﾞｲﾄ数")
        End If
        If IsNotNull(FUPDATE_EQ_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_EQ_ID
            strSQL.Append(vbCrLf & "    AND FUPDATE_EQ_ID = :" & UBound(strBindField) - 1 & " --更新設備ID")
        End If
        If IsNotNull(FUPDATE_FIELD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_FIELD
            strSQL.Append(vbCrLf & "    AND FUPDATE_FIELD = :" & UBound(strBindField) - 1 & " --更新ﾌｨｰﾙﾄﾞ")
        End If
        If IsNotNull(FCOMMENT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOMMENT
            strSQL.Append(vbCrLf & "    AND FCOMMENT = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ")
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
        If IsNothing(objType.GetProperty("FEQ_ID")) = False Then mFEQ_ID = objObject.FEQ_ID '設備ID
        If IsNothing(objType.GetProperty("FTEXT_ID")) = False Then mFTEXT_ID = objObject.FTEXT_ID 'ﾃｷｽﾄID
        If IsNothing(objType.GetProperty("FBYTE_POS")) = False Then mFBYTE_POS = objObject.FBYTE_POS 'ﾊﾞｲﾄ位置
        If IsNothing(objType.GetProperty("FBYTE_NUM")) = False Then mFBYTE_NUM = objObject.FBYTE_NUM 'ﾊﾞｲﾄ数
        If IsNothing(objType.GetProperty("FUPDATE_EQ_ID")) = False Then mFUPDATE_EQ_ID = objObject.FUPDATE_EQ_ID '更新設備ID
        If IsNothing(objType.GetProperty("FUPDATE_FIELD")) = False Then mFUPDATE_FIELD = objObject.FUPDATE_FIELD '更新ﾌｨｰﾙﾄﾞ
        If IsNothing(objType.GetProperty("FCOMMENT")) = False Then mFCOMMENT = objObject.FCOMMENT 'ｺﾒﾝﾄ

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
        mFEQ_ID = Nothing
        mFTEXT_ID = Nothing
        mFBYTE_POS = Nothing
        mFBYTE_NUM = Nothing
        mFUPDATE_EQ_ID = Nothing
        mFUPDATE_FIELD = Nothing
        mFCOMMENT = Nothing


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
        mFEQ_ID = TO_STRING_NULLABLE(objRow("FEQ_ID"))
        mFTEXT_ID = TO_STRING_NULLABLE(objRow("FTEXT_ID"))
        mFBYTE_POS = TO_INTEGER_NULLABLE(objRow("FBYTE_POS"))
        mFBYTE_NUM = TO_INTEGER_NULLABLE(objRow("FBYTE_NUM"))
        mFUPDATE_EQ_ID = TO_STRING_NULLABLE(objRow("FUPDATE_EQ_ID"))
        mFUPDATE_FIELD = TO_STRING_NULLABLE(objRow("FUPDATE_FIELD"))
        mFCOMMENT = TO_STRING_NULLABLE(objRow("FCOMMENT"))


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
        strMsg &= "[ﾃｰﾌﾞﾙ名:状態報告更新ﾏｽﾀ]"
        If IsNotNull(FEQ_ID) Then
            strMsg &= "[設備ID:" & FEQ_ID & "]"
        End If
        If IsNotNull(FTEXT_ID) Then
            strMsg &= "[ﾃｷｽﾄID:" & FTEXT_ID & "]"
        End If
        If IsNotNull(FBYTE_POS) Then
            strMsg &= "[ﾊﾞｲﾄ位置:" & FBYTE_POS & "]"
        End If
        If IsNotNull(FBYTE_NUM) Then
            strMsg &= "[ﾊﾞｲﾄ数:" & FBYTE_NUM & "]"
        End If
        If IsNotNull(FUPDATE_EQ_ID) Then
            strMsg &= "[更新設備ID:" & FUPDATE_EQ_ID & "]"
        End If
        If IsNotNull(FUPDATE_FIELD) Then
            strMsg &= "[更新ﾌｨｰﾙﾄﾞ:" & FUPDATE_FIELD & "]"
        End If
        If IsNotNull(FCOMMENT) Then
            strMsg &= "[ｺﾒﾝﾄ:" & FCOMMENT & "]"
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
