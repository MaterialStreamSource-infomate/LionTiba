'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】出荷実績問合せ画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_304020

#Region "　共通変数　                               "

    Protected mudtSEARCH_ITEM As New stcSEARCH_ITEM     '検索条件用構造体

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ

    '出荷№(8)+計画明細№(2)+ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№(出庫場所)(4)の配列
    Public mstrXSYUKKA_NO() As String = Nothing

    'ｸﾞﾘｯﾄﾞ項目
    Enum menmListCol

        XSYUKKA_NO                          '出荷計画.          出荷№(非表示)
        XPLN_DTL_NO                         '出荷計画明細.      計画明細№(非表示)
        XKENPIN_MIKAN                       '                   未検(SUM出荷数 - SUM検品数)
        XKENPIN_MIKAN_DSP                   '                   未検(SUM出荷数 - SUM検品数)(表示用)
        XSYUKKA_DT                          '出荷計画.          出荷日
        XCAR_NO_WARITUKE                    '出荷計画.          受付車番
        XCAR_NO_EDA_WARITUKE                '出荷計画.          枝番
        XNYUKA_JIGYOU_CD                    '出荷計画.          配送先ｺｰﾄﾞ(非表示)
        XNYUKA_JIGYOU_NM                    '出荷計画.          配送先
        XORDER_NO                           '出荷計画.          発注№
        FHINMEI_CD                          '出荷計画詳細.      品名ｺｰﾄﾞ
        FHINMEI                             '出荷計画詳細.      品名
        'XSEIZOU_DT                          '出荷計画詳細.      製造年月日
        XSEIZOU_DT                          '出荷実績.          製造年月日
        FTRK_BUF_NO                         '出荷実績.          出庫場所
        FBUF_NAME                           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬﾏｽﾀ.   出庫場所(表示用)
        XSYUKKA_VOL                         '出荷実績.          出荷数(SUM値)
        XSYUKKO_VOL                         '                   出庫数(SUM値)
        XSYUKKA_KENPIN_VOL                  '出荷実績.          検品数(SUM値)
        XSYUKKA_STS                         '                   出荷状況
        XSYUKKA_STS_DSP                     '                   出荷状況(表示用)
        XKENPIN_FLAG                        '出荷実績.          検品済みﾌﾗｸﾞ(非表示)

        MAXCOL                              'ｸﾞﾘｯﾄﾞの列数の最大値

    End Enum

    '入力ﾁｪｯｸ場合判別
    Enum menmCheckCase
        SearchBtn_Click             '検索ﾎﾞﾀﾝｸﾘｯｸ時
        DtlBtn_Click                '詳細ﾎﾞﾀﾝｸﾘｯｸ
        CsvOutBtn_Click             'CSV出力ﾎﾞﾀﾝｸﾘｯｸ
        KyoseiBtn_Click             '出荷計画強制完了ﾎﾞﾀﾝｸﾘｯｸ
        ManualKenpinBtn_Click       'ﾏﾆｭｱﾙ検品ﾎﾞﾀﾝｸﾘｯｸ
    End Enum

#End Region
#Region "  構造体定義                               "
    '検索条件
    Protected Structure stcSEARCH_ITEM
        Dim XSYUKKA_DT_FM As String                      '出荷日 FROM
        Dim XSYUKKA_DT_TO As String                      '出荷日 TO
        Dim XORDER_NO As String                          '発注№
        Dim XCAR_NO_WARITUKE As String                   '受付車番
        Dim XCAR_NO_EDA_WARITUKE As String               '枝番
        Dim XKENPIN_MIKAN_FLAG As String                 '検品未完了
    End Structure
#End Region
#Region "  ｲﾍﾞﾝﾄ                                    "
#Region "  ﾘｽﾄ          選択範囲変更ｲﾍﾞﾝﾄ           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾘｽﾄ          選択範囲変更ｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdList.SelectionChanged
        Try

            Call grdList_ClickProcess()

        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "  出荷日FROM ｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞ    ｲﾍﾞﾝﾄ   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 出荷日FROM ｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cboXSYUKKA_DT_FM_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboXSYUKKA_DT_FM.SelectedIndexChanged
        Try


            If mFlag_Form_Load = False Then


                '===================================
                '発注№                     ｾｯﾄ
                '===================================
                Call MakeSyukkaJitseki_cboXORDER_NO(TO_STRING(cboXSYUKKA_DT_FM.SelectedValue.ToString), TO_STRING(cboXSYUKKA_DT_TO.SelectedValue.ToString), cboXORDER_NO, True)

                '===================================
                '受付車番                   ｾｯﾄ
                '===================================
                Call MakeSyukkaJitseki_cboXCAR_NO_WARITUKE(TO_STRING(cboXSYUKKA_DT_FM.SelectedValue.ToString), TO_STRING(cboXSYUKKA_DT_TO.SelectedValue.ToString), cboXCAR_NO_WARITUKE, True)

                '===================================
                '枝番                       ｾｯﾄ
                '===================================
                Call MakeSyukkaJitseki_cboXCAR_NO_EDA_WARITUKE(TO_STRING(cboXSYUKKA_DT_FM.SelectedValue.ToString), TO_STRING(cboXSYUKKA_DT_TO.SelectedValue.ToString), cboXCAR_NO_EDA_WARITUKE, True)


                '*********************************************
                ' ｸﾞﾘｯﾄﾞ表示
                '*********************************************
                grdList.Columns.Clear()
                Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
                Call grdListSetup()

            End If


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "  出荷日TO ｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞ      ｲﾍﾞﾝﾄ   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 出荷日TO ｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cboXSYUKKA_DT_TO_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboXSYUKKA_DT_TO.SelectedIndexChanged
        Try


            If mFlag_Form_Load = False Then


                '===================================
                '発注№                     ｾｯﾄ
                '===================================
                Call MakeSyukkaJitseki_cboXORDER_NO(TO_STRING(cboXSYUKKA_DT_FM.SelectedValue.ToString), TO_STRING(cboXSYUKKA_DT_TO.SelectedValue.ToString), cboXORDER_NO, True)

                '===================================
                '受付車番                   ｾｯﾄ
                '===================================
                Call MakeSyukkaJitseki_cboXCAR_NO_WARITUKE(TO_STRING(cboXSYUKKA_DT_FM.SelectedValue.ToString), TO_STRING(cboXSYUKKA_DT_TO.SelectedValue.ToString), cboXCAR_NO_WARITUKE, True)

                '===================================
                '枝番                       ｾｯﾄ
                '===================================
                Call MakeSyukkaJitseki_cboXCAR_NO_EDA_WARITUKE(TO_STRING(cboXSYUKKA_DT_FM.SelectedValue.ToString), TO_STRING(cboXSYUKKA_DT_TO.SelectedValue.ToString), cboXCAR_NO_EDA_WARITUKE, True)


                '*********************************************
                ' ｸﾞﾘｯﾄﾞ表示
                '*********************************************
                grdList.Columns.Clear()
                Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
                Call grdListSetup()

            End If


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#End Region
#Region "　ﾌｫｰﾑﾛｰﾄﾞ                                 "
    Public Overrides Sub InitializeChild()


        '*********************************************
        ' ｺﾝﾎﾞﾎﾞｯｸｽ初期設定
        '*********************************************
        '===================================
        '出荷日 FROM                ｾｯﾄ
        '===================================
        Call MakeSyukkaJitseki_cboXSYUKKA_DT(cboXSYUKKA_DT_FM, XPLN_OUT_ID_JSEIHIN, True)

        '===================================
        '出荷日 TO                  ｾｯﾄ
        '===================================
        Call MakeSyukkaJitseki_cboXSYUKKA_DT(cboXSYUKKA_DT_TO, XPLN_OUT_ID_JSEIHIN, True)

        '===================================
        '発注№                     ｾｯﾄ
        '===================================
        Call MakeSyukkaJitseki_cboXORDER_NO(TO_STRING(cboXSYUKKA_DT_FM.SelectedValue.ToString), TO_STRING(cboXSYUKKA_DT_TO.SelectedValue.ToString), cboXORDER_NO, True)

        '===================================
        '受付車番                   ｾｯﾄ
        '===================================
        Call MakeSyukkaJitseki_cboXCAR_NO_WARITUKE(TO_STRING(cboXSYUKKA_DT_FM.SelectedValue.ToString), TO_STRING(cboXSYUKKA_DT_TO.SelectedValue.ToString), cboXCAR_NO_WARITUKE, True)

        '===================================
        '枝番                       ｾｯﾄ
        '===================================
        Call MakeSyukkaJitseki_cboXCAR_NO_EDA_WARITUKE(TO_STRING(cboXSYUKKA_DT_FM.SelectedValue.ToString), TO_STRING(cboXSYUKKA_DT_TO.SelectedValue.ToString), cboXCAR_NO_EDA_WARITUKE, True)


        chkKENPIN_MIKAN.Checked = False


        '*********************************************
        ' ﾘｽﾄ表示
        '*********************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)    'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListSetup()


        mFlag_Form_Load = False

    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ                               "
    Public Overrides Sub CloseChild()

        '******************************************
        ' ｺﾝﾄﾛｰﾙの開放
        '******************************************
        cboXSYUKKA_DT_FM.Dispose()          '出荷日 FROM
        cboXSYUKKA_DT_TO.Dispose()          '出荷日 TO
        cboXORDER_NO.Dispose()              '発注№
        cboXCAR_NO_WARITUKE.Dispose()       '受付車番
        cboXCAR_NO_EDA_WARITUKE.Dispose()   '枝番
        chkKENPIN_MIKAN.Dispose()           '検品未完了
        grdList.Dispose()                   'ｸﾞﾘｯﾄﾞ

    End Sub
#End Region
#Region "  F1(検索)           ﾎﾞﾀﾝ押下処理          "
    '*******************************************************************************************************************
    '【機能】F1  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F1Process()


        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.SearchBtn_Click) = False Then
            '(入力ｴﾗｰがある場合)
            Exit Sub
        End If

        '*********************************************
        ' 抽出条件を構造体にｾｯﾄ
        '*********************************************
        Call SearchItem_Set()

        '**********************************************************
        ' ﾘｽﾄ表示
        '**********************************************************
        Call grdListDisplaySub(grdList)


    End Sub
#End Region
#Region "  F4(詳細表示)       ﾎﾞﾀﾝ押下処理          "
    '*******************************************************************************************************************
    '【機能】F4  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F4Process()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.DtlBtn_Click) = False Then
            '(入力ｴﾗｰがある場合)
            Exit Sub
        End If

        'ｵﾌﾞｼﾞｪｸﾄNothingﾁｪｯｸ
        If IsNull(gobjFRM_304021) = False Then
            gobjFRM_304021.Close()
            gobjFRM_304021.Dispose()
            gobjFRM_304021 = Nothing
        End If

        '********************************************************************
        ' 詳細画面ﾌｫｰﾑ展開
        '********************************************************************
        gobjFRM_304021 = New FRM_304021                             'ｵﾌﾞｼﾞｪｸﾄ作成

        Call SetProperty(gobjFRM_304021, menmCheckCase.DtlBtn_Click)                  'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        Call gobjFRM_304021.ShowDialog()        '画面表示


        '*********************************************
        ' 抽出条件を構造体にｾｯﾄ
        '*********************************************
        Call SearchItem_Set()

        '**********************************************************
        ' ﾘｽﾄ表示
        '**********************************************************
        Call grdListDisplaySub(grdList)

    End Sub
#End Region
#Region "  F5(CSV出力)        ﾎﾞﾀﾝ押下処理          "
    '*******************************************************************************************************************
    '【機能】F5  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F5Process()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.SearchBtn_Click) = False Then
            '(入力ｴﾗｰがある場合)
            Exit Sub
        End If

        '*********************************************
        ' 抽出条件を構造体にｾｯﾄ
        '*********************************************
        Call SearchItem_Set()

        '**********************************************************
        ' ﾘｽﾄ表示
        '**********************************************************
        Call grdListDisplaySub(grdList)

        '*******************************************************
        '入力ﾁｪｯｸ
        '*******************************************************
        If InputCheck(menmCheckCase.CsvOutBtn_Click) = False Then
            Exit Sub
        End If

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udeRet As PopupFormType
        udeRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_PRINT_03, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udeRet <> PopupFormType.Ok Then
            Exit Sub
        End If

        '**********************************************************
        ' CSV出力
        '**********************************************************
        Call CSV_OUT()

    End Sub
#End Region
#Region "  F6(出荷計画強制完了)   ﾎﾞﾀﾝ押下処理      "
    '*******************************************************************************************************************
    '【機能】F6  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F6Process()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.KyoseiBtn_Click) = False Then
            '(入力ｴﾗｰがある場合)
            Exit Sub
        End If

        '*********************************************
        ' ｿｹｯﾄ送信
        '*********************************************
        If SendSocket02() = False Then
            Exit Sub
        End If

        '*********************************************
        ' 抽出条件を構造体にｾｯﾄ
        '*********************************************
        Call SearchItem_Set()

        '**********************************************************
        ' ﾘｽﾄ表示
        '**********************************************************
        Call grdListDisplaySub(grdList)

    End Sub
#End Region
#Region "  F7(ﾏﾆｭｱﾙ検品)      ﾎﾞﾀﾝ押下処理          "
    '*******************************************************************************************************************
    '【機能】F7  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F7Process()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.ManualKenpinBtn_Click) = False Then
            '(入力ｴﾗｰがある場合)
            Exit Sub
        End If

        '↓↓↓ 2012/11/08 19:30 
        ''********************************************************************
        '' ﾏﾆｭｱﾙ検品画面ﾌｫｰﾑ展開
        ''********************************************************************
        ''ｵﾌﾞｼﾞｪｸﾄNothingﾁｪｯｸ
        'If IsNull(gobjFRM_308030) = False Then
        '    gobjFRM_308030.Close()
        '    gobjFRM_308030.Dispose()
        '    gobjFRM_308030 = Nothing
        'End If

        'gobjFRM_308030 = New FRM_308030                             'ｵﾌﾞｼﾞｪｸﾄ作成

        'Call SetProperty2(gobjFRM_308030, menmCheckCase.DtlBtn_Click)                  'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        'Call gobjFRM_308030.ShowDialog()        '画面表示


        '********************************************************************
        ' ﾏﾆｭｱﾙ検品画面ﾌｫｰﾑ展開
        '********************************************************************
        'ｵﾌﾞｼﾞｪｸﾄNothingﾁｪｯｸ
        If IsNull(gobjFRM_308160) = False Then
            gobjFRM_308160.Close()
            gobjFRM_308160.Dispose()
            gobjFRM_308160 = Nothing
        End If

        gobjFRM_308160 = New FRM_308160                             'ｵﾌﾞｼﾞｪｸﾄ作成

        Call SetProperty3(gobjFRM_308160, menmCheckCase.DtlBtn_Click)                  'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        Call gobjFRM_308160.ShowDialog()        '画面表示
        '↑↑↑ 2012/11/08 19:30 



        '*********************************************
        ' 抽出条件を構造体にｾｯﾄ
        '*********************************************
        Call SearchItem_Set()

        '**********************************************************
        ' ﾘｽﾄ表示
        '**********************************************************
        Call grdListDisplaySub(grdList)

    End Sub
#End Region
#Region "  F8  ﾎﾞﾀﾝ押下処理　                       "
    '*******************************************************************************************************************
    '【機能】F8  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F8Process()

        '******************************************
        ' 画面遷移
        '******************************************
        Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_204000, Me)

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
        mudtSEARCH_ITEM.XSYUKKA_DT_FM = TO_STRING(cboXSYUKKA_DT_FM.SelectedValue)                  '出荷日 FROM
        mudtSEARCH_ITEM.XSYUKKA_DT_TO = TO_STRING(cboXSYUKKA_DT_TO.SelectedValue)                  '出荷日 TO
        mudtSEARCH_ITEM.XORDER_NO = TO_STRING(cboXORDER_NO.SelectedValue)                          '発注№
        mudtSEARCH_ITEM.XCAR_NO_WARITUKE = TO_STRING(cboXCAR_NO_WARITUKE.SelectedValue)            '受付車番
        mudtSEARCH_ITEM.XCAR_NO_EDA_WARITUKE = TO_STRING(cboXCAR_NO_EDA_WARITUKE.SelectedValue)    '枝番

        If chkKENPIN_MIKAN.Checked = False Then
            '(ﾁｪｯｸない)
            mudtSEARCH_ITEM.XKENPIN_MIKAN_FLAG = "0"                                               '検品未完了
        Else
            '(ﾁｪｯｸした)
            mudtSEARCH_ITEM.XKENPIN_MIKAN_FLAG = "1"                                               '検品未完了
        End If

    End Sub
#End Region
#Region "  ﾘｽﾄ              ｸﾘｯｸ処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾘｽﾄ              ｸﾘｯｸ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdList_ClickProcess()


        '*********************************************
        '混載ｸﾞﾘｯﾄﾞ表示の複数選択処理
        '*********************************************
        'Call gobjComFuncFRM.GridKonsaiSelect(grdList, mstrFPALLET_ID, menmListCol.FPALLET_ID)

        '*********************************************
        '出荷№取得
        '*********************************************
        Dim intRet As Integer = 0
        mstrXSYUKKA_NO = Nothing

        For ii As Integer = 0 To grdList.SelectedRows.Count - 1
            '(ﾙｰﾌﾟ:選択された行数)

            Dim strXSYUKKA_NOTemp As String = grdList.Item(menmListCol.XSYUKKA_NO, grdList.SelectedRows(ii).Index).Value
            Dim strXPLN_DTL_NOTemp As String = grdList.Item(menmListCol.XPLN_DTL_NO, grdList.SelectedRows(ii).Index).Value
            Dim strFTRK_BUF_NOTemp As String = grdList.Item(menmListCol.FTRK_BUF_NO, grdList.SelectedRows(ii).Index).Value

            Dim strSyukkaNoTemp As String = Microsoft.VisualBasic.Right("00000000" & strXSYUKKA_NOTemp, 8) _
                                          & Microsoft.VisualBasic.Right("00" & strXPLN_DTL_NOTemp, 2) _
                                          & Microsoft.VisualBasic.Right("0000" & strFTRK_BUF_NOTemp, 4)

            If IsNull(mstrXSYUKKA_NO) = True Then
                '(最初の一回)
                ReDim mstrXSYUKKA_NO(0)
                mstrXSYUKKA_NO(0) = strSyukkaNoTemp
            Else
                '(二回目以降)
                intRet = ArrayFindData(mstrXSYUKKA_NO, strSyukkaNoTemp)
                If intRet = -1 Then
                    '(出荷№が見つからなかった場合)
                    ReDim Preserve mstrXSYUKKA_NO(UBound(mstrXSYUKKA_NO) + 1)
                    mstrXSYUKKA_NO(UBound(mstrXSYUKKA_NO)) = strSyukkaNoTemp
                End If

            End If

        Next


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
        strSQL &= vbCrLf & "    XSYUKKA_NO "
        strSQL &= vbCrLf & "  , XPLN_DTL_NO "
        strSQL &= vbCrLf & "  , XKENPIN_MIKAN "
        strSQL &= vbCrLf & "  , XKENPIN_MIKAN_DSP "
        strSQL &= vbCrLf & "  , XSYUKKA_DT_DSP "
        strSQL &= vbCrLf & "  , XCAR_NO_WARITUKE "
        strSQL &= vbCrLf & "  , XCAR_NO_EDA_WARITUKE "
        strSQL &= vbCrLf & "  , XNYUKA_JIGYOU_CD "
        strSQL &= vbCrLf & "  , XNYUKA_JIGYOU_NM "
        strSQL &= vbCrLf & "  , XORDER_NO "
        strSQL &= vbCrLf & "  , FHINMEI_CD "
        strSQL &= vbCrLf & "  , FHINMEI "
        strSQL &= vbCrLf & "  , XSEIZOU_DT "
        strSQL &= vbCrLf & "  , FTRK_BUF_NO "
        strSQL &= vbCrLf & "  , FBUF_NAME "
        strSQL &= vbCrLf & "  , SYUKKA_SU "
        strSQL &= vbCrLf & "  , SYUKKO_SU "
        strSQL &= vbCrLf & "  , KENPIN_SU "
        strSQL &= vbCrLf & "  , XSYUKKA_STS "
        strSQL &= vbCrLf & "  , XSYUKKA_STS_DSP "
        strSQL &= vbCrLf & "  , XKENPIN_FLAG "

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & "  FROM "
        strSQL &= vbCrLf & "  ("
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "    XSYUKKA_NO "
        strSQL &= vbCrLf & "  , XPLN_DTL_NO "

        'strSQL &= vbCrLf & " , CASE WHEN XKENPIN_FLAG <> " & XKENPIN_FLAG_JOFF & " THEN '0' "    '未検(非表示)
        strSQL &= vbCrLf & " , CASE WHEN XKENPIN_FLAG = " & XKENPIN_FLAG_JKYOUSEI & " THEN '0' "
        strSQL &= vbCrLf & "        WHEN ((SYUKKA_SU - KENPIN_SU) = 0) AND (XKENPIN_FLAG = " & XKENPIN_FLAG_JON & ") THEN '0' "
        strSQL &= vbCrLf & "    ELSE '1' "
        strSQL &= vbCrLf & "   END AS XKENPIN_MIKAN "

        'strSQL &= vbCrLf & " , CASE WHEN XKENPIN_FLAG <> " & XKENPIN_FLAG_JOFF & " THEN '　' "    '未検(非表示)
        strSQL &= vbCrLf & " , CASE WHEN XKENPIN_FLAG = " & XKENPIN_FLAG_JKYOUSEI & " THEN '　' "
        strSQL &= vbCrLf & "        WHEN ((SYUKKA_SU - KENPIN_SU) = 0) AND (XKENPIN_FLAG = " & XKENPIN_FLAG_JON & ") THEN '　' "
        strSQL &= vbCrLf & "    ELSE '○' "
        strSQL &= vbCrLf & "   END AS XKENPIN_MIKAN_DSP "

        strSQL &= vbCrLf & "  , XSYUKKA_DT_DSP "
        strSQL &= vbCrLf & "  , XCAR_NO_WARITUKE "
        strSQL &= vbCrLf & "  , XCAR_NO_EDA_WARITUKE "
        strSQL &= vbCrLf & "  , XNYUKA_JIGYOU_CD "
        strSQL &= vbCrLf & "  , XNYUKA_JIGYOU_NM "
        strSQL &= vbCrLf & "  , XORDER_NO "
        strSQL &= vbCrLf & "  , FHINMEI_CD "
        strSQL &= vbCrLf & "  , FHINMEI "
        strSQL &= vbCrLf & "  , XSEIZOU_DT "
        strSQL &= vbCrLf & "  , FTRK_BUF_NO "
        strSQL &= vbCrLf & "  , FBUF_NAME "
        strSQL &= vbCrLf & "  , SYUKKA_SU "
        strSQL &= vbCrLf & "  , SYUKKO_SU "
        strSQL &= vbCrLf & "  , KENPIN_SU "

        strSQL &= vbCrLf & "  , CASE WHEN XKENPIN_FLAG = " & XKENPIN_FLAG_JKYOUSEI & " THEN '4' "
        strSQL &= vbCrLf & "         WHEN ((SYUKKA_SU - (NVL(SYUKKO_SU, 0) + KENPIN_SU)) > 0) "
        strSQL &= vbCrLf & "           AND (FTRK_BUF_NO NOT IN (" & FTRK_BUF_NO_J8000
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
        strSQL &= vbCrLf & "                                   )) THEN '1' "
        'strSQL &= vbCrLf & "         WHEN XKENPIN_FLAG = " & XKENPIN_FLAG_JON & " THEN '3' "
        strSQL &= vbCrLf & "         WHEN ((SYUKKA_SU - KENPIN_SU) = 0) AND (XKENPIN_FLAG = " & XKENPIN_FLAG_JON & ") THEN '3' "
        strSQL &= vbCrLf & "         ELSE '2' "
        strSQL &= vbCrLf & "    END AS XSYUKKA_STS "
        strSQL &= vbCrLf & "  , CASE WHEN XKENPIN_FLAG = " & XKENPIN_FLAG_JKYOUSEI & " THEN '強制完了' "
        strSQL &= vbCrLf & "         WHEN ((SYUKKA_SU - (NVL(SYUKKO_SU, 0) + KENPIN_SU)) > 0) "
        strSQL &= vbCrLf & "           AND (FTRK_BUF_NO NOT IN (" & FTRK_BUF_NO_J8000
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
        strSQL &= vbCrLf & "                                   )) THEN '出庫中' "
        'strSQL &= vbCrLf & "         WHEN XKENPIN_FLAG = " & XKENPIN_FLAG_JON & " THEN '検品完了' "
        strSQL &= vbCrLf & "         WHEN ((SYUKKA_SU - KENPIN_SU) = 0) AND (XKENPIN_FLAG = " & XKENPIN_FLAG_JON & ") THEN '検品完了' "
        strSQL &= vbCrLf & "         ELSE '検品中' "
        strSQL &= vbCrLf & "    END AS XSYUKKA_STS_DSP "

        strSQL &= vbCrLf & "  , XKENPIN_FLAG "

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & "  FROM "
        strSQL &= vbCrLf & "  ("
        strSQL &= vbCrLf & "  SELECT "
        strSQL &= vbCrLf & "    XSYUKKA_NO "
        strSQL &= vbCrLf & "  , XPLN_DTL_NO "
        strSQL &= vbCrLf & "  , XSYUKKA_DT_DSP "
        strSQL &= vbCrLf & "  , XCAR_NO_WARITUKE "
        strSQL &= vbCrLf & "  , XCAR_NO_EDA_WARITUKE "
        strSQL &= vbCrLf & "  , XNYUKA_JIGYOU_CD "
        strSQL &= vbCrLf & "  , XNYUKA_JIGYOU_NM "
        strSQL &= vbCrLf & "  , XORDER_NO "
        strSQL &= vbCrLf & "  , FHINMEI_CD "
        strSQL &= vbCrLf & "  , FHINMEI "
        strSQL &= vbCrLf & "  , XSEIZOU_DT "
        strSQL &= vbCrLf & "  , FTRK_BUF_NO "
        strSQL &= vbCrLf & "  , FBUF_NAME "
        strSQL &= vbCrLf & "  , SUM(SYUKKA_SU) AS SYUKKA_SU "
        strSQL &= vbCrLf & "  , SUM((SYUKKO_SU + KENPIN_SU)) AS SYUKKO_SU"
        strSQL &= vbCrLf & "  , SUM(KENPIN_SU) AS KENPIN_SU"
        'strSQL &= vbCrLf & "  , MAX(CASE XKENPIN_FLAG "
        'strSQL &= vbCrLf & "      WHEN " & XKENPIN_FLAG_JKYOUSEI & " THEN " & XKENPIN_FLAG_JKYOUSEI
        'strSQL &= vbCrLf & "      WHEN " & XKENPIN_FLAG_JOFF & " THEN " & XKENPIN_FLAG_JOFF
        'strSQL &= vbCrLf & "      WHEN " & XKENPIN_FLAG_JON & " THEN " & XKENPIN_FLAG_JON
        'strSQL &= vbCrLf & "     END )  AS XKENPIN_FLAG "
        strSQL &= vbCrLf & "  , MAX(XKENPIN_FLAG) AS XKENPIN_FLAG "


        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & " ("

        '============================================================
        'SELECT
        '============================================================
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "   XSYUKKA_NO "                                        '出荷計画.           出荷№(非表示))
        strSQL &= vbCrLf & " , XPLN_DTL_NO "                                       '出荷計画詳細.       計画明細№(非表示)
        strSQL &= vbCrLf & " , XSYUKKA_DT_DSP "                                    '出荷計画.           出荷日
        strSQL &= vbCrLf & " , XCAR_NO_WARITUKE "                                  '出荷計画.           受付車番
        strSQL &= vbCrLf & " , XCAR_NO_EDA_WARITUKE "                              '出荷計画.           枝番
        strSQL &= vbCrLf & " , XNYUKA_JIGYOU_CD "                                  '出荷計画.           入荷事業所ｺｰﾄﾞ(非表示)
        strSQL &= vbCrLf & " , XNYUKA_JIGYOU_NM "                                  '出荷計画.           入荷事業所名(配送先)
        strSQL &= vbCrLf & " , XORDER_NO "                                         '出荷計画.           発注№
        strSQL &= vbCrLf & " , FHINMEI_CD "                                        '出荷計画詳細.       品名ｺｰﾄﾞ
        strSQL &= vbCrLf & " , FHINMEI "                                           '出荷計画詳細.       品名
        strSQL &= vbCrLf & " , XSEIZOU_DT "                                        '出荷実績.           製造年月日
        strSQL &= vbCrLf & " , FTRK_BUF_NO "                                       '出荷実績.           出庫場所(非表示)
        strSQL &= vbCrLf & " , FBUF_NAME "                                         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬﾏｽﾀ.    出庫場所(表示用)
        strSQL &= vbCrLf & " , SYUKKA_SU "                                         '出荷実績.           出荷数(SUM値)
        strSQL &= vbCrLf & " , NVL(SYUKKO_SU, 0) AS SYUKKO_SU "                    '                    出庫数(SUM値)
        strSQL &= vbCrLf & " , KENPIN_SU"                                          '出荷実績.           検品数(SUM値)
        strSQL &= vbCrLf & " , XKENPIN_FLAG "                                      '出荷実績.      検品済みﾌﾗｸﾞ

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & " ("


        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "   XPLN_OUT.XSYUKKA_NO "
        strSQL &= vbCrLf & " , XPLN_OUT_DTL.XPLN_DTL_NO "

        strSQL &= vbCrLf & " , TO_DATE(XPLN_OUT.XSYUKKA_DT, 'YYYY/MM/DD') AS XSYUKKA_DT_DSP "
        strSQL &= vbCrLf & " , XPLN_OUT.XCAR_NO_WARITUKE "
        strSQL &= vbCrLf & " , XPLN_OUT.XCAR_NO_EDA_WARITUKE "
        strSQL &= vbCrLf & " , XPLN_OUT.XNYUKA_JIGYOU_CD "
        strSQL &= vbCrLf & " , XPLN_OUT.XNYUKA_JIGYOU_NM "
        strSQL &= vbCrLf & " , XPLN_OUT.XORDER_NO "
        strSQL &= vbCrLf & " , XPLN_OUT_DTL.FHINMEI_CD "
        strSQL &= vbCrLf & " , XPLN_OUT_DTL.FHINMEI "
        strSQL &= vbCrLf & " , XRST_OUT.XSEIZOU_DT "
        strSQL &= vbCrLf & " , XRST_OUT.FTRK_BUF_NO "
        strSQL &= vbCrLf & " , TMST_TRK.FBUF_NAME "
        strSQL &= vbCrLf & " , (XRST_OUT.FTR_VOL) AS SYUKKA_SU "
        strSQL &= vbCrLf & " , ("
        strSQL &= vbCrLf & "    CASE XRST_OUT.FTRK_BUF_NO "
        strSQL &= vbCrLf & "     WHEN " & FTRK_BUF_NO_J8000 & " THEN "
        strSQL &= vbCrLf & "       (SELECT "
        strSQL &= vbCrLf & "         TSTS_HIKIATE.FTR_VOL "
        strSQL &= vbCrLf & "       FROM "
        strSQL &= vbCrLf & "         TSTS_HIKIATE "
        strSQL &= vbCrLf & "       WHERE (0 = 0) "
        strSQL &= vbCrLf & "         AND XPLN_OUT_DTL.FPLAN_KEY   = TSTS_HIKIATE.FPLAN_KEY "
        'strSQL &= vbCrLf & "         AND XRST_OUT.FPALLET_ID    = TSTS_HIKIATE.FPALLET_ID ) "
        strSQL &= vbCrLf & "         AND NVL(XRST_OUT.XPALLET_ID_CHECK, XRST_OUT.XPALLET_ID_KARI) = TSTS_HIKIATE.FPALLET_ID ) "
        strSQL &= vbCrLf & "     ELSE "
        strSQL &= vbCrLf & "       (SELECT "
        strSQL &= vbCrLf & "         NVL(TRST_STOCK.FTR_RES_VOL, 0)"
        strSQL &= vbCrLf & "        FROM "
        strSQL &= vbCrLf & "           TRST_STOCK "
        strSQL &= vbCrLf & "         , TPRG_TRK_BUF "
        strSQL &= vbCrLf & "        WHERE (0 = 0) "
        'strSQL &= vbCrLf & "         AND XRST_OUT.FPALLET_ID     = TPRG_TRK_BUF.FPALLET_ID "
        strSQL &= vbCrLf & "         AND NVL(XRST_OUT.XPALLET_ID_CHECK, XRST_OUT.XPALLET_ID_KARI) = TPRG_TRK_BUF.FPALLET_ID "
        strSQL &= vbCrLf & "         AND NVL(TMST_TRK.XTRK_BUF_NO_OUT_HIRA,TMST_TRK.FTRK_BUF_NO) = TPRG_TRK_BUF.FTRK_BUF_NO "
        strSQL &= vbCrLf & "         AND TPRG_TRK_BUF.FPALLET_ID = TRST_STOCK.FPALLET_ID ) "
        strSQL &= vbCrLf & "    END)                         AS SYUKKO_SU "
        strSQL &= vbCrLf & " , (XRST_OUT.XSYUKKA_KENPIN_VOL) AS KENPIN_SU "
        strSQL &= vbCrLf & " , XRST_OUT.XKENPIN_FLAG "

        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "     XPLN_OUT "
        strSQL &= vbCrLf & "   , XPLN_OUT_DTL "
        strSQL &= vbCrLf & "   , XRST_OUT "
        strSQL &= vbCrLf & "   , TMST_TRK "


        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE (0 = 0) "
        strSQL &= vbCrLf & " AND XPLN_OUT.XPROGRESS_OUT IN (" & XPROGRESS_OUT_JWARITUKE & ", " _
                                                              & XPROGRESS_OUT_JWORK & ", " _
                                                              & XPROGRESS_OUT_JOUT & ", " _
                                                              & XPROGRESS_OUT_JCOMP & ", " _
                                                              & XPROGRESS_OUT_JBERTH_OTHER & ", " _
                                                              & XPROGRESS_OUT_JGAIBU_SOUKO & ", " _
                                                              & XPROGRESS_OUT_JKYOUSEI & ") "
        strSQL &= vbCrLf & " AND XPLN_OUT.XSYUKKA_NO       = XPLN_OUT_DTL.XSYUKKA_NO(+) "
        strSQL &= vbCrLf & " AND XPLN_OUT_DTL.XSYUKKA_NO   = XRST_OUT.XSYUKKA_NO(+) "
        strSQL &= vbCrLf & " AND XPLN_OUT_DTL.XPLN_DTL_NO  = XRST_OUT.XPLN_DTL_NO(+) "
        strSQL &= vbCrLf & " AND XRST_OUT.FTRK_BUF_NO      = TMST_TRK.FTRK_BUF_NO(+) "
        strSQL &= vbCrLf & " AND XRST_OUT.FTRK_BUF_NO      IS NOT NULL "


        '----------------------------------------------
        '出荷日 FROM
        '----------------------------------------------
        If mudtSEARCH_ITEM.XSYUKKA_DT_FM <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "      AND XPLN_OUT.XSYUKKA_DT >= '" & mudtSEARCH_ITEM.XSYUKKA_DT_FM & "' "
        End If

        '----------------------------------------------
        '出荷日 TO
        '----------------------------------------------
        If mudtSEARCH_ITEM.XSYUKKA_DT_TO <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "      AND XPLN_OUT.XSYUKKA_DT <= '" & mudtSEARCH_ITEM.XSYUKKA_DT_TO & "' "
        End If

        '----------------------------------------------
        '発注№
        '----------------------------------------------
        If mudtSEARCH_ITEM.XORDER_NO <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "      AND XPLN_OUT.XORDER_NO = '" & mudtSEARCH_ITEM.XORDER_NO & "' "
        End If

        '----------------------------------------------
        '受付車番
        '----------------------------------------------
        If mudtSEARCH_ITEM.XCAR_NO_WARITUKE <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "      AND XPLN_OUT.XCAR_NO_WARITUKE = '" & mudtSEARCH_ITEM.XCAR_NO_WARITUKE & "' "
        End If

        '----------------------------------------------
        '枝番
        '----------------------------------------------
        If mudtSEARCH_ITEM.XCAR_NO_EDA_WARITUKE <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "      AND XPLN_OUT.XCAR_NO_EDA_WARITUKE = '" & mudtSEARCH_ITEM.XCAR_NO_EDA_WARITUKE & "' "
        End If

        strSQL &= vbCrLf & " ) A "
        strSQL &= vbCrLf & " ) B "

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE (0 = 0) "

        ''----------------------------------------------
        ''検品未完了
        ''----------------------------------------------
        'If mudtSEARCH_ITEM.XKENPIN_MIKAN_FLAG = "1" Then
        '    '(全検索以外の場合)
        '    strSQL &= vbCrLf & "      AND XKENPIN_MIKAN = '1' "
        'End If

        '============================================================
        'GROUP BY
        '============================================================
        strSQL &= vbCrLf & " GROUP BY "
        strSQL &= vbCrLf & "   XSYUKKA_NO "                                        '出荷計画.           出荷№(非表示))
        strSQL &= vbCrLf & " , XPLN_DTL_NO "                                       '出荷計画詳細.       計画明細№(非表示)
        strSQL &= vbCrLf & " , XSYUKKA_DT_DSP "                                    '出荷計画.           出荷日
        strSQL &= vbCrLf & " , XCAR_NO_WARITUKE "                                  '出荷計画.           受付車番
        strSQL &= vbCrLf & " , XCAR_NO_EDA_WARITUKE "                              '出荷計画.           枝番
        strSQL &= vbCrLf & " , XNYUKA_JIGYOU_CD "                                  '出荷計画.           入荷事業所ｺｰﾄﾞ(非表示)
        strSQL &= vbCrLf & " , XNYUKA_JIGYOU_NM "                                  '出荷計画.           入荷事業所名(配送先)
        strSQL &= vbCrLf & " , XORDER_NO "                                         '出荷計画.           発注№
        strSQL &= vbCrLf & " , FHINMEI_CD "                                        '出荷計画詳細.       品名ｺｰﾄﾞ
        strSQL &= vbCrLf & " , FHINMEI "                                           '出荷計画詳細.       品名
        strSQL &= vbCrLf & " , XSEIZOU_DT "                                        '出荷実績.           製造年月日
        strSQL &= vbCrLf & " , FTRK_BUF_NO "                                       '出荷実績.           出庫場所(非表示)
        strSQL &= vbCrLf & " , FBUF_NAME "                                         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬﾏｽﾀ.    出庫場所(表示用)
        'strSQL &= vbCrLf & " , XKENPIN_FLAG "                                      '出荷実績.           検品済みﾌﾗｸﾞ

        strSQL &= vbCrLf & " ) C "
        strSQL &= vbCrLf & " ) D "

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE (0 = 0) "

        '----------------------------------------------
        '検品未完了
        '----------------------------------------------
        If mudtSEARCH_ITEM.XKENPIN_MIKAN_FLAG = "1" Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "      AND D.XKENPIN_MIKAN = '1' "
            'strSQL &= vbCrLf & "      AND XKENPIN_FLAG = " & XKENPIN_FLAG_JOFF
        End If

        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & gobjComFuncFRM.GetSQL_TDSP_GRID_OrderBy(Me, grdList)


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
        'grdList.AllowUserToResizeColumns = False
        grdList.MultiSelect = True

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

        Select Case udtCheck_Case
            Case menmCheckCase.SearchBtn_Click
                '(検索ﾎﾞﾀﾝｸﾘｯｸ時)

                blnCheckErr = False

            Case menmCheckCase.DtlBtn_Click
                '(詳細ﾎﾞﾀﾝｸﾘｯｸ時)

                '==========================
                'ﾘｽﾄ選択ﾁｪｯｸ
                '==========================
                If grdList.SelectedRows.Count < 1 Then
                    '(ﾘｽﾄが選択されていない場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_GRD_LIST, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select

                End If

                blnCheckErr = False

            Case menmCheckCase.CsvOutBtn_Click
                '(CSV出力ﾎﾞﾀﾝｸﾘｯｸ時)

                '==========================
                'ﾘｽﾄ　表示ﾃﾞｰﾀﾁｪｯｸ
                '==========================
                If grdList.Rows.Count <= 0 Then
                    '(ﾃﾞｰﾀが一行もない場合)
                    Exit Function
                End If

                blnCheckErr = False


            Case menmCheckCase.KyoseiBtn_Click
                '(出荷強制完了ﾎﾞﾀﾝｸﾘｯｸ時)

                '==========================
                'ﾘｽﾄ選択ﾁｪｯｸ
                '==========================
                If grdList.SelectedRows.Count < 1 Then
                    '(ﾘｽﾄが選択されていない場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_GRD_LIST, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select

                End If

                '==========================
                '検品中ﾁｪｯｸ
                '==========================
                'For ii As Integer = 0 To grdList.SelectedRows.Count - 1
                '    If TO_STRING(grdList.Item(menmListCol.XSYUKKA_STS, grdList.SelectedRows(ii).Index).Value) = "0" Then
                '        '(検品済みの時)
                'Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM304020_01, PopupFormType.Ok, PopupIconType.Information)
                '        blnCheckErr = True
                '        Exit Select
                '    End If
                'Next

                '==========================
                '出荷状況 ﾁｪｯｸ
                '==========================
                'If TO_STRING(grdList.Item(menmListCol.XSYUKKA_STS, grdList.SelectedRows(0).Index).Value) = "1" Then
                '    '(出庫中の時)
                '    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM304020_05, PopupFormType.Ok, PopupIconType.Information)
                '    blnCheckErr = True
                '    Exit Select

                'End If

                If TO_STRING(grdList.Item(menmListCol.XSYUKKA_STS, grdList.SelectedRows(0).Index).Value) = "3" Then
                    '(検品完了の時)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM304020_01, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select

                End If

                If TO_STRING(grdList.Item(menmListCol.XSYUKKA_STS, grdList.SelectedRows(0).Index).Value) = "4" Then
                    '(強制完了の時)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM304020_06, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select

                End If

                blnCheckErr = False


            Case menmCheckCase.ManualKenpinBtn_Click
                '(ﾏﾆｭｱﾙ検品ﾎﾞﾀﾝｸﾘｯｸ時)

                '==========================
                'ﾘｽﾄ選択ﾁｪｯｸ
                '==========================
                If grdList.SelectedRows.Count < 1 Then
                    '(ﾘｽﾄが選択されていない場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_GRD_LIST, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select

                End If

                If grdList.SelectedRows.Count > 1 Then
                    '(ﾘｽﾄが2以上選択された場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM304020_04, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If

                ''==========================
                ''検品中ﾁｪｯｸ
                ''==========================
                'For ii As Integer = 0 To grdList.SelectedRows.Count - 1
                '    If TO_STRING(grdList.Item(menmListCol.XSYUKKA_STS, grdList.SelectedRows(ii).Index).Value) = "0" Then
                '        '(検品済みの時)
                '        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM304020_01, PopupFormType.Ok, PopupIconType.Information)
                '        blnCheckErr = True
                '        Exit Select
                '    End If
                'Next

                '==========================
                '出荷状況 ﾁｪｯｸ
                '==========================
                If TO_STRING(grdList.Item(menmListCol.XSYUKKA_STS, grdList.SelectedRows(0).Index).Value) = "1" Then
                    '(出庫中の時)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM304020_05, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select

                End If

                If TO_STRING(grdList.Item(menmListCol.XSYUKKA_STS, grdList.SelectedRows(0).Index).Value) = "3" Then
                    '(検品完了の時)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM304020_01, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select

                End If

                If TO_STRING(grdList.Item(menmListCol.XSYUKKA_STS, grdList.SelectedRows(0).Index).Value) = "4" Then
                    '(強制完了の時)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM304020_06, PopupFormType.Ok, PopupIconType.Information)
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
#Region "　CSV出力                                  "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】なし
    '【戻値】なし
    '*******************************************************************************************************************
    Private Sub CSV_Out()

        Call gobjComFuncFRM.WaitFormShow()                     ' Waitﾌｫｰﾑ表示

        Try

            '******************************************
            'ﾌｧｲﾙ名     取得
            '******************************************
            Dim strFile As String = TO_STRING(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_JGJ304020_001))

            '******************************************
            'ﾃﾞｰﾀ部     ﾍｯﾀﾞ表示名ｾｯﾄ
            '******************************************
            Dim strDataHeaderName_Ary(12) As String
            strDataHeaderName_Ary(0) = "未検"
            strDataHeaderName_Ary(1) = "出荷日"
            strDataHeaderName_Ary(2) = "受付車番"
            strDataHeaderName_Ary(3) = "枝番"
            strDataHeaderName_Ary(4) = "配送先"
            strDataHeaderName_Ary(5) = "発注№"
            strDataHeaderName_Ary(6) = "品名ｺｰﾄﾞ"
            strDataHeaderName_Ary(7) = "品名"
            strDataHeaderName_Ary(8) = "製造年月日"
            strDataHeaderName_Ary(9) = "出庫場所"
            strDataHeaderName_Ary(10) = "出荷数"
            strDataHeaderName_Ary(11) = "検品数"
            strDataHeaderName_Ary(12) = "出荷状況"


            '******************************************
            'ﾃﾞｰﾀ部     ｶﾗﾑ名ｾｯﾄ
            '******************************************
            Dim intDataColumnIdx_Ary(12) As Integer
            intDataColumnIdx_Ary(0) = menmListCol.XKENPIN_MIKAN_DSP
            intDataColumnIdx_Ary(1) = menmListCol.XSYUKKA_DT
            intDataColumnIdx_Ary(2) = menmListCol.XCAR_NO_WARITUKE
            intDataColumnIdx_Ary(3) = menmListCol.XCAR_NO_EDA_WARITUKE
            intDataColumnIdx_Ary(4) = menmListCol.XNYUKA_JIGYOU_NM
            intDataColumnIdx_Ary(5) = menmListCol.XORDER_NO
            intDataColumnIdx_Ary(6) = menmListCol.FHINMEI_CD
            intDataColumnIdx_Ary(7) = menmListCol.FHINMEI
            intDataColumnIdx_Ary(8) = menmListCol.XSEIZOU_DT
            intDataColumnIdx_Ary(9) = menmListCol.FBUF_NAME
            intDataColumnIdx_Ary(10) = menmListCol.XSYUKKA_VOL
            intDataColumnIdx_Ary(11) = menmListCol.XSYUKKA_KENPIN_VOL
            intDataColumnIdx_Ary(12) = menmListCol.XSYUKKA_STS_DSP


            '******************************************
            'CSVﾌｧｲﾙ出力
            '******************************************
            Call MakeCSV(grdList _
                        , TO_STRING(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_JGJ000000_001)) _
                        , strFile _
                        , "" _
                        , strDataHeaderName_Ary _
                        , intDataColumnIdx_Ary _
                        )


        Catch ex As Exception
            Throw ex

        Finally
            Call gobjComFuncFRM.WaitFormClose()                    ' Waitﾌｫｰﾑ削除

        End Try

    End Sub
#End Region

#Region "　ﾌﾟﾛﾊﾟﾃｨｾｯﾄ(詳細)　                       "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub SetProperty(ByVal objForm As FRM_304021, ByVal enmCheckCase As menmCheckCase)


        objForm.userXSYUKKA_NO = TO_STRING(grdList.Item(menmListCol.XSYUKKA_NO, grdList.SelectedRows(0).Index).Value)                         '出荷№
        '↓↓↓↓ 2012.11.30 10:30 H.Morita 同一出荷№+異なる出荷明細№+同一品目の時の検品対応
        objForm.userXPLN_DTL_NO = TO_STRING(grdList.Item(menmListCol.XPLN_DTL_NO, grdList.SelectedRows(0).Index).Value)                       '計画明細№
        '↑↑↑↑ 2012.11.30 10:30 H.Morita 同一出荷№+異なる出荷明細№+同一品目の時の検品対応
        '出荷日
        objForm.userXSYUKKA_DT = Mid(TO_STRING(grdList.Item(menmListCol.XSYUKKA_DT, grdList.SelectedRows(0).Index).Value), 1, 4) & _
                                 Mid(TO_STRING(grdList.Item(menmListCol.XSYUKKA_DT, grdList.SelectedRows(0).Index).Value), 6, 2) & _
                                 Mid(TO_STRING(grdList.Item(menmListCol.XSYUKKA_DT, grdList.SelectedRows(0).Index).Value), 9, 2)
        objForm.userXCAR_NO_WARITUKE = TO_STRING(grdList.Item(menmListCol.XCAR_NO_WARITUKE, grdList.SelectedRows(0).Index).Value)             '受付車番
        objForm.userXCAR_NO_EDA_WARITUKE = TO_STRING(grdList.Item(menmListCol.XCAR_NO_EDA_WARITUKE, grdList.SelectedRows(0).Index).Value)     '枝番
        objForm.userXNYUKA_JIGYOU_NM = TO_STRING(grdList.Item(menmListCol.XNYUKA_JIGYOU_NM, grdList.SelectedRows(0).Index).Value)             '配送先
        objForm.userXORDER_NO = TO_STRING(grdList.Item(menmListCol.XORDER_NO, grdList.SelectedRows(0).Index).Value)                           '発注№
        objForm.userFHINMEI_CD = TO_STRING(grdList.Item(menmListCol.FHINMEI_CD, grdList.SelectedRows(0).Index).Value)                         '品名ｺｰﾄﾞ
        objForm.userFHINMEI = TO_STRING(grdList.Item(menmListCol.FHINMEI, grdList.SelectedRows(0).Index).Value)                               '品名
        objForm.userFTRK_BUF_NO = TO_STRING(grdList.Item(menmListCol.FTRK_BUF_NO, grdList.SelectedRows(0).Index).Value)                       '出荷場所(ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№)
        objForm.userFBUF_NAME = TO_STRING(grdList.Item(menmListCol.FBUF_NAME, grdList.SelectedRows(0).Index).Value)                           '出荷場所
        objForm.userXSEIZOU_DT = TO_STRING(grdList.Item(menmListCol.XSEIZOU_DT, grdList.SelectedRows(0).Index).Value)                         '製造年月日

    End Sub
#End Region
#Region "　ﾌﾟﾛﾊﾟﾃｨｾｯﾄ(ﾏﾆｭｱﾙ検品(旧 FRM_308030))     "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub SetProperty2(ByVal objForm As FRM_308030, ByVal enmCheckCase As menmCheckCase)

        objForm.userFTRK_BUF_NO = TO_STRING(grdList.Item(menmListCol.FTRK_BUF_NO, grdList.SelectedRows(0).Index).Value) 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№(出庫場所)
        objForm.userFBUF_NAME = TO_STRING(grdList.Item(menmListCol.FBUF_NAME, grdList.SelectedRows(0).Index).Value)     '出庫場所
        objForm.userXSYUKKA_NO = TO_STRING(grdList.Item(menmListCol.XSYUKKA_NO, grdList.SelectedRows(0).Index).Value)   '出荷№
        objForm.userFHINMEI_CD = TO_STRING(grdList.Item(menmListCol.FHINMEI_CD, grdList.SelectedRows(0).Index).Value)   '品名ｺｰﾄﾞ
        objForm.userXSEIZOU_DT = TO_STRING(grdList.Item(menmListCol.XSEIZOU_DT, grdList.SelectedRows(0).Index).Value)   '製造年月日
        objForm.userXCAR_NO_WARITUKE = TO_STRING(grdList.Item(menmListCol.XCAR_NO_WARITUKE, grdList.SelectedRows(0).Index).Value)           '受付車番
        objForm.userXCAR_NO_EDA_WARITUKE = TO_STRING(grdList.Item(menmListCol.XCAR_NO_EDA_WARITUKE, grdList.SelectedRows(0).Index).Value)   '受付車番枝番

    End Sub
#End Region
#Region "　ﾌﾟﾛﾊﾟﾃｨｾｯﾄ(ﾏﾆｭｱﾙ検品(FRM_308160))        "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub SetProperty3(ByVal objForm As FRM_308160, ByVal enmCheckCase As menmCheckCase)

        objForm.userFTRK_BUF_NO = TO_STRING(grdList.Item(menmListCol.FTRK_BUF_NO, grdList.SelectedRows(0).Index).Value) 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№(出庫場所)
        objForm.userFBUF_NAME = TO_STRING(grdList.Item(menmListCol.FBUF_NAME, grdList.SelectedRows(0).Index).Value)     '出庫場所
        objForm.userXSYUKKA_NO = TO_STRING(grdList.Item(menmListCol.XSYUKKA_NO, grdList.SelectedRows(0).Index).Value)   '出荷№
        '↓↓↓↓ 2012.11.30 10:30 H.Morita 同一出荷№+異なる出荷明細№+同一品目の時の検品対応
        objForm.userXPLN_DTL_NO = TO_STRING(grdList.Item(menmListCol.XPLN_DTL_NO, grdList.SelectedRows(0).Index).Value)   '計画明細№
        '↑↑↑↑ 2012.11.30 10:30 H.Morita 同一出荷№+異なる出荷明細№+同一品目の時の検品対応
        objForm.userFHINMEI_CD = TO_STRING(grdList.Item(menmListCol.FHINMEI_CD, grdList.SelectedRows(0).Index).Value)   '品名ｺｰﾄﾞ
        objForm.userXSEIZOU_DT = TO_STRING(grdList.Item(menmListCol.XSEIZOU_DT, grdList.SelectedRows(0).Index).Value)   '製造年月日
        objForm.userXCAR_NO_WARITUKE = TO_STRING(grdList.Item(menmListCol.XCAR_NO_WARITUKE, grdList.SelectedRows(0).Index).Value)           '受付車番
        objForm.userXCAR_NO_EDA_WARITUKE = TO_STRING(grdList.Item(menmListCol.XCAR_NO_EDA_WARITUKE, grdList.SelectedRows(0).Index).Value)   '受付車番枝番

    End Sub
#End Region

#Region "  ｿｹｯﾄ送信02  出荷計画強制完了             "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信  作業開始
    ''' </summary>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Function SendSocket02() As Boolean

        Dim blnRet As Boolean = False
        Dim strMsg As String = ""

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        Dim strMessage As String
        strMessage = ""
        strMessage &= FRM_MSG_FRM304020_02
        udtRet = gobjComFuncFRM.DisplayPopup(strMessage, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Function
        End If


        '*******************************************************
        'ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙに追加する電文配列作成
        '*******************************************************
        Dim strSendTel() As String = Nothing

        For ii As Integer = LBound(mstrXSYUKKA_NO) To UBound(mstrXSYUKKA_NO)
            '(ﾊﾟﾚｯﾄID分ﾙｰﾌﾟ)

            If IsNull(strSendTel) = True Then ReDim Preserve strSendTel(0) Else ReDim Preserve strSendTel(UBound(strSendTel) + 1)

            '*******************************************************
            ' 電文作成
            '*******************************************************
            '========================================
            ' 変数宣言
            '========================================
            Dim objTelegramSub As New clsTelegram(CONFIG_TELEGRAM_DSP)
            Dim strXDSPSYUKKA_NO As String = ""               '出荷№
            Dim strXDSPPLN_DTL_NO As String = ""              '計画明細№
            Dim strDSPTRK_BUF_NO As String = ""               'ﾊﾞｯﾌｬ№

            objTelegramSub.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400202       'ﾌｫｰﾏｯﾄ名ｾｯﾄ

            Dim strDSPCMD_ID As String = ""
            strDSPCMD_ID = objTelegramSub.FORMAT_ID.Substring(objTelegramSub.FORMAT_ID.Length - 6, 6)
            'ﾍｯﾀﾞﾃﾞｰﾀ
            objTelegramSub.SETIN_HEADER("DSPCMD_ID", strDSPCMD_ID)              'ｺﾏﾝﾄﾞID
            objTelegramSub.SETIN_HEADER("DSPTERM_ID", gcstrFTERM_ID)            '端末ID
            objTelegramSub.SETIN_HEADER("DSPUSER_ID", gcstrFUSER_ID)            'ﾕｰｻﾞID

            'ﾃﾞｰﾀ
            strXDSPSYUKKA_NO = Mid(mstrXSYUKKA_NO(ii), 1, 8)                    '出荷№
            strXDSPPLN_DTL_NO = TO_INTEGER(Mid(mstrXSYUKKA_NO(ii), 9, 2))       '計画明細№
            strDSPTRK_BUF_NO = Mid(mstrXSYUKKA_NO(ii), 11, 4)                   'ﾊﾞｯﾌｬ№

            objTelegramSub.SETIN_DATA("XDSPSYUKKA_NO", strXDSPSYUKKA_NO)        '出荷№
            objTelegramSub.SETIN_DATA("XDSPPLN_DTL_NO", strXDSPPLN_DTL_NO)      '計画明細№
            objTelegramSub.SETIN_DATA("DSPTRK_BUF_NO", strDSPTRK_BUF_NO)        'ﾊﾞｯﾌｬ№

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
        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400202      'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        objTelegram.SETIN_DATA("XDSPSYUKKA_NO", "")                     '出荷№
        objTelegram.SETIN_DATA("XDSPPLN_DTL_NO", "")                    '計画明細№
        objTelegram.SETIN_DATA("DSPTRK_BUF_NO", "")                     'ﾊﾞｯﾌｬ№

        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode    'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String = ""                    'ｴﾗｰﾒｯｾｰｼﾞ
        strErrMsg = FRM_MSG_FRM304020_03
        udtSckSendRET = gobjComFuncFRM.SockSendServer02(objTelegram, strSendTel, strRET_STATE, , , , strErrMsg)    'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            '(送信できた場合)
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)
                blnRet = True
            End If
        End If

        Return blnRet

    End Function
#End Region

End Class
