'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' 【名称】MaterialStreamﾃｰﾌﾞﾙｸﾗｽ
' 【機能】搬送指示QUEﾃｰﾌﾞﾙｸﾗｽ
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
''' 搬送指示QUEﾃｰﾌﾞﾙｸﾗｽ
''' </summary>
Public Class TBL_TPLN_CARRY_QUE
    Inherits clsTemplateTable

    '**********************************************************************************************
    '↓↓↓自動生成部
#Region "  ｸﾗｽ変数定義                  "
    'ﾌﾟﾛﾊﾟﾃｨ
    Private mobjAryMe As TBL_TPLN_CARRY_QUE()                                    '搬送指示QUE
    Private mstrUSER_SQL As String                                               'ﾕｰｻﾞｰSQL
    Private mORDER_BY As String                                                  'OrderBy句
    Private mWHERE As String                                                     'Where句
    Private mFCARRYQUE_D As Nullable(Of Date)                                    '搬送指示日
    Private mFCARRYQUE_ORDER As Nullable(Of Integer)                             '搬送順№
    Private mFEQ_ID As String                                                    '設備ID
    Private mFPRIORITY As Nullable(Of Integer)                                   '優先ﾚﾍﾞﾙ
    Private mFPALLET_ID As String                                                'ﾊﾟﾚｯﾄID
    Private mFCARRYQUE_KUBUN As Nullable(Of Integer)                             '指示区分
    Private mFCARRYQUE_DIR_STS As Nullable(Of Integer)                           '搬送指示状況
    Private mFENTRY_DT As Nullable(Of Date)                                      '登録日時
    Private mFUPDATE_DT As Nullable(Of Date)                                     '更新日時
    Private mXOYAKO_KUBUN As Nullable(Of Integer)                                '親子区分
    Private mXPALLET_ID_AITE As String                                           '相手ﾊﾟﾚｯﾄID
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                  "
    ''' <summary>
    ''' ｼｽﾃﾑ変数 (自ｸﾗｽ型配列)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_TPLN_CARRY_QUE()
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
    ''' 搬送指示日
    ''' </summary>
    Public Property FCARRYQUE_D() As Nullable(Of Date)
        Get
            Return mFCARRYQUE_D
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mFCARRYQUE_D = Value
        End Set
    End Property
    ''' <summary>
    ''' 搬送順№
    ''' </summary>
    Public Property FCARRYQUE_ORDER() As Nullable(Of Integer)
        Get
            Return mFCARRYQUE_ORDER
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFCARRYQUE_ORDER = Value
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
    ''' 優先ﾚﾍﾞﾙ
    ''' </summary>
    Public Property FPRIORITY() As Nullable(Of Integer)
        Get
            Return mFPRIORITY
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFPRIORITY = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾊﾟﾚｯﾄID
    ''' </summary>
    Public Property FPALLET_ID() As String
        Get
            Return mFPALLET_ID
        End Get
        Set(ByVal Value As String)
            mFPALLET_ID = Value
        End Set
    End Property
    ''' <summary>
    ''' 指示区分
    ''' </summary>
    Public Property FCARRYQUE_KUBUN() As Nullable(Of Integer)
        Get
            Return mFCARRYQUE_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFCARRYQUE_KUBUN = Value
        End Set
    End Property
    ''' <summary>
    ''' 搬送指示状況
    ''' </summary>
    Public Property FCARRYQUE_DIR_STS() As Nullable(Of Integer)
        Get
            Return mFCARRYQUE_DIR_STS
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFCARRYQUE_DIR_STS = Value
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
    ''' 親子区分
    ''' </summary>
    Public Property XOYAKO_KUBUN() As Nullable(Of Integer)
        Get
            Return mXOYAKO_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXOYAKO_KUBUN = Value
        End Set
    End Property
    ''' <summary>
    ''' 相手ﾊﾟﾚｯﾄID
    ''' </summary>
    Public Property XPALLET_ID_AITE() As String
        Get
            Return mXPALLET_ID_AITE
        End Get
        Set(ByVal Value As String)
            mXPALLET_ID_AITE = Value
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
    Public Function GET_TPLN_CARRY_QUE(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    TPLN_CARRY_QUE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FCARRYQUE_D) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_D
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_D = :" & UBound(strBindField) - 1 & " --搬送指示日")
        End If
        If IsNull(FCARRYQUE_ORDER) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_ORDER
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_ORDER = :" & UBound(strBindField) - 1 & " --搬送順№")
        End If
        If IsNull(FEQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --設備ID")
        End If
        If IsNull(FPRIORITY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPRIORITY
            strSQL.Append(vbCrLf & "    AND FPRIORITY = :" & UBound(strBindField) - 1 & " --優先ﾚﾍﾞﾙ")
        End If
        If IsNull(FPALLET_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄID")
        End If
        If IsNull(FCARRYQUE_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_KUBUN
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_KUBUN = :" & UBound(strBindField) - 1 & " --指示区分")
        End If
        If IsNull(FCARRYQUE_DIR_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_DIR_STS
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_DIR_STS = :" & UBound(strBindField) - 1 & " --搬送指示状況")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --登録日時")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --更新日時")
        End If
        If IsNull(XOYAKO_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOYAKO_KUBUN
            strSQL.Append(vbCrLf & "    AND XOYAKO_KUBUN = :" & UBound(strBindField) - 1 & " --親子区分")
        End If
        If IsNull(XPALLET_ID_AITE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPALLET_ID_AITE
            strSQL.Append(vbCrLf & "    AND XPALLET_ID_AITE = :" & UBound(strBindField) - 1 & " --相手ﾊﾟﾚｯﾄID")
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
        strDataSetName = "TPLN_CARRY_QUE"
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
    Public Function GET_TPLN_CARRY_QUE_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    TPLN_CARRY_QUE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FCARRYQUE_D) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_D
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_D = :" & UBound(strBindField) - 1 & " --搬送指示日")
        End If
        If IsNull(FCARRYQUE_ORDER) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_ORDER
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_ORDER = :" & UBound(strBindField) - 1 & " --搬送順№")
        End If
        If IsNull(FEQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --設備ID")
        End If
        If IsNull(FPRIORITY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPRIORITY
            strSQL.Append(vbCrLf & "    AND FPRIORITY = :" & UBound(strBindField) - 1 & " --優先ﾚﾍﾞﾙ")
        End If
        If IsNull(FPALLET_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄID")
        End If
        If IsNull(FCARRYQUE_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_KUBUN
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_KUBUN = :" & UBound(strBindField) - 1 & " --指示区分")
        End If
        If IsNull(FCARRYQUE_DIR_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_DIR_STS
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_DIR_STS = :" & UBound(strBindField) - 1 & " --搬送指示状況")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --登録日時")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --更新日時")
        End If
        If IsNull(XOYAKO_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOYAKO_KUBUN
            strSQL.Append(vbCrLf & "    AND XOYAKO_KUBUN = :" & UBound(strBindField) - 1 & " --親子区分")
        End If
        If IsNull(XPALLET_ID_AITE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPALLET_ID_AITE
            strSQL.Append(vbCrLf & "    AND XPALLET_ID_AITE = :" & UBound(strBindField) - 1 & " --相手ﾊﾟﾚｯﾄID")
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
        strDataSetName = "TPLN_CARRY_QUE"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TPLN_CARRY_QUE(Owner, objDb, objDbLog)
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
    Public Function GET_TPLN_CARRY_QUE_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "TPLN_CARRY_QUE"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TPLN_CARRY_QUE(Owner, objDb, objDbLog)
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
    Public Function GET_TPLN_CARRY_QUE_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    TPLN_CARRY_QUE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FCARRYQUE_D) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_D
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_D = :" & UBound(strBindField) - 1 & " --搬送指示日")
        End If
        If IsNull(FCARRYQUE_ORDER) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_ORDER
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_ORDER = :" & UBound(strBindField) - 1 & " --搬送順№")
        End If
        If IsNull(FEQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --設備ID")
        End If
        If IsNull(FPRIORITY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPRIORITY
            strSQL.Append(vbCrLf & "    AND FPRIORITY = :" & UBound(strBindField) - 1 & " --優先ﾚﾍﾞﾙ")
        End If
        If IsNull(FPALLET_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄID")
        End If
        If IsNull(FCARRYQUE_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_KUBUN
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_KUBUN = :" & UBound(strBindField) - 1 & " --指示区分")
        End If
        If IsNull(FCARRYQUE_DIR_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_DIR_STS
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_DIR_STS = :" & UBound(strBindField) - 1 & " --搬送指示状況")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --登録日時")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --更新日時")
        End If
        If IsNull(XOYAKO_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOYAKO_KUBUN
            strSQL.Append(vbCrLf & "    AND XOYAKO_KUBUN = :" & UBound(strBindField) - 1 & " --親子区分")
        End If
        If IsNull(XPALLET_ID_AITE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPALLET_ID_AITE
            strSQL.Append(vbCrLf & "    AND XPALLET_ID_AITE = :" & UBound(strBindField) - 1 & " --相手ﾊﾟﾚｯﾄID")
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
        strDataSetName = "TPLN_CARRY_QUE"
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
    Public Sub UPDATE_TPLN_CARRY_QUE()
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
        ElseIf IsNull(mFCARRYQUE_D) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[搬送指示日]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFCARRYQUE_ORDER) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[搬送順№]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFEQ_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[設備ID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFPRIORITY) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[優先ﾚﾍﾞﾙ]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFPALLET_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾊﾟﾚｯﾄID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFCARRYQUE_KUBUN) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[指示区分]"
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
        strSQL.Append(vbCrLf & "    TPLN_CARRY_QUE")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
        If IsNull(mFCARRYQUE_D) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCARRYQUE_D = NULL --搬送指示日")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCARRYQUE_D = NULL --搬送指示日")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_D
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCARRYQUE_D = :" & Ubound(strBindField) - 1 & " --搬送指示日")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCARRYQUE_D = :" & Ubound(strBindField) - 1 & " --搬送指示日")
        End If
        intCount = intCount + 1
        If IsNull(mFCARRYQUE_ORDER) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCARRYQUE_ORDER = NULL --搬送順№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCARRYQUE_ORDER = NULL --搬送順№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_ORDER
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCARRYQUE_ORDER = :" & Ubound(strBindField) - 1 & " --搬送順№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCARRYQUE_ORDER = :" & Ubound(strBindField) - 1 & " --搬送順№")
        End If
        intCount = intCount + 1
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
        If IsNull(mFPRIORITY) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FPRIORITY = NULL --優先ﾚﾍﾞﾙ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FPRIORITY = NULL --優先ﾚﾍﾞﾙ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPRIORITY
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FPRIORITY = :" & Ubound(strBindField) - 1 & " --優先ﾚﾍﾞﾙ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FPRIORITY = :" & Ubound(strBindField) - 1 & " --優先ﾚﾍﾞﾙ")
        End If
        intCount = intCount + 1
        If IsNull(mFPALLET_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FPALLET_ID = NULL --ﾊﾟﾚｯﾄID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FPALLET_ID = NULL --ﾊﾟﾚｯﾄID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FPALLET_ID = :" & Ubound(strBindField) - 1 & " --ﾊﾟﾚｯﾄID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FPALLET_ID = :" & Ubound(strBindField) - 1 & " --ﾊﾟﾚｯﾄID")
        End If
        intCount = intCount + 1
        If IsNull(mFCARRYQUE_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCARRYQUE_KUBUN = NULL --指示区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCARRYQUE_KUBUN = NULL --指示区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCARRYQUE_KUBUN = :" & Ubound(strBindField) - 1 & " --指示区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCARRYQUE_KUBUN = :" & Ubound(strBindField) - 1 & " --指示区分")
        End If
        intCount = intCount + 1
        If IsNull(mFCARRYQUE_DIR_STS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCARRYQUE_DIR_STS = NULL --搬送指示状況")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCARRYQUE_DIR_STS = NULL --搬送指示状況")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_DIR_STS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCARRYQUE_DIR_STS = :" & Ubound(strBindField) - 1 & " --搬送指示状況")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCARRYQUE_DIR_STS = :" & Ubound(strBindField) - 1 & " --搬送指示状況")
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
        If IsNull(mXOYAKO_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XOYAKO_KUBUN = NULL --親子区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XOYAKO_KUBUN = NULL --親子区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOYAKO_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XOYAKO_KUBUN = :" & Ubound(strBindField) - 1 & " --親子区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XOYAKO_KUBUN = :" & Ubound(strBindField) - 1 & " --親子区分")
        End If
        intCount = intCount + 1
        If IsNull(mXPALLET_ID_AITE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XPALLET_ID_AITE = NULL --相手ﾊﾟﾚｯﾄID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XPALLET_ID_AITE = NULL --相手ﾊﾟﾚｯﾄID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPALLET_ID_AITE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XPALLET_ID_AITE = :" & Ubound(strBindField) - 1 & " --相手ﾊﾟﾚｯﾄID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XPALLET_ID_AITE = :" & Ubound(strBindField) - 1 & " --相手ﾊﾟﾚｯﾄID")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FCARRYQUE_D) = True Then
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_D IS NULL --搬送指示日")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_D
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_D = :" & UBound(strBindField) - 1 & " --搬送指示日")
        End If
        If IsNull(FCARRYQUE_ORDER) = True Then
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_ORDER IS NULL --搬送順№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_ORDER
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_ORDER = :" & UBound(strBindField) - 1 & " --搬送順№")
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
    Public Sub ADD_TPLN_CARRY_QUE()
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
        ElseIf IsNull(mFCARRYQUE_D) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[搬送指示日]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFCARRYQUE_ORDER) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[搬送順№]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFEQ_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[設備ID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFPRIORITY) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[優先ﾚﾍﾞﾙ]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFPALLET_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾊﾟﾚｯﾄID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFCARRYQUE_KUBUN) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[指示区分]"
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
        strSQL.Append(vbCrLf & "    TPLN_CARRY_QUE")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
        If IsNull(mFCARRYQUE_D) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --搬送指示日")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --搬送指示日")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_D
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --搬送指示日")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --搬送指示日")
        End If
        intCount = intCount + 1
        If IsNull(mFCARRYQUE_ORDER) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --搬送順№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --搬送順№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_ORDER
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --搬送順№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --搬送順№")
        End If
        intCount = intCount + 1
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
        If IsNull(mFPRIORITY) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --優先ﾚﾍﾞﾙ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --優先ﾚﾍﾞﾙ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPRIORITY
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --優先ﾚﾍﾞﾙ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --優先ﾚﾍﾞﾙ")
        End If
        intCount = intCount + 1
        If IsNull(mFPALLET_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾊﾟﾚｯﾄID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾊﾟﾚｯﾄID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾊﾟﾚｯﾄID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾊﾟﾚｯﾄID")
        End If
        intCount = intCount + 1
        If IsNull(mFCARRYQUE_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --指示区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --指示区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --指示区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --指示区分")
        End If
        intCount = intCount + 1
        If IsNull(mFCARRYQUE_DIR_STS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --搬送指示状況")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --搬送指示状況")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_DIR_STS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --搬送指示状況")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --搬送指示状況")
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
        If IsNull(mXOYAKO_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --親子区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --親子区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOYAKO_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --親子区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --親子区分")
        End If
        intCount = intCount + 1
        If IsNull(mXPALLET_ID_AITE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --相手ﾊﾟﾚｯﾄID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --相手ﾊﾟﾚｯﾄID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPALLET_ID_AITE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --相手ﾊﾟﾚｯﾄID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --相手ﾊﾟﾚｯﾄID")
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
    Public Sub DELETE_TPLN_CARRY_QUE()
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
        ElseIf IsNull(mFCARRYQUE_D) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[搬送指示日]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFCARRYQUE_ORDER) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[搬送順№]"
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
        strSQL.Append(vbCrLf & "    TPLN_CARRY_QUE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FCARRYQUE_D) = True Then
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_D IS NULL --搬送指示日")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_D
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_D = :" & UBound(strBindField) - 1 & " --搬送指示日")
        End If
        If IsNull(FCARRYQUE_ORDER) = True Then
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_ORDER IS NULL --搬送順№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_ORDER
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_ORDER = :" & UBound(strBindField) - 1 & " --搬送順№")
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
    Public Sub DELETE_TPLN_CARRY_QUE_ANY()
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
        strSQL.Append(vbCrLf & "    TPLN_CARRY_QUE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(FCARRYQUE_D) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_D
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_D = :" & UBound(strBindField) - 1 & " --搬送指示日")
        End If
        If IsNotNull(FCARRYQUE_ORDER) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_ORDER
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_ORDER = :" & UBound(strBindField) - 1 & " --搬送順№")
        End If
        If IsNotNull(FEQ_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --設備ID")
        End If
        If IsNotNull(FPRIORITY) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPRIORITY
            strSQL.Append(vbCrLf & "    AND FPRIORITY = :" & UBound(strBindField) - 1 & " --優先ﾚﾍﾞﾙ")
        End If
        If IsNotNull(FPALLET_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄID")
        End If
        If IsNotNull(FCARRYQUE_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_KUBUN
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_KUBUN = :" & UBound(strBindField) - 1 & " --指示区分")
        End If
        If IsNotNull(FCARRYQUE_DIR_STS) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCARRYQUE_DIR_STS
            strSQL.Append(vbCrLf & "    AND FCARRYQUE_DIR_STS = :" & UBound(strBindField) - 1 & " --搬送指示状況")
        End If
        If IsNotNull(FENTRY_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --登録日時")
        End If
        If IsNotNull(FUPDATE_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --更新日時")
        End If
        If IsNotNull(XOYAKO_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOYAKO_KUBUN
            strSQL.Append(vbCrLf & "    AND XOYAKO_KUBUN = :" & UBound(strBindField) - 1 & " --親子区分")
        End If
        If IsNotNull(XPALLET_ID_AITE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPALLET_ID_AITE
            strSQL.Append(vbCrLf & "    AND XPALLET_ID_AITE = :" & UBound(strBindField) - 1 & " --相手ﾊﾟﾚｯﾄID")
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
        If IsNothing(objType.GetProperty("FCARRYQUE_D")) = False Then mFCARRYQUE_D = objObject.FCARRYQUE_D '搬送指示日
        If IsNothing(objType.GetProperty("FCARRYQUE_ORDER")) = False Then mFCARRYQUE_ORDER = objObject.FCARRYQUE_ORDER '搬送順№
        If IsNothing(objType.GetProperty("FEQ_ID")) = False Then mFEQ_ID = objObject.FEQ_ID '設備ID
        If IsNothing(objType.GetProperty("FPRIORITY")) = False Then mFPRIORITY = objObject.FPRIORITY '優先ﾚﾍﾞﾙ
        If IsNothing(objType.GetProperty("FPALLET_ID")) = False Then mFPALLET_ID = objObject.FPALLET_ID 'ﾊﾟﾚｯﾄID
        If IsNothing(objType.GetProperty("FCARRYQUE_KUBUN")) = False Then mFCARRYQUE_KUBUN = objObject.FCARRYQUE_KUBUN '指示区分
        If IsNothing(objType.GetProperty("FCARRYQUE_DIR_STS")) = False Then mFCARRYQUE_DIR_STS = objObject.FCARRYQUE_DIR_STS '搬送指示状況
        If IsNothing(objType.GetProperty("FENTRY_DT")) = False Then mFENTRY_DT = objObject.FENTRY_DT '登録日時
        If IsNothing(objType.GetProperty("FUPDATE_DT")) = False Then mFUPDATE_DT = objObject.FUPDATE_DT '更新日時
        If IsNothing(objType.GetProperty("XOYAKO_KUBUN")) = False Then mXOYAKO_KUBUN = objObject.XOYAKO_KUBUN '親子区分
        If IsNothing(objType.GetProperty("XPALLET_ID_AITE")) = False Then mXPALLET_ID_AITE = objObject.XPALLET_ID_AITE '相手ﾊﾟﾚｯﾄID

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
        mFCARRYQUE_D = Nothing
        mFCARRYQUE_ORDER = Nothing
        mFEQ_ID = Nothing
        mFPRIORITY = Nothing
        mFPALLET_ID = Nothing
        mFCARRYQUE_KUBUN = Nothing
        mFCARRYQUE_DIR_STS = Nothing
        mFENTRY_DT = Nothing
        mFUPDATE_DT = Nothing
        mXOYAKO_KUBUN = Nothing
        mXPALLET_ID_AITE = Nothing


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
        mFCARRYQUE_D = TO_DATE_NULLABLE(objRow("FCARRYQUE_D"))
        mFCARRYQUE_ORDER = TO_INTEGER_NULLABLE(objRow("FCARRYQUE_ORDER"))
        mFEQ_ID = TO_STRING_NULLABLE(objRow("FEQ_ID"))
        mFPRIORITY = TO_INTEGER_NULLABLE(objRow("FPRIORITY"))
        mFPALLET_ID = TO_STRING_NULLABLE(objRow("FPALLET_ID"))
        mFCARRYQUE_KUBUN = TO_INTEGER_NULLABLE(objRow("FCARRYQUE_KUBUN"))
        mFCARRYQUE_DIR_STS = TO_INTEGER_NULLABLE(objRow("FCARRYQUE_DIR_STS"))
        mFENTRY_DT = TO_DATE_NULLABLE(objRow("FENTRY_DT"))
        mFUPDATE_DT = TO_DATE_NULLABLE(objRow("FUPDATE_DT"))
        mXOYAKO_KUBUN = TO_INTEGER_NULLABLE(objRow("XOYAKO_KUBUN"))
        mXPALLET_ID_AITE = TO_STRING_NULLABLE(objRow("XPALLET_ID_AITE"))


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
        strMsg &= "[ﾃｰﾌﾞﾙ名:搬送指示QUE]"
        If IsNotNull(FCARRYQUE_D) Then
            strMsg &= "[搬送指示日:" & FCARRYQUE_D & "]"
        End If
        If IsNotNull(FCARRYQUE_ORDER) Then
            strMsg &= "[搬送順№:" & FCARRYQUE_ORDER & "]"
        End If
        If IsNotNull(FEQ_ID) Then
            strMsg &= "[設備ID:" & FEQ_ID & "]"
        End If
        If IsNotNull(FPRIORITY) Then
            strMsg &= "[優先ﾚﾍﾞﾙ:" & FPRIORITY & "]"
        End If
        If IsNotNull(FPALLET_ID) Then
            strMsg &= "[ﾊﾟﾚｯﾄID:" & FPALLET_ID & "]"
        End If
        If IsNotNull(FCARRYQUE_KUBUN) Then
            strMsg &= "[指示区分:" & FCARRYQUE_KUBUN & "]"
        End If
        If IsNotNull(FCARRYQUE_DIR_STS) Then
            strMsg &= "[搬送指示状況:" & FCARRYQUE_DIR_STS & "]"
        End If
        If IsNotNull(FENTRY_DT) Then
            strMsg &= "[登録日時:" & FENTRY_DT & "]"
        End If
        If IsNotNull(FUPDATE_DT) Then
            strMsg &= "[更新日時:" & FUPDATE_DT & "]"
        End If
        If IsNotNull(XOYAKO_KUBUN) Then
            strMsg &= "[親子区分:" & XOYAKO_KUBUN & "]"
        End If
        If IsNotNull(XPALLET_ID_AITE) Then
            strMsg &= "[相手ﾊﾟﾚｯﾄID:" & XPALLET_ID_AITE & "]"
        End If


    End Sub
#End Region
    '↑↑↑自動生成部
    '**********************************************************************************************

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ共通
#Region "  搬送指示QUE追加  [搬送順発番]        (Public  ADD_TPLN_CARRY_QUE_ORDER)"
    Public Sub ADD_TPLN_CARRY_QUE_ORDER()
        Try
            Dim strSQL As String            'SQL文
            Dim strMsg As String            'ﾒｯｾｰｼﾞ
            Dim intRetSQL As Integer        'SQL実行戻り値
            Dim objDataSet As New DataSet   'ﾃﾞｰﾀｾｯﾄ
            Dim strDataSetName As String    'ﾃﾞｰﾀｾｯﾄ名
            Dim objRow As DataRow           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ

            '***********************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '***********************
            If IsNull(mFCARRYQUE_D) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[搬送指示日]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '抽出SQL作成
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    MAX(FCARRYQUE_ORDER) AS MAX_ORDER"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TPLN_CARRY_QUE"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FCARRYQUE_D = TO_DATE('" & Format(mFCARRYQUE_D, "yyyy/MM/dd HH:mm:ss") & "','YYYY/MM/DD HH24:MI:SS')"
            strSQL &= vbCrLf


            '***********************
            '抽出
            '***********************
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TPLN_CARRY_QUE"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                objRow = objDataSet.Tables(strDataSetName).Rows(0)
                If IsDBNull(objRow("MAX_ORDER")) = False Then
                    mFCARRYQUE_ORDER = TO_NUMBER(objRow("MAX_ORDER")) + 1
                Else
                    mFCARRYQUE_ORDER = 1
                End If
            Else
                mFCARRYQUE_ORDER = 1
            End If


            '***********************
            '追加SQL作成
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "INSERT INTO"
            strSQL &= vbCrLf & "    TPLN_CARRY_QUE"
            strSQL &= vbCrLf & " VALUES("
            strSQL &= vbCrLf & "    TO_DATE('" & Format(mFCARRYQUE_D, "yyyy/MM/dd HH:mm:ss") & "','YYYY/MM/DD HH24:MI:SS')"
            strSQL &= vbCrLf & "   ," & TO_STRING(mFCARRYQUE_ORDER)
            strSQL &= vbCrLf & "   ,'" & TO_STRING(mFEQ_ID) & "'"
            strSQL &= vbCrLf & "   ," & TO_STRING(mFPRIORITY)
            strSQL &= vbCrLf & "   ,'" & TO_STRING(mFPALLET_ID) & "'"
            strSQL &= vbCrLf & "   ," & TO_STRING(mFCARRYQUE_KUBUN)
            strSQL &= vbCrLf & "   ," & TO_STRING(mFCARRYQUE_DIR_STS)
            strSQL &= vbCrLf & "   ,TO_DATE('" & Format(mFENTRY_DT, "yyyy/MM/dd HH:mm:ss") & "','YYYY/MM/DD HH24:MI:SS')"
            strSQL &= vbCrLf & "   ,TO_DATE('" & Format(mFUPDATE_DT, "yyyy/MM/dd HH:mm:ss") & "','YYYY/MM/DD HH24:MI:SS')"
            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:N.Dounoshita 2013/04/03  ﾍﾟｱ搬送対応
            If IsNotNull(mXOYAKO_KUBUN) Then
                strSQL &= vbCrLf & "   ," & TO_STRING(mXOYAKO_KUBUN)
            Else
                strSQL &= vbCrLf & "   ,NULL "
            End If
            strSQL &= vbCrLf & "   ,'" & TO_STRING(mXPALLET_ID_AITE) & "'"
            '↑↑↑↑↑↑************************************************************************************************************
            strSQL &= vbCrLf & " )"
            strSQL &= vbCrLf


            '***********************
            '追加
            '***********************
            intRetSQL = ObjDb.Execute(strSQL)
            If intRetSQL = -1 Then
                '(SQLｴﾗｰ)
                strSQL = Replace(strSQL, vbCrLf, "")
                strMsg = ERRMSG_ERR_ADD & ObjDb.ErrMsg & "【" & strSQL & "】"
                Throw New UserException(strMsg)
            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
#Region "  搬送指示QUE削除  [ﾊﾟﾚｯﾄ]             (Public  DELETE_TPLN_CARRY_QUE_PALLET)"
    Public Sub DELETE_TPLN_CARRY_QUE_PALLET()
        Try
            Dim strSQL As String        'SQL文
            Dim strMsg As String        'ﾒｯｾｰｼﾞ
            Dim intRetSQL As Integer    'SQL実行戻り値

            '***********************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '***********************
            If mFPALLET_ID = DEFAULT_STRING Then
                strMsg = ERRMSG_ERR_PROPERTY & "[ﾊﾟﾚｯﾄID]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '削除SQL作成
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "DELETE"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TPLN_CARRY_QUE"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FPALLET_ID = '" & TO_STRING(mFPALLET_ID) & "'"
            strSQL &= vbCrLf


            '***********************
            '削除
            '***********************
            intRetSQL = ObjDb.Execute(strSQL)
            If intRetSQL = -1 Then
                '(SQLｴﾗｰ)
                strSQL = Replace(strSQL, vbCrLf, "")
                strMsg = ERRMSG_ERR_DELETE & ObjDb.ErrMsg & "【" & strSQL & "】"
                Throw New UserException(strMsg)
            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
#Region "  搬送指示QUE指示件数取得  [設備ID]    (Public  GET_TPLN_CARRY_QUE_SEND_COUNT_BY_EQ_ID)"
    Public Function GET_TPLN_CARRY_QUE_SEND_COUNT_BY_EQ_ID() As RetCode
        Try
            Dim strSQL As String            'SQL文
            Dim strMsg As String            'ﾒｯｾｰｼﾞ
            Dim objDataSet As New DataSet   'ﾃﾞｰﾀｾｯﾄ
            Dim strDataSetName As String    'ﾃﾞｰﾀｾｯﾄ名
            Dim objRow As DataRow           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ

            '***********************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '***********************
            If mFEQ_ID = DEFAULT_STRING Then
                strMsg = ERRMSG_ERR_PROPERTY & "[設備ID]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '抽出SQL作成
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    COUNT(*) AS CNT"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TPLN_CARRY_QUE"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FEQ_ID = '" & TO_STRING(mFEQ_ID) & "'"                          '設備ID
            strSQL &= vbCrLf & "    AND FCARRYQUE_DIR_STS = '" & TO_STRING(FCARRYQUE_DIR_STS_SEND) & "'" '搬送指示状況 = 指示済
            strSQL &= vbCrLf


            '***********************
            '抽出
            '***********************
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TPLN_CARRY_QUE"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                objRow = objDataSet.Tables(strDataSetName).Rows(0)
                Return (TO_INTEGER(objRow("CNT")))
            Else
                Return (0)
            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "  搬送指示QUE入庫指示件数取得 [設備ID] (Public  GET_TPLN_CARRY_QUE_SEND_COUNT_IN)"
    Public Function GET_TPLN_CARRY_QUE_SEND_COUNT_IN() As RetCode
        Try
            Dim strSQL As String            'SQL文
            Dim strMsg As String            'ﾒｯｾｰｼﾞ
            Dim objDataSet As New DataSet   'ﾃﾞｰﾀｾｯﾄ
            Dim strDataSetName As String    'ﾃﾞｰﾀｾｯﾄ名
            Dim objRow As DataRow           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ

            '***********************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '***********************
            If mFEQ_ID = DEFAULT_STRING Then
                strMsg = ERRMSG_ERR_PROPERTY & "[設備ID]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '抽出SQL作成
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    COUNT(*) AS CNT"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TPLN_CARRY_QUE"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FEQ_ID = '" & TO_STRING(mFEQ_ID) & "'"                          '設備ID
            strSQL &= vbCrLf & "    AND FCARRYQUE_DIR_STS = " & TO_STRING(FCARRYQUE_DIR_STS_SEND)        '搬送指示状況 = 指示済
            strSQL &= vbCrLf & "    AND FCARRYQUE_KUBUN = " & TO_STRING(FCARRYQUE_KUBUN_SIN)             '指示区分 = 入庫
            strSQL &= vbCrLf


            '***********************
            '抽出
            '***********************
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TPLN_CARRY_QUE"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                objRow = objDataSet.Tables(strDataSetName).Rows(0)
                Return (TO_INTEGER(objRow("CNT")))
            Else
                Return (0)
            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "  搬送指示QUE出庫指示件数取得 [設備ID] (Public  GET_TPLN_CARRY_QUE_SEND_COUNT_OUT)"
    Public Function GET_TPLN_CARRY_QUE_SEND_COUNT_OUT() As RetCode
        Try
            Dim strSQL As String            'SQL文
            Dim strMsg As String            'ﾒｯｾｰｼﾞ
            Dim objDataSet As New DataSet   'ﾃﾞｰﾀｾｯﾄ
            Dim strDataSetName As String    'ﾃﾞｰﾀｾｯﾄ名
            Dim objRow As DataRow           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ

            '***********************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '***********************
            If mFEQ_ID = DEFAULT_STRING Then
                strMsg = ERRMSG_ERR_PROPERTY & "[設備ID]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '抽出SQL作成
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    COUNT(*) AS CNT"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TPLN_CARRY_QUE"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FEQ_ID = '" & TO_STRING(mFEQ_ID) & "'"                          '設備ID
            strSQL &= vbCrLf & "    AND FCARRYQUE_DIR_STS = " & TO_STRING(FCARRYQUE_DIR_STS_SEND)        '搬送指示状況 = 指示済
            strSQL &= vbCrLf & "    AND FCARRYQUE_KUBUN = " & TO_STRING(FCARRYQUE_KUBUN_SOUT)            '指示区分 = 出庫
            strSQL &= vbCrLf


            '***********************
            '抽出
            '***********************
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TPLN_CARRY_QUE"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                objRow = objDataSet.Tables(strDataSetName).Rows(0)
                Return (TO_INTEGER(objRow("CNT")))
            Else
                Return (0)
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

#Region "  ｸﾗｽ変数定義                  "
    Private mFTR_TO As String                       '搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                  "
    ''' <summary>
    ''' 搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    ''' </summary>
    Public Property FTR_TO() As String
        Get
            Return mFTR_TO
        End Get
        Set(ByVal Value As String)
            mFTR_TO = Value
        End Set
    End Property
#End Region
#Region "  搬送指示QUE出庫指示取得 [設備ID][搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№]                       "
    '''**********************************************************************************************
    ''' <summary>
    ''' 搬送指示QUE出庫指示取得 [設備ID][搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№]
    ''' </summary>
    ''' <param name="intWhereMode">WHERE句で、「IN」「NOT IN」のどちらかにする判定</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function GET_TPLN_CARRY_QUE_SEND_OUT_FTR_TO(ByVal intWhereMode As WhereMode) As RetCode
        Try
            Dim strSQL As String            'SQL文
            Dim strMsg As String            'ﾒｯｾｰｼﾞ
            'Dim objDataSet As New DataSet   'ﾃﾞｰﾀｾｯﾄ
            'Dim strDataSetName As String    'ﾃﾞｰﾀｾｯﾄ名
            'Dim objRow As DataRow           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
            Dim intRet As RetCode           '戻り値


            '***********************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '***********************
            If mFEQ_ID = DEFAULT_STRING Then
                strMsg = ERRMSG_ERR_PROPERTY & "[設備ID]"
                Throw New UserException(strMsg)
            ElseIf mFTR_TO = DEFAULT_STRING Then
                strMsg = ERRMSG_ERR_PROPERTY & "[搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '抽出SQL作成
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    TPLN_CARRY_QUE.FCARRYQUE_D "
            strSQL &= vbCrLf & "   ,TPLN_CARRY_QUE.FCARRYQUE_ORDER "
            strSQL &= vbCrLf & "   ,TPLN_CARRY_QUE.FEQ_ID "
            strSQL &= vbCrLf & "   ,TPLN_CARRY_QUE.FPRIORITY "
            strSQL &= vbCrLf & "   ,TPLN_CARRY_QUE.FPALLET_ID "
            strSQL &= vbCrLf & "   ,TPLN_CARRY_QUE.FCARRYQUE_KUBUN "
            strSQL &= vbCrLf & "   ,TPLN_CARRY_QUE.FCARRYQUE_DIR_STS "
            strSQL &= vbCrLf & "   ,TPLN_CARRY_QUE.FENTRY_DT "
            strSQL &= vbCrLf & "   ,TPLN_CARRY_QUE.FUPDATE_DT "
            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:N.Dounoshita 2013/04/03  ﾍﾟｱ搬送対応
            strSQL &= vbCrLf & "   ,TPLN_CARRY_QUE.XOYAKO_KUBUN "
            strSQL &= vbCrLf & "   ,TPLN_CARRY_QUE.XPALLET_ID_AITE "
            '↑↑↑↑↑↑************************************************************************************************************
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TPLN_CARRY_QUE"
            strSQL &= vbCrLf & "   ,TPRG_TRK_BUF"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "    1 = 1"
            strSQL &= vbCrLf & "    AND TPLN_CARRY_QUE.FPALLET_ID = TPRG_TRK_BUF.FPALLET_ID"                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧと結合
            strSQL &= vbCrLf & "    AND TPLN_CARRY_QUE.FCARRYQUE_DIR_STS = " & FCARRYQUE_DIR_STS_SNON & ""      '搬送指示QUE    .搬送指示状況
            strSQL &= vbCrLf & "    AND TPLN_CARRY_QUE.FCARRYQUE_KUBUN IN (" & FCARRYQUE_KUBUN_SOUT & ")"       '搬送指示QUE    .指示区分
            strSQL &= vbCrLf & "    AND TPLN_CARRY_QUE.FEQ_ID = '" & mFEQ_ID & "'"                              '搬送指示QUE    .設備ID
            If intWhereMode = WhereMode.IN_Mode Then
                strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FTR_TO IN(" & mFTR_TO & ")"                                  '搬送指示QUE    .設備ID
            Else
                strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FTR_TO NOT IN(" & mFTR_TO & ")"                                  '搬送指示QUE    .設備ID
            End If
            strSQL &= vbCrLf & " ORDER BY"
            strSQL &= vbCrLf & "    TPLN_CARRY_QUE.FPRIORITY DESC"                  '搬送指示QUE  .ﾌﾟﾗｲｵﾘﾃｨ区分
            strSQL &= vbCrLf & "   ,TPLN_CARRY_QUE.FCARRYQUE_D "                    '搬送指示QUE  .搬送指示日
            strSQL &= vbCrLf & "   ,TPLN_CARRY_QUE.FCARRYQUE_ORDER "                '搬送指示QUE  .搬送順№
            strSQL &= vbCrLf


            '***********************
            '抽出
            '***********************
            mstrUSER_SQL = strSQL
            intRet = GET_TPLN_CARRY_QUE_USER()


            Return (intRet)
        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
