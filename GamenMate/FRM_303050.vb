'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】問合せ出庫設定
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_303050
#Region "　共通変数　                               "

    Private mFlag_Form_Load As Boolean = True                   '画面展開ﾌﾗｸﾞ

    '検索条件用構造体
    Private mudtSEARCH_ITEM As New SEARCH_ITEM

    '選択されたﾊﾟﾚｯﾄIDの配列
    Public mstrFPALLET_ID() As String = Nothing

    'ｸﾞﾘｯﾄﾞ項目
    Enum menmListCol
        FPALLET_ID                  '在庫情報.          ﾊﾟﾚｯﾄID
        FHINMEI_CD                  '在庫情報.          品名ｺｰﾄﾞ
        FHINMEI                     '品目ﾏｽﾀ.           品名
        XSEIZOU_DT                  '在庫情報.          製造年月日
        XLINE_NO                    '在庫情報.          ﾗｲﾝ№
        XPALLET_NO                  '在庫情報.          ﾊﾟﾚｯﾄ№
        XSYUKKA_KAHI                '在庫情報.          出荷可否
        XSYUKKA_KAHI_DSP            '在庫情報.          出荷可否(表示用)
        XHINSHITU_STS               '在庫情報.          品質ｽﾃｰﾀｽ
        XHINSHITU_STS_DSP           '在庫情報.          品質ｽﾃｰﾀｽ(表示用)
        FHORYU_KUBUN                '在庫情報.          保留区分
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
        OutReg_Click                    '出庫登録ﾎﾞﾀﾝｸﾘｯｸ時
        STModeBtn_Click                 'ﾓｰﾄﾞ切替ﾎﾞﾀﾝｸﾘｯｸ時
    End Enum

#End Region
#Region "  構造体定義                               "
    '検索条件
    Private Structure SEARCH_ITEM
        Dim FHINMEI_CD As String        '品名ｺｰﾄﾞ
        Dim XSEIZOU_DT As String        '製造年月日
        Dim XLINE_NO As String          'ﾗｲﾝ№
        Dim XSYUKKA_KAHI As String      '出荷可否
        Dim XHINSHITU_STS As String     '品質ｽﾃｰﾀｽ
        Dim FHORYU_KUBUN As String      '保留区分
    End Structure
    'ｿｹｯﾄ送信情報
    Private Structure STOCK_DATA
        Dim DSPPALLET_ID As String      'ﾊﾟﾚｯﾄID
        Dim DSPST_OUT As String         '出庫先ST
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
                Call MakeToiawaseSyukko_cboXLINE_NO(cboFHINMEI_CD.Text, cboXLINE_NO, TO_STRING(FTRK_BUF_NO_J9000), True)             'ﾗｲﾝ№

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
#Region "　台車№ｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞ       ｲﾍﾞﾝﾄ     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 台車№ｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cboFTRK_BUF_NO_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFTRK_BUF_NO.SelectedIndexChanged
        Try

            If mFlag_Form_Load = False Then

                If cboFTRK_BUF_NO.Enabled = False Then
                    '(台車№ｺﾝﾎﾞ無効の時）
                    btnSTMode.Text = ""                        '台車・状態
                    btnSTMode.BackColor = gcModeColor_Black
                Else
                    '(台車№ｺﾝﾎﾞ有効の時）
                    '**********************************************************
                    ' ﾗﾍﾞﾙ設定
                    '**********************************************************
                    tmr303050.Enabled = False
                    Call gobjComFuncFRM.AlterButtonColorMOD(btnSTMode, TO_STRING(cboFTRK_BUF_NO.SelectedValue), LBL_DSPTYPE.STSNAME)
                    tmr303050.Enabled = True
                End If

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
    Private Sub tmr303050_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr303050.Tick
        Try

            tmr303050.Enabled = False

            '**************************************************
            ' ﾓｰﾄﾞ取得ﾀｲﾏｰ処理
            '**************************************************
            Call tmr303050_TickProcess()

        Catch ex As Exception
            ComError(ex)

        Finally
            tmr303050.Enabled = True

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
        Call gobjComFuncFRM.cboSetup(Me.Name, cboFTRK_BUF_NO, False)

        btnSTMode.Text = ""                          '出庫ST・状態
        btnSTMode.BackColor = gcModeColor_Black

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
        Call MakeToiawaseSyukko_cboXLINE_NO(cboFHINMEI_CD.Text, cboXLINE_NO, TO_STRING(FTRK_BUF_NO_J9000), True)             'ﾗｲﾝ№

        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboXSYUKKA_KAHI, True)                   '出荷可否
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboXHINSHITU_STS, True)                  '品質ｽﾃｰﾀｽ
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboFHORYU_KUBUN, True)                   '保留区分


        '*********************************************
        ' ﾃｷｽﾄﾎﾞｯｸｽ初期設定
        '*********************************************
        lblFHINMEI.Text = ""

        '*********************************************
        ' ｸﾞﾘｯﾄﾞ初期化
        '*********************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListSetup()

        '**************************************************
        ' ﾓｰﾄﾞ取得ﾀｲﾏｰ処理
        '**************************************************
        Call tmr303050_TickProcess()

        '**********************************************************
        ' ﾀｲﾏｰ設定
        '**********************************************************
        tmr303050.Interval = TO_INTEGER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_JGS303050_001))
        tmr303050.Enabled = True

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
        cboFTRK_BUF_NO.Dispose()             '出庫ST
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
#Region "  F6(出庫登録)     ﾎﾞﾀﾝ押下処理　          "
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
        If InputCheck(menmCheckCase.OutReg_Click) = False Then
            Exit Sub
        End If

        tmr303050.Enabled = False

        Call InquiryOut()                                         '出庫登録

        tmr303050.Enabled = True

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

        Dim intRet As RetCode                   '戻り値

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        Select Case udtCheck_Case
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


                '*********************************************
                'ｸﾚｰﾝ状態ﾁｪｯｸ
                '*********************************************
                'Dim intRet As RetCode
                Dim strMsg As String = ""

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
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303050_07, PopupFormType.Ok, PopupIconType.Information)
                        blnCheckErr = True
                        Exit Select
                    End If

                Next


                '*********************************************
                'STﾓｰﾄﾞ ﾁｪｯｸ
                '*********************************************
                If gobjComFuncFRM.CheckFEQ_STS(TO_STRING(cboFTRK_BUF_NO.SelectedValue), FEQ_STS_JINOUTMODE_OUT, FRM_MSG_SYS_ERROR_27, FEQ_STS_JINOUTMODE_OUT) = False Then
                    blnCheckErr = True
                    Exit Select
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


            Case menmCheckCase.STModeBtn_Click
                '(ﾓｰﾄﾞ切替ﾎﾞﾀﾝｸﾘｯｸ時)

                'Dim strSTMode As String = ""        '設備状態
                'strSTMode = gobjComFuncFRM.GetFEQ_STS(TO_STRING(cboFTRK_BUF_NO.SelectedValue))
                Dim intST_RtnCd As Integer = gobjComFuncFRM.GetFEQ_STS(TO_STRING(cboFTRK_BUF_NO.SelectedValue), True, False, True)
                If (intST_RtnCd <> 1) And (intST_RtnCd <> 2) Then
                    '(設備状態が変更できないとき)
                    blnCheckErr = True
                    Exit Select
                End If

                'If strSTMode = "" Then
                '    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303050_04, PopupFormType.Ok, PopupIconType.Information)
                '    blnCheckErr = True
                '    Exit Select
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
        mudtSEARCH_ITEM.FHINMEI_CD = cboFHINMEI_CD.Text                                     '品名ｺｰﾄﾞ
        mudtSEARCH_ITEM.XSEIZOU_DT = TO_STRING(cboXSEIZOU_DT.SelectedValue)                 '製造年月日
        mudtSEARCH_ITEM.XLINE_NO = TO_STRING(cboXLINE_NO.SelectedValue)                     'ﾗｲﾝ№
        mudtSEARCH_ITEM.XSYUKKA_KAHI = TO_STRING(cboXSYUKKA_KAHI.SelectedValue)             '出荷可否
        mudtSEARCH_ITEM.XHINSHITU_STS = TO_STRING(cboXHINSHITU_STS.SelectedValue)           '品質ｽﾃｰﾀｽ
        mudtSEARCH_ITEM.FHORYU_KUBUN = TO_STRING(cboFHORYU_KUBUN.SelectedValue)             '保留区分

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
        strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FTRK_BUF_NO = " & FTRK_BUF_NO_J9000              '自動倉庫

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
#Region "  ｿｹｯﾄ送信03   問合せ出庫処理            　"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub InquiryOut()

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        udtRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM303050_09, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Sub
        End If


        '********************************************************************
        ' 出庫在庫ﾃﾞｰﾀｾｯﾄ
        '********************************************************************
        Dim udtOUT_STOCK() As STOCK_DATA = Nothing      '出庫在庫ﾃﾞｰﾀ用構造体
        Dim strSndTlgrm() As String = Nothing           '送信電文文字列
        Dim intHairetu As Integer = 0                   '配列数
        Dim intRet As RetCode
        Dim strMsg As String = ""
        Dim strOUTST_NO As String = ""                  'ｽﾃｰｼｮﾝID


        For ii As Integer = LBound(mstrFPALLET_ID) To UBound(mstrFPALLET_ID)
            '(展開元画面の行分ﾙｰﾌﾟ)


            '=============================================
            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧTBL
            '=============================================
            Dim objTPRG_TRK_BUF As New TBL_TPRG_TRK_BUF(gobjOwner, gobjDb, Nothing)         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾃｰﾌﾞﾙｸﾗｽ
            objTPRG_TRK_BUF.FPALLET_ID = mstrFPALLET_ID(ii)                                 'ﾊﾟﾚｯﾄID
            objTPRG_TRK_BUF.FTRK_BUF_NO = FTRK_BUF_NO_J9000                                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
            intRet = objTPRG_TRK_BUF.GET_TPRG_TRK_BUF(True)                                 '特定


            '配列再定義
            intHairetu = intHairetu + 1
            ReDim Preserve strSndTlgrm(0 To intHairetu - 1)     '送信電文文字列
            ReDim Preserve udtOUT_STOCK(0 To intHairetu - 1)    '出庫在庫ﾃﾞｰﾀ用構造体

            '電文情報取得
            udtOUT_STOCK(intHairetu - 1).DSPPALLET_ID = mstrFPALLET_ID(ii)                  'ﾊﾟﾚｯﾄID

            '**strOUTST_NO = FTRK_BUF_NO_J101
            strOUTST_NO = TO_STRING(cboFTRK_BUF_NO.SelectedValue)

            udtOUT_STOCK(intHairetu - 1).DSPST_OUT = strOUTST_NO                                               '出庫先ｽﾃｰｼｮﾝ


            Dim objTelegramSub As New clsTelegram(CONFIG_TELEGRAM_DSP)

            objTelegramSub.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S201601

            objTelegramSub.SETIN_HEADER("DSPCMD_ID", Microsoft.VisualBasic.Right(objTelegramSub.FORMAT_ID, 6)) 'ｺﾏﾝﾄﾞID
            objTelegramSub.SETIN_HEADER("DSPTERM_ID", gcstrFTERM_ID)                                           '端末ID
            objTelegramSub.SETIN_HEADER("DSPUSER_ID", gcstrFUSER_ID)                                           '担当者ｺｰﾄﾞ

            objTelegramSub.SETIN_DATA("DSPPALLET_ID", udtOUT_STOCK(intHairetu - 1).DSPPALLET_ID)               'ﾊﾟﾚｯﾄID
            objTelegramSub.SETIN_DATA("DSPST_OUT", udtOUT_STOCK(intHairetu - 1).DSPST_OUT)                     '出庫先ST

            objTelegramSub.MAKE_TELEGRAM()
            strSndTlgrm(intHairetu - 1) = objTelegramSub.TELEGRAM_MAKED                                        '送信電文

        Next


        '********************************************************************
        ' 複数ｿｹｯﾄ処理
        '********************************************************************
        Dim blnPlmSockCmp As Boolean            'ﾊﾟﾗﾒｰﾀ通知ｿｹｯﾄ送信完了ﾌﾗｸﾞ
        Dim strRetState() As String = Nothing   '出庫処理戻りｽﾃｰﾀｽ
        Dim strErrMsg As String = ""            'ｴﾗｰﾒｯｾｰｼﾞ
        '=====================================
        '複数ｿｹｯﾄ処理
        '=====================================
        Call gobjComFuncFRM.SockSendServer03(strSndTlgrm, blnPlmSockCmp, strRetState)

        If blnPlmSockCmp = True Then
            '(正常終了またはﾀｲﾑｱｳﾄの場合)
            For ii As Integer = 0 To UBound(strRetState)
                '(受信電文分ﾙｰﾌﾟ)
                If strRetState(ii) = ID_RETURN_RET_STATE_OK Then
                    '(正常終了の場合)
                    'Me.DialogResult = Windows.Forms.DialogResult.OK
                    'Me.Close()
                    'Me.Dispose()
                Else
                    '(処理が異常終了した場合)
                    strErrMsg = FRM_MSG_FRM303050_10
                    Call gobjComFuncFRM.DisplayPopup(strErrMsg, PopupFormType.Ok, PopupIconType.Err)
                End If
            Next
        End If

    End Sub
#End Region
#Region "  ﾓｰﾄﾞ取得ﾀｲﾏｰ処理                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 設備状態取得ﾀｲﾏｰ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tmr303050_TickProcess()

        '**********************************************************
        ' ﾗﾍﾞﾙ背景色変更処理
        '**********************************************************
        Call gobjComFuncFRM.AlterButtonColorMOD(btnSTMode, TO_STRING(cboFTRK_BUF_NO.SelectedValue), LBL_DSPTYPE.STSNAME)

    End Sub
#End Region
#Region "  ﾓｰﾄﾞ切替ﾎﾞﾀﾝ処理                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾓｰﾄﾞ切替ﾎﾞﾀﾝ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub btnSTMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSTMode.Click

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.STModeBtn_Click) = False Then
            Exit Sub
        End If

        '********************************************************************
        'ｿｹｯﾄ送信処理
        '********************************************************************
        If gobjComFuncFRM.STModeChange(TO_STRING(cboFTRK_BUF_NO.SelectedValue)) = False Then
            Exit Sub
        End If

    End Sub
#End Region

End Class
