'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】生産入庫履歴表示画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_304010

#Region "　共通変数　                               "

    Private mFlag_Form_Load As Boolean = True                   '画面展開ﾌﾗｸﾞ

    '検索条件用構造体
    Private mudtSEARCH_ITEM As New SEARCH_ITEM


    ''' <summary>ｸﾞﾘｯﾄﾞ項目</summary>
    Enum menmListCol
        FLOG_NO             '(非表示)INOUT実績. ﾛｸﾞ№
        FHINMEI_CD          'INOUT実績.         品名ｺｰﾄﾞ
        FHINMEI             'INOUT実績.         品名
        XSEIZOU_DT          'INOUT実績.         製造年月日
        XLINE_NO            'INOUT実績.         ﾗｲﾝ№
        XPALLET_NO          'INOUT実績.         ﾊﾟﾚｯﾄ№
        FTR_VOL             'INOUT実績.         搬送管理量(積込数)
        XKENSA_KUBUN        'INOUT実績.         検査区分
        XAB_KUBUN           'INOUT実績.         AB区分
        FARRIVE_DT          'INOUT実績.         在庫発生日時

        MAXCOL

    End Enum

    ''' <summary>入力ﾁｪｯｸ場合判別</summary>
    Enum menmCheckCase
        SearchBtn_Click         '検索ﾎﾞﾀﾝｸﾘｯｸ時
    End Enum

#End Region
#Region "  構造体定義　                             "

    ''' <summary>検索条件</summary>
    Private Structure SEARCH_ITEM
        Dim FHINMEI_CD As String            '品名ｺｰﾄﾞ
        Dim FARRIVE_DT_FM As String         '在庫発生日時 FROM
        Dim FARRIVE_DT_TO As String         '在庫発生日時 TO
        Dim XLINE_NO As String              'ﾗｲﾝ№
        Dim XPALLET_NO As String            'ﾊﾟﾚｯﾄ№
    End Structure
#End Region
#Region "　ｲﾍﾞﾝﾄ　                                  "
#Region "　品名ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞ       ｲﾍﾞﾝﾄ   "
    'Private Sub cboFHINMEI_CD_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFHINMEI_CD.SelectedIndexChanged
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 品名ｺｰﾄﾞｺﾝﾎﾞﾎﾞｯｸｽ選択ﾁｪﾝｼﾞ       ｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cboFHINMEI_CD_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFHINMEI_CD.LostFocus
        Try

            If mFlag_Form_Load = False Then

                '**********************************************************
                ' ﾗｲﾝ№ｺﾝﾎﾞ                  ｾｯﾄ
                '**********************************************************
                Call MakeSeisanNyukoRireki_cboXLINE_NO(cboFHINMEI_CD.Text, cboXLINE_NO, True)

                '****************************************
                '期間           ｾｯﾄ
                '****************************************
                dtpFARRIVE_DT_FM.userChecked = True
                Call gobjComFuncFRM.dtpKikanFromToSetup(dtpFARRIVE_DT_FM, dtpFARRIVE_DT_TO)

                '*********************************************
                ' ﾃｷｽﾄﾎﾞｯｸｽ初期設定
                '*********************************************
                txtXPALLET_NO.Text = ""    'ﾊﾟﾚｯﾄ№

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


        '****************************************
        ' 品名ｺｰﾄﾞｺﾝﾎﾞ         ｾｯﾄ
        '****************************************
        cboFHINMEI_CD.conn = gobjDb
        cboFHINMEI_CD.HinmeiLabel = lblFHINMEI
        cboFHINMEI_CD.Text = ""
        cboFHINMEI_CD.HinmeiVisible = False
        cboFHINMEI_CD.cboSetupHinmeiCd(cboFHINMEI_CD.Text)

        '**********************************************************
        ' ﾗｲﾝ№ｺﾝﾎﾞ                  ｾｯﾄ
        '**********************************************************
        Call MakeSeisanNyukoRireki_cboXLINE_NO(cboFHINMEI_CD.Text, cboXLINE_NO, True)

        '****************************************
        '期間           ｾｯﾄ
        '****************************************
        Call gobjComFuncFRM.dtpKikanFromToSetup(dtpFARRIVE_DT_FM, dtpFARRIVE_DT_TO)

        '*********************************************
        ' ﾃｷｽﾄﾎﾞｯｸｽ初期設定
        '*********************************************
        lblFHINMEI.Text = ""       '品名
        txtXPALLET_NO.Text = ""    'ﾊﾟﾚｯﾄ№

        '*********************************************
        ' ｸﾞﾘｯﾄﾞ初期化
        '*********************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListSetup()


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
        cboFHINMEI_CD.Dispose()          '品名ｺｰﾄﾞ
        dtpFARRIVE_DT_FM.Dispose()       '在庫発生日時 FROM
        dtpFARRIVE_DT_TO.Dispose()       '在庫発生日時 TO
        cboXLINE_NO.Dispose()            'ﾗｲﾝ№
        txtXPALLET_NO.Dispose()          'ﾊﾟﾚｯﾄ№
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
        '===============================================
        ' 品名ｺｰﾄﾞ
        '===============================================
        mudtSEARCH_ITEM.FHINMEI_CD = cboFHINMEI_CD.Text

        '===============================================
        '在庫発生日時 FROM
        '===============================================
        If dtpFARRIVE_DT_FM.userDispChecked = True Then
            mudtSEARCH_ITEM.FARRIVE_DT_FM = dtpFARRIVE_DT_FM.userDateTimeText
        Else
            mudtSEARCH_ITEM.FARRIVE_DT_FM = ""
        End If

        '===============================================
        '在庫発生日時 TO
        '===============================================
        If dtpFARRIVE_DT_TO.userDispChecked = True Then
            mudtSEARCH_ITEM.FARRIVE_DT_TO = dtpFARRIVE_DT_TO.userDateTimeText
        Else
            mudtSEARCH_ITEM.FARRIVE_DT_TO = ""
        End If

        '===============================================
        ' ﾗｲﾝ№
        '===============================================
        mudtSEARCH_ITEM.XLINE_NO = TO_STRING(cboXLINE_NO.SelectedValue.ToString)

        '===============================================
        ' ﾊﾟﾚｯﾄ№
        '===============================================
        mudtSEARCH_ITEM.XPALLET_NO = txtXPALLET_NO.Text

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
        '↓↓↓↓ 2012.12.12 09:00 H.Morita 生産入庫実績ﾛｸﾞに変更 
        'strSQL &= vbCrLf & "     TLOG_INOUT.FLOG_NO "                                   'INOUT実績.         ﾛｸﾞ№
        'strSQL &= vbCrLf & "   , TLOG_INOUT.FHINMEI_CD "                                'INOUT実績.         品名ｺｰﾄﾞ
        'strSQL &= vbCrLf & "   , TLOG_INOUT.FHINMEI "                                   'INOUT実績.         品名
        'strSQL &= vbCrLf & "   , TLOG_INOUT.XSEIZOU_DT "                                'INOUT実績.         製造年月日
        'strSQL &= vbCrLf & "   , TLOG_INOUT.XLINE_NO "                                  'INOUT実績.         ﾗｲﾝ№
        'strSQL &= vbCrLf & "   , TLOG_INOUT.XPALLET_NO "                                'INOUT実績.         ﾊﾟﾚｯﾄ№
        'strSQL &= vbCrLf & "   , TLOG_INOUT.FTR_VOL "                                   'INOUT実績.         搬送管理量(積込数)
        'strSQL &= vbCrLf & "   , TLOG_INOUT.XKENSA_KUBUN "                              'INOUT実績.         検査区分
        'strSQL &= vbCrLf & "   , TLOG_INOUT.XAB_KUBUN "                                 'INOUT実績.         AB区分
        'strSQL &= vbCrLf & "   , TLOG_INOUT.FARRIVE_DT "                                'INOUT実績.         在庫発生日時

        strSQL &= vbCrLf & "     XLOG_SEISAN.FLOG_NO "                                   '生産入庫実績ﾛｸﾞ.   ﾛｸﾞ№
        strSQL &= vbCrLf & "   , XLOG_SEISAN.FHINMEI_CD "                                '生産入庫実績ﾛｸﾞ.   品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "   , XLOG_SEISAN.FHINMEI "                                   '生産入庫実績ﾛｸﾞ.   品名
        strSQL &= vbCrLf & "   , XLOG_SEISAN.XSEIZOU_DT "                                '生産入庫実績ﾛｸﾞ.   製造年月日
        strSQL &= vbCrLf & "   , XLOG_SEISAN.XLINE_NO "                                  '生産入庫実績ﾛｸﾞ.   ﾗｲﾝ№
        strSQL &= vbCrLf & "   , XLOG_SEISAN.XPALLET_NO "                                '生産入庫実績ﾛｸﾞ.   ﾊﾟﾚｯﾄ№
        strSQL &= vbCrLf & "   , XLOG_SEISAN.FTR_VOL "                                   '生産入庫実績ﾛｸﾞ.   搬送管理量(積込数)
        strSQL &= vbCrLf & "   , XLOG_SEISAN.XKENSA_KUBUN "                              '生産入庫実績ﾛｸﾞ.   検査区分
        strSQL &= vbCrLf & "   , XLOG_SEISAN.XAB_KUBUN "                                 '生産入庫実績ﾛｸﾞ.   AB区分
        strSQL &= vbCrLf & "   , XLOG_SEISAN.FARRIVE_DT "                                '生産入庫実績ﾛｸﾞ.   在庫発生日時
        '↑↑↑↑ 2012.12.12 09:00 H.Morita 生産入庫実績ﾛｸﾞに変更 


        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        '↓↓↓↓ 2012.12.12 09:00 H.Morita 生産入庫実績ﾛｸﾞに変更 
        'strSQL &= vbCrLf & "     TLOG_INOUT "                       'INOUT実績
        strSQL &= vbCrLf & "     XLOG_SEISAN "                       '生産入庫実績ﾛｸﾞ
        '↑↑↑↑ 2012.12.12 09:00 H.Morita 生産入庫実績ﾛｸﾞに変更 


        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & "     WHERE 0 = 0 "
        'strSQL &= vbCrLf & "        AND TLOG_INOUT.FINOUT_STS IN (" & FINOUT_STS_SIN_END & ", " & FINOUT_STS_SMENTE_FINISH_IN & ") "
        '↓↓↓↓ 2012.12.12 09:00 H.Morita 生産入庫実績ﾛｸﾞに変更 
        'strSQL &= vbCrLf & "        AND TLOG_INOUT.FINOUT_STS = " & FINOUT_STS_SIN_UKETUKE
        'strSQL &= vbCrLf & "        AND TLOG_INOUT.FBUF_FM   IS NULL "
        'strSQL &= vbCrLf & "        AND TLOG_INOUT.FARRAY_FM IS NULL "
        'strSQL &= vbCrLf & "        AND TLOG_INOUT.FBUF_TO   IN (" & FTRK_BUF_NO_J384
        'strSQL &= vbCrLf & "                                   , " & FTRK_BUF_NO_J389
        'strSQL &= vbCrLf & "                                   , " & FTRK_BUF_NO_J394
        'strSQL &= vbCrLf & "                                   , " & FTRK_BUF_NO_J399
        'strSQL &= vbCrLf & "                                    ) "
        '↑↑↑↑ 2012.12.12 09:00 H.Morita 生産入庫実績ﾛｸﾞに変更 


        '-----------------------------
        '品名ｺｰﾄﾞ
        '-----------------------------
        If mudtSEARCH_ITEM.FHINMEI_CD <> CBO_ALL_VALUE Then
            '(全選択以外の時)
            '↓↓↓↓ 2012.12.12 09:00 H.Morita 生産入庫実績ﾛｸﾞに変更 
            'strSQL &= vbCrLf & "        AND TLOG_INOUT.FHINMEI_CD LIKE '" & mudtSEARCH_ITEM.FHINMEI_CD & "%' "
            strSQL &= vbCrLf & "        AND XLOG_SEISAN.FHINMEI_CD LIKE '" & mudtSEARCH_ITEM.FHINMEI_CD & "%' "
            '↑↑↑↑ 2012.12.12 09:00 H.Morita 生産入庫実績ﾛｸﾞに変更 
        End If

        '----------------------------
        '在庫発生日時 範囲指定 
        '----------------------------
        If mudtSEARCH_ITEM.FARRIVE_DT_FM <> "" Then
            '(全選択以外の時)
            '↓↓↓↓ 2012.12.12 09:00 H.Morita 生産入庫実績ﾛｸﾞに変更 
            'strSQL &= vbCrLf & "        AND TLOG_INOUT.FARRIVE_DT >= TO_DATE('" & mudtSEARCH_ITEM.FARRIVE_DT_FM & "','YYYY/MM/DD HH24:MI:SS')"
            strSQL &= vbCrLf & "        AND XLOG_SEISAN.FARRIVE_DT >= TO_DATE('" & mudtSEARCH_ITEM.FARRIVE_DT_FM & "','YYYY/MM/DD HH24:MI:SS')"
            '↑↑↑↑ 2012.12.12 09:00 H.Morita 生産入庫実績ﾛｸﾞに変更 
        End If
        If mudtSEARCH_ITEM.FARRIVE_DT_TO <> "" Then
            '(全選択以外の時)
            '↓↓↓↓ 2012.12.12 09:00 H.Morita 生産入庫実績ﾛｸﾞに変更 
            'strSQL &= vbCrLf & "        AND TLOG_INOUT.FARRIVE_DT <= TO_DATE('" & mudtSEARCH_ITEM.FARRIVE_DT_TO & "','YYYY/MM/DD HH24:MI:SS')"
            strSQL &= vbCrLf & "        AND XLOG_SEISAN.FARRIVE_DT <= TO_DATE('" & mudtSEARCH_ITEM.FARRIVE_DT_TO & "','YYYY/MM/DD HH24:MI:SS')"
            '↑↑↑↑ 2012.12.12 09:00 H.Morita 生産入庫実績ﾛｸﾞに変更 
        End If

        '-----------------------------
        'ﾗｲﾝ№
        '-----------------------------
        If mudtSEARCH_ITEM.XLINE_NO <> CBO_ALL_VALUE Then
            '(全選択以外の時)
            '↓↓↓↓ 2012.12.12 09:00 H.Morita 生産入庫実績ﾛｸﾞに変更 
            'strSQL &= vbCrLf & "        AND TLOG_INOUT.XLINE_NO = '" & mudtSEARCH_ITEM.XLINE_NO & "' "
            strSQL &= vbCrLf & "        AND XLOG_SEISAN.XLINE_NO = '" & mudtSEARCH_ITEM.XLINE_NO & "' "
            '↑↑↑↑ 2012.12.12 09:00 H.Morita 生産入庫実績ﾛｸﾞに変更 
        End If

        '-----------------------------
        'ﾊﾟﾚｯﾄ№
        '-----------------------------
        If mudtSEARCH_ITEM.XPALLET_NO <> CBO_ALL_VALUE Then
            '(全選択以外の時)
            '↓↓↓↓ 2012.12.12 09:00 H.Morita 生産入庫実績ﾛｸﾞに変更 
            'strSQL &= vbCrLf & "        AND TLOG_INOUT.XPALLET_NO = '" & mudtSEARCH_ITEM.XPALLET_NO & "' "
            strSQL &= vbCrLf & "        AND XLOG_SEISAN.XPALLET_NO = '" & mudtSEARCH_ITEM.XPALLET_NO & "' "
            '↑↑↑↑ 2012.12.12 09:00 H.Morita 生産入庫実績ﾛｸﾞに変更 
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

        grdList.MultiSelect = True
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

                '********************************************************************
                '日付文字列作成
                '********************************************************************
                If dtpFARRIVE_DT_FM.userDispChecked <> False And dtpFARRIVE_DT_TO.userDispChecked <> False Then
                    '(FROM,TOの日時ｺﾝﾎﾞにﾁｪｯｸが付いているとき)

                    Dim strFrom As String                   'From
                    Dim strTo As String                     'To
                    strFrom = dtpFARRIVE_DT_FM.userDateTimeText
                    strTo = dtpFARRIVE_DT_TO.userDateTimeText

                    '********************************************************************
                    '入力ﾁｪｯｸ
                    '********************************************************************
                    '==========================
                    '期間
                    '==========================
                    If CDate(strFrom) > CDate(strTo) Then
                        ' 期間の大小関係
                        Call gobjComFuncFRM.DisplayPopup(FRM_MSG_DTP_KIKAN_TIME_02, PopupFormType.Ok, PopupIconType.Information)
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

End Class
