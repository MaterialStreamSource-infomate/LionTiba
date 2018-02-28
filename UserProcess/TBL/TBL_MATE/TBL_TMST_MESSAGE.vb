'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' 【名称】MaterialStreamﾃｰﾌﾞﾙｸﾗｽ
' 【機能】ﾒｯｾｰｼﾞﾏｽﾀﾃｰﾌﾞﾙｸﾗｽ
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
''' ﾒｯｾｰｼﾞﾏｽﾀﾃｰﾌﾞﾙｸﾗｽ
''' </summary>
Public Class TBL_TMST_MESSAGE
    Inherits clsTemplateTable

    '**********************************************************************************************
    '↓↓↓自動生成部
#Region "  ｸﾗｽ変数定義                  "
    'ﾌﾟﾛﾊﾟﾃｨ
    Private mobjAryMe As TBL_TMST_MESSAGE()                                      'ﾒｯｾｰｼﾞﾏｽﾀ
    Private mstrUSER_SQL As String                                               'ﾕｰｻﾞｰSQL
    Private mORDER_BY As String                                                  'OrderBy句
    Private mWHERE As String                                                     'Where句
    Private mFMSG_ID As String                                                   'ﾒｯｾｰｼﾞID
    Private mFMSG_NAIYOU As String                                               'ﾒｯｾｰｼﾞ内容
    Private mFMSG_KUBUN As Nullable(Of Integer)                                  'ﾒｯｾｰｼﾞ区分
    Private mFMSG_LEVEL As Nullable(Of Integer)                                  'ﾒｯｾｰｼﾞﾚﾍﾞﾙ
    Private mFMSG_TYPE As Nullable(Of Integer)                                   'ﾒｯｾｰｼﾞﾎﾞｯｸｽﾀｲﾌﾟ
    Private mFMSG_BTN As Nullable(Of Integer)                                    'ﾒｯｾｰｼﾞﾎﾞｯｸｽﾎﾞﾀﾝ
    Private mFMSG_TITLE As Nullable(Of Integer)                                  'ﾒｯｾｰｼﾞﾎﾞｯｸｽﾀｲﾄﾙ
    Private mFMSG_DSP As Nullable(Of Integer)                                    'ﾒｯｾｰｼﾞﾎﾞｯｸｽ表示
    Private mFLOG_FLAG As Nullable(Of Integer)                                   'ﾛｸﾞ書込ﾌﾗｸﾞ
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                  "
    ''' <summary>
    ''' ｼｽﾃﾑ変数 (自ｸﾗｽ型配列)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_TMST_MESSAGE()
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
    ''' ﾒｯｾｰｼﾞID
    ''' </summary>
    Public Property FMSG_ID() As String
        Get
            Return mFMSG_ID
        End Get
        Set(ByVal Value As String)
            mFMSG_ID = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾒｯｾｰｼﾞ内容
    ''' </summary>
    Public Property FMSG_NAIYOU() As String
        Get
            Return mFMSG_NAIYOU
        End Get
        Set(ByVal Value As String)
            mFMSG_NAIYOU = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾒｯｾｰｼﾞ区分
    ''' </summary>
    Public Property FMSG_KUBUN() As Nullable(Of Integer)
        Get
            Return mFMSG_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFMSG_KUBUN = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾒｯｾｰｼﾞﾚﾍﾞﾙ
    ''' </summary>
    Public Property FMSG_LEVEL() As Nullable(Of Integer)
        Get
            Return mFMSG_LEVEL
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFMSG_LEVEL = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾒｯｾｰｼﾞﾎﾞｯｸｽﾀｲﾌﾟ
    ''' </summary>
    Public Property FMSG_TYPE() As Nullable(Of Integer)
        Get
            Return mFMSG_TYPE
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFMSG_TYPE = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾒｯｾｰｼﾞﾎﾞｯｸｽﾎﾞﾀﾝ
    ''' </summary>
    Public Property FMSG_BTN() As Nullable(Of Integer)
        Get
            Return mFMSG_BTN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFMSG_BTN = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾒｯｾｰｼﾞﾎﾞｯｸｽﾀｲﾄﾙ
    ''' </summary>
    Public Property FMSG_TITLE() As Nullable(Of Integer)
        Get
            Return mFMSG_TITLE
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFMSG_TITLE = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾒｯｾｰｼﾞﾎﾞｯｸｽ表示
    ''' </summary>
    Public Property FMSG_DSP() As Nullable(Of Integer)
        Get
            Return mFMSG_DSP
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFMSG_DSP = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾛｸﾞ書込ﾌﾗｸﾞ
    ''' </summary>
    Public Property FLOG_FLAG() As Nullable(Of Integer)
        Get
            Return mFLOG_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFLOG_FLAG = Value
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
    Public Function GET_TMST_MESSAGE(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    TMST_MESSAGE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FMSG_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_ID
            strSQL.Append(vbCrLf & "    AND FMSG_ID = :" & UBound(strBindField) - 1 & " --ﾒｯｾｰｼﾞID")
        End If
        If IsNull(FMSG_NAIYOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_NAIYOU
            strSQL.Append(vbCrLf & "    AND FMSG_NAIYOU = :" & UBound(strBindField) - 1 & " --ﾒｯｾｰｼﾞ内容")
        End If
        If IsNull(FMSG_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_KUBUN
            strSQL.Append(vbCrLf & "    AND FMSG_KUBUN = :" & UBound(strBindField) - 1 & " --ﾒｯｾｰｼﾞ区分")
        End If
        If IsNull(FMSG_LEVEL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_LEVEL
            strSQL.Append(vbCrLf & "    AND FMSG_LEVEL = :" & UBound(strBindField) - 1 & " --ﾒｯｾｰｼﾞﾚﾍﾞﾙ")
        End If
        If IsNull(FMSG_TYPE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_TYPE
            strSQL.Append(vbCrLf & "    AND FMSG_TYPE = :" & UBound(strBindField) - 1 & " --ﾒｯｾｰｼﾞﾎﾞｯｸｽﾀｲﾌﾟ")
        End If
        If IsNull(FMSG_BTN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_BTN
            strSQL.Append(vbCrLf & "    AND FMSG_BTN = :" & UBound(strBindField) - 1 & " --ﾒｯｾｰｼﾞﾎﾞｯｸｽﾎﾞﾀﾝ")
        End If
        If IsNull(FMSG_TITLE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_TITLE
            strSQL.Append(vbCrLf & "    AND FMSG_TITLE = :" & UBound(strBindField) - 1 & " --ﾒｯｾｰｼﾞﾎﾞｯｸｽﾀｲﾄﾙ")
        End If
        If IsNull(FMSG_DSP) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_DSP
            strSQL.Append(vbCrLf & "    AND FMSG_DSP = :" & UBound(strBindField) - 1 & " --ﾒｯｾｰｼﾞﾎﾞｯｸｽ表示")
        End If
        If IsNull(FLOG_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_FLAG
            strSQL.Append(vbCrLf & "    AND FLOG_FLAG = :" & UBound(strBindField) - 1 & " --ﾛｸﾞ書込ﾌﾗｸﾞ")
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
        strDataSetName = "TMST_MESSAGE"
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
    Public Function GET_TMST_MESSAGE_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    TMST_MESSAGE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FMSG_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_ID
            strSQL.Append(vbCrLf & "    AND FMSG_ID = :" & UBound(strBindField) - 1 & " --ﾒｯｾｰｼﾞID")
        End If
        If IsNull(FMSG_NAIYOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_NAIYOU
            strSQL.Append(vbCrLf & "    AND FMSG_NAIYOU = :" & UBound(strBindField) - 1 & " --ﾒｯｾｰｼﾞ内容")
        End If
        If IsNull(FMSG_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_KUBUN
            strSQL.Append(vbCrLf & "    AND FMSG_KUBUN = :" & UBound(strBindField) - 1 & " --ﾒｯｾｰｼﾞ区分")
        End If
        If IsNull(FMSG_LEVEL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_LEVEL
            strSQL.Append(vbCrLf & "    AND FMSG_LEVEL = :" & UBound(strBindField) - 1 & " --ﾒｯｾｰｼﾞﾚﾍﾞﾙ")
        End If
        If IsNull(FMSG_TYPE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_TYPE
            strSQL.Append(vbCrLf & "    AND FMSG_TYPE = :" & UBound(strBindField) - 1 & " --ﾒｯｾｰｼﾞﾎﾞｯｸｽﾀｲﾌﾟ")
        End If
        If IsNull(FMSG_BTN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_BTN
            strSQL.Append(vbCrLf & "    AND FMSG_BTN = :" & UBound(strBindField) - 1 & " --ﾒｯｾｰｼﾞﾎﾞｯｸｽﾎﾞﾀﾝ")
        End If
        If IsNull(FMSG_TITLE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_TITLE
            strSQL.Append(vbCrLf & "    AND FMSG_TITLE = :" & UBound(strBindField) - 1 & " --ﾒｯｾｰｼﾞﾎﾞｯｸｽﾀｲﾄﾙ")
        End If
        If IsNull(FMSG_DSP) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_DSP
            strSQL.Append(vbCrLf & "    AND FMSG_DSP = :" & UBound(strBindField) - 1 & " --ﾒｯｾｰｼﾞﾎﾞｯｸｽ表示")
        End If
        If IsNull(FLOG_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_FLAG
            strSQL.Append(vbCrLf & "    AND FLOG_FLAG = :" & UBound(strBindField) - 1 & " --ﾛｸﾞ書込ﾌﾗｸﾞ")
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
        strDataSetName = "TMST_MESSAGE"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TMST_MESSAGE(Owner, objDb, objDbLog)
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
    Public Function GET_TMST_MESSAGE_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "TMST_MESSAGE"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TMST_MESSAGE(Owner, objDb, objDbLog)
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
    Public Function GET_TMST_MESSAGE_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    TMST_MESSAGE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FMSG_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_ID
            strSQL.Append(vbCrLf & "    AND FMSG_ID = :" & UBound(strBindField) - 1 & " --ﾒｯｾｰｼﾞID")
        End If
        If IsNull(FMSG_NAIYOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_NAIYOU
            strSQL.Append(vbCrLf & "    AND FMSG_NAIYOU = :" & UBound(strBindField) - 1 & " --ﾒｯｾｰｼﾞ内容")
        End If
        If IsNull(FMSG_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_KUBUN
            strSQL.Append(vbCrLf & "    AND FMSG_KUBUN = :" & UBound(strBindField) - 1 & " --ﾒｯｾｰｼﾞ区分")
        End If
        If IsNull(FMSG_LEVEL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_LEVEL
            strSQL.Append(vbCrLf & "    AND FMSG_LEVEL = :" & UBound(strBindField) - 1 & " --ﾒｯｾｰｼﾞﾚﾍﾞﾙ")
        End If
        If IsNull(FMSG_TYPE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_TYPE
            strSQL.Append(vbCrLf & "    AND FMSG_TYPE = :" & UBound(strBindField) - 1 & " --ﾒｯｾｰｼﾞﾎﾞｯｸｽﾀｲﾌﾟ")
        End If
        If IsNull(FMSG_BTN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_BTN
            strSQL.Append(vbCrLf & "    AND FMSG_BTN = :" & UBound(strBindField) - 1 & " --ﾒｯｾｰｼﾞﾎﾞｯｸｽﾎﾞﾀﾝ")
        End If
        If IsNull(FMSG_TITLE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_TITLE
            strSQL.Append(vbCrLf & "    AND FMSG_TITLE = :" & UBound(strBindField) - 1 & " --ﾒｯｾｰｼﾞﾎﾞｯｸｽﾀｲﾄﾙ")
        End If
        If IsNull(FMSG_DSP) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_DSP
            strSQL.Append(vbCrLf & "    AND FMSG_DSP = :" & UBound(strBindField) - 1 & " --ﾒｯｾｰｼﾞﾎﾞｯｸｽ表示")
        End If
        If IsNull(FLOG_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_FLAG
            strSQL.Append(vbCrLf & "    AND FLOG_FLAG = :" & UBound(strBindField) - 1 & " --ﾛｸﾞ書込ﾌﾗｸﾞ")
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
        strDataSetName = "TMST_MESSAGE"
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
    Public Sub UPDATE_TMST_MESSAGE()
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
        ElseIf IsNull(mFMSG_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾒｯｾｰｼﾞID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFMSG_NAIYOU) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾒｯｾｰｼﾞ内容]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFMSG_KUBUN) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾒｯｾｰｼﾞ区分]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFMSG_LEVEL) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾒｯｾｰｼﾞﾚﾍﾞﾙ]"
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
        strSQL.Append(vbCrLf & "    TMST_MESSAGE")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
        If IsNull(mFMSG_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_ID = NULL --ﾒｯｾｰｼﾞID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_ID = NULL --ﾒｯｾｰｼﾞID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_ID = :" & Ubound(strBindField) - 1 & " --ﾒｯｾｰｼﾞID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_ID = :" & Ubound(strBindField) - 1 & " --ﾒｯｾｰｼﾞID")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_NAIYOU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_NAIYOU = NULL --ﾒｯｾｰｼﾞ内容")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_NAIYOU = NULL --ﾒｯｾｰｼﾞ内容")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_NAIYOU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_NAIYOU = :" & Ubound(strBindField) - 1 & " --ﾒｯｾｰｼﾞ内容")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_NAIYOU = :" & Ubound(strBindField) - 1 & " --ﾒｯｾｰｼﾞ内容")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_KUBUN = NULL --ﾒｯｾｰｼﾞ区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_KUBUN = NULL --ﾒｯｾｰｼﾞ区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_KUBUN = :" & Ubound(strBindField) - 1 & " --ﾒｯｾｰｼﾞ区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_KUBUN = :" & Ubound(strBindField) - 1 & " --ﾒｯｾｰｼﾞ区分")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_LEVEL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_LEVEL = NULL --ﾒｯｾｰｼﾞﾚﾍﾞﾙ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_LEVEL = NULL --ﾒｯｾｰｼﾞﾚﾍﾞﾙ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_LEVEL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_LEVEL = :" & Ubound(strBindField) - 1 & " --ﾒｯｾｰｼﾞﾚﾍﾞﾙ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_LEVEL = :" & Ubound(strBindField) - 1 & " --ﾒｯｾｰｼﾞﾚﾍﾞﾙ")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_TYPE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_TYPE = NULL --ﾒｯｾｰｼﾞﾎﾞｯｸｽﾀｲﾌﾟ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_TYPE = NULL --ﾒｯｾｰｼﾞﾎﾞｯｸｽﾀｲﾌﾟ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_TYPE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_TYPE = :" & Ubound(strBindField) - 1 & " --ﾒｯｾｰｼﾞﾎﾞｯｸｽﾀｲﾌﾟ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_TYPE = :" & Ubound(strBindField) - 1 & " --ﾒｯｾｰｼﾞﾎﾞｯｸｽﾀｲﾌﾟ")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_BTN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_BTN = NULL --ﾒｯｾｰｼﾞﾎﾞｯｸｽﾎﾞﾀﾝ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_BTN = NULL --ﾒｯｾｰｼﾞﾎﾞｯｸｽﾎﾞﾀﾝ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_BTN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_BTN = :" & Ubound(strBindField) - 1 & " --ﾒｯｾｰｼﾞﾎﾞｯｸｽﾎﾞﾀﾝ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_BTN = :" & Ubound(strBindField) - 1 & " --ﾒｯｾｰｼﾞﾎﾞｯｸｽﾎﾞﾀﾝ")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_TITLE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_TITLE = NULL --ﾒｯｾｰｼﾞﾎﾞｯｸｽﾀｲﾄﾙ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_TITLE = NULL --ﾒｯｾｰｼﾞﾎﾞｯｸｽﾀｲﾄﾙ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_TITLE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_TITLE = :" & Ubound(strBindField) - 1 & " --ﾒｯｾｰｼﾞﾎﾞｯｸｽﾀｲﾄﾙ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_TITLE = :" & Ubound(strBindField) - 1 & " --ﾒｯｾｰｼﾞﾎﾞｯｸｽﾀｲﾄﾙ")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_DSP) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_DSP = NULL --ﾒｯｾｰｼﾞﾎﾞｯｸｽ表示")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_DSP = NULL --ﾒｯｾｰｼﾞﾎﾞｯｸｽ表示")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_DSP
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_DSP = :" & Ubound(strBindField) - 1 & " --ﾒｯｾｰｼﾞﾎﾞｯｸｽ表示")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_DSP = :" & Ubound(strBindField) - 1 & " --ﾒｯｾｰｼﾞﾎﾞｯｸｽ表示")
        End If
        intCount = intCount + 1
        If IsNull(mFLOG_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_FLAG = NULL --ﾛｸﾞ書込ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_FLAG = NULL --ﾛｸﾞ書込ﾌﾗｸﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_FLAG = :" & Ubound(strBindField) - 1 & " --ﾛｸﾞ書込ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_FLAG = :" & Ubound(strBindField) - 1 & " --ﾛｸﾞ書込ﾌﾗｸﾞ")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FMSG_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FMSG_ID IS NULL --ﾒｯｾｰｼﾞID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_ID
            strSQL.Append(vbCrLf & "    AND FMSG_ID = :" & UBound(strBindField) - 1 & " --ﾒｯｾｰｼﾞID")
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
    Public Sub ADD_TMST_MESSAGE()
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
        ElseIf IsNull(mFMSG_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾒｯｾｰｼﾞID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFMSG_NAIYOU) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾒｯｾｰｼﾞ内容]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFMSG_KUBUN) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾒｯｾｰｼﾞ区分]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFMSG_LEVEL) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾒｯｾｰｼﾞﾚﾍﾞﾙ]"
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
        strSQL.Append(vbCrLf & "    TMST_MESSAGE")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
        If IsNull(mFMSG_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾒｯｾｰｼﾞID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾒｯｾｰｼﾞID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾒｯｾｰｼﾞID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾒｯｾｰｼﾞID")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_NAIYOU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾒｯｾｰｼﾞ内容")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾒｯｾｰｼﾞ内容")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_NAIYOU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾒｯｾｰｼﾞ内容")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾒｯｾｰｼﾞ内容")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾒｯｾｰｼﾞ区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾒｯｾｰｼﾞ区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾒｯｾｰｼﾞ区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾒｯｾｰｼﾞ区分")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_LEVEL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾒｯｾｰｼﾞﾚﾍﾞﾙ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾒｯｾｰｼﾞﾚﾍﾞﾙ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_LEVEL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾒｯｾｰｼﾞﾚﾍﾞﾙ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾒｯｾｰｼﾞﾚﾍﾞﾙ")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_TYPE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾒｯｾｰｼﾞﾎﾞｯｸｽﾀｲﾌﾟ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾒｯｾｰｼﾞﾎﾞｯｸｽﾀｲﾌﾟ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_TYPE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾒｯｾｰｼﾞﾎﾞｯｸｽﾀｲﾌﾟ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾒｯｾｰｼﾞﾎﾞｯｸｽﾀｲﾌﾟ")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_BTN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾒｯｾｰｼﾞﾎﾞｯｸｽﾎﾞﾀﾝ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾒｯｾｰｼﾞﾎﾞｯｸｽﾎﾞﾀﾝ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_BTN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾒｯｾｰｼﾞﾎﾞｯｸｽﾎﾞﾀﾝ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾒｯｾｰｼﾞﾎﾞｯｸｽﾎﾞﾀﾝ")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_TITLE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾒｯｾｰｼﾞﾎﾞｯｸｽﾀｲﾄﾙ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾒｯｾｰｼﾞﾎﾞｯｸｽﾀｲﾄﾙ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_TITLE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾒｯｾｰｼﾞﾎﾞｯｸｽﾀｲﾄﾙ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾒｯｾｰｼﾞﾎﾞｯｸｽﾀｲﾄﾙ")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_DSP) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾒｯｾｰｼﾞﾎﾞｯｸｽ表示")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾒｯｾｰｼﾞﾎﾞｯｸｽ表示")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_DSP
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾒｯｾｰｼﾞﾎﾞｯｸｽ表示")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾒｯｾｰｼﾞﾎﾞｯｸｽ表示")
        End If
        intCount = intCount + 1
        If IsNull(mFLOG_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾛｸﾞ書込ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾛｸﾞ書込ﾌﾗｸﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾛｸﾞ書込ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾛｸﾞ書込ﾌﾗｸﾞ")
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
    Public Sub DELETE_TMST_MESSAGE()
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
        ElseIf IsNull(mFMSG_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾒｯｾｰｼﾞID]"
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
        strSQL.Append(vbCrLf & "    TMST_MESSAGE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FMSG_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FMSG_ID IS NULL --ﾒｯｾｰｼﾞID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_ID
            strSQL.Append(vbCrLf & "    AND FMSG_ID = :" & UBound(strBindField) - 1 & " --ﾒｯｾｰｼﾞID")
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
    Public Sub DELETE_TMST_MESSAGE_ANY()
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
        strSQL.Append(vbCrLf & "    TMST_MESSAGE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(FMSG_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_ID
            strSQL.Append(vbCrLf & "    AND FMSG_ID = :" & UBound(strBindField) - 1 & " --ﾒｯｾｰｼﾞID")
        End If
        If IsNotNull(FMSG_NAIYOU) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_NAIYOU
            strSQL.Append(vbCrLf & "    AND FMSG_NAIYOU = :" & UBound(strBindField) - 1 & " --ﾒｯｾｰｼﾞ内容")
        End If
        If IsNotNull(FMSG_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_KUBUN
            strSQL.Append(vbCrLf & "    AND FMSG_KUBUN = :" & UBound(strBindField) - 1 & " --ﾒｯｾｰｼﾞ区分")
        End If
        If IsNotNull(FMSG_LEVEL) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_LEVEL
            strSQL.Append(vbCrLf & "    AND FMSG_LEVEL = :" & UBound(strBindField) - 1 & " --ﾒｯｾｰｼﾞﾚﾍﾞﾙ")
        End If
        If IsNotNull(FMSG_TYPE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_TYPE
            strSQL.Append(vbCrLf & "    AND FMSG_TYPE = :" & UBound(strBindField) - 1 & " --ﾒｯｾｰｼﾞﾎﾞｯｸｽﾀｲﾌﾟ")
        End If
        If IsNotNull(FMSG_BTN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_BTN
            strSQL.Append(vbCrLf & "    AND FMSG_BTN = :" & UBound(strBindField) - 1 & " --ﾒｯｾｰｼﾞﾎﾞｯｸｽﾎﾞﾀﾝ")
        End If
        If IsNotNull(FMSG_TITLE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_TITLE
            strSQL.Append(vbCrLf & "    AND FMSG_TITLE = :" & UBound(strBindField) - 1 & " --ﾒｯｾｰｼﾞﾎﾞｯｸｽﾀｲﾄﾙ")
        End If
        If IsNotNull(FMSG_DSP) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_DSP
            strSQL.Append(vbCrLf & "    AND FMSG_DSP = :" & UBound(strBindField) - 1 & " --ﾒｯｾｰｼﾞﾎﾞｯｸｽ表示")
        End If
        If IsNotNull(FLOG_FLAG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_FLAG
            strSQL.Append(vbCrLf & "    AND FLOG_FLAG = :" & UBound(strBindField) - 1 & " --ﾛｸﾞ書込ﾌﾗｸﾞ")
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
        If IsNothing(objType.GetProperty("FMSG_ID")) = False Then mFMSG_ID = objObject.FMSG_ID 'ﾒｯｾｰｼﾞID
        If IsNothing(objType.GetProperty("FMSG_NAIYOU")) = False Then mFMSG_NAIYOU = objObject.FMSG_NAIYOU 'ﾒｯｾｰｼﾞ内容
        If IsNothing(objType.GetProperty("FMSG_KUBUN")) = False Then mFMSG_KUBUN = objObject.FMSG_KUBUN 'ﾒｯｾｰｼﾞ区分
        If IsNothing(objType.GetProperty("FMSG_LEVEL")) = False Then mFMSG_LEVEL = objObject.FMSG_LEVEL 'ﾒｯｾｰｼﾞﾚﾍﾞﾙ
        If IsNothing(objType.GetProperty("FMSG_TYPE")) = False Then mFMSG_TYPE = objObject.FMSG_TYPE 'ﾒｯｾｰｼﾞﾎﾞｯｸｽﾀｲﾌﾟ
        If IsNothing(objType.GetProperty("FMSG_BTN")) = False Then mFMSG_BTN = objObject.FMSG_BTN 'ﾒｯｾｰｼﾞﾎﾞｯｸｽﾎﾞﾀﾝ
        If IsNothing(objType.GetProperty("FMSG_TITLE")) = False Then mFMSG_TITLE = objObject.FMSG_TITLE 'ﾒｯｾｰｼﾞﾎﾞｯｸｽﾀｲﾄﾙ
        If IsNothing(objType.GetProperty("FMSG_DSP")) = False Then mFMSG_DSP = objObject.FMSG_DSP 'ﾒｯｾｰｼﾞﾎﾞｯｸｽ表示
        If IsNothing(objType.GetProperty("FLOG_FLAG")) = False Then mFLOG_FLAG = objObject.FLOG_FLAG 'ﾛｸﾞ書込ﾌﾗｸﾞ

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
        mFMSG_ID = Nothing
        mFMSG_NAIYOU = Nothing
        mFMSG_KUBUN = Nothing
        mFMSG_LEVEL = Nothing
        mFMSG_TYPE = Nothing
        mFMSG_BTN = Nothing
        mFMSG_TITLE = Nothing
        mFMSG_DSP = Nothing
        mFLOG_FLAG = Nothing


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
        mFMSG_ID = TO_STRING_NULLABLE(objRow("FMSG_ID"))
        mFMSG_NAIYOU = TO_STRING_NULLABLE(objRow("FMSG_NAIYOU"))
        mFMSG_KUBUN = TO_INTEGER_NULLABLE(objRow("FMSG_KUBUN"))
        mFMSG_LEVEL = TO_INTEGER_NULLABLE(objRow("FMSG_LEVEL"))
        mFMSG_TYPE = TO_INTEGER_NULLABLE(objRow("FMSG_TYPE"))
        mFMSG_BTN = TO_INTEGER_NULLABLE(objRow("FMSG_BTN"))
        mFMSG_TITLE = TO_INTEGER_NULLABLE(objRow("FMSG_TITLE"))
        mFMSG_DSP = TO_INTEGER_NULLABLE(objRow("FMSG_DSP"))
        mFLOG_FLAG = TO_INTEGER_NULLABLE(objRow("FLOG_FLAG"))


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
        strMsg &= "[ﾃｰﾌﾞﾙ名:ﾒｯｾｰｼﾞﾏｽﾀ]"
        If IsNotNull(FMSG_ID) Then
            strMsg &= "[ﾒｯｾｰｼﾞID:" & FMSG_ID & "]"
        End If
        If IsNotNull(FMSG_NAIYOU) Then
            strMsg &= "[ﾒｯｾｰｼﾞ内容:" & FMSG_NAIYOU & "]"
        End If
        If IsNotNull(FMSG_KUBUN) Then
            strMsg &= "[ﾒｯｾｰｼﾞ区分:" & FMSG_KUBUN & "]"
        End If
        If IsNotNull(FMSG_LEVEL) Then
            strMsg &= "[ﾒｯｾｰｼﾞﾚﾍﾞﾙ:" & FMSG_LEVEL & "]"
        End If
        If IsNotNull(FMSG_TYPE) Then
            strMsg &= "[ﾒｯｾｰｼﾞﾎﾞｯｸｽﾀｲﾌﾟ:" & FMSG_TYPE & "]"
        End If
        If IsNotNull(FMSG_BTN) Then
            strMsg &= "[ﾒｯｾｰｼﾞﾎﾞｯｸｽﾎﾞﾀﾝ:" & FMSG_BTN & "]"
        End If
        If IsNotNull(FMSG_TITLE) Then
            strMsg &= "[ﾒｯｾｰｼﾞﾎﾞｯｸｽﾀｲﾄﾙ:" & FMSG_TITLE & "]"
        End If
        If IsNotNull(FMSG_DSP) Then
            strMsg &= "[ﾒｯｾｰｼﾞﾎﾞｯｸｽ表示:" & FMSG_DSP & "]"
        End If
        If IsNotNull(FLOG_FLAG) Then
            strMsg &= "[ﾛｸﾞ書込ﾌﾗｸﾞ:" & FLOG_FLAG & "]"
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
