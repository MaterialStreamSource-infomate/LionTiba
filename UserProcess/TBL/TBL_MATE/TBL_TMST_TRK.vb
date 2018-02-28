'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD. All Rights Reserved
'
' 【名称】MaterialStreamﾃｰﾌﾞﾙｸﾗｽ
' 【機能】ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀﾃｰﾌﾞﾙｸﾗｽ
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
''' ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀﾃｰﾌﾞﾙｸﾗｽ
''' </summary>
Public Class TBL_TMST_TRK
    Inherits clsTemplateTable

    '**********************************************************************************************
    '↓↓↓自動生成部
#Region "  ｸﾗｽ変数定義                  "
    'ﾌﾟﾛﾊﾟﾃｨ
    Private mobjAryMe As TBL_TMST_TRK()                                          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ
    Private mstrUSER_SQL As String                                               'ﾕｰｻﾞｰSQL
    Private mORDER_BY As String                                                  'OrderBy句
    Private mWHERE As String                                                     'Where句
    Private mFTRK_BUF_NO As Nullable(Of Integer)                                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    Private mFBUF_NAME As String                                                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称
    Private mFBUF_KIND As Nullable(Of Integer)                                   'ﾊﾞｯﾌｧ種別
    Private mFNEW_IN_KUBUN As Nullable(Of Integer)                               '新規入庫ﾊﾞｯﾌｧ区分
    Private mFBUF_MAX As Nullable(Of Integer)                                    '最大ﾊﾞｯﾌｧ件数
    Private mFBUF_LOG_FLAG As Nullable(Of Integer)                               'ﾛｸﾞ有無ﾌﾗｸﾞ
    Private mFRAC_RETU_MAX As Nullable(Of Integer)                               '最大列数
    Private mFRAC_REN_MAX As Nullable(Of Integer)                                '最大連数
    Private mFRAC_DAN_MAX As Nullable(Of Integer)                                '最大段数
    Private mFRAC_EDA_MAX As Nullable(Of Integer)                                '最大枝数
    Private mFPLACE_CD As Nullable(Of Integer)                                   '保管場所ｺｰﾄﾞ
    Private mFAREA_CD As Nullable(Of Integer)                                    'ｴﾘｱｺｰﾄﾞ
    Private mXEQ_ID_MOD As String                                                'ﾓｰﾄﾞ設備ID
    Private mXEQ_ID_STN As String                                                'ST載荷設備ID
    Private mXTRK_BUF_NO_IN_HIRA As Nullable(Of Integer)                         '入庫設定時平置
    Private mXTRK_BUF_NO_OUT_HIRA As Nullable(Of Integer)                        '出庫設定時平置
    Private mXADRS_IN As String                                                  '入庫指示ｱﾄﾞﾚｽ
    Private mXADRS_OUT As String                                                 '出庫指示ｱﾄﾞﾚｽ
    Private mXADRS_HANSOU As String                                              '搬送指示ｱﾄﾞﾚｽ
    Private mXADRS_PLCTRK05 As String                                            'PLCﾄﾗｯｷﾝｸﾞｱﾄﾞﾚｽ05
    Private mXADRS_PLCTRK04 As String                                            'PLCﾄﾗｯｷﾝｸﾞｱﾄﾞﾚｽ04
    Private mXADRS_PALLET01 As String                                            'ﾊﾟﾚｯﾄ数ｱﾄﾞﾚｽ01
    Private mXADRS_PALLET02 As String                                            'ﾊﾟﾚｯﾄ数ｱﾄﾞﾚｽ02
    Private mXADRS_YOTEI01 As String                                             '予定数ｱﾄﾞﾚｽ01
    Private mXADRS_YOTEI02 As String                                             '予定数ｱﾄﾞﾚｽ02
    Private mXLS_NO As Nullable(Of Integer)                                      'L/S番号
    Private mXEQ_ID_IN_FR As String                                              '入庫要求前設備ID
    Private mXEQ_ID_IN_BK As String                                              '入庫要求後設備ID
    Private mXEQ_ID_HASU_FR As String                                            '端数前設備ID
    Private mXEQ_ID_HASU_BK As String                                            '端数後設備ID
    Private mXTRK_BUF_NO_CONV As Nullable(Of Integer)                            'ｺﾝﾍﾞﾔ関連付け
    Private mXEQ_ID_IRI_YOUKYU As String                                         '入棚入庫要求設備ID
    Private mXEQ_ID_OUT_YOUKYU As String                                         '出庫要求設備ID
    Private mXEQ_ID_OUT_BUF As String                                            '出棚ﾊﾞｯﾌｧ空設備ID
    Private mXEQ_ID_OUT_END As String                                            '出庫完了設備ID
    Private mXEQ_ID_B_HENSEI As String                                           '編成№表示
    Private mXEQ_ID_B_OUTEND As String                                           '出庫完了ﾗﾝﾌﾟ
    Private mXEQ_ID_B_TUMIEND As String                                          '積込完了ﾎﾞﾀﾝ
    Private mXMAINTE_KUBUN As Nullable(Of Integer)                               'ﾒﾝﾃﾅﾝｽ区分
    Private mXMAINTE_ORDER As Nullable(Of Integer)                               'ﾒﾝﾃﾅﾝｽ区分順
    Private mXMAINTE_NAME As String                                              'ﾒﾝﾃﾅﾝｽ表示名
    Private mXBUF_NAME_DTL As String                                             'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(正式名称)
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                  "
    ''' <summary>
    ''' ｼｽﾃﾑ変数 (自ｸﾗｽ型配列)
    ''' </summary>
    Public ReadOnly Property ARYME() As TBL_TMST_TRK()
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
    ''' ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称
    ''' </summary>
    Public Property FBUF_NAME() As String
        Get
            Return mFBUF_NAME
        End Get
        Set(ByVal Value As String)
            mFBUF_NAME = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾊﾞｯﾌｧ種別
    ''' </summary>
    Public Property FBUF_KIND() As Nullable(Of Integer)
        Get
            Return mFBUF_KIND
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFBUF_KIND = Value
        End Set
    End Property
    ''' <summary>
    ''' 新規入庫ﾊﾞｯﾌｧ区分
    ''' </summary>
    Public Property FNEW_IN_KUBUN() As Nullable(Of Integer)
        Get
            Return mFNEW_IN_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFNEW_IN_KUBUN = Value
        End Set
    End Property
    ''' <summary>
    ''' 最大ﾊﾞｯﾌｧ件数
    ''' </summary>
    Public Property FBUF_MAX() As Nullable(Of Integer)
        Get
            Return mFBUF_MAX
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFBUF_MAX = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾛｸﾞ有無ﾌﾗｸﾞ
    ''' </summary>
    Public Property FBUF_LOG_FLAG() As Nullable(Of Integer)
        Get
            Return mFBUF_LOG_FLAG
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFBUF_LOG_FLAG = Value
        End Set
    End Property
    ''' <summary>
    ''' 最大列数
    ''' </summary>
    Public Property FRAC_RETU_MAX() As Nullable(Of Integer)
        Get
            Return mFRAC_RETU_MAX
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRAC_RETU_MAX = Value
        End Set
    End Property
    ''' <summary>
    ''' 最大連数
    ''' </summary>
    Public Property FRAC_REN_MAX() As Nullable(Of Integer)
        Get
            Return mFRAC_REN_MAX
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRAC_REN_MAX = Value
        End Set
    End Property
    ''' <summary>
    ''' 最大段数
    ''' </summary>
    Public Property FRAC_DAN_MAX() As Nullable(Of Integer)
        Get
            Return mFRAC_DAN_MAX
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRAC_DAN_MAX = Value
        End Set
    End Property
    ''' <summary>
    ''' 最大枝数
    ''' </summary>
    Public Property FRAC_EDA_MAX() As Nullable(Of Integer)
        Get
            Return mFRAC_EDA_MAX
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mFRAC_EDA_MAX = Value
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
    ''' ﾓｰﾄﾞ設備ID
    ''' </summary>
    Public Property XEQ_ID_MOD() As String
        Get
            Return mXEQ_ID_MOD
        End Get
        Set(ByVal Value As String)
            mXEQ_ID_MOD = Value
        End Set
    End Property
    ''' <summary>
    ''' ST載荷設備ID
    ''' </summary>
    Public Property XEQ_ID_STN() As String
        Get
            Return mXEQ_ID_STN
        End Get
        Set(ByVal Value As String)
            mXEQ_ID_STN = Value
        End Set
    End Property
    ''' <summary>
    ''' 入庫設定時平置
    ''' </summary>
    Public Property XTRK_BUF_NO_IN_HIRA() As Nullable(Of Integer)
        Get
            Return mXTRK_BUF_NO_IN_HIRA
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXTRK_BUF_NO_IN_HIRA = Value
        End Set
    End Property
    ''' <summary>
    ''' 出庫設定時平置
    ''' </summary>
    Public Property XTRK_BUF_NO_OUT_HIRA() As Nullable(Of Integer)
        Get
            Return mXTRK_BUF_NO_OUT_HIRA
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXTRK_BUF_NO_OUT_HIRA = Value
        End Set
    End Property
    ''' <summary>
    ''' 入庫指示ｱﾄﾞﾚｽ
    ''' </summary>
    Public Property XADRS_IN() As String
        Get
            Return mXADRS_IN
        End Get
        Set(ByVal Value As String)
            mXADRS_IN = Value
        End Set
    End Property
    ''' <summary>
    ''' 出庫指示ｱﾄﾞﾚｽ
    ''' </summary>
    Public Property XADRS_OUT() As String
        Get
            Return mXADRS_OUT
        End Get
        Set(ByVal Value As String)
            mXADRS_OUT = Value
        End Set
    End Property
    ''' <summary>
    ''' 搬送指示ｱﾄﾞﾚｽ
    ''' </summary>
    Public Property XADRS_HANSOU() As String
        Get
            Return mXADRS_HANSOU
        End Get
        Set(ByVal Value As String)
            mXADRS_HANSOU = Value
        End Set
    End Property
    ''' <summary>
    ''' PLCﾄﾗｯｷﾝｸﾞｱﾄﾞﾚｽ05
    ''' </summary>
    Public Property XADRS_PLCTRK05() As String
        Get
            Return mXADRS_PLCTRK05
        End Get
        Set(ByVal Value As String)
            mXADRS_PLCTRK05 = Value
        End Set
    End Property
    ''' <summary>
    ''' PLCﾄﾗｯｷﾝｸﾞｱﾄﾞﾚｽ04
    ''' </summary>
    Public Property XADRS_PLCTRK04() As String
        Get
            Return mXADRS_PLCTRK04
        End Get
        Set(ByVal Value As String)
            mXADRS_PLCTRK04 = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾊﾟﾚｯﾄ数ｱﾄﾞﾚｽ01
    ''' </summary>
    Public Property XADRS_PALLET01() As String
        Get
            Return mXADRS_PALLET01
        End Get
        Set(ByVal Value As String)
            mXADRS_PALLET01 = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾊﾟﾚｯﾄ数ｱﾄﾞﾚｽ02
    ''' </summary>
    Public Property XADRS_PALLET02() As String
        Get
            Return mXADRS_PALLET02
        End Get
        Set(ByVal Value As String)
            mXADRS_PALLET02 = Value
        End Set
    End Property
    ''' <summary>
    ''' 予定数ｱﾄﾞﾚｽ01
    ''' </summary>
    Public Property XADRS_YOTEI01() As String
        Get
            Return mXADRS_YOTEI01
        End Get
        Set(ByVal Value As String)
            mXADRS_YOTEI01 = Value
        End Set
    End Property
    ''' <summary>
    ''' 予定数ｱﾄﾞﾚｽ02
    ''' </summary>
    Public Property XADRS_YOTEI02() As String
        Get
            Return mXADRS_YOTEI02
        End Get
        Set(ByVal Value As String)
            mXADRS_YOTEI02 = Value
        End Set
    End Property
    ''' <summary>
    ''' L/S番号
    ''' </summary>
    Public Property XLS_NO() As Nullable(Of Integer)
        Get
            Return mXLS_NO
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXLS_NO = Value
        End Set
    End Property
    ''' <summary>
    ''' 入庫要求前設備ID
    ''' </summary>
    Public Property XEQ_ID_IN_FR() As String
        Get
            Return mXEQ_ID_IN_FR
        End Get
        Set(ByVal Value As String)
            mXEQ_ID_IN_FR = Value
        End Set
    End Property
    ''' <summary>
    ''' 入庫要求後設備ID
    ''' </summary>
    Public Property XEQ_ID_IN_BK() As String
        Get
            Return mXEQ_ID_IN_BK
        End Get
        Set(ByVal Value As String)
            mXEQ_ID_IN_BK = Value
        End Set
    End Property
    ''' <summary>
    ''' 端数前設備ID
    ''' </summary>
    Public Property XEQ_ID_HASU_FR() As String
        Get
            Return mXEQ_ID_HASU_FR
        End Get
        Set(ByVal Value As String)
            mXEQ_ID_HASU_FR = Value
        End Set
    End Property
    ''' <summary>
    ''' 端数後設備ID
    ''' </summary>
    Public Property XEQ_ID_HASU_BK() As String
        Get
            Return mXEQ_ID_HASU_BK
        End Get
        Set(ByVal Value As String)
            mXEQ_ID_HASU_BK = Value
        End Set
    End Property
    ''' <summary>
    ''' ｺﾝﾍﾞﾔ関連付け
    ''' </summary>
    Public Property XTRK_BUF_NO_CONV() As Nullable(Of Integer)
        Get
            Return mXTRK_BUF_NO_CONV
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXTRK_BUF_NO_CONV = Value
        End Set
    End Property
    ''' <summary>
    ''' 入棚入庫要求設備ID
    ''' </summary>
    Public Property XEQ_ID_IRI_YOUKYU() As String
        Get
            Return mXEQ_ID_IRI_YOUKYU
        End Get
        Set(ByVal Value As String)
            mXEQ_ID_IRI_YOUKYU = Value
        End Set
    End Property
    ''' <summary>
    ''' 出庫要求設備ID
    ''' </summary>
    Public Property XEQ_ID_OUT_YOUKYU() As String
        Get
            Return mXEQ_ID_OUT_YOUKYU
        End Get
        Set(ByVal Value As String)
            mXEQ_ID_OUT_YOUKYU = Value
        End Set
    End Property
    ''' <summary>
    ''' 出棚ﾊﾞｯﾌｧ空設備ID
    ''' </summary>
    Public Property XEQ_ID_OUT_BUF() As String
        Get
            Return mXEQ_ID_OUT_BUF
        End Get
        Set(ByVal Value As String)
            mXEQ_ID_OUT_BUF = Value
        End Set
    End Property
    ''' <summary>
    ''' 出庫完了設備ID
    ''' </summary>
    Public Property XEQ_ID_OUT_END() As String
        Get
            Return mXEQ_ID_OUT_END
        End Get
        Set(ByVal Value As String)
            mXEQ_ID_OUT_END = Value
        End Set
    End Property
    ''' <summary>
    ''' 編成№表示
    ''' </summary>
    Public Property XEQ_ID_B_HENSEI() As String
        Get
            Return mXEQ_ID_B_HENSEI
        End Get
        Set(ByVal Value As String)
            mXEQ_ID_B_HENSEI = Value
        End Set
    End Property
    ''' <summary>
    ''' 出庫完了ﾗﾝﾌﾟ
    ''' </summary>
    Public Property XEQ_ID_B_OUTEND() As String
        Get
            Return mXEQ_ID_B_OUTEND
        End Get
        Set(ByVal Value As String)
            mXEQ_ID_B_OUTEND = Value
        End Set
    End Property
    ''' <summary>
    ''' 積込完了ﾎﾞﾀﾝ
    ''' </summary>
    Public Property XEQ_ID_B_TUMIEND() As String
        Get
            Return mXEQ_ID_B_TUMIEND
        End Get
        Set(ByVal Value As String)
            mXEQ_ID_B_TUMIEND = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾒﾝﾃﾅﾝｽ区分
    ''' </summary>
    Public Property XMAINTE_KUBUN() As Nullable(Of Integer)
        Get
            Return mXMAINTE_KUBUN
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXMAINTE_KUBUN = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾒﾝﾃﾅﾝｽ区分順
    ''' </summary>
    Public Property XMAINTE_ORDER() As Nullable(Of Integer)
        Get
            Return mXMAINTE_ORDER
        End Get
        Set(ByVal Value As Nullable(Of Integer))
            mXMAINTE_ORDER = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾒﾝﾃﾅﾝｽ表示名
    ''' </summary>
    Public Property XMAINTE_NAME() As String
        Get
            Return mXMAINTE_NAME
        End Get
        Set(ByVal Value As String)
            mXMAINTE_NAME = Value
        End Set
    End Property
    ''' <summary>
    ''' ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(正式名称)
    ''' </summary>
    Public Property XBUF_NAME_DTL() As String
        Get
            Return mXBUF_NAME_DTL
        End Get
        Set(ByVal Value As String)
            mXBUF_NAME_DTL = Value
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
    Public Function GET_TMST_TRK(Optional ByVal blnNotFoundError As Boolean = True) As RetCode
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
        strSQL.Append(vbCrLf & "    TMST_TRK")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FTRK_BUF_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNull(FBUF_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_NAME
            strSQL.Append(vbCrLf & "    AND FBUF_NAME = :" & UBound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称")
        End If
        If IsNull(FBUF_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_KIND
            strSQL.Append(vbCrLf & "    AND FBUF_KIND = :" & UBound(strBindField) - 1 & " --ﾊﾞｯﾌｧ種別")
        End If
        If IsNull(FNEW_IN_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFNEW_IN_KUBUN
            strSQL.Append(vbCrLf & "    AND FNEW_IN_KUBUN = :" & UBound(strBindField) - 1 & " --新規入庫ﾊﾞｯﾌｧ区分")
        End If
        If IsNull(FBUF_MAX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_MAX
            strSQL.Append(vbCrLf & "    AND FBUF_MAX = :" & UBound(strBindField) - 1 & " --最大ﾊﾞｯﾌｧ件数")
        End If
        If IsNull(FBUF_LOG_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_LOG_FLAG
            strSQL.Append(vbCrLf & "    AND FBUF_LOG_FLAG = :" & UBound(strBindField) - 1 & " --ﾛｸﾞ有無ﾌﾗｸﾞ")
        End If
        If IsNull(FRAC_RETU_MAX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_RETU_MAX
            strSQL.Append(vbCrLf & "    AND FRAC_RETU_MAX = :" & UBound(strBindField) - 1 & " --最大列数")
        End If
        If IsNull(FRAC_REN_MAX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_REN_MAX
            strSQL.Append(vbCrLf & "    AND FRAC_REN_MAX = :" & UBound(strBindField) - 1 & " --最大連数")
        End If
        If IsNull(FRAC_DAN_MAX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_DAN_MAX
            strSQL.Append(vbCrLf & "    AND FRAC_DAN_MAX = :" & UBound(strBindField) - 1 & " --最大段数")
        End If
        If IsNull(FRAC_EDA_MAX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_EDA_MAX
            strSQL.Append(vbCrLf & "    AND FRAC_EDA_MAX = :" & UBound(strBindField) - 1 & " --最大枝数")
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
        If IsNull(XEQ_ID_MOD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_MOD
            strSQL.Append(vbCrLf & "    AND XEQ_ID_MOD = :" & UBound(strBindField) - 1 & " --ﾓｰﾄﾞ設備ID")
        End If
        If IsNull(XEQ_ID_STN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_STN
            strSQL.Append(vbCrLf & "    AND XEQ_ID_STN = :" & UBound(strBindField) - 1 & " --ST載荷設備ID")
        End If
        If IsNull(XTRK_BUF_NO_IN_HIRA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_IN_HIRA
            strSQL.Append(vbCrLf & "    AND XTRK_BUF_NO_IN_HIRA = :" & UBound(strBindField) - 1 & " --入庫設定時平置")
        End If
        If IsNull(XTRK_BUF_NO_OUT_HIRA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_OUT_HIRA
            strSQL.Append(vbCrLf & "    AND XTRK_BUF_NO_OUT_HIRA = :" & UBound(strBindField) - 1 & " --出庫設定時平置")
        End If
        If IsNull(XADRS_IN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_IN
            strSQL.Append(vbCrLf & "    AND XADRS_IN = :" & UBound(strBindField) - 1 & " --入庫指示ｱﾄﾞﾚｽ")
        End If
        If IsNull(XADRS_OUT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_OUT
            strSQL.Append(vbCrLf & "    AND XADRS_OUT = :" & UBound(strBindField) - 1 & " --出庫指示ｱﾄﾞﾚｽ")
        End If
        If IsNull(XADRS_HANSOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_HANSOU
            strSQL.Append(vbCrLf & "    AND XADRS_HANSOU = :" & UBound(strBindField) - 1 & " --搬送指示ｱﾄﾞﾚｽ")
        End If
        If IsNull(XADRS_PLCTRK05) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PLCTRK05
            strSQL.Append(vbCrLf & "    AND XADRS_PLCTRK05 = :" & UBound(strBindField) - 1 & " --PLCﾄﾗｯｷﾝｸﾞｱﾄﾞﾚｽ05")
        End If
        If IsNull(XADRS_PLCTRK04) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PLCTRK04
            strSQL.Append(vbCrLf & "    AND XADRS_PLCTRK04 = :" & UBound(strBindField) - 1 & " --PLCﾄﾗｯｷﾝｸﾞｱﾄﾞﾚｽ04")
        End If
        If IsNull(XADRS_PALLET01) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PALLET01
            strSQL.Append(vbCrLf & "    AND XADRS_PALLET01 = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄ数ｱﾄﾞﾚｽ01")
        End If
        If IsNull(XADRS_PALLET02) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PALLET02
            strSQL.Append(vbCrLf & "    AND XADRS_PALLET02 = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄ数ｱﾄﾞﾚｽ02")
        End If
        If IsNull(XADRS_YOTEI01) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_YOTEI01
            strSQL.Append(vbCrLf & "    AND XADRS_YOTEI01 = :" & UBound(strBindField) - 1 & " --予定数ｱﾄﾞﾚｽ01")
        End If
        If IsNull(XADRS_YOTEI02) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_YOTEI02
            strSQL.Append(vbCrLf & "    AND XADRS_YOTEI02 = :" & UBound(strBindField) - 1 & " --予定数ｱﾄﾞﾚｽ02")
        End If
        If IsNull(XLS_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXLS_NO
            strSQL.Append(vbCrLf & "    AND XLS_NO = :" & UBound(strBindField) - 1 & " --L/S番号")
        End If
        If IsNull(XEQ_ID_IN_FR) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_IN_FR
            strSQL.Append(vbCrLf & "    AND XEQ_ID_IN_FR = :" & UBound(strBindField) - 1 & " --入庫要求前設備ID")
        End If
        If IsNull(XEQ_ID_IN_BK) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_IN_BK
            strSQL.Append(vbCrLf & "    AND XEQ_ID_IN_BK = :" & UBound(strBindField) - 1 & " --入庫要求後設備ID")
        End If
        If IsNull(XEQ_ID_HASU_FR) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_HASU_FR
            strSQL.Append(vbCrLf & "    AND XEQ_ID_HASU_FR = :" & UBound(strBindField) - 1 & " --端数前設備ID")
        End If
        If IsNull(XEQ_ID_HASU_BK) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_HASU_BK
            strSQL.Append(vbCrLf & "    AND XEQ_ID_HASU_BK = :" & UBound(strBindField) - 1 & " --端数後設備ID")
        End If
        If IsNull(XTRK_BUF_NO_CONV) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_CONV
            strSQL.Append(vbCrLf & "    AND XTRK_BUF_NO_CONV = :" & UBound(strBindField) - 1 & " --ｺﾝﾍﾞﾔ関連付け")
        End If
        If IsNull(XEQ_ID_IRI_YOUKYU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_IRI_YOUKYU
            strSQL.Append(vbCrLf & "    AND XEQ_ID_IRI_YOUKYU = :" & UBound(strBindField) - 1 & " --入棚入庫要求設備ID")
        End If
        If IsNull(XEQ_ID_OUT_YOUKYU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_OUT_YOUKYU
            strSQL.Append(vbCrLf & "    AND XEQ_ID_OUT_YOUKYU = :" & UBound(strBindField) - 1 & " --出庫要求設備ID")
        End If
        If IsNull(XEQ_ID_OUT_BUF) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_OUT_BUF
            strSQL.Append(vbCrLf & "    AND XEQ_ID_OUT_BUF = :" & UBound(strBindField) - 1 & " --出棚ﾊﾞｯﾌｧ空設備ID")
        End If
        If IsNull(XEQ_ID_OUT_END) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_OUT_END
            strSQL.Append(vbCrLf & "    AND XEQ_ID_OUT_END = :" & UBound(strBindField) - 1 & " --出庫完了設備ID")
        End If
        If IsNull(XEQ_ID_B_HENSEI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_HENSEI
            strSQL.Append(vbCrLf & "    AND XEQ_ID_B_HENSEI = :" & UBound(strBindField) - 1 & " --編成№表示")
        End If
        If IsNull(XEQ_ID_B_OUTEND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_OUTEND
            strSQL.Append(vbCrLf & "    AND XEQ_ID_B_OUTEND = :" & UBound(strBindField) - 1 & " --出庫完了ﾗﾝﾌﾟ")
        End If
        If IsNull(XEQ_ID_B_TUMIEND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_TUMIEND
            strSQL.Append(vbCrLf & "    AND XEQ_ID_B_TUMIEND = :" & UBound(strBindField) - 1 & " --積込完了ﾎﾞﾀﾝ")
        End If
        If IsNull(XMAINTE_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAINTE_KUBUN
            strSQL.Append(vbCrLf & "    AND XMAINTE_KUBUN = :" & UBound(strBindField) - 1 & " --ﾒﾝﾃﾅﾝｽ区分")
        End If
        If IsNull(XMAINTE_ORDER) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAINTE_ORDER
            strSQL.Append(vbCrLf & "    AND XMAINTE_ORDER = :" & UBound(strBindField) - 1 & " --ﾒﾝﾃﾅﾝｽ区分順")
        End If
        If IsNull(XMAINTE_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAINTE_NAME
            strSQL.Append(vbCrLf & "    AND XMAINTE_NAME = :" & UBound(strBindField) - 1 & " --ﾒﾝﾃﾅﾝｽ表示名")
        End If
        If IsNull(XBUF_NAME_DTL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBUF_NAME_DTL
            strSQL.Append(vbCrLf & "    AND XBUF_NAME_DTL = :" & UBound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(正式名称)")
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
        strDataSetName = "TMST_TRK"
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
    Public Function GET_TMST_TRK_ANY() As RetCode
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
        strSQL.Append(vbCrLf & "    TMST_TRK")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FTRK_BUF_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNull(FBUF_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_NAME
            strSQL.Append(vbCrLf & "    AND FBUF_NAME = :" & UBound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称")
        End If
        If IsNull(FBUF_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_KIND
            strSQL.Append(vbCrLf & "    AND FBUF_KIND = :" & UBound(strBindField) - 1 & " --ﾊﾞｯﾌｧ種別")
        End If
        If IsNull(FNEW_IN_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFNEW_IN_KUBUN
            strSQL.Append(vbCrLf & "    AND FNEW_IN_KUBUN = :" & UBound(strBindField) - 1 & " --新規入庫ﾊﾞｯﾌｧ区分")
        End If
        If IsNull(FBUF_MAX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_MAX
            strSQL.Append(vbCrLf & "    AND FBUF_MAX = :" & UBound(strBindField) - 1 & " --最大ﾊﾞｯﾌｧ件数")
        End If
        If IsNull(FBUF_LOG_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_LOG_FLAG
            strSQL.Append(vbCrLf & "    AND FBUF_LOG_FLAG = :" & UBound(strBindField) - 1 & " --ﾛｸﾞ有無ﾌﾗｸﾞ")
        End If
        If IsNull(FRAC_RETU_MAX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_RETU_MAX
            strSQL.Append(vbCrLf & "    AND FRAC_RETU_MAX = :" & UBound(strBindField) - 1 & " --最大列数")
        End If
        If IsNull(FRAC_REN_MAX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_REN_MAX
            strSQL.Append(vbCrLf & "    AND FRAC_REN_MAX = :" & UBound(strBindField) - 1 & " --最大連数")
        End If
        If IsNull(FRAC_DAN_MAX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_DAN_MAX
            strSQL.Append(vbCrLf & "    AND FRAC_DAN_MAX = :" & UBound(strBindField) - 1 & " --最大段数")
        End If
        If IsNull(FRAC_EDA_MAX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_EDA_MAX
            strSQL.Append(vbCrLf & "    AND FRAC_EDA_MAX = :" & UBound(strBindField) - 1 & " --最大枝数")
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
        If IsNull(XEQ_ID_MOD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_MOD
            strSQL.Append(vbCrLf & "    AND XEQ_ID_MOD = :" & UBound(strBindField) - 1 & " --ﾓｰﾄﾞ設備ID")
        End If
        If IsNull(XEQ_ID_STN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_STN
            strSQL.Append(vbCrLf & "    AND XEQ_ID_STN = :" & UBound(strBindField) - 1 & " --ST載荷設備ID")
        End If
        If IsNull(XTRK_BUF_NO_IN_HIRA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_IN_HIRA
            strSQL.Append(vbCrLf & "    AND XTRK_BUF_NO_IN_HIRA = :" & UBound(strBindField) - 1 & " --入庫設定時平置")
        End If
        If IsNull(XTRK_BUF_NO_OUT_HIRA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_OUT_HIRA
            strSQL.Append(vbCrLf & "    AND XTRK_BUF_NO_OUT_HIRA = :" & UBound(strBindField) - 1 & " --出庫設定時平置")
        End If
        If IsNull(XADRS_IN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_IN
            strSQL.Append(vbCrLf & "    AND XADRS_IN = :" & UBound(strBindField) - 1 & " --入庫指示ｱﾄﾞﾚｽ")
        End If
        If IsNull(XADRS_OUT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_OUT
            strSQL.Append(vbCrLf & "    AND XADRS_OUT = :" & UBound(strBindField) - 1 & " --出庫指示ｱﾄﾞﾚｽ")
        End If
        If IsNull(XADRS_HANSOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_HANSOU
            strSQL.Append(vbCrLf & "    AND XADRS_HANSOU = :" & UBound(strBindField) - 1 & " --搬送指示ｱﾄﾞﾚｽ")
        End If
        If IsNull(XADRS_PLCTRK05) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PLCTRK05
            strSQL.Append(vbCrLf & "    AND XADRS_PLCTRK05 = :" & UBound(strBindField) - 1 & " --PLCﾄﾗｯｷﾝｸﾞｱﾄﾞﾚｽ05")
        End If
        If IsNull(XADRS_PLCTRK04) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PLCTRK04
            strSQL.Append(vbCrLf & "    AND XADRS_PLCTRK04 = :" & UBound(strBindField) - 1 & " --PLCﾄﾗｯｷﾝｸﾞｱﾄﾞﾚｽ04")
        End If
        If IsNull(XADRS_PALLET01) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PALLET01
            strSQL.Append(vbCrLf & "    AND XADRS_PALLET01 = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄ数ｱﾄﾞﾚｽ01")
        End If
        If IsNull(XADRS_PALLET02) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PALLET02
            strSQL.Append(vbCrLf & "    AND XADRS_PALLET02 = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄ数ｱﾄﾞﾚｽ02")
        End If
        If IsNull(XADRS_YOTEI01) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_YOTEI01
            strSQL.Append(vbCrLf & "    AND XADRS_YOTEI01 = :" & UBound(strBindField) - 1 & " --予定数ｱﾄﾞﾚｽ01")
        End If
        If IsNull(XADRS_YOTEI02) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_YOTEI02
            strSQL.Append(vbCrLf & "    AND XADRS_YOTEI02 = :" & UBound(strBindField) - 1 & " --予定数ｱﾄﾞﾚｽ02")
        End If
        If IsNull(XLS_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXLS_NO
            strSQL.Append(vbCrLf & "    AND XLS_NO = :" & UBound(strBindField) - 1 & " --L/S番号")
        End If
        If IsNull(XEQ_ID_IN_FR) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_IN_FR
            strSQL.Append(vbCrLf & "    AND XEQ_ID_IN_FR = :" & UBound(strBindField) - 1 & " --入庫要求前設備ID")
        End If
        If IsNull(XEQ_ID_IN_BK) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_IN_BK
            strSQL.Append(vbCrLf & "    AND XEQ_ID_IN_BK = :" & UBound(strBindField) - 1 & " --入庫要求後設備ID")
        End If
        If IsNull(XEQ_ID_HASU_FR) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_HASU_FR
            strSQL.Append(vbCrLf & "    AND XEQ_ID_HASU_FR = :" & UBound(strBindField) - 1 & " --端数前設備ID")
        End If
        If IsNull(XEQ_ID_HASU_BK) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_HASU_BK
            strSQL.Append(vbCrLf & "    AND XEQ_ID_HASU_BK = :" & UBound(strBindField) - 1 & " --端数後設備ID")
        End If
        If IsNull(XTRK_BUF_NO_CONV) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_CONV
            strSQL.Append(vbCrLf & "    AND XTRK_BUF_NO_CONV = :" & UBound(strBindField) - 1 & " --ｺﾝﾍﾞﾔ関連付け")
        End If
        If IsNull(XEQ_ID_IRI_YOUKYU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_IRI_YOUKYU
            strSQL.Append(vbCrLf & "    AND XEQ_ID_IRI_YOUKYU = :" & UBound(strBindField) - 1 & " --入棚入庫要求設備ID")
        End If
        If IsNull(XEQ_ID_OUT_YOUKYU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_OUT_YOUKYU
            strSQL.Append(vbCrLf & "    AND XEQ_ID_OUT_YOUKYU = :" & UBound(strBindField) - 1 & " --出庫要求設備ID")
        End If
        If IsNull(XEQ_ID_OUT_BUF) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_OUT_BUF
            strSQL.Append(vbCrLf & "    AND XEQ_ID_OUT_BUF = :" & UBound(strBindField) - 1 & " --出棚ﾊﾞｯﾌｧ空設備ID")
        End If
        If IsNull(XEQ_ID_OUT_END) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_OUT_END
            strSQL.Append(vbCrLf & "    AND XEQ_ID_OUT_END = :" & UBound(strBindField) - 1 & " --出庫完了設備ID")
        End If
        If IsNull(XEQ_ID_B_HENSEI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_HENSEI
            strSQL.Append(vbCrLf & "    AND XEQ_ID_B_HENSEI = :" & UBound(strBindField) - 1 & " --編成№表示")
        End If
        If IsNull(XEQ_ID_B_OUTEND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_OUTEND
            strSQL.Append(vbCrLf & "    AND XEQ_ID_B_OUTEND = :" & UBound(strBindField) - 1 & " --出庫完了ﾗﾝﾌﾟ")
        End If
        If IsNull(XEQ_ID_B_TUMIEND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_TUMIEND
            strSQL.Append(vbCrLf & "    AND XEQ_ID_B_TUMIEND = :" & UBound(strBindField) - 1 & " --積込完了ﾎﾞﾀﾝ")
        End If
        If IsNull(XMAINTE_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAINTE_KUBUN
            strSQL.Append(vbCrLf & "    AND XMAINTE_KUBUN = :" & UBound(strBindField) - 1 & " --ﾒﾝﾃﾅﾝｽ区分")
        End If
        If IsNull(XMAINTE_ORDER) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAINTE_ORDER
            strSQL.Append(vbCrLf & "    AND XMAINTE_ORDER = :" & UBound(strBindField) - 1 & " --ﾒﾝﾃﾅﾝｽ区分順")
        End If
        If IsNull(XMAINTE_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAINTE_NAME
            strSQL.Append(vbCrLf & "    AND XMAINTE_NAME = :" & UBound(strBindField) - 1 & " --ﾒﾝﾃﾅﾝｽ表示名")
        End If
        If IsNull(XBUF_NAME_DTL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBUF_NAME_DTL
            strSQL.Append(vbCrLf & "    AND XBUF_NAME_DTL = :" & UBound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(正式名称)")
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
        strDataSetName = "TMST_TRK"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TMST_TRK(Owner, objDb, objDbLog)
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
    Public Function GET_TMST_TRK_USER(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "TMST_TRK"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TMST_TRK(Owner, objDb, objDbLog)
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
    Public Function GET_TMST_TRK_COUNT() As Integer
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
        strSQL.Append(vbCrLf & "    TMST_TRK")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1")
        If IsNull(FTRK_BUF_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNull(FBUF_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_NAME
            strSQL.Append(vbCrLf & "    AND FBUF_NAME = :" & UBound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称")
        End If
        If IsNull(FBUF_KIND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_KIND
            strSQL.Append(vbCrLf & "    AND FBUF_KIND = :" & UBound(strBindField) - 1 & " --ﾊﾞｯﾌｧ種別")
        End If
        If IsNull(FNEW_IN_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFNEW_IN_KUBUN
            strSQL.Append(vbCrLf & "    AND FNEW_IN_KUBUN = :" & UBound(strBindField) - 1 & " --新規入庫ﾊﾞｯﾌｧ区分")
        End If
        If IsNull(FBUF_MAX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_MAX
            strSQL.Append(vbCrLf & "    AND FBUF_MAX = :" & UBound(strBindField) - 1 & " --最大ﾊﾞｯﾌｧ件数")
        End If
        If IsNull(FBUF_LOG_FLAG) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_LOG_FLAG
            strSQL.Append(vbCrLf & "    AND FBUF_LOG_FLAG = :" & UBound(strBindField) - 1 & " --ﾛｸﾞ有無ﾌﾗｸﾞ")
        End If
        If IsNull(FRAC_RETU_MAX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_RETU_MAX
            strSQL.Append(vbCrLf & "    AND FRAC_RETU_MAX = :" & UBound(strBindField) - 1 & " --最大列数")
        End If
        If IsNull(FRAC_REN_MAX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_REN_MAX
            strSQL.Append(vbCrLf & "    AND FRAC_REN_MAX = :" & UBound(strBindField) - 1 & " --最大連数")
        End If
        If IsNull(FRAC_DAN_MAX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_DAN_MAX
            strSQL.Append(vbCrLf & "    AND FRAC_DAN_MAX = :" & UBound(strBindField) - 1 & " --最大段数")
        End If
        If IsNull(FRAC_EDA_MAX) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_EDA_MAX
            strSQL.Append(vbCrLf & "    AND FRAC_EDA_MAX = :" & UBound(strBindField) - 1 & " --最大枝数")
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
        If IsNull(XEQ_ID_MOD) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_MOD
            strSQL.Append(vbCrLf & "    AND XEQ_ID_MOD = :" & UBound(strBindField) - 1 & " --ﾓｰﾄﾞ設備ID")
        End If
        If IsNull(XEQ_ID_STN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_STN
            strSQL.Append(vbCrLf & "    AND XEQ_ID_STN = :" & UBound(strBindField) - 1 & " --ST載荷設備ID")
        End If
        If IsNull(XTRK_BUF_NO_IN_HIRA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_IN_HIRA
            strSQL.Append(vbCrLf & "    AND XTRK_BUF_NO_IN_HIRA = :" & UBound(strBindField) - 1 & " --入庫設定時平置")
        End If
        If IsNull(XTRK_BUF_NO_OUT_HIRA) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_OUT_HIRA
            strSQL.Append(vbCrLf & "    AND XTRK_BUF_NO_OUT_HIRA = :" & UBound(strBindField) - 1 & " --出庫設定時平置")
        End If
        If IsNull(XADRS_IN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_IN
            strSQL.Append(vbCrLf & "    AND XADRS_IN = :" & UBound(strBindField) - 1 & " --入庫指示ｱﾄﾞﾚｽ")
        End If
        If IsNull(XADRS_OUT) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_OUT
            strSQL.Append(vbCrLf & "    AND XADRS_OUT = :" & UBound(strBindField) - 1 & " --出庫指示ｱﾄﾞﾚｽ")
        End If
        If IsNull(XADRS_HANSOU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_HANSOU
            strSQL.Append(vbCrLf & "    AND XADRS_HANSOU = :" & UBound(strBindField) - 1 & " --搬送指示ｱﾄﾞﾚｽ")
        End If
        If IsNull(XADRS_PLCTRK05) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PLCTRK05
            strSQL.Append(vbCrLf & "    AND XADRS_PLCTRK05 = :" & UBound(strBindField) - 1 & " --PLCﾄﾗｯｷﾝｸﾞｱﾄﾞﾚｽ05")
        End If
        If IsNull(XADRS_PLCTRK04) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PLCTRK04
            strSQL.Append(vbCrLf & "    AND XADRS_PLCTRK04 = :" & UBound(strBindField) - 1 & " --PLCﾄﾗｯｷﾝｸﾞｱﾄﾞﾚｽ04")
        End If
        If IsNull(XADRS_PALLET01) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PALLET01
            strSQL.Append(vbCrLf & "    AND XADRS_PALLET01 = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄ数ｱﾄﾞﾚｽ01")
        End If
        If IsNull(XADRS_PALLET02) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PALLET02
            strSQL.Append(vbCrLf & "    AND XADRS_PALLET02 = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄ数ｱﾄﾞﾚｽ02")
        End If
        If IsNull(XADRS_YOTEI01) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_YOTEI01
            strSQL.Append(vbCrLf & "    AND XADRS_YOTEI01 = :" & UBound(strBindField) - 1 & " --予定数ｱﾄﾞﾚｽ01")
        End If
        If IsNull(XADRS_YOTEI02) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_YOTEI02
            strSQL.Append(vbCrLf & "    AND XADRS_YOTEI02 = :" & UBound(strBindField) - 1 & " --予定数ｱﾄﾞﾚｽ02")
        End If
        If IsNull(XLS_NO) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXLS_NO
            strSQL.Append(vbCrLf & "    AND XLS_NO = :" & UBound(strBindField) - 1 & " --L/S番号")
        End If
        If IsNull(XEQ_ID_IN_FR) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_IN_FR
            strSQL.Append(vbCrLf & "    AND XEQ_ID_IN_FR = :" & UBound(strBindField) - 1 & " --入庫要求前設備ID")
        End If
        If IsNull(XEQ_ID_IN_BK) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_IN_BK
            strSQL.Append(vbCrLf & "    AND XEQ_ID_IN_BK = :" & UBound(strBindField) - 1 & " --入庫要求後設備ID")
        End If
        If IsNull(XEQ_ID_HASU_FR) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_HASU_FR
            strSQL.Append(vbCrLf & "    AND XEQ_ID_HASU_FR = :" & UBound(strBindField) - 1 & " --端数前設備ID")
        End If
        If IsNull(XEQ_ID_HASU_BK) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_HASU_BK
            strSQL.Append(vbCrLf & "    AND XEQ_ID_HASU_BK = :" & UBound(strBindField) - 1 & " --端数後設備ID")
        End If
        If IsNull(XTRK_BUF_NO_CONV) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_CONV
            strSQL.Append(vbCrLf & "    AND XTRK_BUF_NO_CONV = :" & UBound(strBindField) - 1 & " --ｺﾝﾍﾞﾔ関連付け")
        End If
        If IsNull(XEQ_ID_IRI_YOUKYU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_IRI_YOUKYU
            strSQL.Append(vbCrLf & "    AND XEQ_ID_IRI_YOUKYU = :" & UBound(strBindField) - 1 & " --入棚入庫要求設備ID")
        End If
        If IsNull(XEQ_ID_OUT_YOUKYU) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_OUT_YOUKYU
            strSQL.Append(vbCrLf & "    AND XEQ_ID_OUT_YOUKYU = :" & UBound(strBindField) - 1 & " --出庫要求設備ID")
        End If
        If IsNull(XEQ_ID_OUT_BUF) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_OUT_BUF
            strSQL.Append(vbCrLf & "    AND XEQ_ID_OUT_BUF = :" & UBound(strBindField) - 1 & " --出棚ﾊﾞｯﾌｧ空設備ID")
        End If
        If IsNull(XEQ_ID_OUT_END) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_OUT_END
            strSQL.Append(vbCrLf & "    AND XEQ_ID_OUT_END = :" & UBound(strBindField) - 1 & " --出庫完了設備ID")
        End If
        If IsNull(XEQ_ID_B_HENSEI) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_HENSEI
            strSQL.Append(vbCrLf & "    AND XEQ_ID_B_HENSEI = :" & UBound(strBindField) - 1 & " --編成№表示")
        End If
        If IsNull(XEQ_ID_B_OUTEND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_OUTEND
            strSQL.Append(vbCrLf & "    AND XEQ_ID_B_OUTEND = :" & UBound(strBindField) - 1 & " --出庫完了ﾗﾝﾌﾟ")
        End If
        If IsNull(XEQ_ID_B_TUMIEND) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_TUMIEND
            strSQL.Append(vbCrLf & "    AND XEQ_ID_B_TUMIEND = :" & UBound(strBindField) - 1 & " --積込完了ﾎﾞﾀﾝ")
        End If
        If IsNull(XMAINTE_KUBUN) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAINTE_KUBUN
            strSQL.Append(vbCrLf & "    AND XMAINTE_KUBUN = :" & UBound(strBindField) - 1 & " --ﾒﾝﾃﾅﾝｽ区分")
        End If
        If IsNull(XMAINTE_ORDER) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAINTE_ORDER
            strSQL.Append(vbCrLf & "    AND XMAINTE_ORDER = :" & UBound(strBindField) - 1 & " --ﾒﾝﾃﾅﾝｽ区分順")
        End If
        If IsNull(XMAINTE_NAME) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAINTE_NAME
            strSQL.Append(vbCrLf & "    AND XMAINTE_NAME = :" & UBound(strBindField) - 1 & " --ﾒﾝﾃﾅﾝｽ表示名")
        End If
        If IsNull(XBUF_NAME_DTL) = False Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBUF_NAME_DTL
            strSQL.Append(vbCrLf & "    AND XBUF_NAME_DTL = :" & UBound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(正式名称)")
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
        strDataSetName = "TMST_TRK"
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
    Public Sub UPDATE_TMST_TRK()
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
        ElseIf IsNull(mFBUF_NAME) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFBUF_KIND) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾊﾞｯﾌｧ種別]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFNEW_IN_KUBUN) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[新規入庫ﾊﾞｯﾌｧ区分]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFBUF_MAX) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[最大ﾊﾞｯﾌｧ件数]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFBUF_LOG_FLAG) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾛｸﾞ有無ﾌﾗｸﾞ]"
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
        strSQL.Append(vbCrLf & "    TMST_TRK")
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
        If IsNull(mFBUF_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FBUF_NAME = NULL --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FBUF_NAME = NULL --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FBUF_NAME = :" & Ubound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FBUF_NAME = :" & Ubound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称")
        End If
        intCount = intCount + 1
        If IsNull(mFBUF_KIND) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FBUF_KIND = NULL --ﾊﾞｯﾌｧ種別")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FBUF_KIND = NULL --ﾊﾞｯﾌｧ種別")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_KIND
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FBUF_KIND = :" & Ubound(strBindField) - 1 & " --ﾊﾞｯﾌｧ種別")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FBUF_KIND = :" & Ubound(strBindField) - 1 & " --ﾊﾞｯﾌｧ種別")
        End If
        intCount = intCount + 1
        If IsNull(mFNEW_IN_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FNEW_IN_KUBUN = NULL --新規入庫ﾊﾞｯﾌｧ区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FNEW_IN_KUBUN = NULL --新規入庫ﾊﾞｯﾌｧ区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFNEW_IN_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FNEW_IN_KUBUN = :" & Ubound(strBindField) - 1 & " --新規入庫ﾊﾞｯﾌｧ区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FNEW_IN_KUBUN = :" & Ubound(strBindField) - 1 & " --新規入庫ﾊﾞｯﾌｧ区分")
        End If
        intCount = intCount + 1
        If IsNull(mFBUF_MAX) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FBUF_MAX = NULL --最大ﾊﾞｯﾌｧ件数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FBUF_MAX = NULL --最大ﾊﾞｯﾌｧ件数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_MAX
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FBUF_MAX = :" & Ubound(strBindField) - 1 & " --最大ﾊﾞｯﾌｧ件数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FBUF_MAX = :" & Ubound(strBindField) - 1 & " --最大ﾊﾞｯﾌｧ件数")
        End If
        intCount = intCount + 1
        If IsNull(mFBUF_LOG_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FBUF_LOG_FLAG = NULL --ﾛｸﾞ有無ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FBUF_LOG_FLAG = NULL --ﾛｸﾞ有無ﾌﾗｸﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_LOG_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FBUF_LOG_FLAG = :" & Ubound(strBindField) - 1 & " --ﾛｸﾞ有無ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FBUF_LOG_FLAG = :" & Ubound(strBindField) - 1 & " --ﾛｸﾞ有無ﾌﾗｸﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_RETU_MAX) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_RETU_MAX = NULL --最大列数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_RETU_MAX = NULL --最大列数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_RETU_MAX
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_RETU_MAX = :" & Ubound(strBindField) - 1 & " --最大列数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_RETU_MAX = :" & Ubound(strBindField) - 1 & " --最大列数")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_REN_MAX) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_REN_MAX = NULL --最大連数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_REN_MAX = NULL --最大連数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_REN_MAX
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_REN_MAX = :" & Ubound(strBindField) - 1 & " --最大連数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_REN_MAX = :" & Ubound(strBindField) - 1 & " --最大連数")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_DAN_MAX) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_DAN_MAX = NULL --最大段数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_DAN_MAX = NULL --最大段数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_DAN_MAX
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_DAN_MAX = :" & Ubound(strBindField) - 1 & " --最大段数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_DAN_MAX = :" & Ubound(strBindField) - 1 & " --最大段数")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_EDA_MAX) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_EDA_MAX = NULL --最大枝数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_EDA_MAX = NULL --最大枝数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_EDA_MAX
            If intCount = 0 Then strSQL.Append(vbCrLf & "    FRAC_EDA_MAX = :" & Ubound(strBindField) - 1 & " --最大枝数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,FRAC_EDA_MAX = :" & Ubound(strBindField) - 1 & " --最大枝数")
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
        If IsNull(mXEQ_ID_MOD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_MOD = NULL --ﾓｰﾄﾞ設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_MOD = NULL --ﾓｰﾄﾞ設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_MOD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_MOD = :" & Ubound(strBindField) - 1 & " --ﾓｰﾄﾞ設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_MOD = :" & Ubound(strBindField) - 1 & " --ﾓｰﾄﾞ設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_STN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_STN = NULL --ST載荷設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_STN = NULL --ST載荷設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_STN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_STN = :" & Ubound(strBindField) - 1 & " --ST載荷設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_STN = :" & Ubound(strBindField) - 1 & " --ST載荷設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXTRK_BUF_NO_IN_HIRA) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTRK_BUF_NO_IN_HIRA = NULL --入庫設定時平置")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTRK_BUF_NO_IN_HIRA = NULL --入庫設定時平置")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_IN_HIRA
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTRK_BUF_NO_IN_HIRA = :" & Ubound(strBindField) - 1 & " --入庫設定時平置")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTRK_BUF_NO_IN_HIRA = :" & Ubound(strBindField) - 1 & " --入庫設定時平置")
        End If
        intCount = intCount + 1
        If IsNull(mXTRK_BUF_NO_OUT_HIRA) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTRK_BUF_NO_OUT_HIRA = NULL --出庫設定時平置")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTRK_BUF_NO_OUT_HIRA = NULL --出庫設定時平置")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_OUT_HIRA
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTRK_BUF_NO_OUT_HIRA = :" & Ubound(strBindField) - 1 & " --出庫設定時平置")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTRK_BUF_NO_OUT_HIRA = :" & Ubound(strBindField) - 1 & " --出庫設定時平置")
        End If
        intCount = intCount + 1
        If IsNull(mXADRS_IN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XADRS_IN = NULL --入庫指示ｱﾄﾞﾚｽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XADRS_IN = NULL --入庫指示ｱﾄﾞﾚｽ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_IN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XADRS_IN = :" & Ubound(strBindField) - 1 & " --入庫指示ｱﾄﾞﾚｽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XADRS_IN = :" & Ubound(strBindField) - 1 & " --入庫指示ｱﾄﾞﾚｽ")
        End If
        intCount = intCount + 1
        If IsNull(mXADRS_OUT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XADRS_OUT = NULL --出庫指示ｱﾄﾞﾚｽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XADRS_OUT = NULL --出庫指示ｱﾄﾞﾚｽ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_OUT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XADRS_OUT = :" & Ubound(strBindField) - 1 & " --出庫指示ｱﾄﾞﾚｽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XADRS_OUT = :" & Ubound(strBindField) - 1 & " --出庫指示ｱﾄﾞﾚｽ")
        End If
        intCount = intCount + 1
        If IsNull(mXADRS_HANSOU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XADRS_HANSOU = NULL --搬送指示ｱﾄﾞﾚｽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XADRS_HANSOU = NULL --搬送指示ｱﾄﾞﾚｽ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_HANSOU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XADRS_HANSOU = :" & Ubound(strBindField) - 1 & " --搬送指示ｱﾄﾞﾚｽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XADRS_HANSOU = :" & Ubound(strBindField) - 1 & " --搬送指示ｱﾄﾞﾚｽ")
        End If
        intCount = intCount + 1
        If IsNull(mXADRS_PLCTRK05) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XADRS_PLCTRK05 = NULL --PLCﾄﾗｯｷﾝｸﾞｱﾄﾞﾚｽ05")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XADRS_PLCTRK05 = NULL --PLCﾄﾗｯｷﾝｸﾞｱﾄﾞﾚｽ05")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PLCTRK05
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XADRS_PLCTRK05 = :" & Ubound(strBindField) - 1 & " --PLCﾄﾗｯｷﾝｸﾞｱﾄﾞﾚｽ05")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XADRS_PLCTRK05 = :" & Ubound(strBindField) - 1 & " --PLCﾄﾗｯｷﾝｸﾞｱﾄﾞﾚｽ05")
        End If
        intCount = intCount + 1
        If IsNull(mXADRS_PLCTRK04) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XADRS_PLCTRK04 = NULL --PLCﾄﾗｯｷﾝｸﾞｱﾄﾞﾚｽ04")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XADRS_PLCTRK04 = NULL --PLCﾄﾗｯｷﾝｸﾞｱﾄﾞﾚｽ04")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PLCTRK04
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XADRS_PLCTRK04 = :" & Ubound(strBindField) - 1 & " --PLCﾄﾗｯｷﾝｸﾞｱﾄﾞﾚｽ04")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XADRS_PLCTRK04 = :" & Ubound(strBindField) - 1 & " --PLCﾄﾗｯｷﾝｸﾞｱﾄﾞﾚｽ04")
        End If
        intCount = intCount + 1
        If IsNull(mXADRS_PALLET01) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XADRS_PALLET01 = NULL --ﾊﾟﾚｯﾄ数ｱﾄﾞﾚｽ01")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XADRS_PALLET01 = NULL --ﾊﾟﾚｯﾄ数ｱﾄﾞﾚｽ01")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PALLET01
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XADRS_PALLET01 = :" & Ubound(strBindField) - 1 & " --ﾊﾟﾚｯﾄ数ｱﾄﾞﾚｽ01")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XADRS_PALLET01 = :" & Ubound(strBindField) - 1 & " --ﾊﾟﾚｯﾄ数ｱﾄﾞﾚｽ01")
        End If
        intCount = intCount + 1
        If IsNull(mXADRS_PALLET02) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XADRS_PALLET02 = NULL --ﾊﾟﾚｯﾄ数ｱﾄﾞﾚｽ02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XADRS_PALLET02 = NULL --ﾊﾟﾚｯﾄ数ｱﾄﾞﾚｽ02")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PALLET02
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XADRS_PALLET02 = :" & Ubound(strBindField) - 1 & " --ﾊﾟﾚｯﾄ数ｱﾄﾞﾚｽ02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XADRS_PALLET02 = :" & Ubound(strBindField) - 1 & " --ﾊﾟﾚｯﾄ数ｱﾄﾞﾚｽ02")
        End If
        intCount = intCount + 1
        If IsNull(mXADRS_YOTEI01) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XADRS_YOTEI01 = NULL --予定数ｱﾄﾞﾚｽ01")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XADRS_YOTEI01 = NULL --予定数ｱﾄﾞﾚｽ01")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_YOTEI01
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XADRS_YOTEI01 = :" & Ubound(strBindField) - 1 & " --予定数ｱﾄﾞﾚｽ01")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XADRS_YOTEI01 = :" & Ubound(strBindField) - 1 & " --予定数ｱﾄﾞﾚｽ01")
        End If
        intCount = intCount + 1
        If IsNull(mXADRS_YOTEI02) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XADRS_YOTEI02 = NULL --予定数ｱﾄﾞﾚｽ02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XADRS_YOTEI02 = NULL --予定数ｱﾄﾞﾚｽ02")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_YOTEI02
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XADRS_YOTEI02 = :" & Ubound(strBindField) - 1 & " --予定数ｱﾄﾞﾚｽ02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XADRS_YOTEI02 = :" & Ubound(strBindField) - 1 & " --予定数ｱﾄﾞﾚｽ02")
        End If
        intCount = intCount + 1
        If IsNull(mXLS_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XLS_NO = NULL --L/S番号")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XLS_NO = NULL --L/S番号")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXLS_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XLS_NO = :" & Ubound(strBindField) - 1 & " --L/S番号")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XLS_NO = :" & Ubound(strBindField) - 1 & " --L/S番号")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_IN_FR) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_IN_FR = NULL --入庫要求前設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_IN_FR = NULL --入庫要求前設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_IN_FR
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_IN_FR = :" & Ubound(strBindField) - 1 & " --入庫要求前設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_IN_FR = :" & Ubound(strBindField) - 1 & " --入庫要求前設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_IN_BK) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_IN_BK = NULL --入庫要求後設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_IN_BK = NULL --入庫要求後設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_IN_BK
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_IN_BK = :" & Ubound(strBindField) - 1 & " --入庫要求後設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_IN_BK = :" & Ubound(strBindField) - 1 & " --入庫要求後設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_HASU_FR) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_HASU_FR = NULL --端数前設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_HASU_FR = NULL --端数前設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_HASU_FR
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_HASU_FR = :" & Ubound(strBindField) - 1 & " --端数前設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_HASU_FR = :" & Ubound(strBindField) - 1 & " --端数前設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_HASU_BK) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_HASU_BK = NULL --端数後設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_HASU_BK = NULL --端数後設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_HASU_BK
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_HASU_BK = :" & Ubound(strBindField) - 1 & " --端数後設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_HASU_BK = :" & Ubound(strBindField) - 1 & " --端数後設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXTRK_BUF_NO_CONV) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTRK_BUF_NO_CONV = NULL --ｺﾝﾍﾞﾔ関連付け")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTRK_BUF_NO_CONV = NULL --ｺﾝﾍﾞﾔ関連付け")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_CONV
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XTRK_BUF_NO_CONV = :" & Ubound(strBindField) - 1 & " --ｺﾝﾍﾞﾔ関連付け")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XTRK_BUF_NO_CONV = :" & Ubound(strBindField) - 1 & " --ｺﾝﾍﾞﾔ関連付け")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_IRI_YOUKYU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_IRI_YOUKYU = NULL --入棚入庫要求設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_IRI_YOUKYU = NULL --入棚入庫要求設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_IRI_YOUKYU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_IRI_YOUKYU = :" & Ubound(strBindField) - 1 & " --入棚入庫要求設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_IRI_YOUKYU = :" & Ubound(strBindField) - 1 & " --入棚入庫要求設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_OUT_YOUKYU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_OUT_YOUKYU = NULL --出庫要求設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_OUT_YOUKYU = NULL --出庫要求設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_OUT_YOUKYU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_OUT_YOUKYU = :" & Ubound(strBindField) - 1 & " --出庫要求設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_OUT_YOUKYU = :" & Ubound(strBindField) - 1 & " --出庫要求設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_OUT_BUF) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_OUT_BUF = NULL --出棚ﾊﾞｯﾌｧ空設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_OUT_BUF = NULL --出棚ﾊﾞｯﾌｧ空設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_OUT_BUF
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_OUT_BUF = :" & Ubound(strBindField) - 1 & " --出棚ﾊﾞｯﾌｧ空設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_OUT_BUF = :" & Ubound(strBindField) - 1 & " --出棚ﾊﾞｯﾌｧ空設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_OUT_END) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_OUT_END = NULL --出庫完了設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_OUT_END = NULL --出庫完了設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_OUT_END
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_OUT_END = :" & Ubound(strBindField) - 1 & " --出庫完了設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_OUT_END = :" & Ubound(strBindField) - 1 & " --出庫完了設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_B_HENSEI) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_B_HENSEI = NULL --編成№表示")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_B_HENSEI = NULL --編成№表示")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_HENSEI
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_B_HENSEI = :" & Ubound(strBindField) - 1 & " --編成№表示")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_B_HENSEI = :" & Ubound(strBindField) - 1 & " --編成№表示")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_B_OUTEND) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_B_OUTEND = NULL --出庫完了ﾗﾝﾌﾟ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_B_OUTEND = NULL --出庫完了ﾗﾝﾌﾟ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_OUTEND
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_B_OUTEND = :" & Ubound(strBindField) - 1 & " --出庫完了ﾗﾝﾌﾟ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_B_OUTEND = :" & Ubound(strBindField) - 1 & " --出庫完了ﾗﾝﾌﾟ")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_B_TUMIEND) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_B_TUMIEND = NULL --積込完了ﾎﾞﾀﾝ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_B_TUMIEND = NULL --積込完了ﾎﾞﾀﾝ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_TUMIEND
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XEQ_ID_B_TUMIEND = :" & Ubound(strBindField) - 1 & " --積込完了ﾎﾞﾀﾝ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XEQ_ID_B_TUMIEND = :" & Ubound(strBindField) - 1 & " --積込完了ﾎﾞﾀﾝ")
        End If
        intCount = intCount + 1
        If IsNull(mXMAINTE_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XMAINTE_KUBUN = NULL --ﾒﾝﾃﾅﾝｽ区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XMAINTE_KUBUN = NULL --ﾒﾝﾃﾅﾝｽ区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAINTE_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XMAINTE_KUBUN = :" & Ubound(strBindField) - 1 & " --ﾒﾝﾃﾅﾝｽ区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XMAINTE_KUBUN = :" & Ubound(strBindField) - 1 & " --ﾒﾝﾃﾅﾝｽ区分")
        End If
        intCount = intCount + 1
        If IsNull(mXMAINTE_ORDER) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XMAINTE_ORDER = NULL --ﾒﾝﾃﾅﾝｽ区分順")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XMAINTE_ORDER = NULL --ﾒﾝﾃﾅﾝｽ区分順")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAINTE_ORDER
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XMAINTE_ORDER = :" & Ubound(strBindField) - 1 & " --ﾒﾝﾃﾅﾝｽ区分順")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XMAINTE_ORDER = :" & Ubound(strBindField) - 1 & " --ﾒﾝﾃﾅﾝｽ区分順")
        End If
        intCount = intCount + 1
        If IsNull(mXMAINTE_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XMAINTE_NAME = NULL --ﾒﾝﾃﾅﾝｽ表示名")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XMAINTE_NAME = NULL --ﾒﾝﾃﾅﾝｽ表示名")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAINTE_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XMAINTE_NAME = :" & Ubound(strBindField) - 1 & " --ﾒﾝﾃﾅﾝｽ表示名")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XMAINTE_NAME = :" & Ubound(strBindField) - 1 & " --ﾒﾝﾃﾅﾝｽ表示名")
        End If
        intCount = intCount + 1
        If IsNull(mXBUF_NAME_DTL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XBUF_NAME_DTL = NULL --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(正式名称)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XBUF_NAME_DTL = NULL --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(正式名称)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBUF_NAME_DTL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    XBUF_NAME_DTL = :" & Ubound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(正式名称)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,XBUF_NAME_DTL = :" & Ubound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(正式名称)")
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
    Public Sub ADD_TMST_TRK()
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
        ElseIf IsNull(mFBUF_NAME) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFBUF_KIND) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾊﾞｯﾌｧ種別]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFNEW_IN_KUBUN) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[新規入庫ﾊﾞｯﾌｧ区分]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFBUF_MAX) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[最大ﾊﾞｯﾌｧ件数]"
            Throw New UserException(strMsg)
        ElseIf IsNull(mFBUF_LOG_FLAG) = True Then
            strMsg = ERRMSG_ERR_PROPERTY & "[ﾛｸﾞ有無ﾌﾗｸﾞ]"
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
        strSQL.Append(vbCrLf & "    TMST_TRK")
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
        If IsNull(mFBUF_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称")
        End If
        intCount = intCount + 1
        If IsNull(mFBUF_KIND) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾊﾞｯﾌｧ種別")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾊﾞｯﾌｧ種別")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_KIND
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾊﾞｯﾌｧ種別")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾊﾞｯﾌｧ種別")
        End If
        intCount = intCount + 1
        If IsNull(mFNEW_IN_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --新規入庫ﾊﾞｯﾌｧ区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --新規入庫ﾊﾞｯﾌｧ区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFNEW_IN_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --新規入庫ﾊﾞｯﾌｧ区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --新規入庫ﾊﾞｯﾌｧ区分")
        End If
        intCount = intCount + 1
        If IsNull(mFBUF_MAX) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --最大ﾊﾞｯﾌｧ件数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --最大ﾊﾞｯﾌｧ件数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_MAX
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --最大ﾊﾞｯﾌｧ件数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --最大ﾊﾞｯﾌｧ件数")
        End If
        intCount = intCount + 1
        If IsNull(mFBUF_LOG_FLAG) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾛｸﾞ有無ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾛｸﾞ有無ﾌﾗｸﾞ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_LOG_FLAG
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾛｸﾞ有無ﾌﾗｸﾞ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾛｸﾞ有無ﾌﾗｸﾞ")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_RETU_MAX) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --最大列数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --最大列数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_RETU_MAX
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --最大列数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --最大列数")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_REN_MAX) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --最大連数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --最大連数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_REN_MAX
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --最大連数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --最大連数")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_DAN_MAX) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --最大段数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --最大段数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_DAN_MAX
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --最大段数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --最大段数")
        End If
        intCount = intCount + 1
        If IsNull(mFRAC_EDA_MAX) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --最大枝数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --最大枝数")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_EDA_MAX
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --最大枝数")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --最大枝数")
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
        If IsNull(mXEQ_ID_MOD) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾓｰﾄﾞ設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾓｰﾄﾞ設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_MOD
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾓｰﾄﾞ設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾓｰﾄﾞ設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_STN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ST載荷設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ST載荷設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_STN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ST載荷設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ST載荷設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXTRK_BUF_NO_IN_HIRA) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --入庫設定時平置")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --入庫設定時平置")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_IN_HIRA
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --入庫設定時平置")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --入庫設定時平置")
        End If
        intCount = intCount + 1
        If IsNull(mXTRK_BUF_NO_OUT_HIRA) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --出庫設定時平置")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --出庫設定時平置")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_OUT_HIRA
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --出庫設定時平置")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --出庫設定時平置")
        End If
        intCount = intCount + 1
        If IsNull(mXADRS_IN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --入庫指示ｱﾄﾞﾚｽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --入庫指示ｱﾄﾞﾚｽ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_IN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --入庫指示ｱﾄﾞﾚｽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --入庫指示ｱﾄﾞﾚｽ")
        End If
        intCount = intCount + 1
        If IsNull(mXADRS_OUT) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --出庫指示ｱﾄﾞﾚｽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --出庫指示ｱﾄﾞﾚｽ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_OUT
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --出庫指示ｱﾄﾞﾚｽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --出庫指示ｱﾄﾞﾚｽ")
        End If
        intCount = intCount + 1
        If IsNull(mXADRS_HANSOU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --搬送指示ｱﾄﾞﾚｽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --搬送指示ｱﾄﾞﾚｽ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_HANSOU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --搬送指示ｱﾄﾞﾚｽ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --搬送指示ｱﾄﾞﾚｽ")
        End If
        intCount = intCount + 1
        If IsNull(mXADRS_PLCTRK05) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --PLCﾄﾗｯｷﾝｸﾞｱﾄﾞﾚｽ05")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --PLCﾄﾗｯｷﾝｸﾞｱﾄﾞﾚｽ05")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PLCTRK05
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --PLCﾄﾗｯｷﾝｸﾞｱﾄﾞﾚｽ05")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --PLCﾄﾗｯｷﾝｸﾞｱﾄﾞﾚｽ05")
        End If
        intCount = intCount + 1
        If IsNull(mXADRS_PLCTRK04) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --PLCﾄﾗｯｷﾝｸﾞｱﾄﾞﾚｽ04")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --PLCﾄﾗｯｷﾝｸﾞｱﾄﾞﾚｽ04")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PLCTRK04
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --PLCﾄﾗｯｷﾝｸﾞｱﾄﾞﾚｽ04")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --PLCﾄﾗｯｷﾝｸﾞｱﾄﾞﾚｽ04")
        End If
        intCount = intCount + 1
        If IsNull(mXADRS_PALLET01) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾊﾟﾚｯﾄ数ｱﾄﾞﾚｽ01")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾊﾟﾚｯﾄ数ｱﾄﾞﾚｽ01")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PALLET01
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾊﾟﾚｯﾄ数ｱﾄﾞﾚｽ01")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾊﾟﾚｯﾄ数ｱﾄﾞﾚｽ01")
        End If
        intCount = intCount + 1
        If IsNull(mXADRS_PALLET02) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾊﾟﾚｯﾄ数ｱﾄﾞﾚｽ02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾊﾟﾚｯﾄ数ｱﾄﾞﾚｽ02")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PALLET02
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾊﾟﾚｯﾄ数ｱﾄﾞﾚｽ02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾊﾟﾚｯﾄ数ｱﾄﾞﾚｽ02")
        End If
        intCount = intCount + 1
        If IsNull(mXADRS_YOTEI01) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --予定数ｱﾄﾞﾚｽ01")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --予定数ｱﾄﾞﾚｽ01")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_YOTEI01
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --予定数ｱﾄﾞﾚｽ01")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --予定数ｱﾄﾞﾚｽ01")
        End If
        intCount = intCount + 1
        If IsNull(mXADRS_YOTEI02) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --予定数ｱﾄﾞﾚｽ02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --予定数ｱﾄﾞﾚｽ02")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_YOTEI02
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --予定数ｱﾄﾞﾚｽ02")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --予定数ｱﾄﾞﾚｽ02")
        End If
        intCount = intCount + 1
        If IsNull(mXLS_NO) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --L/S番号")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --L/S番号")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXLS_NO
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --L/S番号")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --L/S番号")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_IN_FR) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --入庫要求前設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --入庫要求前設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_IN_FR
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --入庫要求前設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --入庫要求前設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_IN_BK) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --入庫要求後設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --入庫要求後設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_IN_BK
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --入庫要求後設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --入庫要求後設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_HASU_FR) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --端数前設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --端数前設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_HASU_FR
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --端数前設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --端数前設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_HASU_BK) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --端数後設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --端数後設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_HASU_BK
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --端数後設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --端数後設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXTRK_BUF_NO_CONV) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ｺﾝﾍﾞﾔ関連付け")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ｺﾝﾍﾞﾔ関連付け")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_CONV
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ｺﾝﾍﾞﾔ関連付け")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ｺﾝﾍﾞﾔ関連付け")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_IRI_YOUKYU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --入棚入庫要求設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --入棚入庫要求設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_IRI_YOUKYU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --入棚入庫要求設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --入棚入庫要求設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_OUT_YOUKYU) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --出庫要求設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --出庫要求設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_OUT_YOUKYU
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --出庫要求設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --出庫要求設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_OUT_BUF) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --出棚ﾊﾞｯﾌｧ空設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --出棚ﾊﾞｯﾌｧ空設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_OUT_BUF
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --出棚ﾊﾞｯﾌｧ空設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --出棚ﾊﾞｯﾌｧ空設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_OUT_END) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --出庫完了設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --出庫完了設備ID")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_OUT_END
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --出庫完了設備ID")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --出庫完了設備ID")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_B_HENSEI) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --編成№表示")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --編成№表示")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_HENSEI
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --編成№表示")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --編成№表示")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_B_OUTEND) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --出庫完了ﾗﾝﾌﾟ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --出庫完了ﾗﾝﾌﾟ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_OUTEND
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --出庫完了ﾗﾝﾌﾟ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --出庫完了ﾗﾝﾌﾟ")
        End If
        intCount = intCount + 1
        If IsNull(mXEQ_ID_B_TUMIEND) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --積込完了ﾎﾞﾀﾝ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --積込完了ﾎﾞﾀﾝ")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_TUMIEND
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --積込完了ﾎﾞﾀﾝ")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --積込完了ﾎﾞﾀﾝ")
        End If
        intCount = intCount + 1
        If IsNull(mXMAINTE_KUBUN) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾒﾝﾃﾅﾝｽ区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾒﾝﾃﾅﾝｽ区分")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAINTE_KUBUN
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾒﾝﾃﾅﾝｽ区分")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾒﾝﾃﾅﾝｽ区分")
        End If
        intCount = intCount + 1
        If IsNull(mXMAINTE_ORDER) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾒﾝﾃﾅﾝｽ区分順")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾒﾝﾃﾅﾝｽ区分順")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAINTE_ORDER
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾒﾝﾃﾅﾝｽ区分順")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾒﾝﾃﾅﾝｽ区分順")
        End If
        intCount = intCount + 1
        If IsNull(mXMAINTE_NAME) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾒﾝﾃﾅﾝｽ表示名")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾒﾝﾃﾅﾝｽ表示名")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAINTE_NAME
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾒﾝﾃﾅﾝｽ表示名")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾒﾝﾃﾅﾝｽ表示名")
        End If
        intCount = intCount + 1
        If IsNull(mXBUF_NAME_DTL) = True Then
            If intCount = 0 Then strSQL.Append(vbCrLf & "    NULL --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(正式名称)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,NULL --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(正式名称)")
        Else
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & Ubound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBUF_NAME_DTL
            If intCount = 0 Then strSQL.Append(vbCrLf & "    :" & Ubound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(正式名称)")
            If intCount > 0 Then strSQL.Append(vbCrLf & "   ,:" & Ubound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(正式名称)")
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
    Public Sub DELETE_TMST_TRK()
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
        strSQL.Append(vbCrLf & "    TMST_TRK")
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
    Public Sub DELETE_TMST_TRK_ANY()
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
        strSQL.Append(vbCrLf & "    TMST_TRK")
        strSQL.Append(vbCrLf & " WHERE")
        strSQL.Append(vbCrLf & "        1 = 1 ")
        If IsNotNull(FTRK_BUF_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFTRK_BUF_NO
            strSQL.Append(vbCrLf & "    AND FTRK_BUF_NO = :" & UBound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№")
        End If
        If IsNotNull(FBUF_NAME) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_NAME
            strSQL.Append(vbCrLf & "    AND FBUF_NAME = :" & UBound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称")
        End If
        If IsNotNull(FBUF_KIND) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_KIND
            strSQL.Append(vbCrLf & "    AND FBUF_KIND = :" & UBound(strBindField) - 1 & " --ﾊﾞｯﾌｧ種別")
        End If
        If IsNotNull(FNEW_IN_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFNEW_IN_KUBUN
            strSQL.Append(vbCrLf & "    AND FNEW_IN_KUBUN = :" & UBound(strBindField) - 1 & " --新規入庫ﾊﾞｯﾌｧ区分")
        End If
        If IsNotNull(FBUF_MAX) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_MAX
            strSQL.Append(vbCrLf & "    AND FBUF_MAX = :" & UBound(strBindField) - 1 & " --最大ﾊﾞｯﾌｧ件数")
        End If
        If IsNotNull(FBUF_LOG_FLAG) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFBUF_LOG_FLAG
            strSQL.Append(vbCrLf & "    AND FBUF_LOG_FLAG = :" & UBound(strBindField) - 1 & " --ﾛｸﾞ有無ﾌﾗｸﾞ")
        End If
        If IsNotNull(FRAC_RETU_MAX) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_RETU_MAX
            strSQL.Append(vbCrLf & "    AND FRAC_RETU_MAX = :" & UBound(strBindField) - 1 & " --最大列数")
        End If
        If IsNotNull(FRAC_REN_MAX) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_REN_MAX
            strSQL.Append(vbCrLf & "    AND FRAC_REN_MAX = :" & UBound(strBindField) - 1 & " --最大連数")
        End If
        If IsNotNull(FRAC_DAN_MAX) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_DAN_MAX
            strSQL.Append(vbCrLf & "    AND FRAC_DAN_MAX = :" & UBound(strBindField) - 1 & " --最大段数")
        End If
        If IsNotNull(FRAC_EDA_MAX) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mFRAC_EDA_MAX
            strSQL.Append(vbCrLf & "    AND FRAC_EDA_MAX = :" & UBound(strBindField) - 1 & " --最大枝数")
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
        If IsNotNull(XEQ_ID_MOD) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_MOD
            strSQL.Append(vbCrLf & "    AND XEQ_ID_MOD = :" & UBound(strBindField) - 1 & " --ﾓｰﾄﾞ設備ID")
        End If
        If IsNotNull(XEQ_ID_STN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_STN
            strSQL.Append(vbCrLf & "    AND XEQ_ID_STN = :" & UBound(strBindField) - 1 & " --ST載荷設備ID")
        End If
        If IsNotNull(XTRK_BUF_NO_IN_HIRA) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_IN_HIRA
            strSQL.Append(vbCrLf & "    AND XTRK_BUF_NO_IN_HIRA = :" & UBound(strBindField) - 1 & " --入庫設定時平置")
        End If
        If IsNotNull(XTRK_BUF_NO_OUT_HIRA) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_OUT_HIRA
            strSQL.Append(vbCrLf & "    AND XTRK_BUF_NO_OUT_HIRA = :" & UBound(strBindField) - 1 & " --出庫設定時平置")
        End If
        If IsNotNull(XADRS_IN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_IN
            strSQL.Append(vbCrLf & "    AND XADRS_IN = :" & UBound(strBindField) - 1 & " --入庫指示ｱﾄﾞﾚｽ")
        End If
        If IsNotNull(XADRS_OUT) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_OUT
            strSQL.Append(vbCrLf & "    AND XADRS_OUT = :" & UBound(strBindField) - 1 & " --出庫指示ｱﾄﾞﾚｽ")
        End If
        If IsNotNull(XADRS_HANSOU) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_HANSOU
            strSQL.Append(vbCrLf & "    AND XADRS_HANSOU = :" & UBound(strBindField) - 1 & " --搬送指示ｱﾄﾞﾚｽ")
        End If
        If IsNotNull(XADRS_PLCTRK05) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PLCTRK05
            strSQL.Append(vbCrLf & "    AND XADRS_PLCTRK05 = :" & UBound(strBindField) - 1 & " --PLCﾄﾗｯｷﾝｸﾞｱﾄﾞﾚｽ05")
        End If
        If IsNotNull(XADRS_PLCTRK04) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PLCTRK04
            strSQL.Append(vbCrLf & "    AND XADRS_PLCTRK04 = :" & UBound(strBindField) - 1 & " --PLCﾄﾗｯｷﾝｸﾞｱﾄﾞﾚｽ04")
        End If
        If IsNotNull(XADRS_PALLET01) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PALLET01
            strSQL.Append(vbCrLf & "    AND XADRS_PALLET01 = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄ数ｱﾄﾞﾚｽ01")
        End If
        If IsNotNull(XADRS_PALLET02) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_PALLET02
            strSQL.Append(vbCrLf & "    AND XADRS_PALLET02 = :" & UBound(strBindField) - 1 & " --ﾊﾟﾚｯﾄ数ｱﾄﾞﾚｽ02")
        End If
        If IsNotNull(XADRS_YOTEI01) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_YOTEI01
            strSQL.Append(vbCrLf & "    AND XADRS_YOTEI01 = :" & UBound(strBindField) - 1 & " --予定数ｱﾄﾞﾚｽ01")
        End If
        If IsNotNull(XADRS_YOTEI02) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXADRS_YOTEI02
            strSQL.Append(vbCrLf & "    AND XADRS_YOTEI02 = :" & UBound(strBindField) - 1 & " --予定数ｱﾄﾞﾚｽ02")
        End If
        If IsNotNull(XLS_NO) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXLS_NO
            strSQL.Append(vbCrLf & "    AND XLS_NO = :" & UBound(strBindField) - 1 & " --L/S番号")
        End If
        If IsNotNull(XEQ_ID_IN_FR) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_IN_FR
            strSQL.Append(vbCrLf & "    AND XEQ_ID_IN_FR = :" & UBound(strBindField) - 1 & " --入庫要求前設備ID")
        End If
        If IsNotNull(XEQ_ID_IN_BK) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_IN_BK
            strSQL.Append(vbCrLf & "    AND XEQ_ID_IN_BK = :" & UBound(strBindField) - 1 & " --入庫要求後設備ID")
        End If
        If IsNotNull(XEQ_ID_HASU_FR) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_HASU_FR
            strSQL.Append(vbCrLf & "    AND XEQ_ID_HASU_FR = :" & UBound(strBindField) - 1 & " --端数前設備ID")
        End If
        If IsNotNull(XEQ_ID_HASU_BK) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_HASU_BK
            strSQL.Append(vbCrLf & "    AND XEQ_ID_HASU_BK = :" & UBound(strBindField) - 1 & " --端数後設備ID")
        End If
        If IsNotNull(XTRK_BUF_NO_CONV) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXTRK_BUF_NO_CONV
            strSQL.Append(vbCrLf & "    AND XTRK_BUF_NO_CONV = :" & UBound(strBindField) - 1 & " --ｺﾝﾍﾞﾔ関連付け")
        End If
        If IsNotNull(XEQ_ID_IRI_YOUKYU) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_IRI_YOUKYU
            strSQL.Append(vbCrLf & "    AND XEQ_ID_IRI_YOUKYU = :" & UBound(strBindField) - 1 & " --入棚入庫要求設備ID")
        End If
        If IsNotNull(XEQ_ID_OUT_YOUKYU) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_OUT_YOUKYU
            strSQL.Append(vbCrLf & "    AND XEQ_ID_OUT_YOUKYU = :" & UBound(strBindField) - 1 & " --出庫要求設備ID")
        End If
        If IsNotNull(XEQ_ID_OUT_BUF) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_OUT_BUF
            strSQL.Append(vbCrLf & "    AND XEQ_ID_OUT_BUF = :" & UBound(strBindField) - 1 & " --出棚ﾊﾞｯﾌｧ空設備ID")
        End If
        If IsNotNull(XEQ_ID_OUT_END) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_OUT_END
            strSQL.Append(vbCrLf & "    AND XEQ_ID_OUT_END = :" & UBound(strBindField) - 1 & " --出庫完了設備ID")
        End If
        If IsNotNull(XEQ_ID_B_HENSEI) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_HENSEI
            strSQL.Append(vbCrLf & "    AND XEQ_ID_B_HENSEI = :" & UBound(strBindField) - 1 & " --編成№表示")
        End If
        If IsNotNull(XEQ_ID_B_OUTEND) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_OUTEND
            strSQL.Append(vbCrLf & "    AND XEQ_ID_B_OUTEND = :" & UBound(strBindField) - 1 & " --出庫完了ﾗﾝﾌﾟ")
        End If
        If IsNotNull(XEQ_ID_B_TUMIEND) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXEQ_ID_B_TUMIEND
            strSQL.Append(vbCrLf & "    AND XEQ_ID_B_TUMIEND = :" & UBound(strBindField) - 1 & " --積込完了ﾎﾞﾀﾝ")
        End If
        If IsNotNull(XMAINTE_KUBUN) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAINTE_KUBUN
            strSQL.Append(vbCrLf & "    AND XMAINTE_KUBUN = :" & UBound(strBindField) - 1 & " --ﾒﾝﾃﾅﾝｽ区分")
        End If
        If IsNotNull(XMAINTE_ORDER) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAINTE_ORDER
            strSQL.Append(vbCrLf & "    AND XMAINTE_ORDER = :" & UBound(strBindField) - 1 & " --ﾒﾝﾃﾅﾝｽ区分順")
        End If
        If IsNotNull(XMAINTE_NAME) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXMAINTE_NAME
            strSQL.Append(vbCrLf & "    AND XMAINTE_NAME = :" & UBound(strBindField) - 1 & " --ﾒﾝﾃﾅﾝｽ表示名")
        End If
        If IsNotNull(XBUF_NAME_DTL) = True Then
            ReDim Preserve strBindField(UBound(strBindField) + 1)
            ReDim Preserve objBindValue(UBound(objBindValue) + 1)
            strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
            objBindValue(UBound(objBindValue)) = mXBUF_NAME_DTL
            strSQL.Append(vbCrLf & "    AND XBUF_NAME_DTL = :" & UBound(strBindField) - 1 & " --ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(正式名称)")
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
        If IsNothing(objType.GetProperty("FBUF_NAME")) = False Then mFBUF_NAME = objObject.FBUF_NAME 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称
        If IsNothing(objType.GetProperty("FBUF_KIND")) = False Then mFBUF_KIND = objObject.FBUF_KIND 'ﾊﾞｯﾌｧ種別
        If IsNothing(objType.GetProperty("FNEW_IN_KUBUN")) = False Then mFNEW_IN_KUBUN = objObject.FNEW_IN_KUBUN '新規入庫ﾊﾞｯﾌｧ区分
        If IsNothing(objType.GetProperty("FBUF_MAX")) = False Then mFBUF_MAX = objObject.FBUF_MAX '最大ﾊﾞｯﾌｧ件数
        If IsNothing(objType.GetProperty("FBUF_LOG_FLAG")) = False Then mFBUF_LOG_FLAG = objObject.FBUF_LOG_FLAG 'ﾛｸﾞ有無ﾌﾗｸﾞ
        If IsNothing(objType.GetProperty("FRAC_RETU_MAX")) = False Then mFRAC_RETU_MAX = objObject.FRAC_RETU_MAX '最大列数
        If IsNothing(objType.GetProperty("FRAC_REN_MAX")) = False Then mFRAC_REN_MAX = objObject.FRAC_REN_MAX '最大連数
        If IsNothing(objType.GetProperty("FRAC_DAN_MAX")) = False Then mFRAC_DAN_MAX = objObject.FRAC_DAN_MAX '最大段数
        If IsNothing(objType.GetProperty("FRAC_EDA_MAX")) = False Then mFRAC_EDA_MAX = objObject.FRAC_EDA_MAX '最大枝数
        If IsNothing(objType.GetProperty("FPLACE_CD")) = False Then mFPLACE_CD = objObject.FPLACE_CD '保管場所ｺｰﾄﾞ
        If IsNothing(objType.GetProperty("FAREA_CD")) = False Then mFAREA_CD = objObject.FAREA_CD 'ｴﾘｱｺｰﾄﾞ
        If IsNothing(objType.GetProperty("XEQ_ID_MOD")) = False Then mXEQ_ID_MOD = objObject.XEQ_ID_MOD 'ﾓｰﾄﾞ設備ID
        If IsNothing(objType.GetProperty("XEQ_ID_STN")) = False Then mXEQ_ID_STN = objObject.XEQ_ID_STN 'ST載荷設備ID
        If IsNothing(objType.GetProperty("XTRK_BUF_NO_IN_HIRA")) = False Then mXTRK_BUF_NO_IN_HIRA = objObject.XTRK_BUF_NO_IN_HIRA '入庫設定時平置
        If IsNothing(objType.GetProperty("XTRK_BUF_NO_OUT_HIRA")) = False Then mXTRK_BUF_NO_OUT_HIRA = objObject.XTRK_BUF_NO_OUT_HIRA '出庫設定時平置
        If IsNothing(objType.GetProperty("XADRS_IN")) = False Then mXADRS_IN = objObject.XADRS_IN '入庫指示ｱﾄﾞﾚｽ
        If IsNothing(objType.GetProperty("XADRS_OUT")) = False Then mXADRS_OUT = objObject.XADRS_OUT '出庫指示ｱﾄﾞﾚｽ
        If IsNothing(objType.GetProperty("XADRS_HANSOU")) = False Then mXADRS_HANSOU = objObject.XADRS_HANSOU '搬送指示ｱﾄﾞﾚｽ
        If IsNothing(objType.GetProperty("XADRS_PLCTRK05")) = False Then mXADRS_PLCTRK05 = objObject.XADRS_PLCTRK05 'PLCﾄﾗｯｷﾝｸﾞｱﾄﾞﾚｽ05
        If IsNothing(objType.GetProperty("XADRS_PLCTRK04")) = False Then mXADRS_PLCTRK04 = objObject.XADRS_PLCTRK04 'PLCﾄﾗｯｷﾝｸﾞｱﾄﾞﾚｽ04
        If IsNothing(objType.GetProperty("XADRS_PALLET01")) = False Then mXADRS_PALLET01 = objObject.XADRS_PALLET01 'ﾊﾟﾚｯﾄ数ｱﾄﾞﾚｽ01
        If IsNothing(objType.GetProperty("XADRS_PALLET02")) = False Then mXADRS_PALLET02 = objObject.XADRS_PALLET02 'ﾊﾟﾚｯﾄ数ｱﾄﾞﾚｽ02
        If IsNothing(objType.GetProperty("XADRS_YOTEI01")) = False Then mXADRS_YOTEI01 = objObject.XADRS_YOTEI01 '予定数ｱﾄﾞﾚｽ01
        If IsNothing(objType.GetProperty("XADRS_YOTEI02")) = False Then mXADRS_YOTEI02 = objObject.XADRS_YOTEI02 '予定数ｱﾄﾞﾚｽ02
        If IsNothing(objType.GetProperty("XLS_NO")) = False Then mXLS_NO = objObject.XLS_NO 'L/S番号
        If IsNothing(objType.GetProperty("XEQ_ID_IN_FR")) = False Then mXEQ_ID_IN_FR = objObject.XEQ_ID_IN_FR '入庫要求前設備ID
        If IsNothing(objType.GetProperty("XEQ_ID_IN_BK")) = False Then mXEQ_ID_IN_BK = objObject.XEQ_ID_IN_BK '入庫要求後設備ID
        If IsNothing(objType.GetProperty("XEQ_ID_HASU_FR")) = False Then mXEQ_ID_HASU_FR = objObject.XEQ_ID_HASU_FR '端数前設備ID
        If IsNothing(objType.GetProperty("XEQ_ID_HASU_BK")) = False Then mXEQ_ID_HASU_BK = objObject.XEQ_ID_HASU_BK '端数後設備ID
        If IsNothing(objType.GetProperty("XTRK_BUF_NO_CONV")) = False Then mXTRK_BUF_NO_CONV = objObject.XTRK_BUF_NO_CONV 'ｺﾝﾍﾞﾔ関連付け
        If IsNothing(objType.GetProperty("XEQ_ID_IRI_YOUKYU")) = False Then mXEQ_ID_IRI_YOUKYU = objObject.XEQ_ID_IRI_YOUKYU '入棚入庫要求設備ID
        If IsNothing(objType.GetProperty("XEQ_ID_OUT_YOUKYU")) = False Then mXEQ_ID_OUT_YOUKYU = objObject.XEQ_ID_OUT_YOUKYU '出庫要求設備ID
        If IsNothing(objType.GetProperty("XEQ_ID_OUT_BUF")) = False Then mXEQ_ID_OUT_BUF = objObject.XEQ_ID_OUT_BUF '出棚ﾊﾞｯﾌｧ空設備ID
        If IsNothing(objType.GetProperty("XEQ_ID_OUT_END")) = False Then mXEQ_ID_OUT_END = objObject.XEQ_ID_OUT_END '出庫完了設備ID
        If IsNothing(objType.GetProperty("XEQ_ID_B_HENSEI")) = False Then mXEQ_ID_B_HENSEI = objObject.XEQ_ID_B_HENSEI '編成№表示
        If IsNothing(objType.GetProperty("XEQ_ID_B_OUTEND")) = False Then mXEQ_ID_B_OUTEND = objObject.XEQ_ID_B_OUTEND '出庫完了ﾗﾝﾌﾟ
        If IsNothing(objType.GetProperty("XEQ_ID_B_TUMIEND")) = False Then mXEQ_ID_B_TUMIEND = objObject.XEQ_ID_B_TUMIEND '積込完了ﾎﾞﾀﾝ
        If IsNothing(objType.GetProperty("XMAINTE_KUBUN")) = False Then mXMAINTE_KUBUN = objObject.XMAINTE_KUBUN 'ﾒﾝﾃﾅﾝｽ区分
        If IsNothing(objType.GetProperty("XMAINTE_ORDER")) = False Then mXMAINTE_ORDER = objObject.XMAINTE_ORDER 'ﾒﾝﾃﾅﾝｽ区分順
        If IsNothing(objType.GetProperty("XMAINTE_NAME")) = False Then mXMAINTE_NAME = objObject.XMAINTE_NAME 'ﾒﾝﾃﾅﾝｽ表示名
        If IsNothing(objType.GetProperty("XBUF_NAME_DTL")) = False Then mXBUF_NAME_DTL = objObject.XBUF_NAME_DTL 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(正式名称)

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
        mFBUF_NAME = Nothing
        mFBUF_KIND = Nothing
        mFNEW_IN_KUBUN = Nothing
        mFBUF_MAX = Nothing
        mFBUF_LOG_FLAG = Nothing
        mFRAC_RETU_MAX = Nothing
        mFRAC_REN_MAX = Nothing
        mFRAC_DAN_MAX = Nothing
        mFRAC_EDA_MAX = Nothing
        mFPLACE_CD = Nothing
        mFAREA_CD = Nothing
        mXEQ_ID_MOD = Nothing
        mXEQ_ID_STN = Nothing
        mXTRK_BUF_NO_IN_HIRA = Nothing
        mXTRK_BUF_NO_OUT_HIRA = Nothing
        mXADRS_IN = Nothing
        mXADRS_OUT = Nothing
        mXADRS_HANSOU = Nothing
        mXADRS_PLCTRK05 = Nothing
        mXADRS_PLCTRK04 = Nothing
        mXADRS_PALLET01 = Nothing
        mXADRS_PALLET02 = Nothing
        mXADRS_YOTEI01 = Nothing
        mXADRS_YOTEI02 = Nothing
        mXLS_NO = Nothing
        mXEQ_ID_IN_FR = Nothing
        mXEQ_ID_IN_BK = Nothing
        mXEQ_ID_HASU_FR = Nothing
        mXEQ_ID_HASU_BK = Nothing
        mXTRK_BUF_NO_CONV = Nothing
        mXEQ_ID_IRI_YOUKYU = Nothing
        mXEQ_ID_OUT_YOUKYU = Nothing
        mXEQ_ID_OUT_BUF = Nothing
        mXEQ_ID_OUT_END = Nothing
        mXEQ_ID_B_HENSEI = Nothing
        mXEQ_ID_B_OUTEND = Nothing
        mXEQ_ID_B_TUMIEND = Nothing
        mXMAINTE_KUBUN = Nothing
        mXMAINTE_ORDER = Nothing
        mXMAINTE_NAME = Nothing
        mXBUF_NAME_DTL = Nothing


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
        mFBUF_NAME = TO_STRING_NULLABLE(objRow("FBUF_NAME"))
        mFBUF_KIND = TO_INTEGER_NULLABLE(objRow("FBUF_KIND"))
        mFNEW_IN_KUBUN = TO_INTEGER_NULLABLE(objRow("FNEW_IN_KUBUN"))
        mFBUF_MAX = TO_INTEGER_NULLABLE(objRow("FBUF_MAX"))
        mFBUF_LOG_FLAG = TO_INTEGER_NULLABLE(objRow("FBUF_LOG_FLAG"))
        mFRAC_RETU_MAX = TO_INTEGER_NULLABLE(objRow("FRAC_RETU_MAX"))
        mFRAC_REN_MAX = TO_INTEGER_NULLABLE(objRow("FRAC_REN_MAX"))
        mFRAC_DAN_MAX = TO_INTEGER_NULLABLE(objRow("FRAC_DAN_MAX"))
        mFRAC_EDA_MAX = TO_INTEGER_NULLABLE(objRow("FRAC_EDA_MAX"))
        mFPLACE_CD = TO_INTEGER_NULLABLE(objRow("FPLACE_CD"))
        mFAREA_CD = TO_INTEGER_NULLABLE(objRow("FAREA_CD"))
        mXEQ_ID_MOD = TO_STRING_NULLABLE(objRow("XEQ_ID_MOD"))
        mXEQ_ID_STN = TO_STRING_NULLABLE(objRow("XEQ_ID_STN"))
        mXTRK_BUF_NO_IN_HIRA = TO_INTEGER_NULLABLE(objRow("XTRK_BUF_NO_IN_HIRA"))
        mXTRK_BUF_NO_OUT_HIRA = TO_INTEGER_NULLABLE(objRow("XTRK_BUF_NO_OUT_HIRA"))
        mXADRS_IN = TO_STRING_NULLABLE(objRow("XADRS_IN"))
        mXADRS_OUT = TO_STRING_NULLABLE(objRow("XADRS_OUT"))
        mXADRS_HANSOU = TO_STRING_NULLABLE(objRow("XADRS_HANSOU"))
        mXADRS_PLCTRK05 = TO_STRING_NULLABLE(objRow("XADRS_PLCTRK05"))
        mXADRS_PLCTRK04 = TO_STRING_NULLABLE(objRow("XADRS_PLCTRK04"))
        mXADRS_PALLET01 = TO_STRING_NULLABLE(objRow("XADRS_PALLET01"))
        mXADRS_PALLET02 = TO_STRING_NULLABLE(objRow("XADRS_PALLET02"))
        mXADRS_YOTEI01 = TO_STRING_NULLABLE(objRow("XADRS_YOTEI01"))
        mXADRS_YOTEI02 = TO_STRING_NULLABLE(objRow("XADRS_YOTEI02"))
        mXLS_NO = TO_INTEGER_NULLABLE(objRow("XLS_NO"))
        mXEQ_ID_IN_FR = TO_STRING_NULLABLE(objRow("XEQ_ID_IN_FR"))
        mXEQ_ID_IN_BK = TO_STRING_NULLABLE(objRow("XEQ_ID_IN_BK"))
        mXEQ_ID_HASU_FR = TO_STRING_NULLABLE(objRow("XEQ_ID_HASU_FR"))
        mXEQ_ID_HASU_BK = TO_STRING_NULLABLE(objRow("XEQ_ID_HASU_BK"))
        mXTRK_BUF_NO_CONV = TO_INTEGER_NULLABLE(objRow("XTRK_BUF_NO_CONV"))
        mXEQ_ID_IRI_YOUKYU = TO_STRING_NULLABLE(objRow("XEQ_ID_IRI_YOUKYU"))
        mXEQ_ID_OUT_YOUKYU = TO_STRING_NULLABLE(objRow("XEQ_ID_OUT_YOUKYU"))
        mXEQ_ID_OUT_BUF = TO_STRING_NULLABLE(objRow("XEQ_ID_OUT_BUF"))
        mXEQ_ID_OUT_END = TO_STRING_NULLABLE(objRow("XEQ_ID_OUT_END"))
        mXEQ_ID_B_HENSEI = TO_STRING_NULLABLE(objRow("XEQ_ID_B_HENSEI"))
        mXEQ_ID_B_OUTEND = TO_STRING_NULLABLE(objRow("XEQ_ID_B_OUTEND"))
        mXEQ_ID_B_TUMIEND = TO_STRING_NULLABLE(objRow("XEQ_ID_B_TUMIEND"))
        mXMAINTE_KUBUN = TO_INTEGER_NULLABLE(objRow("XMAINTE_KUBUN"))
        mXMAINTE_ORDER = TO_INTEGER_NULLABLE(objRow("XMAINTE_ORDER"))
        mXMAINTE_NAME = TO_STRING_NULLABLE(objRow("XMAINTE_NAME"))
        mXBUF_NAME_DTL = TO_STRING_NULLABLE(objRow("XBUF_NAME_DTL"))


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
        strMsg &= "[ﾃｰﾌﾞﾙ名:ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ]"
        If IsNotNull(FTRK_BUF_NO) Then
            strMsg &= "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№:" & FTRK_BUF_NO & "]"
        End If
        If IsNotNull(FBUF_NAME) Then
            strMsg &= "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称:" & FBUF_NAME & "]"
        End If
        If IsNotNull(FBUF_KIND) Then
            strMsg &= "[ﾊﾞｯﾌｧ種別:" & FBUF_KIND & "]"
        End If
        If IsNotNull(FNEW_IN_KUBUN) Then
            strMsg &= "[新規入庫ﾊﾞｯﾌｧ区分:" & FNEW_IN_KUBUN & "]"
        End If
        If IsNotNull(FBUF_MAX) Then
            strMsg &= "[最大ﾊﾞｯﾌｧ件数:" & FBUF_MAX & "]"
        End If
        If IsNotNull(FBUF_LOG_FLAG) Then
            strMsg &= "[ﾛｸﾞ有無ﾌﾗｸﾞ:" & FBUF_LOG_FLAG & "]"
        End If
        If IsNotNull(FRAC_RETU_MAX) Then
            strMsg &= "[最大列数:" & FRAC_RETU_MAX & "]"
        End If
        If IsNotNull(FRAC_REN_MAX) Then
            strMsg &= "[最大連数:" & FRAC_REN_MAX & "]"
        End If
        If IsNotNull(FRAC_DAN_MAX) Then
            strMsg &= "[最大段数:" & FRAC_DAN_MAX & "]"
        End If
        If IsNotNull(FRAC_EDA_MAX) Then
            strMsg &= "[最大枝数:" & FRAC_EDA_MAX & "]"
        End If
        If IsNotNull(FPLACE_CD) Then
            strMsg &= "[保管場所ｺｰﾄﾞ:" & FPLACE_CD & "]"
        End If
        If IsNotNull(FAREA_CD) Then
            strMsg &= "[ｴﾘｱｺｰﾄﾞ:" & FAREA_CD & "]"
        End If
        If IsNotNull(XEQ_ID_MOD) Then
            strMsg &= "[ﾓｰﾄﾞ設備ID:" & XEQ_ID_MOD & "]"
        End If
        If IsNotNull(XEQ_ID_STN) Then
            strMsg &= "[ST載荷設備ID:" & XEQ_ID_STN & "]"
        End If
        If IsNotNull(XTRK_BUF_NO_IN_HIRA) Then
            strMsg &= "[入庫設定時平置:" & XTRK_BUF_NO_IN_HIRA & "]"
        End If
        If IsNotNull(XTRK_BUF_NO_OUT_HIRA) Then
            strMsg &= "[出庫設定時平置:" & XTRK_BUF_NO_OUT_HIRA & "]"
        End If
        If IsNotNull(XADRS_IN) Then
            strMsg &= "[入庫指示ｱﾄﾞﾚｽ:" & XADRS_IN & "]"
        End If
        If IsNotNull(XADRS_OUT) Then
            strMsg &= "[出庫指示ｱﾄﾞﾚｽ:" & XADRS_OUT & "]"
        End If
        If IsNotNull(XADRS_HANSOU) Then
            strMsg &= "[搬送指示ｱﾄﾞﾚｽ:" & XADRS_HANSOU & "]"
        End If
        If IsNotNull(XADRS_PLCTRK05) Then
            strMsg &= "[PLCﾄﾗｯｷﾝｸﾞｱﾄﾞﾚｽ05:" & XADRS_PLCTRK05 & "]"
        End If
        If IsNotNull(XADRS_PLCTRK04) Then
            strMsg &= "[PLCﾄﾗｯｷﾝｸﾞｱﾄﾞﾚｽ04:" & XADRS_PLCTRK04 & "]"
        End If
        If IsNotNull(XADRS_PALLET01) Then
            strMsg &= "[ﾊﾟﾚｯﾄ数ｱﾄﾞﾚｽ01:" & XADRS_PALLET01 & "]"
        End If
        If IsNotNull(XADRS_PALLET02) Then
            strMsg &= "[ﾊﾟﾚｯﾄ数ｱﾄﾞﾚｽ02:" & XADRS_PALLET02 & "]"
        End If
        If IsNotNull(XADRS_YOTEI01) Then
            strMsg &= "[予定数ｱﾄﾞﾚｽ01:" & XADRS_YOTEI01 & "]"
        End If
        If IsNotNull(XADRS_YOTEI02) Then
            strMsg &= "[予定数ｱﾄﾞﾚｽ02:" & XADRS_YOTEI02 & "]"
        End If
        If IsNotNull(XLS_NO) Then
            strMsg &= "[L/S番号:" & XLS_NO & "]"
        End If
        If IsNotNull(XEQ_ID_IN_FR) Then
            strMsg &= "[入庫要求前設備ID:" & XEQ_ID_IN_FR & "]"
        End If
        If IsNotNull(XEQ_ID_IN_BK) Then
            strMsg &= "[入庫要求後設備ID:" & XEQ_ID_IN_BK & "]"
        End If
        If IsNotNull(XEQ_ID_HASU_FR) Then
            strMsg &= "[端数前設備ID:" & XEQ_ID_HASU_FR & "]"
        End If
        If IsNotNull(XEQ_ID_HASU_BK) Then
            strMsg &= "[端数後設備ID:" & XEQ_ID_HASU_BK & "]"
        End If
        If IsNotNull(XTRK_BUF_NO_CONV) Then
            strMsg &= "[ｺﾝﾍﾞﾔ関連付け:" & XTRK_BUF_NO_CONV & "]"
        End If
        If IsNotNull(XEQ_ID_IRI_YOUKYU) Then
            strMsg &= "[入棚入庫要求設備ID:" & XEQ_ID_IRI_YOUKYU & "]"
        End If
        If IsNotNull(XEQ_ID_OUT_YOUKYU) Then
            strMsg &= "[出庫要求設備ID:" & XEQ_ID_OUT_YOUKYU & "]"
        End If
        If IsNotNull(XEQ_ID_OUT_BUF) Then
            strMsg &= "[出棚ﾊﾞｯﾌｧ空設備ID:" & XEQ_ID_OUT_BUF & "]"
        End If
        If IsNotNull(XEQ_ID_OUT_END) Then
            strMsg &= "[出庫完了設備ID:" & XEQ_ID_OUT_END & "]"
        End If
        If IsNotNull(XEQ_ID_B_HENSEI) Then
            strMsg &= "[編成№表示:" & XEQ_ID_B_HENSEI & "]"
        End If
        If IsNotNull(XEQ_ID_B_OUTEND) Then
            strMsg &= "[出庫完了ﾗﾝﾌﾟ:" & XEQ_ID_B_OUTEND & "]"
        End If
        If IsNotNull(XEQ_ID_B_TUMIEND) Then
            strMsg &= "[積込完了ﾎﾞﾀﾝ:" & XEQ_ID_B_TUMIEND & "]"
        End If
        If IsNotNull(XMAINTE_KUBUN) Then
            strMsg &= "[ﾒﾝﾃﾅﾝｽ区分:" & XMAINTE_KUBUN & "]"
        End If
        If IsNotNull(XMAINTE_ORDER) Then
            strMsg &= "[ﾒﾝﾃﾅﾝｽ区分順:" & XMAINTE_ORDER & "]"
        End If
        If IsNotNull(XMAINTE_NAME) Then
            strMsg &= "[ﾒﾝﾃﾅﾝｽ表示名:" & XMAINTE_NAME & "]"
        End If
        If IsNotNull(XBUF_NAME_DTL) Then
            strMsg &= "[ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(正式名称):" & XBUF_NAME_DTL & "]"
        End If


    End Sub
#End Region
    '↑↑↑自動生成部
    '**********************************************************************************************

    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ共通
#Region "  ﾃﾞｰﾀ取得(保管場所ｺｰﾄﾞ&ｴﾘｱ)   (Public  GET_TMST_TRK_FPLACE_AREA)"
    Public Function GET_TMST_TRK_FPLACE_AREA() As RetCode
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
            ElseIf IsNull(mFPLACE_CD) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[保管場所ｺｰﾄﾞ]"
                Throw New UserException(strMsg)
            ElseIf IsNull(mFAREA_CD) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[ｴﾘｱ]"
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
            strSQL.Append(vbCrLf & "    TMST_TRK")
            strSQL.Append(vbCrLf & " WHERE")
            strSQL.Append(vbCrLf & "        1 = 1")
            If IsNull(FPLACE_CD) = True Then
                strSQL.Append(vbCrLf & "    AND FPLACE_CD IS NULL --保管場所ｺｰﾄﾞ")
            Else
                ReDim Preserve strBindField(UBound(strBindField) + 1)
                ReDim Preserve objBindValue(UBound(objBindValue) + 1)
                strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
                objBindValue(UBound(objBindValue)) = mFPLACE_CD
                strSQL.Append(vbCrLf & "    AND FPLACE_CD = :" & UBound(strBindField) - 1 & " --保管場所ｺｰﾄﾞ")
            End If
            If IsNull(FAREA_CD) = True Then
                strSQL.Append(vbCrLf & "    AND FAREA_CD IS NULL --ｴﾘｱ")
            Else
                ReDim Preserve strBindField(UBound(strBindField) + 1)
                ReDim Preserve objBindValue(UBound(objBindValue) + 1)
                strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
                objBindValue(UBound(objBindValue)) = mFAREA_CD
                strSQL.Append(vbCrLf & "    AND FAREA_CD = :" & UBound(strBindField) - 1 & " --ｴﾘｱ")
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
            '抽出
            '***********************
            ObjDb.SQL = strSQL.ToString
            ObjDb.Parameter = objParameter
            objDataSet.Clear()
            strDataSetName = "TMST_TRK"
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
    '↑↑↑ｼｽﾃﾑ共通
    '**********************************************************************************************


    '**********************************************************************************************
    '↓↓↓ｼｽﾃﾑ固有
#Region "  ﾃﾞｰﾀ取得(保管場所ｺｰﾄﾞ)       (Public  GET_TMST_TRK_FPLACE)"
    Public Function GET_TMST_TRK_FPLACE() As RetCode
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
            ElseIf IsNull(mFPLACE_CD) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[保管場所ｺｰﾄﾞ]"
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
            strSQL.Append(vbCrLf & "    TMST_TRK")
            strSQL.Append(vbCrLf & " WHERE")
            strSQL.Append(vbCrLf & "        1 = 1")
            If IsNull(FPLACE_CD) = True Then
                strSQL.Append(vbCrLf & "    AND FPLACE_CD IS NULL --保管場所ｺｰﾄﾞ")
            Else
                ReDim Preserve strBindField(UBound(strBindField) + 1)
                ReDim Preserve objBindValue(UBound(objBindValue) + 1)
                strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
                objBindValue(UBound(objBindValue)) = mFPLACE_CD
                strSQL.Append(vbCrLf & "    AND FPLACE_CD = :" & UBound(strBindField) - 1 & " --保管場所ｺｰﾄﾞ")
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
            '抽出
            '***********************
            ObjDb.SQL = strSQL.ToString
            ObjDb.Parameter = objParameter
            objDataSet.Clear()
            strDataSetName = "TMST_TRK"
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
#Region "  ﾃﾞｰﾀ取得(保管場所ｺｰﾄﾞ(棚のみ))       (Public  GET_TMST_TRK_FPLACE_RAC)"
    Public Function GET_TMST_TRK_FPLACE_RAC() As RetCode
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
            ElseIf IsNull(mFPLACE_CD) = True Then
                strMsg = ERRMSG_ERR_PROPERTY & "[保管場所ｺｰﾄﾞ]"
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
            strSQL.Append(vbCrLf & "    TMST_TRK")
            strSQL.Append(vbCrLf & " WHERE")
            strSQL.Append(vbCrLf & "        1 = 1")
            strSQL.Append(vbCrLf & "        AND FBUF_KIND = " & TO_STRING(FBUF_KIND_SASRS))
            If IsNull(FPLACE_CD) = True Then
                strSQL.Append(vbCrLf & "    AND FPLACE_CD IS NULL --保管場所ｺｰﾄﾞ")
            Else
                ReDim Preserve strBindField(UBound(strBindField) + 1)
                ReDim Preserve objBindValue(UBound(objBindValue) + 1)
                strBindField(UBound(strBindField)) = ":" & UBound(strBindField) - 1
                objBindValue(UBound(objBindValue)) = mFPLACE_CD
                strSQL.Append(vbCrLf & "    AND FPLACE_CD = :" & UBound(strBindField) - 1 & " --保管場所ｺｰﾄﾞ")
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
            '抽出
            '***********************
            ObjDb.SQL = strSQL.ToString
            ObjDb.Parameter = objParameter
            objDataSet.Clear()
            strDataSetName = "TMST_TRK"
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

#Region "  ﾃﾞｰﾀ→変数                   "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀ→変数
    ''' </summary>
    ''' <param name="objRow">ﾃﾞｰﾀﾚｺｰﾄﾞｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub SET_DATA_PLC(ByVal objRow As DataRow)


        '***********************
        'ﾃﾞｰﾀｾｯﾄ
        '***********************
        mFTRK_BUF_NO = TO_INTEGER_NULLABLE(objRow("FTRK_BUF_NO"))
        mXADRS_IN = TO_STRING_NULLABLE(objRow("XADRS_IN"))
        mXADRS_OUT = TO_STRING_NULLABLE(objRow("XADRS_OUT"))
        mXMAINTE_KUBUN = TO_INTEGER_NULLABLE(objRow("XMAINTE_KUBUN"))
        mXMAINTE_ORDER = TO_INTEGER_NULLABLE(objRow("XMAINTE_ORDER"))
        mXMAINTE_NAME = TO_STRING_NULLABLE(objRow("XMAINTE_NAME"))


    End Sub
#End Region
#Region "  ﾃﾞｰﾀ取得(ｶｽﾀﾑ抽出)(PLC)           "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾃﾞｰﾀ取得(ｶｽﾀﾑ抽出)(PLC)
    ''' </summary>
    ''' <param name="objUSER_PARAM">ﾕｰｻﾞｰPARAM (ﾊﾞｲﾝﾄﾞ変数用ｵﾌﾞｼﾞｪｸﾄ型配列)</param>
    ''' <returns>共通戻り値</returns>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Public Function GET_TMST_TRK_USER_PLC(Optional ByRef objUSER_PARAM As Object(,) = Nothing) As RetCode
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
        strDataSetName = "TMST_TRK"
        ObjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            ReDim Preserve mobjAryMe(objDataSet.Tables(strDataSetName).Rows.Count - 1)
            For ii = LBound(mobjAryMe) To UBound(mobjAryMe)
                objRow = objDataSet.Tables(strDataSetName).Rows(ii)
                mobjAryMe(ii) = New TBL_TMST_TRK(Owner, ObjDb, ObjDbLog)
                mobjAryMe(ii).SET_DATA_PLC(objRow)
            Next ii
            Return (RetCode.OK)
        Else
            Return (RetCode.NotFound)
        End If


    End Function
#End Region

    '↑↑↑ｼｽﾃﾑ固有
    '**********************************************************************************************

End Class
