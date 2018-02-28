'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】品名ﾏｽﾀﾒﾝﾃﾅﾝｽ画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_206010

#Region "　共通変数　                           "

    '検索条件用構造体
    Private mudtSEARCH_ITEM As New SEARCH_ITEM

    'ｸﾞﾘｯﾄﾞ項目
    Enum menmListCol

        XHINMEI_CD                  '品目ﾏｽﾀ.			品目ｺｰﾄﾞ
        FHINMEI_CD                  '品目ﾏｽﾀ.			品目記号
        FHINMEI                     '品目ﾏｽﾀ.			品名
        FNUM_IN_PALLET              '品目ﾏｽﾀ.			PL毎積載数(ﾊﾟﾚｯﾄ積付数)
        FRAC_FORM                   '品目ﾏｽﾀ.           棚形状種別
        FRAC_FORM_DSP               '品目ﾏｽﾀ.           棚形状種別(表示用)
        XPLANE_PACK_NUMBER          '品目ﾏｽﾀ.           平面梱数
        XWEIGHT_IN_CASE             '品目ﾏｽﾀ.           梱重量
        XHEIGHT_IN_CASE             '品目ﾏｽﾀ.           梱高さ
        XWEIGHT_IN_PALLET           '品目ﾏｽﾀ.           ﾊﾟﾚｯﾄあたりの重量(1PL当重量)
        XDAN_IN_PALLET              '品目ﾏｽﾀ.           1ﾊﾟﾚｯﾄの段数(1PL当段数)
        XHEIGHT_IN_PALLET           '品目ﾏｽﾀ.           ﾊﾟﾚｯﾄ高さ(1PL当高さ)
        XARTICLE_TYPE_CODE          '品目ﾏｽﾀ.           品目種別
        XARTICLE_TYPE_CODE_DSP      '品目ﾏｽﾀ.           品目種別(表示用)
        XSUB_CD                     '品目ﾏｽﾀ.           ｻﾌﾞｺｰﾄﾞ
        XITF_CD                     '品目ﾏｽﾀ.           ITFｺｰﾄﾞ
        XJAN_CD                     '品目ﾏｽﾀ.           JANｺｰﾄﾞ
        XMAKER_CD                   '品目ﾏｽﾀ.           ﾒｰｶｰｺｰﾄﾞ
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/06/26 ｱｲﾃﾑ変更
        'FRAC_BUNRUI                 '品目ﾏｽﾀ.           棚分類
        XIN_RES_TYPE                '品目ﾏｽﾀ.           空棚引当ﾀｲﾌﾟ
        XIN_RES_TYPE_DSP            '品目ﾏｽﾀ.           空棚引当ﾀｲﾌﾟ(表示用)
        '↑↑↑↑↑↑************************************************************************************************************
        FUPDATE_DT                  '品目ﾏｽﾀ.           更新日時(最終更新日時)

        MAXCOL

    End Enum

    '入力ﾁｪｯｸ場合判別
    Enum menmCheckCase
        AddBtn_Click                    '追加ﾎﾞﾀﾝｸﾘｯｸ時
        UpdateBtn_Click                 '変更ﾎﾞﾀﾝｸﾘｯｸ時
        DeleteBtn_Click                 '削除ﾎﾞﾀﾝｸﾘｯｸ時
        Print_Click                     '印刷ﾎﾞﾀﾝｸﾘｯｸ時
    End Enum

#End Region
#Region "  構造体定義                           "
    '検索条件
    Private Structure SEARCH_ITEM
        Dim FHINMEI_CD As String        '品名ｺｰﾄﾞ
    End Structure
#End Region
#Region "　ｲﾍﾞﾝﾄ　                              "
#Region "　ﾌｫｰﾑｱｸﾃｨﾌﾞ                           "
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
#Region "　ﾌｫｰﾑﾛｰﾄﾞ                             "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub InitializeChild()

        '*********************************************
        ' ｸﾞﾘｯﾄﾞ初期化
        '*********************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListSetup()

        '************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '************************************
        Call grdListDisplaySub(grdList)

    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ                           "
    Public Overrides Sub CloseChild()

        '******************************************
        ' ｺﾝﾄﾛｰﾙの開放
        '******************************************
        grdList.Dispose()               'ｸﾞﾘｯﾄﾞ

    End Sub
#End Region
    '↓↓↓↓↓↓************************************************************************************************************
    'JobMate:S.Ouchi 2013/11/05 品名ﾏｽﾀﾒﾝﾃﾅﾝｽ画面で品名ｺｰﾄﾞ/記号の直接指定
#Region "  F4(品名ｺｰﾄﾞ/記号選択)　ﾎﾞﾀﾝ押下処理  "
    '*******************************************************************************************************************
    '【機能】F3  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F3Process()

        '************************************
        ' ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        '************************************
        If IsNull(gobjFRM_206012) = False Then
            gobjFRM_206012.Close()
            gobjFRM_206012.Dispose()
            gobjFRM_206012 = Nothing
        End If
        gobjFRM_206012 = New FRM_206012

        Dim intRet As DialogResult
        intRet = gobjFRM_206012.ShowDialog()            '展開
        If intRet = System.Windows.Forms.DialogResult.Cancel = True Then
            '(ｷｬﾝｾﾙ時)
            Exit Sub
        End If

        If gobjFRM_206012.userButtonMode = BUTTONMODE_UPDATE And _
           gobjFRM_206012.userFHINMEI_CD <> "" Then
            '************************************
            ' ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
            '************************************
            If IsNull(gobjFRM_206011) = False Then
                gobjFRM_206011.Close()
                gobjFRM_206011.Dispose()
                gobjFRM_206011 = Nothing
            End If
            gobjFRM_206011 = New FRM_206011
            gobjFRM_206011.userFHINMEI_CD = gobjFRM_206012.userFHINMEI_CD   '品名ｺｰﾄﾞ
            gobjFRM_206011.userButtonMode = BUTTONMODE_UPDATE               'ﾎﾞﾀﾝ

            intRet = gobjFRM_206011.ShowDialog()                            '展開
            If intRet = System.Windows.Forms.DialogResult.Cancel = True Then
                '(ｷｬﾝｾﾙ時)
                Exit Sub
            End If
        ElseIf gobjFRM_206012.userButtonMode = BUTTONMODE_DELETE And _
               gobjFRM_206012.userFHINMEI_CD <> "" Then
            '************************************
            ' ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
            '************************************
            If IsNull(gobjFRM_206011) = False Then
                gobjFRM_206011.Close()
                gobjFRM_206011.Dispose()
                gobjFRM_206011 = Nothing
            End If
            gobjFRM_206011 = New FRM_206011
            gobjFRM_206011.userFHINMEI_CD = gobjFRM_206012.userFHINMEI_CD   '品名ｺｰﾄﾞ
            gobjFRM_206011.userButtonMode = BUTTONMODE_DELETE               'ﾎﾞﾀﾝ

            intRet = gobjFRM_206011.ShowDialog()                            '展開
            If intRet = System.Windows.Forms.DialogResult.Cancel = True Then
                '(ｷｬﾝｾﾙ時)
                Exit Sub
            End If
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
    'JobMate:S.Ouchi 2013/11/05 品名ﾏｽﾀﾒﾝﾃﾅﾝｽ画面で品名ｺｰﾄﾞ/記号の直接指定
    '↑↑↑↑↑↑************************************************************************************************************
#Region "  F4(追加)　ﾎﾞﾀﾝ押下処理　             "
    '*******************************************************************************************************************
    '【機能】F4  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
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
        If IsNull(gobjFRM_206011) = False Then
            gobjFRM_206011.Close()
            gobjFRM_206011.Dispose()
            gobjFRM_206011 = Nothing
        End If
        gobjFRM_206011 = New FRM_206011
        Call SetProperty(BUTTONMODE_ADD)                   'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        gobjFRM_206011.userButtonMode = BUTTONMODE_ADD     'ﾎﾞﾀﾝ

        Dim intRet As DialogResult
        intRet = gobjFRM_206011.ShowDialog()            '展開
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
#Region "  F5(変更)　ﾎﾞﾀﾝ押下処理　             "
    '*******************************************************************************************************************
    '【機能】F5  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
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
        If IsNull(gobjFRM_206011) = False Then
            gobjFRM_206011.Close()
            gobjFRM_206011.Dispose()
            gobjFRM_206011 = Nothing
        End If
        gobjFRM_206011 = New FRM_206011
        Call SetProperty(BUTTONMODE_UPDATE)                                 'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        gobjFRM_206011.userButtonMode = BUTTONMODE_UPDATE     'ﾎﾞﾀﾝ

        Dim intRet As DialogResult
        intRet = gobjFRM_206011.ShowDialog()            '展開
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
#Region "  F6(削除)　ﾎﾞﾀﾝ押下処理　             "
    '*******************************************************************************************************************
    '【機能】F6  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
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
        If IsNull(gobjFRM_206011) = False Then
            gobjFRM_206011.Close()
            gobjFRM_206011.Dispose()
            gobjFRM_206011 = Nothing
        End If
        gobjFRM_206011 = New FRM_206011
        Call SetProperty(BUTTONMODE_DELETE)                                 'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        gobjFRM_206011.userButtonMode = BUTTONMODE_DELETE     'ﾎﾞﾀﾝ

        Dim intRet As DialogResult
        intRet = gobjFRM_206011.ShowDialog()            '展開
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
#Region "  F7(印刷)  ﾎﾞﾀﾝ押下処理               "
    '*******************************************************************************************************************
    '【機能】F7  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F7Process()

        '**********************************************************
        ' ﾘｽﾄ表示
        '**********************************************************
        Call grdListDisplaySub(grdList)

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.Print_Click) = False Then
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
        Call printOut()


    End Sub
#End Region

#Region "　入力ﾁｪｯｸ　                           "
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
                '在庫有無確認
                '==========================
                Dim FHINMEI_CD As String = ""
                FHINMEI_CD = TO_STRING(grdList.Item(menmListCol.FHINMEI_CD, grdList.SelectedRows(0).Index).Value)
                Dim intCount As Integer = 0     '個数
                Dim objTBL_TRST_STOCK As New TBL_TRST_STOCK(gobjOwner, gobjDb, Nothing)
                objTBL_TRST_STOCK.FHINMEI_CD = FHINMEI_CD

                intCount = objTBL_TRST_STOCK.GET_TRST_STOCK_COUNT
                If intCount > 0 Then
                    '(在庫に1件以上存在する場合)
                    Call gobjComFuncFRM.DisplayPopup("在庫が存在しているため、削除できません。", PopupFormType.Ok, PopupIconType.Information)
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
#Region "　構造体ｾｯﾄ　                          "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub SearchItem_Set()

        ' ''********************************************************************
        ' ''構造体に値をｾｯﾄ
        ' ''********************************************************************
        ' ''===============================================
        ' '' 品名ｺｰﾄﾞ
        ' ''===============================================
        ''mudtSEARCH_ITEM.FHINMEI_CD = TO_STRING(cboFHINMEI_CD.Text)

    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ表示　                         "
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
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "     TMST_ITEM.XHINMEI_CD "                                 '品目ﾏｽﾀ.			品目記号
        strSQL &= vbCrLf & "   , TMST_ITEM.FHINMEI_CD "                                 '品目ﾏｽﾀ.			品目ｺｰﾄﾞ
        strSQL &= vbCrLf & "   , TMST_ITEM.FHINMEI "                                    '品目ﾏｽﾀ.			品名_正式名
        strSQL &= vbCrLf & "   , TMST_ITEM.FNUM_IN_PALLET "                             '品目ﾏｽﾀ.           PL毎積載数(ﾊﾟﾚｯﾄ積付数)
        strSQL &= vbCrLf & "   , TMST_ITEM.FRAC_FORM "                                  '品目ﾏｽﾀ.           棚形状種別
        strSQL &= vbCrLf & "   , HASH01.FGAMEN_DISP         AS FRAC_FORM_DSP "          '品目ﾏｽﾀ.           棚形状種別(表示用)
        strSQL &= vbCrLf & "   , TMST_ITEM.XPLANE_PACK_NUMBER "                         '品目ﾏｽﾀ.           平面梱数
        strSQL &= vbCrLf & "   , TMST_ITEM.XWEIGHT_IN_CASE "                            '品目ﾏｽﾀ.           梱重量
        strSQL &= vbCrLf & "   , TMST_ITEM.XHEIGHT_IN_CASE "                            '品目ﾏｽﾀ.           梱高さ
        strSQL &= vbCrLf & "   , TMST_ITEM.XWEIGHT_IN_PALLET "                          '品目ﾏｽﾀ.           ﾊﾟﾚｯﾄあたりの重量(1PL当重量)
        strSQL &= vbCrLf & "   , TMST_ITEM.XDAN_IN_PALLET "                             '品目ﾏｽﾀ.           1ﾊﾟﾚｯﾄの段数(1PL当段数)
        strSQL &= vbCrLf & "   , TMST_ITEM.XHEIGHT_IN_PALLET "                          '品目ﾏｽﾀ.           ﾊﾟﾚｯﾄ高さ(1PL当高さ)
        strSQL &= vbCrLf & "   , TMST_ITEM.XARTICLE_TYPE_CODE "                         '品目ﾏｽﾀ.           品目種別
        strSQL &= vbCrLf & "   , HASH02.FGAMEN_DISP         AS XARTICLE_TYPE_CODE_DSP " '品目ﾏｽﾀ.           品目種別(表示用)
        strSQL &= vbCrLf & "   , TMST_ITEM.XSUB_CD "                                    '品目ﾏｽﾀ.           ｻﾌﾞｺｰﾄﾞ
        strSQL &= vbCrLf & "   , TMST_ITEM.XITF_CD "                                    '品目ﾏｽﾀ.           ITFｺｰﾄﾞ
        strSQL &= vbCrLf & "   , TMST_ITEM.XJAN_CD "                                    '品目ﾏｽﾀ.           JANｺｰﾄﾞ
        strSQL &= vbCrLf & "   , TMST_ITEM.XMAKER_CD "                                  '品目ﾏｽﾀ.           ﾒｰｶｰｺｰﾄﾞ
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/06/26 ｱｲﾃﾑ変更
        'strSQL &= vbCrLf & "   , TMST_ITEM.FRAC_BUNRUI "                                '品目ﾏｽﾀ.           棚分類
        strSQL &= vbCrLf & "   , TMST_ITEM.XIN_RES_TYPE "                               '品目ﾏｽﾀ.           空棚引当ﾀｲﾌﾟ
        strSQL &= vbCrLf & "   , HASH03.FGAMEN_DISP         AS XIN_RES_TYPE_DSP "       '品目ﾏｽﾀ.           空棚引当ﾀｲﾌﾟ(表示用)
        '↑↑↑↑↑↑************************************************************************************************************
        strSQL &= vbCrLf & "   , TMST_ITEM.FUPDATE_DT "                                 '品目ﾏｽﾀ.           更新日時(最終更新日時)

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "     TMST_ITEM "                                            '品名ﾏｽﾀ
        strSQL &= vbCrLf & "   , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH01", "TMST_ITEM", "FRAC_FORM")
        strSQL &= vbCrLf & "   , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH02", "TMST_ITEM", "XARTICLE_TYPE_CODE")
        strSQL &= vbCrLf & "   , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH03", "TMST_ITEM", "XIN_RES_TYPE")

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE 1 = 1 "          '必ず通る条件
        strSQL &= vbCrLf & "   AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH01", "TMST_ITEM", "FRAC_FORM")
        strSQL &= vbCrLf & "   AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH02", "TMST_ITEM", "XARTICLE_TYPE_CODE")
        strSQL &= vbCrLf & "   AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH03", "TMST_ITEM", "XIN_RES_TYPE")

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
#Region "　ｸﾞﾘｯﾄﾞ表示設定　                     "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub grdListSetup()

        '************************************************
        '搬送管理量小数点表示
        '************************************************
        ''Call gobjComFuncFRM.GridFTR_VOLChange01(grdList, menmListCol.XKOSOU_UNIT_NUM, menmListCol.FDECIMAL_POINT)

        '************************************************
        'ｸﾞﾘｯﾄﾞﾏｽﾀの定義を反映
        '************************************************
        Call gobjComFuncFRM.TDSP_GRIDSetup(Me, grdList)

    End Sub
#End Region
#Region "  ﾒﾝﾃﾅﾝｽ入力画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ　         "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】 
    '*******************************************************************************************************************
    Private Sub SetProperty(ByVal intBtnMode As Integer)

        Dim intRow As Integer = 0

        If intBtnMode = BUTTONMODE_ADD Then
            '(追加のとき)
            gobjFRM_206011.userFHINMEI_CD = Nothing             '品名ｺｰﾄﾞ

        ElseIf intBtnMode = BUTTONMODE_UPDATE Then
            '(変更のとき)
            intRow = grdList.SelectedRows(0).Index
            gobjFRM_206011.userFHINMEI_CD = TO_STRING(grdList.Item(menmListCol.FHINMEI_CD, intRow).Value)     '品名ｺｰﾄﾞ

        Else
            '(削除のとき)
            intRow = grdList.SelectedRows(0).Index
            gobjFRM_206011.userFHINMEI_CD = TO_STRING(grdList.Item(menmListCol.FHINMEI_CD, intRow).Value)     '品名ｺｰﾄﾞ

        End If


    End Sub
#End Region
#Region "　印刷処理　                           "
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
        Dim objCR As New PRT_206010_01          'ｸﾘｽﾀﾙﾚﾎﾟｰﾄｵﾌﾞｼﾞｪｸﾄ
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
                objDataRow.Data00 = grdList.Item(menmListCol.XHINMEI_CD, ii).FormattedValue             '品目ｺｰﾄﾞ
                objDataRow.Data01 = grdList.Item(menmListCol.FHINMEI_CD, ii).FormattedValue             '品目記号
                objDataRow.Data02 = grdList.Item(menmListCol.FHINMEI, ii).FormattedValue                '品名
                objDataRow.Data03 = grdList.Item(menmListCol.FNUM_IN_PALLET, ii).FormattedValue         'PL毎積載数(ﾊﾟﾚｯﾄ積付数)
                objDataRow.Data04 = grdList.Item(menmListCol.FRAC_FORM_DSP, ii).FormattedValue          '棚形状種別(表示用)
                objDataRow.Data05 = grdList.Item(menmListCol.XPLANE_PACK_NUMBER, ii).FormattedValue     '平面梱数
                objDataRow.Data06 = grdList.Item(menmListCol.XWEIGHT_IN_CASE, ii).FormattedValue        '梱重量
                objDataRow.Data07 = grdList.Item(menmListCol.XHEIGHT_IN_CASE, ii).FormattedValue        '梱高さ
                objDataRow.Data08 = grdList.Item(menmListCol.XWEIGHT_IN_PALLET, ii).FormattedValue      'ﾊﾟﾚｯﾄあたりの重量(1PL当重量)
                objDataRow.Data09 = grdList.Item(menmListCol.XDAN_IN_PALLET, ii).FormattedValue         '1ﾊﾟﾚｯﾄの段数(1PL当段数)
                objDataRow.Data10 = grdList.Item(menmListCol.XHEIGHT_IN_PALLET, ii).FormattedValue      'ﾊﾟﾚｯﾄ高さ(1PL当高さ)
                objDataRow.Data11 = grdList.Item(menmListCol.XARTICLE_TYPE_CODE_DSP, ii).FormattedValue '品目種別(表示用)
                objDataRow.Data12 = grdList.Item(menmListCol.XSUB_CD, ii).FormattedValue                'ｻﾌﾞｺｰﾄﾞ
                objDataRow.Data13 = grdList.Item(menmListCol.XITF_CD, ii).FormattedValue                'ITFｺｰﾄﾞ
                objDataRow.Data14 = grdList.Item(menmListCol.XJAN_CD, ii).FormattedValue                'JANｺｰﾄﾞ
                objDataRow.Data15 = grdList.Item(menmListCol.XMAKER_CD, ii).FormattedValue              'ﾒｰｶｰｺｰﾄﾞ
                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:H.Okumura 2013/06/26 ｱｲﾃﾑ変更
                'objDataRow.Data16 = grdList.Item(menmListCol.FRAC_BUNRUI, ii).FormattedValue            '棚分類
                objDataRow.Data16 = grdList.Item(menmListCol.XIN_RES_TYPE, ii).FormattedValue           '空棚引当ﾀｲﾌﾟ
                '↑↑↑↑↑↑************************************************************************************************************
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
