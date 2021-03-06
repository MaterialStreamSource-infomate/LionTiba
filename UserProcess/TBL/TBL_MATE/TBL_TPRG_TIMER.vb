'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' 【名称】MaterialStreamﾃｰﾌﾞﾙｸﾗｽ
' 【機能】定周期管理ﾃｰﾌﾞﾙｸﾗｽ
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
''' 定周期管理ﾃｰﾌﾞﾙｸﾗｽ
''' </summary>
Public Class TBL_TPRG_TIMER
    Inherits clsTemplateTable

    '**********************************************************************************************
    '↓↓↓自動生成部
#Region "  ｸﾗｽ変数定義                  "
    'ﾌﾟﾛﾊﾟﾃｨ
    Private mobjAryMe As TBL_TPRG_TIMER()                                        '定周期管理
    Private mstrUSER_SQL As String                                               'ﾕｰｻﾞｰSQL
    Private mORDER_BY As String                                                  'OrderBy句
    Private mWHERE As String                                                     'Where句
    Private mFSYORI_ID As String                                                 '処理ID
    Private mFYUKOU_FLAG As Nullable(Of Integer)                                 '有効ﾌﾗｸﾞ
    Private mFKIDOU_FLAG As Nullable(Of Integer)                                 '起動ﾌﾗｸﾞ
    Private mFEXEC_DT As Nullable(Of Date)                                       '実行時間
    Private mFRANK As Nullable(Of Integer)                                       '処理優先順位
    Private mFRANK_DTL As Nullable(Of Integer)                                   '処理優先順位詳細
    Private mFSOCKET_MSG As String                                               '処理
    Private mFLAST_DT As Nullable(Of Date)                                       '最終処理日時
    Private mFTIME_OUT_SEC As Nullable(Of Integer)                               'ﾀｲﾏｰ周期
    Private mFCOMMENT As String                                                  'ｺﾒﾝﾄ
    Private mFLOG_OPE_FLAG As Nullable(Of Integer)                               'ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ登録ﾌﾗｸﾞ
    Private mFLOG_TRN_FLAG As Nullable(Of Integer)                               'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ登録ﾌﾗｸﾞ
    Private mFEVD_OPE_FLAG As Nullable(Of Integer)                               '作業履歴登録ﾌﾗｸﾞ
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                  "
    ''' <summary>
    ''' ｼｽﾃﾑ変数 (自ｸﾗｽ型配列)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_TPRG_TIMER()
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
    ''' 有効ﾌﾗｸﾞ
    ''' </summary>
    Public Property FYUKOU_FLAG() As Nullable(Of Integer)
        Get
            Return mFYUKOU_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFYUKOU_FLAG = Value
        End Set
    End Property
    ''' <summary>
    ''' 起動ﾌﾗｸﾞ
    ''' </summary>
    Public Property FKIDOU_FLAG() As Nullable(Of Integer)
        Get
            Return mFKIDOU_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFKIDOU_FLAG = Value
        End Set
    End Property
    ''' <summary>
    ''' 実行時間
    ''' </summary>
    Public Property FEXEC_DT() As Nullable(Of Date)
        Get
            Return mFEXEC_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mFEXEC_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' 処理優先順位
    ''' </summary>
    Public Property FRANK() As Nullable(Of Integer)
        Get
            Return mFRANK
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRANK = Value
        End Set
    End Property
    ''' <summary>
    ''' 処理優先順位詳細
    ''' </summary>
    Public Property FRANK_DTL() As Nullable(Of Integer)
        Get
            Return mFRANK_DTL
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRANK_DTL = Value
        End Set
    End Property
    ''' <summary>
    ''' 処理
    ''' </summary>
    Public Property FSOCKET_MSG() As String
        Get
            Return mFSOCKET_MSG
        End Get
        Set(ByVal Value As String)
            mFSOCKET_MSG = Value
        End Set
    End Property
    ''' <summary>
    ''' 最終処理日時
    ''' </summary>
    Public Property FLAST_DT() As Nullable(Of Date)
        Get
            Return mFLAST_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mFLAST_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾀｲﾏｰ周期
    ''' </summary>
    Public Property FTIME_OUT_SEC() As Nullable(Of Integer)
        Get
            Return mFTIME_OUT_SEC
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFTIME_OUT_SEC = Value
        End Set
    End Property
    ''' <summary>
    ''' ｺﾒﾝﾄ
    ''' </summary>
    Public Property FCOMMENT() As String
        Get
            Return mFCOMMENT
        End Get
        Set(ByVal Value As String)
            mFCOMMENT = Value
        End Set
    End Property
    ''' <summary>
    ''' ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ登録ﾌﾗｸﾞ
    ''' </summary>
    Public Property FLOG_OPE_FLAG() As Nullable(Of Integer)
        Get
            Return mFLOG_OPE_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFLOG_OPE_FLAG = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ登録ﾌﾗｸﾞ
    ''' </summary>
    Public Property FLOG_TRN_FLAG() As Nullable(Of Integer)
        Get
            Return mFLOG_TRN_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFLOG_TRN_FLAG = Value
        End Set
    End Property
    ''' <summary>
    ''' 作業履歴登録ﾌﾗｸﾞ
    ''' </summary>
    Public Property FEVD_OPE_FLAG() As Nullable(Of Integer)
        Get
            Return mFEVD_OPE_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFEVD_OPE_FLAG = Value
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
    Public Function GET_TPRG_TIMER(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    TPRG_TIMER")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FSYORI_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYORI_ID
            strSQL.Append(vbCrLf & "    AND FSYORI_ID = :" & UBound(strBindField) - 1 & " --処理ID")
        End If
        If IsNull(FYUKOU_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFYUKOU_FLAG
            strSQL.Append(vbCrLf & "    AND FYUKOU_FLAG = :" & UBound(strBindField) - 1 & " --有効ﾌﾗｸﾞ")
        End If
        If IsNull(FKIDOU_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFKIDOU_FLAG
            strSQL.Append(vbCrLf & "    AND FKIDOU_FLAG = :" & UBound(strBindField) - 1 & " --起動ﾌﾗｸﾞ")
        End If
        If IsNull(FEXEC_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEXEC_DT
            strSQL.Append(vbCrLf & "    AND FEXEC_DT = :" & UBound(strBindField) - 1 & " --実行時間")
        End If
        If IsNull(FRANK) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRANK
            strSQL.Append(vbCrLf & "    AND FRANK = :" & UBound(strBindField) - 1 & " --処理優先順位")
        End If
        If IsNull(FRANK_DTL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRANK_DTL
            strSQL.Append(vbCrLf & "    AND FRANK_DTL = :" & UBound(strBindField) - 1 & " --処理優先順位詳細")
        End If
        If IsNull(FSOCKET_MSG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSOCKET_MSG
            strSQL.Append(vbCrLf & "    AND FSOCKET_MSG = :" & UBound(strBindField) - 1 & " --処理")
        End If
        If IsNull(FLAST_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLAST_DT
            strSQL.Append(vbCrLf & "    AND FLAST_DT = :" & UBound(strBindField) - 1 & " --最終処理日時")
        End If
        If IsNull(FTIME_OUT_SEC) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTIME_OUT_SEC
            strSQL.Append(vbCrLf & "    AND FTIME_OUT_SEC = :" & UBound(strBindField) - 1 & " --ﾀｲﾏｰ周期")
        End If
        If IsNull(FCOMMENT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOMMENT
            strSQL.Append(vbCrLf & "    AND FCOMMENT = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ")
        End If
        If IsNull(FLOG_OPE_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_OPE_FLAG
            strSQL.Append(vbCrLf & "    AND FLOG_OPE_FLAG = :" & UBound(strBindField) - 1 & " --ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ登録ﾌﾗｸﾞ")
        End If
        If IsNull(FLOG_TRN_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_TRN_FLAG
            strSQL.Append(vbCrLf & "    AND FLOG_TRN_FLAG = :" & UBound(strBindField) - 1 & " --ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ登録ﾌﾗｸﾞ")
        End If
        If IsNull(FEVD_OPE_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEVD_OPE_FLAG
            strSQL.Append(vbCrLf & "    AND FEVD_OPE_FLAG = :" & UBound(strBindField) - 1 & " --作業履歴登録ﾌﾗｸﾞ")
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
        strDataSetName = "TPRG_TIMER"
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
    Public Function GET_TPRG_TIMER_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    TPRG_TIMER")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FSYORI_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYORI_ID
            strSQL.Append(vbCrLf & "    AND FSYORI_ID = :" & UBound(strBindField) - 1 & " --処理ID")
        End If
        If IsNull(FYUKOU_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFYUKOU_FLAG
            strSQL.Append(vbCrLf & "    AND FYUKOU_FLAG = :" & UBound(strBindField) - 1 & " --有効ﾌﾗｸﾞ")
        End If
        If IsNull(FKIDOU_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFKIDOU_FLAG
            strSQL.Append(vbCrLf & "    AND FKIDOU_FLAG = :" & UBound(strBindField) - 1 & " --起動ﾌﾗｸﾞ")
        End If
        If IsNull(FEXEC_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEXEC_DT
            strSQL.Append(vbCrLf & "    AND FEXEC_DT = :" & UBound(strBindField) - 1 & " --実行時間")
        End If
        If IsNull(FRANK) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRANK
            strSQL.Append(vbCrLf & "    AND FRANK = :" & UBound(strBindField) - 1 & " --処理優先順位")
        End If
        If IsNull(FRANK_DTL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRANK_DTL
            strSQL.Append(vbCrLf & "    AND FRANK_DTL = :" & UBound(strBindField) - 1 & " --処理優先順位詳細")
        End If
        If IsNull(FSOCKET_MSG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSOCKET_MSG
            strSQL.Append(vbCrLf & "    AND FSOCKET_MSG = :" & UBound(strBindField) - 1 & " --処理")
        End If
        If IsNull(FLAST_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLAST_DT
            strSQL.Append(vbCrLf & "    AND FLAST_DT = :" & UBound(strBindField) - 1 & " --最終処理日時")
        End If
        If IsNull(FTIME_OUT_SEC) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTIME_OUT_SEC
            strSQL.Append(vbCrLf & "    AND FTIME_OUT_SEC = :" & UBound(strBindField) - 1 & " --ﾀｲﾏｰ周期")
        End If
        If IsNull(FCOMMENT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOMMENT
            strSQL.Append(vbCrLf & "    AND FCOMMENT = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ")
        End If
        If IsNull(FLOG_OPE_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_OPE_FLAG
            strSQL.Append(vbCrLf & "    AND FLOG_OPE_FLAG = :" & UBound(strBindField) - 1 & " --ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ登録ﾌﾗｸﾞ")
        End If
        If IsNull(FLOG_TRN_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_TRN_FLAG
            strSQL.Append(vbCrLf & "    AND FLOG_TRN_FLAG = :" & UBound(strBindField) - 1 & " --ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ登録ﾌﾗｸﾞ")
        End If
        If IsNull(FEVD_OPE_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEVD_OPE_FLAG
            strSQL.Append(vbCrLf & "    AND FEVD_OPE_FLAG = :" & UBound(strBindField) - 1 & " --作業履歴登録ﾌﾗｸﾞ")
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
        strDataSetName = "TPRG_TIMER"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TPRG_TIMER(Owner, objDb, objDbLog)
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
    Public Function GET_TPRG_TIMER_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "TPRG_TIMER"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TPRG_TIMER(Owner, objDb, objDbLog)
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
    Public Function GET_TPRG_TIMER_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    TPRG_TIMER")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FSYORI_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYORI_ID
            strSQL.Append(vbCrLf & "    AND FSYORI_ID = :" & UBound(strBindField) - 1 & " --処理ID")
        End If
        If IsNull(FYUKOU_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFYUKOU_FLAG
            strSQL.Append(vbCrLf & "    AND FYUKOU_FLAG = :" & UBound(strBindField) - 1 & " --有効ﾌﾗｸﾞ")
        End If
        If IsNull(FKIDOU_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFKIDOU_FLAG
            strSQL.Append(vbCrLf & "    AND FKIDOU_FLAG = :" & UBound(strBindField) - 1 & " --起動ﾌﾗｸﾞ")
        End If
        If IsNull(FEXEC_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEXEC_DT
            strSQL.Append(vbCrLf & "    AND FEXEC_DT = :" & UBound(strBindField) - 1 & " --実行時間")
        End If
        If IsNull(FRANK) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRANK
            strSQL.Append(vbCrLf & "    AND FRANK = :" & UBound(strBindField) - 1 & " --処理優先順位")
        End If
        If IsNull(FRANK_DTL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRANK_DTL
            strSQL.Append(vbCrLf & "    AND FRANK_DTL = :" & UBound(strBindField) - 1 & " --処理優先順位詳細")
        End If
        If IsNull(FSOCKET_MSG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSOCKET_MSG
            strSQL.Append(vbCrLf & "    AND FSOCKET_MSG = :" & UBound(strBindField) - 1 & " --処理")
        End If
        If IsNull(FLAST_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLAST_DT
            strSQL.Append(vbCrLf & "    AND FLAST_DT = :" & UBound(strBindField) - 1 & " --最終処理日時")
        End If
        If IsNull(FTIME_OUT_SEC) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTIME_OUT_SEC
            strSQL.Append(vbCrLf & "    AND FTIME_OUT_SEC = :" & UBound(strBindField) - 1 & " --ﾀｲﾏｰ周期")
        End If
        If IsNull(FCOMMENT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOMMENT
            strSQL.Append(vbCrLf & "    AND FCOMMENT = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ")
        End If
        If IsNull(FLOG_OPE_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_OPE_FLAG
            strSQL.Append(vbCrLf & "    AND FLOG_OPE_FLAG = :" & UBound(strBindField) - 1 & " --ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ登録ﾌﾗｸﾞ")
        End If
        If IsNull(FLOG_TRN_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_TRN_FLAG
            strSQL.Append(vbCrLf & "    AND FLOG_TRN_FLAG = :" & UBound(strBindField) - 1 & " --ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ登録ﾌﾗｸﾞ")
        End If
        If IsNull(FEVD_OPE_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEVD_OPE_FLAG
            strSQL.Append(vbCrLf & "    AND FEVD_OPE_FLAG = :" & UBound(strBindField) - 1 & " --作業履歴登録ﾌﾗｸﾞ")
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
        strDataSetName = "TPRG_TIMER"
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
    Public Sub UPDATE_TPRG_TIMER()
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
        End If


        '***********************
        '更新SQL作成
        '***********************
        strBindField = Nothing
        objBindValue = Nothing
        ReDim Preserve strBindField(0)
        ReDim Preserve objBindValue(0)
        strSQL.Append(vbCrLf & "UPDATE")
        strSQL.Append(vbCrLf & "    TPRG_TIMER")
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
        If IsNull(mFYUKOU_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FYUKOU_FLAG = NULL --有効ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FYUKOU_FLAG = NULL --有効ﾌﾗｸﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFYUKOU_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FYUKOU_FLAG = :" & Ubound(strBindField) - 1 & " --有効ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FYUKOU_FLAG = :" & Ubound(strBindField) - 1 & " --有効ﾌﾗｸﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFKIDOU_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FKIDOU_FLAG = NULL --起動ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FKIDOU_FLAG = NULL --起動ﾌﾗｸﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFKIDOU_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FKIDOU_FLAG = :" & Ubound(strBindField) - 1 & " --起動ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FKIDOU_FLAG = :" & Ubound(strBindField) - 1 & " --起動ﾌﾗｸﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFEXEC_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEXEC_DT = NULL --実行時間")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEXEC_DT = NULL --実行時間")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEXEC_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEXEC_DT = :" & Ubound(strBindField) - 1 & " --実行時間")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEXEC_DT = :" & Ubound(strBindField) - 1 & " --実行時間")
        End If
        intCount = intCount + 1
        If IsNull(mFRANK) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRANK = NULL --処理優先順位")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRANK = NULL --処理優先順位")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRANK
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRANK = :" & Ubound(strBindField) - 1 & " --処理優先順位")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRANK = :" & Ubound(strBindField) - 1 & " --処理優先順位")
        End If
        intCount = intCount + 1
        If IsNull(mFRANK_DTL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRANK_DTL = NULL --処理優先順位詳細")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRANK_DTL = NULL --処理優先順位詳細")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRANK_DTL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRANK_DTL = :" & Ubound(strBindField) - 1 & " --処理優先順位詳細")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRANK_DTL = :" & Ubound(strBindField) - 1 & " --処理優先順位詳細")
        End If
        intCount = intCount + 1
        If IsNull(mFSOCKET_MSG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSOCKET_MSG = NULL --処理")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSOCKET_MSG = NULL --処理")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSOCKET_MSG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSOCKET_MSG = :" & Ubound(strBindField) - 1 & " --処理")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSOCKET_MSG = :" & Ubound(strBindField) - 1 & " --処理")
        End If
        intCount = intCount + 1
        If IsNull(mFLAST_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLAST_DT = NULL --最終処理日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLAST_DT = NULL --最終処理日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLAST_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLAST_DT = :" & Ubound(strBindField) - 1 & " --最終処理日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLAST_DT = :" & Ubound(strBindField) - 1 & " --最終処理日時")
        End If
        intCount = intCount + 1
        If IsNull(mFTIME_OUT_SEC) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTIME_OUT_SEC = NULL --ﾀｲﾏｰ周期")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTIME_OUT_SEC = NULL --ﾀｲﾏｰ周期")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTIME_OUT_SEC
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTIME_OUT_SEC = :" & Ubound(strBindField) - 1 & " --ﾀｲﾏｰ周期")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTIME_OUT_SEC = :" & Ubound(strBindField) - 1 & " --ﾀｲﾏｰ周期")
        End If
        intCount = intCount + 1
        If IsNull(mFCOMMENT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCOMMENT = NULL --ｺﾒﾝﾄ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCOMMENT = NULL --ｺﾒﾝﾄ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOMMENT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FCOMMENT = :" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FCOMMENT = :" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ")
        End If
        intCount = intCount + 1
        If IsNull(mFLOG_OPE_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_OPE_FLAG = NULL --ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ登録ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_OPE_FLAG = NULL --ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ登録ﾌﾗｸﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_OPE_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_OPE_FLAG = :" & Ubound(strBindField) - 1 & " --ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ登録ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_OPE_FLAG = :" & Ubound(strBindField) - 1 & " --ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ登録ﾌﾗｸﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFLOG_TRN_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_TRN_FLAG = NULL --ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ登録ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_TRN_FLAG = NULL --ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ登録ﾌﾗｸﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_TRN_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_TRN_FLAG = :" & Ubound(strBindField) - 1 & " --ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ登録ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_TRN_FLAG = :" & Ubound(strBindField) - 1 & " --ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ登録ﾌﾗｸﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFEVD_OPE_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEVD_OPE_FLAG = NULL --作業履歴登録ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEVD_OPE_FLAG = NULL --作業履歴登録ﾌﾗｸﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEVD_OPE_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEVD_OPE_FLAG = :" & Ubound(strBindField) - 1 & " --作業履歴登録ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEVD_OPE_FLAG = :" & Ubound(strBindField) - 1 & " --作業履歴登録ﾌﾗｸﾞ")
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
    Public Sub ADD_TPRG_TIMER()
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
        End If


        '***********************
        '追加SQL作成
        '***********************
        strBindField = Nothing
        objBindValue = Nothing
        ReDim Preserve strBindField(0)
        ReDim Preserve objBindValue(0)
        strSQL.Append(vbCrLf & "INSERT INTO")
        strSQL.Append(vbCrLf & "    TPRG_TIMER")
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
        If IsNull(mFYUKOU_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --有効ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --有効ﾌﾗｸﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFYUKOU_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --有効ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --有効ﾌﾗｸﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFKIDOU_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --起動ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --起動ﾌﾗｸﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFKIDOU_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --起動ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --起動ﾌﾗｸﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFEXEC_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --実行時間")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --実行時間")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEXEC_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --実行時間")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --実行時間")
        End If
        intCount = intCount + 1
        If IsNull(mFRANK) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --処理優先順位")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --処理優先順位")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRANK
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --処理優先順位")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --処理優先順位")
        End If
        intCount = intCount + 1
        If IsNull(mFRANK_DTL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --処理優先順位詳細")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --処理優先順位詳細")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRANK_DTL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --処理優先順位詳細")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --処理優先順位詳細")
        End If
        intCount = intCount + 1
        If IsNull(mFSOCKET_MSG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --処理")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --処理")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSOCKET_MSG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --処理")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --処理")
        End If
        intCount = intCount + 1
        If IsNull(mFLAST_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --最終処理日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --最終処理日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLAST_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --最終処理日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --最終処理日時")
        End If
        intCount = intCount + 1
        If IsNull(mFTIME_OUT_SEC) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾀｲﾏｰ周期")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾀｲﾏｰ周期")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTIME_OUT_SEC
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾀｲﾏｰ周期")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾀｲﾏｰ周期")
        End If
        intCount = intCount + 1
        If IsNull(mFCOMMENT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｺﾒﾝﾄ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｺﾒﾝﾄ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOMMENT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｺﾒﾝﾄ")
        End If
        intCount = intCount + 1
        If IsNull(mFLOG_OPE_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ登録ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ登録ﾌﾗｸﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_OPE_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ登録ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ登録ﾌﾗｸﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFLOG_TRN_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ登録ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ登録ﾌﾗｸﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_TRN_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ登録ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ登録ﾌﾗｸﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFEVD_OPE_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --作業履歴登録ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --作業履歴登録ﾌﾗｸﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEVD_OPE_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --作業履歴登録ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --作業履歴登録ﾌﾗｸﾞ")
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
    Public Sub DELETE_TPRG_TIMER()
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
        strSQL.Append(vbCrLf & "    TPRG_TIMER")
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
    Public Sub DELETE_TPRG_TIMER_ANY()
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
        strSQL.Append(vbCrLf & "    TPRG_TIMER")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(FSYORI_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYORI_ID
            strSQL.Append(vbCrLf & "    AND FSYORI_ID = :" & UBound(strBindField) - 1 & " --処理ID")
        End If
        If IsNotNull(FYUKOU_FLAG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFYUKOU_FLAG
            strSQL.Append(vbCrLf & "    AND FYUKOU_FLAG = :" & UBound(strBindField) - 1 & " --有効ﾌﾗｸﾞ")
        End If
        If IsNotNull(FKIDOU_FLAG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFKIDOU_FLAG
            strSQL.Append(vbCrLf & "    AND FKIDOU_FLAG = :" & UBound(strBindField) - 1 & " --起動ﾌﾗｸﾞ")
        End If
        If IsNotNull(FEXEC_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEXEC_DT
            strSQL.Append(vbCrLf & "    AND FEXEC_DT = :" & UBound(strBindField) - 1 & " --実行時間")
        End If
        If IsNotNull(FRANK) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRANK
            strSQL.Append(vbCrLf & "    AND FRANK = :" & UBound(strBindField) - 1 & " --処理優先順位")
        End If
        If IsNotNull(FRANK_DTL) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRANK_DTL
            strSQL.Append(vbCrLf & "    AND FRANK_DTL = :" & UBound(strBindField) - 1 & " --処理優先順位詳細")
        End If
        If IsNotNull(FSOCKET_MSG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSOCKET_MSG
            strSQL.Append(vbCrLf & "    AND FSOCKET_MSG = :" & UBound(strBindField) - 1 & " --処理")
        End If
        If IsNotNull(FLAST_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLAST_DT
            strSQL.Append(vbCrLf & "    AND FLAST_DT = :" & UBound(strBindField) - 1 & " --最終処理日時")
        End If
        If IsNotNull(FTIME_OUT_SEC) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTIME_OUT_SEC
            strSQL.Append(vbCrLf & "    AND FTIME_OUT_SEC = :" & UBound(strBindField) - 1 & " --ﾀｲﾏｰ周期")
        End If
        If IsNotNull(FCOMMENT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOMMENT
            strSQL.Append(vbCrLf & "    AND FCOMMENT = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ")
        End If
        If IsNotNull(FLOG_OPE_FLAG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_OPE_FLAG
            strSQL.Append(vbCrLf & "    AND FLOG_OPE_FLAG = :" & UBound(strBindField) - 1 & " --ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ登録ﾌﾗｸﾞ")
        End If
        If IsNotNull(FLOG_TRN_FLAG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_TRN_FLAG
            strSQL.Append(vbCrLf & "    AND FLOG_TRN_FLAG = :" & UBound(strBindField) - 1 & " --ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ登録ﾌﾗｸﾞ")
        End If
        If IsNotNull(FEVD_OPE_FLAG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEVD_OPE_FLAG
            strSQL.Append(vbCrLf & "    AND FEVD_OPE_FLAG = :" & UBound(strBindField) - 1 & " --作業履歴登録ﾌﾗｸﾞ")
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
        If IsNothing(objType.GetProperty("FYUKOU_FLAG")) = False Then mFYUKOU_FLAG = objObject.FYUKOU_FLAG '有効ﾌﾗｸﾞ
        If IsNothing(objType.GetProperty("FKIDOU_FLAG")) = False Then mFKIDOU_FLAG = objObject.FKIDOU_FLAG '起動ﾌﾗｸﾞ
        If IsNothing(objType.GetProperty("FEXEC_DT")) = False Then mFEXEC_DT = objObject.FEXEC_DT '実行時間
        If IsNothing(objType.GetProperty("FRANK")) = False Then mFRANK = objObject.FRANK '処理優先順位
        If IsNothing(objType.GetProperty("FRANK_DTL")) = False Then mFRANK_DTL = objObject.FRANK_DTL '処理優先順位詳細
        If IsNothing(objType.GetProperty("FSOCKET_MSG")) = False Then mFSOCKET_MSG = objObject.FSOCKET_MSG '処理
        If IsNothing(objType.GetProperty("FLAST_DT")) = False Then mFLAST_DT = objObject.FLAST_DT '最終処理日時
        If IsNothing(objType.GetProperty("FTIME_OUT_SEC")) = False Then mFTIME_OUT_SEC = objObject.FTIME_OUT_SEC 'ﾀｲﾏｰ周期
        If IsNothing(objType.GetProperty("FCOMMENT")) = False Then mFCOMMENT = objObject.FCOMMENT 'ｺﾒﾝﾄ
        If IsNothing(objType.GetProperty("FLOG_OPE_FLAG")) = False Then mFLOG_OPE_FLAG = objObject.FLOG_OPE_FLAG 'ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ登録ﾌﾗｸﾞ
        If IsNothing(objType.GetProperty("FLOG_TRN_FLAG")) = False Then mFLOG_TRN_FLAG = objObject.FLOG_TRN_FLAG 'ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ登録ﾌﾗｸﾞ
        If IsNothing(objType.GetProperty("FEVD_OPE_FLAG")) = False Then mFEVD_OPE_FLAG = objObject.FEVD_OPE_FLAG '作業履歴登録ﾌﾗｸﾞ

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
        mFYUKOU_FLAG = Nothing
        mFKIDOU_FLAG = Nothing
        mFEXEC_DT = Nothing
        mFRANK = Nothing
        mFRANK_DTL = Nothing
        mFSOCKET_MSG = Nothing
        mFLAST_DT = Nothing
        mFTIME_OUT_SEC = Nothing
        mFCOMMENT = Nothing
        mFLOG_OPE_FLAG = Nothing
        mFLOG_TRN_FLAG = Nothing
        mFEVD_OPE_FLAG = Nothing


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
        mFYUKOU_FLAG = TO_INTEGER_NULLABLE(objRow("FYUKOU_FLAG"))
        mFKIDOU_FLAG = TO_INTEGER_NULLABLE(objRow("FKIDOU_FLAG"))
        mFEXEC_DT = TO_DATE_NULLABLE(objRow("FEXEC_DT"))
        mFRANK = TO_INTEGER_NULLABLE(objRow("FRANK"))
        mFRANK_DTL = TO_INTEGER_NULLABLE(objRow("FRANK_DTL"))
        mFSOCKET_MSG = TO_STRING_NULLABLE(objRow("FSOCKET_MSG"))
        mFLAST_DT = TO_DATE_NULLABLE(objRow("FLAST_DT"))
        mFTIME_OUT_SEC = TO_INTEGER_NULLABLE(objRow("FTIME_OUT_SEC"))
        mFCOMMENT = TO_STRING_NULLABLE(objRow("FCOMMENT"))
        mFLOG_OPE_FLAG = TO_INTEGER_NULLABLE(objRow("FLOG_OPE_FLAG"))
        mFLOG_TRN_FLAG = TO_INTEGER_NULLABLE(objRow("FLOG_TRN_FLAG"))
        mFEVD_OPE_FLAG = TO_INTEGER_NULLABLE(objRow("FEVD_OPE_FLAG"))


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
        strMsg &= "[ﾃｰﾌﾞﾙ名:定周期管理]"
        If IsNotNull(FSYORI_ID) Then
            strMsg &= "[処理ID:" & FSYORI_ID & "]"
        End If
        If IsNotNull(FYUKOU_FLAG) Then
            strMsg &= "[有効ﾌﾗｸﾞ:" & FYUKOU_FLAG & "]"
        End If
        If IsNotNull(FKIDOU_FLAG) Then
            strMsg &= "[起動ﾌﾗｸﾞ:" & FKIDOU_FLAG & "]"
        End If
        If IsNotNull(FEXEC_DT) Then
            strMsg &= "[実行時間:" & FEXEC_DT & "]"
        End If
        If IsNotNull(FRANK) Then
            strMsg &= "[処理優先順位:" & FRANK & "]"
        End If
        If IsNotNull(FRANK_DTL) Then
            strMsg &= "[処理優先順位詳細:" & FRANK_DTL & "]"
        End If
        If IsNotNull(FSOCKET_MSG) Then
            strMsg &= "[処理:" & FSOCKET_MSG & "]"
        End If
        If IsNotNull(FLAST_DT) Then
            strMsg &= "[最終処理日時:" & FLAST_DT & "]"
        End If
        If IsNotNull(FTIME_OUT_SEC) Then
            strMsg &= "[ﾀｲﾏｰ周期:" & FTIME_OUT_SEC & "]"
        End If
        If IsNotNull(FCOMMENT) Then
            strMsg &= "[ｺﾒﾝﾄ:" & FCOMMENT & "]"
        End If
        If IsNotNull(FLOG_OPE_FLAG) Then
            strMsg &= "[ｵﾍﾟﾚｰｼｮﾝﾛｸﾞ登録ﾌﾗｸﾞ:" & FLOG_OPE_FLAG & "]"
        End If
        If IsNotNull(FLOG_TRN_FLAG) Then
            strMsg &= "[ﾄﾗﾝｻﾞｸｼｮﾝﾛｸﾞ登録ﾌﾗｸﾞ:" & FLOG_TRN_FLAG & "]"
        End If
        If IsNotNull(FEVD_OPE_FLAG) Then
            strMsg &= "[作業履歴登録ﾌﾗｸﾞ:" & FEVD_OPE_FLAG & "]"
        End If


    End Sub
#End Region
    '↑↑↑自動生成部
    '**********************************************************************************************

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ共通
#Region "  有効ﾌﾗｸﾞON               (Public  YUKOU_ON)"
    Public Sub YUKOU_ON(ByVal strSYORI_ID As String)
        Try
            Dim intRet As Integer               '戻り値


            '***********************
            '定周期管理情報取得
            '***********************
            '↓↓↓↓↓↓************************************************************************************************************
            'Checked SystemMate:N.Dounoshita 2011/10/20 ﾒｿｯﾄﾞを連続Call出来ない為、修正
            Call CLEAR_PROPERTY()
            '↑↑↑↑↑↑************************************************************************************************************
            mFSYORI_ID = strSYORI_ID
            intRet = Me.GET_TPRG_TIMER(True)


            '***********************
            '定周期管理情報更新
            '***********************
            mFLAST_DT = Now
            mFYUKOU_FLAG = FLAG_ON
            Me.UPDATE_TPRG_TIMER()


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
#Region "  有効ﾌﾗｸﾞOFF              (Public  YUUOU_OFF)"
    Public Sub YUKOU_OFF(ByVal strSYORI_ID As String)
        Try
            Dim intRet As Integer               '戻り値

            '***********************
            '定周期管理情報取得
            '***********************
            '↓↓↓↓↓↓************************************************************************************************************
            'Checked SystemMate:N.Dounoshita 2011/10/20 ﾒｿｯﾄﾞを連続Call出来ない為、修正
            Call CLEAR_PROPERTY()
            '↑↑↑↑↑↑************************************************************************************************************
            mFSYORI_ID = strSYORI_ID
            intRet = Me.GET_TPRG_TIMER(True)


            '***********************
            '定周期管理情報更新
            '***********************
            mFLAST_DT = Now
            mFYUKOU_FLAG = FLAG_OFF
            Me.UPDATE_TPRG_TIMER()


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
#Region "  起動ﾌﾗｸﾞON               (Public  KIDOU_ON)"
    Public Sub KIDOU_ON(ByVal strSYORI_ID As String)
        Try
            Dim intRet As Integer               '戻り値

            '***********************
            '定周期管理情報取得
            '***********************
            '↓↓↓↓↓↓************************************************************************************************************
            'Checked SystemMate:N.Dounoshita 2011/10/20 ﾒｿｯﾄﾞを連続Call出来ない為、修正
            Call CLEAR_PROPERTY()
            '↑↑↑↑↑↑************************************************************************************************************
            mFSYORI_ID = FORMAT_DSP_DELCMD & strSYORI_ID
            intRet = Me.GET_TPRG_TIMER(True)


            '***********************
            '定周期管理情報更新
            '***********************
            mFLAST_DT = Now
            mFKIDOU_FLAG = FLAG_ON
            Me.UPDATE_TPRG_TIMER()


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
#Region "  起動ﾌﾗｸﾞOFF              (Public  KIDOU_OFF)"
    Public Sub KIDOU_OFF(ByVal strSYORI_ID As String)
        Try
            Dim intRet As Integer               '戻り値

            '***********************
            '定周期管理情報取得
            '***********************
            '↓↓↓↓↓↓************************************************************************************************************
            'Checked SystemMate:N.Dounoshita 2011/10/20 ﾒｿｯﾄﾞを連続Call出来ない為、修正
            Call CLEAR_PROPERTY()
            '↑↑↑↑↑↑************************************************************************************************************
            mFSYORI_ID = strSYORI_ID
            intRet = Me.GET_TPRG_TIMER(True)


            '***********************
            '定周期管理情報更新
            '***********************
            mFLAST_DT = Now
            mFKIDOU_FLAG = FLAG_OFF
            Me.UPDATE_TPRG_TIMER()


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
