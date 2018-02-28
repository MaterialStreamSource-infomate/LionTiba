'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】品質ｽﾃｰﾀｽ登録
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_308080
#Region "　共通変数　                               "

    Private mFlag_Form_Load As Boolean = True                   '画面展開ﾌﾗｸﾞ
    Private mFlag_GRID_CLEAR As Boolean = True                  'ｸﾞﾘｯﾄﾞｸﾘｱ済みﾌﾗｸﾞ

    '検索条件用構造体
    Private mudtSEARCH_ITEM As New SEARCH_ITEM

    '選択されたﾊﾟﾚｯﾄID、在庫ﾛｯﾄ№の配列
    Public mstrFPALLET_ID() As String = Nothing
    Public mstrFLOT_NO_STOCK() As String = Nothing

    'ｸﾞﾘｯﾄﾞ項目
    Enum menmListCol
        FTRK_BUF_NO                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      (非表示)ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        FBUF_NAME                   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.           ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称
        FPALLET_ID                  '在庫情報.          (非表示)ﾊﾟﾚｯﾄID
        FLOT_NO_STOCK               '在庫情報.          (非表示)ﾛｯﾄ№
        FHINMEI_CD                  '在庫情報.                  品名ｺｰﾄﾞ
        FHINMEI                     '品目ﾏｽﾀ.                   品名
        XSEIZOU_DT                  '在庫情報.                  製造年月日
        XLINE_NO                    '在庫情報.                  ﾗｲﾝ№
        FPALLET_NO                  '在庫情報.                  ﾊﾟﾚｯﾄNO
        XHINSHITU_STS               '在庫情報.          (非表示)品質ｽﾃｰﾀｽ
        XHINSHITU_STS_DSP           '在庫情報.                  品質ｽﾃｰﾀｽ(表示用)
        FTR_VOL                     '在庫情報.                  搬送管理量

        MAXCOL

    End Enum

    '入力ﾁｪｯｸ場合判別
    Enum menmCheckCase
        SearchBtn_Click                 '検索ﾎﾞﾀﾝｸﾘｯｸ時
        SelectAll_Click                 '全選択ﾎﾞﾀﾝｸﾘｯｸ時
        NotSelectAll_Click              '全解除ﾎﾞﾀﾝｸﾘｯｸ時
        Regist_Click                    '登録ﾎﾞﾀﾝｸﾘｯｸ時
    End Enum

#End Region
#Region "  構造体定義                               "
    '検索条件
    Private Structure SEARCH_ITEM
        Dim FPLACE_CD As String         '保管場所
        Dim XHINSHITU_STS As String      '品質ｽﾃｰﾀｽ
        Dim FHINMEI_CD As String        '品名ｺｰﾄﾞ
        Dim XSEIZOU_DT As String        '製造年月日
        Dim XLINE_NO As String          'ﾗｲﾝ№
        Dim FPALLET_NO_FROM As String   'ﾊﾟﾚｯﾄNO FROM
        Dim FPALLET_NO_TO As String     'ﾊﾟﾚｯﾄNO TO
    End Structure
    'ｿｹｯﾄ送信情報
    Private Structure STOCK_DATA
        Dim DSPPALLET_ID As String      'ﾊﾟﾚｯﾄID
        Dim DSPLOT_NO_STOCK As String   'ﾛｯﾄ№
    End Structure
#End Region
#Region "　ｲﾍﾞﾝﾄ                                　  "
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
#Region "　保管場所ｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞ    ｲﾍﾞﾝﾄ      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 保管場所ｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cboFPLACE_CD_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPLACE_CD.SelectedIndexChanged
        Try

            If mFlag_Form_Load = False Then

                '===================================
                '保留設定 ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
                '===================================
                cboXHINSHITU_STS.SelectedIndex = -1

                cboFHINMEI_CD.Text = ""                 '品名ｺｰﾄﾞ

                cboFHINMEI_CD.conn = gobjDb
                cboFHINMEI_CD.HinmeiLabel = lblFHINMEI
                cboFHINMEI_CD.Text = ""
                cboFHINMEI_CD.TableName = "TRST_STOCK"
                cboFHINMEI_CD.ComboBoxType = GamenCommon.cmpCboFHINMEI_CD.HINMEI_CBO_TYPE.SpecifiedAndMasterData
                cboFHINMEI_CD.HinmeiVisible = False

                If TO_STRING(cboFPLACE_CD.SelectedValue.ToString) <> CBO_ALL_VALUE Then
                    '(全検索以外の場合)
                    ReDim cboFHINMEI_CD.FTRK_BUF_NO(0)                      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№指定
                    cboFHINMEI_CD.FTRK_BUF_NO(0) = TO_STRING(cboFPLACE_CD.SelectedValue.ToString)
                Else
                    '(全検索の場合)
                    ReDim cboFHINMEI_CD.FTRK_BUF_NO(21)                          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№指定
                    cboFHINMEI_CD.FTRK_BUF_NO(0) = FTRK_BUF_NO_J9000
                    cboFHINMEI_CD.FTRK_BUF_NO(1) = FTRK_BUF_NO_J8000
                    cboFHINMEI_CD.FTRK_BUF_NO(2) = FTRK_BUF_NO_J8001
                    cboFHINMEI_CD.FTRK_BUF_NO(3) = FTRK_BUF_NO_J8002
                    cboFHINMEI_CD.FTRK_BUF_NO(4) = FTRK_BUF_NO_J8100
                    cboFHINMEI_CD.FTRK_BUF_NO(5) = FTRK_BUF_NO_J8101
                    cboFHINMEI_CD.FTRK_BUF_NO(6) = FTRK_BUF_NO_J8102
                    cboFHINMEI_CD.FTRK_BUF_NO(7) = FTRK_BUF_NO_J8103
                    cboFHINMEI_CD.FTRK_BUF_NO(8) = FTRK_BUF_NO_J8104
                    cboFHINMEI_CD.FTRK_BUF_NO(9) = FTRK_BUF_NO_J8105
                    cboFHINMEI_CD.FTRK_BUF_NO(10) = FTRK_BUF_NO_J8106
                    cboFHINMEI_CD.FTRK_BUF_NO(11) = FTRK_BUF_NO_J8107
                    cboFHINMEI_CD.FTRK_BUF_NO(12) = FTRK_BUF_NO_J8108
                    cboFHINMEI_CD.FTRK_BUF_NO(13) = FTRK_BUF_NO_J8109
                    cboFHINMEI_CD.FTRK_BUF_NO(14) = FTRK_BUF_NO_J8201
                    cboFHINMEI_CD.FTRK_BUF_NO(15) = FTRK_BUF_NO_J8202
                    cboFHINMEI_CD.FTRK_BUF_NO(16) = FTRK_BUF_NO_J8203
                    cboFHINMEI_CD.FTRK_BUF_NO(17) = FTRK_BUF_NO_J8204
                    cboFHINMEI_CD.FTRK_BUF_NO(18) = FTRK_BUF_NO_J8205
                    cboFHINMEI_CD.FTRK_BUF_NO(19) = FTRK_BUF_NO_J8206
                    cboFHINMEI_CD.FTRK_BUF_NO(20) = FTRK_BUF_NO_J8207
                    cboFHINMEI_CD.FTRK_BUF_NO(21) = FTRK_BUF_NO_J8208

                End If

                cboFHINMEI_CD.FRES_KIND = FRES_KIND_SZAIKO                                             '引当状態 = 「在庫棚」
                cboFHINMEI_CD.cboSetupHinmeiCd(cboFHINMEI_CD.Text)                                     '品名ｺｰﾄﾞ


                Call MakeZaikoToiawase_cboXSEIZOU_DT(TO_STRING(cboFPLACE_CD.SelectedValue.ToString), cboFHINMEI_CD.Text, cboXSEIZOU_DT, True)         '製造年月日
                Call MakeZaikoToiawase_cboXLINE_NO(TO_STRING(cboFPLACE_CD.SelectedValue.ToString), _
                                                   cboFHINMEI_CD.Text, _
                                                   TO_STRING(cboXSEIZOU_DT.SelectedValue), cboXLINE_NO, True)             'ﾗｲﾝ№
                Call MakeHoryuSettei_cboXPALLET_NO(TO_STRING(cboFPLACE_CD.SelectedValue.ToString), _
                                                   cboFHINMEI_CD.Text, _
                                                   TO_STRING(cboXSEIZOU_DT.SelectedValue), _
                                                   TO_STRING(cboXLINE_NO.SelectedValue), _cboXPALLET_NO_FROM, True)      'ﾊﾟﾚｯﾄ№ FROM
                Call MakeHoryuSettei_cboXPALLET_NO(TO_STRING(cboFPLACE_CD.SelectedValue.ToString), _
                                                   cboFHINMEI_CD.Text, _
                                                   TO_STRING(cboXSEIZOU_DT.SelectedValue), _
                                                   TO_STRING(cboXLINE_NO.SelectedValue), _cboXPALLET_NO_TO, True)        'ﾊﾟﾚｯﾄ№ TO

                If mFlag_GRID_CLEAR = False Then
                    '(ｸﾞﾘｯﾄﾞに表示ある時)
                    '*********************************************
                    ' ｸﾞﾘｯﾄﾞ表示
                    '*********************************************
                    grdList.Columns.Clear()
                    Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
                    Call grdListSetup()

                    mFlag_GRID_CLEAR = True
                End If


            End If

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
    '↓↓↓↓ 2012.11.28 16:00 H.Morita 検索範囲の絞込み
#Region "　品名ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞ       ｲﾍﾞﾝﾄ   "
    '* 2012/11/29 10:00 H.Morita ﾃｷｽﾄ変更時対応 * Private Sub cboFHINMEI_CD_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFHINMEI_CD.SelectedIndexChanged
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 品名ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cboFHINMEI_CD_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFHINMEI_CD.TextChanged
        Try


            If mFlag_Form_Load = False Then

                '===================================
                '在庫問合せ ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
                '===================================
                Call MakeZaikoToiawase_cboXSEIZOU_DT(TO_STRING(cboFPLACE_CD.SelectedValue.ToString), cboFHINMEI_CD.Text, cboXSEIZOU_DT, True)         '製造年月日
                Call MakeZaikoToiawase_cboXLINE_NO(TO_STRING(cboFPLACE_CD.SelectedValue.ToString), _
                                                   cboFHINMEI_CD.Text, _
                                                   TO_STRING(cboXSEIZOU_DT.SelectedValue), cboXLINE_NO, True)             'ﾗｲﾝ№
                Call MakeHoryuSettei_cboXPALLET_NO(TO_STRING(cboFPLACE_CD.SelectedValue.ToString), _
                                                   cboFHINMEI_CD.Text, _
                                                   TO_STRING(cboXSEIZOU_DT.SelectedValue), _
                                                   TO_STRING(cboXLINE_NO.SelectedValue), _
                                                   cboXPALLET_NO_FROM, True)                        'ﾊﾟﾚｯﾄ№ FROM
                Call MakeHoryuSettei_cboXPALLET_NO(TO_STRING(cboFPLACE_CD.SelectedValue.ToString), _
                                                   cboFHINMEI_CD.Text, _
                                                   TO_STRING(cboXSEIZOU_DT.SelectedValue), _
                                                   TO_STRING(cboXLINE_NO.SelectedValue), _
                                                   cboXPALLET_NO_TO, True)                          'ﾊﾟﾚｯﾄ№ TO

                If mFlag_GRID_CLEAR = False Then
                    '(ｸﾞﾘｯﾄﾞに表示ある時)
                    '*********************************************
                    ' ｸﾞﾘｯﾄﾞ表示
                    '*********************************************
                    grdList.Columns.Clear()
                    Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
                    Call grdListSetup()

                    mFlag_GRID_CLEAR = True
                End If

            End If


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "　製造年月日ｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞ     ｲﾍﾞﾝﾄ   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 製造年月日ｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cboXSEIZOU_DT_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboXSEIZOU_DT.SelectedIndexChanged
        Try


            If mFlag_Form_Load = False Then

                '===================================
                '在庫問合せ ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
                '===================================
                Call MakeZaikoToiawase_cboXLINE_NO(TO_STRING(cboFPLACE_CD.SelectedValue.ToString), _
                                                   cboFHINMEI_CD.Text, _
                                                   TO_STRING(cboXSEIZOU_DT.SelectedValue), cboXLINE_NO, True)                     'ﾗｲﾝ№
                Call MakeHoryuSettei_cboXPALLET_NO(TO_STRING(cboFPLACE_CD.SelectedValue.ToString), _
                                                   cboFHINMEI_CD.Text, _
                                                   TO_STRING(cboXSEIZOU_DT.SelectedValue), _
                                                   TO_STRING(cboXLINE_NO.SelectedValue), _
                                                   cboXPALLET_NO_FROM, True)      'ﾊﾟﾚｯﾄ№ FROM
                Call MakeHoryuSettei_cboXPALLET_NO(TO_STRING(cboFPLACE_CD.SelectedValue.ToString), _
                                                   cboFHINMEI_CD.Text, _
                                                   TO_STRING(cboXSEIZOU_DT.SelectedValue), _
                                                   TO_STRING(cboXLINE_NO.SelectedValue), _
                                                   cboXPALLET_NO_TO, True)        'ﾊﾟﾚｯﾄ№ TO


                If mFlag_GRID_CLEAR = False Then
                    '(ｸﾞﾘｯﾄﾞに表示ある時)
                    '*********************************************
                    ' ｸﾞﾘｯﾄﾞ表示
                    '*********************************************
                    grdList.Columns.Clear()
                    Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
                    Call grdListSetup()

                    mFlag_GRID_CLEAR = True
                End If

            End If


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "　ﾗｲﾝ№ｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞ          ｲﾍﾞﾝﾄ   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾗｲﾝ№ｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cboXLINE_NO_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboXLINE_NO.SelectedIndexChanged
        Try


            If mFlag_Form_Load = False Then

                '===================================
                '在庫問合せ ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
                '===================================
                Call MakeHoryuSettei_cboXPALLET_NO(TO_STRING(cboFPLACE_CD.SelectedValue.ToString), _
                                                   cboFHINMEI_CD.Text, _
                                                   TO_STRING(cboXSEIZOU_DT.SelectedValue), _
                                                   TO_STRING(cboXLINE_NO.SelectedValue), _
                                                   cboXPALLET_NO_FROM, True)      'ﾊﾟﾚｯﾄ№ FROM
                Call MakeHoryuSettei_cboXPALLET_NO(TO_STRING(cboFPLACE_CD.SelectedValue.ToString), _
                                                   cboFHINMEI_CD.Text, _
                                                   TO_STRING(cboXSEIZOU_DT.SelectedValue), _
                                                   TO_STRING(cboXLINE_NO.SelectedValue), _
                                                   cboXPALLET_NO_TO, True)        'ﾊﾟﾚｯﾄ№ TO


                If mFlag_GRID_CLEAR = False Then
                    '(ｸﾞﾘｯﾄﾞに表示ある時)
                    '*********************************************
                    ' ｸﾞﾘｯﾄﾞ表示
                    '*********************************************
                    grdList.Columns.Clear()
                    Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
                    Call grdListSetup()

                    mFlag_GRID_CLEAR = True
                End If

            End If


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
    '↑↑↑↑ 2012.11.28 16:00 H.Morita 検索範囲の絞込み
#End Region
#Region "　ﾌｫｰﾑﾛｰﾄﾞ                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub InitializeChild()


        '*********************************************
        ' ｺﾝﾎﾞﾎﾞｯｸｽ初期設定
        '*********************************************
        '===================================
        '保管場所                   ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboFPLACE_CD, True)


        '===================================
        '保留区分～ﾊﾟﾚｯﾄ№ ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboXHINSHITU_STS, True)

        cboFHINMEI_CD.conn = gobjDb
        cboFHINMEI_CD.HinmeiLabel = lblFHINMEI
        cboFHINMEI_CD.Text = ""
        cboFHINMEI_CD.TableName = "TRST_STOCK"
        cboFHINMEI_CD.ComboBoxType = GamenCommon.cmpCboFHINMEI_CD.HINMEI_CBO_TYPE.SpecifiedAndMasterData
        cboFHINMEI_CD.HinmeiVisible = False
        ReDim cboFHINMEI_CD.FTRK_BUF_NO(21)                          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№指定
        cboFHINMEI_CD.FTRK_BUF_NO(0) = FTRK_BUF_NO_J9000
        cboFHINMEI_CD.FTRK_BUF_NO(1) = FTRK_BUF_NO_J8000
        cboFHINMEI_CD.FTRK_BUF_NO(2) = FTRK_BUF_NO_J8001
        cboFHINMEI_CD.FTRK_BUF_NO(3) = FTRK_BUF_NO_J8002
        cboFHINMEI_CD.FTRK_BUF_NO(4) = FTRK_BUF_NO_J8100
        cboFHINMEI_CD.FTRK_BUF_NO(5) = FTRK_BUF_NO_J8101
        cboFHINMEI_CD.FTRK_BUF_NO(6) = FTRK_BUF_NO_J8102
        cboFHINMEI_CD.FTRK_BUF_NO(7) = FTRK_BUF_NO_J8103
        cboFHINMEI_CD.FTRK_BUF_NO(8) = FTRK_BUF_NO_J8104
        cboFHINMEI_CD.FTRK_BUF_NO(9) = FTRK_BUF_NO_J8105
        cboFHINMEI_CD.FTRK_BUF_NO(10) = FTRK_BUF_NO_J8106
        cboFHINMEI_CD.FTRK_BUF_NO(11) = FTRK_BUF_NO_J8107
        cboFHINMEI_CD.FTRK_BUF_NO(12) = FTRK_BUF_NO_J8108
        cboFHINMEI_CD.FTRK_BUF_NO(13) = FTRK_BUF_NO_J8109
        cboFHINMEI_CD.FTRK_BUF_NO(14) = FTRK_BUF_NO_J8201
        cboFHINMEI_CD.FTRK_BUF_NO(15) = FTRK_BUF_NO_J8202
        cboFHINMEI_CD.FTRK_BUF_NO(16) = FTRK_BUF_NO_J8203
        cboFHINMEI_CD.FTRK_BUF_NO(17) = FTRK_BUF_NO_J8204
        cboFHINMEI_CD.FTRK_BUF_NO(18) = FTRK_BUF_NO_J8205
        cboFHINMEI_CD.FTRK_BUF_NO(19) = FTRK_BUF_NO_J8206
        cboFHINMEI_CD.FTRK_BUF_NO(20) = FTRK_BUF_NO_J8207
        cboFHINMEI_CD.FTRK_BUF_NO(21) = FTRK_BUF_NO_J8208
        cboFHINMEI_CD.FRES_KIND = FRES_KIND_SZAIKO                                             '引当状態 = 「在庫棚」
        cboFHINMEI_CD.cboSetupHinmeiCd(cboFHINMEI_CD.Text)          '品名ｺｰﾄﾞ

        Call MakeZaikoToiawase_cboXSEIZOU_DT(TO_STRING(cboFPLACE_CD.SelectedValue.ToString), cboFHINMEI_CD.Text, cboXSEIZOU_DT, True)         '製造年月日
        Call MakeZaikoToiawase_cboXLINE_NO(TO_STRING(cboFPLACE_CD.SelectedValue.ToString), _
                                                   cboFHINMEI_CD.Text, _
                                                   TO_STRING(cboXSEIZOU_DT.SelectedValue), cboXLINE_NO, True)             'ﾗｲﾝ№
        Call MakeHoryuSettei_cboXPALLET_NO(TO_STRING(cboFPLACE_CD.SelectedValue.ToString), _
                                                   cboFHINMEI_CD.Text, _
                                                   TO_STRING(cboXSEIZOU_DT.SelectedValue), _
                                                   TO_STRING(cboXLINE_NO.SelectedValue), _
                                                   cboXPALLET_NO_FROM, True)      'ﾊﾟﾚｯﾄ№ FROM
        Call MakeHoryuSettei_cboXPALLET_NO(TO_STRING(cboFPLACE_CD.SelectedValue.ToString), _
                                                   cboFHINMEI_CD.Text, _
                                                   TO_STRING(cboXSEIZOU_DT.SelectedValue), _
                                                   TO_STRING(cboXLINE_NO.SelectedValue), _
                                                   cboXPALLET_NO_TO, True)        'ﾊﾟﾚｯﾄ№ TO


        '*********************************************
        ' ﾃｷｽﾄﾎﾞｯｸｽ初期設定
        '*********************************************
        lblFHINMEI.Text = ""


        '*********************************************
        ' ｸﾞﾘｯﾄﾞ初期化
        '*********************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListSetup()

        mFlag_Form_Load = False
        mFlag_GRID_CLEAR = True

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
        cboFPLACE_CD.Dispose()              '保管場所
        cboXHINSHITU_STS.Dispose()          '品質ｽﾃｰﾀｽ
        cboFHINMEI_CD.Dispose()             '品名ｺｰﾄﾞ
        cboXSEIZOU_DT.Dispose()             '製造年月日
        cboXLINE_NO.Dispose()               'ﾗｲﾝ№
        cboXPALLET_NO_FROM.Dispose()        'ﾊﾟﾚｯﾄ№ FROM
        cboXPALLET_NO_TO.Dispose()          'ﾊﾟﾚｯﾄ№ TO
        grdList.Dispose()                   'ｸﾞﾘｯﾄﾞ

    End Sub
#End Region
#Region "  F1(検索)         ﾎﾞﾀﾝ押下処理　          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F1(検索)         ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F1Process()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.SearchBtn_Click) = False Then
            Exit Sub
        End If

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
#Region "  F4(全選択)       ﾎﾞﾀﾝ押下処理　          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F4(全選択)       ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F4Process()


        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.SelectAll_Click) = False Then

            Exit Sub

        End If

        grdList_Selection(True)


        ''*********************************************
        '' 構造体ｾｯﾄ
        ''*********************************************
        'Call SearchItem_Set()

        ''************************************
        '' ｸﾞﾘｯﾄﾞ表示
        ''************************************
        'Call grdListDisplaySub(grdList)

    End Sub
#End Region
#Region "  F5(全解除)       ﾎﾞﾀﾝ押下処理　          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F5(全解除)       ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F5Process()


        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.NotSelectAll_Click) = False Then

            Exit Sub

        End If

        grdList_Selection(False)


        ''*********************************************
        '' 構造体ｾｯﾄ
        ''*********************************************
        'Call SearchItem_Set()

        ''************************************
        '' ｸﾞﾘｯﾄﾞ表示
        ''************************************
        'Call grdListDisplaySub(grdList)

    End Sub
#End Region
#Region "  F6(登録)     ﾎﾞﾀﾝ押下処理　              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F6(出庫登録)     ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F6Process()

        '*******************************************************
        '入力ﾁｪｯｸ
        '*******************************************************
        If InputCheck(menmCheckCase.Regist_Click) = False Then
            Exit Sub
        End If


        'ｵﾌﾞｼﾞｪｸﾄNothingﾁｪｯｸ
        If IsNull(gobjFRM_308081) = False Then
            gobjFRM_308081.Close()
            gobjFRM_308081.Dispose()
            gobjFRM_308081 = Nothing
        End If

        '********************************************************************
        ' 子画面展開
        '********************************************************************
        gobjFRM_308081 = New FRM_308081                             'ｵﾌﾞｼﾞｪｸﾄ作成

        Call SetProperty(gobjFRM_308081)                  'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        Call gobjFRM_308081.ShowDialog()        '画面表示


        '*********************************************
        ' 構造体ｾｯﾄ
        '*********************************************
        Call SearchItem_Set()

        '************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '************************************
        Call grdListDisplaySub(grdList)


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
        Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_203000, Me)

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
        'ﾊﾟﾚｯﾄID取得
        '*********************************************
        Dim intRet As Integer = 0
        mstrFPALLET_ID = Nothing
        mstrFLOT_NO_STOCK = Nothing

        For ii As Integer = 0 To grdList.SelectedRows.Count - 1
            '(ﾙｰﾌﾟ:選択された行数)

            Dim strPalletTemp As String = grdList.Item(menmListCol.FPALLET_ID, grdList.SelectedRows(ii).Index).Value
            Dim strLOT_NO_STOCKTemp As String = grdList.Item(menmListCol.FLOT_NO_STOCK, grdList.SelectedRows(ii).Index).Value

            If IsNull(mstrFPALLET_ID) = True Then
                '(最初の一回)
                ReDim mstrFPALLET_ID(0)
                mstrFPALLET_ID(0) = strPalletTemp
                ReDim mstrFLOT_NO_STOCK(0)
                mstrFLOT_NO_STOCK(0) = strLOT_NO_STOCKTemp
            Else
                '(二回目以降)
                intRet = ArrayFindData(mstrFPALLET_ID, strPalletTemp)
                If intRet = -1 Then
                    '(ﾊﾟﾚｯﾄIDが見つからなかった場合)
                    ReDim Preserve mstrFPALLET_ID(UBound(mstrFPALLET_ID) + 1)
                    mstrFPALLET_ID(UBound(mstrFPALLET_ID)) = strPalletTemp
                    ReDim Preserve mstrFLOT_NO_STOCK(UBound(mstrFLOT_NO_STOCK) + 1)
                    mstrFLOT_NO_STOCK(UBound(mstrFLOT_NO_STOCK)) = strLOT_NO_STOCKTemp
                End If

            End If

        Next


    End Sub
#End Region
#Region "　入力ﾁｪｯｸ　                               "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】 [ IN  ]　入力ﾁｪｯｸ判別
    '【戻値】 True :入力ﾁｪｯｸ成功
    '         False:入力ﾁｪｯｸ失敗
    '*******************************************************************************************************************
    Private Function InputCheck(ByVal udtCheck_Case As menmCheckCase) As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        Select Case udtCheck_Case
            Case menmCheckCase.SearchBtn_Click
                '(検索ﾎﾞﾀﾝｸﾘｯｸ時)

                '==========================
                '保管場所  選択ﾁｪｯｸ
                '==========================
                'If TO_STRING(cboFPLACE_CD.SelectedValue.ToString) = CBO_ALL_VALUE _
                '    Or IsNull(TO_STRING(cboFPLACE_CD.SelectedValue.ToString)) = True Then
                '    '(ﾗｲﾝ№が選択されていない場合)
                '    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308080_01, PopupFormType.Ok, PopupIconType.Information)
                '    blnCheckErr = True
                '    Exit Select
                'End If

                '==========================
                'ﾊﾟﾚｯﾄ№  FROM,TO 大小ﾁｪｯｸ
                '==========================
                If (cboXPALLET_NO_FROM.Text <> "") And _
                   (cboXPALLET_NO_TO.Text <> "") Then
                    If (TO_STRING(cboXPALLET_NO_FROM.SelectedValue.ToString) > TO_STRING(cboXPALLET_NO_TO.SelectedValue.ToString)) Then
                        '(ﾊﾟﾚｯﾄ№の大小が間違っている場合)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308080_02, PopupFormType.Ok, PopupIconType.Information)
                        blnCheckErr = True
                        Exit Select
                    End If
                End If

                blnCheckErr = False

            Case menmCheckCase.SelectAll_Click
                '(全選択ﾎﾞﾀﾝｸﾘｯｸ時)

                blnCheckErr = False

            Case menmCheckCase.NotSelectAll_Click
                '(全解除ﾎﾞﾀﾝｸﾘｯｸ時)

                blnCheckErr = False

            Case menmCheckCase.Regist_Click
                '(登録ﾎﾞﾀﾝｸﾘｯｸ時)


                '==========================
                'ﾘｽﾄ選択ﾁｪｯｸ
                '==========================
                If grdList.SelectedRows.Count <= 0 Then
                    '(ﾘｽﾄが選択されていない場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_GRD_LIST, PopupFormType.Ok, PopupIconType.Information)
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
        mudtSEARCH_ITEM.FPLACE_CD = TO_STRING(cboFPLACE_CD.SelectedValue)              '保管場所
        mudtSEARCH_ITEM.XHINSHITU_STS = TO_STRING(cboXHINSHITU_STS.SelectedValue)      '品質ｽﾃｰﾀｽ
        mudtSEARCH_ITEM.FHINMEI_CD = cboFHINMEI_CD.Text                                '品名ｺｰﾄﾞ
        mudtSEARCH_ITEM.XSEIZOU_DT = TO_STRING(cboXSEIZOU_DT.SelectedValue)            '製造年月日
        mudtSEARCH_ITEM.XLINE_NO = TO_STRING(cboXLINE_NO.SelectedValue)                'ﾗｲﾝ№
        mudtSEARCH_ITEM.FPALLET_NO_FROM = TO_STRING(cboXPALLET_NO_FROM.SelectedValue)  'ﾊﾟﾚｯﾄNO FROM
        mudtSEARCH_ITEM.FPALLET_NO_TO = TO_STRING(cboXPALLET_NO_TO.SelectedValue)      'ﾊﾟﾚｯﾄNO TO

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
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "    TPRG_TRK_BUF.FTRK_BUF_NO "                  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      (非表示)ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        strSQL &= vbCrLf & "  , TMST_TRK.FBUF_NAME "                        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.           ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称
        strSQL &= vbCrLf & "  , TRST_STOCK.FPALLET_ID "                     '在庫情報.          (非表示)ﾊﾟﾚｯﾄID
        strSQL &= vbCrLf & "  , TRST_STOCK.FLOT_NO_STOCK "                  '在庫情報.          (非表示)ﾛｯﾄ№
        strSQL &= vbCrLf & "  , TRST_STOCK.FHINMEI_CD "                     '在庫情報.                  品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "  , TMST_ITEM.FHINMEI "                         '品目ﾏｽﾀ.                   品名
        strSQL &= vbCrLf & "  , TRST_STOCK.XSEIZOU_DT "                     '在庫情報.                  製造年月日
        strSQL &= vbCrLf & "  , TRST_STOCK.XLINE_NO "                       '在庫情報.                  ﾗｲﾝ№
        strSQL &= vbCrLf & "  , TRST_STOCK.XPALLET_NO "                     '在庫情報.                  ﾊﾟﾚｯﾄNO
        strSQL &= vbCrLf & "  , TRST_STOCK.XHINSHITU_STS "                  '在庫情報.          (非表示)品質ｽﾃｰﾀｽ
        strSQL &= vbCrLf & "  , HASH01.FGAMEN_DISP AS XHINSHITU_STS_DSP "   '在庫情報.                  品質ｽﾃｰﾀｽ(表示用)
        strSQL &= vbCrLf & "  , TRST_STOCK.FTR_VOL "                        '在庫情報.                  搬送管理量(積込数)

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    TMST_TRK "                              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ
        strSQL &= vbCrLf & "  , TPRG_TRK_BUF "                          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
        strSQL &= vbCrLf & "  , TRST_STOCK "                            '在庫情報
        strSQL &= vbCrLf & "  , TMST_ITEM "                             '品目ﾏｽﾀ
        strSQL &= vbCrLf & "  , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH01", "TRST_STOCK", "XHINSHITU_STS")

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE 1 = 1  "
        strSQL &= vbCrLf & "    AND TMST_TRK.FTRK_BUF_NO = TPRG_TRK_BUF.FTRK_BUF_NO "
        strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FPALLET_ID  = TRST_STOCK.FPALLET_ID(+) "
        strSQL &= vbCrLf & "    AND TRST_STOCK.FHINMEI_CD = TMST_ITEM.FHINMEI_CD(+) "
        strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FRES_KIND = " & TO_STRING(FRES_KIND_SZAIKO)      '引当状態 = 「在庫棚」
        strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FPALLET_ID NOT IN( "                             '在庫棚(未引当)
        strSQL &= vbCrLf & "                 (SELECT FPALLET_ID FROM XSTS_HIKIATE_K1) "
        strSQL &= vbCrLf & "                                      ) "
        strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FPALLET_ID NOT IN( "                             '在庫棚(未引当)
        strSQL &= vbCrLf & "                 (SELECT FPALLET_ID FROM TSTS_HIKIATE) "
        strSQL &= vbCrLf & "                                      ) "
        strSQL &= vbCrLf & "    AND TMST_ITEM.XKANRI_KUBUN = " & XKANRI_KUBUN_JHOST               '管理区分 = 「ﾎｽﾄ管理」
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH01", "TRST_STOCK", "XHINSHITU_STS")

        '----------------------------------------------
        '保管場所
        '----------------------------------------------
        If mudtSEARCH_ITEM.FPLACE_CD <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "      AND TPRG_TRK_BUF.FTRK_BUF_NO = " & mudtSEARCH_ITEM.FPLACE_CD
        End If

        '----------------------------------------------
        '品質ｽﾃｰﾀｽ
        '----------------------------------------------
        If mudtSEARCH_ITEM.XHINSHITU_STS <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "      AND TRST_STOCK.XHINSHITU_STS = " & mudtSEARCH_ITEM.XHINSHITU_STS
        End If

        '----------------------------------------------
        '品目ｺｰﾄﾞ
        '----------------------------------------------
        If mudtSEARCH_ITEM.FHINMEI_CD <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "      AND TRST_STOCK.FHINMEI_CD LIKE '" & mudtSEARCH_ITEM.FHINMEI_CD & "%' "
        End If

        '----------------------------------------------
        '製造年月日
        '----------------------------------------------
        If mudtSEARCH_ITEM.XSEIZOU_DT <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "      AND TRST_STOCK.XSEIZOU_DT = TO_DATE('" & mudtSEARCH_ITEM.XSEIZOU_DT & "','YYYY/MM/DD HH24:MI:SS')"
        End If

        '----------------------------------------------
        'ﾗｲﾝ№
        '----------------------------------------------
        If mudtSEARCH_ITEM.XLINE_NO <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            '↓↓↓↓ 2012.12.07 13:00 H.Morita 文字型、数値型を考慮する
            'strSQL &= vbCrLf & "      AND TRST_STOCK.XLINE_NO = " & mudtSEARCH_ITEM.XLINE_NO
            strSQL &= vbCrLf & "      AND TRST_STOCK.XLINE_NO = '" & mudtSEARCH_ITEM.XLINE_NO & "' "
            '↑↑↑↑ 2012.12.07 13:00 H.Morita 文字型、数値型を考慮する
        End If

        '----------------------------------------------
        'ﾊﾟﾚｯﾄ№ FROM
        '----------------------------------------------
        If mudtSEARCH_ITEM.FPALLET_NO_FROM <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "      AND TRST_STOCK.XPALLET_NO >= '" & mudtSEARCH_ITEM.FPALLET_NO_FROM & "' "
        End If

        '----------------------------------------------
        'ﾊﾟﾚｯﾄ№ TO
        '----------------------------------------------
        If mudtSEARCH_ITEM.FPALLET_NO_TO <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "      AND TRST_STOCK.XPALLET_NO <= '" & mudtSEARCH_ITEM.FPALLET_NO_TO & "' "
        End If


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
        'grdList.AllowUserToResizeColumns = False

    End Sub
#End Region

#Region "  ﾘｽﾄ選択/解除処理                         "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】[IN ]blnSelectFlg
    '【戻値】
    '*******************************************************************************************************************
    Private Sub grdList_Selection(ByVal blnSelectFlg As Boolean)

        Call gobjComFuncFRM.GridSelect(grdList, -1, -1, Nothing)      'ｸﾞﾘｯﾄﾞ選択処理

        '*********************************************
        ' ﾘｽﾄ選択
        '*********************************************
        Dim lngii As Integer
        If 0 <= grdList.Rows.Count - 1 Then
            For lngii = 0 To grdList.Rows.Count - 1
                grdList.Rows(lngii).Selected = blnSelectFlg
            Next
        End If

    End Sub
#End Region
#Region "　ﾌﾟﾛﾊﾟﾃｨｾｯﾄ(詳細)　                       "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub SetProperty(ByVal objForm As FRM_308081)

        objForm.userPALLET_ID = mstrFPALLET_ID                'ﾊﾟﾚｯﾄID
        objForm.userFLOT_NO_STOCK = mstrFLOT_NO_STOCK         '在庫ﾛｯﾄ№

    End Sub
#End Region

End Class