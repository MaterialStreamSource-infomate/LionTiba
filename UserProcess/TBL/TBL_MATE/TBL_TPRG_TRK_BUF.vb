'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' 【名称】MaterialStreamﾃｰﾌﾞﾙｸﾗｽ
' 【機能】ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾃｰﾌﾞﾙｸﾗｽ
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
''' ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾃｰﾌﾞﾙｸﾗｽ
''' </summary>
Public Class TBL_TPRG_TRK_BUF
    Inherits clsTemplateTable

    '**********************************************************************************************
    '↓↓↓自動生成部
#Region "  ｸﾗｽ変数定義                  "
    'ﾌﾟﾛﾊﾟﾃｨ
    Private mobjAryMe As TBL_TPRG_TRK_BUF()                                      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
    Private mstrUSER_SQL As String                                               'ﾕｰｻﾞｰSQL
    Private mORDER_BY As String                                                  'OrderBy句
    Private mWHERE As String                                                     'Where句
    Private mFTRK_BUF_NO As Nullable(Of Integer)                                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    Private mFTRK_BUF_ARRAY As Nullable(Of Integer)                              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
    Private mFSERCH_NO As Nullable(Of Integer)                                   '空検索順№
    Private mFTRNS_ADDRESS As String                                             '搬送指示用ｱﾄﾞﾚｽ
    Private mFDISP_ADDRESS As String                                             '表記用ｱﾄﾞﾚｽ
    Private mFRAC_RETU As Nullable(Of Integer)                                   '列
    Private mFRAC_REN As Nullable(Of Integer)                                    '連
    Private mFRAC_DAN As Nullable(Of Integer)                                    '段
    Private mFRAC_EDA As Nullable(Of Integer)                                    '枝
    Private mFREMOVE_KIND As Nullable(Of Integer)                                '禁止有無
    Private mFRAC_FORM As Nullable(Of Integer)                                   '棚形状種別
    Private mFRES_KIND As Nullable(Of Integer)                                   '引当状態
    Private mFRSV_PALLET As String                                               '仮引当ﾊﾟﾚｯﾄID
    Private mFTR_FM As Nullable(Of Integer)                                      '搬送FMﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    Private mFTR_TO As Nullable(Of Integer)                                      '搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    Private mFTR_IDOU As Nullable(Of Integer)                                    '搬送TO移動ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    Private mFTRNS_FM As String                                                  '搬送指令用FM
    Private mFTRNS_TO As String                                                  '搬送指令用TO
    Private mFRSV_BUF_FM As Nullable(Of Integer)                                 'FM引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    Private mFRSV_ARRAY_FM As Nullable(Of Integer)                               'FM引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
    Private mFRSV_BUF_TO As Nullable(Of Integer)                                 'TO引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    Private mFRSV_ARRAY_TO As Nullable(Of Integer)                               'TO引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
    Private mFDISP_ADDRESS_FM As String                                          'FM表記用ｱﾄﾞﾚｽ
    Private mFDISP_ADDRESS_TO As String                                          'TO表記用ｱﾄﾞﾚｽ
    Private mFDISPLOG_ADDRESS_FM As String                                       'FM表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用
    Private mFDISPLOG_ADDRESS_TO As String                                       'TO表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用
    Private mFPALLET_ID As String                                                'ﾊﾟﾚｯﾄID
    Private mFBUF_IN_DT As Nullable(Of Date)                                     'ﾊﾞｯﾌｧ入日時
    Private mFRAC_BUNRUI As String                                               '棚分類
    Private mXTANA_BLOCK As Nullable(Of Integer)                                 '棚ﾌﾞﾛｯｸ
    Private mXTANA_BLOCK_DTL As Nullable(Of Integer)                             '棚ﾌﾞﾛｯｸ詳細
    Private mXTANA_BLOCK_STS As Nullable(Of Integer)                             '棚ﾌﾞﾛｯｸ状態
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                  "
    ''' <summary>
    ''' ｼｽﾃﾑ変数 (自ｸﾗｽ型配列)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_TPRG_TRK_BUF()
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
    ''' ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
    ''' </summary>
    Public Property FTRK_BUF_ARRAY() As Nullable(Of Integer)
        Get
            Return mFTRK_BUF_ARRAY
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFTRK_BUF_ARRAY = Value
        End Set
    End Property
    ''' <summary>
    ''' 空検索順№
    ''' </summary>
    Public Property FSERCH_NO() As Nullable(Of Integer)
        Get
            Return mFSERCH_NO
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFSERCH_NO = Value
        End Set
    End Property
    ''' <summary>
    ''' 搬送指示用ｱﾄﾞﾚｽ
    ''' </summary>
    Public Property FTRNS_ADDRESS() As String
        Get
            Return mFTRNS_ADDRESS
        End Get
        Set(ByVal Value As String)
            mFTRNS_ADDRESS = Value
        End Set
    End Property
    ''' <summary>
    ''' 表記用ｱﾄﾞﾚｽ
    ''' </summary>
    Public Property FDISP_ADDRESS() As String
        Get
            Return mFDISP_ADDRESS
        End Get
        Set(ByVal Value As String)
            mFDISP_ADDRESS = Value
        End Set
    End Property
    ''' <summary>
    ''' 列
    ''' </summary>
    Public Property FRAC_RETU() As Nullable(Of Integer)
        Get
            Return mFRAC_RETU
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRAC_RETU = Value
        End Set
    End Property
    ''' <summary>
    ''' 連
    ''' </summary>
    Public Property FRAC_REN() As Nullable(Of Integer)
        Get
            Return mFRAC_REN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRAC_REN = Value
        End Set
    End Property
    ''' <summary>
    ''' 段
    ''' </summary>
    Public Property FRAC_DAN() As Nullable(Of Integer)
        Get
            Return mFRAC_DAN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRAC_DAN = Value
        End Set
    End Property
    ''' <summary>
    ''' 枝
    ''' </summary>
    Public Property FRAC_EDA() As Nullable(Of Integer)
        Get
            Return mFRAC_EDA
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRAC_EDA = Value
        End Set
    End Property
    ''' <summary>
    ''' 禁止有無
    ''' </summary>
    Public Property FREMOVE_KIND() As Nullable(Of Integer)
        Get
            Return mFREMOVE_KIND
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFREMOVE_KIND = Value
        End Set
    End Property
    ''' <summary>
    ''' 棚形状種別
    ''' </summary>
    Public Property FRAC_FORM() As Nullable(Of Integer)
        Get
            Return mFRAC_FORM
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRAC_FORM = Value
        End Set
    End Property
    ''' <summary>
    ''' 引当状態
    ''' </summary>
    Public Property FRES_KIND() As Nullable(Of Integer)
        Get
            Return mFRES_KIND
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRES_KIND = Value
        End Set
    End Property
    ''' <summary>
    ''' 仮引当ﾊﾟﾚｯﾄID
    ''' </summary>
    Public Property FRSV_PALLET() As String
        Get
            Return mFRSV_PALLET
        End Get
        Set(ByVal Value As String)
            mFRSV_PALLET = Value
        End Set
    End Property
    ''' <summary>
    ''' 搬送FMﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    ''' </summary>
    Public Property FTR_FM() As Nullable(Of Integer)
        Get
            Return mFTR_FM
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFTR_FM = Value
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
    ''' 搬送TO移動ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    ''' </summary>
    Public Property FTR_IDOU() As Nullable(Of Integer)
        Get
            Return mFTR_IDOU
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFTR_IDOU = Value
        End Set
    End Property
    ''' <summary>
    ''' 搬送指令用FM
    ''' </summary>
    Public Property FTRNS_FM() As String
        Get
            Return mFTRNS_FM
        End Get
        Set(ByVal Value As String)
            mFTRNS_FM = Value
        End Set
    End Property
    ''' <summary>
    ''' 搬送指令用TO
    ''' </summary>
    Public Property FTRNS_TO() As String
        Get
            Return mFTRNS_TO
        End Get
        Set(ByVal Value As String)
            mFTRNS_TO = Value
        End Set
    End Property
    ''' <summary>
    ''' FM引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    ''' </summary>
    Public Property FRSV_BUF_FM() As Nullable(Of Integer)
        Get
            Return mFRSV_BUF_FM
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRSV_BUF_FM = Value
        End Set
    End Property
    ''' <summary>
    ''' FM引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
    ''' </summary>
    Public Property FRSV_ARRAY_FM() As Nullable(Of Integer)
        Get
            Return mFRSV_ARRAY_FM
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRSV_ARRAY_FM = Value
        End Set
    End Property
    ''' <summary>
    ''' TO引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    ''' </summary>
    Public Property FRSV_BUF_TO() As Nullable(Of Integer)
        Get
            Return mFRSV_BUF_TO
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRSV_BUF_TO = Value
        End Set
    End Property
    ''' <summary>
    ''' TO引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
    ''' </summary>
    Public Property FRSV_ARRAY_TO() As Nullable(Of Integer)
        Get
            Return mFRSV_ARRAY_TO
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRSV_ARRAY_TO = Value
        End Set
    End Property
    ''' <summary>
    ''' FM表記用ｱﾄﾞﾚｽ
    ''' </summary>
    Public Property FDISP_ADDRESS_FM() As String
        Get
            Return mFDISP_ADDRESS_FM
        End Get
        Set(ByVal Value As String)
            mFDISP_ADDRESS_FM = Value
        End Set
    End Property
    ''' <summary>
    ''' TO表記用ｱﾄﾞﾚｽ
    ''' </summary>
    Public Property FDISP_ADDRESS_TO() As String
        Get
            Return mFDISP_ADDRESS_TO
        End Get
        Set(ByVal Value As String)
            mFDISP_ADDRESS_TO = Value
        End Set
    End Property
    ''' <summary>
    ''' FM表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用
    ''' </summary>
    Public Property FDISPLOG_ADDRESS_FM() As String
        Get
            Return mFDISPLOG_ADDRESS_FM
        End Get
        Set(ByVal Value As String)
            mFDISPLOG_ADDRESS_FM = Value
        End Set
    End Property
    ''' <summary>
    ''' TO表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用
    ''' </summary>
    Public Property FDISPLOG_ADDRESS_TO() As String
        Get
            Return mFDISPLOG_ADDRESS_TO
        End Get
        Set(ByVal Value As String)
            mFDISPLOG_ADDRESS_TO = Value
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
    ''' ﾊﾞｯﾌｧ入日時
    ''' </summary>
    Public Property FBUF_IN_DT() As Nullable(Of Date)
        Get
            Return mFBUF_IN_DT
        End Get
        Set(ByVal Value As Nullable(Of Date))
            mFBUF_IN_DT = Value
        End Set
    End Property
    ''' <summary>
    ''' 棚分類
    ''' </summary>
    Public Property FRAC_BUNRUI() As String
        Get
            Return mFRAC_BUNRUI
        End Get
        Set(ByVal Value As String)
            mFRAC_BUNRUI = Value
        End Set
    End Property
    ''' <summary>
    ''' 棚ﾌﾞﾛｯｸ
    ''' </summary>
    Public Property XTANA_BLOCK() As Nullable(Of Integer)
        Get
            Return mXTANA_BLOCK
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXTANA_BLOCK = Value
        End Set
    End Property
    ''' <summary>
    ''' 棚ﾌﾞﾛｯｸ詳細
    ''' </summary>
    Public Property XTANA_BLOCK_DTL() As Nullable(Of Integer)
        Get
            Return mXTANA_BLOCK_DTL
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXTANA_BLOCK_DTL = Value
        End Set
    End Property
    ''' <summary>
    ''' 棚ﾌﾞﾛｯｸ状態
    ''' </summary>
    Public Property XTANA_BLOCK_STS() As Nullable(Of Integer)
        Get
            Return mXTANA_BLOCK_STS
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXTANA_BLOCK_STS = Value
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
    Public Function GET_TPRG_TRK_BUF(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    TPRG_TRK_BUF")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FTRK_BUF_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNull(FTRK_BUF_ARRAY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_ARRAY
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_ARRAY = :" & UBound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
        End If
        If IsNull(FSERCH_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSERCH_NO
            strSQL.Append(vbCrLf & "    AND FSERCH_NO = :" & UBound(strBindField) - 1 & " --空検索順№")
        End If
        If IsNull(FTRNS_ADDRESS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_ADDRESS
            strSQL.Append(vbCrLf & "    AND FTRNS_ADDRESS = :" & UBound(strBindField) - 1 & " --搬送指示用ｱﾄﾞﾚｽ")
        End If
        If IsNull(FDISP_ADDRESS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS
            strSQL.Append(vbCrLf & "    AND FDISP_ADDRESS = :" & UBound(strBindField) - 1 & " --表記用ｱﾄﾞﾚｽ")
        End If
        If IsNull(FRAC_RETU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_RETU
            strSQL.Append(vbCrLf & "    AND FRAC_RETU = :" & UBound(strBindField) - 1 & " --列")
        End If
        If IsNull(FRAC_REN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_REN
            strSQL.Append(vbCrLf & "    AND FRAC_REN = :" & UBound(strBindField) - 1 & " --連")
        End If
        If IsNull(FRAC_DAN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_DAN
            strSQL.Append(vbCrLf & "    AND FRAC_DAN = :" & UBound(strBindField) - 1 & " --段")
        End If
        If IsNull(FRAC_EDA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_EDA
            strSQL.Append(vbCrLf & "    AND FRAC_EDA = :" & UBound(strBindField) - 1 & " --枝")
        End If
        If IsNull(FREMOVE_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFREMOVE_KIND
            strSQL.Append(vbCrLf & "    AND FREMOVE_KIND = :" & UBound(strBindField) - 1 & " --禁止有無")
        End If
        If IsNull(FRAC_FORM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_FORM
            strSQL.Append(vbCrLf & "    AND FRAC_FORM = :" & UBound(strBindField) - 1 & " --棚形状種別")
        End If
        If IsNull(FRES_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRES_KIND
            strSQL.Append(vbCrLf & "    AND FRES_KIND = :" & UBound(strBindField) - 1 & " --引当状態")
        End If
        If IsNull(FRSV_PALLET) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_PALLET
            strSQL.Append(vbCrLf & "    AND FRSV_PALLET = :" & UBound(strBindField) - 1 & " --仮引当ﾊﾟﾚｯﾄID")
        End If
        If IsNull(FTR_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_FM
            strSQL.Append(vbCrLf & "    AND FTR_FM = :" & UBound(strBindField) - 1 & " --搬送FMﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNull(FTR_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_TO
            strSQL.Append(vbCrLf & "    AND FTR_TO = :" & UBound(strBindField) - 1 & " --搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNull(FTR_IDOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_IDOU
            strSQL.Append(vbCrLf & "    AND FTR_IDOU = :" & UBound(strBindField) - 1 & " --搬送TO移動ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNull(FTRNS_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_FM
            strSQL.Append(vbCrLf & "    AND FTRNS_FM = :" & UBound(strBindField) - 1 & " --搬送指令用FM")
        End If
        If IsNull(FTRNS_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_TO
            strSQL.Append(vbCrLf & "    AND FTRNS_TO = :" & UBound(strBindField) - 1 & " --搬送指令用TO")
        End If
        If IsNull(FRSV_BUF_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_BUF_FM
            strSQL.Append(vbCrLf & "    AND FRSV_BUF_FM = :" & UBound(strBindField) - 1 & " --FM引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNull(FRSV_ARRAY_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_ARRAY_FM
            strSQL.Append(vbCrLf & "    AND FRSV_ARRAY_FM = :" & UBound(strBindField) - 1 & " --FM引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
        End If
        If IsNull(FRSV_BUF_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_BUF_TO
            strSQL.Append(vbCrLf & "    AND FRSV_BUF_TO = :" & UBound(strBindField) - 1 & " --TO引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNull(FRSV_ARRAY_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_ARRAY_TO
            strSQL.Append(vbCrLf & "    AND FRSV_ARRAY_TO = :" & UBound(strBindField) - 1 & " --TO引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
        End If
        If IsNull(FDISP_ADDRESS_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS_FM
            strSQL.Append(vbCrLf & "    AND FDISP_ADDRESS_FM = :" & UBound(strBindField) - 1 & " --FM表記用ｱﾄﾞﾚｽ")
        End If
        If IsNull(FDISP_ADDRESS_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS_TO
            strSQL.Append(vbCrLf & "    AND FDISP_ADDRESS_TO = :" & UBound(strBindField) - 1 & " --TO表記用ｱﾄﾞﾚｽ")
        End If
        If IsNull(FDISPLOG_ADDRESS_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISPLOG_ADDRESS_FM
            strSQL.Append(vbCrLf & "    AND FDISPLOG_ADDRESS_FM = :" & UBound(strBindField) - 1 & " --FM表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用")
        End If
        If IsNull(FDISPLOG_ADDRESS_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISPLOG_ADDRESS_TO
            strSQL.Append(vbCrLf & "    AND FDISPLOG_ADDRESS_TO = :" & UBound(strBindField) - 1 & " --TO表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用")
        End If
        If IsNull(FPALLET_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄID")
        End If
        If IsNull(FBUF_IN_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_IN_DT
            strSQL.Append(vbCrLf & "    AND FBUF_IN_DT = :" & UBound(strBindField) - 1 & " --ﾊﾞｯﾌｧ入日時")
        End If
        If IsNull(FRAC_BUNRUI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_BUNRUI
            strSQL.Append(vbCrLf & "    AND FRAC_BUNRUI = :" & UBound(strBindField) - 1 & " --棚分類")
        End If
        If IsNull(XTANA_BLOCK) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTANA_BLOCK
            strSQL.Append(vbCrLf & "    AND XTANA_BLOCK = :" & UBound(strBindField) - 1 & " --棚ﾌﾞﾛｯｸ")
        End If
        If IsNull(XTANA_BLOCK_DTL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTANA_BLOCK_DTL
            strSQL.Append(vbCrLf & "    AND XTANA_BLOCK_DTL = :" & UBound(strBindField) - 1 & " --棚ﾌﾞﾛｯｸ詳細")
        End If
        If IsNull(XTANA_BLOCK_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTANA_BLOCK_STS
            strSQL.Append(vbCrLf & "    AND XTANA_BLOCK_STS = :" & UBound(strBindField) - 1 & " --棚ﾌﾞﾛｯｸ状態")
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
        strDataSetName = "TPRG_TRK_BUF"
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
    Public Function GET_TPRG_TRK_BUF_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    TPRG_TRK_BUF")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FTRK_BUF_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNull(FTRK_BUF_ARRAY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_ARRAY
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_ARRAY = :" & UBound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
        End If
        If IsNull(FSERCH_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSERCH_NO
            strSQL.Append(vbCrLf & "    AND FSERCH_NO = :" & UBound(strBindField) - 1 & " --空検索順№")
        End If
        If IsNull(FTRNS_ADDRESS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_ADDRESS
            strSQL.Append(vbCrLf & "    AND FTRNS_ADDRESS = :" & UBound(strBindField) - 1 & " --搬送指示用ｱﾄﾞﾚｽ")
        End If
        If IsNull(FDISP_ADDRESS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS
            strSQL.Append(vbCrLf & "    AND FDISP_ADDRESS = :" & UBound(strBindField) - 1 & " --表記用ｱﾄﾞﾚｽ")
        End If
        If IsNull(FRAC_RETU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_RETU
            strSQL.Append(vbCrLf & "    AND FRAC_RETU = :" & UBound(strBindField) - 1 & " --列")
        End If
        If IsNull(FRAC_REN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_REN
            strSQL.Append(vbCrLf & "    AND FRAC_REN = :" & UBound(strBindField) - 1 & " --連")
        End If
        If IsNull(FRAC_DAN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_DAN
            strSQL.Append(vbCrLf & "    AND FRAC_DAN = :" & UBound(strBindField) - 1 & " --段")
        End If
        If IsNull(FRAC_EDA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_EDA
            strSQL.Append(vbCrLf & "    AND FRAC_EDA = :" & UBound(strBindField) - 1 & " --枝")
        End If
        If IsNull(FREMOVE_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFREMOVE_KIND
            strSQL.Append(vbCrLf & "    AND FREMOVE_KIND = :" & UBound(strBindField) - 1 & " --禁止有無")
        End If
        If IsNull(FRAC_FORM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_FORM
            strSQL.Append(vbCrLf & "    AND FRAC_FORM = :" & UBound(strBindField) - 1 & " --棚形状種別")
        End If
        If IsNull(FRES_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRES_KIND
            strSQL.Append(vbCrLf & "    AND FRES_KIND = :" & UBound(strBindField) - 1 & " --引当状態")
        End If
        If IsNull(FRSV_PALLET) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_PALLET
            strSQL.Append(vbCrLf & "    AND FRSV_PALLET = :" & UBound(strBindField) - 1 & " --仮引当ﾊﾟﾚｯﾄID")
        End If
        If IsNull(FTR_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_FM
            strSQL.Append(vbCrLf & "    AND FTR_FM = :" & UBound(strBindField) - 1 & " --搬送FMﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNull(FTR_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_TO
            strSQL.Append(vbCrLf & "    AND FTR_TO = :" & UBound(strBindField) - 1 & " --搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNull(FTR_IDOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_IDOU
            strSQL.Append(vbCrLf & "    AND FTR_IDOU = :" & UBound(strBindField) - 1 & " --搬送TO移動ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNull(FTRNS_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_FM
            strSQL.Append(vbCrLf & "    AND FTRNS_FM = :" & UBound(strBindField) - 1 & " --搬送指令用FM")
        End If
        If IsNull(FTRNS_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_TO
            strSQL.Append(vbCrLf & "    AND FTRNS_TO = :" & UBound(strBindField) - 1 & " --搬送指令用TO")
        End If
        If IsNull(FRSV_BUF_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_BUF_FM
            strSQL.Append(vbCrLf & "    AND FRSV_BUF_FM = :" & UBound(strBindField) - 1 & " --FM引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNull(FRSV_ARRAY_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_ARRAY_FM
            strSQL.Append(vbCrLf & "    AND FRSV_ARRAY_FM = :" & UBound(strBindField) - 1 & " --FM引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
        End If
        If IsNull(FRSV_BUF_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_BUF_TO
            strSQL.Append(vbCrLf & "    AND FRSV_BUF_TO = :" & UBound(strBindField) - 1 & " --TO引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNull(FRSV_ARRAY_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_ARRAY_TO
            strSQL.Append(vbCrLf & "    AND FRSV_ARRAY_TO = :" & UBound(strBindField) - 1 & " --TO引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
        End If
        If IsNull(FDISP_ADDRESS_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS_FM
            strSQL.Append(vbCrLf & "    AND FDISP_ADDRESS_FM = :" & UBound(strBindField) - 1 & " --FM表記用ｱﾄﾞﾚｽ")
        End If
        If IsNull(FDISP_ADDRESS_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS_TO
            strSQL.Append(vbCrLf & "    AND FDISP_ADDRESS_TO = :" & UBound(strBindField) - 1 & " --TO表記用ｱﾄﾞﾚｽ")
        End If
        If IsNull(FDISPLOG_ADDRESS_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISPLOG_ADDRESS_FM
            strSQL.Append(vbCrLf & "    AND FDISPLOG_ADDRESS_FM = :" & UBound(strBindField) - 1 & " --FM表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用")
        End If
        If IsNull(FDISPLOG_ADDRESS_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISPLOG_ADDRESS_TO
            strSQL.Append(vbCrLf & "    AND FDISPLOG_ADDRESS_TO = :" & UBound(strBindField) - 1 & " --TO表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用")
        End If
        If IsNull(FPALLET_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄID")
        End If
        If IsNull(FBUF_IN_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_IN_DT
            strSQL.Append(vbCrLf & "    AND FBUF_IN_DT = :" & UBound(strBindField) - 1 & " --ﾊﾞｯﾌｧ入日時")
        End If
        If IsNull(FRAC_BUNRUI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_BUNRUI
            strSQL.Append(vbCrLf & "    AND FRAC_BUNRUI = :" & UBound(strBindField) - 1 & " --棚分類")
        End If
        If IsNull(XTANA_BLOCK) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTANA_BLOCK
            strSQL.Append(vbCrLf & "    AND XTANA_BLOCK = :" & UBound(strBindField) - 1 & " --棚ﾌﾞﾛｯｸ")
        End If
        If IsNull(XTANA_BLOCK_DTL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTANA_BLOCK_DTL
            strSQL.Append(vbCrLf & "    AND XTANA_BLOCK_DTL = :" & UBound(strBindField) - 1 & " --棚ﾌﾞﾛｯｸ詳細")
        End If
        If IsNull(XTANA_BLOCK_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTANA_BLOCK_STS
            strSQL.Append(vbCrLf & "    AND XTANA_BLOCK_STS = :" & UBound(strBindField) - 1 & " --棚ﾌﾞﾛｯｸ状態")
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
        strDataSetName = "TPRG_TRK_BUF"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TPRG_TRK_BUF(Owner, objDb, objDbLog)
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
    Public Function GET_TPRG_TRK_BUF_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "TPRG_TRK_BUF"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TPRG_TRK_BUF(Owner, objDb, objDbLog)
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
    Public Function GET_TPRG_TRK_BUF_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    TPRG_TRK_BUF")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FTRK_BUF_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNull(FTRK_BUF_ARRAY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_ARRAY
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_ARRAY = :" & UBound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
        End If
        If IsNull(FSERCH_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSERCH_NO
            strSQL.Append(vbCrLf & "    AND FSERCH_NO = :" & UBound(strBindField) - 1 & " --空検索順№")
        End If
        If IsNull(FTRNS_ADDRESS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_ADDRESS
            strSQL.Append(vbCrLf & "    AND FTRNS_ADDRESS = :" & UBound(strBindField) - 1 & " --搬送指示用ｱﾄﾞﾚｽ")
        End If
        If IsNull(FDISP_ADDRESS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS
            strSQL.Append(vbCrLf & "    AND FDISP_ADDRESS = :" & UBound(strBindField) - 1 & " --表記用ｱﾄﾞﾚｽ")
        End If
        If IsNull(FRAC_RETU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_RETU
            strSQL.Append(vbCrLf & "    AND FRAC_RETU = :" & UBound(strBindField) - 1 & " --列")
        End If
        If IsNull(FRAC_REN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_REN
            strSQL.Append(vbCrLf & "    AND FRAC_REN = :" & UBound(strBindField) - 1 & " --連")
        End If
        If IsNull(FRAC_DAN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_DAN
            strSQL.Append(vbCrLf & "    AND FRAC_DAN = :" & UBound(strBindField) - 1 & " --段")
        End If
        If IsNull(FRAC_EDA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_EDA
            strSQL.Append(vbCrLf & "    AND FRAC_EDA = :" & UBound(strBindField) - 1 & " --枝")
        End If
        If IsNull(FREMOVE_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFREMOVE_KIND
            strSQL.Append(vbCrLf & "    AND FREMOVE_KIND = :" & UBound(strBindField) - 1 & " --禁止有無")
        End If
        If IsNull(FRAC_FORM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_FORM
            strSQL.Append(vbCrLf & "    AND FRAC_FORM = :" & UBound(strBindField) - 1 & " --棚形状種別")
        End If
        If IsNull(FRES_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRES_KIND
            strSQL.Append(vbCrLf & "    AND FRES_KIND = :" & UBound(strBindField) - 1 & " --引当状態")
        End If
        If IsNull(FRSV_PALLET) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_PALLET
            strSQL.Append(vbCrLf & "    AND FRSV_PALLET = :" & UBound(strBindField) - 1 & " --仮引当ﾊﾟﾚｯﾄID")
        End If
        If IsNull(FTR_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_FM
            strSQL.Append(vbCrLf & "    AND FTR_FM = :" & UBound(strBindField) - 1 & " --搬送FMﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNull(FTR_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_TO
            strSQL.Append(vbCrLf & "    AND FTR_TO = :" & UBound(strBindField) - 1 & " --搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNull(FTR_IDOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_IDOU
            strSQL.Append(vbCrLf & "    AND FTR_IDOU = :" & UBound(strBindField) - 1 & " --搬送TO移動ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNull(FTRNS_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_FM
            strSQL.Append(vbCrLf & "    AND FTRNS_FM = :" & UBound(strBindField) - 1 & " --搬送指令用FM")
        End If
        If IsNull(FTRNS_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_TO
            strSQL.Append(vbCrLf & "    AND FTRNS_TO = :" & UBound(strBindField) - 1 & " --搬送指令用TO")
        End If
        If IsNull(FRSV_BUF_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_BUF_FM
            strSQL.Append(vbCrLf & "    AND FRSV_BUF_FM = :" & UBound(strBindField) - 1 & " --FM引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNull(FRSV_ARRAY_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_ARRAY_FM
            strSQL.Append(vbCrLf & "    AND FRSV_ARRAY_FM = :" & UBound(strBindField) - 1 & " --FM引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
        End If
        If IsNull(FRSV_BUF_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_BUF_TO
            strSQL.Append(vbCrLf & "    AND FRSV_BUF_TO = :" & UBound(strBindField) - 1 & " --TO引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNull(FRSV_ARRAY_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_ARRAY_TO
            strSQL.Append(vbCrLf & "    AND FRSV_ARRAY_TO = :" & UBound(strBindField) - 1 & " --TO引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
        End If
        If IsNull(FDISP_ADDRESS_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS_FM
            strSQL.Append(vbCrLf & "    AND FDISP_ADDRESS_FM = :" & UBound(strBindField) - 1 & " --FM表記用ｱﾄﾞﾚｽ")
        End If
        If IsNull(FDISP_ADDRESS_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS_TO
            strSQL.Append(vbCrLf & "    AND FDISP_ADDRESS_TO = :" & UBound(strBindField) - 1 & " --TO表記用ｱﾄﾞﾚｽ")
        End If
        If IsNull(FDISPLOG_ADDRESS_FM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISPLOG_ADDRESS_FM
            strSQL.Append(vbCrLf & "    AND FDISPLOG_ADDRESS_FM = :" & UBound(strBindField) - 1 & " --FM表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用")
        End If
        If IsNull(FDISPLOG_ADDRESS_TO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISPLOG_ADDRESS_TO
            strSQL.Append(vbCrLf & "    AND FDISPLOG_ADDRESS_TO = :" & UBound(strBindField) - 1 & " --TO表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用")
        End If
        If IsNull(FPALLET_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄID")
        End If
        If IsNull(FBUF_IN_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_IN_DT
            strSQL.Append(vbCrLf & "    AND FBUF_IN_DT = :" & UBound(strBindField) - 1 & " --ﾊﾞｯﾌｧ入日時")
        End If
        If IsNull(FRAC_BUNRUI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_BUNRUI
            strSQL.Append(vbCrLf & "    AND FRAC_BUNRUI = :" & UBound(strBindField) - 1 & " --棚分類")
        End If
        If IsNull(XTANA_BLOCK) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTANA_BLOCK
            strSQL.Append(vbCrLf & "    AND XTANA_BLOCK = :" & UBound(strBindField) - 1 & " --棚ﾌﾞﾛｯｸ")
        End If
        If IsNull(XTANA_BLOCK_DTL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTANA_BLOCK_DTL
            strSQL.Append(vbCrLf & "    AND XTANA_BLOCK_DTL = :" & UBound(strBindField) - 1 & " --棚ﾌﾞﾛｯｸ詳細")
        End If
        If IsNull(XTANA_BLOCK_STS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTANA_BLOCK_STS
            strSQL.Append(vbCrLf & "    AND XTANA_BLOCK_STS = :" & UBound(strBindField) - 1 & " --棚ﾌﾞﾛｯｸ状態")
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
        strDataSetName = "TPRG_TRK_BUF"
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
    Public Sub UPDATE_TPRG_TRK_BUF()
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
        ElseIf IsNull(mFTRK_BUF_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFTRK_BUF_ARRAY) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№]"
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
        strSQL.Append(vbCrLf & "    TPRG_TRK_BUF")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
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
        If IsNull(mFTRK_BUF_ARRAY) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTRK_BUF_ARRAY = NULL --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTRK_BUF_ARRAY = NULL --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_ARRAY
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTRK_BUF_ARRAY = :" & Ubound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTRK_BUF_ARRAY = :" & Ubound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
        End If
        intCount = intCount + 1
        If IsNull(mFSERCH_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSERCH_NO = NULL --空検索順№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSERCH_NO = NULL --空検索順№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSERCH_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSERCH_NO = :" & Ubound(strBindField) - 1 & " --空検索順№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSERCH_NO = :" & Ubound(strBindField) - 1 & " --空検索順№")
        End If
        intCount = intCount + 1
        If IsNull(mFTRNS_ADDRESS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTRNS_ADDRESS = NULL --搬送指示用ｱﾄﾞﾚｽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTRNS_ADDRESS = NULL --搬送指示用ｱﾄﾞﾚｽ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_ADDRESS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTRNS_ADDRESS = :" & Ubound(strBindField) - 1 & " --搬送指示用ｱﾄﾞﾚｽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTRNS_ADDRESS = :" & Ubound(strBindField) - 1 & " --搬送指示用ｱﾄﾞﾚｽ")
        End If
        intCount = intCount + 1
        If IsNull(mFDISP_ADDRESS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDISP_ADDRESS = NULL --表記用ｱﾄﾞﾚｽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDISP_ADDRESS = NULL --表記用ｱﾄﾞﾚｽ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDISP_ADDRESS = :" & Ubound(strBindField) - 1 & " --表記用ｱﾄﾞﾚｽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDISP_ADDRESS = :" & Ubound(strBindField) - 1 & " --表記用ｱﾄﾞﾚｽ")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_RETU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_RETU = NULL --列")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_RETU = NULL --列")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_RETU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_RETU = :" & Ubound(strBindField) - 1 & " --列")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_RETU = :" & Ubound(strBindField) - 1 & " --列")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_REN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_REN = NULL --連")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_REN = NULL --連")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_REN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_REN = :" & Ubound(strBindField) - 1 & " --連")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_REN = :" & Ubound(strBindField) - 1 & " --連")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_DAN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_DAN = NULL --段")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_DAN = NULL --段")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_DAN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_DAN = :" & Ubound(strBindField) - 1 & " --段")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_DAN = :" & Ubound(strBindField) - 1 & " --段")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_EDA) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_EDA = NULL --枝")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_EDA = NULL --枝")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_EDA
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_EDA = :" & Ubound(strBindField) - 1 & " --枝")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_EDA = :" & Ubound(strBindField) - 1 & " --枝")
        End If
        intCount = intCount + 1
        If IsNull(mFREMOVE_KIND) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FREMOVE_KIND = NULL --禁止有無")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FREMOVE_KIND = NULL --禁止有無")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFREMOVE_KIND
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FREMOVE_KIND = :" & Ubound(strBindField) - 1 & " --禁止有無")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FREMOVE_KIND = :" & Ubound(strBindField) - 1 & " --禁止有無")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_FORM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_FORM = NULL --棚形状種別")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_FORM = NULL --棚形状種別")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_FORM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_FORM = :" & Ubound(strBindField) - 1 & " --棚形状種別")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_FORM = :" & Ubound(strBindField) - 1 & " --棚形状種別")
        End If
        intCount = intCount + 1
        If IsNull(mFRES_KIND) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRES_KIND = NULL --引当状態")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRES_KIND = NULL --引当状態")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRES_KIND
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRES_KIND = :" & Ubound(strBindField) - 1 & " --引当状態")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRES_KIND = :" & Ubound(strBindField) - 1 & " --引当状態")
        End If
        intCount = intCount + 1
        If IsNull(mFRSV_PALLET) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRSV_PALLET = NULL --仮引当ﾊﾟﾚｯﾄID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRSV_PALLET = NULL --仮引当ﾊﾟﾚｯﾄID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_PALLET
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRSV_PALLET = :" & Ubound(strBindField) - 1 & " --仮引当ﾊﾟﾚｯﾄID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRSV_PALLET = :" & Ubound(strBindField) - 1 & " --仮引当ﾊﾟﾚｯﾄID")
        End If
        intCount = intCount + 1
        If IsNull(mFTR_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTR_FM = NULL --搬送FMﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTR_FM = NULL --搬送FMﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTR_FM = :" & Ubound(strBindField) - 1 & " --搬送FMﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTR_FM = :" & Ubound(strBindField) - 1 & " --搬送FMﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
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
        If IsNull(mFTR_IDOU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTR_IDOU = NULL --搬送TO移動ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTR_IDOU = NULL --搬送TO移動ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_IDOU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTR_IDOU = :" & Ubound(strBindField) - 1 & " --搬送TO移動ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTR_IDOU = :" & Ubound(strBindField) - 1 & " --搬送TO移動ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        intCount = intCount + 1
        If IsNull(mFTRNS_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTRNS_FM = NULL --搬送指令用FM")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTRNS_FM = NULL --搬送指令用FM")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTRNS_FM = :" & Ubound(strBindField) - 1 & " --搬送指令用FM")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTRNS_FM = :" & Ubound(strBindField) - 1 & " --搬送指令用FM")
        End If
        intCount = intCount + 1
        If IsNull(mFTRNS_TO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTRNS_TO = NULL --搬送指令用TO")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTRNS_TO = NULL --搬送指令用TO")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_TO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FTRNS_TO = :" & Ubound(strBindField) - 1 & " --搬送指令用TO")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FTRNS_TO = :" & Ubound(strBindField) - 1 & " --搬送指令用TO")
        End If
        intCount = intCount + 1
        If IsNull(mFRSV_BUF_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRSV_BUF_FM = NULL --FM引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRSV_BUF_FM = NULL --FM引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_BUF_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRSV_BUF_FM = :" & Ubound(strBindField) - 1 & " --FM引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRSV_BUF_FM = :" & Ubound(strBindField) - 1 & " --FM引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        intCount = intCount + 1
        If IsNull(mFRSV_ARRAY_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRSV_ARRAY_FM = NULL --FM引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRSV_ARRAY_FM = NULL --FM引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_ARRAY_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRSV_ARRAY_FM = :" & Ubound(strBindField) - 1 & " --FM引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRSV_ARRAY_FM = :" & Ubound(strBindField) - 1 & " --FM引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
        End If
        intCount = intCount + 1
        If IsNull(mFRSV_BUF_TO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRSV_BUF_TO = NULL --TO引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRSV_BUF_TO = NULL --TO引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_BUF_TO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRSV_BUF_TO = :" & Ubound(strBindField) - 1 & " --TO引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRSV_BUF_TO = :" & Ubound(strBindField) - 1 & " --TO引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        intCount = intCount + 1
        If IsNull(mFRSV_ARRAY_TO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRSV_ARRAY_TO = NULL --TO引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRSV_ARRAY_TO = NULL --TO引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_ARRAY_TO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRSV_ARRAY_TO = :" & Ubound(strBindField) - 1 & " --TO引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRSV_ARRAY_TO = :" & Ubound(strBindField) - 1 & " --TO引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
        End If
        intCount = intCount + 1
        If IsNull(mFDISP_ADDRESS_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDISP_ADDRESS_FM = NULL --FM表記用ｱﾄﾞﾚｽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDISP_ADDRESS_FM = NULL --FM表記用ｱﾄﾞﾚｽ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDISP_ADDRESS_FM = :" & Ubound(strBindField) - 1 & " --FM表記用ｱﾄﾞﾚｽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDISP_ADDRESS_FM = :" & Ubound(strBindField) - 1 & " --FM表記用ｱﾄﾞﾚｽ")
        End If
        intCount = intCount + 1
        If IsNull(mFDISP_ADDRESS_TO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDISP_ADDRESS_TO = NULL --TO表記用ｱﾄﾞﾚｽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDISP_ADDRESS_TO = NULL --TO表記用ｱﾄﾞﾚｽ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS_TO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDISP_ADDRESS_TO = :" & Ubound(strBindField) - 1 & " --TO表記用ｱﾄﾞﾚｽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDISP_ADDRESS_TO = :" & Ubound(strBindField) - 1 & " --TO表記用ｱﾄﾞﾚｽ")
        End If
        intCount = intCount + 1
        If IsNull(mFDISPLOG_ADDRESS_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDISPLOG_ADDRESS_FM = NULL --FM表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDISPLOG_ADDRESS_FM = NULL --FM表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISPLOG_ADDRESS_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDISPLOG_ADDRESS_FM = :" & Ubound(strBindField) - 1 & " --FM表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDISPLOG_ADDRESS_FM = :" & Ubound(strBindField) - 1 & " --FM表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用")
        End If
        intCount = intCount + 1
        If IsNull(mFDISPLOG_ADDRESS_TO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDISPLOG_ADDRESS_TO = NULL --TO表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDISPLOG_ADDRESS_TO = NULL --TO表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISPLOG_ADDRESS_TO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FDISPLOG_ADDRESS_TO = :" & Ubound(strBindField) - 1 & " --TO表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FDISPLOG_ADDRESS_TO = :" & Ubound(strBindField) - 1 & " --TO表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用")
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
        If IsNull(mFBUF_IN_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FBUF_IN_DT = NULL --ﾊﾞｯﾌｧ入日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FBUF_IN_DT = NULL --ﾊﾞｯﾌｧ入日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_IN_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FBUF_IN_DT = :" & Ubound(strBindField) - 1 & " --ﾊﾞｯﾌｧ入日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FBUF_IN_DT = :" & Ubound(strBindField) - 1 & " --ﾊﾞｯﾌｧ入日時")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_BUNRUI) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_BUNRUI = NULL --棚分類")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_BUNRUI = NULL --棚分類")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_BUNRUI
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_BUNRUI = :" & Ubound(strBindField) - 1 & " --棚分類")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_BUNRUI = :" & Ubound(strBindField) - 1 & " --棚分類")
        End If
        intCount = intCount + 1
        If IsNull(mXTANA_BLOCK) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTANA_BLOCK = NULL --棚ﾌﾞﾛｯｸ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTANA_BLOCK = NULL --棚ﾌﾞﾛｯｸ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTANA_BLOCK
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTANA_BLOCK = :" & Ubound(strBindField) - 1 & " --棚ﾌﾞﾛｯｸ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTANA_BLOCK = :" & Ubound(strBindField) - 1 & " --棚ﾌﾞﾛｯｸ")
        End If
        intCount = intCount + 1
        If IsNull(mXTANA_BLOCK_DTL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTANA_BLOCK_DTL = NULL --棚ﾌﾞﾛｯｸ詳細")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTANA_BLOCK_DTL = NULL --棚ﾌﾞﾛｯｸ詳細")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTANA_BLOCK_DTL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTANA_BLOCK_DTL = :" & Ubound(strBindField) - 1 & " --棚ﾌﾞﾛｯｸ詳細")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTANA_BLOCK_DTL = :" & Ubound(strBindField) - 1 & " --棚ﾌﾞﾛｯｸ詳細")
        End If
        intCount = intCount + 1
        If IsNull(mXTANA_BLOCK_STS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTANA_BLOCK_STS = NULL --棚ﾌﾞﾛｯｸ状態")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTANA_BLOCK_STS = NULL --棚ﾌﾞﾛｯｸ状態")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTANA_BLOCK_STS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTANA_BLOCK_STS = :" & Ubound(strBindField) - 1 & " --棚ﾌﾞﾛｯｸ状態")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTANA_BLOCK_STS = :" & Ubound(strBindField) - 1 & " --棚ﾌﾞﾛｯｸ状態")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FTRK_BUF_NO) = True Then
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO IS NULL --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNull(FTRK_BUF_ARRAY) = True Then
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_ARRAY IS NULL --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_ARRAY
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_ARRAY = :" & UBound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
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
    Public Sub ADD_TPRG_TRK_BUF()
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
        ElseIf IsNull(mFTRK_BUF_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFTRK_BUF_ARRAY) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№]"
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
        strSQL.Append(vbCrLf & "    TPRG_TRK_BUF")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
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
        If IsNull(mFTRK_BUF_ARRAY) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_ARRAY
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
        End If
        intCount = intCount + 1
        If IsNull(mFSERCH_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --空検索順№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --空検索順№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSERCH_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --空検索順№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --空検索順№")
        End If
        intCount = intCount + 1
        If IsNull(mFTRNS_ADDRESS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --搬送指示用ｱﾄﾞﾚｽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --搬送指示用ｱﾄﾞﾚｽ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_ADDRESS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --搬送指示用ｱﾄﾞﾚｽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --搬送指示用ｱﾄﾞﾚｽ")
        End If
        intCount = intCount + 1
        If IsNull(mFDISP_ADDRESS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --表記用ｱﾄﾞﾚｽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --表記用ｱﾄﾞﾚｽ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --表記用ｱﾄﾞﾚｽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --表記用ｱﾄﾞﾚｽ")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_RETU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --列")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --列")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_RETU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --列")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --列")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_REN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --連")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --連")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_REN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --連")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --連")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_DAN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --段")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --段")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_DAN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --段")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --段")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_EDA) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --枝")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --枝")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_EDA
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --枝")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --枝")
        End If
        intCount = intCount + 1
        If IsNull(mFREMOVE_KIND) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --禁止有無")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --禁止有無")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFREMOVE_KIND
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --禁止有無")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --禁止有無")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_FORM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --棚形状種別")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --棚形状種別")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_FORM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --棚形状種別")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --棚形状種別")
        End If
        intCount = intCount + 1
        If IsNull(mFRES_KIND) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --引当状態")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --引当状態")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRES_KIND
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --引当状態")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --引当状態")
        End If
        intCount = intCount + 1
        If IsNull(mFRSV_PALLET) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --仮引当ﾊﾟﾚｯﾄID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --仮引当ﾊﾟﾚｯﾄID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_PALLET
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --仮引当ﾊﾟﾚｯﾄID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --仮引当ﾊﾟﾚｯﾄID")
        End If
        intCount = intCount + 1
        If IsNull(mFTR_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --搬送FMﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --搬送FMﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --搬送FMﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --搬送FMﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
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
        If IsNull(mFTR_IDOU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --搬送TO移動ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --搬送TO移動ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_IDOU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --搬送TO移動ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --搬送TO移動ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        intCount = intCount + 1
        If IsNull(mFTRNS_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --搬送指令用FM")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --搬送指令用FM")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --搬送指令用FM")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --搬送指令用FM")
        End If
        intCount = intCount + 1
        If IsNull(mFTRNS_TO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --搬送指令用TO")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --搬送指令用TO")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_TO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --搬送指令用TO")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --搬送指令用TO")
        End If
        intCount = intCount + 1
        If IsNull(mFRSV_BUF_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --FM引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --FM引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_BUF_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --FM引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --FM引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        intCount = intCount + 1
        If IsNull(mFRSV_ARRAY_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --FM引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --FM引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_ARRAY_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --FM引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --FM引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
        End If
        intCount = intCount + 1
        If IsNull(mFRSV_BUF_TO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --TO引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --TO引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_BUF_TO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --TO引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --TO引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        intCount = intCount + 1
        If IsNull(mFRSV_ARRAY_TO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --TO引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --TO引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_ARRAY_TO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --TO引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --TO引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
        End If
        intCount = intCount + 1
        If IsNull(mFDISP_ADDRESS_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --FM表記用ｱﾄﾞﾚｽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --FM表記用ｱﾄﾞﾚｽ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --FM表記用ｱﾄﾞﾚｽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --FM表記用ｱﾄﾞﾚｽ")
        End If
        intCount = intCount + 1
        If IsNull(mFDISP_ADDRESS_TO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --TO表記用ｱﾄﾞﾚｽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --TO表記用ｱﾄﾞﾚｽ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS_TO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --TO表記用ｱﾄﾞﾚｽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --TO表記用ｱﾄﾞﾚｽ")
        End If
        intCount = intCount + 1
        If IsNull(mFDISPLOG_ADDRESS_FM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --FM表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --FM表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISPLOG_ADDRESS_FM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --FM表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --FM表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用")
        End If
        intCount = intCount + 1
        If IsNull(mFDISPLOG_ADDRESS_TO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --TO表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --TO表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISPLOG_ADDRESS_TO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --TO表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --TO表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用")
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
        If IsNull(mFBUF_IN_DT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾊﾞｯﾌｧ入日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾊﾞｯﾌｧ入日時")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_IN_DT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾊﾞｯﾌｧ入日時")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾊﾞｯﾌｧ入日時")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_BUNRUI) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --棚分類")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --棚分類")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_BUNRUI
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --棚分類")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --棚分類")
        End If
        intCount = intCount + 1
        If IsNull(mXTANA_BLOCK) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --棚ﾌﾞﾛｯｸ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --棚ﾌﾞﾛｯｸ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTANA_BLOCK
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --棚ﾌﾞﾛｯｸ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --棚ﾌﾞﾛｯｸ")
        End If
        intCount = intCount + 1
        If IsNull(mXTANA_BLOCK_DTL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --棚ﾌﾞﾛｯｸ詳細")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --棚ﾌﾞﾛｯｸ詳細")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTANA_BLOCK_DTL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --棚ﾌﾞﾛｯｸ詳細")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --棚ﾌﾞﾛｯｸ詳細")
        End If
        intCount = intCount + 1
        If IsNull(mXTANA_BLOCK_STS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --棚ﾌﾞﾛｯｸ状態")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --棚ﾌﾞﾛｯｸ状態")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTANA_BLOCK_STS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --棚ﾌﾞﾛｯｸ状態")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --棚ﾌﾞﾛｯｸ状態")
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
    Public Sub DELETE_TPRG_TRK_BUF()
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
        ElseIf IsNull(mFTRK_BUF_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFTRK_BUF_ARRAY) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№]"
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
        strSQL.Append(vbCrLf & "    TPRG_TRK_BUF")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FTRK_BUF_NO) = True Then
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO IS NULL --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNull(FTRK_BUF_ARRAY) = True Then
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_ARRAY IS NULL --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_ARRAY
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_ARRAY = :" & UBound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
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
    Public Sub DELETE_TPRG_TRK_BUF_ANY()
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
        strSQL.Append(vbCrLf & "    TPRG_TRK_BUF")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(FTRK_BUF_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNotNull(FTRK_BUF_ARRAY) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_ARRAY
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_ARRAY = :" & UBound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
        End If
        If IsNotNull(FSERCH_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSERCH_NO
            strSQL.Append(vbCrLf & "    AND FSERCH_NO = :" & UBound(strBindField) - 1 & " --空検索順№")
        End If
        If IsNotNull(FTRNS_ADDRESS) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_ADDRESS
            strSQL.Append(vbCrLf & "    AND FTRNS_ADDRESS = :" & UBound(strBindField) - 1 & " --搬送指示用ｱﾄﾞﾚｽ")
        End If
        If IsNotNull(FDISP_ADDRESS) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS
            strSQL.Append(vbCrLf & "    AND FDISP_ADDRESS = :" & UBound(strBindField) - 1 & " --表記用ｱﾄﾞﾚｽ")
        End If
        If IsNotNull(FRAC_RETU) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_RETU
            strSQL.Append(vbCrLf & "    AND FRAC_RETU = :" & UBound(strBindField) - 1 & " --列")
        End If
        If IsNotNull(FRAC_REN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_REN
            strSQL.Append(vbCrLf & "    AND FRAC_REN = :" & UBound(strBindField) - 1 & " --連")
        End If
        If IsNotNull(FRAC_DAN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_DAN
            strSQL.Append(vbCrLf & "    AND FRAC_DAN = :" & UBound(strBindField) - 1 & " --段")
        End If
        If IsNotNull(FRAC_EDA) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_EDA
            strSQL.Append(vbCrLf & "    AND FRAC_EDA = :" & UBound(strBindField) - 1 & " --枝")
        End If
        If IsNotNull(FREMOVE_KIND) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFREMOVE_KIND
            strSQL.Append(vbCrLf & "    AND FREMOVE_KIND = :" & UBound(strBindField) - 1 & " --禁止有無")
        End If
        If IsNotNull(FRAC_FORM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_FORM
            strSQL.Append(vbCrLf & "    AND FRAC_FORM = :" & UBound(strBindField) - 1 & " --棚形状種別")
        End If
        If IsNotNull(FRES_KIND) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRES_KIND
            strSQL.Append(vbCrLf & "    AND FRES_KIND = :" & UBound(strBindField) - 1 & " --引当状態")
        End If
        If IsNotNull(FRSV_PALLET) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_PALLET
            strSQL.Append(vbCrLf & "    AND FRSV_PALLET = :" & UBound(strBindField) - 1 & " --仮引当ﾊﾟﾚｯﾄID")
        End If
        If IsNotNull(FTR_FM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_FM
            strSQL.Append(vbCrLf & "    AND FTR_FM = :" & UBound(strBindField) - 1 & " --搬送FMﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNotNull(FTR_TO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_TO
            strSQL.Append(vbCrLf & "    AND FTR_TO = :" & UBound(strBindField) - 1 & " --搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNotNull(FTR_IDOU) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_IDOU
            strSQL.Append(vbCrLf & "    AND FTR_IDOU = :" & UBound(strBindField) - 1 & " --搬送TO移動ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNotNull(FTRNS_FM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_FM
            strSQL.Append(vbCrLf & "    AND FTRNS_FM = :" & UBound(strBindField) - 1 & " --搬送指令用FM")
        End If
        If IsNotNull(FTRNS_TO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRNS_TO
            strSQL.Append(vbCrLf & "    AND FTRNS_TO = :" & UBound(strBindField) - 1 & " --搬送指令用TO")
        End If
        If IsNotNull(FRSV_BUF_FM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_BUF_FM
            strSQL.Append(vbCrLf & "    AND FRSV_BUF_FM = :" & UBound(strBindField) - 1 & " --FM引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNotNull(FRSV_ARRAY_FM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_ARRAY_FM
            strSQL.Append(vbCrLf & "    AND FRSV_ARRAY_FM = :" & UBound(strBindField) - 1 & " --FM引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
        End If
        If IsNotNull(FRSV_BUF_TO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_BUF_TO
            strSQL.Append(vbCrLf & "    AND FRSV_BUF_TO = :" & UBound(strBindField) - 1 & " --TO引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNotNull(FRSV_ARRAY_TO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRSV_ARRAY_TO
            strSQL.Append(vbCrLf & "    AND FRSV_ARRAY_TO = :" & UBound(strBindField) - 1 & " --TO引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№")
        End If
        If IsNotNull(FDISP_ADDRESS_FM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS_FM
            strSQL.Append(vbCrLf & "    AND FDISP_ADDRESS_FM = :" & UBound(strBindField) - 1 & " --FM表記用ｱﾄﾞﾚｽ")
        End If
        If IsNotNull(FDISP_ADDRESS_TO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS_TO
            strSQL.Append(vbCrLf & "    AND FDISP_ADDRESS_TO = :" & UBound(strBindField) - 1 & " --TO表記用ｱﾄﾞﾚｽ")
        End If
        If IsNotNull(FDISPLOG_ADDRESS_FM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISPLOG_ADDRESS_FM
            strSQL.Append(vbCrLf & "    AND FDISPLOG_ADDRESS_FM = :" & UBound(strBindField) - 1 & " --FM表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用")
        End If
        If IsNotNull(FDISPLOG_ADDRESS_TO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISPLOG_ADDRESS_TO
            strSQL.Append(vbCrLf & "    AND FDISPLOG_ADDRESS_TO = :" & UBound(strBindField) - 1 & " --TO表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用")
        End If
        If IsNotNull(FPALLET_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFPALLET_ID
            strSQL.Append(vbCrLf & "    AND FPALLET_ID = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄID")
        End If
        If IsNotNull(FBUF_IN_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_IN_DT
            strSQL.Append(vbCrLf & "    AND FBUF_IN_DT = :" & UBound(strBindField) - 1 & " --ﾊﾞｯﾌｧ入日時")
        End If
        If IsNotNull(FRAC_BUNRUI) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_BUNRUI
            strSQL.Append(vbCrLf & "    AND FRAC_BUNRUI = :" & UBound(strBindField) - 1 & " --棚分類")
        End If
        If IsNotNull(XTANA_BLOCK) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTANA_BLOCK
            strSQL.Append(vbCrLf & "    AND XTANA_BLOCK = :" & UBound(strBindField) - 1 & " --棚ﾌﾞﾛｯｸ")
        End If
        If IsNotNull(XTANA_BLOCK_DTL) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTANA_BLOCK_DTL
            strSQL.Append(vbCrLf & "    AND XTANA_BLOCK_DTL = :" & UBound(strBindField) - 1 & " --棚ﾌﾞﾛｯｸ詳細")
        End If
        If IsNotNull(XTANA_BLOCK_STS) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTANA_BLOCK_STS
            strSQL.Append(vbCrLf & "    AND XTANA_BLOCK_STS = :" & UBound(strBindField) - 1 & " --棚ﾌﾞﾛｯｸ状態")
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
        If IsNothing(objType.GetProperty("FTRK_BUF_NO")) = False Then mFTRK_BUF_NO = objObject.FTRK_BUF_NO 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        If IsNothing(objType.GetProperty("FTRK_BUF_ARRAY")) = False Then mFTRK_BUF_ARRAY = objObject.FTRK_BUF_ARRAY 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
        If IsNothing(objType.GetProperty("FSERCH_NO")) = False Then mFSERCH_NO = objObject.FSERCH_NO '空検索順№
        If IsNothing(objType.GetProperty("FTRNS_ADDRESS")) = False Then mFTRNS_ADDRESS = objObject.FTRNS_ADDRESS '搬送指示用ｱﾄﾞﾚｽ
        If IsNothing(objType.GetProperty("FDISP_ADDRESS")) = False Then mFDISP_ADDRESS = objObject.FDISP_ADDRESS '表記用ｱﾄﾞﾚｽ
        If IsNothing(objType.GetProperty("FRAC_RETU")) = False Then mFRAC_RETU = objObject.FRAC_RETU '列
        If IsNothing(objType.GetProperty("FRAC_REN")) = False Then mFRAC_REN = objObject.FRAC_REN '連
        If IsNothing(objType.GetProperty("FRAC_DAN")) = False Then mFRAC_DAN = objObject.FRAC_DAN '段
        If IsNothing(objType.GetProperty("FRAC_EDA")) = False Then mFRAC_EDA = objObject.FRAC_EDA '枝
        If IsNothing(objType.GetProperty("FREMOVE_KIND")) = False Then mFREMOVE_KIND = objObject.FREMOVE_KIND '禁止有無
        If IsNothing(objType.GetProperty("FRAC_FORM")) = False Then mFRAC_FORM = objObject.FRAC_FORM '棚形状種別
        If IsNothing(objType.GetProperty("FRES_KIND")) = False Then mFRES_KIND = objObject.FRES_KIND '引当状態
        If IsNothing(objType.GetProperty("FRSV_PALLET")) = False Then mFRSV_PALLET = objObject.FRSV_PALLET '仮引当ﾊﾟﾚｯﾄID
        If IsNothing(objType.GetProperty("FTR_FM")) = False Then mFTR_FM = objObject.FTR_FM '搬送FMﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        If IsNothing(objType.GetProperty("FTR_TO")) = False Then mFTR_TO = objObject.FTR_TO '搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        If IsNothing(objType.GetProperty("FTR_IDOU")) = False Then mFTR_IDOU = objObject.FTR_IDOU '搬送TO移動ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        If IsNothing(objType.GetProperty("FTRNS_FM")) = False Then mFTRNS_FM = objObject.FTRNS_FM '搬送指令用FM
        If IsNothing(objType.GetProperty("FTRNS_TO")) = False Then mFTRNS_TO = objObject.FTRNS_TO '搬送指令用TO
        If IsNothing(objType.GetProperty("FRSV_BUF_FM")) = False Then mFRSV_BUF_FM = objObject.FRSV_BUF_FM 'FM引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        If IsNothing(objType.GetProperty("FRSV_ARRAY_FM")) = False Then mFRSV_ARRAY_FM = objObject.FRSV_ARRAY_FM 'FM引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
        If IsNothing(objType.GetProperty("FRSV_BUF_TO")) = False Then mFRSV_BUF_TO = objObject.FRSV_BUF_TO 'TO引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        If IsNothing(objType.GetProperty("FRSV_ARRAY_TO")) = False Then mFRSV_ARRAY_TO = objObject.FRSV_ARRAY_TO 'TO引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
        If IsNothing(objType.GetProperty("FDISP_ADDRESS_FM")) = False Then mFDISP_ADDRESS_FM = objObject.FDISP_ADDRESS_FM 'FM表記用ｱﾄﾞﾚｽ
        If IsNothing(objType.GetProperty("FDISP_ADDRESS_TO")) = False Then mFDISP_ADDRESS_TO = objObject.FDISP_ADDRESS_TO 'TO表記用ｱﾄﾞﾚｽ
        If IsNothing(objType.GetProperty("FDISPLOG_ADDRESS_FM")) = False Then mFDISPLOG_ADDRESS_FM = objObject.FDISPLOG_ADDRESS_FM 'FM表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用
        If IsNothing(objType.GetProperty("FDISPLOG_ADDRESS_TO")) = False Then mFDISPLOG_ADDRESS_TO = objObject.FDISPLOG_ADDRESS_TO 'TO表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用
        If IsNothing(objType.GetProperty("FPALLET_ID")) = False Then mFPALLET_ID = objObject.FPALLET_ID 'ﾊﾟﾚｯﾄID
        If IsNothing(objType.GetProperty("FBUF_IN_DT")) = False Then mFBUF_IN_DT = objObject.FBUF_IN_DT 'ﾊﾞｯﾌｧ入日時
        If IsNothing(objType.GetProperty("FRAC_BUNRUI")) = False Then mFRAC_BUNRUI = objObject.FRAC_BUNRUI '棚分類
        If IsNothing(objType.GetProperty("XTANA_BLOCK")) = False Then mXTANA_BLOCK = objObject.XTANA_BLOCK '棚ﾌﾞﾛｯｸ
        If IsNothing(objType.GetProperty("XTANA_BLOCK_DTL")) = False Then mXTANA_BLOCK_DTL = objObject.XTANA_BLOCK_DTL '棚ﾌﾞﾛｯｸ詳細
        If IsNothing(objType.GetProperty("XTANA_BLOCK_STS")) = False Then mXTANA_BLOCK_STS = objObject.XTANA_BLOCK_STS '棚ﾌﾞﾛｯｸ状態

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
        mFTRK_BUF_NO = Nothing
        mFTRK_BUF_ARRAY = Nothing
        mFSERCH_NO = Nothing
        mFTRNS_ADDRESS = Nothing
        mFDISP_ADDRESS = Nothing
        mFRAC_RETU = Nothing
        mFRAC_REN = Nothing
        mFRAC_DAN = Nothing
        mFRAC_EDA = Nothing
        mFREMOVE_KIND = Nothing
        mFRAC_FORM = Nothing
        mFRES_KIND = Nothing
        mFRSV_PALLET = Nothing
        mFTR_FM = Nothing
        mFTR_TO = Nothing
        mFTR_IDOU = Nothing
        mFTRNS_FM = Nothing
        mFTRNS_TO = Nothing
        mFRSV_BUF_FM = Nothing
        mFRSV_ARRAY_FM = Nothing
        mFRSV_BUF_TO = Nothing
        mFRSV_ARRAY_TO = Nothing
        mFDISP_ADDRESS_FM = Nothing
        mFDISP_ADDRESS_TO = Nothing
        mFDISPLOG_ADDRESS_FM = Nothing
        mFDISPLOG_ADDRESS_TO = Nothing
        mFPALLET_ID = Nothing
        mFBUF_IN_DT = Nothing
        mFRAC_BUNRUI = Nothing
        mXTANA_BLOCK = Nothing
        mXTANA_BLOCK_DTL = Nothing
        mXTANA_BLOCK_STS = Nothing


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
        mFTRK_BUF_NO = TO_INTEGER_NULLABLE(objRow("FTRK_BUF_NO"))
        mFTRK_BUF_ARRAY = TO_INTEGER_NULLABLE(objRow("FTRK_BUF_ARRAY"))
        mFSERCH_NO = TO_INTEGER_NULLABLE(objRow("FSERCH_NO"))
        mFTRNS_ADDRESS = TO_STRING_NULLABLE(objRow("FTRNS_ADDRESS"))
        mFDISP_ADDRESS = TO_STRING_NULLABLE(objRow("FDISP_ADDRESS"))
        mFRAC_RETU = TO_INTEGER_NULLABLE(objRow("FRAC_RETU"))
        mFRAC_REN = TO_INTEGER_NULLABLE(objRow("FRAC_REN"))
        mFRAC_DAN = TO_INTEGER_NULLABLE(objRow("FRAC_DAN"))
        mFRAC_EDA = TO_INTEGER_NULLABLE(objRow("FRAC_EDA"))
        mFREMOVE_KIND = TO_INTEGER_NULLABLE(objRow("FREMOVE_KIND"))
        mFRAC_FORM = TO_INTEGER_NULLABLE(objRow("FRAC_FORM"))
        mFRES_KIND = TO_INTEGER_NULLABLE(objRow("FRES_KIND"))
        mFRSV_PALLET = TO_STRING_NULLABLE(objRow("FRSV_PALLET"))
        mFTR_FM = TO_INTEGER_NULLABLE(objRow("FTR_FM"))
        mFTR_TO = TO_INTEGER_NULLABLE(objRow("FTR_TO"))
        mFTR_IDOU = TO_INTEGER_NULLABLE(objRow("FTR_IDOU"))
        mFTRNS_FM = TO_STRING_NULLABLE(objRow("FTRNS_FM"))
        mFTRNS_TO = TO_STRING_NULLABLE(objRow("FTRNS_TO"))
        mFRSV_BUF_FM = TO_INTEGER_NULLABLE(objRow("FRSV_BUF_FM"))
        mFRSV_ARRAY_FM = TO_INTEGER_NULLABLE(objRow("FRSV_ARRAY_FM"))
        mFRSV_BUF_TO = TO_INTEGER_NULLABLE(objRow("FRSV_BUF_TO"))
        mFRSV_ARRAY_TO = TO_INTEGER_NULLABLE(objRow("FRSV_ARRAY_TO"))
        mFDISP_ADDRESS_FM = TO_STRING_NULLABLE(objRow("FDISP_ADDRESS_FM"))
        mFDISP_ADDRESS_TO = TO_STRING_NULLABLE(objRow("FDISP_ADDRESS_TO"))
        mFDISPLOG_ADDRESS_FM = TO_STRING_NULLABLE(objRow("FDISPLOG_ADDRESS_FM"))
        mFDISPLOG_ADDRESS_TO = TO_STRING_NULLABLE(objRow("FDISPLOG_ADDRESS_TO"))
        mFPALLET_ID = TO_STRING_NULLABLE(objRow("FPALLET_ID"))
        mFBUF_IN_DT = TO_DATE_NULLABLE(objRow("FBUF_IN_DT"))
        mFRAC_BUNRUI = TO_STRING_NULLABLE(objRow("FRAC_BUNRUI"))
        mXTANA_BLOCK = TO_INTEGER_NULLABLE(objRow("XTANA_BLOCK"))
        mXTANA_BLOCK_DTL = TO_INTEGER_NULLABLE(objRow("XTANA_BLOCK_DTL"))
        mXTANA_BLOCK_STS = TO_INTEGER_NULLABLE(objRow("XTANA_BLOCK_STS"))


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
        strMsg &= "[ﾃｰﾌﾞﾙ名:ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ]"
        If IsNotNull(FTRK_BUF_NO) Then
            strMsg &= "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & FTRK_BUF_NO & "]"
        End If
        If IsNotNull(FTRK_BUF_ARRAY) Then
            strMsg &= "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№:" & FTRK_BUF_ARRAY & "]"
        End If
        If IsNotNull(FSERCH_NO) Then
            strMsg &= "[空検索順№:" & FSERCH_NO & "]"
        End If
        If IsNotNull(FTRNS_ADDRESS) Then
            strMsg &= "[搬送指示用ｱﾄﾞﾚｽ:" & FTRNS_ADDRESS & "]"
        End If
        If IsNotNull(FDISP_ADDRESS) Then
            strMsg &= "[表記用ｱﾄﾞﾚｽ:" & FDISP_ADDRESS & "]"
        End If
        If IsNotNull(FRAC_RETU) Then
            strMsg &= "[列:" & FRAC_RETU & "]"
        End If
        If IsNotNull(FRAC_REN) Then
            strMsg &= "[連:" & FRAC_REN & "]"
        End If
        If IsNotNull(FRAC_DAN) Then
            strMsg &= "[段:" & FRAC_DAN & "]"
        End If
        If IsNotNull(FRAC_EDA) Then
            strMsg &= "[枝:" & FRAC_EDA & "]"
        End If
        If IsNotNull(FREMOVE_KIND) Then
            strMsg &= "[禁止有無:" & FREMOVE_KIND & "]"
        End If
        If IsNotNull(FRAC_FORM) Then
            strMsg &= "[棚形状種別:" & FRAC_FORM & "]"
        End If
        If IsNotNull(FRES_KIND) Then
            strMsg &= "[引当状態:" & FRES_KIND & "]"
        End If
        If IsNotNull(FRSV_PALLET) Then
            strMsg &= "[仮引当ﾊﾟﾚｯﾄID:" & FRSV_PALLET & "]"
        End If
        If IsNotNull(FTR_FM) Then
            strMsg &= "[搬送FMﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & FTR_FM & "]"
        End If
        If IsNotNull(FTR_TO) Then
            strMsg &= "[搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & FTR_TO & "]"
        End If
        If IsNotNull(FTR_IDOU) Then
            strMsg &= "[搬送TO移動ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & FTR_IDOU & "]"
        End If
        If IsNotNull(FTRNS_FM) Then
            strMsg &= "[搬送指令用FM:" & FTRNS_FM & "]"
        End If
        If IsNotNull(FTRNS_TO) Then
            strMsg &= "[搬送指令用TO:" & FTRNS_TO & "]"
        End If
        If IsNotNull(FRSV_BUF_FM) Then
            strMsg &= "[FM引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & FRSV_BUF_FM & "]"
        End If
        If IsNotNull(FRSV_ARRAY_FM) Then
            strMsg &= "[FM引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№:" & FRSV_ARRAY_FM & "]"
        End If
        If IsNotNull(FRSV_BUF_TO) Then
            strMsg &= "[TO引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & FRSV_BUF_TO & "]"
        End If
        If IsNotNull(FRSV_ARRAY_TO) Then
            strMsg &= "[TO引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№:" & FRSV_ARRAY_TO & "]"
        End If
        If IsNotNull(FDISP_ADDRESS_FM) Then
            strMsg &= "[FM表記用ｱﾄﾞﾚｽ:" & FDISP_ADDRESS_FM & "]"
        End If
        If IsNotNull(FDISP_ADDRESS_TO) Then
            strMsg &= "[TO表記用ｱﾄﾞﾚｽ:" & FDISP_ADDRESS_TO & "]"
        End If
        If IsNotNull(FDISPLOG_ADDRESS_FM) Then
            strMsg &= "[FM表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用:" & FDISPLOG_ADDRESS_FM & "]"
        End If
        If IsNotNull(FDISPLOG_ADDRESS_TO) Then
            strMsg &= "[TO表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用:" & FDISPLOG_ADDRESS_TO & "]"
        End If
        If IsNotNull(FPALLET_ID) Then
            strMsg &= "[ﾊﾟﾚｯﾄID:" & FPALLET_ID & "]"
        End If
        If IsNotNull(FBUF_IN_DT) Then
            strMsg &= "[ﾊﾞｯﾌｧ入日時:" & FBUF_IN_DT & "]"
        End If
        If IsNotNull(FRAC_BUNRUI) Then
            strMsg &= "[棚分類:" & FRAC_BUNRUI & "]"
        End If
        If IsNotNull(XTANA_BLOCK) Then
            strMsg &= "[棚ﾌﾞﾛｯｸ:" & XTANA_BLOCK & "]"
        End If
        If IsNotNull(XTANA_BLOCK_DTL) Then
            strMsg &= "[棚ﾌﾞﾛｯｸ詳細:" & XTANA_BLOCK_DTL & "]"
        End If
        If IsNotNull(XTANA_BLOCK_STS) Then
            strMsg &= "[棚ﾌﾞﾛｯｸ状態:" & XTANA_BLOCK_STS & "]"
        End If


    End Sub
#End Region
    '↑↑↑自動生成部
    '**********************************************************************************************

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ共通
#Region "  ｸﾗｽ変数定義"
    'ﾌﾟﾛﾊﾟﾃｨ(ﾃｰﾌﾞﾙ列)
    Private mintRETU_MIN As Nullable(Of Integer)            '引当て最小列
    Private mintRETU_MAX As Nullable(Of Integer)            '引当て最大列
    Private mintDAN_MIN As Nullable(Of Integer)             '引当て最小段
    Private mintDAN_MAX As Nullable(Of Integer)             '引当て最大段
    Private mintFIFO_STS_FLAG As Nullable(Of Integer)       'FIFO引当状態ﾌﾗｸﾞ(OFF:未引当 ON:引当済)
    '↓↓↓↓↓↓************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/04/26  入出庫予約棚を取得機能追加
    Private mobjTMST_CRANE As TBL_TMST_CRANE            'ｸﾚｰﾝﾏｽﾀ
    '↑↑↑↑↑↑************************************************************************************************************
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義"
    Public Property INTRETU_MIN() As Nullable(Of Integer)
        Get
            Return mintRETU_MIN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mintRETU_MIN = Value
        End Set
    End Property
    Public Property INTRETU_MAX() As Nullable(Of Integer)
        Get
            Return mintRETU_MAX
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mintRETU_MAX = Value
        End Set
    End Property
    Public Property INTDAN_MIN() As Nullable(Of Integer)
        Get
            Return mintDAN_MIN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mintDAN_MIN = Value
        End Set
    End Property
    Public Property INTDAN_MAX() As Nullable(Of Integer)
        Get
            Return mintDAN_MAX
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mintDAN_MAX = Value
        End Set
    End Property
    Public Property INTFIFO_STS_FLAG() As Nullable(Of Integer)
        Get
            Return mintFIFO_STS_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mintFIFO_STS_FLAG = Value
        End Set
    End Property
    '↓↓↓↓↓↓************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/04/26  入出庫予約棚を取得機能追加
    Public Property objTMST_CRANE() As TBL_TMST_CRANE
        Get
            Return mobjTMST_CRANE
        End Get
        Set(ByVal Value As TBL_TMST_CRANE)
            mobjTMST_CRANE = Value
        End Set
    End Property
    '↑↑↑↑↑↑************************************************************************************************************
#End Region
#Region "  ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ特定  [仮引当ﾊﾟﾚｯﾄID]    (Public GET_TPRG_TRK_BUF_RSV_PALLET)"
    Public Function GET_TPRG_TRK_BUF_RSV_PALLET() As RetCode
        Try
            Dim strSQL As String                'SQL文
            Dim strMsg As String                'ﾒｯｾｰｼﾞ
            Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
            Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
            Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のデータ


            '***********************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '***********************
            If IsNull(mFRSV_PALLET) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[仮引当ﾊﾟﾚｯﾄID]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFTRK_BUF_NO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '抽出SQL作成
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    *"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TPRG_TRK_BUF"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FRSV_PALLET = '" & TO_STRING(mFRSV_PALLET) & "'"    '仮引当ﾊﾟﾚｯﾄID
            strSQL &= vbCrLf & "    AND FTRK_BUF_NO = " & TO_STRING(mFTRK_BUF_NO)           'ﾊﾞｯﾌｧ№
            strSQL &= vbCrLf


            '***********************
            '抽出
            '***********************
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TPRG_TRK_BUF"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            '↓↓↓↓↓↓************************************************************************************************************
            'Checked SystemMate:N.Dounoshita 2011/10/19 複数ﾚｺｰﾄﾞ取得ｴﾗｰに対応

            If objDataSet.Tables(strDataSetName).Rows.Count <= 0 Then
                Return (RetCode.NotFound)
            ElseIf objDataSet.Tables(strDataSetName).Rows.Count = 1 Then
                objRow = objDataSet.Tables(strDataSetName).Rows(0)
                Call SET_DATA(objRow)
                Return (RetCode.OK)
            Else
                Throw New Exception("複数ﾚｺｰﾄﾞ抽出した為、ｴﾗｰとします。")
            End If

            'If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            '    objRow = objDataSet.Tables(strDataSetName).Rows(0)
            '    Call SET_DATA(objRow)
            '    Return (RetCode.OK)
            'Else
            '    Return (RetCode.NotFound)
            'End If

            '↑↑↑↑↑↑************************************************************************************************************


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region
#Region "  ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ特定  [空平置き] (Public GET_TPRG_TRK_BUF_AKI_HIRA)"
    Public Function GET_TPRG_TRK_BUF_AKI_HIRA() As RetCode
        Try
            Dim strSQL As String                'SQL文
            Dim strMsg As String                'ﾒｯｾｰｼﾞ
            Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
            Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
            Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のデータ


            '***********************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '***********************
            If IsNull(mFTRK_BUF_NO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[ﾊﾞｯﾌｧNo]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '抽出SQL作成
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    *"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TPRG_TRK_BUF"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FTRK_BUF_NO = " & TO_STRING(mFTRK_BUF_NO)               'ﾊﾞｯﾌｧNo
            strSQL &= vbCrLf & "    AND FTRK_BUF_ARRAY = ("                                     '配列No
            strSQL &= vbCrLf & "        SELECT"
            strSQL &= vbCrLf & "            MIN(FTRK_BUF_ARRAY)"
            strSQL &= vbCrLf & "         FROM"
            strSQL &= vbCrLf & "            TPRG_TRK_BUF"
            strSQL &= vbCrLf & "         WHERE"
            strSQL &= vbCrLf & "                FTRK_BUF_NO = " & TO_STRING(mFTRK_BUF_NO)       'ﾊﾞｯﾌｧNo
            strSQL &= vbCrLf & "            AND FPALLET_ID IS NULL"                             'ﾊﾟﾚｯﾄID
            strSQL &= vbCrLf & "            AND FRES_KIND = " & TO_STRING(FRES_KIND_SAKI)        '在庫引当状態
            strSQL &= vbCrLf & "            AND FREMOVE_KIND = " & TO_STRING(FLAG_OFF)          '禁止有無
            strSQL &= vbCrLf & "    )"
            strSQL &= vbCrLf


            '***********************
            '抽出
            '***********************
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TPRG_TRK_BUF"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                objRow = objDataSet.Tables(strDataSetName).Rows(0)
                Call SET_DATA(objRow)
                Return (RetCode.OK)
            Else
                Return (RetCode.NotFound)
            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "  ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ特定  [FIFO在庫] (Public GET_TPRG_TRK_BUF_FIFO)"
    '↓↓↓↓↓↓************************************************************************************************************
    'SystemMate:N.Dounoshita 2013/03/25  複数ﾄﾗｯｷﾝｸﾞ取得可能なようにした
    Public Function GET_TPRG_TRK_BUF_FIFO(Optional ByVal blnAll As Boolean = False) As RetCode
        'Public Function GET_TPRG_TRK_BUF_FIFO() As RetCode
        '↑↑↑↑↑↑************************************************************************************************************
        Try
            Dim strSQL As String                'SQL文
            Dim strMsg As String                'ﾒｯｾｰｼﾞ
            Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
            Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
            Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のデータ


            '***********************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '***********************
            If IsNull(mFTRK_BUF_NO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[ﾊﾞｯﾌｧ№]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '抽出SQL作成
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    *"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TPRG_TRK_BUF"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FTRK_BUF_NO = " & TO_STRING(mFTRK_BUF_NO)   'ﾊﾞｯﾌｧNo
            strSQL &= vbCrLf & "    AND FPALLET_ID IS NOT NULL"                     'ﾊﾟﾚｯﾄID
            If IsNotNull(mFTR_TO) Then
                strSQL &= vbCrLf & "    AND FTR_TO = " & TO_STRING(mFTR_TO)             '搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            End If
            If IsNotNull(mFTR_FM) Then
                strSQL &= vbCrLf & "    AND FTR_FM = " & TO_STRING(mFTR_FM)             '搬送FMﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            End If
            If IsNotNull(mFRSV_BUF_TO) Then
                strSQL &= vbCrLf & "    AND FRSV_BUF_TO = " & TO_STRING(mFRSV_BUF_TO)   'TO引当ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            End If
            strSQL &= vbCrLf & " ORDER BY"
            strSQL &= vbCrLf & "    FBUF_IN_DT"                                     'ﾊﾞｯﾌｧ入日時
            strSQL &= vbCrLf & "   ,FTRK_BUF_ARRAY"                                 '配列No
            strSQL &= vbCrLf


            '-----------------------
            '抽出
            '-----------------------
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TPRG_TRK_BUF"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then

                If blnAll = True Then
                    '(全取得の場合)
                    ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
                    For ii As Integer = LBound(mobjAryMe) To UBound(mobjAryMe)
                        objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                        mobjAryMe(ii) = New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                        mobjAryMe(ii).SET_DATA(objRow)
                    Next ii
                Else
                    '(一件取得の場合)
                    objRow = objDataSet.Tables(strDataSetName).Rows(0)
                    Call SET_DATA(objRow)
                End If

                Return (RetCode.OK)
            Else
                Return (RetCode.NotFound)
            End If


        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
    End Function
#End Region
#Region "  ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ特定  [入庫ST在庫] (Public GET_TPRG_TRK_BUF_ST_IN)"
    Public Function GET_TPRG_TRK_BUF_ST_IN() As RetCode
        Try
            Dim strSQL As String                'SQL文
            'Dim strMsg As String                'ﾒｯｾｰｼﾞ
            Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
            'Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
            'Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のデータ


            '***********************
            '抽出SQL作成
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    *"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TPRG_TRK_BUF"
            strSQL &= vbCrLf & "  , TMST_ST"
            strSQL &= vbCrLf & "  , TMST_TRK"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "      (    TMST_ST.FINOUT_KUBUN = " & TO_STRING(FINOUT_KUBUN_SIN)            '入出庫区分(入庫)
            strSQL &= vbCrLf & "        OR TMST_ST.FINOUT_KUBUN = " & TO_STRING(FINOUT_KUBUN_SINOUT)         '入出庫区分(入出庫)
            strSQL &= vbCrLf & "      )"
            strSQL &= vbCrLf & "    AND TMST_ST.FTRK_BUF_NO = TPRG_TRK_BUF.FTRK_BUF_NO"                     'ﾊﾞｯﾌｧNo
            strSQL &= vbCrLf & "    AND TMST_TRK.FTRK_BUF_NO = TPRG_TRK_BUF.FTRK_BUF_NO"                     'ﾊﾞｯﾌｧNo
            strSQL &= vbCrLf & "    AND TMST_TRK.FBUF_KIND = " & FBUF_KIND_SONE                              'ﾊﾞｯﾌｧ種別（入出庫ST）
            strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FPALLET_ID IS NOT NULL"                                'ﾊﾟﾚｯﾄID
            strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FRES_KIND = " & TO_STRING(FRES_KIND_SRSV_TRNS_OUT)      '在庫引当状態(搬送予約)
            strSQL &= vbCrLf & " ORDER BY"
            strSQL &= vbCrLf & "    TPRG_TRK_BUF.FBUF_IN_DT"                                    'ﾊﾞｯﾌｧ入日時
            strSQL &= vbCrLf & "   ,TPRG_TRK_BUF.FTRK_BUF_ARRAY"                                '配列No
            strSQL &= vbCrLf

            mstrUSER_SQL = strSQL
            Dim intRet As RetCode
            intRet = GET_TPRG_TRK_BUF_USER()
            Return intRet


        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
    End Function
#End Region
#Region "  ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ特定  [空棚]     (Public GET_TPRG_TRK_BUF_AKI_RAC)"
    '''************************************************************************************************************
    ''' <summary>
    ''' ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ特定  [空棚]
    ''' </summary>
    ''' <param name="blnAll">全ての空棚を取得するか否か</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''************************************************************************************************************
    Public Function GET_TPRG_TRK_BUF_AKI_RAC(Optional ByVal blnAll As Boolean = False) As RetCode
        Try
            Dim strSQL As String                'SQL文
            Dim strMsg As String                'ﾒｯｾｰｼﾞ
            Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
            Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
            Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のデータ


            '***********************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '***********************
            If IsNull(mFTRK_BUF_NO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[ﾊﾞｯﾌｧNo]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '抽出SQL作成
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "         SELECT "
            strSQL &= vbCrLf & "            * "
            strSQL &= vbCrLf & "         FROM"
            strSQL &= vbCrLf & "            TPRG_TRK_BUF,TMST_CRANE,TSTS_EQ_CTRL"
            strSQL &= vbCrLf & "         WHERE"
            strSQL &= vbCrLf & "                TPRG_TRK_BUF.FTRK_BUF_NO = " & TO_STRING(mFTRK_BUF_NO)      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
            strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.FPALLET_ID IS NULL"                            'ﾊﾟﾚｯﾄID
            strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.FRES_KIND = " & TO_STRING(FRES_KIND_SAKI)       '在庫引当状態
            strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.FREMOVE_KIND = " & TO_STRING(FLAG_OFF)         '禁止有無
            If IsNull(mFRAC_FORM) = False Then
                strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.FRAC_FORM = " & TO_STRING(mFRAC_FORM)      '棚形状種別
            End If
            If IsNull(mFRAC_BUNRUI) = False Then
                strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.FRAC_BUNRUI = " & TO_STRING(mFRAC_BUNRUI)  '棚分類
            End If
            If IsNull(mintRETU_MIN) = False And IsNull(mintRETU_MAX) = False Then
                '(列指定有りの場合)
                strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.FRAC_RETU >= " & TO_STRING(INTRETU_MIN)    '最小列
                strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.FRAC_RETU <= " & TO_STRING(INTRETU_MAX)    '最大列
            End If
            If IsNull(mintDAN_MIN) = False And IsNull(mintDAN_MAX) = False Then
                '(段指定有りの場合)
                strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.FRAC_DAN >= " & TO_STRING(INTDAN_MIN)      '最小段
                strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.FRAC_DAN <= " & TO_STRING(INTDAN_MAX)      '最大段
            End If
            strSQL &= vbCrLf & "            AND TMST_CRANE.FTRK_BUF_NO = TPRG_TRK_BUF.FTRK_BUF_NO"          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo

            strSQL &= vbCrLf & "            AND TMST_CRANE.FCRANE_ROW1 <= TPRG_TRK_BUF.FRAC_RETU"            '列1
            strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.FRAC_RETU <= TMST_CRANE.FCRANE_ROW2"            '列2

            strSQL &= vbCrLf & "            AND TSTS_EQ_CTRL.FEQ_ID = TMST_CRANE.FEQ_ID"                    '設備ID
            strSQL &= vbCrLf & "            AND TSTS_EQ_CTRL.FEQ_CUT_STS = " & FEQ_CUT_STS_SOFF              '切離有無


            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:N.Dounoshita 2013/04/03 手前棚、奥棚を区別させる為に必要
            If IsNull(mFRAC_EDA) = False Then
                strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.FRAC_EDA = " & TO_STRING(mFRAC_EDA)                '枝
            End If
            If IsNull(mXTANA_BLOCK) = False Then
                strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.XTANA_BLOCK = " & TO_STRING(mXTANA_BLOCK)          '棚ﾌﾞﾛｯｸ
            End If
            If IsNull(mXTANA_BLOCK_DTL) = False Then
                strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.XTANA_BLOCK_DTL = " & TO_STRING(mXTANA_BLOCK_DTL)  '棚ﾌﾞﾛｯｸ詳細
            End If
            If IsNull(mXTANA_BLOCK_STS) = False Then
                strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.XTANA_BLOCK_STS = " & TO_STRING(mXTANA_BLOCK_STS)  '棚ﾌﾞﾛｯｸ状態
            End If
            '↑↑↑↑↑↑************************************************************************************************************


            strSQL &= vbCrLf & "         ORDER BY "
            strSQL &= vbCrLf & "            TPRG_TRK_BUF.FSERCH_NO "        '空検索順No

            strSQL &= vbCrLf


            '***********************
            '抽出
            '***********************
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TPRG_TRK_BUF"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then

                If blnAll = True Then
                    '(全取得の場合)
                    ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
                    For ii As Integer = LBound(mobjAryMe) To UBound(mobjAryMe)
                        objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                        mobjAryMe(ii) = New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                        mobjAryMe(ii).SET_DATA(objRow)
                    Next ii
                Else
                    '(一件取得の場合)
                    objRow = objDataSet.Tables(strDataSetName).Rows(0)
                    Call SET_DATA(objRow)
                End If

                Return (RetCode.OK)
            Else
                Return (RetCode.NotFound)
            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "  ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ特定  [棚番から] (Public GET_TPRG_TRK_BUF_TANA)"
    Public Function GET_TPRG_TRK_BUF_TANA() As RetCode
        Try
            Dim strSQL As String                'SQL文
            Dim strMsg As String                'ﾒｯｾｰｼﾞ
            Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
            Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
            Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のデータ


            '***********************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '***********************
            If 1 <> 1 Then
            ElseIf IsNull(mFTRK_BUF_NO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFRAC_RETU) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[列]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFRAC_REN) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[連]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFRAC_DAN) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[段]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '抽出SQL作成
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    *"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TPRG_TRK_BUF"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        1 = 1"
            strSQL &= vbCrLf & "    AND FTRK_BUF_NO = " & mFTRK_BUF_NO      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            strSQL &= vbCrLf & "    AND FRAC_RETU = " & mFRAC_RETU          '列
            strSQL &= vbCrLf & "    AND FRAC_REN = " & mFRAC_REN            '連
            strSQL &= vbCrLf & "    AND FRAC_DAN = " & mFRAC_DAN            '段
            strSQL &= vbCrLf


            '***********************
            '抽出
            '***********************
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TPRG_TRK_BUF"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                objRow = objDataSet.Tables(strDataSetName).Rows(0)
                Call SET_DATA(objRow)
                Return (RetCode.OK)
            Else
                Return (RetCode.NotFound)
            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region
#Region "  ﾊﾞｯﾌｧ解放　                  (Public CLEAR_TPRG_TRK_BUF)"
    Public Sub CLEAR_TPRG_TRK_BUF()
        Try
            Dim strSQL As String                    'SQL文
            Dim intRetSQL As Integer                'SQL実行戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ


            '***********************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '***********************
            If IsNull(mFTRK_BUF_NO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[ﾊﾞｯﾌｧNo]"
                Throw New System.Exception(strMsg)
            ElseIf IsNull(mFTRK_BUF_ARRAY) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[配列No]"
                Throw New System.Exception(strMsg)
            End If


            '***********************
            '更新SQL作成
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "UPDATE"
            strSQL &= vbCrLf & "    TPRG_TRK_BUF"                                   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
            strSQL &= vbCrLf & " SET"
            strSQL &= vbCrLf & "    FRES_KIND = " & TO_STRING(FRES_KIND_SAKI)        '在庫引当状態
            strSQL &= vbCrLf & "   ,FRSV_PALLET = NULL"                             '仮引当ﾊﾟﾚｯﾄID
            strSQL &= vbCrLf & "   ,FTR_FM = NULL"                                  '搬送FMﾊﾞｯﾌｧ№
            strSQL &= vbCrLf & "   ,FTR_TO = NULL"                                  '搬送TOﾊﾞｯﾌｧ№
            strSQL &= vbCrLf & "   ,FTR_IDOU = NULL"                                '搬送TO移動ﾊﾞｯﾌｧ№
            strSQL &= vbCrLf & "   ,FTRNS_FM = NULL"                                '搬送指令用FM
            strSQL &= vbCrLf & "   ,FTRNS_TO = NULL"                                '搬送指令用TO
            strSQL &= vbCrLf & "   ,FRSV_BUF_FM = NULL"                             'FM引当ﾄﾗｯｷﾝｸﾞ№
            strSQL &= vbCrLf & "   ,FRSV_ARRAY_FM = NULL"                           'FM引当配列№
            strSQL &= vbCrLf & "   ,FRSV_BUF_TO = NULL"                             'TO引当ﾄﾗｯｷﾝｸﾞ№
            strSQL &= vbCrLf & "   ,FRSV_ARRAY_TO = NULL"                           'TO引当配列№
            strSQL &= vbCrLf & "   ,FDISP_ADDRESS_FM = NULL"                        'FM表記用ｱﾄﾞﾚｽ
            strSQL &= vbCrLf & "   ,FDISP_ADDRESS_TO = NULL"                        'TO表記用ｱﾄﾞﾚｽ
            strSQL &= vbCrLf & "   ,FDISPLOG_ADDRESS_FM = NULL"                     'FM表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用
            strSQL &= vbCrLf & "   ,FDISPLOG_ADDRESS_TO = NULL"                     'TO表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用
            strSQL &= vbCrLf & "   ,FPALLET_ID = NULL"                              'ﾊﾟﾚｯﾄID
            strSQL &= vbCrLf & "   ,FBUF_IN_DT = NULL"                              'ﾊﾞｯﾌｧ入日時
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "       FTRK_BUF_NO = " & TO_STRING(mFTRK_BUF_NO)          'ﾊﾞｯﾌｧNo
            strSQL &= vbCrLf & "   AND FTRK_BUF_ARRAY = " & TO_STRING(mFTRK_BUF_ARRAY)    '配列No
            strSQL &= vbCrLf


            '***********************
            '関係するﾌﾟﾛﾊﾟﾃｨｸﾘｱ
            '***********************
            mFRES_KIND = FRES_KIND_SAKI              '在庫引当状態
            mFRSV_PALLET = Nothing                  '仮引当ﾊﾟﾚｯﾄID
            mFTR_FM = Nothing                       '搬送FMﾊﾞｯﾌｧ№
            mFTR_TO = Nothing                       '搬送TOﾊﾞｯﾌｧ№
            mFTR_IDOU = Nothing                     '搬送TO移動ﾊﾞｯﾌｧ№
            mFTRNS_FM = Nothing                     '搬送指令用FM
            mFTRNS_TO = Nothing                     '搬送指令用TO
            mFRSV_BUF_FM = Nothing                  'FM引当ﾄﾗｯｷﾝｸﾞ№
            mFRSV_ARRAY_FM = Nothing                'FM引当配列№
            mFRSV_BUF_TO = Nothing                  'TO引当ﾄﾗｯｷﾝｸﾞ№
            mFRSV_ARRAY_TO = Nothing                'TO引当配列№
            mFDISP_ADDRESS_FM = Nothing             'FM表記用ｱﾄﾞﾚｽ
            mFDISP_ADDRESS_TO = Nothing             'TO表記用ｱﾄﾞﾚｽ
            mFDISPLOG_ADDRESS_FM = Nothing          'FM表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用
            mFDISPLOG_ADDRESS_TO = Nothing          'TO表記用ｱﾄﾞﾚｽ_ﾛｸﾞ用
            mFPALLET_ID = Nothing                   'ﾊﾟﾚｯﾄID
            mFBUF_IN_DT = Nothing                   'ﾊﾞｯﾌｧ入日時


            '***********************
            '更新
            '***********************
            intRetSQL = ObjDb.Execute(strSQL)
            If intRetSQL = -1 Then
                '(SQLｴﾗｰ)
                strSQL = Replace(strSQL, vbCrLf, "")
                strMsg = ObjDb.ErrMsg & "【" & strSQL & "】"
                strMsg = ERRMSG_ERR_UPDATE & strMsg
                Throw New UserException(strMsg)
            End If
            If intRetSQL <> 1 Then
                '(更新行不正)
                strSQL = Replace(strSQL, vbCrLf, "")
                strMsg = ERRMSG_ERR_UPDATE & "[ﾃｰﾌﾞﾙ:TPRG_TRK_BUF  ,ﾊﾞｯﾌｧNo:" & TO_STRING(mFTRK_BUF_NO) & "  ,配列No:" & TO_STRING(mFTRK_BUF_ARRAY) & "]"
                Throw New UserException(strMsg)
            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region
#Region "  ﾊﾞｯﾌｧ解放    [仮引当ﾊﾟﾚｯﾄID] (Public CLEAR_TPRG_TRK_BUF_RSV_PC)"
    Public Sub CLEAR_TPRG_TRK_BUF_RSV_PC()
        Try
            Dim strSQL As String                    'SQL文
            Dim intRetSQL As Integer                'SQL実行戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ


            '***********************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '***********************
            If IsNull(mFRSV_PALLET) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[仮引当ﾊﾟﾚｯﾄID]"
                Throw New System.Exception(strMsg)
            End If


            '***********************
            '更新SQL作成
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "UPDATE"
            strSQL &= vbCrLf & "    TPRG_TRK_BUF"                        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
            strSQL &= vbCrLf & " SET"
            strSQL &= vbCrLf & "    FRES_KIND = " & TO_STRING(FRES_KIND_SAKI)        '在庫引当状態
            strSQL &= vbCrLf & "   ,FRSV_PALLET = NULL"                             '仮引当ﾊﾟﾚｯﾄID
            strSQL &= vbCrLf & "   ,FTR_FM = NULL"                                  '搬送FMﾊﾞｯﾌｧ№
            strSQL &= vbCrLf & "   ,FTR_TO = NULL"                                  '搬送TOﾊﾞｯﾌｧ№
            strSQL &= vbCrLf & "   ,FTR_IDOU = NULL"                                '搬送TO移動ﾊﾞｯﾌｧ№
            strSQL &= vbCrLf & "   ,FTRNS_FM = NULL"                                '搬送指令用FM
            strSQL &= vbCrLf & "   ,FTRNS_TO = NULL"                                '搬送指令用TO
            strSQL &= vbCrLf & "   ,FRSV_BUF_FM = NULL"                             'FM引当ﾄﾗｯｷﾝｸﾞ№
            strSQL &= vbCrLf & "   ,FRSV_ARRAY_FM = NULL"                           'FM引当配列№
            strSQL &= vbCrLf & "   ,FRSV_BUF_TO = NULL"                             'TO引当ﾄﾗｯｷﾝｸﾞ№
            strSQL &= vbCrLf & "   ,FRSV_ARRAY_TO = NULL"                           'TO引当配列№
            strSQL &= vbCrLf & "   ,FDISP_ADDRESS_FM = NULL"                        'FM表記用ｱﾄﾞﾚｽ
            strSQL &= vbCrLf & "   ,FDISP_ADDRESS_TO = NULL"                        'TO表記用ｱﾄﾞﾚｽ
            strSQL &= vbCrLf & "   ,FPALLET_ID = NULL"                              'ﾊﾟﾚｯﾄID
            strSQL &= vbCrLf & "   ,FBUF_IN_DT = NULL"                              'ﾊﾞｯﾌｧ入日時
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "       FRSV_PALLET = '" & TO_STRING(mFRSV_PALLET) & "'"     '仮引当ﾊﾟﾚｯﾄID
            strSQL &= vbCrLf & "   AND (FPALLET_ID <> '" & TO_STRING(mFRSV_PALLET) & "'"    '仮引当ﾊﾟﾚｯﾄID
            strSQL &= vbCrLf & "        OR FPALLET_ID IS NULL)"
            strSQL &= vbCrLf


            '***********************
            '更新
            '***********************
            intRetSQL = ObjDb.Execute(strSQL)
            If intRetSQL = -1 Then
                '(SQLｴﾗｰ)
                strSQL = Replace(strSQL, vbCrLf, "")
                strMsg = ObjDb.ErrMsg & "【" & strSQL & "】"
                strMsg = ERRMSG_ERR_UPDATE & strMsg
                Throw New UserException(strMsg)
            End If
            'If intRetSQL <> 1 Then
            '    '(更新行不正)
            '    strSQL = Replace(strSQL, vbCrLf, "")
            '    strMsg = ERRMSG_ERR_UPDATE & "[ﾃｰﾌﾞﾙ:TPRG_TRK_BUF  ,仮引当ﾊﾟﾚｯﾄID:" & mFRSV_PALLET & "]"
            '    Throw New UserException(strMsg)
            'End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region
#Region "  TO表記用ｱﾄﾞﾚｽ特定            (Public GET_FDISP_ADDRESS)"
    Public Function GET_ADDRESS_TO() As String
        Try
            'Dim strMsg As String                'ﾒｯｾｰｼﾞ
            Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
            Dim intRet As RetCode               '戻り値
            Dim strReturn As String             '自身関数戻り値


            '***********************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '***********************
            If IsNull(mFRSV_BUF_TO) = True Then
                strReturn = DEFAULT_STRING
                Return (strReturn)
            ElseIf IsNull(mFRSV_ARRAY_TO) = True Then
                strReturn = DEFAULT_STRING
                Return (strReturn)
            End If


            '************************
            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧの特定
            '************************
            Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧｸﾗｽ
            objTPRG_TRK_BUF.FTRK_BUF_NO = mFRSV_BUF_TO          'ﾊﾞｯﾌｧ№
            objTPRG_TRK_BUF.FTRK_BUF_ARRAY = mFRSV_ARRAY_TO     '配列№
            intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF(False)    '特定
            If intRet = RetCode.NotFound Then
                '(見つからない場合)
                strReturn = DEFAULT_STRING
                '' ''strMsg = ERRMSG_NOTFOUND_BUF & "[ﾊﾞｯﾌｧ№:" & objTPRG_TRK_BUF.FTRK_BUF_NO & "  ,ﾊﾞｯﾌｧ配列№:" & objTPRG_TRK_BUF.FTRK_BUF_ARRAY & "]"
                '' ''Throw New UserException(strMsg)
            End If
            strReturn = objTPRG_TRK_BUF.FDISP_ADDRESS


            Return (strReturn)
        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region
#Region "  ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ特定  [ﾊﾟﾚｯﾄ数]  (Public GET_TPRG_TRK_PALLET_COUNT)"
    '''*******************************************************************************************************************
    ''' <summary>
    ''' 指定されたﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧのﾊﾟﾚｯﾄ数を取得
    ''' </summary>
    ''' <returns>指定されたﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧのﾊﾟﾚｯﾄ数をｾｯﾄ</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Public Function GET_TPRG_TRK_PALLET_COUNT() As Integer
        Try
            Dim strSQL As String                'SQL文
            Dim strMsg As String                'ﾒｯｾｰｼﾞ
            Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
            Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
            Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のデータ


            '***********************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '***********************
            If IsNull(mFTRK_BUF_NO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[ﾊﾞｯﾌｧ№]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '抽出SQL作成
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    COUNT(*)"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TPRG_TRK_BUF"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FTRK_BUF_NO = " & TO_STRING(mFTRK_BUF_NO)   'ﾊﾞｯﾌｧNo
            strSQL &= vbCrLf & "    AND FPALLET_ID IS NOT NULL"                     'ﾊﾟﾚｯﾄID
            strSQL &= vbCrLf


            '-----------------------
            '抽出
            '-----------------------
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TPRG_TRK_BUF"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            objRow = objDataSet.Tables(strDataSetName).Rows(0)
            Return (objRow(0))


        Catch ex As Exception
            Throw New System.Exception(ex.Message)
        End Try
    End Function
#End Region
#Region "  ﾃﾞｰﾀ取得 [搬送中ﾄﾗｯｷﾝｸﾞ取得(TO)] "
    ''' <summary>
    ''' ﾃﾞｰﾀ取得 [搬送中ﾄﾗｯｷﾝｸﾞ取得(TO)]
    ''' </summary>
    ''' <returns>共通戻り値</returns>
    ''' <remarks></remarks>
    Public Function GET_TPRG_TRK_BUF_TR_TO() As RetCode
        Try
            Dim strSQL As New StringBuilder     'SQL文
            Dim strMsg As String                'ﾒｯｾｰｼﾞ
            Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
            Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
            Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
            Dim objParameter(1, 0) As Object
            Dim strBindField(0) As String
            Dim objBindValue(0) As Object

            '***********************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '***********************
            If 1 <> 1 Then
            ElseIf IsNull(mFTR_TO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '抽出SQL作成
            '***********************
            strBindField = Nothing
            objBindValue = Nothing
            ReDim Preserve strBindField(0)
            ReDim Preserve objBindValue(0)
            strSQL.Append(vbCrLf & "SELECT")
            strSQL.Append(vbCrLf & "    *")
            strSQL.Append(vbCrLf & " FROM")
            strSQL.Append(vbCrLf & "    TPRG_TRK_BUF")
            strSQL.Append(vbCrLf & " WHERE")
            strSQL.Append(vbCrLf & "        1 = 1")
            If IsNull(FTRK_BUF_NO) = True Then
                'NOP
            Else
                ReDim Preserve strBindField(UBound(strBindField) + 1)
                ReDim Preserve objBindValue(UBound(objBindValue) + 1)
                strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
                objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
                strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
            End If

            strSQL.Append(vbCrLf & "    AND FPALLET_ID IS NOT NULL --ﾊﾟﾚｯﾄID")

            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_TO
            strSQL.Append(vbCrLf & "    AND FTR_TO = :" & UBound(strBindField) - 1 & " --搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")

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
            strDataSetName = "TPRG_TRK_BUF"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                '↓↓↓↓↓↓************************************************************************************************************
                'Checked SystemMate:N.Dounoshita 2011/11/10 複数ﾚｺｰﾄﾞ取得するので対応
                ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
                For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                    objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                    mobjAryMe(ii) = New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                    mobjAryMe(ii).SET_DATA(objRow)
                Next ii
                'objRow = objDataSet.Tables(strDataSetName).Rows(0)
                'Call SET_DATA(objRow)
                '↑↑↑↑↑↑************************************************************************************************************
                Return (RetCode.OK)
            Else
                Return (RetCode.NotFound)
            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "  ﾃﾞｰﾀ取得 [搬送中ﾄﾗｯｷﾝｸﾞ取得(FM)] "
    ''' <summary>
    ''' ﾃﾞｰﾀ取得 [搬送中ﾄﾗｯｷﾝｸﾞ取得(FM)]
    ''' </summary>
    ''' <returns>共通戻り値</returns>
    ''' <remarks></remarks>
    Public Function GET_TPRG_TRK_BUF_TR_FM() As RetCode
        Try
            Dim strSQL As New StringBuilder     'SQL文
            Dim strMsg As String                'ﾒｯｾｰｼﾞ
            Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
            Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
            Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
            Dim objParameter(1, 0) As Object
            Dim strBindField(0) As String
            Dim objBindValue(0) As Object

            '***********************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '***********************
            If 1 <> 1 Then
            ElseIf IsNull(mFTR_FM) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[搬送FMﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '抽出SQL作成
            '***********************
            strBindField = Nothing
            objBindValue = Nothing
            ReDim Preserve strBindField(0)
            ReDim Preserve objBindValue(0)
            strSQL.Append(vbCrLf & "SELECT")
            strSQL.Append(vbCrLf & "    *")
            strSQL.Append(vbCrLf & " FROM")
            strSQL.Append(vbCrLf & "    TPRG_TRK_BUF")
            strSQL.Append(vbCrLf & " WHERE")
            strSQL.Append(vbCrLf & "        1 = 1")
            If IsNull(FTRK_BUF_NO) = True Then
                'NOP
            Else
                ReDim Preserve strBindField(UBound(strBindField) + 1)
                ReDim Preserve objBindValue(UBound(objBindValue) + 1)
                strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
                objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
                strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
            End If

            strSQL.Append(vbCrLf & "    AND FPALLET_ID IS NOT NULL --ﾊﾟﾚｯﾄID")

            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTR_FM
            strSQL.Append(vbCrLf & "    AND FTR_FM = :" & UBound(strBindField) - 1 & " --搬送FMﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")

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
            strDataSetName = "TPRG_TRK_BUF"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                '↓↓↓↓↓↓************************************************************************************************************
                'Checked SystemMate:N.Dounoshita 2011/11/10 複数ﾚｺｰﾄﾞ取得するので対応
                ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
                For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                    objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                    mobjAryMe(ii) = New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                    mobjAryMe(ii).SET_DATA(objRow)
                Next ii
                'objRow = objDataSet.Tables(strDataSetName).Rows(0)
                'Call SET_DATA(objRow)
                '↑↑↑↑↑↑************************************************************************************************************
                Return (RetCode.OK)
            Else
                Return (RetCode.NotFound)
            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "  搬送中ﾄﾗｯｷﾝｸﾞ有無ﾁｪｯｸ            "
    '''*********************************************************************************************************************
    ''' <summary>
    ''' 搬送中ﾄﾗｯｷﾝｸﾞ有無ﾁｪｯｸ
    ''' </summary>
    ''' <param name="strFTRK_BUF_NO"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''*********************************************************************************************************************
    Public Function CHECK_TPRG_TRK_BUF_RELAY(ByVal strFTRK_BUF_NO As String) As RetCode
        Try
            Dim intRet As RetCode = RetCode.NG


            '****************************************************
            'TOとなっているﾄﾗｯｷﾝｸﾞ      ﾁｪｯｸ
            '****************************************************
            Call CLEAR_PROPERTY()
            mFTR_TO = strFTRK_BUF_NO
            intRet = Me.GET_TPRG_TRK_BUF_TR_TO()
            If intRet <> RetCode.OK Then
                '(TOとなっているﾄﾗｯｷﾝｸﾞがなかった場合)


                '****************************************************
                'FMとなっているﾄﾗｯｷﾝｸﾞ      ﾁｪｯｸ
                '****************************************************
                Call CLEAR_PROPERTY()
                mFTR_FM = strFTRK_BUF_NO
                intRet = Me.GET_TPRG_TRK_BUF_TR_FM()

            End If


            Return intRet
        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

    '↓↓↓↓↓↓************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/04/26  入出庫予約棚を取得機能追加
#Region "  ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ特定  [入出庫予約棚]             "
    '''************************************************************************************************************
    ''' <summary>
    ''' ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ特定  [入出庫予約棚]
    ''' </summary>
    ''' <param name="blnAll">全ての棚を取得するか否か</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''************************************************************************************************************
    Public Function GET_TPRG_TRK_BUF_RESERVE_RAC(Optional ByVal blnAll As Boolean = False) As RetCode
        Try
            Dim strSQL As String                'SQL文
            Dim strMsg As String                'ﾒｯｾｰｼﾞ
            Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
            Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
            Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のデータ


            '***********************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '***********************
            If IsNull(mFTRK_BUF_NO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[ﾊﾞｯﾌｧNo]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '抽出SQL作成
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "         SELECT "
            strSQL &= vbCrLf & "            TPRG_TRK_BUF.FTRK_BUF_NO		AS	    FTRK_BUF_NO	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FTRK_BUF_ARRAY	AS      FTRK_BUF_ARRAY	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FSERCH_NO			AS      FSERCH_NO	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FTRNS_ADDRESS		AS      FTRNS_ADDRESS	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FDISP_ADDRESS		AS      FDISP_ADDRESS	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRAC_RETU			AS      FRAC_RETU	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRAC_REN			AS      FRAC_REN	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRAC_DAN			AS      FRAC_DAN	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRAC_EDA			AS      FRAC_EDA	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FREMOVE_KIND		AS      FREMOVE_KIND	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRAC_FORM			AS      FRAC_FORM	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRES_KIND			AS      FRES_KIND	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRSV_PALLET		AS      FRSV_PALLET	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FTR_FM			AS      FTR_FM		 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FTR_TO			AS      FTR_TO		 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FTR_IDOU			AS      FTR_IDOU	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FTRNS_FM			AS      FTRNS_FM	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FTRNS_TO			AS      FTRNS_TO	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRSV_BUF_FM		AS      FRSV_BUF_FM	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRSV_ARRAY_FM		AS      FRSV_ARRAY_FM	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRSV_BUF_TO		AS      FRSV_BUF_TO	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRSV_ARRAY_TO		AS      FRSV_ARRAY_TO	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FDISP_ADDRESS_FM		AS      FDISP_ADDRESS_FM "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FDISP_ADDRESS_TO		AS      FDISP_ADDRESS_TO "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FDISPLOG_ADDRESS_FM	AS      FDISPLOG_ADDRESS_FM "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FDISPLOG_ADDRESS_TO	AS      FDISPLOG_ADDRESS_TO "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FPALLET_ID		AS      FPALLET_ID	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FBUF_IN_DT		AS      FBUF_IN_DT	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRAC_BUNRUI		AS      FRAC_BUNRUI	 "

            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:N.Dounoshita 2013/04/03  ﾍﾟｱ搬送対応

            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.XTANA_BLOCK		AS      XTANA_BLOCK	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.XTANA_BLOCK_DTL	AS      XTANA_BLOCK_DTL	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.XTANA_BLOCK_STS	AS      XTANA_BLOCK_STS	 "

            '↑↑↑↑↑↑************************************************************************************************************

            strSQL &= vbCrLf & "         FROM"
            strSQL &= vbCrLf & "            TPRG_TRK_BUF"
            strSQL &= vbCrLf & "           ,TMST_CRANE"
            strSQL &= vbCrLf & "           ,TSTS_EQ_CTRL"
            strSQL &= vbCrLf & "         WHERE"
            strSQL &= vbCrLf & "                TPRG_TRK_BUF.FTRK_BUF_NO = " & TO_STRING(mFTRK_BUF_NO)      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
            strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.FPALLET_ID IS NULL"                            'ﾊﾟﾚｯﾄID
            strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.FRES_KIND IN (" & TO_STRING(FRES_KIND_SRSV_TRNS_IN) & _
                                                                        ", " & TO_STRING(FRES_KIND_SRSV_TRNS_OUT) & _
                                                                        ")"                                 '在庫引当状態
            strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.FREMOVE_KIND = " & TO_STRING(FLAG_OFF)         '禁止有無
            strSQL &= vbCrLf & "            AND TMST_CRANE.FTRK_BUF_NO = TPRG_TRK_BUF.FTRK_BUF_NO"          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
            strSQL &= vbCrLf & "            AND TMST_CRANE.FCRANE_ROW1 <= TPRG_TRK_BUF.FRAC_RETU"           '列1
            strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.FRAC_RETU <= TMST_CRANE.FCRANE_ROW2"           '列2
            strSQL &= vbCrLf & "            AND TSTS_EQ_CTRL.FEQ_ID = TMST_CRANE.FEQ_ID"                    '設備ID
            strSQL &= vbCrLf & "            AND TSTS_EQ_CTRL.FEQ_CUT_STS = " & FEQ_CUT_STS_SOFF             '切離有無
            strSQL &= vbCrLf & "            AND TSTS_EQ_CTRL.FEQ_ID = '" & mobjTMST_CRANE.FEQ_ID & "'"      '設備ID
            strSQL &= vbCrLf & "         ORDER BY "
            strSQL &= vbCrLf & "            TPRG_TRK_BUF.FSERCH_NO "        '空検索順No

            strSQL &= vbCrLf


            '***********************
            '抽出
            '***********************
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TPRG_TRK_BUF"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then

                If blnAll = True Then
                    '(全取得の場合)
                    ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
                    For ii As Integer = LBound(mobjAryMe) To UBound(mobjAryMe)
                        objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                        mobjAryMe(ii) = New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                        mobjAryMe(ii).SET_DATA(objRow)
                    Next ii
                Else
                    '(一件取得の場合)
                    objRow = objDataSet.Tables(strDataSetName).Rows(0)
                    Call SET_DATA(objRow)
                End If

                Return (RetCode.OK)
            Else
                Return (RetCode.NotFound)
            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
    '↑↑↑↑↑↑************************************************************************************************************

    '↓↓↓↓↓↓************************************************************************************************************
    'SystemMate:A.Noto 2012/05/07  ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ特定  [入庫中、出庫中、棚間搬送中のﾄﾗｯｷﾝｸﾞを取得][引数:設備ID]
#Region "  ｸﾗｽ変数定義"
    Private mFEQ_ID As String                '設備ID
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義"
    Public Property FEQ_ID() As String
        Get
            Return mFEQ_ID
        End Get
        Set(ByVal Value As String)
            mFEQ_ID = Value
        End Set
    End Property
#End Region
#Region "  ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ特定  [入庫中、出庫中、棚間搬送中のﾄﾗｯｷﾝｸﾞを取得]    [引数:設備ID]                   "
    '''************************************************************************************************************
    ''' <summary>
    ''' ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ特定  [入庫中、出庫中、棚間搬送中のﾄﾗｯｷﾝｸﾞを取得][引数:設備ID]
    ''' </summary>
    ''' <param name="blnAll">全ての棚を取得するか否か</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''************************************************************************************************************
    Public Function GET_TPRG_TRK_BUF_RELAY(Optional ByVal blnAll As Boolean = False) As RetCode
        Try
            Dim intRet As RetCode


            Dim strFBUF_KIND As String = ""
            strFBUF_KIND = TO_STRING(FBUF_KIND_SIN)
            strFBUF_KIND &= ", " & TO_STRING(FBUF_KIND_SOUT)
            strFBUF_KIND &= ", " & TO_STRING(FBUF_KIND_SSOUKO)
            intRet = GET_TPRG_TRK_BUF_OUT_HANSOU_BASE(blnAll, strFBUF_KIND)


            Return intRet
        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''''************************************************************************************************************
    '''' <summary>
    '''' ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ特定  [入庫中、出庫中、棚間搬送中のﾄﾗｯｷﾝｸﾞを取得][引数:設備ID]
    '''' </summary>
    '''' <param name="blnAll">全ての棚を取得するか否か</param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    ''''************************************************************************************************************
    'Public Function GET_TPRG_TRK_BUF_RELAY(Optional ByVal blnAll As Boolean = False) As RetCode
    '    Try
    '        Dim strSQL As String                'SQL文
    '        'Dim strMsg As String                'ﾒｯｾｰｼﾞ
    '        Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
    '        Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
    '        Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のデータ


    '        '***********************
    '        'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
    '        '***********************
    '        'If IsNull(mFTRK_BUF_NO) = True Then
    '        '    strMsg = ERRMSG_ERR_PROPERTY & "[ﾊﾞｯﾌｧNo]"
    '        '    Throw New UserException(strMsg)
    '        'ElseIf IsNull(mFEQ_ID) = True Then
    '        '    strMsg = ERRMSG_ERR_PROPERTY & "[設備ID]"
    '        '    Throw New UserException(strMsg)
    '        'End If


    '        '***********************
    '        '抽出SQL作成
    '        '***********************
    '        strSQL = ""
    '        strSQL &= vbCrLf & "         SELECT "
    '        strSQL &= vbCrLf & "             TPRG_TRK_BUF.FTRK_BUF_NO       AS      FTRK_BUF_NO	 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FTRK_BUF_ARRAY    AS      FTRK_BUF_ARRAY	 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FSERCH_NO         AS      FSERCH_NO	 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FTRNS_ADDRESS     AS      FTRNS_ADDRESS	 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FDISP_ADDRESS     AS      FDISP_ADDRESS	 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRAC_RETU         AS      FRAC_RETU	 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRAC_REN          AS      FRAC_REN	 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRAC_DAN          AS      FRAC_DAN	 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRAC_EDA          AS      FRAC_EDA	 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FREMOVE_KIND      AS      FREMOVE_KIND	 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRAC_FORM         AS      FRAC_FORM	 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRES_KIND			AS      FRES_KIND	 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRSV_PALLET		AS      FRSV_PALLET	 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FTR_FM			AS      FTR_FM		 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FTR_TO			AS      FTR_TO		 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FTR_IDOU			AS      FTR_IDOU	 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FTRNS_FM			AS      FTRNS_FM	 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FTRNS_TO			AS      FTRNS_TO	 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRSV_BUF_FM		AS      FRSV_BUF_FM	 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRSV_ARRAY_FM		AS      FRSV_ARRAY_FM	 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRSV_BUF_TO		AS      FRSV_BUF_TO	 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRSV_ARRAY_TO		AS      FRSV_ARRAY_TO	 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FDISP_ADDRESS_FM		AS      FDISP_ADDRESS_FM "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FDISP_ADDRESS_TO		AS      FDISP_ADDRESS_TO "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FDISPLOG_ADDRESS_FM	AS      FDISPLOG_ADDRESS_FM "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FDISPLOG_ADDRESS_TO	AS      FDISPLOG_ADDRESS_TO "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FPALLET_ID		AS      FPALLET_ID	 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FBUF_IN_DT		AS      FBUF_IN_DT	 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRAC_BUNRUI		AS      FRAC_BUNRUI	 "
    '        strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.XRAC_PRIORITY		AS      XRAC_PRIORITY	 "
    '        strSQL &= vbCrLf & "         FROM"
    '        strSQL &= vbCrLf & "            TPRG_TRK_BUF"
    '        strSQL &= vbCrLf & "           ,TMST_TRK"
    '        strSQL &= vbCrLf & "           ,TPLN_CARRY_QUE"
    '        strSQL &= vbCrLf & "         WHERE"
    '        strSQL &= vbCrLf & "                    1 = 1"
    '        If IsNotNull(mFEQ_ID) Then
    '            strSQL &= vbCrLf & "            AND TPLN_CARRY_QUE.FEQ_ID = '" & TO_STRING(mFEQ_ID) & "'"           '設備ID
    '        End If
    '        strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.FPALLET_ID IS NOT NULL"                                'ﾊﾟﾚｯﾄID
    '        strSQL &= vbCrLf & "            AND TMST_TRK.FBUF_KIND IN (" & TO_STRING(FBUF_KIND_SIN) & _
    '                                                                ", " & TO_STRING(FBUF_KIND_SOUT) & _
    '                                                                ", " & TO_STRING(FBUF_KIND_SSOUKO) & _
    '                                                                ")"                                         'ﾊﾞｯﾌｧ種別
    '        strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.FTRK_BUF_NO = TMST_TRK.FTRK_BUF_NO"                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
    '        strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.FPALLET_ID = TPLN_CARRY_QUE.FPALLET_ID"            'ﾊﾟﾚｯﾄID
    '        strSQL &= vbCrLf & "         ORDER BY "
    '        strSQL &= vbCrLf & "            TPRG_TRK_BUF.FSERCH_NO "                                            '空検索順No
    '        strSQL &= vbCrLf


    '        '***********************
    '        '抽出
    '        '***********************
    '        ObjDb.SQL = strSQL
    '        objDataSet.Clear()
    '        strDataSetName = "TPRG_TRK_BUF"
    '        ObjDb.GetDataSet(strDataSetName, objDataSet)
    '        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then

    '            If blnAll = True Then
    '                '(全取得の場合)
    '                ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
    '                For ii As Integer = LBound(mobjAryMe) To UBound(mobjAryMe)
    '                    objRow = objDataSet.Tables(strDataSetName).Rows(ii)
    '                    mobjAryMe(ii) = New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
    '                    mobjAryMe(ii).SET_DATA(objRow)
    '                Next ii
    '            Else
    '                '(一件取得の場合)
    '                If objDataSet.Tables(strDataSetName).Rows.Count > 1 Then
    '                    '(複数件取得した場合)
    '                    Throw New UserException("複数件レコードを取得しました。")
    '                End If

    '                objRow = objDataSet.Tables(strDataSetName).Rows(0)
    '                Call SET_DATA(objRow)

    '            End If

    '            Return (RetCode.OK)
    '        Else
    '            Return (RetCode.NotFound)
    '        End If

    '    Catch ex As UserException
    '        Throw ex
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function
#End Region
#Region "  ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ特定  [搬出予約、搬入予約のﾄﾗｯｷﾝｸﾞを取得]            [引数:設備ID、引当状態]         "
    '''************************************************************************************************************
    ''' <summary>
    ''' ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ特定  [搬出予約、搬入予約のﾄﾗｯｷﾝｸﾞを取得]            [引数:設備ID、引当状態]
    ''' </summary>
    ''' <param name="blnAll">全ての棚を取得するか否か</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''************************************************************************************************************
    Public Function GET_TPRG_TRK_BUF_ASRS(Optional ByVal blnAll As Boolean = False) As RetCode
        Try

            Dim intRet As RetCode
            intRet = GET_TPRG_TRK_BUF_OUT_HANSOU_BASE(blnAll, FBUF_KIND_SASRS)

            Return intRet
        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "  ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ特定  [搬送中ﾄﾗｯｷﾝｸﾞのﾍﾞｰｽ]                          [引数:設備ID、引当状態]         "
    '''************************************************************************************************************
    ''' <summary>
    ''' ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ特定  [搬送中ﾄﾗｯｷﾝｸﾞのﾍﾞｰｽ]                          [引数:設備ID]
    ''' </summary>
    ''' <param name="blnAll">全ての棚を取得するか否か</param>
    ''' <param name="strFBUF_KIND">ﾊﾞｯﾌｧ種別</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''************************************************************************************************************
    Private Function GET_TPRG_TRK_BUF_OUT_HANSOU_BASE(ByVal blnAll As Boolean _
                                                    , ByVal strFBUF_KIND As String _
                                                      ) As RetCode
        Try
            Dim strSQL As String                'SQL文
            'Dim strMsg As String                'ﾒｯｾｰｼﾞ
            Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
            Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
            Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のデータ


            '***********************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '***********************
            'If IsNull(mFTRK_BUF_NO) = True Then
            '    strMsg = ERRMSG_ERR_PROPERTY & "[ﾊﾞｯﾌｧNo]"
            '    Throw New UserException(strMsg)
            'ElseIf IsNull(mFEQ_ID) = True Then
            '    strMsg = ERRMSG_ERR_PROPERTY & "[設備ID]"
            '    Throw New UserException(strMsg)
            'End If


            '***********************
            '抽出SQL作成
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "         SELECT "
            strSQL &= vbCrLf & "             TPRG_TRK_BUF.FTRK_BUF_NO       AS      FTRK_BUF_NO	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FTRK_BUF_ARRAY    AS      FTRK_BUF_ARRAY	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FSERCH_NO         AS      FSERCH_NO	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FTRNS_ADDRESS     AS      FTRNS_ADDRESS	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FDISP_ADDRESS     AS      FDISP_ADDRESS	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRAC_RETU         AS      FRAC_RETU	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRAC_REN          AS      FRAC_REN	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRAC_DAN          AS      FRAC_DAN	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRAC_EDA          AS      FRAC_EDA	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FREMOVE_KIND      AS      FREMOVE_KIND	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRAC_FORM         AS      FRAC_FORM	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRES_KIND			AS      FRES_KIND	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRSV_PALLET		AS      FRSV_PALLET	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FTR_FM			AS      FTR_FM		 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FTR_TO			AS      FTR_TO		 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FTR_IDOU			AS      FTR_IDOU	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FTRNS_FM			AS      FTRNS_FM	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FTRNS_TO			AS      FTRNS_TO	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRSV_BUF_FM		AS      FRSV_BUF_FM	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRSV_ARRAY_FM		AS      FRSV_ARRAY_FM	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRSV_BUF_TO		AS      FRSV_BUF_TO	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRSV_ARRAY_TO		AS      FRSV_ARRAY_TO	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FDISP_ADDRESS_FM		AS      FDISP_ADDRESS_FM "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FDISP_ADDRESS_TO		AS      FDISP_ADDRESS_TO "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FDISPLOG_ADDRESS_FM	AS      FDISPLOG_ADDRESS_FM "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FDISPLOG_ADDRESS_TO	AS      FDISPLOG_ADDRESS_TO "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FPALLET_ID		AS      FPALLET_ID	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FBUF_IN_DT		AS      FBUF_IN_DT	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.FRAC_BUNRUI		AS      FRAC_BUNRUI	 "
            strSQL &= vbCrLf & "            ,TPRG_TRK_BUF.XRAC_PRIORITY		AS      XRAC_PRIORITY	 "
            strSQL &= vbCrLf & "         FROM"
            strSQL &= vbCrLf & "            TPRG_TRK_BUF"
            strSQL &= vbCrLf & "           ,TMST_TRK"
            strSQL &= vbCrLf & "           ,TPLN_CARRY_QUE"
            strSQL &= vbCrLf & "         WHERE"
            strSQL &= vbCrLf & "                    1 = 1"
            If IsNotNull(mFEQ_ID) Then
                strSQL &= vbCrLf & "            AND TPLN_CARRY_QUE.FEQ_ID = '" & TO_STRING(mFEQ_ID) & "'"           '設備ID
            End If
            If IsNotNull(mFRES_KIND) Then
                strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.FRES_KIND = '" & TO_STRING(mFRES_KIND) & "'"       '引当状態
            End If
            strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.FPALLET_ID IS NOT NULL"                                'ﾊﾟﾚｯﾄID
            strSQL &= vbCrLf & "            AND TMST_TRK.FBUF_KIND IN (" & strFBUF_KIND & ")"                   'ﾊﾞｯﾌｧ種別
            strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.FTRK_BUF_NO = TMST_TRK.FTRK_BUF_NO"                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
            strSQL &= vbCrLf & "            AND TPRG_TRK_BUF.FPALLET_ID = TPLN_CARRY_QUE.FPALLET_ID"            'ﾊﾟﾚｯﾄID
            strSQL &= vbCrLf & "         ORDER BY "
            strSQL &= vbCrLf & "            TPRG_TRK_BUF.FSERCH_NO "                                            '空検索順No
            strSQL &= vbCrLf


            '***********************
            '抽出
            '***********************
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TPRG_TRK_BUF"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then

                If blnAll = True Then
                    '(全取得の場合)
                    ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
                    For ii As Integer = LBound(mobjAryMe) To UBound(mobjAryMe)
                        objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                        mobjAryMe(ii) = New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                        mobjAryMe(ii).SET_DATA(objRow)
                    Next ii
                Else
                    '(一件取得の場合)
                    If objDataSet.Tables(strDataSetName).Rows.Count > 1 Then
                        '(複数件取得した場合)
                        Throw New UserException("複数件レコードを取得しました。")
                    End If

                    objRow = objDataSet.Tables(strDataSetName).Rows(0)
                    Call SET_DATA(objRow)

                End If

                Return (RetCode.OK)
            Else
                Return (RetCode.NotFound)
            End If

        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
    '↑↑↑↑↑↑************************************************************************************************************

    '↓↓↓↓↓↓************************************************************************************************************
    'SystemMate:N.Dounoshita 2012/08/21  搬出予約STの取得
#Region "  ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ特定  [搬出予約ST]             "
    '''************************************************************************************************************
    ''' <summary>
    ''' ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ特定  [搬出予約ST]
    ''' </summary>
    ''' <param name="blnAll">全ての棚を取得するか否か</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''************************************************************************************************************
    Public Function GET_TPRG_TRK_BUF_RESERVE_IN_ST(Optional ByVal blnAll As Boolean = False) As RetCode
        Try
            Dim strSQL As String                'SQL文
            Dim strMsg As String                'ﾒｯｾｰｼﾞ
            Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
            Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
            Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のデータ


            '***********************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '***********************
            If IsNull(mFTRK_BUF_NO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[ﾊﾞｯﾌｧNo]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '抽出SQL作成
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "         SELECT "
            strSQL &= vbCrLf & "            * "
            strSQL &= vbCrLf & "         FROM "
            strSQL &= vbCrLf & "            TPRG_TRK_BUF"
            strSQL &= vbCrLf & "         WHERE"
            strSQL &= vbCrLf & "                FTRK_BUF_NO = " & TO_STRING(mFTRK_BUF_NO)      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
            strSQL &= vbCrLf & "            AND FPALLET_ID IS NULL"                            'ﾊﾟﾚｯﾄID
            strSQL &= vbCrLf & "            AND FRES_KIND IN (" & TO_STRING(FRES_KIND_SRSV_TRNS_IN) & ")"          '在庫引当状態
            strSQL &= vbCrLf & "         ORDER BY "
            strSQL &= vbCrLf & "            FBUF_IN_DT ASC "        'ﾊﾞｯﾌｧ入日時
            strSQL &= vbCrLf


            '***********************
            '抽出
            '***********************
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TPRG_TRK_BUF"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then

                If blnAll = True Then
                    '(全取得の場合)
                    ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
                    For ii As Integer = LBound(mobjAryMe) To UBound(mobjAryMe)
                        objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                        mobjAryMe(ii) = New TBL_TPRG_TRK_BUF(Owner, ObjDb, ObjDbLog)
                        mobjAryMe(ii).SET_DATA(objRow)
                    Next ii
                Else
                    '(一件取得の場合)
                    objRow = objDataSet.Tables(strDataSetName).Rows(0)
                    Call SET_DATA(objRow)
                End If

                Return (RetCode.OK)
            Else
                Return (RetCode.NotFound)
            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
    '↑↑↑↑↑↑************************************************************************************************************

    '↑↑↑ｼｽﾃﾑ共通
    '**********************************************************************************************


    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有

    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:A.Noto 2012/07/03  禁止棚一括設定関数追加
#Region "  ｸﾗｽ変数定義"
    Private mFRAC_RETU_FROM As Integer          '列(FROM)
    Private mFRAC_RETU_TO As Integer            '列(TO)
    Private mFRAC_REN_FROM As Integer           '連(FROM)
    Private mFRAC_REN_TO As Integer             '連(TO)
    Private mFRAC_DAN_FROM As Integer           '段(FROM)
    Private mFRAC_DAN_TO As Integer             '段(TO)
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義"
    Public Property FRAC_RETU_FROM() As Integer
        Get
            Return mFRAC_RETU_FROM
        End Get
        Set(ByVal Value As Integer)
            mFRAC_RETU_FROM = Value
        End Set
    End Property
    Public Property FRAC_RETU_TO() As Integer
        Get
            Return mFRAC_RETU_TO
        End Get
        Set(ByVal Value As Integer)
            mFRAC_RETU_TO = Value
        End Set
    End Property
    Public Property FRAC_REN_FROM() As Integer
        Get
            Return mFRAC_REN_FROM
        End Get
        Set(ByVal Value As Integer)
            mFRAC_REN_FROM = Value
        End Set
    End Property
    Public Property FRAC_REN_TO() As Integer
        Get
            Return mFRAC_REN_TO
        End Get
        Set(ByVal Value As Integer)
            mFRAC_REN_TO = Value
        End Set
    End Property
    Public Property FRAC_DAN_FROM() As Integer
        Get
            Return mFRAC_DAN_FROM
        End Get
        Set(ByVal Value As Integer)
            mFRAC_DAN_FROM = Value
        End Set
    End Property
    Public Property FRAC_DAN_TO() As Integer
        Get
            Return mFRAC_DAN_TO
        End Get
        Set(ByVal Value As Integer)
            mFRAC_DAN_TO = Value
        End Set
    End Property
#End Region
#Region "  禁止棚一括更新 (Public UPDATE_TPRG_TRK_BUF_FREMOVE_KIND)"
    Public Sub UPDATE_TPRG_TRK_BUF_FREMOVE_KIND()
        Try
            Dim strSQL As String                    'SQL文
            Dim intRetSQL As Integer                'SQL実行戻り値
            Dim strMsg As String                    'ﾒｯｾｰｼﾞ

            '***********************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '***********************
            If IsNull(mFREMOVE_KIND) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[禁止有無]"
                Throw New UserException(strMsg)
            End If

            '***********************
            '更新SQL作成
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "UPDATE"
            strSQL &= vbCrLf & "    TPRG_TRK_BUF"                                   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
            strSQL &= vbCrLf & " SET"
            strSQL &= vbCrLf & "    FREMOVE_KIND = " & TO_INTEGER(mFREMOVE_KIND)    '禁止有無
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "    1 = 1 "
            If mFRAC_RETU_FROM <> 0 Then
                strSQL &= vbCrLf & "   AND FRAC_RETU >= " & TO_INTEGER(mFRAC_RETU_FROM)         '列(FROM)
            End If
            If mFRAC_RETU_TO <> 0 Then
                strSQL &= vbCrLf & "   AND FRAC_RETU <= " & TO_INTEGER(mFRAC_RETU_TO)           '列(TO)
            End If
            If mFRAC_REN_FROM <> 0 Then
                strSQL &= vbCrLf & "   AND FRAC_REN >= " & TO_INTEGER(mFRAC_REN_FROM)           '連(FROM)
            End If
            If mFRAC_REN_TO <> 0 Then
                strSQL &= vbCrLf & "   AND FRAC_REN <= " & TO_INTEGER(mFRAC_REN_TO)             '連(TO)
            End If
            If mFRAC_DAN_FROM <> 0 Then
                strSQL &= vbCrLf & "   AND FRAC_DAN >= " & TO_INTEGER(mFRAC_DAN_FROM)           '段(FROM)
            End If
            If mFRAC_DAN_TO <> 0 Then
                strSQL &= vbCrLf & "   AND FRAC_DAN <= " & TO_INTEGER(mFRAC_DAN_TO)             '段(TO)
            End If

            strSQL &= vbCrLf & "   AND FREMOVE_KIND <> " & TO_INTEGER(FREMOVE_KIND_SNON)        '禁止有無(無効棚以外)
            strSQL &= vbCrLf


            '***********************
            '更新
            '***********************
            intRetSQL = ObjDb.Execute(strSQL)
            If intRetSQL = -1 Then
                '(SQLｴﾗｰ)
                strSQL = Replace(strSQL, vbCrLf, "")
                strMsg = ObjDb.ErrMsg & "【" & strSQL & "】"
                strMsg = ERRMSG_ERR_UPDATE & strMsg
                Throw New UserException(strMsg)
            End If


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region


    '↑↑↑↑↑↑************************************************************************************************************

#Region "  ﾄﾗｯｷﾝｸﾞﾁｪｯｸ      [出庫中のﾄﾗｯｷﾝｸﾞがあるか否か]                           [引数:ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№]       "
    Public Function GET_TPRG_TRK_BUF_COUNT_OUT_TRK() As RetCode
        Try
            Dim strSQL As String                'SQL文
            Dim strMsg As String                'ﾒｯｾｰｼﾞ
            Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
            Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
            Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のデータ


            '***********************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '***********************
            If IsNull(mFTRK_BUF_NO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[ﾊﾞｯﾌｧNo]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '抽出SQL作成
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    COUNT(*)"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TPRG_TRK_BUF"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FTRK_BUF_NO = " & TO_STRING(mFTRK_BUF_NO)       'ﾊﾞｯﾌｧNo
            strSQL &= vbCrLf & "    AND FRES_KIND <> " & FRES_KIND_SAKI                 '在庫引当状態
            strSQL &= vbCrLf


            '***********************
            '抽出
            '***********************
            ObjDb.SQL = strSQL.ToString
            objDataSet.Clear()
            strDataSetName = "TPRG_TRK_BUF"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            objRow = objDataSet.Tables(strDataSetName).Rows(0)
            Return (objRow(0))


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "  ﾄﾗｯｷﾝｸﾞﾁｪｯｸ      [何かしらのﾄﾗｯｷﾝｸﾞが存在するか否か]                     "
    Public Function GET_TPRG_TRK_BUF_COUNT_ZAIKO() As RetCode
        Try
            Dim strSQL As String                'SQL文
            Dim strMsg As String                'ﾒｯｾｰｼﾞ
            Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
            Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名
            Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のデータ


            '***********************
            'ﾌﾟﾛﾊﾟﾃｨﾁｪｯｸ
            '***********************
            If IsNull(mFTRK_BUF_NO) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[ﾊﾞｯﾌｧNo]"
                Throw New UserException(strMsg)
            End If


            '***********************
            '抽出SQL作成
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "SELECT"
            strSQL &= vbCrLf & "    COUNT(*)"
            strSQL &= vbCrLf & " FROM"
            strSQL &= vbCrLf & "    TPRG_TRK_BUF"
            strSQL &= vbCrLf & " WHERE"
            strSQL &= vbCrLf & "        FTRK_BUF_NO = " & TO_STRING(mFTRK_BUF_NO)       'ﾊﾞｯﾌｧNo
            strSQL &= vbCrLf & "    AND FRES_KIND <> " & FRES_KIND_SAKI                 '在庫引当状態
            strSQL &= vbCrLf


            '***********************
            '抽出
            '***********************
            ObjDb.SQL = strSQL.ToString
            objDataSet.Clear()
            strDataSetName = "TPRG_TRK_BUF"
            ObjDb.GetDataSet(strDataSetName, objDataSet)
            objRow = objDataSet.Tables(strDataSetName).Rows(0)
            Return (objRow(0))


        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

    '    '棚ﾌﾞﾛｯｸ詳細(Where句で使用する条件)
    '#Region "  ｸﾗｽ変数定義"
    '    Private mstrXTANA_BLOCK_DTL_WhereIn As String       '棚ﾌﾞﾛｯｸ詳細(Where句で使用する条件)
    '#End Region
    '#Region "  ﾌﾟﾛﾊﾟﾃｨ定義"
    '    Public Property strXTANA_BLOCK_DTL_WhereIn() As String
    '        Get
    '            Return mstrXTANA_BLOCK_DTL_WhereIn
    '        End Get
    '        Set(ByVal Value As String)
    '            mstrXTANA_BLOCK_DTL_WhereIn = Value
    '        End Set
    '    End Property
    '#End Region


    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:S.Ouchi 2013/11/08 空棚引当変更
#Region "  入庫中ﾄﾗｯｷﾝｸﾞ取得            (Public GET_TPRG_TRK_BUF_NI_NUM)"
    ''' <summary>
    ''' 入庫中ﾄﾗｯｷﾝｸﾞ取得
    ''' </summary>
    ''' <param name="strFEQ_ID">ｸﾚｰﾝ設備ID</param>
    ''' <param name="strFHENSU_ID">ｸﾚｰﾝ優先順 変数ID</param>
    ''' <returns>入庫中件数</returns>
    ''' <remarks></remarks>
    Public Function GET_TPRG_TRK_BUF_NI_NUM(ByVal strFEQ_ID As String, ByVal strFHENSU_ID As String) As Integer
        Try
            Dim strSQL As String                'SQL文
            Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
            Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名

            '***********************
            '抽出SQL作成
            '***********************
            strSQL = ""
            strSQL &= vbCrLf & "         SELECT "
            strSQL &= vbCrLf & "            BB.FTRK_BUF_NO "
            strSQL &= vbCrLf & "           ,BB.FTRK_BUF_ARRAY "
            strSQL &= vbCrLf & "           ,BB.FPALLET_ID "
            strSQL &= vbCrLf & "         FROM"
            strSQL &= vbCrLf & "            TPRG_TRK_BUF AA"
            strSQL &= vbCrLf & "           ,TPRG_TRK_BUF BB"
            strSQL &= vbCrLf & "           ,TMST_CRANE"
            strSQL &= vbCrLf & "         WHERE"
            strSQL &= vbCrLf & "                TMST_CRANE.FEQ_ID = '" & strFEQ_ID & "'"                        'ｸﾚｰﾝ設備ID
            strSQL &= vbCrLf & "            AND TMST_CRANE.FTRK_BUF_NO = AA.FTRK_BUF_NO"                        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
            strSQL &= vbCrLf & "            AND TMST_CRANE.FCRANE_ROW1 <= AA.FRAC_RETU"                         '列1
            strSQL &= vbCrLf & "            AND AA.FRAC_RETU <= TMST_CRANE.FCRANE_ROW2"                         '列2
            strSQL &= vbCrLf & "            AND AA.FTRK_BUF_NO = " & TO_STRING(FTRK_BUF_NO_J9000)               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo(自動倉庫)
            strSQL &= vbCrLf & "            AND AA.FRSV_PALLET IS NOT NULL"                                     '仮引当ﾊﾟﾚｯﾄID
            strSQL &= vbCrLf & "            AND AA.FRSV_PALLET = BB.FPALLET_ID"                                 'ﾊﾟﾚｯﾄID

            If strFHENSU_ID = FHENSU_ID_SSJ000000_051 Then
                strSQL &= vbCrLf & "            AND ((1000 <= BB.FTRK_BUF_NO AND BB.FTRK_BUF_NO <= 1999)"       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo(1F入庫CV)
                strSQL &= vbCrLf & "              OR (4000 <= BB.FTRK_BUF_NO AND BB.FTRK_BUF_NO <= 4999)"       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo(1F入庫CV待ち)
                strSQL &= vbCrLf & "              OR BB.FTRK_BUF_NO = " & TO_STRING(FTRK_BUF_NO_J3301)          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo(1F入庫搬送中)
                strSQL &= vbCrLf & "              OR BB.FTRK_BUF_NO = " & TO_STRING(FTRK_BUF_NO_J3101) & ")"    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo(1F入庫中)
            Else
                strSQL &= vbCrLf & "            AND ((2000 <= BB.FTRK_BUF_NO AND BB.FTRK_BUF_NO <= 2999)"       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo(2F入庫CV)
                strSQL &= vbCrLf & "              OR (5000 <= BB.FTRK_BUF_NO AND BB.FTRK_BUF_NO <= 5999)"       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo(2F入庫CV待ち)
                strSQL &= vbCrLf & "              OR BB.FTRK_BUF_NO = " & TO_STRING(FTRK_BUF_NO_J3302)          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo(2F入庫搬送中)
                strSQL &= vbCrLf & "              OR BB.FTRK_BUF_NO = " & TO_STRING(FTRK_BUF_NO_J3102) & ")"    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo(2F入庫中)
            End If

            strSQL &= vbCrLf & "         ORDER BY "
            strSQL &= vbCrLf & "            BB.FTRK_BUF_NO "
            strSQL &= vbCrLf & "           ,BB.FTRK_BUF_ARRAY "

            strSQL &= vbCrLf


            '***********************
            '抽出
            '***********************
            ObjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "TPRG_TRK_BUF"
            ObjDb.GetDataSet(strDataSetName, objDataSet)

            Return objDataSet.Tables(strDataSetName).Rows.Count

        Catch ex As UserException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
    'JobMate:S.Ouchi 2013/11/08 空棚引当変更
    '↑↑↑↑↑↑************************************************************************************************************


    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
