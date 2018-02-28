'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation
' All Rights Reserved
'
' 【名称】ﾏﾃﾘｱﾙｽﾄﾘｰﾑ標準機能
' 【機能】画面ｻﾝﾌﾟﾙﾒｿｯﾄﾞ集
' 【作成】KSH
'**********************************************************************************************

#Region "　Imports                                  "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class cls999999

#Region "  ｿｹｯﾄ送信ﾌｫｰﾏｯﾄ(親画面で送信の場合)           "
    ''''*******************************************************************************************************************
    '''' <summary>
    '''' ｿｹｯﾄ送信
    '''' </summary>
    '''' <returns></returns>
    '''' <remarks></remarks>
    ''''*******************************************************************************************************************
    'Private Function SendSocket01() As Boolean

    '    Dim blnRet As Boolean = False

    '    '*******************************************************
    '    '確認ﾒｯｾｰｼﾞ
    '    '*******************************************************
    '    Dim udtRet As RetPopup
    '    Dim strMessage As String
    '    strMessage = ""
    '    strMessage &= $$$$$$$$$$$$$$$$$$$$$
    '    udtRet = gobjComFuncFRM.DisplayPopup(strMessage, PopupFormType.Ok_Cancel, PopupIconType.Quest)
    '    If udtRet <> RetPopup.OK Then
    '        Exit Sub
    '    End If


    '    '*******************************************************
    '    'ｿｹｯﾄ送信処理
    '    '*******************************************************
    '    '========================================
    '    ' 変数宣言
    '    '========================================
    '    Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
    '    Dim str$$$$$$$$$$ As String = ""         '
    '    Dim str$$$$$$$$$$ As String = ""         '
    '    Dim str$$$$$$$$$$ As String = ""         '
    '    Dim str$$$$$$$$$$ As String = ""         '
    '    objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_$$$$$$           'ﾌｫｰﾏｯﾄ名ｾｯﾄ
    '    str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '
    '    str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '
    '    str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '
    '    str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '


    '    objTelegram.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '
    '    objTelegram.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '
    '    objTelegram.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '
    '    objTelegram.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '


    '    Dim strRET_STATE As String = ""
    '    Dim udtSckSendRET As clsSocketClient.RetCode    'ｿｹｯﾄ送信戻り値
    '    Dim strErrMsg As String                         'ｴﾗｰﾒｯｾｰｼﾞ

    '    strErrMsg = $$$$$$$$$$$$$$$$$$$$$
    '    udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE)   'ｿｹｯﾄ送信
    '    If udtSckSendRET = clsSocketClient.RetCode.OK Then
    '        '(送信できた場合)
    '        If strRET_STATE = ID_RETURN_RET_STATE_OK Then
    '            '(正常終了の場合)
    '            blnRet = True
    '        Else
    '            '(処理が異常終了した場合)
    '            Call gobjComFuncFRM.DisplayPopup(strErrMsg, _
    '                              PopupFormType.Ok, _
    '                              PopupIconType.Err)
    '        End If
    '    ElseIf udtSckSendRET = clsSocketClient.RetCode.ReceiveTimeOut Then
    '        '(ﾀｲﾑｱｳﾄの場合)
    '    Else
    '        '(その他の場合)
    '        Call gobjComFuncFRM.DisplayPopup(strErrMsg, _
    '                          PopupFormType.Ok, _
    '                          PopupIconType.Err)
    '    End If

    '    Return blnRet

    'End Function

#End Region
#Region "  ｿｹｯﾄ送信ﾌｫｰﾏｯﾄ(子画面で送信の場合)           "
    ''''*******************************************************************************************************************
    '''' <summary>
    '''' ｿｹｯﾄ送信
    '''' </summary>
    '''' <remarks></remarks>
    ''''*******************************************************************************************************************
    'Private Sub SendSocket01()


    '    '*******************************************************
    '    '確認ﾒｯｾｰｼﾞ
    '    '*******************************************************
    '    Dim udtRet As RetPopup
    '    Dim strMessage As String
    '    strMessage = ""
    '    strMessage &= $$$$$$$$$$$$$$$$$$$$$
    '    udtRet = DisplayPopup(strMessage, PopupFormType.Ok_Cancel, PopupIconType.Quest)
    '    If udtRet <> RetPopup.OK Then
    '        Exit Sub
    '    End If


    '    '*******************************************************
    '    'ｿｹｯﾄ送信処理
    '    '*******************************************************
    '    '========================================
    '    ' 変数宣言
    '    '========================================
    '    Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
    '    Dim str$$$$$$$$$$ As String = ""         '
    '    Dim str$$$$$$$$$$ As String = ""         '
    '    Dim str$$$$$$$$$$ As String = ""         '
    '    Dim str$$$$$$$$$$ As String = ""         '
    '    objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_$$$$$$           'ﾌｫｰﾏｯﾄ名ｾｯﾄ
    '    str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '
    '    str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '
    '    str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '
    '    str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '


    '    objTelegram.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '
    '    objTelegram.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '
    '    objTelegram.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '
    '    objTelegram.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '


    '    Dim strRET_STATE As String = ""
    '    Dim udtSckSendRET As clsSocketClient.RetCode    'ｿｹｯﾄ送信戻り値
    '    Dim strErrMsg As String                         'ｴﾗｰﾒｯｾｰｼﾞ

    '    strErrMsg = $$$$$$$$$$$$$$$$$$$$$
    '    udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE)   'ｿｹｯﾄ送信
    '    If udtSckSendRET = clsSocketClient.RetCode.OK Then
    '        '(送信できた場合)
    '        If strRET_STATE = ID_RETURN_RET_STATE_OK Then
    '            '(正常終了の場合)
    '            Me.DialogResult = Windows.Forms.DialogResult.OK

    '            Me.Close()
    '            Me.Dispose()

    '        Else
    '            '(処理が異常終了した場合)
    '            Call DisplayPopup(strErrMsg, _
    '                              PopupFormType.Ok, _
    '                              PopupIconType.Err)
    '        End If
    '    ElseIf udtSckSendRET = clsSocketClient.RetCode.ReceiveTimeOut Then
    '        '(ﾀｲﾑｱｳﾄの場合)
    '    Else
    '        '(その他の場合)
    '        Call DisplayPopup(strErrMsg, _
    '                          PopupFormType.Ok, _
    '                          PopupIconType.Err)
    '    End If


    'End Sub
#End Region
#Region "  ｿｹｯﾄ送信ﾌｫｰﾏｯﾄ(複数ｿｹｯﾄ送信)(親画面で送信の場合)     "
    ''''*******************************************************************************************************************
    '''' <summary>
    '''' ｿｹｯﾄ送信
    '''' </summary>
    '''' <remarks></remarks>
    ''''*******************************************************************************************************************
    'Private Function SendSocket01() As Boolean

    '    Dim blnRet As Boolean = False

    '    '*******************************************************
    '    '確認ﾒｯｾｰｼﾞ
    '    '*******************************************************
    '    Dim udtRet As RetPopup
    '    Dim strMessage As String
    '    strMessage = ""
    '    strMessage &= $$$$$$$$$$$$$$$$$$$$$
    '    udtRet = DisplayPopup(strMessage, PopupFormType.Ok_Cancel, PopupIconType.Quest)
    '    If udtRet <> RetPopup.OK Then
    '        Exit Sub
    '    End If


    '    '*******************************************************
    '    'ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙに追加する電文配列作成
    '    '*******************************************************
    '    Dim strSendTel() As String = Nothing
    '    For ii As Integer = 1 To grdList.Rows.Count - 1
    '        '(展開元画面の行分ﾙｰﾌﾟ)

    '        If IsNull(strSendTel) = True Then ReDim Preserve strSendTel(0) Else ReDim Preserve strSendTel(UBound(strSendTel) + 1)


    '        '*******************************************************
    '        ' 電文作成
    '        '*******************************************************
    '        '========================================
    '        ' 変数宣言
    '        '========================================
    '        Dim objTelegramSub As New clsTelegram(CONFIG_TELEGRAM_DSP)
    '        Dim str$$$$$$$$$$ As String = ""         '
    '        Dim str$$$$$$$$$$ As String = ""         '
    '        Dim str$$$$$$$$$$ As String = ""         '
    '        Dim str$$$$$$$$$$ As String = ""         '
    '        objTelegramSub.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_$$$$$$           'ﾌｫｰﾏｯﾄ名ｾｯﾄ
    '        str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '
    '        str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '
    '        str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '
    '        str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '

    '        Dim strDSPCMD_ID As String = ""
    '        strDSPCMD_ID = objTelegramSub.FORMAT_ID.Substring(objTelegramSub.FORMAT_ID.Length - 6, 6)
    '        'ﾍｯﾀﾞﾃﾞｰﾀ
    '        objTelegramSub.SETIN_HEADER("DSPCMD_ID", strDSPCMD_ID)              'ｺﾏﾝﾄﾞID
    '        objTelegramSub.SETIN_HEADER("DSPTERM_ID", gcstrFTERM_ID)            '端末ID
    '        objTelegramSub.SETIN_HEADER("DSPUSER_ID", gcstrFUSER_ID)            'ﾕｰｻﾞID
    '        'ﾃﾞｰﾀ
    '        objTelegramSub.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '
    '        objTelegramSub.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '
    '        objTelegramSub.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '
    '        objTelegramSub.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '
    '        objTelegramSub.MAKE_TELEGRAM()

    '        strSendTel(UBound(strSendTel)) = objTelegramSub.TELEGRAM_MAKED
    '    Next


    '    '*******************************************************
    '    ' 電文作成
    '    '*******************************************************
    '    '========================================
    '    ' 変数宣言
    '    '========================================
    '    Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
    '    Dim str$$$$$$$$$$ As String = ""         '
    '    Dim str$$$$$$$$$$ As String = ""         '
    '    Dim str$$$$$$$$$$ As String = ""         '
    '    Dim str$$$$$$$$$$ As String = ""         '
    '    objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_$$$$$$           'ﾌｫｰﾏｯﾄ名ｾｯﾄ
    '    str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '
    '    str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '
    '    str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '
    '    str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '


    '    objTelegram.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '
    '    objTelegram.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '
    '    objTelegram.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '
    '    objTelegram.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '

    '    Dim strRET_STATE As String = ""
    '    Dim udtSckSendRET As clsSocketClient.RetCode    'ｿｹｯﾄ送信戻り値
    '    Dim strErrMsg As String                         'ｴﾗｰﾒｯｾｰｼﾞ

    '    strErrMsg = $$$$$$$$$$$$$$$$$$$$$
    '    udtSckSendRET = gobjComFuncFRM.SockSendServer02(objTelegram, strSendTel, strRET_STATE)   'ｿｹｯﾄ送信
    '    If udtSckSendRET = clsSocketClient.RetCode.OK Then
    '        '        '(送信できた場合)
    '        If strRET_STATE = ID_RETURN_RET_STATE_OK Then
    '            '(正常終了の場合)
    '            blnRet = True
    '        Else
    '            '(処理が異常終了した場合)
    '            Call DisplayPopup(strErrMsg, _
    '                              PopupFormType.Ok, _
    '                              PopupIconType.Err)
    '        End If
    '    ElseIf udtSckSendRET = clsSocketClient.RetCode.ReceiveTimeOut Then
    '        '(ﾀｲﾑｱｳﾄの場合)
    '    Else
    '        '(その他の場合)
    '        Call DisplayPopup(strErrMsg, _
    '                          PopupFormType.Ok, _
    '                          PopupIconType.Err)
    '    End If

    '    Return blnRet

    'End Sub
#End Region
#Region "  ｿｹｯﾄ送信ﾌｫｰﾏｯﾄ(複数ｿｹｯﾄ送信)(子画面で送信の場合)     "
    ''''*******************************************************************************************************************
    '''' <summary>
    '''' ｿｹｯﾄ送信
    '''' </summary>
    '''' <remarks></remarks>
    ''''*******************************************************************************************************************
    'Private Sub SendSocket01()


    '    '*******************************************************
    '    '確認ﾒｯｾｰｼﾞ
    '    '*******************************************************
    '    Dim udtRet As RetPopup
    '    Dim strMessage As String
    '    strMessage = ""
    '    strMessage &= $$$$$$$$$$$$$$$$$$$$$
    '    udtRet = DisplayPopup(strMessage, PopupFormType.Ok_Cancel, PopupIconType.Quest)
    '    If udtRet <> RetPopup.OK Then
    '        Exit Sub
    '    End If


    '    '*******************************************************
    '    'ﾊﾟﾗﾒｰﾀﾃｰﾌﾞﾙに追加する電文配列作成
    '    '*******************************************************
    '    Dim strSendTel() As String = Nothing
    '    For ii As Integer = 1 To grdList.Rows.Count - 1
    '        '(展開元画面の行分ﾙｰﾌﾟ)

    '        If IsNull(strSendTel) = True Then ReDim Preserve strSendTel(0) Else ReDim Preserve strSendTel(UBound(strSendTel) + 1)


    '        '*******************************************************
    '        ' 電文作成
    '        '*******************************************************
    '        '========================================
    '        ' 変数宣言
    '        '========================================
    '        Dim objTelegramSub As New clsTelegram(CONFIG_TELEGRAM_DSP)
    '        Dim str$$$$$$$$$$ As String = ""         '
    '        Dim str$$$$$$$$$$ As String = ""         '
    '        Dim str$$$$$$$$$$ As String = ""         '
    '        Dim str$$$$$$$$$$ As String = ""         '
    '        objTelegramSub.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_$$$$$$           'ﾌｫｰﾏｯﾄ名ｾｯﾄ
    '        str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '
    '        str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '
    '        str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '
    '        str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '

    '        Dim strDSPCMD_ID As String = ""
    '        strDSPCMD_ID = objTelegramSub.FORMAT_ID.Substring(objTelegramSub.FORMAT_ID.Length - 6, 6)
    '        'ﾍｯﾀﾞﾃﾞｰﾀ
    '        objTelegramSub.SETIN_HEADER("DSPCMD_ID", strDSPCMD_ID)              'ｺﾏﾝﾄﾞID
    '        objTelegramSub.SETIN_HEADER("DSPTERM_ID", gcstrFTERM_ID)            '端末ID
    '        objTelegramSub.SETIN_HEADER("DSPUSER_ID", gcstrFUSER_ID)            'ﾕｰｻﾞID
    '        'ﾃﾞｰﾀ
    '        objTelegramSub.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '
    '        objTelegramSub.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '
    '        objTelegramSub.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '
    '        objTelegramSub.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '
    '        objTelegramSub.MAKE_TELEGRAM()

    '        strSendTel(UBound(strSendTel)) = objTelegramSub.TELEGRAM_MAKED
    '    Next


    '    '*******************************************************
    '    ' 電文作成
    '    '*******************************************************
    '    '========================================
    '    ' 変数宣言
    '    '========================================
    '    Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
    '    Dim str$$$$$$$$$$ As String = ""         '
    '    Dim str$$$$$$$$$$ As String = ""         '
    '    Dim str$$$$$$$$$$ As String = ""         '
    '    Dim str$$$$$$$$$$ As String = ""         '
    '    objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_$$$$$$           'ﾌｫｰﾏｯﾄ名ｾｯﾄ
    '    str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '
    '    str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '
    '    str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '
    '    str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '


    '    objTelegram.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '
    '    objTelegram.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '
    '    objTelegram.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '
    '    objTelegram.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '

    '    Dim strRET_STATE As String = ""
    '    Dim udtSckSendRET As clsSocketClient.RetCode    'ｿｹｯﾄ送信戻り値
    '    Dim strErrMsg As String                         'ｴﾗｰﾒｯｾｰｼﾞ

    '    strErrMsg = $$$$$$$$$$$$$$$$$$$$$
    '    udtSckSendRET = gobjComFuncFRM.SockSendServer02(objTelegram, strSendTel, strRET_STATE)   'ｿｹｯﾄ送信
    '    If udtSckSendRET = clsSocketClient.RetCode.OK Then
    '        '(送信できた場合)
    '        If strRET_STATE = ID_RETURN_RET_STATE_OK Then
    '            '(正常終了の場合)

    '            Me.DialogResult = Windows.Forms.DialogResult.OK

    '            Me.Close()
    '            Me.Dispose()
    '        Else
    '            '(処理が異常終了した場合)
    '            Call DisplayPopup(strErrMsg, _
    '                              PopupFormType.Ok, _
    '                              PopupIconType.Err)
    '        End If
    '    ElseIf udtSckSendRET = clsSocketClient.RetCode.ReceiveTimeOut Then
    '        '(ﾀｲﾑｱｳﾄの場合)
    '    Else
    '        '(その他の場合)
    '        Call DisplayPopup(strErrMsg, _
    '                          PopupFormType.Ok, _
    '                          PopupIconType.Err)
    '    End If


    'End Sub
#End Region

End Class
