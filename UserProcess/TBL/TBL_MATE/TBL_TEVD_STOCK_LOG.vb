'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' 【名称】MaterialStreamﾃｰﾌﾞﾙｸﾗｽ
' 【機能】在庫更新履歴ﾃｰﾌﾞﾙｸﾗｽ
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
''' 在庫更新履歴ﾃｰﾌﾞﾙｸﾗｽ
''' </summary>
Public Class TBL_TEVD_STOCK_LOG
    Inherits clsTemplateTable

    '**********************************************************************************************
    '↓↓↓自動生成部
#Region "  ｸﾗｽ変数定義                  "
    'ﾌﾟﾛﾊﾟﾃｨ
    Private mobjAryMe As TBL_TEVD_STOCK_LOG()                                    '在庫更新履歴
    Private mstrUSER_SQL As String                                               'ﾕｰｻﾞｰSQL
    Private mORDER_BY As String                                                  'OrderBy句
    Private mWHERE As String                                                     'Where句
    Private mFLOG_NO As String                                                   'ﾛｸﾞ№
    Private mFENTRY_DT As Nullable(Of Date)                                      '登録日時
    Private mFPALLET_ID As String                                                'ﾊﾟﾚｯﾄID
    Private mFTERM_ID As String                                                  '端末ID
    Private mFTERM_NAME As String                                                '端末名
    Private mFUSER_ID As String                                                  'ﾕｰｻﾞｰID
    Private mFUSER_NAME As String                                                '名前
    Private mFPLACE_CD As Nullable(Of Integer)                                   '保管場所ｺｰﾄﾞ
    Private mFAREA_CD As Nullable(Of Integer)                                    'ｴﾘｱｺｰﾄﾞ
    Private mFHINMEI_CD As String                                                '品目ｺｰﾄﾞ
    Private mFHINMEI As String                                                   '品名_正式名
    Private mFLOT_NO As String                                                   'ﾛｯﾄ№
    Private mFSAGYOU_KIND As Nullable(Of Integer)                                '作業種別
    Private mFNUM_IN_CASE As Nullable(Of Decimal)                                '正袋数量
    Private mFTANI As String                                                     '単位ｺｰﾄﾞ
    Private mFDECIMAL_POINT As Nullable(Of Integer)                              '小数点以下有効桁数
    Private mFSEIHIN_KUBUN As Nullable(Of Integer)                               '製品区分
    Private mFZAIKO_KUBUN As Nullable(Of Integer)                                '在庫区分
    Private mFHORYU_KUBUN As Nullable(Of Integer)                                '保留区分
    Private mFRECEIVEPAY_NUM As Nullable(Of Decimal)                             '受払数量
    Private mFZAIKO_NUM As Nullable(Of Decimal)                                  '在庫数量
    Private mFSAGYOU_CONTENT As String                                           '作業内容
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                  "
    ''' <summary>
    ''' ｼｽﾃﾑ変数 (自ｸﾗｽ型配列)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_TEVD_STOCK_LOG()
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
    ''' 端末名
    ''' </summary>
    Public Property FTERM_NAME() As String
        Get
            Return mFTERM_NAME
        End Get
        Set(ByVal Value As String)
            mFTERM_NAME = Value
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
    ''' 名前
    ''' </summary>
    Public Property FUSER_NAME() As String
        Get
            Return mFUSER_NAME
        End Get
        Set(ByVal Value As String)
            mFUSER_NAME = Value
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
    ''' 品名_正式名
    ''' </summary>
    Public Property FHINMEI() As String
        Get
            Return mFHINMEI
        End Get
        Set(ByVal Value As String)
            mFHINMEI = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾛｯﾄ№
    ''' </summary>
    Public Property FLOT_NO() As String
        Get
            Return mFLOT_NO
        End Get
        Set(ByVal Value As String)
            mFLOT_NO = Value
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
    ''' 正袋数量
    ''' </summary>
    Public Property FNUM_IN_CASE() As Nullable(Of Decimal)
        Get
            Return mFNUM_IN_CASE
        End Get
        Set(ByVal Value As Nullable(Of Decimal))
            mFNUM_IN_CASE = Value
        End Set
    End Property
    ''' <summary>
    ''' 単位ｺｰﾄﾞ
    ''' </summary>
    Public Property FTANI() As String
        Get
            Return mFTANI
        End Get
        Set(ByVal Value As String)
            mFTANI = Value
        End Set
    End Property
    ''' <summary>
    ''' 小数点以下有効桁数
    ''' </summary>
    Public Property FDECIMAL_POINT() As Nullable(Of Integer)
        Get
            Return mFDECIMAL_POINT
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFDECIMAL_POINT = Value
        End Set
    End Property
    ''' <summary>
    ''' 製品区分
    ''' </summary>
    Public Property FSEIHIN_KUBUN() As Nullable(Of Integer)
        Get
            Return mFSEIHIN_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFSEIHIN_KUBUN = Value
        End Set
    End Property
    ''' <summary>
    ''' 在庫区分
    ''' </summary>
    Public Property FZAIKO_KUBUN() As Nullable(Of Integer)
        Get
            Return mFZAIKO_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFZAIKO_KUBUN = Value
        End Set
    End Property
    ''' <summary>
    ''' 保留区分
    ''' </summary>
    Public Property FHORYU_KUBUN() As Nullable(Of Integer)
        Get
            Return mFHORYU_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFHORYU_KUBUN = Value
        End Set
    End Property
    ''' <summary>
    ''' 受払数量
    ''' </summary>
    Public Property FRECEIVEPAY_NUM() As Nullable(Of Decimal)
        Get
            Return mFRECEIVEPAY_NUM
        End Get
        Set(ByVal Value As Nullable(Of Decimal))
            mFRECEIVEPAY_NUM = Value
        End Set
    End Property
    ''' <summary>
    ''' 在庫数量
    ''' </summary>
    Public Property FZAIKO_NUM() As Nullable(Of Decimal)
        Get
            Return mFZAIKO_NUM
        End Get
        Set(ByVal Value As Nullable(Of Decimal))
            mFZAIKO_NUM = Value
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
    Public Function GET_TEVD_STOCK_LOG(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    TEVD_STOCK_LOG")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FLOG_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            strSQL.Append(vbCrLf & "    AND FLOG_NO = :" & UBound(strBindField) - 1 & " --ﾛｸﾞ№")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --登録日時")
        End If
        If IsNull(FPALLET_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄID")
        End If
        If IsNull(FTERM_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTERM_ID
            strSQL.Append(vbCrLf & "    AND FTERM_ID = :" & UBound(strBindField) - 1 & " --端末ID")
        End If
        If IsNull(FTERM_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTERM_NAME
            strSQL.Append(vbCrLf & "    AND FTERM_NAME = :" & UBound(strBindField) - 1 & " --端末名")
        End If
        If IsNull(FUSER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID
            strSQL.Append(vbCrLf & "    AND FUSER_ID = :" & UBound(strBindField) - 1 & " --ﾕｰｻﾞｰID")
        End If
        If IsNull(FUSER_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME
            strSQL.Append(vbCrLf & "    AND FUSER_NAME = :" & UBound(strBindField) - 1 & " --名前")
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
        If IsNull(FHINMEI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI
            strSQL.Append(vbCrLf & "    AND FHINMEI = :" & UBound(strBindField) - 1 & " --品名_正式名")
        End If
        If IsNull(FLOT_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO
            strSQL.Append(vbCrLf & "    AND FLOT_NO = :" & UBound(strBindField) - 1 & " --ﾛｯﾄ№")
        End If
        If IsNull(FSAGYOU_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_KIND
            strSQL.Append(vbCrLf & "    AND FSAGYOU_KIND = :" & UBound(strBindField) - 1 & " --作業種別")
        End If
        If IsNull(FNUM_IN_CASE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFNUM_IN_CASE
            strSQL.Append(vbCrLf & "    AND FNUM_IN_CASE = :" & UBound(strBindField) - 1 & " --正袋数量")
        End If
        If IsNull(FTANI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTANI
            strSQL.Append(vbCrLf & "    AND FTANI = :" & UBound(strBindField) - 1 & " --単位ｺｰﾄﾞ")
        End If
        If IsNull(FDECIMAL_POINT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDECIMAL_POINT
            strSQL.Append(vbCrLf & "    AND FDECIMAL_POINT = :" & UBound(strBindField) - 1 & " --小数点以下有効桁数")
        End If
        If IsNull(FSEIHIN_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEIHIN_KUBUN
            strSQL.Append(vbCrLf & "    AND FSEIHIN_KUBUN = :" & UBound(strBindField) - 1 & " --製品区分")
        End If
        If IsNull(FZAIKO_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_KUBUN
            strSQL.Append(vbCrLf & "    AND FZAIKO_KUBUN = :" & UBound(strBindField) - 1 & " --在庫区分")
        End If
        If IsNull(FHORYU_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHORYU_KUBUN
            strSQL.Append(vbCrLf & "    AND FHORYU_KUBUN = :" & UBound(strBindField) - 1 & " --保留区分")
        End If
        If IsNull(FRECEIVEPAY_NUM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRECEIVEPAY_NUM
            strSQL.Append(vbCrLf & "    AND FRECEIVEPAY_NUM = :" & UBound(strBindField) - 1 & " --受払数量")
        End If
        If IsNull(FZAIKO_NUM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_NUM
            strSQL.Append(vbCrLf & "    AND FZAIKO_NUM = :" & UBound(strBindField) - 1 & " --在庫数量")
        End If
        If IsNull(FSAGYOU_CONTENT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_CONTENT
            strSQL.Append(vbCrLf & "    AND FSAGYOU_CONTENT = :" & UBound(strBindField) - 1 & " --作業内容")
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
        strDataSetName = "TEVD_STOCK_LOG"
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
    Public Function GET_TEVD_STOCK_LOG_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    TEVD_STOCK_LOG")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FLOG_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            strSQL.Append(vbCrLf & "    AND FLOG_NO = :" & UBound(strBindField) - 1 & " --ﾛｸﾞ№")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --登録日時")
        End If
        If IsNull(FPALLET_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄID")
        End If
        If IsNull(FTERM_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTERM_ID
            strSQL.Append(vbCrLf & "    AND FTERM_ID = :" & UBound(strBindField) - 1 & " --端末ID")
        End If
        If IsNull(FTERM_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTERM_NAME
            strSQL.Append(vbCrLf & "    AND FTERM_NAME = :" & UBound(strBindField) - 1 & " --端末名")
        End If
        If IsNull(FUSER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID
            strSQL.Append(vbCrLf & "    AND FUSER_ID = :" & UBound(strBindField) - 1 & " --ﾕｰｻﾞｰID")
        End If
        If IsNull(FUSER_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME
            strSQL.Append(vbCrLf & "    AND FUSER_NAME = :" & UBound(strBindField) - 1 & " --名前")
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
        If IsNull(FHINMEI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI
            strSQL.Append(vbCrLf & "    AND FHINMEI = :" & UBound(strBindField) - 1 & " --品名_正式名")
        End If
        If IsNull(FLOT_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO
            strSQL.Append(vbCrLf & "    AND FLOT_NO = :" & UBound(strBindField) - 1 & " --ﾛｯﾄ№")
        End If
        If IsNull(FSAGYOU_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_KIND
            strSQL.Append(vbCrLf & "    AND FSAGYOU_KIND = :" & UBound(strBindField) - 1 & " --作業種別")
        End If
        If IsNull(FNUM_IN_CASE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFNUM_IN_CASE
            strSQL.Append(vbCrLf & "    AND FNUM_IN_CASE = :" & UBound(strBindField) - 1 & " --正袋数量")
        End If
        If IsNull(FTANI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTANI
            strSQL.Append(vbCrLf & "    AND FTANI = :" & UBound(strBindField) - 1 & " --単位ｺｰﾄﾞ")
        End If
        If IsNull(FDECIMAL_POINT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDECIMAL_POINT
            strSQL.Append(vbCrLf & "    AND FDECIMAL_POINT = :" & UBound(strBindField) - 1 & " --小数点以下有効桁数")
        End If
        If IsNull(FSEIHIN_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEIHIN_KUBUN
            strSQL.Append(vbCrLf & "    AND FSEIHIN_KUBUN = :" & UBound(strBindField) - 1 & " --製品区分")
        End If
        If IsNull(FZAIKO_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_KUBUN
            strSQL.Append(vbCrLf & "    AND FZAIKO_KUBUN = :" & UBound(strBindField) - 1 & " --在庫区分")
        End If
        If IsNull(FHORYU_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHORYU_KUBUN
            strSQL.Append(vbCrLf & "    AND FHORYU_KUBUN = :" & UBound(strBindField) - 1 & " --保留区分")
        End If
        If IsNull(FRECEIVEPAY_NUM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRECEIVEPAY_NUM
            strSQL.Append(vbCrLf & "    AND FRECEIVEPAY_NUM = :" & UBound(strBindField) - 1 & " --受払数量")
        End If
        If IsNull(FZAIKO_NUM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_NUM
            strSQL.Append(vbCrLf & "    AND FZAIKO_NUM = :" & UBound(strBindField) - 1 & " --在庫数量")
        End If
        If IsNull(FSAGYOU_CONTENT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_CONTENT
            strSQL.Append(vbCrLf & "    AND FSAGYOU_CONTENT = :" & UBound(strBindField) - 1 & " --作業内容")
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
        strDataSetName = "TEVD_STOCK_LOG"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TEVD_STOCK_LOG(Owner, objDb, objDbLog)
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
    Public Function GET_TEVD_STOCK_LOG_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "TEVD_STOCK_LOG"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TEVD_STOCK_LOG(Owner, objDb, objDbLog)
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
    Public Function GET_TEVD_STOCK_LOG_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    TEVD_STOCK_LOG")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FLOG_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            strSQL.Append(vbCrLf & "    AND FLOG_NO = :" & UBound(strBindField) - 1 & " --ﾛｸﾞ№")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --登録日時")
        End If
        If IsNull(FPALLET_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄID")
        End If
        If IsNull(FTERM_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTERM_ID
            strSQL.Append(vbCrLf & "    AND FTERM_ID = :" & UBound(strBindField) - 1 & " --端末ID")
        End If
        If IsNull(FTERM_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTERM_NAME
            strSQL.Append(vbCrLf & "    AND FTERM_NAME = :" & UBound(strBindField) - 1 & " --端末名")
        End If
        If IsNull(FUSER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID
            strSQL.Append(vbCrLf & "    AND FUSER_ID = :" & UBound(strBindField) - 1 & " --ﾕｰｻﾞｰID")
        End If
        If IsNull(FUSER_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME
            strSQL.Append(vbCrLf & "    AND FUSER_NAME = :" & UBound(strBindField) - 1 & " --名前")
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
        If IsNull(FHINMEI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI
            strSQL.Append(vbCrLf & "    AND FHINMEI = :" & UBound(strBindField) - 1 & " --品名_正式名")
        End If
        If IsNull(FLOT_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO
            strSQL.Append(vbCrLf & "    AND FLOT_NO = :" & UBound(strBindField) - 1 & " --ﾛｯﾄ№")
        End If
        If IsNull(FSAGYOU_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_KIND
            strSQL.Append(vbCrLf & "    AND FSAGYOU_KIND = :" & UBound(strBindField) - 1 & " --作業種別")
        End If
        If IsNull(FNUM_IN_CASE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFNUM_IN_CASE
            strSQL.Append(vbCrLf & "    AND FNUM_IN_CASE = :" & UBound(strBindField) - 1 & " --正袋数量")
        End If
        If IsNull(FTANI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTANI
            strSQL.Append(vbCrLf & "    AND FTANI = :" & UBound(strBindField) - 1 & " --単位ｺｰﾄﾞ")
        End If
        If IsNull(FDECIMAL_POINT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDECIMAL_POINT
            strSQL.Append(vbCrLf & "    AND FDECIMAL_POINT = :" & UBound(strBindField) - 1 & " --小数点以下有効桁数")
        End If
        If IsNull(FSEIHIN_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEIHIN_KUBUN
            strSQL.Append(vbCrLf & "    AND FSEIHIN_KUBUN = :" & UBound(strBindField) - 1 & " --製品区分")
        End If
        If IsNull(FZAIKO_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_KUBUN
            strSQL.Append(vbCrLf & "    AND FZAIKO_KUBUN = :" & UBound(strBindField) - 1 & " --在庫区分")
        End If
        If IsNull(FHORYU_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHORYU_KUBUN
            strSQL.Append(vbCrLf & "    AND FHORYU_KUBUN = :" & UBound(strBindField) - 1 & " --保留区分")
        End If
        If IsNull(FRECEIVEPAY_NUM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRECEIVEPAY_NUM
            strSQL.Append(vbCrLf & "    AND FRECEIVEPAY_NUM = :" & UBound(strBindField) - 1 & " --受払数量")
        End If
        If IsNull(FZAIKO_NUM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_NUM
            strSQL.Append(vbCrLf & "    AND FZAIKO_NUM = :" & UBound(strBindField) - 1 & " --在庫数量")
        End If
        If IsNull(FSAGYOU_CONTENT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_CONTENT
            strSQL.Append(vbCrLf & "    AND FSAGYOU_CONTENT = :" & UBound(strBindField) - 1 & " --作業内容")
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
        strDataSetName = "TEVD_STOCK_LOG"
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
    Public Sub UPDATE_TEVD_STOCK_LOG()
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
        '更新SQL作成
        '***********************
        strBindField = Nothing
        objBindValue = Nothing
        ReDim Preserve strBindField(0)
        ReDim Preserve objBindValue(0)
        strSQL.Append(vbCrLf & "UPDATE")
        strSQL.Append(vbCrLf & "    TEVD_STOCK_LOG")
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
        If IsNull(mFTERM_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTERM_NAME = NULL --端末名")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTERM_NAME = NULL --端末名")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTERM_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTERM_NAME = :" & Ubound(strBindField) - 1 & " --端末名")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTERM_NAME = :" & Ubound(strBindField) - 1 & " --端末名")
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
        If IsNull(mFUSER_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUSER_NAME = NULL --名前")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUSER_NAME = NULL --名前")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUSER_NAME = :" & Ubound(strBindField) - 1 & " --名前")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUSER_NAME = :" & Ubound(strBindField) - 1 & " --名前")
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
        If IsNull(mFHINMEI) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHINMEI = NULL --品名_正式名")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHINMEI = NULL --品名_正式名")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHINMEI = :" & Ubound(strBindField) - 1 & " --品名_正式名")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHINMEI = :" & Ubound(strBindField) - 1 & " --品名_正式名")
        End If
        intCount = intCount + 1
        If IsNull(mFLOT_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOT_NO = NULL --ﾛｯﾄ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOT_NO = NULL --ﾛｯﾄ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOT_NO = :" & Ubound(strBindField) - 1 & " --ﾛｯﾄ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOT_NO = :" & Ubound(strBindField) - 1 & " --ﾛｯﾄ№")
        End If
        intCount = intCount + 1
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
        If IsNull(mFNUM_IN_CASE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FNUM_IN_CASE = NULL --正袋数量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FNUM_IN_CASE = NULL --正袋数量")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFNUM_IN_CASE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FNUM_IN_CASE = :" & Ubound(strBindField) - 1 & " --正袋数量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FNUM_IN_CASE = :" & Ubound(strBindField) - 1 & " --正袋数量")
        End If
        intCount = intCount + 1
        If IsNull(mFTANI) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTANI = NULL --単位ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTANI = NULL --単位ｺｰﾄﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTANI
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTANI = :" & Ubound(strBindField) - 1 & " --単位ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTANI = :" & Ubound(strBindField) - 1 & " --単位ｺｰﾄﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFDECIMAL_POINT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDECIMAL_POINT = NULL --小数点以下有効桁数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDECIMAL_POINT = NULL --小数点以下有効桁数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDECIMAL_POINT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDECIMAL_POINT = :" & Ubound(strBindField) - 1 & " --小数点以下有効桁数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDECIMAL_POINT = :" & Ubound(strBindField) - 1 & " --小数点以下有効桁数")
        End If
        intCount = intCount + 1
        If IsNull(mFSEIHIN_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSEIHIN_KUBUN = NULL --製品区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSEIHIN_KUBUN = NULL --製品区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEIHIN_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSEIHIN_KUBUN = :" & Ubound(strBindField) - 1 & " --製品区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSEIHIN_KUBUN = :" & Ubound(strBindField) - 1 & " --製品区分")
        End If
        intCount = intCount + 1
        If IsNull(mFZAIKO_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FZAIKO_KUBUN = NULL --在庫区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FZAIKO_KUBUN = NULL --在庫区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FZAIKO_KUBUN = :" & Ubound(strBindField) - 1 & " --在庫区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FZAIKO_KUBUN = :" & Ubound(strBindField) - 1 & " --在庫区分")
        End If
        intCount = intCount + 1
        If IsNull(mFHORYU_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHORYU_KUBUN = NULL --保留区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHORYU_KUBUN = NULL --保留区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHORYU_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHORYU_KUBUN = :" & Ubound(strBindField) - 1 & " --保留区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHORYU_KUBUN = :" & Ubound(strBindField) - 1 & " --保留区分")
        End If
        intCount = intCount + 1
        If IsNull(mFRECEIVEPAY_NUM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRECEIVEPAY_NUM = NULL --受払数量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRECEIVEPAY_NUM = NULL --受払数量")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRECEIVEPAY_NUM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRECEIVEPAY_NUM = :" & Ubound(strBindField) - 1 & " --受払数量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRECEIVEPAY_NUM = :" & Ubound(strBindField) - 1 & " --受払数量")
        End If
        intCount = intCount + 1
        If IsNull(mFZAIKO_NUM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FZAIKO_NUM = NULL --在庫数量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FZAIKO_NUM = NULL --在庫数量")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_NUM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FZAIKO_NUM = :" & Ubound(strBindField) - 1 & " --在庫数量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FZAIKO_NUM = :" & Ubound(strBindField) - 1 & " --在庫数量")
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
    Public Sub ADD_TEVD_STOCK_LOG()
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
        '追加SQL作成
        '***********************
        strBindField = Nothing
        objBindValue = Nothing
        ReDim Preserve strBindField(0)
        ReDim Preserve objBindValue(0)
        strSQL.Append(vbCrLf & "INSERT INTO")
        strSQL.Append(vbCrLf & "    TEVD_STOCK_LOG")
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
        If IsNull(mFTERM_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --端末名")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --端末名")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTERM_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --端末名")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --端末名")
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
        If IsNull(mFUSER_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --名前")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --名前")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --名前")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --名前")
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
        If IsNull(mFHINMEI) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --品名_正式名")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --品名_正式名")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --品名_正式名")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --品名_正式名")
        End If
        intCount = intCount + 1
        If IsNull(mFLOT_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾛｯﾄ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾛｯﾄ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾛｯﾄ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾛｯﾄ№")
        End If
        intCount = intCount + 1
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
        If IsNull(mFNUM_IN_CASE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --正袋数量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --正袋数量")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFNUM_IN_CASE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --正袋数量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --正袋数量")
        End If
        intCount = intCount + 1
        If IsNull(mFTANI) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --単位ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --単位ｺｰﾄﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTANI
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --単位ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --単位ｺｰﾄﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFDECIMAL_POINT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --小数点以下有効桁数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --小数点以下有効桁数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDECIMAL_POINT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --小数点以下有効桁数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --小数点以下有効桁数")
        End If
        intCount = intCount + 1
        If IsNull(mFSEIHIN_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --製品区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --製品区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEIHIN_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --製品区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --製品区分")
        End If
        intCount = intCount + 1
        If IsNull(mFZAIKO_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --在庫区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --在庫区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --在庫区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --在庫区分")
        End If
        intCount = intCount + 1
        If IsNull(mFHORYU_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --保留区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --保留区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHORYU_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --保留区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --保留区分")
        End If
        intCount = intCount + 1
        If IsNull(mFRECEIVEPAY_NUM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --受払数量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --受払数量")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRECEIVEPAY_NUM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --受払数量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --受払数量")
        End If
        intCount = intCount + 1
        If IsNull(mFZAIKO_NUM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --在庫数量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --在庫数量")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_NUM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --在庫数量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --在庫数量")
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
    Public Sub DELETE_TEVD_STOCK_LOG()
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
        strSQL.Append(vbCrLf & "    TEVD_STOCK_LOG")
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
    Public Sub DELETE_TEVD_STOCK_LOG_ANY()
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
        strSQL.Append(vbCrLf & "    TEVD_STOCK_LOG")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(FLOG_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            strSQL.Append(vbCrLf & "    AND FLOG_NO = :" & UBound(strBindField) - 1 & " --ﾛｸﾞ№")
        End If
        If IsNotNull(FENTRY_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --登録日時")
        End If
        If IsNotNull(FPALLET_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄID")
        End If
        If IsNotNull(FTERM_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTERM_ID
            strSQL.Append(vbCrLf & "    AND FTERM_ID = :" & UBound(strBindField) - 1 & " --端末ID")
        End If
        If IsNotNull(FTERM_NAME) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTERM_NAME
            strSQL.Append(vbCrLf & "    AND FTERM_NAME = :" & UBound(strBindField) - 1 & " --端末名")
        End If
        If IsNotNull(FUSER_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID
            strSQL.Append(vbCrLf & "    AND FUSER_ID = :" & UBound(strBindField) - 1 & " --ﾕｰｻﾞｰID")
        End If
        If IsNotNull(FUSER_NAME) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME
            strSQL.Append(vbCrLf & "    AND FUSER_NAME = :" & UBound(strBindField) - 1 & " --名前")
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
        If IsNotNull(FHINMEI) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI
            strSQL.Append(vbCrLf & "    AND FHINMEI = :" & UBound(strBindField) - 1 & " --品名_正式名")
        End If
        If IsNotNull(FLOT_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO
            strSQL.Append(vbCrLf & "    AND FLOT_NO = :" & UBound(strBindField) - 1 & " --ﾛｯﾄ№")
        End If
        If IsNotNull(FSAGYOU_KIND) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_KIND
            strSQL.Append(vbCrLf & "    AND FSAGYOU_KIND = :" & UBound(strBindField) - 1 & " --作業種別")
        End If
        If IsNotNull(FNUM_IN_CASE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFNUM_IN_CASE
            strSQL.Append(vbCrLf & "    AND FNUM_IN_CASE = :" & UBound(strBindField) - 1 & " --正袋数量")
        End If
        If IsNotNull(FTANI) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTANI
            strSQL.Append(vbCrLf & "    AND FTANI = :" & UBound(strBindField) - 1 & " --単位ｺｰﾄﾞ")
        End If
        If IsNotNull(FDECIMAL_POINT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDECIMAL_POINT
            strSQL.Append(vbCrLf & "    AND FDECIMAL_POINT = :" & UBound(strBindField) - 1 & " --小数点以下有効桁数")
        End If
        If IsNotNull(FSEIHIN_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSEIHIN_KUBUN
            strSQL.Append(vbCrLf & "    AND FSEIHIN_KUBUN = :" & UBound(strBindField) - 1 & " --製品区分")
        End If
        If IsNotNull(FZAIKO_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_KUBUN
            strSQL.Append(vbCrLf & "    AND FZAIKO_KUBUN = :" & UBound(strBindField) - 1 & " --在庫区分")
        End If
        If IsNotNull(FHORYU_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHORYU_KUBUN
            strSQL.Append(vbCrLf & "    AND FHORYU_KUBUN = :" & UBound(strBindField) - 1 & " --保留区分")
        End If
        If IsNotNull(FRECEIVEPAY_NUM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRECEIVEPAY_NUM
            strSQL.Append(vbCrLf & "    AND FRECEIVEPAY_NUM = :" & UBound(strBindField) - 1 & " --受払数量")
        End If
        If IsNotNull(FZAIKO_NUM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_NUM
            strSQL.Append(vbCrLf & "    AND FZAIKO_NUM = :" & UBound(strBindField) - 1 & " --在庫数量")
        End If
        If IsNotNull(FSAGYOU_CONTENT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_CONTENT
            strSQL.Append(vbCrLf & "    AND FSAGYOU_CONTENT = :" & UBound(strBindField) - 1 & " --作業内容")
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
        If IsNothing(objType.GetProperty("FENTRY_DT")) = False Then mFENTRY_DT = objObject.FENTRY_DT '登録日時
        If IsNothing(objType.GetProperty("FPALLET_ID")) = False Then mFPALLET_ID = objObject.FPALLET_ID 'ﾊﾟﾚｯﾄID
        If IsNothing(objType.GetProperty("FTERM_ID")) = False Then mFTERM_ID = objObject.FTERM_ID '端末ID
        If IsNothing(objType.GetProperty("FTERM_NAME")) = False Then mFTERM_NAME = objObject.FTERM_NAME '端末名
        If IsNothing(objType.GetProperty("FUSER_ID")) = False Then mFUSER_ID = objObject.FUSER_ID 'ﾕｰｻﾞｰID
        If IsNothing(objType.GetProperty("FUSER_NAME")) = False Then mFUSER_NAME = objObject.FUSER_NAME '名前
        If IsNothing(objType.GetProperty("FPLACE_CD")) = False Then mFPLACE_CD = objObject.FPLACE_CD '保管場所ｺｰﾄﾞ
        If IsNothing(objType.GetProperty("FAREA_CD")) = False Then mFAREA_CD = objObject.FAREA_CD 'ｴﾘｱｺｰﾄﾞ
        If IsNothing(objType.GetProperty("FHINMEI_CD")) = False Then mFHINMEI_CD = objObject.FHINMEI_CD '品目ｺｰﾄﾞ
        If IsNothing(objType.GetProperty("FHINMEI")) = False Then mFHINMEI = objObject.FHINMEI '品名_正式名
        If IsNothing(objType.GetProperty("FLOT_NO")) = False Then mFLOT_NO = objObject.FLOT_NO 'ﾛｯﾄ№
        If IsNothing(objType.GetProperty("FSAGYOU_KIND")) = False Then mFSAGYOU_KIND = objObject.FSAGYOU_KIND '作業種別
        If IsNothing(objType.GetProperty("FNUM_IN_CASE")) = False Then mFNUM_IN_CASE = objObject.FNUM_IN_CASE '正袋数量
        If IsNothing(objType.GetProperty("FTANI")) = False Then mFTANI = objObject.FTANI '単位ｺｰﾄﾞ
        If IsNothing(objType.GetProperty("FDECIMAL_POINT")) = False Then mFDECIMAL_POINT = objObject.FDECIMAL_POINT '小数点以下有効桁数
        If IsNothing(objType.GetProperty("FSEIHIN_KUBUN")) = False Then mFSEIHIN_KUBUN = objObject.FSEIHIN_KUBUN '製品区分
        If IsNothing(objType.GetProperty("FZAIKO_KUBUN")) = False Then mFZAIKO_KUBUN = objObject.FZAIKO_KUBUN '在庫区分
        If IsNothing(objType.GetProperty("FHORYU_KUBUN")) = False Then mFHORYU_KUBUN = objObject.FHORYU_KUBUN '保留区分
        If IsNothing(objType.GetProperty("FRECEIVEPAY_NUM")) = False Then mFRECEIVEPAY_NUM = objObject.FRECEIVEPAY_NUM '受払数量
        If IsNothing(objType.GetProperty("FZAIKO_NUM")) = False Then mFZAIKO_NUM = objObject.FZAIKO_NUM '在庫数量
        If IsNothing(objType.GetProperty("FSAGYOU_CONTENT")) = False Then mFSAGYOU_CONTENT = objObject.FSAGYOU_CONTENT '作業内容

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
        mFENTRY_DT = Nothing
        mFPALLET_ID = Nothing
        mFTERM_ID = Nothing
        mFTERM_NAME = Nothing
        mFUSER_ID = Nothing
        mFUSER_NAME = Nothing
        mFPLACE_CD = Nothing
        mFAREA_CD = Nothing
        mFHINMEI_CD = Nothing
        mFHINMEI = Nothing
        mFLOT_NO = Nothing
        mFSAGYOU_KIND = Nothing
        mFNUM_IN_CASE = Nothing
        mFTANI = Nothing
        mFDECIMAL_POINT = Nothing
        mFSEIHIN_KUBUN = Nothing
        mFZAIKO_KUBUN = Nothing
        mFHORYU_KUBUN = Nothing
        mFRECEIVEPAY_NUM = Nothing
        mFZAIKO_NUM = Nothing
        mFSAGYOU_CONTENT = Nothing


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
        mFENTRY_DT = TO_DATE_NULLABLE(objRow("FENTRY_DT"))
        mFPALLET_ID = TO_STRING_NULLABLE(objRow("FPALLET_ID"))
        mFTERM_ID = TO_STRING_NULLABLE(objRow("FTERM_ID"))
        mFTERM_NAME = TO_STRING_NULLABLE(objRow("FTERM_NAME"))
        mFUSER_ID = TO_STRING_NULLABLE(objRow("FUSER_ID"))
        mFUSER_NAME = TO_STRING_NULLABLE(objRow("FUSER_NAME"))
        mFPLACE_CD = TO_INTEGER_NULLABLE(objRow("FPLACE_CD"))
        mFAREA_CD = TO_INTEGER_NULLABLE(objRow("FAREA_CD"))
        mFHINMEI_CD = TO_STRING_NULLABLE(objRow("FHINMEI_CD"))
        mFHINMEI = TO_STRING_NULLABLE(objRow("FHINMEI"))
        mFLOT_NO = TO_STRING_NULLABLE(objRow("FLOT_NO"))
        mFSAGYOU_KIND = TO_INTEGER_NULLABLE(objRow("FSAGYOU_KIND"))
        mFNUM_IN_CASE = TO_DECIMAL_NULLABLE(objRow("FNUM_IN_CASE"))
        mFTANI = TO_STRING_NULLABLE(objRow("FTANI"))
        mFDECIMAL_POINT = TO_INTEGER_NULLABLE(objRow("FDECIMAL_POINT"))
        mFSEIHIN_KUBUN = TO_INTEGER_NULLABLE(objRow("FSEIHIN_KUBUN"))
        mFZAIKO_KUBUN = TO_INTEGER_NULLABLE(objRow("FZAIKO_KUBUN"))
        mFHORYU_KUBUN = TO_INTEGER_NULLABLE(objRow("FHORYU_KUBUN"))
        mFRECEIVEPAY_NUM = TO_DECIMAL_NULLABLE(objRow("FRECEIVEPAY_NUM"))
        mFZAIKO_NUM = TO_DECIMAL_NULLABLE(objRow("FZAIKO_NUM"))
        mFSAGYOU_CONTENT = TO_STRING_NULLABLE(objRow("FSAGYOU_CONTENT"))


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
        strMsg &= "[ﾃｰﾌﾞﾙ名:在庫更新履歴]"
        If IsNotNull(FLOG_NO) Then
            strMsg &= "[ﾛｸﾞ№:" & FLOG_NO & "]"
        End If
        If IsNotNull(FENTRY_DT) Then
            strMsg &= "[登録日時:" & FENTRY_DT & "]"
        End If
        If IsNotNull(FPALLET_ID) Then
            strMsg &= "[ﾊﾟﾚｯﾄID:" & FPALLET_ID & "]"
        End If
        If IsNotNull(FTERM_ID) Then
            strMsg &= "[端末ID:" & FTERM_ID & "]"
        End If
        If IsNotNull(FTERM_NAME) Then
            strMsg &= "[端末名:" & FTERM_NAME & "]"
        End If
        If IsNotNull(FUSER_ID) Then
            strMsg &= "[ﾕｰｻﾞｰID:" & FUSER_ID & "]"
        End If
        If IsNotNull(FUSER_NAME) Then
            strMsg &= "[名前:" & FUSER_NAME & "]"
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
        If IsNotNull(FHINMEI) Then
            strMsg &= "[品名_正式名:" & FHINMEI & "]"
        End If
        If IsNotNull(FLOT_NO) Then
            strMsg &= "[ﾛｯﾄ№:" & FLOT_NO & "]"
        End If
        If IsNotNull(FSAGYOU_KIND) Then
            strMsg &= "[作業種別:" & FSAGYOU_KIND & "]"
        End If
        If IsNotNull(FNUM_IN_CASE) Then
            strMsg &= "[正袋数量:" & FNUM_IN_CASE & "]"
        End If
        If IsNotNull(FTANI) Then
            strMsg &= "[単位ｺｰﾄﾞ:" & FTANI & "]"
        End If
        If IsNotNull(FDECIMAL_POINT) Then
            strMsg &= "[小数点以下有効桁数:" & FDECIMAL_POINT & "]"
        End If
        If IsNotNull(FSEIHIN_KUBUN) Then
            strMsg &= "[製品区分:" & FSEIHIN_KUBUN & "]"
        End If
        If IsNotNull(FZAIKO_KUBUN) Then
            strMsg &= "[在庫区分:" & FZAIKO_KUBUN & "]"
        End If
        If IsNotNull(FHORYU_KUBUN) Then
            strMsg &= "[保留区分:" & FHORYU_KUBUN & "]"
        End If
        If IsNotNull(FRECEIVEPAY_NUM) Then
            strMsg &= "[受払数量:" & FRECEIVEPAY_NUM & "]"
        End If
        If IsNotNull(FZAIKO_NUM) Then
            strMsg &= "[在庫数量:" & FZAIKO_NUM & "]"
        End If
        If IsNotNull(FSAGYOU_CONTENT) Then
            strMsg &= "[作業内容:" & FSAGYOU_CONTENT & "]"
        End If


    End Sub
#End Region
    '↑↑↑自動生成部
    '**********************************************************************************************

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ共通
#Region "  在庫更新履歴追加   [SEQ発番]             (Public  ADD_TEVD_STOCK_LOG_SEQ)"
    Public Sub ADD_TEVD_STOCK_LOG_SEQ()
        Try


            '***********************
            'ﾛｸﾞ№の特定
            '***********************
            Dim objTPRG_SEQNO As New TBL_TPRG_SEQNO(Owner, ObjDb, ObjDbLog) 'ｼｰｹﾝｽ№ｸﾗｽ
            objTPRG_SEQNO.FSEQ_ID = FSEQ_ID_SSVRLOG_NO_STOCK_LOG             'ｼｰｹﾝｽID
            mFLOG_NO = objTPRG_SEQNO.GET_ENTRY_NO()                         'SEQ№の特定


            '***********************
            '追加
            '***********************
            Me.ADD_TEVD_STOCK_LOG()


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
