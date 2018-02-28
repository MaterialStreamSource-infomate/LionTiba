'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' 【名称】MaterialStreamﾃｰﾌﾞﾙｸﾗｽ
' 【機能】ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況ﾃｰﾌﾞﾙｸﾗｽ
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
''' ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況ﾃｰﾌﾞﾙｸﾗｽ
''' </summary>
Public Class TBL_XSTS_DPL_PL
    Inherits clsTemplateTable

    '**********************************************************************************************
    '↓↓↓自動生成部
#Region "  ｸﾗｽ変数定義                  "
    'ﾌﾟﾛﾊﾟﾃｨ
    Private mobjAryMe As TBL_XSTS_DPL_PL()                                       'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況
    Private mstrUSER_SQL As String                                               'ﾕｰｻﾞｰSQL
    Private mORDER_BY As String                                                  'OrderBy句
    Private mWHERE As String                                                     'Where句
    Private mXDPL_PL_NO As Nullable(Of Integer)                                  'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号
    Private mFHINMEI_CD As String                                                '品目ｺｰﾄﾞ
    Private mXDPL_PL_PTN As Nullable(Of Integer)                                 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ
    Private mXDPL_PL_ONLINE As Nullable(Of Integer)                              'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾝﾗｲﾝ状態
    Private mXDPL_PL_STS As Nullable(Of Integer)                                 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転状態
    Private mXSTART_DT As Nullable(Of Date)                                      '開始日時
    Private mXEND_DT As Nullable(Of Date)                                        '終了日時
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                  "
    ''' <summary>
    ''' ｼｽﾃﾑ変数 (自ｸﾗｽ型配列)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_XSTS_DPL_PL()
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
    ''' ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号
    ''' </summary>
    Public Property XDPL_PL_NO() As Nullable(Of Integer)
        Get
            Return mXDPL_PL_NO
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXDPL_PL_NO = Value
        End Set
    End Property
    ''' <summary>
    ''' 品目ｺｰﾄﾞ
    ''' </summary>
    Public Property FHINMEI_CD() As String
        Get
            Return mFHINMEI_CD
        End Get
        Set(ByVal Value As String)
            mFHINMEI_CD = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ
    ''' </summary>
    Public Property XDPL_PL_PTN() As Nullable(Of Integer)
        Get
            Return mXDPL_PL_PTN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXDPL_PL_PTN = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾝﾗｲﾝ状態
    ''' </summary>
    Public Property XDPL_PL_ONLINE() As Nullable(Of Integer)
        Get
            Return mXDPL_PL_ONLINE
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXDPL_PL_ONLINE = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転状態
    ''' </summary>
    Public Property XDPL_PL_STS() As Nullable(Of Integer)
        Get
            Return mXDPL_PL_STS
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXDPL_PL_STS = Value
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
    Public Function GET_XSTS_DPL_PL(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    XSTS_DPL_PL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XDPL_PL_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_NO
            strSQL.Append(vbCrLf & "    AND XDPL_PL_NO = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号")
        End If
        If IsNull(FHINMEI_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --品目ｺｰﾄﾞ")
        End If
        If IsNull(XDPL_PL_PTN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_PTN
            strSQL.Append(vbCrLf & "    AND XDPL_PL_PTN = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ")
        End If
        If IsNull(XDPL_PL_ONLINE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_ONLINE
            strSQL.Append(vbCrLf & "    AND XDPL_PL_ONLINE = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾝﾗｲﾝ状態")
        End If
        If IsNull(XDPL_PL_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_STS
            strSQL.Append(vbCrLf & "    AND XDPL_PL_STS = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転状態")
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
        strDataSetName = "XSTS_DPL_PL"
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
    Public Function GET_XSTS_DPL_PL_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    XSTS_DPL_PL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XDPL_PL_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_NO
            strSQL.Append(vbCrLf & "    AND XDPL_PL_NO = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号")
        End If
        If IsNull(FHINMEI_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --品目ｺｰﾄﾞ")
        End If
        If IsNull(XDPL_PL_PTN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_PTN
            strSQL.Append(vbCrLf & "    AND XDPL_PL_PTN = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ")
        End If
        If IsNull(XDPL_PL_ONLINE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_ONLINE
            strSQL.Append(vbCrLf & "    AND XDPL_PL_ONLINE = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾝﾗｲﾝ状態")
        End If
        If IsNull(XDPL_PL_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_STS
            strSQL.Append(vbCrLf & "    AND XDPL_PL_STS = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転状態")
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
        strDataSetName = "XSTS_DPL_PL"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XSTS_DPL_PL(Owner, objDb, objDbLog)
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
    Public Function GET_XSTS_DPL_PL_USER(Optional ByRef objUSER_PARAM AS Object(,) = nothing) As RetCode
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
        strDataSetName = "XSTS_DPL_PL"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XSTS_DPL_PL(Owner, objDb, objDbLog)
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
    Public Function GET_XSTS_DPL_PL_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    XSTS_DPL_PL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XDPL_PL_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_NO
            strSQL.Append(vbCrLf & "    AND XDPL_PL_NO = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号")
        End If
        If IsNull(FHINMEI_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --品目ｺｰﾄﾞ")
        End If
        If IsNull(XDPL_PL_PTN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_PTN
            strSQL.Append(vbCrLf & "    AND XDPL_PL_PTN = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ")
        End If
        If IsNull(XDPL_PL_ONLINE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_ONLINE
            strSQL.Append(vbCrLf & "    AND XDPL_PL_ONLINE = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾝﾗｲﾝ状態")
        End If
        If IsNull(XDPL_PL_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_STS
            strSQL.Append(vbCrLf & "    AND XDPL_PL_STS = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転状態")
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
        strDataSetName = "XSTS_DPL_PL"
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
    Public Sub UPDATE_XSTS_DPL_PL()
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
        ElseIf IsNull(mXDPL_PL_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号]"
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
        strSQL.Append(vbCrLf & "    XSTS_DPL_PL")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
        If IsNull(mXDPL_PL_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_NO = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_NO = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_NO = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_NO = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号")
        End If
        intCount = intCount + 1
        If IsNull(mFHINMEI_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHINMEI_CD = NULL --品目ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHINMEI_CD = NULL --品目ｺｰﾄﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHINMEI_CD = :" & Ubound(strBindField) - 1 & " --品目ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHINMEI_CD = :" & Ubound(strBindField) - 1 & " --品目ｺｰﾄﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_PTN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_PTN = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_PTN = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_PTN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_PTN = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_PTN = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_ONLINE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_ONLINE = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾝﾗｲﾝ状態")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_ONLINE = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾝﾗｲﾝ状態")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_ONLINE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_ONLINE = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾝﾗｲﾝ状態")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_ONLINE = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾝﾗｲﾝ状態")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_STS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_STS = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転状態")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_STS = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転状態")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_STS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_STS = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転状態")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_STS = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転状態")
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
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(XDPL_PL_NO) = True Then
            strSQL.Append(vbCrLf & "    AND XDPL_PL_NO IS NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_NO
            strSQL.Append(vbCrLf & "    AND XDPL_PL_NO = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号")
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
    Public Sub ADD_XSTS_DPL_PL()
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
        ElseIf IsNull(mXDPL_PL_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号]"
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
        strSQL.Append(vbCrLf & "    XSTS_DPL_PL")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
        If IsNull(mXDPL_PL_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号")
        End If
        intCount = intCount + 1
        If IsNull(mFHINMEI_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --品目ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --品目ｺｰﾄﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --品目ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --品目ｺｰﾄﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_PTN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_PTN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_ONLINE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾝﾗｲﾝ状態")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾝﾗｲﾝ状態")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_ONLINE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾝﾗｲﾝ状態")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾝﾗｲﾝ状態")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_STS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転状態")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転状態")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_STS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転状態")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転状態")
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
    Public Sub DELETE_XSTS_DPL_PL()
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
        ElseIf IsNull(mXDPL_PL_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号]"
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
        strSQL.Append(vbCrLf & "    XSTS_DPL_PL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(XDPL_PL_NO) = True Then
            strSQL.Append(vbCrLf & "    AND XDPL_PL_NO IS NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_NO
            strSQL.Append(vbCrLf & "    AND XDPL_PL_NO = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号")
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
    Public Sub DELETE_XSTS_DPL_PL_ANY()
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
        strSQL.Append(vbCrLf & "    XSTS_DPL_PL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(XDPL_PL_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_NO
            strSQL.Append(vbCrLf & "    AND XDPL_PL_NO = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号")
        End If
        If IsNotNull(FHINMEI_CD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --品目ｺｰﾄﾞ")
        End If
        If IsNotNull(XDPL_PL_PTN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_PTN
            strSQL.Append(vbCrLf & "    AND XDPL_PL_PTN = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ")
        End If
        If IsNotNull(XDPL_PL_ONLINE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_ONLINE
            strSQL.Append(vbCrLf & "    AND XDPL_PL_ONLINE = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾝﾗｲﾝ状態")
        End If
        If IsNotNull(XDPL_PL_STS) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_STS
            strSQL.Append(vbCrLf & "    AND XDPL_PL_STS = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転状態")
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
        If IsNothing(objType.GetProperty("XDPL_PL_NO")) = False Then mXDPL_PL_NO = objObject.XDPL_PL_NO                                                'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号
        If IsNothing(objType.GetProperty("FHINMEI_CD")) = False Then mFHINMEI_CD = objObject.FHINMEI_CD                                                '品目ｺｰﾄﾞ
        If IsNothing(objType.GetProperty("XDPL_PL_PTN")) = False Then mXDPL_PL_PTN = objObject.XDPL_PL_PTN                                             'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ
        If IsNothing(objType.GetProperty("XDPL_PL_ONLINE")) = False Then mXDPL_PL_ONLINE = objObject.XDPL_PL_ONLINE                                    'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾝﾗｲﾝ状態
        If IsNothing(objType.GetProperty("XDPL_PL_STS")) = False Then mXDPL_PL_STS = objObject.XDPL_PL_STS                                             'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転状態
        If IsNothing(objType.GetProperty("XSTART_DT")) = False Then mXSTART_DT = objObject.XSTART_DT                                                   '開始日時
        If IsNothing(objType.GetProperty("XEND_DT")) = False Then mXEND_DT = objObject.XEND_DT                                                         '終了日時

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
        mXDPL_PL_NO = Nothing
        mFHINMEI_CD = Nothing
        mXDPL_PL_PTN = Nothing
        mXDPL_PL_ONLINE = Nothing
        mXDPL_PL_STS = Nothing
        mXSTART_DT = Nothing
        mXEND_DT = Nothing


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
        mXDPL_PL_NO = TO_INTEGER_NULLABLE(objRow("XDPL_PL_NO"))
        mFHINMEI_CD = TO_STRING_NULLABLE(objRow("FHINMEI_CD"))
        mXDPL_PL_PTN = TO_INTEGER_NULLABLE(objRow("XDPL_PL_PTN"))
        mXDPL_PL_ONLINE = TO_INTEGER_NULLABLE(objRow("XDPL_PL_ONLINE"))
        mXDPL_PL_STS = TO_INTEGER_NULLABLE(objRow("XDPL_PL_STS"))
        mXSTART_DT = TO_DATE_NULLABLE(objRow("XSTART_DT"))
        mXEND_DT = TO_DATE_NULLABLE(objRow("XEND_DT"))


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
        strMsg &= "[ﾃｰﾌﾞﾙ名:ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況]"
        If IsNotNull(XDPL_PL_NO) Then
            strMsg &= "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号:" & XDPL_PL_NO & "]"
        End If
        If IsNotNull(FHINMEI_CD) Then
            strMsg &= "[品目ｺｰﾄﾞ:" & FHINMEI_CD & "]"
        End If
        If IsNotNull(XDPL_PL_PTN) Then
            strMsg &= "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ:" & XDPL_PL_PTN & "]"
        End If
        If IsNotNull(XDPL_PL_ONLINE) Then
            strMsg &= "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾝﾗｲﾝ状態:" & XDPL_PL_ONLINE & "]"
        End If
        If IsNotNull(XDPL_PL_STS) Then
            strMsg &= "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転状態:" & XDPL_PL_STS & "]"
        End If
        If IsNotNull(XSTART_DT) Then
            strMsg &= "[開始日時:" & XSTART_DT & "]"
        End If
        If IsNotNull(XEND_DT) Then
            strMsg &= "[終了日時:" & XEND_DT & "]"
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
