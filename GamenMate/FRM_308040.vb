'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】ﾄﾗｯｸ入門受付
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_308040
#Region "　共通変数　                               "

    Private mFlag_Form_Load As Boolean = True                   '画面展開ﾌﾗｸﾞ
    Private mFlag_GRID_CLEAR As Boolean = True                  'ｸﾞﾘｯﾄﾞｸﾘｱ済みﾌﾗｸﾞ

    Private mstrXCAR_NO_EDA_WARITUKE As String                  '受付車番枝番


    '検索条件用構造体
    Private mudtSEARCH_ITEM As New SEARCH_ITEM

    '選択された発注№の配列
    Public mstrXORDER_NO() As String = Nothing
    '外部倉庫先行判定
    Public mintXGAIBU_SOUKO_SENKOU As Integer = 0
    'ﾊﾞｰｽ指定判定
    Public mintXBERTH_SITEI As Integer = 0
    '平1出庫判定
    Public mintXHIRA1 As Integer = 0
    '配送先ｺｰﾄﾞ
    Public mstrXNYUKA_JIGYOU_CD As String
    '配送先名
    Public mstrXNYUKA_JIGYOU_NM As String


    'ｸﾞﾘｯﾄﾞ項目
    Enum menmListCol

        XSYUKKA_DT                  '出荷計画.          (非表示)出荷日
        XSYUKKA_DT_DSP              '出荷計画.                  出荷日(表示用)
        XNYUKA_JIGYOU_CD            '出荷計画.                  入荷事業所ｺｰﾄﾞ(配送先ｺｰﾄﾞ)
        XNYUKA_JIGYOU_NM            '出荷計画.                  入荷事業所名(配送先名)
        XORDER_NO                   '出荷計画.                  発注№
        'XSYUKKA_NO                  '出荷計画.                  出荷№
        XCAR_NO                     '出荷計画.                  車番
        XIDOU_CD                    '出荷計画.                  移動手段ｺｰﾄﾞ
        XARRIVAL_DT                 '出荷計画.          (非表示)到着日
        XARRIVAL_DT_DSP             '出荷計画.                  到着日(表示用)
        XGYOSHA_CD                  '出荷計画.                  業者ｺｰﾄﾞ
        XSYUKKA_BERTH               '                           出荷ﾊﾞｰｽ(0:なし 1:○)
        XSYUKKA_BERTH_DSP           '                           出荷ﾊﾞｰｽ(表示用)
        XHIRA1                      '                           平1(0:なし 1:○)
        XHIRA1_DSP                  '                           平1(表示用)
        XGAIBU_SOUKO                '                           外部倉庫(0:なし 1:○ 2:済)
        XGAIBU_SOUKO_DSP            '                           外部倉庫(表示用)
        XCAR_NO_WARITUKE            '出荷計画.                  割付車番
        XCAR_NO_EDA_WARITUKE        '出荷計画.                  割付車番枝番
        XCAR_NO_WARITUKE_SEL        '                           割付車番選択

        MAXCOL

    End Enum

    '入力ﾁｪｯｸ場合判別
    Enum menmCheckCase
        SearchBtn_Click                 '検索ﾎﾞﾀﾝｸﾘｯｸ時
        Regist_Click                    '入門受付ﾎﾞﾀﾝｸﾘｯｸ時
    End Enum

#End Region
#Region "  構造体定義                               "
    '検索条件
    Private Structure SEARCH_ITEM
        Dim XCAR_NO_WARITUKE As String           '受付車番
        Dim XCAR_NO_EDA_WARITUKE As String       '受付車番枝番
        Dim XCAR_NO As String                    '車番
        Dim XSYUKKA_DT As String                 '出荷日
        Dim XORDER_NO As String                  '発注№
        Dim XNYUKA_JIGYOU_CD As String           '配送先ｺｰﾄﾞ
        Dim XIDOU_CD As String                   '移動手段ｺｰﾄﾞ
        Dim XGYOSHA_CD As String                 '業者ｺｰﾄﾞ
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
#Region "　出荷日ｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞ    ｲﾍﾞﾝﾄ        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 出荷日ｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cboXSYUKKA_DT_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboXSYUKKA_DT.SelectedIndexChanged
        Try

            If mFlag_Form_Load = False Then

                '===================================
                '発注№～業者ｺｰﾄﾞ ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
                '===================================
                cboXCAR_NO.SelectedIndex = 0        '車番
                Call MakeTrackNyumonUketuke_XORDER_NO(TO_STRING(cboXSYUKKA_DT.SelectedValue.ToString), cboXORDER_NO, True)                   '発注№
                Call MakeTrackNyumonUketuke_XNYUKA_JIGYOU_CD(TO_STRING(cboXSYUKKA_DT.SelectedValue.ToString), cboXNYUKA_JIGYOU_CD, True)     '配送先ｺｰﾄﾞ
                Call MakeTrackNyumonUketuke_XIDOU_CD(TO_STRING(cboXSYUKKA_DT.SelectedValue.ToString), cboXIDOU_CD, True)                     '移動手段ｺｰﾄﾞ
                Call MakeTrackNyumonUketuke_XGYOSHA_CD(TO_STRING(cboXSYUKKA_DT.SelectedValue.ToString), cboXGYOSHA_CD, True)                 '業者ｺｰﾄﾞ

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
#Region "　配送先ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞ   ｲﾍﾞﾝﾄ     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 配送先ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cboXNYUKA_JIGYOU_CD_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboXNYUKA_JIGYOU_CD.SelectedIndexChanged
        Try

            If mFlag_Form_Load = False Then

                lblXNYUKA_JIGYOU_NM.Text = TO_STRING(cboXNYUKA_JIGYOU_CD.SelectedValue)

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


        '*********************************************
        ' ｺﾝﾎﾞﾎﾞｯｸｽ初期設定
        '*********************************************
        '===================================
        '車番～業者ｺｰﾄﾞ ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
        '===================================
        Call MakeTrackNyumonUketuke_XCAR_NO(cboXCAR_NO, True)                                                                        '車番
        Call MakeTrackNyumonUketuke_XSYUKKA_DT(cboXSYUKKA_DT, True)                                                                  '出荷日
        Call MakeTrackNyumonUketuke_XORDER_NO(TO_STRING(cboXSYUKKA_DT.SelectedValue.ToString), cboXORDER_NO, True)                   '発注№
        Call MakeTrackNyumonUketuke_XNYUKA_JIGYOU_CD(TO_STRING(cboXSYUKKA_DT.SelectedValue.ToString), cboXNYUKA_JIGYOU_CD, True)     '配送先ｺｰﾄﾞ
        Call MakeTrackNyumonUketuke_XIDOU_CD(TO_STRING(cboXSYUKKA_DT.SelectedValue.ToString), cboXIDOU_CD, True)                     '移動手段ｺｰﾄﾞ
        Call MakeTrackNyumonUketuke_XGYOSHA_CD(TO_STRING(cboXSYUKKA_DT.SelectedValue.ToString), cboXGYOSHA_CD, True)                 '業者ｺｰﾄﾞ


        '*********************************************
        ' ﾃｷｽﾄﾎﾞｯｸｽ初期設定
        '*********************************************
        txtXCAR_NO_WARITUKE.Text = ""
        txtXCAR_NO_EDA_WARITUKE.Text = ""
        lblXNYUKA_JIGYOU_NM.Text = ""

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
        txtXCAR_NO_WARITUKE.Dispose()       '受付車番
        txtXCAR_NO_EDA_WARITUKE.Dispose()   '枝番
        cboXCAR_NO.Dispose()                '車番
        cboXSYUKKA_DT.Dispose()             '出荷日
        cboXORDER_NO.Dispose()              '発注№
        cboXNYUKA_JIGYOU_CD.Dispose()       '配送先ｺｰﾄﾞ
        cboXIDOU_CD.Dispose()               '移動手段ｺｰﾄﾞ
        cboXGYOSHA_CD.Dispose()             '業者ｺｰﾄﾞ
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
#Region "  F2(入門受付)     ﾎﾞﾀﾝ押下処理　          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F2(入門受付)     ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F2Process()

        '*******************************************************
        '入力ﾁｪｯｸ
        '*******************************************************
        If InputCheck(menmCheckCase.Regist_Click) = False Then
            Exit Sub
        End If


        '*********************************************
        ' 受付枝番設定
        '*********************************************
        If txtXCAR_NO_EDA_WARITUKE.Text = CBO_ALL_CONTENT_01 Then
            '(新規入門時の時)
        Else
            '(再入門時の時)
            mstrXCAR_NO_EDA_WARITUKE = txtXCAR_NO_EDA_WARITUKE.Text
        End If

        'ｵﾌﾞｼﾞｪｸﾄNothingﾁｪｯｸ
        If IsNull(gobjFRM_308041) = False Then
            gobjFRM_308041.Close()
            gobjFRM_308041.Dispose()
            gobjFRM_308041 = Nothing
        End If

        '********************************************************************
        ' 子画面展開
        '********************************************************************
        gobjFRM_308041 = New FRM_308041                             'ｵﾌﾞｼﾞｪｸﾄ作成

        Call SetProperty(gobjFRM_308041)                  'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ

        Dim intRet As DialogResult
        intRet = gobjFRM_308041.ShowDialog()    '画面表示
        If intRet = System.Windows.Forms.DialogResult.Cancel = True Then
            '(ｷｬﾝｾﾙ時)
            mstrXCAR_NO_EDA_WARITUKE = ""                  '受付車番枝番
            Exit Sub
        End If


        If txtXCAR_NO_EDA_WARITUKE.Text = "" Then
            '(受付車番枝番に入力ない時)

            '*********************************************
            ' 構造体ｾｯﾄ
            '*********************************************
            Call SearchItem_Set()

            '************************************
            ' ｸﾞﾘｯﾄﾞ表示
            '************************************
            Call grdListDisplaySub(grdList)


            '*********************************************
            ' ﾃｷｽﾄﾎﾞｯｸｽ初期設定
            '*********************************************
            mstrXCAR_NO_EDA_WARITUKE = ""                  '受付車番枝番

        Else
            '(受付車番枝番に入力ある時)
            '*********************************************
            ' ﾃｷｽﾄﾎﾞｯｸｽ初期設定
            '*********************************************
            txtXCAR_NO_WARITUKE.Text = ""
            txtXCAR_NO_EDA_WARITUKE.Text = ""
            lblXNYUKA_JIGYOU_NM.Text = ""

            mstrXCAR_NO_EDA_WARITUKE = ""                  '受付車番枝番

            '*********************************************
            ' ｸﾞﾘｯﾄﾞ初期化
            '*********************************************
            Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
            Call grdListSetup()

            mFlag_GRID_CLEAR = True

        End If

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

        '外部倉庫先行判定
        mintXGAIBU_SOUKO_SENKOU = 0
        'ﾊﾞｰｽ指定判定
        mintXBERTH_SITEI = 0
        '平1出庫判定
        mintXHIRA1 = 0

        ''*********************************************
        ''同一ｵｰﾀﾞｰ№ 選択状態
        ''*********************************************
        'For ii As Integer = 0 To grdList.SelectedRows.Count - 1
        '    '(ﾙｰﾌﾟ:選択された行数)

        '    Dim strXORDER_NO_Temp1 As String = grdList.Item(menmListCol.XORDER_NO, grdList.SelectedRows(ii).Index).Value

        '    For jj As Integer = 0 To grdList.Rows.Count - 1
        '        '(ﾙｰﾌﾟ:ｸﾞﾘｯﾄﾞの行数)

        '        Dim strXORDER_NO_Temp2 As String = grdList.Item(menmListCol.XORDER_NO, grdList.Rows(jj).Index).Value

        '        If strXORDER_NO_Temp1 = strXORDER_NO_Temp2 Then

        '            grdList.Rows(jj).Selected = True

        '        End If

        '    Next
        'Next

        '*********************************************
        'ｵｰﾀﾞｰ№ 取得
        '*********************************************
        Dim intRet As Integer = 0
        mstrXORDER_NO = Nothing

        For ii As Integer = 0 To grdList.SelectedRows.Count - 1
            '(ﾙｰﾌﾟ:選択された行数)

            Dim strXORDER_NO_Temp As String = grdList.Item(menmListCol.XORDER_NO, grdList.SelectedRows(ii).Index).Value

            If IsNull(mstrXORDER_NO) = True Then
                '(最初の一回)
                ReDim mstrXORDER_NO(0)
                mstrXORDER_NO(0) = strXORDER_NO_Temp
            Else
                '(二回目以降)
                intRet = ArrayFindData(mstrXORDER_NO, strXORDER_NO_Temp)
                If intRet = -1 Then
                    '(発注№が見つからなかった場合)
                    ReDim Preserve mstrXORDER_NO(UBound(mstrXORDER_NO) + 1)
                    mstrXORDER_NO(UBound(mstrXORDER_NO)) = strXORDER_NO_Temp
                End If

            End If

            '外部倉庫先行判定
            Dim intXSYUKKA_BERTH_Temp As Integer = TO_INTEGER(grdList.Item(menmListCol.XSYUKKA_BERTH, grdList.SelectedRows(ii).Index).Value)    '出荷ﾊﾞｰｽ
            Dim intXHIRA1_Temp As Integer = TO_INTEGER(grdList.Item(menmListCol.XHIRA1, grdList.SelectedRows(ii).Index).Value)                  '平1
            Dim intXGAIBU_SOUKO_Temp As Integer = TO_INTEGER(grdList.Item(menmListCol.XGAIBU_SOUKO, grdList.SelectedRows(ii).Index).Value)      '外部倉庫

            If intXGAIBU_SOUKO_Temp = 1 Then
                '(外部倉庫に出荷ありの時)
                'If (intXSYUKKA_BERTH_Temp = 1) Or _
                '   (intXHIRA1_Temp = 1) Then
                '    '(構内に出荷ありの時)
                mintXGAIBU_SOUKO_SENKOU = 1     '外部倉庫先行
                'End If
            End If


            'ﾊﾞｰｽ指定判定
            If intXSYUKKA_BERTH_Temp = 1 Then
                '(ﾊﾞｰｽ出庫ありの時)
                mintXBERTH_SITEI = 1
            End If


            '平1出庫判定
            If intXHIRA1_Temp = 1 Then
                '(平1出庫ありの時)
                mintXHIRA1 = 1
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

        Dim intRet As RetCode


        Select Case udtCheck_Case
            Case menmCheckCase.SearchBtn_Click
                '(検索ﾎﾞﾀﾝｸﾘｯｸ時)

                '==========================
                ' 受付車番 ﾁｪｯｸ
                '==========================
                If txtXCAR_NO_WARITUKE.Text = "" Then
                    '(受付車番に入力ない時)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308040_01, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If


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


                '==========================
                '搬送中ﾄﾗｯｷﾝｸﾞ ﾁｪｯｸ (ｽﾄﾚｯﾁ中)
                '==========================
                For ii As Integer = 0 To grdList.SelectedRows.Count - 1
                    '(ﾙｰﾌﾟ:選択された行数)

                    'Dim strXSYUKKA_NO As String = grdList.Item(menmListCol.XSYUKKA_NO, grdList.SelectedRows(ii).Index).Value    '出荷№

                    'If gobjComFuncFRM.CHK_TrackNyumon_TRK(strXSYUKKA_NO) = True Then

                    Dim strXORDER_NO As String = grdList.Item(menmListCol.XORDER_NO, grdList.SelectedRows(ii).Index).Value    'ｵｰﾀﾞｰ№

                    If gobjComFuncFRM.CHK_TrackNyumon_TRK(strXORDER_NO) = True Then
                        '(搬送中ﾄﾗｯｷﾝｸﾞがある時)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308040_06, PopupFormType.Ok, PopupIconType.Information)
                        blnCheckErr = True
                        Exit Select
                    End If

                Next


                '==========================
                '選択 配送先相違 ﾁｪｯｸ
                '==========================
                Dim strXNYUKA_JIGYOU_CD_Temp1 As String = ""
                mstrXNYUKA_JIGYOU_CD = ""                          '配送先ｺｰﾄﾞ
                mstrXNYUKA_JIGYOU_NM = ""                          '配送先名

                For ii As Integer = 0 To grdList.SelectedRows.Count - 1
                    '(ﾙｰﾌﾟ:選択された行数)

                    Dim strXNYUKA_JIGYOU_CD_Temp2 As String = grdList.Item(menmListCol.XNYUKA_JIGYOU_CD, grdList.SelectedRows(ii).Index).Value

                    If strXNYUKA_JIGYOU_CD_Temp1 = "" Then
                        '(比較元が初期値の時)
                        strXNYUKA_JIGYOU_CD_Temp1 = strXNYUKA_JIGYOU_CD_Temp2
                        mstrXNYUKA_JIGYOU_NM = grdList.Item(menmListCol.XNYUKA_JIGYOU_NM, grdList.SelectedRows(ii).Index).Value     '配送先名
                    Else
                        '(比較元が初期値でない時)
                        If strXNYUKA_JIGYOU_CD_Temp1 = strXNYUKA_JIGYOU_CD_Temp2 Then
                            '(比較元と比較先が同じの時)
                        Else
                            '(比較元と比較先が異なる時)
                            Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308040_02, PopupFormType.Ok, PopupIconType.Information)
                            blnCheckErr = True
                            Exit Select
                        End If
                    End If


                Next

                mstrXNYUKA_JIGYOU_CD = strXNYUKA_JIGYOU_CD_Temp1    '配送先ｺｰﾄﾞ


                '==========================
                ' 受付枝番取得ﾁｪｯｸ
                '==========================
                If txtXCAR_NO_EDA_WARITUKE.Text = CBO_ALL_CONTENT_01 Then
                    '(新規入門時の時)
                    intRet = gobjComFuncFRM.GET_XCAR_NO_EDA_WARITUKE(txtXCAR_NO_WARITUKE.Text, mstrXCAR_NO_EDA_WARITUKE)
                    If (intRet = RetCode.OK) Or (intRet = RetCode.NotFound) Then
                        '(受付車番枝番が取得できた時)
                    Else
                        '(受付車番枝番が取得できなかった時)
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308040_04, PopupFormType.Ok, PopupIconType.Information)
                        blnCheckErr = True
                        Exit Select
                    End If
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
        mudtSEARCH_ITEM.XCAR_NO_WARITUKE = TO_STRING(TO_INTEGER(txtXCAR_NO_WARITUKE.Text))           '割付車番
        mudtSEARCH_ITEM.XCAR_NO_EDA_WARITUKE = TO_STRING(TO_INTEGER(txtXCAR_NO_EDA_WARITUKE.Text))   '割付車番枝番
        mudtSEARCH_ITEM.XCAR_NO = TO_STRING(cboXCAR_NO.SelectedValue)                                '車番
        mudtSEARCH_ITEM.XSYUKKA_DT = TO_STRING(cboXSYUKKA_DT.SelectedValue)                          '出荷日
        mudtSEARCH_ITEM.XORDER_NO = TO_STRING(cboXORDER_NO.SelectedValue)                            '発注№
        mudtSEARCH_ITEM.XNYUKA_JIGYOU_CD = cboXNYUKA_JIGYOU_CD.Text                                  '配送先ｺｰﾄﾞ
        mudtSEARCH_ITEM.XIDOU_CD = TO_STRING(cboXIDOU_CD.SelectedValue)                              '移動手段ｺｰﾄﾞ
        mudtSEARCH_ITEM.XGYOSHA_CD = TO_STRING(cboXGYOSHA_CD.SelectedValue)                          '業者ｺｰﾄﾞ

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
        strSQL &= vbCrLf & " SELECT DISTINCT "
        strSQL &= vbCrLf & "     XPLN_OUT.XSYUKKA_DT "                                              '出荷日
        strSQL &= vbCrLf & "   , TO_DATE(XPLN_OUT.XSYUKKA_DT, 'YYYY/MM/DD') AS XSYUKKA_DT_DSP "     '出荷日(表示用)
        strSQL &= vbCrLf & "   , XPLN_OUT.XNYUKA_JIGYOU_CD "                                        '配送先ｺｰﾄﾞ
        strSQL &= vbCrLf & "   , XPLN_OUT.XNYUKA_JIGYOU_NM "                                        '配送先名
        strSQL &= vbCrLf & "   , XPLN_OUT.XORDER_NO "                                               '発注№
        'strSQL &= vbCrLf & "   , XPLN_OUT.XSYUKKA_NO "                                              '出荷№
        strSQL &= vbCrLf & "   , XPLN_OUT.XCAR_NO "                                                 '車番
        strSQL &= vbCrLf & "   , XPLN_OUT.XIDOU_CD "                                                '移動手段ｺｰﾄﾞ
        strSQL &= vbCrLf & "   , XPLN_OUT.XARRIVAL_DT "                                             '到着日
        strSQL &= vbCrLf & "   , TO_DATE(XPLN_OUT.XARRIVAL_DT, 'YYYY/MM/DD') AS XARRIVAL_DT_DSP "   '到着日(表示用)
        strSQL &= vbCrLf & "   , XPLN_OUT.XGYOSHA_CD "                                              '業者ｺｰﾄﾞ
        strSQL &= vbCrLf & "   , NULL AS XSYUKKA_BERTH "                                            '出荷ﾊﾞｰｽ
        strSQL &= vbCrLf & "   , NULL AS XSYUKKA_BERTH_DSP "                                        '出荷ﾊﾞｰｽ(表示用)
        strSQL &= vbCrLf & "   , NULL AS XHIRA1 "                                                   '平1
        strSQL &= vbCrLf & "   , NULL AS XHIRA1_DSP "                                               '平1(表示用)
        strSQL &= vbCrLf & "   , NULL AS XGAIBU_SOUKO "                                             '外部倉庫   
        strSQL &= vbCrLf & "   , NULL AS XGAIBU_SOUKO_DSP "                                         '外部倉庫(表示用)   
        strSQL &= vbCrLf & "   , XPLN_OUT.XCAR_NO_WARITUKE "                                        '割付車番
        strSQL &= vbCrLf & "   , XPLN_OUT.XCAR_NO_EDA_WARITUKE "                                    '割付車番枝番
        strSQL &= vbCrLf & "   , 0    AS XCAR_NO_WARITUKE_SEL "                                     '割付車番選択

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "   XPLN_OUT "               '出荷計画

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE 1 = 1  "

        If txtXCAR_NO_EDA_WARITUKE.Text = CBO_ALL_VALUE Then
            '(枝番に入力ない場合)
            strSQL &= vbCrLf & "    AND XPLN_OUT.XPROGRESS_OUT = " & XPROGRESS_OUT_JHIKIATE      '進捗状態 = 「引当済」
        Else
            '(枝番に入力ある場合)
            strSQL &= vbCrLf & "    AND XPLN_OUT.XPROGRESS_OUT = " & XPROGRESS_OUT_JGAIBU_SOUKO      '進捗状態 = 「外部倉庫出荷中」
        End If

        'strSQL &= vbCrLf & "    AND XPLN_OUT.XORDER_NO NOT IN "                              'ﾊﾞﾗ補充作業あり除外
        'strSQL &= vbCrLf & " (SELECT "
        'strSQL &= vbCrLf & "     XPLN_OUT.XORDER_NO "
        'strSQL &= vbCrLf & "  FROM "
        'strSQL &= vbCrLf & "     XPLN_OUT "
        'strSQL &= vbCrLf & "   , XPLN_OUT_DTL "
        'strSQL &= vbCrLf & "   , XSTS_HIKIATE_K1 "
        'strSQL &= vbCrLf & "   , TPRG_TRK_BUF "
        'strSQL &= vbCrLf & "  WHERE 1 = 1 "
        'strSQL &= vbCrLf & "   AND XPLN_OUT.XSYUKKA_NO          = XPLN_OUT_DTL.XSYUKKA_NO(+) "
        'strSQL &= vbCrLf & "   AND XPLN_OUT_DTL.FPLAN_KEY       = XSTS_HIKIATE_K1.FPLAN_KEY(+) "
        'strSQL &= vbCrLf & "   AND XSTS_HIKIATE_K1.FPALLET_ID   = TPRG_TRK_BUF.FPALLET_ID "
        'strSQL &= vbCrLf & "   AND XSTS_HIKIATE_K1.FSAGYOU_KIND = " & FSAGYOU_KIND_JOUT_BARA        '作業種別 = ﾊﾞﾗ補充出庫
        'strSQL &= vbCrLf & "   AND TPRG_TRK_BUF.FTRK_BUF_NO     <> " & FTRK_BUF_NO_J8000            'ﾊﾞﾗ平置き以外
        'strSQL &= vbCrLf & " ) "


        '----------------------------------------------
        '受付車番＋枝番
        '----------------------------------------------
        If txtXCAR_NO_EDA_WARITUKE.Text <> CBO_ALL_VALUE Then
            '(枝番に入力ある場合)
            strSQL &= vbCrLf & "      AND XPLN_OUT.XCAR_NO_WARITUKE     = '" & mudtSEARCH_ITEM.XCAR_NO_WARITUKE & "' "
            strSQL &= vbCrLf & "      AND XPLN_OUT.XCAR_NO_EDA_WARITUKE = '" & mudtSEARCH_ITEM.XCAR_NO_EDA_WARITUKE & "' "

            strSQL &= vbCrLf & "      AND XPLN_OUT.XORDER_NO NOT IN "               '既にﾊﾞｰｽ待ちにいるのを除く
            strSQL &= vbCrLf & "          (SELECT "
            strSQL &= vbCrLf & "              XPLN_OUT.XORDER_NO "
            strSQL &= vbCrLf & "           FROM "
            strSQL &= vbCrLf & "              XPLN_OUT "
            strSQL &= vbCrLf & "            , XPLN_BERTH_WAIT "
            strSQL &= vbCrLf & "           WHERE 1 = 1 "
            strSQL &= vbCrLf & "              AND XPLN_OUT.XCAR_NO_WARITUKE     = '" & mudtSEARCH_ITEM.XCAR_NO_WARITUKE & "' "
            strSQL &= vbCrLf & "              AND XPLN_OUT.XCAR_NO_EDA_WARITUKE = '" & mudtSEARCH_ITEM.XCAR_NO_EDA_WARITUKE & "' "
            strSQL &= vbCrLf & "              AND XPLN_OUT.XCAR_NO_WARITUKE     = XPLN_BERTH_WAIT.XCAR_NO "
            strSQL &= vbCrLf & "              AND XPLN_OUT.XCAR_NO_EDA_WARITUKE = XPLN_BERTH_WAIT.XCAR_NO_EDA "
            strSQL &= vbCrLf & "          ) "

        Else
            strSQL &= vbCrLf & "      AND XPLN_OUT.XCAR_NO_WARITUKE     IS NULL "
            strSQL &= vbCrLf & "      AND XPLN_OUT.XCAR_NO_EDA_WARITUKE IS NULL "
        End If

        '----------------------------------------------
        '車番
        '----------------------------------------------
        If mudtSEARCH_ITEM.XCAR_NO <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "      AND XPLN_OUT.XCAR_NO = '" & mudtSEARCH_ITEM.XCAR_NO & "' "
        End If

        '----------------------------------------------
        '出荷日
        '----------------------------------------------
        If mudtSEARCH_ITEM.XSYUKKA_DT <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "      AND XPLN_OUT.XSYUKKA_DT = '" & mudtSEARCH_ITEM.XSYUKKA_DT & "' "
        End If

        '----------------------------------------------
        '発注№
        '----------------------------------------------
        If mudtSEARCH_ITEM.XORDER_NO <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "      AND XPLN_OUT.XORDER_NO = '" & mudtSEARCH_ITEM.XORDER_NO & "' "
        End If

        '----------------------------------------------
        '配送先ｺｰﾄﾞ
        '----------------------------------------------
        If mudtSEARCH_ITEM.XNYUKA_JIGYOU_CD <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "      AND XPLN_OUT.XNYUKA_JIGYOU_CD = '" & mudtSEARCH_ITEM.XNYUKA_JIGYOU_CD & "' "
        End If

        '----------------------------------------------
        '移動手段ｺｰﾄﾞ
        '----------------------------------------------
        If mudtSEARCH_ITEM.XIDOU_CD <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "      AND XPLN_OUT.XIDOU_CD = '" & mudtSEARCH_ITEM.XIDOU_CD & "' "
        End If

        '----------------------------------------------
        '業者ｺｰﾄﾞ
        '----------------------------------------------
        If mudtSEARCH_ITEM.XGYOSHA_CD <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "      AND XPLN_OUT.XGYOSHA_CD = '" & mudtSEARCH_ITEM.XGYOSHA_CD & "' "
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
        ' 出荷ﾊﾞｰｽ～外部倉庫「○」、外部倉庫「済」 表示設定
        '********************************************************************
        Call SET_TAHINMOK_DSP()

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
        grdList.Columns(menmListCol.XGAIBU_SOUKO_DSP).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill         '列幅自動調節
        'grdList.AllowUserToResizeColumns = False

    End Sub
#End Region
#Region "　出荷ﾊﾞｰｽ～外部倉庫「○」表示設定         "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub SET_TAHINMOK_DSP()

        Dim strSQL As String


        Dim objDataSet As New DataSet       'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String        'ﾃﾞｰﾀｾｯﾄ名

        Dim objRow As DataRow               '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ

        Dim intASOUKO_CNT As Integer = 0           '他品目出荷  出荷ﾊﾞｰｽ
        Dim intHIRA1_CNT As Integer = 0            '他品目出荷  平置き1
        Dim intBARA_CNT As Integer = 0             '他品目出荷  ﾊﾞﾗ平置き
        Dim intGAIBU_CNT As Integer = 0            '他品目出荷  外部倉庫
        Dim intGAIBU_ZUMI_CNT As Integer = 0       '外部倉庫 積込み済
        'Dim intGAIBU_NONZUMI_CNT As Integer = 0    '外部倉庫 積込み済以外
        Dim intASOUKO_TO_BARA_CNT As Integer = 0   'ﾊﾞﾗ補充中(出荷ﾊﾞｰｽ→ﾊﾞﾗ平置き)


        For ii As Integer = 0 To grdList.RowCount - 1
            '(ｸﾞﾘｯﾄﾞの行数分繰り返し)

            '-----------------------
            '抽出SQL作成
            '-----------------------
            strSQL = ""
            strSQL &= vbCrLf & " SELECT "
            strSQL &= vbCrLf & "     SUM(ASOUKO_CNT) AS ASOUKO_CNT "
            strSQL &= vbCrLf & "   , SUM(HIRA1_CNT)  AS HIRA1_CNT "
            strSQL &= vbCrLf & "   , SUM(BARA_CNT)  AS BARA_CNT "
            strSQL &= vbCrLf & "   , SUM(GAIBU_CNT)  AS GAIBU_CNT "
            strSQL &= vbCrLf & "   , SUM(GAIBU_ZUMI_CNT)  AS GAIBU_ZUMI_CNT "
            strSQL &= vbCrLf & "   , SUM(ASOUKO_TO_BARA_CNT) AS ASOUKO_TO_BARA_CNT "
            strSQL &= vbCrLf & " FROM "
            strSQL &= vbCrLf & "   ( "
            strSQL &= vbCrLf & "   SELECT "
            strSQL &= vbCrLf & "       COUNT(0) AS ASOUKO_CNT "
            strSQL &= vbCrLf & "     , 0        AS HIRA1_CNT "
            strSQL &= vbCrLf & "     , 0        AS BARA_CNT "
            strSQL &= vbCrLf & "     , 0        AS GAIBU_CNT "
            strSQL &= vbCrLf & "     , 0        AS GAIBU_ZUMI_CNT "
            strSQL &= vbCrLf & "     , 0        AS ASOUKO_TO_BARA_CNT "
            strSQL &= vbCrLf & "   FROM "
            strSQL &= vbCrLf & "       XPLN_OUT "
            strSQL &= vbCrLf & "     , XPLN_OUT_DTL "
            strSQL &= vbCrLf & "     , XSTS_HIKIATE_K1 "
            strSQL &= vbCrLf & "     , TPRG_TRK_BUF "
            strSQL &= vbCrLf & "   WHERE  1 = 1 "
            strSQL &= vbCrLf & "     AND XPLN_OUT.XSYUKKA_NO        = XPLN_OUT_DTL.XSYUKKA_NO(+) "
            strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.FPLAN_KEY     = XSTS_HIKIATE_K1.FPLAN_KEY(+) "
            strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K1.FPALLET_ID = TPRG_TRK_BUF.FPALLET_ID(+) "
            strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XPROGRESS_OUT IN ( " & XPROGRESS_OUT_JHIKIATE & "," & XPROGRESS_OUT_JGAIBU_SOUKO & ") "   '引当済みまたは外部倉庫出荷中
            strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FTRK_BUF_NO   = " & FTRK_BUF_NO_J9000              '自動倉庫
            strSQL &= vbCrLf & "     AND XPLN_OUT.XORDER_NO = '" & TO_STRING(grdList.Item(menmListCol.XORDER_NO, ii).Value) & "' "


            strSQL &= vbCrLf & "   UNION "
            strSQL &= vbCrLf & "   SELECT "
            strSQL &= vbCrLf & "       0        AS ASOUKO_CNT "
            strSQL &= vbCrLf & "     , COUNT(0) AS HIRA1_CNT "
            strSQL &= vbCrLf & "     , 0        AS BARA_CNT "
            strSQL &= vbCrLf & "     , 0        AS GAIBU_CNT "
            strSQL &= vbCrLf & "     , 0        AS GAIBU_ZUMI_CNT "
            strSQL &= vbCrLf & "     , 0        AS ASOUKO_TO_BARA_CNT "
            strSQL &= vbCrLf & "   FROM "
            strSQL &= vbCrLf & "       XPLN_OUT "
            strSQL &= vbCrLf & "     , XPLN_OUT_DTL "
            strSQL &= vbCrLf & "     , XSTS_HIKIATE_K1 "
            strSQL &= vbCrLf & "     , TPRG_TRK_BUF "
            strSQL &= vbCrLf & "   WHERE  1 = 1 "
            strSQL &= vbCrLf & "     AND XPLN_OUT.XSYUKKA_NO        = XPLN_OUT_DTL.XSYUKKA_NO(+) "
            strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.FPLAN_KEY     = XSTS_HIKIATE_K1.FPLAN_KEY(+) "
            strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K1.FPALLET_ID = TPRG_TRK_BUF.FPALLET_ID(+) "
            'strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XPROGRESS_OUT = " & XPROGRESS_OUT_JHIKIATE        '引当済み
            strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XPROGRESS_OUT IN ( " & XPROGRESS_OUT_JHIKIATE & "," & XPROGRESS_OUT_JGAIBU_SOUKO & ") "   '引当済みまたは外部倉庫出荷中
            strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FTRK_BUF_NO   = " & FTRK_BUF_NO_J8001             '平置き1
            strSQL &= vbCrLf & "     AND XPLN_OUT.XORDER_NO = '" & TO_STRING(grdList.Item(menmListCol.XORDER_NO, ii).Value) & "' "


            strSQL &= vbCrLf & "   UNION "
            strSQL &= vbCrLf & "   SELECT "
            strSQL &= vbCrLf & "       0        AS ASOUKO_CNT "
            strSQL &= vbCrLf & "     , 0        AS HIRA1_CNT "
            strSQL &= vbCrLf & "     , COUNT(0) AS BARA_CNT "
            strSQL &= vbCrLf & "     , 0        AS GAIBU_CNT "
            strSQL &= vbCrLf & "     , 0        AS GAIBU_ZUMI_CNT "
            strSQL &= vbCrLf & "     , 0        AS ASOUKO_TO_BARA_CNT "
            strSQL &= vbCrLf & "   FROM "
            strSQL &= vbCrLf & "       XPLN_OUT "
            strSQL &= vbCrLf & "     , XPLN_OUT_DTL "
            strSQL &= vbCrLf & "     , XSTS_HIKIATE_K1 "
            strSQL &= vbCrLf & "     , TPRG_TRK_BUF "
            strSQL &= vbCrLf & "   WHERE  1 = 1 "
            strSQL &= vbCrLf & "     AND XPLN_OUT.XSYUKKA_NO        = XPLN_OUT_DTL.XSYUKKA_NO(+) "
            strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.FPLAN_KEY     = XSTS_HIKIATE_K1.FPLAN_KEY(+) "
            strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K1.FPALLET_ID = TPRG_TRK_BUF.FPALLET_ID(+) "
            'strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XPROGRESS_OUT = " & XPROGRESS_OUT_JHIKIATE        '引当済み
            strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XPROGRESS_OUT IN ( " & XPROGRESS_OUT_JHIKIATE & "," & XPROGRESS_OUT_JGAIBU_SOUKO & ") "   '引当済みまたは外部倉庫出荷中
            strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FTRK_BUF_NO   = " & FTRK_BUF_NO_J8000             'ﾊﾞﾗ平置き
            strSQL &= vbCrLf & "     AND XPLN_OUT.XORDER_NO = '" & TO_STRING(grdList.Item(menmListCol.XORDER_NO, ii).Value) & "' "


            strSQL &= vbCrLf & "   UNION "
            strSQL &= vbCrLf & "   SELECT "
            strSQL &= vbCrLf & "       0        AS ASOUKO_CNT "
            strSQL &= vbCrLf & "     , 0        AS HIRA1_CNT "
            strSQL &= vbCrLf & "     , 0        AS BARA_CNT "
            strSQL &= vbCrLf & "     , COUNT(0) AS GAIBU_CNT "
            strSQL &= vbCrLf & "     , 0        AS GAIBU_ZUMI_CNT "
            strSQL &= vbCrLf & "     , 0        AS ASOUKO_TO_BARA_CNT "
            strSQL &= vbCrLf & "   FROM "
            strSQL &= vbCrLf & "       XPLN_OUT "
            strSQL &= vbCrLf & "     , XPLN_OUT_DTL "
            strSQL &= vbCrLf & "     , XSTS_HIKIATE_K1 "
            strSQL &= vbCrLf & "     , TPRG_TRK_BUF "
            strSQL &= vbCrLf & "   WHERE  1 = 1 "
            strSQL &= vbCrLf & "     AND XPLN_OUT.XSYUKKA_NO        = XPLN_OUT_DTL.XSYUKKA_NO(+) "
            strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.FPLAN_KEY     = XSTS_HIKIATE_K1.FPLAN_KEY(+) "
            strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K1.FPALLET_ID = TPRG_TRK_BUF.FPALLET_ID(+) "
            strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XPROGRESS_OUT = " & XPROGRESS_OUT_JHIKIATE        '引当済み
            strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FTRK_BUF_NO IN(" & FTRK_BUF_NO_J8100 & ", " & _
                                                                         FTRK_BUF_NO_J8101 & ", " & _
                                                                         FTRK_BUF_NO_J8102 & ", " & _
                                                                         FTRK_BUF_NO_J8103 & ", " & _
                                                                         FTRK_BUF_NO_J8104 & ", " & _
                                                                         FTRK_BUF_NO_J8105 & ", " & _
                                                                         FTRK_BUF_NO_J8106 & ", " & _
                                                                         FTRK_BUF_NO_J8107 & ", " & _
                                                                         FTRK_BUF_NO_J8108 & ", " & _
                                                                         FTRK_BUF_NO_J8109 & ") "       '外部倉庫1-10
            strSQL &= vbCrLf & "     AND XPLN_OUT.XORDER_NO = '" & TO_STRING(grdList.Item(menmListCol.XORDER_NO, ii).Value) & "' "


            strSQL &= vbCrLf & "   UNION "
            strSQL &= vbCrLf & "    SELECT "
            strSQL &= vbCrLf & "         0        AS ASOUKO_CNT "
            strSQL &= vbCrLf & "       , 0        AS HIRA1_CNT "
            strSQL &= vbCrLf & "       , 0        AS BARA_CNT "
            strSQL &= vbCrLf & "       , 0        AS GAIBU_CNT "
            strSQL &= vbCrLf & "       , COUNT(0) AS GAIBU_ZUMI_CNT "
            strSQL &= vbCrLf & "       , 0        AS ASOUKO_TO_BARA_CNT "
            strSQL &= vbCrLf & "     FROM "
            strSQL &= vbCrLf & "         XPLN_OUT "
            strSQL &= vbCrLf & "       , XPLN_OUT_DTL "
            strSQL &= vbCrLf & "       , XRST_OUT "
            strSQL &= vbCrLf & "       , TPRG_TRK_BUF "
            strSQL &= vbCrLf & "     WHERE  1 = 1 "
            strSQL &= vbCrLf & "       AND XPLN_OUT.XSYUKKA_NO        = XPLN_OUT_DTL.XSYUKKA_NO(+) "
            strSQL &= vbCrLf & "       AND XPLN_OUT_DTL.XSYUKKA_NO    = XRST_OUT.XSYUKKA_NO(+) "
            strSQL &= vbCrLf & "       AND XPLN_OUT_DTL.XPLN_DTL_NO   = XRST_OUT.XPLN_DTL_NO(+) "
            'strSQL &= vbCrLf & "       AND XRST_OUT.FPALLET_ID        = TPRG_TRK_BUF.FPALLET_ID(+) "
            strSQL &= vbCrLf & "       AND XRST_OUT.XPALLET_ID_KARI   = TPRG_TRK_BUF.FPALLET_ID(+) "
            strSQL &= vbCrLf & "       AND XPLN_OUT_DTL.XPROGRESS_OUT = " & XPROGRESS_OUT_JGAIBU_SOUKO
            strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FTRK_BUF_NO IN(" & FTRK_BUF_NO_J8100 & ", " & _
                                                                         FTRK_BUF_NO_J8101 & ", " & _
                                                                         FTRK_BUF_NO_J8102 & ", " & _
                                                                         FTRK_BUF_NO_J8103 & ", " & _
                                                                         FTRK_BUF_NO_J8104 & ", " & _
                                                                         FTRK_BUF_NO_J8105 & ", " & _
                                                                         FTRK_BUF_NO_J8106 & ", " & _
                                                                         FTRK_BUF_NO_J8107 & ", " & _
                                                                         FTRK_BUF_NO_J8108 & ", " & _
                                                                         FTRK_BUF_NO_J8109 & ") "       '自動倉庫1-10
            strSQL &= vbCrLf & "     AND XPLN_OUT.XORDER_NO = '" & TO_STRING(grdList.Item(menmListCol.XORDER_NO, ii).Value) & "' "


            strSQL &= vbCrLf & "   UNION "
            strSQL &= vbCrLf & "   SELECT "
            strSQL &= vbCrLf & "       0        AS ASOUKO_CNT "
            strSQL &= vbCrLf & "     , 0        AS HIRA1_CNT "
            strSQL &= vbCrLf & "     , 0        AS BARA_CNT "
            strSQL &= vbCrLf & "     , 0        AS GAIBU_CNT "
            strSQL &= vbCrLf & "     , 0        AS GAIBU_ZUMI_CNT "
            strSQL &= vbCrLf & "     , COUNT(0) AS ASOUKO_TO_BARA_CNT "
            strSQL &= vbCrLf & "   FROM "
            strSQL &= vbCrLf & "       XPLN_OUT "
            strSQL &= vbCrLf & "     , XPLN_OUT_DTL "
            strSQL &= vbCrLf & "     , XSTS_HIKIATE_K1 "
            strSQL &= vbCrLf & "     , TPRG_TRK_BUF "
            strSQL &= vbCrLf & "   WHERE  1 = 1 "
            strSQL &= vbCrLf & "     AND XPLN_OUT.XSYUKKA_NO        = XPLN_OUT_DTL.XSYUKKA_NO(+) "
            strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.FPLAN_KEY     = XSTS_HIKIATE_K1.FPLAN_KEY(+) "
            strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K1.FPALLET_ID = TPRG_TRK_BUF.FPALLET_ID(+) "
            strSQL &= vbCrLf & "     AND XSTS_HIKIATE_K1.FSAGYOU_KIND  = " & FSAGYOU_KIND_JOUT_BARA         'ﾊﾞﾗ補充
            strSQL &= vbCrLf & "     AND XPLN_OUT_DTL.XPROGRESS_OUT IN ( " & XPROGRESS_OUT_JHIKIATE & "," & XPROGRESS_OUT_JGAIBU_SOUKO & ") "   '引当済みまたは外部倉庫出荷中
            strSQL &= vbCrLf & "     AND TPRG_TRK_BUF.FTRK_BUF_NO   = " & FTRK_BUF_NO_J9000              '自動倉庫
            strSQL &= vbCrLf & "     AND XPLN_OUT.XORDER_NO = '" & TO_STRING(grdList.Item(menmListCol.XORDER_NO, ii).Value) & "' "


            strSQL &= vbCrLf & "   ) A"

            '-----------------------
            '抽出
            '-----------------------
            gobjDb.SQL = strSQL
            objDataSet.Clear()
            strDataSetName = "A"
            gobjDb.GetDataSet(strDataSetName, objDataSet)

            If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
                '(見つかった場合)
                objRow = objDataSet.Tables(strDataSetName).Rows(0)
                intASOUKO_CNT = TO_INTEGER(objRow("ASOUKO_CNT"))                 '他品目出荷  出荷ﾊﾞｰｽ
                intHIRA1_CNT = TO_INTEGER(objRow("HIRA1_CNT"))                   '他品目出荷  平置き1
                intBARA_CNT = TO_INTEGER(objRow("BARA_CNT"))                     '他品目出荷  ﾊﾞﾗ平置き
                intGAIBU_CNT = TO_INTEGER(objRow("GAIBU_CNT"))                   '他品目出荷  外部倉庫
                intGAIBU_ZUMI_CNT = TO_INTEGER(objRow("GAIBU_ZUMI_CNT"))         '外部倉庫 積込み済み
                intASOUKO_TO_BARA_CNT = TO_INTEGER(objRow("ASOUKO_TO_BARA_CNT")) 'ﾊﾞﾗ補充中(自動倉庫→ﾊﾞﾗ平置き)
            Else
                '(見つからない場合)
                intASOUKO_CNT = 0                                                '他品目出荷  出荷ﾊﾞｰｽ
                intHIRA1_CNT = 0                                                 '他品目出荷  平置き1
                intBARA_CNT = 0                                                  '他品目出荷  ﾊﾞﾗ平置き
                intGAIBU_CNT = 0                                                 '他品目出荷  外部倉庫
                intGAIBU_ZUMI_CNT = 0                                            '外部倉庫 積込み済み
                intASOUKO_TO_BARA_CNT = 0                                        'ﾊﾞﾗ補充中(自動倉庫→ﾊﾞﾗ平置き)
            End If

            If intASOUKO_CNT > 0 Then
                '(出荷ﾊﾞｰｽに出荷ある時)
                If intASOUKO_CNT = intASOUKO_TO_BARA_CNT Then
                    '(自動倉庫から出庫の在庫が、ﾊﾞﾗ補充分と同じ数の時[ﾊﾞﾗのみ])
                    grdList.Item(menmListCol.XHIRA1, ii).Value = 1
                    grdList.Item(menmListCol.XHIRA1_DSP, ii).Value = "○"
                Else
                    '(以外の時)
                    grdList.Item(menmListCol.XSYUKKA_BERTH, ii).Value = 1
                    grdList.Item(menmListCol.XSYUKKA_BERTH_DSP, ii).Value = "○"
                End If
            Else
                '(出荷ﾊﾞｰｽに出荷ない時)
                grdList.Item(menmListCol.XSYUKKA_BERTH, ii).Value = 0
                grdList.Item(menmListCol.XSYUKKA_BERTH_DSP, ii).Value = "　"
            End If

            If intHIRA1_CNT > 0 Then
                '(平置きに出荷ある時)
                grdList.Item(menmListCol.XHIRA1, ii).Value = 1
                grdList.Item(menmListCol.XHIRA1_DSP, ii).Value = "○"
            Else
                '(平置きに出荷ない時)
                If intASOUKO_CNT = intASOUKO_TO_BARA_CNT Then
                    '(自動倉庫から出庫の在庫が、ﾊﾞﾗ補充分と同じ数の時[ﾊﾞﾗのみ])
                    '平置きをｸﾘｱしない
                Else
                    '(平置きｸﾘｱの時)
                    grdList.Item(menmListCol.XHIRA1, ii).Value = 0
                    grdList.Item(menmListCol.XHIRA1_DSP, ii).Value = "　"
                End If
            End If

            If (intASOUKO_CNT = 0) And _
               (intHIRA1_CNT = 0) Then
                '(出荷ﾊﾞｰｽと平置き１に出荷ない時)
                If intBARA_CNT > 0 Then
                    '(バラ平置きに出荷ある時)
                    grdList.Item(menmListCol.XHIRA1, ii).Value = 1
                    grdList.Item(menmListCol.XHIRA1_DSP, ii).Value = "○"
                Else
                    '(ﾊﾞﾗ平置きに出荷ない時)
                    If intASOUKO_CNT = intASOUKO_TO_BARA_CNT Then
                        '(自動倉庫から出庫の在庫が、ﾊﾞﾗ補充分と同じ数の時[ﾊﾞﾗのみ])
                        '平置きをｸﾘｱしない
                    Else
                        '(平置きｸﾘｱの時)
                        grdList.Item(menmListCol.XHIRA1, ii).Value = 0
                        grdList.Item(menmListCol.XHIRA1_DSP, ii).Value = "　"
                    End If
                End If
            End If

            If intGAIBU_CNT > 0 Then
                '(外部倉庫に出荷ある時)
                grdList.Item(menmListCol.XGAIBU_SOUKO, ii).Value = 1
                grdList.Item(menmListCol.XGAIBU_SOUKO_DSP, ii).Value = "○"
            Else
                '(外部倉庫に出荷ない時)
                If intGAIBU_ZUMI_CNT > 0 Then
                    '(外部倉庫は積込み済みの時)
                    grdList.Item(menmListCol.XGAIBU_SOUKO, ii).Value = 2
                    grdList.Item(menmListCol.XGAIBU_SOUKO_DSP, ii).Value = "済"
                Else
                    '(以外の時)
                    grdList.Item(menmListCol.XGAIBU_SOUKO, ii).Value = 0
                    grdList.Item(menmListCol.XGAIBU_SOUKO_DSP, ii).Value = "　"
                End If
            End If

        Next


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
#Region "　ﾌﾟﾛﾊﾟﾃｨｾｯﾄ(確認)　                       "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub SetProperty(ByVal objForm As FRM_308041)

        objForm.userXCAR_NO_WARITUKE = txtXCAR_NO_WARITUKE.Text                 '受付車番

        objForm.userXCAR_NO_EDA_WARITUKE = mstrXCAR_NO_EDA_WARITUKE             '受付車番枝番

        objForm.userXGAIBU_SOUKO_SENKOU = TO_STRING(mintXGAIBU_SOUKO_SENKOU)    '外部倉庫先行
        objForm.userXBERTH_SITEI = TO_STRING(mintXBERTH_SITEI)                  'ﾊﾞｰｽ指定
        objForm.userXHIRA1 = TO_STRING(mintXHIRA1)                              '平1出庫判定
        objForm.userXORDER_NO = mstrXORDER_NO                                   '受注№
        objForm.userXNYUKA_JIGYOU_CD = mstrXNYUKA_JIGYOU_CD                     '配送先ｺｰﾄﾞ
        objForm.userXNYUKA_JIGYOU_NM = mstrXNYUKA_JIGYOU_NM                     '配送先名

        objForm.userSCH_XCAR_NO = mudtSEARCH_ITEM.XCAR_NO                       '検索条件_車番
        objForm.userSCH_XSYUKKA_DT = mudtSEARCH_ITEM.XSYUKKA_DT                 '検索条件_出荷日
        objForm.userSCH_XORDER_NO = mudtSEARCH_ITEM.XORDER_NO                   '検索条件_発注№
        objForm.userSCH_XNYUKA_JIGYOU_CD = mudtSEARCH_ITEM.XNYUKA_JIGYOU_CD     '検索条件_配送先ｺｰﾄﾞ
        objForm.userSCH_XIDOU_CD = mudtSEARCH_ITEM.XIDOU_CD                     '検索条件_移動手段ｺｰﾄﾞ
        objForm.userSCH_XGYOSHA_CD = mudtSEARCH_ITEM.XGYOSHA_CD                 '検索条件_業者ｺｰﾄﾞ

        objForm.userGrid = grdList                                              '親画面ｸﾞﾘｯﾄﾞ
        objForm.userCol_XCAR_NO_EDA_WARITUKE = menmListCol.XCAR_NO_EDA_WARITUKE '受付車番枝番ﾘｽﾄｶﾗﾑ位置

    End Sub
#End Region

End Class
