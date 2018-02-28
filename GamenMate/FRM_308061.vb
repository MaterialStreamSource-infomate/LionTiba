'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】製品移動出荷指示詳細画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_308061

#Region "　共通変数　                               "

    Private mstrXSYUKKA_NO As String                     '出荷№
    Private mstrXSYUKKA_DT As String                     '出荷日

    Private mFlag_Form_Load As Boolean = True                   '画面展開ﾌﾗｸﾞ

    'ｸﾞﾘｯﾄﾞ項目
    Enum menmListCol

        XSYUKKA_NO                  '出荷計画           .出荷№
        XPLN_OUT_ID                 '出荷計画           . 出荷計画ID(非表示)
        XSYUKKA_DT                  '出荷計画           .出荷日
        FHINMEI_CD                  '出荷計画詳細       .品名ｺｰﾄﾞ
        FHINMEI                     '出荷計画詳細       .品名
        XHINSHITU_STS               '出荷計画詳細       .品質ｽﾃｰﾀｽ
        XHINSHITU_STS_DSP           '出荷計画詳細       .品質ｽﾃｰﾀｽ(表示用)
        XHIDUKE_SITEI_KUBUN         '出荷計画詳細       .日付指定区分
        XHIDUKE_SITEI_KUBUN_DSP     '出荷計画詳細       .日付指定区分
        XSEIZOU_DT                  '出荷計画詳細       .製造年月日
        XSYUKKA_VOL                 '出荷計画詳細       .出荷数
        XWEIGHT                     '出荷計画詳細       .重量
        FDECIMAL_POINT              '品目ﾏｽﾀ            .小数点以下有効桁数
        '*nasi* XNISUGATA                   '出荷計画詳細       .荷姿

        MAXCOL                      'ｸﾞﾘｯﾄﾞの列数の最大値

    End Enum


#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ                                  "
    '======================================
    ' 出荷№
    '======================================
    Public Property userSYUKKA_NO() As String
        Get
            Return mstrXSYUKKA_NO
        End Get
        Set(ByVal value As String)
            mstrXSYUKKA_NO = value
        End Set
    End Property

    '======================================
    ' 出荷日
    '======================================
    Public Property userSYUKKA_DT() As String
        Get
            Return mstrXSYUKKA_DT
        End Get
        Set(ByVal value As String)
            mstrXSYUKKA_DT = value
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
        strSQL &= vbCrLf & "       XPLN_OUT.XSYUKKA_NO "                             '出荷計画           .出荷№
        strSQL &= vbCrLf & "     , XPLN_OUT.XPLN_OUT_ID "                            '出荷計画           .出荷計画ID(非表示)
        strSQL &= vbCrLf & "     , TO_DATE(XPLN_OUT.XSYUKKA_DT, 'YYYY/MM/DD') "      '出荷計画           .出荷日"
        strSQL &= vbCrLf & "     , XPLN_OUT_DTL.FHINMEI_CD "                         '出荷計画詳細       .品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "     , XPLN_OUT_DTL.FHINMEI "                            '出荷計画詳細       .品名_正式名
        strSQL &= vbCrLf & "     , XPLN_OUT_DTL.XHINSHITU_STS "                      '出荷計画詳細       .品質ｽﾃｰﾀｽ
        strSQL &= vbCrLf & "     , HASH01.FGAMEN_DISP AS XHINSHITU_STS_DSP "         '出荷計画詳細       .品質ｽﾃｰﾀｽ(表示用)
        strSQL &= vbCrLf & "     , XPLN_OUT_DTL.XHIDUKE_SITEI_KUBUN "                '出荷計画詳細       .日付指定区分
        strSQL &= vbCrLf & "     , HASH02.FGAMEN_DISP AS XHIDUKE_SITEI_KUBUN_DSP "   '出荷計画詳細       .日付指定区分(表示用)
        strSQL &= vbCrLf & "     , XPLN_OUT_DTL.XSEIZOU_DT "                         '出荷計画詳細       .製造年月日
        strSQL &= vbCrLf & "     , (XPLN_OUT_DTL.XSYUKKA_VOL + XPLN_OUT_DTL.XSYUKKA_VOL_BARA) "  '出荷計画詳細       .出荷数 + ﾊﾞﾗ出荷数
        strSQL &= vbCrLf & "     , XPLN_OUT_DTL.XWEIGHT "                            '出荷計画詳細       .重量
        strSQL &= vbCrLf & "     , TMST_ITEM.FDECIMAL_POINT "                        '品目ﾏｽﾀ            .小数点以下有効桁数

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "       XPLN_OUT "
        strSQL &= vbCrLf & "     , XPLN_OUT_DTL "
        strSQL &= vbCrLf & "     , TMST_ITEM "
        strSQL &= vbCrLf & "     , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH01", "XPLN_OUT_DTL", "XHINSHITU_STS")
        strSQL &= vbCrLf & "     , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH02", "XPLN_OUT_DTL", "XHIDUKE_SITEI_KUBUN")

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE 0 = 0 "
        strSQL &= vbCrLf & "     AND XPLN_OUT.XPLN_OUT_ID    = " & XPLN_OUT_ID_JSEIHIN      '製品移動出荷計画
        strSQL &= vbCrLf & "     AND XPLN_OUT.XSYUKKA_NO     = XPLN_OUT_DTL.XSYUKKA_NO "
        strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.FHINMEI_CD = TMST_ITEM.FHINMEI_CD "
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH01", "XPLN_OUT_DTL", "XHINSHITU_STS")
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH02", "XPLN_OUT_DTL", "XHIDUKE_SITEI_KUBUN")

        '----------------------------------------------
        '出荷№
        '----------------------------------------------
        If mstrXSYUKKA_NO <> "" Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "    AND XPLN_OUT_DTL.XSYUKKA_NO = '" & mstrXSYUKKA_NO & "' "
        End If

        '----------------------------------------------
        '出荷日
        '----------------------------------------------
        If mstrXSYUKKA_DT <> "" Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "    AND XPLN_OUT.XSYUKKA_DT = '" & mstrXSYUKKA_DT & "' "
        End If


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
        '重量小数点表示
        '************************************************
        Call gobjComFuncFRM.GridFTR_VOLChange01(grdList, menmListCol.XWEIGHT, menmListCol.FDECIMAL_POINT)

        '************************************************
        'ｸﾞﾘｯﾄﾞﾏｽﾀの定義を反映
        '************************************************
        Call gobjComFuncFRM.TDSP_GRIDSetup(Me, grdList)

    End Sub
#End Region

End Class
