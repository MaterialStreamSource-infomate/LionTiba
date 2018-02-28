'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】出荷実績問合せ詳細画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_304021

#Region "　共通変数　                               "

    Private mstrXSYUKKA_NO As String               '出荷№
    '↓↓↓↓ 2012.11.30 10:30 H.Morita 同一出荷№+異なる出荷明細№+同一品目の時の検品対応
    Private mstrXPLN_DTL_NO As String              '計画明細№
    '↑↑↑↑ 2012.11.30 10:30 H.Morita 同一出荷№+異なる出荷明細№+同一品目の時の検品対応
    Private mstrXSYUKKA_DT As String               '出荷日
    Private mstrXCAR_NO_WARITUKE As String         '受付車番
    Private mstrXCAR_NO_EDA_WARITUKE As String     '枝番
    Private mstrXNYUKA_JIGYOU_NM As String         '配送先
    Private mstrXORDER_NO As String                '発注№
    Private mstrFHINMEI_CD As String               '品名ｺｰﾄﾞ
    Private mstrFHINMEI As String                  '品名
    Private mstrFTRK_BUF_NO As String              '出荷場所(ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№)
    Private mstrFBUF_NAME As String                '出荷場所
    Private mstrXSEIZOU_DT As String               '製造年月日

    Private mFlag_Form_Load As Boolean = True                   '画面展開ﾌﾗｸﾞ

    'ｸﾞﾘｯﾄﾞ項目
    Enum menmListCol

        XSYUKKA_NO                  '出荷実績.   出荷№(非表示)
        XPLN_DTL_NO                 '出荷実績.   計画明細№(非表示)
        XLINE_NO                    '出荷実績.   ﾗｲﾝ№
        XPALLET_NO                  '出荷実績.   ﾊﾟﾚｯﾄ№
        'XKENPIN_FLAG                '出荷実績.   検品済ﾌﾗｸﾞ
        'XKENPIN_FLAG_DSP            '出荷実績.   検品済ﾌﾗｸﾞ(表示用)
        XSYUKKA_STS                 '出荷実績.   出荷詳細状況
        XSYUKKA_STS_DSP             '出荷実績.   出荷詳細状況(表示用)
        FTR_VOL                     '出荷実績.   出荷数
        SYUKKO_SU                   '            出庫数
        XSYUKKA_KENPIN_VOL          '出荷実績.   出荷検品数
        FUSER_NAME                  '出荷実績.   検品者
        FENTRY_DT                   '出荷実績.   検品日時
        XKENPIN_FLAG                '出荷実績.          検品済みﾌﾗｸﾞ(非表示)

        MAXCOL                      'ｸﾞﾘｯﾄﾞの列数の最大値

    End Enum


#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ                                  "
    '======================================
    ' 出荷№
    '======================================
    Public Property userXSYUKKA_NO() As String
        Get
            Return mstrXSYUKKA_NO
        End Get
        Set(ByVal value As String)
            mstrXSYUKKA_NO = value
        End Set
    End Property

    '↓↓↓↓ 2012.11.30 10:30 H.Morita 同一出荷№+異なる出荷明細№+同一品目の時の検品対応
    '======================================
    ' 計画明細№
    '======================================
    Public Property userXPLN_DTL_NO() As String
        Get
            Return mstrXPLN_DTL_NO
        End Get
        Set(ByVal value As String)
            mstrXPLN_DTL_NO = value
        End Set
    End Property
    '↑↑↑↑ 2012.11.30 10:30 H.Morita 同一出荷№+異なる出荷明細№+同一品目の時の検品対応

    '======================================
    ' 出荷日
    '======================================
    Public Property userXSYUKKA_DT() As String
        Get
            Return mstrXSYUKKA_DT
        End Get
        Set(ByVal value As String)
            mstrXSYUKKA_DT = value
        End Set
    End Property

    '======================================
    ' 受付車番
    '======================================
    Public Property userXCAR_NO_WARITUKE() As String
        Get
            Return mstrXCAR_NO_WARITUKE
        End Get
        Set(ByVal value As String)
            mstrXCAR_NO_WARITUKE = value
        End Set
    End Property

    '======================================
    ' 枝番
    '======================================
    Public Property userXCAR_NO_EDA_WARITUKE() As String
        Get
            Return mstrXCAR_NO_EDA_WARITUKE
        End Get
        Set(ByVal value As String)
            mstrXCAR_NO_EDA_WARITUKE = value
        End Set
    End Property

    '======================================
    ' 配送先
    '======================================
    Public Property userXNYUKA_JIGYOU_NM() As String
        Get
            Return mstrXNYUKA_JIGYOU_NM
        End Get
        Set(ByVal value As String)
            mstrXNYUKA_JIGYOU_NM = value
        End Set
    End Property

    '======================================
    ' 発注№
    '======================================
    Public Property userXORDER_NO() As String
        Get
            Return mstrXORDER_NO
        End Get
        Set(ByVal value As String)
            mstrXORDER_NO = value
        End Set
    End Property

    '======================================
    ' 品名ｺｰﾄﾞ
    '======================================
    Public Property userFHINMEI_CD() As String
        Get
            Return mstrFHINMEI_CD
        End Get
        Set(ByVal value As String)
            mstrFHINMEI_CD = value
        End Set
    End Property

    '======================================
    ' 品名
    '======================================
    Public Property userFHINMEI() As String
        Get
            Return mstrFHINMEI
        End Get
        Set(ByVal value As String)
            mstrFHINMEI = value
        End Set
    End Property

    '======================================
    ' 出荷場所(ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№)
    '======================================
    Public Property userFTRK_BUF_NO() As String
        Get
            Return mstrFTRK_BUF_NO
        End Get
        Set(ByVal value As String)
            mstrFTRK_BUF_NO = value
        End Set
    End Property

    '======================================
    ' 出荷場所
    '======================================
    Public Property userFBUF_NAME() As String
        Get
            Return mstrFBUF_NAME
        End Get
        Set(ByVal value As String)
            mstrFBUF_NAME = value
        End Set
    End Property

    '======================================
    ' 製造年月日
    '======================================
    Public Property userXSEIZOU_DT() As String
        Get
            Return mstrXSEIZOU_DT
        End Get
        Set(ByVal value As String)
            mstrXSEIZOU_DT = value
        End Set
    End Property

#End Region
#Region "  ｲﾍﾞﾝﾄ                                    "

#End Region
#Region "　ﾌｫｰﾑﾛｰﾄﾞ                                 "
    Public Overrides Sub InitializeChild()

        '**********************************************************
        ' ﾎﾞﾀﾝﾏｽｸ設定
        '**********************************************************
        Call CmdEnabledChangeMenu()                             'Menuﾎﾞﾀﾝ全般
        Call CmdEnabledChange(cmdClose, False)                  'ﾛｸﾞｵﾌﾎﾞﾀﾝ
        Call CmdEnabledChange(cmdMsgChk, False)                 'ｱﾅｼｴｰﾀﾎﾞﾀﾝ

        '*********************************************
        ' ﾃｷｽﾄﾎﾞｯｸｽ初期設定
        '*********************************************
        lblXSYUKKA_DT.Text = Mid(mstrXSYUKKA_DT, 1, 4) & "/" & Mid(mstrXSYUKKA_DT, 5, 2) & "/" & Mid(mstrXSYUKKA_DT, 7, 2)     '出荷日
        lblCAR_NO_WARITUKE.Text = mstrXCAR_NO_WARITUKE & " - " & mstrXCAR_NO_EDA_WARITUKE      '受付車番
        lblXNYUKA_JIGYOU_NM.Text = mstrXNYUKA_JIGYOU_NM     '配送先
        lblXORDER_NO.Text = mstrXORDER_NO                   '発注№
        lblFHINMEI_CD.Text = mstrFHINMEI_CD                 '品名ｺｰﾄﾞ
        lblFHINMEI.Text = mstrFHINMEI                       '品名
        lblFBUF_NAME.Text = mstrFBUF_NAME                   '出荷場所
        lblXSEIZOU_DT.Text = mstrXSEIZOU_DT                 '製造年月日

        '**********************************************************
        ' ﾘｽﾄ表示
        '**********************************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListDisplaySub(grdList)

        mFlag_Form_Load = False

    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ                               "
    Public Overrides Sub CloseChild()

        '******************************************
        ' ｺﾝﾄﾛｰﾙの開放
        '******************************************
        grdList.Dispose()               'ｸﾞﾘｯﾄﾞ

    End Sub
#End Region
#Region "  F8  ﾎﾞﾀﾝ押下処理　                       "
    '*******************************************************************************************************************
    '【機能】F8  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F8Process()

        Me.Close()

    End Sub
#End Region
#Region "　ﾘｽﾄ表示　                                "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub grdListDisplayChild()


        Dim strSQL As String                        'SQL文


        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "    XSYUKKA_NO "                                 '出荷実績.   出荷№(非表示)
        strSQL &= vbCrLf & "  , XPLN_DTL_NO "                                '出荷実績.   計画明細№(非表示)
        strSQL &= vbCrLf & "  , XLINE_NO "                                   '出荷実績.   ﾗｲﾝ№
        strSQL &= vbCrLf & "  , XPALLET_NO "                                 '出荷実績.   ﾊﾟﾚｯﾄ№
        strSQL &= vbCrLf & "  , CASE WHEN XKENPIN_FLAG = " & XKENPIN_FLAG_JKYOUSEI & " THEN '4' "
        strSQL &= vbCrLf & "         WHEN ((SYUKKA_SU - (NVL(SYUKKO_SU, 0) + KENPIN_SU)) > 0) AND (FTRK_BUF_NO NOT IN (" & FTRK_BUF_NO_J8000 & ", " & FTRK_BUF_NO_J8001 & ", " & FTRK_BUF_NO_J8002 & ")) THEN '1' "
        strSQL &= vbCrLf & "         WHEN XKENPIN_FLAG = " & XKENPIN_FLAG_JON & " THEN '3' "
        strSQL &= vbCrLf & "         ELSE '2' "
        strSQL &= vbCrLf & "    END AS XSYUKKA_STS "                         '出荷詳細状況
        strSQL &= vbCrLf & "  , CASE WHEN XKENPIN_FLAG = " & XKENPIN_FLAG_JKYOUSEI & " THEN '強制完了' "
        strSQL &= vbCrLf & "         WHEN ((SYUKKA_SU - (NVL(SYUKKO_SU, 0) + KENPIN_SU)) > 0) AND (FTRK_BUF_NO NOT IN (" & FTRK_BUF_NO_J8000 & ", " & FTRK_BUF_NO_J8001 & ", " & FTRK_BUF_NO_J8002 & ")) THEN '出庫中' "
        strSQL &= vbCrLf & "         WHEN XKENPIN_FLAG = " & XKENPIN_FLAG_JON & " THEN '検品完了' "
        strSQL &= vbCrLf & "         ELSE '検品中' "
        strSQL &= vbCrLf & "    END AS XSYUKKA_STS_DSP "                     '出荷詳細状況(表示用)
        strSQL &= vbCrLf & "  , SYUKKA_SU "                                  '出荷実績.   出荷数
        strSQL &= vbCrLf & "  , NVL(SYUKKO_SU, 0) "                          '出庫数
        strSQL &= vbCrLf & "  , KENPIN_SU "                                  '出荷実績.   出荷検品数
        strSQL &= vbCrLf & "  , FUSER_NAME "                                 '出荷実績.   検品者
        'strSQL &= vbCrLf & "  , FENTRY_DT "                                  '出荷実績.   検品日時
        strSQL &= vbCrLf & "  , FUPDATE_DT "                                 '出荷実績.   更新日時(検品日時)
        strSQL &= vbCrLf & "  , FTRK_BUF_NO "                                '出荷実績.   ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№(非表示)
        strSQL &= vbCrLf & "  , XKENPIN_FLAG "                               '出荷実績.   検品済みﾌﾗｸﾞ(非表示)
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "  ( "
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "    XRST_OUT.XSYUKKA_NO "                        '出荷実績.   出荷№(非表示)
        strSQL &= vbCrLf & "  , XRST_OUT.XPLN_DTL_NO "                       '出荷実績.   計画明細№(非表示)
        strSQL &= vbCrLf & "  , XRST_OUT.XLINE_NO "                          '出荷実績.   ﾗｲﾝ№
        strSQL &= vbCrLf & "  , XRST_OUT.XPALLET_NO "                        '出荷実績.   ﾊﾟﾚｯﾄ№
        strSQL &= vbCrLf & "  , '' AS XSYUKKA_STS "                          '            出荷詳細状況
        strSQL &= vbCrLf & "  , '' AS XSYUKKA_STS_DSP "                      '            出荷詳細状況(表示用)
        strSQL &= vbCrLf & "  , XRST_OUT.FTR_VOL AS SYUKKA_SU "              '出荷実績.   出荷数
        strSQL &= vbCrLf & "  , ( "
        strSQL &= vbCrLf & "     SELECT "
        strSQL &= vbCrLf & "         NVL(TRST_STOCK.FTR_RES_VOL, 0) "
        strSQL &= vbCrLf & "     FROM "
        strSQL &= vbCrLf & "        TRST_STOCK "
        strSQL &= vbCrLf & "      , TPRG_TRK_BUF "
        strSQL &= vbCrLf & "     WHERE (0 = 0) "
        'strSQL &= vbCrLf & "      AND XRST_OUT.FPALLET_ID     = TPRG_TRK_BUF.FPALLET_ID "
        strSQL &= vbCrLf & "      AND NVL(XRST_OUT.XPALLET_ID_CHECK, XRST_OUT.XPALLET_ID_KARI) = TPRG_TRK_BUF.FPALLET_ID "
        strSQL &= vbCrLf & "      AND NVL(TMST_TRK.XTRK_BUF_NO_OUT_HIRA,TMST_TRK.FTRK_BUF_NO)  = TPRG_TRK_BUF.FTRK_BUF_NO "
        strSQL &= vbCrLf & "      AND TPRG_TRK_BUF.FPALLET_ID = TRST_STOCK.FPALLET_ID "
        strSQL &= vbCrLf & "    )                           AS SYUKKO_SU "
        strSQL &= vbCrLf & "  , XRST_OUT.XSYUKKA_KENPIN_VOL AS KENPIN_SU "   '出荷実績.   出荷検品数
        strSQL &= vbCrLf & "  , XRST_OUT.FUSER_NAME "                        '出荷実績.   検品者
        'strSQL &= vbCrLf & "  , XRST_OUT.FENTRY_DT "                         '出荷実績.   検品日時
        strSQL &= vbCrLf & "  , XRST_OUT.FUPDATE_DT "                        '出荷実績.   更新日時(検品日時)
        strSQL &= vbCrLf & "  , XRST_OUT.FTRK_BUF_NO "                       '出荷実績.   ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№(非表示)
        strSQL &= vbCrLf & "  , XRST_OUT.XKENPIN_FLAG "                      '出荷実績.   検品済みﾌﾗｸﾞ(非表示)

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    XRST_OUT "
        strSQL &= vbCrLf & "  , TMST_TRK "

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE 0 = 0 "
        strSQL &= vbCrLf & "  AND XRST_OUT.XSYUKKA_NO  = '" & mstrXSYUKKA_NO & "' "       '出荷№
        '↓↓↓↓ 2012.11.30 10:30 H.Morita 同一出荷№+異なる出荷明細№+同一品目の時の検品対応
        strSQL &= vbCrLf & "  AND XRST_OUT.XPLN_DTL_NO = '" & mstrXPLN_DTL_NO & "' "      '計画明細№
        '↑↑↑↑ 2012.11.30 10:30 H.Morita 同一出荷№+異なる出荷明細№+同一品目の時の検品対応
        strSQL &= vbCrLf & "  AND XRST_OUT.FHINMEI_CD  LIKE '" & mstrFHINMEI_CD & "%' "   '品目ｺｰﾄﾞ
        strSQL &= vbCrLf & "  AND XRST_OUT.XSEIZOU_DT  = '" & mstrXSEIZOU_DT & "' "       '製造年月日
        strSQL &= vbCrLf & "  AND XRST_OUT.FTRK_BUF_NO = '" & mstrFTRK_BUF_NO & "' "      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
        strSQL &= vbCrLf & "  AND XRST_OUT.FTRK_BUF_NO = TMST_TRK.FTRK_BUF_NO(+) "

        strSQL &= vbCrLf & "  ) A "

        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & gobjComFuncFRM.GetSQL_TDSP_GRID_OrderBy(Me, grdList)
        strSQL &= vbCrLf


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        Call gobjComFuncFRM.TblDataGridDisplay(grdList, _
                                strSQL, _
                                True)


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdListSetup()
        Call gobjComFuncFRM.GridSelect(grdList, -1, -1, Nothing)      'ｸﾞﾘｯﾄﾞ選択処理


    End Sub
#End Region
#Region "  ﾘｽﾄ表示設定　                            "
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

    End Sub
#End Region

End Class
