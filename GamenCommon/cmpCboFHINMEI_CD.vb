'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】品名ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ ｶｽﾀﾑｺﾝﾄﾛｰﾙ
' 【機能】何らかのｷｰ入力があった場合のみ、入力された値を元に下記処理を実行する
'           品名ｺｰﾄﾞを検索し、品名ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽのﾘｽﾄをｾｯﾄ
'           品名ｺｰﾄﾞに対応する名称、色名称を取得･表示
' 【作成】SIT
'                               SIT J.Kato          Rev 0.01    品名と品名略称に対応
'**********************************************************************************************

#Region "  Imports  "
Imports JobCommon
Imports MateCommon
Imports MateCommon.clsConst
#End Region

''' <summary>
''' 品名ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ ｶｽﾀﾑｺﾝﾄﾛｰﾙ
''' </summary>
Public Class cmpCboFHINMEI_CD

#Region "  ｸﾗｽ変数定義                      "

    Private mstrSQL As String                           'SQL文
    Private mobjDb As clsConn                           'ｺﾈｸｼｮﾝ
    Private mblnKeyPressFlg As Boolean                  'ｷｰﾌﾟﾚｽｲﾍﾞﾝﾄ
    Private mintCol1Width As Integer = 150              'Col1の列幅
    Private mblnHinmeiVisible As Boolean = True         '品名列表示ﾌﾗｸﾞ
    Private mstrSeihinKubun As String = ""              '製品区分   ※標準のほうは製品区分で作っているため、のこしてあります。
    Private mstrZaikoKubun() As String                  '在庫区分
    Private mstrArticleTypeCode() As String             '品目種別ｺｰﾄﾞ
    Private mobjHinmeiLabel As Windows.Forms.Label = Nothing  '品名ﾗﾍﾞﾙ
    Private mstrTableName As String                     'ﾃｰﾌﾞﾙ名
    Private mobjTaniLabel As Windows.Forms.Label = Nothing  '単位ﾗﾍﾞﾙ
    Private mobjArticleShortName As Windows.Forms.Label = Nothing   '品名略称ﾗﾍﾞﾙ
    Private mudtDispNameType As DispNameType = DispNameType.FullName        'ｺﾝﾎﾞﾎﾞｯｸｽに表示する品名のﾀｲﾌﾟ
    Private mstrPlaceDetailCode() As String                   '保管場所(標準保管場所)

    '↓↓↓↓↓ システム固有
    Private mstrXHINMEI_KIND() As String                '品番形状種別
    '↓↓↓↓↓↓ 2012.10.30 H.Morita KAGOME
    Private mstrXLINE_NO As String                     'ﾗｲﾝ№
    '↑↑↑↑↑↑ 2012.10.30 H.Morita KAGOME

    '↓↓↓↓↓↓ 2012.09.27 H.Morita KAGOME
    Private mstrFTRK_BUF_NO() As String                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
    Private mstrFRES_KIND As String = ""               '引当状態
    '↑↑↑↑↑↑ 2012.09.27 H.Morita KAGOME

    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:A.Noto 2012/11/29 生産入庫設定画面追加
    Private mstrXKANRI_KUBUN As String                  '管理区分
    '↑↑↑↑↑↑************************************************************************************************************

    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:H.Okumura 2013/07/23 品目一致判定追加
    Private mblnFIND_FLAG As Boolean                    '品目一致判定
    '↑↑↑↑↑↑************************************************************************************************************

    '↑↑↑↑↑ システム固有

    Private mudtCboType As HINMEI_CBO_TYPE = HINMEI_CBO_TYPE.SpecifiedTableData 'ｺﾝﾎﾞﾎﾞｯｸｽ作成ﾀｲﾌﾟ
    Private mstrMasterTableName As String = "TMST_ITEM"     '品名ﾏｽﾀﾃｰﾌﾞﾙ

    ''' <summary>
    ''' 品名ｺﾝﾎﾞﾎﾞｯｸｽﾀｲﾌﾟ
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum HINMEI_CBO_TYPE
        ''' <summary>指定ﾃｰﾌﾞﾙでｺﾝﾎﾞﾎﾞｯｸｽ作成</summary>
        SpecifiedTableData = 1
        ''' <summary>指定ﾃｰﾌﾞﾙとﾏｽﾀﾃｰﾌﾞﾙを結合しｺﾝﾎﾞﾎﾞｯｸｽ作成</summary>
        SpecifiedAndMasterData = 2
    End Enum

#End Region
#Region "　列挙体                           "

    ''' <summary>
    ''' ｺﾝﾎﾞﾎﾞｯｸｽに表示する品名のﾀｲﾌﾟを設定
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum DispNameType
        ''' <summary>略称を表示</summary>
        ShortName = 0
        ''' <summary>名称を表示</summary>
        FullName = 1
    End Enum

#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義                      "
    ''' ====================================
    ''' <summary>
    ''' ｺﾈｸｼｮﾝｵﾌﾞｼﾞｪｸﾄ
    ''' </summary>
    ''' <value>ｺﾈｸｼｮﾝｵﾌﾞｼﾞｪｸﾄ</value>
    ''' <returns>ｺﾈｸｼｮﾝｵﾌﾞｼﾞｪｸﾄ</returns>
    ''' <remarks></remarks>
    ''' ====================================
    Public Property conn() As clsConn
        Get
            Return mobjDb
        End Get
        Set(ByVal Value As clsConn)
            mobjDb = Value
        End Set
    End Property

    ''' ====================================
    ''' <summary>
    ''' Col1列幅
    ''' </summary>
    ''' <value>Col1列幅</value>
    ''' <returns>Col1列幅</returns>
    ''' <remarks>列1の列幅を設定または参照します。</remarks>
    ''' ====================================
    Public Property Col1Width() As Integer
        Get
            Return mintCol1Width
        End Get
        Set(ByVal Value As Integer)
            mintCol1Width = Value
        End Set
    End Property

    ''' ====================================
    ''' <summary>
    ''' 品名列表示設定
    ''' </summary>
    ''' <value>True / False</value>
    ''' <returns>True / False</returns>
    ''' <remarks>品名列の表示、非表示を設定または参照します。</remarks>
    ''' ====================================
    Public Property HinmeiVisible() As Boolean
        Get
            Return mblnHinmeiVisible
        End Get
        Set(ByVal Value As Boolean)
            mblnHinmeiVisible = Value
        End Set
    End Property

    ''' ====================================
    ''' <summary>
    ''' 製品区分
    ''' </summary>
    ''' <value>製品区分</value>
    ''' <returns>製品区分</returns>
    ''' <remarks>製品区分の設定または参照します。</remarks>
    ''' ====================================
    Public Property SeihinKubun() As String
        Get
            Return mstrSeihinKubun
        End Get
        Set(ByVal Value As String)
            mstrSeihinKubun = Value
        End Set
    End Property

    ''' ====================================
    ''' <summary>
    ''' 在庫区分
    ''' </summary>
    ''' <value>在庫区分</value>
    ''' <returns>在庫区分</returns>
    ''' <remarks>在庫区分の設定または参照します。(配列)</remarks>
    ''' ====================================
    Public Property ZaikoKubun() As String()
        Get
            Return mstrZaikoKubun
        End Get
        Set(ByVal Value() As String)
            mstrZaikoKubun = Value
        End Set
    End Property

    ''' ====================================
    ''' <summary>
    ''' 品目種別ｺｰﾄﾞ
    ''' </summary>
    ''' <value>品目種別ｺｰﾄﾞ</value>
    ''' <returns>品目種別ｺｰﾄﾞ</returns>
    ''' <remarks>品目種別ｺｰﾄﾞの設定または参照します。(配列)</remarks>
    ''' ====================================
    Public Property ArticleTypeCode() As String()
        Get
            Return mstrArticleTypeCode
        End Get
        Set(ByVal Value() As String)
            mstrArticleTypeCode = Value
        End Set
    End Property

    ''' ====================================
    ''' <summary>
    ''' 品名ﾗﾍﾞﾙ
    ''' </summary>
    ''' <value>ﾗﾍﾞﾙｵﾌﾞｼﾞｪｸﾄ</value>
    ''' <returns>ﾗﾍﾞﾙｵﾌﾞｼﾞｪｸﾄ</returns>
    ''' <remarks>品名ﾗﾍﾞﾙｵﾌﾞｼﾞｪｸﾄを設定します。</remarks>
    ''' ====================================
    Public Property HinmeiLabel() As Windows.Forms.Label
        Get
            Return mobjHinmeiLabel
        End Get
        Set(ByVal Value As Windows.Forms.Label)
            mobjHinmeiLabel = Value
        End Set
    End Property

    ''' ====================================
    ''' <summary>
    ''' ﾃﾞｰﾀ取得ﾃｰﾌﾞﾙ名
    ''' </summary>
    ''' <value>ﾃｰﾌﾞﾙ名</value>
    ''' <returns>ﾃｰﾌﾞﾙ名</returns>
    ''' <remarks>ｺﾝﾎﾞﾎﾞｯｸｽのｱｲﾃﾑを取得するﾃｰﾌﾞﾙ名を設定または参照します。</remarks>
    ''' ====================================
    Public Property TableName() As String
        Get
            Return mstrTableName
        End Get
        Set(ByVal Value As String)
            mstrTableName = Value
        End Set
    End Property

    ''' ====================================
    ''' <summary>
    ''' ﾏｽﾀﾃｰﾌﾞﾙ名(結合用)
    ''' </summary>
    ''' <value>ﾏｽﾀﾃｰﾌﾞﾙ名</value>
    ''' <returns>ﾏｽﾀﾃｰﾌﾞﾙ名</returns>
    ''' <remarks>ｺﾝﾎﾞﾎﾞｯｸｽのｱｲﾃﾑを取得するﾏｽﾀﾃｰﾌﾞﾙ名を設定または参照します。</remarks>
    ''' ====================================
    Public Property MaterTableName() As String
        Get
            Return mstrMasterTableName
        End Get
        Set(ByVal value As String)
            mstrMasterTableName = value
        End Set
    End Property

    ''' ====================================
    ''' <summary>
    ''' ｺﾝﾎﾞﾎﾞｯｸｽ作成ﾀｲﾌﾟ
    ''' </summary>
    ''' <value>作成ﾀｲﾌﾟ</value>
    ''' <returns>作成ﾀｲﾌﾟ</returns>
    ''' <remarks>ｺﾝﾎﾞﾎﾞｯｸｽの作成ﾀｲﾌﾟを設定または参照します。</remarks>
    ''' ====================================
    Public Property ComboBoxType() As HINMEI_CBO_TYPE
        Get
            Return mudtCboType
        End Get
        Set(ByVal value As HINMEI_CBO_TYPE)
            mudtCboType = value
        End Set
    End Property

    ''' ====================================
    ''' <summary>
    ''' 単位ﾗﾍﾞﾙ
    ''' </summary>
    ''' <value>ﾗﾍﾞﾙｵﾌﾞｼﾞｪｸﾄ</value>
    ''' <returns>ﾗﾍﾞﾙｵﾌﾞｼﾞｪｸﾄ</returns>
    ''' <remarks>単位ﾗﾍﾞﾙｵﾌﾞｼﾞｪｸﾄを設定します。</remarks>
    ''' ====================================
    Public Property TaniLabel() As Windows.Forms.Label
        Get
            Return mobjTaniLabel
        End Get
        Set(ByVal Value As Windows.Forms.Label)
            mobjTaniLabel = Value
        End Set
    End Property

    ''' ====================================
    ''' <summary>
    ''' 品名ﾗﾍﾞﾙ
    ''' </summary>
    ''' <value>ﾗﾍﾞﾙｵﾌﾞｼﾞｪｸﾄ</value>
    ''' <returns>ﾗﾍﾞﾙｵﾌﾞｼﾞｪｸﾄ</returns>
    ''' <remarks>品名ﾗﾍﾞﾙｵﾌﾞｼﾞｪｸﾄを設定します。</remarks>
    ''' ====================================
    Public Property ArticleShortNameLabel() As Windows.Forms.Label
        Get
            Return mobjArticleShortName
        End Get
        Set(ByVal Value As Windows.Forms.Label)
            mobjArticleShortName = Value
        End Set
    End Property

    ''' ====================================
    ''' <summary>
    ''' 表示品名ﾀｲﾌﾟ
    ''' </summary>
    ''' <value>品名ﾀｲﾌﾟ</value>
    ''' <returns>品名ﾀｲﾌﾟ</returns>
    ''' <remarks>ｺﾝﾎﾞﾎﾞｯｸｽに表示する品名のﾀｲﾌﾟを設定します。</remarks>
    ''' ====================================
    Public Property CboDispNameType() As DispNameType
        Get
            Return mudtDispNameType
        End Get
        Set(ByVal Value As DispNameType)
            mudtDispNameType = Value
        End Set
    End Property

    ''' ====================================
    ''' <summary>
    ''' 標準保管場所
    ''' </summary>
    ''' <value>標準保管場所</value>
    ''' <returns>標準保管場所</returns>
    ''' <remarks>標準保管場所の設定または参照します。(配列)</remarks>
    ''' ====================================
    Public Property PlaceDetailCode() As String()
        Get
            Return mstrPlaceDetailCode
        End Get
        Set(ByVal Value() As String)
            mstrPlaceDetailCode = Value
        End Set
    End Property

    ''' ====================================
    ''' <summary>
    ''' 品番形状種別
    ''' </summary>
    ''' <value>品番形状種別</value>
    ''' <returns>品番形状種別</returns>
    ''' <remarks>品番形状種別の設定または参照します。(配列)</remarks>
    ''' ====================================
    Public Property HinmeiKind() As String()
        Get
            Return mstrXHINMEI_KIND
        End Get
        Set(ByVal Value() As String)
            mstrXHINMEI_KIND = Value
        End Set
    End Property

    '↓↓↓↓↓↓ 2012.09.27 H.Morita KAGOME

    ''' ====================================
    ''' <summary>
    ''' ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
    ''' </summary>
    ''' <value>ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№</value>
    ''' <returns>ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№</returns>
    ''' <remarks>ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№の設定または参照します。(配列)</remarks>
    ''' ====================================
    Public Property FTRK_BUF_NO() As String()
        Get
            Return mstrFTRK_BUF_NO
        End Get
        Set(ByVal Value() As String)
            mstrFTRK_BUF_NO = Value
        End Set
    End Property

    ''' ====================================
    ''' <summary>
    ''' 引当状態
    ''' </summary>
    ''' <value>引当状態</value>
    ''' <returns>引当状態</returns>
    ''' <remarks>引当状態の設定または参照します。</remarks>
    ''' ====================================
    Public Property FRES_KIND() As String
        Get
            Return mstrFRES_KIND
        End Get
        Set(ByVal Value As String)
            mstrFRES_KIND = Value
        End Set
    End Property

    '↑↑↑↑↑↑ 2012.09.27 H.Morita KAGOME

    '↓↓↓↓↓↓ 2012.10.30 H.Morita KAGOME
    ''' ====================================
    ''' <summary>
    ''' ﾗｲﾝ№
    ''' </summary>
    ''' <value>ﾗｲﾝ№</value>
    ''' <returns>ﾗｲﾝ№</returns>
    ''' <remarks>ﾗｲﾝ№の設定または参照します。</remarks>
    ''' ====================================
    Public Property XLINE_NO() As String
        Get
            Return mstrXLINE_NO
        End Get
        Set(ByVal Value As String)
            mstrXLINE_NO = Value
        End Set
    End Property
    '↑↑↑↑↑↑ 2012.10.30 H.Morita KAGOME

    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:A.Noto 2012/11/29 生産入庫設定画面追加
    ''' ====================================
    ''' <summary>
    ''' 管理区分
    ''' </summary>
    ''' <value>管理区分</value>
    ''' <returns>管理区分</returns>
    ''' <remarks>管理区分の設定または参照します。</remarks>
    ''' ====================================
    Public Property XKANRI_KUBUN() As String
        Get
            Return mstrXKANRI_KUBUN
        End Get
        Set(ByVal Value As String)
            mstrXKANRI_KUBUN = Value
        End Set
    End Property
    '↑↑↑↑↑↑************************************************************************************************************

    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:H.Okumura 2013/07/23 品目一致判定追加
    ''' ====================================
    ''' <summary>
    ''' 品目一致判定
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' ====================================
    Public Property FIND_FLAG() As Boolean
        Get
            Return mblnFIND_FLAG
        End Get
        Set(ByVal value As Boolean)
            mblnFIND_FLAG = value
        End Set
    End Property
    '↑↑↑↑↑↑************************************************************************************************************

#End Region
#Region "  ｺﾝｽﾄﾗｸﾀ                          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｺﾝｽﾄﾗｸﾀ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub New()

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()
        ' InitializeComponent() 呼び出しの後で初期化を追加します。


        '***********************************************************************
        'ｸﾗｽ変数の初期化
        '***********************************************************************
        mstrSQL = ""
        mstrTableName = "TMST_ITEM"


        '*******************************************************************
        ' ｺﾝﾎﾞﾎﾞｯｸｽ設定用ｶﾗﾑ作成処理
        '*******************************************************************
        Dim objComboTable As New DataTable()

        'DataTableに列を追加
        objComboTable.Columns.Add("NAME", GetType(String))
        objComboTable.Columns.Add("ID", GetType(String))


    End Sub
#End Region
#Region "  ｲﾍﾞﾝﾄ                            "
#Region "　ﾄﾞﾛｯﾌﾟﾀﾞｳﾝ表示   ｲﾍﾞﾝﾄ           "
    Private Sub cmpCboFHINMEI_CD_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DropDown

        Call cmbDropDownOpenProccess()

    End Sub
#End Region
#Region "  ﾃｷｽﾄﾁｪﾝｼﾞ        ｲﾍﾞﾝﾄ           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾃｷｽﾄﾁｪﾝｼﾞｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub clsHinmeiCdComboBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.TextChanged

        If IsNothing(mobjHinmeiLabel) = False Then
            '(品名ﾗﾍﾞﾙが設定されている場合)
            Call lblTextSet()
        End If

        If IsNothing(mobjTaniLabel) = False Then
            '(単位ﾗﾍﾞﾙが設定されている場合)
            Call lblTaniSet()
        End If

        If IsNothing(mobjArticleShortName) = False Then
            '(品名略称ﾗﾍﾞﾙが設定されている場合)
            Call lblArticleShortNameSet()
        End If

    End Sub
#End Region
#Region "　"
    Private Sub cmpCboFHINMEI_CD_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SelectedIndexChanged
        If mblnHinmeiVisible = True Then
            Me.Text = Me.SelectedValue.ToString
        End If
    End Sub
#End Region
#End Region
#Region "　ﾄﾞﾛｯﾌﾟﾀﾞｳﾝ表示   ｲﾍﾞﾝﾄ処理　     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾄﾞﾛｯﾌﾟﾀﾞｳﾝ表示ｲﾍﾞﾝﾄ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmbDropDownOpenProccess()

        ' ''(初期時表示)
        ''If Me.Text = "" Then
        'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄにﾃﾞｰﾀをｾｯﾄ
        Call cboSetupHinmeiCd(Me.Text)
        ''End If

    End Sub
#End Region
#Region "  ｷｰｱｯﾌﾟ           ｲﾍﾞﾝﾄ処理       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｷｰｱｯﾌﾟｲﾍﾞﾝﾄ処理
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmbKeyUpProccess(ByVal e As System.Windows.Forms.KeyEventArgs)

        '********************************************************************
        'ﾘｽﾄをｾｯﾄ (ｷｰﾌﾟﾚｽｲﾍﾞﾝﾄ時にはMe.Textが最新でないためｷｰｱｯﾌﾟｲﾍﾞﾝﾄでｾｯﾄ)
        '  ※ｲﾍﾞﾝﾄ順:ｷｰﾌﾟﾚｽｲﾍﾞﾝﾄ → Me.Text更新 → ｷｰｱｯﾌﾟｲﾍﾞﾝﾄ
        '    DELETEﾎﾞﾀﾝ押下時にKeyPressがｲﾍﾞﾝﾄ発生しないためKeyUpｲﾍﾞﾝﾄで別途記述
        '********************************************************************
        If mblnKeyPressFlg = True _
        Or e.KeyCode = Keys.Delete Then
            Call cboSetupHinmeiCd(Me.Text)
        End If

        'ｷｰﾌﾟﾚｽﾌﾗｸﾞOFF
        mblnKeyPressFlg = False

    End Sub
#End Region

    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:H.Okumrua 2013/06/26 品名ｺｰﾄﾞ、記号の両方に対応(変更後ｺｰﾄﾞ)
#Region "  品名ｺｰﾄﾞﾘｽﾄのｾｯﾄ     品名ｺｰﾄﾞ、記号の両方に対応            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 品名ｺｰﾄﾞﾘｽﾄ
    ''' </summary>
    ''' <param name="strHinmeiCd"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub cboSetupHinmeiCd(ByVal strHinmeiCd As String)

        Dim objRow As DataRow                           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim objDataSet As New DataSet                   'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String = mstrTableName    'ﾃﾞｰﾀｾｯﾄﾃｰﾌﾞﾙ名
        Dim strColItemName As String = "FHINMEI"        'ﾌｨｰﾙﾄﾞ名

        If mudtDispNameType = DispNameType.ShortName Then
            strColItemName = "MArticleShortName"
        ElseIf mudtDispNameType = DispNameType.FullName Then
            strColItemName = "FHINMEI"
        End If

        Dim objComboTable As New DataTable()
        'DataTableに列を追加
        objComboTable.Columns.Add("NAME", GetType(String))
        objComboTable.Columns.Add("ID", GetType(String))


        '********************************************************************
        ' ｺﾈｸｼｮﾝの確認
        '********************************************************************
        If IsNull(mobjDb) = True Then
            'ｺﾈｸｼｮﾝがｾｯﾄされていない場合は終了
            Return
        End If

        '********************************************************************
        ' 表示する品名情報の取得
        '********************************************************************
        Select Case mudtCboType
            Case HINMEI_CBO_TYPE.SpecifiedTableData
                '(指定ﾃｰﾌﾞﾙでｺﾝﾎﾞﾎﾞｯｸｽを作成する場合)

                If strHinmeiCd = "" Then
                    '(未入力の場合)

                    mstrSQL = ""
                    mstrSQL &= vbCrLf & " SELECT DISTINCT "
                    mstrSQL &= vbCrLf & "     " & mstrTableName & ".FHINMEI_CD "             '品名ｺｰﾄﾞ
                    mstrSQL &= vbCrLf & "   , " & mstrTableName & "." & strColItemName & " "      '品名
                    mstrSQL &= vbCrLf & " FROM   " & mstrTableName & " "
                    mstrSQL &= vbCrLf & " WHERE 0 = 0 "
                    mstrSQL &= vbCrLf & "   AND " & mstrTableName & ".FHINMEI_CD LIKE '" & strHinmeiCd & "%' "  '前方一致
                    mstrSQL &= vbCrLf & " GROUP BY "
                    mstrSQL &= vbCrLf & "     " & mstrTableName & ".FHINMEI_CD "             '品名ｺｰﾄﾞ
                    mstrSQL &= vbCrLf & "   , " & mstrTableName & "." & strColItemName & " "      '品名
                    mstrSQL &= vbCrLf & " ORDER BY  "
                    mstrSQL &= vbCrLf & "    " & mstrTableName & ".FHINMEI_CD "              '品名ｺｰﾄﾞ

                ElseIf IsNumeric(strHinmeiCd.Substring(0, 1)) = True Then
                    '(数値=品名ｺｰﾄﾞ)

                    mstrSQL = ""
                    mstrSQL &= vbCrLf & " SELECT DISTINCT "
                    mstrSQL &= vbCrLf & "     " & mstrTableName & ".XHINMEI_CD FHINMEI_CD "       '品名ｺｰﾄﾞ(正式名)
                    mstrSQL &= vbCrLf & "   , " & mstrTableName & "." & strColItemName & " "      '品名
                    mstrSQL &= vbCrLf & " FROM   " & mstrTableName & " "
                    mstrSQL &= vbCrLf & " WHERE 0 = 0 "
                    mstrSQL &= vbCrLf & "   AND " & mstrTableName & ".XHINMEI_CD LIKE '" & strHinmeiCd & "%' "  '前方一致
                    mstrSQL &= vbCrLf & " GROUP BY "
                    mstrSQL &= vbCrLf & "     " & mstrTableName & ".XHINMEI_CD "             '品名ｺｰﾄﾞ(正式名)
                    mstrSQL &= vbCrLf & "   , " & mstrTableName & "." & strColItemName & " "      '品名
                    mstrSQL &= vbCrLf & " ORDER BY  "
                    mstrSQL &= vbCrLf & "    " & mstrTableName & ".XHINMEI_CD "              '品名ｺｰﾄﾞ(正式名)


                ElseIf IsNumeric(strHinmeiCd.Substring(0, 1)) = False Then
                    '(文字=品名記号)

                    mstrSQL = ""
                    mstrSQL &= vbCrLf & " SELECT DISTINCT "
                    mstrSQL &= vbCrLf & "     " & mstrTableName & ".FHINMEI_CD "             '品名ｺｰﾄﾞ
                    mstrSQL &= vbCrLf & "   , " & mstrTableName & "." & strColItemName & " "      '品名
                    mstrSQL &= vbCrLf & " FROM   " & mstrTableName & " "
                    mstrSQL &= vbCrLf & " WHERE 0 = 0 "
                    mstrSQL &= vbCrLf & "   AND " & mstrTableName & ".FHINMEI_CD LIKE '" & strHinmeiCd & "%' "  '前方一致
                    mstrSQL &= vbCrLf & " GROUP BY "
                    mstrSQL &= vbCrLf & "     " & mstrTableName & ".FHINMEI_CD "             '品名ｺｰﾄﾞ
                    mstrSQL &= vbCrLf & "   , " & mstrTableName & "." & strColItemName & " "      '品名
                    mstrSQL &= vbCrLf & " ORDER BY  "
                    mstrSQL &= vbCrLf & "    " & mstrTableName & ".FHINMEI_CD "              '品名ｺｰﾄﾞ

                End If

            Case HINMEI_CBO_TYPE.SpecifiedAndMasterData
                '(指定ﾃｰﾌﾞﾙとﾏｽﾀﾃｰﾌﾞﾙでｺﾝﾎﾞﾎﾞｯｸｽを作成する場合)


                If strHinmeiCd = "" Then
                    '(未入力の場合)
                    mstrSQL = ""
                    mstrSQL &= vbCrLf & " SELECT DISTINCT "
                    mstrSQL &= vbCrLf & "     " & mstrTableName & ".FHINMEI_CD "             '品名ｺｰﾄﾞ
                    mstrSQL &= vbCrLf & "   , " & mstrMasterTableName & "." & strColItemName & " "          '品名
                    mstrSQL &= vbCrLf & " FROM   " & mstrTableName & " "
                    mstrSQL &= vbCrLf & "      , " & mstrMasterTableName & " "
                    mstrSQL &= vbCrLf & " WHERE 0 = 0 "
                    mstrSQL &= vbCrLf & "   AND " & mstrTableName & ".FHINMEI_CD = " & mstrMasterTableName & ".FHINMEI_CD "    '結合条件
                    mstrSQL &= vbCrLf & "   AND " & mstrTableName & ".FHINMEI_CD LIKE '" & strHinmeiCd & "%' "  '前方一致
                    mstrSQL &= vbCrLf & " GROUP BY "
                    mstrSQL &= vbCrLf & "     " & mstrTableName & ".FHINMEI_CD "             '品名ｺｰﾄﾞ
                    mstrSQL &= vbCrLf & "   , " & mstrMasterTableName & "." & strColItemName & " "          '品名
                    mstrSQL &= vbCrLf & " ORDER BY  "
                    mstrSQL &= vbCrLf & "    " & mstrTableName & ".FHINMEI_CD "              '品名ｺｰﾄﾞ

                ElseIf IsNumeric(strHinmeiCd.Substring(0, 1)) = True Then
                    '(数値=品名ｺｰﾄﾞ)
                    mstrSQL = ""
                    mstrSQL &= vbCrLf & " SELECT DISTINCT "
                    mstrSQL &= vbCrLf & "     " & mstrTableName & ".XHINMEI_CD "             '品名ｺｰﾄﾞ(正式名)
                    mstrSQL &= vbCrLf & "   , " & mstrMasterTableName & "." & strColItemName & " "          '品名
                    mstrSQL &= vbCrLf & " FROM   " & mstrTableName & " "
                    mstrSQL &= vbCrLf & "      , " & mstrMasterTableName & " "
                    mstrSQL &= vbCrLf & " WHERE 0 = 0 "
                    mstrSQL &= vbCrLf & "   AND " & mstrTableName & ".FHINMEI_CD = " & mstrMasterTableName & ".FHINMEI_CD "    '結合条件
                    mstrSQL &= vbCrLf & "   AND " & mstrTableName & ".XHINMEI_CD LIKE '" & strHinmeiCd & "%' "  '前方一致
                    mstrSQL &= vbCrLf & " GROUP BY "
                    mstrSQL &= vbCrLf & "     " & mstrTableName & ".XHINMEI_CD "             '品名ｺｰﾄﾞ(正式名)
                    mstrSQL &= vbCrLf & "   , " & mstrMasterTableName & "." & strColItemName & " "          '品名
                    mstrSQL &= vbCrLf & " ORDER BY  "
                    mstrSQL &= vbCrLf & "    " & mstrTableName & ".XHINMEI_CD "              '品名ｺｰﾄﾞ(正式名)


                ElseIf IsNumeric(strHinmeiCd.Substring(0, 1)) = False Then
                    '(文字=品名記号)
                    mstrSQL = ""
                    mstrSQL &= vbCrLf & " SELECT DISTINCT "
                    mstrSQL &= vbCrLf & "     " & mstrTableName & ".FHINMEI_CD "             '品名ｺｰﾄﾞ
                    mstrSQL &= vbCrLf & "   , " & mstrMasterTableName & "." & strColItemName & " "          '品名
                    mstrSQL &= vbCrLf & " FROM   " & mstrTableName & " "
                    mstrSQL &= vbCrLf & "      , " & mstrMasterTableName & " "
                    mstrSQL &= vbCrLf & " WHERE 0 = 0 "
                    mstrSQL &= vbCrLf & "   AND " & mstrTableName & ".FHINMEI_CD = " & mstrMasterTableName & ".FHINMEI_CD "    '結合条件
                    mstrSQL &= vbCrLf & "   AND " & mstrTableName & ".FHINMEI_CD LIKE '" & strHinmeiCd & "%' "  '前方一致
                    mstrSQL &= vbCrLf & " GROUP BY "
                    mstrSQL &= vbCrLf & "     " & mstrTableName & ".FHINMEI_CD "             '品名ｺｰﾄﾞ
                    mstrSQL &= vbCrLf & "   , " & mstrMasterTableName & "." & strColItemName & " "          '品名
                    mstrSQL &= vbCrLf & " ORDER BY  "
                    mstrSQL &= vbCrLf & "    " & mstrTableName & ".FHINMEI_CD "              '品名ｺｰﾄﾞ

                End If



        End Select


        mobjDb.SQL = mstrSQL
        objDataSet.Clear()
        mobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows

                ' ｻﾌﾞｱｲﾃﾑを作成 
                Dim SubItem1 As String
                SubItem1 = TO_STRING(objRow("FHINMEI_CD"))
                Dim subItem2 As String
                subItem2 = TO_STRING(objRow(strColItemName))


                '  各列に値をｾｯﾄ 
                Dim row As DataRow = objComboTable.NewRow()
                '品番 & " | " & 品名の形式にする為、変更 2011/09/01 Nakashima -----<
                'row("NAME") = SubItem1
                If mblnHinmeiVisible Then
                    row("NAME") = SubItem1 & " | " & subItem2
                Else
                    row("NAME") = SubItem1
                End If

                '>-----
                row("ID") = SubItem1

                '　DataTableに行を追加
                objComboTable.Rows.Add(row)

            Next
        End If

        '********************************************************************
        ' 未入力の場合
        '********************************************************************
        If strHinmeiCd = "" Then
            '(品名記号、品名ｺｰﾄﾞの両方を追加)

            Select Case mudtCboType
                Case HINMEI_CBO_TYPE.SpecifiedTableData
                    '(指定ﾃｰﾌﾞﾙでｺﾝﾎﾞﾎﾞｯｸｽを作成する場合)
                    mstrSQL = ""
                    mstrSQL &= vbCrLf & " SELECT DISTINCT "
                    mstrSQL &= vbCrLf & "     " & mstrTableName & ".XHINMEI_CD "       '品名ｺｰﾄﾞ(正式名)
                    mstrSQL &= vbCrLf & "   , " & mstrTableName & ".FHINMEI_CD "       '品名ｺｰﾄﾞ
                    mstrSQL &= vbCrLf & " FROM   " & mstrTableName & " "
                    mstrSQL &= vbCrLf & " GROUP BY "
                    mstrSQL &= vbCrLf & "     " & mstrTableName & ".XHINMEI_CD "             '品名ｺｰﾄﾞ(正式名)
                    mstrSQL &= vbCrLf & "   , " & mstrTableName & ".FHINMEI_CD "            '品名ｺｰﾄﾞ
                    mstrSQL &= vbCrLf & " ORDER BY  "
                    mstrSQL &= vbCrLf & "    " & mstrTableName & ".XHINMEI_CD "              '品名ｺｰﾄﾞ(正式名)

                    mobjDb.SQL = mstrSQL
                    objDataSet.Clear()
                    mobjDb.GetDataSet(strDataSetName, objDataSet)

                    If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                        For Each objRow In objDataSet.Tables(strDataSetName).Rows

                            ' ｻﾌﾞｱｲﾃﾑを作成 
                            Dim SubItem1 As String
                            SubItem1 = TO_STRING(objRow("XHINMEI_CD"))
                            Dim subItem2 As String
                            subItem2 = TO_STRING(objRow("FHINMEI_CD"))


                            '  各列に値をｾｯﾄ 
                            Dim row As DataRow = objComboTable.NewRow()

                            row("NAME") = SubItem1
                            row("ID") = subItem2

                            '　DataTableに行を追加
                            objComboTable.Rows.Add(row)

                        Next
                    End If

                Case HINMEI_CBO_TYPE.SpecifiedAndMasterData
                    '(指定ﾃｰﾌﾞﾙとﾏｽﾀﾃｰﾌﾞﾙでｺﾝﾎﾞﾎﾞｯｸｽを作成する場合)
                    mstrSQL = ""
                    mstrSQL &= vbCrLf & " SELECT DISTINCT "
                    mstrSQL &= vbCrLf & "     " & mstrMasterTableName & ".XHINMEI_CD "             '品名ｺｰﾄﾞ(正式名)
                    mstrSQL &= vbCrLf & "   , " & mstrMasterTableName & "." & strColItemName & " "          '品名
                    mstrSQL &= vbCrLf & " FROM   " & mstrTableName & " "
                    mstrSQL &= vbCrLf & "      , " & mstrMasterTableName & " "
                    mstrSQL &= vbCrLf & " WHERE 0 = 0 "
                    mstrSQL &= vbCrLf & "   AND " & mstrTableName & ".FHINMEI_CD = " & mstrMasterTableName & ".FHINMEI_CD "    '結合条件
                    mstrSQL &= vbCrLf & "   AND " & mstrTableName & ".XHINMEI_CD LIKE '" & strHinmeiCd & "%' "  '前方一致
                    mstrSQL &= vbCrLf & " GROUP BY "
                    mstrSQL &= vbCrLf & "     " & mstrTableName & ".XHINMEI_CD "             '品名ｺｰﾄﾞ(正式名)
                    mstrSQL &= vbCrLf & "   , " & mstrMasterTableName & "." & strColItemName & " "          '品名
                    mstrSQL &= vbCrLf & " ORDER BY  "
                    mstrSQL &= vbCrLf & "    " & mstrTableName & ".XHINMEI_CD "              '品名ｺｰﾄﾞ(正式名)

                    If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                        For Each objRow In objDataSet.Tables(strDataSetName).Rows

                            ' ｻﾌﾞｱｲﾃﾑを作成 
                            Dim SubItem1 As String
                            SubItem1 = TO_STRING(objRow("XHINMEI_CD"))
                            Dim subItem2 As String
                            subItem2 = TO_STRING(objRow(strColItemName))


                            '  各列に値をｾｯﾄ 
                            Dim row As DataRow = objComboTable.NewRow()

                            row("NAME") = SubItem1
                            row("ID") = subItem2

                            '　DataTableに行を追加
                            objComboTable.Rows.Add(row)

                        Next
                    End If

            End Select
        End If

        objComboTable.AcceptChanges()

        'ｺﾝﾎﾞﾎﾞｯｸｽのDataSourceにDataTableを割り当てる
        Me.DataSource = objComboTable

        '表示される値はDataTableのNAME列
        Me.DisplayMember = "NAME"

        '対応する値はDataTableのID列
        Me.ValueMember = "ID"


        Me.EndUpdate()      'まとめて描画

        Me.Text = strHinmeiCd


    End Sub
#End Region
#Region "  品名ﾗﾍﾞﾙ表示処理     品名ｺｰﾄﾞ、記号の両方に対応            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 品名ﾗﾍﾞﾙ表示処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub lblTextSet()

        Dim objDataSet As New DataSet                   'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String = mstrTableName    'ﾃﾞｰﾀｾｯﾄﾃｰﾌﾞﾙ名


        '********************************************************************
        ' ｺﾈｸｼｮﾝの確認
        '********************************************************************
        If IsNull(mobjDb) = True Then
            'ｺﾈｸｼｮﾝがｾｯﾄされていない場合は終了
            Return
        End If


        '********************************************************************
        ' 表示するｴﾝｼﾞﾝ型式の取得
        '********************************************************************
        Select Case mudtCboType
            Case HINMEI_CBO_TYPE.SpecifiedTableData
                '(指定ﾃｰﾌﾞﾙでｺﾝﾎﾞﾎﾞｯｸｽを作成する場合)

                mstrSQL = ""
                mstrSQL &= vbCrLf & " SELECT DISTINCT "
                mstrSQL &= vbCrLf & "     " & mstrTableName & ".FHINMEI_CD "                '品名ｺｰﾄﾞ
                mstrSQL &= vbCrLf & "   , " & mstrTableName & ".FHINMEI "                   '品名
                mstrSQL &= vbCrLf & " FROM   " & mstrTableName & ""
                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:H.Okumrua 2013/06/26 品名ｺｰﾄﾞ、記号の両方に対応
                mstrSQL &= vbCrLf & " WHERE "
                mstrSQL &= vbCrLf & " ( "
                mstrSQL &= vbCrLf & "  " & mstrTableName & ".FHINMEI_CD = '" & Me.Text & "' "
                mstrSQL &= vbCrLf & " OR "
                mstrSQL &= vbCrLf & "  " & mstrTableName & ".XHINMEI_CD = '" & Me.Text & "' "
                mstrSQL &= vbCrLf & " ) "
                '↑↑↑↑↑↑************************************************************************************************************

                If mstrSeihinKubun <> "" Then
                    '(製品区分が入力されている場合)
                    mstrSQL &= vbCrLf & "   AND  " & mstrTableName & ".FSEIHIN_KUBUN = '" & mstrSeihinKubun & "' "
                End If
                If IsNothing(mstrZaikoKubun) = False Then
                    If mstrZaikoKubun.Length >= 0 Then
                        '(在庫区分が設定されている場合)
                        mstrSQL &= vbCrLf & "   AND  " & mstrTableName & ".FZAIKO_KUBUN IN("
                        For intII As Integer = 0 To UBound(mstrZaikoKubun)
                            mstrSQL &= vbCrLf & "                                     '" & mstrZaikoKubun(intII) & "'"
                            If intII < UBound(mstrZaikoKubun) Then
                                mstrSQL &= ", "
                            End If
                        Next
                        mstrSQL &= vbCrLf & "                                              )"
                    End If
                End If


                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:A.Noto 2012/11/29 生産入庫設定画面追加
                If (mstrXKANRI_KUBUN <> "") Then
                    '(管理区分がNULLでないとき)
                    mstrSQL &= vbCrLf & "      AND " & mstrTableName & ".XKANRI_KUBUN = '" & TO_INTEGER(mstrXKANRI_KUBUN) & "'"                        '在庫棚(未引当)
                End If
                '↑↑↑↑↑↑************************************************************************************************************



                If IsNothing(mstrArticleTypeCode) = False Then
                    If mstrArticleTypeCode.Length >= 0 Then
                        '(品目種別ｺｰﾄﾞが設定されている場合)
                        mstrSQL &= vbCrLf & "   AND  " & mstrTableName & ".MArticleTypeCode IN("
                        For intII As Integer = 0 To UBound(mstrArticleTypeCode)
                            mstrSQL &= vbCrLf & "                                     '" & mstrArticleTypeCode(intII) & "'"
                            If intII < UBound(mstrArticleTypeCode) Then
                                mstrSQL &= ", "
                            End If
                        Next
                        mstrSQL &= vbCrLf & "                                              )"
                    End If
                End If

                If IsNothing(mstrPlaceDetailCode) = False Then
                    If mstrPlaceDetailCode.Length >= 0 Then
                        '(保管場所が設定されている場合)
                        mstrSQL &= vbCrLf & "   AND  " & mstrMasterTableName & ".XPlaceDetailCode IN("
                        For intII As Integer = 0 To UBound(mstrPlaceDetailCode)
                            mstrSQL &= vbCrLf & "                                     '" & mstrPlaceDetailCode(intII) & "'"
                            If intII < UBound(mstrPlaceDetailCode) Then
                                mstrSQL &= ", "
                            End If
                        Next
                        mstrSQL &= vbCrLf & "                                              )"
                    End If
                End If

                If IsNothing(mstrXHINMEI_KIND) = False Then
                    If mstrXHINMEI_KIND.Length >= 0 Then
                        '(品番形状種別が設定されている場合)
                        mstrSQL &= vbCrLf & "   AND  " & mstrMasterTableName & ".XHINMEI_KIND IN("
                        For intII As Integer = 0 To UBound(mstrXHINMEI_KIND)
                            mstrSQL &= vbCrLf & "                                     '" & mstrXHINMEI_KIND(intII) & "'"
                            If intII < UBound(mstrXHINMEI_KIND) Then
                                mstrSQL &= ", "
                            End If
                        Next
                        mstrSQL &= vbCrLf & "                                              )"
                    End If
                End If

                mstrSQL &= vbCrLf & " ORDER BY  "
                mstrSQL &= vbCrLf & "    " & mstrTableName & ".FHINMEI_CD "                           '品名ｺｰﾄﾞ

            Case HINMEI_CBO_TYPE.SpecifiedAndMasterData
                '(指定ﾃｰﾌﾞﾙとﾏｽﾀﾃｰﾌﾞﾙでｺﾝﾎﾞﾎﾞｯｸｽを作成する場合)

                mstrSQL = ""
                mstrSQL &= vbCrLf & " SELECT DISTINCT "
                mstrSQL &= vbCrLf & "     " & mstrTableName & ".FHINMEI_CD "                '品名ｺｰﾄﾞ
                mstrSQL &= vbCrLf & "   , " & mstrMasterTableName & ".FHINMEI "             '品名
                mstrSQL &= vbCrLf & " FROM   " & mstrTableName & ""
                mstrSQL &= vbCrLf & "      , " & mstrMasterTableName & ""
                mstrSQL &= vbCrLf & " WHERE  " & mstrTableName & ".FHINMEI_CD = " & mstrMasterTableName & ".FHINMEI_CD (+) "
                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:H.Okumrua 2013/06/26 品名ｺｰﾄﾞ、記号の両方に対応
                mstrSQL &= vbCrLf & " WHERE "
                mstrSQL &= vbCrLf & " ( "
                mstrSQL &= vbCrLf & "  " & mstrTableName & ".FHINMEI_CD = '" & Me.Text & "' "
                mstrSQL &= vbCrLf & " OR "
                mstrSQL &= vbCrLf & "  " & mstrTableName & ".XHINMEI_CD = '" & Me.Text & "' "
                mstrSQL &= vbCrLf & " ) "
                '↑↑↑↑↑↑************************************************************************************************************

                If IsNothing(mstrZaikoKubun) = False Then
                    If mstrZaikoKubun.Length >= 0 Then
                        '(在庫区分が設定されている場合)
                        mstrSQL &= vbCrLf & "   AND  " & mstrTableName & ".FZAIKO_KUBUN IN("
                        For intII As Integer = 0 To UBound(mstrZaikoKubun)
                            mstrSQL &= vbCrLf & "                                     '" & mstrZaikoKubun(intII) & "'"
                            If intII < UBound(mstrZaikoKubun) Then
                                mstrSQL &= ", "
                            End If
                        Next
                        mstrSQL &= vbCrLf & "                                              )"
                    End If
                End If

                If IsNothing(mstrArticleTypeCode) = False Then
                    If mstrArticleTypeCode.Length >= 0 Then
                        '(品目種別ｺｰﾄﾞが設定されている場合)
                        mstrSQL &= vbCrLf & "   AND  " & mstrMasterTableName & ".MArticleTypeCode IN("
                        For intII As Integer = 0 To UBound(mstrArticleTypeCode)
                            mstrSQL &= vbCrLf & "                                     '" & mstrArticleTypeCode(intII) & "'"
                            If intII < UBound(mstrArticleTypeCode) Then
                                mstrSQL &= ", "
                            End If
                        Next
                        mstrSQL &= vbCrLf & "                                              )"
                    End If
                End If

                If IsNothing(mstrPlaceDetailCode) = False Then
                    If mstrPlaceDetailCode.Length >= 0 Then
                        '(保管場所が設定されている場合)
                        mstrSQL &= vbCrLf & "   AND  " & mstrMasterTableName & ".XPlaceDetailCode IN("
                        For intII As Integer = 0 To UBound(mstrPlaceDetailCode)
                            mstrSQL &= vbCrLf & "                                     '" & mstrPlaceDetailCode(intII) & "'"
                            If intII < UBound(mstrPlaceDetailCode) Then
                                mstrSQL &= ", "
                            End If
                        Next
                        mstrSQL &= vbCrLf & "                                              )"
                    End If
                End If

                If IsNothing(mstrXHINMEI_KIND) = False Then
                    If mstrXHINMEI_KIND.Length >= 0 Then
                        '(品番形状種別が設定されている場合)
                        mstrSQL &= vbCrLf & "   AND  " & mstrMasterTableName & ".XHINMEI_KIND IN("
                        For intII As Integer = 0 To UBound(mstrXHINMEI_KIND)
                            mstrSQL &= vbCrLf & "                                     '" & mstrXHINMEI_KIND(intII) & "'"
                            If intII < UBound(mstrXHINMEI_KIND) Then
                                mstrSQL &= ", "
                            End If
                        Next
                        mstrSQL &= vbCrLf & "                                              )"
                    End If
                End If

                mstrSQL &= vbCrLf & " ORDER BY  "
                mstrSQL &= vbCrLf & "    " & mstrTableName & ".FHINMEI_CD "                           '品名ｺｰﾄﾞ

        End Select


        mobjDb.SQL = mstrSQL

        objDataSet.Clear()
        mobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count <= 0 Then
            '(品名が取得できなかった場合)
            mobjHinmeiLabel.Text = ""
            mblnFIND_FLAG = False
        Else
            '(品名が取得できた場合)
            mobjHinmeiLabel.Text = TO_STRING(objDataSet.Tables(strDataSetName).Rows(0).Item("FHINMEI"))
            mblnFIND_FLAG = True
        End If


    End Sub
#End Region
    '↑↑↑↑↑↑************************************************************************************************************

#Region "　単位ﾗﾍﾞﾙ表示処理                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 単位ﾗﾍﾞﾙ表示処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub lblTaniSet()

        Dim objDataSet As New DataSet                   'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String = mstrTableName    'ﾃﾞｰﾀｾｯﾄﾃｰﾌﾞﾙ名


        '********************************************************************
        ' ｺﾈｸｼｮﾝの確認
        '********************************************************************
        If IsNull(mobjDb) = True Then
            'ｺﾈｸｼｮﾝがｾｯﾄされていない場合は終了
            Return
        End If


        '********************************************************************
        ' 表示するｴﾝｼﾞﾝ型式の取得
        '********************************************************************
        Select Case mudtCboType
            Case HINMEI_CBO_TYPE.SpecifiedTableData
                '(指定ﾃｰﾌﾞﾙでｺﾝﾎﾞﾎﾞｯｸｽを作成する場合)

                mstrSQL = ""
                mstrSQL &= vbCrLf & " SELECT DISTINCT "
                mstrSQL &= vbCrLf & "     " & mstrTableName & ".FHINMEI_CD "            '品名ｺｰﾄﾞ
                mstrSQL &= vbCrLf & "   , NVL(TMST_UNIT.MUnitName," & mstrTableName & ".FTANI) AS FTANI "   '単位
                mstrSQL &= vbCrLf & " FROM   " & mstrTableName & ""
                mstrSQL &= vbCrLf & "      , TMST_UNIT "
                mstrSQL &= vbCrLf & " WHERE 0 = 0 "
                mstrSQL &= vbCrLf & "   AND " & mstrTableName & ".FTANI = TMST_UNIT.FTANI"
                mstrSQL &= vbCrLf & "   AND " & mstrTableName & ".FHINMEI_CD = '" & Me.Text & "' "
                mstrSQL &= vbCrLf & " ORDER BY  "
                mstrSQL &= vbCrLf & "    " & mstrTableName & ".FHINMEI_CD "                           '品名ｺｰﾄﾞ

            Case HINMEI_CBO_TYPE.SpecifiedAndMasterData
                '(指定ﾃｰﾌﾞﾙとﾏｽﾀﾃｰﾌﾞﾙでｺﾝﾎﾞﾎﾞｯｸｽを作成する場合)

                mstrSQL = ""
                mstrSQL &= vbCrLf & " SELECT DISTINCT "
                mstrSQL &= vbCrLf & "     " & mstrTableName & ".FHINMEI_CD "                    '品名ｺｰﾄﾞ
                mstrSQL &= vbCrLf & "   , " & mstrMasterTableName & ".FHINMEI "                 '品名
                mstrSQL &= vbCrLf & "   , NVL(TMST_UNIT.MUnitName," & mstrMasterTableName & ".FTANI) AS FTANI "   '単位
                mstrSQL &= vbCrLf & " FROM   " & mstrTableName & ""
                mstrSQL &= vbCrLf & "      , " & mstrMasterTableName & ""
                mstrSQL &= vbCrLf & "      , TMST_UNIT "
                mstrSQL &= vbCrLf & " WHERE 0 = 0 "
                mstrSQL &= vbCrLf & "   AND " & mstrTableName & ".FHINMEI_CD = " & mstrMasterTableName & ".FHINMEI_CD (+) "
                mstrSQL &= vbCrLf & "   AND " & mstrMasterTableName & ".FTANI = TMST_UNIT.FTANI"
                mstrSQL &= vbCrLf & "   AND " & mstrTableName & ".FHINMEI_CD = '" & Me.Text & "' "
                mstrSQL &= vbCrLf & " ORDER BY  "
                mstrSQL &= vbCrLf & "    " & mstrTableName & ".FHINMEI_CD "                           '品名ｺｰﾄﾞ

        End Select


        mobjDb.SQL = mstrSQL

        objDataSet.Clear()
        mobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count <= 0 Then
            '(単位が取得できなかった場合)
            mobjTaniLabel.Text = ""
        Else
            '(単位が取得できた場合)
            mobjTaniLabel.Text = TO_STRING(objDataSet.Tables(strDataSetName).Rows(0).Item("FTANI"))
        End If


    End Sub
#End Region
#Region "  品名略称ﾗﾍﾞﾙ表示処理             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 品名略称ﾗﾍﾞﾙ表示処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub lblArticleShortNameSet()

        Dim objDataSet As New DataSet                   'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String = mstrTableName    'ﾃﾞｰﾀｾｯﾄﾃｰﾌﾞﾙ名


        '********************************************************************
        ' ｺﾈｸｼｮﾝの確認
        '********************************************************************
        If IsNull(mobjDb) = True Then
            'ｺﾈｸｼｮﾝがｾｯﾄされていない場合は終了
            Return
        End If


        '********************************************************************
        ' 表示するｴﾝｼﾞﾝ型式の取得
        '********************************************************************
        Select Case mudtCboType
            Case HINMEI_CBO_TYPE.SpecifiedTableData
                '(指定ﾃｰﾌﾞﾙでｺﾝﾎﾞﾎﾞｯｸｽを作成する場合)

                mstrSQL = ""
                mstrSQL &= vbCrLf & " SELECT DISTINCT "
                mstrSQL &= vbCrLf & "     " & mstrTableName & ".FHINMEI_CD "             '品名ｺｰﾄﾞ
                mstrSQL &= vbCrLf & "   , " & mstrTableName & ".MArticleShortName "      '品名略称
                mstrSQL &= vbCrLf & " FROM   " & mstrTableName & ""
                mstrSQL &= vbCrLf & " WHERE  " & mstrTableName & ".FHINMEI_CD = '" & Me.Text & "' "
                mstrSQL &= vbCrLf & " ORDER BY  "
                mstrSQL &= vbCrLf & "    " & mstrTableName & ".FHINMEI_CD "                           '品名ｺｰﾄﾞ

            Case HINMEI_CBO_TYPE.SpecifiedAndMasterData
                '(指定ﾃｰﾌﾞﾙとﾏｽﾀﾃｰﾌﾞﾙでｺﾝﾎﾞﾎﾞｯｸｽを作成する場合)

                mstrSQL = ""
                mstrSQL &= vbCrLf & " SELECT DISTINCT "
                mstrSQL &= vbCrLf & "     " & mstrTableName & ".FHINMEI_CD "                '品名ｺｰﾄﾞ
                mstrSQL &= vbCrLf & "   , " & mstrMasterTableName & ".MArticleShortName "   '品名略称
                mstrSQL &= vbCrLf & " FROM   " & mstrTableName & ""
                mstrSQL &= vbCrLf & "      , " & mstrMasterTableName & ""
                mstrSQL &= vbCrLf & " WHERE  " & mstrTableName & ".FHINMEI_CD = " & mstrMasterTableName & ".FHINMEI_CD (+) "
                mstrSQL &= vbCrLf & "   AND  " & mstrTableName & ".FHINMEI_CD = '" & Me.Text & "' "
                mstrSQL &= vbCrLf & " ORDER BY  "
                mstrSQL &= vbCrLf & "    " & mstrTableName & ".FHINMEI_CD "                           '品名ｺｰﾄﾞ

        End Select


        mobjDb.SQL = mstrSQL

        objDataSet.Clear()
        mobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count <= 0 Then
            '(品名が取得できなかった場合)
            mobjHinmeiLabel.Text = ""
        Else
            '(品名が取得できた場合)
            mobjHinmeiLabel.Text = TO_STRING(objDataSet.Tables(strDataSetName).Rows(0).Item("MArticleShortName"))
        End If


    End Sub
#End Region

    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:H.Okumrua 2013/06/26 品名ｺｰﾄﾞ、記号の両方に対応(変更前ｺｰﾄﾞ)
#Region "  品名ｺｰﾄﾞﾘｽﾄのｾｯﾄ                 "
    '''''' *******************************************************************************************************************
    '''''' <summary>
    '''''' 品名ｺｰﾄﾞﾘｽﾄ
    '''''' </summary>
    '''''' <param name="strHinmeiCd"></param>
    '''''' <remarks></remarks>
    '''''' *******************************************************************************************************************
    '' '' '' ''Public Sub cboSetupHinmeiCd(ByVal strHinmeiCd As String)

    ' '' ''    Dim objRow As DataRow                           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
    ' '' ''    Dim objDataSet As New DataSet                   'ﾃﾞｰﾀｾｯﾄ
    ' '' ''    Dim strDataSetName As String = mstrTableName    'ﾃﾞｰﾀｾｯﾄﾃｰﾌﾞﾙ名
    ' '' ''    Dim strColItemName As String = "FHINMEI"        'ﾌｨｰﾙﾄﾞ名

    ' '' ''    If mudtDispNameType = DispNameType.ShortName Then
    ' '' ''        strColItemName = "MArticleShortName"
    ' '' ''    ElseIf mudtDispNameType = DispNameType.FullName Then
    ' '' ''        strColItemName = "FHINMEI"
    ' '' ''    End If

    ' '' ''    Dim objComboTable As New DataTable()
    ' '' ''    'DataTableに列を追加
    ' '' ''    objComboTable.Columns.Add("NAME", GetType(String))
    ' '' ''    objComboTable.Columns.Add("ID", GetType(String))


    ' '' ''    '********************************************************************
    ' '' ''    ' ｺﾈｸｼｮﾝの確認
    ' '' ''    '********************************************************************
    ' '' ''    If IsNull(mobjDb) = True Then
    ' '' ''        'ｺﾈｸｼｮﾝがｾｯﾄされていない場合は終了
    ' '' ''        Return
    ' '' ''    End If

    ' '' ''    '********************************************************************
    ' '' ''    ' 表示する品名情報の取得
    ' '' ''    '********************************************************************
    ' '' ''    Select Case mudtCboType
    ' '' ''        Case HINMEI_CBO_TYPE.SpecifiedTableData
    ' '' ''            '(指定ﾃｰﾌﾞﾙでｺﾝﾎﾞﾎﾞｯｸｽを作成する場合)
    ' '' ''            mstrSQL = ""
    ' '' ''            mstrSQL &= vbCrLf & " SELECT DISTINCT "
    ' '' ''            mstrSQL &= vbCrLf & "     " & mstrTableName & ".FHINMEI_CD "             '品名ｺｰﾄﾞ
    ' '' ''            mstrSQL &= vbCrLf & "   , " & mstrTableName & "." & strColItemName & " "      '品名
    ' '' ''            mstrSQL &= vbCrLf & " FROM   " & mstrTableName & " "
    ' '' ''            mstrSQL &= vbCrLf & " WHERE 0 = 0 "
    ' '' ''            mstrSQL &= vbCrLf & "   AND " & mstrTableName & ".FHINMEI_CD LIKE '" & strHinmeiCd & "%' "  '前方一致

    ' '' ''            '↓↓↓↓↓↓************************************************************************************************************
    ' '' ''            'JobMate:A.Noto 2013/03/29 今回未使用
    ' '' ''            'If mstrSeihinKubun <> "" Then
    ' '' ''            '    '(製品区分が入力されている場合)
    ' '' ''            '    mstrSQL &= vbCrLf & "   AND  " & mstrTableName & ".FSEIHIN_KUBUN = '" & mstrSeihinKubun & "' "
    ' '' ''            'End If
    ' '' ''            'If IsNothing(mstrZaikoKubun) = False Then
    ' '' ''            '    If mstrZaikoKubun.Length >= 0 Then
    ' '' ''            '        '(在庫区分が設定されている場合)
    ' '' ''            '        mstrSQL &= vbCrLf & "   AND  " & mstrTableName & ".FZAIKO_KUBUN IN("
    ' '' ''            '        For intII As Integer = 0 To UBound(mstrZaikoKubun)
    ' '' ''            '            mstrSQL &= vbCrLf & "                                     '" & mstrZaikoKubun(intII) & "'"
    ' '' ''            '            If intII < UBound(mstrZaikoKubun) Then
    ' '' ''            '                mstrSQL &= ", "
    ' '' ''            '            End If
    ' '' ''            '        Next
    ' '' ''            '        mstrSQL &= vbCrLf & "                                              )"
    ' '' ''            '    End If
    ' '' ''            'End If

    ' '' ''            'If IsNothing(mstrArticleTypeCode) = False Then
    ' '' ''            '    If mstrArticleTypeCode.Length >= 0 Then
    ' '' ''            '        '(品目種別ｺｰﾄﾞが設定されている場合)
    ' '' ''            '        mstrSQL &= vbCrLf & "   AND  " & mstrTableName & ".MArticleTypeCode IN("
    ' '' ''            '        For intII As Integer = 0 To UBound(mstrArticleTypeCode)
    ' '' ''            '            mstrSQL &= vbCrLf & "                                     '" & mstrArticleTypeCode(intII) & "'"
    ' '' ''            '            If intII < UBound(mstrArticleTypeCode) Then
    ' '' ''            '                mstrSQL &= ", "
    ' '' ''            '            End If
    ' '' ''            '        Next
    ' '' ''            '        mstrSQL &= vbCrLf & "                                              )"
    ' '' ''            '    End If
    ' '' ''            'End If

    ' '' ''            'If IsNothing(mstrPlaceDetailCode) = False Then
    ' '' ''            '    If mstrPlaceDetailCode.Length >= 0 Then
    ' '' ''            '        '(保管場所が設定されている場合)
    ' '' ''            '        mstrSQL &= vbCrLf & "   AND  " & mstrMasterTableName & ".XPlaceDetailCode IN("
    ' '' ''            '        For intII As Integer = 0 To UBound(mstrPlaceDetailCode)
    ' '' ''            '            mstrSQL &= vbCrLf & "                                     '" & mstrPlaceDetailCode(intII) & "'"
    ' '' ''            '            If intII < UBound(mstrPlaceDetailCode) Then
    ' '' ''            '                mstrSQL &= ", "
    ' '' ''            '            End If
    ' '' ''            '        Next
    ' '' ''            '        mstrSQL &= vbCrLf & "                                              )"
    ' '' ''            '    End If
    ' '' ''            'End If

    ' '' ''            'If IsNothing(mstrXHINMEI_KIND) = False Then
    ' '' ''            '    If mstrXHINMEI_KIND.Length >= 0 Then
    ' '' ''            '        '(品番形状種別が設定されている場合)
    ' '' ''            '        mstrSQL &= vbCrLf & "   AND  " & mstrMasterTableName & ".XHINMEI_KIND IN("
    ' '' ''            '        For intII As Integer = 0 To UBound(mstrXHINMEI_KIND)
    ' '' ''            '            mstrSQL &= vbCrLf & "                                     '" & mstrXHINMEI_KIND(intII) & "'"
    ' '' ''            '            If intII < UBound(mstrXHINMEI_KIND) Then
    ' '' ''            '                mstrSQL &= ", "
    ' '' ''            '            End If
    ' '' ''            '        Next
    ' '' ''            '        mstrSQL &= vbCrLf & "                                              )"
    ' '' ''            '    End If
    ' '' ''            'End If
    ' '' ''            '↑↑↑↑↑↑************************************************************************************************************

    ' '' ''            mstrSQL &= vbCrLf & " GROUP BY "
    ' '' ''            mstrSQL &= vbCrLf & "     " & mstrTableName & ".FHINMEI_CD "             '品名ｺｰﾄﾞ
    ' '' ''            mstrSQL &= vbCrLf & "   , " & mstrTableName & "." & strColItemName & " "      '品名
    ' '' ''            mstrSQL &= vbCrLf & " ORDER BY  "
    ' '' ''            mstrSQL &= vbCrLf & "    " & mstrTableName & ".FHINMEI_CD "              '品名ｺｰﾄﾞ

    ' '' ''        Case HINMEI_CBO_TYPE.SpecifiedAndMasterData
    ' '' ''            '(指定ﾃｰﾌﾞﾙとﾏｽﾀﾃｰﾌﾞﾙでｺﾝﾎﾞﾎﾞｯｸｽを作成する場合)

    ' '' ''            mstrSQL = ""
    ' '' ''            mstrSQL &= vbCrLf & " SELECT DISTINCT "
    ' '' ''            mstrSQL &= vbCrLf & "     " & mstrTableName & ".FHINMEI_CD "             '品名ｺｰﾄﾞ
    ' '' ''            mstrSQL &= vbCrLf & "   , " & mstrMasterTableName & "." & strColItemName & " "          '品名

    ' '' ''            mstrSQL &= vbCrLf & " FROM   " & mstrTableName & " "
    ' '' ''            mstrSQL &= vbCrLf & "      , " & mstrMasterTableName & " "

    ' '' ''            ''↓↓↓↓↓↓ 2012.09.27 H.Morita KAGOME
    ' '' ''            'If (mstrFTRK_BUF_NO Is Nothing) And _
    ' '' ''            '   (mstrFRES_KIND = "") Then
    ' '' ''            '    '(ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№、引当状態の指定がない時)
    ' '' ''            'Else
    ' '' ''            '    '(ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№、引当状態の指定がある時)
    ' '' ''            '    mstrSQL &= vbCrLf & "      , TPRG_TRK_BUF "                          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
    ' '' ''            'End If
    ' '' ''            ''↑↑↑↑↑↑ 2012.09.27 H.Morita KAGOME


    ' '' ''            mstrSQL &= vbCrLf & " WHERE 0 = 0 "

    ' '' ''            ''↓↓↓↓↓↓ 2012.09.27 H.Morita KAGOME
    ' '' ''            'If (mstrFTRK_BUF_NO Is Nothing) And _
    ' '' ''            '   (mstrFRES_KIND = "") Then
    ' '' ''            '    '(ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№、引当状態の指定がない時)
    ' '' ''            'Else
    ' '' ''            '    '(ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№、引当状態の指定がある時)
    ' '' ''            '    mstrSQL &= vbCrLf & "   AND " & mstrTableName & ".FPALLET_ID  = TPRG_TRK_BUF.FPALLET_ID(+) "
    ' '' ''            '    mstrSQL &= vbCrLf & "   AND TPRG_TRK_BUF.FRES_KIND IN (" & TO_STRING(FRES_KIND_SZAIKO)      '引当状態 = 「在庫棚」
    ' '' ''            '    If mstrFRES_KIND = FRES_KIND_SRSV_TRNS_OUT Then
    ' '' ''            '        mstrSQL &= vbCrLf & "                            , " & TO_STRING(FRES_KIND_SRSV_TRNS_OUT)  '引当状態 = 「搬出予約」
    ' '' ''            '    End If
    ' '' ''            '    mstrSQL &= vbCrLf & "                                 )"

    ' '' ''            '    If mstrFTRK_BUF_NO Is Nothing Then
    ' '' ''            '        '(ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№の指定なしの時)
    ' '' ''            '    Else
    ' '' ''            '        '(ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№の指定ありの時)
    ' '' ''            '        For ii As Integer = LBound(mstrFTRK_BUF_NO) To UBound(mstrFTRK_BUF_NO)
    ' '' ''            '            '(ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№ 条件設定)

    ' '' ''            '            If ii = LBound(mstrFTRK_BUF_NO) Then
    ' '' ''            '                '(最初の時)
    ' '' ''            '                mstrSQL &= vbCrLf & "   AND TPRG_TRK_BUF.FTRK_BUF_NO IN ("
    ' '' ''            '                mstrSQL &= vbCrLf & "    " & mstrFTRK_BUF_NO(ii)
    ' '' ''            '            Else
    ' '' ''            '                '(以降)
    ' '' ''            '                mstrSQL &= vbCrLf & "  , " & mstrFTRK_BUF_NO(ii)
    ' '' ''            '            End If

    ' '' ''            '            If ii = UBound(mstrFTRK_BUF_NO) Then
    ' '' ''            '                '(最後の時)
    ' '' ''            '                mstrSQL &= vbCrLf & "   ) "
    ' '' ''            '            End If

    ' '' ''            '        Next
    ' '' ''            '    End If

    ' '' ''            'End If
    ' '' ''            ''↑↑↑↑↑↑ 2012.09.27 H.Morita KAGOME

    ' '' ''            mstrSQL &= vbCrLf & "   AND " & mstrTableName & ".FHINMEI_CD = " & mstrMasterTableName & ".FHINMEI_CD "    '結合条件
    ' '' ''            mstrSQL &= vbCrLf & "   AND " & mstrTableName & ".FHINMEI_CD LIKE '" & strHinmeiCd & "%' "  '前方一致

    ' '' ''            '↓↓↓↓↓↓************************************************************************************************************
    ' '' ''            'JobMate:A.Noto 2013/03/29 今回未使用
    ' '' ''            'If mstrSeihinKubun <> "" Then
    ' '' ''            '    '(製品区分が入力されている場合)
    ' '' ''            '    mstrSQL &= vbCrLf & "   AND  " & mstrMasterTableName & ".FSEIHIN_KUBUN = '" & mstrSeihinKubun & "' "
    ' '' ''            'End If
    ' '' ''            'If IsNothing(mstrZaikoKubun) = False Then
    ' '' ''            '    If mstrZaikoKubun.Length >= 0 Then
    ' '' ''            '        '(在庫区分が設定されている場合)
    ' '' ''            '        mstrSQL &= vbCrLf & "   AND  " & mstrTableName & ".FZAIKO_KUBUN IN("
    ' '' ''            '        For intII As Integer = 0 To UBound(mstrZaikoKubun)
    ' '' ''            '            mstrSQL &= vbCrLf & "                                     '" & mstrZaikoKubun(intII) & "'"
    ' '' ''            '            If intII < UBound(mstrZaikoKubun) Then
    ' '' ''            '                mstrSQL &= ", "
    ' '' ''            '            End If
    ' '' ''            '        Next
    ' '' ''            '        mstrSQL &= vbCrLf & "                                              )"
    ' '' ''            '    End If
    ' '' ''            'End If

    ' '' ''            'If IsNothing(mstrArticleTypeCode) = False Then
    ' '' ''            '    If mstrArticleTypeCode.Length >= 0 Then
    ' '' ''            '        '(品目種別ｺｰﾄﾞが設定されている場合)
    ' '' ''            '        mstrSQL &= vbCrLf & "   AND  " & mstrMasterTableName & ".MArticleTypeCode IN("
    ' '' ''            '        For intII As Integer = 0 To UBound(mstrArticleTypeCode)
    ' '' ''            '            mstrSQL &= vbCrLf & "                                     '" & mstrArticleTypeCode(intII) & "'"
    ' '' ''            '            If intII < UBound(mstrArticleTypeCode) Then
    ' '' ''            '                mstrSQL &= ", "
    ' '' ''            '            End If
    ' '' ''            '        Next
    ' '' ''            '        mstrSQL &= vbCrLf & "                                              )"
    ' '' ''            '    End If
    ' '' ''            'End If

    ' '' ''            'If IsNothing(mstrPlaceDetailCode) = False Then
    ' '' ''            '    If mstrPlaceDetailCode.Length >= 0 Then
    ' '' ''            '        '(保管場所が設定されている場合)
    ' '' ''            '        mstrSQL &= vbCrLf & "   AND  " & mstrMasterTableName & ".XPlaceDetailCode IN("
    ' '' ''            '        For intII As Integer = 0 To UBound(mstrPlaceDetailCode)
    ' '' ''            '            mstrSQL &= vbCrLf & "                                     '" & mstrPlaceDetailCode(intII) & "'"
    ' '' ''            '            If intII < UBound(mstrPlaceDetailCode) Then
    ' '' ''            '                mstrSQL &= ", "
    ' '' ''            '            End If
    ' '' ''            '        Next
    ' '' ''            '        mstrSQL &= vbCrLf & "                                              )"
    ' '' ''            '    End If
    ' '' ''            'End If

    ' '' ''            'If IsNothing(mstrXHINMEI_KIND) = False Then
    ' '' ''            '    If mstrXHINMEI_KIND.Length >= 0 Then
    ' '' ''            '        '(品番形状種別が設定されている場合)
    ' '' ''            '        mstrSQL &= vbCrLf & "   AND  " & mstrMasterTableName & ".XHINMEI_KIND IN("
    ' '' ''            '        For intII As Integer = 0 To UBound(mstrXHINMEI_KIND)
    ' '' ''            '            mstrSQL &= vbCrLf & "                                     '" & mstrXHINMEI_KIND(intII) & "'"
    ' '' ''            '            If intII < UBound(mstrXHINMEI_KIND) Then
    ' '' ''            '                mstrSQL &= ", "
    ' '' ''            '            End If
    ' '' ''            '        Next
    ' '' ''            '        mstrSQL &= vbCrLf & "                                              )"
    ' '' ''            '    End If
    ' '' ''            'End If
    ' '' ''            '↑↑↑↑↑↑************************************************************************************************************

    ' '' ''            mstrSQL &= vbCrLf & " GROUP BY "
    ' '' ''            mstrSQL &= vbCrLf & "     " & mstrTableName & ".FHINMEI_CD "             '品名ｺｰﾄﾞ
    ' '' ''            mstrSQL &= vbCrLf & "   , " & mstrMasterTableName & "." & strColItemName & " "          '品名
    ' '' ''            mstrSQL &= vbCrLf & " ORDER BY  "
    ' '' ''            mstrSQL &= vbCrLf & "    " & mstrTableName & ".FHINMEI_CD "              '品名ｺｰﾄﾞ

    ' '' ''    End Select


    ' '' ''    mobjDb.SQL = mstrSQL

    ' '' ''    objDataSet.Clear()
    ' '' ''    mobjDb.GetDataSet(strDataSetName, objDataSet)


    ' '' ''    If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
    ' '' ''        For Each objRow In objDataSet.Tables(strDataSetName).Rows

    ' '' ''            ' ｻﾌﾞｱｲﾃﾑを作成 
    ' '' ''            Dim SubItem1 As String
    ' '' ''            SubItem1 = TO_STRING(objRow("FHINMEI_CD"))
    ' '' ''            Dim subItem2 As String
    ' '' ''            subItem2 = TO_STRING(objRow(strColItemName))


    ' '' ''            '  各列に値をｾｯﾄ 
    ' '' ''            Dim row As DataRow = objComboTable.NewRow()
    ' '' ''            '品番 & " | " & 品名の形式にする為、変更 2011/09/01 Nakashima -----<
    ' '' ''            'row("NAME") = SubItem1
    ' '' ''            If mblnHinmeiVisible Then
    ' '' ''                row("NAME") = SubItem1 & " | " & subItem2
    ' '' ''            Else
    ' '' ''                row("NAME") = SubItem1
    ' '' ''            End If

    ' '' ''            '>-----
    ' '' ''            row("ID") = SubItem1

    ' '' ''            '　DataTableに行を追加
    ' '' ''            objComboTable.Rows.Add(row)

    ' '' ''        Next
    ' '' ''    End If

    ' '' ''    objComboTable.AcceptChanges()

    ' '' ''    'ｺﾝﾎﾞﾎﾞｯｸｽのDataSourceにDataTableを割り当てる
    ' '' ''    Me.DataSource = objComboTable

    ' '' ''    '表示される値はDataTableのNAME列
    ' '' ''    Me.DisplayMember = "NAME"

    ' '' ''    '対応する値はDataTableのID列
    ' '' ''    Me.ValueMember = "ID"


    ' '' ''    Me.EndUpdate()      'まとめて描画

    ' '' ''    Me.Text = strHinmeiCd


    ' '' ''End Sub
#End Region
#Region "  品名ﾗﾍﾞﾙ表示処理                 "
    '''''''' *******************************************************************************************************************
    '''''''' <summary>
    '''''''' 品名ﾗﾍﾞﾙ表示処理
    '''''''' </summary>
    '''''''' <remarks></remarks>
    '''''''' *******************************************************************************************************************
    ' '' ''Private Sub lblTextSet()

    ' '' ''    Dim objDataSet As New DataSet                   'ﾃﾞｰﾀｾｯﾄ
    ' '' ''    Dim strDataSetName As String = mstrTableName    'ﾃﾞｰﾀｾｯﾄﾃｰﾌﾞﾙ名


    ' '' ''    '********************************************************************
    ' '' ''    ' ｺﾈｸｼｮﾝの確認
    ' '' ''    '********************************************************************
    ' '' ''    If IsNull(mobjDb) = True Then
    ' '' ''        'ｺﾈｸｼｮﾝがｾｯﾄされていない場合は終了
    ' '' ''        Return
    ' '' ''    End If


    ' '' ''    '********************************************************************
    ' '' ''    ' 表示するｴﾝｼﾞﾝ型式の取得
    ' '' ''    '********************************************************************
    ' '' ''    Select Case mudtCboType
    ' '' ''        Case HINMEI_CBO_TYPE.SpecifiedTableData
    ' '' ''            '(指定ﾃｰﾌﾞﾙでｺﾝﾎﾞﾎﾞｯｸｽを作成する場合)

    ' '' ''            mstrSQL = ""
    ' '' ''            mstrSQL &= vbCrLf & " SELECT DISTINCT "
    ' '' ''            mstrSQL &= vbCrLf & "     " & mstrTableName & ".FHINMEI_CD "                '品名ｺｰﾄﾞ
    ' '' ''            mstrSQL &= vbCrLf & "   , " & mstrTableName & ".FHINMEI "                   '品名
    ' '' ''            mstrSQL &= vbCrLf & " FROM   " & mstrTableName & ""
    ' '' ''            mstrSQL &= vbCrLf & " WHERE  " & mstrTableName & ".FHINMEI_CD = '" & Me.Text & "' "

    ' '' ''            If mstrSeihinKubun <> "" Then
    ' '' ''                '(製品区分が入力されている場合)
    ' '' ''                mstrSQL &= vbCrLf & "   AND  " & mstrTableName & ".FSEIHIN_KUBUN = '" & mstrSeihinKubun & "' "
    ' '' ''            End If
    ' '' ''            If IsNothing(mstrZaikoKubun) = False Then
    ' '' ''                If mstrZaikoKubun.Length >= 0 Then
    ' '' ''                    '(在庫区分が設定されている場合)
    ' '' ''                    mstrSQL &= vbCrLf & "   AND  " & mstrTableName & ".FZAIKO_KUBUN IN("
    ' '' ''                    For intII As Integer = 0 To UBound(mstrZaikoKubun)
    ' '' ''                        mstrSQL &= vbCrLf & "                                     '" & mstrZaikoKubun(intII) & "'"
    ' '' ''                        If intII < UBound(mstrZaikoKubun) Then
    ' '' ''                            mstrSQL &= ", "
    ' '' ''                        End If
    ' '' ''                    Next
    ' '' ''                    mstrSQL &= vbCrLf & "                                              )"
    ' '' ''                End If
    ' '' ''            End If


    ' '' ''            '↓↓↓↓↓↓************************************************************************************************************
    ' '' ''            'JobMate:A.Noto 2012/11/29 生産入庫設定画面追加
    ' '' ''            If (mstrXKANRI_KUBUN <> "") Then
    ' '' ''                '(管理区分がNULLでないとき)
    ' '' ''                mstrSQL &= vbCrLf & "      AND " & mstrTableName & ".XKANRI_KUBUN = '" & TO_INTEGER(mstrXKANRI_KUBUN) & "'"                        '在庫棚(未引当)
    ' '' ''            End If
    ' '' ''            '↑↑↑↑↑↑************************************************************************************************************



    ' '' ''            If IsNothing(mstrArticleTypeCode) = False Then
    ' '' ''                If mstrArticleTypeCode.Length >= 0 Then
    ' '' ''                    '(品目種別ｺｰﾄﾞが設定されている場合)
    ' '' ''                    mstrSQL &= vbCrLf & "   AND  " & mstrTableName & ".MArticleTypeCode IN("
    ' '' ''                    For intII As Integer = 0 To UBound(mstrArticleTypeCode)
    ' '' ''                        mstrSQL &= vbCrLf & "                                     '" & mstrArticleTypeCode(intII) & "'"
    ' '' ''                        If intII < UBound(mstrArticleTypeCode) Then
    ' '' ''                            mstrSQL &= ", "
    ' '' ''                        End If
    ' '' ''                    Next
    ' '' ''                    mstrSQL &= vbCrLf & "                                              )"
    ' '' ''                End If
    ' '' ''            End If

    ' '' ''            If IsNothing(mstrPlaceDetailCode) = False Then
    ' '' ''                If mstrPlaceDetailCode.Length >= 0 Then
    ' '' ''                    '(保管場所が設定されている場合)
    ' '' ''                    mstrSQL &= vbCrLf & "   AND  " & mstrMasterTableName & ".XPlaceDetailCode IN("
    ' '' ''                    For intII As Integer = 0 To UBound(mstrPlaceDetailCode)
    ' '' ''                        mstrSQL &= vbCrLf & "                                     '" & mstrPlaceDetailCode(intII) & "'"
    ' '' ''                        If intII < UBound(mstrPlaceDetailCode) Then
    ' '' ''                            mstrSQL &= ", "
    ' '' ''                        End If
    ' '' ''                    Next
    ' '' ''                    mstrSQL &= vbCrLf & "                                              )"
    ' '' ''                End If
    ' '' ''            End If

    ' '' ''            If IsNothing(mstrXHINMEI_KIND) = False Then
    ' '' ''                If mstrXHINMEI_KIND.Length >= 0 Then
    ' '' ''                    '(品番形状種別が設定されている場合)
    ' '' ''                    mstrSQL &= vbCrLf & "   AND  " & mstrMasterTableName & ".XHINMEI_KIND IN("
    ' '' ''                    For intII As Integer = 0 To UBound(mstrXHINMEI_KIND)
    ' '' ''                        mstrSQL &= vbCrLf & "                                     '" & mstrXHINMEI_KIND(intII) & "'"
    ' '' ''                        If intII < UBound(mstrXHINMEI_KIND) Then
    ' '' ''                            mstrSQL &= ", "
    ' '' ''                        End If
    ' '' ''                    Next
    ' '' ''                    mstrSQL &= vbCrLf & "                                              )"
    ' '' ''                End If
    ' '' ''            End If

    ' '' ''            mstrSQL &= vbCrLf & " ORDER BY  "
    ' '' ''            mstrSQL &= vbCrLf & "    " & mstrTableName & ".FHINMEI_CD "                           '品名ｺｰﾄﾞ

    ' '' ''        Case HINMEI_CBO_TYPE.SpecifiedAndMasterData
    ' '' ''            '(指定ﾃｰﾌﾞﾙとﾏｽﾀﾃｰﾌﾞﾙでｺﾝﾎﾞﾎﾞｯｸｽを作成する場合)

    ' '' ''            mstrSQL = ""
    ' '' ''            mstrSQL &= vbCrLf & " SELECT DISTINCT "
    ' '' ''            mstrSQL &= vbCrLf & "     " & mstrTableName & ".FHINMEI_CD "                '品名ｺｰﾄﾞ
    ' '' ''            mstrSQL &= vbCrLf & "   , " & mstrMasterTableName & ".FHINMEI "             '品名
    ' '' ''            mstrSQL &= vbCrLf & " FROM   " & mstrTableName & ""
    ' '' ''            mstrSQL &= vbCrLf & "      , " & mstrMasterTableName & ""
    ' '' ''            mstrSQL &= vbCrLf & " WHERE  " & mstrTableName & ".FHINMEI_CD = " & mstrMasterTableName & ".FHINMEI_CD (+) "
    ' '' ''            mstrSQL &= vbCrLf & "   AND  " & mstrTableName & ".FHINMEI_CD = '" & Me.Text & "' "

    ' '' ''            If IsNothing(mstrZaikoKubun) = False Then
    ' '' ''                If mstrZaikoKubun.Length >= 0 Then
    ' '' ''                    '(在庫区分が設定されている場合)
    ' '' ''                    mstrSQL &= vbCrLf & "   AND  " & mstrTableName & ".FZAIKO_KUBUN IN("
    ' '' ''                    For intII As Integer = 0 To UBound(mstrZaikoKubun)
    ' '' ''                        mstrSQL &= vbCrLf & "                                     '" & mstrZaikoKubun(intII) & "'"
    ' '' ''                        If intII < UBound(mstrZaikoKubun) Then
    ' '' ''                            mstrSQL &= ", "
    ' '' ''                        End If
    ' '' ''                    Next
    ' '' ''                    mstrSQL &= vbCrLf & "                                              )"
    ' '' ''                End If
    ' '' ''            End If

    ' '' ''            If IsNothing(mstrArticleTypeCode) = False Then
    ' '' ''                If mstrArticleTypeCode.Length >= 0 Then
    ' '' ''                    '(品目種別ｺｰﾄﾞが設定されている場合)
    ' '' ''                    mstrSQL &= vbCrLf & "   AND  " & mstrMasterTableName & ".MArticleTypeCode IN("
    ' '' ''                    For intII As Integer = 0 To UBound(mstrArticleTypeCode)
    ' '' ''                        mstrSQL &= vbCrLf & "                                     '" & mstrArticleTypeCode(intII) & "'"
    ' '' ''                        If intII < UBound(mstrArticleTypeCode) Then
    ' '' ''                            mstrSQL &= ", "
    ' '' ''                        End If
    ' '' ''                    Next
    ' '' ''                    mstrSQL &= vbCrLf & "                                              )"
    ' '' ''                End If
    ' '' ''            End If

    ' '' ''            If IsNothing(mstrPlaceDetailCode) = False Then
    ' '' ''                If mstrPlaceDetailCode.Length >= 0 Then
    ' '' ''                    '(保管場所が設定されている場合)
    ' '' ''                    mstrSQL &= vbCrLf & "   AND  " & mstrMasterTableName & ".XPlaceDetailCode IN("
    ' '' ''                    For intII As Integer = 0 To UBound(mstrPlaceDetailCode)
    ' '' ''                        mstrSQL &= vbCrLf & "                                     '" & mstrPlaceDetailCode(intII) & "'"
    ' '' ''                        If intII < UBound(mstrPlaceDetailCode) Then
    ' '' ''                            mstrSQL &= ", "
    ' '' ''                        End If
    ' '' ''                    Next
    ' '' ''                    mstrSQL &= vbCrLf & "                                              )"
    ' '' ''                End If
    ' '' ''            End If

    ' '' ''            If IsNothing(mstrXHINMEI_KIND) = False Then
    ' '' ''                If mstrXHINMEI_KIND.Length >= 0 Then
    ' '' ''                    '(品番形状種別が設定されている場合)
    ' '' ''                    mstrSQL &= vbCrLf & "   AND  " & mstrMasterTableName & ".XHINMEI_KIND IN("
    ' '' ''                    For intII As Integer = 0 To UBound(mstrXHINMEI_KIND)
    ' '' ''                        mstrSQL &= vbCrLf & "                                     '" & mstrXHINMEI_KIND(intII) & "'"
    ' '' ''                        If intII < UBound(mstrXHINMEI_KIND) Then
    ' '' ''                            mstrSQL &= ", "
    ' '' ''                        End If
    ' '' ''                    Next
    ' '' ''                    mstrSQL &= vbCrLf & "                                              )"
    ' '' ''                End If
    ' '' ''            End If

    ' '' ''            mstrSQL &= vbCrLf & " ORDER BY  "
    ' '' ''            mstrSQL &= vbCrLf & "    " & mstrTableName & ".FHINMEI_CD "                           '品名ｺｰﾄﾞ

    ' '' ''    End Select


    ' '' ''    mobjDb.SQL = mstrSQL

    ' '' ''    objDataSet.Clear()
    ' '' ''    mobjDb.GetDataSet(strDataSetName, objDataSet)

    ' '' ''    If objDataSet.Tables(strDataSetName).Rows.Count <= 0 Then
    ' '' ''        '(品名が取得できなかった場合)
    ' '' ''        mobjHinmeiLabel.Text = ""
    ' '' ''    Else
    ' '' ''        '(品名が取得できた場合)
    ' '' ''        mobjHinmeiLabel.Text = TO_STRING(objDataSet.Tables(strDataSetName).Rows(0).Item("FHINMEI"))
    ' '' ''    End If


    ' '' ''End Sub
#End Region
    '↑↑↑↑↑↑************************************************************************************************************

End Class
