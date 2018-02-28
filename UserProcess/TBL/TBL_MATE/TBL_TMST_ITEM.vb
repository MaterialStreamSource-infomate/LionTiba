'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' 【名称】MaterialStreamﾃｰﾌﾞﾙｸﾗｽ
' 【機能】品目ﾏｽﾀﾃｰﾌﾞﾙｸﾗｽ
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
''' 品目ﾏｽﾀﾃｰﾌﾞﾙｸﾗｽ
''' </summary>
Public Class TBL_TMST_ITEM
    Inherits clsTemplateTable

    '**********************************************************************************************
    '↓↓↓自動生成部
#Region "  ｸﾗｽ変数定義                  "
    'ﾌﾟﾛﾊﾟﾃｨ
    Private mobjAryMe As TBL_TMST_ITEM()                                         '品目ﾏｽﾀ
    Private mstrUSER_SQL As String                                               'ﾕｰｻﾞｰSQL
    Private mORDER_BY As String                                                  'OrderBy句
    Private mWHERE As String                                                     'Where句
    Private mFHINMEI_CD As String                                                '品目ｺｰﾄﾞ
    Private mFHINMEI As String                                                   '品名_正式名
    Private mFTANI As String                                                     '単位ｺｰﾄﾞ
    Private mFDECIMAL_POINT As Nullable(Of Integer)                              '小数点以下有効桁数
    Private mFNUM_IN_CASE As Nullable(Of Decimal)                                '正袋数量
    Private mFZAIKO_KUBUN As Nullable(Of Integer)                                '在庫区分
    Private mFSHIKEN_YOUHI As Nullable(Of Integer)                               '受入試験有無
    Private mFSHIKEN_TIMELIMIT As Nullable(Of Integer)                           '試験有効期限
    Private mFSHIKEN_READTIME As Nullable(Of Integer)                            '試験ﾘｰﾄﾞﾀｲﾑ
    Private mFRITEST_TIMELIMIT As Nullable(Of Integer)                           'ﾘﾃｽﾄ期間
    Private mFRITEST_FLAG As Nullable(Of Integer)                                'ﾘﾃｽﾄ対象品ﾌﾗｸﾞ
    Private mFNUM_IN_PALLET As Nullable(Of Decimal)                              'PL毎積載数
    Private mFINVENTORY_FLAG As Nullable(Of Integer)                             '棚卸し対象ﾌﾗｸﾞ
    Private mFSYSTEM_FLAG As Nullable(Of Integer)                                'ｼｽﾃﾑ対象ﾌﾗｸﾞ
    Private mFHASU_MATOME As Nullable(Of Integer)                                '端数まとめﾌﾗｸﾞ
    Private mFDISP_ADDRESS As String                                             '表記用ｱﾄﾞﾚｽ
    Private mFHINMEI_KIKAKU As String                                            '品目_規格容量
    Private mFRAC_FORM As Nullable(Of Integer)                                   '棚形状種別
    Private mFENTRY_TERM_ID As String                                            '登録端末ID
    Private mFENTRY_DT As Nullable(Of Date)                                      '登録日時
    Private mFENTRY_USER_ID As String                                            '登録ﾕｰｻﾞｰID
    Private mFENTRY_USER_NAME As String                                          '登録ﾕｰｻﾞｰ名
    Private mFUPDATE_TERM_ID As String                                           '更新端末ID
    Private mFUPDATE_USER_ID As String                                           '更新ﾕｰｻﾞｰID
    Private mFUPDATE_USER_NAME As String                                         '更新ﾕｰｻﾞｰ名
    Private mFUPDATE_DT As Nullable(Of Date)                                     '更新日時
    Private mXABC_KANRI As Nullable(Of Integer)                                  'ABC管理
    Private mXPLANE_PACK_NUMBER As Nullable(Of Integer)                          '平面梱数
    Private mXWEIGHT_IN_CASE As Nullable(Of Decimal)                             '梱重量
    Private mXWEIGHT_IN_PALLET As Nullable(Of Decimal)                           'ﾊﾟﾚｯﾄあたりの重量
    Private mXHEIGHT_IN_CASE As Nullable(Of Integer)                             '梱高さ
    Private mXHEIGHT_IN_PALLET As Nullable(Of Integer)                           'ﾊﾟﾚｯﾄ高さ
    Private mXARTICLE_TYPE_CODE As Nullable(Of Integer)                          '品目種別(商品区分)
    Private mX24H_KENSA_AUTO_FLG As Nullable(Of Integer)                         '24H検査結果自動指定
    Private mXHINMEI_CD As String                                                '品目ｺｰﾄﾞ(正式品目ｺｰﾄﾞ)
    Private mXSUB_CD As Nullable(Of Integer)                                     'ｻﾌﾞｺｰﾄﾞ
    Private mXITF_CD As String                                                   'ITFｺｰﾄﾞ
    Private mXJAN_CD As String                                                   'JANｺｰﾄﾞ
    Private mXMAKER_CD As String                                                 'ﾒｰｶ-ｺｰﾄﾞ
    Private mFRAC_BUNRUI As String                                               '棚分類
    Private mXDAN_IN_PALLET As Nullable(Of Integer)                              '1ﾊﾟﾚｯﾄの段数
    Private mXIN_RES_TYPE As Nullable(Of Integer)                                '品目別空棚引当ﾀｲﾌﾟ
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                  "
    ''' <summary>
    ''' ｼｽﾃﾑ変数 (自ｸﾗｽ型配列)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_TMST_ITEM()
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
    ''' 受入試験有無
    ''' </summary>
    Public Property FSHIKEN_YOUHI() As Nullable(Of Integer)
        Get
            Return mFSHIKEN_YOUHI
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFSHIKEN_YOUHI = Value
        End Set
    End Property
    ''' <summary>
    ''' 試験有効期限
    ''' </summary>
    Public Property FSHIKEN_TIMELIMIT() As Nullable(Of Integer)
        Get
            Return mFSHIKEN_TIMELIMIT
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFSHIKEN_TIMELIMIT = Value
        End Set
    End Property
    ''' <summary>
    ''' 試験ﾘｰﾄﾞﾀｲﾑ
    ''' </summary>
    Public Property FSHIKEN_READTIME() As Nullable(Of Integer)
        Get
            Return mFSHIKEN_READTIME
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFSHIKEN_READTIME = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾘﾃｽﾄ期間
    ''' </summary>
    Public Property FRITEST_TIMELIMIT() As Nullable(Of Integer)
        Get
            Return mFRITEST_TIMELIMIT
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRITEST_TIMELIMIT = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾘﾃｽﾄ対象品ﾌﾗｸﾞ
    ''' </summary>
    Public Property FRITEST_FLAG() As Nullable(Of Integer)
        Get
            Return mFRITEST_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRITEST_FLAG = Value
        End Set
    End Property
    ''' <summary>
    ''' PL毎積載数
    ''' </summary>
    Public Property FNUM_IN_PALLET() As Nullable(Of Decimal)
        Get
            Return mFNUM_IN_PALLET
        End Get
        Set(ByVal Value As Nullable(Of Decimal))
            mFNUM_IN_PALLET = Value
        End Set
    End Property
    ''' <summary>
    ''' 棚卸し対象ﾌﾗｸﾞ
    ''' </summary>
    Public Property FINVENTORY_FLAG() As Nullable(Of Integer)
        Get
            Return mFINVENTORY_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFINVENTORY_FLAG = Value
        End Set
    End Property
    ''' <summary>
    ''' ｼｽﾃﾑ対象ﾌﾗｸﾞ
    ''' </summary>
    Public Property FSYSTEM_FLAG() As Nullable(Of Integer)
        Get
            Return mFSYSTEM_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFSYSTEM_FLAG = Value
        End Set
    End Property
    ''' <summary>
    ''' 端数まとめﾌﾗｸﾞ
    ''' </summary>
    Public Property FHASU_MATOME() As Nullable(Of Integer)
        Get
            Return mFHASU_MATOME
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFHASU_MATOME = Value
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
    ''' 品目_規格容量
    ''' </summary>
    Public Property FHINMEI_KIKAKU() As String
        Get
            Return mFHINMEI_KIKAKU
        End Get
        Set(ByVal Value As String)
            mFHINMEI_KIKAKU = Value
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
    ''' 登録端末ID
    ''' </summary>
    Public Property FENTRY_TERM_ID() As String
        Get
            Return mFENTRY_TERM_ID
        End Get
        Set(ByVal Value As String)
            mFENTRY_TERM_ID = Value
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
    ''' 登録ﾕｰｻﾞｰID
    ''' </summary>
    Public Property FENTRY_USER_ID() As String
        Get
            Return mFENTRY_USER_ID
        End Get
        Set(ByVal Value As String)
            mFENTRY_USER_ID = Value
        End Set
    End Property
    ''' <summary>
    ''' 登録ﾕｰｻﾞｰ名
    ''' </summary>
    Public Property FENTRY_USER_NAME() As String
        Get
            Return mFENTRY_USER_NAME
        End Get
        Set(ByVal Value As String)
            mFENTRY_USER_NAME = Value
        End Set
    End Property
    ''' <summary>
    ''' 更新端末ID
    ''' </summary>
    Public Property FUPDATE_TERM_ID() As String
        Get
            Return mFUPDATE_TERM_ID
        End Get
        Set(ByVal Value As String)
            mFUPDATE_TERM_ID = Value
        End Set
    End Property
    ''' <summary>
    ''' 更新ﾕｰｻﾞｰID
    ''' </summary>
    Public Property FUPDATE_USER_ID() As String
        Get
            Return mFUPDATE_USER_ID
        End Get
        Set(ByVal Value As String)
            mFUPDATE_USER_ID = Value
        End Set
    End Property
    ''' <summary>
    ''' 更新ﾕｰｻﾞｰ名
    ''' </summary>
    Public Property FUPDATE_USER_NAME() As String
        Get
            Return mFUPDATE_USER_NAME
        End Get
        Set(ByVal Value As String)
            mFUPDATE_USER_NAME = Value
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
    ''' ABC管理
    ''' </summary>
    Public Property XABC_KANRI() As Nullable(Of Integer)
        Get
            Return mXABC_KANRI
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXABC_KANRI = Value
        End Set
    End Property
    ''' <summary>
    ''' 平面梱数
    ''' </summary>
    Public Property XPLANE_PACK_NUMBER() As Nullable(Of Integer)
        Get
            Return mXPLANE_PACK_NUMBER
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXPLANE_PACK_NUMBER = Value
        End Set
    End Property
    ''' <summary>
    ''' 梱重量
    ''' </summary>
    Public Property XWEIGHT_IN_CASE() As Nullable(Of Decimal)
        Get
            Return mXWEIGHT_IN_CASE
        End Get
        Set(ByVal Value As Nullable(Of Decimal))
            mXWEIGHT_IN_CASE = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾊﾟﾚｯﾄあたりの重量
    ''' </summary>
    Public Property XWEIGHT_IN_PALLET() As Nullable(Of Decimal)
        Get
            Return mXWEIGHT_IN_PALLET
        End Get
        Set(ByVal Value As Nullable(Of Decimal))
            mXWEIGHT_IN_PALLET = Value
        End Set
    End Property
    ''' <summary>
    ''' 梱高さ
    ''' </summary>
    Public Property XHEIGHT_IN_CASE() As Nullable(Of Integer)
        Get
            Return mXHEIGHT_IN_CASE
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXHEIGHT_IN_CASE = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾊﾟﾚｯﾄ高さ
    ''' </summary>
    Public Property XHEIGHT_IN_PALLET() As Nullable(Of Integer)
        Get
            Return mXHEIGHT_IN_PALLET
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXHEIGHT_IN_PALLET = Value
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
    ''' 24H検査結果自動指定
    ''' </summary>
    Public Property X24H_KENSA_AUTO_FLG() As Nullable(Of Integer)
        Get
            Return mX24H_KENSA_AUTO_FLG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mX24H_KENSA_AUTO_FLG = Value
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
    ''' ｻﾌﾞｺｰﾄﾞ
    ''' </summary>
    Public Property XSUB_CD() As Nullable(Of Integer)
        Get
            Return mXSUB_CD
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXSUB_CD = Value
        End Set
    End Property
    ''' <summary>
    ''' ITFｺｰﾄﾞ
    ''' </summary>
    Public Property XITF_CD() As String
        Get
            Return mXITF_CD
        End Get
        Set(ByVal Value As String)
            mXITF_CD = Value
        End Set
    End Property
    ''' <summary>
    ''' JANｺｰﾄﾞ
    ''' </summary>
    Public Property XJAN_CD() As String
        Get
            Return mXJAN_CD
        End Get
        Set(ByVal Value As String)
            mXJAN_CD = Value
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
    ''' 1ﾊﾟﾚｯﾄの段数
    ''' </summary>
    Public Property XDAN_IN_PALLET() As Nullable(Of Integer)
        Get
            Return mXDAN_IN_PALLET
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXDAN_IN_PALLET = Value
        End Set
    End Property
    ''' <summary>
    ''' 品目別空棚引当ﾀｲﾌﾟ
    ''' </summary>
    Public Property XIN_RES_TYPE() As Nullable(Of Integer)
        Get
            Return mXIN_RES_TYPE
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXIN_RES_TYPE = Value
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
    Public Function GET_TMST_ITEM(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    TMST_ITEM")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
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
        If IsNull(FNUM_IN_CASE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFNUM_IN_CASE
            strSQL.Append(vbCrLf & "    AND FNUM_IN_CASE = :" & UBound(strBindField) - 1 & " --正袋数量")
        End If
        If IsNull(FZAIKO_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_KUBUN
            strSQL.Append(vbCrLf & "    AND FZAIKO_KUBUN = :" & UBound(strBindField) - 1 & " --在庫区分")
        End If
        If IsNull(FSHIKEN_YOUHI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSHIKEN_YOUHI
            strSQL.Append(vbCrLf & "    AND FSHIKEN_YOUHI = :" & UBound(strBindField) - 1 & " --受入試験有無")
        End If
        If IsNull(FSHIKEN_TIMELIMIT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSHIKEN_TIMELIMIT
            strSQL.Append(vbCrLf & "    AND FSHIKEN_TIMELIMIT = :" & UBound(strBindField) - 1 & " --試験有効期限")
        End If
        If IsNull(FSHIKEN_READTIME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSHIKEN_READTIME
            strSQL.Append(vbCrLf & "    AND FSHIKEN_READTIME = :" & UBound(strBindField) - 1 & " --試験ﾘｰﾄﾞﾀｲﾑ")
        End If
        If IsNull(FRITEST_TIMELIMIT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRITEST_TIMELIMIT
            strSQL.Append(vbCrLf & "    AND FRITEST_TIMELIMIT = :" & UBound(strBindField) - 1 & " --ﾘﾃｽﾄ期間")
        End If
        If IsNull(FRITEST_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRITEST_FLAG
            strSQL.Append(vbCrLf & "    AND FRITEST_FLAG = :" & UBound(strBindField) - 1 & " --ﾘﾃｽﾄ対象品ﾌﾗｸﾞ")
        End If
        If IsNull(FNUM_IN_PALLET) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFNUM_IN_PALLET
            strSQL.Append(vbCrLf & "    AND FNUM_IN_PALLET = :" & UBound(strBindField) - 1 & " --PL毎積載数")
        End If
        If IsNull(FINVENTORY_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINVENTORY_FLAG
            strSQL.Append(vbCrLf & "    AND FINVENTORY_FLAG = :" & UBound(strBindField) - 1 & " --棚卸し対象ﾌﾗｸﾞ")
        End If
        If IsNull(FSYSTEM_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYSTEM_FLAG
            strSQL.Append(vbCrLf & "    AND FSYSTEM_FLAG = :" & UBound(strBindField) - 1 & " --ｼｽﾃﾑ対象ﾌﾗｸﾞ")
        End If
        If IsNull(FHASU_MATOME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHASU_MATOME
            strSQL.Append(vbCrLf & "    AND FHASU_MATOME = :" & UBound(strBindField) - 1 & " --端数まとめﾌﾗｸﾞ")
        End If
        If IsNull(FDISP_ADDRESS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS
            strSQL.Append(vbCrLf & "    AND FDISP_ADDRESS = :" & UBound(strBindField) - 1 & " --表記用ｱﾄﾞﾚｽ")
        End If
        If IsNull(FHINMEI_KIKAKU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_KIKAKU
            strSQL.Append(vbCrLf & "    AND FHINMEI_KIKAKU = :" & UBound(strBindField) - 1 & " --品目_規格容量")
        End If
        If IsNull(FRAC_FORM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_FORM
            strSQL.Append(vbCrLf & "    AND FRAC_FORM = :" & UBound(strBindField) - 1 & " --棚形状種別")
        End If
        If IsNull(FENTRY_TERM_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_TERM_ID
            strSQL.Append(vbCrLf & "    AND FENTRY_TERM_ID = :" & UBound(strBindField) - 1 & " --登録端末ID")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --登録日時")
        End If
        If IsNull(FENTRY_USER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_USER_ID
            strSQL.Append(vbCrLf & "    AND FENTRY_USER_ID = :" & UBound(strBindField) - 1 & " --登録ﾕｰｻﾞｰID")
        End If
        If IsNull(FENTRY_USER_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_USER_NAME
            strSQL.Append(vbCrLf & "    AND FENTRY_USER_NAME = :" & UBound(strBindField) - 1 & " --登録ﾕｰｻﾞｰ名")
        End If
        If IsNull(FUPDATE_TERM_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_TERM_ID
            strSQL.Append(vbCrLf & "    AND FUPDATE_TERM_ID = :" & UBound(strBindField) - 1 & " --更新端末ID")
        End If
        If IsNull(FUPDATE_USER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_USER_ID
            strSQL.Append(vbCrLf & "    AND FUPDATE_USER_ID = :" & UBound(strBindField) - 1 & " --更新ﾕｰｻﾞｰID")
        End If
        If IsNull(FUPDATE_USER_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_USER_NAME
            strSQL.Append(vbCrLf & "    AND FUPDATE_USER_NAME = :" & UBound(strBindField) - 1 & " --更新ﾕｰｻﾞｰ名")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --更新日時")
        End If
        If IsNull(XABC_KANRI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXABC_KANRI
            strSQL.Append(vbCrLf & "    AND XABC_KANRI = :" & UBound(strBindField) - 1 & " --ABC管理")
        End If
        If IsNull(XPLANE_PACK_NUMBER) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPLANE_PACK_NUMBER
            strSQL.Append(vbCrLf & "    AND XPLANE_PACK_NUMBER = :" & UBound(strBindField) - 1 & " --平面梱数")
        End If
        If IsNull(XWEIGHT_IN_CASE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXWEIGHT_IN_CASE
            strSQL.Append(vbCrLf & "    AND XWEIGHT_IN_CASE = :" & UBound(strBindField) - 1 & " --梱重量")
        End If
        If IsNull(XWEIGHT_IN_PALLET) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXWEIGHT_IN_PALLET
            strSQL.Append(vbCrLf & "    AND XWEIGHT_IN_PALLET = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄあたりの重量")
        End If
        If IsNull(XHEIGHT_IN_CASE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHEIGHT_IN_CASE
            strSQL.Append(vbCrLf & "    AND XHEIGHT_IN_CASE = :" & UBound(strBindField) - 1 & " --梱高さ")
        End If
        If IsNull(XHEIGHT_IN_PALLET) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHEIGHT_IN_PALLET
            strSQL.Append(vbCrLf & "    AND XHEIGHT_IN_PALLET = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄ高さ")
        End If
        If IsNull(XARTICLE_TYPE_CODE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXARTICLE_TYPE_CODE
            strSQL.Append(vbCrLf & "    AND XARTICLE_TYPE_CODE = :" & UBound(strBindField) - 1 & " --品目種別(商品区分)")
        End If
        If IsNull(X24H_KENSA_AUTO_FLG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mX24H_KENSA_AUTO_FLG
            strSQL.Append(vbCrLf & "    AND X24H_KENSA_AUTO_FLG = :" & UBound(strBindField) - 1 & " --24H検査結果自動指定")
        End If
        If IsNull(XHINMEI_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHINMEI_CD
            strSQL.Append(vbCrLf & "    AND XHINMEI_CD = :" & UBound(strBindField) - 1 & " --品目ｺｰﾄﾞ(正式品目ｺｰﾄﾞ)")
        End If
        If IsNull(XSUB_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSUB_CD
            strSQL.Append(vbCrLf & "    AND XSUB_CD = :" & UBound(strBindField) - 1 & " --ｻﾌﾞｺｰﾄﾞ")
        End If
        If IsNull(XITF_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXITF_CD
            strSQL.Append(vbCrLf & "    AND XITF_CD = :" & UBound(strBindField) - 1 & " --ITFｺｰﾄﾞ")
        End If
        If IsNull(XJAN_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXJAN_CD
            strSQL.Append(vbCrLf & "    AND XJAN_CD = :" & UBound(strBindField) - 1 & " --JANｺｰﾄﾞ")
        End If
        If IsNull(XMAKER_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAKER_CD
            strSQL.Append(vbCrLf & "    AND XMAKER_CD = :" & UBound(strBindField) - 1 & " --ﾒｰｶ-ｺｰﾄﾞ")
        End If
        If IsNull(FRAC_BUNRUI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_BUNRUI
            strSQL.Append(vbCrLf & "    AND FRAC_BUNRUI = :" & UBound(strBindField) - 1 & " --棚分類")
        End If
        If IsNull(XDAN_IN_PALLET) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDAN_IN_PALLET
            strSQL.Append(vbCrLf & "    AND XDAN_IN_PALLET = :" & UBound(strBindField) - 1 & " --1ﾊﾟﾚｯﾄの段数")
        End If
        If IsNull(XIN_RES_TYPE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIN_RES_TYPE
            strSQL.Append(vbCrLf & "    AND XIN_RES_TYPE = :" & UBound(strBindField) - 1 & " --品目別空棚引当ﾀｲﾌﾟ")
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
        strDataSetName = "TMST_ITEM"
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
    Public Function GET_TMST_ITEM_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    TMST_ITEM")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
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
        If IsNull(FNUM_IN_CASE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFNUM_IN_CASE
            strSQL.Append(vbCrLf & "    AND FNUM_IN_CASE = :" & UBound(strBindField) - 1 & " --正袋数量")
        End If
        If IsNull(FZAIKO_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_KUBUN
            strSQL.Append(vbCrLf & "    AND FZAIKO_KUBUN = :" & UBound(strBindField) - 1 & " --在庫区分")
        End If
        If IsNull(FSHIKEN_YOUHI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSHIKEN_YOUHI
            strSQL.Append(vbCrLf & "    AND FSHIKEN_YOUHI = :" & UBound(strBindField) - 1 & " --受入試験有無")
        End If
        If IsNull(FSHIKEN_TIMELIMIT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSHIKEN_TIMELIMIT
            strSQL.Append(vbCrLf & "    AND FSHIKEN_TIMELIMIT = :" & UBound(strBindField) - 1 & " --試験有効期限")
        End If
        If IsNull(FSHIKEN_READTIME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSHIKEN_READTIME
            strSQL.Append(vbCrLf & "    AND FSHIKEN_READTIME = :" & UBound(strBindField) - 1 & " --試験ﾘｰﾄﾞﾀｲﾑ")
        End If
        If IsNull(FRITEST_TIMELIMIT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRITEST_TIMELIMIT
            strSQL.Append(vbCrLf & "    AND FRITEST_TIMELIMIT = :" & UBound(strBindField) - 1 & " --ﾘﾃｽﾄ期間")
        End If
        If IsNull(FRITEST_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRITEST_FLAG
            strSQL.Append(vbCrLf & "    AND FRITEST_FLAG = :" & UBound(strBindField) - 1 & " --ﾘﾃｽﾄ対象品ﾌﾗｸﾞ")
        End If
        If IsNull(FNUM_IN_PALLET) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFNUM_IN_PALLET
            strSQL.Append(vbCrLf & "    AND FNUM_IN_PALLET = :" & UBound(strBindField) - 1 & " --PL毎積載数")
        End If
        If IsNull(FINVENTORY_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINVENTORY_FLAG
            strSQL.Append(vbCrLf & "    AND FINVENTORY_FLAG = :" & UBound(strBindField) - 1 & " --棚卸し対象ﾌﾗｸﾞ")
        End If
        If IsNull(FSYSTEM_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYSTEM_FLAG
            strSQL.Append(vbCrLf & "    AND FSYSTEM_FLAG = :" & UBound(strBindField) - 1 & " --ｼｽﾃﾑ対象ﾌﾗｸﾞ")
        End If
        If IsNull(FHASU_MATOME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHASU_MATOME
            strSQL.Append(vbCrLf & "    AND FHASU_MATOME = :" & UBound(strBindField) - 1 & " --端数まとめﾌﾗｸﾞ")
        End If
        If IsNull(FDISP_ADDRESS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS
            strSQL.Append(vbCrLf & "    AND FDISP_ADDRESS = :" & UBound(strBindField) - 1 & " --表記用ｱﾄﾞﾚｽ")
        End If
        If IsNull(FHINMEI_KIKAKU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_KIKAKU
            strSQL.Append(vbCrLf & "    AND FHINMEI_KIKAKU = :" & UBound(strBindField) - 1 & " --品目_規格容量")
        End If
        If IsNull(FRAC_FORM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_FORM
            strSQL.Append(vbCrLf & "    AND FRAC_FORM = :" & UBound(strBindField) - 1 & " --棚形状種別")
        End If
        If IsNull(FENTRY_TERM_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_TERM_ID
            strSQL.Append(vbCrLf & "    AND FENTRY_TERM_ID = :" & UBound(strBindField) - 1 & " --登録端末ID")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --登録日時")
        End If
        If IsNull(FENTRY_USER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_USER_ID
            strSQL.Append(vbCrLf & "    AND FENTRY_USER_ID = :" & UBound(strBindField) - 1 & " --登録ﾕｰｻﾞｰID")
        End If
        If IsNull(FENTRY_USER_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_USER_NAME
            strSQL.Append(vbCrLf & "    AND FENTRY_USER_NAME = :" & UBound(strBindField) - 1 & " --登録ﾕｰｻﾞｰ名")
        End If
        If IsNull(FUPDATE_TERM_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_TERM_ID
            strSQL.Append(vbCrLf & "    AND FUPDATE_TERM_ID = :" & UBound(strBindField) - 1 & " --更新端末ID")
        End If
        If IsNull(FUPDATE_USER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_USER_ID
            strSQL.Append(vbCrLf & "    AND FUPDATE_USER_ID = :" & UBound(strBindField) - 1 & " --更新ﾕｰｻﾞｰID")
        End If
        If IsNull(FUPDATE_USER_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_USER_NAME
            strSQL.Append(vbCrLf & "    AND FUPDATE_USER_NAME = :" & UBound(strBindField) - 1 & " --更新ﾕｰｻﾞｰ名")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --更新日時")
        End If
        If IsNull(XABC_KANRI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXABC_KANRI
            strSQL.Append(vbCrLf & "    AND XABC_KANRI = :" & UBound(strBindField) - 1 & " --ABC管理")
        End If
        If IsNull(XPLANE_PACK_NUMBER) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPLANE_PACK_NUMBER
            strSQL.Append(vbCrLf & "    AND XPLANE_PACK_NUMBER = :" & UBound(strBindField) - 1 & " --平面梱数")
        End If
        If IsNull(XWEIGHT_IN_CASE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXWEIGHT_IN_CASE
            strSQL.Append(vbCrLf & "    AND XWEIGHT_IN_CASE = :" & UBound(strBindField) - 1 & " --梱重量")
        End If
        If IsNull(XWEIGHT_IN_PALLET) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXWEIGHT_IN_PALLET
            strSQL.Append(vbCrLf & "    AND XWEIGHT_IN_PALLET = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄあたりの重量")
        End If
        If IsNull(XHEIGHT_IN_CASE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHEIGHT_IN_CASE
            strSQL.Append(vbCrLf & "    AND XHEIGHT_IN_CASE = :" & UBound(strBindField) - 1 & " --梱高さ")
        End If
        If IsNull(XHEIGHT_IN_PALLET) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHEIGHT_IN_PALLET
            strSQL.Append(vbCrLf & "    AND XHEIGHT_IN_PALLET = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄ高さ")
        End If
        If IsNull(XARTICLE_TYPE_CODE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXARTICLE_TYPE_CODE
            strSQL.Append(vbCrLf & "    AND XARTICLE_TYPE_CODE = :" & UBound(strBindField) - 1 & " --品目種別(商品区分)")
        End If
        If IsNull(X24H_KENSA_AUTO_FLG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mX24H_KENSA_AUTO_FLG
            strSQL.Append(vbCrLf & "    AND X24H_KENSA_AUTO_FLG = :" & UBound(strBindField) - 1 & " --24H検査結果自動指定")
        End If
        If IsNull(XHINMEI_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHINMEI_CD
            strSQL.Append(vbCrLf & "    AND XHINMEI_CD = :" & UBound(strBindField) - 1 & " --品目ｺｰﾄﾞ(正式品目ｺｰﾄﾞ)")
        End If
        If IsNull(XSUB_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSUB_CD
            strSQL.Append(vbCrLf & "    AND XSUB_CD = :" & UBound(strBindField) - 1 & " --ｻﾌﾞｺｰﾄﾞ")
        End If
        If IsNull(XITF_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXITF_CD
            strSQL.Append(vbCrLf & "    AND XITF_CD = :" & UBound(strBindField) - 1 & " --ITFｺｰﾄﾞ")
        End If
        If IsNull(XJAN_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXJAN_CD
            strSQL.Append(vbCrLf & "    AND XJAN_CD = :" & UBound(strBindField) - 1 & " --JANｺｰﾄﾞ")
        End If
        If IsNull(XMAKER_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAKER_CD
            strSQL.Append(vbCrLf & "    AND XMAKER_CD = :" & UBound(strBindField) - 1 & " --ﾒｰｶ-ｺｰﾄﾞ")
        End If
        If IsNull(FRAC_BUNRUI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_BUNRUI
            strSQL.Append(vbCrLf & "    AND FRAC_BUNRUI = :" & UBound(strBindField) - 1 & " --棚分類")
        End If
        If IsNull(XDAN_IN_PALLET) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDAN_IN_PALLET
            strSQL.Append(vbCrLf & "    AND XDAN_IN_PALLET = :" & UBound(strBindField) - 1 & " --1ﾊﾟﾚｯﾄの段数")
        End If
        If IsNull(XIN_RES_TYPE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIN_RES_TYPE
            strSQL.Append(vbCrLf & "    AND XIN_RES_TYPE = :" & UBound(strBindField) - 1 & " --品目別空棚引当ﾀｲﾌﾟ")
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
        strDataSetName = "TMST_ITEM"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TMST_ITEM(Owner, objDb, objDbLog)
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
    Public Function GET_TMST_ITEM_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "TMST_ITEM"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TMST_ITEM(Owner, objDb, objDbLog)
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
    Public Function GET_TMST_ITEM_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    TMST_ITEM")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
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
        If IsNull(FNUM_IN_CASE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFNUM_IN_CASE
            strSQL.Append(vbCrLf & "    AND FNUM_IN_CASE = :" & UBound(strBindField) - 1 & " --正袋数量")
        End If
        If IsNull(FZAIKO_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_KUBUN
            strSQL.Append(vbCrLf & "    AND FZAIKO_KUBUN = :" & UBound(strBindField) - 1 & " --在庫区分")
        End If
        If IsNull(FSHIKEN_YOUHI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSHIKEN_YOUHI
            strSQL.Append(vbCrLf & "    AND FSHIKEN_YOUHI = :" & UBound(strBindField) - 1 & " --受入試験有無")
        End If
        If IsNull(FSHIKEN_TIMELIMIT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSHIKEN_TIMELIMIT
            strSQL.Append(vbCrLf & "    AND FSHIKEN_TIMELIMIT = :" & UBound(strBindField) - 1 & " --試験有効期限")
        End If
        If IsNull(FSHIKEN_READTIME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSHIKEN_READTIME
            strSQL.Append(vbCrLf & "    AND FSHIKEN_READTIME = :" & UBound(strBindField) - 1 & " --試験ﾘｰﾄﾞﾀｲﾑ")
        End If
        If IsNull(FRITEST_TIMELIMIT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRITEST_TIMELIMIT
            strSQL.Append(vbCrLf & "    AND FRITEST_TIMELIMIT = :" & UBound(strBindField) - 1 & " --ﾘﾃｽﾄ期間")
        End If
        If IsNull(FRITEST_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRITEST_FLAG
            strSQL.Append(vbCrLf & "    AND FRITEST_FLAG = :" & UBound(strBindField) - 1 & " --ﾘﾃｽﾄ対象品ﾌﾗｸﾞ")
        End If
        If IsNull(FNUM_IN_PALLET) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFNUM_IN_PALLET
            strSQL.Append(vbCrLf & "    AND FNUM_IN_PALLET = :" & UBound(strBindField) - 1 & " --PL毎積載数")
        End If
        If IsNull(FINVENTORY_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINVENTORY_FLAG
            strSQL.Append(vbCrLf & "    AND FINVENTORY_FLAG = :" & UBound(strBindField) - 1 & " --棚卸し対象ﾌﾗｸﾞ")
        End If
        If IsNull(FSYSTEM_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYSTEM_FLAG
            strSQL.Append(vbCrLf & "    AND FSYSTEM_FLAG = :" & UBound(strBindField) - 1 & " --ｼｽﾃﾑ対象ﾌﾗｸﾞ")
        End If
        If IsNull(FHASU_MATOME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHASU_MATOME
            strSQL.Append(vbCrLf & "    AND FHASU_MATOME = :" & UBound(strBindField) - 1 & " --端数まとめﾌﾗｸﾞ")
        End If
        If IsNull(FDISP_ADDRESS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS
            strSQL.Append(vbCrLf & "    AND FDISP_ADDRESS = :" & UBound(strBindField) - 1 & " --表記用ｱﾄﾞﾚｽ")
        End If
        If IsNull(FHINMEI_KIKAKU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_KIKAKU
            strSQL.Append(vbCrLf & "    AND FHINMEI_KIKAKU = :" & UBound(strBindField) - 1 & " --品目_規格容量")
        End If
        If IsNull(FRAC_FORM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_FORM
            strSQL.Append(vbCrLf & "    AND FRAC_FORM = :" & UBound(strBindField) - 1 & " --棚形状種別")
        End If
        If IsNull(FENTRY_TERM_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_TERM_ID
            strSQL.Append(vbCrLf & "    AND FENTRY_TERM_ID = :" & UBound(strBindField) - 1 & " --登録端末ID")
        End If
        If IsNull(FENTRY_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --登録日時")
        End If
        If IsNull(FENTRY_USER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_USER_ID
            strSQL.Append(vbCrLf & "    AND FENTRY_USER_ID = :" & UBound(strBindField) - 1 & " --登録ﾕｰｻﾞｰID")
        End If
        If IsNull(FENTRY_USER_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_USER_NAME
            strSQL.Append(vbCrLf & "    AND FENTRY_USER_NAME = :" & UBound(strBindField) - 1 & " --登録ﾕｰｻﾞｰ名")
        End If
        If IsNull(FUPDATE_TERM_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_TERM_ID
            strSQL.Append(vbCrLf & "    AND FUPDATE_TERM_ID = :" & UBound(strBindField) - 1 & " --更新端末ID")
        End If
        If IsNull(FUPDATE_USER_ID) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_USER_ID
            strSQL.Append(vbCrLf & "    AND FUPDATE_USER_ID = :" & UBound(strBindField) - 1 & " --更新ﾕｰｻﾞｰID")
        End If
        If IsNull(FUPDATE_USER_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_USER_NAME
            strSQL.Append(vbCrLf & "    AND FUPDATE_USER_NAME = :" & UBound(strBindField) - 1 & " --更新ﾕｰｻﾞｰ名")
        End If
        If IsNull(FUPDATE_DT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --更新日時")
        End If
        If IsNull(XABC_KANRI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXABC_KANRI
            strSQL.Append(vbCrLf & "    AND XABC_KANRI = :" & UBound(strBindField) - 1 & " --ABC管理")
        End If
        If IsNull(XPLANE_PACK_NUMBER) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPLANE_PACK_NUMBER
            strSQL.Append(vbCrLf & "    AND XPLANE_PACK_NUMBER = :" & UBound(strBindField) - 1 & " --平面梱数")
        End If
        If IsNull(XWEIGHT_IN_CASE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXWEIGHT_IN_CASE
            strSQL.Append(vbCrLf & "    AND XWEIGHT_IN_CASE = :" & UBound(strBindField) - 1 & " --梱重量")
        End If
        If IsNull(XWEIGHT_IN_PALLET) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXWEIGHT_IN_PALLET
            strSQL.Append(vbCrLf & "    AND XWEIGHT_IN_PALLET = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄあたりの重量")
        End If
        If IsNull(XHEIGHT_IN_CASE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHEIGHT_IN_CASE
            strSQL.Append(vbCrLf & "    AND XHEIGHT_IN_CASE = :" & UBound(strBindField) - 1 & " --梱高さ")
        End If
        If IsNull(XHEIGHT_IN_PALLET) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHEIGHT_IN_PALLET
            strSQL.Append(vbCrLf & "    AND XHEIGHT_IN_PALLET = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄ高さ")
        End If
        If IsNull(XARTICLE_TYPE_CODE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXARTICLE_TYPE_CODE
            strSQL.Append(vbCrLf & "    AND XARTICLE_TYPE_CODE = :" & UBound(strBindField) - 1 & " --品目種別(商品区分)")
        End If
        If IsNull(X24H_KENSA_AUTO_FLG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mX24H_KENSA_AUTO_FLG
            strSQL.Append(vbCrLf & "    AND X24H_KENSA_AUTO_FLG = :" & UBound(strBindField) - 1 & " --24H検査結果自動指定")
        End If
        If IsNull(XHINMEI_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHINMEI_CD
            strSQL.Append(vbCrLf & "    AND XHINMEI_CD = :" & UBound(strBindField) - 1 & " --品目ｺｰﾄﾞ(正式品目ｺｰﾄﾞ)")
        End If
        If IsNull(XSUB_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSUB_CD
            strSQL.Append(vbCrLf & "    AND XSUB_CD = :" & UBound(strBindField) - 1 & " --ｻﾌﾞｺｰﾄﾞ")
        End If
        If IsNull(XITF_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXITF_CD
            strSQL.Append(vbCrLf & "    AND XITF_CD = :" & UBound(strBindField) - 1 & " --ITFｺｰﾄﾞ")
        End If
        If IsNull(XJAN_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXJAN_CD
            strSQL.Append(vbCrLf & "    AND XJAN_CD = :" & UBound(strBindField) - 1 & " --JANｺｰﾄﾞ")
        End If
        If IsNull(XMAKER_CD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAKER_CD
            strSQL.Append(vbCrLf & "    AND XMAKER_CD = :" & UBound(strBindField) - 1 & " --ﾒｰｶ-ｺｰﾄﾞ")
        End If
        If IsNull(FRAC_BUNRUI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_BUNRUI
            strSQL.Append(vbCrLf & "    AND FRAC_BUNRUI = :" & UBound(strBindField) - 1 & " --棚分類")
        End If
        If IsNull(XDAN_IN_PALLET) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDAN_IN_PALLET
            strSQL.Append(vbCrLf & "    AND XDAN_IN_PALLET = :" & UBound(strBindField) - 1 & " --1ﾊﾟﾚｯﾄの段数")
        End If
        If IsNull(XIN_RES_TYPE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIN_RES_TYPE
            strSQL.Append(vbCrLf & "    AND XIN_RES_TYPE = :" & UBound(strBindField) - 1 & " --品目別空棚引当ﾀｲﾌﾟ")
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
        strDataSetName = "TMST_ITEM"
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
    Public Sub UPDATE_TMST_ITEM()
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
        ElseIf IsNull(mFHINMEI_CD) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[品目ｺｰﾄﾞ]"
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
        strSQL.Append(vbCrLf & "    TMST_ITEM")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
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
        If IsNull(mFSHIKEN_YOUHI) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSHIKEN_YOUHI = NULL --受入試験有無")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSHIKEN_YOUHI = NULL --受入試験有無")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSHIKEN_YOUHI
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSHIKEN_YOUHI = :" & Ubound(strBindField) - 1 & " --受入試験有無")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSHIKEN_YOUHI = :" & Ubound(strBindField) - 1 & " --受入試験有無")
        End If
        intCount = intCount + 1
        If IsNull(mFSHIKEN_TIMELIMIT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSHIKEN_TIMELIMIT = NULL --試験有効期限")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSHIKEN_TIMELIMIT = NULL --試験有効期限")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSHIKEN_TIMELIMIT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSHIKEN_TIMELIMIT = :" & Ubound(strBindField) - 1 & " --試験有効期限")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSHIKEN_TIMELIMIT = :" & Ubound(strBindField) - 1 & " --試験有効期限")
        End If
        intCount = intCount + 1
        If IsNull(mFSHIKEN_READTIME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSHIKEN_READTIME = NULL --試験ﾘｰﾄﾞﾀｲﾑ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSHIKEN_READTIME = NULL --試験ﾘｰﾄﾞﾀｲﾑ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSHIKEN_READTIME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSHIKEN_READTIME = :" & Ubound(strBindField) - 1 & " --試験ﾘｰﾄﾞﾀｲﾑ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSHIKEN_READTIME = :" & Ubound(strBindField) - 1 & " --試験ﾘｰﾄﾞﾀｲﾑ")
        End If
        intCount = intCount + 1
        If IsNull(mFRITEST_TIMELIMIT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRITEST_TIMELIMIT = NULL --ﾘﾃｽﾄ期間")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRITEST_TIMELIMIT = NULL --ﾘﾃｽﾄ期間")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRITEST_TIMELIMIT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRITEST_TIMELIMIT = :" & Ubound(strBindField) - 1 & " --ﾘﾃｽﾄ期間")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRITEST_TIMELIMIT = :" & Ubound(strBindField) - 1 & " --ﾘﾃｽﾄ期間")
        End If
        intCount = intCount + 1
        If IsNull(mFRITEST_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRITEST_FLAG = NULL --ﾘﾃｽﾄ対象品ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRITEST_FLAG = NULL --ﾘﾃｽﾄ対象品ﾌﾗｸﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRITEST_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRITEST_FLAG = :" & Ubound(strBindField) - 1 & " --ﾘﾃｽﾄ対象品ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRITEST_FLAG = :" & Ubound(strBindField) - 1 & " --ﾘﾃｽﾄ対象品ﾌﾗｸﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFNUM_IN_PALLET) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FNUM_IN_PALLET = NULL --PL毎積載数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FNUM_IN_PALLET = NULL --PL毎積載数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFNUM_IN_PALLET
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FNUM_IN_PALLET = :" & Ubound(strBindField) - 1 & " --PL毎積載数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FNUM_IN_PALLET = :" & Ubound(strBindField) - 1 & " --PL毎積載数")
        End If
        intCount = intCount + 1
        If IsNull(mFINVENTORY_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FINVENTORY_FLAG = NULL --棚卸し対象ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FINVENTORY_FLAG = NULL --棚卸し対象ﾌﾗｸﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINVENTORY_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FINVENTORY_FLAG = :" & Ubound(strBindField) - 1 & " --棚卸し対象ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FINVENTORY_FLAG = :" & Ubound(strBindField) - 1 & " --棚卸し対象ﾌﾗｸﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFSYSTEM_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSYSTEM_FLAG = NULL --ｼｽﾃﾑ対象ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSYSTEM_FLAG = NULL --ｼｽﾃﾑ対象ﾌﾗｸﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYSTEM_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FSYSTEM_FLAG = :" & Ubound(strBindField) - 1 & " --ｼｽﾃﾑ対象ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FSYSTEM_FLAG = :" & Ubound(strBindField) - 1 & " --ｼｽﾃﾑ対象ﾌﾗｸﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFHASU_MATOME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHASU_MATOME = NULL --端数まとめﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHASU_MATOME = NULL --端数まとめﾌﾗｸﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHASU_MATOME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHASU_MATOME = :" & Ubound(strBindField) - 1 & " --端数まとめﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHASU_MATOME = :" & Ubound(strBindField) - 1 & " --端数まとめﾌﾗｸﾞ")
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
        If IsNull(mFHINMEI_KIKAKU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHINMEI_KIKAKU = NULL --品目_規格容量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHINMEI_KIKAKU = NULL --品目_規格容量")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_KIKAKU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FHINMEI_KIKAKU = :" & Ubound(strBindField) - 1 & " --品目_規格容量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FHINMEI_KIKAKU = :" & Ubound(strBindField) - 1 & " --品目_規格容量")
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
        If IsNull(mFENTRY_TERM_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FENTRY_TERM_ID = NULL --登録端末ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FENTRY_TERM_ID = NULL --登録端末ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_TERM_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FENTRY_TERM_ID = :" & Ubound(strBindField) - 1 & " --登録端末ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FENTRY_TERM_ID = :" & Ubound(strBindField) - 1 & " --登録端末ID")
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
        If IsNull(mFENTRY_USER_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FENTRY_USER_ID = NULL --登録ﾕｰｻﾞｰID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FENTRY_USER_ID = NULL --登録ﾕｰｻﾞｰID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_USER_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FENTRY_USER_ID = :" & Ubound(strBindField) - 1 & " --登録ﾕｰｻﾞｰID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FENTRY_USER_ID = :" & Ubound(strBindField) - 1 & " --登録ﾕｰｻﾞｰID")
        End If
        intCount = intCount + 1
        If IsNull(mFENTRY_USER_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FENTRY_USER_NAME = NULL --登録ﾕｰｻﾞｰ名")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FENTRY_USER_NAME = NULL --登録ﾕｰｻﾞｰ名")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_USER_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FENTRY_USER_NAME = :" & Ubound(strBindField) - 1 & " --登録ﾕｰｻﾞｰ名")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FENTRY_USER_NAME = :" & Ubound(strBindField) - 1 & " --登録ﾕｰｻﾞｰ名")
        End If
        intCount = intCount + 1
        If IsNull(mFUPDATE_TERM_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUPDATE_TERM_ID = NULL --更新端末ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUPDATE_TERM_ID = NULL --更新端末ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_TERM_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUPDATE_TERM_ID = :" & Ubound(strBindField) - 1 & " --更新端末ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUPDATE_TERM_ID = :" & Ubound(strBindField) - 1 & " --更新端末ID")
        End If
        intCount = intCount + 1
        If IsNull(mFUPDATE_USER_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUPDATE_USER_ID = NULL --更新ﾕｰｻﾞｰID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUPDATE_USER_ID = NULL --更新ﾕｰｻﾞｰID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_USER_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUPDATE_USER_ID = :" & Ubound(strBindField) - 1 & " --更新ﾕｰｻﾞｰID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUPDATE_USER_ID = :" & Ubound(strBindField) - 1 & " --更新ﾕｰｻﾞｰID")
        End If
        intCount = intCount + 1
        If IsNull(mFUPDATE_USER_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUPDATE_USER_NAME = NULL --更新ﾕｰｻﾞｰ名")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUPDATE_USER_NAME = NULL --更新ﾕｰｻﾞｰ名")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_USER_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FUPDATE_USER_NAME = :" & Ubound(strBindField) - 1 & " --更新ﾕｰｻﾞｰ名")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FUPDATE_USER_NAME = :" & Ubound(strBindField) - 1 & " --更新ﾕｰｻﾞｰ名")
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
        If IsNull(mXABC_KANRI) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XABC_KANRI = NULL --ABC管理")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XABC_KANRI = NULL --ABC管理")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXABC_KANRI
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XABC_KANRI = :" & Ubound(strBindField) - 1 & " --ABC管理")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XABC_KANRI = :" & Ubound(strBindField) - 1 & " --ABC管理")
        End If
        intCount = intCount + 1
        If IsNull(mXPLANE_PACK_NUMBER) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XPLANE_PACK_NUMBER = NULL --平面梱数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XPLANE_PACK_NUMBER = NULL --平面梱数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPLANE_PACK_NUMBER
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XPLANE_PACK_NUMBER = :" & Ubound(strBindField) - 1 & " --平面梱数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XPLANE_PACK_NUMBER = :" & Ubound(strBindField) - 1 & " --平面梱数")
        End If
        intCount = intCount + 1
        If IsNull(mXWEIGHT_IN_CASE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XWEIGHT_IN_CASE = NULL --梱重量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XWEIGHT_IN_CASE = NULL --梱重量")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXWEIGHT_IN_CASE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XWEIGHT_IN_CASE = :" & Ubound(strBindField) - 1 & " --梱重量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XWEIGHT_IN_CASE = :" & Ubound(strBindField) - 1 & " --梱重量")
        End If
        intCount = intCount + 1
        If IsNull(mXWEIGHT_IN_PALLET) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XWEIGHT_IN_PALLET = NULL --ﾊﾟﾚｯﾄあたりの重量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XWEIGHT_IN_PALLET = NULL --ﾊﾟﾚｯﾄあたりの重量")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXWEIGHT_IN_PALLET
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XWEIGHT_IN_PALLET = :" & Ubound(strBindField) - 1 & " --ﾊﾟﾚｯﾄあたりの重量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XWEIGHT_IN_PALLET = :" & Ubound(strBindField) - 1 & " --ﾊﾟﾚｯﾄあたりの重量")
        End If
        intCount = intCount + 1
        If IsNull(mXHEIGHT_IN_CASE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XHEIGHT_IN_CASE = NULL --梱高さ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XHEIGHT_IN_CASE = NULL --梱高さ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHEIGHT_IN_CASE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XHEIGHT_IN_CASE = :" & Ubound(strBindField) - 1 & " --梱高さ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XHEIGHT_IN_CASE = :" & Ubound(strBindField) - 1 & " --梱高さ")
        End If
        intCount = intCount + 1
        If IsNull(mXHEIGHT_IN_PALLET) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XHEIGHT_IN_PALLET = NULL --ﾊﾟﾚｯﾄ高さ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XHEIGHT_IN_PALLET = NULL --ﾊﾟﾚｯﾄ高さ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHEIGHT_IN_PALLET
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XHEIGHT_IN_PALLET = :" & Ubound(strBindField) - 1 & " --ﾊﾟﾚｯﾄ高さ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XHEIGHT_IN_PALLET = :" & Ubound(strBindField) - 1 & " --ﾊﾟﾚｯﾄ高さ")
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
        If IsNull(mX24H_KENSA_AUTO_FLG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    X24H_KENSA_AUTO_FLG = NULL --24H検査結果自動指定")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,X24H_KENSA_AUTO_FLG = NULL --24H検査結果自動指定")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mX24H_KENSA_AUTO_FLG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    X24H_KENSA_AUTO_FLG = :" & Ubound(strBindField) - 1 & " --24H検査結果自動指定")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,X24H_KENSA_AUTO_FLG = :" & Ubound(strBindField) - 1 & " --24H検査結果自動指定")
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
        If IsNull(mXSUB_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSUB_CD = NULL --ｻﾌﾞｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSUB_CD = NULL --ｻﾌﾞｺｰﾄﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSUB_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XSUB_CD = :" & Ubound(strBindField) - 1 & " --ｻﾌﾞｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XSUB_CD = :" & Ubound(strBindField) - 1 & " --ｻﾌﾞｺｰﾄﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mXITF_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XITF_CD = NULL --ITFｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XITF_CD = NULL --ITFｺｰﾄﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXITF_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XITF_CD = :" & Ubound(strBindField) - 1 & " --ITFｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XITF_CD = :" & Ubound(strBindField) - 1 & " --ITFｺｰﾄﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mXJAN_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XJAN_CD = NULL --JANｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XJAN_CD = NULL --JANｺｰﾄﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXJAN_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XJAN_CD = :" & Ubound(strBindField) - 1 & " --JANｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XJAN_CD = :" & Ubound(strBindField) - 1 & " --JANｺｰﾄﾞ")
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
        If IsNull(mXDAN_IN_PALLET) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDAN_IN_PALLET = NULL --1ﾊﾟﾚｯﾄの段数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDAN_IN_PALLET = NULL --1ﾊﾟﾚｯﾄの段数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDAN_IN_PALLET
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDAN_IN_PALLET = :" & Ubound(strBindField) - 1 & " --1ﾊﾟﾚｯﾄの段数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDAN_IN_PALLET = :" & Ubound(strBindField) - 1 & " --1ﾊﾟﾚｯﾄの段数")
        End If
        intCount = intCount + 1
        If IsNull(mXIN_RES_TYPE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XIN_RES_TYPE = NULL --品目別空棚引当ﾀｲﾌﾟ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XIN_RES_TYPE = NULL --品目別空棚引当ﾀｲﾌﾟ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIN_RES_TYPE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XIN_RES_TYPE = :" & Ubound(strBindField) - 1 & " --品目別空棚引当ﾀｲﾌﾟ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XIN_RES_TYPE = :" & Ubound(strBindField) - 1 & " --品目別空棚引当ﾀｲﾌﾟ")
        End If
        intCount = intCount + 1
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FHINMEI_CD) = True Then
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD IS NULL --品目ｺｰﾄﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --品目ｺｰﾄﾞ")
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
    Public Sub ADD_TMST_ITEM()
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
        ElseIf IsNull(mFHINMEI_CD) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[品目ｺｰﾄﾞ]"
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
        strSQL.Append(vbCrLf & "    TMST_ITEM")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
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
        If IsNull(mFSHIKEN_YOUHI) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --受入試験有無")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --受入試験有無")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSHIKEN_YOUHI
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --受入試験有無")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --受入試験有無")
        End If
        intCount = intCount + 1
        If IsNull(mFSHIKEN_TIMELIMIT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --試験有効期限")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --試験有効期限")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSHIKEN_TIMELIMIT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --試験有効期限")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --試験有効期限")
        End If
        intCount = intCount + 1
        If IsNull(mFSHIKEN_READTIME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --試験ﾘｰﾄﾞﾀｲﾑ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --試験ﾘｰﾄﾞﾀｲﾑ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSHIKEN_READTIME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --試験ﾘｰﾄﾞﾀｲﾑ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --試験ﾘｰﾄﾞﾀｲﾑ")
        End If
        intCount = intCount + 1
        If IsNull(mFRITEST_TIMELIMIT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾘﾃｽﾄ期間")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾘﾃｽﾄ期間")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRITEST_TIMELIMIT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾘﾃｽﾄ期間")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾘﾃｽﾄ期間")
        End If
        intCount = intCount + 1
        If IsNull(mFRITEST_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾘﾃｽﾄ対象品ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾘﾃｽﾄ対象品ﾌﾗｸﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRITEST_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾘﾃｽﾄ対象品ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾘﾃｽﾄ対象品ﾌﾗｸﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFNUM_IN_PALLET) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --PL毎積載数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --PL毎積載数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFNUM_IN_PALLET
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --PL毎積載数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --PL毎積載数")
        End If
        intCount = intCount + 1
        If IsNull(mFINVENTORY_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --棚卸し対象ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --棚卸し対象ﾌﾗｸﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINVENTORY_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --棚卸し対象ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --棚卸し対象ﾌﾗｸﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFSYSTEM_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｼｽﾃﾑ対象ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｼｽﾃﾑ対象ﾌﾗｸﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYSTEM_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｼｽﾃﾑ対象ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｼｽﾃﾑ対象ﾌﾗｸﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFHASU_MATOME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --端数まとめﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --端数まとめﾌﾗｸﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHASU_MATOME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --端数まとめﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --端数まとめﾌﾗｸﾞ")
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
        If IsNull(mFHINMEI_KIKAKU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --品目_規格容量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --品目_規格容量")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_KIKAKU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --品目_規格容量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --品目_規格容量")
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
        If IsNull(mFENTRY_TERM_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --登録端末ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --登録端末ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_TERM_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --登録端末ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --登録端末ID")
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
        If IsNull(mFENTRY_USER_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --登録ﾕｰｻﾞｰID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --登録ﾕｰｻﾞｰID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_USER_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --登録ﾕｰｻﾞｰID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --登録ﾕｰｻﾞｰID")
        End If
        intCount = intCount + 1
        If IsNull(mFENTRY_USER_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --登録ﾕｰｻﾞｰ名")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --登録ﾕｰｻﾞｰ名")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_USER_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --登録ﾕｰｻﾞｰ名")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --登録ﾕｰｻﾞｰ名")
        End If
        intCount = intCount + 1
        If IsNull(mFUPDATE_TERM_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --更新端末ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --更新端末ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_TERM_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --更新端末ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --更新端末ID")
        End If
        intCount = intCount + 1
        If IsNull(mFUPDATE_USER_ID) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --更新ﾕｰｻﾞｰID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --更新ﾕｰｻﾞｰID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_USER_ID
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --更新ﾕｰｻﾞｰID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --更新ﾕｰｻﾞｰID")
        End If
        intCount = intCount + 1
        If IsNull(mFUPDATE_USER_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --更新ﾕｰｻﾞｰ名")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --更新ﾕｰｻﾞｰ名")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_USER_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --更新ﾕｰｻﾞｰ名")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --更新ﾕｰｻﾞｰ名")
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
        If IsNull(mXABC_KANRI) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ABC管理")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ABC管理")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXABC_KANRI
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ABC管理")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ABC管理")
        End If
        intCount = intCount + 1
        If IsNull(mXPLANE_PACK_NUMBER) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --平面梱数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --平面梱数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPLANE_PACK_NUMBER
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --平面梱数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --平面梱数")
        End If
        intCount = intCount + 1
        If IsNull(mXWEIGHT_IN_CASE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --梱重量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --梱重量")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXWEIGHT_IN_CASE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --梱重量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --梱重量")
        End If
        intCount = intCount + 1
        If IsNull(mXWEIGHT_IN_PALLET) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾊﾟﾚｯﾄあたりの重量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾊﾟﾚｯﾄあたりの重量")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXWEIGHT_IN_PALLET
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾊﾟﾚｯﾄあたりの重量")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾊﾟﾚｯﾄあたりの重量")
        End If
        intCount = intCount + 1
        If IsNull(mXHEIGHT_IN_CASE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --梱高さ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --梱高さ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHEIGHT_IN_CASE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --梱高さ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --梱高さ")
        End If
        intCount = intCount + 1
        If IsNull(mXHEIGHT_IN_PALLET) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾊﾟﾚｯﾄ高さ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾊﾟﾚｯﾄ高さ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHEIGHT_IN_PALLET
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾊﾟﾚｯﾄ高さ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾊﾟﾚｯﾄ高さ")
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
        If IsNull(mX24H_KENSA_AUTO_FLG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --24H検査結果自動指定")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --24H検査結果自動指定")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mX24H_KENSA_AUTO_FLG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --24H検査結果自動指定")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --24H検査結果自動指定")
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
        If IsNull(mXSUB_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｻﾌﾞｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｻﾌﾞｺｰﾄﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSUB_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｻﾌﾞｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｻﾌﾞｺｰﾄﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mXITF_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ITFｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ITFｺｰﾄﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXITF_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ITFｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ITFｺｰﾄﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mXJAN_CD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --JANｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --JANｺｰﾄﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXJAN_CD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --JANｺｰﾄﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --JANｺｰﾄﾞ")
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
        If IsNull(mXDAN_IN_PALLET) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --1ﾊﾟﾚｯﾄの段数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --1ﾊﾟﾚｯﾄの段数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDAN_IN_PALLET
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --1ﾊﾟﾚｯﾄの段数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --1ﾊﾟﾚｯﾄの段数")
        End If
        intCount = intCount + 1
        If IsNull(mXIN_RES_TYPE) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --品目別空棚引当ﾀｲﾌﾟ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --品目別空棚引当ﾀｲﾌﾟ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIN_RES_TYPE
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --品目別空棚引当ﾀｲﾌﾟ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --品目別空棚引当ﾀｲﾌﾟ")
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
    Public Sub DELETE_TMST_ITEM()
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
        ElseIf IsNull(mFHINMEI_CD) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[品目ｺｰﾄﾞ]"
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
        strSQL.Append(vbCrLf & "    TMST_ITEM")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(FHINMEI_CD) = True Then
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD IS NULL --品目ｺｰﾄﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_CD
            strSQL.Append(vbCrLf & "    AND FHINMEI_CD = :" & UBound(strBindField) - 1 & " --品目ｺｰﾄﾞ")
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
    Public Sub DELETE_TMST_ITEM_ANY()
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
        strSQL.Append(vbCrLf & "    TMST_ITEM")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
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
        If IsNotNull(FNUM_IN_CASE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFNUM_IN_CASE
            strSQL.Append(vbCrLf & "    AND FNUM_IN_CASE = :" & UBound(strBindField) - 1 & " --正袋数量")
        End If
        If IsNotNull(FZAIKO_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFZAIKO_KUBUN
            strSQL.Append(vbCrLf & "    AND FZAIKO_KUBUN = :" & UBound(strBindField) - 1 & " --在庫区分")
        End If
        If IsNotNull(FSHIKEN_YOUHI) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSHIKEN_YOUHI
            strSQL.Append(vbCrLf & "    AND FSHIKEN_YOUHI = :" & UBound(strBindField) - 1 & " --受入試験有無")
        End If
        If IsNotNull(FSHIKEN_TIMELIMIT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSHIKEN_TIMELIMIT
            strSQL.Append(vbCrLf & "    AND FSHIKEN_TIMELIMIT = :" & UBound(strBindField) - 1 & " --試験有効期限")
        End If
        If IsNotNull(FSHIKEN_READTIME) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSHIKEN_READTIME
            strSQL.Append(vbCrLf & "    AND FSHIKEN_READTIME = :" & UBound(strBindField) - 1 & " --試験ﾘｰﾄﾞﾀｲﾑ")
        End If
        If IsNotNull(FRITEST_TIMELIMIT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRITEST_TIMELIMIT
            strSQL.Append(vbCrLf & "    AND FRITEST_TIMELIMIT = :" & UBound(strBindField) - 1 & " --ﾘﾃｽﾄ期間")
        End If
        If IsNotNull(FRITEST_FLAG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRITEST_FLAG
            strSQL.Append(vbCrLf & "    AND FRITEST_FLAG = :" & UBound(strBindField) - 1 & " --ﾘﾃｽﾄ対象品ﾌﾗｸﾞ")
        End If
        If IsNotNull(FNUM_IN_PALLET) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFNUM_IN_PALLET
            strSQL.Append(vbCrLf & "    AND FNUM_IN_PALLET = :" & UBound(strBindField) - 1 & " --PL毎積載数")
        End If
        If IsNotNull(FINVENTORY_FLAG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFINVENTORY_FLAG
            strSQL.Append(vbCrLf & "    AND FINVENTORY_FLAG = :" & UBound(strBindField) - 1 & " --棚卸し対象ﾌﾗｸﾞ")
        End If
        If IsNotNull(FSYSTEM_FLAG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFSYSTEM_FLAG
            strSQL.Append(vbCrLf & "    AND FSYSTEM_FLAG = :" & UBound(strBindField) - 1 & " --ｼｽﾃﾑ対象ﾌﾗｸﾞ")
        End If
        If IsNotNull(FHASU_MATOME) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHASU_MATOME
            strSQL.Append(vbCrLf & "    AND FHASU_MATOME = :" & UBound(strBindField) - 1 & " --端数まとめﾌﾗｸﾞ")
        End If
        If IsNotNull(FDISP_ADDRESS) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFDISP_ADDRESS
            strSQL.Append(vbCrLf & "    AND FDISP_ADDRESS = :" & UBound(strBindField) - 1 & " --表記用ｱﾄﾞﾚｽ")
        End If
        If IsNotNull(FHINMEI_KIKAKU) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFHINMEI_KIKAKU
            strSQL.Append(vbCrLf & "    AND FHINMEI_KIKAKU = :" & UBound(strBindField) - 1 & " --品目_規格容量")
        End If
        If IsNotNull(FRAC_FORM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_FORM
            strSQL.Append(vbCrLf & "    AND FRAC_FORM = :" & UBound(strBindField) - 1 & " --棚形状種別")
        End If
        If IsNotNull(FENTRY_TERM_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_TERM_ID
            strSQL.Append(vbCrLf & "    AND FENTRY_TERM_ID = :" & UBound(strBindField) - 1 & " --登録端末ID")
        End If
        If IsNotNull(FENTRY_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_DT
            strSQL.Append(vbCrLf & "    AND FENTRY_DT = :" & UBound(strBindField) - 1 & " --登録日時")
        End If
        If IsNotNull(FENTRY_USER_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_USER_ID
            strSQL.Append(vbCrLf & "    AND FENTRY_USER_ID = :" & UBound(strBindField) - 1 & " --登録ﾕｰｻﾞｰID")
        End If
        If IsNotNull(FENTRY_USER_NAME) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFENTRY_USER_NAME
            strSQL.Append(vbCrLf & "    AND FENTRY_USER_NAME = :" & UBound(strBindField) - 1 & " --登録ﾕｰｻﾞｰ名")
        End If
        If IsNotNull(FUPDATE_TERM_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_TERM_ID
            strSQL.Append(vbCrLf & "    AND FUPDATE_TERM_ID = :" & UBound(strBindField) - 1 & " --更新端末ID")
        End If
        If IsNotNull(FUPDATE_USER_ID) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_USER_ID
            strSQL.Append(vbCrLf & "    AND FUPDATE_USER_ID = :" & UBound(strBindField) - 1 & " --更新ﾕｰｻﾞｰID")
        End If
        If IsNotNull(FUPDATE_USER_NAME) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_USER_NAME
            strSQL.Append(vbCrLf & "    AND FUPDATE_USER_NAME = :" & UBound(strBindField) - 1 & " --更新ﾕｰｻﾞｰ名")
        End If
        If IsNotNull(FUPDATE_DT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFUPDATE_DT
            strSQL.Append(vbCrLf & "    AND FUPDATE_DT = :" & UBound(strBindField) - 1 & " --更新日時")
        End If
        If IsNotNull(XABC_KANRI) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXABC_KANRI
            strSQL.Append(vbCrLf & "    AND XABC_KANRI = :" & UBound(strBindField) - 1 & " --ABC管理")
        End If
        If IsNotNull(XPLANE_PACK_NUMBER) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPLANE_PACK_NUMBER
            strSQL.Append(vbCrLf & "    AND XPLANE_PACK_NUMBER = :" & UBound(strBindField) - 1 & " --平面梱数")
        End If
        If IsNotNull(XWEIGHT_IN_CASE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXWEIGHT_IN_CASE
            strSQL.Append(vbCrLf & "    AND XWEIGHT_IN_CASE = :" & UBound(strBindField) - 1 & " --梱重量")
        End If
        If IsNotNull(XWEIGHT_IN_PALLET) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXWEIGHT_IN_PALLET
            strSQL.Append(vbCrLf & "    AND XWEIGHT_IN_PALLET = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄあたりの重量")
        End If
        If IsNotNull(XHEIGHT_IN_CASE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHEIGHT_IN_CASE
            strSQL.Append(vbCrLf & "    AND XHEIGHT_IN_CASE = :" & UBound(strBindField) - 1 & " --梱高さ")
        End If
        If IsNotNull(XHEIGHT_IN_PALLET) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHEIGHT_IN_PALLET
            strSQL.Append(vbCrLf & "    AND XHEIGHT_IN_PALLET = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄ高さ")
        End If
        If IsNotNull(XARTICLE_TYPE_CODE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXARTICLE_TYPE_CODE
            strSQL.Append(vbCrLf & "    AND XARTICLE_TYPE_CODE = :" & UBound(strBindField) - 1 & " --品目種別(商品区分)")
        End If
        If IsNotNull(X24H_KENSA_AUTO_FLG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mX24H_KENSA_AUTO_FLG
            strSQL.Append(vbCrLf & "    AND X24H_KENSA_AUTO_FLG = :" & UBound(strBindField) - 1 & " --24H検査結果自動指定")
        End If
        If IsNotNull(XHINMEI_CD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXHINMEI_CD
            strSQL.Append(vbCrLf & "    AND XHINMEI_CD = :" & UBound(strBindField) - 1 & " --品目ｺｰﾄﾞ(正式品目ｺｰﾄﾞ)")
        End If
        If IsNotNull(XSUB_CD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXSUB_CD
            strSQL.Append(vbCrLf & "    AND XSUB_CD = :" & UBound(strBindField) - 1 & " --ｻﾌﾞｺｰﾄﾞ")
        End If
        If IsNotNull(XITF_CD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXITF_CD
            strSQL.Append(vbCrLf & "    AND XITF_CD = :" & UBound(strBindField) - 1 & " --ITFｺｰﾄﾞ")
        End If
        If IsNotNull(XJAN_CD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXJAN_CD
            strSQL.Append(vbCrLf & "    AND XJAN_CD = :" & UBound(strBindField) - 1 & " --JANｺｰﾄﾞ")
        End If
        If IsNotNull(XMAKER_CD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAKER_CD
            strSQL.Append(vbCrLf & "    AND XMAKER_CD = :" & UBound(strBindField) - 1 & " --ﾒｰｶ-ｺｰﾄﾞ")
        End If
        If IsNotNull(FRAC_BUNRUI) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_BUNRUI
            strSQL.Append(vbCrLf & "    AND FRAC_BUNRUI = :" & UBound(strBindField) - 1 & " --棚分類")
        End If
        If IsNotNull(XDAN_IN_PALLET) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDAN_IN_PALLET
            strSQL.Append(vbCrLf & "    AND XDAN_IN_PALLET = :" & UBound(strBindField) - 1 & " --1ﾊﾟﾚｯﾄの段数")
        End If
        If IsNotNull(XIN_RES_TYPE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXIN_RES_TYPE
            strSQL.Append(vbCrLf & "    AND XIN_RES_TYPE = :" & UBound(strBindField) - 1 & " --品目別空棚引当ﾀｲﾌﾟ")
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
        If IsNothing(objType.GetProperty("FHINMEI_CD")) = False Then mFHINMEI_CD = objObject.FHINMEI_CD '品目ｺｰﾄﾞ
        If IsNothing(objType.GetProperty("FHINMEI")) = False Then mFHINMEI = objObject.FHINMEI '品名_正式名
        If IsNothing(objType.GetProperty("FTANI")) = False Then mFTANI = objObject.FTANI '単位ｺｰﾄﾞ
        If IsNothing(objType.GetProperty("FDECIMAL_POINT")) = False Then mFDECIMAL_POINT = objObject.FDECIMAL_POINT '小数点以下有効桁数
        If IsNothing(objType.GetProperty("FNUM_IN_CASE")) = False Then mFNUM_IN_CASE = objObject.FNUM_IN_CASE '正袋数量
        If IsNothing(objType.GetProperty("FZAIKO_KUBUN")) = False Then mFZAIKO_KUBUN = objObject.FZAIKO_KUBUN '在庫区分
        If IsNothing(objType.GetProperty("FSHIKEN_YOUHI")) = False Then mFSHIKEN_YOUHI = objObject.FSHIKEN_YOUHI '受入試験有無
        If IsNothing(objType.GetProperty("FSHIKEN_TIMELIMIT")) = False Then mFSHIKEN_TIMELIMIT = objObject.FSHIKEN_TIMELIMIT '試験有効期限
        If IsNothing(objType.GetProperty("FSHIKEN_READTIME")) = False Then mFSHIKEN_READTIME = objObject.FSHIKEN_READTIME '試験ﾘｰﾄﾞﾀｲﾑ
        If IsNothing(objType.GetProperty("FRITEST_TIMELIMIT")) = False Then mFRITEST_TIMELIMIT = objObject.FRITEST_TIMELIMIT 'ﾘﾃｽﾄ期間
        If IsNothing(objType.GetProperty("FRITEST_FLAG")) = False Then mFRITEST_FLAG = objObject.FRITEST_FLAG 'ﾘﾃｽﾄ対象品ﾌﾗｸﾞ
        If IsNothing(objType.GetProperty("FNUM_IN_PALLET")) = False Then mFNUM_IN_PALLET = objObject.FNUM_IN_PALLET 'PL毎積載数
        If IsNothing(objType.GetProperty("FINVENTORY_FLAG")) = False Then mFINVENTORY_FLAG = objObject.FINVENTORY_FLAG '棚卸し対象ﾌﾗｸﾞ
        If IsNothing(objType.GetProperty("FSYSTEM_FLAG")) = False Then mFSYSTEM_FLAG = objObject.FSYSTEM_FLAG 'ｼｽﾃﾑ対象ﾌﾗｸﾞ
        If IsNothing(objType.GetProperty("FHASU_MATOME")) = False Then mFHASU_MATOME = objObject.FHASU_MATOME '端数まとめﾌﾗｸﾞ
        If IsNothing(objType.GetProperty("FDISP_ADDRESS")) = False Then mFDISP_ADDRESS = objObject.FDISP_ADDRESS '表記用ｱﾄﾞﾚｽ
        If IsNothing(objType.GetProperty("FHINMEI_KIKAKU")) = False Then mFHINMEI_KIKAKU = objObject.FHINMEI_KIKAKU '品目_規格容量
        If IsNothing(objType.GetProperty("FRAC_FORM")) = False Then mFRAC_FORM = objObject.FRAC_FORM '棚形状種別
        If IsNothing(objType.GetProperty("FENTRY_TERM_ID")) = False Then mFENTRY_TERM_ID = objObject.FENTRY_TERM_ID '登録端末ID
        If IsNothing(objType.GetProperty("FENTRY_DT")) = False Then mFENTRY_DT = objObject.FENTRY_DT '登録日時
        If IsNothing(objType.GetProperty("FENTRY_USER_ID")) = False Then mFENTRY_USER_ID = objObject.FENTRY_USER_ID '登録ﾕｰｻﾞｰID
        If IsNothing(objType.GetProperty("FENTRY_USER_NAME")) = False Then mFENTRY_USER_NAME = objObject.FENTRY_USER_NAME '登録ﾕｰｻﾞｰ名
        If IsNothing(objType.GetProperty("FUPDATE_TERM_ID")) = False Then mFUPDATE_TERM_ID = objObject.FUPDATE_TERM_ID '更新端末ID
        If IsNothing(objType.GetProperty("FUPDATE_USER_ID")) = False Then mFUPDATE_USER_ID = objObject.FUPDATE_USER_ID '更新ﾕｰｻﾞｰID
        If IsNothing(objType.GetProperty("FUPDATE_USER_NAME")) = False Then mFUPDATE_USER_NAME = objObject.FUPDATE_USER_NAME '更新ﾕｰｻﾞｰ名
        If IsNothing(objType.GetProperty("FUPDATE_DT")) = False Then mFUPDATE_DT = objObject.FUPDATE_DT '更新日時
        If IsNothing(objType.GetProperty("XABC_KANRI")) = False Then mXABC_KANRI = objObject.XABC_KANRI 'ABC管理
        If IsNothing(objType.GetProperty("XPLANE_PACK_NUMBER")) = False Then mXPLANE_PACK_NUMBER = objObject.XPLANE_PACK_NUMBER '平面梱数
        If IsNothing(objType.GetProperty("XWEIGHT_IN_CASE")) = False Then mXWEIGHT_IN_CASE = objObject.XWEIGHT_IN_CASE '梱重量
        If IsNothing(objType.GetProperty("XWEIGHT_IN_PALLET")) = False Then mXWEIGHT_IN_PALLET = objObject.XWEIGHT_IN_PALLET 'ﾊﾟﾚｯﾄあたりの重量
        If IsNothing(objType.GetProperty("XHEIGHT_IN_CASE")) = False Then mXHEIGHT_IN_CASE = objObject.XHEIGHT_IN_CASE '梱高さ
        If IsNothing(objType.GetProperty("XHEIGHT_IN_PALLET")) = False Then mXHEIGHT_IN_PALLET = objObject.XHEIGHT_IN_PALLET 'ﾊﾟﾚｯﾄ高さ
        If IsNothing(objType.GetProperty("XARTICLE_TYPE_CODE")) = False Then mXARTICLE_TYPE_CODE = objObject.XARTICLE_TYPE_CODE '品目種別(商品区分)
        If IsNothing(objType.GetProperty("X24H_KENSA_AUTO_FLG")) = False Then mX24H_KENSA_AUTO_FLG = objObject.X24H_KENSA_AUTO_FLG '24H検査結果自動指定
        If IsNothing(objType.GetProperty("XHINMEI_CD")) = False Then mXHINMEI_CD = objObject.XHINMEI_CD '品目ｺｰﾄﾞ(正式品目ｺｰﾄﾞ)
        If IsNothing(objType.GetProperty("XSUB_CD")) = False Then mXSUB_CD = objObject.XSUB_CD 'ｻﾌﾞｺｰﾄﾞ
        If IsNothing(objType.GetProperty("XITF_CD")) = False Then mXITF_CD = objObject.XITF_CD 'ITFｺｰﾄﾞ
        If IsNothing(objType.GetProperty("XJAN_CD")) = False Then mXJAN_CD = objObject.XJAN_CD 'JANｺｰﾄﾞ
        If IsNothing(objType.GetProperty("XMAKER_CD")) = False Then mXMAKER_CD = objObject.XMAKER_CD 'ﾒｰｶ-ｺｰﾄﾞ
        If IsNothing(objType.GetProperty("FRAC_BUNRUI")) = False Then mFRAC_BUNRUI = objObject.FRAC_BUNRUI '棚分類
        If IsNothing(objType.GetProperty("XDAN_IN_PALLET")) = False Then mXDAN_IN_PALLET = objObject.XDAN_IN_PALLET '1ﾊﾟﾚｯﾄの段数
        If IsNothing(objType.GetProperty("XIN_RES_TYPE")) = False Then mXIN_RES_TYPE = objObject.XIN_RES_TYPE '品目別空棚引当ﾀｲﾌﾟ

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
        mFHINMEI_CD = Nothing
        mFHINMEI = Nothing
        mFTANI = Nothing
        mFDECIMAL_POINT = Nothing
        mFNUM_IN_CASE = Nothing
        mFZAIKO_KUBUN = Nothing
        mFSHIKEN_YOUHI = Nothing
        mFSHIKEN_TIMELIMIT = Nothing
        mFSHIKEN_READTIME = Nothing
        mFRITEST_TIMELIMIT = Nothing
        mFRITEST_FLAG = Nothing
        mFNUM_IN_PALLET = Nothing
        mFINVENTORY_FLAG = Nothing
        mFSYSTEM_FLAG = Nothing
        mFHASU_MATOME = Nothing
        mFDISP_ADDRESS = Nothing
        mFHINMEI_KIKAKU = Nothing
        mFRAC_FORM = Nothing
        mFENTRY_TERM_ID = Nothing
        mFENTRY_DT = Nothing
        mFENTRY_USER_ID = Nothing
        mFENTRY_USER_NAME = Nothing
        mFUPDATE_TERM_ID = Nothing
        mFUPDATE_USER_ID = Nothing
        mFUPDATE_USER_NAME = Nothing
        mFUPDATE_DT = Nothing
        mXABC_KANRI = Nothing
        mXPLANE_PACK_NUMBER = Nothing
        mXWEIGHT_IN_CASE = Nothing
        mXWEIGHT_IN_PALLET = Nothing
        mXHEIGHT_IN_CASE = Nothing
        mXHEIGHT_IN_PALLET = Nothing
        mXARTICLE_TYPE_CODE = Nothing
        mX24H_KENSA_AUTO_FLG = Nothing
        mXHINMEI_CD = Nothing
        mXSUB_CD = Nothing
        mXITF_CD = Nothing
        mXJAN_CD = Nothing
        mXMAKER_CD = Nothing
        mFRAC_BUNRUI = Nothing
        mXDAN_IN_PALLET = Nothing
        mXIN_RES_TYPE = Nothing


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
        mFHINMEI_CD = TO_STRING_NULLABLE(objRow("FHINMEI_CD"))
        mFHINMEI = TO_STRING_NULLABLE(objRow("FHINMEI"))
        mFTANI = TO_STRING_NULLABLE(objRow("FTANI"))
        mFDECIMAL_POINT = TO_INTEGER_NULLABLE(objRow("FDECIMAL_POINT"))
        mFNUM_IN_CASE = TO_DECIMAL_NULLABLE(objRow("FNUM_IN_CASE"))
        mFZAIKO_KUBUN = TO_INTEGER_NULLABLE(objRow("FZAIKO_KUBUN"))
        mFSHIKEN_YOUHI = TO_INTEGER_NULLABLE(objRow("FSHIKEN_YOUHI"))
        mFSHIKEN_TIMELIMIT = TO_INTEGER_NULLABLE(objRow("FSHIKEN_TIMELIMIT"))
        mFSHIKEN_READTIME = TO_INTEGER_NULLABLE(objRow("FSHIKEN_READTIME"))
        mFRITEST_TIMELIMIT = TO_INTEGER_NULLABLE(objRow("FRITEST_TIMELIMIT"))
        mFRITEST_FLAG = TO_INTEGER_NULLABLE(objRow("FRITEST_FLAG"))
        mFNUM_IN_PALLET = TO_DECIMAL_NULLABLE(objRow("FNUM_IN_PALLET"))
        mFINVENTORY_FLAG = TO_INTEGER_NULLABLE(objRow("FINVENTORY_FLAG"))
        mFSYSTEM_FLAG = TO_INTEGER_NULLABLE(objRow("FSYSTEM_FLAG"))
        mFHASU_MATOME = TO_INTEGER_NULLABLE(objRow("FHASU_MATOME"))
        mFDISP_ADDRESS = TO_STRING_NULLABLE(objRow("FDISP_ADDRESS"))
        mFHINMEI_KIKAKU = TO_STRING_NULLABLE(objRow("FHINMEI_KIKAKU"))
        mFRAC_FORM = TO_INTEGER_NULLABLE(objRow("FRAC_FORM"))
        mFENTRY_TERM_ID = TO_STRING_NULLABLE(objRow("FENTRY_TERM_ID"))
        mFENTRY_DT = TO_DATE_NULLABLE(objRow("FENTRY_DT"))
        mFENTRY_USER_ID = TO_STRING_NULLABLE(objRow("FENTRY_USER_ID"))
        mFENTRY_USER_NAME = TO_STRING_NULLABLE(objRow("FENTRY_USER_NAME"))
        mFUPDATE_TERM_ID = TO_STRING_NULLABLE(objRow("FUPDATE_TERM_ID"))
        mFUPDATE_USER_ID = TO_STRING_NULLABLE(objRow("FUPDATE_USER_ID"))
        mFUPDATE_USER_NAME = TO_STRING_NULLABLE(objRow("FUPDATE_USER_NAME"))
        mFUPDATE_DT = TO_DATE_NULLABLE(objRow("FUPDATE_DT"))
        mXABC_KANRI = TO_INTEGER_NULLABLE(objRow("XABC_KANRI"))
        mXPLANE_PACK_NUMBER = TO_INTEGER_NULLABLE(objRow("XPLANE_PACK_NUMBER"))
        mXWEIGHT_IN_CASE = TO_DECIMAL_NULLABLE(objRow("XWEIGHT_IN_CASE"))
        mXWEIGHT_IN_PALLET = TO_DECIMAL_NULLABLE(objRow("XWEIGHT_IN_PALLET"))
        mXHEIGHT_IN_CASE = TO_INTEGER_NULLABLE(objRow("XHEIGHT_IN_CASE"))
        mXHEIGHT_IN_PALLET = TO_INTEGER_NULLABLE(objRow("XHEIGHT_IN_PALLET"))
        mXARTICLE_TYPE_CODE = TO_INTEGER_NULLABLE(objRow("XARTICLE_TYPE_CODE"))
        mX24H_KENSA_AUTO_FLG = TO_INTEGER_NULLABLE(objRow("X24H_KENSA_AUTO_FLG"))
        mXHINMEI_CD = TO_STRING_NULLABLE(objRow("XHINMEI_CD"))
        mXSUB_CD = TO_INTEGER_NULLABLE(objRow("XSUB_CD"))
        mXITF_CD = TO_STRING_NULLABLE(objRow("XITF_CD"))
        mXJAN_CD = TO_STRING_NULLABLE(objRow("XJAN_CD"))
        mXMAKER_CD = TO_STRING_NULLABLE(objRow("XMAKER_CD"))
        mFRAC_BUNRUI = TO_STRING_NULLABLE(objRow("FRAC_BUNRUI"))
        mXDAN_IN_PALLET = TO_INTEGER_NULLABLE(objRow("XDAN_IN_PALLET"))
        mXIN_RES_TYPE = TO_INTEGER_NULLABLE(objRow("XIN_RES_TYPE"))


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
        strMsg &= "[ﾃｰﾌﾞﾙ名:品目ﾏｽﾀ]"
        If IsNotNull(FHINMEI_CD) Then
            strMsg &= "[品目ｺｰﾄﾞ:" & FHINMEI_CD & "]"
        End If
        If IsNotNull(FHINMEI) Then
            strMsg &= "[品名_正式名:" & FHINMEI & "]"
        End If
        If IsNotNull(FTANI) Then
            strMsg &= "[単位ｺｰﾄﾞ:" & FTANI & "]"
        End If
        If IsNotNull(FDECIMAL_POINT) Then
            strMsg &= "[小数点以下有効桁数:" & FDECIMAL_POINT & "]"
        End If
        If IsNotNull(FNUM_IN_CASE) Then
            strMsg &= "[正袋数量:" & FNUM_IN_CASE & "]"
        End If
        If IsNotNull(FZAIKO_KUBUN) Then
            strMsg &= "[在庫区分:" & FZAIKO_KUBUN & "]"
        End If
        If IsNotNull(FSHIKEN_YOUHI) Then
            strMsg &= "[受入試験有無:" & FSHIKEN_YOUHI & "]"
        End If
        If IsNotNull(FSHIKEN_TIMELIMIT) Then
            strMsg &= "[試験有効期限:" & FSHIKEN_TIMELIMIT & "]"
        End If
        If IsNotNull(FSHIKEN_READTIME) Then
            strMsg &= "[試験ﾘｰﾄﾞﾀｲﾑ:" & FSHIKEN_READTIME & "]"
        End If
        If IsNotNull(FRITEST_TIMELIMIT) Then
            strMsg &= "[ﾘﾃｽﾄ期間:" & FRITEST_TIMELIMIT & "]"
        End If
        If IsNotNull(FRITEST_FLAG) Then
            strMsg &= "[ﾘﾃｽﾄ対象品ﾌﾗｸﾞ:" & FRITEST_FLAG & "]"
        End If
        If IsNotNull(FNUM_IN_PALLET) Then
            strMsg &= "[PL毎積載数:" & FNUM_IN_PALLET & "]"
        End If
        If IsNotNull(FINVENTORY_FLAG) Then
            strMsg &= "[棚卸し対象ﾌﾗｸﾞ:" & FINVENTORY_FLAG & "]"
        End If
        If IsNotNull(FSYSTEM_FLAG) Then
            strMsg &= "[ｼｽﾃﾑ対象ﾌﾗｸﾞ:" & FSYSTEM_FLAG & "]"
        End If
        If IsNotNull(FHASU_MATOME) Then
            strMsg &= "[端数まとめﾌﾗｸﾞ:" & FHASU_MATOME & "]"
        End If
        If IsNotNull(FDISP_ADDRESS) Then
            strMsg &= "[表記用ｱﾄﾞﾚｽ:" & FDISP_ADDRESS & "]"
        End If
        If IsNotNull(FHINMEI_KIKAKU) Then
            strMsg &= "[品目_規格容量:" & FHINMEI_KIKAKU & "]"
        End If
        If IsNotNull(FRAC_FORM) Then
            strMsg &= "[棚形状種別:" & FRAC_FORM & "]"
        End If
        If IsNotNull(FENTRY_TERM_ID) Then
            strMsg &= "[登録端末ID:" & FENTRY_TERM_ID & "]"
        End If
        If IsNotNull(FENTRY_DT) Then
            strMsg &= "[登録日時:" & FENTRY_DT & "]"
        End If
        If IsNotNull(FENTRY_USER_ID) Then
            strMsg &= "[登録ﾕｰｻﾞｰID:" & FENTRY_USER_ID & "]"
        End If
        If IsNotNull(FENTRY_USER_NAME) Then
            strMsg &= "[登録ﾕｰｻﾞｰ名:" & FENTRY_USER_NAME & "]"
        End If
        If IsNotNull(FUPDATE_TERM_ID) Then
            strMsg &= "[更新端末ID:" & FUPDATE_TERM_ID & "]"
        End If
        If IsNotNull(FUPDATE_USER_ID) Then
            strMsg &= "[更新ﾕｰｻﾞｰID:" & FUPDATE_USER_ID & "]"
        End If
        If IsNotNull(FUPDATE_USER_NAME) Then
            strMsg &= "[更新ﾕｰｻﾞｰ名:" & FUPDATE_USER_NAME & "]"
        End If
        If IsNotNull(FUPDATE_DT) Then
            strMsg &= "[更新日時:" & FUPDATE_DT & "]"
        End If
        If IsNotNull(XABC_KANRI) Then
            strMsg &= "[ABC管理:" & XABC_KANRI & "]"
        End If
        If IsNotNull(XPLANE_PACK_NUMBER) Then
            strMsg &= "[平面梱数:" & XPLANE_PACK_NUMBER & "]"
        End If
        If IsNotNull(XWEIGHT_IN_CASE) Then
            strMsg &= "[梱重量:" & XWEIGHT_IN_CASE & "]"
        End If
        If IsNotNull(XWEIGHT_IN_PALLET) Then
            strMsg &= "[ﾊﾟﾚｯﾄあたりの重量:" & XWEIGHT_IN_PALLET & "]"
        End If
        If IsNotNull(XHEIGHT_IN_CASE) Then
            strMsg &= "[梱高さ:" & XHEIGHT_IN_CASE & "]"
        End If
        If IsNotNull(XHEIGHT_IN_PALLET) Then
            strMsg &= "[ﾊﾟﾚｯﾄ高さ:" & XHEIGHT_IN_PALLET & "]"
        End If
        If IsNotNull(XARTICLE_TYPE_CODE) Then
            strMsg &= "[品目種別(商品区分):" & XARTICLE_TYPE_CODE & "]"
        End If
        If IsNotNull(X24H_KENSA_AUTO_FLG) Then
            strMsg &= "[24H検査結果自動指定:" & X24H_KENSA_AUTO_FLG & "]"
        End If
        If IsNotNull(XHINMEI_CD) Then
            strMsg &= "[品目ｺｰﾄﾞ(正式品目ｺｰﾄﾞ):" & XHINMEI_CD & "]"
        End If
        If IsNotNull(XSUB_CD) Then
            strMsg &= "[ｻﾌﾞｺｰﾄﾞ:" & XSUB_CD & "]"
        End If
        If IsNotNull(XITF_CD) Then
            strMsg &= "[ITFｺｰﾄﾞ:" & XITF_CD & "]"
        End If
        If IsNotNull(XJAN_CD) Then
            strMsg &= "[JANｺｰﾄﾞ:" & XJAN_CD & "]"
        End If
        If IsNotNull(XMAKER_CD) Then
            strMsg &= "[ﾒｰｶ-ｺｰﾄﾞ:" & XMAKER_CD & "]"
        End If
        If IsNotNull(FRAC_BUNRUI) Then
            strMsg &= "[棚分類:" & FRAC_BUNRUI & "]"
        End If
        If IsNotNull(XDAN_IN_PALLET) Then
            strMsg &= "[1ﾊﾟﾚｯﾄの段数:" & XDAN_IN_PALLET & "]"
        End If
        If IsNotNull(XIN_RES_TYPE) Then
            strMsg &= "[品目別空棚引当ﾀｲﾌﾟ:" & XIN_RES_TYPE & "]"
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
