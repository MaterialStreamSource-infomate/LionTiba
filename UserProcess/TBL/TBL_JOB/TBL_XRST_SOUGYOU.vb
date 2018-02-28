'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' 【名称】MaterialStreamﾃｰﾌﾞﾙｸﾗｽ
' 【機能】操業履歴ﾃｰﾌﾞﾙｸﾗｽ
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
''' 操業履歴ﾃｰﾌﾞﾙｸﾗｽ
''' </summary>
Public Class TBL_XRST_SOUGYOU
    Inherits clsTemplateTable

    '**********************************************************************************************
    '↓↓↓自動生成部
#Region "  ｸﾗｽ変数定義                  "
    'ﾌﾟﾛﾊﾟﾃｨ
    Private mobjAryMe As TBL_XRST_SOUGYOU()                                      '操業履歴
    Private mstrUSER_SQL As String                                               'ﾕｰｻﾞｰSQL
    Private mORDER_BY As String                                                  'OrderBy句
    Private mWHERE As String                                                     'Where句
    Private mXSOUGYOU_DT As Nullable(Of Date)                                    '操業日
    Private mXSTART_DT As Nullable(Of Date)                                      '開始日時
    Private mXEND_DT As Nullable(Of Date)                                        '終了日時
    Private mXSYUKKA_END_DT As Nullable(Of Date)                                 '出荷終了日時
    Private mXSYUKKO_END_DT As Nullable(Of Date)                                 '出庫終了日時
    Private mXDATA_TENSOU_DT As Nullable(Of Date)                                '翌日ﾃﾞｰﾀ転送
    Private mXTANA_BLOCK_AKI As Nullable(Of Integer)                             '空棚ﾌﾞﾛｯｸ数
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                  "
    ''' <summary>
    ''' ｼｽﾃﾑ変数 (自ｸﾗｽ型配列)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_XRST_SOUGYOU()
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
    ''' 操業日
    ''' </summary>
    Public Property XSOUGYOU_DT() As Nullable(Of Date)
        Get
            Return mXSOUGYOU_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mXSOUGYOU_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' 開始日時
    ''' </summary>
    Public Property XSTART_DT() As Nullable(Of Date)
        Get
            Return mXSTART_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mXSTART_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' 終了日時
    ''' </summary>
    Public Property XEND_DT() As Nullable(Of Date)
        Get
            Return mXEND_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mXEND_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' 出荷終了日時
    ''' </summary>
    Public Property XSYUKKA_END_DT() As Nullable(Of Date)
        Get
            Return mXSYUKKA_END_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mXSYUKKA_END_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' 出庫終了日時
    ''' </summary>
    Public Property XSYUKKO_END_DT() As Nullable(Of Date)
        Get
            Return mXSYUKKO_END_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mXSYUKKO_END_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' 翌日ﾃﾞｰﾀ転送
    ''' </summary>
    Public Property XDATA_TENSOU_DT() As Nullable(Of Date)
        Get
            Return mXDATA_TENSOU_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mXDATA_TENSOU_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' 空棚ﾌﾞﾛｯｸ数
    ''' </summary>
    Public Property XTANA_BLOCK_AKI() As Nullable(Of Integer)
        Get
            Return mXTANA_BLOCK_AKI
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXTANA_BLOCK_AKI = Value
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
    Public Function GET_XRST_SOUGYOU(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    XRST_SOUGYOU")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XSOUGYOU_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSOUGYOU_DT
            strSQL.Append(vbCrLf & "    AND XSOUGYOU_DT = :" & UBound(strBindField) - 1 & " --操業日")
        End If
        If IsNull(XSTART_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSTART_DT
            strSQL.Append(vbCrLf & "    AND XSTART_DT = :" & UBound(strBindField) - 1 & " --開始日時")
        End If
        If IsNull(XEND_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEND_DT
            strSQL.Append(vbCrLf & "    AND XEND_DT = :" & UBound(strBindField) - 1 & " --終了日時")
        End If
        If IsNull(XSYUKKA_END_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_END_DT
            strSQL.Append(vbCrLf & "    AND XSYUKKA_END_DT = :" & UBound(strBindField) - 1 & " --出荷終了日時")
        End If
        If IsNull(XSYUKKO_END_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKO_END_DT
            strSQL.Append(vbCrLf & "    AND XSYUKKO_END_DT = :" & UBound(strBindField) - 1 & " --出庫終了日時")
        End If
        If IsNull(XDATA_TENSOU_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDATA_TENSOU_DT
            strSQL.Append(vbCrLf & "    AND XDATA_TENSOU_DT = :" & UBound(strBindField) - 1 & " --翌日ﾃﾞｰﾀ転送")
        End If
        If IsNull(XTANA_BLOCK_AKI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTANA_BLOCK_AKI
            strSQL.Append(vbCrLf & "    AND XTANA_BLOCK_AKI = :" & UBound(strBindField) - 1 & " --空棚ﾌﾞﾛｯｸ数")
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
        strDataSetName = "XRST_SOUGYOU"
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
    Public Function GET_XRST_SOUGYOU_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    XRST_SOUGYOU")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XSOUGYOU_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSOUGYOU_DT
            strSQL.Append(vbCrLf & "    AND XSOUGYOU_DT = :" & UBound(strBindField) - 1 & " --操業日")
        End If
        If IsNull(XSTART_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSTART_DT
            strSQL.Append(vbCrLf & "    AND XSTART_DT = :" & UBound(strBindField) - 1 & " --開始日時")
        End If
        If IsNull(XEND_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEND_DT
            strSQL.Append(vbCrLf & "    AND XEND_DT = :" & UBound(strBindField) - 1 & " --終了日時")
        End If
        If IsNull(XSYUKKA_END_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_END_DT
            strSQL.Append(vbCrLf & "    AND XSYUKKA_END_DT = :" & UBound(strBindField) - 1 & " --出荷終了日時")
        End If
        If IsNull(XSYUKKO_END_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKO_END_DT
            strSQL.Append(vbCrLf & "    AND XSYUKKO_END_DT = :" & UBound(strBindField) - 1 & " --出庫終了日時")
        End If
        If IsNull(XDATA_TENSOU_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDATA_TENSOU_DT
            strSQL.Append(vbCrLf & "    AND XDATA_TENSOU_DT = :" & UBound(strBindField) - 1 & " --翌日ﾃﾞｰﾀ転送")
        End If
        If IsNull(XTANA_BLOCK_AKI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTANA_BLOCK_AKI
            strSQL.Append(vbCrLf & "    AND XTANA_BLOCK_AKI = :" & UBound(strBindField) - 1 & " --空棚ﾌﾞﾛｯｸ数")
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
        strDataSetName = "XRST_SOUGYOU"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XRST_SOUGYOU(Owner, objDb, objDbLog)
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
    Public Function GET_XRST_SOUGYOU_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "XRST_SOUGYOU"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XRST_SOUGYOU(Owner, objDb, objDbLog)
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
    Public Function GET_XRST_SOUGYOU_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    XRST_SOUGYOU")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XSOUGYOU_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSOUGYOU_DT
            strSQL.Append(vbCrLf & "    AND XSOUGYOU_DT = :" & UBound(strBindField) - 1 & " --操業日")
        End If
        If IsNull(XSTART_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSTART_DT
            strSQL.Append(vbCrLf & "    AND XSTART_DT = :" & UBound(strBindField) - 1 & " --開始日時")
        End If
        If IsNull(XEND_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEND_DT
            strSQL.Append(vbCrLf & "    AND XEND_DT = :" & UBound(strBindField) - 1 & " --終了日時")
        End If
        If IsNull(XSYUKKA_END_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_END_DT
            strSQL.Append(vbCrLf & "    AND XSYUKKA_END_DT = :" & UBound(strBindField) - 1 & " --出荷終了日時")
        End If
        If IsNull(XSYUKKO_END_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKO_END_DT
            strSQL.Append(vbCrLf & "    AND XSYUKKO_END_DT = :" & UBound(strBindField) - 1 & " --出庫終了日時")
        End If
        If IsNull(XDATA_TENSOU_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDATA_TENSOU_DT
            strSQL.Append(vbCrLf & "    AND XDATA_TENSOU_DT = :" & UBound(strBindField) - 1 & " --翌日ﾃﾞｰﾀ転送")
        End If
        If IsNull(XTANA_BLOCK_AKI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTANA_BLOCK_AKI
            strSQL.Append(vbCrLf & "    AND XTANA_BLOCK_AKI = :" & UBound(strBindField) - 1 & " --空棚ﾌﾞﾛｯｸ数")
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
        strDataSetName = "XRST_SOUGYOU"
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
    Public Sub UPDATE_XRST_SOUGYOU()
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
        ElseIf IsNull(mXSOUGYOU_DT) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[操業日]"
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
        strSQL.Append(vbCrLf & "    XRST_SOUGYOU")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
        If IsNull(mXSOUGYOU_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSOUGYOU_DT = NULL --操業日")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSOUGYOU_DT = NULL --操業日")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSOUGYOU_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSOUGYOU_DT = :" & Ubound(strBindField) - 1 & " --操業日")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSOUGYOU_DT = :" & Ubound(strBindField) - 1 & " --操業日")
        End If
        intCount = intCount + 1
        If IsNull(mXSTART_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSTART_DT = NULL --開始日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSTART_DT = NULL --開始日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSTART_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSTART_DT = :" & Ubound(strBindField) - 1 & " --開始日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSTART_DT = :" & Ubound(strBindField) - 1 & " --開始日時")
        End If
        intCount = intCount + 1
        If IsNull(mXEND_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEND_DT = NULL --終了日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEND_DT = NULL --終了日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEND_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEND_DT = :" & Ubound(strBindField) - 1 & " --終了日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEND_DT = :" & Ubound(strBindField) - 1 & " --終了日時")
        End If
        intCount = intCount + 1
        If IsNull(mXSYUKKA_END_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_END_DT = NULL --出荷終了日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_END_DT = NULL --出荷終了日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_END_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_END_DT = :" & Ubound(strBindField) - 1 & " --出荷終了日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_END_DT = :" & Ubound(strBindField) - 1 & " --出荷終了日時")
        End If
        intCount = intCount + 1
        If IsNull(mXSYUKKO_END_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKO_END_DT = NULL --出庫終了日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKO_END_DT = NULL --出庫終了日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKO_END_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKO_END_DT = :" & Ubound(strBindField) - 1 & " --出庫終了日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKO_END_DT = :" & Ubound(strBindField) - 1 & " --出庫終了日時")
        End If
        intCount = intCount + 1
        If IsNull(mXDATA_TENSOU_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDATA_TENSOU_DT = NULL --翌日ﾃﾞｰﾀ転送")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDATA_TENSOU_DT = NULL --翌日ﾃﾞｰﾀ転送")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDATA_TENSOU_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDATA_TENSOU_DT = :" & Ubound(strBindField) - 1 & " --翌日ﾃﾞｰﾀ転送")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDATA_TENSOU_DT = :" & Ubound(strBindField) - 1 & " --翌日ﾃﾞｰﾀ転送")
        End If
        intCount = intCount + 1
        If IsNull(mXTANA_BLOCK_AKI) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTANA_BLOCK_AKI = NULL --空棚ﾌﾞﾛｯｸ数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTANA_BLOCK_AKI = NULL --空棚ﾌﾞﾛｯｸ数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTANA_BLOCK_AKI
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTANA_BLOCK_AKI = :" & Ubound(strBindField) - 1 & " --空棚ﾌﾞﾛｯｸ数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTANA_BLOCK_AKI = :" & Ubound(strBindField) - 1 & " --空棚ﾌﾞﾛｯｸ数")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(XSOUGYOU_DT) = True Then
            strSQL.Append(vbCrLf & "    AND XSOUGYOU_DT IS NULL --操業日")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSOUGYOU_DT
            strSQL.Append(vbCrLf & "    AND XSOUGYOU_DT = :" & UBound(strBindField) - 1 & " --操業日")
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
    Public Sub ADD_XRST_SOUGYOU()
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
        ElseIf IsNull(mXSOUGYOU_DT) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[操業日]"
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
        strSQL.Append(vbCrLf & "    XRST_SOUGYOU")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
        If IsNull(mXSOUGYOU_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --操業日")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --操業日")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSOUGYOU_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --操業日")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --操業日")
        End If
        intCount = intCount + 1
        If IsNull(mXSTART_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --開始日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --開始日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSTART_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --開始日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --開始日時")
        End If
        intCount = intCount + 1
        If IsNull(mXEND_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --終了日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --終了日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEND_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --終了日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --終了日時")
        End If
        intCount = intCount + 1
        If IsNull(mXSYUKKA_END_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --出荷終了日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --出荷終了日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_END_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --出荷終了日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --出荷終了日時")
        End If
        intCount = intCount + 1
        If IsNull(mXSYUKKO_END_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --出庫終了日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --出庫終了日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKO_END_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --出庫終了日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --出庫終了日時")
        End If
        intCount = intCount + 1
        If IsNull(mXDATA_TENSOU_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --翌日ﾃﾞｰﾀ転送")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --翌日ﾃﾞｰﾀ転送")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDATA_TENSOU_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --翌日ﾃﾞｰﾀ転送")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --翌日ﾃﾞｰﾀ転送")
        End If
        intCount = intCount + 1
        If IsNull(mXTANA_BLOCK_AKI) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --空棚ﾌﾞﾛｯｸ数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --空棚ﾌﾞﾛｯｸ数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTANA_BLOCK_AKI
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --空棚ﾌﾞﾛｯｸ数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --空棚ﾌﾞﾛｯｸ数")
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
    Public Sub DELETE_XRST_SOUGYOU()
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
        ElseIf IsNull(mXSOUGYOU_DT) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[操業日]"
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
        strSQL.Append(vbCrLf & "    XRST_SOUGYOU")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(XSOUGYOU_DT) = True Then
            strSQL.Append(vbCrLf & "    AND XSOUGYOU_DT IS NULL --操業日")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSOUGYOU_DT
            strSQL.Append(vbCrLf & "    AND XSOUGYOU_DT = :" & UBound(strBindField) - 1 & " --操業日")
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
    Public Sub DELETE_XRST_SOUGYOU_ANY()
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
        strSQL.Append(vbCrLf & "    XRST_SOUGYOU")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(XSOUGYOU_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSOUGYOU_DT
            strSQL.Append(vbCrLf & "    AND XSOUGYOU_DT = :" & UBound(strBindField) - 1 & " --操業日")
        End If
        If IsNotNull(XSTART_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSTART_DT
            strSQL.Append(vbCrLf & "    AND XSTART_DT = :" & UBound(strBindField) - 1 & " --開始日時")
        End If
        If IsNotNull(XEND_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEND_DT
            strSQL.Append(vbCrLf & "    AND XEND_DT = :" & UBound(strBindField) - 1 & " --終了日時")
        End If
        If IsNotNull(XSYUKKA_END_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_END_DT
            strSQL.Append(vbCrLf & "    AND XSYUKKA_END_DT = :" & UBound(strBindField) - 1 & " --出荷終了日時")
        End If
        If IsNotNull(XSYUKKO_END_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKO_END_DT
            strSQL.Append(vbCrLf & "    AND XSYUKKO_END_DT = :" & UBound(strBindField) - 1 & " --出庫終了日時")
        End If
        If IsNotNull(XDATA_TENSOU_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDATA_TENSOU_DT
            strSQL.Append(vbCrLf & "    AND XDATA_TENSOU_DT = :" & UBound(strBindField) - 1 & " --翌日ﾃﾞｰﾀ転送")
        End If
        If IsNotNull(XTANA_BLOCK_AKI) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTANA_BLOCK_AKI
            strSQL.Append(vbCrLf & "    AND XTANA_BLOCK_AKI = :" & UBound(strBindField) - 1 & " --空棚ﾌﾞﾛｯｸ数")
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
        If IsNothing(objType.GetProperty("XSOUGYOU_DT")) = False Then mXSOUGYOU_DT = objObject.XSOUGYOU_DT '操業日
        If IsNothing(objType.GetProperty("XSTART_DT")) = False Then mXSTART_DT = objObject.XSTART_DT '開始日時
        If IsNothing(objType.GetProperty("XEND_DT")) = False Then mXEND_DT = objObject.XEND_DT '終了日時
        If IsNothing(objType.GetProperty("XSYUKKA_END_DT")) = False Then mXSYUKKA_END_DT = objObject.XSYUKKA_END_DT '出荷終了日時
        If IsNothing(objType.GetProperty("XSYUKKO_END_DT")) = False Then mXSYUKKO_END_DT = objObject.XSYUKKO_END_DT '出庫終了日時
        If IsNothing(objType.GetProperty("XDATA_TENSOU_DT")) = False Then mXDATA_TENSOU_DT = objObject.XDATA_TENSOU_DT '翌日ﾃﾞｰﾀ転送
        If IsNothing(objType.GetProperty("XTANA_BLOCK_AKI")) = False Then mXTANA_BLOCK_AKI = objObject.XTANA_BLOCK_AKI '空棚ﾌﾞﾛｯｸ数

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
        mXSOUGYOU_DT = Nothing
        mXSTART_DT = Nothing
        mXEND_DT = Nothing
        mXSYUKKA_END_DT = Nothing
        mXSYUKKO_END_DT = Nothing
        mXDATA_TENSOU_DT = Nothing
        mXTANA_BLOCK_AKI = Nothing


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
        mXSOUGYOU_DT = TO_DATE_NULLABLE(objRow("XSOUGYOU_DT"))
        mXSTART_DT = TO_DATE_NULLABLE(objRow("XSTART_DT"))
        mXEND_DT = TO_DATE_NULLABLE(objRow("XEND_DT"))
        mXSYUKKA_END_DT = TO_DATE_NULLABLE(objRow("XSYUKKA_END_DT"))
        mXSYUKKO_END_DT = TO_DATE_NULLABLE(objRow("XSYUKKO_END_DT"))
        mXDATA_TENSOU_DT = TO_DATE_NULLABLE(objRow("XDATA_TENSOU_DT"))
        mXTANA_BLOCK_AKI = TO_INTEGER_NULLABLE(objRow("XTANA_BLOCK_AKI"))


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
        strMsg &= "[ﾃｰﾌﾞﾙ名:操業履歴]"
        If IsNotNull(XSOUGYOU_DT) Then
            strMsg &= "[操業日:" & XSOUGYOU_DT & "]"
        End If
        If IsNotNull(XSTART_DT) Then
            strMsg &= "[開始日時:" & XSTART_DT & "]"
        End If
        If IsNotNull(XEND_DT) Then
            strMsg &= "[終了日時:" & XEND_DT & "]"
        End If
        If IsNotNull(XSYUKKA_END_DT) Then
            strMsg &= "[出荷終了日時:" & XSYUKKA_END_DT & "]"
        End If
        If IsNotNull(XSYUKKO_END_DT) Then
            strMsg &= "[出庫終了日時:" & XSYUKKO_END_DT & "]"
        End If
        If IsNotNull(XDATA_TENSOU_DT) Then
            strMsg &= "[翌日ﾃﾞｰﾀ転送:" & XDATA_TENSOU_DT & "]"
        End If
        If IsNotNull(XTANA_BLOCK_AKI) Then
            strMsg &= "[空棚ﾌﾞﾛｯｸ数:" & XTANA_BLOCK_AKI & "]"
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
#Region "  操業日MAXのﾚｺｰﾄﾞを取得                                               "
    Public Function GET_XRST_SOUGYOU_XRST_SOUGYOU_MAX(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
        Dim strSQL As String            'SQL文
        Dim objDataSet As New DataSet   'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String    'ﾃﾞｰﾀｾｯﾄ名
        Dim objRow As DataRow           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ


        '*****************************************************
        '操業日MAXのﾚｺｰﾄﾞを取得
        '*****************************************************
        strSQL = ""
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "    * "
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    XRST_SOUGYOU "
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "    XSOUGYOU_DT = (SELECT MAX(XSOUGYOU_DT) FROM XRST_SOUGYOU) "
        strSQL &= vbCrLf & "  "


        '***********************
        '抽出
        '***********************
        ObjDb.SQL = strSQL.ToString
        objDataSet.Clear()
        strDataSetName = "XRST_SOUGYOU"
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
    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
