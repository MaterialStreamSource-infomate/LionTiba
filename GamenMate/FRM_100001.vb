'**********************************************************************************************
' Copyright(C) SHIBUYA IT SOLUTION CO.,LTD.
' All Rights Reserved
'
' �y���́z��رٽ�ذѕW���@�\
' �y�@�\�z۸޲݉��
' �y�쐬�zSIT
'**********************************************************************************************

#Region "  Imports      "
Imports MateCommon
Imports MateCommon.clsConst
Imports JobCommon
Imports UserProcess
Imports GamenMate.clsComFuncFRM
#End Region

Public Class FRM_100001

#Region "  ���ʕϐ�         "
    Private mobjThread As System.Threading.Thread
#End Region
#Region "  �����                                "
#Region "  ̫��۰��                             "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ̫��۰�޲����
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub frmCR2001_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Call frmLoad()

        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)
            Throw New System.Exception(ex.Message)

        End Try
    End Sub
#End Region
#Region "  ̧ݸ��ݷ�����            KeyDown     "
    ''' *******************************************************************************************************************
    ''' <summary>
    '''  ̧ݸ��ݷ�����
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub frmCR2001_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try

            Select Case e.KeyCode
                Case Windows.Forms.Keys.F1
                    cmdF1_Proc()
                Case Windows.Forms.Keys.F8
                    cmdF8_Proc()
            End Select

        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "  ���۰����݉���                       "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F1���ݸد�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdF1.Click
        Try

            cmdF1_Proc()

        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub


    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F8���ݸد�
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdF8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdF8.Click
        Try

            cmdF8_Proc()

        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "  հ�ްID�ύX           Validated   "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' հ�ްID�ύX
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub txtFLOGIN_ID_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFLOGIN_ID.Validated
        Try

            Call Change_EmpCd()

        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "  հ�ްID�ύX           KeyDown     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' հ�ްID�ύX
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub txtFLOGIN_ID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFLOGIN_ID.KeyDown
        Try

            If e.KeyCode = Windows.Forms.Keys.Enter Then
                txtFPASS_WORD.Focus()
            End If

        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "�@�߽ܰ�ޓ���              KeyDown     "

    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �߽ܰ�ޓ���
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub txtFPASS_WORD_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFPASS_WORD.KeyDown
        Try

            If e.KeyCode = Windows.Forms.Keys.Enter Then
                If txtReFPASS_WORD.Enabled = False Then
                    cmdF1.Focus()
                Else
                    txtReFPASS_WORD.Focus()
                End If
            End If
        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "  �߽ܰ�ލē���            KeyDown     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �߽ܰ�ލē���
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub txtReFPASS_WORD_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtReFPASS_WORD.KeyDown
        Try

            If e.KeyCode = Windows.Forms.Keys.Enter Then
                cmdF1.Focus()
            End If
        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)

        End Try
    End Sub
#End Region
#Region "  �ύX���݉�������                     "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �ύX���݉�������
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdPassChng_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPassChng.Click
        Try

            Call Change_Pass()

        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)

        End Try

    End Sub
#End Region
#End Region
#Region "  ̫��۰�ޏ���                         "
    Private Sub frmLoad()
        Try

            '**********************************************************
            ' ۸޵��׸�True
            '**********************************************************
            gblnLogoff = True           '۸޵̏��

            '**************************************************************************
            ' �׸ِڑ�
            '**************************************************************************
            '==========================================
            'Config�擾
            '==========================================
            Dim objSystem As clsConnectConfig
            objSystem = New clsConnectConfig(CONFIG_FILE)                ' Confiģ�ِڑ��׽�i��ʗpConfig�j

            '==========================================
            'DB�ڑ�
            '==========================================
            Dim blnRet As Boolean
            gobjDb = New clsConn
            gobjDb.ConnectString = objSystem.GET_INFO(GKEY_CONNECT_STRING)
            blnRet = gobjDb.Connect()     '�ڑ�
            If blnRet = False Then
                Throw New Exception("DB�ڑ��Ɏ��s���܂����B")
            End If


            '**********************************************************
            'Config & ���ѕϐ�  �ް��擾
            '**********************************************************
            '��ϰ�p
            gcinttmrTime_Interval = TO_NUMBER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_002))             '�����\��                 ��ϰ
            gcinttmrBlink_Interval = TO_NUMBER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_003))            '���ݓ_�ŗp               ��ϰ
            gcinttmrOpeMsg_Interval = TO_NUMBER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_004))           '���ڰ���ү���ގ擾       ��ϰ
            gcinttmrTest_1_Interval = TO_NUMBER(gobjComFuncFRM.GET_CONFIG_INFO(GKEY_tmrTest_1_Interval))   '��ʑJ��ýėp            ��ϰ

            '���۸ޗp
            gcstrLOG_FILE_NAME = gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_005)                           '̧�ٖ�
            gcstrLOG_FILE_NAME_OLD = gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_006)                       '̧�ٖ�(�Â�)
            gcstrLOG_FILE_SIZE = gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_007)                           '�ő�̧�ٻ���
            gcstrLOG_FILE_SIZE = TO_NUMBER(gcstrLOG_FILE_SIZE) * 1000000                                    'Byte �� MByte
            gcstrLOG_FILE_PATH = gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_031)                           '̧�يi�[�ꏊ

            '���ėp
            gcstrSOCK_SEND_ADDRESS = gobjComFuncFRM.GET_CONFIG_INFO(GKEY_SOCK_SEND_ADDRESS)                '���M����ڽ
            gcstrSOCK_SEND_PORT = gobjComFuncFRM.GET_CONFIG_INFO(GKEY_SOCK_SEND_PORT)                      '���M���߰�No
            gcstrSOCK_SEND_TIME_OUT = gobjComFuncFRM.GET_CONFIG_INFO(GKEY_SOCK_SEND_TIME_OUT)              '�������đҋ@����

            '���̑�
            gcintDisp_INTMSG_LEVEL = TO_NUMBER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_010))            '�\������ү��������
            gcstrTMRTEST_1 = gobjComFuncFRM.GET_CONFIG_INFO(GKEY_TMRTEST_1_FLG)                            '��ʑJ��ýėp            ��ϰ�׸�
            gcstrPRINT_FLG = gobjComFuncFRM.GET_CONFIG_INFO(GKEY_PRINT_FLG)                                '��                     �׸�
            gcstrDEGUB_FLG = gobjComFuncFRM.GET_CONFIG_INFO(GKEY_DEGUB_FLG)                                '���ޯ��                  �׸�
            gcintDSPLOGIN_FLG = TO_NUMBER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_013))                 '۸޲݉�ʕ\���׸�        �׸�
            gcintDSPLOGOFF = TO_NUMBER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_014))                    '۸޵���ѱ��(sec)
            gcintOPE_FLG = TO_NUMBER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_015))
            gcintLOGIN_SVR_USE_FLG = TO_NUMBER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_019))            '۸޲ݎ�������۾��g�p       �׸�
            gcintAfkFlg = TO_NUMBER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_024))                       '���ȏ����L��               �׸�
            gcintPASSWORD_KETA = TO_NUMBER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_025))                '�߽ܰ�ލŏ�����
            gcintPASSWORD_ENG = TO_NUMBER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_026))                 '�߽ܰ�މp�������׸�
            gcintPASSWORD_NUM = TO_NUMBER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_027))                 '�߽ܰ�ސ��l�����׸�
            gcintPASSWORD_KIGO = TO_NUMBER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_028))                '�߽ܰ�ދL�������׸�
            gcintPASSWORD_DAISHO = TO_NUMBER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_029))              '�߽ܰ�ޑ啶�������������׸�


            '*******************************************************
            ' �[�����擾
            '*******************************************************
            Dim udtRet As RetCode

            If gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_023) = 0 Then
                gcstrFTERM_ID = System.Net.Dns.GetHostName      '���߭�����擾
            Else
                gcstrFTERM_ID = System.Environment.UserName     'հ�ް���擾(�ӰĒ[���p)
            End If

            Dim TDSP_TERM As New TBL_TDSP_TERM(gobjOwner, gobjDb, Nothing)
            TDSP_TERM.FTERM_ID = gcstrFTERM_ID                          '�[��ID     ���
            udtRet = TDSP_TERM.GET_TDSP_TERM(False)                     '���擾
            If udtRet = RetCode.NotFound Then
                Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_03, PopupFormType.Ok, PopupIconType.Err)
                Me.Close()
            End If
            If TDSP_TERM.FTERM_CUT_STS = FTERM_CUT_STS_SON Then
                Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_11, PopupFormType.Ok, PopupIconType.Err)
                Me.Close()
            End If
            gcintFTERM_KBN = TO_INTEGER(TDSP_TERM.FTERM_KUBUN)                      '�[���敪   ���
            gcstrFTERM_NAME = TDSP_TERM.FTERM_NAME                      '�[������   ���


            '*******************************************************
            ' �N��۸ޏ�����
            '*******************************************************
            gobjComFuncFRM.AddToLog_frm(Application.ExecutablePath & "  �N��")


            '*******************************************************
            ' ��ʗp��Ű��޼ު�č쐬
            '*******************************************************
            gobjOwner = New GamenCommon.clsOwner                 ' ��ʗp��Ű��޼ު��


            '*******************************************************
            ' �N�����t�擾
            '*******************************************************
            gcdtmStart = Now


            '*******************************************************
            ' �F�X������
            '*******************************************************
            gobjGridDataTable05 = New GamenCommon.clsGridDataTable05    '��د�ޗp�ް�ð���
            gobjLocation = New Point(0, 0)                  '��ʈʒu


            '*******************************************************
            ' ��ʐݔ���ԕ\��Ͻ��@�̐F�ݒ�
            '*******************************************************
            '������������************************************************************************************************************
            'JobMate:A.Noto 2012/07/03 �F�ύX

            'gcLabelColor_Blue = Color.Blue                           ' DSP_EQ_STS �� INTCOLOR = 0 �̎��̐F�i�j
            'gcLabelColor_Red = Color.LawnGreen                       ' DSP_EQ_STS �� INTCOLOR = 1 �̎��̐F�i�ԁj
            'gcLabelColor_Yellow = Color.Yellow                       ' DSP_EQ_STS �� INTCOLOR = 2 �̎��̐F�i���j
            'gcLabelColor_Purple = Color.Purple                       ' DSP_EQ_STS �� INTCOLOR = 3 �̎��̐F�i���j
            'gcLabelColor_White = Color.White                         ' DSP_EQ_STS �� INTCOLOR = 4 �̎��̐F�i���j
            'gcLabelColor_Green = Color.Green                         ' DSP_EQ_STS �� INTCOLOR = 5 �̎��̐F�i�΁j
            'gcLabelColor_LightGreen = Color.Salmon                ' DSP_EQ_STS �� INTCOLOR = 6 �̎��̐F�i���΁j
            'gcLabelColor_Orange = Color.DarkOrange                   ' DSP_EQ_STS �� INTCOLOR = 7 �̎��̐F�i��j
            'gcLabelColor_Black = Color.Gray                          ' �װ���̐F�i���j

            gcLabelColor_Blue = Color.Blue                           ' DSP_EQ_STS �� INTCOLOR = 0 �̎��̐F�i�j
            gcLabelColor_Red = Color.Red                             ' DSP_EQ_STS �� INTCOLOR = 1 �̎��̐F�i�ԁj
            gcLabelColor_Yellow = Color.Yellow                       ' DSP_EQ_STS �� INTCOLOR = 2 �̎��̐F�i���j
            gcLabelColor_Purple = Color.Purple                       ' DSP_EQ_STS �� INTCOLOR = 3 �̎��̐F�i���j
            gcLabelColor_White = Color.White                         ' DSP_EQ_STS �� INTCOLOR = 4 �̎��̐F�i���j
            gcLabelColor_Green = Color.Green                         ' DSP_EQ_STS �� INTCOLOR = 5 �̎��̐F�i�΁j
            gcLabelColor_LightGreen = Color.LawnGreen                ' DSP_EQ_STS �� INTCOLOR = 6 �̎��̐F�i���΁j
            gcLabelColor_Orange = Color.DarkOrange                   ' DSP_EQ_STS �� INTCOLOR = 7 �̎��̐F�i��j
            gcLabelColor_Black = Color.Gray                          ' �װ���̐F�i���j
            '������������************************************************************************************************************

            '������������************************************************************************************************************
            'JobMate:A.Noto 2012/07/03 ���o��Ӱ�ނ̐F�ݒ�
            '*******************************************************
            ' ���o��Ӱ�ނ̐F�ݒ�
            '*******************************************************
            gcModeColor_IN = Color.LightGreen               ' (�΁@)����Ӱ��
            'gcModeColor_OUT = Color.LightPink               ' (���@)�o��Ӱ��
            gcModeColor_OUT = Color.Blue                    ' (�@)�o��Ӱ��
            gcModeColor_Black = Color.LightGray             ' (���@)

            gcModeColor_CUS_IN = Color.LightGreen           ' (�΁@)���ѐF ����Ӱ��
            gcModeColor_CUS_OUT = Color.LightBlue           ' (�@)���ѐF �o��Ӱ��
            gcModeColor_CUS_FUITHI = Color.Red              ' (�ԁ@)���ѐF Ӱ�ޕs��v
            '������������************************************************************************************************************

            '*******************************************************
            ' �߽ܰ�ލē���÷���ޯ��Enabled
            '*******************************************************
            txtReFPASS_WORD.Enabled = False

            Call gobjComFuncFRM.AddToLog_frm("LoadCR�گ�ފJ�n�B")
            mobjThread = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf LoadCR))
            mobjThread.IsBackground = True      '�ޯ���׳��ޥ�گ�ނƂ���
            mobjThread.Start()                  '�گ�ފJ�n


            '*******************************************************
            ' ����۸޲�
            '*******************************************************
            If gcintDSPLOGIN_FLG = FLAG_OFF Then
                '(۸޲݉�ʕs�v�̏ꍇ)

                Try
                    '==================================
                    ' ���۰ق��ް����
                    '==================================
                    txtFLOGIN_ID.Text = gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_016)         'հ�ްID
                    lblFUSER_NAME.Text = ""                                                     'հ�ް��
                    txtFPASS_WORD.Text = gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS000000_017)        '�߽ܰ��
                    txtFLOGIN_ID.Select()
                    cmdF1.Select()
                    Call cmdF1_Proc()

                Catch ex As Exception
                Finally
                    Me.Close()
                    Me.Dispose()
                End Try

            End If


        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)
            MsgBox(ex.Message)

        End Try
    End Sub
#End Region
#Region "  F1 (OK)          ���݉�������        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F1 (OK) ���݉�������
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdF1_Proc()
        Try

            Dim objTPRG_SYS_HEN As New TBL_TPRG_SYS_HEN(gobjOwner, gobjDb, Nothing)     '���ѕϐ�

            '**********************************************************
            ' հ�ްID��������
            '**********************************************************
            If txtFLOGIN_ID.Text = "" Then
                '(�߽ܰ�ނ����ݸ�̂Ƃ�)
                Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_10, _
                                PopupFormType.Ok, _
                                PopupIconType.Err)
                Exit Sub
            End If


            '**********************************************************
            ' ۸޲ݏ���
            '**********************************************************
            Select Case gcintLOGIN_SVR_USE_FLG      '۸޲ݎ�������۾��g�p�׸�
                Case FLAG_ON
                    '(������۾����g�p����۸޲݂���ꍇ)

                    '**********************************************************
                    ' �V�Kհ���߽ܰ������
                    '**********************************************************
                    If txtReFPASS_WORD.Enabled = True Then
                        '(�V�Kհ�ނ̂Ƃ�)
                        If txtFPASS_WORD.Text <> txtReFPASS_WORD.Text Then
                            '(�߽ܰ�ނ��߽ܰ�ލē��͂̓��͒l���قȂ�Ƃ�)
                            Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_06, _
                                            PopupFormType.Ok, _
                                            PopupIconType.Err)
                            txtFPASS_WORD.Focus()
                            Exit Sub
                        End If

                        If txtFPASS_WORD.Text = "" Then
                            '(�߽ܰ�ނ����ݸ�̂Ƃ�)
                            Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_07, _
                                            PopupFormType.Ok, _
                                            PopupIconType.Err)
                            txtFPASS_WORD.Focus()
                            Exit Sub
                        End If

                        If txtReFPASS_WORD.Text = "" Then
                            '(�߽ܰ�ލē��͂����ݸ�̂Ƃ�)
                            Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_07, _
                                            PopupFormType.Ok, _
                                            PopupIconType.Err)
                            Exit Sub
                            txtReFPASS_WORD.Focus()
                        End If

                        If txtReFPASS_WORD.Text = txtFLOGIN_ID.Text _
                       And objTPRG_SYS_HEN.SS000000_014 = FLAG_ON _
                       Then
                            '(�߽ܰ�ނ�հ��ID�������Ƃ�)
                            Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_16, _
                                            PopupFormType.Ok, _
                                            PopupIconType.Err)
                            txtFPASS_WORD.Focus()
                            Exit Sub
                        End If

                        If gcintPASSWORD_KETA > 0 Then
                            '(�߽ܰ�ލŏ�������0���傫���Ƃ�)
                            If (txtFPASS_WORD.Text).Length < gcintPASSWORD_KETA Then
                                '(�߽ܰ�ނ�6������菬�����Ƃ�)
                                Call gobjComFuncFRM.DisplayPopup(String.Format(FRM_MSG_FRM100001_12, gcintPASSWORD_KETA), _
                                                PopupFormType.Ok, _
                                                PopupIconType.Err)
                                txtFPASS_WORD.Focus()
                                Exit Sub
                            End If
                        End If

                        If gcintPASSWORD_ENG = FLAG_ON Then
                            '(�߽ܰ�މp�������׸ނ�ON�̂Ƃ�)
                            If System.Text.RegularExpressions.Regex.IsMatch(txtFPASS_WORD.Text, ".*[A-Za-z]") = False Then
                                '(�߽ܰ�ނɉp�����܂܂�Ă��Ȃ��Ƃ�)
                                Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_13, _
                                                PopupFormType.Ok, _
                                                PopupIconType.Err)
                                txtFPASS_WORD.Focus()
                                Exit Sub
                            End If
                        End If

                        If gcintPASSWORD_NUM = FLAG_ON Then
                            '(�߽ܰ�ސ��������׸ނ�ON�̂Ƃ�)
                            If System.Text.RegularExpressions.Regex.IsMatch(txtFPASS_WORD.Text, ".*[0-9]") = False Then
                                '(�߽ܰ�ނɐ������܂܂�Ă��Ȃ��Ƃ�)
                                Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_14, _
                                                PopupFormType.Ok, _
                                                PopupIconType.Err)
                                txtFPASS_WORD.Focus()
                                Exit Sub
                            End If
                        End If

                        If gcintPASSWORD_KIGO = FLAG_ON Then
                            '(�߽ܰ�ދL�������׸ނ�ON�̂Ƃ�)
                            If System.Text.RegularExpressions.Regex.IsMatch(txtFPASS_WORD.Text, ".*[^a-zA-Z0-9]") = False Then
                                '(�߽ܰ�ނɋL�����܂܂�Ă��Ȃ��Ƃ�)
                                Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_15, _
                                                PopupFormType.Ok, _
                                                PopupIconType.Err)
                                txtFPASS_WORD.Focus()
                                Exit Sub
                            End If
                        End If

                        If gcintPASSWORD_DAISHO = FLAG_ON Then
                            '(�߽ܰ�ޑ啶�������������׸ނ�ON�̂Ƃ�)
                            If System.Text.RegularExpressions.Regex.IsMatch(txtFPASS_WORD.Text, ".*[A-Z]") = False Then
                                '(�߽ܰ�ނɑ啶�����܂܂�Ă��Ȃ��Ƃ�)
                                Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_17, _
                                                PopupFormType.Ok, _
                                                PopupIconType.Err)
                                txtFPASS_WORD.Focus()
                                Exit Sub
                            End If

                            If System.Text.RegularExpressions.Regex.IsMatch(txtFPASS_WORD.Text, ".*[a-z]") = False Then
                                '(�߽ܰ�ނɏ��������܂܂�Ă��Ȃ��Ƃ�)
                                Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_18, _
                                                PopupFormType.Ok, _
                                                PopupIconType.Err)
                                txtFPASS_WORD.Focus()
                                Exit Sub
                            End If
                        End If

                    End If

                    '********************************************************************
                    '���đ��M����(�߽ܰ�ޓo�^����)
                    '********************************************************************
                    Call SendSocket01()


                Case FLAG_OFF
                    '(������۾����g�p���Ȃ���۸޲݂���ꍇ)
                    Call LogInProcess()    '۸޲ݏ�����

            End Select


        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)
            Throw New System.Exception(ex.Message)

        End Try
    End Sub
#End Region
#Region "  F8 (Close)       ���݉�������        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' F8 ��������
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub cmdF8_Proc()
        Try

            Dim udeRet As RetPopup

            '*******************************************************
            '�m�Fү����
            '*******************************************************
            udeRet = gobjComFuncFRM.DisplayPopup(FRM_MSG_SHUTDOWN, PopupFormType.Ok_Cancel, PopupIconType.Quest)
            If udeRet <> RetPopup.OK Then
                Exit Sub
            End If


            '*******************************************************
            '�����޳�or��ʸ۰�ޏ���
            '*******************************************************
            Dim intShutDownFlg As Integer
            Try
                intShutDownFlg = TO_INTEGER(gobjComFuncFRM.GetSYS_HEN(FHENSU_ID_SGS200000_001))
            Catch ex As Exception
                '(���ѕϐ��擾�Ŵװ���o���ꍇ)
                gobjComFuncFRM.ComError_frm(ex)
                intShutDownFlg = FLAG_OFF
            End Try

            If intShutDownFlg = FLAG_ON Then
                '(�����޳��׸ނ�ON�̏ꍇ)

                '----------------------------------------
                ' �����޳�
                '----------------------------------------
                Call PubF_ShutDown()            ' �����޳�

            Else
                '(�����޳��׸ނ�ON�ȊO�̏ꍇ)

                '----------------------------------------
                ' ��ʸ۰��
                '----------------------------------------
                If IsNull(gobjFRM_100001) = False Then
                    gobjFRM_100001.Close()
                    gobjFRM_100001.Dispose()
                    gobjFRM_100001 = Nothing
                End If
                Me.Close()
                Me.Dispose()

            End If


        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)
            Throw New System.Exception(ex.Message)

        End Try
    End Sub
#End Region
#Region "  հ�ް���\������                      "
    ''' ------------------------------------------------------------------------
    ''' <summary>
    ''' հ�ް���\������
    ''' </summary>
    ''' <remarks></remarks>
    ''' ------------------------------------------------------------------------
    Private Sub Change_EmpCd()
        Try

            Dim intRet As Integer       '�ߒl�p
            Dim objTMST_USER As New TBL_TMST_USER(gobjOwner, gobjDb, Nothing)


            '**********************************************************
            ' հ�ްID    ����
            '**********************************************************
            If Trim(txtFLOGIN_ID.Text) = "" Then
                lblFUSER_NAME.Text = ""
                txtReFPASS_WORD.Text = ""
                txtReFPASS_WORD.Enabled = False
                cmdPassChng.Enabled = True
                Exit Sub
            End If

            '**********************************************************
            ' հ�ް��      �\��
            '**********************************************************
            objTMST_USER.FUSER_ID = txtFLOGIN_ID.Text           'հ��ID
            intRet = objTMST_USER.GET_TMST_USER(False)          '���擾

            If intRet <> RetCode.OK Then
                lblFUSER_NAME.Text = ""                    'հ�ް��
                txtReFPASS_WORD.Text = ""
                txtReFPASS_WORD.Enabled = False
                cmdPassChng.Enabled = False
                txtFPASS_WORD.Focus()                      '�߽ܰ��÷���ޯ��  �I��
                Exit Sub
            End If

            lblFUSER_NAME.Text = objTMST_USER.FUSER_NAME    'հ�ް��
            txtFPASS_WORD.Focus()                          '�߽ܰ��÷���ޯ��  �I��


            '==================================
            ' �߽ܰ������
            '==================================
            If IsNull(objTMST_USER.FPASS_WORD) <> False Then
                '(�߽ܰ�ނ�NULL�̏ꍇ�A�V�Kհ��)
                txtReFPASS_WORD.Enabled = True
                cmdPassChng.Enabled = False
            Else
                txtReFPASS_WORD.Text = ""
                txtReFPASS_WORD.Enabled = False
                cmdPassChng.Enabled = True
            End If


        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)
            Throw New System.Exception(ex.Message)

        End Try
    End Sub
#End Region
#Region "  �߽ܰ�ޕύX����                      "
    ''' ------------------------------------------------------------------------
    ''' <summary>
    ''' �߽ܰ�ޕύX����
    ''' </summary>
    ''' <remarks></remarks>
    ''' ------------------------------------------------------------------------
    Private Sub Change_Pass()
        Try

            '**********************************************************
            ' հ�ްID��������
            '**********************************************************
            If txtFLOGIN_ID.Text = "" Then
                '(�߽ܰ�ނ����ݸ�̂Ƃ�)
                Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_10, _
                                PopupFormType.Ok, _
                                PopupIconType.Err)
                Exit Sub
            End If

            Dim intRet As Integer       '�ߒl�p
            '**********************************************************
            ' �߽ܰ������
            ' հ�ް�������َ擾
            '   �yհ�ްϽ��z
            '**********************************************************
            '==================================
            ' �߽ܰ�޹ޯ�
            '==================================
            Dim objTMST_USER_CHANGE As New TBL_TMST_USER(gobjOwner, gobjDb, Nothing)
            objTMST_USER_CHANGE.FUSER_ID = txtFLOGIN_ID.Text            'հ��ID
            intRet = objTMST_USER_CHANGE.GET_TMST_USER(False)           '����
            If intRet = RetCode.OK Then
                '==================================
                ' �߽ܰ������
                '==================================
                If txtFPASS_WORD.Text <> objTMST_USER_CHANGE.FPASS_WORD Then
                    Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_01, _
                                      PopupFormType.Ok, _
                                      PopupIconType.Err)
                    Exit Sub
                End If
            Else
                Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_02, _
                                  PopupFormType.Ok, _
                                  PopupIconType.Err)
                Exit Sub
            End If


            '****************************************************
            '�߽ܰ�ޕύX��ʕ\��
            '****************************************************
            gobjFRM_100006 = Nothing
            gobjFRM_100006 = New FRM_100006     '�߽ܰ�ޕύX���

            Call SetProperty()                                  '�����è���


            '****************************************************
            '�ύX/��ݾ�����
            '****************************************************
            Dim intRtn As DialogResult

            gobjFRM_100006.ShowDialog()

            If intRtn = System.Windows.Forms.DialogResult.Cancel = True Then
                '(��ݾَ�)
                Exit Sub
            End If

            txtFPASS_WORD.Text = ""


        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)
            Throw New System.Exception(ex.Message)

        End Try
    End Sub
#End Region
#Region "  �����޳�         ����                "

    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �����޳ݏ���
    ''' </summary>
    ''' <returns>����FTrue     �ُ�FFalse</returns>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Function PubF_ShutDown() As Boolean
        Dim flags As Shutdown.ShutdownFlag

        PubF_ShutDown = False

        Try

            flags = Shutdown.ShutdownFlag.Shutdown

            ' EWX_FORCEIFHUNG
            '�n���O�A�b�v�����v���O�������I��
            flags = flags Or _
                        Shutdown.ShutdownFlag.ForceIfHung

            ' �V���b�g�_�E�������s
            Shutdown.ExitWindows(flags)

            PubF_ShutDown = True

        Catch ex As Exception
            Throw ex
        Finally
            If IsNull(flags) = False Then
                flags = Nothing
            End If
            If IsNull(flags) = False Then
                flags = Nothing
            End If
        End Try
    End Function
#End Region
#Region "  ۸޲ݏ���                            "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ۸޲ݏ���
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub LogInProcess()

        Try
            Dim intRet As RetCode       '�ߒl�p


            '*******************************************************
            'հ�ްID�擾
            '*******************************************************
            Dim objTMST_USER As New TBL_TMST_USER(gobjOwner, gobjDb, Nothing)
            objTMST_USER.FUSER_ID = txtFLOGIN_ID.Text         '۸޲�ID
            objTMST_USER.GET_TMST_USER(False)               '���擾
            If intRet <> RetCode.OK Then
                Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_02, _
                                  PopupFormType.Ok, _
                                  PopupIconType.Err)
                Exit Sub
            End If

            '==================================
            ' �߽ܰ������
            '==================================
            If txtFPASS_WORD.Text <> objTMST_USER.FPASS_WORD Then
                Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_01, _
                                  PopupFormType.Ok, _
                                  PopupIconType.Err)
                txtFPASS_WORD.Focus()
                Exit Sub
            End If

            '==================================
            ' հ�ޔF�؏�����
            '==================================
            If objTMST_USER.FUSER_ATEST <> FUSER_ATEST_SNORMAL Then
                Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_05, _
                                  PopupFormType.Ok, _
                                  PopupIconType.Err)
                Exit Sub
            End If

            '==================================
            ' հ�ް���擾
            '================================== 
            gcstrFUSER_ID = objTMST_USER.FUSER_ID           'հ�ްID
            gcstrFUSER_NAME = objTMST_USER.FUSER_NAME       'հ�ް��

            '=======================================
            'հ�ް����Ͻ��̓���
            '=======================================
            Dim strSQL As String
            strSQL = ""
            strSQL &= vbCrLf & " SELECT "
            strSQL &= vbCrLf & "    * "
            strSQL &= vbCrLf & " FROM "
            strSQL &= vbCrLf & "    TMST_USER_DSP "
            strSQL &= vbCrLf & " WHERE "
            strSQL &= vbCrLf & "         FUSER_ID = '" & gcstrFUSER_ID & "'"
            Dim objTMST_USER_DSP As New TBL_TMST_USER_DSP(gobjOwner, gobjDb, Nothing)   'հ�ް����Ͻ�
            objTMST_USER_DSP.USER_SQL = strSQL                  'SQL��
            intRet = objTMST_USER_DSP.GET_TMST_USER_DSP_USER()  '�擾
            If intRet <> RetCode.OK Then
                Call gobjComFuncFRM.DisplayPopup(FRM_MSG_FRM100001_04, _
                                  PopupFormType.Ok, _
                                  PopupIconType.Err)
                Exit Sub
            End If
            For ii As Integer = LBound(objTMST_USER_DSP.ARYME) To UBound(objTMST_USER_DSP.ARYME)
                '(ٰ��:�擾���������̐�)
                ReDim Preserve gcintFUSER_LEVEL(ii)
                gcintFUSER_LEVEL(ii) = objTMST_USER_DSP.ARYME(ii).FUSER_DSP_LEVEL       'հ�ް��������
            Next


            '**********************************************************
            ' ��ʋN��
            '**********************************************************
            Dim objTDSP_TERM As New TBL_TDSP_TERM(gobjOwner, gobjDb, Nothing)
            objTDSP_TERM.FTERM_ID = gcstrFTERM_ID       '�[��ID     ���
            objTDSP_TERM.GET_TDSP_TERM(False)           '���擾

            Dim strPara As String = objTDSP_TERM.FDISP_ID
            Call gobjComFuncFRM.FormMoveSelect(strPara, Me)

            '**********************************************************
            ' ۸޵��׸�False
            '**********************************************************
            gblnLogoff = False          '۸޵ݏ��


            Me.Close()
            Me.Dispose()


        Catch ex As Exception
            gobjComFuncFRM.ComError_frm(ex)
            Throw New System.Exception(ex.Message)

        End Try

    End Sub
#End Region
#Region "  �߽ܰ�ޕύX��ʂ������è��ā@        "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' �߽ܰ�ޕύX��ʂ������è���
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SetProperty()

        gobjFRM_100006.userFUSER_ID = TO_STRING(txtFLOGIN_ID.Text)                  'հ�ްID
        gobjFRM_100006.userFUSER_NAME = TO_STRING(lblFUSER_NAME.Text)               'հ�ް��

    End Sub

#End Region
#Region "  ���đ��M01                           "
    ''' *******************************************************************************************************************
    ''' <summary>
    ''' ���đ��M01
    ''' </summary>
    ''' <remarks></remarks>
    ''' *******************************************************************************************************************
    Private Sub SendSocket01()
        Dim intRet As RetCode           '�ߒl�p


        '*******************************************************
        'հ�ްID�擾
        '*******************************************************
        Dim objTMST_USER As New TBL_TMST_USER(gobjOwner, gobjDb, Nothing)
        objTMST_USER.FUSER_ID = txtFLOGIN_ID.Text             '۸޲�ID
        intRet = objTMST_USER.GET_TMST_USER(False)          '���擾
        If intRet = RetCode.OK Then
            gcstrFUSER_ID = objTMST_USER.FUSER_ID           'հ�ްID
        Else
            gcstrFUSER_ID = ""                              'հ�ްID
        End If


        '*******************************************************
        '���đ��M����
        '*******************************************************
        Dim strRET_STATE As String = ""                 '�����ð��
        Dim udtSckSendRET As clsSocketClient.RetCode    '���đ��M�߂�l
        udtSckSendRET = gobjComFuncFRM.SendSockLogin(txtFLOGIN_ID.Text _
                                    , txtFPASS_WORD.Text _
                                    , strRET_STATE _
                                    , FSYORI_ID_S200002 _
                                    )
        If udtSckSendRET = clsSocketClient.RetCode.OK Then
            '(���M�ł����ꍇ)
            If strRET_STATE = ID_RETURN_RET_STATE_OK Then
                '(����I���̏ꍇ)

                Call LogInProcess()    '۸޲ݏ�����

            Else
                txtFPASS_WORD.Text = ""
                txtReFPASS_WORD.Text = ""
                txtFPASS_WORD.Focus()
            End If
        Else
            txtFPASS_WORD.Text = ""
            txtReFPASS_WORD.Text = ""
            txtFPASS_WORD.Focus()
        End If

    End Sub
#End Region
#Region "  �ؽ����߰�����ѓǍ�                  "
    ''' <summary>
    ''' �ؽ����߰�����ѓǍ�
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadCR()


        '***********************************************
        ' �e��޼ު�Ă̲ݽ�ݽ
        '***********************************************
        Dim objCR As New PRT_000001          '�ؽ����߰ĵ�޼ު��
        Dim objDataSet As New clsPrintDataSet   '�ް�ð��ٵ�޼ު��
        Try


            '***********************************************
            ' ͯ�ް�����쐬
            '***********************************************
            '================================
            ' �ް����
            '================================
            Call gobjComFuncFRM.ChangeCRText(objCR, "crDateTime01", Format(Now, GAMEN_DATE_FORMAT_02))         '���s����

            Dim objDataRow As clsPrintDataSet.DataTable01Row
            objDataRow = objDataSet.DataTable01.NewRow
            objDataRow.BeginEdit()
            objDataRow.Data00 = "1"
            objDataRow.EndEdit()
            objDataSet.DataTable01.Rows.Add(objDataRow)


            '***********************************************
            ' �ؽ����߰Ă��ް���Ă��
            '***********************************************
            objCR.SetDataSource(objDataSet)
            'objCR.PrintToPrinter(0, False, 0, 0)    ' ��


            '***********************************************
            ' �ؽ����߰Ă���а�󎚏���
            '***********************************************
            Dim objetc1201 As New FRM_100003
            If IsNull(objetc1201) = False Then
                objetc1201.Close()
                objetc1201.Dispose()
                objetc1201 = Nothing
            End If
            objetc1201 = FRM_100003
            objetc1201.CrystalReportViewer1.ReportSource = objCR
            objetc1201.Opacity = 0
            objetc1201.Show()
            objetc1201.Close()
            objetc1201.Dispose()
            objetc1201 = Nothing


        Catch ex As Exception
            Throw ex

        Finally
            Try
                '�ؽ����߰ĵ�޼ު��
                objCR.Dispose()
                objCR = Nothing
                '�ް�ð��ٵ�޼ު��
                objDataSet.Dispose()
                objDataSet = Nothing
                Call gobjComFuncFRM.AddToLog_frm("LoadCR�گ�ޏI���B")
            Catch ex As Exception
                Throw ex
            End Try
        End Try

    End Sub
#End Region

End Class