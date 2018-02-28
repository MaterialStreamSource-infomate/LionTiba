'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】在庫ﾒﾝﾃﾅﾝｽ画面
' 【作成】SIT
'               ※今回は保管場所にﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№をｾｯﾄする
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_205040

#Region "　共通変数　                       "

    Private mudtSEARCH_ITEM As New stcSEARCH_ITEM       '検索条件用構造体

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ

    ''' <summary>ｸﾞﾘｯﾄﾞ項目</summary>
    Enum menmListCol
        FTRK_BUF_NO                 '(非表示)ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        FTRK_BUF_ARRAY              '(非表示)ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      配列№
        FPALLET_ID                  '(非表示)ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      ﾊﾟﾚｯﾄID
        FLOT_NO_STOCK               '(非表示)在庫情報.          在庫ﾛｯﾄ№
        FRAC_RETU                   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.              棚列
        FRAC_REN                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.              棚連
        FRAC_DAN                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.              棚段
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:A.Noto 2013/03/26 枝番表示
        FRAC_EDA                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.              枝番
        '↑↑↑↑↑↑************************************************************************************************************
        FRES_KIND                   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.              引当状態
        FRES_KIND_Disp              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.              引当状態    (表示用)
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:K.Kobayashi 2013/05/20 品名記号
        'JobMate:H.Okumura 2013/06/05 順番変更
        XHINMEI_CD                  '品目ﾏｽﾀ.                   品目ｺｰﾄﾞ
        FHINMEI_CD                  '在庫情報.                  品名ｺｰﾄﾞ(品名記号)
        '↑↑↑↑↑↑************************************************************************************************************
        FHINMEI                     '品目ﾏｽﾀ.                   品名
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/06/03 在庫発生日時
        'FBUF_IN_DT                  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.              ﾊﾞｯﾌｧ入日時
        FARRIVE_DT                  '在庫情報.                  在庫発生日時
        '↑↑↑↑↑↑************************************************************************************************************
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:A.Noto 2013/03/26 生産ﾗｲﾝ№表示
        XPROD_LINE                  '在庫情報.                  生産ﾗｲﾝ№
        XPROD_LINE_DSP              '在庫情報.                  生産ﾗｲﾝ№   (表示用)
        '↑↑↑↑↑↑************************************************************************************************************
        FTR_VOL                     '在庫情報.                  搬送管理量(数量)
        FREMOVE_KIND                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ.              禁止区分
        FREMOVE_KIND_DSP            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ.              禁止区分    (表示用)
        FRAC_FORM                   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ.              棚形状種別
        FRAC_FORM_DSP               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ.              棚形状種別  (表示用)
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:A.Noto 2013/03/26 棚ﾌﾞﾛｯｸ追加
        XTANA_BLOCK                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ.              棚ﾌﾞﾛｯｸ
        XTANA_BLOCK_DTL             'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ.              棚ﾌﾞﾛｯｸ詳細
        '↑↑↑↑↑↑************************************************************************************************************
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:K.Kobayashi 2013/05/20 棚在庫リスト用　非表示項目
        XKENSA_KUBUN                '在庫情報.                  検査区分
        XKENSA_KUBUN_DSP            '在庫情報.                  検査区分(表示用)
        FHORYU_KUBUN                '在庫情報.                  保留区分
        FHORYU_KUBUN_DSP            '在庫情報.                  保留区分(表示用)
        XKENPIN_KUBUN               '在庫情報.                  検品区分
        XKENPIN_KUBUN_DSP           '在庫情報.                  検品区分(表示用)
        FIN_KUBUN                   '在庫情報.                  入庫区分
        FIN_KUBUN_DSP               '在庫情報.                  入庫区分(表示用)
        XMAKER_CD                   '在庫情報.			        ﾒｰｶ-ｺｰﾄﾞ
        '↑↑↑↑↑↑************************************************************************************************************

        MAXCOL                      'ｸﾞﾘｯﾄﾞの列数の最大値
    End Enum


    ''' <summary>ﾁｪｯｸ用列挙体</summary>
    Enum menmCheckCase
        SearchBtn_Click         '検索ﾎﾞﾀﾝｸﾘｯｸ時
        PrevBtn_Click           '前列ﾎﾞﾀﾝｸﾘｯｸ時
        NextBtn_Click           '次列ﾎﾞﾀﾝｸﾘｯｸ時 
        AddBtn_Click            '追加ﾎﾞﾀﾝｸﾘｯｸ時
        UpdateBtn_Click         '変更ﾎﾞﾀﾝｸﾘｯｸ時
        DeleteBtn_Click         '削除ﾎﾞﾀﾝｸﾘｯｸ時
        KinshiBtn_Click         '禁止設定ﾎﾞﾀﾝｸﾘｯｸ時
        Print_Click             '印刷ﾎﾞﾀﾝｸﾘｯｸ時
    End Enum

#End Region
#Region "  構造体定義　                     "
    ''' <summary>ｸ検索条件</summary>
    Private Structure stcSEARCH_ITEM
        Dim FTRK_BUF_NO As String   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        Dim FRAC_RETU As String     '列
        Dim FRAC_REN As String      '連
        Dim FRAC_DAN As String      '段
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:A.Noto 2013/04/02 枝追加
        Dim FRAC_EDA As String      '枝
        '↑↑↑↑↑↑************************************************************************************************************

    End Structure
#End Region
#Region "　ｲﾍﾞﾝﾄ　                          "
#Region "　保管場所ｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞ       ｲﾍﾞﾝﾄ   "
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
                '棚番ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
                '===================================
                Call MakeTanabanCombo()

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
#Region "　ｸﾞﾘｯﾄﾞ ｾﾚｸﾄﾁｪﾝｼﾞｲﾍﾞﾝﾄ　"
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ ｾﾚｸﾄﾁｪﾝｼﾞｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdList.SelectionChanged
        Try

            Call grdList_SelChangeProcess()

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
    Private Sub FRM_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            Me.ActiveControl = Nothing          'ﾃﾞﾌｫﾙﾄﾌｫｰｶｽの無効化

        Catch ex As Exception
            Call gobjComFuncFRM.ComError_frm(ex)

        End Try

    End Sub
#End Region
#End Region
#Region "　ﾌｫｰﾑﾛｰﾄﾞ                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub InitializeChild()

        '===================================
        '保管場所                   ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(Me.Name, cboFPLACE_CD, True)


        '===================================
        '棚番ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
        '===================================
        Call MakeTanabanCombo()


        '*********************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '*********************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListSetup()


        '**********************************************************
        ' ｺﾝﾄﾛｰﾙ初期化
        '**********************************************************
        mFlag_Form_Load = False


    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ                       "
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
        cboFPLACE_CD.Dispose()            '保管場所
        cboFRAC_RETU.Dispose()              '列
        cboFRAC_REN.Dispose()               '連
        cboFRAC_DAN.Dispose()               '段
        grdList.Dispose()                   'ｸﾞﾘｯﾄﾞ

    End Sub
#End Region
#Region "  F1 (検索)        ﾎﾞﾀﾝ押下処理    "
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
        Call SearchItem_Set()


        '*********************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '*********************************************
        Call grdListDisplaySub(grdList)

        Dim blnASRS As Boolean = False  '自動倉庫ﾌﾗｸﾞ
        Dim objTMST_TRK As New TBL_TMST_TRK(gobjOwner, gobjDb, Nothing)
        objTMST_TRK.FTRK_BUF_NO = TO_NUMBER(cboFPLACE_CD.SelectedValue.ToString)
        objTMST_TRK.GET_TMST_TRK(False)
        If objTMST_TRK.FBUF_KIND = FBUF_KIND_SASRS Then
            '(自動倉庫の場合)
            blnASRS = True
        Else
            '(その他の場合)
            blnASRS = False
        End If
        If blnASRS = True Then
            '(自動倉庫の場合)
            Call CmdEnabledChangeButton(cmdF2, Me.Name, True)       '前列
            Call CmdEnabledChangeButton(cmdF3, Me.Name, True)       '次列
        Else
            Call CmdEnabledChangeButton(cmdF2, Me.Name, False)      '前列
            Call CmdEnabledChangeButton(cmdF3, Me.Name, False)      '次列
        End If

    End Sub
#End Region
#Region "  F2 (前列)        ﾎﾞﾀﾝ押下処理    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F2(前列) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F2Process()


        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.NextBtn_Click) = False Then

            Exit Sub

        End If


        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:A.Noto 2013/04/02 枝追加
        '*********************************************
        ' 構造体ｾｯﾄ(枝)
        '*********************************************
        Call SearchItem_Set_EDA()
        '↑↑↑↑↑↑************************************************************************************************************


        '*********************************************
        ' 表示する列をｾｯﾄ
        '*********************************************
        Call SetDispRetuNo(menmCheckCase.PrevBtn_Click)


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
#Region "  F3 (次列)        ﾎﾞﾀﾝ押下処理    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F3(次列) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F3Process()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.NextBtn_Click) = False Then

            Exit Sub

        End If


        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:A.Noto 2013/04/02 枝追加
        '*********************************************
        ' 構造体ｾｯﾄ(枝)
        '*********************************************
        Call SearchItem_Set_EDA()
        '↑↑↑↑↑↑************************************************************************************************************


        '*********************************************
        ' 表示する列をｾｯﾄ
        '*********************************************
        Call SetDispRetuNo(menmCheckCase.NextBtn_Click)


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
#Region "  F4 (追加)        ﾎﾞﾀﾝ押下処理    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F4(追加) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F4Process()


        '*******************************************************
        '入力ﾁｪｯｸ
        '*******************************************************
        If InputCheck(menmCheckCase.AddBtn_Click) = False Then

            Exit Sub

        End If

        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:A.Noto 2013/04/02 枝追加
        '*********************************************
        ' 構造体ｾｯﾄ(枝)
        '*********************************************
        Call SearchItem_Set_EDA()
        '↑↑↑↑↑↑************************************************************************************************************


        '************************************
        ' ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        '************************************
        If IsNull(gobjFRM_205041) = False Then
            gobjFRM_205041.Close()
            gobjFRM_205041.Dispose()
            gobjFRM_205041 = Nothing
        End If

        gobjFRM_205041 = New FRM_205041
        Call SetProperty(BUTTONMODE_ADD)                                  'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        gobjFRM_205041.userButtonMode = BUTTONMODE_ADD     'ﾎﾞﾀﾝ

        Dim intRet As DialogResult
        intRet = gobjFRM_205041.ShowDialog()            '展開
        If intRet = System.Windows.Forms.DialogResult.Cancel = True Then
            '(ｷｬﾝｾﾙ時)
            Exit Sub
        End If


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
#Region "  F5 (変更)        ﾎﾞﾀﾝ押下処理    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F5(変更) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F5Process()


        '*******************************************************
        '入力ﾁｪｯｸ
        '*******************************************************
        If InputCheck(menmCheckCase.UpdateBtn_Click) = False Then

            Exit Sub

        End If

        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:A.Noto 2013/04/02 枝追加
        '*********************************************
        ' 構造体ｾｯﾄ(枝)
        '*********************************************
        Call SearchItem_Set_EDA()
        '↑↑↑↑↑↑************************************************************************************************************


        '************************************
        ' ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        '************************************
        If IsNull(gobjFRM_205041) = False Then
            gobjFRM_205041.Close()
            gobjFRM_205041.Dispose()
            gobjFRM_205041 = Nothing
        End If

        gobjFRM_205041 = New FRM_205041

        Call SetProperty(BUTTONMODE_UPDATE)                                      'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        gobjFRM_205041.userButtonMode = BUTTONMODE_UPDATE       'ﾎﾞﾀﾝ

        Dim intRet As DialogResult
        intRet = gobjFRM_205041.ShowDialog()            '展開
        'If intRet = System.Windows.Forms.DialogResult.Cancel = True Then
        '    '(ｷｬﾝｾﾙ時)
        '    Exit Sub
        'End If


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
#Region "  F6 (削除)        ﾎﾞﾀﾝ押下処理    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F6(削除) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F6Process()


        '*******************************************************
        '入力ﾁｪｯｸ
        '*******************************************************
        If InputCheck(menmCheckCase.DeleteBtn_Click) = False Then

            Exit Sub

        End If

        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:A.Noto 2013/04/02 枝追加
        '*********************************************
        ' 構造体ｾｯﾄ(枝)
        '*********************************************
        Call SearchItem_Set_EDA()
        '↑↑↑↑↑↑************************************************************************************************************

        '************************************
        ' ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        '************************************
        If IsNull(gobjFRM_205041) = False Then
            gobjFRM_205041.Close()
            gobjFRM_205041.Dispose()
            gobjFRM_205041 = Nothing
        End If

        gobjFRM_205041 = New FRM_205041

        Call SetProperty(BUTTONMODE_DELETE)                                      'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        gobjFRM_205041.userButtonMode = BUTTONMODE_DELETE      'ﾎﾞﾀﾝ

        Dim intRet As DialogResult
        intRet = gobjFRM_205041.ShowDialog()            '展開
        If intRet = System.Windows.Forms.DialogResult.Cancel = True Then
            '(ｷｬﾝｾﾙ時)
            Exit Sub
        End If


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
#Region "  F7 (禁止設定)    ﾎﾞﾀﾝ押下処理    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F7(禁止設定) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F7Process()


        '*******************************************************
        '入力ﾁｪｯｸ
        '*******************************************************
        If InputCheck(menmCheckCase.KinshiBtn_Click) = False Then

            Exit Sub

        End If

        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:A.Noto 2013/04/02 枝追加
        '*********************************************
        ' 構造体ｾｯﾄ(枝)
        '*********************************************
        Call SearchItem_Set_EDA()
        '↑↑↑↑↑↑************************************************************************************************************


        '************************************
        ' ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        '************************************
        If IsNull(gobjFRM_205042) = False Then
            gobjFRM_205042.Close()
            gobjFRM_205042.Dispose()
            gobjFRM_205042 = Nothing
        End If

        gobjFRM_205042 = New FRM_205042

        Call SetProperty2()                                     'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ

        Dim intRet As DialogResult
        intRet = gobjFRM_205042.ShowDialog()            '展開
        'If intRet = System.Windows.Forms.DialogResult.Cancel = True Then
        '    '(ｷｬﾝｾﾙ時)
        '    Exit Sub
        'End If


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
#Region "  F8 (印刷)        ﾎﾞﾀﾝ押下処理    "
    '*******************************************************************************************************************
    '【機能】F8  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F8Process()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.Print_Click) = False Then
            '(入力ｴﾗｰがある場合)
            Exit Sub
        End If

        '*********************************************
        ' 構造体ｾｯﾄ
        '*********************************************
        'Call SearchItem_Set()

        '**********************************************************
        ' ﾘｽﾄ表示
        '**********************************************************
        Call grdListDisplaySub(grdList)

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
        Call printOut()


    End Sub
#End Region
#Region "　構造体ｾｯﾄ　                      "
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
        If IsNull(cboFRAC_RETU.SelectedItem) = False Then
            mudtSEARCH_ITEM.FRAC_RETU = TO_STRING(cboFRAC_RETU.SelectedValue.ToString)          '列
            mudtSEARCH_ITEM.FRAC_REN = TO_STRING(cboFRAC_REN.SelectedValue.ToString)            '連
            mudtSEARCH_ITEM.FRAC_DAN = TO_STRING(cboFRAC_DAN.SelectedValue.ToString)            '段
            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:H.Okumura 2013/06/20 枝追加
            mudtSEARCH_ITEM.FRAC_EDA = TO_STRING(cboFRAC_EDA.SelectedValue.ToString)            '枝
            '↑↑↑↑↑↑************************************************************************************************************

        Else
            mudtSEARCH_ITEM.FRAC_RETU = ""
            mudtSEARCH_ITEM.FRAC_REN = ""
            mudtSEARCH_ITEM.FRAC_DAN = ""
            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:H.Okumura 2013/06/20 枝追加
            mudtSEARCH_ITEM.FRAC_EDA = ""
            '↑↑↑↑↑↑************************************************************************************************************
        End If

        mudtSEARCH_ITEM.FTRK_BUF_NO = TO_STRING(cboFPLACE_CD.SelectedValue.ToString)            '保管場所(ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№)

    End Sub
#End Region
#Region "　構造体ｾｯﾄ　                      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 構造体ｾｯﾄ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SearchItem_Set_EDA()

        '***********************************************
        '検索条件をｾｯﾄ
        '***********************************************
        If grdList.SelectedRows.Count > 0 Then
            '(ｸﾞﾘｯﾄﾞが選択されているとき)
            mudtSEARCH_ITEM.FRAC_EDA = TO_INTEGER(grdList.Item(menmListCol.FRAC_EDA, grdList.SelectedRows(0).Index).Value)      '枝
        Else
            mudtSEARCH_ITEM.FRAC_EDA = ""
        End If

    End Sub
#End Region
#Region "　入力ﾁｪｯｸ　                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 入力ﾁｪｯｸ
    ''' </summary>
    ''' <param name="udtCheck_Case">[IN ]入力ﾁｪｯｸ判別</param>
    ''' <returns>True/False</returns>
    ''' <remarks>戻値 = True :入力ﾁｪｯｸ成功/False:入力ﾁｪｯｸ失敗</remarks>
    ''' *******************************************************************************************************************
    Public Function InputCheck(ByVal udtCheck_Case As menmCheckCase) As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ


        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        Select Case udtCheck_Case
            Case menmCheckCase.SearchBtn_Click
                '(検索ﾎﾞﾀﾝｸﾘｯｸ時)

                '==========================
                '保管場所選択ﾁｪｯｸ
                '==========================
                If TO_STRING(cboFPLACE_CD.SelectedValue.ToString) = CBO_ALL_VALUE _
                    Or IsNull(TO_STRING(cboFPLACE_CD.SelectedValue.ToString)) = True _
                    Then
                    '(保管場所が選択されていない場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FPLACE_CD_MSG_01, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If


                blnCheckErr = False

            Case menmCheckCase.NextBtn_Click, _
                 menmCheckCase.PrevBtn_Click
                '(次列・前列ﾎﾞﾀﾝｸﾘｯｸ時)

                blnCheckErr = False

            Case menmCheckCase.AddBtn_Click
                '(追加ﾎﾞﾀﾝｸﾘｯｸ時)

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
                '禁止棚ﾁｪｯｸ
                '==========================
                'If TO_NUMBER(grdList.Item(menmListCol.FREMOVE_KIND, grdList.SelectedRows(0).Index).Value) <> FREMOVE_KIND_SNORMAL Then
                '    '(通常棚以外の時)
                '    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205040_04, PopupFormType.Ok, PopupIconType.Information)
                '    blnCheckErr = True
                '    Exit Select

                'End If


                '==========================
                '在庫棚ﾁｪｯｸ
                '==========================
                If TO_NUMBER(grdList.Item(menmListCol.FRES_KIND, grdList.SelectedRows(0).Index).Value) <> FRES_KIND_SAKI Then
                    '(在庫棚の時)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205040_02, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select

                End If


                blnCheckErr = False

            Case menmCheckCase.UpdateBtn_Click
                '(変更ﾎﾞﾀﾝｸﾘｯｸ時)

                '==========================
                'ﾘｽﾄ選択ﾁｪｯｸ
                '==========================
                If grdList.SelectedRows.Count < 1 Then
                    '(ﾘｽﾄが選択されていない場合)

                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_GRD_LIST, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select

                End If


                ' ''==========================
                ' ''物理禁止棚ﾁｪｯｸ
                ' ''==========================
                ''If TO_NUMBER(grdList.Item(menmListCol.FREMOVE_KIND, grdList.SelectedRows(0).Index).Value) = FREMOVE_KIND_SNON Then
                ''    '(物理禁止棚の時)
                ''    Call DisplayPopup(FRM_MSG_FRM205040_04, PopupFormType.Ok, PopupIconType.Information)
                ''    blnCheckErr = True
                ''    Exit Select

                ''End If


                '==========================
                '在庫棚ﾁｪｯｸ
                '==========================
                If TO_NUMBER(grdList.Item(menmListCol.FRES_KIND, grdList.SelectedRows(0).Index).Value) = FRES_KIND_SZAIKO Or _
                    TO_NUMBER(grdList.Item(menmListCol.FRES_KIND, grdList.SelectedRows(0).Index).Value) = FRES_KIND_SAKI Or _
                    TO_NUMBER(grdList.Item(menmListCol.FRES_KIND, grdList.SelectedRows(0).Index).Value) = FRES_KIND_SRSV_TRNS_IN Then
                    '(在庫棚、空棚、搬入予約の場合)
                Else
                    '(それ以外のとき)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205040_05, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select

                End If


                blnCheckErr = False

            Case menmCheckCase.DeleteBtn_Click
                '(削除ﾎﾞﾀﾝｸﾘｯｸ時)

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
                '禁止棚ﾁｪｯｸ
                '==========================
                'If TO_NUMBER(grdList.Item(menmListCol.FREMOVE_KIND, grdList.SelectedRows(0).Index).Value) <> FREMOVE_KIND_SNORMAL Then
                '    '(通常棚以外の時)
                '    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205040_04, PopupFormType.Ok, PopupIconType.Information)
                '    blnCheckErr = True
                '    Exit Select

                'End If


                '==========================
                '在庫棚ﾁｪｯｸ
                '==========================
                If TO_NUMBER(grdList.Item(menmListCol.FRES_KIND, grdList.SelectedRows(0).Index).Value) <> FRES_KIND_SZAIKO Then
                    '(在庫棚以外の場合)

                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205040_01, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select

                End If


                blnCheckErr = False


            Case menmCheckCase.KinshiBtn_Click
                '(禁止設定ﾎﾞﾀﾝｸﾘｯｸ時)

                '==========================
                '保管場所選択ﾁｪｯｸ
                '==========================
                If TO_STRING(cboFPLACE_CD.SelectedValue.ToString) = CBO_ALL_VALUE _
                    Or IsNull(TO_STRING(cboFPLACE_CD.SelectedValue.ToString)) = True _
                    Then
                    '(保管場所が選択されていない場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FPLACE_CD_MSG_01, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If


                blnCheckErr = False

            Case menmCheckCase.Print_Click
                '(印刷ﾎﾞﾀﾝｸﾘｯｸ時)

                '==========================
                'ﾘｽﾄ　表示ﾃﾞｰﾀﾁｪｯｸ
                '==========================
                If grdList.Rows.Count <= 0 Then
                    '(ﾃﾞｰﾀが一行もない場合)
                    Exit Function
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
#Region "　ｸﾞﾘｯﾄﾞ表示　                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub grdListDisplayChild()

        'mblnInitFlag = True

        '************************************************
        '倉庫か判別
        '************************************************
        Dim blnASRS As Boolean = False  '自動倉庫ﾌﾗｸﾞ
        Dim objTMST_TRK As New TBL_TMST_TRK(gobjOwner, gobjDb, Nothing)
        objTMST_TRK.FTRK_BUF_NO = TO_NUMBER(cboFPLACE_CD.SelectedValue.ToString)
        objTMST_TRK.GET_TMST_TRK(False)
        If objTMST_TRK.FBUF_KIND = FBUF_KIND_SASRS Then
            '(自動倉庫の場合)
            blnASRS = True
        Else
            '(その他の場合)
            blnASRS = False
        End If


        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        Dim strSQL As String                        'SQL文
        strSQL = ""
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "     TPRG_TRK_BUF.FTRK_BUF_NO "                             'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.  ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        strSQL &= vbCrLf & "   , TPRG_TRK_BUF.FTRK_BUF_ARRAY "                          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.  配列№
        strSQL &= vbCrLf & "   , TPRG_TRK_BUF.FPALLET_ID "                              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.  ﾊﾟﾚｯﾄID
        strSQL &= vbCrLf & "   , TRST_STOCK.FLOT_NO_STOCK "                             '在庫情報.      在庫ﾛｯﾄ№
        strSQL &= vbCrLf & "   , DECODE( TPRG_TRK_BUF.FRAC_RETU, 0, '' "                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.  列連段
        strSQL &= vbCrLf & "             , LPAD(TPRG_TRK_BUF.FRAC_RETU,2,'0') ) as FRAC_RETU "         '棚列(0の時は非表示)
        strSQL &= vbCrLf & "   , DECODE( TPRG_TRK_BUF.FRAC_REN, 0, '' "
        strSQL &= vbCrLf & "             , LPAD(TPRG_TRK_BUF.FRAC_REN,3,'0') ) as FRAC_REN "           '棚連(0の時は非表示)
        strSQL &= vbCrLf & "   , DECODE( TPRG_TRK_BUF.FRAC_DAN, 0, '' "
        strSQL &= vbCrLf & "             , LPAD(TPRG_TRK_BUF.FRAC_DAN,2,'0') ) as FRAC_DAN "           '棚段(0の時は非表示)
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:A.Noto 2013/03/26 枝番表示
        'JobMate:H.Okumura 2013/06/03 表示分岐処理
        If TO_STRING(mudtSEARCH_ITEM.FTRK_BUF_NO) = FTRK_BUF_NO_J9000 Then
            '(自動倉庫の場合)
            strSQL &= vbCrLf & "   , LPAD(TPRG_TRK_BUF.FRAC_EDA,2,'0') as FRAC_EDA "                        '枝番
        ElseIf TO_STRING(mudtSEARCH_ITEM.FTRK_BUF_NO) = FTRK_BUF_NO_J9100 Or _
                TO_STRING(mudtSEARCH_ITEM.FTRK_BUF_NO) = FTRK_BUF_NO_J9200 Then
            '(平置き、検品ｴﾘｱの場合)
            strSQL &= vbCrLf & "   , DECODE( TPRG_TRK_BUF.FRAC_EDA, 0, '' "
            strSQL &= vbCrLf & "             , LPAD(TPRG_TRK_BUF.FRAC_EDA,2,'0') ) as FRAC_EDA "           '枝番(0の時は非表示)
        End If
        '↑↑↑↑↑↑************************************************************************************************************
        strSQL &= vbCrLf & "   , TPRG_TRK_BUF.FRES_KIND "                               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.  引当状態
        strSQL &= vbCrLf & "   , HASH01.FGAMEN_DISP AS FRES_KIND_Dsp "                  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.  引当状態(表示用)
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:K.Kobayashi 2013/05/20 品名記号
        'JobMate:H.Okumura 2013/06/05 順番変更
        strSQL &= vbCrLf & "   , TMST_ITEM.XHINMEI_CD "                                 '品目ﾏｽﾀ.       品目ｺｰﾄﾞ(品名記号)
        strSQL &= vbCrLf & "   , TRST_STOCK.FHINMEI_CD "                                '在庫情報.      品名ｺｰﾄﾞ
        '↑↑↑↑↑↑************************************************************************************************************
        strSQL &= vbCrLf & "   , TMST_ITEM.FHINMEI "                                    '品目ﾏｽﾀ.       品名
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/06/03 在庫発生日時
        'strSQL &= vbCrLf & "   , TPRG_TRK_BUF.FBUF_IN_DT "                              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.  ﾊﾞｯﾌｧ入日時
        strSQL &= vbCrLf & "   , TRST_STOCK.FARRIVE_DT "                                '在庫情報.      入庫日時
        '↑↑↑↑↑↑************************************************************************************************************
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:A.Noto 2013/03/26 生産ﾗｲﾝ№
        strSQL &= vbCrLf & "   , TRST_STOCK.XPROD_LINE "                                '在庫情報.      生産ﾗｲﾝ№
        strSQL &= vbCrLf & "   , HASH04.XPROD_LINE_NAME AS XPROD_LINE_DSP "             '在庫情報.      生産ﾗｲﾝ№(表示用)
        '↑↑↑↑↑↑************************************************************************************************************
        strSQL &= vbCrLf & "   , TRST_STOCK.FTR_VOL "                                   '在庫情報.      搬送管理量(数量)
        strSQL &= vbCrLf & "   , TPRG_TRK_BUF.FREMOVE_KIND "                            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.  禁止有無
        strSQL &= vbCrLf & "   , HASH02.FGAMEN_DISP AS FREMOVE_KIND_DSP "               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.  禁止有無(表示用)
        strSQL &= vbCrLf & "   , TPRG_TRK_BUF.FRAC_FORM "                               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.  棚形状種別
        strSQL &= vbCrLf & "   , HASH03.FGAMEN_DISP AS FRAC_FORM_DSP "                  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.  棚形状種別(表示用)
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:A.Noto 2013/03/26 棚ﾌﾞﾛｯｸ追加
        strSQL &= vbCrLf & "   , TPRG_TRK_BUF.XTANA_BLOCK "                             'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.  棚ﾌﾞﾛｯｸ
        strSQL &= vbCrLf & "   , TPRG_TRK_BUF.XTANA_BLOCK_DTL "                         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.  棚ﾌﾞﾛｯｸ詳細
        '↑↑↑↑↑↑************************************************************************************************************
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:K.Kobayashi 2013/05/20 棚在庫リスト用　非表示項目
        strSQL &= vbCrLf & "   , TRST_STOCK.XKENSA_KUBUN "                              '在庫情報.      検査区分
        strSQL &= vbCrLf & "   , HASH05.FGAMEN_DISP AS XKENSA_KUBUN_DSP "               '在庫情報.      検査区分(表示用)
        strSQL &= vbCrLf & "   , TRST_STOCK.FHORYU_KUBUN "                              '在庫情報.      保留区分
        strSQL &= vbCrLf & "   , HASH06.FGAMEN_DISP AS FHORYU_KUBUN_DSP "               '在庫情報.      保留区分(表示用)
        strSQL &= vbCrLf & "   , TRST_STOCK.XKENPIN_KUBUN "                             '在庫情報.      検品区分
        strSQL &= vbCrLf & "   , HASH07.FGAMEN_DISP AS XKENPIN_KUBUN_DSP "              '在庫情報.      検品区分(表示用)
        strSQL &= vbCrLf & "   , TRST_STOCK.FIN_KUBUN "                                 '在庫情報.      入庫区分
        strSQL &= vbCrLf & "   , HASH08.FGAMEN_DISP AS FIN_KUBUN_DSP "                  '在庫情報.      入庫区分(表示用)
        strSQL &= vbCrLf & "   , TRST_STOCK.XMAKER_CD "                                 '在庫情報.		ﾒｰｶ-ｺｰﾄﾞ
        '↑↑↑↑↑↑************************************************************************************************************


        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "     TPRG_TRK_BUF "
        strSQL &= vbCrLf & "    ,TRST_STOCK "
        strSQL &= vbCrLf & "    ,TMST_ITEM "
        strSQL &= vbCrLf & "    ," & gobjComFuncFRM.GetSQLHashTableFrom01("HASH01", "TPRG_TRK_BUF", "FRES_KIND")
        strSQL &= vbCrLf & "    ," & gobjComFuncFRM.GetSQLHashTableFrom01("HASH02", "TPRG_TRK_BUF", "FREMOVE_KIND")
        strSQL &= vbCrLf & "    ," & gobjComFuncFRM.GetSQLHashTableFrom01("HASH03", "TPRG_TRK_BUF", "FRAC_FORM")
        strSQL &= vbCrLf & "    ," & gobjComFuncFRM.GetSQLHashTableFrom02("HASH04", "XMST_PROD_LINE", "XPROD_LINE", "XPROD_LINE_NAME", "TRST_STOCK", "XPROD_LINE")
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:K.Kobayashi 2013/05/20 棚在庫リスト用　非表示項目
        strSQL &= vbCrLf & "    ," & gobjComFuncFRM.GetSQLHashTableFrom01("HASH05", "TRST_STOCK", "XKENSA_KUBUN")
        strSQL &= vbCrLf & "    ," & gobjComFuncFRM.GetSQLHashTableFrom01("HASH06", "TRST_STOCK", "FHORYU_KUBUN")
        strSQL &= vbCrLf & "    ," & gobjComFuncFRM.GetSQLHashTableFrom01("HASH07", "TRST_STOCK", "XKENPIN_KUBUN")
        strSQL &= vbCrLf & "    ," & gobjComFuncFRM.GetSQLHashTableFrom01("HASH08", "TRST_STOCK", "FIN_KUBUN")
        '↑↑↑↑↑↑************************************************************************************************************


        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE 0 = 0 "
        strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FTRK_BUF_NO = " & TO_STRING(mudtSEARCH_ITEM.FTRK_BUF_NO)
        strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FPALLET_ID  = TRST_STOCK.FPALLET_ID(+) "
        strSQL &= vbCrLf & "     AND TRST_STOCK.FHINMEI_CD  = TMST_ITEM.FHINMEI_CD(+) "
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH01", "TPRG_TRK_BUF", "FRES_KIND")
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH02", "TPRG_TRK_BUF", "FREMOVE_KIND")
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH03", "TPRG_TRK_BUF", "FRAC_FORM")
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere02("HASH04", "XMST_PROD_LINE", "XPROD_LINE", "XPROD_LINE_NAME", "TRST_STOCK", "XPROD_LINE")
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:K.Kobayashi 2013/05/20 棚在庫リスト用　非表示項目
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH05", "TRST_STOCK", "XKENSA_KUBUN")
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH06", "TRST_STOCK", "FHORYU_KUBUN")
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH07", "TRST_STOCK", "XKENPIN_KUBUN")
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH08", "TRST_STOCK", "FIN_KUBUN")
        '↑↑↑↑↑↑************************************************************************************************************

        '↓↓↓↓↓↓************************************************************************************************************
        'SystemMate:A.Noto 2012/08/29 無効棚は表示しない(※消したらダメ)
        strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FREMOVE_KIND <> " & FREMOVE_KIND_SNON
        '↑↑↑↑↑↑************************************************************************************************************

        If blnASRS = True Then
            '(自動倉庫の場合)
            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:H.Okumura 2013/06/20 列空白確認方法変更
            ' ''If IsNull(cboFRAC_RETU.SelectedItem) = False Then

            ' ''End If
            If TO_STRING(mudtSEARCH_ITEM.FRAC_RETU) <> "" Then
                '(ｺﾝﾎﾞﾎﾞｯｸｽが設定されている場合)
                strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FRAC_RETU = " & TO_STRING(mudtSEARCH_ITEM.FRAC_RETU) & " "
            End If
            '↑↑↑↑↑↑************************************************************************************************************
        End If

        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/06/20 空棚のみ表示する
        If chkFRES_KIND_AKI.Checked = True Then
            strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FRES_KIND = " & FRES_KIND_SAKI & " "
        End If
        '↑↑↑↑↑↑************************************************************************************************************

        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & gobjComFuncFRM.GetSQL_TDSP_GRID_OrderBy(Me, grdList)
        strSQL &= vbCrLf


        '=======================================
        'ｽｸﾛｰﾙﾊﾞｰ位置保持(ﾘｽﾄ選択処理で使用)
        '=======================================
        Dim objPoint As New Point(grdList.HorizontalScrollingOffset, grdList.FirstDisplayedScrollingRowIndex)


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        Call gobjComFuncFRM.TblDataGridDisplay(grdList, strSQL, True)


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdListSetup()
        Call gobjComFuncFRM.GridSelect(grdList, -1, 1, Nothing)      'ｸﾞﾘｯﾄﾞ選択処理


        '********************************************************************
        'ﾘｽﾄ選択処理
        '********************************************************************
        Call SetGridTopRow(objPoint)

    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ表示設定　                 "
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

        'grdList.AllowUserToResizeColumns = False

    End Sub
#End Region
#Region "  ｸﾞﾘｯﾄﾞ ｾﾚｸﾄﾁｪﾝｼﾞ                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ ｾﾚｸﾄﾁｪﾝｼﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdList_SelChangeProcess()

        If grdList.SelectedRows.Count <= 0 Then Exit Sub
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/06/20 自動倉庫のみ対応
        If grdList.Item(menmListCol.FTRK_BUF_NO, grdList.SelectedRows(0).Index).Value <> FTRK_BUF_NO_J9000 Then Exit Sub
        '↑↑↑↑↑↑************************************************************************************************************

        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/06/20 ｺﾝﾎﾞﾎﾞｯｸｽ切替処理変更
        ' ''cboFRAC_RETU.SelectedIndex = TO_INTEGER(grdList.Item(menmListCol.FRAC_RETU, grdList.SelectedRows(0).Index).Value) - 1
        ' ''cboFRAC_REN.SelectedIndex = TO_INTEGER(grdList.Item(menmListCol.FRAC_REN, grdList.SelectedRows(0).Index).Value) - 1
        ' ''cboFRAC_DAN.SelectedIndex = TO_INTEGER(grdList.Item(menmListCol.FRAC_DAN, grdList.SelectedRows(0).Index).Value) - 1
        cboFRAC_RETU.SelectedValue = TO_INTEGER(grdList.Item(menmListCol.FRAC_RETU, grdList.SelectedRows(0).Index).Value)
        cboFRAC_REN.SelectedValue = TO_INTEGER(grdList.Item(menmListCol.FRAC_REN, grdList.SelectedRows(0).Index).Value)
        cboFRAC_DAN.SelectedValue = TO_INTEGER(grdList.Item(menmListCol.FRAC_DAN, grdList.SelectedRows(0).Index).Value)
        cboFRAC_EDA.SelectedValue = TO_INTEGER(grdList.Item(menmListCol.FRAC_EDA, grdList.SelectedRows(0).Index).Value)
        '↑↑↑↑↑↑************************************************************************************************************

    End Sub
#End Region
#Region "　ﾘｽﾄ選択処理(ｽｸﾛｰﾙ位置無変更Ver)  "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾘｽﾄ選択処理(ｽｸﾛｰﾙ位置無変更Ver)
    ''' </summary>
    ''' <param name="objPoint">Point 構造体ｵﾌﾞｼﾞｪｸﾄ(2次元平面の点の定義　X,Y)</param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SetGridTopRow(ByVal objPoint As Point)

        '行選択ﾌﾗｸﾞ
        Dim blnRowSelFlg As Boolean = False     '行が選択された場合Trueする

        '入力値と一致する行を検索
        For ii As Integer = 0 To grdList.Rows.Count - 1
            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:H.Okumura 2013/06/20 検索分岐追加
            If mudtSEARCH_ITEM.FRAC_EDA = "" Then
                '(枝指定なし)

                If TO_INTEGER(mudtSEARCH_ITEM.FRAC_RETU) = TO_INTEGER(grdList.Item(menmListCol.FRAC_RETU, ii).Value) _
               And TO_INTEGER(mudtSEARCH_ITEM.FRAC_REN) = TO_INTEGER(grdList.Item(menmListCol.FRAC_REN, ii).Value) _
               And TO_INTEGER(mudtSEARCH_ITEM.FRAC_DAN) = TO_INTEGER(grdList.Item(menmListCol.FRAC_DAN, ii).Value) _
               Then
                    '↑↑↑↑↑↑************************************************************************************************************

                    '(指定棚が見つかった場合)
                    grdList.FirstDisplayedScrollingRowIndex = ii                'ｽｸﾛｰﾙﾊﾞｰ位置　縦
                    grdList.Rows(ii).Selected = True                            '指定棚選択
                    blnRowSelFlg = True                                         '選択ﾌﾗｸﾞON
                    Exit For

                End If

            Else
                '(枝指定あり)

                If TO_INTEGER(mudtSEARCH_ITEM.FRAC_RETU) = TO_INTEGER(grdList.Item(menmListCol.FRAC_RETU, ii).Value) _
               And TO_INTEGER(mudtSEARCH_ITEM.FRAC_REN) = TO_INTEGER(grdList.Item(menmListCol.FRAC_REN, ii).Value) _
               And TO_INTEGER(mudtSEARCH_ITEM.FRAC_DAN) = TO_INTEGER(grdList.Item(menmListCol.FRAC_DAN, ii).Value) _
               And TO_INTEGER(mudtSEARCH_ITEM.FRAC_EDA) = TO_INTEGER(grdList.Item(menmListCol.FRAC_EDA, ii).Value) _
               Then
                    '↑↑↑↑↑↑************************************************************************************************************

                    '(指定棚が見つかった場合)
                    grdList.FirstDisplayedScrollingRowIndex = ii                'ｽｸﾛｰﾙﾊﾞｰ位置　縦
                    grdList.Rows(ii).Selected = True                            '指定棚選択
                    blnRowSelFlg = True                                         '選択ﾌﾗｸﾞON
                    Exit For

                End If


            End If


            '↑↑↑↑↑↑************************************************************************************************************

            '' ''↓↓↓↓↓↓************************************************************************************************************
            '' ''JobMate:A.Noto 2013/04/02 枝追加
            '' ''If TO_INTEGER(mudtSEARCH_ITEM.FRAC_RETU) = TO_INTEGER(grdList.Item(menmListCol.FRAC_RETU, ii).Value) _
            '' ''   And TO_INTEGER(mudtSEARCH_ITEM.FRAC_REN) = TO_INTEGER(grdList.Item(menmListCol.FRAC_REN, ii).Value) _
            '' ''   And TO_INTEGER(mudtSEARCH_ITEM.FRAC_DAN) = TO_INTEGER(grdList.Item(menmListCol.FRAC_DAN, ii).Value) _
            '' ''   Then
            ' ''If TO_INTEGER(mudtSEARCH_ITEM.FRAC_RETU) = TO_INTEGER(grdList.Item(menmListCol.FRAC_RETU, ii).Value) _
            ' ''               And TO_INTEGER(mudtSEARCH_ITEM.FRAC_REN) = TO_INTEGER(grdList.Item(menmListCol.FRAC_REN, ii).Value) _
            ' ''               And TO_INTEGER(mudtSEARCH_ITEM.FRAC_DAN) = TO_INTEGER(grdList.Item(menmListCol.FRAC_DAN, ii).Value) _
            ' ''               And TO_INTEGER(mudtSEARCH_ITEM.FRAC_EDA) = TO_INTEGER(grdList.Item(menmListCol.FRAC_EDA, ii).Value) _
            ' ''               Then
            ' ''    '↑↑↑↑↑↑************************************************************************************************************

            ' ''    '(指定棚が見つかった場合)
            ' ''    grdList.FirstDisplayedScrollingRowIndex = ii                'ｽｸﾛｰﾙﾊﾞｰ位置　縦
            ' ''    grdList.Rows(ii).Selected = True                            '指定棚選択
            ' ''    blnRowSelFlg = True                                         '選択ﾌﾗｸﾞON
            ' ''    Exit For

            ' ''End If

        Next

        'ｸﾞﾘｯﾄﾞに入力値のﾃﾞｰﾀが存在しない場合
        Try
            If blnRowSelFlg = False Then
                '(行が選択されなかった場合)
                grdList.HorizontalScrollingOffset = objPoint.X                  'ｽｸﾛｰﾙﾊﾞｰ位置　横
                If 0 <= objPoint.Y Then
                    grdList.FirstDisplayedScrollingRowIndex = objPoint.Y        'ｽｸﾛｰﾙﾊﾞｰ位置　縦
                End If
            End If
        Catch ex As Exception
            grdList.HorizontalScrollingOffset = Nothing
            grdList.FirstDisplayedScrollingRowIndex = Nothing
        End Try

    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞに表示する列をｾｯﾄ　        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞに表示する列をｾｯﾄ
    ''' </summary>
    ''' <param name="udtCheck_Case"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SetDispRetuNo(ByVal udtCheck_Case As menmCheckCase)

        '=====================================
        '列番号             ｾｯﾄ
        '=====================================
        Dim intDispRetuNo As Integer = TO_INTEGER(cboFRAC_RETU.SelectedValue.ToString)    'ｸﾞﾘｯﾄﾞに表示する列番号

        '=====================================
        '最大列数取得
        '=====================================
        Dim objRow As DataRowView               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim intMaxIndex As Integer = cboFRAC_RETU.Items.Count
        objRow = cboFRAC_RETU.Items.Item(intMaxIndex - 1)
        Dim intRetuMax As Integer = TO_INTEGER(objRow.Item("ID").ToString)
        ''Dim intRetuMax As Integer = TO_INTEGER(cboFRAC_RETU.Items(intMaxIndex - 1).ToString())
        Dim intRetuMin As Integer = 1



        '押下したﾎﾞﾀﾝによって取得方法を変更
        Select Case udtCheck_Case
            Case menmCheckCase.NextBtn_Click
                '(次列ﾎﾞﾀﾝ押下時)
                Select Case intDispRetuNo
                    Case 0
                        '(ｸﾞﾘｯﾄﾞ未表示時)
                        intDispRetuNo = intRetuMin   '列最小値をｾｯﾄ

                    Case intRetuMax
                        '(列最大表示時)
                        intDispRetuNo = intRetuMin   '列最小値をｾｯﾄ

                    Case Else
                        '(その他)
                        intDispRetuNo += 1             '次の列をｾｯﾄ

                End Select

            Case menmCheckCase.PrevBtn_Click
                '(前列ﾎﾞﾀﾝ押下時)

                Select Case intDispRetuNo
                    Case 0
                        '(ｸﾞﾘｯﾄﾞ未表示時)
                        intDispRetuNo = intRetuMin   '列最小値をｾｯﾄ

                    Case intRetuMin
                        '(列最小時)
                        intDispRetuNo = intRetuMax   '列最大値をｾｯﾄ

                    Case Else
                        '(その他)
                        intDispRetuNo -= 1             '前の列をｾｯﾄ

                End Select

        End Select

        Call gobjComFuncFRM.cboSelectValue(cboFRAC_RETU, intDispRetuNo)


    End Sub
#End Region
#Region "  ﾒﾝﾃﾅﾝｽ入力画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ　     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾒﾝﾃﾅﾝｽ入力画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ
    ''' </summary>
    ''' <param name="intBtnMode"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SetProperty(ByVal intBtnMode As Integer)

        gobjFRM_205041.userFTRK_BUF_NO = TO_STRING(grdList.Item(menmListCol.FTRK_BUF_NO, grdList.SelectedRows(0).Index).Value)              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        gobjFRM_205041.userFTRK_BUF_ARRAY = TO_STRING(grdList.Item(menmListCol.FTRK_BUF_ARRAY, grdList.SelectedRows(0).Index).Value)        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
        gobjFRM_205041.userFPALLET_ID = TO_STRING(grdList.Item(menmListCol.FPALLET_ID, grdList.SelectedRows(0).Index).Value)                'ﾊﾟﾚｯﾄID
        gobjFRM_205041.userFLOT_NO_STOCK = TO_STRING(grdList.Item(menmListCol.FLOT_NO_STOCK, grdList.SelectedRows(0).Index).Value)          '在庫ﾛｯﾄ№

    End Sub

#End Region
#Region "  禁止設定画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ　       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 禁止設定画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SetProperty2()

        gobjFRM_205042.userFTRK_BUF_NO = TO_STRING(cboFPLACE_CD.SelectedValue.ToString)            '保管場所(ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№)

    End Sub

#End Region
#Region "　列連段枝ｺﾝﾎﾞ作成処理             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 列連段枝ｺﾝﾎﾞ作成処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub MakeTanabanCombo()

        If mFlag_Form_Load = False Then

            '************************************************
            '倉庫か判別
            '************************************************
            Dim blnASRS As Boolean = False  '自動倉庫ﾌﾗｸﾞ
            Dim objTMST_TRK As New TBL_TMST_TRK(gobjOwner, gobjDb, Nothing)
            objTMST_TRK.FTRK_BUF_NO = TO_NUMBER(cboFPLACE_CD.SelectedValue.ToString)
            objTMST_TRK.GET_TMST_TRK(False)
            If objTMST_TRK.FBUF_KIND = FBUF_KIND_SASRS Then
                '(自動倉庫の場合)
                blnASRS = True
            Else
                '(その他の場合)
                blnASRS = False
            End If
            If blnASRS = True Then
                '(自動倉庫の場合)
                cboFRAC_RETU.Enabled = True     '列
                cboFRAC_REN.Enabled = True      '連
                cboFRAC_DAN.Enabled = True      '段
                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:H.Okumura 2013/06/20 枝追加
                cboFRAC_EDA.Enabled = True      '枝
                '↑↑↑↑↑↑************************************************************************************************************

                'Call CmdEnabledChangeButton(cmdF2, Me.Name, True)       '前列
                'Call CmdEnabledChangeButton(cmdF3, Me.Name, True)       '次列
                Call CmdEnabledChangeButton(cmdF2, Me.Name, False)      '前列
                Call CmdEnabledChangeButton(cmdF3, Me.Name, False)      '次列

                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:H.Okumura 2013/06/20 枝追加
                Call gobjComFuncFRM.InitRetuRenDanEda_TrkBufNo(TO_NUMBER(cboFPLACE_CD.SelectedValue.ToString) _
                      , cboFRAC_RETU _
                      , cboFRAC_REN _
                      , cboFRAC_DAN _
                      , cboFRAC_EDA _
                      )
                '↑↑↑↑↑↑************************************************************************************************************

                cboFRAC_RETU.SelectedIndex = 0     '列
                cboFRAC_REN.SelectedIndex = 0      '連
                cboFRAC_DAN.SelectedIndex = 0      '段
                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:H.Okumura 2013/06/20 枝追加
                cboFRAC_EDA.SelectedIndex = 0      '枝
                '↑↑↑↑↑↑************************************************************************************************************

            Else
                '(その他の場合)
                cboFRAC_RETU.Enabled = False        '列
                cboFRAC_REN.Enabled = False         '連
                cboFRAC_DAN.Enabled = False         '段
                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:H.Okumura 2013/06/20 枝追加
                cboFRAC_EDA.Enabled = False         '枝
                '↑↑↑↑↑↑************************************************************************************************************

                Call CmdEnabledChangeButton(cmdF2, Me.Name, False)      '前列
                Call CmdEnabledChangeButton(cmdF3, Me.Name, False)      '次列
                cboFRAC_RETU.SelectedIndex = -1     '列
                cboFRAC_REN.SelectedIndex = -1      '連
                cboFRAC_DAN.SelectedIndex = -1      '段
                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:H.Okumura 2013/06/20 枝追加
                cboFRAC_EDA.SelectedIndex = -1      '枝
                '↑↑↑↑↑↑************************************************************************************************************
            End If

        Else
            '(初回の場合)
            cboFRAC_RETU.Enabled = False        '列
            cboFRAC_REN.Enabled = False         '連
            cboFRAC_DAN.Enabled = False         '段
            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:H.Okumura 2013/06/20 枝追加
            cboFRAC_EDA.Enabled = False         '枝
            '↑↑↑↑↑↑************************************************************************************************************
            Call CmdEnabledChangeButton(cmdF2, Me.Name, False)      '前列
            Call CmdEnabledChangeButton(cmdF3, Me.Name, False)      '次列
            cboFRAC_RETU.SelectedIndex = -1     '列
            cboFRAC_REN.SelectedIndex = -1      '連
            cboFRAC_DAN.SelectedIndex = -1      '段
            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:H.Okumura 2013/06/20 枝追加
            cboFRAC_EDA.SelectedIndex = -1      '枝
            '↑↑↑↑↑↑************************************************************************************************************

        End If

    End Sub
#End Region
#Region "　印刷処理　                       "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】なし
    '【戻値】なし
    '*******************************************************************************************************************
    Private Sub printOut()

        Call gobjComFuncFRM.WaitFormShow()                     ' Waitﾌｫｰﾑ表示

        '***********************************************
        ' 各ｵﾌﾞｼﾞｪｸﾄのｲﾝｽﾀﾝｽ
        '***********************************************
        Dim objCR As New PRT_205040_01          'ｸﾘｽﾀﾙﾚﾎﾟｰﾄｵﾌﾞｼﾞｪｸﾄ
        Dim objDataSet As New clsPrintDataSet   'ﾃﾞｰﾀﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ

        Try

            '***********************************************
            ' ﾍｯﾀﾞｰ部分作成
            '***********************************************
            '================================
            ' ﾃﾞｰﾀをｾｯﾄ
            '================================
            Call gobjComFuncFRM.ChangeCRText(objCR, "crDateTime01", Format(Now, GAMEN_DATE_FORMAT_02))     '発行日時

            '***********************************************
            ' ﾃﾞｰﾀ部分作成
            '***********************************************
            For ii As Integer = 0 To grdList.Rows.Count - 1
                Dim objDataRow As clsPrintDataSet.DataTable01Row
                objDataRow = objDataSet.DataTable01.NewRow

                objDataRow.BeginEdit()

                '*明細項目(表示)    
                Dim strLoc As String = grdList.Item(menmListCol.FRAC_RETU, ii).FormattedValue.ToString.PadLeft(2, "0")           '列
                strLoc = strLoc & "-" & grdList.Item(menmListCol.FRAC_REN, ii).FormattedValue.ToString.PadLeft(3, "0")           '連
                strLoc = strLoc & "-" & grdList.Item(menmListCol.FRAC_DAN, ii).FormattedValue.ToString.PadLeft(2, "0")           '段
                strLoc = strLoc & "-" & grdList.Item(menmListCol.FRAC_EDA, ii).FormattedValue.ToString.PadLeft(2, "0")           '枝番
                objDataRow.Data00 = strLoc                                                              'ﾛｹｰｼｮﾝ
                objDataRow.Data01 = grdList.Item(menmListCol.FRES_KIND_Disp, ii).FormattedValue         '棚状態
                objDataRow.Data02 = grdList.Item(menmListCol.FHINMEI_CD, ii).FormattedValue             '品名ｺｰﾄﾞ
                objDataRow.Data03 = grdList.Item(menmListCol.XHINMEI_CD, ii).FormattedValue             '品名記号
                objDataRow.Data04 = grdList.Item(menmListCol.FHINMEI, ii).FormattedValue                '品名
                objDataRow.Data05 = grdList.Item(menmListCol.FLOT_NO_STOCK, ii).FormattedValue          'ﾛｯﾄ№
                objDataRow.Data06 = grdList.Item(menmListCol.XPROD_LINE, ii).FormattedValue             '生産ﾗｲﾝ№
                objDataRow.Data07 = grdList.Item(menmListCol.FARRIVE_DT, ii).FormattedValue             '在庫発生日時
                objDataRow.Data08 = grdList.Item(menmListCol.FTR_VOL, ii).FormattedValue                '数量
                objDataRow.Data09 = grdList.Item(menmListCol.XKENSA_KUBUN_DSP, ii).FormattedValue       '検査区分
                objDataRow.Data10 = grdList.Item(menmListCol.FHORYU_KUBUN_DSP, ii).FormattedValue       '保留区分
                objDataRow.Data11 = grdList.Item(menmListCol.XKENPIN_KUBUN_DSP, ii).FormattedValue      '検品区分
                objDataRow.Data12 = grdList.Item(menmListCol.FIN_KUBUN_DSP, ii).FormattedValue          '入庫区分
                objDataRow.Data13 = grdList.Item(menmListCol.XMAKER_CD, ii).FormattedValue              'ﾒｰｶｺｰﾄﾞ

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

End Class
