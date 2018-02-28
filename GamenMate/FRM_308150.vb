'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】ﾄﾗｯｸ入門受付明細確認
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_308150
#Region "　共通変数　                               "

    Private mFlag_Form_Load As Boolean = True                   '画面展開ﾌﾗｸﾞ
    Private mFlag_GRID_CLEAR As Boolean = True                  'ｸﾞﾘｯﾄﾞｸﾘｱ済みﾌﾗｸﾞ

    Private mstrXDSPUKETUKE_DT As String                         '受付時間

    '検索条件用構造体
    Private mudtSEARCH_ITEM As New SEARCH_ITEM      '画面用

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
        'ﾃｷｽﾄﾎﾞｯｸｽｾｯﾄｱｯﾌﾟ
        '**********************************************************
        lblXCAR_NO_WARITUKE.Text = mstrXCAR_NO_WARITUKE             '受付車番

        '*********************************************
        ' ｸﾞﾘｯﾄﾞ初期化
        '*********************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListSetup()

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
        lblXCAR_NO_WARITUKE.Dispose()       '受付車番
        grdList.Dispose()                   'ｸﾞﾘｯﾄﾞ

    End Sub
#End Region
#Region "  F8(戻る)         ﾎﾞﾀﾝ押下処理　          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F8(戻る)         ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F8Process()

        '******************************************
        ' 画面遷移
        '******************************************
        'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_203000, Me)
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub
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
    '                                                                    FTRK_BUF_NO_J8101 & ", " & _
    '                                                                    FTRK_BUF_NO_J8102 & ", " & _
    '                                                                    FTRK_BUF_NO_J8103 & ", " & _
    '                                                                    FTRK_BUF_NO_J8104 & ", " & _
    '                                                                    FTRK_BUF_NO_J8105 & ", " & _
    '                                                                    FTRK_BUF_NO_J8106 & ", " & _
    '                                                                    FTRK_BUF_NO_J8107 & ", " & _
    '                                                                    FTRK_BUF_NO_J8108 & ", " & _
    '                                                                    FTRK_BUF_NO_J8109 & ") "       '自動倉庫1-10
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
    '            Else
    '                '(以外の時)
    '                grdList.Item(menmListCol.XSYUKKA_BERTH, ii).Value = 1
    '                grdList.Item(menmListCol.XSYUKKA_BERTH_DSP, ii).Value = "○"
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
    '        Else
    '            '(平置きに出荷ない時)
    '            If intASOUKO_CNT = intASOUKO_TO_BARA_CNT Then
    '                '(自動倉庫から出庫の在庫が、ﾊﾞﾗ補充分と同じ数の時[ﾊﾞﾗのみ])
    '                '平置きをｸﾘｱしない
    '            Else
    '                '(平置きｸﾘｱの時)
    '                grdList.Item(menmListCol.XHIRA1, ii).Value = 0
    '                grdList.Item(menmListCol.XHIRA1_DSP, ii).Value = "　"
    '            End If
    '        End If

    '        If (intASOUKO_CNT = 0) And _
    '           (intHIRA1_CNT = 0) Then
    '            '(出荷ﾊﾞｰｽと平置き１に出荷ない時)
    '            If intBARA_CNT > 0 Then
    '                '(バラ平置きに出荷ある時)
    '                grdList.Item(menmListCol.XHIRA1, ii).Value = 1
    '                grdList.Item(menmListCol.XHIRA1_DSP, ii).Value = "○"
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


    'End Sub
#End Region
#Region "　出荷ﾊﾞｰｽ～外部倉庫「○」表示設定         "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub SET_TAHINMOK_DSP()

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
                Else
                    '(以外の時)
                    grdList.Item(menmListCol.XSYUKKA_BERTH, ii).Value = 1
                    grdList.Item(menmListCol.XSYUKKA_BERTH_DSP, ii).Value = "○"
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

End Class
