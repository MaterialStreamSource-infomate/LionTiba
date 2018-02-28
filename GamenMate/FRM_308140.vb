'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】ﾄﾗｯｸ入門受付確認
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_308140
#Region "　共通変数　                               "

    Private mFlag_Form_Load As Boolean = True                   '画面展開ﾌﾗｸﾞ
    Private mFlag_GRID_CLEAR As Boolean = True                  'ｸﾞﾘｯﾄﾞｸﾘｱ済みﾌﾗｸﾞ

    Private mstrXDSPUKETUKE_DT As String                         '受付時間

    '検索条件用構造体
    Private mudtSEARCH_ITEM As New SEARCH_ITEM      '画面用
    Private mudtSEARCH_ITEM2 As New SEARCH_ITEM2    'ﾘｽﾄ用

    'ﾌﾟﾛﾊﾟﾃｨ
    Public mstrXCAR_NO_WARITUKE As String        '受付車番
    Public mstrXCAR_NO_EDA_WARITUKE As String    '受付車番枝番
    Public mstrXGAIBU_SOUKO_SENKOU As String     '外部倉庫先行
    Public mstrXBERTH_SITEI As String            'ﾊﾞｰｽ指定
    Public mstrXHIRA1 As String                  '平1出庫判定

    Public mstrXORDER_NO() As String             '受注№(登録する受注№)
    Public mstrXCAR_NO_TOUROKU() As String       '受付車番(登録する受付車番)
    Public mstrXCAR_NO_EDA_TOUROKU() As String   '受付車番枝番(登録する受付車番枝番)

    Public mstrXNYUKA_JIGYOU_CD As String        '配送先ｺｰﾄﾞ
    Public mstrXNYUKA_JIGYOU_NM As String        '配送先名

    Public mstrSCH_XCAR_NO As String             '検索条件_車番
    Public mstrSCH_XSYUKKA_DT As String          '検索条件_出荷日
    Public mstrSCH_XORDER_NO As String           '検索条件_発注№
    Public mstrSCH_XNYUKA_JIGYOU_CD As String    '検索条件_配送先ｺｰﾄﾞ
    Public mstrSCH_XIDOU_CD As String            '検索条件_移動手段ｺｰﾄﾞ
    Public mstrSCH_XGYOSHA_CD As String          '検索条件_業者ｺｰﾄﾞ

    'Public mobjGrid As GamenCommon.cmpMDataGrid     '親画面ｸﾞﾘｯﾄﾞ
    'Public mintCol_XCAR_NO_EDA_WARITUKE As Integer  '受付車番枝番ﾘｽﾄｶﾗﾑ位置


    'ｸﾞﾘｯﾄﾞ項目(登録明細)
    Enum menmListCol

        XCAR_NO_WARITUKE            '画面.                      受付車番
        XCAR_NO_EDA_WARITUKE        '画面.                      受付車番枝番
        XSYUKKA_DT                  '出荷計画.          (非表示)出荷日
        XSYUKKA_DT_DSP              '出荷計画.                  出荷日(表示用)
        XNYUKA_JIGYOU_CD            '出荷計画.                  入荷事業所ｺｰﾄﾞ(配送先ｺｰﾄﾞ)
        XNYUKA_JIGYOU_NM            '出荷計画.                  入荷事業所名(配送先名)
        XORDER_NO                   '出荷計画.                  発注№
        'XSYUKKA_NO                  '出荷計画.                  出荷№
        XCAR_NO                     '出荷計画.                  車番
        XIDOU_CD                    '出荷計画.                  移動手段ｺｰﾄﾞ
        XARRIVAL_DT                 '出荷計画.          (非表示)到着日
        XARRIVAL_DT_DSP             '出荷計画.                  到着日(表示用)
        XGYOSHA_CD                  '出荷計画.                  業者ｺｰﾄﾞ
        XSYUKKA_BERTH               '                           出荷ﾊﾞｰｽ(0:なし 1:○)
        XSYUKKA_BERTH_DSP           '                           出荷ﾊﾞｰｽ(表示用)
        XHIRA1                      '                           平1(0:なし 1:○)
        XHIRA1_DSP                  '                           平1(表示用)
        '↓↓↓↓ 2012.12.03 11:30 H.Morita ﾊﾞﾗ平「○」表示対応
        XBARA                       '                           ﾊﾞﾗ平(0:なし 1:○)
        XBARA_DSP                   '                           ﾊﾞﾗ平(表示用)
        '↑↑↑↑ 2012.12.03 11:30 H.Morita ﾊﾞﾗ平「○」表示対応
        XGAIBU_SOUKO                '                           外部倉庫(0:なし 1:○ 2:済)
        XGAIBU_SOUKO_DSP            '                           外部倉庫(表示用)

        MAXCOL

    End Enum


    ''' <summary>ｸﾞﾘｯﾄﾞ項目(ﾋﾟｯｷﾝｸﾞﾘｽﾄ全体用)</summary>
    Enum menmListCol2

        XHIKIATE_DT             'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷引当日時(非表示)
        XSYUKKA_DT              'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷日(非表示)
        XCAR_NO_WARITUKE        'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        割付車番
        XCAR_NO_EDA_WARITUKE    'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        割付車番枝番
        XNYUKA_JIGYOU_CD        'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        入荷事業所ｺｰﾄﾞ(非表示)
        XNYUKA_JIGYOU_NM        'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        入荷事業所名
        '↓↓↓↓ 2012.12.03 17:10 H.Morita ﾋﾟｯｷﾝｸﾞﾘｽﾄ(全体) 「発注№」の表示
        XORDER_NO               'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        発注№
        '↑↑↑↑ 2012.12.03 17:10 H.Morita ﾋﾟｯｷﾝｸﾞﾘｽﾄ(全体) 「発注№」の表示
        FHINMEI                 'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        品名
        FHINMEI_CD              'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        品名ｺｰﾄﾞ
        XSEIZOU_DT              'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        製造年月日

        XHIKIATE_VOL            'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        引当数
        XPRINT_PL_NUM           'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        PL
        XPRINT_BARA_DAN_NUM     'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        段
        XPRINT_BARA_NUM         'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        C/S
        XHINSHITU_STS           'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        品質ｽﾃｰﾀｽ(非表示)
        XHINSHITU_STS_DSP       'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        品質ｽﾃｰﾀｽ(表示用)
        FTRK_BUF_NO             'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№(非表示)
        FBUF_NAME               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬﾏｽﾀ.   ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ名称(保管場所)

        MAXCOL

    End Enum


    ''' <summary>ｸﾞﾘｯﾄﾞ項目(ﾋﾟｯｷﾝｸﾞﾘｽﾄ用)</summary>
    Enum menmListCol3

        XHIKIATE_DT             'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷引当日時(非表示)
        XHIKIATE_DT_DSP         'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷引当日時(表示用)
        XSYUKKA_DT              'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷日(非表示)
        XSYUKKA_DT_DSP          'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷日(表示用)
        XCAR_NO_WARITUKE        'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        割付車番
        XCAR_NO_EDA_WARITUKE    'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        割付車番枝番
        XNYUKA_JIGYOU_CD        'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        入荷事業所ｺｰﾄﾞ(非表示)
        XNYUKA_JIGYOU_NM        'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        入荷事業所名
        XORDER_NO               'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        発注№
        XIDOU_CD                'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        移動手段ｺｰﾄﾞ(非表示)
        XIDOU_NM                'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        移動手段名
        FTRK_BUF_NO             'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№(非表示)
        FBUF_NAME               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬﾏｽﾀ.   ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ名称(保管場所)

        FHINMEI_CD              'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        品名ｺｰﾄﾞ
        FHINMEI                 'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        品名
        XSEIZOU_DT              'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        製造年月日
        XHIKIATE_VOL            'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        引当数
        XPRINT_PL_NUM           'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        PL
        XPRINT_BARA_DAN_NUM     'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        段
        XPRINT_BARA_NUM         'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        C/S
        XWEIGHT                 'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        重量
        XSYUKKA_KAHI            'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷可否(非表示)
        XSYUKKA_KAHI_DSP        'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷可否(表示用)
        XHINSHITU_STS           'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        品質ｽﾃｰﾀｽ(非表示)
        XHINSHITU_STS_DSP       'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        品質ｽﾃｰﾀｽ(表示用)
        FDECIMAL_POINT          '品目ﾏｽﾀ.           小数点以下有効桁数

        MAXCOL

    End Enum


#End Region
#Region "  構造体定義                               "
    '検索条件
    Private Structure SEARCH_ITEM
        Dim XCAR_NO_WARITUKE As String           '受付車番
        Dim XCAR_NO_EDA_WARITUKE As String       '受付車番枝番
        Dim XCAR_NO As String                    '車番
        Dim XSYUKKA_DT As String                 '出荷日
        Dim XORDER_NO As String                  '発注№
        Dim XNYUKA_JIGYOU_CD As String           '配送先ｺｰﾄﾞ
        Dim XIDOU_CD As String                   '移動手段ｺｰﾄﾞ
        Dim XGYOSHA_CD As String                 '業者ｺｰﾄﾞ
    End Structure
    ''' <summary>検索条件(ﾘｽﾄ用)</summary>
    Private Structure SEARCH_ITEM2
        Dim XHIKIATE_DT As String           '引当日
        Dim XORDER_NO As String             '発注№
        Dim XCAR_NO_WARITUKE As String      '受付車番
        Dim XCAR_NO_EDA_WARITUKE As String  '受付車番枝番
        Dim XNYUKA_JIGYOU_CD As String      '配送先ｺｰﾄﾞ
        Dim XNYUKA_JIGYOU_NM As String      '配送先名
        Dim XIDOU_CD As String              '移動手段ｺｰﾄﾞ
        Dim XGYOSHA_CD As String            '業者ｺｰﾄﾞ
    End Structure
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義　                            "
    ''' ======================================
    ''' <summary>受付車番</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userXCAR_NO_WARITUKE() As String
        Get
            Return mstrXCAR_NO_WARITUKE
        End Get
        Set(ByVal value As String)
            mstrXCAR_NO_WARITUKE = value
        End Set
    End Property

    ''' ======================================
    ''' <summary>受付車番枝番</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userXCAR_NO_EDA_WARITUKE() As String
        Get
            Return mstrXCAR_NO_EDA_WARITUKE
        End Get
        Set(ByVal value As String)
            mstrXCAR_NO_EDA_WARITUKE = value
        End Set
    End Property

    ''' ======================================
    ''' <summary>外部倉庫先行</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userXGAIBU_SOUKO_SENKOU() As String
        Get
            Return mstrXGAIBU_SOUKO_SENKOU
        End Get
        Set(ByVal value As String)
            mstrXGAIBU_SOUKO_SENKOU = value
        End Set
    End Property

    ''' ======================================
    ''' <summary>ﾊﾞｰｽ指定</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userXBERTH_SITEI() As String
        Get
            Return mstrXBERTH_SITEI
        End Get
        Set(ByVal value As String)
            mstrXBERTH_SITEI = value
        End Set
    End Property

    ''' ======================================
    ''' <summary>平1出庫判定</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userXHIRA1() As String
        Get
            Return mstrXHIRA1
        End Get
        Set(ByVal value As String)
            mstrXHIRA1 = value
        End Set
    End Property

    ''' ======================================
    ''' <summary>受注№</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userXORDER_NO() As String()
        Get
            Return mstrXORDER_NO
        End Get
        Set(ByVal value As String())
            mstrXORDER_NO = value
        End Set
    End Property

    ''' ======================================
    ''' <summary>受付車番(登録する車番)</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userXCAR_NO_TOUROKU() As String()
        Get
            Return mstrXCAR_NO_TOUROKU
        End Get
        Set(ByVal value As String())
            mstrXCAR_NO_TOUROKU = value
        End Set
    End Property

    ''' ======================================
    ''' <summary>受付車番枝番(登録する車番枝番)</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userXCAR_NO_EDA_TOUROKU() As String()
        Get
            Return mstrXCAR_NO_EDA_TOUROKU
        End Get
        Set(ByVal value As String())
            mstrXCAR_NO_EDA_TOUROKU = value
        End Set
    End Property

    ''' ======================================
    ''' <summary>配送先ｺｰﾄﾞ</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userXNYUKA_JIGYOU_CD() As String
        Get
            Return mstrXNYUKA_JIGYOU_CD
        End Get
        Set(ByVal value As String)
            mstrXNYUKA_JIGYOU_CD = value
        End Set
    End Property

    ''' ======================================
    ''' <summary>配送先名</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userXNYUKA_JIGYOU_NM() As String
        Get
            Return mstrXNYUKA_JIGYOU_NM
        End Get
        Set(ByVal value As String)
            mstrXNYUKA_JIGYOU_NM = value
        End Set
    End Property

    ''' ======================================
    ''' <summary>検索条件_車番</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userSCH_XCAR_NO() As String
        Get
            Return mstrSCH_XCAR_NO
        End Get
        Set(ByVal value As String)
            mstrSCH_XCAR_NO = value
        End Set
    End Property

    ''' ======================================
    ''' <summary>検索条件_出荷日</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userSCH_XSYUKKA_DT() As String
        Get
            Return mstrSCH_XSYUKKA_DT
        End Get
        Set(ByVal value As String)
            mstrSCH_XSYUKKA_DT = value
        End Set
    End Property

    ''' ======================================
    ''' <summary>検索条件_発注№</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userSCH_XORDER_NO() As String
        Get
            Return mstrSCH_XORDER_NO
        End Get
        Set(ByVal value As String)
            mstrSCH_XORDER_NO = value
        End Set
    End Property

    ''' ======================================
    ''' <summary>検索条件_配送先ｺｰﾄﾞ</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userSCH_XNYUKA_JIGYOU_CD() As String
        Get
            Return mstrSCH_XNYUKA_JIGYOU_CD
        End Get
        Set(ByVal value As String)
            mstrSCH_XNYUKA_JIGYOU_CD = value
        End Set
    End Property

    ''' ======================================
    ''' <summary>検索条件_移動手段ｺｰﾄﾞ</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userSCH_XIDOU_CD() As String
        Get
            Return mstrSCH_XIDOU_CD
        End Get
        Set(ByVal value As String)
            mstrSCH_XIDOU_CD = value
        End Set
    End Property

    ''' ======================================
    ''' <summary>検索条件_業者ｺｰﾄﾞ</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userSCH_XGYOSHA_CD() As String
        Get
            Return mstrSCH_XGYOSHA_CD
        End Get
        Set(ByVal value As String)
            mstrSCH_XGYOSHA_CD = value
        End Set
    End Property

    '''' ======================================
    '''' <summary>親画面ｸﾞﾘｯﾄﾞ</summary>
    '''' <remarks></remarks>
    '''' ======================================
    'Public Property userGrid() As GamenCommon.cmpMDataGrid
    '    Get
    '        Return mobjGrid
    '    End Get
    '    Set(ByVal value As GamenCommon.cmpMDataGrid)
    '        mobjGrid = value
    '    End Set
    'End Property

    '''' ======================================
    '''' <summary>受付車番枝番ﾘｽﾄｶﾗﾑ位置</summary>
    '''' <remarks></remarks>
    '''' ======================================
    'Public Property userCol_XCAR_NO_EDA_WARITUKE() As Integer
    '    Get
    '        Return mintCol_XCAR_NO_EDA_WARITUKE
    '    End Get
    '    Set(ByVal value As Integer)
    '        mintCol_XCAR_NO_EDA_WARITUKE = value
    '    End Set
    'End Property
#End Region
#Region "　ﾌｫｰﾑﾛｰﾄﾞ                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub InitializeChild()

        '**********************************************************
        ' ﾎﾞﾀﾝﾏｽｸ設定
        '**********************************************************
        Call CmdEnabledChangeMenu()                             'Menuﾎﾞﾀﾝ全般
        Call CmdEnabledChange(cmdClose, False)                  'ﾛｸﾞｵﾌﾎﾞﾀﾝ
        Call CmdEnabledChange(cmdMsgChk, False)                 'ｱﾅｼｴｰﾀﾎﾞﾀﾝ

        '**********************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄｱｯﾌﾟ
        '**********************************************************
        Call gobjComFuncFRM.cboSetup(Me.Name, cboXGAIBU_SOUKO_FLAG, False)     '外部倉庫先行
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboXBERTH_SITEI, True)   'ﾊﾞｰｽ指定


        '↓↓↓ 2012/11/08 17:00 DEL
        'If (TO_INTEGER(mstrXBERTH_SITEI) = 0) Then
        '    '(ﾊﾞｰｽ出荷なしの時)
        '    lblXBERTH_SITEI.Visible = False            'ﾊﾞｰｽ指定ｺﾝﾎﾞ
        '    cboXBERTH_SITEI.Visible = False
        '    cboXBERTH_SITEI.Enabled = False
        'Else
        '    '(ﾊﾞｰｽ出荷ありの時)
        '    lblXBERTH_SITEI.Visible = True             'ﾊﾞｰｽ指定ｺﾝﾎﾞ
        '    cboXBERTH_SITEI.Visible = True
        '    cboXBERTH_SITEI.Enabled = True
        'End If

        'If TO_INTEGER(mstrXGAIBU_SOUKO_SENKOU) = 1 Then
        '    '(構内と外部倉庫に出荷ありの時)
        '    lblGAIBU_SOUKO_FLAG.Visible = True
        '    cboXGAIBU_SOUKO_FLAG.Visible = True
        '    cboXGAIBU_SOUKO_FLAG.Enabled = True

        '    If (TO_INTEGER(mstrXBERTH_SITEI) = 0) And _
        '       (TO_INTEGER(mstrXHIRA1) = 0) Then
        '        '(ﾊﾞｰｽ出荷なし、平1出庫なしの時)
        '        cboXGAIBU_SOUKO_FLAG.SelectedIndex = 1      '外部倉庫先行
        '        lblGAIBU_SOUKO_FLAG.Visible = False
        '        cboXGAIBU_SOUKO_FLAG.Visible = False
        '        cboXGAIBU_SOUKO_FLAG.Enabled = False
        '    End If

        'Else
        '    '(構内のみの時)
        '    lblGAIBU_SOUKO_FLAG.Visible = False
        '    cboXGAIBU_SOUKO_FLAG.Visible = False
        '    cboXGAIBU_SOUKO_FLAG.Enabled = False
        'End If
        '↑↑↑ 2012/11/08 17:00 DEL



        '**********************************************************
        'ﾃｷｽﾄﾎﾞｯｸｽｾｯﾄｱｯﾌﾟ
        '**********************************************************
        lblXCAR_NO_WARITUKE.Text = mstrXCAR_NO_WARITUKE             '受付車番
        'txtXCAR_NO_EDA_WARITUKE.Text = mstrXCAR_NO_EDA_WARITUKE     '枝番


        ''**********************************************************
        ''ｺﾝﾃﾅ車 ｾｯﾄｱｯﾌﾟ
        ''**********************************************************
        'Call MakeTrackNyumonUketukeSub_XCAR_NO_DAIHYOU(mstrXCAR_NO_WARITUKE, cboXDSPCAR_NO_DAIHYOU, True)   '代表車番選択

        '*********************************************
        ' ｸﾞﾘｯﾄﾞ初期化
        '*********************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListSetup()

        Call gobjComFuncFRM.FlexGridInitialize(grdList2, 1, menmListCol2.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListSetup2()

        Call gobjComFuncFRM.FlexGridInitialize(grdList3, 1, menmListCol3.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListSetup3()

        mFlag_Form_Load = False
        mFlag_GRID_CLEAR = True

        '*********************************************
        ' 構造体ｾｯﾄ
        '*********************************************
        Call SearchItem_Set()

        '*********************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '*********************************************
        Call grdListDisplaySub(grdList)

    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑｱﾝﾛｰﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub CloseChild()

        '******************************************
        ' ｺﾝﾄﾛｰﾙの開放
        '******************************************
        cboXGAIBU_SOUKO_FLAG.Dispose()
        cboXBERTH_SITEI.Dispose()
        grdList.Dispose()                   'ｸﾞﾘｯﾄﾞ

    End Sub
#End Region
#Region "  F1(OK)           ﾎﾞﾀﾝ押下処理　          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F1(OK)         ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F1Process()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck() = False Then
            Exit Sub
        End If

        '********************************************************************
        'ｿｹｯﾄ送信処理
        '********************************************************************
        If SendSocket02(1) = False Then
            Exit Sub
        End If


        '*******************************************************
        '印刷処理
        '*******************************************************
        Call printOut()


        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub
#End Region
#Region "  F8(ｷｬﾝｾﾙ)        ﾎﾞﾀﾝ押下処理　          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F8(ｷｬﾝｾﾙ)         ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F8Process()

        '******************************************
        ' 画面遷移
        '******************************************
        'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_308130, Me)
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub
#End Region


#Region "　入力ﾁｪｯｸ　                               "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】 [ IN  ]　入力ﾁｪｯｸ判別
    '【戻値】 True :入力ﾁｪｯｸ成功
    '         False:入力ﾁｪｯｸ失敗
    '*******************************************************************************************************************
    Protected Overridable Function InputCheck() As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        Select Case "a"
            Case "a"

                '↓↓↓ 2012/11/08 
                '==========================
                ' 受付車番枝番 ﾁｪｯｸ
                '==========================
                'If txtXCAR_NO_EDA_WARITUKE.Text = "" Then
                '    '(受付車番枝番に入力ない時)
                '    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308041_05, PopupFormType.Ok, PopupIconType.Information)
                '    blnCheckErr = True
                '    Exit Select
                'End If

                '==========================
                ' 受付車番枝番 重複ﾁｪｯｸ
                '==========================
                'If mstrXCAR_NO_EDA_WARITUKE <> txtXCAR_NO_EDA_WARITUKE.Text Then
                '    '(受付車番枝番を変更した時)
                '    Dim intRet As RetCode
                '    Dim strCAR_EDA_Temp As String = txtXCAR_NO_EDA_WARITUKE.Text
                '    intRet = gobjComFuncFRM.GET_XCAR_NO_EDA_WARITUKE(lblXCAR_NO_WARITUKE.Text _
                '                                                   , txtXCAR_NO_EDA_WARITUKE.Text _
                '                                                    )
                '    If intRet <> RetCode.OK Then
                '        '(受付車番枝番が既に同じものがある時)
                '        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308041_06, PopupFormType.Ok, PopupIconType.Information)
                '        blnCheckErr = True
                '        Exit Select
                '    End If
                'End If
                '↑↑↑ 2012/11/08 


                '↓↓↓ 2012/11/08 
                '======================================
                ' ﾊﾞｰｽ割付済みの 受付車番枝番 重複ﾁｪｯｸ
                '======================================
                '**********************************************************
                ' ﾊﾞｰｽ状況の特定
                '**********************************************************
                For ii As Integer = 0 To grdList.RowCount - 1
                    '(ﾙｰﾌﾟ:ｸﾞﾘｯﾄﾞ行)
                    Dim objXPRG_BERTH As TBL_XPRG_BERTH                                   'ﾊﾞｰｽ状況
                    objXPRG_BERTH = New TBL_XPRG_BERTH(gobjOwner, gobjDb, Nothing)
                    objXPRG_BERTH.XCAR_NO_WARITUKE = lblXCAR_NO_WARITUKE.Text             '割付車番
                    '**DEL2012/11/08** objXPRG_BERTH.XCAR_NO_EDA_WARITUKE = txtXCAR_NO_EDA_WARITUKE.Text     '割付車番枝番
                    objXPRG_BERTH.XCAR_NO_EDA_WARITUKE = TO_STRING(grdList.Item(menmListCol.XCAR_NO_EDA_WARITUKE, ii).Value)  '割付車番枝番
                    If objXPRG_BERTH.GET_XPRG_BERTH_COUNT() > 0 Then
                        '(ﾊﾞｰｽに同じ車番、枝番が存在するとき)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308041_06, PopupFormType.Ok, PopupIconType.Information)
                        blnCheckErr = True
                        Exit Select
                    End If
                Next
                '↑↑↑ 2012/11/08 


                '==========================
                'ﾊﾞｰｽ指定  選択ﾁｪｯｸ
                '==========================
                If TO_INTEGER(mstrXBERTH_SITEI) = 1 Then
                    '(ﾊﾞｰｽ出荷ありの時)
                Else
                    '(ﾊﾞｰｽ出荷無しの時)
                    If cboXBERTH_SITEI.Text <> CBO_ALL_VALUE Then
                        '(ﾊﾞｰｽ指定が選択されている場合)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308041_02, PopupFormType.Ok, PopupIconType.Information)
                        blnCheckErr = True
                        Exit Select
                    End If
                End If



                '============================
                '在庫の存在ﾁｪｯｸ(自動倉庫対象)
                '============================
                Dim strSQL As String

                Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
                Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名

                Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ

                '-----------------------
                '抽出SQL作成
                '-----------------------
                strSQL = ""
                strSQL &= vbCrLf & " SELECT "
                strSQL &= vbCrLf & "    XPLN_OUT.XORDER_NO "
                strSQL &= vbCrLf & "  , XPLN_OUT_DTL.XSYUKKA_NO "
                strSQL &= vbCrLf & "  , XSTS_HIKIATE_K1.FSAGYOU_KIND "
                strSQL &= vbCrLf & "  , XSTS_HIKIATE_K1.FPLAN_KEY "
                strSQL &= vbCrLf & "  , TRST_STOCK.FPALLET_ID "
                strSQL &= vbCrLf & "  , (CASE WHEN NVL(TRST_STOCK.FPALLET_ID,'UNKNOWN') = 'UNKNOWN' THEN 0 ELSE 1 END) AS XPALLET_ID_EXIST "
                strSQL &= vbCrLf & " FROM "
                strSQL &= vbCrLf & "    XPLN_OUT "
                strSQL &= vbCrLf & "  , XPLN_OUT_DTL "
                strSQL &= vbCrLf & "  , XSTS_HIKIATE_K1 "
                strSQL &= vbCrLf & "  , TRST_STOCK "
                strSQL &= vbCrLf & " WHERE 1 = 1 "
                strSQL &= vbCrLf & "  AND XPLN_OUT.XORDER_NO          IN( "
                For ii As Integer = LBound(mstrXORDER_NO) To UBound(mstrXORDER_NO)
                    If ii = LBound(mstrXORDER_NO) Then
                        '(初回)
                        strSQL &= vbCrLf & "  '" & mstrXORDER_NO(ii) & "' "
                    Else
                        '(以降)
                        strSQL &= vbCrLf & ", '" & mstrXORDER_NO(ii) & "' "
                    End If
                Next
                strSQL &= vbCrLf & "                                    ) "
                strSQL &= vbCrLf & "  AND XPLN_OUT.XSYUKKA_NO         = XPLN_OUT_DTL.XSYUKKA_NO "
                strSQL &= vbCrLf & "  AND XPLN_OUT_DTL.FPLAN_KEY      = XSTS_HIKIATE_K1.FPLAN_KEY "
                strSQL &= vbCrLf & "  AND XSTS_HIKIATE_K1.FPALLET_ID  = TRST_STOCK.FPALLET_ID(+) "
                strSQL &= vbCrLf & "  AND XSTS_HIKIATE_K1.FTRK_BUF_NO = " & FTRK_BUF_NO_J9000        '自動倉庫
                strSQL &= vbCrLf

                '-----------------------
                '抽出
                '-----------------------
                gobjDb.SQL = strSQL
                objDataSet.Clear()
                strDataSetName = "TRST_STOCK"
                gobjDb.GetDataSet(strDataSetName, objDataSet)

                If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                    '(見つかった場合)
                    'objRow = objDataSet.Tables(strDataSetName).Rows(0)
                    For Each objRow In objDataSet.Tables(strDataSetName).Rows
                        '(ﾙｰﾌﾟ:読めた数)
                        If TO_INTEGER(objRow.Item("XPALLET_ID_EXIST")) = 0 Then
                            '(在庫が無くなっている場合)
                            Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308041_08, PopupFormType.Ok, PopupIconType.Information)
                            blnCheckErr = True
                            Exit Select
                        End If
                    Next
                End If



                '==========================
                '保留区分ﾁｪｯｸ
                '==========================
                '-----------------------
                '抽出SQL作成
                '-----------------------
                strSQL = ""
                strSQL &= vbCrLf & " SELECT "
                strSQL &= vbCrLf & "    XPLN_OUT.XORDER_NO "
                strSQL &= vbCrLf & "  , XPLN_OUT_DTL.XSYUKKA_NO "
                strSQL &= vbCrLf & "  , XSTS_HIKIATE_K1.FSAGYOU_KIND "
                strSQL &= vbCrLf & "  , XSTS_HIKIATE_K1.FPLAN_KEY "
                strSQL &= vbCrLf & "  , TRST_STOCK.FPALLET_ID "
                strSQL &= vbCrLf & "  , TRST_STOCK.FHORYU_KUBUN "
                strSQL &= vbCrLf & " FROM "
                strSQL &= vbCrLf & "    XPLN_OUT "
                strSQL &= vbCrLf & "  , XPLN_OUT_DTL "
                strSQL &= vbCrLf & "  , XSTS_HIKIATE_K1 "
                strSQL &= vbCrLf & "  , TRST_STOCK "
                strSQL &= vbCrLf & " WHERE 1 = 1 "
                strSQL &= vbCrLf & "  AND XPLN_OUT.XORDER_NO          IN( "
                For ii As Integer = LBound(mstrXORDER_NO) To UBound(mstrXORDER_NO)
                    If ii = LBound(mstrXORDER_NO) Then
                        '(初回)
                        strSQL &= vbCrLf & "  '" & mstrXORDER_NO(ii) & "' "
                    Else
                        '(以降)
                        strSQL &= vbCrLf & ", '" & mstrXORDER_NO(ii) & "' "
                    End If
                Next
                strSQL &= vbCrLf & "                                    ) "
                strSQL &= vbCrLf & "  AND XPLN_OUT.XSYUKKA_NO        = XPLN_OUT_DTL.XSYUKKA_NO "
                strSQL &= vbCrLf & "  AND XPLN_OUT_DTL.FPLAN_KEY     = XSTS_HIKIATE_K1.FPLAN_KEY "
                strSQL &= vbCrLf & "  AND XSTS_HIKIATE_K1.FPALLET_ID = TRST_STOCK.FPALLET_ID(+) "
                strSQL &= vbCrLf & "  AND TRST_STOCK.FHORYU_KUBUN   <> " & FHORYU_KUBUN_SNORMAL     '保留区分 <> 通常 
                strSQL &= vbCrLf

                '-----------------------
                '抽出
                '-----------------------
                gobjDb.SQL = strSQL
                objDataSet.Clear()
                strDataSetName = "TRST_STOCK"
                gobjDb.GetDataSet(strDataSetName, objDataSet)

                If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                    '(見つかった場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308041_09, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If


                blnCheckErr = False

        End Select


        If blnCheckErr = True Then
            '(ﾁｪｯｸに引っかかった時)
            blnReturn = False
        Else
            '(ﾁｪｯｸに引っかからなかった時)
            blnReturn = True
        End If

        Return blnReturn

    End Function
#End Region

#Region "　構造体ｾｯﾄ　                              "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub SearchItem_Set()

        '********************************************************************
        '構造体に値をｾｯﾄ
        '********************************************************************
        mudtSEARCH_ITEM.XCAR_NO_WARITUKE = mstrXCAR_NO_WARITUKE           '割付車番
        mudtSEARCH_ITEM.XCAR_NO_EDA_WARITUKE = mstrXCAR_NO_EDA_WARITUKE   '割付車番枝番
        mudtSEARCH_ITEM.XCAR_NO = mstrSCH_XCAR_NO                         '車番
        mudtSEARCH_ITEM.XSYUKKA_DT = mstrSCH_XSYUKKA_DT                   '出荷日
        mudtSEARCH_ITEM.XORDER_NO = mstrSCH_XORDER_NO                     '発注№
        mudtSEARCH_ITEM.XNYUKA_JIGYOU_CD = mstrSCH_XNYUKA_JIGYOU_CD       '配送先ｺｰﾄﾞ
        mudtSEARCH_ITEM.XIDOU_CD = mstrSCH_XIDOU_CD                       '移動手段ｺｰﾄﾞ
        mudtSEARCH_ITEM.XGYOSHA_CD = mstrSCH_XGYOSHA_CD                   '業者ｺｰﾄﾞ

    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ表示　                             "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub grdListDisplayChild()

        Dim strSQL As String                    'SQL文


        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & " SELECT DISTINCT "
        strSQL &= vbCrLf & "     '' AS XCAR_NO_WARITUKE "                                           '受付車番
        strSQL &= vbCrLf & "   , '' AS XCAR_NO_EDA_WARITUKE "                                       '受付車番枝番
        strSQL &= vbCrLf & "   , XPLN_OUT.XSYUKKA_DT "                                              '出荷日
        strSQL &= vbCrLf & "   , TO_DATE(XPLN_OUT.XSYUKKA_DT, 'YYYY/MM/DD') AS XSYUKKA_DT_DSP "     '出荷日(表示用)
        strSQL &= vbCrLf & "   , XPLN_OUT.XNYUKA_JIGYOU_CD "                                        '配送先ｺｰﾄﾞ
        strSQL &= vbCrLf & "   , XPLN_OUT.XNYUKA_JIGYOU_NM "                                        '配送先名
        strSQL &= vbCrLf & "   , XPLN_OUT.XORDER_NO "                                               '発注№
        strSQL &= vbCrLf & "   , XPLN_OUT.XCAR_NO "                                                 '車番
        strSQL &= vbCrLf & "   , XPLN_OUT.XIDOU_CD "                                                '移動手段ｺｰﾄﾞ
        strSQL &= vbCrLf & "   , XPLN_OUT.XARRIVAL_DT "                                             '到着日
        strSQL &= vbCrLf & "   , TO_DATE(XPLN_OUT.XARRIVAL_DT, 'YYYY/MM/DD') AS XARRIVAL_DT_DSP "   '到着日(表示用)
        strSQL &= vbCrLf & "   , XPLN_OUT.XGYOSHA_CD "                                              '業者ｺｰﾄﾞ
        strSQL &= vbCrLf & "   , NULL AS XSYUKKA_BERTH "                                            '出荷ﾊﾞｰｽ
        strSQL &= vbCrLf & "   , NULL AS XSYUKKA_BERTH_DSP "                                        '出荷ﾊﾞｰｽ(表示用)
        strSQL &= vbCrLf & "   , NULL AS XHIRA1 "                                                   '平1
        strSQL &= vbCrLf & "   , NULL AS XHIRA1_DSP "                                               '平1(表示用)
        '↓↓↓↓ 2012.12.03 11:30 H.Morita ﾊﾞﾗ平「○」表示対応
        strSQL &= vbCrLf & "   , NULL AS XBARA "                                                    'ﾊﾞﾗ平(0:なし 1:○)
        strSQL &= vbCrLf & "   , NULL AS XBARA_DSP "                                                'ﾊﾞﾗ平(表示用)
        '↑↑↑↑ 2012.12.03 11:30 H.Morita ﾊﾞﾗ平「○」表示対応
        strSQL &= vbCrLf & "   , NULL AS XGAIBU_SOUKO "                                             '外部倉庫   
        strSQL &= vbCrLf & "   , NULL AS XGAIBU_SOUKO_DSP "                                         '外部倉庫(表示用)   

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "   XPLN_OUT "               '出荷計画

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE 1 = 1  "

        'If txtXCAR_NO_EDA_WARITUKE.Text = CBO_ALL_VALUE Then
        '    '(枝番に入力ない場合)
        '    strSQL &= vbCrLf & "    AND XPLN_OUT.XPROGRESS_OUT = " & XPROGRESS_OUT_JHIKIATE      '進捗状態 = 「引当済」
        'Else
        '    '(枝番に入力ある場合)
        '    strSQL &= vbCrLf & "    AND XPLN_OUT.XPROGRESS_OUT = " & XPROGRESS_OUT_JGAIBU_SOUKO      '進捗状態 = 「外部倉庫出荷中」
        'End If


        ''----------------------------------------------
        ''受付車番＋枝番
        ''----------------------------------------------
        'If txtXCAR_NO_EDA_WARITUKE.Text <> CBO_ALL_VALUE Then
        '    '(枝番に入力ある場合)
        '    strSQL &= vbCrLf & "      AND XPLN_OUT.XCAR_NO_WARITUKE     = '" & mudtSEARCH_ITEM.XCAR_NO_WARITUKE & "' "
        '    strSQL &= vbCrLf & "      AND XPLN_OUT.XCAR_NO_EDA_WARITUKE = '" & mudtSEARCH_ITEM.XCAR_NO_EDA_WARITUKE & "' "

        '    strSQL &= vbCrLf & "      AND XPLN_OUT.XORDER_NO NOT IN "               '既にﾊﾞｰｽ待ちにいるのを除く
        '    strSQL &= vbCrLf & "          (SELECT "
        '    strSQL &= vbCrLf & "              XPLN_OUT.XORDER_NO "
        '    strSQL &= vbCrLf & "           FROM "
        '    strSQL &= vbCrLf & "              XPLN_OUT "
        '    strSQL &= vbCrLf & "            , XPLN_BERTH_WAIT "
        '    strSQL &= vbCrLf & "           WHERE 1 = 1 "
        '    strSQL &= vbCrLf & "              AND XPLN_OUT.XCAR_NO_WARITUKE     = '" & mudtSEARCH_ITEM.XCAR_NO_WARITUKE & "' "
        '    strSQL &= vbCrLf & "              AND XPLN_OUT.XCAR_NO_EDA_WARITUKE = '" & mudtSEARCH_ITEM.XCAR_NO_EDA_WARITUKE & "' "
        '    strSQL &= vbCrLf & "              AND XPLN_OUT.XCAR_NO_WARITUKE     = XPLN_BERTH_WAIT.XCAR_NO "
        '    strSQL &= vbCrLf & "              AND XPLN_OUT.XCAR_NO_EDA_WARITUKE = XPLN_BERTH_WAIT.XCAR_NO_EDA "
        '    strSQL &= vbCrLf & "          ) "

        'Else
        '    strSQL &= vbCrLf & "      AND XPLN_OUT.XCAR_NO_WARITUKE     IS NULL "
        '    strSQL &= vbCrLf & "      AND XPLN_OUT.XCAR_NO_EDA_WARITUKE IS NULL "
        'End If

        ''----------------------------------------------
        ''車番
        ''----------------------------------------------
        'If mudtSEARCH_ITEM.XCAR_NO <> CBO_ALL_VALUE Then
        '    '(全検索以外の場合)
        '    strSQL &= vbCrLf & "      AND XPLN_OUT.XCAR_NO = '" & mudtSEARCH_ITEM.XCAR_NO & "' "
        'End If

        ''----------------------------------------------
        ''出荷日
        ''----------------------------------------------
        'If mudtSEARCH_ITEM.XSYUKKA_DT <> CBO_ALL_VALUE Then
        '    '(全検索以外の場合)
        '    strSQL &= vbCrLf & "      AND XPLN_OUT.XSYUKKA_DT = '" & mudtSEARCH_ITEM.XSYUKKA_DT & "' "
        'End If

        '----------------------------------------------
        '発注№
        '----------------------------------------------
        'If mudtSEARCH_ITEM.XORDER_NO <> CBO_ALL_VALUE Then
        '(全検索以外の場合)
        'strSQL &= vbCrLf & "      AND XPLN_OUT.XORDER_NO = '" & mudtSEARCH_ITEM.XORDER_NO & "' "
        strSQL &= vbCrLf & "      AND XPLN_OUT.XORDER_NO IN ( "

        For ii As Integer = LBound(mstrXORDER_NO) To UBound(mstrXORDER_NO)
            '(ﾙｰﾌﾟ:登録する受注№)
            If ii = 0 Then
                '(1回目)
                strSQL &= vbCrLf & "                                 '" & mstrXORDER_NO(ii) & "' "
            Else
                '(以外)
                strSQL &= vbCrLf & "                               , '" & mstrXORDER_NO(ii) & "' "
            End If
        Next

        strSQL &= vbCrLf & "                                ) "
        'End If

        ''----------------------------------------------
        ''配送先ｺｰﾄﾞ
        ''----------------------------------------------
        'If mudtSEARCH_ITEM.XNYUKA_JIGYOU_CD <> CBO_ALL_VALUE Then
        '    '(全検索以外の場合)
        '    strSQL &= vbCrLf & "      AND XPLN_OUT.XNYUKA_JIGYOU_CD = '" & mudtSEARCH_ITEM.XNYUKA_JIGYOU_CD & "' "
        'End If

        ''----------------------------------------------
        ''移動手段ｺｰﾄﾞ
        ''----------------------------------------------
        'If mudtSEARCH_ITEM.XIDOU_CD <> CBO_ALL_VALUE Then
        '    '(全検索以外の場合)
        '    strSQL &= vbCrLf & "      AND XPLN_OUT.XIDOU_CD = '" & mudtSEARCH_ITEM.XIDOU_CD & "' "
        'End If

        ''----------------------------------------------
        ''業者ｺｰﾄﾞ
        ''----------------------------------------------
        'If mudtSEARCH_ITEM.XGYOSHA_CD <> CBO_ALL_VALUE Then
        '    '(全検索以外の場合)
        '    strSQL &= vbCrLf & "      AND XPLN_OUT.XGYOSHA_CD = '" & mudtSEARCH_ITEM.XGYOSHA_CD & "' "
        'End If


        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & gobjComFuncFRM.GetSQL_TDSP_GRID_OrderBy(Me, grdList)
        strSQL &= vbCrLf


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        Call gobjComFuncFRM.TblDataGridDisplay(grdList, strSQL, True)


        '********************************************************************
        ' 出荷ﾊﾞｰｽ～外部倉庫「○」、外部倉庫「済」 表示設定
        '********************************************************************
        Call SET_TAHINMOK_DSP()

        '********************************************************************
        ' 受付車番、受付車番枝番 表示設定
        '********************************************************************
        Call SET_CAR_NO_DSP()

        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdListSetup()
        Call gobjComFuncFRM.GridSelect(grdList, -1, -1, Nothing)       'ｸﾞﾘｯﾄﾞ選択処理


        mFlag_GRID_CLEAR = False        'ｸﾞﾘｯﾄﾞ表示あり

    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ表示設定　                         "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub grdListSetup()

        '************************************************
        'ｸﾞﾘｯﾄﾞﾏｽﾀの定義を反映
        '************************************************
        Call gobjComFuncFRM.TDSP_GRIDSetup(Me, grdList)

        grdList.MultiSelect = True
        grdList.Columns(menmListCol.XGAIBU_SOUKO_DSP).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill         '列幅自動調節
        'grdList.AllowUserToResizeColumns = False


        If grdList.Rows.Count > 0 Then
            '(ﾃﾞｰﾀある時)
            grdList.Sort(grdList.Columns(1), System.ComponentModel.ListSortDirection.Ascending)     '枝番で昇順
        End If

    End Sub
#End Region

#Region "　出荷ﾊﾞｰｽ～外部倉庫「○」表示設定 (旧)    "
    ''*******************************************************************************************************************
    ''【機能】同上
    ''【引数】
    ''【戻値】
    ''*******************************************************************************************************************
    'Private Sub SET_TAHINMOK_DSP()

    '    '↓↓↓ 2012/11/08 17:00 ADD
    '    mstrXBERTH_SITEI = "0"
    '    '↑↑↑ 2012/11/08 17:00 ADD


    '    Dim strSQL As String


    '    Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
    '    Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名

    '    Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ

    '    Dim intASOUKO_CNT As Integer = 0           '他品目出荷  出荷ﾊﾞｰｽ
    '    Dim intHIRA1_CNT As Integer = 0            '他品目出荷  平置き1
    '    Dim intBARA_CNT As Integer = 0             '他品目出荷  ﾊﾞﾗ平置き
    '    Dim intGAIBU_CNT As Integer = 0            '他品目出荷  外部倉庫
    '    Dim intGAIBU_ZUMI_CNT As Integer = 0       '外部倉庫 積込み済
    '    'Dim intGAIBU_NONZUMI_CNT As Integer = 0    '外部倉庫 積込み済以外
    '    Dim intASOUKO_TO_BARA_CNT As Integer = 0   'ﾊﾞﾗ補充中(出荷ﾊﾞｰｽ→ﾊﾞﾗ平置き)


    '    For ii As Integer = 0 To grdList.RowCount - 1
    '        '(ｸﾞﾘｯﾄﾞの行数分繰り返し)

    '        '-----------------------
    '        '抽出SQL作成
    '        '-----------------------
    '        strSQL = ""
    '        strSQL &= vbCrLf & " SELECT "
    '        strSQL &= vbCrLf & "     SUM(ASOUKO_CNT) AS ASOUKO_CNT "
    '        strSQL &= vbCrLf & "   , SUM(HIRA1_CNT)  AS HIRA1_CNT "
    '        strSQL &= vbCrLf & "   , SUM(BARA_CNT)  AS BARA_CNT "
    '        strSQL &= vbCrLf & "   , SUM(GAIBU_CNT)  AS GAIBU_CNT "
    '        strSQL &= vbCrLf & "   , SUM(GAIBU_ZUMI_CNT)  AS GAIBU_ZUMI_CNT "
    '        strSQL &= vbCrLf & "   , SUM(ASOUKO_TO_BARA_CNT) AS ASOUKO_TO_BARA_CNT "
    '        strSQL &= vbCrLf & " FROM "
    '        strSQL &= vbCrLf & "   ( "
    '        strSQL &= vbCrLf & "   SELECT "
    '        strSQL &= vbCrLf & "       COUNT(0) AS ASOUKO_CNT "
    '        strSQL &= vbCrLf & "     , 0        AS HIRA1_CNT "
    '        strSQL &= vbCrLf & "     , 0        AS BARA_CNT "
    '        strSQL &= vbCrLf & "     , 0        AS GAIBU_CNT "
    '        strSQL &= vbCrLf & "     , 0        AS GAIBU_ZUMI_CNT "
    '        strSQL &= vbCrLf & "     , 0        AS ASOUKO_TO_BARA_CNT "
    '        strSQL &= vbCrLf & "   FROM "
    '        strSQL &= vbCrLf & "       XPLN_OUT "
    '        strSQL &= vbCrLf & "     , XPLN_OUT_DTL "
    '        strSQL &= vbCrLf & "     , XSTS_HIKIATE_K1 "
    '        strSQL &= vbCrLf & "     , TPRG_TRK_BUF "
    '        strSQL &= vbCrLf & "   WHERE  1 = 1 "
    '        strSQL &= vbCrLf & "     AND XPLN_OUT.XSYUKKA_NO        = XPLN_OUT_DTL.XSYUKKA_NO(+) "
    '        strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.FPLAN_KEY     = XSTS_HIKIATE_K1.FPLAN_KEY(+) "
    '        strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K1.FPALLET_ID = TPRG_TRK_BUF.FPALLET_ID(+) "
    '        strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XPROGRESS_OUT IN ( " & XPROGRESS_OUT_JHIKIATE & "," & XPROGRESS_OUT_JGAIBU_SOUKO & ") "   '引当済みまたは外部倉庫出荷中
    '        strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FTRK_BUF_NO   = " & FTRK_BUF_NO_J9000              '自動倉庫
    '        strSQL &= vbCrLf & "     AND XPLN_OUT.XORDER_NO = '" & TO_STRING(grdList.Item(menmListCol.XORDER_NO, ii).Value) & "' "


    '        strSQL &= vbCrLf & "   UNION "
    '        strSQL &= vbCrLf & "   SELECT "
    '        strSQL &= vbCrLf & "       0        AS ASOUKO_CNT "
    '        strSQL &= vbCrLf & "     , COUNT(0) AS HIRA1_CNT "
    '        strSQL &= vbCrLf & "     , 0        AS BARA_CNT "
    '        strSQL &= vbCrLf & "     , 0        AS GAIBU_CNT "
    '        strSQL &= vbCrLf & "     , 0        AS GAIBU_ZUMI_CNT "
    '        strSQL &= vbCrLf & "     , 0        AS ASOUKO_TO_BARA_CNT "
    '        strSQL &= vbCrLf & "   FROM "
    '        strSQL &= vbCrLf & "       XPLN_OUT "
    '        strSQL &= vbCrLf & "     , XPLN_OUT_DTL "
    '        strSQL &= vbCrLf & "     , XSTS_HIKIATE_K1 "
    '        strSQL &= vbCrLf & "     , TPRG_TRK_BUF "
    '        strSQL &= vbCrLf & "   WHERE  1 = 1 "
    '        strSQL &= vbCrLf & "     AND XPLN_OUT.XSYUKKA_NO        = XPLN_OUT_DTL.XSYUKKA_NO(+) "
    '        strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.FPLAN_KEY     = XSTS_HIKIATE_K1.FPLAN_KEY(+) "
    '        strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K1.FPALLET_ID = TPRG_TRK_BUF.FPALLET_ID(+) "
    '        'strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XPROGRESS_OUT = " & XPROGRESS_OUT_JHIKIATE        '引当済み
    '        strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XPROGRESS_OUT IN ( " & XPROGRESS_OUT_JHIKIATE & "," & XPROGRESS_OUT_JGAIBU_SOUKO & ") "   '引当済みまたは外部倉庫出荷中
    '        strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FTRK_BUF_NO   = " & FTRK_BUF_NO_J8001             '平置き1
    '        strSQL &= vbCrLf & "     AND XPLN_OUT.XORDER_NO = '" & TO_STRING(grdList.Item(menmListCol.XORDER_NO, ii).Value) & "' "


    '        strSQL &= vbCrLf & "   UNION "
    '        strSQL &= vbCrLf & "   SELECT "
    '        strSQL &= vbCrLf & "       0        AS ASOUKO_CNT "
    '        strSQL &= vbCrLf & "     , 0        AS HIRA1_CNT "
    '        strSQL &= vbCrLf & "     , COUNT(0) AS BARA_CNT "
    '        strSQL &= vbCrLf & "     , 0        AS GAIBU_CNT "
    '        strSQL &= vbCrLf & "     , 0        AS GAIBU_ZUMI_CNT "
    '        strSQL &= vbCrLf & "     , 0        AS ASOUKO_TO_BARA_CNT "
    '        strSQL &= vbCrLf & "   FROM "
    '        strSQL &= vbCrLf & "       XPLN_OUT "
    '        strSQL &= vbCrLf & "     , XPLN_OUT_DTL "
    '        strSQL &= vbCrLf & "     , XSTS_HIKIATE_K1 "
    '        strSQL &= vbCrLf & "     , TPRG_TRK_BUF "
    '        strSQL &= vbCrLf & "   WHERE  1 = 1 "
    '        strSQL &= vbCrLf & "     AND XPLN_OUT.XSYUKKA_NO        = XPLN_OUT_DTL.XSYUKKA_NO(+) "
    '        strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.FPLAN_KEY     = XSTS_HIKIATE_K1.FPLAN_KEY(+) "
    '        strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K1.FPALLET_ID = TPRG_TRK_BUF.FPALLET_ID(+) "
    '        'strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XPROGRESS_OUT = " & XPROGRESS_OUT_JHIKIATE        '引当済み
    '        strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XPROGRESS_OUT IN ( " & XPROGRESS_OUT_JHIKIATE & "," & XPROGRESS_OUT_JGAIBU_SOUKO & ") "   '引当済みまたは外部倉庫出荷中
    '        strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FTRK_BUF_NO   = " & FTRK_BUF_NO_J8000             'ﾊﾞﾗ平置き
    '        strSQL &= vbCrLf & "     AND XPLN_OUT.XORDER_NO = '" & TO_STRING(grdList.Item(menmListCol.XORDER_NO, ii).Value) & "' "


    '        strSQL &= vbCrLf & "   UNION "
    '        strSQL &= vbCrLf & "   SELECT "
    '        strSQL &= vbCrLf & "       0        AS ASOUKO_CNT "
    '        strSQL &= vbCrLf & "     , 0        AS HIRA1_CNT "
    '        strSQL &= vbCrLf & "     , 0        AS BARA_CNT "
    '        strSQL &= vbCrLf & "     , COUNT(0) AS GAIBU_CNT "
    '        strSQL &= vbCrLf & "     , 0        AS GAIBU_ZUMI_CNT "
    '        strSQL &= vbCrLf & "     , 0        AS ASOUKO_TO_BARA_CNT "
    '        strSQL &= vbCrLf & "   FROM "
    '        strSQL &= vbCrLf & "       XPLN_OUT "
    '        strSQL &= vbCrLf & "     , XPLN_OUT_DTL "
    '        strSQL &= vbCrLf & "     , XSTS_HIKIATE_K1 "
    '        strSQL &= vbCrLf & "     , TPRG_TRK_BUF "
    '        strSQL &= vbCrLf & "   WHERE  1 = 1 "
    '        strSQL &= vbCrLf & "     AND XPLN_OUT.XSYUKKA_NO        = XPLN_OUT_DTL.XSYUKKA_NO(+) "
    '        strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.FPLAN_KEY     = XSTS_HIKIATE_K1.FPLAN_KEY(+) "
    '        strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K1.FPALLET_ID = TPRG_TRK_BUF.FPALLET_ID(+) "
    '        strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XPROGRESS_OUT = " & XPROGRESS_OUT_JHIKIATE        '引当済み
    '        strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FTRK_BUF_NO IN(" & FTRK_BUF_NO_J8100 & ", " & _
    '                                                                     FTRK_BUF_NO_J8101 & ", " & _
    '                                                                     FTRK_BUF_NO_J8102 & ", " & _
    '                                                                     FTRK_BUF_NO_J8103 & ", " & _
    '                                                                     FTRK_BUF_NO_J8104 & ", " & _
    '                                                                     FTRK_BUF_NO_J8105 & ", " & _
    '                                                                     FTRK_BUF_NO_J8106 & ", " & _
    '                                                                     FTRK_BUF_NO_J8107 & ", " & _
    '                                                                     FTRK_BUF_NO_J8108 & ", " & _
    '                                                                     FTRK_BUF_NO_J8109 & ") "       '外部倉庫1-10
    '        strSQL &= vbCrLf & "     AND XPLN_OUT.XORDER_NO = '" & TO_STRING(grdList.Item(menmListCol.XORDER_NO, ii).Value) & "' "


    '        strSQL &= vbCrLf & "   UNION "
    '        strSQL &= vbCrLf & "    SELECT "
    '        strSQL &= vbCrLf & "         0        AS ASOUKO_CNT "
    '        strSQL &= vbCrLf & "       , 0        AS HIRA1_CNT "
    '        strSQL &= vbCrLf & "       , 0        AS BARA_CNT "
    '        strSQL &= vbCrLf & "       , 0        AS GAIBU_CNT "
    '        strSQL &= vbCrLf & "       , COUNT(0) AS GAIBU_ZUMI_CNT "
    '        strSQL &= vbCrLf & "       , 0        AS ASOUKO_TO_BARA_CNT "
    '        strSQL &= vbCrLf & "     FROM "
    '        strSQL &= vbCrLf & "         XPLN_OUT "
    '        strSQL &= vbCrLf & "       , XPLN_OUT_DTL "
    '        strSQL &= vbCrLf & "       , XRST_OUT "
    '        strSQL &= vbCrLf & "       , TPRG_TRK_BUF "
    '        strSQL &= vbCrLf & "     WHERE  1 = 1 "
    '        strSQL &= vbCrLf & "       AND XPLN_OUT.XSYUKKA_NO        = XPLN_OUT_DTL.XSYUKKA_NO(+) "
    '        strSQL &= vbCrLf & "       AND XPLN_OUT_DTL.XSYUKKA_NO    = XRST_OUT.XSYUKKA_NO(+) "
    '        strSQL &= vbCrLf & "       AND XPLN_OUT_DTL.XPLN_DTL_NO   = XRST_OUT.XPLN_DTL_NO(+) "
    '        'strSQL &= vbCrLf & "       AND XRST_OUT.FPALLET_ID        = TPRG_TRK_BUF.FPALLET_ID(+) "
    '        strSQL &= vbCrLf & "       AND XRST_OUT.XPALLET_ID_KARI   = TPRG_TRK_BUF.FPALLET_ID(+) "
    '        strSQL &= vbCrLf & "       AND XPLN_OUT_DTL.XPROGRESS_OUT = " & XPROGRESS_OUT_JGAIBU_SOUKO

    '        'strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FTRK_BUF_NO IN(" & FTRK_BUF_NO_J8100 & ", " & _
    '        strSQL &= vbCrLf & "     AND XRST_OUT.FTRK_BUF_NO IN(" & FTRK_BUF_NO_J8100 & ", " & _
    '                                                                     FTRK_BUF_NO_J8101 & ", " & _
    '                                                                     FTRK_BUF_NO_J8102 & ", " & _
    '                                                                     FTRK_BUF_NO_J8103 & ", " & _
    '                                                                     FTRK_BUF_NO_J8104 & ", " & _
    '                                                                     FTRK_BUF_NO_J8105 & ", " & _
    '                                                                     FTRK_BUF_NO_J8106 & ", " & _
    '                                                                     FTRK_BUF_NO_J8107 & ", " & _
    '                                                                     FTRK_BUF_NO_J8108 & ", " & _
    '                                                                     FTRK_BUF_NO_J8109 & ") "       '自動倉庫1-10
    '        strSQL &= vbCrLf & "     AND XPLN_OUT.XORDER_NO = '" & TO_STRING(grdList.Item(menmListCol.XORDER_NO, ii).Value) & "' "


    '        strSQL &= vbCrLf & "   UNION "
    '        strSQL &= vbCrLf & "   SELECT "
    '        strSQL &= vbCrLf & "       0        AS ASOUKO_CNT "
    '        strSQL &= vbCrLf & "     , 0        AS HIRA1_CNT "
    '        strSQL &= vbCrLf & "     , 0        AS BARA_CNT "
    '        strSQL &= vbCrLf & "     , 0        AS GAIBU_CNT "
    '        strSQL &= vbCrLf & "     , 0        AS GAIBU_ZUMI_CNT "
    '        strSQL &= vbCrLf & "     , COUNT(0) AS ASOUKO_TO_BARA_CNT "
    '        strSQL &= vbCrLf & "   FROM "
    '        strSQL &= vbCrLf & "       XPLN_OUT "
    '        strSQL &= vbCrLf & "     , XPLN_OUT_DTL "
    '        strSQL &= vbCrLf & "     , XSTS_HIKIATE_K1 "
    '        strSQL &= vbCrLf & "     , TPRG_TRK_BUF "
    '        strSQL &= vbCrLf & "   WHERE  1 = 1 "
    '        strSQL &= vbCrLf & "     AND XPLN_OUT.XSYUKKA_NO        = XPLN_OUT_DTL.XSYUKKA_NO(+) "
    '        strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.FPLAN_KEY     = XSTS_HIKIATE_K1.FPLAN_KEY(+) "
    '        strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K1.FPALLET_ID = TPRG_TRK_BUF.FPALLET_ID(+) "
    '        strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K1.FSAGYOU_KIND  = " & FSAGYOU_KIND_JOUT_BARA         'ﾊﾞﾗ補充
    '        strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XPROGRESS_OUT IN ( " & XPROGRESS_OUT_JHIKIATE & "," & XPROGRESS_OUT_JGAIBU_SOUKO & ") "   '引当済みまたは外部倉庫出荷中
    '        strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FTRK_BUF_NO   = " & FTRK_BUF_NO_J9000              '自動倉庫
    '        strSQL &= vbCrLf & "     AND XPLN_OUT.XORDER_NO = '" & TO_STRING(grdList.Item(menmListCol.XORDER_NO, ii).Value) & "' "


    '        strSQL &= vbCrLf & "   ) A"

    '        '-----------------------
    '        '抽出
    '        '-----------------------
    '        gobjDb.SQL = strSQL
    '        objDataSet.Clear()
    '        strDataSetName = "A"
    '        gobjDb.GetDataSet(strDataSetName, objDataSet)

    '        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
    '            '(見つかった場合)
    '            objRow = objDataSet.Tables(strDataSetName).Rows(0)
    '            intASOUKO_CNT = TO_INTEGER(objRow("ASOUKO_CNT"))                 '他品目出荷  出荷ﾊﾞｰｽ
    '            intHIRA1_CNT = TO_INTEGER(objRow("HIRA1_CNT"))                   '他品目出荷  平置き1
    '            intBARA_CNT = TO_INTEGER(objRow("BARA_CNT"))                     '他品目出荷  ﾊﾞﾗ平置き
    '            intGAIBU_CNT = TO_INTEGER(objRow("GAIBU_CNT"))                   '他品目出荷  外部倉庫
    '            intGAIBU_ZUMI_CNT = TO_INTEGER(objRow("GAIBU_ZUMI_CNT"))         '外部倉庫 積込み済み
    '            intASOUKO_TO_BARA_CNT = TO_INTEGER(objRow("ASOUKO_TO_BARA_CNT")) 'ﾊﾞﾗ補充中(自動倉庫→ﾊﾞﾗ平置き)
    '        Else
    '            '(見つからない場合)
    '            intASOUKO_CNT = 0                                                '他品目出荷  出荷ﾊﾞｰｽ
    '            intHIRA1_CNT = 0                                                 '他品目出荷  平置き1
    '            intBARA_CNT = 0                                                  '他品目出荷  ﾊﾞﾗ平置き
    '            intGAIBU_CNT = 0                                                 '他品目出荷  外部倉庫
    '            intGAIBU_ZUMI_CNT = 0                                            '外部倉庫 積込み済み
    '            intASOUKO_TO_BARA_CNT = 0                                        'ﾊﾞﾗ補充中(自動倉庫→ﾊﾞﾗ平置き)
    '        End If

    '        If intASOUKO_CNT > 0 Then
    '            '(出荷ﾊﾞｰｽに出荷ある時)
    '            If intASOUKO_CNT = intASOUKO_TO_BARA_CNT Then
    '                '(自動倉庫から出庫の在庫が、ﾊﾞﾗ補充分と同じ数の時[ﾊﾞﾗのみ])
    '                grdList.Item(menmListCol.XHIRA1, ii).Value = 1
    '                grdList.Item(menmListCol.XHIRA1_DSP, ii).Value = "○"

    '                '↓↓↓ 2012/11/08 17:00 ADD
    '                mstrXHIRA1 = "1"
    '                '↑↑↑ 2012/11/08 17:00 ADD

    '            Else
    '                '(以外の時)
    '                grdList.Item(menmListCol.XSYUKKA_BERTH, ii).Value = 1
    '                grdList.Item(menmListCol.XSYUKKA_BERTH_DSP, ii).Value = "○"

    '                '↓↓↓ 2012/11/08 17:00 ADD
    '                mstrXBERTH_SITEI = "1"
    '                '↑↑↑ 2012/11/08 17:00 ADD

    '            End If
    '        Else
    '            '(出荷ﾊﾞｰｽに出荷ない時)
    '            grdList.Item(menmListCol.XSYUKKA_BERTH, ii).Value = 0
    '            grdList.Item(menmListCol.XSYUKKA_BERTH_DSP, ii).Value = "　"
    '        End If

    '        If intHIRA1_CNT > 0 Then
    '            '(平置きに出荷ある時)
    '            grdList.Item(menmListCol.XHIRA1, ii).Value = 1
    '            grdList.Item(menmListCol.XHIRA1_DSP, ii).Value = "○"

    '            '↓↓↓ 2012/11/08 17:00 ADD
    '            mstrXHIRA1 = "1"
    '            '↑↑↑ 2012/11/08 17:00 ADD

    '        Else
    '            '(平置きに出荷ない時)
    '            If intASOUKO_CNT = intASOUKO_TO_BARA_CNT Then
    '                '(自動倉庫から出庫の在庫が、ﾊﾞﾗ補充分と同じ数の時[ﾊﾞﾗのみ])
    '                '平置きをｸﾘｱしない
    '            Else
    '                '(平置きｸﾘｱの時)
    '                grdList.Item(menmListCol.XHIRA1, ii).Value = 0
    '                grdList.Item(menmListCol.XHIRA1_DSP, ii).Value = "　"

    '                '↓↓↓ 2012/11/08 17:00 ADD
    '                mstrXHIRA1 = "0"
    '                '↑↑↑ 2012/11/08 17:00 ADD

    '            End If
    '        End If

    '        If (intASOUKO_CNT = 0) And _
    '           (intHIRA1_CNT = 0) Then
    '            '(出荷ﾊﾞｰｽと平置き１に出荷ない時)
    '            If intBARA_CNT > 0 Then
    '                '(バラ平置きに出荷ある時)
    '                grdList.Item(menmListCol.XHIRA1, ii).Value = 1
    '                grdList.Item(menmListCol.XHIRA1_DSP, ii).Value = "○"

    '                '↓↓↓ 2012/11/08 17:00 ADD
    '                mstrXHIRA1 = "1"
    '                '↑↑↑ 2012/11/08 17:00 ADD

    '            Else
    '                '(ﾊﾞﾗ平置きに出荷ない時)
    '                If intASOUKO_CNT = intASOUKO_TO_BARA_CNT Then
    '                    '(自動倉庫から出庫の在庫が、ﾊﾞﾗ補充分と同じ数の時[ﾊﾞﾗのみ])
    '                    '平置きをｸﾘｱしない
    '                Else
    '                    '(平置きｸﾘｱの時)
    '                    grdList.Item(menmListCol.XHIRA1, ii).Value = 0
    '                    grdList.Item(menmListCol.XHIRA1_DSP, ii).Value = "　"
    '                End If
    '            End If
    '        End If

    '        If intGAIBU_CNT > 0 Then
    '            '(外部倉庫に出荷ある時)
    '            grdList.Item(menmListCol.XGAIBU_SOUKO, ii).Value = 1
    '            grdList.Item(menmListCol.XGAIBU_SOUKO_DSP, ii).Value = "○"

    '            '↓↓↓ 2012/11/08 17:00 ADD
    '            mstrXGAIBU_SOUKO_SENKOU = "1"
    '            '↑↑↑ 2012/11/08 17:00 ADD

    '        Else
    '            '(外部倉庫に出荷ない時)
    '            If intGAIBU_ZUMI_CNT > 0 Then
    '                '(外部倉庫は積込み済みの時)
    '                grdList.Item(menmListCol.XGAIBU_SOUKO, ii).Value = 2
    '                grdList.Item(menmListCol.XGAIBU_SOUKO_DSP, ii).Value = "済"
    '            Else
    '                '(以外の時)
    '                grdList.Item(menmListCol.XGAIBU_SOUKO, ii).Value = 0
    '                grdList.Item(menmListCol.XGAIBU_SOUKO_DSP, ii).Value = "　"
    '            End If
    '        End If

    '    Next



    '    '↓↓↓ 2012/11/08 17:00 DEL
    '    '********************************************************
    '    ' ｺﾝﾎﾞ表示制御  ﾊﾞｰｽ指定、外部倉庫先行
    '    '********************************************************
    '    If (TO_INTEGER(mstrXBERTH_SITEI) = 0) Then
    '        '(ﾊﾞｰｽ出荷なしの時)
    '        lblXBERTH_SITEI.Visible = False            'ﾊﾞｰｽ指定ｺﾝﾎﾞ
    '        cboXBERTH_SITEI.Visible = False
    '        cboXBERTH_SITEI.Enabled = False
    '    Else
    '        '(ﾊﾞｰｽ出荷ありの時)
    '        lblXBERTH_SITEI.Visible = True             'ﾊﾞｰｽ指定ｺﾝﾎﾞ
    '        cboXBERTH_SITEI.Visible = True
    '        cboXBERTH_SITEI.Enabled = True
    '    End If

    '    If TO_INTEGER(mstrXGAIBU_SOUKO_SENKOU) = 1 Then
    '        '(構内と外部倉庫に出荷ありの時)
    '        lblGAIBU_SOUKO_FLAG.Visible = True
    '        cboXGAIBU_SOUKO_FLAG.Visible = True
    '        cboXGAIBU_SOUKO_FLAG.Enabled = True

    '        If (TO_INTEGER(mstrXBERTH_SITEI) = 0) And _
    '           (TO_INTEGER(mstrXHIRA1) = 0) Then
    '            '(ﾊﾞｰｽ出荷なし、平1出庫なしの時)
    '            cboXGAIBU_SOUKO_FLAG.SelectedIndex = 1      '外部倉庫先行
    '            lblGAIBU_SOUKO_FLAG.Visible = False
    '            cboXGAIBU_SOUKO_FLAG.Visible = False
    '            cboXGAIBU_SOUKO_FLAG.Enabled = False
    '        End If

    '    Else
    '        '(構内のみの時)
    '        lblGAIBU_SOUKO_FLAG.Visible = False
    '        cboXGAIBU_SOUKO_FLAG.Visible = False
    '        cboXGAIBU_SOUKO_FLAG.Enabled = False
    '    End If
    '    '↑↑↑ 2012/11/08 17:00 DEL



    'End Sub
#End Region
#Region "　出荷ﾊﾞｰｽ～外部倉庫「○」表示設定         "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub SET_TAHINMOK_DSP()

        '↓↓↓ 2012/11/08 17:00 ADD
        mstrXBERTH_SITEI = "0"
        '↑↑↑ 2012/11/08 17:00 ADD


        Dim strSQL As String


        Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名

        Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ

        Dim intASOUKO_CNT As Integer = 0           '他品目出荷  出荷ﾊﾞｰｽ
        Dim intHIRA1_CNT As Integer = 0            '他品目出荷  平置き1
        Dim intBARA_CNT As Integer = 0             '他品目出荷  ﾊﾞﾗ平置き
        Dim intGAIBU_CNT As Integer = 0            '他品目出荷  外部倉庫
        Dim intGAIBU_ZUMI_CNT As Integer = 0       '外部倉庫 積込み済
        'Dim intGAIBU_NONZUMI_CNT As Integer = 0    '外部倉庫 積込み済以外
        Dim intASOUKO_TO_BARA_CNT As Integer = 0   'ﾊﾞﾗ補充中(出荷ﾊﾞｰｽ→ﾊﾞﾗ平置き)


        For ii As Integer = 0 To grdList.RowCount - 1
            '(ｸﾞﾘｯﾄﾞの行数分繰り返し)

            '-----------------------
            '抽出SQL作成
            '-----------------------
            strSQL = ""
            strSQL &= vbCrLf & " SELECT "
            strSQL &= vbCrLf & "     SUM(ASOUKO_CNT) AS ASOUKO_CNT "
            strSQL &= vbCrLf & "   , SUM(HIRA1_CNT)  AS HIRA1_CNT "
            strSQL &= vbCrLf & "   , SUM(BARA_CNT)  AS BARA_CNT "
            strSQL &= vbCrLf & "   , SUM(GAIBU_CNT)  AS GAIBU_CNT "
            strSQL &= vbCrLf & "   , SUM(GAIBU_ZUMI_CNT)  AS GAIBU_ZUMI_CNT "
            strSQL &= vbCrLf & "   , SUM(ASOUKO_TO_BARA_CNT) AS ASOUKO_TO_BARA_CNT "
            strSQL &= vbCrLf & " FROM "
            strSQL &= vbCrLf & "   ( "
            strSQL &= vbCrLf & "   SELECT "
            strSQL &= vbCrLf & "       COUNT(0) AS ASOUKO_CNT "
            strSQL &= vbCrLf & "     , 0        AS HIRA1_CNT "
            strSQL &= vbCrLf & "     , 0        AS BARA_CNT "
            strSQL &= vbCrLf & "     , 0        AS GAIBU_CNT "
            strSQL &= vbCrLf & "     , 0        AS GAIBU_ZUMI_CNT "
            strSQL &= vbCrLf & "     , 0        AS ASOUKO_TO_BARA_CNT "
            strSQL &= vbCrLf & "   FROM "
            strSQL &= vbCrLf & "       XPLN_OUT "
            strSQL &= vbCrLf & "     , XPLN_OUT_DTL "
            strSQL &= vbCrLf & "     , XSTS_HIKIATE_K1 "
            '*2012.11.14* strSQL &= vbCrLf & "     , TPRG_TRK_BUF "
            strSQL &= vbCrLf & "   WHERE  1 = 1 "
            strSQL &= vbCrLf & "     AND XPLN_OUT.XSYUKKA_NO        = XPLN_OUT_DTL.XSYUKKA_NO(+) "
            strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.FPLAN_KEY     = XSTS_HIKIATE_K1.FPLAN_KEY(+) "
            '*2012.11.14* strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K1.FPALLET_ID = TPRG_TRK_BUF.FPALLET_ID(+) "
            strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XPROGRESS_OUT IN ( " & XPROGRESS_OUT_JHIKIATE & "," & XPROGRESS_OUT_JGAIBU_SOUKO & ") "   '引当済みまたは外部倉庫出荷中
            '*2012.11.14* strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FTRK_BUF_NO   = " & FTRK_BUF_NO_J9000              '自動倉庫
            strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K1.FTRK_BUF_NO   = " & FTRK_BUF_NO_J9000            '*2012.11.14* 自動倉庫
            strSQL &= vbCrLf & "     AND XPLN_OUT.XORDER_NO = '" & TO_STRING(grdList.Item(menmListCol.XORDER_NO, ii).Value) & "' "


            strSQL &= vbCrLf & "   UNION "
            strSQL &= vbCrLf & "   SELECT "
            strSQL &= vbCrLf & "       0        AS ASOUKO_CNT "
            strSQL &= vbCrLf & "     , COUNT(0) AS HIRA1_CNT "
            strSQL &= vbCrLf & "     , 0        AS BARA_CNT "
            strSQL &= vbCrLf & "     , 0        AS GAIBU_CNT "
            strSQL &= vbCrLf & "     , 0        AS GAIBU_ZUMI_CNT "
            strSQL &= vbCrLf & "     , 0        AS ASOUKO_TO_BARA_CNT "
            strSQL &= vbCrLf & "   FROM "
            strSQL &= vbCrLf & "       XPLN_OUT "
            strSQL &= vbCrLf & "     , XPLN_OUT_DTL "
            strSQL &= vbCrLf & "     , XSTS_HIKIATE_K1 "
            '*2012.11.14* strSQL &= vbCrLf & "     , TPRG_TRK_BUF "
            strSQL &= vbCrLf & "   WHERE  1 = 1 "
            strSQL &= vbCrLf & "     AND XPLN_OUT.XSYUKKA_NO        = XPLN_OUT_DTL.XSYUKKA_NO(+) "
            strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.FPLAN_KEY     = XSTS_HIKIATE_K1.FPLAN_KEY(+) "
            '*2012.11.14* strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K1.FPALLET_ID = TPRG_TRK_BUF.FPALLET_ID(+) "
            'strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XPROGRESS_OUT = " & XPROGRESS_OUT_JHIKIATE        '引当済み
            strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XPROGRESS_OUT IN ( " & XPROGRESS_OUT_JHIKIATE & "," & XPROGRESS_OUT_JGAIBU_SOUKO & ") "   '引当済みまたは外部倉庫出荷中
            '*2012.11.14* strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FTRK_BUF_NO   = " & FTRK_BUF_NO_J8001             '平置き1
            strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K1.FTRK_BUF_NO   = " & FTRK_BUF_NO_J8001           '*2012.11.14* 平置き1
            strSQL &= vbCrLf & "     AND XPLN_OUT.XORDER_NO = '" & TO_STRING(grdList.Item(menmListCol.XORDER_NO, ii).Value) & "' "


            strSQL &= vbCrLf & "   UNION "
            strSQL &= vbCrLf & "   SELECT "
            strSQL &= vbCrLf & "       0        AS ASOUKO_CNT "
            strSQL &= vbCrLf & "     , 0        AS HIRA1_CNT "
            strSQL &= vbCrLf & "     , COUNT(0) AS BARA_CNT "
            strSQL &= vbCrLf & "     , 0        AS GAIBU_CNT "
            strSQL &= vbCrLf & "     , 0        AS GAIBU_ZUMI_CNT "
            strSQL &= vbCrLf & "     , 0        AS ASOUKO_TO_BARA_CNT "
            strSQL &= vbCrLf & "   FROM "
            strSQL &= vbCrLf & "       XPLN_OUT "
            strSQL &= vbCrLf & "     , XPLN_OUT_DTL "
            strSQL &= vbCrLf & "     , XSTS_HIKIATE_K1 "
            '*2012.11.14* strSQL &= vbCrLf & "     , TPRG_TRK_BUF "
            strSQL &= vbCrLf & "   WHERE  1 = 1 "
            strSQL &= vbCrLf & "     AND XPLN_OUT.XSYUKKA_NO        = XPLN_OUT_DTL.XSYUKKA_NO(+) "
            strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.FPLAN_KEY     = XSTS_HIKIATE_K1.FPLAN_KEY(+) "
            '*2012.11.14* strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K1.FPALLET_ID = TPRG_TRK_BUF.FPALLET_ID(+) "
            'strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XPROGRESS_OUT = " & XPROGRESS_OUT_JHIKIATE        '引当済み
            strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XPROGRESS_OUT IN ( " & XPROGRESS_OUT_JHIKIATE & "," & XPROGRESS_OUT_JGAIBU_SOUKO & ") "   '引当済みまたは外部倉庫出荷中
            '*2012.11.14* strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FTRK_BUF_NO   = " & FTRK_BUF_NO_J8000             'ﾊﾞﾗ平置き
            strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K1.FTRK_BUF_NO   = " & FTRK_BUF_NO_J8000           '*2012.11.14* ﾊﾞﾗ平置き
            strSQL &= vbCrLf & "     AND XPLN_OUT.XORDER_NO = '" & TO_STRING(grdList.Item(menmListCol.XORDER_NO, ii).Value) & "' "


            strSQL &= vbCrLf & "   UNION "
            strSQL &= vbCrLf & "   SELECT "
            strSQL &= vbCrLf & "       0        AS ASOUKO_CNT "
            strSQL &= vbCrLf & "     , 0        AS HIRA1_CNT "
            strSQL &= vbCrLf & "     , 0        AS BARA_CNT "
            strSQL &= vbCrLf & "     , COUNT(0) AS GAIBU_CNT "
            strSQL &= vbCrLf & "     , 0        AS GAIBU_ZUMI_CNT "
            strSQL &= vbCrLf & "     , 0        AS ASOUKO_TO_BARA_CNT "
            strSQL &= vbCrLf & "   FROM "
            strSQL &= vbCrLf & "       XPLN_OUT "
            strSQL &= vbCrLf & "     , XPLN_OUT_DTL "
            strSQL &= vbCrLf & "     , XSTS_HIKIATE_K1 "
            '*2012.11.14* strSQL &= vbCrLf & "     , TPRG_TRK_BUF "
            strSQL &= vbCrLf & "   WHERE  1 = 1 "
            strSQL &= vbCrLf & "     AND XPLN_OUT.XSYUKKA_NO        = XPLN_OUT_DTL.XSYUKKA_NO(+) "
            strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.FPLAN_KEY     = XSTS_HIKIATE_K1.FPLAN_KEY(+) "
            '*2012.11.14* strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K1.FPALLET_ID = TPRG_TRK_BUF.FPALLET_ID(+) "
            strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XPROGRESS_OUT = " & XPROGRESS_OUT_JHIKIATE        '引当済み
            '*2012.11.14* strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FTRK_BUF_NO IN(" & FTRK_BUF_NO_J8100 & ", " & _
            strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K1.FTRK_BUF_NO IN(" & FTRK_BUF_NO_J8100 & ", " & _
                                                                         FTRK_BUF_NO_J8101 & ", " & _
                                                                         FTRK_BUF_NO_J8102 & ", " & _
                                                                         FTRK_BUF_NO_J8103 & ", " & _
                                                                         FTRK_BUF_NO_J8104 & ", " & _
                                                                         FTRK_BUF_NO_J8105 & ", " & _
                                                                         FTRK_BUF_NO_J8106 & ", " & _
                                                                         FTRK_BUF_NO_J8107 & ", " & _
                                                                         FTRK_BUF_NO_J8108 & ", " & _
                                                                         FTRK_BUF_NO_J8109 & ") "       '*2012.11.14* 外部倉庫1-10
            strSQL &= vbCrLf & "     AND XPLN_OUT.XORDER_NO = '" & TO_STRING(grdList.Item(menmListCol.XORDER_NO, ii).Value) & "' "


            strSQL &= vbCrLf & "   UNION "
            strSQL &= vbCrLf & "    SELECT "
            strSQL &= vbCrLf & "         0        AS ASOUKO_CNT "
            strSQL &= vbCrLf & "       , 0        AS HIRA1_CNT "
            strSQL &= vbCrLf & "       , 0        AS BARA_CNT "
            strSQL &= vbCrLf & "       , 0        AS GAIBU_CNT "
            strSQL &= vbCrLf & "       , COUNT(0) AS GAIBU_ZUMI_CNT "
            strSQL &= vbCrLf & "       , 0        AS ASOUKO_TO_BARA_CNT "
            strSQL &= vbCrLf & "     FROM "
            strSQL &= vbCrLf & "         XPLN_OUT "
            strSQL &= vbCrLf & "       , XPLN_OUT_DTL "
            strSQL &= vbCrLf & "       , XRST_OUT "
            '*2012.11.14* strSQL &= vbCrLf & "       , TPRG_TRK_BUF "
            strSQL &= vbCrLf & "     WHERE  1 = 1 "
            strSQL &= vbCrLf & "       AND XPLN_OUT.XSYUKKA_NO        = XPLN_OUT_DTL.XSYUKKA_NO(+) "
            strSQL &= vbCrLf & "       AND XPLN_OUT_DTL.XSYUKKA_NO    = XRST_OUT.XSYUKKA_NO(+) "
            strSQL &= vbCrLf & "       AND XPLN_OUT_DTL.XPLN_DTL_NO   = XRST_OUT.XPLN_DTL_NO(+) "
            'strSQL &= vbCrLf & "       AND XRST_OUT.FPALLET_ID        = TPRG_TRK_BUF.FPALLET_ID(+) "
            '*2012.11.14* strSQL &= vbCrLf & "       AND XRST_OUT.XPALLET_ID_KARI   = TPRG_TRK_BUF.FPALLET_ID(+) "
            strSQL &= vbCrLf & "       AND XPLN_OUT_DTL.XPROGRESS_OUT = " & XPROGRESS_OUT_JGAIBU_SOUKO

            'strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FTRK_BUF_NO IN(" & FTRK_BUF_NO_J8100 & ", " & _
            strSQL &= vbCrLf & "     AND XRST_OUT.FTRK_BUF_NO IN(" & FTRK_BUF_NO_J8100 & ", " & _
                                                                         FTRK_BUF_NO_J8101 & ", " & _
                                                                         FTRK_BUF_NO_J8102 & ", " & _
                                                                         FTRK_BUF_NO_J8103 & ", " & _
                                                                         FTRK_BUF_NO_J8104 & ", " & _
                                                                         FTRK_BUF_NO_J8105 & ", " & _
                                                                         FTRK_BUF_NO_J8106 & ", " & _
                                                                         FTRK_BUF_NO_J8107 & ", " & _
                                                                         FTRK_BUF_NO_J8108 & ", " & _
                                                                         FTRK_BUF_NO_J8109 & ") "       '自動倉庫1-10
            strSQL &= vbCrLf & "     AND XPLN_OUT.XORDER_NO = '" & TO_STRING(grdList.Item(menmListCol.XORDER_NO, ii).Value) & "' "


            strSQL &= vbCrLf & "   UNION "
            strSQL &= vbCrLf & "   SELECT "
            strSQL &= vbCrLf & "       0        AS ASOUKO_CNT "
            strSQL &= vbCrLf & "     , 0        AS HIRA1_CNT "
            strSQL &= vbCrLf & "     , 0        AS BARA_CNT "
            strSQL &= vbCrLf & "     , 0        AS GAIBU_CNT "
            strSQL &= vbCrLf & "     , 0        AS GAIBU_ZUMI_CNT "
            strSQL &= vbCrLf & "     , COUNT(0) AS ASOUKO_TO_BARA_CNT "
            strSQL &= vbCrLf & "   FROM "
            strSQL &= vbCrLf & "       XPLN_OUT "
            strSQL &= vbCrLf & "     , XPLN_OUT_DTL "
            strSQL &= vbCrLf & "     , XSTS_HIKIATE_K1 "
            '*2012.11.14* strSQL &= vbCrLf & "     , TPRG_TRK_BUF "
            strSQL &= vbCrLf & "   WHERE  1 = 1 "
            strSQL &= vbCrLf & "     AND XPLN_OUT.XSYUKKA_NO        = XPLN_OUT_DTL.XSYUKKA_NO(+) "
            strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.FPLAN_KEY     = XSTS_HIKIATE_K1.FPLAN_KEY(+) "
            '*2012.11.14* strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K1.FPALLET_ID = TPRG_TRK_BUF.FPALLET_ID(+) "
            strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K1.FSAGYOU_KIND  = " & FSAGYOU_KIND_JOUT_BARA         'ﾊﾞﾗ補充
            strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XPROGRESS_OUT IN ( " & XPROGRESS_OUT_JHIKIATE & "," & XPROGRESS_OUT_JGAIBU_SOUKO & ") "   '引当済みまたは外部倉庫出荷中
            '*2012.11.14* strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FTRK_BUF_NO   = " & FTRK_BUF_NO_J9000              '自動倉庫
            strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K1.FTRK_BUF_NO   = " & FTRK_BUF_NO_J9000            '*2012.11.14* 自動倉庫
            strSQL &= vbCrLf & "     AND XPLN_OUT.XORDER_NO = '" & TO_STRING(grdList.Item(menmListCol.XORDER_NO, ii).Value) & "' "


            strSQL &= vbCrLf & "   ) A"

            '-----------------------
            '抽出
            '-----------------------
            gobjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "A"
            gobjDb.GetDataSet(strDataSetName, objDataSet)

            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                '(見つかった場合)
                objRow = objDataSet.Tables(strDataSetName).Rows(0)
                intASOUKO_CNT = TO_INTEGER(objRow("ASOUKO_CNT"))                 '他品目出荷  出荷ﾊﾞｰｽ
                intHIRA1_CNT = TO_INTEGER(objRow("HIRA1_CNT"))                   '他品目出荷  平置き1
                intBARA_CNT = TO_INTEGER(objRow("BARA_CNT"))                     '他品目出荷  ﾊﾞﾗ平置き
                intGAIBU_CNT = TO_INTEGER(objRow("GAIBU_CNT"))                   '他品目出荷  外部倉庫
                intGAIBU_ZUMI_CNT = TO_INTEGER(objRow("GAIBU_ZUMI_CNT"))         '外部倉庫 積込み済み
                intASOUKO_TO_BARA_CNT = TO_INTEGER(objRow("ASOUKO_TO_BARA_CNT")) 'ﾊﾞﾗ補充中(自動倉庫→ﾊﾞﾗ平置き)
            Else
                '(見つからない場合)
                intASOUKO_CNT = 0                                                '他品目出荷  出荷ﾊﾞｰｽ
                intHIRA1_CNT = 0                                                 '他品目出荷  平置き1
                intBARA_CNT = 0                                                  '他品目出荷  ﾊﾞﾗ平置き
                intGAIBU_CNT = 0                                                 '他品目出荷  外部倉庫
                intGAIBU_ZUMI_CNT = 0                                            '外部倉庫 積込み済み
                intASOUKO_TO_BARA_CNT = 0                                        'ﾊﾞﾗ補充中(自動倉庫→ﾊﾞﾗ平置き)
            End If

            If intASOUKO_CNT > 0 Then
                '(出荷ﾊﾞｰｽに出荷ある時)
                If intASOUKO_CNT = intASOUKO_TO_BARA_CNT Then
                    '(自動倉庫から出庫の在庫が、ﾊﾞﾗ補充分と同じ数の時[ﾊﾞﾗのみ])
                    '↓↓↓↓ 2012.12.03 11:30 H.Morita ﾊﾞﾗ平「○」表示対応
                    'grdList.Item(menmListCol.XHIRA1, ii).Value = 1
                    'grdList.Item(menmListCol.XHIRA1_DSP, ii).Value = "○"
                    grdList.Item(menmListCol.XBARA, ii).Value = 1
                    grdList.Item(menmListCol.XBARA_DSP, ii).Value = "○"
                    '↑↑↑↑ 2012.12.03 11:30 H.Morita ﾊﾞﾗ平「○」表示対応

                    '↓↓↓ 2012/11/08 17:00 ADD
                    mstrXHIRA1 = "1"
                    '↑↑↑ 2012/11/08 17:00 ADD

                Else
                    '(以外の時)
                    grdList.Item(menmListCol.XSYUKKA_BERTH, ii).Value = 1
                    grdList.Item(menmListCol.XSYUKKA_BERTH_DSP, ii).Value = "○"

                    '↓↓↓ 2012/11/08 17:00 ADD
                    mstrXBERTH_SITEI = "1"
                    '↑↑↑ 2012/11/08 17:00 ADD

                End If
            Else
                '(出荷ﾊﾞｰｽに出荷ない時)
                grdList.Item(menmListCol.XSYUKKA_BERTH, ii).Value = 0
                grdList.Item(menmListCol.XSYUKKA_BERTH_DSP, ii).Value = "　"
            End If

            If intHIRA1_CNT > 0 Then
                '(平置きに出荷ある時)
                grdList.Item(menmListCol.XHIRA1, ii).Value = 1
                grdList.Item(menmListCol.XHIRA1_DSP, ii).Value = "○"

                '↓↓↓ 2012/11/08 17:00 ADD
                mstrXHIRA1 = "1"
                '↑↑↑ 2012/11/08 17:00 ADD

            Else
                '(平置きに出荷ない時)
                '↓↓↓↓ 2012.12.03 11:30 H.Morita ﾊﾞﾗ平「○」表示対応
                'If intASOUKO_CNT = intASOUKO_TO_BARA_CNT Then
                '    '(自動倉庫から出庫の在庫が、ﾊﾞﾗ補充分と同じ数の時[ﾊﾞﾗのみ])
                '    '平置きをｸﾘｱしない
                'Else
                '    '(平置きｸﾘｱの時)
                grdList.Item(menmListCol.XHIRA1, ii).Value = 0
                grdList.Item(menmListCol.XHIRA1_DSP, ii).Value = "　"

                ''↓↓↓ 2012/11/08 17:00 ADD
                'mstrXHIRA1 = "0"
                ''↑↑↑ 2012/11/08 17:00 ADD

                'End If
                '↑↑↑↑ 2012.12.03 11:30 H.Morita ﾊﾞﾗ平「○」表示対応
            End If

            '↓↓↓↓ 2012.12.03 11:30 H.Morita ﾊﾞﾗ平「○」表示対応
            'If (intASOUKO_CNT = 0) And _
            '   (intHIRA1_CNT = 0) Then
            '    '(出荷ﾊﾞｰｽと平置き１に出荷ない時)
            If intBARA_CNT > 0 Then
                '(バラ平置きに出荷ある時)
                'grdList.Item(menmListCol.XHIRA1, ii).Value = 1
                'grdList.Item(menmListCol.XHIRA1_DSP, ii).Value = "○"
                grdList.Item(menmListCol.XBARA, ii).Value = 1
                grdList.Item(menmListCol.XBARA_DSP, ii).Value = "○"

                '↓↓↓ 2012/11/08 17:00 ADD
                mstrXHIRA1 = "1"
                '↑↑↑ 2012/11/08 17:00 ADD

            Else
                '(ﾊﾞﾗ平置きに出荷ない時)
                If intASOUKO_CNT = intASOUKO_TO_BARA_CNT Then
                    '(自動倉庫から出庫の在庫が、ﾊﾞﾗ補充分と同じ数の時[ﾊﾞﾗのみ])
                    '平置きをｸﾘｱしない
                Else
                    '(平置きｸﾘｱの時)
                    'grdList.Item(menmListCol.XHIRA1, ii).Value = 0
                    'grdList.Item(menmListCol.XHIRA1_DSP, ii).Value = "　"
                    grdList.Item(menmListCol.XBARA, ii).Value = 0
                    grdList.Item(menmListCol.XBARA_DSP, ii).Value = "　"
                End If
            End If
            'End If
            '↑↑↑↑ 2012.12.03 11:30 H.Morita ﾊﾞﾗ平「○」表示対応

            If intGAIBU_CNT > 0 Then
                '(外部倉庫に出荷ある時)
                grdList.Item(menmListCol.XGAIBU_SOUKO, ii).Value = 1
                grdList.Item(menmListCol.XGAIBU_SOUKO_DSP, ii).Value = "○"

                '↓↓↓ 2012/11/08 17:00 ADD
                mstrXGAIBU_SOUKO_SENKOU = "1"
                '↑↑↑ 2012/11/08 17:00 ADD

            Else
                '(外部倉庫に出荷ない時)
                If intGAIBU_ZUMI_CNT > 0 Then
                    '(外部倉庫は積込み済みの時)
                    grdList.Item(menmListCol.XGAIBU_SOUKO, ii).Value = 2
                    grdList.Item(menmListCol.XGAIBU_SOUKO_DSP, ii).Value = "済"
                Else
                    '(以外の時)
                    grdList.Item(menmListCol.XGAIBU_SOUKO, ii).Value = 0
                    grdList.Item(menmListCol.XGAIBU_SOUKO_DSP, ii).Value = "　"
                End If
            End If

        Next



        '↓↓↓ 2012/11/08 17:00 ADD
        '********************************************************
        ' ｺﾝﾎﾞ表示制御  ﾊﾞｰｽ指定、外部倉庫先行
        '********************************************************
        If (TO_INTEGER(mstrXBERTH_SITEI) = 0) Then
            '(ﾊﾞｰｽ出荷なしの時)
            lblXBERTH_SITEI.Visible = False            'ﾊﾞｰｽ指定ｺﾝﾎﾞ
            cboXBERTH_SITEI.Visible = False
            cboXBERTH_SITEI.Enabled = False
        Else
            '(ﾊﾞｰｽ出荷ありの時)
            lblXBERTH_SITEI.Visible = True             'ﾊﾞｰｽ指定ｺﾝﾎﾞ
            cboXBERTH_SITEI.Visible = True
            cboXBERTH_SITEI.Enabled = True
        End If

        If TO_INTEGER(mstrXGAIBU_SOUKO_SENKOU) = 1 Then
            '(構内と外部倉庫に出荷ありの時)
            lblGAIBU_SOUKO_FLAG.Visible = True
            cboXGAIBU_SOUKO_FLAG.Visible = True
            cboXGAIBU_SOUKO_FLAG.Enabled = True

            If (TO_INTEGER(mstrXBERTH_SITEI) = 0) And _
               (TO_INTEGER(mstrXHIRA1) = 0) Then
                '(ﾊﾞｰｽ出荷なし、平1出庫なしの時)
                cboXGAIBU_SOUKO_FLAG.SelectedIndex = 1      '外部倉庫先行
                lblGAIBU_SOUKO_FLAG.Visible = False
                cboXGAIBU_SOUKO_FLAG.Visible = False
                cboXGAIBU_SOUKO_FLAG.Enabled = False
            End If

        Else
            '(構内のみの時)
            lblGAIBU_SOUKO_FLAG.Visible = False
            cboXGAIBU_SOUKO_FLAG.Visible = False
            cboXGAIBU_SOUKO_FLAG.Enabled = False
        End If
        '↑↑↑ 2012/11/08 17:00 ADD



    End Sub
#End Region

#Region "　受付車番、受付車番枝番 表示設定          "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub SET_CAR_NO_DSP()

        For ii As Integer = 0 To grdList.RowCount - 1
            '(ｸﾞﾘｯﾄﾞの行数分繰り返し)
            For jj As Integer = LBound(mstrXORDER_NO) To UBound(mstrXORDER_NO)
                '(ﾙｰﾌﾟ:登録する受注№)
                If mstrXORDER_NO(jj) = TO_STRING(grdList.Item(menmListCol.XORDER_NO, ii).Value) Then
                    grdList.Item(menmListCol.XCAR_NO_WARITUKE, ii).Value = mstrXCAR_NO_TOUROKU(jj)
                    grdList.Item(menmListCol.XCAR_NO_EDA_WARITUKE, ii).Value = mstrXCAR_NO_EDA_TOUROKU(jj)
                End If
            Next
        Next

    End Sub
#End Region


#Region "  ｿｹｯﾄ送信02                             　"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Function SendSocket02(ByVal intXDSPBERTH_WARITUKE_FLAG As Integer) As Boolean

        Dim blnReturn As Boolean = False

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        udtRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308041_03, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Return blnReturn
        End If


        '********************************************************************
        '日付文字列作成
        '********************************************************************
        mstrXDSPUKETUKE_DT = Format(Now, "yyyy/MM/dd HH:mm:ss")

        Dim strXDSPGAIBU_SOUKO_FLAG As String = TO_STRING(cboXGAIBU_SOUKO_FLAG.SelectedValue)    '外部倉庫先行ﾌﾗｸﾞ
        Dim strXDSPBERTH_SITEI As String = TO_STRING(cboXBERTH_SITEI.SelectedValue)              'ﾊﾞｰｽ指定


        '*******************************************************
        ' ﾊﾞｰｽ待ち情報ﾃｰﾌﾞﾙの割付ﾌﾗｸﾞ        取得
        '*******************************************************
        Dim strXDSPWARITUKE_BERTH As String = XWARITUKE_BERTH_JNOTHING      '割付_ﾊﾞｰｽ
        Dim strXDSPWARITUKE_HIRA01 As String = XWARITUKE_BERTH_JNOTHING     '割付_1F平置き
        Dim strXDSPWARITUKE_BARA As String = XWARITUKE_BERTH_JNOTHING       '割付_ﾊﾞﾗ平置き
        Dim strXDSPWARITUKE_GAIBU As String = XWARITUKE_BERTH_JNOTHING      '割付_外部倉庫
        Call GetWarituke(mstrXORDER_NO _
                       , strXDSPWARITUKE_BERTH _
                       , strXDSPWARITUKE_HIRA01 _
                       , strXDSPWARITUKE_BARA _
                       , strXDSPWARITUKE_GAIBU _
                       )
        If strXDSPGAIBU_SOUKO_FLAG = XGAIBU_SOUKO_FLAG_JON Then
            '(外部倉庫先行の場合)
            strXDSPWARITUKE_BERTH = XWARITUKE_BERTH_JNOTHING      '割付_ﾊﾞｰｽ
            strXDSPWARITUKE_HIRA01 = XWARITUKE_BERTH_JNOTHING     '割付_1F平置き
            strXDSPWARITUKE_BARA = XWARITUKE_BERTH_JNOTHING       '割付_ﾊﾞﾗ平置き
        Else
            '(外部倉庫先行じゃない場合)
            strXDSPWARITUKE_GAIBU = XWARITUKE_BERTH_JNOTHING      '割付_外部倉庫
        End If


        '*******************************************************
        'ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙに追加する電文配列作成
        '*******************************************************
        Dim strSendTel() As String = Nothing



        For ii As Integer = LBound(mstrXORDER_NO) To UBound(mstrXORDER_NO)
            '(展開元画面の行分ﾙｰﾌﾟ)

            If IsNull(strSendTel) = True Then ReDim Preserve strSendTel(0) Else ReDim Preserve strSendTel(UBound(strSendTel) + 1)

            '*******************************************************
            ' 電文作成
            '*******************************************************
            '========================================
            ' 変数宣言
            '========================================
            Dim objTelegramSub As New clsTelegram(CONFIG_TELEGRAM_DSP)
            Dim strXDSPORDER_NO As String = ""               '受注№
            Dim strXDSPCAR_NO As String = ""                 '受付車番
            Dim strXDSPCAR_NO_EDA As String = ""             '受付車番枝番
            Dim strXDSPBERTH_WARITUKE_FLAG As String = ""    'ﾊﾞｰｽ割付可能ﾌﾗｸﾞ


            objTelegramSub.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400701       'ﾌｫｰﾏｯﾄ名ｾｯﾄ

            Dim strDSPCMD_ID As String = ""
            strDSPCMD_ID = objTelegramSub.FORMAT_ID.Substring(objTelegramSub.FORMAT_ID.Length - 6, 6)
            'ﾍｯﾀﾞﾃﾞｰﾀ
            objTelegramSub.SETIN_HEADER("DSPCMD_ID", strDSPCMD_ID)              'ｺﾏﾝﾄﾞID
            objTelegramSub.SETIN_HEADER("DSPTERM_ID", gcstrFTERM_ID)            '端末ID
            objTelegramSub.SETIN_HEADER("DSPUSER_ID", gcstrFUSER_ID)            'ﾕｰｻﾞID

            'ﾃﾞｰﾀ
            strXDSPORDER_NO = mstrXORDER_NO(ii)                                 '受注№
            strXDSPCAR_NO = mstrXCAR_NO_TOUROKU(ii)                             '受付車番
            strXDSPCAR_NO_EDA = mstrXCAR_NO_EDA_TOUROKU(ii)                     '受付車番枝番

            'If ii = UBound(mstrXORDER_NO) Then
            '    '(最後のﾙｰﾌﾟの時)
            strXDSPBERTH_WARITUKE_FLAG = "1"                                    'ﾊﾞｰｽ割付可能ﾌﾗｸﾞ
            'Else
            '    '(以外の時)
            '    strXDSPBERTH_WARITUKE_FLAG = "0"                               'ﾊﾞｰｽ割付可能ﾌﾗｸﾞ
            'End If

            objTelegramSub.SETIN_DATA("XDSPORDER_NO", strXDSPORDER_NO)                         '受注№
            objTelegramSub.SETIN_DATA("XDSPCAR_NO", strXDSPCAR_NO)                             '受付車番
            objTelegramSub.SETIN_DATA("XDSPCAR_NO_EDA", strXDSPCAR_NO_EDA)                     '受付車番枝番
            objTelegramSub.SETIN_DATA("XDSPBERTH_WARITUKE_FLAG", strXDSPBERTH_WARITUKE_FLAG)   'ﾊﾞｰｽ割付可能ﾌﾗｸﾞ

            objTelegramSub.MAKE_TELEGRAM()

            strSendTel(UBound(strSendTel)) = objTelegramSub.TELEGRAM_MAKED

        Next


        '*******************************************************
        ' 電文作成
        '*******************************************************
        '========================================
        ' 変数宣言
        '========================================
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
        Dim strPARA_ID As String = ""

        'Dim strXDSPCAR_NO As String = ""                   '車番
        'Dim strXDSPCAR_NO_EDA As String = ""               '車番枝番
        Dim strXDSPCAR_NO_DAIHYOU As String = ""           '代表車番
        Dim strXDSPCAR_NO_EDA_DAIHYOU As String = ""       '代表車番枝番
        'Dim strXDSPBERTH_WARITUKE_FLAG As String = ""      'ﾊﾞｰｽ割付可能ﾌﾗｸﾞ

        'strXDSPCAR_NO = mstrXCAR_NO_WARITUKE               '車番
        'strXDSPCAR_NO_EDA = mstrXCAR_NO_EDA_WARITUKE       '車番枝番
        'strXDSPCAR_NO_EDA = txtXCAR_NO_EDA_WARITUKE.Text   '車番枝番

        'If cboXDSPCAR_NO_DAIHYOU.SelectedIndex = 0 Then
        ''(代表車番選択が全選択の時)
        strXDSPCAR_NO_DAIHYOU = mstrXCAR_NO_WARITUKE                                  '代表車番
        strXDSPCAR_NO_EDA_DAIHYOU = mstrXCAR_NO_EDA_WARITUKE                          '代表車番枝番
        'Else
        '    '(代表車番選択が選択時)
        '    Dim intHF As Integer = cboXDSPCAR_NO_DAIHYOU.Text.LastIndexOf("-")
        '    strXDSPCAR_NO_DAIHYOU = Mid(cboXDSPCAR_NO_DAIHYOU.Text, 1, intHF)             '代表車番
        '    strXDSPCAR_NO_EDA_DAIHYOU = cboXDSPCAR_NO_DAIHYOU.Text.Substring(intHF + 1)   '代表車番枝番
        'End If

        'strXDSPBERTH_WARITUKE_FLAG = intXDSPBERTH_WARITUKE_FLAG.ToString                            'ﾊﾞｰｽ割付可能ﾌﾗｸﾞ


        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400701       'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        objTelegram.SETIN_DATA("DSPDIR_KUBUN", FORMAT_DSP_DSPDIR_KUBUN_INSERT)          '処理区分
        'objTelegram.SETIN_DATA("XDSPCAR_NO", strXDSPCAR_NO)                             '車番
        'objTelegram.SETIN_DATA("XDSPCAR_NO_EDA", strXDSPCAR_NO_EDA)                     '車番枝番
        objTelegram.SETIN_DATA("XDSPUKETUKE_DT", mstrXDSPUKETUKE_DT)                    '受付時間
        objTelegram.SETIN_DATA("XDSPGAIBU_SOUKO_FLAG", strXDSPGAIBU_SOUKO_FLAG)         '外部倉庫先行ﾌﾗｸﾞ
        objTelegram.SETIN_DATA("XDSPBERTH_SITEI", strXDSPBERTH_SITEI)                   'ﾊﾞｰｽ指定

        objTelegram.SETIN_DATA("XDSPCAR_NO_DAIHYOU", strXDSPCAR_NO_DAIHYOU)             '代表車番
        objTelegram.SETIN_DATA("XDSPCAR_NO_EDA_DAIHYOU", strXDSPCAR_NO_EDA_DAIHYOU)     '代表車番枝番
        'objTelegram.SETIN_DATA("XDSPBERTH_WARITUKE_FLAG", strXDSPBERTH_WARITUKE_FLAG)   'ﾊﾞｰｽ割付可能ﾌﾗｸﾞ

        objTelegram.SETIN_DATA("XDSPWARITUKE_BERTH", strXDSPWARITUKE_BERTH)     '割付_ﾊﾞｰｽ
        objTelegram.SETIN_DATA("XDSPWARITUKE_HIRA01", strXDSPWARITUKE_HIRA01)   '割付_1F平置き
        objTelegram.SETIN_DATA("XDSPWARITUKE_BARA", strXDSPWARITUKE_BARA)       '割付_ﾊﾞﾗ平置き
        objTelegram.SETIN_DATA("XDSPWARITUKE_GAIBU", strXDSPWARITUKE_GAIBU)     '割付_外部倉庫


        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode    'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String = ""                    'ｴﾗｰﾒｯｾｰｼﾞ
        strErrMsg = FRM_MSG_FRM308041_04
        udtSckSendRET = gobjComFuncFRM.SockSendServer02(objTelegram, strSendTel, strRET_STATE, , , , strErrMsg)    'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            '(送信できた場合)
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)
                blnReturn = True
            End If
        End If

        Return blnReturn

    End Function
#End Region

#Region "　印刷処理                                 "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub printOut()

        ''*******************************************************
        ''確認ﾒｯｾｰｼﾞ
        ''*******************************************************
        'Dim udeRet As PopupFormType
        'udeRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_PRINT_01, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        'If udeRet <> PopupFormType.Ok Then
        '    Exit Sub
        'End If


        '*******************************************************
        '印刷処理
        '*******************************************************
        '*********************************************
        ' 構造体ｾｯﾄ
        '*********************************************
        Call SearchItem_Set2()

        '*********************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '*********************************************
        Call grdListDisplayChild2()     'ﾋﾟｯｷﾝｸﾞﾘｽﾄ全体
        Call grdListDisplayChild3()     'ﾋﾟｯｷﾝｸﾞﾘｽﾄ

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        If (grdList2.RowCount > 0) Or _
           (grdList3.RowCount > 0) Then
            '(印刷ﾃﾞｰﾀありの時)
            Dim udeRet As PopupFormType
            udeRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_PRINT_01, PopupFormType.Ok_Cancel, PopupIconType.Quest)
            If udeRet <> PopupFormType.Ok Then
                Exit Sub
            End If
        End If

        '*********************************************
        ' ﾘｽﾄ出力
        '*********************************************
        If grdList2.RowCount > 0 Then
            '(印刷ﾃﾞｰﾀありの時)
            Call printOut01()               'ﾋﾟｯｷﾝｸﾞﾘｽﾄ全体
        End If

        If grdList3.RowCount > 0 Then
            '(印刷ﾃﾞｰﾀありの時)
            Call printOut02()               'ﾋﾟｯｷﾝｸﾞﾘｽﾄ
        End If

    End Sub
#End Region

#Region "  構造体ｾｯﾄ(ﾘｽﾄ用)                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 構造体ｾｯﾄ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SearchItem_Set2()

        '********************************************************************
        '構造体に値をｾｯﾄ
        '********************************************************************
        mudtSEARCH_ITEM2.XHIKIATE_DT = mstrXDSPUKETUKE_DT                   '引当日
        mudtSEARCH_ITEM2.XCAR_NO_WARITUKE = mstrXCAR_NO_WARITUKE            '受付車番
        mudtSEARCH_ITEM2.XCAR_NO_EDA_WARITUKE = mstrXCAR_NO_EDA_WARITUKE    '受付車番枝番
        'mudtSEARCH_ITEM2.XCAR_NO_EDA_WARITUKE = txtXCAR_NO_EDA_WARITUKE.Text    '受付車番枝番
        mudtSEARCH_ITEM2.XNYUKA_JIGYOU_CD = mstrXNYUKA_JIGYOU_CD            '配送先ｺｰﾄﾞ
        mudtSEARCH_ITEM2.XNYUKA_JIGYOU_NM = mstrXNYUKA_JIGYOU_NM            '配送先名

    End Sub
#End Region

#Region "　ﾘｽﾄ表示(ﾋﾟｯｷﾝｸﾞﾘｽﾄ全体)                  "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾘｽﾄ表示
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub grdListDisplayChild2()

        Dim strSQL As String                        'SQL文


        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "     XPLN_SYUKKA_PICK_PRINT.XHIKIATE_DT "               'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷引当日時(非表示)
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XSYUKKA_DT "                'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷日(非表示)
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XCAR_NO_WARITUKE "          'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        割付車番
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XCAR_NO_EDA_WARITUKE "      'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        割付車番枝番
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XNYUKA_JIGYOU_CD "          'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        入荷事業所ｺｰﾄﾞ(非表示)
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XNYUKA_JIGYOU_NM "          'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        入荷事業所名
        '↓↓↓↓ 2012.12.03 17:10 H.Morita ﾋﾟｯｷﾝｸﾞﾘｽﾄ(全体) 「発注№」の表示
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XORDER_NO "                 'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        発注№
        '↑↑↑↑ 2012.12.03 17:10 H.Morita ﾋﾟｯｷﾝｸﾞﾘｽﾄ(全体) 「発注№」の表示
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.FHINMEI "                   'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        品名
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.FHINMEI_CD "                'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XSEIZOU_DT "                'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        製造年月日

        strSQL &= vbCrLf & "   , SUM(XPLN_SYUKKA_PICK_PRINT.XHIKIATE_VOL) "         'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        引当数
        strSQL &= vbCrLf & "   , SUM(XPLN_SYUKKA_PICK_PRINT.XPRINT_PL_NUM) "        'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        PL
        strSQL &= vbCrLf & "   , SUM(XPLN_SYUKKA_PICK_PRINT.XPRINT_BARA_DAN_NUM) "  'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        段
        strSQL &= vbCrLf & "   , SUM(XPLN_SYUKKA_PICK_PRINT.XPRINT_BARA_NUM) "      'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        C/S
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XHINSHITU_STS "             'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        品質ｽﾃｰﾀｽ(非表示)
        strSQL &= vbCrLf & "   , HASH01.FGAMEN_DISP AS XHINSHITU_STS_DSP "          'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        品質ｽﾃｰﾀｽ(表示用)
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.FTRK_BUF_NO "               'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№(非表示)
        strSQL &= vbCrLf & "   , TMST_TRK.FBUF_NAME "                               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬﾏｽﾀ.   ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ名称(保管場所)

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "     XPLN_SYUKKA_PICK_PRINT "                         'ﾋﾟｯｷﾝｸﾞﾘｽﾄ情報
        strSQL &= vbCrLf & "   , TMST_TRK "                                       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬﾏｽﾀ
        strSQL &= vbCrLf & "  , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH01", "XPLN_SYUKKA_PICK_PRINT", "XHINSHITU_STS")

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE 0 = 0 "
        strSQL &= vbCrLf & "   AND XPLN_SYUKKA_PICK_PRINT.FTRK_BUF_NO = TMST_TRK.FTRK_BUF_NO(+) "
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH01", "XPLN_SYUKKA_PICK_PRINT", "XHINSHITU_STS")

        '-----------------------------
        '引当日
        '-----------------------------
        If mudtSEARCH_ITEM2.XHIKIATE_DT <> CBO_ALL_VALUE Then
            '(全選択以外の時)
            strSQL &= vbCrLf & "        AND XPLN_SYUKKA_PICK_PRINT.XHIKIATE_DT = TO_DATE('" & mudtSEARCH_ITEM2.XHIKIATE_DT & "', 'YYYY/MM/DD HH24:MI:SS') "
        End If

        '-----------------------------
        '受付車番
        '-----------------------------
        If mudtSEARCH_ITEM2.XCAR_NO_WARITUKE <> CBO_ALL_VALUE Then
            '(全選択以外の時)
            strSQL &= vbCrLf & "        AND XPLN_SYUKKA_PICK_PRINT.XCAR_NO_WARITUKE = '" & mudtSEARCH_ITEM2.XCAR_NO_WARITUKE & "' "
        End If

        '-----------------------------
        '受付車番枝番
        '-----------------------------
        '↓↓↓ 2012/11/08 18:00 DEL
        'If mudtSEARCH_ITEM2.XCAR_NO_EDA_WARITUKE <> CBO_ALL_VALUE Then
        '    '(全選択以外の時)
        '    strSQL &= vbCrLf & "        AND XPLN_SYUKKA_PICK_PRINT.XCAR_NO_EDA_WARITUKE = '" & mudtSEARCH_ITEM2.XCAR_NO_EDA_WARITUKE & "' "
        'End If
        '↑↑↑ 2012/11/08 18:00 DEL


        '↓↓↓↓ 2012/11/27 9:30 H.Morita DEL
        ''-----------------------------
        ''配送先ｺｰﾄﾞ
        ''-----------------------------
        'If mudtSEARCH_ITEM2.XNYUKA_JIGYOU_CD <> CBO_ALL_VALUE Then
        '    '(全選択以外の時)
        '    strSQL &= vbCrLf & "        AND XPLN_SYUKKA_PICK_PRINT.XNYUKA_JIGYOU_CD = '" & mudtSEARCH_ITEM2.XNYUKA_JIGYOU_CD & "' "
        'End If
        '↑↑↑↑ 2012/11/27 9:30 H.Morita DEL


        '-----------------------------
        '発注№
        '-----------------------------
        strSQL &= vbCrLf & " AND XPLN_SYUKKA_PICK_PRINT.XORDER_NO IN ("
        For ii As Integer = LBound(mstrXORDER_NO) To UBound(mstrXORDER_NO)
            '(ﾙｰﾌﾟ:選択された行数)
            If ii = 0 Then
                '(初回の時)
                strSQL &= vbCrLf & "'" & mstrXORDER_NO(ii) & "'"
            Else
                '(以降の時)
                strSQL &= vbCrLf & ", '" & mstrXORDER_NO(ii) & "'"
            End If
        Next
        strSQL &= vbCrLf & " ) "


        '============================================================
        'GROUP BY
        '============================================================
        strSQL &= vbCrLf & " GROUP BY "
        strSQL &= vbCrLf & "     XPLN_SYUKKA_PICK_PRINT.XHIKIATE_DT "               'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷引当日時(非表示)
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XSYUKKA_DT "                'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷日(非表示)
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XCAR_NO_WARITUKE "          'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        割付車番
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XCAR_NO_EDA_WARITUKE "      'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        割付車番枝番
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XNYUKA_JIGYOU_CD "          'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        入荷事業所ｺｰﾄﾞ(非表示)
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XNYUKA_JIGYOU_NM "          'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        入荷事業所名
        '↓↓↓↓ 2012.12.03 17:10 H.Morita ﾋﾟｯｷﾝｸﾞﾘｽﾄ(全体) 「発注№」の表示
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XORDER_NO "                 'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        発注№
        '↑↑↑↑ 2012.12.03 17:10 H.Morita ﾋﾟｯｷﾝｸﾞﾘｽﾄ(全体) 「発注№」の表示
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.FHINMEI "                   'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        品名
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.FHINMEI_CD "                'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XSEIZOU_DT "                'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        製造年月日
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XHINSHITU_STS "             'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        品質ｽﾃｰﾀｽ(非表示)
        strSQL &= vbCrLf & "   , HASH01.FGAMEN_DISP "                               'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        品質ｽﾃｰﾀｽ(表示用)
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.FTRK_BUF_NO "               'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№(非表示)
        strSQL &= vbCrLf & "   , TMST_TRK.FBUF_NAME "                               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬﾏｽﾀ.   ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ名称(保管場所)


        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "     XPLN_SYUKKA_PICK_PRINT.XHIKIATE_DT "               'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷引当日時(非表示)
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XSYUKKA_DT "                'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷日(非表示)
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XCAR_NO_WARITUKE "          'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        割付車番
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XCAR_NO_EDA_WARITUKE "      'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        割付車番枝番
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XNYUKA_JIGYOU_CD "          'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        入荷事業所ｺｰﾄﾞ(非表示)
        '↓↓↓↓ 2012.11.28 13:30 H.Morita 出力順の不具合修正
        'strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XNYUKA_JIGYOU_NM "          'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        入荷事業所名
        'strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.FHINMEI "                   'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        品名
        '↑↑↑↑ 2012.11.28 13:30 H.Morita 出力順の不具合修正
        '↓↓↓↓ 2012.12.03 17:10 H.Morita ﾋﾟｯｷﾝｸﾞﾘｽﾄ(全体) 「発注№」の表示
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XORDER_NO "                 'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        発注№
        '↑↑↑↑ 2012.12.03 17:10 H.Morita ﾋﾟｯｷﾝｸﾞﾘｽﾄ(全体) 「発注№」の表示
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.FHINMEI_CD "                'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XSEIZOU_DT "                'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        製造年月日
        strSQL &= vbCrLf


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        Call gobjComFuncFRM.TblDataGridDisplay(grdList2, strSQL, False)


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdListSetup2()
        Call gobjComFuncFRM.GridSelect(grdList2, -1, 1, Nothing)        'ｸﾞﾘｯﾄﾞ選択処理


    End Sub
#End Region
#Region "  ﾘｽﾄ表示設定(ﾋﾟｯｷﾝｸﾞﾘｽﾄ全体)              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾘｽﾄ表示設定
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListSetup2()


        '************************************************
        'ｸﾞﾘｯﾄﾞﾏｽﾀの定義を反映
        '************************************************
        Call gobjComFuncFRM.TDSP_GRIDSetup(Me, grdList2)

        'grdList.MultiSelect = True
        'grdList.AllowUserToResizeColumns = False

    End Sub
#End Region
#Region "　印刷処理(ﾋﾟｯｷﾝｸﾞﾘｽﾄ全体）                "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】なし
    '【戻値】なし
    '*******************************************************************************************************************
    Private Sub printOut01()

        Call gobjComFuncFRM.WaitFormShow()                     ' Waitﾌｫｰﾑ表示

        '***********************************************
        ' 各ｵﾌﾞｼﾞｪｸﾄのｲﾝｽﾀﾝｽ
        '***********************************************
        Dim objCR As New PRT_308041_01          'ｸﾘｽﾀﾙﾚﾎﾟｰﾄｵﾌﾞｼﾞｪｸﾄ
        Dim objDataSet As New clsPrintDataSet   'ﾃﾞｰﾀﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ

        Try

            '***********************************************
            ' ﾍｯﾀﾞｰ部分作成
            '***********************************************
            '================================
            ' ﾃﾞｰﾀをｾｯﾄ
            '================================
            Call gobjComFuncFRM.ChangeCRText(objCR, "crDateTime01", Format(Now, GAMEN_DATE_FORMAT_02))

            ''受付車番
            'Call gobjComFuncFRM.ChangeCRText(objCR, "crText01", mudtSEARCH_ITEM2.XCAR_NO_WARITUKE & _
            '                                              "-" & mudtSEARCH_ITEM2.XCAR_NO_EDA_WARITUKE)

            'Call gobjComFuncFRM.ChangeCRText(objCR, "crText02", mudtSEARCH_ITEM2.XNYUKA_JIGYOU_NM)  '配送先

            Call gobjComFuncFRM.ChangeCRText(objCR, "crText01", "")     '受付車番枝番(未使用)
            Call gobjComFuncFRM.ChangeCRText(objCR, "crText02", "")     '配送先(未使用)

            '***********************************************
            ' ﾃﾞｰﾀ部分作成
            '***********************************************
            For ii As Integer = 0 To grdList2.Rows.Count - 1

                Dim objDataRow As clsPrintDataSet.DataTable01Row
                objDataRow = objDataSet.DataTable01.NewRow

                objDataRow.BeginEdit()

                objDataRow.Data14 = grdList2.Item(menmListCol2.XCAR_NO_WARITUKE, ii).FormattedValue _
                            & "-" & grdList2.Item(menmListCol2.XCAR_NO_EDA_WARITUKE, ii).FormattedValue       '(ﾍｯﾀﾞｰ)受付車番-受付車番枝番
                objDataRow.Data15 = grdList2.Item(menmListCol2.XNYUKA_JIGYOU_NM, ii).FormattedValue           '(ﾍｯﾀﾞｰ)入荷事業所ｺｰﾄﾞ

                objDataRow.Data00 = grdList2.Item(menmListCol2.XHIKIATE_DT, ii).FormattedValue                '出荷引当日時
                objDataRow.Data01 = grdList2.Item(menmListCol2.XCAR_NO_WARITUKE, ii).FormattedValue           '割付車番
                objDataRow.Data02 = grdList2.Item(menmListCol2.XCAR_NO_EDA_WARITUKE, ii).FormattedValue       '割付車番枝番
                objDataRow.Data03 = grdList2.Item(menmListCol2.XNYUKA_JIGYOU_CD, ii).FormattedValue           '入荷事業所ｺｰﾄﾞ

                objDataRow.Data04 = ii + 1                                                                    '№
                '↓↓↓↓ 2012.12.03 17:10 H.Morita ﾋﾟｯｷﾝｸﾞﾘｽﾄ(全体) 「発注№」の表示
                objDataRow.Data16 = grdList2.Item(menmListCol2.XORDER_NO, ii).FormattedValue                  '発注№
                '↑↑↑↑ 2012.12.03 17:10 H.Morita ﾋﾟｯｷﾝｸﾞﾘｽﾄ(全体) 「発注№」の表示
                objDataRow.Data05 = grdList2.Item(menmListCol2.FHINMEI_CD, ii).FormattedValue                 '品名ｺｰﾄﾞ
                objDataRow.Data06 = grdList2.Item(menmListCol2.FHINMEI, ii).FormattedValue                    '品名
                objDataRow.Data07 = grdList2.Item(menmListCol2.XSEIZOU_DT, ii).FormattedValue                 '製造年月日
                objDataRow.Data09 = grdList2.Item(menmListCol2.XHIKIATE_VOL, ii).FormattedValue               '引当数
                objDataRow.Data10 = grdList2.Item(menmListCol2.XPRINT_PL_NUM, ii).FormattedValue              'PL
                objDataRow.Data11 = grdList2.Item(menmListCol2.XPRINT_BARA_DAN_NUM, ii).FormattedValue        '段
                objDataRow.Data12 = grdList2.Item(menmListCol2.XPRINT_BARA_NUM, ii).FormattedValue            'C/S

                objDataRow.Data08 = grdList2.Item(menmListCol2.XHINSHITU_STS_DSP, ii).FormattedValue          '品質ｽﾃｰﾀｽ
                objDataRow.Data13 = grdList2.Item(menmListCol2.FBUF_NAME, ii).FormattedValue                  '保管場所

                objDataRow.EndEdit()

                objDataSet.DataTable01.Rows.Add(objDataRow)

            Next

            '***********************************************
            ' ｸﾘｽﾀﾙﾚﾎﾟｰﾄにﾃﾞｰﾀｾｯﾄをｾｯﾄ
            '***********************************************
            objCR.SetDataSource(objDataSet)

            '***********************************************
            ' 印字
            '***********************************************
            Call gobjComFuncFRM.CRPrint(objCR)

        Catch ex As Exception
            Throw ex

        Finally
            'ｸﾘｽﾀﾙﾚﾎﾟｰﾄｵﾌﾞｼﾞｪｸﾄ
            objCR.Dispose()
            objCR = Nothing
            'ﾃﾞｰﾀﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ
            objDataSet.Dispose()
            objDataSet = Nothing

            Call gobjComFuncFRM.WaitFormClose()                    ' Waitﾌｫｰﾑ削除

        End Try

    End Sub
#End Region

#Region "　ﾘｽﾄ表示(ﾋﾟｯｷﾝｸﾞﾘｽﾄ)                      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾘｽﾄ表示
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub grdListDisplayChild3()

        Dim strSQL As String                        'SQL文


        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "     XPLN_SYUKKA_PICK_PRINT.XHIKIATE_DT "                                               'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷引当日時(非表示)
        strSQL &= vbCrLf & "   , TO_CHAR(XPLN_SYUKKA_PICK_PRINT.XHIKIATE_DT, 'YYYY/MM/DD') AS XHIKIATE_DT_DSP "     'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷引当日時(表示用)
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XSYUKKA_DT "                                                'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷日(非表示)
        strSQL &= vbCrLf & "   , TO_CHAR(TO_DATE(XPLN_SYUKKA_PICK_PRINT.XSYUKKA_DT, 'YYYY/MM/DD'), 'YYYY/MM/DD') AS XSYUKKA_DT_DSP "       'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷日(表示用)
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XCAR_NO_WARITUKE "                                          'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        割付車番
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XCAR_NO_EDA_WARITUKE "                                      'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        割付車番枝番
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XNYUKA_JIGYOU_CD "                                          'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        入荷事業所ｺｰﾄﾞ(非表示)
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XNYUKA_JIGYOU_NM "                                          'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        入荷事業所名
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XORDER_NO "                                                 'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        発注№
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XIDOU_CD "                                                  'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        移動手段ｺｰﾄﾞ(非表示)
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XIDOU_NM "                                                  'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        移動手段名

        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.FTRK_BUF_NO "                                               'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№(非表示)
        strSQL &= vbCrLf & "   , TMST_TRK.FBUF_NAME "                                                               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬﾏｽﾀ.   ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ名称(保管場所)

        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.FHINMEI_CD "                                                'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.FHINMEI "                                                   'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        品名
        strSQL &= vbCrLf & "   , TO_CHAR(XPLN_SYUKKA_PICK_PRINT.XSEIZOU_DT, 'YYYY/MM/DD') "                         'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        製造年月日
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XHIKIATE_VOL "                                              'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        引当数
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XPRINT_PL_NUM "                                             'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        PL
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XPRINT_BARA_DAN_NUM "                                       'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        段
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XPRINT_BARA_NUM "                                           'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        C/S
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XWEIGHT "                                                   'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        重量
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XSYUKKA_KAHI "                                              'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷可否(非表示)
        strSQL &= vbCrLf & "   , HASH01.FGAMEN_DISP AS XSYUKKA_KAHI_DSP "                                           'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷可否(表示用)
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XHINSHITU_STS "                                             'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        品質ｽﾃｰﾀｽ(非表示)
        strSQL &= vbCrLf & "   , HASH02.FGAMEN_DISP AS XHINSHITU_STS_DSP "                                          'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        品質ｽﾃｰﾀｽ(表示用)
        strSQL &= vbCrLf & "   , TMST_ITEM.FDECIMAL_POINT "                                                         '品目ﾏｽﾀ.           小数点以下有効桁数


        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    XPLN_SYUKKA_PICK_PRINT "                         'ﾋﾟｯｷﾝｸﾞﾘｽﾄ情報
        strSQL &= vbCrLf & "  , TMST_TRK "                                       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬﾏｽﾀ
        strSQL &= vbCrLf & "  , TMST_ITEM "                                      '品目ﾏｽﾀ
        strSQL &= vbCrLf & "  , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH01", "XPLN_SYUKKA_PICK_PRINT", "XSYUKKA_KAHI")
        strSQL &= vbCrLf & "  , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH02", "XPLN_SYUKKA_PICK_PRINT", "XHINSHITU_STS")


        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE 0 = 0 "
        strSQL &= vbCrLf & "    AND XPLN_SYUKKA_PICK_PRINT.FTRK_BUF_NO = TMST_TRK.FTRK_BUF_NO(+) "
        strSQL &= vbCrLf & "    AND XPLN_SYUKKA_PICK_PRINT.FHINMEI_CD  = TMST_ITEM.FHINMEI_CD(+) "
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH01", "XPLN_SYUKKA_PICK_PRINT", "XSYUKKA_KAHI")
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH02", "XPLN_SYUKKA_PICK_PRINT", "XHINSHITU_STS")
        strSQL &= vbCrLf & "        AND XPLN_SYUKKA_PICK_PRINT.FTRK_BUF_NO IN ("
        strSQL &= vbCrLf & FTRK_BUF_NO_J8000 & ", "
        strSQL &= vbCrLf & FTRK_BUF_NO_J8001 & ", "
        strSQL &= vbCrLf & FTRK_BUF_NO_J8100 & ", " & FTRK_BUF_NO_J8101 & ", " _
                         & FTRK_BUF_NO_J8102 & ", " & FTRK_BUF_NO_J8103 & ", " _
                         & FTRK_BUF_NO_J8104 & ", " & FTRK_BUF_NO_J8105 & ", " _
                         & FTRK_BUF_NO_J8106 & ", " & FTRK_BUF_NO_J8107 & ", " _
                         & FTRK_BUF_NO_J8108 & ", " & FTRK_BUF_NO_J8109
        strSQL &= vbCrLf & ") "


        '-----------------------------
        '引当日
        '-----------------------------
        If mudtSEARCH_ITEM2.XHIKIATE_DT <> CBO_ALL_VALUE Then
            '(全選択以外の時)
            strSQL &= vbCrLf & "        AND XPLN_SYUKKA_PICK_PRINT.XHIKIATE_DT = TO_DATE('" & mudtSEARCH_ITEM2.XHIKIATE_DT & "', 'YYYY/MM/DD HH24:MI:SS') "
        End If

        '-----------------------------
        '発注№
        '-----------------------------
        strSQL &= vbCrLf & " AND XPLN_SYUKKA_PICK_PRINT.XORDER_NO IN ("
        For ii As Integer = LBound(mstrXORDER_NO) To UBound(mstrXORDER_NO)
            '(ﾙｰﾌﾟ:選択された行数)
            If ii = 0 Then
                '(初回の時)
                strSQL &= vbCrLf & "'" & mstrXORDER_NO(ii) & "'"
            Else
                '(以降の時)
                strSQL &= vbCrLf & ", '" & mstrXORDER_NO(ii) & "'"
            End If
        Next
        strSQL &= vbCrLf & " ) "

        '-----------------------------
        '受付車番
        '-----------------------------
        If mudtSEARCH_ITEM2.XCAR_NO_WARITUKE <> CBO_ALL_VALUE Then
            '(全選択以外の時)
            strSQL &= vbCrLf & "        AND XPLN_SYUKKA_PICK_PRINT.XCAR_NO_WARITUKE = '" & mudtSEARCH_ITEM2.XCAR_NO_WARITUKE & "' "
        End If

        '-----------------------------
        '受付車番枝番
        '-----------------------------
        '↓↓↓ 2012/11/08 18:00 DEL
        'If mudtSEARCH_ITEM2.XCAR_NO_EDA_WARITUKE <> CBO_ALL_VALUE Then
        '    '(全選択以外の時)
        '    strSQL &= vbCrLf & "        AND XPLN_SYUKKA_PICK_PRINT.XCAR_NO_EDA_WARITUKE = '" & mudtSEARCH_ITEM2.XCAR_NO_EDA_WARITUKE & "' "
        'End If
        '↑↑↑ 2012/11/08 18:00 DEL

        '↓↓↓↓ 2012/11/27 9:30 H.Morita DEL
        ''-----------------------------
        ''配送先ｺｰﾄﾞ
        ''-----------------------------
        'If mudtSEARCH_ITEM2.XNYUKA_JIGYOU_CD <> CBO_ALL_VALUE Then
        '    '(全選択以外の時)
        '    strSQL &= vbCrLf & "        AND XPLN_SYUKKA_PICK_PRINT.XNYUKA_JIGYOU_CD = '" & mudtSEARCH_ITEM2.XNYUKA_JIGYOU_CD & "' "
        'End If
        '↑↑↑↑ 2012/11/27 9:30 H.Morita DEL


        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "     XPLN_SYUKKA_PICK_PRINT.XHIKIATE_DT "                                               'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷引当日時(非表示)
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XSYUKKA_DT "                                                'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        出荷日(非表示)
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XCAR_NO_WARITUKE "                                          'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        車番
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XCAR_NO_EDA_WARITUKE "                                      'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        車番枝番
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XNYUKA_JIGYOU_CD "                                          'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        入荷事業所ｺｰﾄﾞ(非表示)
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XORDER_NO "                                                 'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        発注№
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XIDOU_CD "                                                  'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        移動手段ｺｰﾄﾞ(非表示)
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.FTRK_BUF_NO "                                               'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№(非表示)
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.FHINMEI_CD "                                                'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_PICK_PRINT.XSEIZOU_DT "                                                'ﾋﾟｯｷﾝｸﾞﾘｽﾄ.        製造年月日
        strSQL &= vbCrLf


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        Call gobjComFuncFRM.TblDataGridDisplay(grdList3, strSQL, False)


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdListSetup3()
        Call gobjComFuncFRM.GridSelect(grdList3, -1, 1, Nothing)        'ｸﾞﾘｯﾄﾞ選択処理


    End Sub
#End Region
#Region "  ﾘｽﾄ表示設定(ﾋﾟｯｷﾝｸﾞﾘｽﾄ)                  "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾘｽﾄ表示設定
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListSetup3()

        '************************************************
        '重量小数点表示
        '************************************************
        Call gobjComFuncFRM.GridFTR_VOLChange01(grdList3, menmListCol3.XWEIGHT, menmListCol3.FDECIMAL_POINT)


        '************************************************
        'ｸﾞﾘｯﾄﾞﾏｽﾀの定義を反映
        '************************************************
        Call gobjComFuncFRM.TDSP_GRIDSetup(Me, grdList3)

        'grdList.MultiSelect = True
        'grdList.AllowUserToResizeColumns = False

    End Sub
#End Region
#Region "　印刷処理(ﾋﾟｯｷﾝｸﾞﾘｽﾄ）                    "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】なし
    '【戻値】なし
    '*******************************************************************************************************************
    Private Sub printOut02()

        Call gobjComFuncFRM.WaitFormShow()                     ' Waitﾌｫｰﾑ表示

        '***********************************************
        ' 各ｵﾌﾞｼﾞｪｸﾄのｲﾝｽﾀﾝｽ
        '***********************************************
        Dim objCR As New PRT_308041_02          'ｸﾘｽﾀﾙﾚﾎﾟｰﾄｵﾌﾞｼﾞｪｸﾄ
        Dim objDataSet As New clsPrintDataSet   'ﾃﾞｰﾀﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ

        Try

            '***********************************************
            ' ﾍｯﾀﾞｰ部分作成
            '***********************************************
            '================================
            ' ﾃﾞｰﾀをｾｯﾄ
            '================================
            Call gobjComFuncFRM.ChangeCRText(objCR, "crDateTime01", Format(Now, GAMEN_DATE_FORMAT_02))

            Dim strFTRK_BUF_NO_OLD As String = ""       '旧ｷｰ
            Dim intRec_Cnt As Integer = 0               'ﾚｺｰﾄﾞｶｳﾝﾄ

            '***********************************************
            ' ﾃﾞｰﾀ部分作成
            '***********************************************
            For ii As Integer = 0 To grdList3.Rows.Count - 1

                If ii = 0 Then
                    '(1回目の時)
                    'Call gobjComFuncFRM.ChangeCRText(objCR, "crText02", grdList3.Item(menmListCol3.XNYUKA_JIGYOU_NM, ii).FormattedValue)  '配送先
                    'Call gobjComFuncFRM.ChangeCRText(objCR, "crText03", grdList3.Item(menmListCol3.XSYUKKA_DT_DSP, ii).FormattedValue)   '出荷日
                    'Call gobjComFuncFRM.ChangeCRText(objCR, "crText05", grdList3.Item(menmListCol3.XIDOU_NM, ii).FormattedValue)          '移動手段
                    'Call gobjComFuncFRM.ChangeCRText(objCR, "crText06", grdList3.Item(menmListCol3.XCAR_NO_WARITUKE, ii).FormattedValue & "-" & _
                    '                                                    grdList3.Item(menmListCol3.XCAR_NO_EDA_WARITUKE, ii).FormattedValue)       '受付車番
                    Call gobjComFuncFRM.ChangeCRText(objCR, "crText02", "")  '配送先
                    Call gobjComFuncFRM.ChangeCRText(objCR, "crText03", "")  '出荷日
                    Call gobjComFuncFRM.ChangeCRText(objCR, "crText05", "")  '移動手段
                    Call gobjComFuncFRM.ChangeCRText(objCR, "crText06", "")  '受付車番-受付車番枝番
                End If


                Dim objDataRow As clsPrintDataSet.DataTable01Row
                objDataRow = objDataSet.DataTable01.NewRow

                objDataRow.BeginEdit()

                objDataRow.Data19 = grdList3.Item(menmListCol3.FBUF_NAME, ii).FormattedValue            '保管場所
                objDataRow.Data20 = grdList3.Item(menmListCol3.XORDER_NO, ii).FormattedValue            '発注№
                objDataRow.Data21 = grdList3.Item(menmListCol3.XCAR_NO_WARITUKE, ii).FormattedValue & "-" & _
                                    grdList3.Item(menmListCol3.XCAR_NO_EDA_WARITUKE, ii).FormattedValue         '受付車番-受付車番枝番
                objDataRow.Data22 = grdList3.Item(menmListCol3.XNYUKA_JIGYOU_NM, ii).FormattedValue     '配送先
                objDataRow.Data23 = grdList3.Item(menmListCol3.XSYUKKA_DT_DSP, ii).FormattedValue       '出荷日
                objDataRow.Data24 = grdList3.Item(menmListCol3.XIDOU_NM, ii).FormattedValue             '移動手段

                objDataRow.Data00 = grdList3.Item(menmListCol3.XHIKIATE_DT, ii).FormattedValue          '出荷引当日時
                objDataRow.Data01 = grdList3.Item(menmListCol3.XCAR_NO_WARITUKE, ii).FormattedValue     '割付車番
                objDataRow.Data02 = grdList3.Item(menmListCol3.XCAR_NO_EDA_WARITUKE, ii).FormattedValue '割付車番枝番
                objDataRow.Data03 = grdList3.Item(menmListCol3.XNYUKA_JIGYOU_CD, ii).FormattedValue     '入荷事業所ｺｰﾄﾞ
                objDataRow.Data04 = grdList3.Item(menmListCol3.XORDER_NO, ii).FormattedValue            '発注№
                objDataRow.Data05 = grdList3.Item(menmListCol3.XIDOU_CD, ii).FormattedValue             '移動手段ｺｰﾄﾞ

                objDataRow.Data07 = grdList3.Item(menmListCol3.FTRK_BUF_NO, ii).FormattedValue          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№

                If strFTRK_BUF_NO_OLD <> grdList3.Item(menmListCol3.FTRK_BUF_NO, ii).FormattedValue Then
                    '(ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№が異なるとき)
                    strFTRK_BUF_NO_OLD = grdList3.Item(menmListCol3.FTRK_BUF_NO, ii).FormattedValue
                    intRec_Cnt = 1
                Else
                    '(ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№が同じのとき)
                    intRec_Cnt += 1
                End If
                objDataRow.Data08 = intRec_Cnt                                                          '№

                objDataRow.Data09 = grdList3.Item(menmListCol3.FHINMEI_CD, ii).FormattedValue           '品名ｺｰﾄﾞ
                objDataRow.Data10 = grdList3.Item(menmListCol3.FHINMEI, ii).FormattedValue              '品名
                objDataRow.Data16 = grdList3.Item(menmListCol3.XSEIZOU_DT, ii).FormattedValue           '製造年月日
                objDataRow.Data11 = grdList3.Item(menmListCol3.XHIKIATE_VOL, ii).FormattedValue         '引当数(C/S)
                objDataRow.Data12 = grdList3.Item(menmListCol3.XPRINT_PL_NUM, ii).FormattedValue        'PL

                '↓↓↓↓ 2012.11.28 13:30 H.Morita
                If TO_INTEGER(grdList3.Item(menmListCol3.XPRINT_BARA_DAN_NUM, ii).FormattedValue) = 0 Then
                    '(段がｾﾞﾛの時)
                    objDataRow.Data13 = ""                                                                  '段
                Else
                    '(段に値がある時)
                    objDataRow.Data13 = grdList3.Item(menmListCol3.XPRINT_BARA_DAN_NUM, ii).FormattedValue  '段
                End If
                '↑↑↑↑ 2012.11.28 13:30 H.Morita

                '↓↓↓↓ 2012.11.28 13:30 H.Morita
                If TO_INTEGER(grdList3.Item(menmListCol3.XPRINT_BARA_NUM, ii).FormattedValue) = 0 Then
                    '(C/Sがｾﾞﾛの時)
                    objDataRow.Data14 = ""                                                                  'C/S
                Else
                    '(C/Sに値がある時)
                    objDataRow.Data14 = grdList3.Item(menmListCol3.XPRINT_BARA_NUM, ii).FormattedValue      'C/S
                End If
                '↑↑↑↑ 2012.11.28 13:30 H.Morita

                objDataRow.Data15 = grdList3.Item(menmListCol3.XWEIGHT, ii).FormattedValue              '重量
                objDataRow.Data17 = grdList3.Item(menmListCol3.XSYUKKA_KAHI_DSP, ii).FormattedValue     '出荷可否
                objDataRow.Data18 = grdList3.Item(menmListCol3.XHINSHITU_STS_DSP, ii).FormattedValue    '品質ｽﾃｰﾀｽ

                objDataRow.EndEdit()

                objDataSet.DataTable01.Rows.Add(objDataRow)

            Next

            '***********************************************
            ' ｸﾘｽﾀﾙﾚﾎﾟｰﾄにﾃﾞｰﾀｾｯﾄをｾｯﾄ
            '***********************************************
            objCR.SetDataSource(objDataSet)

            '***********************************************
            ' 印字
            '***********************************************
            Call gobjComFuncFRM.CRPrint(objCR)

        Catch ex As Exception
            Throw ex

        Finally
            'ｸﾘｽﾀﾙﾚﾎﾟｰﾄｵﾌﾞｼﾞｪｸﾄ
            objCR.Dispose()
            objCR = Nothing
            'ﾃﾞｰﾀﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ
            objDataSet.Dispose()
            objDataSet = Nothing

            Call gobjComFuncFRM.WaitFormClose()                    ' Waitﾌｫｰﾑ削除

        End Try

    End Sub
#End Region

#Region "  ﾊﾞｰｽ待ち情報ﾃｰﾌﾞﾙの割付ﾌﾗｸﾞ        取得      "
    '''**********************************************************************************************
    ''' <summary>
    ''' ﾊﾞｰｽ待ち情報ﾃｰﾌﾞﾙの割付ﾌﾗｸﾞ        取得
    ''' </summary>
    ''' <param name="strAryXORDER_NO">発注№</param>
    ''' <param name="strXDSPWARITUKE_BERTH">割付ﾌﾗｸﾞ(自動倉庫)</param>
    ''' <param name="strXDSPWARITUKE_HIRA01">割付ﾌﾗｸﾞ(ﾊﾞﾗ平置場)</param>
    ''' <param name="strXDSPWARITUKE_BARA">割付ﾌﾗｸﾞ(1F平置場)</param>
    ''' <param name="strXDSPWARITUKE_GAIBU">割付ﾌﾗｸﾞ(外部倉庫)</param>
    ''' <remarks></remarks>
    '''**********************************************************************************************
    Private Sub GetWarituke(ByVal strAryXORDER_NO() As String _
                          , ByRef strXDSPWARITUKE_BERTH As String _
                          , ByRef strXDSPWARITUKE_HIRA01 As String _
                          , ByRef strXDSPWARITUKE_BARA As String _
                          , ByRef strXDSPWARITUKE_GAIBU As String _
                          )

        Dim intRet As RetCode                       '戻り値


        '***************************************************************************************************************************************************************
        '***************************************************************************************************************************************************************
        '計画の取得
        '***************************************************************************************************************************************************************
        '***************************************************************************************************************************************************************
        '************************************************
        '出荷計画(選択されたもの)       取得
        '************************************************
        Dim objAryXPLN_OUT_CHECK_Oya(0) As TBL_XPLN_OUT
        For Each strXORDER_NO As String In strAryXORDER_NO
            '(ﾙｰﾌﾟ:選択された発注№)

            Dim objAryXPLN_OUT_CHECK_Kodomo As New TBL_XPLN_OUT(gobjOwner, gobjDb, Nothing)
            objAryXPLN_OUT_CHECK_Kodomo.XORDER_NO = strXORDER_NO
            objAryXPLN_OUT_CHECK_Kodomo.GET_XPLN_OUT_ANY()
            For Each objXPLN_OUT_CHECK_Kodomo As TBL_XPLN_OUT In objAryXPLN_OUT_CHECK_Kodomo.ARYME
                '(ﾙｰﾌﾟ:取得したﾚｺｰﾄﾞ数)

                '配列再定義
                If IsNull(objAryXPLN_OUT_CHECK_Oya(0)) Then
                    'NOP
                Else
                    ReDim Preserve objAryXPLN_OUT_CHECK_Oya(UBound(objAryXPLN_OUT_CHECK_Oya) + 1)
                End If

                'ｾｯﾄ
                objAryXPLN_OUT_CHECK_Oya(UBound(objAryXPLN_OUT_CHECK_Oya)) = objXPLN_OUT_CHECK_Kodomo

            Next

        Next


        If intRet = RetCode.OK Then
            '(見つかった場合)
            For Each objXPLN_OUT As TBL_XPLN_OUT In objAryXPLN_OUT_CHECK_Oya
                '(ﾙｰﾌﾟ:出荷計画の取得件数)
                '************************
                '出荷計画詳細　特定
                '************************
                Dim objXPLN_OUT_DTL_CHECK_ANY As New TBL_XPLN_OUT_DTL(gobjOwner, gobjDb, Nothing)
                objXPLN_OUT_DTL_CHECK_ANY.XSYUKKA_NO = objXPLN_OUT.XSYUKKA_NO       '出荷№
                intRet = objXPLN_OUT_DTL_CHECK_ANY.GET_XPLN_OUT_DTL_ANY()
                If intRet = RetCode.OK Then
                    '(見つかった場合)
                    For Each objXPLN_OUT_DTL As TBL_XPLN_OUT_DTL In objXPLN_OUT_DTL_CHECK_ANY.ARYME
                        '(ﾙｰﾌﾟ:出荷計画詳細の取得件数)
                        '************************
                        '在庫引当情報(仮1)　特定
                        '************************
                        Dim objXSTS_HIKIATE_K1_ANY As New TBL_XSTS_HIKIATE_K1(gobjOwner, gobjDb, Nothing)
                        objXSTS_HIKIATE_K1_ANY.FPLAN_KEY = objXPLN_OUT_DTL.FPLAN_KEY                    '計画ｷｰ
                        intRet = objXSTS_HIKIATE_K1_ANY.GET_XSTS_HIKIATE_K1_ANY()
                        If intRet = RetCode.OK Then
                            For Each objXSTS_HIKIATE_K1 As TBL_XSTS_HIKIATE_K1 In objXSTS_HIKIATE_K1_ANY.ARYME
                                '(ﾙｰﾌﾟ:在庫引当情報(仮1)の取得件数)

                                If objXSTS_HIKIATE_K1.FTRK_BUF_NO = FTRK_BUF_NO_J9000 Then
                                    '(自動倉庫のとき)
                                    strXDSPWARITUKE_BERTH = XWARITUKE_BERTH_JWAIT

                                ElseIf objXSTS_HIKIATE_K1.FTRK_BUF_NO = FTRK_BUF_NO_J8000 Then
                                    '(ﾊﾞﾗ平置場のとき)
                                    strXDSPWARITUKE_BARA = XWARITUKE_BERTH_JWAIT

                                ElseIf objXSTS_HIKIATE_K1.FTRK_BUF_NO = FTRK_BUF_NO_J8001 Then
                                    '(1F平置場のとき)
                                    strXDSPWARITUKE_HIRA01 = XWARITUKE_BERTH_JWAIT

                                ElseIf objXSTS_HIKIATE_K1.FTRK_BUF_NO = FTRK_BUF_NO_J8100 Or _
                                       objXSTS_HIKIATE_K1.FTRK_BUF_NO = FTRK_BUF_NO_J8101 Or _
                                       objXSTS_HIKIATE_K1.FTRK_BUF_NO = FTRK_BUF_NO_J8102 Or _
                                       objXSTS_HIKIATE_K1.FTRK_BUF_NO = FTRK_BUF_NO_J8103 Or _
                                       objXSTS_HIKIATE_K1.FTRK_BUF_NO = FTRK_BUF_NO_J8104 Or _
                                       objXSTS_HIKIATE_K1.FTRK_BUF_NO = FTRK_BUF_NO_J8105 Or _
                                       objXSTS_HIKIATE_K1.FTRK_BUF_NO = FTRK_BUF_NO_J8106 Or _
                                       objXSTS_HIKIATE_K1.FTRK_BUF_NO = FTRK_BUF_NO_J8107 Or _
                                       objXSTS_HIKIATE_K1.FTRK_BUF_NO = FTRK_BUF_NO_J8108 Or _
                                       objXSTS_HIKIATE_K1.FTRK_BUF_NO = FTRK_BUF_NO_J8109 Then
                                    '(外部倉庫のとき)
                                    strXDSPWARITUKE_GAIBU = XWARITUKE_BERTH_JWAIT

                                End If

                            Next

                        End If

                    Next

                End If

            Next

        End If


    End Sub
#End Region

End Class
