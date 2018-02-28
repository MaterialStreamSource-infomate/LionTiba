'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】倉替え設定
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_303060
#Region "　共通変数　                               "

    Private mFlag_Form_Load As Boolean = True                   '画面展開ﾌﾗｸﾞ

    '検索条件用構造体
    Private mudtSEARCH_ITEM As New SEARCH_ITEM

    '選択されたﾊﾟﾚｯﾄID、在庫ﾛｯﾄ№の配列
    Public mstrFPALLET_ID() As String = Nothing

    'ｸﾞﾘｯﾄﾞ項目
    Enum menmListCol
        FPALLET_ID                  '在庫情報.          ﾊﾟﾚｯﾄID(非表示)
        FHINMEI_CD                  '在庫情報.          品名ｺｰﾄﾞ
        FHINMEI                     '品目ﾏｽﾀ.           品名
        XSEIZOU_DT                  '在庫情報.          製造年月日
        XLINE_NO                    '在庫情報.          ﾗｲﾝ№
        XPALLET_NO                  '在庫情報.          ﾊﾟﾚｯﾄ№
        XSYUKKA_KAHI                '在庫情報.          出荷可否(非表示)
        XSYUKKA_KAHI_DSP            '在庫情報.          出荷可否(表示用)
        XHINSHITU_STS               '在庫情報.          品質ｽﾃｰﾀｽ(非表示)
        XHINSHITU_STS_DSP           '在庫情報.          品質ｽﾃｰﾀｽ(表示用)
        FHORYU_KUBUN                '在庫情報.          保留区分(非表示)
        FHORYU_KUBUN_DSP            '在庫情報.          保留区分(表示用)
        FTR_VOL                     '在庫情報.          搬送管理量(数量)
        FDISP_ADDRESS               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      ﾛｹｰｼｮﾝ

        MAXCOL

    End Enum

    '入力ﾁｪｯｸ場合判別
    Enum menmCheckCase
        SearchBtn_Click                 '検索ﾎﾞﾀﾝｸﾘｯｸ時
        SelectAll_Click                 '全選択ﾎﾞﾀﾝｸﾘｯｸ時
        NotSelectAll_Click              '全解除ﾎﾞﾀﾝｸﾘｯｸ時
        OutReg_Click                    '倉替え設定ﾎﾞﾀﾝｸﾘｯｸ時
    End Enum

#End Region
#Region "  構造体定義                               "
    '検索条件
    Private Structure SEARCH_ITEM
        Dim FTRK_BUF_NO_FM As String    '移送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
        Dim FTRK_BUF_NO_TO As String    '移送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
        Dim FTRK_BUF_NM_FM As String    '移送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ名称
        Dim FTRK_BUF_NM_TO As String    '移送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ名称
        Dim FHINMEI_CD As String        '品名ｺｰﾄﾞ
        Dim FHINMEI As String           '品名
        Dim XSEIZOU_DT As String        '製造年月日
        Dim XLINE_NO As String          'ﾗｲﾝ№
        Dim XSYUKKA_KAHI As String      '出荷可否
        Dim XHINSHITU_STS As String     '品質ｽﾃｰﾀｽ
        Dim FHORYU_KUBUN As String      '保留区分
        Dim XSYUKKA_KAHI_DSP As String   '出荷可否(表示用)
        Dim XHINSHITU_STS_DSP As String  '品質ｽﾃｰﾀｽ(表示用)
        Dim FHORYU_KUBUN_DSP As String   '保留区分(表示用)
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
#Region "　移動元ｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞ       ｲﾍﾞﾝﾄ     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 移動元ｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cboFTRK_BUF_NO_FM_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFTRK_BUF_NO_FM.SelectedIndexChanged
        Try

            If mFlag_Form_Load = False Then

                '===================================
                '在庫問合せ ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
                '===================================
                cboFHINMEI_CD.Text = ""         '品名ｺｰﾄﾞ

                cboFHINMEI_CD.conn = gobjDb
                cboFHINMEI_CD.HinmeiLabel = lblFHINMEI
                cboFHINMEI_CD.Text = ""
                cboFHINMEI_CD.TableName = "TRST_STOCK"
                cboFHINMEI_CD.ComboBoxType = GamenCommon.cmpCboFHINMEI_CD.HINMEI_CBO_TYPE.SpecifiedAndMasterData
                cboFHINMEI_CD.HinmeiVisible = False
                ReDim cboFHINMEI_CD.FTRK_BUF_NO(0)                      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№指定
                cboFHINMEI_CD.FTRK_BUF_NO(0) = TO_STRING(cboFTRK_BUF_NO_FM.SelectedValue.ToString)
                cboFHINMEI_CD.FRES_KIND = FRES_KIND_SZAIKO                                             '引当状態 = 「在庫棚」
                cboFHINMEI_CD.cboSetupHinmeiCd(cboFHINMEI_CD.Text)                                     '品名ｺｰﾄﾞ

            End If


        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
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
                Dim strFTRK_BUF_NO_FM As String = TO_STRING(cboFTRK_BUF_NO_FM.SelectedValue.ToString)

                Call MakeToiawaseSyukko_cboXSEIZOU_DT(cboFHINMEI_CD.Text, cboXSEIZOU_DT, strFTRK_BUF_NO_FM, True)         '製造年月日
                Call MakeToiawaseSyukko_cboXLINE_NO(cboFHINMEI_CD.Text, cboXLINE_NO, strFTRK_BUF_NO_FM, True)             'ﾗｲﾝ№

                cboXSYUKKA_KAHI.SelectedIndex = -1                                                     '出荷可否
                cboXHINSHITU_STS.SelectedIndex = -1                                                    '品質ｽﾃｰﾀｽ
                cboFHORYU_KUBUN.SelectedIndex = -1                                                     '保留区分

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
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub InitializeChild()

        '**********************************************************
        'ｺﾝﾎﾞﾎﾞｯｸｽｾｯﾄｱｯﾌﾟ
        '**********************************************************
        '===================================
        '移動元 ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(Me.Name, cboFTRK_BUF_NO_FM, False)

        '===================================
        '移動先 ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(Me.Name, cboFTRK_BUF_NO_TO, False)


        '===================================
        '倉替え設定 ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
        '===================================
        cboFHINMEI_CD.conn = gobjDb
        cboFHINMEI_CD.HinmeiLabel = lblFHINMEI
        cboFHINMEI_CD.Text = ""
        cboFHINMEI_CD.TableName = "TRST_STOCK"
        cboFHINMEI_CD.ComboBoxType = GamenCommon.cmpCboFHINMEI_CD.HINMEI_CBO_TYPE.SpecifiedAndMasterData
        cboFHINMEI_CD.HinmeiVisible = False
        ReDim cboFHINMEI_CD.FTRK_BUF_NO(0)                     'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№指定
        cboFHINMEI_CD.FTRK_BUF_NO(0) = FTRK_BUF_NO_J9000
        cboFHINMEI_CD.FRES_KIND = FRES_KIND_SZAIKO                                             '引当状態 = 「在庫棚」
        cboFHINMEI_CD.cboSetupHinmeiCd(cboFHINMEI_CD.Text)                                     '品名ｺｰﾄﾞ


        Dim strFTRK_BUF_NO_FM As String = TO_STRING(cboFTRK_BUF_NO_FM.SelectedValue.ToString)
        Call MakeToiawaseSyukko_cboXSEIZOU_DT(cboFHINMEI_CD.Text, cboXSEIZOU_DT, strFTRK_BUF_NO_FM, True)         '製造年月日
        Call MakeToiawaseSyukko_cboXLINE_NO(cboFHINMEI_CD.Text, cboXLINE_NO, strFTRK_BUF_NO_FM, True)             'ﾗｲﾝ№

        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboXSYUKKA_KAHI, True)                    '出荷可否
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboXHINSHITU_STS, True)                   '品質ｽﾃｰﾀｽ
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboFHORYU_KUBUN, True)                    '保留区分


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
        cboFTRK_BUF_NO_FM.Dispose()         '移動元
        cboFTRK_BUF_NO_TO.Dispose()         '移動先
        cboFHINMEI_CD.Dispose()             '品名ｺｰﾄﾞ
        cboXSEIZOU_DT.Dispose()             '製造年月日
        cboXLINE_NO.Dispose()               'ﾗｲﾝ№
        cboXSYUKKA_KAHI.Dispose()           '出荷可否
        cboXHINSHITU_STS.Dispose()          '品質ｽﾃｰﾀｽ
        cboFHORYU_KUBUN.Dispose()           '保留区分
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
#Region "  F6(倉替え設定)     ﾎﾞﾀﾝ押下処理　        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F6(倉替え設定)     ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F6Process()

        '*******************************************************
        '入力ﾁｪｯｸ
        '*******************************************************
        If InputCheck(menmCheckCase.OutReg_Click) = False Then
            Exit Sub
        End If


        'ｵﾌﾞｼﾞｪｸﾄNothingﾁｪｯｸ
        If IsNull(gobjFRM_303061) = False Then
            gobjFRM_303061.Close()
            gobjFRM_303061.Dispose()
            gobjFRM_303061 = Nothing
        End If

        '********************************************************************
        ' 子画面展開
        '********************************************************************
        gobjFRM_303061 = New FRM_303061         'ｵﾌﾞｼﾞｪｸﾄ作成

        Call SetProperty(gobjFRM_303061)        'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        Call gobjFRM_303061.ShowDialog()        '画面表示


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
        For ii As Integer = 0 To grdList.SelectedRows.Count - 1
            '(ﾙｰﾌﾟ:選択された行数)

            Dim strPalletTemp As String = grdList.Item(menmListCol.FPALLET_ID, grdList.SelectedRows(ii).Index).Value

            If IsNull(mstrFPALLET_ID) = True Then
                '(最初の一回)
                ReDim mstrFPALLET_ID(0)
                mstrFPALLET_ID(0) = strPalletTemp
            Else
                '(二回目以降)
                intRet = ArrayFindData(mstrFPALLET_ID, strPalletTemp)
                If intRet = -1 Then
                    '(ﾊﾟﾚｯﾄIDが見つからなかった場合)
                    ReDim Preserve mstrFPALLET_ID(UBound(mstrFPALLET_ID) + 1)
                    mstrFPALLET_ID(UBound(mstrFPALLET_ID)) = strPalletTemp
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
                '移動元、移動先 選択ﾁｪｯｸ()
                '==========================
                If TO_STRING(cboFTRK_BUF_NO_FM.SelectedValue) = TO_STRING(cboFTRK_BUF_NO_TO.SelectedValue) Then
                    '(移動元、移動先が、同一が選択された場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303060_01, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If

                blnCheckErr = False

            Case menmCheckCase.SelectAll_Click
                '(全選択ﾎﾞﾀﾝｸﾘｯｸ時)

                blnCheckErr = False

            Case menmCheckCase.NotSelectAll_Click
                '(全解除ﾎﾞﾀﾝｸﾘｯｸ時)

                blnCheckErr = False

            Case menmCheckCase.OutReg_Click
                '(倉替え設定ﾎﾞﾀﾝｸﾘｯｸ時)

                '==========================
                'ﾘｽﾄ選択ﾁｪｯｸ
                '==========================
                If grdList.SelectedRows.Count <= 0 Then
                    '(ﾘｽﾄが選択されていない場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_GRD_LIST, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select

                End If


                '*********************************************
                'ｸﾚｰﾝ状態ﾁｪｯｸ
                '*********************************************
                'Dim intRet As RetCode
                Dim strMsg As String = ""

                If mudtSEARCH_ITEM.FTRK_BUF_NO_FM = FTRK_BUF_NO_J9000 Then
                    '(移動元が自動倉庫の時)

                    For ii As Integer = 0 To grdList.SelectedRows.Count - 1
                        '(ﾙｰﾌﾟ:選択された行数)
                        '↓↓↓↓↓↓************************************************************************************************************
                        'SystemMate:A.Noto 2012/05/23  出庫ﾄﾗｯｷﾝｸﾞの禁止設定ﾁｪｯｸ(標準化※削除しないこと)
                        Dim strFPALLET_ID As String = TO_STRING(grdList.Item(menmListCol.FPALLET_ID, grdList.SelectedRows(ii).Index).Value)
                        If gobjComFuncFRM.CheckOutTrkBufNo(strFPALLET_ID) = False Then
                            blnCheckErr = True
                            Exit Select
                        End If


                        'Dim strFRAC_RETU As String = TO_STRING(grdList.Item(menmListCol.FRAC_RETU, grdList.SelectedRows(ii).Index).Value)

                        ''=============================================
                        ''ｸﾚｰﾝﾏｽﾀ
                        ''=============================================
                        'Dim objTMST_CRANE As New TBL_TMST_CRANE(gobjOwner, gobjDb, Nothing)         'ｸﾚｰﾝﾏｽﾀﾃｰﾌﾞﾙｸﾗｽ
                        'objTMST_CRANE.INTCHECK_ROW = strFRAC_RETU                                   '列
                        'If cboFPLACE_CD.SelectedValue = FTRK_BUF_NO_J9101 Then
                        '    '(ｼｰﾄﾗｯｸのとき)
                        '    objTMST_CRANE.FTRK_BUF_NO = FTRK_BUF_NO_J9101
                        'ElseIf cboFPLACE_CD.SelectedValue = FTRK_BUF_NO_J9201 Then
                        '    '(ｺｲﾙﾗｯｸのとき)
                        '    objTMST_CRANE.FTRK_BUF_NO = FTRK_BUF_NO_J9201
                        'End If

                        'intRet = objTMST_CRANE.GET_TMST_CRANE_ROW                                   '特定
                        'If intRet = RetCode.NotFound Then
                        '    '(見つからない場合)
                        '    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303050_01, PopupFormType.Ok, PopupIconType.Information)
                        '    blnCheckErr = True
                        '    Exit Select
                        'End If


                        ''=============================================
                        ''設備状況
                        ''=============================================
                        'Dim objTSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(gobjOwner, gobjDb, Nothing)     '設備状況ﾃｰﾌﾞﾙｸﾗｽ
                        'objTSTS_EQ_CTRL.FEQ_ID = objTMST_CRANE.FEQ_ID                               '設備ID
                        'intRet = objTSTS_EQ_CTRL.GET_TSTS_EQ_CTRL(False)                            '特定
                        'If intRet = RetCode.NotFound Then
                        '    '(見つからない場合)
                        '    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303050_02, PopupFormType.Ok, PopupIconType.Information)
                        '    blnCheckErr = True
                        '    Exit Select
                        'End If

                        'If objTSTS_EQ_CTRL.FEQ_CUT_STS = FEQ_CUT_STS_SON Then
                        '    '(切離し状態が切離中のとき)
                        '    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303050_03, PopupFormType.Ok, PopupIconType.Information)
                        '    blnCheckErr = True
                        '    Exit Select
                        'End If

                        '↑↑↑↑↑↑************************************************************************************************************

                    Next

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
        mudtSEARCH_ITEM.FTRK_BUF_NO_FM = TO_STRING(cboFTRK_BUF_NO_FM.SelectedValue)         '移送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
        mudtSEARCH_ITEM.FTRK_BUF_NO_TO = TO_STRING(cboFTRK_BUF_NO_TO.SelectedValue)         '移送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
        mudtSEARCH_ITEM.FTRK_BUF_NM_FM = cboFTRK_BUF_NO_FM.Text                             '移送元ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ名称
        mudtSEARCH_ITEM.FTRK_BUF_NM_TO = cboFTRK_BUF_NO_TO.Text                             '移送先ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ名称
        mudtSEARCH_ITEM.FHINMEI_CD = cboFHINMEI_CD.Text                                     '品名ｺｰﾄﾞ
        mudtSEARCH_ITEM.FHINMEI = lblFHINMEI.Text                                           '品名
        mudtSEARCH_ITEM.XSEIZOU_DT = TO_STRING(cboXSEIZOU_DT.SelectedValue)                 '製造年月日
        mudtSEARCH_ITEM.XLINE_NO = TO_STRING(cboXLINE_NO.SelectedValue)                     'ﾗｲﾝ№
        mudtSEARCH_ITEM.XSYUKKA_KAHI = TO_STRING(cboXSYUKKA_KAHI.SelectedValue)             '出荷可否
        mudtSEARCH_ITEM.XHINSHITU_STS = TO_STRING(cboXHINSHITU_STS.SelectedValue)           '品質ｽﾃｰﾀｽ
        mudtSEARCH_ITEM.FHORYU_KUBUN = TO_STRING(cboFHORYU_KUBUN.SelectedValue)             '保留区分
        mudtSEARCH_ITEM.XSYUKKA_KAHI_DSP = cboXSYUKKA_KAHI.Text                             '出荷可否(表示用)
        mudtSEARCH_ITEM.XHINSHITU_STS_DSP = cboXHINSHITU_STS.Text                           '品質ｽﾃｰﾀｽ(表示用)
        mudtSEARCH_ITEM.FHORYU_KUBUN_DSP = cboFHORYU_KUBUN.Text                             '保留区分(表示用)

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
        strSQL &= vbCrLf & "    TRST_STOCK.FPALLET_ID "                     '在庫情報.          ﾊﾟﾚｯﾄID
        strSQL &= vbCrLf & "  , TRST_STOCK.FHINMEI_CD "                     '在庫情報.          品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "  , TMST_ITEM.FHINMEI "                         '品目ﾏｽﾀ.           品名
        strSQL &= vbCrLf & "  , TRST_STOCK.XSEIZOU_DT "                     '在庫情報.          製造年月日
        strSQL &= vbCrLf & "  , TRST_STOCK.XLINE_NO "                       '在庫情報.          ﾗｲﾝ№
        strSQL &= vbCrLf & "  , TRST_STOCK.XPALLET_NO "                     '在庫情報.          ﾊﾟﾚｯﾄ№
        strSQL &= vbCrLf & "  , TRST_STOCK.XSYUKKA_KAHI "                   '在庫情報.          出荷可否
        strSQL &= vbCrLf & "  , HASH01.FGAMEN_DISP AS XSYUKKA_KAHI_DSP "    '在庫情報.          出荷可否(表示用)
        strSQL &= vbCrLf & "  , TRST_STOCK.XHINSHITU_STS "                  '在庫情報.          品質ｽﾃｰﾀｽ
        strSQL &= vbCrLf & "  , HASH02.FGAMEN_DISP AS XHINSHITU_STS_DSP "   '在庫情報.          品質ｽﾃｰﾀｽ(表示用)
        strSQL &= vbCrLf & "  , TRST_STOCK.FHORYU_KUBUN "                   '在庫情報.          保留区分
        strSQL &= vbCrLf & "  , HASH03.FGAMEN_DISP AS FHORYU_KUBUN_DSP "    '在庫情報.          保留区分(表示用)
        strSQL &= vbCrLf & "  , TRST_STOCK.FTR_VOL "                        '在庫情報.          搬送管理量(数量)
        strSQL &= vbCrLf & "  , TPRG_TRK_BUF.FDISP_ADDRESS "                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      ﾛｹｰｼｮﾝ

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    TPRG_TRK_BUF "                          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
        strSQL &= vbCrLf & "  , TRST_STOCK "                            '在庫情報
        strSQL &= vbCrLf & "  , TMST_ITEM "                             '品目ﾏｽﾀ
        strSQL &= vbCrLf & "  , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH01", "TRST_STOCK", "XSYUKKA_KAHI")
        strSQL &= vbCrLf & "  , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH02", "TRST_STOCK", "XHINSHITU_STS")
        strSQL &= vbCrLf & "  , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH03", "TRST_STOCK", "FHORYU_KUBUN")

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE 1 = 1  "
        strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FPALLET_ID  = TRST_STOCK.FPALLET_ID(+) "
        strSQL &= vbCrLf & "    AND TRST_STOCK.FHINMEI_CD = TMST_ITEM.FHINMEI_CD(+) "
        strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FRES_KIND = " & TO_STRING(FRES_KIND_SZAIKO)      '引当状態 = 「在庫棚」
        strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FPALLET_ID NOT IN( "                             '在庫棚(未引当)
        strSQL &= vbCrLf & "                (SELECT FPALLET_ID FROM XSTS_HIKIATE_K1) "
        strSQL &= vbCrLf & "                                    ) "
        strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FPALLET_ID NOT IN( "                             '在庫棚(未引当)
        strSQL &= vbCrLf & "                (SELECT FPALLET_ID FROM TSTS_HIKIATE) "
        strSQL &= vbCrLf & "                                    ) "
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH01", "TRST_STOCK", "XSYUKKA_KAHI")
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH02", "TRST_STOCK", "XHINSHITU_STS")
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH03", "TRST_STOCK", "FHORYU_KUBUN")
        'strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FTRK_BUF_NO = " & FTRK_BUF_NO_J9000              '自動倉庫
        strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FTRK_BUF_NO = " & mudtSEARCH_ITEM.FTRK_BUF_NO_FM  '移動元

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
        '出荷可否
        '----------------------------------------------
        If mudtSEARCH_ITEM.XSYUKKA_KAHI <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "      AND TRST_STOCK.XSYUKKA_KAHI = " & mudtSEARCH_ITEM.XSYUKKA_KAHI
        End If

        '----------------------------------------------
        '品質ｽﾃｰﾀｽ
        '----------------------------------------------
        If mudtSEARCH_ITEM.XHINSHITU_STS <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "      AND TRST_STOCK.XHINSHITU_STS = " & mudtSEARCH_ITEM.XHINSHITU_STS
        End If

        '----------------------------------------------
        '保留区分
        '----------------------------------------------
        If mudtSEARCH_ITEM.FHORYU_KUBUN <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "      AND TRST_STOCK.FHORYU_KUBUN = " & mudtSEARCH_ITEM.FHORYU_KUBUN
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
#Region "　ﾌﾟﾛﾊﾟﾃｨｾｯﾄ(倉替え設定)　                 "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub SetProperty(ByVal objForm As FRM_303061)

        objForm.userPALLET_ID = mstrFPALLET_ID                                      'ﾊﾟﾚｯﾄID

        objForm.userFTRK_BUF_NO_FM = mudtSEARCH_ITEM.FTRK_BUF_NO_FM                 '倉替え元
        objForm.userFTRK_BUF_NO_TO = mudtSEARCH_ITEM.FTRK_BUF_NO_TO                 '倉替え先

        objForm.userFTRK_BUF_NM_FM = mudtSEARCH_ITEM.FTRK_BUF_NM_FM                 '倉替え元
        objForm.userFTRK_BUF_NM_TO = mudtSEARCH_ITEM.FTRK_BUF_NM_TO                 '倉替え先

        objForm.userFHINMEI_CD = mudtSEARCH_ITEM.FHINMEI_CD                         '品名ｺｰﾄﾞ
        objForm.userFHINMEI = mudtSEARCH_ITEM.FHINMEI                               '品名
        objForm.userXSEIZOU_DT = mudtSEARCH_ITEM.XSEIZOU_DT                         '製造年月日
        objForm.userXLINE_NO = mudtSEARCH_ITEM.XLINE_NO                             'ﾗｲﾝ№
        objForm.userXSYUKKA_KAHI = mudtSEARCH_ITEM.XSYUKKA_KAHI                     '出荷可否
        objForm.userXHINSHITU_STS = mudtSEARCH_ITEM.XHINSHITU_STS                   '品質ｽﾃｰﾀｽ
        objForm.userFHORYU_KUBUN = mudtSEARCH_ITEM.FHORYU_KUBUN                     '保留区分
        objForm.userXSYUKKA_KAHI_DSP = mudtSEARCH_ITEM.XSYUKKA_KAHI_DSP             '出荷可否(表示用)
        objForm.userXHINSHITU_STS_DSP = mudtSEARCH_ITEM.XHINSHITU_STS_DSP           '品質ｽﾃｰﾀｽ(表示用)
        objForm.userFHORYU_KUBUN_DSP = mudtSEARCH_ITEM.FHORYU_KUBUN_DSP             '保留区分(表示用)

    End Sub
#End Region

End Class
