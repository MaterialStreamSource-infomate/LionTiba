'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】ｵﾝﾗｲﾝ設定画面
' 【作成】SIT
'**********************************************************************************************

#Region "　Imports                              "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class FRM_205010

#Region "　共通変数　                           "

    '定数
    Private Const MESSAGE_001 As String = "ｵﾝﾗｲﾝ設定 ﾌｫｰﾑﾛｰﾄﾞ時の状態です。:"
    Private Const MESSAGE_002 As String = "ｵﾝﾗｲﾝ設定 切替発生しました。    :"

    ''' <summary>ﾁｪｯｸ用列挙体</summary>
    Enum menmCheckCase
        OnlineBtn_Click         'ｵﾝﾗｲﾝﾎﾞﾀﾝｸﾘｯｸ時
        OfflineBtn_Click        'ｵﾌﾗｲﾝﾎﾞﾀﾝｸﾘｯｸ時
    End Enum


    ''' <summary>CUT_STS(切離状態)ｵﾌﾗｲﾝ/ｵﾝﾗｲﾝ</summary>
    Enum menmCUT_STS
        ONLINE = 0
        OFFLINE = 1
    End Enum

#End Region
#Region "　ｲﾍﾞﾝﾄ　                              "
#Region "　ｵﾝﾗｲﾝ状態更新    ﾀｲﾏ　               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｵﾝﾗｲﾝ状態更新    ﾀｲﾏ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tmr205010_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr205010.Tick
        Try

            tmr205010.Enabled = False

            '**************************************************
            ' 設備状態取得ﾀｲﾏｰ処理
            '**************************************************
            Call tmr205010_TickProcess()

        Catch ex As Exception
            ComError(ex)

        Finally
            tmr205010.Enabled = True

        End Try
    End Sub
#End Region
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
#Region "　ﾌｫｰﾑﾛｰﾄﾞ　                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ﾌｫｰﾑﾛｰﾄﾞ
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub InitializeChild()

        '**********************************************************
        ' ﾗｼﾞｵﾎﾞﾀﾝ初期設定
        '**********************************************************
        rdoSYS0000.Checked = False                  'MELSEC
        rdoSYS0001.Checked = False                  'SW-1
        rdoSYS0002.Checked = False                  'SW-2
        rdoSYS0003.Checked = False                  'SW-3
        rdoSYS0004.Checked = False                  'SW-4
        rdoSYS0005.Checked = False                  'SW-5
        rdoSYS0006.Checked = False                  'SW-4A
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:S.Ouchi 2015/07/23 CW6追加対応 ↓↓↓↓↓↓
        rdoSYS0007.Checked = False                  'SW-6
        'JobMate:S.Ouchi 2015/07/23 CW6追加対応 ↑↑↑↑↑↑
        '↑↑↑↑↑↑************************************************************************************************************
        rdoSYS0101.Checked = False                  '車両ｺﾝﾄﾛｰﾗ

        '**********************************************************
        ' ﾗﾍﾞﾙ設定
        '**********************************************************
        Call AlterLabelColorAll()


        '**********************************************************
        ' ﾀｲﾏｰ設定
        '**********************************************************
        tmr205010.Interval = TO_INTEGER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS205010_001))
        tmr205010.Enabled = True


    End Sub
#End Region
#Region "　ﾌｫｰﾑｱﾝﾛｰﾄﾞ                           "
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
        rdoSYS0000.Dispose()
        rdoSYS0001.Dispose()
        rdoSYS0002.Dispose()
        rdoSYS0003.Dispose()
        rdoSYS0004.Dispose()
        rdoSYS0005.Dispose()
        rdoSYS0006.Dispose()
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:S.Ouchi 2015/07/23 CW6追加対応 ↓↓↓↓↓↓
        rdoSYS0007.Dispose()
        'JobMate:S.Ouchi 2015/07/23 CW6追加対応 ↑↑↑↑↑↑
        '↑↑↑↑↑↑************************************************************************************************************
        rdoSYS0101.Dispose()

    End Sub
#End Region
#Region "  F4(ｵﾝﾗｲﾝ)  ﾎﾞﾀﾝ押下処理　            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F4(ｵﾝﾗｲﾝ) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F4Process()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.OnlineBtn_Click) = False Then

            Exit Sub

        End If

        '**********************************************************
        ' ｿｹｯﾄ送信
        '**********************************************************
        Dim objRadioLabel As System.Windows.Forms.Label = Nothing
        Dim objRadioButton As System.Windows.Forms.RadioButton = Nothing
        If rdoSYS0000.Checked = True Then
            '(MELSEC)
            objRadioLabel = lblSYS0000
            objRadioButton = rdoSYS0000
        ElseIf rdoSYS0001.Checked = True Then
            '(SW-1)
            objRadioLabel = lblSYS0001
            objRadioButton = rdoSYS0001
        ElseIf rdoSYS0002.Checked = True Then
            '(SW-2)
            objRadioLabel = lblSYS0002
            objRadioButton = rdoSYS0002
        ElseIf rdoSYS0003.Checked = True Then
            '(SW-3)
            objRadioLabel = lblSYS0003
            objRadioButton = rdoSYS0003
        ElseIf rdoSYS0004.Checked = True Then
            '(SW-4)
            objRadioLabel = lblSYS0004
            objRadioButton = rdoSYS0004
        ElseIf rdoSYS0005.Checked = True Then
            '(SW-5)
            objRadioLabel = lblSYS0005
            objRadioButton = rdoSYS0005
        ElseIf rdoSYS0006.Checked = True Then
            '(SW-4A)
            objRadioLabel = lblSYS0006
            objRadioButton = rdoSYS0006

            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2015/07/23 CW6追加対応 ↓↓↓↓↓↓
        ElseIf rdoSYS0007.Checked = True Then
            '(SW-6)
            objRadioLabel = lblSYS0007
            objRadioButton = rdoSYS0007
            'JobMate:S.Ouchi 2015/07/23 CW6追加対応 ↑↑↑↑↑↑
            '↑↑↑↑↑↑************************************************************************************************************

        ElseIf rdoSYS0101.Checked = True Then
            '(車両ｺﾝﾄﾛｰﾗ)
            objRadioLabel = lblSYS0101
            objRadioButton = rdoSYS0101
        End If
        Call SendSocket01(menmCUT_STS.ONLINE, objRadioLabel, objRadioButton)


        '**********************************************************
        ' ﾗﾍﾞﾙ設定
        '**********************************************************
        Call AlterLabelColorAll()


    End Sub
#End Region
#Region "  F5(ｵﾌﾗｲﾝ)  ﾎﾞﾀﾝ押下処理　            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F4(ｵﾌﾗｲﾝ) ﾎﾞﾀﾝ押下処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F5Process()

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        If InputCheck(menmCheckCase.OfflineBtn_Click) = False Then

            Exit Sub

        End If

        '**********************************************************
        ' ｿｹｯﾄ送信
        '**********************************************************
        Dim objRadioLabel As System.Windows.Forms.Label = Nothing
        Dim objRadioButton As Windows.Forms.RadioButton = Nothing
        If rdoSYS0000.Checked = True Then
            '(MELSEC)
            objRadioLabel = lblSYS0000
            objRadioButton = rdoSYS0000
        ElseIf rdoSYS0001.Checked = True Then
            '(SW-1)
            objRadioLabel = lblSYS0001
            objRadioButton = rdoSYS0001
        ElseIf rdoSYS0002.Checked = True Then
            '(SW-2)
            objRadioLabel = lblSYS0002
            objRadioButton = rdoSYS0002
        ElseIf rdoSYS0003.Checked = True Then
            '(SW-3)
            objRadioLabel = lblSYS0003
            objRadioButton = rdoSYS0003
        ElseIf rdoSYS0004.Checked = True Then
            '(SW-4)
            objRadioLabel = lblSYS0004
            objRadioButton = rdoSYS0004
        ElseIf rdoSYS0005.Checked = True Then
            '(SW-5)
            objRadioLabel = lblSYS0005
            objRadioButton = rdoSYS0005
        ElseIf rdoSYS0006.Checked = True Then
            '(SW-4A)
            objRadioLabel = lblSYS0006
            objRadioButton = rdoSYS0006

            '↓↓↓↓↓↓************************************************************************************************************
            'JobMate:S.Ouchi 2015/07/23 CW6追加対応 ↓↓↓↓↓↓
        ElseIf rdoSYS0007.Checked = True Then
            '(SW-6)
            objRadioLabel = lblSYS0007
            objRadioButton = rdoSYS0007
            'JobMate:S.Ouchi 2015/07/23 CW6追加対応 ↑↑↑↑↑↑
            '↑↑↑↑↑↑************************************************************************************************************

        ElseIf rdoSYS0101.Checked = True Then
            '(車両ｺﾝﾄﾛｰﾗ)
            objRadioLabel = lblSYS0101
            objRadioButton = rdoSYS0101
        End If
        Call SendSocket01(menmCUT_STS.OFFLINE, objRadioLabel, objRadioButton)


        '**********************************************************
        ' ﾗﾍﾞﾙ設定
        '**********************************************************
        Call AlterLabelColorAll()


    End Sub
#End Region
#Region "　入力ﾁｪｯｸ　                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 入力ﾁｪｯｸ
    ''' </summary>
    ''' <param name="udtCheck_Case">入力ﾁｪｯｸ判別</param>
    ''' <returns>True :入力ﾁｪｯｸ成功 False:入力ﾁｪｯｸ失敗</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Function InputCheck(ByVal udtCheck_Case As menmCheckCase) As Boolean

        Dim blnReturn As Boolean = False        '自関数戻値
        Dim blnCheckErr As Boolean = True       'ﾁｪｯｸｴﾗｰﾌﾗｸﾞ

        '********************************************************************
        '入力ﾁｪｯｸ
        '********************************************************************
        Select Case udtCheck_Case
            Case menmCheckCase.OnlineBtn_Click
                '(ｵﾝﾗｲﾝﾎﾞﾀﾝｸﾘｯｸ時)

                '==========================
                'ﾗｼﾞｵﾎﾞﾀﾝ選択ﾁｪｯｸ
                '==========================
                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:S.Ouchi 2015/07/23 CW6追加対応 ↓↓↓↓↓↓
                '' ''If rdoSYS0000.Checked = False And _
                '' ''   rdoSYS0001.Checked = False And _
                '' ''   rdoSYS0002.Checked = False And _
                '' ''   rdoSYS0003.Checked = False And _
                '' ''   rdoSYS0004.Checked = False And _
                '' ''   rdoSYS0005.Checked = False And _
                '' ''   rdoSYS0006.Checked = False And _
                '' ''   rdoSYS0101.Checked = False Then
                If rdoSYS0000.Checked = False And _
                   rdoSYS0001.Checked = False And _
                   rdoSYS0002.Checked = False And _
                   rdoSYS0003.Checked = False And _
                   rdoSYS0004.Checked = False And _
                   rdoSYS0005.Checked = False And _
                   rdoSYS0006.Checked = False And _
                   rdoSYS0007.Checked = False And _
                   rdoSYS0101.Checked = False Then
                    'JobMate:S.Ouchi 2015/07/23 CW6追加対応 ↑↑↑↑↑↑
                    '↑↑↑↑↑↑************************************************************************************************************
                    '(ﾗｼﾞｵﾎﾞﾀﾝが選択されていない場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205010_01, PopupFormType.Ok, PopupIconType.Information)
                    blnCheckErr = True
                    Exit Select

                End If

                blnCheckErr = False

            Case menmCheckCase.OfflineBtn_Click
                '(ｵﾌﾗｲﾝﾎﾞﾀﾝｸﾘｯｸ時)

                '==========================
                'ﾗｼﾞｵﾎﾞﾀﾝ選択ﾁｪｯｸ
                '==========================
                '↓↓↓↓↓↓************************************************************************************************************
                'JobMate:S.Ouchi 2015/07/23 CW6追加対応 ↓↓↓↓↓↓
                '' ''If rdoSYS0000.Checked = False And _
                '' ''   rdoSYS0001.Checked = False And _
                '' ''   rdoSYS0002.Checked = False And _
                '' ''   rdoSYS0003.Checked = False And _
                '' ''   rdoSYS0004.Checked = False And _
                '' ''   rdoSYS0005.Checked = False And _
                '' ''   rdoSYS0006.Checked = False And _
                '' ''   rdoSYS0101.Checked = False Then
                If rdoSYS0000.Checked = False And _
                   rdoSYS0001.Checked = False And _
                   rdoSYS0002.Checked = False And _
                   rdoSYS0003.Checked = False And _
                   rdoSYS0004.Checked = False And _
                   rdoSYS0005.Checked = False And _
                   rdoSYS0006.Checked = False And _
                   rdoSYS0007.Checked = False And _
                   rdoSYS0101.Checked = False Then
                    'JobMate:S.Ouchi 2015/07/23 CW6追加対応 ↑↑↑↑↑↑
                    '↑↑↑↑↑↑************************************************************************************************************
                    '(ﾗｼﾞｵﾎﾞﾀﾝが選択されていない場合)
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205010_01, PopupFormType.Ok, PopupIconType.Information)
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
#Region "  ｿｹｯﾄ送信                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ｿｹｯﾄ送信
    ''' </summary>
    ''' <param name="udtCutSts">切離状態</param>
    ''' <param name="objLabel">設備</param>
    ''' <param name="objRadioButton"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function SendSocket01(ByVal udtCutSts As menmCUT_STS _
                                , ByVal objLabel As System.Windows.Forms.Label _
                                , ByVal objRadioButton As System.Windows.Forms.RadioButton _
                                  ) _
                                  As Boolean

        Dim blnRet As Boolean = False

        '*******************************************************
        '確認ﾒｯｾｰｼﾞ
        '*******************************************************
        Dim udtRet As RetPopup
        Dim strMsg As String
        strMsg = ""
        Select Case udtCutSts
            Case menmCUT_STS.ONLINE
                '(ｵﾝﾗｲﾝ)
                strMsg = FRM_MSG_FRM205010_02

            Case menmCUT_STS.OFFLINE
                '(ｵﾌﾗｲﾝ)
                strMsg = FRM_MSG_FRM205010_05
        End Select
        udtRet = gobjComFuncFRM.DisplayPopup(strMsg, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Function
        End If


        Dim strEQ_ID As String = ""                     '設備ID
        strEQ_ID = gobjComFuncFRM.GetTDSP_CTRL(Me.Name, objLabel.Name)             '設備ID

        '↓↓↓↓↓↓************************************************************************************************************
        'SystemMate:A.Noto 2012/04/28  搬送制御送信IFﾁｪｯｸ

        Dim strReSendFlg As String = ""          '再送信ﾌﾗｸﾞ


        If TO_NUMBER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_033)) = FLAG_ON Then
            '(ｵﾝﾗｲﾝ再送信ﾒｯｾｰｼﾞ表示ﾌﾗｸﾞがONのとき)

            Select Case udtCutSts
                Case menmCUT_STS.ONLINE
                    '(ｵﾝﾗｲﾝ)
                    '=============================================
                    '搬送制御送信IFﾃｰﾌﾞﾙ
                    '=============================================
                    Dim objTLIF_TRNS_SEND As New TBL_TLIF_TRNS_SEND(gobjOwner, gobjDb, Nothing)     '搬送制御送信IFﾃｰﾌﾞﾙｸﾗｽ
                    objTLIF_TRNS_SEND.FEQ_ID = strEQ_ID                                             '設備ID
                    If objTLIF_TRNS_SEND.GET_TLIF_TRNS_SEND_COUNT_BY_EQ_ID_TRY > 0 Then
                        '(件数が存在する場合)
                        udtRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM205010_10, PopupFormType.YES_NO, PopupIconType.Quest)
                        If udtRet = RetPopup.OK Then
                            strReSendFlg = TO_STRING(FLAG_ON)
                        Else
                            strReSendFlg = TO_STRING(FLAG_OFF)
                        End If
                    End If

            End Select

        End If


        '↑↑↑↑↑↑************************************************************************************************************


        '*******************************************************
        'ｿｹｯﾄ送信処理
        '*******************************************************
        '========================================
        ' 変数宣言
        '========================================
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)


        '========================================
        ' 変数ｾｯﾄ
        '========================================
        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200301      'ﾌｫｰﾏｯﾄ名ｾｯﾄ
        objTelegram.SETIN_DATA("DSPEQ_ID", strEQ_ID)                    '設備ID
        objTelegram.SETIN_DATA("DSPEQ_CUT_STS", udtCutSts)              '切離し状態
        '↓↓↓↓↓↓************************************************************************************************************
        'SystemMate:A.Noto 2012/04/28  再送信ﾌﾗｸﾞ追加
        objTelegram.SETIN_DATA("DSPRESEND", strReSendFlg)               '再送信ﾌﾗｸﾞ
        '↑↑↑↑↑↑************************************************************************************************************

        Dim strRET_STATE As String = ""
        Dim udtSckSendRET As clsSocketClient.RetCode   'ｿｹｯﾄ送信戻り値
        Dim strErrMsg As String = ""                 'ｴﾗｰﾒｯｾｰｼﾞ

        Select Case udtCutSts
            Case menmCUT_STS.ONLINE
                '(ｵﾝﾗｲﾝ)
                strErrMsg = objRadioButton.Text & FRM_MSG_FRM205010_07
            Case menmCUT_STS.OFFLINE
                '(ｵﾌﾗｲﾝ)
                strErrMsg = objRadioButton.Text & FRM_MSG_FRM205010_09
        End Select

        udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE, , , , strErrMsg)   'ｿｹｯﾄ送信
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            '(送信できた場合)
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(正常終了の場合)
                blnret = True
            End If
        End If

        Return blnRet

    End Function
#End Region
#Region "　全ﾗﾍﾞﾙ背景色変更　                   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 全ﾗﾍﾞﾙ背景色変更
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub AlterLabelColorAll()

        Call gobjComFuncFRM.AlterLabelColor(lblSYS0000, Me.Name, LBL_DSPTYPE.STSNAME)          'MELSEC
        Call gobjComFuncFRM.AlterLabelColor(lblSYS0001, Me.Name, LBL_DSPTYPE.STSNAME)          'SW-1
        Call gobjComFuncFRM.AlterLabelColor(lblSYS0002, Me.Name, LBL_DSPTYPE.STSNAME)          'SW-2
        Call gobjComFuncFRM.AlterLabelColor(lblSYS0003, Me.Name, LBL_DSPTYPE.STSNAME)          'SW-3
        Call gobjComFuncFRM.AlterLabelColor(lblSYS0004, Me.Name, LBL_DSPTYPE.STSNAME)          'SW-4
        Call gobjComFuncFRM.AlterLabelColor(lblSYS0005, Me.Name, LBL_DSPTYPE.STSNAME)          'SW-5
        Call gobjComFuncFRM.AlterLabelColor(lblSYS0006, Me.Name, LBL_DSPTYPE.STSNAME)          'SW-4A
        '↓↓↓↓↓↓************************************************************************************************************
        'JobMate:S.Ouchi 2015/07/23 CW6追加対応 ↓↓↓↓↓↓
        Call gobjComFuncFRM.AlterLabelColor(lblSYS0007, Me.Name, LBL_DSPTYPE.STSNAME)          'SW-6
        'JobMate:S.Ouchi 2015/07/23 CW6追加対応 ↑↑↑↑↑↑
        '↑↑↑↑↑↑************************************************************************************************************
        Call gobjComFuncFRM.AlterLabelColor(lblSYS0101, Me.Name, LBL_DSPTYPE.STSNAME)          '車両ｺﾝﾄﾛｰﾗ

    End Sub
#End Region
#Region "  設備状態取得ﾀｲﾏｰ処理                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' 設備状態取得ﾀｲﾏｰ処理
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub tmr205010_TickProcess()

        '**********************************************************
        ' ﾗﾍﾞﾙ背景色変更処理
        '**********************************************************
        Call AlterLabelColorAll()


    End Sub
#End Region

End Class
