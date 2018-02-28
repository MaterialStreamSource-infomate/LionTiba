'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】生産ﾗｲﾝﾓﾆﾀ画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_302010
#Region "　共通変数　                               "

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ

    ''' <summary>ﾁｪｯｸ用列挙体</summary>
    Enum menmCheckCase
        UntenSetteiBtn_Click            '運転設定
        NippouOutBtn_Click              '生産ﾗｲﾝ日報出力
    End Enum

    ''' <summary>ｸﾞﾘｯﾄﾞ項目</summary>
    Enum menmListCol
        XDPL_PL_NO                      'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況      .ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号
        XDPL_PL_NAME                    'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾏｽﾀ       .ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ名称
        XPROD_LINE                      'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾏｽﾀ       .生産ﾗｲﾝ№
        XDPL_PL_ONLINE                  'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況      .ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾝﾗｲﾝ状態
        XDPL_PL_ONLINE_DSP              'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況      .ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾝﾗｲﾝ状態(表示用)
        XDPL_PL_STS                     'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況      .ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転状態
        XDPL_PL_STS_DSP                 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況      .ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転状態(表示用)
        FEQ_STS_01                      '設備状況(異常状態)     .設備状態
        FEQ_STS_01_DSP                  '設備状況(異常状態)     .設備状態(表示用)
        FHINMEI_CD                      'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況      .品目ｺｰﾄﾞ
        XDPL_PL_PTN                     'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況      .ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ
        FEQ_STS_02                      '設備状況(生産数)       .設備状態
        FEQ_STS_03                      '設備状況(PL数)         .設備状態
        START_DT                        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況      .開始日時
        END_DT                          'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況      .終了日時
        KADOU_DT                        '設備状況(稼働時間)     .設備状態
        FEQ_STS_11                      '設備状況((ﾄﾗﾌﾞﾙ件数)   .設備状態
        DUMMY18
        DUMMY19
        DUMMY20
        DUMMY21
        MAXCOL

    End Enum

#End Region
#Region "  ｲﾍﾞﾝﾄ                                    "
#Region "  ﾎｰﾑﾍﾞｰｽｸﾘｯｸ(選択解除)                "
    Private Sub FRM_302010_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Click
        grdList.ClearSelection()
    End Sub
#End Region
#Region "  定周期表示用   ﾀｲﾏｰ                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 定周期表示用 ﾀｲﾏｰ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tmr302010_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr302010.Tick
        Try

            tmr302010.Enabled = False

            '**************************************************
            ' 定周期表示ﾀｲﾏｰ処理
            '**************************************************
            Call tmr302010_TickProcess()

        Catch ex As Exception
            ComError(ex)

        Finally
            tmr302010.Enabled = True

        End Try
    End Sub
#End Region
#Region "　ﾌｫｰﾑｱｸﾃｨﾌﾞ                               "
    '*******************************************************************************************************************
    '【機能】ﾌｫｰﾑｱｸﾃｨﾌﾞ時ｲﾍﾞﾝﾄ
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub FRM_302010_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
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
        ' ｸﾞﾘｯﾄﾞ初期化
        '*********************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        'grdList.MultiSelect = True                                              '複数行選択
        Call grdListSetup()

        '**********************************************************
        ' 表示更新
        '**********************************************************
        Call tmr302010_TickProcess()

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
        grdList.Dispose()

    End Sub
#End Region
#Region "  F1(運転設定)  ﾎﾞﾀﾝ押下処理　               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F1(運転設定) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F1Process()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.UntenSetteiBtn_Click) = False Then
            Exit Sub
        End If

        '************************************
        ' ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        '************************************
        If IsNull(gobjFRM_302011) = False Then
            gobjFRM_302011.Close()
            gobjFRM_302011.Dispose()
            gobjFRM_302011 = Nothing
        End If

        gobjFRM_302011 = New FRM_302011

        Call SetPropertyF1()      'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ

        Dim intRet As DialogResult
        intRet = gobjFRM_302011.ShowDialog()            '展開

        If intRet = Windows.Forms.DialogResult.Cancel Then
            '(ｷｬﾝｾﾙ時)
            Exit Sub
        End If

        '*********************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '*********************************************
        Call grdListDisplaySub(grdList)
        grdList.ClearSelection()

    End Sub
#End Region
#Region "  F2(生産ﾗｲﾝ日報出力)  ﾎﾞﾀﾝ押下処理           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F2(生産ﾗｲﾝ日報出力) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F2Process()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.NippouOutBtn_Click) = False Then
            Exit Sub
        End If

        '************************************
        ' ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        '************************************
        If IsNull(gobjFRM_302012) = False Then
            gobjFRM_302012.Close()
            gobjFRM_302012.Dispose()
            gobjFRM_302012 = Nothing
        End If

        gobjFRM_302012 = New FRM_302012

        Call SetPropertyF2()      'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ

        Dim intRet As DialogResult
        intRet = gobjFRM_302012.ShowDialog()            '展開

        If intRet = Windows.Forms.DialogResult.Cancel Then
            '(ｷｬﾝｾﾙ時)
            Exit Sub
        End If

        '*********************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '*********************************************
        Call grdListDisplaySub(grdList)
        grdList.ClearSelection()

    End Sub
#End Region
#Region "  F3(生産入庫登録)  ﾎﾞﾀﾝ押下処理　     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F3(生産入庫登録) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F3Process()

        ''******************************************
        '' 画面遷移
        ''******************************************
        Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_310010, Me)
        Me.Close()

    End Sub
#End Region
#Region "  F4(包材出庫登録)  ﾎﾞﾀﾝ押下処理　     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F4(包材出庫登録) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F4Process()

        ''******************************************
        '' 画面遷移
        ''******************************************
        Call gobjComFuncFRM.FormMoveSelect(FDISP_ID_JFRM_310030, Me)
        Me.Close()

    End Sub
#End Region

#Region "　入力ﾁｪｯｸ　                               "
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
            Case menmCheckCase.UntenSetteiBtn_Click
                '(運転設定ﾎﾞﾀﾝｸﾘｯｸ時)

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


            Case menmCheckCase.NippouOutBtn_Click
                '(開始終了設定ﾎﾞﾀﾝｸﾘｯｸ時)

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
#Region "  運転設定子画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ　          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 運転設定子画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SetPropertyF1()
        Dim intXPROGRESS As Integer = -1

        gobjFRM_302011.userXDPL_PL_NO = TO_INTEGER(grdList.Item(menmListCol.XDPL_PL_NO, grdList.SelectedRows(0).Index).Value)                   'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況      .ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号
        gobjFRM_302011.userXDPL_PL_NAME = TO_STRING(grdList.Item(menmListCol.XDPL_PL_NAME, grdList.SelectedRows(0).Index).Value)                'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾏｽﾀ       .ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ名称
        gobjFRM_302011.userXPROD_LINE = TO_STRING(grdList.Item(menmListCol.XPROD_LINE, grdList.SelectedRows(0).Index).Value)                    'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾏｽﾀ       .生産ﾗｲﾝ№
        gobjFRM_302011.userXDPL_PL_ONLINE = TO_INTEGER_NULLABLE(grdList.Item(menmListCol.XDPL_PL_ONLINE, grdList.SelectedRows(0).Index).Value)  'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況      .ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾝﾗｲﾝ状態
        gobjFRM_302011.userXDPL_PL_STS = TO_INTEGER_NULLABLE(grdList.Item(menmListCol.XDPL_PL_STS, grdList.SelectedRows(0).Index).Value)        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況      .ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転状態
        gobjFRM_302011.userFEQ_STS_01 = TO_INTEGER_NULLABLE(grdList.Item(menmListCol.FEQ_STS_01, grdList.SelectedRows(0).Index).Value)          '設備状況(異常状態)     .設備状態
        gobjFRM_302011.userFHINMEI_CD = TO_STRING(grdList.Item(menmListCol.FHINMEI_CD, grdList.SelectedRows(0).Index).Value)                    'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況      .品目ｺｰﾄﾞ
        gobjFRM_302011.userXDPL_PL_PTN = TO_INTEGER_NULLABLE(grdList.Item(menmListCol.XDPL_PL_PTN, grdList.SelectedRows(0).Index).Value)        'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況      .ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ

        'intXPROGRESS = TO_INTEGER(grdList.Item(menmListCol.PROGRESS, grdList.SelectedRows(0).Index).Value)

        '共通ﾃﾞｰﾀ
        'gobjFRM_302011.userFTRK_BUF_NO = TO_STRING(grdList.Item(menmListCol.FTRK_BUF_NO, grdList.SelectedRows(0).Index).Value)                  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
        ' ''gobjFRM_302011.userFTRK_BUF_NO_Disp = TO_STRING(grdList.Item(menmListCol.FTRK_BUF_NO_Disp, grdList.SelectedRows(0).Index).Value)        '入庫ST
        ' ''gobjFRM_302011.userFEQ_ID = TO_STRING(grdList.Item(menmListCol.DSPEQ_ID, grdList.SelectedRows(0).Index).Value)                          '設備ID
        ' ''gobjFRM_302011.userDSPGRID_DISPLAYINDEX = TO_STRING(grdList.Item(menmListCol.GRID_DISPLAYINDEX, grdList.SelectedRows(0).Index).Value)   '表示順序

        ' ''gobjFRM_302011.userXPROGRESS = intXPROGRESS         '進捗状況

        ' ''If intXPROGRESS = XPROGRESS_NON Then
        ' ''    '(未作業の場合)

        ' ''ElseIf intXPROGRESS = XPROGRESS_START Then
        ' ''    '(開始状態の場合)
        ' ''    gobjFRM_302011.userFHINMEI_CD = TO_STRING(grdList.Item(menmListCol.HINMEI_CD, grdList.SelectedRows(0).Index).Value)                     '品名ｺｰﾄﾞ
        ' ''    gobjFRM_302011.userFHINMEI = TO_STRING(grdList.Item(menmListCol.HINMEI, grdList.SelectedRows(0).Index).Value)                           '品名
        ' ''    gobjFRM_302011.userXPROD_LINE = TO_STRING(grdList.Item(menmListCol.PROD_LINE, grdList.SelectedRows(0).Index).Value)                     '生産ﾗｲﾝNo.
        ' ''    gobjFRM_302011.userXPROD_LINE_Disp = TO_STRING(grdList.Item(menmListCol.PROD_LINE_Disp, grdList.SelectedRows(0).Index).Value)           '生産ﾗｲﾝNo.(表示用)

        ' ''    gobjFRM_302011.userFARRIVE_DT = TO_STRING(grdList.Item(menmListCol.FARRIVE_DT, grdList.SelectedRows(0).Index).Value)                    '在庫発生日時
        ' ''    gobjFRM_302011.userXMAKER_CD = TO_STRING(grdList.Item(menmListCol.XMAKER_CD, grdList.SelectedRows(0).Index).Value)                      'ﾒｰｶｰｺｰﾄﾞ
        ' ''    gobjFRM_302011.userXKENSA_KUBUN = TO_STRING(grdList.Item(menmListCol.XKENSA_KUBUN, grdList.SelectedRows(0).Index).Value)                '検査区分
        ' ''    gobjFRM_302011.userXKENSA_KUBUN_Disp = TO_STRING(grdList.Item(menmListCol.XKENSA_KUBUN_Disp, grdList.SelectedRows(0).Index).Value)      '検査区分(表示用)
        ' ''    gobjFRM_302011.userFHORYU_KUBUN = TO_STRING(grdList.Item(menmListCol.FHORYU_KUBUN, grdList.SelectedRows(0).Index).Value)                '保留区分
        ' ''    gobjFRM_302011.userFHORYU_KUBUN_Disp = TO_STRING(grdList.Item(menmListCol.FHORYU_KUBUN_Disp, grdList.SelectedRows(0).Index).Value)      '保留区分(表示用)
        ' ''    gobjFRM_302011.userFIN_KUBUN = TO_STRING(grdList.Item(menmListCol.FIN_KUBUN, grdList.SelectedRows(0).Index).Value)                      '入庫区分
        ' ''    gobjFRM_302011.userFIN_KUBUN_Disp = TO_STRING(grdList.Item(menmListCol.FIN_KUBUN_Disp, grdList.SelectedRows(0).Index).Value)            '入庫区分(表示用)
        ' ''    gobjFRM_302011.userXKENPIN_KUBUN = TO_STRING(grdList.Item(menmListCol.XKENPIN_KUBUN, grdList.SelectedRows(0).Index).Value)              '検品区分
        ' ''    gobjFRM_302011.userXKENPIN_KUBUN_Disp = TO_STRING(grdList.Item(menmListCol.XKENPIN_KUBUN_Disp, grdList.SelectedRows(0).Index).Value)    '検品区分(表示用)


        ' ''ElseIf intXPROGRESS = XPROGRESS_END Then
        ' ''    '(終了状態の場合)

        ' ''End If

    End Sub

#End Region
#Region "  運転設定子画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ　          "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 運転設定子画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SetPropertyF2()
    End Sub

#End Region
#Region "  端数生産入庫設定画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ　       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 端数生産入庫設定画面へﾌﾟﾛﾊﾟﾃｨｾｯﾄ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SetProperty2()
        gobjFRM_310020.userMenuFlg = False
        'gobjFRM_310020.userFTRK_BUF_NO = TO_STRING(grdList.Item(menmListCol.FTRK_BUF_NO, grdList.SelectedRows(0).Index).Value)                  'ﾄﾗｯｷﾝｸﾞﾊﾞｯﾌｧNo.
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

        Dim strSQL As String = ""                       'SQL文

        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "       XSTS_DPL_PL.XDPL_PL_NO AS XDPL_PL_NO "                   'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況      .ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ番号
        strSQL &= vbCrLf & "     , XMST_DPL_PL.XDPL_PL_NAME AS XDPL_PL_NAME "               'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾏｽﾀ       .ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ名称
        strSQL &= vbCrLf & "     , XMST_DPL_PL.XPROD_LINE AS XPROD_LINE "                   'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾏｽﾀ       .生産ﾗｲﾝ№
        strSQL &= vbCrLf & "     , XSTS_DPL_PL.XDPL_PL_ONLINE AS XDPL_PL_ONLINE "           'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況      .ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾝﾗｲﾝ状態
        strSQL &= vbCrLf & "     , HASH01.FGAMEN_DISP AS XDPL_PL_ONLINE_DSP "               'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況      .ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞｵﾝﾗｲﾝ状態(表示用)
        strSQL &= vbCrLf & "     , XSTS_DPL_PL.XDPL_PL_STS AS XDPL_PL_STS "                 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況      .ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転状態
        strSQL &= vbCrLf & "     , HASH02.FGAMEN_DISP AS XDPL_PL_STS_DSP "                  'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況      .ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ運転状態(表示用)
        strSQL &= vbCrLf & "     , EQ01.FEQ_STS AS FEQ_STS_01"                              '設備状況(異常状態)     .設備状態
        strSQL &= vbCrLf & "     , HASH03.FGAMEN_DISP AS FEQ_STS_01_DSP "                   '設備状況(異常状態)     .設備状態(表示用)
        strSQL &= vbCrLf & "     , XSTS_DPL_PL.FHINMEI_CD AS FHINMEI_CD "                   'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況      .品目ｺｰﾄﾞ
        strSQL &= vbCrLf & "     , XSTS_DPL_PL.XDPL_PL_PTN AS XDPL_PL_PTN "                 'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況      .ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾊﾟﾀｰﾝ
        strSQL &= vbCrLf & "     , EQ02.FEQ_STS AS FEQ_STS_02 "                             '設備状況(生産数)       .設備状態
        strSQL &= vbCrLf & "     , EQ03.FEQ_STS AS FEQ_STS_03 "                             '設備状況(PL数)         .設備状態
        strSQL &= vbCrLf & "     , TO_CHAR(XSTS_DPL_PL.XSTART_DT,'HH24:MI') AS START_DT "   'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況      .開始日時
        strSQL &= vbCrLf & "     , TO_CHAR(XSTS_DPL_PL.XEND_DT,'HH24:MI') AS END_DT  "      'ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況      .終了日時
        strSQL &= vbCrLf & "     , CONCAT(CONCAT(TRIM(TO_CHAR(EQ05.FEQ_STS,'00')),':' ), "  '設備状況(稼働時間_時)  .設備状態
        strSQL &= vbCrLf & "       TRIM(TO_CHAR(EQ06.FEQ_STS,'00'))) AS KADOU_DT"           '設備状況(稼働時間_分)  .設備状態
        strSQL &= vbCrLf & "     , EQ11.FEQ_STS AS FEQ_STS_11 "                             '設備状況((ﾄﾗﾌﾞﾙ件数)   .設備状態
        strSQL &= vbCrLf & "     , XSTS_PRODUCT_IN.FHINMEI_CD AS FHINMEI_CD_01 "            '生産入庫設定状態       .品目ｺｰﾄﾞ
        strSQL &= vbCrLf & "     , XSTS_WRAPPING_MATERIAL.FHINMEI_CD AS FHINMEI_CD_02 "     '包材出庫設定状態       .品目ｺｰﾄﾞ

        '============================================================
        'FROM
        '============================================================
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    XSTS_DPL_PL "                               '【ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞ状況】
        strSQL &= vbCrLf & "  , XMST_DPL_PL "                               '【ﾃﾞﾊﾟﾚ･ﾊﾟﾚﾀｲｻﾞﾏｽﾀ】
        strSQL &= vbCrLf & "  , XSTS_PRODUCT_IN "                           '【生産入庫設定状態】
        strSQL &= vbCrLf & "  , XSTS_WRAPPING_MATERIAL "                    '【包材出庫設定状態】
        strSQL &= vbCrLf & "  , TSTS_EQ_CTRL EQ01"                          '【設備状況(異常状態)】
        strSQL &= vbCrLf & "  , TSTS_EQ_CTRL EQ02"                          '【設備状況(生産数)】
        strSQL &= vbCrLf & "  , TSTS_EQ_CTRL EQ03"                          '【設備状況(PL数)】
        strSQL &= vbCrLf & "  , TSTS_EQ_CTRL EQ04"                          '【設備状況(端数)】
        strSQL &= vbCrLf & "  , TSTS_EQ_CTRL EQ05"                          '【設備状況(稼働時間_時)】
        strSQL &= vbCrLf & "  , TSTS_EQ_CTRL EQ06"                          '【設備状況(稼働時間_分)】
        strSQL &= vbCrLf & "  , TSTS_EQ_CTRL EQ07"                          '【設備状況(稼働時間_秒)】
        strSQL &= vbCrLf & "  , TSTS_EQ_CTRL EQ08"                          '【設備状況(ﾄﾗﾌﾞﾙ時間_時)】
        strSQL &= vbCrLf & "  , TSTS_EQ_CTRL EQ09"                          '【設備状況(ﾄﾗﾌﾞﾙ時間_分)】
        strSQL &= vbCrLf & "  , TSTS_EQ_CTRL EQ10"                          '【設備状況(ﾄﾗﾌﾞﾙ時間_秒)】
        strSQL &= vbCrLf & "  , TSTS_EQ_CTRL EQ11"                          '【設備状況(ﾄﾗﾌﾞﾙ件数)】
        strSQL &= vbCrLf & "  , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH01", "XSTS_DPL_PL", "XDPL_PL_ONLINE")
        strSQL &= vbCrLf & "  , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH02", "XSTS_DPL_PL", "XDPL_PL_STS")
        strSQL &= vbCrLf & "  , " & gobjComFuncFRM.GetSQLHashTableFrom01("HASH03", "EQ01", "FEQ_STS")


        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        1 = 1"         '必ず通る条件
        strSQL &= vbCrLf & "    AND XSTS_DPL_PL.XDPL_PL_NO = XMST_DPL_PL.XDPL_PL_NO(+) "
        strSQL &= vbCrLf & "    AND XMST_DPL_PL.XDPL_PL_EQ_ID_IJOU = EQ01.FEQ_ID(+) "       '【設備状況(異常状態)】
        strSQL &= vbCrLf & "    AND XMST_DPL_PL.XDPL_PL_EQ_ID_COUNT = EQ02.FEQ_ID(+) "      '【設備状況(生産数)】
        strSQL &= vbCrLf & "    AND XMST_DPL_PL.XDPL_PL_EQ_ID_PL = EQ03.FEQ_ID(+) "         '【設備状況(PL数)】
        strSQL &= vbCrLf & "    AND XMST_DPL_PL.XDPL_PL_EQ_ID_HASU = EQ04.FEQ_ID(+) "       '【設備状況(端数)】
        strSQL &= vbCrLf & "    AND XMST_DPL_PL.XDPL_PL_EQ_ID_KADOU_HH = EQ05.FEQ_ID(+) "   '【設備状況(稼働時間_時)】
        strSQL &= vbCrLf & "    AND XMST_DPL_PL.XDPL_PL_EQ_ID_KADOU_MM = EQ06.FEQ_ID(+) "   '【設備状況(稼働時間_分)】
        strSQL &= vbCrLf & "    AND XMST_DPL_PL.XDPL_PL_EQ_ID_KADOU_SS = EQ07.FEQ_ID(+) "   '【設備状況(稼働時間_秒)】
        strSQL &= vbCrLf & "    AND XMST_DPL_PL.XDPL_PL_EQ_ID_TRBL_HH = EQ08.FEQ_ID(+) "    '【設備状況(ﾄﾗﾌﾞﾙ時間_時)】
        strSQL &= vbCrLf & "    AND XMST_DPL_PL.XDPL_PL_EQ_ID_TRBL_MM = EQ09.FEQ_ID(+) "    '【設備状況(ﾄﾗﾌﾞﾙ時間_分)】
        strSQL &= vbCrLf & "    AND XMST_DPL_PL.XDPL_PL_EQ_ID_TRBL_SS = EQ10.FEQ_ID(+) "    '【設備状況(ﾄﾗﾌﾞﾙ時間_秒)】
        strSQL &= vbCrLf & "    AND XMST_DPL_PL.XDPL_PL_EQ_ID_TRBL = EQ11.FEQ_ID(+) "       '【設備状況(ﾄﾗﾌﾞﾙ件数)】
        strSQL &= vbCrLf & "    AND XMST_DPL_PL.FTRK_BUF_NO = XSTS_PRODUCT_IN.FTRK_BUF_NO(+) "
        strSQL &= vbCrLf & "    AND XMST_DPL_PL.FTRK_BUF_NO = XSTS_WRAPPING_MATERIAL.FTRK_BUF_NO(+) "
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH01", "XSTS_DPL_PL", "XDPL_PL_ONLINE")
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH02", "XSTS_DPL_PL", "XDPL_PL_STS")
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH03", "EQ01", "FEQ_STS")


        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & gobjComFuncFRM.GetSQL_TDSP_GRID_OrderBy(Me, grdList)
        strSQL &= vbCrLf


        '********************************************************************
        'ﾃﾞｰﾀｾｯﾄ取得
        '********************************************************************
        Dim objRow As DataRow                                   '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim objDataTable As New GamenCommon.clsGridDataTable20  'ｸﾞﾘｯﾄﾞ用ﾃﾞｰﾀﾃｰﾌﾞﾙ
        Dim objDataSet As New DataSet           'ﾃﾞｰﾀｾｯﾄ
        Dim strDataSetName As String            'ﾃﾞｰﾀｾｯﾄ名
        gobjDb.SQL = strSQL
        strDataSetName = "XSTS_DPL_PL"
        objDataSet.Clear()
        gobjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            Dim ii As Integer = 1
            For Each objRow In objDataSet.Tables(strDataSetName).Rows
                '' ''objDataTable.userAddRowDataSet( _
                '' ''                               TO_STRING(objRow("XDPL_PL_NO")), _
                '' ''                               TO_STRING(objRow("XDPL_PL_NAME")), _
                '' ''                               TO_STRING(objRow("XPROD_LINE")), _
                '' ''                               TO_STRING(objRow("XDPL_PL_ONLINE")), _
                '' ''                               TO_STRING(objRow("XDPL_PL_ONLINE_DSP")), _
                '' ''                               TO_STRING(objRow("XDPL_PL_STS")), _
                '' ''                               TO_STRING(objRow("XDPL_PL_STS_DSP")), _
                '' ''                               TO_STRING(objRow("FEQ_STS_01")), _
                '' ''                               TO_STRING(objRow("FEQ_STS_01_DSP")), _
                '' ''                               TO_STRING(objRow("FHINMEI_CD")), _
                '' ''                               TO_STRING(objRow("XDPL_PL_PTN")), _
                '' ''                               TO_STRING(objRow("FEQ_STS_02")), _
                '' ''                               TO_STRING(objRow("FEQ_STS_03")), _
                '' ''                               TO_STRING(objRow("START_DT")), _
                '' ''                               TO_STRING(objRow("END_DT")), _
                '' ''                               TO_STRING(objRow("KADOU_DT")), _
                '' ''                               TO_STRING(objRow("FEQ_STS_11")), _
                '' ''                              )
                If TO_STRING(objRow("FHINMEI_CD_02")) <> "" Then
                    objDataTable.userAddRowDataSet( _
                                                   TO_STRING(objRow("XDPL_PL_NO")), _
                                                   TO_STRING(objRow("XDPL_PL_NAME")), _
                                                   TO_STRING(objRow("XPROD_LINE")), _
                                                   TO_STRING(objRow("XDPL_PL_ONLINE")), _
                                                   TO_STRING(objRow("XDPL_PL_ONLINE_DSP")), _
                                                   TO_STRING(objRow("XDPL_PL_STS")), _
                                                   TO_STRING(objRow("XDPL_PL_STS_DSP")), _
                                                   TO_STRING(objRow("FEQ_STS_01")), _
                                                   TO_STRING(objRow("FEQ_STS_01_DSP")), _
                                                   TO_STRING(objRow("FHINMEI_CD_02")), _
                                                   TO_STRING(objRow("XDPL_PL_PTN")), _
                                                   TO_STRING(objRow("FEQ_STS_02")), _
                                                   TO_STRING(objRow("FEQ_STS_03")), _
                                                   TO_STRING(objRow("START_DT")), _
                                                   TO_STRING(objRow("END_DT")), _
                                                   TO_STRING(objRow("KADOU_DT")), _
                                                   TO_STRING(objRow("FEQ_STS_11")), _
                                                  )
                Else
                    objDataTable.userAddRowDataSet( _
                                                   TO_STRING(objRow("XDPL_PL_NO")), _
                                                   TO_STRING(objRow("XDPL_PL_NAME")), _
                                                   TO_STRING(objRow("XPROD_LINE")), _
                                                   TO_STRING(objRow("XDPL_PL_ONLINE")), _
                                                   TO_STRING(objRow("XDPL_PL_ONLINE_DSP")), _
                                                   TO_STRING(objRow("XDPL_PL_STS")), _
                                                   TO_STRING(objRow("XDPL_PL_STS_DSP")), _
                                                   TO_STRING(objRow("FEQ_STS_01")), _
                                                   TO_STRING(objRow("FEQ_STS_01_DSP")), _
                                                   TO_STRING(objRow("FHINMEI_CD_01")), _
                                                   TO_STRING(objRow("XDPL_PL_PTN")), _
                                                   TO_STRING(objRow("FEQ_STS_02")), _
                                                   TO_STRING(objRow("FEQ_STS_03")), _
                                                   TO_STRING(objRow("START_DT")), _
                                                   TO_STRING(objRow("END_DT")), _
                                                   TO_STRING(objRow("KADOU_DT")), _
                                                   TO_STRING(objRow("FEQ_STS_11")), _
                                                  )
                End If
                ii += 1
            Next
        End If


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示
        '********************************************************************
        Dim objPoint As Point           'ｸﾞﾘｯﾄﾞのｽｸﾛｰﾙ位置     記憶
        Dim intSelectRow As Integer     'ｸﾞﾘｯﾄﾞの選択行位置     記憶
        Dim intSelectCol As Integer     'ｸﾞﾘｯﾄﾞの選択列位置     記憶
        Call gobjComFuncFRM.GridDisplay(objDataTable, _
                         grdList, _
                         intSelectRow, _
                         intSelectCol, _
                         objPoint)
        objDataSet = Nothing


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdListSetup()


        '********************************************************************
        '「異常」文字色変更
        '********************************************************************
        For ii As Integer = 0 To grdList.RowCount - 1
            '(ﾙｰﾌﾟ:明細行分)
            'If (grdList.Item(menmListCol.XDPL_PL_ONLINE, grdList.Rows(ii).Index).Value = XDPL_PL_ONLINE_ON) Then
            '    '条件に合ったのでセルの色を変える
            '    grdList.Item(menmListCol.XDPL_PL_ONLINE_DSP, grdList.Rows(ii).Index).Style.BackColor = Color.Red
            'ElseIf (grdList.Item(menmListCol.XDPL_PL_ONLINE, grdList.Rows(ii).Index).Value = XDPL_PL_ONLINE_ERR) Then
            '    '条件に合ったのでセルの色を変える
            '    grdList.Item(menmListCol.XDPL_PL_ONLINE_DSP, grdList.Rows(ii).Index).Style.BackColor = Color.Red
            'Else
            '    '条件に合ったのでセルの色を変える
            '    grdList.Item(menmListCol.XDPL_PL_ONLINE_DSP, grdList.Rows(ii).Index).Style.BackColor = Color.Lime
            'End If

            'If (grdList.Item(menmListCol.XDPL_PL_STS, grdList.Rows(ii).Index).Value = XDPL_PL_STS_TEISI) Then       '終了
            '    '条件に合ったのでセルの色を変える
            '    grdList.Item(menmListCol.XDPL_PL_STS_DSP, grdList.Rows(ii).Index).Style.BackColor = Color.Lime
            'ElseIf (grdList.Item(menmListCol.XDPL_PL_STS, grdList.Rows(ii).Index).Value = XDPL_PL_STS_KANOU) Then   '起動可
            '    '条件に合ったのでセルの色を変える
            '    grdList.Item(menmListCol.XDPL_PL_STS_DSP, grdList.Rows(ii).Index).Style.BackColor = Color.Yellow
            'ElseIf (grdList.Item(menmListCol.XDPL_PL_STS, grdList.Rows(ii).Index).Value = XDPL_PL_STS_START) Then   '起動中
            '    '条件に合ったのでセルの色を変える
            '    grdList.Item(menmListCol.XDPL_PL_STS_DSP, grdList.Rows(ii).Index).Style.BackColor = Color.Yellow
            'ElseIf (grdList.Item(menmListCol.XDPL_PL_STS, grdList.Rows(ii).Index).Value = XDPL_PL_STS_KIDOU) Then   '起動
            '    '条件に合ったのでセルの色を変える
            '    grdList.Item(menmListCol.XDPL_PL_STS_DSP, grdList.Rows(ii).Index).Style.BackColor = Color.Red
            'ElseIf (grdList.Item(menmListCol.XDPL_PL_STS, grdList.Rows(ii).Index).Value = XDPL_PL_STS_YOKYU) Then   '終了中
            '    '条件に合ったのでセルの色を変える
            '    grdList.Item(menmListCol.XDPL_PL_STS_DSP, grdList.Rows(ii).Index).Style.BackColor = Color.Yellow
            'ElseIf (grdList.Item(menmListCol.XDPL_PL_STS, grdList.Rows(ii).Index).Value = XDPL_PL_STS_CLEAR) Then   'ｸﾘｱ中
            '    '条件に合ったのでセルの色を変える
            '    grdList.Item(menmListCol.XDPL_PL_STS_DSP, grdList.Rows(ii).Index).Style.BackColor = Color.Yellow
            'ElseIf (grdList.Item(menmListCol.XDPL_PL_STS, grdList.Rows(ii).Index).Value = XDPL_PL_STS_CLRED) Then   'ｸﾘｱ完
            '    '条件に合ったのでセルの色を変える
            '    grdList.Item(menmListCol.XDPL_PL_STS_DSP, grdList.Rows(ii).Index).Style.BackColor = Color.Yellow
            'ElseIf (grdList.Item(menmListCol.XDPL_PL_STS, grdList.Rows(ii).Index).Value = XDPL_PL_STS_ERROR) Then   '異常
            '    '条件に合ったのでセルの色を変える
            '    grdList.Item(menmListCol.XDPL_PL_STS_DSP, grdList.Rows(ii).Index).Style.BackColor = Color.Red
            'ElseIf (grdList.Item(menmListCol.XDPL_PL_STS, grdList.Rows(ii).Index).Value = XDPL_PL_STS_CHUYK) Then   '停止中
            '    '条件に合ったのでセルの色を変える
            '    grdList.Item(menmListCol.XDPL_PL_STS_DSP, grdList.Rows(ii).Index).Style.BackColor = Color.Yellow
            'ElseIf (grdList.Item(menmListCol.XDPL_PL_STS, grdList.Rows(ii).Index).Value = XDPL_PL_STS_CHUDN) Then   '停止
            '    '条件に合ったのでセルの色を変える
            '    grdList.Item(menmListCol.XDPL_PL_STS_DSP, grdList.Rows(ii).Index).Style.BackColor = Color.Lime
            'Else                                                                                                    'その他
            '    '条件に合ったのでセルの色を変える
            '    grdList.Item(menmListCol.XDPL_PL_STS_DSP, grdList.Rows(ii).Index).Style.BackColor = Color.White
            'End If

            'If (grdList.Item(menmListCol.FEQ_STS_01, grdList.Rows(ii).Index).Value = XDPL_PL_ONLINE_ON) Then
            '    '条件に合ったのでセルの色を変える
            '    grdList.Item(menmListCol.FEQ_STS_01_DSP, grdList.Rows(ii).Index).Style.BackColor = Color.Yellow
            'Else
            '    grdList.Item(menmListCol.FEQ_STS_01_DSP, grdList.Rows(ii).Index).Style.BackColor = Color.White
            'End If
            '' Lime Red 入替　2017/04/18 YAMAMOTO
            If (grdList.Item(menmListCol.XDPL_PL_ONLINE, grdList.Rows(ii).Index).Value = XDPL_PL_ONLINE_ON) Then
                '条件に合ったのでセルの色を変える
                grdList.Item(menmListCol.XDPL_PL_ONLINE_DSP, grdList.Rows(ii).Index).Style.BackColor = Color.Lime
            ElseIf (grdList.Item(menmListCol.XDPL_PL_ONLINE, grdList.Rows(ii).Index).Value = XDPL_PL_ONLINE_ERR) Then
                '条件に合ったのでセルの色を変える
                grdList.Item(menmListCol.XDPL_PL_ONLINE_DSP, grdList.Rows(ii).Index).Style.BackColor = Color.Lime
            Else
                '条件に合ったのでセルの色を変える
                grdList.Item(menmListCol.XDPL_PL_ONLINE_DSP, grdList.Rows(ii).Index).Style.BackColor = Color.Red
            End If

            If (grdList.Item(menmListCol.XDPL_PL_STS, grdList.Rows(ii).Index).Value = XDPL_PL_STS_TEISI) Then       '終了
                '条件に合ったのでセルの色を変える
                grdList.Item(menmListCol.XDPL_PL_STS_DSP, grdList.Rows(ii).Index).Style.BackColor = Color.Red
            ElseIf (grdList.Item(menmListCol.XDPL_PL_STS, grdList.Rows(ii).Index).Value = XDPL_PL_STS_KANOU) Then   '起動可
                '条件に合ったのでセルの色を変える
                grdList.Item(menmListCol.XDPL_PL_STS_DSP, grdList.Rows(ii).Index).Style.BackColor = Color.Yellow
            ElseIf (grdList.Item(menmListCol.XDPL_PL_STS, grdList.Rows(ii).Index).Value = XDPL_PL_STS_START) Then   '起動中
                '条件に合ったのでセルの色を変える
                grdList.Item(menmListCol.XDPL_PL_STS_DSP, grdList.Rows(ii).Index).Style.BackColor = Color.Yellow
            ElseIf (grdList.Item(menmListCol.XDPL_PL_STS, grdList.Rows(ii).Index).Value = XDPL_PL_STS_KIDOU) Then   '起動
                '条件に合ったのでセルの色を変える
                grdList.Item(menmListCol.XDPL_PL_STS_DSP, grdList.Rows(ii).Index).Style.BackColor = Color.Lime
            ElseIf (grdList.Item(menmListCol.XDPL_PL_STS, grdList.Rows(ii).Index).Value = XDPL_PL_STS_YOKYU) Then   '終了中
                '条件に合ったのでセルの色を変える
                grdList.Item(menmListCol.XDPL_PL_STS_DSP, grdList.Rows(ii).Index).Style.BackColor = Color.Yellow
            ElseIf (grdList.Item(menmListCol.XDPL_PL_STS, grdList.Rows(ii).Index).Value = XDPL_PL_STS_CLEAR) Then   'ｸﾘｱ中
                '条件に合ったのでセルの色を変える
                grdList.Item(menmListCol.XDPL_PL_STS_DSP, grdList.Rows(ii).Index).Style.BackColor = Color.Yellow
            ElseIf (grdList.Item(menmListCol.XDPL_PL_STS, grdList.Rows(ii).Index).Value = XDPL_PL_STS_CLRED) Then   'ｸﾘｱ完
                '条件に合ったのでセルの色を変える
                grdList.Item(menmListCol.XDPL_PL_STS_DSP, grdList.Rows(ii).Index).Style.BackColor = Color.Yellow
            ElseIf (grdList.Item(menmListCol.XDPL_PL_STS, grdList.Rows(ii).Index).Value = XDPL_PL_STS_ERROR) Then   '異常
                '条件に合ったのでセルの色を変える
                grdList.Item(menmListCol.XDPL_PL_STS_DSP, grdList.Rows(ii).Index).Style.BackColor = Color.Lime
            ElseIf (grdList.Item(menmListCol.XDPL_PL_STS, grdList.Rows(ii).Index).Value = XDPL_PL_STS_CHUYK) Then   '停止中
                '条件に合ったのでセルの色を変える
                grdList.Item(menmListCol.XDPL_PL_STS_DSP, grdList.Rows(ii).Index).Style.BackColor = Color.Yellow
            ElseIf (grdList.Item(menmListCol.XDPL_PL_STS, grdList.Rows(ii).Index).Value = XDPL_PL_STS_CHUDN) Then   '停止
                '条件に合ったのでセルの色を変える
                grdList.Item(menmListCol.XDPL_PL_STS_DSP, grdList.Rows(ii).Index).Style.BackColor = Color.Red
            Else                                                                                                    'その他
                '条件に合ったのでセルの色を変える
                grdList.Item(menmListCol.XDPL_PL_STS_DSP, grdList.Rows(ii).Index).Style.BackColor = Color.White
            End If

            If (grdList.Item(menmListCol.FEQ_STS_01, grdList.Rows(ii).Index).Value = XDPL_PL_ONLINE_ON) Then
                '条件に合ったのでセルの色を変える
                grdList.Item(menmListCol.FEQ_STS_01_DSP, grdList.Rows(ii).Index).Style.BackColor = Color.Yellow
            Else
                grdList.Item(menmListCol.FEQ_STS_01_DSP, grdList.Rows(ii).Index).Style.BackColor = Color.White
            End If
        Next


        '********************************************************************
        'ｸﾞﾘｯﾄﾞ選択
        '********************************************************************
        grdList.HorizontalScrollingOffset = objPoint.X               'ｽｸﾛｰﾙﾊﾞｰ位置　横
        If 0 <= objPoint.Y Then
            grdList.FirstDisplayedScrollingRowIndex = objPoint.Y     'ｽｸﾛｰﾙﾊﾞｰ位置　縦
        End If
        Call gobjComFuncFRM.GridSelect(grdList, intSelectRow, intSelectCol, objPoint)      'ｸﾞﾘｯﾄﾞ選択処理


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

        'grdList.Columns(menmListCol.DENBUN).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill   '列幅自動調整


    End Sub
#End Region
#Region "  定周期表示ﾀｲﾏｰ処理                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 定周期表示ﾀｲﾏｰ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tmr302010_TickProcess()


        '*********************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '*********************************************
        Call grdListDisplaySub(grdList)

        '**********************************************************
        ' ﾀｲﾏｰ設定
        '**********************************************************
        tmr302010.Enabled = False
        tmr302010.Interval = TO_INTEGER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_JGS302010_001))
        tmr302010.Enabled = True


    End Sub
#End Region
End Class
