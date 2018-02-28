'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' 【名称】MaterialStreamﾃｰﾌﾞﾙｸﾗｽ
' 【機能】画面ｺﾝﾄﾛｰﾙﾏｽﾀﾃｰﾌﾞﾙｸﾗｽ
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
''' 画面ｺﾝﾄﾛｰﾙﾏｽﾀﾃｰﾌﾞﾙｸﾗｽ
''' </summary>
Public Class TBL_TDSP_CTRL
    Inherits clsTemplateTable

    '**********************************************************************************************
    '↓↓↓自動生成部
#Region "  ｸﾗｽ変数定義                  "
    'ﾌﾟﾛﾊﾟﾃｨ
    Private mobjAryMe As TBL_TDSP_CTRL()                                         '画面ｺﾝﾄﾛｰﾙﾏｽﾀ
    Private mstrUSER_SQL As String                                               'ﾕｰｻﾞｰSQL
    Private mORDER_BY As String                                                  'OrderBy句
    Private mWHERE As String                                                     'Where句
    Private mFDISP_ID As String                                                  '画面ID
    Private mFCTRL_ID As String                                                  'ｺﾝﾄﾛｰﾙID
    Private mFCTRL_ORDER As Nullable(Of Integer)                                 'ｺﾝﾄﾛｰﾙ順番
    Private mFCTRL_VALUE As String                                               'ｺﾝﾄﾛｰﾙ設定値
    Private mFTABLE_NAME As String                                               'ﾃｰﾌﾞﾙ名
    Private mFFIELD_NAME As String                                               'ﾌｨｰﾙﾄﾞ名
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                  "
    ''' <summary>
    ''' ｼｽﾃﾑ変数 (自ｸﾗｽ型配列)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_TDSP_CTRL()
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
    ''' ｺﾝﾄﾛｰﾙ順番
    ''' </summary>
    Public Property FCTRL_ORDER() As Nullable(Of Integer)
        Get
            Return mFCTRL_ORDER
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFCTRL_ORDER = Value
        End Set
    End Property
    ''' <summary>
    ''' ｺﾝﾄﾛｰﾙ設定値
    ''' </summary>
    Public Property FCTRL_VALUE() As String
        Get
            Return mFCTRL_VALUE
        End Get
        Set(ByVal Value As String)
            mFCTRL_VALUE = Value
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
    Public Function GET_TDSP_CTRL(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    TDSP_CTRL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
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
        If IsNull(FCTRL_ORDER) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCTRL_ORDER
            strSQL.Append(vbCrLf & "    AND FCTRL_ORDER = :" & UBound(strBindField) - 1 & " --ｺﾝﾄﾛｰﾙ順番")
        End If
        If IsNull(FCTRL_VALUE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCTRL_VALUE
            strSQL.Append(vbCrLf & "    AND FCTRL_VALUE = :" & UBound(strBindField) - 1 & " --ｺﾝﾄﾛｰﾙ設定値")
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
        strDataSetName = "TDSP_CTRL"
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
    Public Function GET_TDSP_CTRL_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    TDSP_CTRL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
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
        If IsNull(FCTRL_ORDER) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCTRL_ORDER
            strSQL.Append(vbCrLf & "    AND FCTRL_ORDER = :" & UBound(strBindField) - 1 & " --ｺﾝﾄﾛｰﾙ順番")
        End If
        If IsNull(FCTRL_VALUE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCTRL_VALUE
            strSQL.Append(vbCrLf & "    AND FCTRL_VALUE = :" & UBound(strBindField) - 1 & " --ｺﾝﾄﾛｰﾙ設定値")
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
        strDataSetName = "TDSP_CTRL"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TDSP_CTRL(Owner, objDb, objDbLog)
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
    Public Function GET_TDSP_CTRL_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "TDSP_CTRL"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TDSP_CTRL(Owner, objDb, objDbLog)
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
    Public Function GET_TDSP_CTRL_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    TDSP_CTRL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
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
        If IsNull(FCTRL_ORDER) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCTRL_ORDER
            strSQL.Append(vbCrLf & "    AND FCTRL_ORDER = :" & UBound(strBindField) - 1 & " --ｺﾝﾄﾛｰﾙ順番")
        End If
        If IsNull(FCTRL_VALUE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCTRL_VALUE
            strSQL.Append(vbCrLf & "    AND FCTRL_VALUE = :" & UBound(strBindField) - 1 & " --ｺﾝﾄﾛｰﾙ設定値")
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
        strDataSetName = "TDSP_CTRL"
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
    Public Sub UPDATE_TDSP_CTRL()
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
        ElseIf IsNull(mFDISP_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[画面ID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFCTRL_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ｺﾝﾄﾛｰﾙID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFCTRL_ORDER) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ｺﾝﾄﾛｰﾙ順番]"
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
        strSQL.Append(vbCrLf & "    TDSP_CTRL")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
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
        If IsNull(mFCTRL_ORDER) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCTRL_ORDER = NULL --ｺﾝﾄﾛｰﾙ順番")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCTRL_ORDER = NULL --ｺﾝﾄﾛｰﾙ順番")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCTRL_ORDER
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCTRL_ORDER = :" & Ubound(strBindField) - 1 & " --ｺﾝﾄﾛｰﾙ順番")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCTRL_ORDER = :" & Ubound(strBindField) - 1 & " --ｺﾝﾄﾛｰﾙ順番")
        End If
        intCount = intCount + 1
        If IsNull(mFCTRL_VALUE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCTRL_VALUE = NULL --ｺﾝﾄﾛｰﾙ設定値")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCTRL_VALUE = NULL --ｺﾝﾄﾛｰﾙ設定値")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCTRL_VALUE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCTRL_VALUE = :" & Ubound(strBindField) - 1 & " --ｺﾝﾄﾛｰﾙ設定値")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCTRL_VALUE = :" & Ubound(strBindField) - 1 & " --ｺﾝﾄﾛｰﾙ設定値")
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
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
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
        If IsNull(FCTRL_ORDER) = True Then
            strSQL.Append(vbCrLf & "    AND FCTRL_ORDER IS NULL --ｺﾝﾄﾛｰﾙ順番")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCTRL_ORDER
            strSQL.Append(vbCrLf & "    AND FCTRL_ORDER = :" & UBound(strBindField) - 1 & " --ｺﾝﾄﾛｰﾙ順番")
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
    Public Sub ADD_TDSP_CTRL()
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
        ElseIf IsNull(mFDISP_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[画面ID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFCTRL_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ｺﾝﾄﾛｰﾙID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFCTRL_ORDER) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ｺﾝﾄﾛｰﾙ順番]"
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
        strSQL.Append(vbCrLf & "    TDSP_CTRL")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
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
        If IsNull(mFCTRL_ORDER) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｺﾝﾄﾛｰﾙ順番")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｺﾝﾄﾛｰﾙ順番")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCTRL_ORDER
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｺﾝﾄﾛｰﾙ順番")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｺﾝﾄﾛｰﾙ順番")
        End If
        intCount = intCount + 1
        If IsNull(mFCTRL_VALUE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｺﾝﾄﾛｰﾙ設定値")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｺﾝﾄﾛｰﾙ設定値")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCTRL_VALUE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｺﾝﾄﾛｰﾙ設定値")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｺﾝﾄﾛｰﾙ設定値")
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
    Public Sub DELETE_TDSP_CTRL()
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
        ElseIf IsNull(mFDISP_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[画面ID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFCTRL_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ｺﾝﾄﾛｰﾙID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFCTRL_ORDER) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ｺﾝﾄﾛｰﾙ順番]"
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
        strSQL.Append(vbCrLf & "    TDSP_CTRL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
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
        If IsNull(FCTRL_ORDER) = True Then
            strSQL.Append(vbCrLf & "    AND FCTRL_ORDER IS NULL --ｺﾝﾄﾛｰﾙ順番")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCTRL_ORDER
            strSQL.Append(vbCrLf & "    AND FCTRL_ORDER = :" & UBound(strBindField) - 1 & " --ｺﾝﾄﾛｰﾙ順番")
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
    Public Sub DELETE_TDSP_CTRL_ANY()
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
        strSQL.Append(vbCrLf & "    TDSP_CTRL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
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
        If IsNotNull(FCTRL_ORDER) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCTRL_ORDER
            strSQL.Append(vbCrLf & "    AND FCTRL_ORDER = :" & UBound(strBindField) - 1 & " --ｺﾝﾄﾛｰﾙ順番")
        End If
        If IsNotNull(FCTRL_VALUE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCTRL_VALUE
            strSQL.Append(vbCrLf & "    AND FCTRL_VALUE = :" & UBound(strBindField) - 1 & " --ｺﾝﾄﾛｰﾙ設定値")
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
        If IsNothing(objType.GetProperty("FDISP_ID")) = False Then mFDISP_ID = objObject.FDISP_ID '画面ID
        If IsNothing(objType.GetProperty("FCTRL_ID")) = False Then mFCTRL_ID = objObject.FCTRL_ID 'ｺﾝﾄﾛｰﾙID
        If IsNothing(objType.GetProperty("FCTRL_ORDER")) = False Then mFCTRL_ORDER = objObject.FCTRL_ORDER 'ｺﾝﾄﾛｰﾙ順番
        If IsNothing(objType.GetProperty("FCTRL_VALUE")) = False Then mFCTRL_VALUE = objObject.FCTRL_VALUE 'ｺﾝﾄﾛｰﾙ設定値
        If IsNothing(objType.GetProperty("FTABLE_NAME")) = False Then mFTABLE_NAME = objObject.FTABLE_NAME 'ﾃｰﾌﾞﾙ名
        If IsNothing(objType.GetProperty("FFIELD_NAME")) = False Then mFFIELD_NAME = objObject.FFIELD_NAME 'ﾌｨｰﾙﾄﾞ名

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
        mFDISP_ID = Nothing
        mFCTRL_ID = Nothing
        mFCTRL_ORDER = Nothing
        mFCTRL_VALUE = Nothing
        mFTABLE_NAME = Nothing
        mFFIELD_NAME = Nothing


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
        mFDISP_ID = TO_STRING_NULLABLE(objRow("FDISP_ID"))
        mFCTRL_ID = TO_STRING_NULLABLE(objRow("FCTRL_ID"))
        mFCTRL_ORDER = TO_INTEGER_NULLABLE(objRow("FCTRL_ORDER"))
        mFCTRL_VALUE = TO_STRING_NULLABLE(objRow("FCTRL_VALUE"))
        mFTABLE_NAME = TO_STRING_NULLABLE(objRow("FTABLE_NAME"))
        mFFIELD_NAME = TO_STRING_NULLABLE(objRow("FFIELD_NAME"))


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
        strMsg &= "[ﾃｰﾌﾞﾙ名:画面ｺﾝﾄﾛｰﾙﾏｽﾀ]"
        If IsNotNull(FDISP_ID) Then
            strMsg &= "[画面ID:" & FDISP_ID & "]"
        End If
        If IsNotNull(FCTRL_ID) Then
            strMsg &= "[ｺﾝﾄﾛｰﾙID:" & FCTRL_ID & "]"
        End If
        If IsNotNull(FCTRL_ORDER) Then
            strMsg &= "[ｺﾝﾄﾛｰﾙ順番:" & FCTRL_ORDER & "]"
        End If
        If IsNotNull(FCTRL_VALUE) Then
            strMsg &= "[ｺﾝﾄﾛｰﾙ設定値:" & FCTRL_VALUE & "]"
        End If
        If IsNotNull(FTABLE_NAME) Then
            strMsg &= "[ﾃｰﾌﾞﾙ名:" & FTABLE_NAME & "]"
        End If
        If IsNotNull(FFIELD_NAME) Then
            strMsg &= "[ﾌｨｰﾙﾄﾞ名:" & FFIELD_NAME & "]"
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
