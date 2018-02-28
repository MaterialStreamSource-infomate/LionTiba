'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】ロット保留/解除画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_305060

#Region "　共通変数　                               "

    '検索条件用構造体
    Private mudtSEARCH_ITEM As New SEARCH_ITEM

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ

    '選択されたｸﾞﾘｯﾄﾞﾘｽﾄの配列
    'Private mudtGRID_LIST_ITEM() As GRID_LIST_ITEM = Nothing
    Private mstrFPALLET_ID() As String = Nothing
    Private mstrFLOT_NO_STOCK() As String = Nothing

    ''' <summary>ﾁｪｯｸ用列挙体</summary>
    Enum menmCheckCase
        SearchBtn_Click                 '検索ﾎﾞﾀﾝｸﾘｯｸ時
        SelectAll_Click                 '全選択ﾎﾞﾀﾝｸﾘｯｸ時
        NotSelectAll_Click              '全解除ﾎﾞﾀﾝｸﾘｯｸ時
        Entry_Click                     '保留区分登録ﾎﾞﾀﾝｸﾘｯｸ時
    End Enum

    ''' <summary>ｸﾞﾘｯﾄﾞ項目</summary>
    Enum menmListCol
        FPALLET_ID          ' 在庫情報       .パレットID(非表示)
        FLOT_NO_STOCK       ' 在庫情報       .在庫ﾛｯﾄNo.(非表示)
        FTRK_BUF_NO         ' ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№(非表示)
        FBUF_NAME           ' ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称(在庫ｴﾘｱ)
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/06/05 順番変更
        XHINMEI_CD          ' 品目ﾏｽﾀ        .品名記号
        FHINMEI_CD          ' 在庫情報       .品目ｺｰﾄﾞ
        '↑↑↑↑↑↑************************************************************************************************************
        FHINMEI             ' 品目ﾏｽﾀ        .品名
        XPROD_LINE          ' 在庫情報       .生産ﾗｲﾝNo
        FHORYU_KUBUN        ' 在庫情報       .保留区分(非表示)
        FHORYU_KUBUN_DSP    ' 在庫情報       .保留区分
        FTR_VOL             ' 在庫情報       .搬送管理量
        FDISP_ADDRESS       ' ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .表記用ｱﾄﾞﾚｽ(ﾛｹｰｼｮﾝ)
        FARRIVE_DT          ' 在庫情報       .在庫発生日時

        MAXCOL

    End Enum

#End Region
#Region "  構造体定義　                             "

    ''' <summary>検索条件</summary>
    Private Structure SEARCH_ITEM
        Dim FTRK_BUF_NO As String       '在庫ｴﾘｱ
        Dim HINMEI_CD As String         '品名ｺｰﾄﾞ
        Dim ARRIVE_DT_FROM As String    '在庫発生日(FROM)
        Dim ARRIVE_DT_TO As String      '在庫発生日(TO)
        Dim PROD_LINE As String         '生産ﾗｲﾝNo.
        Dim FHORYU_KUBUN As String      '保留区分
    End Structure

    '''' <summary>ｸﾞﾘｯﾄﾞﾘｽﾄ</summary>
    'Private Structure GRID_LIST_ITEM
    '    Dim PALLET_ID As String         'ﾊﾟﾚｯﾄID
    'End Structure

#End Region
#Region "  ｲﾍﾞﾝﾄ                                    "
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

        '===================================
        '在庫ｴﾘｱ ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboFPLACE_CD, True, 0)

        '===================================
        '品名ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ  ｾｯﾄ
        '===================================
        cboFHINMEI_CD.conn = gobjDb
        cboFHINMEI_CD.HinmeiLabel = lblFHINMEI
        cboFHINMEI_CD.Text = ""
        cboFHINMEI_CD.HinmeiVisible = False
        cboFHINMEI_CD.cboSetupHinmeiCd(cboFHINMEI_CD.Text)

        '===================================
        '期間 在庫発生日時  ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.dtpKikanFromToSetup(dtpFrom, dtpTo)
        dtpFrom.userChecked = False
        dtpTo.userChecked = False

        '===================================
        '生産ﾗｲﾝNo.ｺﾝﾎﾞﾎﾞｯｸｽ  ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboMsterSetup("XMST_PROD_LINE", "XPROD_LINE", "XPROD_LINE", "XPROD_LINE_NAME", cboXPROD_LINE)

        '===================================
        '保留区分 ｺﾝﾎﾞﾎﾞｯｸｽ      ｾｯﾄ
        '===================================
        Call gobjComFuncFRM.cboSetup(FDISP_ID_SKOTEI, cboFHORYU_KUBUN, True)

        '*********************************************
        ' ｸﾞﾘｯﾄﾞ初期化
        '*********************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        grdList.MultiSelect = True                                              '複数行選択
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
        cboFHINMEI_CD.Dispose()
        lblFHINMEI.Dispose()
        dtpFrom.Dispose()
        dtpTo.Dispose()
        cboXPROD_LINE.Dispose()
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
        Call grdListDisplaySub(grdList)

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
#Region "  F6(保留区分登録)  ﾎﾞﾀﾝ押下処理　         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F6(保留区分登録) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F6Process()

        '*******************************************************
        '入力ﾁｪｯｸ
        '*******************************************************
        If InputCheck(menmCheckCase.Entry_Click) = False Then
            Exit Sub
        End If

        '************************************
        ' ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        '************************************
        If IsNull(gobjFRM_305061) = False Then
            gobjFRM_305061.Close()
            gobjFRM_305061.Dispose()
            gobjFRM_305061 = Nothing
        End If
        gobjFRM_305061 = New FRM_305061
        Call SetProperty(gobjFRM_305061)                  'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ

        Dim intRet As DialogResult
        intRet = gobjFRM_305061.ShowDialog()            '画面表示
        If intRet = System.Windows.Forms.DialogResult.Cancel = True Then
            '(ｷｬﾝｾﾙ時)
            Exit Sub
        End If


        '*********************************************
        ' 構造体ｾｯﾄ
        '*********************************************
        Call SeachItem_Set()

        '************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '************************************
        Call grdListDisplaySub(grdList)

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
        mudtSEARCH_ITEM.FTRK_BUF_NO = TO_STRING(cboFPLACE_CD.SelectedValue)

        '===============================================
        '品名ｺｰﾄﾞ
        '===============================================
        mudtSEARCH_ITEM.HINMEI_CD = TO_STRING(cboFHINMEI_CD.Text)

        '===============================================
        '入庫日(FROM)
        '===============================================
        If dtpFrom.userDispChecked = True Then
            mudtSEARCH_ITEM.ARRIVE_DT_FROM = dtpFrom.userDateTimeText   '期間FROM
        Else
            mudtSEARCH_ITEM.ARRIVE_DT_FROM = ""
        End If

        '===============================================
        '入庫日(TO)
        '===============================================
        If dtpTo.userDispChecked = True Then
            mudtSEARCH_ITEM.ARRIVE_DT_TO = dtpTo.userDateTimeText       '期間TO
        Else
            mudtSEARCH_ITEM.ARRIVE_DT_TO = ""
        End If

        '===============================================
        '生産ﾗｲﾝNo.
        '===============================================
        mudtSEARCH_ITEM.PROD_LINE = TO_STRING(cboXPROD_LINE.Text)

        '===============================================
        '保留区分
        '===============================================
        mudtSEARCH_ITEM.FHORYU_KUBUN = TO_STRING(cboFHORYU_KUBUN.SelectedValue.ToString)


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

                blnCheckErr = False

            Case menmCheckCase.SelectAll_Click
                '(全選択ﾎﾞﾀﾝｸﾘｯｸ時)

                blnCheckErr = False

            Case menmCheckCase.NotSelectAll_Click
                '(全解除ﾎﾞﾀﾝｸﾘｯｸ時)

                blnCheckErr = False

            Case menmCheckCase.Entry_Click
                '(保留区分登録ﾎﾞﾀﾝｸﾘｯｸ時)

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
        strSQL &= vbCrLf & "       TRST_STOCK.FPALLET_ID "                      '在庫情報       .ﾊﾟﾚｯﾄID
        strSQL &= vbCrLf & "     , TRST_STOCK.FLOT_NO_STOCK "                   '在庫情報       .在庫ﾛｯﾄ№
        strSQL &= vbCrLf & "     , TPRG_TRK_BUF.FTRK_BUF_NO "                   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        strSQL &= vbCrLf & "     , TMST_TRK.FBUF_NAME "                         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/06/05 順番変更
        strSQL &= vbCrLf & "     , TMST_ITEM.XHINMEI_CD "                       '品目ﾏｽﾀ        .品名記号
        strSQL &= vbCrLf & "     , TRST_STOCK.FHINMEI_CD "                      '在庫情報       .品名ｺｰﾄﾞ
        '↑↑↑↑↑↑************************************************************************************************************
        strSQL &= vbCrLf & "     , TMST_ITEM.FHINMEI "                          '品目ﾏｽﾀ        .品名
        strSQL &= vbCrLf & "     , TRST_STOCK.XPROD_LINE "                      '在庫情報       .生産ﾗｲﾝNo.
        strSQL &= vbCrLf & "     , TRST_STOCK.FHORYU_KUBUN "                    '在庫情報       .保留区分
        strSQL &= vbCrLf & "     , HASH01.FGAMEN_DISP AS FHORYU_KUBUN_DSP "     '在庫情報       .保留区分(表示用)
        strSQL &= vbCrLf & "     , TRST_STOCK.FTR_VOL "                         '在庫情報       .数量(搬送管理量)
        strSQL &= vbCrLf & "     , TPRG_TRK_BUF.FDISP_ADDRESS "                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ   .表記用ｱﾄﾞﾚｽ(ﾛｹｰｼｮﾝ)
        strSQL &= vbCrLf & "     , TRST_STOCK.FARRIVE_DT "                      '在庫情報       .在庫発生日時

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    TPRG_TRK_BUF "                  '【ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ】
        strSQL &= vbCrLf & "  , TMST_TRK "                      '【ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ】
        strSQL &= vbCrLf & "  , TRST_STOCK "                    '【在庫情報】
        strSQL &= vbCrLf & "  , TMST_ITEM "                     '【品目ﾏｽﾀ】
        strSQL &= vbCrLf & "  , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH01", "TRST_STOCK", "FHORYU_KUBUN")

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        1 = 1"         '必ず通る条件
        strSQL &= vbCrLf & "    AND TRST_STOCK.FPALLET_ID = TPRG_TRK_BUF.FPALLET_ID(+) "
        strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FTRK_BUF_NO = TMST_TRK.FTRK_BUF_NO(+) "
        strSQL &= vbCrLf & "    AND TRST_STOCK.FHINMEI_CD = TMST_ITEM.FHINMEI_CD(+) "
        strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FRES_KIND = " & FRES_KIND_SZAIKO                 '引当状態：在庫
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH01", "TRST_STOCK", "FHORYU_KUBUN")
        strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FTRK_BUF_NO IN (" & FTRK_BUF_NO_J9000 & "," & FTRK_BUF_NO_J9100 & "," & FTRK_BUF_NO_J9200 & ") "

        '----------------------------
        '在庫ｴﾘｱﾁｪｯｸ
        '----------------------------
        If mudtSEARCH_ITEM.FTRK_BUF_NO <> "" Then
            strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FTRK_BUF_NO = " & mudtSEARCH_ITEM.FTRK_BUF_NO & " "
        End If

        '----------------------------
        '品名ｺｰﾄﾞ
        '----------------------------
        If mudtSEARCH_ITEM.HINMEI_CD <> CBO_ALL_VALUE Then
            '(品名ｺｰﾄﾞに何か入力されている場合)
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
        '保留区分
        '----------------------------
        If mudtSEARCH_ITEM.FHORYU_KUBUN <> "" Then
            '(全検索以外の場合)
            strSQL &= vbCrLf & "    AND TRST_STOCK.FHORYU_KUBUN = " & mudtSEARCH_ITEM.FHORYU_KUBUN
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

#Region "　ﾌﾟﾛﾊﾟﾃｨｾｯﾄ(詳細)　                       "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub SetProperty(ByVal objForm As FRM_305061)

        objForm.userPALLET_ID = mstrFPALLET_ID                'ﾊﾟﾚｯﾄID
        objForm.userFLOT_NO_STOCK = mstrFLOT_NO_STOCK         '在庫ﾛｯﾄ№

    End Sub
#End Region

End Class
