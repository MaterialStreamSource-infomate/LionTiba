'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】問合せ出庫設定画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess

#End Region

Public Class FRM_303020
#Region "　共通変数　                               "

    '検索条件用構造体
    Private mudtSEARCH_ITEM As New SEARCH_ITEM

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ

    Private mblnCV_YOUTO As Boolean = False             'CV用途

    '選択されたｸﾞﾘｯﾄﾞﾘｽﾄの配列
    Private mudtGRID_LIST_ITEM() As GRID_LIST_ITEM = Nothing

    '手前 搬送ﾃﾞｰﾀ
    Private mudtFront_HANSOU_DATA() As HANSOU_DATA = Nothing
    '奥 搬送ﾃﾞｰﾀ
    Private mudtBack_HANSOU_DATA() As HANSOU_DATA = Nothing

    '平置き、検品ｴﾘｱ 搬送ﾃﾞｰﾀ
    Private mudtPL_HANSOU_DATA() As HANSOU_DATA = Nothing

    ''' <summary>ﾁｪｯｸ用列挙体</summary>
    Enum menmCheckCase
        ModeChangeBtn_Click             '出庫ﾓｰﾄﾞ切替ﾎﾞﾀﾝｸﾘｯｸ時
        SearchBtn_Click                 '検索ﾎﾞﾀﾝｸﾘｯｸ時
        SelectAll_Click                 '全選択ﾎﾞﾀﾝｸﾘｯｸ時
        NotSelectAll_Click              '全解除ﾎﾞﾀﾝｸﾘｯｸ時
        OutReg_Click                    '出庫登録ﾎﾞﾀﾝｸﾘｯｸ時
    End Enum

    ''' <summary>ｸﾞﾘｯﾄﾞ項目</summary>
    Enum menmListCol
        FTRK_BUF_NO                     '問合せ出庫設定.       ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
        FTRK_BUF_NO_Disp                '問合せ出庫設定.       ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(表示用)
        XINMEI_CD                       '問合せ出庫設定.       品名ｺｰﾄﾞ
        FHINMEI_CD                      '問合せ出庫設定.       品名記号
        FHINMEI                         '問合せ出庫設定.       品名
        XPROD_LINE                      '問合せ出庫設定.       生産ﾗｲﾝNo.
        XPROD_LINE_Disp                 '問合せ出庫設定.       生産ﾗｲﾝNo.(表示用)
        FTR_VOL                         '問合せ出庫設定.       数量
        DISP_ADDRESS                    '問合せ出庫設定.       ﾛｹｰｼｮﾝ
        FARRIVE_DT                      '問合せ出庫設定.       在庫発生日時
        XKENSA_KUBUN                    '問合せ出庫設定.       検査区分
        XKENSA_KUBUN_Disp               '問合せ出庫設定.       検査区分(表示用)
        FHORYU_KUBUN                    '問合せ出庫設定.       保留区分
        FHORYU_KUBUN_Disp               '問合せ出庫設定.       保留区分(表示用)
        XKENPIN_KUBUN                   '問合せ出庫設定.       検品区分
        XKENPIN_KUBUN_Disp              '問合せ出庫設定.       検品区分(表示用)
        XARTICLE_TYPE_CODE              '問合せ出庫設定.       製品区分
        XARTICLE_TYPE_CODE_Disp         '問合せ出庫設定.       製品区分(表示用)
        FLOT_NO                         '問合せ出庫設定.       ﾛｯﾄNo.
        FPALLET_ID                      '問合せ出庫設定.       ﾊﾟﾚｯﾄID
        'ｿｰﾄ用
        XTANA_BLOCK                     '問合せ出庫設定.       棚ﾌﾞﾛｯｸ
        XTANA_BLOCK_DTL                 '問合せ出庫設定.       棚ﾌﾞﾛｯｸ詳細
        FRAC_RETU                       '問合せ出庫設定.       列
        FRAC_REN                        '問合せ出庫設定.       連
        FRAC_DAN                        '問合せ出庫設定.       段
        FRAC_EDA                        '問合せ出庫設定.       枝

        MAXCOL

    End Enum

#End Region
#Region "  構造体定義　                             "

    ''' <summary>検索条件</summary>
    Private Structure SEARCH_ITEM
        Dim FTRK_BUF_NO As String           '在庫ｴﾘｱ
        Dim FHINMEI_CD As String            '品名ｺｰﾄﾞ
        Dim FARRIVE_DT_FROM As String       '入庫日(FROM)
        Dim FARRIVE_DT_TO As String         '入庫日(TO)
        Dim XPROD_LINE As String            '生産ﾗｲﾝNo.
        Dim XKENSA_KUBUN As String          '検査区分
        Dim FHORYU_KUBUN As String          '保留区分
        Dim XARTICLE_TYPE_CODE As String    '商品区分
        Dim FTR_VOL As String               '数量
    End Structure

    ''' <summary>ｸﾞﾘｯﾄﾞﾘｽﾄ</summary>
    Private Structure GRID_LIST_ITEM
        Dim FTRK_BUF_NO As String       '在庫ｴﾘｱ
        Dim PALLET_ID As String         'ﾊﾟﾚｯﾄID
        Dim TANA_BLOCK As String        '棚ﾌﾞﾛｯｸ
        Dim TANA_BLOCK_DTL As String    '棚ﾌﾞﾛｯｸ詳細
        Dim RAC_RETU As Integer         '列
        Dim RAC_REN As Integer          '連
        Dim RAC_DAN As Integer          '段
        Dim RAC_EDA As Integer          '枝
        Dim PARE_FLAG As Boolean        'ﾍﾟｱ有ﾌﾗｸﾞ
    End Structure

    ''' <summary>搬送ﾃﾞｰﾀ</summary>
    Private Structure HANSOU_DATA
        Dim RAC_RETU As Integer             '列(共通)
        Dim RAC_DAN As Integer              '段(共通)
        Dim RAC_EDA As Integer              '枝(共通)
        'Dim OYA_Flag As Boolean             '親有り
        Dim PARE_FLAG As Boolean            'ﾍﾟｱ搬送

        Dim PALLET_ID_1 As String           'ﾊﾟﾚｯﾄID(1)
        Dim TANA_BLOCK_1 As String          '棚ﾌﾞﾛｯｸ(1)
        Dim TANA_BLOCK_DTL_1 As String      '棚ﾌﾞﾛｯｸ詳細(1)
        Dim RAC_REN_1 As Integer            '連(1)

        Dim PALLET_ID_2 As String          'ﾊﾟﾚｯﾄID(2)
        Dim TANA_BLOCK_2 As String         '棚ﾌﾞﾛｯｸ(2)
        Dim TANA_BLOCK_DTL_2 As String     '棚ﾌﾞﾛｯｸ詳細(2)
        Dim RAC_REN_2 As Integer           '連(2)

    End Structure

    ''' <summary>棚ﾌﾞﾛｯｸﾃﾞｰﾀ</summary>
    Private Structure TANA_BLOCK_DATA
        Dim TANA_BLOCK As String        '棚ﾌﾞﾛｯｸ
        Dim PALLET_ID_1 As String       'ﾊﾟﾚｯﾄID 1
        Dim PALLET_ID_2 As String       'ﾊﾟﾚｯﾄID 2
        Dim PALLET_ID_3 As String       'ﾊﾟﾚｯﾄID 3
        Dim PALLET_ID_4 As String       'ﾊﾟﾚｯﾄID 4

        Dim FLAG_Front As Boolean       '手前 在庫ﾌﾗｸﾞ
        Dim FLAG_Back As Boolean        '奥 在庫ﾌﾗｸﾞ
    End Structure


#End Region
#Region "  ｲﾍﾞﾝﾄ   "

#Region "　出庫STｺﾝﾎﾞﾎﾞｯｸｽﾌｫｰｶｽ           ｲﾍﾞﾝﾄ     "
    Private Sub cboFTRK_BUF_NO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFTRK_BUF_NO.GotFocus
        tmr303020.Enabled = False       'ﾀｲﾏｰ停止
    End Sub
#End Region
#Region "　出庫STｺﾝﾎﾞﾎﾞｯｸｽﾌｫｰｶｽﾛｽﾄ        ｲﾍﾞﾝﾄ     "
    Private Sub cboFTRK_BUF_NO_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFTRK_BUF_NO.LostFocus
        Call tmr303020_TickProcess()    'ﾀｲﾏｰ処理
        tmr303020.Enabled = True        'ﾀｲﾏｰ再開
    End Sub
#End Region
#Region "　出庫STｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞ       ｲﾍﾞﾝﾄ     "
    Private Sub cboFTRK_BUF_NO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFTRK_BUF_NO.SelectedIndexChanged
        Try
            If mFlag_Form_Load = False Then

                Dim intSelect As Integer
                intSelect = TO_INTEGER(cboFTRK_BUF_NO.SelectedValue)

                Select Case intSelect
                    Case FTRK_BUF_NO_J2038, FTRK_BUF_NO_J1171, FTRK_BUF_NO_J1172, FTRK_BUF_NO_J1173, FTRK_BUF_NO_J1174
                        '(D21,C01～C04)
                        ' ''lblSTMode.Visible = True
                        ' ''cboXCONVYOR_YOUTO.Enabled = False
                        ' ''cmdModeChange.Visible = False
                        mblnCV_YOUTO = False
                        Call tmr303020_TickProcess()

                    Case FTRK_BUF_NO_J1102, FTRK_BUF_NO_J1121, FTRK_BUF_NO_J1122, FTRK_BUF_NO_J1123, FTRK_BUF_NO_J1124, FTRK_BUF_NO_J1125, FTRK_BUF_NO_J1127, FTRK_BUF_NO_J1128, FTRK_BUF_NO_J1129, FTRK_BUF_NO_J1130, FTRK_BUF_NO_J1131, _
                             FTRK_BUF_NO_J1132, FTRK_BUF_NO_J1133, FTRK_BUF_NO_J1134, FTRK_BUF_NO_J1135, FTRK_BUF_NO_J1137, FTRK_BUF_NO_J1138, FTRK_BUF_NO_J1139, FTRK_BUF_NO_J1140, FTRK_BUF_NO_J1141, FTRK_BUF_NO_J1142, _
                             FTRK_BUF_NO_J1143, FTRK_BUF_NO_J1144, FTRK_BUF_NO_J1151, FTRK_BUF_NO_J1152, FTRK_BUF_NO_J1153, FTRK_BUF_NO_J1154, FTRK_BUF_NO_J1155, FTRK_BUF_NO_J1156, FTRK_BUF_NO_J1157, FTRK_BUF_NO_J1158, _
                             FTRK_BUF_NO_J1159, FTRK_BUF_NO_J1161, FTRK_BUF_NO_J1162
                        '(B01～B34)
                        '' ''lblSTMode.Visible = True
                        '' ''cboXCONVYOR_YOUTO.Enabled = True
                        '' ''cmdModeChange.Visible = True
                        mblnCV_YOUTO = True
                        Call tmr303020_TickProcess()

                    Case Else
                        lblSTMode.Visible = False
                        cboXCONVYOR_YOUTO.Enabled = False
                        cmdModeChange.Visible = False
                        mblnCV_YOUTO = False

                End Select


            End If

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
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
#Region "　ﾓｰﾄﾞ更新    ﾀｲﾏ　                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾓｰﾄﾞ更新    ﾀｲﾏ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tmr303020_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr303020.Tick
        Try

            tmr303020.Enabled = False

            '**************************************************
            ' ﾓｰﾄﾞ取得ﾀｲﾏｰ処理
            '**************************************************
            Call tmr303020_TickProcess()

        Catch ex As Exception
            ComError(ex)

        Finally
            tmr303020.Enabled = True

        End Try
    End Sub
#End Region
#Region "　出庫ﾓｰﾄﾞ切替 　ﾎﾞﾀﾝ押下                  "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub cmdModeChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdModeChange.Click
        Try
            Call cmdModeChange_ClickProcess()

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "　ﾌｫｰﾑｱｸﾃｨﾌﾞ                               "
    '*******************************************************************************************************************
    '【機能】ﾌｫｰﾑｱｸﾃｨﾌﾞ時ｲﾍﾞﾝﾄ
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub FRM_303020_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            Me.ActiveControl = Nothing          'ﾃﾞﾌｫﾙﾄﾌｫｰｶｽの無効化

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try

    End Sub
#End Region
#End Region
#Region "　ﾌｫｰﾑﾛｰﾄﾞ                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub InitializeChild()

        '===================================
        '出庫ST ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(Me.Name, cboFTRK_BUF_NO, False, -1)
        'Call gobjComFuncFRM.cboNYUUKO_ST_Setup(Me.Name, cboFTRK_BUF_NO, False, -1)  '設定出庫のｺﾝﾍﾞﾔのみ

        lblSTMode.Text = ""                          '出庫ST・状態
        lblSTMode.BackColor = gcModeColor_Black

        '===================================
        ' 設定ﾓｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ         ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(Me.Name, Me.cboXCONVYOR_YOUTO, True)

        '===================================
        '在庫ｴﾘｱ ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(Me.Name, cboFTRK_BUF_NO_ZAIKO, True, 0)

        '===================================
        '品名ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ  ｾｯﾄ
        '===================================
        cboFHINMEI_CD.conn = gobjDb
        cboFHINMEI_CD.HinmeiLabel = lblFHINMEI
        cboFHINMEI_CD.Text = ""
        cboFHINMEI_CD.HinmeiVisible = False
        cboFHINMEI_CD.cboSetupHinmeiCd(cboFHINMEI_CD.Text)

        '===================================
        '期間 初期化
        '===================================
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:S.Ouchi 2014/12/12 在庫発生日時指定異常の対応
        Call gobjComFuncFRM.dtpKikanFromToSetup(dtpFrom, dtpTo)
        'JobMate:S.Ouchi 2014/12/12 在庫発生日時指定異常の対応
        '↑↑↑↑↑↑************************************************************************************************************
        dtpFrom.userChecked = False
        dtpTo.userChecked = False

        '===================================
        '生産ﾗｲﾝNo.ｺﾝﾎﾞﾎﾞｯｸｽ  ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboMsterSetup("XMST_PROD_LINE", "XPROD_LINE", "XPROD_LINE", "XPROD_LINE_NAME", cboXPROD_LINE)
        'Call gobjComFuncFRM.cboMsterSetup("XMST_PROD_LINE", "XPROD_LINE", "XPROD_LINE_NAME", "XPROD_LINE", cboXPROD_LINE)

        '===================================
        '検索区分 ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboXKENSA_KUBUN, True)

        '===================================
        '保留区分 ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboFHORYU_KUBUN, True)

        '===================================
        '商品区分 ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboXARTICLE_TYPE_CODE, True)

        '*********************************************
        ' ｸﾞﾘｯﾄﾞ初期化
        '*********************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        grdList.MultiSelect = True                                              '複数行選択
        Call grdListSetup()

        '**************************************************
        ' ﾓｰﾄﾞ取得ﾀｲﾏｰ処理
        '**************************************************
        Call tmr303020_TickProcess()

        '**********************************************************
        ' ﾀｲﾏｰ設定
        '**********************************************************
        tmr303020.Interval = TO_INTEGER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_JGS303020_001))
        tmr303020.Enabled = True

        mFlag_Form_Load = False

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
        cboFTRK_BUF_NO.Dispose()           '出庫ST
        lblSTMode.Dispose()
        cboFHINMEI_CD.Dispose()
        lblFHINMEI.Dispose()
        dtpFrom.Dispose()
        dtpTo.Dispose()
        cboXPROD_LINE.Dispose()
        cboXKENSA_KUBUN.Dispose()
        cboFHORYU_KUBUN.Dispose()
        grdList.Dispose()

    End Sub
#End Region
#Region "  F1(検索)  ﾎﾞﾀﾝ押下処理　                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F1(検索) ﾎﾞﾀﾝ押下処理
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
        Call SeachItem_Set()


        '*********************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '*********************************************
        If txtPL_VOL.Text = "" Then
            '(数量指定がない場合)
            Call grdListDisplaySub(grdList)
        Else
            '(数量指定がある場合)
            Call grdListDisplay_PL_VOL()
        End If


    End Sub
#End Region
#Region "  F4(全選択)  ﾎﾞﾀﾝ押下処理　               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F4(全選択) ﾎﾞﾀﾝ押下処理
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

        grdList.SelectAll()

    End Sub
#End Region
#Region "  F5(全解除)  ﾎﾞﾀﾝ押下処理　               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F5(全解除) ﾎﾞﾀﾝ押下処理
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

        Call grdList.ClearSelection()
    End Sub
#End Region
#Region "  F6(出庫登録)  ﾎﾞﾀﾝ押下処理　             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F6(出庫登録) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F6Process()

        tmr303020.Enabled = False

        '*******************************************************
        '入力ﾁｪｯｸ
        '*******************************************************
        If InputCheck(menmCheckCase.OutReg_Click) = False Then
            tmr303020.Enabled = True
            Exit Sub
        End If

        '*******************************************************
        '出庫登録
        '*******************************************************
        If mudtGRID_LIST_ITEM(0).FTRK_BUF_NO = FTRK_BUF_NO_J9000 Then
            '(自動倉庫が対象の場合)
            Call MakeFUTAI_DATA()

            If InquiryOut() = False Then
                tmr303020.Enabled = True
                Exit Sub
            End If
        Else
            '(それ以外が対象の場合)
            If InquiryOut2() = False Then
                tmr303020.Enabled = True
                Exit Sub
            End If
        End If
        '*********************************************
        ' 構造体ｾｯﾄ
        '*********************************************
        Call SeachItem_Set()

        '*********************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '*********************************************
        If txtPL_VOL.Text = "" Then
            '(数量指定がない場合)
            Call grdListDisplaySub(grdList)
        Else
            '(数量指定がある場合)
            Call grdListDisplay_PL_VOL()
        End If

        tmr303020.Enabled = True

    End Sub
#End Region

#Region "　出庫ﾓｰﾄﾞ切替  ﾎﾞﾀﾝ押下処理               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｷｬﾝｾﾙ ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdModeChange_ClickProcess()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.ModeChangeBtn_Click) = False Then
            Exit Sub
        End If

        '********************************************************************
        'ｿｹｯﾄ送信処理
        '********************************************************************
        If SendSocket01() = False Then
            Exit Sub
        End If


    End Sub
#End Region

#Region "　構造体ｾｯﾄ　                              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 構造体ｾｯﾄ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SeachItem_Set()

        '********************************************************************
        '構造体に値をｾｯﾄ
        '********************************************************************
        mudtSEARCH_ITEM = New SEARCH_ITEM

        '===============================================
        '在庫ｴﾘｱ
        '===============================================
        mudtSEARCH_ITEM.FTRK_BUF_NO = TO_STRING(cboFTRK_BUF_NO_ZAIKO.SelectedValue)

        '===============================================
        '品名ｺｰﾄﾞ
        '===============================================
        mudtSEARCH_ITEM.FHINMEI_CD = TO_STRING(cboFHINMEI_CD.Text)

        '===============================================
        '入庫日(FROM)
        '===============================================
        If dtpFrom.userDispChecked = True Then
            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2014/12/12 在庫発生日時指定異常の対応
            '' ''mudtSEARCH_ITEM.FARRIVE_DT_FROM = Format(TO_DATE(dtpFrom.userDateTimeText), "yyyy/MM/dd")   '期間FROM
            '' ''mudtSEARCH_ITEM.FARRIVE_DT_FROM = mudtSEARCH_ITEM.FARRIVE_DT_FROM & " 00:00:00"
            mudtSEARCH_ITEM.FARRIVE_DT_FROM = dtpFrom.userDateTimeText  '期間FROM
            'JobMate:S.Ouchi 2014/12/12 在庫発生日時指定異常の対応
            '↑↑↑↑↑↑************************************************************************************************************
        Else
            mudtSEARCH_ITEM.FARRIVE_DT_FROM = ""
        End If

        '===============================================
        '入庫日(TO)
        '===============================================
        If dtpTo.userDispChecked = True Then
            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2014/12/12 在庫発生日時指定異常の対応
            '' ''mudtSEARCH_ITEM.FARRIVE_DT_TO = Format(TO_DATE(dtpTo.userDateTimeText), "yyyy/MM/dd")   '期間TO
            '' ''mudtSEARCH_ITEM.FARRIVE_DT_TO = mudtSEARCH_ITEM.FARRIVE_DT_TO & " 23:59:59"
            mudtSEARCH_ITEM.FARRIVE_DT_TO = dtpTo.userDateTimeText      '期間TO
            'JobMate:S.Ouchi 2014/12/12 在庫発生日時指定異常の対応
            '↑↑↑↑↑↑************************************************************************************************************
        Else
            mudtSEARCH_ITEM.FARRIVE_DT_TO = ""
        End If

        '===============================================
        '生産ﾗｲﾝNo.
        '===============================================
        mudtSEARCH_ITEM.XPROD_LINE = TO_STRING(cboXPROD_LINE.SelectedValue.ToString)

        '===============================================
        '検査区分
        '===============================================
        mudtSEARCH_ITEM.XKENSA_KUBUN = TO_STRING(cboXKENSA_KUBUN.SelectedValue.ToString)

        '===============================================
        '保留区分
        '===============================================
        mudtSEARCH_ITEM.FHORYU_KUBUN = TO_STRING(cboFHORYU_KUBUN.SelectedValue.ToString)

        '===============================================
        '商品区分
        '===============================================
        mudtSEARCH_ITEM.XARTICLE_TYPE_CODE = TO_STRING(cboXARTICLE_TYPE_CODE.SelectedValue.ToString)

        '===============================================
        '数量
        '===============================================
        mudtSEARCH_ITEM.FTR_VOL = TO_STRING(txtPL_VOL.Text)

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
        mudtGRID_LIST_ITEM = Nothing
        For ii As Integer = 0 To grdList.SelectedRows.Count - 1
            '(ﾙｰﾌﾟ:選択された行数)

            Dim strSELECT_PALLET_ID As String = grdList.Item(menmListCol.FPALLET_ID, grdList.SelectedRows(ii).Index).Value

            If IsNull(mudtGRID_LIST_ITEM) = True Then
                '(最初の一回)
                ReDim mudtGRID_LIST_ITEM(0)

                mudtGRID_LIST_ITEM(0).PALLET_ID = strSELECT_PALLET_ID                                                                       'ﾊﾟﾚｯﾄID

                mudtGRID_LIST_ITEM(0).FTRK_BUF_NO = grdList.Item(menmListCol.FTRK_BUF_NO, grdList.SelectedRows(ii).Index).Value             'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.

                If mudtGRID_LIST_ITEM(0).FTRK_BUF_NO = FTRK_BUF_NO_J9000 Then
                    '(自動倉庫の場合)
                    mudtGRID_LIST_ITEM(0).TANA_BLOCK = grdList.Item(menmListCol.XTANA_BLOCK, grdList.SelectedRows(ii).Index).Value              '棚ﾌﾞﾛｯｸ
                    mudtGRID_LIST_ITEM(0).TANA_BLOCK_DTL = grdList.Item(menmListCol.XTANA_BLOCK_DTL, grdList.SelectedRows(ii).Index).Value      '棚ﾌﾞﾛｯｸ詳細
                    mudtGRID_LIST_ITEM(0).RAC_RETU = grdList.Item(menmListCol.FRAC_RETU, grdList.SelectedRows(ii).Index).Value                  '列
                    mudtGRID_LIST_ITEM(0).RAC_REN = grdList.Item(menmListCol.FRAC_REN, grdList.SelectedRows(ii).Index).Value                    '連
                    mudtGRID_LIST_ITEM(0).RAC_DAN = grdList.Item(menmListCol.FRAC_DAN, grdList.SelectedRows(ii).Index).Value                    '段
                    mudtGRID_LIST_ITEM(0).RAC_EDA = grdList.Item(menmListCol.FRAC_EDA, grdList.SelectedRows(ii).Index).Value                    '枝
                End If

            Else
                '(二回目以降)

                '重複確認
                Dim blnAlready As Boolean = False

                For Each grid_list_item As GRID_LIST_ITEM In mudtGRID_LIST_ITEM
                    If grid_list_item.PALLET_ID = strSELECT_PALLET_ID Then
                        blnAlready = True
                        Exit For
                    End If
                Next

                If blnAlready = False Then
                    '(重複したﾊﾟﾚｯﾄIDが見つからなかった場合)
                    ReDim Preserve mudtGRID_LIST_ITEM(UBound(mudtGRID_LIST_ITEM) + 1)
                    mudtGRID_LIST_ITEM(ii).PALLET_ID = strSELECT_PALLET_ID                                                                  'ﾊﾟﾚｯﾄID
                    mudtGRID_LIST_ITEM(ii).FTRK_BUF_NO = grdList.Item(menmListCol.FTRK_BUF_NO, grdList.SelectedRows(ii).Index).Value        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
                    If mudtGRID_LIST_ITEM(ii).FTRK_BUF_NO = FTRK_BUF_NO_J9000 Then
                        '(自動倉庫の場合)
                        mudtGRID_LIST_ITEM(ii).TANA_BLOCK = grdList.Item(menmListCol.XTANA_BLOCK, grdList.SelectedRows(ii).Index).Value         '棚ﾌﾞﾛｯｸ
                        mudtGRID_LIST_ITEM(ii).TANA_BLOCK_DTL = grdList.Item(menmListCol.XTANA_BLOCK_DTL, grdList.SelectedRows(ii).Index).Value '棚ﾌﾞﾛｯｸ詳細
                        mudtGRID_LIST_ITEM(ii).RAC_RETU = grdList.Item(menmListCol.FRAC_RETU, grdList.SelectedRows(ii).Index).Value             '列
                        mudtGRID_LIST_ITEM(ii).RAC_REN = grdList.Item(menmListCol.FRAC_REN, grdList.SelectedRows(ii).Index).Value               '連
                        mudtGRID_LIST_ITEM(ii).RAC_DAN = grdList.Item(menmListCol.FRAC_DAN, grdList.SelectedRows(ii).Index).Value               '段
                        mudtGRID_LIST_ITEM(ii).RAC_EDA = grdList.Item(menmListCol.FRAC_EDA, grdList.SelectedRows(ii).Index).Value               '枝
                    End If
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

        Dim intRet As RetCode                   '戻り値
        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ
        Dim strMsg As String = ""

        Select Case udtCheck_Case
            Case menmCheckCase.ModeChangeBtn_Click
                '(出庫ﾓｰﾄﾞ切替ﾎﾞﾀﾝｸﾘｯｸ時)

                '========================================
                '設定ﾓｰﾄﾞ
                '========================================
                If cboXCONVYOR_YOUTO.SelectedIndex < 1 Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303020_11, _
                                     PopupFormType.Ok, _
                                     PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If

                '========================================
                'CVｸﾞﾙｰﾌﾟ内に別の設定がないか確認
                '========================================
                If TO_STRING(cboXCONVYOR_YOUTO.SelectedValue) = XCONVEYOR_YOUTO_JPALLET Or _
                    TO_STRING(cboXCONVYOR_YOUTO.SelectedValue) = XCONVEYOR_YOUTO_JBARA Then
                    '(ﾊﾟﾚｯﾄ、ﾊﾞﾗの場合)

                    '********************************************************************
                    ' 出荷ｺﾝﾍﾞﾔ状況取得
                    '********************************************************************
                    Dim objXSTS_CONVEYOR1 As New TBL_XSTS_CONVEYOR(gobjOwner, gobjDb, Nothing)

                    objXSTS_CONVEYOR1.XSTNO = TO_STRING(cboFTRK_BUF_NO.SelectedValue)            'STNo.
                    intRet = objXSTS_CONVEYOR1.GET_XSTS_CONVEYOR()                               '情報取得
                    If intRet = RetCode.OK Then
                        Dim intXBERTH_GROUP As Integer                                           'ﾊﾞｰｽｸﾞﾙｰﾌﾟ
                        intXBERTH_GROUP = TO_INTEGER(objXSTS_CONVEYOR1.XBERTH_GROUP)

                        If intXBERTH_GROUP <> 0 Then
                            '(0以外の場合)
                            Dim objXSTS_CONVEYOR2 As New TBL_XSTS_CONVEYOR(gobjOwner, gobjDb, Nothing)
                            objXSTS_CONVEYOR2.XBERTH_GROUP = intXBERTH_GROUP                     'ﾊﾞｰｽｸﾞﾙｰﾌﾟ
                            intRet = objXSTS_CONVEYOR2.GET_XSTS_CONVEYOR_ANY()                   '情報取得
                            If intRet = RetCode.OK Then
                                For Each objXSTS_CONVEYOR_DATA As TBL_XSTS_CONVEYOR In objXSTS_CONVEYOR2.ARYME
                                    Dim strXCONVEYOR_YOUTO As String                                            'ｺﾝﾍﾞﾔ用途
                                    strXCONVEYOR_YOUTO = TO_STRING(objXSTS_CONVEYOR_DATA.XCONVEYOR_YOUTO)

                                    If objXSTS_CONVEYOR_DATA.XSTNO = TO_STRING(cboFTRK_BUF_NO.SelectedValue) Then
                                        '(変更対象の場合)
                                        '無視
                                    ElseIf strXCONVEYOR_YOUTO = "0" Then
                                        '(0の場合)

                                    ElseIf strXCONVEYOR_YOUTO <> TO_STRING(cboXCONVYOR_YOUTO.SelectedValue) Then
                                        '(一致しない場合)
                                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303020_13, _
                                                            PopupFormType.Ok, _
                                                            PopupIconType.Information)
                                        blnCheckErr = True
                                        Exit Select
                                    End If

                                Next

                            End If
                        End If
                    End If
                End If

                blnCheckErr = False

            Case menmCheckCase.SearchBtn_Click
                '(検索ﾎﾞﾀﾝｸﾘｯｸ時)

                blnCheckErr = False

            Case menmCheckCase.SelectAll_Click
                '(全選択ﾎﾞﾀﾝｸﾘｯｸ時)

                blnCheckErr = False

            Case menmCheckCase.NotSelectAll_Click
                '(全解除ﾎﾞﾀﾝｸﾘｯｸ時)

                blnCheckErr = False
            Case menmCheckCase.OutReg_Click
                '(出庫登録ﾎﾞﾀﾝｸﾘｯｸ時)

                '==========================
                'ﾘｽﾄ選択ﾁｪｯｸ
                '==========================
                If grdList.SelectedRows.Count <= 0 Then
                    '(ﾘｽﾄが選択されていない場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_GRD_LIST, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select

                End If

                '==========================
                '出庫STﾁｪｯｸ
                '==========================
                If TO_STRING(mudtGRID_LIST_ITEM(0).FTRK_BUF_NO) = FTRK_BUF_NO_J9000 Then
                    '(自動倉庫の場合)

                    If cboFTRK_BUF_NO.Text = "" Then
                        '(選択なしの場合)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FTRK_BUF_NO_SYUKKO, _
                                        PopupFormType.Ok, _
                                        PopupIconType.Information)
                        Exit Select

                    End If
                End If

                '==========================
                'ｺﾝﾍﾞﾔ用途ﾁｪｯｸ
                '==========================
                If mblnCV_YOUTO = True Then
                    '(Bｺﾝﾍﾞﾔの場合)
                    If lblSTMode.Text <> "設定出庫" Then
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_CONVEYOR_YOUTO, _
                                                        PopupFormType.Ok, _
                                                        PopupIconType.Information)
                        Exit Select
                    End If
                End If

                '==========================
                '包材出庫設定ﾁｪｯｸ
                '==========================
                If gobjComFuncFRM.Check_XSTS_WRAPPING_MATERIAL(TO_STRING(cboFTRK_BUF_NO.SelectedValue)) = True Then
                    '(設定済みの場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_XSTS_WRAPPING_MATERIAL, _
                                                    PopupFormType.Ok, _
                                                    PopupIconType.Information)
                    Exit Select
                End If


                '==========================
                '在庫ｴﾘｱ混在ﾁｪｯｸ
                '==========================
                If Check_FTRK_BUF_NO_ZAIKO() = False Then
                    '(選択なしの場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303020_12, _
                                    PopupFormType.Ok, _
                                    PopupIconType.Information)
                    Exit Select
                End If

                '==========================
                'ｸﾚｰﾝ状態ﾁｪｯｸ
                '==========================
                If TO_STRING(mudtGRID_LIST_ITEM(0).FTRK_BUF_NO) = FTRK_BUF_NO_J9000 Then
                    '(自動倉庫が対象)
                    For ii As Integer = 0 To grdList.SelectedRows.Count - 1
                        '(ﾙｰﾌﾟ:選択された行数)
                        '↓↓↓↓↓↓************************************************************************************************************
                        'SystemMate:A.Noto 2012/05/23  出庫ﾄﾗｯｷﾝｸﾞの禁止設定ﾁｪｯｸ(標準化※削除しないこと)
                        Dim strFPALLET_ID As String = TO_STRING(grdList.Item(menmListCol.FPALLET_ID, grdList.SelectedRows(ii).Index).Value)
                        '↓↓↓↓↓　2012/10/22 H.Morita 下記、在庫引当ｸﾗｽ(SVR_100202)を使用するので、無効とした。
                        'If gobjComFuncFRM.CheckOutTrkBufNo(strFPALLET_ID) = False Then
                        '    blnCheckErr = True
                        '    Exit Select
                        'End If
                        '↑↑↑↑↑  2012/10/22 H.Morita 下記、在庫引当ｸﾗｽ(SVR_100202)を使用するので、無効とした。
                        '↑↑↑↑↑↑************************************************************************************************************

                        '**********************************
                        '在庫引当
                        '**********************************
                        Dim decReqNum As Decimal = 0
                        Dim objSVR_100202 As New SVR_100202(Owner, gobjDb, Nothing)     '在庫引当ｸﾗｽ
                        objSVR_100202.FTRK_BUF_NO = FTRK_BUF_NO_J9000                   'ﾊﾞｯﾌｧ№(自動倉庫)
                        objSVR_100202.INTMaxPlt = KOTEI_MAX_PLT                         '最大引当ﾊﾟﾚｯﾄ数
                        objSVR_100202.INTUpdateMode = SVR_100202.UpdateMode.NON_UPDATE  '更新ﾓｰﾄﾞ(更新なし)
                        objSVR_100202.FPALLET_ID = strFPALLET_ID                        'ﾊﾟﾚｯﾄID
                        objSVR_100202.FBUF_TO = TO_STRING(cboFTRK_BUF_NO.SelectedValue) '搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                        intRet = objSVR_100202.FIND_STOCK(decReqNum)                    '在庫引当
                        If intRet <> RetCode.OK Then
                            '(在庫引当ができない時)
                            Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303020_07, PopupFormType.Ok, PopupIconType.Information)
                            blnCheckErr = True
                            Exit Select
                        End If

                    Next
                End If

                '*******************************************************
                '予定数確認
                '*******************************************************
                Dim objTBL_TMST_TRK As New TBL_TMST_TRK(gobjOwner, gobjDb, Nothing)
                objTBL_TMST_TRK.FTRK_BUF_NO = TO_INTEGER(cboFTRK_BUF_NO.SelectedValue)  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                objTBL_TMST_TRK.GET_TMST_TRK()                              '取得
                If IsNotNull(objTBL_TMST_TRK.XADRS_YOTEI01) Then
                    '(予定数ｱﾄﾞﾚｽ01が定義されている場合)

                    '************************************************
                    '設備状況           取得
                    '************************************************
                    'ﾄﾗｯｸﾛｰﾀﾞは含まないため、予定2はみない
                    Dim objTSTS_EQ_CTRL_YOTEI01 As New TBL_TSTS_EQ_CTRL(gobjOwner, gobjDb, Nothing)
                    ' ''Dim objTSTS_EQ_CTRL_YOTEI02 As New TBL_TSTS_EQ_CTRL(gobjOwner, gobjDb, Nothing)

                    objTSTS_EQ_CTRL_YOTEI01.FEQ_ID = objTBL_TMST_TRK.XADRS_YOTEI01  '設備ID
                    objTSTS_EQ_CTRL_YOTEI01.GET_TSTS_EQ_CTRL(True)                  '特定

                    ' ''If IsNotNull(objTMST_TRK.XADRS_YOTEI02) Then
                    ' ''    '(予定数ｱﾄﾞﾚｽ02が定義されている場合)
                    ' ''    objTSTS_EQ_CTRL_YOTEI02.FEQ_ID = objTBL_TMST_TRK.XADRS_YOTEI02  '設備ID
                    ' ''    objTSTS_EQ_CTRL_YOTEI02.GET_TSTS_EQ_CTRL(True)                  '特定
                    ' ''End If


                    '************************************************
                    '予定数、ﾊﾟﾚｯﾄ数ﾁｪｯｸ
                    '************************************************
                    If objTSTS_EQ_CTRL_YOTEI01.FEQ_STS <> 0 Then

                        strMsg = "出庫STの予定数が0ではありません。" & vbCrLf & _
                                 "出庫してもよろしいですか?" & vbCrLf & _
                                 "[設備ID:" & objTSTS_EQ_CTRL_YOTEI01.FEQ_ID & "]" & vbCrLf & _
                                 "[設備状態:" & objTSTS_EQ_CTRL_YOTEI01.FEQ_STS & "]"
                        If gobjComFuncFRM.DisplayPopup(strMsg, PopupFormType.Ok_Cancel, PopupIconType.Information) = RetPopup.Cancel Then
                            '(Cancel)
                            blnCheckErr = True
                        Exit Select
                    End If
                End If
                ' ''If IsNotNull(objTMST_TRK.XADRS_YOTEI02) Then
                ' ''    '(予定数ｱﾄﾞﾚｽ02が定義されている場合)
                ' ''    If objTSTS_EQ_CTRL_YOTEI02.FEQ_STS <> 0 Then Throw New Exception("予定数が0でない為、出庫は行えません。[設備ID:" & objTSTS_EQ_CTRL_YOTEI02.FEQ_ID & "][設備状態:" & objTSTS_EQ_CTRL_YOTEI02.FEQ_STS & "]")
                ' ''End If
                End If

                '*******************************************************
                '選択ﾃﾞｰﾀ整理
                '*******************************************************
                If TO_STRING(mudtGRID_LIST_ITEM(0).FTRK_BUF_NO) = FTRK_BUF_NO_J9000 Then
                    '(自動倉庫の場合)

                    Dim aryFront() As GRID_LIST_ITEM = Nothing
                    Dim aryBack() As GRID_LIST_ITEM = Nothing

                    MakeFrontBackArray(aryFront, aryBack)               '手前と奥でﾃﾞｰﾀ分割
                    MakeHANSOU_SET_DATA(aryFront, mudtFront_HANSOU_DATA)    '手前 搬送ﾃﾞｰﾀ作成
                    MakeHANSOU_SET_DATA(aryBack, mudtBack_HANSOU_DATA)      '奥 搬送ﾃﾞｰﾀ作成

                    '*******************************************************
                    '奥棚 手前状況確認
                    '*******************************************************
                    If Not mudtBack_HANSOU_DATA Is Nothing Then
                        '(奥棚ﾃﾞｰﾀがある場合)

                        '********************************************************************
                        ' 手前棚の在庫状況取得
                        '********************************************************************
                        Dim objDataSet As New DataSet                   'ﾃﾞｰﾀｾｯﾄ
                        Dim strSQL As String = ""

                        Dim ii As Long

                        For ii = 0 To UBound(mudtBack_HANSOU_DATA)
                            '(奥棚のﾃﾞｰﾀ分ﾙｰﾌﾟ)

                            Dim intFRES_KIND_1 As Integer           '引当状態 偶数
                            Dim intFRES_KIND_2 As Integer           '引当状態 奇数
                            Dim strFPALLET_ID_1 As String           'ﾊﾟﾚｯﾄID 偶数
                            Dim strFPALLET_ID_2 As String           'ﾊﾟﾚｯﾄID 奇数
                            Dim strFTR_TO_1 As String               '搬送TO 偶数
                            Dim strFTR_TO_2 As String               '搬送TO 奇数
                            Dim blnFPALLET_ID_1 As Boolean          'ﾊﾟﾚｯﾄID 有無 偶数
                            Dim blnFPALLET_ID_2 As Boolean          'ﾊﾟﾚｯﾄID 有無 奇数

                            '********************************************************************
                            ' 偶数か奇数か確認
                            '********************************************************************
                            Dim intREN_1 As Integer                 '連(1)
                            Dim intREN_2 As Integer                 '連(2)

                            If (mudtBack_HANSOU_DATA(ii).RAC_REN_1 Mod 2) = 0 Then
                                '(連が偶数)
                                intREN_1 = mudtBack_HANSOU_DATA(ii).RAC_REN_1
                                intREN_2 = mudtBack_HANSOU_DATA(ii).RAC_REN_1 - 1

                            Else
                                '(連が奇数)
                                intREN_1 = mudtBack_HANSOU_DATA(ii).RAC_REN_1 + 1
                                intREN_2 = mudtBack_HANSOU_DATA(ii).RAC_REN_1

                            End If

                            '********************************************************************
                            ' SQL文
                            '********************************************************************
                            strSQL = ""
                            '(Select句)
                            strSQL &= vbCrLf & " SELECT "
                            strSQL &= vbCrLf & "     TPRG_TRK_BUF.FRES_KIND "                           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ       .引当状態
                            strSQL &= vbCrLf & "   , TPRG_TRK_BUF.FPALLET_ID "                          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ       .ﾊﾟﾚｯﾄID
                            strSQL &= vbCrLf & "   , TPRG_TRK_BUF.FTR_TO "                              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ       .搬送To
                            '(From句)
                            strSQL &= vbCrLf & " FROM   "
                            strSQL &= vbCrLf & "     TPRG_TRK_BUF "                                     '【ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ】
                            '(Where句)
                            strSQL &= vbCrLf & " WHERE  "
                            strSQL &= vbCrLf & "     TPRG_TRK_BUF.FRAC_RETU = " & mudtBack_HANSOU_DATA(ii).RAC_RETU & " "
                            strSQL &= vbCrLf & " AND TPRG_TRK_BUF.FRAC_REN IN (" & TO_STRING(intREN_1) & ", " & TO_STRING(intREN_2) & ") "
                            strSQL &= vbCrLf & " AND TPRG_TRK_BUF.FRAC_DAN = " & mudtBack_HANSOU_DATA(ii).RAC_DAN & " "
                            strSQL &= vbCrLf & " AND TPRG_TRK_BUF.FRAC_EDA = 0 "
                            '(Order句)
                            strSQL &= vbCrLf & " ORDER BY "
                            strSQL &= vbCrLf & " TPRG_TRK_BUF.FRAC_REN  "

                            '********************************************************************
                            ' 実行
                            '********************************************************************
                            gobjDb.SQL = strSQL

                            objDataSet.Clear()
                            gobjDb.GetDataSet("TRK_BUF", objDataSet)

                            If objDataSet.Tables("TRK_BUF").Rows.Count > 0 Then
                                '(取得できた場合)
                                intFRES_KIND_2 = objDataSet.Tables("TRK_BUF").Rows(0).Item("FRES_KIND")                 '引当状態 手前 奇数
                                strFPALLET_ID_2 = TO_STRING(objDataSet.Tables("TRK_BUF").Rows(0).Item("FPALLET_ID"))    'ﾊﾟﾚｯﾄID 手前 奇数
                                strFTR_TO_2 = TO_STRING(objDataSet.Tables("TRK_BUF").Rows(0).Item("FTR_TO"))            '搬送TO 手前 奇数

                                intFRES_KIND_1 = objDataSet.Tables("TRK_BUF").Rows(1).Item("FRES_KIND")                 '引当状態 手前 偶数
                                strFPALLET_ID_1 = TO_STRING(objDataSet.Tables("TRK_BUF").Rows(1).Item("FPALLET_ID"))    'ﾊﾟﾚｯﾄID 手前 偶数
                                strFTR_TO_1 = TO_STRING(objDataSet.Tables("TRK_BUF").Rows(1).Item("FTR_TO"))            '搬送TO 手前 偶数

                            Else
                                strMsg = "該当する引当状態がありませんでした。"
                                Call gobjComFuncFRM.DisplayPopup(strMsg, PopupFormType.Ok, PopupIconType.Information)
                                blnCheckErr = True
                                Exit Select
                            End If


                            '********************************************************************
                            ' 引当状態の確認
                            '********************************************************************
                            If intFRES_KIND_1 = 0 And intFRES_KIND_2 = 0 Then
                                '(両方とも空ﾄﾗｯｷﾝｸﾞの場合)
                                '無視

                            ElseIf intFRES_KIND_1 = 1 And intFRES_KIND_2 = 0 Then
                                '(偶数=実 奇数=空 ﾄﾗｯｷﾝｸﾞの場合)

                                If Not mudtFront_HANSOU_DATA Is Nothing Then
                                    '(手前棚が出庫対象か調べる)
                                    blnFPALLET_ID_1 = False
                                    blnFPALLET_ID_1 = SearchPALLET_ID(aryFront, strFPALLET_ID_1)
                                End If

                                If blnFPALLET_ID_1 = False Then
                                    strMsg = "手前棚に在庫があります。" & vbCrLf & _
                                             "付帯出庫してもよろしいですか？" & vbCrLf & _
                                                 "手前棚ﾛｹｰｼｮﾝ:" & mudtBack_HANSOU_DATA(ii).RAC_RETU.ToString("D2") & "-" & intREN_1.ToString("D2") & "-" & mudtBack_HANSOU_DATA(ii).RAC_DAN.ToString("D2") & "-0" & vbCrLf & _
                                                 "　奥棚ﾛｹｰｼｮﾝ:" & mudtBack_HANSOU_DATA(ii).RAC_RETU.ToString("D2") & "-" & intREN_1.ToString("D2") & "-" & mudtBack_HANSOU_DATA(ii).RAC_DAN.ToString("D2") & "-1"
                                    If gobjComFuncFRM.DisplayPopup(strMsg, PopupFormType.Ok_Cancel, PopupIconType.Information) = RetPopup.Cancel Then
                                        '(Cancel)
                                        blnCheckErr = True
                                        Exit Select
                                    End If
                                End If


                            ElseIf intFRES_KIND_1 = 0 And intFRES_KIND_2 = 1 Then
                                '(偶数=空 奇数=実 ﾄﾗｯｷﾝｸﾞの場合)

                                If Not mudtFront_HANSOU_DATA Is Nothing Then
                                    '(手前棚が出庫対象か調べる)
                                    blnFPALLET_ID_2 = False
                                    blnFPALLET_ID_2 = SearchPALLET_ID(aryFront, strFPALLET_ID_2)

                                End If

                                If blnFPALLET_ID_2 = False Then
                                    strMsg = "手前棚に在庫があります。" & vbCrLf & _
                                             "付帯出庫してもよろしいですか？" & vbCrLf & _
                                             "手前棚ﾛｹｰｼｮﾝ:" & mudtBack_HANSOU_DATA(ii).RAC_RETU.ToString("D2") & "-" & intREN_2.ToString("D2") & "-" & mudtBack_HANSOU_DATA(ii).RAC_DAN.ToString("D2") & "-0" & vbCrLf & _
                                             "　奥棚ﾛｹｰｼｮﾝ:" & mudtBack_HANSOU_DATA(ii).RAC_RETU.ToString("D2") & "-" & intREN_2.ToString("D2") & "-" & mudtBack_HANSOU_DATA(ii).RAC_DAN.ToString("D2") & "-1"
                                    If gobjComFuncFRM.DisplayPopup(strMsg, PopupFormType.Ok_Cancel, PopupIconType.Information) = RetPopup.Cancel Then
                                        '(Cancel)
                                        blnCheckErr = True
                                        Exit Select
                                    End If
                                End If


                            ElseIf intFRES_KIND_1 = 1 And intFRES_KIND_2 = 1 Then
                                '(両方とも実ﾄﾗｯｷﾝｸﾞの場合)

                                If Not mudtFront_HANSOU_DATA Is Nothing Then
                                    '(手前棚が出庫対象か調べる)
                                    blnFPALLET_ID_1 = False
                                    blnFPALLET_ID_2 = False

                                    blnFPALLET_ID_1 = SearchPALLET_ID(aryFront, strFPALLET_ID_1)
                                    blnFPALLET_ID_2 = SearchPALLET_ID(aryFront, strFPALLET_ID_2)


                                End If

                                If blnFPALLET_ID_1 = False Then
                                    strMsg = "手前棚に在庫があります。" & vbCrLf & _
                                             "付帯出庫してもよろしいですか？" & vbCrLf & _
                                            "手前棚ﾛｹｰｼｮﾝ:" & mudtBack_HANSOU_DATA(ii).RAC_RETU.ToString("D2") & "-" & intREN_1.ToString("D2") & "-" & mudtBack_HANSOU_DATA(ii).RAC_DAN.ToString("D2") & "-0" & vbCrLf & _
                                            "　奥棚ﾛｹｰｼｮﾝ:" & mudtBack_HANSOU_DATA(ii).RAC_RETU.ToString("D2") & "-" & intREN_1.ToString("D2") & "-" & mudtBack_HANSOU_DATA(ii).RAC_DAN.ToString("D2") & "-1"
                                    If gobjComFuncFRM.DisplayPopup(strMsg, PopupFormType.Ok_Cancel, PopupIconType.Information) = RetPopup.Cancel Then
                                        '(Cancel)
                                        blnCheckErr = True
                                        Exit Select
                                    End If
                                End If
                                If blnFPALLET_ID_2 = False Then
                                    strMsg = "手前棚に在庫があります。" & vbCrLf & _
                                             "付帯出庫してもよろしいですか？" & vbCrLf & _
                                             "手前棚ﾛｹｰｼｮﾝ:" & mudtBack_HANSOU_DATA(ii).RAC_RETU.ToString("D2") & "-" & intREN_2.ToString("D2") & "-" & mudtBack_HANSOU_DATA(ii).RAC_DAN.ToString("D2") & "-0" & vbCrLf & _
                                             "　奥棚ﾛｹｰｼｮﾝ:" & mudtBack_HANSOU_DATA(ii).RAC_RETU.ToString("D2") & "-" & intREN_2.ToString("D2") & "-" & mudtBack_HANSOU_DATA(ii).RAC_DAN.ToString("D2") & "-1"
                                    If gobjComFuncFRM.DisplayPopup(strMsg, PopupFormType.Ok_Cancel, PopupIconType.Information) = RetPopup.Cancel Then
                                        '(Cancel)
                                        blnCheckErr = True
                                        Exit Select
                                    End If
                                End If


                            Else
                                '(その他)

                                '**************************
                                ' 手前偶数 引当状態の確認
                                '**************************
                                If intFRES_KIND_1 = 0 Then
                                    '(偶数が空ﾄﾗｯｷﾝｸﾞの場合)
                                    '処理なし

                                ElseIf intFRES_KIND_1 = 1 Then
                                    '(偶数が実ﾄﾗｯｷﾝｸﾞの場合)
                                    If Not mudtFront_HANSOU_DATA Is Nothing Then
                                        '(手前棚が出庫対象か調べる)
                                        blnFPALLET_ID_1 = False
                                        blnFPALLET_ID_1 = SearchPALLET_ID(aryFront, strFPALLET_ID_1)
                                    End If

                                    If blnFPALLET_ID_1 = False Then
                                        strMsg = "手前棚に在庫があります。" & vbCrLf & _
                                                 "付帯出庫してもよろしいですか？" & vbCrLf & _
                                                     "手前棚ﾛｹｰｼｮﾝ:" & mudtBack_HANSOU_DATA(ii).RAC_RETU.ToString("D2") & "-" & intREN_1.ToString("D2") & "-" & mudtBack_HANSOU_DATA(ii).RAC_DAN.ToString("D2") & "-0" & vbCrLf & _
                                                     "　奥棚ﾛｹｰｼｮﾝ:" & mudtBack_HANSOU_DATA(ii).RAC_RETU.ToString("D2") & "-" & intREN_1.ToString("D2") & "-" & mudtBack_HANSOU_DATA(ii).RAC_DAN.ToString("D2") & "-1"
                                        If gobjComFuncFRM.DisplayPopup(strMsg, PopupFormType.Ok_Cancel, PopupIconType.Information) = RetPopup.Cancel Then
                                            '(Cancel)
                                            blnCheckErr = True
                                            Exit Select
                                        End If
                                    End If

                                ElseIf intFRES_KIND_1 = 2 Then
                                    '(偶数が搬入予約)
                                    strMsg = "手前棚が予約済みのため出庫できません。"
                                    Call gobjComFuncFRM.DisplayPopup(strMsg, PopupFormType.Ok, PopupIconType.Information)
                                    blnCheckErr = True
                                    Exit Select

                                ElseIf intFRES_KIND_1 = 3 Then
                                    '(偶数が搬出予約)

                                    '**************************
                                    ' 搬出先の確認
                                    '**************************
                                    If strFTR_TO_1 <> TO_STRING(cboFTRK_BUF_NO.SelectedValue) Then
                                        '(搬出予約先と出庫STが一致しない場合)

                                        strMsg = "手前棚に搬送予定の在庫があります。" & vbCrLf & _
                                                 "出庫が遅れる可能性がありますが、" & vbCrLf & _
                                                 "よろしいですか？" & vbCrLf & _
                                                 "手前棚ﾛｹｰｼｮﾝ:" & mudtBack_HANSOU_DATA(ii).RAC_RETU.ToString("D2") & "-" & intREN_1.ToString("D2") & "-" & mudtBack_HANSOU_DATA(ii).RAC_DAN.ToString("D2") & "-0"
                                        If gobjComFuncFRM.DisplayPopup(strMsg, PopupFormType.Ok_Cancel, PopupIconType.Information) = RetPopup.Cancel Then
                                            blnCheckErr = True
                                            Exit Select
                                        End If
                                    End If

                                Else
                                    '(偶数がその他)
                                    strMsg = "手前棚が予約済みのため出庫できません。"
                                    Call gobjComFuncFRM.DisplayPopup(strMsg, PopupFormType.Ok, PopupIconType.Information)
                                    blnCheckErr = True
                                    Exit Select

                                End If

                                '**************************
                                ' 手前奇数 引当状態の確認
                                '**************************
                                If intFRES_KIND_2 = 0 Then
                                    '(奇数が空ﾄﾗｯｷﾝｸﾞ)
                                    '処理なし

                                ElseIf intFRES_KIND_2 = 1 Then
                                    '(奇数が実ﾄﾗｯｷﾝｸﾞ)
                                    If Not mudtFront_HANSOU_DATA Is Nothing Then
                                        '(手前棚が出庫対象か調べる)
                                        blnFPALLET_ID_2 = False
                                        blnFPALLET_ID_2 = SearchPALLET_ID(aryFront, strFPALLET_ID_2)
                                    End If

                                    If blnFPALLET_ID_2 = False Then
                                        strMsg = "手前棚に在庫があります。" & vbCrLf & _
                                                 "付帯出庫してもよろしいですか？" & vbCrLf & _
                                                 "手前棚ﾛｹｰｼｮﾝ:" & mudtBack_HANSOU_DATA(ii).RAC_RETU.ToString("D2") & "-" & intREN_2.ToString("D2") & "-" & mudtBack_HANSOU_DATA(ii).RAC_DAN.ToString("D2") & "-0" & vbCrLf & _
                                                 "　奥棚ﾛｹｰｼｮﾝ:" & mudtBack_HANSOU_DATA(ii).RAC_RETU.ToString("D2") & "-" & intREN_2.ToString("D2") & "-" & mudtBack_HANSOU_DATA(ii).RAC_DAN.ToString("D2") & "-1"
                                        If gobjComFuncFRM.DisplayPopup(strMsg, PopupFormType.Ok_Cancel, PopupIconType.Information) = RetPopup.Cancel Then
                                            '(Cancel)
                                            blnCheckErr = True
                                            Exit Select
                                        End If
                                    End If

                                ElseIf intFRES_KIND_2 = 2 Then
                                    '(奇数が搬入予約)
                                    strMsg = "手前棚が予約済みのため出庫できません。"
                                    Call gobjComFuncFRM.DisplayPopup(strMsg, PopupFormType.Ok, PopupIconType.Information)
                                    blnCheckErr = True
                                    Exit Select

                                ElseIf intFRES_KIND_2 = 3 Then
                                    '(奇数が搬出予約)

                                    '**************************
                                    ' 搬出先の確認
                                    '**************************
                                    If strFTR_TO_2 <> TO_STRING(cboFTRK_BUF_NO.SelectedValue) Then
                                        '(搬出予約先と出庫STが一致しない場合)
                                        strMsg = "手前棚に搬送予定の在庫があります。" & vbCrLf & _
                                                 "出庫が遅れる可能性がありますが、" & vbCrLf & _
                                                 "よろしいですか？" & vbCrLf & _
                                                 "手前棚ﾛｹｰｼｮﾝ:" & mudtBack_HANSOU_DATA(ii).RAC_RETU.ToString("D2") & "-" & intREN_2.ToString("D2") & "-" & mudtBack_HANSOU_DATA(ii).RAC_DAN.ToString("D2") & "-0"
                                        If gobjComFuncFRM.DisplayPopup(strMsg, PopupFormType.Ok_Cancel, PopupIconType.Information) = RetPopup.Cancel Then
                                            blnCheckErr = True
                                            Exit Select
                                        End If
                                    End If

                                Else
                                    '(奇数がその他)
                                    strMsg = "手前棚が予約済みのため出庫できません。"
                                    Call gobjComFuncFRM.DisplayPopup(strMsg, PopupFormType.Ok, PopupIconType.Information)
                                    blnCheckErr = True
                                    Exit Select

                                End If

                            End If

                        Next

                    End If


                Else
                    '(それ以外)

                    Call MakePLArray()


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

#Region "　ｸﾞﾘｯﾄﾞ表示(通常検索)                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub grdListDisplayChild()

        Dim strSQL As String = ""                       'SQL文

        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "       TPRG_TRK_BUF.FTRK_BUF_NO "                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
        strSQL &= vbCrLf & "     , TMST_TRK.FBUF_NAME "                          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称
        strSQL &= vbCrLf & "     , TMST_ITEM.XHINMEI_CD "                        '品目ﾏｽﾀ        .品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "     , TRST_STOCK.FHINMEI_CD "                       '在庫情報       .品名記号
        strSQL &= vbCrLf & "     , TMST_ITEM.FHINMEI "                           '品目ﾏｽﾀ        .品名
        strSQL &= vbCrLf & "     , TRST_STOCK.XPROD_LINE "                       '在庫情報       .生産ﾗｲﾝNo.
        strSQL &= vbCrLf & "     , XMST_PROD_LINE.XPROD_LINE_NAME "              '生産ﾗｲﾝﾏｽﾀ     .生産ﾗｲﾝNo.名称
        strSQL &= vbCrLf & "     , TRST_STOCK.FTR_VOL "                          '在庫情報       .数量(搬送管理量)
        strSQL &= vbCrLf & "     , TPRG_TRK_BUF.FDISP_ADDRESS "                  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .表記用ｱﾄﾞﾚｽ(ﾛｹｰｼｮﾝ)
        strSQL &= vbCrLf & "     , TRST_STOCK.FARRIVE_DT "                       '在庫情報       .在庫発生日時
        strSQL &= vbCrLf & "     , TRST_STOCK.XKENSA_KUBUN "                     '在庫情報       .検査区分
        strSQL &= vbCrLf & "     , HASH01.FGAMEN_DISP AS XKENSA_KUBUN_DSP "      '在庫情報       .検査区分(表示用)
        strSQL &= vbCrLf & "     , TRST_STOCK.FHORYU_KUBUN "                     '在庫情報       .保留区分
        strSQL &= vbCrLf & "     , HASH02.FGAMEN_DISP AS FHORYU_KUBUN_DSP "      '在庫情報       .保留区分(表示用)
        strSQL &= vbCrLf & "     , TRST_STOCK.XKENPIN_KUBUN "                    '在庫情報       .検品区分
        strSQL &= vbCrLf & "     , HASH03.FGAMEN_DISP AS XKENPIN_KUBUN_DSP "     '在庫情報       .検品区分(表示用)
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/06/05 商品区分追加
        strSQL &= vbCrLf & "     , TMST_ITEM.XARTICLE_TYPE_CODE "                    '在庫情報       .商品区分
        strSQL &= vbCrLf & "     , HASH04.FGAMEN_DISP AS XARTICLE_TYPE_CODE_DSP "     '在庫情報       .商品区分(表示用)
        '↑↑↑↑↑↑************************************************************************************************************
        strSQL &= vbCrLf & "     , TRST_STOCK.FLOT_NO "                          '在庫情報       .ﾛｯﾄNo.
        strSQL &= vbCrLf & "     , TRST_STOCK.FPALLET_ID "                       '在庫情報       .ﾊﾟﾚｯﾄID
        strSQL &= vbCrLf & "     , TPRG_TRK_BUF.XTANA_BLOCK "                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .棚ﾌﾞﾛｯｸ
        strSQL &= vbCrLf & "     , TPRG_TRK_BUF.XTANA_BLOCK_DTL "                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .棚ﾌﾞﾛｯｸ詳細
        strSQL &= vbCrLf & "     , TPRG_TRK_BUF.FRAC_RETU "                      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .列
        strSQL &= vbCrLf & "     , TPRG_TRK_BUF.FRAC_REN "                       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .連
        strSQL &= vbCrLf & "     , TPRG_TRK_BUF.FRAC_DAN "                       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .段
        strSQL &= vbCrLf & "     , TPRG_TRK_BUF.FRAC_EDA "                       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .枝

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    TPRG_TRK_BUF "                  '【ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ】
        strSQL &= vbCrLf & "  , TMST_TRK "                      '【ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ】
        strSQL &= vbCrLf & "  , TRST_STOCK "                    '【在庫情報】
        strSQL &= vbCrLf & "  , TMST_ITEM "                     '【品目ﾏｽﾀ】
        strSQL &= vbCrLf & "  , XMST_PROD_LINE "                '【生産ﾗｲﾝﾏｽﾀ】
        strSQL &= vbCrLf & "     , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH01", "TRST_STOCK", "XKENSA_KUBUN")     '【検査区分(表示用)】
        strSQL &= vbCrLf & "     , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH02", "TRST_STOCK", "FHORYU_KUBUN")     '【保留区分(表示用)】
        strSQL &= vbCrLf & "     , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH03", "TRST_STOCK", "XKENPIN_KUBUN")    '【検品区分(表示用)】
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/06/05 商品区分追加
        strSQL &= vbCrLf & "     , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH04", "TMST_ITEM", "XARTICLE_TYPE_CODE")    '【商品区分(表示用)】
        '↑↑↑↑↑↑************************************************************************************************************

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        1 = 1"         '必ず通る条件
        strSQL &= vbCrLf & "    AND TRST_STOCK.FPALLET_ID = TPRG_TRK_BUF.FPALLET_ID(+) "
        strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FTRK_BUF_NO = TMST_TRK.FTRK_BUF_NO(+) "
        strSQL &= vbCrLf & "    AND TRST_STOCK.FHINMEI_CD = TMST_ITEM.FHINMEI_CD(+) "
        strSQL &= vbCrLf & "    AND TRST_STOCK.XPROD_LINE = XMST_PROD_LINE.XPROD_LINE(+) "
        'strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FPALLET_ID NOT IN( "                             '在庫棚(未引当)
        'strSQL &= vbCrLf & "                (SELECT FPALLET_ID FROM XSTS_HIKIATE_K1) "
        'strSQL &= vbCrLf & "                                    ) "
        strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FPALLET_ID NOT IN( "                             '在庫棚(未引当)
        strSQL &= vbCrLf & "                (SELECT FPALLET_ID FROM TSTS_HIKIATE) "
        strSQL &= vbCrLf & "                                    ) "
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH01", "TRST_STOCK", "XKENSA_KUBUN")
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH02", "TRST_STOCK", "FHORYU_KUBUN")
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH03", "TRST_STOCK", "XKENPIN_KUBUN")
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/06/05 商品区分追加
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH04", "TMST_ITEM", "XARTICLE_TYPE_CODE")
        '↑↑↑↑↑↑************************************************************************************************************

        '----------------------------
        '在庫ｴﾘｱﾁｪｯｸ
        '----------------------------
        If mudtSEARCH_ITEM.FTRK_BUF_NO <> "" Then
            strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FTRK_BUF_NO = " & mudtSEARCH_ITEM.FTRK_BUF_NO & " "
        End If

        '----------------------------
        '品名ｺｰﾄﾞ
        '----------------------------
        If mudtSEARCH_ITEM.FHINMEI_CD <> "" Then
            If IsNumeric(mudtSEARCH_ITEM.FHINMEI_CD.Substring(0, 1)) Then
                '(品名ｺｰﾄﾞ)
                strSQL &= vbCrLf & "    AND TMST_ITEM.XHINMEI_CD = '" & mudtSEARCH_ITEM.FHINMEI_CD & "' "
            Else
                '(品名記号)
                strSQL &= vbCrLf & "    AND TRST_STOCK.FHINMEI_CD = '" & mudtSEARCH_ITEM.FHINMEI_CD & "' "
            End If

        End If

        '----------------------------
        '入庫日
        '----------------------------
        If mudtSEARCH_ITEM.FARRIVE_DT_FROM <> "" Then
            strSQL &= vbCrLf & "    AND TRST_STOCK.FARRIVE_DT >= TO_DATE('" & mudtSEARCH_ITEM.FARRIVE_DT_FROM & "','YYYY/MM/DD HH24:MI:SS')"
        End If
        If mudtSEARCH_ITEM.FARRIVE_DT_TO <> "" Then
            strSQL &= vbCrLf & "    AND TRST_STOCK.FARRIVE_DT <= TO_DATE('" & mudtSEARCH_ITEM.FARRIVE_DT_TO & "','YYYY/MM/DD HH24:MI:SS')"
        End If

        '----------------------------
        '生産ﾗｲﾝNo.
        '----------------------------
        If mudtSEARCH_ITEM.XPROD_LINE <> "" Then
            strSQL &= vbCrLf & "    AND TRST_STOCK.XPROD_LINE = '" & mudtSEARCH_ITEM.XPROD_LINE & "' "
        End If

        '----------------------------
        '検査区分
        '----------------------------
        If mudtSEARCH_ITEM.XKENSA_KUBUN <> "" Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "    AND TRST_STOCK.XKENSA_KUBUN = " & mudtSEARCH_ITEM.XKENSA_KUBUN
        End If

        '----------------------------
        '保留区分
        '----------------------------
        If mudtSEARCH_ITEM.FHORYU_KUBUN <> "" Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "    AND TRST_STOCK.FHORYU_KUBUN = " & mudtSEARCH_ITEM.FHORYU_KUBUN
        End If

        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/06/05 商品区分追加
        '----------------------------
        '商品区分
        '----------------------------
        If mudtSEARCH_ITEM.XARTICLE_TYPE_CODE <> "" Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "    AND TMST_ITEM.XARTICLE_TYPE_CODE = " & mudtSEARCH_ITEM.XARTICLE_TYPE_CODE
        End If
        '↑↑↑↑↑↑************************************************************************************************************

        '----------------------------
        '数量
        '----------------------------
        If mudtSEARCH_ITEM.FTR_VOL <> "" Then
            '(指定の場合)
            strSQL &= vbCrLf & "    AND ROWNUM <= " & mudtSEARCH_ITEM.FTR_VOL
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



    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ表示(数量指定)　                   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示(数量指定)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListDisplay_PL_VOL()

        Dim strSQL As String = ""                       'SQL文

        '********************************************************************
        ' 問合せ
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "       TOIAWASE.FTRK_BUF_NO "                       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
        strSQL &= vbCrLf & "     , TOIAWASE.FBUF_NAME "                         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称
        strSQL &= vbCrLf & "     , TOIAWASE.XHINMEI_CD "                        '品目ﾏｽﾀ        .品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "     , TOIAWASE.FHINMEI_CD "                        '在庫情報       .品名記号
        strSQL &= vbCrLf & "     , TOIAWASE.FHINMEI "                           '品目ﾏｽﾀ        .品名
        strSQL &= vbCrLf & "     , TOIAWASE.XPROD_LINE "                        '在庫情報       .生産ﾗｲﾝNo.
        strSQL &= vbCrLf & "     , TOIAWASE.XPROD_LINE_NAME "                   '生産ﾗｲﾝﾏｽﾀ     .生産ﾗｲﾝNo.名称
        strSQL &= vbCrLf & "     , TOIAWASE.FTR_VOL "                           '在庫情報       .数量(搬送管理量)
        strSQL &= vbCrLf & "     , TOIAWASE.FDISP_ADDRESS "                     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .表記用ｱﾄﾞﾚｽ(ﾛｹｰｼｮﾝ)
        strSQL &= vbCrLf & "     , TOIAWASE.FARRIVE_DT "                        '在庫情報       .在庫発生日時
        strSQL &= vbCrLf & "     , TOIAWASE.XKENSA_KUBUN "                      '在庫情報       .検査区分
        strSQL &= vbCrLf & "     , TOIAWASE.XKENSA_KUBUN_DSP "                  '在庫情報       .検査区分(表示用)
        strSQL &= vbCrLf & "     , TOIAWASE.FHORYU_KUBUN "                      '在庫情報       .保留区分
        strSQL &= vbCrLf & "     , TOIAWASE.FHORYU_KUBUN_DSP "                  '在庫情報       .保留区分(表示用)
        strSQL &= vbCrLf & "     , TOIAWASE.XKENPIN_KUBUN "                     '在庫情報       .検品区分
        strSQL &= vbCrLf & "     , TOIAWASE.XKENPIN_KUBUN_DSP "                 '在庫情報       .検品区分(表示用)
        strSQL &= vbCrLf & "     , TOIAWASE.XARTICLE_TYPE_CODE "                '在庫情報       .商品区分
        strSQL &= vbCrLf & "     , TOIAWASE.XARTICLE_TYPE_CODE_DSP "                 '在庫情報       .商品区分(表示用)
        strSQL &= vbCrLf & "     , TOIAWASE.FLOT_NO "                           '在庫情報       .ﾛｯﾄNo.
        strSQL &= vbCrLf & "     , TOIAWASE.FPALLET_ID "                        '在庫情報       .ﾊﾟﾚｯﾄID
        strSQL &= vbCrLf & "     , TOIAWASE.XTANA_BLOCK "                       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .棚ﾌﾞﾛｯｸ
        strSQL &= vbCrLf & "     , TOIAWASE.XTANA_BLOCK_DTL "                   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .棚ﾌﾞﾛｯｸ詳細
        strSQL &= vbCrLf & "     , TOIAWASE.FRAC_RETU "                         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .列
        strSQL &= vbCrLf & "     , TOIAWASE.FRAC_REN "                          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .連
        strSQL &= vbCrLf & "     , TOIAWASE.FRAC_DAN "                          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .段
        strSQL &= vbCrLf & "     , TOIAWASE.FRAC_EDA "                          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .枝

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "

        '********************************************************************
        ' 副問合せ
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL &= " ( "
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "       TPRG_TRK_BUF.FTRK_BUF_NO "                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
        strSQL &= vbCrLf & "     , TMST_TRK.FBUF_NAME "                          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称
        strSQL &= vbCrLf & "     , TMST_ITEM.XHINMEI_CD "                        '品目ﾏｽﾀ        .品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "     , TRST_STOCK.FHINMEI_CD "                       '在庫情報       .品名記号
        strSQL &= vbCrLf & "     , TMST_ITEM.FHINMEI "                           '品目ﾏｽﾀ        .品名
        strSQL &= vbCrLf & "     , TRST_STOCK.FLOT_NO "                          '在庫情報       .ﾛｯﾄNo.
        strSQL &= vbCrLf & "     , TRST_STOCK.XPROD_LINE "                       '在庫情報       .生産ﾗｲﾝNo.
        strSQL &= vbCrLf & "     , XMST_PROD_LINE.XPROD_LINE_NAME "              '生産ﾗｲﾝﾏｽﾀ     .生産ﾗｲﾝNo.名称
        strSQL &= vbCrLf & "     , TRST_STOCK.FARRIVE_DT "                       '在庫情報       .在庫発生日時
        strSQL &= vbCrLf & "     , TRST_STOCK.XKENSA_KUBUN "                     '在庫情報       .検査区分
        strSQL &= vbCrLf & "     , HASH01.FGAMEN_DISP AS XKENSA_KUBUN_DSP "      '在庫情報       .検査区分(表示用)
        strSQL &= vbCrLf & "     , TRST_STOCK.FHORYU_KUBUN "                     '在庫情報       .保留区分
        strSQL &= vbCrLf & "     , HASH02.FGAMEN_DISP AS FHORYU_KUBUN_DSP "      '在庫情報       .保留区分(表示用)
        strSQL &= vbCrLf & "     , TRST_STOCK.XKENPIN_KUBUN "                    '在庫情報       .検品区分
        strSQL &= vbCrLf & "     , HASH03.FGAMEN_DISP AS XKENPIN_KUBUN_DSP "     '在庫情報       .検品区分(表示用)
        strSQL &= vbCrLf & "     , TMST_ITEM.XARTICLE_TYPE_CODE "                '在庫情報       .商品区分
        strSQL &= vbCrLf & "     , HASH04.FGAMEN_DISP AS XARTICLE_TYPE_CODE_DSP "     '在庫情報       .商品区分(表示用)
        strSQL &= vbCrLf & "     , TRST_STOCK.FTR_VOL "                          '在庫情報       .数量(搬送管理量)
        strSQL &= vbCrLf & "     , TPRG_TRK_BUF.FDISP_ADDRESS "                  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .表記用ｱﾄﾞﾚｽ(ﾛｹｰｼｮﾝ)
        strSQL &= vbCrLf & "     , TRST_STOCK.FPALLET_ID "                       '在庫情報       .ﾊﾟﾚｯﾄID
        strSQL &= vbCrLf & "     , TPRG_TRK_BUF.XTANA_BLOCK "                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .棚ﾌﾞﾛｯｸ
        strSQL &= vbCrLf & "     , TPRG_TRK_BUF.XTANA_BLOCK_DTL "                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .棚ﾌﾞﾛｯｸ詳細
        strSQL &= vbCrLf & "     , TPRG_TRK_BUF.FRAC_RETU "                      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .列
        strSQL &= vbCrLf & "     , TPRG_TRK_BUF.FRAC_REN "                       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .連
        strSQL &= vbCrLf & "     , TPRG_TRK_BUF.FRAC_DAN "                       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .段
        strSQL &= vbCrLf & "     , TPRG_TRK_BUF.FRAC_EDA "                       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .枝

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    TPRG_TRK_BUF "                  '【ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ】
        strSQL &= vbCrLf & "  , TMST_TRK "                      '【ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ】
        strSQL &= vbCrLf & "  , TRST_STOCK "                    '【在庫情報】
        strSQL &= vbCrLf & "  , TMST_ITEM "                     '【品目ﾏｽﾀ】
        strSQL &= vbCrLf & "  , XMST_PROD_LINE "                '【生産ﾗｲﾝﾏｽﾀ】
        strSQL &= vbCrLf & "     , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH01", "TRST_STOCK", "XKENSA_KUBUN")     '【検査区分(表示用)】
        strSQL &= vbCrLf & "     , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH02", "TRST_STOCK", "FHORYU_KUBUN")     '【保留区分(表示用)】
        strSQL &= vbCrLf & "     , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH03", "TRST_STOCK", "XKENPIN_KUBUN")    '【検品区分(表示用)】
        strSQL &= vbCrLf & "     , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH04", "TMST_ITEM", "XARTICLE_TYPE_CODE")    '【商品区分(表示用)】

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        1 = 1"         '必ず通る条件
        strSQL &= vbCrLf & "    AND TRST_STOCK.FPALLET_ID = TPRG_TRK_BUF.FPALLET_ID(+) "
        strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FTRK_BUF_NO = TMST_TRK.FTRK_BUF_NO(+) "
        strSQL &= vbCrLf & "    AND TRST_STOCK.FHINMEI_CD = TMST_ITEM.FHINMEI_CD(+) "
        strSQL &= vbCrLf & "    AND TRST_STOCK.XPROD_LINE = XMST_PROD_LINE.XPROD_LINE(+) "
        strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FPALLET_ID NOT IN( "                             '在庫棚(未引当)
        strSQL &= vbCrLf & "                (SELECT FPALLET_ID FROM TSTS_HIKIATE) "
        strSQL &= vbCrLf & "                                    ) "
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH01", "TRST_STOCK", "XKENSA_KUBUN")
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH02", "TRST_STOCK", "FHORYU_KUBUN")
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH03", "TRST_STOCK", "XKENPIN_KUBUN")
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH04", "TMST_ITEM", "XARTICLE_TYPE_CODE")

        '----------------------------
        '在庫ｴﾘｱﾁｪｯｸ
        '----------------------------
        If mudtSEARCH_ITEM.FTRK_BUF_NO <> "" Then
            strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FTRK_BUF_NO = " & mudtSEARCH_ITEM.FTRK_BUF_NO & " "
        End If

        '----------------------------
        '品名ｺｰﾄﾞ
        '----------------------------
        If mudtSEARCH_ITEM.FHINMEI_CD <> "" Then
            If IsNumeric(mudtSEARCH_ITEM.FHINMEI_CD.Substring(0, 1)) Then
                '(品名ｺｰﾄﾞ)
                strSQL &= vbCrLf & "    AND TMST_ITEM.XHINMEI_CD = '" & mudtSEARCH_ITEM.FHINMEI_CD & "' "
            Else
                '(品名記号)
                strSQL &= vbCrLf & "    AND TRST_STOCK.FHINMEI_CD = '" & mudtSEARCH_ITEM.FHINMEI_CD & "' "
            End If

        End If

        '----------------------------
        '入庫日
        '----------------------------
        If mudtSEARCH_ITEM.FARRIVE_DT_FROM <> "" Then
            strSQL &= vbCrLf & "    AND TRST_STOCK.FARRIVE_DT >= TO_DATE('" & mudtSEARCH_ITEM.FARRIVE_DT_FROM & "','YYYY/MM/DD HH24:MI:SS')"
        End If
        If mudtSEARCH_ITEM.FARRIVE_DT_TO <> "" Then
            strSQL &= vbCrLf & "    AND TRST_STOCK.FARRIVE_DT <= TO_DATE('" & mudtSEARCH_ITEM.FARRIVE_DT_TO & "','YYYY/MM/DD HH24:MI:SS')"
        End If

        '----------------------------
        '生産ﾗｲﾝNo.
        '----------------------------
        If mudtSEARCH_ITEM.XPROD_LINE <> "" Then
            strSQL &= vbCrLf & "    AND TRST_STOCK.XPROD_LINE = '" & mudtSEARCH_ITEM.XPROD_LINE & "' "
        End If

        '----------------------------
        '検査区分
        '----------------------------
        If mudtSEARCH_ITEM.XKENSA_KUBUN <> "" Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "    AND TRST_STOCK.XKENSA_KUBUN = " & mudtSEARCH_ITEM.XKENSA_KUBUN
        End If

        '----------------------------
        '保留区分
        '----------------------------
        If mudtSEARCH_ITEM.FHORYU_KUBUN <> "" Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "    AND TRST_STOCK.FHORYU_KUBUN = " & mudtSEARCH_ITEM.FHORYU_KUBUN
        End If

        '----------------------------
        '商品区分
        '----------------------------
        If mudtSEARCH_ITEM.XARTICLE_TYPE_CODE <> "" Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "    AND TMST_ITEM.XARTICLE_TYPE_CODE = " & mudtSEARCH_ITEM.XARTICLE_TYPE_CODE
        End If

        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & gobjComFuncFRM.GetSQL_TDSP_GRID_OrderBy(Me, grdList)
        strSQL &= vbCrLf

        '============================================================
        '副問合せ 終了
        '============================================================
        strSQL &= " ) TOIAWASE "

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        1 = 1"         '必ず通る条件

        '----------------------------
        '数量
        '----------------------------
        If mudtSEARCH_ITEM.FTR_VOL <> "" Then
            '(指定の場合)
            strSQL &= vbCrLf & "    AND ROWNUM <= " & mudtSEARCH_ITEM.FTR_VOL
        End If




        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        Call gobjComFuncFRM.TblDataGridDisplay(grdList, strSQL, True)

        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdListSetup()
        Call gobjComFuncFRM.GridSelect(grdList, -1, -1, Nothing)       'ｸﾞﾘｯﾄﾞ選択処理

    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ表示設定　                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示設定
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListSetup()


        '************************************************
        'ｸﾞﾘｯﾄﾞﾏｽﾀの定義を反映
        '************************************************
        Call gobjComFuncFRM.TDSP_GRIDSetup(Me, grdList)

        'grdList.Columns(menmListCol.DENBUN).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill   '列幅自動調整


    End Sub
#End Region

#Region "  ｿｹｯﾄ送信01   出庫ﾓｰﾄﾞ切替                "
    '''*******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信01
    ''' </summary>
    ''' <returns>True:送信成功  False:送信失敗</returns>
    ''' <remarks></remarks>
    '''*******************************************************************************************************************
    Private Function SendSocket01() As Boolean
        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        Dim strMessage As String
        Dim strXCONVEYOR_NAME As String = ""

        ' ''If TO_INTEGER(txtList01.Text) <> -1 Then
        ' ''    strXCONVEYOR_NAME = TO_STRING(grdList01.Item(menmListCol.XCONBEYOR_NAME, TO_INTEGER(txtList01.Text)).Value)
        ' ''ElseIf TO_INTEGER(txtList02.Text) <> -1 Then
        ' ''    strXCONVEYOR_NAME = TO_STRING(grdList02.Item(menmListCol.XCONBEYOR_NAME, TO_INTEGER(txtList02.Text)).Value)
        ' ''End If
        strXCONVEYOR_NAME = cboFTRK_BUF_NO.Text
        strMessage = ""
        strMessage &= strXCONVEYOR_NAME & "を"
        strMessage &= TO_STRING(cboXCONVYOR_YOUTO.Text) & "としてよろしいですか？"
        udtRet = gobjComFuncFRM.DisplayPopup(strMessage, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Function
        End If

        '*******************************************************
        'ﾃﾞｰﾀ取得
        '*******************************************************
        Dim intRet As Integer
        Dim strXST_NO As String = ""                        'ST№
        Dim strXCONVEYOR_YOUTO As String = ""               'ｺﾝﾍﾞﾔ用途
        Dim strXBERTH_GROUP As String = ""                  'ﾊﾞｰｽｸﾞﾙｰﾌﾟ

        strXCONVEYOR_YOUTO = TO_STRING(cboXCONVYOR_YOUTO.SelectedValue)
        strXST_NO = TO_STRING(cboFTRK_BUF_NO.SelectedValue)

        If strXCONVEYOR_YOUTO = XCONVEYOR_YOUTO_JPALLET Or _
            strXCONVEYOR_YOUTO = XCONVEYOR_YOUTO_JBARA Then
            '(ﾊﾟﾚｯﾄ,ﾊﾞﾗの場合)

            '出荷ｺﾝﾍﾞﾔ状況取得
            Dim objXSTS_CONVEYOR1 As New TBL_XSTS_CONVEYOR(gobjOwner, gobjDb, Nothing)

            objXSTS_CONVEYOR1.XSTNO = TO_STRING(cboFTRK_BUF_NO.SelectedValue)           'STNo.
            intRet = objXSTS_CONVEYOR1.GET_XSTS_CONVEYOR()                              '情報取得
            If intRet = RetCode.OK Then
                strXBERTH_GROUP = TO_STRING(objXSTS_CONVEYOR1.XBERTH_GROUP)             'ﾊﾞｰｽｸﾞﾙｰﾌﾟ
            End If
        Else
            '(それ以外)
            strXBERTH_GROUP = "0"
        End If

        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        '========================================
        ' 変数宣言
        '========================================
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400202          'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        objTelegram.SETIN_DATA("XDSPSTNO", strXST_NO)                       'STNo    ｾｯﾄ
        objTelegram.SETIN_DATA("XDSPCONVEYOR_YOUTO", strXCONVEYOR_YOUTO)    'ｺﾝﾍﾞﾔ用途    ｾｯﾄ
        objTelegram.SETIN_DATA("XDSPBERTH_GROUP", strXBERTH_GROUP)          'ﾊﾞｰｽｸﾞﾙｰﾌﾟ    ｾｯﾄ

        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode   'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String = ""                 'ｴﾗｰﾒｯｾｰｼﾞ

        strErrMsg = "コンベヤの設定に失敗しました。"
        udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            '(送信できた場合)
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)
                blnCheckErr = False
            End If
        End If

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
#Region "  ｿｹｯﾄ送信02   問合せ出庫処理(自動倉庫)    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信02   問合せ出庫処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function InquiryOut() As Boolean
        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        udtRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303020_09, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Function
        End If

        '********************************************************************
        ' 出庫在庫ﾃﾞｰﾀｾｯﾄ
        '********************************************************************
        'Dim udtOUT_STOCK() As STOCK_DATA = Nothing      '出庫在庫ﾃﾞｰﾀ用構造体
        Dim strSndTlgrm() As String = Nothing           '送信電文文字列
        Dim intHairetu As Integer = 0                   '配列数
        'Dim intRet As RetCode
        Dim strMsg As String = ""
        Dim strXADRS_YOTEI = ""                         '予定数ｱﾄﾞﾚｽ
        Dim strOUTST_NO As String = ""                  'ｽﾃｰｼｮﾝID
        Dim blnPareFlag As Boolean = False              'ﾍﾟｱ出庫ﾌﾗｸﾞ

        '********************************************************************
        ' 出庫数予約用 電文作成
        '********************************************************************
        strOUTST_NO = TO_STRING(cboFTRK_BUF_NO.SelectedValue)                   '出庫先ST

        '予定設備IDの取得
        Dim intRet As RetCode
        Dim objTBL_TMST_TRK As TBL_TMST_TRK                                     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ
        objTBL_TMST_TRK = New TBL_TMST_TRK(gobjOwner, gobjDb, Nothing)

        objTBL_TMST_TRK.FTRK_BUF_NO = TO_STRING(cboFTRK_BUF_NO.SelectedValue)   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.

        intRet = objTBL_TMST_TRK.GET_TMST_TRK(False)
        If intRet = RetCode.OK Then
            '(値がある時)
            If Not objTBL_TMST_TRK.XADRS_YOTEI01 Is Nothing Then
                strXADRS_YOTEI = objTBL_TMST_TRK.XADRS_YOTEI01                  '予定数ｱﾄﾞﾚｽ
            Else
                strXADRS_YOTEI = ""
                'Throw New System.Exception(FRM_MSG_FRM303020_10)
            End If

        Else
            '(読めなかった時)
            strXADRS_YOTEI = ""
            'Throw New System.Exception(FRM_MSG_FRM303020_10)
        End If

        '予定数の計算
        Dim intYOTEI_NUM = 0        '予定数
        Dim i As Integer = 0
        If Not mudtFront_HANSOU_DATA Is Nothing Then
            For i = 0 To UBound(mudtFront_HANSOU_DATA)
                '(手前ﾊﾟﾚｯﾄ数)
                If mudtFront_HANSOU_DATA(i).PARE_FLAG = True Then
                    '(ﾍﾟｱ出庫の場合)
                    intYOTEI_NUM = intYOTEI_NUM + 2
                Else
                    '(ｼﾝｸﾞﾙ出庫の場合)
                    intYOTEI_NUM = intYOTEI_NUM + 1
                End If
            Next
        End If

        If Not mudtBack_HANSOU_DATA Is Nothing Then
            For i = 0 To UBound(mudtBack_HANSOU_DATA)
                '(奥ﾊﾟﾚｯﾄ数)
                If mudtBack_HANSOU_DATA(i).PARE_FLAG = True Then
                    '(ﾍﾟｱ出庫の場合)
                    intYOTEI_NUM = intYOTEI_NUM + 2
                Else
                    '(ｼﾝｸﾞﾙ出庫の場合)
                    intYOTEI_NUM = intYOTEI_NUM + 1
                End If
            Next
        End If

        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S201601

        objTelegram.SETIN_HEADER("DSPCMD_ID", Microsoft.VisualBasic.Right(objTelegram.FORMAT_ID, 6))    'ｺﾏﾝﾄﾞID
        objTelegram.SETIN_HEADER("DSPTERM_ID", gcstrFTERM_ID)                                           '端末ID
        objTelegram.SETIN_HEADER("DSPUSER_ID", gcstrFUSER_ID)                                           '担当者ｺｰﾄﾞ

        objTelegram.SETIN_DATA("DSPPALLET_ID", "")                                                      'ﾊﾟﾚｯﾄID
        objTelegram.SETIN_DATA("DSPST_OUT", strOUTST_NO)                                                '出庫先ST
        objTelegram.SETIN_DATA("XDSPPALLET_ID_KO", "")                                                  'ﾊﾟﾚｯﾄID(子)
        objTelegram.SETIN_DATA("XDSPYOTEI_NUM", TO_STRING(intYOTEI_NUM))                                '予定数
        objTelegram.SETIN_DATA("XDSPYOTEI_EQ_ID", strXADRS_YOTEI)                                       '予定設備ID

        '送信電文
        ReDim strSndTlgrm(0)
        objTelegram.MAKE_TELEGRAM()
        strSndTlgrm(0) = objTelegram.TELEGRAM_MAKED

        '********************************************************************
        ' 問合せ出庫用 電文作成(手前)
        '********************************************************************
        If Not mudtFront_HANSOU_DATA Is Nothing Then
            '(手前棚を出庫する場合)

            For ii As Integer = 0 To UBound(mudtFront_HANSOU_DATA)
                '(手前棚分 電文作成)

                '配列再定義
                intHairetu = intHairetu + 1
                ReDim Preserve strSndTlgrm(0 To intHairetu)         '送信電文文字列


                Dim objTelegramSub As New clsTelegram(CONFIG_TELEGRAM_DSP)

                objTelegramSub.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S201601

                objTelegramSub.SETIN_HEADER("DSPCMD_ID", Microsoft.VisualBasic.Right(objTelegramSub.FORMAT_ID, 6))  'ｺﾏﾝﾄﾞID
                objTelegramSub.SETIN_HEADER("DSPTERM_ID", gcstrFTERM_ID)                                            '端末ID
                objTelegramSub.SETIN_HEADER("DSPUSER_ID", gcstrFUSER_ID)                                            '担当者ｺｰﾄﾞ

                objTelegramSub.SETIN_DATA("DSPPALLET_ID", mudtFront_HANSOU_DATA(ii).PALLET_ID_1)                    'ﾊﾟﾚｯﾄID(1)
                objTelegramSub.SETIN_DATA("DSPST_OUT", strOUTST_NO)                                                 '出庫先ST

                If mudtFront_HANSOU_DATA(ii).PARE_FLAG = True Then                                                  'ﾊﾟﾚｯﾄID(2)
                    objTelegramSub.SETIN_DATA("XDSPPALLET_ID_KO", mudtFront_HANSOU_DATA(ii).PALLET_ID_2)
                Else
                    objTelegramSub.SETIN_DATA("XDSPPALLET_ID_KO", "")
                End If

                objTelegramSub.MAKE_TELEGRAM()
                strSndTlgrm(intHairetu) = objTelegramSub.TELEGRAM_MAKED                                            '送信電文

            Next

        End If


        '********************************************************************
        ' 問合せ出庫用 電文作成(奥)
        '********************************************************************
        If Not mudtBack_HANSOU_DATA Is Nothing Then
            '(手前棚を出庫する場合)

            For ii As Integer = 0 To UBound(mudtBack_HANSOU_DATA)
                '(手前棚分 電文作成)

                '配列再定義
                intHairetu = intHairetu + 1
                ReDim Preserve strSndTlgrm(0 To intHairetu)         '送信電文文字列


                Dim objTelegramSub As New clsTelegram(CONFIG_TELEGRAM_DSP)

                objTelegramSub.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S201601

                objTelegramSub.SETIN_HEADER("DSPCMD_ID", Microsoft.VisualBasic.Right(objTelegramSub.FORMAT_ID, 6))  'ｺﾏﾝﾄﾞID
                objTelegramSub.SETIN_HEADER("DSPTERM_ID", gcstrFTERM_ID)                                            '端末ID
                objTelegramSub.SETIN_HEADER("DSPUSER_ID", gcstrFUSER_ID)                                            '担当者ｺｰﾄﾞ

                objTelegramSub.SETIN_DATA("DSPPALLET_ID", mudtBack_HANSOU_DATA(ii).PALLET_ID_1)                     'ﾊﾟﾚｯﾄID(1)
                objTelegramSub.SETIN_DATA("DSPST_OUT", strOUTST_NO)                                                 '出庫先ST

                If mudtBack_HANSOU_DATA(ii).PARE_FLAG = True Then                                                   'ﾊﾟﾚｯﾄID(2)
                    objTelegramSub.SETIN_DATA("XDSPPALLET_ID_KO", mudtBack_HANSOU_DATA(ii).PALLET_ID_2)
                Else
                    objTelegramSub.SETIN_DATA("XDSPPALLET_ID_KO", "")
                End If

                objTelegramSub.MAKE_TELEGRAM()
                strSndTlgrm(intHairetu) = objTelegramSub.TELEGRAM_MAKED                                             '送信電文

            Next

        End If

        '********************************************************************
        ' ｿｹｯﾄ送信処理
        '********************************************************************
        Dim strRetState() As String = Nothing               '出庫処理戻りｽﾃｰﾀｽ
        Dim strErrMsg As String = ""                        'ｴﾗｰﾒｯｾｰｼﾞ
        Dim udtSckSendRET As clsSocketClient.RetCode        'ｿｹｯﾄ送信戻り値
        Dim strRET_STATE As String = ""

        Dim objTelegramNull As New clsTelegram(CONFIG_TELEGRAM_DSP)
        objTelegramNull.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S201601

        '=====================================
        '複数ｿｹｯﾄ処理
        '=====================================
        strErrMsg = FRM_MSG_FRM303020_10
        udtSckSendRET = gobjComFuncFRM.SockSendServer02(objTelegramNull, strSndTlgrm, strRET_STATE, , , , strErrMsg)    'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            '(送信できた場合)
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)
                blnCheckErr = False
            End If
        End If


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
#Region "  ｿｹｯﾄ送信02   問合せ出庫処理(平置き、検品ｴﾘｱ) "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信02   問合せ出庫処理(平置き、検品ｴﾘｱ)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function InquiryOut2() As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        udtRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303020_09, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Function
        End If

        '********************************************************************
        ' 出庫在庫ﾃﾞｰﾀｾｯﾄ
        '********************************************************************
        'Dim udtOUT_STOCK() As STOCK_DATA = Nothing      '出庫在庫ﾃﾞｰﾀ用構造体
        Dim strSndTlgrm() As String = Nothing           '送信電文文字列
        Dim intHairetu As Integer = 0                   '配列数
        'Dim intRet As RetCode
        Dim strMsg As String = ""
        Dim strXADRS_YOTEI = ""                         '予定数ｱﾄﾞﾚｽ
        Dim strOUTST_NO As String = ""                  'ｽﾃｰｼｮﾝID
        Dim blnPareFlag As Boolean = False              'ﾍﾟｱ出庫ﾌﾗｸﾞ

        ' ''********************************************************************
        ' '' 出庫数予約用 電文作成
        ' ''********************************************************************
        ''strOUTST_NO = TO_STRING(cboFTRK_BUF_NO.SelectedValue)                   '出庫先ST

        ' ''予定設備IDの取得
        ''Dim intRet As RetCode
        ''Dim objTBL_TMST_TRK As TBL_TMST_TRK                                     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ
        ''objTBL_TMST_TRK = New TBL_TMST_TRK(gobjOwner, gobjDb, Nothing)

        ''objTBL_TMST_TRK.FTRK_BUF_NO = TO_STRING(cboFTRK_BUF_NO.SelectedValue)   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.

        ''intRet = objTBL_TMST_TRK.GET_TMST_TRK(False)
        ''If intRet = RetCode.OK Then
        ''    '(値がある時)
        ''    If Not objTBL_TMST_TRK.XADRS_YOTEI Is Nothing Then
        ''        strXADRS_YOTEI = objTBL_TMST_TRK.XADRS_YOTEI                        '予定数ｱﾄﾞﾚｽ
        ''    Else
        ''        strXADRS_YOTEI = ""
        ''        'Throw New System.Exception(FRM_MSG_FRM303020_10)
        ''    End If

        ''Else
        ''    '(読めなかった時)
        ''    strXADRS_YOTEI = ""
        ''    'Throw New System.Exception(FRM_MSG_FRM303020_10)
        ''End If


        ''Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)

        ''objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S201601

        ''objTelegram.SETIN_HEADER("DSPCMD_ID", Microsoft.VisualBasic.Right(objTelegram.FORMAT_ID, 6))    'ｺﾏﾝﾄﾞID
        ''objTelegram.SETIN_HEADER("DSPTERM_ID", gcstrFTERM_ID)                                           '端末ID
        ''objTelegram.SETIN_HEADER("DSPUSER_ID", gcstrFUSER_ID)                                           '担当者ｺｰﾄﾞ

        ''objTelegram.SETIN_DATA("DSPPALLET_ID", "")                                                      'ﾊﾟﾚｯﾄID
        ''objTelegram.SETIN_DATA("DSPST_OUT", strOUTST_NO)                                                '出庫先ST
        ''objTelegram.SETIN_DATA("XDSPPALLET_ID_KO", "")                                                  'ﾊﾟﾚｯﾄID(子)
        ''objTelegram.SETIN_DATA("XDSPYOTEI_NUM", TO_STRING(mudtGRID_LIST_ITEM.Length))                   '予定数
        ''objTelegram.SETIN_DATA("XDSPYOTEI_EQ_ID", strXADRS_YOTEI)                                       '予定設備ID

        ' ''送信電文
        ''ReDim strSndTlgrm(0)
        ''objTelegram.MAKE_TELEGRAM()
        ''strSndTlgrm(0) = objTelegram.TELEGRAM_MAKED

        '********************************************************************
        ' 問合せ出庫用 電文作成
        '********************************************************************
        For ii As Integer = 0 To UBound(mudtPL_HANSOU_DATA)
            '(手前棚分 電文作成)

            '配列再定義
            ReDim Preserve strSndTlgrm(0 To intHairetu)         '送信電文文字列


            Dim objTelegramSub As New clsTelegram(CONFIG_TELEGRAM_DSP)

            objTelegramSub.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S201601

            objTelegramSub.SETIN_HEADER("DSPCMD_ID", Microsoft.VisualBasic.Right(objTelegramSub.FORMAT_ID, 6))  'ｺﾏﾝﾄﾞID
            objTelegramSub.SETIN_HEADER("DSPTERM_ID", gcstrFTERM_ID)                                            '端末ID
            objTelegramSub.SETIN_HEADER("DSPUSER_ID", gcstrFUSER_ID)                                            '担当者ｺｰﾄﾞ

            objTelegramSub.SETIN_DATA("DSPPALLET_ID", mudtPL_HANSOU_DATA(ii).PALLET_ID_1)                       'ﾊﾟﾚｯﾄID(1)
            objTelegramSub.SETIN_DATA("DSPST_OUT", "")                                                          '出庫先ST
            objTelegramSub.SETIN_DATA("XDSPPALLET_ID_KO", "")                                                   'ﾊﾟﾚｯﾄID(2)

            objTelegramSub.MAKE_TELEGRAM()
            strSndTlgrm(intHairetu) = objTelegramSub.TELEGRAM_MAKED                                            '送信電文

            intHairetu = intHairetu + 1
        Next

        '********************************************************************
        ' ｿｹｯﾄ送信処理
        '********************************************************************
        Dim strRetState() As String = Nothing               '出庫処理戻りｽﾃｰﾀｽ
        Dim strErrMsg As String = ""                        'ｴﾗｰﾒｯｾｰｼﾞ
        Dim udtSckSendRET As clsSocketClient.RetCode        'ｿｹｯﾄ送信戻り値
        Dim strRET_STATE As String = ""

        Dim objTelegramNull As New clsTelegram(CONFIG_TELEGRAM_DSP)
        objTelegramNull.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S201601

        '=====================================
        '複数ｿｹｯﾄ処理
        '=====================================
        strErrMsg = FRM_MSG_FRM303020_10
        udtSckSendRET = gobjComFuncFRM.SockSendServer02(objTelegramNull, strSndTlgrm, strRET_STATE, , , , strErrMsg)    'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            '(送信できた場合)
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)
                blnCheckErr = False
            End If
        End If


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

#Region "  在庫ｴﾘｱの混在確認                        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 在庫ｴﾘｱの混在確認
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function Check_FTRK_BUF_NO_ZAIKO() As Boolean

        Dim blnReturn As Boolean
        Dim blnCheckErr As Boolean

        Dim strPrevFTRK_BUF_NO As String   '直前のﾄﾗｯｷﾝｸﾞ
        strPrevFTRK_BUF_NO = mudtGRID_LIST_ITEM(0).FTRK_BUF_NO

        Dim ii As Integer
        For ii = 1 To UBound(mudtGRID_LIST_ITEM)
            '(ﾙｰﾌﾟ:選択数分)

            If strPrevFTRK_BUF_NO <> mudtGRID_LIST_ITEM(ii).FTRK_BUF_NO Then
                '(ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.が一致しない場合)

                If strPrevFTRK_BUF_NO = FTRK_BUF_NO_J9000 Or _
                    mudtGRID_LIST_ITEM(ii).FTRK_BUF_NO = FTRK_BUF_NO_J9000 Then
                    '(自動倉庫が含まれる場合)

                    blnCheckErr = True
                    Exit For
                End If


            End If

        Next


        If blnCheckErr = True Then
            blnReturn = False
        Else
            blnReturn = True
        End If

        Check_FTRK_BUF_NO_ZAIKO = blnReturn

    End Function
#End Region

#Region "  平置き、検品ｴﾘｱ用ﾃﾞｰﾀ作成                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 平置き、検品ｴﾘｱ用ﾃﾞｰﾀ作成
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub MakePLArray()
        Dim ii As Long = 0

        mudtPL_HANSOU_DATA = Nothing

        For ii = 0 To UBound(mudtGRID_LIST_ITEM)
            '(配列再定義)
            If mudtPL_HANSOU_DATA Is Nothing Then
                '(初めて)
                ReDim Preserve mudtPL_HANSOU_DATA(0)
            Else
                '(2回目以降)
                ReDim Preserve mudtPL_HANSOU_DATA(UBound(mudtPL_HANSOU_DATA) + 1)
            End If

            mudtPL_HANSOU_DATA(UBound(mudtPL_HANSOU_DATA)).PALLET_ID_1 = mudtGRID_LIST_ITEM(ii).PALLET_ID   'ﾊﾟﾚｯﾄID(1)

        Next

    End Sub
#End Region

#Region "  付帯出庫 手前ﾃﾞｰﾀ作成                    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 付帯出庫 手前ﾃﾞｰﾀ作成
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub MakeFUTAI_DATA()

        '********************************************
        ' 選択中のﾃﾞｰﾀをﾌﾞﾛｯｸ毎にまとめる
        '********************************************
        Dim udtTANA_BLOCK() As TANA_BLOCK_DATA = Nothing        '棚ﾌﾞﾛｯｸﾃﾞｰﾀ
        Dim i As Integer
        Dim j As Integer
        Dim intIndex As Integer

        For i = 0 To grdList.SelectedRows.Count - 1
            '(選択列の分ﾙｰﾌﾟ)
            Dim strTANA_BLOCK As String             '棚ﾌﾞﾛｯｸ
            Dim strTANA_BLOCK_DTL As String         '棚ﾌﾞﾛｯｸ詳細
            Dim strPALLET_ID As String              'ﾊﾟﾚｯﾄID

            strTANA_BLOCK = TO_STRING(grdList.Item(menmListCol.XTANA_BLOCK, grdList.SelectedRows(i).Index).Value)
            strTANA_BLOCK_DTL = TO_STRING(grdList.Item(menmListCol.XTANA_BLOCK_DTL, grdList.SelectedRows(i).Index).Value)
            strPALLET_ID = TO_STRING(grdList.Item(menmListCol.FPALLET_ID, grdList.SelectedRows(i).Index).Value)

            If udtTANA_BLOCK Is Nothing Then
                '(初回時)
                ReDim udtTANA_BLOCK(0)      '再定義
                intIndex = 0
            Else
                '(以降)
                intIndex = -1

                '登録済かﾁｪｯｸ
                For j = 0 To UBound(udtTANA_BLOCK)
                    If strTANA_BLOCK = udtTANA_BLOCK(j).TANA_BLOCK Then
                        '(一致)
                        intIndex = j
                        Exit For
                    End If
                Next

                If intIndex < 0 Then
                    '(見つからない場合)
                    ReDim Preserve udtTANA_BLOCK(UBound(udtTANA_BLOCK) + 1)      '再定義
                    intIndex = UBound(udtTANA_BLOCK)
                End If
            End If

            udtTANA_BLOCK(intIndex).TANA_BLOCK = strTANA_BLOCK          '棚ﾌﾞﾛｯｸ

            '棚ﾌﾞﾛｯｸ詳細の位置に合わせてﾊﾟﾚｯﾄIDを記録
            If TO_INTEGER(strTANA_BLOCK_DTL) = 1 Then
                '(奥 偶数)
                udtTANA_BLOCK(intIndex).PALLET_ID_1 = strPALLET_ID
                udtTANA_BLOCK(intIndex).FLAG_Back = True

            ElseIf TO_INTEGER(strTANA_BLOCK_DTL) = 2 Then
                '(奥 奇数)
                udtTANA_BLOCK(intIndex).PALLET_ID_2 = strPALLET_ID
                udtTANA_BLOCK(intIndex).FLAG_Back = True

            ElseIf TO_INTEGER(strTANA_BLOCK_DTL) = 3 Then
                '(手前 偶数)
                udtTANA_BLOCK(intIndex).PALLET_ID_3 = strPALLET_ID
                udtTANA_BLOCK(intIndex).FLAG_Front = True

            ElseIf TO_INTEGER(strTANA_BLOCK_DTL) = 4 Then
                '(手前 奇数)
                udtTANA_BLOCK(intIndex).PALLET_ID_4 = strPALLET_ID
                udtTANA_BLOCK(intIndex).FLAG_Front = True

            End If

        Next

        '********************************************************************
        ' 奥棚ﾃﾞｰﾀがある場合、手前の棚ﾃﾞｰﾀを追加する
        '********************************************************************
        Dim strSQL As String                'SQL文
        Dim objRow_GUUSUU As DataRow        '偶数のﾃﾞｰﾀ
        Dim objRow_KISUU As DataRow         '奇数のﾃﾞｰﾀ
        Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名

        For i = 0 To UBound(udtTANA_BLOCK)
            '(棚ﾌﾞﾛｯｸの分ﾙｰﾌﾟ)
            If udtTANA_BLOCK(i).FLAG_Back = True Then
                '(奥棚を出庫する場合)

                Dim strFPALLET_ID_GUUSUU As String = ""     '偶数 ﾊﾟﾚｯﾄID
                Dim strFPALLET_ID_KISUU As String = ""      '奇数 ﾊﾟﾚｯﾄID
                Dim blnZAIKO_GUUSUU As Boolean = False      '偶数 在庫ﾌﾗｸﾞ
                Dim blnZAIKO_KISUU As Boolean = False       '奇数 在庫ﾌﾗｸﾞ
                Dim strFRES_KIND_GUUSUU As String = ""      '偶数 引当状態
                Dim strFRES_KIND_KISUU As String = ""       '奇数 引当状態

                '============================================================
                ' SQL文
                '============================================================
                strSQL = ""
                strSQL &= vbCrLf & "SELECT "
                strSQL &= vbCrLf & "    FPALLET_ID "                                        'ﾊﾟﾚｯﾄID
                strSQL &= vbCrLf & "  , FRES_KIND "                                         '引当状態
                strSQL &= vbCrLf & " FROM "
                strSQL &= vbCrLf & "    TPRG_TRK_BUF "                                      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
                strSQL &= vbCrLf & " WHERE "
                strSQL &= vbCrLf & "        1 = 1 "
                strSQL &= vbCrLf & "    AND XTANA_BLOCK = " & udtTANA_BLOCK(i).TANA_BLOCK   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ の 棚ﾌﾞﾛｯｸ を 指定
                strSQL &= vbCrLf & "    AND XTANA_BLOCK_DTL IN (3, 4) "                     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ の 棚ﾌﾞﾛｯｸ詳細 を 指定(手前のみ取得)
                strSQL &= vbCrLf & " ORDER BY "
                strSQL &= vbCrLf & "    XTANA_BLOCK_DTL "

                '-----------------------
                '抽出
                '-----------------------
                gobjDb.SQL = strSQL
                objDataSet.Clear()
                strDataSetName = "TPRG_TRK_BUF"
                gobjDb.GetDataSet(strDataSetName, objDataSet)
                If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                    objRow_GUUSUU = objDataSet.Tables(strDataSetName).Rows(0)       '手前 偶数
                    strFPALLET_ID_GUUSUU = TO_STRING(objRow_GUUSUU("FPALLET_ID"))
                    strFRES_KIND_GUUSUU = TO_STRING(objRow_GUUSUU("FRES_KIND"))

                    objRow_KISUU = objDataSet.Tables(strDataSetName).Rows(1)        '手前 奇数
                    strFPALLET_ID_KISUU = TO_STRING(objRow_KISUU("FPALLET_ID"))
                    strFRES_KIND_KISUU = TO_STRING(objRow_KISUU("FRES_KIND"))
                End If

                '********************************************************************
                ' 在庫有無の確認
                '********************************************************************
                If strFPALLET_ID_GUUSUU <> "" Then
                    If TO_INTEGER(strFRES_KIND_GUUSUU) = 1 Then
                        '(偶数に在庫あり)
                        blnZAIKO_GUUSUU = True
                    End If
                End If

                If strFPALLET_ID_KISUU <> "" Then
                    If TO_INTEGER(strFRES_KIND_KISUU) = 1 Then
                        '(奇数に在庫あり)
                        blnZAIKO_KISUU = True
                    End If
                End If

                '********************************************************************
                ' 在庫ﾃﾞｰﾀ ｾｯﾄ
                '********************************************************************
                If blnZAIKO_GUUSUU = True Or blnZAIKO_KISUU = True Then
                    '(在庫がある場合)
                    If blnZAIKO_GUUSUU = True And blnZAIKO_KISUU = True Then
                        '(両方在庫あり)
                        udtTANA_BLOCK(i).FLAG_Front = True
                        udtTANA_BLOCK(i).PALLET_ID_3 = strFPALLET_ID_GUUSUU
                        udtTANA_BLOCK(i).PALLET_ID_4 = strFPALLET_ID_KISUU

                    ElseIf blnZAIKO_GUUSUU = True And blnZAIKO_KISUU = False Then
                        '(偶数のみ在庫あり)
                        udtTANA_BLOCK(i).FLAG_Front = True
                        udtTANA_BLOCK(i).PALLET_ID_3 = strFPALLET_ID_GUUSUU

                    ElseIf blnZAIKO_GUUSUU = False And blnZAIKO_KISUU = True Then
                        '(奇数のみ在庫あり)
                        udtTANA_BLOCK(i).FLAG_Front = True
                        udtTANA_BLOCK(i).PALLET_ID_4 = strFPALLET_ID_KISUU

                    End If
                End If
            End If

        Next

        '********************************************************************
        ' 出庫対象のﾃﾞｰﾀを作成
        '********************************************************************
        Dim udtFront_HANSOU_DATA() As HANSOU_DATA = Nothing      '新規 手前ﾃﾞｰﾀ
        Dim udtBack_HANSOU_DATA() As HANSOU_DATA = Nothing       '新規 奥ﾃﾞｰﾀ

        For i = 0 To UBound(udtTANA_BLOCK)
            '(棚ﾌﾞﾛｯｸの分ﾙｰﾌﾟ)

            '********************************************************************
            ' 手前棚のﾃﾞｰﾀを作成
            '********************************************************************
            If udtTANA_BLOCK(i).FLAG_Front = True Then
                '(手前ﾃﾞｰﾀがある場合)

                If udtFront_HANSOU_DATA Is Nothing Then
                    '(初回時)
                    ReDim udtFront_HANSOU_DATA(0)
                    intIndex = 0
                Else
                    '(以降)
                    ReDim Preserve udtFront_HANSOU_DATA(UBound(udtFront_HANSOU_DATA) + 1)
                    intIndex = UBound(udtFront_HANSOU_DATA)
                End If

                'ﾍﾟｱかｼﾝｸﾞﾙか確認
                If udtTANA_BLOCK(i).PALLET_ID_3 <> "" And udtTANA_BLOCK(i).PALLET_ID_4 <> "" Then
                    '(ﾍﾟｱ搬送の場合)
                    udtFront_HANSOU_DATA(intIndex).PARE_FLAG = True
                    udtFront_HANSOU_DATA(intIndex).PALLET_ID_1 = udtTANA_BLOCK(i).PALLET_ID_3
                    udtFront_HANSOU_DATA(intIndex).PALLET_ID_2 = udtTANA_BLOCK(i).PALLET_ID_4

                ElseIf udtTANA_BLOCK(i).PALLET_ID_3 <> "" And udtTANA_BLOCK(i).PALLET_ID_4 = "" Then
                    '(偶数列のみの場合)
                    udtFront_HANSOU_DATA(intIndex).PARE_FLAG = False
                    udtFront_HANSOU_DATA(intIndex).PALLET_ID_1 = udtTANA_BLOCK(i).PALLET_ID_3

                ElseIf udtTANA_BLOCK(i).PALLET_ID_3 = "" And udtTANA_BLOCK(i).PALLET_ID_4 <> "" Then
                    '(奇数列のみの場合)
                    udtFront_HANSOU_DATA(intIndex).PARE_FLAG = False
                    udtFront_HANSOU_DATA(intIndex).PALLET_ID_1 = udtTANA_BLOCK(i).PALLET_ID_4

                End If
            End If

            '********************************************************************
            ' 奥棚のﾃﾞｰﾀを作成
            '********************************************************************
            If udtTANA_BLOCK(i).FLAG_Back = True Then
                '(奥ﾃﾞｰﾀがある場合)

                If udtBack_HANSOU_DATA Is Nothing Then
                    '(初回時)
                    ReDim udtBack_HANSOU_DATA(0)
                    intIndex = 0
                Else
                    '(以降)
                    ReDim Preserve udtBack_HANSOU_DATA(UBound(udtBack_HANSOU_DATA) + 1)
                    intIndex = UBound(udtBack_HANSOU_DATA)
                End If

                'ﾍﾟｱかｼﾝｸﾞﾙか確認
                If udtTANA_BLOCK(i).PALLET_ID_1 <> "" And udtTANA_BLOCK(i).PALLET_ID_2 <> "" Then
                    '(ﾍﾟｱ搬送の場合)
                    udtBack_HANSOU_DATA(intIndex).PARE_FLAG = True
                    udtBack_HANSOU_DATA(intIndex).PALLET_ID_1 = udtTANA_BLOCK(i).PALLET_ID_1
                    udtBack_HANSOU_DATA(intIndex).PALLET_ID_2 = udtTANA_BLOCK(i).PALLET_ID_2

                ElseIf udtTANA_BLOCK(i).PALLET_ID_1 <> "" And udtTANA_BLOCK(i).PALLET_ID_2 = "" Then
                    '(偶数列のみの場合)
                    udtBack_HANSOU_DATA(intIndex).PARE_FLAG = False
                    udtBack_HANSOU_DATA(intIndex).PALLET_ID_1 = udtTANA_BLOCK(i).PALLET_ID_1

                ElseIf udtTANA_BLOCK(i).PALLET_ID_1 = "" And udtTANA_BLOCK(i).PALLET_ID_2 <> "" Then
                    '(奇数列のみの場合)
                    udtBack_HANSOU_DATA(intIndex).PARE_FLAG = False
                    udtBack_HANSOU_DATA(intIndex).PALLET_ID_1 = udtTANA_BLOCK(i).PALLET_ID_2

                End If
            End If

        Next

        '出庫ﾃﾞｰﾀ入替
        mudtFront_HANSOU_DATA = Nothing
        mudtFront_HANSOU_DATA = udtFront_HANSOU_DATA
        mudtBack_HANSOU_DATA = Nothing
        mudtBack_HANSOU_DATA = udtBack_HANSOU_DATA


    End Sub
#End Region


#Region "  手前と奥でﾃﾞｰﾀを分別                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 手前と奥でﾃﾞｰﾀを分別
    ''' </summary>
    ''' <param name="aryFront">手前</param>
    ''' <param name="aryBack">奥</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub MakeFrontBackArray(ByRef aryFront() As GRID_LIST_ITEM, ByRef aryBack() As GRID_LIST_ITEM)

        aryFront = Nothing
        aryBack = Nothing

        Dim ii As Long = 0

        For ii = 0 To UBound(mudtGRID_LIST_ITEM)

            If mudtGRID_LIST_ITEM(ii).RAC_EDA = 0 Then
                '(手前の場合)
                If aryFront Is Nothing Then
                    '(初めて)
                    ReDim Preserve aryFront(0)
                Else
                    '(2回目以降)
                    ReDim Preserve aryFront(UBound(aryFront) + 1)
                End If

                aryFront(UBound(aryFront)) = mudtGRID_LIST_ITEM(ii)

            ElseIf mudtGRID_LIST_ITEM(ii).RAC_EDA = 1 Then
                '(奥の場合)
                If aryBack Is Nothing Then
                    '(初めて)
                    ReDim Preserve aryBack(0)
                Else
                    '(2回目以降)
                    ReDim Preserve aryBack(UBound(aryBack) + 1)
                End If

                aryBack(UBound(aryBack)) = mudtGRID_LIST_ITEM(ii)

            End If

        Next


    End Sub
#End Region
#Region "  選択ﾃﾞｰﾀから偶数奇数を捜査・まとめる     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 選択ﾃﾞｰﾀから偶数奇数を捜査・まとめる
    ''' </summary>
    ''' <param name="aryGRID_LIST_ITEM">ｸﾞﾘｯﾄﾞﾃﾞｰﾀ</param>
    ''' <param name="aryHANSOU_DATA">搬送ﾃﾞｰﾀ</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub MakeHANSOU_SET_DATA(ByVal aryGRID_LIST_ITEM() As GRID_LIST_ITEM, ByRef aryHANSOU_DATA() As HANSOU_DATA)

        Dim ii As Long
        Dim intTarget As Long

        aryHANSOU_DATA = Nothing

        If aryGRID_LIST_ITEM Is Nothing Then
            Exit Sub
        End If

        For ii = 0 To UBound(aryGRID_LIST_ITEM)
            '(ｸﾞﾘｯﾄﾞﾃﾞｰﾀ分ﾙｰﾌﾟ)

            If aryGRID_LIST_ITEM(ii).PARE_FLAG = True Then
                '(既に親子関係の場合)
                Continue For
            End If

            '=====================================
            '偶数か奇数か特定・捜査対象の列を決定
            '=====================================
            Dim intRAC_REN_Target As Integer        '捜査対象 列

            If (aryGRID_LIST_ITEM(ii).RAC_REN Mod 2) = 0 Then
                '(偶数の場合)
                intRAC_REN_Target = aryGRID_LIST_ITEM(ii).RAC_REN - 1   '捜査対象:奇数
            Else
                '(奇数の場合)
                intRAC_REN_Target = aryGRID_LIST_ITEM(ii).RAC_REN + 1   '捜査対象:偶数
            End If

            '=====================================
            '相方の捜査
            '=====================================
            Dim blnFind As Boolean = False      '相方発見ﾌﾗｸﾞ

            For intTarget = ii + 1 To UBound(aryGRID_LIST_ITEM)
                '(残りのﾃﾞｰﾀ分ﾙｰﾌﾟ)

                If aryGRID_LIST_ITEM(intTarget).PARE_FLAG = True Then
                    '(既に親子関係の場合)
                    Continue For
                End If

                If aryGRID_LIST_ITEM(ii).RAC_RETU = aryGRID_LIST_ITEM(intTarget).RAC_RETU And _
                   intRAC_REN_Target = aryGRID_LIST_ITEM(intTarget).RAC_REN And _
                   aryGRID_LIST_ITEM(ii).RAC_DAN = aryGRID_LIST_ITEM(intTarget).RAC_DAN And _
                   aryGRID_LIST_ITEM(ii).RAC_EDA = aryGRID_LIST_ITEM(intTarget).RAC_EDA Then
                    '(対象と一致している場合)

                    aryGRID_LIST_ITEM(intTarget).PARE_FLAG = True
                    blnFind = True
                    Exit For
                End If

            Next

            '=====================================
            '配列のｻｲｽﾞ変更
            '=====================================
            If aryHANSOU_DATA Is Nothing Then
                '(初めて)
                ReDim aryHANSOU_DATA(0)
            Else
                '(それ以外)
                ReDim Preserve aryHANSOU_DATA(UBound(aryHANSOU_DATA) + 1)
            End If

            '=====================================
            '搬送ﾃﾞｰﾀ ｾｯﾄ
            '=====================================
            If blnFind = True Then
                '(相方が見つかった場合)
                aryHANSOU_DATA(UBound(aryHANSOU_DATA)).RAC_RETU = aryGRID_LIST_ITEM(ii).RAC_RETU    '列
                aryHANSOU_DATA(UBound(aryHANSOU_DATA)).RAC_DAN = aryGRID_LIST_ITEM(ii).RAC_DAN      '段
                aryHANSOU_DATA(UBound(aryHANSOU_DATA)).RAC_EDA = aryGRID_LIST_ITEM(ii).RAC_EDA      '枝
                aryHANSOU_DATA(UBound(aryHANSOU_DATA)).PARE_FLAG = True                             'ﾍﾟｱﾌﾗｸﾞ

                If (aryGRID_LIST_ITEM(ii).RAC_REN Mod 2) = 0 Then
                    '(元ﾃﾞｰﾀが偶数の場合)
                    aryHANSOU_DATA(UBound(aryHANSOU_DATA)).RAC_REN_1 = aryGRID_LIST_ITEM(ii).RAC_REN                        '連(1)
                    aryHANSOU_DATA(UBound(aryHANSOU_DATA)).PALLET_ID_1 = aryGRID_LIST_ITEM(ii).PALLET_ID                    'ﾊﾟﾚｯﾄID(1)
                    aryHANSOU_DATA(UBound(aryHANSOU_DATA)).TANA_BLOCK_1 = aryGRID_LIST_ITEM(ii).TANA_BLOCK                  '棚ﾌﾞﾛｯｸ(1)
                    aryHANSOU_DATA(UBound(aryHANSOU_DATA)).TANA_BLOCK_DTL_1 = aryGRID_LIST_ITEM(ii).TANA_BLOCK_DTL          '棚ﾌﾞﾛｯｸ詳細(1)

                    aryHANSOU_DATA(UBound(aryHANSOU_DATA)).RAC_REN_2 = aryGRID_LIST_ITEM(intTarget).RAC_REN                 '連(2)
                    aryHANSOU_DATA(UBound(aryHANSOU_DATA)).PALLET_ID_2 = aryGRID_LIST_ITEM(intTarget).PALLET_ID             'ﾊﾟﾚｯﾄID(2)
                    aryHANSOU_DATA(UBound(aryHANSOU_DATA)).TANA_BLOCK_2 = aryGRID_LIST_ITEM(intTarget).TANA_BLOCK           '棚ﾌﾞﾛｯｸ(2)
                    aryHANSOU_DATA(UBound(aryHANSOU_DATA)).TANA_BLOCK_DTL_2 = aryGRID_LIST_ITEM(intTarget).TANA_BLOCK_DTL   '棚ﾌﾞﾛｯｸ詳細(2)

                Else
                    '(元ﾃﾞｰﾀが奇数の場合)
                    aryHANSOU_DATA(UBound(aryHANSOU_DATA)).RAC_REN_1 = aryGRID_LIST_ITEM(intTarget).RAC_REN                 '連(1)
                    aryHANSOU_DATA(UBound(aryHANSOU_DATA)).PALLET_ID_1 = aryGRID_LIST_ITEM(intTarget).PALLET_ID             'ﾊﾟﾚｯﾄID(1)
                    aryHANSOU_DATA(UBound(aryHANSOU_DATA)).TANA_BLOCK_1 = aryGRID_LIST_ITEM(intTarget).TANA_BLOCK           '棚ﾌﾞﾛｯｸ(1)
                    aryHANSOU_DATA(UBound(aryHANSOU_DATA)).TANA_BLOCK_DTL_1 = aryGRID_LIST_ITEM(intTarget).TANA_BLOCK_DTL   '棚ﾌﾞﾛｯｸ詳細(1)

                    aryHANSOU_DATA(UBound(aryHANSOU_DATA)).RAC_REN_2 = aryGRID_LIST_ITEM(ii).RAC_REN                        '連(2)
                    aryHANSOU_DATA(UBound(aryHANSOU_DATA)).PALLET_ID_2 = aryGRID_LIST_ITEM(ii).PALLET_ID                    'ﾊﾟﾚｯﾄID(2)
                    aryHANSOU_DATA(UBound(aryHANSOU_DATA)).TANA_BLOCK_2 = aryGRID_LIST_ITEM(ii).TANA_BLOCK                  '棚ﾌﾞﾛｯｸ(2)
                    aryHANSOU_DATA(UBound(aryHANSOU_DATA)).TANA_BLOCK_DTL_2 = aryGRID_LIST_ITEM(ii).TANA_BLOCK_DTL          '棚ﾌﾞﾛｯｸ詳細(2)

                End If

            Else
                '(相方が見つからない場合)
                aryHANSOU_DATA(UBound(aryHANSOU_DATA)).RAC_RETU = aryGRID_LIST_ITEM(ii).RAC_RETU    '列
                aryHANSOU_DATA(UBound(aryHANSOU_DATA)).RAC_DAN = aryGRID_LIST_ITEM(ii).RAC_DAN      '段
                aryHANSOU_DATA(UBound(aryHANSOU_DATA)).RAC_EDA = aryGRID_LIST_ITEM(ii).RAC_EDA      '枝
                aryHANSOU_DATA(UBound(aryHANSOU_DATA)).PARE_FLAG = False                            'ﾍﾟｱﾌﾗｸﾞ

                aryHANSOU_DATA(UBound(aryHANSOU_DATA)).RAC_REN_1 = aryGRID_LIST_ITEM(ii).RAC_REN                      '連(1)
                aryHANSOU_DATA(UBound(aryHANSOU_DATA)).PALLET_ID_1 = aryGRID_LIST_ITEM(ii).PALLET_ID                  'ﾊﾟﾚｯﾄID(1)
                aryHANSOU_DATA(UBound(aryHANSOU_DATA)).TANA_BLOCK_1 = aryGRID_LIST_ITEM(ii).TANA_BLOCK                '棚ﾌﾞﾛｯｸ(1)
                aryHANSOU_DATA(UBound(aryHANSOU_DATA)).TANA_BLOCK_DTL_1 = aryGRID_LIST_ITEM(ii).TANA_BLOCK_DTL        '棚ﾌﾞﾛｯｸ詳細(1)
            End If

        Next

    End Sub
#End Region
#Region "  一致するﾊﾟﾚｯﾄIDを探す                    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 一致するﾊﾟﾚｯﾄIDを探す
    ''' </summary>
    ''' <param name="aryFront">前棚ﾃﾞｰﾀ</param>
    ''' <param name="strFPALLETID">ﾊﾟﾚｯﾄID</param>
    ''' <param name="intIndex">配列No.</param>
    ''' <returns>発見:true 未発見:false</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function SearchPALLET_ID(ByVal aryFront() As GRID_LIST_ITEM, ByVal strFPALLETID As String, Optional ByRef intIndex As Integer = -1) As Boolean

        Dim blnReturn = False
        Dim ii As Long

        For ii = 0 To UBound(aryFront)
            If aryFront(ii).PALLET_ID = strFPALLETID Then
                intIndex = ii
                blnReturn = True
                Exit For

            End If

        Next

        Return blnReturn

    End Function

#End Region

#Region "  ﾓｰﾄﾞ取得ﾀｲﾏｰ処理                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 設備状態取得ﾀｲﾏｰ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tmr303020_TickProcess()

        Select Case TO_INTEGER(cboFTRK_BUF_NO.SelectedValue)
            Case FTRK_BUF_NO_J2038, FTRK_BUF_NO_J1171, FTRK_BUF_NO_J1172, FTRK_BUF_NO_J1173, FTRK_BUF_NO_J1174
                '(D21,C01～C04)

                lblSTMode.Visible = True
                cboXCONVYOR_YOUTO.Enabled = False
                cmdModeChange.Visible = False

                '**********************************************************
                ' ﾓｰﾄﾞ ﾗﾍﾞﾙ背景色変更処理
                '**********************************************************
                Call gobjComFuncFRM.AlterLabelColorMOD_TIBA(lblSTMode, TO_STRING(cboFTRK_BUF_NO.SelectedValue), LBL_DSPTYPE.STSNAME)
                lblSTMode.ForeColor = Color.Black

            Case FTRK_BUF_NO_J1102, FTRK_BUF_NO_J1121, FTRK_BUF_NO_J1122, FTRK_BUF_NO_J1123, FTRK_BUF_NO_J1124, FTRK_BUF_NO_J1125, FTRK_BUF_NO_J1127, FTRK_BUF_NO_J1128, FTRK_BUF_NO_J1129, FTRK_BUF_NO_J1130, FTRK_BUF_NO_J1131, _
                     FTRK_BUF_NO_J1132, FTRK_BUF_NO_J1133, FTRK_BUF_NO_J1134, FTRK_BUF_NO_J1135, FTRK_BUF_NO_J1137, FTRK_BUF_NO_J1138, FTRK_BUF_NO_J1139, FTRK_BUF_NO_J1140, FTRK_BUF_NO_J1141, FTRK_BUF_NO_J1142, _
                     FTRK_BUF_NO_J1143, FTRK_BUF_NO_J1144, FTRK_BUF_NO_J1151, FTRK_BUF_NO_J1152, FTRK_BUF_NO_J1153, FTRK_BUF_NO_J1154, FTRK_BUF_NO_J1155, FTRK_BUF_NO_J1156, FTRK_BUF_NO_J1157, FTRK_BUF_NO_J1158, _
                     FTRK_BUF_NO_J1159, FTRK_BUF_NO_J1161, FTRK_BUF_NO_J1162
                '(B01～B34)

                lblSTMode.Visible = True
                cboXCONVYOR_YOUTO.Enabled = True
                cmdModeChange.Visible = True

                '**********************************************************
                ' ｺﾝﾍﾞﾔ用途の取得
                '**********************************************************
                Dim intXCONVEYOR_YOUTO As Integer

                Dim intRet As RetCode
                Dim objTBL_XSTS_CONVEYOR As TBL_XSTS_CONVEYOR                               '出荷ｺﾝﾍﾞﾔ状況
                objTBL_XSTS_CONVEYOR = New TBL_XSTS_CONVEYOR(gobjOwner, gobjDb, Nothing)

                objTBL_XSTS_CONVEYOR.XSTNO = TO_STRING(cboFTRK_BUF_NO.SelectedValue)        'STNo.

                intRet = objTBL_XSTS_CONVEYOR.GET_XSTS_CONVEYOR(False)
                If intRet = RetCode.OK Then
                    '(値がある時)
                    If Not objTBL_XSTS_CONVEYOR.XCONVEYOR_YOUTO Is Nothing Then
                        intXCONVEYOR_YOUTO = objTBL_XSTS_CONVEYOR.XCONVEYOR_YOUTO           'ｺﾝﾍﾞﾔ用途
                    Else
                        Throw New System.Exception("ｺﾝﾍﾞﾔ用途の取得に失敗しました。")
                    End If

                Else
                    '(読めなかった時)
                    Throw New System.Exception("ｺﾝﾍﾞﾔ用途の取得に失敗しました。")
                End If

                'ｺﾝﾍﾞﾔ用途の表示
                Select Case intXCONVEYOR_YOUTO
                    Case XCONVEYOR_YOUTO_JPALLET                        'ﾊﾟﾚｯﾄ
                        lblSTMode.Text = "パレット"

                    Case XCONVEYOR_YOUTO_JBARA                          'ﾊﾞﾗ
                        lblSTMode.Text = "バラ"

                    Case XCONVEYOR_YOUTO_JDOWN                          '切離し
                        lblSTMode.Text = "切離し"

                    Case XCONVEYOR_YOUTO_JINOUT                         '設定出庫
                        lblSTMode.Text = "設定出庫"

                End Select

                lblSTMode.ForeColor = Color.White
                lblSTMode.BackColor = Color.DarkGreen

            Case Else
                '(その他)
                lblSTMode.Visible = False
                cboXCONVYOR_YOUTO.Enabled = False
                cmdModeChange.Visible = False

        End Select

    End Sub
#End Region

End Class
