'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ﾄﾗｯｷﾝｸﾞﾒﾝﾃﾅﾝｽ詳細画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_205030

#Region "　共通変数　                               "

    Private mstrTrackingBufferNo As String = ""         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo

    ''' <summary>ｸﾞﾘｯﾄﾞ項目</summary>
    Enum menmListCol

        FTRK_BUF_NAME       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.           ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称
        FPALLET_ID          '(非表示)ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      ﾊﾟﾚｯﾄID
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/05/16 最終行先追加
        FTR_TO              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.              搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        FTR_TO_DISP         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.              搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№(表示用)
        '↑↑↑↑↑↑************************************************************************************************************
        FTRNS_SERIAL        'ｼﾘｱﾙ関連津付け.            搬送ｼﾙｱﾙ№(MCｷｰ)
        FBUF_IN_DT          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.              ﾊﾞｯﾌｧ入日時
        FDISP_ADDRESS_FM    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.              FM表記用ｱﾄﾞﾚｽ
        FDISP_ADDRESS_TO    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.              TO表記用ｱﾄﾞﾚｽ
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/05/16 表記用ｱﾄﾞﾚｽ追加
        FDISP_ADDRESS       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.              表記用ｱﾄﾞﾚｽ
        '↑↑↑↑↑↑************************************************************************************************************
        FHINMEI_CD          '在庫情報.                  品名ｺｰﾄﾞ
        FHINMEI             '品目ﾏｽﾀ.                   品名
        FARRIVE_DT          '在庫情報.                  在庫発生日時
        FWAIT_REASON        '在庫引当情報.              指示送信待ち理由
        FTRK_BUF_NO         '(非表示)ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        FTRK_BUF_ARRAY      '(非表示)ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№

        MAXCOL
    End Enum

    ''' <summary>入力ﾁｪｯｸ場合判別</summary>
    Enum menmCheckCase
        Complete_Click      '強制完了ﾎﾞﾀﾝｸﾘｯｸ
        Cancel_Click        'ｷｬﾝｾﾙﾎﾞﾀﾝｸﾘｯｸ
        Delete_Click        '削除ﾎﾞﾀﾝｸﾘｯｸ
    End Enum

    ''' <summary>選択されたﾊﾟﾚｯﾄIDの配列</summary>
    Public mstrFPALLET_ID() As String = Nothing

#End Region
#Region "  ﾌﾟﾛﾊﾟﾃｨ                                  "
    ''' =======================================
    ''' <summary>ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNoのﾌﾟﾛﾊﾟﾃｨ</summary>
    ''' <remarks></remarks>
    ''' =======================================
    Public Property userTRK_BUF_NO() As String
        Get
            Return mstrTrackingBufferNo
        End Get
        Set(ByVal value As String)
            mstrTrackingBufferNo = value
        End Set
    End Property

#End Region
#Region "  ｲﾍﾞﾝﾄ                                    "
#Region "  ﾘｽﾄ          選択範囲変更ｲﾍﾞﾝﾄ           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾘｽﾄ 選択範囲変更ｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
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

        '**********************************************************
        ' ﾎﾞﾀﾝﾏｽｸ設定
        '**********************************************************
        Call CmdEnabledChangeMenu()                             'Menuﾎﾞﾀﾝ全般
        Call CmdEnabledChange(cmdClose, False)                  'ﾛｸﾞｵﾌﾎﾞﾀﾝ
        Call CmdEnabledChange(cmdMsgChk, False)                 'ｱﾅｼｴｰﾀﾎﾞﾀﾝ

        '**********************************************************
        ' ﾘｽﾄ表示
        '**********************************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        Call grdListDisplaySub(grdList)


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

    End Sub
#End Region
#Region "  F4(強制完了)  ﾎﾞﾀﾝ押下処理         　    "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F4(強制完了) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F4Process()


        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.Complete_Click) = False Then

            Exit Sub

        End If


        '********************************************************************
        '電文送信
        '********************************************************************
        If SendSocket02() = True Then

            Call grdListDisplaySub(grdList)

        End If

    End Sub
#End Region
#Region "  F5(ｷｬﾝｾﾙ)  ﾎﾞﾀﾝ押下処理　                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F5(ｷｬﾝｾﾙ) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F5Process()


        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.Cancel_Click) = False Then

            Exit Sub

        End If


        '********************************************************************
        '電文送信
        '********************************************************************
        If SendSocket01() = True Then

            Call grdListDisplaySub(grdList)

        End If

    End Sub
#End Region
#Region "  F6(削除)  ﾎﾞﾀﾝ押下処理　                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F6(削除) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F6Process()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.Delete_Click) = False Then

            Exit Sub

        End If


        '********************************************************************
        '電文送信
        '********************************************************************
        If SendSocket03() = True Then

            Call grdListDisplaySub(grdList)

        End If

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
        Me.Close()

    End Sub
#End Region
#Region "  ﾘｽﾄ              ｸﾘｯｸ処理                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾘｽﾄ ｸﾘｯｸ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdList_ClickProcess()


        '*********************************************
        '混載ｸﾞﾘｯﾄﾞ表示の複数選択処理
        '*********************************************
        Call gobjComFuncFRM.GridKonsaiSelect(grdList, mstrFPALLET_ID, menmListCol.FPALLET_ID)


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
        Dim blnCheckErr As Boolean = True      'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        Select Case udtCheck_Case
            Case menmCheckCase.Complete_Click
                '(強制完了)


                '********************************************************************
                '入力ﾁｪｯｸ
                '********************************************************************
                '==========================================
                ' ﾘｽﾄﾁｪｯｸ
                '==========================================
                If grdList.SelectedRows.Count < 1 Then
                    '(ﾘｽﾄが選択されていない場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_GRD_LIST, PopupFormType.Ok, PopupIconType.Information)
                    Exit Select
                End If

                '************************************************
                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ特定
                '************************************************
                Dim objTMST_TRK As New TBL_TMST_TRK(gobjOwner, gobjDb, Nothing)
                objTMST_TRK.FTRK_BUF_NO = TO_INTEGER(grdList.Item(menmListCol.FTRK_BUF_NO, grdList.SelectedRows(0).Index).Value)    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                objTMST_TRK.GET_TMST_TRK()                         '取得

                If Not (objTMST_TRK.FBUF_KIND = FBUF_KIND_SIN Or _
                    objTMST_TRK.FBUF_KIND = FBUF_KIND_SOUT Or _
                    objTMST_TRK.FBUF_KIND = FBUF_KIND_STRNS Or _
                    objTMST_TRK.FBUF_KIND = FBUF_KIND_SSOUKO) Then
                    '(入庫中ﾊﾞｯﾌｧ、出庫中ﾊﾞｯﾌｧ、搬送中ﾊﾞｯﾌｧ、倉庫間搬送中ﾊﾞｯﾌｧ以外のとき)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205030_04, PopupFormType.Ok, PopupIconType.Information)
                    Exit Select
                End If


                blnCheckErr = False

            Case menmCheckCase.Cancel_Click
                '(ｷｬﾝｾﾙ)


                '********************************************************************
                '入力ﾁｪｯｸ
                '********************************************************************
                '==========================================
                ' ﾘｽﾄﾁｪｯｸ
                '==========================================
                If grdList.SelectedRows.Count < 1 Then
                    '(ﾘｽﾄが選択されていない場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_GRD_LIST, PopupFormType.Ok, PopupIconType.Information)
                    Exit Select
                End If

                '************************************************
                'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ特定
                '************************************************
                Dim objTMST_TRK As New TBL_TMST_TRK(gobjOwner, gobjDb, Nothing)
                objTMST_TRK.FTRK_BUF_NO = TO_INTEGER(grdList.Item(menmListCol.FTRK_BUF_NO, grdList.SelectedRows(0).Index).Value)    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
                objTMST_TRK.GET_TMST_TRK()                         '取得

                If Not (objTMST_TRK.FBUF_KIND = FBUF_KIND_SIN Or _
                    objTMST_TRK.FBUF_KIND = FBUF_KIND_SOUT Or _
                    objTMST_TRK.FBUF_KIND = FBUF_KIND_STRNS Or _
                    objTMST_TRK.FBUF_KIND = FBUF_KIND_SSOUKO Or _
                    objTMST_TRK.FBUF_KIND = FBUF_KIND_SASRS Or _
                    objTMST_TRK.FBUF_KIND = FBUF_KIND_SHIRA) Then
                    '(入庫中ﾊﾞｯﾌｧ、出庫中ﾊﾞｯﾌｧ、搬送中ﾊﾞｯﾌｧ、倉庫間搬送中ﾊﾞｯﾌｧ、自動倉庫、平置き以外のとき)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205030_05, PopupFormType.Ok, PopupIconType.Information)
                    Exit Select
                End If


                blnCheckErr = False

            Case menmCheckCase.Delete_Click
                '(削除)

                '********************************************************************
                '入力ﾁｪｯｸ
                '********************************************************************
                '==========================================
                ' ﾘｽﾄﾁｪｯｸ
                '==========================================
                If grdList.SelectedRows.Count < 1 Then
                    '(ﾘｽﾄが選択されていない場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_GRD_LIST, PopupFormType.Ok, PopupIconType.Information)
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
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    TDSP_DISP.FGAMEN_DISP "                                 '画面表示ﾏｽﾀ.       画面表示用名称(ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称)
        strSQL &= vbCrLf & "   ,TPRG_TRK_BUF.FPALLET_ID "                               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      ﾊﾟﾚｯﾄID
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/06/12 最終行先追加
        strSQL &= vbCrLf & "   ,TPRG_TRK_BUF.FTR_TO "                                   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        strSQL &= vbCrLf & "   ,TMST_TRK.FBUF_NAME "                                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      名称
        '↑↑↑↑↑↑************************************************************************************************************
        strSQL &= vbCrLf & "   ,TPRG_SERIAL.FTRNS_SERIAL "                              'ｼﾘｱﾙ関連津付け.    搬送ｼﾙｱﾙ№(MCｷｰ)
        strSQL &= vbCrLf & "   ,TPRG_TRK_BUF.FBUF_IN_DT "                               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      ﾊﾞｯﾌｧ入日時
        strSQL &= vbCrLf & "   ,TPRG_TRK_BUF.FDISP_ADDRESS_FM "                         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      From表記用ｱﾄﾞﾚｽ
        strSQL &= vbCrLf & "   ,TPRG_TRK_BUF.FDISP_ADDRESS_TO "                         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      TO表記用ｱﾄﾞﾚｽ
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/05/16 表記用ｱﾄﾞﾚｽ追加
        strSQL &= vbCrLf & "   ,TPRG_TRK_BUF_DISP.FDISP_ADDRESS "                       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      表示用ｱﾄﾞﾚｽ
        '↑↑↑↑↑↑************************************************************************************************************
        strSQL &= vbCrLf & "   ,TRST_STOCK.FHINMEI_CD "                                 '在庫情報.          品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "   ,TMST_ITEM.FHINMEI "                                     '品目ﾏｽﾀ.           品名
        strSQL &= vbCrLf & "   ,TRST_STOCK.FARRIVE_DT "                                 '在庫情報.          在庫発生日時
        strSQL &= vbCrLf & "   ,MAX(TSTS_HIKIATE.FWAIT_REASON) "                        '在庫引当情報.      指示送信待ち理由                            
        strSQL &= vbCrLf & "   ,TPRG_TRK_BUF.FTRK_BUF_NO "                              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        strSQL &= vbCrLf & "   ,TPRG_TRK_BUF.FTRK_BUF_ARRAY "                           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№

        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    TPRG_TRK_BUF "                              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ
        strSQL &= vbCrLf & "   ,TRST_STOCK "                                '在庫情報
        strSQL &= vbCrLf & "   ,TPRG_SERIAL "                               'ｼﾘｱﾙ関連付け
        strSQL &= vbCrLf & "   ,TDSP_DISP "                                 '画面表示ﾏｽﾀ
        strSQL &= vbCrLf & "   ,TSTS_HIKIATE "                              '在庫引当情報
        strSQL &= vbCrLf & "   ,TMST_ITEM "                                 '品目ﾏｽﾀ

        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/06/12 最終行先追加
        strSQL &= vbCrLf & "   ,TMST_TRK "                                 'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ
        '↑↑↑↑↑↑************************************************************************************************************
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/05/16 表記用ｱﾄﾞﾚｽ追加
        strSQL &= vbCrLf & "   ,TPRG_TRK_BUF TPRG_TRK_BUF_DISP "         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ(表示用)
        '↑↑↑↑↑↑************************************************************************************************************

        '============================================================
        'WHERE
        '============================================================
        '----------------------------
        'ﾃｰﾌﾞﾙ結合
        '----------------------------
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        1 = 1 "
        strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FPALLET_ID = TRST_STOCK.FPALLET_ID "           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ と 在庫情報 の ﾊﾟﾚｯﾄID を 結合
        strSQL &= vbCrLf & "    AND TRST_STOCK.FPALLET_ID = TPRG_SERIAL.FPALLET_ID(+) "         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ と ｼﾘｱﾙ関連付け の ﾊﾟﾚｯﾄID を 外部結合
        strSQL &= vbCrLf & "    AND TRST_STOCK.FPALLET_ID = TSTS_HIKIATE.FPALLET_ID(+) "        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ と 在庫引当情報 の ﾊﾟﾚｯﾄID を 外部結合
        strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FRES_KIND IN (" & FRES_KIND_SZAIKO & "," & FRES_KIND_SRSV_TRNS_OUT & ")"   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.引当状態 ﾄﾗｯｷﾝｸﾞ有を意味する条件を全て指定
        strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FPALLET_ID IS NOT NULL "                       'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.ﾊﾟﾚｯﾄID NULL以外 を 指定
        strSQL &= vbCrLf & "    AND NOT (     TPRG_TRK_BUF.FTRK_BUF_NO IN ("
        strSQL &= vbCrLf & "                                               SELECT FTRK_BUF_NO FROM TMST_TRK WHERE FBUF_KIND IN (" & FBUF_KIND_SASRS & ", " & FBUF_KIND_SHIRA & ")"
        strSQL &= vbCrLf & "                                               )"
        strSQL &= vbCrLf & "              AND TPRG_TRK_BUF.FRES_KIND = " & FRES_KIND_SZAIKO & ") "
        strSQL &= vbCrLf & "    AND TDSP_DISP.FTABLE_NAME = 'TMST_TRK' "                            '画面表示設定値
        strSQL &= vbCrLf & "    AND TDSP_DISP.FFIELD_NAME = 'FTRK_BUF_NO' "                         '画面表示設定値
        strSQL &= vbCrLf & "    AND TDSP_DISP.FDISP_VALUE = TO_CHAR(TPRG_TRK_BUF.FTRK_BUF_NO) "     '画面表示設定値
        strSQL &= vbCrLf & "    AND TMST_ITEM.FHINMEI_CD(+) = TRST_STOCK.FHINMEI_CD "               '品目ﾏｽﾀ と 在庫情報 の 品目ｺｰﾄﾞ を 外部結合

        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/06/12 最終行先追加
        strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FTR_TO = TMST_TRK.FTRK_BUF_NO(+) "
        '↑↑↑↑↑↑************************************************************************************************************

        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/05/16 表記用ｱﾄﾞﾚｽ追加
        strSQL &= vbCrLf & "   AND TRST_STOCK.XTRK_BUF_NO_IN = TPRG_TRK_BUF_DISP.FTRK_BUF_NO(+) "
        strSQL &= vbCrLf & "   AND TRST_STOCK.XTRK_BUF_ARRAY_IN = TPRG_TRK_BUF_DISP.FTRK_BUF_ARRAY(+) "
        '↑↑↑↑↑↑************************************************************************************************************

        If mstrTrackingBufferNo = DSP_MNT_GRD_ALL Then
            '(全検索ﾎﾞﾀﾝを押下した場合)
            'NOP
 
        Else
            '('その他のﾄﾗｯｷﾝｸﾞｴﾘｱを選択した場合)
            strSQL &= vbCrLf & "    AND TPRG_TRK_BUF.FTRK_BUF_NO IN (" & mstrTrackingBufferNo & ")"

        End If
        '============================================================
        'GROUP BY
        '============================================================
        strSQL &= vbCrLf & " GROUP BY  "
        strSQL &= vbCrLf & "    TDSP_DISP.FGAMEN_DISP "                                 '画面表示ﾏｽﾀ.       画面表示用名称(ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ名称)
        strSQL &= vbCrLf & "   ,TPRG_TRK_BUF.FPALLET_ID "                               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      ﾊﾟﾚｯﾄID
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/06/12 最終行先追加
        strSQL &= vbCrLf & "   ,TPRG_TRK_BUF.FTR_TO "                                   'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      搬送TOﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        strSQL &= vbCrLf & "   ,TMST_TRK.FBUF_NAME "                                    'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧﾏｽﾀ.   名称
        '↑↑↑↑↑↑************************************************************************************************************
        strSQL &= vbCrLf & "   ,TPRG_SERIAL.FTRNS_SERIAL "                              'ｼﾘｱﾙ関連津付け.    搬送ｼﾙｱﾙ№(MCｷｰ)
        strSQL &= vbCrLf & "   ,TPRG_TRK_BUF.FBUF_IN_DT "                               'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      ﾊﾞｯﾌｧ入日時
        strSQL &= vbCrLf & "   ,TPRG_TRK_BUF.FDISP_ADDRESS_FM "                         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      From表記用ｱﾄﾞﾚｽ
        strSQL &= vbCrLf & "   ,TPRG_TRK_BUF.FDISP_ADDRESS_TO "                         'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      TO表記用ｱﾄﾞﾚｽ
        strSQL &= vbCrLf & "   ,TRST_STOCK.FHINMEI_CD "                                 '在庫情報.          品名ｺｰﾄﾞ
        strSQL &= vbCrLf & "   ,TMST_ITEM.FHINMEI "                                     '品目ﾏｽﾀ.           品名
        strSQL &= vbCrLf & "   ,TRST_STOCK.FARRIVE_DT "                                 '在庫情報.          在庫発生日時
        strSQL &= vbCrLf & "   ,TPRG_TRK_BUF.FTRK_BUF_NO "                              'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        strSQL &= vbCrLf & "   ,TPRG_TRK_BUF.FTRK_BUF_ARRAY "                           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:H.Okumura 2013/05/16 表記用ｱﾄﾞﾚｽ追加
        strSQL &= vbCrLf & "   ,TPRG_TRK_BUF_DISP.FDISP_ADDRESS "                           'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.      ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ配列№
        '↑↑↑↑↑↑************************************************************************************************************

        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & " ORDER BY  "
        strSQL &= vbCrLf & "    TPRG_TRK_BUF.FBUF_IN_DT DESC "      'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.ﾊﾞｯﾌｧ入日時
        strSQL &= vbCrLf & "  , TPRG_TRK_BUF.FTRK_BUF_NO "          'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ№
        strSQL &= vbCrLf & "  , TPRG_TRK_BUF.FPALLET_ID"            'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧ.ﾊﾟﾚｯﾄID

        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        Dim objPoint As Point           'ｸﾞﾘｯﾄﾞのｽｸﾛｰﾙ位置      記憶
        Dim intSelectRow As Integer     'ｸﾞﾘｯﾄﾞの選択行位置     記憶
        Dim intSelectCol As Integer     'ｸﾞﾘｯﾄﾞの選択列位置
        Call gobjComFuncFRM.TblDataGridDisplay(grdList, _
                                strSQL, _
                                False, _
                                False, _
                                intSelectRow, _
                                intSelectCol, _
                                objPoint)


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdListSetup()
        Call gobjComFuncFRM.GridSelect(grdList, intSelectRow, intSelectCol, objPoint)      'ｸﾞﾘｯﾄﾞ選択処理


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


    End Sub
#End Region
#Region "  ｿｹｯﾄ送信01　                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信01
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function SendSocket01() As Boolean


        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        udtRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205030_02, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Function
        End If


        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
        Dim strTrkBufNo As String
        Dim strTrkBufAry As String
        Dim strPalletID As String

        strTrkBufNo = TO_STRING(grdList.Item(menmListCol.FTRK_BUF_NO, grdList.SelectedRows(0).Index).Value)
        strTrkBufAry = TO_STRING(grdList.Item(menmListCol.FTRK_BUF_ARRAY, grdList.SelectedRows(0).Index).Value)
        strPalletID = TO_STRING(grdList.Item(menmListCol.FPALLET_ID, grdList.SelectedRows(0).Index).Value)

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200503  'ﾌｫｰﾏｯﾄ名ｾｯﾄ
        objTelegram.SETIN_DATA("DSPTRK_BUF_NO", strTrkBufNo)        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
        objTelegram.SETIN_DATA("DSPTRK_BUF_ARRAY", strTrkBufAry)    'ﾄﾗｯｷﾝｸﾞ配列No
        objTelegram.SETIN_DATA("DSPPALLET_ID", strPalletID)         'ﾊﾟﾚｯﾄID

        If gobjComFuncFRM.SockSendServer01(objTelegram, "") = clsSocketClient.RetCode.OK Then
            Return True
        Else
            Return False
        End If

    End Function
#End Region
#Region "  ｿｹｯﾄ送信02　                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信02
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function SendSocket02() As Boolean


        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        udtRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205030_01, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Function
        End If


        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
        Dim strTrkBufNo As String
        Dim strTrkBufAry As String
        Dim strPalletID As String

        strTrkBufNo = TO_STRING(grdList.Item(menmListCol.FTRK_BUF_NO, grdList.SelectedRows(0).Index).Value)
        strTrkBufAry = TO_STRING(grdList.Item(menmListCol.FTRK_BUF_ARRAY, grdList.SelectedRows(0).Index).Value)
        strPalletID = TO_STRING(grdList.Item(menmListCol.FPALLET_ID, grdList.SelectedRows(0).Index).Value)

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200501  'ﾌｫｰﾏｯﾄ名ｾｯﾄ
        objTelegram.SETIN_DATA("DSPTRK_BUF_NO", strTrkBufNo)        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
        objTelegram.SETIN_DATA("DSPTRK_BUF_ARRAY", strTrkBufAry)    'ﾄﾗｯｷﾝｸﾞ配列No
        objTelegram.SETIN_DATA("DSPPALLET_ID", strPalletID)         'ﾊﾟﾚｯﾄID

        If gobjComFuncFRM.SockSendServer01(objTelegram, "") = clsSocketClient.RetCode.OK Then
            Return True
        Else
            Return False
        End If

    End Function
#End Region
#Region "  ｿｹｯﾄ送信03　                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信03
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function SendSocket03() As Boolean


        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        udtRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205030_03, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Function
        End If


        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
        Dim strTrkBufNo As String
        Dim strTrkBufAry As String
        Dim strPalletID As String

        strTrkBufNo = TO_STRING(grdList.Item(menmListCol.FTRK_BUF_NO, grdList.SelectedRows(0).Index).Value)
        strTrkBufAry = TO_STRING(grdList.Item(menmListCol.FTRK_BUF_ARRAY, grdList.SelectedRows(0).Index).Value)
        strPalletID = TO_STRING(grdList.Item(menmListCol.FPALLET_ID, grdList.SelectedRows(0).Index).Value)

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200502  'ﾌｫｰﾏｯﾄ名ｾｯﾄ
        objTelegram.SETIN_DATA("DSPTRK_BUF_NO", strTrkBufNo)        'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo
        objTelegram.SETIN_DATA("DSPTRK_BUF_ARRAY", strTrkBufAry)    'ﾄﾗｯｷﾝｸﾞ配列No
        objTelegram.SETIN_DATA("DSPPALLET_ID", strPalletID)         'ﾊﾟﾚｯﾄID

        If gobjComFuncFRM.SockSendServer01(objTelegram, "") = clsSocketClient.RetCode.OK Then
            Return True
        Else
            Return False
        End If

    End Function
#End Region

End Class
