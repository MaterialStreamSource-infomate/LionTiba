'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】倉替入庫設定画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_303030

#Region "　共通変数　                               "

    '検索条件用構造体
    Private mudtSEARCH_ITEM As New SEARCH_ITEM

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ

    ''' <summary>ﾁｪｯｸ用列挙体</summary>
    Enum menmCheckCase
        SearchBtn_Click                 '検索ﾎﾞﾀﾝｸﾘｯｸ時
        KurakaeNyuuko_Click             '倉替入庫設定ﾎﾞﾀﾝｸﾘｯｸ時
    End Enum

    ''' <summary>ｸﾞﾘｯﾄﾞ項目</summary>
    Enum menmListCol
        TRK_BUF_NO                      '倉替入庫設定画面.       在庫ｴﾘｱ
        TRK_BUF_NO_Disp                 '倉替入庫設定画面.       在庫ｴﾘｱ(表示用)
        XHINMEI_CD                      '倉替入庫設定画面.       品名ｺｰﾄﾞ
        FHINMEI_CD                      '倉替入庫設定画面.       品名記号
        HINMEI                          '倉替入庫設定画面.       品名
        PROD_LINE                       '倉替入庫設定画面.       生産ﾗｲﾝNo.
        TR_VOL                          '倉替入庫設定画面.       数量
        ARRIVE_DT                       '倉替入庫設定画面.       入庫日
        KENSA_KUBUN                     '倉替入庫設定画面.       検査区分
        KENSA_KUBUN_disp                '倉替入庫設定画面.       検査区分(表示用)
        HORYU_KUBUN                     '倉替入庫設定画面.       保留区分
        HORYU_KUBUN_disp                '倉替入庫設定画面.       保留区分(表示用)
        KENPIN_KUBUN                    '倉替入庫設定画面.       検品区分
        KENPIN_KUBUN_disp               '倉替入庫設定画面.       検品区分(表示用)
        XARTICLE_TYPE_CODE              '倉替入庫設定画面.       製品区分
        XARTICLE_TYPE_CODE_Disp         '倉替入庫設定画面.       製品区分(表示用)
        LOT_NO                          '倉替入庫設定画面.       ﾛｯﾄNo.
        PALLET_ID                       '倉替入庫設定画面.       ﾊﾟﾚｯﾄID
        IN_KUBUN                        '倉替入庫設定画面.       入庫区分

        'ｿｰﾄ用
        ' ''TANA_BLOCK                      '倉替入庫設定画面.       棚ﾌﾞﾛｯｸ
        ' ''TANA_BLOCK_DTL                  '倉替入庫設定画面.       棚ﾌﾞﾛｯｸ詳細
        ' ''RAC_RETU                        '倉替入庫設定画面.       列
        ' ''RAC_REN                         '倉替入庫設定画面.       連
        ' ''RAC_DAN                         '倉替入庫設定画面.       段
        ' ''RAC_EDA                         '倉替入庫設定画面.       枝

        MAXCOL

    End Enum

#End Region
#Region "  構造体定義　                             "

    ''' <summary>検索条件</summary>
    Private Structure SEARCH_ITEM
        Dim STOCK_AREA As String        '在庫ｴﾘｱ
        Dim HINMEI_CD As String         '品名ｺｰﾄﾞ
        Dim ARRIVE_DT_FROM As String    '入庫日(FROM)
        Dim ARRIVE_DT_TO As String      '入庫日(TO)
        Dim PROD_LINE As String         '生産ﾗｲﾝNo.
        Dim KENSA_KUBUN As String       '検査区分
        Dim HORYU_KUBUN As String       '保留区分
        Dim XARTICLE_TYPE_CODE As String    '商品区分
    End Structure

    ''' <summary>倉替入庫</summary>
    Private Structure SORT_ITEM
        Dim FARRIVE_DT As String        '在庫発生日時
        Dim FPALLET_ID As String        'ﾊﾟﾚｯﾄID
    End Structure

#End Region
#Region "  ｲﾍﾞﾝﾄ                                    "
#Region "　入庫STｺﾝﾎﾞﾎﾞｯｸｽﾌｫｰｶｽ           ｲﾍﾞﾝﾄ     "
    Private Sub cboFTRK_BUF_NO_NYUUKO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFTRK_BUF_NO_NYUUKO.GotFocus
        tmr303030.Enabled = False   'ﾀｲﾏｰ停止
    End Sub
#End Region
#Region "　入庫STｺﾝﾎﾞﾎﾞｯｸｽﾌｫｰｶｽﾛｽﾄ        ｲﾍﾞﾝﾄ     "
    Private Sub cboFTRK_BUF_NO_NYUUKO_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFTRK_BUF_NO_NYUUKO.LostFocus
        Call tmr303030_TickProcess()    'ﾀｲﾏｰ処理
        tmr303030.Enabled = True        'ﾀｲﾏｰ再開
    End Sub
#End Region
#Region "　入庫STｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞ       ｲﾍﾞﾝﾄ     "
    Private Sub cboFTRK_BUF_NO_NYUUKO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFTRK_BUF_NO_NYUUKO.SelectedIndexChanged
        Try

            If mFlag_Form_Load = False Then

                Dim intSelect As Integer
                intSelect = TO_INTEGER(cboFTRK_BUF_NO_NYUUKO.SelectedValue)

                Select Case intSelect
                    Case FTRK_BUF_NO_J2038, FTRK_BUF_NO_J1171, FTRK_BUF_NO_J1172, FTRK_BUF_NO_J1173, FTRK_BUF_NO_J1174
                        lblSTMode.Visible = True

                    Case Else
                        lblSTMode.Visible = False

                End Select


            End If

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
    Private Sub tmr303030_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr303030.Tick
        Try

            tmr303030.Enabled = False

            '**************************************************
            ' ﾓｰﾄﾞ取得ﾀｲﾏｰ処理
            '**************************************************
            Call tmr303030_TickProcess()

        Catch ex As Exception
            ComError(ex)

        Finally
            tmr303030.Enabled = True

        End Try
    End Sub
#End Region
#Region "　在庫ｴﾘｱｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞ      ｲﾍﾞﾝﾄ     "
    Private Sub cboFTRK_BUF_NO_ZAIKO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFTRK_BUF_NO_ZAIKO.SelectedIndexChanged
        Try

            If mFlag_Form_Load = False Then

                '検索条件初期化
                cboFHINMEI_CD.Text = ""
                dtpFrom.userChecked = False
                dtpTo.userChecked = False
                cboXPROD_LINE.SelectedIndex = 0
                cboXKENSA_KUBUN.SelectedIndex = 0
                cboFHORYU_KUBUN.SelectedIndex = 0
                cboXARTICLE_TYPE_CODE.SelectedIndex = 0

            End If

        Catch ex As Exception
            ComError(ex)

        End Try

    End Sub
#End Region
#Region "　ﾌｫｰﾑｱｸﾃｨﾌﾞ                               "
    '*******************************************************************************************************************
    '【機能】ﾌｫｰﾑｱｸﾃｨﾌﾞ時ｲﾍﾞﾝﾄ
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub FRM_303030_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
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
        '入庫ST ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
        '===================================

        Call gobjComFuncFRM.cboSetup(Me.Name, cboFTRK_BUF_NO_NYUUKO, False, -1)

        lblSTMode.Text = ""                          '入庫ST・状態
        lblSTMode.BackColor = gcModeColor_Black

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
        ' 期間初期化
        '===================================
        'Dim dtmNow As Date = Now            '現在日時
        'dtpFARRIVE_DT.cmpMDateTimePicker_D.Value = dtmNow
        dtpFrom.userChecked = False
        dtpTo.userChecked = False


        '===================================
        '生産ﾗｲﾝNo.ｺﾝﾎﾞﾎﾞｯｸｽ  ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboMsterSetup("XMST_PROD_LINE", "XPROD_LINE", "XPROD_LINE", "XPROD_LINE_NAME", cboXPROD_LINE, True, 0)
        'Call gobjComFuncFRM.cboMsterSetup("XMST_PROD_LINE", "XPROD_LINE", "XPROD_LINE_NAME", "XPROD_LINE", cboXPROD_LINE, True, 0)

        '===================================
        '検索区分 ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboXKENSA_KUBUN, True, -1)

        '===================================
        '保留区分 ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboFHORYU_KUBUN, True, -1)

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
        Call tmr303030_TickProcess()

        '**********************************************************
        ' ﾀｲﾏｰ設定
        '**********************************************************
        tmr303030.Interval = TO_INTEGER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_JGS303030_001))
        tmr303030.Enabled = True


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
        cboFTRK_BUF_NO_NYUUKO.Dispose()           '入庫ST
        lblSTMode.Dispose()
        cboFHINMEI_CD.Dispose()
        lblFHINMEI.Dispose()
        cboXPROD_LINE.Dispose()
        cboXKENSA_KUBUN.Dispose()
        cboFHORYU_KUBUN.Dispose()

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
        Call grdListDisplaySub(grdList)

    End Sub
#End Region
#Region "  F4(倉替入庫設定)  ﾎﾞﾀﾝ押下処理           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F4(倉替入庫設定) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F4Process()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.KurakaeNyuuko_Click) = False Then
            Exit Sub
        End If

        '************************************
        ' ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        '************************************
        If IsNull(gobjFRM_303031) = False Then
            gobjFRM_303031.Close()
            gobjFRM_303031.Dispose()
            gobjFRM_303031 = Nothing
        End If

        gobjFRM_303031 = New FRM_303031

        Call SetProperty()      'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ

        Dim intRet As DialogResult
        intRet = gobjFRM_303031.ShowDialog()            '展開

        If intRet = Windows.Forms.DialogResult.Cancel Then
            '(ｷｬﾝｾﾙ時)
            Exit Sub
        End If

        '*********************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '*********************************************
        Call grdListDisplaySub(grdList)

    End Sub
#End Region

    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:S.Ouchi 2013/10/18 設定済ﾃﾞｰﾀ表示
#Region "  F5(設定済ﾃﾞｰﾀ表示) ﾎﾞﾀﾝ押下処理          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F5(設定済ﾃﾞｰﾀ表示)   ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F5Process()

        '*******************************************************
        '入力ﾁｪｯｸ
        '*******************************************************
        '========================================
        '入庫ST
        '========================================
        If cboFTRK_BUF_NO_NYUUKO.Text = "" Then
            '(選択なしの場合)
            Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FTRK_BUF_NO_NYUUKO, _
                            PopupFormType.Ok, _
                            PopupIconType.Information)
            Exit Sub
        End If

        '************************************
        ' ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        '************************************
        If IsNull(gobjFRM_303032) = False Then
            gobjFRM_303032.Close()
            gobjFRM_303032.Dispose()
            gobjFRM_303032 = Nothing
        End If

        gobjFRM_303032 = New FRM_303032

        Call SetProperty3()      'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ

        Dim intRet As DialogResult
        intRet = gobjFRM_303032.ShowDialog()            '展開

        If intRet = Windows.Forms.DialogResult.Cancel Then
            '(ｷｬﾝｾﾙ時)
            Exit Sub
        End If

    End Sub
#End Region
    'JobMate:S.Ouchi 2013/10/18 設定済ﾃﾞｰﾀ表示
    '↑↑↑↑↑↑************************************************************************************************************

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
        mudtSEARCH_ITEM.STOCK_AREA = TO_STRING(cboFTRK_BUF_NO_ZAIKO.SelectedValue.ToString)

        '===============================================
        '品名ｺｰﾄﾞ
        '===============================================
        mudtSEARCH_ITEM.HINMEI_CD = TO_STRING(cboFHINMEI_CD.Text)

        '===============================================
        '入庫日(FROM)
        '===============================================
        If dtpFrom.userDispChecked = True Then
            mudtSEARCH_ITEM.ARRIVE_DT_FROM = Format(TO_DATE(dtpFrom.userDateTimeText), "yyyy/MM/dd HH:mm:ss")    '期間FROM
        Else
            mudtSEARCH_ITEM.ARRIVE_DT_FROM = ""
        End If

        '===============================================
        '入庫日(TO)
        '===============================================
        If dtpTo.userDispChecked = True Then
            mudtSEARCH_ITEM.ARRIVE_DT_TO = Format(TO_DATE(dtpTo.userDateTimeText), "yyyy/MM/dd HH:mm:ss")        '期間TO
        Else
            mudtSEARCH_ITEM.ARRIVE_DT_TO = ""
        End If

        '===============================================
        '生産ﾗｲﾝNo.
        '===============================================
        mudtSEARCH_ITEM.PROD_LINE = TO_STRING(cboXPROD_LINE.SelectedValue.ToString)

        '===============================================
        '検査区分
        '===============================================
        mudtSEARCH_ITEM.KENSA_KUBUN = TO_STRING(cboXKENSA_KUBUN.SelectedValue.ToString)

        '===============================================
        '保留区分
        '===============================================
        mudtSEARCH_ITEM.HORYU_KUBUN = TO_STRING(cboFHORYU_KUBUN.SelectedValue.ToString)

        '===============================================
        '商品区分
        '===============================================
        mudtSEARCH_ITEM.XARTICLE_TYPE_CODE = TO_STRING(cboXARTICLE_TYPE_CODE.SelectedValue.ToString)

    End Sub
#End Region
#Region "  倉替設定画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ　               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 倉替設定画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SetProperty()

        '===============================
        ' 在庫発生日時順にﾊﾟﾚｯﾄIDを取得
        '===============================
        'Dim udtSORT_ITEM As SORT_ITEM

        Dim strFPALLET_ID() As String = Nothing
        Dim dtmFARRIVE_DT() As Date

        ReDim strFPALLET_ID(0)
        ReDim dtmFARRIVE_DT(0)

        Dim i As Integer
        Dim j As Integer
        j = 0

        For i = 0 To grdList.Rows.Count - 1
            '(上から順に捜索)
            If grdList.Rows(i).Selected = True Then
                ReDim Preserve strFPALLET_ID(j)
                ReDim Preserve dtmFARRIVE_DT(j)

                strFPALLET_ID(j) = TO_STRING(grdList.Item(menmListCol.PALLET_ID, i).Value)
                dtmFARRIVE_DT(j) = TO_DATE(grdList.Item(menmListCol.ARRIVE_DT, i).Value)

                j = j + 1
            End If

        Next

        gobjFRM_303031.userFPALLET_ID = strFPALLET_ID                                                                                           'ﾊﾟﾚｯﾄID

        gobjFRM_303031.userFTRK_BUF_NO = TO_STRING(cboFTRK_BUF_NO_NYUUKO.SelectedValue.ToString)                                                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
        gobjFRM_303031.userFTRK_BUF_NO_Disp = TO_STRING(cboFTRK_BUF_NO_NYUUKO.Text)                                                             '入庫ST
        gobjFRM_303031.userFHINMEI_CD = TO_STRING(grdList.Item(menmListCol.FHINMEI_CD, grdList.SelectedRows(0).Index).Value)                    '品名記号
        gobjFRM_303031.userFHINMEI = TO_STRING(grdList.Item(menmListCol.HINMEI, grdList.SelectedRows(0).Index).Value)                           '品名

        '(検品ｴﾘｱか確認)
        Dim strZAIKO_AREA As String
        strZAIKO_AREA = TO_STRING(grdList.Item(menmListCol.TRK_BUF_NO, grdList.SelectedRows(0).Index).Value)                                    '在庫ｴﾘｱ ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
        If strZAIKO_AREA = FTRK_BUF_NO_J9200 Then                                                                                               '検品ｴﾘｱ ﾌﾗｸﾞ
            gobjFRM_303031.userXKENPIN_Flag = True
        Else
            gobjFRM_303031.userXKENPIN_Flag = False
        End If

        gobjFRM_303031.userXKENPIN_KUBUN = TO_STRING(grdList.Item(menmListCol.KENPIN_KUBUN, grdList.SelectedRows(0).Index).Value)               '検品区分
        'gobjFRM_303031.userXKENPIN_KUBUN_Disp = TO_STRING(grdList.Item(menmListCol.KENPIN_KUBUN_disp, grdList.SelectedRows(0).Index).Value)     '検品区分(表示用)

        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/06/27 入庫追加
        gobjFRM_303031.userFIN_KUBUN = TO_STRING(grdList.Item(menmListCol.IN_KUBUN, grdList.SelectedRows(0).Index).Value)                       '入庫区分
        '↑↑↑↑↑↑************************************************************************************************************

    End Sub

#End Region
    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:S.Ouchi 2013/10/17 設定済ﾃﾞｰﾀ表示
#Region "  設定済ﾃﾞｰﾀ表示画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ　         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 設定済ﾃﾞｰﾀ表示画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SetProperty3()

        '===================================
        ' 入庫ST情報ｾｯﾄ
        '===================================
        gobjFRM_303032.userFTRK_BUF_NO = TO_STRING(cboFTRK_BUF_NO_NYUUKO.SelectedValue.ToString)                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
        gobjFRM_303032.userFTRK_BUF_NO_Disp = TO_STRING(cboFTRK_BUF_NO_NYUUKO.Text)                             'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.(表示用)

    End Sub

#End Region
    'JobMate:S.Ouchi 2013/10/17 設定済ﾃﾞｰﾀ表示
    '↑↑↑↑↑↑************************************************************************************************************

#Region "　入力ﾁｪｯｸ　                               "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】 [ IN  ]　入力ﾁｪｯｸ判別
    '【戻値】 True :入力ﾁｪｯｸ成功
    '         False:入力ﾁｪｯｸ失敗
    '*******************************************************************************************************************
    Private Function InputCheck(ByVal udtCheck_Case As menmCheckCase) As Boolean

        'Dim intRet As RetCode                   '戻り値

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        Select Case udtCheck_Case
            Case menmCheckCase.SearchBtn_Click
                '(検索ﾎﾞﾀﾝｸﾘｯｸ時)

                blnCheckErr = False

            Case menmCheckCase.KurakaeNyuuko_Click
                '(倉替入庫設定ﾎﾞﾀﾝｸﾘｯｸ時)


                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:Dou 2014/07/02 入庫設定のﾊﾟﾚｯﾄ数の制限

                '========================================
                'PL数ﾁｪｯｸ
                '========================================
                Dim intLimit As Integer = 40
                If intLimit < grdList.SelectedRows.Count Then
                    '(上限を超えていた場合)
                    Dim strMsg As String
                    strMsg = Replace(FRM_MSG_FRM303030_01, "@@", TO_STRING(intLimit))
                    Call gobjComFuncFRM.DisplayPopup(strMsg, _
                                                     PopupFormType.Ok, _
                                                     PopupIconType.Information)
                    Exit Select
                End If

                '↑↑↑↑↑↑************************************************************************************************************


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
                '入庫STﾁｪｯｸ
                '==========================
                If cboFTRK_BUF_NO_NYUUKO.Text = "" Then
                    '(選択なしの場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FTRK_BUF_NO_NYUUKO, _
                                    PopupFormType.Ok, _
                                    PopupIconType.Information)
                    Exit Select

                End If

                '==============================
                '在庫ｴﾘｱ 品名ｺｰﾄﾞ ﾛｯﾄ 生産ﾗｲﾝNo. ﾁｪｯｸ
                '==============================
                If grdList.SelectedRows.Count > 1 Then
                    '(複数選択されている場合)

                    Dim strFTRK_BUF_NO_check As String
                    Dim strFHINMEI_CD_check As String
                    Dim strFLOT_NO_check As String
                    Dim strXPROD_LINE_check As String

                    strFTRK_BUF_NO_check = TO_STRING(grdList.Item(menmListCol.TRK_BUF_NO, grdList.SelectedRows(0).Index).Value)
                    strFHINMEI_CD_check = TO_STRING(grdList.Item(menmListCol.FHINMEI_CD, grdList.SelectedRows(0).Index).Value)
                    strFLOT_NO_check = TO_STRING(grdList.Item(menmListCol.LOT_NO, grdList.SelectedRows(0).Index).Value)
                    strXPROD_LINE_check = TO_STRING(grdList.Item(menmListCol.PROD_LINE, grdList.SelectedRows(0).Index).Value)

                    Dim i As Integer
                    For i = 1 To grdList.SelectedRows.Count - 1

                        If strFTRK_BUF_NO_check <> TO_STRING(grdList.Item(menmListCol.TRK_BUF_NO, grdList.SelectedRows(i).Index).Value) Then
                            '(一致しない場合)
                            Call gobjComFuncFRM.DisplayPopup("選択されたデータに異なる在庫ｴﾘｱが含まれているため、一括設定できません。", _
                                            PopupFormType.Ok, _
                                            PopupIconType.Information)
                            Exit Select

                        End If

                        If strFHINMEI_CD_check <> TO_STRING(grdList.Item(menmListCol.FHINMEI_CD, grdList.SelectedRows(i).Index).Value) Then
                            '(一致しない場合)
                            Call gobjComFuncFRM.DisplayPopup("選択されたデータに異なる品名ｺｰﾄﾞが含まれているため、一括設定できません。", _
                                            PopupFormType.Ok, _
                                            PopupIconType.Information)
                            Exit Select

                        End If

                        If strFLOT_NO_check <> TO_STRING(grdList.Item(menmListCol.LOT_NO, grdList.SelectedRows(i).Index).Value) Then
                            '(一致しない場合)
                            Call gobjComFuncFRM.DisplayPopup("選択されたデータに異なるﾛｯﾄNo.が含まれているため、一括設定できません。", _
                                            PopupFormType.Ok, _
                                            PopupIconType.Information)
                            Exit Select

                        End If

                        If strXPROD_LINE_check <> TO_STRING(grdList.Item(menmListCol.PROD_LINE, grdList.SelectedRows(i).Index).Value) Then
                            '(一致しない場合)
                            Call gobjComFuncFRM.DisplayPopup("選択されたデータに異なる生産ﾗｲﾝNo.が含まれているため、一括設定できません。", _
                                            PopupFormType.Ok, _
                                            PopupIconType.Information)
                            Exit Select

                        End If

                    Next

                End If




                '' ''*********************************************
                '' ''ｸﾚｰﾝ状態ﾁｪｯｸ
                '' ''*********************************************
                '' ''Dim intRet As RetCode
                ' ''Dim strMsg As String = ""

                ' ''For ii As Integer = 0 To grdList.SelectedRows.Count - 1
                ' ''    '(ﾙｰﾌﾟ:選択された行数)
                ' ''    '↓↓↓↓↓↓************************************************************************************************************
                ' ''    'SystemMate:A.Noto 2012/05/23  出庫ﾄﾗｯｷﾝｸﾞの禁止設定ﾁｪｯｸ(標準化※削除しないこと)
                ' ''    Dim strFPALLET_ID As String = TO_STRING(grdList.Item(menmListCol.PALLET_ID, grdList.SelectedRows(ii).Index).Value)
                ' ''    '↓↓↓↓↓　2012/10/22 H.Morita 下記、在庫引当ｸﾗｽ(SVR_100202)を使用するので、無効とした。
                ' ''    'If gobjComFuncFRM.CheckOutTrkBufNo(strFPALLET_ID) = False Then
                ' ''    '    blnCheckErr = True
                ' ''    '    Exit Select
                ' ''    'End If
                ' ''    '↑↑↑↑↑  2012/10/22 H.Morita 下記、在庫引当ｸﾗｽ(SVR_100202)を使用するので、無効とした。
                ' ''    '↑↑↑↑↑↑************************************************************************************************************

                ' ''    '**********************************
                ' ''    '在庫引当
                ' ''    '**********************************
                ' ''    Dim decReqNum As Decimal = 0
                ' ''    Dim objSVR_100202 As New SVR_100202(Owner, gobjDb, Nothing)     '在庫引当ｸﾗｽ
                ' ''    objSVR_100202.FTRK_BUF_NO = FTRK_BUF_NO_J9000                   'ﾊﾞｯﾌｧ№(自動倉庫)
                ' ''    objSVR_100202.INTMaxPlt = KOTEI_MAX_PLT                         '最大引当ﾊﾟﾚｯﾄ数
                ' ''    objSVR_100202.INTUpdateMode = SVR_100202.UpdateMode.NON_UPDATE  '更新ﾓｰﾄﾞ(更新なし)
                ' ''    objSVR_100202.FPALLET_ID = strFPALLET_ID                        'ﾊﾟﾚｯﾄID
                ' ''    objSVR_100202.FBUF_TO = TO_STRING(cboFTRK_BUF_NO.SelectedValue) '搬送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                ' ''    intRet = objSVR_100202.FIND_STOCK(decReqNum)                    '在庫引当
                ' ''    If intRet <> RetCode.OK Then
                ' ''        '(在庫引当ができない時)
                ' ''        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303020_07, PopupFormType.Ok, PopupIconType.Information)
                ' ''        blnCheckErr = True
                ' ''        Exit Select
                ' ''    End If

                ' ''Next

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

#Region "　ｸﾞﾘｯﾄﾞ表示　                             "
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
        strSQL &= vbCrLf & "       TPRG_TRK_BUF.FTRK_BUF_NO "                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ      .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
        strSQL &= vbCrLf & "     , TMST_TRK.FBUF_NAME  "                         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ   .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称
        strSQL &= vbCrLf & "     , TMST_ITEM.XHINMEI_CD "                        '在庫情報          .品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "     , TRST_STOCK.FHINMEI_CD "                       '在庫情報          .品名記号
        strSQL &= vbCrLf & "     , TMST_ITEM.FHINMEI "                           '品目ﾏｽﾀ           .品名
        strSQL &= vbCrLf & "     , TRST_STOCK.XPROD_LINE "                       '在庫情報          .生産ﾗｲﾝNo.
        strSQL &= vbCrLf & "     , TRST_STOCK.FTR_VOL "                          '在庫情報          .数量(搬送管理量)
        strSQL &= vbCrLf & "     , TRST_STOCK.FARRIVE_DT "                       '在庫情報          .入庫日(在庫発生日時)
        strSQL &= vbCrLf & "     , TRST_STOCK.XKENSA_KUBUN "                     '在庫情報          .検査区分
        strSQL &= vbCrLf & "     , HASH01.FGAMEN_DISP AS XKENSA_KUBUN_DSP "      '在庫情報          .検査区分(表示用)
        strSQL &= vbCrLf & "     , TRST_STOCK.FHORYU_KUBUN "                     '在庫情報          .保留区分
        strSQL &= vbCrLf & "     , HASH02.FGAMEN_DISP AS FHORYU_KUBUN_DSP "      '在庫情報          .保留区分(表示用)
        strSQL &= vbCrLf & "     , TRST_STOCK.XKENPIN_KUBUN "                    '在庫情報          .検品区分
        strSQL &= vbCrLf & "     , HASH03.FGAMEN_DISP AS XKENPIN_KUBUN_DSP "     '在庫情報          .検品区分(表示用)
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/06/06 商品区分追加
        strSQL &= vbCrLf & "     , TMST_ITEM.XARTICLE_TYPE_CODE "                '在庫情報       .商品区分
        strSQL &= vbCrLf & "     , HASH04.FGAMEN_DISP AS XARTICLE_TYPE_CODE_DSP "     '在庫情報       .商品区分(表示用)
        '↑↑↑↑↑↑************************************************************************************************************
        strSQL &= vbCrLf & "     , TRST_STOCK.FLOT_NO "                          '在庫情報          .ﾛｯﾄNo.
        strSQL &= vbCrLf & "     , TRST_STOCK.FPALLET_ID "                       '在庫情報          .ﾊﾟﾚｯﾄID
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/06/27 入庫追加
        strSQL &= vbCrLf & "     , TRST_STOCK.FIN_KUBUN "                        '在庫情報          .入庫区分
        '↑↑↑↑↑↑************************************************************************************************************

        ' ''strSQL &= vbCrLf & "     , TPRG_TRK_BUF.FDISP_ADDRESS "                  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .表記用ｱﾄﾞﾚｽ(ﾛｹｰｼｮﾝ)
        ' ''strSQL &= vbCrLf & "     , TPRG_TRK_BUF.XTANA_BLOCK "                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .棚ﾌﾞﾛｯｸ
        ' ''strSQL &= vbCrLf & "     , TPRG_TRK_BUF.XTANA_BLOCK_DTL "                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .棚ﾌﾞﾛｯｸ詳細
        ' ''strSQL &= vbCrLf & "     , TPRG_TRK_BUF.FRAC_RETU "                      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .列
        ' ''strSQL &= vbCrLf & "     , TPRG_TRK_BUF.FRAC_REN "                       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .連
        ' ''strSQL &= vbCrLf & "     , TPRG_TRK_BUF.FRAC_DAN "                       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .段
        ' ''strSQL &= vbCrLf & "     , TPRG_TRK_BUF.FRAC_EDA "                       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .枝

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    TRST_STOCK "                    '【在庫情報】
        strSQL &= vbCrLf & "  , TMST_ITEM "                     '【品目ﾏｽﾀ】
        strSQL &= vbCrLf & "  , XMST_PROD_LINE "                '【生産ﾗｲﾝﾏｽﾀ】
        strSQL &= vbCrLf & "  , TPRG_TRK_BUF "                  '【ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ】
        strSQL &= vbCrLf & "  , TMST_TRK "                      '【ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ】
        strSQL &= vbCrLf & "     , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH01", "TRST_STOCK", "XKENSA_KUBUN")     '【検査区分(表示用)】
        strSQL &= vbCrLf & "     , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH02", "TRST_STOCK", "FHORYU_KUBUN")     '【保留区分(表示用)】
        strSQL &= vbCrLf & "     , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH03", "TRST_STOCK", "XKENPIN_KUBUN")    '【検品区分(表示用)】
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/06/06 商品区分追加
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
        'JobMate:H.Okumura 2013/06/06 商品区分追加
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH04", "TMST_ITEM", "XARTICLE_TYPE_CODE")
        '↑↑↑↑↑↑************************************************************************************************************

        '----------------------------
        '在庫ｴﾘｱﾁｪｯｸ
        '----------------------------
        If cboFTRK_BUF_NO_ZAIKO.Text <> "" Then
            strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FTRK_BUF_NO = " & TO_STRING(cboFTRK_BUF_NO_ZAIKO.SelectedValue) & " "
        Else
            strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FTRK_BUF_NO IN (" & FTRK_BUF_NO_J9100 & ", " & FTRK_BUF_NO_J9200 & " ) "
        End If

        '----------------------------
        '品名ｺｰﾄﾞ
        '----------------------------
        If mudtSEARCH_ITEM.HINMEI_CD <> "" Then
            If IsNumeric(mudtSEARCH_ITEM.HINMEI_CD.Substring(0, 1)) Then
                '(品名ｺｰﾄﾞ)
                strSQL &= vbCrLf & "    AND TMST_ITEM.XHINMEI_CD LIKE '" & mudtSEARCH_ITEM.HINMEI_CD & "' "
            Else
                '(品名記号)
                strSQL &= vbCrLf & "    AND TRST_STOCK.FHINMEI_CD LIKE '" & mudtSEARCH_ITEM.HINMEI_CD & "' "
            End If

        End If

        '----------------------------
        '入庫日
        '----------------------------
        If mudtSEARCH_ITEM.ARRIVE_DT_FROM <> "" Then
            strSQL &= vbCrLf & "    AND TRST_STOCK.FARRIVE_DT >= TO_DATE('" & mudtSEARCH_ITEM.ARRIVE_DT_FROM & "','YYYY/MM/DD HH24:MI:SS')"
        End If
        If mudtSEARCH_ITEM.ARRIVE_DT_TO <> "" Then
            strSQL &= vbCrLf & "    AND TRST_STOCK.FARRIVE_DT <= TO_DATE('" & mudtSEARCH_ITEM.ARRIVE_DT_TO & "','YYYY/MM/DD HH24:MI:SS')"
        End If

        '----------------------------
        '生産ﾗｲﾝNo.
        '----------------------------
        If mudtSEARCH_ITEM.PROD_LINE <> "" Then
            strSQL &= vbCrLf & "    AND TRST_STOCK.XPROD_LINE = '" & mudtSEARCH_ITEM.PROD_LINE & "' "
        End If

        '----------------------------
        '検査区分
        '----------------------------
        If mudtSEARCH_ITEM.KENSA_KUBUN <> "" Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "    AND TRST_STOCK.XKENSA_KUBUN = " & mudtSEARCH_ITEM.KENSA_KUBUN
        End If

        '----------------------------
        '保留区分
        '----------------------------
        If mudtSEARCH_ITEM.HORYU_KUBUN <> "" Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "    AND TRST_STOCK.FHORYU_KUBUN = " & mudtSEARCH_ITEM.HORYU_KUBUN
        End If

        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/06/06 商品区分追加
        '----------------------------
        '商品区分
        '----------------------------
        If mudtSEARCH_ITEM.XARTICLE_TYPE_CODE <> "" Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "    AND TMST_ITEM.XARTICLE_TYPE_CODE = " & mudtSEARCH_ITEM.XARTICLE_TYPE_CODE
        End If
        '↑↑↑↑↑↑************************************************************************************************************

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

#Region "  ﾓｰﾄﾞ取得ﾀｲﾏｰ処理                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 設備状態取得ﾀｲﾏｰ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tmr303030_TickProcess()

        '**********************************************************
        ' ﾗﾍﾞﾙ背景色変更処理
        '**********************************************************
        Call gobjComFuncFRM.AlterLabelColorMOD_TIBA(lblSTMode, TO_STRING(cboFTRK_BUF_NO_NYUUKO.SelectedValue), LBL_DSPTYPE.STSNAME)

    End Sub
#End Region

End Class
