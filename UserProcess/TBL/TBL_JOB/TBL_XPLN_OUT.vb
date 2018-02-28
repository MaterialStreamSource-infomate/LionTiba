'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' 【名称】MaterialStreamﾃｰﾌﾞﾙｸﾗｽ
' 【機能】出荷指示ﾃｰﾌﾞﾙｸﾗｽ
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
''' 出荷指示ﾃｰﾌﾞﾙｸﾗｽ
''' </summary>
Public Class TBL_XPLN_OUT
    Inherits clsTemplateTable

    '**********************************************************************************************
    '↓↓↓自動生成部
#Region "  ｸﾗｽ変数定義                  "
    'ﾌﾟﾛﾊﾟﾃｨ
    Private mobjAryMe As TBL_XPLN_OUT()                                          '出荷指示
    Private mstrUSER_SQL As String                                               'ﾕｰｻﾞｰSQL
    Private mORDER_BY As String                                                  'OrderBy句
    Private mWHERE As String                                                     'Where句
    Private mXSYUKKA_D As Nullable(Of Date)                                      '出荷日
    Private mXHENSEI_NO As String                                                '編成No.
    Private mXDATA_KIND As String                                                'ﾃﾞｰﾀ種類
    Private mXEDIT_KBN As String                                                 '編集区分
    Private mXINPUT_PLACE As String                                              'ｲﾝﾌﾟｯﾄ場所
    Private mXINPUT_DT As Nullable(Of Date)                                      'ｲﾝﾌﾟｯﾄ日付
    Private mXINPUT_NO As String                                                 'ｲﾝﾌﾟｯﾄNo.
    Private mXDENPYOU_NO As String                                               '伝票No.
    Private mXBUNRUI_NO As String                                                '分類No.
    Private mXDATA_DT As Nullable(Of Date)                                       'ﾃﾞｰﾀ日付
    Private mXSOUKO_CD As String                                                 '倉庫ｺｰﾄﾞ
    Private mXTOU_NO As String                                                   '棟ｺｰﾄﾞ
    Private mXTORIHIKI_KBN As String                                             '取引区分
    Private mXDATA_SYORI As String                                               'ﾃﾞｰﾀ処理
    Private mXGYOUSYA_CD As String                                               '物流業者ｺｰﾄﾞ
    Private mXGYOUSYA_KBN As String                                              '業者区分
    Private mXSYARYOU_NO As Nullable(Of Integer)                                 '車輌番号
    Private mXUNKOU_NO As String                                                 '倉庫別運行No.
    Private mXTUMI_HOUKOU As Nullable(Of Integer)                                '積込方向
    Private mXTUMI_HOUHOU As Nullable(Of Integer)                                '積込方法
    Private mXSYASYU_KBN As String                                               '車種区分
    Private mXHENSEI_NO_OYA As String                                            '親編成No.
    Private mXSEND_NAME As String                                                '届け先名称
    Private mXSEND_ADDRESS As String                                             '届け先住所
    Private mXBERTH_NO As String                                                 'ﾊﾞｰｽNo.
    Private mXKINKYU_KBN As Nullable(Of Integer)                                 '緊急出荷区分
    Private mXKINKYU_LEVEL As Nullable(Of Integer)                               '緊急度
    Private mXSYARYOU_ENTRY_DT As Nullable(Of Date)                              '車輌受付日時
    Private mXSYUKKA_DIR_DT As Nullable(Of Date)                                 '出荷指示日時
    Private mXOUT_START_DT As Nullable(Of Date)                                  '出庫開始日時
    Private mXOUT_END_DT As Nullable(Of Date)                                    '出庫完了日時
    Private mXTUMI_END_DT As Nullable(Of Date)                                   '積込完了日時
    Private mXSYUKKA_STS As Nullable(Of Integer)                                 '出荷状況
    Private mXIKKATU_SYUKKO As Nullable(Of Integer)                              '一括出庫指定
    Private mFENTRY_DT As Nullable(Of Date)                                      '登録日時
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                  "
    ''' <summary>
    ''' ｼｽﾃﾑ変数 (自ｸﾗｽ型配列)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_XPLN_OUT()
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
    ''' ﾃﾞｰﾀ種類
    ''' </summary>
    Public Property XDATA_KIND() As String
        Get
            Return mXDATA_KIND
        End Get
        Set(ByVal Value As String)
            mXDATA_KIND = Value
        End Set
    End Property
    ''' <summary>
    ''' 編集区分
    ''' </summary>
    Public Property XEDIT_KBN() As String
        Get
            Return mXEDIT_KBN
        End Get
        Set(ByVal Value As String)
            mXEDIT_KBN = Value
        End Set
    End Property
    ''' <summary>
    ''' ｲﾝﾌﾟｯﾄ場所
    ''' </summary>
    Public Property XINPUT_PLACE() As String
        Get
            Return mXINPUT_PLACE
        End Get
        Set(ByVal Value As String)
            mXINPUT_PLACE = Value
        End Set
    End Property
    ''' <summary>
    ''' ｲﾝﾌﾟｯﾄ日付
    ''' </summary>
    Public Property XINPUT_DT() As Nullable(Of Date)
        Get
            Return mXINPUT_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mXINPUT_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' ｲﾝﾌﾟｯﾄNo.
    ''' </summary>
    Public Property XINPUT_NO() As String
        Get
            Return mXINPUT_NO
        End Get
        Set(ByVal Value As String)
            mXINPUT_NO = Value
        End Set
    End Property
    ''' <summary>
    ''' 伝票No.
    ''' </summary>
    Public Property XDENPYOU_NO() As String
        Get
            Return mXDENPYOU_NO
        End Get
        Set(ByVal Value As String)
            mXDENPYOU_NO = Value
        End Set
    End Property
    ''' <summary>
    ''' 分類No.
    ''' </summary>
    Public Property XBUNRUI_NO() As String
        Get
            Return mXBUNRUI_NO
        End Get
        Set(ByVal Value As String)
            mXBUNRUI_NO = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾃﾞｰﾀ日付
    ''' </summary>
    Public Property XDATA_DT() As Nullable(Of Date)
        Get
            Return mXDATA_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mXDATA_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' 倉庫ｺｰﾄﾞ
    ''' </summary>
    Public Property XSOUKO_CD() As String
        Get
            Return mXSOUKO_CD
        End Get
        Set(ByVal Value As String)
            mXSOUKO_CD = Value
        End Set
    End Property
    ''' <summary>
    ''' 棟ｺｰﾄﾞ
    ''' </summary>
    Public Property XTOU_NO() As String
        Get
            Return mXTOU_NO
        End Get
        Set(ByVal Value As String)
            mXTOU_NO = Value
        End Set
    End Property
    ''' <summary>
    ''' 取引区分
    ''' </summary>
    Public Property XTORIHIKI_KBN() As String
        Get
            Return mXTORIHIKI_KBN
        End Get
        Set(ByVal Value As String)
            mXTORIHIKI_KBN = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾃﾞｰﾀ処理
    ''' </summary>
    Public Property XDATA_SYORI() As String
        Get
            Return mXDATA_SYORI
        End Get
        Set(ByVal Value As String)
            mXDATA_SYORI = Value
        End Set
    End Property
    ''' <summary>
    ''' 物流業者ｺｰﾄﾞ
    ''' </summary>
    Public Property XGYOUSYA_CD() As String
        Get
            Return mXGYOUSYA_CD
        End Get
        Set(ByVal Value As String)
            mXGYOUSYA_CD = Value
        End Set
    End Property
    ''' <summary>
    ''' 業者区分
    ''' </summary>
    Public Property XGYOUSYA_KBN() As String
        Get
            Return mXGYOUSYA_KBN
        End Get
        Set(ByVal Value As String)
            mXGYOUSYA_KBN = Value
        End Set
    End Property
    ''' <summary>
    ''' 車輌番号
    ''' </summary>
    Public Property XSYARYOU_NO() As Nullable(Of Integer)
        Get
            Return mXSYARYOU_NO
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXSYARYOU_NO = Value
        End Set
    End Property
    ''' <summary>
    ''' 倉庫別運行No.
    ''' </summary>
    Public Property XUNKOU_NO() As String
        Get
            Return mXUNKOU_NO
        End Get
        Set(ByVal Value As String)
            mXUNKOU_NO = Value
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
    ''' 積込方法
    ''' </summary>
    Public Property XTUMI_HOUHOU() As Nullable(Of Integer)
        Get
            Return mXTUMI_HOUHOU
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXTUMI_HOUHOU = Value
        End Set
    End Property
    ''' <summary>
    ''' 車種区分
    ''' </summary>
    Public Property XSYASYU_KBN() As String
        Get
            Return mXSYASYU_KBN
        End Get
        Set(ByVal Value As String)
            mXSYASYU_KBN = Value
        End Set
    End Property
    ''' <summary>
    ''' 親編成No.
    ''' </summary>
    Public Property XHENSEI_NO_OYA() As String
        Get
            Return mXHENSEI_NO_OYA
        End Get
        Set(ByVal Value As String)
            mXHENSEI_NO_OYA = Value
        End Set
    End Property
    ''' <summary>
    ''' 届け先名称
    ''' </summary>
    Public Property XSEND_NAME() As String
        Get
            Return mXSEND_NAME
        End Get
        Set(ByVal Value As String)
            mXSEND_NAME = Value
        End Set
    End Property
    ''' <summary>
    ''' 届け先住所
    ''' </summary>
    Public Property XSEND_ADDRESS() As String
        Get
            Return mXSEND_ADDRESS
        End Get
        Set(ByVal Value As String)
            mXSEND_ADDRESS = Value
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
    ''' 緊急出荷区分
    ''' </summary>
    Public Property XKINKYU_KBN() As Nullable(Of Integer)
        Get
            Return mXKINKYU_KBN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXKINKYU_KBN = Value
        End Set
    End Property
    ''' <summary>
    ''' 緊急度
    ''' </summary>
    Public Property XKINKYU_LEVEL() As Nullable(Of Integer)
        Get
            Return mXKINKYU_LEVEL
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXKINKYU_LEVEL = Value
        End Set
    End Property
    ''' <summary>
    ''' 車輌受付日時
    ''' </summary>
    Public Property XSYARYOU_ENTRY_DT() As Nullable(Of Date)
        Get
            Return mXSYARYOU_ENTRY_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mXSYARYOU_ENTRY_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' 出荷指示日時
    ''' </summary>
    Public Property XSYUKKA_DIR_DT() As Nullable(Of Date)
        Get
            Return mXSYUKKA_DIR_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mXSYUKKA_DIR_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' 出庫開始日時
    ''' </summary>
    Public Property XOUT_START_DT() As Nullable(Of Date)
        Get
            Return mXOUT_START_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mXOUT_START_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' 出庫完了日時
    ''' </summary>
    Public Property XOUT_END_DT() As Nullable(Of Date)
        Get
            Return mXOUT_END_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mXOUT_END_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' 積込完了日時
    ''' </summary>
    Public Property XTUMI_END_DT() As Nullable(Of Date)
        Get
            Return mXTUMI_END_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mXTUMI_END_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' 出荷状況
    ''' </summary>
    Public Property XSYUKKA_STS() As Nullable(Of Integer)
        Get
            Return mXSYUKKA_STS
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXSYUKKA_STS = Value
        End Set
    End Property
    ''' <summary>
    ''' 一括出庫指定
    ''' </summary>
    Public Property XIKKATU_SYUKKO() As Nullable(Of Integer)
        Get
            Return mXIKKATU_SYUKKO
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXIKKATU_SYUKKO = Value
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
    Public Function GET_XPLN_OUT(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    XPLN_OUT")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
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
        If IsNull(XDATA_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDATA_KIND
            strSQL.Append(vbCrLf & "    AND XDATA_KIND = :" & UBound(strBindField) - 1 & " --ﾃﾞｰﾀ種類")
        End If
        If IsNull(XEDIT_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEDIT_KBN
            strSQL.Append(vbCrLf & "    AND XEDIT_KBN = :" & UBound(strBindField) - 1 & " --編集区分")
        End If
        If IsNull(XINPUT_PLACE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXINPUT_PLACE
            strSQL.Append(vbCrLf & "    AND XINPUT_PLACE = :" & UBound(strBindField) - 1 & " --ｲﾝﾌﾟｯﾄ場所")
        End If
        If IsNull(XINPUT_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXINPUT_DT
            strSQL.Append(vbCrLf & "    AND XINPUT_DT = :" & UBound(strBindField) - 1 & " --ｲﾝﾌﾟｯﾄ日付")
        End If
        If IsNull(XINPUT_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXINPUT_NO
            strSQL.Append(vbCrLf & "    AND XINPUT_NO = :" & UBound(strBindField) - 1 & " --ｲﾝﾌﾟｯﾄNo.")
        End If
        If IsNull(XDENPYOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDENPYOU_NO
            strSQL.Append(vbCrLf & "    AND XDENPYOU_NO = :" & UBound(strBindField) - 1 & " --伝票No.")
        End If
        If IsNull(XBUNRUI_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBUNRUI_NO
            strSQL.Append(vbCrLf & "    AND XBUNRUI_NO = :" & UBound(strBindField) - 1 & " --分類No.")
        End If
        If IsNull(XDATA_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDATA_DT
            strSQL.Append(vbCrLf & "    AND XDATA_DT = :" & UBound(strBindField) - 1 & " --ﾃﾞｰﾀ日付")
        End If
        If IsNull(XSOUKO_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSOUKO_CD
            strSQL.Append(vbCrLf & "    AND XSOUKO_CD = :" & UBound(strBindField) - 1 & " --倉庫ｺｰﾄﾞ")
        End If
        If IsNull(XTOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTOU_NO
            strSQL.Append(vbCrLf & "    AND XTOU_NO = :" & UBound(strBindField) - 1 & " --棟ｺｰﾄﾞ")
        End If
        If IsNull(XTORIHIKI_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTORIHIKI_KBN
            strSQL.Append(vbCrLf & "    AND XTORIHIKI_KBN = :" & UBound(strBindField) - 1 & " --取引区分")
        End If
        If IsNull(XDATA_SYORI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDATA_SYORI
            strSQL.Append(vbCrLf & "    AND XDATA_SYORI = :" & UBound(strBindField) - 1 & " --ﾃﾞｰﾀ処理")
        End If
        If IsNull(XGYOUSYA_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_CD
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_CD = :" & UBound(strBindField) - 1 & " --物流業者ｺｰﾄﾞ")
        End If
        If IsNull(XGYOUSYA_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_KBN
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_KBN = :" & UBound(strBindField) - 1 & " --業者区分")
        End If
        If IsNull(XSYARYOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYARYOU_NO
            strSQL.Append(vbCrLf & "    AND XSYARYOU_NO = :" & UBound(strBindField) - 1 & " --車輌番号")
        End If
        If IsNull(XUNKOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXUNKOU_NO
            strSQL.Append(vbCrLf & "    AND XUNKOU_NO = :" & UBound(strBindField) - 1 & " --倉庫別運行No.")
        End If
        If IsNull(XTUMI_HOUKOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_HOUKOU
            strSQL.Append(vbCrLf & "    AND XTUMI_HOUKOU = :" & UBound(strBindField) - 1 & " --積込方向")
        End If
        If IsNull(XTUMI_HOUHOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_HOUHOU
            strSQL.Append(vbCrLf & "    AND XTUMI_HOUHOU = :" & UBound(strBindField) - 1 & " --積込方法")
        End If
        If IsNull(XSYASYU_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYASYU_KBN
            strSQL.Append(vbCrLf & "    AND XSYASYU_KBN = :" & UBound(strBindField) - 1 & " --車種区分")
        End If
        If IsNull(XHENSEI_NO_OYA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO_OYA = :" & UBound(strBindField) - 1 & " --親編成No.")
        End If
        If IsNull(XSEND_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSEND_NAME
            strSQL.Append(vbCrLf & "    AND XSEND_NAME = :" & UBound(strBindField) - 1 & " --届け先名称")
        End If
        If IsNull(XSEND_ADDRESS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSEND_ADDRESS
            strSQL.Append(vbCrLf & "    AND XSEND_ADDRESS = :" & UBound(strBindField) - 1 & " --届け先住所")
        End If
        If IsNull(XBERTH_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_NO
            strSQL.Append(vbCrLf & "    AND XBERTH_NO = :" & UBound(strBindField) - 1 & " --ﾊﾞｰｽNo.")
        End If
        If IsNull(XKINKYU_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKINKYU_KBN
            strSQL.Append(vbCrLf & "    AND XKINKYU_KBN = :" & UBound(strBindField) - 1 & " --緊急出荷区分")
        End If
        If IsNull(XKINKYU_LEVEL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKINKYU_LEVEL
            strSQL.Append(vbCrLf & "    AND XKINKYU_LEVEL = :" & UBound(strBindField) - 1 & " --緊急度")
        End If
        If IsNull(XSYARYOU_ENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYARYOU_ENTRY_DT
            strSQL.Append(vbCrLf & "    AND XSYARYOU_ENTRY_DT = :" & UBound(strBindField) - 1 & " --車輌受付日時")
        End If
        If IsNull(XSYUKKA_DIR_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_DIR_DT
            strSQL.Append(vbCrLf & "    AND XSYUKKA_DIR_DT = :" & UBound(strBindField) - 1 & " --出荷指示日時")
        End If
        If IsNull(XOUT_START_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_START_DT
            strSQL.Append(vbCrLf & "    AND XOUT_START_DT = :" & UBound(strBindField) - 1 & " --出庫開始日時")
        End If
        If IsNull(XOUT_END_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_END_DT
            strSQL.Append(vbCrLf & "    AND XOUT_END_DT = :" & UBound(strBindField) - 1 & " --出庫完了日時")
        End If
        If IsNull(XTUMI_END_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_END_DT
            strSQL.Append(vbCrLf & "    AND XTUMI_END_DT = :" & UBound(strBindField) - 1 & " --積込完了日時")
        End If
        If IsNull(XSYUKKA_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_STS
            strSQL.Append(vbCrLf & "    AND XSYUKKA_STS = :" & UBound(strBindField) - 1 & " --出荷状況")
        End If
        If IsNull(XIKKATU_SYUKKO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIKKATU_SYUKKO
            strSQL.Append(vbCrLf & "    AND XIKKATU_SYUKKO = :" & UBound(strBindField) - 1 & " --一括出庫指定")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --登録日時")
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
        strDataSetName = "XPLN_OUT"
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
    Public Function GET_XPLN_OUT_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    XPLN_OUT")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
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
        If IsNull(XDATA_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDATA_KIND
            strSQL.Append(vbCrLf & "    AND XDATA_KIND = :" & UBound(strBindField) - 1 & " --ﾃﾞｰﾀ種類")
        End If
        If IsNull(XEDIT_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEDIT_KBN
            strSQL.Append(vbCrLf & "    AND XEDIT_KBN = :" & UBound(strBindField) - 1 & " --編集区分")
        End If
        If IsNull(XINPUT_PLACE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXINPUT_PLACE
            strSQL.Append(vbCrLf & "    AND XINPUT_PLACE = :" & UBound(strBindField) - 1 & " --ｲﾝﾌﾟｯﾄ場所")
        End If
        If IsNull(XINPUT_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXINPUT_DT
            strSQL.Append(vbCrLf & "    AND XINPUT_DT = :" & UBound(strBindField) - 1 & " --ｲﾝﾌﾟｯﾄ日付")
        End If
        If IsNull(XINPUT_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXINPUT_NO
            strSQL.Append(vbCrLf & "    AND XINPUT_NO = :" & UBound(strBindField) - 1 & " --ｲﾝﾌﾟｯﾄNo.")
        End If
        If IsNull(XDENPYOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDENPYOU_NO
            strSQL.Append(vbCrLf & "    AND XDENPYOU_NO = :" & UBound(strBindField) - 1 & " --伝票No.")
        End If
        If IsNull(XBUNRUI_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBUNRUI_NO
            strSQL.Append(vbCrLf & "    AND XBUNRUI_NO = :" & UBound(strBindField) - 1 & " --分類No.")
        End If
        If IsNull(XDATA_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDATA_DT
            strSQL.Append(vbCrLf & "    AND XDATA_DT = :" & UBound(strBindField) - 1 & " --ﾃﾞｰﾀ日付")
        End If
        If IsNull(XSOUKO_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSOUKO_CD
            strSQL.Append(vbCrLf & "    AND XSOUKO_CD = :" & UBound(strBindField) - 1 & " --倉庫ｺｰﾄﾞ")
        End If
        If IsNull(XTOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTOU_NO
            strSQL.Append(vbCrLf & "    AND XTOU_NO = :" & UBound(strBindField) - 1 & " --棟ｺｰﾄﾞ")
        End If
        If IsNull(XTORIHIKI_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTORIHIKI_KBN
            strSQL.Append(vbCrLf & "    AND XTORIHIKI_KBN = :" & UBound(strBindField) - 1 & " --取引区分")
        End If
        If IsNull(XDATA_SYORI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDATA_SYORI
            strSQL.Append(vbCrLf & "    AND XDATA_SYORI = :" & UBound(strBindField) - 1 & " --ﾃﾞｰﾀ処理")
        End If
        If IsNull(XGYOUSYA_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_CD
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_CD = :" & UBound(strBindField) - 1 & " --物流業者ｺｰﾄﾞ")
        End If
        If IsNull(XGYOUSYA_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_KBN
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_KBN = :" & UBound(strBindField) - 1 & " --業者区分")
        End If
        If IsNull(XSYARYOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYARYOU_NO
            strSQL.Append(vbCrLf & "    AND XSYARYOU_NO = :" & UBound(strBindField) - 1 & " --車輌番号")
        End If
        If IsNull(XUNKOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXUNKOU_NO
            strSQL.Append(vbCrLf & "    AND XUNKOU_NO = :" & UBound(strBindField) - 1 & " --倉庫別運行No.")
        End If
        If IsNull(XTUMI_HOUKOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_HOUKOU
            strSQL.Append(vbCrLf & "    AND XTUMI_HOUKOU = :" & UBound(strBindField) - 1 & " --積込方向")
        End If
        If IsNull(XTUMI_HOUHOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_HOUHOU
            strSQL.Append(vbCrLf & "    AND XTUMI_HOUHOU = :" & UBound(strBindField) - 1 & " --積込方法")
        End If
        If IsNull(XSYASYU_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYASYU_KBN
            strSQL.Append(vbCrLf & "    AND XSYASYU_KBN = :" & UBound(strBindField) - 1 & " --車種区分")
        End If
        If IsNull(XHENSEI_NO_OYA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO_OYA = :" & UBound(strBindField) - 1 & " --親編成No.")
        End If
        If IsNull(XSEND_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSEND_NAME
            strSQL.Append(vbCrLf & "    AND XSEND_NAME = :" & UBound(strBindField) - 1 & " --届け先名称")
        End If
        If IsNull(XSEND_ADDRESS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSEND_ADDRESS
            strSQL.Append(vbCrLf & "    AND XSEND_ADDRESS = :" & UBound(strBindField) - 1 & " --届け先住所")
        End If
        If IsNull(XBERTH_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_NO
            strSQL.Append(vbCrLf & "    AND XBERTH_NO = :" & UBound(strBindField) - 1 & " --ﾊﾞｰｽNo.")
        End If
        If IsNull(XKINKYU_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKINKYU_KBN
            strSQL.Append(vbCrLf & "    AND XKINKYU_KBN = :" & UBound(strBindField) - 1 & " --緊急出荷区分")
        End If
        If IsNull(XKINKYU_LEVEL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKINKYU_LEVEL
            strSQL.Append(vbCrLf & "    AND XKINKYU_LEVEL = :" & UBound(strBindField) - 1 & " --緊急度")
        End If
        If IsNull(XSYARYOU_ENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYARYOU_ENTRY_DT
            strSQL.Append(vbCrLf & "    AND XSYARYOU_ENTRY_DT = :" & UBound(strBindField) - 1 & " --車輌受付日時")
        End If
        If IsNull(XSYUKKA_DIR_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_DIR_DT
            strSQL.Append(vbCrLf & "    AND XSYUKKA_DIR_DT = :" & UBound(strBindField) - 1 & " --出荷指示日時")
        End If
        If IsNull(XOUT_START_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_START_DT
            strSQL.Append(vbCrLf & "    AND XOUT_START_DT = :" & UBound(strBindField) - 1 & " --出庫開始日時")
        End If
        If IsNull(XOUT_END_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_END_DT
            strSQL.Append(vbCrLf & "    AND XOUT_END_DT = :" & UBound(strBindField) - 1 & " --出庫完了日時")
        End If
        If IsNull(XTUMI_END_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_END_DT
            strSQL.Append(vbCrLf & "    AND XTUMI_END_DT = :" & UBound(strBindField) - 1 & " --積込完了日時")
        End If
        If IsNull(XSYUKKA_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_STS
            strSQL.Append(vbCrLf & "    AND XSYUKKA_STS = :" & UBound(strBindField) - 1 & " --出荷状況")
        End If
        If IsNull(XIKKATU_SYUKKO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIKKATU_SYUKKO
            strSQL.Append(vbCrLf & "    AND XIKKATU_SYUKKO = :" & UBound(strBindField) - 1 & " --一括出庫指定")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --登録日時")
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
        strDataSetName = "XPLN_OUT"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XPLN_OUT(Owner, objDb, objDbLog)
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
    Public Function GET_XPLN_OUT_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "XPLN_OUT"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XPLN_OUT(Owner, objDb, objDbLog)
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
    Public Function GET_XPLN_OUT_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    XPLN_OUT")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
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
        If IsNull(XDATA_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDATA_KIND
            strSQL.Append(vbCrLf & "    AND XDATA_KIND = :" & UBound(strBindField) - 1 & " --ﾃﾞｰﾀ種類")
        End If
        If IsNull(XEDIT_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEDIT_KBN
            strSQL.Append(vbCrLf & "    AND XEDIT_KBN = :" & UBound(strBindField) - 1 & " --編集区分")
        End If
        If IsNull(XINPUT_PLACE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXINPUT_PLACE
            strSQL.Append(vbCrLf & "    AND XINPUT_PLACE = :" & UBound(strBindField) - 1 & " --ｲﾝﾌﾟｯﾄ場所")
        End If
        If IsNull(XINPUT_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXINPUT_DT
            strSQL.Append(vbCrLf & "    AND XINPUT_DT = :" & UBound(strBindField) - 1 & " --ｲﾝﾌﾟｯﾄ日付")
        End If
        If IsNull(XINPUT_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXINPUT_NO
            strSQL.Append(vbCrLf & "    AND XINPUT_NO = :" & UBound(strBindField) - 1 & " --ｲﾝﾌﾟｯﾄNo.")
        End If
        If IsNull(XDENPYOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDENPYOU_NO
            strSQL.Append(vbCrLf & "    AND XDENPYOU_NO = :" & UBound(strBindField) - 1 & " --伝票No.")
        End If
        If IsNull(XBUNRUI_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBUNRUI_NO
            strSQL.Append(vbCrLf & "    AND XBUNRUI_NO = :" & UBound(strBindField) - 1 & " --分類No.")
        End If
        If IsNull(XDATA_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDATA_DT
            strSQL.Append(vbCrLf & "    AND XDATA_DT = :" & UBound(strBindField) - 1 & " --ﾃﾞｰﾀ日付")
        End If
        If IsNull(XSOUKO_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSOUKO_CD
            strSQL.Append(vbCrLf & "    AND XSOUKO_CD = :" & UBound(strBindField) - 1 & " --倉庫ｺｰﾄﾞ")
        End If
        If IsNull(XTOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTOU_NO
            strSQL.Append(vbCrLf & "    AND XTOU_NO = :" & UBound(strBindField) - 1 & " --棟ｺｰﾄﾞ")
        End If
        If IsNull(XTORIHIKI_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTORIHIKI_KBN
            strSQL.Append(vbCrLf & "    AND XTORIHIKI_KBN = :" & UBound(strBindField) - 1 & " --取引区分")
        End If
        If IsNull(XDATA_SYORI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDATA_SYORI
            strSQL.Append(vbCrLf & "    AND XDATA_SYORI = :" & UBound(strBindField) - 1 & " --ﾃﾞｰﾀ処理")
        End If
        If IsNull(XGYOUSYA_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_CD
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_CD = :" & UBound(strBindField) - 1 & " --物流業者ｺｰﾄﾞ")
        End If
        If IsNull(XGYOUSYA_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_KBN
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_KBN = :" & UBound(strBindField) - 1 & " --業者区分")
        End If
        If IsNull(XSYARYOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYARYOU_NO
            strSQL.Append(vbCrLf & "    AND XSYARYOU_NO = :" & UBound(strBindField) - 1 & " --車輌番号")
        End If
        If IsNull(XUNKOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXUNKOU_NO
            strSQL.Append(vbCrLf & "    AND XUNKOU_NO = :" & UBound(strBindField) - 1 & " --倉庫別運行No.")
        End If
        If IsNull(XTUMI_HOUKOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_HOUKOU
            strSQL.Append(vbCrLf & "    AND XTUMI_HOUKOU = :" & UBound(strBindField) - 1 & " --積込方向")
        End If
        If IsNull(XTUMI_HOUHOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_HOUHOU
            strSQL.Append(vbCrLf & "    AND XTUMI_HOUHOU = :" & UBound(strBindField) - 1 & " --積込方法")
        End If
        If IsNull(XSYASYU_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYASYU_KBN
            strSQL.Append(vbCrLf & "    AND XSYASYU_KBN = :" & UBound(strBindField) - 1 & " --車種区分")
        End If
        If IsNull(XHENSEI_NO_OYA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO_OYA = :" & UBound(strBindField) - 1 & " --親編成No.")
        End If
        If IsNull(XSEND_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSEND_NAME
            strSQL.Append(vbCrLf & "    AND XSEND_NAME = :" & UBound(strBindField) - 1 & " --届け先名称")
        End If
        If IsNull(XSEND_ADDRESS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSEND_ADDRESS
            strSQL.Append(vbCrLf & "    AND XSEND_ADDRESS = :" & UBound(strBindField) - 1 & " --届け先住所")
        End If
        If IsNull(XBERTH_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_NO
            strSQL.Append(vbCrLf & "    AND XBERTH_NO = :" & UBound(strBindField) - 1 & " --ﾊﾞｰｽNo.")
        End If
        If IsNull(XKINKYU_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKINKYU_KBN
            strSQL.Append(vbCrLf & "    AND XKINKYU_KBN = :" & UBound(strBindField) - 1 & " --緊急出荷区分")
        End If
        If IsNull(XKINKYU_LEVEL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKINKYU_LEVEL
            strSQL.Append(vbCrLf & "    AND XKINKYU_LEVEL = :" & UBound(strBindField) - 1 & " --緊急度")
        End If
        If IsNull(XSYARYOU_ENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYARYOU_ENTRY_DT
            strSQL.Append(vbCrLf & "    AND XSYARYOU_ENTRY_DT = :" & UBound(strBindField) - 1 & " --車輌受付日時")
        End If
        If IsNull(XSYUKKA_DIR_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_DIR_DT
            strSQL.Append(vbCrLf & "    AND XSYUKKA_DIR_DT = :" & UBound(strBindField) - 1 & " --出荷指示日時")
        End If
        If IsNull(XOUT_START_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_START_DT
            strSQL.Append(vbCrLf & "    AND XOUT_START_DT = :" & UBound(strBindField) - 1 & " --出庫開始日時")
        End If
        If IsNull(XOUT_END_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_END_DT
            strSQL.Append(vbCrLf & "    AND XOUT_END_DT = :" & UBound(strBindField) - 1 & " --出庫完了日時")
        End If
        If IsNull(XTUMI_END_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_END_DT
            strSQL.Append(vbCrLf & "    AND XTUMI_END_DT = :" & UBound(strBindField) - 1 & " --積込完了日時")
        End If
        If IsNull(XSYUKKA_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_STS
            strSQL.Append(vbCrLf & "    AND XSYUKKA_STS = :" & UBound(strBindField) - 1 & " --出荷状況")
        End If
        If IsNull(XIKKATU_SYUKKO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIKKATU_SYUKKO
            strSQL.Append(vbCrLf & "    AND XIKKATU_SYUKKO = :" & UBound(strBindField) - 1 & " --一括出庫指定")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --登録日時")
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
        strDataSetName = "XPLN_OUT"
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
    Public Sub UPDATE_XPLN_OUT()
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
        ElseIf IsNull(mXSYUKKA_D) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[出荷日]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mXHENSEI_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[編成No.]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mXDENPYOU_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[伝票No.]"
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
        strSQL.Append(vbCrLf & "    XPLN_OUT")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
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
        If IsNull(mXDATA_KIND) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDATA_KIND = NULL --ﾃﾞｰﾀ種類")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDATA_KIND = NULL --ﾃﾞｰﾀ種類")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDATA_KIND
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDATA_KIND = :" & Ubound(strBindField) - 1 & " --ﾃﾞｰﾀ種類")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDATA_KIND = :" & Ubound(strBindField) - 1 & " --ﾃﾞｰﾀ種類")
        End If
        intCount = intCount + 1
        If IsNull(mXEDIT_KBN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEDIT_KBN = NULL --編集区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEDIT_KBN = NULL --編集区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEDIT_KBN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEDIT_KBN = :" & Ubound(strBindField) - 1 & " --編集区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEDIT_KBN = :" & Ubound(strBindField) - 1 & " --編集区分")
        End If
        intCount = intCount + 1
        If IsNull(mXINPUT_PLACE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XINPUT_PLACE = NULL --ｲﾝﾌﾟｯﾄ場所")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XINPUT_PLACE = NULL --ｲﾝﾌﾟｯﾄ場所")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXINPUT_PLACE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XINPUT_PLACE = :" & Ubound(strBindField) - 1 & " --ｲﾝﾌﾟｯﾄ場所")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XINPUT_PLACE = :" & Ubound(strBindField) - 1 & " --ｲﾝﾌﾟｯﾄ場所")
        End If
        intCount = intCount + 1
        If IsNull(mXINPUT_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XINPUT_DT = NULL --ｲﾝﾌﾟｯﾄ日付")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XINPUT_DT = NULL --ｲﾝﾌﾟｯﾄ日付")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXINPUT_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XINPUT_DT = :" & Ubound(strBindField) - 1 & " --ｲﾝﾌﾟｯﾄ日付")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XINPUT_DT = :" & Ubound(strBindField) - 1 & " --ｲﾝﾌﾟｯﾄ日付")
        End If
        intCount = intCount + 1
        If IsNull(mXINPUT_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XINPUT_NO = NULL --ｲﾝﾌﾟｯﾄNo.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XINPUT_NO = NULL --ｲﾝﾌﾟｯﾄNo.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXINPUT_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XINPUT_NO = :" & Ubound(strBindField) - 1 & " --ｲﾝﾌﾟｯﾄNo.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XINPUT_NO = :" & Ubound(strBindField) - 1 & " --ｲﾝﾌﾟｯﾄNo.")
        End If
        intCount = intCount + 1
        If IsNull(mXDENPYOU_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDENPYOU_NO = NULL --伝票No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDENPYOU_NO = NULL --伝票No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDENPYOU_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDENPYOU_NO = :" & Ubound(strBindField) - 1 & " --伝票No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDENPYOU_NO = :" & Ubound(strBindField) - 1 & " --伝票No.")
        End If
        intCount = intCount + 1
        If IsNull(mXBUNRUI_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XBUNRUI_NO = NULL --分類No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XBUNRUI_NO = NULL --分類No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBUNRUI_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XBUNRUI_NO = :" & Ubound(strBindField) - 1 & " --分類No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XBUNRUI_NO = :" & Ubound(strBindField) - 1 & " --分類No.")
        End If
        intCount = intCount + 1
        If IsNull(mXDATA_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDATA_DT = NULL --ﾃﾞｰﾀ日付")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDATA_DT = NULL --ﾃﾞｰﾀ日付")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDATA_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDATA_DT = :" & Ubound(strBindField) - 1 & " --ﾃﾞｰﾀ日付")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDATA_DT = :" & Ubound(strBindField) - 1 & " --ﾃﾞｰﾀ日付")
        End If
        intCount = intCount + 1
        If IsNull(mXSOUKO_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSOUKO_CD = NULL --倉庫ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSOUKO_CD = NULL --倉庫ｺｰﾄﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSOUKO_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSOUKO_CD = :" & Ubound(strBindField) - 1 & " --倉庫ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSOUKO_CD = :" & Ubound(strBindField) - 1 & " --倉庫ｺｰﾄﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mXTOU_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTOU_NO = NULL --棟ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTOU_NO = NULL --棟ｺｰﾄﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTOU_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTOU_NO = :" & Ubound(strBindField) - 1 & " --棟ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTOU_NO = :" & Ubound(strBindField) - 1 & " --棟ｺｰﾄﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mXTORIHIKI_KBN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTORIHIKI_KBN = NULL --取引区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTORIHIKI_KBN = NULL --取引区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTORIHIKI_KBN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTORIHIKI_KBN = :" & Ubound(strBindField) - 1 & " --取引区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTORIHIKI_KBN = :" & Ubound(strBindField) - 1 & " --取引区分")
        End If
        intCount = intCount + 1
        If IsNull(mXDATA_SYORI) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDATA_SYORI = NULL --ﾃﾞｰﾀ処理")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDATA_SYORI = NULL --ﾃﾞｰﾀ処理")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDATA_SYORI
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDATA_SYORI = :" & Ubound(strBindField) - 1 & " --ﾃﾞｰﾀ処理")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDATA_SYORI = :" & Ubound(strBindField) - 1 & " --ﾃﾞｰﾀ処理")
        End If
        intCount = intCount + 1
        If IsNull(mXGYOUSYA_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XGYOUSYA_CD = NULL --物流業者ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XGYOUSYA_CD = NULL --物流業者ｺｰﾄﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XGYOUSYA_CD = :" & Ubound(strBindField) - 1 & " --物流業者ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XGYOUSYA_CD = :" & Ubound(strBindField) - 1 & " --物流業者ｺｰﾄﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mXGYOUSYA_KBN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XGYOUSYA_KBN = NULL --業者区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XGYOUSYA_KBN = NULL --業者区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_KBN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XGYOUSYA_KBN = :" & Ubound(strBindField) - 1 & " --業者区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XGYOUSYA_KBN = :" & Ubound(strBindField) - 1 & " --業者区分")
        End If
        intCount = intCount + 1
        If IsNull(mXSYARYOU_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYARYOU_NO = NULL --車輌番号")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYARYOU_NO = NULL --車輌番号")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYARYOU_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYARYOU_NO = :" & Ubound(strBindField) - 1 & " --車輌番号")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYARYOU_NO = :" & Ubound(strBindField) - 1 & " --車輌番号")
        End If
        intCount = intCount + 1
        If IsNull(mXUNKOU_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XUNKOU_NO = NULL --倉庫別運行No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XUNKOU_NO = NULL --倉庫別運行No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXUNKOU_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XUNKOU_NO = :" & Ubound(strBindField) - 1 & " --倉庫別運行No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XUNKOU_NO = :" & Ubound(strBindField) - 1 & " --倉庫別運行No.")
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
        If IsNull(mXTUMI_HOUHOU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTUMI_HOUHOU = NULL --積込方法")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTUMI_HOUHOU = NULL --積込方法")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_HOUHOU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTUMI_HOUHOU = :" & Ubound(strBindField) - 1 & " --積込方法")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTUMI_HOUHOU = :" & Ubound(strBindField) - 1 & " --積込方法")
        End If
        intCount = intCount + 1
        If IsNull(mXSYASYU_KBN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYASYU_KBN = NULL --車種区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYASYU_KBN = NULL --車種区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYASYU_KBN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYASYU_KBN = :" & Ubound(strBindField) - 1 & " --車種区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYASYU_KBN = :" & Ubound(strBindField) - 1 & " --車種区分")
        End If
        intCount = intCount + 1
        If IsNull(mXHENSEI_NO_OYA) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XHENSEI_NO_OYA = NULL --親編成No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XHENSEI_NO_OYA = NULL --親編成No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XHENSEI_NO_OYA = :" & Ubound(strBindField) - 1 & " --親編成No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XHENSEI_NO_OYA = :" & Ubound(strBindField) - 1 & " --親編成No.")
        End If
        intCount = intCount + 1
        If IsNull(mXSEND_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSEND_NAME = NULL --届け先名称")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSEND_NAME = NULL --届け先名称")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSEND_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSEND_NAME = :" & Ubound(strBindField) - 1 & " --届け先名称")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSEND_NAME = :" & Ubound(strBindField) - 1 & " --届け先名称")
        End If
        intCount = intCount + 1
        If IsNull(mXSEND_ADDRESS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSEND_ADDRESS = NULL --届け先住所")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSEND_ADDRESS = NULL --届け先住所")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSEND_ADDRESS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSEND_ADDRESS = :" & Ubound(strBindField) - 1 & " --届け先住所")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSEND_ADDRESS = :" & Ubound(strBindField) - 1 & " --届け先住所")
        End If
        intCount = intCount + 1
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
        If IsNull(mXKINKYU_KBN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XKINKYU_KBN = NULL --緊急出荷区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XKINKYU_KBN = NULL --緊急出荷区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKINKYU_KBN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XKINKYU_KBN = :" & Ubound(strBindField) - 1 & " --緊急出荷区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XKINKYU_KBN = :" & Ubound(strBindField) - 1 & " --緊急出荷区分")
        End If
        intCount = intCount + 1
        If IsNull(mXKINKYU_LEVEL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XKINKYU_LEVEL = NULL --緊急度")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XKINKYU_LEVEL = NULL --緊急度")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKINKYU_LEVEL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XKINKYU_LEVEL = :" & Ubound(strBindField) - 1 & " --緊急度")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XKINKYU_LEVEL = :" & Ubound(strBindField) - 1 & " --緊急度")
        End If
        intCount = intCount + 1
        If IsNull(mXSYARYOU_ENTRY_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYARYOU_ENTRY_DT = NULL --車輌受付日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYARYOU_ENTRY_DT = NULL --車輌受付日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYARYOU_ENTRY_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYARYOU_ENTRY_DT = :" & Ubound(strBindField) - 1 & " --車輌受付日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYARYOU_ENTRY_DT = :" & Ubound(strBindField) - 1 & " --車輌受付日時")
        End If
        intCount = intCount + 1
        If IsNull(mXSYUKKA_DIR_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_DIR_DT = NULL --出荷指示日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_DIR_DT = NULL --出荷指示日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_DIR_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_DIR_DT = :" & Ubound(strBindField) - 1 & " --出荷指示日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_DIR_DT = :" & Ubound(strBindField) - 1 & " --出荷指示日時")
        End If
        intCount = intCount + 1
        If IsNull(mXOUT_START_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XOUT_START_DT = NULL --出庫開始日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XOUT_START_DT = NULL --出庫開始日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_START_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XOUT_START_DT = :" & Ubound(strBindField) - 1 & " --出庫開始日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XOUT_START_DT = :" & Ubound(strBindField) - 1 & " --出庫開始日時")
        End If
        intCount = intCount + 1
        If IsNull(mXOUT_END_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XOUT_END_DT = NULL --出庫完了日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XOUT_END_DT = NULL --出庫完了日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_END_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XOUT_END_DT = :" & Ubound(strBindField) - 1 & " --出庫完了日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XOUT_END_DT = :" & Ubound(strBindField) - 1 & " --出庫完了日時")
        End If
        intCount = intCount + 1
        If IsNull(mXTUMI_END_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTUMI_END_DT = NULL --積込完了日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTUMI_END_DT = NULL --積込完了日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_END_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTUMI_END_DT = :" & Ubound(strBindField) - 1 & " --積込完了日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTUMI_END_DT = :" & Ubound(strBindField) - 1 & " --積込完了日時")
        End If
        intCount = intCount + 1
        If IsNull(mXSYUKKA_STS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_STS = NULL --出荷状況")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_STS = NULL --出荷状況")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_STS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_STS = :" & Ubound(strBindField) - 1 & " --出荷状況")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_STS = :" & Ubound(strBindField) - 1 & " --出荷状況")
        End If
        intCount = intCount + 1
        If IsNull(mXIKKATU_SYUKKO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XIKKATU_SYUKKO = NULL --一括出庫指定")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XIKKATU_SYUKKO = NULL --一括出庫指定")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIKKATU_SYUKKO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XIKKATU_SYUKKO = :" & Ubound(strBindField) - 1 & " --一括出庫指定")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XIKKATU_SYUKKO = :" & Ubound(strBindField) - 1 & " --一括出庫指定")
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
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(XSYUKKA_D) = True Then
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D IS NULL --出荷日")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D = :" & UBound(strBindField) - 1 & " --出荷日")
        End If
        If IsNull(XHENSEI_NO) = True Then
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO IS NULL --編成No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO = :" & UBound(strBindField) - 1 & " --編成No.")
        End If
        If IsNull(XDENPYOU_NO) = True Then
            strSQL.Append(vbCrLf & "    AND XDENPYOU_NO IS NULL --伝票No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDENPYOU_NO
            strSQL.Append(vbCrLf & "    AND XDENPYOU_NO = :" & UBound(strBindField) - 1 & " --伝票No.")
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
    Public Sub ADD_XPLN_OUT()
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
        ElseIf IsNull(mXSYUKKA_D) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[出荷日]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mXHENSEI_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[編成No.]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mXDENPYOU_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[伝票No.]"
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
        strSQL.Append(vbCrLf & "    XPLN_OUT")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
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
        If IsNull(mXDATA_KIND) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾃﾞｰﾀ種類")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾃﾞｰﾀ種類")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDATA_KIND
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾃﾞｰﾀ種類")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾃﾞｰﾀ種類")
        End If
        intCount = intCount + 1
        If IsNull(mXEDIT_KBN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --編集区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --編集区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEDIT_KBN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --編集区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --編集区分")
        End If
        intCount = intCount + 1
        If IsNull(mXINPUT_PLACE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｲﾝﾌﾟｯﾄ場所")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｲﾝﾌﾟｯﾄ場所")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXINPUT_PLACE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｲﾝﾌﾟｯﾄ場所")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｲﾝﾌﾟｯﾄ場所")
        End If
        intCount = intCount + 1
        If IsNull(mXINPUT_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｲﾝﾌﾟｯﾄ日付")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｲﾝﾌﾟｯﾄ日付")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXINPUT_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｲﾝﾌﾟｯﾄ日付")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｲﾝﾌﾟｯﾄ日付")
        End If
        intCount = intCount + 1
        If IsNull(mXINPUT_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｲﾝﾌﾟｯﾄNo.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｲﾝﾌﾟｯﾄNo.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXINPUT_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｲﾝﾌﾟｯﾄNo.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｲﾝﾌﾟｯﾄNo.")
        End If
        intCount = intCount + 1
        If IsNull(mXDENPYOU_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --伝票No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --伝票No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDENPYOU_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --伝票No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --伝票No.")
        End If
        intCount = intCount + 1
        If IsNull(mXBUNRUI_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --分類No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --分類No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBUNRUI_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --分類No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --分類No.")
        End If
        intCount = intCount + 1
        If IsNull(mXDATA_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾃﾞｰﾀ日付")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾃﾞｰﾀ日付")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDATA_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾃﾞｰﾀ日付")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾃﾞｰﾀ日付")
        End If
        intCount = intCount + 1
        If IsNull(mXSOUKO_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --倉庫ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --倉庫ｺｰﾄﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSOUKO_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --倉庫ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --倉庫ｺｰﾄﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mXTOU_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --棟ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --棟ｺｰﾄﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTOU_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --棟ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --棟ｺｰﾄﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mXTORIHIKI_KBN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --取引区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --取引区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTORIHIKI_KBN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --取引区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --取引区分")
        End If
        intCount = intCount + 1
        If IsNull(mXDATA_SYORI) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾃﾞｰﾀ処理")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾃﾞｰﾀ処理")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDATA_SYORI
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾃﾞｰﾀ処理")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾃﾞｰﾀ処理")
        End If
        intCount = intCount + 1
        If IsNull(mXGYOUSYA_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --物流業者ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --物流業者ｺｰﾄﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --物流業者ｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --物流業者ｺｰﾄﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mXGYOUSYA_KBN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --業者区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --業者区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_KBN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --業者区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --業者区分")
        End If
        intCount = intCount + 1
        If IsNull(mXSYARYOU_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --車輌番号")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --車輌番号")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYARYOU_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --車輌番号")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --車輌番号")
        End If
        intCount = intCount + 1
        If IsNull(mXUNKOU_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --倉庫別運行No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --倉庫別運行No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXUNKOU_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --倉庫別運行No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --倉庫別運行No.")
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
        If IsNull(mXTUMI_HOUHOU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --積込方法")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --積込方法")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_HOUHOU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --積込方法")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --積込方法")
        End If
        intCount = intCount + 1
        If IsNull(mXSYASYU_KBN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --車種区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --車種区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYASYU_KBN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --車種区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --車種区分")
        End If
        intCount = intCount + 1
        If IsNull(mXHENSEI_NO_OYA) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --親編成No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --親編成No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --親編成No.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --親編成No.")
        End If
        intCount = intCount + 1
        If IsNull(mXSEND_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --届け先名称")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --届け先名称")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSEND_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --届け先名称")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --届け先名称")
        End If
        intCount = intCount + 1
        If IsNull(mXSEND_ADDRESS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --届け先住所")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --届け先住所")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSEND_ADDRESS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --届け先住所")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --届け先住所")
        End If
        intCount = intCount + 1
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
        If IsNull(mXKINKYU_KBN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --緊急出荷区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --緊急出荷区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKINKYU_KBN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --緊急出荷区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --緊急出荷区分")
        End If
        intCount = intCount + 1
        If IsNull(mXKINKYU_LEVEL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --緊急度")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --緊急度")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKINKYU_LEVEL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --緊急度")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --緊急度")
        End If
        intCount = intCount + 1
        If IsNull(mXSYARYOU_ENTRY_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --車輌受付日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --車輌受付日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYARYOU_ENTRY_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --車輌受付日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --車輌受付日時")
        End If
        intCount = intCount + 1
        If IsNull(mXSYUKKA_DIR_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --出荷指示日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --出荷指示日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_DIR_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --出荷指示日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --出荷指示日時")
        End If
        intCount = intCount + 1
        If IsNull(mXOUT_START_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --出庫開始日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --出庫開始日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_START_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --出庫開始日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --出庫開始日時")
        End If
        intCount = intCount + 1
        If IsNull(mXOUT_END_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --出庫完了日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --出庫完了日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_END_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --出庫完了日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --出庫完了日時")
        End If
        intCount = intCount + 1
        If IsNull(mXTUMI_END_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --積込完了日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --積込完了日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_END_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --積込完了日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --積込完了日時")
        End If
        intCount = intCount + 1
        If IsNull(mXSYUKKA_STS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --出荷状況")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --出荷状況")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_STS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --出荷状況")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --出荷状況")
        End If
        intCount = intCount + 1
        If IsNull(mXIKKATU_SYUKKO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --一括出庫指定")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --一括出庫指定")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIKKATU_SYUKKO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --一括出庫指定")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --一括出庫指定")
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
    Public Sub DELETE_XPLN_OUT()
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
        ElseIf IsNull(mXSYUKKA_D) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[出荷日]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mXHENSEI_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[編成No.]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mXDENPYOU_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[伝票No.]"
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
        strSQL.Append(vbCrLf & "    XPLN_OUT")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(XSYUKKA_D) = True Then
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D IS NULL --出荷日")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_D
            strSQL.Append(vbCrLf & "    AND XSYUKKA_D = :" & UBound(strBindField) - 1 & " --出荷日")
        End If
        If IsNull(XHENSEI_NO) = True Then
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO IS NULL --編成No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO = :" & UBound(strBindField) - 1 & " --編成No.")
        End If
        If IsNull(XDENPYOU_NO) = True Then
            strSQL.Append(vbCrLf & "    AND XDENPYOU_NO IS NULL --伝票No.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDENPYOU_NO
            strSQL.Append(vbCrLf & "    AND XDENPYOU_NO = :" & UBound(strBindField) - 1 & " --伝票No.")
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
    Public Sub DELETE_XPLN_OUT_ANY()
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
        strSQL.Append(vbCrLf & "    XPLN_OUT")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
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
        If IsNotNull(XDATA_KIND) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDATA_KIND
            strSQL.Append(vbCrLf & "    AND XDATA_KIND = :" & UBound(strBindField) - 1 & " --ﾃﾞｰﾀ種類")
        End If
        If IsNotNull(XEDIT_KBN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEDIT_KBN
            strSQL.Append(vbCrLf & "    AND XEDIT_KBN = :" & UBound(strBindField) - 1 & " --編集区分")
        End If
        If IsNotNull(XINPUT_PLACE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXINPUT_PLACE
            strSQL.Append(vbCrLf & "    AND XINPUT_PLACE = :" & UBound(strBindField) - 1 & " --ｲﾝﾌﾟｯﾄ場所")
        End If
        If IsNotNull(XINPUT_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXINPUT_DT
            strSQL.Append(vbCrLf & "    AND XINPUT_DT = :" & UBound(strBindField) - 1 & " --ｲﾝﾌﾟｯﾄ日付")
        End If
        If IsNotNull(XINPUT_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXINPUT_NO
            strSQL.Append(vbCrLf & "    AND XINPUT_NO = :" & UBound(strBindField) - 1 & " --ｲﾝﾌﾟｯﾄNo.")
        End If
        If IsNotNull(XDENPYOU_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDENPYOU_NO
            strSQL.Append(vbCrLf & "    AND XDENPYOU_NO = :" & UBound(strBindField) - 1 & " --伝票No.")
        End If
        If IsNotNull(XBUNRUI_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBUNRUI_NO
            strSQL.Append(vbCrLf & "    AND XBUNRUI_NO = :" & UBound(strBindField) - 1 & " --分類No.")
        End If
        If IsNotNull(XDATA_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDATA_DT
            strSQL.Append(vbCrLf & "    AND XDATA_DT = :" & UBound(strBindField) - 1 & " --ﾃﾞｰﾀ日付")
        End If
        If IsNotNull(XSOUKO_CD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSOUKO_CD
            strSQL.Append(vbCrLf & "    AND XSOUKO_CD = :" & UBound(strBindField) - 1 & " --倉庫ｺｰﾄﾞ")
        End If
        If IsNotNull(XTOU_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTOU_NO
            strSQL.Append(vbCrLf & "    AND XTOU_NO = :" & UBound(strBindField) - 1 & " --棟ｺｰﾄﾞ")
        End If
        If IsNotNull(XTORIHIKI_KBN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTORIHIKI_KBN
            strSQL.Append(vbCrLf & "    AND XTORIHIKI_KBN = :" & UBound(strBindField) - 1 & " --取引区分")
        End If
        If IsNotNull(XDATA_SYORI) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDATA_SYORI
            strSQL.Append(vbCrLf & "    AND XDATA_SYORI = :" & UBound(strBindField) - 1 & " --ﾃﾞｰﾀ処理")
        End If
        If IsNotNull(XGYOUSYA_CD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_CD
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_CD = :" & UBound(strBindField) - 1 & " --物流業者ｺｰﾄﾞ")
        End If
        If IsNotNull(XGYOUSYA_KBN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_KBN
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_KBN = :" & UBound(strBindField) - 1 & " --業者区分")
        End If
        If IsNotNull(XSYARYOU_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYARYOU_NO
            strSQL.Append(vbCrLf & "    AND XSYARYOU_NO = :" & UBound(strBindField) - 1 & " --車輌番号")
        End If
        If IsNotNull(XUNKOU_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXUNKOU_NO
            strSQL.Append(vbCrLf & "    AND XUNKOU_NO = :" & UBound(strBindField) - 1 & " --倉庫別運行No.")
        End If
        If IsNotNull(XTUMI_HOUKOU) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_HOUKOU
            strSQL.Append(vbCrLf & "    AND XTUMI_HOUKOU = :" & UBound(strBindField) - 1 & " --積込方向")
        End If
        If IsNotNull(XTUMI_HOUHOU) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_HOUHOU
            strSQL.Append(vbCrLf & "    AND XTUMI_HOUHOU = :" & UBound(strBindField) - 1 & " --積込方法")
        End If
        If IsNotNull(XSYASYU_KBN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYASYU_KBN
            strSQL.Append(vbCrLf & "    AND XSYASYU_KBN = :" & UBound(strBindField) - 1 & " --車種区分")
        End If
        If IsNotNull(XHENSEI_NO_OYA) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO_OYA = :" & UBound(strBindField) - 1 & " --親編成No.")
        End If
        If IsNotNull(XSEND_NAME) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSEND_NAME
            strSQL.Append(vbCrLf & "    AND XSEND_NAME = :" & UBound(strBindField) - 1 & " --届け先名称")
        End If
        If IsNotNull(XSEND_ADDRESS) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSEND_ADDRESS
            strSQL.Append(vbCrLf & "    AND XSEND_ADDRESS = :" & UBound(strBindField) - 1 & " --届け先住所")
        End If
        If IsNotNull(XBERTH_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_NO
            strSQL.Append(vbCrLf & "    AND XBERTH_NO = :" & UBound(strBindField) - 1 & " --ﾊﾞｰｽNo.")
        End If
        If IsNotNull(XKINKYU_KBN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKINKYU_KBN
            strSQL.Append(vbCrLf & "    AND XKINKYU_KBN = :" & UBound(strBindField) - 1 & " --緊急出荷区分")
        End If
        If IsNotNull(XKINKYU_LEVEL) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKINKYU_LEVEL
            strSQL.Append(vbCrLf & "    AND XKINKYU_LEVEL = :" & UBound(strBindField) - 1 & " --緊急度")
        End If
        If IsNotNull(XSYARYOU_ENTRY_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYARYOU_ENTRY_DT
            strSQL.Append(vbCrLf & "    AND XSYARYOU_ENTRY_DT = :" & UBound(strBindField) - 1 & " --車輌受付日時")
        End If
        If IsNotNull(XSYUKKA_DIR_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_DIR_DT
            strSQL.Append(vbCrLf & "    AND XSYUKKA_DIR_DT = :" & UBound(strBindField) - 1 & " --出荷指示日時")
        End If
        If IsNotNull(XOUT_START_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_START_DT
            strSQL.Append(vbCrLf & "    AND XOUT_START_DT = :" & UBound(strBindField) - 1 & " --出庫開始日時")
        End If
        If IsNotNull(XOUT_END_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXOUT_END_DT
            strSQL.Append(vbCrLf & "    AND XOUT_END_DT = :" & UBound(strBindField) - 1 & " --出庫完了日時")
        End If
        If IsNotNull(XTUMI_END_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTUMI_END_DT
            strSQL.Append(vbCrLf & "    AND XTUMI_END_DT = :" & UBound(strBindField) - 1 & " --積込完了日時")
        End If
        If IsNotNull(XSYUKKA_STS) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_STS
            strSQL.Append(vbCrLf & "    AND XSYUKKA_STS = :" & UBound(strBindField) - 1 & " --出荷状況")
        End If
        If IsNotNull(XIKKATU_SYUKKO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIKKATU_SYUKKO
            strSQL.Append(vbCrLf & "    AND XIKKATU_SYUKKO = :" & UBound(strBindField) - 1 & " --一括出庫指定")
        End If
        If IsNotNull(FENTRY_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --登録日時")
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
        If IsNothing(objType.GetProperty("XSYUKKA_D")) = False Then mXSYUKKA_D = objObject.XSYUKKA_D '出荷日
        If IsNothing(objType.GetProperty("XHENSEI_NO")) = False Then mXHENSEI_NO = objObject.XHENSEI_NO '編成No.
        If IsNothing(objType.GetProperty("XDATA_KIND")) = False Then mXDATA_KIND = objObject.XDATA_KIND 'ﾃﾞｰﾀ種類
        If IsNothing(objType.GetProperty("XEDIT_KBN")) = False Then mXEDIT_KBN = objObject.XEDIT_KBN '編集区分
        If IsNothing(objType.GetProperty("XINPUT_PLACE")) = False Then mXINPUT_PLACE = objObject.XINPUT_PLACE 'ｲﾝﾌﾟｯﾄ場所
        If IsNothing(objType.GetProperty("XINPUT_DT")) = False Then mXINPUT_DT = objObject.XINPUT_DT 'ｲﾝﾌﾟｯﾄ日付
        If IsNothing(objType.GetProperty("XINPUT_NO")) = False Then mXINPUT_NO = objObject.XINPUT_NO 'ｲﾝﾌﾟｯﾄNo.
        If IsNothing(objType.GetProperty("XDENPYOU_NO")) = False Then mXDENPYOU_NO = objObject.XDENPYOU_NO '伝票No.
        If IsNothing(objType.GetProperty("XBUNRUI_NO")) = False Then mXBUNRUI_NO = objObject.XBUNRUI_NO '分類No.
        If IsNothing(objType.GetProperty("XDATA_DT")) = False Then mXDATA_DT = objObject.XDATA_DT 'ﾃﾞｰﾀ日付
        If IsNothing(objType.GetProperty("XSOUKO_CD")) = False Then mXSOUKO_CD = objObject.XSOUKO_CD '倉庫ｺｰﾄﾞ
        If IsNothing(objType.GetProperty("XTOU_NO")) = False Then mXTOU_NO = objObject.XTOU_NO '棟ｺｰﾄﾞ
        If IsNothing(objType.GetProperty("XTORIHIKI_KBN")) = False Then mXTORIHIKI_KBN = objObject.XTORIHIKI_KBN '取引区分
        If IsNothing(objType.GetProperty("XDATA_SYORI")) = False Then mXDATA_SYORI = objObject.XDATA_SYORI 'ﾃﾞｰﾀ処理
        If IsNothing(objType.GetProperty("XGYOUSYA_CD")) = False Then mXGYOUSYA_CD = objObject.XGYOUSYA_CD '物流業者ｺｰﾄﾞ
        If IsNothing(objType.GetProperty("XGYOUSYA_KBN")) = False Then mXGYOUSYA_KBN = objObject.XGYOUSYA_KBN '業者区分
        If IsNothing(objType.GetProperty("XSYARYOU_NO")) = False Then mXSYARYOU_NO = objObject.XSYARYOU_NO '車輌番号
        If IsNothing(objType.GetProperty("XUNKOU_NO")) = False Then mXUNKOU_NO = objObject.XUNKOU_NO '倉庫別運行No.
        If IsNothing(objType.GetProperty("XTUMI_HOUKOU")) = False Then mXTUMI_HOUKOU = objObject.XTUMI_HOUKOU '積込方向
        If IsNothing(objType.GetProperty("XTUMI_HOUHOU")) = False Then mXTUMI_HOUHOU = objObject.XTUMI_HOUHOU '積込方法
        If IsNothing(objType.GetProperty("XSYASYU_KBN")) = False Then mXSYASYU_KBN = objObject.XSYASYU_KBN '車種区分
        If IsNothing(objType.GetProperty("XHENSEI_NO_OYA")) = False Then mXHENSEI_NO_OYA = objObject.XHENSEI_NO_OYA '親編成No.
        If IsNothing(objType.GetProperty("XSEND_NAME")) = False Then mXSEND_NAME = objObject.XSEND_NAME '届け先名称
        If IsNothing(objType.GetProperty("XSEND_ADDRESS")) = False Then mXSEND_ADDRESS = objObject.XSEND_ADDRESS '届け先住所
        If IsNothing(objType.GetProperty("XBERTH_NO")) = False Then mXBERTH_NO = objObject.XBERTH_NO 'ﾊﾞｰｽNo.
        If IsNothing(objType.GetProperty("XKINKYU_KBN")) = False Then mXKINKYU_KBN = objObject.XKINKYU_KBN '緊急出荷区分
        If IsNothing(objType.GetProperty("XKINKYU_LEVEL")) = False Then mXKINKYU_LEVEL = objObject.XKINKYU_LEVEL '緊急度
        If IsNothing(objType.GetProperty("XSYARYOU_ENTRY_DT")) = False Then mXSYARYOU_ENTRY_DT = objObject.XSYARYOU_ENTRY_DT '車輌受付日時
        If IsNothing(objType.GetProperty("XSYUKKA_DIR_DT")) = False Then mXSYUKKA_DIR_DT = objObject.XSYUKKA_DIR_DT '出荷指示日時
        If IsNothing(objType.GetProperty("XOUT_START_DT")) = False Then mXOUT_START_DT = objObject.XOUT_START_DT '出庫開始日時
        If IsNothing(objType.GetProperty("XOUT_END_DT")) = False Then mXOUT_END_DT = objObject.XOUT_END_DT '出庫完了日時
        If IsNothing(objType.GetProperty("XTUMI_END_DT")) = False Then mXTUMI_END_DT = objObject.XTUMI_END_DT '積込完了日時
        If IsNothing(objType.GetProperty("XSYUKKA_STS")) = False Then mXSYUKKA_STS = objObject.XSYUKKA_STS '出荷状況
        If IsNothing(objType.GetProperty("XIKKATU_SYUKKO")) = False Then mXIKKATU_SYUKKO = objObject.XIKKATU_SYUKKO '一括出庫指定
        If IsNothing(objType.GetProperty("FENTRY_DT")) = False Then mFENTRY_DT = objObject.FENTRY_DT '登録日時

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
        mXSYUKKA_D = Nothing
        mXHENSEI_NO = Nothing
        mXDATA_KIND = Nothing
        mXEDIT_KBN = Nothing
        mXINPUT_PLACE = Nothing
        mXINPUT_DT = Nothing
        mXINPUT_NO = Nothing
        mXDENPYOU_NO = Nothing
        mXBUNRUI_NO = Nothing
        mXDATA_DT = Nothing
        mXSOUKO_CD = Nothing
        mXTOU_NO = Nothing
        mXTORIHIKI_KBN = Nothing
        mXDATA_SYORI = Nothing
        mXGYOUSYA_CD = Nothing
        mXGYOUSYA_KBN = Nothing
        mXSYARYOU_NO = Nothing
        mXUNKOU_NO = Nothing
        mXTUMI_HOUKOU = Nothing
        mXTUMI_HOUHOU = Nothing
        mXSYASYU_KBN = Nothing
        mXHENSEI_NO_OYA = Nothing
        mXSEND_NAME = Nothing
        mXSEND_ADDRESS = Nothing
        mXBERTH_NO = Nothing
        mXKINKYU_KBN = Nothing
        mXKINKYU_LEVEL = Nothing
        mXSYARYOU_ENTRY_DT = Nothing
        mXSYUKKA_DIR_DT = Nothing
        mXOUT_START_DT = Nothing
        mXOUT_END_DT = Nothing
        mXTUMI_END_DT = Nothing
        mXSYUKKA_STS = Nothing
        mXIKKATU_SYUKKO = Nothing
        mFENTRY_DT = Nothing


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
        mXSYUKKA_D = TO_DATE_NULLABLE(objRow("XSYUKKA_D"))
        mXHENSEI_NO = TO_STRING_NULLABLE(objRow("XHENSEI_NO"))
        mXDATA_KIND = TO_STRING_NULLABLE(objRow("XDATA_KIND"))
        mXEDIT_KBN = TO_STRING_NULLABLE(objRow("XEDIT_KBN"))
        mXINPUT_PLACE = TO_STRING_NULLABLE(objRow("XINPUT_PLACE"))
        mXINPUT_DT = TO_DATE_NULLABLE(objRow("XINPUT_DT"))
        mXINPUT_NO = TO_STRING_NULLABLE(objRow("XINPUT_NO"))
        mXDENPYOU_NO = TO_STRING_NULLABLE(objRow("XDENPYOU_NO"))
        mXBUNRUI_NO = TO_STRING_NULLABLE(objRow("XBUNRUI_NO"))
        mXDATA_DT = TO_DATE_NULLABLE(objRow("XDATA_DT"))
        mXSOUKO_CD = TO_STRING_NULLABLE(objRow("XSOUKO_CD"))
        mXTOU_NO = TO_STRING_NULLABLE(objRow("XTOU_NO"))
        mXTORIHIKI_KBN = TO_STRING_NULLABLE(objRow("XTORIHIKI_KBN"))
        mXDATA_SYORI = TO_STRING_NULLABLE(objRow("XDATA_SYORI"))
        mXGYOUSYA_CD = TO_STRING_NULLABLE(objRow("XGYOUSYA_CD"))
        mXGYOUSYA_KBN = TO_STRING_NULLABLE(objRow("XGYOUSYA_KBN"))
        mXSYARYOU_NO = TO_INTEGER_NULLABLE(objRow("XSYARYOU_NO"))
        mXUNKOU_NO = TO_STRING_NULLABLE(objRow("XUNKOU_NO"))
        mXTUMI_HOUKOU = TO_INTEGER_NULLABLE(objRow("XTUMI_HOUKOU"))
        mXTUMI_HOUHOU = TO_INTEGER_NULLABLE(objRow("XTUMI_HOUHOU"))
        mXSYASYU_KBN = TO_STRING_NULLABLE(objRow("XSYASYU_KBN"))
        mXHENSEI_NO_OYA = TO_STRING_NULLABLE(objRow("XHENSEI_NO_OYA"))
        mXSEND_NAME = TO_STRING_NULLABLE(objRow("XSEND_NAME"))
        mXSEND_ADDRESS = TO_STRING_NULLABLE(objRow("XSEND_ADDRESS"))
        mXBERTH_NO = TO_STRING_NULLABLE(objRow("XBERTH_NO"))
        mXKINKYU_KBN = TO_INTEGER_NULLABLE(objRow("XKINKYU_KBN"))
        mXKINKYU_LEVEL = TO_INTEGER_NULLABLE(objRow("XKINKYU_LEVEL"))
        mXSYARYOU_ENTRY_DT = TO_DATE_NULLABLE(objRow("XSYARYOU_ENTRY_DT"))
        mXSYUKKA_DIR_DT = TO_DATE_NULLABLE(objRow("XSYUKKA_DIR_DT"))
        mXOUT_START_DT = TO_DATE_NULLABLE(objRow("XOUT_START_DT"))
        mXOUT_END_DT = TO_DATE_NULLABLE(objRow("XOUT_END_DT"))
        mXTUMI_END_DT = TO_DATE_NULLABLE(objRow("XTUMI_END_DT"))
        mXSYUKKA_STS = TO_INTEGER_NULLABLE(objRow("XSYUKKA_STS"))
        mXIKKATU_SYUKKO = TO_INTEGER_NULLABLE(objRow("XIKKATU_SYUKKO"))
        mFENTRY_DT = TO_DATE_NULLABLE(objRow("FENTRY_DT"))


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
        strMsg &= "[ﾃｰﾌﾞﾙ名:出荷指示]"
        If IsNotNull(XSYUKKA_D) Then
            strMsg &= "[出荷日:" & XSYUKKA_D & "]"
        End If
        If IsNotNull(XHENSEI_NO) Then
            strMsg &= "[編成No.:" & XHENSEI_NO & "]"
        End If
        If IsNotNull(XDATA_KIND) Then
            strMsg &= "[ﾃﾞｰﾀ種類:" & XDATA_KIND & "]"
        End If
        If IsNotNull(XEDIT_KBN) Then
            strMsg &= "[編集区分:" & XEDIT_KBN & "]"
        End If
        If IsNotNull(XINPUT_PLACE) Then
            strMsg &= "[ｲﾝﾌﾟｯﾄ場所:" & XINPUT_PLACE & "]"
        End If
        If IsNotNull(XINPUT_DT) Then
            strMsg &= "[ｲﾝﾌﾟｯﾄ日付:" & XINPUT_DT & "]"
        End If
        If IsNotNull(XINPUT_NO) Then
            strMsg &= "[ｲﾝﾌﾟｯﾄNo.:" & XINPUT_NO & "]"
        End If
        If IsNotNull(XDENPYOU_NO) Then
            strMsg &= "[伝票No.:" & XDENPYOU_NO & "]"
        End If
        If IsNotNull(XBUNRUI_NO) Then
            strMsg &= "[分類No.:" & XBUNRUI_NO & "]"
        End If
        If IsNotNull(XDATA_DT) Then
            strMsg &= "[ﾃﾞｰﾀ日付:" & XDATA_DT & "]"
        End If
        If IsNotNull(XSOUKO_CD) Then
            strMsg &= "[倉庫ｺｰﾄﾞ:" & XSOUKO_CD & "]"
        End If
        If IsNotNull(XTOU_NO) Then
            strMsg &= "[棟ｺｰﾄﾞ:" & XTOU_NO & "]"
        End If
        If IsNotNull(XTORIHIKI_KBN) Then
            strMsg &= "[取引区分:" & XTORIHIKI_KBN & "]"
        End If
        If IsNotNull(XDATA_SYORI) Then
            strMsg &= "[ﾃﾞｰﾀ処理:" & XDATA_SYORI & "]"
        End If
        If IsNotNull(XGYOUSYA_CD) Then
            strMsg &= "[物流業者ｺｰﾄﾞ:" & XGYOUSYA_CD & "]"
        End If
        If IsNotNull(XGYOUSYA_KBN) Then
            strMsg &= "[業者区分:" & XGYOUSYA_KBN & "]"
        End If
        If IsNotNull(XSYARYOU_NO) Then
            strMsg &= "[車輌番号:" & XSYARYOU_NO & "]"
        End If
        If IsNotNull(XUNKOU_NO) Then
            strMsg &= "[倉庫別運行No.:" & XUNKOU_NO & "]"
        End If
        If IsNotNull(XTUMI_HOUKOU) Then
            strMsg &= "[積込方向:" & XTUMI_HOUKOU & "]"
        End If
        If IsNotNull(XTUMI_HOUHOU) Then
            strMsg &= "[積込方法:" & XTUMI_HOUHOU & "]"
        End If
        If IsNotNull(XSYASYU_KBN) Then
            strMsg &= "[車種区分:" & XSYASYU_KBN & "]"
        End If
        If IsNotNull(XHENSEI_NO_OYA) Then
            strMsg &= "[親編成No.:" & XHENSEI_NO_OYA & "]"
        End If
        If IsNotNull(XSEND_NAME) Then
            strMsg &= "[届け先名称:" & XSEND_NAME & "]"
        End If
        If IsNotNull(XSEND_ADDRESS) Then
            strMsg &= "[届け先住所:" & XSEND_ADDRESS & "]"
        End If
        If IsNotNull(XBERTH_NO) Then
            strMsg &= "[ﾊﾞｰｽNo.:" & XBERTH_NO & "]"
        End If
        If IsNotNull(XKINKYU_KBN) Then
            strMsg &= "[緊急出荷区分:" & XKINKYU_KBN & "]"
        End If
        If IsNotNull(XKINKYU_LEVEL) Then
            strMsg &= "[緊急度:" & XKINKYU_LEVEL & "]"
        End If
        If IsNotNull(XSYARYOU_ENTRY_DT) Then
            strMsg &= "[車輌受付日時:" & XSYARYOU_ENTRY_DT & "]"
        End If
        If IsNotNull(XSYUKKA_DIR_DT) Then
            strMsg &= "[出荷指示日時:" & XSYUKKA_DIR_DT & "]"
        End If
        If IsNotNull(XOUT_START_DT) Then
            strMsg &= "[出庫開始日時:" & XOUT_START_DT & "]"
        End If
        If IsNotNull(XOUT_END_DT) Then
            strMsg &= "[出庫完了日時:" & XOUT_END_DT & "]"
        End If
        If IsNotNull(XTUMI_END_DT) Then
            strMsg &= "[積込完了日時:" & XTUMI_END_DT & "]"
        End If
        If IsNotNull(XSYUKKA_STS) Then
            strMsg &= "[出荷状況:" & XSYUKKA_STS & "]"
        End If
        If IsNotNull(XIKKATU_SYUKKO) Then
            strMsg &= "[一括出庫指定:" & XIKKATU_SYUKKO & "]"
        End If
        If IsNotNull(FENTRY_DT) Then
            strMsg &= "[登録日時:" & FENTRY_DT & "]"
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

#Region "  出荷指示取得         (Public  GET_PLN_OUT_HENSEI_MINYUKOU)"
    Public Function GET_PLN_OUT_HENSEI_MINYUKOU() As RetCode
        Dim strSQL As New StringBuilder 'SQL文
        Dim objDataSet As New DataSet   'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String    'ﾃﾞｰﾀｾｯﾄ名
        Dim objRow As DataRow           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim objParameter(1, 0) As Object
        Dim strBindField(0) As String
        Dim objBindValue(0) As Object
        Dim strBindType(0) As String
        Dim strMsg As String            'ﾒｯｾｰｼﾞ


        '----------------
        'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
        '----------------
        If mXHENSEI_NO = DEFAULT_STRING Then
            strMsg = ERRMSG_ERR_PROPERTY & "[編成No]"
            Throw New System.Exception(strMsg)
        End If


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
        strSQL.Append(vbCrLf & "    XPLN_OUT")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")

        ReDim Preserve strBindField(UBound(strBindField) + 1)
        ReDim Preserve objBindValue(UBound(objBindValue) + 1)
        strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
        objBindValue(UBound(objBindValue)) = mXHENSEI_NO
        strSQL.Append(vbCrLf & "    AND XHENSEI_NO = :" & UBound(strBindField) - 1 & " --編成No.")

        ReDim Preserve strBindField(UBound(strBindField) + 1)
        ReDim Preserve objBindValue(UBound(objBindValue) + 1)
        strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
        objBindValue(UBound(objBindValue)) = XSYUKKA_STS_JNON
        strSQL.Append(vbCrLf & "    AND XSYUKKA_STS = :" & UBound(strBindField) - 1 & " --出荷状況")

        strSQL.Append(vbCrLf & " ORDER BY ")
        strSQL.Append(vbCrLf & "    XSYUKKA_D ")
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
        mobjAryMe = Nothing
        ObjDb.SQL = strSQL.ToString
        ObjDb.Parameter = objParameter
        objDataSet.Clear()
        strDataSetName = "XPLN_OUT"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XPLN_OUT(Owner, ObjDb, ObjDbLog)
                mobjAryMe(ii).SET_DATA(objRow)
            Next ii
            Return (RetCode.OK)
        Else
            Return (RetCode.NotFound)
        End If

    End Function
#End Region

#Region "  出荷指示取得         (Public  GET_PLN_OUT_HENSEI_MINCOMPLETE)"
    Public Function GET_PLN_OUT_HENSEI_MINCOMPLETE() As RetCode
        Dim strSQL As New StringBuilder 'SQL文
        Dim objDataSet As New DataSet   'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String    'ﾃﾞｰﾀｾｯﾄ名
        Dim objRow As DataRow           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim objParameter(1, 0) As Object
        Dim strBindField(0) As String
        Dim objBindValue(0) As Object
        Dim strBindType(0) As String
        Dim strMsg As String            'ﾒｯｾｰｼﾞ


        '----------------
        'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
        '----------------
        If mXHENSEI_NO = DEFAULT_STRING Then
            strMsg = ERRMSG_ERR_PROPERTY & "[編成No]"
            Throw New System.Exception(strMsg)
        End If


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
        strSQL.Append(vbCrLf & "    XPLN_OUT")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")

        ReDim Preserve strBindField(UBound(strBindField) + 1)
        ReDim Preserve objBindValue(UBound(objBindValue) + 1)
        strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
        objBindValue(UBound(objBindValue)) = mXHENSEI_NO
        strSQL.Append(vbCrLf & "    AND XHENSEI_NO = :" & UBound(strBindField) - 1 & " --編成No.")

        strSQL.Append(vbCrLf & " ORDER BY ")
        strSQL.Append(vbCrLf & "    XSYUKKA_D ")
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
        mobjAryMe = Nothing
        ObjDb.SQL = strSQL.ToString
        ObjDb.Parameter = objParameter
        objDataSet.Clear()
        strDataSetName = "XPLN_OUT"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            objRow = objDataSet.Tables(strDataSetName).Rows(0)
            Call SET_DATA(objRow)
            Return (RetCode.OK)
        Else
            Return (RetCode.NotFound)
        End If

    End Function
#End Region

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
