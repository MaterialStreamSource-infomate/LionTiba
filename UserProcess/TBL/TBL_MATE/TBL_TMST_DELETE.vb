'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' 【名称】MaterialStreamﾃｰﾌﾞﾙｸﾗｽ
' 【機能】ﾃﾞｰﾀ削除ﾏｽﾀﾃｰﾌﾞﾙｸﾗｽ
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
''' ﾃﾞｰﾀ削除ﾏｽﾀﾃｰﾌﾞﾙｸﾗｽ
''' </summary>
Public Class TBL_TMST_DELETE
    Inherits clsTemplateTable

    '**********************************************************************************************
    '↓↓↓自動生成部
#Region "  ｸﾗｽ変数定義                  "
    'ﾌﾟﾛﾊﾟﾃｨ
    Private mobjAryMe As TBL_TMST_DELETE()                                       'ﾃﾞｰﾀ削除ﾏｽﾀ
    Private mstrUSER_SQL As String                                               'ﾕｰｻﾞｰSQL
    Private mORDER_BY As String                                                  'OrderBy句
    Private mWHERE As String                                                     'Where句
    Private mFTABLE_NAME As String                                               'ﾃｰﾌﾞﾙ名
    Private mFTABLE_AREA As Nullable(Of Integer)                                 '表領域
    Private mFCONDITION_SERIAL As Nullable(Of Integer)                           '条件連番
    Private mFDELETE_KUBUN As Nullable(Of Integer)                               '削除区分
    Private mFDELETE_UNIT As String                                              '定期削除単位
    Private mFDELETE_FIELD As String                                             '削除条件ﾌｨｰﾙﾄﾞ
    Private mFDELETE_VALUE As Nullable(Of Integer)                               '削除条件値
    Private mFDELETE_KUBUN02 As Nullable(Of Integer)                             '削除区分02
    Private mFDELETE_FIELD02 As String                                           '削除条件ﾌｨｰﾙﾄﾞ02
    Private mFDELETE_VALUE02 As Nullable(Of Integer)                             '削除条件値02
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                  "
    ''' <summary>
    ''' ｼｽﾃﾑ変数 (自ｸﾗｽ型配列)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_TMST_DELETE()
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
    ''' 表領域
    ''' </summary>
    Public Property FTABLE_AREA() As Nullable(Of Integer)
        Get
            Return mFTABLE_AREA
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFTABLE_AREA = Value
        End Set
    End Property
    ''' <summary>
    ''' 条件連番
    ''' </summary>
    Public Property FCONDITION_SERIAL() As Nullable(Of Integer)
        Get
            Return mFCONDITION_SERIAL
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFCONDITION_SERIAL = Value
        End Set
    End Property
    ''' <summary>
    ''' 削除区分
    ''' </summary>
    Public Property FDELETE_KUBUN() As Nullable(Of Integer)
        Get
            Return mFDELETE_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFDELETE_KUBUN = Value
        End Set
    End Property
    ''' <summary>
    ''' 定期削除単位
    ''' </summary>
    Public Property FDELETE_UNIT() As String
        Get
            Return mFDELETE_UNIT
        End Get
        Set(ByVal Value As String)
            mFDELETE_UNIT = Value
        End Set
    End Property
    ''' <summary>
    ''' 削除条件ﾌｨｰﾙﾄﾞ
    ''' </summary>
    Public Property FDELETE_FIELD() As String
        Get
            Return mFDELETE_FIELD
        End Get
        Set(ByVal Value As String)
            mFDELETE_FIELD = Value
        End Set
    End Property
    ''' <summary>
    ''' 削除条件値
    ''' </summary>
    Public Property FDELETE_VALUE() As Nullable(Of Integer)
        Get
            Return mFDELETE_VALUE
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFDELETE_VALUE = Value
        End Set
    End Property
    ''' <summary>
    ''' 削除区分02
    ''' </summary>
    Public Property FDELETE_KUBUN02() As Nullable(Of Integer)
        Get
            Return mFDELETE_KUBUN02
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFDELETE_KUBUN02 = Value
        End Set
    End Property
    ''' <summary>
    ''' 削除条件ﾌｨｰﾙﾄﾞ02
    ''' </summary>
    Public Property FDELETE_FIELD02() As String
        Get
            Return mFDELETE_FIELD02
        End Get
        Set(ByVal Value As String)
            mFDELETE_FIELD02 = Value
        End Set
    End Property
    ''' <summary>
    ''' 削除条件値02
    ''' </summary>
    Public Property FDELETE_VALUE02() As Nullable(Of Integer)
        Get
            Return mFDELETE_VALUE02
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFDELETE_VALUE02 = Value
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
    Public Function GET_TMST_DELETE(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    TMST_DELETE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FTABLE_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTABLE_NAME
            strSQL.Append(vbCrLf & "    AND FTABLE_NAME = :" & UBound(strBindField) - 1 & " --ﾃｰﾌﾞﾙ名")
        End If
        If IsNull(FTABLE_AREA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTABLE_AREA
            strSQL.Append(vbCrLf & "    AND FTABLE_AREA = :" & UBound(strBindField) - 1 & " --表領域")
        End If
        If IsNull(FCONDITION_SERIAL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCONDITION_SERIAL
            strSQL.Append(vbCrLf & "    AND FCONDITION_SERIAL = :" & UBound(strBindField) - 1 & " --条件連番")
        End If
        If IsNull(FDELETE_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_KUBUN
            strSQL.Append(vbCrLf & "    AND FDELETE_KUBUN = :" & UBound(strBindField) - 1 & " --削除区分")
        End If
        If IsNull(FDELETE_UNIT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_UNIT
            strSQL.Append(vbCrLf & "    AND FDELETE_UNIT = :" & UBound(strBindField) - 1 & " --定期削除単位")
        End If
        If IsNull(FDELETE_FIELD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_FIELD
            strSQL.Append(vbCrLf & "    AND FDELETE_FIELD = :" & UBound(strBindField) - 1 & " --削除条件ﾌｨｰﾙﾄﾞ")
        End If
        If IsNull(FDELETE_VALUE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_VALUE
            strSQL.Append(vbCrLf & "    AND FDELETE_VALUE = :" & UBound(strBindField) - 1 & " --削除条件値")
        End If
        If IsNull(FDELETE_KUBUN02) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_KUBUN02
            strSQL.Append(vbCrLf & "    AND FDELETE_KUBUN02 = :" & UBound(strBindField) - 1 & " --削除区分02")
        End If
        If IsNull(FDELETE_FIELD02) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_FIELD02
            strSQL.Append(vbCrLf & "    AND FDELETE_FIELD02 = :" & UBound(strBindField) - 1 & " --削除条件ﾌｨｰﾙﾄﾞ02")
        End If
        If IsNull(FDELETE_VALUE02) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_VALUE02
            strSQL.Append(vbCrLf & "    AND FDELETE_VALUE02 = :" & UBound(strBindField) - 1 & " --削除条件値02")
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
        strDataSetName = "TMST_DELETE"
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
    Public Function GET_TMST_DELETE_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    TMST_DELETE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FTABLE_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTABLE_NAME
            strSQL.Append(vbCrLf & "    AND FTABLE_NAME = :" & UBound(strBindField) - 1 & " --ﾃｰﾌﾞﾙ名")
        End If
        If IsNull(FTABLE_AREA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTABLE_AREA
            strSQL.Append(vbCrLf & "    AND FTABLE_AREA = :" & UBound(strBindField) - 1 & " --表領域")
        End If
        If IsNull(FCONDITION_SERIAL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCONDITION_SERIAL
            strSQL.Append(vbCrLf & "    AND FCONDITION_SERIAL = :" & UBound(strBindField) - 1 & " --条件連番")
        End If
        If IsNull(FDELETE_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_KUBUN
            strSQL.Append(vbCrLf & "    AND FDELETE_KUBUN = :" & UBound(strBindField) - 1 & " --削除区分")
        End If
        If IsNull(FDELETE_UNIT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_UNIT
            strSQL.Append(vbCrLf & "    AND FDELETE_UNIT = :" & UBound(strBindField) - 1 & " --定期削除単位")
        End If
        If IsNull(FDELETE_FIELD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_FIELD
            strSQL.Append(vbCrLf & "    AND FDELETE_FIELD = :" & UBound(strBindField) - 1 & " --削除条件ﾌｨｰﾙﾄﾞ")
        End If
        If IsNull(FDELETE_VALUE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_VALUE
            strSQL.Append(vbCrLf & "    AND FDELETE_VALUE = :" & UBound(strBindField) - 1 & " --削除条件値")
        End If
        If IsNull(FDELETE_KUBUN02) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_KUBUN02
            strSQL.Append(vbCrLf & "    AND FDELETE_KUBUN02 = :" & UBound(strBindField) - 1 & " --削除区分02")
        End If
        If IsNull(FDELETE_FIELD02) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_FIELD02
            strSQL.Append(vbCrLf & "    AND FDELETE_FIELD02 = :" & UBound(strBindField) - 1 & " --削除条件ﾌｨｰﾙﾄﾞ02")
        End If
        If IsNull(FDELETE_VALUE02) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_VALUE02
            strSQL.Append(vbCrLf & "    AND FDELETE_VALUE02 = :" & UBound(strBindField) - 1 & " --削除条件値02")
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
        strDataSetName = "TMST_DELETE"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TMST_DELETE(Owner, objDb, objDbLog)
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
    Public Function GET_TMST_DELETE_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "TMST_DELETE"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TMST_DELETE(Owner, objDb, objDbLog)
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
    Public Function GET_TMST_DELETE_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    TMST_DELETE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FTABLE_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTABLE_NAME
            strSQL.Append(vbCrLf & "    AND FTABLE_NAME = :" & UBound(strBindField) - 1 & " --ﾃｰﾌﾞﾙ名")
        End If
        If IsNull(FTABLE_AREA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTABLE_AREA
            strSQL.Append(vbCrLf & "    AND FTABLE_AREA = :" & UBound(strBindField) - 1 & " --表領域")
        End If
        If IsNull(FCONDITION_SERIAL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCONDITION_SERIAL
            strSQL.Append(vbCrLf & "    AND FCONDITION_SERIAL = :" & UBound(strBindField) - 1 & " --条件連番")
        End If
        If IsNull(FDELETE_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_KUBUN
            strSQL.Append(vbCrLf & "    AND FDELETE_KUBUN = :" & UBound(strBindField) - 1 & " --削除区分")
        End If
        If IsNull(FDELETE_UNIT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_UNIT
            strSQL.Append(vbCrLf & "    AND FDELETE_UNIT = :" & UBound(strBindField) - 1 & " --定期削除単位")
        End If
        If IsNull(FDELETE_FIELD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_FIELD
            strSQL.Append(vbCrLf & "    AND FDELETE_FIELD = :" & UBound(strBindField) - 1 & " --削除条件ﾌｨｰﾙﾄﾞ")
        End If
        If IsNull(FDELETE_VALUE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_VALUE
            strSQL.Append(vbCrLf & "    AND FDELETE_VALUE = :" & UBound(strBindField) - 1 & " --削除条件値")
        End If
        If IsNull(FDELETE_KUBUN02) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_KUBUN02
            strSQL.Append(vbCrLf & "    AND FDELETE_KUBUN02 = :" & UBound(strBindField) - 1 & " --削除区分02")
        End If
        If IsNull(FDELETE_FIELD02) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_FIELD02
            strSQL.Append(vbCrLf & "    AND FDELETE_FIELD02 = :" & UBound(strBindField) - 1 & " --削除条件ﾌｨｰﾙﾄﾞ02")
        End If
        If IsNull(FDELETE_VALUE02) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_VALUE02
            strSQL.Append(vbCrLf & "    AND FDELETE_VALUE02 = :" & UBound(strBindField) - 1 & " --削除条件値02")
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
        strDataSetName = "TMST_DELETE"
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
    Public Sub UPDATE_TMST_DELETE()
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
        ElseIf IsNull(mFTABLE_NAME) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾃｰﾌﾞﾙ名]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFTABLE_AREA) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[表領域]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFCONDITION_SERIAL) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[条件連番]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFDELETE_KUBUN) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[削除区分]"
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
        strSQL.Append(vbCrLf & "    TMST_DELETE")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
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
        If IsNull(mFTABLE_AREA) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTABLE_AREA = NULL --表領域")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTABLE_AREA = NULL --表領域")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTABLE_AREA
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTABLE_AREA = :" & Ubound(strBindField) - 1 & " --表領域")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTABLE_AREA = :" & Ubound(strBindField) - 1 & " --表領域")
        End If
        intCount = intCount + 1
        If IsNull(mFCONDITION_SERIAL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCONDITION_SERIAL = NULL --条件連番")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCONDITION_SERIAL = NULL --条件連番")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCONDITION_SERIAL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCONDITION_SERIAL = :" & Ubound(strBindField) - 1 & " --条件連番")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCONDITION_SERIAL = :" & Ubound(strBindField) - 1 & " --条件連番")
        End If
        intCount = intCount + 1
        If IsNull(mFDELETE_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDELETE_KUBUN = NULL --削除区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDELETE_KUBUN = NULL --削除区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDELETE_KUBUN = :" & Ubound(strBindField) - 1 & " --削除区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDELETE_KUBUN = :" & Ubound(strBindField) - 1 & " --削除区分")
        End If
        intCount = intCount + 1
        If IsNull(mFDELETE_UNIT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDELETE_UNIT = NULL --定期削除単位")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDELETE_UNIT = NULL --定期削除単位")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_UNIT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDELETE_UNIT = :" & Ubound(strBindField) - 1 & " --定期削除単位")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDELETE_UNIT = :" & Ubound(strBindField) - 1 & " --定期削除単位")
        End If
        intCount = intCount + 1
        If IsNull(mFDELETE_FIELD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDELETE_FIELD = NULL --削除条件ﾌｨｰﾙﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDELETE_FIELD = NULL --削除条件ﾌｨｰﾙﾄﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_FIELD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDELETE_FIELD = :" & Ubound(strBindField) - 1 & " --削除条件ﾌｨｰﾙﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDELETE_FIELD = :" & Ubound(strBindField) - 1 & " --削除条件ﾌｨｰﾙﾄﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFDELETE_VALUE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDELETE_VALUE = NULL --削除条件値")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDELETE_VALUE = NULL --削除条件値")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_VALUE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDELETE_VALUE = :" & Ubound(strBindField) - 1 & " --削除条件値")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDELETE_VALUE = :" & Ubound(strBindField) - 1 & " --削除条件値")
        End If
        intCount = intCount + 1
        If IsNull(mFDELETE_KUBUN02) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDELETE_KUBUN02 = NULL --削除区分02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDELETE_KUBUN02 = NULL --削除区分02")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_KUBUN02
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDELETE_KUBUN02 = :" & Ubound(strBindField) - 1 & " --削除区分02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDELETE_KUBUN02 = :" & Ubound(strBindField) - 1 & " --削除区分02")
        End If
        intCount = intCount + 1
        If IsNull(mFDELETE_FIELD02) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDELETE_FIELD02 = NULL --削除条件ﾌｨｰﾙﾄﾞ02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDELETE_FIELD02 = NULL --削除条件ﾌｨｰﾙﾄﾞ02")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_FIELD02
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDELETE_FIELD02 = :" & Ubound(strBindField) - 1 & " --削除条件ﾌｨｰﾙﾄﾞ02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDELETE_FIELD02 = :" & Ubound(strBindField) - 1 & " --削除条件ﾌｨｰﾙﾄﾞ02")
        End If
        intCount = intCount + 1
        If IsNull(mFDELETE_VALUE02) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDELETE_VALUE02 = NULL --削除条件値02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDELETE_VALUE02 = NULL --削除条件値02")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_VALUE02
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDELETE_VALUE02 = :" & Ubound(strBindField) - 1 & " --削除条件値02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDELETE_VALUE02 = :" & Ubound(strBindField) - 1 & " --削除条件値02")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FTABLE_NAME) = True Then
            strSQL.Append(vbCrLf & "    AND FTABLE_NAME IS NULL --ﾃｰﾌﾞﾙ名")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTABLE_NAME
            strSQL.Append(vbCrLf & "    AND FTABLE_NAME = :" & UBound(strBindField) - 1 & " --ﾃｰﾌﾞﾙ名")
        End If
        If IsNull(FTABLE_AREA) = True Then
            strSQL.Append(vbCrLf & "    AND FTABLE_AREA IS NULL --表領域")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTABLE_AREA
            strSQL.Append(vbCrLf & "    AND FTABLE_AREA = :" & UBound(strBindField) - 1 & " --表領域")
        End If
        If IsNull(FCONDITION_SERIAL) = True Then
            strSQL.Append(vbCrLf & "    AND FCONDITION_SERIAL IS NULL --条件連番")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCONDITION_SERIAL
            strSQL.Append(vbCrLf & "    AND FCONDITION_SERIAL = :" & UBound(strBindField) - 1 & " --条件連番")
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
    Public Sub ADD_TMST_DELETE()
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
        ElseIf IsNull(mFTABLE_NAME) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾃｰﾌﾞﾙ名]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFTABLE_AREA) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[表領域]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFCONDITION_SERIAL) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[条件連番]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFDELETE_KUBUN) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[削除区分]"
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
        strSQL.Append(vbCrLf & "    TMST_DELETE")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
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
        If IsNull(mFTABLE_AREA) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --表領域")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --表領域")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTABLE_AREA
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --表領域")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --表領域")
        End If
        intCount = intCount + 1
        If IsNull(mFCONDITION_SERIAL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --条件連番")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --条件連番")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCONDITION_SERIAL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --条件連番")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --条件連番")
        End If
        intCount = intCount + 1
        If IsNull(mFDELETE_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --削除区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --削除区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --削除区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --削除区分")
        End If
        intCount = intCount + 1
        If IsNull(mFDELETE_UNIT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --定期削除単位")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --定期削除単位")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_UNIT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --定期削除単位")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --定期削除単位")
        End If
        intCount = intCount + 1
        If IsNull(mFDELETE_FIELD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --削除条件ﾌｨｰﾙﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --削除条件ﾌｨｰﾙﾄﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_FIELD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --削除条件ﾌｨｰﾙﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --削除条件ﾌｨｰﾙﾄﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFDELETE_VALUE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --削除条件値")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --削除条件値")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_VALUE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --削除条件値")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --削除条件値")
        End If
        intCount = intCount + 1
        If IsNull(mFDELETE_KUBUN02) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --削除区分02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --削除区分02")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_KUBUN02
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --削除区分02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --削除区分02")
        End If
        intCount = intCount + 1
        If IsNull(mFDELETE_FIELD02) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --削除条件ﾌｨｰﾙﾄﾞ02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --削除条件ﾌｨｰﾙﾄﾞ02")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_FIELD02
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --削除条件ﾌｨｰﾙﾄﾞ02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --削除条件ﾌｨｰﾙﾄﾞ02")
        End If
        intCount = intCount + 1
        If IsNull(mFDELETE_VALUE02) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --削除条件値02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --削除条件値02")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_VALUE02
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --削除条件値02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --削除条件値02")
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
    Public Sub DELETE_TMST_DELETE()
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
        ElseIf IsNull(mFTABLE_NAME) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾃｰﾌﾞﾙ名]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFTABLE_AREA) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[表領域]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFCONDITION_SERIAL) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[条件連番]"
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
        strSQL.Append(vbCrLf & "    TMST_DELETE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FTABLE_NAME) = True Then
            strSQL.Append(vbCrLf & "    AND FTABLE_NAME IS NULL --ﾃｰﾌﾞﾙ名")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTABLE_NAME
            strSQL.Append(vbCrLf & "    AND FTABLE_NAME = :" & UBound(strBindField) - 1 & " --ﾃｰﾌﾞﾙ名")
        End If
        If IsNull(FTABLE_AREA) = True Then
            strSQL.Append(vbCrLf & "    AND FTABLE_AREA IS NULL --表領域")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTABLE_AREA
            strSQL.Append(vbCrLf & "    AND FTABLE_AREA = :" & UBound(strBindField) - 1 & " --表領域")
        End If
        If IsNull(FCONDITION_SERIAL) = True Then
            strSQL.Append(vbCrLf & "    AND FCONDITION_SERIAL IS NULL --条件連番")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCONDITION_SERIAL
            strSQL.Append(vbCrLf & "    AND FCONDITION_SERIAL = :" & UBound(strBindField) - 1 & " --条件連番")
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
    Public Sub DELETE_TMST_DELETE_ANY()
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
        strSQL.Append(vbCrLf & "    TMST_DELETE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(FTABLE_NAME) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTABLE_NAME
            strSQL.Append(vbCrLf & "    AND FTABLE_NAME = :" & UBound(strBindField) - 1 & " --ﾃｰﾌﾞﾙ名")
        End If
        If IsNotNull(FTABLE_AREA) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTABLE_AREA
            strSQL.Append(vbCrLf & "    AND FTABLE_AREA = :" & UBound(strBindField) - 1 & " --表領域")
        End If
        If IsNotNull(FCONDITION_SERIAL) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCONDITION_SERIAL
            strSQL.Append(vbCrLf & "    AND FCONDITION_SERIAL = :" & UBound(strBindField) - 1 & " --条件連番")
        End If
        If IsNotNull(FDELETE_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_KUBUN
            strSQL.Append(vbCrLf & "    AND FDELETE_KUBUN = :" & UBound(strBindField) - 1 & " --削除区分")
        End If
        If IsNotNull(FDELETE_UNIT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_UNIT
            strSQL.Append(vbCrLf & "    AND FDELETE_UNIT = :" & UBound(strBindField) - 1 & " --定期削除単位")
        End If
        If IsNotNull(FDELETE_FIELD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_FIELD
            strSQL.Append(vbCrLf & "    AND FDELETE_FIELD = :" & UBound(strBindField) - 1 & " --削除条件ﾌｨｰﾙﾄﾞ")
        End If
        If IsNotNull(FDELETE_VALUE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_VALUE
            strSQL.Append(vbCrLf & "    AND FDELETE_VALUE = :" & UBound(strBindField) - 1 & " --削除条件値")
        End If
        If IsNotNull(FDELETE_KUBUN02) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_KUBUN02
            strSQL.Append(vbCrLf & "    AND FDELETE_KUBUN02 = :" & UBound(strBindField) - 1 & " --削除区分02")
        End If
        If IsNotNull(FDELETE_FIELD02) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_FIELD02
            strSQL.Append(vbCrLf & "    AND FDELETE_FIELD02 = :" & UBound(strBindField) - 1 & " --削除条件ﾌｨｰﾙﾄﾞ02")
        End If
        If IsNotNull(FDELETE_VALUE02) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDELETE_VALUE02
            strSQL.Append(vbCrLf & "    AND FDELETE_VALUE02 = :" & UBound(strBindField) - 1 & " --削除条件値02")
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
        If IsNothing(objType.GetProperty("FTABLE_NAME")) = False Then mFTABLE_NAME = objObject.FTABLE_NAME 'ﾃｰﾌﾞﾙ名
        If IsNothing(objType.GetProperty("FTABLE_AREA")) = False Then mFTABLE_AREA = objObject.FTABLE_AREA '表領域
        If IsNothing(objType.GetProperty("FCONDITION_SERIAL")) = False Then mFCONDITION_SERIAL = objObject.FCONDITION_SERIAL '条件連番
        If IsNothing(objType.GetProperty("FDELETE_KUBUN")) = False Then mFDELETE_KUBUN = objObject.FDELETE_KUBUN '削除区分
        If IsNothing(objType.GetProperty("FDELETE_UNIT")) = False Then mFDELETE_UNIT = objObject.FDELETE_UNIT '定期削除単位
        If IsNothing(objType.GetProperty("FDELETE_FIELD")) = False Then mFDELETE_FIELD = objObject.FDELETE_FIELD '削除条件ﾌｨｰﾙﾄﾞ
        If IsNothing(objType.GetProperty("FDELETE_VALUE")) = False Then mFDELETE_VALUE = objObject.FDELETE_VALUE '削除条件値
        If IsNothing(objType.GetProperty("FDELETE_KUBUN02")) = False Then mFDELETE_KUBUN02 = objObject.FDELETE_KUBUN02 '削除区分02
        If IsNothing(objType.GetProperty("FDELETE_FIELD02")) = False Then mFDELETE_FIELD02 = objObject.FDELETE_FIELD02 '削除条件ﾌｨｰﾙﾄﾞ02
        If IsNothing(objType.GetProperty("FDELETE_VALUE02")) = False Then mFDELETE_VALUE02 = objObject.FDELETE_VALUE02 '削除条件値02

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
        mFTABLE_NAME = Nothing
        mFTABLE_AREA = Nothing
        mFCONDITION_SERIAL = Nothing
        mFDELETE_KUBUN = Nothing
        mFDELETE_UNIT = Nothing
        mFDELETE_FIELD = Nothing
        mFDELETE_VALUE = Nothing
        mFDELETE_KUBUN02 = Nothing
        mFDELETE_FIELD02 = Nothing
        mFDELETE_VALUE02 = Nothing


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
        mFTABLE_NAME = TO_STRING_NULLABLE(objRow("FTABLE_NAME"))
        mFTABLE_AREA = TO_INTEGER_NULLABLE(objRow("FTABLE_AREA"))
        mFCONDITION_SERIAL = TO_INTEGER_NULLABLE(objRow("FCONDITION_SERIAL"))
        mFDELETE_KUBUN = TO_INTEGER_NULLABLE(objRow("FDELETE_KUBUN"))
        mFDELETE_UNIT = TO_STRING_NULLABLE(objRow("FDELETE_UNIT"))
        mFDELETE_FIELD = TO_STRING_NULLABLE(objRow("FDELETE_FIELD"))
        mFDELETE_VALUE = TO_INTEGER_NULLABLE(objRow("FDELETE_VALUE"))
        mFDELETE_KUBUN02 = TO_INTEGER_NULLABLE(objRow("FDELETE_KUBUN02"))
        mFDELETE_FIELD02 = TO_STRING_NULLABLE(objRow("FDELETE_FIELD02"))
        mFDELETE_VALUE02 = TO_INTEGER_NULLABLE(objRow("FDELETE_VALUE02"))


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
        strMsg &= "[ﾃｰﾌﾞﾙ名:ﾃﾞｰﾀ削除ﾏｽﾀ]"
        If IsNotNull(FTABLE_NAME) Then
            strMsg &= "[ﾃｰﾌﾞﾙ名:" & FTABLE_NAME & "]"
        End If
        If IsNotNull(FTABLE_AREA) Then
            strMsg &= "[表領域:" & FTABLE_AREA & "]"
        End If
        If IsNotNull(FCONDITION_SERIAL) Then
            strMsg &= "[条件連番:" & FCONDITION_SERIAL & "]"
        End If
        If IsNotNull(FDELETE_KUBUN) Then
            strMsg &= "[削除区分:" & FDELETE_KUBUN & "]"
        End If
        If IsNotNull(FDELETE_UNIT) Then
            strMsg &= "[定期削除単位:" & FDELETE_UNIT & "]"
        End If
        If IsNotNull(FDELETE_FIELD) Then
            strMsg &= "[削除条件ﾌｨｰﾙﾄﾞ:" & FDELETE_FIELD & "]"
        End If
        If IsNotNull(FDELETE_VALUE) Then
            strMsg &= "[削除条件値:" & FDELETE_VALUE & "]"
        End If
        If IsNotNull(FDELETE_KUBUN02) Then
            strMsg &= "[削除区分02:" & FDELETE_KUBUN02 & "]"
        End If
        If IsNotNull(FDELETE_FIELD02) Then
            strMsg &= "[削除条件ﾌｨｰﾙﾄﾞ02:" & FDELETE_FIELD02 & "]"
        End If
        If IsNotNull(FDELETE_VALUE02) Then
            strMsg &= "[削除条件値02:" & FDELETE_VALUE02 & "]"
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
