'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】操作権限ﾏｽﾀﾒﾝﾃﾅﾝｽ画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_206030

#Region "　共通変数　                               "

    Private GrdEdtModeColor As Color = Color.White      'ｸﾞﾘｯﾄﾞ入力状態背景色

    '検索条件用構造体
    Private mudtSEARCH_ITEM As New SEARCH_ITEM

    ''' <summary>ｸﾞﾘｯﾄﾞ項目</summary>
    Enum menmListCol
        KUBUN                       '区分
        FDISP_TITLE                 '画面ﾏｽﾀ.           画面名称
        FCONTROL_NAME               '画面ﾏｽﾀ.           ｺﾝﾄﾛｰﾙ名称
        FOPE_FLAG_Data              'ﾕｰｻﾞ別許可ﾏｽﾀ.     操作ﾌﾗｸﾞ
        FUSER_DSP_LEVEL             '(非表示)ﾕｰｻﾞｰ別許可ﾏｽﾀ.    ﾕｰｻﾞｰ操作ﾚﾍﾞﾙ
        FDISP_ID                    '(非表示)ﾕｰｻﾞｰ別許可ﾏｽﾀ.    画面ID
        FCTRL_ID                    '(非表示)ﾕｰｻﾞｰ別許可ﾏｽﾀ.    ｺﾝﾄﾛｰﾙID
        FOPE_FLAG                   'ﾕｰｻﾞ別許可ﾏｽﾀ.     操作ﾌﾗｸﾞ(表示用)

        MAXCOL

    End Enum

    ''' <summary>入力ﾁｪｯｸ場合判別</summary>
    Enum menmCheckCase
        SearchBtn_Click                 '検索ﾎﾞﾀﾝｸﾘｯｸ時
        Update_Click                    '更新ﾎﾞﾀﾝｸﾘｯｸ時
    End Enum

#End Region
#Region "  構造体定義                               "
    ''' <summary>検索条件</summary>
    Private Structure SEARCH_ITEM
        Dim FUSER_DSP_LEVEL As String        '権限ﾚﾍﾞﾙ

    End Structure
#End Region
#Region "　ｲﾍﾞﾝﾄ                                    "
#Region "  ｾﾙ選択               ｲﾍﾞﾝﾄ               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｾﾙ選択処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        If grdList.SelectedCells(0).ColumnIndex <> menmListCol.FOPE_FLAG Then grdList.SelectedCells(0).Selected = False

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
        ' 権限ﾚﾍﾞﾙ             ｾｯﾄ
        '**********************************************************
        Call gobjComFuncFRM.cboMsterSetup("TMST_LEVEL", "FUSER_DSP_LEVEL", "FUSER_DSP_LEVEL_NAME", "FUSER_DSP_LEVEL", cboFUSER_DSP_LEVEL, False)


        '*********************************************
        ' ｸﾞﾘｯﾄﾞ初期化
        '*********************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListSetup()


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
        Call SearchItem_Set()


        '*********************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '*********************************************
        Call grdListDisplaySub(grdList)


    End Sub
#End Region
#Region "  F4(更新)　ﾎﾞﾀﾝ押下処理　                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F4(更新) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F4Process()


        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.Update_Click) = False Then

            Exit Sub
        End If

        '*******************************************************
        '理由ｺｰﾄﾞ表示
        '*******************************************************
        Dim udeRet As RetPopup
        Dim strFREASON As String = ""
        udeRet = gobjComFuncFRM.DisplayFRM_100201(FREASON_KUBUN_STDSP_PMT_USER_UPDATE, strFREASON)
        If udeRet <> RetPopup.OK Then
            Exit Sub
        End If

        '*********************************************
        ' ｿｹｯﾄ送信
        '*********************************************
        If SendSocket01(strFREASON) = False Then Exit Sub


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
#Region "  F8(戻る)  ﾎﾞﾀﾝ押下処理　                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F8(戻る) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F8Process()

        '******************************************
        ' 画面遷移
        '******************************************
        Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_SFRM_206000, Me)

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
        grdList.Dispose()               'ｸﾞﾘｯﾄﾞ
        cboFUSER_DSP_LEVEL.Dispose()

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

            Case menmCheckCase.Update_Click
                '(更新ﾎﾞﾀﾝｸﾘｯｸ時)

                If grdList.Rows.Count <= 0 Then
                    '(ﾘｽﾄが表示されていない場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM206030_01, PopupFormType.Ok, PopupIconType.Information)
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
        ' 権限ﾚﾍﾞﾙ
        '===============================================
        mudtSEARCH_ITEM.FUSER_DSP_LEVEL = TO_STRING(cboFUSER_DSP_LEVEL.SelectedValue.ToString)


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

        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "     DECODE(TDSP_PMT_USER.FCTRL_ID,'" & FCTRL_ID_SKOTEI & "','画面展開','操作ボタン')　FCTRL_ID "        '区分
        strSQL &= vbCrLf & "    ,DECODE(TDSP_NAME.FCTRL_ID,'" & FCTRL_ID_SKOTEI & "',TDSP_NAME.FOBJECT_NAME,'')　FOBJECT_NAME "      '画面ﾏｽﾀ.           画面名称
        strSQL &= vbCrLf & "    ,DECODE(TDSP_NAME.FCTRL_ID,'" & FCTRL_ID_SKOTEI & "','',REPLACE(TDSP_NAME.FOBJECT_NAME,'" & FCTRL_ID_SKOTEI & "',''))　FOBJECT_NAME2 "     '画面ﾏｽﾀ.           ｺﾝﾄﾛｰﾙ名称
        strSQL &= vbCrLf & "    ,TDSP_PMT_USER.FOPE_FLAG "              'ﾕｰｻﾞ別許可ﾏｽﾀ.     操作ﾌﾗｸﾞ
        strSQL &= vbCrLf & "    ,TDSP_PMT_USER.FUSER_DSP_LEVEL "        'ﾕｰｻﾞ別許可ﾏｽﾀ.     ﾕｰｻﾞｰ操作ﾚﾍﾞﾙ
        strSQL &= vbCrLf & "    ,TDSP_PMT_USER.FDISP_ID "               'ﾕｰｻﾞ別許可ﾏｽﾀ.     画面ID
        strSQL &= vbCrLf & "    ,TDSP_PMT_USER.FCTRL_ID "               'ﾕｰｻﾞ別許可ﾏｽﾀ.     ｺﾝﾄﾛｰﾙID
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    ( TDSP_PMT_USER LEFT OUTER JOIN TMST_LEVEL "                        'ﾕｰｻﾞ別許可ﾏｽﾀと権限ﾚﾍﾞﾙﾏｽﾀ
        strSQL &= vbCrLf & "         ON TDSP_PMT_USER.FUSER_DSP_LEVEL = TMST_LEVEL.FUSER_DSP_LEVEL "  'ﾕｰｻﾞ操作ﾚﾍﾞﾙで内部結合
        strSQL &= vbCrLf & "    ) LEFT OUTER JOIN TDSP_NAME "
        strSQL &= vbCrLf & "       ON TDSP_PMT_USER.FDISP_ID = TDSP_NAME.FDISP_ID "
        strSQL &= vbCrLf & "       AND TDSP_PMT_USER.FCTRL_ID = TDSP_NAME.FCTRL_ID   "

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        1 = 1"         '必ず通る条件
        '----------------------------
        ' ﾕｰｻﾞ操作ﾚﾍﾞﾙ
        '----------------------------
        strSQL &= vbCrLf & "    AND TDSP_PMT_USER.FUSER_DSP_LEVEL =  '" & mudtSEARCH_ITEM.FUSER_DSP_LEVEL & "' "      'ﾕｰｻﾞ別許可ﾏｽﾀ.     ﾕｰｻﾞ操作ﾚﾍﾞﾙ


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
        Call gobjComFuncFRM.GridSelect(grdList, -1, -1, objPoint)       'ｸﾞﾘｯﾄﾞ選択処理


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

        '=========================================
        '表示ﾌｫｰﾏｯﾄ
        '=========================================
        'grdList.Columns(menmListCol.FOPE_FLAG) = GetType(Boolean)       '権限ﾏｽﾀ.         ﾕｰｻﾞ操作ﾚﾍﾞﾙﾁｪｯｸﾎﾞｯｸｽ


        '************************************************
        'ﾁｪｯｸﾎﾞｯｸｽ追加
        '************************************************
        Call gobjComFuncFRM.GridAddCheckBoxColumn(grdList, menmListCol.FOPE_FLAG_Data)
        'If IsNotNull(grdList.DataSource) Then
        '    '(ﾃﾞｰﾀが表示されている場合)

        '    '=========================================
        '    'ﾁｪｯｸﾎﾞｯｸｽ追加
        '    '=========================================
        '    Dim objDataTable As DataTable = grdList.DataSource
        '    Dim objDataColumn As DataColumn = New DataColumn("CheckBox", GetType(Boolean))
        '    objDataTable.Columns.Add(objDataColumn)

        '    '=========================================
        '    '値設定
        '    '=========================================
        '    For ii As Integer = 0 To grdList.RowCount - 1
        '        '(ﾙｰﾌﾟ:ﾃﾞｰﾀ件数)
        '        If TO_INTEGER(grdList.Item(menmListCol.FOPE_FLAG_Data, ii).Value) = FOPE_FLAG_ON Then
        '            grdList.Item(menmListCol.FOPE_FLAG, ii).Value = True
        '        Else
        '            grdList.Item(menmListCol.FOPE_FLAG, ii).Value = False
        '        End If
        '    Next

        'End If


        '************************************************
        'ｸﾞﾘｯﾄﾞﾏｽﾀの定義を反映
        '************************************************
        Call gobjComFuncFRM.TDSP_GRIDSetup(Me, grdList)
        grdList.ReadOnly = False                                                         'ｾﾙの編集           許可設定


        '************************************************
        '編集ﾓｰﾄﾞ
        '************************************************
        grdList.Columns(menmListCol.KUBUN).ReadOnly = True
        grdList.Columns(menmListCol.FDISP_TITLE).ReadOnly = True
        grdList.Columns(menmListCol.FCONTROL_NAME).ReadOnly = True
        grdList.Columns(menmListCol.FOPE_FLAG_Data).ReadOnly = True
        grdList.Columns(menmListCol.FUSER_DSP_LEVEL).ReadOnly = True          '(非表示)ﾕｰｻﾞｰ別許可ﾏｽﾀ.    ﾕｰｻﾞｰ操作ﾚﾍﾞﾙ
        grdList.Columns(menmListCol.FDISP_ID).ReadOnly = True                 '(非表示)ﾕｰｻﾞｰ別許可ﾏｽﾀ.    画面ID
        grdList.Columns(menmListCol.FCTRL_ID).ReadOnly = True                 '(非表示)ﾕｰｻﾞｰ別許可ﾏｽﾀ.    ｺﾝﾄﾛｰﾙID
        'grdList.Rows(0).AllowEditing = False


        '************************************************
        '列背景設定
        '************************************************
        For ii As Integer = 0 To grdList.ColumnCount - 1
            If grdList.Columns(ii).ReadOnly = False Then
                '(入力可の場合)
                grdList.Columns(ii).DefaultCellStyle.BackColor = Color.White
            Else
                '(入力不可の場合)
                grdList.Columns(ii).DefaultCellStyle.BackColor = Color.LightGray
            End If
        Next


    End Sub
#End Region
#Region "  ﾒﾝﾃﾅﾝｽ入力画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ　             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾒﾝﾃﾅﾝｽ入力画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SetProperty()


    End Sub
#End Region
#Region "  ｿｹｯﾄ送信                                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function SendSocket01(ByVal strReason As String) As Boolean

        Dim blnRet As Boolean = False

        Dim intRet As RetCode                 '戻り値
        Dim strMsg As String                  'ﾒｯｾｰｼﾞ


        ' '' ''*******************************************************
        ' '' ''確認ﾒｯｾｰｼﾞ
        ' '' ''*******************************************************
        '' ''Dim udtRet As RetPopup
        '' ''Dim strMessage As String
        '' ''strMessage = ""
        '' ''strMessage &= "更新" & FRM_MSG_FRM100031_01
        '' ''udtRet = DisplayPopup(strMessage, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        '' ''If udtRet <> RetPopup.OK Then
        '' ''    Exit Sub
        '' ''End If


        ' ''*******************************************************
        ' ''理由ｺｰﾄﾞ表示
        ' ''*******************************************************
        ''Dim udeRet As RetPopup
        ''Dim strFREASON As String = ""
        ''udeRet = DisplayFRM_100201(FREASON_KUBUN_TDSP_PMT_USER_UPDATE, strFREASON)
        ''If udeRet <> RetPopup.OK Then
        ''    Exit Sub
        ''End If



        '*******************************************************
        'ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙに追加する電文配列作成
        '*******************************************************
        Dim strSendTel() As String = Nothing
        For ii As Integer = 0 To grdList.Rows.Count - 1
            '(展開元画面の行分ﾙｰﾌﾟ)

            'ﾁｪｯｸﾎﾞｯｸｽ値ｾｯﾄ
            Dim strDSPCHECK As String = "0"
            Dim blnTrue As Boolean = True
            If TO_STRING(grdList.Item(FRM_206030.menmListCol.FOPE_FLAG, ii).Value) = blnTrue.ToString Or TO_STRING(grdList.Item(FRM_206030.menmListCol.FOPE_FLAG, ii).Value) = "1" Then
                '(ﾁｪｯｸが入っている場合)
                strDSPCHECK = "1"
            End If


            '************************
            'ﾕｰｻﾞｰ別許可ﾏｽﾀ特定
            '************************
            Dim objTDSP_PMT_USER As New TBL_TDSP_PMT_USER(gobjOwner, gobjDb, Nothing)
            objTDSP_PMT_USER.FUSER_DSP_LEVEL = TO_INTEGER_NULLABLE(grdList.Item(FRM_206030.menmListCol.FUSER_DSP_LEVEL, ii).Value)   'ﾕｰｻﾞｰ操作ﾚﾍﾞﾙ
            objTDSP_PMT_USER.FDISP_ID = TO_STRING(grdList.Item(FRM_206030.menmListCol.FDISP_ID, ii).Value)                           '画面ID
            objTDSP_PMT_USER.FCTRL_ID = TO_STRING(grdList.Item(FRM_206030.menmListCol.FCTRL_ID, ii).Value)                     'ｺﾝﾄﾛｰﾙID
            intRet = objTDSP_PMT_USER.GET_TDSP_PMT_USER(False)
            If intRet = RetCode.NotFound Then
                '(ﾕｰｻﾞｰ別許可ﾏｽﾀが存在しない場合)
                strMsg = ERRMSG_NOTFOUND_TDSP_PMT_USER & "[ﾕｰｻﾞｰ操作ﾚﾍﾞﾙ:" & TO_STRING(objTDSP_PMT_USER.FUSER_DSP_LEVEL) & "][画面ID:" & objTDSP_PMT_USER.FDISP_ID & "][ｺﾝﾄﾛｰﾙID:" & objTDSP_PMT_USER.FCTRL_ID & "]"
                Throw New UserException(strMsg)
            End If


            If TO_STRING(objTDSP_PMT_USER.FOPE_FLAG) <> strDSPCHECK Then
                '(DB値と違う場合)

                If IsNull(strSendTel) = True Then ReDim Preserve strSendTel(0) Else ReDim Preserve strSendTel(UBound(strSendTel) + 1)

                Dim objTelegramSub As New clsTelegram(CONFIG_TELEGRAM_DSP)
                objTelegramSub.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200801              'ﾌｫｰﾏｯﾄ名ｾｯﾄ
                objTelegramSub.SETIN_HEADER("DSPREASON", "")                                            '理由
                objTelegramSub.SETIN_DATA("DSPUSER_DSP_LEVEL", objTDSP_PMT_USER.FUSER_DSP_LEVEL)        'ﾕｰｻﾞｰ操作ﾚﾍﾞﾙ
                objTelegramSub.SETIN_DATA("DSPDISP_ID", objTDSP_PMT_USER.FDISP_ID)                      '画面ID
                objTelegramSub.SETIN_DATA("DSPCONTROL_ID", objTDSP_PMT_USER.FCTRL_ID)                   'ｺﾝﾄﾛｰﾙID
                objTelegramSub.SETIN_DATA("DSPOPE_FLAG", strDSPCHECK)                                   '操作ﾌﾗｸﾞ
                objTelegramSub.MAKE_TELEGRAM()

                strSendTel(UBound(strSendTel)) = objTelegramSub.TELEGRAM_MAKED

            End If

        Next


        '*******************************************************
        '変更箇所ﾁｪｯｸ
        '*******************************************************
        If IsNothing(strSendTel) = True Then
            '(ｸﾞﾘｯﾄﾞに変更箇所がなかった場合)
            Return True
        End If


        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        '========================================
        ' 変数宣言
        '========================================
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)

        Dim strDIR_KUBUN As String = ""         '処理区分
        Dim strMAINTE_USER_ID As String = ""     'ﾒﾝﾃﾅﾝｽﾕｰｻﾞｰID
        Dim strMAINTE_USER_NAME As String = ""   'ﾒﾝﾃﾅﾝｽﾕｰｻﾞｰ名
        Dim strREASON_CD As String = ""         '理由ｺｰﾄﾞ


        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200801       'ﾌｫｰﾏｯﾄ名ｾｯﾄ
        objTelegram.SETIN_HEADER("DSPREASON", strReason)                '理由
        objTelegram.SETIN_DATA("DSPUSER_DSP_LEVEL", "")                 'ﾕｰｻﾞｰ操作ﾚﾍﾞﾙ
        objTelegram.SETIN_DATA("DSPDISP_ID", "")                        '画面ID
        objTelegram.SETIN_DATA("DSPCONTROL_ID", "")                     'ｺﾝﾄﾛｰﾙID
        objTelegram.SETIN_DATA("DSPOPE_FLAG", "")                       '操作ﾌﾗｸﾞ

        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode    'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String                         'ｴﾗｰﾒｯｾｰｼﾞ

        strErrMsg = FRM_MSG_FRM206030_02
        udtSckSendRET = gobjComFuncFRM.SockSendServer02(objTelegram, strSendTel, strRET_STATE, , , , strErrMsg)    'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            '(送信できた場合)
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)
                blnRet = True
            End If
        End If
       
        Return blnRet

    End Function
#End Region

End Class
