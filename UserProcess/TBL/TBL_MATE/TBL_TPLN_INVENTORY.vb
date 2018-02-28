'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' 【名称】MaterialStreamﾃｰﾌﾞﾙｸﾗｽ
' 【機能】棚卸し作業ﾃｰﾌﾞﾙｸﾗｽ
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
''' 棚卸し作業ﾃｰﾌﾞﾙｸﾗｽ
''' </summary>
Public Class TBL_TPLN_INVENTORY
    Inherits clsTemplateTable

    '**********************************************************************************************
    '↓↓↓自動生成部
#Region "  ｸﾗｽ変数定義                  "
    'ﾌﾟﾛﾊﾟﾃｨ
    Private mobjAryMe As TBL_TPLN_INVENTORY()                                    '棚卸し作業
    Private mstrUSER_SQL As String                                               'ﾕｰｻﾞｰSQL
    Private mORDER_BY As String                                                  'OrderBy句
    Private mWHERE As String                                                     'Where句
    Private mFPLAN_KEY As String                                                 '計画ｷｰ
    Private mFPLACE_CD As Nullable(Of Integer)                                   '保管場所ｺｰﾄﾞ
    Private mFAREA_CD As Nullable(Of Integer)                                    'ｴﾘｱｺｰﾄﾞ
    Private mFHINMEI_CD As String                                                '品目ｺｰﾄﾞ
    Private mFLOT_NO_FM As String                                                'Fmﾛｯﾄ№
    Private mFLOT_NO_TO As String                                                'Toﾛｯﾄ№
    Private mFRAC_RETU_FM As Nullable(Of Integer)                                'Fm列
    Private mFRAC_REN_FM As Nullable(Of Integer)                                 'Fm連
    Private mFRAC_DAN_FM As Nullable(Of Integer)                                 'Fm段
    Private mFRAC_RETU_TO As Nullable(Of Integer)                                'To列
    Private mFRAC_REN_TO As Nullable(Of Integer)                                 'To連
    Private mFRAC_DAN_TO As Nullable(Of Integer)                                 'To段
    Private mFTR_TO As Nullable(Of Integer)                                      '搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    Private mFTERM_ID As String                                                  '端末ID
    Private mFUSER_ID As String                                                  'ﾕｰｻﾞｰID
    Private mFEXEC_DT As Nullable(Of Date)                                       '実行時間
    Private mFPROGRESS_PLNINV As Nullable(Of Integer)                            '進捗状態(棚卸し)
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                  "
    ''' <summary>
    ''' ｼｽﾃﾑ変数 (自ｸﾗｽ型配列)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_TPLN_INVENTORY()
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
    ''' 計画ｷｰ
    ''' </summary>
    Public Property FPLAN_KEY() As String
        Get
            Return mFPLAN_KEY
        End Get
        Set(ByVal Value As String)
            mFPLAN_KEY = Value
        End Set
    End Property
    ''' <summary>
    ''' 保管場所ｺｰﾄﾞ
    ''' </summary>
    Public Property FPLACE_CD() As Nullable(Of Integer)
        Get
            Return mFPLACE_CD
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFPLACE_CD = Value
        End Set
    End Property
    ''' <summary>
    ''' ｴﾘｱｺｰﾄﾞ
    ''' </summary>
    Public Property FAREA_CD() As Nullable(Of Integer)
        Get
            Return mFAREA_CD
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFAREA_CD = Value
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
    ''' Fmﾛｯﾄ№
    ''' </summary>
    Public Property FLOT_NO_FM() As String
        Get
            Return mFLOT_NO_FM
        End Get
        Set(ByVal Value As String)
            mFLOT_NO_FM = Value
        End Set
    End Property
    ''' <summary>
    ''' Toﾛｯﾄ№
    ''' </summary>
    Public Property FLOT_NO_TO() As String
        Get
            Return mFLOT_NO_TO
        End Get
        Set(ByVal Value As String)
            mFLOT_NO_TO = Value
        End Set
    End Property
    ''' <summary>
    ''' Fm列
    ''' </summary>
    Public Property FRAC_RETU_FM() As Nullable(Of Integer)
        Get
            Return mFRAC_RETU_FM
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRAC_RETU_FM = Value
        End Set
    End Property
    ''' <summary>
    ''' Fm連
    ''' </summary>
    Public Property FRAC_REN_FM() As Nullable(Of Integer)
        Get
            Return mFRAC_REN_FM
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRAC_REN_FM = Value
        End Set
    End Property
    ''' <summary>
    ''' Fm段
    ''' </summary>
    Public Property FRAC_DAN_FM() As Nullable(Of Integer)
        Get
            Return mFRAC_DAN_FM
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRAC_DAN_FM = Value
        End Set
    End Property
    ''' <summary>
    ''' To列
    ''' </summary>
    Public Property FRAC_RETU_TO() As Nullable(Of Integer)
        Get
            Return mFRAC_RETU_TO
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRAC_RETU_TO = Value
        End Set
    End Property
    ''' <summary>
    ''' To連
    ''' </summary>
    Public Property FRAC_REN_TO() As Nullable(Of Integer)
        Get
            Return mFRAC_REN_TO
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRAC_REN_TO = Value
        End Set
    End Property
    ''' <summary>
    ''' To段
    ''' </summary>
    Public Property FRAC_DAN_TO() As Nullable(Of Integer)
        Get
            Return mFRAC_DAN_TO
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRAC_DAN_TO = Value
        End Set
    End Property
    ''' <summary>
    ''' 搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    ''' </summary>
    Public Property FTR_TO() As Nullable(Of Integer)
        Get
            Return mFTR_TO
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFTR_TO = Value
        End Set
    End Property
    ''' <summary>
    ''' 端末ID
    ''' </summary>
    Public Property FTERM_ID() As String
        Get
            Return mFTERM_ID
        End Get
        Set(ByVal Value As String)
            mFTERM_ID = Value
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
    ''' 進捗状態(棚卸し)
    ''' </summary>
    Public Property FPROGRESS_PLNINV() As Nullable(Of Integer)
        Get
            Return mFPROGRESS_PLNINV
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFPROGRESS_PLNINV = Value
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
    Public Function GET_TPLN_INVENTORY(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    TPLN_INVENTORY")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FPLAN_KEY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLAN_KEY
            strSQL.Append(vbCrLf & "    AND FPLAN_KEY = :" & UBound(strBindField) - 1 & " --計画ｷｰ")
        End If
        If IsNull(FPLACE_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLACE_CD
            strSQL.Append(vbCrLf & "    AND FPLACE_CD = :" & UBound(strBindField) - 1 & " --保管場所ｺｰﾄﾞ")
        End If
        If IsNull(FAREA_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFAREA_CD
            strSQL.Append(vbCrLf & "    AND FAREA_CD = :" & UBound(strBindField) - 1 & " --ｴﾘｱｺｰﾄﾞ")
        End If
        If IsNull(FHINMEI_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --品目ｺｰﾄﾞ")
        End If
        If IsNull(FLOT_NO_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO_FM
            strSQL.Append(vbCrLf & "    AND FLOT_NO_FM = :" & UBound(strBindField) - 1 & " --Fmﾛｯﾄ№")
        End If
        If IsNull(FLOT_NO_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO_TO
            strSQL.Append(vbCrLf & "    AND FLOT_NO_TO = :" & UBound(strBindField) - 1 & " --Toﾛｯﾄ№")
        End If
        If IsNull(FRAC_RETU_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_RETU_FM
            strSQL.Append(vbCrLf & "    AND FRAC_RETU_FM = :" & UBound(strBindField) - 1 & " --Fm列")
        End If
        If IsNull(FRAC_REN_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_REN_FM
            strSQL.Append(vbCrLf & "    AND FRAC_REN_FM = :" & UBound(strBindField) - 1 & " --Fm連")
        End If
        If IsNull(FRAC_DAN_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_DAN_FM
            strSQL.Append(vbCrLf & "    AND FRAC_DAN_FM = :" & UBound(strBindField) - 1 & " --Fm段")
        End If
        If IsNull(FRAC_RETU_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_RETU_TO
            strSQL.Append(vbCrLf & "    AND FRAC_RETU_TO = :" & UBound(strBindField) - 1 & " --To列")
        End If
        If IsNull(FRAC_REN_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_REN_TO
            strSQL.Append(vbCrLf & "    AND FRAC_REN_TO = :" & UBound(strBindField) - 1 & " --To連")
        End If
        If IsNull(FRAC_DAN_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_DAN_TO
            strSQL.Append(vbCrLf & "    AND FRAC_DAN_TO = :" & UBound(strBindField) - 1 & " --To段")
        End If
        If IsNull(FTR_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_TO
            strSQL.Append(vbCrLf & "    AND FTR_TO = :" & UBound(strBindField) - 1 & " --搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNull(FTERM_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTERM_ID
            strSQL.Append(vbCrLf & "    AND FTERM_ID = :" & UBound(strBindField) - 1 & " --端末ID")
        End If
        If IsNull(FUSER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID
            strSQL.Append(vbCrLf & "    AND FUSER_ID = :" & UBound(strBindField) - 1 & " --ﾕｰｻﾞｰID")
        End If
        If IsNull(FEXEC_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEXEC_DT
            strSQL.Append(vbCrLf & "    AND FEXEC_DT = :" & UBound(strBindField) - 1 & " --実行時間")
        End If
        If IsNull(FPROGRESS_PLNINV) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPROGRESS_PLNINV
            strSQL.Append(vbCrLf & "    AND FPROGRESS_PLNINV = :" & UBound(strBindField) - 1 & " --進捗状態(棚卸し)")
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
        strDataSetName = "TPLN_INVENTORY"
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
    Public Function GET_TPLN_INVENTORY_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    TPLN_INVENTORY")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FPLAN_KEY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLAN_KEY
            strSQL.Append(vbCrLf & "    AND FPLAN_KEY = :" & UBound(strBindField) - 1 & " --計画ｷｰ")
        End If
        If IsNull(FPLACE_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLACE_CD
            strSQL.Append(vbCrLf & "    AND FPLACE_CD = :" & UBound(strBindField) - 1 & " --保管場所ｺｰﾄﾞ")
        End If
        If IsNull(FAREA_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFAREA_CD
            strSQL.Append(vbCrLf & "    AND FAREA_CD = :" & UBound(strBindField) - 1 & " --ｴﾘｱｺｰﾄﾞ")
        End If
        If IsNull(FHINMEI_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --品目ｺｰﾄﾞ")
        End If
        If IsNull(FLOT_NO_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO_FM
            strSQL.Append(vbCrLf & "    AND FLOT_NO_FM = :" & UBound(strBindField) - 1 & " --Fmﾛｯﾄ№")
        End If
        If IsNull(FLOT_NO_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO_TO
            strSQL.Append(vbCrLf & "    AND FLOT_NO_TO = :" & UBound(strBindField) - 1 & " --Toﾛｯﾄ№")
        End If
        If IsNull(FRAC_RETU_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_RETU_FM
            strSQL.Append(vbCrLf & "    AND FRAC_RETU_FM = :" & UBound(strBindField) - 1 & " --Fm列")
        End If
        If IsNull(FRAC_REN_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_REN_FM
            strSQL.Append(vbCrLf & "    AND FRAC_REN_FM = :" & UBound(strBindField) - 1 & " --Fm連")
        End If
        If IsNull(FRAC_DAN_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_DAN_FM
            strSQL.Append(vbCrLf & "    AND FRAC_DAN_FM = :" & UBound(strBindField) - 1 & " --Fm段")
        End If
        If IsNull(FRAC_RETU_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_RETU_TO
            strSQL.Append(vbCrLf & "    AND FRAC_RETU_TO = :" & UBound(strBindField) - 1 & " --To列")
        End If
        If IsNull(FRAC_REN_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_REN_TO
            strSQL.Append(vbCrLf & "    AND FRAC_REN_TO = :" & UBound(strBindField) - 1 & " --To連")
        End If
        If IsNull(FRAC_DAN_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_DAN_TO
            strSQL.Append(vbCrLf & "    AND FRAC_DAN_TO = :" & UBound(strBindField) - 1 & " --To段")
        End If
        If IsNull(FTR_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_TO
            strSQL.Append(vbCrLf & "    AND FTR_TO = :" & UBound(strBindField) - 1 & " --搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNull(FTERM_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTERM_ID
            strSQL.Append(vbCrLf & "    AND FTERM_ID = :" & UBound(strBindField) - 1 & " --端末ID")
        End If
        If IsNull(FUSER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID
            strSQL.Append(vbCrLf & "    AND FUSER_ID = :" & UBound(strBindField) - 1 & " --ﾕｰｻﾞｰID")
        End If
        If IsNull(FEXEC_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEXEC_DT
            strSQL.Append(vbCrLf & "    AND FEXEC_DT = :" & UBound(strBindField) - 1 & " --実行時間")
        End If
        If IsNull(FPROGRESS_PLNINV) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPROGRESS_PLNINV
            strSQL.Append(vbCrLf & "    AND FPROGRESS_PLNINV = :" & UBound(strBindField) - 1 & " --進捗状態(棚卸し)")
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
        strDataSetName = "TPLN_INVENTORY"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TPLN_INVENTORY(Owner, objDb, objDbLog)
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
    Public Function GET_TPLN_INVENTORY_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "TPLN_INVENTORY"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TPLN_INVENTORY(Owner, objDb, objDbLog)
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
    Public Function GET_TPLN_INVENTORY_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    TPLN_INVENTORY")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FPLAN_KEY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLAN_KEY
            strSQL.Append(vbCrLf & "    AND FPLAN_KEY = :" & UBound(strBindField) - 1 & " --計画ｷｰ")
        End If
        If IsNull(FPLACE_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLACE_CD
            strSQL.Append(vbCrLf & "    AND FPLACE_CD = :" & UBound(strBindField) - 1 & " --保管場所ｺｰﾄﾞ")
        End If
        If IsNull(FAREA_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFAREA_CD
            strSQL.Append(vbCrLf & "    AND FAREA_CD = :" & UBound(strBindField) - 1 & " --ｴﾘｱｺｰﾄﾞ")
        End If
        If IsNull(FHINMEI_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --品目ｺｰﾄﾞ")
        End If
        If IsNull(FLOT_NO_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO_FM
            strSQL.Append(vbCrLf & "    AND FLOT_NO_FM = :" & UBound(strBindField) - 1 & " --Fmﾛｯﾄ№")
        End If
        If IsNull(FLOT_NO_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO_TO
            strSQL.Append(vbCrLf & "    AND FLOT_NO_TO = :" & UBound(strBindField) - 1 & " --Toﾛｯﾄ№")
        End If
        If IsNull(FRAC_RETU_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_RETU_FM
            strSQL.Append(vbCrLf & "    AND FRAC_RETU_FM = :" & UBound(strBindField) - 1 & " --Fm列")
        End If
        If IsNull(FRAC_REN_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_REN_FM
            strSQL.Append(vbCrLf & "    AND FRAC_REN_FM = :" & UBound(strBindField) - 1 & " --Fm連")
        End If
        If IsNull(FRAC_DAN_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_DAN_FM
            strSQL.Append(vbCrLf & "    AND FRAC_DAN_FM = :" & UBound(strBindField) - 1 & " --Fm段")
        End If
        If IsNull(FRAC_RETU_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_RETU_TO
            strSQL.Append(vbCrLf & "    AND FRAC_RETU_TO = :" & UBound(strBindField) - 1 & " --To列")
        End If
        If IsNull(FRAC_REN_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_REN_TO
            strSQL.Append(vbCrLf & "    AND FRAC_REN_TO = :" & UBound(strBindField) - 1 & " --To連")
        End If
        If IsNull(FRAC_DAN_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_DAN_TO
            strSQL.Append(vbCrLf & "    AND FRAC_DAN_TO = :" & UBound(strBindField) - 1 & " --To段")
        End If
        If IsNull(FTR_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_TO
            strSQL.Append(vbCrLf & "    AND FTR_TO = :" & UBound(strBindField) - 1 & " --搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNull(FTERM_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTERM_ID
            strSQL.Append(vbCrLf & "    AND FTERM_ID = :" & UBound(strBindField) - 1 & " --端末ID")
        End If
        If IsNull(FUSER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID
            strSQL.Append(vbCrLf & "    AND FUSER_ID = :" & UBound(strBindField) - 1 & " --ﾕｰｻﾞｰID")
        End If
        If IsNull(FEXEC_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEXEC_DT
            strSQL.Append(vbCrLf & "    AND FEXEC_DT = :" & UBound(strBindField) - 1 & " --実行時間")
        End If
        If IsNull(FPROGRESS_PLNINV) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPROGRESS_PLNINV
            strSQL.Append(vbCrLf & "    AND FPROGRESS_PLNINV = :" & UBound(strBindField) - 1 & " --進捗状態(棚卸し)")
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
        strDataSetName = "TPLN_INVENTORY"
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
    Public Sub UPDATE_TPLN_INVENTORY()
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
        ElseIf IsNull(mFPLAN_KEY) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[計画ｷｰ]"
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
        strSQL.Append(vbCrLf & "    TPLN_INVENTORY")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
        If IsNull(mFPLAN_KEY) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FPLAN_KEY = NULL --計画ｷｰ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FPLAN_KEY = NULL --計画ｷｰ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLAN_KEY
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FPLAN_KEY = :" & Ubound(strBindField) - 1 & " --計画ｷｰ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FPLAN_KEY = :" & Ubound(strBindField) - 1 & " --計画ｷｰ")
        End If
        intCount = intCount + 1
        If IsNull(mFPLACE_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FPLACE_CD = NULL --保管場所ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FPLACE_CD = NULL --保管場所ｺｰﾄﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLACE_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FPLACE_CD = :" & Ubound(strBindField) - 1 & " --保管場所ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FPLACE_CD = :" & Ubound(strBindField) - 1 & " --保管場所ｺｰﾄﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFAREA_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FAREA_CD = NULL --ｴﾘｱｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FAREA_CD = NULL --ｴﾘｱｺｰﾄﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFAREA_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FAREA_CD = :" & Ubound(strBindField) - 1 & " --ｴﾘｱｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FAREA_CD = :" & Ubound(strBindField) - 1 & " --ｴﾘｱｺｰﾄﾞ")
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
        If IsNull(mFLOT_NO_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOT_NO_FM = NULL --Fmﾛｯﾄ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOT_NO_FM = NULL --Fmﾛｯﾄ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOT_NO_FM = :" & Ubound(strBindField) - 1 & " --Fmﾛｯﾄ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOT_NO_FM = :" & Ubound(strBindField) - 1 & " --Fmﾛｯﾄ№")
        End If
        intCount = intCount + 1
        If IsNull(mFLOT_NO_TO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOT_NO_TO = NULL --Toﾛｯﾄ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOT_NO_TO = NULL --Toﾛｯﾄ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO_TO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOT_NO_TO = :" & Ubound(strBindField) - 1 & " --Toﾛｯﾄ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOT_NO_TO = :" & Ubound(strBindField) - 1 & " --Toﾛｯﾄ№")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_RETU_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_RETU_FM = NULL --Fm列")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_RETU_FM = NULL --Fm列")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_RETU_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_RETU_FM = :" & Ubound(strBindField) - 1 & " --Fm列")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_RETU_FM = :" & Ubound(strBindField) - 1 & " --Fm列")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_REN_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_REN_FM = NULL --Fm連")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_REN_FM = NULL --Fm連")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_REN_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_REN_FM = :" & Ubound(strBindField) - 1 & " --Fm連")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_REN_FM = :" & Ubound(strBindField) - 1 & " --Fm連")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_DAN_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_DAN_FM = NULL --Fm段")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_DAN_FM = NULL --Fm段")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_DAN_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_DAN_FM = :" & Ubound(strBindField) - 1 & " --Fm段")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_DAN_FM = :" & Ubound(strBindField) - 1 & " --Fm段")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_RETU_TO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_RETU_TO = NULL --To列")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_RETU_TO = NULL --To列")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_RETU_TO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_RETU_TO = :" & Ubound(strBindField) - 1 & " --To列")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_RETU_TO = :" & Ubound(strBindField) - 1 & " --To列")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_REN_TO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_REN_TO = NULL --To連")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_REN_TO = NULL --To連")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_REN_TO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_REN_TO = :" & Ubound(strBindField) - 1 & " --To連")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_REN_TO = :" & Ubound(strBindField) - 1 & " --To連")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_DAN_TO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_DAN_TO = NULL --To段")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_DAN_TO = NULL --To段")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_DAN_TO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_DAN_TO = :" & Ubound(strBindField) - 1 & " --To段")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_DAN_TO = :" & Ubound(strBindField) - 1 & " --To段")
        End If
        intCount = intCount + 1
        If IsNull(mFTR_TO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTR_TO = NULL --搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTR_TO = NULL --搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_TO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTR_TO = :" & Ubound(strBindField) - 1 & " --搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTR_TO = :" & Ubound(strBindField) - 1 & " --搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        intCount = intCount + 1
        If IsNull(mFTERM_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTERM_ID = NULL --端末ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTERM_ID = NULL --端末ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTERM_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTERM_ID = :" & Ubound(strBindField) - 1 & " --端末ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTERM_ID = :" & Ubound(strBindField) - 1 & " --端末ID")
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
        If IsNull(mFPROGRESS_PLNINV) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FPROGRESS_PLNINV = NULL --進捗状態(棚卸し)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FPROGRESS_PLNINV = NULL --進捗状態(棚卸し)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPROGRESS_PLNINV
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FPROGRESS_PLNINV = :" & Ubound(strBindField) - 1 & " --進捗状態(棚卸し)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FPROGRESS_PLNINV = :" & Ubound(strBindField) - 1 & " --進捗状態(棚卸し)")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FPLAN_KEY) = True Then
            strSQL.Append(vbCrLf & "    AND FPLAN_KEY IS NULL --計画ｷｰ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLAN_KEY
            strSQL.Append(vbCrLf & "    AND FPLAN_KEY = :" & UBound(strBindField) - 1 & " --計画ｷｰ")
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
    Public Sub ADD_TPLN_INVENTORY()
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
        ElseIf IsNull(mFPLAN_KEY) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[計画ｷｰ]"
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
        strSQL.Append(vbCrLf & "    TPLN_INVENTORY")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
        If IsNull(mFPLAN_KEY) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --計画ｷｰ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --計画ｷｰ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLAN_KEY
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --計画ｷｰ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --計画ｷｰ")
        End If
        intCount = intCount + 1
        If IsNull(mFPLACE_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --保管場所ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --保管場所ｺｰﾄﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLACE_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --保管場所ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --保管場所ｺｰﾄﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFAREA_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｴﾘｱｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｴﾘｱｺｰﾄﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFAREA_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｴﾘｱｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｴﾘｱｺｰﾄﾞ")
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
        If IsNull(mFLOT_NO_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --Fmﾛｯﾄ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --Fmﾛｯﾄ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --Fmﾛｯﾄ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --Fmﾛｯﾄ№")
        End If
        intCount = intCount + 1
        If IsNull(mFLOT_NO_TO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --Toﾛｯﾄ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --Toﾛｯﾄ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO_TO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --Toﾛｯﾄ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --Toﾛｯﾄ№")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_RETU_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --Fm列")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --Fm列")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_RETU_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --Fm列")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --Fm列")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_REN_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --Fm連")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --Fm連")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_REN_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --Fm連")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --Fm連")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_DAN_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --Fm段")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --Fm段")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_DAN_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --Fm段")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --Fm段")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_RETU_TO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --To列")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --To列")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_RETU_TO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --To列")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --To列")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_REN_TO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --To連")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --To連")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_REN_TO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --To連")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --To連")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_DAN_TO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --To段")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --To段")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_DAN_TO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --To段")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --To段")
        End If
        intCount = intCount + 1
        If IsNull(mFTR_TO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_TO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        intCount = intCount + 1
        If IsNull(mFTERM_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --端末ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --端末ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTERM_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --端末ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --端末ID")
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
        If IsNull(mFPROGRESS_PLNINV) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --進捗状態(棚卸し)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --進捗状態(棚卸し)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPROGRESS_PLNINV
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --進捗状態(棚卸し)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --進捗状態(棚卸し)")
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
    Public Sub DELETE_TPLN_INVENTORY()
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
        ElseIf IsNull(mFPLAN_KEY) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[計画ｷｰ]"
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
        strSQL.Append(vbCrLf & "    TPLN_INVENTORY")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FPLAN_KEY) = True Then
            strSQL.Append(vbCrLf & "    AND FPLAN_KEY IS NULL --計画ｷｰ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLAN_KEY
            strSQL.Append(vbCrLf & "    AND FPLAN_KEY = :" & UBound(strBindField) - 1 & " --計画ｷｰ")
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
    Public Sub DELETE_TPLN_INVENTORY_ANY()
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
        strSQL.Append(vbCrLf & "    TPLN_INVENTORY")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(FPLAN_KEY) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLAN_KEY
            strSQL.Append(vbCrLf & "    AND FPLAN_KEY = :" & UBound(strBindField) - 1 & " --計画ｷｰ")
        End If
        If IsNotNull(FPLACE_CD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPLACE_CD
            strSQL.Append(vbCrLf & "    AND FPLACE_CD = :" & UBound(strBindField) - 1 & " --保管場所ｺｰﾄﾞ")
        End If
        If IsNotNull(FAREA_CD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFAREA_CD
            strSQL.Append(vbCrLf & "    AND FAREA_CD = :" & UBound(strBindField) - 1 & " --ｴﾘｱｺｰﾄﾞ")
        End If
        If IsNotNull(FHINMEI_CD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --品目ｺｰﾄﾞ")
        End If
        If IsNotNull(FLOT_NO_FM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO_FM
            strSQL.Append(vbCrLf & "    AND FLOT_NO_FM = :" & UBound(strBindField) - 1 & " --Fmﾛｯﾄ№")
        End If
        If IsNotNull(FLOT_NO_TO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO_TO
            strSQL.Append(vbCrLf & "    AND FLOT_NO_TO = :" & UBound(strBindField) - 1 & " --Toﾛｯﾄ№")
        End If
        If IsNotNull(FRAC_RETU_FM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_RETU_FM
            strSQL.Append(vbCrLf & "    AND FRAC_RETU_FM = :" & UBound(strBindField) - 1 & " --Fm列")
        End If
        If IsNotNull(FRAC_REN_FM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_REN_FM
            strSQL.Append(vbCrLf & "    AND FRAC_REN_FM = :" & UBound(strBindField) - 1 & " --Fm連")
        End If
        If IsNotNull(FRAC_DAN_FM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_DAN_FM
            strSQL.Append(vbCrLf & "    AND FRAC_DAN_FM = :" & UBound(strBindField) - 1 & " --Fm段")
        End If
        If IsNotNull(FRAC_RETU_TO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_RETU_TO
            strSQL.Append(vbCrLf & "    AND FRAC_RETU_TO = :" & UBound(strBindField) - 1 & " --To列")
        End If
        If IsNotNull(FRAC_REN_TO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_REN_TO
            strSQL.Append(vbCrLf & "    AND FRAC_REN_TO = :" & UBound(strBindField) - 1 & " --To連")
        End If
        If IsNotNull(FRAC_DAN_TO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_DAN_TO
            strSQL.Append(vbCrLf & "    AND FRAC_DAN_TO = :" & UBound(strBindField) - 1 & " --To段")
        End If
        If IsNotNull(FTR_TO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_TO
            strSQL.Append(vbCrLf & "    AND FTR_TO = :" & UBound(strBindField) - 1 & " --搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNotNull(FTERM_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTERM_ID
            strSQL.Append(vbCrLf & "    AND FTERM_ID = :" & UBound(strBindField) - 1 & " --端末ID")
        End If
        If IsNotNull(FUSER_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID
            strSQL.Append(vbCrLf & "    AND FUSER_ID = :" & UBound(strBindField) - 1 & " --ﾕｰｻﾞｰID")
        End If
        If IsNotNull(FEXEC_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEXEC_DT
            strSQL.Append(vbCrLf & "    AND FEXEC_DT = :" & UBound(strBindField) - 1 & " --実行時間")
        End If
        If IsNotNull(FPROGRESS_PLNINV) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPROGRESS_PLNINV
            strSQL.Append(vbCrLf & "    AND FPROGRESS_PLNINV = :" & UBound(strBindField) - 1 & " --進捗状態(棚卸し)")
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
        If IsNothing(objType.GetProperty("FPLAN_KEY")) = False Then mFPLAN_KEY = objObject.FPLAN_KEY '計画ｷｰ
        If IsNothing(objType.GetProperty("FPLACE_CD")) = False Then mFPLACE_CD = objObject.FPLACE_CD '保管場所ｺｰﾄﾞ
        If IsNothing(objType.GetProperty("FAREA_CD")) = False Then mFAREA_CD = objObject.FAREA_CD 'ｴﾘｱｺｰﾄﾞ
        If IsNothing(objType.GetProperty("FHINMEI_CD")) = False Then mFHINMEI_CD = objObject.FHINMEI_CD '品目ｺｰﾄﾞ
        If IsNothing(objType.GetProperty("FLOT_NO_FM")) = False Then mFLOT_NO_FM = objObject.FLOT_NO_FM 'Fmﾛｯﾄ№
        If IsNothing(objType.GetProperty("FLOT_NO_TO")) = False Then mFLOT_NO_TO = objObject.FLOT_NO_TO 'Toﾛｯﾄ№
        If IsNothing(objType.GetProperty("FRAC_RETU_FM")) = False Then mFRAC_RETU_FM = objObject.FRAC_RETU_FM 'Fm列
        If IsNothing(objType.GetProperty("FRAC_REN_FM")) = False Then mFRAC_REN_FM = objObject.FRAC_REN_FM 'Fm連
        If IsNothing(objType.GetProperty("FRAC_DAN_FM")) = False Then mFRAC_DAN_FM = objObject.FRAC_DAN_FM 'Fm段
        If IsNothing(objType.GetProperty("FRAC_RETU_TO")) = False Then mFRAC_RETU_TO = objObject.FRAC_RETU_TO 'To列
        If IsNothing(objType.GetProperty("FRAC_REN_TO")) = False Then mFRAC_REN_TO = objObject.FRAC_REN_TO 'To連
        If IsNothing(objType.GetProperty("FRAC_DAN_TO")) = False Then mFRAC_DAN_TO = objObject.FRAC_DAN_TO 'To段
        If IsNothing(objType.GetProperty("FTR_TO")) = False Then mFTR_TO = objObject.FTR_TO '搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        If IsNothing(objType.GetProperty("FTERM_ID")) = False Then mFTERM_ID = objObject.FTERM_ID '端末ID
        If IsNothing(objType.GetProperty("FUSER_ID")) = False Then mFUSER_ID = objObject.FUSER_ID 'ﾕｰｻﾞｰID
        If IsNothing(objType.GetProperty("FEXEC_DT")) = False Then mFEXEC_DT = objObject.FEXEC_DT '実行時間
        If IsNothing(objType.GetProperty("FPROGRESS_PLNINV")) = False Then mFPROGRESS_PLNINV = objObject.FPROGRESS_PLNINV '進捗状態(棚卸し)

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
        mFPLAN_KEY = Nothing
        mFPLACE_CD = Nothing
        mFAREA_CD = Nothing
        mFHINMEI_CD = Nothing
        mFLOT_NO_FM = Nothing
        mFLOT_NO_TO = Nothing
        mFRAC_RETU_FM = Nothing
        mFRAC_REN_FM = Nothing
        mFRAC_DAN_FM = Nothing
        mFRAC_RETU_TO = Nothing
        mFRAC_REN_TO = Nothing
        mFRAC_DAN_TO = Nothing
        mFTR_TO = Nothing
        mFTERM_ID = Nothing
        mFUSER_ID = Nothing
        mFEXEC_DT = Nothing
        mFPROGRESS_PLNINV = Nothing


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
        mFPLAN_KEY = TO_STRING_NULLABLE(objRow("FPLAN_KEY"))
        mFPLACE_CD = TO_INTEGER_NULLABLE(objRow("FPLACE_CD"))
        mFAREA_CD = TO_INTEGER_NULLABLE(objRow("FAREA_CD"))
        mFHINMEI_CD = TO_STRING_NULLABLE(objRow("FHINMEI_CD"))
        mFLOT_NO_FM = TO_STRING_NULLABLE(objRow("FLOT_NO_FM"))
        mFLOT_NO_TO = TO_STRING_NULLABLE(objRow("FLOT_NO_TO"))
        mFRAC_RETU_FM = TO_INTEGER_NULLABLE(objRow("FRAC_RETU_FM"))
        mFRAC_REN_FM = TO_INTEGER_NULLABLE(objRow("FRAC_REN_FM"))
        mFRAC_DAN_FM = TO_INTEGER_NULLABLE(objRow("FRAC_DAN_FM"))
        mFRAC_RETU_TO = TO_INTEGER_NULLABLE(objRow("FRAC_RETU_TO"))
        mFRAC_REN_TO = TO_INTEGER_NULLABLE(objRow("FRAC_REN_TO"))
        mFRAC_DAN_TO = TO_INTEGER_NULLABLE(objRow("FRAC_DAN_TO"))
        mFTR_TO = TO_INTEGER_NULLABLE(objRow("FTR_TO"))
        mFTERM_ID = TO_STRING_NULLABLE(objRow("FTERM_ID"))
        mFUSER_ID = TO_STRING_NULLABLE(objRow("FUSER_ID"))
        mFEXEC_DT = TO_DATE_NULLABLE(objRow("FEXEC_DT"))
        mFPROGRESS_PLNINV = TO_INTEGER_NULLABLE(objRow("FPROGRESS_PLNINV"))


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
        strMsg &= "[ﾃｰﾌﾞﾙ名:棚卸し作業]"
        If IsNotNull(FPLAN_KEY) Then
            strMsg &= "[計画ｷｰ:" & FPLAN_KEY & "]"
        End If
        If IsNotNull(FPLACE_CD) Then
            strMsg &= "[保管場所ｺｰﾄﾞ:" & FPLACE_CD & "]"
        End If
        If IsNotNull(FAREA_CD) Then
            strMsg &= "[ｴﾘｱｺｰﾄﾞ:" & FAREA_CD & "]"
        End If
        If IsNotNull(FHINMEI_CD) Then
            strMsg &= "[品目ｺｰﾄﾞ:" & FHINMEI_CD & "]"
        End If
        If IsNotNull(FLOT_NO_FM) Then
            strMsg &= "[Fmﾛｯﾄ№:" & FLOT_NO_FM & "]"
        End If
        If IsNotNull(FLOT_NO_TO) Then
            strMsg &= "[Toﾛｯﾄ№:" & FLOT_NO_TO & "]"
        End If
        If IsNotNull(FRAC_RETU_FM) Then
            strMsg &= "[Fm列:" & FRAC_RETU_FM & "]"
        End If
        If IsNotNull(FRAC_REN_FM) Then
            strMsg &= "[Fm連:" & FRAC_REN_FM & "]"
        End If
        If IsNotNull(FRAC_DAN_FM) Then
            strMsg &= "[Fm段:" & FRAC_DAN_FM & "]"
        End If
        If IsNotNull(FRAC_RETU_TO) Then
            strMsg &= "[To列:" & FRAC_RETU_TO & "]"
        End If
        If IsNotNull(FRAC_REN_TO) Then
            strMsg &= "[To連:" & FRAC_REN_TO & "]"
        End If
        If IsNotNull(FRAC_DAN_TO) Then
            strMsg &= "[To段:" & FRAC_DAN_TO & "]"
        End If
        If IsNotNull(FTR_TO) Then
            strMsg &= "[搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & FTR_TO & "]"
        End If
        If IsNotNull(FTERM_ID) Then
            strMsg &= "[端末ID:" & FTERM_ID & "]"
        End If
        If IsNotNull(FUSER_ID) Then
            strMsg &= "[ﾕｰｻﾞｰID:" & FUSER_ID & "]"
        End If
        If IsNotNull(FEXEC_DT) Then
            strMsg &= "[実行時間:" & FEXEC_DT & "]"
        End If
        If IsNotNull(FPROGRESS_PLNINV) Then
            strMsg &= "[進捗状態(棚卸し):" & FPROGRESS_PLNINV & "]"
        End If


    End Sub
#End Region
    '↑↑↑自動生成部
    '**********************************************************************************************

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ共通
#Region "  棚卸し作業追加  [SEQ発番]                                    "
    Public Sub ADD_TPLN_INVENTORY_SEQ()
        Try


            '***********************
            'ﾛｸﾞ№の特定
            '***********************
            Dim objTPRG_SEQNO As New TBL_TPRG_SEQNO(Owner, ObjDb, ObjDbLog) 'ｼｰｹﾝｽ№ｸﾗｽ
            objTPRG_SEQNO.FSEQ_ID = FSEQ_ID_SSVRFPLAN_KEY_PLN_INV            'ｼｰｹﾝｽID
            mFPLAN_KEY = "INV" & objTPRG_SEQNO.GET_ENTRY_NO()               'SEQ№の特定


            '***********************
            '追加
            '***********************
            Me.ADD_TPLN_INVENTORY()


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
