'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' 【名称】MaterialStreamﾃｰﾌﾞﾙｸﾗｽ
' 【機能】保管出納記録ﾃｰﾌﾞﾙｸﾗｽ
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
''' 保管出納記録ﾃｰﾌﾞﾙｸﾗｽ
''' </summary>
Public Class TBL_TEVD_SUITOU
    Inherits clsTemplateTable

    '**********************************************************************************************
    '↓↓↓自動生成部
#Region "  ｸﾗｽ変数定義                  "
    'ﾌﾟﾛﾊﾟﾃｨ
    Private mobjAryMe As TBL_TEVD_SUITOU()                                       '保管出納記録
    Private mstrUSER_SQL As String                                               'ﾕｰｻﾞｰSQL
    Private mORDER_BY As String                                                  'OrderBy句
    Private mWHERE As String                                                     'Where句
    Private mFLOG_NO As String                                                   'ﾛｸﾞ№
    Private mFLOT_NO_STOCK As String                                             '在庫ﾛｯﾄ№
    Private mFRESULT_DT As Nullable(Of Date)                                     '実績日時
    Private mFHINMEI_CD As String                                                '品目ｺｰﾄﾞ
    Private mFHINMEI As String                                                   '品名_正式名
    Private mFLOT_NO As String                                                   'ﾛｯﾄ№
    Private mFTANI As String                                                     '単位ｺｰﾄﾞ
    Private mFTRK_BUF_NO As Nullable(Of Integer)                                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    Private mFOUT_NAME As String                                                 '搬送先
    Private mFTR_TO As Nullable(Of Integer)                                      '搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    Private mFTR_VOL As Nullable(Of Decimal)                                     '搬送管理量
    Private mFTR_INOUT_VOL As Nullable(Of Decimal)                               '入出庫数量
    Private mFDECIMAL_POINT As Nullable(Of Integer)                              '小数点以下有効桁数
    Private mFTERM_ID As String                                                  '端末ID
    Private mFTERM_NAME As String                                                '端末名
    Private mFUSER_ID As String                                                  'ﾕｰｻﾞｰID
    Private mFUSER_NAME As String                                                '名前
    Private mFREASON_CD As String                                                '理由ｺｰﾄﾞ
    Private mFREASON As String                                                   '理由
    Private mFSAGYOU_KIND As Nullable(Of Integer)                                '作業種別
    Private mFLOG_CHECK_DT1 As Nullable(Of Date)                                 '確認日時_1
    Private mFUSER_ID_CHECK1 As String                                           '確認ﾕｰｻﾞｰID_1
    Private mFUSER_NAME_CHECK1 As String                                         '確認ﾕｰｻﾞｰ名_1
    Private mFLOG_CHECK_DT2 As Nullable(Of Date)                                 '確認日時_2
    Private mFUSER_ID_CHECK2 As String                                           '確認ﾕｰｻﾞｰID_2
    Private mFUSER_NAME_CHECK2 As String                                         '確認ﾕｰｻﾞｰ名_2
    Private mFLOG_CHECK_DT3 As Nullable(Of Date)                                 '確認日時_3
    Private mFUSER_ID_CHECK3 As String                                           '確認ﾕｰｻﾞｰID_3
    Private mFUSER_NAME_CHECK3 As String                                         '確認ﾕｰｻﾞｰ名_3
    Private mFLOG_CHECK_DT4 As Nullable(Of Date)                                 '確認日時_4
    Private mFUSER_ID_CHECK4 As String                                           '確認ﾕｰｻﾞｰID_4
    Private mFUSER_NAME_CHECK4 As String                                         '確認ﾕｰｻﾞｰ名_4
    Private mFLOG_CHECK_DT5 As Nullable(Of Date)                                 '確認日時_5
    Private mFUSER_ID_CHECK5 As String                                           '確認ﾕｰｻﾞｰID_5
    Private mFUSER_NAME_CHECK5 As String                                         '確認ﾕｰｻﾞｰ名_5
    Private mFSYUKKA_TO_CD As String                                             '出荷先ｺｰﾄﾞ
    Private mFSYUKKA_TO_NAME As String                                           '出荷先名称
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                  "
    ''' <summary>
    ''' ｼｽﾃﾑ変数 (自ｸﾗｽ型配列)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_TEVD_SUITOU()
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
    ''' 在庫ﾛｯﾄ№
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
    ''' 実績日時
    ''' </summary>
    Public Property FRESULT_DT() As Nullable(Of Date)
        Get
            Return mFRESULT_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mFRESULT_DT = Value
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
    ''' 搬送先
    ''' </summary>
    Public Property FOUT_NAME() As String
        Get
            Return mFOUT_NAME
        End Get
        Set(ByVal Value As String)
            mFOUT_NAME = Value
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
    ''' 入出庫数量
    ''' </summary>
    Public Property FTR_INOUT_VOL() As Nullable(Of Decimal)
        Get
            Return mFTR_INOUT_VOL
        End Get
        Set(ByVal Value As Nullable(Of Decimal))
            mFTR_INOUT_VOL = Value
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
    ''' 理由ｺｰﾄﾞ
    ''' </summary>
    Public Property FREASON_CD() As String
        Get
            Return mFREASON_CD
        End Get
        Set(ByVal Value As String)
            mFREASON_CD = Value
        End Set
    End Property
    ''' <summary>
    ''' 理由
    ''' </summary>
    Public Property FREASON() As String
        Get
            Return mFREASON
        End Get
        Set(ByVal Value As String)
            mFREASON = Value
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
    ''' 確認日時_1
    ''' </summary>
    Public Property FLOG_CHECK_DT1() As Nullable(Of Date)
        Get
            Return mFLOG_CHECK_DT1
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mFLOG_CHECK_DT1 = Value
        End Set
    End Property
    ''' <summary>
    ''' 確認ﾕｰｻﾞｰID_1
    ''' </summary>
    Public Property FUSER_ID_CHECK1() As String
        Get
            Return mFUSER_ID_CHECK1
        End Get
        Set(ByVal Value As String)
            mFUSER_ID_CHECK1 = Value
        End Set
    End Property
    ''' <summary>
    ''' 確認ﾕｰｻﾞｰ名_1
    ''' </summary>
    Public Property FUSER_NAME_CHECK1() As String
        Get
            Return mFUSER_NAME_CHECK1
        End Get
        Set(ByVal Value As String)
            mFUSER_NAME_CHECK1 = Value
        End Set
    End Property
    ''' <summary>
    ''' 確認日時_2
    ''' </summary>
    Public Property FLOG_CHECK_DT2() As Nullable(Of Date)
        Get
            Return mFLOG_CHECK_DT2
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mFLOG_CHECK_DT2 = Value
        End Set
    End Property
    ''' <summary>
    ''' 確認ﾕｰｻﾞｰID_2
    ''' </summary>
    Public Property FUSER_ID_CHECK2() As String
        Get
            Return mFUSER_ID_CHECK2
        End Get
        Set(ByVal Value As String)
            mFUSER_ID_CHECK2 = Value
        End Set
    End Property
    ''' <summary>
    ''' 確認ﾕｰｻﾞｰ名_2
    ''' </summary>
    Public Property FUSER_NAME_CHECK2() As String
        Get
            Return mFUSER_NAME_CHECK2
        End Get
        Set(ByVal Value As String)
            mFUSER_NAME_CHECK2 = Value
        End Set
    End Property
    ''' <summary>
    ''' 確認日時_3
    ''' </summary>
    Public Property FLOG_CHECK_DT3() As Nullable(Of Date)
        Get
            Return mFLOG_CHECK_DT3
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mFLOG_CHECK_DT3 = Value
        End Set
    End Property
    ''' <summary>
    ''' 確認ﾕｰｻﾞｰID_3
    ''' </summary>
    Public Property FUSER_ID_CHECK3() As String
        Get
            Return mFUSER_ID_CHECK3
        End Get
        Set(ByVal Value As String)
            mFUSER_ID_CHECK3 = Value
        End Set
    End Property
    ''' <summary>
    ''' 確認ﾕｰｻﾞｰ名_3
    ''' </summary>
    Public Property FUSER_NAME_CHECK3() As String
        Get
            Return mFUSER_NAME_CHECK3
        End Get
        Set(ByVal Value As String)
            mFUSER_NAME_CHECK3 = Value
        End Set
    End Property
    ''' <summary>
    ''' 確認日時_4
    ''' </summary>
    Public Property FLOG_CHECK_DT4() As Nullable(Of Date)
        Get
            Return mFLOG_CHECK_DT4
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mFLOG_CHECK_DT4 = Value
        End Set
    End Property
    ''' <summary>
    ''' 確認ﾕｰｻﾞｰID_4
    ''' </summary>
    Public Property FUSER_ID_CHECK4() As String
        Get
            Return mFUSER_ID_CHECK4
        End Get
        Set(ByVal Value As String)
            mFUSER_ID_CHECK4 = Value
        End Set
    End Property
    ''' <summary>
    ''' 確認ﾕｰｻﾞｰ名_4
    ''' </summary>
    Public Property FUSER_NAME_CHECK4() As String
        Get
            Return mFUSER_NAME_CHECK4
        End Get
        Set(ByVal Value As String)
            mFUSER_NAME_CHECK4 = Value
        End Set
    End Property
    ''' <summary>
    ''' 確認日時_5
    ''' </summary>
    Public Property FLOG_CHECK_DT5() As Nullable(Of Date)
        Get
            Return mFLOG_CHECK_DT5
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mFLOG_CHECK_DT5 = Value
        End Set
    End Property
    ''' <summary>
    ''' 確認ﾕｰｻﾞｰID_5
    ''' </summary>
    Public Property FUSER_ID_CHECK5() As String
        Get
            Return mFUSER_ID_CHECK5
        End Get
        Set(ByVal Value As String)
            mFUSER_ID_CHECK5 = Value
        End Set
    End Property
    ''' <summary>
    ''' 確認ﾕｰｻﾞｰ名_5
    ''' </summary>
    Public Property FUSER_NAME_CHECK5() As String
        Get
            Return mFUSER_NAME_CHECK5
        End Get
        Set(ByVal Value As String)
            mFUSER_NAME_CHECK5 = Value
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
    Public Function GET_TEVD_SUITOU(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    TEVD_SUITOU")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FLOG_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            strSQL.Append(vbCrLf & "    AND FLOG_NO = :" & UBound(strBindField) - 1 & " --ﾛｸﾞ№")
        End If
        If IsNull(FLOT_NO_STOCK) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO_STOCK
            strSQL.Append(vbCrLf & "    AND FLOT_NO_STOCK = :" & UBound(strBindField) - 1 & " --在庫ﾛｯﾄ№")
        End If
        If IsNull(FRESULT_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRESULT_DT
            strSQL.Append(vbCrLf & "    AND FRESULT_DT = :" & UBound(strBindField) - 1 & " --実績日時")
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
        If IsNull(FTANI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTANI
            strSQL.Append(vbCrLf & "    AND FTANI = :" & UBound(strBindField) - 1 & " --単位ｺｰﾄﾞ")
        End If
        If IsNull(FTRK_BUF_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNull(FOUT_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFOUT_NAME
            strSQL.Append(vbCrLf & "    AND FOUT_NAME = :" & UBound(strBindField) - 1 & " --搬送先")
        End If
        If IsNull(FTR_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_TO
            strSQL.Append(vbCrLf & "    AND FTR_TO = :" & UBound(strBindField) - 1 & " --搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNull(FTR_VOL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_VOL
            strSQL.Append(vbCrLf & "    AND FTR_VOL = :" & UBound(strBindField) - 1 & " --搬送管理量")
        End If
        If IsNull(FTR_INOUT_VOL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_INOUT_VOL
            strSQL.Append(vbCrLf & "    AND FTR_INOUT_VOL = :" & UBound(strBindField) - 1 & " --入出庫数量")
        End If
        If IsNull(FDECIMAL_POINT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDECIMAL_POINT
            strSQL.Append(vbCrLf & "    AND FDECIMAL_POINT = :" & UBound(strBindField) - 1 & " --小数点以下有効桁数")
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
        If IsNull(FREASON_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFREASON_CD
            strSQL.Append(vbCrLf & "    AND FREASON_CD = :" & UBound(strBindField) - 1 & " --理由ｺｰﾄﾞ")
        End If
        If IsNull(FREASON) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFREASON
            strSQL.Append(vbCrLf & "    AND FREASON = :" & UBound(strBindField) - 1 & " --理由")
        End If
        If IsNull(FSAGYOU_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_KIND
            strSQL.Append(vbCrLf & "    AND FSAGYOU_KIND = :" & UBound(strBindField) - 1 & " --作業種別")
        End If
        If IsNull(FLOG_CHECK_DT1) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT1
            strSQL.Append(vbCrLf & "    AND FLOG_CHECK_DT1 = :" & UBound(strBindField) - 1 & " --確認日時_1")
        End If
        If IsNull(FUSER_ID_CHECK1) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID_CHECK1
            strSQL.Append(vbCrLf & "    AND FUSER_ID_CHECK1 = :" & UBound(strBindField) - 1 & " --確認ﾕｰｻﾞｰID_1")
        End If
        If IsNull(FUSER_NAME_CHECK1) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME_CHECK1
            strSQL.Append(vbCrLf & "    AND FUSER_NAME_CHECK1 = :" & UBound(strBindField) - 1 & " --確認ﾕｰｻﾞｰ名_1")
        End If
        If IsNull(FLOG_CHECK_DT2) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT2
            strSQL.Append(vbCrLf & "    AND FLOG_CHECK_DT2 = :" & UBound(strBindField) - 1 & " --確認日時_2")
        End If
        If IsNull(FUSER_ID_CHECK2) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID_CHECK2
            strSQL.Append(vbCrLf & "    AND FUSER_ID_CHECK2 = :" & UBound(strBindField) - 1 & " --確認ﾕｰｻﾞｰID_2")
        End If
        If IsNull(FUSER_NAME_CHECK2) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME_CHECK2
            strSQL.Append(vbCrLf & "    AND FUSER_NAME_CHECK2 = :" & UBound(strBindField) - 1 & " --確認ﾕｰｻﾞｰ名_2")
        End If
        If IsNull(FLOG_CHECK_DT3) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT3
            strSQL.Append(vbCrLf & "    AND FLOG_CHECK_DT3 = :" & UBound(strBindField) - 1 & " --確認日時_3")
        End If
        If IsNull(FUSER_ID_CHECK3) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID_CHECK3
            strSQL.Append(vbCrLf & "    AND FUSER_ID_CHECK3 = :" & UBound(strBindField) - 1 & " --確認ﾕｰｻﾞｰID_3")
        End If
        If IsNull(FUSER_NAME_CHECK3) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME_CHECK3
            strSQL.Append(vbCrLf & "    AND FUSER_NAME_CHECK3 = :" & UBound(strBindField) - 1 & " --確認ﾕｰｻﾞｰ名_3")
        End If
        If IsNull(FLOG_CHECK_DT4) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT4
            strSQL.Append(vbCrLf & "    AND FLOG_CHECK_DT4 = :" & UBound(strBindField) - 1 & " --確認日時_4")
        End If
        If IsNull(FUSER_ID_CHECK4) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID_CHECK4
            strSQL.Append(vbCrLf & "    AND FUSER_ID_CHECK4 = :" & UBound(strBindField) - 1 & " --確認ﾕｰｻﾞｰID_4")
        End If
        If IsNull(FUSER_NAME_CHECK4) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME_CHECK4
            strSQL.Append(vbCrLf & "    AND FUSER_NAME_CHECK4 = :" & UBound(strBindField) - 1 & " --確認ﾕｰｻﾞｰ名_4")
        End If
        If IsNull(FLOG_CHECK_DT5) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT5
            strSQL.Append(vbCrLf & "    AND FLOG_CHECK_DT5 = :" & UBound(strBindField) - 1 & " --確認日時_5")
        End If
        If IsNull(FUSER_ID_CHECK5) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID_CHECK5
            strSQL.Append(vbCrLf & "    AND FUSER_ID_CHECK5 = :" & UBound(strBindField) - 1 & " --確認ﾕｰｻﾞｰID_5")
        End If
        If IsNull(FUSER_NAME_CHECK5) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME_CHECK5
            strSQL.Append(vbCrLf & "    AND FUSER_NAME_CHECK5 = :" & UBound(strBindField) - 1 & " --確認ﾕｰｻﾞｰ名_5")
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
        strDataSetName = "TEVD_SUITOU"
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
    Public Function GET_TEVD_SUITOU_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    TEVD_SUITOU")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FLOG_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            strSQL.Append(vbCrLf & "    AND FLOG_NO = :" & UBound(strBindField) - 1 & " --ﾛｸﾞ№")
        End If
        If IsNull(FLOT_NO_STOCK) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO_STOCK
            strSQL.Append(vbCrLf & "    AND FLOT_NO_STOCK = :" & UBound(strBindField) - 1 & " --在庫ﾛｯﾄ№")
        End If
        If IsNull(FRESULT_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRESULT_DT
            strSQL.Append(vbCrLf & "    AND FRESULT_DT = :" & UBound(strBindField) - 1 & " --実績日時")
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
        If IsNull(FTANI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTANI
            strSQL.Append(vbCrLf & "    AND FTANI = :" & UBound(strBindField) - 1 & " --単位ｺｰﾄﾞ")
        End If
        If IsNull(FTRK_BUF_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNull(FOUT_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFOUT_NAME
            strSQL.Append(vbCrLf & "    AND FOUT_NAME = :" & UBound(strBindField) - 1 & " --搬送先")
        End If
        If IsNull(FTR_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_TO
            strSQL.Append(vbCrLf & "    AND FTR_TO = :" & UBound(strBindField) - 1 & " --搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNull(FTR_VOL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_VOL
            strSQL.Append(vbCrLf & "    AND FTR_VOL = :" & UBound(strBindField) - 1 & " --搬送管理量")
        End If
        If IsNull(FTR_INOUT_VOL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_INOUT_VOL
            strSQL.Append(vbCrLf & "    AND FTR_INOUT_VOL = :" & UBound(strBindField) - 1 & " --入出庫数量")
        End If
        If IsNull(FDECIMAL_POINT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDECIMAL_POINT
            strSQL.Append(vbCrLf & "    AND FDECIMAL_POINT = :" & UBound(strBindField) - 1 & " --小数点以下有効桁数")
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
        If IsNull(FREASON_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFREASON_CD
            strSQL.Append(vbCrLf & "    AND FREASON_CD = :" & UBound(strBindField) - 1 & " --理由ｺｰﾄﾞ")
        End If
        If IsNull(FREASON) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFREASON
            strSQL.Append(vbCrLf & "    AND FREASON = :" & UBound(strBindField) - 1 & " --理由")
        End If
        If IsNull(FSAGYOU_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_KIND
            strSQL.Append(vbCrLf & "    AND FSAGYOU_KIND = :" & UBound(strBindField) - 1 & " --作業種別")
        End If
        If IsNull(FLOG_CHECK_DT1) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT1
            strSQL.Append(vbCrLf & "    AND FLOG_CHECK_DT1 = :" & UBound(strBindField) - 1 & " --確認日時_1")
        End If
        If IsNull(FUSER_ID_CHECK1) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID_CHECK1
            strSQL.Append(vbCrLf & "    AND FUSER_ID_CHECK1 = :" & UBound(strBindField) - 1 & " --確認ﾕｰｻﾞｰID_1")
        End If
        If IsNull(FUSER_NAME_CHECK1) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME_CHECK1
            strSQL.Append(vbCrLf & "    AND FUSER_NAME_CHECK1 = :" & UBound(strBindField) - 1 & " --確認ﾕｰｻﾞｰ名_1")
        End If
        If IsNull(FLOG_CHECK_DT2) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT2
            strSQL.Append(vbCrLf & "    AND FLOG_CHECK_DT2 = :" & UBound(strBindField) - 1 & " --確認日時_2")
        End If
        If IsNull(FUSER_ID_CHECK2) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID_CHECK2
            strSQL.Append(vbCrLf & "    AND FUSER_ID_CHECK2 = :" & UBound(strBindField) - 1 & " --確認ﾕｰｻﾞｰID_2")
        End If
        If IsNull(FUSER_NAME_CHECK2) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME_CHECK2
            strSQL.Append(vbCrLf & "    AND FUSER_NAME_CHECK2 = :" & UBound(strBindField) - 1 & " --確認ﾕｰｻﾞｰ名_2")
        End If
        If IsNull(FLOG_CHECK_DT3) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT3
            strSQL.Append(vbCrLf & "    AND FLOG_CHECK_DT3 = :" & UBound(strBindField) - 1 & " --確認日時_3")
        End If
        If IsNull(FUSER_ID_CHECK3) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID_CHECK3
            strSQL.Append(vbCrLf & "    AND FUSER_ID_CHECK3 = :" & UBound(strBindField) - 1 & " --確認ﾕｰｻﾞｰID_3")
        End If
        If IsNull(FUSER_NAME_CHECK3) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME_CHECK3
            strSQL.Append(vbCrLf & "    AND FUSER_NAME_CHECK3 = :" & UBound(strBindField) - 1 & " --確認ﾕｰｻﾞｰ名_3")
        End If
        If IsNull(FLOG_CHECK_DT4) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT4
            strSQL.Append(vbCrLf & "    AND FLOG_CHECK_DT4 = :" & UBound(strBindField) - 1 & " --確認日時_4")
        End If
        If IsNull(FUSER_ID_CHECK4) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID_CHECK4
            strSQL.Append(vbCrLf & "    AND FUSER_ID_CHECK4 = :" & UBound(strBindField) - 1 & " --確認ﾕｰｻﾞｰID_4")
        End If
        If IsNull(FUSER_NAME_CHECK4) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME_CHECK4
            strSQL.Append(vbCrLf & "    AND FUSER_NAME_CHECK4 = :" & UBound(strBindField) - 1 & " --確認ﾕｰｻﾞｰ名_4")
        End If
        If IsNull(FLOG_CHECK_DT5) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT5
            strSQL.Append(vbCrLf & "    AND FLOG_CHECK_DT5 = :" & UBound(strBindField) - 1 & " --確認日時_5")
        End If
        If IsNull(FUSER_ID_CHECK5) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID_CHECK5
            strSQL.Append(vbCrLf & "    AND FUSER_ID_CHECK5 = :" & UBound(strBindField) - 1 & " --確認ﾕｰｻﾞｰID_5")
        End If
        If IsNull(FUSER_NAME_CHECK5) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME_CHECK5
            strSQL.Append(vbCrLf & "    AND FUSER_NAME_CHECK5 = :" & UBound(strBindField) - 1 & " --確認ﾕｰｻﾞｰ名_5")
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
        strDataSetName = "TEVD_SUITOU"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TEVD_SUITOU(Owner, objDb, objDbLog)
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
    Public Function GET_TEVD_SUITOU_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "TEVD_SUITOU"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TEVD_SUITOU(Owner, objDb, objDbLog)
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
    Public Function GET_TEVD_SUITOU_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    TEVD_SUITOU")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FLOG_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            strSQL.Append(vbCrLf & "    AND FLOG_NO = :" & UBound(strBindField) - 1 & " --ﾛｸﾞ№")
        End If
        If IsNull(FLOT_NO_STOCK) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO_STOCK
            strSQL.Append(vbCrLf & "    AND FLOT_NO_STOCK = :" & UBound(strBindField) - 1 & " --在庫ﾛｯﾄ№")
        End If
        If IsNull(FRESULT_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRESULT_DT
            strSQL.Append(vbCrLf & "    AND FRESULT_DT = :" & UBound(strBindField) - 1 & " --実績日時")
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
        If IsNull(FTANI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTANI
            strSQL.Append(vbCrLf & "    AND FTANI = :" & UBound(strBindField) - 1 & " --単位ｺｰﾄﾞ")
        End If
        If IsNull(FTRK_BUF_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNull(FOUT_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFOUT_NAME
            strSQL.Append(vbCrLf & "    AND FOUT_NAME = :" & UBound(strBindField) - 1 & " --搬送先")
        End If
        If IsNull(FTR_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_TO
            strSQL.Append(vbCrLf & "    AND FTR_TO = :" & UBound(strBindField) - 1 & " --搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNull(FTR_VOL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_VOL
            strSQL.Append(vbCrLf & "    AND FTR_VOL = :" & UBound(strBindField) - 1 & " --搬送管理量")
        End If
        If IsNull(FTR_INOUT_VOL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_INOUT_VOL
            strSQL.Append(vbCrLf & "    AND FTR_INOUT_VOL = :" & UBound(strBindField) - 1 & " --入出庫数量")
        End If
        If IsNull(FDECIMAL_POINT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDECIMAL_POINT
            strSQL.Append(vbCrLf & "    AND FDECIMAL_POINT = :" & UBound(strBindField) - 1 & " --小数点以下有効桁数")
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
        If IsNull(FREASON_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFREASON_CD
            strSQL.Append(vbCrLf & "    AND FREASON_CD = :" & UBound(strBindField) - 1 & " --理由ｺｰﾄﾞ")
        End If
        If IsNull(FREASON) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFREASON
            strSQL.Append(vbCrLf & "    AND FREASON = :" & UBound(strBindField) - 1 & " --理由")
        End If
        If IsNull(FSAGYOU_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_KIND
            strSQL.Append(vbCrLf & "    AND FSAGYOU_KIND = :" & UBound(strBindField) - 1 & " --作業種別")
        End If
        If IsNull(FLOG_CHECK_DT1) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT1
            strSQL.Append(vbCrLf & "    AND FLOG_CHECK_DT1 = :" & UBound(strBindField) - 1 & " --確認日時_1")
        End If
        If IsNull(FUSER_ID_CHECK1) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID_CHECK1
            strSQL.Append(vbCrLf & "    AND FUSER_ID_CHECK1 = :" & UBound(strBindField) - 1 & " --確認ﾕｰｻﾞｰID_1")
        End If
        If IsNull(FUSER_NAME_CHECK1) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME_CHECK1
            strSQL.Append(vbCrLf & "    AND FUSER_NAME_CHECK1 = :" & UBound(strBindField) - 1 & " --確認ﾕｰｻﾞｰ名_1")
        End If
        If IsNull(FLOG_CHECK_DT2) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT2
            strSQL.Append(vbCrLf & "    AND FLOG_CHECK_DT2 = :" & UBound(strBindField) - 1 & " --確認日時_2")
        End If
        If IsNull(FUSER_ID_CHECK2) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID_CHECK2
            strSQL.Append(vbCrLf & "    AND FUSER_ID_CHECK2 = :" & UBound(strBindField) - 1 & " --確認ﾕｰｻﾞｰID_2")
        End If
        If IsNull(FUSER_NAME_CHECK2) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME_CHECK2
            strSQL.Append(vbCrLf & "    AND FUSER_NAME_CHECK2 = :" & UBound(strBindField) - 1 & " --確認ﾕｰｻﾞｰ名_2")
        End If
        If IsNull(FLOG_CHECK_DT3) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT3
            strSQL.Append(vbCrLf & "    AND FLOG_CHECK_DT3 = :" & UBound(strBindField) - 1 & " --確認日時_3")
        End If
        If IsNull(FUSER_ID_CHECK3) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID_CHECK3
            strSQL.Append(vbCrLf & "    AND FUSER_ID_CHECK3 = :" & UBound(strBindField) - 1 & " --確認ﾕｰｻﾞｰID_3")
        End If
        If IsNull(FUSER_NAME_CHECK3) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME_CHECK3
            strSQL.Append(vbCrLf & "    AND FUSER_NAME_CHECK3 = :" & UBound(strBindField) - 1 & " --確認ﾕｰｻﾞｰ名_3")
        End If
        If IsNull(FLOG_CHECK_DT4) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT4
            strSQL.Append(vbCrLf & "    AND FLOG_CHECK_DT4 = :" & UBound(strBindField) - 1 & " --確認日時_4")
        End If
        If IsNull(FUSER_ID_CHECK4) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID_CHECK4
            strSQL.Append(vbCrLf & "    AND FUSER_ID_CHECK4 = :" & UBound(strBindField) - 1 & " --確認ﾕｰｻﾞｰID_4")
        End If
        If IsNull(FUSER_NAME_CHECK4) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME_CHECK4
            strSQL.Append(vbCrLf & "    AND FUSER_NAME_CHECK4 = :" & UBound(strBindField) - 1 & " --確認ﾕｰｻﾞｰ名_4")
        End If
        If IsNull(FLOG_CHECK_DT5) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT5
            strSQL.Append(vbCrLf & "    AND FLOG_CHECK_DT5 = :" & UBound(strBindField) - 1 & " --確認日時_5")
        End If
        If IsNull(FUSER_ID_CHECK5) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID_CHECK5
            strSQL.Append(vbCrLf & "    AND FUSER_ID_CHECK5 = :" & UBound(strBindField) - 1 & " --確認ﾕｰｻﾞｰID_5")
        End If
        If IsNull(FUSER_NAME_CHECK5) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME_CHECK5
            strSQL.Append(vbCrLf & "    AND FUSER_NAME_CHECK5 = :" & UBound(strBindField) - 1 & " --確認ﾕｰｻﾞｰ名_5")
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
        strDataSetName = "TEVD_SUITOU"
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
    Public Sub UPDATE_TEVD_SUITOU()
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
        strSQL.Append(vbCrLf & "    TEVD_SUITOU")
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
        If IsNull(mFLOT_NO_STOCK) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOT_NO_STOCK = NULL --在庫ﾛｯﾄ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOT_NO_STOCK = NULL --在庫ﾛｯﾄ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO_STOCK
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOT_NO_STOCK = :" & Ubound(strBindField) - 1 & " --在庫ﾛｯﾄ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOT_NO_STOCK = :" & Ubound(strBindField) - 1 & " --在庫ﾛｯﾄ№")
        End If
        intCount = intCount + 1
        If IsNull(mFRESULT_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRESULT_DT = NULL --実績日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRESULT_DT = NULL --実績日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRESULT_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRESULT_DT = :" & Ubound(strBindField) - 1 & " --実績日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRESULT_DT = :" & Ubound(strBindField) - 1 & " --実績日時")
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
        If IsNull(mFOUT_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FOUT_NAME = NULL --搬送先")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FOUT_NAME = NULL --搬送先")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFOUT_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FOUT_NAME = :" & Ubound(strBindField) - 1 & " --搬送先")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FOUT_NAME = :" & Ubound(strBindField) - 1 & " --搬送先")
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
        If IsNull(mFTR_INOUT_VOL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTR_INOUT_VOL = NULL --入出庫数量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTR_INOUT_VOL = NULL --入出庫数量")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_INOUT_VOL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTR_INOUT_VOL = :" & Ubound(strBindField) - 1 & " --入出庫数量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTR_INOUT_VOL = :" & Ubound(strBindField) - 1 & " --入出庫数量")
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
        If IsNull(mFREASON_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FREASON_CD = NULL --理由ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FREASON_CD = NULL --理由ｺｰﾄﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFREASON_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FREASON_CD = :" & Ubound(strBindField) - 1 & " --理由ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FREASON_CD = :" & Ubound(strBindField) - 1 & " --理由ｺｰﾄﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFREASON) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FREASON = NULL --理由")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FREASON = NULL --理由")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFREASON
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FREASON = :" & Ubound(strBindField) - 1 & " --理由")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FREASON = :" & Ubound(strBindField) - 1 & " --理由")
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
        If IsNull(mFLOG_CHECK_DT1) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_CHECK_DT1 = NULL --確認日時_1")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_CHECK_DT1 = NULL --確認日時_1")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT1
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_CHECK_DT1 = :" & Ubound(strBindField) - 1 & " --確認日時_1")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_CHECK_DT1 = :" & Ubound(strBindField) - 1 & " --確認日時_1")
        End If
        intCount = intCount + 1
        If IsNull(mFUSER_ID_CHECK1) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUSER_ID_CHECK1 = NULL --確認ﾕｰｻﾞｰID_1")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUSER_ID_CHECK1 = NULL --確認ﾕｰｻﾞｰID_1")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID_CHECK1
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUSER_ID_CHECK1 = :" & Ubound(strBindField) - 1 & " --確認ﾕｰｻﾞｰID_1")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUSER_ID_CHECK1 = :" & Ubound(strBindField) - 1 & " --確認ﾕｰｻﾞｰID_1")
        End If
        intCount = intCount + 1
        If IsNull(mFUSER_NAME_CHECK1) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUSER_NAME_CHECK1 = NULL --確認ﾕｰｻﾞｰ名_1")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUSER_NAME_CHECK1 = NULL --確認ﾕｰｻﾞｰ名_1")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME_CHECK1
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUSER_NAME_CHECK1 = :" & Ubound(strBindField) - 1 & " --確認ﾕｰｻﾞｰ名_1")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUSER_NAME_CHECK1 = :" & Ubound(strBindField) - 1 & " --確認ﾕｰｻﾞｰ名_1")
        End If
        intCount = intCount + 1
        If IsNull(mFLOG_CHECK_DT2) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_CHECK_DT2 = NULL --確認日時_2")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_CHECK_DT2 = NULL --確認日時_2")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT2
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_CHECK_DT2 = :" & Ubound(strBindField) - 1 & " --確認日時_2")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_CHECK_DT2 = :" & Ubound(strBindField) - 1 & " --確認日時_2")
        End If
        intCount = intCount + 1
        If IsNull(mFUSER_ID_CHECK2) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUSER_ID_CHECK2 = NULL --確認ﾕｰｻﾞｰID_2")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUSER_ID_CHECK2 = NULL --確認ﾕｰｻﾞｰID_2")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID_CHECK2
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUSER_ID_CHECK2 = :" & Ubound(strBindField) - 1 & " --確認ﾕｰｻﾞｰID_2")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUSER_ID_CHECK2 = :" & Ubound(strBindField) - 1 & " --確認ﾕｰｻﾞｰID_2")
        End If
        intCount = intCount + 1
        If IsNull(mFUSER_NAME_CHECK2) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUSER_NAME_CHECK2 = NULL --確認ﾕｰｻﾞｰ名_2")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUSER_NAME_CHECK2 = NULL --確認ﾕｰｻﾞｰ名_2")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME_CHECK2
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUSER_NAME_CHECK2 = :" & Ubound(strBindField) - 1 & " --確認ﾕｰｻﾞｰ名_2")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUSER_NAME_CHECK2 = :" & Ubound(strBindField) - 1 & " --確認ﾕｰｻﾞｰ名_2")
        End If
        intCount = intCount + 1
        If IsNull(mFLOG_CHECK_DT3) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_CHECK_DT3 = NULL --確認日時_3")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_CHECK_DT3 = NULL --確認日時_3")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT3
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_CHECK_DT3 = :" & Ubound(strBindField) - 1 & " --確認日時_3")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_CHECK_DT3 = :" & Ubound(strBindField) - 1 & " --確認日時_3")
        End If
        intCount = intCount + 1
        If IsNull(mFUSER_ID_CHECK3) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUSER_ID_CHECK3 = NULL --確認ﾕｰｻﾞｰID_3")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUSER_ID_CHECK3 = NULL --確認ﾕｰｻﾞｰID_3")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID_CHECK3
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUSER_ID_CHECK3 = :" & Ubound(strBindField) - 1 & " --確認ﾕｰｻﾞｰID_3")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUSER_ID_CHECK3 = :" & Ubound(strBindField) - 1 & " --確認ﾕｰｻﾞｰID_3")
        End If
        intCount = intCount + 1
        If IsNull(mFUSER_NAME_CHECK3) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUSER_NAME_CHECK3 = NULL --確認ﾕｰｻﾞｰ名_3")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUSER_NAME_CHECK3 = NULL --確認ﾕｰｻﾞｰ名_3")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME_CHECK3
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUSER_NAME_CHECK3 = :" & Ubound(strBindField) - 1 & " --確認ﾕｰｻﾞｰ名_3")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUSER_NAME_CHECK3 = :" & Ubound(strBindField) - 1 & " --確認ﾕｰｻﾞｰ名_3")
        End If
        intCount = intCount + 1
        If IsNull(mFLOG_CHECK_DT4) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_CHECK_DT4 = NULL --確認日時_4")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_CHECK_DT4 = NULL --確認日時_4")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT4
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_CHECK_DT4 = :" & Ubound(strBindField) - 1 & " --確認日時_4")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_CHECK_DT4 = :" & Ubound(strBindField) - 1 & " --確認日時_4")
        End If
        intCount = intCount + 1
        If IsNull(mFUSER_ID_CHECK4) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUSER_ID_CHECK4 = NULL --確認ﾕｰｻﾞｰID_4")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUSER_ID_CHECK4 = NULL --確認ﾕｰｻﾞｰID_4")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID_CHECK4
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUSER_ID_CHECK4 = :" & Ubound(strBindField) - 1 & " --確認ﾕｰｻﾞｰID_4")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUSER_ID_CHECK4 = :" & Ubound(strBindField) - 1 & " --確認ﾕｰｻﾞｰID_4")
        End If
        intCount = intCount + 1
        If IsNull(mFUSER_NAME_CHECK4) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUSER_NAME_CHECK4 = NULL --確認ﾕｰｻﾞｰ名_4")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUSER_NAME_CHECK4 = NULL --確認ﾕｰｻﾞｰ名_4")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME_CHECK4
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUSER_NAME_CHECK4 = :" & Ubound(strBindField) - 1 & " --確認ﾕｰｻﾞｰ名_4")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUSER_NAME_CHECK4 = :" & Ubound(strBindField) - 1 & " --確認ﾕｰｻﾞｰ名_4")
        End If
        intCount = intCount + 1
        If IsNull(mFLOG_CHECK_DT5) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_CHECK_DT5 = NULL --確認日時_5")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_CHECK_DT5 = NULL --確認日時_5")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT5
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FLOG_CHECK_DT5 = :" & Ubound(strBindField) - 1 & " --確認日時_5")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FLOG_CHECK_DT5 = :" & Ubound(strBindField) - 1 & " --確認日時_5")
        End If
        intCount = intCount + 1
        If IsNull(mFUSER_ID_CHECK5) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUSER_ID_CHECK5 = NULL --確認ﾕｰｻﾞｰID_5")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUSER_ID_CHECK5 = NULL --確認ﾕｰｻﾞｰID_5")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID_CHECK5
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUSER_ID_CHECK5 = :" & Ubound(strBindField) - 1 & " --確認ﾕｰｻﾞｰID_5")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUSER_ID_CHECK5 = :" & Ubound(strBindField) - 1 & " --確認ﾕｰｻﾞｰID_5")
        End If
        intCount = intCount + 1
        If IsNull(mFUSER_NAME_CHECK5) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUSER_NAME_CHECK5 = NULL --確認ﾕｰｻﾞｰ名_5")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUSER_NAME_CHECK5 = NULL --確認ﾕｰｻﾞｰ名_5")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME_CHECK5
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUSER_NAME_CHECK5 = :" & Ubound(strBindField) - 1 & " --確認ﾕｰｻﾞｰ名_5")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUSER_NAME_CHECK5 = :" & Ubound(strBindField) - 1 & " --確認ﾕｰｻﾞｰ名_5")
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
        If IsNull(FLOT_NO_STOCK) = True Then
            strSQL.Append(vbCrLf & "    AND FLOT_NO_STOCK IS NULL --在庫ﾛｯﾄ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO_STOCK
            strSQL.Append(vbCrLf & "    AND FLOT_NO_STOCK = :" & UBound(strBindField) - 1 & " --在庫ﾛｯﾄ№")
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
    Public Sub ADD_TEVD_SUITOU()
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
        strSQL.Append(vbCrLf & "    TEVD_SUITOU")
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
        If IsNull(mFLOT_NO_STOCK) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --在庫ﾛｯﾄ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --在庫ﾛｯﾄ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO_STOCK
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --在庫ﾛｯﾄ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --在庫ﾛｯﾄ№")
        End If
        intCount = intCount + 1
        If IsNull(mFRESULT_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --実績日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --実績日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRESULT_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --実績日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --実績日時")
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
        If IsNull(mFOUT_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --搬送先")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --搬送先")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFOUT_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --搬送先")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --搬送先")
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
        If IsNull(mFTR_INOUT_VOL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --入出庫数量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --入出庫数量")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_INOUT_VOL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --入出庫数量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --入出庫数量")
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
        If IsNull(mFREASON_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --理由ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --理由ｺｰﾄﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFREASON_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --理由ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --理由ｺｰﾄﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFREASON) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --理由")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --理由")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFREASON
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --理由")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --理由")
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
        If IsNull(mFLOG_CHECK_DT1) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --確認日時_1")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --確認日時_1")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT1
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --確認日時_1")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --確認日時_1")
        End If
        intCount = intCount + 1
        If IsNull(mFUSER_ID_CHECK1) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --確認ﾕｰｻﾞｰID_1")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --確認ﾕｰｻﾞｰID_1")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID_CHECK1
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --確認ﾕｰｻﾞｰID_1")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --確認ﾕｰｻﾞｰID_1")
        End If
        intCount = intCount + 1
        If IsNull(mFUSER_NAME_CHECK1) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --確認ﾕｰｻﾞｰ名_1")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --確認ﾕｰｻﾞｰ名_1")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME_CHECK1
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --確認ﾕｰｻﾞｰ名_1")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --確認ﾕｰｻﾞｰ名_1")
        End If
        intCount = intCount + 1
        If IsNull(mFLOG_CHECK_DT2) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --確認日時_2")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --確認日時_2")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT2
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --確認日時_2")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --確認日時_2")
        End If
        intCount = intCount + 1
        If IsNull(mFUSER_ID_CHECK2) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --確認ﾕｰｻﾞｰID_2")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --確認ﾕｰｻﾞｰID_2")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID_CHECK2
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --確認ﾕｰｻﾞｰID_2")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --確認ﾕｰｻﾞｰID_2")
        End If
        intCount = intCount + 1
        If IsNull(mFUSER_NAME_CHECK2) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --確認ﾕｰｻﾞｰ名_2")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --確認ﾕｰｻﾞｰ名_2")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME_CHECK2
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --確認ﾕｰｻﾞｰ名_2")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --確認ﾕｰｻﾞｰ名_2")
        End If
        intCount = intCount + 1
        If IsNull(mFLOG_CHECK_DT3) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --確認日時_3")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --確認日時_3")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT3
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --確認日時_3")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --確認日時_3")
        End If
        intCount = intCount + 1
        If IsNull(mFUSER_ID_CHECK3) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --確認ﾕｰｻﾞｰID_3")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --確認ﾕｰｻﾞｰID_3")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID_CHECK3
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --確認ﾕｰｻﾞｰID_3")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --確認ﾕｰｻﾞｰID_3")
        End If
        intCount = intCount + 1
        If IsNull(mFUSER_NAME_CHECK3) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --確認ﾕｰｻﾞｰ名_3")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --確認ﾕｰｻﾞｰ名_3")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME_CHECK3
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --確認ﾕｰｻﾞｰ名_3")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --確認ﾕｰｻﾞｰ名_3")
        End If
        intCount = intCount + 1
        If IsNull(mFLOG_CHECK_DT4) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --確認日時_4")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --確認日時_4")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT4
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --確認日時_4")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --確認日時_4")
        End If
        intCount = intCount + 1
        If IsNull(mFUSER_ID_CHECK4) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --確認ﾕｰｻﾞｰID_4")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --確認ﾕｰｻﾞｰID_4")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID_CHECK4
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --確認ﾕｰｻﾞｰID_4")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --確認ﾕｰｻﾞｰID_4")
        End If
        intCount = intCount + 1
        If IsNull(mFUSER_NAME_CHECK4) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --確認ﾕｰｻﾞｰ名_4")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --確認ﾕｰｻﾞｰ名_4")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME_CHECK4
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --確認ﾕｰｻﾞｰ名_4")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --確認ﾕｰｻﾞｰ名_4")
        End If
        intCount = intCount + 1
        If IsNull(mFLOG_CHECK_DT5) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --確認日時_5")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --確認日時_5")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT5
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --確認日時_5")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --確認日時_5")
        End If
        intCount = intCount + 1
        If IsNull(mFUSER_ID_CHECK5) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --確認ﾕｰｻﾞｰID_5")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --確認ﾕｰｻﾞｰID_5")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID_CHECK5
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --確認ﾕｰｻﾞｰID_5")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --確認ﾕｰｻﾞｰID_5")
        End If
        intCount = intCount + 1
        If IsNull(mFUSER_NAME_CHECK5) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --確認ﾕｰｻﾞｰ名_5")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --確認ﾕｰｻﾞｰ名_5")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME_CHECK5
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --確認ﾕｰｻﾞｰ名_5")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --確認ﾕｰｻﾞｰ名_5")
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
    Public Sub DELETE_TEVD_SUITOU()
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
        ElseIf IsNull(mFLOT_NO_STOCK) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[在庫ﾛｯﾄ№]"
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
        strSQL.Append(vbCrLf & "    TEVD_SUITOU")
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
        If IsNull(FLOT_NO_STOCK) = True Then
            strSQL.Append(vbCrLf & "    AND FLOT_NO_STOCK IS NULL --在庫ﾛｯﾄ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO_STOCK
            strSQL.Append(vbCrLf & "    AND FLOT_NO_STOCK = :" & UBound(strBindField) - 1 & " --在庫ﾛｯﾄ№")
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
    Public Sub DELETE_TEVD_SUITOU_ANY()
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
        strSQL.Append(vbCrLf & "    TEVD_SUITOU")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(FLOG_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_NO
            strSQL.Append(vbCrLf & "    AND FLOG_NO = :" & UBound(strBindField) - 1 & " --ﾛｸﾞ№")
        End If
        If IsNotNull(FLOT_NO_STOCK) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOT_NO_STOCK
            strSQL.Append(vbCrLf & "    AND FLOT_NO_STOCK = :" & UBound(strBindField) - 1 & " --在庫ﾛｯﾄ№")
        End If
        If IsNotNull(FRESULT_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRESULT_DT
            strSQL.Append(vbCrLf & "    AND FRESULT_DT = :" & UBound(strBindField) - 1 & " --実績日時")
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
        If IsNotNull(FTANI) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTANI
            strSQL.Append(vbCrLf & "    AND FTANI = :" & UBound(strBindField) - 1 & " --単位ｺｰﾄﾞ")
        End If
        If IsNotNull(FTRK_BUF_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNotNull(FOUT_NAME) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFOUT_NAME
            strSQL.Append(vbCrLf & "    AND FOUT_NAME = :" & UBound(strBindField) - 1 & " --搬送先")
        End If
        If IsNotNull(FTR_TO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_TO
            strSQL.Append(vbCrLf & "    AND FTR_TO = :" & UBound(strBindField) - 1 & " --搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNotNull(FTR_VOL) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_VOL
            strSQL.Append(vbCrLf & "    AND FTR_VOL = :" & UBound(strBindField) - 1 & " --搬送管理量")
        End If
        If IsNotNull(FTR_INOUT_VOL) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_INOUT_VOL
            strSQL.Append(vbCrLf & "    AND FTR_INOUT_VOL = :" & UBound(strBindField) - 1 & " --入出庫数量")
        End If
        If IsNotNull(FDECIMAL_POINT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDECIMAL_POINT
            strSQL.Append(vbCrLf & "    AND FDECIMAL_POINT = :" & UBound(strBindField) - 1 & " --小数点以下有効桁数")
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
        If IsNotNull(FREASON_CD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFREASON_CD
            strSQL.Append(vbCrLf & "    AND FREASON_CD = :" & UBound(strBindField) - 1 & " --理由ｺｰﾄﾞ")
        End If
        If IsNotNull(FREASON) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFREASON
            strSQL.Append(vbCrLf & "    AND FREASON = :" & UBound(strBindField) - 1 & " --理由")
        End If
        If IsNotNull(FSAGYOU_KIND) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSAGYOU_KIND
            strSQL.Append(vbCrLf & "    AND FSAGYOU_KIND = :" & UBound(strBindField) - 1 & " --作業種別")
        End If
        If IsNotNull(FLOG_CHECK_DT1) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT1
            strSQL.Append(vbCrLf & "    AND FLOG_CHECK_DT1 = :" & UBound(strBindField) - 1 & " --確認日時_1")
        End If
        If IsNotNull(FUSER_ID_CHECK1) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID_CHECK1
            strSQL.Append(vbCrLf & "    AND FUSER_ID_CHECK1 = :" & UBound(strBindField) - 1 & " --確認ﾕｰｻﾞｰID_1")
        End If
        If IsNotNull(FUSER_NAME_CHECK1) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME_CHECK1
            strSQL.Append(vbCrLf & "    AND FUSER_NAME_CHECK1 = :" & UBound(strBindField) - 1 & " --確認ﾕｰｻﾞｰ名_1")
        End If
        If IsNotNull(FLOG_CHECK_DT2) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT2
            strSQL.Append(vbCrLf & "    AND FLOG_CHECK_DT2 = :" & UBound(strBindField) - 1 & " --確認日時_2")
        End If
        If IsNotNull(FUSER_ID_CHECK2) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID_CHECK2
            strSQL.Append(vbCrLf & "    AND FUSER_ID_CHECK2 = :" & UBound(strBindField) - 1 & " --確認ﾕｰｻﾞｰID_2")
        End If
        If IsNotNull(FUSER_NAME_CHECK2) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME_CHECK2
            strSQL.Append(vbCrLf & "    AND FUSER_NAME_CHECK2 = :" & UBound(strBindField) - 1 & " --確認ﾕｰｻﾞｰ名_2")
        End If
        If IsNotNull(FLOG_CHECK_DT3) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT3
            strSQL.Append(vbCrLf & "    AND FLOG_CHECK_DT3 = :" & UBound(strBindField) - 1 & " --確認日時_3")
        End If
        If IsNotNull(FUSER_ID_CHECK3) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID_CHECK3
            strSQL.Append(vbCrLf & "    AND FUSER_ID_CHECK3 = :" & UBound(strBindField) - 1 & " --確認ﾕｰｻﾞｰID_3")
        End If
        If IsNotNull(FUSER_NAME_CHECK3) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME_CHECK3
            strSQL.Append(vbCrLf & "    AND FUSER_NAME_CHECK3 = :" & UBound(strBindField) - 1 & " --確認ﾕｰｻﾞｰ名_3")
        End If
        If IsNotNull(FLOG_CHECK_DT4) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT4
            strSQL.Append(vbCrLf & "    AND FLOG_CHECK_DT4 = :" & UBound(strBindField) - 1 & " --確認日時_4")
        End If
        If IsNotNull(FUSER_ID_CHECK4) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID_CHECK4
            strSQL.Append(vbCrLf & "    AND FUSER_ID_CHECK4 = :" & UBound(strBindField) - 1 & " --確認ﾕｰｻﾞｰID_4")
        End If
        If IsNotNull(FUSER_NAME_CHECK4) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME_CHECK4
            strSQL.Append(vbCrLf & "    AND FUSER_NAME_CHECK4 = :" & UBound(strBindField) - 1 & " --確認ﾕｰｻﾞｰ名_4")
        End If
        If IsNotNull(FLOG_CHECK_DT5) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFLOG_CHECK_DT5
            strSQL.Append(vbCrLf & "    AND FLOG_CHECK_DT5 = :" & UBound(strBindField) - 1 & " --確認日時_5")
        End If
        If IsNotNull(FUSER_ID_CHECK5) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_ID_CHECK5
            strSQL.Append(vbCrLf & "    AND FUSER_ID_CHECK5 = :" & UBound(strBindField) - 1 & " --確認ﾕｰｻﾞｰID_5")
        End If
        If IsNotNull(FUSER_NAME_CHECK5) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUSER_NAME_CHECK5
            strSQL.Append(vbCrLf & "    AND FUSER_NAME_CHECK5 = :" & UBound(strBindField) - 1 & " --確認ﾕｰｻﾞｰ名_5")
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
        If IsNothing(objType.GetProperty("FLOT_NO_STOCK")) = False Then mFLOT_NO_STOCK = objObject.FLOT_NO_STOCK '在庫ﾛｯﾄ№
        If IsNothing(objType.GetProperty("FRESULT_DT")) = False Then mFRESULT_DT = objObject.FRESULT_DT '実績日時
        If IsNothing(objType.GetProperty("FHINMEI_CD")) = False Then mFHINMEI_CD = objObject.FHINMEI_CD '品目ｺｰﾄﾞ
        If IsNothing(objType.GetProperty("FHINMEI")) = False Then mFHINMEI = objObject.FHINMEI '品名_正式名
        If IsNothing(objType.GetProperty("FLOT_NO")) = False Then mFLOT_NO = objObject.FLOT_NO 'ﾛｯﾄ№
        If IsNothing(objType.GetProperty("FTANI")) = False Then mFTANI = objObject.FTANI '単位ｺｰﾄﾞ
        If IsNothing(objType.GetProperty("FTRK_BUF_NO")) = False Then mFTRK_BUF_NO = objObject.FTRK_BUF_NO 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        If IsNothing(objType.GetProperty("FOUT_NAME")) = False Then mFOUT_NAME = objObject.FOUT_NAME '搬送先
        If IsNothing(objType.GetProperty("FTR_TO")) = False Then mFTR_TO = objObject.FTR_TO '搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        If IsNothing(objType.GetProperty("FTR_VOL")) = False Then mFTR_VOL = objObject.FTR_VOL '搬送管理量
        If IsNothing(objType.GetProperty("FTR_INOUT_VOL")) = False Then mFTR_INOUT_VOL = objObject.FTR_INOUT_VOL '入出庫数量
        If IsNothing(objType.GetProperty("FDECIMAL_POINT")) = False Then mFDECIMAL_POINT = objObject.FDECIMAL_POINT '小数点以下有効桁数
        If IsNothing(objType.GetProperty("FTERM_ID")) = False Then mFTERM_ID = objObject.FTERM_ID '端末ID
        If IsNothing(objType.GetProperty("FTERM_NAME")) = False Then mFTERM_NAME = objObject.FTERM_NAME '端末名
        If IsNothing(objType.GetProperty("FUSER_ID")) = False Then mFUSER_ID = objObject.FUSER_ID 'ﾕｰｻﾞｰID
        If IsNothing(objType.GetProperty("FUSER_NAME")) = False Then mFUSER_NAME = objObject.FUSER_NAME '名前
        If IsNothing(objType.GetProperty("FREASON_CD")) = False Then mFREASON_CD = objObject.FREASON_CD '理由ｺｰﾄﾞ
        If IsNothing(objType.GetProperty("FREASON")) = False Then mFREASON = objObject.FREASON '理由
        If IsNothing(objType.GetProperty("FSAGYOU_KIND")) = False Then mFSAGYOU_KIND = objObject.FSAGYOU_KIND '作業種別
        If IsNothing(objType.GetProperty("FLOG_CHECK_DT1")) = False Then mFLOG_CHECK_DT1 = objObject.FLOG_CHECK_DT1 '確認日時_1
        If IsNothing(objType.GetProperty("FUSER_ID_CHECK1")) = False Then mFUSER_ID_CHECK1 = objObject.FUSER_ID_CHECK1 '確認ﾕｰｻﾞｰID_1
        If IsNothing(objType.GetProperty("FUSER_NAME_CHECK1")) = False Then mFUSER_NAME_CHECK1 = objObject.FUSER_NAME_CHECK1 '確認ﾕｰｻﾞｰ名_1
        If IsNothing(objType.GetProperty("FLOG_CHECK_DT2")) = False Then mFLOG_CHECK_DT2 = objObject.FLOG_CHECK_DT2 '確認日時_2
        If IsNothing(objType.GetProperty("FUSER_ID_CHECK2")) = False Then mFUSER_ID_CHECK2 = objObject.FUSER_ID_CHECK2 '確認ﾕｰｻﾞｰID_2
        If IsNothing(objType.GetProperty("FUSER_NAME_CHECK2")) = False Then mFUSER_NAME_CHECK2 = objObject.FUSER_NAME_CHECK2 '確認ﾕｰｻﾞｰ名_2
        If IsNothing(objType.GetProperty("FLOG_CHECK_DT3")) = False Then mFLOG_CHECK_DT3 = objObject.FLOG_CHECK_DT3 '確認日時_3
        If IsNothing(objType.GetProperty("FUSER_ID_CHECK3")) = False Then mFUSER_ID_CHECK3 = objObject.FUSER_ID_CHECK3 '確認ﾕｰｻﾞｰID_3
        If IsNothing(objType.GetProperty("FUSER_NAME_CHECK3")) = False Then mFUSER_NAME_CHECK3 = objObject.FUSER_NAME_CHECK3 '確認ﾕｰｻﾞｰ名_3
        If IsNothing(objType.GetProperty("FLOG_CHECK_DT4")) = False Then mFLOG_CHECK_DT4 = objObject.FLOG_CHECK_DT4 '確認日時_4
        If IsNothing(objType.GetProperty("FUSER_ID_CHECK4")) = False Then mFUSER_ID_CHECK4 = objObject.FUSER_ID_CHECK4 '確認ﾕｰｻﾞｰID_4
        If IsNothing(objType.GetProperty("FUSER_NAME_CHECK4")) = False Then mFUSER_NAME_CHECK4 = objObject.FUSER_NAME_CHECK4 '確認ﾕｰｻﾞｰ名_4
        If IsNothing(objType.GetProperty("FLOG_CHECK_DT5")) = False Then mFLOG_CHECK_DT5 = objObject.FLOG_CHECK_DT5 '確認日時_5
        If IsNothing(objType.GetProperty("FUSER_ID_CHECK5")) = False Then mFUSER_ID_CHECK5 = objObject.FUSER_ID_CHECK5 '確認ﾕｰｻﾞｰID_5
        If IsNothing(objType.GetProperty("FUSER_NAME_CHECK5")) = False Then mFUSER_NAME_CHECK5 = objObject.FUSER_NAME_CHECK5 '確認ﾕｰｻﾞｰ名_5
        If IsNothing(objType.GetProperty("FSYUKKA_TO_CD")) = False Then mFSYUKKA_TO_CD = objObject.FSYUKKA_TO_CD '出荷先ｺｰﾄﾞ
        If IsNothing(objType.GetProperty("FSYUKKA_TO_NAME")) = False Then mFSYUKKA_TO_NAME = objObject.FSYUKKA_TO_NAME '出荷先名称

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
        mFLOT_NO_STOCK = Nothing
        mFRESULT_DT = Nothing
        mFHINMEI_CD = Nothing
        mFHINMEI = Nothing
        mFLOT_NO = Nothing
        mFTANI = Nothing
        mFTRK_BUF_NO = Nothing
        mFOUT_NAME = Nothing
        mFTR_TO = Nothing
        mFTR_VOL = Nothing
        mFTR_INOUT_VOL = Nothing
        mFDECIMAL_POINT = Nothing
        mFTERM_ID = Nothing
        mFTERM_NAME = Nothing
        mFUSER_ID = Nothing
        mFUSER_NAME = Nothing
        mFREASON_CD = Nothing
        mFREASON = Nothing
        mFSAGYOU_KIND = Nothing
        mFLOG_CHECK_DT1 = Nothing
        mFUSER_ID_CHECK1 = Nothing
        mFUSER_NAME_CHECK1 = Nothing
        mFLOG_CHECK_DT2 = Nothing
        mFUSER_ID_CHECK2 = Nothing
        mFUSER_NAME_CHECK2 = Nothing
        mFLOG_CHECK_DT3 = Nothing
        mFUSER_ID_CHECK3 = Nothing
        mFUSER_NAME_CHECK3 = Nothing
        mFLOG_CHECK_DT4 = Nothing
        mFUSER_ID_CHECK4 = Nothing
        mFUSER_NAME_CHECK4 = Nothing
        mFLOG_CHECK_DT5 = Nothing
        mFUSER_ID_CHECK5 = Nothing
        mFUSER_NAME_CHECK5 = Nothing
        mFSYUKKA_TO_CD = Nothing
        mFSYUKKA_TO_NAME = Nothing


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
        mFLOT_NO_STOCK = TO_STRING_NULLABLE(objRow("FLOT_NO_STOCK"))
        mFRESULT_DT = TO_DATE_NULLABLE(objRow("FRESULT_DT"))
        mFHINMEI_CD = TO_STRING_NULLABLE(objRow("FHINMEI_CD"))
        mFHINMEI = TO_STRING_NULLABLE(objRow("FHINMEI"))
        mFLOT_NO = TO_STRING_NULLABLE(objRow("FLOT_NO"))
        mFTANI = TO_STRING_NULLABLE(objRow("FTANI"))
        mFTRK_BUF_NO = TO_INTEGER_NULLABLE(objRow("FTRK_BUF_NO"))
        mFOUT_NAME = TO_STRING_NULLABLE(objRow("FOUT_NAME"))
        mFTR_TO = TO_INTEGER_NULLABLE(objRow("FTR_TO"))
        mFTR_VOL = TO_DECIMAL_NULLABLE(objRow("FTR_VOL"))
        mFTR_INOUT_VOL = TO_DECIMAL_NULLABLE(objRow("FTR_INOUT_VOL"))
        mFDECIMAL_POINT = TO_INTEGER_NULLABLE(objRow("FDECIMAL_POINT"))
        mFTERM_ID = TO_STRING_NULLABLE(objRow("FTERM_ID"))
        mFTERM_NAME = TO_STRING_NULLABLE(objRow("FTERM_NAME"))
        mFUSER_ID = TO_STRING_NULLABLE(objRow("FUSER_ID"))
        mFUSER_NAME = TO_STRING_NULLABLE(objRow("FUSER_NAME"))
        mFREASON_CD = TO_STRING_NULLABLE(objRow("FREASON_CD"))
        mFREASON = TO_STRING_NULLABLE(objRow("FREASON"))
        mFSAGYOU_KIND = TO_INTEGER_NULLABLE(objRow("FSAGYOU_KIND"))
        mFLOG_CHECK_DT1 = TO_DATE_NULLABLE(objRow("FLOG_CHECK_DT1"))
        mFUSER_ID_CHECK1 = TO_STRING_NULLABLE(objRow("FUSER_ID_CHECK1"))
        mFUSER_NAME_CHECK1 = TO_STRING_NULLABLE(objRow("FUSER_NAME_CHECK1"))
        mFLOG_CHECK_DT2 = TO_DATE_NULLABLE(objRow("FLOG_CHECK_DT2"))
        mFUSER_ID_CHECK2 = TO_STRING_NULLABLE(objRow("FUSER_ID_CHECK2"))
        mFUSER_NAME_CHECK2 = TO_STRING_NULLABLE(objRow("FUSER_NAME_CHECK2"))
        mFLOG_CHECK_DT3 = TO_DATE_NULLABLE(objRow("FLOG_CHECK_DT3"))
        mFUSER_ID_CHECK3 = TO_STRING_NULLABLE(objRow("FUSER_ID_CHECK3"))
        mFUSER_NAME_CHECK3 = TO_STRING_NULLABLE(objRow("FUSER_NAME_CHECK3"))
        mFLOG_CHECK_DT4 = TO_DATE_NULLABLE(objRow("FLOG_CHECK_DT4"))
        mFUSER_ID_CHECK4 = TO_STRING_NULLABLE(objRow("FUSER_ID_CHECK4"))
        mFUSER_NAME_CHECK4 = TO_STRING_NULLABLE(objRow("FUSER_NAME_CHECK4"))
        mFLOG_CHECK_DT5 = TO_DATE_NULLABLE(objRow("FLOG_CHECK_DT5"))
        mFUSER_ID_CHECK5 = TO_STRING_NULLABLE(objRow("FUSER_ID_CHECK5"))
        mFUSER_NAME_CHECK5 = TO_STRING_NULLABLE(objRow("FUSER_NAME_CHECK5"))
        mFSYUKKA_TO_CD = TO_STRING_NULLABLE(objRow("FSYUKKA_TO_CD"))
        mFSYUKKA_TO_NAME = TO_STRING_NULLABLE(objRow("FSYUKKA_TO_NAME"))


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
        strMsg &= "[ﾃｰﾌﾞﾙ名:保管出納記録]"
        If IsNotNull(FLOG_NO) Then
            strMsg &= "[ﾛｸﾞ№:" & FLOG_NO & "]"
        End If
        If IsNotNull(FLOT_NO_STOCK) Then
            strMsg &= "[在庫ﾛｯﾄ№:" & FLOT_NO_STOCK & "]"
        End If
        If IsNotNull(FRESULT_DT) Then
            strMsg &= "[実績日時:" & FRESULT_DT & "]"
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
        If IsNotNull(FTANI) Then
            strMsg &= "[単位ｺｰﾄﾞ:" & FTANI & "]"
        End If
        If IsNotNull(FTRK_BUF_NO) Then
            strMsg &= "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & FTRK_BUF_NO & "]"
        End If
        If IsNotNull(FOUT_NAME) Then
            strMsg &= "[搬送先:" & FOUT_NAME & "]"
        End If
        If IsNotNull(FTR_TO) Then
            strMsg &= "[搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & FTR_TO & "]"
        End If
        If IsNotNull(FTR_VOL) Then
            strMsg &= "[搬送管理量:" & FTR_VOL & "]"
        End If
        If IsNotNull(FTR_INOUT_VOL) Then
            strMsg &= "[入出庫数量:" & FTR_INOUT_VOL & "]"
        End If
        If IsNotNull(FDECIMAL_POINT) Then
            strMsg &= "[小数点以下有効桁数:" & FDECIMAL_POINT & "]"
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
        If IsNotNull(FREASON_CD) Then
            strMsg &= "[理由ｺｰﾄﾞ:" & FREASON_CD & "]"
        End If
        If IsNotNull(FREASON) Then
            strMsg &= "[理由:" & FREASON & "]"
        End If
        If IsNotNull(FSAGYOU_KIND) Then
            strMsg &= "[作業種別:" & FSAGYOU_KIND & "]"
        End If
        If IsNotNull(FLOG_CHECK_DT1) Then
            strMsg &= "[確認日時_1:" & FLOG_CHECK_DT1 & "]"
        End If
        If IsNotNull(FUSER_ID_CHECK1) Then
            strMsg &= "[確認ﾕｰｻﾞｰID_1:" & FUSER_ID_CHECK1 & "]"
        End If
        If IsNotNull(FUSER_NAME_CHECK1) Then
            strMsg &= "[確認ﾕｰｻﾞｰ名_1:" & FUSER_NAME_CHECK1 & "]"
        End If
        If IsNotNull(FLOG_CHECK_DT2) Then
            strMsg &= "[確認日時_2:" & FLOG_CHECK_DT2 & "]"
        End If
        If IsNotNull(FUSER_ID_CHECK2) Then
            strMsg &= "[確認ﾕｰｻﾞｰID_2:" & FUSER_ID_CHECK2 & "]"
        End If
        If IsNotNull(FUSER_NAME_CHECK2) Then
            strMsg &= "[確認ﾕｰｻﾞｰ名_2:" & FUSER_NAME_CHECK2 & "]"
        End If
        If IsNotNull(FLOG_CHECK_DT3) Then
            strMsg &= "[確認日時_3:" & FLOG_CHECK_DT3 & "]"
        End If
        If IsNotNull(FUSER_ID_CHECK3) Then
            strMsg &= "[確認ﾕｰｻﾞｰID_3:" & FUSER_ID_CHECK3 & "]"
        End If
        If IsNotNull(FUSER_NAME_CHECK3) Then
            strMsg &= "[確認ﾕｰｻﾞｰ名_3:" & FUSER_NAME_CHECK3 & "]"
        End If
        If IsNotNull(FLOG_CHECK_DT4) Then
            strMsg &= "[確認日時_4:" & FLOG_CHECK_DT4 & "]"
        End If
        If IsNotNull(FUSER_ID_CHECK4) Then
            strMsg &= "[確認ﾕｰｻﾞｰID_4:" & FUSER_ID_CHECK4 & "]"
        End If
        If IsNotNull(FUSER_NAME_CHECK4) Then
            strMsg &= "[確認ﾕｰｻﾞｰ名_4:" & FUSER_NAME_CHECK4 & "]"
        End If
        If IsNotNull(FLOG_CHECK_DT5) Then
            strMsg &= "[確認日時_5:" & FLOG_CHECK_DT5 & "]"
        End If
        If IsNotNull(FUSER_ID_CHECK5) Then
            strMsg &= "[確認ﾕｰｻﾞｰID_5:" & FUSER_ID_CHECK5 & "]"
        End If
        If IsNotNull(FUSER_NAME_CHECK5) Then
            strMsg &= "[確認ﾕｰｻﾞｰ名_5:" & FUSER_NAME_CHECK5 & "]"
        End If
        If IsNotNull(FSYUKKA_TO_CD) Then
            strMsg &= "[出荷先ｺｰﾄﾞ:" & FSYUKKA_TO_CD & "]"
        End If
        If IsNotNull(FSYUKKA_TO_NAME) Then
            strMsg &= "[出荷先名称:" & FSYUKKA_TO_NAME & "]"
        End If


    End Sub
#End Region
    '↑↑↑自動生成部
    '**********************************************************************************************

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ共通
#Region "  保管出納記録追加  [SEQ発番]              (Public  ADD_TEVD_SUITOU_SEQ)"
    Public Sub ADD_TEVD_SUITOU_SEQ()
        Try


            '***********************
            'ﾛｸﾞ№の特定
            '***********************
            Dim objTPRG_SEQNO As New TBL_TPRG_SEQNO(Owner, ObjDb, ObjDbLog) 'ｼｰｹﾝｽ№ｸﾗｽ
            objTPRG_SEQNO.FSEQ_ID = FSEQ_ID_SSVRLOG_NO_SUITOU                'ｼｰｹﾝｽID
            mFLOG_NO = objTPRG_SEQNO.GET_ENTRY_NO()                         'SEQ№の特定


            '***********************
            '追加
            '***********************
            Me.ADD_TEVD_SUITOU()


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
