'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' 【名称】MaterialStreamﾃｰﾌﾞﾙｸﾗｽ
' 【機能】ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾏｽﾀﾃｰﾌﾞﾙｸﾗｽ
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
''' ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾏｽﾀﾃｰﾌﾞﾙｸﾗｽ
''' </summary>
Public Class TBL_XMST_DPL_PL
    Inherits clsTemplateTable

    '**********************************************************************************************
    '↓↓↓自動生成部
#Region "  ｸﾗｽ変数定義                  "
    'ﾌﾟﾛﾊﾟﾃｨ
    Private mobjAryMe As TBL_XMST_DPL_PL()                                       'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾏｽﾀ
    Private mstrUSER_SQL As String                                               'ﾕｰｻﾞｰSQL
    Private mORDER_BY As String                                                  'OrderBy句
    Private mWHERE As String                                                     'Where句
    Private mXDPL_PL_NO As Nullable(Of Integer)                                  'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号
    Private mXDPL_PL_NAME As String                                              'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ名称
    Private mXPROD_LINE As String                                                '生産ﾗｲﾝ№
    Private mFTRK_BUF_NO As Nullable(Of Integer)                                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    Private mXDPL_PL_EQ_ID_HINM As String                                        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ品種ｺｰﾄﾞ設備ID
    Private mXDPL_PL_EQ_ID_PL As String                                          'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ生産ﾊﾟﾚｯﾄ数設備ID
    Private mXDPL_PL_EQ_ID_HASU As String                                        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ端数ﾃﾞｰﾀ設備ID
    Private mXDPL_PL_EQ_ID_TRBL_HH As String                                     'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(時)
    Private mXDPL_PL_EQ_ID_TRBL_MM As String                                     'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(分)
    Private mXDPL_PL_EQ_ID_TRBL_SS As String                                     'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(秒)
    Private mXDPL_PL_EQ_ID_TRBL As String                                        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ件数設備ID
    Private mXDPL_PL_EQ_ID_COUNT As String                                       'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付数設備ID
    Private mXDPL_PL_EQ_ID_KADOU_HH As String                                    'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(時)
    Private mXDPL_PL_EQ_ID_KADOU_MM As String                                    'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(分)
    Private mXDPL_PL_EQ_ID_KADOU_SS As String                                    'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(秒)
    Private mXDPL_PL_EQ_ID_STKD As String                                        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動(指示)設備ID
    Private mXDPL_PL_EQ_ID_STED As String                                        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転終了(指示)設備ID
    Private mXDPL_PL_EQ_ID_STPT As String                                        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付ﾊﾟﾀｰﾝ設定(指示)設備ID
    Private mXDPL_PL_EQ_ID_STCL As String                                        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾃﾞｰﾀｸﾘｱ(指示)設備ID
    Private mXDPL_PL_EQ_ID_STKN As String                                        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾃﾞｰﾀｸﾘｱ完了(指示)設備ID
    Private mXDPL_PL_EQ_ID_STST As String                                        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転停止(指示)設備ID
    Private mXDPL_PL_EQ_ID_STHR As String                                        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ払出停止(指示)設備ID
    Private mXDPL_PL_EQ_ID_KIDO As String                                        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動ANS設備ID
    Private mXDPL_PL_EQ_ID_ONLN As String                                        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾝﾗｲﾝANS設備ID
    Private mXDPL_PL_EQ_ID_OFLN As String                                        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾌﾗｲﾝANS設備ID
    Private mXDPL_PL_EQ_ID_IJOU As String                                        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ一括異常設備ID
    Private mXDPL_PL_EQ_ID_KEHO As String                                        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ警報設備ID
    Private mXDPL_PL_EQ_ID_PLPT As String                                        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付ﾊﾟﾀｰﾝ設定一致設備ID
    Private mXDPL_PL_EQ_ID_REDY As String                                        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動可能設備ID
    Private mXDPL_PL_EQ_ID_SYRY As String                                        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ終了要求設備ID
    Private mFENTRY_DT As Nullable(Of Date)                                      '登録日時
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                  "
    ''' <summary>
    ''' ｼｽﾃﾑ変数 (自ｸﾗｽ型配列)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_XMST_DPL_PL()
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
    ''' ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号
    ''' </summary>
    Public Property XDPL_PL_NO() As Nullable(Of Integer)
        Get
            Return mXDPL_PL_NO
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXDPL_PL_NO = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ名称
    ''' </summary>
    Public Property XDPL_PL_NAME() As String
        Get
            Return mXDPL_PL_NAME
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_NAME = Value
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
    ''' ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ品種ｺｰﾄﾞ設備ID
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_HINM() As String
        Get
            Return mXDPL_PL_EQ_ID_HINM
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_HINM = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ生産ﾊﾟﾚｯﾄ数設備ID
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_PL() As String
        Get
            Return mXDPL_PL_EQ_ID_PL
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_PL = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ端数ﾃﾞｰﾀ設備ID
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_HASU() As String
        Get
            Return mXDPL_PL_EQ_ID_HASU
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_HASU = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(時)
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_TRBL_HH() As String
        Get
            Return mXDPL_PL_EQ_ID_TRBL_HH
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_TRBL_HH = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(分)
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_TRBL_MM() As String
        Get
            Return mXDPL_PL_EQ_ID_TRBL_MM
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_TRBL_MM = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(秒)
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_TRBL_SS() As String
        Get
            Return mXDPL_PL_EQ_ID_TRBL_SS
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_TRBL_SS = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ件数設備ID
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_TRBL() As String
        Get
            Return mXDPL_PL_EQ_ID_TRBL
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_TRBL = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付数設備ID
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_COUNT() As String
        Get
            Return mXDPL_PL_EQ_ID_COUNT
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_COUNT = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(時)
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_KADOU_HH() As String
        Get
            Return mXDPL_PL_EQ_ID_KADOU_HH
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_KADOU_HH = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(分)
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_KADOU_MM() As String
        Get
            Return mXDPL_PL_EQ_ID_KADOU_MM
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_KADOU_MM = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(秒)
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_KADOU_SS() As String
        Get
            Return mXDPL_PL_EQ_ID_KADOU_SS
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_KADOU_SS = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動(指示)設備ID
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_STKD() As String
        Get
            Return mXDPL_PL_EQ_ID_STKD
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_STKD = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転終了(指示)設備ID
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_STED() As String
        Get
            Return mXDPL_PL_EQ_ID_STED
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_STED = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付ﾊﾟﾀｰﾝ設定(指示)設備ID
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_STPT() As String
        Get
            Return mXDPL_PL_EQ_ID_STPT
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_STPT = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾃﾞｰﾀｸﾘｱ(指示)設備ID
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_STCL() As String
        Get
            Return mXDPL_PL_EQ_ID_STCL
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_STCL = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾃﾞｰﾀｸﾘｱ完了(指示)設備ID
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_STKN() As String
        Get
            Return mXDPL_PL_EQ_ID_STKN
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_STKN = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転停止(指示)設備ID
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_STST() As String
        Get
            Return mXDPL_PL_EQ_ID_STST
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_STST = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ払出停止(指示)設備ID
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_STHR() As String
        Get
            Return mXDPL_PL_EQ_ID_STHR
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_STHR = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動ANS設備ID
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_KIDO() As String
        Get
            Return mXDPL_PL_EQ_ID_KIDO
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_KIDO = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾝﾗｲﾝANS設備ID
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_ONLN() As String
        Get
            Return mXDPL_PL_EQ_ID_ONLN
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_ONLN = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾌﾗｲﾝANS設備ID
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_OFLN() As String
        Get
            Return mXDPL_PL_EQ_ID_OFLN
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_OFLN = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ一括異常設備ID
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_IJOU() As String
        Get
            Return mXDPL_PL_EQ_ID_IJOU
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_IJOU = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ警報設備ID
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_KEHO() As String
        Get
            Return mXDPL_PL_EQ_ID_KEHO
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_KEHO = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付ﾊﾟﾀｰﾝ設定一致設備ID
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_PLPT() As String
        Get
            Return mXDPL_PL_EQ_ID_PLPT
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_PLPT = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動可能設備ID
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_REDY() As String
        Get
            Return mXDPL_PL_EQ_ID_REDY
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_REDY = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ終了要求設備ID
    ''' </summary>
    Public Property XDPL_PL_EQ_ID_SYRY() As String
        Get
            Return mXDPL_PL_EQ_ID_SYRY
        End Get
        Set(ByVal Value As String)
            mXDPL_PL_EQ_ID_SYRY = Value
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
    Public Function GET_XMST_DPL_PL(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    XMST_DPL_PL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XDPL_PL_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_NO
            strSQL.Append(vbCrLf & "    AND XDPL_PL_NO = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号")
        End If
        If IsNull(XDPL_PL_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_NAME
            strSQL.Append(vbCrLf & "    AND XDPL_PL_NAME = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ名称")
        End If
        If IsNull(XPROD_LINE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPROD_LINE
            strSQL.Append(vbCrLf & "    AND XPROD_LINE = :" & UBound(strBindField) - 1 & " --生産ﾗｲﾝ№")
        End If
        If IsNull(FTRK_BUF_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNull(XDPL_PL_EQ_ID_HINM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_HINM
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_HINM = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ品種ｺｰﾄﾞ設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_PL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_PL
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_PL = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ生産ﾊﾟﾚｯﾄ数設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_HASU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_HASU
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_HASU = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ端数ﾃﾞｰﾀ設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_TRBL_HH) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL_HH
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_TRBL_HH = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(時)")
        End If
        If IsNull(XDPL_PL_EQ_ID_TRBL_MM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL_MM
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_TRBL_MM = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(分)")
        End If
        If IsNull(XDPL_PL_EQ_ID_TRBL_SS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL_SS
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_TRBL_SS = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(秒)")
        End If
        If IsNull(XDPL_PL_EQ_ID_TRBL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_TRBL = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ件数設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_COUNT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_COUNT
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_COUNT = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付数設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_KADOU_HH) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KADOU_HH
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_KADOU_HH = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(時)")
        End If
        If IsNull(XDPL_PL_EQ_ID_KADOU_MM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KADOU_MM
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_KADOU_MM = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(分)")
        End If
        If IsNull(XDPL_PL_EQ_ID_KADOU_SS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KADOU_SS
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_KADOU_SS = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(秒)")
        End If
        If IsNull(XDPL_PL_EQ_ID_STKD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STKD
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STKD = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動(指示)設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_STED) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STED
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STED = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転終了(指示)設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_STPT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STPT
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STPT = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付ﾊﾟﾀｰﾝ設定(指示)設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_STCL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STCL
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STCL = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾃﾞｰﾀｸﾘｱ(指示)設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_STKN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STKN
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STKN = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾃﾞｰﾀｸﾘｱ完了(指示)設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_STST) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STST
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STST = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転停止(指示)設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_STHR) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STHR
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STHR = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ払出停止(指示)設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_KIDO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KIDO
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_KIDO = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動ANS設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_ONLN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_ONLN
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_ONLN = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾝﾗｲﾝANS設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_OFLN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_OFLN
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_OFLN = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾌﾗｲﾝANS設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_IJOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_IJOU
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_IJOU = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ一括異常設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_KEHO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KEHO
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_KEHO = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ警報設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_PLPT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_PLPT
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_PLPT = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付ﾊﾟﾀｰﾝ設定一致設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_REDY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_REDY
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_REDY = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動可能設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_SYRY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_SYRY
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_SYRY = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ終了要求設備ID")
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
        strDataSetName = "XMST_DPL_PL"
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
    Public Function GET_XMST_DPL_PL_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    XMST_DPL_PL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XDPL_PL_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_NO
            strSQL.Append(vbCrLf & "    AND XDPL_PL_NO = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号")
        End If
        If IsNull(XDPL_PL_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_NAME
            strSQL.Append(vbCrLf & "    AND XDPL_PL_NAME = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ名称")
        End If
        If IsNull(XPROD_LINE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPROD_LINE
            strSQL.Append(vbCrLf & "    AND XPROD_LINE = :" & UBound(strBindField) - 1 & " --生産ﾗｲﾝ№")
        End If
        If IsNull(FTRK_BUF_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNull(XDPL_PL_EQ_ID_HINM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_HINM
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_HINM = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ品種ｺｰﾄﾞ設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_PL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_PL
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_PL = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ生産ﾊﾟﾚｯﾄ数設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_HASU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_HASU
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_HASU = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ端数ﾃﾞｰﾀ設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_TRBL_HH) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL_HH
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_TRBL_HH = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(時)")
        End If
        If IsNull(XDPL_PL_EQ_ID_TRBL_MM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL_MM
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_TRBL_MM = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(分)")
        End If
        If IsNull(XDPL_PL_EQ_ID_TRBL_SS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL_SS
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_TRBL_SS = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(秒)")
        End If
        If IsNull(XDPL_PL_EQ_ID_TRBL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_TRBL = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ件数設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_COUNT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_COUNT
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_COUNT = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付数設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_KADOU_HH) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KADOU_HH
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_KADOU_HH = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(時)")
        End If
        If IsNull(XDPL_PL_EQ_ID_KADOU_MM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KADOU_MM
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_KADOU_MM = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(分)")
        End If
        If IsNull(XDPL_PL_EQ_ID_KADOU_SS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KADOU_SS
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_KADOU_SS = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(秒)")
        End If
        If IsNull(XDPL_PL_EQ_ID_STKD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STKD
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STKD = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動(指示)設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_STED) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STED
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STED = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転終了(指示)設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_STPT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STPT
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STPT = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付ﾊﾟﾀｰﾝ設定(指示)設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_STCL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STCL
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STCL = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾃﾞｰﾀｸﾘｱ(指示)設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_STKN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STKN
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STKN = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾃﾞｰﾀｸﾘｱ完了(指示)設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_STST) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STST
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STST = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転停止(指示)設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_STHR) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STHR
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STHR = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ払出停止(指示)設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_KIDO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KIDO
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_KIDO = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動ANS設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_ONLN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_ONLN
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_ONLN = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾝﾗｲﾝANS設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_OFLN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_OFLN
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_OFLN = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾌﾗｲﾝANS設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_IJOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_IJOU
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_IJOU = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ一括異常設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_KEHO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KEHO
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_KEHO = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ警報設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_PLPT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_PLPT
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_PLPT = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付ﾊﾟﾀｰﾝ設定一致設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_REDY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_REDY
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_REDY = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動可能設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_SYRY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_SYRY
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_SYRY = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ終了要求設備ID")
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
        strDataSetName = "XMST_DPL_PL"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XMST_DPL_PL(Owner, objDb, objDbLog)
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
    Public Function GET_XMST_DPL_PL_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "XMST_DPL_PL"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_XMST_DPL_PL(Owner, objDb, objDbLog)
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
    Public Function GET_XMST_DPL_PL_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    XMST_DPL_PL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(XDPL_PL_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_NO
            strSQL.Append(vbCrLf & "    AND XDPL_PL_NO = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号")
        End If
        If IsNull(XDPL_PL_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_NAME
            strSQL.Append(vbCrLf & "    AND XDPL_PL_NAME = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ名称")
        End If
        If IsNull(XPROD_LINE) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPROD_LINE
            strSQL.Append(vbCrLf & "    AND XPROD_LINE = :" & UBound(strBindField) - 1 & " --生産ﾗｲﾝ№")
        End If
        If IsNull(FTRK_BUF_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNull(XDPL_PL_EQ_ID_HINM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_HINM
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_HINM = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ品種ｺｰﾄﾞ設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_PL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_PL
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_PL = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ生産ﾊﾟﾚｯﾄ数設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_HASU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_HASU
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_HASU = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ端数ﾃﾞｰﾀ設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_TRBL_HH) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL_HH
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_TRBL_HH = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(時)")
        End If
        If IsNull(XDPL_PL_EQ_ID_TRBL_MM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL_MM
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_TRBL_MM = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(分)")
        End If
        If IsNull(XDPL_PL_EQ_ID_TRBL_SS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL_SS
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_TRBL_SS = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(秒)")
        End If
        If IsNull(XDPL_PL_EQ_ID_TRBL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_TRBL = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ件数設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_COUNT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_COUNT
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_COUNT = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付数設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_KADOU_HH) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KADOU_HH
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_KADOU_HH = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(時)")
        End If
        If IsNull(XDPL_PL_EQ_ID_KADOU_MM) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KADOU_MM
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_KADOU_MM = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(分)")
        End If
        If IsNull(XDPL_PL_EQ_ID_KADOU_SS) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KADOU_SS
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_KADOU_SS = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(秒)")
        End If
        If IsNull(XDPL_PL_EQ_ID_STKD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STKD
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STKD = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動(指示)設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_STED) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STED
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STED = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転終了(指示)設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_STPT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STPT
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STPT = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付ﾊﾟﾀｰﾝ設定(指示)設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_STCL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STCL
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STCL = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾃﾞｰﾀｸﾘｱ(指示)設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_STKN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STKN
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STKN = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾃﾞｰﾀｸﾘｱ完了(指示)設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_STST) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STST
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STST = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転停止(指示)設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_STHR) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STHR
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STHR = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ払出停止(指示)設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_KIDO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KIDO
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_KIDO = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動ANS設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_ONLN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_ONLN
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_ONLN = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾝﾗｲﾝANS設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_OFLN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_OFLN
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_OFLN = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾌﾗｲﾝANS設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_IJOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_IJOU
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_IJOU = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ一括異常設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_KEHO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KEHO
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_KEHO = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ警報設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_PLPT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_PLPT
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_PLPT = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付ﾊﾟﾀｰﾝ設定一致設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_REDY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_REDY
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_REDY = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動可能設備ID")
        End If
        If IsNull(XDPL_PL_EQ_ID_SYRY) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_SYRY
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_SYRY = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ終了要求設備ID")
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
        strDataSetName = "XMST_DPL_PL"
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
    Public Sub UPDATE_XMST_DPL_PL()
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
        ElseIf IsNull(mXDPL_PL_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号]"
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
        strSQL.Append(vbCrLf & "    XMST_DPL_PL")
        strSQL.Append(vbCrLf & " SET")
        Dim intCount As Integer = 0
        If IsNull(mXDPL_PL_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_NO = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_NO = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_NO = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_NO = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_NAME = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ名称")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_NAME = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ名称")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_NAME = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ名称")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_NAME = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ名称")
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
        If IsNull(mXDPL_PL_EQ_ID_HINM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_HINM = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ品種ｺｰﾄﾞ設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_HINM = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ品種ｺｰﾄﾞ設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_HINM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_HINM = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ品種ｺｰﾄﾞ設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_HINM = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ品種ｺｰﾄﾞ設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_PL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_PL = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ生産ﾊﾟﾚｯﾄ数設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_PL = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ生産ﾊﾟﾚｯﾄ数設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_PL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_PL = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ生産ﾊﾟﾚｯﾄ数設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_PL = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ生産ﾊﾟﾚｯﾄ数設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_HASU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_HASU = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ端数ﾃﾞｰﾀ設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_HASU = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ端数ﾃﾞｰﾀ設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_HASU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_HASU = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ端数ﾃﾞｰﾀ設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_HASU = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ端数ﾃﾞｰﾀ設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_TRBL_HH) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_TRBL_HH = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(時)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_TRBL_HH = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(時)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL_HH
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_TRBL_HH = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(時)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_TRBL_HH = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(時)")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_TRBL_MM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_TRBL_MM = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(分)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_TRBL_MM = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(分)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL_MM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_TRBL_MM = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(分)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_TRBL_MM = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(分)")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_TRBL_SS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_TRBL_SS = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(秒)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_TRBL_SS = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(秒)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL_SS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_TRBL_SS = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(秒)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_TRBL_SS = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(秒)")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_TRBL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_TRBL = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ件数設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_TRBL = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ件数設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_TRBL = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ件数設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_TRBL = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ件数設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_COUNT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_COUNT = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付数設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_COUNT = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付数設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_COUNT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_COUNT = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付数設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_COUNT = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付数設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_KADOU_HH) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_KADOU_HH = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(時)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_KADOU_HH = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(時)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KADOU_HH
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_KADOU_HH = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(時)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_KADOU_HH = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(時)")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_KADOU_MM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_KADOU_MM = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(分)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_KADOU_MM = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(分)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KADOU_MM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_KADOU_MM = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(分)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_KADOU_MM = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(分)")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_KADOU_SS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_KADOU_SS = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(秒)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_KADOU_SS = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(秒)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KADOU_SS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_KADOU_SS = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(秒)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_KADOU_SS = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(秒)")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_STKD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_STKD = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動(指示)設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_STKD = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動(指示)設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STKD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_STKD = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動(指示)設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_STKD = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動(指示)設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_STED) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_STED = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転終了(指示)設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_STED = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転終了(指示)設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STED
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_STED = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転終了(指示)設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_STED = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転終了(指示)設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_STPT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_STPT = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付ﾊﾟﾀｰﾝ設定(指示)設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_STPT = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付ﾊﾟﾀｰﾝ設定(指示)設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STPT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_STPT = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付ﾊﾟﾀｰﾝ設定(指示)設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_STPT = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付ﾊﾟﾀｰﾝ設定(指示)設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_STCL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_STCL = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾃﾞｰﾀｸﾘｱ(指示)設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_STCL = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾃﾞｰﾀｸﾘｱ(指示)設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STCL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_STCL = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾃﾞｰﾀｸﾘｱ(指示)設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_STCL = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾃﾞｰﾀｸﾘｱ(指示)設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_STKN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_STKN = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾃﾞｰﾀｸﾘｱ完了(指示)設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_STKN = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾃﾞｰﾀｸﾘｱ完了(指示)設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STKN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_STKN = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾃﾞｰﾀｸﾘｱ完了(指示)設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_STKN = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾃﾞｰﾀｸﾘｱ完了(指示)設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_STST) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_STST = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転停止(指示)設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_STST = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転停止(指示)設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STST
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_STST = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転停止(指示)設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_STST = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転停止(指示)設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_STHR) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_STHR = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ払出停止(指示)設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_STHR = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ払出停止(指示)設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STHR
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_STHR = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ払出停止(指示)設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_STHR = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ払出停止(指示)設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_KIDO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_KIDO = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動ANS設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_KIDO = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動ANS設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KIDO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_KIDO = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動ANS設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_KIDO = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動ANS設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_ONLN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_ONLN = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾝﾗｲﾝANS設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_ONLN = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾝﾗｲﾝANS設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_ONLN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_ONLN = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾝﾗｲﾝANS設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_ONLN = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾝﾗｲﾝANS設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_OFLN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_OFLN = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾌﾗｲﾝANS設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_OFLN = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾌﾗｲﾝANS設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_OFLN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_OFLN = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾌﾗｲﾝANS設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_OFLN = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾌﾗｲﾝANS設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_IJOU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_IJOU = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ一括異常設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_IJOU = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ一括異常設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_IJOU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_IJOU = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ一括異常設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_IJOU = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ一括異常設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_KEHO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_KEHO = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ警報設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_KEHO = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ警報設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KEHO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_KEHO = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ警報設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_KEHO = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ警報設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_PLPT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_PLPT = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付ﾊﾟﾀｰﾝ設定一致設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_PLPT = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付ﾊﾟﾀｰﾝ設定一致設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_PLPT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_PLPT = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付ﾊﾟﾀｰﾝ設定一致設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_PLPT = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付ﾊﾟﾀｰﾝ設定一致設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_REDY) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_REDY = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動可能設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_REDY = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動可能設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_REDY
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_REDY = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動可能設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_REDY = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動可能設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_SYRY) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_SYRY = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ終了要求設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_SYRY = NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ終了要求設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_SYRY
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XDPL_PL_EQ_ID_SYRY = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ終了要求設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XDPL_PL_EQ_ID_SYRY = :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ終了要求設備ID")
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
        If IsNull(XDPL_PL_NO) = True Then
            strSQL.Append(vbCrLf & "    AND XDPL_PL_NO IS NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_NO
            strSQL.Append(vbCrLf & "    AND XDPL_PL_NO = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号")
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
    Public Sub ADD_XMST_DPL_PL()
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
        ElseIf IsNull(mXDPL_PL_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号]"
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
        strSQL.Append(vbCrLf & "    XMST_DPL_PL")
        strSQL.Append(vbCrLf & " VALUES(")
        Dim intCount As Integer = 0
        If IsNull(mXDPL_PL_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ名称")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ名称")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ名称")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ名称")
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
        If IsNull(mXDPL_PL_EQ_ID_HINM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ品種ｺｰﾄﾞ設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ品種ｺｰﾄﾞ設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_HINM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ品種ｺｰﾄﾞ設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ品種ｺｰﾄﾞ設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_PL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ生産ﾊﾟﾚｯﾄ数設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ生産ﾊﾟﾚｯﾄ数設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_PL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ生産ﾊﾟﾚｯﾄ数設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ生産ﾊﾟﾚｯﾄ数設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_HASU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ端数ﾃﾞｰﾀ設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ端数ﾃﾞｰﾀ設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_HASU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ端数ﾃﾞｰﾀ設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ端数ﾃﾞｰﾀ設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_TRBL_HH) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(時)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(時)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL_HH
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(時)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(時)")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_TRBL_MM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(分)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(分)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL_MM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(分)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(分)")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_TRBL_SS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(秒)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(秒)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL_SS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(秒)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(秒)")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_TRBL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ件数設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ件数設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ件数設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ件数設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_COUNT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付数設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付数設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_COUNT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付数設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付数設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_KADOU_HH) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(時)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(時)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KADOU_HH
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(時)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(時)")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_KADOU_MM) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(分)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(分)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KADOU_MM
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(分)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(分)")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_KADOU_SS) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(秒)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(秒)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KADOU_SS
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(秒)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(秒)")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_STKD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動(指示)設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動(指示)設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STKD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動(指示)設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動(指示)設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_STED) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転終了(指示)設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転終了(指示)設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STED
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転終了(指示)設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転終了(指示)設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_STPT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付ﾊﾟﾀｰﾝ設定(指示)設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付ﾊﾟﾀｰﾝ設定(指示)設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STPT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付ﾊﾟﾀｰﾝ設定(指示)設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付ﾊﾟﾀｰﾝ設定(指示)設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_STCL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾃﾞｰﾀｸﾘｱ(指示)設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾃﾞｰﾀｸﾘｱ(指示)設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STCL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾃﾞｰﾀｸﾘｱ(指示)設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾃﾞｰﾀｸﾘｱ(指示)設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_STKN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾃﾞｰﾀｸﾘｱ完了(指示)設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾃﾞｰﾀｸﾘｱ完了(指示)設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STKN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾃﾞｰﾀｸﾘｱ完了(指示)設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾃﾞｰﾀｸﾘｱ完了(指示)設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_STST) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転停止(指示)設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転停止(指示)設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STST
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転停止(指示)設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転停止(指示)設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_STHR) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ払出停止(指示)設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ払出停止(指示)設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STHR
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ払出停止(指示)設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ払出停止(指示)設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_KIDO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動ANS設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動ANS設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KIDO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動ANS設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動ANS設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_ONLN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾝﾗｲﾝANS設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾝﾗｲﾝANS設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_ONLN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾝﾗｲﾝANS設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾝﾗｲﾝANS設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_OFLN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾌﾗｲﾝANS設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾌﾗｲﾝANS設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_OFLN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾌﾗｲﾝANS設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾌﾗｲﾝANS設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_IJOU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ一括異常設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ一括異常設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_IJOU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ一括異常設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ一括異常設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_KEHO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ警報設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ警報設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KEHO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ警報設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ警報設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_PLPT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付ﾊﾟﾀｰﾝ設定一致設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付ﾊﾟﾀｰﾝ設定一致設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_PLPT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付ﾊﾟﾀｰﾝ設定一致設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付ﾊﾟﾀｰﾝ設定一致設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_REDY) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動可能設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動可能設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_REDY
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動可能設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動可能設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXDPL_PL_EQ_ID_SYRY) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ終了要求設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ終了要求設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_SYRY
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ終了要求設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ終了要求設備ID")
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
    Public Sub DELETE_XMST_DPL_PL()
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
        ElseIf IsNull(mXDPL_PL_NO) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号]"
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
        strSQL.Append(vbCrLf & "    XMST_DPL_PL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNull(XDPL_PL_NO) = True Then
            strSQL.Append(vbCrLf & "    AND XDPL_PL_NO IS NULL --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_NO
            strSQL.Append(vbCrLf & "    AND XDPL_PL_NO = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号")
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
    Public Sub DELETE_XMST_DPL_PL_ANY()
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
        strSQL.Append(vbCrLf & "    XMST_DPL_PL")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(XDPL_PL_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_NO
            strSQL.Append(vbCrLf & "    AND XDPL_PL_NO = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号")
        End If
        If IsNotNull(XDPL_PL_NAME) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_NAME
            strSQL.Append(vbCrLf & "    AND XDPL_PL_NAME = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ名称")
        End If
        If IsNotNull(XPROD_LINE) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXPROD_LINE
            strSQL.Append(vbCrLf & "    AND XPROD_LINE = :" & UBound(strBindField) - 1 & " --生産ﾗｲﾝ№")
        End If
        If IsNotNull(FTRK_BUF_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_HINM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_HINM
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_HINM = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ品種ｺｰﾄﾞ設備ID")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_PL) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_PL
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_PL = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ生産ﾊﾟﾚｯﾄ数設備ID")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_HASU) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_HASU
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_HASU = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ端数ﾃﾞｰﾀ設備ID")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_TRBL_HH) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL_HH
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_TRBL_HH = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(時)")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_TRBL_MM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL_MM
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_TRBL_MM = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(分)")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_TRBL_SS) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL_SS
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_TRBL_SS = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(秒)")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_TRBL) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_TRBL
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_TRBL = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ件数設備ID")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_COUNT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_COUNT
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_COUNT = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付数設備ID")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_KADOU_HH) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KADOU_HH
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_KADOU_HH = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(時)")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_KADOU_MM) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KADOU_MM
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_KADOU_MM = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(分)")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_KADOU_SS) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KADOU_SS
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_KADOU_SS = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(秒)")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_STKD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STKD
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STKD = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動(指示)設備ID")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_STED) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STED
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STED = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転終了(指示)設備ID")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_STPT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STPT
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STPT = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付ﾊﾟﾀｰﾝ設定(指示)設備ID")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_STCL) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STCL
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STCL = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾃﾞｰﾀｸﾘｱ(指示)設備ID")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_STKN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STKN
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STKN = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾃﾞｰﾀｸﾘｱ完了(指示)設備ID")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_STST) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STST
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STST = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転停止(指示)設備ID")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_STHR) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_STHR
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_STHR = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ払出停止(指示)設備ID")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_KIDO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KIDO
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_KIDO = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動ANS設備ID")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_ONLN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_ONLN
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_ONLN = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾝﾗｲﾝANS設備ID")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_OFLN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_OFLN
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_OFLN = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾌﾗｲﾝANS設備ID")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_IJOU) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_IJOU
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_IJOU = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ一括異常設備ID")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_KEHO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_KEHO
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_KEHO = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ警報設備ID")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_PLPT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_PLPT
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_PLPT = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付ﾊﾟﾀｰﾝ設定一致設備ID")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_REDY) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_REDY
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_REDY = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動可能設備ID")
        End If
        If IsNotNull(XDPL_PL_EQ_ID_SYRY) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXDPL_PL_EQ_ID_SYRY
            strSQL.Append(vbCrLf & "    AND XDPL_PL_EQ_ID_SYRY = :" & UBound(strBindField) - 1 & " --ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ終了要求設備ID")
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
        If IsNothing(objType.GetProperty("XDPL_PL_NO")) = False Then mXDPL_PL_NO = objObject.XDPL_PL_NO 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号
        If IsNothing(objType.GetProperty("XDPL_PL_NAME")) = False Then mXDPL_PL_NAME = objObject.XDPL_PL_NAME 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ名称
        If IsNothing(objType.GetProperty("XPROD_LINE")) = False Then mXPROD_LINE = objObject.XPROD_LINE '生産ﾗｲﾝ№
        If IsNothing(objType.GetProperty("FTRK_BUF_NO")) = False Then mFTRK_BUF_NO = objObject.FTRK_BUF_NO 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_HINM")) = False Then mXDPL_PL_EQ_ID_HINM = objObject.XDPL_PL_EQ_ID_HINM 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ品種ｺｰﾄﾞ設備ID
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_PL")) = False Then mXDPL_PL_EQ_ID_PL = objObject.XDPL_PL_EQ_ID_PL 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ生産ﾊﾟﾚｯﾄ数設備ID
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_HASU")) = False Then mXDPL_PL_EQ_ID_HASU = objObject.XDPL_PL_EQ_ID_HASU 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ端数ﾃﾞｰﾀ設備ID
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_TRBL_HH")) = False Then mXDPL_PL_EQ_ID_TRBL_HH = objObject.XDPL_PL_EQ_ID_TRBL_HH 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(時)
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_TRBL_MM")) = False Then mXDPL_PL_EQ_ID_TRBL_MM = objObject.XDPL_PL_EQ_ID_TRBL_MM 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(分)
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_TRBL_SS")) = False Then mXDPL_PL_EQ_ID_TRBL_SS = objObject.XDPL_PL_EQ_ID_TRBL_SS 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(秒)
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_TRBL")) = False Then mXDPL_PL_EQ_ID_TRBL = objObject.XDPL_PL_EQ_ID_TRBL 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ件数設備ID
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_COUNT")) = False Then mXDPL_PL_EQ_ID_COUNT = objObject.XDPL_PL_EQ_ID_COUNT 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付数設備ID
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_KADOU_HH")) = False Then mXDPL_PL_EQ_ID_KADOU_HH = objObject.XDPL_PL_EQ_ID_KADOU_HH 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(時)
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_KADOU_MM")) = False Then mXDPL_PL_EQ_ID_KADOU_MM = objObject.XDPL_PL_EQ_ID_KADOU_MM 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(分)
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_KADOU_SS")) = False Then mXDPL_PL_EQ_ID_KADOU_SS = objObject.XDPL_PL_EQ_ID_KADOU_SS 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(秒)
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_STKD")) = False Then mXDPL_PL_EQ_ID_STKD = objObject.XDPL_PL_EQ_ID_STKD 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動(指示)設備ID
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_STED")) = False Then mXDPL_PL_EQ_ID_STED = objObject.XDPL_PL_EQ_ID_STED 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転終了(指示)設備ID
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_STPT")) = False Then mXDPL_PL_EQ_ID_STPT = objObject.XDPL_PL_EQ_ID_STPT 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付ﾊﾟﾀｰﾝ設定(指示)設備ID
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_STCL")) = False Then mXDPL_PL_EQ_ID_STCL = objObject.XDPL_PL_EQ_ID_STCL 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾃﾞｰﾀｸﾘｱ(指示)設備ID
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_STKN")) = False Then mXDPL_PL_EQ_ID_STKN = objObject.XDPL_PL_EQ_ID_STKN 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾃﾞｰﾀｸﾘｱ完了(指示)設備ID
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_STST")) = False Then mXDPL_PL_EQ_ID_STST = objObject.XDPL_PL_EQ_ID_STST 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転停止(指示)設備ID
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_STHR")) = False Then mXDPL_PL_EQ_ID_STHR = objObject.XDPL_PL_EQ_ID_STHR 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ払出停止(指示)設備ID
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_KIDO")) = False Then mXDPL_PL_EQ_ID_KIDO = objObject.XDPL_PL_EQ_ID_KIDO 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動ANS設備ID
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_ONLN")) = False Then mXDPL_PL_EQ_ID_ONLN = objObject.XDPL_PL_EQ_ID_ONLN 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾝﾗｲﾝANS設備ID
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_OFLN")) = False Then mXDPL_PL_EQ_ID_OFLN = objObject.XDPL_PL_EQ_ID_OFLN 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾌﾗｲﾝANS設備ID
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_IJOU")) = False Then mXDPL_PL_EQ_ID_IJOU = objObject.XDPL_PL_EQ_ID_IJOU 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ一括異常設備ID
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_KEHO")) = False Then mXDPL_PL_EQ_ID_KEHO = objObject.XDPL_PL_EQ_ID_KEHO 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ警報設備ID
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_PLPT")) = False Then mXDPL_PL_EQ_ID_PLPT = objObject.XDPL_PL_EQ_ID_PLPT 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付ﾊﾟﾀｰﾝ設定一致設備ID
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_REDY")) = False Then mXDPL_PL_EQ_ID_REDY = objObject.XDPL_PL_EQ_ID_REDY 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動可能設備ID
        If IsNothing(objType.GetProperty("XDPL_PL_EQ_ID_SYRY")) = False Then mXDPL_PL_EQ_ID_SYRY = objObject.XDPL_PL_EQ_ID_SYRY 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ終了要求設備ID
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
        mXDPL_PL_NO = Nothing
        mXDPL_PL_NAME = Nothing
        mXPROD_LINE = Nothing
        mFTRK_BUF_NO = Nothing
        mXDPL_PL_EQ_ID_HINM = Nothing
        mXDPL_PL_EQ_ID_PL = Nothing
        mXDPL_PL_EQ_ID_HASU = Nothing
        mXDPL_PL_EQ_ID_TRBL_HH = Nothing
        mXDPL_PL_EQ_ID_TRBL_MM = Nothing
        mXDPL_PL_EQ_ID_TRBL_SS = Nothing
        mXDPL_PL_EQ_ID_TRBL = Nothing
        mXDPL_PL_EQ_ID_COUNT = Nothing
        mXDPL_PL_EQ_ID_KADOU_HH = Nothing
        mXDPL_PL_EQ_ID_KADOU_MM = Nothing
        mXDPL_PL_EQ_ID_KADOU_SS = Nothing
        mXDPL_PL_EQ_ID_STKD = Nothing
        mXDPL_PL_EQ_ID_STED = Nothing
        mXDPL_PL_EQ_ID_STPT = Nothing
        mXDPL_PL_EQ_ID_STCL = Nothing
        mXDPL_PL_EQ_ID_STKN = Nothing
        mXDPL_PL_EQ_ID_STST = Nothing
        mXDPL_PL_EQ_ID_STHR = Nothing
        mXDPL_PL_EQ_ID_KIDO = Nothing
        mXDPL_PL_EQ_ID_ONLN = Nothing
        mXDPL_PL_EQ_ID_OFLN = Nothing
        mXDPL_PL_EQ_ID_IJOU = Nothing
        mXDPL_PL_EQ_ID_KEHO = Nothing
        mXDPL_PL_EQ_ID_PLPT = Nothing
        mXDPL_PL_EQ_ID_REDY = Nothing
        mXDPL_PL_EQ_ID_SYRY = Nothing
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
        mXDPL_PL_NO = TO_INTEGER_NULLABLE(objRow("XDPL_PL_NO"))
        mXDPL_PL_NAME = TO_STRING_NULLABLE(objRow("XDPL_PL_NAME"))
        mXPROD_LINE = TO_STRING_NULLABLE(objRow("XPROD_LINE"))
        mFTRK_BUF_NO = TO_INTEGER_NULLABLE(objRow("FTRK_BUF_NO"))
        mXDPL_PL_EQ_ID_HINM = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_HINM"))
        mXDPL_PL_EQ_ID_PL = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_PL"))
        mXDPL_PL_EQ_ID_HASU = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_HASU"))
        mXDPL_PL_EQ_ID_TRBL_HH = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_TRBL_HH"))
        mXDPL_PL_EQ_ID_TRBL_MM = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_TRBL_MM"))
        mXDPL_PL_EQ_ID_TRBL_SS = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_TRBL_SS"))
        mXDPL_PL_EQ_ID_TRBL = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_TRBL"))
        mXDPL_PL_EQ_ID_COUNT = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_COUNT"))
        mXDPL_PL_EQ_ID_KADOU_HH = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_KADOU_HH"))
        mXDPL_PL_EQ_ID_KADOU_MM = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_KADOU_MM"))
        mXDPL_PL_EQ_ID_KADOU_SS = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_KADOU_SS"))
        mXDPL_PL_EQ_ID_STKD = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_STKD"))
        mXDPL_PL_EQ_ID_STED = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_STED"))
        mXDPL_PL_EQ_ID_STPT = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_STPT"))
        mXDPL_PL_EQ_ID_STCL = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_STCL"))
        mXDPL_PL_EQ_ID_STKN = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_STKN"))
        mXDPL_PL_EQ_ID_STST = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_STST"))
        mXDPL_PL_EQ_ID_STHR = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_STHR"))
        mXDPL_PL_EQ_ID_KIDO = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_KIDO"))
        mXDPL_PL_EQ_ID_ONLN = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_ONLN"))
        mXDPL_PL_EQ_ID_OFLN = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_OFLN"))
        mXDPL_PL_EQ_ID_IJOU = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_IJOU"))
        mXDPL_PL_EQ_ID_KEHO = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_KEHO"))
        mXDPL_PL_EQ_ID_PLPT = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_PLPT"))
        mXDPL_PL_EQ_ID_REDY = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_REDY"))
        mXDPL_PL_EQ_ID_SYRY = TO_STRING_NULLABLE(objRow("XDPL_PL_EQ_ID_SYRY"))
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
        strMsg &= "[ﾃｰﾌﾞﾙ名:ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾏｽﾀ]"
        If IsNotNull(XDPL_PL_NO) Then
            strMsg &= "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号:" & XDPL_PL_NO & "]"
        End If
        If IsNotNull(XDPL_PL_NAME) Then
            strMsg &= "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ名称:" & XDPL_PL_NAME & "]"
        End If
        If IsNotNull(XPROD_LINE) Then
            strMsg &= "[生産ﾗｲﾝ№:" & XPROD_LINE & "]"
        End If
        If IsNotNull(FTRK_BUF_NO) Then
            strMsg &= "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & FTRK_BUF_NO & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_HINM) Then
            strMsg &= "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ品種ｺｰﾄﾞ設備ID:" & XDPL_PL_EQ_ID_HINM & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_PL) Then
            strMsg &= "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ生産ﾊﾟﾚｯﾄ数設備ID:" & XDPL_PL_EQ_ID_PL & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_HASU) Then
            strMsg &= "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ端数ﾃﾞｰﾀ設備ID:" & XDPL_PL_EQ_ID_HASU & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_TRBL_HH) Then
            strMsg &= "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(時):" & XDPL_PL_EQ_ID_TRBL_HH & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_TRBL_MM) Then
            strMsg &= "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(分):" & XDPL_PL_EQ_ID_TRBL_MM & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_TRBL_SS) Then
            strMsg &= "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ時間設備ID(秒):" & XDPL_PL_EQ_ID_TRBL_SS & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_TRBL) Then
            strMsg &= "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾄﾗﾌﾞﾙ件数設備ID:" & XDPL_PL_EQ_ID_TRBL & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_COUNT) Then
            strMsg &= "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付数設備ID:" & XDPL_PL_EQ_ID_COUNT & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_KADOU_HH) Then
            strMsg &= "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(時):" & XDPL_PL_EQ_ID_KADOU_HH & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_KADOU_MM) Then
            strMsg &= "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(分):" & XDPL_PL_EQ_ID_KADOU_MM & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_KADOU_SS) Then
            strMsg &= "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転時間設備ID(秒):" & XDPL_PL_EQ_ID_KADOU_SS & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_STKD) Then
            strMsg &= "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動(指示)設備ID:" & XDPL_PL_EQ_ID_STKD & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_STED) Then
            strMsg &= "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転終了(指示)設備ID:" & XDPL_PL_EQ_ID_STED & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_STPT) Then
            strMsg &= "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付ﾊﾟﾀｰﾝ設定(指示)設備ID:" & XDPL_PL_EQ_ID_STPT & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_STCL) Then
            strMsg &= "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾃﾞｰﾀｸﾘｱ(指示)設備ID:" & XDPL_PL_EQ_ID_STCL & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_STKN) Then
            strMsg &= "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾃﾞｰﾀｸﾘｱ完了(指示)設備ID:" & XDPL_PL_EQ_ID_STKN & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_STST) Then
            strMsg &= "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転停止(指示)設備ID:" & XDPL_PL_EQ_ID_STST & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_STHR) Then
            strMsg &= "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ払出停止(指示)設備ID:" & XDPL_PL_EQ_ID_STHR & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_KIDO) Then
            strMsg &= "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動ANS設備ID:" & XDPL_PL_EQ_ID_KIDO & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_ONLN) Then
            strMsg &= "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾝﾗｲﾝANS設備ID:" & XDPL_PL_EQ_ID_ONLN & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_OFLN) Then
            strMsg &= "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾌﾗｲﾝANS設備ID:" & XDPL_PL_EQ_ID_OFLN & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_IJOU) Then
            strMsg &= "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ一括異常設備ID:" & XDPL_PL_EQ_ID_IJOU & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_KEHO) Then
            strMsg &= "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ警報設備ID:" & XDPL_PL_EQ_ID_KEHO & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_PLPT) Then
            strMsg &= "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ積付ﾊﾟﾀｰﾝ設定一致設備ID:" & XDPL_PL_EQ_ID_PLPT & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_REDY) Then
            strMsg &= "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ起動可能設備ID:" & XDPL_PL_EQ_ID_REDY & "]"
        End If
        If IsNotNull(XDPL_PL_EQ_ID_SYRY) Then
            strMsg &= "[ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ終了要求設備ID:" & XDPL_PL_EQ_ID_SYRY & "]"
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

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
