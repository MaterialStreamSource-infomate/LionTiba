'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' 【名称】MaterialStreamﾃｰﾌﾞﾙｸﾗｽ
' 【機能】画面設備状態表示ﾏｽﾀﾃｰﾌﾞﾙｸﾗｽ
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
''' 画面設備状態表示ﾏｽﾀﾃｰﾌﾞﾙｸﾗｽ
''' </summary>
Public Class TBL_TDSP_EQ_STS
    Inherits clsTemplateTable

    '**********************************************************************************************
    '↓↓↓自動生成部
#Region "  ｸﾗｽ変数定義                  "
    'ﾌﾟﾛﾊﾟﾃｨ
    Private mobjAryMe As TBL_TDSP_EQ_STS()                                       '画面設備状態表示ﾏｽﾀ
    Private mstrUSER_SQL As String                                               'ﾕｰｻﾞｰSQL
    Private mORDER_BY As String                                                  'OrderBy句
    Private mWHERE As String                                                     'Where句
    Private mFEQ_DSP_KUBUN As Nullable(Of Integer)                               '画面設備状態表示区分
    Private mFEQ_STS As String                                                   '設備状態
    Private mFEQ_CUT_STS As Nullable(Of Integer)                                 '切離状態
    Private mFSTS_NAME As String                                                 '状態名
    Private mFCOLOR_KUBUN As Nullable(Of Integer)                                '表示色
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                  "
    ''' <summary>
    ''' ｼｽﾃﾑ変数 (自ｸﾗｽ型配列)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_TDSP_EQ_STS()
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
    ''' 画面設備状態表示区分
    ''' </summary>
    Public Property FEQ_DSP_KUBUN() As Nullable(Of Integer)
        Get
            Return mFEQ_DSP_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFEQ_DSP_KUBUN = Value
        End Set
    End Property
    ''' <summary>
    ''' 設備状態
    ''' </summary>
    Public Property FEQ_STS() As String
        Get
            Return mFEQ_STS
        End Get
        Set(ByVal Value As String)
            mFEQ_STS = Value
        End Set
    End Property
    ''' <summary>
    ''' 切離状態
    ''' </summary>
    Public Property FEQ_CUT_STS() As Nullable(Of Integer)
        Get
            Return mFEQ_CUT_STS
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFEQ_CUT_STS = Value
        End Set
    End Property
    ''' <summary>
    ''' 状態名
    ''' </summary>
    Public Property FSTS_NAME() As String
        Get
            Return mFSTS_NAME
        End Get
        Set(ByVal Value As String)
            mFSTS_NAME = Value
        End Set
    End Property
    ''' <summary>
    ''' 表示色
    ''' </summary>
    Public Property FCOLOR_KUBUN() As Nullable(Of Integer)
        Get
            Return mFCOLOR_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFCOLOR_KUBUN = Value
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
    Public Function GET_TDSP_EQ_STS(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    TDSP_EQ_STS")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FEQ_DSP_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_DSP_KUBUN
            strSQL.Append(vbCrLf & "    AND FEQ_DSP_KUBUN = :" & UBound(strBindField) - 1 & " --画面設備状態表示区分")
        End If
        If IsNull(FEQ_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STS
            strSQL.Append(vbCrLf & "    AND FEQ_STS = :" & UBound(strBindField) - 1 & " --設備状態")
        End If
        If IsNull(FEQ_CUT_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_CUT_STS
            strSQL.Append(vbCrLf & "    AND FEQ_CUT_STS = :" & UBound(strBindField) - 1 & " --切離状態")
        End If
        If IsNull(FSTS_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSTS_NAME
            strSQL.Append(vbCrLf & "    AND FSTS_NAME = :" & UBound(strBindField) - 1 & " --状態名")
        End If
        If IsNull(FCOLOR_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOLOR_KUBUN
            strSQL.Append(vbCrLf & "    AND FCOLOR_KUBUN = :" & UBound(strBindField) - 1 & " --表示色")
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
        strDataSetName = "TDSP_EQ_STS"
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
    Public Function GET_TDSP_EQ_STS_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    TDSP_EQ_STS")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FEQ_DSP_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_DSP_KUBUN
            strSQL.Append(vbCrLf & "    AND FEQ_DSP_KUBUN = :" & UBound(strBindField) - 1 & " --画面設備状態表示区分")
        End If
        If IsNull(FEQ_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STS
            strSQL.Append(vbCrLf & "    AND FEQ_STS = :" & UBound(strBindField) - 1 & " --設備状態")
        End If
        If IsNull(FEQ_CUT_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_CUT_STS
            strSQL.Append(vbCrLf & "    AND FEQ_CUT_STS = :" & UBound(strBindField) - 1 & " --切離状態")
        End If
        If IsNull(FSTS_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSTS_NAME
            strSQL.Append(vbCrLf & "    AND FSTS_NAME = :" & UBound(strBindField) - 1 & " --状態名")
        End If
        If IsNull(FCOLOR_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOLOR_KUBUN
            strSQL.Append(vbCrLf & "    AND FCOLOR_KUBUN = :" & UBound(strBindField) - 1 & " --表示色")
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
        strDataSetName = "TDSP_EQ_STS"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TDSP_EQ_STS(Owner, objDb, objDbLog)
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
    Public Function GET_TDSP_EQ_STS_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "TDSP_EQ_STS"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TDSP_EQ_STS(Owner, objDb, objDbLog)
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
    Public Function GET_TDSP_EQ_STS_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    TDSP_EQ_STS")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FEQ_DSP_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_DSP_KUBUN
            strSQL.Append(vbCrLf & "    AND FEQ_DSP_KUBUN = :" & UBound(strBindField) - 1 & " --画面設備状態表示区分")
        End If
        If IsNull(FEQ_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STS
            strSQL.Append(vbCrLf & "    AND FEQ_STS = :" & UBound(strBindField) - 1 & " --設備状態")
        End If
        If IsNull(FEQ_CUT_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_CUT_STS
            strSQL.Append(vbCrLf & "    AND FEQ_CUT_STS = :" & UBound(strBindField) - 1 & " --切離状態")
        End If
        If IsNull(FSTS_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSTS_NAME
            strSQL.Append(vbCrLf & "    AND FSTS_NAME = :" & UBound(strBindField) - 1 & " --状態名")
        End If
        If IsNull(FCOLOR_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOLOR_KUBUN
            strSQL.Append(vbCrLf & "    AND FCOLOR_KUBUN = :" & UBound(strBindField) - 1 & " --表示色")
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
        strDataSetName = "TDSP_EQ_STS"
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
    Public Sub UPDATE_TDSP_EQ_STS()
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
        ElseIf IsNull(mFEQ_DSP_KUBUN) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[画面設備状態表示区分]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFEQ_STS) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[設備状態]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFEQ_CUT_STS) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[切離状態]"
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
        strSQL.Append(vbCrLf & "    TDSP_EQ_STS")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
        If IsNull(mFEQ_DSP_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_DSP_KUBUN = NULL --画面設備状態表示区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_DSP_KUBUN = NULL --画面設備状態表示区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_DSP_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_DSP_KUBUN = :" & Ubound(strBindField) - 1 & " --画面設備状態表示区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_DSP_KUBUN = :" & Ubound(strBindField) - 1 & " --画面設備状態表示区分")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_STS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_STS = NULL --設備状態")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_STS = NULL --設備状態")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_STS = :" & Ubound(strBindField) - 1 & " --設備状態")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_STS = :" & Ubound(strBindField) - 1 & " --設備状態")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_CUT_STS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_CUT_STS = NULL --切離状態")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_CUT_STS = NULL --切離状態")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_CUT_STS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_CUT_STS = :" & Ubound(strBindField) - 1 & " --切離状態")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_CUT_STS = :" & Ubound(strBindField) - 1 & " --切離状態")
        End If
        intCount = intCount + 1
        If IsNull(mFSTS_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSTS_NAME = NULL --状態名")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSTS_NAME = NULL --状態名")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSTS_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSTS_NAME = :" & Ubound(strBindField) - 1 & " --状態名")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSTS_NAME = :" & Ubound(strBindField) - 1 & " --状態名")
        End If
        intCount = intCount + 1
        If IsNull(mFCOLOR_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCOLOR_KUBUN = NULL --表示色")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCOLOR_KUBUN = NULL --表示色")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOLOR_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCOLOR_KUBUN = :" & Ubound(strBindField) - 1 & " --表示色")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCOLOR_KUBUN = :" & Ubound(strBindField) - 1 & " --表示色")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FEQ_DSP_KUBUN) = True Then
            strSQL.Append(vbCrLf & "    AND FEQ_DSP_KUBUN IS NULL --画面設備状態表示区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_DSP_KUBUN
            strSQL.Append(vbCrLf & "    AND FEQ_DSP_KUBUN = :" & UBound(strBindField) - 1 & " --画面設備状態表示区分")
        End If
        If IsNull(FEQ_STS) = True Then
            strSQL.Append(vbCrLf & "    AND FEQ_STS IS NULL --設備状態")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STS
            strSQL.Append(vbCrLf & "    AND FEQ_STS = :" & UBound(strBindField) - 1 & " --設備状態")
        End If
        If IsNull(FEQ_CUT_STS) = True Then
            strSQL.Append(vbCrLf & "    AND FEQ_CUT_STS IS NULL --切離状態")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_CUT_STS
            strSQL.Append(vbCrLf & "    AND FEQ_CUT_STS = :" & UBound(strBindField) - 1 & " --切離状態")
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
    Public Sub ADD_TDSP_EQ_STS()
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
        ElseIf IsNull(mFEQ_DSP_KUBUN) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[画面設備状態表示区分]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFEQ_STS) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[設備状態]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFEQ_CUT_STS) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[切離状態]"
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
        strSQL.Append(vbCrLf & "    TDSP_EQ_STS")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
        If IsNull(mFEQ_DSP_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --画面設備状態表示区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --画面設備状態表示区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_DSP_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --画面設備状態表示区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --画面設備状態表示区分")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_STS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --設備状態")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --設備状態")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --設備状態")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --設備状態")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_CUT_STS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --切離状態")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --切離状態")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_CUT_STS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --切離状態")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --切離状態")
        End If
        intCount = intCount + 1
        If IsNull(mFSTS_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --状態名")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --状態名")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSTS_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --状態名")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --状態名")
        End If
        intCount = intCount + 1
        If IsNull(mFCOLOR_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --表示色")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --表示色")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOLOR_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --表示色")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --表示色")
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
    Public Sub DELETE_TDSP_EQ_STS()
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
        ElseIf IsNull(mFEQ_DSP_KUBUN) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[画面設備状態表示区分]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFEQ_STS) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[設備状態]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFEQ_CUT_STS) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[切離状態]"
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
        strSQL.Append(vbCrLf & "    TDSP_EQ_STS")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FEQ_DSP_KUBUN) = True Then
            strSQL.Append(vbCrLf & "    AND FEQ_DSP_KUBUN IS NULL --画面設備状態表示区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_DSP_KUBUN
            strSQL.Append(vbCrLf & "    AND FEQ_DSP_KUBUN = :" & UBound(strBindField) - 1 & " --画面設備状態表示区分")
        End If
        If IsNull(FEQ_STS) = True Then
            strSQL.Append(vbCrLf & "    AND FEQ_STS IS NULL --設備状態")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STS
            strSQL.Append(vbCrLf & "    AND FEQ_STS = :" & UBound(strBindField) - 1 & " --設備状態")
        End If
        If IsNull(FEQ_CUT_STS) = True Then
            strSQL.Append(vbCrLf & "    AND FEQ_CUT_STS IS NULL --切離状態")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_CUT_STS
            strSQL.Append(vbCrLf & "    AND FEQ_CUT_STS = :" & UBound(strBindField) - 1 & " --切離状態")
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
    Public Sub DELETE_TDSP_EQ_STS_ANY()
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
        strSQL.Append(vbCrLf & "    TDSP_EQ_STS")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(FEQ_DSP_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_DSP_KUBUN
            strSQL.Append(vbCrLf & "    AND FEQ_DSP_KUBUN = :" & UBound(strBindField) - 1 & " --画面設備状態表示区分")
        End If
        If IsNotNull(FEQ_STS) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STS
            strSQL.Append(vbCrLf & "    AND FEQ_STS = :" & UBound(strBindField) - 1 & " --設備状態")
        End If
        If IsNotNull(FEQ_CUT_STS) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_CUT_STS
            strSQL.Append(vbCrLf & "    AND FEQ_CUT_STS = :" & UBound(strBindField) - 1 & " --切離状態")
        End If
        If IsNotNull(FSTS_NAME) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSTS_NAME
            strSQL.Append(vbCrLf & "    AND FSTS_NAME = :" & UBound(strBindField) - 1 & " --状態名")
        End If
        If IsNotNull(FCOLOR_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOLOR_KUBUN
            strSQL.Append(vbCrLf & "    AND FCOLOR_KUBUN = :" & UBound(strBindField) - 1 & " --表示色")
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
        If IsNothing(objType.GetProperty("FEQ_DSP_KUBUN")) = False Then mFEQ_DSP_KUBUN = objObject.FEQ_DSP_KUBUN '画面設備状態表示区分
        If IsNothing(objType.GetProperty("FEQ_STS")) = False Then mFEQ_STS = objObject.FEQ_STS '設備状態
        If IsNothing(objType.GetProperty("FEQ_CUT_STS")) = False Then mFEQ_CUT_STS = objObject.FEQ_CUT_STS '切離状態
        If IsNothing(objType.GetProperty("FSTS_NAME")) = False Then mFSTS_NAME = objObject.FSTS_NAME '状態名
        If IsNothing(objType.GetProperty("FCOLOR_KUBUN")) = False Then mFCOLOR_KUBUN = objObject.FCOLOR_KUBUN '表示色

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
        mFEQ_DSP_KUBUN = Nothing
        mFEQ_STS = Nothing
        mFEQ_CUT_STS = Nothing
        mFSTS_NAME = Nothing
        mFCOLOR_KUBUN = Nothing


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
        mFEQ_DSP_KUBUN = TO_INTEGER_NULLABLE(objRow("FEQ_DSP_KUBUN"))
        mFEQ_STS = TO_STRING_NULLABLE(objRow("FEQ_STS"))
        mFEQ_CUT_STS = TO_INTEGER_NULLABLE(objRow("FEQ_CUT_STS"))
        mFSTS_NAME = TO_STRING_NULLABLE(objRow("FSTS_NAME"))
        mFCOLOR_KUBUN = TO_INTEGER_NULLABLE(objRow("FCOLOR_KUBUN"))


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
        strMsg &= "[ﾃｰﾌﾞﾙ名:画面設備状態表示ﾏｽﾀ]"
        If IsNotNull(FEQ_DSP_KUBUN) Then
            strMsg &= "[画面設備状態表示区分:" & FEQ_DSP_KUBUN & "]"
        End If
        If IsNotNull(FEQ_STS) Then
            strMsg &= "[設備状態:" & FEQ_STS & "]"
        End If
        If IsNotNull(FEQ_CUT_STS) Then
            strMsg &= "[切離状態:" & FEQ_CUT_STS & "]"
        End If
        If IsNotNull(FSTS_NAME) Then
            strMsg &= "[状態名:" & FSTS_NAME & "]"
        End If
        If IsNotNull(FCOLOR_KUBUN) Then
            strMsg &= "[表示色:" & FCOLOR_KUBUN & "]"
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
