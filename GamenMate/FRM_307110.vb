'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】日報月報出力画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_307110

#Region "　共通変数　                               "

    Protected mudtSEARCH_ITEM As New stcSEARCH_ITEM     '検索条件用構造体


    ''' <summary>入力ﾁｪｯｸ場合判別</summary>
    Enum menmCheckCase
        SeisanKyouseiKanryou_Click   '生産入庫強制完了
        SyukkaSyuuryou_Click         '出荷作業終了
        NippoPrint_Click             '日報印刷ﾎﾞﾀﾝｸﾘｯｸ時
        GeppoPrint_Click             '月報印刷ﾎﾞﾀﾝｸﾘｯｸ時
    End Enum

#End Region
#Region "  構造体定義　                             "
    '検索条件
    Protected Structure stcSEARCH_ITEM
        Dim SOUGYOU_D As Date                '日付

    End Structure

#End Region
#Region "　ｲﾍﾞﾝﾄ　                                  "
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


        '****************************************
        '日報　日付           ｾｯﾄ
        '****************************************
        dtpNIPPO_D.cmpMDateTimePicker_D.Value = Now.AddDays(-1)


        '****************************************
        '月報　年           ｾｯﾄ
        '****************************************
        Dim i As Integer
        Dim intMinYear As Integer
        Dim intMaxYear As Integer
        intMinYear = TO_INTEGER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_JGS307110_001))
        intMaxYear = TO_INTEGER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_JGS307110_002))
        Dim intNowYear As Integer
        intNowYear = TO_INTEGER(Format(Now, "yyyy"))

        cboYEAR.Items.Clear()
        '(下限年度)
        For i = (intNowYear - intMinYear) To intNowYear
            cboYEAR.Items.Add(TO_STRING(i))
        Next

        '(上限年度)
        For i = (intNowYear + 1) To (intNowYear + intMaxYear)
            cboYEAR.Items.Add(TO_STRING(i))
        Next

        cboYEAR.Text = TO_STRING(intNowYear)

        '****************************************
        '月報　月           ｾｯﾄ
        '****************************************
        Dim intNowMonth As Integer
        intNowMonth = TO_INTEGER(Format(Now, "MM"))
        cboMONTH.Items.Clear()
        For i = 1 To 12
            cboMONTH.Items.Add(TO_STRING(i))
        Next

        cboMONTH.Text = TO_STRING(intNowMonth)


        '****************************************
        ' 端末に応じてﾎﾞﾀﾝ状態を変化
        '****************************************
        Select Case System.Net.Dns.GetHostName      'ｺﾝﾋﾟｭｰﾀ名取得
            Case "LNSC02", "LNSC03", "LNSC04", "LNSC05", "LNSC06", "LNSC07", "LNSC08", "LNSC09", "LNSC10", "LNSC11", "LNSS01"
                cmdF6.Enabled = False
                cmdF7.Enabled = False
            Case Else
                cmdF6.Enabled = True
                cmdF7.Enabled = True

        End Select

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
        dtpNIPPO_D.Dispose()           '日報　日付
        cboYEAR.Dispose()               '月報　年
        cboMONTH.Dispose()              '月報　月

    End Sub
#End Region
#Region "  F1(生産入庫強制完了) ﾎﾞﾀﾝ押下処理        "
    '*******************************************************************************************************************
    '【機能】F1  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F1Process()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.SeisanKyouseiKanryou_Click) = False Then
            '(入力ｴﾗｰがある場合)
            Exit Sub
        End If

        '********************************************************************
        'ｿｹｯﾄ送信(340002)
        '********************************************************************
        Call SendSocket01()

    End Sub
#End Region
#Region "  F2(出荷作業終了) ﾎﾞﾀﾝ押下処理            "
    '*******************************************************************************************************************
    '【機能】F2  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F2Process()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.SyukkaSyuuryou_Click) = False Then
            '(入力ｴﾗｰがある場合)
            Exit Sub
        End If

        '********************************************************************
        'ｿｹｯﾄ送信(400107)
        '********************************************************************
        Call SendSocket02()

    End Sub
#End Region
#Region "  F6(日報印刷)     ﾎﾞﾀﾝ押下処理            "
    '*******************************************************************************************************************
    '【機能】F6  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F6Process()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.NippoPrint_Click) = False Then
            '(入力ｴﾗｰがある場合)
            Exit Sub
        End If

        '*********************************************
        ' 抽出条件を構造体にｾｯﾄ
        '*********************************************
        Call SearchItem_Set(menmCheckCase.NippoPrint_Click)

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udeRet As PopupFormType
        udeRet = gobjComFuncFRM.DisplayPopup("日報出力" & FRM_MSG_FRM200000_01, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udeRet <> PopupFormType.Ok Then
            Exit Sub
        End If


        Try
            '*******************************************************
            '日報印刷処理
            '*******************************************************
            Call printOutNippo()

        Catch ex As UserException
            Call gobjComFuncFRM.DisplayPopup(ex.Message, PopupFormType.Ok, PopupIconType.Information)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
#End Region
#Region "  F7(月報印刷)     ﾎﾞﾀﾝ押下処理            "
    '*******************************************************************************************************************
    '【機能】F6  ﾎﾞﾀﾝ押下処理
    '【引数】
    '【戻値】
    '*******************************************************************************************************************
    Public Overrides Sub F7Process()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.GeppoPrint_Click) = False Then
            '(入力ｴﾗｰがある場合)
            Exit Sub
        End If

        '*********************************************
        ' 抽出条件を構造体にｾｯﾄ
        '*********************************************
        Call SearchItem_Set(menmCheckCase.GeppoPrint_Click)

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udeRet As PopupFormType
        udeRet = gobjComFuncFRM.DisplayPopup("月報出力" & FRM_MSG_FRM200000_01, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udeRet <> PopupFormType.Ok Then
            Exit Sub
        End If

        Try

            '*******************************************************
            '月報印刷処理
            '*******************************************************
            Call printOutGeppo()

        Catch ex As UserException
            Call gobjComFuncFRM.DisplayPopup(ex.Message, PopupFormType.Ok, PopupIconType.Information)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
#End Region
#Region "  構造体ｾｯﾄ                                "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 構造体ｾｯﾄ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SearchItem_Set(ByVal udtCheck_Case As menmCheckCase)

        '********************************************************************
        '構造体に値をｾｯﾄ
        '********************************************************************
        Select Case udtCheck_Case
            Case menmCheckCase.NippoPrint_Click
                '(日報印刷ﾎﾞﾀﾝｸﾘｯｸ時)
                mudtSEARCH_ITEM.SOUGYOU_D = TO_DATE(dtpNIPPO_D.userDateTimeText)       '日付

            Case menmCheckCase.GeppoPrint_Click
                '(月報印刷ﾎﾞﾀﾝｸﾘｯｸ時)
                Dim strSougyouD As String
                strSougyouD = cboYEAR.Text & "/" & cboMONTH.Text & "/" & "01"
                mudtSEARCH_ITEM.SOUGYOU_D = TO_DATE(strSougyouD)                        '日付

        End Select

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
            Case menmCheckCase.SeisanKyouseiKanryou_Click
                '(生産入庫強制完了ﾎﾞﾀﾝｸﾘｯｸ時)

                blnCheckErr = False

            Case menmCheckCase.SyukkaSyuuryou_Click
                '(出荷作業終了ﾎﾞﾀﾝｸﾘｯｸ時)

                blnCheckErr = False

            Case menmCheckCase.NippoPrint_Click
                '(日報印刷ﾎﾞﾀﾝｸﾘｯｸ時)

                blnCheckErr = False

            Case menmCheckCase.GeppoPrint_Click
                '(月報印刷ﾎﾞﾀﾝｸﾘｯｸ時)

                '========================================
                '年
                '========================================
                If cboYEAR.SelectedIndex < 1 Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM307110_01, _
                                     PopupFormType.Ok, _
                                     PopupIconType.Information)
                    Exit Select
                End If

                '========================================
                '月
                '========================================
                '    ↓↓↓↓↓↓************************************************************************************************************
                '    JobMate:S.Ouchi 2014/02/04 月報で１月が選択できない対応
                '' ''If cboMONTH.SelectedIndex < 1 Then
                If cboMONTH.SelectedIndex < 0 Or cboMONTH.SelectedIndex > 11 Then
                    'JobMate:S.Ouchi 2014/02/04 月報で１月が選択できない対応
                    '↑↑↑↑↑↑************************************************************************************************************
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM307110_02, _
                                     PopupFormType.Ok, _
                                     PopupIconType.Information)
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
#Region "　日報印刷処理　                      　　 "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】なし
    '【戻値】なし
    '*******************************************************************************************************************
    Private Function printOutNippo() As Boolean

        Dim objTemplateServer As New clsTemplateServer(gobjOwner, gobjDb, Nothing)

        Call gobjComFuncFRM.WaitFormShow()                     ' Waitﾌｫｰﾑ表示

        Try

            '*============================
            '* 日報作成
            '*============================
            Call objTemplateServer.MakeExcelNippou(mudtSEARCH_ITEM.SOUGYOU_D)

        Catch ex As Exception
            Throw ex
        Finally
            Call gobjComFuncFRM.WaitFormClose()                    ' Waitﾌｫｰﾑ削除
        End Try


    End Function
#End Region
#Region "　月報印刷処理　                           "
    '*******************************************************************************************************************
    '【機能】同上
    '【引数】なし
    '【戻値】なし
    '*******************************************************************************************************************
    Private Sub printOutGeppo()

        Dim objTemplateServer As New clsTemplateServer(gobjOwner, gobjDb, Nothing)

        Call gobjComFuncFRM.WaitFormShow()                     ' Waitﾌｫｰﾑ表示

        Try

            '*============================
            '* 月報作成
            '*============================
            Call objTemplateServer.MakeExcelGeppou(mudtSEARCH_ITEM.SOUGYOU_D)

        Catch ex As Exception
            Throw ex
        Finally
            Call gobjComFuncFRM.WaitFormClose()                    ' Waitﾌｫｰﾑ削除
        End Try

    End Sub
#End Region
#Region "  ｿｹｯﾄ送信(生産入庫強制完了)               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信(生産入庫強制完了) 
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SendSocket01()


        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        Dim strMessage As String
        strMessage = ""
        strMessage &= "生産入庫強制完了" & FRM_MSG_FRM200000_01
        udtRet = gobjComFuncFRM.DisplayPopup(strMessage, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Sub
        End If


        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J340002    'ﾌｫｰﾏｯﾄ名ｾｯﾄ

        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode    'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String

        strErrMsg = "生産入庫強制完了" & FRM_MSG_FRM200000_14
        udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)   'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            '(送信できた場合)
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)

            End If
        End If

    End Sub
#End Region
#Region "  ｿｹｯﾄ送信(出荷作業終了)                   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信(出荷作業終了) 
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SendSocket02()

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        Dim strMessage As String
        strMessage = ""
        strMessage &= "出荷作業終了" & FRM_MSG_FRM200000_01
        udtRet = gobjComFuncFRM.DisplayPopup(strMessage, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Sub
        End If

        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)

        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_J400107    'ﾌｫｰﾏｯﾄ名ｾｯﾄ
        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode    'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String

        strErrMsg = "出荷作業終了" & FRM_MSG_FRM200000_14
        udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)   'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            '(送信できた場合)
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)

            End If
        End If

    End Sub
#End Region

End Class
