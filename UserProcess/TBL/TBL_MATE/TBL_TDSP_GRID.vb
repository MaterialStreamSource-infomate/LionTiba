'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' 【名称】MaterialStreamﾃｰﾌﾞﾙｸﾗｽ
' 【機能】ｸﾞﾘｯﾄﾞﾏｽﾀﾃｰﾌﾞﾙｸﾗｽ
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
''' ｸﾞﾘｯﾄﾞﾏｽﾀﾃｰﾌﾞﾙｸﾗｽ
''' </summary>
Public Class TBL_TDSP_GRID
    Inherits clsTemplateTable

    '**********************************************************************************************
    '↓↓↓自動生成部
#Region "  ｸﾗｽ変数定義                  "
    'ﾌﾟﾛﾊﾟﾃｨ
    Private mobjAryMe As TBL_TDSP_GRID()                                         'ｸﾞﾘｯﾄﾞﾏｽﾀ
    Private mstrUSER_SQL As String                                               'ﾕｰｻﾞｰSQL
    Private mORDER_BY As String                                                  'OrderBy句
    Private mWHERE As String                                                     'Where句
    Private mFDISP_ID As String                                                  '画面ID
    Private mFCTRL_ID As String                                                  'ｺﾝﾄﾛｰﾙID
    Private mFCOL_INDEX As Nullable(Of Integer)                                  '列ｲﾝﾃﾞｯｸｽ
    Private mFGRID_DISPLAYINDEX As Nullable(Of Integer)                          'ｸﾞﾘｯﾄﾞ列表示順序
    Private mFGRID_ORDER_BY As Nullable(Of Integer)                              'ｸﾞﾘｯﾄﾞｵｰﾀﾞｰ優先順
    Private mFGRID_ORDER_ASCDESC As String                                       'ｸﾞﾘｯﾄﾞｵｰﾀﾞｰ昇順降順
    Private mFGRID_H_TEXT As String                                              'ｸﾞﾘｯﾄﾞﾍｯﾀﾞｰﾃｷｽﾄ
    Private mFGRID_H_ALIGNMENT As String                                         'ｸﾞﾘｯﾄﾞﾍｯﾀﾞｰ配置
    Private mFGRID_D_ALIGNMENT As String                                         'ｸﾞﾘｯﾄﾞﾃﾞｰﾀ配置
    Private mFGRID_D_FORMAT As String                                            'ｸﾞﾘｯﾄﾞﾃﾞｰﾀﾌｫｰﾏｯﾄ
    Private mFGRID_D_WIDTH As String                                             'ｸﾞﾘｯﾄﾞﾃﾞｰﾀ幅
    Private mFGRID_COL_DISP_FLAG As Nullable(Of Integer)                         'ｸﾞﾘｯﾄﾞ列表示ﾌﾗｸﾞ
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                  "
    ''' <summary>
    ''' ｼｽﾃﾑ変数 (自ｸﾗｽ型配列)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_TDSP_GRID()
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
    ''' 列ｲﾝﾃﾞｯｸｽ
    ''' </summary>
    Public Property FCOL_INDEX() As Nullable(Of Integer)
        Get
            Return mFCOL_INDEX
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFCOL_INDEX = Value
        End Set
    End Property
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ列表示順序
    ''' </summary>
    Public Property FGRID_DISPLAYINDEX() As Nullable(Of Integer)
        Get
            Return mFGRID_DISPLAYINDEX
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFGRID_DISPLAYINDEX = Value
        End Set
    End Property
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞｵｰﾀﾞｰ優先順
    ''' </summary>
    Public Property FGRID_ORDER_BY() As Nullable(Of Integer)
        Get
            Return mFGRID_ORDER_BY
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFGRID_ORDER_BY = Value
        End Set
    End Property
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞｵｰﾀﾞｰ昇順降順
    ''' </summary>
    Public Property FGRID_ORDER_ASCDESC() As String
        Get
            Return mFGRID_ORDER_ASCDESC
        End Get
        Set(ByVal Value As String)
            mFGRID_ORDER_ASCDESC = Value
        End Set
    End Property
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞﾍｯﾀﾞｰﾃｷｽﾄ
    ''' </summary>
    Public Property FGRID_H_TEXT() As String
        Get
            Return mFGRID_H_TEXT
        End Get
        Set(ByVal Value As String)
            mFGRID_H_TEXT = Value
        End Set
    End Property
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞﾍｯﾀﾞｰ配置
    ''' </summary>
    Public Property FGRID_H_ALIGNMENT() As String
        Get
            Return mFGRID_H_ALIGNMENT
        End Get
        Set(ByVal Value As String)
            mFGRID_H_ALIGNMENT = Value
        End Set
    End Property
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞﾃﾞｰﾀ配置
    ''' </summary>
    Public Property FGRID_D_ALIGNMENT() As String
        Get
            Return mFGRID_D_ALIGNMENT
        End Get
        Set(ByVal Value As String)
            mFGRID_D_ALIGNMENT = Value
        End Set
    End Property
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞﾃﾞｰﾀﾌｫｰﾏｯﾄ
    ''' </summary>
    Public Property FGRID_D_FORMAT() As String
        Get
            Return mFGRID_D_FORMAT
        End Get
        Set(ByVal Value As String)
            mFGRID_D_FORMAT = Value
        End Set
    End Property
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞﾃﾞｰﾀ幅
    ''' </summary>
    Public Property FGRID_D_WIDTH() As String
        Get
            Return mFGRID_D_WIDTH
        End Get
        Set(ByVal Value As String)
            mFGRID_D_WIDTH = Value
        End Set
    End Property
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ列表示ﾌﾗｸﾞ
    ''' </summary>
    Public Property FGRID_COL_DISP_FLAG() As Nullable(Of Integer)
        Get
            Return mFGRID_COL_DISP_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFGRID_COL_DISP_FLAG = Value
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
    Public Function GET_TDSP_GRID(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    TDSP_GRID")
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
        If IsNull(FCOL_INDEX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOL_INDEX
            strSQL.Append(vbCrLf & "    AND FCOL_INDEX = :" & UBound(strBindField) - 1 & " --列ｲﾝﾃﾞｯｸｽ")
        End If
        If IsNull(FGRID_DISPLAYINDEX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_DISPLAYINDEX
            strSQL.Append(vbCrLf & "    AND FGRID_DISPLAYINDEX = :" & UBound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞ列表示順序")
        End If
        If IsNull(FGRID_ORDER_BY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_ORDER_BY
            strSQL.Append(vbCrLf & "    AND FGRID_ORDER_BY = :" & UBound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞｵｰﾀﾞｰ優先順")
        End If
        If IsNull(FGRID_ORDER_ASCDESC) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_ORDER_ASCDESC
            strSQL.Append(vbCrLf & "    AND FGRID_ORDER_ASCDESC = :" & UBound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞｵｰﾀﾞｰ昇順降順")
        End If
        If IsNull(FGRID_H_TEXT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_H_TEXT
            strSQL.Append(vbCrLf & "    AND FGRID_H_TEXT = :" & UBound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞﾍｯﾀﾞｰﾃｷｽﾄ")
        End If
        If IsNull(FGRID_H_ALIGNMENT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_H_ALIGNMENT
            strSQL.Append(vbCrLf & "    AND FGRID_H_ALIGNMENT = :" & UBound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞﾍｯﾀﾞｰ配置")
        End If
        If IsNull(FGRID_D_ALIGNMENT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_D_ALIGNMENT
            strSQL.Append(vbCrLf & "    AND FGRID_D_ALIGNMENT = :" & UBound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞﾃﾞｰﾀ配置")
        End If
        If IsNull(FGRID_D_FORMAT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_D_FORMAT
            strSQL.Append(vbCrLf & "    AND FGRID_D_FORMAT = :" & UBound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞﾃﾞｰﾀﾌｫｰﾏｯﾄ")
        End If
        If IsNull(FGRID_D_WIDTH) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_D_WIDTH
            strSQL.Append(vbCrLf & "    AND FGRID_D_WIDTH = :" & UBound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞﾃﾞｰﾀ幅")
        End If
        If IsNull(FGRID_COL_DISP_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_COL_DISP_FLAG
            strSQL.Append(vbCrLf & "    AND FGRID_COL_DISP_FLAG = :" & UBound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞ列表示ﾌﾗｸﾞ")
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
        strDataSetName = "TDSP_GRID"
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
    Public Function GET_TDSP_GRID_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    TDSP_GRID")
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
        If IsNull(FCOL_INDEX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOL_INDEX
            strSQL.Append(vbCrLf & "    AND FCOL_INDEX = :" & UBound(strBindField) - 1 & " --列ｲﾝﾃﾞｯｸｽ")
        End If
        If IsNull(FGRID_DISPLAYINDEX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_DISPLAYINDEX
            strSQL.Append(vbCrLf & "    AND FGRID_DISPLAYINDEX = :" & UBound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞ列表示順序")
        End If
        If IsNull(FGRID_ORDER_BY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_ORDER_BY
            strSQL.Append(vbCrLf & "    AND FGRID_ORDER_BY = :" & UBound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞｵｰﾀﾞｰ優先順")
        End If
        If IsNull(FGRID_ORDER_ASCDESC) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_ORDER_ASCDESC
            strSQL.Append(vbCrLf & "    AND FGRID_ORDER_ASCDESC = :" & UBound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞｵｰﾀﾞｰ昇順降順")
        End If
        If IsNull(FGRID_H_TEXT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_H_TEXT
            strSQL.Append(vbCrLf & "    AND FGRID_H_TEXT = :" & UBound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞﾍｯﾀﾞｰﾃｷｽﾄ")
        End If
        If IsNull(FGRID_H_ALIGNMENT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_H_ALIGNMENT
            strSQL.Append(vbCrLf & "    AND FGRID_H_ALIGNMENT = :" & UBound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞﾍｯﾀﾞｰ配置")
        End If
        If IsNull(FGRID_D_ALIGNMENT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_D_ALIGNMENT
            strSQL.Append(vbCrLf & "    AND FGRID_D_ALIGNMENT = :" & UBound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞﾃﾞｰﾀ配置")
        End If
        If IsNull(FGRID_D_FORMAT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_D_FORMAT
            strSQL.Append(vbCrLf & "    AND FGRID_D_FORMAT = :" & UBound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞﾃﾞｰﾀﾌｫｰﾏｯﾄ")
        End If
        If IsNull(FGRID_D_WIDTH) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_D_WIDTH
            strSQL.Append(vbCrLf & "    AND FGRID_D_WIDTH = :" & UBound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞﾃﾞｰﾀ幅")
        End If
        If IsNull(FGRID_COL_DISP_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_COL_DISP_FLAG
            strSQL.Append(vbCrLf & "    AND FGRID_COL_DISP_FLAG = :" & UBound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞ列表示ﾌﾗｸﾞ")
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
        strDataSetName = "TDSP_GRID"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TDSP_GRID(Owner, objDb, objDbLog)
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
    Public Function GET_TDSP_GRID_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "TDSP_GRID"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TDSP_GRID(Owner, objDb, objDbLog)
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
    Public Function GET_TDSP_GRID_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    TDSP_GRID")
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
        If IsNull(FCOL_INDEX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOL_INDEX
            strSQL.Append(vbCrLf & "    AND FCOL_INDEX = :" & UBound(strBindField) - 1 & " --列ｲﾝﾃﾞｯｸｽ")
        End If
        If IsNull(FGRID_DISPLAYINDEX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_DISPLAYINDEX
            strSQL.Append(vbCrLf & "    AND FGRID_DISPLAYINDEX = :" & UBound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞ列表示順序")
        End If
        If IsNull(FGRID_ORDER_BY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_ORDER_BY
            strSQL.Append(vbCrLf & "    AND FGRID_ORDER_BY = :" & UBound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞｵｰﾀﾞｰ優先順")
        End If
        If IsNull(FGRID_ORDER_ASCDESC) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_ORDER_ASCDESC
            strSQL.Append(vbCrLf & "    AND FGRID_ORDER_ASCDESC = :" & UBound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞｵｰﾀﾞｰ昇順降順")
        End If
        If IsNull(FGRID_H_TEXT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_H_TEXT
            strSQL.Append(vbCrLf & "    AND FGRID_H_TEXT = :" & UBound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞﾍｯﾀﾞｰﾃｷｽﾄ")
        End If
        If IsNull(FGRID_H_ALIGNMENT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_H_ALIGNMENT
            strSQL.Append(vbCrLf & "    AND FGRID_H_ALIGNMENT = :" & UBound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞﾍｯﾀﾞｰ配置")
        End If
        If IsNull(FGRID_D_ALIGNMENT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_D_ALIGNMENT
            strSQL.Append(vbCrLf & "    AND FGRID_D_ALIGNMENT = :" & UBound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞﾃﾞｰﾀ配置")
        End If
        If IsNull(FGRID_D_FORMAT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_D_FORMAT
            strSQL.Append(vbCrLf & "    AND FGRID_D_FORMAT = :" & UBound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞﾃﾞｰﾀﾌｫｰﾏｯﾄ")
        End If
        If IsNull(FGRID_D_WIDTH) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_D_WIDTH
            strSQL.Append(vbCrLf & "    AND FGRID_D_WIDTH = :" & UBound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞﾃﾞｰﾀ幅")
        End If
        If IsNull(FGRID_COL_DISP_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_COL_DISP_FLAG
            strSQL.Append(vbCrLf & "    AND FGRID_COL_DISP_FLAG = :" & UBound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞ列表示ﾌﾗｸﾞ")
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
        strDataSetName = "TDSP_GRID"
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
    Public Sub UPDATE_TDSP_GRID()
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
        strSQL.Append(vbCrLf & "    TDSP_GRID")
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
        If IsNull(mFCOL_INDEX) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCOL_INDEX = NULL --列ｲﾝﾃﾞｯｸｽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCOL_INDEX = NULL --列ｲﾝﾃﾞｯｸｽ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOL_INDEX
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCOL_INDEX = :" & Ubound(strBindField) - 1 & " --列ｲﾝﾃﾞｯｸｽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCOL_INDEX = :" & Ubound(strBindField) - 1 & " --列ｲﾝﾃﾞｯｸｽ")
        End If
        intCount = intCount + 1
        If IsNull(mFGRID_DISPLAYINDEX) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FGRID_DISPLAYINDEX = NULL --ｸﾞﾘｯﾄﾞ列表示順序")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FGRID_DISPLAYINDEX = NULL --ｸﾞﾘｯﾄﾞ列表示順序")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_DISPLAYINDEX
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FGRID_DISPLAYINDEX = :" & Ubound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞ列表示順序")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FGRID_DISPLAYINDEX = :" & Ubound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞ列表示順序")
        End If
        intCount = intCount + 1
        If IsNull(mFGRID_ORDER_BY) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FGRID_ORDER_BY = NULL --ｸﾞﾘｯﾄﾞｵｰﾀﾞｰ優先順")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FGRID_ORDER_BY = NULL --ｸﾞﾘｯﾄﾞｵｰﾀﾞｰ優先順")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_ORDER_BY
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FGRID_ORDER_BY = :" & Ubound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞｵｰﾀﾞｰ優先順")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FGRID_ORDER_BY = :" & Ubound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞｵｰﾀﾞｰ優先順")
        End If
        intCount = intCount + 1
        If IsNull(mFGRID_ORDER_ASCDESC) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FGRID_ORDER_ASCDESC = NULL --ｸﾞﾘｯﾄﾞｵｰﾀﾞｰ昇順降順")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FGRID_ORDER_ASCDESC = NULL --ｸﾞﾘｯﾄﾞｵｰﾀﾞｰ昇順降順")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_ORDER_ASCDESC
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FGRID_ORDER_ASCDESC = :" & Ubound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞｵｰﾀﾞｰ昇順降順")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FGRID_ORDER_ASCDESC = :" & Ubound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞｵｰﾀﾞｰ昇順降順")
        End If
        intCount = intCount + 1
        If IsNull(mFGRID_H_TEXT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FGRID_H_TEXT = NULL --ｸﾞﾘｯﾄﾞﾍｯﾀﾞｰﾃｷｽﾄ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FGRID_H_TEXT = NULL --ｸﾞﾘｯﾄﾞﾍｯﾀﾞｰﾃｷｽﾄ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_H_TEXT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FGRID_H_TEXT = :" & Ubound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞﾍｯﾀﾞｰﾃｷｽﾄ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FGRID_H_TEXT = :" & Ubound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞﾍｯﾀﾞｰﾃｷｽﾄ")
        End If
        intCount = intCount + 1
        If IsNull(mFGRID_H_ALIGNMENT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FGRID_H_ALIGNMENT = NULL --ｸﾞﾘｯﾄﾞﾍｯﾀﾞｰ配置")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FGRID_H_ALIGNMENT = NULL --ｸﾞﾘｯﾄﾞﾍｯﾀﾞｰ配置")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_H_ALIGNMENT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FGRID_H_ALIGNMENT = :" & Ubound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞﾍｯﾀﾞｰ配置")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FGRID_H_ALIGNMENT = :" & Ubound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞﾍｯﾀﾞｰ配置")
        End If
        intCount = intCount + 1
        If IsNull(mFGRID_D_ALIGNMENT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FGRID_D_ALIGNMENT = NULL --ｸﾞﾘｯﾄﾞﾃﾞｰﾀ配置")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FGRID_D_ALIGNMENT = NULL --ｸﾞﾘｯﾄﾞﾃﾞｰﾀ配置")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_D_ALIGNMENT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FGRID_D_ALIGNMENT = :" & Ubound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞﾃﾞｰﾀ配置")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FGRID_D_ALIGNMENT = :" & Ubound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞﾃﾞｰﾀ配置")
        End If
        intCount = intCount + 1
        If IsNull(mFGRID_D_FORMAT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FGRID_D_FORMAT = NULL --ｸﾞﾘｯﾄﾞﾃﾞｰﾀﾌｫｰﾏｯﾄ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FGRID_D_FORMAT = NULL --ｸﾞﾘｯﾄﾞﾃﾞｰﾀﾌｫｰﾏｯﾄ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_D_FORMAT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FGRID_D_FORMAT = :" & Ubound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞﾃﾞｰﾀﾌｫｰﾏｯﾄ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FGRID_D_FORMAT = :" & Ubound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞﾃﾞｰﾀﾌｫｰﾏｯﾄ")
        End If
        intCount = intCount + 1
        If IsNull(mFGRID_D_WIDTH) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FGRID_D_WIDTH = NULL --ｸﾞﾘｯﾄﾞﾃﾞｰﾀ幅")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FGRID_D_WIDTH = NULL --ｸﾞﾘｯﾄﾞﾃﾞｰﾀ幅")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_D_WIDTH
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FGRID_D_WIDTH = :" & Ubound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞﾃﾞｰﾀ幅")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FGRID_D_WIDTH = :" & Ubound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞﾃﾞｰﾀ幅")
        End If
        intCount = intCount + 1
        If IsNull(mFGRID_COL_DISP_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FGRID_COL_DISP_FLAG = NULL --ｸﾞﾘｯﾄﾞ列表示ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FGRID_COL_DISP_FLAG = NULL --ｸﾞﾘｯﾄﾞ列表示ﾌﾗｸﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_COL_DISP_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FGRID_COL_DISP_FLAG = :" & Ubound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞ列表示ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FGRID_COL_DISP_FLAG = :" & Ubound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞ列表示ﾌﾗｸﾞ")
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
        If IsNull(FCOL_INDEX) = True Then
            strSQL.Append(vbCrLf & "    AND FCOL_INDEX IS NULL --列ｲﾝﾃﾞｯｸｽ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOL_INDEX
            strSQL.Append(vbCrLf & "    AND FCOL_INDEX = :" & UBound(strBindField) - 1 & " --列ｲﾝﾃﾞｯｸｽ")
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
    Public Sub ADD_TDSP_GRID()
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
        strSQL.Append(vbCrLf & "    TDSP_GRID")
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
        If IsNull(mFCOL_INDEX) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --列ｲﾝﾃﾞｯｸｽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --列ｲﾝﾃﾞｯｸｽ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOL_INDEX
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --列ｲﾝﾃﾞｯｸｽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --列ｲﾝﾃﾞｯｸｽ")
        End If
        intCount = intCount + 1
        If IsNull(mFGRID_DISPLAYINDEX) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｸﾞﾘｯﾄﾞ列表示順序")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｸﾞﾘｯﾄﾞ列表示順序")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_DISPLAYINDEX
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞ列表示順序")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞ列表示順序")
        End If
        intCount = intCount + 1
        If IsNull(mFGRID_ORDER_BY) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｸﾞﾘｯﾄﾞｵｰﾀﾞｰ優先順")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｸﾞﾘｯﾄﾞｵｰﾀﾞｰ優先順")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_ORDER_BY
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞｵｰﾀﾞｰ優先順")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞｵｰﾀﾞｰ優先順")
        End If
        intCount = intCount + 1
        If IsNull(mFGRID_ORDER_ASCDESC) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｸﾞﾘｯﾄﾞｵｰﾀﾞｰ昇順降順")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｸﾞﾘｯﾄﾞｵｰﾀﾞｰ昇順降順")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_ORDER_ASCDESC
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞｵｰﾀﾞｰ昇順降順")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞｵｰﾀﾞｰ昇順降順")
        End If
        intCount = intCount + 1
        If IsNull(mFGRID_H_TEXT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｸﾞﾘｯﾄﾞﾍｯﾀﾞｰﾃｷｽﾄ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｸﾞﾘｯﾄﾞﾍｯﾀﾞｰﾃｷｽﾄ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_H_TEXT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞﾍｯﾀﾞｰﾃｷｽﾄ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞﾍｯﾀﾞｰﾃｷｽﾄ")
        End If
        intCount = intCount + 1
        If IsNull(mFGRID_H_ALIGNMENT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｸﾞﾘｯﾄﾞﾍｯﾀﾞｰ配置")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｸﾞﾘｯﾄﾞﾍｯﾀﾞｰ配置")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_H_ALIGNMENT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞﾍｯﾀﾞｰ配置")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞﾍｯﾀﾞｰ配置")
        End If
        intCount = intCount + 1
        If IsNull(mFGRID_D_ALIGNMENT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｸﾞﾘｯﾄﾞﾃﾞｰﾀ配置")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｸﾞﾘｯﾄﾞﾃﾞｰﾀ配置")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_D_ALIGNMENT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞﾃﾞｰﾀ配置")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞﾃﾞｰﾀ配置")
        End If
        intCount = intCount + 1
        If IsNull(mFGRID_D_FORMAT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｸﾞﾘｯﾄﾞﾃﾞｰﾀﾌｫｰﾏｯﾄ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｸﾞﾘｯﾄﾞﾃﾞｰﾀﾌｫｰﾏｯﾄ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_D_FORMAT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞﾃﾞｰﾀﾌｫｰﾏｯﾄ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞﾃﾞｰﾀﾌｫｰﾏｯﾄ")
        End If
        intCount = intCount + 1
        If IsNull(mFGRID_D_WIDTH) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｸﾞﾘｯﾄﾞﾃﾞｰﾀ幅")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｸﾞﾘｯﾄﾞﾃﾞｰﾀ幅")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_D_WIDTH
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞﾃﾞｰﾀ幅")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞﾃﾞｰﾀ幅")
        End If
        intCount = intCount + 1
        If IsNull(mFGRID_COL_DISP_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｸﾞﾘｯﾄﾞ列表示ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｸﾞﾘｯﾄﾞ列表示ﾌﾗｸﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_COL_DISP_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞ列表示ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞ列表示ﾌﾗｸﾞ")
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
    Public Sub DELETE_TDSP_GRID()
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
        ElseIf IsNull(mFCOL_INDEX) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[列ｲﾝﾃﾞｯｸｽ]"
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
        strSQL.Append(vbCrLf & "    TDSP_GRID")
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
        If IsNull(FCOL_INDEX) = True Then
            strSQL.Append(vbCrLf & "    AND FCOL_INDEX IS NULL --列ｲﾝﾃﾞｯｸｽ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOL_INDEX
            strSQL.Append(vbCrLf & "    AND FCOL_INDEX = :" & UBound(strBindField) - 1 & " --列ｲﾝﾃﾞｯｸｽ")
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
    Public Sub DELETE_TDSP_GRID_ANY()
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
        strSQL.Append(vbCrLf & "    TDSP_GRID")
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
        If IsNotNull(FCOL_INDEX) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOL_INDEX
            strSQL.Append(vbCrLf & "    AND FCOL_INDEX = :" & UBound(strBindField) - 1 & " --列ｲﾝﾃﾞｯｸｽ")
        End If
        If IsNotNull(FGRID_DISPLAYINDEX) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_DISPLAYINDEX
            strSQL.Append(vbCrLf & "    AND FGRID_DISPLAYINDEX = :" & UBound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞ列表示順序")
        End If
        If IsNotNull(FGRID_ORDER_BY) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_ORDER_BY
            strSQL.Append(vbCrLf & "    AND FGRID_ORDER_BY = :" & UBound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞｵｰﾀﾞｰ優先順")
        End If
        If IsNotNull(FGRID_ORDER_ASCDESC) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_ORDER_ASCDESC
            strSQL.Append(vbCrLf & "    AND FGRID_ORDER_ASCDESC = :" & UBound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞｵｰﾀﾞｰ昇順降順")
        End If
        If IsNotNull(FGRID_H_TEXT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_H_TEXT
            strSQL.Append(vbCrLf & "    AND FGRID_H_TEXT = :" & UBound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞﾍｯﾀﾞｰﾃｷｽﾄ")
        End If
        If IsNotNull(FGRID_H_ALIGNMENT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_H_ALIGNMENT
            strSQL.Append(vbCrLf & "    AND FGRID_H_ALIGNMENT = :" & UBound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞﾍｯﾀﾞｰ配置")
        End If
        If IsNotNull(FGRID_D_ALIGNMENT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_D_ALIGNMENT
            strSQL.Append(vbCrLf & "    AND FGRID_D_ALIGNMENT = :" & UBound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞﾃﾞｰﾀ配置")
        End If
        If IsNotNull(FGRID_D_FORMAT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_D_FORMAT
            strSQL.Append(vbCrLf & "    AND FGRID_D_FORMAT = :" & UBound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞﾃﾞｰﾀﾌｫｰﾏｯﾄ")
        End If
        If IsNotNull(FGRID_D_WIDTH) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_D_WIDTH
            strSQL.Append(vbCrLf & "    AND FGRID_D_WIDTH = :" & UBound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞﾃﾞｰﾀ幅")
        End If
        If IsNotNull(FGRID_COL_DISP_FLAG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFGRID_COL_DISP_FLAG
            strSQL.Append(vbCrLf & "    AND FGRID_COL_DISP_FLAG = :" & UBound(strBindField) - 1 & " --ｸﾞﾘｯﾄﾞ列表示ﾌﾗｸﾞ")
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
        If IsNothing(objType.GetProperty("FCOL_INDEX")) = False Then mFCOL_INDEX = objObject.FCOL_INDEX '列ｲﾝﾃﾞｯｸｽ
        If IsNothing(objType.GetProperty("FGRID_DISPLAYINDEX")) = False Then mFGRID_DISPLAYINDEX = objObject.FGRID_DISPLAYINDEX 'ｸﾞﾘｯﾄﾞ列表示順序
        If IsNothing(objType.GetProperty("FGRID_ORDER_BY")) = False Then mFGRID_ORDER_BY = objObject.FGRID_ORDER_BY 'ｸﾞﾘｯﾄﾞｵｰﾀﾞｰ優先順
        If IsNothing(objType.GetProperty("FGRID_ORDER_ASCDESC")) = False Then mFGRID_ORDER_ASCDESC = objObject.FGRID_ORDER_ASCDESC 'ｸﾞﾘｯﾄﾞｵｰﾀﾞｰ昇順降順
        If IsNothing(objType.GetProperty("FGRID_H_TEXT")) = False Then mFGRID_H_TEXT = objObject.FGRID_H_TEXT 'ｸﾞﾘｯﾄﾞﾍｯﾀﾞｰﾃｷｽﾄ
        If IsNothing(objType.GetProperty("FGRID_H_ALIGNMENT")) = False Then mFGRID_H_ALIGNMENT = objObject.FGRID_H_ALIGNMENT 'ｸﾞﾘｯﾄﾞﾍｯﾀﾞｰ配置
        If IsNothing(objType.GetProperty("FGRID_D_ALIGNMENT")) = False Then mFGRID_D_ALIGNMENT = objObject.FGRID_D_ALIGNMENT 'ｸﾞﾘｯﾄﾞﾃﾞｰﾀ配置
        If IsNothing(objType.GetProperty("FGRID_D_FORMAT")) = False Then mFGRID_D_FORMAT = objObject.FGRID_D_FORMAT 'ｸﾞﾘｯﾄﾞﾃﾞｰﾀﾌｫｰﾏｯﾄ
        If IsNothing(objType.GetProperty("FGRID_D_WIDTH")) = False Then mFGRID_D_WIDTH = objObject.FGRID_D_WIDTH 'ｸﾞﾘｯﾄﾞﾃﾞｰﾀ幅
        If IsNothing(objType.GetProperty("FGRID_COL_DISP_FLAG")) = False Then mFGRID_COL_DISP_FLAG = objObject.FGRID_COL_DISP_FLAG 'ｸﾞﾘｯﾄﾞ列表示ﾌﾗｸﾞ

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
        mFCOL_INDEX = Nothing
        mFGRID_DISPLAYINDEX = Nothing
        mFGRID_ORDER_BY = Nothing
        mFGRID_ORDER_ASCDESC = Nothing
        mFGRID_H_TEXT = Nothing
        mFGRID_H_ALIGNMENT = Nothing
        mFGRID_D_ALIGNMENT = Nothing
        mFGRID_D_FORMAT = Nothing
        mFGRID_D_WIDTH = Nothing
        mFGRID_COL_DISP_FLAG = Nothing


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
        mFCOL_INDEX = TO_INTEGER_NULLABLE(objRow("FCOL_INDEX"))
        mFGRID_DISPLAYINDEX = TO_INTEGER_NULLABLE(objRow("FGRID_DISPLAYINDEX"))
        mFGRID_ORDER_BY = TO_INTEGER_NULLABLE(objRow("FGRID_ORDER_BY"))
        mFGRID_ORDER_ASCDESC = TO_STRING_NULLABLE(objRow("FGRID_ORDER_ASCDESC"))
        mFGRID_H_TEXT = TO_STRING_NULLABLE(objRow("FGRID_H_TEXT"))
        mFGRID_H_ALIGNMENT = TO_STRING_NULLABLE(objRow("FGRID_H_ALIGNMENT"))
        mFGRID_D_ALIGNMENT = TO_STRING_NULLABLE(objRow("FGRID_D_ALIGNMENT"))
        mFGRID_D_FORMAT = TO_STRING_NULLABLE(objRow("FGRID_D_FORMAT"))
        mFGRID_D_WIDTH = TO_STRING_NULLABLE(objRow("FGRID_D_WIDTH"))
        mFGRID_COL_DISP_FLAG = TO_INTEGER_NULLABLE(objRow("FGRID_COL_DISP_FLAG"))


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
        strMsg &= "[ﾃｰﾌﾞﾙ名:ｸﾞﾘｯﾄﾞﾏｽﾀ]"
        If IsNotNull(FDISP_ID) Then
            strMsg &= "[画面ID:" & FDISP_ID & "]"
        End If
        If IsNotNull(FCTRL_ID) Then
            strMsg &= "[ｺﾝﾄﾛｰﾙID:" & FCTRL_ID & "]"
        End If
        If IsNotNull(FCOL_INDEX) Then
            strMsg &= "[列ｲﾝﾃﾞｯｸｽ:" & FCOL_INDEX & "]"
        End If
        If IsNotNull(FGRID_DISPLAYINDEX) Then
            strMsg &= "[ｸﾞﾘｯﾄﾞ列表示順序:" & FGRID_DISPLAYINDEX & "]"
        End If
        If IsNotNull(FGRID_ORDER_BY) Then
            strMsg &= "[ｸﾞﾘｯﾄﾞｵｰﾀﾞｰ優先順:" & FGRID_ORDER_BY & "]"
        End If
        If IsNotNull(FGRID_ORDER_ASCDESC) Then
            strMsg &= "[ｸﾞﾘｯﾄﾞｵｰﾀﾞｰ昇順降順:" & FGRID_ORDER_ASCDESC & "]"
        End If
        If IsNotNull(FGRID_H_TEXT) Then
            strMsg &= "[ｸﾞﾘｯﾄﾞﾍｯﾀﾞｰﾃｷｽﾄ:" & FGRID_H_TEXT & "]"
        End If
        If IsNotNull(FGRID_H_ALIGNMENT) Then
            strMsg &= "[ｸﾞﾘｯﾄﾞﾍｯﾀﾞｰ配置:" & FGRID_H_ALIGNMENT & "]"
        End If
        If IsNotNull(FGRID_D_ALIGNMENT) Then
            strMsg &= "[ｸﾞﾘｯﾄﾞﾃﾞｰﾀ配置:" & FGRID_D_ALIGNMENT & "]"
        End If
        If IsNotNull(FGRID_D_FORMAT) Then
            strMsg &= "[ｸﾞﾘｯﾄﾞﾃﾞｰﾀﾌｫｰﾏｯﾄ:" & FGRID_D_FORMAT & "]"
        End If
        If IsNotNull(FGRID_D_WIDTH) Then
            strMsg &= "[ｸﾞﾘｯﾄﾞﾃﾞｰﾀ幅:" & FGRID_D_WIDTH & "]"
        End If
        If IsNotNull(FGRID_COL_DISP_FLAG) Then
            strMsg &= "[ｸﾞﾘｯﾄﾞ列表示ﾌﾗｸﾞ:" & FGRID_COL_DISP_FLAG & "]"
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
