'**********************************************************************************************
' Copyright(C) Kanazawa System House Corporation
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z��ʻ����ҿ��ޏW
' �y�쐬�zKSH
'**********************************************************************************************

#Region "�@Imports                                  "
Imports MateCommon
Imports MateCommon.clsConst
Imports GamenMate.clsComFuncFRM
Imports UserProcess
#End Region

Public Class cls999999

#Region "  ���đ��M̫�ϯ�(�e��ʂő��M�̏ꍇ)           "
    ''''*******************************************************************************************************************
    '''' <summary>
    '''' ���đ��M
    '''' </summary>
    '''' <returns></returns>
    '''' <remarks></remarks>
    ''''*******************************************************************************************************************
    'Private Function SendSocket01() As Boolean

    '    Dim blnRet As Boolean = False

    '    '*******************************************************
    '    '�m�Fү����
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
    '    '���đ��M����
    '    '*******************************************************
    '    '========================================
    '    ' �ϐ��錾
    '    '========================================
    '    Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
    '    Dim str$$$$$$$$$$ As String = ""         '
    '    Dim str$$$$$$$$$$ As String = ""         '
    '    Dim str$$$$$$$$$$ As String = ""         '
    '    Dim str$$$$$$$$$$ As String = ""         '
    '    objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_$$$$$$           '̫�ϯĖ����
    '    str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '
    '    str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '
    '    str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '
    '    str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '


    '    objTelegram.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '
    '    objTelegram.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '
    '    objTelegram.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '
    '    objTelegram.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '


    '    Dim strRET_STATE As String = ""
    '    Dim udtSckSendRET As clsSocketClient.RetCode    '���đ��M�߂�l
    '    Dim strErrMsg As String                         '�װү����

    '    strErrMsg = $$$$$$$$$$$$$$$$$$$$$
    '    udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE)   '���đ��M
    '    If udtSckSendRET = clsSocketClient.RetCode.OK Then
    '        '(���M�ł����ꍇ)
    '        If strRET_STATE = ID_RETURN_RET_STATE_OK Then
    '            '(����I���̏ꍇ)
    '            blnRet = True
    '        Else
    '            '(�������ُ�I�������ꍇ)
    '            Call gobjComFuncFRM.DisplayPopup(strErrMsg, _
    '                              PopupFormType.Ok, _
    '                              PopupIconType.Err)
    '        End If
    '    ElseIf udtSckSendRET = clsSocketClient.RetCode.ReceiveTimeOut Then
    '        '(��ѱ�Ă̏ꍇ)
    '    Else
    '        '(���̑��̏ꍇ)
    '        Call gobjComFuncFRM.DisplayPopup(strErrMsg, _
    '                          PopupFormType.Ok, _
    '                          PopupIconType.Err)
    '    End If

    '    Return blnRet

    'End Function

#End Region
#Region "  ���đ��M̫�ϯ�(�q��ʂő��M�̏ꍇ)           "
    ''''*******************************************************************************************************************
    '''' <summary>
    '''' ���đ��M
    '''' </summary>
    '''' <remarks></remarks>
    ''''*******************************************************************************************************************
    'Private Sub SendSocket01()


    '    '*******************************************************
    '    '�m�Fү����
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
    '    '���đ��M����
    '    '*******************************************************
    '    '========================================
    '    ' �ϐ��錾
    '    '========================================
    '    Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
    '    Dim str$$$$$$$$$$ As String = ""         '
    '    Dim str$$$$$$$$$$ As String = ""         '
    '    Dim str$$$$$$$$$$ As String = ""         '
    '    Dim str$$$$$$$$$$ As String = ""         '
    '    objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_$$$$$$           '̫�ϯĖ����
    '    str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '
    '    str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '
    '    str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '
    '    str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '


    '    objTelegram.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '
    '    objTelegram.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '
    '    objTelegram.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '
    '    objTelegram.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '


    '    Dim strRET_STATE As String = ""
    '    Dim udtSckSendRET As clsSocketClient.RetCode    '���đ��M�߂�l
    '    Dim strErrMsg As String                         '�װү����

    '    strErrMsg = $$$$$$$$$$$$$$$$$$$$$
    '    udtSckSendRET = gobjComFuncFRM.SockSendServer01(objTelegram, strRET_STATE)   '���đ��M
    '    If udtSckSendRET = clsSocketClient.RetCode.OK Then
    '        '(���M�ł����ꍇ)
    '        If strRET_STATE = ID_RETURN_RET_STATE_OK Then
    '            '(����I���̏ꍇ)
    '            Me.DialogResult = Windows.Forms.DialogResult.OK

    '            Me.Close()
    '            Me.Dispose()

    '        Else
    '            '(�������ُ�I�������ꍇ)
    '            Call DisplayPopup(strErrMsg, _
    '                              PopupFormType.Ok, _
    '                              PopupIconType.Err)
    '        End If
    '    ElseIf udtSckSendRET = clsSocketClient.RetCode.ReceiveTimeOut Then
    '        '(��ѱ�Ă̏ꍇ)
    '    Else
    '        '(���̑��̏ꍇ)
    '        Call DisplayPopup(strErrMsg, _
    '                          PopupFormType.Ok, _
    '                          PopupIconType.Err)
    '    End If


    'End Sub
#End Region
#Region "  ���đ��M̫�ϯ�(�������đ��M)(�e��ʂő��M�̏ꍇ)     "
    ''''*******************************************************************************************************************
    '''' <summary>
    '''' ���đ��M
    '''' </summary>
    '''' <remarks></remarks>
    ''''*******************************************************************************************************************
    'Private Function SendSocket01() As Boolean

    '    Dim blnRet As Boolean = False

    '    '*******************************************************
    '    '�m�Fү����
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
    '    '���Ұ�ð��قɒǉ�����d���z��쐬
    '    '*******************************************************
    '    Dim strSendTel() As String = Nothing
    '    For ii As Integer = 1 To grdList.Rows.Count - 1
    '        '(�W�J����ʂ̍s��ٰ��)

    '        If IsNull(strSendTel) = True Then ReDim Preserve strSendTel(0) Else ReDim Preserve strSendTel(UBound(strSendTel) + 1)


    '        '*******************************************************
    '        ' �d���쐬
    '        '*******************************************************
    '        '========================================
    '        ' �ϐ��錾
    '        '========================================
    '        Dim objTelegramSub As New clsTelegram(CONFIG_TELEGRAM_DSP)
    '        Dim str$$$$$$$$$$ As String = ""         '
    '        Dim str$$$$$$$$$$ As String = ""         '
    '        Dim str$$$$$$$$$$ As String = ""         '
    '        Dim str$$$$$$$$$$ As String = ""         '
    '        objTelegramSub.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_$$$$$$           '̫�ϯĖ����
    '        str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '
    '        str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '
    '        str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '
    '        str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '

    '        Dim strDSPCMD_ID As String = ""
    '        strDSPCMD_ID = objTelegramSub.FORMAT_ID.Substring(objTelegramSub.FORMAT_ID.Length - 6, 6)
    '        'ͯ���ް�
    '        objTelegramSub.SETIN_HEADER("DSPCMD_ID", strDSPCMD_ID)              '�����ID
    '        objTelegramSub.SETIN_HEADER("DSPTERM_ID", gcstrFTERM_ID)            '�[��ID
    '        objTelegramSub.SETIN_HEADER("DSPUSER_ID", gcstrFUSER_ID)            'հ��ID
    '        '�ް�
    '        objTelegramSub.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '
    '        objTelegramSub.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '
    '        objTelegramSub.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '
    '        objTelegramSub.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '
    '        objTelegramSub.MAKE_TELEGRAM()

    '        strSendTel(UBound(strSendTel)) = objTelegramSub.TELEGRAM_MAKED
    '    Next


    '    '*******************************************************
    '    ' �d���쐬
    '    '*******************************************************
    '    '========================================
    '    ' �ϐ��錾
    '    '========================================
    '    Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
    '    Dim str$$$$$$$$$$ As String = ""         '
    '    Dim str$$$$$$$$$$ As String = ""         '
    '    Dim str$$$$$$$$$$ As String = ""         '
    '    Dim str$$$$$$$$$$ As String = ""         '
    '    objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_$$$$$$           '̫�ϯĖ����
    '    str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '
    '    str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '
    '    str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '
    '    str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '


    '    objTelegram.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '
    '    objTelegram.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '
    '    objTelegram.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '
    '    objTelegram.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '

    '    Dim strRET_STATE As String = ""
    '    Dim udtSckSendRET As clsSocketClient.RetCode    '���đ��M�߂�l
    '    Dim strErrMsg As String                         '�װү����

    '    strErrMsg = $$$$$$$$$$$$$$$$$$$$$
    '    udtSckSendRET = gobjComFuncFRM.SockSendServer02(objTelegram, strSendTel, strRET_STATE)   '���đ��M
    '    If udtSckSendRET = clsSocketClient.RetCode.OK Then
    '        '        '(���M�ł����ꍇ)
    '        If strRET_STATE = ID_RETURN_RET_STATE_OK Then
    '            '(����I���̏ꍇ)
    '            blnRet = True
    '        Else
    '            '(�������ُ�I�������ꍇ)
    '            Call DisplayPopup(strErrMsg, _
    '                              PopupFormType.Ok, _
    '                              PopupIconType.Err)
    '        End If
    '    ElseIf udtSckSendRET = clsSocketClient.RetCode.ReceiveTimeOut Then
    '        '(��ѱ�Ă̏ꍇ)
    '    Else
    '        '(���̑��̏ꍇ)
    '        Call DisplayPopup(strErrMsg, _
    '                          PopupFormType.Ok, _
    '                          PopupIconType.Err)
    '    End If

    '    Return blnRet

    'End Sub
#End Region
#Region "  ���đ��M̫�ϯ�(�������đ��M)(�q��ʂő��M�̏ꍇ)     "
    ''''*******************************************************************************************************************
    '''' <summary>
    '''' ���đ��M
    '''' </summary>
    '''' <remarks></remarks>
    ''''*******************************************************************************************************************
    'Private Sub SendSocket01()


    '    '*******************************************************
    '    '�m�Fү����
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
    '    '���Ұ�ð��قɒǉ�����d���z��쐬
    '    '*******************************************************
    '    Dim strSendTel() As String = Nothing
    '    For ii As Integer = 1 To grdList.Rows.Count - 1
    '        '(�W�J����ʂ̍s��ٰ��)

    '        If IsNull(strSendTel) = True Then ReDim Preserve strSendTel(0) Else ReDim Preserve strSendTel(UBound(strSendTel) + 1)


    '        '*******************************************************
    '        ' �d���쐬
    '        '*******************************************************
    '        '========================================
    '        ' �ϐ��錾
    '        '========================================
    '        Dim objTelegramSub As New clsTelegram(CONFIG_TELEGRAM_DSP)
    '        Dim str$$$$$$$$$$ As String = ""         '
    '        Dim str$$$$$$$$$$ As String = ""         '
    '        Dim str$$$$$$$$$$ As String = ""         '
    '        Dim str$$$$$$$$$$ As String = ""         '
    '        objTelegramSub.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_$$$$$$           '̫�ϯĖ����
    '        str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '
    '        str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '
    '        str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '
    '        str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '

    '        Dim strDSPCMD_ID As String = ""
    '        strDSPCMD_ID = objTelegramSub.FORMAT_ID.Substring(objTelegramSub.FORMAT_ID.Length - 6, 6)
    '        'ͯ���ް�
    '        objTelegramSub.SETIN_HEADER("DSPCMD_ID", strDSPCMD_ID)              '�����ID
    '        objTelegramSub.SETIN_HEADER("DSPTERM_ID", gcstrFTERM_ID)            '�[��ID
    '        objTelegramSub.SETIN_HEADER("DSPUSER_ID", gcstrFUSER_ID)            'հ��ID
    '        '�ް�
    '        objTelegramSub.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '
    '        objTelegramSub.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '
    '        objTelegramSub.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '
    '        objTelegramSub.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '
    '        objTelegramSub.MAKE_TELEGRAM()

    '        strSendTel(UBound(strSendTel)) = objTelegramSub.TELEGRAM_MAKED
    '    Next


    '    '*******************************************************
    '    ' �d���쐬
    '    '*******************************************************
    '    '========================================
    '    ' �ϐ��錾
    '    '========================================
    '    Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
    '    Dim str$$$$$$$$$$ As String = ""         '
    '    Dim str$$$$$$$$$$ As String = ""         '
    '    Dim str$$$$$$$$$$ As String = ""         '
    '    Dim str$$$$$$$$$$ As String = ""         '
    '    objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_$$$$$$           '̫�ϯĖ����
    '    str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '
    '    str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '
    '    str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '
    '    str$$$$$$$$$$ = TO_STRING($$$$$$$$$$$$$$$$$$$$$$$$)                            '


    '    objTelegram.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '
    '    objTelegram.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '
    '    objTelegram.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '
    '    objTelegram.SETIN_DATA("DSP$$$$$$$$$$", str$$$$$$$$$$)                '

    '    Dim strRET_STATE As String = ""
    '    Dim udtSckSendRET As clsSocketClient.RetCode    '���đ��M�߂�l
    '    Dim strErrMsg As String                         '�װү����

    '    strErrMsg = $$$$$$$$$$$$$$$$$$$$$
    '    udtSckSendRET = gobjComFuncFRM.SockSendServer02(objTelegram, strSendTel, strRET_STATE)   '���đ��M
    '    If udtSckSendRET = clsSocketClient.RetCode.OK Then
    '        '(���M�ł����ꍇ)
    '        If strRET_STATE = ID_RETURN_RET_STATE_OK Then
    '            '(����I���̏ꍇ)

    '            Me.DialogResult = Windows.Forms.DialogResult.OK

    '            Me.Close()
    '            Me.Dispose()
    '        Else
    '            '(�������ُ�I�������ꍇ)
    '            Call DisplayPopup(strErrMsg, _
    '                              PopupFormType.Ok, _
    '                              PopupIconType.Err)
    '        End If
    '    ElseIf udtSckSendRET = clsSocketClient.RetCode.ReceiveTimeOut Then
    '        '(��ѱ�Ă̏ꍇ)
    '    Else
    '        '(���̑��̏ꍇ)
    '        Call DisplayPopup(strErrMsg, _
    '                          PopupFormType.Ok, _
    '                          PopupIconType.Err)
    '    End If


    'End Sub
#End Region

End Class
