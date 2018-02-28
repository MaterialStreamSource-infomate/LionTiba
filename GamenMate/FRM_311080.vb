'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑJOB固有機能
' 【機能】ﾛｰﾀﾞﾊﾞｰｽﾓﾆﾀ画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_311080
#Region "　共通変数　                           "

    Private mFlag_Form_Load As Boolean = True           '画面展開ﾌﾗｸﾞ

    Private mintBERTH_COUNT As Integer = 6              'ﾊﾞｰｽNoのｶｳﾝﾄ用定数

    Private mSTRFRONT_SYARYOU(mintBERTH_COUNT) As String    '音声用の比較後のﾃﾞｰﾀ
    Private mSTRBERTH_NO(mintBERTH_COUNT) As String         '音声用ﾊﾞｰｽﾅﾝﾊﾞｰ
    Private mDTMSYUKKA_D(mintBERTH_COUNT) As Date           '音声用の比較　　ﾊﾞｰｽNo
    Private mSTRHENSEI_NO(mintBERTH_COUNT) As String        '音声用の比較　　編成No

    'ｸﾞﾘｯﾄﾞ項目
    Enum menmBerthListCol
        XBERTH_NO             'ﾊﾞｰｽ
        XSTS_CONVEYOR         'ｺﾝﾍﾞﾔﾓｰﾄﾞ
        XSYARYOU_NO           '車輌No.
        XHENSEI_NO_OYA        '親編成No.
        XHENSEI_NO1           '編成No.1
        XHENSEI_NO2           '編成No.2
        XHENSEI_NO3           '編成No.3
        XHENSEI_NO4           '編成No.4
        XTUMI_HOUHOU          '積込方法
        XTUMI_HOUKOU          '積込方向
        XOUT_START_DT         '出庫開始日時
        ZAN_PL                '残PL

        SYUKKO_PL             '出庫中PL
        HANSOU_PL             '搬送中PL

        XSYUKKA_STS           '出荷状況
        XSYUKKA_D             '出荷日
        FEQ_CUT_STS           '切離
        FEQ_ID                '設備ID

        DATA18                '未使用
        DATA19                '未使用
        DATA20                '未使用

        MAXCOL

    End Enum

    Enum menmWaitListCol
        XSYARYOU_NO           '車輌No.
        XBERTH_SET            'ﾊﾞｰｽ指定
        XTUMI_HOUKOU          '積込方向
        XSYUKKA_D             '出荷日
        XHENSEI_NO_OYA        '親編成No.
        DATA05                  '未使用

        MAXCOL
    End Enum



    ''' <summary>ﾁｪｯｸ用列挙体</summary>
    Enum menmCheckCase
        BerthONBtn_Click         'ﾊﾞｰｽ有効ﾎﾞﾀﾝｸﾘｯｸ時
        BerthOFFBtn_Click        'ﾊﾞｰｽ無効ﾎﾞﾀﾝｸﾘｯｸ時
        STSSyousaiBtn_Click      '状況詳細ﾎﾞﾀﾝｸﾘｯｸ時
        YuusenBtn_Click          '優先設定ﾎﾞﾀﾝｸﾘｯｸ時
    End Enum

#End Region

#Region "  ｲﾍﾞﾝﾄ                                    "
#Region "　ｸﾞﾘｯﾄﾞ ﾛｰﾀﾞﾊﾞｰｽ     選択変更ｲﾍﾞﾝﾄ　      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ ﾛｰﾀﾞﾊﾞｰｽ 選択変更ｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdList_Berth_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdList_Berth.SelectionChanged
        Try
            If mFlag_Form_Load = False Then

                '****************************************
                ' ｸﾞﾘｯﾄﾞ ﾊﾞｰｽ 選択変更処理
                '****************************************
                Call grdListChangeColor_Selection(grdList_Berth)

            End If

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ 待ち車輌     選択変更ｲﾍﾞﾝﾄ　      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ 待ち車輌 選択変更ｲﾍﾞﾝﾄ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdList_Wait_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdList_Wait.SelectionChanged
        Try
            If mFlag_Form_Load = False Then

                '****************************************
                ' ｸﾞﾘｯﾄﾞ ﾊﾟﾚｯﾄ積み待ち車輌 選択変更処理
                '****************************************
                Call grdListChangeColor_Selection(grdList_Wait)

            End If

        Catch ex As Exception
            ComError(ex)

        End Try
    End Sub
#End Region
#Region "　ﾀｲﾏｰ 表示更新                            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾀｲﾏｰ 表示更新
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tmr311080_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr311080.Tick
        Try

            tmr311080.Enabled = False


            '**************************************************
            ' 表示更新ﾀｲﾏｰ処理
            '**************************************************
            Call tmr311080_TickProcess()


        Catch ex As Exception
            ComError(ex)
        Finally
            tmr311080.Enabled = True

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

        '*********************************************
        ' ｸﾞﾘｯﾄﾞ初期化
        '*********************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList_Berth, 1, menmBerthListCol.MAXCOL)  'ｸﾞﾘｯﾄﾞ初期設定
        grdListDisplay_Berth()

        Call gobjComFuncFRM.FlexGridInitialize(grdList_Wait, 1, menmWaitListCol.MAXCOL)
        grdListDisplay_Wait()

        Call grdList_Berth.ClearSelection()
        Call grdList_Wait.ClearSelection()

        tmr311080.Interval = TO_INTEGER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_JGS311080_001))
        tmr311080.Enabled = True

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
        grdList_Berth.Dispose()
        grdList_Wait.Dispose()

    End Sub
#End Region
#Region "  F1(ﾊﾞｰｽ復帰)         ﾎﾞﾀﾝ押下処理　      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F1ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F1Process()

        tmr311080.Enabled = False

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.BerthONBtn_Click) = False Then
            tmr311080.Enabled = True
            Exit Sub
        End If

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        Dim strMessage As String
        strMessage = ""
        strMessage &= "選択されたバースを有効にしますか？"
        udtRet = gobjComFuncFRM.DisplayPopup(strMessage, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            tmr311080.Enabled = True
            Exit Sub
        End If

        '**********************************************************
        ' ｿｹｯﾄ送信
        '**********************************************************
        Call SendSock_200201(FORMAT_DSP_CUTOFF_DSPDIR_KUBUN_CUT_OFF)

        '**********************************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '**********************************************************
        Call tmr311080_TickProcess()
        tmr311080.Enabled = True

    End Sub
#End Region
#Region "  F2(ﾊﾞｰｽ切離し)       ﾎﾞﾀﾝ押下処理　      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F2ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F2Process()

        tmr311080.Enabled = False

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.BerthOFFBtn_Click) = False Then
            tmr311080.Enabled = True
            Exit Sub
        End If

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        Dim strMessage As String
        strMessage = ""
        strMessage &= "選択されたバースを無効にしますか？"
        udtRet = gobjComFuncFRM.DisplayPopup(strMessage, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            tmr311080.Enabled = True
            Exit Sub
        End If

        '**********************************************************
        ' ｿｹｯﾄ送信
        '**********************************************************
        Call SendSock_200201(FORMAT_DSP_CUTOFF_DSPDIR_KUBUN_CUT_ON)

        '**********************************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '**********************************************************
        Call tmr311080_TickProcess()
        tmr311080.Enabled = True

    End Sub
#End Region
#Region "  F3(状況詳細)         ﾎﾞﾀﾝ押下処理　      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F3ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F3Process()

        tmr311080.Enabled = False

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.STSSyousaiBtn_Click) = False Then
            tmr311080.Enabled = True
            Exit Sub
        End If

        '************************************
        ' ﾌﾟﾛﾊﾟﾃｨｾｯﾄ
        '************************************
        If IsNull(gobjFRM_311050) = False Then
            gobjFRM_311050.Close()
            gobjFRM_311050.Dispose()
            gobjFRM_311050 = Nothing
        End If
        gobjFRM_311050 = New FRM_311050
        Call SetProperty()                   'ﾌﾟﾛﾊﾟﾃｨｾｯﾄ

        Dim intRet As DialogResult
        intRet = gobjFRM_311050.ShowDialog()            '展開
        ' ''If intRet = System.Windows.Forms.DialogResult.Cancel = True Then
        ' ''    '(ｷｬﾝｾﾙ時)
        ' ''    tmr311080.Enabled = True
        ' ''    Exit Sub
        ' ''End If

        '**********************************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '**********************************************************
        Call tmr311080_TickProcess()
        tmr311080.Enabled = True

    End Sub
#End Region
#Region "  F4(優先設定)         ﾎﾞﾀﾝ押下処理　      "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F4ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F4Process()

        tmr311080.Enabled = False

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.YuusenBtn_Click) = False Then
            tmr311080.Enabled = True
            Exit Sub
        End If

        '*******************************************************
        '優先設定
        '*******************************************************
        Call SendSock_400104()

        '**********************************************************
        ' ｸﾞﾘｯﾄﾞ表示
        '**********************************************************
        Call tmr311080_TickProcess()
        tmr311080.Enabled = True

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
            Case menmCheckCase.BerthONBtn_Click
                '(ﾊﾞｰｽ復帰ﾎﾞﾀﾝｸﾘｯｸ時)

                'ｴﾘｱ選択ﾁｪｯｸ
                If grdList_Berth.SelectedRows.Count < 1 Then

                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_GRD_LIST, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If

                blnCheckErr = False


            Case menmCheckCase.BerthOFFBtn_Click
                '(ﾊﾞｰｽ切離しﾎﾞﾀﾝｸﾘｯｸ時)

                'ｴﾘｱ選択ﾁｪｯｸ
                If grdList_Berth.SelectedRows.Count < 1 Then

                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_GRD_LIST, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If

                blnCheckErr = False

            Case menmCheckCase.STSSyousaiBtn_Click
                '(状況詳細ﾎﾞﾀﾝｸﾘｯｸ時)

                'ｴﾘｱ選択ﾁｪｯｸ
                If grdList_Berth.SelectedRows.Count < 1 Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_GRD_LIST, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select
                End If

                blnCheckErr = False

            Case menmCheckCase.YuusenBtn_Click
                '(優先設定ﾎﾞﾀﾝｸﾘｯｸ時)

                'ｴﾘｱ選択ﾁｪｯｸ
                If grdList_Wait.SelectedRows.Count < 1 Then

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

#Region "　ｸﾞﾘｯﾄﾞ表示(ﾛｰﾀﾞﾊﾞｰｽ)　                   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示(ﾛｰﾀﾞﾊﾞｰｽ)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListDisplay_Berth()

        Dim strSQL As String                            'SQL文
        Dim objRow As DataRow                           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim strDataSetName As String                    'ﾃﾞｰﾀｾｯﾄ名
        Dim objDataSet As New DataSet                   'ﾃﾞｰﾀｾｯﾄ（ﾃﾞｰﾀ取得用）

        Dim objDataTable As New GamenCommon.clsGridDataTable20      'ｸﾞﾘｯﾄﾞ用ﾃﾞｰﾀﾃｰﾌﾞﾙ

        '============================================================
        'SELECT 出荷ﾊﾞｰｽ状況
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    XSTS_BERTH.XBERTH_NO XBERTH_NO"                  '出荷ﾊﾞｰｽ状況.  ﾊﾞｰｽNo.
        strSQL &= vbCrLf & "  , XSTS_BERTH.XBERTH_GROUP "                        '出荷ﾊﾞｰｽ状況.  ﾊﾞｰｽｸﾞﾙｰﾌﾟ
        strSQL &= vbCrLf & "  , XSTS_BERTH.XSYUKKA_D XSYUKKA_D"                  '出荷ﾊﾞｰｽ状況.  出荷日時
        strSQL &= vbCrLf & "  , XSTS_BERTH.XSYUKKA_D XSYUKKA_D"                  '出荷ﾊﾞｰｽ状況.  出荷日時
        strSQL &= vbCrLf & "  , XSTS_BERTH.XHENSEI_NO XHENSEI_NO"                '出荷ﾊﾞｰｽ状況.  編成No.
        strSQL &= vbCrLf & "  , XSTS_BERTH.XBERTH_STS XBERTH_STS"                '出荷ﾊﾞｰｽ状況.  ﾊﾞｰｽ指示状況
        strSQL &= vbCrLf & "  , XSTS_BERTH.FEQ_ID FEQ_ID"                        '出荷ﾊﾞｰｽ状況.  設備ID
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    XSTS_BERTH "                                     '【出荷ﾊﾞｰｽ状況】

        '============================================================
        'WHERE
        '============================================================
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "    XSTS_BERTH.XBERTH_NO LIKE 'X%' "

        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & " ORDER BY  "
        strSQL &= vbCrLf & "    XSTS_BERTH.XBERTH_NO"                              '出荷ﾊﾞｰｽ状況.      ﾊﾞｰｽNo

        '-----------------------
        '抽出
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "XSTS_BERTH"
        gobjDb.GetDataSet(strDataSetName, objDataSet)

        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows

                '********************************************************************
                ' ﾃﾞｰﾀ取得
                '********************************************************************
                Dim strXBERTH_NO As String = ""         'ﾊﾞｰｽNo.
                Dim strXBERTH_GROUP As String = ""      'ﾊﾞｰｽｸﾞﾙｰﾌﾟ
                Dim strXBERTH_YOUTO As String = ""      'ｺﾝﾍﾞﾔ用途
                Dim strXSYUKKA_D As String = ""         '出荷日
                Dim strXHENSEI_NO_OYA As String = ""    '親編成No.
                Dim strXBERTH_STS As String = ""        'ﾊﾞｰｽ指示状況

                Dim strXSYARYOU_NO As String = ""               '車輌No.
                Dim strXTUMI_HOUHOU As String = ""              '積込方法
                Dim strXTUMI_HOUKOU As String = ""              '積込方向
                Dim datXOUT_START_DT As New Date(0)             '出庫開始時間
                Dim strXOUT_START_DT As String = ""             '同上
                Dim strXSYUKKA_STS As String = ""               '出荷状況
                Dim strPLCount As String = ""                   '残PL数
                Dim strSYUKKO As String = ""                    '出庫中PL数
                Dim strHANSOUTYUU As String = ""                '搬送中PL数
                Dim strXHENSEI_NO(3) As String                  '編成No.

                strXBERTH_NO = TO_STRING(objRow("XBERTH_NO"))       'ﾊﾞｰｽNo.

                'ｺﾝﾍﾞﾔ用途の取得
                strXBERTH_GROUP = TO_STRING(objRow("XBERTH_GROUP"))
                strXBERTH_YOUTO = gobjComFuncFRM.GetXCONVEYOR_YOUTO(strXBERTH_GROUP)

                strXSYUKKA_D = TO_STRING(objRow("XSYUKKA_D"))       '出荷日
                strXHENSEI_NO_OYA = TO_STRING(objRow("XHENSEI_NO")) '親編成No.
                strXBERTH_STS = TO_STRING(objRow("XBERTH_STS"))     'ﾊﾞｰｽ指示状況

                Select Case TO_INTEGER(strXBERTH_STS)
                    ' ''Case XBERTH_STS_JSESSYA
                    ' ''    'ﾊﾞｰｽ使用状況が1:「接車」の場合
                    ' ''    strXSYARYOU_NO = TO_STRING(objRow2("XSYARYOU_NO"))
                    ' ''    strXTUMI_HOUHOU = TO_STRING(objRow2("XTUMI_HOUHOU"))
                    ' ''    strXTUMI_HOUKOU = TO_STRING(objRow2("XTUMI_HOUKOU"))
                    ' ''    datXOUT_START_DT = TO_DATE(objRow2("XOUT_START_DT"))

                    ' ''    If datXOUT_START_DT <> New Date(0) Then
                    ' ''        strXOUT_START_DT = Format(datXOUT_START_DT, GAMEN_TIME_FORMAT_01)
                    ' ''    End If

                    Case XBERTH_STS_JUP, XBERTH_STS_JDOWN, XBERTH_STS_JUPDOWN
                        'ﾊﾞｰｽ使用状況が2:「↑」,3:「↓」,4:「↑↓」の場合
                        '各ｽﾃｰﾀｽを変換（2:「↑↑↑」,3:「↓↓↓」,4:「↑↑↑↓↓↓」）
                        Dim objTBL_TDSP_DISP As New TBL_TDSP_DISP(gobjOwner, gobjDb, Nothing)
                        objTBL_TDSP_DISP.FTABLE_NAME = "XSTS_BERTH"
                        objTBL_TDSP_DISP.FFIELD_NAME = "XBERTH_STS"
                        objTBL_TDSP_DISP.FDISP_VALUE = TO_STRING(strXBERTH_STS)
                        objTBL_TDSP_DISP.GET_TDSP_DISP()                                        '情報取得

                        strXSYARYOU_NO = objTBL_TDSP_DISP.FGAMEN_DISP
                End Select

                '============================================================
                ' 出荷指示 取得
                '============================================================
                If strXSYUKKA_D <> "" And _
                    strXHENSEI_NO_OYA <> "" Then
                    '(出荷日と編成No.が設定されている場合)

                    Dim strSQL2 As String                           'SQL文
                    Dim objRow2 As DataRow                          '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
                    Dim strDataSetName2 As String                   'ﾃﾞｰﾀｾｯﾄ名
                    Dim objDataSet2 As New DataSet                  'ﾃﾞｰﾀｾｯﾄ（ﾃﾞｰﾀ取得用）

                    '============================================================
                    'SELECT 出荷指示
                    '============================================================
                    strSQL2 = ""
                    strSQL2 &= vbCrLf & "SELECT "
                    strSQL2 &= vbCrLf & "    XPLN_OUT.XSYARYOU_NO XSYARYOU_NO"                '出荷指示.  車輌No.
                    strSQL2 &= vbCrLf & "  , XPLN_OUT.XTUMI_HOUHOU XTUMI_HOUHOU"              '出荷指示.  積込方法
                    strSQL2 &= vbCrLf & "  , XPLN_OUT.XTUMI_HOUKOU XTUMI_HOUKOU"              '出荷指示.  積込方向
                    strSQL2 &= vbCrLf & "  , XPLN_OUT.XOUT_START_DT XOUT_START_DT"            '出荷指示.  出庫開始日時
                    strSQL2 &= vbCrLf & "  , XPLN_OUT.XSYUKKA_STS XSYUKKA_STS"                '出荷指示.  出荷状況
                    strSQL2 &= vbCrLf & "  , XPLN_OUT.XHENSEI_NO_OYA XHENSEI_NO_OYA"          '出荷指示.  親編成No.
                    strSQL2 &= vbCrLf & "  , XPLN_OUT.XHENSEI_NO XHENSEI_NO"                  '出荷指示.  編成No.

                    strSQL2 &= vbCrLf & " FROM "
                    strSQL2 &= vbCrLf & "    XPLN_OUT "                                       '【出荷指示】

                    '============================================================
                    'WHERE
                    '============================================================
                    strSQL2 &= vbCrLf & " WHERE "
                    strSQL2 &= vbCrLf & "        XPLN_OUT.XHENSEI_NO_OYA = '" & strXHENSEI_NO_OYA & "' "    '親編成No.
                    strSQL2 &= vbCrLf & "    AND XPLN_OUT.XSYUKKA_D = '" & strXSYUKKA_D & "' "              '出荷日

                    '============================================================
                    'ORDER BY
                    '============================================================
                    strSQL2 &= vbCrLf & " ORDER BY  "
                    strSQL2 &= vbCrLf & "    XPLN_OUT.XBERTH_NO"                              '出荷ﾊﾞｰｽ状況.      ﾊﾞｰｽNo

                    '-----------------------
                    '抽出
                    '-----------------------
                    gobjDb.SQL = strSQL2
                    objDataSet2.Clear()
                    strDataSetName2 = "XPLN_OUT"
                    gobjDb.GetDataSet(strDataSetName2, objDataSet2)

                    If objDataSet2.Tables(strDataSetName2).Rows.Count > 0 Then
                        '(1件目の共通ﾃﾞｰﾀを取得)
                        objRow2 = objDataSet2.Tables(strDataSetName2).Rows(0)

                        Select Case TO_INTEGER(strXBERTH_STS)
                            Case XBERTH_STS_JSESSYA
                                'ﾊﾞｰｽ使用状況が1:「接車」の場合
                                strXSYARYOU_NO = TO_STRING(objRow2("XSYARYOU_NO"))
                                strXTUMI_HOUHOU = TO_STRING(objRow2("XTUMI_HOUHOU"))

                                Select Case TO_STRING(objRow2("XTUMI_HOUKOU"))
                                    Case TO_STRING(XTUMI_HOUKOU_JBACK)
                                        strXTUMI_HOUKOU = "後積"
                                    Case TO_STRING(XTUMI_HOUKOU_JSIDE)
                                        strXTUMI_HOUKOU = "片横積"
                                    Case TO_STRING(XTUMI_HOUKOU_JWING)
                                        strXTUMI_HOUKOU = "両横積"
                                    Case TO_STRING(XTUMI_HOUKOU_JALL)
                                        strXTUMI_HOUKOU = "ALL"
                                End Select

                                datXOUT_START_DT = TO_DATE(objRow2("XOUT_START_DT"))
                                If datXOUT_START_DT <> New Date(0) Then
                                    strXOUT_START_DT = Format(datXOUT_START_DT, GAMEN_TIME_FORMAT_02)
                                End If

                                ' ''Case XBERTH_STS_JUP, XBERTH_STS_JDOWN, XBERTH_STS_JUPDOWN
                                ' ''    'ﾊﾞｰｽ使用状況が2:「↑」,3:「↓」,4:「↑↓」の場合
                                ' ''    '各ｽﾃｰﾀｽを変換（2:「↑↑↑」,3:「↓↓↓」,4:「↑↑↑↓↓↓」）
                                ' ''    Dim objTBL_TDSP_DISP As New TBL_TDSP_DISP(gobjOwner, gobjDb, Nothing)
                                ' ''    objTBL_TDSP_DISP.FTABLE_NAME = "XSTS_BERTH"
                                ' ''    objTBL_TDSP_DISP.FFIELD_NAME = "XBERTH_STS"
                                ' ''    objTBL_TDSP_DISP.FDISP_VALUE = TO_STRING(strXBERTH_STS)
                                ' ''    objTBL_TDSP_DISP.GET_TDSP_DISP()                                        '情報取得

                                ' ''    strXSYARYOU_NO = objTBL_TDSP_DISP.FGAMEN_DISP
                        End Select

                        '出荷状況
                        If gobjComFuncFRM.BERTH_GetKeppin(strXBERTH_NO) = True Then
                            strXSYUKKA_STS = XSYUKKA_STS_JLESS
                        Else
                            strXSYUKKA_STS = TO_STRING(objRow2("XSYUKKA_STS"))
                        End If
                        'INTSYUKKA_STS = TO_STRING(objRow("INTSYUKKA_STS"))

                        '' ''ﾊﾞｰｽ切離取得
                        ' ''Dim objTBL_TSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(gobjOwner, gobjDb, Nothing)
                        ' ''If TO_STRING(objRow("FEQ_ID")) <> "" Then
                        ' ''    objTBL_TSTS_EQ_CTRL.FEQ_ID = TO_STRING(objRow("FEQ_ID"))
                        ' ''    objTBL_TSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()
                        ' ''End If

                        ' ﾊﾞｰｽ毎のPL数取得
                        strPLCount = TO_STRING(gobjComFuncFRM.BERTH_GetPLCount(strXBERTH_NO))
                        'If strPLCount = "0" Then
                        '    '(PL数が0の場合)
                        '    strPLCount = ""
                        'End If

                    End If

                    ' 編成No.の取得
                    strXHENSEI_NO = gobjComFuncFRM.BERTH_GetHENSEI_NO(strXBERTH_NO)

                    ' 出庫中PLの取得
                    strSYUKKO = TO_STRING(gobjComFuncFRM.COUNT_SYUKKO(strXBERTH_NO))

                    ' 搬送中PLの取得
                    strHANSOUTYUU = TO_STRING(gobjComFuncFRM.COUNT_HANSOUTYUU(strXBERTH_NO))

                End If

                '============================================================
                ' 設備状態 取得
                '============================================================
                Dim objTBL_TSTS_EQ_CTRL As New TBL_TSTS_EQ_CTRL(gobjOwner, gobjDb, Nothing)
                objTBL_TSTS_EQ_CTRL.FEQ_ID = strXBERTH_NO
                objTBL_TSTS_EQ_CTRL.GET_TSTS_EQ_CTRL()

                '********************************************************************
                ' ｸﾞﾘｯﾄﾞ表示用ﾃﾞｰﾀｾｯﾄﾃｰﾌﾞﾙに追加
                '********************************************************************
                objDataTable.userAddRowDataSet(strXBERTH_NO, _
                                               strXBERTH_YOUTO, _
                                               strXSYARYOU_NO, _
                                               strXHENSEI_NO_OYA, _
                                               strXHENSEI_NO(0), _
                                               strXHENSEI_NO(1), _
                                               strXHENSEI_NO(2), _
                                               strXHENSEI_NO(3), _
                                               strXTUMI_HOUHOU, _
                                               strXTUMI_HOUKOU, _
                                               strXOUT_START_DT, _
                                               strPLCount, _
                                               strSYUKKO, _
                                               strHANSOUTYUU, _
                                               strXSYUKKA_STS, _
                                               TO_DATE(objRow("XSYUKKA_D")), _
                                               objTBL_TSTS_EQ_CTRL.FEQ_CUT_STS, _
                                               objTBL_TSTS_EQ_CTRL.FEQ_ID _
                                               )

                '' ''============================================================
                '' ''音声合成用前回ﾃﾞｰﾀ取得
                '' ''============================================================
                ' ''mSTRFRONT_SYARYOU(ii) = TO_STRING(objRow("XSYARYOU_NO"))
                ' ''mSTRBERTH_NO(ii) = TO_STRING(objRow("XBERTH_NO"))
                ' ''mDTMSYUKKA_D(ii) = TO_DATE(objRow("XSYUKKA_D"))              '音声合成の比較用　　出荷日No
                ' ''mSTRHENSEI_NO(ii) = TO_STRING(objRow("XHENSEI_NO"))          '音声合成の比較用　　編成No
            Next
        End If

        '********************************************************************
        ' ｸﾞﾘｯﾄﾞへ出力
        '********************************************************************
        Call gobjComFuncFRM.GridDisplay(objDataTable, _
                         grdList_Berth, _
                         )
        objDataTable = Nothing
        objDataTable = New GamenCommon.clsGridDataTable20

        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdList_BerthSetup()                'ｸﾞﾘｯﾄﾞ表示設定

    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ表示設定(ﾛｰﾀﾞﾊﾞｰｽ)　               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示設定(ﾛｰﾀﾞﾊﾞｰｽ)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdList_BerthSetup()

        '************************************************
        'ｸﾞﾘｯﾄﾞﾏｽﾀの定義を反映
        '************************************************
        Call gobjComFuncFRM.TDSP_GRIDSetup(Me, grdList_Berth)

        '************************************************
        '色変更の確認
        '************************************************
        Dim i As Integer
        For i = 0 To grdList_Berth.RowCount - 1
            Dim strXSYUKKA_STS As String
            strXSYUKKA_STS = grdList_Berth.Item(menmBerthListCol.XSYUKKA_STS, i).FormattedValue()             '出荷状況

            If strXSYUKKA_STS = TO_STRING(XSYUKKA_STS_DTL_JLESS) Then
                '(欠品の場合)
                grdList_Berth.Item(menmBerthListCol.XSYARYOU_NO, i).Style.BackColor = Color.Red

            End If

            Dim strFEQ_CUT_STS As String
            strFEQ_CUT_STS = grdList_Berth.Item(menmBerthListCol.FEQ_CUT_STS, i).FormattedValue()             '設備切離し状況
            If strFEQ_CUT_STS = TO_STRING(FEQ_CUT_STS_SON) Then
                '(切離しの場合)
                grdList_Berth.Item(menmBerthListCol.XBERTH_NO, i).Style.BackColor = Color.Yellow

            End If

        Next

    End Sub
#End Region

#Region "  ｸﾞﾘｯﾄﾞ表示   (待ち車輌)                　"
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub grdListDisplay_Wait()

        Dim strSQL As String                            'SQL文
        Dim objRow As DataRow                           '1ﾚｺｰﾄﾞ分のﾃﾞｰﾀ
        Dim strDataSetName As String                    'ﾃﾞｰﾀｾｯﾄ名
        Dim objDataSet As New DataSet                   'ﾃﾞｰﾀｾｯﾄ（ﾃﾞｰﾀ取得用）

        Dim objDataTable As New GamenCommon.clsGridDataTable05()      'ｸﾞﾘｯﾄﾞ用ﾃﾞｰﾀﾃｰﾌﾞﾙ

        objDataTable.Clear()

        '********************************************************************
        ' SQL文作成
        '********************************************************************
        '============================================================
        'SELECT 出荷指示
        '============================================================
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    XPLN_OUT.XSYARYOU_NO XSYARYOU_NO"                '出荷指示.  車輌No.
        strSQL &= vbCrLf & "  , XPLN_OUT.XBERTH_NO XBERTH_NO"                    '出荷指示.  ﾊﾞｰｽNo.
        strSQL &= vbCrLf & "  , XPLN_OUT.XTUMI_HOUKOU XTUMI_HOUKOU"              '出荷指示.  積込方向
        strSQL &= vbCrLf & "  , XPLN_OUT.XSYUKKA_D XSYUKKA_D"                    '出荷指示.  出荷日
        strSQL &= vbCrLf & "  , XPLN_OUT.XHENSEI_NO_OYA XHENSEI_NO_OYA"          '出荷指示.  親編成No.
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    XPLN_OUT "                                           '【出荷指示】

        '============================================================
        'WHERE
        '============================================================
        '----------------------------
        'ﾃｰﾌﾞﾙ結合
        '----------------------------
        strSQL &= vbCrLf & " WHERE "
        strSQL &= vbCrLf & "        XPLN_OUT.XSYUKKA_STS = " & XSYUKKA_STS_JDIR & " "       '出荷指示.出荷状況 = 3(指示済)
        strSQL &= vbCrLf & "    AND XPLN_OUT.XHENSEI_NO = XPLN_OUT.XHENSEI_NO_OYA"          '出荷指示.編成No = 出荷指示.親編成No
        strSQL &= vbCrLf & "    AND XPLN_OUT.XTUMI_HOUHOU = " & XTUMI_HOUHOU_JL & " "       '出荷指示.積込方法 = 3(:ﾛｰﾀﾞ)

        '============================================================
        'ORDER BY
        '============================================================
        strSQL &= vbCrLf & " ORDER BY  "
        strSQL &= vbCrLf & "    XPLN_OUT.XKINKYU_LEVEL DESC"                                '出荷指示.緊急度 　　　     降順
        strSQL &= vbCrLf & "   ,XPLN_OUT.XSYUKKA_DIR_DT"                                    '出荷指示.出荷指示日時      昇順

        '-----------------------
        '抽出
        '-----------------------
        gobjDb.SQL = strSQL
        objDataSet.Clear()
        strDataSetName = "XPLN_OUT"
        gobjDb.GetDataSet(strDataSetName, objDataSet)
        If objDataSet.Tables(strDataSetName).Rows.Count > 0 Then
            For Each objRow In objDataSet.Tables(strDataSetName).Rows

                Dim XSYARYOU_NO As String = ""                    '車輌No
                Dim XBERTH_NO As String = ""                     'ﾊﾞｰｽ指定
                Dim XTUMI_HOUKOU As String = ""                   '積込方向
                Dim XSYUKKA_D As New Date(0)                      '出荷日
                Dim XHENSEI_NO_OYA As String = ""                 '親編成No


                XSYARYOU_NO = TO_STRING(objRow("XSYARYOU_NO"))
                If TO_STRING(objRow("XBERTH_NO")) = "0" Then
                    XBERTH_NO = ""
                Else
                    XBERTH_NO = TO_STRING(objRow("XBERTH_NO"))
                End If
                Select Case TO_STRING(objRow("XTUMI_HOUKOU"))
                    Case TO_STRING(XTUMI_HOUKOU_JBACK)
                        XTUMI_HOUKOU = "後積"
                    Case TO_STRING(XTUMI_HOUKOU_JSIDE)
                        XTUMI_HOUKOU = "片横積"
                    Case TO_STRING(XTUMI_HOUKOU_JWING)
                        XTUMI_HOUKOU = "両横積"
                    Case TO_STRING(XTUMI_HOUKOU_JALL)
                        XTUMI_HOUKOU = "ALL"
                End Select
                XSYUKKA_D = TO_DATE(objRow("XSYUKKA_D"))
                XHENSEI_NO_OYA = TO_STRING(objRow("XHENSEI_NO_OYA"))

                '-----------------------
                ' 重複車輌の確認
                '-----------------------
                Dim objRow2 As DataRow
                Dim blnFind As Boolean = False
                For Each objRow2 In objDataTable.Rows
                    If XSYARYOU_NO = TO_STRING(objRow2.Item(0)) And _
                      XSYUKKA_D = TO_STRING(objRow2.Item(3)) And _
                      XHENSEI_NO_OYA = TO_STRING(objRow2.Item(4)) Then
                        '(車輌番号、出荷日、親編成No.が一致した場合)
                        blnFind = True
                        Exit For
                    End If
                Next

                If blnFind = False Then
                    '(重複なしの場合)
                    objDataTable.userAddRowDataSet(XSYARYOU_NO, _
                                                   XBERTH_NO, _
                                                   XTUMI_HOUKOU, _
                                                   XSYUKKA_D, _
                                                   XHENSEI_NO_OYA)
                End If

            Next
        End If

        '********************************************************************
        ' ｸﾞﾘｯﾄﾞへ出力
        '********************************************************************
        Call gobjComFuncFRM.GridDisplay(objDataTable, _
                         grdList_Wait, _
                         )
        objDataTable = Nothing
        objDataTable = New GamenCommon.clsGridDataTable05

        '********************************************************************
        'ｸﾞﾘｯﾄﾞ表示設定
        '********************************************************************
        Call grdList_Wait_Setup()                                                                'ｸﾞﾘｯﾄﾞ表示設定
        'Call gobjComFuncFRM.GridSelect(grdList_Wait, intSelectRow, intSelectCol, objPoint)          'ｸﾞﾘｯﾄﾞ選択処理


    End Sub
#End Region
#Region "　ｸﾞﾘｯﾄﾞ表示設定(待ち車輌)　               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｸﾞﾘｯﾄﾞ表示設定(待ち車輌)
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdList_Wait_Setup()


        '************************************************
        'ｸﾞﾘｯﾄﾞﾏｽﾀの定義を反映
        '************************************************
        Call gobjComFuncFRM.TDSP_GRIDSetup(Me, grdList_Wait)

    End Sub
#End Region

#Region "  設備切離し           （ID : 200201）     "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub SendSock_200201(ByVal strCutSts As String)

        '*******************************************************
        '送信ﾃﾞｰﾀ
        '*******************************************************
        Dim strEQ_ID As String = ""          '出荷日
        strEQ_ID = TO_STRING(grdList_Berth.Item(menmBerthListCol.XBERTH_NO, grdList_Berth.SelectedRows(0).Index).Value)

        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200201      'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        objTelegram.SETIN_DATA("DSPEQ_ID", strEQ_ID)                    '設備ID
        objTelegram.SETIN_DATA("DSPEQ_CUT_STS", strCutSts)              '切離状態

        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode    'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String

        strErrMsg = ""
        udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)    'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)

            End If
        End If


    End Sub
#End Region
#Region "  優先設定受付         （ID : 400104）     "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Private Sub SendSock_400104()

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        Dim strMessage As String

        strMessage = ""
        strMessage += "選択した車輌を"
        strMessage += "優先としてよろしいですか？"
        udtRet = gobjComFuncFRM.DisplayPopup(strMessage, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Sub
        End If

        '*******************************************************
        '送信ﾃﾞｰﾀ
        '*******************************************************
        Dim strSYUKKA_D As String = ""          '出荷日
        Dim strHENSEI_NO_OYA As String = ""     '親編成No.

        strSYUKKA_D = TO_STRING(grdList_Wait.Item(menmWaitListCol.XSYUKKA_D, grdList_Wait.SelectedRows(0).Index).Value)
        strHENSEI_NO_OYA = TO_STRING(grdList_Wait.Item(menmWaitListCol.XHENSEI_NO_OYA, grdList_Wait.SelectedRows(0).Index).Value)

        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400104    'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        objTelegram.SETIN_DATA("XDSPSYUKKA_D", strSYUKKA_D)             '出荷日
        objTelegram.SETIN_DATA("XDSPHENSEI_NO_OYA", strHENSEI_NO_OYA)   '親編成No.

        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode    'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String

        strErrMsg = ""
        udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)    'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)

            End If
        End If


    End Sub
#End Region

#Region "  ﾌﾟﾛﾊﾟﾃｨｾｯﾄ(出荷中状況詳細画面)           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetProperty()

        gobjFRM_311050.userXBERTH_NO = TO_STRING(grdList_Berth.Item(menmBerthListCol.XBERTH_NO, grdList_Berth.SelectedRows(0).Index).Value)         'ﾊﾞｰｽNo.
        gobjFRM_311050.userXSYARYOU_NO = TO_STRING(grdList_Berth.Item(menmBerthListCol.XSYARYOU_NO, grdList_Berth.SelectedRows(0).Index).Value)     '車輌番号
        gobjFRM_311050.userXSYUKKA_D = TO_STRING(grdList_Berth.Item(menmBerthListCol.XSYUKKA_D, grdList_Berth.SelectedRows(0).Index).Value)         '出荷日
        gobjFRM_311050.userXHENSEI_NO_OYA = TO_STRING(grdList_Berth.Item(menmBerthListCol.XHENSEI_NO_OYA, grdList_Berth.SelectedRows(0).Index).Value)   '編成No.

    End Sub
#End Region

#Region "  選択変更時のｸﾞﾘｯﾄﾞ色変え                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 選択変更時のｸﾞﾘｯﾄﾞ色変え
    ''' </summary>
    ''' <param name="grdList"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListChangeColor_Selection(ByRef grdList As GamenCommon.cmpMDataGrid)

        If mFlag_Form_Load = True Then Exit Sub
        If grdList.SelectedRows.Count < 1 Then Exit Sub

        ' 選択されていない方の、選択状態を解除
        If grdList Is grdList_Berth Then
            Call grdList_Wait.ClearSelection()

        ElseIf grdList Is grdList_Wait Then
            Call grdList_Berth.ClearSelection()

        Else
            Call grdList_Berth.ClearSelection()
            Call grdList_Wait.ClearSelection()

        End If

    End Sub
#End Region

#Region "  表示更新ﾀｲﾏｰ処理                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 画面更新ﾀｲﾏｰ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tmr311080_TickProcess()


        '' ''********************************************************************
        '' '' 前回ﾃﾞｰﾀを記憶
        '' ''********************************************************************
        ' ''Dim DTMSYUKKA_D_before(mintBERTH_COUNT) As Date                             '音声の比較用　　出荷日
        ' ''Dim STRHENSEI_NO_before(mintBERTH_COUNT) As String                          '音声の比較用　　編成No
        ' ''Array.Copy(mDTMSYUKKA_D, DTMSYUKKA_D_before, mDTMSYUKKA_D.Length)           '音声の比較前後の出荷日
        ' ''Array.Copy(mSTRHENSEI_NO, STRHENSEI_NO_before, mSTRHENSEI_NO.Length)        '音声の比較前後の編成No

        '*******************************************
        '表示前のﾘｽﾄ選択記憶
        '*******************************************
        Dim objGrid As GamenCommon.cmpMDataGrid         '選択されたｸﾞﾘｯﾄﾞ       記憶
        Dim objPoint As Point                           'ｸﾞﾘｯﾄﾞのｽｸﾛｰﾙ位置      記憶
        Dim intSelectRow As Integer                     'ｸﾞﾘｯﾄﾞの選択行位置     記憶
        Dim intSelectCol As Integer                     'ｸﾞﾘｯﾄﾞの選択列位置     記憶

        If grdList_Berth.SelectedRows.Count > 0 Then
            '(ﾊﾞｰｽ)
            objGrid = grdList_Berth

        ElseIf grdList_Wait.SelectedRows.Count > 0 Then
            '(待ち)
            objGrid = grdList_Wait

        Else
            '(選択なし)
            objGrid = Nothing

        End If

        If Not objGrid Is Nothing Then
            objPoint.X = objGrid.HorizontalScrollingOffset          'ｽｸﾛｰﾙﾊﾞｰ位置　横
            objPoint.Y = objGrid.FirstDisplayedScrollingRowIndex    'ｽｸﾛｰﾙﾊﾞｰ位置　縦
            intSelectRow = objGrid.SelectedCells(0).RowIndex        'ﾘｽﾄの行
            intSelectCol = objGrid.SelectedCells(0).ColumnIndex     'ﾘｽﾄの列
        End If

        '**********************************************************
        ' 状態表示変更（ ｸﾞﾘｯﾄﾞ表示）
        '**********************************************************
        grdList_Berth.ScrollBars = ScrollBars.None
        grdList_Wait.ScrollBars = ScrollBars.None

        Call grdListDisplay_Berth()         'ﾊﾞｰｽ   状態
        Call grdListDisplay_Wait()          'ﾊﾞｰｽ   積み待ち車輌

        If Not objGrid Is Nothing Then
            '(選択あり)
            intSelectCol = 2
            Call gobjComFuncFRM.GridSelect(objGrid, intSelectRow, intSelectCol, objPoint)     'ｸﾞﾘｯﾄﾞ選択処理
        Else
            '(選択なし)
            Call grdList_Berth.ClearSelection()
            Call grdList_Wait.ClearSelection()
        End If

        grdList_Berth.ScrollBars = ScrollBars.Both
        grdList_Wait.ScrollBars = ScrollBars.Both

        '' ''********************************************************************
        '' '' 音声合成用のﾃﾞｰﾀの比較
        '' ''********************************************************************
        ' ''Dim strMSG As String = ""             '音声合成用ﾒｯｾｰｼﾞ

        ' ''For ii As Integer = LBound(mDTMSYUKKA_D) To UBound(mDTMSYUKKA_D)
        ' ''    '----------------------------------------------
        ' ''    '出荷日、編成Noが違っていた場合、
        ' ''    '音声案内を実行
        ' ''    '----------------------------------------------
        ' ''    If ( _
        ' ''       (mDTMSYUKKA_D(ii) <> DTMSYUKKA_D_before(ii)) _
        ' ''       Or (mSTRHENSEI_NO(ii) <> STRHENSEI_NO_before(ii)) _
        ' ''       ) _
        ' ''       And (mSTRHENSEI_NO(ii) <> "") Then

        ' ''        '-----------------------------------------
        ' ''        '車両ﾅﾝﾊﾞｰをゆっくり喋らす
        ' ''        '-----------------------------------------
        ' ''        Const strSpeakSpeed As String = "{T3}"      '喋るｽﾋﾟｰﾄﾞ
        ' ''        Const strCarNoSpeed As String = "{T0}"      '車両Noの喋るｽﾋﾟｰﾄﾞ
        ' ''        Dim STRFRONT_SYARYOU_Slow As String         '車両ﾅﾝﾊﾞｰをゆっくり喋らす文字列
        ' ''        STRFRONT_SYARYOU_Slow = strCarNoSpeed & mSTRFRONT_SYARYOU(ii)

        ' ''        Dim strSpeakHeader As String = "お待たせしました"       '最初の言葉
        ' ''        Select Case Val(Format(Now, "ss")) Mod 10
        ' ''            Case 1
        ' ''                'strSpeakHeader = "まいどおおきに"
        ' ''                strSpeakHeader = "お待たせしました"
        ' ''            Case 2
        ' ''                'strSpeakHeader = "まいどおおきに"
        ' ''                strSpeakHeader = "お待たせしました"
        ' ''            Case 3
        ' ''                'strSpeakHeader = "たばこの吸いすぎには注意しましょう"
        ' ''                strSpeakHeader = "お待たせしました"
        ' ''            Case 4
        ' ''                'strSpeakHeader = "いつもお世話になっております"
        ' ''                strSpeakHeader = "お待たせしました"
        ' ''            Case 5
        ' ''                'strSpeakHeader = "おつかれさまです"
        ' ''                strSpeakHeader = "今日もご安全に"
        ' ''            Case 6
        ' ''                'strSpeakHeader = "まいど、ごくろうさまです"
        ' ''                strSpeakHeader = "今日も安全運転でお願いします"
        ' ''            Case 7
        ' ''                strSpeakHeader = "今日もご安全に"
        ' ''            Case 8
        ' ''                strSpeakHeader = "今日も安全運転でお願いします"
        ' ''            Case 9
        ' ''                strSpeakHeader = "お待たせしました"
        ' ''            Case Else
        ' ''                strSpeakHeader = "お待たせしました"
        ' ''        End Select

        ' ''        strMSG &= "{B4}"                                                                    'ﾋﾟﾝﾎﾟﾝﾊﾟﾝﾎﾟﾝ
        ' ''        strMSG &= strSpeakSpeed                                                             '喋るｽﾋﾟｰﾄﾞ設定
        ' ''        strMSG &= strSpeakHeader                                                            'ﾍｯﾀﾞｰ部分
        ' ''        strMSG &= "、車輌ナンバー、" & STRFRONT_SYARYOU_Slow                                'ｾﾘﾌ
        ' ''        strMSG &= strSpeakSpeed                                                             '喋るｽﾋﾟｰﾄﾞ設定
        ' ''        strMSG &= "の運転手のかたは、" & mINTBERTH_NO(ii) & "番バースに、接車して下さい"    'ｾﾘﾌ
        ' ''        strMSG &= "{B5}"                                                                    'ﾋﾟﾝﾎﾟﾝﾊﾟﾝﾎﾟﾝ

        ' ''        '' ''strMSG &= "{B4}"                                                                    'ﾋﾟﾝﾎﾟﾝﾊﾟﾝﾎﾟﾝ
        ' ''        '' ''strMSG &= strSpeakSpeed                                                             '喋るｽﾋﾟｰﾄﾞ設定
        ' ''        '' ''strMSG &= "お待たせしました、車輌ナンバー、" & STRFRONT_SYARYOU_Slow                'ｾﾘﾌ
        ' ''        '' ''strMSG &= strSpeakSpeed                                                             '喋るｽﾋﾟｰﾄﾞ設定
        ' ''        '' ''strMSG &= "の運転手のかたは、" & mINTBERTH_NO(ii) & "番バースに、接車して下さい"    'ｾﾘﾌ
        ' ''        '' ''strMSG &= "{B5}"                                                                    'ﾋﾟﾝﾎﾟﾝﾊﾟﾝﾎﾟﾝ

        ' ''    End If

        ' ''Next

        ' ''Call Speak(strMSG)

    End Sub
#End Region

#Region "  発声関数　"
    '' ''*******************************************************************************************************************
    '' ''【機能】同上
    '' ''【引数】[ IN ]strSpeakText      ：声にするﾃｷｽﾄ
    '' ''【戻値】
    '' ''*******************************************************************************************************************
    ' ''Private Sub Speak(ByVal strSpeakText As String)

    ' ''    '*******************************************************
    ' ''    'ﾊﾞｰｽﾓﾆﾀ確認
    ' ''    '*******************************************************
    ' ''    If (gstrTERM_KBN <> STRTERM_ID_LN04) And (gstrTERM_KBN <> STRTERM_ID_AAA) Then Exit Sub


    ' ''    '*******************************************************
    ' ''    '発声
    ' ''    '*******************************************************
    ' ''    Dim objSpeak As New Speak.frmSpeak

    ' ''    objSpeak.strSpeakText = strSpeakText
    ' ''    objSpeak.shoSpeakerName = 5         '発声者設定 (2 or 4:男　3 or 5:女)
    ' ''    objSpeak.Speak()

    ' ''    objSpeak.Close()
    ' ''    objSpeak.Dispose()
    ' ''    objSpeak = Nothing


    ' ''End Sub
#End Region

End Class
