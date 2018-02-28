'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】棚卸し出庫設定画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_305010

#Region "　共通変数　                               "

    Private mFlag_Form_Load As Boolean = True                   '画面展開ﾌﾗｸﾞ

    Private mFlag_PRINT_ZUMI As Boolean = False                 '印刷済みﾌﾗｸﾞ

    Private mudtSEARCH_ITEM As New stcSEARCH_ITEM               '検索条件用構造体

    '作業実施のﾊﾞｯﾌｬ№、ﾊﾞｯﾌｬ配列№、ﾊﾟﾚｯﾄIDの配列
    Public mstrFTRK_BUF_NO() As String = Nothing
    Public mstrFTRK_BUF_ARRAY() As String = Nothing
    Public mstrFPALLET_ID() As String = Nothing


    ''' <summary>ｸﾞﾘｯﾄﾞ項目</summary>
    Enum menmListCol
        FPALLET_ID                  '在庫情報       .ﾊﾟﾚｯﾄID
        FTRK_BUF_NO                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        FTRK_BUF_ARRAY              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
        FBUF_BUF_NO_NM              'ﾄﾗｯｷﾝｸﾞﾏｽﾀ     .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称
        FDISP_ADDRESS               'ﾄﾗｯｷﾝﾊﾞｯﾌｬ     .表記用ｱﾄﾞﾚｽ(ﾛｹｰｼｮﾝ)
        FHINMEI_CD                  '在庫情報       .品名ｺｰﾄﾞ
        FHINMEI                     '品目ﾏｽﾀ        .品名
        XSEIZOU_DT                  '在庫情報       .製造年月日
        XLINE_NO                    '在庫情報       .ﾗｲﾝ№
        XSYUKKA_KAHI                '在庫情報       .出荷可否
        XSYUKKA_KAHI_DSP            '在庫情報       .出荷可否(表示用)
        XHINSHITU_STS               '在庫情報       .品質ｽﾃｰﾀｽ
        XHINSHITU_STS_DSP           '在庫情報       .品質ｽﾃｰﾀｽ(表示用)
        FHORYU_KUBUN                '在庫情報       .保留区分
        FHORYU_KUBUN_DSP            '在庫情報       .保留区分(表示用)
        FTR_VOL                     '在庫情報       .搬送管理量(積込数)
        XPALLET_NO                  '在庫情報       .ﾊﾟﾚｯﾄ№

        MAXCOL                      'ｸﾞﾘｯﾄﾞの列数の最大値

    End Enum


    ''' <summary>入力ﾁｪｯｸ場合判別</summary>
    Enum menmCheckCase
        BEFORE_Check_Click  '事前ﾁｪｯｸ
        KAKUNIN_Click       '確認ﾎﾞﾀﾝｸﾘｯｸ
        SAGYO_START_Click   '作業開始ﾎﾞﾀﾝｸﾘｯｸ
        PRINT_Click         '印刷ﾎﾞﾀﾝｸﾘｯｸ時
    End Enum

#End Region
#Region "  構造体定義　                             "

    ''' <summary>検索条件</summary>
    Private Structure stcSEARCH_ITEM
        '*品名指定
        Dim FHINMEI_CD As String        '品名ｺｰﾄﾞ
        Dim XSEIZOU_DT As String        '製造年月日
        Dim XLINE_NO As String          'ﾗｲﾝ№
        Dim XPALLET_NO_FM As String     'ﾊﾟﾚｯﾄ№ FROM
        Dim XPALLET_NO_TO As String     'ﾊﾟﾚｯﾄ№ TO
        '*棚範囲指定
        Dim FRAC_RETU_FM As String      '列 FROM
        Dim FRAC_REN_FM As String       '連 FROM
        Dim FRAC_DAN_FM As String       '段 FROM
        Dim FRAC_RETU_TO As String      '列 TO
        Dim FRAC_REN_TO As String       '連 TO
        Dim FRAC_DAN_TO As String       '段 TO
    End Structure

#End Region
#Region "　ｲﾍﾞﾝﾄ　                                  "
#Region "　品名ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞ       ｲﾍﾞﾝﾄ   "
    'Private Sub cboFHINMEI_CD_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFHINMEI_CD.SelectedIndexChanged
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 品名ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cboFHINMEI_CD_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFHINMEI_CD.LostFocus
        Try

            If mFlag_Form_Load = False Then

                '===================================
                '出庫問合せ ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
                '===================================
                Call MakeToiawaseSyukko_cboXSEIZOU_DT(cboFHINMEI_CD.Text, cboXSEIZOU_DT, TO_STRING(FTRK_BUF_NO_J9000), True)         '製造年月日

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
#Region "　品名ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽﾌｫｰｶｽｲﾍﾞﾝﾄ              "
    Private Sub cboFHINMEI_CD_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFHINMEI_CD.GotFocus
        Try
            chkHINMEI.Checked = True
            chkTANA.Checked = False
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　製造年月日ｺﾝﾎﾞﾎﾞｯｸｽﾌｫｰｶｽｲﾍﾞﾝﾄ            "
    Private Sub cboXSEIZOU_DT_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboXSEIZOU_DT.GotFocus
        Try
            chkHINMEI.Checked = True
            chkTANA.Checked = False
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　ﾗｲﾝ№ ﾃｷｽﾄﾎﾞｯｸｽﾌｫｰｶｽｲﾍﾞﾝﾄ                "
    Private Sub txtXLINE_NO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtXLINE_NO.GotFocus
        Try
            chkHINMEI.Checked = True
            chkTANA.Checked = False
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　ﾊﾟﾚｯﾄ№ FROM ﾃｷｽﾄﾎﾞｯｸｽﾌｫｰｶｽｲﾍﾞﾝﾄ         "
    Private Sub txtXPALLET_FM_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtXPALLET_NO_FM.GotFocus
        Try
            chkHINMEI.Checked = True
            chkTANA.Checked = False
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　ﾊﾟﾚｯﾄ№ TO ﾃｷｽﾄﾎﾞｯｸｽﾌｫｰｶｽｲﾍﾞﾝﾄ           "
    Private Sub txtXPALLET_TO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtXPALLET_NO_TO.GotFocus
        Try
            chkHINMEI.Checked = True
            chkTANA.Checked = False
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　列 FROM ﾃｷｽﾄﾎﾞｯｸｽﾌｫｰｶｽｲﾍﾞﾝﾄ              "
    Private Sub txtRETU_FM_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFRAC_RETU_FM.GotFocus
        Try
            chkHINMEI.Checked = False
            chkTANA.Checked = True
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　連 FROM ﾃｷｽﾄﾎﾞｯｸｽﾌｫｰｶｽｲﾍﾞﾝﾄ              "
    Private Sub txtREN_FM_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFRAC_REN_FM.GotFocus
        Try
            chkHINMEI.Checked = False
            chkTANA.Checked = True
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　段 FROM ﾃｷｽﾄﾎﾞｯｸｽﾌｫｰｶｽｲﾍﾞﾝﾄ              "
    Private Sub txtDAN_FM_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFRAC_DAN_FM.GotFocus
        Try
            chkHINMEI.Checked = False
            chkTANA.Checked = True
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　列 TO ﾃｷｽﾄﾎﾞｯｸｽﾌｫｰｶｽｲﾍﾞﾝﾄ                "
    Private Sub txtRETU_TO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFRAC_RETU_TO.GotFocus
        Try
            chkHINMEI.Checked = False
            chkTANA.Checked = True
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　連 TO ﾃｷｽﾄﾎﾞｯｸｽﾌｫｰｶｽｲﾍﾞﾝﾄ                "
    Private Sub txtREN_TO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFRAC_REN_TO.GotFocus
        Try
            chkHINMEI.Checked = False
            chkTANA.Checked = True
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　段 TO ﾃｷｽﾄﾎﾞｯｸｽﾌｫｰｶｽｲﾍﾞﾝﾄ                "
    Private Sub txtDAN_TO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFRAC_DAN_TO.GotFocus
        Try
            chkHINMEI.Checked = False
            chkTANA.Checked = True
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
    '↓↓↓↓ 2012.12.19 14:30 H.Morita 棚範囲指定 TO値 自動設定 対応 
#Region "　列 FROM ﾃｷｽﾄﾎﾞｯｸｽﾛｽﾄﾌｫｰｶｽｲﾍﾞﾝﾄ           "
    Private Sub txtRETU_FM_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFRAC_RETU_FM.LostFocus
        Try
            If (txtFRAC_RETU_FM.Text <> "") And _
               (txtFRAC_REN_FM.Text <> "") And _
               (txtFRAC_DAN_FM.Text <> "") Then
                '(FROMの棚番号が全て入力されている時)
                If (txtFRAC_RETU_TO.Text = "") And _
                   (txtFRAC_REN_TO.Text = "") And _
                   (txtFRAC_DAN_TO.Text = "") Then
                    '(TOの棚番号が全て入力されていない時)
                    txtFRAC_RETU_TO.Text = txtFRAC_RETU_FM.Text
                    txtFRAC_REN_TO.Text = txtFRAC_REN_FM.Text
                    txtFRAC_DAN_TO.Text = txtFRAC_DAN_FM.Text
                End If
            End If
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　連 FROM ﾃｷｽﾄﾎﾞｯｸｽﾛｽﾄﾌｫｰｶｽｲﾍﾞﾝﾄ           "
    Private Sub txtREN_FM_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFRAC_REN_FM.LostFocus
        Try
            If (txtFRAC_RETU_FM.Text <> "") And _
               (txtFRAC_REN_FM.Text <> "") And _
               (txtFRAC_DAN_FM.Text <> "") Then
                '(FROMの棚番号が全て入力されている時)
                If (txtFRAC_RETU_TO.Text = "") And _
                   (txtFRAC_REN_TO.Text = "") And _
                   (txtFRAC_DAN_TO.Text = "") Then
                    '(TOの棚番号が全て入力されていない時)
                    txtFRAC_RETU_TO.Text = txtFRAC_RETU_FM.Text
                    txtFRAC_REN_TO.Text = txtFRAC_REN_FM.Text
                    txtFRAC_DAN_TO.Text = txtFRAC_DAN_FM.Text
                End If
            End If
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　段 FROM ﾃｷｽﾄﾎﾞｯｸｽﾛｽﾄﾌｫｰｶｽｲﾍﾞﾝﾄ           "
    Private Sub txtDAN_FM_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFRAC_DAN_FM.LostFocus
        Try
            If (txtFRAC_RETU_FM.Text <> "") And _
               (txtFRAC_REN_FM.Text <> "") And _
               (txtFRAC_DAN_FM.Text <> "") Then
                '(FROMの棚番号が全て入力されている時)
                If (txtFRAC_RETU_TO.Text = "") And _
                   (txtFRAC_REN_TO.Text = "") And _
                   (txtFRAC_DAN_TO.Text = "") Then
                    '(TOの棚番号が全て入力されていない時)
                    txtFRAC_RETU_TO.Text = txtFRAC_RETU_FM.Text
                    txtFRAC_REN_TO.Text = txtFRAC_REN_FM.Text
                    txtFRAC_DAN_TO.Text = txtFRAC_DAN_FM.Text
                End If
            End If
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
    '↑↑↑↑ 2012.12.19 14:30 H.Morita 棚範囲指定 TO値 自動設定 対応 

#Region "　品名指定 ﾁｪｯｸﾎﾞｯｸｽﾁｪｯｸﾁｬﾝｼﾞｲﾍﾞﾝﾄ         "
    Private Sub chkHINMEI_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkHINMEI.CheckedChanged
        Try
            If chkHINMEI.Checked = True Then
                '(品名指定の時)
                chkHINMEI.Checked = True
                chkTANA.Checked = False
            Else
                '(棚指定の時)
                chkHINMEI.Checked = False
                chkTANA.Checked = True
            End If
        Catch ex As Exception
            ComError(ex)
        End Try
    End Sub
#End Region
#Region "　棚指定 ﾁｪｯｸﾎﾞｯｸｽﾁｪｯｸﾁｬﾝｼﾞｲﾍﾞﾝﾄ           "
    Private Sub chkTANA_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkTANA.CheckedChanged
        Try
            If chkTANA.Checked = True Then
                '(品名指定の時)
                chkHINMEI.Checked = False
                chkTANA.Checked = True
            Else
                '(棚指定の時)
                chkHINMEI.Checked = True
                chkTANA.Checked = False
            End If
        Catch ex As Exception
            ComError(ex)
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


        '**********************************************************
        ' ｺﾝﾄﾛｰﾙ初期化
        '**********************************************************
        '===================================
        '棚卸しST
        '===================================
        Call gobjComFuncFRM.cboSetup(Me.Name, cboFTRK_BUF_NO, False)

        '===================================
        '出庫問合せ ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
        '===================================
        cboFHINMEI_CD.conn = gobjDb
        cboFHINMEI_CD.HinmeiLabel = lblFHINMEI
        cboFHINMEI_CD.Text = ""
        cboFHINMEI_CD.TableName = "TRST_STOCK"
        cboFHINMEI_CD.ComboBoxType = GamenCommon.cmpCboFHINMEI_CD.HINMEI_CBO_TYPE.SpecifiedAndMasterData
        cboFHINMEI_CD.HinmeiVisible = False
        ReDim cboFHINMEI_CD.FTRK_BUF_NO(0)
        cboFHINMEI_CD.FTRK_BUF_NO(0) = FTRK_BUF_NO_J9000                                       '自動倉庫
        cboFHINMEI_CD.FRES_KIND = FRES_KIND_SZAIKO                                             '引当状態 = 「在庫棚」
        cboFHINMEI_CD.cboSetupHinmeiCd(cboFHINMEI_CD.Text)                                     '品名ｺｰﾄﾞ

        Call MakeToiawaseSyukko_cboXSEIZOU_DT(cboFHINMEI_CD.Text, cboXSEIZOU_DT, TO_STRING(FTRK_BUF_NO_J9000), True)         '製造年月日

        '*********************************************
        ' 画面初期表示
        '*********************************************
        Call Gamen_Display()

        '*********************************************
        ' ｸﾞﾘｯﾄﾞ初期化
        '*********************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListSetup()

        mFlag_Form_Load = False

        mFlag_PRINT_ZUMI = False                 '印刷済みﾌﾗｸﾞ

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
        cboFTRK_BUF_NO.Dispose()      '棚卸しST
        cboFHINMEI_CD.Dispose()       '品名ｺｰﾄﾞ
        cboXSEIZOU_DT.Dispose()       '製造年月日
        grdList.Dispose()             'ｸﾞﾘｯﾄﾞ
        txtXLINE_NO.Dispose()         'ﾗｲﾝ№
        txtXPALLET_NO_FM.Dispose()    'ﾊﾟﾚｯﾄ№ FROM
        txtXPALLET_NO_TO.Dispose()    'ﾊﾟﾚｯﾄ№ TO
        txtFRAC_RETU_FM.Dispose()          '列 FROM
        txtFRAC_REN_FM.Dispose()           '連 FROM
        txtFRAC_DAN_FM.Dispose()           '段 FROM
        txtFRAC_RETU_TO.Dispose()          '列 TO
        txtFRAC_REN_TO.Dispose()           '連 TO
        txtFRAC_DAN_TO.Dispose()           '段 TO

    End Sub
#End Region
#Region "  F1(確認)  ﾎﾞﾀﾝ押下処理　                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F1ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F1Process()


        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.KAKUNIN_Click) = False Then
            Exit Sub
        End If

        '******************************************
        ' 棚卸し作業指示展開
        '******************************************
        Dim strMsg As String = ""
        Dim strFPALLET_ID As String() = Nothing

        If gobjComFuncFRM.TANAOROSHI_STS(CBO_ALL_VALUE, strFPALLET_ID) = RetCode.OK Then
            '([ST180],[搬送中]を含み 作業中の時)
            '******************************************
            ' 搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№  ｾｯﾄ
            '******************************************
            gstrTR_TO = TO_STRING(cboFTRK_BUF_NO.SelectedValue)
            '******************************************
            ' 画面遷移
            '******************************************
            Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_305011, Me)
        Else
            '(作業無しの時)
            Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM305010_18, PopupFormType.Ok, PopupIconType.Information)
        End If


        '*********************************************
        ' 画面初期表示
        '*********************************************
        Call Gamen_Display()

        '*********************************************
        ' 構造体ｾｯﾄ
        '*********************************************
        Call SearchItem_Set()

        ''*********************************************
        '' ｸﾞﾘｯﾄﾞ表示
        ''*********************************************
        'Call grdListDisplaySub(grdList)


    End Sub
#End Region
#Region "  F4(印刷)         ﾎﾞﾀﾝ押下処理            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F4  ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F4Process()

        mFlag_PRINT_ZUMI = False                '印刷済みﾌﾗｸﾞ

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.BEFORE_Check_Click) = False Then
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

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.PRINT_Click) = False Then
            '(入力ｴﾗｰがある場合)
            Exit Sub
        End If

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udeRet As PopupFormType
        udeRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_PRINT_01, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udeRet <> PopupFormType.Ok Then
            Exit Sub
        End If

        '*******************************************************
        '印刷処理
        '*******************************************************
        Call PrintOutProcess()

        '*TODO* '*********************************************
        '' 画面初期表示
        ''*********************************************
        'Call Gamen_Display()

        ''*********************************************
        '' 構造体ｾｯﾄ
        ''*********************************************
        'Call SearchItem_Set()


        mFlag_PRINT_ZUMI = True                 '印刷済みﾌﾗｸﾞ


    End Sub
#End Region
#Region "  F7(作業開始)  ﾎﾞﾀﾝ押下処理　             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F7ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F7Process()

        'If mFlag_PRINT_ZUMI = False Then
        '(印刷未の時)
        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.BEFORE_Check_Click) = False Then
            '(入力ｴﾗｰがある場合)
            Exit Sub
        End If

        '*********************************************
        ' 構造体ｾｯﾄ
        '*********************************************
        Call SearchItem_Set()

        '**********************************************************
        ' ﾘｽﾄ表示
        '**********************************************************
        Call grdListDisplaySub(grdList)

        'Else
        '(印刷済みの時)
        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.SAGYO_START_Click) = False Then
            Exit Sub
        End If

        'End If


        '*********************************************
        ' 実施確認画面
        '*********************************************
        'ｵﾌﾞｼﾞｪｸﾄNothingﾁｪｯｸ
        If IsNull(gobjFRM_305012) = False Then
            gobjFRM_305012.Close()
            gobjFRM_305012.Dispose()
            gobjFRM_305012 = Nothing
        End If

        '********************************************************************
        ' 子画面展開
        '********************************************************************
        gobjFRM_305012 = New FRM_305012         'ｵﾌﾞｼﾞｪｸﾄ作成
        Call SetProperty(gobjFRM_305012)        'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ

        Dim intRet As DialogResult
        intRet = gobjFRM_305012.ShowDialog()    '画面表示
        If intRet = System.Windows.Forms.DialogResult.Cancel Then
            '(ｷｬﾝｾﾙ時)
            Exit Sub
        End If


        '******************************************
        ' 棚卸し作業指示展開
        '******************************************
        Dim strMsg As String = ""
        Dim strFPALLET_ID As String() = Nothing

        If gobjComFuncFRM.TANAOROSHI_STS(CBO_ALL_VALUE, strFPALLET_ID) = RetCode.OK Then
            '([ST180],[搬送中]を含めて作業中の時)
        Else
            '(作業無しの時)
            strMsg = "棚卸し作業が取得できませんでした。"
            Throw New UserException(strMsg)
        End If

        '******************************************
        ' 搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№  ｾｯﾄ
        '******************************************
        gstrTR_TO = TO_STRING(cboFTRK_BUF_NO.SelectedValue)

        '↓↓↓↓ 2012.12.06 10:25 H.Morita 棚卸しを複数品目同時作業する対応 画面移行しないようにする。
        ''******************************************
        '' 画面遷移
        ''******************************************
        'Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_305011, Me)
        '↑↑↑↑ 2012.12.06 10:25 H.Morita 棚卸しを複数品目同時作業する対応 画面移行しないようにする。


        '*********************************************
        ' 画面初期表示
        '*********************************************
        Call Gamen_Display()

        '*********************************************
        ' 構造体ｾｯﾄ
        '*********************************************
        Call SearchItem_Set()

    End Sub
#End Region
#Region "  F8  ﾎﾞﾀﾝ押下処理　                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F8ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F8Process()

        '******************************************
        ' 画面遷移
        '******************************************
        Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_205000, Me)

    End Sub
#End Region
#Region "　構造体ｾｯﾄ　                              "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 構造体ｾｯﾄ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SearchItem_Set()

        '***********************************************
        '検索条件をｾｯﾄ
        '***********************************************
        '*品名指定
        mudtSEARCH_ITEM.FHINMEI_CD = cboFHINMEI_CD.Text                         '品名ｺｰﾄﾞ
        mudtSEARCH_ITEM.XSEIZOU_DT = TO_STRING(cboXSEIZOU_DT.SelectedValue)     '製造年月日
        mudtSEARCH_ITEM.XLINE_NO = txtXLINE_NO.Text                             'ﾗｲﾝ№
        mudtSEARCH_ITEM.XPALLET_NO_FM = txtXPALLET_NO_FM.Text                   'ﾊﾟﾚｯﾄ№ FROM
        '↓↓↓ TO省略可能に 2012/12/06 10:30
        If txtXPALLET_NO_TO.Text = "" Then
            '(TOが省略された場合)
            mudtSEARCH_ITEM.XPALLET_NO_TO = txtXPALLET_NO_FM.Text               'ﾊﾟﾚｯﾄ№ TO
        Else
            '(TOに入力ありの時)
            mudtSEARCH_ITEM.XPALLET_NO_TO = txtXPALLET_NO_TO.Text               'ﾊﾟﾚｯﾄ№ TO
        End If
        '↑↑↑ TO省略可能に 2012/12/06 10:30

        '*棚範囲指定
        mudtSEARCH_ITEM.FRAC_RETU_FM = txtFRAC_RETU_FM.Text                          '列 FROM
        mudtSEARCH_ITEM.FRAC_REN_FM = txtFRAC_REN_FM.Text                            '連 FROM
        mudtSEARCH_ITEM.FRAC_DAN_FM = txtFRAC_DAN_FM.Text                            '段 FROM

        '↓↓↓ TO省略可能に 2012/11/12 18:20
        If (txtFRAC_RETU_TO.Text = "") And _
           (txtFRAC_REN_TO.Text = "") And _
           (txtFRAC_DAN_TO.Text = "") Then
            '(TOが省略されている場合)
            mudtSEARCH_ITEM.FRAC_RETU_TO = txtFRAC_RETU_FM.Text                          '列 TO
            mudtSEARCH_ITEM.FRAC_REN_TO = txtFRAC_REN_FM.Text                            '連 TO
            mudtSEARCH_ITEM.FRAC_DAN_TO = txtFRAC_DAN_FM.Text                            '段 TO
        Else
            '(TOの入力ある時)
            mudtSEARCH_ITEM.FRAC_RETU_TO = txtFRAC_RETU_TO.Text                          '列 TO
            mudtSEARCH_ITEM.FRAC_REN_TO = txtFRAC_REN_TO.Text                            '連 TO
            mudtSEARCH_ITEM.FRAC_DAN_TO = txtFRAC_DAN_TO.Text                            '段 TO
        End If
        '↑↑↑ TO省略可能に 2012/11/12 18:20

    End Sub
#End Region
#Region "　入力ﾁｪｯｸ　                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 入力ﾁｪｯｸ
    ''' </summary>
    ''' <param name="udtCheck_Case">[IN ]入力ﾁｪｯｸ判別</param>
    ''' <returns>True/False</returns>
    ''' <remarks>戻値 = True :入力ﾁｪｯｸ成功/False:入力ﾁｪｯｸ失敗</remarks>
    ''' *******************************************************************************************************************
    Private Function InputCheck(ByVal udtCheck_Case As menmCheckCase) As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        Dim intRet As RetCode

        Select Case udtCheck_Case
            Case menmCheckCase.KAKUNIN_Click
                '(確認ﾎﾞﾀﾝｸﾘｯｸ時)

                blnCheckErr = False

            Case menmCheckCase.SAGYO_START_Click
                '(作業開始ﾎﾞﾀﾝｸﾘｯｸ時)

                ''==========================
                ''ﾘｽﾄ出力ﾁｪｯｸ
                ''==========================
                'If mFlag_PRINT_ZUMI = False Then
                '    '(ﾘｽﾄ出力されていない場合)
                '    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM305010_15, PopupFormType.Ok, PopupIconType.Information)
                '    blnCheckErr = True
                '    Exit Select
                'End If

                '==========================
                'ﾘｽﾄ　表示ﾃﾞｰﾀﾁｪｯｸ
                '==========================
                If grdList.Rows.Count < 1 Then
                    '(ﾃﾞｰﾀが一行もない場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM305010_14, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If

                '==========================
                '計画ﾁｪｯｸ
                '==========================
                'Dim objTBL_XPLN_TANA_CHK As New TBL_XPLN_TANA(gobjOwner, gobjDb, Nothing)
                'objTBL_XPLN_TANA_CHK.FTERM_ID = gcstrFTERM_ID
                'objTBL_XPLN_TANA_CHK.XPROGRESS_TANA = XPROGRESS_TANA_JACT
                'If objTBL_XPLN_TANA_CHK.GET_XPLN_TANA(False) = RetCode.OK Then
                '    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM305010_16, PopupFormType.Ok, PopupIconType.Information)
                '    blnCheckErr = True
                '    Exit Select
                'End If


                Dim strFPALLET_ID As String() = Nothing
                intRet = gobjComFuncFRM.TANAOROSHI_STS(CBO_ALL_VALUE, strFPALLET_ID)

                '↓↓↓↓ 2012.12.06 10:25 H.Morita 棚卸しを複数品目同時作業する対応
                'If intRet = RetCode.OK Then
                '    '([ST180],[搬送中]も含めて作業中の時)
                '    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM305010_16, PopupFormType.Ok, PopupIconType.Information)
                '    blnCheckErr = True
                '    Exit Select
                'End If
                '↑↑↑↑ 2012.12.06 10:25 H.Morita 棚卸しを複数品目同時作業する対応


                '==========================
                '作業中のﾊﾟﾚｯﾄと被っていないかﾁｪｯｸ
                '==========================
                Dim objDataTable As DataTable

                'ｸﾞﾘｯﾄﾞﾃﾞｰﾀ取得
                objDataTable = grdList.DataSource

                If intRet = RetCode.OK Then
                    '(作業中計画が存在する場合)
                    For II As Integer = LBound(strFPALLET_ID) To UBound(strFPALLET_ID)
                        '(計画分ﾙｰﾌﾟ(計画は1つのはずだけど念のため))
                        For Each objRow As DataRow In objDataTable.Rows
                            '(行ﾙｰﾌﾟ)
                            If strFPALLET_ID(II) = TO_STRING(objRow(menmListCol.FPALLET_ID)) Then
                                '(作業中のﾊﾟﾚｯﾄIDと被った時)
                                Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM305010_17, PopupFormType.Ok, PopupIconType.Information)
                                blnCheckErr = True
                                Exit Select
                            End If
                        Next
                    Next
                End If


                '**********************************************************
                ' 引当処理中確認
                '**********************************************************
                If gobjComFuncFRM.KariHikiate_Syukko_Chk() = False Then
                    '(仮引当処理中の時)
                    blnCheckErr = True
                    Exit Select
                End If


                blnCheckErr = False

            Case menmCheckCase.BEFORE_Check_Click
                '(印刷ﾎﾞﾀﾝｸﾘｯｸ時 事前ﾁｪｯｸ)

                If chkHINMEI.Checked = True Then
                    '(品名指定の時)

                    '----------------------------
                    '品名ｺｰﾄﾞﾁｪｯｸ
                    '----------------------------
                    If cboFHINMEI_CD.Text = "" Then
                        '(品名ｺｰﾄﾞが選択されていない場合)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM305010_09, PopupFormType.Ok, PopupIconType.Information)
                        blnCheckErr = True
                        Exit Select
                    End If

                    '----------------------------
                    '製造年月日ﾁｪｯｸ
                    '----------------------------
                    'If TO_STRING(cboXSEIZOU_DT.SelectedValue.ToString) = CBO_ALL_VALUE _
                    '        Or IsNull(TO_STRING(cboXSEIZOU_DT.SelectedValue.ToString)) = True Then
                    '    '(製造年月日が選択されていない場合)
                    '    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM305010_10, PopupFormType.Ok, PopupIconType.Information)
                    '    blnCheckErr = True
                    '    Exit Select
                    'End If

                    ''========================================
                    ''ﾊﾟﾚｯﾄ№ FROM
                    ''========================================
                    'If txtXPALLET_NO_FM.Text = "" Then
                    '    '（入力無しの場合）
                    '    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM305010_11, _
                    '                      PopupFormType.Ok, _
                    '                      PopupIconType.Information)
                    '    Exit Select
                    'End If

                    '========================================
                    'ﾊﾟﾚｯﾄ№ TO
                    '========================================
                    If (txtXPALLET_NO_TO.Text <> "") And _
                       (txtXPALLET_NO_FM.Text > txtXPALLET_NO_TO.Text) Then
                        '（FROM>TOの場合）
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM305010_12, _
                                          PopupFormType.Ok, _
                                          PopupIconType.Information)
                        Exit Select
                    End If

                Else
                    '(棚指定の時)
                    '=======================================
                    'FROM列連段入力ﾁｪｯｸ
                    '=======================================
                    If txtFRAC_RETU_FM.Text <> "" Or txtFRAC_REN_FM.Text <> "" Or txtFRAC_DAN_FM.Text <> "" Then
                        '(何か入力されている場合)
                        If txtFRAC_RETU_FM.Text = "" Or txtFRAC_REN_FM.Text = "" Or txtFRAC_DAN_FM.Text = "" Then
                            '(何か抜けている場合)
                            Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM305010_04, PopupFormType.Ok, PopupIconType.Information)
                            blnCheckErr = True
                            Exit Select
                        End If
                    Else
                        '(未指定の時)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM305010_04, PopupFormType.Ok, PopupIconType.Information)
                        blnCheckErr = True
                        Exit Select
                    End If

                    '=======================================
                    'TO列連段入力ﾁｪｯｸ
                    '=======================================
                    If txtFRAC_RETU_TO.Text <> "" Or txtFRAC_REN_TO.Text <> "" Or txtFRAC_DAN_TO.Text <> "" Then
                        '(何か入力されている場合)
                        If txtFRAC_RETU_TO.Text = "" Or txtFRAC_REN_TO.Text = "" Or txtFRAC_DAN_TO.Text = "" Then
                            '(何か抜けている場合)
                            Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM305010_05, PopupFormType.Ok, PopupIconType.Information)
                            blnCheckErr = True
                            Exit Select
                        End If
                    Else
                        '(未指定の時)
                        '↓↓↓ TO省略可能に 2011/11/12 18:15
                        'Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM305010_05, PopupFormType.Ok, PopupIconType.Information)
                        'blnCheckErr = True
                        'Exit Select
                        '↑↑↑ TO省略可能に 2011/11/12 18:15
                    End If

                    '=======================================
                    '列連段それぞれの範囲ﾁｪｯｸ
                    '=======================================
                    Dim intRetuMin As Integer = 0
                    Dim intRenMin As Integer = 0
                    Dim intDanMin As Integer = 0
                    Dim intRetuMax As Integer = 0
                    Dim intRenMax As Integer = 0
                    Dim intDanMax As Integer = 0
                    '列連段の最小最大取得
                    Call gobjComFuncFRM.GetRackInit(FTRK_BUF_NO_J9000, _
                                     intRetuMin, _
                                     intRenMin, _
                                     intDanMin, _
                                     intRetuMax, _
                                     intRenMax, _
                                     intDanMax)

                    If TO_INTEGER(txtFRAC_RETU_FM.Text) < intRetuMin Or TO_INTEGER(txtFRAC_RETU_FM.Text) > intRetuMax Then
                        '(最小より小さい場合、または最大より大きい場合)
                        Call gobjComFuncFRM.DisplayPopup(TO_STRING(intRetuMin) & "～" & TO_STRING(intRetuMax) & FRM_MSG_FRM305010_06, PopupFormType.Ok, PopupIconType.Information)
                        blnCheckErr = True
                        Exit Select
                    End If
                    If TO_INTEGER(txtFRAC_REN_FM.Text) < intRenMin Or TO_INTEGER(txtFRAC_REN_FM.Text) > intRenMax Then
                        '(最小より小さい場合、または最大より大きい場合)
                        Call gobjComFuncFRM.DisplayPopup(TO_STRING(intRenMin) & "～" & TO_STRING(intRenMax) & FRM_MSG_FRM305010_07, PopupFormType.Ok, PopupIconType.Information)
                        blnCheckErr = True
                        Exit Select
                    End If
                    If TO_INTEGER(txtFRAC_DAN_FM.Text) < intDanMin Or TO_INTEGER(txtFRAC_DAN_FM.Text) > intDanMax Then
                        '(最小より小さい場合、または最大より大きい場合)
                        Call gobjComFuncFRM.DisplayPopup(TO_STRING(intDanMin) & "～" & TO_STRING(intDanMax) & FRM_MSG_FRM305010_08, PopupFormType.Ok, PopupIconType.Information)
                        blnCheckErr = True
                        Exit Select
                    End If


                    '↓↓↓ TO省略可能に 2012/11/12 18:20
                    If (txtFRAC_RETU_TO.Text = "") And _
                       (txtFRAC_REN_TO.Text = "") And _
                       (txtFRAC_DAN_TO.Text = "") Then
                        '(TOが省略されている場合)
                        'ﾁｪｯｸなし
                    Else
                        '(TOの入力ある時)
                        If TO_INTEGER(txtFRAC_RETU_TO.Text) < intRetuMin Or TO_INTEGER(txtFRAC_RETU_TO.Text) > intRetuMax Then
                            '(最小より小さい場合、または最大より大きい場合)
                            Call gobjComFuncFRM.DisplayPopup(TO_STRING(intRetuMin) & "～" & TO_STRING(intRetuMax) & FRM_MSG_FRM305010_06, PopupFormType.Ok, PopupIconType.Information)
                            blnCheckErr = True
                            Exit Select
                        End If
                        If TO_INTEGER(txtFRAC_REN_TO.Text) < intRenMin Or TO_INTEGER(txtFRAC_REN_TO.Text) > intRenMax Then
                            '(最小より小さい場合、または最大より大きい場合)
                            Call gobjComFuncFRM.DisplayPopup(TO_STRING(intRenMin) & "～" & TO_STRING(intRenMax) & FRM_MSG_FRM305010_07, PopupFormType.Ok, PopupIconType.Information)
                            blnCheckErr = True
                            Exit Select
                        End If
                        If TO_INTEGER(txtFRAC_DAN_TO.Text) < intDanMin Or TO_INTEGER(txtFRAC_DAN_TO.Text) > intDanMax Then
                            '(最小より小さい場合、または最大より大きい場合)
                            Call gobjComFuncFRM.DisplayPopup(TO_STRING(intDanMin) & "～" & TO_STRING(intDanMax) & FRM_MSG_FRM305010_08, PopupFormType.Ok, PopupIconType.Information)
                            blnCheckErr = True
                            Exit Select
                        End If
                    End If
                    '↑↑↑ TO省略可能に 2012/11/12 18:20




                    '====================================
                    'FROM TO 大小ﾁｪｯｸ
                    '====================================
                    If (txtFRAC_RETU_FM.Text <> "") And _
                       (txtFRAC_REN_FM.Text <> "") And _
                       (txtFRAC_DAN_FM.Text <> "") And _
                       (txtFRAC_RETU_TO.Text <> "") And _
                       (txtFRAC_REN_TO.Text <> "") And _
                       (txtFRAC_DAN_TO.Text <> "") Then
                        '(全て入力ある時)
                        'Dim strFROM As String = Format(TO_INTEGER(mudtSEARCH_ITEM.FRAC_RETU_FM), "00") & "-" _
                        '                      & Format(TO_INTEGER(mudtSEARCH_ITEM.FRAC_REN_FM), "00") & "-" _
                        '                      & Format(TO_INTEGER(mudtSEARCH_ITEM.FRAC_DAN_FM), "00")

                        'Dim strTO As String = Format(TO_INTEGER(mudtSEARCH_ITEM.FRAC_RETU_TO), "00") & "-" _
                        '                     & Format(TO_INTEGER(mudtSEARCH_ITEM.FRAC_REN_TO), "00") & "-" _
                        '                     & Format(TO_INTEGER(mudtSEARCH_ITEM.FRAC_DAN_TO), "00")

                        Dim strFROM As String = Format(TO_INTEGER(txtFRAC_RETU_FM.Text), "00") & "-" _
                                              & Format(TO_INTEGER(txtFRAC_REN_FM.Text), "00") & "-" _
                                              & Format(TO_INTEGER(txtFRAC_DAN_FM.Text), "00")

                        Dim strTO As String = Format(TO_INTEGER(txtFRAC_RETU_TO.Text), "00") & "-" _
                                             & Format(TO_INTEGER(txtFRAC_REN_TO.Text), "00") & "-" _
                                             & Format(TO_INTEGER(txtFRAC_DAN_TO.Text), "00")

                        If strFROM > strTO Then
                            '(FROM>TOの時)
                            Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM305010_03, PopupFormType.Ok, PopupIconType.Information)
                            blnCheckErr = True
                            Exit Select
                        End If
                    End If

                End If

                blnCheckErr = False

            Case menmCheckCase.PRINT_Click
                '(印刷ﾎﾞﾀﾝｸﾘｯｸ時)

                '==========================
                'ﾘｽﾄ　表示ﾃﾞｰﾀﾁｪｯｸ
                '==========================
                If grdList.Rows.Count < 1 Then
                    '(ﾃﾞｰﾀが一行もない場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM305010_13, PopupFormType.Ok, PopupIconType.Information)
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
#Region "　ﾘｽﾄ表示　                                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾘｽﾄ表示
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub grdListDisplayChild()


        Dim strSQL As String                        'SQL文


        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "  SELECT "
        strSQL &= vbCrLf & "       TRST_STOCK.FPALLET_ID "                       '在庫情報       .ﾊﾟﾚｯﾄID
        strSQL &= vbCrLf & "     , TPRG_TRK_BUF.FTRK_BUF_NO "                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        strSQL &= vbCrLf & "     , TPRG_TRK_BUF.FTRK_BUF_ARRAY "                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
        strSQL &= vbCrLf & "     , TMST_TRK.FBUF_NAME "                          'ﾄﾗｯｷﾝｸﾞﾏｽﾀ     .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称
        strSQL &= vbCrLf & "     , TPRG_TRK_BUF.FDISP_ADDRESS "                  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ   .表記用ｱﾄﾞﾚｽ(ﾛｹｰｼｮﾝ)
        strSQL &= vbCrLf & "     , TRST_STOCK.FHINMEI_CD "                       '在庫情報       .品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "     , TMST_ITEM.FHINMEI "                           '品目ﾏｽﾀ        .品名
        strSQL &= vbCrLf & "     , TRST_STOCK.XSEIZOU_DT "                       '在庫情報       .製造年月日
        strSQL &= vbCrLf & "     , TRST_STOCK.XLINE_NO "                         '在庫情報       .ﾗｲﾝ№
        strSQL &= vbCrLf & "     , TRST_STOCK.XSYUKKA_KAHI "                     '在庫情報       .出荷可否
        strSQL &= vbCrLf & "     , HASH01.FGAMEN_DISP AS XSYUKKA_KAHI_DSP "      '在庫情報       .出荷可否(表示用)
        strSQL &= vbCrLf & "     , TRST_STOCK.XHINSHITU_STS "                    '在庫情報       .品質ｽﾃｰﾀｽ
        strSQL &= vbCrLf & "     , HASH02.FGAMEN_DISP AS XHINSHITU_STS_DSP "     '在庫情報       .品質ｽﾃｰﾀｽ(表示用)
        strSQL &= vbCrLf & "     , TRST_STOCK.FHORYU_KUBUN "                     '在庫情報       .保留区分
        strSQL &= vbCrLf & "     , HASH03.FGAMEN_DISP AS FHORYU_KUBUN_DSP "      '在庫情報       .保留区分(表示用)
        strSQL &= vbCrLf & "     , TRST_STOCK.FTR_VOL "                          '在庫情報       .搬送管理量(積込数)
        strSQL &= vbCrLf & "     , TRST_STOCK.XPALLET_NO "                       '在庫情報       .ﾊﾟﾚｯﾄ№

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "       TPRG_TRK_BUF "
        strSQL &= vbCrLf & "     , TMST_TRK "
        strSQL &= vbCrLf & "     , TRST_STOCK "
        strSQL &= vbCrLf & "     , TMST_ITEM "
        strSQL &= vbCrLf & "     , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH01", "TRST_STOCK", "XSYUKKA_KAHI")
        strSQL &= vbCrLf & "     , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH02", "TRST_STOCK", "XHINSHITU_STS")
        strSQL &= vbCrLf & "     , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH03", "TRST_STOCK", "FHORYU_KUBUN")

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE 0 = 0 "
        strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FPALLET_ID = TRST_STOCK.FPALLET_ID(+) "
        strSQL &= vbCrLf & "     AND TRST_STOCK.FHINMEI_CD = TMST_ITEM.FHINMEI_CD(+) "
        strSQL &= vbCrLf & "     AND TMST_TRK.FTRK_BUF_NO = TPRG_TRK_BUF.FTRK_BUF_NO(+) "
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH01", "TRST_STOCK", "XSYUKKA_KAHI")
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH02", "TRST_STOCK", "XHINSHITU_STS")
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH03", "TRST_STOCK", "FHORYU_KUBUN")
        strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FRES_KIND = " & FRES_KIND_SZAIKO              '引当状態：在庫
        strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FPALLET_ID NOT IN( "                          '在庫棚(未引当)
        strSQL &= vbCrLf & "                (SELECT FPALLET_ID FROM XSTS_HIKIATE_K1) "
        strSQL &= vbCrLf & "                                    ) "
        strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FPALLET_ID NOT IN( "                          '在庫棚(未引当)
        strSQL &= vbCrLf & "                (SELECT FPALLET_ID FROM TSTS_HIKIATE) "
        strSQL &= vbCrLf & "                                    ) "
        strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FTRK_BUF_NO = " & FTRK_BUF_NO_J9000           '自動倉庫


        If chkHINMEI.Checked = True Then
            '(品名指定の時)

            '----------------------------------------------
            '品名ｺｰﾄﾞ
            '----------------------------------------------
            If mudtSEARCH_ITEM.FHINMEI_CD <> "" Then
                '(全検索以外の場合)
                strSQL &= vbCrLf & "    AND TRST_STOCK.FHINMEI_CD LIKE '" & mudtSEARCH_ITEM.FHINMEI_CD & "%' "
            End If

            '----------------------------------------------
            '製造年月日
            '----------------------------------------------
            If mudtSEARCH_ITEM.XSEIZOU_DT <> "" Then
                '(全検索以外の場合)
                strSQL &= vbCrLf & "    AND TRST_STOCK.XSEIZOU_DT = TO_DATE('" & mudtSEARCH_ITEM.XSEIZOU_DT & " 00:00:00','YYYY/MM/DD HH24:MI:SS')"
            End If

            '----------------------------------------------
            'ﾗｲﾝ№
            '----------------------------------------------
            If mudtSEARCH_ITEM.XLINE_NO <> "" Then
                '(全検索以外の場合)
                '↓↓↓↓ 2012.12.07 13:00 H.Morita 文字型、数値型を考慮する
                'strSQL &= vbCrLf & "    AND TRST_STOCK.XLINE_NO = " & mudtSEARCH_ITEM.XLINE_NO
                strSQL &= vbCrLf & "    AND TRST_STOCK.XLINE_NO = '" & mudtSEARCH_ITEM.XLINE_NO & "' "
                '↑↑↑↑ 2012.12.07 13:00 H.Morita 文字型、数値型を考慮する
            End If

            '----------------------------------------------
            'ﾊﾟﾚｯﾄ№ FROM
            '----------------------------------------------
            If mudtSEARCH_ITEM.XPALLET_NO_FM <> "" Then
                '(全検索以外の場合)
                '↓↓↓↓ 2012.12.07 13:00 H.Morita 文字型、数値型を考慮する
                'strSQL &= vbCrLf & "    AND TRST_STOCK.XPALLET_NO >= " & mudtSEARCH_ITEM.XPALLET_NO_FM
                strSQL &= vbCrLf & "    AND TRST_STOCK.XPALLET_NO >= '" & mudtSEARCH_ITEM.XPALLET_NO_FM & "' "
                '↑↑↑↑ 2012.12.07 13:00 H.Morita 文字型、数値型を考慮する
            End If

            '----------------------------------------------
            'ﾊﾟﾚｯﾄ№ TO
            '----------------------------------------------
            If mudtSEARCH_ITEM.XPALLET_NO_TO <> "" Then
                '(全検索以外の場合)
                '↓↓↓↓ 2012.12.07 13:00 H.Morita 文字型、数値型を考慮する
                'strSQL &= vbCrLf & "    AND TRST_STOCK.XPALLET_NO <= " & mudtSEARCH_ITEM.XPALLET_NO_TO
                strSQL &= vbCrLf & "    AND TRST_STOCK.XPALLET_NO <= '" & mudtSEARCH_ITEM.XPALLET_NO_TO & "' "
                '↑↑↑↑ 2012.12.07 13:00 H.Morita 文字型、数値型を考慮する
            End If

        Else
            '(棚範囲指定の時)

            '----------------------------------------------
            'FROM
            '----------------------------------------------
            If (mudtSEARCH_ITEM.FRAC_RETU_FM <> "") Or _
               (mudtSEARCH_ITEM.FRAC_REN_FM <> "") Or _
               (mudtSEARCH_ITEM.FRAC_DAN_FM <> "") Then
                '(全検索以外の場合)
                strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FDISP_ADDRESS >= '" _
                                       & Format(TO_INTEGER(mudtSEARCH_ITEM.FRAC_RETU_FM), "00") & "-" _
                                       & Format(TO_INTEGER(mudtSEARCH_ITEM.FRAC_REN_FM), "00") & "-" _
                                       & Format(TO_INTEGER(mudtSEARCH_ITEM.FRAC_DAN_FM), "00") _
                                       & "' "    '表記用ｱﾄﾞﾚｽ(FROM)
            End If

            '----------------------------------------------
            'TO
            '----------------------------------------------
            If (mudtSEARCH_ITEM.FRAC_RETU_TO <> "") Or _
               (mudtSEARCH_ITEM.FRAC_REN_TO <> "") Or _
               (mudtSEARCH_ITEM.FRAC_DAN_TO <> "") Then
                '(全検索以外の場合)
                strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FDISP_ADDRESS <= '" _
                                      & Format(TO_INTEGER(mudtSEARCH_ITEM.FRAC_RETU_TO), "00") & "-" _
                                      & Format(TO_INTEGER(mudtSEARCH_ITEM.FRAC_REN_TO), "00") & "-" _
                                      & Format(TO_INTEGER(mudtSEARCH_ITEM.FRAC_DAN_TO), "00") _
                                      & "' "    '表記用ｱﾄﾞﾚｽ(FROM)
            End If

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
                                    False)

        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdListSetup()
        Call gobjComFuncFRM.GridSelect(grdList, -1, -1, Nothing)      'ｸﾞﾘｯﾄﾞ選択処理


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

        grdList.AllowUserToResizeColumns = False

    End Sub
#End Region
#Region "　印刷処理　                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 印刷処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub PrintOutProcess()

        Call gobjComFuncFRM.WaitFormShow()                     ' Waitﾌｫｰﾑ表示

        '***********************************************
        ' 各ｵﾌﾞｼﾞｪｸﾄのｲﾝｽﾀﾝｽ
        '***********************************************
        Dim objCR As New PRT_305010_01          'ｸﾘｽﾀﾙﾚﾎﾟｰﾄｵﾌﾞｼﾞｪｸﾄ
        Dim objDataSet As New clsPrintDataSet   'ﾃﾞｰﾀﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ

        Try

            '***********************************************
            ' ﾍｯﾀﾞｰ部分作成
            '***********************************************
            '================================
            ' ﾃﾞｰﾀをｾｯﾄ
            '================================
            Call gobjComFuncFRM.ChangeCRText(objCR, "crDateTime01", Format(Now, GAMEN_DATE_FORMAT_02))         '発行日時

            If chkHINMEI.Checked = True Then
                '(品名指定の時)
                Call gobjComFuncFRM.ChangeCRText(objCR, "crText02", mudtSEARCH_ITEM.FHINMEI_CD)             '品名ｺｰﾄﾞ
                Call gobjComFuncFRM.ChangeCRText(objCR, "crText03", lblFHINMEI.Text)                        '品名
                Call gobjComFuncFRM.ChangeCRText(objCR, "crText04", mudtSEARCH_ITEM.XSEIZOU_DT)             '製造年月日
                Call gobjComFuncFRM.ChangeCRText(objCR, "crText05", mudtSEARCH_ITEM.XPALLET_NO_FM)          'ﾊﾟﾚｯﾄ№ FROM
                Call gobjComFuncFRM.ChangeCRText(objCR, "crText06", mudtSEARCH_ITEM.XPALLET_NO_TO)          'ﾊﾟﾚｯﾄ№ TO
            Else
                '(棚番指定の時)
                Call gobjComFuncFRM.ChangeCRText(objCR, "crText02", "")     '品名ｺｰﾄﾞ
                Call gobjComFuncFRM.ChangeCRText(objCR, "crText03", "")     '品名
                Call gobjComFuncFRM.ChangeCRText(objCR, "crText04", "")     '製造年月日
                Call gobjComFuncFRM.ChangeCRText(objCR, "crText05", "")     'ﾊﾟﾚｯﾄ№ FROM
                Call gobjComFuncFRM.ChangeCRText(objCR, "crText06", "")     'ﾊﾟﾚｯﾄ№ TO
            End If

            '***********************************************
            ' ﾃﾞｰﾀ部分作成
            '***********************************************
            For ii As Integer = 0 To grdList.Rows.Count - 1
                Dim objDataRow As clsPrintDataSet.DataTable01Row
                objDataRow = objDataSet.DataTable01.NewRow

                objDataRow.BeginEdit()

                If ii = 0 Then
                    Call gobjComFuncFRM.ChangeCRText(objCR, "crText01", grdList.Item(menmListCol.FBUF_BUF_NO_NM, ii).FormattedValue)  '保管場所
                End If

                objDataRow.Data00 = grdList.Item(menmListCol.FDISP_ADDRESS, ii).FormattedValue         '棚卸しﾘｽﾄ.  ﾛｹｰｼｮﾝ
                objDataRow.Data01 = grdList.Item(menmListCol.FHINMEI_CD, ii).FormattedValue            '棚卸しﾘｽﾄ.  品名ｺｰﾄﾞ
                objDataRow.Data02 = grdList.Item(menmListCol.FHINMEI, ii).FormattedValue               '棚卸しﾘｽﾄ.  品名
                objDataRow.Data03 = grdList.Item(menmListCol.XSEIZOU_DT, ii).FormattedValue            '棚卸しﾘｽﾄ.  製造年月日
                objDataRow.Data04 = grdList.Item(menmListCol.XLINE_NO, ii).FormattedValue              '棚卸しﾘｽﾄ.  ﾗｲﾝ№
                objDataRow.Data05 = grdList.Item(menmListCol.XSYUKKA_KAHI_DSP, ii).FormattedValue      '棚卸しﾘｽﾄ.  出荷可否
                objDataRow.Data06 = grdList.Item(menmListCol.XHINSHITU_STS_DSP, ii).FormattedValue     '棚卸しﾘｽﾄ.  品質ｽﾃｰﾀｽ
                objDataRow.Data07 = grdList.Item(menmListCol.FHORYU_KUBUN_DSP, ii).FormattedValue      '棚卸しﾘｽﾄ.  保留区分
                objDataRow.Data08 = grdList.Item(menmListCol.FTR_VOL, ii).FormattedValue               '棚卸しﾘｽﾄ.  C/S数
                objDataRow.Data09 = grdList.Item(menmListCol.XPALLET_NO, ii).FormattedValue            '棚卸しﾘｽﾄ.  ﾊﾟﾚｯﾄ№

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
#Region "　画面初期表示                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub Gamen_Display()

        '**********************************************************
        ' ｺﾝﾄﾛｰﾙ初期化
        '**********************************************************
        '===================================
        '出庫問合せ ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
        '===================================
        cboFHINMEI_CD.SelectedIndex = -1             '品名ｺｰﾄﾞ
        cboFHINMEI_CD.Text = ""
        cboXSEIZOU_DT.SelectedIndex = -1             '製造年月日

        '*********************************************
        ' ﾃｷｽﾄﾎﾞｯｸｽ初期設定
        '*********************************************
        lblFHINMEI.Text = ""
        txtXLINE_NO.Text = ""
        txtXPALLET_NO_FM.Text = ""
        txtXPALLET_NO_TO.Text = ""
        txtFRAC_RETU_FM.Text = ""
        txtFRAC_REN_FM.Text = ""
        txtFRAC_DAN_FM.Text = ""
        txtFRAC_RETU_TO.Text = ""
        txtFRAC_REN_TO.Text = ""
        txtFRAC_DAN_TO.Text = ""

        '*********************************************
        ' ﾁｪｯｸﾎﾞｯｸｽ初期設定
        '*********************************************
        chkHINMEI.Checked = True
        chkTANA.Checked = False

    End Sub
#End Region
#Region "　ﾌﾟﾛﾊﾟﾃｨｾｯﾄ(棚卸し作業実施確認画面)　     "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub SetProperty(ByVal objForm As FRM_305012)

        '*********************************************
        'ﾊﾟﾚｯﾄID取得
        '*********************************************
        Dim intRet As Integer = 0
        mstrFPALLET_ID = Nothing

        For ii As Integer = 0 To grdList.RowCount - 1
            '(ﾙｰﾌﾟ:行数)

            Dim strBUF_NOTemp As String = grdList.Item(menmListCol.FTRK_BUF_NO, grdList.Rows(ii).Index).Value
            Dim strBUF_ARRAYTemp As String = grdList.Item(menmListCol.FTRK_BUF_ARRAY, grdList.Rows(ii).Index).Value
            Dim strPalletTemp As String = grdList.Item(menmListCol.FPALLET_ID, grdList.Rows(ii).Index).Value

            If IsNull(mstrFPALLET_ID) = True Then
                '(最初の一回)
                ReDim mstrFPALLET_ID(0)
                mstrFPALLET_ID(0) = strPalletTemp

                ReDim mstrFTRK_BUF_NO(0)
                mstrFTRK_BUF_NO(0) = strBUF_NOTemp

                ReDim mstrFTRK_BUF_ARRAY(0)
                mstrFTRK_BUF_ARRAY(0) = strBUF_ARRAYTemp
            Else
                '(二回目以降)
                intRet = ArrayFindData(mstrFPALLET_ID, strPalletTemp)
                If intRet = -1 Then
                    '(ﾊﾟﾚｯﾄIDが見つからなかった場合)
                    ReDim Preserve mstrFPALLET_ID(UBound(mstrFPALLET_ID) + 1)
                    mstrFPALLET_ID(UBound(mstrFPALLET_ID)) = strPalletTemp

                    ReDim Preserve mstrFTRK_BUF_NO(UBound(mstrFTRK_BUF_NO) + 1)
                    mstrFTRK_BUF_NO(UBound(mstrFTRK_BUF_NO)) = strBUF_NOTemp

                    ReDim Preserve mstrFTRK_BUF_ARRAY(UBound(mstrFTRK_BUF_ARRAY) + 1)
                    mstrFTRK_BUF_ARRAY(UBound(mstrFTRK_BUF_ARRAY)) = strBUF_ARRAYTemp
                End If

            End If

        Next


        objForm.userHINMEI_CD_SRCH = cboFHINMEI_CD.Text                '検索条件品名ｺｰﾄﾞ
        objForm.mstrTR_TO = TO_STRING(cboFTRK_BUF_NO.SelectedValue)    '搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
        objForm.userPALLET_ID = mstrFPALLET_ID                         'ﾊﾟﾚｯﾄID
        objForm.userBUF_NO = mstrFTRK_BUF_NO                           'ﾊﾞｯﾌｬ№
        objForm.userBUF_ARRAY = mstrFTRK_BUF_ARRAY                     'ﾊﾞｯﾌｬ配列№

    End Sub
#End Region

End Class
