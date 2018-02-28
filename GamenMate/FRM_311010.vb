'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】出荷指示問合せ画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
Imports GamenCommon
#End Region

Public Class FRM_311010

#Region "　共通変数　                               "


    Protected mudtSEARCH_ITEM As New stcSEARCH_ITEM     '検索条件用構造体

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ

    '共通定数
    Private mintSTART_CNT As Integer = 1       '品名取得用の開始定数（品名1～8ｱｲﾃﾑ）
    Private mintEND_CNT As Integer = 8         '品名取得用の終了定数（品名1～8ｱｲﾃﾑ）

    'ｸﾞﾘｯﾄﾞ項目
    Enum menmListCol

        XROWCOUNT                   '行番号
        XSYUKKA_D                   '出荷日
        XSYUKKA_STS                 '出荷状況(進捗状況)
        XSYUKKA_STS_DISP            '出荷状況(進捗状況)(表示用)
        XHENSEI_NO                  '編成No
        XHENSEI_NO_OYA              '親編成No
        XDENPYOU_NO                 '伝票No
        XBUNRUI_NO                  '分類No
        XSYARYOU_NO                 '車輌No
        XTUMI_HOUHOU                '積込方法
        XTUMI_HOUHOU_DISP           '積込方法(表示用)
        XTUMI_HOUKOU                '積込方向
        XTUMI_HOUKOU_DISP           '積込方向(表示用)
        XGYOUSYA_CD                 '業者ｺｰﾄﾞ
        XGYOUSYA_NAME               '業者名
        XSEND_NAME                  '届け先名称
        XSEND_ADDRESS               '住所
        XKINKYU_KBN                 '緊急出荷区分
        XKINKYU_KBN_DISP            '緊急出荷区分(表示用)
        XBERTH_NO                   'ﾊﾞｰｽNo.

        'XEDIT_KBN                   '編集区分
        'XINPUT_PLACE                'ｲﾝﾌﾟｯﾄ場所
        'XINPUT_DT                   'ｲﾝﾌﾟｯﾄ日付
        'XINPUT_NO                   'ｲﾝﾌﾟｯﾄNo.
        'XDATA_DT                    'ﾃﾞｰﾀ日付
        'XSOUKO_CD                   '倉庫ｺｰﾄﾞ
        'XTOU_NO                     '棟ｺｰﾄﾞ
        'XTORIHIKI_KBN               '取引区分
        'XDATA_SYORI                 'ﾃﾞｰﾀ処理
        'XSYASYU_KBN                 '車種区分
        'XUNKOU_NO                   '倉庫別運行No.

        XHINMEI_CD1                 '品名ｺｰﾄﾞ1
        XSYUKKA_NUM1                '出荷数1
        XSAIMOKU1                   '取引区分細目1
        XSAIMOKU1_DISP              '取引区分細目1(表示用)
        ZAIKO_KUBUN1                 '在庫区分1
        XIDOU_KBN1                  '移動区分1

        XHINMEI_CD2
        XSYUKKA_NUM2
        XSAIMOKU2
        XSAIMOKU2_DISP
        ZAIKO_KUBUN2
        XIDOU_KBN2

        XHINMEI_CD3
        XSYUKKA_NUM3
        XSAIMOKU3
        XSAIMOKU3_DISP
        ZAIKO_KUBUN3
        XIDOU_KBN3

        XHINMEI_CD4
        XSYUKKA_NUM4
        XSAIMOKU4
        XSAIMOKU4_DISP
        ZAIKO_KUBUN4
        XIDOU_KBN4

        XHINMEI_CD5
        XSYUKKA_NUM5
        XSAIMOKU5
        XSAIMOKU5_DISP
        ZAIKO_KUBUN5
        XIDOU_KBN5

        XHINMEI_CD6
        XSYUKKA_NUM6
        XSAIMOKU6
        XSAIMOKU6_DISP
        ZAIKO_KUBUN6
        XIDOU_KBN6

        XHINMEI_CD7
        XSYUKKA_NUM7
        XSAIMOKU7
        XSAIMOKU7_DISP
        ZAIKO_KUBUN7
        XIDOU_KBN7

        XHINMEI_CD8
        XSYUKKA_NUM8
        XSAIMOKU8
        XSAIMOKU8_DISP
        ZAIKO_KUBUN8
        XIDOU_KBN8

        DATA68          '未使用
        DATA69          '未使用
        DATA70          '未使用

        MAXCOL                              'ｸﾞﾘｯﾄﾞの列数の最大値

    End Enum

    ''' <summary>ﾁｪｯｸ用列挙体</summary>
    Enum menmCheckCase
        SearchBtn_Click         '検索ﾎﾞﾀﾝｸﾘｯｸ時
        AddBtn_Click            '追加ﾎﾞﾀﾝｸﾘｯｸ時
        UpdateBtn_Click         '変更ﾎﾞﾀﾝｸﾘｯｸ時
        DeleteBtn_Click         '削除ﾎﾞﾀﾝｸﾘｯｸ時
        DispDTLBtn_Click        '詳細表示ﾎﾞﾀﾝｸﾘｯｸ時
    End Enum

#End Region
#Region "  構造体定義                               "
    '検索条件
    Protected Structure stcSEARCH_ITEM
        Dim XSYUKKA_D As String                         '出荷日
        Dim XHENSEI_NO As String                        '編成№
        Dim XDENPYOU_NO As String                       '伝票No.
        Dim XSYUKKA_STS As String                       '進捗状況
    End Structure
#End Region
#Region "  ｲﾍﾞﾝﾄ                                    "
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
        '出荷日                ｾｯﾄ
        '===================================
        cboXSYUKKA_D.cmpMDateTimePicker_D.Value = Now       '出荷日
        'cboXSYUKKA_D.userChecked = False                    'ﾁｪｯｸを外す


        '===================================
        '進捗状況                   ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboXSYUKKA_STS, True)


        '**********************************************************
        ' 編成No            ﾘｾｯﾄ
        '**********************************************************
        txtXHENSEI_NO.Text = ""

        '**********************************************************
        ' 伝票No            ﾘｾｯﾄ
        '**********************************************************
        txtXDENPYOU_NO.Text = ""

        '*********************************************
        ' ﾘｽﾄ表示
        '*********************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)    'ｸﾞﾘｯﾄﾞ初期設定
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
        cboXSYUKKA_D.Dispose()              '出荷日
        txtXHENSEI_NO.Dispose()             '編成№
        txtXDENPYOU_NO.Dispose()            '伝票№
        cboXSYUKKA_STS.Dispose()            '出荷状況
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
#Region "  F4(追加)　ﾎﾞﾀﾝ押下処理　                 "
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

        '************************************
        ' ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        '************************************
        If IsNull(gobjFRM_311011) = False Then
            gobjFRM_311011.Close()
            gobjFRM_311011.Dispose()
            gobjFRM_311011 = Nothing
        End If
        gobjFRM_311011 = New FRM_311011
        Call SetProperty(BUTTONMODE_ADD)                   'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        gobjFRM_311011.userButtonMode = BUTTONMODE_ADD     'ﾎﾞﾀﾝ

        Dim intRet As DialogResult
        intRet = gobjFRM_311011.ShowDialog()            '展開
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
#Region "  F5(変更)　ﾎﾞﾀﾝ押下処理　                 "
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


        '************************************
        ' ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        '************************************
        If IsNull(gobjFRM_311011) = False Then
            gobjFRM_311011.Close()
            gobjFRM_311011.Dispose()
            gobjFRM_311011 = Nothing
        End If
        gobjFRM_311011 = New FRM_311011
        Call SetProperty(BUTTONMODE_UPDATE)                   'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        gobjFRM_311011.userButtonMode = BUTTONMODE_UPDATE     'ﾎﾞﾀﾝ

        Dim intRet As DialogResult
        intRet = gobjFRM_311011.ShowDialog()            '展開
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
#Region "  F6(削除)　ﾎﾞﾀﾝ押下処理　                 "
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

        '************************************
        ' ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        '************************************
        If IsNull(gobjFRM_311011) = False Then
            gobjFRM_311011.Close()
            gobjFRM_311011.Dispose()
            gobjFRM_311011 = Nothing
        End If
        gobjFRM_311011 = New FRM_311011
        Call SetProperty(BUTTONMODE_DELETE)                   'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        gobjFRM_311011.userButtonMode = BUTTONMODE_DELETE     'ﾎﾞﾀﾝ

        Dim intRet As DialogResult
        intRet = gobjFRM_311011.ShowDialog()            '展開
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
#Region "  F7(詳細表示)　ﾎﾞﾀﾝ押下処理　             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F7(詳細表示) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F7Process()

        '*******************************************************
        '入力ﾁｪｯｸ
        '*******************************************************
        If InputCheck(menmCheckCase.DispDTLBtn_Click) = False Then

            Exit Sub

        End If

        '************************************
        ' ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        '************************************
        If IsNull(gobjFRM_311015) = False Then
            gobjFRM_311015.Close()
            gobjFRM_311015.Dispose()
            gobjFRM_311015 = Nothing
        End If
        gobjFRM_311015 = New FRM_311015
        Call SetProperty2()                   'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ

        Dim intRet As DialogResult
        intRet = gobjFRM_311015.ShowDialog()            '展開
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
#Region "　入力ﾁｪｯｸ　                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 入力ﾁｪｯｸ
    ''' </summary>
    ''' <param name="udtCheck_Case">入力ﾁｪｯｸ判別</param>
    ''' <returns>True :入力ﾁｪｯｸ成功 False:入力ﾁｪｯｸ失敗</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function InputCheck(ByVal udtCheck_Case As menmCheckCase) As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        Select Case udtCheck_Case
            Case menmCheckCase.SearchBtn_Click
                '(検索ﾎﾞﾀﾝｸﾘｯｸ時)


                blnCheckErr = False

            Case menmCheckCase.AddBtn_Click
                '(追加ﾎﾞﾀﾝｸﾘｯｸ時)


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


                '==========================
                '進捗状況ﾁｪｯｸ
                '==========================
                '進捗状況が、「未入構」、「受付済み」、「指示済み」以外は削除不可
                Dim strXSYUKKA_STS As String
                strXSYUKKA_STS = TO_STRING(grdList.Item(menmListCol.XSYUKKA_STS, grdList.SelectedRows(0).Index).Value)        '進捗状況

                If strXSYUKKA_STS = TO_STRING(XSYUKKA_STS_JNON) Then
                ElseIf strXSYUKKA_STS = TO_STRING(XSYUKKA_STS_JREQ) Then
                ElseIf strXSYUKKA_STS = TO_STRING(XSYUKKA_STS_JDIR) Then

                Else
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM311010_01, PopupFormType.Ok, PopupIconType.Information)
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
                '進捗状況ﾁｪｯｸ
                '==========================
                '進捗状況が、「未入構」、「受付済み」、「指示済み」以外は削除不可
                Dim strXSYUKKA_STS As String
                strXSYUKKA_STS = TO_STRING(grdList.Item(menmListCol.XSYUKKA_STS, grdList.SelectedRows(0).Index).Value)        '進捗状況

                If strXSYUKKA_STS = TO_STRING(XSYUKKA_STS_JNON) Then
                ElseIf strXSYUKKA_STS = TO_STRING(XSYUKKA_STS_JREQ) Then
                ElseIf strXSYUKKA_STS = TO_STRING(XSYUKKA_STS_JDIR) Then

                Else
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM311010_02, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If


                blnCheckErr = False

            Case menmCheckCase.DispDTLBtn_Click
                '(詳細表示ﾎﾞﾀﾝｸﾘｯｸ時)

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
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 構造体ｾｯﾄ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SearchItem_Set()

        '********************************************************************
        '構造体に値をｾｯﾄ
        '********************************************************************
        If cboXSYUKKA_D.userDispChecked = True Then
            mudtSEARCH_ITEM.XSYUKKA_D = Mid(cboXSYUKKA_D.userDateTimeText, 1, 10)       '出荷日
        Else
            mudtSEARCH_ITEM.XSYUKKA_D = ""
        End If
        mudtSEARCH_ITEM.XHENSEI_NO = txtXHENSEI_NO.Text                             '編成№
        mudtSEARCH_ITEM.XDENPYOU_NO = txtXDENPYOU_NO.Text                           '伝票№
        mudtSEARCH_ITEM.XSYUKKA_STS = TO_STRING(cboXSYUKKA_STS.SelectedValue)       '進捗状況

    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ表示　                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub grdListDisplayChild()

        Dim strSQL As String                    'SQL文
        Dim strSQL2 As String
        Dim objDataSet As New DataSet           'ﾃﾞｰﾀｾｯﾄ
        Dim objDataSet2 As New DataSet
        Dim strDataSetName As String            'ﾃﾞｰﾀｾｯﾄ名
        Dim strDataSetName2 As String
        Dim objRow As DataRow                   '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim objRow2 As DataRow
        Dim objDataTable As New clsGridDataTable70      'ｸﾞﾘｯﾄﾞ用ﾃﾞｰﾀﾃｰﾌﾞﾙ



        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    XPLN_OUT.XSYUKKA_D "                                    '出荷指示.     出荷日
        strSQL &= vbCrLf & "  , XPLN_OUT.XSYUKKA_STS "                                  '出荷指示.     出荷状況(進捗状況)
        strSQL &= vbCrLf & "  , HASH01.FGAMEN_DISP AS XSYUKKA_STS_Dsp "                 '出荷指示.     出荷状況(進捗状況)(表示用)
        strSQL &= vbCrLf & "  , XPLN_OUT.XHENSEI_NO "                                   '出荷指示.     編成No
        strSQL &= vbCrLf & "  , XPLN_OUT.XHENSEI_NO_OYA "                               '出荷指示.     親編成No
        strSQL &= vbCrLf & "  , XPLN_OUT.XDENPYOU_NO "                                  '出荷指示.     伝票No
        strSQL &= vbCrLf & "  , XPLN_OUT.XBUNRUI_NO "                                   '出荷指示.     分類No
        strSQL &= vbCrLf & "  , XPLN_OUT.XSYARYOU_NO "                                  '出荷指示.     車輌No
        strSQL &= vbCrLf & "  , XPLN_OUT.XTUMI_HOUHOU "                                 '出荷指示.     積込方法
        strSQL &= vbCrLf & "  , HASH02.FGAMEN_DISP AS XTUMI_HOUHOU_Dsp "               '出荷指示.     積込方法(表示用)
        strSQL &= vbCrLf & "  , XPLN_OUT.XTUMI_HOUKOU "                                 '出荷指示.     積込方向
        strSQL &= vbCrLf & "  , HASH03.FGAMEN_DISP AS XTUMI_HOUKOU_Dsp "               '出荷指示.     積込方向(表示用)
        strSQL &= vbCrLf & "  , XPLN_OUT.XGYOUSYA_CD "                                  '出荷指示.     業者ｺｰﾄﾞ
        strSQL &= vbCrLf & "  , XMST_GYOUSYA.XGYOUSYA_NAME "                            '業者ﾏｽﾀ.      業者名
        strSQL &= vbCrLf & "  , XPLN_OUT.XSEND_NAME "                                   '出荷指示.     届け先名称
        strSQL &= vbCrLf & "  , XPLN_OUT.XSEND_ADDRESS "                                '出荷指示.     住所
        strSQL &= vbCrLf & "  , XPLN_OUT.XKINKYU_KBN "                                  '出荷指示.     緊急出荷区分
        strSQL &= vbCrLf & "  , HASH04.FGAMEN_DISP AS XKINKYU_KBN_Dsp "                 '出荷指示.     緊急出荷区分(表示用)
        strSQL &= vbCrLf & "  , XPLN_OUT.XBERTH_NO "                                   '出荷指示.     ﾊﾞｰｽ指定

        ' ''strSQL &= vbCrLf & "  , XPLN_OUT.XEDIT_KBN "                                    '出荷指示.     編集区分
        ' ''strSQL &= vbCrLf & "  , XPLN_OUT.XINPUT_PLACE "                                 '出荷指示.     ｲﾝﾌﾟｯﾄ場所
        ' ''strSQL &= vbCrLf & "  , XPLN_OUT.XINPUT_DT "                                    '出荷指示.     ｲﾝﾌﾟｯﾄ日付
        ' ''strSQL &= vbCrLf & "  , XPLN_OUT.XINPUT_NO "                                    '出荷指示.     ｲﾝﾌﾟｯﾄNo.
        ' ''strSQL &= vbCrLf & "  , XPLN_OUT.XDATA_DT "                                     '出荷指示.     ﾃﾞｰﾀ日付
        ' ''strSQL &= vbCrLf & "  , XPLN_OUT.XSOUKO_CD "                                    '出荷指示.     倉庫ｺｰﾄﾞ
        ' ''strSQL &= vbCrLf & "  , XPLN_OUT.XTOU_NO "                                      '出荷指示.     棟ｺｰﾄﾞ
        ' ''strSQL &= vbCrLf & "  , XPLN_OUT.XTORIHIKI_KBN "                                '出荷指示.     取引区分
        ' ''strSQL &= vbCrLf & "  , XPLN_OUT.XDATA_SYORI "                                  '出荷指示.     ﾃﾞｰﾀ処理
        ' ''strSQL &= vbCrLf & "  , XPLN_OUT.XSYASYU_KBN "                                  '出荷指示.     車種区分
        ' ''strSQL &= vbCrLf & "  , XPLN_OUT.XUNKOU_NO "                                    '出荷指示.     倉庫別運行No.

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "      XPLN_OUT "                                                '【出荷指示】
        strSQL &= vbCrLf & "    , XMST_GYOUSYA "                                            '【業者ﾏｽﾀ】
        strSQL &= vbCrLf & "    ," & gobjComFuncFRM.GetSQLHashTableFrom01("HASH01", "XPLN_OUT", "XSYUKKA_STS")
        strSQL &= vbCrLf & "    ," & gobjComFuncFRM.GetSQLHashTableFrom01("HASH02", "XPLN_OUT", "XTUMI_HOUHOU")
        strSQL &= vbCrLf & "    ," & gobjComFuncFRM.GetSQLHashTableFrom01("HASH03", "XPLN_OUT", "XTUMI_HOUKOU")
        strSQL &= vbCrLf & "    ," & gobjComFuncFRM.GetSQLHashTableFrom01("HASH04", "XPLN_OUT", "XKINKYU_KBN")

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE 0 = 0 "
        strSQL &= vbCrLf & "     AND XPLN_OUT.XGYOUSYA_CD = XMST_GYOUSYA.XGYOUSYA_CD(+) "
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH01", "XPLN_OUT", "XSYUKKA_STS")
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH02", "XPLN_OUT", "XTUMI_HOUHOU")
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH03", "XPLN_OUT", "XTUMI_HOUKOU")
        strSQL &= vbCrLf & "     AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH04", "XPLN_OUT", "XKINKYU_KBN")

        '----------------------------------------------
        '出荷日 FROM
        '----------------------------------------------
        If mudtSEARCH_ITEM.XSYUKKA_D <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "      AND XPLN_OUT.XSYUKKA_D = TO_DATE('" & mudtSEARCH_ITEM.XSYUKKA_D & "', 'YYYY/MM/DD')"
        End If

        '----------------------------
        '編成№
        '----------------------------
        If mudtSEARCH_ITEM.XHENSEI_NO <> "" Then
            strSQL &= vbCrLf & "    AND XPLN_OUT.XHENSEI_NO = '" & mudtSEARCH_ITEM.XHENSEI_NO & "' "
        End If

        '----------------------------
        '伝票№
        '----------------------------
        If mudtSEARCH_ITEM.XDENPYOU_NO <> "" Then
            strSQL &= vbCrLf & "    AND XPLN_OUT.XDENPYOU_NO = '" & mudtSEARCH_ITEM.XDENPYOU_NO & "' "
        End If

        '----------------------------
        '進捗状況
        '----------------------------
        If mudtSEARCH_ITEM.XSYUKKA_STS <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "    AND XPLN_OUT.XSYUKKA_STS = '" & mudtSEARCH_ITEM.XSYUKKA_STS & "' "
        End If

        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "    XPLN_OUT.XSYUKKA_D"       '出荷指示.     出荷日
        strSQL &= vbCrLf & "  , XSYUKKA_STS"              '出荷指示.     進捗状況
        strSQL &= vbCrLf & "  , XHENSEI_NO"               '出荷指示.     編成No
        strSQL &= vbCrLf & "  , XDENPYOU_NO"              '出荷指示.     伝票No
        strSQL &= vbCrLf & "  , XBUNRUI_NO"               '出荷指示.     分類No
        strSQL &= vbCrLf & "  , XSYARYOU_NO"              '出荷指示.     車輌No
        strSQL &= vbCrLf & "  , XTUMI_HOUHOU"             '出荷指示.     積込方法
        strSQL &= vbCrLf & "  , XTUMI_HOUKOU"             '出荷指示.     積込方向
        strSQL &= vbCrLf & "  , XGYOUSYA_NAME"            '出荷指示.     業者名
        strSQL &= vbCrLf & "  , XSEND_NAME"               '出荷指示.     届け先名
        strSQL &= vbCrLf


        '============================================================
        '抽出
        '============================================================
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "XPLN_OUT"
        gobjDb.GetDataSet(strDataSetName, objDataSet)


        Dim mFHINMEI_CD(mintEND_CNT) As String                '品名ｺｰﾄﾞ
        Dim mXSYUKKA_KON_PLAN(mintEND_CNT) As String          '出荷予定梱数
        Dim mXSAIMOKU(mintEND_CNT) As String                  '取引区分細目
        Dim mXSAIMOKU_DISP(mintEND_CNT) As String             '取引区分細目(表示用)
        Dim mXZAIKO_KBN(mintEND_CNT) As String                '在庫区分
        Dim mXIDOU_KBN(mintEND_CNT) As String                 '移動区分
        Dim strXHENSEI_NO As String
        Dim strXSYUKKA_D As String
        Dim strXDENPYOU_NO As String
        Dim intII As Integer
        Dim intRowCnt As Integer = 0

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows

                strXHENSEI_NO = TO_STRING(objRow("XHENSEI_NO"))
                strXSYUKKA_D = TO_STRING(objRow("XSYUKKA_D"))
                strXDENPYOU_NO = TO_STRING(objRow("XDENPYOU_NO"))

                '-----------------------
                '抽出SQL作成
                '-----------------------
                strSQL2 = ""
                strSQL2 &= vbCrLf & "SELECT"
                strSQL2 &= vbCrLf & "    XPLN_OUT_DTL.FHINMEI_CD "             '出荷指示詳細.  品名ｺｰﾄﾞ
                strSQL2 &= vbCrLf & "  , XPLN_OUT_DTL.XSYUKKA_KON_PLAN "       '出荷指示詳細.  出荷予定数
                strSQL2 &= vbCrLf & "  , XPLN_OUT_DTL.XSAIMOKU "               '出荷指示詳細.  取引区分細目
                strSQL2 &= vbCrLf & "  , HASH01.FGAMEN_DISP AS XSAIMOKU_Dsp "  '出荷指示詳細.  取引区分細目(表示用)
                strSQL2 &= vbCrLf & "  , XPLN_OUT_DTL.FZAIKO_KUBUN "           '出荷指示詳細.  在庫区分
                strSQL2 &= vbCrLf & "  , XPLN_OUT_DTL.XIDOU_KBN "              '出荷指示詳細.  移動区分
                strSQL2 &= vbCrLf & " FROM"
                strSQL2 &= vbCrLf & "       XPLN_OUT_DTL "
                strSQL2 &= vbCrLf & "    ," & gobjComFuncFRM.GetSQLHashTableFrom01("HASH01", "XPLN_OUT_DTL", "XSAIMOKU")
                strSQL2 &= vbCrLf & " WHERE "
                strSQL2 &= vbCrLf & "       XSYUKKA_D = TO_DATE('" & strXSYUKKA_D & "', 'YYYY/MM/DD')"                      '出荷日
                strSQL2 &= vbCrLf & " AND   XHENSEI_NO = '" & strXHENSEI_NO & "' "                                          '編成No
                strSQL2 &= vbCrLf & " AND   XDENPYOU_NO = '" & strXDENPYOU_NO & "' "                                        '伝票No
                strSQL2 &= vbCrLf & " AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH01", "XPLN_OUT_DTL", "XSAIMOKU")
                strSQL2 &= vbCrLf & " ORDER BY  "
                strSQL2 &= vbCrLf & "    XOUT_ORDER "              '出荷指示詳細.  車輌内出荷品目順

                objDataSet2.Clear()
                gobjDb.SQL = strSQL2
                objDataSet2.Clear()
                strDataSetName2 = "XPLN_OUT_DTL"
                gobjDb.GetDataSet(strDataSetName2, objDataSet2)

                '-----------------------
                '変数ﾃﾞｰﾀ初期化
                '-----------------------
                For jj As Integer = mintSTART_CNT To mintEND_CNT
                    mFHINMEI_CD(jj) = ""              '品名ｺｰﾄﾞ
                    mXSYUKKA_KON_PLAN(jj) = ""        '出荷予定梱数
                    mXSAIMOKU(jj) = ""                '取引区分細目
                    mXSAIMOKU_DISP(jj) = ""           '取引区分細目(表示用)
                    mXZAIKO_KBN(jj) = ""              '在庫区分
                    mXIDOU_KBN(jj) = ""               '移動区分
                Next

                intII = mintSTART_CNT               '品名取得用の開始定数（品名1～8ｱｲﾃﾑ）

                If objDataSet2.Tables(strDataSetName2).Rows.Count > 0 Then
                    '-----------------------
                    '変数ﾃﾞｰﾀｾｯﾄ
                    '-----------------------
                    For Each objRow2 In objDataSet2.Tables(strDataSetName2).Rows
                        mFHINMEI_CD(intII) = TO_STRING(objRow2("FHINMEI_CD"))              '品名ｺｰﾄﾞ
                        mXSYUKKA_KON_PLAN(intII) = TO_STRING(objRow2("XSYUKKA_KON_PLAN"))  '出荷予定梱数
                        mXSAIMOKU(intII) = TO_STRING(objRow2("XSAIMOKU"))                  '取引区分細目
                        mXSAIMOKU_DISP(intII) = TO_STRING(objRow2("XSAIMOKU_Dsp"))         '取引区分細目(表示用)
                        mXZAIKO_KBN(intII) = TO_STRING(objRow2("FZAIKO_KUBUN"))            '在庫区分
                        mXIDOU_KBN(intII) = TO_STRING(objRow2("XIDOU_KBN"))                '移動区分
                        intII += 1
                    Next
                End If

                intRowCnt += 1

                '-----------------------
                'ﾃﾞｰﾀｾｯﾄ
                '-----------------------
                objDataTable.userAddRowDataSet _
                    ( _
                    TO_STRING(intRowCnt), TO_STRING(objRow("XSYUKKA_D")), TO_STRING(objRow("XSYUKKA_STS")), TO_STRING(objRow("XSYUKKA_STS_Dsp")), _
                    TO_STRING(objRow("XHENSEI_NO")), TO_STRING(objRow("XHENSEI_NO_OYA")), TO_STRING(objRow("XDENPYOU_NO")), _
                    TO_STRING(objRow("XBUNRUI_NO")), TO_STRING(objRow("XSYARYOU_NO")), TO_STRING(objRow("XTUMI_HOUHOU")), _
                    TO_STRING(objRow("XTUMI_HOUHOU_Dsp")), TO_STRING(objRow("XTUMI_HOUKOU")), TO_STRING(objRow("XTUMI_HOUKOU_Dsp")), _
                    TO_STRING(objRow("XGYOUSYA_CD")), TO_STRING(objRow("XGYOUSYA_NAME")), TO_STRING(objRow("XSEND_NAME")), TO_STRING(objRow("XSEND_ADDRESS")), _
                    TO_STRING(objRow("XKINKYU_KBN")), TO_STRING(objRow("XKINKYU_KBN_Dsp")), TO_STRING(objRow("XBERTH_NO")), _
 _
                    TO_STRING(mFHINMEI_CD(1)), TO_STRING(mXSYUKKA_KON_PLAN(1)), TO_STRING(mXSAIMOKU(1)), _
                    TO_STRING(mXSAIMOKU_DISP(1)), TO_STRING(mXZAIKO_KBN(1)), TO_STRING(mXIDOU_KBN(1)), _
                    TO_STRING(mFHINMEI_CD(2)), TO_STRING(mXSYUKKA_KON_PLAN(2)), TO_STRING(mXSAIMOKU(2)), _
                    TO_STRING(mXSAIMOKU_DISP(2)), TO_STRING(mXZAIKO_KBN(2)), TO_STRING(mXIDOU_KBN(2)), _
                    TO_STRING(mFHINMEI_CD(3)), TO_STRING(mXSYUKKA_KON_PLAN(3)), TO_STRING(mXSAIMOKU(3)), _
                    TO_STRING(mXSAIMOKU_DISP(3)), TO_STRING(mXZAIKO_KBN(3)), TO_STRING(mXIDOU_KBN(3)), _
                    TO_STRING(mFHINMEI_CD(4)), TO_STRING(mXSYUKKA_KON_PLAN(4)), TO_STRING(mXSAIMOKU(4)), _
                    TO_STRING(mXSAIMOKU_DISP(4)), TO_STRING(mXZAIKO_KBN(4)), TO_STRING(mXIDOU_KBN(4)), _
                    TO_STRING(mFHINMEI_CD(5)), TO_STRING(mXSYUKKA_KON_PLAN(5)), TO_STRING(mXSAIMOKU(5)), _
                    TO_STRING(mXSAIMOKU_DISP(5)), TO_STRING(mXZAIKO_KBN(5)), TO_STRING(mXIDOU_KBN(5)), _
                    TO_STRING(mFHINMEI_CD(6)), TO_STRING(mXSYUKKA_KON_PLAN(6)), TO_STRING(mXSAIMOKU(6)), _
                    TO_STRING(mXSAIMOKU_DISP(6)), TO_STRING(mXZAIKO_KBN(6)), TO_STRING(mXIDOU_KBN(6)), _
                    TO_STRING(mFHINMEI_CD(7)), TO_STRING(mXSYUKKA_KON_PLAN(7)), TO_STRING(mXSAIMOKU(7)), _
                    TO_STRING(mXSAIMOKU_DISP(7)), TO_STRING(mXZAIKO_KBN(7)), TO_STRING(mXIDOU_KBN(7)), _
                    TO_STRING(mFHINMEI_CD(8)), TO_STRING(mXSYUKKA_KON_PLAN(8)), TO_STRING(mXSAIMOKU(8)), _
                    TO_STRING(mXSAIMOKU_DISP(8)), TO_STRING(mXZAIKO_KBN(8)), TO_STRING(mXIDOU_KBN(8)) _
                    )

            Next

        End If

        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        grdList.Columns.Clear()
        grdList.DataSource = objDataTable

        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdListSetup()
        Call gobjComFuncFRM.GridSelect(grdList, -1, -1, Nothing)       'ｸﾞﾘｯﾄﾞ選択処理


        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:S.Ouchi 2013/10/30 出荷指示問合せ画面 合計台数表示
        Call DausuSet()
        'JobMate:S.Ouchi 2013/10/30 出荷指示問合せ画面 合計台数表示
        '↑↑↑↑↑↑************************************************************************************************************

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


    End Sub
#End Region
#Region "  ﾒﾝﾃﾅﾝｽ入力画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ　             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾒﾝﾃﾅﾝｽ入力画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ
    ''' </summary>
    ''' <param name="intBtnMode"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SetProperty(ByVal intBtnMode As Integer)


        If intBtnMode = BUTTONMODE_UPDATE Or intBtnMode = BUTTONMODE_DELETE Then
            '(変更または削除のとき)
            gobjFRM_311011.userXSYUKKA_D = TO_STRING(grdList.Item(menmListCol.XSYUKKA_D, grdList.SelectedRows(0).Index).Value)          '出荷日
            gobjFRM_311011.userXHENSEI_NO = TO_STRING(grdList.Item(menmListCol.XHENSEI_NO, grdList.SelectedRows(0).Index).Value)        '編成№
            gobjFRM_311011.userXDENPYOU_NO = TO_STRING(grdList.Item(menmListCol.XDENPYOU_NO, grdList.SelectedRows(0).Index).Value)      '伝票№
            gobjFRM_311011.userFHINMEI_CD1 = TO_STRING(grdList.Item(menmListCol.XHINMEI_CD1, grdList.SelectedRows(0).Index).Value)      '品名ｺｰﾄﾞ1
            gobjFRM_311011.userXSYUKKA_NUM1 = TO_STRING(grdList.Item(menmListCol.XSYUKKA_NUM1, grdList.SelectedRows(0).Index).Value)    '出荷数1
            gobjFRM_311011.userXSAIMOKU1 = TO_STRING(grdList.Item(menmListCol.XSAIMOKU1, grdList.SelectedRows(0).Index).Value)          '取引区分細目1
            gobjFRM_311011.userZAIKO_KUBUN1 = TO_STRING(grdList.Item(menmListCol.ZAIKO_KUBUN1, grdList.SelectedRows(0).Index).Value)      '在庫区分1
            gobjFRM_311011.userXIDOU_KBN1 = TO_STRING(grdList.Item(menmListCol.XIDOU_KBN1, grdList.SelectedRows(0).Index).Value)        '移動区分1
            gobjFRM_311011.userFHINMEI_CD2 = TO_STRING(grdList.Item(menmListCol.XHINMEI_CD2, grdList.SelectedRows(0).Index).Value)      '品名ｺｰﾄﾞ2
            gobjFRM_311011.userXSYUKKA_NUM2 = TO_STRING(grdList.Item(menmListCol.XSYUKKA_NUM2, grdList.SelectedRows(0).Index).Value)    '出荷数2
            gobjFRM_311011.userXSAIMOKU2 = TO_STRING(grdList.Item(menmListCol.XSAIMOKU2, grdList.SelectedRows(0).Index).Value)          '取引区分細目2
            gobjFRM_311011.userZAIKO_KUBUN2 = TO_STRING(grdList.Item(menmListCol.ZAIKO_KUBUN2, grdList.SelectedRows(0).Index).Value)      '在庫区分2
            gobjFRM_311011.userXIDOU_KBN2 = TO_STRING(grdList.Item(menmListCol.XIDOU_KBN2, grdList.SelectedRows(0).Index).Value)        '移動区分2
            gobjFRM_311011.userFHINMEI_CD3 = TO_STRING(grdList.Item(menmListCol.XHINMEI_CD3, grdList.SelectedRows(0).Index).Value)      '品名ｺｰﾄﾞ3
            gobjFRM_311011.userXSYUKKA_NUM3 = TO_STRING(grdList.Item(menmListCol.XSYUKKA_NUM3, grdList.SelectedRows(0).Index).Value)    '出荷数3
            gobjFRM_311011.userXSAIMOKU3 = TO_STRING(grdList.Item(menmListCol.XSAIMOKU3, grdList.SelectedRows(0).Index).Value)          '取引区分細目3
            gobjFRM_311011.userZAIKO_KUBUN3 = TO_STRING(grdList.Item(menmListCol.ZAIKO_KUBUN3, grdList.SelectedRows(0).Index).Value)      '在庫区分3
            gobjFRM_311011.userXIDOU_KBN3 = TO_STRING(grdList.Item(menmListCol.XIDOU_KBN3, grdList.SelectedRows(0).Index).Value)        '移動区分3
            gobjFRM_311011.userFHINMEI_CD4 = TO_STRING(grdList.Item(menmListCol.XHINMEI_CD4, grdList.SelectedRows(0).Index).Value)      '品名ｺｰﾄﾞ4
            gobjFRM_311011.userXSYUKKA_NUM4 = TO_STRING(grdList.Item(menmListCol.XSYUKKA_NUM4, grdList.SelectedRows(0).Index).Value)    '出荷数4
            gobjFRM_311011.userXSAIMOKU4 = TO_STRING(grdList.Item(menmListCol.XSAIMOKU4, grdList.SelectedRows(0).Index).Value)          '取引区分細目4
            gobjFRM_311011.userZAIKO_KUBUN4 = TO_STRING(grdList.Item(menmListCol.ZAIKO_KUBUN4, grdList.SelectedRows(0).Index).Value)      '在庫区分4
            gobjFRM_311011.userXIDOU_KBN4 = TO_STRING(grdList.Item(menmListCol.XIDOU_KBN4, grdList.SelectedRows(0).Index).Value)        '移動区分4
            gobjFRM_311011.userFHINMEI_CD5 = TO_STRING(grdList.Item(menmListCol.XHINMEI_CD5, grdList.SelectedRows(0).Index).Value)      '品名ｺｰﾄﾞ5
            gobjFRM_311011.userXSYUKKA_NUM5 = TO_STRING(grdList.Item(menmListCol.XSYUKKA_NUM5, grdList.SelectedRows(0).Index).Value)    '出荷数5
            gobjFRM_311011.userXSAIMOKU5 = TO_STRING(grdList.Item(menmListCol.XSAIMOKU5, grdList.SelectedRows(0).Index).Value)          '取引区分細目5
            gobjFRM_311011.userZAIKO_KUBUN5 = TO_STRING(grdList.Item(menmListCol.ZAIKO_KUBUN5, grdList.SelectedRows(0).Index).Value)      '在庫区分5
            gobjFRM_311011.userXIDOU_KBN5 = TO_STRING(grdList.Item(menmListCol.XIDOU_KBN5, grdList.SelectedRows(0).Index).Value)        '移動区分5
            gobjFRM_311011.userFHINMEI_CD6 = TO_STRING(grdList.Item(menmListCol.XHINMEI_CD6, grdList.SelectedRows(0).Index).Value)      '品名ｺｰﾄﾞ6
            gobjFRM_311011.userXSYUKKA_NUM6 = TO_STRING(grdList.Item(menmListCol.XSYUKKA_NUM6, grdList.SelectedRows(0).Index).Value)    '出荷数6
            gobjFRM_311011.userXSAIMOKU6 = TO_STRING(grdList.Item(menmListCol.XSAIMOKU6, grdList.SelectedRows(0).Index).Value)          '取引区分細目6
            gobjFRM_311011.userZAIKO_KUBUN6 = TO_STRING(grdList.Item(menmListCol.ZAIKO_KUBUN6, grdList.SelectedRows(0).Index).Value)      '在庫区分6
            gobjFRM_311011.userXIDOU_KBN6 = TO_STRING(grdList.Item(menmListCol.XIDOU_KBN6, grdList.SelectedRows(0).Index).Value)        '移動区分6
            gobjFRM_311011.userFHINMEI_CD7 = TO_STRING(grdList.Item(menmListCol.XHINMEI_CD7, grdList.SelectedRows(0).Index).Value)      '品名ｺｰﾄﾞ7
            gobjFRM_311011.userXSYUKKA_NUM7 = TO_STRING(grdList.Item(menmListCol.XSYUKKA_NUM7, grdList.SelectedRows(0).Index).Value)    '出荷数7
            gobjFRM_311011.userXSAIMOKU7 = TO_STRING(grdList.Item(menmListCol.XSAIMOKU7, grdList.SelectedRows(0).Index).Value)          '取引区分細目7
            gobjFRM_311011.userZAIKO_KUBUN7 = TO_STRING(grdList.Item(menmListCol.ZAIKO_KUBUN7, grdList.SelectedRows(0).Index).Value)      '在庫区分7
            gobjFRM_311011.userXIDOU_KBN7 = TO_STRING(grdList.Item(menmListCol.XIDOU_KBN7, grdList.SelectedRows(0).Index).Value)        '移動区分7
            gobjFRM_311011.userFHINMEI_CD8 = TO_STRING(grdList.Item(menmListCol.XHINMEI_CD8, grdList.SelectedRows(0).Index).Value)      '品名ｺｰﾄﾞ8
            gobjFRM_311011.userXSYUKKA_NUM8 = TO_STRING(grdList.Item(menmListCol.XSYUKKA_NUM8, grdList.SelectedRows(0).Index).Value)    '出荷数8
            gobjFRM_311011.userXSAIMOKU8 = TO_STRING(grdList.Item(menmListCol.XSAIMOKU8, grdList.SelectedRows(0).Index).Value)          '取引区分細目8
            gobjFRM_311011.userZAIKO_KUBUN8 = TO_STRING(grdList.Item(menmListCol.ZAIKO_KUBUN8, grdList.SelectedRows(0).Index).Value)      '在庫区分8
            gobjFRM_311011.userXIDOU_KBN8 = TO_STRING(grdList.Item(menmListCol.XIDOU_KBN8, grdList.SelectedRows(0).Index).Value)        '移動区分8
        End If

    End Sub

#End Region
#Region "  出荷指示詳細画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ　             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 出荷指示詳細画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SetProperty2()

        gobjFRM_311015.userMenuFlg = False                                  'ﾒﾆｭｰ呼び出しﾌﾗｸﾞ

        If grdList.SelectedCells.Count = 0 Then
            '(未選択時)
            If cboXSYUKKA_D.userChecked = True Then                             '出荷日付
                gobjFRM_311015.userXSYUKKA_D = Mid(cboXSYUKKA_D.userDateTimeText, 1, 10)
            Else
                gobjFRM_311015.userXSYUKKA_D = ""
            End If
            gobjFRM_311015.userXHENSEI_NO = txtXHENSEI_NO.Text                             '編成№
            gobjFRM_311015.userXDENPYOU_NO = txtXDENPYOU_NO.Text                           '伝票№
            gobjFRM_311015.userXSYUKKA_STS = TO_STRING(cboXSYUKKA_STS.SelectedValue)       '進捗状況

        Else
            '(ｾﾙ選択時)
            gobjFRM_311015.userXSYUKKA_D = TO_STRING(grdList.Item(menmListCol.XSYUKKA_D, grdList.SelectedRows(0).Index).Value)          '出荷日
            gobjFRM_311015.userXHENSEI_NO = TO_STRING(grdList.Item(menmListCol.XHENSEI_NO, grdList.SelectedRows(0).Index).Value)        '編成№
            gobjFRM_311015.userXDENPYOU_NO = TO_STRING(grdList.Item(menmListCol.XDENPYOU_NO, grdList.SelectedRows(0).Index).Value)      '伝票№
            gobjFRM_311015.userXSYUKKA_STS = TO_STRING(grdList.Item(menmListCol.XSYUKKA_STS, grdList.SelectedRows(0).Index).Value)      '進捗状況

        End If

    End Sub
#End Region
    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:S.Ouchi 2013/10/30 出荷指示問合せ画面 合計台数表示
#Region "　ｸﾞﾘｯﾄﾞ表示　                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub DausuSet()

        Dim strSQL As String                    'SQL文
        Dim objDataSet As New DataSet           'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String            'ﾃﾞｰﾀｾｯﾄ名


        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    XPLN_OUT.XSYUKKA_D"                                         '出荷指示.     出荷日
        strSQL &= vbCrLf & "  , XPLN_OUT.XHENSEI_NO_OYA"                                    '出荷指示.     編成№

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "      XPLN_OUT "                                                '【出荷指示】

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE 0 = 0 "

        '----------------------------------------------
        '出荷日 FROM
        '----------------------------------------------
        If mudtSEARCH_ITEM.XSYUKKA_D <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "      AND XPLN_OUT.XSYUKKA_D = TO_DATE('" & mudtSEARCH_ITEM.XSYUKKA_D & "', 'YYYY/MM/DD')"
        End If

        '----------------------------
        '編成№
        '----------------------------
        If mudtSEARCH_ITEM.XHENSEI_NO <> "" Then
            strSQL &= vbCrLf & "    AND XPLN_OUT.XHENSEI_NO = '" & mudtSEARCH_ITEM.XHENSEI_NO & "' "
        End If

        '----------------------------
        '伝票№
        '----------------------------
        If mudtSEARCH_ITEM.XDENPYOU_NO <> "" Then
            strSQL &= vbCrLf & "    AND XPLN_OUT.XDENPYOU_NO = '" & mudtSEARCH_ITEM.XDENPYOU_NO & "' "
        End If

        '----------------------------
        '進捗状況
        '----------------------------
        If mudtSEARCH_ITEM.XSYUKKA_STS <> CBO_ALL_VALUE Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "    AND XPLN_OUT.XSYUKKA_STS = '" & mudtSEARCH_ITEM.XSYUKKA_STS & "' "
        End If

        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & " GROUP BY "
        strSQL &= vbCrLf & "    XPLN_OUT.XSYUKKA_D"                                         '出荷指示.     出荷日
        strSQL &= vbCrLf & "  , XPLN_OUT.XHENSEI_NO_OYA"                                    '出荷指示.     編成№
        strSQL &= vbCrLf


        '============================================================
        '抽出
        '============================================================
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "XPLN_OUT"
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        '============================================================
        '合計台数表示
        '============================================================
        lblXDAISU.Text = TO_STRING(objDataSet.Tables(strDataSetName).Rows.Count)            '合計台数


    End Sub
#End Region
    'JobMate:S.Ouchi 2013/10/30 出荷指示問合せ画面 合計台数表示
    '↑↑↑↑↑↑************************************************************************************************************
End Class
