'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�zү���ފm�F���
' �y�쐬�zSIT
'**********************************************************************************************

#Region "�@Imports�@                                "
Imports MateCommon
Imports MateCommon.clsConst
Imports UserProcess
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_209000

#Region "  ���ʕϐ��@                               "

    Enum menmListCol
        FLOG_CHECK_FLAG     'ү����۸�.�m�F�ς��׸�
        FLOG_CHECK_FLAG_disp     'ү����۸�.�m�F�ς��׸�(�\���p)
        FHASSEI_DT          'ү����۸�.��������
        FMSG_NAIYOU         'ү����Ͻ�.����
        FMSG_PRM1           'ү����۸�.���Ұ�1
        FMSG_PRM2           'ү����۸�.���Ұ�2
        FMSG_PRM3           'ү����۸�.���Ұ�3
        FMSG_PRM4           'ү����۸�.���Ұ�4
        FMSG_PRM5           'ү����۸�.���Ұ�5
        FLOG_NO             'ү����۸�.۸�No
        FMSG_ID             'ү����۸�.ү����ID

        MAXCOL

    End Enum

#End Region
#Region "  ̫��۰�ށ@                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̫��۰��
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub InitializeChild()

        '**********************************************************
        ' ���ݐݒ�
        '**********************************************************
        Call CmdEnabledChangeMenu()                             'Menu���ݑS��
        Call CmdEnabledChange(cmdClose, False)                  '۸޵�����
        Call CmdEnabledChange(cmdMsgChk, False)                 '�ż�������

        '*********************************************
        ' ��د�ޕ\��
        '*********************************************
        Call gobjComFuncFRM.FlexGridInitialize(grdList, 1, menmListCol.MAXCOL)  '��د�ޏ����ݒ�
        Call grdListDisplaySub(grdList)


    End Sub
#End Region
#Region "  F1(�\���X�V)  ���݉��������@             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F1(�\���X�V) ���݉�������
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F1Process()
        Try
            '*******************************************************
            '��د�ޕ\��
            '*******************************************************
            Call grdListDisplaySub(grdList)


            '*******************************************************
            '���ڰ���ү���ލX�V
            '*******************************************************
            Call GetLogMessage()


        Catch ex As Exception
            ComError(ex)
            Throw ex

        End Try
    End Sub
#End Region
#Region "  F4(�I���m�F)  ���݉��������@             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F4(�I���m�F) ���݉�������
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F4Process()

        '*******************************************************
        '�I���m�F���đ��M     
        '*******************************************************
        Call SendSocket01()


        '*******************************************************
        '��د�ލĕ\��
        '*******************************************************
        Call grdListDisplaySub(grdList)


        '*******************************************************
        '���ڰ���ү���ލX�V
        '*******************************************************
        Call GetLogMessage()


    End Sub
#End Region
#Region "  F5(�ꊇ�m�F)  ���݉��������@             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F5(�ꊇ�m�F) ���݉�������
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F5Process()

        '*******************************************************
        '�ꊇ�m�F���đ��M     
        '*******************************************************
        Call SendSocket02()


        '*******************************************************
        '��د�ލĕ\��
        '*******************************************************
        Call grdListDisplaySub(grdList)


        '*******************************************************
        '���ڰ���ү���ލX�V
        '*******************************************************
        Call GetLogMessage()


    End Sub
#End Region
#Region "  F8(�߂�)  ���݉��������@                 "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F8(�߂�) ���݉�������
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub F8Process()

        '*******************************************************
        '���g�۰��
        '*******************************************************
        Me.Close()
        Me.Dispose()


    End Sub
#End Region
#Region "  ��د�ޕ\���@                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��د�ޕ\��
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Public Overrides Sub grdListDisplayChild()

        Dim strSQL As String                    'SQL��


        '********************************************************************
        ' SQL���쐬
        '********************************************************************
        strSQL = ""
        strSQL &= vbCrLf & "SELECT "
        strSQL &= vbCrLf & "    TLOG_MESSAGE.FLOG_CHECK_FLAG FLOG_CHECK_FLAG "  'ү����۸�.�m�F�ς��׸�
        strSQL &= vbCrLf & "  , HASH01.FGAMEN_DISP "                            'ү����۸�.�m�F�ς��׸�(�\���p)
        strSQL &= vbCrLf & "  , TLOG_MESSAGE.FHASSEI_DT FHASSEI_DT "            'ү����۸�.��������
        strSQL &= vbCrLf & "  , TMST_MESSAGE.FMSG_NAIYOU FMSG_NAIYOU "          'ү����Ͻ�.����
        strSQL &= vbCrLf & "  , TLOG_MESSAGE.FMSG_PRM1 FMSG_PRM1 "              'ү����۸�.���Ұ�1
        strSQL &= vbCrLf & "  , TLOG_MESSAGE.FMSG_PRM2 FMSG_PRM2 "              'ү����۸�.���Ұ�2
        strSQL &= vbCrLf & "  , TLOG_MESSAGE.FMSG_PRM3 FMSG_PRM3 "              'ү����۸�.���Ұ�3
        strSQL &= vbCrLf & "  , TLOG_MESSAGE.FMSG_PRM4 FMSG_PRM4 "              'ү����۸�.���Ұ�4
        strSQL &= vbCrLf & "  , TLOG_MESSAGE.FMSG_PRM5 FMSG_PRM5 "              'ү����۸�.���Ұ�5
        strSQL &= vbCrLf & "  , TLOG_MESSAGE.FLOG_NO FLOG_NO "                  'ү����۸�.۸�No
        strSQL &= vbCrLf & "  , TLOG_MESSAGE.FMSG_ID FMSG_ID "                  'ү����۸�.ү����ID
        strSQL &= vbCrLf & " FROM "
        strSQL &= vbCrLf & "    TLOG_MESSAGE "                                  'ү����۸�
        strSQL &= vbCrLf & "    ,TMST_MESSAGE "                                 'ү����Ͻ� 
        strSQL &= vbCrLf & "     ," & gobjComFuncFRM.GetSQLHashTableFrom01("HASH01", "TLOG_MESSAGE", "FLOG_CHECK_FLAG")
        strSQL &= vbCrLf & " WHERE 0 = 0 "
        strSQL &= vbCrLf & "    AND TLOG_MESSAGE.FMSG_ID = TMST_MESSAGE.FMSG_ID "
        strSQL &= vbCrLf & "    AND " & gobjComFuncFRM.GetSQLHashTableWhere01("HASH01", "TLOG_MESSAGE", "FLOG_CHECK_FLAG")
        strSQL &= vbCrLf & " ORDER BY  "
        strSQL &= vbCrLf & "    TLOG_MESSAGE.FLOG_NO DESC"            '۸�No


        '********************************************************************
        '��د�ޕ\��
        '********************************************************************
        Call gobjComFuncFRM.TblDataGridDisplay(grdList, strSQL, False)


        '********************************************************************
        '��د�ޕ\���ݒ�
        '********************************************************************
        Call grdListSetup()
        Call gobjComFuncFRM.GridSelect(grdList, -1, -1, Nothing)      '��د�ޑI������


    End Sub
#End Region
#Region "  ��د�ޕ\���ݒ�@                         "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ��د�ޕ\���ݒ�
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub grdListSetup()

        '************************************************
        '��د��Ͻ��̒�`�𔽉f
        '************************************************
        Call gobjComFuncFRM.TDSP_GRIDSetup(Me, grdList)

    End Sub
#End Region
#Region "  ���đ��M01                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���đ��M01
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SendSocket01()

        '*******************************************************
        '��������
        '*******************************************************
        If grdList.SelectedRows.Count < 1 Then
            '�����
            Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM1101_01, PopupFormType.Ok, PopupIconType.Information)
            Exit Sub
        End If

        '*******************************************************
        '�m�Fү����
        '*******************************************************
        Dim udtRet As RetPopup
        udtRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM1101_51, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Sub
        End If

        '*******************************************************
        '���đ��M����
        '*******************************************************
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200101        '̫�ϯĖ����

        objTelegram.SETIN_DATA("DSPLOG_NO", grdList.Item(menmListCol.FLOG_NO, grdList.SelectedRows(0).Index).Value)            '۸�No
        objTelegram.SETIN_DATA("DSPMSG_ID", grdList.Item(menmListCol.FMSG_ID, grdList.SelectedRows(0).Index).Value)            'ү����ID

        Call gobjComFuncFRM.SockSendServer01(objTelegram, "")        '���đ��M


    End Sub
#End Region
#Region "  ���đ��M02                               "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���đ��M02
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SendSocket02()

        '*******************************************************
        '�m�Fү����
        '*******************************************************
        Dim udtRet As RetPopup
        udtRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM1101_52, PopupFormType.Ok_Cancel, PopupIconType.Quest)
        If udtRet <> RetPopup.OK Then
            Exit Sub
        End If

        '*******************************************************
        '���đ��M����
        '*******************************************************
        Dim objTelegram As New clsTelegram(CONFIG_TELEGRAM_DSP)
        objTelegram.FORMAT_ID = FORMAT_DSP_PRI & FSYORI_ID_S200101        '̫�ϯĖ����

        objTelegram.SETIN_DATA("DSPLOG_NO", CBO_ALL_VALUE)            '۸�No

        Call gobjComFuncFRM.SockSendServer01(objTelegram, "")                          '���đ��M

    End Sub
#End Region

End Class
