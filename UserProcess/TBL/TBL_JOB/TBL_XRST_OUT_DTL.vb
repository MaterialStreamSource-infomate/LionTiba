'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' 【名称】MaterialStreamﾃｰﾌﾞﾙｸﾗｽ
' 【機能】出荷実績詳細ﾃｰﾌﾞﾙｸﾗｽ
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
''' 出荷実績詳細ﾃｰﾌﾞﾙｸﾗｽ
''' </summary>
Public Class TBL_XRST_OUT_DTL
    Inherits clsTemplateTable

    '**********************************************************************************************
    '↓↓↓自動生成部
#Region "  ｸﾗｽ変数定義                  "
    'ﾌﾟﾛﾊﾟﾃｨ
    Private mobjAryMe As TBL_XRST_OUT_DTL()                                      '出荷実績詳細
    Private mstrUSER_SQL As String                                               'ﾕｰｻﾞｰSQL
    Private mORDER_BY As String                                                  'OrderBy句
    Private mWHERE As String                                                     'Where句
    Private mXSYUKKA_D As Nullable(Of Date)                                      '出荷日
    Private mXHENSEI_NO As String                                                '編成No.
    Private mXDENPYOU_NO As String                                               '伝票No.
    Private mXSYUKKA_RESULT_DT As Nullable(Of Date)                              '出荷実績日時
    Private mFPALLET_ID As String                                                'ﾊﾟﾚｯﾄID
    Private mFHINMEI_CD As String                                                '品目ｺｰﾄﾞ
    Private mFLOT_NO As String                                                   'ﾛｯﾄ№
    Private mXNUM As Nullable(Of Decimal)                                        '数量
    Private mXTUMI_HOUKOU As Nullable(Of Integer)                                '積込方向
    Private mXTUMI_HOUHOU As Nullable(Of Integer)                                '積込方法
    Private mFIN_KUBUN As Nullable(Of Integer)                                   '入庫区分
    Private mFARRIVE_DT As Nullable(Of Date)                                     '在庫発生日時
    Private mXPROD_LINE As String                                                '生産ﾗｲﾝ№
    Private mXFM_ST As Nullable(Of Integer)                                      '搬送元ｽﾃｰｼｮﾝNo.
    Private mFBUF_FM As Nullable(Of Integer)                                     '搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    Private mFARRAY_FM As Nullable(Of Integer)                                   '搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
    Private mFBUF_TO As Nullable(Of Integer)                                     '搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    Private mFARRAY_TO As Nullable(Of Integer)                                   '搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
    Private mXBERTH_NO As String                                                 'ﾊﾞｰｽNo.
    Private mXSEND_NAME As String                                                '届け先名称
    Private mXGYOUSYA_CD As String                                               '物流業者ｺｰﾄﾞ
    Private mXHINMEI_CD As String                                                '品目ｺｰﾄﾞ(正式品目ｺｰﾄﾞ)
    Private mXRAC_IN_DT As Nullable(Of Date)                                     '入庫日時
    Private mXSYARYOU_NO As Nullable(Of Integer)                                 '車輌番号
    Private mXKENPIN_KUBUN As String                                             '検品区分
    Private mXSAIMOKU As String                                                  '取引区分細目
    Private mXIDOU_KBN As String                                                 '移動区分
    Private mXSYASYU_KBN As String                                               '車種区分
    Private mXARTICLE_TYPE_CODE As Nullable(Of Integer)                          '品目種別(商品区分)
    Private mXUNKOU_NO As String                                                 '倉庫別運行No.
    Private mXHENSEI_NO_OYA As String                                            '親編成No.
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                  "
    ''' <summary>
    ''' ｼｽﾃﾑ変数 (自ｸﾗｽ型配列)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_XRST_OUT_DTL()
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
    ''' 出荷実績日時
    ''' </summary>
    Public Property XSYUKKA_RESULT_DT() As Nullable(Of Date)
        Get
            Return mXSYUKKA_RESULT_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mXSYUKKA_RESULT_DT = Value
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
    ''' 数量
    ''' </summary>
    Public Property XNUM() As Nullable(Of Decimal)
        Get
            Return mXNUM
        End Get
        Set(ByVal Value As Nullable(Of Decimal))
            mXNUM = Value
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
    ''' 生産ﾗｲﾝ№
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
    ''' 搬送元ｽﾃｰｼｮﾝNo.
    ''' </summary>
    Public Property XFM_ST() As Nullable(Of Integer)
        Get
            Return mXFM_ST
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXFM_ST = Value
        End Set
    End Property
    ''' <summary>
    ''' 搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    ''' </summary>
    Public Property FBUF_FM() As Nullable(Of Integer)
        Get
            Return mFBUF_FM
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFBUF_FM = Value
        End Set
    End Property
    ''' <summary>
    ''' 搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
    ''' </summary>
    Public Property FARRAY_FM() As Nullable(Of Integer)
        Get
            Return mFARRAY_FM
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFARRAY_FM = Value
        End Set
    End Property
    ''' <summary>
    ''' 搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    ''' </summary>
    Public Property FBUF_TO() As Nullable(Of Integer)
        Get
            Return mFBUF_TO
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFBUF_TO = Value
        End Set
    End Property
    ''' <summary>
    ''' 搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
    ''' </summary>
    Public Property FARRAY_TO() As Nullable(Of Integer)
        Get
            Return mFARRAY_TO
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFARRAY_TO = Value
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
    ''' 品目ｺｰﾄﾞ(正式品目ｺｰﾄﾞ)
    ''' </summary>
    Public Property XHINMEI_CD() As String
        Get
            Return mXHINMEI_CD
        End Get
        Set(ByVal Value As String)
            mXHINMEI_CD = Value
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
    ''' 取引区分細目
    ''' </summary>
    Public Property XSAIMOKU() As String
        Get
            Return mXSAIMOKU
        End Get
        Set(ByVal Value As String)
            mXSAIMOKU = Value
        End Set
    End Property
    ''' <summary>
    ''' 移動区分
    ''' </summary>
    Public Property XIDOU_KBN() As String
        Get
            Return mXIDOU_KBN
        End Get
        Set(ByVal Value As String)
            mXIDOU_KBN = Value
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
    ''' 品目種別(商品区分)
    ''' </summary>
    Public Property XARTICLE_TYPE_CODE() As Nullable(Of Integer)
        Get
            Return mXARTICLE_TYPE_CODE
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXARTICLE_TYPE_CODE = Value
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
    Public Function GET_XRST_OUT_DTL(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    XRST_OUT_DTL")
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
        If IsNull(XDENPYOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDENPYOU_NO
            strSQL.Append(vbCrLf & "    AND XDENPYOU_NO = :" & UBound(strBindField) - 1 & " --伝票No.")
        End If
        If IsNull(XSYUKKA_RESULT_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_RESULT_DT
            strSQL.Append(vbCrLf & "    AND XSYUKKA_RESULT_DT = :" & UBound(strBindField) - 1 & " --出荷実績日時")
        End If
        If IsNull(FPALLET_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄID")
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
            strSQL.Append(vbCrLf & "    AND FLOT_NO = :" & UBound(strBindField) - 1 & " --ﾛｯﾄ№")
        End If
        If IsNull(XNUM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXNUM
            strSQL.Append(vbCrLf & "    AND XNUM = :" & UBound(strBindField) - 1 & " --数量")
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
        If IsNull(FIN_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFIN_KUBUN
            strSQL.Append(vbCrLf & "    AND FIN_KUBUN = :" & UBound(strBindField) - 1 & " --入庫区分")
        End If
        If IsNull(FARRIVE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFARRIVE_DT
            strSQL.Append(vbCrLf & "    AND FARRIVE_DT = :" & UBound(strBindField) - 1 & " --在庫発生日時")
        End If
        If IsNull(XPROD_LINE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPROD_LINE
            strSQL.Append(vbCrLf & "    AND XPROD_LINE = :" & UBound(strBindField) - 1 & " --生産ﾗｲﾝ№")
        End If
        If IsNull(XFM_ST) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXFM_ST
            strSQL.Append(vbCrLf & "    AND XFM_ST = :" & UBound(strBindField) - 1 & " --搬送元ｽﾃｰｼｮﾝNo.")
        End If
        If IsNull(FBUF_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_FM
            strSQL.Append(vbCrLf & "    AND FBUF_FM = :" & UBound(strBindField) - 1 & " --搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNull(FARRAY_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFARRAY_FM
            strSQL.Append(vbCrLf & "    AND FARRAY_FM = :" & UBound(strBindField) - 1 & " --搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
        End If
        If IsNull(FBUF_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_TO
            strSQL.Append(vbCrLf & "    AND FBUF_TO = :" & UBound(strBindField) - 1 & " --搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNull(FARRAY_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFARRAY_TO
            strSQL.Append(vbCrLf & "    AND FARRAY_TO = :" & UBound(strBindField) - 1 & " --搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
        End If
        If IsNull(XBERTH_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_NO
            strSQL.Append(vbCrLf & "    AND XBERTH_NO = :" & UBound(strBindField) - 1 & " --ﾊﾞｰｽNo.")
        End If
        If IsNull(XSEND_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSEND_NAME
            strSQL.Append(vbCrLf & "    AND XSEND_NAME = :" & UBound(strBindField) - 1 & " --届け先名称")
        End If
        If IsNull(XGYOUSYA_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_CD
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_CD = :" & UBound(strBindField) - 1 & " --物流業者ｺｰﾄﾞ")
        End If
        If IsNull(XHINMEI_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHINMEI_CD
            strSQL.Append(vbCrLf & "    AND XHINMEI_CD = :" & UBound(strBindField) - 1 & " --品目ｺｰﾄﾞ(正式品目ｺｰﾄﾞ)")
        End If
        If IsNull(XRAC_IN_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXRAC_IN_DT
            strSQL.Append(vbCrLf & "    AND XRAC_IN_DT = :" & UBound(strBindField) - 1 & " --入庫日時")
        End If
        If IsNull(XSYARYOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYARYOU_NO
            strSQL.Append(vbCrLf & "    AND XSYARYOU_NO = :" & UBound(strBindField) - 1 & " --車輌番号")
        End If
        If IsNull(XKENPIN_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKENPIN_KUBUN
            strSQL.Append(vbCrLf & "    AND XKENPIN_KUBUN = :" & UBound(strBindField) - 1 & " --検品区分")
        End If
        If IsNull(XSAIMOKU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSAIMOKU
            strSQL.Append(vbCrLf & "    AND XSAIMOKU = :" & UBound(strBindField) - 1 & " --取引区分細目")
        End If
        If IsNull(XIDOU_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIDOU_KBN
            strSQL.Append(vbCrLf & "    AND XIDOU_KBN = :" & UBound(strBindField) - 1 & " --移動区分")
        End If
        If IsNull(XSYASYU_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYASYU_KBN
            strSQL.Append(vbCrLf & "    AND XSYASYU_KBN = :" & UBound(strBindField) - 1 & " --車種区分")
        End If
        If IsNull(XARTICLE_TYPE_CODE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXARTICLE_TYPE_CODE
            strSQL.Append(vbCrLf & "    AND XARTICLE_TYPE_CODE = :" & UBound(strBindField) - 1 & " --品目種別(商品区分)")
        End If
        If IsNull(XUNKOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXUNKOU_NO
            strSQL.Append(vbCrLf & "    AND XUNKOU_NO = :" & UBound(strBindField) - 1 & " --倉庫別運行No.")
        End If
        If IsNull(XHENSEI_NO_OYA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO_OYA = :" & UBound(strBindField) - 1 & " --親編成No.")
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
        strDataSetName = "XRST_OUT_DTL"
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
    Public Function GET_XRST_OUT_DTL_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    XRST_OUT_DTL")
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
        If IsNull(XDENPYOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDENPYOU_NO
            strSQL.Append(vbCrLf & "    AND XDENPYOU_NO = :" & UBound(strBindField) - 1 & " --伝票No.")
        End If
        If IsNull(XSYUKKA_RESULT_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_RESULT_DT
            strSQL.Append(vbCrLf & "    AND XSYUKKA_RESULT_DT = :" & UBound(strBindField) - 1 & " --出荷実績日時")
        End If
        If IsNull(FPALLET_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄID")
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
            strSQL.Append(vbCrLf & "    AND FLOT_NO = :" & UBound(strBindField) - 1 & " --ﾛｯﾄ№")
        End If
        If IsNull(XNUM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXNUM
            strSQL.Append(vbCrLf & "    AND XNUM = :" & UBound(strBindField) - 1 & " --数量")
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
        If IsNull(FIN_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFIN_KUBUN
            strSQL.Append(vbCrLf & "    AND FIN_KUBUN = :" & UBound(strBindField) - 1 & " --入庫区分")
        End If
        If IsNull(FARRIVE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFARRIVE_DT
            strSQL.Append(vbCrLf & "    AND FARRIVE_DT = :" & UBound(strBindField) - 1 & " --在庫発生日時")
        End If
        If IsNull(XPROD_LINE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPROD_LINE
            strSQL.Append(vbCrLf & "    AND XPROD_LINE = :" & UBound(strBindField) - 1 & " --生産ﾗｲﾝ№")
        End If
        If IsNull(XFM_ST) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXFM_ST
            strSQL.Append(vbCrLf & "    AND XFM_ST = :" & UBound(strBindField) - 1 & " --搬送元ｽﾃｰｼｮﾝNo.")
        End If
        If IsNull(FBUF_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_FM
            strSQL.Append(vbCrLf & "    AND FBUF_FM = :" & UBound(strBindField) - 1 & " --搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNull(FARRAY_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFARRAY_FM
            strSQL.Append(vbCrLf & "    AND FARRAY_FM = :" & UBound(strBindField) - 1 & " --搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
        End If
        If IsNull(FBUF_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_TO
            strSQL.Append(vbCrLf & "    AND FBUF_TO = :" & UBound(strBindField) - 1 & " --搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNull(FARRAY_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFARRAY_TO
            strSQL.Append(vbCrLf & "    AND FARRAY_TO = :" & UBound(strBindField) - 1 & " --搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
        End If
        If IsNull(XBERTH_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_NO
            strSQL.Append(vbCrLf & "    AND XBERTH_NO = :" & UBound(strBindField) - 1 & " --ﾊﾞｰｽNo.")
        End If
        If IsNull(XSEND_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSEND_NAME
            strSQL.Append(vbCrLf & "    AND XSEND_NAME = :" & UBound(strBindField) - 1 & " --届け先名称")
        End If
        If IsNull(XGYOUSYA_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_CD
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_CD = :" & UBound(strBindField) - 1 & " --物流業者ｺｰﾄﾞ")
        End If
        If IsNull(XHINMEI_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHINMEI_CD
            strSQL.Append(vbCrLf & "    AND XHINMEI_CD = :" & UBound(strBindField) - 1 & " --品目ｺｰﾄﾞ(正式品目ｺｰﾄﾞ)")
        End If
        If IsNull(XRAC_IN_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXRAC_IN_DT
            strSQL.Append(vbCrLf & "    AND XRAC_IN_DT = :" & UBound(strBindField) - 1 & " --入庫日時")
        End If
        If IsNull(XSYARYOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYARYOU_NO
            strSQL.Append(vbCrLf & "    AND XSYARYOU_NO = :" & UBound(strBindField) - 1 & " --車輌番号")
        End If
        If IsNull(XKENPIN_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKENPIN_KUBUN
            strSQL.Append(vbCrLf & "    AND XKENPIN_KUBUN = :" & UBound(strBindField) - 1 & " --検品区分")
        End If
        If IsNull(XSAIMOKU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSAIMOKU
            strSQL.Append(vbCrLf & "    AND XSAIMOKU = :" & UBound(strBindField) - 1 & " --取引区分細目")
        End If
        If IsNull(XIDOU_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIDOU_KBN
            strSQL.Append(vbCrLf & "    AND XIDOU_KBN = :" & UBound(strBindField) - 1 & " --移動区分")
        End If
        If IsNull(XSYASYU_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYASYU_KBN
            strSQL.Append(vbCrLf & "    AND XSYASYU_KBN = :" & UBound(strBindField) - 1 & " --車種区分")
        End If
        If IsNull(XARTICLE_TYPE_CODE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXARTICLE_TYPE_CODE
            strSQL.Append(vbCrLf & "    AND XARTICLE_TYPE_CODE = :" & UBound(strBindField) - 1 & " --品目種別(商品区分)")
        End If
        If IsNull(XUNKOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXUNKOU_NO
            strSQL.Append(vbCrLf & "    AND XUNKOU_NO = :" & UBound(strBindField) - 1 & " --倉庫別運行No.")
        End If
        If IsNull(XHENSEI_NO_OYA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO_OYA = :" & UBound(strBindField) - 1 & " --親編成No.")
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
        strDataSetName = "XRST_OUT_DTL"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XRST_OUT_DTL(Owner, objDb, objDbLog)
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
    Public Function GET_XRST_OUT_DTL_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "XRST_OUT_DTL"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XRST_OUT_DTL(Owner, objDb, objDbLog)
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
    Public Function GET_XRST_OUT_DTL_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    XRST_OUT_DTL")
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
        If IsNull(XDENPYOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDENPYOU_NO
            strSQL.Append(vbCrLf & "    AND XDENPYOU_NO = :" & UBound(strBindField) - 1 & " --伝票No.")
        End If
        If IsNull(XSYUKKA_RESULT_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_RESULT_DT
            strSQL.Append(vbCrLf & "    AND XSYUKKA_RESULT_DT = :" & UBound(strBindField) - 1 & " --出荷実績日時")
        End If
        If IsNull(FPALLET_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄID")
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
            strSQL.Append(vbCrLf & "    AND FLOT_NO = :" & UBound(strBindField) - 1 & " --ﾛｯﾄ№")
        End If
        If IsNull(XNUM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXNUM
            strSQL.Append(vbCrLf & "    AND XNUM = :" & UBound(strBindField) - 1 & " --数量")
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
        If IsNull(FIN_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFIN_KUBUN
            strSQL.Append(vbCrLf & "    AND FIN_KUBUN = :" & UBound(strBindField) - 1 & " --入庫区分")
        End If
        If IsNull(FARRIVE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFARRIVE_DT
            strSQL.Append(vbCrLf & "    AND FARRIVE_DT = :" & UBound(strBindField) - 1 & " --在庫発生日時")
        End If
        If IsNull(XPROD_LINE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPROD_LINE
            strSQL.Append(vbCrLf & "    AND XPROD_LINE = :" & UBound(strBindField) - 1 & " --生産ﾗｲﾝ№")
        End If
        If IsNull(XFM_ST) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXFM_ST
            strSQL.Append(vbCrLf & "    AND XFM_ST = :" & UBound(strBindField) - 1 & " --搬送元ｽﾃｰｼｮﾝNo.")
        End If
        If IsNull(FBUF_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_FM
            strSQL.Append(vbCrLf & "    AND FBUF_FM = :" & UBound(strBindField) - 1 & " --搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNull(FARRAY_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFARRAY_FM
            strSQL.Append(vbCrLf & "    AND FARRAY_FM = :" & UBound(strBindField) - 1 & " --搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
        End If
        If IsNull(FBUF_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_TO
            strSQL.Append(vbCrLf & "    AND FBUF_TO = :" & UBound(strBindField) - 1 & " --搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNull(FARRAY_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFARRAY_TO
            strSQL.Append(vbCrLf & "    AND FARRAY_TO = :" & UBound(strBindField) - 1 & " --搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
        End If
        If IsNull(XBERTH_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_NO
            strSQL.Append(vbCrLf & "    AND XBERTH_NO = :" & UBound(strBindField) - 1 & " --ﾊﾞｰｽNo.")
        End If
        If IsNull(XSEND_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSEND_NAME
            strSQL.Append(vbCrLf & "    AND XSEND_NAME = :" & UBound(strBindField) - 1 & " --届け先名称")
        End If
        If IsNull(XGYOUSYA_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_CD
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_CD = :" & UBound(strBindField) - 1 & " --物流業者ｺｰﾄﾞ")
        End If
        If IsNull(XHINMEI_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHINMEI_CD
            strSQL.Append(vbCrLf & "    AND XHINMEI_CD = :" & UBound(strBindField) - 1 & " --品目ｺｰﾄﾞ(正式品目ｺｰﾄﾞ)")
        End If
        If IsNull(XRAC_IN_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXRAC_IN_DT
            strSQL.Append(vbCrLf & "    AND XRAC_IN_DT = :" & UBound(strBindField) - 1 & " --入庫日時")
        End If
        If IsNull(XSYARYOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYARYOU_NO
            strSQL.Append(vbCrLf & "    AND XSYARYOU_NO = :" & UBound(strBindField) - 1 & " --車輌番号")
        End If
        If IsNull(XKENPIN_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKENPIN_KUBUN
            strSQL.Append(vbCrLf & "    AND XKENPIN_KUBUN = :" & UBound(strBindField) - 1 & " --検品区分")
        End If
        If IsNull(XSAIMOKU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSAIMOKU
            strSQL.Append(vbCrLf & "    AND XSAIMOKU = :" & UBound(strBindField) - 1 & " --取引区分細目")
        End If
        If IsNull(XIDOU_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIDOU_KBN
            strSQL.Append(vbCrLf & "    AND XIDOU_KBN = :" & UBound(strBindField) - 1 & " --移動区分")
        End If
        If IsNull(XSYASYU_KBN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYASYU_KBN
            strSQL.Append(vbCrLf & "    AND XSYASYU_KBN = :" & UBound(strBindField) - 1 & " --車種区分")
        End If
        If IsNull(XARTICLE_TYPE_CODE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXARTICLE_TYPE_CODE
            strSQL.Append(vbCrLf & "    AND XARTICLE_TYPE_CODE = :" & UBound(strBindField) - 1 & " --品目種別(商品区分)")
        End If
        If IsNull(XUNKOU_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXUNKOU_NO
            strSQL.Append(vbCrLf & "    AND XUNKOU_NO = :" & UBound(strBindField) - 1 & " --倉庫別運行No.")
        End If
        If IsNull(XHENSEI_NO_OYA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO_OYA = :" & UBound(strBindField) - 1 & " --親編成No.")
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
        strDataSetName = "XRST_OUT_DTL"
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
    Public Sub UPDATE_XRST_OUT_DTL()
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
        ElseIf IsNull(mXSYUKKA_RESULT_DT) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[出荷実績日時]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFPALLET_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾊﾟﾚｯﾄID]"
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
        strSQL.Append(vbCrLf & "    XRST_OUT_DTL")
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
        If IsNull(mXSYUKKA_RESULT_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_RESULT_DT = NULL --出荷実績日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_RESULT_DT = NULL --出荷実績日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_RESULT_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSYUKKA_RESULT_DT = :" & Ubound(strBindField) - 1 & " --出荷実績日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSYUKKA_RESULT_DT = :" & Ubound(strBindField) - 1 & " --出荷実績日時")
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
        If IsNull(mXNUM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XNUM = NULL --数量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XNUM = NULL --数量")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXNUM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XNUM = :" & Ubound(strBindField) - 1 & " --数量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XNUM = :" & Ubound(strBindField) - 1 & " --数量")
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
        If IsNull(mXPROD_LINE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XPROD_LINE = NULL --生産ﾗｲﾝ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XPROD_LINE = NULL --生産ﾗｲﾝ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPROD_LINE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XPROD_LINE = :" & Ubound(strBindField) - 1 & " --生産ﾗｲﾝ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XPROD_LINE = :" & Ubound(strBindField) - 1 & " --生産ﾗｲﾝ№")
        End If
        intCount = intCount + 1
        If IsNull(mXFM_ST) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XFM_ST = NULL --搬送元ｽﾃｰｼｮﾝNo.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XFM_ST = NULL --搬送元ｽﾃｰｼｮﾝNo.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXFM_ST
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XFM_ST = :" & Ubound(strBindField) - 1 & " --搬送元ｽﾃｰｼｮﾝNo.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XFM_ST = :" & Ubound(strBindField) - 1 & " --搬送元ｽﾃｰｼｮﾝNo.")
        End If
        intCount = intCount + 1
        If IsNull(mFBUF_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FBUF_FM = NULL --搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FBUF_FM = NULL --搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FBUF_FM = :" & Ubound(strBindField) - 1 & " --搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FBUF_FM = :" & Ubound(strBindField) - 1 & " --搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        intCount = intCount + 1
        If IsNull(mFARRAY_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FARRAY_FM = NULL --搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FARRAY_FM = NULL --搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFARRAY_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FARRAY_FM = :" & Ubound(strBindField) - 1 & " --搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FARRAY_FM = :" & Ubound(strBindField) - 1 & " --搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
        End If
        intCount = intCount + 1
        If IsNull(mFBUF_TO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FBUF_TO = NULL --搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FBUF_TO = NULL --搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_TO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FBUF_TO = :" & Ubound(strBindField) - 1 & " --搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FBUF_TO = :" & Ubound(strBindField) - 1 & " --搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        intCount = intCount + 1
        If IsNull(mFARRAY_TO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FARRAY_TO = NULL --搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FARRAY_TO = NULL --搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFARRAY_TO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FARRAY_TO = :" & Ubound(strBindField) - 1 & " --搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FARRAY_TO = :" & Ubound(strBindField) - 1 & " --搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
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
        If IsNull(mXHINMEI_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XHINMEI_CD = NULL --品目ｺｰﾄﾞ(正式品目ｺｰﾄﾞ)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XHINMEI_CD = NULL --品目ｺｰﾄﾞ(正式品目ｺｰﾄﾞ)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHINMEI_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XHINMEI_CD = :" & Ubound(strBindField) - 1 & " --品目ｺｰﾄﾞ(正式品目ｺｰﾄﾞ)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XHINMEI_CD = :" & Ubound(strBindField) - 1 & " --品目ｺｰﾄﾞ(正式品目ｺｰﾄﾞ)")
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
        If IsNull(mXSAIMOKU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSAIMOKU = NULL --取引区分細目")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSAIMOKU = NULL --取引区分細目")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSAIMOKU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSAIMOKU = :" & Ubound(strBindField) - 1 & " --取引区分細目")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSAIMOKU = :" & Ubound(strBindField) - 1 & " --取引区分細目")
        End If
        intCount = intCount + 1
        If IsNull(mXIDOU_KBN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XIDOU_KBN = NULL --移動区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XIDOU_KBN = NULL --移動区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIDOU_KBN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XIDOU_KBN = :" & Ubound(strBindField) - 1 & " --移動区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XIDOU_KBN = :" & Ubound(strBindField) - 1 & " --移動区分")
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
        If IsNull(mXARTICLE_TYPE_CODE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XARTICLE_TYPE_CODE = NULL --品目種別(商品区分)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XARTICLE_TYPE_CODE = NULL --品目種別(商品区分)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXARTICLE_TYPE_CODE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XARTICLE_TYPE_CODE = :" & Ubound(strBindField) - 1 & " --品目種別(商品区分)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XARTICLE_TYPE_CODE = :" & Ubound(strBindField) - 1 & " --品目種別(商品区分)")
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
        If IsNull(XSYUKKA_RESULT_DT) = True Then
            strSQL.Append(vbCrLf & "    AND XSYUKKA_RESULT_DT IS NULL --出荷実績日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_RESULT_DT
            strSQL.Append(vbCrLf & "    AND XSYUKKA_RESULT_DT = :" & UBound(strBindField) - 1 & " --出荷実績日時")
        End If
        If IsNull(FPALLET_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FPALLET_ID IS NULL --ﾊﾟﾚｯﾄID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄID")
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
    Public Sub ADD_XRST_OUT_DTL()
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
        ElseIf IsNull(mXSYUKKA_RESULT_DT) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[出荷実績日時]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFPALLET_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾊﾟﾚｯﾄID]"
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
        strSQL.Append(vbCrLf & "    XRST_OUT_DTL")
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
        If IsNull(mXSYUKKA_RESULT_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --出荷実績日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --出荷実績日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_RESULT_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --出荷実績日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --出荷実績日時")
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
        If IsNull(mXNUM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --数量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --数量")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXNUM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --数量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --数量")
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
        If IsNull(mXPROD_LINE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --生産ﾗｲﾝ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --生産ﾗｲﾝ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPROD_LINE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --生産ﾗｲﾝ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --生産ﾗｲﾝ№")
        End If
        intCount = intCount + 1
        If IsNull(mXFM_ST) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --搬送元ｽﾃｰｼｮﾝNo.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --搬送元ｽﾃｰｼｮﾝNo.")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXFM_ST
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --搬送元ｽﾃｰｼｮﾝNo.")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --搬送元ｽﾃｰｼｮﾝNo.")
        End If
        intCount = intCount + 1
        If IsNull(mFBUF_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        intCount = intCount + 1
        If IsNull(mFARRAY_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFARRAY_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
        End If
        intCount = intCount + 1
        If IsNull(mFBUF_TO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_TO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        intCount = intCount + 1
        If IsNull(mFARRAY_TO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFARRAY_TO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
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
        If IsNull(mXHINMEI_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --品目ｺｰﾄﾞ(正式品目ｺｰﾄﾞ)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --品目ｺｰﾄﾞ(正式品目ｺｰﾄﾞ)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHINMEI_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --品目ｺｰﾄﾞ(正式品目ｺｰﾄﾞ)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --品目ｺｰﾄﾞ(正式品目ｺｰﾄﾞ)")
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
        If IsNull(mXSAIMOKU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --取引区分細目")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --取引区分細目")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSAIMOKU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --取引区分細目")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --取引区分細目")
        End If
        intCount = intCount + 1
        If IsNull(mXIDOU_KBN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --移動区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --移動区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIDOU_KBN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --移動区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --移動区分")
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
        If IsNull(mXARTICLE_TYPE_CODE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --品目種別(商品区分)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --品目種別(商品区分)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXARTICLE_TYPE_CODE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --品目種別(商品区分)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --品目種別(商品区分)")
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
    Public Sub DELETE_XRST_OUT_DTL()
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
        ElseIf IsNull(mXSYUKKA_RESULT_DT) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[出荷実績日時]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFPALLET_ID) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾊﾟﾚｯﾄID]"
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
        strSQL.Append(vbCrLf & "    XRST_OUT_DTL")
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
        If IsNull(XSYUKKA_RESULT_DT) = True Then
            strSQL.Append(vbCrLf & "    AND XSYUKKA_RESULT_DT IS NULL --出荷実績日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_RESULT_DT
            strSQL.Append(vbCrLf & "    AND XSYUKKA_RESULT_DT = :" & UBound(strBindField) - 1 & " --出荷実績日時")
        End If
        If IsNull(FPALLET_ID) = True Then
            strSQL.Append(vbCrLf & "    AND FPALLET_ID IS NULL --ﾊﾟﾚｯﾄID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄID")
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
    Public Sub DELETE_XRST_OUT_DTL_ANY()
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
        strSQL.Append(vbCrLf & "    XRST_OUT_DTL")
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
        If IsNotNull(XDENPYOU_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDENPYOU_NO
            strSQL.Append(vbCrLf & "    AND XDENPYOU_NO = :" & UBound(strBindField) - 1 & " --伝票No.")
        End If
        If IsNotNull(XSYUKKA_RESULT_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYUKKA_RESULT_DT
            strSQL.Append(vbCrLf & "    AND XSYUKKA_RESULT_DT = :" & UBound(strBindField) - 1 & " --出荷実績日時")
        End If
        If IsNotNull(FPALLET_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄID")
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
            strSQL.Append(vbCrLf & "    AND FLOT_NO = :" & UBound(strBindField) - 1 & " --ﾛｯﾄ№")
        End If
        If IsNotNull(XNUM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXNUM
            strSQL.Append(vbCrLf & "    AND XNUM = :" & UBound(strBindField) - 1 & " --数量")
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
        If IsNotNull(FIN_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFIN_KUBUN
            strSQL.Append(vbCrLf & "    AND FIN_KUBUN = :" & UBound(strBindField) - 1 & " --入庫区分")
        End If
        If IsNotNull(FARRIVE_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFARRIVE_DT
            strSQL.Append(vbCrLf & "    AND FARRIVE_DT = :" & UBound(strBindField) - 1 & " --在庫発生日時")
        End If
        If IsNotNull(XPROD_LINE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPROD_LINE
            strSQL.Append(vbCrLf & "    AND XPROD_LINE = :" & UBound(strBindField) - 1 & " --生産ﾗｲﾝ№")
        End If
        If IsNotNull(XFM_ST) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXFM_ST
            strSQL.Append(vbCrLf & "    AND XFM_ST = :" & UBound(strBindField) - 1 & " --搬送元ｽﾃｰｼｮﾝNo.")
        End If
        If IsNotNull(FBUF_FM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_FM
            strSQL.Append(vbCrLf & "    AND FBUF_FM = :" & UBound(strBindField) - 1 & " --搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNotNull(FARRAY_FM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFARRAY_FM
            strSQL.Append(vbCrLf & "    AND FARRAY_FM = :" & UBound(strBindField) - 1 & " --搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
        End If
        If IsNotNull(FBUF_TO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_TO
            strSQL.Append(vbCrLf & "    AND FBUF_TO = :" & UBound(strBindField) - 1 & " --搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNotNull(FARRAY_TO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFARRAY_TO
            strSQL.Append(vbCrLf & "    AND FARRAY_TO = :" & UBound(strBindField) - 1 & " --搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
        End If
        If IsNotNull(XBERTH_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBERTH_NO
            strSQL.Append(vbCrLf & "    AND XBERTH_NO = :" & UBound(strBindField) - 1 & " --ﾊﾞｰｽNo.")
        End If
        If IsNotNull(XSEND_NAME) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSEND_NAME
            strSQL.Append(vbCrLf & "    AND XSEND_NAME = :" & UBound(strBindField) - 1 & " --届け先名称")
        End If
        If IsNotNull(XGYOUSYA_CD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXGYOUSYA_CD
            strSQL.Append(vbCrLf & "    AND XGYOUSYA_CD = :" & UBound(strBindField) - 1 & " --物流業者ｺｰﾄﾞ")
        End If
        If IsNotNull(XHINMEI_CD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHINMEI_CD
            strSQL.Append(vbCrLf & "    AND XHINMEI_CD = :" & UBound(strBindField) - 1 & " --品目ｺｰﾄﾞ(正式品目ｺｰﾄﾞ)")
        End If
        If IsNotNull(XRAC_IN_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXRAC_IN_DT
            strSQL.Append(vbCrLf & "    AND XRAC_IN_DT = :" & UBound(strBindField) - 1 & " --入庫日時")
        End If
        If IsNotNull(XSYARYOU_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYARYOU_NO
            strSQL.Append(vbCrLf & "    AND XSYARYOU_NO = :" & UBound(strBindField) - 1 & " --車輌番号")
        End If
        If IsNotNull(XKENPIN_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXKENPIN_KUBUN
            strSQL.Append(vbCrLf & "    AND XKENPIN_KUBUN = :" & UBound(strBindField) - 1 & " --検品区分")
        End If
        If IsNotNull(XSAIMOKU) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSAIMOKU
            strSQL.Append(vbCrLf & "    AND XSAIMOKU = :" & UBound(strBindField) - 1 & " --取引区分細目")
        End If
        If IsNotNull(XIDOU_KBN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIDOU_KBN
            strSQL.Append(vbCrLf & "    AND XIDOU_KBN = :" & UBound(strBindField) - 1 & " --移動区分")
        End If
        If IsNotNull(XSYASYU_KBN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSYASYU_KBN
            strSQL.Append(vbCrLf & "    AND XSYASYU_KBN = :" & UBound(strBindField) - 1 & " --車種区分")
        End If
        If IsNotNull(XARTICLE_TYPE_CODE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXARTICLE_TYPE_CODE
            strSQL.Append(vbCrLf & "    AND XARTICLE_TYPE_CODE = :" & UBound(strBindField) - 1 & " --品目種別(商品区分)")
        End If
        If IsNotNull(XUNKOU_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXUNKOU_NO
            strSQL.Append(vbCrLf & "    AND XUNKOU_NO = :" & UBound(strBindField) - 1 & " --倉庫別運行No.")
        End If
        If IsNotNull(XHENSEI_NO_OYA) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHENSEI_NO_OYA
            strSQL.Append(vbCrLf & "    AND XHENSEI_NO_OYA = :" & UBound(strBindField) - 1 & " --親編成No.")
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
        If IsNothing(objType.GetProperty("XDENPYOU_NO")) = False Then mXDENPYOU_NO = objObject.XDENPYOU_NO '伝票No.
        If IsNothing(objType.GetProperty("XSYUKKA_RESULT_DT")) = False Then mXSYUKKA_RESULT_DT = objObject.XSYUKKA_RESULT_DT '出荷実績日時
        If IsNothing(objType.GetProperty("FPALLET_ID")) = False Then mFPALLET_ID = objObject.FPALLET_ID 'ﾊﾟﾚｯﾄID
        If IsNothing(objType.GetProperty("FHINMEI_CD")) = False Then mFHINMEI_CD = objObject.FHINMEI_CD '品目ｺｰﾄﾞ
        If IsNothing(objType.GetProperty("FLOT_NO")) = False Then mFLOT_NO = objObject.FLOT_NO 'ﾛｯﾄ№
        If IsNothing(objType.GetProperty("XNUM")) = False Then mXNUM = objObject.XNUM '数量
        If IsNothing(objType.GetProperty("XTUMI_HOUKOU")) = False Then mXTUMI_HOUKOU = objObject.XTUMI_HOUKOU '積込方向
        If IsNothing(objType.GetProperty("XTUMI_HOUHOU")) = False Then mXTUMI_HOUHOU = objObject.XTUMI_HOUHOU '積込方法
        If IsNothing(objType.GetProperty("FIN_KUBUN")) = False Then mFIN_KUBUN = objObject.FIN_KUBUN '入庫区分
        If IsNothing(objType.GetProperty("FARRIVE_DT")) = False Then mFARRIVE_DT = objObject.FARRIVE_DT '在庫発生日時
        If IsNothing(objType.GetProperty("XPROD_LINE")) = False Then mXPROD_LINE = objObject.XPROD_LINE '生産ﾗｲﾝ№
        If IsNothing(objType.GetProperty("XFM_ST")) = False Then mXFM_ST = objObject.XFM_ST '搬送元ｽﾃｰｼｮﾝNo.
        If IsNothing(objType.GetProperty("FBUF_FM")) = False Then mFBUF_FM = objObject.FBUF_FM '搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        If IsNothing(objType.GetProperty("FARRAY_FM")) = False Then mFARRAY_FM = objObject.FARRAY_FM '搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
        If IsNothing(objType.GetProperty("FBUF_TO")) = False Then mFBUF_TO = objObject.FBUF_TO '搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        If IsNothing(objType.GetProperty("FARRAY_TO")) = False Then mFARRAY_TO = objObject.FARRAY_TO '搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
        If IsNothing(objType.GetProperty("XBERTH_NO")) = False Then mXBERTH_NO = objObject.XBERTH_NO 'ﾊﾞｰｽNo.
        If IsNothing(objType.GetProperty("XSEND_NAME")) = False Then mXSEND_NAME = objObject.XSEND_NAME '届け先名称
        If IsNothing(objType.GetProperty("XGYOUSYA_CD")) = False Then mXGYOUSYA_CD = objObject.XGYOUSYA_CD '物流業者ｺｰﾄﾞ
        If IsNothing(objType.GetProperty("XHINMEI_CD")) = False Then mXHINMEI_CD = objObject.XHINMEI_CD '品目ｺｰﾄﾞ(正式品目ｺｰﾄﾞ)
        If IsNothing(objType.GetProperty("XRAC_IN_DT")) = False Then mXRAC_IN_DT = objObject.XRAC_IN_DT '入庫日時
        If IsNothing(objType.GetProperty("XSYARYOU_NO")) = False Then mXSYARYOU_NO = objObject.XSYARYOU_NO '車輌番号
        If IsNothing(objType.GetProperty("XKENPIN_KUBUN")) = False Then mXKENPIN_KUBUN = objObject.XKENPIN_KUBUN '検品区分
        If IsNothing(objType.GetProperty("XSAIMOKU")) = False Then mXSAIMOKU = objObject.XSAIMOKU '取引区分細目
        If IsNothing(objType.GetProperty("XIDOU_KBN")) = False Then mXIDOU_KBN = objObject.XIDOU_KBN '移動区分
        If IsNothing(objType.GetProperty("XSYASYU_KBN")) = False Then mXSYASYU_KBN = objObject.XSYASYU_KBN '車種区分
        If IsNothing(objType.GetProperty("XARTICLE_TYPE_CODE")) = False Then mXARTICLE_TYPE_CODE = objObject.XARTICLE_TYPE_CODE '品目種別(商品区分)
        If IsNothing(objType.GetProperty("XUNKOU_NO")) = False Then mXUNKOU_NO = objObject.XUNKOU_NO '倉庫別運行No.
        If IsNothing(objType.GetProperty("XHENSEI_NO_OYA")) = False Then mXHENSEI_NO_OYA = objObject.XHENSEI_NO_OYA '親編成No.

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
        mXDENPYOU_NO = Nothing
        mXSYUKKA_RESULT_DT = Nothing
        mFPALLET_ID = Nothing
        mFHINMEI_CD = Nothing
        mFLOT_NO = Nothing
        mXNUM = Nothing
        mXTUMI_HOUKOU = Nothing
        mXTUMI_HOUHOU = Nothing
        mFIN_KUBUN = Nothing
        mFARRIVE_DT = Nothing
        mXPROD_LINE = Nothing
        mXFM_ST = Nothing
        mFBUF_FM = Nothing
        mFARRAY_FM = Nothing
        mFBUF_TO = Nothing
        mFARRAY_TO = Nothing
        mXBERTH_NO = Nothing
        mXSEND_NAME = Nothing
        mXGYOUSYA_CD = Nothing
        mXHINMEI_CD = Nothing
        mXRAC_IN_DT = Nothing
        mXSYARYOU_NO = Nothing
        mXKENPIN_KUBUN = Nothing
        mXSAIMOKU = Nothing
        mXIDOU_KBN = Nothing
        mXSYASYU_KBN = Nothing
        mXARTICLE_TYPE_CODE = Nothing
        mXUNKOU_NO = Nothing
        mXHENSEI_NO_OYA = Nothing


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
        mXDENPYOU_NO = TO_STRING_NULLABLE(objRow("XDENPYOU_NO"))
        mXSYUKKA_RESULT_DT = TO_DATE_NULLABLE(objRow("XSYUKKA_RESULT_DT"))
        mFPALLET_ID = TO_STRING_NULLABLE(objRow("FPALLET_ID"))
        mFHINMEI_CD = TO_STRING_NULLABLE(objRow("FHINMEI_CD"))
        mFLOT_NO = TO_STRING_NULLABLE(objRow("FLOT_NO"))
        mXNUM = TO_DECIMAL_NULLABLE(objRow("XNUM"))
        mXTUMI_HOUKOU = TO_INTEGER_NULLABLE(objRow("XTUMI_HOUKOU"))
        mXTUMI_HOUHOU = TO_INTEGER_NULLABLE(objRow("XTUMI_HOUHOU"))
        mFIN_KUBUN = TO_INTEGER_NULLABLE(objRow("FIN_KUBUN"))
        mFARRIVE_DT = TO_DATE_NULLABLE(objRow("FARRIVE_DT"))
        mXPROD_LINE = TO_STRING_NULLABLE(objRow("XPROD_LINE"))
        mXFM_ST = TO_INTEGER_NULLABLE(objRow("XFM_ST"))
        mFBUF_FM = TO_INTEGER_NULLABLE(objRow("FBUF_FM"))
        mFARRAY_FM = TO_INTEGER_NULLABLE(objRow("FARRAY_FM"))
        mFBUF_TO = TO_INTEGER_NULLABLE(objRow("FBUF_TO"))
        mFARRAY_TO = TO_INTEGER_NULLABLE(objRow("FARRAY_TO"))
        mXBERTH_NO = TO_STRING_NULLABLE(objRow("XBERTH_NO"))
        mXSEND_NAME = TO_STRING_NULLABLE(objRow("XSEND_NAME"))
        mXGYOUSYA_CD = TO_STRING_NULLABLE(objRow("XGYOUSYA_CD"))
        mXHINMEI_CD = TO_STRING_NULLABLE(objRow("XHINMEI_CD"))
        mXRAC_IN_DT = TO_DATE_NULLABLE(objRow("XRAC_IN_DT"))
        mXSYARYOU_NO = TO_INTEGER_NULLABLE(objRow("XSYARYOU_NO"))
        mXKENPIN_KUBUN = TO_STRING_NULLABLE(objRow("XKENPIN_KUBUN"))
        mXSAIMOKU = TO_STRING_NULLABLE(objRow("XSAIMOKU"))
        mXIDOU_KBN = TO_STRING_NULLABLE(objRow("XIDOU_KBN"))
        mXSYASYU_KBN = TO_STRING_NULLABLE(objRow("XSYASYU_KBN"))
        mXARTICLE_TYPE_CODE = TO_INTEGER_NULLABLE(objRow("XARTICLE_TYPE_CODE"))
        mXUNKOU_NO = TO_STRING_NULLABLE(objRow("XUNKOU_NO"))
        mXHENSEI_NO_OYA = TO_STRING_NULLABLE(objRow("XHENSEI_NO_OYA"))


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
        strMsg &= "[ﾃｰﾌﾞﾙ名:出荷実績詳細]"
        If IsNotNull(XSYUKKA_D) Then
            strMsg &= "[出荷日:" & XSYUKKA_D & "]"
        End If
        If IsNotNull(XHENSEI_NO) Then
            strMsg &= "[編成No.:" & XHENSEI_NO & "]"
        End If
        If IsNotNull(XDENPYOU_NO) Then
            strMsg &= "[伝票No.:" & XDENPYOU_NO & "]"
        End If
        If IsNotNull(XSYUKKA_RESULT_DT) Then
            strMsg &= "[出荷実績日時:" & XSYUKKA_RESULT_DT & "]"
        End If
        If IsNotNull(FPALLET_ID) Then
            strMsg &= "[ﾊﾟﾚｯﾄID:" & FPALLET_ID & "]"
        End If
        If IsNotNull(FHINMEI_CD) Then
            strMsg &= "[品目ｺｰﾄﾞ:" & FHINMEI_CD & "]"
        End If
        If IsNotNull(FLOT_NO) Then
            strMsg &= "[ﾛｯﾄ№:" & FLOT_NO & "]"
        End If
        If IsNotNull(XNUM) Then
            strMsg &= "[数量:" & XNUM & "]"
        End If
        If IsNotNull(XTUMI_HOUKOU) Then
            strMsg &= "[積込方向:" & XTUMI_HOUKOU & "]"
        End If
        If IsNotNull(XTUMI_HOUHOU) Then
            strMsg &= "[積込方法:" & XTUMI_HOUHOU & "]"
        End If
        If IsNotNull(FIN_KUBUN) Then
            strMsg &= "[入庫区分:" & FIN_KUBUN & "]"
        End If
        If IsNotNull(FARRIVE_DT) Then
            strMsg &= "[在庫発生日時:" & FARRIVE_DT & "]"
        End If
        If IsNotNull(XPROD_LINE) Then
            strMsg &= "[生産ﾗｲﾝ№:" & XPROD_LINE & "]"
        End If
        If IsNotNull(XFM_ST) Then
            strMsg &= "[搬送元ｽﾃｰｼｮﾝNo.:" & XFM_ST & "]"
        End If
        If IsNotNull(FBUF_FM) Then
            strMsg &= "[搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & FBUF_FM & "]"
        End If
        If IsNotNull(FARRAY_FM) Then
            strMsg &= "[搬送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№:" & FARRAY_FM & "]"
        End If
        If IsNotNull(FBUF_TO) Then
            strMsg &= "[搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & FBUF_TO & "]"
        End If
        If IsNotNull(FARRAY_TO) Then
            strMsg &= "[搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№:" & FARRAY_TO & "]"
        End If
        If IsNotNull(XBERTH_NO) Then
            strMsg &= "[ﾊﾞｰｽNo.:" & XBERTH_NO & "]"
        End If
        If IsNotNull(XSEND_NAME) Then
            strMsg &= "[届け先名称:" & XSEND_NAME & "]"
        End If
        If IsNotNull(XGYOUSYA_CD) Then
            strMsg &= "[物流業者ｺｰﾄﾞ:" & XGYOUSYA_CD & "]"
        End If
        If IsNotNull(XHINMEI_CD) Then
            strMsg &= "[品目ｺｰﾄﾞ(正式品目ｺｰﾄﾞ):" & XHINMEI_CD & "]"
        End If
        If IsNotNull(XRAC_IN_DT) Then
            strMsg &= "[入庫日時:" & XRAC_IN_DT & "]"
        End If
        If IsNotNull(XSYARYOU_NO) Then
            strMsg &= "[車輌番号:" & XSYARYOU_NO & "]"
        End If
        If IsNotNull(XKENPIN_KUBUN) Then
            strMsg &= "[検品区分:" & XKENPIN_KUBUN & "]"
        End If
        If IsNotNull(XSAIMOKU) Then
            strMsg &= "[取引区分細目:" & XSAIMOKU & "]"
        End If
        If IsNotNull(XIDOU_KBN) Then
            strMsg &= "[移動区分:" & XIDOU_KBN & "]"
        End If
        If IsNotNull(XSYASYU_KBN) Then
            strMsg &= "[車種区分:" & XSYASYU_KBN & "]"
        End If
        If IsNotNull(XARTICLE_TYPE_CODE) Then
            strMsg &= "[品目種別(商品区分):" & XARTICLE_TYPE_CODE & "]"
        End If
        If IsNotNull(XUNKOU_NO) Then
            strMsg &= "[倉庫別運行No.:" & XUNKOU_NO & "]"
        End If
        If IsNotNull(XHENSEI_NO_OYA) Then
            strMsg &= "[親編成No.:" & XHENSEI_NO_OYA & "]"
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
