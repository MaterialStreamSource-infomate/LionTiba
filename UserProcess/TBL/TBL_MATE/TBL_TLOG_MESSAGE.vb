'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' 【名称】MaterialStreamﾃｰﾌﾞﾙｸﾗｽ
' 【機能】ﾒｯｾｰｼﾞﾛｸﾞﾃｰﾌﾞﾙｸﾗｽ
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
''' ﾒｯｾｰｼﾞﾛｸﾞﾃｰﾌﾞﾙｸﾗｽ
''' </summary>
Public Class TBL_TLOG_MESSAGE
    Inherits clsTemplateTable

    '**********************************************************************************************
    '↓↓↓自動生成部
#Region "  ｸﾗｽ変数定義                  "
    'ﾌﾟﾛﾊﾟﾃｨ
    Private mobjAryMe As TBL_TLOG_MESSAGE()                                      'ﾒｯｾｰｼﾞﾛｸﾞ
    Private mstrUSER_SQL As String                                               'ﾕｰｻﾞｰSQL
    Private mORDER_BY As String                                                  'OrderBy句
    Private mWHERE As String                                                     'Where句
    Private mFLOG_NO As String                                                   'ﾛｸﾞ№
    Private mFMSG_ID As String                                                   'ﾒｯｾｰｼﾞID
    Private mFLOG_CHECK_FLAG As Nullable(Of Integer)                             '確認ﾌﾗｸﾞ
    Private mFHASSEI_DT As Nullable(Of Date)                                     '発生日時
    Private mFLOG_CHECK_DT As Nullable(Of Date)                                  '確認日時
    Private mFUSER_ID As String                                                  'ﾕｰｻﾞｰID
    Private mFMSG_PRM1 As String                                                 'ﾊﾟﾗﾒｰﾀ1
    Private mFMSG_PRM2 As String                                                 'ﾊﾟﾗﾒｰﾀ2
    Private mFMSG_PRM3 As String                                                 'ﾊﾟﾗﾒｰﾀ3
    Private mFMSG_PRM4 As String                                                 'ﾊﾟﾗﾒｰﾀ4
    Private mFMSG_PRM5 As String                                                 'ﾊﾟﾗﾒｰﾀ5
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                  "
    ''' <summary>
    ''' ｼｽﾃﾑ変数 (自ｸﾗｽ型配列)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_TLOG_MESSAGE()
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
    ''' ﾛｸﾞ№
    ''' </summary>
    Public Property FLOG_NO() As String
        Get
            Return mFLOG_NO
        End Get
        Set(ByVal Value As String)
            mFLOG_NO = Value
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
    ''' 確認ﾌﾗｸﾞ
    ''' </summary>
    Public Property FLOG_CHECK_FLAG() As Nullable(Of Integer)
        Get
            Return mFLOG_CHECK_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFLOG_CHECK_FLAG = Value
        End Set
    End Property
    ''' <summary>
    ''' 発生日時
    ''' </summary>
    Public Property FHASSEI_DT() As Nullable(Of Date)
        Get
            Return mFHASSEI_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mFHASSEI_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' 確認日時
    ''' </summary>
    Public Property FLOG_CHECK_DT() As Nullable(Of Date)
        Get
            Return mFLOG_CHECK_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mFLOG_CHECK_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾕｰｻﾞｰID
    ''' </summary>
    Public Property FUSER_ID() As String
        Get
            Return mFUSER_ID
        End Get
        Set(ByVal Value As String)
            mFUSER_ID = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾊﾟﾗﾒｰﾀ1
    ''' </summary>
    Public Property FMSG_PRM1() As String
        Get
            Return mFMSG_PRM1
        End Get
        Set(ByVal Value As String)
            mFMSG_PRM1 = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾊﾟﾗﾒｰﾀ2
    ''' </summary>
    Public Property FMSG_PRM2() As String
        Get
            Return mFMSG_PRM2
        End Get
        Set(ByVal Value As String)
            mFMSG_PRM2 = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾊﾟﾗﾒｰﾀ3
    ''' </summary>
    Public Property FMSG_PRM3() As String
        Get
            Return mFMSG_PRM3
        End Get
        Set(ByVal Value As String)
            mFMSG_PRM3 = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾊﾟﾗﾒｰﾀ4
    ''' </summary>
    Public Property FMSG_PRM4() As String
        Get
            Return mFMSG_PRM4
        End Get
        Set(ByVal Value As String)
            mFMSG_PRM4 = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾊﾟﾗﾒｰﾀ5
    ''' </summary>
    Public Property FMSG_PRM5() As String
        Get
            Return mFMSG_PRM5
        End Get
        Set(ByVal Value As String)
            mFMSG_PRM5 = Value
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
    Public Function GET_TLOG_MESSAGE(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    TLOG_MESSAGE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FLOG_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            strSQL.Append(vbCrLf & "    AND FLOG_NO = :" & UBound(strBindField) - 1 & " --ﾛｸﾞ№")
        End If
        If IsNull(FMSG_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_ID
            strSQL.Append(vbCrLf & "    AND FMSG_ID = :" & UBound(strBindField) - 1 & " --ﾒｯｾｰｼﾞID")
        End If
        If IsNull(FLOG_CHECK_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_FLAG
            strSQL.Append(vbCrLf & "    AND FLOG_CHECK_FLAG = :" & UBound(strBindField) - 1 & " --確認ﾌﾗｸﾞ")
        End If
        If IsNull(FHASSEI_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHASSEI_DT
            strSQL.Append(vbCrLf & "    AND FHASSEI_DT = :" & UBound(strBindField) - 1 & " --発生日時")
        End If
        If IsNull(FLOG_CHECK_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT
            strSQL.Append(vbCrLf & "    AND FLOG_CHECK_DT = :" & UBound(strBindField) - 1 & " --確認日時")
        End If
        If IsNull(FUSER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID
            strSQL.Append(vbCrLf & "    AND FUSER_ID = :" & UBound(strBindField) - 1 & " --ﾕｰｻﾞｰID")
        End If
        If IsNull(FMSG_PRM1) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM1
            strSQL.Append(vbCrLf & "    AND FMSG_PRM1 = :" & UBound(strBindField) - 1 & " --ﾊﾟﾗﾒｰﾀ1")
        End If
        If IsNull(FMSG_PRM2) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM2
            strSQL.Append(vbCrLf & "    AND FMSG_PRM2 = :" & UBound(strBindField) - 1 & " --ﾊﾟﾗﾒｰﾀ2")
        End If
        If IsNull(FMSG_PRM3) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM3
            strSQL.Append(vbCrLf & "    AND FMSG_PRM3 = :" & UBound(strBindField) - 1 & " --ﾊﾟﾗﾒｰﾀ3")
        End If
        If IsNull(FMSG_PRM4) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM4
            strSQL.Append(vbCrLf & "    AND FMSG_PRM4 = :" & UBound(strBindField) - 1 & " --ﾊﾟﾗﾒｰﾀ4")
        End If
        If IsNull(FMSG_PRM5) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM5
            strSQL.Append(vbCrLf & "    AND FMSG_PRM5 = :" & UBound(strBindField) - 1 & " --ﾊﾟﾗﾒｰﾀ5")
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
        strDataSetName = "TLOG_MESSAGE"
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
    Public Function GET_TLOG_MESSAGE_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    TLOG_MESSAGE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FLOG_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            strSQL.Append(vbCrLf & "    AND FLOG_NO = :" & UBound(strBindField) - 1 & " --ﾛｸﾞ№")
        End If
        If IsNull(FMSG_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_ID
            strSQL.Append(vbCrLf & "    AND FMSG_ID = :" & UBound(strBindField) - 1 & " --ﾒｯｾｰｼﾞID")
        End If
        If IsNull(FLOG_CHECK_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_FLAG
            strSQL.Append(vbCrLf & "    AND FLOG_CHECK_FLAG = :" & UBound(strBindField) - 1 & " --確認ﾌﾗｸﾞ")
        End If
        If IsNull(FHASSEI_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHASSEI_DT
            strSQL.Append(vbCrLf & "    AND FHASSEI_DT = :" & UBound(strBindField) - 1 & " --発生日時")
        End If
        If IsNull(FLOG_CHECK_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT
            strSQL.Append(vbCrLf & "    AND FLOG_CHECK_DT = :" & UBound(strBindField) - 1 & " --確認日時")
        End If
        If IsNull(FUSER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID
            strSQL.Append(vbCrLf & "    AND FUSER_ID = :" & UBound(strBindField) - 1 & " --ﾕｰｻﾞｰID")
        End If
        If IsNull(FMSG_PRM1) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM1
            strSQL.Append(vbCrLf & "    AND FMSG_PRM1 = :" & UBound(strBindField) - 1 & " --ﾊﾟﾗﾒｰﾀ1")
        End If
        If IsNull(FMSG_PRM2) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM2
            strSQL.Append(vbCrLf & "    AND FMSG_PRM2 = :" & UBound(strBindField) - 1 & " --ﾊﾟﾗﾒｰﾀ2")
        End If
        If IsNull(FMSG_PRM3) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM3
            strSQL.Append(vbCrLf & "    AND FMSG_PRM3 = :" & UBound(strBindField) - 1 & " --ﾊﾟﾗﾒｰﾀ3")
        End If
        If IsNull(FMSG_PRM4) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM4
            strSQL.Append(vbCrLf & "    AND FMSG_PRM4 = :" & UBound(strBindField) - 1 & " --ﾊﾟﾗﾒｰﾀ4")
        End If
        If IsNull(FMSG_PRM5) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM5
            strSQL.Append(vbCrLf & "    AND FMSG_PRM5 = :" & UBound(strBindField) - 1 & " --ﾊﾟﾗﾒｰﾀ5")
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
        strDataSetName = "TLOG_MESSAGE"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TLOG_MESSAGE(Owner, objDb, objDbLog)
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
    Public Function GET_TLOG_MESSAGE_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "TLOG_MESSAGE"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TLOG_MESSAGE(Owner, objDb, objDbLog)
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
    Public Function GET_TLOG_MESSAGE_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    TLOG_MESSAGE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FLOG_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            strSQL.Append(vbCrLf & "    AND FLOG_NO = :" & UBound(strBindField) - 1 & " --ﾛｸﾞ№")
        End If
        If IsNull(FMSG_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_ID
            strSQL.Append(vbCrLf & "    AND FMSG_ID = :" & UBound(strBindField) - 1 & " --ﾒｯｾｰｼﾞID")
        End If
        If IsNull(FLOG_CHECK_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_FLAG
            strSQL.Append(vbCrLf & "    AND FLOG_CHECK_FLAG = :" & UBound(strBindField) - 1 & " --確認ﾌﾗｸﾞ")
        End If
        If IsNull(FHASSEI_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHASSEI_DT
            strSQL.Append(vbCrLf & "    AND FHASSEI_DT = :" & UBound(strBindField) - 1 & " --発生日時")
        End If
        If IsNull(FLOG_CHECK_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT
            strSQL.Append(vbCrLf & "    AND FLOG_CHECK_DT = :" & UBound(strBindField) - 1 & " --確認日時")
        End If
        If IsNull(FUSER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID
            strSQL.Append(vbCrLf & "    AND FUSER_ID = :" & UBound(strBindField) - 1 & " --ﾕｰｻﾞｰID")
        End If
        If IsNull(FMSG_PRM1) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM1
            strSQL.Append(vbCrLf & "    AND FMSG_PRM1 = :" & UBound(strBindField) - 1 & " --ﾊﾟﾗﾒｰﾀ1")
        End If
        If IsNull(FMSG_PRM2) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM2
            strSQL.Append(vbCrLf & "    AND FMSG_PRM2 = :" & UBound(strBindField) - 1 & " --ﾊﾟﾗﾒｰﾀ2")
        End If
        If IsNull(FMSG_PRM3) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM3
            strSQL.Append(vbCrLf & "    AND FMSG_PRM3 = :" & UBound(strBindField) - 1 & " --ﾊﾟﾗﾒｰﾀ3")
        End If
        If IsNull(FMSG_PRM4) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM4
            strSQL.Append(vbCrLf & "    AND FMSG_PRM4 = :" & UBound(strBindField) - 1 & " --ﾊﾟﾗﾒｰﾀ4")
        End If
        If IsNull(FMSG_PRM5) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM5
            strSQL.Append(vbCrLf & "    AND FMSG_PRM5 = :" & UBound(strBindField) - 1 & " --ﾊﾟﾗﾒｰﾀ5")
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
        strDataSetName = "TLOG_MESSAGE"
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
    Public Sub UPDATE_TLOG_MESSAGE()
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
        ElseIf IsNull(mFLOG_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾛｸﾞ№]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFMSG_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾒｯｾｰｼﾞID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFHASSEI_DT) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[発生日時]"
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
        strSQL.Append(vbCrLf & "    TLOG_MESSAGE")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
        If IsNull(mFLOG_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_NO = NULL --ﾛｸﾞ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_NO = NULL --ﾛｸﾞ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_NO = :" & Ubound(strBindField) - 1 & " --ﾛｸﾞ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_NO = :" & Ubound(strBindField) - 1 & " --ﾛｸﾞ№")
        End If
        intCount = intCount + 1
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
        If IsNull(mFLOG_CHECK_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_CHECK_FLAG = NULL --確認ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_CHECK_FLAG = NULL --確認ﾌﾗｸﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_CHECK_FLAG = :" & Ubound(strBindField) - 1 & " --確認ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_CHECK_FLAG = :" & Ubound(strBindField) - 1 & " --確認ﾌﾗｸﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFHASSEI_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHASSEI_DT = NULL --発生日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHASSEI_DT = NULL --発生日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHASSEI_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHASSEI_DT = :" & Ubound(strBindField) - 1 & " --発生日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHASSEI_DT = :" & Ubound(strBindField) - 1 & " --発生日時")
        End If
        intCount = intCount + 1
        If IsNull(mFLOG_CHECK_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_CHECK_DT = NULL --確認日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_CHECK_DT = NULL --確認日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_CHECK_DT = :" & Ubound(strBindField) - 1 & " --確認日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_CHECK_DT = :" & Ubound(strBindField) - 1 & " --確認日時")
        End If
        intCount = intCount + 1
        If IsNull(mFUSER_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUSER_ID = NULL --ﾕｰｻﾞｰID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUSER_ID = NULL --ﾕｰｻﾞｰID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUSER_ID = :" & Ubound(strBindField) - 1 & " --ﾕｰｻﾞｰID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUSER_ID = :" & Ubound(strBindField) - 1 & " --ﾕｰｻﾞｰID")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_PRM1) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_PRM1 = NULL --ﾊﾟﾗﾒｰﾀ1")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_PRM1 = NULL --ﾊﾟﾗﾒｰﾀ1")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM1
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_PRM1 = :" & Ubound(strBindField) - 1 & " --ﾊﾟﾗﾒｰﾀ1")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_PRM1 = :" & Ubound(strBindField) - 1 & " --ﾊﾟﾗﾒｰﾀ1")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_PRM2) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_PRM2 = NULL --ﾊﾟﾗﾒｰﾀ2")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_PRM2 = NULL --ﾊﾟﾗﾒｰﾀ2")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM2
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_PRM2 = :" & Ubound(strBindField) - 1 & " --ﾊﾟﾗﾒｰﾀ2")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_PRM2 = :" & Ubound(strBindField) - 1 & " --ﾊﾟﾗﾒｰﾀ2")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_PRM3) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_PRM3 = NULL --ﾊﾟﾗﾒｰﾀ3")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_PRM3 = NULL --ﾊﾟﾗﾒｰﾀ3")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM3
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_PRM3 = :" & Ubound(strBindField) - 1 & " --ﾊﾟﾗﾒｰﾀ3")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_PRM3 = :" & Ubound(strBindField) - 1 & " --ﾊﾟﾗﾒｰﾀ3")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_PRM4) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_PRM4 = NULL --ﾊﾟﾗﾒｰﾀ4")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_PRM4 = NULL --ﾊﾟﾗﾒｰﾀ4")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM4
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_PRM4 = :" & Ubound(strBindField) - 1 & " --ﾊﾟﾗﾒｰﾀ4")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_PRM4 = :" & Ubound(strBindField) - 1 & " --ﾊﾟﾗﾒｰﾀ4")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_PRM5) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_PRM5 = NULL --ﾊﾟﾗﾒｰﾀ5")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_PRM5 = NULL --ﾊﾟﾗﾒｰﾀ5")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM5
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FMSG_PRM5 = :" & Ubound(strBindField) - 1 & " --ﾊﾟﾗﾒｰﾀ5")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FMSG_PRM5 = :" & Ubound(strBindField) - 1 & " --ﾊﾟﾗﾒｰﾀ5")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FLOG_NO) = True Then
            strSQL.Append(vbCrLf & "    AND FLOG_NO IS NULL --ﾛｸﾞ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            strSQL.Append(vbCrLf & "    AND FLOG_NO = :" & UBound(strBindField) - 1 & " --ﾛｸﾞ№")
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
    Public Sub ADD_TLOG_MESSAGE()
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
        ElseIf IsNull(mFLOG_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾛｸﾞ№]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFMSG_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾒｯｾｰｼﾞID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFHASSEI_DT) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[発生日時]"
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
        strSQL.Append(vbCrLf & "    TLOG_MESSAGE")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
        If IsNull(mFLOG_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾛｸﾞ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾛｸﾞ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾛｸﾞ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾛｸﾞ№")
        End If
        intCount = intCount + 1
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
        If IsNull(mFLOG_CHECK_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --確認ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --確認ﾌﾗｸﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --確認ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --確認ﾌﾗｸﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFHASSEI_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --発生日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --発生日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHASSEI_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --発生日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --発生日時")
        End If
        intCount = intCount + 1
        If IsNull(mFLOG_CHECK_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --確認日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --確認日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --確認日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --確認日時")
        End If
        intCount = intCount + 1
        If IsNull(mFUSER_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾕｰｻﾞｰID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾕｰｻﾞｰID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾕｰｻﾞｰID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾕｰｻﾞｰID")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_PRM1) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾊﾟﾗﾒｰﾀ1")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾊﾟﾗﾒｰﾀ1")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM1
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾊﾟﾗﾒｰﾀ1")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾊﾟﾗﾒｰﾀ1")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_PRM2) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾊﾟﾗﾒｰﾀ2")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾊﾟﾗﾒｰﾀ2")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM2
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾊﾟﾗﾒｰﾀ2")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾊﾟﾗﾒｰﾀ2")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_PRM3) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾊﾟﾗﾒｰﾀ3")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾊﾟﾗﾒｰﾀ3")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM3
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾊﾟﾗﾒｰﾀ3")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾊﾟﾗﾒｰﾀ3")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_PRM4) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾊﾟﾗﾒｰﾀ4")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾊﾟﾗﾒｰﾀ4")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM4
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾊﾟﾗﾒｰﾀ4")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾊﾟﾗﾒｰﾀ4")
        End If
        intCount = intCount + 1
        If IsNull(mFMSG_PRM5) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾊﾟﾗﾒｰﾀ5")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾊﾟﾗﾒｰﾀ5")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM5
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾊﾟﾗﾒｰﾀ5")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾊﾟﾗﾒｰﾀ5")
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
    Public Sub DELETE_TLOG_MESSAGE()
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
        ElseIf IsNull(mFLOG_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾛｸﾞ№]"
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
        strSQL.Append(vbCrLf & "    TLOG_MESSAGE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FLOG_NO) = True Then
            strSQL.Append(vbCrLf & "    AND FLOG_NO IS NULL --ﾛｸﾞ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            strSQL.Append(vbCrLf & "    AND FLOG_NO = :" & UBound(strBindField) - 1 & " --ﾛｸﾞ№")
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
    Public Sub DELETE_TLOG_MESSAGE_ANY()
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
        strSQL.Append(vbCrLf & "    TLOG_MESSAGE")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(FLOG_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            strSQL.Append(vbCrLf & "    AND FLOG_NO = :" & UBound(strBindField) - 1 & " --ﾛｸﾞ№")
        End If
        If IsNotNull(FMSG_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_ID
            strSQL.Append(vbCrLf & "    AND FMSG_ID = :" & UBound(strBindField) - 1 & " --ﾒｯｾｰｼﾞID")
        End If
        If IsNotNull(FLOG_CHECK_FLAG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_FLAG
            strSQL.Append(vbCrLf & "    AND FLOG_CHECK_FLAG = :" & UBound(strBindField) - 1 & " --確認ﾌﾗｸﾞ")
        End If
        If IsNotNull(FHASSEI_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHASSEI_DT
            strSQL.Append(vbCrLf & "    AND FHASSEI_DT = :" & UBound(strBindField) - 1 & " --発生日時")
        End If
        If IsNotNull(FLOG_CHECK_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT
            strSQL.Append(vbCrLf & "    AND FLOG_CHECK_DT = :" & UBound(strBindField) - 1 & " --確認日時")
        End If
        If IsNotNull(FUSER_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID
            strSQL.Append(vbCrLf & "    AND FUSER_ID = :" & UBound(strBindField) - 1 & " --ﾕｰｻﾞｰID")
        End If
        If IsNotNull(FMSG_PRM1) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM1
            strSQL.Append(vbCrLf & "    AND FMSG_PRM1 = :" & UBound(strBindField) - 1 & " --ﾊﾟﾗﾒｰﾀ1")
        End If
        If IsNotNull(FMSG_PRM2) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM2
            strSQL.Append(vbCrLf & "    AND FMSG_PRM2 = :" & UBound(strBindField) - 1 & " --ﾊﾟﾗﾒｰﾀ2")
        End If
        If IsNotNull(FMSG_PRM3) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM3
            strSQL.Append(vbCrLf & "    AND FMSG_PRM3 = :" & UBound(strBindField) - 1 & " --ﾊﾟﾗﾒｰﾀ3")
        End If
        If IsNotNull(FMSG_PRM4) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM4
            strSQL.Append(vbCrLf & "    AND FMSG_PRM4 = :" & UBound(strBindField) - 1 & " --ﾊﾟﾗﾒｰﾀ4")
        End If
        If IsNotNull(FMSG_PRM5) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFMSG_PRM5
            strSQL.Append(vbCrLf & "    AND FMSG_PRM5 = :" & UBound(strBindField) - 1 & " --ﾊﾟﾗﾒｰﾀ5")
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
        If IsNothing(objType.GetProperty("FLOG_NO")) = False Then mFLOG_NO = objObject.FLOG_NO 'ﾛｸﾞ№
        If IsNothing(objType.GetProperty("FMSG_ID")) = False Then mFMSG_ID = objObject.FMSG_ID 'ﾒｯｾｰｼﾞID
        If IsNothing(objType.GetProperty("FLOG_CHECK_FLAG")) = False Then mFLOG_CHECK_FLAG = objObject.FLOG_CHECK_FLAG '確認ﾌﾗｸﾞ
        If IsNothing(objType.GetProperty("FHASSEI_DT")) = False Then mFHASSEI_DT = objObject.FHASSEI_DT '発生日時
        If IsNothing(objType.GetProperty("FLOG_CHECK_DT")) = False Then mFLOG_CHECK_DT = objObject.FLOG_CHECK_DT '確認日時
        If IsNothing(objType.GetProperty("FUSER_ID")) = False Then mFUSER_ID = objObject.FUSER_ID 'ﾕｰｻﾞｰID
        If IsNothing(objType.GetProperty("FMSG_PRM1")) = False Then mFMSG_PRM1 = objObject.FMSG_PRM1 'ﾊﾟﾗﾒｰﾀ1
        If IsNothing(objType.GetProperty("FMSG_PRM2")) = False Then mFMSG_PRM2 = objObject.FMSG_PRM2 'ﾊﾟﾗﾒｰﾀ2
        If IsNothing(objType.GetProperty("FMSG_PRM3")) = False Then mFMSG_PRM3 = objObject.FMSG_PRM3 'ﾊﾟﾗﾒｰﾀ3
        If IsNothing(objType.GetProperty("FMSG_PRM4")) = False Then mFMSG_PRM4 = objObject.FMSG_PRM4 'ﾊﾟﾗﾒｰﾀ4
        If IsNothing(objType.GetProperty("FMSG_PRM5")) = False Then mFMSG_PRM5 = objObject.FMSG_PRM5 'ﾊﾟﾗﾒｰﾀ5

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
        mFLOG_NO = Nothing
        mFMSG_ID = Nothing
        mFLOG_CHECK_FLAG = Nothing
        mFHASSEI_DT = Nothing
        mFLOG_CHECK_DT = Nothing
        mFUSER_ID = Nothing
        mFMSG_PRM1 = Nothing
        mFMSG_PRM2 = Nothing
        mFMSG_PRM3 = Nothing
        mFMSG_PRM4 = Nothing
        mFMSG_PRM5 = Nothing


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
        mFLOG_NO = TO_STRING_NULLABLE(objRow("FLOG_NO"))
        mFMSG_ID = TO_STRING_NULLABLE(objRow("FMSG_ID"))
        mFLOG_CHECK_FLAG = TO_INTEGER_NULLABLE(objRow("FLOG_CHECK_FLAG"))
        mFHASSEI_DT = TO_DATE_NULLABLE(objRow("FHASSEI_DT"))
        mFLOG_CHECK_DT = TO_DATE_NULLABLE(objRow("FLOG_CHECK_DT"))
        mFUSER_ID = TO_STRING_NULLABLE(objRow("FUSER_ID"))
        mFMSG_PRM1 = TO_STRING_NULLABLE(objRow("FMSG_PRM1"))
        mFMSG_PRM2 = TO_STRING_NULLABLE(objRow("FMSG_PRM2"))
        mFMSG_PRM3 = TO_STRING_NULLABLE(objRow("FMSG_PRM3"))
        mFMSG_PRM4 = TO_STRING_NULLABLE(objRow("FMSG_PRM4"))
        mFMSG_PRM5 = TO_STRING_NULLABLE(objRow("FMSG_PRM5"))


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
        strMsg &= "[ﾃｰﾌﾞﾙ名:ﾒｯｾｰｼﾞﾛｸﾞ]"
        If IsNotNull(FLOG_NO) Then
            strMsg &= "[ﾛｸﾞ№:" & FLOG_NO & "]"
        End If
        If IsNotNull(FMSG_ID) Then
            strMsg &= "[ﾒｯｾｰｼﾞID:" & FMSG_ID & "]"
        End If
        If IsNotNull(FLOG_CHECK_FLAG) Then
            strMsg &= "[確認ﾌﾗｸﾞ:" & FLOG_CHECK_FLAG & "]"
        End If
        If IsNotNull(FHASSEI_DT) Then
            strMsg &= "[発生日時:" & FHASSEI_DT & "]"
        End If
        If IsNotNull(FLOG_CHECK_DT) Then
            strMsg &= "[確認日時:" & FLOG_CHECK_DT & "]"
        End If
        If IsNotNull(FUSER_ID) Then
            strMsg &= "[ﾕｰｻﾞｰID:" & FUSER_ID & "]"
        End If
        If IsNotNull(FMSG_PRM1) Then
            strMsg &= "[ﾊﾟﾗﾒｰﾀ1:" & FMSG_PRM1 & "]"
        End If
        If IsNotNull(FMSG_PRM2) Then
            strMsg &= "[ﾊﾟﾗﾒｰﾀ2:" & FMSG_PRM2 & "]"
        End If
        If IsNotNull(FMSG_PRM3) Then
            strMsg &= "[ﾊﾟﾗﾒｰﾀ3:" & FMSG_PRM3 & "]"
        End If
        If IsNotNull(FMSG_PRM4) Then
            strMsg &= "[ﾊﾟﾗﾒｰﾀ4:" & FMSG_PRM4 & "]"
        End If
        If IsNotNull(FMSG_PRM5) Then
            strMsg &= "[ﾊﾟﾗﾒｰﾀ5:" & FMSG_PRM5 & "]"
        End If


    End Sub
#End Region
    '↑↑↑自動生成部
    '**********************************************************************************************

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ共通
#Region "  ｸﾗｽ変数定義"
    Private mFMSG_KUBUN As String          'ﾒｯｾｰｼﾞ区分
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義"
    Public Property FMSG_KUBUN() As String
        Get
            Return mFMSG_KUBUN
        End Get
        Set(ByVal Value As String)
            mFMSG_KUBUN = Value
        End Set
    End Property
#End Region
#Region "  ﾒｯｾｰｼﾞﾛｸﾞ追加  [SEQ発番]                 (Public  ADD_TLOG_MESSAGE_SEQ)"
    Public Sub ADD_TLOG_MESSAGE_SEQ()
        Try


            '***********************
            'ﾛｸﾞ№の特定
            '***********************
            Dim objTPRG_SEQNO As New TBL_TPRG_SEQNO(Owner, ObjDb, ObjDbLog) 'ｼｰｹﾝｽ№ｸﾗｽ
            objTPRG_SEQNO.FSEQ_ID = FSEQ_ID_SSVRLOG_NO_MESSAGE               'ｼｰｹﾝｽID
            mFLOG_NO = objTPRG_SEQNO.GET_ENTRY_NO()                         'SEQ№の特定


            '***********************
            '追加
            '***********************
            Me.ADD_TLOG_MESSAGE()


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
#Region "  ﾒｯｾｰｼﾞﾛｸﾞ更新    [確認]              (Public  UPDATE_TLOG_MESSAGE_CHECK)"
    Public Sub UPDATE_TLOG_MESSAGE_CHECK()
        Try
            Dim strSQL As String        'SQL文
            Dim strMsg As String        'ﾒｯｾｰｼﾞ
            Dim intRetSQL As Integer    'SQL実行戻り値


            '***********************
            '更新SQL作成
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "UPDATE"
            strSQL &= vbCrLf & "    TLOG_MESSAGE"
            strSQL &= vbCrLf & " SET"
            strSQL &= vbCrLf & "    FLOG_CHECK_FLAG = '" & TO_STRING(FLAG_ON) & "'"
            strSQL &= vbCrLf & "   ,FLOG_CHECK_DT = TO_DATE('" & mFLOG_CHECK_DT.ToString & "', 'YYYY/MM/DD HH24:MI:SS')"
            strSQL &= vbCrLf & "   ,FUSER_ID = '" & TO_STRING(mFUSER_ID) & "'"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "    FLOG_CHECK_FLAG = '" & TO_STRING(FLAG_OFF) & "'"
            If mFLOG_NO <> DEFAULT_STRING Then
                strSQL &= vbCrLf & "    AND FLOG_NO = '" & TO_STRING(mFLOG_NO) & "'"
            End If

            strSQL &= vbCrLf


            '***********************
            '更新
            '***********************
            intRetSQL = ObjDb.Execute(strSQL)
            If intRetSQL = -1 Then
                '(SQLｴﾗｰ)
                strSQL = Replace(strSQL, vbCrLf, "")
                strMsg = ERRMSG_ERR_UPDATE & ObjDb.ErrMsg & "【" & strSQL & "】"
                Throw New UserException(strMsg)
            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
    '↑↑↑ｼｽﾃﾑ共通
    '**********************************************************************************************


    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
