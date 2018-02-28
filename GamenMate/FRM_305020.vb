'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】出荷可否ﾒﾝﾃﾅﾝｽ
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_305020
#Region "　共通変数　                               "

    Private mFlag_Form_Load As Boolean = True                   '画面展開ﾌﾗｸﾞ
    Private mFlag_GRID_CLEAR As Boolean = True                  'ｸﾞﾘｯﾄﾞｸﾘｱ済みﾌﾗｸﾞ
    Private mflag_CboFHINMEI_CD_Change As Boolean = False       '品名ｺｰﾄﾞｺﾝﾎﾞ更新
    Private mflag_CboXSEIZOU_DT_Change As Boolean = False       '製造年月日ｺﾝﾎﾞ更新

    '検索条件用構造体
    Private mudtSEARCH_ITEM As New SEARCH_ITEM

    '選択されたﾊﾟﾚｯﾄID、在庫ﾛｯﾄ№の配列
    Public mstrFPALLET_ID() As String = Nothing
    Public mstrFLOT_NO_STOCK() As String = Nothing

    'ｸﾞﾘｯﾄﾞ項目
    Enum menmListCol
        XLINE_NO                    '在庫情報.          (非表示)ﾗｲﾝ№
        FHINMEI_CD                  '在庫情報.          (非表示)品名ｺｰﾄﾞ
        XSEIZOU_DT                  '在庫情報.          (非表示)製造年月日
        FPALLET_ID                  '在庫情報.          (非表示)ﾊﾟﾚｯﾄID
        FLOT_NO_STOCK               '在庫情報.          (非表示)ﾛｯﾄ№
        FPALLET_NO                  '在庫情報.                  ﾊﾟﾚｯﾄNO
        XSYUKKA_KAHI                '在庫情報.          (非表示)出荷可否
        XSYUKKA_KAHI_DSP            '在庫情報.                  出荷可否(表示用)
        FTRK_BUF_NO                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      (非表示)ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        FBUF_NAME                   'ﾄﾗｯｷﾝｸﾞﾏｽﾀ.                ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称
        FTR_VOL                     '在庫情報.                  搬送管理量(数量)
        FHORYU_KUBUN                '在庫情報.          (非表示)保留区分
        FHORYU_KUBUN_DSP            '在庫情報.                  保留区分(表示用)
        XHINSHITU_STS               '在庫情報.          (非表示)品質ｽﾃｰﾀｽ
        XHINSHITU_STS_DSP           '在庫情報.                  品質ｽﾃｰﾀｽ(表示用)
        FARRIVE_DT                  '在庫情報.                  在庫発生日時

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
        Dim XLINE_NO As String          'ﾗｲﾝ№
        Dim FHINMEI_CD As String        '品名ｺｰﾄﾞ
        Dim XSEIZOU_DT As String        '製造年月日
        Dim FPALLET_NO_FROM As String   'ﾊﾟﾚｯﾄNO FROM
        Dim FPALLET_NO_TO As String     'ﾊﾟﾚｯﾄNO TO
        Dim XSYUKKA_KAHI As String      '出荷可否
        Dim FPLACE_CD As String         '保管場所
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
#Region "　ﾗｲﾝ№ｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞ       ｲﾍﾞﾝﾄ      "
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
                '出荷可否 ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
                '===================================
                cboFHINMEI_CD.Text = ""                          '品名ｺｰﾄﾞ

                cboFHINMEI_CD.conn = gobjDb
                cboFHINMEI_CD.HinmeiLabel = lblFHINMEI
                cboFHINMEI_CD.Text = ""
                cboFHINMEI_CD.TableName = "TRST_STOCK"
                cboFHINMEI_CD.ComboBoxType = GamenCommon.cmpCboFHINMEI_CD.HINMEI_CBO_TYPE.SpecifiedAndMasterData
                cboFHINMEI_CD.HinmeiVisible = False
                cboFHINMEI_CD.FRES_KIND = FRES_KIND_SZAIKO                  '引当状態 = 「在庫棚」
                cboFHINMEI_CD.XLINE_NO = cboXLINE_NO.Text                   'ﾗｲﾝ№
                cboFHINMEI_CD.cboSetupHinmeiCd(cboFHINMEI_CD.Text)          '品名ｺｰﾄﾞ

                Call MakeSyukkaKahi_cboXSEIZOU_DT(cboXLINE_NO.Text, cboFHINMEI_CD.Text, cboXSEIZOU_DT, True)                            '製造年月日
                Call MakeSyukkaKahi_cboXPALLET_NO(cboXLINE_NO.Text, cboFHINMEI_CD.Text, TO_STRING(cboXSEIZOU_DT.SelectedValue), cboXPALLET_NO_FROM, True)   'ﾊﾟﾚｯﾄ№ FROM
                Call MakeSyukkaKahi_cboXPALLET_NO(cboXLINE_NO.Text, cboFHINMEI_CD.Text, TO_STRING(cboXSEIZOU_DT.SelectedValue), cboXPALLET_NO_TO, True)     'ﾊﾟﾚｯﾄ№ TO
                cboXSYUKKA_KAHI.SelectedIndex = -1      '出荷可否

                Call MakeSyukkaKahi_cboFPLACE_CD(cboXLINE_NO.Text, cboFHINMEI_CD.Text, TO_STRING(cboXSEIZOU_DT.SelectedValue), cboFPLACE_CD, True)          '保管場所

                If mFlag_GRID_CLEAR = False Then
                    '*********************************************
                    ' ｸﾞﾘｯﾄﾞ表示
                    '*********************************************
                    grdList.Columns.Clear()
                    Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
                    Call grdListSetup()

                    mFlag_GRID_CLEAR = True
                End If

                mflag_CboFHINMEI_CD_Change = True
                mflag_CboXSEIZOU_DT_Change = True

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
                '出荷可否 ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
                '===================================
                Call MakeSyukkaKahi_cboXSEIZOU_DT(cboXLINE_NO.Text, cboFHINMEI_CD.Text, cboXSEIZOU_DT, True)                            '製造年月日
                Call MakeSyukkaKahi_cboXPALLET_NO(cboXLINE_NO.Text, cboFHINMEI_CD.Text, cboXSEIZOU_DT.Text, cboXPALLET_NO_FROM, True)   'ﾊﾟﾚｯﾄ№ FROM
                Call MakeSyukkaKahi_cboXPALLET_NO(cboXLINE_NO.Text, cboFHINMEI_CD.Text, cboXSEIZOU_DT.Text, cboXPALLET_NO_TO, True)     'ﾊﾟﾚｯﾄ№ TO
                cboXSYUKKA_KAHI.SelectedIndex = -1      '出荷可否

                Call MakeSyukkaKahi_cboFPLACE_CD(cboXLINE_NO.Text, cboFHINMEI_CD.Text, cboXSEIZOU_DT.Text, cboFPLACE_CD, True)          '保管場所


                If mFlag_GRID_CLEAR = False Then
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
#Region "　製造年月日ｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞ    ｲﾍﾞﾝﾄ    "
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
                '出荷可否 ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
                '===================================
                If mflag_CboXSEIZOU_DT_Change = True Then
                    '(製造年月日ｺﾝﾎﾞ更新ありの時)
                    mflag_CboXSEIZOU_DT_Change = False

                Else
                    '(製造年月日ｺﾝﾎﾞ更新なしの時)
                    Call MakeSyukkaKahi_cboXPALLET_NO(cboXLINE_NO.Text, cboFHINMEI_CD.Text, TO_STRING(cboXSEIZOU_DT.SelectedValue), cboXPALLET_NO_FROM, True)   'ﾊﾟﾚｯﾄ№ FROM
                    Call MakeSyukkaKahi_cboXPALLET_NO(cboXLINE_NO.Text, cboFHINMEI_CD.Text, TO_STRING(cboXSEIZOU_DT.SelectedValue), cboXPALLET_NO_TO, True)     'ﾊﾟﾚｯﾄ№ TO
                    cboXSYUKKA_KAHI.SelectedIndex = -1      '出荷可否

                    Call MakeSyukkaKahi_cboFPLACE_CD(cboXLINE_NO.Text, cboFHINMEI_CD.Text, TO_STRING(cboXSEIZOU_DT.SelectedValue), cboFPLACE_CD, True)          '保管場所

                End If

                If mFlag_GRID_CLEAR = False Then
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
        '出荷可否 ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
        '===================================
        Call MakeSyukkaKahi_cboXLINE_NO(cboXLINE_NO, True)                                                                      'ﾗｲﾝ№

        cboFHINMEI_CD.conn = gobjDb
        cboFHINMEI_CD.HinmeiLabel = lblFHINMEI
        cboFHINMEI_CD.Text = ""
        cboFHINMEI_CD.TableName = "TRST_STOCK"
        cboFHINMEI_CD.ComboBoxType = GamenCommon.cmpCboFHINMEI_CD.HINMEI_CBO_TYPE.SpecifiedAndMasterData
        cboFHINMEI_CD.HinmeiVisible = False
        cboFHINMEI_CD.FRES_KIND = FRES_KIND_SZAIKO                                             '引当状態 = 「在庫棚」
        cboFHINMEI_CD.cboSetupHinmeiCd(cboFHINMEI_CD.Text)          '品名ｺｰﾄﾞ

        Call MakeSyukkaKahi_cboXSEIZOU_DT(cboXLINE_NO.Text, cboFHINMEI_CD.Text, cboXSEIZOU_DT, True)                            '製造年月日
        Call MakeSyukkaKahi_cboXPALLET_NO(cboXLINE_NO.Text, cboFHINMEI_CD.Text, TO_STRING(cboXSEIZOU_DT.SelectedValue), cboXPALLET_NO_FROM, True)   'ﾊﾟﾚｯﾄ№ FROM
        Call MakeSyukkaKahi_cboXPALLET_NO(cboXLINE_NO.Text, cboFHINMEI_CD.Text, TO_STRING(cboXSEIZOU_DT.SelectedValue), cboXPALLET_NO_TO, True)     'ﾊﾟﾚｯﾄ№ TO
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboXSYUKKA_KAHI, True)        '出荷可否
        Call MakeSyukkaKahi_cboFPLACE_CD(cboXLINE_NO.Text, cboFHINMEI_CD.Text, TO_STRING(cboXSEIZOU_DT.SelectedValue), cboFPLACE_CD, True)          '保管場所


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
        cboXLINE_NO.Dispose()               'ﾗｲﾝ№
        cboFHINMEI_CD.Dispose()             '品名ｺｰﾄﾞ
        cboXSEIZOU_DT.Dispose()             '製造年月日
        cboXPALLET_NO_FROM.Dispose()        'ﾊﾟﾚｯﾄ№ FROM
        cboXPALLET_NO_TO.Dispose()          'ﾊﾟﾚｯﾄ№ TO
        cboXSYUKKA_KAHI.Dispose()           '出荷可否
        cboFPLACE_CD.Dispose()              '保管場所
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
        If IsNull(gobjFRM_305021) = False Then
            gobjFRM_305021.Close()
            gobjFRM_305021.Dispose()
            gobjFRM_305021 = Nothing
        End If

        '********************************************************************
        ' 子画面展開
        '********************************************************************
        gobjFRM_305021 = New FRM_305021                             'ｵﾌﾞｼﾞｪｸﾄ作成

        Call SetProperty(gobjFRM_305021)                  'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        Call gobjFRM_305021.ShowDialog()        '画面表示


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
                'ﾗｲﾝ№  選択ﾁｪｯｸ
                '==========================
                If TO_STRING(cboXLINE_NO.SelectedValue.ToString) = CBO_ALL_VALUE _
                    Or IsNull(TO_STRING(cboXLINE_NO.SelectedValue.ToString)) = True Then
                    '(ﾗｲﾝ№が選択されていない場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM305020_01, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If

                '==========================
                '品名ｺｰﾄﾞ  選択ﾁｪｯｸ
                '==========================
                If cboFHINMEI_CD.Text = "" Then
                    '(品名ｺｰﾄﾞが選択されていない場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM305020_02, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If

                '==========================
                '製造年月日  選択ﾁｪｯｸ
                '==========================
                If TO_STRING(cboXSEIZOU_DT.SelectedValue.ToString) = CBO_ALL_VALUE _
                    Or IsNull(TO_STRING(cboXSEIZOU_DT.SelectedValue.ToString)) = True Then
                    '(製造年月日が選択されていない場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM305020_03, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If


                '==========================
                'ﾊﾟﾚｯﾄ№  FROM,TO 大小ﾁｪｯｸ
                '==========================
                If (cboXPALLET_NO_FROM.Text <> "") And _
                  (cboXPALLET_NO_TO.Text <> "") Then
                    If (TO_STRING(cboXPALLET_NO_FROM.SelectedValue.ToString) > TO_STRING(cboXPALLET_NO_TO.SelectedValue.ToString)) Then
                        '(ﾊﾟﾚｯﾄ№の大小が間違っている場合)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM305020_04, PopupFormType.Ok, PopupIconType.Information)
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
        mudtSEARCH_ITEM.XLINE_NO = TO_STRING(cboXLINE_NO.SelectedValue)                'ﾗｲﾝ№
        mudtSEARCH_ITEM.FHINMEI_CD = cboFHINMEI_CD.Text                                '品名ｺｰﾄﾞ
        mudtSEARCH_ITEM.XSEIZOU_DT = TO_STRING(cboXSEIZOU_DT.SelectedValue)            '製造年月日
        mudtSEARCH_ITEM.FPALLET_NO_FROM = TO_STRING(cboXPALLET_NO_FROM.SelectedValue)  'ﾊﾟﾚｯﾄNO FROM
        mudtSEARCH_ITEM.FPALLET_NO_TO = TO_STRING(cboXPALLET_NO_TO.SelectedValue)      'ﾊﾟﾚｯﾄNO TO
        mudtSEARCH_ITEM.XSYUKKA_KAHI = TO_STRING(cboXSYUKKA_KAHI.SelectedValue)        '出荷可否
        mudtSEARCH_ITEM.FPLACE_CD = TO_STRING(cboFPLACE_CD.SelectedValue)              '保管場所

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
        strSQL &= vbCrLf & "    TRST_STOCK.XLINE_NO "                       '在庫情報.          (非表示)ﾗｲﾝ№
        strSQL &= vbCrLf & "  , TRST_STOCK.FHINMEI_CD "                     '在庫情報.          (非表示)品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "  , TRST_STOCK.XSEIZOU_DT "                     '在庫情報.          (非表示)製造年月日
        strSQL &= vbCrLf & "  , TRST_STOCK.FPALLET_ID "                     '在庫情報.          (非表示)ﾊﾟﾚｯﾄID
        strSQL &= vbCrLf & "  , TRST_STOCK.FLOT_NO_STOCK "                  '在庫情報.          (非表示)ﾛｯﾄ№
        strSQL &= vbCrLf & "  , TRST_STOCK.XPALLET_NO "                     '在庫情報.                  ﾊﾟﾚｯﾄNO
        strSQL &= vbCrLf & "  , TRST_STOCK.XSYUKKA_KAHI "                   '在庫情報.          (非表示)出荷可否
        strSQL &= vbCrLf & "  , HASH01.FGAMEN_DISP AS XSYUKKA_KAHI_DSP "    '在庫情報.                  出荷可否(表示用)
        strSQL &= vbCrLf & "  , TPRG_TRK_BUF.FTRK_BUF_NO "                  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      (非表示)ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        strSQL &= vbCrLf & "  , TMST_TRK.FBUF_NAME "                        'ﾄﾗｯｷﾝｸﾞﾏｽﾀ.                ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称
        strSQL &= vbCrLf & "  , TRST_STOCK.FTR_VOL "                        '在庫情報.                  搬送管理量(数量)
        strSQL &= vbCrLf & "  , TRST_STOCK.FHORYU_KUBUN "                   '在庫情報.          (非表示)保留区分
        strSQL &= vbCrLf & "  , HASH02.FGAMEN_DISP AS FHORYU_KUBUN_DSP "    '在庫情報.                  保留区分(表示用)
        strSQL &= vbCrLf & "  , TRST_STOCK.XHINSHITU_STS "                  '在庫情報.          (非表示)品質ｽﾃｰﾀｽ
        strSQL &= vbCrLf & "  , HASH03.FGAMEN_DISP AS XHINSHITU_STS_DSP "   '在庫情報.                  品質ｽﾃｰﾀｽ(表示用)
        strSQL &= vbCrLf & "  , TRST_STOCK.FARRIVE_DT "                     '在庫情報.                  在庫発生日時

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    TMST_TRK "                              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ
        strSQL &= vbCrLf & "  , TPRG_TRK_BUF "                          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
        strSQL &= vbCrLf & "  , TRST_STOCK "                            '在庫情報
        strSQL &= vbCrLf & "  , TMST_ITEM "                             '品目ﾏｽﾀ
        strSQL &= vbCrLf & "  , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH01", "TRST_STOCK", "XSYUKKA_KAHI")
        strSQL &= vbCrLf & "  , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH02", "TRST_STOCK", "FHORYU_KUBUN")
        strSQL &= vbCrLf & "  , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH03", "TRST_STOCK", "XHINSHITU_STS")
 
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
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH01", "TRST_STOCK", "XSYUKKA_KAHI")
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH02", "TRST_STOCK", "FHORYU_KUBUN")
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH03", "TRST_STOCK", "XHINSHITU_STS")

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
        '出荷可否
        '----------------------------------------------
        If mudtSEARCH_ITEM.XSYUKKA_KAHI <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "      AND TRST_STOCK.XSYUKKA_KAHI = " & mudtSEARCH_ITEM.XSYUKKA_KAHI
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

        '----------------------------------------------
        '保管場所
        '----------------------------------------------
        If mudtSEARCH_ITEM.FPLACE_CD <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "      AND TPRG_TRK_BUF.FTRK_BUF_NO = " & mudtSEARCH_ITEM.FPLACE_CD
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
    Private Sub SetProperty(ByVal objForm As FRM_305021)

        objForm.userPALLET_ID = mstrFPALLET_ID                'ﾊﾟﾚｯﾄID
        objForm.userFLOT_NO_STOCK = mstrFLOT_NO_STOCK         '在庫ﾛｯﾄ№

    End Sub
#End Region

End Class
