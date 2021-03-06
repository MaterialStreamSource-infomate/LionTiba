'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' 【名称】MaterialStreamﾃｰﾌﾞﾙｸﾗｽ
' 【機能】在庫情報ﾃｰﾌﾞﾙｸﾗｽ
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
''' 在庫情報ﾃｰﾌﾞﾙｸﾗｽ
''' </summary>
Public Class TBL_TRST_STOCK
    Inherits clsTemplateTable

    '**********************************************************************************************
    '↓↓↓自動生成部
#Region "  ｸﾗｽ変数定義                  "
    'ﾌﾟﾛﾊﾟﾃｨ
    Private mobjAryMe As TBL_TRST_STOCK()                                        '在庫情報
    Private mstrUSER_SQL As String                                               'ﾕｰｻﾞｰSQL
    Private mORDER_BY As String                                                  'OrderBy句
    Private mWHERE As String                                                     'Where句
    Private mFPALLET_ID As String                                                'ﾊﾟﾚｯﾄID
    Private mFLOT_NO_STOCK As String                                             '在庫ﾛｯﾄ��
    Private mFHINMEI_CD As String                                                '品目ｺｰﾄﾞ
    Private mFLOT_NO As String                                                   'ﾛｯﾄ��
    Private mFARRIVE_DT As Nullable(Of Date)                                     '在庫発生日時
    Private mFIN_KUBUN As Nullable(Of Integer)                                   '入庫区分
    Private mFSEIHIN_KUBUN As Nullable(Of Integer)                               '製品区分
    Private mFZAIKO_KUBUN As Nullable(Of Integer)                                '在庫区分
    Private mFHORYU_KUBUN As Nullable(Of Integer)                                '保留区分
    Private mFST_FM As Nullable(Of Integer)                                      '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ��
    Private mFTR_VOL As Nullable(Of Decimal)                                     '搬送管理量
    Private mFTR_RES_VOL As Nullable(Of Decimal)                                 '搬送引当量
    Private mFUPDATE_DT As Nullable(Of Date)                                     '更新日時
    Private mFHASU_FLAG As Nullable(Of Integer)                                  '端数ﾌﾗｸﾞ
    Private mFLABEL_ID As String                                                 'ﾗﾍﾞﾙID
    Private mFSYUKKA_TO_CD As String                                             '出荷先ｺｰﾄﾞ
    Private mFSYUKKA_TO_NAME As String                                           '出荷先名称
    Private mXPROD_LINE As String                                                '生産ﾗｲﾝ��
    Private mXKENSA_KUBUN As String                                              '検査区分
    Private mXKENPIN_KUBUN As String                                             '検品区分
    Private mXMAKER_CD As String                                                 'ﾒｰｶ-ｺｰﾄﾞ
    Private mXRAC_IN_DT As Nullable(Of Date)                                     '入庫日時
    Private mXTRK_BUF_NO_IN As Nullable(Of Integer)                              '入庫ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ��
    Private mXTRK_BUF_ARRAY_IN As Nullable(Of Integer)                           '入庫ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列��
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                  "
    ''' <summary>
    ''' ｼｽﾃﾑ変数 (自ｸﾗｽ型配列)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_TRST_STOCK()
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
    ''' 在庫ﾛｯﾄ��
    ''' </summary>
    Public Property FLOT_NO_STOCK() As String
        Get
            Return mFLOT_NO_STOCK
        End Get
        Set(ByVal Value As String)
            mFLOT_NO_STOCK = Value
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
    ''' ﾛｯﾄ��
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
    ''' 在庫発生日時
    ''' </summary>
    Public Property FARRIVE_DT() As Nullable(Of Date)
        Get
            Return mFARRIVE_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mFARRIVE_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' 入庫区分
    ''' </summary>
    Public Property FIN_KUBUN() As Nullable(Of Integer)
        Get
            Return mFIN_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFIN_KUBUN = Value
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
    ''' 搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ��
    ''' </summary>
    Public Property FST_FM() As Nullable(Of Integer)
        Get
            Return mFST_FM
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFST_FM = Value
        End Set
    End Property
    ''' <summary>
    ''' 搬送管理量
    ''' </summary>
    Public Property FTR_VOL() As Nullable(Of Decimal)
        Get
            Return mFTR_VOL
        End Get
        Set(ByVal Value As Nullable(Of Decimal))
            mFTR_VOL = Value
        End Set
    End Property
    ''' <summary>
    ''' 搬送引当量
    ''' </summary>
    Public Property FTR_RES_VOL() As Nullable(Of Decimal)
        Get
            Return mFTR_RES_VOL
        End Get
        Set(ByVal Value As Nullable(Of Decimal))
            mFTR_RES_VOL = Value
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
    ''' 端数ﾌﾗｸﾞ
    ''' </summary>
    Public Property FHASU_FLAG() As Nullable(Of Integer)
        Get
            Return mFHASU_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFHASU_FLAG = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾗﾍﾞﾙID
    ''' </summary>
    Public Property FLABEL_ID() As String
        Get
            Return mFLABEL_ID
        End Get
        Set(ByVal Value As String)
            mFLABEL_ID = Value
        End Set
    End Property
    ''' <summary>
    ''' 出荷先ｺｰﾄﾞ
    ''' </summary>
    Public Property FSYUKKA_TO_CD() As String
        Get
            Return mFSYUKKA_TO_CD
        End Get
        Set(ByVal Value As String)
            mFSYUKKA_TO_CD = Value
        End Set
    End Property
    ''' <summary>
    ''' 出荷先名称
    ''' </summary>
    Public Property FSYUKKA_TO_NAME() As String
        Get
            Return mFSYUKKA_TO_NAME
        End Get
        Set(ByVal Value As String)
            mFSYUKKA_TO_NAME = Value
        End Set
    End Property
    ''' <summary>
    ''' 生産ﾗｲﾝ��
    ''' </summary>
    Public Property XPROD_LINE() As String
        Get
            Return mXPROD_LINE
        End Get
        Set(ByVal Value As String)
            mXPROD_LINE = Value
        End Set
    End Property
    ''' <summary>
    ''' 検査区分
    ''' </summary>
    Public Property XKENSA_KUBUN() As String
        Get
            Return mXKENSA_KUBUN
        End Get
        Set(ByVal Value As String)
            mXKENSA_KUBUN = Value
        End Set
    End Property
    ''' <summary>
    ''' 検品区分
    ''' </summary>
    Public Property XKENPIN_KUBUN() As String
        Get
            Return mXKENPIN_KUBUN
        End Get
        Set(ByVal Value As String)
            mXKENPIN_KUBUN = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾒｰｶ-ｺｰﾄﾞ
    ''' </summary>
    Public Property XMAKER_CD() As String
        Get
            Return mXMAKER_CD
        End Get
        Set(ByVal Value As String)
            mXMAKER_CD = Value
        End Set
    End Property
    ''' <summary>
    ''' 入庫日時
    ''' </summary>
    Public Property XRAC_IN_DT() As Nullable(Of Date)
        Get
            Return mXRAC_IN_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mXRAC_IN_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' 入庫ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ��
    ''' </summary>
    Public Property XTRK_BUF_NO_IN() As Nullable(Of Integer)
        Get
            Return mXTRK_BUF_NO_IN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXTRK_BUF_NO_IN = Value
        End Set
    End Property
    ''' <summary>
    ''' 入庫ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列��
    ''' </summary>
    Public Property XTRK_BUF_ARRAY_IN() As Nullable(Of Integer)
        Get
            Return mXTRK_BUF_ARRAY_IN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXTRK_BUF_ARRAY_IN = Value
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
    Public Function GET_TRST_STOCK(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    TRST_STOCK")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FPALLET_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄID")
        End If
        If IsNull(FLOT_NO_STOCK) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO_STOCK
            strSQL.Append(vbCrLf & "    AND FLOT_NO_STOCK = :" & UBound(strBindField) - 1 & " --在庫ﾛｯﾄ��")
        End If
        If IsNull(FHINMEI_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --品目ｺｰﾄﾞ")
        End If
        If IsNull(FLOT_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO
            strSQL.Append(vbCrLf & "    AND FLOT_NO = :" & UBound(strBindField) - 1 & " --ﾛｯﾄ��")
        End If
        If IsNull(FARRIVE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFARRIVE_DT
            strSQL.Append(vbCrLf & "    AND FARRIVE_DT = :" & UBound(strBindField) - 1 & " --在庫発生日時")
        End If
        If IsNull(FIN_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFIN_KUBUN
            strSQL.Append(vbCrLf & "    AND FIN_KUBUN = :" & UBound(strBindField) - 1 & " --入庫区分")
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
        If IsNull(FST_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFST_FM
            strSQL.Append(vbCrLf & "    AND FST_FM = :" & UBound(strBindField) - 1 & " --搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ��")
        End If
        If IsNull(FTR_VOL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_VOL
            strSQL.Append(vbCrLf & "    AND FTR_VOL = :" & UBound(strBindField) - 1 & " --搬送管理量")
        End If
        If IsNull(FTR_RES_VOL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_RES_VOL
            strSQL.Append(vbCrLf & "    AND FTR_RES_VOL = :" & UBound(strBindField) - 1 & " --搬送引当量")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --更新日時")
        End If
        If IsNull(FHASU_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHASU_FLAG
            strSQL.Append(vbCrLf & "    AND FHASU_FLAG = :" & UBound(strBindField) - 1 & " --端数ﾌﾗｸﾞ")
        End If
        If IsNull(FLABEL_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLABEL_ID
            strSQL.Append(vbCrLf & "    AND FLABEL_ID = :" & UBound(strBindField) - 1 & " --ﾗﾍﾞﾙID")
        End If
        If IsNull(FSYUKKA_TO_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYUKKA_TO_CD
            strSQL.Append(vbCrLf & "    AND FSYUKKA_TO_CD = :" & UBound(strBindField) - 1 & " --出荷先ｺｰﾄﾞ")
        End If
        If IsNull(FSYUKKA_TO_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYUKKA_TO_NAME
            strSQL.Append(vbCrLf & "    AND FSYUKKA_TO_NAME = :" & UBound(strBindField) - 1 & " --出荷先名称")
        End If
        If IsNull(XPROD_LINE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPROD_LINE
            strSQL.Append(vbCrLf & "    AND XPROD_LINE = :" & UBound(strBindField) - 1 & " --生産ﾗｲﾝ��")
        End If
        If IsNull(XKENSA_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKENSA_KUBUN
            strSQL.Append(vbCrLf & "    AND XKENSA_KUBUN = :" & UBound(strBindField) - 1 & " --検査区分")
        End If
        If IsNull(XKENPIN_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKENPIN_KUBUN
            strSQL.Append(vbCrLf & "    AND XKENPIN_KUBUN = :" & UBound(strBindField) - 1 & " --検品区分")
        End If
        If IsNull(XMAKER_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAKER_CD
            strSQL.Append(vbCrLf & "    AND XMAKER_CD = :" & UBound(strBindField) - 1 & " --ﾒｰｶ-ｺｰﾄﾞ")
        End If
        If IsNull(XRAC_IN_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXRAC_IN_DT
            strSQL.Append(vbCrLf & "    AND XRAC_IN_DT = :" & UBound(strBindField) - 1 & " --入庫日時")
        End If
        If IsNull(XTRK_BUF_NO_IN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_IN
            strSQL.Append(vbCrLf & "    AND XTRK_BUF_NO_IN = :" & UBound(strBindField) - 1 & " --入庫ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ��")
        End If
        If IsNull(XTRK_BUF_ARRAY_IN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_ARRAY_IN
            strSQL.Append(vbCrLf & "    AND XTRK_BUF_ARRAY_IN = :" & UBound(strBindField) - 1 & " --入庫ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列��")
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
        strDataSetName = "TRST_STOCK"
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
    Public Function GET_TRST_STOCK_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    TRST_STOCK")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FPALLET_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄID")
        End If
        If IsNull(FLOT_NO_STOCK) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO_STOCK
            strSQL.Append(vbCrLf & "    AND FLOT_NO_STOCK = :" & UBound(strBindField) - 1 & " --在庫ﾛｯﾄ��")
        End If
        If IsNull(FHINMEI_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --品目ｺｰﾄﾞ")
        End If
        If IsNull(FLOT_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO
            strSQL.Append(vbCrLf & "    AND FLOT_NO = :" & UBound(strBindField) - 1 & " --ﾛｯﾄ��")
        End If
        If IsNull(FARRIVE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFARRIVE_DT
            strSQL.Append(vbCrLf & "    AND FARRIVE_DT = :" & UBound(strBindField) - 1 & " --在庫発生日時")
        End If
        If IsNull(FIN_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFIN_KUBUN
            strSQL.Append(vbCrLf & "    AND FIN_KUBUN = :" & UBound(strBindField) - 1 & " --入庫区分")
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
        If IsNull(FST_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFST_FM
            strSQL.Append(vbCrLf & "    AND FST_FM = :" & UBound(strBindField) - 1 & " --搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ��")
        End If
        If IsNull(FTR_VOL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_VOL
            strSQL.Append(vbCrLf & "    AND FTR_VOL = :" & UBound(strBindField) - 1 & " --搬送管理量")
        End If
        If IsNull(FTR_RES_VOL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_RES_VOL
            strSQL.Append(vbCrLf & "    AND FTR_RES_VOL = :" & UBound(strBindField) - 1 & " --搬送引当量")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --更新日時")
        End If
        If IsNull(FHASU_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHASU_FLAG
            strSQL.Append(vbCrLf & "    AND FHASU_FLAG = :" & UBound(strBindField) - 1 & " --端数ﾌﾗｸﾞ")
        End If
        If IsNull(FLABEL_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLABEL_ID
            strSQL.Append(vbCrLf & "    AND FLABEL_ID = :" & UBound(strBindField) - 1 & " --ﾗﾍﾞﾙID")
        End If
        If IsNull(FSYUKKA_TO_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYUKKA_TO_CD
            strSQL.Append(vbCrLf & "    AND FSYUKKA_TO_CD = :" & UBound(strBindField) - 1 & " --出荷先ｺｰﾄﾞ")
        End If
        If IsNull(FSYUKKA_TO_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYUKKA_TO_NAME
            strSQL.Append(vbCrLf & "    AND FSYUKKA_TO_NAME = :" & UBound(strBindField) - 1 & " --出荷先名称")
        End If
        If IsNull(XPROD_LINE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPROD_LINE
            strSQL.Append(vbCrLf & "    AND XPROD_LINE = :" & UBound(strBindField) - 1 & " --生産ﾗｲﾝ��")
        End If
        If IsNull(XKENSA_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKENSA_KUBUN
            strSQL.Append(vbCrLf & "    AND XKENSA_KUBUN = :" & UBound(strBindField) - 1 & " --検査区分")
        End If
        If IsNull(XKENPIN_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKENPIN_KUBUN
            strSQL.Append(vbCrLf & "    AND XKENPIN_KUBUN = :" & UBound(strBindField) - 1 & " --検品区分")
        End If
        If IsNull(XMAKER_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAKER_CD
            strSQL.Append(vbCrLf & "    AND XMAKER_CD = :" & UBound(strBindField) - 1 & " --ﾒｰｶ-ｺｰﾄﾞ")
        End If
        If IsNull(XRAC_IN_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXRAC_IN_DT
            strSQL.Append(vbCrLf & "    AND XRAC_IN_DT = :" & UBound(strBindField) - 1 & " --入庫日時")
        End If
        If IsNull(XTRK_BUF_NO_IN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_IN
            strSQL.Append(vbCrLf & "    AND XTRK_BUF_NO_IN = :" & UBound(strBindField) - 1 & " --入庫ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ��")
        End If
        If IsNull(XTRK_BUF_ARRAY_IN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_ARRAY_IN
            strSQL.Append(vbCrLf & "    AND XTRK_BUF_ARRAY_IN = :" & UBound(strBindField) - 1 & " --入庫ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列��")
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
        strDataSetName = "TRST_STOCK"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TRST_STOCK(Owner, objDb, objDbLog)
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
    Public Function GET_TRST_STOCK_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "TRST_STOCK"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TRST_STOCK(Owner, objDb, objDbLog)
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
    Public Function GET_TRST_STOCK_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    TRST_STOCK")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FPALLET_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄID")
        End If
        If IsNull(FLOT_NO_STOCK) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO_STOCK
            strSQL.Append(vbCrLf & "    AND FLOT_NO_STOCK = :" & UBound(strBindField) - 1 & " --在庫ﾛｯﾄ��")
        End If
        If IsNull(FHINMEI_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --品目ｺｰﾄﾞ")
        End If
        If IsNull(FLOT_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO
            strSQL.Append(vbCrLf & "    AND FLOT_NO = :" & UBound(strBindField) - 1 & " --ﾛｯﾄ��")
        End If
        If IsNull(FARRIVE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFARRIVE_DT
            strSQL.Append(vbCrLf & "    AND FARRIVE_DT = :" & UBound(strBindField) - 1 & " --在庫発生日時")
        End If
        If IsNull(FIN_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFIN_KUBUN
            strSQL.Append(vbCrLf & "    AND FIN_KUBUN = :" & UBound(strBindField) - 1 & " --入庫区分")
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
        If IsNull(FST_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFST_FM
            strSQL.Append(vbCrLf & "    AND FST_FM = :" & UBound(strBindField) - 1 & " --搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ��")
        End If
        If IsNull(FTR_VOL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_VOL
            strSQL.Append(vbCrLf & "    AND FTR_VOL = :" & UBound(strBindField) - 1 & " --搬送管理量")
        End If
        If IsNull(FTR_RES_VOL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_RES_VOL
            strSQL.Append(vbCrLf & "    AND FTR_RES_VOL = :" & UBound(strBindField) - 1 & " --搬送引当量")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --更新日時")
        End If
        If IsNull(FHASU_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHASU_FLAG
            strSQL.Append(vbCrLf & "    AND FHASU_FLAG = :" & UBound(strBindField) - 1 & " --端数ﾌﾗｸﾞ")
        End If
        If IsNull(FLABEL_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLABEL_ID
            strSQL.Append(vbCrLf & "    AND FLABEL_ID = :" & UBound(strBindField) - 1 & " --ﾗﾍﾞﾙID")
        End If
        If IsNull(FSYUKKA_TO_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYUKKA_TO_CD
            strSQL.Append(vbCrLf & "    AND FSYUKKA_TO_CD = :" & UBound(strBindField) - 1 & " --出荷先ｺｰﾄﾞ")
        End If
        If IsNull(FSYUKKA_TO_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYUKKA_TO_NAME
            strSQL.Append(vbCrLf & "    AND FSYUKKA_TO_NAME = :" & UBound(strBindField) - 1 & " --出荷先名称")
        End If
        If IsNull(XPROD_LINE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPROD_LINE
            strSQL.Append(vbCrLf & "    AND XPROD_LINE = :" & UBound(strBindField) - 1 & " --生産ﾗｲﾝ��")
        End If
        If IsNull(XKENSA_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKENSA_KUBUN
            strSQL.Append(vbCrLf & "    AND XKENSA_KUBUN = :" & UBound(strBindField) - 1 & " --検査区分")
        End If
        If IsNull(XKENPIN_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKENPIN_KUBUN
            strSQL.Append(vbCrLf & "    AND XKENPIN_KUBUN = :" & UBound(strBindField) - 1 & " --検品区分")
        End If
        If IsNull(XMAKER_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAKER_CD
            strSQL.Append(vbCrLf & "    AND XMAKER_CD = :" & UBound(strBindField) - 1 & " --ﾒｰｶ-ｺｰﾄﾞ")
        End If
        If IsNull(XRAC_IN_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXRAC_IN_DT
            strSQL.Append(vbCrLf & "    AND XRAC_IN_DT = :" & UBound(strBindField) - 1 & " --入庫日時")
        End If
        If IsNull(XTRK_BUF_NO_IN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_IN
            strSQL.Append(vbCrLf & "    AND XTRK_BUF_NO_IN = :" & UBound(strBindField) - 1 & " --入庫ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ��")
        End If
        If IsNull(XTRK_BUF_ARRAY_IN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_ARRAY_IN
            strSQL.Append(vbCrLf & "    AND XTRK_BUF_ARRAY_IN = :" & UBound(strBindField) - 1 & " --入庫ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列��")
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
        strDataSetName = "TRST_STOCK"
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
    Public Sub UPDATE_TRST_STOCK()
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
        ElseIf IsNull(mFPALLET_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾊﾟﾚｯﾄID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFLOT_NO_STOCK) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[在庫ﾛｯﾄ��]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFARRIVE_DT) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[在庫発生日時]"
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
        strSQL.Append(vbCrLf & "    TRST_STOCK")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
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
        If IsNull(mFLOT_NO_STOCK) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOT_NO_STOCK = NULL --在庫ﾛｯﾄ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOT_NO_STOCK = NULL --在庫ﾛｯﾄ��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO_STOCK
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOT_NO_STOCK = :" & Ubound(strBindField) - 1 & " --在庫ﾛｯﾄ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOT_NO_STOCK = :" & Ubound(strBindField) - 1 & " --在庫ﾛｯﾄ��")
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
        If IsNull(mFLOT_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOT_NO = NULL --ﾛｯﾄ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOT_NO = NULL --ﾛｯﾄ��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOT_NO = :" & Ubound(strBindField) - 1 & " --ﾛｯﾄ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOT_NO = :" & Ubound(strBindField) - 1 & " --ﾛｯﾄ��")
        End If
        intCount = intCount + 1
        If IsNull(mFARRIVE_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FARRIVE_DT = NULL --在庫発生日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FARRIVE_DT = NULL --在庫発生日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFARRIVE_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FARRIVE_DT = :" & Ubound(strBindField) - 1 & " --在庫発生日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FARRIVE_DT = :" & Ubound(strBindField) - 1 & " --在庫発生日時")
        End If
        intCount = intCount + 1
        If IsNull(mFIN_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FIN_KUBUN = NULL --入庫区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FIN_KUBUN = NULL --入庫区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFIN_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FIN_KUBUN = :" & Ubound(strBindField) - 1 & " --入庫区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FIN_KUBUN = :" & Ubound(strBindField) - 1 & " --入庫区分")
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
        If IsNull(mFST_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FST_FM = NULL --搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FST_FM = NULL --搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFST_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FST_FM = :" & Ubound(strBindField) - 1 & " --搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FST_FM = :" & Ubound(strBindField) - 1 & " --搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ��")
        End If
        intCount = intCount + 1
        If IsNull(mFTR_VOL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTR_VOL = NULL --搬送管理量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTR_VOL = NULL --搬送管理量")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_VOL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTR_VOL = :" & Ubound(strBindField) - 1 & " --搬送管理量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTR_VOL = :" & Ubound(strBindField) - 1 & " --搬送管理量")
        End If
        intCount = intCount + 1
        If IsNull(mFTR_RES_VOL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTR_RES_VOL = NULL --搬送引当量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTR_RES_VOL = NULL --搬送引当量")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_RES_VOL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTR_RES_VOL = :" & Ubound(strBindField) - 1 & " --搬送引当量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTR_RES_VOL = :" & Ubound(strBindField) - 1 & " --搬送引当量")
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
        If IsNull(mFHASU_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHASU_FLAG = NULL --端数ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHASU_FLAG = NULL --端数ﾌﾗｸﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHASU_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHASU_FLAG = :" & Ubound(strBindField) - 1 & " --端数ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHASU_FLAG = :" & Ubound(strBindField) - 1 & " --端数ﾌﾗｸﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFLABEL_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLABEL_ID = NULL --ﾗﾍﾞﾙID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLABEL_ID = NULL --ﾗﾍﾞﾙID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLABEL_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLABEL_ID = :" & Ubound(strBindField) - 1 & " --ﾗﾍﾞﾙID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLABEL_ID = :" & Ubound(strBindField) - 1 & " --ﾗﾍﾞﾙID")
        End If
        intCount = intCount + 1
        If IsNull(mFSYUKKA_TO_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSYUKKA_TO_CD = NULL --出荷先ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSYUKKA_TO_CD = NULL --出荷先ｺｰﾄﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYUKKA_TO_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSYUKKA_TO_CD = :" & Ubound(strBindField) - 1 & " --出荷先ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSYUKKA_TO_CD = :" & Ubound(strBindField) - 1 & " --出荷先ｺｰﾄﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFSYUKKA_TO_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSYUKKA_TO_NAME = NULL --出荷先名称")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSYUKKA_TO_NAME = NULL --出荷先名称")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYUKKA_TO_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSYUKKA_TO_NAME = :" & Ubound(strBindField) - 1 & " --出荷先名称")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSYUKKA_TO_NAME = :" & Ubound(strBindField) - 1 & " --出荷先名称")
        End If
        intCount = intCount + 1
        If IsNull(mXPROD_LINE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XPROD_LINE = NULL --生産ﾗｲﾝ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XPROD_LINE = NULL --生産ﾗｲﾝ��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPROD_LINE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XPROD_LINE = :" & Ubound(strBindField) - 1 & " --生産ﾗｲﾝ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XPROD_LINE = :" & Ubound(strBindField) - 1 & " --生産ﾗｲﾝ��")
        End If
        intCount = intCount + 1
        If IsNull(mXKENSA_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XKENSA_KUBUN = NULL --検査区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XKENSA_KUBUN = NULL --検査区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKENSA_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XKENSA_KUBUN = :" & Ubound(strBindField) - 1 & " --検査区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XKENSA_KUBUN = :" & Ubound(strBindField) - 1 & " --検査区分")
        End If
        intCount = intCount + 1
        If IsNull(mXKENPIN_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XKENPIN_KUBUN = NULL --検品区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XKENPIN_KUBUN = NULL --検品区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKENPIN_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XKENPIN_KUBUN = :" & Ubound(strBindField) - 1 & " --検品区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XKENPIN_KUBUN = :" & Ubound(strBindField) - 1 & " --検品区分")
        End If
        intCount = intCount + 1
        If IsNull(mXMAKER_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XMAKER_CD = NULL --ﾒｰｶ-ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XMAKER_CD = NULL --ﾒｰｶ-ｺｰﾄﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAKER_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XMAKER_CD = :" & Ubound(strBindField) - 1 & " --ﾒｰｶ-ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XMAKER_CD = :" & Ubound(strBindField) - 1 & " --ﾒｰｶ-ｺｰﾄﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mXRAC_IN_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XRAC_IN_DT = NULL --入庫日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XRAC_IN_DT = NULL --入庫日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXRAC_IN_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XRAC_IN_DT = :" & Ubound(strBindField) - 1 & " --入庫日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XRAC_IN_DT = :" & Ubound(strBindField) - 1 & " --入庫日時")
        End If
        intCount = intCount + 1
        If IsNull(mXTRK_BUF_NO_IN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTRK_BUF_NO_IN = NULL --入庫ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTRK_BUF_NO_IN = NULL --入庫ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_IN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTRK_BUF_NO_IN = :" & Ubound(strBindField) - 1 & " --入庫ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTRK_BUF_NO_IN = :" & Ubound(strBindField) - 1 & " --入庫ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ��")
        End If
        intCount = intCount + 1
        If IsNull(mXTRK_BUF_ARRAY_IN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTRK_BUF_ARRAY_IN = NULL --入庫ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTRK_BUF_ARRAY_IN = NULL --入庫ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_ARRAY_IN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTRK_BUF_ARRAY_IN = :" & Ubound(strBindField) - 1 & " --入庫ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTRK_BUF_ARRAY_IN = :" & Ubound(strBindField) - 1 & " --入庫ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列��")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FPALLET_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FPALLET_ID IS NULL --ﾊﾟﾚｯﾄID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄID")
        End If
        If IsNull(FLOT_NO_STOCK) = True Then
            strSQL.Append(vbCrLf & "    AND FLOT_NO_STOCK IS NULL --在庫ﾛｯﾄ��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO_STOCK
            strSQL.Append(vbCrLf & "    AND FLOT_NO_STOCK = :" & UBound(strBindField) - 1 & " --在庫ﾛｯﾄ��")
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
    Public Sub ADD_TRST_STOCK()
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
        ElseIf IsNull(mFPALLET_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾊﾟﾚｯﾄID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFLOT_NO_STOCK) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[在庫ﾛｯﾄ��]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFARRIVE_DT) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[在庫発生日時]"
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
        strSQL.Append(vbCrLf & "    TRST_STOCK")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
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
        If IsNull(mFLOT_NO_STOCK) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --在庫ﾛｯﾄ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --在庫ﾛｯﾄ��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO_STOCK
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --在庫ﾛｯﾄ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --在庫ﾛｯﾄ��")
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
        If IsNull(mFLOT_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾛｯﾄ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾛｯﾄ��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾛｯﾄ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾛｯﾄ��")
        End If
        intCount = intCount + 1
        If IsNull(mFARRIVE_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --在庫発生日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --在庫発生日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFARRIVE_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --在庫発生日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --在庫発生日時")
        End If
        intCount = intCount + 1
        If IsNull(mFIN_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --入庫区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --入庫区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFIN_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --入庫区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --入庫区分")
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
        If IsNull(mFST_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFST_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ��")
        End If
        intCount = intCount + 1
        If IsNull(mFTR_VOL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --搬送管理量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --搬送管理量")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_VOL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --搬送管理量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --搬送管理量")
        End If
        intCount = intCount + 1
        If IsNull(mFTR_RES_VOL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --搬送引当量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --搬送引当量")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_RES_VOL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --搬送引当量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --搬送引当量")
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
        If IsNull(mFHASU_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --端数ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --端数ﾌﾗｸﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHASU_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --端数ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --端数ﾌﾗｸﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFLABEL_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾗﾍﾞﾙID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾗﾍﾞﾙID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLABEL_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾗﾍﾞﾙID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾗﾍﾞﾙID")
        End If
        intCount = intCount + 1
        If IsNull(mFSYUKKA_TO_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --出荷先ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --出荷先ｺｰﾄﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYUKKA_TO_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --出荷先ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --出荷先ｺｰﾄﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFSYUKKA_TO_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --出荷先名称")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --出荷先名称")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYUKKA_TO_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --出荷先名称")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --出荷先名称")
        End If
        intCount = intCount + 1
        If IsNull(mXPROD_LINE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --生産ﾗｲﾝ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --生産ﾗｲﾝ��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPROD_LINE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --生産ﾗｲﾝ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --生産ﾗｲﾝ��")
        End If
        intCount = intCount + 1
        If IsNull(mXKENSA_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --検査区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --検査区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKENSA_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --検査区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --検査区分")
        End If
        intCount = intCount + 1
        If IsNull(mXKENPIN_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --検品区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --検品区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKENPIN_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --検品区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --検品区分")
        End If
        intCount = intCount + 1
        If IsNull(mXMAKER_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾒｰｶ-ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾒｰｶ-ｺｰﾄﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAKER_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾒｰｶ-ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾒｰｶ-ｺｰﾄﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mXRAC_IN_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --入庫日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --入庫日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXRAC_IN_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --入庫日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --入庫日時")
        End If
        intCount = intCount + 1
        If IsNull(mXTRK_BUF_NO_IN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --入庫ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --入庫ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_IN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --入庫ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --入庫ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ��")
        End If
        intCount = intCount + 1
        If IsNull(mXTRK_BUF_ARRAY_IN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --入庫ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --入庫ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_ARRAY_IN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --入庫ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列��")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --入庫ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列��")
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
    Public Sub DELETE_TRST_STOCK()
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
        ElseIf IsNull(mFPALLET_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾊﾟﾚｯﾄID]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFLOT_NO_STOCK) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[在庫ﾛｯﾄ��]"
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
        strSQL.Append(vbCrLf & "    TRST_STOCK")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FPALLET_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FPALLET_ID IS NULL --ﾊﾟﾚｯﾄID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄID")
        End If
        If IsNull(FLOT_NO_STOCK) = True Then
            strSQL.Append(vbCrLf & "    AND FLOT_NO_STOCK IS NULL --在庫ﾛｯﾄ��")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO_STOCK
            strSQL.Append(vbCrLf & "    AND FLOT_NO_STOCK = :" & UBound(strBindField) - 1 & " --在庫ﾛｯﾄ��")
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
    Public Sub DELETE_TRST_STOCK_ANY()
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
        strSQL.Append(vbCrLf & "    TRST_STOCK")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(FPALLET_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄID")
        End If
        If IsNotNull(FLOT_NO_STOCK) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO_STOCK
            strSQL.Append(vbCrLf & "    AND FLOT_NO_STOCK = :" & UBound(strBindField) - 1 & " --在庫ﾛｯﾄ��")
        End If
        If IsNotNull(FHINMEI_CD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --品目ｺｰﾄﾞ")
        End If
        If IsNotNull(FLOT_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO
            strSQL.Append(vbCrLf & "    AND FLOT_NO = :" & UBound(strBindField) - 1 & " --ﾛｯﾄ��")
        End If
        If IsNotNull(FARRIVE_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFARRIVE_DT
            strSQL.Append(vbCrLf & "    AND FARRIVE_DT = :" & UBound(strBindField) - 1 & " --在庫発生日時")
        End If
        If IsNotNull(FIN_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFIN_KUBUN
            strSQL.Append(vbCrLf & "    AND FIN_KUBUN = :" & UBound(strBindField) - 1 & " --入庫区分")
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
        If IsNotNull(FST_FM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFST_FM
            strSQL.Append(vbCrLf & "    AND FST_FM = :" & UBound(strBindField) - 1 & " --搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ��")
        End If
        If IsNotNull(FTR_VOL) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_VOL
            strSQL.Append(vbCrLf & "    AND FTR_VOL = :" & UBound(strBindField) - 1 & " --搬送管理量")
        End If
        If IsNotNull(FTR_RES_VOL) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_RES_VOL
            strSQL.Append(vbCrLf & "    AND FTR_RES_VOL = :" & UBound(strBindField) - 1 & " --搬送引当量")
        End If
        If IsNotNull(FUPDATE_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --更新日時")
        End If
        If IsNotNull(FHASU_FLAG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHASU_FLAG
            strSQL.Append(vbCrLf & "    AND FHASU_FLAG = :" & UBound(strBindField) - 1 & " --端数ﾌﾗｸﾞ")
        End If
        If IsNotNull(FLABEL_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLABEL_ID
            strSQL.Append(vbCrLf & "    AND FLABEL_ID = :" & UBound(strBindField) - 1 & " --ﾗﾍﾞﾙID")
        End If
        If IsNotNull(FSYUKKA_TO_CD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYUKKA_TO_CD
            strSQL.Append(vbCrLf & "    AND FSYUKKA_TO_CD = :" & UBound(strBindField) - 1 & " --出荷先ｺｰﾄﾞ")
        End If
        If IsNotNull(FSYUKKA_TO_NAME) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYUKKA_TO_NAME
            strSQL.Append(vbCrLf & "    AND FSYUKKA_TO_NAME = :" & UBound(strBindField) - 1 & " --出荷先名称")
        End If
        If IsNotNull(XPROD_LINE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPROD_LINE
            strSQL.Append(vbCrLf & "    AND XPROD_LINE = :" & UBound(strBindField) - 1 & " --生産ﾗｲﾝ��")
        End If
        If IsNotNull(XKENSA_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKENSA_KUBUN
            strSQL.Append(vbCrLf & "    AND XKENSA_KUBUN = :" & UBound(strBindField) - 1 & " --検査区分")
        End If
        If IsNotNull(XKENPIN_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKENPIN_KUBUN
            strSQL.Append(vbCrLf & "    AND XKENPIN_KUBUN = :" & UBound(strBindField) - 1 & " --検品区分")
        End If
        If IsNotNull(XMAKER_CD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAKER_CD
            strSQL.Append(vbCrLf & "    AND XMAKER_CD = :" & UBound(strBindField) - 1 & " --ﾒｰｶ-ｺｰﾄﾞ")
        End If
        If IsNotNull(XRAC_IN_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXRAC_IN_DT
            strSQL.Append(vbCrLf & "    AND XRAC_IN_DT = :" & UBound(strBindField) - 1 & " --入庫日時")
        End If
        If IsNotNull(XTRK_BUF_NO_IN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_IN
            strSQL.Append(vbCrLf & "    AND XTRK_BUF_NO_IN = :" & UBound(strBindField) - 1 & " --入庫ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ��")
        End If
        If IsNotNull(XTRK_BUF_ARRAY_IN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_ARRAY_IN
            strSQL.Append(vbCrLf & "    AND XTRK_BUF_ARRAY_IN = :" & UBound(strBindField) - 1 & " --入庫ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列��")
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
        If IsNothing(objType.GetProperty("FPALLET_ID")) = False Then mFPALLET_ID = objObject.FPALLET_ID 'ﾊﾟﾚｯﾄID
        If IsNothing(objType.GetProperty("FLOT_NO_STOCK")) = False Then mFLOT_NO_STOCK = objObject.FLOT_NO_STOCK '在庫ﾛｯﾄ��
        If IsNothing(objType.GetProperty("FHINMEI_CD")) = False Then mFHINMEI_CD = objObject.FHINMEI_CD '品目ｺｰﾄﾞ
        If IsNothing(objType.GetProperty("FLOT_NO")) = False Then mFLOT_NO = objObject.FLOT_NO 'ﾛｯﾄ��
        If IsNothing(objType.GetProperty("FARRIVE_DT")) = False Then mFARRIVE_DT = objObject.FARRIVE_DT '在庫発生日時
        If IsNothing(objType.GetProperty("FIN_KUBUN")) = False Then mFIN_KUBUN = objObject.FIN_KUBUN '入庫区分
        If IsNothing(objType.GetProperty("FSEIHIN_KUBUN")) = False Then mFSEIHIN_KUBUN = objObject.FSEIHIN_KUBUN '製品区分
        If IsNothing(objType.GetProperty("FZAIKO_KUBUN")) = False Then mFZAIKO_KUBUN = objObject.FZAIKO_KUBUN '在庫区分
        If IsNothing(objType.GetProperty("FHORYU_KUBUN")) = False Then mFHORYU_KUBUN = objObject.FHORYU_KUBUN '保留区分
        If IsNothing(objType.GetProperty("FST_FM")) = False Then mFST_FM = objObject.FST_FM '搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ��
        If IsNothing(objType.GetProperty("FTR_VOL")) = False Then mFTR_VOL = objObject.FTR_VOL '搬送管理量
        If IsNothing(objType.GetProperty("FTR_RES_VOL")) = False Then mFTR_RES_VOL = objObject.FTR_RES_VOL '搬送引当量
        If IsNothing(objType.GetProperty("FUPDATE_DT")) = False Then mFUPDATE_DT = objObject.FUPDATE_DT '更新日時
        If IsNothing(objType.GetProperty("FHASU_FLAG")) = False Then mFHASU_FLAG = objObject.FHASU_FLAG '端数ﾌﾗｸﾞ
        If IsNothing(objType.GetProperty("FLABEL_ID")) = False Then mFLABEL_ID = objObject.FLABEL_ID 'ﾗﾍﾞﾙID
        If IsNothing(objType.GetProperty("FSYUKKA_TO_CD")) = False Then mFSYUKKA_TO_CD = objObject.FSYUKKA_TO_CD '出荷先ｺｰﾄﾞ
        If IsNothing(objType.GetProperty("FSYUKKA_TO_NAME")) = False Then mFSYUKKA_TO_NAME = objObject.FSYUKKA_TO_NAME '出荷先名称
        If IsNothing(objType.GetProperty("XPROD_LINE")) = False Then mXPROD_LINE = objObject.XPROD_LINE '生産ﾗｲﾝ��
        If IsNothing(objType.GetProperty("XKENSA_KUBUN")) = False Then mXKENSA_KUBUN = objObject.XKENSA_KUBUN '検査区分
        If IsNothing(objType.GetProperty("XKENPIN_KUBUN")) = False Then mXKENPIN_KUBUN = objObject.XKENPIN_KUBUN '検品区分
        If IsNothing(objType.GetProperty("XMAKER_CD")) = False Then mXMAKER_CD = objObject.XMAKER_CD 'ﾒｰｶ-ｺｰﾄﾞ
        If IsNothing(objType.GetProperty("XRAC_IN_DT")) = False Then mXRAC_IN_DT = objObject.XRAC_IN_DT '入庫日時
        If IsNothing(objType.GetProperty("XTRK_BUF_NO_IN")) = False Then mXTRK_BUF_NO_IN = objObject.XTRK_BUF_NO_IN '入庫ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ��
        If IsNothing(objType.GetProperty("XTRK_BUF_ARRAY_IN")) = False Then mXTRK_BUF_ARRAY_IN = objObject.XTRK_BUF_ARRAY_IN '入庫ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列��

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
        mFPALLET_ID = Nothing
        mFLOT_NO_STOCK = Nothing
        mFHINMEI_CD = Nothing
        mFLOT_NO = Nothing
        mFARRIVE_DT = Nothing
        mFIN_KUBUN = Nothing
        mFSEIHIN_KUBUN = Nothing
        mFZAIKO_KUBUN = Nothing
        mFHORYU_KUBUN = Nothing
        mFST_FM = Nothing
        mFTR_VOL = Nothing
        mFTR_RES_VOL = Nothing
        mFUPDATE_DT = Nothing
        mFHASU_FLAG = Nothing
        mFLABEL_ID = Nothing
        mFSYUKKA_TO_CD = Nothing
        mFSYUKKA_TO_NAME = Nothing
        mXPROD_LINE = Nothing
        mXKENSA_KUBUN = Nothing
        mXKENPIN_KUBUN = Nothing
        mXMAKER_CD = Nothing
        mXRAC_IN_DT = Nothing
        mXTRK_BUF_NO_IN = Nothing
        mXTRK_BUF_ARRAY_IN = Nothing


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
        mFPALLET_ID = TO_STRING_NULLABLE(objRow("FPALLET_ID"))
        mFLOT_NO_STOCK = TO_STRING_NULLABLE(objRow("FLOT_NO_STOCK"))
        mFHINMEI_CD = TO_STRING_NULLABLE(objRow("FHINMEI_CD"))
        mFLOT_NO = TO_STRING_NULLABLE(objRow("FLOT_NO"))
        mFARRIVE_DT = TO_DATE_NULLABLE(objRow("FARRIVE_DT"))
        mFIN_KUBUN = TO_INTEGER_NULLABLE(objRow("FIN_KUBUN"))
        mFSEIHIN_KUBUN = TO_INTEGER_NULLABLE(objRow("FSEIHIN_KUBUN"))
        mFZAIKO_KUBUN = TO_INTEGER_NULLABLE(objRow("FZAIKO_KUBUN"))
        mFHORYU_KUBUN = TO_INTEGER_NULLABLE(objRow("FHORYU_KUBUN"))
        mFST_FM = TO_INTEGER_NULLABLE(objRow("FST_FM"))
        mFTR_VOL = TO_DECIMAL_NULLABLE(objRow("FTR_VOL"))
        mFTR_RES_VOL = TO_DECIMAL_NULLABLE(objRow("FTR_RES_VOL"))
        mFUPDATE_DT = TO_DATE_NULLABLE(objRow("FUPDATE_DT"))
        mFHASU_FLAG = TO_INTEGER_NULLABLE(objRow("FHASU_FLAG"))
        mFLABEL_ID = TO_STRING_NULLABLE(objRow("FLABEL_ID"))
        mFSYUKKA_TO_CD = TO_STRING_NULLABLE(objRow("FSYUKKA_TO_CD"))
        mFSYUKKA_TO_NAME = TO_STRING_NULLABLE(objRow("FSYUKKA_TO_NAME"))
        mXPROD_LINE = TO_STRING_NULLABLE(objRow("XPROD_LINE"))
        mXKENSA_KUBUN = TO_STRING_NULLABLE(objRow("XKENSA_KUBUN"))
        mXKENPIN_KUBUN = TO_STRING_NULLABLE(objRow("XKENPIN_KUBUN"))
        mXMAKER_CD = TO_STRING_NULLABLE(objRow("XMAKER_CD"))
        mXRAC_IN_DT = TO_DATE_NULLABLE(objRow("XRAC_IN_DT"))
        mXTRK_BUF_NO_IN = TO_INTEGER_NULLABLE(objRow("XTRK_BUF_NO_IN"))
        mXTRK_BUF_ARRAY_IN = TO_INTEGER_NULLABLE(objRow("XTRK_BUF_ARRAY_IN"))


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
        strMsg &= "[ﾃｰﾌﾞﾙ名:在庫情報]"
        If IsNotNull(FPALLET_ID) Then
            strMsg &= "[ﾊﾟﾚｯﾄID:" & FPALLET_ID & "]"
        End If
        If IsNotNull(FLOT_NO_STOCK) Then
            strMsg &= "[在庫ﾛｯﾄ��:" & FLOT_NO_STOCK & "]"
        End If
        If IsNotNull(FHINMEI_CD) Then
            strMsg &= "[品目ｺｰﾄﾞ:" & FHINMEI_CD & "]"
        End If
        If IsNotNull(FLOT_NO) Then
            strMsg &= "[ﾛｯﾄ��:" & FLOT_NO & "]"
        End If
        If IsNotNull(FARRIVE_DT) Then
            strMsg &= "[在庫発生日時:" & FARRIVE_DT & "]"
        End If
        If IsNotNull(FIN_KUBUN) Then
            strMsg &= "[入庫区分:" & FIN_KUBUN & "]"
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
        If IsNotNull(FST_FM) Then
            strMsg &= "[搬送元STﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ��:" & FST_FM & "]"
        End If
        If IsNotNull(FTR_VOL) Then
            strMsg &= "[搬送管理量:" & FTR_VOL & "]"
        End If
        If IsNotNull(FTR_RES_VOL) Then
            strMsg &= "[搬送引当量:" & FTR_RES_VOL & "]"
        End If
        If IsNotNull(FUPDATE_DT) Then
            strMsg &= "[更新日時:" & FUPDATE_DT & "]"
        End If
        If IsNotNull(FHASU_FLAG) Then
            strMsg &= "[端数ﾌﾗｸﾞ:" & FHASU_FLAG & "]"
        End If
        If IsNotNull(FLABEL_ID) Then
            strMsg &= "[ﾗﾍﾞﾙID:" & FLABEL_ID & "]"
        End If
        If IsNotNull(FSYUKKA_TO_CD) Then
            strMsg &= "[出荷先ｺｰﾄﾞ:" & FSYUKKA_TO_CD & "]"
        End If
        If IsNotNull(FSYUKKA_TO_NAME) Then
            strMsg &= "[出荷先名称:" & FSYUKKA_TO_NAME & "]"
        End If
        If IsNotNull(XPROD_LINE) Then
            strMsg &= "[生産ﾗｲﾝ��:" & XPROD_LINE & "]"
        End If
        If IsNotNull(XKENSA_KUBUN) Then
            strMsg &= "[検査区分:" & XKENSA_KUBUN & "]"
        End If
        If IsNotNull(XKENPIN_KUBUN) Then
            strMsg &= "[検品区分:" & XKENPIN_KUBUN & "]"
        End If
        If IsNotNull(XMAKER_CD) Then
            strMsg &= "[ﾒｰｶ-ｺｰﾄﾞ:" & XMAKER_CD & "]"
        End If
        If IsNotNull(XRAC_IN_DT) Then
            strMsg &= "[入庫日時:" & XRAC_IN_DT & "]"
        End If
        If IsNotNull(XTRK_BUF_NO_IN) Then
            strMsg &= "[入庫ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ��:" & XTRK_BUF_NO_IN & "]"
        End If
        If IsNotNull(XTRK_BUF_ARRAY_IN) Then
            strMsg &= "[入庫ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列��:" & XTRK_BUF_ARRAY_IN & "]"
        End If


    End Sub
#End Region
    '↑↑↑自動生成部
    '**********************************************************************************************


    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ共通
#Region "  ｸﾗｽ変数定義"
    Private mFPALLET_KIND As Integer                'ﾊﾟﾚｯﾄ種別
    Private mFZAIKO_ON_STYLE As Integer             '在庫積載状態

    '並び順
    Public Enum Order
        FLOT_NO_STOCK       '在庫ﾛｯﾄ��
        FARRIVE_DT          '在庫発生日時
    End Enum

#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義"
    Public Property FPALLET_KIND() As Integer
        Get
            Return mFPALLET_KIND
        End Get
        Set(ByVal Value As Integer)
            mFPALLET_KIND = Value
        End Set
    End Property
    Public Property FZAIKO_ON_STYLE() As Integer
        Get
            Return mFZAIKO_ON_STYLE
        End Get
        Set(ByVal Value As Integer)
            mFZAIKO_ON_STYLE = Value
        End Set
    End Property
#End Region
#Region "  在庫情報取得     [混載情報取得]              (Public  GET_TRST_STOCK_KONSAI)"
    ''' *******************************************************************************************************
    ''' <summary>
    ''' 在庫情報取得 [混載情報取得]
    ''' </summary>
    ''' <param name="intOrder">配列にｾｯﾄする並び順</param>
    ''' <param name="blnDateOrderAsc">日付ｵｰﾀﾞｰ昇順ﾌﾗｸﾞ</param>
    ''' <returns>検索結果</returns>
    ''' <remarks>
    ''' 混載情報を取得し、結果を配列にｾｯﾄする。
    ''' 配列にｾｯﾄする順番は、引数のintOrderで設定出来る。
    ''' </remarks>
    ''' *******************************************************************************************************
    Public Function GET_TRST_STOCK_KONSAI(ByVal blnNotFoundError As Boolean _
                                        , Optional ByVal intOrder As Order = Order.FLOT_NO_STOCK _
                                        , Optional ByVal blnDateOrderAsc As Boolean = True _
                                        ) _
                                        As RetCode
        Try
            Dim strSQL As String            'SQL文
            Dim strMsg As String            'ﾒｯｾｰｼﾞ
            Dim objDataSet As New DataSet   'ﾃﾞｰﾀｾｯﾄ
            Dim intRet As RetCode


            '***********************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '***********************
            If mFPALLET_ID = DEFAULT_STRING Then
                strMsg = ERRMSG_ERR_PROPERTY & "[ﾊﾟﾚｯﾄID]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '抽出SQL作成
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    *"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TRST_STOCK TRST_STOCK"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        TRST_STOCK.FPALLET_ID = '" & TO_STRING(mFPALLET_ID) & "'"
            If IsNull(mFLOT_NO_STOCK) = False Then
                strSQL &= vbCrLf & "    AND TRST_STOCK.FLOT_NO_STOCK = '" & TO_STRING(mFLOT_NO_STOCK) & "'"
            End If
            strSQL &= vbCrLf & " ORDER BY "

            If intOrder = Order.FLOT_NO_STOCK Then
                strSQL &= vbCrLf & "    TRST_STOCK.FLOT_NO_STOCK "
            ElseIf intOrder = Order.FARRIVE_DT Then
                strSQL &= vbCrLf & "    TRST_STOCK.XSEITAI_KUBUN DESC "
                If blnDateOrderAsc Then
                    strSQL &= vbCrLf & "   ,TRST_STOCK.FARRIVE_DT "
                Else
                    strSQL &= vbCrLf & "   ,TRST_STOCK.FARRIVE_DT DESC "
                End If
                strSQL &= vbCrLf & "   ,TRST_STOCK.FLOT_NO "
            End If

            strSQL &= vbCrLf


            '***********************
            '抽出
            '***********************
            mstrUSER_SQL = strSQL
            intRet = GET_TRST_STOCK_USER()
            '↓↓↓↓↓↓************************************************************************************************************
            'Checked SystemMate:N.Dounoshita 2012/03/24 混載取得、自動ｴﾗｰ対応
            If intRet <> RetCode.OK Then

                If blnNotFoundError = True Then
                    '(ｴﾗｰとする場合)
                    strMsg = ""
                    Call MAKE_ERRMSG01(strMsg)
                    Throw New Exception(strMsg)
                Else
                    '(ｴﾗｰしない場合)
                    Return (intRet)
                End If

            End If
            '↑↑↑↑↑↑************************************************************************************************************


            Return intRet
        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "  在庫情報追加     [ﾊﾟﾚｯﾄ/付加情報込み]        (Public  ADD_TRST_STOCK_ALL)"
    Public Sub ADD_TRST_STOCK_ALL()
        Try
            Dim intRet As RetCode                 '戻り値

            If IsNull(mFPALLET_ID) = True Then
                '***********************
                'ﾊﾟﾚｯﾄIDの特定
                '***********************
                Dim objTPRG_SEQNO As New TBL_TPRG_SEQNO(Owner, ObjDb, ObjDbLog) 'ｼｰｹﾝｽ�ずﾗｽ
                objTPRG_SEQNO.FSEQ_ID = FSEQ_ID_SSVRPALLET_ID                    'ｼｰｹﾝｽID(ﾊﾟﾚｯﾄID)
                mFPALLET_ID = objTPRG_SEQNO.GET_ENTRY_NO()                      'ﾛｸﾞ�ｂﾌ特定
            End If


            '***********************
            '在庫ﾛｯﾄ�ｂﾌ特定
            '***********************
            Dim objTPRG_SEQNO_LOT_NO As New TBL_TPRG_SEQNO(Owner, ObjDb, ObjDbLog)  'ｼｰｹﾝｽ�ずﾗｽ
            objTPRG_SEQNO_LOT_NO.FSEQ_ID = FSEQ_ID_SSVRLOT_NO_STOCK                  'ｼｰｹﾝｽID(在庫ﾛｯﾄ��)
            mFLOT_NO_STOCK = objTPRG_SEQNO_LOT_NO.GET_ENTRY_NO()                    'ﾛｸﾞ�ｂﾌ特定


            '***********************
            '在庫情報の登録
            '***********************
            Me.ADD_TRST_STOCK()


            '***********************
            'ﾊﾟﾚｯﾄ情報の登録
            '***********************
            Dim objTRST_PALLET As New TBL_TRST_PALLET(Owner, ObjDb, ObjDbLog)   'ﾊﾟﾚｯﾄ情報ｸﾗｽ
            objTRST_PALLET.FPALLET_ID = mFPALLET_ID                             'ﾊﾟﾚｯﾄID
            intRet = objTRST_PALLET.GET_TRST_PALLET(False)
            If intRet <> RetCode.OK Then
                '(見つからなかった場合)

                objTRST_PALLET.FPALLET_KIND = mFPALLET_KIND                         'ﾊﾟﾚｯﾄ種別
                objTRST_PALLET.FZAIKO_ON_STYLE = mFZAIKO_ON_STYLE                   '在庫積載状態
                objTRST_PALLET.FENTRY_DT = Now                                      '登録日時
                objTRST_PALLET.ADD_TRST_PALLET()                                    '登録

            Else
                '(見つかった場合)
                objTRST_PALLET.FPALLET_KIND = mFPALLET_KIND                         'ﾊﾟﾚｯﾄ種別
                objTRST_PALLET.FZAIKO_ON_STYLE = mFZAIKO_ON_STYLE                   '在庫積載状態
                objTRST_PALLET.UPDATE_TRST_PALLET()                                 '更新
            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
#Region "  在庫情報削除     [ﾊﾟﾚｯﾄ/付加情報込み]        (Public  DELETE_TRST_STOCK_ALL)"
    Public Sub DELETE_TRST_STOCK_ALL()
        Try
            Dim strSQL As String        'SQL文
            Dim intRetSQL As Integer    'SQL実行戻り値
            Dim strMsg As String        'ﾒｯｾｰｼﾞ

            '***********************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '***********************
            If mFPALLET_ID = DEFAULT_STRING Then
                strMsg = ERRMSG_ERR_PROPERTY & "[ﾊﾟﾚｯﾄID]"
                Throw New UserException(strMsg)
                '' ''ElseIf mFLOT_NO_STOCK = DEFAULT_STRING Then
                '' ''    strMsg = ERRMSG_ERR_PROPERTY & "[在庫ﾛｯﾄ��]"
                '' ''    Throw New UserException(strMsg)
            End If



            '***********************
            '削除SQL作成
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & " DELETE"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TRST_STOCK "
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        TRST_STOCK.FPALLET_ID = '" & TO_STRING(mFPALLET_ID) & "'"
            If IsNull(mFLOT_NO_STOCK) = False Then
                strSQL &= vbCrLf & "    AND TRST_STOCK.FLOT_NO_STOCK = '" & TO_STRING(mFLOT_NO_STOCK) & "'"
            End If


            '***********************
            '削除
            '***********************
            intRetSQL = ObjDb.Execute(strSQL)
            If intRetSQL = -1 Then
                '(SQLｴﾗｰ)
                strMsg = ERRMSG_ERR_DELETE & " " & ObjDb.ErrMsg & "[" & Replace(strSQL.ToString, vbCrLf, "") & "]"
                Throw New UserException(strMsg)
            End If


            '***********************
            'ﾊﾟﾚｯﾄ情報削除
            '***********************
            Dim intCount As Integer '在庫情報件数
            Dim objTRST_STOCK As New TBL_TRST_STOCK(Owner, ObjDb, ObjDbLog)
            objTRST_STOCK.FPALLET_ID = mFPALLET_ID              'ﾊﾟﾚｯﾄID
            intCount = objTRST_STOCK.GET_TRST_STOCK_COUNT()     '件数取得
            If intCount = 0 Then
                Dim objTRST_PALLET As New TBL_TRST_PALLET(Owner, ObjDb, ObjDbLog)
                objTRST_PALLET.FPALLET_ID = mFPALLET_ID         'ﾊﾟﾚｯﾄID
                objTRST_PALLET.DELETE_TRST_PALLET()             '削除
            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
#Region "  在庫情報更新     [ﾊﾟﾚｯﾄ/付加情報込み]        (Public  UPDATE_TRST_STOCK_ALL)"
    Public Function GET_TRST_STOCK_ALL() As RetCode
        Try
            Dim intRet As RetCode                 '戻り値

            '***********************
            '在庫情報の更新
            '***********************
            Me.GET_TRST_STOCK(False)

            '***********************
            'ﾊﾟﾚｯﾄ情報の更新
            '***********************
            Dim objTRST_PALLET As New TBL_TRST_PALLET(Owner, ObjDb, ObjDbLog)   'ﾊﾟﾚｯﾄ情報ｸﾗｽ
            objTRST_PALLET.FPALLET_ID = mFPALLET_ID                             'ﾊﾟﾚｯﾄID
            intRet = objTRST_PALLET.GET_TRST_PALLET(False)
            If intRet = RetCode.OK Then
                '(見つかった場合)
                mFPALLET_KIND = objTRST_PALLET.FPALLET_KIND                     'ﾊﾟﾚｯﾄ種別
                mFZAIKO_ON_STYLE = objTRST_PALLET.FZAIKO_ON_STYLE               '在庫積載状態
            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "  在庫情報更新     [ﾊﾟﾚｯﾄ/付加情報込み]        (Public  UPDATE_TRST_STOCK_ALL)"
    Public Sub UPDATE_TRST_STOCK_ALL()
        Try
            Dim intRet As RetCode                 '戻り値

            '***********************
            '在庫情報の更新
            '***********************
            Me.UPDATE_TRST_STOCK()

            '***********************
            'ﾊﾟﾚｯﾄ情報の更新
            '***********************
            Dim objTRST_PALLET As New TBL_TRST_PALLET(Owner, ObjDb, ObjDbLog)   'ﾊﾟﾚｯﾄ情報ｸﾗｽ
            objTRST_PALLET.FPALLET_ID = mFPALLET_ID                             'ﾊﾟﾚｯﾄID
            intRet = objTRST_PALLET.GET_TRST_PALLET(False)
            If intRet <> RetCode.OK Then
                '(見つからなかった場合)

                objTRST_PALLET.FPALLET_KIND = mFPALLET_KIND                         'ﾊﾟﾚｯﾄ種別
                objTRST_PALLET.FZAIKO_ON_STYLE = mFZAIKO_ON_STYLE                   '在庫積載状態
                objTRST_PALLET.FENTRY_DT = Now                                      '登録日時
                objTRST_PALLET.ADD_TRST_PALLET()                                    '登録
            Else
                '(見つかった場合)
                objTRST_PALLET.FPALLET_KIND = mFPALLET_KIND                         'ﾊﾟﾚｯﾄ種別
                objTRST_PALLET.FZAIKO_ON_STYLE = mFZAIKO_ON_STYLE                   '在庫積載状態
                objTRST_PALLET.UPDATE_TRST_PALLET()                                 '更新

            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
#Region "  在庫情報取得     [指定されたﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ内の全ての在庫]                      "
    ''' *******************************************************************************************************
    ''' <summary>
    ''' 在庫情報取得     [指定されたﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ内の全ての在庫]
    ''' </summary>
    ''' <param name="strFTRK_BUF_NO">配列にｾｯﾄする並び順</param>
    ''' <returns>検索結果</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************
    Public Function GET_TRST_STOCK_FTRK_BUF_NO(ByVal strFTRK_BUF_NO As String) As RetCode
        Try
            Dim strSQL As String            'SQL文
            'Dim strMsg As String            'ﾒｯｾｰｼﾞ
            Dim objDataSet As New DataSet   'ﾃﾞｰﾀｾｯﾄ
            Dim intRet As RetCode


            '***********************
            '抽出SQL作成
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    *"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TRST_STOCK "
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "    EXISTS"
            strSQL &= vbCrLf & "        ("
            strSQL &= vbCrLf & "        SELECT"
            strSQL &= vbCrLf & "            *"
            strSQL &= vbCrLf & "        FROM"
            strSQL &= vbCrLf & "            TPRG_TRK_BUF"
            strSQL &= vbCrLf & "        WHERE"
            strSQL &= vbCrLf & "                TPRG_TRK_BUF.FPALLET_ID = TRST_STOCK.FPALLET_ID"
            strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.FTRK_BUF_NO = " & strFTRK_BUF_NO
            strSQL &= vbCrLf & "        )"
            strSQL &= vbCrLf


            '***********************
            '抽出
            '***********************
            mstrUSER_SQL = strSQL
            intRet = GET_TRST_STOCK_USER()


            Return intRet
        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

    '↑↑↑ｼｽﾃﾑ共通
    '**********************************************************************************************


    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

    '**********************************************************************************************
    '↓↓↓HDT用
    '↑↑↑HDT用
    '**********************************************************************************************

End Class
