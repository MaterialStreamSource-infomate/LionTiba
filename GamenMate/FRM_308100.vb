'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】出荷予定ﾘｽﾄ再発行画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_308100

#Region "　共通変数　                               "

    Private mFlag_Form_Load As Boolean = True                   '画面展開ﾌﾗｸﾞ

    '検索条件用構造体
    Private mudtSEARCH_ITEM As New SEARCH_ITEM
    Private mudtSEARCH_ITEM2 As New SEARCH_ITEM2

    'ﾌﾟﾛﾊﾟﾃｨ
    Public mstrXHIKIATE_DT As String            '出荷引当日時


    ''' <summary>ｸﾞﾘｯﾄﾞ項目</summary>
    Enum menmListCol

        XHIKIATE_DT             '出荷予定ﾘｽﾄ情報.       出荷引当日時
        XHIKIATE_DT_DSP         '出荷予定ﾘｽﾄ情報.       出荷引当日時(表示用、発行日)
        XHIKIATE_TM_DSP         '出荷予定ﾘｽﾄ情報.       出荷引当日時(表示用、発行時刻)
        XORDER_SU               '出荷予定ﾘｽﾄ情報.       引当ｵｰﾀﾞ数

        MAXCOL

    End Enum

    ''' <summary>ｸﾞﾘｯﾄﾞ項目(出荷予定ﾘｽﾄ)</summary>
    Enum menmListCol2

        XHIKIATE_DT             '出荷予定ﾘｽﾄ情報.       出荷引当日時
        XHIKIATE_DT_DSP         '出荷予定ﾘｽﾄ情報.       出荷引当日時(表示用、出荷日)
        XHIKIATE_TM_DSP         '出荷予定ﾘｽﾄ情報.       出荷引当日時(表示用、出荷時刻)
        FTRK_BUF_NO             '出荷予定ﾘｽﾄ情報.       ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
        FBUF_NAME               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬﾏｽﾀ.       ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ名称
        XNYUKA_JIGYOU_CD        '出荷予定ﾘｽﾄ情報.       入荷事業所ｺｰﾄﾞ
        XNYUKA_JIGYOU_NM        '出荷予定ﾘｽﾄ情報.       入荷事業所名
        FHINMEI_CD              '出荷予定ﾘｽﾄ情報.       品名ｺｰﾄﾞ
        FHINMEI                 '出荷予定ﾘｽﾄ情報.       品名
        XSEIZOU_DT              '出荷予定ﾘｽﾄ情報.       製造年月日
        XHIKIATE_VOL            '出荷予定ﾘｽﾄ情報.       引当数
        XPRINT_PL_NUM           '出荷予定ﾘｽﾄ情報.       ﾊﾟﾚｯﾄ数
        XPRINT_BARA_DAN_NUM     '出荷予定ﾘｽﾄ情報.       段数
        XPRINT_BARA_NUM         '出荷予定ﾘｽﾄ情報.       C/S
        FNUM_IN_PALLET          '出荷予定ﾘｽﾄ情報.       PL毎積載数
        XORDER_NO               '出荷予定ﾘｽﾄ情報.       発注№

        MAXCOL

    End Enum

    ''' <summary>入力ﾁｪｯｸ場合判別</summary>
    Enum menmCheckCase
        SearchBtn_Click         '検索ﾎﾞﾀﾝｸﾘｯｸ時
        PrintBtn_Click          '帳票出力ﾎﾞﾀﾝｸﾘｯｸ時
        CsvOutBtn_Click         'CSV出力ﾎﾞﾀﾝｸﾘｯｸ時
    End Enum

#End Region
#Region "  構造体定義　                             "
    ''' <summary>検索条件</summary>
    Private Structure SEARCH_ITEM
        Dim XHATKOU_DT As String                '発行日
        Dim chkFTRK_BUF_NO_J8000 As Boolean     'ﾊﾞﾗ平置場
        Dim chkFTRK_BUF_NO_J8001 As Boolean     '1F平置場
        Dim chkFTRK_BUF_NO_J8100 As Boolean     '外部倉庫
    End Structure
    ''' <summary>検索条件(ﾘｽﾄ用)</summary>
    Private Structure SEARCH_ITEM2
        Dim XHIKIATE_DT As String               '出荷引当日時
        Dim chkFTRK_BUF_NO_J8000 As Boolean     'ﾊﾞﾗ平置場
        Dim chkFTRK_BUF_NO_J8001 As Boolean     '1F平置場
        Dim chkFTRK_BUF_NO_J8100 As Boolean     '外部倉庫
    End Structure
#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ定義　                            "
    ''' ======================================
    ''' <summary>出荷引当日時</summary>
    ''' <remarks></remarks>
    ''' ======================================
    Public Property userXHIKIATE_DT() As String
        Get
            Return mstrXHIKIATE_DT
        End Get
        Set(ByVal value As String)
            mstrXHIKIATE_DT = value
        End Set
    End Property
#End Region
#Region "　ｲﾍﾞﾝﾄ　                                  "
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
        ' 日付ﾎﾞｯｸｽ初期設定
        '*********************************************
        dtpXHATKOU_DT.cmpMDateTimePicker_D.Value = Now

        '*********************************************
        ' ﾁｪｯｸﾎﾞｯｸｽ初期設定
        '*********************************************
        chkFTRK_BUF_NO_J8000.Checked = True    'ﾊﾞﾗ平置場
        chkFTRK_BUF_NO_J8001.Checked = True    '1F平置場
        chkFTRK_BUF_NO_J8100.Checked = True    '外部倉庫


        '*********************************************
        ' ｸﾞﾘｯﾄﾞ初期化
        '*********************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListSetup()

        Call gobjComFuncFRM.FlexGridInitialize(grdList2, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListSetup2()

        mFlag_Form_Load = False

    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ　                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub CloseChild()

        '******************************************
        ' ｺﾝﾄﾛｰﾙの開放
        '******************************************
        dtpXHATKOU_DT.Dispose()          '発行日
        chkFTRK_BUF_NO_J8000.Dispose()   'ﾊﾞﾗ平置場
        chkFTRK_BUF_NO_J8001.Dispose()   '1F平置場
        chkFTRK_BUF_NO_J8100.Dispose()   '外部倉庫
        grdList.Dispose()                'ｸﾞﾘｯﾄﾞ

    End Sub
#End Region
#Region "  F1(検索)         ﾎﾞﾀﾝ押下処理　          "
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
#Region "  F4(帳票出力)     ﾎﾞﾀﾝ押下処理　          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F4ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F4Process()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.PrintBtn_Click) = False Then
            Exit Sub
        End If

        '*********************************************
        ' 構造体ｾｯﾄ(ﾘｽﾄ用)
        '*********************************************
        Call SearchItem_Set2(1)

        '*********************************************
        ' 帳票出力
        '*********************************************
        Call printOut()

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
#Region "  F5(外部倉庫CSV出力)  ﾎﾞﾀﾝ押下処理　      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F5ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F5Process()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.CsvOutBtn_Click) = False Then
            Exit Sub
        End If

        '*********************************************
        ' 構造体ｾｯﾄ(ﾘｽﾄ用)
        '*********************************************
        Call SearchItem_Set2(2)

        '*********************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '*********************************************
        Call grdListDisplaySub2(grdList2)


        If grdList2.RowCount = 0 Then
            '(出力がない時)
            Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308100_02, PopupFormType.Ok, PopupIconType.Information)
            Exit Sub
        End If


        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udeRet As PopupFormType
        udeRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_PRINT_03, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udeRet <> PopupFormType.Ok Then
            Exit Sub
        End If

        '*********************************************
        ' CSV出力
        '*********************************************
        Call CSV_Out()

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
#Region "  F8(戻る)         ﾎﾞﾀﾝ押下処理　          "
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
        Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_204000, Me)

    End Sub
#End Region
#Region "  構造体ｾｯﾄ                                "
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
        mudtSEARCH_ITEM.XHATKOU_DT = Format(dtpXHATKOU_DT.cmpMDateTimePicker_D.Value, "yyyyMMdd") '発行日

        If chkFTRK_BUF_NO_J8000.Checked = False Then
            '(ｵﾌの時)
            mudtSEARCH_ITEM.chkFTRK_BUF_NO_J8000 = False    'ﾊﾞﾗ平置場
        Else
            '(ｵﾝの時)
            mudtSEARCH_ITEM.chkFTRK_BUF_NO_J8000 = True     'ﾊﾞﾗ平置場
        End If

        If chkFTRK_BUF_NO_J8001.Checked = False Then
            '(ｵﾌの時)
            mudtSEARCH_ITEM.chkFTRK_BUF_NO_J8001 = False    '1F平置場
        Else
            '(ｵﾝの時)
            mudtSEARCH_ITEM.chkFTRK_BUF_NO_J8001 = True     '1F平置場
        End If

        If chkFTRK_BUF_NO_J8100.Checked = False Then
            '(ｵﾌの時)
            mudtSEARCH_ITEM.chkFTRK_BUF_NO_J8100 = False    '外部倉庫
        Else
            '(ｵﾝの時)
            mudtSEARCH_ITEM.chkFTRK_BUF_NO_J8100 = True     '外部倉庫
        End If

    End Sub
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
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "     XPLN_SYUKKA_YOTEI_PRINT.XHIKIATE_DT "                                          '出荷予定ﾘｽﾄ情報.       出荷引当日時
        strSQL &= vbCrLf & "   , TO_CHAR(XPLN_SYUKKA_YOTEI_PRINT.XHIKIATE_DT, 'YYYY/MM/DD') AS XHATKOU_DT "     '出荷予定ﾘｽﾄ情報.       出荷引当日時(発行日)
        strSQL &= vbCrLf & "   , TO_CHAR(XPLN_SYUKKA_YOTEI_PRINT.XHIKIATE_DT, 'HH24:MI') AS XHATKOU_TM "        '出荷予定ﾘｽﾄ情報.       出荷引当日時(発行時刻)
        strSQL &= vbCrLf & "   , COUNT(0) AS XORDER_SU "                                                        '出荷予定ﾘｽﾄ情報.       引当ｵｰﾀﾞ数

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "     XPLN_SYUKKA_YOTEI_PRINT "                  '出荷予定ﾘｽﾄ情報

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE 0 = 0 "

        '-----------------------------
        '出荷引当日時
        '-----------------------------
        If mudtSEARCH_ITEM.XHATKOU_DT <> CBO_ALL_VALUE Then
            '(全選択以外の時)
            strSQL &= vbCrLf & "   AND TO_CHAR(XPLN_SYUKKA_YOTEI_PRINT.XHIKIATE_DT, 'yyyyMMdd') = '" & mudtSEARCH_ITEM.XHATKOU_DT & "' "
        End If

        '-----------------------------
        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
        '-----------------------------
        Dim blnC As Boolean = False

        strSQL &= vbCrLf & "        AND XPLN_SYUKKA_YOTEI_PRINT.FTRK_BUF_NO IN ("

        If mudtSEARCH_ITEM.chkFTRK_BUF_NO_J8000 = True Then
            '(平置きの時)
            strSQL &= vbCrLf & FTRK_BUF_NO_J8000
            blnC = True
        End If

        If mudtSEARCH_ITEM.chkFTRK_BUF_NO_J8001 = True Then
            '(1F平置きの時)
            If blnC = True Then
                '(ｶﾝﾏ付けあり)
                strSQL &= vbCrLf & ", "
            End If
            strSQL &= vbCrLf & FTRK_BUF_NO_J8001
            blnC = True
        End If

        If mudtSEARCH_ITEM.chkFTRK_BUF_NO_J8100 = True Then
            '(外部倉庫の時)
            If blnC = True Then
                '(ｶﾝﾏ付けあり)
                strSQL &= vbCrLf & ", "
            End If
            strSQL &= vbCrLf & FTRK_BUF_NO_J8100 & ", " & FTRK_BUF_NO_J8101 & ", " _
                             & FTRK_BUF_NO_J8102 & ", " & FTRK_BUF_NO_J8103 & ", " _
                             & FTRK_BUF_NO_J8104 & ", " & FTRK_BUF_NO_J8105 & ", " _
                             & FTRK_BUF_NO_J8106 & ", " & FTRK_BUF_NO_J8107 & ", " _
                             & FTRK_BUF_NO_J8108 & ", " & FTRK_BUF_NO_J8109
        End If

        strSQL &= vbCrLf & ") "
        

        '============================================================
        'GROUP BY
        '============================================================
        strSQL &= vbCrLf & " GROUP BY "
        strSQL &= vbCrLf & "     XPLN_SYUKKA_YOTEI_PRINT.XHIKIATE_DT "     '出荷予定ﾘｽﾄ情報.       出荷引当日時

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
        Call gobjComFuncFRM.GridSelect(grdList, -1, 1, Nothing)        'ｸﾞﾘｯﾄﾞ選択処理


    End Sub
#End Region
#Region "  ﾘｽﾄ表示設定　                            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾘｽﾄ表示設定
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListSetup()


        '************************************************
        'ｸﾞﾘｯﾄﾞﾏｽﾀの定義を反映
        '************************************************
        Call gobjComFuncFRM.TDSP_GRIDSetup(Me, grdList)

        'grdList.MultiSelect = True
        'grdList.AllowUserToResizeColumns = False

    End Sub
#End Region
#Region "  入力ﾁｪｯｸ                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 入力ﾁｪｯｸ
    ''' </summary>
    ''' <param name="udtCheck_Case">[ IN  ] 入力ﾁｪｯｸ判別</param>
    ''' <returns>True :入力ﾁｪｯｸ成功 / False:入力ﾁｪｯｸ失敗</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function InputCheck(ByVal udtCheck_Case As menmCheckCase) As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True      'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ


        Select Case udtCheck_Case
            Case menmCheckCase.SearchBtn_Click
                '(検索ﾎﾞﾀﾝｸﾘｯｸ時)

                If (chkFTRK_BUF_NO_J8000.Checked = False) And _
                   (chkFTRK_BUF_NO_J8001.Checked = False) And _
                   (chkFTRK_BUF_NO_J8100.Checked = False) Then
                    '(出荷場所が全て選択されていない時)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM308100_01, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If


                blnCheckErr = False

            Case menmCheckCase.PrintBtn_Click
                '(帳票出力ﾎﾞﾀﾝｸﾘｯｸ時)

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

            Case menmCheckCase.CsvOutBtn_Click
                '(外部倉庫CSV出力ﾎﾞﾀﾝｸﾘｯｸ時)

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

#Region "  構造体ｾｯﾄ(ﾘｽﾄ用)                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 構造体ｾｯﾄ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SearchItem_Set2(ByVal intMode As Integer)

        '********************************************************************
        '構造体に値をｾｯﾄ
        '********************************************************************
        mudtSEARCH_ITEM2.XHIKIATE_DT = TO_STRING(grdList.Item(menmListCol.XHIKIATE_DT, grdList.SelectedRows(0).Index).Value) '出荷引当日時

        If intMode = 1 Then
            '(出荷予定ﾘｽﾄ出力時)
            If chkFTRK_BUF_NO_J8000.Checked = False Then
                '(ｵﾌの時)
                mudtSEARCH_ITEM2.chkFTRK_BUF_NO_J8000 = False    'ﾊﾞﾗ平置場
            Else
                '(ｵﾝの時)
                mudtSEARCH_ITEM2.chkFTRK_BUF_NO_J8000 = True     'ﾊﾞﾗ平置場
            End If

            If chkFTRK_BUF_NO_J8001.Checked = False Then
                '(ｵﾌの時)
                mudtSEARCH_ITEM2.chkFTRK_BUF_NO_J8001 = False    '1F平置場
            Else
                '(ｵﾝの時)
                mudtSEARCH_ITEM2.chkFTRK_BUF_NO_J8001 = True     '1F平置場
            End If

            If chkFTRK_BUF_NO_J8100.Checked = False Then
                '(ｵﾌの時)
                mudtSEARCH_ITEM2.chkFTRK_BUF_NO_J8100 = False    '外部倉庫
            Else
                '(ｵﾝの時)
                mudtSEARCH_ITEM2.chkFTRK_BUF_NO_J8100 = True     '外部倉庫
            End If

        Else
            '(外部倉庫CSV出力時)
            mudtSEARCH_ITEM2.chkFTRK_BUF_NO_J8000 = False    'ﾊﾞﾗ平置場
            mudtSEARCH_ITEM2.chkFTRK_BUF_NO_J8001 = False    '1F平置場
            mudtSEARCH_ITEM2.chkFTRK_BUF_NO_J8100 = True     '外部倉庫

        End If


    End Sub
#End Region
#Region "  構造体ｾｯﾄ(ﾘｽﾄ用) 出荷引当画面より        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 構造体ｾｯﾄ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub SearchItem_Set3()

        Call gobjComFuncFRM.FlexGridInitialize(grdList2, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListSetup2()

        '********************************************************************
        '構造体に値をｾｯﾄ
        '********************************************************************
        mudtSEARCH_ITEM2.XHIKIATE_DT = mstrXHIKIATE_DT   '出荷引当日時
        mudtSEARCH_ITEM2.chkFTRK_BUF_NO_J8000 = True     'ﾊﾞﾗ平置場
        mudtSEARCH_ITEM2.chkFTRK_BUF_NO_J8001 = True     '1F平置場
        mudtSEARCH_ITEM2.chkFTRK_BUF_NO_J8100 = True     '外部倉庫
        
    End Sub
#End Region

#Region "  印刷処理                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 印刷処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Sub printOut()

        '*********************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '*********************************************
        Call grdListDisplaySub2(grdList2)

        '*********************************************
        ' ﾘｽﾄ出力
        '*********************************************
        If grdList2.RowCount > 0 Then

            '*******************************************************
            '確認ﾒｯｾｰｼﾞ
            '*******************************************************
            Dim udeRet As PopupFormType
            udeRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_PRINT_01, PopupFormType.Ok_Cancel, PopupIconType.Quest)
            If udeRet <> PopupFormType.Ok Then
                Exit Sub
            End If

            '(印刷ﾃﾞｰﾀありの時)
            Call printOut01()       '出荷予定ﾘｽﾄ

        End If

    End Sub
#End Region

#Region "　ﾘｽﾄ表示(出荷予定ﾘｽﾄ)                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾘｽﾄ表示
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub grdListDisplayChild2()

        Dim strSQL As String                        'SQL文


        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & " SELECT "
        strSQL &= vbCrLf & "     XPLN_SYUKKA_YOTEI_PRINT.XHIKIATE_DT "             '出荷予定ﾘｽﾄ情報.       出荷引当日時
        strSQL &= vbCrLf & "   , TO_CHAR(XPLN_SYUKKA_YOTEI_PRINT.XHIKIATE_DT, 'YYYY/MM/DD') AS XHIKIATE_DT_DSP "    '出荷予定ﾘｽﾄ情報.       出荷引当日時(表示用、出荷日)
        strSQL &= vbCrLf & "   , TO_CHAR(XPLN_SYUKKA_YOTEI_PRINT.XHIKIATE_DT, 'HH24:Mi') AS XHIKIATE_TM_DSP "       '出荷予定ﾘｽﾄ情報.       出荷引当日時(表示用、出荷時刻)
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_YOTEI_PRINT.FTRK_BUF_NO "             '出荷予定ﾘｽﾄ情報.       ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
        strSQL &= vbCrLf & "   , TMST_TRK.FBUF_NAME "                              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬﾏｽﾀ.       ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ名称

        strSQL &= vbCrLf & "   , XPLN_SYUKKA_YOTEI_PRINT.XNYUKA_JIGYOU_CD "        '出荷予定ﾘｽﾄ情報.       入荷事業所ｺｰﾄﾞ
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_YOTEI_PRINT.XNYUKA_JIGYOU_NM "        '出荷予定ﾘｽﾄ情報.       入荷事業所名
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_YOTEI_PRINT.FHINMEI_CD "              '出荷予定ﾘｽﾄ情報.       品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_YOTEI_PRINT.FHINMEI "                 '出荷予定ﾘｽﾄ情報.       品名
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_YOTEI_PRINT.XSEIZOU_DT "              '出荷予定ﾘｽﾄ情報.       製造年月日
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_YOTEI_PRINT.XHIKIATE_VOL "            '出荷予定ﾘｽﾄ情報.       引当数
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_YOTEI_PRINT.XPRINT_PL_NUM "           '出荷予定ﾘｽﾄ情報.       ﾊﾟﾚｯﾄ数
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_YOTEI_PRINT.XPRINT_BARA_DAN_NUM "     '出荷予定ﾘｽﾄ情報.       段数
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_YOTEI_PRINT.XPRINT_BARA_NUM "         '出荷予定ﾘｽﾄ情報.       C/S
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_YOTEI_PRINT.FNUM_IN_PALLET "          '出荷予定ﾘｽﾄ情報.       PL毎積載数
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_YOTEI_PRINT.XORDER_NO "               '出荷予定ﾘｽﾄ情報.       発注№


        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "     XPLN_SYUKKA_YOTEI_PRINT "                        '出荷予定ﾘｽﾄ情報
        strSQL &= vbCrLf & "   , TMST_TRK "                                       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬﾏｽﾀ

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE 0 = 0 "
        strSQL &= vbCrLf & "   AND XPLN_SYUKKA_YOTEI_PRINT.FTRK_BUF_NO = TMST_TRK.FTRK_BUF_NO(+) "


        '-----------------------------
        '出荷引当日時
        '-----------------------------
        If mudtSEARCH_ITEM2.XHIKIATE_DT <> CBO_ALL_VALUE Then
            '(全選択以外の時)
            strSQL &= vbCrLf & "   AND XPLN_SYUKKA_YOTEI_PRINT.XHIKIATE_DT = TO_DATE('" & mudtSEARCH_ITEM2.XHIKIATE_DT & "', 'YYYY/MM/DD HH24:MI:SS') "
        End If

        '-----------------------------
        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
        '-----------------------------
        Dim blnC As Boolean = False

        strSQL &= vbCrLf & "        AND XPLN_SYUKKA_YOTEI_PRINT.FTRK_BUF_NO IN ("

        If mudtSEARCH_ITEM2.chkFTRK_BUF_NO_J8000 = True Then
            '(平置きの時)
            strSQL &= vbCrLf & FTRK_BUF_NO_J8000
            blnC = True
        End If

        If mudtSEARCH_ITEM2.chkFTRK_BUF_NO_J8001 = True Then
            '(1F平置きの時)
            If blnC = True Then
                '(ｶﾝﾏ付けあり)
                strSQL &= vbCrLf & ", "
            End If
            strSQL &= vbCrLf & FTRK_BUF_NO_J8001
            blnC = True
        End If

        If mudtSEARCH_ITEM2.chkFTRK_BUF_NO_J8100 = True Then
            '(外部倉庫の時)
            If blnC = True Then
                '(ｶﾝﾏ付けあり)
                strSQL &= vbCrLf & ", "
            End If
            strSQL &= vbCrLf & FTRK_BUF_NO_J8100 & ", " & FTRK_BUF_NO_J8101 & ", " _
                             & FTRK_BUF_NO_J8102 & ", " & FTRK_BUF_NO_J8103 & ", " _
                             & FTRK_BUF_NO_J8104 & ", " & FTRK_BUF_NO_J8105 & ", " _
                             & FTRK_BUF_NO_J8106 & ", " & FTRK_BUF_NO_J8107 & ", " _
                             & FTRK_BUF_NO_J8108 & ", " & FTRK_BUF_NO_J8109
        End If

        strSQL &= vbCrLf & ") "


        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & " ORDER BY "
        strSQL &= vbCrLf & "     XPLN_SYUKKA_YOTEI_PRINT.XHIKIATE_DT "             '出荷予定ﾘｽﾄ情報.       出荷引当日時
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_YOTEI_PRINT.FTRK_BUF_NO "             '出荷予定ﾘｽﾄ情報.       ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_YOTEI_PRINT.FHINMEI_CD "              '出荷予定ﾘｽﾄ情報.       品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_YOTEI_PRINT.XSEIZOU_DT "              '出荷予定ﾘｽﾄ情報.       製造年月日
        strSQL &= vbCrLf & "   , XPLN_SYUKKA_YOTEI_PRINT.XORDER_NO "               '出荷予定ﾘｽﾄ情報.       発注№
        strSQL &= vbCrLf


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        Call gobjComFuncFRM.TblDataGridDisplay(grdList2, strSQL, False)


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdListSetup2()
        Call gobjComFuncFRM.GridSelect(grdList2, -1, 1, Nothing)        'ｸﾞﾘｯﾄﾞ選択処理


    End Sub
#End Region
#Region "  ﾘｽﾄ表示設定(出荷予定ﾘｽﾄ)                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾘｽﾄ表示設定
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListSetup2()


        '************************************************
        'ｸﾞﾘｯﾄﾞﾏｽﾀの定義を反映
        '************************************************
        Call gobjComFuncFRM.TDSP_GRIDSetup(Me, grdList2)

        'grdList.MultiSelect = True
        'grdList.AllowUserToResizeColumns = False

    End Sub
#End Region
#Region "　印刷処理(出荷予定ﾘｽﾄ全体）               "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】なし
    '【戻値】なし
    '*******************************************************************************************************************
    Private Sub printOut01()

        Call gobjComFuncFRM.WaitFormShow()                     ' Waitﾌｫｰﾑ表示

        '***********************************************
        ' 各ｵﾌﾞｼﾞｪｸﾄのｲﾝｽﾀﾝｽ
        '***********************************************
        Dim objCR As New PRT_308050_01          'ｸﾘｽﾀﾙﾚﾎﾟｰﾄｵﾌﾞｼﾞｪｸﾄ
        Dim objDataSet As New clsPrintDataSet   'ﾃﾞｰﾀﾃｰﾌﾞﾙｵﾌﾞｼﾞｪｸﾄ

        Try

            '***********************************************
            ' ﾍｯﾀﾞｰ部分作成
            '***********************************************
            '================================
            ' ﾃﾞｰﾀをｾｯﾄ
            '================================
            Call gobjComFuncFRM.ChangeCRText(objCR, "crDateTime01", Format(Now, GAMEN_DATE_FORMAT_02))

            Call gobjComFuncFRM.ChangeCRText(objCR, "crText01", Format(TO_DATE(mudtSEARCH_ITEM2.XHIKIATE_DT), GAMEN_DATE_FORMAT_03))  '出荷日

            Dim strFTRK_BUF_NO_OLD As String = ""       '旧ｷｰ
            Dim intRec_Cnt As Integer = 0               'ﾚｺｰﾄﾞｶｳﾝﾄ

            '***********************************************
            ' ﾃﾞｰﾀ部分作成
            '***********************************************
            For ii As Integer = 0 To grdList2.Rows.Count - 1

                Dim objDataRow As clsPrintDataSet.DataTable01Row
                objDataRow = objDataSet.DataTable01.NewRow

                objDataRow.BeginEdit()

                objDataRow.Data00 = grdList2.Item(menmListCol2.XHIKIATE_DT, ii).FormattedValue          '出荷引当日時
                objDataRow.Data01 = grdList2.Item(menmListCol2.FTRK_BUF_NO, ii).FormattedValue          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№
                objDataRow.Data13 = grdList2.Item(menmListCol2.FBUF_NAME, ii).FormattedValue            '保管場所

                If strFTRK_BUF_NO_OLD <> grdList2.Item(menmListCol2.FTRK_BUF_NO, ii).FormattedValue Then
                    '(ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№が異なるとき)
                    strFTRK_BUF_NO_OLD = grdList2.Item(menmListCol2.FTRK_BUF_NO, ii).FormattedValue
                    intRec_Cnt = 1
                Else
                    '(ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｬ№が同じのとき)
                    intRec_Cnt += 1
                End If
                objDataRow.Data02 = intRec_Cnt                                                          '№

                objDataRow.Data03 = grdList2.Item(menmListCol2.XNYUKA_JIGYOU_NM, ii).FormattedValue     '配送先
                objDataRow.Data04 = grdList2.Item(menmListCol2.FHINMEI_CD, ii).FormattedValue           '品名ｺｰﾄﾞ
                objDataRow.Data05 = grdList2.Item(menmListCol2.FHINMEI, ii).FormattedValue              '品名
                objDataRow.Data06 = grdList2.Item(menmListCol2.XSEIZOU_DT, ii).FormattedValue           '製造年月日
                objDataRow.Data07 = grdList2.Item(menmListCol2.XHIKIATE_VOL, ii).FormattedValue         '引当数
                objDataRow.Data08 = grdList2.Item(menmListCol2.XPRINT_PL_NUM, ii).FormattedValue        'PL

                '↓↓↓↓ 2012.11.28 13:30 H.Morita
                If TO_INTEGER(grdList2.Item(menmListCol2.XPRINT_BARA_DAN_NUM, ii).FormattedValue) = 0 Then
                    '(段がｾﾞﾛの時)
                    objDataRow.Data09 = ""
                Else
                    '(段に値がある時)
                    objDataRow.Data09 = grdList2.Item(menmListCol2.XPRINT_BARA_DAN_NUM, ii).FormattedValue  '段
                End If
                '↑↑↑↑ 2012.11.28 13:30 H.Morita

                '↓↓↓↓ 2012.11.28 13:30 H.Morita
                If TO_INTEGER(grdList2.Item(menmListCol2.XPRINT_BARA_NUM, ii).FormattedValue) = 0 Then
                    '(C/Sがｾﾞﾛの時)
                    objDataRow.Data10 = ""
                Else
                    '(C/Sに値がある時)
                    objDataRow.Data10 = grdList2.Item(menmListCol2.XPRINT_BARA_NUM, ii).FormattedValue      'C/S
                End If
                '↑↑↑↑ 2012.11.28 13:30 H.Morita

                objDataRow.Data11 = grdList2.Item(menmListCol2.FNUM_IN_PALLET, ii).FormattedValue       'ﾊﾟﾚｯﾄ積付数
                objDataRow.Data12 = grdList2.Item(menmListCol2.XORDER_NO, ii).FormattedValue            '発注№

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

#Region "　CSV出力                                  "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】なし
    '【戻値】なし
    '*******************************************************************************************************************
    Private Sub CSV_Out()

        Call gobjComFuncFRM.WaitFormShow()                     ' Waitﾌｫｰﾑ表示

        Try

            '******************************************
            'ﾌｧｲﾙ名     取得
            '******************************************
            Dim strFile As String = TO_STRING(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_JGJ308100_001))

            '******************************************
            'ﾃﾞｰﾀ部     ﾍｯﾀﾞ表示名ｾｯﾄ
            '******************************************
            Dim strDataHeaderName_Ary(11) As String
            strDataHeaderName_Ary(0) = "出荷日"
            strDataHeaderName_Ary(1) = "保管場所"
            strDataHeaderName_Ary(2) = "配送先"
            strDataHeaderName_Ary(3) = "品名ｺｰﾄﾞ"
            strDataHeaderName_Ary(4) = "品名"
            strDataHeaderName_Ary(5) = "製造年月日"
            strDataHeaderName_Ary(6) = "引当数(C/S)"
            strDataHeaderName_Ary(7) = "PL"
            strDataHeaderName_Ary(8) = "段"
            strDataHeaderName_Ary(9) = "C/S"
            strDataHeaderName_Ary(10) = "ﾊﾟﾚｯﾄ積付数"
            strDataHeaderName_Ary(11) = "発注№"


            '******************************************
            'ﾃﾞｰﾀ部     ｶﾗﾑ名ｾｯﾄ
            '******************************************
            Dim intDataColumnIdx_Ary(11) As Integer
            intDataColumnIdx_Ary(0) = menmListCol2.XHIKIATE_DT_DSP
            intDataColumnIdx_Ary(1) = menmListCol2.FBUF_NAME
            intDataColumnIdx_Ary(2) = menmListCol2.XNYUKA_JIGYOU_NM
            intDataColumnIdx_Ary(3) = menmListCol2.FHINMEI_CD
            intDataColumnIdx_Ary(4) = menmListCol2.FHINMEI
            intDataColumnIdx_Ary(5) = menmListCol2.XSEIZOU_DT
            intDataColumnIdx_Ary(6) = menmListCol2.XHIKIATE_VOL
            intDataColumnIdx_Ary(7) = menmListCol2.XPRINT_PL_NUM
            intDataColumnIdx_Ary(8) = menmListCol2.XPRINT_BARA_DAN_NUM
            intDataColumnIdx_Ary(9) = menmListCol2.XPRINT_BARA_NUM
            intDataColumnIdx_Ary(10) = menmListCol2.FNUM_IN_PALLET
            intDataColumnIdx_Ary(11) = menmListCol2.XORDER_NO


            '******************************************
            'CSVﾌｧｲﾙ出力
            '******************************************
            Call MakeCSV(grdList2 _
                        , TO_STRING(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_JGJ000000_001)) _
                        , strFile _
                        , "" _
                        , strDataHeaderName_Ary _
                        , intDataColumnIdx_Ary _
                        )


        Catch ex As Exception
            Throw ex

        Finally
            Call gobjComFuncFRM.WaitFormClose()                    ' Waitﾌｫｰﾑ削除

        End Try

    End Sub
#End Region

End Class
