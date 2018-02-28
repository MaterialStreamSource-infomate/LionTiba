'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation All Rights Reserved
'
' 【名称】MaterialStreamﾃｰﾌﾞﾙｸﾗｽ
' 【機能】変更履歴表示ﾏｽﾀﾃｰﾌﾞﾙｸﾗｽ
' 【作成】2008/08/31  KSH                                   Rev 0.00
'**********************************************************************************************

#Region "  Imports"
Imports System
Imports System.Text
Imports MateCommon
Imports MateCommon.clsConst
Imports JobCommon
#End Region

''' <summary>
''' 変更履歴表示ﾏｽﾀﾃｰﾌﾞﾙｸﾗｽ
''' </summary>
Public Class TBL_TMST_TBLCHANGE
    Inherits clsTemplateTable

    '**********************************************************************************************
    '↓↓↓自動生成部
#Region "  ｸﾗｽ変数定義                  "
    'ﾌﾟﾛﾊﾟﾃｨ
    Private mobjAryMe As TBL_TMST_TBLCHANGE()                                    '変更履歴表示ﾏｽﾀ
    Private mstrUSER_SQL As String                                               'ﾕｰｻﾞｰSQL
    Private mORDER_BY As String                                                  'OrderBy句
    Private mWHERE As String                                                     'Where句
    Private mFSYORI_ID As String                                                 '処理ID
    Private mFTABLE_NAME As String                                               'ﾃｰﾌﾞﾙ名
    Private mFFIELD_NAME As String                                               'ﾌｨｰﾙﾄﾞ名
    Private mFGAMEN_DISP As String                                               '表示用名称
    Private mFWIDTH_CELL As Nullable(Of Integer)                                 'ｾﾙ幅
    Private mFORDER As Nullable(Of Integer)                                      '表示順
    Private mFTEXT_ALIGN As Nullable(Of Integer)                                 'ﾃｷｽﾄ配置位置
    Private mFDISP_FORMAT As String                                              '表示ﾌｫｰﾏｯﾄ
    Private mFLISTDSP_FLAG As Nullable(Of Integer)                               '一覧表示ﾌﾗｸﾞ
    Private mFDTLDSP_FLAG As Nullable(Of Integer)                                '詳細一覧表示ﾌﾗｸﾞ
    Private mFDATA_TYPE As Nullable(Of Integer)                                  'ﾃﾞｰﾀﾀｲﾌﾟ
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                  "
    ''' <summary>
    ''' ｼｽﾃﾑ変数 (自ｸﾗｽ型配列)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_TMST_TBLCHANGE()
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
    ''' 処理ID
    ''' </summary>
    Public Property FSYORI_ID() As String
        Get
            Return mFSYORI_ID
        End Get
        Set(ByVal Value As String)
            mFSYORI_ID = Value
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
    ''' <summary>
    ''' 表示用名称
    ''' </summary>
    Public Property FGAMEN_DISP() As String
        Get
            Return mFGAMEN_DISP
        End Get
        Set(ByVal Value As String)
            mFGAMEN_DISP = Value
        End Set
    End Property
    ''' <summary>
    ''' ｾﾙ幅
    ''' </summary>
    Public Property FWIDTH_CELL() As Nullable(Of Integer)
        Get
            Return mFWIDTH_CELL
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFWIDTH_CELL = Value
        End Set
    End Property
    ''' <summary>
    ''' 表示順
    ''' </summary>
    Public Property FORDER() As Nullable(Of Integer)
        Get
            Return mFORDER
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFORDER = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾃｷｽﾄ配置位置
    ''' </summary>
    Public Property FTEXT_ALIGN() As Nullable(Of Integer)
        Get
            Return mFTEXT_ALIGN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFTEXT_ALIGN = Value
        End Set
    End Property
    ''' <summary>
    ''' 表示ﾌｫｰﾏｯﾄ
    ''' </summary>
    Public Property FDISP_FORMAT() As String
        Get
            Return mFDISP_FORMAT
        End Get
        Set(ByVal Value As String)
            mFDISP_FORMAT = Value
        End Set
    End Property
    ''' <summary>
    ''' 一覧表示ﾌﾗｸﾞ
    ''' </summary>
    Public Property FLISTDSP_FLAG() As Nullable(Of Integer)
        Get
            Return mFLISTDSP_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFLISTDSP_FLAG = Value
        End Set
    End Property
    ''' <summary>
    ''' 詳細一覧表示ﾌﾗｸﾞ
    ''' </summary>
    Public Property FDTLDSP_FLAG() As Nullable(Of Integer)
        Get
            Return mFDTLDSP_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFDTLDSP_FLAG = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾃﾞｰﾀﾀｲﾌﾟ
    ''' </summary>
    Public Property FDATA_TYPE() As Nullable(Of Integer)
        Get
            Return mFDATA_TYPE
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFDATA_TYPE = Value
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
    Public Function GET_TMST_TBLCHANGE(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    TMST_TBLCHANGE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FSYORI_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYORI_ID
            strSQL.Append(vbCrLf & "    AND FSYORI_ID = :" & UBound(strBindField) - 1 & " --処理ID")
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
        If IsNull(FGAMEN_DISP) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGAMEN_DISP
            strSQL.Append(vbCrLf & "    AND FGAMEN_DISP = :" & UBound(strBindField) - 1 & " --表示用名称")
        End If
        If IsNull(FWIDTH_CELL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFWIDTH_CELL
            strSQL.Append(vbCrLf & "    AND FWIDTH_CELL = :" & UBound(strBindField) - 1 & " --ｾﾙ幅")
        End If
        If IsNull(FORDER) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFORDER
            strSQL.Append(vbCrLf & "    AND FORDER = :" & UBound(strBindField) - 1 & " --表示順")
        End If
        If IsNull(FTEXT_ALIGN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTEXT_ALIGN
            strSQL.Append(vbCrLf & "    AND FTEXT_ALIGN = :" & UBound(strBindField) - 1 & " --ﾃｷｽﾄ配置位置")
        End If
        If IsNull(FDISP_FORMAT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_FORMAT
            strSQL.Append(vbCrLf & "    AND FDISP_FORMAT = :" & UBound(strBindField) - 1 & " --表示ﾌｫｰﾏｯﾄ")
        End If
        If IsNull(FLISTDSP_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLISTDSP_FLAG
            strSQL.Append(vbCrLf & "    AND FLISTDSP_FLAG = :" & UBound(strBindField) - 1 & " --一覧表示ﾌﾗｸﾞ")
        End If
        If IsNull(FDTLDSP_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDTLDSP_FLAG
            strSQL.Append(vbCrLf & "    AND FDTLDSP_FLAG = :" & UBound(strBindField) - 1 & " --詳細一覧表示ﾌﾗｸﾞ")
        End If
        If IsNull(FDATA_TYPE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDATA_TYPE
            strSQL.Append(vbCrLf & "    AND FDATA_TYPE = :" & UBound(strBindField) - 1 & " --ﾃﾞｰﾀﾀｲﾌﾟ")
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
        strDataSetName = "TMST_TBLCHANGE"
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
    Public Function GET_TMST_TBLCHANGE_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    TMST_TBLCHANGE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FSYORI_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYORI_ID
            strSQL.Append(vbCrLf & "    AND FSYORI_ID = :" & UBound(strBindField) - 1 & " --処理ID")
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
        If IsNull(FGAMEN_DISP) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGAMEN_DISP
            strSQL.Append(vbCrLf & "    AND FGAMEN_DISP = :" & UBound(strBindField) - 1 & " --表示用名称")
        End If
        If IsNull(FWIDTH_CELL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFWIDTH_CELL
            strSQL.Append(vbCrLf & "    AND FWIDTH_CELL = :" & UBound(strBindField) - 1 & " --ｾﾙ幅")
        End If
        If IsNull(FORDER) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFORDER
            strSQL.Append(vbCrLf & "    AND FORDER = :" & UBound(strBindField) - 1 & " --表示順")
        End If
        If IsNull(FTEXT_ALIGN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTEXT_ALIGN
            strSQL.Append(vbCrLf & "    AND FTEXT_ALIGN = :" & UBound(strBindField) - 1 & " --ﾃｷｽﾄ配置位置")
        End If
        If IsNull(FDISP_FORMAT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_FORMAT
            strSQL.Append(vbCrLf & "    AND FDISP_FORMAT = :" & UBound(strBindField) - 1 & " --表示ﾌｫｰﾏｯﾄ")
        End If
        If IsNull(FLISTDSP_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLISTDSP_FLAG
            strSQL.Append(vbCrLf & "    AND FLISTDSP_FLAG = :" & UBound(strBindField) - 1 & " --一覧表示ﾌﾗｸﾞ")
        End If
        If IsNull(FDTLDSP_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDTLDSP_FLAG
            strSQL.Append(vbCrLf & "    AND FDTLDSP_FLAG = :" & UBound(strBindField) - 1 & " --詳細一覧表示ﾌﾗｸﾞ")
        End If
        If IsNull(FDATA_TYPE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDATA_TYPE
            strSQL.Append(vbCrLf & "    AND FDATA_TYPE = :" & UBound(strBindField) - 1 & " --ﾃﾞｰﾀﾀｲﾌﾟ")
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
        strDataSetName = "TMST_TBLCHANGE"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TMST_TBLCHANGE(Owner, objDb, objDbLog)
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
    Public Function GET_TMST_TBLCHANGE_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "TMST_TBLCHANGE"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TMST_TBLCHANGE(Owner, objDb, objDbLog)
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
    Public Function GET_TMST_TBLCHANGE_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    TMST_TBLCHANGE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FSYORI_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYORI_ID
            strSQL.Append(vbCrLf & "    AND FSYORI_ID = :" & UBound(strBindField) - 1 & " --処理ID")
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
        If IsNull(FGAMEN_DISP) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGAMEN_DISP
            strSQL.Append(vbCrLf & "    AND FGAMEN_DISP = :" & UBound(strBindField) - 1 & " --表示用名称")
        End If
        If IsNull(FWIDTH_CELL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFWIDTH_CELL
            strSQL.Append(vbCrLf & "    AND FWIDTH_CELL = :" & UBound(strBindField) - 1 & " --ｾﾙ幅")
        End If
        If IsNull(FORDER) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFORDER
            strSQL.Append(vbCrLf & "    AND FORDER = :" & UBound(strBindField) - 1 & " --表示順")
        End If
        If IsNull(FTEXT_ALIGN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTEXT_ALIGN
            strSQL.Append(vbCrLf & "    AND FTEXT_ALIGN = :" & UBound(strBindField) - 1 & " --ﾃｷｽﾄ配置位置")
        End If
        If IsNull(FDISP_FORMAT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_FORMAT
            strSQL.Append(vbCrLf & "    AND FDISP_FORMAT = :" & UBound(strBindField) - 1 & " --表示ﾌｫｰﾏｯﾄ")
        End If
        If IsNull(FLISTDSP_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLISTDSP_FLAG
            strSQL.Append(vbCrLf & "    AND FLISTDSP_FLAG = :" & UBound(strBindField) - 1 & " --一覧表示ﾌﾗｸﾞ")
        End If
        If IsNull(FDTLDSP_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDTLDSP_FLAG
            strSQL.Append(vbCrLf & "    AND FDTLDSP_FLAG = :" & UBound(strBindField) - 1 & " --詳細一覧表示ﾌﾗｸﾞ")
        End If
        If IsNull(FDATA_TYPE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDATA_TYPE
            strSQL.Append(vbCrLf & "    AND FDATA_TYPE = :" & UBound(strBindField) - 1 & " --ﾃﾞｰﾀﾀｲﾌﾟ")
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
        strDataSetName = "TMST_TBLCHANGE"
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
    Public Sub UPDATE_TMST_TBLCHANGE()
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
        ElseIf IsNull(mFSYORI_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[処理ID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFTABLE_NAME) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾃｰﾌﾞﾙ名]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFFIELD_NAME) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾌｨｰﾙﾄﾞ名]"
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
        strSQL.Append(vbCrLf & "    TMST_TBLCHANGE")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
        If IsNull(mFSYORI_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSYORI_ID = NULL --処理ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSYORI_ID = NULL --処理ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYORI_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSYORI_ID = :" & Ubound(strBindField) - 1 & " --処理ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSYORI_ID = :" & Ubound(strBindField) - 1 & " --処理ID")
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
        If IsNull(mFGAMEN_DISP) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FGAMEN_DISP = NULL --表示用名称")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FGAMEN_DISP = NULL --表示用名称")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGAMEN_DISP
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FGAMEN_DISP = :" & Ubound(strBindField) - 1 & " --表示用名称")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FGAMEN_DISP = :" & Ubound(strBindField) - 1 & " --表示用名称")
        End If
        intCount = intCount + 1
        If IsNull(mFWIDTH_CELL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FWIDTH_CELL = NULL --ｾﾙ幅")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FWIDTH_CELL = NULL --ｾﾙ幅")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFWIDTH_CELL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FWIDTH_CELL = :" & Ubound(strBindField) - 1 & " --ｾﾙ幅")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FWIDTH_CELL = :" & Ubound(strBindField) - 1 & " --ｾﾙ幅")
        End If
        intCount = intCount + 1
        If IsNull(mFORDER) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FORDER = NULL --表示順")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FORDER = NULL --表示順")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFORDER
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FORDER = :" & Ubound(strBindField) - 1 & " --表示順")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FORDER = :" & Ubound(strBindField) - 1 & " --表示順")
        End If
        intCount = intCount + 1
        If IsNull(mFTEXT_ALIGN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTEXT_ALIGN = NULL --ﾃｷｽﾄ配置位置")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTEXT_ALIGN = NULL --ﾃｷｽﾄ配置位置")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTEXT_ALIGN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTEXT_ALIGN = :" & Ubound(strBindField) - 1 & " --ﾃｷｽﾄ配置位置")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTEXT_ALIGN = :" & Ubound(strBindField) - 1 & " --ﾃｷｽﾄ配置位置")
        End If
        intCount = intCount + 1
        If IsNull(mFDISP_FORMAT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDISP_FORMAT = NULL --表示ﾌｫｰﾏｯﾄ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDISP_FORMAT = NULL --表示ﾌｫｰﾏｯﾄ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_FORMAT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDISP_FORMAT = :" & Ubound(strBindField) - 1 & " --表示ﾌｫｰﾏｯﾄ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDISP_FORMAT = :" & Ubound(strBindField) - 1 & " --表示ﾌｫｰﾏｯﾄ")
        End If
        intCount = intCount + 1
        If IsNull(mFLISTDSP_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLISTDSP_FLAG = NULL --一覧表示ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLISTDSP_FLAG = NULL --一覧表示ﾌﾗｸﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLISTDSP_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLISTDSP_FLAG = :" & Ubound(strBindField) - 1 & " --一覧表示ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLISTDSP_FLAG = :" & Ubound(strBindField) - 1 & " --一覧表示ﾌﾗｸﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFDTLDSP_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDTLDSP_FLAG = NULL --詳細一覧表示ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDTLDSP_FLAG = NULL --詳細一覧表示ﾌﾗｸﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDTLDSP_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDTLDSP_FLAG = :" & Ubound(strBindField) - 1 & " --詳細一覧表示ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDTLDSP_FLAG = :" & Ubound(strBindField) - 1 & " --詳細一覧表示ﾌﾗｸﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFDATA_TYPE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDATA_TYPE = NULL --ﾃﾞｰﾀﾀｲﾌﾟ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDATA_TYPE = NULL --ﾃﾞｰﾀﾀｲﾌﾟ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDATA_TYPE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDATA_TYPE = :" & Ubound(strBindField) - 1 & " --ﾃﾞｰﾀﾀｲﾌﾟ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDATA_TYPE = :" & Ubound(strBindField) - 1 & " --ﾃﾞｰﾀﾀｲﾌﾟ")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FSYORI_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FSYORI_ID IS NULL --処理ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYORI_ID
            strSQL.Append(vbCrLf & "    AND FSYORI_ID = :" & UBound(strBindField) - 1 & " --処理ID")
        End If
        If IsNull(FTABLE_NAME) = True Then
            strSQL.Append(vbCrLf & "    AND FTABLE_NAME IS NULL --ﾃｰﾌﾞﾙ名")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTABLE_NAME
            strSQL.Append(vbCrLf & "    AND FTABLE_NAME = :" & UBound(strBindField) - 1 & " --ﾃｰﾌﾞﾙ名")
        End If
        If IsNull(FFIELD_NAME) = True Then
            strSQL.Append(vbCrLf & "    AND FFIELD_NAME IS NULL --ﾌｨｰﾙﾄﾞ名")
        Else
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
    Public Sub ADD_TMST_TBLCHANGE()
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
        ElseIf IsNull(mFSYORI_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[処理ID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFTABLE_NAME) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾃｰﾌﾞﾙ名]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFFIELD_NAME) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾌｨｰﾙﾄﾞ名]"
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
        strSQL.Append(vbCrLf & "    TMST_TBLCHANGE")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
        If IsNull(mFSYORI_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --処理ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --処理ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYORI_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --処理ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --処理ID")
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
        If IsNull(mFGAMEN_DISP) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --表示用名称")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --表示用名称")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGAMEN_DISP
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --表示用名称")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --表示用名称")
        End If
        intCount = intCount + 1
        If IsNull(mFWIDTH_CELL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｾﾙ幅")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｾﾙ幅")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFWIDTH_CELL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｾﾙ幅")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｾﾙ幅")
        End If
        intCount = intCount + 1
        If IsNull(mFORDER) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --表示順")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --表示順")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFORDER
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --表示順")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --表示順")
        End If
        intCount = intCount + 1
        If IsNull(mFTEXT_ALIGN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾃｷｽﾄ配置位置")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾃｷｽﾄ配置位置")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTEXT_ALIGN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾃｷｽﾄ配置位置")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾃｷｽﾄ配置位置")
        End If
        intCount = intCount + 1
        If IsNull(mFDISP_FORMAT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --表示ﾌｫｰﾏｯﾄ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --表示ﾌｫｰﾏｯﾄ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_FORMAT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --表示ﾌｫｰﾏｯﾄ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --表示ﾌｫｰﾏｯﾄ")
        End If
        intCount = intCount + 1
        If IsNull(mFLISTDSP_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --一覧表示ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --一覧表示ﾌﾗｸﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLISTDSP_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --一覧表示ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --一覧表示ﾌﾗｸﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFDTLDSP_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --詳細一覧表示ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --詳細一覧表示ﾌﾗｸﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDTLDSP_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --詳細一覧表示ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --詳細一覧表示ﾌﾗｸﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFDATA_TYPE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾃﾞｰﾀﾀｲﾌﾟ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾃﾞｰﾀﾀｲﾌﾟ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDATA_TYPE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾃﾞｰﾀﾀｲﾌﾟ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾃﾞｰﾀﾀｲﾌﾟ")
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
    Public Sub DELETE_TMST_TBLCHANGE()
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
        ElseIf IsNull(mFSYORI_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[処理ID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFTABLE_NAME) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾃｰﾌﾞﾙ名]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFFIELD_NAME) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾌｨｰﾙﾄﾞ名]"
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
        strSQL.Append(vbCrLf & "    TMST_TBLCHANGE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FSYORI_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FSYORI_ID IS NULL --処理ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYORI_ID
            strSQL.Append(vbCrLf & "    AND FSYORI_ID = :" & UBound(strBindField) - 1 & " --処理ID")
        End If
        If IsNull(FTABLE_NAME) = True Then
            strSQL.Append(vbCrLf & "    AND FTABLE_NAME IS NULL --ﾃｰﾌﾞﾙ名")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTABLE_NAME
            strSQL.Append(vbCrLf & "    AND FTABLE_NAME = :" & UBound(strBindField) - 1 & " --ﾃｰﾌﾞﾙ名")
        End If
        If IsNull(FFIELD_NAME) = True Then
            strSQL.Append(vbCrLf & "    AND FFIELD_NAME IS NULL --ﾌｨｰﾙﾄﾞ名")
        Else
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
#Region "  ﾃﾞｰﾀ削除(複数ﾚｺｰﾄﾞ)          "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀ削除
    ''' </summary>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Sub DELETE_TMST_TBLCHANGE_ANY()
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
        strSQL.Append(vbCrLf & "    TMST_TBLCHANGE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(FSYORI_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYORI_ID
            strSQL.Append(vbCrLf & "    AND FSYORI_ID = :" & UBound(strBindField) - 1 & " --処理ID")
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
        If IsNotNull(FGAMEN_DISP) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGAMEN_DISP
            strSQL.Append(vbCrLf & "    AND FGAMEN_DISP = :" & UBound(strBindField) - 1 & " --表示用名称")
        End If
        If IsNotNull(FWIDTH_CELL) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFWIDTH_CELL
            strSQL.Append(vbCrLf & "    AND FWIDTH_CELL = :" & UBound(strBindField) - 1 & " --ｾﾙ幅")
        End If
        If IsNotNull(FORDER) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFORDER
            strSQL.Append(vbCrLf & "    AND FORDER = :" & UBound(strBindField) - 1 & " --表示順")
        End If
        If IsNotNull(FTEXT_ALIGN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTEXT_ALIGN
            strSQL.Append(vbCrLf & "    AND FTEXT_ALIGN = :" & UBound(strBindField) - 1 & " --ﾃｷｽﾄ配置位置")
        End If
        If IsNotNull(FDISP_FORMAT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_FORMAT
            strSQL.Append(vbCrLf & "    AND FDISP_FORMAT = :" & UBound(strBindField) - 1 & " --表示ﾌｫｰﾏｯﾄ")
        End If
        If IsNotNull(FLISTDSP_FLAG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLISTDSP_FLAG
            strSQL.Append(vbCrLf & "    AND FLISTDSP_FLAG = :" & UBound(strBindField) - 1 & " --一覧表示ﾌﾗｸﾞ")
        End If
        If IsNotNull(FDTLDSP_FLAG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDTLDSP_FLAG
            strSQL.Append(vbCrLf & "    AND FDTLDSP_FLAG = :" & UBound(strBindField) - 1 & " --詳細一覧表示ﾌﾗｸﾞ")
        End If
        If IsNotNull(FDATA_TYPE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDATA_TYPE
            strSQL.Append(vbCrLf & "    AND FDATA_TYPE = :" & UBound(strBindField) - 1 & " --ﾃﾞｰﾀﾀｲﾌﾟ")
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
        If IsNothing(objType.GetProperty("FSYORI_ID")) = False Then mFSYORI_ID = objObject.FSYORI_ID '処理ID
        If IsNothing(objType.GetProperty("FTABLE_NAME")) = False Then mFTABLE_NAME = objObject.FTABLE_NAME 'ﾃｰﾌﾞﾙ名
        If IsNothing(objType.GetProperty("FFIELD_NAME")) = False Then mFFIELD_NAME = objObject.FFIELD_NAME 'ﾌｨｰﾙﾄﾞ名
        If IsNothing(objType.GetProperty("FGAMEN_DISP")) = False Then mFGAMEN_DISP = objObject.FGAMEN_DISP '表示用名称
        If IsNothing(objType.GetProperty("FWIDTH_CELL")) = False Then mFWIDTH_CELL = objObject.FWIDTH_CELL 'ｾﾙ幅
        If IsNothing(objType.GetProperty("FORDER")) = False Then mFORDER = objObject.FORDER '表示順
        If IsNothing(objType.GetProperty("FTEXT_ALIGN")) = False Then mFTEXT_ALIGN = objObject.FTEXT_ALIGN 'ﾃｷｽﾄ配置位置
        If IsNothing(objType.GetProperty("FDISP_FORMAT")) = False Then mFDISP_FORMAT = objObject.FDISP_FORMAT '表示ﾌｫｰﾏｯﾄ
        If IsNothing(objType.GetProperty("FLISTDSP_FLAG")) = False Then mFLISTDSP_FLAG = objObject.FLISTDSP_FLAG '一覧表示ﾌﾗｸﾞ
        If IsNothing(objType.GetProperty("FDTLDSP_FLAG")) = False Then mFDTLDSP_FLAG = objObject.FDTLDSP_FLAG '詳細一覧表示ﾌﾗｸﾞ
        If IsNothing(objType.GetProperty("FDATA_TYPE")) = False Then mFDATA_TYPE = objObject.FDATA_TYPE 'ﾃﾞｰﾀﾀｲﾌﾟ

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
        mFSYORI_ID = Nothing
        mFTABLE_NAME = Nothing
        mFFIELD_NAME = Nothing
        mFGAMEN_DISP = Nothing
        mFWIDTH_CELL = Nothing
        mFORDER = Nothing
        mFTEXT_ALIGN = Nothing
        mFDISP_FORMAT = Nothing
        mFLISTDSP_FLAG = Nothing
        mFDTLDSP_FLAG = Nothing
        mFDATA_TYPE = Nothing


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
        mFSYORI_ID = TO_STRING_NULLABLE(objRow("FSYORI_ID"))
        mFTABLE_NAME = TO_STRING_NULLABLE(objRow("FTABLE_NAME"))
        mFFIELD_NAME = TO_STRING_NULLABLE(objRow("FFIELD_NAME"))
        mFGAMEN_DISP = TO_STRING_NULLABLE(objRow("FGAMEN_DISP"))
        mFWIDTH_CELL = TO_INTEGER_NULLABLE(objRow("FWIDTH_CELL"))
        mFORDER = TO_INTEGER_NULLABLE(objRow("FORDER"))
        mFTEXT_ALIGN = TO_INTEGER_NULLABLE(objRow("FTEXT_ALIGN"))
        mFDISP_FORMAT = TO_STRING_NULLABLE(objRow("FDISP_FORMAT"))
        mFLISTDSP_FLAG = TO_INTEGER_NULLABLE(objRow("FLISTDSP_FLAG"))
        mFDTLDSP_FLAG = TO_INTEGER_NULLABLE(objRow("FDTLDSP_FLAG"))
        mFDATA_TYPE = TO_INTEGER_NULLABLE(objRow("FDATA_TYPE"))


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
        strMsg &= "[ﾃｰﾌﾞﾙ名:変更履歴表示ﾏｽﾀ]"
        If IsNotNull(FSYORI_ID) Then
            strMsg &= "[処理ID:" & FSYORI_ID & "]"
        End If
        If IsNotNull(FTABLE_NAME) Then
            strMsg &= "[ﾃｰﾌﾞﾙ名:" & FTABLE_NAME & "]"
        End If
        If IsNotNull(FFIELD_NAME) Then
            strMsg &= "[ﾌｨｰﾙﾄﾞ名:" & FFIELD_NAME & "]"
        End If
        If IsNotNull(FGAMEN_DISP) Then
            strMsg &= "[表示用名称:" & FGAMEN_DISP & "]"
        End If
        If IsNotNull(FWIDTH_CELL) Then
            strMsg &= "[ｾﾙ幅:" & FWIDTH_CELL & "]"
        End If
        If IsNotNull(FORDER) Then
            strMsg &= "[表示順:" & FORDER & "]"
        End If
        If IsNotNull(FTEXT_ALIGN) Then
            strMsg &= "[ﾃｷｽﾄ配置位置:" & FTEXT_ALIGN & "]"
        End If
        If IsNotNull(FDISP_FORMAT) Then
            strMsg &= "[表示ﾌｫｰﾏｯﾄ:" & FDISP_FORMAT & "]"
        End If
        If IsNotNull(FLISTDSP_FLAG) Then
            strMsg &= "[一覧表示ﾌﾗｸﾞ:" & FLISTDSP_FLAG & "]"
        End If
        If IsNotNull(FDTLDSP_FLAG) Then
            strMsg &= "[詳細一覧表示ﾌﾗｸﾞ:" & FDTLDSP_FLAG & "]"
        End If
        If IsNotNull(FDATA_TYPE) Then
            strMsg &= "[ﾃﾞｰﾀﾀｲﾌﾟ:" & FDATA_TYPE & "]"
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
