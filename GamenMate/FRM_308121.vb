'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】引当情報詳細問合せ画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_308121

#Region "　共通変数　                               "

    Private mstrFPLACE_CD As String                     '保管場所
    Private mstrFHINMEI_CD As String                    '品名ｺｰﾄﾞ
    Private mstrXSEIZOU_DT As String                    '製造年月日
    Private mstrXHINSHITU_STS As String                 '品質ｽﾃｰﾀｽ

    Private mFlag_Form_Load As Boolean = True                   '画面展開ﾌﾗｸﾞ

    Private mobjOwner As FRM_308120      'ｵｰﾅｰﾌｫｰﾑ

    'ｸﾞﾘｯﾄﾞ項目
    Enum menmListCol

        FTRK_BUF_NO                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ   .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        FBUF_NAME                   'ﾄﾗｯｷﾝｸﾞﾏｽﾀ     .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称
        FHINMEI_CD                  '出荷計画詳細   .品名ｺｰﾄﾞ
        FHINMEI                     '出荷計画詳細   .品名
        XSEIZOU_DT                  '在庫情報_仮1   .製造年月日
        XHINSHITU_STS               '出荷計画詳細   .品質ｽﾃｰﾀｽ
        XHINSHITU_STS_DSP           '出荷計画詳細   .品質ｽﾃｰﾀｽ(表示用)
        XNYUKA_JIGYOU_NM            '出荷計画       .入荷事業所名
        XSYUKKKA_NO                 '出荷計画詳細   .出荷№
        XORDER_NO                   '出荷計画       .発注№
        XSYUKKA_DT                  '出荷計画       .出荷日
        XSYUKKKA_VOL                '出荷計画詳細   .出荷数

        MAXCOL                      'ｸﾞﾘｯﾄﾞの列数の最大値

    End Enum

    '入力ﾁｪｯｸ場合判別
    Enum menmCheckCase
        XXXXBtn_Click                 'XXXXﾎﾞﾀﾝｸﾘｯｸ
    End Enum

#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ                                  "
    '======================================
    ' ｵｰﾅｰﾌｫｰﾑ
    '======================================
    Public Property userOWNER() As FRM_308120
        Get
            Return mobjOwner
        End Get
        Set(ByVal Value As FRM_308120)
            mobjOwner = Value
        End Set
    End Property
    '======================================
    ' 保管場所ｺｰﾄﾞ
    '======================================
    Public Property userFPLACE_CD() As String
        Get
            Return mstrFPLACE_CD
        End Get
        Set(ByVal value As String)
            mstrFPLACE_CD = value
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
    '======================================
    ' 品質ｽﾃｰﾀｽ
    '======================================
    Public Property userXHINSHITU_STS() As String
        Get
            Return mstrXHINSHITU_STS
        End Get
        Set(ByVal value As String)
            mstrXHINSHITU_STS = value
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
        strSQL &= vbCrLf & "       TPRG_TRK_BUF.FTRK_BUF_NO "                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ   .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        strSQL &= vbCrLf & "     , TMST_TRK.FBUF_NAME "                          'ﾄﾗｯｷﾝｸﾞﾏｽﾀ     .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称
        strSQL &= vbCrLf & "     , XPLN_OUT_DTL.FHINMEI_CD "                     '出荷計画詳細   .品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "     , XPLN_OUT_DTL.FHINMEI "                        '出荷計画詳細   .品名
        strSQL &= vbCrLf & "     , XRST_STOCK_K1.XSEIZOU_DT "                    '在庫情報_仮1   .製造年月日
        strSQL &= vbCrLf & "     , XPLN_OUT_DTL.XHINSHITU_STS "                  '出荷計画詳細   .品質ｽﾃｰﾀｽ
        strSQL &= vbCrLf & "     , HASH01.FGAMEN_DISP AS XHINSHITU_STS_DSP "     '出荷計画詳細   .品質ｽﾃｰﾀｽ(表示用)
        strSQL &= vbCrLf & "     , XPLN_OUT.XNYUKA_JIGYOU_NM "                   '出荷計画       .入荷事業所名
        strSQL &= vbCrLf & "     , XPLN_OUT_DTL.XSYUKKA_NO "                     '出荷計画詳細   .出荷№
        strSQL &= vbCrLf & "     , XPLN_OUT.XORDER_NO "                          '出荷計画       .発注№
        strSQL &= vbCrLf & "     , TO_DATE(XPLN_OUT.XSYUKKA_DT, 'YYYY/MM/DD') AS XSYUKKA_DT  " '出荷計画       .出荷日

        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:A.Noto 2012/12/10 数量を合計する
        'strSQL &= vbCrLf & "     , XSTS_HIKIATE_K1.FTR_VOL "                     '在庫引当情報_仮1  .搬送管理量 
        strSQL &= vbCrLf & "     , SUM(XSTS_HIKIATE_K1.FTR_VOL) "                 '在庫引当情報_仮1  .搬送管理量 
        '↑↑↑↑↑↑************************************************************************************************************

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "       XPLN_OUT "
        strSQL &= vbCrLf & "     , XPLN_OUT_DTL "
        strSQL &= vbCrLf & "     , XSTS_HIKIATE_K1 "
        strSQL &= vbCrLf & "     , XRST_STOCK_K1 "
        strSQL &= vbCrLf & "     , TPRG_TRK_BUF "
        strSQL &= vbCrLf & "     , TMST_TRK "
        strSQL &= vbCrLf & "     , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH01", "XPLN_OUT_DTL", "XHINSHITU_STS")

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE 0 = 0 "
        strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XSYUKKA_NO        = XPLN_OUT.XSYUKKA_NO(+) "
        strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.FPLAN_KEY         = XSTS_HIKIATE_K1.FPLAN_KEY(+) "
        strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K1.FPALLET_ID     = XRST_STOCK_K1.FPALLET_ID(+) "
        strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K1.FLOT_NO_STOCK  = XRST_STOCK_K1.FLOT_NO_STOCK(+) "
        strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K1.FPALLET_ID     = TPRG_TRK_BUF.FPALLET_ID(+) "
        strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FTRK_BUF_NO       = TMST_TRK.FTRK_BUF_NO(+) "
        strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XPROGRESS_OUT     = " & XPROGRESS_OUT_JHIKIATE     '進捗状態：引当済み
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH01", "XPLN_OUT_DTL", "XHINSHITU_STS")


        '----------------------------------------------
        '保管場所
        '----------------------------------------------
        If mstrFPLACE_CD <> "" Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FTRK_BUF_NO = " & mstrFPLACE_CD
        Else
            '(全検索の場合)
            strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FTRK_BUF_NO IN(" & FTRK_BUF_NO_J9000
            strSQL &= vbCrLf & "                                  , " & FTRK_BUF_NO_J8000
            strSQL &= vbCrLf & "                                  , " & FTRK_BUF_NO_J8001
            strSQL &= vbCrLf & "                                  , " & FTRK_BUF_NO_J8002
            strSQL &= vbCrLf & "                                  , " & FTRK_BUF_NO_J8100
            strSQL &= vbCrLf & "                                  , " & FTRK_BUF_NO_J8101
            strSQL &= vbCrLf & "                                  , " & FTRK_BUF_NO_J8102
            strSQL &= vbCrLf & "                                  , " & FTRK_BUF_NO_J8103
            strSQL &= vbCrLf & "                                  , " & FTRK_BUF_NO_J8104
            strSQL &= vbCrLf & "                                  , " & FTRK_BUF_NO_J8105
            strSQL &= vbCrLf & "                                  , " & FTRK_BUF_NO_J8106
            strSQL &= vbCrLf & "                                  , " & FTRK_BUF_NO_J8107
            strSQL &= vbCrLf & "                                  , " & FTRK_BUF_NO_J8108
            strSQL &= vbCrLf & "                                  , " & FTRK_BUF_NO_J8109
            strSQL &= vbCrLf & "                                  , " & FTRK_BUF_NO_J8201
            strSQL &= vbCrLf & "                                  , " & FTRK_BUF_NO_J8202
            strSQL &= vbCrLf & "                                  , " & FTRK_BUF_NO_J8203
            strSQL &= vbCrLf & "                                  , " & FTRK_BUF_NO_J8204
            strSQL &= vbCrLf & "                                  , " & FTRK_BUF_NO_J8205
            strSQL &= vbCrLf & "                                  , " & FTRK_BUF_NO_J8206
            strSQL &= vbCrLf & "                                  , " & FTRK_BUF_NO_J8207
            strSQL &= vbCrLf & "                                  , " & FTRK_BUF_NO_J8208
            strSQL &= vbCrLf & "                                   ) "
        End If

        '----------------------------------------------
        '品名ｺｰﾄﾞ
        '----------------------------------------------
        If mstrFHINMEI_CD <> "" Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "    AND XPLN_OUT_DTL.FHINMEI_CD LIKE '" & mstrFHINMEI_CD & "%' "
        End If

        '----------------------------------------------
        '製造年月日
        '----------------------------------------------
        If mstrXSEIZOU_DT <> "" Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "    AND XRST_STOCK_K1.XSEIZOU_DT = TO_DATE('" & mstrXSEIZOU_DT & " 00:00:00','YYYY/MM/DD HH24:MI:SS')"
        End If

        '----------------------------------------------
        '品質ｽﾃｰﾀｽ
        '----------------------------------------------
        If mstrXHINSHITU_STS <> "" Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "    AND XPLN_OUT_DTL.XHINSHITU_STS = " & mstrXHINSHITU_STS
        End If



        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:A.Noto 2012/12/10 ｸﾞﾙｰﾌﾟ化する
        '============================================================
        'GROUP BY
        '============================================================
        strSQL &= vbCrLf & "   GROUP BY "
        strSQL &= vbCrLf & "         TPRG_TRK_BUF.FTRK_BUF_NO "
        strSQL &= vbCrLf & "       , TMST_TRK.FBUF_NAME "
        strSQL &= vbCrLf & "       , XPLN_OUT_DTL.FHINMEI_CD "
        strSQL &= vbCrLf & "       , XPLN_OUT_DTL.FHINMEI "
        strSQL &= vbCrLf & "       , XRST_STOCK_K1.XSEIZOU_DT "
        strSQL &= vbCrLf & "       , XPLN_OUT_DTL.XHINSHITU_STS "
        strSQL &= vbCrLf & "       , HASH01.FGAMEN_DISP "
        strSQL &= vbCrLf & "       , XPLN_OUT.XNYUKA_JIGYOU_NM "
        strSQL &= vbCrLf & "       , XPLN_OUT_DTL.XSYUKKA_NO "
        strSQL &= vbCrLf & "       , XPLN_OUT.XORDER_NO "
        strSQL &= vbCrLf & "       , XPLN_OUT.XSYUKKA_DT "
        '↑↑↑↑↑↑************************************************************************************************************


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
#Region "　入力ﾁｪｯｸ　                               "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】 [ IN  ]　入力ﾁｪｯｸ判別
    '【戻値】 True :入力ﾁｪｯｸ成功
    '         False:入力ﾁｪｯｸ失敗
    '*******************************************************************************************************************
    Public Function InputCheck(ByVal udtCheck_Case As menmCheckCase) As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        Select Case udtCheck_Case
            Case menmCheckCase.XXXXBtn_Click
                '(XXXXﾎﾞﾀﾝｸﾘｯｸ時)

                ''==========================
                ''ﾘｽﾄ　表示ﾃﾞｰﾀﾁｪｯｸ
                ''==========================
                'If grdList.Rows.Count <= 0 Then
                '    '(ﾃﾞｰﾀが一行もない場合)
                '    Exit Function
                'End If


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

End Class
