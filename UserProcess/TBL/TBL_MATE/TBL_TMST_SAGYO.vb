'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' 【名称】MaterialStreamﾃｰﾌﾞﾙｸﾗｽ
' 【機能】作業種別毎制御情報ﾃｰﾌﾞﾙｸﾗｽ
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
''' 作業種別毎制御情報ﾃｰﾌﾞﾙｸﾗｽ
''' </summary>
Public Class TBL_TMST_SAGYO
    Inherits clsTemplateTable

    '**********************************************************************************************
    '↓↓↓自動生成部
#Region "  ｸﾗｽ変数定義                  "
    'ﾌﾟﾛﾊﾟﾃｨ
    Private mobjAryMe As TBL_TMST_SAGYO()                                        '作業種別毎制御情報
    Private mstrUSER_SQL As String                                               'ﾕｰｻﾞｰSQL
    Private mORDER_BY As String                                                  'OrderBy句
    Private mWHERE As String                                                     'Where句
    Private mFSAGYOU_KIND As Nullable(Of Integer)                                '作業種別
    Private mFEQ_ID As String                                                    '設備ID
    Private mFPRIORITY As Nullable(Of Integer)                                   '優先ﾚﾍﾞﾙ
    Private mFSAGYOU_CONTENT As String                                           '作業内容
    Private mFTIME_OUT_RCVTMR As Nullable(Of Integer)                            'ﾀｲﾑｱｳﾄﾘｶﾊﾞﾘﾀｲﾏ
    Private mFLAST_TRNSSTART_DT As Nullable(Of Date)                             '最終搬送開始日時
    Private mFJUNMATI_DT As Nullable(Of Date)                                    '順待ち開始日時
    Private mFOUT_ST_RSV_FLAG As Nullable(Of Integer)                            'ST予約出庫ﾌﾗｸﾞ
    Private mFKEEP_RSVRAC_FLAG As Nullable(Of Integer)                           '出庫時棚予約保持ﾌﾗｸﾞ
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                  "
    ''' <summary>
    ''' ｼｽﾃﾑ変数 (自ｸﾗｽ型配列)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_TMST_SAGYO()
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
    ''' 作業種別
    ''' </summary>
    Public Property FSAGYOU_KIND() As Nullable(Of Integer)
        Get
            Return mFSAGYOU_KIND
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFSAGYOU_KIND = Value
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
    ''' 作業内容
    ''' </summary>
    Public Property FSAGYOU_CONTENT() As String
        Get
            Return mFSAGYOU_CONTENT
        End Get
        Set(ByVal Value As String)
            mFSAGYOU_CONTENT = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾀｲﾑｱｳﾄﾘｶﾊﾞﾘﾀｲﾏ
    ''' </summary>
    Public Property FTIME_OUT_RCVTMR() As Nullable(Of Integer)
        Get
            Return mFTIME_OUT_RCVTMR
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFTIME_OUT_RCVTMR = Value
        End Set
    End Property
    ''' <summary>
    ''' 最終搬送開始日時
    ''' </summary>
    Public Property FLAST_TRNSSTART_DT() As Nullable(Of Date)
        Get
            Return mFLAST_TRNSSTART_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mFLAST_TRNSSTART_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' 順待ち開始日時
    ''' </summary>
    Public Property FJUNMATI_DT() As Nullable(Of Date)
        Get
            Return mFJUNMATI_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mFJUNMATI_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' ST予約出庫ﾌﾗｸﾞ
    ''' </summary>
    Public Property FOUT_ST_RSV_FLAG() As Nullable(Of Integer)
        Get
            Return mFOUT_ST_RSV_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFOUT_ST_RSV_FLAG = Value
        End Set
    End Property
    ''' <summary>
    ''' 出庫時棚予約保持ﾌﾗｸﾞ
    ''' </summary>
    Public Property FKEEP_RSVRAC_FLAG() As Nullable(Of Integer)
        Get
            Return mFKEEP_RSVRAC_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFKEEP_RSVRAC_FLAG = Value
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
    Public Function GET_TMST_SAGYO(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    TMST_SAGYO")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FSAGYOU_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_KIND
            strSQL.Append(vbCrLf & "    AND FSAGYOU_KIND = :" & UBound(strBindField) - 1 & " --作業種別")
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
        If IsNull(FSAGYOU_CONTENT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_CONTENT
            strSQL.Append(vbCrLf & "    AND FSAGYOU_CONTENT = :" & UBound(strBindField) - 1 & " --作業内容")
        End If
        If IsNull(FTIME_OUT_RCVTMR) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTIME_OUT_RCVTMR
            strSQL.Append(vbCrLf & "    AND FTIME_OUT_RCVTMR = :" & UBound(strBindField) - 1 & " --ﾀｲﾑｱｳﾄﾘｶﾊﾞﾘﾀｲﾏ")
        End If
        If IsNull(FLAST_TRNSSTART_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLAST_TRNSSTART_DT
            strSQL.Append(vbCrLf & "    AND FLAST_TRNSSTART_DT = :" & UBound(strBindField) - 1 & " --最終搬送開始日時")
        End If
        If IsNull(FJUNMATI_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFJUNMATI_DT
            strSQL.Append(vbCrLf & "    AND FJUNMATI_DT = :" & UBound(strBindField) - 1 & " --順待ち開始日時")
        End If
        If IsNull(FOUT_ST_RSV_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFOUT_ST_RSV_FLAG
            strSQL.Append(vbCrLf & "    AND FOUT_ST_RSV_FLAG = :" & UBound(strBindField) - 1 & " --ST予約出庫ﾌﾗｸﾞ")
        End If
        If IsNull(FKEEP_RSVRAC_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFKEEP_RSVRAC_FLAG
            strSQL.Append(vbCrLf & "    AND FKEEP_RSVRAC_FLAG = :" & UBound(strBindField) - 1 & " --出庫時棚予約保持ﾌﾗｸﾞ")
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
        strDataSetName = "TMST_SAGYO"
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
    Public Function GET_TMST_SAGYO_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    TMST_SAGYO")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FSAGYOU_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_KIND
            strSQL.Append(vbCrLf & "    AND FSAGYOU_KIND = :" & UBound(strBindField) - 1 & " --作業種別")
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
        If IsNull(FSAGYOU_CONTENT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_CONTENT
            strSQL.Append(vbCrLf & "    AND FSAGYOU_CONTENT = :" & UBound(strBindField) - 1 & " --作業内容")
        End If
        If IsNull(FTIME_OUT_RCVTMR) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTIME_OUT_RCVTMR
            strSQL.Append(vbCrLf & "    AND FTIME_OUT_RCVTMR = :" & UBound(strBindField) - 1 & " --ﾀｲﾑｱｳﾄﾘｶﾊﾞﾘﾀｲﾏ")
        End If
        If IsNull(FLAST_TRNSSTART_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLAST_TRNSSTART_DT
            strSQL.Append(vbCrLf & "    AND FLAST_TRNSSTART_DT = :" & UBound(strBindField) - 1 & " --最終搬送開始日時")
        End If
        If IsNull(FJUNMATI_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFJUNMATI_DT
            strSQL.Append(vbCrLf & "    AND FJUNMATI_DT = :" & UBound(strBindField) - 1 & " --順待ち開始日時")
        End If
        If IsNull(FOUT_ST_RSV_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFOUT_ST_RSV_FLAG
            strSQL.Append(vbCrLf & "    AND FOUT_ST_RSV_FLAG = :" & UBound(strBindField) - 1 & " --ST予約出庫ﾌﾗｸﾞ")
        End If
        If IsNull(FKEEP_RSVRAC_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFKEEP_RSVRAC_FLAG
            strSQL.Append(vbCrLf & "    AND FKEEP_RSVRAC_FLAG = :" & UBound(strBindField) - 1 & " --出庫時棚予約保持ﾌﾗｸﾞ")
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
        strDataSetName = "TMST_SAGYO"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TMST_SAGYO(Owner, objDb, objDbLog)
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
    Public Function GET_TMST_SAGYO_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "TMST_SAGYO"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TMST_SAGYO(Owner, objDb, objDbLog)
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
    Public Function GET_TMST_SAGYO_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    TMST_SAGYO")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FSAGYOU_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_KIND
            strSQL.Append(vbCrLf & "    AND FSAGYOU_KIND = :" & UBound(strBindField) - 1 & " --作業種別")
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
        If IsNull(FSAGYOU_CONTENT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_CONTENT
            strSQL.Append(vbCrLf & "    AND FSAGYOU_CONTENT = :" & UBound(strBindField) - 1 & " --作業内容")
        End If
        If IsNull(FTIME_OUT_RCVTMR) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTIME_OUT_RCVTMR
            strSQL.Append(vbCrLf & "    AND FTIME_OUT_RCVTMR = :" & UBound(strBindField) - 1 & " --ﾀｲﾑｱｳﾄﾘｶﾊﾞﾘﾀｲﾏ")
        End If
        If IsNull(FLAST_TRNSSTART_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLAST_TRNSSTART_DT
            strSQL.Append(vbCrLf & "    AND FLAST_TRNSSTART_DT = :" & UBound(strBindField) - 1 & " --最終搬送開始日時")
        End If
        If IsNull(FJUNMATI_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFJUNMATI_DT
            strSQL.Append(vbCrLf & "    AND FJUNMATI_DT = :" & UBound(strBindField) - 1 & " --順待ち開始日時")
        End If
        If IsNull(FOUT_ST_RSV_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFOUT_ST_RSV_FLAG
            strSQL.Append(vbCrLf & "    AND FOUT_ST_RSV_FLAG = :" & UBound(strBindField) - 1 & " --ST予約出庫ﾌﾗｸﾞ")
        End If
        If IsNull(FKEEP_RSVRAC_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFKEEP_RSVRAC_FLAG
            strSQL.Append(vbCrLf & "    AND FKEEP_RSVRAC_FLAG = :" & UBound(strBindField) - 1 & " --出庫時棚予約保持ﾌﾗｸﾞ")
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
        strDataSetName = "TMST_SAGYO"
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
    Public Sub UPDATE_TMST_SAGYO()
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
        ElseIf IsNull(mFSAGYOU_KIND) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[作業種別]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFEQ_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[設備ID]"
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
        strSQL.Append(vbCrLf & "    TMST_SAGYO")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
        If IsNull(mFSAGYOU_KIND) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSAGYOU_KIND = NULL --作業種別")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSAGYOU_KIND = NULL --作業種別")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_KIND
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSAGYOU_KIND = :" & Ubound(strBindField) - 1 & " --作業種別")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSAGYOU_KIND = :" & Ubound(strBindField) - 1 & " --作業種別")
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
        If IsNull(mFSAGYOU_CONTENT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSAGYOU_CONTENT = NULL --作業内容")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSAGYOU_CONTENT = NULL --作業内容")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_CONTENT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSAGYOU_CONTENT = :" & Ubound(strBindField) - 1 & " --作業内容")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSAGYOU_CONTENT = :" & Ubound(strBindField) - 1 & " --作業内容")
        End If
        intCount = intCount + 1
        If IsNull(mFTIME_OUT_RCVTMR) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTIME_OUT_RCVTMR = NULL --ﾀｲﾑｱｳﾄﾘｶﾊﾞﾘﾀｲﾏ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTIME_OUT_RCVTMR = NULL --ﾀｲﾑｱｳﾄﾘｶﾊﾞﾘﾀｲﾏ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTIME_OUT_RCVTMR
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTIME_OUT_RCVTMR = :" & Ubound(strBindField) - 1 & " --ﾀｲﾑｱｳﾄﾘｶﾊﾞﾘﾀｲﾏ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTIME_OUT_RCVTMR = :" & Ubound(strBindField) - 1 & " --ﾀｲﾑｱｳﾄﾘｶﾊﾞﾘﾀｲﾏ")
        End If
        intCount = intCount + 1
        If IsNull(mFLAST_TRNSSTART_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLAST_TRNSSTART_DT = NULL --最終搬送開始日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLAST_TRNSSTART_DT = NULL --最終搬送開始日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLAST_TRNSSTART_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLAST_TRNSSTART_DT = :" & Ubound(strBindField) - 1 & " --最終搬送開始日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLAST_TRNSSTART_DT = :" & Ubound(strBindField) - 1 & " --最終搬送開始日時")
        End If
        intCount = intCount + 1
        If IsNull(mFJUNMATI_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FJUNMATI_DT = NULL --順待ち開始日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FJUNMATI_DT = NULL --順待ち開始日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFJUNMATI_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FJUNMATI_DT = :" & Ubound(strBindField) - 1 & " --順待ち開始日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FJUNMATI_DT = :" & Ubound(strBindField) - 1 & " --順待ち開始日時")
        End If
        intCount = intCount + 1
        If IsNull(mFOUT_ST_RSV_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FOUT_ST_RSV_FLAG = NULL --ST予約出庫ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FOUT_ST_RSV_FLAG = NULL --ST予約出庫ﾌﾗｸﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFOUT_ST_RSV_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FOUT_ST_RSV_FLAG = :" & Ubound(strBindField) - 1 & " --ST予約出庫ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FOUT_ST_RSV_FLAG = :" & Ubound(strBindField) - 1 & " --ST予約出庫ﾌﾗｸﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFKEEP_RSVRAC_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FKEEP_RSVRAC_FLAG = NULL --出庫時棚予約保持ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FKEEP_RSVRAC_FLAG = NULL --出庫時棚予約保持ﾌﾗｸﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFKEEP_RSVRAC_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FKEEP_RSVRAC_FLAG = :" & Ubound(strBindField) - 1 & " --出庫時棚予約保持ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FKEEP_RSVRAC_FLAG = :" & Ubound(strBindField) - 1 & " --出庫時棚予約保持ﾌﾗｸﾞ")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FSAGYOU_KIND) = True Then
            strSQL.Append(vbCrLf & "    AND FSAGYOU_KIND IS NULL --作業種別")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_KIND
            strSQL.Append(vbCrLf & "    AND FSAGYOU_KIND = :" & UBound(strBindField) - 1 & " --作業種別")
        End If
        If IsNull(FEQ_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FEQ_ID IS NULL --設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --設備ID")
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
    Public Sub ADD_TMST_SAGYO()
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
        ElseIf IsNull(mFSAGYOU_KIND) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[作業種別]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFEQ_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[設備ID]"
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
        strSQL.Append(vbCrLf & "    TMST_SAGYO")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
        If IsNull(mFSAGYOU_KIND) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --作業種別")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --作業種別")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_KIND
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --作業種別")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --作業種別")
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
        If IsNull(mFSAGYOU_CONTENT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --作業内容")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --作業内容")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_CONTENT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --作業内容")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --作業内容")
        End If
        intCount = intCount + 1
        If IsNull(mFTIME_OUT_RCVTMR) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾀｲﾑｱｳﾄﾘｶﾊﾞﾘﾀｲﾏ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾀｲﾑｱｳﾄﾘｶﾊﾞﾘﾀｲﾏ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTIME_OUT_RCVTMR
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾀｲﾑｱｳﾄﾘｶﾊﾞﾘﾀｲﾏ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾀｲﾑｱｳﾄﾘｶﾊﾞﾘﾀｲﾏ")
        End If
        intCount = intCount + 1
        If IsNull(mFLAST_TRNSSTART_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --最終搬送開始日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --最終搬送開始日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLAST_TRNSSTART_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --最終搬送開始日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --最終搬送開始日時")
        End If
        intCount = intCount + 1
        If IsNull(mFJUNMATI_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --順待ち開始日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --順待ち開始日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFJUNMATI_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --順待ち開始日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --順待ち開始日時")
        End If
        intCount = intCount + 1
        If IsNull(mFOUT_ST_RSV_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ST予約出庫ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ST予約出庫ﾌﾗｸﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFOUT_ST_RSV_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ST予約出庫ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ST予約出庫ﾌﾗｸﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFKEEP_RSVRAC_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --出庫時棚予約保持ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --出庫時棚予約保持ﾌﾗｸﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFKEEP_RSVRAC_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --出庫時棚予約保持ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --出庫時棚予約保持ﾌﾗｸﾞ")
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
    Public Sub DELETE_TMST_SAGYO()
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
        ElseIf IsNull(mFSAGYOU_KIND) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[作業種別]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFEQ_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[設備ID]"
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
        strSQL.Append(vbCrLf & "    TMST_SAGYO")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FSAGYOU_KIND) = True Then
            strSQL.Append(vbCrLf & "    AND FSAGYOU_KIND IS NULL --作業種別")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_KIND
            strSQL.Append(vbCrLf & "    AND FSAGYOU_KIND = :" & UBound(strBindField) - 1 & " --作業種別")
        End If
        If IsNull(FEQ_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FEQ_ID IS NULL --設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --設備ID")
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
    Public Sub DELETE_TMST_SAGYO_ANY()
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
        strSQL.Append(vbCrLf & "    TMST_SAGYO")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(FSAGYOU_KIND) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_KIND
            strSQL.Append(vbCrLf & "    AND FSAGYOU_KIND = :" & UBound(strBindField) - 1 & " --作業種別")
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
        If IsNotNull(FSAGYOU_CONTENT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_CONTENT
            strSQL.Append(vbCrLf & "    AND FSAGYOU_CONTENT = :" & UBound(strBindField) - 1 & " --作業内容")
        End If
        If IsNotNull(FTIME_OUT_RCVTMR) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTIME_OUT_RCVTMR
            strSQL.Append(vbCrLf & "    AND FTIME_OUT_RCVTMR = :" & UBound(strBindField) - 1 & " --ﾀｲﾑｱｳﾄﾘｶﾊﾞﾘﾀｲﾏ")
        End If
        If IsNotNull(FLAST_TRNSSTART_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLAST_TRNSSTART_DT
            strSQL.Append(vbCrLf & "    AND FLAST_TRNSSTART_DT = :" & UBound(strBindField) - 1 & " --最終搬送開始日時")
        End If
        If IsNotNull(FJUNMATI_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFJUNMATI_DT
            strSQL.Append(vbCrLf & "    AND FJUNMATI_DT = :" & UBound(strBindField) - 1 & " --順待ち開始日時")
        End If
        If IsNotNull(FOUT_ST_RSV_FLAG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFOUT_ST_RSV_FLAG
            strSQL.Append(vbCrLf & "    AND FOUT_ST_RSV_FLAG = :" & UBound(strBindField) - 1 & " --ST予約出庫ﾌﾗｸﾞ")
        End If
        If IsNotNull(FKEEP_RSVRAC_FLAG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFKEEP_RSVRAC_FLAG
            strSQL.Append(vbCrLf & "    AND FKEEP_RSVRAC_FLAG = :" & UBound(strBindField) - 1 & " --出庫時棚予約保持ﾌﾗｸﾞ")
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
        If IsNothing(objType.GetProperty("FSAGYOU_KIND")) = False Then mFSAGYOU_KIND = objObject.FSAGYOU_KIND '作業種別
        If IsNothing(objType.GetProperty("FEQ_ID")) = False Then mFEQ_ID = objObject.FEQ_ID '設備ID
        If IsNothing(objType.GetProperty("FPRIORITY")) = False Then mFPRIORITY = objObject.FPRIORITY '優先ﾚﾍﾞﾙ
        If IsNothing(objType.GetProperty("FSAGYOU_CONTENT")) = False Then mFSAGYOU_CONTENT = objObject.FSAGYOU_CONTENT '作業内容
        If IsNothing(objType.GetProperty("FTIME_OUT_RCVTMR")) = False Then mFTIME_OUT_RCVTMR = objObject.FTIME_OUT_RCVTMR 'ﾀｲﾑｱｳﾄﾘｶﾊﾞﾘﾀｲﾏ
        If IsNothing(objType.GetProperty("FLAST_TRNSSTART_DT")) = False Then mFLAST_TRNSSTART_DT = objObject.FLAST_TRNSSTART_DT '最終搬送開始日時
        If IsNothing(objType.GetProperty("FJUNMATI_DT")) = False Then mFJUNMATI_DT = objObject.FJUNMATI_DT '順待ち開始日時
        If IsNothing(objType.GetProperty("FOUT_ST_RSV_FLAG")) = False Then mFOUT_ST_RSV_FLAG = objObject.FOUT_ST_RSV_FLAG 'ST予約出庫ﾌﾗｸﾞ
        If IsNothing(objType.GetProperty("FKEEP_RSVRAC_FLAG")) = False Then mFKEEP_RSVRAC_FLAG = objObject.FKEEP_RSVRAC_FLAG '出庫時棚予約保持ﾌﾗｸﾞ

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
        mFSAGYOU_KIND = Nothing
        mFEQ_ID = Nothing
        mFPRIORITY = Nothing
        mFSAGYOU_CONTENT = Nothing
        mFTIME_OUT_RCVTMR = Nothing
        mFLAST_TRNSSTART_DT = Nothing
        mFJUNMATI_DT = Nothing
        mFOUT_ST_RSV_FLAG = Nothing
        mFKEEP_RSVRAC_FLAG = Nothing


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
        mFSAGYOU_KIND = TO_INTEGER_NULLABLE(objRow("FSAGYOU_KIND"))
        mFEQ_ID = TO_STRING_NULLABLE(objRow("FEQ_ID"))
        mFPRIORITY = TO_INTEGER_NULLABLE(objRow("FPRIORITY"))
        mFSAGYOU_CONTENT = TO_STRING_NULLABLE(objRow("FSAGYOU_CONTENT"))
        mFTIME_OUT_RCVTMR = TO_INTEGER_NULLABLE(objRow("FTIME_OUT_RCVTMR"))
        mFLAST_TRNSSTART_DT = TO_DATE_NULLABLE(objRow("FLAST_TRNSSTART_DT"))
        mFJUNMATI_DT = TO_DATE_NULLABLE(objRow("FJUNMATI_DT"))
        mFOUT_ST_RSV_FLAG = TO_INTEGER_NULLABLE(objRow("FOUT_ST_RSV_FLAG"))
        mFKEEP_RSVRAC_FLAG = TO_INTEGER_NULLABLE(objRow("FKEEP_RSVRAC_FLAG"))


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
        strMsg &= "[ﾃｰﾌﾞﾙ名:作業種別毎制御情報]"
        If IsNotNull(FSAGYOU_KIND) Then
            strMsg &= "[作業種別:" & FSAGYOU_KIND & "]"
        End If
        If IsNotNull(FEQ_ID) Then
            strMsg &= "[設備ID:" & FEQ_ID & "]"
        End If
        If IsNotNull(FPRIORITY) Then
            strMsg &= "[優先ﾚﾍﾞﾙ:" & FPRIORITY & "]"
        End If
        If IsNotNull(FSAGYOU_CONTENT) Then
            strMsg &= "[作業内容:" & FSAGYOU_CONTENT & "]"
        End If
        If IsNotNull(FTIME_OUT_RCVTMR) Then
            strMsg &= "[ﾀｲﾑｱｳﾄﾘｶﾊﾞﾘﾀｲﾏ:" & FTIME_OUT_RCVTMR & "]"
        End If
        If IsNotNull(FLAST_TRNSSTART_DT) Then
            strMsg &= "[最終搬送開始日時:" & FLAST_TRNSSTART_DT & "]"
        End If
        If IsNotNull(FJUNMATI_DT) Then
            strMsg &= "[順待ち開始日時:" & FJUNMATI_DT & "]"
        End If
        If IsNotNull(FOUT_ST_RSV_FLAG) Then
            strMsg &= "[ST予約出庫ﾌﾗｸﾞ:" & FOUT_ST_RSV_FLAG & "]"
        End If
        If IsNotNull(FKEEP_RSVRAC_FLAG) Then
            strMsg &= "[出庫時棚予約保持ﾌﾗｸﾞ:" & FKEEP_RSVRAC_FLAG & "]"
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
