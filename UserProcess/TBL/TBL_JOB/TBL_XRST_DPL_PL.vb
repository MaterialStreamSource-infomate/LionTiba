'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' 【名称】MaterialStreamﾃｰﾌﾞﾙｸﾗｽ
' 【機能】ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ実績ﾃｰﾌﾞﾙｸﾗｽ
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
''' ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ実績ﾃｰﾌﾞﾙｸﾗｽ
''' </summary>
Public Class TBL_XRST_DPL_PL
    Inherits clsTemplateTable

    '**********************************************************************************************
    '↓↓↓自動生成部
#Region "  ｸﾗｽ変数定義                  "
    'ﾌﾟﾛﾊﾟﾃｨ
    Private mobjAryMe As TBL_XRST_DPL_PL()                                       'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ実績
    Private mstrUSER_SQL As String                                               'ﾕｰｻﾞｰSQL
    Private mORDER_BY As String                                                  'OrderBy句
    Private mWHERE As String                                                     'Where句
    Private mXSOUGYOU_DT As Nullable(Of Date)                                    '操業日
    Private mXDPL_PL_NO As Nullable(Of Integer)                                  'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号
    Private mFHINMEI_CD As String                                                '品目ｺｰﾄﾞ
    Private mXDPL_PL_PTN As Nullable(Of Integer)                                 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ
    Private mXSTART_DT As Nullable(Of Date)                                      '開始日時
    Private mXEND_DT As Nullable(Of Date)                                        '終了日時
    Private mXDPL_PL_CNT As Nullable(Of Decimal)                                 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付数
    Private mXDPL_PL_PLT As Nullable(Of Decimal)                                 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ生産ﾊﾟﾚｯﾄ数
    Private mXDPL_PL_HAS As Nullable(Of Decimal)                                 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ端数ﾃﾞｰﾀ
    Private mXDPL_PL_KADO_TIM As Nullable(Of Decimal)                            'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間
    Private mXDPL_PL_TRBL_TIM As Nullable(Of Decimal)                            'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間
    Private mXDPL_PL_TRBL_CNT As Nullable(Of Decimal)                            'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ件数
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                  "
    ''' <summary>
    ''' ｼｽﾃﾑ変数 (自ｸﾗｽ型配列)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_XRST_DPL_PL()
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
    ''' ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付数
    ''' </summary>
    Public Property XDPL_PL_CNT() As Nullable(Of Decimal)
        Get
            Return mXDPL_PL_CNT
        End Get
        Set(ByVal Value As Nullable(Of Decimal))
            mXDPL_PL_CNT = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ生産ﾊﾟﾚｯﾄ数
    ''' </summary>
    Public Property XDPL_PL_PLT() As Nullable(Of Decimal)
        Get
            Return mXDPL_PL_PLT
        End Get
        Set(ByVal Value As Nullable(Of Decimal))
            mXDPL_PL_PLT = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ端数ﾃﾞｰﾀ
    ''' </summary>
    Public Property XDPL_PL_HAS() As Nullable(Of Decimal)
        Get
            Return mXDPL_PL_HAS
        End Get
        Set(ByVal Value As Nullable(Of Decimal))
            mXDPL_PL_HAS = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間
    ''' </summary>
    Public Property XDPL_PL_KADO_TIM() As Nullable(Of Decimal)
        Get
            Return mXDPL_PL_KADO_TIM
        End Get
        Set(ByVal Value As Nullable(Of Decimal))
            mXDPL_PL_KADO_TIM = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間
    ''' </summary>
    Public Property XDPL_PL_TRBL_TIM() As Nullable(Of Decimal)
        Get
            Return mXDPL_PL_TRBL_TIM
        End Get
        Set(ByVal Value As Nullable(Of Decimal))
            mXDPL_PL_TRBL_TIM = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ件数
    ''' </summary>
    Public Property XDPL_PL_TRBL_CNT() As Nullable(Of Decimal)
        Get
            Return mXDPL_PL_TRBL_CNT
        End Get
        Set(ByVal Value As Nullable(Of Decimal))
            mXDPL_PL_TRBL_CNT = Value
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
    Public Function GET_XRST_DPL_PL(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    XRST_DPL_PL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XSOUGYOU_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSOUGYOU_DT
            strSQL.Append(vbCrLf & "    AND XSOUGYOU_DT = :" & UBound(strBindField) - 1 & " --操業日")
        End If
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
        If IsNull(XDPL_PL_CNT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_CNT
            strSQL.Append(vbCrLf & "    AND XDPL_PL_CNT = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付数")
        End If
        If IsNull(XDPL_PL_PLT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_PLT
            strSQL.Append(vbCrLf & "    AND XDPL_PL_PLT = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ生産ﾊﾟﾚｯﾄ数")
        End If
        If IsNull(XDPL_PL_HAS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_HAS
            strSQL.Append(vbCrLf & "    AND XDPL_PL_HAS = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ端数ﾃﾞｰﾀ")
        End If
        If IsNull(XDPL_PL_KADO_TIM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_KADO_TIM
            strSQL.Append(vbCrLf & "    AND XDPL_PL_KADO_TIM = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間")
        End If
        If IsNull(XDPL_PL_TRBL_TIM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_TRBL_TIM
            strSQL.Append(vbCrLf & "    AND XDPL_PL_TRBL_TIM = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間")
        End If
        If IsNull(XDPL_PL_TRBL_CNT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_TRBL_CNT
            strSQL.Append(vbCrLf & "    AND XDPL_PL_TRBL_CNT = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ件数")
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
        strDataSetName = "XRST_DPL_PL"
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
    Public Function GET_XRST_DPL_PL_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    XRST_DPL_PL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XSOUGYOU_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSOUGYOU_DT
            strSQL.Append(vbCrLf & "    AND XSOUGYOU_DT = :" & UBound(strBindField) - 1 & " --操業日")
        End If
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
        If IsNull(XDPL_PL_CNT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_CNT
            strSQL.Append(vbCrLf & "    AND XDPL_PL_CNT = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付数")
        End If
        If IsNull(XDPL_PL_PLT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_PLT
            strSQL.Append(vbCrLf & "    AND XDPL_PL_PLT = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ生産ﾊﾟﾚｯﾄ数")
        End If
        If IsNull(XDPL_PL_HAS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_HAS
            strSQL.Append(vbCrLf & "    AND XDPL_PL_HAS = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ端数ﾃﾞｰﾀ")
        End If
        If IsNull(XDPL_PL_KADO_TIM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_KADO_TIM
            strSQL.Append(vbCrLf & "    AND XDPL_PL_KADO_TIM = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間")
        End If
        If IsNull(XDPL_PL_TRBL_TIM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_TRBL_TIM
            strSQL.Append(vbCrLf & "    AND XDPL_PL_TRBL_TIM = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間")
        End If
        If IsNull(XDPL_PL_TRBL_CNT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_TRBL_CNT
            strSQL.Append(vbCrLf & "    AND XDPL_PL_TRBL_CNT = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ件数")
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
        strDataSetName = "XRST_DPL_PL"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XRST_DPL_PL(Owner, objDb, objDbLog)
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
    Public Function GET_XRST_DPL_PL_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "XRST_DPL_PL"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XRST_DPL_PL(Owner, objDb, objDbLog)
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
    Public Function GET_XRST_DPL_PL_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    XRST_DPL_PL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XSOUGYOU_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSOUGYOU_DT
            strSQL.Append(vbCrLf & "    AND XSOUGYOU_DT = :" & UBound(strBindField) - 1 & " --操業日")
        End If
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
        If IsNull(XDPL_PL_CNT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_CNT
            strSQL.Append(vbCrLf & "    AND XDPL_PL_CNT = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付数")
        End If
        If IsNull(XDPL_PL_PLT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_PLT
            strSQL.Append(vbCrLf & "    AND XDPL_PL_PLT = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ生産ﾊﾟﾚｯﾄ数")
        End If
        If IsNull(XDPL_PL_HAS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_HAS
            strSQL.Append(vbCrLf & "    AND XDPL_PL_HAS = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ端数ﾃﾞｰﾀ")
        End If
        If IsNull(XDPL_PL_KADO_TIM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_KADO_TIM
            strSQL.Append(vbCrLf & "    AND XDPL_PL_KADO_TIM = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間")
        End If
        If IsNull(XDPL_PL_TRBL_TIM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_TRBL_TIM
            strSQL.Append(vbCrLf & "    AND XDPL_PL_TRBL_TIM = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間")
        End If
        If IsNull(XDPL_PL_TRBL_CNT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_TRBL_CNT
            strSQL.Append(vbCrLf & "    AND XDPL_PL_TRBL_CNT = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ件数")
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
        strDataSetName = "XRST_DPL_PL"
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
    Public Sub UPDATE_XRST_DPL_PL()
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
        ElseIf IsNull(mXDPL_PL_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFHINMEI_CD) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[品目ｺｰﾄﾞ]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mXDPL_PL_PTN) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mXSTART_DT) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[開始日時]"
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
        strSQL.Append(vbCrLf & "    XRST_DPL_PL")
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
        If IsNull(mXDPL_PL_CNT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_CNT = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_CNT = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_CNT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_CNT = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_CNT = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付数")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_PLT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_PLT = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ生産ﾊﾟﾚｯﾄ数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_PLT = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ生産ﾊﾟﾚｯﾄ数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_PLT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_PLT = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ生産ﾊﾟﾚｯﾄ数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_PLT = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ生産ﾊﾟﾚｯﾄ数")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_HAS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_HAS = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ端数ﾃﾞｰﾀ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_HAS = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ端数ﾃﾞｰﾀ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_HAS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_HAS = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ端数ﾃﾞｰﾀ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_HAS = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ端数ﾃﾞｰﾀ")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_KADO_TIM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_KADO_TIM = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_KADO_TIM = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_KADO_TIM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_KADO_TIM = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_KADO_TIM = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_TRBL_TIM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_TRBL_TIM = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_TRBL_TIM = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_TRBL_TIM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_TRBL_TIM = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_TRBL_TIM = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_TRBL_CNT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_TRBL_CNT = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ件数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_TRBL_CNT = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ件数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_TRBL_CNT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_TRBL_CNT = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ件数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_TRBL_CNT = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ件数")
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
        If IsNull(XDPL_PL_NO) = True Then
            strSQL.Append(vbCrLf & "    AND XDPL_PL_NO IS NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_NO
            strSQL.Append(vbCrLf & "    AND XDPL_PL_NO = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号")
        End If
        If IsNull(FHINMEI_CD) = True Then
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD IS NULL --品目ｺｰﾄﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --品目ｺｰﾄﾞ")
        End If
        If IsNull(XDPL_PL_PTN) = True Then
            strSQL.Append(vbCrLf & "    AND XDPL_PL_PTN IS NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_PTN
            strSQL.Append(vbCrLf & "    AND XDPL_PL_PTN = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ")
        End If
        If IsNull(XSTART_DT) = True Then
            strSQL.Append(vbCrLf & "    AND XSTART_DT IS NULL --開始日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSTART_DT
            strSQL.Append(vbCrLf & "    AND XSTART_DT = :" & UBound(strBindField) - 1 & " --開始日時")
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
    Public Sub ADD_XRST_DPL_PL()
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
        ElseIf IsNull(mXDPL_PL_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFHINMEI_CD) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[品目ｺｰﾄﾞ]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mXDPL_PL_PTN) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mXSTART_DT) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[開始日時]"
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
        strSQL.Append(vbCrLf & "    XRST_DPL_PL")
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
        If IsNull(mXDPL_PL_CNT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_CNT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付数")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_PLT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ生産ﾊﾟﾚｯﾄ数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ生産ﾊﾟﾚｯﾄ数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_PLT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ生産ﾊﾟﾚｯﾄ数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ生産ﾊﾟﾚｯﾄ数")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_HAS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ端数ﾃﾞｰﾀ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ端数ﾃﾞｰﾀ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_HAS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ端数ﾃﾞｰﾀ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ端数ﾃﾞｰﾀ")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_KADO_TIM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_KADO_TIM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_TRBL_TIM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_TRBL_TIM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_TRBL_CNT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ件数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ件数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_TRBL_CNT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ件数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ件数")
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
    Public Sub DELETE_XRST_DPL_PL()
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
        ElseIf IsNull(mXDPL_PL_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFHINMEI_CD) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[品目ｺｰﾄﾞ]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mXDPL_PL_PTN) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mXSTART_DT) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[開始日時]"
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
        strSQL.Append(vbCrLf & "    XRST_DPL_PL")
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
        If IsNull(XDPL_PL_NO) = True Then
            strSQL.Append(vbCrLf & "    AND XDPL_PL_NO IS NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_NO
            strSQL.Append(vbCrLf & "    AND XDPL_PL_NO = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号")
        End If
        If IsNull(FHINMEI_CD) = True Then
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD IS NULL --品目ｺｰﾄﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --品目ｺｰﾄﾞ")
        End If
        If IsNull(XDPL_PL_PTN) = True Then
            strSQL.Append(vbCrLf & "    AND XDPL_PL_PTN IS NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_PTN
            strSQL.Append(vbCrLf & "    AND XDPL_PL_PTN = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ")
        End If
        If IsNull(XSTART_DT) = True Then
            strSQL.Append(vbCrLf & "    AND XSTART_DT IS NULL --開始日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSTART_DT
            strSQL.Append(vbCrLf & "    AND XSTART_DT = :" & UBound(strBindField) - 1 & " --開始日時")
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
    Public Sub DELETE_XRST_DPL_PL_ANY()
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
        strSQL.Append(vbCrLf & "    XRST_DPL_PL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(XSOUGYOU_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSOUGYOU_DT
            strSQL.Append(vbCrLf & "    AND XSOUGYOU_DT = :" & UBound(strBindField) - 1 & " --操業日")
        End If
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
        If IsNotNull(XDPL_PL_CNT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_CNT
            strSQL.Append(vbCrLf & "    AND XDPL_PL_CNT = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付数")
        End If
        If IsNotNull(XDPL_PL_PLT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_PLT
            strSQL.Append(vbCrLf & "    AND XDPL_PL_PLT = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ生産ﾊﾟﾚｯﾄ数")
        End If
        If IsNotNull(XDPL_PL_HAS) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_HAS
            strSQL.Append(vbCrLf & "    AND XDPL_PL_HAS = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ端数ﾃﾞｰﾀ")
        End If
        If IsNotNull(XDPL_PL_KADO_TIM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_KADO_TIM
            strSQL.Append(vbCrLf & "    AND XDPL_PL_KADO_TIM = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間")
        End If
        If IsNotNull(XDPL_PL_TRBL_TIM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_TRBL_TIM
            strSQL.Append(vbCrLf & "    AND XDPL_PL_TRBL_TIM = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間")
        End If
        If IsNotNull(XDPL_PL_TRBL_CNT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_TRBL_CNT
            strSQL.Append(vbCrLf & "    AND XDPL_PL_TRBL_CNT = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ件数")
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
        If IsNothing(objType.GetProperty("XDPL_PL_NO")) = False Then mXDPL_PL_NO = objObject.XDPL_PL_NO 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号
        If IsNothing(objType.GetProperty("FHINMEI_CD")) = False Then mFHINMEI_CD = objObject.FHINMEI_CD '品目ｺｰﾄﾞ
        If IsNothing(objType.GetProperty("XDPL_PL_PTN")) = False Then mXDPL_PL_PTN = objObject.XDPL_PL_PTN 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ
        If IsNothing(objType.GetProperty("XSTART_DT")) = False Then mXSTART_DT = objObject.XSTART_DT '開始日時
        If IsNothing(objType.GetProperty("XEND_DT")) = False Then mXEND_DT = objObject.XEND_DT '終了日時
        If IsNothing(objType.GetProperty("XDPL_PL_CNT")) = False Then mXDPL_PL_CNT = objObject.XDPL_PL_CNT 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付数
        If IsNothing(objType.GetProperty("XDPL_PL_PLT")) = False Then mXDPL_PL_PLT = objObject.XDPL_PL_PLT 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ生産ﾊﾟﾚｯﾄ数
        If IsNothing(objType.GetProperty("XDPL_PL_HAS")) = False Then mXDPL_PL_HAS = objObject.XDPL_PL_HAS 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ端数ﾃﾞｰﾀ
        If IsNothing(objType.GetProperty("XDPL_PL_KADO_TIM")) = False Then mXDPL_PL_KADO_TIM = objObject.XDPL_PL_KADO_TIM 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間
        If IsNothing(objType.GetProperty("XDPL_PL_TRBL_TIM")) = False Then mXDPL_PL_TRBL_TIM = objObject.XDPL_PL_TRBL_TIM 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間
        If IsNothing(objType.GetProperty("XDPL_PL_TRBL_CNT")) = False Then mXDPL_PL_TRBL_CNT = objObject.XDPL_PL_TRBL_CNT 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ件数

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
        mXDPL_PL_NO = Nothing
        mFHINMEI_CD = Nothing
        mXDPL_PL_PTN = Nothing
        mXSTART_DT = Nothing
        mXEND_DT = Nothing
        mXDPL_PL_CNT = Nothing
        mXDPL_PL_PLT = Nothing
        mXDPL_PL_HAS = Nothing
        mXDPL_PL_KADO_TIM = Nothing
        mXDPL_PL_TRBL_TIM = Nothing
        mXDPL_PL_TRBL_CNT = Nothing


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
        mXDPL_PL_NO = TO_INTEGER_NULLABLE(objRow("XDPL_PL_NO"))
        mFHINMEI_CD = TO_STRING_NULLABLE(objRow("FHINMEI_CD"))
        mXDPL_PL_PTN = TO_INTEGER_NULLABLE(objRow("XDPL_PL_PTN"))
        mXSTART_DT = TO_DATE_NULLABLE(objRow("XSTART_DT"))
        mXEND_DT = TO_DATE_NULLABLE(objRow("XEND_DT"))
        mXDPL_PL_CNT = TO_DECIMAL_NULLABLE(objRow("XDPL_PL_CNT"))
        mXDPL_PL_PLT = TO_DECIMAL_NULLABLE(objRow("XDPL_PL_PLT"))
        mXDPL_PL_HAS = TO_DECIMAL_NULLABLE(objRow("XDPL_PL_HAS"))
        mXDPL_PL_KADO_TIM = TO_DECIMAL_NULLABLE(objRow("XDPL_PL_KADO_TIM"))
        mXDPL_PL_TRBL_TIM = TO_DECIMAL_NULLABLE(objRow("XDPL_PL_TRBL_TIM"))
        mXDPL_PL_TRBL_CNT = TO_DECIMAL_NULLABLE(objRow("XDPL_PL_TRBL_CNT"))


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
        strMsg &= "[ﾃｰﾌﾞﾙ名:ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ実績]"
        If IsNotNull(XSOUGYOU_DT) Then
            strMsg &= "[操業日:" & XSOUGYOU_DT & "]"
        End If
        If IsNotNull(XDPL_PL_NO) Then
            strMsg &= "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号:" & XDPL_PL_NO & "]"
        End If
        If IsNotNull(FHINMEI_CD) Then
            strMsg &= "[品目ｺｰﾄﾞ:" & FHINMEI_CD & "]"
        End If
        If IsNotNull(XDPL_PL_PTN) Then
            strMsg &= "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ:" & XDPL_PL_PTN & "]"
        End If
        If IsNotNull(XSTART_DT) Then
            strMsg &= "[開始日時:" & XSTART_DT & "]"
        End If
        If IsNotNull(XEND_DT) Then
            strMsg &= "[終了日時:" & XEND_DT & "]"
        End If
        If IsNotNull(XDPL_PL_CNT) Then
            strMsg &= "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付数:" & XDPL_PL_CNT & "]"
        End If
        If IsNotNull(XDPL_PL_PLT) Then
            strMsg &= "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ生産ﾊﾟﾚｯﾄ数:" & XDPL_PL_PLT & "]"
        End If
        If IsNotNull(XDPL_PL_HAS) Then
            strMsg &= "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ端数ﾃﾞｰﾀ:" & XDPL_PL_HAS & "]"
        End If
        If IsNotNull(XDPL_PL_KADO_TIM) Then
            strMsg &= "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間:" & XDPL_PL_KADO_TIM & "]"
        End If
        If IsNotNull(XDPL_PL_TRBL_TIM) Then
            strMsg &= "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間:" & XDPL_PL_TRBL_TIM & "]"
        End If
        If IsNotNull(XDPL_PL_TRBL_CNT) Then
            strMsg &= "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ件数:" & XDPL_PL_TRBL_CNT & "]"
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
#Region "  ﾃﾞｰﾀ取得(未終了ﾃﾞｰﾀ)         "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀ取得(未終了ﾃﾞｰﾀ)
    ''' </summary>
    ''' <param name="blnNotFoundError">ﾚｺｰﾄﾞが一件も取得出来なかった場合、Throwするか否かのﾌﾗｸﾞ</param>
    ''' <returns>共通戻り値</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function GET_XRST_DPL_PL_NotEnd(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    XRST_DPL_PL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        '' ''If IsNull(XSOUGYOU_DT) = False Then
        '' ''    ReDim Preserve strBindField(UBound(strBindField) + 1)
        '' ''    ReDim Preserve objBindValue(UBound(objBindValue) + 1)
        '' ''    strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
        '' ''    objBindValue(UBound(objBindValue)) = mXSOUGYOU_DT
        '' ''    strSQL.Append(vbCrLf & "    AND XSOUGYOU_DT = :" & UBound(strBindField) - 1 & " --操業日")
        '' ''End If
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

        strSQL.Append(vbCrLf & "    AND XEND_DT IS NULL    --終了日時")
        strSQL.Append(vbCrLf & " ORDER BY ")
        strSQL.Append(vbCrLf & "    XSTART_DT DESC ")

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
        strDataSetName = "XRST_DPL_PL"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count >= 1 Then
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
        End If


    End Function
#End Region
    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
