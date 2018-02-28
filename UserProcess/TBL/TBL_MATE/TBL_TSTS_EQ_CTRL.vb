'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' 【名称】MaterialStreamﾃｰﾌﾞﾙｸﾗｽ
' 【機能】設備状況ﾃｰﾌﾞﾙｸﾗｽ
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
''' 設備状況ﾃｰﾌﾞﾙｸﾗｽ
''' </summary>
Public Class TBL_TSTS_EQ_CTRL
    Inherits clsTemplateTable

    '**********************************************************************************************
    '↓↓↓自動生成部
#Region "  ｸﾗｽ変数定義                  "
    'ﾌﾟﾛﾊﾟﾃｨ
    Private mobjAryMe As TBL_TSTS_EQ_CTRL()                                      '設備状況
    Private mstrUSER_SQL As String                                               'ﾕｰｻﾞｰSQL
    Private mORDER_BY As String                                                  'OrderBy句
    Private mWHERE As String                                                     'Where句
    Private mFEQ_ID As String                                                    '設備ID
    Private mFEQ_KUBUN As Nullable(Of Integer)                                   '設備区分
    Private mFEQ_ID_LOCAL As String                                              'ﾛｰｶﾙ設備ID
    Private mFTRK_BUF_NO As Nullable(Of Integer)                                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    Private mFEQ_NAME As String                                                  '設備名称
    Private mFEQ_STS As String                                                   '設備状態
    Private mFEQ_STOP_CD As String                                               '停止要因ｺｰﾄﾞ
    Private mFEQ_REQ_STS As Nullable(Of Integer)                                 '要求状態
    Private mFEQ_CUT_STS As Nullable(Of Integer)                                 '切離状態
    Private mFEQ_CUT_KUBUN As Nullable(Of Integer)                               '切離可否
    Private mFEQ_PASS_FLAG As Nullable(Of Integer)                               '搬送指示引当追越ﾌﾗｸﾞ
    Private mFUPDATE_DT As Nullable(Of Date)                                     '更新日時
    Private mFENTRY_DT As Nullable(Of Date)                                      '登録日時
    Private mFUSER_ID As String                                                  'ﾕｰｻﾞｰID
    Private mFCOMMENT As String                                                  'ｺﾒﾝﾄ
    Private mFEQ_DSP_KUBUN As Nullable(Of Integer)                               '画面設備状態表示区分
    Private mFEQ_STOP_KUBUN As Nullable(Of Integer)                              '設備停止要因区分
    Private mXEVENT_FLAG As Nullable(Of Integer)                                 'ｲﾍﾞﾝﾄ通知ﾌﾗｸﾞ
    Private mXEVENT_LOG_KUBUN As Nullable(Of Integer)                            'ｲﾍﾞﾝﾄ通知ﾛｸﾞ出力区分
    Private mXEQ_DSP_GROUP_KUBUN As Nullable(Of Integer)                         'ｸﾞﾙｰﾌﾟ設備状態表示区分
    Private mXEQ_RPT_KUBUN01 As Nullable(Of Integer)                             '帳票区分01
    Private mXEQ_ERR_KUBUN As Nullable(Of Integer)                               '設備異常ﾛｸﾞ出力区分
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                  "
    ''' <summary>
    ''' ｼｽﾃﾑ変数 (自ｸﾗｽ型配列)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_TSTS_EQ_CTRL()
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
    ''' 設備区分
    ''' </summary>
    Public Property FEQ_KUBUN() As Nullable(Of Integer)
        Get
            Return mFEQ_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFEQ_KUBUN = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾛｰｶﾙ設備ID
    ''' </summary>
    Public Property FEQ_ID_LOCAL() As String
        Get
            Return mFEQ_ID_LOCAL
        End Get
        Set(ByVal Value As String)
            mFEQ_ID_LOCAL = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    ''' </summary>
    Public Property FTRK_BUF_NO() As Nullable(Of Integer)
        Get
            Return mFTRK_BUF_NO
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFTRK_BUF_NO = Value
        End Set
    End Property
    ''' <summary>
    ''' 設備名称
    ''' </summary>
    Public Property FEQ_NAME() As String
        Get
            Return mFEQ_NAME
        End Get
        Set(ByVal Value As String)
            mFEQ_NAME = Value
        End Set
    End Property
    ''' <summary>
    ''' 設備状態
    ''' </summary>
    Public Property FEQ_STS() As String
        Get
            Return mFEQ_STS
        End Get
        Set(ByVal Value As String)
            mFEQ_STS = Value
        End Set
    End Property
    ''' <summary>
    ''' 停止要因ｺｰﾄﾞ
    ''' </summary>
    Public Property FEQ_STOP_CD() As String
        Get
            Return mFEQ_STOP_CD
        End Get
        Set(ByVal Value As String)
            mFEQ_STOP_CD = Value
        End Set
    End Property
    ''' <summary>
    ''' 要求状態
    ''' </summary>
    Public Property FEQ_REQ_STS() As Nullable(Of Integer)
        Get
            Return mFEQ_REQ_STS
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFEQ_REQ_STS = Value
        End Set
    End Property
    ''' <summary>
    ''' 切離状態
    ''' </summary>
    Public Property FEQ_CUT_STS() As Nullable(Of Integer)
        Get
            Return mFEQ_CUT_STS
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFEQ_CUT_STS = Value
        End Set
    End Property
    ''' <summary>
    ''' 切離可否
    ''' </summary>
    Public Property FEQ_CUT_KUBUN() As Nullable(Of Integer)
        Get
            Return mFEQ_CUT_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFEQ_CUT_KUBUN = Value
        End Set
    End Property
    ''' <summary>
    ''' 搬送指示引当追越ﾌﾗｸﾞ
    ''' </summary>
    Public Property FEQ_PASS_FLAG() As Nullable(Of Integer)
        Get
            Return mFEQ_PASS_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFEQ_PASS_FLAG = Value
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
    ''' 画面設備状態表示区分
    ''' </summary>
    Public Property FEQ_DSP_KUBUN() As Nullable(Of Integer)
        Get
            Return mFEQ_DSP_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFEQ_DSP_KUBUN = Value
        End Set
    End Property
    ''' <summary>
    ''' 設備停止要因区分
    ''' </summary>
    Public Property FEQ_STOP_KUBUN() As Nullable(Of Integer)
        Get
            Return mFEQ_STOP_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFEQ_STOP_KUBUN = Value
        End Set
    End Property
    ''' <summary>
    ''' ｲﾍﾞﾝﾄ通知ﾌﾗｸﾞ
    ''' </summary>
    Public Property XEVENT_FLAG() As Nullable(Of Integer)
        Get
            Return mXEVENT_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXEVENT_FLAG = Value
        End Set
    End Property
    ''' <summary>
    ''' ｲﾍﾞﾝﾄ通知ﾛｸﾞ出力区分
    ''' </summary>
    Public Property XEVENT_LOG_KUBUN() As Nullable(Of Integer)
        Get
            Return mXEVENT_LOG_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXEVENT_LOG_KUBUN = Value
        End Set
    End Property
    ''' <summary>
    ''' ｸﾞﾙｰﾌﾟ設備状態表示区分
    ''' </summary>
    Public Property XEQ_DSP_GROUP_KUBUN() As Nullable(Of Integer)
        Get
            Return mXEQ_DSP_GROUP_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXEQ_DSP_GROUP_KUBUN = Value
        End Set
    End Property
    ''' <summary>
    ''' 帳票区分01
    ''' </summary>
    Public Property XEQ_RPT_KUBUN01() As Nullable(Of Integer)
        Get
            Return mXEQ_RPT_KUBUN01
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXEQ_RPT_KUBUN01 = Value
        End Set
    End Property
    ''' <summary>
    ''' 設備異常ﾛｸﾞ出力区分
    ''' </summary>
    Public Property XEQ_ERR_KUBUN() As Nullable(Of Integer)
        Get
            Return mXEQ_ERR_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXEQ_ERR_KUBUN = Value
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
    Public Function GET_TSTS_EQ_CTRL(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    TSTS_EQ_CTRL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FEQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --設備ID")
        End If
        If IsNull(FEQ_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_KUBUN
            strSQL.Append(vbCrLf & "    AND FEQ_KUBUN = :" & UBound(strBindField) - 1 & " --設備区分")
        End If
        If IsNull(FEQ_ID_LOCAL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID_LOCAL
            strSQL.Append(vbCrLf & "    AND FEQ_ID_LOCAL = :" & UBound(strBindField) - 1 & " --ﾛｰｶﾙ設備ID")
        End If
        If IsNull(FTRK_BUF_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNull(FEQ_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_NAME
            strSQL.Append(vbCrLf & "    AND FEQ_NAME = :" & UBound(strBindField) - 1 & " --設備名称")
        End If
        If IsNull(FEQ_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STS
            strSQL.Append(vbCrLf & "    AND FEQ_STS = :" & UBound(strBindField) - 1 & " --設備状態")
        End If
        If IsNull(FEQ_STOP_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STOP_CD
            strSQL.Append(vbCrLf & "    AND FEQ_STOP_CD = :" & UBound(strBindField) - 1 & " --停止要因ｺｰﾄﾞ")
        End If
        If IsNull(FEQ_REQ_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_REQ_STS
            strSQL.Append(vbCrLf & "    AND FEQ_REQ_STS = :" & UBound(strBindField) - 1 & " --要求状態")
        End If
        If IsNull(FEQ_CUT_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_CUT_STS
            strSQL.Append(vbCrLf & "    AND FEQ_CUT_STS = :" & UBound(strBindField) - 1 & " --切離状態")
        End If
        If IsNull(FEQ_CUT_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_CUT_KUBUN
            strSQL.Append(vbCrLf & "    AND FEQ_CUT_KUBUN = :" & UBound(strBindField) - 1 & " --切離可否")
        End If
        If IsNull(FEQ_PASS_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_PASS_FLAG
            strSQL.Append(vbCrLf & "    AND FEQ_PASS_FLAG = :" & UBound(strBindField) - 1 & " --搬送指示引当追越ﾌﾗｸﾞ")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --更新日時")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --登録日時")
        End If
        If IsNull(FUSER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID
            strSQL.Append(vbCrLf & "    AND FUSER_ID = :" & UBound(strBindField) - 1 & " --ﾕｰｻﾞｰID")
        End If
        If IsNull(FCOMMENT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOMMENT
            strSQL.Append(vbCrLf & "    AND FCOMMENT = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ")
        End If
        If IsNull(FEQ_DSP_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_DSP_KUBUN
            strSQL.Append(vbCrLf & "    AND FEQ_DSP_KUBUN = :" & UBound(strBindField) - 1 & " --画面設備状態表示区分")
        End If
        If IsNull(FEQ_STOP_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STOP_KUBUN
            strSQL.Append(vbCrLf & "    AND FEQ_STOP_KUBUN = :" & UBound(strBindField) - 1 & " --設備停止要因区分")
        End If
        If IsNull(XEVENT_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEVENT_FLAG
            strSQL.Append(vbCrLf & "    AND XEVENT_FLAG = :" & UBound(strBindField) - 1 & " --ｲﾍﾞﾝﾄ通知ﾌﾗｸﾞ")
        End If
        If IsNull(XEVENT_LOG_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEVENT_LOG_KUBUN
            strSQL.Append(vbCrLf & "    AND XEVENT_LOG_KUBUN = :" & UBound(strBindField) - 1 & " --ｲﾍﾞﾝﾄ通知ﾛｸﾞ出力区分")
        End If
        If IsNull(XEQ_DSP_GROUP_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_DSP_GROUP_KUBUN
            strSQL.Append(vbCrLf & "    AND XEQ_DSP_GROUP_KUBUN = :" & UBound(strBindField) - 1 & " --ｸﾞﾙｰﾌﾟ設備状態表示区分")
        End If
        If IsNull(XEQ_RPT_KUBUN01) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_RPT_KUBUN01
            strSQL.Append(vbCrLf & "    AND XEQ_RPT_KUBUN01 = :" & UBound(strBindField) - 1 & " --帳票区分01")
        End If
        If IsNull(XEQ_ERR_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ERR_KUBUN
            strSQL.Append(vbCrLf & "    AND XEQ_ERR_KUBUN = :" & UBound(strBindField) - 1 & " --設備異常ﾛｸﾞ出力区分")
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
        strDataSetName = "TSTS_EQ_CTRL"
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
    Public Function GET_TSTS_EQ_CTRL_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    TSTS_EQ_CTRL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FEQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --設備ID")
        End If
        If IsNull(FEQ_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_KUBUN
            strSQL.Append(vbCrLf & "    AND FEQ_KUBUN = :" & UBound(strBindField) - 1 & " --設備区分")
        End If
        If IsNull(FEQ_ID_LOCAL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID_LOCAL
            strSQL.Append(vbCrLf & "    AND FEQ_ID_LOCAL = :" & UBound(strBindField) - 1 & " --ﾛｰｶﾙ設備ID")
        End If
        If IsNull(FTRK_BUF_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNull(FEQ_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_NAME
            strSQL.Append(vbCrLf & "    AND FEQ_NAME = :" & UBound(strBindField) - 1 & " --設備名称")
        End If
        If IsNull(FEQ_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STS
            strSQL.Append(vbCrLf & "    AND FEQ_STS = :" & UBound(strBindField) - 1 & " --設備状態")
        End If
        If IsNull(FEQ_STOP_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STOP_CD
            strSQL.Append(vbCrLf & "    AND FEQ_STOP_CD = :" & UBound(strBindField) - 1 & " --停止要因ｺｰﾄﾞ")
        End If
        If IsNull(FEQ_REQ_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_REQ_STS
            strSQL.Append(vbCrLf & "    AND FEQ_REQ_STS = :" & UBound(strBindField) - 1 & " --要求状態")
        End If
        If IsNull(FEQ_CUT_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_CUT_STS
            strSQL.Append(vbCrLf & "    AND FEQ_CUT_STS = :" & UBound(strBindField) - 1 & " --切離状態")
        End If
        If IsNull(FEQ_CUT_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_CUT_KUBUN
            strSQL.Append(vbCrLf & "    AND FEQ_CUT_KUBUN = :" & UBound(strBindField) - 1 & " --切離可否")
        End If
        If IsNull(FEQ_PASS_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_PASS_FLAG
            strSQL.Append(vbCrLf & "    AND FEQ_PASS_FLAG = :" & UBound(strBindField) - 1 & " --搬送指示引当追越ﾌﾗｸﾞ")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --更新日時")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --登録日時")
        End If
        If IsNull(FUSER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID
            strSQL.Append(vbCrLf & "    AND FUSER_ID = :" & UBound(strBindField) - 1 & " --ﾕｰｻﾞｰID")
        End If
        If IsNull(FCOMMENT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOMMENT
            strSQL.Append(vbCrLf & "    AND FCOMMENT = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ")
        End If
        If IsNull(FEQ_DSP_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_DSP_KUBUN
            strSQL.Append(vbCrLf & "    AND FEQ_DSP_KUBUN = :" & UBound(strBindField) - 1 & " --画面設備状態表示区分")
        End If
        If IsNull(FEQ_STOP_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STOP_KUBUN
            strSQL.Append(vbCrLf & "    AND FEQ_STOP_KUBUN = :" & UBound(strBindField) - 1 & " --設備停止要因区分")
        End If
        If IsNull(XEVENT_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEVENT_FLAG
            strSQL.Append(vbCrLf & "    AND XEVENT_FLAG = :" & UBound(strBindField) - 1 & " --ｲﾍﾞﾝﾄ通知ﾌﾗｸﾞ")
        End If
        If IsNull(XEVENT_LOG_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEVENT_LOG_KUBUN
            strSQL.Append(vbCrLf & "    AND XEVENT_LOG_KUBUN = :" & UBound(strBindField) - 1 & " --ｲﾍﾞﾝﾄ通知ﾛｸﾞ出力区分")
        End If
        If IsNull(XEQ_DSP_GROUP_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_DSP_GROUP_KUBUN
            strSQL.Append(vbCrLf & "    AND XEQ_DSP_GROUP_KUBUN = :" & UBound(strBindField) - 1 & " --ｸﾞﾙｰﾌﾟ設備状態表示区分")
        End If
        If IsNull(XEQ_RPT_KUBUN01) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_RPT_KUBUN01
            strSQL.Append(vbCrLf & "    AND XEQ_RPT_KUBUN01 = :" & UBound(strBindField) - 1 & " --帳票区分01")
        End If
        If IsNull(XEQ_ERR_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ERR_KUBUN
            strSQL.Append(vbCrLf & "    AND XEQ_ERR_KUBUN = :" & UBound(strBindField) - 1 & " --設備異常ﾛｸﾞ出力区分")
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
        strDataSetName = "TSTS_EQ_CTRL"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TSTS_EQ_CTRL(Owner, objDb, objDbLog)
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
    Public Function GET_TSTS_EQ_CTRL_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "TSTS_EQ_CTRL"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TSTS_EQ_CTRL(Owner, objDb, objDbLog)
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
    Public Function GET_TSTS_EQ_CTRL_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    TSTS_EQ_CTRL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FEQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --設備ID")
        End If
        If IsNull(FEQ_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_KUBUN
            strSQL.Append(vbCrLf & "    AND FEQ_KUBUN = :" & UBound(strBindField) - 1 & " --設備区分")
        End If
        If IsNull(FEQ_ID_LOCAL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID_LOCAL
            strSQL.Append(vbCrLf & "    AND FEQ_ID_LOCAL = :" & UBound(strBindField) - 1 & " --ﾛｰｶﾙ設備ID")
        End If
        If IsNull(FTRK_BUF_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNull(FEQ_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_NAME
            strSQL.Append(vbCrLf & "    AND FEQ_NAME = :" & UBound(strBindField) - 1 & " --設備名称")
        End If
        If IsNull(FEQ_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STS
            strSQL.Append(vbCrLf & "    AND FEQ_STS = :" & UBound(strBindField) - 1 & " --設備状態")
        End If
        If IsNull(FEQ_STOP_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STOP_CD
            strSQL.Append(vbCrLf & "    AND FEQ_STOP_CD = :" & UBound(strBindField) - 1 & " --停止要因ｺｰﾄﾞ")
        End If
        If IsNull(FEQ_REQ_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_REQ_STS
            strSQL.Append(vbCrLf & "    AND FEQ_REQ_STS = :" & UBound(strBindField) - 1 & " --要求状態")
        End If
        If IsNull(FEQ_CUT_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_CUT_STS
            strSQL.Append(vbCrLf & "    AND FEQ_CUT_STS = :" & UBound(strBindField) - 1 & " --切離状態")
        End If
        If IsNull(FEQ_CUT_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_CUT_KUBUN
            strSQL.Append(vbCrLf & "    AND FEQ_CUT_KUBUN = :" & UBound(strBindField) - 1 & " --切離可否")
        End If
        If IsNull(FEQ_PASS_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_PASS_FLAG
            strSQL.Append(vbCrLf & "    AND FEQ_PASS_FLAG = :" & UBound(strBindField) - 1 & " --搬送指示引当追越ﾌﾗｸﾞ")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --更新日時")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --登録日時")
        End If
        If IsNull(FUSER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID
            strSQL.Append(vbCrLf & "    AND FUSER_ID = :" & UBound(strBindField) - 1 & " --ﾕｰｻﾞｰID")
        End If
        If IsNull(FCOMMENT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOMMENT
            strSQL.Append(vbCrLf & "    AND FCOMMENT = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ")
        End If
        If IsNull(FEQ_DSP_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_DSP_KUBUN
            strSQL.Append(vbCrLf & "    AND FEQ_DSP_KUBUN = :" & UBound(strBindField) - 1 & " --画面設備状態表示区分")
        End If
        If IsNull(FEQ_STOP_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STOP_KUBUN
            strSQL.Append(vbCrLf & "    AND FEQ_STOP_KUBUN = :" & UBound(strBindField) - 1 & " --設備停止要因区分")
        End If
        If IsNull(XEVENT_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEVENT_FLAG
            strSQL.Append(vbCrLf & "    AND XEVENT_FLAG = :" & UBound(strBindField) - 1 & " --ｲﾍﾞﾝﾄ通知ﾌﾗｸﾞ")
        End If
        If IsNull(XEVENT_LOG_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEVENT_LOG_KUBUN
            strSQL.Append(vbCrLf & "    AND XEVENT_LOG_KUBUN = :" & UBound(strBindField) - 1 & " --ｲﾍﾞﾝﾄ通知ﾛｸﾞ出力区分")
        End If
        If IsNull(XEQ_DSP_GROUP_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_DSP_GROUP_KUBUN
            strSQL.Append(vbCrLf & "    AND XEQ_DSP_GROUP_KUBUN = :" & UBound(strBindField) - 1 & " --ｸﾞﾙｰﾌﾟ設備状態表示区分")
        End If
        If IsNull(XEQ_RPT_KUBUN01) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_RPT_KUBUN01
            strSQL.Append(vbCrLf & "    AND XEQ_RPT_KUBUN01 = :" & UBound(strBindField) - 1 & " --帳票区分01")
        End If
        If IsNull(XEQ_ERR_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ERR_KUBUN
            strSQL.Append(vbCrLf & "    AND XEQ_ERR_KUBUN = :" & UBound(strBindField) - 1 & " --設備異常ﾛｸﾞ出力区分")
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
        strDataSetName = "TSTS_EQ_CTRL"
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
    Public Sub UPDATE_TSTS_EQ_CTRL()
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
        ElseIf IsNull(mFEQ_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[設備ID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFEQ_KUBUN) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[設備区分]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFEQ_NAME) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[設備名称]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFEQ_STS) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[設備状態]"
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
        strSQL.Append(vbCrLf & "    TSTS_EQ_CTRL")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
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
        If IsNull(mFEQ_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_KUBUN = NULL --設備区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_KUBUN = NULL --設備区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_KUBUN = :" & Ubound(strBindField) - 1 & " --設備区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_KUBUN = :" & Ubound(strBindField) - 1 & " --設備区分")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_ID_LOCAL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_ID_LOCAL = NULL --ﾛｰｶﾙ設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_ID_LOCAL = NULL --ﾛｰｶﾙ設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID_LOCAL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_ID_LOCAL = :" & Ubound(strBindField) - 1 & " --ﾛｰｶﾙ設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_ID_LOCAL = :" & Ubound(strBindField) - 1 & " --ﾛｰｶﾙ設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mFTRK_BUF_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTRK_BUF_NO = NULL --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTRK_BUF_NO = NULL --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTRK_BUF_NO = :" & Ubound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTRK_BUF_NO = :" & Ubound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_NAME = NULL --設備名称")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_NAME = NULL --設備名称")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_NAME = :" & Ubound(strBindField) - 1 & " --設備名称")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_NAME = :" & Ubound(strBindField) - 1 & " --設備名称")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_STS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_STS = NULL --設備状態")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_STS = NULL --設備状態")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_STS = :" & Ubound(strBindField) - 1 & " --設備状態")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_STS = :" & Ubound(strBindField) - 1 & " --設備状態")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_STOP_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_STOP_CD = NULL --停止要因ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_STOP_CD = NULL --停止要因ｺｰﾄﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STOP_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_STOP_CD = :" & Ubound(strBindField) - 1 & " --停止要因ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_STOP_CD = :" & Ubound(strBindField) - 1 & " --停止要因ｺｰﾄﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_REQ_STS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_REQ_STS = NULL --要求状態")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_REQ_STS = NULL --要求状態")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_REQ_STS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_REQ_STS = :" & Ubound(strBindField) - 1 & " --要求状態")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_REQ_STS = :" & Ubound(strBindField) - 1 & " --要求状態")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_CUT_STS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_CUT_STS = NULL --切離状態")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_CUT_STS = NULL --切離状態")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_CUT_STS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_CUT_STS = :" & Ubound(strBindField) - 1 & " --切離状態")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_CUT_STS = :" & Ubound(strBindField) - 1 & " --切離状態")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_CUT_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_CUT_KUBUN = NULL --切離可否")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_CUT_KUBUN = NULL --切離可否")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_CUT_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_CUT_KUBUN = :" & Ubound(strBindField) - 1 & " --切離可否")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_CUT_KUBUN = :" & Ubound(strBindField) - 1 & " --切離可否")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_PASS_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_PASS_FLAG = NULL --搬送指示引当追越ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_PASS_FLAG = NULL --搬送指示引当追越ﾌﾗｸﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_PASS_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_PASS_FLAG = :" & Ubound(strBindField) - 1 & " --搬送指示引当追越ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_PASS_FLAG = :" & Ubound(strBindField) - 1 & " --搬送指示引当追越ﾌﾗｸﾞ")
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
        If IsNull(mFEQ_DSP_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_DSP_KUBUN = NULL --画面設備状態表示区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_DSP_KUBUN = NULL --画面設備状態表示区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_DSP_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_DSP_KUBUN = :" & Ubound(strBindField) - 1 & " --画面設備状態表示区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_DSP_KUBUN = :" & Ubound(strBindField) - 1 & " --画面設備状態表示区分")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_STOP_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_STOP_KUBUN = NULL --設備停止要因区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_STOP_KUBUN = NULL --設備停止要因区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STOP_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_STOP_KUBUN = :" & Ubound(strBindField) - 1 & " --設備停止要因区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_STOP_KUBUN = :" & Ubound(strBindField) - 1 & " --設備停止要因区分")
        End If
        intCount = intCount + 1
        If IsNull(mXEVENT_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEVENT_FLAG = NULL --ｲﾍﾞﾝﾄ通知ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEVENT_FLAG = NULL --ｲﾍﾞﾝﾄ通知ﾌﾗｸﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEVENT_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEVENT_FLAG = :" & Ubound(strBindField) - 1 & " --ｲﾍﾞﾝﾄ通知ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEVENT_FLAG = :" & Ubound(strBindField) - 1 & " --ｲﾍﾞﾝﾄ通知ﾌﾗｸﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mXEVENT_LOG_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEVENT_LOG_KUBUN = NULL --ｲﾍﾞﾝﾄ通知ﾛｸﾞ出力区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEVENT_LOG_KUBUN = NULL --ｲﾍﾞﾝﾄ通知ﾛｸﾞ出力区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEVENT_LOG_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEVENT_LOG_KUBUN = :" & Ubound(strBindField) - 1 & " --ｲﾍﾞﾝﾄ通知ﾛｸﾞ出力区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEVENT_LOG_KUBUN = :" & Ubound(strBindField) - 1 & " --ｲﾍﾞﾝﾄ通知ﾛｸﾞ出力区分")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_DSP_GROUP_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_DSP_GROUP_KUBUN = NULL --ｸﾞﾙｰﾌﾟ設備状態表示区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_DSP_GROUP_KUBUN = NULL --ｸﾞﾙｰﾌﾟ設備状態表示区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_DSP_GROUP_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_DSP_GROUP_KUBUN = :" & Ubound(strBindField) - 1 & " --ｸﾞﾙｰﾌﾟ設備状態表示区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_DSP_GROUP_KUBUN = :" & Ubound(strBindField) - 1 & " --ｸﾞﾙｰﾌﾟ設備状態表示区分")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_RPT_KUBUN01) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_RPT_KUBUN01 = NULL --帳票区分01")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_RPT_KUBUN01 = NULL --帳票区分01")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_RPT_KUBUN01
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_RPT_KUBUN01 = :" & Ubound(strBindField) - 1 & " --帳票区分01")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_RPT_KUBUN01 = :" & Ubound(strBindField) - 1 & " --帳票区分01")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ERR_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ERR_KUBUN = NULL --設備異常ﾛｸﾞ出力区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ERR_KUBUN = NULL --設備異常ﾛｸﾞ出力区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ERR_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ERR_KUBUN = :" & Ubound(strBindField) - 1 & " --設備異常ﾛｸﾞ出力区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ERR_KUBUN = :" & Ubound(strBindField) - 1 & " --設備異常ﾛｸﾞ出力区分")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
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
    Public Sub ADD_TSTS_EQ_CTRL()
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
        ElseIf IsNull(mFEQ_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[設備ID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFEQ_KUBUN) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[設備区分]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFEQ_NAME) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[設備名称]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFEQ_STS) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[設備状態]"
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
        strSQL.Append(vbCrLf & "    TSTS_EQ_CTRL")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
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
        If IsNull(mFEQ_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --設備区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --設備区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --設備区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --設備区分")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_ID_LOCAL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾛｰｶﾙ設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾛｰｶﾙ設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID_LOCAL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾛｰｶﾙ設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾛｰｶﾙ設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mFTRK_BUF_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --設備名称")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --設備名称")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --設備名称")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --設備名称")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_STS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --設備状態")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --設備状態")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --設備状態")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --設備状態")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_STOP_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --停止要因ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --停止要因ｺｰﾄﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STOP_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --停止要因ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --停止要因ｺｰﾄﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_REQ_STS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --要求状態")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --要求状態")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_REQ_STS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --要求状態")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --要求状態")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_CUT_STS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --切離状態")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --切離状態")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_CUT_STS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --切離状態")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --切離状態")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_CUT_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --切離可否")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --切離可否")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_CUT_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --切離可否")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --切離可否")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_PASS_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --搬送指示引当追越ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --搬送指示引当追越ﾌﾗｸﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_PASS_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --搬送指示引当追越ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --搬送指示引当追越ﾌﾗｸﾞ")
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
        If IsNull(mFEQ_DSP_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --画面設備状態表示区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --画面設備状態表示区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_DSP_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --画面設備状態表示区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --画面設備状態表示区分")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_STOP_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --設備停止要因区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --設備停止要因区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STOP_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --設備停止要因区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --設備停止要因区分")
        End If
        intCount = intCount + 1
        If IsNull(mXEVENT_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｲﾍﾞﾝﾄ通知ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｲﾍﾞﾝﾄ通知ﾌﾗｸﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEVENT_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｲﾍﾞﾝﾄ通知ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｲﾍﾞﾝﾄ通知ﾌﾗｸﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mXEVENT_LOG_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｲﾍﾞﾝﾄ通知ﾛｸﾞ出力区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｲﾍﾞﾝﾄ通知ﾛｸﾞ出力区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEVENT_LOG_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｲﾍﾞﾝﾄ通知ﾛｸﾞ出力区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｲﾍﾞﾝﾄ通知ﾛｸﾞ出力区分")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_DSP_GROUP_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｸﾞﾙｰﾌﾟ設備状態表示区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｸﾞﾙｰﾌﾟ設備状態表示区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_DSP_GROUP_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｸﾞﾙｰﾌﾟ設備状態表示区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｸﾞﾙｰﾌﾟ設備状態表示区分")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_RPT_KUBUN01) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --帳票区分01")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --帳票区分01")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_RPT_KUBUN01
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --帳票区分01")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --帳票区分01")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ERR_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --設備異常ﾛｸﾞ出力区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --設備異常ﾛｸﾞ出力区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ERR_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --設備異常ﾛｸﾞ出力区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --設備異常ﾛｸﾞ出力区分")
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
    Public Sub DELETE_TSTS_EQ_CTRL()
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
        strSQL.Append(vbCrLf & "    TSTS_EQ_CTRL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
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
    Public Sub DELETE_TSTS_EQ_CTRL_ANY()
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
        strSQL.Append(vbCrLf & "    TSTS_EQ_CTRL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(FEQ_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --設備ID")
        End If
        If IsNotNull(FEQ_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_KUBUN
            strSQL.Append(vbCrLf & "    AND FEQ_KUBUN = :" & UBound(strBindField) - 1 & " --設備区分")
        End If
        If IsNotNull(FEQ_ID_LOCAL) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID_LOCAL
            strSQL.Append(vbCrLf & "    AND FEQ_ID_LOCAL = :" & UBound(strBindField) - 1 & " --ﾛｰｶﾙ設備ID")
        End If
        If IsNotNull(FTRK_BUF_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNotNull(FEQ_NAME) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_NAME
            strSQL.Append(vbCrLf & "    AND FEQ_NAME = :" & UBound(strBindField) - 1 & " --設備名称")
        End If
        If IsNotNull(FEQ_STS) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STS
            strSQL.Append(vbCrLf & "    AND FEQ_STS = :" & UBound(strBindField) - 1 & " --設備状態")
        End If
        If IsNotNull(FEQ_STOP_CD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STOP_CD
            strSQL.Append(vbCrLf & "    AND FEQ_STOP_CD = :" & UBound(strBindField) - 1 & " --停止要因ｺｰﾄﾞ")
        End If
        If IsNotNull(FEQ_REQ_STS) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_REQ_STS
            strSQL.Append(vbCrLf & "    AND FEQ_REQ_STS = :" & UBound(strBindField) - 1 & " --要求状態")
        End If
        If IsNotNull(FEQ_CUT_STS) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_CUT_STS
            strSQL.Append(vbCrLf & "    AND FEQ_CUT_STS = :" & UBound(strBindField) - 1 & " --切離状態")
        End If
        If IsNotNull(FEQ_CUT_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_CUT_KUBUN
            strSQL.Append(vbCrLf & "    AND FEQ_CUT_KUBUN = :" & UBound(strBindField) - 1 & " --切離可否")
        End If
        If IsNotNull(FEQ_PASS_FLAG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_PASS_FLAG
            strSQL.Append(vbCrLf & "    AND FEQ_PASS_FLAG = :" & UBound(strBindField) - 1 & " --搬送指示引当追越ﾌﾗｸﾞ")
        End If
        If IsNotNull(FUPDATE_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --更新日時")
        End If
        If IsNotNull(FENTRY_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --登録日時")
        End If
        If IsNotNull(FUSER_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID
            strSQL.Append(vbCrLf & "    AND FUSER_ID = :" & UBound(strBindField) - 1 & " --ﾕｰｻﾞｰID")
        End If
        If IsNotNull(FCOMMENT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFCOMMENT
            strSQL.Append(vbCrLf & "    AND FCOMMENT = :" & UBound(strBindField) - 1 & " --ｺﾒﾝﾄ")
        End If
        If IsNotNull(FEQ_DSP_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_DSP_KUBUN
            strSQL.Append(vbCrLf & "    AND FEQ_DSP_KUBUN = :" & UBound(strBindField) - 1 & " --画面設備状態表示区分")
        End If
        If IsNotNull(FEQ_STOP_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_STOP_KUBUN
            strSQL.Append(vbCrLf & "    AND FEQ_STOP_KUBUN = :" & UBound(strBindField) - 1 & " --設備停止要因区分")
        End If
        If IsNotNull(XEVENT_FLAG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEVENT_FLAG
            strSQL.Append(vbCrLf & "    AND XEVENT_FLAG = :" & UBound(strBindField) - 1 & " --ｲﾍﾞﾝﾄ通知ﾌﾗｸﾞ")
        End If
        If IsNotNull(XEVENT_LOG_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEVENT_LOG_KUBUN
            strSQL.Append(vbCrLf & "    AND XEVENT_LOG_KUBUN = :" & UBound(strBindField) - 1 & " --ｲﾍﾞﾝﾄ通知ﾛｸﾞ出力区分")
        End If
        If IsNotNull(XEQ_DSP_GROUP_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_DSP_GROUP_KUBUN
            strSQL.Append(vbCrLf & "    AND XEQ_DSP_GROUP_KUBUN = :" & UBound(strBindField) - 1 & " --ｸﾞﾙｰﾌﾟ設備状態表示区分")
        End If
        If IsNotNull(XEQ_RPT_KUBUN01) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_RPT_KUBUN01
            strSQL.Append(vbCrLf & "    AND XEQ_RPT_KUBUN01 = :" & UBound(strBindField) - 1 & " --帳票区分01")
        End If
        If IsNotNull(XEQ_ERR_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ERR_KUBUN
            strSQL.Append(vbCrLf & "    AND XEQ_ERR_KUBUN = :" & UBound(strBindField) - 1 & " --設備異常ﾛｸﾞ出力区分")
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
        If IsNothing(objType.GetProperty("FEQ_ID")) = False Then mFEQ_ID = objObject.FEQ_ID '設備ID
        If IsNothing(objType.GetProperty("FEQ_KUBUN")) = False Then mFEQ_KUBUN = objObject.FEQ_KUBUN '設備区分
        If IsNothing(objType.GetProperty("FEQ_ID_LOCAL")) = False Then mFEQ_ID_LOCAL = objObject.FEQ_ID_LOCAL 'ﾛｰｶﾙ設備ID
        If IsNothing(objType.GetProperty("FTRK_BUF_NO")) = False Then mFTRK_BUF_NO = objObject.FTRK_BUF_NO 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        If IsNothing(objType.GetProperty("FEQ_NAME")) = False Then mFEQ_NAME = objObject.FEQ_NAME '設備名称
        If IsNothing(objType.GetProperty("FEQ_STS")) = False Then mFEQ_STS = objObject.FEQ_STS '設備状態
        If IsNothing(objType.GetProperty("FEQ_STOP_CD")) = False Then mFEQ_STOP_CD = objObject.FEQ_STOP_CD '停止要因ｺｰﾄﾞ
        If IsNothing(objType.GetProperty("FEQ_REQ_STS")) = False Then mFEQ_REQ_STS = objObject.FEQ_REQ_STS '要求状態
        If IsNothing(objType.GetProperty("FEQ_CUT_STS")) = False Then mFEQ_CUT_STS = objObject.FEQ_CUT_STS '切離状態
        If IsNothing(objType.GetProperty("FEQ_CUT_KUBUN")) = False Then mFEQ_CUT_KUBUN = objObject.FEQ_CUT_KUBUN '切離可否
        If IsNothing(objType.GetProperty("FEQ_PASS_FLAG")) = False Then mFEQ_PASS_FLAG = objObject.FEQ_PASS_FLAG '搬送指示引当追越ﾌﾗｸﾞ
        If IsNothing(objType.GetProperty("FUPDATE_DT")) = False Then mFUPDATE_DT = objObject.FUPDATE_DT '更新日時
        If IsNothing(objType.GetProperty("FENTRY_DT")) = False Then mFENTRY_DT = objObject.FENTRY_DT '登録日時
        If IsNothing(objType.GetProperty("FUSER_ID")) = False Then mFUSER_ID = objObject.FUSER_ID 'ﾕｰｻﾞｰID
        If IsNothing(objType.GetProperty("FCOMMENT")) = False Then mFCOMMENT = objObject.FCOMMENT 'ｺﾒﾝﾄ
        If IsNothing(objType.GetProperty("FEQ_DSP_KUBUN")) = False Then mFEQ_DSP_KUBUN = objObject.FEQ_DSP_KUBUN '画面設備状態表示区分
        If IsNothing(objType.GetProperty("FEQ_STOP_KUBUN")) = False Then mFEQ_STOP_KUBUN = objObject.FEQ_STOP_KUBUN '設備停止要因区分
        If IsNothing(objType.GetProperty("XEVENT_FLAG")) = False Then mXEVENT_FLAG = objObject.XEVENT_FLAG 'ｲﾍﾞﾝﾄ通知ﾌﾗｸﾞ
        If IsNothing(objType.GetProperty("XEVENT_LOG_KUBUN")) = False Then mXEVENT_LOG_KUBUN = objObject.XEVENT_LOG_KUBUN 'ｲﾍﾞﾝﾄ通知ﾛｸﾞ出力区分
        If IsNothing(objType.GetProperty("XEQ_DSP_GROUP_KUBUN")) = False Then mXEQ_DSP_GROUP_KUBUN = objObject.XEQ_DSP_GROUP_KUBUN 'ｸﾞﾙｰﾌﾟ設備状態表示区分
        If IsNothing(objType.GetProperty("XEQ_RPT_KUBUN01")) = False Then mXEQ_RPT_KUBUN01 = objObject.XEQ_RPT_KUBUN01 '帳票区分01
        If IsNothing(objType.GetProperty("XEQ_ERR_KUBUN")) = False Then mXEQ_ERR_KUBUN = objObject.XEQ_ERR_KUBUN '設備異常ﾛｸﾞ出力区分

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
        mFEQ_ID = Nothing
        mFEQ_KUBUN = Nothing
        mFEQ_ID_LOCAL = Nothing
        mFTRK_BUF_NO = Nothing
        mFEQ_NAME = Nothing
        mFEQ_STS = Nothing
        mFEQ_STOP_CD = Nothing
        mFEQ_REQ_STS = Nothing
        mFEQ_CUT_STS = Nothing
        mFEQ_CUT_KUBUN = Nothing
        mFEQ_PASS_FLAG = Nothing
        mFUPDATE_DT = Nothing
        mFENTRY_DT = Nothing
        mFUSER_ID = Nothing
        mFCOMMENT = Nothing
        mFEQ_DSP_KUBUN = Nothing
        mFEQ_STOP_KUBUN = Nothing
        mXEVENT_FLAG = Nothing
        mXEVENT_LOG_KUBUN = Nothing
        mXEQ_DSP_GROUP_KUBUN = Nothing
        mXEQ_RPT_KUBUN01 = Nothing
        mXEQ_ERR_KUBUN = Nothing


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
        mFEQ_ID = TO_STRING_NULLABLE(objRow("FEQ_ID"))
        mFEQ_KUBUN = TO_INTEGER_NULLABLE(objRow("FEQ_KUBUN"))
        mFEQ_ID_LOCAL = TO_STRING_NULLABLE(objRow("FEQ_ID_LOCAL"))
        mFTRK_BUF_NO = TO_INTEGER_NULLABLE(objRow("FTRK_BUF_NO"))
        mFEQ_NAME = TO_STRING_NULLABLE(objRow("FEQ_NAME"))
        mFEQ_STS = TO_STRING_NULLABLE(objRow("FEQ_STS"))
        mFEQ_STOP_CD = TO_STRING_NULLABLE(objRow("FEQ_STOP_CD"))
        mFEQ_REQ_STS = TO_INTEGER_NULLABLE(objRow("FEQ_REQ_STS"))
        mFEQ_CUT_STS = TO_INTEGER_NULLABLE(objRow("FEQ_CUT_STS"))
        mFEQ_CUT_KUBUN = TO_INTEGER_NULLABLE(objRow("FEQ_CUT_KUBUN"))
        mFEQ_PASS_FLAG = TO_INTEGER_NULLABLE(objRow("FEQ_PASS_FLAG"))
        mFUPDATE_DT = TO_DATE_NULLABLE(objRow("FUPDATE_DT"))
        mFENTRY_DT = TO_DATE_NULLABLE(objRow("FENTRY_DT"))
        mFUSER_ID = TO_STRING_NULLABLE(objRow("FUSER_ID"))
        mFCOMMENT = TO_STRING_NULLABLE(objRow("FCOMMENT"))
        mFEQ_DSP_KUBUN = TO_INTEGER_NULLABLE(objRow("FEQ_DSP_KUBUN"))
        mFEQ_STOP_KUBUN = TO_INTEGER_NULLABLE(objRow("FEQ_STOP_KUBUN"))
        mXEVENT_FLAG = TO_INTEGER_NULLABLE(objRow("XEVENT_FLAG"))
        mXEVENT_LOG_KUBUN = TO_INTEGER_NULLABLE(objRow("XEVENT_LOG_KUBUN"))
        mXEQ_DSP_GROUP_KUBUN = TO_INTEGER_NULLABLE(objRow("XEQ_DSP_GROUP_KUBUN"))
        mXEQ_RPT_KUBUN01 = TO_INTEGER_NULLABLE(objRow("XEQ_RPT_KUBUN01"))
        mXEQ_ERR_KUBUN = TO_INTEGER_NULLABLE(objRow("XEQ_ERR_KUBUN"))


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
        strMsg &= "[ﾃｰﾌﾞﾙ名:設備状況]"
        If IsNotNull(FEQ_ID) Then
            strMsg &= "[設備ID:" & FEQ_ID & "]"
        End If
        If IsNotNull(FEQ_KUBUN) Then
            strMsg &= "[設備区分:" & FEQ_KUBUN & "]"
        End If
        If IsNotNull(FEQ_ID_LOCAL) Then
            strMsg &= "[ﾛｰｶﾙ設備ID:" & FEQ_ID_LOCAL & "]"
        End If
        If IsNotNull(FTRK_BUF_NO) Then
            strMsg &= "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & FTRK_BUF_NO & "]"
        End If
        If IsNotNull(FEQ_NAME) Then
            strMsg &= "[設備名称:" & FEQ_NAME & "]"
        End If
        If IsNotNull(FEQ_STS) Then
            strMsg &= "[設備状態:" & FEQ_STS & "]"
        End If
        If IsNotNull(FEQ_STOP_CD) Then
            strMsg &= "[停止要因ｺｰﾄﾞ:" & FEQ_STOP_CD & "]"
        End If
        If IsNotNull(FEQ_REQ_STS) Then
            strMsg &= "[要求状態:" & FEQ_REQ_STS & "]"
        End If
        If IsNotNull(FEQ_CUT_STS) Then
            strMsg &= "[切離状態:" & FEQ_CUT_STS & "]"
        End If
        If IsNotNull(FEQ_CUT_KUBUN) Then
            strMsg &= "[切離可否:" & FEQ_CUT_KUBUN & "]"
        End If
        If IsNotNull(FEQ_PASS_FLAG) Then
            strMsg &= "[搬送指示引当追越ﾌﾗｸﾞ:" & FEQ_PASS_FLAG & "]"
        End If
        If IsNotNull(FUPDATE_DT) Then
            strMsg &= "[更新日時:" & FUPDATE_DT & "]"
        End If
        If IsNotNull(FENTRY_DT) Then
            strMsg &= "[登録日時:" & FENTRY_DT & "]"
        End If
        If IsNotNull(FUSER_ID) Then
            strMsg &= "[ﾕｰｻﾞｰID:" & FUSER_ID & "]"
        End If
        If IsNotNull(FCOMMENT) Then
            strMsg &= "[ｺﾒﾝﾄ:" & FCOMMENT & "]"
        End If
        If IsNotNull(FEQ_DSP_KUBUN) Then
            strMsg &= "[画面設備状態表示区分:" & FEQ_DSP_KUBUN & "]"
        End If
        If IsNotNull(FEQ_STOP_KUBUN) Then
            strMsg &= "[設備停止要因区分:" & FEQ_STOP_KUBUN & "]"
        End If
        If IsNotNull(XEVENT_FLAG) Then
            strMsg &= "[ｲﾍﾞﾝﾄ通知ﾌﾗｸﾞ:" & XEVENT_FLAG & "]"
        End If
        If IsNotNull(XEVENT_LOG_KUBUN) Then
            strMsg &= "[ｲﾍﾞﾝﾄ通知ﾛｸﾞ出力区分:" & XEVENT_LOG_KUBUN & "]"
        End If
        If IsNotNull(XEQ_DSP_GROUP_KUBUN) Then
            strMsg &= "[ｸﾞﾙｰﾌﾟ設備状態表示区分:" & XEQ_DSP_GROUP_KUBUN & "]"
        End If
        If IsNotNull(XEQ_RPT_KUBUN01) Then
            strMsg &= "[帳票区分01:" & XEQ_RPT_KUBUN01 & "]"
        End If
        If IsNotNull(XEQ_ERR_KUBUN) Then
            strMsg &= "[設備異常ﾛｸﾞ出力区分:" & XEQ_ERR_KUBUN & "]"
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
