'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' 【名称】MaterialStreamﾃｰﾌﾞﾙｸﾗｽ
' 【機能】ｸﾚｰﾝﾏｽﾀﾃｰﾌﾞﾙｸﾗｽ
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
''' ｸﾚｰﾝﾏｽﾀﾃｰﾌﾞﾙｸﾗｽ
''' </summary>
Public Class TBL_TMST_CRANE
    Inherits clsTemplateTable

    '**********************************************************************************************
    '↓↓↓自動生成部
#Region "  ｸﾗｽ変数定義                  "
    'ﾌﾟﾛﾊﾟﾃｨ
    Private mobjAryMe As TBL_TMST_CRANE()                                        'ｸﾚｰﾝﾏｽﾀ
    Private mstrUSER_SQL As String                                               'ﾕｰｻﾞｰSQL
    Private mORDER_BY As String                                                  'OrderBy句
    Private mWHERE As String                                                     'Where句
    Private mFEQ_ID As String                                                    '設備ID
    Private mFTRK_BUF_NO As Nullable(Of Integer)                                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    Private mFIN_MAX As Nullable(Of Integer)                                     '入庫規制数
    Private mFOUT_MAX As Nullable(Of Integer)                                    '出庫規制数
    Private mFINOUT_MAX As Nullable(Of Integer)                                  '入出庫規制数
    Private mFCRANE_ROW1 As Nullable(Of Integer)                                 'ｸﾚｰﾝ対象列1
    Private mFCRANE_ROW2 As Nullable(Of Integer)                                 'ｸﾚｰﾝ対象列2
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                  "
    ''' <summary>
    ''' ｼｽﾃﾑ変数 (自ｸﾗｽ型配列)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_TMST_CRANE()
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
    ''' ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    ''' </summary>
    Public Property FTRK_BUF_NO() As Nullable(Of Integer)
        Get
            Return mFTRK_BUF_NO
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFTRK_BUF_NO = Value
        End Set
    End Property
    ''' <summary>
    ''' 入庫規制数
    ''' </summary>
    Public Property FIN_MAX() As Nullable(Of Integer)
        Get
            Return mFIN_MAX
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFIN_MAX = Value
        End Set
    End Property
    ''' <summary>
    ''' 出庫規制数
    ''' </summary>
    Public Property FOUT_MAX() As Nullable(Of Integer)
        Get
            Return mFOUT_MAX
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFOUT_MAX = Value
        End Set
    End Property
    ''' <summary>
    ''' 入出庫規制数
    ''' </summary>
    Public Property FINOUT_MAX() As Nullable(Of Integer)
        Get
            Return mFINOUT_MAX
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFINOUT_MAX = Value
        End Set
    End Property
    ''' <summary>
    ''' ｸﾚｰﾝ対象列1
    ''' </summary>
    Public Property FCRANE_ROW1() As Nullable(Of Integer)
        Get
            Return mFCRANE_ROW1
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFCRANE_ROW1 = Value
        End Set
    End Property
    ''' <summary>
    ''' ｸﾚｰﾝ対象列2
    ''' </summary>
    Public Property FCRANE_ROW2() As Nullable(Of Integer)
        Get
            Return mFCRANE_ROW2
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFCRANE_ROW2 = Value
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
    Public Function GET_TMST_CRANE(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    TMST_CRANE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FEQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --設備ID")
        End If
        If IsNull(FTRK_BUF_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNull(FIN_MAX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFIN_MAX
            strSQL.Append(vbCrLf & "    AND FIN_MAX = :" & UBound(strBindField) - 1 & " --入庫規制数")
        End If
        If IsNull(FOUT_MAX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFOUT_MAX
            strSQL.Append(vbCrLf & "    AND FOUT_MAX = :" & UBound(strBindField) - 1 & " --出庫規制数")
        End If
        If IsNull(FINOUT_MAX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINOUT_MAX
            strSQL.Append(vbCrLf & "    AND FINOUT_MAX = :" & UBound(strBindField) - 1 & " --入出庫規制数")
        End If
        If IsNull(FCRANE_ROW1) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCRANE_ROW1
            strSQL.Append(vbCrLf & "    AND FCRANE_ROW1 = :" & UBound(strBindField) - 1 & " --ｸﾚｰﾝ対象列1")
        End If
        If IsNull(FCRANE_ROW2) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCRANE_ROW2
            strSQL.Append(vbCrLf & "    AND FCRANE_ROW2 = :" & UBound(strBindField) - 1 & " --ｸﾚｰﾝ対象列2")
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
        strDataSetName = "TMST_CRANE"
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
    Public Function GET_TMST_CRANE_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    TMST_CRANE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FEQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --設備ID")
        End If
        If IsNull(FTRK_BUF_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNull(FIN_MAX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFIN_MAX
            strSQL.Append(vbCrLf & "    AND FIN_MAX = :" & UBound(strBindField) - 1 & " --入庫規制数")
        End If
        If IsNull(FOUT_MAX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFOUT_MAX
            strSQL.Append(vbCrLf & "    AND FOUT_MAX = :" & UBound(strBindField) - 1 & " --出庫規制数")
        End If
        If IsNull(FINOUT_MAX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINOUT_MAX
            strSQL.Append(vbCrLf & "    AND FINOUT_MAX = :" & UBound(strBindField) - 1 & " --入出庫規制数")
        End If
        If IsNull(FCRANE_ROW1) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCRANE_ROW1
            strSQL.Append(vbCrLf & "    AND FCRANE_ROW1 = :" & UBound(strBindField) - 1 & " --ｸﾚｰﾝ対象列1")
        End If
        If IsNull(FCRANE_ROW2) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCRANE_ROW2
            strSQL.Append(vbCrLf & "    AND FCRANE_ROW2 = :" & UBound(strBindField) - 1 & " --ｸﾚｰﾝ対象列2")
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
        strDataSetName = "TMST_CRANE"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TMST_CRANE(Owner, objDb, objDbLog)
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
    Public Function GET_TMST_CRANE_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "TMST_CRANE"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TMST_CRANE(Owner, objDb, objDbLog)
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
    Public Function GET_TMST_CRANE_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    TMST_CRANE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FEQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --設備ID")
        End If
        If IsNull(FTRK_BUF_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNull(FIN_MAX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFIN_MAX
            strSQL.Append(vbCrLf & "    AND FIN_MAX = :" & UBound(strBindField) - 1 & " --入庫規制数")
        End If
        If IsNull(FOUT_MAX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFOUT_MAX
            strSQL.Append(vbCrLf & "    AND FOUT_MAX = :" & UBound(strBindField) - 1 & " --出庫規制数")
        End If
        If IsNull(FINOUT_MAX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINOUT_MAX
            strSQL.Append(vbCrLf & "    AND FINOUT_MAX = :" & UBound(strBindField) - 1 & " --入出庫規制数")
        End If
        If IsNull(FCRANE_ROW1) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCRANE_ROW1
            strSQL.Append(vbCrLf & "    AND FCRANE_ROW1 = :" & UBound(strBindField) - 1 & " --ｸﾚｰﾝ対象列1")
        End If
        If IsNull(FCRANE_ROW2) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCRANE_ROW2
            strSQL.Append(vbCrLf & "    AND FCRANE_ROW2 = :" & UBound(strBindField) - 1 & " --ｸﾚｰﾝ対象列2")
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
        strDataSetName = "TMST_CRANE"
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
    Public Sub UPDATE_TMST_CRANE()
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
        ElseIf IsNull(mFTRK_BUF_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFCRANE_ROW1) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ｸﾚｰﾝ対象列1]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFCRANE_ROW2) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ｸﾚｰﾝ対象列2]"
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
        strSQL.Append(vbCrLf & "    TMST_CRANE")
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
        If IsNull(mFTRK_BUF_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTRK_BUF_NO = NULL --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTRK_BUF_NO = NULL --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTRK_BUF_NO = :" & Ubound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTRK_BUF_NO = :" & Ubound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        intCount = intCount + 1
        If IsNull(mFIN_MAX) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FIN_MAX = NULL --入庫規制数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FIN_MAX = NULL --入庫規制数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFIN_MAX
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FIN_MAX = :" & Ubound(strBindField) - 1 & " --入庫規制数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FIN_MAX = :" & Ubound(strBindField) - 1 & " --入庫規制数")
        End If
        intCount = intCount + 1
        If IsNull(mFOUT_MAX) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FOUT_MAX = NULL --出庫規制数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FOUT_MAX = NULL --出庫規制数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFOUT_MAX
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FOUT_MAX = :" & Ubound(strBindField) - 1 & " --出庫規制数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FOUT_MAX = :" & Ubound(strBindField) - 1 & " --出庫規制数")
        End If
        intCount = intCount + 1
        If IsNull(mFINOUT_MAX) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FINOUT_MAX = NULL --入出庫規制数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FINOUT_MAX = NULL --入出庫規制数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINOUT_MAX
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FINOUT_MAX = :" & Ubound(strBindField) - 1 & " --入出庫規制数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FINOUT_MAX = :" & Ubound(strBindField) - 1 & " --入出庫規制数")
        End If
        intCount = intCount + 1
        If IsNull(mFCRANE_ROW1) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCRANE_ROW1 = NULL --ｸﾚｰﾝ対象列1")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCRANE_ROW1 = NULL --ｸﾚｰﾝ対象列1")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCRANE_ROW1
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCRANE_ROW1 = :" & Ubound(strBindField) - 1 & " --ｸﾚｰﾝ対象列1")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCRANE_ROW1 = :" & Ubound(strBindField) - 1 & " --ｸﾚｰﾝ対象列1")
        End If
        intCount = intCount + 1
        If IsNull(mFCRANE_ROW2) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCRANE_ROW2 = NULL --ｸﾚｰﾝ対象列2")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCRANE_ROW2 = NULL --ｸﾚｰﾝ対象列2")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCRANE_ROW2
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCRANE_ROW2 = :" & Ubound(strBindField) - 1 & " --ｸﾚｰﾝ対象列2")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCRANE_ROW2 = :" & Ubound(strBindField) - 1 & " --ｸﾚｰﾝ対象列2")
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
    Public Sub ADD_TMST_CRANE()
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
        ElseIf IsNull(mFTRK_BUF_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFCRANE_ROW1) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ｸﾚｰﾝ対象列1]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFCRANE_ROW2) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ｸﾚｰﾝ対象列2]"
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
        strSQL.Append(vbCrLf & "    TMST_CRANE")
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
        If IsNull(mFTRK_BUF_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        intCount = intCount + 1
        If IsNull(mFIN_MAX) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --入庫規制数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --入庫規制数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFIN_MAX
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --入庫規制数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --入庫規制数")
        End If
        intCount = intCount + 1
        If IsNull(mFOUT_MAX) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --出庫規制数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --出庫規制数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFOUT_MAX
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --出庫規制数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --出庫規制数")
        End If
        intCount = intCount + 1
        If IsNull(mFINOUT_MAX) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --入出庫規制数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --入出庫規制数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINOUT_MAX
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --入出庫規制数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --入出庫規制数")
        End If
        intCount = intCount + 1
        If IsNull(mFCRANE_ROW1) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｸﾚｰﾝ対象列1")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｸﾚｰﾝ対象列1")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCRANE_ROW1
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｸﾚｰﾝ対象列1")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｸﾚｰﾝ対象列1")
        End If
        intCount = intCount + 1
        If IsNull(mFCRANE_ROW2) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｸﾚｰﾝ対象列2")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｸﾚｰﾝ対象列2")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCRANE_ROW2
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｸﾚｰﾝ対象列2")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｸﾚｰﾝ対象列2")
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
    Public Sub DELETE_TMST_CRANE()
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
        strSQL.Append(vbCrLf & "    TMST_CRANE")
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
    Public Sub DELETE_TMST_CRANE_ANY()
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
        strSQL.Append(vbCrLf & "    TMST_CRANE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(FEQ_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --設備ID")
        End If
        If IsNotNull(FTRK_BUF_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNotNull(FIN_MAX) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFIN_MAX
            strSQL.Append(vbCrLf & "    AND FIN_MAX = :" & UBound(strBindField) - 1 & " --入庫規制数")
        End If
        If IsNotNull(FOUT_MAX) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFOUT_MAX
            strSQL.Append(vbCrLf & "    AND FOUT_MAX = :" & UBound(strBindField) - 1 & " --出庫規制数")
        End If
        If IsNotNull(FINOUT_MAX) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINOUT_MAX
            strSQL.Append(vbCrLf & "    AND FINOUT_MAX = :" & UBound(strBindField) - 1 & " --入出庫規制数")
        End If
        If IsNotNull(FCRANE_ROW1) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCRANE_ROW1
            strSQL.Append(vbCrLf & "    AND FCRANE_ROW1 = :" & UBound(strBindField) - 1 & " --ｸﾚｰﾝ対象列1")
        End If
        If IsNotNull(FCRANE_ROW2) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCRANE_ROW2
            strSQL.Append(vbCrLf & "    AND FCRANE_ROW2 = :" & UBound(strBindField) - 1 & " --ｸﾚｰﾝ対象列2")
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
        If IsNothing(objType.GetProperty("FTRK_BUF_NO")) = False Then mFTRK_BUF_NO = objObject.FTRK_BUF_NO 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        If IsNothing(objType.GetProperty("FIN_MAX")) = False Then mFIN_MAX = objObject.FIN_MAX '入庫規制数
        If IsNothing(objType.GetProperty("FOUT_MAX")) = False Then mFOUT_MAX = objObject.FOUT_MAX '出庫規制数
        If IsNothing(objType.GetProperty("FINOUT_MAX")) = False Then mFINOUT_MAX = objObject.FINOUT_MAX '入出庫規制数
        If IsNothing(objType.GetProperty("FCRANE_ROW1")) = False Then mFCRANE_ROW1 = objObject.FCRANE_ROW1 'ｸﾚｰﾝ対象列1
        If IsNothing(objType.GetProperty("FCRANE_ROW2")) = False Then mFCRANE_ROW2 = objObject.FCRANE_ROW2 'ｸﾚｰﾝ対象列2

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
        mFTRK_BUF_NO = Nothing
        mFIN_MAX = Nothing
        mFOUT_MAX = Nothing
        mFINOUT_MAX = Nothing
        mFCRANE_ROW1 = Nothing
        mFCRANE_ROW2 = Nothing


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
        mFTRK_BUF_NO = TO_INTEGER_NULLABLE(objRow("FTRK_BUF_NO"))
        mFIN_MAX = TO_INTEGER_NULLABLE(objRow("FIN_MAX"))
        mFOUT_MAX = TO_INTEGER_NULLABLE(objRow("FOUT_MAX"))
        mFINOUT_MAX = TO_INTEGER_NULLABLE(objRow("FINOUT_MAX"))
        mFCRANE_ROW1 = TO_INTEGER_NULLABLE(objRow("FCRANE_ROW1"))
        mFCRANE_ROW2 = TO_INTEGER_NULLABLE(objRow("FCRANE_ROW2"))


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
        strMsg &= "[ﾃｰﾌﾞﾙ名:ｸﾚｰﾝﾏｽﾀ]"
        If IsNotNull(FEQ_ID) Then
            strMsg &= "[設備ID:" & FEQ_ID & "]"
        End If
        If IsNotNull(FTRK_BUF_NO) Then
            strMsg &= "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & FTRK_BUF_NO & "]"
        End If
        If IsNotNull(FIN_MAX) Then
            strMsg &= "[入庫規制数:" & FIN_MAX & "]"
        End If
        If IsNotNull(FOUT_MAX) Then
            strMsg &= "[出庫規制数:" & FOUT_MAX & "]"
        End If
        If IsNotNull(FINOUT_MAX) Then
            strMsg &= "[入出庫規制数:" & FINOUT_MAX & "]"
        End If
        If IsNotNull(FCRANE_ROW1) Then
            strMsg &= "[ｸﾚｰﾝ対象列1:" & FCRANE_ROW1 & "]"
        End If
        If IsNotNull(FCRANE_ROW2) Then
            strMsg &= "[ｸﾚｰﾝ対象列2:" & FCRANE_ROW2 & "]"
        End If


    End Sub
#End Region
    '↑↑↑自動生成部
    '**********************************************************************************************

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ共通
#Region "  ｸﾗｽ変数定義"
    'ﾌﾟﾛﾊﾟﾃｨ(ﾃｰﾌﾞﾙ列)
    Private mINTCHECK_ROW As Nullable(Of Integer)              'ﾁｪｯｸ列
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義"
    Public Property INTCHECK_ROW() As Nullable(Of Integer)
        Get
            Return mINTCHECK_ROW
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mINTCHECK_ROW = Value
        End Set
    End Property
#End Region
#Region "  ｸﾚｰﾝﾏｽﾀ取得  [列指定]                                                                    "
    Public Function GET_TMST_CRANE_ROW() As RetCode
        Try
            Dim strSQL As String            'SQL文
            Dim strMsg As String            'ﾒｯｾｰｼﾞ
            Dim objDataSet As New DataSet   'ﾃﾞｰﾀｾｯﾄ
            Dim strDataSetName As String    'ﾃﾞｰﾀｾｯﾄ名
            Dim objRow As DataRow           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ

            '***********************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '***********************
            If IsNull(mFTRK_BUF_NO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mINTCHECK_ROW) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[列]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '抽出SQL作成
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    *"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TMST_CRANE"
            strSQL &= vbCrLf & " WHERE"

            strSQL &= vbCrLf & "        FTRK_BUF_NO = " & TO_STRING(mFTRK_BUF_NO)
            strSQL &= vbCrLf & "    AND FCRANE_ROW1 <= " & TO_STRING(mINTCHECK_ROW)
            strSQL &= vbCrLf & "    AND " & TO_STRING(mINTCHECK_ROW) & " <= FCRANE_ROW2 "

            strSQL &= vbCrLf


            '***********************
            '抽出
            '***********************
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TMST_CRANE"
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
    '↑↑↑ｼｽﾃﾑ共通
    '**********************************************************************************************


    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
