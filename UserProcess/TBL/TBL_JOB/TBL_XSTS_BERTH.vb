'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' 【名称】MaterialStreamﾃｰﾌﾞﾙｸﾗｽ
' 【機能】出荷ﾊﾞｰｽ状況ﾃｰﾌﾞﾙｸﾗｽ
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
''' 出荷ﾊﾞｰｽ状況ﾃｰﾌﾞﾙｸﾗｽ
''' </summary>
Public Class TBL_XSTS_BERTH
    Inherits clsTemplateTable

    '**********************************************************************************************
    '↓↓↓自動生成部
#Region "  ｸﾗｽ変数定義                  "
    'ﾌﾟﾛﾊﾟﾃｨ
    Private mobjAryMe As TBL_XSTS_BERTH()                                        '出荷ﾊﾞｰｽ状況
    Private mstrUSER_SQL As String                                               'ﾕｰｻﾞｰSQL
    Private mORDER_BY As String                                                  'OrderBy句
    Private mWHERE As String                                                     'Where句
    Private mXBERTH_NO As String                                                 'ﾊﾞｰｽNo.
    Private mXSYUKKA_D As Nullable(Of Date)                                      '出荷日
    Private mXHENSEI_NO As String                                                '編成No.
    Private mXSYUKKA_D_RIN1 As Nullable(Of Date)                                 '隣接1出荷日
    Private mXHENSEI_NO_OYA_RIN1 As String                                       '隣接1親編成No.
    Private mXSYUKKA_D_RIN2 As Nullable(Of Date)                                 '隣接2出荷日
    Private mXHENSEI_NO_OYA_RIN2 As String                                       '隣接2親編成No.
    Private mFEQ_LOCATION As Nullable(Of Integer)                                '設備ﾛｹｰｼｮﾝ
    Private mXBERTH_YOUTO As Nullable(Of Integer)                                'ﾊﾞｰｽ用途
    Private mXBRTH_PRI_BARA As Nullable(Of Integer)                              'ﾊﾞｰｽ引当順_ﾊﾞﾗ
    Private mXBRTH_PRI_PALE As Nullable(Of Integer)                              'ﾊﾞｰｽ引当順_ﾊﾟﾚｯﾄ
    Private mFEQ_ID As String                                                    '設備ID
    Private mXBERTH_STS As Nullable(Of Integer)                                  'ﾊﾞｰｽ使用状況
    Private mXSTNO_HIKI As Nullable(Of Integer)                                  '引当STNo.
    Private mFUPDATE_DT As Nullable(Of Date)                                     '更新日時
    Private mXBERTH_GROUP As Nullable(Of Integer)                                'ﾊﾞｰｽｸﾞﾙｰﾌﾟ
    Private mXTUMI_HOUKOU As Nullable(Of Integer)                                '積込方向
    Private mXEQ_ID_B_SYABAN As String                                           '車番表示
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                  "
    ''' <summary>
    ''' ｼｽﾃﾑ変数 (自ｸﾗｽ型配列)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_XSTS_BERTH()
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
    ''' ﾊﾞｰｽNo.
    ''' </summary>
    Public Property XBERTH_NO() As String
        Get
            Return mXBERTH_NO
        End Get
        Set(ByVal Value As String)
            mXBERTH_NO = Value
        End Set
    End Property
    ''' <summary>
    ''' 出荷日
    ''' </summary>
    Public Property XSYUKKA_D() As Nullable(Of Date)
        Get
            Return mXSYUKKA_D
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mXSYUKKA_D = Value
        End Set
    End Property
    ''' <summary>
    ''' 編成No.
    ''' </summary>
    Public Property XHENSEI_NO() As String
        Get
            Return mXHENSEI_NO
        End Get
        Set(ByVal Value As String)
            mXHENSEI_NO = Value
        End Set
    End Property
    ''' <summary>
    ''' 隣接1出荷日
    ''' </summary>
    Public Property XSYUKKA_D_RIN1() As Nullable(Of Date)
        Get
            Return mXSYUKKA_D_RIN1
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mXSYUKKA_D_RIN1 = Value
        End Set
    End Property
    ''' <summary>
    ''' 隣接1親編成No.
    ''' </summary>
    Public Property XHENSEI_NO_OYA_RIN1() As String
        Get
            Return mXHENSEI_NO_OYA_RIN1
        End Get
        Set(ByVal Value As String)
            mXHENSEI_NO_OYA_RIN1 = Value
        End Set
    End Property
    ''' <summary>
    ''' 隣接2出荷日
    ''' </summary>
    Public Property XSYUKKA_D_RIN2() As Nullable(Of Date)
        Get
            Return mXSYUKKA_D_RIN2
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mXSYUKKA_D_RIN2 = Value
        End Set
    End Property
    ''' <summary>
    ''' 隣接2親編成No.
    ''' </summary>
    Public Property XHENSEI_NO_OYA_RIN2() As String
        Get
            Return mXHENSEI_NO_OYA_RIN2
        End Get
        Set(ByVal Value As String)
            mXHENSEI_NO_OYA_RIN2 = Value
        End Set
    End Property
    ''' <summary>
    ''' 設備ﾛｹｰｼｮﾝ
    ''' </summary>
    Public Property FEQ_LOCATION() As Nullable(Of Integer)
        Get
            Return mFEQ_LOCATION
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFEQ_LOCATION = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾊﾞｰｽ用途
    ''' </summary>
    Public Property XBERTH_YOUTO() As Nullable(Of Integer)
        Get
            Return mXBERTH_YOUTO
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXBERTH_YOUTO = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾊﾞｰｽ引当順_ﾊﾞﾗ
    ''' </summary>
    Public Property XBRTH_PRI_BARA() As Nullable(Of Integer)
        Get
            Return mXBRTH_PRI_BARA
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXBRTH_PRI_BARA = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾊﾞｰｽ引当順_ﾊﾟﾚｯﾄ
    ''' </summary>
    Public Property XBRTH_PRI_PALE() As Nullable(Of Integer)
        Get
            Return mXBRTH_PRI_PALE
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXBRTH_PRI_PALE = Value
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
    ''' ﾊﾞｰｽ使用状況
    ''' </summary>
    Public Property XBERTH_STS() As Nullable(Of Integer)
        Get
            Return mXBERTH_STS
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXBERTH_STS = Value
        End Set
    End Property
    ''' <summary>
    ''' 引当STNo.
    ''' </summary>
    Public Property XSTNO_HIKI() As Nullable(Of Integer)
        Get
            Return mXSTNO_HIKI
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXSTNO_HIKI = Value
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
    ''' ﾊﾞｰｽｸﾞﾙｰﾌﾟ
    ''' </summary>
    Public Property XBERTH_GROUP() As Nullable(Of Integer)
        Get
            Return mXBERTH_GROUP
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXBERTH_GROUP = Value
        End Set
    End Property
    ''' <summary>
    ''' 積込方向
    ''' </summary>
    Public Property XTUMI_HOUKOU() As Nullable(Of Integer)
        Get
            Return mXTUMI_HOUKOU
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXTUMI_HOUKOU = Value
        End Set
    End Property
    ''' <summary>
    ''' 車番表示
    ''' </summary>
    Public Property XEQ_ID_B_SYABAN() As String
        Get
            Return mXEQ_ID_B_SYABAN
        End Get
        Set(ByVal Value As String)
            mXEQ_ID_B_SYABAN = Value
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
    Public Function GET_XSTS_BERTH(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    XSTS_BERTH")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XBERTH_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_NO
            strSQL.Append(vbCrLf & "    AND XBERTH_NO = :" & UBound(strBindField) - 1 & " --ﾊﾞｰｽNo.")
        End If
        If IsNull(XSYUKKA_D) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D = :" & UBound(strBindField) - 1 & " --出荷日")
        End If
        If IsNull(XHENSEI_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO = :" & UBound(strBindField) - 1 & " --編成No.")
        End If
        If IsNull(XSYUKKA_D_RIN1) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D_RIN1
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D_RIN1 = :" & UBound(strBindField) - 1 & " --隣接1出荷日")
        End If
        If IsNull(XHENSEI_NO_OYA_RIN1) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA_RIN1
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO_OYA_RIN1 = :" & UBound(strBindField) - 1 & " --隣接1親編成No.")
        End If
        If IsNull(XSYUKKA_D_RIN2) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D_RIN2
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D_RIN2 = :" & UBound(strBindField) - 1 & " --隣接2出荷日")
        End If
        If IsNull(XHENSEI_NO_OYA_RIN2) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA_RIN2
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO_OYA_RIN2 = :" & UBound(strBindField) - 1 & " --隣接2親編成No.")
        End If
        If IsNull(FEQ_LOCATION) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_LOCATION
            strSQL.Append(vbCrLf & "    AND FEQ_LOCATION = :" & UBound(strBindField) - 1 & " --設備ﾛｹｰｼｮﾝ")
        End If
        If IsNull(XBERTH_YOUTO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_YOUTO
            strSQL.Append(vbCrLf & "    AND XBERTH_YOUTO = :" & UBound(strBindField) - 1 & " --ﾊﾞｰｽ用途")
        End If
        If IsNull(XBRTH_PRI_BARA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBRTH_PRI_BARA
            strSQL.Append(vbCrLf & "    AND XBRTH_PRI_BARA = :" & UBound(strBindField) - 1 & " --ﾊﾞｰｽ引当順_ﾊﾞﾗ")
        End If
        If IsNull(XBRTH_PRI_PALE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBRTH_PRI_PALE
            strSQL.Append(vbCrLf & "    AND XBRTH_PRI_PALE = :" & UBound(strBindField) - 1 & " --ﾊﾞｰｽ引当順_ﾊﾟﾚｯﾄ")
        End If
        If IsNull(FEQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --設備ID")
        End If
        If IsNull(XBERTH_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_STS
            strSQL.Append(vbCrLf & "    AND XBERTH_STS = :" & UBound(strBindField) - 1 & " --ﾊﾞｰｽ使用状況")
        End If
        If IsNull(XSTNO_HIKI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSTNO_HIKI
            strSQL.Append(vbCrLf & "    AND XSTNO_HIKI = :" & UBound(strBindField) - 1 & " --引当STNo.")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --更新日時")
        End If
        If IsNull(XBERTH_GROUP) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_GROUP
            strSQL.Append(vbCrLf & "    AND XBERTH_GROUP = :" & UBound(strBindField) - 1 & " --ﾊﾞｰｽｸﾞﾙｰﾌﾟ")
        End If
        If IsNull(XTUMI_HOUKOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_HOUKOU
            strSQL.Append(vbCrLf & "    AND XTUMI_HOUKOU = :" & UBound(strBindField) - 1 & " --積込方向")
        End If
        If IsNull(XEQ_ID_B_SYABAN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_SYABAN
            strSQL.Append(vbCrLf & "    AND XEQ_ID_B_SYABAN = :" & UBound(strBindField) - 1 & " --車番表示")
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
        strDataSetName = "XSTS_BERTH"
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
    Public Function GET_XSTS_BERTH_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    XSTS_BERTH")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XBERTH_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_NO
            strSQL.Append(vbCrLf & "    AND XBERTH_NO = :" & UBound(strBindField) - 1 & " --ﾊﾞｰｽNo.")
        End If
        If IsNull(XSYUKKA_D) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D = :" & UBound(strBindField) - 1 & " --出荷日")
        End If
        If IsNull(XHENSEI_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO = :" & UBound(strBindField) - 1 & " --編成No.")
        End If
        If IsNull(XSYUKKA_D_RIN1) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D_RIN1
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D_RIN1 = :" & UBound(strBindField) - 1 & " --隣接1出荷日")
        End If
        If IsNull(XHENSEI_NO_OYA_RIN1) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA_RIN1
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO_OYA_RIN1 = :" & UBound(strBindField) - 1 & " --隣接1親編成No.")
        End If
        If IsNull(XSYUKKA_D_RIN2) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D_RIN2
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D_RIN2 = :" & UBound(strBindField) - 1 & " --隣接2出荷日")
        End If
        If IsNull(XHENSEI_NO_OYA_RIN2) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA_RIN2
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO_OYA_RIN2 = :" & UBound(strBindField) - 1 & " --隣接2親編成No.")
        End If
        If IsNull(FEQ_LOCATION) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_LOCATION
            strSQL.Append(vbCrLf & "    AND FEQ_LOCATION = :" & UBound(strBindField) - 1 & " --設備ﾛｹｰｼｮﾝ")
        End If
        If IsNull(XBERTH_YOUTO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_YOUTO
            strSQL.Append(vbCrLf & "    AND XBERTH_YOUTO = :" & UBound(strBindField) - 1 & " --ﾊﾞｰｽ用途")
        End If
        If IsNull(XBRTH_PRI_BARA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBRTH_PRI_BARA
            strSQL.Append(vbCrLf & "    AND XBRTH_PRI_BARA = :" & UBound(strBindField) - 1 & " --ﾊﾞｰｽ引当順_ﾊﾞﾗ")
        End If
        If IsNull(XBRTH_PRI_PALE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBRTH_PRI_PALE
            strSQL.Append(vbCrLf & "    AND XBRTH_PRI_PALE = :" & UBound(strBindField) - 1 & " --ﾊﾞｰｽ引当順_ﾊﾟﾚｯﾄ")
        End If
        If IsNull(FEQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --設備ID")
        End If
        If IsNull(XBERTH_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_STS
            strSQL.Append(vbCrLf & "    AND XBERTH_STS = :" & UBound(strBindField) - 1 & " --ﾊﾞｰｽ使用状況")
        End If
        If IsNull(XSTNO_HIKI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSTNO_HIKI
            strSQL.Append(vbCrLf & "    AND XSTNO_HIKI = :" & UBound(strBindField) - 1 & " --引当STNo.")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --更新日時")
        End If
        If IsNull(XBERTH_GROUP) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_GROUP
            strSQL.Append(vbCrLf & "    AND XBERTH_GROUP = :" & UBound(strBindField) - 1 & " --ﾊﾞｰｽｸﾞﾙｰﾌﾟ")
        End If
        If IsNull(XTUMI_HOUKOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_HOUKOU
            strSQL.Append(vbCrLf & "    AND XTUMI_HOUKOU = :" & UBound(strBindField) - 1 & " --積込方向")
        End If
        If IsNull(XEQ_ID_B_SYABAN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_SYABAN
            strSQL.Append(vbCrLf & "    AND XEQ_ID_B_SYABAN = :" & UBound(strBindField) - 1 & " --車番表示")
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
        strDataSetName = "XSTS_BERTH"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XSTS_BERTH(Owner, objDb, objDbLog)
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
    Public Function GET_XSTS_BERTH_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "XSTS_BERTH"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XSTS_BERTH(Owner, objDb, objDbLog)
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
    Public Function GET_XSTS_BERTH_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    XSTS_BERTH")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XBERTH_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_NO
            strSQL.Append(vbCrLf & "    AND XBERTH_NO = :" & UBound(strBindField) - 1 & " --ﾊﾞｰｽNo.")
        End If
        If IsNull(XSYUKKA_D) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D = :" & UBound(strBindField) - 1 & " --出荷日")
        End If
        If IsNull(XHENSEI_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO = :" & UBound(strBindField) - 1 & " --編成No.")
        End If
        If IsNull(XSYUKKA_D_RIN1) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D_RIN1
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D_RIN1 = :" & UBound(strBindField) - 1 & " --隣接1出荷日")
        End If
        If IsNull(XHENSEI_NO_OYA_RIN1) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA_RIN1
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO_OYA_RIN1 = :" & UBound(strBindField) - 1 & " --隣接1親編成No.")
        End If
        If IsNull(XSYUKKA_D_RIN2) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D_RIN2
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D_RIN2 = :" & UBound(strBindField) - 1 & " --隣接2出荷日")
        End If
        If IsNull(XHENSEI_NO_OYA_RIN2) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA_RIN2
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO_OYA_RIN2 = :" & UBound(strBindField) - 1 & " --隣接2親編成No.")
        End If
        If IsNull(FEQ_LOCATION) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_LOCATION
            strSQL.Append(vbCrLf & "    AND FEQ_LOCATION = :" & UBound(strBindField) - 1 & " --設備ﾛｹｰｼｮﾝ")
        End If
        If IsNull(XBERTH_YOUTO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_YOUTO
            strSQL.Append(vbCrLf & "    AND XBERTH_YOUTO = :" & UBound(strBindField) - 1 & " --ﾊﾞｰｽ用途")
        End If
        If IsNull(XBRTH_PRI_BARA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBRTH_PRI_BARA
            strSQL.Append(vbCrLf & "    AND XBRTH_PRI_BARA = :" & UBound(strBindField) - 1 & " --ﾊﾞｰｽ引当順_ﾊﾞﾗ")
        End If
        If IsNull(XBRTH_PRI_PALE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBRTH_PRI_PALE
            strSQL.Append(vbCrLf & "    AND XBRTH_PRI_PALE = :" & UBound(strBindField) - 1 & " --ﾊﾞｰｽ引当順_ﾊﾟﾚｯﾄ")
        End If
        If IsNull(FEQ_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --設備ID")
        End If
        If IsNull(XBERTH_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_STS
            strSQL.Append(vbCrLf & "    AND XBERTH_STS = :" & UBound(strBindField) - 1 & " --ﾊﾞｰｽ使用状況")
        End If
        If IsNull(XSTNO_HIKI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSTNO_HIKI
            strSQL.Append(vbCrLf & "    AND XSTNO_HIKI = :" & UBound(strBindField) - 1 & " --引当STNo.")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --更新日時")
        End If
        If IsNull(XBERTH_GROUP) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_GROUP
            strSQL.Append(vbCrLf & "    AND XBERTH_GROUP = :" & UBound(strBindField) - 1 & " --ﾊﾞｰｽｸﾞﾙｰﾌﾟ")
        End If
        If IsNull(XTUMI_HOUKOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_HOUKOU
            strSQL.Append(vbCrLf & "    AND XTUMI_HOUKOU = :" & UBound(strBindField) - 1 & " --積込方向")
        End If
        If IsNull(XEQ_ID_B_SYABAN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_SYABAN
            strSQL.Append(vbCrLf & "    AND XEQ_ID_B_SYABAN = :" & UBound(strBindField) - 1 & " --車番表示")
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
        strDataSetName = "XSTS_BERTH"
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
    Public Sub UPDATE_XSTS_BERTH()
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
        ElseIf IsNull(mXBERTH_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾊﾞｰｽNo.]"
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
        strSQL.Append(vbCrLf & "    XSTS_BERTH")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
        If IsNull(mXBERTH_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XBERTH_NO = NULL --ﾊﾞｰｽNo.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XBERTH_NO = NULL --ﾊﾞｰｽNo.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XBERTH_NO = :" & Ubound(strBindField) - 1 & " --ﾊﾞｰｽNo.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XBERTH_NO = :" & Ubound(strBindField) - 1 & " --ﾊﾞｰｽNo.")
        End If
        intCount = intCount + 1
        If IsNull(mXSYUKKA_D) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_D = NULL --出荷日")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_D = NULL --出荷日")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_D = :" & Ubound(strBindField) - 1 & " --出荷日")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_D = :" & Ubound(strBindField) - 1 & " --出荷日")
        End If
        intCount = intCount + 1
        If IsNull(mXHENSEI_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XHENSEI_NO = NULL --編成No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XHENSEI_NO = NULL --編成No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XHENSEI_NO = :" & Ubound(strBindField) - 1 & " --編成No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XHENSEI_NO = :" & Ubound(strBindField) - 1 & " --編成No.")
        End If
        intCount = intCount + 1
        If IsNull(mXSYUKKA_D_RIN1) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_D_RIN1 = NULL --隣接1出荷日")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_D_RIN1 = NULL --隣接1出荷日")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D_RIN1
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_D_RIN1 = :" & Ubound(strBindField) - 1 & " --隣接1出荷日")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_D_RIN1 = :" & Ubound(strBindField) - 1 & " --隣接1出荷日")
        End If
        intCount = intCount + 1
        If IsNull(mXHENSEI_NO_OYA_RIN1) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XHENSEI_NO_OYA_RIN1 = NULL --隣接1親編成No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XHENSEI_NO_OYA_RIN1 = NULL --隣接1親編成No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA_RIN1
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XHENSEI_NO_OYA_RIN1 = :" & Ubound(strBindField) - 1 & " --隣接1親編成No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XHENSEI_NO_OYA_RIN1 = :" & Ubound(strBindField) - 1 & " --隣接1親編成No.")
        End If
        intCount = intCount + 1
        If IsNull(mXSYUKKA_D_RIN2) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_D_RIN2 = NULL --隣接2出荷日")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_D_RIN2 = NULL --隣接2出荷日")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D_RIN2
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_D_RIN2 = :" & Ubound(strBindField) - 1 & " --隣接2出荷日")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_D_RIN2 = :" & Ubound(strBindField) - 1 & " --隣接2出荷日")
        End If
        intCount = intCount + 1
        If IsNull(mXHENSEI_NO_OYA_RIN2) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XHENSEI_NO_OYA_RIN2 = NULL --隣接2親編成No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XHENSEI_NO_OYA_RIN2 = NULL --隣接2親編成No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA_RIN2
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XHENSEI_NO_OYA_RIN2 = :" & Ubound(strBindField) - 1 & " --隣接2親編成No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XHENSEI_NO_OYA_RIN2 = :" & Ubound(strBindField) - 1 & " --隣接2親編成No.")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_LOCATION) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_LOCATION = NULL --設備ﾛｹｰｼｮﾝ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_LOCATION = NULL --設備ﾛｹｰｼｮﾝ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_LOCATION
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FEQ_LOCATION = :" & Ubound(strBindField) - 1 & " --設備ﾛｹｰｼｮﾝ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FEQ_LOCATION = :" & Ubound(strBindField) - 1 & " --設備ﾛｹｰｼｮﾝ")
        End If
        intCount = intCount + 1
        If IsNull(mXBERTH_YOUTO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XBERTH_YOUTO = NULL --ﾊﾞｰｽ用途")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XBERTH_YOUTO = NULL --ﾊﾞｰｽ用途")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_YOUTO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XBERTH_YOUTO = :" & Ubound(strBindField) - 1 & " --ﾊﾞｰｽ用途")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XBERTH_YOUTO = :" & Ubound(strBindField) - 1 & " --ﾊﾞｰｽ用途")
        End If
        intCount = intCount + 1
        If IsNull(mXBRTH_PRI_BARA) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XBRTH_PRI_BARA = NULL --ﾊﾞｰｽ引当順_ﾊﾞﾗ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XBRTH_PRI_BARA = NULL --ﾊﾞｰｽ引当順_ﾊﾞﾗ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBRTH_PRI_BARA
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XBRTH_PRI_BARA = :" & Ubound(strBindField) - 1 & " --ﾊﾞｰｽ引当順_ﾊﾞﾗ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XBRTH_PRI_BARA = :" & Ubound(strBindField) - 1 & " --ﾊﾞｰｽ引当順_ﾊﾞﾗ")
        End If
        intCount = intCount + 1
        If IsNull(mXBRTH_PRI_PALE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XBRTH_PRI_PALE = NULL --ﾊﾞｰｽ引当順_ﾊﾟﾚｯﾄ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XBRTH_PRI_PALE = NULL --ﾊﾞｰｽ引当順_ﾊﾟﾚｯﾄ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBRTH_PRI_PALE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XBRTH_PRI_PALE = :" & Ubound(strBindField) - 1 & " --ﾊﾞｰｽ引当順_ﾊﾟﾚｯﾄ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XBRTH_PRI_PALE = :" & Ubound(strBindField) - 1 & " --ﾊﾞｰｽ引当順_ﾊﾟﾚｯﾄ")
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
        If IsNull(mXBERTH_STS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XBERTH_STS = NULL --ﾊﾞｰｽ使用状況")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XBERTH_STS = NULL --ﾊﾞｰｽ使用状況")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_STS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XBERTH_STS = :" & Ubound(strBindField) - 1 & " --ﾊﾞｰｽ使用状況")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XBERTH_STS = :" & Ubound(strBindField) - 1 & " --ﾊﾞｰｽ使用状況")
        End If
        intCount = intCount + 1
        If IsNull(mXSTNO_HIKI) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSTNO_HIKI = NULL --引当STNo.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSTNO_HIKI = NULL --引当STNo.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSTNO_HIKI
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSTNO_HIKI = :" & Ubound(strBindField) - 1 & " --引当STNo.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSTNO_HIKI = :" & Ubound(strBindField) - 1 & " --引当STNo.")
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
        If IsNull(mXBERTH_GROUP) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XBERTH_GROUP = NULL --ﾊﾞｰｽｸﾞﾙｰﾌﾟ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XBERTH_GROUP = NULL --ﾊﾞｰｽｸﾞﾙｰﾌﾟ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_GROUP
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XBERTH_GROUP = :" & Ubound(strBindField) - 1 & " --ﾊﾞｰｽｸﾞﾙｰﾌﾟ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XBERTH_GROUP = :" & Ubound(strBindField) - 1 & " --ﾊﾞｰｽｸﾞﾙｰﾌﾟ")
        End If
        intCount = intCount + 1
        If IsNull(mXTUMI_HOUKOU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTUMI_HOUKOU = NULL --積込方向")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTUMI_HOUKOU = NULL --積込方向")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_HOUKOU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTUMI_HOUKOU = :" & Ubound(strBindField) - 1 & " --積込方向")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTUMI_HOUKOU = :" & Ubound(strBindField) - 1 & " --積込方向")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_B_SYABAN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_B_SYABAN = NULL --車番表示")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_B_SYABAN = NULL --車番表示")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_SYABAN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_B_SYABAN = :" & Ubound(strBindField) - 1 & " --車番表示")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_B_SYABAN = :" & Ubound(strBindField) - 1 & " --車番表示")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(XBERTH_NO) = True Then
            strSQL.Append(vbCrLf & "    AND XBERTH_NO IS NULL --ﾊﾞｰｽNo.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_NO
            strSQL.Append(vbCrLf & "    AND XBERTH_NO = :" & UBound(strBindField) - 1 & " --ﾊﾞｰｽNo.")
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
    Public Sub ADD_XSTS_BERTH()
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
        ElseIf IsNull(mXBERTH_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾊﾞｰｽNo.]"
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
        strSQL.Append(vbCrLf & "    XSTS_BERTH")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
        If IsNull(mXBERTH_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾊﾞｰｽNo.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾊﾞｰｽNo.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾊﾞｰｽNo.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾊﾞｰｽNo.")
        End If
        intCount = intCount + 1
        If IsNull(mXSYUKKA_D) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --出荷日")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --出荷日")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --出荷日")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --出荷日")
        End If
        intCount = intCount + 1
        If IsNull(mXHENSEI_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --編成No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --編成No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --編成No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --編成No.")
        End If
        intCount = intCount + 1
        If IsNull(mXSYUKKA_D_RIN1) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --隣接1出荷日")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --隣接1出荷日")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D_RIN1
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --隣接1出荷日")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --隣接1出荷日")
        End If
        intCount = intCount + 1
        If IsNull(mXHENSEI_NO_OYA_RIN1) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --隣接1親編成No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --隣接1親編成No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA_RIN1
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --隣接1親編成No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --隣接1親編成No.")
        End If
        intCount = intCount + 1
        If IsNull(mXSYUKKA_D_RIN2) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --隣接2出荷日")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --隣接2出荷日")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D_RIN2
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --隣接2出荷日")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --隣接2出荷日")
        End If
        intCount = intCount + 1
        If IsNull(mXHENSEI_NO_OYA_RIN2) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --隣接2親編成No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --隣接2親編成No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA_RIN2
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --隣接2親編成No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --隣接2親編成No.")
        End If
        intCount = intCount + 1
        If IsNull(mFEQ_LOCATION) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --設備ﾛｹｰｼｮﾝ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --設備ﾛｹｰｼｮﾝ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_LOCATION
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --設備ﾛｹｰｼｮﾝ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --設備ﾛｹｰｼｮﾝ")
        End If
        intCount = intCount + 1
        If IsNull(mXBERTH_YOUTO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾊﾞｰｽ用途")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾊﾞｰｽ用途")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_YOUTO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾊﾞｰｽ用途")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾊﾞｰｽ用途")
        End If
        intCount = intCount + 1
        If IsNull(mXBRTH_PRI_BARA) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾊﾞｰｽ引当順_ﾊﾞﾗ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾊﾞｰｽ引当順_ﾊﾞﾗ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBRTH_PRI_BARA
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾊﾞｰｽ引当順_ﾊﾞﾗ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾊﾞｰｽ引当順_ﾊﾞﾗ")
        End If
        intCount = intCount + 1
        If IsNull(mXBRTH_PRI_PALE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾊﾞｰｽ引当順_ﾊﾟﾚｯﾄ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾊﾞｰｽ引当順_ﾊﾟﾚｯﾄ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBRTH_PRI_PALE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾊﾞｰｽ引当順_ﾊﾟﾚｯﾄ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾊﾞｰｽ引当順_ﾊﾟﾚｯﾄ")
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
        If IsNull(mXBERTH_STS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾊﾞｰｽ使用状況")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾊﾞｰｽ使用状況")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_STS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾊﾞｰｽ使用状況")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾊﾞｰｽ使用状況")
        End If
        intCount = intCount + 1
        If IsNull(mXSTNO_HIKI) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --引当STNo.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --引当STNo.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSTNO_HIKI
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --引当STNo.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --引当STNo.")
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
        If IsNull(mXBERTH_GROUP) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾊﾞｰｽｸﾞﾙｰﾌﾟ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾊﾞｰｽｸﾞﾙｰﾌﾟ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_GROUP
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾊﾞｰｽｸﾞﾙｰﾌﾟ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾊﾞｰｽｸﾞﾙｰﾌﾟ")
        End If
        intCount = intCount + 1
        If IsNull(mXTUMI_HOUKOU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --積込方向")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --積込方向")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_HOUKOU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --積込方向")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --積込方向")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_B_SYABAN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --車番表示")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --車番表示")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_SYABAN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --車番表示")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --車番表示")
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
    Public Sub DELETE_XSTS_BERTH()
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
        ElseIf IsNull(mXBERTH_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾊﾞｰｽNo.]"
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
        strSQL.Append(vbCrLf & "    XSTS_BERTH")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(XBERTH_NO) = True Then
            strSQL.Append(vbCrLf & "    AND XBERTH_NO IS NULL --ﾊﾞｰｽNo.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_NO
            strSQL.Append(vbCrLf & "    AND XBERTH_NO = :" & UBound(strBindField) - 1 & " --ﾊﾞｰｽNo.")
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
    Public Sub DELETE_XSTS_BERTH_ANY()
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
        strSQL.Append(vbCrLf & "    XSTS_BERTH")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(XBERTH_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_NO
            strSQL.Append(vbCrLf & "    AND XBERTH_NO = :" & UBound(strBindField) - 1 & " --ﾊﾞｰｽNo.")
        End If
        If IsNotNull(XSYUKKA_D) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D = :" & UBound(strBindField) - 1 & " --出荷日")
        End If
        If IsNotNull(XHENSEI_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO = :" & UBound(strBindField) - 1 & " --編成No.")
        End If
        If IsNotNull(XSYUKKA_D_RIN1) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D_RIN1
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D_RIN1 = :" & UBound(strBindField) - 1 & " --隣接1出荷日")
        End If
        If IsNotNull(XHENSEI_NO_OYA_RIN1) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA_RIN1
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO_OYA_RIN1 = :" & UBound(strBindField) - 1 & " --隣接1親編成No.")
        End If
        If IsNotNull(XSYUKKA_D_RIN2) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D_RIN2
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D_RIN2 = :" & UBound(strBindField) - 1 & " --隣接2出荷日")
        End If
        If IsNotNull(XHENSEI_NO_OYA_RIN2) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA_RIN2
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO_OYA_RIN2 = :" & UBound(strBindField) - 1 & " --隣接2親編成No.")
        End If
        If IsNotNull(FEQ_LOCATION) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_LOCATION
            strSQL.Append(vbCrLf & "    AND FEQ_LOCATION = :" & UBound(strBindField) - 1 & " --設備ﾛｹｰｼｮﾝ")
        End If
        If IsNotNull(XBERTH_YOUTO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_YOUTO
            strSQL.Append(vbCrLf & "    AND XBERTH_YOUTO = :" & UBound(strBindField) - 1 & " --ﾊﾞｰｽ用途")
        End If
        If IsNotNull(XBRTH_PRI_BARA) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBRTH_PRI_BARA
            strSQL.Append(vbCrLf & "    AND XBRTH_PRI_BARA = :" & UBound(strBindField) - 1 & " --ﾊﾞｰｽ引当順_ﾊﾞﾗ")
        End If
        If IsNotNull(XBRTH_PRI_PALE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBRTH_PRI_PALE
            strSQL.Append(vbCrLf & "    AND XBRTH_PRI_PALE = :" & UBound(strBindField) - 1 & " --ﾊﾞｰｽ引当順_ﾊﾟﾚｯﾄ")
        End If
        If IsNotNull(FEQ_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFEQ_ID
            strSQL.Append(vbCrLf & "    AND FEQ_ID = :" & UBound(strBindField) - 1 & " --設備ID")
        End If
        If IsNotNull(XBERTH_STS) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_STS
            strSQL.Append(vbCrLf & "    AND XBERTH_STS = :" & UBound(strBindField) - 1 & " --ﾊﾞｰｽ使用状況")
        End If
        If IsNotNull(XSTNO_HIKI) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSTNO_HIKI
            strSQL.Append(vbCrLf & "    AND XSTNO_HIKI = :" & UBound(strBindField) - 1 & " --引当STNo.")
        End If
        If IsNotNull(FUPDATE_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --更新日時")
        End If
        If IsNotNull(XBERTH_GROUP) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_GROUP
            strSQL.Append(vbCrLf & "    AND XBERTH_GROUP = :" & UBound(strBindField) - 1 & " --ﾊﾞｰｽｸﾞﾙｰﾌﾟ")
        End If
        If IsNotNull(XTUMI_HOUKOU) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_HOUKOU
            strSQL.Append(vbCrLf & "    AND XTUMI_HOUKOU = :" & UBound(strBindField) - 1 & " --積込方向")
        End If
        If IsNotNull(XEQ_ID_B_SYABAN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_SYABAN
            strSQL.Append(vbCrLf & "    AND XEQ_ID_B_SYABAN = :" & UBound(strBindField) - 1 & " --車番表示")
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
        If IsNothing(objType.GetProperty("XBERTH_NO")) = False Then mXBERTH_NO = objObject.XBERTH_NO 'ﾊﾞｰｽNo.
        If IsNothing(objType.GetProperty("XSYUKKA_D")) = False Then mXSYUKKA_D = objObject.XSYUKKA_D '出荷日
        If IsNothing(objType.GetProperty("XHENSEI_NO")) = False Then mXHENSEI_NO = objObject.XHENSEI_NO '編成No.
        If IsNothing(objType.GetProperty("XSYUKKA_D_RIN1")) = False Then mXSYUKKA_D_RIN1 = objObject.XSYUKKA_D_RIN1 '隣接1出荷日
        If IsNothing(objType.GetProperty("XHENSEI_NO_OYA_RIN1")) = False Then mXHENSEI_NO_OYA_RIN1 = objObject.XHENSEI_NO_OYA_RIN1 '隣接1親編成No.
        If IsNothing(objType.GetProperty("XSYUKKA_D_RIN2")) = False Then mXSYUKKA_D_RIN2 = objObject.XSYUKKA_D_RIN2 '隣接2出荷日
        If IsNothing(objType.GetProperty("XHENSEI_NO_OYA_RIN2")) = False Then mXHENSEI_NO_OYA_RIN2 = objObject.XHENSEI_NO_OYA_RIN2 '隣接2親編成No.
        If IsNothing(objType.GetProperty("FEQ_LOCATION")) = False Then mFEQ_LOCATION = objObject.FEQ_LOCATION '設備ﾛｹｰｼｮﾝ
        If IsNothing(objType.GetProperty("XBERTH_YOUTO")) = False Then mXBERTH_YOUTO = objObject.XBERTH_YOUTO 'ﾊﾞｰｽ用途
        If IsNothing(objType.GetProperty("XBRTH_PRI_BARA")) = False Then mXBRTH_PRI_BARA = objObject.XBRTH_PRI_BARA 'ﾊﾞｰｽ引当順_ﾊﾞﾗ
        If IsNothing(objType.GetProperty("XBRTH_PRI_PALE")) = False Then mXBRTH_PRI_PALE = objObject.XBRTH_PRI_PALE 'ﾊﾞｰｽ引当順_ﾊﾟﾚｯﾄ
        If IsNothing(objType.GetProperty("FEQ_ID")) = False Then mFEQ_ID = objObject.FEQ_ID '設備ID
        If IsNothing(objType.GetProperty("XBERTH_STS")) = False Then mXBERTH_STS = objObject.XBERTH_STS 'ﾊﾞｰｽ使用状況
        If IsNothing(objType.GetProperty("XSTNO_HIKI")) = False Then mXSTNO_HIKI = objObject.XSTNO_HIKI '引当STNo.
        If IsNothing(objType.GetProperty("FUPDATE_DT")) = False Then mFUPDATE_DT = objObject.FUPDATE_DT '更新日時
        If IsNothing(objType.GetProperty("XBERTH_GROUP")) = False Then mXBERTH_GROUP = objObject.XBERTH_GROUP 'ﾊﾞｰｽｸﾞﾙｰﾌﾟ
        If IsNothing(objType.GetProperty("XTUMI_HOUKOU")) = False Then mXTUMI_HOUKOU = objObject.XTUMI_HOUKOU '積込方向
        If IsNothing(objType.GetProperty("XEQ_ID_B_SYABAN")) = False Then mXEQ_ID_B_SYABAN = objObject.XEQ_ID_B_SYABAN '車番表示

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
        mXBERTH_NO = Nothing
        mXSYUKKA_D = Nothing
        mXHENSEI_NO = Nothing
        mXSYUKKA_D_RIN1 = Nothing
        mXHENSEI_NO_OYA_RIN1 = Nothing
        mXSYUKKA_D_RIN2 = Nothing
        mXHENSEI_NO_OYA_RIN2 = Nothing
        mFEQ_LOCATION = Nothing
        mXBERTH_YOUTO = Nothing
        mXBRTH_PRI_BARA = Nothing
        mXBRTH_PRI_PALE = Nothing
        mFEQ_ID = Nothing
        mXBERTH_STS = Nothing
        mXSTNO_HIKI = Nothing
        mFUPDATE_DT = Nothing
        mXBERTH_GROUP = Nothing
        mXTUMI_HOUKOU = Nothing
        mXEQ_ID_B_SYABAN = Nothing


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
        mXBERTH_NO = TO_STRING_NULLABLE(objRow("XBERTH_NO"))
        mXSYUKKA_D = TO_DATE_NULLABLE(objRow("XSYUKKA_D"))
        mXHENSEI_NO = TO_STRING_NULLABLE(objRow("XHENSEI_NO"))
        mXSYUKKA_D_RIN1 = TO_DATE_NULLABLE(objRow("XSYUKKA_D_RIN1"))
        mXHENSEI_NO_OYA_RIN1 = TO_STRING_NULLABLE(objRow("XHENSEI_NO_OYA_RIN1"))
        mXSYUKKA_D_RIN2 = TO_DATE_NULLABLE(objRow("XSYUKKA_D_RIN2"))
        mXHENSEI_NO_OYA_RIN2 = TO_STRING_NULLABLE(objRow("XHENSEI_NO_OYA_RIN2"))
        mFEQ_LOCATION = TO_INTEGER_NULLABLE(objRow("FEQ_LOCATION"))
        mXBERTH_YOUTO = TO_INTEGER_NULLABLE(objRow("XBERTH_YOUTO"))
        mXBRTH_PRI_BARA = TO_INTEGER_NULLABLE(objRow("XBRTH_PRI_BARA"))
        mXBRTH_PRI_PALE = TO_INTEGER_NULLABLE(objRow("XBRTH_PRI_PALE"))
        mFEQ_ID = TO_STRING_NULLABLE(objRow("FEQ_ID"))
        mXBERTH_STS = TO_INTEGER_NULLABLE(objRow("XBERTH_STS"))
        mXSTNO_HIKI = TO_INTEGER_NULLABLE(objRow("XSTNO_HIKI"))
        mFUPDATE_DT = TO_DATE_NULLABLE(objRow("FUPDATE_DT"))
        mXBERTH_GROUP = TO_INTEGER_NULLABLE(objRow("XBERTH_GROUP"))
        mXTUMI_HOUKOU = TO_INTEGER_NULLABLE(objRow("XTUMI_HOUKOU"))
        mXEQ_ID_B_SYABAN = TO_STRING_NULLABLE(objRow("XEQ_ID_B_SYABAN"))


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
        strMsg &= "[ﾃｰﾌﾞﾙ名:出荷ﾊﾞｰｽ状況]"
        If IsNotNull(XBERTH_NO) Then
            strMsg &= "[ﾊﾞｰｽNo.:" & XBERTH_NO & "]"
        End If
        If IsNotNull(XSYUKKA_D) Then
            strMsg &= "[出荷日:" & XSYUKKA_D & "]"
        End If
        If IsNotNull(XHENSEI_NO) Then
            strMsg &= "[編成No.:" & XHENSEI_NO & "]"
        End If
        If IsNotNull(XSYUKKA_D_RIN1) Then
            strMsg &= "[隣接1出荷日:" & XSYUKKA_D_RIN1 & "]"
        End If
        If IsNotNull(XHENSEI_NO_OYA_RIN1) Then
            strMsg &= "[隣接1親編成No.:" & XHENSEI_NO_OYA_RIN1 & "]"
        End If
        If IsNotNull(XSYUKKA_D_RIN2) Then
            strMsg &= "[隣接2出荷日:" & XSYUKKA_D_RIN2 & "]"
        End If
        If IsNotNull(XHENSEI_NO_OYA_RIN2) Then
            strMsg &= "[隣接2親編成No.:" & XHENSEI_NO_OYA_RIN2 & "]"
        End If
        If IsNotNull(FEQ_LOCATION) Then
            strMsg &= "[設備ﾛｹｰｼｮﾝ:" & FEQ_LOCATION & "]"
        End If
        If IsNotNull(XBERTH_YOUTO) Then
            strMsg &= "[ﾊﾞｰｽ用途:" & XBERTH_YOUTO & "]"
        End If
        If IsNotNull(XBRTH_PRI_BARA) Then
            strMsg &= "[ﾊﾞｰｽ引当順_ﾊﾞﾗ:" & XBRTH_PRI_BARA & "]"
        End If
        If IsNotNull(XBRTH_PRI_PALE) Then
            strMsg &= "[ﾊﾞｰｽ引当順_ﾊﾟﾚｯﾄ:" & XBRTH_PRI_PALE & "]"
        End If
        If IsNotNull(FEQ_ID) Then
            strMsg &= "[設備ID:" & FEQ_ID & "]"
        End If
        If IsNotNull(XBERTH_STS) Then
            strMsg &= "[ﾊﾞｰｽ使用状況:" & XBERTH_STS & "]"
        End If
        If IsNotNull(XSTNO_HIKI) Then
            strMsg &= "[引当STNo.:" & XSTNO_HIKI & "]"
        End If
        If IsNotNull(FUPDATE_DT) Then
            strMsg &= "[更新日時:" & FUPDATE_DT & "]"
        End If
        If IsNotNull(XBERTH_GROUP) Then
            strMsg &= "[ﾊﾞｰｽｸﾞﾙｰﾌﾟ:" & XBERTH_GROUP & "]"
        End If
        If IsNotNull(XTUMI_HOUKOU) Then
            strMsg &= "[積込方向:" & XTUMI_HOUKOU & "]"
        End If
        If IsNotNull(XEQ_ID_B_SYABAN) Then
            strMsg &= "[車番表示:" & XEQ_ID_B_SYABAN & "]"
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
